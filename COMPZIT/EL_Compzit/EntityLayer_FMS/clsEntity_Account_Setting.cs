using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntity_Account_Setting
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intAccGrpId = 0;
        private string strMasterName = "";
      
        private int intUsrId = 0;
        private int intMasterId = 0;
        private int intLedgerId = 0;
        private int intFinancialYr = 0;
        private int intFinancialYrId = 0;
        private DateTime dtStratdate;
        private DateTime dtEnddate;
        private string strDefaultName = "";
        private int intModuleId = 0;
        private int intAccountNatureStatus = 0;
        private int intVersionId = 0;
        private int intVoucherId = 0;
        private int intPrmryGrpId = 0;
        private int intAsmodId = 0;
        private int intLdgrGrpSts = 0;


        public int LdgrGrpSts
        {
            get { return intLdgrGrpSts; }
            set { intLdgrGrpSts = value; }
        }
        public int AsmodId
        {
            get { return intAsmodId; }
            set { intAsmodId = value; }
        }
        public int PrimaryGrpId
        {
            get { return intPrmryGrpId; }
            set { intPrmryGrpId = value; }
        }
        public int VoucherID
        {
            get { return intVoucherId; }
            set { intVoucherId = value; }
        }
        public int VersionID
        {
            get { return intVersionId; }
            set { intVersionId = value; }
        }

        public int AccountNatureStatus
        {
            get { return intAccountNatureStatus; }
            set { intAccountNatureStatus = value; }
        }


        public int ModuleId
        {
            get
            {
                return intModuleId;
            }
            set
            {
                intModuleId = value;
            }
        }
        public int FinancialYearID
        {
            get
            {
                return intFinancialYrId;
            }
            set
            {
                intFinancialYrId = value;
            }
        }
        public int FinancialYearStatus
        {
            get
            {
                return intFinancialYr;
            }
            set
            {
                intFinancialYr = value;
            }
        }
        public string DefaultName
        {
            get
            {
                return strDefaultName;
            }
            set
            {
                strDefaultName = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return dtStratdate;
            }
            set
            {
                dtStratdate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return dtEnddate;
            }
            set
            {
                dtEnddate = value;
            }
        }
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
        public int MasterId
        {
            get
            {
                return intMasterId;
            }
            set
            {
                intMasterId = value;
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
        public string MasterName
        {
            get
            {
                return strMasterName;
            }
            set
            {
                strMasterName = value;
            }
        }
      

    }
}
