using System;
using System.Collections.Generic;
using System.Linq;
using EL_Compzit;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Web;
using BL_Compzit;



namespace CL_Compzit
{
    public class clsCommonLibrary
    {

        //Enumeration for storing master id for each section.
        public enum QUOTATION_TEMPLATE
        {
            Standard = 1,
            Project = 2,
            Tender = 3

        }
        //enumeration of  account group id
        public enum ACNT_GRP_ID
        {
            PRIMARY = 1
        }

        //enumeration of  primary grps
        public enum PRIMARYGRP
        {
            BANK = 1,
            CASHINHND = 2,
            SUNDRYCREDITR = 3,
            SUNDRYDEBTR = 4,
        }

        //enumeration of  account setting id
        public enum ASMOD_ID
        {
            bank = 1,
            customer = 2,
            supplier = 3,
            purchase = 4,
            sales = 5,
            profitloss = 6,
            paymntclearance = 7,
            receiptclearance = 8,
        }

        //enumeration of  boucher type
        public enum VOUCHER_TYPE
        {
            RECEIPT = 0,
            PAYMENT = 1,
            JOURNAL = 2,
            CREDITNOTE = 3,
            DEBITNOTE = 4,
            SALE = 5,
            PURCHASE = 6,
            PDC_PAYMENT = 7,
            PDC_RECEIPT = 8,
        }

        //Method for setting id for each status
        public enum Status
        {
            Status_New = 1,
            Status_ApprovalPending = 2,
            Status_Rejected = 3,
            Status_Approved = 4
        }
        //Method for setting id for each status
        public enum LeadStatus
        {
            New = 1,
            Open = 2,
            Quotation_Prepared = 3,
            Quotation_Approval_Pending = 4,
            Quotation_Returned = 5,
            Quotation_Approved = 6,
            Quotation_ReOpened = 7,
            Quotation_Delivered = 8,
            Success = 9,
            Loss = 10,
            Under_Negotiation = 11,
            Project_On_Hold = 12,
            Project_Canceled = 13,
            Technical_Submission = 14,
            Under_Review = 15,
            Partial_Win = 16
        }
        //storing id for each section for ref number fetchiNg
        public enum Section
        {
            USER_MASTER = 1,
            CORP_DIVISION = 2,
            WORK_STATION = 3,
            CUSTOMER = 4,
            PRODUCT_MASTER = 5,
            PRODUCT_CODE = 6,
            TEAM_HIERARCHY = 7,
            LEAD = 8,
            QUOTATION = 9,
            MAIL_BOX = 10,
            LEAD_MAIL = 11,
            PROJECT = 12,
            VEHICLE_CLASS = 13,
            LICENSE_TYPE = 14,
            FUEL_TYPE = 15,
            VEHICLE_MASTER = 16,
            WATER_RECHARGE = 17,
            INSURANCE_PROVIDER = 18,
            INSURANCE_RENEWAL = 19,
            PERMIT_RENEWAL = 20,
            VEHICLE_ASSIGN = 21,
            WATER_BILLING = 22,
            LEAVE_ALLOCATION = 23,
            JOBSCHDL = 24,
            TRAFFIC_VIOLATION = 25,
            CONTRACT = 26,
            REQUEST_FOR_GUARANTEE = 27,
            Bank_Guarantee = 28,
            Guarantee_Attchment = 29,
            NOTIFICATION_TEMPLATE = 30,
            NOTIFICATION_TEMPLATE_DETAIL = 31,
            ORGANIZATION_UPDATE = 32,
            BANK_GRNTY_TEMPLT_DTL = 33,
            CORPORATE_DEPARTMENTS = 34,
            CORPORATE_PARTNER = 35,
            DUTYOFF = 36,
            MONTHLY_DUTYOFF = 37,
            PAY_GRADE = 38,
            PERSONAL_DETAILS = 39,
            EMPLOYEE_SALARY = 40,
            EMPLOYEEJOB = 41,
            DUTY_ROSTER = 42,
            DUTY_ROSTER_SUBMISSION = 43,
            MANPOWER_RECRUITMENT = 44,
            INTERVIEW_CATEGORY = 45,
            REQUIREMENT_ALLOCATION = 46,
            INTERVIEW_TEMPLATE = 47,
            JOB_NOTIFICATION = 48,
            CANDIDATE_SHORTLIST = 49,
            INTERVIEW_PROCESS_MASTER = 50,
            INTERVIEW_SCHEDULE_LEVEL = 51,
            CANDIDATE_SELECTION = 52,
            INTERVIEW_PANEL = 53,
            CANDIDATE_SELECTION_FILES = 54,
            VISA_QUOTA = 55,
            ONBOARDING_PROCESS = 56,
            ONBOARDING_PROCESS_DETAIL = 57,
            CANDIDATE_LOGIN = 58,
            CERTIFICATE_BUNDEL = 59,
            JOINING_WORKER = 60,
            CERTIFICATE_VERIFICATION = 61,
            IMMIGRATION_ROUND = 62,
            IMMIGRATION_ASGNMNT = 63,
            IMMIGRATION_ASGNMNT_DTL = 64,
            HCM_STAFF_OTHER_DETAILS = 65,
            HCM_LEAVE_TYPE_MASTER = 66,
            CLEARANCE_FORM_WORKER = 67,
            LEAVE_REQUEST = 68,
            LEAVE_FACILITY_ASSEMENT = 69,
            CLEARANCE_FORM_STAFF = 70,
            HCM_ACCOMMODATION_CATEGORY = 71,
            EXIT_PROCEDURE = 72,
            EXIT_INTERVIEW_PROCESS = 73,
            ACCOMODATION = 74,
            QUOTATION_MAIL_ATTCH_BKP = 75,
            CUSTOMER_REFNUM = 76,
            OVERTIME_CATEGORY = 79,
            EMPLOYEE_DEDUCTION_MASTER = 80,
            EMPLOYEE_DAILY_HOUR = 78,
            QTN_PRDCT_GROUP = 81,
            MONTHLY_WPS_LIST = 82,
            EMPLOYEE_TRANSFER = 83,
            MESS_BILL = 85,
            EMP_CNDCT_INCDNT = 86,
            EMP_WELFARE_SERVICE = 87,
            CONDUCT_INCIDENT_PDF = 88,
            EMP_WELFARE_SERVICE_TRANS = 88,
            CONDUCT_INCIDENT = 90,
            CONDUCT_INCIDENT_REF = 91,
            SALARY_CERTIFICATE = 92,
            EXPERIENCE_CERT_PDF = 93,
            PERFOMANCE_TEMPLATE_REF = 94,
            PERFORMANCE_ISSUE = 95,
            PERFOMANCE_TEMPLATE = 96,
            PERFOMANCE_TEMPLATE_GRP = 97,
            PERFOMANCE_EVALUATION = 98,
            PERFOMANCE_EVALUATION_GRP = 99,
            PERFORMANCE_ISSUE_REFNO = 100,
            PERFOMANCE_TEMPLATE_BKUP = 101,
            PERFOMANCE_TEMPLATE_GRP_BKUP = 102,
            EXPIREDCSV = 104,
            SUPPLIEDCSV = 105,
            GUARATETYPE_CSV = 106,
            EXPIRYRANGE_CSV = 107,
            CLIENTGRANTEE_CSV = 108,
            PRJTGRNTE_CSV = 109,
            EMPLOYEE_DETAILS_CSV = 110,
            EMPLOYEE_RECRUITMENT_CSV = 111,
            VISA_BUNDLE_CSV = 112,
            MNPWR_REQRMNT_STS_CSV = 113,
            EXPIRY_NOTIFICATION_CSV = 114,
            MESS_CALCULTN_RPRT_CSV = 115,
            EMP_DEDUCTN_RPRT_CSV = 116,
            PAYROLL_PRSS_REPORT_CSV = 117,
            ATTENTANCE_RPRT_CSV = 118,
            LEAVE_APLICTN_RPRT_CSV = 119,
            JOB_COST_SUMMARY_CSV = 120,
            ON_BOARDING_STS_CSV = 121,
            ACCOMMODATION_REPORT_CSV = 122,
            INTERVIEW_SUMMARY_CSV = 123,
            IMMIGRATION_TASK_REPRT_CSV = 124,
            MNPWR_JOB_ASIGNMNT_RPRT_CSV = 125,
            VISA_QUOTA_STATUS_RPRT_CSV = 126,
            INTERVIEW_EVLVTN_RPRT_CSV = 127,
            MNPWR_PROCESS_DTL_RPRT_CSV = 128,
            JOB_OFFER_STATUS_RPRT_CSV = 129,
            ONBOARDING_JOB_ASGNMNT_RPRT_CSV = 130,
            LEAVE_MNGMNT_RPRT_CSV = 131,
            FMS_PURCHASE_MASTER = 138,
            SALES = 139,
            JOURNAL = 140,
            FMS_PAYMENT = 141,

            INSURANCE_EXPIRED_CSV = 136,
            INSURANCE_PROJECT_WISE_CSV = 137,
            INSURANCE_EXPRY_RANGE = 135,
            INSURANCE_MSTR = 132,
            INSURANCE_TEMPLATE = 133,
            INSURANCE_ATTACHMNT = 134,
            BANKGUARANTEE_CSV = 145,
            RECEIPT = 142,
            RECEIPT_LEDGER = 143,
            PAYMENT_LEDGER = 144,
            BUDGET = 146,
            INSURANCE_TYPE_CSV = 147,
            TRAFIC_VIOLATION = 148,
            CHEQUE_TEMPLATE = 149,
            CREDIT_NOTE = 150,
            DEBIT_NOTE = 151,
            ACCOUNT_GROUP = 152,
            PURCHASE_PRINT = 153,
            SALES_PRINT = 154,
            PAYMENT_PRINT = 155,
            RECEIPT_PRINT = 156,
            CREDITNOTE_PRINT = 157,
            DEBITNOTE_PRINT = 158,
            JOURNAL_PRINT = 159,

