using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
    //START
    //EVM040
    public class clsEntityAppSetting
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        //HCM
        //leavesettlement
        private int LEVSTRTDT_HOLIDAYSTS = 0;
        private int LEVEND_HOLIDAYSTS = 0;
        private int LEVSTRTDT_OFFDUTYSTS = 0;
        private int LEVEND_OFFDUTYSTS = 0;
        private int OFFDUTYDAYS_STATUS = 0;      
        private int ELIGIBLE_LEAVE_STLMNT_LMT = 0;
        private int EMPDLYHR_FUTURE_DAYS = 0;
        private int GN_LEAVE_SETTLE_DAYS = 0;

        //payroll
        private int BASIC_PAY = 0;
        private int PAYROLL_INDIVIDUAL_ROUND = 0;
        private DateTime COPRT_SALARY_DATE=new DateTime();
        private DateTime GRATUITY_START_DATE = new DateTime();
        private int ELIGIBLE_GRATUITY_DAYS = 0;
        private int WORKDAY_FIXED_PAYRL_MODE = 0;
        private int FIXED_PAYRL_MODE_JOIN = 0;    

        //dutyrejoin
        private int REJOIN_CONFIRMATION_MODE = 0;
        private int JOINING_DATE_LIMIT = 0;

        //employeesection
        private string EMP_REF_FORMAT;
        private int EMPID_AUTOFILL_STS = 0;

        //mails

        private string HR_EMAIL;
        private string RPLY_NO_MAIL;

        //messbill
        private string FOOD_AUTRTY_CAPTION;
        private string FOOD_AUTRTY_NUMBER;
          
        //general
        private int MENU_STATUS = 0;
        private int FREQNT_COUNT = 0;
        private int RECNT_COUNT = 0;


        public int Org_Id
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
        //Method of storing id of corporate office
        public int Corp_Id
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
        
        //Method of store the userid
        public int User_Id
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

       
        //leave
        public int allowstart
        {
            get
            {
                return LEVSTRTDT_HOLIDAYSTS;
            }
            set
            {
                LEVSTRTDT_HOLIDAYSTS = value;
            }
        }
        public int allowend
        {
            get
            {
                return LEVEND_HOLIDAYSTS;
            }
            set
            {
                LEVEND_HOLIDAYSTS = value;
            }
        }
        public int allowoffday
        {
            get
            {
                return LEVSTRTDT_OFFDUTYSTS;
            }
            set
            {
                LEVSTRTDT_OFFDUTYSTS = value;
            }
        }
        public int blockoffday
        {
            get
            {
                return LEVEND_OFFDUTYSTS;
            }
            set
            {
                LEVEND_OFFDUTYSTS = value;
            }
        }
        public int calculateoffduty
        {
            get
            {
                return OFFDUTYDAYS_STATUS;
            }
            set
            {
                OFFDUTYDAYS_STATUS = value;
            }
        }
        public int leaveeligible
        {
            get
            {
                return ELIGIBLE_LEAVE_STLMNT_LMT;
            }
            set
            {
                ELIGIBLE_LEAVE_STLMNT_LMT = value;
            }
        }
        public int attendancesheet
        {
            get
            {
                return EMPDLYHR_FUTURE_DAYS;
            }
            set
            {
                EMPDLYHR_FUTURE_DAYS = value;
            }
        }
        public int leavesettlementdays
        {
            get
            {
                return GN_LEAVE_SETTLE_DAYS;
            }
            set
            {
                GN_LEAVE_SETTLE_DAYS = value;
            }
        }

       //payroll
        public int basicpay
        {
            get
            {
                return BASIC_PAY;
            }
            set
            {
                BASIC_PAY = value;
            }
        }
        public int payrollround
        {
            get
            {
                return PAYROLL_INDIVIDUAL_ROUND;
            }
            set
            {
                PAYROLL_INDIVIDUAL_ROUND = value;
            }
        }
        public DateTime corpsalary
        {
            get
            {
                return COPRT_SALARY_DATE;
            }
            set
            {
                COPRT_SALARY_DATE = value;
            }
        }
        public DateTime gratuitystart
        {
            get
            {
                return GRATUITY_START_DATE;
            }
            set
            {
                GRATUITY_START_DATE = value;
            }
        }
        public int gratuitydays
        {
            get
            {
                return ELIGIBLE_GRATUITY_DAYS;
            }
            set
            {
                ELIGIBLE_GRATUITY_DAYS = value;
            }
        }
        public int payrollworkday
        {
            get
            {
                return WORKDAY_FIXED_PAYRL_MODE;
            }
            set
            {
                WORKDAY_FIXED_PAYRL_MODE = value;
            }
        }
        public int payrolljoin
        {
            get
            {
                return FIXED_PAYRL_MODE_JOIN;
            }
            set
            {
                FIXED_PAYRL_MODE_JOIN = value;
            }
        }

        //dutyrejoin     
        public int rejoinmode
        {
            get
            {
                return REJOIN_CONFIRMATION_MODE;
            }
            set
            {
                REJOIN_CONFIRMATION_MODE = value;
            }
        }
        public int joininglimit
        {
            get
            {
                return JOINING_DATE_LIMIT;
            }
            set
            {
                JOINING_DATE_LIMIT = value;
            }
        }      

       // employeesection     
        public string employeereferenceformat
        {
            get
            {
                return EMP_REF_FORMAT;
            }
            set
            {
                EMP_REF_FORMAT = value;
            }
        }
        public int employeestatus
        {
            get
            {
                return EMPID_AUTOFILL_STS;
            }
            set
            {
                EMPID_AUTOFILL_STS = value;
            }
        }

        //mail
        public string hrmail
        {
            get
            {
                return HR_EMAIL;
            }
            set
            {
                HR_EMAIL = value;
            }
        }
        public string noreply
        {
            get
            {
                return RPLY_NO_MAIL;
            }
            set
            {
                RPLY_NO_MAIL = value;
            }
        }

        //messbill      
        public string foodcaption
        {
            get
            {
                return FOOD_AUTRTY_CAPTION;
            }
            set
            {
                FOOD_AUTRTY_CAPTION = value;
            }
        }
        public string safetynumber
        {
            get
            {
                return FOOD_AUTRTY_NUMBER;
            }
            set
            {
                FOOD_AUTRTY_NUMBER = value;
            }
        }

        //general
        public int menubar
        {
            get
            {
                return MENU_STATUS;
            }
            set
            {
                MENU_STATUS = value;
            }
        }
        public int frequent
        {
            get
            {
                return FREQNT_COUNT;
            }
            set
            {
                FREQNT_COUNT = value;
            }
        }
        public int recent
        {
            get
            {
                return RECNT_COUNT;
            }
            set
            {
                RECNT_COUNT = value;
            }
        }

        //FAS
        //accountcode
        private int FMS_VIEW_CODE_STS = 0;
        private int FMS_CODE_FORMATE = 0;
        private int FMS_CODE_NUMBER_FORMAT = 0;
        

        //ledger and production duplication
        private int FMS_LDGR_DUPLICATION = 0;
        private int FMS_PRDT_DUPLICATION = 0;
       

        //sales and purchase
        private int FMS_SALE_PRCHS_VISBLE_STATUS = 0;

        //auditing and account closing

        private int AUDIT_DEPNDENT_STATUS = 0;

        private int REFNUM_ACCNTCLS_STS = 0;

        //emp-0043 start
       //currency settings
        private int PRIMARY_CRNC_TYPE=0;
        //end

        //accountcode
        public int codestatus
        {
            get
            {
                return FMS_VIEW_CODE_STS;
            }
            set
            {
                FMS_VIEW_CODE_STS = value;
            }
        }
        public int codeformat
        {
            get
            {
                return FMS_CODE_FORMATE;
            }
            set
            {
                FMS_CODE_FORMATE = value;
            }
        }
        public int codeaddition
        {
            get
            {
                return FMS_CODE_NUMBER_FORMAT;
            }
            set
            {
                FMS_CODE_NUMBER_FORMAT = value;
            }
        }

        //duplication
        public int ledgerdup
        {
            get
            {
                return FMS_LDGR_DUPLICATION;
            }
            set
            {
                FMS_LDGR_DUPLICATION = value;
            }
        }
        public int productdup
        {
            get
            {
                return FMS_PRDT_DUPLICATION;
            }
            set
            {
                FMS_PRDT_DUPLICATION = value;
            }
        }

        //sales and purchase

        public int salesandpurchase
        {
            get
            {
                return FMS_SALE_PRCHS_VISBLE_STATUS;
            }
            set
            {
                FMS_SALE_PRCHS_VISBLE_STATUS = value;
            }
        }
        public int auditing
        {
            get
            {
                return AUDIT_DEPNDENT_STATUS;
            }
            set
            {
                AUDIT_DEPNDENT_STATUS = value;
            }
        }
        public int accountclosing
        {
            get
            {
                return REFNUM_ACCNTCLS_STS;
            }
            set
            {
                REFNUM_ACCNTCLS_STS = value;
            }
        }
        //emp-0043 start
        //Currency settings
        public int primarycurrency
        {
            get
            {
                return PRIMARY_CRNC_TYPE;
            }
            set
            {
                PRIMARY_CRNC_TYPE = value;
            }
        }
        //general
        //taxation 

        private string TAXATION_SYSTEM ;
        private int GN_TAX_ENABLED = 0;
        private int TAX_PERC_DECIMAL = 0;

        //COLOR ATTRIBUTES


        private string GN_APP_HEADER_COLOR ;
        private string GN_APP_FOOTER_COLOR;
        private string GN_SALES_HEADER_COLOR ;
        private string GN_SALES_FOOTER_COLOR ;



        private int LISTING_MODE = 0;
        private int LISTING_MODE_SIZE = 0;
        private int ITEM_LISTING_MODE = 0;

        public string taxsystem
        {
            get
            {
                return TAXATION_SYSTEM;
            }
            set
            {
                TAXATION_SYSTEM = value;
            }
        }
        public int taxenabled
        {
            get
            {
                return GN_TAX_ENABLED;
            }
            set
            {
                GN_TAX_ENABLED = value;
            }
        }
        public int taxdecimal
        {
            get
            {
                return TAX_PERC_DECIMAL;
            }
            set
            {
                TAX_PERC_DECIMAL = value;
            }
        }
        //colour
        public string appheader
        {
            get
            {
                return GN_APP_HEADER_COLOR;
            }
            set
            {
                GN_APP_HEADER_COLOR = value;
            }
        }
        public string appfooter
        {
            get
            {
                return GN_APP_FOOTER_COLOR;
            }
            set
            {
                GN_APP_FOOTER_COLOR = value;
            }
        }
        public string salesheader
        {
            get
            {
                return GN_SALES_HEADER_COLOR;
            }
            set
            {
                GN_SALES_HEADER_COLOR = value;
            }
        }
        public string salesfooter
        {
            get
            {
                return GN_SALES_FOOTER_COLOR;
            }
            set
            {
                GN_SALES_FOOTER_COLOR = value;
            }
        }

        //listing
        public int listingmode
        {
            get
            {
                return LISTING_MODE;
            }
            set
            {
                LISTING_MODE = value;
            }
        }
        public int listingsize
        {
            get
            {
                return LISTING_MODE_SIZE;
            }
            set
            {
                LISTING_MODE_SIZE = value;
            }
        }
        public int itemlistingmode
        {
            get
            {
                return ITEM_LISTING_MODE;
            }
            set
            {
                ITEM_LISTING_MODE = value;
            }
        }


        private int CNCL_REASN_MUST = 0;
        //private string CMN_IMAGE_PATH;
        private int CMDTY_MANTN_OFFCE = 0;


        public int cancelreason
        {
            get
            {
                return CNCL_REASN_MUST;
            }
            set
            {
                CNCL_REASN_MUST = value;
            }
        }
        //public string imagepath
        //{
        //    get
        //    {
        //        return CMN_IMAGE_PATH;
        //    }
        //    set
        //    {
        //        CMN_IMAGE_PATH = value;
        //    }
        //}
        public int commoditystatus
        {
            get
            {
                return CMDTY_MANTN_OFFCE;
            }
            set
            {
                CMDTY_MANTN_OFFCE = value;
            }
        }

    }
    //END
    //EVM040
}
