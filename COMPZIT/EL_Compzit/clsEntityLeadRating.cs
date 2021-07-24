using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// CREATED BY:WEM-0006
// CREATED DATE:17/08/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Lead rating Master .
namespace EL_Compzit
{
   public class clsEntityLeadRating
    {
        private int intLeadRateId = 0;
        private int intLeadRateCancel = 0;
        private string strLeadRateName = "";
        private int intStatus = 0;
        private int intUserId;
        private string strCnclReason = "";
        private DateTime dateofEvent;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intCancelStatus = 0;
        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        public string CommonSearchTerm
        {
            get
            {
                return strCommonSearchTerm;
            }
            set
            {
                strCommonSearchTerm = value;
            }
        }
        public string SearchName
        {
            get
            {
                return strSearchName;
            }
            set
            {
                strSearchName = value;
            }
        }
        public int OrderColumn
        {
            get
            {
                return intOrderColumn;
            }
            set
            {
                intOrderColumn = value;
            }
        }
        public int OrderMethod
        {
            get
            {
                return intOrderMethod;
            }
            set
            {
                intOrderMethod = value;
            }
        }
        public int PageMaxSize
        {
            get
            {
                return intPageMaxSize;
            }
            set
            {
                intPageMaxSize = value;
            }
        }
        public int PageNumber
        {
            get
            {
                return intPageNumber;
            }
            set
            {
                intPageNumber = value;
            }
        }
        //----------------Pageination--------------------
        //method of cancel status storing
        public int Cancel_Status
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


        // This is the property definition for storing Id of LeadRating Master.
        public int LeadRateId
        {
            get
            {
                return intLeadRateId;
            }
            set
            {
                intLeadRateId = value;
            }
        }
        //Storing the LeadRate id when it get cancel event.
        public int LeadRateCancelId
        {
            get
            {
                return intLeadRateCancel;
            }
            set
            {
                intLeadRateCancel = value;
            }
        }
        // This is the property definition for storing UserId of the User logined.
        public int LeadRateUserId
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

        // This is the property definition for storing Status of LeadRate Master.
        public int LeadRateStatus
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
        // This is the property definition for storing LeadRate name entered .
        public string LeadRateName
        {
            get
            {
                return strLeadRateName;
            }
            set
            {
                strLeadRateName = value;
            }
        }
        // This is the property definition for storing Cancelation reason .
        public string LeadRateCancelReason
        {
            get
            {
                return strCnclReason;
            }
            set
            {
                strCnclReason = value;
            }
        }
        // This is the property definition for storing Date of updation and cancelation .
        public DateTime LeadRateDate
        {
            get
            {
                return dateofEvent;
            }
            set
            {
                dateofEvent = value;
            }
        }

        //Method for storing organistion id.
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

    }
}
