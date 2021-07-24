using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerStaffWorkExperience
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intWrkExpDtlId = 0;
        private DateTime date;
        private decimal intWrkExpYears= 0;
        private decimal intWrkGCCExpYears = 0;
        private int intWrkEmpName= 0;
        private string strWrkAddress="";
        private DateTime dateLastWrkJoiningDate=DateTime.MinValue;
        private DateTime dateLastWrkLeavingDate=DateTime.MinValue;
        private string strDesignation="";
        private decimal deciSalary=0;
        private int intCandidateID= 0;
        private string strCancelReason="";
        public string CancelReason
        {
            get { return strCancelReason; }
            set { strCancelReason = value; }
        }
        public int CandidateID
        {
            get { return intCandidateID; }
            set { intCandidateID = value; }
        }
        public decimal Salary
        {
            get { return deciSalary; }
            set { deciSalary = value; }
        }

        public string Designation
        {
            get { return strDesignation; }
            set { strDesignation = value; }
        }
        public DateTime LastWrkLeavingDate
        {
            get { return dateLastWrkLeavingDate; }
            set { dateLastWrkLeavingDate = value; }
        }
        public DateTime LastWrkJoiningDate
        {
            get { return dateLastWrkJoiningDate; }
            set { dateLastWrkJoiningDate = value; }
        }
        public string WrkAddress
        {
            get { return strWrkAddress; }
            set { strWrkAddress = value; }
        }
        private string strWrkEmpName;
        public string WrkEmpName
        {
            get { return strWrkEmpName; }
            set { strWrkEmpName = value; }
        }
        public decimal WrkGCCExpYears
        {
            get { return intWrkGCCExpYears; }
            set { intWrkGCCExpYears = value; }
        }
        public decimal WrkExpYears
        {
            get { return intWrkExpYears; }
            set { intWrkExpYears = value; }
        }
       
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
    public class clsEntityLayerStaffEducation
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intStaffQualID = 0;
        private DateTime date;
        private int intCandidateID= 0;
        private string strCancelReason="";
        private string strInstitution="";
        private int intCourseID= 0;
        private DateTime datePassingYear= DateTime.MinValue;
        private string strDegree="";
        private string strSpecialization="";
        private decimal decimalPercentage= 0;
        public decimal Percentage
        {
            get { return decimalPercentage; }
            set { decimalPercentage = value; }
        }
        public string Specialization
        {
            get { return strSpecialization; }
            set { strSpecialization = value; }
        }
        public DateTime PassingYear
        {
            get { return datePassingYear; }
            set { datePassingYear = value; }
        }
        public string Degree
        {
            get { return strDegree; }
            set { strDegree = value; }
        }
        public int CourseID
        {
            get { return intCourseID; }
            set { intCourseID = value; }
        }
        public string Institution
        {
            get { return strInstitution; }
            set { strInstitution = value; }
        }
        public string CancelReason
        {
            get { return strCancelReason; }
            set { strCancelReason = value; }
        }
        public int CandidateID
        {
            get { return intCandidateID; }
            set { intCandidateID = value; }
        }
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
                return intStaffQualID;
            }
            set
            {
                intStaffQualID = value;
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
    public class clsEntityLayerStaffLanguage
    {

        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intLangDtlId = 0;
        private int intLangId = 0;
        private int intWrite = 0;
        private int intSpeak = 0;
        private int intRead = 0;
        private string strcomment = "";
        private DateTime date;
        private int intMotherTongue = 0;
        private int intCandidateID = 0;
        public int CandidateID
        {
            get { return intCandidateID; }
            set { intCandidateID = value; }
        }
        public int MotherTongue
        {
            get { return intMotherTongue; }
            set { intMotherTongue = value; }
        }
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
   
        //methode of language write id storing
        public int LangWrite
        {
            get
            {
                return intWrite;
            }
            set
            {
                intWrite = value;
            }
        }
        //methode of language read  id storing
        public int LangRead
        {
            get
            {
                return intRead;
            }
            set
            {
                intRead = value;
            }
        }
        //methode of language speak id storing
        public int LangSpeak
        {
            get
            {
                return intSpeak;
            }
            set
            {
                intSpeak = value;
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
