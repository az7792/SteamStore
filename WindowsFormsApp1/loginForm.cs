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
    public partial class loginForm : Form
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

        private static loginForm instance;
        private static readonly object lockObject = new object();

        private loginForm()
        {
            InitializeComponent(); 
        }

        public static loginForm GetInstance()//单例模式
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new loginForm();
                    }
                }
            }
            return instance;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AMD\source\repos\WindowsFormsApp1\WindowsFormsApp1\SteamStore.mdf;Integrated Security=True;Connect Timeout=30");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ:1460014874");
        }

        private void button1_Click_1(object sender, EventArgs e)//登录
        {
            if(userName.Text==""||userPassword.Text=="")
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else//处理登录
            {
                Con.Open();
                string query = "select count(*) from UserTable where Uname = @Uname and Upassword = @Upassword";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", userName.Text);
                    Com.Parameters.AddWithValue("@Upassword", userPassword.Text);
                    if((int)Com.ExecuteScalar()==1)
                    {
                        //切换界面
                        StoreForm storeForm = StoreForm.GetInstance();
                        storeForm.Location = this.Location;
                        storeForm.NewLoad(userName.Text);
                        storeForm.Show();
                        this.Hide();
                        //this.Close();
                        //MessageBox.Show("登录成功！");
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误！");
                        userPassword.Text = "";
                    }
                    Con.Close();
                }                
            }
        }

        private void button2_Click(object sender, EventArgs e)//注册
        {
            if(RegP1.Text!=RegP2.Text)//密码不一致
            {
                MessageBox.Show("密码不一致");
                RegP2.Text = "";
            }
            else if (RegUserName.Text == "" || RegP1.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else//处理注册
            {
                Con.Open();
                string query = "select count(*) from UserTable where Uname = @Uname";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", RegUserName.Text);
                    if ((int)Com.ExecuteScalar() == 1)//已被注册
                    {
                        MessageBox.Show("用户名已被注册！");
                        Con.Close();
                        return;
                    }
                }
                //注册成功
                //更新用户
                query = "insert into UserTable(Uname, Upassword) values(@Uname, @Upassword)";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", RegUserName.Text);                    
                    Com.Parameters.AddWithValue("@Upassword", RegP1.Text);
                    Com.ExecuteNonQuery();//更新数据库                    
                }
                //创建用户游戏库
                query = "CREATE TABLE [dbo].[_"+RegUserName.Text+"GL]([GId] INT NOT NULL, PRIMARY KEY([GId]))";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.ExecuteNonQuery();//更新数据库                    
                }
                Con.Close();
                MessageBox.Show("注册成功");
                inORup.Text = "登录";
                RegisterPanel.Enabled = false;
                RegisterPanel.Visible = false;
                loginPanel.Enabled = true;
                loginPanel.Visible = true;
                //this.Text = "Steam-登录";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ:1460014874");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            inORup.Text = "注册";
            loginPanel.Enabled = false;
            loginPanel.Visible = false;
            RegisterPanel.Enabled = true;
            RegisterPanel.Visible = true;
            //this.Text = "Steam-注册";
        }

        private void label10_Click(object sender, EventArgs e)
        {
            inORup.Text = "登录";
            RegisterPanel.Enabled = false;
            RegisterPanel.Visible = false;
            loginPanel.Enabled = true;
            loginPanel.Visible = true;
            //this.Text = "Steam-登录";
        }
        public void NewLoad()
        {
            inORup.Text = "登录";
            RegisterPanel.Enabled = false;
            RegisterPanel.Visible = false;
            loginPanel.Enabled = true;
            loginPanel.Visible = true;
            RegUserName.Text = "";
            RegP1.Text = "";
            RegP2.Text = "";
            userName.Text = "";
            userPassword.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
