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
    public partial class LibForm : Form
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

        private static LibForm instance;
        private static readonly object lockObject = new object();

        private LibForm()
        {
            InitializeComponent();
        }

        public static LibForm GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new LibForm();
                    }
                }
            }
            return instance;
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AMD\source\repos\WindowsFormsApp1\WindowsFormsApp1\SteamStore.mdf;Integrated Security=True;Connect Timeout=30");
        private void Populate()
        {
            Con.Open();
            string query = "select GImage, Gname, GAuthor, GTime, GType, GPrice from GameTable JOIN _"+UNamelabel.Text+"GL ON GameTable.GId = _"+UNamelabel.Text + "GL.GID";
            //string query = "select GImage, Gname, GAuthor, GTime, GType, GPrice from GameTable JOIN _"+"7792"+"GL ON GameTable.GId = _7792GL.GID";
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

        private void label3_Click(object sender, EventArgs e)
        {
            UserForm userForm = UserForm.GetInstance();
            userForm.Location = this.Location;
            userForm.NewLoad(UNamelabel.Text);
            userForm.Show();
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

        private void LibForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
