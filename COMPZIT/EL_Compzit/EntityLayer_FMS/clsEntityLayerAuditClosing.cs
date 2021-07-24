using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityLayerAuditClosing
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private int intAuditClsId = 0;
        private int intLedgerId = 0;
        private int intDrBrMode = 0;
        private int intAccntGrpid = 0;
        private DateTime dFromDate;
        private DateTime dDate;
        private string strCancel_Reason = "";

        //methode for cancel reason
        public string Cancel_Reason
        {
            get
            {
                return strCancel_Reason;
            }
            set
            {
                strCancel_Reason = value;
            }
        }
        //methode to specify account grp id
        public int AccntGrpid
        {
            get
            {
                return intAccntGrpid;
            }
            set
            {
                intAccntGrpid = value;
            }
        }
        //methode to specify debit credit mode
        public int DrBrMode
        {
            get
            {
                return intDrBrMode;
            }
            set
            {
                intDrBrMode = value;
            }
        }
        //methode of ledger id storing
        public int LedgerId
        {
            get
            {
                return intLedgerId;
            }
            set
            {
                intLedgerId = value;
            }
        }
        //methode of account close id storing
        public int AuditClsId
        {
            get
            {
                return intAuditClsId;
            }
            set
            {
                intAuditClsId = value;
            }
        }
        //methode of organisation id storing
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

        //methode of user id storing
        public int User_Id
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
        //methode of status id storing
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


        //methode of provider type date storing
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        public DateTime CurrentDate
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
    }
}
