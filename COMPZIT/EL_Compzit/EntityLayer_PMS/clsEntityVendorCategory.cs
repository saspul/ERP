using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_PMS
{
 public  class clsEntityVendorCategory
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private string strCnclRsn = "";
        private int intStatus = 0;
        private int intCancelStatus = 0;
        private int intVendorCategoryID = 0;
        private string strVendorCategory = "";
        private string strVCategoryCode = "";
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
        public int Cancel_status
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
        public string CancelReason
        {
            get
            {
                return strCnclRsn;
            }
            set
            {
                strCnclRsn = value;
            }
        }
        public int vendorCategoryID
        {
            get
            {
                return intVendorCategoryID;
            }
            set
            {
                intVendorCategoryID = value;
            }
        }

        public string VendorCategory
        {
            get
            {
                return strVendorCategory;
            }
            set
            {
                strVendorCategory = value;
            }
        }

        public string VendorCategoryCode
        {
            get
            {
                return strVCategoryCode;
            }
            set
            {
                strVCategoryCode = value;
            }
        }
        
    }
}