using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:26/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Organisation registration parking .

namespace EL_Compzit
{
    public class clsEntityOrgParking
    {
        private int intFrameworkId = 0;
        private int intCountryId = 0;
        private int? intStateId = 0;
        private int? intCityId = 0;
        private int intLicPacId = 0;
        private int intCorPacId = 0;
        private int intLicPacCount = 0;
        private int intCorPacCount = 0;
        private int intNextId = 0;
        private int intNextValue = 0;
        private int intOrgTypeId = 0;
        private string strOrgName = null;
        private string strAdd1 = null;
        private string strAdd2 = null;
        private string strAdd3 = null;
        private string strZipCode = null;
        private string strPhone = null;
        private string strMobile = null;
        private string strWebAdd = null;
        private string strEmail = null;
        private string strPwd = null;
        private string strEncryPwd = null;
        private int intOrgStatusId = 0;
        private int intUserId = 0;
        private DateTime OrgStatusDate;
        private string strIPAdd = null;
        private DateTime InsertDate;
        private string strVerfnCode = null;
        private string strVerfnLink = null;

        private string strContactName = null;


        public int FrameworkId
        {
            get
            {
                return intFrameworkId;
            }
            set
            {
                intFrameworkId = value;
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
        public int? StateId
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
        public int? CityId
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

        //Method for storing license pack id.
        public int LicPacId
        {
            get
            {
                return intLicPacId;
            }
            set
            {
                intLicPacId = value;
            }
        }

        //Method for storing max users allowed on particular license pack.
        public int LicPacCount
        {
            get
            {
                return intLicPacCount;
            }
            set
            {
                intLicPacCount = value;
            }
        }

        //Methode of storing corporate pack id.
        public int CorPacId
        {
            get
            {
                return intCorPacId;
            }
            set
            {
                intCorPacId = value;
            }
        }

        //Methode of storing count of offices allowed in particular corporate office.
        public int CorPacCount
        {
            get
            {
                return intCorPacCount;
            }
            set
            {
                intCorPacCount = value;
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

        //Method for storing organisation type id.
        public int OrgTypeId
        {
            get
            {
                return intOrgTypeId;
            }
            set
            {
                intOrgTypeId = value;
            }
        }

        //Method for storing organisation name.
        public string Organisation_Name
        {
            get
            {
                return strOrgName;
            }
            set
            {
                strOrgName = value;
            }
        }

        //Method for storing address of organisation
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

        //Method for storing address of organisation
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

        //Method for storing address of organisation
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

        //Method fort storing zip code/pin code of organisation address.
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

        //Method for storing phone number of organisation.
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

        //Method for storing mobile number of organisation.
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

        //Method of storing Web address of organisation. 
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

        //Method of storing email address of organisation.
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

        //Method of storing password of organisation.
        public string Password
        {
            get
            {
                return strPwd;
            }
            set
            {
                strPwd = value;
            }
        }

        //Method of storing the encrypted password.
        public string EncryptPassword
        {
            get
            {
                return strEncryPwd;
            }
            set
            {
                strEncryPwd = value;
            }
        }

        //Method of storing organisation status id.
        public int OrgStatusId
        {
            get
            {
                return intOrgStatusId;
            }
            set
            {
                intOrgStatusId = value;
            }
        }

        //Method of storing userid of the person who do registration.
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

        //Method of keeping date of data updation if any.
        public DateTime OrganisationStatusDate
        {
            get
            {
                return OrgStatusDate;
            }
            set
            {
                OrgStatusDate = value;
            }
        }

        //Method for keeping the date of organisation details insertion.
        public DateTime OrgInsertDate
        {
            get
            {
                return InsertDate;
            }
            set
            {
                InsertDate = value;
            }
        }

        //Method of storing ip address of organisation.
        public string IP_Address
        {
            get
            {
                return strIPAdd;
            }
            set
            {
                strIPAdd = value;
            }
        }
        //Method of storing verification code,that send through email.
        public string Verification_Code
        {
            get
            {
                return strVerfnCode;
            }
            set
            {
                strVerfnCode = value;
            }
        }
        //Method of storing verification link,that send through email.
        public string Verification_Link
        {
            get
            {
                return strVerfnLink;
            }
            set
            {
                strVerfnLink = value;
            }
        }

        //Method of storing Contact pesron name of organisation.
        public string Contact_Person
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

    }
}
