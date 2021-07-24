using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
 public   class clsEntityLayerRecentMenu
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intMenuid = 0;
        private int intUserId = 0;
        private int intAppid = 0;
        private int intCount = 0;
        private DateTime dDate;
        private TimeSpan dTime;
        private string strCancelReason = null;
        private string strAccoAddress = "";
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
        public int MenuId
        {
            get
            {
                return intMenuid;
            }
            set
            {
                intMenuid = value;
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
        public int AppId
        {
            get
            {
                return intAppid;
            }
            set
            {
                intAppid = value;
            }
        }
        public int Count
        {
            get
            {
                return intCount;
            }
            set
            {
                intCount = value;
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
        public TimeSpan MenuTime
        {
            get
            {
                return dTime;
            }
            set
            {
                dTime = value;
            }
        }
    }
}
