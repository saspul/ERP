using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
   public class clsEntityCommon
    {
        private int intUomId = 0;
        private int intCorporateOfficeID=0;
        private int intOrgid = 0;
        private int intSectionId = 0;
        private int intWrkAreaId = 0;
        private int intCorpMailTmpltTypId = 0;
        private int intCurrencyId = 0;    
        private string strCorpDivisionCode = "";
        private int intYearRef = 0;
        private int intMonthRef = 0;
        private string strUserCodeRef = "";
        private int intQtnId = 0;
        private string strRvsnVrsnRef = "";
        private int intCorporateDivId = 0;
        private string strCommonLabelFieldName = "";
        private int intVhclRnwlAlrtMod = 0;
        private int intVhclRnwlAlrtVal = 0;
        private int intFinancialYrId = 0;
        private string strRedirectUrl="";
        private int intVouchar_Type = 0;
        private string strPrimaryGrpId = "";
        private string strCorprtIds = "";
        private DateTime dtDate;
        private int intRecurPeriodId = 0;
        private int intRecurRemindDays = 0;
        private DateTime dRecurDate;
        private int intRecurReceiptId = 0;
        private int intRecurMasterId = 0;
        private int intRecurSubId = 0;
        private int intUserId = 0;
        private string strSearch = "";
        //evm 0044
        private int intDefaultModId = 0;
        //evm-0043 start
        private int intshowZerosts = 0;
        private string strYear = "";
        //0041
        private int intPkId = 0;
        private string strValue = "";
        private string strLabel = "";
        private int intDataType = 0;
        private int intType = 0;
        private int intdynid = 0;
        //end



        //0041

        public int PKId
        {
            get
            {
                return intPkId;
            }
            set
            {
                intPkId = value;
            }
        }


        public int Dynid
        {
            get
            {
                return intdynid;
            }
            set
            {
                intdynid = value;
            }
        }

        public int DataType
        {
            get
            {
                return intDataType;
            }
            set
            {
                intDataType = value;
            }
        }

        public int Type
        {
            get
            {
                return intType;
            }
            set
            {
                intType = value;
            }
        }

        public string Value
        {
            get
            {
                return strValue;
            }
            set
            {
                strValue = value;
            }
        }

        public string Label
        {
            get
            {
                return strLabel;
            }
            set
            {
                strLabel = value;
            }
        }
        //end
        public int ShowZerosts
        {
            get
            {
                return intshowZerosts;
            }
            set
            {
                intshowZerosts = value;
            }
        }
        public string strYears
        {
            get
            {
                return strYear;
            }
            set
            {
                strYear = value;
            }
        }
        //end----
        //evm 0044------
        public int DefaultModId
        {
            get { return intDefaultModId; }
            set { intDefaultModId = value; }
        }
        //--------------
        public string Searchstring
        {
            get
            {
                return strSearch;
            }
            set
            {
                strSearch = value;
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
        public int RecurPeriodId
        {
            get
            {
                return intRecurPeriodId;
            }
            set
            {
                intRecurPeriodId = value;
            }
        }

        public int RecurRemindDays
        {
            get
            {
                return intRecurRemindDays;
            }
            set
            {
                intRecurRemindDays = value;
            }
        }

        public int RecurReceiptId
        {
            get
            {
                return intRecurReceiptId;
            }
            set
            {
                intRecurReceiptId = value;
            }
        }

        public int RecurMasterId
        {
            get
            {
                return intRecurMasterId;
            }
            set
            {
                intRecurMasterId = value;
            }
        }

        public int RecurSubId
        {
            get
            {
                return intRecurSubId;
            }
            set
            {
                intRecurSubId = value;
            }
        }

        public DateTime RecurDate
        {
            get
            {
                return dRecurDate;
            }
            set
            {
                dRecurDate = value;
            }
        }


        public DateTime Date
        {
            get { return dtDate; }
            set { dtDate = value; }
        }
        public string CorprtIds
        {
            get { return strCorprtIds; }
            set { strCorprtIds = value; }
        }
        public string PrimaryGrpIds
        {
            get { return strPrimaryGrpId; }
            set { strPrimaryGrpId = value; }
        }
        public int Vouchar_Type
        {
            get { return intVouchar_Type; }
            set { intVouchar_Type = value; }
        }
        public int FinancialYrId
        {
            get { return intFinancialYrId; }
            set { intFinancialYrId = value; }
        }

        public string RedirectUrl
        {
            get { return strRedirectUrl; }
            set { strRedirectUrl = value; }
        }



       //for storing field name of common labeling
        public string CommonLabelFieldName
        {
            get
            {
                return strCommonLabelFieldName;
            }
            set
            {
                strCommonLabelFieldName = value;
            }
        }

        //Method of storing id of WrkArea 
        public int WrkAreaId
        {
            get
            {
                return intWrkAreaId;
            }
            set
            {
                intWrkAreaId = value;
            }
        }
        //Method of storing id of uom 
        public int UOM_Id
        {
            get
            {
                return intUomId;
            }
            set
            {
                intUomId = value;
            }
        }
        //Method for storing section id(Ledger)
        public int SectionId
        {
            get
            {
                return intSectionId;
            }
            set
            {
                intSectionId = value;
            }
        }
        //Method for storing Login Corporate Office ID
        public int CorporateID
        {
            get
            {
                return intCorporateOfficeID;
            }
            set
            {
                intCorporateOfficeID = value;
            }
        }  //property for storing organistion id.
        public int Organisation_Id
        {
            get
            {
                return intOrgid;
            }
            set
            {
                intOrgid = value;
            }
        }
        //property for storing tempalte type  id.
        public int CorpMailTmpltTypId
        {
            get
            {
                return intCorpMailTmpltTypId;
            }
            set
            {
                intCorpMailTmpltTypId = value;
            }
        }
        public int CurrencyId
        {
            get
            {
                return intCurrencyId;
            }
            set
            {
                intCurrencyId = value;
            }
        }

        public string CorpDivisionCode
        {
            get
            {
                return strCorpDivisionCode;
            }
            set
            {
                strCorpDivisionCode = value;
            }
        }
        public int YearRef
        {
            get
            {
                return intYearRef;
            }
            set
            {
                intYearRef = value;
            }
        }
        public int MonthRef
        {
            get
            {
                return intMonthRef;
            }
            set
            {
                intMonthRef = value;
            }
        }
        public string UserCodeRef
        {
            get
            {
                return strUserCodeRef;
            }
            set
            {
                strUserCodeRef = value;
            }
        }
        public int QtnId
        {
            get
            {
                return intQtnId;
            }
            set
            {
                intQtnId = value;
            }
        }
        public string RvsnVrsnRef
        {
            get
            {
                return strRvsnVrsnRef;
            }
            set
            {
                strRvsnVrsnRef = value;
            }
        }
        public int CorporateDivId
        {
            get
            {
                return intCorporateDivId;
            }
            set
            {
                intCorporateDivId = value;
            }
        }
        public int VhclRnwlAlrtMod
        {
            get
            {
                return intVhclRnwlAlrtMod;
            }
            set
            {
                intVhclRnwlAlrtMod = value;
            }
        }
        public int VhclRnwlAlrtVal
        {
            get
            {
                return intVhclRnwlAlrtVal;
            }
            set
            {
                intVhclRnwlAlrtVal = value;
            }
        }
    }


   public class clsEntityQueryString
   {
       private int intEncrypt=0;
       // if value is 1 encrypt
       public int Encrypt
       {
           get { return intEncrypt; }
           set { intEncrypt = value; }
       }
       private string strQueryString="";

       public string QueryString
       {
           get { return strQueryString; }
           set { strQueryString = value; }
       }
       private string strQueryStringValue = "";

       public string QueryStringValue
       {
           get { return strQueryStringValue; }
           set { strQueryStringValue = value; }
       }


   }
}
