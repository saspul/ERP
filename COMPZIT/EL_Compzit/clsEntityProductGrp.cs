using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:16/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit
{
    public class clsEntityProductGrp
    {

        private int intItemGrpId = 0;
        private string strItemGrpName = null;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private Int64 intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private string strGroupCode = null;
        private int intPurchTax = 0;
        private int intSalesTax = 0;
        private int intItemTaxUpdate = 0;
        private int intCancelStatus = 0;

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
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

        //Method of storing id of Item Group
        public int ItemGrp_Id
        {
            get
            {
                return intItemGrpId;
            }
            set
            {
                intItemGrpId = value;
            }
        }
        //Method of storing Item Group name
        public string ItemGrp_name
        {
            get
            {
                return strItemGrpName;
            }

            set
            {
                strItemGrpName = value;
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
        //Method of storing Item Group status
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
        //methode of storing the purchase tax
        public int Purchase_Tax
        {
            get
            {
                return intPurchTax;
            }
            set
            {
                intPurchTax = value;
            }
        }
        //methode of storing the sales tax
        public int Sales_Tax
        {
            get
            {
                return intSalesTax;
            }
            set
            {
                intSalesTax = value;
            }
        }
        //methode of storing group code
        public string Group_Code
        {
            get
            {
                return strGroupCode;
            }
            set
            {
                strGroupCode = value;
            }
        }
        //this value decide item tax update or not
        public int Item_Tax_Update
        {
            get
            {
                return intItemTaxUpdate;
            }
            set
            {
                intItemTaxUpdate = value;
            }
        }
    }
}
