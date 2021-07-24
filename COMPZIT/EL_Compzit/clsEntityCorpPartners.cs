using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
   public class clsEntityCorpPartners
    {
        
        private string strDocumentNo = "";
        private int intPartnerId = 0;
        private decimal decSharePer = 0;

        private int intCorp_PartnerId = 0;

        public int Corp_PartnerId
        {
            get
            {
                return intCorp_PartnerId;
            }
            set
            {
                intCorp_PartnerId = value;
            }
        }

        public string DocumentNo
        {
            get
            {
                return strDocumentNo;
            }
            set
            {
                strDocumentNo = value;
            }
        }

        public int PartnerId
        {
            get
            {
                return intPartnerId;
            }
            set
            {
                intPartnerId = value;
            }
        }

        public decimal SharePerc
        {
            get
            {
                return decSharePer;
            }
            set
            {
                decSharePer = value;
            }
        }
    }
}
