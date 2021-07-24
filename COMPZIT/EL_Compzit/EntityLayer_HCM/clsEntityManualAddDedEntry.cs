using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityManualAddDedEntry
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intCancelStatus = 0;
        private string strcancelReason = "";
        private int intStatusId = 0;
        private int intConfStatusId = 0;

        private int intMasterTabId = 0;
        private int intMonthId = 0;
        private int intYearId = 0;
        private string strFileName = "";
        private string strActFileName = "";
        private int intSubTabId = 0;
        private int intEmployeeId = 0;
        private int intAddDedId = 0;
        private int intCurrencyId = 0;
        private decimal decAmount = 0;

        //----------------Pageination--------------------

        private string strCommonSearchTerm = "";
        private string strSearcMonth = "";
        private string strSearchYear = "";
        private string strSearchNumEmp = "";
        private string strSearchInsDate = "";
        private string strSearchInsTime = "";
        private string strSearchStatus = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        private DateTime dStartDate;
        private DateTime dEndDate;
        private string strDescription = "";
        private int intDescChangeSts = 0;
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }
        public int DescChangeSts
        {
            get
            {
                return intDescChangeSts;
            }
            set
            {
                intDescChangeSts = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return dStartDate;
            }
            set
            {
                dStartDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return dEndDate;
            }
            set
            {
                dEndDate = value;
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
        public string searcMonth
        {
            get
            {
                return strSearcMonth;
            }
            set
            {
                strSearcMonth = value;
            }
        }
        public string SearchYear
        {
            get
            {
                return strSearchYear;
            }
            set
            {
                strSearchYear = value;
            }
        }
        public string SearchNumEmp
        {
            get
            {
                return strSearchNumEmp;
            }
            set
            {
                strSearchNumEmp = value;
            }
        }
        public string SearchInsDate
        {
            get
            {
                return strSearchInsDate;
            }
            set
            {
                strSearchInsDate = value;
            }
        }
        public string SearchInsTime
        {
            get
            {
                return strSearchInsTime;
            }
            set
            {
                strSearchInsTime = value;
            }
        }
        public string SearchStatus
        {
            get
            {
                return strSearchStatus;
            }
            set
            {
                strSearchStatus = value;
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
        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        public string ActFileName
        {
            get
            {
                return strActFileName;
            }
            set
            {
                strActFileName = value;
            }
        }     
        public decimal Amount
        {
            get
            {
                return decAmount;
            }
            set
            {
                decAmount = value;
            }
        }
        public int MasterTabId
        {
            get
            {
                return intMasterTabId;
            }
            set
            {
                intMasterTabId = value;
            }
        }
        public int MonthId
        {
            get
            {
                return intMonthId;
            }
            set
            {
                intMonthId = value;
            }
        }
        public int YearId
        {
            get
            {
                return intYearId;
            }
            set
            {
                intYearId = value;
            }
        }
        public int SubTabId
        {
            get
            {
                return intSubTabId;
            }
            set
            {
                intSubTabId = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }
        public int AddDedId
        {
            get
            {
                return intAddDedId;
            }
            set
            {
                intAddDedId = value;
            }
        }
        public int CurrencyId
        {
            get
            {
                return intCurrencyId;
            }
            set
            {
                intCurrencyId = value;
            }
        }

        public int ConfStatusId
        {
            get
            {
                return intConfStatusId;
            }
            set
            {
                intConfStatusId = value;
            }
        }
        public int StatusId
        {
            get
            {
                return intStatusId;
            }
            set
            {
                intStatusId = value;
            }
        }
        //method for storing cancel reason
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
        //method for storing cancel reason
        public string cancelReason
        {
            get
            {
                return strcancelReason;
            }
            set
            {
                strcancelReason = value;
            }
        }       
        //method for storing bill id
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
    }
}