            CORP_OFFICE_IMAGE = 161,
            FMS_LEDGER_MASTER = 160,
            Cost_Group = 162,
            COST_CENTER = 163,
            PURCHASE_ATTACHMENT = 165,
            SALES_ATTACHMENT = 164,
            FMS_POSTDATED_CHEQUE = 166,
            END_OF_SERVICE = 167,
            APPROV_HIERARCHY_TEMPLATE = 168,
            LEAVE_SETTLEMENT = 170,
            MANUAL_ADD_DED_LIST_ATTACHMENT = 173,
            MANUAL_ADD_DED_ATTACHMENT = 174,
            MONTHLY_ATTENDACE_SHEET = 175,
            EXPORT_EMPLOYEE_DETAILS_CSV = 176,
            CUSTOMER_OUTSTANDING_PDF = 177,
            SUPPLIER_OUTSTANDING_PDF = 178,
            PROFIT_LOSS_PDF = 179,
            BALANCESHEET_PDF = 180,
            COST_CENTRE_PERFOMANCE_PDF = 181,
            COST_GROUP_PERFOMANCE_PDF = 182,
            POSTDATED_CHEQUE_PDF = 184,
            TRIAL_BALANCE_PDF = 183,
            POSTDATED_CHEQUE_CSV = 185,
            CUSTOMER_OUTSTANDING_AGING_PDF = 186,
            SUPPLIER_OUTSTANDING_AGING_PDF = 187,
            SALES_PDF = 188,
            PURCHASE_PDF = 189,
            PAYMENT_PDF = 190,
            RECEIPT_PDF = 191,
            JOURNAL_PDF = 192,
            CREDITNOTE_PDF = 193,
            DEBITNOTE_PDF = 194,
            COST_CENTRE_PERFOMANCE_CSV = 195,
            REPORT_BUILDER_PDF = 196,
            CUSTOMER_OUTSTNDG_AGEING_CSV = 197,
            SUPPLIER_OUTSTNDG_AGEING_CSV = 198,
            COST_GROUP_PERFOMANCE_CSV = 199,
            PURCHASE_CSV = 200,
            SALE_CSV = 201,
            PAYMENTLIST_CSV = 202,
            RECIPTLIST_CSV = 203,
            DEBITNOTELIST_CSV = 204,
            CREDITNOTELIST_CSV = 205,
            JOURNALLIST_CSV = 206,
            PROFITLOSS_CSV = 207,
            BALANCESHEET_CSV = 208,
            TRIALBALANCE_CSV = 209,
            SUPPLIER_OUTSTANDING_CSV = 210,
            CUSTOMER_OUTSTANDING_CSV = 211,
            REPORT_BUILDER_CSV = 212,
            LEDGER_STATEMENT_PDF = 213,
            LEDGER_STATEMENT_CSV = 214,
            MONTHLY_SALARY_STATEMENT = 215,
            MONTHLY_ATTENDACE_SHEET_AMNT = 216,
            EMPLOYEE_DAILY_HOUR_AMNT = 217,
            POSTDATED_CHEQUE_FILE = 218,
            ACCOUNT_GROUP_START_REF = 219,
            ACCOUNT_SUB_GROUP_START_REF = 220,
            LEDGER_START_REF = 221,
            SUB_LEDGER_START_REf = 222,
            COST_GROUP_START_REF = 223,
            COST_CENTER_START_REf = 224,
            LEAVE_APPLICATION_REPORT_PDF = 225,
            PURCHASE_ORDER_MASTER = 226,
            PURCHASE_ORDER_ATTCHMNT = 227,
            EXPENSE = 228,
            EMP_ADD_DED_REPORT_PDF = 229,
            BANK_LIST_PDF = 231,
            BUSINESS_UNIT_LIST_PDF = 232,
            PURCHASE_ORDER_NOTE_ATTACH = 230,
            COUNTRY_LIST_PDF = 233,
            STATE_LIST_PDF = 234,
            CITY_LIST_PDF = 235,
            WORKSTATION_LIST_PDF = 236,
            DEPARTMENT_LIST_PDF = 237,
            DIVISION_LIST_PDF = 238,
            PASSWORD_LIST_PDF = 239,
            COMPLAINT_LIST_PDF = 240,
            FUELTYPE_LIST_PDF = 241,
            JOB_LIST_PDF = 242,
            INSURANCE_LIST_PDF = 243,
            PREMISE_LIST_PDF = 244,
            PREMISE_AREA_LIST_PDF = 245,
            TIMESLOT_LIST_PDF = 246,
            PARTNER_LIST_PDF = 247,
            APPROVAL_CONSOLE_NOTE_ATTACH = 248,
            APPROVAL_CONSOLE_ADDTNL_ATTACH = 250,
            PRODUCT_BRAND_LIST_PDF = 251,
            UNIT_MEASURE_LIST_PDF = 252,
            TAX_LIST_PDF = 253,
            VENDOR_CATEGORY = 249,
            CHARGE_HEAD = 263,
            WAREHOUSE_MASTER = 257,
            CUSTOMER_GROUP_LIST_PDF = 254,
            PRODUCT_GROUP_LIST_PDF = 256,
            TERMS_TEMPLATE_LIST_PDF = 264,
            OPPORTUNITY_RATE_LIST_PDF = 265,
            APPROVAL_HIERARCHY = 258,
            DOCUMENT_WORKFLOW = 259,
            VENDORCATEGORY_CSV = 260,
            WAREHOUSE_CSV = 261,
            CHARGEHEAD_CSV = 262,
            APPROVAL_HIERARCHY_CSV = 266,
            DOCUMENT_WORKFLOW_CSV = 267,
            MAIL_SETTINGS_LIST_PDF = 268,
            ACTIVE_OPPORTUNITY_RPT_PDF = 270,
            OPPORTUNITY_SUMMARY_RPT_PDF = 271,
            QUOTATION_SUMMARY_RPT_PDF = 272,
            APPROVAL_SET = 269,
            APPROVAL_ASSIGNMENT = 273,
            APPROVLA_SET_CSV = 274,
            APPROVAL_ASSIGNMENT_CSV = 275,
            PURCHASE_ORDER_PDF = 276,
            PURCHASE_ORDER_CSV = 277,
            APPROVAL_CONSOLE_PDF = 278,
            APPROVAL_CONSOLE_CSV = 279,
            TEAM_HIERACHY_PDF = 280,
            OPEN_DM_REPORT_PDF = 281,
            BOOKING_DM_REPORT_PDF = 282,
            PRODUCT_MASTER_PDF = 283,
            PRODUCT_CATEGORY_PDF = 284,
            BOOKING_SE_REPORT_PDF = 285,
            SALES_EXECUTIVE_PDF = 286,
            PROJECT_MASTER_LIST_PDF = 287,
            ITEM_LIST_PDF = 288,
            CUSTOMER_MASTER_PDF = 289,
            DEAL_CLOSURE_SE_RPT_PDF = 291,
            DEAL_CLOSURE_DM_RPT_PDF = 292,
            ACCOMMODATION_TYPE_PDF = 290,
            LICENSE_TYPE_PDF = 293,
            EMPLOYEE_ROLE_ALLOCATION_PDF = 294,
            PAYROLL_LIST_PDF=295,
            DESIGNATION_MASTER_PDF = 296,
            JOB_ROLE_PDF = 297,
            OPPORTUNITY_LIST_PDF = 299,
            TASKS_LIST_PDF=300

        }

        //Account group nature Property
        public enum Acnt_Nature
        {
            Asset = 1,
            Liability = 2,
            Expense = 3,
            Income = 4
        }


        //Method of store status
        public enum StatusAll
        {
            Active = 1,
            InActive = 0
        }
        //enumeration of store Oncloud Property
        public enum Cloud
        {
            OnCloud = 1,
            NotCloud = 2
        }
        //Method for storing master id for each section.
        public enum MasterId
        {
            Parking_Org = 101,
            Designation = 103,
            UserId = 104,
            Corporate_Office = 102,
            Supplier = 105,
            Customer = 106,
            Corporate_Division = 107,
            Job_Role = 108,
            Employee_Role = 109
        }
        //Enumeration for storing master id for each section.
        public enum DASHBOARD_DECIMAL_COUNT
        {
            Lead = 2

        }
        //Method for storing template type of corporate
        public enum CORP_TMPLT_TYP
        {
            Quotation = 1

        }
        //Method for storing FORMAT type of corporate
        public enum CORP_QTN_FORMAT
        {
            Standard_Format = 1,
            Advanced_Format = 2,
            Advanced_Format_Corpoate = 3,
            Advncd_Frmt_Corp_Terms_To_Last = 4
        }
        //Method for storing COLUMNS of GN_CORP_GLOBAL.
        public enum CORP_GLOBAL
        {

