using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:17/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit
{
  public  class clsEntityCategory
    {
        private  int intCategoryId = 0;
        private  string strCategoryName = null;
        private  int intCategoryTypeId = 0;
        private  int intMainCategoryId = 0;
        private  int intOrgId = 0;
        private  int intCorpId = 0;
        private  int intStatus = 0;
        private  Int64 intUserId = 0;
        private  DateTime dDate;
        private  string strCancelReason = null;
        private int intGruopId = 0;
        private string strCommodityCode = null;
        private string strSearchWord = null;
        private string strDataBaseField = null;
        private int intCancelStatus = 0;
        private int intLedgerID=0;
        private int intPrchsLedgerID = 0;
        private int intNatureSts = 0;


        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchCode = "";
        private string strSearchType = "";
        private string strSearchCategory = "";
        private string strSearchGroup = "";
        private string strSearchSale = "";
        private string strSearchPurchase = "";
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
        public string SearchType
        {
            get
            {
                return strSearchType;
            }
            set
            {
                strSearchType = value;
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
        public string SearchSale
        {
            get
            {
                return strSearchSale;
            }
            set
            {
                strSearchSale = value;
            }
        }
        public string SearchPurchase
        {
            get
            {
                return strSearchPurchase;
            }
            set
            {
                strSearchPurchase = value;
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

        public int NatureSts
        {
            get { return intNatureSts; }
            set { intNatureSts = value; }
        }
        public int LedgerID
        {
            get { return intLedgerID; }
            set { intLedgerID = value; }
        }
        public int PurchaseLedgerID
        {
            get { return intPrchsLedgerID; }
            set { intPrchsLedgerID = value; }
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
        //Method of storing id of Category 
        public int Category_Id
        {
            get
            {
                return intCategoryId;
            }
            set
            {
                intCategoryId = value;
            }
        }
        //Method of storing Category  name
        public string Category_name
        {
            get
            {
                return strCategoryName;
            }

            set
            {
                strCategoryName = value;
            }
        }
        //Method of storing id of CategoryType 
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
        //Method of storing id of Main Category 
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
      //methode for storing item group id
        public int Item_Group_Id
        {
            get
            {
                return intGruopId;
            }
            set
            {
                intGruopId = value;
            }
        }
      //methode for storing commodity code
        public string Commodity_Code
        {
            get
            {
                return strCommodityCode;
            }
            set
            {
                strCommodityCode = value;
            }
        }
      //methode for storing search field
        public string Search_Field
        {
            get
            {
                return strSearchWord;
            }
            set
            {
                strSearchWord = value;
            }
        }
      //methode for storing database field
        public string DataBase_Field
        {
            get
            {
                return strDataBaseField;
            }
            set
            {
                strDataBaseField = value;
            }
        }
    }
}
