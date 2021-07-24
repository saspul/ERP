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
   public class clsDataLayerSalaryStatemnt
    {
       public DataTable LoadSalaryPrssListPrssTable(clsEntityLayerSalaryStatement objEntitySalary)
        {
            string strQueryReadPayGrd = "MONTHLY_SALARY_STATEMENT.SP_READ_LIST_FRMPRSSTABLE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_SAVECON", OracleDbType.Int32).Value = objEntitySalary.SavConf;
            cmdReadPayGrd.Parameters.Add("P_STFFWRKR", OracleDbType.Int32).Value = objEntitySalary.StffWrkr;
            cmdReadPayGrd.Parameters.Add("P_DEP", OracleDbType.Int32).Value = objEntitySalary.CorpOffice;
            if (objEntitySalary.date != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntitySalary.date;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntitySalary.Month;
            cmdReadPayGrd.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntitySalary.Year;
            cmdReadPayGrd.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntitySalary.CorpID;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntitySalary.Orgid;


            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadAllwnc(clsEntityLayerSalaryStatement objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_STATEMENT.SP_READ_ALLOWANC_PAYROLL";
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
        public DataTable ReadDedctn(clsEntityLayerSalaryStatement objEntityLeaveSettlmt)
        {
            string strQueryReadEmploy = "MONTHLY_SALARY_STATEMENT.SP_READ_DEDUCTION_PAYROLL";
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
        public DataTable ReadAllowanceDetails(clsEntityLayerSalaryStatement objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "MONTHLY_SALARY_STATEMENT.SP_LOAD_ALLOWANCE";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.Orgid;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpOffice;
            cmdPayrollReport.Parameters.Add("P_PROCESS", OracleDbType.Int32).Value = objEntityPayroll_Report.SalaryPrssId;
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
        public DataTable ReadDeductionDetails(clsEntityLayerSalaryStatement objEntityPayroll_Report)
        {
            string strQueryPayrollReport = "MONTHLY_SALARY_STATEMENT.SP_LOAD_DEDUCTION";
            OracleCommand cmdPayrollReport = new OracleCommand();
            cmdPayrollReport.CommandText = strQueryPayrollReport;
            cmdPayrollReport.CommandType = CommandType.StoredProcedure;
            cmdPayrollReport.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayroll_Report.Orgid;
            cmdPayrollReport.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayroll_Report.CorpOffice;

            cmdPayrollReport.Parameters.Add("P_PROCESS", OracleDbType.Int32).Value = objEntityPayroll_Report.SalaryPrssId;
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

        public DataTable ReadEmpManualy_Add_Dedn_Dtls(clsEntityLayerSalaryStatement objEntitySalary)
        {
            string strQueryUpdateStatus = "MONTHLY_SALARY_STATEMENT.SP_READ_MANL_ADD_DED";
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
    }
}
