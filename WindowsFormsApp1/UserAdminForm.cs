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
    public partial class UserAdminForm : Form
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

        private static UserAdminForm instance;
        private static readonly object lockObject = new object();

        private UserAdminForm()
        {
            InitializeComponent();
        }

        public static UserAdminForm GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserAdminForm();
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
            string query = "select Uname,Upassword,Ubalance,UId from UserTable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gameDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        public static string UName=string.Empty;
        public static string OUName=string.Empty;

        public void NewLoad(string Uname)
        {
            UName = Uname;
            Populate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UserForm userForm = UserForm.GetInstance();
            userForm.Location = this.Location;
            userForm.NewLoad(UName);
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select Uname,Upassword,Ubalance,UId from UserTable where Uname like '%" + SearchBox.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            gameDGV.DataSource = ds.Tables[0];
            Con.Close();
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
                textBox1.Text = selectedRow.Cells[3].Value.ToString();//UId
                textBox4.Text = selectedRow.Cells[0].Value.ToString();//用户名
                textBox2.Text = selectedRow.Cells[1].Value.ToString();//密码
                textBox5.Text = selectedRow.Cells[2].Value.ToString();//余额               
                OUName = textBox4.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if(OUName==UName)
                {
                    MessageBox.Show("你不能删除自己");
                    return;
                }
                Con.Open();
                string query = "DELETE FROM UserTable WHERE UId = @UId";//删除行
                using (SqlCommand command = new SqlCommand(query, Con))
                {
                    command.Parameters.AddWithValue("@UId", textBox1.Text);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("删除成功！");                      
                    }
                }

                query = "DROP TABLE _"+ OUName + "GL";//删除对应库
                using (SqlCommand command = new SqlCommand(query, Con))
                {                    
                    command.ExecuteNonQuery();                
                }
                Populate();
                Con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else//处理注册
            {
                Con.Open();
                string query = "select count(*) from UserTable where Uname = @Uname";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", textBox4.Text);
                    if ((int)Com.ExecuteScalar() == 1)//已被注册
                    {
                        MessageBox.Show("用户名已被注册！");
                        Con.Close();
                        return;
                    }
                }
                //注册成功
                //更新用户
                query = "insert into UserTable(Uname, Upassword,Ubalance) values(@Uname, @Upassword,@Ubalance)";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", textBox4.Text);
                    Com.Parameters.AddWithValue("@Upassword", textBox2.Text);
                    Com.Parameters.AddWithValue("@Ubalance", textBox5.Text);
                    Com.ExecuteNonQuery();//更新数据库                    
                }
                //创建用户游戏库
                query = "CREATE TABLE [dbo].[_" + textBox4.Text + "GL]([GId] INT NOT NULL, PRIMARY KEY([GId]))";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.ExecuteNonQuery();//更新数据库                    
                }
                Con.Close();
                MessageBox.Show("添加成功");
                Populate();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select count(*) from UserTable where UId = @UId";//判断是否已经存在
            using (SqlCommand command = new SqlCommand(query, Con))
            {
                command.Parameters.AddWithValue("@UId", textBox1.Text);
                if ((int)command.ExecuteScalar() == 0)
                {
                    MessageBox.Show("修改失败：用户不存在");
                }
                else//修改
                {
                    if (OUName != textBox4.Text)
                    {
                        query = "select count(*) from UserTable where Uname = @Uname";
                        using (SqlCommand Com = new SqlCommand(query, Con))
                        {
                            Com.Parameters.AddWithValue("@Uname", textBox4.Text);
                            if ((int)Com.ExecuteScalar() == 1)//已被注册
                            {
                                MessageBox.Show("用户名已存在！");
                                Con.Close();
                                return;
                            }
                        }
                        query = "EXEC sp_rename '_" + UName + "GL', '_" + textBox4.Text + "GL'"; // 更新表名
                        using (SqlCommand Com = new SqlCommand(query, Con))
                        {
                            Com.ExecuteNonQuery();
                        }
                    }
                    query = "UPDATE UserTable SET Uname = @Uname, Upassword = @Upassword, Ubalance = @Ubalance WHERE UId = @UId";
                    using (SqlCommand Com = new SqlCommand(query, Con))
                    {                        
                        Com.Parameters.AddWithValue("@Uname", textBox4.Text);
                        Com.Parameters.AddWithValue("@Upassword", textBox2.Text);
                        Com.Parameters.AddWithValue("@Ubalance", textBox5.Text);
                        Com.Parameters.AddWithValue("@UId", textBox1.Text);
                        Com.ExecuteNonQuery(); // 更新数据库
                        if (OUName == UName)
                            UName = textBox4.Text;
                        MessageBox.Show("更新成功");
                        Populate();
                        Con.Close();
                        return;
                    }                    

                }
            }
            Con.Close();
        }
    }
}