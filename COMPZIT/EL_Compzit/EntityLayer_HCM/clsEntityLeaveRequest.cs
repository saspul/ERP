using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLeaveRequest
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
        private string strDescription = null;   //emp25

        private DateTime dateLeaveFrmDate;
        private DateTime dateLeaveToDate;
        private int intLeavFrmSecnId = 0;
        private int intLevconfsts = 0;
        private int intLevTrvlsts = 0;  //emp25

        private int intLeavToSecnId = 0;
        private decimal intNumOfLeav = 0;
        private decimal decRemingLev = 0;
        private int intYearSrch = 0;
        private int intStatsSrch = 0;
        private decimal decOpeningLv = 0;

       //start:-For Travel Details
        private int intMulDays = 0;
        private DateTime dDateTrvl;
        private DateTime dDateRetrn;
        private string strDestn = null;
        private string strAirlnPrfrd = null;
        private int intDepentId = 0;
        private string strAddress = null;
        private string strTeleNo = null;
        private string strLclcontctNo = null;
        private string strEmail = null;
        private string strCmnt = null;
        private int intTcktNeeded = 0;
        private int intShowTrvldtls = 0;

        private int intLeaveRqstId = 0;
        private DateTime dateDate;

        private decimal decNumOfLeave = 0;
        private decimal decBalaLeaveNum = 0;
        private int intPaidLvStatus = 0;

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
        public decimal NumOfLeaveNew
        {
            get
            {
                return decNumOfLeave;
            }
            set
            {
                decNumOfLeave = value;
            }
        }
        public decimal BalaLeaveNumNew
        {
            get
            {
                return decBalaLeaveNum;
            }
            set
            {
                decBalaLeaveNum = value;
            }
        }


        public DateTime date
        {
            get
            {
                return dateDate;
            }
            set
            {
                dateDate = value;
            }
        }
        public int LeaveRqstId
        {
            get
            {
                return intLeaveRqstId;
            }
            set
            {
                intLeaveRqstId = value;
            }
        }
        public int ShowTrvlDtls
        {
            get
            {
                return intShowTrvldtls;
            }
            set
            {
                intShowTrvldtls = value;
            }
        }
        public int TcketNeeded
        {
            get
            {
                return intTcktNeeded;
            }
            set
            {
                intTcktNeeded = value;
            }
        }
        public int DepndtId
        {
            get
            {
                return intDepentId;
            }
            set
            {
                intDepentId = value;
            }
        }
        public int MulDaysChk
        {
            get
            {
                return intMulDays;
            }
            set
            {
                intMulDays = value;
            }
        }
        public DateTime DateOfTrvl
        {
            get
            {
                return dDateTrvl;
            }
            set
            {
                dDateTrvl = value;
            }
        }
        public DateTime DateOfRetrn
        {
            get
            {
                return dDateRetrn;
            }
            set
            {
                dDateRetrn = value;
            }
        }
        public string Destination
        {
            get
            {
                return strDestn;
            }
            set
            {
                strDestn = value;
            }
        }
        public string AirlinePrfrd
        {
            get
            {
                return strAirlnPrfrd;
            }
            set
            {
                strAirlnPrfrd = value;
            }
        }
        public string Address
        {
            get
            {
                return strAddress;
            }
            set
            {
                strAddress = value;
            }
        }

        public string TeleNo
        {
            get
            {
                return strTeleNo;
            }
            set
            {
                strTeleNo = value;
            }
        }
        public string LocalCntctNo
        {
            get
            {
                return strLclcontctNo;
            }
            set
            {
                strLclcontctNo = value;
            }
        }
        public string Email
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
        public string Comment
        {
            get
            {
                return strCmnt;
            }
            set
            {
                strCmnt = value;
            }
        }
        //End:-For Travel Details
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
        public string Description   //emp25
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
        public int TravelStatus   //emp25
        {
            get
            {
                return intLevTrvlsts;
            }
            set
            {
                intLevTrvlsts = value;
            }
        }
       
    }
}
