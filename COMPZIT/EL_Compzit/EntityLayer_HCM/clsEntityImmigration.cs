using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityImmigration
    {
        private int intImgId = 0;
        private int intImgEmpId = 0;
        private int intTypeId = 0;
        private int intIssuedBy = 0;
        private int intVisatype = 0;
        private string strDocNo = "";
        private int intusrid = 0;
        private DateTime dDate;
        private DateTime issueDate;
        private DateTime expiryDate;
        private DateTime rvwDate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private string strDocName = "";
        private string strCOMMENTS = "";
        private string strAttachname = "";
        private string strDocStatus = "";
        private string strCanReasn = "";

        private string strCenterNum = "";

        public string CenterNum
        {
            get
            {
                return strCenterNum;
            }
            set
            {
                strCenterNum = value;
            }
        }
        public int Imig_Id
        {
            get
            {
                return intImgId;
            }
            set
            {
                intImgId = value;
            }
        }
        public string Imig_Doc_No
        {
            get
            {
                return strDocNo;
            }
            set
            {
                strDocNo = value;
            }
        }
        public int Imig_Emp_id
        {
            get
            {
                return intImgEmpId;
            }
            set
            {
                intImgEmpId = value;
            }
        }


          public int intVisaType
        {
            get
            {
                return intVisatype;
            }
            set
            {
                intVisatype = value;
            }
        }


        
        public int Imig_user_id
        {
            get
            {
                return intusrid;
            }
            set
            {
                intusrid = value;
            }
        }
        public int ImigDocType_Id
        {
            get
            {
                return intTypeId;
            }
            set
            {
                intTypeId = value;
            }
        }
        public int IssuedBy
        {
            get
            {
                return intIssuedBy;
            }
            set
            {
                intIssuedBy = value;
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
        
        public DateTime Imigdate
        {
            get
            {
                return dDate;
            }
            set
            {
                dDate = value;
            }
        }
                 public DateTime Imigissuedate
        {
            get
            {
                return issueDate;
            }
            set
            {
                issueDate = value;
            }
        }    
                 public DateTime Imigrvwdate
                 {
                     get
                     {
                         return rvwDate;
                     }
                     set
                     {
                         rvwDate = value;
                     }
                 }
                 public DateTime ImigExpdate
                 {
                     get
                     {
                         return expiryDate;
                     }
                     set
                     {
                         expiryDate = value;
                     }
                 } 
        public string ImigDocName
        {
            get
            {
                return strDocName;
            }
            set
            {
                strDocName = value;
            }
     
        }
        public string ImigComments
        {
            get
            {
                return strCOMMENTS;
            }
            set
            {
                strCOMMENTS = value;
            }
        }
      
        public string ImigAttachname
        {
            get
            {
                return strAttachname;
            }
            set
            {
                strAttachname = value;
            }
        }
        public string ImigStatus
        {
            get
            {
                return strDocStatus;
            }
            set
            {
                strDocStatus = value;
            }
        }
        public string ImigCancelREASON
        {
            get
            {
                return strCanReasn;
            }
            set
            {
                strCanReasn = value;
            }
        }
    }
}
