using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerresignationApproval
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


        private DateTime dateResignationFrmDate;
        private DateTime dateResignationToDate;
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
        private string strRoReason = null;
        private string strDmReason = null;
        private string strGmReason = null;
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
        public int ResignationToSection
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
        public DateTime ResignationToDate
        {
            get
            {
                return dateResignationToDate;
            }
            set
            {
                dateResignationToDate = value;
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
        public int ResignationConfmn
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
        public decimal NumOfResignation
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
        public int ResignationFromSection
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
        public DateTime ResignationFrmDate
        {
            get
            {
                return dateResignationFrmDate;
            }
            set
            {
                dateResignationFrmDate = value;
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

        public int Resignation_Id
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
        public string RoReason
        {
            get
            {
                return strRoReason;
            }
            set
            {
                strRoReason = value;
            }
        }
        public string DmReason
        {
            get
            {
                return strDmReason;
            }
            set
            {
                strDmReason = value;
            }
        }
        public string GmReason
        {
            get
            {
                return strGmReason;
            }
            set
            {
                strGmReason = value;
            }
        }
    
    
}
}
