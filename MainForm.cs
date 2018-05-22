using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Windows.Forms;

namespace VVClient
{
    public partial class MainForm : Form
    {
        public string settingIniFile = Application.StartupPath + "\\setting.ini";
        public string iniFile = Application.StartupPath + "\\config.ini";
        private static string logPath = Application.StartupPath + "\\log";
        public BaseSite site = null;
        public bool isTouZhu = true;
        public bool isLogin = false;
        public string siteName = "未知";
        public string lastVN = "";
        public string lastId = "";
        public string lastResult = "";
        public string cur_lastId = "";
        public string tou_lastId = "";
        public string acc = "";
        public string sel_site = "";
        public string mk = "";
        public string[] pubArr;
        public string sId = "";
        public List<string> bMoneyLst = new List<string>();

        public Dictionary<string, string> bitem_dics = new Dictionary<string, string>();
        string mg = "该功能" + "未对你开放!";
        string gqm = "己过期";
        public int op_c = 0;
        public string ut = "";
        public bool isHasUpdate = false;

        string pubKey = "";
        Thread thread = null;
        public Dictionary<string, string> beiDics = new Dictionary<string, string>();
        public Dictionary<string, TextBox> bsLst = new Dictionary<string, TextBox>();
        public bool isLoadFirst = true;
        public Dictionary<int, string> ruleDics = new Dictionary<int, string>();
        public Dictionary<int, string> continueDics = new Dictionary<int, string>();
        public Dictionary<string, ErrorStruct> errorDics = new Dictionary<string, ErrorStruct>();
        public List<List<string>> moneyLst = new List<List<string>>();
        CheckAutoUpdate cau = null;
        string pub_reg = "";

