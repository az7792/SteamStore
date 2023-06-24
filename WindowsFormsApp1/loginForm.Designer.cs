
namespace WindowsFormsApp1
{
    partial class loginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.inORup = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RegisterPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.RegP2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.RegP1 = new System.Windows.Forms.TextBox();
            this.RegUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.loginPanel.SuspendLayout();
            this.RegisterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // inORup
            // 
            this.inORup.AutoSize = true;
            this.inORup.BackColor = System.Drawing.Color.Transparent;
            this.inORup.Font = new System.Drawing.Font("黑体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inORup.ForeColor = System.Drawing.Color.White;
            this.inORup.Location = new System.Drawing.Point(345, 126);
            this.inORup.Name = "inORup";
            this.inORup.Size = new System.Drawing.Size(122, 50);
            this.inORup.TabIndex = 0;
            this.inORup.Text = "登录";
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.loginPanel.Controls.Add(this.label9);
            this.loginPanel.Controls.Add(this.label4);
            this.loginPanel.Controls.Add(this.button1);
            this.loginPanel.Controls.Add(this.userPassword);
            this.loginPanel.Controls.Add(this.userName);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Location = new System.Drawing.Point(354, 179);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(571, 415);
            this.loginPanel.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(463, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 19);
            this.label9.TabIndex = 7;
            this.label9.Text = "注册";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(188, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "无法登录请联系管理员";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.button1.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(109, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(348, 71);
            this.button1.TabIndex = 5;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // userPassword
            // 
            this.userPassword.Font = new System.Drawing.Font("宋体", 20F);
            this.userPassword.Location = new System.Drawing.Point(60, 186);
            this.userPassword.MaxLength = 10;
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(440, 46);
            this.userPassword.TabIndex = 4;
            this.userPassword.UseSystemPasswordChar = true;
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("宋体", 20F);
            this.userName.Location = new System.Drawing.Point(60, 80);
            this.userName.MaxLength = 10;
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(440, 46);
            this.userName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("黑体", 10F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(57, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("黑体", 10F);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(57, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "用账户名称登录";
            // 
            // RegisterPanel
            // 
            this.RegisterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(26)))), ((int)(((byte)(33)))));
            this.RegisterPanel.Controls.Add(this.label10);
            this.RegisterPanel.Controls.Add(this.RegP2);
            this.RegisterPanel.Controls.Add(this.label8);
            this.RegisterPanel.Controls.Add(this.label5);
            this.RegisterPanel.Controls.Add(this.button2);
            this.RegisterPanel.Controls.Add(this.RegP1);
            this.RegisterPanel.Controls.Add(this.RegUserName);
            this.RegisterPanel.Controls.Add(this.label6);
            this.RegisterPanel.Controls.Add(this.label7);
            this.RegisterPanel.Enabled = false;
            this.RegisterPanel.Location = new System.Drawing.Point(354, 179);
            this.RegisterPanel.Name = "RegisterPanel";
            this.RegisterPanel.Size = new System.Drawing.Size(571, 415);
            this.RegisterPanel.TabIndex = 2;
            this.RegisterPanel.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.DarkGray;
            this.label10.Location = new System.Drawing.Point(463, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "登录";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // RegP2
            // 
            this.RegP2.Font = new System.Drawing.Font("宋体", 20F);
            this.RegP2.Location = new System.Drawing.Point(60, 225);
            this.RegP2.MaxLength = 10;
            this.RegP2.Name = "RegP2";
            this.RegP2.Size = new System.Drawing.Size(440, 46);
            this.RegP2.TabIndex = 8;
            this.RegP2.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("黑体", 10F);
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(57, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "再次输入密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("黑体", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(188, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "无法注册请联系管理员";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(109, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(348, 71);
            this.button2.TabIndex = 5;
            this.button2.Text = "注册";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RegP1
            // 
            this.RegP1.Font = new System.Drawing.Font("宋体", 20F);
            this.RegP1.Location = new System.Drawing.Point(60, 147);
            this.RegP1.MaxLength = 10;
            this.RegP1.Name = "RegP1";
            this.RegP1.Size = new System.Drawing.Size(440, 46);
            this.RegP1.TabIndex = 4;
            this.RegP1.UseSystemPasswordChar = true;
            // 
            // RegUserName
            // 
            this.RegUserName.Font = new System.Drawing.Font("宋体", 20F);
            this.RegUserName.Location = new System.Drawing.Point(60, 70);
            this.RegUserName.MaxLength = 10;
            this.RegUserName.Name = "RegUserName";
            this.RegUserName.Size = new System.Drawing.Size(440, 46);
            this.RegUserName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("黑体", 10F);
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(57, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("黑体", 10F);
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(57, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "账户名称";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.button3.Location = new System.Drawing.Point(1211, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 39);
            this.button3.TabIndex = 3;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button4.Location = new System.Drawing.Point(1166, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(39, 39);
            this.button4.TabIndex = 4;
            this.button4.Text = "—";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // loginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.ControlBox = false;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.RegisterPanel);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.inORup);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Steam";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.RegisterPanel.ResumeLayout(false);
            this.RegisterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inORup;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel RegisterPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox RegP1;
        private System.Windows.Forms.TextBox RegUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RegP2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

