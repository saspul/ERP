using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0001
// CREATED DATE:13/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is a Entity layer for the Country Master .
namespace EL_Compzit
{
    public class clsEntityCountry
    {
        private int intCountryId = 0;
        private int intCountryCancel = 0;
        private string strCountryName = "";
        private int intCountryPreInstl = 0;
        private int intStatus = 0;
        private int intUserId;
        private string strCnclReason = "";
        private DateTime dateofEvent;


        private string strCommonSearchTerm = "";
        private string strSearchCountry = "";
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
        public string SearchCountry
        {
            get
            {
                return strSearchCountry;
            }
            set
            {
                strSearchCountry = value;
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

        private int intPreinstall = 0;
        // This is the property definition for storing Country Pre installed or not.
        public int CountryPreInstl
        {
            get
            {
                return intCountryPreInstl;
            }
            set
            {
                intCountryPreInstl = value;
            }
        }

        // This is the property definition for storing Id of Country Master.
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
        //Storing the country id when it get cancel event.
        public int CountryCancelId
        {
            get
            {
                return intCountryCancel;
            }
            set
            {
                intCountryCancel = value;
            }
        }
        // This is the property definition for storing UserId of the User logined.
        public int CountryUserId
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

        // This is the property definition for storing Status of Country Master.
        public int CountryStatus
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
        // This is the property definition for storing Country name entered .
        public string CountryName
        {
            get
            {
                return strCountryName;
            }
            set
            {
                strCountryName = value;
            }
        }
        // This is the property definition for storing Cancelation reason .
        public string CountryCancelReason
        {
            get
            {
                return strCnclReason;
            }
            set
            {
                strCnclReason = value;
            }
        }
        // This is the property definition for storing Date of updation and cancelation .
        public DateTime CountryDate
        {
            get
            {
                return dateofEvent;
            }
            set
            {
                dateofEvent = value;
            }
        }
        public int Preinstall
        {
            get
            {
                return intPreinstall;
            }
            set
            {
                intPreinstall = value;
            }
        }
    }
}
