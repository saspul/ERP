using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0009
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Accommodation master .
namespace EL_Compzit
{
  public  class clsEntityAccommodation
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private string strAccoAddress = "";
        private string strAccoName = "";
        private string strFloorName = "";
        private int intAccoType = 0;
        private int intAccoId = 0;
        private int intCancelStatus = 0;
        private int intSubcategoryId = 0;
        private int intHavMess = 0;
        private int intCordinatorId = 0;
        private int intNo_of_Sbscriber = 0;
        private int intFloorNo = 0;
        private int intNo_Of_Floor = 0;
        private string strLocation = null;
        private int intSubcategoryDetailId = 0;
        private string strBus= "";
        public string Bus
        {
            get
            {
                return strBus;
            }
            set
            {
                strBus = value;
            }
        }


        //methode storing floor name
        public string FloorName
        {
            get
            {
                return strFloorName;
            }
            set
            {
                strFloorName = value;
            }
        }
        //methode storing subcategory detail id
        public int SubcategoryDetailId
        {
            get
            {
                return intSubcategoryDetailId;
            }
            set
            {
                intSubcategoryDetailId = value;
            }
        }
        //methode storing sub category id
        public int SubcategoryId
        {
            get
            {
                return intSubcategoryId;
            }
            set
            {
                intSubcategoryId = value;
            }
        }
        //methode storing have mess or not
        public int HavMessId
        {
            get
            {
                return intHavMess;
            }
            set
            {
                intHavMess = value;
            }
        }
        //methode storing cordinator id
        public int CordinatorId
        {
            get
            {
                return intCordinatorId;
            }
            set
            {
                intCordinatorId = value;
            }
        }
        //methode storing number of subscriber
        public int No_of_Sbscriber
        {
            get
            {
                return intNo_of_Sbscriber;
            }
            set
            {
                intNo_of_Sbscriber = value;
            }
        }
        //methode storing floor number in the accomodation
        public int FloorNo
        {
            get
            {
                return intFloorNo;
            }
            set
            {
                intFloorNo = value;
            }
        }
        //methode storing no of floor in the accomodedation
        public int No_Of_Floor
        {
            get
            {
                return intNo_Of_Floor;
            }
            set
            {
                intNo_Of_Floor = value;
            }
        }
        //methode of location name storing
        public string Location
        {
            get
            {
                return strLocation;
            }
            set
            {
                strLocation = value;
            }
        }
        //methode of organisation id storing
        public int Organisation_id
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
        //methode of corporate id storing
        public int Corporate_id
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

        //methode of user id storing
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
        //methode of status id storing
        public int Status_id
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
        //methode of provider name storing
        public string AccoName
        {
            get
            {
                return strAccoName;
            }
            set
            {
                strAccoName = value;
            }
        }
        //methode of provider name storing
        public string AccoAddress
        {
            get
            {
                return strAccoAddress;
            }
            set
            {
                strAccoAddress = value;
            }
        }
        //methode of provider type id storing
        public int AccommodationId
        {
            get
            {
                return intAccoId;
            }
            set
            {
                intAccoId = value;
            }
        }
        //methode of provider type accommodation type storing
        public int AccommodationType
        {
            get
            {
                return intAccoType;
            }
            set
            {
                intAccoType = value;
            }
        }
        //methode of provider type date storing
        public DateTime Date
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

        //methode of provider name storing
        public string CancelReason
        {
            get
            {
                return strCancelReason;
            }
            set
            {
                strCancelReason = value;
            }
        }
        //methode of provider name storing
        public int CancelStatus
        {
            get
            {
                return intCancelStatus;
            }
            set
            {
                intCancelStatus = value;
            }
        }

      
    }
}
