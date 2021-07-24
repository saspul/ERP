using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityConsultancyMaster
    {
        private int intConsultancyId = 0;
        private string strConsultancyName = "";
        private string strConsultancyAddress = "";
        private int intRegStatus= 0;
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intConsultancyStatus = 0;
        private int intConsultancyTypeId = 0;
        private int intCountryId = 0;
        private string strLocation = "";
        private string strRegNo = "";
        private string strConsultancyEmail = "";
        private string strConsultancyPhone = "";
        private string strContactName = "";
        private string strContactEmail = "";
        private string strContactMobile = "";
        private int intUserId = 0;
        private DateTime dDate;
        private string strCancelReason = "";
        private int intDivsnId = 0;
        private int intCancelStatus = 0;
        public int ConsultancyId
        {
            get
            {
                return intConsultancyId;
            }
            set
            {
                intConsultancyId = value;
            }
        }
        public string ConsultancyName
        {
            get
            {
                return strConsultancyName;
            }
            set
            {
                strConsultancyName = value;
            }
        }
        public string ConsultancyAddress
        {
            get
            {
                return strConsultancyAddress;
            }
            set
            {
                strConsultancyAddress = value;
            }
        }
        public int RegStatus
        {
            get
            {
                return intRegStatus;
            }
            set
            {
                intRegStatus = value;
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
        public int ConsultancyStatus
        {
            get
            {
                return intConsultancyStatus;
            }
            set
            {
                intConsultancyStatus = value;
            }
        }
        public int ConsultancyTypeId
        {
            get
            {
                return intConsultancyTypeId;
            }
            set
            {
                intConsultancyTypeId = value;
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
          public string RegNo
        {
            get
            {
                return strRegNo;
            }
            set
            {
                strRegNo = value;
            }
        }
          public string ConsultancyEmail
        {
            get
            {
                return strConsultancyEmail;
            }
            set
            {
                strConsultancyEmail = value;
            }
        }
        
          public string ConsultancyPhone
        {
            get
            {
                return strConsultancyPhone;
            }
            set
            {
                strConsultancyPhone = value;
            }
        }
          public string ContactName
        {
            get
            {
                return strContactName;
            }
            set
            {
                strContactName = value;
            }
        }
          public string ContactEmail
        {
            get
            {
                return strContactEmail;
            }
            set
            {
                strContactEmail = value;
            }
        }
          public string ContactMobile
        {
            get
            {
                return strContactMobile;
            }
            set
            {
                strContactMobile = value;
            }
        }
        
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
             public string CancelReason
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
          public int DivsnId
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
          
          public int CancelStatus
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
    }
}
