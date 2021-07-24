using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_visa_quota_info
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private string strBundleNum = "";
        private int intVisaTyp = 0;
        private int intCountryId = 0;
        private int intNumVisa = 0;
        private int intBussnsId = 0;
        private int intGender = 0;
        private int intNxtVisaId = 0;
        private int intCancel_Status = 0;
        private int intVisaDetailId = 0;
        private int intConfrmChkId = 0;
       
      
        private string strCancel_Reason = "";


        private DateTime dateExpiryDate;
        private DateTime dateIssueDate;
        private DateTime ddate = new DateTime();
        private DateTime dateFromDate = DateTime.MinValue;
        private DateTime dateToDate = DateTime.MinValue;

        public int ConfrmChkId
        {
            get
            {
                return intConfrmChkId;
            }
            set
            {
                intConfrmChkId = value;
            }
        }
        public DateTime FromDate
        {
            get
            {
                return dateFromDate;
            }
            set
            {
                dateFromDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dateToDate;
            }
            set
            {
                dateToDate = value;
            }
        }
        public int Orgid
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
        public int CorpOffice
        {
            get
            {
                return intCorpOffice;
            }
            set
            {
                intCorpOffice = value;
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
        public string BundleNum
        {
            get
            {
                return strBundleNum;
            }
            set
            {
                strBundleNum = value;
            }
        }
        public int VisaTyp
        {
            get
            {
                return intVisaTyp;
            }
            set
            {
                intVisaTyp = value;
            }
        }
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

        public int NumVisa
        {
            get
            {
                return intNumVisa;
            }
            set
            {
                intNumVisa = value;
            }
        }

        public int BussnsId
        {
            get
            {
                return intBussnsId;
            }
            set
            {
                intBussnsId = value;
            }
        }
        public int Gender
        {
            get
            {
                return intGender;
            }
            set
            {
                intGender = value;
            }
        }
        public int NxtVisaId
        {
            get
            {
                return intNxtVisaId;
            }
            set
            {
                intNxtVisaId = value;
            }
        }
        public int Cancel_Status
        {
            get
            {
                return intCancel_Status;
            }
            set
            {
                intCancel_Status = value;
            }
        }
        public int VisaDetailId
        {
            get
            {
                return intVisaDetailId;
            }
            set
            {
                intVisaDetailId = value;
            }
        }

        public string Cancel_Reason
        {
            get
            {
                return strCancel_Reason;
            }
            set
            {
                strCancel_Reason = value;
            }
        }

        public DateTime ExpiryDate
        {
            get
            {
                return dateExpiryDate;
            }
            set
            {
                dateExpiryDate = value;
            }
        }
        public DateTime IssueDate
        {
            get
            {
                return dateIssueDate;
            }
            set
            {
                dateIssueDate = value;
            }
        }
        public DateTime dateNow
        {
            get
            {
                return ddate;
            }
            set
            {
                ddate = value;
            }
        }
    }
}
