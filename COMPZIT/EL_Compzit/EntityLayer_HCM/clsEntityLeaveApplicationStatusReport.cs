using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLeaveApplicationStatusReport
    {
        private DateTime dFromDate;
        private DateTime dTodate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private string intStatus = "";
        private string intDepartmentId = "";
        private string intLeaveTypeId = "";
        private string intDivisionId = "";
        private int intCategoryId = 0;
        private string intJobId = "";
        private int intReportTypeId = 0;
        private int intSummaryTypeId = 0;
        private int intSummaryTypeIdInd = 0;
        private string strQueryColumns = "";
        public string QueryColumns
        {
            get
            {
                return strQueryColumns;
            }
            set
            {
                strQueryColumns = value;
            }
        }

        public int SummaryTypeIdInd
        {
            get
            {
                return intSummaryTypeIdInd;
            }
            set
            {
                intSummaryTypeIdInd = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        public DateTime Todate
        {
            get
            {
                return dTodate;
            }
            set
            {
                dTodate = value;
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
        public string Status
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
        public string DepartmentId
        {
            get
            {
                return intDepartmentId;
            }
            set
            {
                intDepartmentId = value;
            }
        }
        public string LeaveTypeId
        {
            get
            {
                return intLeaveTypeId;
            }
            set
            {
                intLeaveTypeId = value;
            }
        }
        public string DivisionId
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
        public int CategoryId
        {
            get
            {
                return intCategoryId;
            }
            set
            {
                intCategoryId = value;
            }
        }
        public string JobId
        {
            get
            {
                return intJobId;
            }
            set
            {
                intJobId = value;
            }
        }
        public int ReportTypeId
        {
            get
            {
                return intReportTypeId;
            }
            set
            {
                intReportTypeId = value;
            }
        }
        public int SummaryTypeId
        {
            get
            {
                return intSummaryTypeId;
            }
            set
            {
                intSummaryTypeId = value;
            }
        }
    }
}
