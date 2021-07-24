using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerLeaveSettlmt
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intEmpId = 0;
        private int intLevSettlmtId = 0;
        private double intSettlmtDays = 0;
        private DateTime dRejoinDate;
        private string strRemarks = "";
        private DateTime SettlmtDt;
        private decimal intBasicPay = 0;
        private decimal intAlownce = 0;
        private decimal intDeductn = 0;
        private decimal intTotalPay = 0;
        private decimal intSalaryPerDay = 0;
        private decimal intLevSalary = 0;
        private decimal intPrevMnthSal = 0;
        private decimal intCurrntMnthSal = 0;
        private decimal intTicktAmt = 0;
        private decimal intOtherAmt = 0;
        private decimal intOtherDeductnAmt = 0;
        private decimal intNetAmt = 0;
        private int intConfrmSts = 0;
        private int intCancelSts = 0;
        private string strCancelReasn = "";
        private DateTime dDate;
        private int intPrevMnth = 0;
        private int intYear = 0;
        private int intLeavTypId = 0;
        private int intLeavTypeId = 0;
        private decimal intOvertm = 0;
        private decimal intPaymntDeductn = 0;
        private decimal intBalLeave = 0;
        private decimal intDedctnMess = 0;
        private DateTime dtDateStartDate;
        private DateTime dtDateEndDate;

        private int intLeaveId = 0;
        private int intFixedAloowance = 0;
        private int intMode = 0;
        private DateTime dtDate;
        private decimal decSettlmtDaysDeduct = 0;

        private decimal decLeaveArrearAmnt = 0;

        private decimal decPrevAdditionAmnt = 0;
        private decimal decPrevOvertimeAmnt = 0;
        private decimal decLPrevArrearAmnt = 0;
        private decimal decPrevDeductionAmnt = 0;
        private decimal decPrevPaymntDedAmnt = 0;
        private decimal decPrevMessDedAmnt = 0;

        private DateTime dtFromDate;
        private DateTime dtToDate;


        private DateTime dtPrevMntRejoinDate;
        private decimal decPrevMnthArrAmt= 0;
        public DateTime PrevMntRejoinDate
        {
            get
            {
                return dtPrevMntRejoinDate;
            }
            set
            {
                dtPrevMntRejoinDate = value;
            }
        }
        public decimal PrevMnthArrAmt
        {
            get
            {
                return decPrevMnthArrAmt;
            }
            set
            {
                decPrevMnthArrAmt = value;
            }
        }



        public DateTime FromDate
        {
            get
            {
                return dtFromDate;
            }
            set
            {
                dtFromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dtToDate;
            }
            set
            {
                dtToDate = value;
            }
        }


        private int intMonth = 0;
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



        private decimal decPrevOtherAddAmnt = 0;
        public decimal PrevOtherAddAmnt
        {
            get
            {
                return decPrevOtherAddAmnt;
            }
            set
            {
                decPrevOtherAddAmnt = value;
            }
        }
        private decimal decPrevOtherDedAmnt = 0;
        public decimal PrevOtherDedAmnt
        {
            get
            {
                return decPrevOtherDedAmnt;
            }
            set
            {
                decPrevOtherDedAmnt = value;
            }
        }

        public decimal PrevAdditionAmnt
        {
            get
            {
                return decPrevAdditionAmnt;
            }
            set
            {
                decPrevAdditionAmnt = value;
            }
        }
        public decimal PrevOvertimeAmnt
        {
            get
            {
                return decPrevOvertimeAmnt;
            }
            set
            {
                decPrevOvertimeAmnt = value;
            }
        }
        public decimal PrevArrearAmnt
        {
            get
            {
                return decLPrevArrearAmnt;
            }
            set
            {
                decLPrevArrearAmnt = value;
            }
        }
        public decimal PrevDeductionAmnt
        {
            get
            {
                return decPrevDeductionAmnt;
            }
            set
            {
                decPrevDeductionAmnt = value;
            }
        }
        public decimal PrevPaymntDedAmnt
        {
            get
            {
                return decPrevPaymntDedAmnt;
            }
            set
            {
                decPrevPaymntDedAmnt = value;
            }
        }
        public decimal PrevMessDedAmnt
        {
            get
            {
                return decPrevMessDedAmnt;
            }
            set
            {
                decPrevMessDedAmnt = value;
            }
        }


        public decimal LeaveArrearAmnt
        {
            get
            {
                return decLeaveArrearAmnt;
            }
            set
            {
                decLeaveArrearAmnt = value;
            }
        }



        private decimal decOpenElgibleDays = 0;
        private decimal decOpenLeaveSalary = 0;
        public decimal OpenElgibleDays
        {
            get
            {
                return decOpenElgibleDays;
            }
            set
            {
                decOpenElgibleDays = value;
            }
        }
        public decimal OpenLeaveSalary
        {
            get
            {
                return decOpenLeaveSalary;
            }
            set
            {
                decOpenLeaveSalary = value;
            }
        }






        public decimal SettlmtDaysDeduct
        {
            get
            {
                return decSettlmtDaysDeduct;
            }
            set
            {
                decSettlmtDaysDeduct = value;
            }
        }
        public DateTime DateSettle
        {
            get
            {
                return dtDate;
            }
            set
            {
                dtDate = value;
            }
        }
        public Decimal BalanceLeave
        {
            get
            {
                return intBalLeave;
            }
            set
            {
                intBalLeave = value;
            }
        }
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
        public int FixedAllowance
        {
            get
            {
                return intFixedAloowance;
            }
            set
            {
                intFixedAloowance = value;
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
        public decimal DedctnMess
        {
            get
            {
                return intDedctnMess;
            }
            set
            {
                intDedctnMess = value;
            }
        }
        public decimal Overtm
        {
            get
            {
                return intOvertm;
            }
            set
            {
                intOvertm = value;
            }
        }
        public decimal PaymntDeductn
        {
            get
            {
                return intPaymntDeductn;
            }
            set
            {
                intPaymntDeductn = value;
            }
        }

        public int LeaveTypId
        {
            get
            {
                return intLeavTypId;
            }
            set
            {
                intLeavTypId = value;
            }
        }
        public int LeaveTypeId
        {
            get
            {
                return intLeavTypeId;
            }
            set
            {
                intLeavTypeId = value;
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

        public int EmployeeId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }

        public int LeaveSettlmtId
        {
            get
            {
                return intLevSettlmtId;
            }
            set
            {
                intLevSettlmtId = value;
            }
        }

        public double SettlmtDays
        {
            get
            {
                return intSettlmtDays;
            }
            set
            {
                intSettlmtDays = value;
            }
        }

        public DateTime RejoinDate
        {
            get
            {
                return dRejoinDate;
            }
            set
            {
                dRejoinDate = value;
            }
        }

        public string Remarks
        {
            get
            {
                return strRemarks;
            }
            set
            {
                strRemarks = value;
            }
        }

        public DateTime SettlmtDate
        {
            get
            {
                return SettlmtDt;
            }
            set
            {
                SettlmtDt = value;
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

        public decimal Allowance
        {
            get
            {
                return intAlownce;
            }
            set
            {
                intAlownce = value;
            }
        }

        public decimal Deduction
        {
            get
            {
                return intDeductn;
            }
            set
            {
                intDeductn = value;
            }
        }

        public decimal TotalPay
        {
            get
            {
                return intTotalPay;
            }
            set
            {
                intTotalPay = value;
            }
        }

        public decimal SalaryPerDay
        {
            get
            {
                return intSalaryPerDay;
            }
            set
            {
                intSalaryPerDay = value;
            }
        }

        public decimal LeaveSalary
        {
            get
            {
                return intLevSalary;
            }
            set
            {
                intLevSalary = value;
            }
        }

        public decimal PrevMnthSalary
        {
            get
            {
                return intPrevMnthSal;
            }
            set
            {
                intPrevMnthSal = value;
            }
        }

        public decimal CurrentMnthSalary
        {
            get
            {
                return intCurrntMnthSal;
            }
            set
            {
                intCurrntMnthSal = value;
            }
        }

        public decimal TicktAmt
        {
            get
            {
                return intTicktAmt;
            }
            set
            {
                intTicktAmt = value;
            }
        }

        public decimal OtherAmt
        {
            get
            {
                return intOtherAmt;
            }
            set
            {
                intOtherAmt = value;
            }
        }

        public decimal OtherDeductionAmt
        {
            get
            {
                return intOtherDeductnAmt;
            }
            set
            {
                intOtherDeductnAmt = value;
            }
        }

        public decimal NetAmount
        {
            get
            {
                return intNetAmt;
            }
            set
            {
                intNetAmt = value;
            }
        }

        public int ConfrmStatus
        {
            get
            {
                return intConfrmSts;
            }
            set
            {
                intConfrmSts = value;
            }
        }

        public int CancelStatus
        {
            get
            {
                return intCancelSts;
            }
            set
            {
                intCancelSts = value;
            }
        }
        public string CnclReason
        {
            get
            {
                return strCancelReasn;
            }
            set
            {
                strCancelReasn = value;
            }
        }

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
        public int PrevMnth
        {
            get
            {
                return intPrevMnth;
            }
            set
            {
                intPrevMnth = value;
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



    }
}
