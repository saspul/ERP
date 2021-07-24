using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:08/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the work station .

namespace EL_Compzit
{
    public class clsEntityWorkStation
    {
        private  string strStationName = null;
        private  string strCancelreason = null;
        private  int intOrgid = 0;
        private  int intCorpOffice = 0;
        private  int intPremiseId = 0;
        private  int intWorkAreaId = 0;
        private  DateTime ddate;
        private  int intUserId = 0;
        public  int intStatus = 0;
        private  int? intDeptId = 0;
        private  int intMasterId = 0;
        private int intWrkStnAssigned = 0;
        private int intMultipleInstance = 0;
        private int intCancelStatus = 0;

        private string strCommonSearchTerm = "";
        private string strSearchWorkstation = "";
        private string strSearchPremise = "";
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
        public string SearchWorkstation
        {
            get
            {
                return strSearchWorkstation;
            }
            set
            {
                strSearchWorkstation = value;
            }
        }
        public string SearchPremise
        {
            get
            {
                return strSearchPremise;
            }
            set
            {
                strSearchPremise = value;
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

        //method for storing multiple instatnce value
        public int Multiple_Instance
        {
            get
            {
                return intMultipleInstance;
            }
            set
            {
                intMultipleInstance = value;
            }
        }
        //Method for storing work station AssignStatus
        public int WorkStation_Assigned
        {
            get
            {
                return intWrkStnAssigned;
            }
            set
            {
                intWrkStnAssigned = value;
            }
        }
        //Method for storing work station name
        public string WorkStation_Name
        {
            get
            {
                return strStationName;
            }
            set
            {
                strStationName = value;
            }
        }
        //Method for storing work station cancel reason
        public string WorkStation_Cancel_reason
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
        //Method for storing Department id.
        public int? Department_Id
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
        //Method for storing work station master id.
        public int WorkStation_Master_Id
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
        //Method of storing the status of the work station
        public int WorkStation_Status
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
        //Method of storing the premise id
        public int PremiseId
        {
            get
            {
                return intPremiseId;
            }
            set
            {
                intPremiseId = value;
            }
        }
        //Method of storing the work area id
        public int WorkArea_Id
        {
            get
            {
                return intWorkAreaId;
            }
            set
            {
                intWorkAreaId = value;
            }
        }
    }
}
