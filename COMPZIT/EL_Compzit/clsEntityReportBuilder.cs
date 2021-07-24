using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityReportBuilder
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intReportId = 0;


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

        public int ReportId
        {
            get
            {
                return intReportId;
            }
            set
            {
                intReportId = value;
            }
        }

    }
}
