using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerEndOfServiceLeaveStlmnt
    {
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = "";
        private int intCancelStatus = 0;
        private int intServiceLveSttlmntID = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private string strComments = "";
        private int intEmployeeStatus = 0;
        private DateTime dDateReJoin;
        private DateTime dDateOfLeaving=DateTime.MinValue;
        private decimal deciEligibleDaysLveSalary = 0;
        private decimal deciEligibleDaysLveGratuity = 0;
        private decimal decGratuityAmount=0;
        private decimal decLeaveSalary=0;
        private decimal decCurrentMonthSalary=0;
        private decimal decPreviousMonthSalary=0;
        private decimal decOtherAmount=0;
        private decimal decTicketAmount=0;
        private decimal decOtherDeduction=0;
        private decimal decNetAmount=0;
        private decimal deciBacispay=0;
        private decimal deciAddition = 0;
        private decimal deciDeduction = 0;
        private int intConfirmStatus = 0;
        private int intEndSrvLveStlmntID = 0;

        private decimal deciOT_Addition = 0;
        private decimal deciEmpPaymentDeduction = 0;
        private decimal dec_MessAmnt = 0;
        private DateTime dtDateStartDate;
        private DateTime dtDateEndDate;
        private int int_LvCnt = 0;
        private int int_LvId = 0;

        private decimal decPrevOtherAmount = 0;
        private decimal decPrevOtherDeduction = 0;


        private decimal decPrevAdditionAmnt = 0;
        private decimal decPrevOvertimeAmnt = 0;
        private decimal decPrevDeductionAmnt = 0;
        private decimal decPrevPaymntDeduAmnt = 0;
        private decimal decPrevMessAmnt = 0;
        public decimal PrevMessAmnt
        {
            get { return decPrevMessAmnt; }
            set { decPrevMessAmnt = value; }
        }
        public decimal PrevAdditionAmnt
        {
            get { return decPrevAdditionAmnt; }
            set { decPrevAdditionAmnt = value; }
        }
        public decimal PrevOvertimeAmnt
        {
            get { return decPrevOvertimeAmnt; }
            set { decPrevOvertimeAmnt = value; }
        }
        public decimal PrevDeductionAmnt
        {
            get { return decPrevDeductionAmnt; }
            set { decPrevDeductionAmnt = value; }
        }
        public decimal PrevPaymntDedAmnt
        {
            get { return decPrevPaymntDeduAmnt; }
            set { decPrevPaymntDeduAmnt = value; }
        }
        private DateTime dtPrevMntRejoinDate;
        private decimal decPrevMnthArrAmt = 0;
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



        private int int_GrtJoinDateSts = 0;
        public int GrtJoinDateSts
        {
            get { return int_GrtJoinDateSts; }
            set { int_GrtJoinDateSts = value; }
        }

        private decimal decLvArrearAmnt = 0;
        public decimal LvArrearAmnt
        {
            get { return decLvArrearAmnt; }
            set { decLvArrearAmnt = value; }
        }


        private decimal decOpenElgibleDays = 0;
        private decimal decOpenLeaveSalary = 0;
        public decimal OpenElgibleDays
        {
            get { return decOpenElgibleDays; }
            set { decOpenElgibleDays = value; }
        }
        public decimal OpenLeaveSalary
        {
            get { return decOpenLeaveSalary; }
            set { decOpenLeaveSalary = value; }
        }


        public int LeaveId
        {
            get
            {
                return int_LvId;
            }
            set
            {
                int_LvId = value;
            }
        }
        public int LvCnt
        {
            get 
            {
                return int_LvCnt; 
            }
            set {
                int_LvCnt = value; 
            }
        }
        private DateTime dtFromDate;
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
            get { return dec_MessAmnt; }
            set { dec_MessAmnt = value; }
        }
        public decimal EmpPaymentDeduction
        {
            get { return deciEmpPaymentDeduction; }
            set { deciEmpPaymentDeduction = value; }
        }

        public decimal OT_Addition
        {
            get { return deciOT_Addition; }
            set { deciOT_Addition = value; }
        }

        public decimal Deduction
        {
            get { return deciDeduction; }
            set { deciDeduction = value; }
        }

        public decimal Addition
        {
            get { return deciAddition; }
            set { deciAddition = value; }
        }

        public decimal Bacispay
        {
            get { return deciBacispay; }
            set { deciBacispay = value; }
        }


        public int EndSrvLveStlmntID
        {
            get { return intEndSrvLveStlmntID; }
            set { intEndSrvLveStlmntID = value; }
        }
        public int ConfirmStatus
        {
            get { return intConfirmStatus; }
            set { intConfirmStatus = value; }
        }
        private int intEmployeeID=0;

        public int EmployeeID
        {
            get { return intEmployeeID; }
            set { intEmployeeID = value; }
        }

        public decimal LeaveSalary
        {
            get { return decLeaveSalary; }
            set { decLeaveSalary = value; }
        }
        public decimal NetAmount
        {
            get { return decNetAmount; }
            set { decNetAmount = value; }
        }
        public decimal OtherDeduction
        {
            get { return decOtherDeduction; }
            set { decOtherDeduction = value; }
        }
        public decimal TicketAmount
        {
            get { return decTicketAmount; }
            set { decTicketAmount = value; }
        }
        public decimal OtherAmount
        {
            get { return decOtherAmount; }
            set { decOtherAmount = value; }
        }

        public decimal PrevOtherAmount
        {
            get { return decPrevOtherAmount; }
            set { decPrevOtherAmount = value; }
        }

        public decimal PrevOtherDeduction
        {
            get { return decPrevOtherDeduction; }
            set { decPrevOtherDeduction = value; }
        }

        public decimal PreviousMonthSalary
        {
            get { return decPreviousMonthSalary; }
            set { decPreviousMonthSalary = value; }
        }
        public decimal CurrentMonthSalary
        {
            get { return decCurrentMonthSalary; }
            set { decCurrentMonthSalary = value; }
        }
        public decimal GratuityAmount
        {
            get { return decGratuityAmount; }
            set { decGratuityAmount = value; }
        }
        public decimal EligibleDaysLveGratuity
        {
            get { return deciEligibleDaysLveGratuity; }
            set { deciEligibleDaysLveGratuity = value; }
        }
        public decimal EligibleDaysLveSalary
        {
            get { return deciEligibleDaysLveSalary; }
            set { deciEligibleDaysLveSalary = value; }
        }
        public DateTime DateOfLeaving
        {
            get
            {
                return dDateOfLeaving;
            }
            set
            {
                dDateOfLeaving = value;
            }
        }
        public DateTime DateReJoin
        {
            get
            {
                return dDateReJoin;
            }
            set
            {
                dDateReJoin = value;
            }
        }
        public int EmployeeStatus
        {
            get
            {
                return intEmployeeStatus;
            }
            set
            {
                intEmployeeStatus = value;
            }
        }
        public string Comments
        {
            get
            {
                return strComments;
            }
            set
            {
                strComments = value;
            }
        }
        public int ServiceLveSttlmntID
        {
            get
            {
                return intServiceLveSttlmntID;
            }
            set
            {
                intServiceLveSttlmntID = value;
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
        public string CancelReason
        {
            get
            {
                return strCancelReason;
            }
            set
            {
                strCancelReason = value;
            }
        }
        public int CancelStatus
        {
            get
            {
                return intCancelStatus;
            }
            set
            {
                intCancelStatus = value;
            }
        }
    }
}
