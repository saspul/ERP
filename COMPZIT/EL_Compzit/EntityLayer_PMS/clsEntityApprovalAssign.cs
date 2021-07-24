using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_PMS
{
   public class clsEntityApprovalAssign
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int inttempid = 0;
        private int intdesgid = 0;
        private int intuser = 0;
        private int intwrkflw = 0;
        private int intapprset = 0;
        private int intSubstituteEmpSts = 0;
        private int intThresholdPeriodMode = 0;
        private int intThresholdPeriodDays = 0;
        private int intAprvPendingSts = 0;
        private int intTtExceededSts = 0;
        private int intSmsSts = 0;
        private int intSystemSts = 0;
        private DateTime dStartDate;
        private DateTime dEndDate;
        private DateTime tDate;

        public int SubstituteEmpSts
        {
            get
            {
                return intSubstituteEmpSts;
            }
            set
            {
                intSubstituteEmpSts = value;
            }
        }
        public int ThresholdPeriodMode
        {
            get
            {
                return intThresholdPeriodMode;
            }
            set
            {
                intThresholdPeriodMode = value;
            }
        }
        public int ThresholdPeriodDays
        {
            get
            {
                return intThresholdPeriodDays;
            }
            set
            {
                intThresholdPeriodDays = value;
            }
        }
        public int AprvPendingSts
        {
            get
            {
                return intAprvPendingSts;
            }
            set
            {
                intAprvPendingSts = value;
            }

        }
        public int TtExceededSts
        {
            get
            {
                return intTtExceededSts;
            }
            set
            {
                intTtExceededSts = value;
            }
        }
        public int SmsSts
        {
            get
            {
                return intSmsSts;
            }
            set
            {
                intSmsSts = value;
            }
        }
        public int SystemSts
        {
            get
            {
                return intSystemSts;
            }
            set
            {
                intSystemSts = value;
            }
        }


       public DateTime StartDate
        {
            get
            {
                return dStartDate;
            }
            set
            {
                dStartDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return dEndDate;
            }
            set
            {
                dEndDate = value;
            }
        }
        public DateTime cDate
        {
            get
            {
                return tDate;
            }
            set
            {
                tDate = value;
            }
        }
        public int apprsetid
        {
            get
            {
                return intapprset;
            }
            set
            {
                intapprset = value;
            }
        }
        public int wrkflwid
        {
            get
            {
                return intwrkflw;
            }
            set
            {
                intwrkflw = value;
            }
        }
        public int userid
        {
            get
            {
                return intuser;
            }
            set
            {
                intuser = value;
            }
        }
        public int Organisation_id
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
        //methode of corporate id storing
        public int Corporate_id
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
        public int tempid
        {
            get
            {
                return inttempid;
            }
            set
            {
                inttempid = value;
            }
        }
        public int desgid
        {
            get
            {
                return intdesgid;
            }
            set
            {
                intdesgid = value;
            }
        }
        public int Status_id
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
    }
}
