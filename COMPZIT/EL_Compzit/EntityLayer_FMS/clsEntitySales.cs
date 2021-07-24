using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
  public  class clsEntitySales
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private DateTime dFromPeriod;
        private DateTime dToPeriod;
        private string strCancelReason = null;
        private string strRef = null;
        private int intAccId = 0;
        private int intLedgerId = 0;
        private int intBankId = 0;
        private int intcnclStatus = 0;
        private int intstatus = 0;
        private int intSales = 0;
        private string stringReceiptNo = null;
        private string stringOrderNo = null;
        private int intSLnO = 0;
        private int intproduct_id = 0;
        private decimal decQuantity = 0;
        private string strLedgerType = null;
        private decimal decRate = 0;
        private decimal decDcntPrcntg = 0;
        private decimal decDcntAmt = 0;
        private int intTax_id = 0;
        private decimal decTaxAmt = 0;
        private decimal decPrice = 0;
        private decimal decGrossTotal = 0;
        private decimal decTotalDiscount = 0;
        private decimal decTotalTax = 0;
        private decimal decNetTotal = 0;
        private decimal decPaidAmt = 0;
        private decimal decBalencAmtl = 0;
        private int intSalesProductId = 0;
        private int intCurrencyId = 0;
        private int intDefaultCurrencyId = 0;
        private decimal decExchangeRate = 0;
        private int intCurrencysts = 0;
        private string strProdctName = "";

        private int intExistingSplrsts = 0;
        private string strCustName = "";
        private string strAddressOne = "";
        private string strAddressTwo = "";
        private string strAddressThree = "";
        private int intActModeId = 0;
        private DateTime dtConfirmDate;
        private decimal decTotalexchageRate = 0;
        private DateTime dtStartDate;
        private DateTime dtEndDate;
        private DateTime dtSaleUpdDate;

        private string StrFileName = "";
        private string StrActualFileName = "";
        private int intAtchmntId = 0;
        private int intAtchmntSts = 0;
        private int intSalesSts = 0;
        private string strRemark = "";

        private int intSaleCC_Id = 0;
        private int intCostCntreId = 0;
        private int intCC_Grp_Id1 = 0;
        private int intCC_Grp_Id2 = 0;
        private decimal DecSaleCC_Amt = 0;
        private int intFinancialYrId = 0;
        private int intVoucherId = 0;


      //0039
        private int intPageNumber = 0;
        private int intPageMaxSize = 0;
      
           private int intOrderMethod = 0;
           private int intOrderColumn = 0;

           private string strCommonSearchTerm = "";

           private string strrSearchName = "";
           private string strSearchCode = "";
           private string strSearchAddress = "";

           private string strSearchRef = "";
           private string DSearchDate ="";
           private string strSearchCusto = "";
           private string strSearchAmount = "";
           private int creditprd = 0;
           private int intExpenseId;
           private string strGuestName = "";





           public string GuestName
           {
               get { return strGuestName; }
               set { strGuestName = value; }
           }
           public int ExpenseId
           {
               get { return intExpenseId; }
               set { intExpenseId = value; }
           }
           private DateTime dtExpDate;
           public DateTime ExpDate
           {
               get { return dtExpDate; }
               set { dtExpDate = value; }
           }
           private string strExpRef;
           public string ExpRef
           {
               get { return strExpRef; }
               set { strExpRef = value; }
           }
           private decimal decexpPaidAmt = 0;
           public decimal expPaidAmt
           {
               get { return decexpPaidAmt; }
               set { decexpPaidAmt = value; }
           }
           private decimal decexpBalAmt = 0;
           public decimal expBalAmt
           {
               get { return decexpBalAmt; }
               set { decexpBalAmt = value; }
           }
           private int intexpUserId;
           public int expUserId
           {
               get { return intexpUserId; }
               set { intexpUserId = value; }
           }
           private string strexpCnclReasn = "";
           public string expCnclReasn
           {
               get { return strexpCnclReasn; }
               set { strexpCnclReasn = value; }
           }
           private int intexpCorpId;
           public int expCorpId
           {
               get { return intexpCorpId; }
               set { intexpCorpId = value; }
           }
           private int intexpOrgId;
           public int expOrgId
           {
               get { return intexpOrgId; }
               set { intexpOrgId = value; }
           }
           private int intexpSettleSts = 0;
           public int expSettleSts
           {
               get { return intexpSettleSts; }
               set { intexpSettleSts = value; }
           }
           private string strexpDesc = "";
           public string expDesc
           {
               get { return strexpDesc; }
               set { strexpDesc = value; }
           }
           private int intexpStatus = 0;
           public int expStatus
           {
               get { return intexpStatus; }
               set { intexpStatus = value; }
           }
           private int intexpSalesId;
           public int expSalesId
           {
               get { return intexpSalesId; }
               set { intexpSalesId = value; }
           }
           private int intexpDtlId;
           public int expDtlId
           {
               get { return intexpDtlId; }
               set { intexpDtlId = value; }
           }
           private int intexpDtlLdgrId;
           public int expDtlLdgrId
           {
               get { return intexpDtlLdgrId; }
               set { intexpDtlLdgrId = value; }
           }
           private decimal decexpDtlAmt = 0;
           public decimal expDtlAmt
           {
               get { return decexpDtlAmt; }
               set { decexpDtlAmt = value; }
           }
           private string strexpDtlDesc = "";
           public string  expDtlDesc
           {
               get { return strexpDtlDesc; }
               set { strexpDtlDesc = value; }
           }
           private int intexpDtlUser;
           public int expDtlUser
           {
               get { return intexpDtlUser; }
               set { intexpDtlUser = value; }
           }
           private decimal decexpDtlPaidAmt = 0;
           public decimal expDtlPaidAmt
           {
               get { return decexpDtlPaidAmt; }
               set { decexpDtlPaidAmt = value; }
           }
           private decimal decexpDtlBalAmt = 0;
           public decimal expDtlBalAmt
           {
               get { return decexpDtlBalAmt; }
               set { decexpDtlBalAmt = value; }
           }
           private int intexpPrdtId;
           public int expPrdtId
           {
               get { return intexpPrdtId; }
               set { intexpPrdtId = value; }
           }
           private decimal decexpPrdtAmt = 0;
           public decimal expPrdtAmt
           {
               get { return decexpPrdtAmt; }
               set { decexpPrdtAmt = value; }
           }
           private int intexpPrdtUser;
           public int expPrdtUser
           {
               get { return intexpPrdtUser; }
               set { intexpPrdtUser = value; }
           }
           private int intexpDtlPartyId;
           public int expDtlPartyId
           {
               get { return intexpDtlPartyId; }
               set { intexpDtlPartyId = value; }
           }
           private decimal decExpAmount;
           public decimal expAmount
           {
               get { return decExpAmount; }
               set { decExpAmount = value; }
           }
      //---------------

          //end

        public int VoucherId
        {
            get { return intVoucherId; }
            set { intVoucherId = value; }
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
        public int Sale_CC_Id
        {
            get { return intSaleCC_Id; }
            set { intSaleCC_Id = value; }
        }
        public int CC_Id
        {
            get { return intCostCntreId; }
            set { intCostCntreId = value; }
        }
        public int CC_Grp1_Id
        {
            get { return intCC_Grp_Id1; }
            set { intCC_Grp_Id1 = value; }
        }
        public int CC_Grp2_Id
        {
            get { return intCC_Grp_Id2; }
            set { intCC_Grp_Id2 = value; }
        }
        public decimal CC_Amount
        {
            get { return DecSaleCC_Amt; }
            set { DecSaleCC_Amt = value; }
        }
        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }
        }
        public int SalesSts
        {
            get { return intSalesSts; }
            set { intSalesSts = value; }
        }

        public int AtchmntSts
        {
            get { return intAtchmntSts; }
            set { intAtchmntSts = value; }
        }
        public int AtchmntId
        {
            get { return intAtchmntId; }
            set { intAtchmntId = value; }
        }

        public string FileName
        {
            get { return StrFileName; }
            set { StrFileName = value; }
        }
        public string ActualFileName
        {
            get { return StrActualFileName; }
            set { StrActualFileName = value; }
        }
        public DateTime UpdSaleDate
        {
            get { return dtSaleUpdDate; }
            set { dtSaleUpdDate = value; }
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

        public decimal TotalExchangeRate
        {
            get { return decTotalexchageRate; }
            set { decTotalexchageRate = value; }
        }
        public DateTime ConfirmDate
        {
            get { return dtConfirmDate; }
            set { dtConfirmDate = value; }
        }
        public int ActModeId
        {
            get { return intActModeId; }
            set { intActModeId = value; }
        }

        public int ExistingSplrsts
        {
            get { return intExistingSplrsts; }
            set { intExistingSplrsts = value; }
        }
        public string CustName
        {
            get { return strCustName; }
            set { strCustName = value; }
        }
        public string AddressOne
        {
            get { return strAddressOne; }
            set { strAddressOne = value; }
        }
        public string AddressTwo
        {
            get { return strAddressTwo; }
            set { strAddressTwo = value; }
        }
        public string AddressThree
        {
            get { return strAddressThree; }
            set { strAddressThree = value; }
        }
        private int intRefNextNumbr = 0;
        public int RefNextNumbr
        {
            get
            {
                return intRefNextNumbr;
            }
            set
            {
                intRefNextNumbr = value;
            }
        }
        public string ProdctName
        {
            get
            {
                return strProdctName;
            }
            set
            {
                strProdctName = value;
            }
        }
        public int Currencysts
        {
            get
            {
                return intCurrencysts;
            }
            set
            {
                intCurrencysts = value;
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
        public int DefaultCurrencyId
        {
            get
            {
                return intDefaultCurrencyId;
            }
            set
            {
                intDefaultCurrencyId = value;
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
        public int SalesProductId
        {
            get
            {
                return intSalesProductId;
            }
            set
            {
                intSalesProductId = value;
            }
        }
        public decimal PaidAmt
        {
            get
            {
                return decPaidAmt;
            }
            set
            {
                decPaidAmt = value;
            }
        }
        public decimal BalencAmtl
        {
            get
            {
                return decBalencAmtl;
            }
            set
            {
                decBalencAmtl = value;
            }
        }
        public DateTime FromPeriod
        {
            get
            {
                return dFromPeriod;
            }
            set
            {
                dFromPeriod = value;
            }
        }

        public DateTime ToPeriod
        {
            get
            {
                return dToPeriod;
            }
            set
            {
                dToPeriod = value;
            }
        }
       

        public int SLnO
        {
            get
            {
                return intSLnO;
            }
            set
            {
                intSLnO = value;
            }
        }
      public decimal GrossTotal
        {
            get
            {
                return decGrossTotal;
            }
            set
            {
                decGrossTotal = value;
            }
        }
      public decimal TotalDiscount
        {
            get
            {
                return decTotalDiscount;
            }
            set
            {
                decTotalDiscount = value;
            }
        }
      public decimal TotalTax
        {
            get
            {
                return decTotalTax;
            }
            set
            {
                decTotalTax = value;
            }
        }
      public decimal NetTotal
        {
            get
            {
                return decNetTotal;
            }
            set
            {
                decNetTotal = value;
            }
        }

        public decimal Price
        {
            get
            {
                return decPrice;
            }
            set
            {
                decPrice = value;
            }
        }

        public decimal TaxAmt
        {
            get
            {
                return decTaxAmt;
            }
            set
            {
                decTaxAmt = value;
            }
        }
        public int Tax_id
        {
            get
            {
                return intTax_id;
            }
            set
            {
                intTax_id = value;
            }
        }
        public decimal DcntAmt
        {
            get
            {
                return decDcntAmt;
            }
            set
            {
                decDcntAmt = value;
            }
        }
        public decimal DcntPrcntg
        {
            get
            {
                return decDcntPrcntg;
            }
            set
            {
                decDcntPrcntg = value;
            }
        }


        public decimal Rate
        {
            get
            {
                return decRate;
            }
            set
            {
                decRate = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return decQuantity;
            }
            set
            {
                decQuantity = value;
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
        public int product_id
        {
            get
            {
                return intproduct_id;
            }
            set
            {
                intproduct_id = value;
            }
        }
        public string Ref
        {
            get
            {
                return strRef;
            }
            set
            {
                strRef = value;
            }
        }
        public int AccId
        {
            get
            {
                return intAccId;
            }
            set
            {
                intAccId = value;
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
        public string LedgerType
        {
            get
            {
                return strLedgerType;
            }
            set
            {
                strLedgerType = value;
            }
        }

        public string OrderNo
        {
            get
            {
                return stringOrderNo;
            }
            set
            {
                stringOrderNo = value;
            }
        }

        public string ReceiptNo
        {
            get
            {
                return stringReceiptNo;
            }
            set
            {
                stringReceiptNo = value;
            }
        }
        public int status
        {
            get
            {
                return intstatus;
            }
            set
            {
                intstatus = value;
            }
        }


        public int SalesId
        {
            get
            {
                return intSales;
            }
            set
            {
                intSales = value;
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

        //methode of provider type date storing
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

      //0039
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
                return strrSearchName;
            }
            set
            {
                strrSearchName = value;
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

        public string SearchRef
        {
            get
            {
                return strSearchRef;
            }
            set
            {
                strSearchRef = value;
            }
        }
        public string SearchDate
        {
            get
            {
                return DSearchDate;
            }
            set
            {
                DSearchDate = value;
            }
        }
        public string SearchCusto
        {
            get
            {
                return strSearchCusto;
            }
            set
            {
                strSearchCusto = value;
            }
        }
        public string SearchAmount
        {
            get
            {
                return strSearchAmount;
            }
            set
            {
                strSearchAmount = value;
            }
        }
        //evm 0044
        public int CreditPeriod
        {
            get
            {
                return creditprd;
            }

            set
            {
                creditprd = value;
            }
        }
      //end
      
      
    }
}
