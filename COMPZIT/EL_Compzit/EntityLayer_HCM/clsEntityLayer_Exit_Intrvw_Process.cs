using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public class clsEntityLayer_Exit_Intrvw_Process
    {
       private int intNextId = 0;
        private int intDesgId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intEmpId = 0;
        private int intInsId = 0;
        private int intCnfrmSts = 0;
        private int intSearchSts = 0;
        private DateTime dtInsDate;
        public int NextId
        {
            get { return intNextId; }
            set { intNextId = value; }
        }
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
        public int EmpId
        {
            get { return intEmpId; }
            set { intEmpId = value; }
        }
        public int InsId
        {
            get { return intInsId; }
            set { intInsId = value; }
        }
        public int CnfrmSts
        {
            get { return intCnfrmSts; }
            set { intCnfrmSts = value; }
        }
        public int SearchSts
        {
            get { return intSearchSts; }
            set { intSearchSts = value; }
        }
        public DateTime InsDate
        {
            get { return dtInsDate; }
            set { dtInsDate = value; }
        }
    }
   public class clsEntityLayer_Exit_Intrvw_Process_List
   {
      
       private string strQues = "";
       private int intQuesId = 0;
       
        public string Ques
        {
            get { return strQues; }
            set { strQues = value; }
        }
        public int QuesId
        {
            get { return intQuesId; }
            set { intQuesId = value; }
        }
   }
   
}
