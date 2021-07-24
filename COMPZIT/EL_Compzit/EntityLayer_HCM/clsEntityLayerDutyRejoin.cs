using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerDutyRejoin
    {
        private int intLeaveId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intEmpId = 0;
        private int intHolidaySts = 0;
        private int intEmpDlyWrkHrID = 0;
        private DateTime dDate;
        private DateTime rDate;
        private string strFilename = "";
        private int intHolidaycSts = 0;
        private int intHalfDaySts = 0;
        private int intSalProcsSts = 0;
        public int SalProcsSts
        {
            get
            {
                return intSalProcsSts;
            }
            set
            {
                intSalProcsSts = value;
            }
        }
        public int HalfdayStatus
        {
            get
            {
                return intHalfDaySts;
            }
            set
            {
                intHalfDaySts = value;
            }
        }
        public int LeaveId
        {
            get
            {
                return intLeaveId;
            }
            set
            {
                intLeaveId = value;
            }
        }
        public int Status
        {
            get
            {
                return intHolidaycSts;
            }
            set
            {
                intHolidaycSts = value;
            }
        }
        //Method of storing main table id
        public int DutyRejoinId
        {
            get
            {
                return intEmpDlyWrkHrID;
            }
            set
            {
                intEmpDlyWrkHrID = value;
            }
        }

        //Method of storing userid of the person who do the process.
        public int EmployeeId
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


        //Method of storing userid of the person who do the process.
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


        //Method for storing Corporation office id.
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
        //Method of storing organisationid .
        public int orgid
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
        //Method of storing holiday status
        public int PassHandOverSts
        {
            get
            {
                return intHolidaySts;
            }
            set
            {
                intHolidaySts = value;
            }
        }
        //Method of storing date 
        public DateTime RejoinDate
        {
            get
            {
                return rDate;
            }
            set
            {
                rDate = value;
            }
        }

        //Method of storing date 
        public DateTime UserDate
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
        //Method of storing filename
        public string RejectReason
        {
            get
            {
                return strFilename;
            }
            set
            {
                strFilename = value;
            }
        }
       
    }
}
