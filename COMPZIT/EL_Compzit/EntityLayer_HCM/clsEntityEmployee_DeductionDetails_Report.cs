using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
   public  class clsEntityEmployee_DeductionDetails_Report
    {
        private long intEmpDedctnId = 0;
        private string strReferenceno = "";
        private string strRemarks = "";
        private int intEmpId = 0;
        private int intDedctnMstrId = 0;
        private double intamount = 0;
        private int intInstalmntno = 0;
        private int intInstalmntplanid = 0;
        private long intDocno = 0;
        private int intApprovalstats2 = 0;
        private int intApprvlUserId = 0;
        private int intRoleId = 0;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intDeptId = 0;
        private int intApprvlUserId1 = 0;
        private int intApprvlUserId2 = 0;
        private int intAppStatus = 1;
        private int intConfrmStatus = 0;
        private DateTime EffctveDte;
        private DateTime Instlmntdate;
        private double Instlmntamount;
        private DateTime Instlmnpaiddate;
        private double Instlmnpaidamount;
        private int intMode = 0;
        private int intdivisionId = 0;
        private int intdesgId = 0;
        private int inttype = 0;
        public int divisionId
        {
            get
            {
                return intdivisionId;
            }
            set
            {
                intdivisionId = value;
            }
        }
        public int desgId
        {
            get
            {
                return intdesgId;
            }
            set
            {
                intdesgId = value;
            }
        }
        public int type
        {
            get
            {
                return inttype;
            }
            set
            {
                inttype = value;
            }
        }
        public int DeptId
        {
            get
            {
                return intDeptId;
            }
            set
            {
                intDeptId = value;
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
        public DateTime EffectiveDate
        {
            get
            {
                return EffctveDte;
            }
            set
            {
                EffctveDte = value;
            }
        }
        public double TotLPaid
        {
            get
            {
                return Instlmnpaidamount;
            }
            set
            {
                Instlmnpaidamount = value;
            }
        }
        public double InstallmentAmount
        {
            get
            {
                return Instlmntamount;
            }
            set
            {
                Instlmntamount = value;
            }
        }
        public DateTime InstallmentDate
        {
            get
            {
                return Instlmntdate;
            }
            set
            {
                Instlmntdate = value;
            }
        }
        public DateTime PaidDate
        {
            get
            {
                return Instlmnpaiddate;
            }
            set
            {
                Instlmnpaiddate = value;
            }
        }

        public long EmployeeDeductionID
        {
            get
            {
                return intEmpDedctnId;
            }
            set
            {
                intEmpDedctnId = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return intEmpId;
            }
            set
            {
                intEmpId = value;
            }
        }
        public string Reference_Number
        {
            get
            {
                return strReferenceno;
            }
            set
            {
                strReferenceno = value;
            }
        }
        public int DeductionId
        {
            get
            {
                return intDedctnMstrId;
            }
            set
            {
                intDedctnMstrId = value;
            }
        }
        public double Amount
        {
            get
            {
                return intamount;
            }
            set
            {
                intamount = value;
            }
        }
        public int InstallementNo
        {
            get
            {
                return intInstalmntno;
            }
            set
            {
                intInstalmntno = value;
            }
        }
        public int InstallementPlan
        {
            get
            {
                return intInstalmntplanid;
            }
            set
            {
                intInstalmntplanid = value;
            }
        }
        public String Remarks
        {
            get
            {
                return strRemarks;
            }
            set
            {
                strRemarks = value;
            }
        }
        public int Confirm_Status
        {
            get
            {
                return intConfrmStatus;
            }
            set
            {
                intConfrmStatus = value;
            }
        }




        //Method of storing userid of the person who do the process.
        public int UserId
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


        //Method for storing Corporation office id.
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
        public int orgid
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
        public long Documentno
        {
            get
            {
                return intDocno;
            }
            set
            {
                intDocno = value;
            }
        }


    }
}
