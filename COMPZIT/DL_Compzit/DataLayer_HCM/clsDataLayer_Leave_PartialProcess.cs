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
    public class clsDataLayer_Leave_PartialProcess
    {
        //read employee to dropdown
        public DataTable ReadToddlEmployee(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadEmp = "LEAVE_PARTIAL_PROCESS.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.CorpId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.OrgId;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read employee details to table
        public DataTable ReadEmployeeLeave(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadEmp = "LEAVE_PARTIAL_PROCESS.SP_READ_EMPLOYEE_LEAVE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmp;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.CorpId;
            cmdReadEmp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.OrgId;
            cmdReadEmp.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
            if (objEntityLayerLeavePartialPrcs.AsgndDate != DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("P_ASSGND_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.AsgndDate;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_ASSGND_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityLayerLeavePartialPrcs.ToDate != DateTime.MinValue)
            {
                cmdReadEmp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.ToDate;
            }
            else
            {
                cmdReadEmp.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadEmp.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.Mode;
            cmdReadEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
            cmdReadEmp.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmp = new DataTable();
            dtEmp = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmp;
        }

        //read division by employee id
        public DataTable ReadDivsnEmp(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadDiv = "LEAVE_PARTIAL_PROCESS.SP_READ_EMPLOYEE_DIVSN";
            OracleCommand cmdReadDiv = new OracleCommand();
            cmdReadDiv.CommandText = strQueryReadDiv;
            cmdReadDiv.CommandType = CommandType.StoredProcedure;
            cmdReadDiv.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.CorpId;
            cmdReadDiv.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.OrgId;
            cmdReadDiv.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
            cmdReadDiv.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivEmp = new DataTable();
            dtDivEmp = clsDataLayer.ExecuteReader(cmdReadDiv);
            return dtDivEmp;
        }

        //read Employee Dtls By levid
        public DataTable ReadallAssignstatus(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadFinishdOrClosd = "LEAVE_PARTIAL_PROCESS.SP_READ_ASSIGNSTATUS";
            OracleCommand cmdReadFinishdOrClosd = new OracleCommand();
            cmdReadFinishdOrClosd.CommandText = strQueryReadFinishdOrClosd;
            cmdReadFinishdOrClosd.CommandType = CommandType.StoredProcedure;
            cmdReadFinishdOrClosd.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
            cmdReadFinishdOrClosd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtFinishdOrClosd = new DataTable();
            dtFinishdOrClosd = clsDataLayer.ExecuteReader(cmdReadFinishdOrClosd);
            return dtFinishdOrClosd;
        }

        //read Employee Particular Dtls By Id
        public DataTable ReadEmpDtlsByLevId(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadEmpDtlsById = "LEAVE_PARTIAL_PROCESS.SP_READ_EMPLOYEE_BYLEVID";
            OracleCommand cmdReadEmpDtlsById = new OracleCommand();
            cmdReadEmpDtlsById.CommandText = strQueryReadEmpDtlsById;
            cmdReadEmpDtlsById.CommandType = CommandType.StoredProcedure;
            cmdReadEmpDtlsById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
            cmdReadEmpDtlsById.Parameters.Add("P_LEVID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
            cmdReadEmpDtlsById.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpDtlsById = new DataTable();
            dtEmpDtlsById = clsDataLayer.ExecuteReader(cmdReadEmpDtlsById);
            return dtEmpDtlsById;
        }

        //update ticket status
        public void updTicktSts(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_UPD_TICKT";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DTLSTS", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlStatus;
                if (objEntityLayerLeavePartialPrcs.AsgndDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("P_EXP_TRGTDATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.AsgndDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("P_EXP_TRGTDATE", OracleDbType.Date).Value = null;
                }
                cmdReadById.Parameters.Add("P_TRGTDATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                //BKUP TABLE
                cmdReadById.Parameters.Add("P_LEVFCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //update settlement status
        public void updSettlmtSts(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_UPD_SETTLMT";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DTLSTS", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlStatus;
                if (objEntityLayerLeavePartialPrcs.AsgndDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("P_EXP_TRGTDATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.AsgndDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("P_EXP_TRGTDATE", OracleDbType.Date).Value = null;
                }
                cmdReadById.Parameters.Add("P_TRGTDATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_LEVFCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //update exit process status
        public void updExitSts(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_UPD_EXITPRCS";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DTLSTS", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlStatus;
                if (objEntityLayerLeavePartialPrcs.AsgndDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("P_EXP_TRGTDATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.AsgndDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("P_EXP_TRGTDATE", OracleDbType.Date).Value = null;
                }
                cmdReadById.Parameters.Add("P_TRGTDATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_LEVFCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }


        //read finished or closed
        public DataTable ReadFinishdOrClosd(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadFinishdOrClosd = "LEAVE_PARTIAL_PROCESS.SP_CHECK_FINSH_CLS";
            OracleCommand cmdReadFinishdOrClosd = new OracleCommand();
            cmdReadFinishdOrClosd.CommandText = strQueryReadFinishdOrClosd;
            cmdReadFinishdOrClosd.CommandType = CommandType.StoredProcedure;
            cmdReadFinishdOrClosd.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
            cmdReadFinishdOrClosd.Parameters.Add("P_PRTCLR_ID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.PartclrId;
            cmdReadFinishdOrClosd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtFinishdOrClosd = new DataTable();
            dtFinishdOrClosd = clsDataLayer.ExecuteReader(cmdReadFinishdOrClosd);
            return dtFinishdOrClosd;
        }


        //close ticket
        public void closeTicket(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_CLOSE_TICKT";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_FCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                //BKUP TABLE
                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //close settlemt
        public void closeSettlmt(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_CLOSE_SETTLMT";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_FCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //close exit process
        public void closeExitPrcs(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_CLOSE_EXITPRCS";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_FCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //finish ticket
        public void finishTicket(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_FINISH_TICKT";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_FCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //finish settlment
        public void finishSettlmt(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_FINISH_SETTLMT";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_FCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }

        //finish exit process
        public void finishExitPrcs(clsEntity_Leave_PartialProcess objEntityLayerLeavePartialPrcs)
        {
            string strQueryReadById = "LEAVE_PARTIAL_PROCESS.SP_FINISH_EXITPRCS";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("P_FCLTYID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveFacltyId;
                cmdReadById.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.LeaveDtlId;
                cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerLeavePartialPrcs.Date;

                cmdReadById.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.EmpId;
                cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerLeavePartialPrcs.UserId;
                cmdReadById.ExecuteNonQuery();
            }
        }


        


    }
}
