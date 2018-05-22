using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VVClient
{
    static class Program
    {
        private static string iniFile = Application.StartupPath + "\\config.ini";
        private static readonly string settingIniFile = Application.StartupPath + "\\setting.ini";
        private static readonly string updatePath = Application.StartupPath + "\\Update";
        private static string logPath = Application.StartupPath + "\\log";
        private static string writePath = Application.StartupPath + "\\write";
        private const string APP_NAME = "VVClient";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
            if (!Directory.Exists(writePath)) Directory.CreateDirectory(writePath);
            try
            {
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                //Application.Run(new CcbForm2(null));
                Mutex mutex = new Mutex(false, APP_NAME);
                bool Running = !mutex.WaitOne(0, false);
                if (!Running)
                {
                    if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
                    string mn = helper.GetMNum();
                    if (mn == "")
                    {
                        MessageBox.Show("该系统环境无法运行此软件！");
                        Environment.Exit(0);
                        return;
                    }
                    string _ms = helper.EncodingBase64("A" + helper.GetMNum() + "F");
                    string kk = helper.EncodingBase64(_ms);
                    string key = INI.GetIniValue("Reg", "Key", iniFile);
                    //判断软件是否注册
                    if (key.Length>15 && key.Replace("-", "/").Substring(0, 15).IndexOf(kk.Substring(0, 15)) != -1)
                    {
                        Application.Run(new MainForm(key));
                        return;
                    }
                    Application.Run(new LoadForm(_ms));
                    //LoginForm lf = new LoginForm(rs);
                    //if (lf.ShowDialog() == DialogResult.Yes)
                    //{
                    //    Application.Run(new MainForm(rs, lf.tk, lf.acc, lf.site));
                    //}
                    //Application.Run(new MainForm("", "", "",""));
                    //Application.Run(new MoniForm());
                    //Application.Run(new WapPinganForm(null));
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";

                if (ex != null)
                {
                    str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                         ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("应用程序线程错误:{0}", ex);
                }

                helper.writeLog(str);
            }
            finally
            {
            }
            //Mutex mutex = new Mutex(false, APP_NAME);
            //bool Running = !mutex.WaitOne(0, false);
            //if (!Running)
            //{

            //}
            //else
            //{
            //    Environment.Exit(0);
            //}

            //string _ms = helper.EncryptSymmetric("A" + helper.GetMNum() + "F");
            //string _finish = INI.GetIniValue("Reg", "Finish", settingIniFile);
            //if (_finish == "" || DateTime.Now.Ticks < Convert.ToInt64(_finish))
            //{
            //    Application.Run(new LoadForm(_ms));
            //    return;
            //}

            //string kk = helper.EncryptSymmetric(_ms);
            ////判断软件是否注册
            //RegistryKey retkey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("PKSoft");
            //string[] sArr = retkey.GetSubKeyNames();
            //for (int i = 0; i < sArr.Length; i++)
            //{
            //    if (sArr[i].Replace("-", "/").Substring(0, 15).IndexOf(kk.Substring(0, 15)) != -1)
            //    {
            //        string _t = Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("PKSoft").OpenSubKey(sArr[i]).GetValue("User").ToString();
            //        Application.Run(new MainForm(_t));
            //        return;
            //    }
            //}
            //Application.Run(new LoadForm(_ms));

            //Application.Run(new MainForm(""));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = "";
            Exception error = e.ExceptionObject as Exception;
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            if (error != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", e);
            }
            helper.writeLog(str);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }

            helper.writeLog(str);
        }

    }
}
