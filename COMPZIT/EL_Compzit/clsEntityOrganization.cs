using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
   public class clsEntityOrganization
    {
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

        private int intOrgId = 0;
        private int intCorpId = 0;
        private string strCRnumber = null;
        private DateTime CrExpDate;
        private DateTime CrIssueDate;
        private string strTXnumber = null;
        private DateTime TxExpDate;
        private DateTime TxIssueDate;
        private string strCompNumber = null;
        private DateTime CompExpDate;
        private DateTime CompIssueDate;
        private int intCrRoll = 0;
        private int intTxRoll = 0;
        private int intCompRoll = 0;

        private int intOrgAppMode = 0;

        public int OrgAppMode
        {
            get
            {
                return intOrgAppMode;
            }
            set
            {
                intOrgAppMode = value;
            }
        }


        //Methode for storing COMPUTER CARD roll id.
        public int CompRoll
        {
            get
            {
                return intCompRoll;
            }
            set
            {
                intCompRoll = value;
            }
        }
        //Methode for storing TAX CARD roll id.
        public int TxRoll
        {
            get
            {
                return intTxRoll;
            }
            set
            {
                intTxRoll = value;
            }
        }
        //Methode for storing COMMERCIAL REGISTRATION roll id.
        public int CrRoll
        {
            get
            {
                return intCrRoll;
            }
            set
            {
                intCrRoll = value;
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
        //0013
        //Methode for storing id of organisation.
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
        //Method of storing Commercial Registration number.
        public string CRnumber
        {
            get
            {
                return strCRnumber;
            }
            set
            {
                strCRnumber = value;
            }
        }
        //Method of keeping Expiry date of Commercial Registration number.
        public DateTime CrNumExpDate
        {
            get
            {
                return CrExpDate;
            }
            set
            {
                CrExpDate = value;
            }
        }
        //Method of keeping Issue date of Commercial Registration number.
        public DateTime CrNumIssueDate
        {
            get
            {
                return CrIssueDate;
            }
            set
            {
                CrIssueDate = value;
            }
        }
        //Method of storing Tax Card number.
        public string TxNumber
        {
            get
            {
                return strTXnumber;
            }
            set
            {
                strTXnumber = value;
            }
        }
        //Method of keeping Expiry date of Tax Card number.
        public DateTime TxNumExpDate
        {
            get
            {
                return TxExpDate;
            }
            set
            {
                TxExpDate = value;
            }
        }
        //Method of keeping Issue date of Tax Card number.
        public DateTime TxNumIssueDate
        {
            get
            {
                return TxIssueDate;
            }
            set
            {
                TxIssueDate = value;
            }
        }
        //Method of storing Computer Card number.
        public string CompNumber
        {
            get
            {
                return strCompNumber;
            }
            set
            {
                strCompNumber = value;
            }
        }
        //Method of keeping Expiry date of Computer Card number.
        public DateTime CompNumExpDate
        {
            get
            {
                return CompExpDate;
            }
            set
            {
                CompExpDate = value;
            }
        }
        //Method of keeping Issue date of Computer Card number.
        public DateTime CompNumIssueDate
        {
            get
            {
                return CompIssueDate;
            }
            set
            {
                CompIssueDate = value;
            }
        }
    }
   public class clsEntityAttachment
   {
       private int intRnwlAttchmntDtlId = 0;
       private string strFileName = "";
       private string strActualFileName = "";
       private int intRnwlAttchmntSlNumber = 0;
       private int intRnwlId = 0;
       private int intCorpOffice_Id = 0;
       private int intRnwlFileType = 0;
       private string strDescrptn = "";
       private int intCardRol = 0;
       private int intOrgId = 0;
       //Methode for storing id of organisation.
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
       //property of storing card roll id of attachment
       public int CardRol
       {
           get
           {
               return intCardRol;
           }
           set
           {
               intCardRol = value;
           }
       }

       //property of storing Detail id of attachment
       public int RnwlAttchmntDtlId
       {
           get
           {
               return intRnwlAttchmntDtlId;
           }
           set
           {
               intRnwlAttchmntDtlId = value;
           }
       }


       //Property of storing the file name of attachment
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
       //property of storing actual file name of attachment 
       public string ActualFileName
       {
           get
           {
               return strActualFileName;
           }
           set
           {
               strActualFileName = value;
           }
       }
       //property of storing Slnumber of  attachment
       public int RnwlAttchmntSlNumber
       {
           get
           {
               return intRnwlAttchmntSlNumber;
           }
           set
           {
               intRnwlAttchmntSlNumber = value;
           }
       }

       public int RnwlId
       {
           get
           {
               return intRnwlId;
           }
           set
           {
               intRnwlId = value;
           }
       }
       public int CorpOffice_Id
       {
           get
           {
               return intCorpOffice_Id;
           }
           set
           {
               intCorpOffice_Id = value;
           }
       }

       public int RnwlFileType
       {
           get
           {
               return intRnwlFileType;
           }
           set
           {
               intRnwlFileType = value;
           }
       }

       //Property of storing the description of attachment
       public string Description
       {
           get
           {
               return strDescrptn;
           }
           set
           {
               strDescrptn = value;
           }
       }

   }
   public class clsEntityAttachmentDtl
   {
       private int intRnwlAttchmntDtlId = 0;
       private string strFileName = "";
       private string strActualFileName = "";
       private int intRnwlAttchmntSlNumber = 0;
       private int intRnwlId = 0;
       private int intCorpOffice_Id = 0;
       private int intRnwlFileType = 0;
       private string strDescrptn = "";
       //property of storing Detail id of attachment
       public int RnwlAttchmntDtlId
       {
           get
           {
               return intRnwlAttchmntDtlId;
           }
           set
           {
               intRnwlAttchmntDtlId = value;
           }
       }


       //Property of storing the file name of attachment
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
       //property of storing actual file name of attachment 
       public string ActualFileName
       {
           get
           {
               return strActualFileName;
           }
           set
           {
               strActualFileName = value;
           }
       }
       //property of storing Slnumber of  attachment
       public int RnwlAttchmntSlNumber
       {
           get
           {
               return intRnwlAttchmntSlNumber;
           }
           set
           {
               intRnwlAttchmntSlNumber = value;
           }
       }

       public int RnwlId
       {
           get
           {
               return intRnwlId;
           }
           set
           {
               intRnwlId = value;
           }
       }
       public int CorpOffice_Id
       {
           get
           {
               return intCorpOffice_Id;
           }
           set
           {
               intCorpOffice_Id = value;
           }
       }

       public int RnwlFileType
       {
           get
           {
               return intRnwlFileType;
           }
           set
           {
               intRnwlFileType = value;
           }
       }

       //Property of storing the description of attachment
       public string Description
       {
           get
           {
               return strDescrptn;
           }
           set
           {
               strDescrptn = value;
           }
       }
   }
   public class clsAddPartner
   {
       private int intRnwlId = 0;
       private int intOrgId = 0;
       private string strPartnerName = "";
       private string strDocNo = "";
       private string strCrNo = "";
       private int intContry = 0;
       private decimal  intPercent= 0;
       private int intStatus = 0;


       public int RnwlId
       {
           get
           {
               return intRnwlId;
           }
           set
           {
               intRnwlId = value;
           }
       }
       public string PartnerName
       {
           get
           {
               return strPartnerName;
           }
           set
           {
               strPartnerName = value;
           }
       }
       public string DocNo
       {
           get
           {
               return strDocNo;
           }
           set
           {
               strDocNo = value;
           }
       }
       public string CrNo
       {
           get
           {
               return strCrNo;
           }
           set
           {
               strCrNo = value;
           }
       }
       public int orgId
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
       public int Contry
       {
           get
           {
               return intContry;
           }
           set
           {
               intContry = value;
           }
       }
       public decimal Percent
       {
           get
           {
               return intPercent;
           }
           set
           {
               intPercent = value;
           }
       }
       public int Status
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
   }
   
}
