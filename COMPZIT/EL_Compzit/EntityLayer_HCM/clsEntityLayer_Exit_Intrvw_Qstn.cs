using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit
{
   public class clsEntityLayer_Exit_Intrvw_Qstn
    {
        private int intDesgId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intInsUserId = 0;
        private int intCnclUserId = 0;
        private int intUpdUserId = 0;
        private int intSearchSts = 0;
        private string strCnclResn = "";
       
        private DateTime dateInsDate;
        private DateTime dateUpdDate;
        private DateTime dateCnclDate;
        public int DesgId
        {
            get { return intDesgId; }
            set { intDesgId = value; }
        }
        
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }
        public int OrgId
        {
            get { return intOrgId; }
            set { intOrgId = value; }
        }
        public int InsUserId
        {
            get { return intInsUserId; }
            set { intInsUserId = value; }
        }
        public int UpdUserId
        {
            get { return intUpdUserId; }
            set { intUpdUserId = value; }
        }
        public int CnclUserId
        {
            get { return intCnclUserId; }
            set { intCnclUserId = value; }
        }
        public int SearchSts
        {
            get { return intSearchSts; }
            set { intSearchSts = value; }
        }
        public DateTime InsDate
        {
            get { return dateInsDate; }
            set { dateInsDate = value; }
        }
        public string CnclResn
        {
            get { return strCnclResn; }
            set { strCnclResn = value; }
        }
        public DateTime UpdDate
        {
            get { return dateUpdDate; }
            set { dateUpdDate = value; }
        }
        public DateTime CnclDate
        {
            get { return dateCnclDate; }
            set { dateCnclDate = value; }
        }
    }
   public class clsEntityLayer_Exit_Intrvw_Qstn_List
   {
       private int intCommonSts = 0;
       private string strQuestion = "";
       private int intDtlId = 0;
       public string Questions
       {
           get { return strQuestion; }
           set { strQuestion = value; }
       }
       public int CommonSts
       {
           get { return intCommonSts; }
           set { intCommonSts = value; }
       }
       public int DtlId
       {
           get { return intDtlId; }
           set { intDtlId = value; }
       }
   }
}
