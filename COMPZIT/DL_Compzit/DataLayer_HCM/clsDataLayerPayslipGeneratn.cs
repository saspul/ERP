using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerPayslipGeneratn
    {

        public DataTable ReadEmployeeDtls(clsEntityLayerPayslipGeneratn objEntityPayslip)
        {
            string strQueryReadPayslip = "PAYSLIP_GENERATION.SP_READ_EMPLOYEE_DTLS";
            OracleCommand cmdReadPayslip = new OracleCommand();
            cmdReadPayslip.CommandText = strQueryReadPayslip;
            cmdReadPayslip.CommandType = CommandType.StoredProcedure;
            cmdReadPayslip.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityPayslip.UserId;
            cmdReadPayslip.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtPayslip = new DataTable();
            dtPayslip = clsDataLayer.ExecuteReader(cmdReadPayslip);
            return dtPayslip;
        }

        public DataTable ReadDivisn(clsEntityLayerPayslipGeneratn objEntityPayslip)
        {
            string strQueryReadPayslip = "PAYSLIP_GENERATION.SP_READ_DIVISION";
            OracleCommand cmdReadPayslip = new OracleCommand();
            cmdReadPayslip.CommandText = strQueryReadPayslip;
            cmdReadPayslip.CommandType = CommandType.StoredProcedure;
            cmdReadPayslip.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityPayslip.UserId;
            cmdReadPayslip.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtPayslip = new DataTable();
            dtPayslip = clsDataLayer.ExecuteReader(cmdReadPayslip);
            return dtPayslip;
        }

        public DataTable ReadProcessdEmployees(clsEntityLayerPayslipGeneratn objEntityPayslip)
        {
            string strQueryReadPayslip = "PAYSLIP_GENERATION.SP_READ_SLRYPRCSD_EMP";
            OracleCommand cmdReadPayslip = new OracleCommand();
            cmdReadPayslip.CommandText = strQueryReadPayslip;
            cmdReadPayslip.CommandType = CommandType.StoredProcedure;
            cmdReadPayslip.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityPayslip.UserId;
            cmdReadPayslip.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityPayslip.Month;
            cmdReadPayslip.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityPayslip.Year;
            cmdReadPayslip.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtPayslip = new DataTable();
            dtPayslip = clsDataLayer.ExecuteReader(cmdReadPayslip);
            return dtPayslip;
        }


    }
}
