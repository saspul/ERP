using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityEmplyeeAccessMgmt
    {
        private int intOrgId = 0;
        private int intCorprtId = 0;
        private int intUsrId = 0;
        private string strEmpId;
        private int intstatus = 0;
        private string strEmpFName = "";
        private string strEmpLName = "";
        private DateTime dateAttendence;
        private DateTime timeCheckIn;
        private DateTime timeCheckOut;
        private DateTime InsDate;
        private DateTime UpdDate;
        private DateTime CnfrmDate;
        
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
        public int CorprtId
        {
            get
            {
                return intCorprtId;
            }
            set
            {
                intCorprtId = value;
            }
        }
        public int UsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
            }
        }
        public string EmpId
        {
            get
            {
                return strEmpId;
            }
            set
            {
                strEmpId = value;
            }
        }
        public int Status
        {
            get
            {
                return intstatus;
            }
            set
            {
                intstatus = value;
            }
        }
        public string EmpFirstName
        {
            get
            {
                return strEmpFName;
            }
            set
            {
                strEmpFName = value;
            }
        }
        public string EmpLastName
        {
            get
            {
                return strEmpLName;
            }
            set
            {
                strEmpLName = value;
            }
        }
        public DateTime AttendenceDate
        {
            get
            {
                return dateAttendence;
            }
            set
            {
                dateAttendence = value;
            }
        }
        public DateTime FirstCheckIn
        {
            get
            {
                return timeCheckIn;
            }
            set
            {
                timeCheckIn = value;
            }
        }
        public DateTime LastCheckOut
        {
            get
            {
                return timeCheckOut;
            }
            set
            {
                timeCheckOut = value;
            }
        }
        public DateTime InsertDate
        {
            get
            {
                return InsDate;
            }
            set
            {
                InsDate = value;
            }
        }
        public DateTime UpdateDate
        {
            get
            {
                return UpdDate;
            }
            set
            {
                UpdDate = value;
            }
        }
        public DateTime ConfirmDate
        {
            get
            {
                return CnfrmDate;
            }
            set
            {
                CnfrmDate = value;
            }
        }

    }
}
