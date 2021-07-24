using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
    public class clsEntityLayerTimeSheetReport
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate=DateTime.MinValue;
        private DateTime dFromDate = DateTime.MinValue;
        private DateTime dToDate = DateTime.MinValue;
        private int intEmployeeId = 0;
        private int intQuarter = 0;
        private int intDivisionId = 0;
        private int intDepartmentId = 0;
        private string strMonth = "";
        private int intYear = 0;
        private int intYearCommon = 0;
        public int YearCommon
        {
            get
            {
                return intYearCommon;
            }
            set
            {
                intYearCommon = value;
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
        public int DepartmentId
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
        public int Quarter
        {
            get
            {
                return intQuarter;
            }
            set
            {
                intQuarter = value;
            }
        }
        //methode of storing from date
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        //methode of storing from date
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
        //methode of storing employee id
        public int EmployeeId
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
       
        //methode of organisation id storing
        public int Organisation_id
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
        //methode of corporate id storing
        public int Corporate_id
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

        //methode of user id storing
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
        //methode of status id storing
        public int Status_id
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

        //methode of storing date of the entry
        public DateTime Date
        {
            get
            {
                return dDate;
            }
            set
            {
                dDate = value;
            }
        }

      
    }
}
