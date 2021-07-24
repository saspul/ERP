using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityJournal
    {

        private int intJournalId = 0;
        private int intCurrencyId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intViewStatus = 0;
        private int intUserId = 0;
        private string strCancelReason = null;
        private string strRefNum = null;
        private string strDescription = null;
        private DateTime dToDate;
        private DateTime dFromDate;
        private DateTime dateFromPeriod;
        private DateTime dateToPeriod;
        private decimal decTotAmnt = 0;
        private decimal decExcha = 0;
        private int intFinancialYrId = 0;
        private int intCreditCount = 0;
        private int intDebitCount = 0;
        private int intJrnltSts = 0;
        private int intJournlLedgerId = 0;
        private int intRefSeqNo = 0;
        private int intJournalCostCntrId = 0;
        private int intPostdateChqDtlId = 0;
        //START EVM 040
        private int ExpnseId = 0;




        public int Expense_Id
        {
            get
            {
                return ExpnseId;
            }
            set
            {
                ExpnseId = value;
            }
        }
        public int PostdateChqDtlId
        {
            get { return intPostdateChqDtlId; }
            set { intPostdateChqDtlId = value; }
        }
        public int JournalCostCntrId
        {
            get { return intJournalCostCntrId; }
            set { intJournalCostCntrId = value; }
        }
        public int RefSeqNo
        {
            get { return intRefSeqNo; }
            set { intRefSeqNo = value; }
        }
        public int JournlLedgerId
        {
            get
            {
                return intJournlLedgerId;
            }
            set
            {
                intJournlLedgerId = value;
            }
        }

        public int JrnltSts
        {
            get { return intJrnltSts; }
            set { intJrnltSts = value; }
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
        public int ViewStatus
        {
            get
            {
                return intViewStatus;
            }

            set
            {
                intViewStatus = value;
            }
        }
        public DateTime FromPeriod
        {
            get
            {
                return dateFromPeriod;
            }

            set
            {
                dateFromPeriod = value;
            }
        }
        public DateTime ToPeriod
        {
            get
            {
                return dateToPeriod;
            }

            set
            {
                dateToPeriod = value;
            }
        }
        public decimal ExchangeRate
        {
            get
            {
                return decExcha;
            }
            set
            {
                decExcha = value;
            }
        }
        public decimal JournalTotAmnt
        {
            get
            {
                return decTotAmnt;
            }
            set
            {
                decTotAmnt = value;
            }
        }
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
        public DateTime JournalDate
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
     
        public int JournalId
        {
            get
            {
                return intJournalId;
            }
            set
            {
                intJournalId = value;
            }
        }
        //Method of storing id of Main Category 
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
        //Method of storing id of organisation
        public int Org_Id
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
        //Method of storing id of corporate office
        public int Corp_Id
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
        //Method of storing Category status
        public int ConfirmSts
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
        //Method of store the userid
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
        //Method of storing the cancel reason
        public string Cancel_Reason
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
    public class clsEntityJournalLedgerDtl
    {
        private int intJournalId = 0;
        private int intLedgerId = 0;
        private int intJournlLedgerId = 0;
        private decimal decTotAmnt = 0;
        private int intTabMode = 0;
        private int intMainTabId = 0;
        private decimal decExcha = 0;
        private string strRemarks = null;
        private int intLdgrCount = 0;




        public int LdgrCount
        {
            get
            {
                return intLdgrCount;
            }
            set
            {
                intLdgrCount = value;
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



        public decimal ExchangeRate
        {
            get
            {
                return decExcha;
            }
            set
            {
                decExcha = value;
            }
        }
        public int TabMode
        {
            get
            {
                return intTabMode;
            }
            set
            {
                intTabMode = value;
            }
        }
        public int MainTabId
        {
            get
            {
                return intMainTabId;
            }
            set
            {
                intMainTabId = value;
            }
        }
        public decimal LedgerTotAmnt
        {
            get
            {
                return decTotAmnt;
            }
            set
            {
                decTotAmnt = value;
            }
        }
       

        public int JournalId
        {
            get
            {
                return intJournalId;
            }
            set
            {
                intJournalId = value;
            }
        }
        //Method of storing id of Main Category 
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
        //Method of storing id of organisation
        public int JournlLedgerId
        {
            get
            {
                return intJournlLedgerId;
            }
            set
            {
                intJournlLedgerId = value;
            }
        }
             
    }
    public class clsEntityJournalCostCntrDtl
    {
        private int intJournalId = 0;
        private int intJournlLedgerId = 0;
        private int intCostCenterId = 0;
        private int intPurchaseId = 0;
        private int intSaleId = 0;
        private int intJournalCostCntrId = 0;
        private string strPurSaleRefNum = null;
        private decimal decTotAmnt = 0;
        private int intTabMode = 0;
        private int intMainTabId = 0;
        private int intSubTabId = 0;
        private decimal decExcha = 0;
        private int intCostGrp1Id = 0;
        private int intCostGrp2Id = 0;
        private decimal decSettlmntAmmnt = 0;
        //START EVM 040
        private int ExpnseId = 0;
        private decimal ExpenseAmount = 0;
        private decimal decBalAmount = 0;




        public decimal BalAmount
        {
            get
            {
                return decBalAmount;
            }
            set
            {
                decBalAmount = value;
            }
        }
        public decimal Expense_Amount
        {
            get
            {
                return ExpenseAmount;
            }
            set
            {
                ExpenseAmount = value;
            }
        }
        public int Expense_Id
        {
            get
            {
                return ExpnseId;
            }
            set
            {
                ExpnseId = value;
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

        public decimal ExchangeRate
        {
            get
            {
                return decExcha;
            }
            set
            {
                decExcha = value;
            }
        }
        public int TabMode
        {
            get
            {
                return intTabMode;
            }
            set
            {
                intTabMode = value;
            }
        }
        public int MainTabId
        {
            get
            {
                return intMainTabId;
            }
            set
            {
                intMainTabId = value;
            }
        }
        public int SubTabId
        {
            get
            {
                return intSubTabId;
            }
            set
            {
                intSubTabId = value;
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
        public int SaleId
        {
            get
            {
                return intSaleId;
            }
            set
            {
                intSaleId = value;
            }
        }
        public int JournalCostCntrId
        {
            get
            {
                return intJournalCostCntrId;
            }
            set
            {
                intJournalCostCntrId = value;
            }
        }
        public string PurSaleRefNum
        {
            get
            {
                return strPurSaleRefNum;
            }
            set
            {
                strPurSaleRefNum = value;
            }
        }
        public decimal CostCntrAmnt
        {
            get
            {
                return decTotAmnt;
            }
            set
            {
                decTotAmnt = value;
            }
        }


        public int JournalId
        {
            get
            {
                return intJournalId;
            }
            set
            {
                intJournalId = value;
            }
        }
        //Method of storing id of Main Category 
        public int CostCenterId
        {
            get
            {
                return intCostCenterId;
            }
            set
            {
                intCostCenterId = value;
            }
        }
        //Method of storing id of organisation
        public int JournlLedgerId
        {
            get
            {
                return intJournlLedgerId;
            }
            set
            {
                intJournlLedgerId = value;
            }
        }

    }
}
