using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class StoreForm : Form
    {

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return parameters;
            }
        }

        private static StoreForm instance;
        private static readonly object lockObject = new object();

        private StoreForm()
        {
            InitializeComponent();
        }

        public static StoreForm GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new StoreForm();
                    }
                }
            }
            return instance;
        }
        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AMD\source\repos\WindowsFormsApp1\WindowsFormsApp1\SteamStore.mdf;Integrated Security=True;Connect Timeout=30");
        private void Populate()
        {
            Con.Open();
            string query = "select GImage,Gname,GAuthor,GTime,GType,GPrice,GId from GameTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select GImage,Gname,GAuthor,GTime,GType,GPrice,GId from GameTable where Gname like '%"+ SearchBox.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        public void NewLoad(string Uname)
        {
            UNamelabel.Text = Uname;
            Populate();
        }

        private void StoreForm_Load(object sender, EventArgs e)
        {

        }

        public static string GameOwner = string.Empty;
        private void BuyGames()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                float Price = float.Parse(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                Con.Open();
                string query = "select Ubalance from UserTable where Uname = @Uname";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", UNamelabel.Text);
                    if (Com.ExecuteScalar() == null)
                    {
                        MessageBox.Show("购买失败,付款方不存在！！");
                    }
                    else
                    {
                        //判断游戏获得方是否存在
                        query = "select Uname from UserTable where Uname = @Uname";
                        using (SqlCommand command = new SqlCommand(query, Con))
                        {
                            command.Parameters.AddWithValue("@Uname", GameOwner);
                            if (command.ExecuteScalar() == null)//不存在
                            {
                                MessageBox.Show("对象不存在！");
                                Con.Close();
                                return;
                            }
                        }
                        //判断用户是否已经购买
                        query = "select count(*) from _" + GameOwner + "GL where GId = @GId";
                        using (SqlCommand command = new SqlCommand(query, Con))
                        {
                            command.Parameters.AddWithValue("@GId", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                            if ((int)command.ExecuteScalar() == 1)//已经买过了
                            {
                                MessageBox.Show("该游戏已在库中，请勿重复购买！");
                                Con.Close();
                                return;
                            }
                        }

                        Price = Convert.ToSingle(Com.ExecuteScalar()) - Price;
                        if (Price < 0)
                        {
                            MessageBox.Show("余额不足！");
                        }
                        else//更新
                        {                            
                            query = "UPDATE UserTable SET Ubalance = @Ubalance WHERE Uname = @Uname";//更新余额
                            using (SqlCommand command = new SqlCommand(query, Con))
                            {
                                command.Parameters.AddWithValue("@Ubalance", Price);
                                command.Parameters.AddWithValue("@Uname", UNamelabel.Text);
                                command.ExecuteNonQuery();
                            }

                            query = "insert into _" + GameOwner + "GL(GId) values(@GId)";//更新库
                            using (SqlCommand command = new SqlCommand(query, Con))
                            {
                                command.Parameters.AddWithValue("@GId", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                                command.ExecuteNonQuery();
                            }
                            MessageBox.Show("购买成功");
                        }
                    }
                    Con.Close();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)//购买游戏
        {
            GameOwner = UNamelabel.Text;
            BuyGames();
        }

        private void gameDGV_SelectionChanged(object sender, EventArgs e)
        {
            // 获取选中的行
            DataGridViewRow selectedRow = null;
            if (gameDGV.SelectedRows.Count > 0)
            {
                selectedRow = gameDGV.SelectedRows[0];
            }

            // 获取选中行的多列的值
            string columnValue1 = string.Empty;
            string columnValue2 = string.Empty;
            string columnValue3 = string.Empty;

            if (selectedRow != null)
            {
                columnValue1 = selectedRow.Cells[1].Value.ToString(); 
                columnValue2 = selectedRow.Cells[5].Value.ToString(); 
                columnValue3 = selectedRow.Cells[6].Value.ToString(); 
            }

            // 将选中行的多列内容添加到第二个DataGridView中
            dataGridView1.Rows.Clear();
            if (!string.IsNullOrEmpty(columnValue1) && !string.IsNullOrEmpty(columnValue2)&& !string.IsNullOrEmpty(columnValue3))
            {
                dataGridView1.Rows.Add(columnValue1, columnValue2, columnValue3);
            }
        }

        private void gameDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameOwner = textBox1.Text;
            BuyGames();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LibForm lib = LibForm.GetInstance();
            lib.Location = this.Location;
            lib.NewLoad(UNamelabel.Text);
            lib.Show();
            this.Hide();
        }

        private void UNamelabel_Click(object sender, EventArgs e)
        {
            UserForm userForm = UserForm.GetInstance();
            userForm.Location = this.Location;
            userForm.NewLoad(UNamelabel.Text);
            userForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
