using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityMonthlySalaryStatement
    {
        private decimal intBasicPay = 0;
        private int intPendFinshId = 0;
        private int intSalaryPrssId = 0;
        private int intSavConf = 0;
        private int intPaidFinish = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intYear = 0;
        private int intMonth = 0;
        private int intTypeStffWrkr = 0;
        private int intCorpID = 0;
        private int intEmployee = 0;

        private DateTime ddate = new DateTime();
        private DateTime dCurrentDate = new DateTime();

        private int intMode = 0;
        private string strMonths = "";
        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
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
        public decimal BasicPay
        {
            get
            {
                return intBasicPay;
            }
            set
            {
                intBasicPay = value;
            }
        }

        public int PendFinshId
        {
            get
            {
                return intPendFinshId;
            }
            set
            {
                intPendFinshId = value;
            }
        }
        public int SalaryPrssId
        {
            get
            {
                return intSalaryPrssId;
            }
            set
            {
                intSalaryPrssId = value;
            }
        }
        public int SavConf
        {
            get
            {
                return intSavConf;
            }
            set
            {
                intSavConf = value;
            }
        }
        public int PaidFinish
        {
            get
            {
                return intPaidFinish;
            }
            set
            {
                intPaidFinish = value;
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                return dCurrentDate;
            }
            set
            {
                dCurrentDate = value;
            }
        }

        public DateTime date
        {
            get
            {
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }



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



        public int StffWrkr
        {
            get
            {
                return intTypeStffWrkr;
            }
            set
            {
                intTypeStffWrkr = value;
            }
        }
        public int Month
        {
            get
            {
                return intMonth;
            }
            set
            {
                intMonth = value;
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
        public int Orgid
        {
            get
            {
                return intOrgid;
            }
            set
            {
                intOrgid = value;
            }
        }
        public int CorpOffice
        {
            get
            {
                return intCorpOffice;
            }
            set
            {
                intCorpOffice = value;
            }
        }
        public int CorpID
        {
            get
            {
                return intCorpID;
            }
            set
            {
                intCorpID = value;
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
    }
}

