using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public  class clsEntityVisaQuotaStatusReport
    {
        private int intVisaQuotaId = 0;
        private string strVisaBndlNo = null;
        private DateTime dateIssue;
        private DateTime dateExpiry;
        private int intUserId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private DateTime dateFromDate = DateTime.MinValue;
        private DateTime dateToDate = DateTime.MinValue;
        private int intVisaDtlId = 0;
        private int intVisaTypId = 0;
        private int intCntryId = 0;
        private int intVisaNo = 0;
        private int intBussnsId = 0;
       
        private int intGender = 0;
       //EVM-0027
        private int intBusstatus = 0;
        private int intHrManager = 0;
        private int intAllDivision = 0;
        private int intNxtVisaId = 0;
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
        public int BussUnit
        {
            get
            {
                return intBusstatus;
            }
            set
            {
                intBusstatus = value;
            }
        }

        public int AllDivision
        {
            get
            {
                return intAllDivision;
            }
            set
            {
                intAllDivision = value;
            }
        }
        public int HrManager
        {
            get
            {
                return intHrManager;
            }
            set
            {
                intHrManager = value;
            }
        }
       //END
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
        public int VisaQuotaId
        {
            get
            {
                return intVisaQuotaId;
            }
            set
            {
                intVisaQuotaId = value;
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

        public string VisaBundleNo
        {
            get
            {
                return strVisaBndlNo;
            }
            set
            {
                strVisaBndlNo = value;
            }
        }


        public DateTime IssueDate
        {
            get
            {
                return dateIssue;
            }
            set
            {
                dateIssue = value;
            }
        }


        public DateTime ExpiryDate
        {
            get
            {
                return dateExpiry;
            }
            set
            {
                dateExpiry = value;
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

        public DateTime FrmDate
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

        public int VisaDtlId
        {
            get
            {
                return intVisaDtlId;
            }
            set
            {
                intVisaDtlId = value;
            }
        }

        public int VisaTypeId
        {
            get
            {
                return intVisaTypId;
            }
            set
            {
                intVisaTypId = value;
            }
        }

        public int CountryId
        {
            get
            {
                return intCntryId;
            }
            set
            {
                intCntryId = value;
            }
        }


        public int VisaNos
        {
            get
            {
                return intVisaNo;
            }
            set
            {
                intVisaNo = value;
            }
        }



    }
}
