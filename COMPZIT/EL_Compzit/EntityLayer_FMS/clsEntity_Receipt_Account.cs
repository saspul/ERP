using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
   public class clsEntity_Receipt_Account
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;
        private string strCancelReason = null;
        private string strName = null;
        private decimal decPercentage = 0;
        private int intResident_sts = 0;
        private int intTaxDeducted = 0;
        private int intcnclStatus = 0;
        private int intcncl_sts = 0;
        private int intTcsId = 0;


        private int intCurrcyId = 0;
        private int intAccntNameId = 0;
        private int intLedgerId = 0;
        private int intCostCtrId = 0;
        private int intReceiptId = 0;
        private int intReceiptCstCntrId = 0;
        private int intReceiptLedgrId = 0;
        private int intReceiptCstCntrldgrsts = 0;
        private decimal intLedgerAmnt = 0;
        private decimal intCstCntrAmnt = 0;
        private decimal intTotalAmnt = 0;
        private decimal decLedgerCreditAmt = 0;
        private decimal decExchangeRate = 0;
        private string strRefNum = null;
        private string strDescription = "";

        private int intConfirmStatus = 0;

        private int intBankId = 0;
        private string strIbanNo = "";

        private DateTime dtPaymentDate;
        private string intDDNumber = "";
        private int intTransferModId = 0;
        private int intPaymentModId = 0;
        private string intChecqueBookNo = "";
        private string strBank_Name = "";
        private DateTime dtStartDate;
        private DateTime dtEndDate;

        private DateTime dtRcptUpdateDate;

    
        private int intFinancialYrId = 0;
        private int intLedId = 0;
        private int intCostGrp1Id = 0;
        private int intCostGrp2Id = 0;

        private int intRcptSts = 0;
        private string strRemarks = null;

        private decimal decSettlmntAmmnt = 0;
        private decimal decBalanceAmmnt = 0;

       private int intRefNextNum = 0;


       private int intRecurPeriodId = 0;
       private int intRecurRemindDays = 0;
       private DateTime dRecurDate;
       private int intRecurReceiptId = 0;
       private int intRecurMasterId = 0;
       private int intRecurSubId = 0;
       private decimal intLedgerPaidAmt = 0;
       private decimal intLedgerBalncAmt = 0;
       private int intVoucherCategory = 0;
       private int intLedgerRow = 0;




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





       public int RefNextNum
        {
            get
            {
                return intRefNextNum;
            }
            set
            {
                intRefNextNum = value;
            }
        }
       public decimal BalanceAmount
       {
           get
           {
               return decBalanceAmmnt;
           }
           set
           {
               decBalanceAmmnt = value;
           }
       }
        public decimal SettlmntAmmnt
        {
            get
            {
                return decSettlmntAmmnt;
            }
            set
            {
                decSettlmntAmmnt = value;
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

        public int RcptSts
        {
            get { return intRcptSts; }
            set { intRcptSts = value; }
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
        public int LedId
        {
            get
            {
                return intLedId;
            }
            set
            {
                intLedId = value;
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
        public DateTime RcptUpdateDate
        {
            get { return dtRcptUpdateDate; }
            set { dtRcptUpdateDate = value; }
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

        public string Bank_Name
        {
            get
            {
                return strBank_Name;
            }
            set
            {
                strBank_Name = value;
            }
        }
        public string ChequeBook_No
        {
            get
            {
                return intChecqueBookNo;
            }
            set
            {
                intChecqueBookNo = value;
            }
        }
        public int PaymentMod
        {
            get
            {
                return intPaymentModId;
            }
            set
            {
                intPaymentModId = value;
            }
        }

        public int TransferModId
        {
            get
            {
                return intTransferModId;
            }
            set
            {
                intTransferModId = value;
            }
        }

        public string DDNumber
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
        public DateTime PaymentDate
        {
            get
            {
                return dtPaymentDate;
            }
            set
            {
                dtPaymentDate = value;
            }
        }


        public string IbanNo
        {
            get
            {
                return strIbanNo;
            }
            set
            {
                strIbanNo = value;
            }
        }

        public int BankId
        {
            get
            {
                return intBankId;
            }
            set
            {
                intBankId = value;
            }
        }


       public decimal ExchangeRate
        {
            get
            {
                return decExchangeRate;
            }
            set
            {
                decExchangeRate = value;
            }
        }


        public decimal LedgerCreditAmt
        {
            get
            {
                return decLedgerCreditAmt;
            }
            set
            {
                decLedgerCreditAmt = value;
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
        public int ReceiptCstCntrldgrsts
        {
            get
            {
                return intReceiptCstCntrldgrsts;
            }
            set
            {
                intReceiptCstCntrldgrsts = value;
            }
        }
        public int ReceiptCstCntrId
        {
            get
            {
                return intReceiptCstCntrId;
            }
            set
            {
                intReceiptCstCntrId = value;
            }
        }


        public int ReceiptLedgrId
        {
            get
            {
                return intReceiptLedgrId;
            }
            set
            {
                intReceiptLedgrId = value;
            }
        }

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
        public int ReceiptId
        {
            get
            {
                return intReceiptId;
            }
            set
            {
                intReceiptId = value;
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
