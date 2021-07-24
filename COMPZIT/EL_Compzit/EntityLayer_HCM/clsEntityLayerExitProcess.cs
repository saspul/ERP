using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerExitProcess
    {
        private int intExtPrcsId = 0;
        private int intEmpId = 0;
        private int intMode = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intExtPrcsStatus = 0;
        private DateTime dateExtPrcs;
        private string strExtRsn = null;
        private int intNotcPrd = 0;
        private int intConfrmStatus = 0;
        private DateTime dDate;
        private int intCancelStatus = 0;
        private string strCancelReason = null;
        private int intIncidentUsrId = 0;

        public int IncidentUserId
        {
            get
            {
                return intIncidentUsrId;
            }
            set
            {
                intIncidentUsrId = value;
            }
        }
        public int ExitProcsId
        {
            get
            {
                return intExtPrcsId;
            }
            set
            {
                intExtPrcsId = value;
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

        public int ExitProcsStatus
        {
            get
            {
                return intExtPrcsStatus;
            }
            set
            {
                intExtPrcsStatus = value;
            }
        }

        public DateTime ExitProcsDate
        {
            get
            {
                return dateExtPrcs;
            }
            set
            {
                dateExtPrcs = value;
            }
        }

        public string ExitReason
        {
            get
            {
                return strExtRsn;
            }
            set
            {
                strExtRsn = value;
            }
        }

        public int NoticePrd
        {
            get
            {
                return intNotcPrd;
            }
            set
            {
                intNotcPrd = value;
            }
        }

        public int ConfrmStatus
        {
            get
            {
                return intConfrmStatus;
            }
            set
            {
                intConfrmStatus = value;
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

























    }
}
