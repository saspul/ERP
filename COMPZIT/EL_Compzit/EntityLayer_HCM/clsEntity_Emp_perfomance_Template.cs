using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public  class clsEntity_Emp_perfomance_Template
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private string strRefNo = "";
        private string strprfmncForm = "";
        private string strprfmncNote = "";
        private int intRating = 0;
        private int intStatus = 0;
        private int intcnclStatus = 0;
        private int intPerfomanceId = 0;
        private string strCnclRsn = "";
        private int intActStatus = 0;


        private int intGrpId = 0;
        private string intGrpName = "";
        private int intQstnId = 0;
        private string intQstnText = "";
        private int intRateSclaeId = 0;
        private string strKpiText = "";

        private string strEventText = "";


        public string EventText
        {
            get
            {
                return strEventText;
            }
            set
            {
                strEventText = value;
            }
        }
        public string KpiText
        {
            get
            {
                return strKpiText;
            }
            set
            {
                strKpiText = value;
            }
        }

        public int RateSclaeId
        {
            get
            {
                return intRateSclaeId;
            }
            set
            {
                intRateSclaeId = value;
            }
        }
        public string QstnText
        {
            get
            {
                return intQstnText;
            }
            set
            {
                intQstnText = value;
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
        public string GrpName
        {
            get
            {
                return intGrpName;
            }
            set
            {
                intGrpName = value;
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
