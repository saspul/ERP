using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class ClsEntity_Performance_Evaluation_Analysis
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private int intEmpUsrId = 0;
        private string strRefNo = "";
        private string strprfmncForm = "";
        private string strprfmncNote = "";
        private int intRating = 0;
        private int intStatus = 0;
        private int intcnclStatus = 0;
        private int intPerfomanceId = 0;
        private string strCnclRsn = "";
        private int intActStatus = 0;
        private DateTime DtfrmDate;
        private DateTime DtToDate;
        private int intRspnTypeId = 0;
        private int intIssueId = 0;
        private int intGrpId = 0;
        private int intRateList = 0;
        private int intRatechk = 0;
        private int intQstnId = 0;
        private string strRateText = "";
        private string strEvlComment = "";
        private int intEvltnId = 0;
        private int intEmpTypId = 0;
        private int intusrDtlId = 0;
        public int usrDtlId
        {
            get
            {
                return intusrDtlId;
            }
            set
            {
                intusrDtlId = value;
            }
        }
        public int EmpTypId
        {
            get
            {
                return intEmpTypId;
            }
            set
            {
                intEmpTypId = value;
            }
        }

        public int EmpUsrId
        {
            get
            {
                return intEmpUsrId;
            }
            set
            {
                intEmpUsrId = value;
            }
        }

        public int EvltnId
        {
            get
            {
                return intEvltnId;
            }
            set
            {
                intEvltnId = value;
            }
        }

        public string EvlComment
        {
            get
            {
                return strEvlComment;
            }
            set
            {
                strEvlComment = value;
            }
        }

        public int QstnId
        {
            get
            {
                return intQstnId;
            }
            set
            {
                intQstnId = value;
            }
        }

        public string RateText
        {
            get
            {
                return strRateText;
            }
            set
            {
                strRateText = value;
            }
        }

        public int Ratechk
        {
            get
            {
                return intRatechk;
            }
            set
            {
                intRatechk = value;
            }
        }

        public int RateList
        {
            get
            {
                return intRateList;
            }
            set
            {
                intRateList = value;
            }
        }
        public int GrpId
        {
            get
            {
                return intGrpId;
            }
            set
            {
                intGrpId = value;
            }
        }

        public int IssueId
        {
            get
            {
                return intIssueId;
            }
            set
            {
                intIssueId = value;
            }
        }
        public int RspnTypeId
        {
            get
            {
                return intRspnTypeId;
            }
            set
            {
                intRspnTypeId = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return DtToDate;
            }
            set
            {
                DtToDate = value;
            }
        }
        public DateTime frmDate
        {
            get
            {
                return DtfrmDate;
            }
            set
            {
                DtfrmDate = value;
            }
        }

        public int ActStatus
        {
            get
            {
                return intActStatus;
            }
            set
            {
                intActStatus = value;
            }
        }
        public int PerfomanceId
        {
            get
            {
                return intPerfomanceId;
            }
            set
            {
                intPerfomanceId = value;
            }
        }
        public int cnclStatus
        {
            get
            {
                return intcnclStatus;
            }
            set
            {
                intcnclStatus = value;
            }
        }
        public int Status
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
        public int Rating
        {
            get
            {
                return intRating;
            }
            set
            {
                intRating = value;
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
        public string CnclRsn
        {
            get
            {
                return strCnclRsn;
            }
            set
            {
                strCnclRsn = value;
            }
        }
        public string prfmncForm
        {
            get
            {
                return strprfmncForm;
            }
            set
            {
                strprfmncForm = value;
            }
        }
        public string prfmncNote
        {
            get
            {
                return strprfmncNote;
            }
            set
            {
                strprfmncNote = value;
            }
        }
       
    }
}
