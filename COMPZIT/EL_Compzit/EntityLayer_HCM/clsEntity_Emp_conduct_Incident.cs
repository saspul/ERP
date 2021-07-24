using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Emp_conduct_Incident
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intDeptId = -1;
        private int intDivId = -1;
        private int intUsrId = 0;
        private string strRefNo = "";
        private string strDescrptn = "";
        private int intIncType = 0;
        private DateTime dtIncDate;
        private int intseverity = 0;
        private int intmemoIssue = 0;
        private int intCatId = -1;
        private string strcatRsn = "";
        private int intMailNotfy = 0;
        private int intNotify = 0;
        private int intUserId = 0;
        private int intStatus = 0;
        private int intreceive = 0;
        private string strMsg = "";
        private DateTime intInsdate;
        private int intConfirm = 0;
        private int intCndctIndntId = 0;
        private int intAllDivisionChk = 0;
        private int intBussnessUnit = -1;
        private int intdivisionManager = 0;
        private int intEmployee = 0;
        private int intCndctIndntSubId = 0;
        public int Employee
        {
            get
            {
                return intEmployee;
            }
            set
            {
                intEmployee = value;
            }
        }

        public int divisionManager
        {
            get
            {
                return intdivisionManager;
            }
            set
            {
                intdivisionManager = value;
            }
        }
        public int BussnessUnit
        {
            get
            {
                return intBussnessUnit;
            }
            set
            {
                intBussnessUnit = value;
            }
        }
        public int AllDivisionChk
        {
            get
            {
                return intAllDivisionChk;
            }
            set
            {
                intAllDivisionChk = value;
            }
        }
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
        public int DeptId
        {
            get
            {
                return intDeptId;
            }
            set
            {
                intDeptId = value;
            }
        }
        public int DivId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }
        public int UsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        public string REFNo
        {
            get
            {
                return strRefNo;
            }
            set
            {
                strRefNo = value;
            }
        }
        public string IncidentDescripton
        {
            get
            {
                return strDescrptn;
            }
            set
            {
                strDescrptn = value;
            }
        }
        public int IncidentType
        {
            get
            {
                return intIncType;
            }
            set
            {
                intIncType = value;
            }
        }
        public DateTime IncidentDate
        {
            get
            {
                return dtIncDate;
            }
            set
            {
                dtIncDate = value;
            }
        }
        public int Severity
        {
            get
            {
                return intseverity;
            }
            set
            {
                intseverity = value;
            }
        }
        public int MemoIssue
        {
            get
            {
                return intmemoIssue;
            }
            set
            {
                intmemoIssue = value;
            }
        }
        public int CatgoryId
        {
            get
            {
                return intCatId;
            }
            set
            {
                intCatId = value;
            }
        }
        public string CatgoryReson
        {
            get
            {
                return strcatRsn;
            }
            set
            {
                strcatRsn = value;
            }
        }
        public int MailNotify
        {
            get
            {
                return intMailNotfy;
            }
            set
            {
                intMailNotfy = value;
            }
        }
        public int OfficierNotify
        {
            get
            {
                return intNotify;
            }
            set
            {
                intNotify = value;
            }
        }
        public int UserId
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
        public int ReplyExpln
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
        public int RecieveOrNot
        {
            get
            {
                return intreceive;
            }
            set
            {
                intreceive = value;
            }
        }
        public string Message
        {
            get
            {
                return strMsg;
            }
            set
            {
                strMsg = value;
            }
        }
        
          public DateTime InsertDate
        {
            get
            {
                return intInsdate;
            }
            set
            {
                intInsdate = value;
            }
        }
        public int ConfirmId
        {
            get
            {
                return intConfirm;
            }
            set
            {
                intConfirm = value;
            }
        }
        public int ConductIncident_Id
        {
            get
            {
                return intCndctIndntId;
            }
            set
            {
                intCndctIndntId = value;
            }
        }
        public int ConductSubIncident_Id
        {
            get
            {
                return intCndctIndntSubId;
            }
            set
            {
                intCndctIndntSubId = value;
            }
        }
    }
}
