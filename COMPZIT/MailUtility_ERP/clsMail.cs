using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using DataLayerMailUtility;
using System.Web;
using System.Web.UI.WebControls;
using CL_Compzit;
using EL_Compzit;
using HashingUtility;
using OpenPop;
using OpenPop.Mime;
using BL_Compzit;
using System.Windows;
using OpenPop.Mime.Header;
//using System.Web.Mail;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_GMS;
using EL_Compzit.EntityLayer_GMS;


// CREATED BY:EVM-0001
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the class in MailUtility Layer .

namespace MailUtility_ERP
{
    public class clsMail
    {

        public enum MailProtocol
        {
            Pop3 = 1,
            Imap = 2
        }

        static int intStoreId = 0;
        clsCmnLbryOrgVefnMailBody objCmnlbryMailBody = new clsCmnLbryOrgVefnMailBody();
        clsDataMailUtility objDataLayerMailUtility = new clsDataMailUtility();
        List<string> LstToAddress = new List<string>();

        //Method for Instant Mail sending it accepts TemplateId and Details of sender as reference
        public void InstantMail(string strTempalteId, ref DataTable dtTemplateDetail)
        {
            dtTemplateDetail = objDataLayerMailUtility.SelectTemplateDetail(strTempalteId);
        }

        //Method for Bulk Mail sending
        public void BulkMail(string strTemplateId = null, string strTransId = null, DataTable dtCompanyDetailInstant = null, clsEntityOrgParking objEntityOrgParking = null, clsEntityLayerOrgVerification objEntityOrgVef = null)
        {
            DataTable dtCompanyDetail;
            if (dtCompanyDetailInstant == null)
            {
                dtCompanyDetail = objDataLayerMailUtility.ReadCompanyDetails();
            }
            else
            {
                dtCompanyDetail = dtCompanyDetailInstant;
            }
            DataTable dtBulkDetail = new DataTable();
            //for single mail 
            if ((strTemplateId != null) && (strTransId != null))
            {
                dtBulkDetail = objDataLayerMailUtility.SelectBulkDetail(strTemplateId, strTransId);
            }
            //for bulk mail
            else
            {
                dtBulkDetail = objDataLayerMailUtility.SelectBulkDetail();
            }
            int intcnt = 0;
            //fetching all record in email store table with unsucessfull delivery and sending again
            while (dtBulkDetail.Rows.Count > intcnt)
            {
                MailBulkSend(dtCompanyDetail, dtBulkDetail, intcnt, objEntityOrgParking, objEntityOrgVef);
                intcnt = intcnt + 1;
            }
            //Calls method for deletion of records from store table that has sucessfully send
            objDataLayerMailUtility.RemoveUpdated();
        }


        //check smtp ( for sending mails ) mail server .
        public void CheckSmtpServer(string strUserName, int intPort)
        {
            //CheckSmtpServer(strUserName, Convert.ToInt32(intPort));
            using (var client = new TcpClient())
            {
                var server = strUserName;
                var port = intPort;
                client.Connect(server, port);
            }
        }

        //general method for sending mail
        public void SendMail(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList)
        {

            clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(objEntityMail.Out_Service_Name);
            mail.From = new MailAddress(objEntityMail.From_Email_Address);
            //EVM0012
            if (objEntityMail.To_Email_Address != "" && objEntityMail.To_Email_Address != null)
            {
                mail.To.Add(objEntityMail.To_Email_Address);
            }
            foreach (classEntityToMailAddress objEntityToMailAddress in objEntityToMailAddressList)
            {
                if (objEntityToMailAddress.ToAddress != "" && objEntityToMailAddress.ToAddress != null)
                {
                    mail.To.Add(new MailAddress(objEntityToMailAddress.ToAddress));
                }
            }

            foreach (clsEntityMailCcBCc objEntityMailCcBCc in objEntityMailCcBCcList)
            {
                if (objEntityMailCcBCc.CcMail != "" && objEntityMailCcBCc.CcMail != null)
                {
                    mail.CC.Add(new MailAddress(objEntityMailCcBCc.CcMail)); //Adding Multiple CC email Id
                }
                if (objEntityMailCcBCc.BCcMail != "" && objEntityMailCcBCc.BCcMail != null)
                {

                    mail.Bcc.Add(new MailAddress(objEntityMailCcBCc.BCcMail)); //Adding Multiple BCC email Id
                }
            }



            //string strBody = objEntityMail.Email_Content + objEntityMail.Signature;
            //string strBody = objEntityMail.Email_Content;
            mail.Subject = objEntityMail.Email_Subject;
            mail.Body = objEntityMail.Email_Content;
            // mail.IsBodyHtml = true;


            //ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            //// Add the alternate body to the message.

            //AlternateView alternate = AlternateView.CreateAlternateViewFromString(strBody, mimeType);
            //mail.AlternateViews.Add(alternate);


            //for attachment
            foreach (clsEntityMailAttachment objEntityAtt in objEntityMailAttachList)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(objEntityAtt.Attch_Path);
                mail.Attachments.Add(attachment);
            }
            SmtpServer.Port = Convert.ToInt32(objEntityMail.Out_Port_Number);
            string strPassword = objEncryptDecrypt.Decrypt(objEntityMail.Password);
            if (objEntityMail.SSL_Status == 1)
                SmtpServer.EnableSsl = true;
            else
                SmtpServer.EnableSsl = false;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(objEntityMail.From_Email_Address, strPassword);
            SmtpServer.Send(mail);
            SmtpServer.Dispose();
            mail.Dispose();
        }
        // Method for sending mails in Bulk sending module
        protected void MailBulkSend(DataTable dtCompanyDetail, DataTable dtBulkDetail, int intcnt, clsEntityOrgParking objEntityOrgParking = null, clsEntityLayerOrgVerification objEntityOrgVef = null)
        {
            try
            {
                string strHost = dtCompanyDetail.Rows[0]["CMPNY_SMTP_HOST"].ToString();
                string strfromaddr = "noreply.volviar@gmail.com";
                    //dtCompanyDetail.Rows[0]["CMPNY_EMAIL_SENDMAIL"].ToString();
                string strEncryptedPwd = dtCompanyDetail.Rows[0]["CMPNY_PWD_SENDMAIL"].ToString();

                clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
                string strPassword = "n06ply@v0lviar";
                    //objEncryptDecrypt.Decrypt(strEncryptedPwd);
                string strReplyToMail = dtCompanyDetail.Rows[0]["CMPNY_RPLYTO_SENDMAIL"].ToString();
                string strPort = dtCompanyDetail.Rows[0]["CMPNY_SMTP_PORT"].ToString();
                string strMailAttchPath = dtCompanyDetail.Rows[0]["CMPNY_ML_ATTCH_PATH"].ToString();
                string strSubject = dtBulkDetail.Rows[intcnt]["EMSTR_SUBJECT"].ToString();
                string strBody = dtBulkDetail.Rows[intcnt]["EMSTR_MESSAGE"].ToString();
                string strDisclaimer = dtBulkDetail.Rows[intcnt]["EMSTR_DISCLAIMER"].ToString();
                string strToAddr = dtBulkDetail.Rows[intcnt]["EMSTR_TO_MAIL"].ToString();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(strHost);

                mail.From = new MailAddress(strfromaddr);
                mail.To.Add(strToAddr);
                mail.Subject = strSubject;
                // adding if there is ReplyTo mail
                if (strReplyToMail != "")
                {
                    mail.ReplyToList.Add(strReplyToMail);
                }
                mail.Body = objCmnlbryMailBody.MailBody(strBody, strDisclaimer, dtCompanyDetail, objEntityOrgParking, objEntityOrgVef);
                intStoreId = Convert.ToInt32(dtBulkDetail.Rows[intcnt]["EMSTR_ID"].ToString());
                DataTable dtStoreAttachement = new DataTable();
                dtStoreAttachement = objDataLayerMailUtility.ReadStoreAttachementDetails(intStoreId);
                int intCount = 0;
                //Adding all attachement related to current mail
                while (dtStoreAttachement.Rows.Count > intCount)
                {
                    string strAttachementFile = dtStoreAttachement.Rows[intCount]["EMSTATMT_FILE"].ToString();
                    string strPath = strMailAttchPath + strAttachementFile;
                    if (strAttachementFile != "")
                    {
                        System.Net.Mail.Attachment attachment;
                        attachment = new System.Net.Mail.Attachment(System.Web.HttpContext.Current.Server.MapPath(strPath));
                        mail.Attachments.Add(attachment);
                        intCount = intCount + 1;
                        strAttachementFile = "";
                        strPath = "";
                    }
                }
                SmtpServer.Port = Convert.ToInt32(strPort);
                SmtpServer.Credentials = new System.Net.NetworkCredential(strfromaddr, strPassword);
                SmtpServer.Send(mail);
                objDataLayerMailUtility.UpdateStoreDetail(intStoreId);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                objDataLayerMailUtility.UpdateStoreLastTryDate(intStoreId);
                Console.WriteLine(ex.ToString());
            }
        }
        //reading the mails from the server against an email id
        public void ReadMail(string strServerName, int intPort, bool sslStatus, string strUserName, string strPassword, int intCorpId, int intOrgId, string strToAddress, int intDivisionId, int intUserId, string strEmailLimitDate, string strWebsiteorService, List<string> LstEmail, string strRemove, List<string> LstUserId, List<string> LstDivision)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //    string strPath1 = System.AppDomain.CurrentDomain.BaseDirectory.ToString();

