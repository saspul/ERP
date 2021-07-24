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
    public class clsDataLayerExitPartialProcess
    {

        //read employee to dropdown
        public DataTable ReadToddlDesignation(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadEmp = "EXIT_PARTIAL_PROCESS.SP_READ_DSGN_BY_USRID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.OrgId;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.CorpId;
            cmdReadEmp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.UserId;
            cmdReadEmp.Parameters.Add("D_DSGN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read employee details to table
        public DataTable ReadEmployeeExit(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadEmp = "EXIT_PARTIAL_PROCESS.SP_READ_EMP_EXIT_PROCESS";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;

            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.CorpId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.OrgId;
            cmdReadEmp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.UserId;
            if (objEntityLayerExitPartialProcess.AsgndDate != DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("P_ASSGND_DATE", OracleDbType.Date).Value = objEntityLayerExitPartialProcess.AsgndDate;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_ASSGND_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityLayerExitPartialProcess.ToDate != DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLayerExitPartialProcess.ToDate;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityLayerExitPartialProcess.DesigID != 0)
            {
                cmdReadEmp.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.DesigID;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = null;
            }
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read division by employee id
        public DataTable ReadDivsnEmp(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadDiv = "EXIT_PARTIAL_PROCESS.SP_READ_EMPLOYEE_DIVSN";
            OracleCommand cmdReadDiv = new OracleCommand();
            cmdReadDiv.CommandText = strQueryReadDiv;
            cmdReadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.CorpId;
            cmdReadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.OrgId;
            cmdReadDiv.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.EmpId;
            cmdReadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivEmp = new DataTable();
            dtDivEmp = clsDataLayer.ExecuteReader(cmdReadDiv);
            return dtDivEmp;
        }
        //read Employee Particular Dtls By Id
        public DataTable ReadEmpDtlsById(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadEmpDtlsById = "EXIT_PARTIAL_PROCESS.SP_READ_EMPLOYEE_BYID";
            OracleCommand cmdReadEmpDtlsById = new OracleCommand();
            cmdReadEmpDtlsById.CommandText = strQueryReadEmpDtlsById;
            cmdReadEmpDtlsById.CommandType = CommandType.StoredProcedure;
            cmdReadEmpDtlsById.Parameters.Add("P_EXTPRD_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcdureID;
            cmdReadEmpDtlsById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.EmpId;
            cmdReadEmpDtlsById.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpDtlsById = new DataTable();
            dtEmpDtlsById = clsDataLayer.ExecuteReader(cmdReadEmpDtlsById);
            return dtEmpDtlsById;
        }

        //read Exit Process Dtls By ID
        public DataTable ReadExitProcessDtlsByID(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadFinishdOrClosd = "EXIT_PARTIAL_PROCESS.SP_READ_EXIT_PROC_DTL_BYID";
            OracleCommand cmdReadEmpDtlsById = new OracleCommand();
            cmdReadEmpDtlsById.CommandText = strQueryReadFinishdOrClosd;
            cmdReadEmpDtlsById.CommandType = CommandType.StoredProcedure;
            cmdReadEmpDtlsById.Parameters.Add("P_EXTPRD_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcdureID;
            cmdReadEmpDtlsById.Parameters.Add("P_USER_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.UserId;
            cmdReadEmpDtlsById.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.EmpId;
            cmdReadEmpDtlsById.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtFinishdOrClosd = new DataTable();
            dtFinishdOrClosd = clsDataLayer.ExecuteReader(cmdReadEmpDtlsById);
            return dtFinishdOrClosd;
        }
        // This Method checks exit process
        public string CheckExitProcess(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryCheckExitProcess = "EXIT_PARTIAL_PROCESS.SP_CHECK_EXIT_PROCESS";
            OracleCommand cmdCheckExitProcess = new OracleCommand();
            cmdCheckExitProcess.CommandText = strQueryCheckExitProcess;
            cmdCheckExitProcess.CommandType = CommandType.StoredProcedure;
            cmdCheckExitProcess.Parameters.Add("P_EXTPRDDTL_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcDtlID;
            cmdCheckExitProcess.Parameters.Add("P_EXTPRD_ID", OracleDbType.Varchar2).Value = objEntityLayerExitPartialProcess.ExitProcdureID;
            cmdCheckExitProcess.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.Mode;
            cmdCheckExitProcess.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckExitProcess);
            string strReturn = cmdCheckExitProcess.Parameters["P_COUNT"].Value.ToString();
            cmdCheckExitProcess.Dispose();
            return strReturn;
        }
        //update Partial Exit Process
        public void updPartialExitProcess(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadById = "EXIT_PARTIAL_PROCESS.SP_UPDATE_PARTIAL_EXIT_PRO";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_EXTPRDDTL_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcDtlID;
                cmdReadById.Parameters.Add("P_EXTPRD_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcdureID;
                if (objEntityLayerExitPartialProcess.ExpectedTargetDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("P_DATE_EXPEC", OracleDbType.Date).Value = objEntityLayerExitPartialProcess.ExpectedTargetDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("P_DATE_EXPEC", OracleDbType.Date).Value = null;
                }
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerExitPartialProcess.Date;
                cmdReadById.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.Status;
                cmdReadById.Parameters.Add("P_FINSH_STS", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.FinishSts;
                cmdReadById.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.Mode;
                //BKUP TABLE
                cmdReadById.ExecuteNonQuery();
            }
        }

        //close Partial Exit Process
        public void closePartialExitProcess(clsEntityLayerExitPartialProcess objEntityLayerExitPartialProcess)
        {
            string strQueryReadById = "EXIT_PARTIAL_PROCESS.SP_CLOSE_PARTIAL_EXIT_PRO";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_EXTPRDDTL_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcDtlID;
                cmdReadById.Parameters.Add("P_EXTPRD_ID", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.ExitProcdureID;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerExitPartialProcess.Date;
                cmdReadById.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityLayerExitPartialProcess.Mode;
                cmdReadById.ExecuteNonQuery();
            }
        }

       


    }
}
