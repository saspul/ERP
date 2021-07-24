using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerClearanceFormStaff
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intEmpid = 0;
        private DateTime date_Date;
        private int intLeaveClrStaffID = 0;
        private int intLeaveID=0;
        private string strComments = "";
        private int intCancelStatus = 0;
        private string strCancelReason = "";
        private int intApprvStatus = 0;
        private int intTakeOverEmpID = 0;
        private string strFileName = "";
        private string strActualFileName = "";

        private int intClrnceStaffMode = 0;

        private DateTime dtAllctnDate;
        private DateTime dtRqstDate;
        public DateTime RequstDate
        {
            get
            {
                return dtRqstDate;
            }
            set
            {
                dtRqstDate = value;
            }
        }
        public DateTime AllocationDate
        {
            get
            {
                return dtAllctnDate;
            }
            set
            {
                dtAllctnDate = value;
            }
        }

        public int ClrnceStaffMode
        {
            get
            {
                return intClrnceStaffMode;
            }
            set
            {
                intClrnceStaffMode = value;
            }
        }

        public string ActualFileName
        {
            get { return strActualFileName; }
            set { strActualFileName = value; }
        }
        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }



        public int TakeOverEmpID
        {
            get { return intTakeOverEmpID; }
            set { intTakeOverEmpID = value; }
        }


        public int ApprvStatus
        {
            get
            {
                return intApprvStatus;
            }
            set
            {
                intApprvStatus = value;
            }
        }
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
        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
        }



        public int LeaveID
        {
            get { return intLeaveID; }
            set { intLeaveID = value; }
        }


        public int LeaveClrStaffID
        {
            get { return intLeaveClrStaffID; }
            set { intLeaveClrStaffID = value; }
        }


        public DateTime Date
        {
            get
            {
                return date_Date;
            }
            set
            {
                date_Date = value;
            }
        }

        public int Empid
        {
            get
            {
                return intEmpid;
            }
            set
            {
                intEmpid = value;
            }
        }

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
    public class clsEntityClearanceFormStaffSub
    {

        private int intLeaveClrStaffDtlID = 0;
        private int intDecision = 0;
        private int intSubjectID = 0;
        private string strSubjectRemarks = "";
        private int intSubject_Type = 0;
        private string strComments = "";
        private int intHandedOverEmpID = 0;
        private int intAvailability=0;
        public int AvailabilitySts
        {
            get { return intAvailability; }
            set { intAvailability = value; }
        }
        public int HandedOverEmpID
        {
            get { return intHandedOverEmpID; }
            set { intHandedOverEmpID = value; }
        }
        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
        }
        public int Subject_Type
        {
            get { return intSubject_Type; }
            set { intSubject_Type = value; }
        }
        public int SubjectID
        {
            get { return intSubjectID; }
            set { intSubjectID = value; }
        }

        public string SubjectRemarks
        {
            get { return strSubjectRemarks; }
            set { strSubjectRemarks = value; }
        }

        public int Decision
        {
            get { return intDecision; }
            set { intDecision = value; }
        }

        public int LeaveClrStaffDtlID
        {
            get
            {
                return intLeaveClrStaffDtlID;
            }
            set
            {
                intLeaveClrStaffDtlID = value;
            }
        }


    }
    public class clsEntityClearanceFormStaffDetail
    {
        private int intLeaveClrStaffDtlID = 0;
        private int intDecision = 0;
        private string strSubject = "";
        private string strSubjectRemarks = "";
        private int intSubject_Type = 0;

        private string strComments = "";
        private int intHandedOverEmpID = 0;

        public int HandedOverEmpID
        {
            get { return intHandedOverEmpID; }
            set { intHandedOverEmpID = value; }
        }


        public string Comments
        {
            get { return strComments; }
            set { strComments = value; }
        }


        public int Subject_Type
        {
            get { return intSubject_Type; }
            set { intSubject_Type = value; }
        }
        public string Subject
        {
            get { return strSubject; }
            set { strSubject = value; }
        }

        public string SubjectRemarks
        {
            get { return strSubjectRemarks; }
            set { strSubjectRemarks = value; }
        }

        public int Decision
        {
            get { return intDecision; }
            set { intDecision = value; }
        }

        public int LeaveClrStaffDtlID
        {
            get
            {
                return intLeaveClrStaffDtlID;
            }
            set
            {
                intLeaveClrStaffDtlID = value;
            }
        }


    }
}