            CORPRT_ID = 1,
            GN_TAX_ENABLED = 2,
            TAX_PERC_DECIMAL = 3,
            GN_MNEY_DECIMAL_CNT = 4,
            GN_UNIT_DECIMAL_CNT = 5,
            GN_ITM_CD_GENERATE = 6,
            GN_ITM_QUK_CD_PRFX = 7,
            SL_SLRET_JOIN_ALLOW = 8,
            DEFLT_CURNCY_MST_ID = 9,
            DEFLT_ITMTYPE_ID = 10,
            CMN_PERCENT_DECIMAL = 11,
            OPSTK_BLOCK_STATUS = 12,
            OPSTK_RESTRICT_CTGRY = 13,
            USRCLS_PRCDRE = 14,
            USRCLS_RQAMT_VISIBLE = 15,
            SLS_ACCES_SRCH_TYP = 16,
            SLRTN_ACCES_SRCH_TYP = 17,
            PRCH_ACESS_SRCH_TYP = 18,
            PRCHRTN_ACESS_SRCH_TYP = 19,
            OPSTK_ACESS_SRCH_TYP = 20,
            PRDTN_ACESS_SRCH_TYP = 21,
            STKISU_ACESS_SRCH_TYP = 22,
            SLS_BLAMT_DFLT_CRNC = 23,
            ACTIVE_FINCYR_ID = 24,
            STKTFR_ACESS_SRCH_TYP = 25,
            SLS_PRINT_GREETINGS = 26,
            SLS_NEED_YOU_SAVED = 27,
            SLS_AUTO_CUT_STATUS = 28,
            SLS_PRINT_CAPTION = 29,
            FOOD_AUTRTY_CAPTION = 30,
            FOOD_AUTRTY_NUMBER = 31,
            BARCODE_OPEN_ITMST = 32,
            SLSRTN_REASN_REQRD = 33,
            TRNS_NMBR_REQRD = 34,
            MIN_SEEK_LENGTH = 35,
            CNCL_REASN_MUST = 36,
            CMN_IMAGE_PATH = 37,
            SLSPRNT_DECLARATION = 38,
            LISTING_MODE = 39,
            LISTING_MODE_SIZE = 40,
            LEAD_FOLLOWUP_EDIT = 41,
            ITEM_LISTING_MODE = 42,
            CMDTY_MANTN_OFFCE = 43,
            RPLY_NO_MAIL = 44,
            DFLT_QTNFRMT_ID = 45,
            GN_APP_HEADER_COLOR = 46,
            GN_APP_FOOTER_COLOR = 47,
            GN_SALES_HEADER_COLOR = 48,
            GN_SALES_FOOTER_COLOR = 49,
            GN_MAIL_SRVC_REFRSH_TIME = 50,
            DFLT_CURNCY_DISPLAY = 51,
            QTN_STNDRD_ALLOW_ITM_DUP = 52,
            VHCL_RNWL_ALRT_MOD = 53,
            VHCL_RNWL_ALRT_VAL = 54,
            GN_INVENTORY_FOREX_STATUS = 55,
            GN_LEAVE_SETTLE_DAYS = 56,
            REFNUM_ACCNTCLS_STS = 57,
            JOINING_DATE_LIMIT = 59,
            ELIGIBLE_LEAVE_STLMNT_LMT = 60,
            AUDIT_DEPNDENT_STATUS = 61,
            GRATUITY_START_DATE = 62,
            FMS_VIEW_CODE_STS = 76,
            FMS_CODE_FORMATE = 77,
            FMS_SALE_PRCHS_VISBLE_STATUS = 78,
            FMS_LDGR_DUPLICATION = 79,
            GN_REMOVE_RESTRCTNS_STS = 80,
            FMS_PRDT_DUPLICATION = 81,
            EMPDLYHR_FUTURE_DAYS = 82,
            PAYROLL_INDIVIDUAL_ROUND = 83,
            MENU_STATUS = 84,
            FREQNT_COUNT = 85,
            RECNT_COUNT = 86,
            FMS_CODE_NUMBER_FORMAT = 87,
            OFFDUTYDAYS_STATUS = 88,
            REJOIN_CONFIRMATION_MODE = 89,
            FIXED_PAYRL_MODE_JOIN = 90,
            WORKDAY_FIXED_PAYRL_MODE = 91,
            LEVSTRTDT_OFFDUTYSTS = 92,//EVM 0041
            LEVSTRTDT_HOLIDAYSTS = 93,
            LEVEND_OFFDUTYSTS = 94,
            LEVEND_HOLIDAYSTS = 95,//EVM 0041
            DELETE_PDF_DAYS = 96,//EVM 040
            BASIC_PAY = 97,
            COPRT_SALARY_DATE = 98,
            ELIGIBLE_GRATUITY_DAYS = 99,
            EMP_REF_FORMAT = 100,
            EMPID_AUTOFILL_STS = 101,
            HR_EMAIL = 102,
            TAXATION_SYSTEM = 103,//EVM040
            USRID_GNRT_TYPE = 104,
            PMS_CONTROLS_DISPLAY_STS = 105,
            FMS_DYNAMIC_CNTRL_STS = 106,//0041
            FMS_EXPBOOK_DISPLAY_STS = 107,
        }

        //Method for storing COLUMNS of GN_CORP_SUB_GLOBAL.
        public enum CORP_SUB_GLOBAL
        {

            CORPRT_ID = 1,
            LD_PRJCT_SELECTN_MUST = 2,
            LD_EMAIL_MUST = 3,
            AUTOMTC_MOBL_CODE = 4

        }
        //Method for storing COLUMNS of APP_COMPANY .
        public enum APP_COMPANY
        {

            CMPNY_NAME = 1,
            CMPNY_ADDR1 = 2,
            CMPNY_ADDR2 = 3,
            CMPNY_ADDR3 = 4,
            CMPNY_CITY = 5,
            CMPNY_STATE = 6,
            CMPNY_COUNTRY = 7,
            CMPNY_PIN = 8,
            CMPNY_WEB = 9,
            CMPNY_EMAIL = 10,
            CMPNY_PHONE = 11,
            CMPNY_MOBILE = 12,
            CMPNY_FAX = 13,
            CMPNY_SMTP_HOST = 14,
            CMPNY_SMTP_PORT = 15,
            CMPNY_EMAIL_SENDMAIL = 16,
            CMPNY_PWD_SENDMAIL = 17,
            CMPNY_RPLYTO_SENDMAIL = 18,
            CMPNY_ML_ATTCH_PATH = 19,
            CMPNY_APRVAL_SENDMAIL = 20,
            CHNL_PARTNR_NAME = 21,
            CHNL_PARTNR_WEB = 22
        }

        //method of storing transaction is recipt or payement type
        public enum Tax_Enable
        {
            Enabled = 1,
            Disabled = 0
        }

        //Method for primary and not primary Designation.
        public enum DesignationType
        {
            Primary = 1,
            NonPrimary = 0,
            App_Administrator = 1,
            OrganisationMosAdministrator = 2,
            CorporateMOSAdministrator = 3,
            DepartmentUser = 4,
            DepartmentHead = 5,
            DepartmentManager = 6,
            DepartmentGroupManager = 7,
            OtherUser = 8
        }
        //Method for setting id for CategoryType
        public enum CategoryType
        {
            MainCategory = 1,
            SubCategory = 2,
            SmallCategory = 3,
            LeastCategory = 4
        }
        //Method for  Designation Id.
        public enum DesignationId
        {
            AppAdmin = 1,
            OrgAdmin = 2,
            CrprtAdmin = 3
        }

        //Storing diff. ttype payment modes
        public enum Payment_Modes
        {
            Cash = 1,
            EFT = 2,
            DD = 3,
            Cheque = 4,
            DEFT = 5
        }

        // enumeration for HashTypes
        public enum HashType
        {
            MD5 = 1,
            SHA1 = 2,
            SHA256 = 3,
            SHA512 = 4
        }

        //enumeration for printing formats
        public enum Printitng_Format
        {
            Normal_Simple = 1,
            Normal_Wide = 2,
            Form8_Simple = 3,
            Form8_Wide = 4,
            TSC_Single = 5,
            TSC_Double = 6,
            Simple_User_Close = 7,
            Simple_Laser_Printer = 8,
            TSC_7040_New = 9
        }

        //Enumeration for child roles
        public enum ChildRole
        {

            Add = 1,
            Modify = 2,
            Find = 3,
            Cancel = 4,
            Rate_Updation = 5,
            Confirm = 6,
            Approve = 7,
            Re_Open = 8,
            Return = 9,
            Win = 10,
            Loss = 11,
            Allocate = 12,
            All_Mails = 13,
            Mail_Allocate = 14,
            Mail_Forward = 15,
            Mail_Attach = 16,
            Close = 17,
            Suplier_Guarantee_Permission = 18,
            Client_Guarantee_Permission = 19,
            Renew = 20,
            Reissue = 21,
            HR_Allocation = 22,
            Self_Allocation = 23,
            Edit_Allocation = 24,
            GM_Allocation = 25,
            OnHold = 26,
            ALL_BUSINESS_UNIT = 27,
            ALL_DIVISION = 28,
            FMS_ACCOUNT = 29,
            BUSINESS_SPECIFIC = 30,
            ACCOUNT_SPECIFIC = 31,
            DISCOUNT = 32,
            FMS_AUDIT = 33,
            FINANCL_YR_EDIT = 34,
            Administrator_Privileges = 35,
            Recurring = 36,
            Cheque_Print = 37,
        }
        //Enumeration for uSER ROLE MASTER ID
        public enum USR_ROLE_MSTR
        {
            Corporate_Pack = 1,
            Licence_Pack = 2,
            Country_Master = 3,
            State_Master = 4,
            City_Master = 5,
            Organisation_Type = 6,
            OrganisationVerification = 9,
            DesignationMaster = 10,
            Corporate_Department = 11,
            Corporate_Office = 12,
            Premise = 13,
            User_Registration = 14,
            WorkArea = 15,
            WorkStationMastr = 16,
            Corporate_Division = 22,
            Team_Hierarchy = 24,
            Customer_Master = 25,
            Product_Category = 23,
            Tax_Master = 27,
            UOM_Master = 28,
            Product_Master = 29,
            Product_Group = 30,
            Product_Brand = 31,
            Customer_Group = 32,
            Quotation = 34,
            New_Lead = 35,
            Mail_Settings = 40,
            Mail_Box = 41,
            Project = 46,
            Terms_Template = 47,
            LeadRate_Master = 49,
            Insurance_Provider = 54,
            Accomodation_Master = 51,
            Vehicle_Class = 53,
            License_Type = 55,
            Vehicle_Master = 56,
            Login_Details = 57,
            Auto_Workshop = 58,
            Insurance_Permit_Renewal = 59,
            Water_Card_Master = 60,
            Recall_Cancelled = 61,
            Bank_Master = 62,
            Water_Card_Recharge = 63,
            Job_master = 64,
            Complaint_Master = 65,
            Fuel_Type = 69,
            Vehicle_Status_Management = 70,
            Vehicle_Status_Master = 71,
            Water_Billing = 72,
            Timeslot_Master = 73,
            Holiday_Master = 74,
            Accommodation_Type_Master = 75,
            Leave_Type = 76,
            Job_Schedule = 77,
            Leave_Allocation_Master = 78,
            Job_Category_Master = 79,
            Traffic_Violation = 81,
            Contract_Category_Master = 82,
            Guarantee_Type_Master = 83,
            Contract_Master = 84,
            Request_For_Guarantee = 85,
            Notification_Template = 86,
            Bank_Guarantee = 87,
            Insurance_Coverage_Type = 88,
            Partner = 90,
            DutyRoster = 91,
            Job_role = 92,
            Expired_Guarantee = 94,
            Employee_Role_Allocation = 95,
            Project_Wise_Bank_Guarantee = 100,
            Traffic_Violation_Settlement = 101,
            Employee_Master = 107,
            Employee_Sponsor_Master = 108,
            Payroll_Structure = 109,
            Visa_type = 110,
            Pay_Grades = 111,

