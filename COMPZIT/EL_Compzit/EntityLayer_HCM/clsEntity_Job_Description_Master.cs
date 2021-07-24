using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public  class clsEntity_Job_Description_Master
    {
        private int intOrgid = 0;
        private int intCorpOffice = 0;
        private int intUserId = 0;
        private int intDivId = 0;
        private int intDesgId = 0;
        private int intDeprt_Id = 0;
        private int intPayGradeId = 0;
        private int intRestrctLimit = 0;
        private int intPostnTyp = 0;
        private int intPostnRprtDesgId = 0;


        private int intJobDescrpId = 0;
        private int intcurrcyId = 0;
        private int intCancel_Status = 0;
        private int intAlownceId = 0;
        private int intDedctnId = 0;
        private int intMinExprnce = 0;
     

        private string strSummryPostn = "";
        private string strDesiredQual = "";
        private string strMandtrySkls = "";
        private string strEducation = "";
        private string strCertfcnTraing = "";
        private string strJobRspblty = "";
        private string strCancel_Reason = "";


    
        private DateTime ddate = new DateTime();



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
        public int JobDescrpId
        {
            get
            {
                return intJobDescrpId;
            }
            set
            {
                intJobDescrpId = value;
            }
        }

        public string JobRspblty
        {
            get
            {
                return strJobRspblty;
            }
            set
            {
                strJobRspblty = value;
            }
        }
        public int MinExprnce
        {
            get
            {
                return intMinExprnce;
            }
            set
            {
                intMinExprnce = value;
            }
        }
        public string CertfcnTraing
        {
            get
            {
                return strCertfcnTraing;
            }
            set
            {
                strCertfcnTraing = value;
            }
        }
        public string Education
        {
            get
            {
                return strEducation;
            }
            set
            {
                strEducation = value;
            }
        }
        public string MandtrySkls
        {
            get
            {
                return strMandtrySkls;
            }
            set
            {
                strMandtrySkls = value;
            }
        }
        public string DesiredQual
        {
            get
            {
                return strDesiredQual;
            }
            set
            {
                strDesiredQual = value;
            }
        }
        public string SummryPostn
        {
            get
            {
                return strSummryPostn;
            }
            set
            {
                strSummryPostn = value;
            }
        }
        public int PostnRprtDesgId
        {
            get
            {
                return intPostnRprtDesgId;
            }
            set
            {
                intPostnRprtDesgId = value;
            }
        }

        public int PostnTyp
        {
            get
            {
                return intPostnTyp;
            }
            set
            {
                intPostnTyp = value;
            }
        }
        public int PayGradeId
        {
            get
            {
                return intPayGradeId;
            }
            set
            {
                intPayGradeId = value;
            }
        }
        public int Deprt_Id
        {
            get
            {
                return intDeprt_Id;
            }
            set
            {
                intDeprt_Id = value;
            }
        }
        public int DesgId
        {
            get
            {
                return intDesgId;
            }
            set
            {
                intDesgId = value;
            }
        }
        public int DivId
        {
            get
            {
                return intDivId;
            }
            set
            {
                intDivId = value;
            }
        }
        public int Organisation_Id
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


        //Method for storing Corporate office id.
        public int CorpOffice_Id
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


        //Method for storing user id who do the event.
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
        //Method for storing the date when the event occurs.
        public DateTime D_Date
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
