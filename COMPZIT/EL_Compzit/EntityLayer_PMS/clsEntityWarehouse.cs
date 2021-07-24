using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_PMS
{
    public class clsEntityWarehouse
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private int intWarehouseId = 0;
        private int intCntryId = 0;
        private int intStateId = 0;
        private int intCityId = 0;
        private string strWarehouseName = "";
        private string strWarehouseCode = "";
        private string strAddress1 = "";
        private string strAddress2 = "";
        private string strAddress3 = "";
        private string strPostalCode = "";
        private string strPhone = "";
        private string strEmail = "";
        private int intStatus = 0;
        private int intCancelSts = 0;
        private string strCnclReason = "";

//----------------Pageination--------------------

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchCode = "";
        private string strSearchAddress = "";
        private string strSearchCountry = "";
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
        public int UserId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
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
        public int CntryId
        {
            get
            {
                return intCntryId;
            }
            set
            {
                intCntryId = value;
            }
        }
        public int StateId
        {
            get
            {
                return intStateId;
            }
            set
            {
                intStateId = value;
            }
        }
        public int CityId
        {
            get
            {
                return intCityId;
            }
            set
            {
                intCityId = value;
            }
        }
        public string WarehouseName
        {
            get
            {
                return strWarehouseName;
            }
            set
            {
                strWarehouseName = value;
            }
        }
        public string WarehouseCode
        {
            get
            {
                return strWarehouseCode;
            }
            set
            {
                strWarehouseCode = value;
            }
        }
        public string Address1
        {
            get
            {
                return strAddress1;
            }
            set
            {
                strAddress1 = value;
            }
        }
        public string Address2
        {
            get
            {
                return strAddress2;
            }
            set
            {
                strAddress2 = value;
            }
        }
        public string Address3
        {
            get
            {
                return strAddress3;
            }
            set
            {
                strAddress3 = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return strPostalCode;
            }
            set
            {
                strPostalCode = value;
            }
        }
        public string Phone
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }
        public string Email
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
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
        public string CnclReason
        {
            get
            {
                return strCnclReason;
            }
            set
            {
                strCnclReason = value;
            }
        }


    }
}
