using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_FMS
{
    public class clsEntity_DayBook
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intmode = 0;
        private DateTime DtDate;
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
