using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntity_Postdated_Cheque
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private int intPostDatedChequeId = 0;
        private int intTransactionType = 0;
        private string strRefNumber = null;
        private int intLedgerId = 0;
        private DateTime dtPostdatedChequeDate;
        private int intPartyId = 0;
        private string strPayee = null;
        private int intIssueStatus = 0;
        private DateTime dtChequeIssueDate;
        private string strCancelReason = null;
        private int intChequeBookId = 0;
        private int intChequeBookNo = 0;
        private DateTime dtChequeDate;
        private decimal decChequeAmnt = 0;
        private string strRemarks = null;
        private string strDescription = null;
        private int intPaidStatus = 0;
        private decimal decTotalAmnt = 0;
        private int intSequenceRef = 0;
        private int intCurrencyId = 0;
        private int intConfirmStatus = 0;
        private DateTime DtFinStartDate;
        private DateTime DtFinEndDate;
        private DateTime DtUpdChequeDate;
        private string strBank = null;
        private string strIban = null;
        private int intSalesId = 0;
        private int intPurchaseId = 0;
        private int intExpIncmLedgerId = 0;
        private int intMethod = 0;
        private int intFinancialYrId = 0;
        private int intVoucherId = 0;
        private int intVoucherStatus = 0;
        private int intClearanceLedger = 0;
        private int intVoucherClrncId = 0;
        private decimal decSalePurchaseAmnt = 0;
        //0039
        private int intPaymentId = 0;
        private int intPaymentLdgrId = 0;
        //end

        public decimal SalePurchaseAmnt
        {
            get
            {
                return decSalePurchaseAmnt;
            }
            set
            {
                decSalePurchaseAmnt = value;
            }
        }
        public int VoucherClrncId
        {
            get
            {
                return intVoucherClrncId;
            }
            set
            {
                intVoucherClrncId = value;
            }
        }
        public int ClearanceLedger
        {
            get
            {
                return intClearanceLedger;
            }
            set
            {
                intClearanceLedger = value;
            }
        }
        public int VoucherStatus
        {
            get
            {
                return intVoucherStatus;
            }
            set
            {
                intVoucherStatus = value;
            }
        }
        public int VoucherId
        {
            get
            {
                return intVoucherId;
            }
            set
            {
                intVoucherId = value;
            }
        }
        public int FinancialYrId
        {
            get
            {
                return intFinancialYrId;
            }
            set
            {
                intFinancialYrId = value;
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
        public int SalesId
        {
            get
            {
                return intSalesId;
            }
            set
            {
                intSalesId = value;
            }
        }
        public int PurchaseId
        {
            get
            {
                return intPurchaseId;
            }
            set
            {
                intPurchaseId = value;
            }
        }
        public int ExpIncmLedgerId
        {
            get
            {
                return intExpIncmLedgerId;
            }
            set
            {
                intExpIncmLedgerId = value;
            }
        }
        public string Bank
        {
            get
            {
                return strBank;
            }
            set
            {
                strBank = value;
            }
        }
        public string Iban
        {
            get
            {
                return strIban;
            }
            set
            {
                strIban = value;
            }
        }


        public DateTime UpdChequeDate
        {
            get
            {
                return DtUpdChequeDate;
            }
            set
            {
                DtUpdChequeDate = value;
            }
        }
        public int ConfirmStatus
        {
            get
            {
                return intConfirmStatus;
            }
            set
            {
                intConfirmStatus = value;
            }
        }
        public DateTime FiancialStatDate
        {
            get
            {
                return DtFinStartDate;
            }
            set
            {
                DtFinStartDate = value;
            }
        }
        public DateTime FiancialEndDate
        {
            get
            {
                return DtFinEndDate;
            }
            set
            {
                DtFinEndDate = value;
            }
        }
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }
        public int CurrencyId
        {
            get
            {
                return intCurrencyId;
            }
            set
            {
                intCurrencyId = value;
            }
        }
        public int SequenceRef
        {
            get
            {
                return intSequenceRef;
            }
            set
            {
                intSequenceRef = value;
            }
        }
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
        public int Status
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
        public int PostDatedChequeId
        {
            get
            {
                return intPostDatedChequeId;
            }
            set
            {
                intPostDatedChequeId = value;
            }
        }
        public int TransactionType
        {
            get
            {
                return intTransactionType;
            }
            set
            {
                intTransactionType = value;
            }
        }
        public string RefNumber
        {
            get
            {
                return strRefNumber;
            }
            set
            {
                strRefNumber = value;
            }
        }
        public int LedgerId
        {
            get
            {
                return intLedgerId;
            }
            set
            {
                intLedgerId = value;
            }
        }
        public DateTime PostdatedChequeDate
        {
            get
            {
                return dtPostdatedChequeDate;
            }
            set
            {
                dtPostdatedChequeDate = value;
            }
        }
        public int PartId 
        {
            get
            {
                return intPartyId;
            }
            set
            {
                intPartyId = value;
            }
        }
        public string Payee
        {
            get
            {
                return strPayee;
            }
            set
            {
                strPayee = value;
            }
        }
        public int IssueStatus
        {
            get
            {
                return intIssueStatus;
            }
            set
            {
                intIssueStatus = value;
            }
        }
        public DateTime ChequeIssueDate
        {
            get
            {
                return dtChequeIssueDate;
            }
            set
            {
                dtChequeIssueDate = value;
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
        public int ChequeBookId
        {
            get
            {
                return intChequeBookId;
            }
            set
            {
                intChequeBookId = value;
            }
        }
        public int ChequeBookNo
        {
            get
            {
                return intChequeBookNo;
            }
            set
            {
                intChequeBookNo = value;
            }
        }
        public DateTime ChequeDate
        {
            get
            {
                return dtChequeDate;
            }
            set
            {
                dtChequeDate = value;
            }
        }
        public decimal ChequeAmount
        {
            get
            {
                return decChequeAmnt;
            }
            set
            {
                decChequeAmnt = value;
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
        public int Paid_Status
        {
            get
            {
                return intPaidStatus;
            }
            set
            {
                intPaidStatus = value;
            }
        }
        public decimal TotalAmount
        {
            get
            {
                return decTotalAmnt;
            }
            set
            {
                decTotalAmnt = value;
            }
        }

        //0039
        public int PaymentId
        {
            get
            {
                return intPaymentId;
            }
            set
            {
                intPaymentId = value;
            }
        }

        public int Payment_Ledgr_Id
        {
            get
            {
                return intPaymentLdgrId;
            }
            set
            {
                intPaymentLdgrId = value;
            }
        }
        //end
    }
}
