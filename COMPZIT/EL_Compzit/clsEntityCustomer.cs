using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:17/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the customer registration .

namespace EL_Compzit
{
    public class clsEntityCustomer
    {
        private Int64? intCountryId = 0;
        private Int64? intStateId = 0;
        private Int64? intCityId = 0;
        private int intNextId = 0;
        private int intNextValue = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private string strCustomerName = null;
        private string strAdd1 = null;
        private string strAdd2 = null;
        private string strAdd3 = null;
        private string strZipCode = null;
        private string strPhone = null;
        private string strMobile = null;
        private string strWebAdd = null;
        private string strEmail = null;
        private Int64 intCustomerStatus = 0;
        private Int64 intUserId = 0;
        private decimal? decCustomerLimit = 0;
        private int? intCustomerPeriod = 0;
        private DateTime dDate;
        private int intCustomerId = 0;
        private int intCustomerGroupId = 0;
        private string strCancelReason = null;
        private string strTINNumber=null;
        private int intCustomerTypeId = 0;
        private int intMediaId = 0;
        private string strMediaDescription = null;
        private int intUpdateDecide = 0;
        private int intLeadId = 0;
        private int intTemplateTypeId = 0;
        private int intTermTemplateId = 0;
        private string strPaymentTerms = "";
        private string strDeliveryTerms = "";
        private string strPriceTerms = "";
        private int intCancelStatus = 0;
        private string strRefnum = "";
        private int intMailAllowed = 0;

        private int intLdgerSts = 0;
        private int intLdgerID = 0;
        private string strCode = "";
        private int intCreditLimitRestrict = 0;
        private int intCreditPeriodRestrict = 0;
        private int intCreditLimitWarn = 0;
        private int intCreditPeriodWarn = 0;


        private string strCommonSearchTerm = "";
        private string strSearchName = "";
        private int intOrderColumn = 0;
        private int intOrderMethod = 0;
        private int intPageMaxSize = 0;
        private int intPageNumber = 0;
        private string strSearchRef = "";
        private string strSearchCustomer = "";
        private string strSearchStatus = "";


        private string strSearchCusName = "";
        private string strSearchAddress = "";
        private string strSearchGroup = "";
        private string strSearchType = "";
        public string SearchCusName
        {
            get
            {
                return strSearchCusName;
            }
            set
            {
                strSearchCusName = value;
            }
        }
        public string SearchAdress
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
        public string SearchGroup
        {
            get
            {
                return strSearchGroup;
            }
            set
            {
                strSearchGroup = value;
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

        public string SearchRef
        {
            get
            {
                return strSearchRef;
            }
            set
            {
                strSearchRef = value;
            }
        }


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
      
        public int CreditPeriodWarn
        {
            get
            {
                return intCreditPeriodWarn;
            }

            set
            {
                intCreditPeriodWarn = value;
            }
        }
        public int CreditLimitWarn
        {
            get
            {
                return intCreditLimitWarn;
            }

            set
            {
                intCreditLimitWarn = value;
            }
        }
        public int CreditPeriodRestrict
        {
            get
            {
                return intCreditPeriodRestrict;
            }

            set
            {
                intCreditPeriodRestrict = value;
            }
        }
        public int CreditLimitRestrict
        {
            get
            {
                return intCreditLimitRestrict;
            }

            set
            {
                intCreditLimitRestrict = value;
            }
        }
        public string CustomerCode
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
        public int LedgerId
        {
            get
            {
                return intLdgerID;
            }

            set
            {
                intLdgerID = value;
            }
        }
        public int LedgerSts
        {
            get
            {
                return intLdgerSts;
            }

            set
            {
                intLdgerSts = value;
            }
        }


        //methode of storing mail allowed id.
        public int MailAllowed
        {
            get
            {
                return intMailAllowed;
            }
            set
            {
                intMailAllowed = value;
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
        //methode of store lead id
        public int Lead_Id
        {
            get
            {
                return intLeadId;
            }
            set
            {
                intLeadId = value;
            }
        }

        //methode of storing update decide id
        public int Update_Decide
        {
            get
            {
                return intUpdateDecide;
            }
            set
            {
                intUpdateDecide = value;
            }
        }


        //Method of storing Customer id
        public int Customer_Id
        {
            get
            {
                return intCustomerId;
            }
            set
            {
                intCustomerId = value;
            }
        }

        //Method of storing Customer group id
        public int Customer_Group_Id
        {
            get
            {
                return intCustomerGroupId;
            }
            set
            {
                intCustomerGroupId = value;
            }
        }

        //Methode for storing Country id of Customer.
        public Int64? CountryId
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

        //Method for storing state id of Customer.
        public Int64? StateId
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

        //Method for storing city id of Customer.
        public Int64? CityId
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

        //Method for storing nextid of particular Customer.
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

        //Method for storing Customer name.
        public string Customer_Name
        {
            get
            {
                return strCustomerName;
            }
            set
            {
                strCustomerName = value;
            }
        }

        //Method for storing address of Customer 
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

        //Method for storing address of Customer 
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

        //Method for storing address of Customer 
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

        //Method fort storing zip code/pin code of Customer addrress .
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

        //Method for storing phone number of Customer .
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

        //Method for storing mobile number of Customer.
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

        //Method of storing Web address of Customer. 
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

        //Method of storing email address of Customer.
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

        //Method of storing  status of Customer.
        public Int64 Customer_Status
        {
            get
            {
                return intCustomerStatus;
            }
            set
            {
                intCustomerStatus = value;
            }
        }

        //Method of storing userid of the person who do the process.
        public Int64 UserId
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

        //Method of storing Customer credit amount limit.
        public decimal? Customer_Credit_Limit
        {
            get
            {
                return decCustomerLimit;
            }
            set
            {
                decCustomerLimit = value;
            }
        }

        //Method of storing Customer credit period
        public int? Customer_Credit_Period
        {
            get
            {
                return intCustomerPeriod;
            }
            set
            {
                intCustomerPeriod = value;
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
        //Method for storing TIN number
        public string TIN_Number
        {
            get
            {
                return strTINNumber;
            }
            set
            {
                strTINNumber = value;
            }
        }
        //methode for storing payment terms
        public string Payment_Terms
        {
            get
            {
                return strPaymentTerms;
            }
            set
            {
                strPaymentTerms = value;
            }
        }
        //methode of storing customer type id
        public int Customer_Type_Id
        {
            get
            {
                return intCustomerTypeId;
            }
            set
            {
                intCustomerTypeId = value;
            }
        }
        //methode of storing media id
        public int Media_Id
        {
            get
            {
                return intMediaId;
            }
            set
            {
                intMediaId = value;
            }
        }
        //methode of storing media description
        public string Media_Description
        {
            get
            {
                return strMediaDescription;
            }
            set
            {
                strMediaDescription = value;
            }
        }

        public int TemplateTypeId
        {
            get
            {
                return intTemplateTypeId;
            }
            set
            {
                intTemplateTypeId = value;
            }
        }
        public int TermTemplateId
        {
            get
            {
                return intTermTemplateId;
            }
            set
            {
                intTermTemplateId = value;
            }
        }

        //code 005 start
        //for storing delivery term details
        public string Delivery_Terms
        {
            get
            {
                return strDeliveryTerms;
            }
            set
            {
                strDeliveryTerms = value;
            }
        }
        //for storing price term details
        public string Price_Terms
        {
            get
            {
                return strPriceTerms;
            }
            set
            {
                strPriceTerms = value;
            }
        }
        public string CustomerRefnumber
        {
            get
            {
                return strRefnum;
            }
            set
            {
                strRefnum = value;
            }
        }
    }
}