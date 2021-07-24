using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0009
// CREATED DATE:13/12/2016
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Accommodation Type master .


namespace EL_Compzit
{
    public class clsEntityAccommodationType
    {
        private int intMasterId = 0;
        private string strAccmdtnTypeName = "";
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private DateTime ddate;
        private int intUserId = 0;
        public int intStatus = 0;
        private int intCancelStatus = 0;
        private string strCancelreason = "";

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        private string strSearchType = "";
        public string SearchType
        {
            get
            {
                return strSearchType;
            }
            set
            {
                strSearchType = value;
            }
        }
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
        //Method for storing Accommodation Type master id.
        public int AccommodatonType_Master_Id
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
        //Method for storing Accommodation Type Name
        public string AccommodationType_Name
        {
            get
            {
                return strAccmdtnTypeName;
            }
            set
            {
                strAccmdtnTypeName = value;
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
        //Method of storing the Status of the Accommodation Type
        public int AccommodationType_Status
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

        //Method for storing Accommodation Type cancel reason
        public string AccommmodationType_Cancel_reason
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
