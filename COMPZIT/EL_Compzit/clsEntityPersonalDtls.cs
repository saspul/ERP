using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    public class clsEntityPersonalDtls
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private DateTime dDate;
        private DateTime joinDate;
        private DateTime dobDate;
        private string strFname = "";
        private string strMname = "";
        private string strLname = "";
        private string strEmpId = "";
        private string strRefNum = "";
        private string strBirthPlc = "";
        private string strNickName = "";
        private string strHobbies = "";
        private int intCountryid = 0;
        private int intEmpToReportid = 0;
        private int intGender = 0;
        private int intMrtlSts = 0;
        private int intReligion = 0;
        private int intBloodGrp = 0;
        private int intSmoker = 0;
        private int intAlcoholic = 0;
        private int intEmployeeId = 0;
        private int intEmpPerDtlID = 0;
        private string strPhotoFname = "";
        private string strPhotoActFname = "";
        private int intResignStats = 0;
        private int intAccomdtnId = 0;
        private int intCatagoryIdId = 0;
        private int intSubCatagoryId = 0;
        private DateTime dDateMess = DateTime.MinValue;
        private DateTime dDateAcmdtnFrom = DateTime.MinValue;
        private DateTime dDateMessFrom = DateTime.MinValue;
        private DateTime dDateMessTo = DateTime.MinValue;
        private int intBankDtlId = 0;
        private int intBankId = 0;
        private string strBranch = "";
        private int intAccountTyp = 0;
        private string strIbanNo = "";
        private string strCardNo = "";
        private int inPaymentSts = 0;

        //evm-0043 start



        //method for payment status
        public int PaymentSts
        {
            get
            {
                return inPaymentSts;
            }
            set
            {
                inPaymentSts = value;
            }
        }
        public int BankDtlId
        {
            get
            {
                return intBankDtlId;
            }
            set
            {
                intBankDtlId = value;
            }
        }

        public int BankId
        {
            get
            {
                return intBankId;
            }
            set
            {
                intBankId = value;
            }
        }

        public string BankBranch
        {
            get
            {
                return strBranch;
            }
            set
            {
                strBranch = value;
            }
        }

        public int AccountTyp
        {
            get
            {
                return intAccountTyp;
            }
            set
            {
                intAccountTyp = value;
            }
        }

        public string IbanNo
        {
            get
            {
                return strIbanNo;
            }
            set
            {
                strIbanNo = value;
            }
        }

        public string CardNo
        {
            get
            {
                return strCardNo;
            }
            set
            {
                strCardNo = value;
            }
        }

        public DateTime DateMess
        {
            get
            {
                return dDateMess;
            }
            set
            {
                dDateMess = value;
            }
        }
        public DateTime DateAcmdtn
        {
            get
            {
                return dDateAcmdtnFrom;
            }
            set
            {
                dDateAcmdtnFrom = value;
            }
        }
        public DateTime DateMessFrom
        {
            get
            {
                return dDateMessFrom;
            }
            set
            {
                dDateMessFrom = value;
            }
        }
        public DateTime DateMessTo
        {
            get
            {
                return dDateMessTo;
            }
            set
            {
                dDateMessTo = value;
            }
        }
        public int SubCatagoryId
        {
            get
            {
                return intSubCatagoryId;
            }
            set
            {
                intSubCatagoryId = value;
            }
        }
        public int AccomdtnId
        {
            get
            {
                return intAccomdtnId;
            }
            set
            {
                intAccomdtnId = value;
            }
        }
        //methode of personal detail id storing
        public int EmpPerDtls_id
        {
            get
            {
                return intEmpPerDtlID;
            }
            set
            {
                intEmpPerDtlID = value;
            }
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
        //methode of activity date storing
        public DateTime Date
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
        //methode of join date storing
        public DateTime JoinDate
        {
            get
            {
                return joinDate;
            }
            set
            {
                joinDate = value;
            }
        }
        //methode of date of birth storing
        public DateTime DOB
        {
            get
            {
                return dobDate;
            }
            set
            {
                dobDate = value;
            }
        }

        //methode for photo file name
        public string PhotoFname
        {
            get
            {
                return strPhotoFname;
            }
            set
            {
                strPhotoFname = value;
            }
        }
        //methode for photo actual file name
        public string PhotoActFname
        {
            get
            {
                return strPhotoActFname;
            }
            set
            {
                strPhotoActFname = value;
            }
        }
        //methode of first name storing
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
        //methode of middle name storing
        public string Mname
        {
            get
            {
                return strMname;
            }
            set
            {
                strMname = value;
            }
        }
        //methode of last name storing
        public string Lname
        {
            get
            {
                return strLname;
            }
            set
            {
                strLname = value;
            }
        }
        //methode of employee id storing
        public string EmployeeId
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
        //methode of reference number  storing
        public string RefNum
        {
            get
            {
                return strRefNum;
            }
            set
            {
                strRefNum = value;
            }
        }
        //methode of place of birth storing
        public string BirthPlace
        {
            get
            {
                return strBirthPlc;
            }
            set
            {
                strBirthPlc = value;
            }
        }
        //methode of nick name storing
        public string NickName
        {
            get
            {
                return strNickName;
            }
            set
            {
                strNickName = value;
            }
        }
        //methode of hobbies storing
        public string Hobbies
        {
            get
            {
                return strHobbies;
            }
            set
            {
                strHobbies = value;
            }
        }

        //methode of country id storing
        public int CountryID
        {
            get
            {
                return intCountryid;
            }
            set
            {
                intCountryid = value;
            }
        }
        //methode of gender storing
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
        //methode of marital status storing
        public int MaritalSts
        {
            get
            {
                return intMrtlSts;
            }
            set
            {
                intMrtlSts = value;
            }
        }

        //methode of religion id storing
        public int ReligionId
        {
            get
            {
                return intReligion;
            }
            set
            {
                intReligion = value;
            }
        }
        //methode of blood group id storing
        public int BloodGrpId
        {
            get
            {
                return intBloodGrp;
            }
            set
            {
                intBloodGrp = value;
            }
        }
        //methode of smoker status storing
        public int Smoker
        {
            get
            {
                return intSmoker;
            }
            set
            {
                intSmoker = value;
            }
        }
        //methode of alcoholic status storing
        public int Alcoholic
        {
            get
            {
                return intAlcoholic;
            }
            set
            {
                intAlcoholic = value;
            }
        }
        //methode of Employee user id storing
        public int EmpUserId
        {
            get
            {
                return intEmployeeId;
            }
            set
            {
                intEmployeeId = value;
            }
        }        //methode of Employee Reporting storing
        public int EmployeeToReport
        {
            get
            {
                return intEmpToReportid;
            }
            set
            {
                intEmpToReportid = value;
            }
        }
        public int Resignsstats
        {
            get
            {
                return intResignStats;
            }
            set
            {
                intResignStats = value;
            }
        }
    }
    
}
