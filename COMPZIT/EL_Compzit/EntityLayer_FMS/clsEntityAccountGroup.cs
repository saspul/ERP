using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityAccountGroup
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intAccGrpId = 0;
        private string strGrpName = "";
        private int intParntAccGrpId = 0;
        private int intNatureId = 0;
        private int intType = 0;
        private int intGrpSts = 0;
        private int intInsType = 0;
        private int intUsrId = 0;
        private string strCnclRsn = "";
        private int intGP =0;
        private int intCancelStatus = 0;
        private int intAddressStatus = 0;
        private string strGrpCode = "";

        private int intCodeSts = 0;
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
        public int AddressStatus
        {
            get
            {
                return intAddressStatus;
            }
            set
            {
                intAddressStatus = value;
            }
        }
        public int Cancel_status
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
        public int Affect_Gross_Profit
        {
            get
            {
                return intGP;
            }
            set
            {
                intGP = value;
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
        public int AccountGrpId
        {
            get
            {
                return intAccGrpId;
            }
            set
            {
                intAccGrpId = value;
            }
        }
        public string AccountGrpName
        {
            get
            {
                return strGrpName;
            }
            set
            {
                strGrpName = value;
            }
        }
        public int ParentAccountGrpId
        {
            get
            {
                return intParntAccGrpId;
            }
            set
            {
                intParntAccGrpId = value;
            }
        }
        public int NatureId
        {
            get
            {
                return intNatureId;
            }
            set
            {
                intNatureId = value;
            }
        }
        public int NatureType
        {
            get
            {
                return intType;
            }
            set
            {
                intType = value;
            }
        }
        public int GroupStatus
        {
            get
            {
                return intGrpSts;
            }
            set
            {
                intGrpSts = value;
            }
        }
        public int InsertType
        {
            get
            {
                return intInsType;
            }
            set
            {
                intInsType = value;
            }
        }
        public string CancelReason
        {
            get
            {
                return strCnclRsn;
            }
            set
            {
                strCnclRsn = value;
            }
        }
        public int UserId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
    }
}
