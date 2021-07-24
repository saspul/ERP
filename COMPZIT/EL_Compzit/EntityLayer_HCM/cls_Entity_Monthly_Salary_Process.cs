using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class cls_Entity_Monthly_Salary_Process
    {
        private decimal intSpecialAllAmnt = 0;
        private decimal intAllowOverTmAmnt = 0;
        private decimal intSpecialDedAmnt = 0;
        private decimal intInstalAmount = 0;
        private decimal intNumLeav = 0;
        private decimal intBasicPay = 0;
        private decimal intArrerMount = 0;
        private decimal intTotMount = 0;
        private decimal intPaidMount = 0;
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
        private int intDivision = 0;
        private int intDep = 0;
        private int intEmployee = 0;
        private int intDesg = 0;
        private int intLeaveId = 0;
        private decimal intMessAmnt = 0;
        private decimal intOtherAdditionAmt = 0;
        private decimal decPrevMnthArreAmt = 0;
        private int intPaymentType = 0;


        public int PaymentType
        {
            get
            {
                return intPaymentType;
            }
            set
            {
                intPaymentType = value;
            }
        }
        public decimal PrevMnthArreAmt
        {
            get
            {
                return decPrevMnthArreAmt;
            }
            set
            {
                decPrevMnthArreAmt = value;
            }
        }
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

        public decimal OtherAdditionAmt
        {
            get
            {
                return intOtherAdditionAmt;
            }
            set
            {
                intOtherAdditionAmt = value;
            }
        }

        private decimal intOtherDeductionAmt = 0;
        public decimal OtherDeductionAmt
        {
            get
            {
                return intOtherDeductionAmt;
            }
            set
            {
                intOtherDeductionAmt = value;
            }
        }



        private int intManualAddDedId = 0;
        public int ManualAddDedId
        {
            get
            {
                return intManualAddDedId;
            }
            set
            {
                intManualAddDedId = value;
            }
        }

        private int intPayrlMode = 0;
        public int PayrlMode
        {
            get
            {
                return intPayrlMode;
            }
            set
            {
                intPayrlMode = value;
            }
        }






        private decimal decBasic_Allwnc_Amt = 0;
        public decimal Basic_Allwnc_Amt
        {
            get
            {
                return decBasic_Allwnc_Amt;
            }
            set
            {
                decBasic_Allwnc_Amt = value;
            }
        }

        //EVM-0027

        private decimal decProsBasicPay = 0;
        public decimal ProcessedBasicPay
        {
            get
            {
                return decProsBasicPay;
            }
            set
            {
                decProsBasicPay = value;
            }
        }
        private decimal decProsAllwnAmt = 0;
        public decimal ProcessedAllwncAmt
        {
            get
            {
                return decProsAllwnAmt;
            }
            set
            {
                decProsAllwnAmt = value;
            }
        }
        private decimal decProsDedtnAmt = 0;
        public decimal ProcessedDedtnAmt
        {
            get
            {
                return decProsDedtnAmt;
            }
            set
            {
                decProsDedtnAmt = value;
            }
        }
        private int intProcessAlwncID = 0;
        public int ProcessAllwnceID
        {
            get
            {
                return intProcessAlwncID;
            }
            set
            {
                intProcessAlwncID = value;
            }
        }
        private int intProcessDedtnID = 0;
        public int ProcessDeductneID
        {
            get
            {
                return intProcessDedtnID;
            }
            set
            {
                intProcessDedtnID = value;
            }
        }
        private int intPayGradeID = 0;
        public int PayGradeID
        {
            get
            {
                return intPayGradeID;
            }
            set
            {
                intPayGradeID = value;
            }
        }

        //END

        private decimal decLvArrearAmnt = 0;
        public decimal LvArrearAmnt
        {
            get
            {
                return decLvArrearAmnt;
            }
            set
            {
                decLvArrearAmnt = value;
            }
        }



        private DateTime ddate = new DateTime();
        private DateTime dCurrentDate = new DateTime();
        private DateTime dtDateStartDate;
        private DateTime dtDateEndDate;

        public int LeaveId
        {
            get
            {
                return intLeaveId;
            }
            set
            {
                intLeaveId = value;
            }
        }
        public DateTime DateStartDate
        {
            get
            {
                return dtDateStartDate;
            }
            set
            {
                dtDateStartDate = value;
            }
        }
        public DateTime DateEndDate
        {
            get
            {
                return dtDateEndDate;
            }
            set
            {
                dtDateEndDate = value;
            }
        }


        public decimal MessAmnt
        {
            get
            {
                return intMessAmnt;
            }
            set
            {
                intMessAmnt = value;
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
        public decimal NumLeav
        {
            get
            {
                return intNumLeav;
            }
            set
            {
                intNumLeav = value;
            }
        }

        public decimal SpecialAllAmnt
        {
            get
            {
                return intSpecialAllAmnt;
            }
            set
            {
                intSpecialAllAmnt = value;
            }
        }
        public decimal AllowOverTmAmnt
        {
            get
            {
                return intAllowOverTmAmnt;
            }
            set
            {
                intAllowOverTmAmnt = value;
            }
        }
        public decimal SpecialDedAmnt
        {
            get
            {
                return intSpecialDedAmnt;
            }
            set
            {
                intSpecialDedAmnt = value;
            }
        }

        public decimal InstalAmount
        {
            get
            {
                return intInstalAmount;
            }
            set
            {
                intInstalAmount = value;
            }
        }
        public decimal ArrerMount
        {
            get
            {
                return intArrerMount;
            }
            set
            {
                intArrerMount = value;
            }
        }
             public decimal PaidMount
        {
            get
            {
                return intPaidMount;
            }
            set
            {
                intPaidMount = value;
            }
        }
      
        public decimal TotMount
        {
            get
            {
                return intTotMount;
            }
            set
            {
                intTotMount = value;
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

        public int Desg
        {
            get
            {
                return intDesg;
            }
            set
            {
                intDesg = value;
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

        public int Dep
        {
            get
            {
                return intDep;
            }
            set
            {
                intDep = value;
            }
        }
        public int Division
        {
            get
            {
                return intDivision;
            }
            set
            {
                intDivision = value;
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

        private DateTime dMonthYearDate = new DateTime();
        private decimal decOT_Hour = 0;
        private decimal intTotalCost = 0;
        private int intNumOfDays = 0;
        private decimal intTotalOTamt = 0;
        private int intProjectId = 0;

        public int ProjectId
        {
            get
            {
                return intProjectId;
            }
            set
            {
                intProjectId = value;
            }
        }

        public decimal TotalOTamt
        {
            get
            {
                return intTotalOTamt;
            }
            set
            {
                intTotalOTamt = value;
            }
        }

        public int NumOfDays
        {
            get
            {
                return intNumOfDays;
            }
            set
            {
                intNumOfDays = value;
            }
        }
        public decimal TotalCost
        {
            get
            {
                return intTotalCost;
            }
            set
            {
                intTotalCost = value;
            }
        }

        public decimal OT_Hour
        {
            get
            {
                return decOT_Hour;
            }
            set
            {
                decOT_Hour = value;
            }
        }
        public DateTime MonthYearDate
        {
            get
            {
                return dMonthYearDate;
            }
            set
            {
                dMonthYearDate = value;
            }
        }
    }
}
