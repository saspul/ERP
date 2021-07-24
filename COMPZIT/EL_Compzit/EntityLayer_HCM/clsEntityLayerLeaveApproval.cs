using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerLeaveApproval
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intEmplySrch = 0;
        private int intUserId = 0;
        private int intEmployeeId = 0;
        private int intclassId = 0;
        private int intLeavAllocn = 0;
        private int intRqstMode = 0;
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

        private int intApproval = 0;
        private int intreject = 0;
        private int intRqstStats = 0;
        private int intRoleSrch = 0;

        private string strRoComment = null;
        private string strDmComment = null;
        private string strGmComment = null;
        private string strHrComment = null;
        public int RoleSrch
        {
            get { return intRoleSrch; }
            set { intRoleSrch = value; }
        }


        public int ApprovalStatus
        {
            get
            {
                return intApproval;
            }
            set
            {
                intApproval = value;
            }
        }
        public int Reject_Status
        {
            get
            {
                return intreject;
            }
            set
            {
                intreject = value;
            }
        }
        public int Requeststatus
        {
            get
            {
                return intRqstStats;
            }
            set
            {
                intRqstStats = value;
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
        public int Mode
        {
            get
            {
                return intRqstMode;
            }
            set
            {
                intRqstMode = value;
            }
        }
        public string RoComment
        {
            get
            {
                return strRoComment;
            }
            set
            {
                strRoComment = value;
            }
        }
        public string DmComment
        {
            get
            {
                return strDmComment;
            }
            set
            {
                strDmComment = value;
            }
        }
        public string GmComment
        {
            get
            {
                return strGmComment;
            }
            set
            {
                strGmComment = value;
            }
        }
        public string HrComment
        {
            get
            {
                return strHrComment;
            }
            set
            {
                strHrComment = value;
            }
        }
    }

}
