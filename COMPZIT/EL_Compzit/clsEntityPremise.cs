using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:06/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Premise .

namespace EL_Compzit
{
   public class clsEntityPremise
    {
        private  string strPremiseName = null;
        private  string strCancelreason = null;
        private  int intOrgid = 0;
        private  int intCorpOffice = 0;
        private  DateTime ddate;
        private  int intUserId = 0;
        public  int intStatus = 0;
        private  int? intDeptId = 0;
        private  int intMasterId = 0;
        private int intCancelStatus = 0;
        private string strCommonSearchTerm = "";
        private string strSearchPremise = "";
        private string strSearchDepartment = "";
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
        public string SearchDepartment
        {
            get
            {
                return strSearchDepartment;
            }
            set
            {
                strSearchDepartment = value;
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
        //Method for storing Premise name
        public string Premise_Name
        {
            get
            {
                return strPremiseName;
            }
            set
            {
                strPremiseName = value;
            }
        }
        //Method for storing Premise cancel reason
        public string Premise_Cancel_reason
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
        //Method for storing Premise master id.
        public int Premise_Master_Id
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
        //Method of storing the Status of the premise
        public int Premise_Status
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
    }
}