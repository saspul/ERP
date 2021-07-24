using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.Entity_Layer_HCM
{
   public class clsEntityJobDetails
    {
        private int intJobId = 0;
        //private int intImgEmpId = 0;
        private int intDesigtnId = 0;
        private string strType = "";
        private int intSpsnsrId = 0;
        private int intDeptId = 0;
        private int intProjId = 0;
        private int intDivsnId = 0;
        private int intProjAssnId = 0;
        private int intUsrId = 0;
        private int intAccomdatnId = 0;
        private int intProbatnPeriod = 0;
        private int intUserDsgnId = 0;
        private DateTime joinedDate;
        private DateTime probationendDate;
        private DateTime permanencyDate;
        private DateTime UserDate;
         private int intCorpId = 0;
        private int intOrgId = 0;
        private int intEmpId = 0;
        private string strProjLoc = "";
        private string strJobtype = "";
        private string strTitle = "";
        private string strDescrptn = "";
        private string strEmpLocatn = "";
        private string strCanReasn = "";
      
        public int Job_Id
        {
            get
            {
                return intJobId;
            }
            set
            {
                intJobId = value;
            }
        }
        public int Designation
        {
            get
            {
                return intDesigtnId;
            }
            set
            {
                intDesigtnId = value;
            }
        }
        public string EmployeeType
        {
            get
            {
                return strType;
            }
            set
            {
                strType = value;
            }
        }
        public int Sponsorid
        {
            get
            {
                return intSpsnsrId;
            }
            set
            {
                intSpsnsrId = value;
            }
        }
        public int Department_Id
        {
            get
            {
                return intDeptId;
            }
            set
            {
                intDeptId = value;
            }
        }
        public int Project
        {
            get
            {
                return intProjId;
            }
            set
            {
                intProjId = value;
            }
        }
       

    public int Division
        {
            get
            {
                return intDivsnId;
            }
            set
            {
                intDivsnId = value;
            }
        }

       public int Project_AssignId
        {
            get
            {
                return intProjAssnId;
            }
            set
            {
                intProjAssnId = value;
            }
        }

       public int UserId
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
       public int Accomadation_id
       {
           get
           {
               return intAccomdatnId;
           }
           set
           {
               intAccomdatnId = value;
           }
       }
       public int Probation
       {
           get
           {
               return intProbatnPeriod;
           }
           set
           {
               intProbatnPeriod = value;
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

        public DateTime JobUserDate
        {
            get
            {
                return UserDate;
            }
            set
            {
                UserDate = value;
            }
        }
        public DateTime ProbationEnddate
        {
            get
            {
                return probationendDate;
            }
            set
            {
                probationendDate = value;
            }
        }
        public DateTime PermamanencyDate
        {
            get
            {
                return permanencyDate;
            }
            set
            {
                permanencyDate = value;
            }
        }
        public DateTime JoinedDate
        {
            get
            {
                return joinedDate;
            }
            set
            {
                joinedDate = value;
            }
        }
        public string ProjectLocation
        {
            get
            {
                return strProjLoc;
            }
            set
            {
                strProjLoc = value;
            }

        }
        public string JobType
        {
            get
            {
                return strJobtype;
            }
            set
            {
                strJobtype = value;
            }

        }
        public string JobTitle
        {
            get
            {
                return strTitle;
            }
            set
            {
                strTitle = value;
            }
        }

        public string Description
        {
            get
            {
                return strDescrptn;
            }
            set
            {
                strDescrptn = value;
            }
        }
        public string EmployeeLocation
        {
            get
            {
                return strEmpLocatn;
            }
            set
            {
                strEmpLocatn = value;
            }
        }
        public string JobCancelREASON
        {
            get
            {
                return strCanReasn;
            }
            set
            {
                strCanReasn = value;
            }
        }
        public int UserDsgnId
        {
            get
            {
                return intUserDsgnId;
            }
            set
            {
                intUserDsgnId = value;
            }
        }
    }
   public class clsEntityProjectAssign
   {
       private int intprojjob_id = 0;
       private int intProjassnId = 0;
       //private int intImgEmpId = 0;
       private int intProjId = 0;
       private int intProjstatus = 0;

  
       private DateTime projstartdate;
       private DateTime projennddate;
  
       private DateTime UserActionDate;
       private int intCorpId = 0;
       private int intOrgId = 0;
       private int intUsrId = 0;
       private string strProjName = "";
       private string strProjComments = "";
      private string strAssgnCanReasn = "";
    
       public int Project_Job_Id
      {
          get
          {
              return intprojjob_id;
          }
          set
          {
              intprojjob_id = value;
          }
      }

       public int Project_Asgn_Id
       {
           get
           {
               return intProjassnId;
           }
           set
           {
               intProjassnId = value;
           }
       }
       public int ProjectStatus
       {
           get
           {
               return intProjstatus;
           }
           set
           {
               intProjstatus = value;
           }
       }



       public int ProjectId
       {
           get
           {
               return intProjId;
           }
           set
           {
               intProjId = value;
           }
       }
     

      
       public int UserId
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




       public DateTime Project_StartDate
       {
           get
           {
               return projstartdate;
           }
           set
           {
               projstartdate = value;
           }
       }
       public DateTime Project_EndDate
       {
           get
           {
               return projennddate;
           }
           set
           {
               projennddate = value;
           }
       }
       public DateTime UserDate
       {
           get
           {
               return UserActionDate;
           }
           set
           {
               UserActionDate = value;
           }
       }
       public string ProjectName
       {
           get
           {
               return strProjName;
           }
           set
           {
               strProjName = value;
           }

       }
       public string Project_Comments
       {
           get
           {
               return strProjComments;
           }
           set
           {
               strProjComments = value;
           }

       }
       public string ProjAssgnCanReason
       {
           get
           {
               return strAssgnCanReasn;
           }
           set
           {
               strAssgnCanReasn = value;
           }
       }
       
   }
}
