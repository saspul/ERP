using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerEmployeeDetailsReport
    {
        public DataTable ReadEmployeeList(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadCntrctCatgry = "EMPLOYEE_DETAILS_REPORT.SP_READ_EMPLOYEE_LIST";
            OracleCommand cmdReadCntrctCatgry = new OracleCommand();
            cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
            cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCatgry.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
            cmdReadCntrctCatgry.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
            cmdReadCntrctCatgry.Parameters.Add("E_DESG_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.DesignationId;
            cmdReadCntrctCatgry.Parameters.Add("E_DEPT_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.DepartmentId;
            cmdReadCntrctCatgry.Parameters.Add("E_DIVSN_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.DivisionId;
            cmdReadCntrctCatgry.Parameters.Add("E_PRJCT_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.ProjectId;
            cmdReadCntrctCatgry.Parameters.Add("E_RELGN_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.ReligionId;
            cmdReadCntrctCatgry.Parameters.Add("E_GENDER_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.GenderId;
            cmdReadCntrctCatgry.Parameters.Add("E_NOYEAR_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.NumOfYears;
            cmdReadCntrctCatgry.Parameters.Add("E_GRADE_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.GradeId;
            cmdReadCntrctCatgry.Parameters.Add("E_AGE_FROM", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.AgeFrom;
            cmdReadCntrctCatgry.Parameters.Add("E_AGE_TO", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.AgeTo;
            cmdReadCntrctCatgry.Parameters.Add("E_STS_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.StatusId;
            cmdReadCntrctCatgry.Parameters.Add("E_CNTRY_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.NationalityId;
            cmdReadCntrctCatgry.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
            return dtCategory;
        }

        public DataTable ReadDivisionOfEmp(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadCntrctCatgry = "EMPLOYEE_DETAILS_REPORT.SP_READ_DIVISIONS_EMP";
            OracleCommand cmdReadCntrctCatgry = new OracleCommand();
            cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
            cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCatgry.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
            cmdReadCntrctCatgry.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
            return dtCategory;
        }
        public DataTable ReadProject(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_PROJECT";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
                cmdReadProj.Parameters.Add("E_DIV_ID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.DivisionId;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDivision(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_DIVISION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable readCountry()
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_COUNTRY";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDesignation(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_DESIGNATION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadDepartment(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_DEPARTMENT";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }

        public DataTable ReadPaygrade(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_PAYGRADE";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable readReligion()
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_RELIGION";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadEmpDetailsById(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_EMP_DTLS_BYID";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
                cmdReadProj.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public DataTable ReadProjectDetails(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_EMP_PRJCT";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmployeeDetailsreport.date;            
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }

        public DataTable ReadCorporateAddress(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadCorp = "EMPLOYEE_DETAILS_REPORT.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.OrganisationId;
            cmdReadCorp.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.Corporate_id;
            cmdReadCorp.Parameters.Add("E_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable ReadLeave(clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport)
        {
            string strQueryReadProj = "EMPLOYEE_DETAILS_REPORT.SP_READ_EMP_LEAVE";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;
                cmdReadProj.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntityEmployeeDetailsreport.UserId;
                cmdReadProj.Parameters.Add("E_DATE", OracleDbType.Date).Value = objEntityEmployeeDetailsreport.date;
                cmdReadProj.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
    }
}
