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
        //public Dictionary<string, TextBox> txtLst = new Dictionary<string, TextBox>();
        //Dictionary<string, TextBox> moneyLst = new Dictionary<string, TextBox>();
        //Dictionary<string, Label> zongLst = new Dictionary<string, Label>();
        //public Dictionary<int, List<string>> bMoneyLst = new Dictionary<int, List<string>>();
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
            //if (isHasUpdate)
            //{
            //    UpdateForm uForm = new UpdateForm();
            //    if (uForm.ShowDialog() == DialogResult.Yes)
            //    {
            //        Process.Start(Application.StartupPath + "\\AutoUpdate.exe");
            //        Application.Exit();
            //    }
            //    isHasUpdate = false;
            //}
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

        //private void getDics(int s, ref Dictionary<string, string> dics, JToken jobj)
        //{
        //    for (int i = s; i <= s + 9; i++)
        //    {
        //        dics.Add(i.ToString(), jobj["j" + i].ToString());
        //    }
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {

            //abcefg();
            //Dictionary<string, string> dics = new Dictionary<string, string>();
            //string content = "{\"Success\":\"1\",\"Msg\":\"\",\"ExtendObj\":{\"IsLogin\":\"1\"},\"OK\":\"\",\"PageCount\":\"0\",\"Obj\":{\"IsLogin\":\"1\",\"ChangLong\":[[\"第四名-双\",\"5\"],[\"亚军-龙\",\"4\"],[\"第七名-小\",\"4\"],[\"亚军-大\",\"3\"],[\"第三名-单\",\"3\"],[\"冠军-双\",\"2\"],[\"冠军-大\",\"2\"],[\"冠军-龙\",\"2\"],[\"第七名-单\",\"2\"],[\"第九名-大\",\"2\"],[\"第五名-小\",\"2\"],[\"第八名-小\",\"2\"],[\"第十名-小\",\"2\"],[\"第四名-大\",\"2\"],[\"第四名-龙\",\"2\"]],\"CurrentPeriod\":\"681969\",\"CloseCount\":\"24\",\"OpenCount\":\"54\",\"PrePeriodNumber\":\"681968\",\"PreResult\":\"8,10,9,6,4,2,3,1,7,5\",\"NotCountSum\":\"0.00\",\"Balance\":\"0.00\",\"ZongchuYilou\":{\"miss\":\"\",\"hit\":\"\"},\"Lines\":{\"j4179\":\"41\",\"j4180\":\"41\",\"j4181\":\"20\",\"j4182\":\"20\",\"j4183\":\"13\",\"j4184\":\"13\",\"j4185\":\"9.8\",\"j4186\":\"9.8\",\"j4187\":\"9\",\"j4188\":\"9.8\",\"j4189\":\"9.8\",\"j4190\":\"13\",\"j4191\":\"13\",\"j4192\":\"20\",\"j4193\":\"20\",\"j4194\":\"41\",\"j4195\":\"41\",\"j4196\":\"1.95\",\"j4197\":\"1.7\",\"j4198\":\"1.7\",\"j4199\":\"1.95\",\"j861\":\"9.8\",\"j862\":\"9.8\",\"j863\":\"9.8\",\"j864\":\"9.8\",\"j865\":\"9.8\",\"j866\":\"9.8\",\"j867\":\"9.8\",\"j868\":\"9.8\",\"j869\":\"9.8\",\"j870\":\"9.8\",\"j871\":\"1.96\",\"j872\":\"1.96\",\"j873\":\"1.96\",\"j874\":\"1.96\",\"j875\":\"1.96\",\"j876\":\"1.96\",\"j877\":\"9.8\",\"j878\":\"9.8\",\"j879\":\"9.8\",\"j880\":\"9.8\",\"j881\":\"9.8\",\"j882\":\"9.8\",\"j883\":\"9.8\",\"j884\":\"9.8\",\"j885\":\"9.8\",\"j886\":\"9.8\",\"j887\":\"1.96\",\"j888\":\"1.96\",\"j889\":\"1.96\",\"j890\":\"1.96\",\"j891\":\"1.96\",\"j892\":\"1.96\",\"j893\":\"9.8\",\"j894\":\"9.8\",\"j895\":\"9.8\",\"j896\":\"9.8\",\"j897\":\"9.8\",\"j898\":\"9.8\",\"j899\":\"9.8\",\"j900\":\"9.8\",\"j901\":\"9.8\",\"j902\":\"9.8\",\"j903\":\"1.96\",\"j904\":\"1.96\",\"j905\":\"1.96\",\"j906\":\"1.96\",\"j907\":\"1.96\",\"j908\":\"1.96\",\"j909\":\"9.8\",\"j910\":\"9.8\",\"j911\":\"9.8\",\"j912\":\"9.8\",\"j913\":\"9.8\",\"j914\":\"9.8\",\"j915\":\"9.8\",\"j916\":\"9.8\",\"j917\":\"9.8\",\"j918\":\"9.8\",\"j919\":\"1.96\",\"j920\":\"1.96\",\"j921\":\"1.96\",\"j922\":\"1.96\",\"j923\":\"1.96\",\"j924\":\"1.96\",\"j925\":\"9.8\",\"j926\":\"9.8\",\"j927\":\"9.8\",\"j928\":\"9.8\",\"j929\":\"9.8\",\"j930\":\"9.8\",\"j931\":\"9.8\",\"j932\":\"9.8\",\"j933\":\"9.8\",\"j934\":\"9.8\",\"j935\":\"1.96\",\"j936\":\"1.96\",\"j937\":\"1.96\",\"j938\":\"1.96\",\"j939\":\"1.96\",\"j940\":\"1.96\",\"j941\":\"9.8\",\"j942\":\"9.8\",\"j943\":\"9.8\",\"j944\":\"9.8\",\"j945\":\"9.8\",\"j946\":\"9.8\",\"j947\":\"9.8\",\"j948\":\"9.8\",\"j949\":\"9.8\",\"j950\":\"9.8\",\"j951\":\"1.96\",\"j952\":\"1.96\",\"j953\":\"1.96\",\"j954\":\"1.96\",\"j955\":\"9.8\",\"j956\":\"9.8\",\"j957\":\"9.8\",\"j958\":\"9.8\",\"j959\":\"9.8\",\"j960\":\"9.8\",\"j961\":\"9.8\",\"j962\":\"9.8\",\"j963\":\"9.8\",\"j964\":\"9.8\",\"j965\":\"1.96\",\"j966\":\"1.96\",\"j967\":\"1.96\",\"j968\":\"1.96\",\"j969\":\"9.8\",\"j970\":\"9.8\",\"j971\":\"9.8\",\"j972\":\"9.8\",\"j973\":\"9.8\",\"j974\":\"9.8\",\"j975\":\"9.8\",\"j976\":\"9.8\",\"j977\":\"9.8\",\"j978\":\"9.8\",\"j979\":\"1.96\",\"j980\":\"1.96\",\"j981\":\"1.96\",\"j982\":\"1.96\",\"j983\":\"9.8\",\"j984\":\"9.8\",\"j985\":\"9.8\",\"j986\":\"9.8\",\"j987\":\"9.8\",\"j988\":\"9.8\",\"j989\":\"9.8\",\"j990\":\"9.8\",\"j991\":\"9.8\",\"j992\":\"9.8\",\"j993\":\"1.96\",\"j994\":\"1.96\",\"j995\":\"1.96\",\"j996\":\"1.96\",\"j997\":\"9.8\",\"j998\":\"9.8\",\"j999\":\"9.8\",\"j1000\":\"9.8\",\"j1001\":\"9.8\",\"j1002\":\"9.8\",\"j1003\":\"9.8\",\"j1004\":\"9.8\",\"j1005\":\"9.8\",\"j1006\":\"9.8\",\"j1007\":\"1.96\",\"j1008\":\"1.96\",\"j1009\":\"1.96\",\"j1010\":\"1.96\",\"j1011\":\"1.96\",\"j1012\":\"1.96\",\"j1013\":\"1.96\",\"j1014\":\"1.96\",\"j1015\":\"1.96\",\"j1016\":\"1.96\",\"j1017\":\"1.96\",\"j1018\":\"1.96\",\"j1019\":\"1.96\",\"j1020\":\"1.96\"},\"LuZhu\":[{\"c\":\"18:1,19:1,11:2,4:1,15:1,11:3,10:1,19:1,12:1,13:1,15:1,11:1,5:1,16:1,5:1,15:1,12:1,11:1,12:1,11:2,17:1,13:1,17:1,7:1,15:1,12:1\",\"n\":\"冠亚和\",\"p\":1},{\"c\":\"大:2,小:3,大:1,小:4,大:4,小:2,大:1,小:1,大:2,小:1,大:1,小:2,大:3,小:1,大:2\",\"n\":\"冠亚和大小\",\"p\":1},{\"c\":\"双:1,单:3,双:1,单:4,双:1,单:1,双:1,单:4,双:1,单:2,双:1,单:1,双:1,单:7,双:1\",\"n\":\"冠亚和单双\",\"p\":1}]}}";
            //JObject jobj = (JObject)JsonConvert.DeserializeObject(content);
            //if (jobj != null)
            //{
            //    if (jobj["Success"].ToString() != "1")
            //    {
            //        //AppendLog("无法倍数信息");
            //    }
            //    else
            //    {
            //        JToken jt = jobj["Obj"]["Lines"];
            //        if (jt.ToString() != "[]")
            //        {
            //            getDics(861, ref dics, jt);
            //            getDics(877, ref dics, jt);
            //            getDics(893, ref dics, jt);
            //            getDics(909, ref dics, jt);
            //            getDics(925, ref dics, jt);
            //            getDics(941, ref dics, jt);
            //            getDics(955, ref dics, jt);
            //            getDics(969, ref dics, jt);
            //            getDics(983, ref dics, jt);
            //            getDics(997, ref dics, jt);
            //        }
            //    }
            //}


            helper.clearLog();

            DelAllFormTable();

            this.Text = this.Text + "-" + sel_site;

            //switch (sel_site)
            //{
            //    case "本地1":
            //        {
            //            site = new JfSite();
            //            break;
            //        }
            //    default:
            //        {
            //            site = new AsSite();
            //            break;
            //        }
            //}
            site = new VvSite();
            site._form = this;
            //site.ManualGetResults();
            //return;

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
                //txtMulMoney.Text = bmoney;
            }
            else
            {
                //txtMulMoney.Text = "2,2,6,14,30,62,126";
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

            
            //dTime.AddMinutes(sm).AddSeconds(sem);
            //DateTime nTime = new DateTime(dTime.Year, dTime.Month, dTime.Day, dTime.Hour,)
            //leaveTime.Text=


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
                    //if (!isCurBet) site.ManualBetMoney(false);
                    if (!isMuCurBet) site.ManualBetMoney(true);
                }
                else
                {
                    if (!isCurBet) site.ManualBetMoney(false);
                }
                //site
                //isCompute = false;
                //if (!isCompute) site.ManualGetResults();//获取最新开奖记录
                //site.ManualGetUserInfo();
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

            /*
            else if (tmp == 1 || tmp == 6)
            {

            }*/
            //else
            //{
            //    getHistory = false;
            //    site.ManualGetUserInfo();
            //    //site.KaiJiang(Convert.ToInt32(lastId));

            //}
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
