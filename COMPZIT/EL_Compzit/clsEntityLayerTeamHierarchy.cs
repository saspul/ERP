using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
   public class clsEntityLayerTeamHierarchy
    {
        private int intTeamId = 0;
        private string strTeamName = null;
        private int intTeamLeadEmp_Id = 0;
        private int intStatus = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private DateTime ddate;
        private string strCancelreason = null;
        private int intDivsnid = 0;
        private int intCancelStatus = 0;

        private string strSearchText = null;

        public string SearchText
        {
            get
            {
                return strSearchText;
            }
            set
            {
                strSearchText = value;
            }
        }

        //methode of cancel status storing
        public int Cancel_Status
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
        //Property for storing Team id.
        public int TeamId
        {
            get
            {
                return intTeamId;
            }
            set
            {
                intTeamId = value;
            }
        }
        //Property for storing Team Name
        public string TeamName
        {
            get
            {
                return strTeamName;
            }
            set
            {
                strTeamName = value;
            }
        }
        //Property for storing Team Lead Emp id.
        public int TeamLeadEmp_Id
        {
            get
            {
                return intTeamLeadEmp_Id;
            }
            set
            {
                intTeamLeadEmp_Id = value;
            }
        }
        //Property of storing the status of the team
        public int Status
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
        //Property for storing organistion id.
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

        //Property for storing Corporate office id.
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
        //Property for storing user id who do the event.
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
        //Property for storing the date when the event occurs.
        public DateTime D_Date
        {
            get
            {
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }
        //Property for storing  cancel reason
        public string Cancel_reason
        {
            get
            {
                return strCancelreason;
            }
            set
            {
                strCancelreason = value;
            }
        }

        //Property for storing Divsn id .
        public int Divsnid
        {
            get
            {
                return intDivsnid;
            }
            set
            {
                intDivsnid = value;
            }
        }
      
    }
   public class clsEntityLayerTeamMember
    {
        private int intTeamMembersMasterId = 0;
        private int intTeamId = 0;
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intTeamMemberEmp_Id = 0;
   
      
       

        //Property for storing Team Members id.
        public int TeamMembersMasterId
        {
            get
            {
                return intTeamMembersMasterId;
            }
            set
            {
                intTeamMembersMasterId = value;
            }
        }
        //Property for storing Team Master id
        public int TeamId
        {
            get
            {
                return intTeamId;
            }
            set
            {
                intTeamId = value;
            }
        }
        //Property for storing organistion id.
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

        //Property for storing Corporate office id.
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
        //Property for storing Team member's user id.
        public int TeamMemberEmp_Id
        {
            get
            {
                return intTeamMemberEmp_Id;
            }
            set
            {
                intTeamMemberEmp_Id = value;
            }
        }
       

    }
}
