using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public  class clsEntityAttendanceReport
    {
        private int intUserId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private string strMonth="";
        private string strYear = "";
        private int intDeptID = 0;
        private int intDivId = 0;
        private int intPrjctId = 0;
        private int intOTtype = 0;
        private DateTime dateFromDate = DateTime.MinValue;

        public DateTime FromDate
        {
            get
            {
                return dateFromDate;
            }
            set
            {
                dateFromDate = value;
            }
        }


        public int OtType
        {
            get
            {
                return intOTtype;
            }
            set
            {
                intOTtype = value;
            }
        }
        public int ProjectId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
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
        public int DepartmentId
        {
            get
            {
                return intDeptID;
            }
            set
            {
                intDeptID = value;
            }
        }
        public string Year
        {
            get
            {
                return strYear;
            }
            set
            {
                strYear = value;
            }
        }
        public string Month
        {
            get
            {
                return strMonth;
            }
            set
            {
                strMonth = value;
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
    }
}
