using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityPurchaseMaster
    {
        private int intOrgid = 0;
        private int intProductid = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private int intPurchaseMstrId = 0;
        private string strCnclRsn = "";
        private int intCancelStatus = 0;
        private string strRef = "";
        private DateTime dtDate;
        private string strAccName = "";
        private string strSearchString = "";
        private int intledger = 0;
        private int intStatus = 0;
        private int intledgerBank = 0;
        private string strReceipt = "";
        private string strOrder = "";
        private int intCnfrmSts = 0;
        private decimal floatGross = 0;
        private decimal floatTaxTotal = 0;
        private decimal floatDiscountAmt = 0;
        private decimal floatNetAmt = 0;
        private decimal floatBalAmt = 0;
        private decimal floatPaidAmt = 0;
        private DateTime FromdtDate;
        private DateTime TodtDate;
        private decimal decexchageRate = 0;
        private decimal decTotalexchageRate = 0;
        private int intExistingSplrsts = 0;
        private string strSplrName = "";
        private string strAddressOne = "";
        private string strAddressTwo = "";
        private string strAddressThree = "";
        private string strcontactNo = "";
        private int intActModeId = 0;
        private DateTime dtConfirmDate;
        private DateTime dtStartDate;
        private DateTime dtEndDate;
        private string strFileName = "";
        private string strActualFileName = "";
        private int intFileUpdId = 0;
        private int intFinYrId = 0;
        private int intRefSequence = 0;
        private int intFileAttachStatus = 0;
        private string strDescription = "";
        private string strTerms = "";
        private int intVoucherId = 0;
        //0039
        //0039
        private int intLedgerId = 0;

        private DateTime dFromPeriod;

        private DateTime dToPeriod;

        private int intPrchsSts = 0;

        private int intPageNumber = 0;
        private int intPageMaxSize = 0;

        private int intOrderMethod = 0;
        private int intOrderColumn = 0;

        private string strCommonSearchTerm = "";

        private string strrSearchName = "";
        private string strSearchCode = "";
        private string strSearchAddress = "";

        private string strSearchRef = "";
        private string DSearchDate = "";
        private string strSearchSuppl = "";
        private string strSearchAmount = "";
        private int creditprd = 0;//evm 0044
        //end
      

        public int VoucherId
        {
            get { return intVoucherId; }
            set { intVoucherId = value; }
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
        private DateTime UpdPurchase_date;
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        public string Terms
        {
            get { return strTerms; }
            set { strTerms = value; }
        }
        public int AttachmentStatus
        {
            get { return intFileAttachStatus; }
            set { intFileAttachStatus = value; }
        }
        public int FinancialYrID
        {
            get { return intFinYrId; }
            set { intFinYrId = value; }
        }
        public int AttachmentId
        {
            get { return intFileUpdId; }
            set { intFileUpdId = value; }
        }
        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }
        public string ActualFileName
        {
            get { return strActualFileName; }
            set { strActualFileName = value; }
        }
               public DateTime PurchaseDateInUpd
        {
            get { return UpdPurchase_date; }
            set { UpdPurchase_date = value; }
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
        public string SplrName
        {
            get { return strSplrName; }
            set { strSplrName = value; }
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
         public string ContactNumber
        {
            get { return strcontactNo; }
            set { strcontactNo = value; }
        }
        
        public string AddressThree
        {
            get { return strAddressThree; }
            set { strAddressThree = value; }
        }


        private int intCurrency = 0;

        public string SearchString
        {
            get { return strSearchString; }
            set { strSearchString = value; }
        }
        public decimal ExchangeRate
        {
            get { return decexchageRate; }
            set { decexchageRate = value; }
        }
        public decimal TotalExchangeRate
        {
            get { return decTotalexchageRate; }
            set { decTotalexchageRate = value; }
        }
        public decimal PaidAmount
        {
            get { return floatPaidAmt; }
            set { floatPaidAmt = value; }
        }
        public decimal BalanceAmount
        {
            get { return floatBalAmt; }
            set { floatBalAmt = value; }
        }
        public int CurrencyId
        {
            get { return intCurrency; }
            set { intCurrency = value; }
        }
        public DateTime FromDate
        {
            get { return FromdtDate; }
            set { FromdtDate = value; }
        }
        public DateTime ToDate
        {
            get { return TodtDate; }
            set { TodtDate = value; }
        }
        public int ProductId
        {
            get { return intProductid; }
            set { intProductid = value; }
        }
        public int AccountStatus
        {
            get { return intStatus; }
            set { intStatus = value; }
        }
        public int PurchaseId
        {
            get { return intPurchaseMstrId; }
            set { intPurchaseMstrId = value; }
        }
        public string CancelReason
        {
            get { return strCnclRsn; }
            set { strCnclRsn = value; }
        }
        public int CancelStatus
        {
            get { return intCancelStatus; }
            set { intCancelStatus = value; }
        }
        public string AccountRef
        {
            get { return strRef; }
            set { strRef = value; }
        }
        public DateTime AccountDate
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        public string AccountName
        {
            get { return strAccName; }
            set { strAccName = value; }
        }
        public int LedgerCustomer
        {
            get { return intledger; }
            set { intledger = value; }
        }
        public int LedgerBank
        {
            get { return intledgerBank; }
            set { intledgerBank = value; }
        }
        public string ReceiptNo
        {
            get { return strReceipt; }
            set { strReceipt = value; }
        }
        public string OrderNo
        {
            get { return strOrder; }
            set { strOrder = value; }
        }
        public int ConfirmStatus
        {
            get { return intCnfrmSts; }
            set { intCnfrmSts = value; }
        }
        public decimal GrossAmount
        {
            get { return floatGross; }
            set { floatGross = value; }
        }
        public decimal DiscountTotal
        {
            get { return floatDiscountAmt; }
            set { floatDiscountAmt = value; }
        }
        public decimal TaxTotal
        {
            get { return floatTaxTotal; }
            set { floatTaxTotal = value; }
        }
        public decimal NetAmount
        {
            get { return floatNetAmt; }
            set { floatNetAmt = value; }
        }
        public int OrgId
        {
            get { return intOrgid; }
            set { intOrgid = value; }

        }
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }

        public int UserId
        {
            get { return intUsrId; }

            set { intUsrId = value; }
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
        public int PrchsSts
        {
            get
            {
                return intPrchsSts;
            }
            set
            {
                intPrchsSts = value;
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
        public string SearchSuppl
        {
            get
            {
                return strSearchSuppl;
            }
            set
            {
                strSearchSuppl = value;
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
                return creditprd ;
            }

            set
            {
                creditprd  = value;
            }
        }
       
    }
    public class clsEntityPurchaseMaster_list
    {
        private int intSlno = 0;
        private decimal floatQty = 0;
        private decimal intRate = 0;
        private decimal intTax = 0;
        private decimal floatDiscount = 0;
        private decimal floatDiscountAmt = 0;
        private decimal floatTaxAmt = 0;
        private decimal floatPrice = 0;
        private int intProductId = 0;
        private int intPrchsProductId = 0;
        private string strRemark = "";
        private int intPurchaseCC_Id = 0;
        private int intCostCntreId = 0;
        private int intCC_Grp_Id1 = 0;
        private int intCC_Grp_Id2 = 0;
        private decimal DecSaleCC_Amt = 0;
        private int intFinancialYrId = 0;

      


        public int FinancialYrId
        {
            get { return intFinancialYrId; }
            set { intFinancialYrId = value; }
        }
        public int Purchase_CC_Id
        {
            get { return intPurchaseCC_Id; }
            set { intPurchaseCC_Id = value; }
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
        public int PurchaseProductId
        {
            get { return intPrchsProductId; }
            set { intPrchsProductId = value; }
        }
        public int SlNo
        {
            get { return intSlno; }
            set { intSlno = value; }
        }
        public decimal Quantity
        {
            get { return floatQty; }
            set { floatQty = value; }
        }
        public decimal DiscountPercentage
        {
            get { return floatDiscount; }
            set { floatDiscount = value; }
        }
        public decimal Rate
        {
            get { return intRate; }
            set { intRate = value; }
        }
        public decimal DiscountAmount
        {
            get { return floatDiscountAmt; }
            set { floatDiscountAmt = value; }
        }
        public decimal Tax
        {
            get { return intTax; }
            set { intTax = value; }
        }
        public decimal TaxAmount
        {
            get { return floatTaxAmt; }
            set { floatTaxAmt = value; }
        }
        public decimal Price
        {
            get { return floatPrice; }
            set { floatPrice = value; }
        }
        public int ProductId
        {
            get { return intProductId; }
            set { intProductId = value; }

        }
        //0039
        

    }
        
}
    