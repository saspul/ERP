using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Accommodation_Cat
    {
        private int intUserId = 0;
        private DateTime dDate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intStatus = 0;
        private int intAccommodationCategoryId = 0;
        private string strAccommodatioCatName = "";
        private string strCancelReason = "";
        private int intCancelStat = 0;



        public int UserId
        {
            get { return intUserId; }

            set { intUserId = value; }
        }

        public DateTime Date
        {

            get { return dDate; }
            set { dDate = value; }

        }
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }


        public int OrgId
        {
            get { return intOrgId; }
            set { intOrgId = value; }

        }

        public int Status
        {

            get { return intStatus; }
            set { intStatus = value; }
        }
        public int AccommodationcatId
        {

            get { return intAccommodationCategoryId; }
            set { intAccommodationCategoryId = value; }
        }
        public string AccommodationName
        {


            get { return strAccommodatioCatName; }
            set { strAccommodatioCatName = value; }

        }


        public string CancelReason
        {

            get { return strCancelReason; }
            set { strCancelReason = value; }
        }


        public int CancelStatus
        {

            get { return intCancelStat; }
            set { intCancelStat = value; }
        }


    }


 public class cls_Entity_Accommodation_Category_list
    {
        private int intAccommodationsubCatsid = 0;
        private int intAccommodationsubCatStatus = 0;
        private string stringAccommodationsubCaName= "";

        public int Accommodationsubcategrysid
        {

            get { return intAccommodationsubCatsid; }
            set { intAccommodationsubCatsid = value; }

        }

        public int AccommodationSubCatStatus
        {


            get { return intAccommodationsubCatStatus; }
            set { intAccommodationsubCatStatus = value; }


        }
        public string AccommodationSubCatName
        {
            get { return stringAccommodationsubCaName; }
            set { stringAccommodationsubCaName = value; }

        }
    }
}
