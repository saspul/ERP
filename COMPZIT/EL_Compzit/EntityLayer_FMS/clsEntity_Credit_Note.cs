using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntity_Credit_Note
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intCreditId = 0;
        private int intLedgerCreditId = 0;
        private int intCostCreditId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;
        private DateTime dFromDateFY;
        private DateTime dToDateFY;
        private int intLedgerId = 0;
        private int intCostCtrId = 0;
        private decimal intLedgerDebitAmnt = 0;
        private decimal intLedgerCreditTotal = 0;
        private decimal intLedgerDebitTotal = 0;
        private decimal intCstCntrAmnt = 0;
        private string strRefNum = null;
        private string strDescription = "";
        private DateTime Credit_date;
        private DateTime Upd_Credit_date;
        private int intConfrmSts = 0;
        private string strCancelReason = null;
        private int intSts = 0;
        private int intStatus = 0;
        private int intFinancialYrId = 0;
        private int intCurrencyId = 0;
        private int intCostGrp1Id = 0;
        private int intCostGrp2Id = 0;
        private int intVoucherID = 0;
        private int intCreditCount = 0;
        private int intDebitCount = 0;
        private string strRemarks = null;
        private decimal decreceiptAmt = 0;
        private int intRefSequence = 0;
        private decimal decSalesRefSettleAmnt = 0;
        private decimal decrBeforeSalesRefAmt = 0;



        public decimal BeforeSalesRefAmt
        {
            get
            {
                return decrBeforeSalesRefAmt;
            }
            set
            {
                decrBeforeSalesRefAmt = value;
            }
        }
        public decimal SalesRefSettleAmnt
        {
            get
            {
                return decSalesRefSettleAmnt;
            }
            set
            {
                decSalesRefSettleAmnt = value;
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
        public decimal ReceiptActAmount
        {
            get
            {
                return decreceiptAmt;
            }
            set
            {
                decreceiptAmt = value;
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
        public int CreditCount
        {
            get { return intCreditCount; }
            set { intCreditCount = value; }
        }
        public int DebitCount
        {
            get { return intDebitCount; }
            set { intDebitCount = value; }
        }
        public int VoucherID
        {
            get { return intVoucherID; }
            set { intVoucherID = value; }
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
        public DateTime UpdCredit_date
        {
            get { return Upd_Credit_date; }
            set { Upd_Credit_date = value; }
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
        public int Credit_debit_Status
        {
            get
            {
                return intSts;
            }
            set
            {
                intSts = value;
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
        public int Credit_Id
        {
            get
            {
                return intCreditId;
            }
            set
            {
                intCreditId = value;
            }
        }
        public int Ledger_Credit_Id
        {
            get
            {
                return intLedgerCreditId;
            }
            set
            {
                intLedgerCreditId = value;
            }
        }
        public int Cost_Centre_Credit_Id
        {
            get
            {
                return intCostCreditId;
            }
            set
            {
                intCostCreditId = value;
            }
        }
        public DateTime Date_From_FY
        {
            get
            {
                return dFromDateFY;
            }
            set
            {
                dFromDateFY = value;
            }
        }
        public DateTime Date_To_FY
        {
            get
            {
                return dToDateFY;
            }
            set
            {
                dToDateFY = value;
            }
        }
        public DateTime Date_From
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
        public DateTime Date_To
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
        public int Cost_Centre_Id
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

        public decimal Ledger_Amount
        {
            get
            {
                return intLedgerDebitAmnt;
            }
            set
            {
                intLedgerDebitAmnt = value;
            }
        }
        public decimal Credit_Total
        {
            get
            {
                return intLedgerCreditTotal;
            }
            set
            {
                intLedgerCreditTotal = value;
            }
        }
        public decimal Debit_Total
        {
            get
            {
                return intLedgerDebitTotal;
            }
            set
            {
                intLedgerDebitTotal = value;
            }
        }
        public decimal Cost_Centre_Amt
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
        public string Reference_Num
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
        public DateTime Credit_Date
        {
            get
            {
                return Credit_date;
            }
            set
            {
                Credit_date = value;
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

    }
}