            //  String path =  Server.MapPath("~/myappfolder");
            //  string cnmpath = Convert.ToString(objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Mail_Attachments));
            //   string path2 = HttpContext.Current.Server.MapPath(cnmpath);

            //0001 start


            DateTime dtPreviousDate = DateTime.Now.AddDays(-1);


            DateTime dtEmlLimitDate = new DateTime();
            if (strEmailLimitDate != "")
            {

                dtEmlLimitDate = objCommon.textWithTimeToDateTime(strEmailLimitDate);
            }
            else
            {
                goto outerDateLabel;
            }


            //0001 stop
            clsEncryptionDecryption objEncrypt = new clsEncryptionDecryption();

            clsBusinessLayerMail objBusinessMail = new clsBusinessLayerMail();

            OpenPop.Pop3.Pop3Client objPop3 = new OpenPop.Pop3.Pop3Client();

            ErrfileWrite("Connection Begins.");

            objPop3.Connect(strServerName, intPort, Convert.ToBoolean(sslStatus));

            ErrfileWrite("Connected.");

            ErrfileWrite("Authentication Begins.");

            objPop3.Authenticate(strUserName, strPassword, OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword);

            ErrfileWrite("Authenticated.");

            List<string> strUidList = new List<string>();
            strUidList = objPop3.GetMessageUids();

            ErrfileWrite("Message UID Fetched - " + strUidList.Count);

            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();

            for (int intListCount = strUidList.Count; intListCount > 0; intListCount--)
            {
                try
                {


                    //0001 start
                    MessageHeader headers = objPop3.GetMessageHeaders(intListCount);

                   

                    ErrfileWrite(headers.DateSent.ToString());

                    RfcMailAddress from = headers.From;
                    string subject = headers.Subject;
                    string[] arrstrDateSplit = headers.Date.Split('(');
                    DateTime dtServerEmail_Receive_Date = Convert.ToDateTime(arrstrDateSplit[0]);

                  


                    if (dtEmlLimitDate >= dtServerEmail_Receive_Date)
                    {
                        break;
                        //goto outerDateLabel;

                    }
                    else
                    {

                        for (int intHeadCount = 0; intHeadCount < headers.To.Count; intHeadCount++)
                        {
                            string strCount = "0";
                            string strDate = "";
                            int intindex = 0;
                            //check the 'to mail address' is valid or not on the basis of division and emoployee.
                            ErrfileWrite("Header Address Checking Starts");
                            if (LstEmail.Contains(headers.To[intHeadCount].Address.ToString()) == false)
                            {
                                //ErrfileWrite("Header Address: " + headers.To[0].Address.ToString());
                                goto innerOut;
                            }
                            else
                            {
                                ErrfileWrite("Header Address Checking Ends");
                                intindex = LstEmail.FindIndex(x => x.StartsWith(headers.To[intHeadCount].Address.ToString()));
                                intUserId = Convert.ToInt32(LstUserId[intindex]);
                                intDivisionId = Convert.ToInt32(LstDivision[intindex]);
                            }

                            objEntityMail.To_Email_Address = headers.To[intHeadCount].Address.ToString();
                            objEntityMail.Email_Unique_Id = strUidList[intListCount - 1];
                            objEntityMail.D_Date = dtServerEmail_Receive_Date;
                            DataTable dtMailId = objBusinessMail.SelectUniqueIdCount(objEntityMail);

                            if (dtMailId.Rows.Count > 0)
                            {
                                strCount = dtMailId.Rows[0]["CNT"].ToString();
                                strDate = dtMailId.Rows[0]["MAIL_RECEIVED_DATE"].ToString();
                            }

                            //checking the mailbox have the same mail or not
                            if (strCount == "0")
                            {

                            }
                            else
                            {
                                //break;
                                goto innerOut;
                            }

                            Message message = objPop3.GetMessage(intListCount);

                            objEntityMail.MessageID = message.Headers.MessageId.ToString();
                            objEntityMail.From_Email_Address = message.Headers.From.ToString();

                            objEntityMail.To_Email_Address = message.Headers.To[intHeadCount].Address.ToString();

                            //ToAddressList contains all to address against this whole mail attaching process
                            if (LstToAddress.Contains(objEntityMail.To_Email_Address) == false)
                                LstToAddress.Add(objEntityMail.To_Email_Address);

                            if (message.Headers.Subject != null)
                            {
                                objEntityMail.Email_Subject = message.Headers.Subject;
                                if (objEntityMail.Email_Subject.Contains("["))
                                {
                                    try
                                    {
                                        string[] SubArray = new string[10];
                                        SubArray = objEntityMail.Email_Subject.Split('[', ']');
                                        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
                                        objEntityLead.Ref_Id = Convert.ToInt32(SubArray[1]);
                                        DataTable dtLead = objBusinessMail.ReadLeadByRef(objEntityLead);
                                        if (dtLead.Rows.Count > 0)
                                        {
                                            objEntityMail.User_Id = Convert.ToInt32(dtLead.Rows[0]["LEADS_ACTIVE_USR_ID"]);
                                            objEntityMail.D_Date = System.DateTime.Now;
                                            objEntityMail.Auto_Attach = 1;
                                        }

                                    }
                                    catch
                                    {

                                    }
                                }
                            }

                            var mailbody = ASCIIEncoding.ASCII.GetString(message.RawMessage);

                            string strBody = message.ToMailMessage().Body;

                            objEntityMail.Email_Content = strBody;

                            objEntityMail.Email_Receive_Date = dtServerEmail_Receive_Date;

                            objEntityMail.Email_Store = Convert.ToInt32(clsCommonLibrary.Mail_Storage.Inbox);

                            objEntityMail.Corporate_Id = intCorpId;

                            objEntityMail.Organisation_Id = intOrgId;

                            objEntityMail.Transaction_Id = intDivisionId;

                            objEntityMail.User_Id = intUserId;

                            clsBusinessLayer objBusiness = new clsBusinessLayer();
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MAIL_BOX);
                            objEntCommon.CorporateID = objEntityMail.Corporate_Id;
                            string strNextValue = objBusiness.ReadNextNumberWebForUI(objEntCommon);

                            objEntityMail.Mail_Box_Id = Convert.ToInt64(strNextValue);

                            List<clsEntityMailAttachment> objEntAttachList = new List<clsEntityMailAttachment>();
                            int intSaveCounter = 0;
                            string[] strFileNameArray = new string[500];
                            foreach (var myMsg in message.FindAllAttachments())
                            {
                                clsEntityMailAttachment objEntAttach = new clsEntityMailAttachment();
                                // strFileName = objPop3.GetMessageUid(intListCount);
                                strFileNameArray[intSaveCounter] = objEntityMail.Mail_Box_Id.ToString() + intSaveCounter.ToString() + Path.GetExtension(myMsg.FileName);
                                objEntAttach.Email_File_Name = strFileNameArray[intSaveCounter];
                                objEntAttach.Email_Real_Name = myMsg.FileName;
                                objEntAttachList.Add(objEntAttach);
                                intSaveCounter++;
                            }

                            //saving to database mail box                
                            ErrfileWrite("Writting the mail box");
                            objBusinessMail.AddMail(objEntityMail, objEntAttachList);

                            int intAttchCounter = 1;
                            //for attachment saving 

                            //find the path
                            string strPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                            clsCommonLibrary objCommonLib = new clsCommonLibrary();
                            string strCommonPath = Convert.ToString(objCommonLib.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Mail_Attachments));
                            string strServerPath = strPath + strCommonPath;

                            intSaveCounter = 0;

                            foreach (var myMsg in message.FindAllAttachments())
                            {
                                string filePath = Path.Combine(strServerPath, strFileNameArray[intSaveCounter]);
                                FileStream Stream = new FileStream(filePath, FileMode.Create);
                                BinaryWriter BinaryStream = new BinaryWriter(Stream);
                                BinaryStream.Write(myMsg.Body);
                                BinaryStream.Close();
                                intAttchCounter++;
                                intSaveCounter++;
                            }

                            //if mail remove is defined in division master
                            if (strRemove == "1")
                                objPop3.DeleteMessage(intListCount);


                        innerOut: ;
                        }
                    }
                //outer: ;
                //DataTable dtConfig = objBusinessMail.Read_Configuration();
                //if (dtConfig.Rows[0]["MAIL_STORE_DAYS"] != DBNull.Value)
                //{
                //    if (strDate != "")
                //    {
                //        int intDays = Convert.ToInt32(dtConfig.Rows[0]["MAIL_STORE_DAYS"]);
                //        DateTime dateMailDate = Convert.ToDateTime(strDate);
                //        DateTime dateCurrentDate = Convert.ToDateTime(System.DateTime.Now);

