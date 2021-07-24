using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;

namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerTimeSheetReport
    {
        // This Method will fetch Employees
        public DataTable ReadEmployees(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            string strQueryReadEmployees = "AWMS_REPORTS.SP_READ_EMPLOYEES_DIV";
            OracleCommand cmdReadEmployees = new OracleCommand();
            cmdReadEmployees.CommandText = strQueryReadEmployees;
            cmdReadEmployees.CommandType = CommandType.StoredProcedure;
            cmdReadEmployees.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTimeSheetReport.User_Id;
            if (objEntityTimeSheetReport.DivisionId == 0)
            {
                cmdReadEmployees.Parameters.Add("T_CPRDIV_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadEmployees.Parameters.Add("T_CPRDIV_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.DivisionId;
            }
            cmdReadEmployees.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Organisation_id;
            cmdReadEmployees.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Corporate_id;
            cmdReadEmployees.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmployees = new DataTable();
            dtEmployees = clsDataLayer.ExecuteReader(cmdReadEmployees);
            return dtEmployees;
        }
        // This Method will fetch Division
        public DataTable ReadDivision(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            string strQueryReadDivision = "AWMS_REPORTS.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Organisation_id;
            cmdReadDivision.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Corporate_id;
            cmdReadDivision.Parameters.Add("S_USERID", OracleDbType.Int32).Value = objEntityTimeSheetReport.User_Id;
            cmdReadDivision.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }
        // This Method will fetch Department
        public DataTable ReadDepartment(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            string strQueryReadDepartment = "AWMS_REPORTS.SP_READ_DEPARTMENTS";
            OracleCommand cmdReadDepartment = new OracleCommand();
            cmdReadDepartment.CommandText = strQueryReadDepartment;
            cmdReadDepartment.CommandType = CommandType.StoredProcedure;
            cmdReadDepartment.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Organisation_id;
            cmdReadDepartment.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Corporate_id;
            cmdReadDepartment.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepartment = new DataTable();
            dtDepartment = clsDataLayer.ExecuteReader(cmdReadDepartment);
            return dtDepartment;
        }
        // This Method will fetch Report
        public DataTable ReadTimeSheetReport(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            string strQueryReadTimeSheetReport = "AWMS_REPORTS.SP_READ_TIME_SHEET_REPORT";
            OracleCommand cmdReadTimeSheetReport = new OracleCommand();
            cmdReadTimeSheetReport.CommandText = strQueryReadTimeSheetReport;
            cmdReadTimeSheetReport.CommandType = CommandType.StoredProcedure;
            cmdReadTimeSheetReport.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTimeSheetReport.User_Id;
            cmdReadTimeSheetReport.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Organisation_id;
            cmdReadTimeSheetReport.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Corporate_id;
            if (objEntityTimeSheetReport.DivisionId == 0)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_CPRDIV_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_CPRDIV_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.DivisionId;
            }
            if (objEntityTimeSheetReport.DepartmentId == 0)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_CPRDEPT_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_CPRDEPT_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.DepartmentId;
            }
            if (objEntityTimeSheetReport.EmployeeId == 0)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_EMP_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_EMP_ID", OracleDbType.Int32).Value = objEntityTimeSheetReport.EmployeeId;
            }
            if (objEntityTimeSheetReport.Date == DateTime.MinValue)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_DATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_DATE", OracleDbType.Date).Value = objEntityTimeSheetReport.Date;
            }
            if (objEntityTimeSheetReport.Month == "")
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_MONTH", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_MONTH", OracleDbType.Varchar2).Value = objEntityTimeSheetReport.Month;
            }
            if (objEntityTimeSheetReport.Quarter == 0)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_QUARTER", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_QUARTER", OracleDbType.Int32).Value = objEntityTimeSheetReport.Quarter;
            }
            if (objEntityTimeSheetReport.Year == 0)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_YEAR", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_S_YEAR", OracleDbType.Int32).Value = objEntityTimeSheetReport.Year;
            }
            if (objEntityTimeSheetReport.YearCommon == 0)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_COM_YEAR", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_COM_YEAR", OracleDbType.Int32).Value = objEntityTimeSheetReport.YearCommon;
            }
            if (objEntityTimeSheetReport.FromDate == DateTime.MinValue)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_FROM_DATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_FROM_DATE", OracleDbType.Date).Value = objEntityTimeSheetReport.FromDate;
            }
            if (objEntityTimeSheetReport.ToDate == DateTime.MinValue)
            {
                cmdReadTimeSheetReport.Parameters.Add("T_TO_DATE", OracleDbType.Date).Value = null;
            }
            else
            {
                cmdReadTimeSheetReport.Parameters.Add("T_TO_DATE", OracleDbType.Date).Value = objEntityTimeSheetReport.ToDate;
            }
            cmdReadTimeSheetReport.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTimeSheetReport = new DataTable();
            dtTimeSheetReport = clsDataLayer.ExecuteReader(cmdReadTimeSheetReport);
            return dtTimeSheetReport;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            string strQueryReadCorp = "AWMS_REPORTS.SP_READ_CORPORATE_ADDR";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Corporate_id;
            cmdReadCorp.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityTimeSheetReport.Organisation_id;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
    }
}
