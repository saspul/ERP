using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EL_Compzit.EntityLayer_HCM
{
  public  class ClsEntity_Staff_Contact_Details
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intStaffCntId = 0;
        private int intCandId = 0;
        private string strStaffPermntAddrs = "";
        private string strStaffEmrgncyCntct = "";
        private DateTime dDate;
        private string strCancelReason = "";
        private int Accomdtn_Id = 0;
        private int Recruited_Id = 0;
        private int Sponser_Id = 0;


        public int OrgId
        {
            get { return intOrgId; }
            set { intOrgId = value; }

        }

        public int corpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }


        }
        public int UserId
        {
            get { return intUserId; }
            set { intUserId = value; }

        }


        public int StaffContact_id
        {
            get { return intStaffCntId; }
            set { intStaffCntId = value; }
        }

        public int CandidadteId
        {
            get { return intCandId; }
            set { intCandId = value; }

        }

        public string StaffPermanentAdd
        {
            get { return strStaffPermntAddrs; }
            set { strStaffPermntAddrs = value; }
        }

        public string EmergencyContact 
        {
            get { return strStaffEmrgncyCntct; }
            set { strStaffEmrgncyCntct = value; }
        }

        public DateTime Date
        {
            get { return dDate; }
            set { dDate = value; }
        }


        public string CancelReason
        {
            get { return strCancelReason; }
            set { strCancelReason = value; }
        }
        public int Accomdation 
        {
            get { return Accomdtn_Id; }
            set { Accomdtn_Id = value; }
        }

        public int Recruted
        {
            get { return Recruited_Id; }
            set { Recruited_Id = value; }
        }

        public int Sponser
        {

            get { return Sponser_Id; }
            set { Sponser_Id = value; }
        
        }
    }
}
