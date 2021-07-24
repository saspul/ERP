using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public  class clsEntityEmployeeDailyWorkHour
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intHolidaySts = 0;
        private int intEmpDlyWrkHrID = 0;
        private DateTime dDate;
        private string strFilename = "";
        private string strActFileName = "";
        private int intMnth = 0;
        private int intYear = 0;
        private string strDate = "";
        private decimal decIdleHour = 0;

        //used to Select Absentees 
        private int intAttandanceMode=0;
        private int intProjectId = 0;

        private int intOTCatgId = 0;
        private string strOTCatgName = "";

        private int intInsTableSts = 0;
        public int InsTableSts
        {
            get
            {
                return intInsTableSts;
            }
            set
            {
                intInsTableSts = value;
            }
        }


        public int OTCatgId
        {
            get
            {
                return intOTCatgId;
            }
            set
            {
                intOTCatgId = value;
            }
        }

        public string OTCatgName
        {
            get
            {
                return strOTCatgName;
            }
            set
            {
                strOTCatgName = value;
            }
        }


        public int ProjectId
        {
            get
            {
                return intProjectId;
            }
            set
            {
                intProjectId = value;
            }
        }

        public int AttandanceMode
        {
            get { return intAttandanceMode; }
            set { intAttandanceMode = value; }
        }


        public decimal IdleHourCmn
        {
            get
            {
                return decIdleHour;
            }
            set
            {
                decIdleHour = value;
            }
        }
        public string StrDate
        {
            get
            {
                return strDate;
            }
            set
            {
                strDate = value;
            }
        }
        //Method of storing main table id
        public int Month
        {
            get
            {
                return intMnth;
            }
            set
            {
                intMnth = value;
            }
        }
        //Method of storing main table id
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
        //Method of storing main table id
        public int EmpDlyWrkHrID
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
        public int HolidaySts
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
        public DateTime DateOfWork
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
        public string FileName
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
        //Method of storing actual filename 
        public string ActFileName
        {
            get
            {
                return strActFileName;
            }
            set
            {
                strActFileName = value;
            }
        }

    }

   public class clsEntityEmployeeDailyWorkHourDtl
    {
        private decimal decOT = 0;
        private int intUserId = 0;
        private string strJobTitle = "";
        private string strRemarks = "";
        private string strEmployee = "";
        private string strDesignation = "";
        private string strAtt = "";
        private decimal decRoundedOT = 0;
        private decimal decIdleHour = 0;
        private int intInsTableSts = 0;
        public int InsTableSts
        {
            get
            {
                return intInsTableSts;
            }
            set
            {
                intInsTableSts = value;
            }
        }
        
        private int intProjectId = 0;
        public int ProjectId
        {
            get
            {
                return intProjectId;
            }
            set
            {
                intProjectId = value;
            }
        }


        public decimal RoundedOT
        {
            get
            {
                return decRoundedOT;
            }
            set
            {
                decRoundedOT = value;
            }
        }
        public decimal IdleHour
        {
            get
            {
                return decIdleHour;
            }
            set
            {
                decIdleHour = value;
            }
        }
        public string Attendance
        {
            get
            {
                return strAtt;
            }
            set
            {
                strAtt = value;
            }
        }
        public string Designation
        {
            get
            {
                return strDesignation;
            }
            set
            {
                strDesignation = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return strEmployee;
            }
            set
            {
                strEmployee = value;
            }
        }
        //Method of storing userId
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
        //Method of storing overtime
        public decimal OT
        {
            get
            {
                return decOT;
            }
            set
            {
                decOT = value;
            }
        }

        //Method of storing jobTitle
        public string JobTitle
        {
            get
            {
                return strJobTitle;
            }
            set
            {
                strJobTitle = value;
            }
        }

        //Method of storing remark
        public string Remark
        {
            get
            {
                return strRemarks;
            }
            set
            {
                strRemarks = value;
            }
        }

        private int intOTCatgId = 0;
        private string strOTCatgName = "";

        public int OTCatgId
        {
            get
            {
                return intOTCatgId;
            }
            set
            {
                intOTCatgId = value;
            }
        }

        public string OTCatgName
        {
            get
            {
                return strOTCatgName;
            }
            set
            {
                strOTCatgName = value;
            }
        }

        int intEmpDlyWrkHrID = 0;
        public int EmpDlyWrkHrID
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
        int intCorpId = 0;
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

    }
}
