using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Emp_Transfer
    {
        private int intUserId = 0;
        private DateTime dFromDate;
        private DateTime dTodate;
        private int intCorpId = 0;
        private int intOrgId = 0;
        private int intStatus = 0;
        private int intBusinesUnitId = 0;
        private int intBusinesUnitId_Old = 0;
        private int intEmployeeId = 0;
        private int intDepartmentId = 0;
        private int intTrans_Mode = 0;
        private int intTrans_Method = 0;
        private int intTrans_Type = 0;
        private int intDivisionId = 0;
        private int intReporterId = 0;
        private int intSponsorId = 0;
        private int intProjectId = 0;
        private int intPaygradeId = 0;
        private int intEmp_TrnsId = 0;
        private int intManPowerLinked = 0;
        private string strEmpId = "";
        private int intmanPOwerId = 0;
        private int intEmpType = 0;
        private int intDepartmentIdOld;
        private int intPaygradeIdOld;
        private int intDivisionIdOld;
        private int intSponsorIdOld;

        public int SponsorIdOld
        {
            get
            {
                return intSponsorIdOld;
            }
            set
            {
                intSponsorIdOld = value;
            }
        }
        public int DivisionIdOld
        {
            get
            {
                return intDivisionIdOld;
            }
            set
            {
                intDivisionIdOld = value;
            }
        }
        public int PaygradeIdOld
        {
            get
            {
                return intPaygradeIdOld;
            }
            set
            {
                intPaygradeIdOld = value;
            }
        }
        public int DepartmentIdOld
        {
            get
            {
                return intDepartmentIdOld;
            }
            set
            {
                intDepartmentIdOld = value;
            }
        }
        public int EmpType
        {
            get
            {
                return intEmpType;
            }
            set
            {
                intEmpType = value;
            }
        }
        public int manPOwerId
        {
            get
            {
                return intmanPOwerId;
            }
            set
            {
                intmanPOwerId = value;
            }
        }
        public int ManPowerLinked
        {
            get { return intManPowerLinked; }

            set { intManPowerLinked = value; }
        }
        public string EmpId
        {
            get { return strEmpId; }

            set { strEmpId = value; }
        }
        public DateTime FromDate
        {
            get { return dFromDate; }

            set { dFromDate = value; }
        }
        public DateTime Todate
        {
            get { return dTodate; }

            set { dTodate = value; }
        }
        public int BusinesUnitId_Old
        {
            get { return intBusinesUnitId_Old; }

            set { intBusinesUnitId_Old = value; }
        }
        public int Emp_TrnsId
        {
            get { return intEmp_TrnsId; }

            set { intEmp_TrnsId = value; }
        }
        public int PaygradeId
        {
            get { return intPaygradeId; }

            set { intPaygradeId = value; }
        }
        public int ProjectId
        {
            get { return intProjectId; }

            set { intProjectId = value; }
        }
        public int SponsorId
        {
            get { return intSponsorId; }

            set { intSponsorId = value; }
        }
        public int ReporterId
        {
            get { return intReporterId; }

            set { intReporterId = value; }
        }
        public int DivisionId
        {
            get { return intDivisionId; }

            set { intDivisionId = value; }
        }
        public int Trans_Type
        {
            get { return intTrans_Type; }

            set { intTrans_Type = value; }
        }
        public int Trans_Method
        {
            get { return intTrans_Method; }

            set { intTrans_Method = value; }
        }
        public int Trans_Mode
        {
            get { return intTrans_Mode; }

            set { intTrans_Mode = value; }
        }
        public int DepartmentId
        {
            get { return intDepartmentId; }

            set { intDepartmentId = value; }
        }
        public int EmployeeId
        {
            get { return intEmployeeId; }

            set { intEmployeeId = value; }
        }
        public int BusinesUnitId
        {
            get { return intBusinesUnitId; }

            set { intBusinesUnitId = value; }
        }
        public int UserId
        {
            get { return intUserId; }

            set { intUserId = value; }
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

        public int Status
        {

            get { return intStatus; }
            set { intStatus = value; }
        }

    }
}
