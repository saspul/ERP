using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class cls_Entity_Bulk_LabourCard_Print
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

        private int intEmpIdFirst = 0;
        private int intEmpIdSecond = 0;
        private int intPrint_Sts = 0;
        private int intMail_Sts = 0;

        public int EmpIdFirst
        {
            get
            {
                return intEmpIdFirst;
            }
            set
            {
                intEmpIdFirst = value;
            }
        }
        public int EmpIdSecond
        {
            get
            {
                return intEmpIdSecond;
            }
            set
            {
                intEmpIdSecond = value;
            }
        }
        public int Print_Sts
        {
            get
            {
                return intPrint_Sts;
            }
            set
            {
                intPrint_Sts = value;
            }
        }
        public int Mail_Sts
        {
            get
            {
                return intMail_Sts;
            }
            set
            {
                intMail_Sts = value;
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
        private int intOT_Hour = 0;
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

        public int OT_Hour
        {
            get
            {
                return intOT_Hour;
            }
            set
            {
                intOT_Hour = value;
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

        private string strMultipleEmpId = "";
        public string MultipleEmpId
        {
            get
            {
                return strMultipleEmpId;
            }
            set
            {
                strMultipleEmpId = value;
            }
        }

        //----------------Pageination--------------------

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchCode = "";
        private string strSearchDesignation = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;

        public string CommonSearchTerm
        {
            get
            {
                return strCommonSearchTerm;
            }
            set
            {
                strCommonSearchTerm = value;
            }
        }
        public string SearchName
        {
            get
            {
                return strSearchName;
            }
            set
            {
                strSearchName = value;
            }
        }
        public string SearchCode
        {
            get
            {
                return strSearchCode;
            }
            set
            {
                strSearchCode = value;
            }
        }
        public string SearchDesignation
        {
            get
            {
                return strSearchDesignation;
            }
            set
            {
                strSearchDesignation = value;
            }
        }

        public int OrderColumn
        {
            get
            {
                return intOrderColumn;
            }
            set
            {
                intOrderColumn = value;
            }
        }
        public int OrderMethod
        {
            get
            {
                return intOrderMethod;
            }
            set
            {
                intOrderMethod = value;
            }
        }
        public int PageMaxSize
        {
            get
            {
                return intPageMaxSize;
            }
            set
            {
                intPageMaxSize = value;
            }
        }
        public int PageNumber
        {
            get
            {
                return intPageNumber;
            }
            set
            {
                intPageNumber = value;
            }
        }
        //----------------Pageination--------------------

    }
}
