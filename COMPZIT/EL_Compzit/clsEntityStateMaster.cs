using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:16/05/2015
// REVIEWED BY:
// REVIEW DATE
namespace EL_Compzit
{
    public class clsEntityStateMaster
    {
        private  string strStateName = null;
        private  int intStateCountryId = 0;
        private  int intStateStatus = 0;
        private  string strStateCancelReason = null;
        private int intUserId = 0;
        private int intStateMasterId = 0;
        private int intStateCancelId = 0;
        private DateTime strDate;
        private int intPreinstall = 0;


        private string strCommonSearchTerm = "";
        private string strSearchCountry = "";
        private string strSearchState = "";
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
        public string SearchState
        {
            get
            {
                return strSearchState;
            }
            set
            {
                strSearchState = value;
            }
        }
        public string SearchCountry
        {
            get
            {
                return strSearchCountry;
            }
            set
            {
                strSearchCountry = value;
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

        //Method for storing state name.
        public string StateName
        {
            get
            {
                return strStateName;
            }
            set
            {
                strStateName = value;
            }
        }
        //Method for storing state include country name.
        public int StateCountryId
        {
            get
            {
                return intStateCountryId;
            }
            set
            {
                intStateCountryId = value;
            }
        }
        //Method for storing state status(active or inactive).
        public int StateStatus
        {
            get
            {
                return intStateStatus;
            }
            set
            {
                intStateStatus = value;
            }
        }
        //Method for storing Reason for state cancel if any.
        public string StateCancelReason
        {
            get
            {
                return strStateCancelReason;
            }
            set
            {
                strStateCancelReason = value;
            }
        }
        //Method for storing UserId of Proceding Person.
        public int UserId
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
        //Method for storing Id in the state master table.
        public int StateMasterId
        {
            get
            {
                return intStateMasterId;
            }
            set
            {
                intStateMasterId = value;
            }
        }
        //Method for storing Id in the state that get cancel event.
        public int StateCancelId
        {
            get
            {
                return intStateCancelId;
            }
            set
            {
                intStateCancelId = value;
            }
        }
        //Method for storing date of process.
        public DateTime Date
        {
            get
            {
                return strDate;
            }
            set
            {
                strDate = value;
            }
        }
        public int Preinstall
        {
            get
            {
                return intPreinstall;
            }
            set
            {
                intPreinstall = value;
            }
        }
    }
}
