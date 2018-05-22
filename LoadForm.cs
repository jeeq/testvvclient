using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VVClient
{
    public partial class LoadForm : Form
    {
        private static string iniFile = Application.StartupPath + "\\config.ini";
        private string _ms = "";
        public LoadForm(string ms)
        {
            _ms = ms;
            InitializeComponent();
        }

        private void LoadForm_Load(object sender, EventArgs e)
        {
            txtMa.Text = _ms;
            txtMa.MaxLength = 15;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string reg = txtReg.Text;
            if (ma=="" || reg == "")
            {
                MessageBox.Show("请输入注册码!");
                return;
            }
            string _m = helper.EncodingBase64(ma);
            if (1 == 2 || _m.Substring(0, 20) == reg.Substring(0, 20))
            {
                string key = reg.Replace("/", "-");
                INI.SetIniValue("Reg", "Key", key, iniFile);

                MessageBox.Show("注册成功！重启软件后生效！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("无效注册码！");
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtMa.Text.Length > 0)
            {
                Clipboard.SetDataObject(txtMa.Text);
                MessageBox.Show("己复制");
            }
        }
    }
}
