using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:19/03/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit
{
    public class clsEntityProduct_Master
    {
        private  int intProductId = 0;
        private  string strProductName = "";
        private  string strProductShortName = "";
        private  string strProductCode = "";
        private  int intProductGrpId = 0;
        private  int intProductMainCtgryId = 0;
        private  int intProductSubCtgryId = 0;
        private  int intProductSmallCtgryId = 0;
        private  int intProductLeastCtgryId = 0;    
        private  int intProductTaxId = 0;
        private  int intProductTaxMode = 0;
        private decimal decProductCostPrice = 0;
        private  int intOrgId = 0;
        private  int intCorpId = 0;
        private  int intStatus = 0;
        private  Int64 intUserId = 0;
        private  DateTime dDate;
        private  string strCancelReason = "";
        private int intDivsnId = 0;
        private int intProductBrand = 0;
        private int intCountryId = 0;
        private int intCategoryTypeId = 0;
        private int intMainCategoryId = 0;
        private string strExternalAppCode = "";
        private string strProductDescription = "";
        private int intCancelStatus = 0;
        private int intUnit = 0;
        private int intSaleableSts = 0;
        private int intStockableSts = 0;
        private int intNametoDescrptnSts = 0;
        private int intNametoRemarkSts = 0;

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchCode = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
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


        public int NametoRemarkSts
        {
            get
            {
                return intNametoRemarkSts;
            }
            set
            {
                intNametoRemarkSts = value;
            }
        }
        public int NametoDescrptnSts
        {
            get
            {
                return intNametoDescrptnSts;
            }
            set
            {
                intNametoDescrptnSts = value;
            }
        }
        public int StockableSts
        {
            get
            {
                return intStockableSts;
            }
            set
            {
                intStockableSts = value;
            }
        }
        public int SaleableSts
        {
            get
            {
                return intSaleableSts;
            }
            set
            {
                intSaleableSts = value;
            }
        }
        public int Unit
        {
            get
            {
                return intUnit;
            }
            set
            {
                intUnit = value;
            }
        }
        //methode of cancel status storing
        public int Cancel_Status
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
        //Property of storing id of Product Master
        public int Product_Id
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
      
        //Property of storing Product Master name
        public string Product_name
        {
            get
            {
                return strProductName;
            }

            set
            {
                strProductName = value;
            }
        }


        //Property of storing Product Master's ShortName
        public string Product_ShortName
        {
            get
            {
                return strProductShortName;
            }

            set
            {
                strProductShortName = value;
            }
        }

        //Property of storing Product Master's Code
        public string Product_Code
        {
            get
            {
                return strProductCode;
            }

            set
            {
                strProductCode = value;
            }
        }
     

       
        //Property of storing Group id of Product
        public int Product_GrpId
        {
            get
            {
                return intProductGrpId;
            }
            set
            {
                intProductGrpId = value;
            }
        }
        //Property of storing Product's Main Catgory Id 
        public int Product_MainCtgryId
        {
            get
            {
                return intProductMainCtgryId;
            }
            set
            {
                intProductMainCtgryId = value;
            }
        }
        //Property of storing Product's Sub Catgory Id 
        public int Product_SubCtgryId
        {
            get
            {
                return intProductSubCtgryId;
            }
            set
            {
                intProductSubCtgryId = value;
            }
        }
        //Property of storing Product's Small Ctgry Id
        public int Product_SmallCtgryId
        {
            get
            {
                return intProductSmallCtgryId;
            }
            set
            {
                intProductSmallCtgryId = value;
            }
        }
        //Property of storing Product's Least Ctgry Id
        public int Product_LeastCtgryId
        {
            get
            {
                return intProductLeastCtgryId;
            }
            set
            {
                intProductLeastCtgryId = value;
            }
        }
      
        //Property of storing Product's Sales Tax Id
        public int Product_TaxId
        {
            get
            {
                return intProductTaxId;
            }
            set
            {
                intProductTaxId = value;
            }
        }
        //Property of storing Product's Sales Tax Mode
        public int Product_TaxMode
        {
            get
            {
                return intProductTaxMode;
            }
            set
            {
                intProductTaxMode= value;
            }
        }

        //storing the product Cost Price
        public decimal ProductCostPrice
        {
            get
            {
                return decProductCostPrice;
            }
            set
            {
                decProductCostPrice = value;
            }
        }
        //Property of storing id of organisation
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
        //Property of storing id of corporate office
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
        //Property of storing Product Master status
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
        //Property of store the userid
        public Int64 User_Id
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
        //Property of storing the date when event occurs
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
        //Property of storing the cancel reason
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
        //Property of storing Divsion Id
        public int DivsionId
        {
            get
            {
                return intDivsnId;
            }
            set
            {
                intDivsnId = value;
            }
        }
        //Property of storing Product Brand
        public int ProductBrand
        {
            get
            {
                return intProductBrand;
            }
            set
            {
                intProductBrand = value;
            }
        }

        //Property of storing Country Id
        public int CountryId
        {
            get
            {
                return intCountryId;
            }
            set
            {
                intCountryId = value;
            }
        }
        //Property of storing id of CategoryType 
        public int CategoryType_Id
        {
            get
            {
                return intCategoryTypeId;
            }
            set
            {
                intCategoryTypeId = value;
            }
        }
        //Property of storing id of Main Category 
        public int MainCategoryId
        {
            get
            {
                return intMainCategoryId;
            }
            set
            {
                intMainCategoryId = value;
            }
        }
        //Property of storing Product Master's Code
        public string ExternalAppCode
        {
            get
            {
                return strExternalAppCode;
            }

            set
            {
                strExternalAppCode = value;
            }
        }
        //Property of storing product description
        public string Product_description
        {
            get
            {
                return strProductDescription;
            }

            set
            {
                strProductDescription = value;
            }
        }
    }
}
