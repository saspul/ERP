using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CREATED BY:EVM-0002
// CREATED DATE:16/05/2015
// REVIEWED BY:
// REVIEW DATE
namespace EL_Compzit
{
   public class clsEntityCityMaster
   {
       private  string strCityName = null;
       private  int intCityStateId = 0;
       private  int intCityStatus = 0;
       private  string strCityCancelReason = null;
       private  int intUserId = 0;
       private int intCityMasterId = 0;
       private DateTime strDate;
       private int intPreinstall = 0;
       private int intCancelStatus = 0;
       private int intCountryId = 0;
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
       private string strCommonSearchTerm = "";
       private string strSearchCity = "";
       private string strSearchState = "";
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
       public string SearchState
       {
           get
           {
               return strSearchState;
           }
           set
           {
               strSearchState = value;
           }
       }
       public string SearchCity
       {
           get
           {
               return strSearchCity;
           }
           set
           {
               strSearchCity = value;
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
       //methode to store cancel status
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

        //Method for storing city name.
        public string CityName
        {
            get
            {
                return strCityName;
            }
            set
            {
                strCityName = value;
            }
        }
        //Method for storing city include state name.
        public int CityStateId
        {
            get
            {
                return intCityStateId;
            }
            set
            {
                intCityStateId = value;
            }
        }
        //Method for storing city status(active or inactive).
        public int CityStatus
        {
            get
            {
                return intCityStatus;
            }
            set
            {
                intCityStatus = value;
            }
        }
        //Method for storing Reason for City cancel if any.
        public string CityCancelReason
        {
            get
            {
                return strCityCancelReason;
            }
            set
            {
                strCityCancelReason = value;
            }
        }
        //Method for storing UserId of Proceding Person.
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
        //Method for storing Id in the city master table.
        public int CityMasterId
        {
            get
            {
                return intCityMasterId;
            }
            set
            {
                intCityMasterId = value;
            }
        }
        //Method for storing date of process.
        public DateTime Date
        {
            get
            {
                return strDate;
            }
            set
            {
                strDate = value;
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
