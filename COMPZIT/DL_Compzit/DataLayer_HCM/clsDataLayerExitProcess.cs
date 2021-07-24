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
    public class clsDataLayerExitProcess
    {
        //read employee to dropdown
        public DataTable ReadToddlEmployee(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadEmp = "EMPLOYEE_EXIT_PROCESS.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitProcs.CorpId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitProcs.OrgId;
            cmdReadEmp.Parameters.Add("P_STAFFWRKR", OracleDbType.Int32).Value = objEntityExitProcs.Mode;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read employee details
        public DataTable ReadEmpDtls(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadEmp = "EMPLOYEE_EXIT_PROCESS.SP_READ_EMPDTLS_BYID";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityExitProcs.EmpId;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read division of employee
        public DataTable ReadDivsnEmp(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadDiv = "EMPLOYEE_EXIT_PROCESS.SP_READ_EMPLOYEE_DIVSN";
            OracleCommand cmdReadDiv = new OracleCommand();
            cmdReadDiv.CommandText = strQueryReadDiv;
            cmdReadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadDiv.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityExitProcs.EmpId;
            cmdReadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivEmp = new DataTable();
            dtDivEmp = clsDataLayer.ExecuteReader(cmdReadDiv);
            return dtDivEmp;
        }

        //insert exit process
        public void InsertExitPrcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryAddExit = "EMPLOYEE_EXIT_PROCESS.SP_INSERT_EXIT_PRCS";
            using (OracleCommand cmdAddExit = new OracleCommand())
            {
                cmdAddExit.CommandText = strQueryAddExit;
                cmdAddExit.CommandType = CommandType.StoredProcedure;
                cmdAddExit.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityExitProcs.EmpId;
                cmdAddExit.Parameters.Add("P_EXTPRCS_STS", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsStatus;
                cmdAddExit.Parameters.Add("P_EXTPRCS_RSN", OracleDbType.Varchar2).Value = objEntityExitProcs.ExitReason;
                cmdAddExit.Parameters.Add("P_EXTPRCS_DATE", OracleDbType.Date).Value = objEntityExitProcs.ExitProcsDate;
                cmdAddExit.Parameters.Add("P_NOTICEPRD", OracleDbType.Int32).Value = objEntityExitProcs.NoticePrd;
                cmdAddExit.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitProcs.CorpId;
                cmdAddExit.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitProcs.OrgId;
                cmdAddExit.Parameters.Add("P_INS_USRID", OracleDbType.Int32).Value = objEntityExitProcs.UserId;
                cmdAddExit.Parameters.Add("P_INS_DT", OracleDbType.Date).Value = objEntityExitProcs.Date;
                //EVM-0024
                if (objEntityExitProcs.IncidentUserId != 0)
                {
                    cmdAddExit.Parameters.Add("P_INCIDENT", OracleDbType.Int32).Value = objEntityExitProcs.IncidentUserId;
                }
                else{
                     cmdAddExit.Parameters.Add("P_INCIDENT", OracleDbType.Int32).Value =null;
                    }
                //END
                clsDataLayer.ExecuteNonQuery(cmdAddExit);
            }
        }

        //read exit process
        public DataTable ReadExitProcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadDiv = "EMPLOYEE_EXIT_PROCESS.SP_READ_EXITPRCS";
            OracleCommand cmdReadDiv = new OracleCommand();
            cmdReadDiv.CommandText = strQueryReadDiv;
            cmdReadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitProcs.CorpId;
            cmdReadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitProcs.OrgId;
            cmdReadDiv.Parameters.Add("P_CANCEL", OracleDbType.Int32).Value = objEntityExitProcs.CancelStatus;
            cmdReadDiv.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityExitProcs.EmpId;
            cmdReadDiv.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsStatus;
            cmdReadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtExtPrcs = new DataTable();
            dtExtPrcs = clsDataLayer.ExecuteReader(cmdReadDiv);
            return dtExtPrcs;
        }

        //cancel exit process
        public void CancelExitPrcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryCnclExit = "EMPLOYEE_EXIT_PROCESS.SP_CANCEL_EXITPRCS";
            using (OracleCommand cmdCancelExit = new OracleCommand())
            {
                cmdCancelExit.CommandText = strQueryCnclExit;
                cmdCancelExit.CommandType = CommandType.StoredProcedure;
                cmdCancelExit.Parameters.Add("P_EXTPROCS_ID", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsId;
                cmdCancelExit.Parameters.Add("P_EXTPRCS_CNCL_DATE", OracleDbType.Date).Value = objEntityExitProcs.Date;
                cmdCancelExit.Parameters.Add("P_EXTPRCS_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityExitProcs.CancelReason;
                cmdCancelExit.Parameters.Add("P_EXTPRCS_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityExitProcs.UserId;
                cmdCancelExit.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitProcs.OrgId;
                cmdCancelExit.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitProcs.CorpId;
                cmdCancelExit.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdCancelExit);
            }
        }

        //read employee details on exit process
        public DataTable ReadEmpExitDtls(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadEmpExt = "EMPLOYEE_EXIT_PROCESS.SP_READ_EMPDTLS_EXTPRCS";
            OracleCommand cmdReadEmpExt = new OracleCommand();
            cmdReadEmpExt.CommandText = strQueryReadEmpExt;
            cmdReadEmpExt.CommandType = CommandType.StoredProcedure;
            cmdReadEmpExt.Parameters.Add("P_EXTPROCS_ID", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsId;
            cmdReadEmpExt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmpExt);
            return dtEmp;
        }

        //update exit process
        public void UpdateExitPrcs(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryUpdExit = "EMPLOYEE_EXIT_PROCESS.SP_UPDATE_EXIT_PRCS";
            using (OracleCommand cmdUpdExit = new OracleCommand())
            {
                cmdUpdExit.CommandText = strQueryUpdExit;
                cmdUpdExit.CommandType = CommandType.StoredProcedure;
                cmdUpdExit.Parameters.Add("P_EXTPROCS_ID", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsId;
                cmdUpdExit.Parameters.Add("P_EXTPRCS_STS", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsStatus;
                cmdUpdExit.Parameters.Add("P_EXTPRCS_RSN", OracleDbType.Varchar2).Value = objEntityExitProcs.ExitReason;
                cmdUpdExit.Parameters.Add("P_EXTPRCS_DATE", OracleDbType.Date).Value = objEntityExitProcs.ExitProcsDate;
                cmdUpdExit.Parameters.Add("P_NOTICEPRD", OracleDbType.Int32).Value = objEntityExitProcs.NoticePrd;
                cmdUpdExit.Parameters.Add("P_CONFRMSTS", OracleDbType.Int32).Value = objEntityExitProcs.ConfrmStatus;
                cmdUpdExit.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitProcs.CorpId;
                cmdUpdExit.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitProcs.OrgId;
                cmdUpdExit.Parameters.Add("P_UPD_USRID", OracleDbType.Int32).Value = objEntityExitProcs.UserId;
                cmdUpdExit.Parameters.Add("P_UPD_DT", OracleDbType.Date).Value = objEntityExitProcs.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdExit);
            }
            //EVM-0024
             string strQueryUpdIncident = "EMPLOYEE_EXIT_PROCESS.SP_UPDATE_INCIDENT";
             using (OracleCommand cmdUpdIncident = new OracleCommand())
             {
                 cmdUpdIncident.CommandText = strQueryUpdIncident;
                 cmdUpdIncident.CommandType = CommandType.StoredProcedure;
                 cmdUpdIncident.Parameters.Add("INCIDENT_UID", OracleDbType.Int32).Value = objEntityExitProcs.EmpId;
                 cmdUpdIncident.Parameters.Add("TRMTN_UID", OracleDbType.Int32).Value = objEntityExitProcs.UserId;

                 clsDataLayer.ExecuteNonQuery(cmdUpdIncident);
             }
            //END
        }

        //update confrm status
        public void UpdateConfrm(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryUpdExit = "EMPLOYEE_EXIT_PROCESS.SP_UPDATE_CONFRM_STATUS";
            using (OracleCommand cmdUpdExit = new OracleCommand())
            {
                cmdUpdExit.CommandText = strQueryUpdExit;
                cmdUpdExit.CommandType = CommandType.StoredProcedure;
                cmdUpdExit.Parameters.Add("P_EXTPROCS_ID", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsId;
                cmdUpdExit.Parameters.Add("P_CONFRMSTS", OracleDbType.Int32).Value = objEntityExitProcs.ConfrmStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdExit);
            }
            //EVM-0024
            string strQueryUpdIncident = "EMPLOYEE_EXIT_PROCESS.SP_UPDATE_INCIDENT_TRMNTN";
            using (OracleCommand cmdUpdIncident = new OracleCommand())
            {
                cmdUpdIncident.CommandText = strQueryUpdIncident;
                cmdUpdIncident.CommandType = CommandType.StoredProcedure;
                cmdUpdIncident.Parameters.Add("P_EXTPROCS_ID", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsId;
                clsDataLayer.ExecuteNonQuery(cmdUpdIncident);
            }
            //END
        }


        //check confirm status
        public DataTable CheckConfrmStatus(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadEmpExt = "EMPLOYEE_EXIT_PROCESS.SP_CHECK_CONFRM_STATUS";
            OracleCommand cmdReadEmpExt = new OracleCommand();
            cmdReadEmpExt.CommandText = strQueryReadEmpExt;
            cmdReadEmpExt.CommandType = CommandType.StoredProcedure;
            cmdReadEmpExt.Parameters.Add("P_EXTPROCS_ID", OracleDbType.Int32).Value = objEntityExitProcs.ExitProcsId;
            cmdReadEmpExt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmpExt);
            return dtEmp;
        }
        //EVM-0024
        //read employee details from conduct incident
        public DataTable ReadEmpIncidentDtls(clsEntityLayerExitProcess objEntityExitProcs)
        {
            string strQueryReadEmpExt = "EMPLOYEE_EXIT_PROCESS.SP_READ_EMPDTLS_INCIDNET";
            OracleCommand cmdReadEmpExt = new OracleCommand();
            cmdReadEmpExt.CommandText = strQueryReadEmpExt;
            cmdReadEmpExt.CommandType = CommandType.StoredProcedure;
            cmdReadEmpExt.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityExitProcs.EmpId;
            cmdReadEmpExt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmpExt);
            return dtEmp;
        }
        //END

        public DataTable ReadEmpExitProcessMstrSts(clsEntityLayerExitProcess objEntityExitProcs)        
        {
            string strQueryReadEmpExt = "EMPLOYEE_EXIT_PROCESS.SP_READ_EXIT_PRCS_STS_MSTR";
            OracleCommand cmdReadEmpExt = new OracleCommand();
            cmdReadEmpExt.CommandText = strQueryReadEmpExt;
            cmdReadEmpExt.CommandType = CommandType.StoredProcedure;
            cmdReadEmpExt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmpExt);
            return dtEmp;
        }

    }
}
