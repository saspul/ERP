using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayerEmployeeSponsorMaster
    {
        private int intCountryId = 0;

        private int intCorpId = 0;
        private int intOrgId = 0;
        private string strSponsorName = null;
        private string strAdd1 = null;
        private string strAdd2 = null;
        private string strAdd3 = null;
        private string strPhone = null;
        private string strMobile = null;
        private string strEmail = null;
        private int intSponsorStatus = 0;
        private int intUserId = 0;
          private int intSponsorType = 0;
          private string intSponsorDocno = "";
        private DateTime dDate;
        private int intSponsorId = 0;

        private string strCancelReason = null;
        private string strFax = null;







        private int intCancelStatus = 0;

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


        //Method of storing Sponsor_Id
        public int Sponsor_Id
        {
            get
            {
                return intSponsorId;
            }
            set
            {
                intSponsorId = value;
            }
        }

        
        //Methode for storing Country id of Sponsor.
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

        //Method for storing Sponsor name.
        public string Sponsor_Name
        {
            get
            {
                return strSponsorName;
            }
            set
            {
                strSponsorName = value;
            }
        }

        //Method for storing address of Sponsor 
        public string Address1
        {
            get
            {
                return strAdd1;
            }
            set
            {
                strAdd1 = value;
            }
        }

        //Method for storing address of Sponsor 
        public string Address2
        {
            get
            {
                return strAdd2;
            }
            set
            {
                strAdd2 = value;
            }
        }

        //Method for storing address of Sponsor 
        public string Address3
        {
            get
            {
                return strAdd3;
            }
            set
            {
                strAdd3 = value;
            }
        }

        
        //Method for storing phone number of Sponsor .
        public string Phone_Number
        {
            get
            {
                return strPhone;
            }
            set
            {
                strPhone = value;
            }
        }

        //Method for storing mobile number of Sponsor.
        public string Mobile_Number
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

        //Method of storing Web address of Sponsor. 
        public string Fax_Number
        {
            get
            {
                return strFax;
            }
            set
            {
                strFax = value;
            }
        }

        //Method of storing email address of Sponsor.
        public string Email_Address
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

        //Method of storing  status of Sponsor.
        public int Sponsor_Status
        {
            get
            {
                return intSponsorStatus;
            }
            set
            {
                intSponsorStatus = value;
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

        //Method of keeping date of the process.
        public DateTime SponsrDate
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

   

 
        //Method of storing organisation id.
        public int Organisation_Id
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


        public int SponsorType_Id
        {
            get
            {
                return intSponsorType;
            }
            set
            {
                intSponsorType = value;
            }
        }
      
         public string SponsorDoc_No
        {
            get
            {
                return intSponsorDocno;
            }
            set
            {
                intSponsorDocno = value;
            }
        }  
    }
}
