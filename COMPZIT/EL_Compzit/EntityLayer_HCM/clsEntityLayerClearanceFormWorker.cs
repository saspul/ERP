using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerClearanceFormWorker
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intEmpid = 0;
        private DateTime date_Date;
        private int intLeaveClrWkrID = 0;
        private int intLeaveID;
        private int intQpPass_sts;
        private int intSimCard_sts;
        private int intDrivingLic_sts;
        private int intTools_sts;
        private int intCLrTraffic_sts;
        private int intMessAmount_sts;
        private string strComments = "";
        private string strQpPass = "";
        private string strSimCard = "";
        private string strDrivingLic = "";
        private string strTools = "";
        private string strCLrTraffic = "";
        private string strMessAmount = "";

        private int intCancelStatus = 0;
        private string strCancelReason = "";
        private int intApprvStatus = 0;
        //evm-0023 For Exit leave employees clearance
        private int intClearanceStaffMode=0;

      
        private int intSub = 0;

        private int intdescid = 0;
        public int Subtableid
        {
            get
            {
                return intSub;
            }
            set
            {
                intSub = value;
            }
        }

        public int Decision
        {
            get
            {
                return intdescid;
            }
            set
            {
                intdescid = value;
            }
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

        public string QpPass
        {
            get { return strQpPass; }
            set { strQpPass = value; }
        }
        public string SimCard
        {
            get { return strSimCard; }
            set { strSimCard = value; }
        }
        public string DrivingLic
        {
            get { return strDrivingLic; }
            set { strDrivingLic = value; }
        }

        public string Tools
        {
            get { return strTools; }
            set { strTools = value; }
        }

        public string CLrTraffic
        {
            get { return strCLrTraffic; }
            set { strCLrTraffic = value; }
        }

        public string MessAmount
        {
            get { return strMessAmount; }
            set { strMessAmount = value; }
        }

        public int MessAmount_sts
        {
            get { return intMessAmount_sts; }
            set { intMessAmount_sts = value; }
        }

        public int CLrTraffic_sts
        {
            get { return intCLrTraffic_sts; }
            set { intCLrTraffic_sts = value; }
        }

        public int Tools_sts
        {
            get { return intTools_sts; }
            set { intTools_sts = value; }
        }

        public int DrivingLic_sts
        {
            get { return intDrivingLic_sts; }
            set { intDrivingLic_sts = value; }
        }


        public int SimCard_sts
        {
            get { return intSimCard_sts; }
            set { intSimCard_sts = value; }
        }


        public int QpPass_Sts
        {
            get { return intQpPass_sts; }
            set { intQpPass_sts = value; }
        }


        public int LeaveID
        {
            get { return intLeaveID; }
            set { intLeaveID = value; }
        }


        public int LeaveClrWkrID
        {
            get { return intLeaveClrWkrID; }
            set { intLeaveClrWkrID = value; }
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

        public int ClearanceStaffMode
        {
            get
            {
                return intClearanceStaffMode;
            }
            set
            {
                intClearanceStaffMode = value;
            }
        }
    }
    public class clsEntityClearanceFormWorkerDetail
    {
        private int intLeaveClrWkrDtlID = 0;
        private int intParticular_sts = 0;
        private string strParticular = "";
        private string strParticularRemarks = "";
        private int intParticular_Type = 0;
        public int Particular_Type
        {
            get { return intParticular_Type; }
            set { intParticular_Type = value; }
        }
        public string Particular
        {
            get { return strParticular; }
            set { strParticular = value; }
        }

        public string ParticularRemarks
        {
            get { return strParticularRemarks; }
            set { strParticularRemarks = value; }
        }

        public int Particular_sts
        {
            get { return intParticular_sts; }
            set { intParticular_sts = value; }
        }

        public int LeaveClrWkrDtlID
        {
            get
            {
                return intLeaveClrWkrDtlID;
            }
            set
            {
                intLeaveClrWkrDtlID = value;
            }
        }


    }
}
