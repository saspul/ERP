using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:03/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Corporate office registration .

namespace EL_Compzit
{
    public class clsEntityCorpOffice
    {
        private  int intCountryId = 0;
        private  int? intStateId = 0;
        private  int? intCityId = 0;
        private  int intNextId = 0;
        private  int intNextValue = 0;
        private  int intCorpTypeId = 0;
        private  int intOrgId = 0;
        private  string strCorpName = null;
        private  string strAdd1 = null;
        private  string strAdd2 = null;
        private  string strAdd3 = null;
        private  string strZipCode = null;
        private  string strPhone = null;
        private  string strMobile = null;
        private  string strWebAdd = null;
        private  string strEmail = null;
        private  int intCorpStatus = 0;
        private  int intUserId = 0;
        private  int intFiscalMonth = 0;
        private DateTime AppDate;
        private DateTime CorpDate;
        private  int intCorpOfficeId = 0;
        private  string strCancelReason = null;
        private string strTinNumber = null;
        private string strCustCareNumber = null;
        private string strShortName = null;
        private string strShortAddress = null;
        private string strCinNumber=null;
        private int intCancelStatus = 0;
        //new code
        private string strCode = "";
        private int intBsnsTypeId = 0;
        private int intShareTypeId = 0;
        private string strFax = "";
        private string strEnqMail = "";
        private string strStrgMail = "";
        private string strIcon = "";
        private int intRemveStrg = 0;
        private int intParentUntTypeId = 0;
        private int intCmpnyShare = 0;
        private string strCRN = "";
        private DateTime dateCRNExp;
        private DateTime dateCRNIss;
        private string strTIN = "";
        private DateTime dateTINxp;
        private DateTime dateTINIss;
        private string strCCN = "";
        private DateTime dateCCNxp;
        private DateTime dateCCNIss;
        private string strActIcon = "";



        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private string strSearchAddress = "";
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
        public string SearchAddress
        {
            get
            {
                return strSearchAddress;
            }
            set
            {
                strSearchAddress = value;
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



        private int intPartnerId = 0;
        private int intCrno = 0;
        private DateTime dtchkintime;
        private DateTime dtchkoutime;
        //to read cr No
        public int crNo
        {
            get
            {
                return intCrno;
            }
            set
            {
                intCrno = value;
            }
        }
        //method for storing the Partner Id
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
        //methode for icon file name
        public string Icon
        {
            get
            {
                return strIcon;
            }
            set
            {
                strIcon = value;
            }
        }
        //methode for icon actual file name
        public string ActIcon
        {
            get
            {
                return strActIcon;
            }
            set
            {
                strActIcon = value;
            }
        }

        //methode for storing code
        public string Code
        {
            get
            {
                return strCode;
            }
            set
            {
                strCode = value;
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

        //methode for storing storage mail
        public string StorageMail
        {
            get
            {
                return strStrgMail;
            }
            set
            {
                strStrgMail = value;
            }
        }

        //methode for storing CRN number
        public string CRNnum
        {
            get
            {
                return strCRN;
            }
            set
            {
                strCRN = value;
            }
        }

        //methode for storing TIN number
        public string TINnum
        {
            get
            {
                return strTIN;
            }
            set
            {
                strTIN = value;
            }
        }

        //methode for storing CCN number
        public string CCNnum
        {
            get
            {
                return strCCN;
            }
            set
            {
                strCCN = value;
            }
        }

        //methode for storing business type id
        public int BsnsTypeId
        {
            get
            {
                return intBsnsTypeId;
            }
            set
            {
                intBsnsTypeId = value;
            }
        }

        //methode for storing share type id
        public int ShareTypeId
        {
            get
            {
                return intShareTypeId;
            }
            set
            {
                intShareTypeId = value;
            }
        }

        //methode for storing remove storage
        public int RemoveStrg
        {
            get
            {
                return intRemveStrg;
            }
            set
            {
                intRemveStrg = value;
            }
        }

        //methode for storing parent type id
        public int ParentTypId
        {
            get
            {
                return intParentUntTypeId;
            }
            set
            {
                intParentUntTypeId = value;
            }
        }

        //methode for storing company share percentage
        public int CmpnySharePer
        {
            get
            {
                return intCmpnyShare;
            }
            set
            {
                intCmpnyShare = value;
            }
        }

        //Method for keeping expiry date of CRN.
        public DateTime CRNexpDate
        {
            get
            {
                return dateCRNExp;
            }
            set
            {
                dateCRNExp = value;
            }
        }
        //Method for keeping expiry date of TIN.
        public DateTime TINexpDate
        {
            get
            {
                return dateTINxp;
            }
            set
            {
                dateTINxp = value;
            }
        }
        //Method for keeping expiry date of CCN.
        public DateTime CCNexpDate
        {
            get
            {
                return dateCCNxp;
            }
            set
            {
                dateCCNxp = value;
            }
        }
        //Method for keeping issue date of CRN.
        public DateTime CRNissDate
        {
            get
            {
                return dateCRNIss;
            }
            set
            {
                dateCRNIss = value;
            }
        }
        //Method for keeping issue date of TIN.
        public DateTime TINissDate
        {
            get
            {
                return dateTINIss;
            }
            set
            {
                dateTINIss = value;
            }
        }
        //Method for keeping issue date of CCN.
        public DateTime CCNissDate
        {
            get
            {
                return dateCCNIss;
            }
            set
            {
                dateCCNIss = value;
            }
        }
        //new code

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
        //Method of storing corporate office id
        public int CorpOfficeId
        {
            get
            {
                return intCorpOfficeId;
            }
            set
            {
                intCorpOfficeId = value;
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

        //Method for storing Corporation type id.
        public int CorpTypeId
        {
            get
            {
                return intCorpTypeId;
            }
            set
            {
                intCorpTypeId = value;
            }
        }

        //Method for storing Corporation Office name.
        public string Corporation_Name
        {
            get
            {
                return strCorpName;
            }
            set
            {
                strCorpName = value;
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

        //Method for storing mobile number of corporation office.
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
        public int CorpStatus
        {
            get
            {
                return intCorpStatus;
            }
            set
            {
                intCorpStatus = value;
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

        //Method of keeping date of data when the application will start.
        public DateTime ApplicationDate
        {
            get
            {
                return AppDate;
            }
            set
            {
                AppDate = value;
            }
        }

        //Method for keeping the date of Corporate Office details insertion.
        public DateTime dDate
        {
            get
            {
                return CorpDate;
            }
            set
            {
                CorpDate = value;
            }
        }

        //Method of storing starting Fiscal month.
        public int FiscalMonth
        {
            get
            {
                return intFiscalMonth;
            }
            set
            {
                intFiscalMonth = value;
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
        //method for storing TIN Number
        public string TIN_Number
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
        //method for storing Customer Care Number
        public string Cust_Care_Number
        {
            get
            {
                return strCustCareNumber;
            }
            set
            {
                strCustCareNumber = value;
            }
        }
        //method for storing short name of the corp office
        public string Short_Name
        {
            get
            {
                return strShortName;
            }
            set
            {
                strShortName = value;
            }
        }
        //method for storing short address of the corp office 
        public string Short_Address
        {
            get
            {
                return strShortAddress;
            }
            set
            {
                strShortAddress = value;
            }
        }
        //methode for storing company identification number
        public string Cin_Number
        {
            get
            {
                return strCinNumber;
            }
            set
            {
                strCinNumber = value;
            }
        }
        public DateTime CheckIn
        {
            get
            {
                return dtchkintime;
            }
            set
            {
                dtchkintime = value;
            }
        }
        public DateTime CheckOut
        {
            get
            {
                return dtchkoutime;
            }
            set
            {
                dtchkoutime = value;
            }
        }
    }
    public class clsEntityBankDtl
    {
        private int intBankId = 0;
        private int intDtlId = 0;
        private string strBranch = "";
        private string strIban = "";

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
        public int DtlId
        {
            get
            {
                return intDtlId;
            }
            set
            {
                intDtlId = value;
            }
        }

        public string Branch
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

        public string IBAN
        {
            get
            {
                return strIban;
            }
            set
            {
                strIban = value;
            }
        }
     
    }
}
