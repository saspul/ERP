using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityImmigrationTasks
    {

        private int intImgrtnDetailId = 0;
        private int intImgrtnId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime DateUsrDate;
        private DateTime Datefinish;
        private DateTime DateClose;
        private DateTime DateSchdle;
        private int intCandId = 0;
        private int intEmpId = 0;
        private int intImgrtnRoundId = 0;
        private int intRondStatusId = 0;
        private int intFinishStatusId = 0;
        private int intCloseStatusId = 0;
        private string strRoundName = "";
        private string strActFname = "";
        private string strFname = "";



        public string Fname
        {
            get
            {
                return strFname;
            }
            set
            {
                strFname = value;
            }
        }
        public string ActFname
        {
            get
            {
                return strActFname;
            }
            set
            {
                strActFname = value;
            }
        }
        public string RoundName
        {
            get
            {
                return strRoundName;
            }
            set
            {
                strRoundName = value;
            }
        }
        public DateTime FinishDate
        {
            get
            {
                return Datefinish;
            }
            set
            {
                Datefinish = value;
            }
        }
        public DateTime CloseDate
        {
            get
            {
                return DateClose;
            }
            set
            {
                DateClose = value;
            }
        }

        public DateTime ScheduleDate
        {
            get
            {
                return DateSchdle;
            }
            set
            {
                DateSchdle = value;
            }
        }
        
       
        public DateTime UsrDate
        {
            get
            {
                return DateUsrDate;
            }
            set
            {
                DateUsrDate = value;
            }
        }

       
        public int CloseStatusId
        {
            get
            {
                return intCloseStatusId;
            }
            set
            {
                intCloseStatusId = value;
            }
        }
        public int FinishStatusId
        {
            get
            {
                return intFinishStatusId;
            }
            set
            {
                intFinishStatusId = value;
            }
        }
        public int RoundStatusId
        {
            get
            {
                return intRondStatusId;
            }
            set
            {
                intRondStatusId = value;
            }
        }
        public int ImgrtnRndId
        {
            get
            {
                return intImgrtnRoundId;
            }
            set
            {
                intImgrtnRoundId = value;
            }
        }
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
        public int ImgrtnDetailId
        {
            get
            {
                return intImgrtnDetailId;
            }
            set
            {
                intImgrtnDetailId = value;
            }
        }
        public int ImgrtnId
        {
            get
            {
                return intImgrtnId;
            }
            set
            {
                intImgrtnId = value;
            }
        }

        public int Orgid
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
        public int CorpOffice
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
        public int CandId
        {
            get
            {
                return intCandId;
            }
            set
            {
                intCandId = value;
            }
        }

      
    }
}
