using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntityPayrollProcess
    {
        private int intCorpId = 0;
        private int intDept = 0;
        private int intDiv = 0;
        private int intOrgId = 0;
        private int intUserId = 0;
        private int intmonth = 0;
        private int intYear = 0;
        private int intBank = 0;
        //evm-0027

        private int intProcessID = 0;
        private int intEmpid = 0;

        public int ProcessId
        {
            get
            {
                return intProcessID;
            }
            set
            {
                intProcessID = value;
            }
        }

        public int EmployeeId
        {
            get
            {
                return intEmpid;
            }
            set
            {
                intEmpid = value;
            }
        }
        //end

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
        public int DepartmentId
        {
            get
            {
                return intDept;
            }
            set
            {
                intDept = value;
            }
        }
        public int DivisionId
        {
            get
            {
                return intDiv;
            }
            set
            {
                intDiv = value;
            }
        }
        public int OrganizatonId
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
        public int Month
        {
            get
            {
                return intmonth;
            }
            set
            {
                intmonth = value;
            }
        }
        public int Year
        {
            get
            {
                return intYear;
            }
            set
            {
                intYear = value;
            }
        }
        public int Bank
        {
            get
            {
                return intBank;
            }
            set
            {
                intBank = value;
            }
        }
    }
}
