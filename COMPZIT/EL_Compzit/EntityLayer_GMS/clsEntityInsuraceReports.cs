using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsEntityInsuraceReports
/// </summary>
public class clsEntityInsuraceReports
{
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intDivisionId = 0;
        private string strFromDate = null;
        private string strToDate = null;
        private int intLeadStatus = 0;
        private int intQuotationStatus = 0;
        private int intInsurcatgryId = 0;
        private int intInsurTypeId = 0;
        private int intInsurModeId = 0;
        private int intProjctId = 0;
        private int intInsurExpiryModeId = 0;
        private int intTempId = 0;
        private int intLeadQtnId = 0;
        private DateTime dateExpiryRangeToDate = new DateTime();
        private DateTime dateExpiryRangeFromDate = new DateTime();
        private int intGroupId = 0;
        private string strGroupName = null;

        private DateTime dteLeadDate = DateTime.MinValue;
        private DateTime dteLeadTo = DateTime.MinValue;

        private int intCustomerId = 0;
        private string strCustname = null;
        private int intProjId = 0;
        private int intStatusId = 0;
        private int intEmpId = 0;

        private string strProjctId = "";
        private string strCustomerName = "";
        private int intLeadStsId = 0;

        private DateTime fDate = DateTime.MinValue;
        private DateTime lDate = DateTime.MinValue;


        private int intYear = 0;
        private string strMonth = null;
        private int intQuarter = 0;

        private int intSalesExecutiveId = 0;
        private int intBankId = 0;

        private int intCurncyId = 0;

        public int CurrencyId
        {
            get
            {
                return intCurncyId;
            }
            set
            {
                intCurncyId = value;
            }
        }

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

        public int SalesExecutiveId
        {
            get
            {
                return intSalesExecutiveId;
            }
            set
            {
                intSalesExecutiveId = value;
            }
        }

        public int Quarter
        {
            get
            {
                return intQuarter;
            }
            set
            {
                intQuarter = value;
            }
        }
        public string Month
        {
            get
            {
                return strMonth;
            }
            set
            {
                strMonth = value;
            }
        }
        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }
        //methode of storing the project id
        public int ProjctId
        {
            get
            {
                return intProjctId;
            }
            set
            {
                intProjctId = value;
            }
        }
        public int InsurCatgryId
        {
            get
            {
                return intInsurcatgryId;
            }
            set
            {
                intInsurcatgryId = value;
            }
        }
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

        //methode of storing corporate office id
        public int Corporate_Id
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

        //methode of storing the user id
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

        //methode of storing the division id
        public int Division_Id
        {
            get
            {
                return intDivisionId;
            }
            set
            {
                intDivisionId = value;
            }
        }

        //methode of storing from date
        public string From_Date
        {
            get
            {
                return strFromDate;
            }
            set
            {
                strFromDate = value;
            }
        }

        //methode of storing the to date
        public string To_Date
        {
            get
            {
                return strToDate;
            }
            set
            {
                strToDate = value;
            }
        }

        //methode of storing the lead status 
        public int Lead_Status
        {
            get
            {
                return intLeadStatus;
            }
            set
            {
                intLeadStatus = value;
            }

        }
        //method of storing the quotation status 
        public int Quotaion_Status
        {
            get
            {
                return intQuotationStatus;
            }
            set
            {
                intQuotationStatus = value;
            }

        }
        //method of storing the TypeId status 
        public int InsurTypeId
        {
            get
            {
                return intInsurTypeId;
            }
            set
            {
                intInsurTypeId = value;
            }

        }
        public int InsurModeId
        {
            get
            {
                return intInsurModeId;
            }
            set
            {
                intInsurModeId = value;
            }

        }
        public int InsurExpiryModeId
        {
            get
            {
                return intInsurExpiryModeId;
            }
            set
            {
                intInsurExpiryModeId = value;
            }

        }
        public DateTime InsurExpiryRangeTO
        {
            get
            {
                return dateExpiryRangeToDate;
            }
            set
            {
                dateExpiryRangeToDate = value;
            }

        }
        public DateTime InsurExpiryRangeFrom
        {
            get
            {
                return dateExpiryRangeFromDate;
            }
            set
            {
                dateExpiryRangeFromDate = value;
            }

        }

        public int InsurTempID
        {
            get
            {
                return intTempId;
            }
            set
            {
                intTempId = value;
            }

        }

        public int CustomerId
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
        public string Customername
        {
            get
            {
                return strCustname;
            }
            set
            {
                strCustname = value;
            }

        }
        public int ProjectId
        {
            get
            {
                return intProjId;
            }
            set
            {
                intProjId = value;
            }

        }
        public int StatusId
        {
            get
            {
                return intStatusId;
            }
            set
            {
                intStatusId = value;
            }

        }
        public int EmployeeId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }

        }
        public int LeadStsId
        {
            get
            {
                return intLeadStsId;
            }
            set
            {
                intLeadStsId = value;
            }
        }
        public string CustomerName
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
        public string ProjctName
        {
            get
            {
                return strProjctId;
            }
            set
            {
                strProjctId = value;
            }
        }
        public DateTime LeadDateTo
        {
            get
            {
                return dteLeadTo;
            }
            set
            {
                dteLeadTo = value;
            }

        }
        public DateTime LeadDate
        {
            get
            {
                return dteLeadDate;
            }
            set
            {
                dteLeadDate = value;
            }

        }
        public DateTime FDate
        {
            get
            {
                return fDate;
            }
            set
            {
                fDate = value;
            }
        }
        public DateTime LDate
        {
            get
            {
                return lDate;
            }
            set
            {
                lDate = value;
            }
        }
        public int LdQtnId
        {
            get
            {
                return intLeadQtnId;
            }
            set
            {
                intLeadQtnId = value;
            }
        }
        public int GroupId
        {
            get
            {
                return intGroupId;
            }
            set
            {
                intGroupId = value;
            }
        }
        public string GroupName
        {
            get
            {
                return strGroupName;
            }
            set
            {
                strGroupName = value;
            }
        }
}