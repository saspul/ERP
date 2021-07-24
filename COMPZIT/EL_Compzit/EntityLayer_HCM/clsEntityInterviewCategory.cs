using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityInterviewCategory
    {
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = "";
        private int intCancelStatus = 0;
        private int intIntwCategoryId=0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private string strIntwCategoryName = "";
        private int intIntwCategoryStatus = 0;
        public int IntwCategoryStatus
        {
            get
            {
                return intIntwCategoryStatus;
            }
            set
            {
                intIntwCategoryStatus = value;
            }
        }
        public string IntwCategoryName
        {
            get
            {
                return strIntwCategoryName;
            }
            set
            {
                strIntwCategoryName = value;
            }
        }
        public int IntwCategoryId
        {
            get
            {
                return intIntwCategoryId;
            }
            set
            {
                intIntwCategoryId = value;
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
    }
    public class clsEntityInterviewCategoryDetails
    {
        private string strIntwCtgryDtlName = "";
        private int intIntwCtgryDtlStatus = 0;
        private int intIntwCtgryDtlId=0;
        public int IntwCtgryDtlId
        {
            get
            {
                return intIntwCtgryDtlId;
            }
            set
            {
                intIntwCtgryDtlId = value;
            }
        }
        public string IntwCtgryDtlName
        {
            get
            {
                return strIntwCtgryDtlName;
            }
            set
            {
                strIntwCtgryDtlName = value;
            }
        }
        public int IntwCtgryDtlStatus
        {
            get
            {
                return intIntwCtgryDtlStatus;
            }
            set
            {
                intIntwCtgryDtlStatus = value;
            }
        }
    }
}
