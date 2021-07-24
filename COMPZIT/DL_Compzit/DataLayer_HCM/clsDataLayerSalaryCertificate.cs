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
    public class clsDataLayerSalaryCertificate
    {

        public DataTable ReadEmployeeDtls(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_READ_EMPLOYEE_DTLS";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.EmployeeId;
            cmdReadSalary.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalary = new DataTable();
            dtSalary = clsDataLayer.ExecuteReader(cmdReadSalary);
            return dtSalary;
        }

        public DataTable ReadBasicPay(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_READ_BASIC_PAY";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.EmployeeId;
            cmdReadSalary.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalary = new DataTable();
            dtSalary = clsDataLayer.ExecuteReader(cmdReadSalary);
            return dtSalary;
        }

        public DataTable ReadAllowance(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_READ_ALLOWANCE";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.EmployeeId;
            cmdReadSalary.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalary = new DataTable();
            dtSalary = clsDataLayer.ExecuteReader(cmdReadSalary);
            return dtSalary;
        }

        public DataTable ReadDivision(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_READ_DIVISION";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.EmployeeId;
            cmdReadSalary.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalary = new DataTable();
            dtSalary = clsDataLayer.ExecuteReader(cmdReadSalary);
            return dtSalary;
        }

        public void InsertSalaryCertfctRequest(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_INSERT_CERTFCT_REQUEST";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.EmployeeId;
            cmdReadSalary.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.CorpId;
            cmdReadSalary.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySalaryCertfct.OrgId;
            cmdReadSalary.Parameters.Add("C_BASIC_PAY_AMT", OracleDbType.Decimal).Value = objEntitySalaryCertfct.BasicPay;
            cmdReadSalary.Parameters.Add("C_ALLOWANCE_AMT", OracleDbType.Decimal).Value = objEntitySalaryCertfct.Allowance;
            cmdReadSalary.Parameters.Add("C_CONFRMSTS", OracleDbType.Int32).Value = objEntitySalaryCertfct.ConfirmSts;
            cmdReadSalary.Parameters.Add("C_REASN", OracleDbType.Varchar2).Value = objEntitySalaryCertfct.Reason;
            cmdReadSalary.Parameters.Add("C_INS_USR_ID", OracleDbType.Int32).Value = objEntitySalaryCertfct.UserId;
            cmdReadSalary.Parameters.Add("C_INS_DATE", OracleDbType.Date).Value = objEntitySalaryCertfct.Date;
            clsDataLayer.ExecuteNonQuery(cmdReadSalary);
        }

        public DataTable ReadSalaryCertfctReqsts(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_READ_SALARY_CERTFCT_REQSTS";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.CorpId;
            cmdReadSalary.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySalaryCertfct.OrgId;
            cmdReadSalary.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntitySalaryCertfct.CancelSts;
            cmdReadSalary.Parameters.Add("C_APPROVE_STS", OracleDbType.Int32).Value = objEntitySalaryCertfct.HRApprovalSts;
            cmdReadSalary.Parameters.Add("C_EMPID", OracleDbType.Int32).Value = objEntitySalaryCertfct.EmployeeId;
            cmdReadSalary.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalary = new DataTable();
            dtSalary = clsDataLayer.ExecuteReader(cmdReadSalary);
            return dtSalary;
        }

        public DataTable ReadRequestById(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_READ_CERTFCT_REQST_BYID";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_SLRYCRTFCTID", OracleDbType.Int32).Value = objEntitySalaryCertfct.CertifictId;
            cmdReadSalary.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtSalary = new DataTable();
            dtSalary = clsDataLayer.ExecuteReader(cmdReadSalary);
            return dtSalary;
        }

        public void UpdateApproveSalaryReqst(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_UPDATE_APPROVE_RQST";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_SLRYCRTFCTID", OracleDbType.Int32).Value = objEntitySalaryCertfct.CertifictId;
            cmdReadSalary.Parameters.Add("C_INS_USR_ID", OracleDbType.Int32).Value = objEntitySalaryCertfct.UserId;
            cmdReadSalary.Parameters.Add("C_INS_DATE", OracleDbType.Date).Value = objEntitySalaryCertfct.Date;
            clsDataLayer.ExecuteNonQuery(cmdReadSalary);
        }

        public void UpdateRejectSalaryReqst(clsEntityLayerSalaryCertificate objEntitySalaryCertfct)
        {
            string strQueryReadSalary = "SALARY_CERTIFICATE.SP_UPDATE_REJECT_RQST";
            OracleCommand cmdReadSalary = new OracleCommand();
            cmdReadSalary.CommandText = strQueryReadSalary;
            cmdReadSalary.CommandType = CommandType.StoredProcedure;
            cmdReadSalary.Parameters.Add("C_SLRYCRTFCTID", OracleDbType.Int32).Value = objEntitySalaryCertfct.CertifictId;
            cmdReadSalary.Parameters.Add("C_INS_USR_ID", OracleDbType.Int32).Value = objEntitySalaryCertfct.UserId;
            cmdReadSalary.Parameters.Add("C_INS_DATE", OracleDbType.Date).Value = objEntitySalaryCertfct.Date;
            cmdReadSalary.Parameters.Add("C_REJECT_REASN", OracleDbType.Varchar2).Value = objEntitySalaryCertfct.RejectReason;
            clsDataLayer.ExecuteNonQuery(cmdReadSalary);
        }


    }
}