            Division_Manager_Dashboard = 114,
            Job_Description = 115,
            Consultancy_Master = 116,
            Mapower_Requirement = 117,
            Requirement_Allocation = 118,
            Interview_Category = 119,
            Job_Notification = 120,
            Interview_Process = 121,
            CANDIDATE_SHORTLIST = 122,
            Interview_Template = 123,
            Joining_Intimation = 124,
            InterviewPanel = 125,
            Candidate_Selection = 126,
            Visa_Quota = 128,
            Onboaring_Partial_Process = 133,
            OnBoarding_Process = 134,
            Certificate_Bundle_Template = 136,
            Joining_Staff = 138,
            Joining_Worker = 139,
            Candidate_LogIn = 142,
            Certificate_Validation = 143,
            Immigration_Tasks = 144,
            Immigration_Round = 145,
            Immigration_Assignment = 146,
            Leave_Request = 156,
            Clearance_Form_Worker = 157,
            Leave_Facility_Assignment = 158,
            HCM_STAFF_LEAVE_APROVAL = 159,
            Leave_Type_Master = 160,
            Leave_Partial_Process = 161,
            Clearance_Approval_Form = 163,
            Exit_Interview_questions = 165,
            Resignation_Approval = 166,
            Resignation_Form = 167,
            Employee_Exit_Process = 168,
            Exit_Procedure = 169,
            Accommodatiion_Category_Master = 170,
            Exit_Partial_Process = 175,
            Notice_Period = 176,
            Passport_Hand_Over_Status = 178,
            Mess_Exemption = 179,
            Mess_Bill_Calculation = 180,
            Daily_Attendance_Sheet = 182,
            End_Of_Service_Leave_Settlement = 183,

            EMPLOYEE_DEDUCTION_MASTER = 185,
            Duty_Rejoin = 187,
            Leave_Settlement = 184,
            Monthly_Salary_Process = 186,
            Overtime_Category = 188,
            Payment_closing = 189,
            Employee_Transfer = 191,
            Memo_Reason = 194,
            Emp_Conduct_Incident = 195,
            Emp_Welfare_Service = 196,
            Emp_Welfare_Service_Master = 197,
            Emp_Welfare_Service_Master_Trans = 198,
            Emp_Conduct = 199,
            Salary_Certificate = 200,
            AppointmentLetterParameter = 210,
            Visa_Quota_Status_Report = 211,
            Mnpwr_Job_Assignemt_Report = 204,
            Issue_performance_form = 223,
            Perfomance_Tmplt = 224,
            Perfomance_Evalvtn = 225,
            FMS_ACCOUNT_GROUP = 228,
            Ledger = 229,
            TAX_DEDCTD_ATSRCE = 231,
            TaxCollectedAtSource = 234,
            Supplier = 236,
            PurchaseMaster = 237,
            SALES = 238,
            Journal = 239,
            Cost_Group = 240,
            Cost_Center = 241,
            Insurance_Expired = 230,
            Project_Wise_Insurance_Report = 235,
            Insurance_Master = 226,
            PAYMENT_ACCOUNT = 242,
            Budget = 243,
            Receipt = 244,
            Insurance_Type_Master = 259,
            Cheque_Template = 265,
            Credit_Note = 269,
            Debit_Note = 270,
            Account_Setting = 268,
            FMS_POSTDATED_CHEQUE = 295,
            PMS_Vendor_Category = 298,
            PMS_Warehouse = 300,
            PMS_Charge_Head = 299,
            Approval_Hierarchy_Template = 297,
            MANUAL_ADD_DED_ENTRY = 304,
            Document_Workflow = 302,
            Approval_Set = 301,
            Approval_Assignment = 310,
            Purchase_Order_Master = 303,
            ApprovalConsole = 313,
        }
        //Method for storing COLUMNS of GN_CORP_GLOBAL.
        public enum IMAGE_SECTION
        {


            USER_PROFILEPIC = 1,
            DIVISION_ICON = 2,
            Rate_Amendment = 3,
            QUOTATION_ATTACHMENT = 4,
            LEAD_ATTACHMENT = 5,
            Mail_Attachments = 6,
            Lead_Mail_Attachment = 7,
            QUOTATION_PDF = 8,
            CORPORATE_LOGOS = 9,
            QUOTATION_IMPORT = 10,
            CURRENCY_SYMBOL = 11,
            APP_ICON_IMAGES = 12,
            VEHICLE_MASTER = 13,
            USER_LICENSECOPY = 14,
            WATER_RECHARGE = 15,
            REQUEST_FOR_GUARANTEE = 16,
            Guarantee_Attchment = 17,
            Bussiness_Unit = 18,
            ORGANIZATION = 19,
            EMPLOYEE_IMMIGRATION = 20,
            QUALIFICATION = 21,
            CANDIDATE_SELECTION = 22,
            JOINING_WORKER_LICENCE = 23,
            JOINING_WORKER_CERTIFICATE = 24,
            JOINING_WORKER_DOCUMENTS = 25,
            IMMIGRATION = 26,
            STAFF_OTHER_DOCUMENT = 27,
            CERTIFICATE_VERIFICATION = 28,
            HCM_STAFF_OTHER_DETAILS = 29,
            CLEARANCE_FORM_STAFF = 30,
            QUOTATION_MAIL_ATTCH_BKP = 31,
            ONBOARDING_VISA = 32,
            ONBOARDING_FLIGHTTICKET = 33,
            EMPLOYEE_DAILY_HOUR = 34,
            WPS_LIST = 35,
            EMP_ACCESS_MGMT = 36,
            APPOINMENT_PDF = 37,
            CONDUCT_INCIDENT_PDF = 38,
            SALARY_CERTIFICATE = 39,
            EXPERIENCE_CERT_PDF = 40,
            PAYSLIP_PDF = 41,
            EXPIRED_CSV = 42,
            SUPPLY_CSV = 43,
            GUARANTEETYPE_CSV = 44,
            EXPIRYRANG_CSV = 45,
            CLENT_GRANTEE_CSV = 46,
            PRJT_GRANTEE_CSV = 47,
            EMPLOYEE_DETAILS_CSV = 48,
            EMPLOYEE_RECRUITMENT_CSV = 49,
            VISA_BUNDLE_CSV = 50,
            MNPWR_REQRMNT_STS_CSV = 51,
            EXPIRY_NOTIFICATION_CSV = 52,
            MESS_CALCULTN_RPRT_CSV = 53,
            EMP_DEDUCTN_RPRT_CSV = 54,
            PAYROLL_PRSS_REPORT_CSV = 55,
            ATTENTANCE_RPRT_CSV = 56,
            LEAVE_APLICTN_RPRT_CSV = 57,
            JOB_COST_SUMMARY_CSV = 58,
            ON_BOARDING_STS_CSV = 59,
            ACCOMMODATION_REPORT_CSV = 60,
            INTERVIEW_SUMMARY_CSV = 61,
            IMMIGRATION_TASK_REPRT_CSV = 62,
            MNPWR_JOB_ASIGNMNT_RPRT_CSV = 63,
            VISA_QUOTA_STATUS_RPRT_CSV = 64,
            INTERVIEW_EVLVTN_RPRT_CSV = 65,
            MNPWR_PROCESS_DTL_RPRT_CSV = 66,
            JOB_OFFER_STATUS_RPRT_CSV = 67,
            ONBOARDING_JOB_ASGNMNT_RPRT_CSV = 68,
            LEAVE_MNGMNT_RPRT_CSV = 69,

            INSURANCE_EXPIRED_CSV = 70,
            PROJECT_WISE_INSURANCE_CSV = 71,
            INSURANCE_EXPIRYRANG_CSV = 72,
            INSURANCE_ATTACHMNT = 73,
            BANKGUARANTEE_CSV = 74,
            INSURANCE_TYPE_CSV = 75,

            CHEQUE_TEMPLATE = 76,

            SALE_INVOICE = 77,
            JOURNAL_VOUCHER = 78,
            CREDIT_NOTE = 79,
            RECEIPT_INVOICE = 80,
            PAYMENT_INVOICE = 81,
            DEBIT_NOTE = 82,
            PURCHASE_INVOICE = 83,
            JOINING_FORM = 84,
            DEFAULT_LOGO = 85,
            PURCHASE_ATTACHMENT = 87,
            SALES_ATTACHMENT = 86,
            JOINING_FORM_BLANK = 88,
            APP_ICONS = 89,
            CANDIDATE_PROFILEPIC = 90,
            END_OF_SERVICE_PDF = 91,
            LEAVE_SETTLEMENT_PDF = 92,
            MANUAL_ADD_DED_LIST_PDF = 93,
            MANUAL_ADD_DED_PDF = 94,
            MONTHLY_ATTENDACE_SHEET = 95,
            EXPORT_EMPLOYEE_DETAILS_CSV = 96,
            REPORT_PDF = 97,
            POSTDATED_CHEQUE_CSV = 98,
            TRANSACTION_PDF = 99,
            COST_CENTRE_PERFOMANCE_CSV = 100,
            REPORT_BUILDER_PDF = 101,
            CUSTOMER_OUTSTNDG_AGEING_CSV = 102,
            SUPPLIER_OUTSTNDG_AGEING_CSV = 103,
            COST_GROUP_PERFOMANCE_CSV = 104,
            PURCHASE_CSV = 105,
            SALE_CSV = 106,
            PAYMENTLIST_CSV = 107,
            RECIPTLIST_CSV = 108,
            DEBITNOTELIST_CSV = 109,
            CREDITNOTELIST_CSV = 110,
            JOURNALLIST_CSV = 111,
            PROFITLOSS_CSV = 112,
            BALANCESHEET_CSV = 113,
            TRIALBALANCE_CSV = 114,
            SUPPLIER_OUTSTANDING_CSV = 115,
            CUSTOMER_OUTSTANDING_CSV = 116,
            CUSTOMER_OUTSTANDING_PDF = 117,
            SUPPLIER_OUTSTANDING_PDF = 118,
            PROFIT_LOSS_PDF = 119,
            BALANCESHEET_PDF = 120,
            COST_CENTRE_PERFOMANCE_PDF = 121,
            COST_GROUP_PERFOMANCE_PDF = 122,
            POSTDATED_CHEQUE_PDF = 123,
            TRIAL_BALANCE_PDF = 124,
            CUSTOMER_OUTSTANDING_AGING_PDF = 125,
            SUPPLIER_OUTSTANDING_AGING_PDF = 126,
            REPORT_BUILDER_CSV = 127,
            LEDGER_STATEMENT_PDF = 128,
            LEDGER_STATEMENT_CSV = 129,
            MONTHLY_SALARY_STATEMENT = 130,
            POSTDATED_CHEQUE = 131,
            LEAVE_APPLICATION_REPORT_PDF = 132,
            PURCHASE_ORDER_ATTCHMNT = 133,
            EMP_ADD_DED_REPORT_PDF = 134,
            BANK_LIST_PDF = 135,
            BUSINESS_UNIT_LIST_PDF = 136,
            PURCHASE_ORDER_NOTE_ATTACH = 137,
            COUNTRY_LIST_PDF = 138,
            STATE_LIST_PDF = 139,
            CITY_LIST_PDF = 140,
            WORKSTATION_LIST_PDF = 141,
            DEPARTMENT_LIST_PDF = 142,
            DIVISION_LIST_PDF = 143,
            PASSWORD_LIST_PDF = 144,
            COMPLAINT_LIST_PDF = 145,
            FUELTYPE_LIST_PDF = 146,
            JOB_LIST_PDF = 147,
            INSURANCE_LIST_PDF = 148,
            PREMISE_LIST_PDF = 149,
            PREMISE_AREA_LIST_PDF = 150,
            TIMESLOT_LIST_PDF = 151,
            PARTNER_LIST_PDF = 152,
            APPROVAL_CONSOLE_NOTE_ATTACH = 153,
            APPROVAL_CONSOLE_ADDTNL_ATTACH = 155,
            PRODUCT_BRAND_LIST_PDF = 156,
            UNIT_MEASURE_LIST_PDF = 157,
            TAX_LIST_PDF = 158,
            VENDOR_CATEGORY = 154,
            CHARGE_HEAD = 168,
            WAREHOUSE_MASTER = 162,

