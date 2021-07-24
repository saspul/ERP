using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
   public class clsEntityLayer_Cost_Center
    {
        private int intCostId = 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private string strName = null;
        private int intStatus = 0;
        private int intCancl_Status = 0;
        private string strCancelReason = null;
        private decimal decimalBalance = 0;
        private int intDCStatus = -1;
        private int intgrpId = 0;
        private int intNature = 0;


        private string strGrpCode = "";

        private int intCodeSts = 0;

        private int intCodePrsntSts = 0;
        public int CodePrsntSts
        {
            get
            {
                return intCodePrsntSts;
            }
            set
            {
                intCodePrsntSts = value;
            }
        }




        public int CodeSts
        {
            get
            {
                return intCodeSts;
            }
            set
            {
                intCodeSts = value;
            }
        }
        public string GrpCode
        {
            get
            {
                return strGrpCode;
            }
            set
            {
                strGrpCode = value;
            }
        }

        public int Nature
        {
            get
            {
                return intNature;
            }
            set
            {
                intNature = value;
            }
        }
        public int CostId
        {
            get
            {
                return intCostId;
            }
            set
            {
                intCostId = value;
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
        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
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
        public int Org_Id
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
        public int Corp_Id
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
        public int Cancl_Status
        {
            get
            {
                return intCancl_Status;
            }
            set
            {
                intCancl_Status = value;
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
        public decimal Balance
        {
            get
            {
                return decimalBalance;
            }
            set
            {
                decimalBalance = value;
            }
        }
        public int DCStatus
        {
            get
            {
                return intDCStatus;
            }
            set
            {
                intDCStatus = value;
            }
        }
        public int grpId
        {
            get
            {
                return intgrpId;
            }
            set
            {
                intgrpId = value;
            }
        }
    }
}
