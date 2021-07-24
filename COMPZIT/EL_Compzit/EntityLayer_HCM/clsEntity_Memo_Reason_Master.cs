using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Memo_Reason_Master
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intMemoId = 0;
        private int intMemoStatus = 0;
        private int intCnclStatus = 0;

        private string strMemoRsnName = "";
        private string strMemoDesc = "";
        private string strMemoCnclRsn = "";
        private DateTime UserDate;

        public int Organisation_id
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
        public int MemoId
        {
            get
            {
                return intMemoId;
            }
            set
            {
                intMemoId = value;
            }
        }

        public int MemoStatus
        {
            get
            {
                return intMemoStatus;
            }
            set
            {
                intMemoStatus = value;
            }
        }

        public int CnclStatus
        {
            get
            {
                return intCnclStatus;
            }
            set
            {
                intCnclStatus = value;
            }
        }
        public string MemoRsnName
        {
            get
            {
                return strMemoRsnName;
            }
            set
            {
                strMemoRsnName = value;
            }
        }
        public string MemoDesc
        {
            get
            {
                return strMemoDesc;
            }
            set
            {
                strMemoDesc = value;
            }
        }
        public string MemoCnclRsn
        {
            get
            {
                return strMemoCnclRsn;
            }
            set
            {
                strMemoCnclRsn = value;
            }
        }
        public DateTime MemoUserDate
        {
            get
            {
                return UserDate;
            }
            set
            {
                UserDate = value;
            }
        }
    }
}
