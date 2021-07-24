using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_PMS
{
    public class clsEntityChargeHeads
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private string strCnclRsn = "";
        private int intStatus = 0;
        private int intCancelStatus = 0;
        private int intChargeHeadID = 0;
        private string strChargeHead = "";
        private string strChargeHeadCode = "";
        private int intChargeHeadCatID = 0;
        private int intChargeHeadCalculate = 0;

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
                return intChargeHeadID;
            }
            set
            {
                intChargeHeadID = value;
            }
        }

        public string ChargeHead
        {
            get
            {
                return strChargeHead;
            }
            set
            {
                strChargeHead = value;
            }
        }

        public string ChargeHeadCode
        {
            get
            {
                return strChargeHeadCode;
            }
            set
            {
                strChargeHeadCode = value;
            }
        }
        public int CHCategoryId
        {
            get
            {
                return intChargeHeadCatID;
            }
            set
            {
                intChargeHeadCatID = value;
            }
        }
        public int CHCalculate
        {
            get
            {
                return intChargeHeadCalculate;
            }
            set
            {
                intChargeHeadCalculate = value;
            }
        }

    }
}