using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public  class clsEntity_AccountSettings
    {
        private int intOrgid = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
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

    }
}
