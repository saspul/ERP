using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
  public class clsEntityLedger
    {

        private int intLedgerId = 0;
        private string strLedgerName = null;
        private int intAccountGrpId = 0;
        private int intCurrencyId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private int intTDSsts = 0;
        private int intTCSsts = 0;
        private int intCostCenetersts = 0;
        private string strContactName = null;
        private int intLedgerZIP = 0;
        private string strLedgerTax = null;
        private string strLedgerAddess = null;
        private int intTDSId = 0;
        private int intTCSId = 0;
        private decimal decOpenBala = 0;
        private decimal decBalanceType = 0;
        private int intPageStatus = 0;
        private DateTime dToDate;
        private int intCostCenterID = 0;
        private int intSubLedgerID = 0;
        private int intSubLedgerSts = 0;
        private int intLedgerSts = 0;
        private int intTxEnabledSts = 0;
        private int intActModeId = 0;
        private int intBankId = 0;
        private int intCstmrSupplierSts = 0;

        private int intLedgerAcntGrpSts = 0;

        private int intCodeSts = 0;
       
        private string strLdgrCode = null;

        private int intCodePrsntSts = 0;
        private int intVouchrId = 0;
        private int intLevel = 0;
        private decimal intCreditLimit = 0;
        private int intCreditPeriod = 0;
        private int intCreditLimitRestrict = 0;
        private int intCreditPeriodRestrict = 0;
        private int intCreditLimitWarn = 0;
        private int intCreditPeriodWarn = 0;
        private int intPrimaryGrp = 0;
        private int intCodeFormatNumber = 0;

        private int intCancelSts = 0;
        private int intPageNumber = 0;
        private int intPageMaxSize = 0;
        private int intOrderMethod = 0;
        private int intOrderColumn = 0;
        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchCode = "";
        private string strSearchAddress = "";
        private string strSearchCountry = "";


        public int CodeFormatNumber
        {
            get
            {
                return intCodeFormatNumber;
            }
            set
            {
                intCodeFormatNumber = value;
            }
        }
        public int PrimaryGrp
        {
            get
            {
                return intPrimaryGrp;
            }
            set
            {
                intPrimaryGrp = value;
            }
        }
        public int CreditPeriodWarn
        {
            get
            {
                return intCreditPeriodWarn;
            }
            set
            {
                intCreditPeriodWarn = value;
            }
        }
        public int CreditLimitWarn
        {
            get
            {
                return intCreditLimitWarn;
            }
            set
            {
                intCreditLimitWarn = value;
            }
        }
        public int CreditPeriodRestrict
        {
            get
            {
                return intCreditPeriodRestrict;
            }
            set
            {
                intCreditPeriodRestrict = value;
            }
        }
        public int CreditLimitRestrict
        {
            get
            {
                return intCreditLimitRestrict;
            }
            set
            {
                intCreditLimitRestrict = value;
            }
        }
        public int CreditPeriod
        {
            get
            {
                return intCreditPeriod;
            }
            set
            {
                intCreditPeriod = value;
            }
        }
        public decimal CreditLimit
        {
            get
            {
                return intCreditLimit;
            }
            set
            {
                intCreditLimit = value;
            }
        }
        public int Level
        {
            get
            {
                return intLevel;
            }
            set
            {
                intLevel = value;
            }
        }
        public int VouchrId
        {
            get
            {
                return intVouchrId;
            }
            set
            {
                intVouchrId = value;
            }
        }
        public int CodePrsntSts
        {
            get
            {
                return intCodePrsntSts;
            }
            set
            {
                intCodePrsntSts = value;
            }
        }

        public string LdgrCode
        {
            get
            {
                return strLdgrCode;
            }
            set
            {
                strLdgrCode = value;
            }
        }

        public int CodeSts
        {
            get
            {
                return intCodeSts;
            }
            set
            {
                intCodeSts = value;
            }
        }

        public int LedgerAcntGrpSts
        {
            get
            {
                return intLedgerAcntGrpSts;
            }

            set
            {
                intLedgerAcntGrpSts = value;
            }
        }






        public int CustmrSupplierSts
        {
            get
            {
                return intCstmrSupplierSts;
            }

            set
            {
                intCstmrSupplierSts = value;
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
        public int ActModeId
        {
            get
            {
                return intActModeId;
            }

            set
            {
                intActModeId = value;
            }
        }
        public int TxEnabledSts
        {
            get
            {
                return intTxEnabledSts;
            }

            set
            {
                intTxEnabledSts = value;
            }
        }
        public int SubLedgerId
        {
            get
            {
                return intSubLedgerID;
            }

            set
            {
                intSubLedgerID = value;
            }
        }
        public int LedgerStatus
        {
            get
            {
                return intLedgerSts;
            }

            set
            {
                intLedgerSts = value;
            }
        }
        public int SubLedgerStatus
        {
            get
            {
                return intSubLedgerSts;
            }

            set
            {
                intSubLedgerSts = value;
            }
        }
        public int CostCenterID
        {
            get
            {
                return intCostCenterID;
            }

            set
            {
                intCostCenterID = value;
            }
        }


        public DateTime EffectiveDate
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

        public int PageSts
        {
            get
            {
                return intPageStatus;
            }

            set
            {
                intPageStatus = value;
            }
        }
        public decimal CreditBalance
        {
            get
            {
                return decBalanceType;
            }

            set
            {
                decBalanceType = value;
            }
        }
        public decimal DebitBalance
        {
            get
            {
                return decOpenBala;
            }

            set
            {
                decOpenBala = value;
            }
        }
        public int TDSid
        {
            get
            {
                return intTDSId;
            }

            set
            {
                intTDSId = value;
            }
        }
        public int TCSid
        {
            get
            {
                return intTCSId;
            }

            set
            {
                intTCSId = value;
            }
        }

        public string ContactName
        {
            get
            {
                return strContactName;
            }

            set
            {
                strContactName = value;
            }
        }
        public int LedgerZIP
        {
            get
            {
                return intLedgerZIP;
            }

            set
            {
                intLedgerZIP = value;
            }
        }
        public string LedgerTax
        {
            get
            {
                return strLedgerTax;
            }

            set
            {
                strLedgerTax = value;
            }
        }
        public string LedgerAddess
        {
            get
            {
                return strLedgerAddess;
            }

            set
            {
                strLedgerAddess = value;
            }
        }

        public int TDSstatus
        {
            get
            {
                return intTDSsts;
            }
            set
            {
                intTDSsts = value;
            }
        }
        public int TCSstatus
        {
            get
            {
                return intTCSsts;
            }
            set
            {
                intTCSsts = value;
            }
        }
        public int CostCenterSts
        {
            get
            {
                return intCostCenetersts;
            }
            set
            {
                intCostCenetersts = value;
            }
        }


        //Method of storing id of Category 
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
        //Method of storing Category  name
        public string LedgerName
        {
            get
            {
                return strLedgerName;
            }

            set
            {
                strLedgerName = value;
            }
        }
        //Method of storing id of CategoryType 
        public int AccountGrpId
        {
            get
            {
                return intAccountGrpId;
            }
            set
            {
                intAccountGrpId = value;
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
        //Method of storing the date when event occurs
        public DateTime D_Date
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




        //cancel sts
        public int CancelSts
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

        public string SearchAddress
        {
            get
            {
                return strSearchAddress;
            }
            set
            {
                strSearchAddress = value;
            }
        }

         public string SearchCountry
        {
            get
            {
                return strSearchCountry;
            }
            set
            {
                strSearchCountry = value;
            }
        }
        
   

     
    }
}
