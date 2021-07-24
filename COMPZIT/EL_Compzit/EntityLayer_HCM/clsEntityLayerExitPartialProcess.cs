using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityLayerExitPartialProcess
    {
        private int intOrgId = 0;
        private int intCorpId = 0;
        private int intUserId = 0;
        private int intExitProcdureID = 0;
        private int intStatus = 0;
        private DateTime dDate;
        private DateTime dAsgndDate=DateTime.MinValue;
        private DateTime dToDate = DateTime.MinValue;
        private int intEmpId = 0;
        private int intExitProcDtlID=0;
        private DateTime dateExpectedTargetDate = DateTime.MinValue;
        private int intMode=0;

        private int intFinishSts=0;

        public int FinishSts
        {
            get { return intFinishSts; }
            set { intFinishSts = value; }
        }

        public int Mode
        {
            get { return intMode; }
            set { intMode = value; }
        }


        public DateTime ExpectedTargetDate
        {
            get { return dateExpectedTargetDate; }
            set { dateExpectedTargetDate = value; }
        }
        public int ExitProcDtlID
        {
            get { return intExitProcDtlID; }
            set { intExitProcDtlID = value; }
        }
        

        private int intDesigID=0;

        public int DesigID
        {
            get { return intDesigID; }
            set { intDesigID = value; }
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

        public int ExitProcdureID
        {
            get
            {
                return intExitProcdureID;
            }
            set
            {
                intExitProcdureID = value;
            }
        }

        public int Status
        {
            get
            {
                return intStatus;
            }
            set
            {
                intStatus = value;
            }
        }

       

        public int LeaveDtlId
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

        public int EmpId
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



        public DateTime Date
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

        public DateTime AsgndDate
        {
            get
            {
                return dAsgndDate;
            }
            set
            {
                dAsgndDate = value;
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

    }
}
