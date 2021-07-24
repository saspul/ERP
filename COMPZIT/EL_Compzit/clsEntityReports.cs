using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:20/05/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit
{
    public class clsEntityReports
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intDivisionId = 0;
        private string strFromDate = null;
        private string strToDate = null;
        private int intLeadStatus = 0;
        private int intQuotationStatus = 0;
        private int intguarcatgryId = 0;
        private int intGuaranteeTypeId = 0;
        private int intGuaranteeModeId = 0;
        private int intProjctId = 0;
        private int intGuaranteeExpiryModeId = 0;
        private int intTempId = 0;
        private int intLeadQtnId = 0;
        private DateTime dateExpiryRangeToDate = new DateTime();
        private DateTime dateExpiryRangeFromDate = new DateTime();
        private int intGroupId = 0;
        private string strGroupName = null;

        private DateTime dteLeadDate = DateTime.MinValue;
        private DateTime dteLeadTo = DateTime.MinValue;

        private int intCustomerId = 0;
        private string strCustname = null;
        private int intProjId = 0;
        private int intStatusId = 0;
        private int intEmpId = 0;

        private string strProjctId = "";
        private string strCustomerName = "";
        private int intLeadStsId = 0;

        private DateTime fDate = DateTime.MinValue;
        private DateTime lDate = DateTime.MinValue;


        private int intYear = 0;
        private string strMonth = null;
        private int intQuarter = 0;

        private int intSalesExecutiveId = 0;
        private int intBankId = 0;

        private int intCurncyId = 0;
        //EVM-0027
        private int strInsProviderName = 0;
        private int intInsTyp = 0;

        //----------------Pageination--------------------
        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;


        private string strSearchRef = "";
        private string strSearchDate = "";
        private string strSearchAssignTo = "";
        private string strSearchProject = "";
        private string strSearchCustomer = "";
        private string strSearchStatus = "";
        private string strSearchQuotRef = "";
        private string strSearchQuarter = "";
        private string strSearchMonth = "";


        private string strSearchCode = "";
        private string strSearchProduct = "";
        private string strSearchGroup = "";
        private string strSearchCategory = "";
        private string strSearchBrand = "";
        private string strSearchDivision = "";
        private string strSearchnature = "";
        private string strSearchExcode = "";


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
        public string SearchProduct
        {
            get
            {
                return strSearchProduct;
            }
            set
            {
                strSearchProduct = value;
            }
        }
        public string SearchGroup
        {
            get
            {
                return strSearchGroup;
            }
            set
            {
                strSearchGroup = value;
            }
        }

        public string SearchCategory
        {
            get
            {
                return strSearchCategory;
            }
            set
            {
                strSearchCategory = value;
            }
        }
        public string SearchBrand
        {
            get
            {
                return strSearchBrand;
            }
            set
            {
                strSearchBrand = value;
            }
        }
        public string SearchDivision
        {
            get
            {
                return strSearchDivision;
            }
            set
            {
                strSearchDivision = value;
            }
        }

        public string Searchnature
        {
            get
            {
                return strSearchnature;
            }
            set
            {
                strSearchnature = value;
            }
        }
        public string SearchExcode
        {
            get
            {
                return strSearchExcode;
            }
            set
            {
                strSearchExcode = value;
            }
        }
        public string SearchMonth
        {
            get
            {
                return strSearchMonth;
            }
            set
            {
                strSearchMonth = value;
            }
        }
        public string SearchQuarter
        {
            get
            {
                return strSearchQuarter;
            }
            set
            {
                strSearchQuarter = value;
            }
        }
        public string SearchQuotRef
        {
            get
            {
                return strSearchQuotRef;
            }
            set
            {
                strSearchQuotRef = value;
            }
        }
        public string SearchStatus
        {
            get
            {
                return strSearchStatus;
            }
            set
            {
                strSearchStatus = value;
            }
        }
        public string SearchCustomer
        {
            get
            {
                return strSearchCustomer;
            }
            set
            {
                strSearchCustomer = value;
            }
        }
        public string SearchProject
        {
            get
            {
                return strSearchProject;
            }
            set
            {
                strSearchProject = value;
            }
        }
        public string SearchAssignTo
        {
            get
            {
                return strSearchAssignTo;
            }
            set
            {
                strSearchAssignTo = value;
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

        public int InsuranceType
        {
            get
            {
                return intInsTyp;
            }
            set
            {
                intInsTyp = value;
            }
        }


        public int InsuranceProvider
        {
            get
            {
                return strInsProviderName;
            }
            set
            {
                strInsProviderName = value;
            }
        }
        //END
        public int CurrencyId
        {
            get
            {
                return intCurncyId;
            }
            set
            {
                intCurncyId = value;
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

        public int SalesExecutiveId
        {
            get
            {
                return intSalesExecutiveId;
            }
            set
            {
                intSalesExecutiveId = value;
            }
        }

        public int Quarter
        {
            get
            {
                return intQuarter;
            }
            set
            {
                intQuarter = value;
            }
        }
        public string Month
        {
            get
            {
                return strMonth;
            }
            set
            {
                strMonth = value;
            }
        }
        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }
        //methode of storing the project id
        public int ProjctId
        {
            get
            {
                return intProjctId;
            }
            set
            {
                intProjctId = value;
            }
        }
        public int GuarCatgryId
        {
            get
            {
                return intguarcatgryId;
            }
            set
            {
                intguarcatgryId = value;
            }
        }
        public int Organisation_Id
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

        //methode of storing corporate office id
        public int Corporate_Id
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

        //methode of storing the user id
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

        //methode of storing the division id
        public int Division_Id
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

        //methode of storing from date
        public string From_Date
        {
            get
            {
                return strFromDate;
            }
            set
            {
                strFromDate = value;
            }
        }

        //methode of storing the to date
        public string To_Date
        {
            get
            {
                return strToDate;
            }
            set
            {
                strToDate = value;
            }
        }

        //methode of storing the lead status 
        public int Lead_Status
        {
            get
            {
                return intLeadStatus;
            }
            set
            {
                intLeadStatus = value;
            }

        }
        //method of storing the quotation status 
        public int Quotaion_Status
        {
            get
            {
                return intQuotationStatus;
            }
            set
            {
                intQuotationStatus = value;
            }

        }
        //method of storing the TypeId status 
        public int GuaranteeTypeId
        {
            get
            {
                return intGuaranteeTypeId;
            }
            set
            {
                intGuaranteeTypeId = value;
            }

        }
        public int GuaranteeModeId
        {
            get
            {
                return intGuaranteeModeId;
            }
            set
            {
                intGuaranteeModeId = value;
            }

        }
        public int GuaranteeExpiryModeId
        {
            get
            {
                return intGuaranteeExpiryModeId;
            }
            set
            {
                intGuaranteeExpiryModeId = value;
            }

        }
        public DateTime GuaranteeExpiryRangeTO
        {
            get
            {
                return dateExpiryRangeToDate;
            }
            set
            {
                dateExpiryRangeToDate = value;
            }

        }
        public DateTime GuaranteeExpiryRangeFrom
        {
            get
            {
                return dateExpiryRangeFromDate;
            }
            set
            {
                dateExpiryRangeFromDate = value;
            }

        }

        public int GuaranteeTempID
        {
            get
            {
                return intTempId;
            }
            set
            {
                intTempId = value;
            }

        }

        public int CustomerId
        {
            get
            {
                return intCustomerId;
            }
            set
            {
                intCustomerId = value;
            }

        }
        public string Customername
        {
            get
            {
                return strCustname;
            }
            set
            {
                strCustname = value;
            }

        }
        public int ProjectId
        {
            get
            {
                return intProjId;
            }
            set
            {
                intProjId = value;
            }

        }
        public int StatusId
        {
            get
            {
                return intStatusId;
            }
            set
            {
                intStatusId = value;
            }

        }
        public int EmployeeId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }

        }
        public int LeadStsId
        {
            get
            {
                return intLeadStsId;
            }
            set
            {
                intLeadStsId = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return strCustomerName;
            }
            set
            {
                strCustomerName = value;
            }
        }
        public string ProjctName
        {
            get
            {
                return strProjctId;
            }
            set
            {
                strProjctId = value;
            }
        }
        public DateTime LeadDateTo
        {
            get
            {
                return dteLeadTo;
            }
            set
            {
                dteLeadTo = value;
            }

        }
        public DateTime LeadDate
        {
            get
            {
                return dteLeadDate;
            }
            set
            {
                dteLeadDate = value;
            }

        }
        public DateTime FDate
        {
            get
            {
                return fDate;
            }
            set
            {
                fDate = value;
            }
        }
        public DateTime LDate
        {
            get
            {
                return lDate;
            }
            set
            {
                lDate = value;
            }
        }
        public int LdQtnId
        {
            get
            {
                return intLeadQtnId;
            }
            set
            {
                intLeadQtnId = value;
            }
        }
        public int GroupId
        {
            get
            {
                return intGroupId;
            }
            set
            {
                intGroupId = value;
            }
        }
        public string GroupName
        {
            get
            {
                return strGroupName;
            }
            set
            {
                strGroupName = value;
            }
        }
    }
}
