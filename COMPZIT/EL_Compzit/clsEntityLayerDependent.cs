using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
 public class clsEntityLayerDependent
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intMrgDtlId = 0;
        private int intEmpUserId = 0;
        private string strCerNum = "";
        private string strSpsName = "";
        private string strSpsPhone = "";
        private string strSpsMob = "";
        private string strSpsEmail = "";
        private DateTime dMrgDate;
        private DateTime date;
        private int intDepntId = 0;
        private int intreltnId = 0;
        private string strDepntName = "";
        private string strPasprtNum = "";
        private string strRPnum = "";
        private DateTime dPasprtExp;
        private DateTime dRPiss;
        private DateTime dRPexp;
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
        //methode of marriage detail id storing
        public int MrgDtlId
        {
            get
            {
                return intMrgDtlId;
            }
            set
            {
                intMrgDtlId = value;
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
        public string SpsMobile
        {
            get
            {
                return strSpsMob;
            }
            set
            {
                strSpsMob = value;
            }
        }
        //methode of spouse phone storing
        public string SpsPhone
        {
            get
            {
                return strSpsPhone;
            }
            set
            {
                strSpsPhone = value;
            }
        }
        //methode of spouse email storing
        public string SpsEmail
        {
            get
            {
                return strSpsEmail;
            }
            set
            {
                strSpsEmail = value;
            }
        }
        //methode of marriage date storing
        public DateTime MrgDate
        {
            get
            {
                return dMrgDate;
            }
            set
            {
                dMrgDate = value;
            }
        }
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
        //methode of dependent passport number storing
        public string DepntPasprtNum
        {
            get
            {
                return strPasprtNum;
            }
            set
            {
                strPasprtNum = value;
            }
        }
        //methode of dependent RP number storing
        public string RPNum
        {
            get
            {
                return strRPnum;
            }
            set
            {
                strRPnum = value;
            }
        }
        //methode of passport expiry date storing
        public DateTime PasprtExpDate
        {
            get
            {
                return dPasprtExp;
            }
            set
            {
                dPasprtExp = value;
            }
        }
        //methode of RP expiry date storing
        public DateTime RPExpDate
        {
            get
            {
                return dRPexp;
            }
            set
            {
                dRPexp = value;
            }
        }
        //methode of RP issue date storing
        public DateTime RPIssDate
        {
            get
            {
                return dRPiss;
            }
            set
            {
                dRPiss = value;
            }
        }
    }
}
