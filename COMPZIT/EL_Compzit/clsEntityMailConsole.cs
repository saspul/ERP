using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:07/04/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the mail console.


namespace EL_Compzit
{
    public class clsEntityMailConsole
    {
        private int intMailConsoleId = 0;
        private string strEmail=null;
        private string strPassword = null;
        private string strInServiceName = null;
        private Int64 intInPort = 0;
        private string strOutServiceName = null;
        private Int64 intOutPort = 0;
        private Int32 intProtocolId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dtDate;
        private string strCancelReason = null;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intSSLStatus = 0;
        private Int64 intMailBoxId = 0;
        private string strFromEmail = null;
        private string strToEmail = null;
        private string strSubject = null;
        private string strContent = null;
        private int intMailStore = 0;
        private int intMailAction = 0;
        private DateTime ReceiveDate;
        private string strMailUniqueId = null;
        private Int32 intTransId = 0;
        private Int64 intLeadMailId = 0;
        private Int64 intLeadid = 0;
        private int intAllMail = 0;
        private int intCustomerId = 0;
        private string strFromdate=null;
        private string strToDate=null;
        private int intAutoAttach = 0;
        private string strSignature = null;
        private int intCancelStatus = 0;
        private DateTime dtEmailLimitDate;

        private string strMessageID="";

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchProtocol = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        public string CommonSearchTerm
        {
            get
            {
                return strCommonSearchTerm;
            }
            set
            {
                strCommonSearchTerm = value;
            }
        }
        public string SearchName
        {
            get
            {
                return strSearchName;
            }
            set
            {
                strSearchName = value;
            }
        }
        public string SearchProtocol
        {
            get
            {
                return strSearchProtocol;
            }
            set
            {
                strSearchProtocol = value;
            }
        }
        public int OrderColumn
        {
            get
            {
                return intOrderColumn;
            }
            set
            {
                intOrderColumn = value;
            }
        }
        public int OrderMethod
        {
            get
            {
                return intOrderMethod;
            }
            set
            {
                intOrderMethod = value;
            }
        }
        public int PageMaxSize
        {
            get
            {
                return intPageMaxSize;
            }
            set
            {
                intPageMaxSize = value;
            }
        }
        public int PageNumber
        {
            get
            {
                return intPageNumber;
            }
            set
            {
                intPageNumber = value;
            }
        }
        //----------------Pageination--------------------

        public string MessageID
        {
            get { return strMessageID; }
            set { strMessageID = value; }
        }


        //methode for mail cancel status
        public int Cancel_Status
        {
            get
            {
                return intCancelStatus;
            }
            set
            {
                intCancelStatus = value;
            }
        }
        //methode of storing the signature
        public string Signature
        {
            get
            {
                return strSignature;
            }
            set
            {
                strSignature = value;
            }
        }

        //methode of store the value decide automatic attach or not
        public int Auto_Attach
        {
            get
            {
                return intAutoAttach;
            }
            set
            {
                intAutoAttach = value;
            }
        }

        //methode for store from date
        public string From_Date
        {
            get
            {
                return strFromdate;
            }
            set
            {
                strFromdate = value;
            }

        }

        //methode of storing to date
        public string To_Date
        {
            get
            {
                return strToDate;
            }
            set
            {
                strToDate = value;
            }
        }

        //method for store customer id
        public int Customer_Id
        {
            get
            {
                return intCustomerId;
            }
            set
            {
                intCustomerId = value;
            }
        }
       
        //methode of storing lead id
        public Int64 Lead_Id
        {
            get
            {
                return intLeadid;
            }
            set
            {
                intLeadid = value;
            }
        }

