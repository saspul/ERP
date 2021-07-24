using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_Compzit.EntityLayer_HCM
{
    public class clsEntity_Emp_Welfare_Service
    {

        private int intOrgid = 0;
        private int intCorpId = 0;
        private int intUsrId = 0;
        private int intWelfareId = 0;
        private int intCatId = 0;
        private string strServiceName = "";
        private int intsts = 0;
        private DateTime dtFrom;
        private DateTime dtTo;
        private string strServiceDesc = "";
        private int intAllDesgn = 0;
        private int intAllDept = 0;
        private int intAllDiv = 0;
        private int intDivId = 0;
        private int intAllEmp = 0;
        private string strCnclRsn = "";
        private int intCancelStatus = 0;
        private int intDesignationId = 0;
        private int WelfareService_SubId = 0;
        public int Welfare_SubDtlId
        {
            get { return WelfareService_SubId; }
            set { WelfareService_SubId = value; }

        }
        public int DesignationId
        {
            get { return intDesignationId; }
            set { intDesignationId = value; }

        }
       
        public int WelfareServiceId
        {
            get { return intWelfareId; }
            set { intWelfareId = value; }

        }
        public int OrgId
        {
            get { return intOrgid; }
            set { intOrgid = value; }

        }
        public int CorpId
        {
            get { return intCorpId; }
            set { intCorpId = value; }
        }

        public int UserId
        {
            get { return intUsrId; }

            set { intUsrId = value; }
        }

        public DateTime FromPeriod
        {

            get { return dtFrom; }
            set { dtFrom = value; }
        }
        public DateTime ToPeriod
        {

            get { return dtTo; }
            set { dtTo = value; }
        }
        public int CategoryId
        {
            get { return intCatId; }

            set { intCatId = value; }
        }
        public string ServiceName
        {

            get { return strServiceName; }
            set { strServiceName = value; }
        }

        public string ServiceDescription
        {

            get { return strServiceDesc; }
            set { strServiceDesc = value; }
        }
        public int AllDesignation
        {

            get { return intAllDesgn; }
            set { intAllDesgn = value; }
        }
        public int AllDepartment
        {

            get { return intAllDept; }
            set { intAllDept = value; }
        }
        public int AllDivision
        {

            get { return intAllDiv; }
            set { intAllDiv = value; }
        }
        public int AllEmployee
        {

            get { return intAllEmp; }
            set { intAllEmp = value; }
        }

        public string CancelReason
        {

            get { return strCnclRsn; }
            set { strCnclRsn = value; }
        }
        public int Cancel_Status
        {
            get { return intCancelStatus; }
            set { intCancelStatus = value; }

        }
        public int Status
        {

            get { return intsts; }
            set { intsts = value; }
        }
    }
    public class clsEntity_Designation_list
    {
        private int intDesgnId = 0;
        private int intWelfareIdDsgn = 0;
        public int DesignationId
        {
            get { return intDesgnId; }
            set { intDesgnId = value; }
        }
        public int WelfareServiceDsgnId
        {
            get { return intWelfareIdDsgn; }
            set { intWelfareIdDsgn = value; }
        }
    }
    public class clsEntity_Department_list
    {
        private int intDeptId = 0;
        private int intWelfareIdDept = 0;

        public int DepartmentId
        {
            get { return intDeptId; }
            set { intDeptId = value; }
        }
        public int WelfareServiceId
        {
            get { return intWelfareIdDept; }
            set { intWelfareIdDept = value; }

        }
    }
    public class clsEntity_Division_list
    {
        private int intDivisionId = 0;
        private int intWelfareIdDivisn = 0;
        public int DivisionId
        {
            get { return intDivisionId; }
            set { intDivisionId = value; }
        }
        public int WelfareServiceId
        {
            get { return intWelfareIdDivisn; }
            set { intWelfareIdDivisn = value; }
        }
    }
     public class clsEntity_Employee_list
    {
        private int intEmpId = 0;
        private int intWelfareIdEmp = 0;
        public int EmployeeId
        {
            get { return intEmpId; }
            set { intEmpId = value; }
        }
        public int WelfareServiceId
        {
            get { return intWelfareIdEmp; }
            set { intWelfareIdEmp = value; }
        }
    }
     public class clsEntity_Welfare_Limit_list
     {
         private int WelfareService_SubId = 0;

         private decimal decQntity = 0;
         private int intUnit = 0;
         private int intFreq = 0;
         private int intMandatory = 0;
         private DateTime dtFrom;
         private DateTime dtTo;
         private int intCurrency = 0;
         private string strInsUpd = "";
         public decimal Quantity
         {
             get { return decQntity; }

             set { decQntity = value; }
         }
         public string InsUpd
         {
             get { return strInsUpd; }

             set { strInsUpd = value; }
         }
         public int Unit
         {
             get { return intUnit; }

             set { intUnit = value; }
         }
         public int Frequency
         {
             get { return intFreq; }

             set { intFreq = value; }
         }
         public int Mandatory
         {
             get { return intMandatory; }

             set { intMandatory = value; }
         }
       
         public DateTime FromPeriod
         {

             get { return dtFrom; }
             set { dtFrom = value; }
         }
         public DateTime ToPeriod
         {

             get { return dtTo; }
             set { dtTo = value; }
         }
         public int CurrencyId
         {
             get { return intCurrency; }
             set { intCurrency = value; }

         }
         public int Welfare_SubDtlId
         {
             get { return WelfareService_SubId; }
             set { WelfareService_SubId = value; }

         }
     }

}
