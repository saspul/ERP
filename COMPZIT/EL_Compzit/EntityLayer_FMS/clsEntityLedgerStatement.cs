using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntityLedgerStatement
    {
        private int intCorpId = 0;
        private int intOrgId = 0;
        private DateTime dFrmDate;
        private DateTime dToDate;
        private int intMode = 0;
        private int intAccountGrpId = 0;
        private string strLedgerIds = "";
        private int intLedgerId = 0;
        private int intReferenceId = 0;
        private int intVoucherTyp = 0;
        private int intVoucherId = 0;
        //0039
        private int intVoucherAccId = 0;
        //end

        private int intLedgerFrom = 0;
        private int intLedgerTo = 0;

        private int intH1LedgerFrom = 0;
        private int intH1LedgerTo = 0;

        private int intH2LedgerFrom = 0;
        private int intH2LedgerTo = 0;

        private int intCCFrom = 0;
        private int intCCTo = 0;

        private int intAllLedgers = 0;
        private int intSubLedgerSts = 0;
        private int intCodeType = 0;
        private int intVoucherAccntId = 0;

        public int VoucherAccntId
        {
            get
            {
                return intVoucherAccntId;
            }
            set
            {
                intVoucherAccntId = value;
            }
        }
        public int CodeType
        {
            get
            {
                return intCodeType;
            }
            set
            {
                intCodeType = value;
            }
        }
        public int SubLedgerStatus
        {
            get
            {
                return intSubLedgerSts;
            }
            set
            {
                intSubLedgerSts = value;
            }
        }
        public int AllLedgersStatus
        {
            get
            {
                return intAllLedgers;
            }
            set
            {
                intAllLedgers = value;
            }
        }
        public int AccountGrpId
        {
            get
            {
                return intAccountGrpId;
            }
            set
            {
                intAccountGrpId = value;
            }
        }
        public int CCFromRange
        {
            get
            {
                return intCCFrom;
            }
            set
            {
                intCCFrom = value;
            }
        }
        public int CCToRange
        {
            get
            {
                return intCCTo;
            }
            set
            {
                intCCTo = value;
            }
        }
        public int H2LedgerFromRange
        {
            get
            {
                return intH2LedgerFrom;
            }
            set
            {
                intH2LedgerFrom = value;
            }
        }
        public int H2LedgerToRange
        {
            get
            {
                return intH2LedgerTo;
            }
            set
            {
                intH2LedgerTo = value;
            }
        }
        public int H1LedgerFromRange
        {
            get
            {
                return intH1LedgerFrom;
            }
            set
            {
                intH1LedgerFrom = value;
            }
        }
        public int H1LedgerToRange
        {
            get
            {
                return intH1LedgerTo;
            }
            set
            {
                intH1LedgerTo = value;
            }
        }
        public int LedgerFromRange
        {
            get
            {
                return intLedgerFrom;
            }
            set
            {
                intLedgerFrom = value;
            }
        }
        public int LedgerToRange
        {
            get
            {
                return intLedgerTo;
            }
            set
            {
                intLedgerTo = value;
            }
        }
        public int VoucherId
        {
            get
            {
                return intVoucherId;
            }
            set
            {
                intVoucherId = value;
            }
        }

        //0039
        public int VoucherAccId
        {
            get
            {
                return intVoucherAccId;
            }
            set
            {
                intVoucherAccId = value;
            }
        }
        //end
        public int VoucherTyp
        {
            get
            {
                return intVoucherTyp;
            }
            set
            {
                intVoucherTyp = value;
            }
        }
        public int ReferenceId
        {
            get
            {
                return intReferenceId;
            }
            set
            {
                intReferenceId = value;
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
        public DateTime FromDate
        {
            get
            {
                return dFrmDate;
            }
            set
            {
                dFrmDate = value;
            }
        }
        public DateTime ToDate
        {
            get
            {
                return dToDate;
            }
            set
            {
                dToDate = value;
            }
        }
        public int Mode
        {
            get
            {
                return intMode;
            }
            set
            {
                intMode = value;
            }
        }
        public string LedgerIds
        {
            get
            {
                return strLedgerIds;
            }
            set
            {
                strLedgerIds = value;
            }
        }
        public int Ledger
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

    }
}
