using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLeaveApplicationReport
    {

        private int intUserId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private DateTime dateFrom;
        private DateTime dateTo;
        private int intLeaveTypId = 0;
        private int intDesgId = 0;
        private int intDivId = 0;
        private int intSts = 0;


        public int LeaveTypeId
        {
            get
            {
                return intLeaveTypId;
            }
            set
            {
                intLeaveTypId = value;
            }
        }
        public int DesgnId
        {
            get
            {
                return intDesgId;
            }
            set
            {
                intDesgId = value;
            }
        }
        public int DivsnId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }
        public int Status
        {
            get
            {
                return intSts;
            }
            set
            {
                intSts = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dateFrom;
            }
            set
            {
                dateFrom = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dateTo;
            }
            set
            {
                dateTo = value;
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
    }
}
