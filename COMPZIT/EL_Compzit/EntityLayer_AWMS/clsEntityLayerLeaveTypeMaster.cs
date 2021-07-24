using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0008
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerLeaveTypeMaster
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intStatus = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strSearchField = null;
       

        private string strCardNumber = "";
   

       
        private int intNoOfDays = 0;
    
        private string strLeaveName = "";
        
        private int intLeaveTypeMasterId = 0;


        //methode of watercard master id storing
        public int LeaveTypeMasterId
        {
            get
            {
                return intLeaveTypeMasterId;
            }
            set
            {
                intLeaveTypeMasterId = value;
            }
        }
      
        //methode of card name storing
        public string LeaveTypeName
        {
            get
            {
                return strLeaveName;
            }
            set
            {
                strLeaveName = value;
            }
        }
        
        //methode of vehicle number storing
        public int NoOfDays
        {
            get
            {
                return intNoOfDays;
            }
            set
            {
                intNoOfDays = value;
            }
        }
       
   
     
      
        //methode of Card Number storing
        public string CardNumber
        {
            get
            {
                return strCardNumber;
            }
            set
            {
                strCardNumber = value;
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
      
    }
}