using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityEmployeeAddDedReport
    {

        private int intCorpId = 0;
        private int intOrgId = 0;
        private string intDepartmentId = "";
        private string intEmployeeId = "";
        private string intDivisionId = "";
        private int intCategoryId = 0;
        private string intJobId = "";
        private int intReportTypeId = 0;
        private int intSummaryTypeId = 0;
        private int intSummaryTypeIdInd = 0;
        private string strQueryColumns = "";
        private int intYear = 0;
        private int intMethod = 0;
        private string strMonths = "";
        private string strDesignation = "";
        private string strAddition = "";
        private string strDeduction = "";
        private string strBAids = "";
        private string strBDids = "";
        private string strMAids = "";
        private string strMDids = "";
        public string BAids
        {
            get
            {
                return strBAids;
            }
            set
            {
                strBAids = value;
            }
        }
        public string BDids
        {
            get
            {
                return strBDids;
            }
            set
            {
                strBDids = value;
            }
        }
        public string MAids
        {
            get
            {
                return strMAids;
            }
            set
            {
                strMAids = value;
            }
        }
        public string MDids
        {
            get
            {
                return strMDids;
            }
            set
            {
                strMDids = value;
            }
        }

        public int Method
        {
            get
            {
                return intMethod;
            }
            set
            {
                intMethod = value;
            }
        }
        public string AdditionIds
        {
            get
            {
                return strAddition;
            }
            set
            {
                strAddition = value;
            }
        }
        public string DeductionIds
        {
            get
            {
                return strDeduction;
            }
            set
            {
                strDeduction = value;
            }
        }

        public string DesignationIds
        {
            get
            {
                return strDesignation;
            }
            set
            {
                strDesignation = value;
            }
        }
        public string Months
        {
            get
            {
                return strMonths;
            }
            set
            {
                strMonths = value;
            }
        }
        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }


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
        public string DepartmentIds
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
        public string EmployeeIds
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        public string DivisionIds
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
        public string JobIds
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