        public MainForm(string _reg)
        {
            if (_reg == "") Environment.Exit(0);
            pub_reg = helper.DecodingBase64(_reg);

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        bool isDue = false;
        void dueTimer_Tick(object sender, EventArgs e)
        {
            if (isDue) return;
            isDue = true;
            abcefg();
            isDue = false;
        }

        private void abcefg()
        {
            
            new Thread(new ThreadStart(delegate ()
            {
                string sTime = helper.GetNetTime();
                if (sTime == "")
                {
                    MessageBox.Show("网络有问题，无法连接!");
                    Application.Exit();
                    return;
                }
                DateTime nTime = Convert.ToDateTime(sTime);
                string[] sArr = pub_reg.Split('.');
                DateTime exTime = new DateTime(Convert.ToInt64(sArr[1]));
                if (sArr.Length < 2 || (Convert.ToInt32(sArr[2]) != -1 && nTime.Subtract(exTime).TotalDays > Convert.ToInt32(sArr[2])))
                {
                    INI.SetIniValue("Reg", "Key", "", iniFile);
                    Application.Exit();
                    MessageBox.Show(gqm);
                    return;
                }
            })).Start();
            
        }

        private void DelAllFormTable()
        {
            try
            {
                StringBuilder tmpSql = new StringBuilder();
                tmpSql.Append("delete from s_touzu_as where id<(select max(id)-100 from s_touzu_as order by id asc);");
                SQLiteHelper.TestExecuteSql(tmpSql.ToString());
                tmpSql = new StringBuilder();
                tmpSql.Append("vacuum;");
                SQLiteHelper.TestExecuteSql(tmpSql.ToString());
            }
            catch (Exception ex)
            {
                helper.writeLog(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            helper.clearLog();

            DelAllFormTable();

            this.Text = this.Text + "-" + sel_site;

          
            site = new VvSite();
            site._form = this;
         

            txtMinMoney.Text = INI.GetIniValue("MM", "min", settingIniFile);
            txtMaxMoney.Text = INI.GetIniValue("MM", "max", settingIniFile);

            txtUser.Text = INI.GetIniValue(site.tag, "account", settingIniFile);
            string pwd = INI.GetIniValue(site.tag, "pwd", settingIniFile);
            if (pwd != "") txtPwd.Text = helper.DecodingBase64(pwd);
            else txtPwd.Text = "";

            string bmoney = INI.GetIniValue(site.tag, "bm", settingIniFile);
            if (bmoney != "")
            {
                bMoneyLst.AddRange(bmoney.Split(','));
         
            }
            else
            {
               
            }

            isTouZhu = false;
            btnStartStop.Text = "开启下注";
            btnStartStop.BackColor = Color.Green;

            site.getValidCode(lblValid);

            countTimer.Tick += CountTimer_Tick;
            countTimer.Enabled = true;
            countTimer.Interval = 1000;
            countTimer.Start();

            selMult.SelectedIndex = 0;
            ut = selMult.SelectedItem.ToString();
            selMult.SelectedIndexChanged += SelMult_SelectedIndexChanged;

            btnStartStop_Click(null, null);

            RegisterTimerStart();
        }

        private void SelMult_SelectedIndexChanged(object sender, EventArgs e)
        {
            ut = selMult.SelectedItem.ToString();
        }

        string countTimeStr = "";
        private void CountTimer_Tick(object sender, EventArgs e)
        {
            DateTime dTime = DateTime.Now;
            string ltime = dTime.ToString("yyyy-MM-dd HH:mm");
            if (Convert.ToInt32(dTime.ToString("HHmm")) >= 2357) leaveTime.Text = "00:00";
            if (Convert.ToInt32(dTime.ToString("HHmm")) < 920) leaveTime.Text = "00:00";
            if (countTimeStr == "")
            {
                int mm = dTime.Minute;
                int sec = dTime.Second;
                int m = 0;
                if (mm < 10) m = mm;
                else m = Convert.ToInt32(mm.ToString().Substring(1, 1));
                int sm = 0;
                int sem = 0;
                if (m >= 7 || m < 2)
                {
                    if (m <= 2) sm = 2 - m;
                    else sm = 12 - m;
                }
                else
                {
                    sm = 7 - m;
                }
                if (sec > 0) sm = sm - 1;
                sem = 60 - sec;
                countTimeStr = sm.ToString().PadLeft(2,'0') + ":" + sem;
                leaveTime.Text = countTimeStr;
            }
            else
            {
                string[] sArr = countTimeStr.Split(':');
                int m = Convert.ToInt32(sArr[0]);
                int s = Convert.ToInt32(sArr[1]) - 1;
                if (s == 0 || s==-1)
                {

                    if (m == 0) leaveTime.Text = "05:00";
                    else leaveTime.Text = (m - 1).ToString().PadLeft(2, '0') + ":59";
                }
                else
                {
                    leaveTime.Text = m.ToString().PadLeft(2, '0') + ":" + s.ToString().PadLeft(2, '0');
                }
                countTimeStr = leaveTime.Text;
            }

        }

        public void RegisterTimerStart()
        {
            getTimer.Tick += getTimer_Tick;
            getTimer.Enabled = true;
            getTimer.Interval = 1000 * 15;
            getTimer.Start();
        }

        private int lm = 0;
        //bool getHistory = false;
        //bool isCompute = false;
        public bool isKaiJiang = false;
        public bool isCompute = false;
        public bool isCurBet = false;
        public bool isMuCurBet = false;
        void getTimer_Tick(object sender, EventArgs e)
        {
            DateTime dTime = DateTime.Now;
            //if (dTime.Hour % 5 == 0)
            //{
            //    cau.checkUpdate(false);
            //}
            //if (site.indexHtmlUrl == "") return;
            if (dTime.Hour >= 0 && dTime.Hour <= 8)
            {
                site.ManualLoopList();
                return;
            }
            int m = dTime.Minute;
            int tmp = m % 10;
            if (tmp == 9 || tmp == 5 || tmp == 0 || tmp == 4)
            {
                if ((tmp == 0 || tmp == 5) && dTime.Second >= 30)
                {
                    if (!isMuCurBet) site.ManualBetMoney(true);
                }
                else
                {
                    if (!isCurBet) site.ManualBetMoney(false);
                }
            }
            else if (tmp == 8 || tmp == 3)// || tmp == 3
            {
                if (lastId != "")
                {
                    site.KaiJiang(Convert.ToInt32(lastId));
                }
                isCompute = false;
                isCurBet = false;
                isMuCurBet = false;
            }
            //isCurBet = false;
            site.ManualLoopList();

        }

        private void Ok10Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            site.ExitSite();
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void Ok10Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // 取消关闭  
                e.Cancel = true;
                this.Hide();
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "获取验证码")
            {
                site.getValidCode(lblValid);
            }
            else if (btnLogin.Text == "登　录")
            {
                site.Login();
            }
            else if (btnLogin.Text == "退　出")
            {
                userPanel.Visible = false;
                lblValid.Image = null;
                txtCode.Text = "";
                site.ExitSite();
                site.getValidCode(lblValid);
                loginPanel.Enabled = true;

            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认重新开始下注?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                site.isContinuePrev = false;
                site.curMoney = 0;
            }
        }

        
        public void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "开启下注")
            {
                isTouZhu = true;
                btnStartStop.Text = "关闭下注";
                btnStartStop.BackColor = Color.Red;
                //lblStartTop.Text = "[当前真实下注]";
                site.AppendLog("开启下注",Color.Green);
            }
            else
            {
                isTouZhu = false;
                btnStartStop.Text = "开启下注";
                btnStartStop.BackColor = Color.Green;
                //lblStartTop.Text = "[当前是模拟下注]";
                site.AppendLog("关闭下注",Color.Red);
            }
        }

        private void lblValid_DoubleClick(object sender, EventArgs e)
        {
            lblValid.Image = null;
            site.getValidCode(lblValid);
        }

        private void linkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(site.loginUrl);
        }

        

        public static bool SetAllowUnsafeHeaderParsing()
        {
            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for 
                // the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance 
                    // of the internal settings class. If the static instance 
                    // isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });
                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the 
                        // framework is unsafe header parsing should be 
                        // allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing",BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void stripMain_Click(object sender, EventArgs e)
        {
            if (!this.Visible) this.Show();
        }

        private void stripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCheckUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckAutoUpdate tmp_cau = new CheckAutoUpdate(this);
            tmp_cau.checkUpdate(true);
        }
    }

    public class ComboxItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    
}
