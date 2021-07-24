using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using MailUtility_ERP;
using System.Timers;
using System.Web;
using System.IO;
//using CL_Compzit;
using System.Configuration;



// CREATED BY:EVM-0002
// CREATED DATE:12/04/2016
// REVIEWED BY:
// REVIEW DATE:

namespace CompzitService
{
    public partial class CompzitMailClient_Test : ServiceBase
    {

        private Timer MailTimer = null;

        public CompzitMailClient_Test()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                var location = System.Reflection.Assembly.GetEntryAssembly().Location;
                var directoryPath = Path.GetDirectoryName(location);

                string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strCommonPath = "ServiceError\\MailTimer.txt";
                string strFilePath = strServerPath + strCommonPath;

                //if any exception on the time of mail fetching
                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, "BEGIN");
                }


                //setting timer.
                int intRefreshTime = 100000;
                string strRefreshTime = ConfigurationManager.AppSettings["MailRefreshingTime"];
                if (strRefreshTime != "")
                {
                    intRefreshTime = Convert.ToInt32(strRefreshTime);

                }
                MailTimer = new Timer(intRefreshTime);
                MailTimer.AutoReset = true;
                this.MailTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.MailTimer_Tick);
                // this.MailTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.MailSendingChking);
                this.MailTimer.Start();
            }
            catch (Exception MailException)
            {
                string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strCommonPath = "ServiceError\\MailTimer.txt";
                string strFilePath = strServerPath + strCommonPath;

                //if any exception on the time of mail fetching
                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, MailException.Message.ToString());
                }

            }

        }
        public void startTesting()
        { //setting timer.
            int intRefreshTime = 100000;
            string strRefreshTime = ConfigurationManager.AppSettings["MailRefreshingTime"];
            intRefreshTime = Convert.ToInt32(strRefreshTime);
            MailTimer = new Timer(intRefreshTime);
            MailTimer.AutoReset = true;

            this.MailTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.MailTimer_Tick);
            // this.MailTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.MailSendingChking);
            this.MailTimer.Start();

        }
        private void MailTimer_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                //MailTimer.Enabled = false;
                clsMail objMail = new clsMail();
                objMail.MailSendingChking();
                objMail.Read_Receive_Mail("SERVICE");                
                //try
                //{
                //    objMail.MailSendingChking();
                //}
                //catch
                //{
                //    string strServer = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                //    clsCommonLibrary objCommon = new clsCommonLibrary();
                //    string strCommon = "ServiceError\\MailTimer.txt";
                //    string strFile = strServer + strCommon;

                //    //if any exception on the time of mail fetching
                //    if (File.Exists(strFile))
                //    {
                //        File.AppendAllText(strFile, System.DateTime.Now.ToString() + Environment.NewLine);
                //        File.AppendAllText(strFile, "mail fail");
                //    } 
                //}
            }
            catch (Exception MailException)
            {
                string strServerPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string strCommonPath = "ServiceError\\MailTimer.txt";
                string strFilePath = strServerPath + strCommonPath;

                //if any exception on the time of mail fetching
                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, MailException.Message.ToString());
                }

            }
            //MailTimer.Enabled = true;

        }




        protected override void OnStop()
        {
            this.MailTimer.Stop();
            this.MailTimer = null;
        }

    }
}
