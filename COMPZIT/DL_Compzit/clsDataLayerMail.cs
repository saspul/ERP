using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using CL_Compzit;


// CREATED BY:EVM-0001
// CREATED DATE:26/05/2015E:\Compzit\COMPZIT\DL_Compzit\clsDataLayerOrgType.cs
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Mail Sending it select the details of Sender .

namespace DL_Compzit
{
    public class clsDataLayerMail
    {
        //This Method is for selecting the Details of Company in the Datalayer it returns a DataTable  containing  details of  Company
        public DataTable ReadCompanyDetails()
        {
            string strCommandText = "MAIL.SP_READ_COMPANY_DETAILS";
            using (OracleCommand cmdComp = new OracleCommand())
            {
                cmdComp.CommandText = strCommandText;
                cmdComp.CommandType = CommandType.StoredProcedure;
                cmdComp.Parameters.Add("D_COMPANY_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCompDisp = new DataTable();
                dtCompDisp = clsDataLayer.SelectDataTable(cmdComp);
                return dtCompDisp;
            }
        }

        //fetch configuration table details
        public DataTable ReadConfigurations()
        {
            string strCommandText = "MAIL.SP_READ_CONFIG";
            using (OracleCommand cmdConfig = new OracleCommand())
            {
                cmdConfig.CommandText = strCommandText;
                cmdConfig.CommandType = CommandType.StoredProcedure;
                cmdConfig.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtConfig = new DataTable();
                dtConfig = clsDataLayer.SelectDataTable(cmdConfig);
                return dtConfig;
            }
        }

        //fetch divisions based on organisation and corporate office id
        public DataTable LoadDivisions(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_LOAD_DIVISIONS";
            using (OracleCommand cmdLoadDivision = new OracleCommand())
            {
                cmdLoadDivision.CommandText = strCommandText;
                cmdLoadDivision.CommandType = CommandType.StoredProcedure;
                cmdLoadDivision.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                cmdLoadDivision.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                cmdLoadDivision.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtDivision = new DataTable();
                dtDivision = clsDataLayer.SelectDataTable(cmdLoadDivision);
                return dtDivision;
            }
        }

        //load allocate user id
        public DataTable Load_Allocate_User(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.LOAD_ALLOCATE_EMPLOYEES";
            using (OracleCommand cmdLoadEmployees = new OracleCommand())
            {
                cmdLoadEmployees.CommandText = strCommandText;
                cmdLoadEmployees.CommandType = CommandType.StoredProcedure;
                cmdLoadEmployees.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                cmdLoadEmployees.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                cmdLoadEmployees.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                cmdLoadEmployees.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtUsers = new DataTable();
                dtUsers = clsDataLayer.SelectDataTable(cmdLoadEmployees);
                return dtUsers;
            }
        }


        public void InsertToStoreDetail(string strTempalteId, string strToAddr, string strTransId, DataTable dtCompanyDetails, DataTable dtTemplateDetail)
        {
            int intStatus = 0;
            string strCommandText = "MAIL.SP_INSERT_GN_EMAIL_STORE";
            using (OracleCommand cmdStore = new OracleCommand())
            {
                cmdStore.CommandText = strCommandText;
                cmdStore.CommandType = CommandType.StoredProcedure;
                cmdStore.Parameters.Add("S_TMTP_ID", OracleDbType.Int32).Value = dtTemplateDetail.Rows[0]["EMTMTP_ID"].ToString(); ;
                cmdStore.Parameters.Add("S_TRANS_ID", OracleDbType.Int32).Value = Convert.ToInt32(strTransId);
                cmdStore.Parameters.Add("S_FR0M_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_EMAIL_SENDMAIL"].ToString();
                cmdStore.Parameters.Add("S_TO_MAIL", OracleDbType.Varchar2).Value = strToAddr;
                cmdStore.Parameters.Add("S_RPLYTO_MAIL", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_RPLYTO_SENDMAIL"].ToString();
                cmdStore.Parameters.Add("S_SUBJ", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_SUBJECT"].ToString();
                cmdStore.Parameters.Add("S_MSG", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_MESSAGE"].ToString();
                cmdStore.Parameters.Add("S_FROM_ADDR1", OracleDbType.Varchar2).Value = dtCompanyDetails.Rows[0]["CMPNY_ADDR1"].ToString();
                cmdStore.Parameters.Add("S_DISCLAIMER", OracleDbType.Varchar2).Value = dtTemplateDetail.Rows[0]["EMTMPLT_DISCLAIMER"].ToString();
                cmdStore.Parameters.Add("S_SEND_STATUS", OracleDbType.Int32).Value = intStatus;
                cmdStore.Parameters.Add("S_TMPLT_ID", OracleDbType.Int32).Value = Convert.ToInt32(strTempalteId);
                clsDataLayer.ExecuteNonQuery(cmdStore);
            }
        }
        //fetch server,port,email,password.... mail details from mail console config table based on organisation and corporate office id
        //this will happen most probebly at the begin of app and at the time of refresh mail console.
        //check mail console config email address with corporate division email address 
        //M_GET_USR_ID AND M_GET_ORG_ID would be zero if they are from windows service .If from mail page when GetMessage is clicked then it has values
        public DataTable ReadReceiveMailDetails(int intGetUserId, int intGetOrgId)
        {
            string strCommandText = "MAIL.SP_READ_RECEIVE_MAIL_DETAILS";
            using (OracleCommand cmdReceiveMail = new OracleCommand())
            {
                cmdReceiveMail.CommandText = strCommandText;
                cmdReceiveMail.CommandType = CommandType.StoredProcedure;
                cmdReceiveMail.Parameters.Add("M_GET_USR_ID", OracleDbType.Int32).Value = intGetUserId;
                cmdReceiveMail.Parameters.Add("M_GET_ORG_ID", OracleDbType.Int32).Value = intGetOrgId;
                cmdReceiveMail.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReceiveMail = new DataTable();
                dtReceiveMail = clsDataLayer.SelectDataTable(cmdReceiveMail);
                return dtReceiveMail;
            }
        }

        //fetch all valid emails from databse based on divisions and employees
        public DataTable ReadAllEmails(int intOrgId)
        {
            string strCommandText = "MAIL.SP_READ_ALL_EMAILS";
            using (OracleCommand cmdReadMail = new OracleCommand())
            {
                cmdReadMail.CommandText = strCommandText;
                cmdReadMail.CommandType = CommandType.StoredProcedure;
                cmdReadMail.Parameters.Add("M_GET_ORG_ID", OracleDbType.Int32).Value = intOrgId;
                cmdReadMail.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadMail = new DataTable();
                dtReadMail = clsDataLayer.SelectDataTable(cmdReadMail);
                return dtReadMail;
            }
        }


        //methode for fetch the count from mail box table 
        public DataTable SelectUniqueIdCount(clsEntityMailConsole objEntityMail)
        {
            string strQueryUniqueIdCount = "MAIL.SP_READ_UNIQUEID_COUNT";
            OracleCommand cmdUniqueIdCode = new OracleCommand();
            cmdUniqueIdCode.CommandText = strQueryUniqueIdCount;
            cmdUniqueIdCode.CommandType = CommandType.StoredProcedure;
            cmdUniqueIdCode.Parameters.Add("M_UNIQUEID", OracleDbType.Varchar2).Value = objEntityMail.Email_Unique_Id;
            cmdUniqueIdCode.Parameters.Add("M_TOMAIL", OracleDbType.Varchar2).Value = objEntityMail.To_Email_Address;
            cmdUniqueIdCode.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMail.D_Date;
            cmdUniqueIdCode.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtUniqueMail = new DataTable();
            dtUniqueMail = clsDataLayer.SelectDataTable(cmdUniqueIdCode);
            return dtUniqueMail;
        }

        //methode for fetch mail box based mail storage
        public DataTable Read_Mail_Box(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_READ_MAILBOX";
            using (OracleCommand cmdReadMailBox = new OracleCommand())
            {
                cmdReadMailBox.CommandText = strCommandText;
                cmdReadMailBox.CommandType = CommandType.StoredProcedure;
                cmdReadMailBox.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                cmdReadMailBox.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                cmdReadMailBox.Parameters.Add("M_STREID", OracleDbType.Int32).Value = objEntityMail.Email_Store;
                cmdReadMailBox.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                cmdReadMailBox.Parameters.Add("M_MAILENABLE", OracleDbType.Int32).Value = objEntityMail.All_Mail_Enable;
                //------------------------------------------Pagination------------------------------------------------
                cmdReadMailBox.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityMail.CommonSearchTerm;
                cmdReadMailBox.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityMail.OrderColumn;
                cmdReadMailBox.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityMail.OrderMethod;
                cmdReadMailBox.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityMail.PageMaxSize;
                cmdReadMailBox.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityMail.PageNumber;
                //------------------------------------------Pagination------------------------------------------------
                cmdReadMailBox.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReceiveMail = new DataTable();
                dtReceiveMail = clsDataLayer.SelectDataTable(cmdReadMailBox );
                return dtReceiveMail;
            }
        }

        //methode for fetching  mail details from mail box based on mail id
        public DataTable Read_Mail_ById(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_READ_DETAILS_BY_MAILID";
            using (OracleCommand cmdReadMailById = new OracleCommand())
            {
                cmdReadMailById.CommandText = strCommandText;
                cmdReadMailById.CommandType = CommandType.StoredProcedure;
                cmdReadMailById.Parameters.Add("M_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdReadMailById.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMailDtl = new DataTable();
                dtMailDtl = clsDataLayer.SelectDataTable(cmdReadMailById);
                return dtMailDtl;
            }
        }

        //allocate a mail from inbox to trash
        public void PushToTrash(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_PUSH_TO_TRASH";
            using (OracleCommand cmdPushToTrash = new OracleCommand())
            {
                cmdPushToTrash.CommandText = strCommandText;
                cmdPushToTrash.CommandType = CommandType.StoredProcedure;
                cmdPushToTrash.Parameters.Add("M_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdPushToTrash.Parameters.Add("M_RSNID", OracleDbType.Int32).Value = objEntityMail.ReasonId;
                cmdPushToTrash.Parameters.Add("M_DESC", OracleDbType.Varchar2).Value = objEntityMail.Desc;
                clsDataLayer.ExecuteNonQuery(cmdPushToTrash);
            }
        }

        //forward a mail from one division to another
        public void ForwardMail(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_FORWARD_DIVISION";
            using (OracleCommand cmdForwardMail = new OracleCommand())
            {
                cmdForwardMail.CommandText = strCommandText;
                cmdForwardMail.CommandType = CommandType.StoredProcedure;
                cmdForwardMail.Parameters.Add("M_ID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdForwardMail.Parameters.Add("M_DIVID", OracleDbType.Int32).Value = objEntityMail.Transaction_Id;                
                clsDataLayer.ExecuteNonQuery(cmdForwardMail);
            }
        }

        //change the status of a mail from unread to read
        public void ChangeToRead(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_CHANGE_TO_READ";
            using (OracleCommand cmdChangeToRead = new OracleCommand())
            {
                cmdChangeToRead.CommandText = strCommandText;
                cmdChangeToRead.CommandType = CommandType.StoredProcedure;
                cmdChangeToRead.Parameters.Add("M_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdChangeToRead.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdChangeToRead);
            }
        }

        //allocate mail from one user to another user
        public void AllocateMail(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_MAIL_ALLOCATE";
            using (OracleCommand cmdAllocateMail = new OracleCommand())
            {
                cmdAllocateMail.CommandText = strCommandText;
                cmdAllocateMail.CommandType = CommandType.StoredProcedure;
                cmdAllocateMail.Parameters.Add("M_ID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdAllocateMail.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                cmdAllocateMail.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityMail.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdAllocateMail);
            }
        }


        //reject a allocated mail to previous position
        public void RejectMail(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_REJECT_MAIL";
            using (OracleCommand cmdRejectedMail = new OracleCommand())
            {
                cmdRejectedMail.CommandText = strCommandText;
                cmdRejectedMail.CommandType = CommandType.StoredProcedure;
                cmdRejectedMail.Parameters.Add("M_ID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                clsDataLayer.ExecuteNonQuery(cmdRejectedMail);
            }
        }

        // This Method adds mails from server to the table
        public void AddMail(clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttList)
        {
            //fetching next value
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddMail = "MAIL.SP_INSERT_MAIL_BOX";
                    using (OracleCommand cmdAddMail = new OracleCommand(strQueryAddMail, con))
                    {

                        cmdAddMail.CommandType = CommandType.StoredProcedure;
                        //generate next value
                       
                 
                        cmdAddMail.Parameters.Add("M_ID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                        cmdAddMail.Parameters.Add("M_FROM_MAIL", OracleDbType.Varchar2).Value = objEntityMail.From_Email_Address;
                        cmdAddMail.Parameters.Add("M_TO_MAIL", OracleDbType.Varchar2).Value = objEntityMail.To_Email_Address;
                        cmdAddMail.Parameters.Add("M_SUBJECT", OracleDbType.Varchar2).Value = objEntityMail.Email_Subject;
                        cmdAddMail.Parameters.Add("M_CONTENT", OracleDbType.Clob).Value = objEntityMail.Email_Content;
                        cmdAddMail.Parameters.Add("M_MAILSTORE", OracleDbType.Int32).Value = objEntityMail.Email_Store;
                        //there is no mail action on the time of filling mails from server to table
                        if (objEntityMail.User_Id == 0)
                        {
                            cmdAddMail.Parameters.Add("M_MAILACTION", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddMail.Parameters.Add("M_MAILACTION", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.Mail_Actions.User_New);

                        }
                        cmdAddMail.Parameters.Add("M_RECEIVEDATE", OracleDbType.Date).Value = objEntityMail.Email_Receive_Date;
                        cmdAddMail.Parameters.Add("M_TRANSID", OracleDbType.Int32).Value = objEntityMail.Transaction_Id;
                        // status 0 from unread mails, so intially it is unread
                        cmdAddMail.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = 0;
                        cmdAddMail.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                        cmdAddMail.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                        cmdAddMail.Parameters.Add("M_UNIQUEID", OracleDbType.Varchar2).Value = objEntityMail.Email_Unique_Id;
                        if (objEntityMail.User_Id == 0)
                        {
                            cmdAddMail.Parameters.Add("M_ALLOCATE_USRID", OracleDbType.Int32).Value = null;
                        }
                        else
                        {
                            cmdAddMail.Parameters.Add("M_ALLOCATE_USRID", OracleDbType.Int32).Value = objEntityMail.User_Id;

                        }
                        cmdAddMail.Parameters.Add("M_MLBOX_MESSAGE_ID", OracleDbType.Varchar2).Value = objEntityMail.MessageID;

                        cmdAddMail.ExecuteNonQuery();
                    }

                    //insert email attachment to the email attachment table
                    foreach (clsEntityMailAttachment objAttach in objEntityMailAttList)
                    {
                        string strQueryInsertAttachment = "MAIL.SP_INSERT_MAIL_ATTACHMENTS";
                        using (OracleCommand cmdAddInsertAttachment = new OracleCommand(strQueryInsertAttachment, con))
                            {
                                cmdAddInsertAttachment.Transaction = tran;

                                cmdAddInsertAttachment.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertAttachment.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                                cmdAddInsertAttachment.Parameters.Add("M_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                                cmdAddInsertAttachment.Parameters.Add("M_ATTCHFILE", OracleDbType.Varchar2).Value = objAttach.Email_File_Name;
                                cmdAddInsertAttachment.Parameters.Add("M_FILENAME", OracleDbType.Varchar2).Value = objAttach.Email_Real_Name;

                                cmdAddInsertAttachment.ExecuteNonQuery();
                            }

                    }

                    tran.Commit();

                    //if any mail came as reply of any lead then it get auto allocate to leads's user
                    if (objEntityMail.Auto_Attach == 1)
                    {
                        AllocateMail(objEntityMail);
                    }

                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }
        }

        
        //fetch mail storage details from mail storage table
        public DataTable ReadMailStorage()
        {
            string strCommandText = "MAIL.SP_READ_MAIL_STORAGE";
            using (OracleCommand cmdMailStorage = new OracleCommand())
            {
                cmdMailStorage.CommandText = strCommandText;
                cmdMailStorage.CommandType = CommandType.StoredProcedure;
                cmdMailStorage.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtStorage = new DataTable();
                dtStorage = clsDataLayer.SelectDataTable(cmdMailStorage);
                return dtStorage;

            }
        }


        //fetch mail attachments based on mail id
        public DataTable Read_Mail_Attachments(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_READ_ATTACHMENT_BYID";
            using (OracleCommand cmdReadAttach = new OracleCommand())
            {
                cmdReadAttach.CommandText = strCommandText;
                cmdReadAttach.CommandType = CommandType.StoredProcedure;
                cmdReadAttach.Parameters.Add("M_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdReadAttach.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtAttach = new DataTable();
                dtAttach = clsDataLayer.SelectDataTable(cmdReadAttach);
                return dtAttach;

            }
        }


        //load customer details to the customer drop down list
        public DataTable ReadCustomers(clsEntityMailConsole objEntityMail)
        {
            string strQueryReadCust = "MAIL.SP_READ_CUSTOMERS";
            using (OracleCommand cmdReadCustomer = new OracleCommand())
            {
                cmdReadCustomer.CommandText = strQueryReadCust;
                cmdReadCustomer.CommandType = CommandType.StoredProcedure;
                cmdReadCustomer.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                cmdReadCustomer.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                cmdReadCustomer.Parameters.Add("L_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadCustomer);
                return dtReadCust;
            }
        }


        //fetch the leads detailos based on date period and user and customer details
        public DataTable SearchLeads(clsEntityMailConsole objEntityMail)
        {
            string strQueryReadCust = "MAIL.SP_SEARCH_LEADS";
            using (OracleCommand cmdReadCustomer = new OracleCommand())
            {
                cmdReadCustomer.CommandText = strQueryReadCust;
                cmdReadCustomer.CommandType = CommandType.StoredProcedure;
                cmdReadCustomer.Parameters.Add("M_FROMDATE", OracleDbType.Varchar2).Value = objEntityMail.From_Date;
                cmdReadCustomer.Parameters.Add("M_TODATE", OracleDbType.Varchar2).Value = objEntityMail.To_Date;
                cmdReadCustomer.Parameters.Add("M_CUSTOMERID", OracleDbType.Int32).Value = objEntityMail.Customer_Id;               
                cmdReadCustomer.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                cmdReadCustomer.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                cmdReadCustomer.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                cmdReadCustomer.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadCust = new DataTable();
                dtReadCust = clsDataLayer.SelectDataTable(cmdReadCustomer);
                return dtReadCust;
            }
        }


        //attach a mail to a lead
        public void MailLeadAttach(clsEntityMailConsole objEntityMail)
        {
            string strQueryMailAttach = "MAIL.SP_MAIL_LEAD_ATTACH";
            using (OracleCommand cmdMailAttach = new OracleCommand())
            {
                cmdMailAttach.CommandText = strQueryMailAttach;
                cmdMailAttach.CommandType = CommandType.StoredProcedure;
                cmdMailAttach.Parameters.Add("M_ID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdMailAttach.Parameters.Add("M_LEADID", OracleDbType.Int64).Value = objEntityMail.Lead_Id;
                cmdMailAttach.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityMail.User_Id;
                cmdMailAttach.Parameters.Add("M_DATE", OracleDbType.Date).Value = System.DateTime.Now;
                cmdMailAttach.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtMailAttach = new DataTable();
                dtMailAttach = clsDataLayer.SelectDataTable(cmdMailAttach);

                if (dtMailAttach.Rows.Count > 0)
                {
                   
                    string strFromMail = dtMailAttach.Rows[0]["MLBOX_FROM_MAIL"].ToString();
                    try
                    {
                        string[] Array = new string[2];
                        Array = strFromMail.Split('<');
                        strFromMail = Array[1].TrimEnd('>');
                    }
                    catch
                    {
                        
                    }
                    objEntityMail.Email_Subject = dtMailAttach.Rows[0]["MLBOX_SUBJECT"].ToString();
                    objEntityMail.From_Email_Address = strFromMail;
                    objEntityMail.To_Email_Address = dtMailAttach.Rows[0]["MLBOX_TO_MAIL"].ToString();
                    objEntityMail.D_Date = Convert.ToDateTime(dtMailAttach.Rows[0]["MAIL_RECEIVED_DATE"]);
                    if (dtMailAttach.Rows[0]["MLBOX_CONTENT"] != DBNull.Value)
                    {
                        objEntityMail.Email_Content = dtMailAttach.Rows[0]["MLBOX_CONTENT"].ToString();
                    }

                    List<clsEntityMailAttachment> objEntityAttList = new List<clsEntityMailAttachment>();
                    for (int intRowCount = 0; intRowCount < dtMailAttach.Rows.Count; intRowCount++)
                    {
                        clsEntityMailAttachment objEntityAttach = new clsEntityMailAttachment();
                        if (dtMailAttach.Rows[intRowCount]["MLBXATCH_FLNAME"] != DBNull.Value)
                        {
                            objEntityAttach.Email_File_Name = dtMailAttach.Rows[intRowCount]["MLBXATCH_FLNAME"].ToString();
                            objEntityAttach.Email_Real_Name = dtMailAttach.Rows[intRowCount]["MLBXATCH_ACT_FLNM"].ToString();
                            objEntityAttList.Add(objEntityAttach);
                        }
                    }

                    clsDataLayerLeadIndividual objDataLayerIndividual = new clsDataLayerLeadIndividual();
                    clsDataLayer objDataLayer = new clsDataLayer();
                    //means it is a sucess status
                    int intSucessStatus = 1;
                    // 1 means it is a received mail
                    int intMailStatus = 1;

                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAD_MAIL);
                    objEntityCommon.CorporateID = objEntityMail.Corporate_Id;                    
                    string strNextNum = objDataLayer.ReadNextNumberWebForUI(objEntityCommon);
                    objEntityMail.LeadMailId = Convert.ToInt64(strNextNum);

                    List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                    List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                    objDataLayerIndividual.InsertLeadMail(objEntityMail, objEntityAttList, objEntityMailCcBCcList,objEntityToMailAddressList, intSucessStatus, intMailStatus);

                }



            }
        }

        //read the current status about a mail based on mail id
        public DataTable Read_Mail_Sts(clsEntityMailConsole objEntityMail)
        {
            string strQueryReadMailSts = "MAIL.SP_READ_MAIL_CURRENT_STS";
            using (OracleCommand cmdReadMailSts = new OracleCommand())
            {
                cmdReadMailSts.CommandText = strQueryReadMailSts;
                cmdReadMailSts.CommandType = CommandType.StoredProcedure;
                cmdReadMailSts.Parameters.Add("M_MAILID", OracleDbType.Int64).Value = objEntityMail.Mail_Box_Id;
                cmdReadMailSts.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadMailSts = new DataTable();
                dtReadMailSts = clsDataLayer.SelectDataTable(cmdReadMailSts);
                return dtReadMailSts;
            }
        }


        //read the details aboput the lead based on the lead ref number
        public DataTable Read_Lead_By_Ref(clsEntityLeadCreation objEntityLead)
        {
            string strQueryReadLead = "MAIL.SP_READ_LEAD_BY_REF";
            using (OracleCommand cmdReadLead = new OracleCommand())
            {
                cmdReadLead.CommandText = strQueryReadLead;
                cmdReadLead.CommandType = CommandType.StoredProcedure;
                cmdReadLead.Parameters.Add("M_REF", OracleDbType.Int64).Value = objEntityLead.Ref_Id;
                cmdReadLead.Parameters.Add("M_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadLead = new DataTable();
                dtReadLead = clsDataLayer.SelectDataTable(cmdReadLead);
                return dtReadLead;
            }
        }

        //TO UPDATE LIMIT EMAIL DATE  TO PREVIOUS DATE IF READED
        public void Update_EmailLimitDate(clsEntityMailConsole objEntityMail)
        {
            string strCommandText = "MAIL.SP_UPD_MLCONFIG_EML_LIMIT_DATE";
            using (OracleCommand cmdUpdEmlLimitDate = new OracleCommand())
            {
                cmdUpdEmlLimitDate.CommandText = strCommandText;
                cmdUpdEmlLimitDate.CommandType = CommandType.StoredProcedure;
                cmdUpdEmlLimitDate.Parameters.Add("M_EMAIL", OracleDbType.Varchar2).Value = objEntityMail.Email_Address;
                cmdUpdEmlLimitDate.Parameters.Add("M_CORPID", OracleDbType.Int32).Value = objEntityMail.Corporate_Id;
                cmdUpdEmlLimitDate.Parameters.Add("M_ORGID", OracleDbType.Int32).Value = objEntityMail.Organisation_Id;
                cmdUpdEmlLimitDate.Parameters.Add("M_LMT_DATE", OracleDbType.Date).Value = objEntityMail.EmailLimitDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdEmlLimitDate);
            }
        }


        //Start:-EMP-0009
        public DataTable ReadPushReason()
        {
            string strCommandText = "MAIL.SP_READ_PUSH_REASN";
            using (OracleCommand cmdComp = new OracleCommand())
            {
                cmdComp.CommandText = strCommandText;
                cmdComp.CommandType = CommandType.StoredProcedure;
                cmdComp.Parameters.Add("D_COMPANY_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCompDisp = new DataTable();
                dtCompDisp = clsDataLayer.SelectDataTable(cmdComp);
                return dtCompDisp;
            }
        }
        //End:-EMP-0009

    }
}
