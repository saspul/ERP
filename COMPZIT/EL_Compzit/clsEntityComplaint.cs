using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:02/11/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Complaint master .

namespace EL_Compzit
{
  public class clsEntityComplaint
    {

      private int intMasterId = 0;
        private string strComplaintDesc = "";
        private int intCtgryId = 0;
        private decimal decPenalty = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intStatus = 0;     
        private int intCancelStatus = 0;
        private string strCancelreason = "";

        private string strCommonSearchTerm = "";
        private string strSearchComplaint = "";
        private string strSearchCategory = "";
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
        public string SearchComplaint
        {
            get
            {
                return strSearchComplaint;
            }
            set
            {
                strSearchComplaint = value;
            }
        }
        public string SearchCategory
        {
            get
            {
                return strSearchCategory;
            }
            set
            {
                strSearchCategory = value;
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
        //Method for storing Complaint master id.
        public int Complaint_Master_Id
        {
            get
            {
                return intMasterId;
            }
            set
            {
                intMasterId = value;
            }
        }
        //Method for storing Complaint Description
        public string ComplaintDesc
        {
            get
            {
                return strComplaintDesc;
            }
            set
            {
                strComplaintDesc = value;
            }
        }

        //Method for storing Ctgry id.
        public int CtgryId
        {
            get
            {
                return intCtgryId;
            }
            set
            {
                intCtgryId = value;
            }
        }
        //methode  storing Penalty
        public decimal Penalty
        {
            get
            {
                return decPenalty;
            }
            set
            {
                decPenalty = value;
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
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }
        //Method of storing the Status of the Complaint
        public int Complaint_Status
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
        //methode of cancel status storing
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

        //Method for storing Complaint cancel reason
        public string Complaint_Cancel_reason
        {
            get
            {
                return strCancelreason;
            }
            set
            {
                strCancelreason = value;
            }
        }

        
    }
}
