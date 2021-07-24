
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0008
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerHolidayMaster
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private int intclassId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strSearchField = null;
        private string strDataBaseField = null;

        private string strHolidayTitle = "";
        private DateTime dateHolidayDate;
        private int intHolModeId = 0;
        private int intHolconfsts = 0;
        
        private int intHolTypeId = 0;
        private int intHolYear = 0;



        //methode for holiday confirmation
        public int HOlConfmn
        {
            get
            {
                return intHolconfsts;
            }
            set
            {
                intHolconfsts = value;
            }
        }

        //methode for holiday confirmation
        public int HOlYear
        {
            get
            {
                return intHolYear;
            }
            set
            {
                intHolYear = value;
            }
        }
       
      
    
        //methode of vehicle number storing
        public int HOlTypeId
        {
            get
            {
                return intHolTypeId;
            }
            set
            {
                intHolTypeId = value;
            }
        }
       
      
        //methode of bank id storing
        public int HolModeId
        {
            get
            {
                return intHolModeId;
            }
            set
            {
                intHolModeId = value;
            }
        }
        //methode of Card expiry date storing
        public DateTime HolidayDate
        {
            get
            {
                return dateHolidayDate;
            }
            set
            {
                dateHolidayDate = value;
            }
        }
        //methode of Card Number storing
        public string HolidayTitle
        {
            get
            {
                return strHolidayTitle;
            }
            set
            {
                strHolidayTitle = value;
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

        public int Holdy_Id
        {
            get
            {
                return intclassId;
            }
            set
            {
                intclassId = value;
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
        //methode of provider type id storing
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

        //methode of provider name storing
        public string SearchField
        {
            get
            {
                return strSearchField;
            }
            set
            {
                strSearchField = value;
            }
        }
        //methode of provider name storing
        public string DataBase_Field
        {
            get
            {
                return strDataBaseField;
            }
            set
            {
                strDataBaseField = value;
            }
        }
    }
}
