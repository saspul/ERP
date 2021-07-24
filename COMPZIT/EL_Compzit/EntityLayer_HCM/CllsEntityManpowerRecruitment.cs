using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public  class CllsEntityManpowerRecruitment
    {
        private int intRqstId = 0;
       private int intResourceno = 0;
      private int intDesigId = 0;
      private string strReferenceno = "";
      private int intDivId = 0;
       private int intDepID = 0;
      private int intProjId = 0;
      private int intExprnce = 0;
       private int intPaygrdId = 0;
       private int intIdentrId = 0;
       private int intApprovalstats1 = 0;
       private int intApprovalstats2 = 0;
       private int intApprvlUserId = 0;
       private int intRoleId = 0;
       private int intCorpId = 0;
       private int intOrgId = 0;
       private int intUserId = 0; 
       private int intApprvlUserId1 = 0; 
      private int intApprvlUserId2 = 0;
      private int intAppStatus = 1;
      private int intConfrmStatus = 0;
      private int intRoleSrch = 0;
      

        private DateTime RqstDate;
        private DateTime RqstDate1;

        private DateTime RqsrDate2;
        private DateTime RqsrDate3;

        private string strHrNotes = null;
        private string strComments = null;
        private string strOtherBenefits = null;
        private string strRecruitreason = null;
        private string strRefno = "";
        private DateTime dDate;

        private string strCancelReason = null;
        int intrejectstatus = 0;
        public int RejectStatus
        {
            get
            {
                return intrejectstatus;
            }
            set
            {
                intrejectstatus = value;
            }
        }


        public int RoleSrch
        {
            get
            {
                return intRoleSrch;
            }
            set
            {
                intRoleSrch = value;
            }
        }

      

        private int intCancelStatus = 0;
        private int intRqst_Id = 0;
        private int[] intcntry_Id = new int[500];
        private int intMastr_Id = 0;
        public int[] PrefCountry_id
        {
            get
            {
                return intcntry_Id;
            }
            set
            {
                intcntry_Id = value;
            }
        }
        public int PrefferedMastrID
      {
          get
          {
              return intMastr_Id;
          }
          set
          {
              intMastr_Id = value;
          }
      }
      public int RequestId
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
      public int No_Resources
      {
          get
          {
              return intResourceno;
          }
          set
          {
              intResourceno = value;
          }
      }
      public string Reference_Number
      {
          get
          {
              return strReferenceno;
          }
          set
          {
              strReferenceno = value;
          }
      }
      public int DesignationId
      {
          get
          {
              return intDesigId;
          }
          set
          {
              intDesigId = value;
          }
      }
      public int DivisionId
      {
          get
          {
              return intDivId;
          }
          set
          {
              intDivId = value;
          }
      }
      public int Derpartment
      {
          get
          {
              return intDepID;
          }
          set
          {
              intDepID = value;
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
      public int ExperienceRqrd
      {
          get
          {
              return intExprnce;
          }
          set
          {
              intExprnce = value;
          }
      }
            public int ApprovalStats1
      {
          get
          {
              return intApprovalstats1;
          }
          set
          {
              intApprovalstats1 = value;
          }
      }

            public int ApprovalStats2
            {
                get
                {
                    return intApprovalstats2;
                }
                set
                {
                    intApprovalstats2 = value;
                }
            }
            public int ApprovalUsrId1
            {
                get 
                {
                    return intApprvlUserId1;
                }
                set
                {
                  intApprvlUserId1   = value;
                }
            }
            public int ApprovalUsrId2
            {
                get
                {
                    return intApprvlUserId2;
                }
                set
                {
                    intApprvlUserId2 = value;
                }
            }
            public int Identer
            {
                get
                {
                    return intIdentrId;
                }
                set
                {
                    intIdentrId = value;
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

              public int Confirm_Status
        {
            get
            {
                return intConfrmStatus;
            }
            set
            {
                intConfrmStatus = value;
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
        public int PaygradeId
        {
            get
            {
                return intPaygrdId;
            }
            set
            {
                intPaygrdId = value;
            }
        }
        //Method for storing Sponsor name.
        public string Comments
        {
            get
            {
                return strComments;
            }
            set
            {
                strComments = value;
            }
        }

        //Method for storing address of Sponsor 
        public string HrNotes
        {
            get
            {
                return strHrNotes;
            }
            set
            {
                strHrNotes = value;
            }
        }

        //Method for storing address of Sponsor 
        public string OtherBenefits
        {
            get
            {
                return strOtherBenefits;
            }
            set
            {
                strOtherBenefits = value;
            }
        }

        //Method for storing address of Sponsor 
        public string RecruitReason
        {
            get
            {
                return strRecruitreason;
            }
            set
            {
                strRecruitreason = value;
            }
        }


     

 


        //Method of storing  status of Sponsor.
        public int Application_Status
        {
            get
            {
                return intAppStatus;
            }
            set
            {
                intAppStatus = value;
            }
        }

    

        //Method of keeping date of the process.
        public DateTime RequestDate
        {
            get
            {
                return RqstDate;
            }
            set
            {
                RqstDate = value;
            }
        }
        //Method of keeping date of the process.
        public DateTime RequestDate1
        {
            get
            {
                return RqstDate1;
            }
            set
            {
                RqstDate1 = value;
            }
        }
        public DateTime RequestDate2
        {
            get
            {
                return RqsrDate2;
            }
            set
            {
                RqsrDate2 = value;
            }
        }
        public DateTime RequestDate3
        {
            get
            {
                return RqsrDate3;
            }
            set
            {
                RqsrDate3 = value;
            }
        } 
      //Method of keeping date of the process.
    


    
        //Method for storing cancel reason
        public string Cancel_Reason
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

              public int Role_id
        {
            get
            {
                return intRoleId;
            }
            set
            {
                intRoleId = value;
            }
        }

      
      
    }


  public class CllsEntityPrefferedNationaity
  {
      private int intRqst_Id = 0;
      private int[] intcntry_Id=new int[100];
      private int intMastr_Id = 0;

      public int RequestId
      {
          get
          {
              return intRqst_Id;
          }
          set
          {
              intRqst_Id = value;
          }
      }
      public int[] PrefCountry_id
      {
          get
          {
              return intcntry_Id;
          }
          set
          {
              intcntry_Id = value;
          }
      }
      public int PrefferedMastrID
      {
          get
          {
              return intMastr_Id;
          }
          set
          {
              intMastr_Id = value;
          }
      }
  
  }

}

