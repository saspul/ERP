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
   public class clsDataLayerMonthlySalaryStatement
    {
        public DataTable LoadSalaryPrssListPrssTable(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_LIST_FRMPRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntitySalary.PendFinshId;
            cmdReadPayGrd.Parameters.Add("P_STFFWRKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
            cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntitySalary.CorpID;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadSalaryPrssListPrssTableDept(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_LIST_FRMPRSSTABLE_DEPT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntitySalary.PendFinshId;
            cmdReadPayGrd.Parameters.Add("P_STFFWRKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
            cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntitySalary.CorpID;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadAllwnc(clsEntityMonthlySalaryStatement objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_ALLOWANC_PAYROLL";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpID;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadDedctn(clsEntityMonthlySalaryStatement objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_DEDUCTION_PAYROLL";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Orgid;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpID;
            cmdReadEmp.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //EVM-0027
        public DataTable ReadAllowanceDetails(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "MONTHLY_SALARY_STATEMENT_ALL.SP_LOAD_ALLOWANCE";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.Orgid;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpID;
            cmdPayrollReport.Parameters.Add("P_PROCESS", OracleDbType.Int32).Value = objEntityPayroll_Report.SalaryPrssId;
            cmdPayrollReport.Parameters.Add("P_PAGE", OracleDbType.Int32).Value = objEntityPayroll_Report.SavConf;
            cmdPayrollReport.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityPayroll_Report.Employee;
            cmdPayrollReport.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityPayroll_Report.Month;
            cmdPayrollReport.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityPayroll_Report.Year;
            cmdPayrollReport.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdPayrollReport);
            return dtCategory;
        }
        //END

        //EVM-0027
        public DataTable ReadDeductionDetails(clsEntityMonthlySalaryStatement objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "MONTHLY_SALARY_STATEMENT_ALL.SP_LOAD_DEDUCTION";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.Orgid;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpID;
            cmdPayrollReport.Parameters.Add("P_PROCESS", OracleDbType.Int32).Value = objEntityPayroll_Report.SalaryPrssId;
            cmdPayrollReport.Parameters.Add("P_PAGE", OracleDbType.Int32).Value = objEntityPayroll_Report.SavConf;
            cmdPayrollReport.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntityPayroll_Report.Employee;
            cmdPayrollReport.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityPayroll_Report.Month;
            cmdPayrollReport.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityPayroll_Report.Year;
            cmdPayrollReport.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdPayrollReport);
            return dtCategory;
        }
        //END

        public DataTable ReadEmpManualy_Add_Dedn_Dtls(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            string strQueryUpdateStatus = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_MANL_ADD_DED";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = strQueryUpdateStatus;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
                cmd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
                cmd.Parameters.Add("P_EMP", OracleDbType.Int32).Value = objEntitySalary.Employee;
                cmd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
                cmd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
                cmd.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmp = new DataTable();
                dtEmp = clsDataLayer.ExecuteReader(cmd);
                return dtEmp;
            }
        }
        public DataTable LoadMonthlySalList(clsEntityMonthlySalaryStatement objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_MONTHLYSAL_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_PENDFINSH", OracleDbType.Int32).Value = objEntitySalary.PendFinshId;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntitySalary.Mode;
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadOTctgries(clsEntityMonthlySalaryStatement objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_OT_CTGRY";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.CorpID;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Orgid;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
        public DataTable ReadOTdtls(clsEntityMonthlySalaryStatement objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_STATEMENT_ALL.SP_READ_OT_DTLS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLeaveSettlmt.Employee;
            cmdReadEmp.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.date;
            cmdReadEmp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLeaveSettlmt.CurrentDate;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }
    }
}

