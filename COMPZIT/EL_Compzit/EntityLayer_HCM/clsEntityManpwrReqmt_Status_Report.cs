using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityManpwrReqmt_Status_Report
    {
        private int intUserId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intManpwrId = 0;
        //Evm-27
        private int intDivId = 0;
        private int intDeptId = 0;
        private int intdegid= 0;
        private int intProj = 0;
        private DateTime DFromDt;
        private DateTime DToDate;
        private int intDegid = 0;
        private int intStatus = 0;
        
        private string strStsChk = "";
        public DateTime FromDt
        {
            get
            {
                return DFromDt;
            }
            set
            {
                DFromDt = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return DToDate;
            }
            set
            {
                DToDate = value;
            }
        }
        public int intDegsid
        {
            get
            {
                return intDegid;
            }
            set
            {
                intDegid = value;
            }
        }
        public int intS
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
        //End
        
        public string StsChk
        {
            get
            {
                return strStsChk;
            }
            set
            {
                strStsChk = value;
            }
        }
        public int intProjid
        {
            get
            {
                return intProj;
            }
            set
            {
                intProj = value;
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
        public int intdesid
        {
            get
            {
                return intdegid;
            }
            set
            {
                intdegid = value;
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

        public int ManPwrId
        {
            get
            {
                return intManpwrId;
            }
            set
            {
                intManpwrId = value;
            }
        }

        public int DivsnId
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




    }
}