                    //        TimeSpan DateDifference = dateCurrentDate - dateMailDate;

                    //        if (DateDifference.TotalDays >= intDays)
                //        {
                //            objPop3.DeleteMessage(intListCount);
                //        }
                //    }
                //}
                //else
                //{
                //    objPop3.DeleteMessage(intListCount);
                //}
                outerLabel: ;
                }
                catch (Exception ex)
                {
                    continue;
                    //find the path
                    //string strServerPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString();

                    string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();
                    clsCommonLibrary objCommonLib = new clsCommonLibrary();
                    string strCommonPath = "\\ServiceError\\MailClient.txt";
                    string strFilePath = strServerPath + strCommonPath;

                    //if any exception on the time of mail fetching
                    if (File.Exists(strFilePath))
                    {
                        File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                        File.AppendAllText(strFilePath, ex.ToString());
                    }
                }
            }
            objEntityMail.Email_Address = strUserName;
            objEntityMail.Corporate_Id = intCorpId;
            objEntityMail.Organisation_Id = intOrgId;
            objEntityMail.EmailLimitDate = dtPreviousDate;
            objBusinessMail.Update_EmailLimitDate(objEntityMail);
            objPop3.Disconnect();
            objPop3.Dispose();

            //if email lIMIT dATE IS NOT SET
        outerDateLabel: ;
        }

        private void ErrfileWrite(string strWriteText)
        {

            StringBuilder strServerPath = new StringBuilder();
            strServerPath.Append(System.IO.Directory.GetCurrentDirectory().ToString());

            //strServerPath.Append(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString());

            StringBuilder strCommonPath = new StringBuilder();
            strCommonPath.Append("\\ServiceError\\MailClient.txt");

            StringBuilder strFilePath = new StringBuilder();
            strFilePath.Append(strServerPath.ToString() + strCommonPath.ToString());

            if (File.Exists(strFilePath.ToString()))
            {
                File.AppendAllText(strFilePath.ToString(), strWriteText + Environment.NewLine);
            }

        }

        //read receive mail details
        public bool Read_Receive_Mail(string strWebsiteorService, int intGetUserId = 0, int intGetOrgId = 0)
        {
            // when service  both intGetUserId and intGetOrgId will be zero
            //  when called from mail byte getmessage iterator will have value
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
            clsEncryptionDecryption objEncrypt = new clsEncryptionDecryption();
            DataTable dtMailDtls = objBusinessLayerMail.Read_Receive_Mail(intGetUserId, intGetOrgId);
            DataTable dtAllEmails = objBusinessLayerMail.ReadAllEmails(intGetOrgId);
            if (dtMailDtls.Rows.Count == 0) { }
            else
            {
                //create a list for storing all valid emails
                List<string> LstEmail = new List<string>();
                List<string> LstUserId = new List<string>();
                List<string> LstDivision = new List<string>();

                for (int intRowCount = 0; intRowCount < dtAllEmails.Rows.Count; intRowCount++)
                {
                    if (dtAllEmails.Rows[intRowCount]["MAIL ADDRESS"] != DBNull.Value)
                        LstEmail.Add(dtAllEmails.Rows[intRowCount]["MAIL ADDRESS"].ToString());
                }

                for (int intRowCount = 0; intRowCount < dtAllEmails.Rows.Count; intRowCount++)
                {
                    if (dtAllEmails.Rows[intRowCount]["USER ID"] != DBNull.Value)
                        LstUserId.Add(dtAllEmails.Rows[intRowCount]["USER ID"].ToString());
                }

                for (int intRowCount = 0; intRowCount < dtAllEmails.Rows.Count; intRowCount++)
                {
                    if (dtAllEmails.Rows[intRowCount]["DIVISION ID"] != DBNull.Value)
                        LstDivision.Add(dtAllEmails.Rows[intRowCount]["DIVISION ID"].ToString());
                }

                for (int intRowCount = 0; intRowCount < dtMailDtls.Rows.Count; intRowCount++)
                {
                    string strToAddress = dtMailDtls.Rows[intRowCount]["MLCNFG_EMAIL"].ToString();
                    //if this to address mailbox's mails already fetched
                    if (LstToAddress.Contains(strToAddress) == true)
                        goto OuterLabel;
                    string server = dtMailDtls.Rows[intRowCount]["MLCNFG_IN_SERVICE_NAME"].ToString();
                    string UserName = dtMailDtls.Rows[intRowCount]["MLCNFG_EMAIL"].ToString();
                    string EncryPassword = dtMailDtls.Rows[intRowCount]["MLCNFG_PASSWORD"].ToString();
                    string Password = objEncrypt.Decrypt(EncryPassword);
                    int intPort = Convert.ToInt32(dtMailDtls.Rows[intRowCount]["MLCNFG_IN_PORT_NUMBER"]);
                    bool sslStatus = Convert.ToBoolean(dtMailDtls.Rows[intRowCount]["MLCNFG_SSL_STATUS"]);
                    int intCorpId = Convert.ToInt32(dtMailDtls.Rows[intRowCount]["CORPRT_ID"]);
                    int intOrgId = Convert.ToInt32(dtMailDtls.Rows[intRowCount]["ORG_ID"]);
                    int intDivisionId = Convert.ToInt32(dtMailDtls.Rows[intRowCount]["CPRDIV_ID"]);
                    int intUserId = Convert.ToInt32(dtMailDtls.Rows[intRowCount]["USR_ID"]);
                    string strEmailLimitDate = dtMailDtls.Rows[intRowCount]["MLCNFG_EMAIL_LIMIT_DATE"].ToString().Trim();
                    string strStorageMail = dtMailDtls.Rows[intRowCount]["MAIL STORAGE"].ToString();
                    string strRemove = "";
                    if (strStorageMail != "0")
                    {
                        strRemove = dtMailDtls.Rows[intRowCount]["Remove"].ToString();
                    }
                    else
                    {
                        strRemove = "0";
                    }
                    try
                    {

                        ReadMail(server, intPort, sslStatus, UserName, Password, intCorpId, intOrgId, strToAddress, intDivisionId, intUserId, strEmailLimitDate, strWebsiteorService, LstEmail, strRemove, LstUserId, LstDivision);

                    }
                    catch (Exception ex)
                    {

                        //find the path
                        //string strServerPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString();

                        string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();

                        clsCommonLibrary objCommonLib = new clsCommonLibrary();
                        string strCommonPath = "\\ServiceError\\MailClient.txt";
                        string strFilePath = strServerPath + strCommonPath;

                        //if any exception on the time of mail fetching
                        if (File.Exists(strFilePath))
                        {
                            File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                            File.AppendAllText(strFilePath, ex.ToString());

                            File.AppendAllText(strFilePath, Environment.NewLine + "Mail Server: " + server);
                            File.AppendAllText(strFilePath, Environment.NewLine + "Mail User: " + UserName);
                            File.AppendAllText(strFilePath, Environment.NewLine + "Mail Password: " + Password);
                            File.AppendAllText(strFilePath, Environment.NewLine + "Mail Port: " + intPort);
                            File.AppendAllText(strFilePath, Environment.NewLine + "Mail To Address: " + strToAddress);

                        }


                    }
                OuterLabel: ;
                }

            }

            return false;
        }

        public bool MailSendingChking()
        {

            string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();
            string strCommonPath = "\\ServiceError\\GMS_Mail.txt";
            string strFilePath = strServerPath + strCommonPath;

            //if any exception on the time of mail fetching

            if (File.Exists(strFilePath) == false)
            {
                File.CreateText(strFilePath).Close();
            }


            if (File.Exists(strFilePath))
            {
                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, "Mail Send Start" + strServerPath + Environment.NewLine);
            }
            try
            {

                clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();
                Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();
                clsBusinessLayer objBusiness = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();

                DateTime dtDateNow = DateTime.Now;
                string strCurrentDate = objBusiness.LoadCurrentDateInString();
                DateTime dateCurrntdte = objCommon.textToDateTime(strCurrentDate);

                DateTime dateRfqCloseDate = DateTime.MinValue;
                DataTable dtReqstGuarnteedetails = objBusnssTemMailServce.ReqstGuarnteedetails(EntityTemMailServce);

                if (dtReqstGuarnteedetails.Rows.Count > 0)
                {
                    foreach (DataRow rowrqst in dtReqstGuarnteedetails.Rows)
                    {
                        dateRfqCloseDate = objCommon.textToDateTime(rowrqst["RFQ_CLOSING_DATE"].ToString());
                        if (dtDateNow >= dateRfqCloseDate)
                        {
                            EntityTemMailServce.ReqstGrntId = Convert.ToInt32(rowrqst["RFQ_ID"].ToString());
                            objBusnssTemMailServce.UpdateRfqCloseDate(EntityTemMailServce);
                        }
                    }
                }


                //hiddenCurrentDate.Value = strCurrentDate;
                DataTable dtBankGuaranteeDtls = objBusnssTemMailServce.ReadBankDetails(EntityTemMailServce);
                int intTimeDiff = 0, intdays = 0, inthour = 0, intSectId = 0;
                DateTime dtdatehourDiff;
                //DateTime dtDateNow = DateTime.Now;

                File.AppendAllText(strFilePath, "Total Guarantee count: " + dtBankGuaranteeDtls.Rows.Count);

                if (dtBankGuaranteeDtls.Rows.Count > 0)
                {
                    foreach (DataRow row in dtBankGuaranteeDtls.Rows)
                    {
                        DateTime dateExpiredte = DateTime.MinValue;
                        if (row["GUARANTEE_EXP_DATE"].ToString() != "")
                        {
                            dateExpiredte = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());
                        }
                        DateTime dateGuarnteeDate = new DateTime();
                        if (row["GUARANTEE_DATE"].ToString() != "")
                        {
                            dateGuarnteeDate = objCommon.textToDateTime(row["GUARANTEE_DATE"].ToString());
                        }
                        int inttempltAlertOptn = Convert.ToInt32(row["GRNT_TMALRT_OPT"].ToString());
                        EntityTemMailServce.GuaranteeId = Convert.ToInt32(row["GUARANTEE_ID"].ToString());
                        int intCorpId = 0;
                        intCorpId = Convert.ToInt32(row["CORPRT_ID"].ToString());
                        EntityTemMailServce.CorpOffice_Id = intCorpId;
                        DataTable dtGR = objBusnssTemMailServce.ReadGuranteeById(EntityTemMailServce);
                        EntityTemMailServce.TempAlertId = Convert.ToInt32(row["GRNT_TMALRT_ID"].ToString());

                        int intGurntId = 0, intTemAlertId = 0, GuarntypeChk = 0;
                        string strRefNo = "", strGurantTyp = "", strGuaranteeNo = "";
                        strGurantTyp = row["GUARNTYPE_ID"].ToString();
                        if (strGurantTyp == "101")
                        {
                            GuarntypeChk = 1;
                        }
                        strGuaranteeNo = row["GUARANTEE_NUMBER"].ToString();
                        strRefNo = row["GUARANTEE_REF_NUM"].ToString();
                        intGurntId = Convert.ToInt32(row["GUARANTEE_ID"].ToString());
                        intTemAlertId = Convert.ToInt32(row["GRNT_TMALRT_ID"].ToString());
                        if (row["GRTY_TMDTL_DASHBOARD"].ToString() != "0" || row["GRTY_TMDTL_EMAIL"].ToString() != "0")
                        {

                            if (row["GRTY_TMDTL_EMAIL"].ToString() != "0")
                            {

                                DataTable dtMailServce;
                                string MailAddress = "";
                                // MailAddress = "ajinks@volviar.com";
                                //TempMailSend(MailAddress);TemAlertId

                                string strMailSndNot = row["GRNT_MAILSEND_STS"].ToString();
                                if (inttempltAlertOptn != 3)
                                {
                                    intSectId = Convert.ToInt32(row["GRNT_NTFY_ID"].ToString());
                                    EntityTemMailServce.EmployeId = intSectId;
                                }

                                if (row["GRTY_TMDTL_PERIOD"].ToString() == "1")
                                {

                                    if (GuarntypeChk != 1)
                                    {
                                        inthour = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                        dtdatehourDiff = dateExpiredte.AddHours(-(inthour));


                                        if (dtDateNow >= dtdatehourDiff)
                                        {
                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {

                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {

                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }


                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                         MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                    TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                   
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        inthour = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                        dtdatehourDiff = dateGuarnteeDate.AddHours((inthour));
                                        if (dtDateNow >= dtdatehourDiff)
                                        {
                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {


                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }


                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                                else if (row["GRTY_TMDTL_PERIOD"].ToString() == "2")
                                {
                                    if (GuarntypeChk != 1)
                                    {
                                        intdays = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                        if (row["GUARANTEE_EXP_DATE"].ToString() != "")
                                        {
                                            EntityTemMailServce.ExpireDate = objCommon.textToDateTime(row["GUARANTEE_EXP_DATE"].ToString());
                                        }


                                        //  intTimeDiff = Math.Abs(Convert.ToInt32(dateExpiredte.ToShortTimeString()) - Convert.ToInt32(dateCurrntdte.ToShortTimeString()));
                                        intTimeDiff = Convert.ToInt32((dateExpiredte - dateCurrntdte).TotalDays);
                                        if (Math.Abs(intdays) >= Math.Abs(intTimeDiff))
                                        {
                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {


                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {


                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }

                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    //string strMailAddrs = "";
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }


                                            }


                                        }
                                    }
                                    else
                                    {
                                        intdays = Convert.ToInt32(row["GRTY_TMDTL_COUNT"].ToString());
                                        intdays++;
                                        DateTime dateExpGurntDate = dateGuarnteeDate.AddDays(intdays);
                                        if (dtDateNow >= dateExpGurntDate)
                                        {

                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {


                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {


                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }

                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    //string strMailAddrs = "";
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddress(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["GRNT_TMALRT_EMAIL"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            TempMailSend(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }

                                                //if any exception on the time of mail fetching
                                                if (File.Exists(strFilePath))
                                                {
                                                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                                                    File.AppendAllText(strFilePath, "PASS");
                                                }
                                            }


                                        }

                                    }
                                }

                            }

                        }

                    }
                }

                //Insurance Mail 

                DataTable dtInsuranceDtls = objBusnssTemMailServce.ReadInsuranceDetails(EntityTemMailServce);
                int intTimeDiff_Insu = 0, intdays_Insu = 0, inthour_insu = 0, intSectId_Insu = 0;
                DateTime dtdatehourDiff_Insu;

                if (dtInsuranceDtls.Rows.Count > 0)
                {
                    foreach (DataRow row in dtInsuranceDtls.Rows)
                    {
                        DateTime dateExpiredte = DateTime.MinValue;
                        if (row["INSURANCE_EXP_DATE"].ToString() != "")
                        {
                            dateExpiredte = objCommon.textToDateTime(row["INSURANCE_EXP_DATE"].ToString());
                        }
                        DateTime dateGuarnteeDate = new DateTime();
                        if (row["INSURANCE_DATE"].ToString() != "")
                        {
                            dateGuarnteeDate = objCommon.textToDateTime(row["INSURANCE_DATE"].ToString());
                        }
                        int inttempltAlertOptn = Convert.ToInt32(row["INSRNC_TMPALRT_OPT"].ToString());
                        EntityTemMailServce.InsuranceID = Convert.ToInt32(row["INSURANCE_ID"].ToString());
                        int intCorpId = 0;
                        intCorpId = Convert.ToInt32(row["CORPRT_ID"].ToString());
                        EntityTemMailServce.CorpOffice_Id = intCorpId;
                        DataTable dtGR = objBusnssTemMailServce.ReadInsuranceByID(EntityTemMailServce);
                        EntityTemMailServce.TempAlertId = Convert.ToInt32(row["INSRNC_TMPALRT_ID"].ToString());

                        int intGurntId = 0, intTemAlertId = 0, GuarntypeChk = 0;
                        string strRefNo = "", strGurantTyp = "", strGuaranteeNo = "";
                        strGurantTyp = row["INSURNCTYPE_ID"].ToString();
                        if (strGurantTyp == "101")
                        {
                            GuarntypeChk = 1;
                        }
                        strGuaranteeNo = row["INSURANCE_NUMBER"].ToString();
                        strRefNo = row["INSURANCE_REF_NUM"].ToString();
                        intGurntId = Convert.ToInt32(row["INSURANCE_ID"].ToString());
                        intTemAlertId = Convert.ToInt32(row["INSRNC_TMPALRT_ID"].ToString());
                        if (row["INSRNC_TMPDTL_DASHBOARD"].ToString() != "0" || row["INSRNC_TMPDTL_EMAIL"].ToString() != "0")
                        {

                            if (row["INSRNC_TMPDTL_EMAIL"].ToString() != "0")
                            {

                                DataTable dtMailServce;
                                string MailAddress = "";
                                // MailAddress = "ajinks@volviar.com";
                                //Temp_MailSendForInsurance(MailAddress);TemAlertId

                                string strMailSndNot = row["INSRNC_MAILSEND_STS"].ToString();
                                if (inttempltAlertOptn != 3)
                                {
                                    intSectId_Insu = Convert.ToInt32(row["INSRNC_NOTIFY_ID"].ToString());
                                    EntityTemMailServce.EmployeId = intSectId_Insu;
                                }

                                if (row["INSRNC_TMPDTL_PERIOD"].ToString() == "1")
                                {

                                    if (GuarntypeChk != 1)
                                    {
                                        inthour_insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                        dtdatehourDiff_Insu = dateExpiredte.AddHours(-(inthour_insu));


                                        if (dtDateNow >= dtdatehourDiff_Insu)
                                        {
                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {

                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {

                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }


                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        inthour_insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                        dtdatehourDiff_Insu = dateGuarnteeDate.AddHours((inthour_insu));
                                        if (dtDateNow >= dtdatehourDiff_Insu)
                                        {
                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {


                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }


                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                                else if (row["INSRNC_TMPDTL_PERIOD"].ToString() == "2")
                                {
                                    if (GuarntypeChk != 1)
                                    {
                                        intdays_Insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                        if (row["INSURANCE_EXP_DATE"].ToString() != "")
                                        {
                                            EntityTemMailServce.ExpireDate = objCommon.textToDateTime(row["INSURANCE_EXP_DATE"].ToString());
                                        }


                                        //  intTimeDiff_Insu = Math.Abs(Convert.ToInt32(dateExpiredte.ToShortTimeString()) - Convert.ToInt32(dateCurrntdte.ToShortTimeString()));
                                        intTimeDiff_Insu = Convert.ToInt32((dateExpiredte - dateCurrntdte).TotalDays);
                                        if (Math.Abs(intdays_Insu) >= Math.Abs(intTimeDiff_Insu))
                                        {
                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {


                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {


                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }

                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    //string strMailAddrs = "";
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }


                                            }


                                        }
                                    }
                                    else
                                    {
                                        intdays_Insu = Convert.ToInt32(row["INSRNC_TMPDTL_COUNT"].ToString());
                                        intdays_Insu++;
                                        DateTime dateExpGurntDate = dateGuarnteeDate.AddDays(intdays_Insu);
                                        if (dtDateNow >= dateExpGurntDate)
                                        {

                                            if (strMailSndNot == "0")
                                            {

                                                if (inttempltAlertOptn == 0)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadDivisiondetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["CPRDIV_EMAIL_ID"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 1)
                                                {


                                                    dtMailServce = objBusnssTemMailServce.ReadDesignatndetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow roww in dtMailServce.Rows)
                                                        {


                                                            MailAddress = roww["USR_EMAIL"].ToString();

                                                            //MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);

                                                        }
                                                    }

                                                }
                                                else if (inttempltAlertOptn == 2)
                                                {
                                                    dtMailServce = objBusnssTemMailServce.ReadEmplydetails(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        MailAddress = dtMailServce.Rows[0]["USR_EMAIL"].ToString();
                                                        Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                    }
                                                }
                                                else if (inttempltAlertOptn == 3)
                                                {
                                                    //string strMailAddrs = "";
                                                    string strMailAddrs = "";
                                                    dtMailServce = objBusnssTemMailServce.ReadMailAddressInsurance(EntityTemMailServce);
                                                    if (dtMailServce.Rows.Count > 0)
                                                    {
                                                        strMailAddrs = dtMailServce.Rows[0]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                                                        string[] strAddrs = strMailAddrs.Split(',');
                                                        foreach (string str in strAddrs)
                                                        {
                                                            MailAddress = str;
                                                            Temp_MailSendForInsurance(MailAddress, intCorpId, intGurntId, strRefNo, strGuaranteeNo, dateExpiredte, GuarntypeChk, intTemAlertId, dtGR);
                                                        }
                                                    }
                                                }

                                                //if any exception on the time of mail fetching
                                                if (File.Exists(strFilePath))
                                                {
                                                    File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                                                    File.AppendAllText(strFilePath, "PASS");
                                                }
                                            }


                                        }

                                    }
                                }

                            }

                        }

                    }
                }





            }
            catch (Exception ex)
            {
                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, ex.ToString() + "inside Error");
            }
            return false;
        }

        private void TempMailSend(string MailAddress, int intCorpId, int intGurntId, string strRefNo, string strGuaranteeNo, DateTime dateExpiredte, int GuarntypeChk, int intTemAlertId, DataTable dtGR)
        {


            string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();
            string strCommonPath = "\\ServiceError\\GMS_Mail.txt";
            string strFilePath = strServerPath + strCommonPath;
            if (File.Exists(strFilePath))
            {
                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, "Mail Sending in progress");
            }


            Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();


            EntityTemMailServce.CorpOffice_Id = intCorpId;
            EntityTemMailServce.GuaranteeId = intGurntId;
            EntityTemMailServce.TempAlertId = intTemAlertId;
            EntityTemMailServce.MailMOdule = "BANK GUARANTEE";
            clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
            //clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            MailMessage mail = new MailMessage();
            DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
            DataTable dtUserDetails = new DataTable();

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }

            string g_Ref = "";
            string g_Mode = "";
            string g_Type = "";
            string g_ExDate = "";
            string g_Projct_Ref = "";
            string g_Projct_Name = "";
            string g_Contact_PName = "";
            string g_Cont_PEmail = "";
            string g_Bank_gurn_date = "";
            string g_Cust_SupplierName = "";
            string g_Amount = "";
            string g_CurrencyType = "";
            string g_BankName = "";
            string g_GrnteeNo = "";
            // string g_Per_No = "";
            if (dtGR.Rows.Count > 0)
            {
                /////
                //FOR TRACKING TABLE
                EntityTemMailServce.Organisation_Id = Convert.ToInt32(dtGR.Rows[0]["ORG_ID"].ToString());
                EntityTemMailServce.RefNumber = dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString();

                if (dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString() != "")
                {
                    g_Ref = dtGR.Rows[0]["GUARANTEE_REF_NUM"].ToString();
                }



                if (dtGR.Rows[0]["GUANTCAT_NAME"].ToString() != "")
                {
                    g_Mode = dtGR.Rows[0]["GUANTCAT_NAME"].ToString();
                }

                if (dtGR.Rows[0]["GUARNTYPE_NAME"].ToString() != "")
                {
                    g_Type = dtGR.Rows[0]["GUARNTYPE_NAME"].ToString();
                }
                else
                {
                    g_Type = "";
                }
                if (dtGR.Rows[0]["GUARANTEE_EXP_DATE"].ToString() != "")
                {
                    g_ExDate = dtGR.Rows[0]["GUARANTEE_EXP_DATE"].ToString();
                }


                if (dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString() != "")
                {
                    g_Projct_Ref = dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString();
                }
                else
                {

                    g_Projct_Ref = "";
                }

                if (dtGR.Rows[0]["PROJECT_NAME"].ToString() != "")
                {
                    g_Projct_Name = dtGR.Rows[0]["PROJECT_NAME"].ToString();
                }
                else
                {

                    g_Projct_Name = "";
                }
                if (dtGR.Rows[0]["GUARANTEE_PERSON_NAME"].ToString() != "")
                {
                    g_Contact_PName = dtGR.Rows[0]["GUARANTEE_PERSON_NAME"].ToString();
                }
                else
                {
                    g_Contact_PName = "";
                }

                if (dtGR.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString() != "")
                {
                    g_Cont_PEmail = dtGR.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString();
                }
                else
                {
                    g_Cont_PEmail = "";
                }

                //if (dtGR.Rows[0]["USR_NAME"].ToString() != "")
                //{
                //    g_Per_No = dtGR.Rows[0]["USR_NAME"].ToString();
                //}
                //else
                //{
                //    g_Per_No = "";
                //}
                if (dtGR.Rows[0]["GUARANTEE_DATE"].ToString() != "")
                {
                    g_Bank_gurn_date = dtGR.Rows[0]["GUARANTEE_DATE"].ToString();
                }
                else
                {
                    g_Bank_gurn_date = "";
                }
                //Mod by EVM-0012
                if (dtGR.Rows[0]["CSTMR_NAME"].ToString() != "")
                {
                    g_Cust_SupplierName = dtGR.Rows[0]["CSTMR_NAME"].ToString();
                }
                else
                {
                    g_Cust_SupplierName = "";
                }
                if (dtGR.Rows[0]["GUARANTEE_AMOUNT"].ToString() != "")
                {
                    string strAmount = dtGR.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                    g_Amount = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
                }
                else
                {
                    g_Amount = "";
                }
                if (dtGR.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                {
                    g_CurrencyType = dtGR.Rows[0]["CRNCMST_ABBRV"].ToString();
                }
                else
                {
                    g_CurrencyType = "";
                }
                if (dtGR.Rows[0]["BANK_NAME"].ToString() != "")
                {
                    g_BankName = dtGR.Rows[0]["BANK_NAME"].ToString();
                }
                else
                {
                    g_BankName = "";
                }

                if (dtGR.Rows[0]["GUARANTEE_NUMBER"].ToString() != "")
                {
                    g_GrnteeNo = dtGR.Rows[0]["GUARANTEE_NUMBER"].ToString();
                }
                else
                {
                    g_GrnteeNo = "";
                }

            }

            string content = "";
            if (GuarntypeChk != 1)
            {
                content = " Dear Sir/Madam,<br/><br/> The below guarantee will expire on Date " + g_ExDate + ".";
            }
            else
            {
                content = " Dear Sir/Madam,<br/><br/> The below guarantee created on Date " + g_Bank_gurn_date + ".";
            }
            content += "<br/><br/><b><u>Guarantee Management System Notification</u></b>";
            //Evm-0012
            //table
            content += "<br/><br/><br/><table>";
            if (g_Cust_SupplierName != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Customer/Supplier&emsp;</th><td>:&emsp;" + g_Cust_SupplierName + "</td></tr>";


            }

            if (g_Amount != "")
            {

                content += "<tr style=\"text-align: left;\"><th>Amount&emsp;</th><td>:&emsp;" + g_Amount + " " + g_CurrencyType + "</td></tr>";
            }


            if (g_BankName != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Bank name&emsp;</th><td>:&emsp;" + g_BankName + "</td></tr>";

            }


            if (g_Ref != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Guarantee Ref #&emsp;</th><td>:&emsp;" + g_Ref + "</td></tr>";
            }
            if (g_GrnteeNo != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Guarantee Number&emsp;</th><td>:&emsp;" + g_GrnteeNo + "</td></tr>";
            }
            if (g_Mode != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Guarantee Mode&emsp;</th><td>:&emsp;" + g_Mode + "</td></tr>";
            }
            if (g_Type != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Guarantee Type&emsp;</th><td>:&emsp;" + g_Type + "</td></tr>";
            }
            if (GuarntypeChk != 1)
            {
                if (g_ExDate != "")
                {
                    content += "<tr style=\"text-align: left;\"><th>Expiry Date&emsp;</th><td>:&emsp;" + g_ExDate + "</td></tr>";
                }
            }
            if (g_Projct_Ref != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Project Ref&emsp;</th><td>:&emsp;" + g_Projct_Ref + "</td></tr>";
            }
            if (g_Projct_Ref != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Project Name&emsp;</th><td>:&emsp;" + g_Projct_Name + "</td></tr>";
            }
            if (g_Contact_PName != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Contact Person Name&emsp;</th><td>:&emsp;" + g_Contact_PName + "</td></tr>";

            }
            if (g_Cont_PEmail != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Contact Person Email&emsp;</th><td>:&emsp;" + g_Cont_PEmail + "</td></tr>";

            }
            content += "</table>";

            content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
            content += "<br/><br/><br/>Best Regards,";
            content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";


            if (dtFromMail.Rows.Count > 0)
            {

                objEntityMail.To_Email_Address = MailAddress;
                objEntityMail.Email_Subject = "BANK GUARANTEE EXPIRATION";
                objEntityMail.Email_Content = content;
                objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
                objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();



                List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                try
                {
                    if (File.Exists(strFilePath))
                    {
                        File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                        File.AppendAllText(strFilePath, "Mail Send");
                    }

                    SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);


                    objBusnssTemMailServce.UpdateMailChk(EntityTemMailServce);

                    string strMailDeliveryFile = "\\ServiceError\\GMSG_Mail.txt";
                    string strMailDeliveryPath = strServerPath + strMailDeliveryFile;

                    if(Directory.Exists(strServerPath + "\\ServiceError\\GMSG_Mail") == false)
                    {

                    }


                    string strMailDeliveryCopyFile = "\\ServiceError\\GMSG_Mail.txt";


                    if (File.Exists(strMailDeliveryPath) == false)
                    {
                        File.CreateText(strMailDeliveryPath).Close();
                    }
                 

                    if (File.Exists(strMailDeliveryPath))
                    {
                        File.AppendAllText(strMailDeliveryPath, System.DateTime.Now.ToString() + Environment.NewLine);
                        File.AppendAllText(strMailDeliveryPath, g_Ref + ' ' + objEntityMail.To_Email_Address.ToString());
                    }

                    EntityTemMailServce.D_Date = DateTime.Now;
                    EntityTemMailServce.FromMailId = objEntityMail.From_Email_Address;
                    EntityTemMailServce.ToMailId = objEntityMail.To_Email_Address;

                    EntityTemMailServce.MailSubject = objEntityMail.Email_Subject;
                    objBusnssTemMailServce.InsertMailTracking(EntityTemMailServce);

                }
                catch (Exception ex)
                {
                    if (File.Exists(strFilePath))
                    {
                        File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                        File.AppendAllText(strFilePath, ex + " - Mail Send error" + Environment.NewLine + objEntityMail.From_Email_Address + Environment.NewLine + objEntityMail.To_Email_Address);
                    }

                }

            }
        }

        private void Temp_MailSendForInsurance(string MailAddress, int intCorpId, int intGurntId, string strRefNo, string strGuaranteeNo, DateTime dateExpiredte, int GuarntypeChk, int intTemAlertId, DataTable dtGR)
        {
            //string strServerPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).ToString()).ToString();

            string strServerPath = System.IO.Directory.GetCurrentDirectory().ToString();
            string strCommonPath = "\\ServiceError\\GMS_Mail.txt";
            string strFilePath = strServerPath + strCommonPath;
            if (File.Exists(strFilePath))
            {
                File.AppendAllText(strFilePath, System.DateTime.Now.ToString() + Environment.NewLine);
                File.AppendAllText(strFilePath, "Mail Sending in progress");
            }


            Entity_Template_Mail_Service EntityTemMailServce = new Entity_Template_Mail_Service();


            EntityTemMailServce.CorpOffice_Id = intCorpId;
            EntityTemMailServce.InsuranceID = intGurntId;
            EntityTemMailServce.TempAlertId = intTemAlertId;
            EntityTemMailServce.MailMOdule = "INSURANCE";

            clsBusiness_Template_Mail_Service objBusnssTemMailServce = new clsBusiness_Template_Mail_Service();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
            //clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
            clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
            MailMessage mail = new MailMessage();
            DataTable dtFromMail = objBusnssTemMailServce.ReadFromMailDetails(EntityTemMailServce);
            DataTable dtUserDetails = new DataTable();

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                                  };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }

            string g_Ref = "";
            string g_Mode = "";
            string g_Type = "";
            string g_ExDate = "";
            string g_Projct_Ref = "";
            string g_Projct_Name = "";
            string g_Contact_PName = "";
            string g_Cont_PEmail = "";
            string g_Bank_gurn_date = "";
            string g_Cust_SupplierName = "";
            string g_Amount = "";
            string g_CurrencyType = "";
            string g_BankName = "";
            string g_GrnteeNo = "";
            // string g_Per_No = "";
            if (dtGR.Rows.Count > 0)
            {
                /////
                //FOR TRACKING TABLE
                EntityTemMailServce.Organisation_Id = Convert.ToInt32(dtGR.Rows[0]["ORG_ID"].ToString());
                EntityTemMailServce.RefNumber = dtGR.Rows[0]["INSURANCE_REF_NUM"].ToString();

                if (dtGR.Rows[0]["INSURANCE_REF_NUM"].ToString() != "")
                {
                    g_Ref = dtGR.Rows[0]["INSURANCE_REF_NUM"].ToString();
                }



                ////////////if (dtGR.Rows[0]["GUANTCAT_NAME"].ToString() != "")
                ////////////{
                ////////////    g_Mode = dtGR.Rows[0]["GUANTCAT_NAME"].ToString();
                ////////////}

                if (dtGR.Rows[0]["INSURNCTYPE_NAME"].ToString() != "")
                {
                    g_Type = dtGR.Rows[0]["INSURNCTYPE_NAME"].ToString();
                }
                else
                {
                    g_Type = "";
                }
                if (dtGR.Rows[0]["INSURANCE_EXP_DATE"].ToString() != "")
                {
                    g_ExDate = dtGR.Rows[0]["INSURANCE_EXP_DATE"].ToString();
                }


                if (dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString() != "")
                {
                    g_Projct_Ref = dtGR.Rows[0]["PROJECT_REF_NUMBER"].ToString();
                }
                else
                {

                    g_Projct_Ref = "";
                }

                if (dtGR.Rows[0]["PROJECT_NAME"].ToString() != "")
                {
                    g_Projct_Name = dtGR.Rows[0]["PROJECT_NAME"].ToString();
                }
                else
                {

                    g_Projct_Name = "";
                }
                if (dtGR.Rows[0]["INSURANCE_PERSON_NAME"].ToString() != "")
                {
                    g_Contact_PName = dtGR.Rows[0]["INSURANCE_PERSON_NAME"].ToString();
                }
                else
                {
                    g_Contact_PName = "";
                }

                if (dtGR.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString() != "")
                {
                    g_Cont_PEmail = dtGR.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString();
                }
                else
                {
                    g_Cont_PEmail = "";
                }

                //if (dtGR.Rows[0]["USR_NAME"].ToString() != "")
                //{
                //    g_Per_No = dtGR.Rows[0]["USR_NAME"].ToString();
                //}
                //else
                //{
                //    g_Per_No = "";
                //}
                if (dtGR.Rows[0]["INSURANCE_DATE"].ToString() != "")
                {
                    g_Bank_gurn_date = dtGR.Rows[0]["INSURANCE_DATE"].ToString();
                }
                else
                {
                    g_Bank_gurn_date = "";
                }
                //Mod by EVM-0012
                //////////////if (dtGR.Rows[0]["CSTMR_NAME"].ToString() != "")
                //////////////{
                //////////////    g_Cust_SupplierName = dtGR.Rows[0]["CSTMR_NAME"].ToString();
                //////////////}
                //////////////else
                //////////////{
                //////////////    g_Cust_SupplierName = "";
                //////////////}
                if (dtGR.Rows[0]["INSURANCE_AMOUNT"].ToString() != "")
                {
                    string strAmount = dtGR.Rows[0]["INSURANCE_AMOUNT"].ToString();
                    g_Amount = objBusiness.AddCommasForNumberSeperation(strAmount, objEntityCommon);
                }
                else
                {
                    g_Amount = "";
                }
                if (dtGR.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                {
                    g_CurrencyType = dtGR.Rows[0]["CRNCMST_ABBRV"].ToString();
                }
                else
                {
                    g_CurrencyType = "";
                }
                if (dtGR.Rows[0]["INSURPRVDR_NAME"].ToString() != "")
                {
                    g_BankName = dtGR.Rows[0]["INSURPRVDR_NAME"].ToString();
                }
                else
                {
                    g_BankName = "";
                }

                if (dtGR.Rows[0]["INSURANCE_NUMBER"].ToString() != "")
                {
                    g_GrnteeNo = dtGR.Rows[0]["INSURANCE_NUMBER"].ToString();
                }
                else
                {
                    g_GrnteeNo = "";
                }

            }

            string content = "";
            if (GuarntypeChk != 1)
            {
                content = " Dear Sir/Madam,<br/><br/> The below insurance will expire on Date " + g_ExDate + ".";
            }
            else
            {
                content = " Dear Sir/Madam,<br/><br/> The below insurance created on Date " + g_Bank_gurn_date + ".";
            }
            content += "<br/><br/><b><u>Insurance Management System Notification</u></b>";
            //Evm-0012
            //table
            content += "<br/><br/><br/><table>";
            if (g_Cust_SupplierName != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Customer/Supplier&emsp;</th><td>:&emsp;" + g_Cust_SupplierName + "</td></tr>";


            }

            if (g_Amount != "")
            {

                content += "<tr style=\"text-align: left;\"><th>Amount&emsp;</th><td>:&emsp;" + g_Amount + " " + g_CurrencyType + "</td></tr>";
            }


            if (g_BankName != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Insurance provider name&emsp;</th><td>:&emsp;" + g_BankName + "</td></tr>";

            }


            if (g_Ref != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Insurance Ref #&emsp;</th><td>:&emsp;" + g_Ref + "</td></tr>";
            }
            if (g_GrnteeNo != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Insurance Number&emsp;</th><td>:&emsp;" + g_GrnteeNo + "</td></tr>";
            }
            if (g_Mode != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Insurance Mode&emsp;</th><td>:&emsp;" + g_Mode + "</td></tr>";
            }
            if (g_Type != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Insurance Type&emsp;</th><td>:&emsp;" + g_Type + "</td></tr>";
            }
            if (GuarntypeChk != 1)
            {
                if (g_ExDate != "")
                {
                    content += "<tr style=\"text-align: left;\"><th>Expiry Date&emsp;</th><td>:&emsp;" + g_ExDate + "</td></tr>";
                }
            }
            if (g_Projct_Ref != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Project Ref&emsp;</th><td>:&emsp;" + g_Projct_Ref + "</td></tr>";
            }
            if (g_Projct_Ref != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Project Name&emsp;</th><td>:&emsp;" + g_Projct_Name + "</td></tr>";
            }
            if (g_Contact_PName != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Contact Person Name&emsp;</th><td>:&emsp;" + g_Contact_PName + "</td></tr>";

            }
            if (g_Cont_PEmail != "")
            {
                content += "<tr style=\"text-align: left;\"><th>Contact Person Email&emsp;</th><td>:&emsp;" + g_Cont_PEmail + "</td></tr>";

            }
            content += "</table>";

            content += "<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>";
            content += "<br/><br/><br/>Best Regards,";
            content += "<br/><font color=\"#0a409b\"><b>Compzit Administrator</b></font><br/><font color=\"#438df8\">Al-Balagh Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>";


            if (dtFromMail.Rows.Count > 0)
            {

                objEntityMail.To_Email_Address = MailAddress;
                objEntityMail.Email_Subject = "INSURANCE EXPIRATION";
                objEntityMail.Email_Content = content;
                objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
                objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();



                List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                try
                {
                    SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                    objBusnssTemMailServce.UpdateMailChk_Insurance(EntityTemMailServce);


                    EntityTemMailServce.D_Date = DateTime.Now;
                    EntityTemMailServce.FromMailId = objEntityMail.From_Email_Address;
                    EntityTemMailServce.ToMailId = objEntityMail.To_Email_Address;

                    EntityTemMailServce.MailSubject = objEntityMail.Email_Subject;
                    objBusnssTemMailServce.InsertMailTracking(EntityTemMailServce);

                }
                catch
                {


                }

            }
        }


        public void SendMailAsHtml(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList)
        {

            clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient SmtpServer = new SmtpClient(objEntityMail.Out_Service_Name);
            mail.From = new MailAddress(objEntityMail.From_Email_Address);
            mail.To.Add(objEntityMail.To_Email_Address);
            foreach (classEntityToMailAddress objEntityToMailAddress in objEntityToMailAddressList)
            {
                if (objEntityToMailAddress.ToAddress != "" && objEntityToMailAddress.ToAddress != null)
                {
                    mail.To.Add(new MailAddress(objEntityToMailAddress.ToAddress));
                }
            }

            foreach (clsEntityMailCcBCc objEntityMailCcBCc in objEntityMailCcBCcList)
            {
                if (objEntityMailCcBCc.CcMail != "" && objEntityMailCcBCc.CcMail != null)
                {
                    mail.CC.Add(new MailAddress(objEntityMailCcBCc.CcMail)); //Adding Multiple CC email Id
                }
                if (objEntityMailCcBCc.BCcMail != "" && objEntityMailCcBCc.BCcMail != null)
                {

                    mail.Bcc.Add(new MailAddress(objEntityMailCcBCc.BCcMail)); //Adding Multiple BCC email Id
                }
            }



            //string strBody = objEntityMail.Email_Content + objEntityMail.Signature;
            //string strBody = objEntityMail.Email_Content;
            mail.Subject = objEntityMail.Email_Subject;
            mail.Body = objEntityMail.Email_Content;
            // mail.IsBodyHtml = true;


            //ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            //// Add the alternate body to the message.

            //AlternateView alternate = AlternateView.CreateAlternateViewFromString(strBody, mimeType);
            //mail.AlternateViews.Add(alternate);


            //for attachment
            foreach (clsEntityMailAttachment objEntityAtt in objEntityMailAttachList)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(objEntityAtt.Attch_Path);
                mail.Attachments.Add(attachment);
            }

            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            SmtpServer.Port = Convert.ToInt32(objEntityMail.Out_Port_Number);
            string strPassword = objEncryptDecrypt.Decrypt(objEntityMail.Password);
            if (objEntityMail.SSL_Status == 1)
                SmtpServer.EnableSsl = true;
            else
                SmtpServer.EnableSsl = false;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(objEntityMail.From_Email_Address, strPassword);
            SmtpServer.Send(mail);
            SmtpServer.Dispose();
            mail.Dispose();
        }

        public void SendJobNotifyMail(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList)
        {
            clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient SmtpServer = new SmtpClient(objEntityMail.Out_Service_Name);
            mail.From = new MailAddress(objEntityMail.From_Email_Address);
            mail.To.Add(objEntityMail.To_Email_Address);
            mail.Subject = objEntityMail.Email_Subject;
            mail.Body = objEntityMail.Email_Content;
            foreach (clsEntityMailAttachment objEntityAtt in objEntityMailAttachList)
            {
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(objEntityAtt.Attch_Path);
                mail.Attachments.Add(attachment);
            }
            SmtpServer.Port = Convert.ToInt32(objEntityMail.Out_Port_Number);
            string strPassword = objEncryptDecrypt.Decrypt(objEntityMail.Password);
            if (objEntityMail.SSL_Status == 1)
                SmtpServer.EnableSsl = true;
            else
                SmtpServer.EnableSsl = false;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(objEntityMail.From_Email_Address, strPassword);
            SmtpServer.Send(mail);
            SmtpServer.Dispose();
            mail.Dispose();
        }

    }
}

