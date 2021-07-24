using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityJobCostSummary_Report
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intPrjctId = 0;
        private int intCrncyId = 0;

        private int intDivisionId = 0;
        private int intMonth = 0;
        private int intYear = 0;

        public int DivisionId
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }
        public int Month
        {
            get
            {
                return intMonth;
            }
            set
            {
                intMonth = value;
            }
        }

        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }

        public int CrncyId
        {
            get
            {
                return intCrncyId;
            }
            set
            {
                intCrncyId = value;
            }
        }

        public int PrjctId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
            }
        }

        public int Organisation_Id
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

        //methode of storing corporate office id
        public int Corporate_Id
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

        //methode of storing the user id
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
    }
}
