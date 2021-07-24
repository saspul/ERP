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
using System.Configuration;


// CREATED BY:EVM-0002
// CREATED DATE:12/04/2016
// REVIEWED BY:
// REVIEW DATE:

namespace CompzitService
{
    public partial class CompzitMailClient : ServiceBase
    {

        private Timer MailTimer = null;
        bool blnStarted;
        bool blnRfgSrvcStarted;


        public CompzitMailClient()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceStart();
        }

        public void serviceStart()
        {

            try
            {

                // Current running directory will be allocated here.
                System.IO.Directory.SetCurrentDirectory(System.IO.Directory.GetCurrentDirectory().ToString());

                string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();
                string strCommonPath = "\\ServiceError\\MailTimer.txt";

                if (Directory.Exists(strServerPath + "\\ServiceError") == false)
                {
                    Directory.CreateDirectory(strServerPath + "\\ServiceError");
                }

                string strFilePath = strServerPath + strCommonPath;

                
                if (File.Exists(strFilePath) == false)
                {
                    File.CreateText(strFilePath).Close();
                }

                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, "BEGIN");
                }

                //setting timer.
                int intRefreshTime = 600000;
                string strRefreshTime = ConfigurationManager.AppSettings["MailRefreshingTime"];
                if (strRefreshTime != "")
                {
                    intRefreshTime = Convert.ToInt32(strRefreshTime);

                }
                MailTimer = new Timer(intRefreshTime);
                MailTimer.AutoReset = true;
                this.MailTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.MailTimer_Tick);

                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, "TIMER STARTS");
                }


                // Following line should be uncommented after debugging 
                this.MailTimer.Start();

                // Following line should be uncommented for debugging 
                TimerFunctionStarts();

            }
            catch (Exception MailException)
            {

                string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();

                //File.AppendAllText("E:\\Demo Company\\COMPZIT\\WebApp\\ServiceError\\MailTimer.txt", MailException.Message.ToString());

                string strCommonPath = "\\ServiceError\\MailTimer.txt";
                string strFilePath = strServerPath + strCommonPath;

                //if any exception on the time of mail fetching
                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, MailException.Message.ToString());
                    File.AppendAllText(strFilePath, System.IO.Directory.GetCurrentDirectory().ToString());
                }

            }

        }


        public void startTesting()
        { //setting timer.

            System.IO.Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory);
            int intRefreshTime = 600000;
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

            TimerFunctionStarts();

        }


        private void TimerFunctionStarts()
        {

            try
            {
                //MailTimer.Enabled = false;

                string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();

                string strCommonPath = "\\ServiceError\\MailTimer.txt";

                string strFilePath = strServerPath + strCommonPath;


                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, "MAIL READ START");
                }

                clsMail objMail = new clsMail();


                //if any exception on the time of mail fetching
                if (File.Exists(strFilePath) == false)
                {
                    File.CreateText(strFilePath).Close();
                }

                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, blnRfgSrvcStarted.ToString());
                }
                if (blnRfgSrvcStarted == false)
                {

                    blnRfgSrvcStarted = true;
                    blnRfgSrvcStarted = objMail.MailSendingChking();
                }


                if (blnStarted == false)
                {
                    blnStarted = true;
                    blnStarted = objMail.Read_Receive_Mail("SERVICE");
                }
                if (File.Exists(strFilePath))
                {
                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                    File.AppendAllText(strFilePath, "Start");
                }
            }
            catch (Exception MailException)
            {
                string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();
                string strCommonPath = "\\ServiceError\\MailTimer.txt";
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
