using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public  class clsEntityRequirementAllocation
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intDeprt_Id = 0;
        private int intPrjctId = 0;
        private int intReqrmntAlctnId = 0;
        private int intReqrmntAlctnDtlId = 0;
        private int intReqrmntId = 0;
        private int intEmployeeId = 0;
        private int intSelfAlctnSts = 0;
        private DateTime dDate;
        public int SelfAlctnSts
        {
            get
            {
                return intSelfAlctnSts;
            }
            set
            {
                intSelfAlctnSts = value;
            }
        }
        public int ReqrmntAlctn_Id
        {
            get
            {
                return intReqrmntAlctnId;
            }
            set
            {
                intReqrmntAlctnId = value;
            }
        }
        public int ReqrmntAlctnDtl_Id
        {
            get
            {
                return intReqrmntAlctnDtlId;
            }
            set
            {
                intReqrmntAlctnDtlId = value;
            }
        }
        public int Reqrmnt_Id
        {
            get
            {
                return intReqrmntId;
            }
            set
            {
                intReqrmntId = value;
            }
        }
        public int Employee_Id
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        public int Deprt_Id
        {
            get
            {
                return intDeprt_Id;
            }
            set
            {
                intDeprt_Id = value;
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
        public int DivId
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
        public int Organisation_Id
        {
            get
            {
                return intOrgid;
            }
            set
            {
                intOrgid = value;
            }
        }


        //Method for storing Corporate office id.
        public int CorpOffice_Id
        {
            get
            {
                return intCorpOffice;
            }
            set
            {
                intCorpOffice = value;
            }
        }


        //Method for storing user id who do the event.
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
        //Method for storing the date when the event occurs.
        public DateTime D_Date
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

    }
}
