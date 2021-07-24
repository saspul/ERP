using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerPayrollProcessReport
    {
        public DataTable ReadDepts(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryReadDepts = "PAYROLL_PROCESS_REPORT.SP_READ_DEPARTMENTS";
            OracleCommand cmdReadDepts = new OracleCommand();
            cmdReadDepts.CommandText = strQueryReadDepts;
            cmdReadDepts.CommandType = CommandType.StoredProcedure;
            cmdReadDepts.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.OrganizatonId;
            cmdReadDepts.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;
            cmdReadDepts.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepts = new DataTable();
            dtDepts = clsDataLayer.ExecuteReader(cmdReadDepts);
            return dtDepts;
        }
        public DataTable ReadDivision(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryReadDivision = "PAYROLL_PROCESS_REPORT.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.OrganizatonId;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;
            cmdReadDivision.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityPayroll_Report.DepartmentId;
            cmdReadDivision.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }
        public DataTable LoadBank(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryReadPayGrd = "PAYROLL_PROCESS_REPORT.SP_READ_BANK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadPayrollReport(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "PAYROLL_PROCESS_REPORT.SP_LOAD_REPORT";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.OrganizatonId;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;
            cmdPayrollReport.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityPayroll_Report.DepartmentId;
            cmdPayrollReport.Parameters.Add("P_MNTH", OracleDbType.Int32).Value = objEntityPayroll_Report.Month;
            cmdPayrollReport.Parameters.Add("P_YR", OracleDbType.Int32).Value = objEntityPayroll_Report.Year;
            cmdPayrollReport.Parameters.Add("P_BANK", OracleDbType.Int32).Value = objEntityPayroll_Report.Bank;
            cmdPayrollReport.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntityPayroll_Report.DivisionId;
            cmdPayrollReport.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdPayrollReport);
            return dtCategory;
        }
        public DataTable ReadCorporateAddress(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryReadCorp = "PAYROLL_PROCESS_REPORT.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.OrganizatonId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }


        //EVM-0027
        public DataTable ReadAllowanceDetails(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "PAYROLL_PROCESS_REPORT.SP_LOAD_ALLOWANCE";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.OrganizatonId;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;

            cmdPayrollReport.Parameters.Add("P_PROCESS", OracleDbType.Int32).Value = objEntityPayroll_Report.ProcessId;
            cmdPayrollReport.Parameters.Add("P_MNTH", OracleDbType.Int32).Value = objEntityPayroll_Report.Month;
            cmdPayrollReport.Parameters.Add("P_YR", OracleDbType.Int32).Value = objEntityPayroll_Report.Year;
          //  cmdPayrollReport.Parameters.Add("P_BANK", OracleDbType.Int32).Value = objEntityPayroll_Report.Bank;
          //  cmdPayrollReport.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntityPayroll_Report.DivisionId;
            cmdPayrollReport.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdPayrollReport);
            return dtCategory;
        }
        //END

        //EVM-0027
        public DataTable ReadDeductionDetails(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "PAYROLL_PROCESS_REPORT.SP_LOAD_DEDUCTION";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.OrganizatonId;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpId;

            cmdPayrollReport.Parameters.Add("P_PROCESS", OracleDbType.Int32).Value = objEntityPayroll_Report.ProcessId;
            cmdPayrollReport.Parameters.Add("P_MNTH", OracleDbType.Int32).Value = objEntityPayroll_Report.Month;
            cmdPayrollReport.Parameters.Add("P_YR", OracleDbType.Int32).Value = objEntityPayroll_Report.Year;
            //  cmdPayrollReport.Parameters.Add("P_BANK", OracleDbType.Int32).Value = objEntityPayroll_Report.Bank;
            //  cmdPayrollReport.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntityPayroll_Report.DivisionId;
            cmdPayrollReport.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdPayrollReport);
            return dtCategory;
        }
        //END
    }

}
