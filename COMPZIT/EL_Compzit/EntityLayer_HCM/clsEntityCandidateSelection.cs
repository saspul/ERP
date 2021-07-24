using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityCandidateSelection
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intDesgId = 0;
        private int intDeprt_Id = 0;
        private int intPrjctId = 0;
        private int intManPwrRqstId = 0;
        private int intConsltId = 0;
        private int intJObNotifyId = 0;
        private DateTime dateJ_Date;
        private int intCandidateSelectionId = 0;
        private int intIntervTemplateId = 0;
        private int intMstrResumeType = 0;
        public int CandidateSelectionId
        {
            get
            {
                return intCandidateSelectionId;
            }
            set
            {
                intCandidateSelectionId = value;
            }
        }
        public int IntervTemplateId
        {
            get
            {
                return intIntervTemplateId;
            }
            set
            {
                intIntervTemplateId = value;
            }
        }
        public DateTime J_Date
        {
            get
            {
                return dateJ_Date;
            }
            set
            {
                dateJ_Date = value;
            }
        }
        public int JObNotifyId
        {
            get
            {
                return intJObNotifyId;
            }
            set
            {
                intJObNotifyId = value;
            }
        }
        public int ConsltId
        {
            get
            {
                return intConsltId;
            }
            set
            {
                intConsltId = value;
            }
        }
        public int ManPwrRqstId
        {
            get
            {
                return intManPwrRqstId;
            }
            set
            {
                intManPwrRqstId = value;
            }
        }




        public int PrjctId
        {
            get
            {
                return intPrjctId;
            }
            set
            {
                intPrjctId = value;
            }
        }
        public int MstrResumeType
        {
            get
            {
                return intMstrResumeType;
            }
            set
            {
                intMstrResumeType = value;
            }
        }
        public int Deprt_Id
        {
            get
            {
                return intDeprt_Id;
            }
            set
            {
                intDeprt_Id = value;
            }
        }
        public int DesgId
        {
            get
            {
                return intDesgId;
            }
            set
            {
                intDesgId = value;
            }
        }
        public int DivId
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

        
    
    }
    public class clsEntityCandSelectionDtl
    {
        private string strCandidatename  = "";
        private string strLocation  = "";
        private int intCountryId = 0;
        private int intRefType = 0;
        private int intRefVal = 0;
        private int intSkipIntrw = 0;
        private int intVisa = 0;
        private int intLicense = 0;
        private string strPassport = "";
        private string strFileName = "";
        private string strActFileName = "";
        private string strEmail= "";
        private int intResumeType = 0;
        private int intCandDtlId = 0;
        private int intConsultId = 0;
        private int intDivisionId = 0;
        private int intDepartId = 0;
        private int intEmpId = 0;

        private string strMobile = "";
        private int intGender = 0;

        public string MobileNo
        {
            get
            {
                return strMobile;
            }
            set
            {
                strMobile = value;
            }
        }
        public int Gender
        {
            get
            {
                return intGender;
            }
            set
            {
                intGender = value;
            }
        }

        public int EmpId
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
        public int ConsultId
        {
            get
            {
                return intConsultId;
            }
            set
            {
                intConsultId = value;
            }
        }
        public int DivisionId
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }
        public int DepartId
        {
            get
            {
                return intDepartId;
            }
            set
            {
                intDepartId = value;
            }
        }

        public int SkipIntrw
        {
            get
            {
                return intSkipIntrw;
            }
            set
            {
                intSkipIntrw = value;
            }
        }
        public int RefVal
        {
            get
            {
                return intRefVal;
            }
            set
            {
                intRefVal = value;
            }
        }
        public int CandDtlId
        {
            get
            {
                return intCandDtlId;
            }
            set
            {
                intCandDtlId = value;
            }
        }
        public int ResumeType
        {
            get
            {
                return intResumeType;
            }
            set
            {
                intResumeType = value;
            }
        }
        public string Candidatename
        {
            get
            {
                return strCandidatename;
            }
            set
            {
                strCandidatename = value;
            }
        }
        public string Location
        {
            get
            {
                return strLocation;
            }
            set
            {
                strLocation = value;
            }
        }
        public int CountryId
        {
            get
            {
                return intCountryId;
            }
            set
            {
                intCountryId = value;
            }
        }
        public int RefType
        {
            get
            {
                return intRefType;
            }
            set
            {
                intRefType = value;
            }
        }
        public int Visa
        {
            get
            {
                return intVisa;
            }
            set
            {
                intVisa = value;
            }
        }
        public int License
        {
            get
            {
                return intLicense;
            }
            set
            {
                intLicense = value;
            }
        }
        public string Passport
        {
            get
            {
                return strPassport;
            }
            set
            {
                strPassport = value;
            }
        }
        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
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
        public string Email
        {
            get
            {
                return strEmail;
            }
            set
            {
                strEmail = value;
            }
        }
    }
}
