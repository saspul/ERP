using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Leave_Type
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

        private string strDesgn = "";
        private string strPaygrade = "";
        private string strExperience = "";

        private int intEmployeeId = 0;

        private int intLeaveOnAbsence = 0;
        private int intApplicableNone = 0;
        private int intIndividualLeavTypId = 0;
        private string strIndLeavIds = "";
        private int intConfirmSts = 0;
        private int intCnclId = 0;
        private int intReopenSts = 0;
        private int intOverRideSts = 0;
        private decimal decNooFDays = 0;
        private int intExpMstrId = 0;
        private DateTime dFromDate;
        private int intYear;


        private int intIncDutyRejoin;
        private int intExcSalProc;
        private int intHoliPaid;
        private int intOffPaid;
        public int HoliPaid
        {
            get
            {
                return intHoliPaid;
            }
            set
            {
                intHoliPaid = value;
            }
        }
        public int OffPaid
        {
            get
            {
                return intOffPaid;
            }
            set
            {
                intOffPaid = value;
            }
        }

        public int IncDutyRejoin
        {
            get
            {
                return intIncDutyRejoin;
            }
            set
            {
                intIncDutyRejoin = value;
            }
        }
        public int ExcSalProc
        {
            get
            {
                return intExcSalProc;
            }
            set
            {
                intExcSalProc = value;
            }
        }




        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        public int ExpMstrId
        {
            get
            {
                return intExpMstrId;
            }
            set
            {
                intExpMstrId = value;
            }
        }
        public decimal OverRideDays
        {
            get
            {
                return decNooFDays;
            }
            set
            {
                decNooFDays = value;
            }
        }
        public int OverRideSts
        {
            get
            {
                return intOverRideSts;
            }
            set
            {
                intOverRideSts = value;
            }
        }
        public int ReopenSts
        {
            get
            {
                return intReopenSts;
            }
            set
            {
                intReopenSts = value;
            }
        }
        public int CancelId
        {
            get
            {
                return intCnclId;
            }
            set
            {
                intCnclId = value;
            }
        }
        public int ConfirmSts
        {
            get
            {
                return intConfirmSts;
            }
            set
            {
                intConfirmSts = value;
            }
        }
        public string IndvdlLeavIds
        {
            get
            {
                return strIndLeavIds;
            }
            set
            {
                strIndLeavIds = value;
            }
        }
        public int IndividualLeavTypId
        {
            get
            {
                return intIndividualLeavTypId;
            }
            set
            {
                intIndividualLeavTypId = value;
            }
        }
        public int ApplicableNone
        {
            get
            {
                return intApplicableNone;
            }
            set
            {
                intApplicableNone = value;
            }
        }
        public int LeaveOnAbsence
        {
            get
            {
                return intLeaveOnAbsence;
            }
            set
            {
                intLeaveOnAbsence = value;
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



        public string DesignationID
        {
            get
            {
                return strDesgn;
            }
            set
            {
                strDesgn = value;
            }
        }
        public string Paygrade
        {
            get
            {
                return strPaygrade;
            }
            set
            {
                strPaygrade = value;
            }
        }
        public string Experience
        {
            get
            {
                return strExperience;
            }
            set
            {
                strExperience = value;
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
    public class clsEntity_designation_list
    {
        private int intDesigs = 0;
        private int intDesignationstatus = 0;


        public int intDesignationlist_id
        {
            get
            {
                return intDesigs;
            }
            set
            {
                intDesigs = value;
            }
        }

        public int intDesignationliststatus_id
        {
            get
            {
                return intDesignationstatus;
            }
            set
            {
                intDesignationstatus = value;
            }
        }
    }
    public class clsEntity_paygrade_list
    {
        private int intpaygrades = 0;
        private int intpaygradestatus = 0;


        public int intpaygradelist_id
        {
            get
            {
                return intpaygrades;
            }
            set
            {
                intpaygrades = value;
            }
        }

        public int intpaygradeliststatus_id
        {
            get
            {
                return intpaygradestatus;
            }
            set
            {
                intpaygradestatus = value;
            }
        }
    }
    public class clsEntity_experience_list
    {


        private int intpexperience = 0;
        private int intexperiencestatus = 0;


        public int intexperiencelist_id
        {
            get
            {
                return intpexperience;
            }
            set
            {
                intpexperience = value;
            }
        }

        public int intexperienceliststatus_id
        {
            get
            {
                return intexperiencestatus;
            }
            set
            {
                intexperiencestatus = value;
            }
        }

    }
    public class clsEntity_Users_list
    {
        private int intUser = 0;
        private string strExpFrom = "";
        private string strExpTo = "";
        public int UserID
        {
            get
            {
                return intUser;
            }
            set
            {
                intUser = value;
            }
        }
        public string ExperienceFrom
        {
            get
            {
                return strExpFrom;
            }
            set
            {
                strExpFrom = value;
            }
        }
        public string ExperienceTo
        {
            get
            {
                return strExpTo;
            }
            set
            {
                strExpTo = value;
            }
        }
    }
}

