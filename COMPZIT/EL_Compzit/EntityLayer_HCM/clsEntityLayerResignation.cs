using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayerResignation
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intResignationId = 0;
        private int intResgntnSts = 0;
        
        private DateTime dUserDate;
        private DateTime dPreferdDate;

        private string strReason = "";
        private int intLvClrId = 0;
        public string Reason
        {
            get
            {
                return strReason;
            }
            set
            {
                strReason = value;
            }
        }
        public int LvStfClrId
        {
            get
            {
                return intLvClrId;
            }
            set
            {
                intLvClrId = value;
            }
        }
        public DateTime PreferdDate
        {
            get
            {
                return dPreferdDate;
            }
            set
            {
                dPreferdDate = value;
            }
        }
        public DateTime UserDate
        {
            get
            {
                return dUserDate;
            }
            set
            {
                dUserDate = value;
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
        public int ResgntnId
        {
            get
            {
                return intResignationId;
            }
            set
            {
                intResignationId = value;
            }
        }

        public int ResgntnSts
        {
            get
            {
                return intResgntnSts;
            }
            set
            {
                intResgntnSts = value;
            }
        }

    }
}
