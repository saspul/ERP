using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityBalanceSheet
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;

        private int intLedgId = 0;
        private int intVoucherTyp = 0;

        private string strDescription = "";

        private int intshowZerosts = 0;
        public int ShowZerosts
        {
            get
            {
                return intshowZerosts;
            }
            set
            {
                intshowZerosts = value;
            }
        }
        private int intAccountGroupId = 0;
        public int AccountGroupId
        {
            get
            {
                return intAccountGroupId;
            }
            set
            {
                intAccountGroupId = value;
            }
        }

        //methode of Description
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
        public int VoucherTyp
        {
            get
            {
                return intVoucherTyp;
            }
            set
            {
                intVoucherTyp = value;
            }
        }
        public int LedgId
        {
            get
            {
                return intLedgId;
            }
            set
            {
                intLedgId = value;
            }
        }
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
    }
}
