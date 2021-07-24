using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerPayslipGeneratn
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intMonth = 0;
        private int intYear = 0;
        private DateTime dtDate;

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

        public DateTime Date
        {
            get
            {
                return dtDate;
            }
            set
            {
                dtDate = value;
            }
        }







    }
}
