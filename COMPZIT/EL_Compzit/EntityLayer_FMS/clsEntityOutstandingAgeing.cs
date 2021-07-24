using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityOutstandingAgeing
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dToDate;

        private int intMode = 0;
        private int intFromAgeing = 0;
        private int intToAgeing = 0;

        private int intSplit1 = 0;
        private int intSplit2 = 0;
        private int intSplit3 = 0;
        private int intMethod2Mode = 0;
        private int intCustomerId = 0;

        private DateTime dFinYearToDate;
        private DateTime dFinYearFromDate;
        private int intCredit = 0;//0044
        private int intDueSts = 0;//0044
        public DateTime FinYearToDate
        {
            get
            {
                return dFinYearToDate;
            }
            set
            {
                dFinYearToDate = value;
            }
        }
        public DateTime FinYearFromDate
        {
            get
            {
                return dFinYearFromDate;
            }
            set
            {
                dFinYearFromDate = value;
            }
        }
        public int CustomerId
        {
            get
            {
                return intCustomerId;
            }
            set
            {
                intCustomerId = value;
            }
        }
        public int ToAgeing
        {
            get
            {
                return intToAgeing;
            }
            set
            {
                intToAgeing = value;
            }
        }
        public int Split1
        {
            get
            {
                return intSplit1;
            }
            set
            {
                intSplit1 = value;
            }
        }
        public int Split2
        {
            get
            {
                return intSplit2;
            }
            set
            {
                intSplit2 = value;
            }
        }
        public int Split3
        {
            get
            {
                return intSplit3;
            }
            set
            {
                intSplit3 = value;
            }
        }
        public int Method2Mode
        {
            get
            {
                return intMethod2Mode;
            }
            set
            {
                intMethod2Mode = value;
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
        public int FromAgeing
        {
            get
            {
                return intFromAgeing;
            }
            set
            {
                intFromAgeing = value;
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
        //---0044
        public int ByCredit
        {
            get
            {
                return intCredit ;
            }
            set
            {
                intCredit  = value;
            }
        }
        public int DueSts
        {
            get
            {
                return intDueSts ;
            }
            set
            {
                intDueSts  = value;
            }
        }
        //--0044
    }
}