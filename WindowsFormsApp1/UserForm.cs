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
    public partial class UserForm : Form
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

        private static UserForm instance;
        private static readonly object lockObject = new object();

        private UserForm()
        {
            InitializeComponent();
        }

        public static UserForm GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new UserForm();
                    }
                }
            }
            return instance;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AMD\source\repos\WindowsFormsApp1\WindowsFormsApp1\SteamStore.mdf;Integrated Security=True;Connect Timeout=30");
        public void NewLoad(string Uname)
        {
            if (Uname == "")
                return;
            UNamelabel.Text = Uname;            
            textBox1.Text = Uname;
            string query = "select Ubalance from UserTable where Uname = @Uname";
            using (SqlCommand command = new SqlCommand(query, Con))
            {
                Con.Open();
                command.Parameters.AddWithValue("@Uname",Uname);
                label3.Text = "余额：" + command.ExecuteScalar().ToString();
                Con.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LibForm lib = LibForm.GetInstance();
            lib.Location = this.Location;
            lib.NewLoad(UNamelabel.Text);
            lib.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            StoreForm storeForm = StoreForm.GetInstance();
            storeForm.Location = this.Location;
            storeForm.NewLoad(UNamelabel.Text);
            storeForm.Show();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginForm login = loginForm.GetInstance();
            login.Location = this.Location;
            login.NewLoad();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select count(*) from UserTable where Uname = @Uname";
            using (SqlCommand Com = new SqlCommand(query, Con))
            {
                Com.Parameters.AddWithValue("@Uname", textBox1.Text);
                if ((int)Com.ExecuteScalar() == 1)//已被注册
                {
                    MessageBox.Show("用户名已存在！");                    
                }
                else
                {
                    query = "UPDATE UserTable SET Uname = @NowUname WHERE Uname = @Uname";//更新名称
                    using (SqlCommand command = new SqlCommand(query, Con))
                    {                        
                        command.Parameters.AddWithValue("@NowUname", textBox1.Text);
                        command.Parameters.AddWithValue("@Uname", UNamelabel.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("修改成功！");                        
                    }

                    query = "EXEC sp_rename '_"+UNamelabel.Text+"GL', '_"+textBox1.Text+"GL'"; // 更新表名
                    using (SqlCommand command = new SqlCommand(query, Con))
                    {
                        command.ExecuteNonQuery();
                    }

                    UNamelabel.Text = textBox1.Text;
                }
                Con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请联系管理员充值QQ：1460014874");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Enabled = false;
            ChangePasswordPanel.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ:1460014874");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Enabled = true;
            ChangePasswordPanel.Visible = true;
            OPassword.Text = "";
            NPassword1.Text = "";
            NPassword2.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (OPassword.Text == "" || NPassword1.Text == ""||NPassword2.Text=="")
            {
                MessageBox.Show("密码不能为空");
            }
            else if(NPassword1.Text != NPassword2.Text )
            {
                MessageBox.Show("密码不一致！");
            }
            else//密码修改
            {
                Con.Open();
                //验证原密码
                string query = "select count(*) from UserTable where Uname = @Uname and Upassword = @Upassword";
                using (SqlCommand Com = new SqlCommand(query, Con))
                {
                    Com.Parameters.AddWithValue("@Uname", UNamelabel.Text);
                    Com.Parameters.AddWithValue("@Upassword", OPassword.Text);
                    if ((int)Com.ExecuteScalar() == 1)//验证成功
                    {
                        if (NPassword1.Text == OPassword.Text)
                        {
                            MessageBox.Show("新密码不能与原密码一样！");
                        }
                        else//修改密码
                        {
                            query = "UPDATE UserTable SET Upassword = @NPassword WHERE Uname = @Uname";//更新名称
                            using (SqlCommand command = new SqlCommand(query, Con))
                            {
                                command.Parameters.AddWithValue("@NPassword", NPassword1.Text);
                                command.Parameters.AddWithValue("@Uname", UNamelabel.Text);
                                command.ExecuteNonQuery();
                                MessageBox.Show("修改成功！");
                                ChangePasswordPanel.Enabled = false;
                                ChangePasswordPanel.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("原密码错误！");
                    }
                    Con.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            GameAdminForm gameAdminForm = GameAdminForm.GetInstance();
            gameAdminForm.Location = this.Location;
            gameAdminForm.NewLoad();
            gameAdminForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UserAdminForm userAdminForm = UserAdminForm.GetInstance();
            userAdminForm.Location = this.Location;
            userAdminForm.NewLoad(UNamelabel.Text);
            userAdminForm.Show();
            this.Hide();
        }
    }
}
