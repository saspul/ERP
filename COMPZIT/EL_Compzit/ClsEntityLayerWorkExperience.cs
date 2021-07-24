using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{   
    //Entity Layer For Qualification:Work Experience
  public class ClsEntityLayerWorkExperience
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intWrkExpDtlId = 0;
        private int intEmpUserId = 0;
        private int intRefChkId = 0;
        private string strCmpny = "";
        private string strJobTle = "";
        private string strCmnt = "";
        private string strRefName = "";
        private string strRefdesg = "";
        private string strFname = "";
        private string strActFname = "";
        private DateTime dFromDate;
        private DateTime dToDate;
        private DateTime date;
        //methode of organisation id storing
        public int Organisation_id
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
        //methode of corporate id storing
        public int Corporate_id
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
        //methode of user id storing
        public int User_id
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
        //methode of work experience detail id storing
        public int WorkExpDtl_id
        {
            get
            {
                return intWrkExpDtlId;
            }
            set
            {
                intWrkExpDtlId = value;
            }
        }
        //methode of employee id storing
        public int EmpUser_id
        {
            get
            {
                return intEmpUserId;
            }
            set
            {
                intEmpUserId = value;
            }
        }
        //methode of reference check id storing
        public int Refcheck_id
        {
            get
            {
                return intRefChkId;
            }
            set
            {
                intRefChkId = value;
            }
        }
        //methode of company name storing
        public string CompanyName
        {
            get
            {
                return strCmpny;
            }
            set
            {
                strCmpny = value;
            }
        }
        //methode of job title storing
        public string JobTitle
        {
            get
            {
                return strJobTle;
            }
            set
            {
                strJobTle = value;
            }
        }
        //methode of comment storing
        public string Comment
        {
            get
            {
                return strCmnt;
            }
            set
            {
                strCmnt = value;
            }
        }
        //methode of reference name  storing
        public string RefName
        {
            get
            {
                return strRefName;
            }
            set
            {
                strRefName = value;
            }
        }
        //methode of reference designation storing
        public string RefDesgntn
        {
            get
            {
                return strRefdesg;
            }
            set
            {
                strRefdesg = value;
            }
        }
        //methode of filename storing
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
        //methode of actual filename storing
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
        //methode of from date storing
        public DateTime FromDate
        {
            get
            {
                return dFromDate;
            }
            set
            {
                dFromDate = value;
            }
        }
        //methode of to date storing
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        //methode of  date storing
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }


    }
  //Entity Layer For Qualification:Education
  public class ClsEntityLayerEducation
  {
      private int intOrgId = 0;
      private int intCorpId = 0;
      private int intUserId = 0;
      private int intEduDtlId = 0;
      private int intEduLvlId = 0;
      private int intEmpUserId = 0;
      private int intYear = 0;
      private string strInstit = "";
      private string strMajor = "";
      private string strFname = "";
      private string strActFname = "";
      private decimal decScore = 0;
      private DateTime dFromDate;
      private DateTime dToDate;
      private DateTime date;
      //methode of organisation id storing
      public int Organisation_id
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
      //methode of corporate id storing
      public int Corporate_id
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
      //methode of user id storing
      public int User_id
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
      //methode of education detail id storing
      public int EductnDtl_Id
      {
          get
          {
              return intEduDtlId;
          }
          set
          {
              intEduDtlId = value;
          }
      }
      //methode of employee id storing
      public int EmpUser_id
      {
          get
          {
              return intEmpUserId;
          }
          set
          {
              intEmpUserId = value;
          }
      }
      //methode of education level id storing
      public int EduLevelId
      {
          get
          {
              return intEduLvlId;
          }
          set
          {
              intEduLvlId = value;
          }
      }
      //methode of year storing
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
     
     
      //methode of major/Specialization  storing
      public string MajorSpec
      {
          get
          {
              return strMajor;
          }
          set
          {
              strMajor = value;
          }
      }
      //methode of institute name storing
      public string Institute
      {
          get
          {
              return strInstit;
          }
          set
          {
              strInstit = value;
          }
      }
      //methode of filename storing
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
      //methode of actual filename storing
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
      //methode of from date storing
      public DateTime StartDate
      {
          get
          {
              return dFromDate;
          }
          set
          {
              dFromDate = value;
          }
      }
      //methode of to date storing
      public DateTime EndDate
      {
          get
          {
              return dToDate;
          }
          set
          {
              dToDate = value;
          }
      }
      //methode of  date storing
      public DateTime Date
      {
          get
          {
              return date;
          }
          set
          {
              date = value;
          }
      }
      //methode of  GPA/score storing
      public decimal GPAscore
      {
          get
          {
              return decScore;
          }
          set
          {
              decScore = value;
          }
      }
  }
  //Entity Layer For Qualification:Skills &Certifications
  public class ClsEntityLayerSkillCertifcn
  {
      private int intOrgId = 0;
      private int intCorpId = 0;
      private int intUserId = 0;
      private int intSklCerDtlId = 0;
      private int intEmpUserId = 0;
      private int intSklCerCbxId = 0;
      private int intSkillId = 0;
      private int intYear = 0;
      private string strCertfn = "";
      private string strCmnt = "";
      private string strFname = "";
      private string strActFname = "";
      private DateTime date;
      //methode of organisation id storing
      public int Organisation_id
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
      //methode of corporate id storing
      public int Corporate_id
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
      //methode of user id storing
      public int User_id
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
      //methode of work experience detail id storing
      public int SklCerfnDtlId
      {
          get
          {
              return intSklCerDtlId;
          }
          set
          {
              intSklCerDtlId = value;
          }
      }
      //methode of employee id storing
      public int EmpUser_id
      {
          get
          {
              return intEmpUserId;
          }
          set
          {
              intEmpUserId = value;
          }
      }
      //methode of year storing
      public int year
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
      //methode of skill Id storing
      public int SkillId
      {
          get
          {
              return intSkillId;
          }
          set
          {
              intSkillId = value;
          }
      }
      //methode of cbx skill certification  Id storing
      public int cbxSklCerId
      {
          get
          {
              return intSklCerCbxId;
          }
          set
          {
              intSklCerCbxId = value;
          }
      }
      //methode of certification storing
      public string Certfcn
      {
          get
          {
              return strCertfn;
          }
          set
          {
              strCertfn = value;
          }
      }
      //methode of comment storing
      public string Comment
      {
          get
          {
              return strCmnt;
          }
          set
          {
              strCmnt = value;
          }
      }
      
      //methode of filename storing
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
      //methode of actual filename storing
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
     
      //methode of  date storing
      public DateTime Date
      {
          get
          {
              return date;
          }
          set
          {
              date = value;
          }
      }
  }
  //Entity Layer For Qualification:Language
  public class ClsEntityLayerLanguage
  {

      private int intOrgId = 0;
      private int intCorpId = 0;
      private int intUserId = 0;
      private int intLangDtlId = 0;
      private int intLangId = 0;
      private int intEmpUserId = 0;
      private int intFlncyLvlId = 0;
      private int intWrtId = 0;
      private int intSpkId = 0;
      private int intReadId = 0;
      private string strcomment = "";
      private DateTime date;
      //methode of organisation id storing
      public int Organisation_id
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
      //methode of corporate id storing
      public int Corporate_id
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
      //methode of user id storing
      public int User_id
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
      //methode of language detail id storing
      public int LangdtlId
      {
          get
          {
              return intLangDtlId;
          }
          set
          {
              intLangDtlId = value;
          }
      }
      //methode of employee id storing
      public int EmpUser_id
      {
          get
          {
              return intEmpUserId;
          }
          set
          {
              intEmpUserId = value;
          }
      }
      //methode of language id storing
      public int LanguageId
      {
          get
          {
              return intLangId;
          }
          set
          {
              intLangId = value;
          }
      }
      //methode of fluency level id storing
      public int FlncyLvlId
      {
          get
          {
              return intFlncyLvlId;
          }
          set
          {
              intFlncyLvlId = value;
          }
      }
      //methode of language write id storing
      public int LangWriteId
      {
          get
          {
              return intWrtId;
          }
          set
          {
              intWrtId = value;
          }
      }
      //methode of language read  id storing
      public int LangReadId
      {
          get
          {
              return intReadId;
          }
          set
          {
              intReadId = value;
          }
      }
      //methode of language speak id storing
      public int LangSpeakId
      {
          get
          {
              return intSpkId;
          }
          set
          {
              intSpkId = value;
          }
      }

     
      //methode of comment storing
      public string Comment
      {
          get
          {
              return strcomment;
          }
          set
          {
              strcomment = value;
          }
      }
     
      //methode of  date storing
      public DateTime Date
      {
          get
          {
              return date;
          }
          set
          {
              date = value;
          }
      }
     
  }

}
