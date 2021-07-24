using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_PMS
{
    public class clsEntityPurchaseOrder
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intStatus = 0;
        private int intCancelStatus = 0;
        private string strCancelReason = "";
        private int intPurchsOrdrId = 0;
        private int intPurchsOrdrType = 0;
        private string strPurchsOrdrRefrncNo = "";
        private DateTime dPurchsOrdrDate;
        private DateTime dExpctdDelivryDate;
        private int intProjectId = 0;
        private string strClientName = "";
        private string strEndCustmrName = "";
        private int intModeOfSupply = 0;
        private int intDeliverToSts = 0;
        private int intWarehouseId = 0;
        private string strWrhsDeliveryLocatn = "";
        private string strPrjctDeliveryLocatn = "";
        private string strQuotatnRefNo = "";
        private DateTime dQuotatnDate;
        private int intCurrencyId = 0;
        private decimal decExchngRate = 0;
        private decimal decNetAmntWthtExchngRt = 0;
        private decimal decGrossTotalAmnt = 0;
        private decimal decTaxTotalAmnt = 0;
        private decimal decDiscntTotalAmnt = 0;
        private decimal decNetTotalAmnt = 0;
        private int intVendorId = 0;
        private string strVendorRefNo = "";
        private string strVendorAddress = "";
        private int intVendorCntctPrsnId = 0;
        private string strVendorMobile = "";
        private string strVendorPhone = "";
        private string strVendorFax = "";
        private string strVendorEmail = "";
        private string strVendorComments = "";
        private int intUseVendorDtlFuture = 0;
        private int intWrkFlowId = 0;
        private int intRqstdCustomerId = 0;
        private DateTime dRqrmntDate;
        private int intPOPriority = 0;
        private string strPOReqstnNo = "";
        private DateTime dPOReqstnDate;
        private int intPOCntctPrsnId = 0;
        private string strPOMobileNo = "";
        private int intDivisionId = 0;
        private DateTime dApprovalDate;
        private string strJobCode = "";
        private string strJobDescriptn = "";
        private string strPaymntTerms = "";
        private string strTermsAndCondtns = "";
        private string strFreightTerms = "";

        //--------SubTables--------
        private int intDtlId = 0;
        private int intSLNo = 0;
        private int intProductId = 0;
        private decimal decQnty = 0;
        private decimal decPrice = 0;
        private decimal decProductTotalAmnt = 0;
        private decimal decDiscntPrcnt = 0;
        private decimal decDiscntAmnt = 0;
        private int intTaxId = 0;
        private decimal decTaxPrcnt = 0;
        private decimal decTaxAmnt = 0;
        private int intVehicleId = 0;
        private DateTime dStartDate;
        private DateTime dEndDate;
        private int intEmployeeId = 0;
        private string strPNRNo = "";
        private string strSector = "";
        private DateTime dTravelDate;
        private string strRemarks = "";
        private int intVisibleSts = 0;
        private string strComment = "";
        private int intChrgHeadId = 0;
        private decimal decChrgHeadAmnt = 0;
        private string strFileName = "";
        private string strActualFileName = "";
        private string strDescrptn = "";
        private string strNoteMsg = "";
        private int intReplySts = 0;

        //----------------Pageination--------------------
        private string strCommonSearchTerm = "";
        private string strSearchDate = "";
        private string strSearchRef = "";
        private string strSearchPOType = "";
        private string strSearchVendor = "";
        private string strSearchWrkflw = "";
        private string strSearchDelvryDt = "";
        private string strSearchAmnt = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        //----------------Pageination--------------------

        private int intNoteId = 0;
        private string strVendorContactName = "";
        private int intVendorContactSts = 0;


        public int VendorContactSts
        {
            get
            {
                return intVendorContactSts;
            }
            set
            {
                intVendorContactSts = value;
            }
        }
        public string VendorContactName
        {
            get
            {
                return strVendorContactName;
            }
            set
            {
                strVendorContactName = value;
            }
        }
        public int NoteId
        {
            get
            {
                return intNoteId;
            }
            set
            {
                intNoteId = value;
            }
        }
        //----------------Pageination--------------------
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
        public string SearchDate
        {
            get
            {
                return strSearchDate;
            }
            set
            {
                strSearchDate = value;
            }
        }

        public string SearchPOType
        {
            get
            {
                return strSearchPOType;
            }
            set
            {
                strSearchPOType = value;
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
        public string SearchVendor
        {
            get
            {
                return strSearchVendor;
            }
            set
            {
                strSearchVendor = value;
            }
        }
        public string SearchWrkflw
        {
            get
            {
                return strSearchWrkflw;
            }
            set
            {
                strSearchWrkflw = value;
            }
        }
        public string SearchDelvryDt
        {
            get
            {
                return strSearchDelvryDt;
            }
            set
            {
                strSearchDelvryDt = value;
            }
        }
        public string SearchAmnt
        {
            get
            {
                return strSearchAmnt;
            }
            set
            {
                strSearchAmnt = value;
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
        //----------------Pageination--------------------
        public int ReplySts
        {
            get
            {
                return intReplySts;
            }
            set
            {
                intReplySts = value;
            }
        }
        public string NoteMsg
        {
            get
            {
                return strNoteMsg;
            }
            set
            {
                strNoteMsg = value;
            }
        }
        public string Descrptn
        {
            get
            {
                return strDescrptn;
            }
            set
            {
                strDescrptn = value;
            }
        }
        public string ActualFileName
        {
            get
            {
                return strActualFileName;
            }
            set
            {
                strActualFileName = value;
            }
        }
        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        public decimal ChrgHeadAmnt
        {
            get
            {
                return decChrgHeadAmnt;
            }
            set
            {
                decChrgHeadAmnt = value;
            }
        }
        public int ChrgHeadId
        {
            get
            {
                return intChrgHeadId;
            }
            set
            {
                intChrgHeadId = value;
            }
        }
        public string Comment
        {
            get
            {
                return strComment;
            }
            set
            {
                strComment = value;
            }
        }
        public int VisibleSts
        {
            get
            {
                return intVisibleSts;
            }
            set
            {
                intVisibleSts = value;
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
        public DateTime TravelDate
        {
            get
            {
                return dTravelDate;
            }
            set
            {
                dTravelDate = value;
            }
        }
        public string Sector
        {
            get
            {
                return strSector;
            }
            set
            {
                strSector = value;
            }
        }
        public string PNRNo
        {
            get
            {
                return strPNRNo;
            }
            set
            {
                strPNRNo = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return dEndDate;
            }
            set
            {
                dEndDate = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return dStartDate;
            }
            set
            {
                dStartDate = value;
            }
        }
        public int VehicleId
        {
            get
            {
                return intVehicleId;
            }
            set
            {
                intVehicleId = value;
            }
        }
        public decimal TaxAmnt
        {
            get
            {
                return decTaxAmnt;
            }
            set
            {
                decTaxAmnt = value;
            }
        }
        public decimal TaxPrcnt
        {
            get
            {
                return decTaxPrcnt;
            }
            set
            {
                decTaxPrcnt = value;
            }
        }
        public int TaxId
        {
            get
            {
                return intTaxId;
            }
            set
            {
                intTaxId = value;
            }
        }
        public decimal DiscntAmnt
        {
            get
            {
                return decDiscntAmnt;
            }
            set
            {
                decDiscntAmnt = value;
            }
        }
        public decimal DiscntPrcnt
        {
            get
            {
                return decDiscntPrcnt;
            }
            set
            {
                decDiscntPrcnt = value;
            }
        }

        public decimal ProductTotalAmnt
        {
            get
            {
                return decProductTotalAmnt;
            }
            set
            {
                decProductTotalAmnt = value;
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
        public decimal Qnty
        {
            get
            {
                return decQnty;
            }
            set
            {
                decQnty = value;
            }
        }
        public int ProductId
        {
            get
            {
                return intProductId;
            }
            set
            {
                intProductId = value;
            }
        }
        public int SLNo
        {
            get
            {
                return intSLNo;
            }
            set
            {
                intSLNo = value;
            }
        }

        public int DtlId
        {
            get
            {
                return intDtlId;
            }
            set
            {
                intDtlId = value;
            }
        }
        
        //--------SubTables--------

        public string FreightTerms
        {
            get
            {
                return strFreightTerms;
            }
            set
            {
                strFreightTerms = value;
            }
        }
        public string TermsAndCondtns
        {
            get
            {
                return strTermsAndCondtns;
            }
            set
            {
                strTermsAndCondtns = value;
            }
        }
        public string PaymntTerms
        {
            get
            {
                return strPaymntTerms;
            }
            set
            {
                strPaymntTerms = value;
            }
        }
        public string JobDescriptn
        {
            get
            {
                return strJobDescriptn;
            }
            set
            {
                strJobDescriptn = value;
            }
        }
        public string JobCode
        {
            get
            {
                return strJobCode;
            }
            set
            {
                strJobCode = value;
            }
        }
        public DateTime ApprovalDate
        {
            get
            {
                return dApprovalDate;
            }
            set
            {
                dApprovalDate = value;
            }
        }
        public int DivisionId
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }
        public string POMobileNo
        {
            get
            {
                return strPOMobileNo;
            }
            set
            {
                strPOMobileNo = value;
            }
        }
        public int POCntctPrsnId
        {
            get
            {
                return intPOCntctPrsnId;
            }
            set
            {
                intPOCntctPrsnId = value;
            }
        }
        public DateTime POReqstnDate
        {
            get
            {
                return dPOReqstnDate;
            }
            set
            {
                dPOReqstnDate = value;
            }
        }
        public string POReqstnNo
        {
            get
            {
                return strPOReqstnNo;
            }
            set
            {
                strPOReqstnNo = value;
            }
        }
        public int POPriority
        {
            get
            {
                return intPOPriority;
            }
            set
            {
                intPOPriority = value;
            }
        }
        public DateTime RqrmntDate
        {
            get
            {
                return dRqrmntDate;
            }
            set
            {
                dRqrmntDate = value;
            }
        }
        public int RqstdCustomerId
        {
            get
            {
                return intRqstdCustomerId;
            }
            set
            {
                intRqstdCustomerId = value;
            }
        }
        public int WrkFlowId
        {
            get
            {
                return intWrkFlowId;
            }
            set
            {
                intWrkFlowId = value;
            }
        }
        public int UseVendorDtlFuture
        {
            get
            {
                return intUseVendorDtlFuture;
            }
            set
            {
                intUseVendorDtlFuture = value;
            }
        }
        public string VendorComments
        {
            get
            {
                return strVendorComments;
            }
            set
            {
                strVendorComments = value;
            }
        }
        public string VendorEmail
        {
            get
            {
                return strVendorEmail;
            }
            set
            {
                strVendorEmail = value;
            }
        }
        public string VendorFax
        {
            get
            {
                return strVendorFax;
            }
            set
            {
                strVendorFax = value;
            }
        }
        public string VendorPhone
        {
            get
            {
                return strVendorPhone;
            }
            set
            {
                strVendorPhone = value;
            }
        }
        public string VendorMobile
        {
            get
            {
                return strVendorMobile;
            }
            set
            {
                strVendorMobile = value;
            }
        }
        public int VendorCntctPrsnId
        {
            get
            {
                return intVendorCntctPrsnId;
            }
            set
            {
                intVendorCntctPrsnId = value;
            }
        }
        public string VendorAddress
        {
            get
            {
                return strVendorAddress;
            }
            set
            {
                strVendorAddress = value;
            }
        }
        public string VendorRefNo
        {
            get
            {
                return strVendorRefNo;
            }
            set
            {
                strVendorRefNo = value;
            }
        }
        public int VendorId
        {
            get
            {
                return intVendorId;
            }
            set
            {
                intVendorId = value;
            }
        }
        public decimal NetAmntWthoutExchngRt
        {
            get
            {
                return decNetAmntWthtExchngRt;
            }
            set
            {
                decNetAmntWthtExchngRt = value;
            }
        }
        public decimal GrossTotalAmnt
        {
            get
            {
                return decGrossTotalAmnt;
            }
            set
            {
                decGrossTotalAmnt = value;
            }
        }
        public decimal TaxTotalAmnt
        {
            get
            {
                return decTaxTotalAmnt;
            }
            set
            {
                decTaxTotalAmnt = value;
            }
        }
        public decimal DiscntTotalAmnt
        {
            get
            {
                return decDiscntTotalAmnt;
            }
            set
            {
                decDiscntTotalAmnt = value;
            }
        }
        public decimal NetTotalAmnt
        {
            get
            {
                return decNetTotalAmnt;
            }
            set
            {
                decNetTotalAmnt = value;
            }
        }
        public decimal ExchngRate
        {
            get
            {
                return decExchngRate;
            }
            set
            {
                decExchngRate = value;
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
        public DateTime QuotatnDate
        {
            get
            {
                return dQuotatnDate;
            }
            set
            {
                dQuotatnDate = value;
            }
        }
        public string QuotatnRefNo
        {
            get
            {
                return strQuotatnRefNo;
            }
            set
            {
                strQuotatnRefNo = value;
            }
        }
        public string PrjctDeliveryLocatn
        {
            get
            {
                return strPrjctDeliveryLocatn;
            }
            set
            {
                strPrjctDeliveryLocatn = value;
            }
        }
        public string WrhsDeliveryLocatn
        {
            get
            {
                return strWrhsDeliveryLocatn;
            }
            set
            {
                strWrhsDeliveryLocatn = value;
            }
        }
        public int WarehouseId
        {
            get
            {
                return intWarehouseId;
            }
            set
            {
                intWarehouseId = value;
            }
        }
        public int DeliverToSts
        {
            get
            {
                return intDeliverToSts;
            }
            set
            {
                intDeliverToSts = value;
            }
        }
        public int ModeOfSupply
        {
            get
            {
                return intModeOfSupply;
            }
            set
            {
                intModeOfSupply = value;
            }
        }
        public string EndCustmrName
        {
            get
            {
                return strEndCustmrName;
            }
            set
            {
                strEndCustmrName = value;
            }
        }
        public string ClientName
        {
            get
            {
                return strClientName;
            }
            set
            {
                strClientName = value;
            }
        }
        public int ProjectId
        {
            get
            {
                return intProjectId;
            }
            set
            {
                intProjectId = value;
            }
        }
        public DateTime ExpctdDelivryDate
        {
            get
            {
                return dExpctdDelivryDate;
            }
            set
            {
                dExpctdDelivryDate = value;
            }
        }
        public DateTime PurchsOrdrDate
        {
            get
            {
                return dPurchsOrdrDate;
            }
            set
            {
                dPurchsOrdrDate = value;
            }
        }
        public string PurchsOrdrRefrncNo
        {
            get
            {
                return strPurchsOrdrRefrncNo;
            }
            set
            {
                strPurchsOrdrRefrncNo = value;
            }
        }
        public int PurchaseOrderType
        {
            get
            {
                return intPurchsOrdrType;
            }
            set
            {
                intPurchsOrdrType = value;
            }
        }
        public int PurchsOrdrId
        {
            get
            {
                return intPurchsOrdrId;
            }
            set
            {
                intPurchsOrdrId = value;
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

    }
}
