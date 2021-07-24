
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// CREATED BY:EVM-0008
// CREATED DATE:20/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace EL_Compzit.EntityLayer_AWMS
{
   public class clsEntityLayerLeaveAllocationMaster
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intEmplySrch = 0;
        private int intUserId = 0;
        private int intEmployeeId = 0;
        private int intclassId = 0;
        private int intLeavAllocn = 0;
      
        private DateTime dDate;
        private string strCancelReason = null;
        private int intCancelStatus = 0;
        private string strSearchField = null;
        private string strDataBaseField = null;

        
        private DateTime dateLeaveFrmDate;
        private DateTime dateLeaveToDate;
        private int intLeavFrmSecnId = 0;
        private int intLevconfsts = 0;

        private int intLeavToSecnId = 0;
        private decimal intNumOfLeav = 0;
        private decimal decRemingLev = 0;
        private int intYearSrch = 0;
        private int intStatsSrch = 0;
        private decimal decOpeningLv = 0;


        private int intPaidLvStatus = 0;

        private int intSettlmntEilgiblLeavAlloctn = 0;

        private string strEmployeeCode="";

        private int intDailyLeaveStatus=0;

        private int intLeaveRequestID=0;

        private int intLeavCatgry = 0;

        private int intLeaveSource = 0;
        public int LeaveSource
        {
            get { return intLeaveSource; }
            set { intLeaveSource = value; }
        }


        public int LeavCatgry
        {
            get { return intLeavCatgry; }
            set { intLeavCatgry = value; }
        }

        public int LeaveRequestID
        {
            get { return intLeaveRequestID; }
            set { intLeaveRequestID = value; }
        }



        public int DailyLeaveStatus
        {
            get { return intDailyLeaveStatus; }
            set { intDailyLeaveStatus = value; }
        }




        public string EmployeeCode
        {
            get { return strEmployeeCode; }
            set { strEmployeeCode = value; }
        }



        public int EilgiblLeaveAlloctnSts
        {
            get
            {
                return intSettlmntEilgiblLeavAlloctn;
            }
            set
            {
                intSettlmntEilgiblLeavAlloctn = value;
            }
        }


        public int PaidLvStatus
        {
            get
            {
                return intPaidLvStatus;
            }
            set
            {
                intPaidLvStatus = value;
            }
        }
        public decimal OpeningLv
        {
            get
            {
                return decOpeningLv;
            }
            set
            {
                decOpeningLv = value;
            }
        }
        public int StatsSrch
        {
            get
            {
                return intStatsSrch;
            }
            set
            {
                intStatsSrch = value;
            }
        }
        public int YearSrch
        {
            get
            {
                return intYearSrch;
            }
            set
            {
                intYearSrch = value;
            }
        }

        public decimal RemingLev
        {
            get
            {
                return decRemingLev;
            }
            set
            {
                decRemingLev = value;
            }
        }
       
        public int LeavAllocn
        {
            get
            {
                return intLeavAllocn;
            }
            set
            {
                intLeavAllocn = value;
            }
        }
        //methode of vehicle number storing
        public int LeaveToSection
        {
            get
            {
                return intLeavToSecnId;
            }
            set
            {
                intLeavToSecnId = value;
            }
        }
        //methode of Card expiry date storing
        public DateTime LeaveToDate
        {
            get
            {
                return dateLeaveToDate;
            }
            set
            {
                dateLeaveToDate = value;
            }
        }
        //methode of user id storing
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
        //methode for holiday confirmation
        public int LeaveConfmn
        {
            get
            {
                return intLevconfsts;
            }
            set
            {
                intLevconfsts = value;
            }
        }

        //methode for holiday confirmation
        public decimal NumOfLeave
        {
            get
            {
                return intNumOfLeav;
            }
            set
            {
                intNumOfLeav = value;
            }
        }
       
      
    
        //methode of vehicle number storing
        public int LeaveFromSection
        {
            get
            {
                return intLeavFrmSecnId;
            }
            set
            {
                intLeavFrmSecnId = value;
            }
        }
       
      
      
        //methode of Card expiry date storing
        public DateTime LeaveFrmDate
        {
            get
            {
                return dateLeaveFrmDate;
            }
            set
            {
                dateLeaveFrmDate = value;
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

        public int Leave_Id
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
        public int EmplySrch
        {
            get
            {
                return intEmplySrch;
            }
            set
            {
                intEmplySrch = value;
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
        public string searcEmpId
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
        public string SearchEmpName
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
        public string SearchLeaveType
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
        public string SearchFromDate
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
        public string SearchToDate
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



    }
}