            CUSTOMER_GROUP_LIST_PDF = 159,
            PRODUCT_GROUP_LIST_PDF = 161,
            TERMS_TEMPLATE_LIST_PDF = 169,
            OPPORTUNITY_RATE_LIST_PDF = 170,

            APPROVAL_HIERARCHY = 163,
            DOCUMENT_WORKFLOW = 164,
            VENDORCATEGORY_CSV = 165,
            WAREHOUSE_CSV = 166,
            CHARGEHEAD_CSV = 167,
            APPROVAL_HIERARCHY_CSV = 171,
            DOCUMENT_WORKFLOW_CSV = 172,
            MAIL_SETTINGS_LIST_PDF = 173,
            ACTIVE_OPPORTUNITY_RPT_PDF = 175,
            OPPORTUNITY_SUMMARY_RPT_PDF = 176,
            QUOTATION_SUMMARY_RPT_PDF = 177,
            APPROVAL_SET = 174,
            APPROVAL_ASSIGNMENT = 178,
            APPROVLA_SET_CSV = 179,
            APPROVAL_ASSIGNMENT_CSV = 180,
            PURCHASE_ORDER_PDF = 181,
            PURCHASE_ORDER_CSV = 182,
            APPROVAL_CONSOLE_PDF = 183,
            APPROVAL_CONSOLE_CSV = 184,
            TEAM_HIERACHY_PDF = 185,
            COUNTRY_ICON_IMAGES = 186,
            OPEN_DM_REPORT_PDF = 187,
            BOOKING_DM_REPORT_PDF = 188,
            PRODUCT_MASTER_PDF = 189,
            PRODUCT_CATEGORY_PDF = 190,
            BOOKING_SE_REPORT_PDF = 191,
            SALES_EXECUTIVE_PDF = 192,
            PROJECT_MASTER_LIST_PDF = 193,
            ITEM_LIST_PDF = 194,
            CUSTOMER_MASTER_PDF = 195,
            DEAL_CLOSURE_SE_RPT_PDF = 197,
            DEAL_CLOSURE_DM_RPT_PDF = 198,
            ACCOMMODATION_TYPE_PDF = 196,
            LICENSE_TYPE_PDF = 199,
            EMPLOYEE_ROLE_ALLOCATION_PDF = 200,

            PAYROLL_LIST_PDF = 201,
            DESIGNATION_MASTER_PDF = 202,
            JOB_ROLE_PDF = 203,
            OPPORTUNITY_LIST_PDF = 205,
            TASKS_LIST_PDF=206


        }

        public enum IMAGE_SIZE
        {
            DIVISION_ICON = 512000,
            USER_PROFILEPIC = 512000,
            VEHICLE_ATTACHMENT = 512000,
            WATER_RECHARGE = 512000,
            CORPORATE_PARTNER = 512000,
            REQUEST_FOR_GUARANTEE = 512000,
            EMPLOYEE_PERSONAL = 512000,
            CANDIDATE_SELECTION = 512000,
            JOINING_WORKER_LICENCE = 512000,
            JOINING_WORKER_CERTIFICATE = 512000,
            JOINING_WORKER_DOCUMENTS = 512000,
            CLEARANCE_FORM_STAFF = 512000,
            QTN_ADDITIONAL = 512000,
            ONBOARDING_VISA = 512000,
            ONBOARDING_FLIGHTTICKET = 512000,
            CANDIDATE_PROFILEPIC = 512000,
        }
        //store mail storage parts as enumeration
        public enum Mail_Storage
        {
            Inbox = 1,
            Draft = 2,
            Trash = 3,
            Sent = 4
        }
        //Method for storing section of mesage.
        public enum MSG_SECTION
        {
            LEAD_WON = 1,
            LEAD_LOST = 2,
            QUOTATION_PDF_FOOTER_MSG = 3

        }

        //store mail actions as enumeration
        public enum Mail_Actions
        {
            Forward = 1,
            Allocate = 2,
            Attach = 3,
            Reject = 4,
            Lead = 5,
            User_New = 6
        }

        //store lead sources
        public enum Lead_Sources
        {
            Mail = 1,
            Fax = 2,
            Phone = 3,
            Other = 4
        }

        //Method for setting id for Customer Type
        public enum CustomerType
        {
            CONTRACTOR = 1,
            CLIENT = 4,
            CUSTOMER = 2,
            CONSULTANT = 3
        }

        //enumeration of TERMS
        public enum TERMS_TEMPLATE
        {
            Price_Term = 1,
            Payment_Term = 2,
            Delivery_Term = 3,
            Warranty_Term = 4,
            Manufacturer_Term = 5
        }


