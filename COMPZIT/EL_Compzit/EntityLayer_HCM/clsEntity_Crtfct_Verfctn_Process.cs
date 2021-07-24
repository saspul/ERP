using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Crtfct_Verfctn_Process
    {



        private int intCertVerctnProcId = 0;
        private int intNextProcId = 0;
        private int intCandNameId = 0;

        private int intDesgRoleId = 0;
        private int intCancel_Status = 0;


        private DateTime Inetwdate;

        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUsrId = 0;
        private int intCrfct_sts = 0;

        private string strCancel_Reason = "";



        private DateTime ddate = new DateTime();


        public int Crfct_sts
        {
            get
            {
                return intCrfct_sts;
            }
            set
            {
                intCrfct_sts = value;
            }
        }
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
       
        public int NextProcId
        {
            get
            {
                return intNextProcId;
            }
            set
            {
                intNextProcId = value;
            }
        }
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

        public int UsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
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
        public int DesgRoleId
        {
            get
            {
                return intDesgRoleId;
            }
            set
            {
                intDesgRoleId = value;
            }
        }
        public int CertVerctnProcId
        {
            get
            {
                return intCertVerctnProcId;
            }
            set
            {
                intCertVerctnProcId = value;
            }
        }
        public int CandId
        {
            get
            {
                return intCandNameId;
            }
            set
            {
                intCandNameId = value;
            }
        }
    }
    public class clsEntity_Crtverfcn_Dtls
    {
        private int intCertVerctnProcIdDtl = 0;
        private int intCandNameId = 0;

        private int intDesgRoleId = 0;
        private int intVerctnProcIdDtlSts = 0;
        private int intVerctnProcIdDtlSubmit = 0;
        private int intVerctnProcIdDtlverify = 0;
        private DateTime Inetwrdate;

        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUsrId = 0;
        private int intDelOrNot = 0;
        private DateTime dDetaildate = new DateTime();

        private string intCertProcDtlName = "";
        private string intActualFileName = "";
        private string intFileName = "";


        public int DelOrNot
        {
            get
            {
                return intDelOrNot;
            }
            set
            {
                intDelOrNot = value;
            }
        }
        public string ActualFileName
        {
            get
            {
                return intActualFileName;
            }
            set
            {
                intActualFileName = value;
            }
        }
        public string FileName
        {
            get
            {
                return intFileName;
            }
            set
            {
                intFileName = value;
            }
        }
        public int Dtlverify
        {
            get
            {
                return intVerctnProcIdDtlverify;
            }
            set
            {
                intVerctnProcIdDtlverify = value;
            }
        }
        public int DtlSubmit
        {
            get
            {
                return intVerctnProcIdDtlSubmit;
            }
            set
            {
                intVerctnProcIdDtlSubmit = value;
            }
        }
        public int DtlSts
        {
            get
            {
                return intVerctnProcIdDtlSts;
            }
            set
            {
                intVerctnProcIdDtlSts = value;
            }
        }
        public DateTime Detaildate
        {
            get
            {
                return dDetaildate;
            }
            set
            {
                dDetaildate = value;
            }
        }
        public string CertProcDtlName
        {
            get
            {
                return intCertProcDtlName;
            }
            set
            {
                intCertProcDtlName = value;
            }
        }

        public int VerctnProcIdDtl
        {
            get
            {
                return intCertVerctnProcIdDtl;
            }
            set
            {
                intCertVerctnProcIdDtl = value;
            }
        }
        public int UsrId
        {
            get
            {
                return intUsrId;
            }
            set
            {
                intUsrId = value;
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
        public int DesgRoleId
        {
            get
            {
                return intDesgRoleId;
            }
            set
            {
                intDesgRoleId = value;
            }
        }
        public int CertVerctnProcId
        {
            get
            {
                return intCertVerctnProcIdDtl;
            }
            set
            {
                intCertVerctnProcIdDtl = value;
            }
        }
        public int CandId
        {
            get
            {
                return intCandNameId;
            }
            set
            {
                intCandNameId = value;
            }
        }



    }
}
