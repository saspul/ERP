using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class cls_EntityCustomer_Outstanding
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intmode = 0;
        private int intLedgerId = 0;
        private DateTime DtDate;
        private DateTime FinStartDate;
        private DateTime FinEndDate;
        private string strPrimaryGrpIds = "";
        public string PrimaryGrpIds
        {
            get
            {
                return strPrimaryGrpIds;
            }
            set
            {
                strPrimaryGrpIds = value;
            }
        }
        public DateTime FinancialStartDate
        {
            get
            {
                return FinStartDate;
            }
            set
            {
                FinStartDate = value;
            }
        }

        public DateTime FinancialEndDate
        {
            get
            {
                return FinEndDate;
            }
            set
            {
                FinEndDate = value;
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
        public int Ledger_id
        {
            get
            {
                return intLedgerId;
            }
            set
            {
                intLedgerId = value;
            }
        }
        public int Corporate_id
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
        public int TransactionType
        {
            get
            {
                return intmode;
            }
            set
            {
                intmode = value;
            }
        }
        public DateTime DayBook_Date
        {
            get
            {
                return DtDate;
            }
            set
            {
                DtDate = value;
            }
        }
    }
}
