using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayer_Payment_Closing
    {
        private int intuserId=0;
        private int intOrgId=0;
        private int intCorprtId=0;
        private int intuserType=0;
        private int intMonth=0;
        private int intYear=0;
        private int intMode=0;
        private int intSavConf=0;
        private int intBusnsUnit=0;
        private int intCloseId = 0;
        private DateTime dDate;
        private decimal decPaidAmnt=0;
        private string strMonth = "";

        public string SMonth
        {
            get
            {
                return strMonth;
            }
            set
            {
                strMonth = value;
            }
        }

        public decimal PaidAmnt
        {
            get
            {
                return decPaidAmnt;
            }
            set
            {
                decPaidAmnt = value;
            }
        }
        public int BusnsUnitId
        {
            get
            {
                return intBusnsUnit;
            }
            set
            {
                intBusnsUnit = value;
            }
        }
        public int CloseId
        {
            get
            {
                return intCloseId;
            }
            set
            {
                intCloseId = value;
            }
        }
        public DateTime date
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






        public int UserId
        {
            get
            {
                return intuserId;
            }
            set
            {
                intuserId = value;
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
        public int CorprtId
        {
            get
            {
                return intCorprtId;
            }
            set
            {
                intCorprtId = value;
            }
        }
        public int Staff_Worker
        {
            get
            {
                return intuserType;
            }
            set
            {
                intuserType = value;
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
        public int SavConf
        {
            get
            {
                return intSavConf;
            }
            set
            {
                intSavConf = value;
            }
        }
    }
}