        //Method for fetching Path of Image stored.
        public string GetImagePath(IMAGE_SECTION enumImgPath)
        {
            string strPath = "";
            if (enumImgPath == IMAGE_SECTION.USER_PROFILEPIC)
            {
                strPath = "/CustomImages/UserImages/";

            }
            else if (enumImgPath == IMAGE_SECTION.DIVISION_ICON)
            {
                strPath = "/CustomImages/DivisionIcons/";
            }

            else if (enumImgPath == IMAGE_SECTION.Rate_Amendment)
            {
                strPath = "/CustomImages/RateAmendment/";
            }
            else if (enumImgPath == IMAGE_SECTION.QUOTATION_ATTACHMENT)
            {
                strPath = "/CustomImages/Quotation_attachment/";
            }
            else if (enumImgPath == IMAGE_SECTION.LEAD_ATTACHMENT)
            {
                strPath = "/CustomImages/Lead_attachment/";
            }
            else if (enumImgPath == IMAGE_SECTION.Mail_Attachments)
            {
                strPath = "CustomImages\\MailAttachments\\";
            }
            else if (enumImgPath == IMAGE_SECTION.Lead_Mail_Attachment)
            {
                strPath = "/CustomImages/LeadMailAttachments/";
            }
            else if (enumImgPath == IMAGE_SECTION.QUOTATION_PDF)
            {
                strPath = "/CustomImages/Quotation_PDF/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CORPORATE_LOGOS)
            {
                strPath = "/CustomImages/Corporate Logos/";
            }
            else if (enumImgPath == IMAGE_SECTION.QUOTATION_IMPORT)
            {
                strPath = "/CustomImages/Quotation_Import/";
            }
            else if (enumImgPath == IMAGE_SECTION.CURRENCY_SYMBOL)
            {
                strPath = "/CustomImages/Currency_Symbol/";
            }
            else if (enumImgPath == IMAGE_SECTION.APP_ICON_IMAGES)
            {
                strPath = "/CustomImages/App_Icon_Images/";
            }
            else if (enumImgPath == IMAGE_SECTION.VEHICLE_MASTER)
            {
                strPath = "/CustomImages/Vehicle_Master_Images/";
            }

            else if (enumImgPath == IMAGE_SECTION.USER_LICENSECOPY)
            {
                strPath = "/CustomImages/User_LicenseCopy/";

            }
            else if (enumImgPath == IMAGE_SECTION.WATER_RECHARGE)
            {
                strPath = "/CustomImages/Water_Recharge/";

            }
            else if (enumImgPath == IMAGE_SECTION.REQUEST_FOR_GUARANTEE)
            {
                strPath = "/CustomImages/Request_Guarantee/";

            }
            else if (enumImgPath == IMAGE_SECTION.Guarantee_Attchment)
            {
                strPath = "/CustomImages/Guarantee_Attchments/";

            }
            else if (enumImgPath == IMAGE_SECTION.Bussiness_Unit)
            {
                strPath = "/CustomImages/Corporate_Attchments/";

            }
            else if (enumImgPath == IMAGE_SECTION.ORGANIZATION)
            {
                strPath = "/CustomImages/Org_detail_attachment/";
            }
            else if (enumImgPath == IMAGE_SECTION.EMPLOYEE_IMMIGRATION)
            {
                strPath = "/CustomImages/Employee_Immigration_Attchment/";
            }
            else if (enumImgPath == IMAGE_SECTION.QUALIFICATION)
            {
                strPath = "/CustomImages/Qualification/";
            }
            else if (enumImgPath == IMAGE_SECTION.CANDIDATE_SELECTION)
            {
                strPath = "/CustomFiles/Candidate_Selection/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.JOINING_WORKER_LICENCE)
            {
                strPath = "/CustomFiles/Joining_Worker/LicenceFiles/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.JOINING_WORKER_CERTIFICATE)
            {
                strPath = "/CustomFiles/Joining_Worker/CertificateFiles/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.JOINING_WORKER_DOCUMENTS)
            {
                strPath = "/CustomFiles/Joining_Worker/DocumentFiles/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.IMMIGRATION)
            {
                strPath = "/CustomImages/Immigration/";

            }
            else if (enumImgPath == IMAGE_SECTION.STAFF_OTHER_DOCUMENT)
            {
                strPath = "/CustomFiles/StaffDocumentFiles/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CERTIFICATE_VERIFICATION)
            {
                strPath = "/CustomFiles/Certificate_Verification/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.HCM_STAFF_OTHER_DETAILS)
            {
                strPath = "/CustomFiles/Hcm_Staff_Other_Details/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CLEARANCE_FORM_STAFF)
            {
                strPath = "/CustomFiles/Clearance_Form_Staff/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.QUOTATION_MAIL_ATTCH_BKP)
            {
                strPath = "/CustomImages/QuotationMailAttchBkp/";
            }
            else if (enumImgPath == IMAGE_SECTION.ONBOARDING_VISA)
            {
                strPath = "/CustomFiles/ONBOARDING_PROCESS/ONBOARDING_VISA/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.ONBOARDING_FLIGHTTICKET)
            {
                strPath = "/CustomFiles/ONBOARDING_PROCESS/ONBOARDING_FLIGHTTICKET/";
                ClearOlderFiles(strPath);

            }

            else if (enumImgPath == IMAGE_SECTION.EMPLOYEE_DAILY_HOUR)
            {
                strPath = "/CustomFiles/EmployeeDailyHour/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.WPS_LIST)
            {
                strPath = "/CustomFiles/hcm_Monthly_Sal_WPS/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.EMP_ACCESS_MGMT)
            {
                strPath = "/CustomFiles/EmpAccessMgmt/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.APPOINMENT_PDF)
            {
                strPath = "/CustomFiles/messagepdf/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CONDUCT_INCIDENT_PDF)
            {
                strPath = "/CustomFiles/Conduct_Incident/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.SALARY_CERTIFICATE)
            {
                strPath = "/CustomFiles/SalaryCertficate/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.EXPERIENCE_CERT_PDF)
            {
                strPath = "/CustomFiles/messagepdf/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.PAYSLIP_PDF)
            {
                strPath = "/CustomFiles/PaySlip/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.EXPIRED_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Expired Guarantee/";
            }
            else if (enumImgPath == IMAGE_SECTION.SUPPLY_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Supply Guarantee/";
            }
            else if (enumImgPath == IMAGE_SECTION.GUARANTEETYPE_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Guarantee Type/";
            }
            else if (enumImgPath == IMAGE_SECTION.JOB_ROLE_PDF)
            {
                strPath = "/CustomFiles/Hcm_jobrole/";
                ClearOlderFiles(strPath);

            }

            else if (enumImgPath == IMAGE_SECTION.CLENT_GRANTEE_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Client Guarantee/";
            }
            else if (enumImgPath == IMAGE_SECTION.EXPIRYRANG_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Expiry Range/";
            }
            else if (enumImgPath == IMAGE_SECTION.PRJT_GRANTEE_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Project Guarantee/";
            }
            else if (enumImgPath == IMAGE_SECTION.EMPLOYEE_DETAILS_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Employee Details/";
            }
            else if (enumImgPath == IMAGE_SECTION.EMPLOYEE_RECRUITMENT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Employee Recruitment/";
            }
            else if (enumImgPath == IMAGE_SECTION.VISA_BUNDLE_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Visa Bundle/";
            }
            else if (enumImgPath == IMAGE_SECTION.MNPWR_REQRMNT_STS_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Manpower Requirement Status/";
            }
            else if (enumImgPath == IMAGE_SECTION.EXPIRY_NOTIFICATION_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Expiry Notification/";
            }

            else if (enumImgPath == IMAGE_SECTION.PAYROLL_LIST_PDF)
            {
                strPath = "/CustomFiles/Payroll_list/";
                // ClearOlderFiles(strPath);

            }

            else if (enumImgPath == IMAGE_SECTION.JOB_COST_SUMMARY_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Job_Cost_summary/";
            }
            else if (enumImgPath == IMAGE_SECTION.ON_BOARDING_STS_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/OnBoarding_Status/";
            }
            else if (enumImgPath == IMAGE_SECTION.ACCOMMODATION_REPORT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Accommodation/";
            }
            else if (enumImgPath == IMAGE_SECTION.INTERVIEW_SUMMARY_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/InterviewSummary/";
            }
            else if (enumImgPath == IMAGE_SECTION.IMMIGRATION_TASK_REPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/ImmigrationTask/";
            }
            else if (enumImgPath == IMAGE_SECTION.MNPWR_JOB_ASIGNMNT_RPRT_CSV)//
            {
                strPath = "/CustomFiles/HCM CSV/Manpower_Job_Assignment/";
            }
            else if (enumImgPath == IMAGE_SECTION.VISA_QUOTA_STATUS_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/VisaQuoata_Staus/";
            }
            else if (enumImgPath == IMAGE_SECTION.INTERVIEW_EVLVTN_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Interview Evaluation/";
            }
            else if (enumImgPath == IMAGE_SECTION.MNPWR_PROCESS_DTL_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Manpower_ProcessDtls/";
            }
            else if (enumImgPath == IMAGE_SECTION.JOB_OFFER_STATUS_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Job_Offer_Status/";
            }
            else if (enumImgPath == IMAGE_SECTION.ONBOARDING_JOB_ASGNMNT_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/On Boarding Job Assignment/";
            }
            else if (enumImgPath == IMAGE_SECTION.LEAVE_MNGMNT_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Leave_Management/";
            }
            else if (enumImgPath == IMAGE_SECTION.PAYROLL_PRSS_REPORT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Payroll Process/";
            }
            else if (enumImgPath == IMAGE_SECTION.MESS_CALCULTN_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Mess Calculation/";
            }
            else if (enumImgPath == IMAGE_SECTION.EMP_DEDUCTN_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Employee Deducation/";
            }
            else if (enumImgPath == IMAGE_SECTION.ATTENTANCE_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Attendance/";
            }
            else if (enumImgPath == IMAGE_SECTION.LEAVE_APLICTN_RPRT_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Leave Application/";
            }

            else if (enumImgPath == IMAGE_SECTION.INSURANCE_EXPIRED_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Insurance_Expired/";
            }
            else if (enumImgPath == IMAGE_SECTION.PROJECT_WISE_INSURANCE_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Insurance_Project_Wise/";
            }
            else if (enumImgPath == IMAGE_SECTION.INSURANCE_EXPIRYRANG_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Insurance_Expiry_Range/";
            }
            else if (enumImgPath == IMAGE_SECTION.INSURANCE_ATTACHMNT)
            {
                strPath = "/CustomImages/Insurance_Attchmnts/";
            }
            else if (enumImgPath == IMAGE_SECTION.BANKGUARANTEE_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Bank_Gurarantee_csv/";
            }
            else if (enumImgPath == IMAGE_SECTION.INSURANCE_TYPE_CSV)
            {
                strPath = "/CustomFiles/GMS CSV/Insurance_Type_csv/";
            }
            else if (enumImgPath == IMAGE_SECTION.CHEQUE_TEMPLATE)
            {
                strPath = "/CustomImages/Cheque_Template/";
            }
            else if (enumImgPath == IMAGE_SECTION.SALE_INVOICE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_Sale_Invoice/";

                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.JOURNAL_VOUCHER)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_Journal/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.CREDIT_NOTE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_CreditNote/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.RECEIPT_INVOICE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_RECEIPT_Invoice/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PAYMENT_INVOICE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_PAYMENT_INVOICE/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DEBIT_NOTE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_DEBIT_NOTE/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_INVOICE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_PURCHASE_INVOICE/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DEFAULT_LOGO)
            {
                strPath = "/CustomImages/Default_image/NoLogo_Image.jpg";
            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_ATTACHMENT)
            {
                strPath = "/CustomFiles/FMS/PURCHASE/";
            }
            else if (enumImgPath == IMAGE_SECTION.SALES_ATTACHMENT)
            {
                strPath = "/CustomFiles/FMS/SALES/";
            }
            else if (enumImgPath == IMAGE_SECTION.JOINING_FORM)
            {
                strPath = "/CustomFiles/Joining_Form/";
            }
            else if (enumImgPath == IMAGE_SECTION.JOINING_FORM_BLANK)
            {
                strPath = "/CustomFiles/Blank_Joing_Form/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APP_ICONS)
            {
                strPath = "/Images/AppIcons/";
            }
            else if (enumImgPath == IMAGE_SECTION.CANDIDATE_PROFILEPIC)
            {
                strPath = "/CustomImages/CANDIDATE_PROFILEPIC/";
            }
            else if (enumImgPath == IMAGE_SECTION.END_OF_SERVICE_PDF)
            {
                strPath = "/CustomFiles/END_OF_SERVICE_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.LEAVE_SETTLEMENT_PDF)
            {
                strPath = "/CustomFiles/Leave_Settlement_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.MANUAL_ADD_DED_LIST_PDF)
            {
                strPath = "/CustomFiles/Manual_Add_Ded_List_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.MANUAL_ADD_DED_PDF)
            {
                strPath = "/CustomFiles/Manual_Add_Ded_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.MONTHLY_ATTENDACE_SHEET)
            {
                strPath = "/CustomFiles/MonthlyAttendanceSheet/";
            }
            else if (enumImgPath == IMAGE_SECTION.EXPORT_EMPLOYEE_DETAILS_CSV)
            {
                strPath = "/CustomFiles/HCM CSV/Export Employee Details/";

            }
            else if (enumImgPath == IMAGE_SECTION.REPORT_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.POSTDATED_CHEQUE_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Postdated Cheque/";

            }
            else if (enumImgPath == IMAGE_SECTION.TRANSACTION_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/TRANSACTION_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.COST_CENTRE_PERFOMANCE_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Cost Centre Perfomance/";

            }
            else if (enumImgPath == IMAGE_SECTION.REPORT_BUILDER_PDF)
            {
                strPath = "/CustomFiles/ReportBuilder/PDF/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CUSTOMER_OUTSTNDG_AGEING_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Customer Outstanding Ageing/";

            }
            else if (enumImgPath == IMAGE_SECTION.SUPPLIER_OUTSTNDG_AGEING_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Supplier Outstanding Ageing/";

            }
            else if (enumImgPath == IMAGE_SECTION.COST_GROUP_PERFOMANCE_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Cost Group Perfomance/";

            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Purchase/";

            }
            else if (enumImgPath == IMAGE_SECTION.SALE_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Sale/";

            }
            else if (enumImgPath == IMAGE_SECTION.PAYMENTLIST_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Payment/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.RECIPTLIST_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Receipt/";
                //  ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CREDITNOTELIST_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/CreditNote/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.DEBITNOTELIST_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/DebitNote/";
                //  ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.JOURNALLIST_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/Journal/";

            }
            else if (enumImgPath == IMAGE_SECTION.PROFITLOSS_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/ProfitAndLoss/";

            }
            else if (enumImgPath == IMAGE_SECTION.BALANCESHEET_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/BalanceSheet/";

            }
            else if (enumImgPath == IMAGE_SECTION.TRIALBALANCE_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/TrialBalance/";

            }
            else if (enumImgPath == IMAGE_SECTION.SUPPLIER_OUTSTANDING_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/SupplierOutstanding/";

            }
            else if (enumImgPath == IMAGE_SECTION.CUSTOMER_OUTSTANDING_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/CustomerOutstanding/";

            }
            else if (enumImgPath == IMAGE_SECTION.CUSTOMER_OUTSTANDING_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/CustomerOutstanding/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.SUPPLIER_OUTSTANDING_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/SupplierOutstanding/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PROFIT_LOSS_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/ProfitAndLoss/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.BALANCESHEET_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/BalanceSheet/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.COST_CENTRE_PERFOMANCE_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/CostCentrePerfmnc/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.COST_GROUP_PERFOMANCE_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/CostGroupPerfmnc/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.POSTDATED_CHEQUE_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/PostDatedCheque/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.TRIAL_BALANCE_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/TrialBalance/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.CUSTOMER_OUTSTANDING_AGING_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/CustomerOutstandingAgeing/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.SUPPLIER_OUTSTANDING_AGING_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/SupplierOutstandingAgeing/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.REPORT_BUILDER_CSV)
            {
                strPath = "/CustomFiles/ReportBuilder/CSV/";

            }
            else if (enumImgPath == IMAGE_SECTION.LEDGER_STATEMENT_PDF)
            {
                strPath = "/CustomFiles/FMS_PDF/REPORT_PDF/LedgerStatement/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.LEDGER_STATEMENT_CSV)
            {
                strPath = "/CustomFiles/FMS CSV/LedgerStatement/";
                //ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.MONTHLY_SALARY_STATEMENT)
            {
                strPath = "/CustomFiles/MonthlySalaryStatement/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.POSTDATED_CHEQUE)
            {
                strPath = "/CustomFiles/FMS_PDF/FMS_POSTDATED_CHEQUE/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.LEAVE_APPLICATION_REPORT_PDF)
            {
                strPath = "/CustomFiles/Leave_Application_Report_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_ORDER_ATTCHMNT)
            {
                strPath = "/CustomFiles/PMS/PurchaseOrder/";
            }
            else if (enumImgPath == IMAGE_SECTION.EMP_ADD_DED_REPORT_PDF)
            {
                strPath = "/CustomFiles/Employee_AddDed_Report_PDF/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.BANK_LIST_PDF)
            {
                strPath = "/CustomFiles/BANK_LIST/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.BUSINESS_UNIT_LIST_PDF)
            {
                strPath = "/CustomFiles/BusinessUnit_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_ORDER_NOTE_ATTACH)
            {
                strPath = "/CustomFiles/PMS/PurchaseOrderNote/";
            }
            else if (enumImgPath == IMAGE_SECTION.COUNTRY_LIST_PDF)
            {
                strPath = "/CustomFiles/Country_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.STATE_LIST_PDF)
            {
                strPath = "/CustomFiles/State_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.CITY_LIST_PDF)
            {
                strPath = "/CustomFiles/City_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.WORKSTATION_LIST_PDF)
            {
                strPath = "/CustomFiles/Workstation_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.FUELTYPE_LIST_PDF)
            {
                strPath = "/CustomFiles/AWMS_PDF/Fuel_Type_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.JOB_LIST_PDF)
            {
                strPath = "/CustomFiles/AWMS_PDF/Job_Master_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DEPARTMENT_LIST_PDF)
            {
                strPath = "/CustomFiles/Department_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DIVISION_LIST_PDF)
            {
                strPath = "/CustomFiles/Division_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PASSWORD_LIST_PDF)
            {
                strPath = "/CustomFiles/Password_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.COMPLAINT_LIST_PDF)
            {
                strPath = "/CustomFiles/Complaint_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.INSURANCE_LIST_PDF)
            {
                strPath = "/CustomFiles/Insurance_Provider_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PREMISE_LIST_PDF)
            {
                strPath = "/CustomFiles/Premise_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PREMISE_AREA_LIST_PDF)
            {
                strPath = "/CustomFiles/Premise_Area_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.TIMESLOT_LIST_PDF)
            {
                strPath = "/CustomFiles/Timeslot_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PARTNER_LIST_PDF)
            {
                strPath = "/CustomFiles/Partner_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_CONSOLE_NOTE_ATTACH)
            {
                strPath = "/CustomFiles/PMS/ApprovalConsoleNote/";
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_CONSOLE_ADDTNL_ATTACH)
            {
                strPath = "/CustomFiles/PMS/ApprovalConsoleAddtnlDtls/";
            }
            else if (enumImgPath == IMAGE_SECTION.PRODUCT_BRAND_LIST_PDF)
            {
                strPath = "/CustomFiles/Product_Brand_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.UNIT_MEASURE_LIST_PDF)
            {
                strPath = "/CustomFiles/Unit_Measure_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.TAX_LIST_PDF)
            {
                strPath = "/CustomFiles/Tax_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.VENDOR_CATEGORY)
            {
                strPath = "/CustomFiles/PMS/VENDOR_CATEGORY/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.CHARGE_HEAD)
            {
                strPath = "/CustomFiles/PMS/CHARGE_HEADS/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.WAREHOUSE_MASTER)
            {
                strPath = "/CustomFiles/PMS/WAREHOUSE_MASTER/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.CUSTOMER_GROUP_LIST_PDF)
            {
                strPath = "/CustomFiles/Customer_Group_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PRODUCT_GROUP_LIST_PDF)
            {
                strPath = "/CustomFiles/Product_Group_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.TERMS_TEMPLATE_LIST_PDF)
            {
                strPath = "/CustomFiles/Terms_Template_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.OPPORTUNITY_RATE_LIST_PDF)
            {
                strPath = "/CustomFiles/Opportunity_Rate_List/";
                ClearOlderFiles(strPath);
            }

            else if (enumImgPath == IMAGE_SECTION.APPROVAL_HIERARCHY)
            {
                strPath = "/CustomFiles/PMS/APPROVAL_HIERARCHY/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DOCUMENT_WORKFLOW)
            {
                strPath = "/CustomFiles/PMS/DOCUMENT_WORKFLOW/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.VENDORCATEGORY_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Vendor_category/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.WAREHOUSE_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Warehouse_master/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.CHARGEHEAD_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Charge_head/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_HIERARCHY_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Approval_hierarchy/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.DOCUMENT_WORKFLOW_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Document_workflow/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.MAIL_SETTINGS_LIST_PDF)
            {
                strPath = "/CustomFiles/Mail_Settings_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.ACTIVE_OPPORTUNITY_RPT_PDF)
            {
                strPath = "/CustomFiles/Active_Opportunity_Rpt/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.OPPORTUNITY_SUMMARY_RPT_PDF)
            {
                strPath = "/CustomFiles/Opportunity_Summary_Rpt/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.QUOTATION_SUMMARY_RPT_PDF)
            {
                strPath = "/CustomFiles/Quotation_Summary_Rpt/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_ASSIGNMENT_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Approval_assignment/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_ASSIGNMENT)
            {
                strPath = "/CustomFiles/PMS/APPROVAL_ASSIGNMENT/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVLA_SET_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Approval_set/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_SET)
            {
                strPath = "/CustomFiles/PMS/APPROVAL_SET/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_ORDER_PDF)
            {
                strPath = "/CustomFiles/PMS/PURCHASE_ORDER/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PURCHASE_ORDER_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Purchase_order/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_CONSOLE_PDF)
            {
                strPath = "/CustomFiles/PMS/APPROVAL_CONSOLE/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.APPROVAL_CONSOLE_CSV)
            {
                strPath = "/CustomFiles/PMS_CSV/Approval_console/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.TEAM_HIERACHY_PDF)
            {
                strPath = "/CustomFiles/TeamHierarchy/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.OPEN_DM_REPORT_PDF)
            {
                strPath = "/CustomFiles/OpenDMReport/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.BOOKING_DM_REPORT_PDF)
            {
                strPath = "/CustomFiles/BookingDMReport/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.COUNTRY_ICON_IMAGES)
            {
                strPath = "/CustomImages/Country_Icon_Images/";
            }
            else if (enumImgPath == IMAGE_SECTION.PRODUCT_MASTER_PDF)
            {
                strPath = "/CustomFiles/Product_Master_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.PRODUCT_CATEGORY_PDF)
            {
                strPath = "/CustomFiles/Product_Category_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.BOOKING_SE_REPORT_PDF)
            {
                strPath = "/CustomFiles/Booking_SE_Rpt/";
                ClearOlderFiles(strPath);
            }

            else if (enumImgPath == IMAGE_SECTION.SALES_EXECUTIVE_PDF)
            {
                strPath = "/CustomFiles/open_sales_list/";
                // ClearOlderFiles(strPath);

            }

            else if (enumImgPath == IMAGE_SECTION.ITEM_LIST_PDF)
            {
                strPath = "/CustomFiles/Item_list/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.PROJECT_MASTER_LIST_PDF)
            {
                strPath = "/CustomFiles/Project_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.CUSTOMER_MASTER_PDF)
            {
                strPath = "/CustomFiles/Customer_Master/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.DEAL_CLOSURE_SE_RPT_PDF)
            {
                strPath = "/CustomFiles/Deal_Closure_SE_Rpt/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DEAL_CLOSURE_DM_RPT_PDF)
            {
                strPath = "/CustomFiles/Deal_Closure_DM_Rpt/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.ACCOMMODATION_TYPE_PDF)
            {
                strPath = "/CustomFiles/Accommodation_Type/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.LICENSE_TYPE_PDF)
            {
                strPath = "/CustomFiles/License_Type/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.EMPLOYEE_ROLE_ALLOCATION_PDF)
            {
                strPath = "/CustomFiles/Employee_Role_Allocation_List/";
                ClearOlderFiles(strPath);
            }
            else if (enumImgPath == IMAGE_SECTION.DESIGNATION_MASTER_PDF)
            {
                strPath = "/CustomFiles/Designation_Master/";
                // ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.OPPORTUNITY_LIST_PDF)
            {
                strPath = "/CustomFiles/Opportunity_List/";
                ClearOlderFiles(strPath);

            }
            else if (enumImgPath == IMAGE_SECTION.TASKS_LIST_PDF)
            {
                strPath = "/CustomFiles/Tasks_List/";
                ClearOlderFiles(strPath);

            }
            return strPath;

        }




        public void ClearOlderFiles(string filepath)
        {
            //EVM 040 START

            int intCorpId = 0;
            if (HttpContext.Current.Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.DELETE_PDF_DAYS };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            string str = dtCorpDetail.Rows[0]["DELETE_PDF_DAYS"].ToString().Trim();

            string[] files = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath(filepath));

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                info.Refresh();

                if (IsFileLocked(info) == false)
                {
                    if (info.LastWriteTime <= DateTime.Now.AddDays(-Convert.ToInt32(str)))
                    {
                        info.Delete();
                    }
                }
            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        //Method for fetching message.
        public string GetMsg(MSG_SECTION enumMsgSctn)
        {
            string strMsg = "";
            if (enumMsgSctn == MSG_SECTION.LEAD_WON)
            {
                strMsg = "Congratulations for Successfull Conversion";

            }
            else if (enumMsgSctn == MSG_SECTION.LEAD_LOST)
            {
                strMsg = "Status Changed to loss!";
            }
            else if (enumMsgSctn == MSG_SECTION.QUOTATION_PDF_FOOTER_MSG)
            {
                strMsg = "We hope the above offer will have your approval and look forward to receive your valued order. For any further clarifications, please contact ";
            }
            return strMsg;

        }

        //Method for fetch the ip address.
        public string GetInfo()
        {
            return new WebClient().DownloadString("http://api.hostip.info/get_html.php");



        }
        public string CancelReason()
        {
            string strRsn = "--USER CANCELLED--";
            return strRsn;



        }
        public string GetIp()
        {
            //string strIp = GetInfo().ToString();
            //string[] strArrIp = strIp.Split(':');
            //string strAdr = "";
            //if (strArrIp.Length > 3)
            //{
            //    strAdr = strArrIp[3];

            //}
            //string[] strArrIp1 = strAdr.Split('\n');
            //string strArrIpAddr = strArrIp1[0];
            //return strArrIpAddr;
            return "";
        }
        //Method for generate random numbers.
        public string Random_Number()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 6)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        //round off function
        public decimal CalculateAmtAfterRoundOff(decimal AmountBeforeRound)
        {
            decimal decimalPart;
            decimal amountAfterRoundOff;
            decimalPart = Convert.ToDecimal(AmountBeforeRound - (Int64)AmountBeforeRound);
            if ((decimalPart >= 0) && (decimalPart < Convert.ToDecimal(.25)))
                decimalPart = 0;
            else if (decimalPart >= Convert.ToDecimal(0.25) && decimalPart < Convert.ToDecimal(0.75))
                decimalPart = Convert.ToDecimal(0.5);
            else if (decimalPart >= Convert.ToDecimal(0.75))
                return Math.Ceiling(AmountBeforeRound);

            amountAfterRoundOff = Math.Floor(AmountBeforeRound) + decimalPart;
            return amountAfterRoundOff;
        }

        //Method for formating Corporate Address.
        public string FrmtCrprt_Addr(string strCompanyAddr1, string strCompanyAddr2, string strCompanyAddr3, string strCompanyAddrCntry)
        {
            string strCompanyAddr = "";


            if (strCompanyAddr1 != "")
            {
                strCompanyAddr = strCompanyAddr1;
                if (strCompanyAddr2 == "")
                {
                    if (strCompanyAddr3 == "")
                    {
                        if (strCompanyAddrCntry == "")
                        {
                            strCompanyAddr = strCompanyAddr + ".";
                        }
                        else
                        {
                            strCompanyAddr = strCompanyAddr + "," + strCompanyAddrCntry + ".";
                        }

                    }
                    else
                    {
                        strCompanyAddr = strCompanyAddr + "," + strCompanyAddr3;
                        if (strCompanyAddrCntry == "")
                        {
                            strCompanyAddr = strCompanyAddr + ".";
                        }
                        else
                        {
                            strCompanyAddr = strCompanyAddr + "," + strCompanyAddrCntry + ".";
                        }

                    }
                }
                else
                {
                    strCompanyAddr = strCompanyAddr + "," + strCompanyAddr2;
                    if (strCompanyAddr3 == "")
                    {
                        if (strCompanyAddrCntry == "")
                        {
                            strCompanyAddr = strCompanyAddr + ".";
                        }
                        else
                        {
                            strCompanyAddr = strCompanyAddr + "," + strCompanyAddrCntry + ".";
                        }

                    }
                    else
                    {
                        strCompanyAddr = strCompanyAddr + "," + strCompanyAddr3;
                        if (strCompanyAddrCntry == "")
                        {
                            strCompanyAddr = strCompanyAddr + ".";
                        }
                        else
                        {
                            strCompanyAddr = strCompanyAddr + "," + strCompanyAddrCntry + ".";
                        }

                    }
                }

            }
            return strCompanyAddr;
        }


        //Method for encrypting passwords
        static public void Encrp_Pwd(clsEntityOrgParking objEntityOrgParking)
        {
            string strPwd = objEntityOrgParking.Password;
            objEntityOrgParking.EncryptPassword = strPwd;
        }
        //Declaring all months in an array
        public string[] arrMonth = new string[] { "Select Month", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        // This is the common method which will get dd/mm/yyyy string and converted to 
        // datetime type.
        public DateTime textToDateTime(string strSearchText)
        {


            int dayValue = Convert.ToInt32(strSearchText.Substring(0, 2));
            int mtValue = Convert.ToInt32(strSearchText.Substring(3, 2));
            int yrValue = Convert.ToInt32(strSearchText.Substring(6, 4));
            return (new DateTime(yrValue, mtValue, dayValue));


        }
        public DateTime textWithTimeToDateTime(string strSearchText)
        {//01-01-2010 01:23 pm
            int dayValue = Convert.ToInt32(strSearchText.Substring(0, 2));
            int mtValue = Convert.ToInt32(strSearchText.Substring(3, 2));
            int yrValue = Convert.ToInt32(strSearchText.Substring(6, 4));
            int inthr = Convert.ToInt32(strSearchText.Substring(11, 2));
            int intmn = Convert.ToInt32(strSearchText.Substring(14, 2));
            string strAM_PM = strSearchText.Substring(17, 2);
            if (strAM_PM == "PM" && inthr != 12)
            {

                inthr = inthr + 12;
            }
            if (strAM_PM == "AM" && inthr == 12)
            {

                inthr = 0;
            }
            return (new DateTime(yrValue, mtValue, dayValue, inthr, intmn, 0));

        }
        //convert date time of any formate to dd-mm-yyyy hh:mmtt string format
        public string ConvertDateTimeToStringWithTime(DateTime dtDate)
        {

            return dtDate.ToString("dd-MM-yyyy hh:mmtt");

        }
        //convert date time of any formate to dd-mm-yyyy  string format
        public string ConvertDateTimeToStringWithoutTime(DateTime dtDate)
        {

            return dtDate.ToString("dd-MM-yyyy");

        }
        public bool IsNumberDate(string strText, bool blnNumber)
        {
            string strExpresion;

            if (blnNumber == true)
            { strExpresion = @"^[1-9]\d*(\.\d+)?$"; }

            else { strExpresion = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$"; }

            try
            {
                if (String.IsNullOrWhiteSpace(strText))
                {
                    return false;
                }
                if (!Regex.IsMatch(strText, strExpresion))
                {
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
            }
            return false;
        }


        //Replace string for dispaying ',",\ in onclick of javascript
        public string ReplaceEscapeSequence_ForJavascript(string strActual)
        {
            string strRepalce = strActual;
            strRepalce = strRepalce.Replace(@"\", @"\\");
            strRepalce = strRepalce.Replace(Environment.NewLine, @"\r\n");
            strRepalce = strRepalce.Replace(@"'", @"\'");
            strRepalce = strRepalce.Replace(@"""", "&quot;");
            return strRepalce;

        }





        public string Format(int intDecimalCount, string strValue)
        {
            if (strValue == ".")
            {
                strValue = "0";
            }
            if (strValue == "")
            {
                strValue = "0";
            }
            //for concatinating zero
            string strZero = "0";
            if (intDecimalCount > 1)
            {
                string strdecimal = strZero.PadRight(intDecimalCount, '0');
                //  MessageBox.Show(String.Format("{0:0." + strdecimal + "}",52.3));
                return String.Format("{0:0." + strdecimal + "}", Convert.ToDecimal(strValue));
            }
            else if (intDecimalCount == 1)
            {
                return String.Format("{0:0." + strZero + "}", Convert.ToDecimal(strValue));
            }
            else
            {
                return String.Format("{0:0}", Convert.ToDecimal(strValue));
            }

        }
        // this method is to Round a two decimal number in which RATES SUCH AS 23.23, 23.21, 23.57 etc. ALL THESE WILL BE CONVERTED AS 23.25, 23.25, 23,60
        public string RoundTwoDigit(string text)
        {
            if (text != "")
            {
                decimal dcheckint = Convert.ToDecimal(text) - Convert.ToInt64(Convert.ToDecimal(text));

                if (dcheckint != 0)
                {
                    decimal decMulValue = Convert.ToDecimal(text) * 10;
                    string strMulValue = decMulValue.ToString();
                    Int64 intMulValue = (Int64)decMulValue;
                    decimal dcheckintsecond = decMulValue - intMulValue;
                    if (dcheckintsecond != 0)
                    {
                        decimal decMulValueSecond = dcheckintsecond * 10;
                        decimal decSum = 0;
                        if (decMulValueSecond <= 5)
                        {
                            int intDigit = 5;
                            for (int intCount = 1; intCount <= 5; intCount++)
                            {
                                if (decMulValueSecond == intCount)
                                {
                                    int intdif = intDigit - intCount;
                                    float flDiv = (float)intdif / 100;
                                    decimal decDiv = Convert.ToDecimal(flDiv);
                                    decSum = Convert.ToDecimal(text) + decDiv;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            int intDigit = 5;
                            int intCount = 1;
                            for (int intequal = 6; intequal <= 9; intequal++)
                            {
                                if (decMulValueSecond == intequal)
                                {
                                    int intdif = intDigit - intCount;
                                    float flDiv = (float)intdif / 100;
                                    decimal decDiv = Convert.ToDecimal(flDiv);
                                    decSum = Convert.ToDecimal(text) + decDiv;
                                    break;
                                }
                                intCount++;
                            }
                        }
                        string strSum = Format(2, Convert.ToString(decSum.ToString()));
                        return strSum;
                    }
                    else
                    {
                        return text;
                    }
                }
                else
                {
                    return text;
                }
            }
            else
            {
                return text;
            }
        }

        public string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&bull;", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lsaquo;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&rsaquo;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&trade;", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&frasl;", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&lt;", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&gt;", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&copy;", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&reg;", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                return source;
            }
        }


    }

    internal static class cmnLibraryglobalModule
    {
        public static Int64 intSearchID;
        public static DataTable dtSearchItem;
        public static bool blnCancelStatus;

        public static void ResetValues()
        {
            // This will reset old initialized value
            intSearchID = 0;
            dtSearchItem = null;
            blnCancelStatus = false;
        }


    }





}