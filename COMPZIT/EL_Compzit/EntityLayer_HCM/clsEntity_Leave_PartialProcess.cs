using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Leave_PartialProcess
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intLeaveFcltyId = 0;
        private int intLeaveDtlId = 0;
        private int intLeavStatus = 0;
        private int intPrtclrId = 0;
        private DateTime dDate;
        private DateTime dAsgndDate;
        private DateTime dToDate;
        private int intEmpId = 0;
        private int intMode = 0;

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

        public int LeaveFacltyId
        {
            get
            {
                return intLeaveFcltyId;
            }
            set
            {
                intLeaveFcltyId = value;
            }
        }

        public int LeaveDtlStatus
        {
            get
            {
                return intLeavStatus;
            }
            set
            {
                intLeavStatus = value;
            }
        }

        public int PartclrId
        {
            get
            {
                return intPrtclrId;
            }
            set
            {
                intPrtclrId = value;
            }
        }

        public int LeaveDtlId
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

        public int EmpId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }

        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
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

        public DateTime AsgndDate
        {
            get
            {
                return dAsgndDate;
            }
            set
            {
                dAsgndDate = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }





    }
}