       //methode of storing mail console id
        public int Mail_Console_Id
        {
            get
            {
                return intMailConsoleId;
            }
            set
            {
                intMailConsoleId = value;
            }
        }
        //methode of storing email address
        public string Email_Address
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
        //methode of storing the password
        public string Password
        {
            get
            {
                return strPassword;
            }
            set
            {
                strPassword = value;
            }
        }
        //methode of storing mail protocol id 
        public int Protocol_Id
        {
            get
            {
                return intProtocolId;
            }
            set
            {
                intProtocolId = value;
            }
        }
        //methode of storing service name for receving mails
        public string In_Service_Name
        {
            get
            {
                return strInServiceName;
            }
            set
            {
                strInServiceName = value;
            }
        }
        //methode of storing port number for receiving mails
        public Int64 In_Port_Number
        {
            get
            {
                return intInPort;
            }
            set
            {
                intInPort = value;
            }
        }
        //methode of storing port number for sending mails
        public Int64 Out_Port_Number
        {
            get
            {
                return intOutPort;
            }
            set
            {
                intOutPort = value;
            }
        }
        //methode of storing service name for sending mails
        public string Out_Service_Name
        {
            get
            {
                return strOutServiceName;
            }
            set
            {
                strOutServiceName = value;
            }
        }
        //methode of storing the status
        public int Console_Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }
        //methode of storing the user id
        public int User_Id
        {
            get
            {
                return intUserId;
            }
            set
            {
                intUserId = value;
            }
        }
        //methode of storing the date
        public DateTime D_Date
        {
            get
            {
                return dtDate;
            }
            set
            {
                dtDate = value;
            }
        }
        //methode of storing the cancel reason
        public string Cancel_Reason
        {
            get
            {
                return strCancelReason;
            }
            set
            {
                strCancelReason = value;
            }
        }
        //methode fo storing organisation id
        public int Organisation_Id
        {
            get
            {
                return intOrgId;
            }
            set
            {
                intOrgId = value;
            }
        }
        //methode of storing corporate id
        public int Corporate_Id
        {
            get
            {
                return intCorpId;
            }
            set
            {
                intCorpId = value;
            }
        }
        //methode of storing SSL (security) status
        public int SSL_Status
        {
            get
            {
                return intSSLStatus;
            }
            set
            {
                intSSLStatus = value;
            }
        }
        //store mailbox id
        public Int64 Mail_Box_Id
        {
            get
            {
                return intMailBoxId;
            }
            set
            {
                intMailBoxId = value;
            }
        }
        //store from email id
        public string From_Email_Address
        {
            get
            {
                return strFromEmail;
            }
            set
            {
                strFromEmail = value;
            }
        }
        //store to email address
        public string To_Email_Address
        {
            get
            {
                return strToEmail;
            }
            set
            {
                strToEmail = value;
            }
        }
        //store email subject
        public string Email_Subject
        {
            get
            {
                return strSubject;
            }
            set
            {
                strSubject = value;
            }
        }
        //store email content
        public string Email_Content
        {
            get
            {
                return strContent;
            }
            set
            {
                strContent = value;
            }
        }
        //store email store id
        public int Email_Store
        {
            get
            {
                return intMailStore;
            }
            set
            {
                intMailStore = value;
            }
        }
        //store email action id
        public int Email_Action
        {
            get
            {
                return intMailAction;
            }
            set
            {
                intMailAction = value;
            }
        }
        //store email receive date
        public DateTime Email_Receive_Date
        {
            get
            {
                return ReceiveDate;
            }
            set
            {
                ReceiveDate = value;
            }
        }
        //store email unique id
        public string Email_Unique_Id
        {
            get
            {
                return strMailUniqueId;
            }
            set
            {
                strMailUniqueId = value;
            }
        }
        //store transaction id that depends division or employee etc.
        public int Transaction_Id
        {
            get
            {
                return intTransId;
            }
            set
            {
                intTransId = value;
            }
        }
        //storing lead mail id
        public Int64 LeadMailId
        {
            get
            {
                return intLeadMailId;
            }
            set
            {
                intLeadMailId = value;
            }
        }
        //this field stores the all mail enable value
        public int All_Mail_Enable
        {
            get
            {
                return intAllMail;
            }
            set
            {
                intAllMail = value;
            }

        }
        //store email Limit date
        public DateTime EmailLimitDate
        {
            get
            {
                return dtEmailLimitDate;
            }
            set
            {
                dtEmailLimitDate = value;
            }
        }


        //Start:-EMP-0009
        private int intReasonId = 0;
        private string strDesc = null;

        //store push to trash reason id
        public int ReasonId
        {
            get
            {
                return intReasonId;
            }
            set
            {
                intReasonId = value;
            }
        }
        //store push to trash description
        public string Desc
        {
            get
            {
                return strDesc;
            }
            set
            {
                strDesc = value;
            }
        }
        //End:-EMP-0009
    }    
    //New class for email attachment
    public class clsEntityMailAttachment
    {
        private string strAttchFileName = null;
        private string strAttchRealName = null;
        private string strAttchPath = null;

        //store email attachment file name
        public string Email_File_Name
        {
            get
            {
                return strAttchFileName;
            }
            set
            {
                strAttchFileName = value;
            }
        }
        //store email attachment real name
        public string Email_Real_Name
        {
            get
            {
                return strAttchRealName;
            }
            set
            {
                strAttchRealName = value;
            }
        }

        //store email attachment real name
        public string Attch_Path
        {
            get
            {
                return strAttchPath;
            }
            set
            {
                strAttchPath = value;
            }
        }       


    }

    public class clsEntityMailCcBCc
    {
        private string strCcMail = "";
        private string strBCcMail = "";

        //store email attachment real name
        public string CcMail
        {
            get
            {
                return strCcMail;
            }
            set
            {
                strCcMail = value;
            }
        }

        public string BCcMail
        {
            get
            {
                return strBCcMail;
            }
            set
            {
                strBCcMail = value;
            }
        }
    }

    public class classEntityToMailAddress
    {
        private string strToAddress = "";
        public string ToAddress
        {
            get
            {
                return strToAddress;
            }
            set
            {
                strToAddress = value;
            }
        }
    }
   
    
}