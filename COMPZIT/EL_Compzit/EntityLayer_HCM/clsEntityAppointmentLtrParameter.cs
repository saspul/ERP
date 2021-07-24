using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityAppointmentLtrParameter
    {
        private int intApptLtrParameterId = 0;
        private string strHead = "";
        private string strDescription = "";
        private int intStatus = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = "";
        private int intCancelStatus = 0;
        public int ApptLtrParameterId
        {
            get
            {
                return intApptLtrParameterId;
            }
            set
            {
                intApptLtrParameterId = value;
            }
        }
        public string Head
        {
            get
            {
                return strHead;
            }
            set
            {
                strHead = value;
            }
        }
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
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
}