using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityCandidatelogin
    {
        private int intCandidateLoginMasterId = 0;
        private string strCandidateLoginGeneretedId = "";
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime UsrDate;
        private int intCandId = 0;
         private int intconfrmstatus = 0;
         private int intCanconfrmstatus = 0;
         private int intEmpId = 0;   
        private int intRqstId = 0;

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
        public int Confirmstatus
        {
            get
            {
                return intconfrmstatus;
            }
            set
            {
                intconfrmstatus = value;
            }
        }
        public int Cancelstatus
        {
            get
            {
                return intCanconfrmstatus;
            }
            set
            {
                intCanconfrmstatus = value;
            }
        }
        public int UserStatus
        {
            get
            {
                return intRqstId;
            }
            set
            {
                intRqstId = value;
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


        public int CandidateId
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
        public string GeneratedCandidateId
        {
            get
            {
                return strCandidateLoginGeneretedId;
            }
            set
            {
                strCandidateLoginGeneretedId = value;
            }
        }

        public DateTime CandidateDate
        {
            get
            {
                return UsrDate;
            }
            set
            {
                UsrDate = value;
            }
        }
    }

  
}
