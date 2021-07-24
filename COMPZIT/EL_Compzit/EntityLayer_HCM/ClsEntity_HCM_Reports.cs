using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    class ClsEntity_HCM_Reports
    {
    }

    public class clsEntity_Mess_Bill_Report
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intAccomoDationId = 0;
        private int intMessBillId = 0;
        private int intEmpId = 0;
        private decimal intTotalAmount = 0;
        private int intCancelStatus = 0;
        private DateTime dtFromdate;
        private DateTime dtTodate;
        private string strcancelReason = "";
        private int intDivId = 0;
        private int intDeptId = 0;
        
        /// <summary>
        
        /// </summary>
        public int DivsnId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }

        public int DeptId
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
        //method for storing mess bill id
        public decimal TotalAmount
        {
            get
            {
                return intTotalAmount;
            }
            set
            {
                intTotalAmount = value;
            }
        }
        //method for storing mess bill id
        public int EmpId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
        //method for storing mess bill id
        public int MessBillId
        {
            get
            {
                return intMessBillId;
            }
            set
            {
                intMessBillId = value;
            }
        }
        //method for storing bill id
        public int AccomoDationId
        {
            get
            {
                return intAccomoDationId;
            }
            set
            {
                intAccomoDationId = value;
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

        //Method for storing the to date.
        public DateTime Todate
        {
            get
            {
                return dtTodate;
            }
            set
            {
                dtTodate = value;
            }
        }
        //Method for storing the from date.
        public DateTime Fromdate
        {
            get
            {
                return dtFromdate;
            }
            set
            {
                dtFromdate = value;
            }
        }
    }


    public class clsEntityManpwr_Process_Report
    {
        private int intUserId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intManpwrId = 0;
        private int intDivId = 0;
        private int intDeptId = 0;
        private int intPrjctId = 0;
        private string intEmpId = "";

        private string strStsChk = "";

        private DateTime dtFromDate=DateTime.MinValue;
        private DateTime dtToDate = DateTime.MinValue;

        public DateTime FromDate
        {
            get
            {
                return dtFromDate;
            }
            set
            {
                dtFromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dtToDate;
            }
            set
            {
                dtToDate = value;
            }
        }

        public string EmpId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
 

        public int PrjctId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
            }
        }
        public string StsChk
        {
            get
            {
                return strStsChk;
            }
            set
            {
                strStsChk = value;
            }
        }
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

        public int CorpId
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

        public int OrgId
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

        public int ManPwrId
        {
            get
            {
                return intManpwrId;
            }
            set
            {
                intManpwrId = value;
            }
        }

        public int DivsnId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }

        public int DeptId
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




    }

    public class clsEntity_Leave_Management_Report
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
        private string strLeaveDesc = "";
        private int intLeaveTypeMasterId = 0;

        private int intTravel = 0;
        private int intpaidLeave = 0;
        private int intCalendar = 0;
        private int intdesig_id = 0;
        private int intpay_id = 0;
        private int intexperid = 0;
        private int intDesig = 0;
        private int intdesigStatus = 0;
        private int intPaygrade = 0;
        private int intPaygradestatus = 0;
        private int intExperience = 0;
        private int intExperiencestatus = 0;
        private int intsex = 0;
        private int intMarital = 0;
        private int intleaveId = 0;

        private int intSettlmtSts = 0;
        private int intMonthly = 0;
        private int intDEPID = 0;
        private int intDivId = 0;


        private DateTime dtFromDate = DateTime.MinValue;
        private DateTime dtToDate = DateTime.MinValue;


        public int DivId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dtFromDate;
            }
            set
            {
                dtFromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dtToDate;
            }
            set
            {
                dtToDate = value;
            }
        }


        public int DepId
        {
            get
            {
                return intDEPID;
            }
            set
            {
                intDEPID = value;
            }
        }
        public int Monthly
        {
            get
            {
                return intMonthly;
            }
            set
            {
                intMonthly = value;
            }
        }
        public int SettlmtSts
        {
            get
            {
                return intSettlmtSts;
            }
            set
            {
                intSettlmtSts = value;
            }
        }

        public int intdesigbation_id
        {
            get
            {
                return intdesig_id;
            }
            set
            {
                intdesig_id = value;
            }
        }
        public int intpaygrade_id
        {
            get
            {
                return intpay_id;
            }
            set
            {
                intpay_id = value;
            }
        }

        public int experience_id
        {
            get
            {
                return intexperid;
            }
            set
            {
                intexperid = value;
            }
        }
        public int intleave
        {
            get
            {
                return intleaveId;
            }
            set
            {
                intleaveId = value;
            }
        }

        public int intTravelNeeded
        {
            get
            {
                return intTravel;
            }
            set
            {
                intTravel = value;
            }
        }

        public int intPaidLeave
        {
            get
            {
                return intpaidLeave;
            }
            set
            {
                intpaidLeave = value;
            }
        }

        public int intCalendarRb
        {
            get
            {
                return intCalendar;
            }
            set
            {
                intCalendar = value;
            }
        }
        public int intDesignation
        {
            get
            {
                return intDesig;
            }
            set
            {
                intDesig = value;
            }
        }
        public int intDesignationStatus
        {
            get
            {
                return intdesigStatus;
            }
            set
            {
                intdesigStatus = value;
            }
        }

        public int intpaygrade
        {
            get
            {
                return intPaygrade;
            }
            set
            {
                intPaygrade = value;
            }
        }


        public int intpaygradestatus
        {
            get
            {
                return intPaygradestatus;
            }
            set
            {
                intPaygradestatus = value;
            }
        }
        public int intexperiences
        {
            get
            {
                return intExperience;
            }
            set
            {
                intExperience = value;
            }
        }
        public int intexperiencesstatus
        {
            get
            {
                return intExperiencestatus;
            }
            set
            {
                intExperiencestatus = value;
            }
        }

        public int intsexRb
        {
            get
            {
                return intsex;
            }
            set
            {
                intsex = value;
            }
        }

        public int MaritalStatus
        {
            get
            {
                return intMarital;
            }
            set
            {
                intMarital = value;
            }
        }


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
        public string LeaveDesc
        {
            get
            {
                return strLeaveDesc;
            }
            set
            {
                strLeaveDesc = value;
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
