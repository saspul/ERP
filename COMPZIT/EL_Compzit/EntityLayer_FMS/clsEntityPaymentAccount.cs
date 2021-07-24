using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityPaymentAccount
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;
        private DateTime dtUpdDate;
        private string strCancelReason = null;
        private string strRemarks = null;
        private string strName = null;
        private decimal decPercentage = 0;
        private int intResident_sts = 0;
        private int intTaxDeducted = 0;
        private int intcnclStatus = 0;
        private int intcncl_sts = 0;
        private int intTcsId = 0;
        private int intPurchaseId = 0;
        private int intRefSequence = 0;


        private int intCurrcyId = 0;
        private int intAccntNameId = 0;
        private int intLedgerId = 0;
        private int intCostCtrId = 0;


        private decimal intLedgerAmnt = 0;
        private decimal intCstCntrAmnt = 0;
        private decimal intExchngAmnt = 0;
        private decimal intTotalAmnt = 0;


        private string strRefNum = null;
        private string strDescription = "";
        private int intPaymentId = 0;
        private int intPaymentLdgrId = 0;
        private int intPaymentCostId = 0;
        private int intConfrmSts = 0;

        private int intPaymentMode = 0;
        private int intChequeBookId = 0;
        private int intChequeBookNo = 0;
        private string intDDNumber = "";
        private int intBankTransferMode = 0;
        private int intChequeIssue = 0;
        private DateTime DtChequeIssueDate;
        private string strBank = "";
        private string strPayee = "";
        private string strIBAN = "";
        private DateTime dtStartDate;
        private DateTime dtEndDate;

        private int intCostGrp1Id = 0;
        private int intCostGrp2Id = 0;
        private int intVocherID = 0;
        private int intAccountVocherID = 0;
        private decimal decPurchaseAmt = 0;

        private int intDebitNoteId = 0;
        private int intDebitNoteStatus = 0;
        private decimal decDebitAmount = 0;
        private decimal decDebiBaltAmount = 0;



        private int intRecurPeriodId = 0;
        private int intRecurRemindDays = 0;
        private DateTime dRecurDate;
        private int intRecurReceiptId = 0;
        private int intRecurMasterId = 0;
        private int intRecurSubId = 0;
        private int intPostdatedStatus = 0;
        private int intPostdateChqId = 0;
        private int intPostdateChqDtlId = 0;

        private decimal intLedgerPaidAmt = 0;
        private decimal intLedgerBalncAmt = 0;
        private int intVoucherCategory = 0;
        private int intLedgerRow = 0;
        //0043
        private int intExpenseId = 0;
        private decimal decExpnsAmnt = 0;
        private decimal decTotalExpnsAmnt = 0;


        public decimal TotalExpnsAmnt
        {
            get
            {
                return decTotalExpnsAmnt;
            }
            set
            {
                decTotalExpnsAmnt = value;
            }
        }
        public decimal ExpnsAmnt
        {
            get
            {
                return decExpnsAmnt;
            }
            set
            {
                decExpnsAmnt = value;
            }
        }
        public int ExpenceId
        {
            get
            {
                return intExpenseId;
            }
            set
            {
                intExpenseId = value;
            }
        }
        public int LedgerRow
        {
            get
            {
                return intLedgerRow;
            }
            set
            {
                intLedgerRow = value;
            }
        }
        public int VoucherCategory
        {
            get
            {
                return intVoucherCategory;
            }
            set
            {
                intVoucherCategory = value;
            }
        }
        public decimal PaidAmt
        {
            get
            {
                return intLedgerPaidAmt;
            }
            set
            {
                intLedgerPaidAmt = value;
            }
        }
        public decimal BalnceAmt
        {
            get
            {
                return intLedgerBalncAmt;
            }
            set
            {
                intLedgerBalncAmt = value;
            }
        }

        public int PostdateChqDtlId
        {
            get
            {
                return intPostdateChqDtlId;
            }
            set
            {
                intPostdateChqDtlId = value;
            }
        }
        public int PostdateChqId
        {
            get
            {
                return intPostdateChqId;
            }
            set
            {
                intPostdateChqId = value;
            }
        }
        public int PostdatedStatus
        {
            get
            {
                return intPostdatedStatus;
            }
            set
            {
                intPostdatedStatus = value;
            }
        }
        public int RecurPeriodId
        {
            get
            {
                return intRecurPeriodId;
            }
            set
            {
                intRecurPeriodId = value;
            }
        }

        public int RecurRemindDays
        {
            get
            {
                return intRecurRemindDays;
            }
            set
            {
                intRecurRemindDays = value;
            }
        }

        public int RecurReceiptId
        {
            get
            {
                return intRecurReceiptId;
            }
            set
            {
                intRecurReceiptId = value;
            }
        }

        public int RecurMasterId
        {
            get
            {
                return intRecurMasterId;
            }
            set
            {
                intRecurMasterId = value;
            }
        }

        public int RecurSubId
        {
            get
            {
                return intRecurSubId;
            }
            set
            {
                intRecurSubId = value;
            }
        }

        public DateTime RecurDate
        {
            get
            {
                return dRecurDate;
            }
            set
            {
                dRecurDate = value;
            }
        }



        public int DebitNoteStatus
        {
            get
            {
                return intDebitNoteStatus;
            }
            set
            {
                intDebitNoteStatus = value;
            }
        }
        public decimal DebitNoteRemainingAmount
        {
            get
            {
                return decDebiBaltAmount;
            }
            set
            {
                decDebiBaltAmount = value;
            }
        }
        public decimal DebitNoteAmount
        {
            get
            {
                return decDebitAmount;
            }
            set
            {
                decDebitAmount = value;
            }
        }
        public int DebitNoteId
        {
            get
            {
                return intDebitNoteId;
            }
            set
            {
                intDebitNoteId = value;
            }
        }
        public int SequenceRef
        {
            get
            {
                return intRefSequence;
            }
            set
            {
                intRefSequence = value;
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
        public decimal PurchaseActAmount
        {
            get
            {
                return decPurchaseAmt;
            }
            set
            {
                decPurchaseAmt = value;
            }
        }
        public int AccountVocherID
        {
            get
            {
                return intAccountVocherID;
            }
            set
            {
                intAccountVocherID = value;
            }
        }
        public int VoucherID
        {
            get
            {
                return intVocherID;
            }
            set
            {
                intVocherID = value;
            }
        }
        public int CostGrp1Id
        {
            get
            {
                return intCostGrp1Id;
            }
            set
            {
                intCostGrp1Id = value;
            }
        }
        public int CostGrp2Id
        {
            get
            {
                return intCostGrp2Id;
            }
            set
            {
                intCostGrp2Id = value;
            }
        }
        private int intBankStatus = 0;

        public int BankStatus
        {
            get
            {
                return intBankStatus;
            }
            set
            {
                intBankStatus = value;
            }
        }

        private int intFinancialYrId = 0;

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
        public DateTime UpdPaymentDate
        {
            get { return dtUpdDate; }
            set { dtUpdDate = value; }
        }
        public DateTime StartDate
        {
            get { return dtStartDate; }
            set { dtStartDate = value; }
        }
        public DateTime EndDate
        {
            get { return dtEndDate; }
            set { dtEndDate = value; }
        }
        public string Bank_BankTransfer
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
        public string IBAN_BankTransfer
        {
            get
            {
                return strIBAN;
            }
            set
            {
                strIBAN = value;
            }
        }
        public int BankTransfer_Mode
        {
            get
            {
                return intBankTransferMode;
            }
            set
            {
                intBankTransferMode = value;
            }
        }
        public DateTime ChequeIssueDate
        {
            get
            {
                return DtChequeIssueDate;
            }
            set
            {
                DtChequeIssueDate = value;
            }
        }
        public string DD_Number
        {
            get
            {
                return intDDNumber;
            }
            set
            {
                intDDNumber = value;
            }
        }
        public int ChequeIssue
        {
            get
            {
                return intChequeIssue;
            }
            set
            {
                intChequeIssue = value;
            }
        }
        public int PayemntMode
        {
            get
            {
                return intPaymentMode;
            }
            set
            {
                intPaymentMode = value;
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
        public int ChequeBookNumber
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
        public int ConfirmStatus
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
        public int PaymentCostCntrId
        {
            get
            {
                return intPaymentCostId;
            }
            set
            {
                intPaymentCostId = value;
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
        //methode of total amount
        public decimal TotalAmnt
        {
            get
            {
                return intTotalAmnt;
            }
            set
            {
                intTotalAmnt = value;
            }
        }
        //methode of costcenter amount
        public decimal LedgerAmnt
        {
            get
            {
                return intLedgerAmnt;
            }
            set
            {
                intLedgerAmnt = value;
            }
        }
        //methode of costcenter amount
        public decimal CstCntrAmnt
        {
            get
            {
                return intCstCntrAmnt;
            }
            set
            {
                intCstCntrAmnt = value;
            }
        }
        public decimal ExchangeRate
        {
            get
            {
                return intExchngAmnt;
            }
            set
            {
                intExchngAmnt = value;
            }
        }
        
        //methode of costcenter
        public int CostCtrId
        {
            get
            {
                return intCostCtrId;
            }
            set
            {
                intCostCtrId = value;
            }
        }

        //methode of ledger
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
        //methode of Description
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

        //methode of reference number
        public string RefNum
        {
            get
            {
                return strRefNum;
            }
            set
            {
                strRefNum = value;
            }
        }
        //methode of Accountid
        public int AccntNameId
        {
            get
            {
                return intAccntNameId;
            }
            set
            {
                intAccntNameId = value;
            }
        }
        //methode of curruncy id
        public int CurrcyId
        {
            get
            {
                return intCurrcyId;
            }
            set
            {
                intCurrcyId = value;
            }
        }

        //methode of cancel status
        public int cncl_sts
        {
            get
            {
                return intcncl_sts;
            }
            set
            {
                intcncl_sts = value;
            }
        }


        public int TcsId
        {
            get
            {
                return intTcsId;
            }
            set
            {
                intTcsId = value;
            }
        }

        public int cnclStatus
        {
            get
            {
                return intcnclStatus;
            }
            set
            {
                intcnclStatus = value;
            }
        }

        //methode of tax id storing
        public int TaxId
        {
            get
            {
                return intTaxDeducted;
            }
            set
            {
                intTaxDeducted = value;
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

        public int Resident_sts
        {
            get
            {
                return intResident_sts;
            }
            set
            {
                intResident_sts = value;
            }
        }
        //methode of provider type date storing
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

        //methode of provider name storing
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
        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
        public decimal Percentage
        {
            get
            {
                return decPercentage;
            }
            set
            {
                decPercentage = value;
            }
        }
    }
}

