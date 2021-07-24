using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0003
// CREATED DATE:03/03/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Corporate Division .

namespace EL_Compzit
{
   public class clsEntityCorpDivision
    {
        private int intDivisionId = 0;
        private int intDivStatus;
        private int intInsUserId;
        private DateTime dtInsUserDate;
        private int intUpdUserId;
        private DateTime dtUpdUserDate;
        private int intCanUserId;
        private DateTime dtCanUserDate;
        private string strCancelRsn;
        private string strCorpDivName;
        private string strEmail;
        private string strDivCode;
        private string strDivIcon;
        private int intCorpId;
        private int intOrgId;
        private int intnextId;
        private int intMailSettingsId = 0;
        private string strPassword = null;
        private string strServiceName = null;
        private Int64 intPort = 0;
        private int intCancelStatus = 0;
        private string strMailStoreEmailId = "";
        private int intRemoveMails = 0;


        private string strCommonSearchTerm = "";
        private string strSearchDivision = "";
        private string strSearchCode = "";
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
        public string SearchDivision
        {
            get
            {
                return strSearchDivision;
            }
            set
            {
                strSearchDivision = value;
            }
        }
        public string SearchCode
        {
            get
            {
                return strSearchCode;
            }
            set
            {
                strSearchCode = value;
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

       //methode for store mail storage email id
        public string Mail_Storage_Email
        {
            get
            {
                return strMailStoreEmailId;
            }
            set
            {
                strMailStoreEmailId = value;
            }
        }
       //methode for store status of remove mail store
        public int Remove_Mail_Store
        {
            get
            {
                return intRemoveMails;
            }
            set
            {
                intRemoveMails = value;
            }
        }
        //methode of cancel status storing
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

        
        //method to store the Id of Division
        public int DivisionId
        {
            get 
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }
        //method to store the Id of Division
        public int NextId
        {
            get
            {
                return intnextId;
            }
            set
            {
                intnextId = value;
            }
        }

        //method to store the status of Division-- active 1, inactive - 0
        public int DivStatus
        {
            get
            {
                return intDivStatus;
            }
            set
            {
                intDivStatus = value;
            }
        }

        //method to store the Id of insert user
        public int InsertUsrId
        {
            get
            {
                return intInsUserId;
            }
            set
            {
                intInsUserId = value;
            }
        }

        //method to store the Date of insert user
        public DateTime InsUsrDate
        {
            get
            {
                return dtInsUserDate;
            }
            set
            {
                dtInsUserDate = value;
            }
        }

        //method to store the Id of Update user
        public int UpdateUsrId
        {
            get
            {
                return intUpdUserId;
            }
            set
            {
                intUpdUserId = value;
            }
        }

        //method to store the Date of Update user
        public DateTime UpdUsrDate
        {
            get
            {
                return dtUpdUserDate;
            }
            set
            {
                dtUpdUserDate = value;
            }
        }

        //method to store the Id of Cancel user
        public int CanceltUsrId
        {
            get
            {
                return intCanUserId;
            }
            set
            {
                intCanUserId = value;
            }
        }

        //method to store the Date of Cancel user
        public DateTime CancelUsrDate
        {
            get
            {
                return dtCanUserDate;
            }
            set
            {
                dtCanUserDate = value;
            }
        }

        //method to store the Reason for Canceling
        public string CancelReason
        {
            get
            {
                return strCancelRsn;
            }
            set
            {
                strCancelRsn = value;
            }
        }

        //method to store the Name of Corporate Division
        public string CorpDivisionName
        {
            get
            {
                return strCorpDivName;
            }
            set
            {
                strCorpDivName = value;
            }
        }

        //method to store the Email ID of Corporate Division
        public string EmailId
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

        //method to store the Division Code of Corporate Division
        public string DivisionCode
        {
            get
            {
                return strDivCode;
            }
            set
            {
                strDivCode = value;
            }
        }

        //method to store the Division Icon path of Corporate Division
        public string DivisionIcon
        {
            get
            {
                return strDivIcon;
            }
            set
            {
                strDivIcon = value;
            }
        }

       // method to store corp Id
        public int CorpId
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

       // method to set org id

        public int OrgId
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

       //methode for storing mail settings id
        public int Mail_Settings_Id
        {
            get
            {
                return intMailSettingsId;
            }
            set
            {
                intMailSettingsId = value;
            }
        }

       //methode for storing email password
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

       //methode for storing service name
        public string Service_Name
        {
            get
            {
                return strServiceName;
            }
            set
            {
                strServiceName = value;
            }
        }

       //methode of storing port number
        public Int64 Port_Number
        {
            get
            {
                return intPort;
            }
            set
            {
                intPort = value;
            }
        }
    }



}
