using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_AWMS
{
  public  class ClsEntityExpiryNotificationReport
    {


        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intDoctype = 0;
      //EVM-0027
        private int intStatus = 0;
        private int intDocStatus = 0;
        private int intDivId = 0;
        private int intDeptId = 0;
        private DateTime DFromDt;
        private DateTime DToDate;
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
        public int DocStatus 
        {
            get
            {
                return intDocStatus;
            }
            set
            {
                intDocStatus = value;
            }
        }
        public int DivsnId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }

        public int DeptId
        {
            get
            {
                return intDeptId;
            }
            set
            {
                intDeptId = value;
            }
        }

        public DateTime FromDt
        {
            get
            {
                return DFromDt;
            }
            set
            {
                DFromDt = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return DToDate;
            }
            set
            {
                DToDate = value;
            }
        }
      //END
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

        //methode of storing the division id
        public int Document_Type
        {
            get
            {
                return intDoctype;
            }
            set
            {
                intDoctype = value;
            }
        }

    }
}
