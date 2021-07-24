using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Emp_Welfare_Service_category
    {
        private int intOrgid = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private int intCatId = 0;
        private string strCatName = "";
        private string strDesc = "";
        private int intsts = 0;
        private string strCnclRsn = "";
        private int intCancelStatus = 0;
        public int Cancel_Status
        {
            get { return intCancelStatus; }
            set { intCancelStatus = value; }

        }
        public int OrgId
        {
            get { return intOrgid; }
            set { intOrgid = value; }

        }
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }
               
        public int UserId
        {
            get { return intUsrId; }

            set { intUsrId = value; }
        }

      
        public int CategoryId
        {
            get { return intCatId; }

            set { intCatId = value; }
        }
        public string categoryName
        {

            get { return strCatName; }
            set { strCatName = value; }
        }
        public string categoryDescription
        {

            get { return strDesc; }
            set { strDesc = value; }
        }
        public int Status
        {

            get { return intsts; }
            set { intsts = value; }
        } 
         public string CancelReason
        {

            get { return strCnclRsn; }
            set { strCnclRsn = value; }
        }
        
    }
}
