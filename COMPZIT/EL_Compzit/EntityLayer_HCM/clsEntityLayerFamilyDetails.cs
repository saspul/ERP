using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
 public class clsEntityLayerFamilyDetails
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intEmpUserId = 0;
        private string strCerNum = "";
        private string strSpsName = "";
        private string strFatherName = "";
        private string strFatherOcc = "";
        private string strhusname = "";
    


        private int intrelation = 0;
        private DateTime date;
        private int intDepntId = 0;
        private int intreltnId = 0;
        private DateTime DDateOfBirth=DateTime.MinValue;
        private int intMaritalstats = 0;
        private string strDepntName = "";
        private int intGuardtyp = 0;
        private string strGuardname = "";
        private string strGuardoccp = "";

        private string strOccupation = "";

     

        //methode for date of birth
        public DateTime DateOfBirth
        {
            get
            {
                return DDateOfBirth;
            }
            set
            {
                DDateOfBirth = value;
            }
        }
        public string HusbandName
        {
            get { return strhusname; }
            set { strhusname=value;}
        
        }

        public int relationship
        {
            get
            {
                return intrelation;
            }
            set
            {
                intrelation = value;
            }
        }

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
     
        //methode of employee user id storing
        public int EmpUserId
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
        //methode of certificate number storing
        public string CerfNum
        {
            get
            {
                return strCerNum;
            }
            set
            {
                strCerNum = value;
            }
        }
        //methode of spouse name storing
        public string SpsName
        {
            get
            {
                return strSpsName;
            }
            set
            {
                strSpsName = value;
            }
        }
        //methode of spouse mobile storing

        //methode of spouse phone storing

        //methode of spouse email storing

        //methode of marriage date storing

        //methode of activity date storing
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
        //methode of dependent id storing
        public int DepntId
        {
            get
            {
                return intDepntId;
            }
            set
            {
                intDepntId = value;
            }
        }
        public int Maritalstst
        {
            get
            {
                return intMaritalstats;
            }
            set
            {
                intMaritalstats = value;
            }
        }
        //methode of relationship id storing
        public int RelatnshpId
        {
            get
            {
                return intreltnId;
            }
            set
            {
                intreltnId = value;
            }
        }
        //methode of dependent name storing
        public string DepntName
        {
            get
            {
                return strDepntName;
            }
            set
            {
                strDepntName = value;
            }
        }

        //methode of dependent RP number storing
        public string Occupation
        {
            get
            {
                return strOccupation;
            }
            set
            {
                strOccupation = value;
            }
        }
        public string DependtnOccupation
        {
            get
            {
                return strFatherOcc;
            }
            set
            {
                strFatherOcc = value;
            }
        }
        public string DependtnName
        {
            get
            {
                return strFatherName;
            }
            set
            {
                strFatherName = value;
            }
        }

        public int GuardTyp
        {
            get
            {
                return intGuardtyp;
            }
            set
            {
                intGuardtyp = value;
            }
        }

        public string GuardName
        {
            get
            {
                return strGuardname;
            }
            set
            {
                strGuardname = value;
            }
        }

        public string GuardOccp
        {
            get
            {
                return strGuardoccp;
            }
            set
            {
                strGuardoccp = value;
            }
        }
    }
}
