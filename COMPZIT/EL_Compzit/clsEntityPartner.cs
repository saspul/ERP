using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
  public class clsEntityPartner
    {

        private int intCountryId = 0;
        private int intStateId = 0;
        private int intCityId = 0;
        private int intNextId = 0;
        private int intNextValue = 0;
        private int intOrgId = 0;
        private int intCorporate_id = 0;
        private string strName = null;
        private string strAdd1 = null;
        private string strAdd2 = null;
        private string strAdd3 = null;
        private string strZipCode = null;
        private string strPhone = null;
        private string strWebAdd = null;
        private string strEmail = null;
        private int intStatus = 0;
        private int intUserId = 0;
        private int intPartnerId = 0;
        private string strCancelReason = null;
        private string strTinNumber = null;
        private string strCcnNumber = null;
        private string strCrnNumber = null;
        private int intCancelStatus = 0;    
        private int intPartshipTypeId = 0;
        private string strFax = "";
        private string strEnqMail = "";
        private string strIconFname = "";
        private string strIconActFname = "";
        private string strDocNum = "";
        private DateTime dateDate;

        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchType = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        public string CommonSearchTerm
        {
            get
            {
                return strCommonSearchTerm;
            }
            set
            {
                strCommonSearchTerm = value;
            }
        }
        public string SearchName
        {
            get
            {
                return strSearchName;
            }
            set
            {
                strSearchName = value;
            }
        }
        public string SearchType
        {
            get
            {
                return strSearchType;
            }
            set
            {
                strSearchType = value;
            }
        }
        public int OrderColumn
        {
            get
            {
                return intOrderColumn;
            }
            set
            {
                intOrderColumn = value;
            }
        }
        public int OrderMethod
        {
            get
            {
                return intOrderMethod;
            }
            set
            {
                intOrderMethod = value;
            }
        }
        public int PageMaxSize
        {
            get
            {
                return intPageMaxSize;
            }
            set
            {
                intPageMaxSize = value;
            }
        }
        public int PageNumber
        {
            get
            {
                return intPageNumber;
            }
            set
            {
                intPageNumber = value;
            }
        }
        //----------------Pageination--------------------

        //Method for keeping date
        public DateTime date
        {
            get
            {
                return dateDate;
            }
            set
            {
                dateDate = value;
            }
        }
        //methode for document number
        public string DocNum
        {
            get
            {
                return strDocNum;
            }
            set
            {
                strDocNum = value;
            }
        }

        //methode for icon file name
        public string IconFname
        {
            get
            {
                return strIconFname;
            }
            set
            {
                strIconFname = value;
            }
        }
        //methode for icon actual file name
        public string IconActFname
        {
            get
            {
                return strIconActFname;
            }
            set
            {
                strIconActFname = value;
            }
        }
       
        //methode for storing fax
        public string Fax
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
        //methode for storing enquiry mail
        public string EnqMail
        {
            get
            {
                return strEnqMail;
            }
            set
            {
                strEnqMail = value;
            }
        }

      

        //methode for storing CRN number
        public string CRNnum
        {
            get
            {
                return strCrnNumber;
            }
            set
            {
                strCrnNumber = value;
            }
        }

        //methode for storing TIN number
        public string TINnum
        {
            get
            {
                return strTinNumber;
            }
            set
            {
                strTinNumber = value;
            }
        }

        //methode for storing CCN number
        public string CCNnum
        {
            get
            {
                return strCcnNumber;
            }
            set
            {
                strCcnNumber = value;
            }
        }

        //methode for storing partnership type id
        public int PartshipTypeId
        {
            get
            {
                return intPartshipTypeId;
            }
            set
            {
                intPartshipTypeId = value;
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
        //Method of storing partner id
        public int PartnerId
        {
            get
            {
                return intPartnerId;
            }
            set
            {
                intPartnerId = value;
            }
        }

        //Methode for storing Country id of organisation.
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

        //Method for storing state id of organisation.
        public int StateId
        {
            get
            {
                return intStateId;
            }
            set
            {
                intStateId = value;
            }
        }

        //Method for storing city id of organisation.
        public int CityId
        {
            get
            {
                return intCityId;
            }
            set
            {
                intCityId = value;
            }
        }

        //Method for storing nextid of particular department.
        public int NextId
        {
            get
            {
                return intNextId;
            }
            set
            {
                intNextId = value;
            }
        }

        //Method of Storing next value for table insertion.
        public int NextValue
        {
            get
            {
                return intNextValue;
            }
            set
            {
                intNextValue = value;
            }
        }

       

        //Method for storing Partner name.
        public string PartnerName
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }

        //Method for storing address of corporation office
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

        //Method for storing address of corporation office
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

        //Method for storing address of corporation office
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

        //Method fort storing zip code/pin code of Corporation office address.
        public string ZipCode
        {
            get
            {
                return strZipCode;
            }
            set
            {
                strZipCode = value;
            }
        }

        //Method for storing phone number of corporation office.
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

      

        //Method of storing Web address of corporation office. 
        public string Web_Address
        {
            get
            {
                return strWebAdd;
            }
            set
            {
                strWebAdd = value;
            }
        }

        //Method of storing email address of corporation office.
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

        //Method of storing  status .
        public int StatusId
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
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
        //intCorporate_id
        public int Corporate_id
        {
            get
            {
                return intCorporate_id;
            }
            set
            {
                intCorporate_id = value;
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
       
      
       
    }
}
