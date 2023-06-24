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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class GameAdminForm : Form
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

        private static GameAdminForm instance;
        private static readonly object lockObject = new object();

        private GameAdminForm()
        {
            InitializeComponent();
        }

        public static GameAdminForm GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new GameAdminForm();
                    }
                }
            }
            return instance;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AMD\source\repos\WindowsFormsApp1\WindowsFormsApp1\SteamStore.mdf;Integrated Security=True;Connect Timeout=30");
        private void Populate()
        {
            if (!Con.State.Equals(ConnectionState.Open))
                Con.Open();
            string query = "select GImage,Gname,GAuthor,GTime,GType,GPrice,GId from GameTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }


        public void NewLoad()
        {
            Populate();
        }

        private void gameDGV_SelectionChanged(object sender, EventArgs e)
        {
            // 获取选中的行
            DataGridViewRow selectedRow = null;
            if (gameDGV.SelectedRows.Count > 0)
            {
                selectedRow = gameDGV.SelectedRows[0];
            }

            if (selectedRow != null)
            {
                textBox1.Text = selectedRow.Cells[6].Value.ToString();//GId
                textBox4.Text = selectedRow.Cells[1].Value.ToString();//游戏名
                textBox2.Text = selectedRow.Cells[2].Value.ToString();//作者
                textBox5.Text = selectedRow.Cells[5].Value.ToString();//价格
                comboBox1.Text = selectedRow.Cells[4].Value.ToString();//类型
                if(selectedRow.Cells[3].Value.ToString()=="")
                    dateTimePicker1.Value = DateTime.Parse("1753-1-1");//时间
                else
                    dateTimePicker1.Value = DateTime.Parse(selectedRow.Cells[3].Value.ToString());//时间
                                                                                                  //selectedRow.Cells[0].Value.ToString();//图片
                if (selectedRow.Cells[0].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])selectedRow.Cells[0].Value;
                    MemoryStream ms = new MemoryStream(imageData);
                    pictureBox2.Image = Image.FromStream(ms);
                }
                else
                {
                    // 处理空值情况
                    pictureBox2.Image = null;
                }
            }            
         }


        private void button4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SearchButton_Click_1(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select GImage,Gname,GAuthor,GTime,GType,GPrice,GId from GameTable where Gname like '%" + SearchBox.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void gameDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBox2.Image = Image.FromFile(imagePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                Con.Open();
                string query = "DELETE FROM GameTable WHERE GId = @GId";//删除行
                using (SqlCommand command = new SqlCommand(query, Con))
                {
                    command.Parameters.AddWithValue("@GId", textBox1.Text);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("删除成功！");
                        Con.Close();
                        Populate();
                        return;
                    }
                }
                Con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select count(*) from GameTable where Gname = @Gname";//判断是否已经存在
            using (SqlCommand command = new SqlCommand(query, Con))
            {
                command.Parameters.AddWithValue("@Gname", textBox4.Text);
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("添加失败：游戏已存在");
                }
                else//新增加
                {
                    query = "insert into GameTable(GImage,Gname,GAuthor,GTime,GType,GPrice) values(@GImage,@Gname,@GAuthor,@GTime,@GType,@GPrice)";
                    using (SqlCommand Com = new SqlCommand(query, Con))
                    {
                        byte[] imageBytes;
                        if (pictureBox2.Image == null)
                            pictureBox2.Image = pictureBox3.Image;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            ms.Position = 0;
                            imageBytes =  ms.ToArray();
                        }

                        Com.Parameters.AddWithValue("@GImage", imageBytes);
                        Com.Parameters.AddWithValue("@Gname", textBox4.Text);
                        Com.Parameters.AddWithValue("@GAuthor", textBox2.Text);
                        Com.Parameters.AddWithValue("@GTime", dateTimePicker1.Value);
                        Com.Parameters.AddWithValue("@GType", comboBox1.Text);
                        Com.Parameters.AddWithValue("@GPrice", textBox5.Text);
                        Com.ExecuteNonQuery();//更新数据库
                        MessageBox.Show("添加成功");
                        Populate();
                        Con.Close();
                        return;
                    }
                }
            }
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select count(*) from GameTable where GId = @GId";//判断是否已经存在
            using (SqlCommand command = new SqlCommand(query, Con))
            {
                command.Parameters.AddWithValue("@GId", textBox1.Text);
                if ((int)command.ExecuteScalar() == 0)
                {
                    MessageBox.Show("修改失败：游戏不存在");
                }
                else//修改
                {
                    query = "UPDATE GameTable SET GImage = @GImage, Gname = @Gname, GAuthor = @GAuthor, GTime = @GTime, GType = @GType, GPrice = @GPrice WHERE GId = @GId";
                    using (SqlCommand Com = new SqlCommand(query, Con))
                    {
                        byte[] imageBytes = new byte[0];
                        if (pictureBox2.Image != null)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                imageBytes = ms.ToArray();
                            }
                        }                        
                        Com.Parameters.AddWithValue("@GImage", imageBytes);
                        Com.Parameters.AddWithValue("@Gname", textBox4.Text);
                        Com.Parameters.AddWithValue("@GAuthor", textBox2.Text);
                        Com.Parameters.AddWithValue("@GTime", dateTimePicker1.Value);
                        Com.Parameters.AddWithValue("@GType", comboBox1.Text);
                        Com.Parameters.AddWithValue("@GPrice", textBox5.Text);
                        Com.Parameters.AddWithValue("@GId", textBox1.Text); 
                        Com.ExecuteNonQuery(); // 更新数据库
                        MessageBox.Show("更新成功");
                        Populate();
                        Con.Close();
                        return;
                    }

                }
            }
            Con.Close();
        }

        private void UNamelabel_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserForm userForm = UserForm.GetInstance();
            userForm.Location = this.Location;
            userForm.NewLoad("");
            userForm.Show();
            this.Hide();
        }
    }
}
