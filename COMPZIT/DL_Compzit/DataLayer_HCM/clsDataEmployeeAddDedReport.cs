using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataEmployeeAddDedReport
    {

        public DataTable LoadDepartment(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_DEPARTMENT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadDivison(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_DIVISION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadJob(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_JOB";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadDesignation(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_DESIGNATION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadAddition(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_ADDITION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadDeduction(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_DEDUCTION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadEmployee(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_EMPLOYEE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            if (objEntityBulkPrint.DepartmentIds != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionIds != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DesignationIds != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DesignationIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryFirst(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_SUMMARY_FIRST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            if (objEntityBulkPrint.Months != "" && objEntityBulkPrint.Months != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Months;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentIds != "" && objEntityBulkPrint.DepartmentIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionIds != "" && objEntityBulkPrint.DivisionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DesignationIds != "" && objEntityBulkPrint.DesignationIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DesignationIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.EmployeeIds != "" && objEntityBulkPrint.EmployeeIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.EmployeeIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.AdditionIds != "" && objEntityBulkPrint.AdditionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.AdditionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DeductionIds != "" && objEntityBulkPrint.DeductionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DeductionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryFirstMtdTwo(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_SUMMARY_FIRST_MTD2";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            if (objEntityBulkPrint.Months != "" && objEntityBulkPrint.Months != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Months;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentIds != "" && objEntityBulkPrint.DepartmentIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionIds != "" && objEntityBulkPrint.DivisionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DesignationIds != "" && objEntityBulkPrint.DesignationIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DesignationIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.EmployeeIds != "" && objEntityBulkPrint.EmployeeIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.EmployeeIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.AdditionIds != "" && objEntityBulkPrint.AdditionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.AdditionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DeductionIds != "" && objEntityBulkPrint.DeductionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DeductionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummarySecond(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_SUMMARY_SECOND";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            if (objEntityBulkPrint.Months != "" && objEntityBulkPrint.Months != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Months;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentIds != "" && objEntityBulkPrint.DepartmentIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionIds != "" && objEntityBulkPrint.DivisionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DesignationIds != "" && objEntityBulkPrint.DesignationIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DesignationIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.EmployeeIds != "" && objEntityBulkPrint.EmployeeIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.EmployeeIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.AdditionIds != "" && objEntityBulkPrint.AdditionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.AdditionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DeductionIds != "" && objEntityBulkPrint.DeductionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DeductionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            cmdReadPayGrd.Parameters.Add("P_QUERY_COLS", OracleDbType.Varchar2).Value = objEntityBulkPrint.QueryColumns;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryThird(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_SUMMARY_THIRD";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            if (objEntityBulkPrint.Months != "" && objEntityBulkPrint.Months != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Months;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentIds != "" && objEntityBulkPrint.DepartmentIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionIds != "" && objEntityBulkPrint.DivisionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DesignationIds != "" && objEntityBulkPrint.DesignationIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DesignationIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.EmployeeIds != "" && objEntityBulkPrint.EmployeeIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.EmployeeIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.AdditionIds != "" && objEntityBulkPrint.AdditionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.AdditionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DeductionIds != "" && objEntityBulkPrint.DeductionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DeductionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            cmdReadPayGrd.Parameters.Add("P_QUERY_COLS", OracleDbType.Varchar2).Value = objEntityBulkPrint.QueryColumns;
            cmdReadPayGrd.Parameters.Add("P_BA_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.BAids;
            cmdReadPayGrd.Parameters.Add("P_BD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.BDids;
            cmdReadPayGrd.Parameters.Add("P_MA_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.MAids;
            cmdReadPayGrd.Parameters.Add("P_MD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.MDids;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryThirdGrp(clsEntityEmployeeAddDedReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "EMPLOYEE_ADD_DED_REPORT.SP_READ_SUMMARY_THIRD_GRP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityBulkPrint.Year;
            if (objEntityBulkPrint.Months != "" && objEntityBulkPrint.Months != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Months;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_MONTH_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentIds != "" && objEntityBulkPrint.DepartmentIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPT_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionIds != "" && objEntityBulkPrint.DivisionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIV_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DesignationIds != "" && objEntityBulkPrint.DesignationIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DesignationIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DESG_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.EmployeeIds != "" && objEntityBulkPrint.EmployeeIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.EmployeeIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_EMP_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.AdditionIds != "" && objEntityBulkPrint.AdditionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.AdditionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_ADD_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DeductionIds != "" && objEntityBulkPrint.DeductionIds != "null")
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.DeductionIds;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DED_IDS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY_ID", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            cmdReadPayGrd.Parameters.Add("P_QUERY_COLS", OracleDbType.Varchar2).Value = objEntityBulkPrint.QueryColumns;
            cmdReadPayGrd.Parameters.Add("P_BA_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.BAids;
            cmdReadPayGrd.Parameters.Add("P_BD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.BDids;
            cmdReadPayGrd.Parameters.Add("P_MA_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.MAids;
            cmdReadPayGrd.Parameters.Add("P_MD_IDS", OracleDbType.Varchar2).Value = objEntityBulkPrint.MDids;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
    }
}
