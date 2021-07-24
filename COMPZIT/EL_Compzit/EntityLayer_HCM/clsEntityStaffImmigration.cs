using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
  public class clsEntityStaffImmigration
    {
        private int intStaffImgId = 0;
        private int intCandId = 0;
        private int intTypeId = 0;
        private int intIssuedBy = 0;
        private int intVisatypeId = 0;
        private string strVisaNo = "";
        private int intusrid = 0;
        private int intempid = 0;
        private DateTime dDate;
        private DateTime VisaexpiryDate;
        private DateTime PassexpiryDate;
        private DateTime UserinsDate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private string strPassNo = "";
        private string strCOMMENTS = "";
        private string strAttachname = "";
        private string strDocStatus = "";
        private string strCanReasn = "";

        public int StaffImig_Id
        {
            get
            {
                return intStaffImgId;
            }
            set
            {
                intStaffImgId = value;
            }
        }
        public string VisaNo
        {
            get
            {
                return strVisaNo;
            }
            set
            {
                strVisaNo = value;
            }
        }
        public int CandId
        {
            get
            {
                return intCandId;
            }
            set
            {
                intCandId = value;
            }
        }


          public int intVisaTypeID
        {
            get
            {
                return intVisatypeId;
            }
            set
            {
                intVisatypeId = value;
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
        public int Imig_Emp_id
        {
            get
            {
                return intempid;
            }
            set
            {
                intempid = value;
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
        public DateTime VisaExpDate
        {
            get
            {
                return VisaexpiryDate;
            }
            set
            {
                VisaexpiryDate = value;
            }
        }    
                 public DateTime UsrInsdate
                 {
                     get
                     {
                         return UserinsDate;
                     }
                     set
                     {
                         UserinsDate = value;
                     }
                 }
                 public DateTime PassExpDate
                 {
                     get
                     {
                         return PassexpiryDate;
                     }
                     set
                     {
                         PassexpiryDate = value;
                     }
                 } 
        public string PassNo
        {
            get
            {
                return strPassNo;
            }
            set
            {
                strPassNo = value;
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
