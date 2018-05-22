namespace VVClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.getTimer = new System.Windows.Forms.Timer(this.components);
            this.btnLogin = new System.Windows.Forms.Button();
            this.userPanel = new System.Windows.Forms.Panel();
            this.txtMaxMoney = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMinMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCountMoney = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTerm = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMoney = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblXing = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValid = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoni = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLeft = new System.Windows.Forms.RichTextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.leaveTime = new System.Windows.Forms.Label();
            this.countTimer = new System.Windows.Forms.Timer(this.components);
            this.dueTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stripMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.stripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.selMult = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(578, 7);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(58, 23);
            this.btnLogin.TabIndex = 43;
            this.btnLogin.Text = "登　录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // userPanel
            // 
            this.userPanel.Controls.Add(this.txtMaxMoney);
            this.userPanel.Controls.Add(this.label19);
            this.userPanel.Controls.Add(this.txtMinMoney);
            this.userPanel.Controls.Add(this.label1);
            this.userPanel.Controls.Add(this.lblCountMoney);
            this.userPanel.Controls.Add(this.label11);
            this.userPanel.Controls.Add(this.lblResult);
            this.userPanel.Controls.Add(this.lblTerm);
            this.userPanel.Controls.Add(this.label10);
            this.userPanel.Controls.Add(this.label5);
            this.userPanel.Controls.Add(this.lblMoney);
            this.userPanel.Controls.Add(this.label4);
            this.userPanel.Controls.Add(this.label7);
            this.userPanel.Controls.Add(this.lblUser);
            this.userPanel.Controls.Add(this.lblXing);
            this.userPanel.Location = new System.Drawing.Point(5, 35);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(798, 55);
            this.userPanel.TabIndex = 41;
            // 
            // txtMaxMoney
            // 
            this.txtMaxMoney.Location = new System.Drawing.Point(702, 5);
            this.txtMaxMoney.Name = "txtMaxMoney";
            this.txtMaxMoney.Size = new System.Drawing.Size(73, 21);
            this.txtMaxMoney.TabIndex = 67;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(655, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 66;
            this.label19.Text = "止盈：";
            // 
            // txtMinMoney
            // 
            this.txtMinMoney.Location = new System.Drawing.Point(554, 4);
            this.txtMinMoney.Name = "txtMinMoney";
            this.txtMinMoney.Size = new System.Drawing.Size(73, 21);
            this.txtMinMoney.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(515, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "止损：";
            // 
            // lblCountMoney
            // 
            this.lblCountMoney.AutoSize = true;
            this.lblCountMoney.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCountMoney.ForeColor = System.Drawing.Color.Red;
            this.lblCountMoney.Location = new System.Drawing.Point(472, 5);
            this.lblCountMoney.Name = "lblCountMoney";
            this.lblCountMoney.Size = new System.Drawing.Size(16, 16);
            this.lblCountMoney.TabIndex = 63;
            this.lblCountMoney.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(404, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 62;
            this.label11.Text = "累计下注：";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblResult.Location = new System.Drawing.Point(8, 33);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(59, 16);
            this.lblResult.TabIndex = 61;
            this.lblResult.Text = "上期：";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTerm.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTerm.Location = new System.Drawing.Point(504, 33);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(0, 14);
            this.lblTerm.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 11F);
            this.label10.Location = new System.Drawing.Point(419, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 59;
            this.label10.Text = "当前期数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "信用：";
            // 
            // lblMoney
            // 
            this.lblMoney.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMoney.ForeColor = System.Drawing.Color.Purple;
            this.lblMoney.Location = new System.Drawing.Point(302, 4);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(61, 18);
            this.lblMoney.TabIndex = 16;
            this.lblMoney.Text = "0";
            this.lblMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "账    号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(262, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "金额：";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUser.Location = new System.Drawing.Point(72, 7);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(44, 12);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "未登录";
            // 
            // lblXing
            // 
            this.lblXing.AutoSize = true;
            this.lblXing.Font = new System.Drawing.Font("宋体", 11F);
            this.lblXing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblXing.Location = new System.Drawing.Point(208, 5);
            this.lblXing.Name = "lblXing";
            this.lblXing.Size = new System.Drawing.Size(15, 15);
            this.lblXing.TabIndex = 14;
            this.lblXing.Text = "0";
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.Red;
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartStop.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartStop.Location = new System.Drawing.Point(826, 35);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(91, 42);
            this.btnStartStop.TabIndex = 38;
            this.btnStartStop.Text = "关闭下注";
            this.btnStartStop.UseVisualStyleBackColor = false;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.lblValid);
            this.loginPanel.Controls.Add(this.txtUser);
            this.loginPanel.Controls.Add(this.lblCode);
            this.loginPanel.Controls.Add(this.txtPwd);
            this.loginPanel.Controls.Add(this.txtCode);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Location = new System.Drawing.Point(5, 3);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(565, 31);
            this.loginPanel.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "用户名：";
            // 
            // lblValid
            // 
            this.lblValid.Location = new System.Drawing.Point(444, 4);
            this.lblValid.Name = "lblValid";
            this.lblValid.Size = new System.Drawing.Size(100, 23);
            this.lblValid.TabIndex = 8;
            this.lblValid.DoubleClick += new System.EventHandler(this.lblValid_DoubleClick);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(60, 6);
            this.txtUser.MaxLength = 20;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(104, 21);
            this.txtUser.TabIndex = 2;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(338, 9);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(53, 12);
            this.lblCode.TabIndex = 7;
            this.lblCode.Text = "验证码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(219, 6);
            this.txtPwd.MaxLength = 20;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(391, 5);
            this.txtCode.MaxLength = 5;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(49, 21);
            this.txtCode.TabIndex = 6;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码：";
            // 
            // txtMoni
            // 
            this.txtMoni.Location = new System.Drawing.Point(578, 101);
            this.txtMoni.Name = "txtMoni";
            this.txtMoni.ReadOnly = true;
            this.txtMoni.Size = new System.Drawing.Size(504, 508);
            this.txtMoni.TabIndex = 39;
            this.txtMoni.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLeft);
            this.groupBox1.Location = new System.Drawing.Point(4, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 516);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "下注记录";
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(6, 20);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            this.txtLeft.Size = new System.Drawing.Size(556, 491);
            this.txtLeft.TabIndex = 40;
            this.txtLeft.Text = "";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(828, 83);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(65, 12);
            this.label51.TabIndex = 62;
            this.label51.Text = "距离开奖：";
            // 
            // leaveTime
            // 
            this.leaveTime.AutoSize = true;
            this.leaveTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.leaveTime.ForeColor = System.Drawing.Color.DarkRed;
            this.leaveTime.Location = new System.Drawing.Point(890, 82);
            this.leaveTime.Name = "leaveTime";
            this.leaveTime.Size = new System.Drawing.Size(47, 14);
            this.leaveTime.TabIndex = 63;
            this.leaveTime.Text = "00:00";
            // 
            // dueTimer
            // 
            this.dueTimer.Enabled = true;
            this.dueTimer.Interval = 300000;
            this.dueTimer.Tick += new System.EventHandler(this.dueTimer_Tick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripMain,
            this.toolStripMenuItem2,
            this.stripExit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(133, 54);
            // 
            // stripMain
            // 
            this.stripMain.Name = "stripMain";
            this.stripMain.Size = new System.Drawing.Size(132, 22);
            this.stripMain.Text = "主窗口(&M)";
            this.stripMain.Click += new System.EventHandler(this.stripMain_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(129, 6);
            // 
            // stripExit
            // 
            this.stripExit.Name = "stripExit";
            this.stripExit.Size = new System.Drawing.Size(132, 22);
            this.stripExit.Text = "退出(&X)";
            this.stripExit.Click += new System.EventHandler(this.stripExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "VVClient";
            this.notifyIcon.Visible = true;
            // 
            // selMult
            // 
            this.selMult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selMult.FormattingEnabled = true;
            this.selMult.Items.AddRange(new object[] {
            "3000",
            "6000",
            "9000",
            "12000",
            "15000",
            "18000",
            "21000",
            "24000",
            "27000",
            "30000"});
            this.selMult.Location = new System.Drawing.Point(996, 39);
            this.selMult.Name = "selMult";
            this.selMult.Size = new System.Drawing.Size(69, 20);
            this.selMult.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(928, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 65;
            this.label6.Text = "倍数维度：";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selMult);
            this.Controls.Add(this.leaveTime);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.txtMoni);
            this.Controls.Add(this.btnStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VVClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ok10Form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ok10Form_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer getTimer;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.Panel userPanel;
        public System.Windows.Forms.Button btnStartStop;
        public System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblValid;
        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.TextBox txtPwd;
        public System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RichTextBox txtMoni;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblXing;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblTerm;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblCountMoney;
        public System.Windows.Forms.TextBox txtMaxMoney;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.TextBox txtMinMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label leaveTime;
        private System.Windows.Forms.Timer countTimer;
        public System.Windows.Forms.RichTextBox txtLeft;
        private System.Windows.Forms.Timer dueTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem stripMain;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem stripExit;
        public System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox selMult;
        private System.Windows.Forms.Label label6;
    }
}