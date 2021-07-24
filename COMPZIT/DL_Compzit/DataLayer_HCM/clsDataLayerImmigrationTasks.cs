using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using DL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerImmigrationTasks
    {


        public DataTable ReadEmpLoad(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_EMP_LOAD";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityImgrtnTasks.Orgid;
            cmdReadJob.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CorpOffice;
            cmdReadJob.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityImgrtnTasks.UserId;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadAsgndImgrtnCandts(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_ASGND_CANDLIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityImgrtnTasks.Orgid;
            cmdReadJob.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CorpOffice;
            cmdReadJob.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityImgrtnTasks.UserId;
            if (objEntityImgrtnTasks.CloseDate != DateTime.MinValue)
            {
                cmdReadJob.Parameters.Add("I_ASGND_DATE", OracleDbType.Date).Value = objEntityImgrtnTasks.CloseDate;
            }
            else
            {
                cmdReadJob.Parameters.Add("I_ASGND_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityImgrtnTasks.FinishDate != DateTime.MinValue)
            {
                cmdReadJob.Parameters.Add("I_TO_DATE", OracleDbType.Date).Value = objEntityImgrtnTasks.FinishDate;
            }
            else
            {
                cmdReadJob.Parameters.Add("I_TO_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadJob.Parameters.Add("I_EMPID", OracleDbType.Int32).Value = objEntityImgrtnTasks.EmployeeId;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }


        public DataTable ReadEmpInfoById(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_CAND_INFO";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadEmpRoundDtls(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_CAND_ROUND_DTLS";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
            cmdReadJob.Parameters.Add("I_RND_NAME", OracleDbType.Varchar2).Value = objEntityImgrtnTasks.RoundName;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public DataTable ReadEmpRoundDtlsID(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_CAND_ROUND_DTLS_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
            cmdReadJob.Parameters.Add("I_RND_NAME", OracleDbType.Varchar2).Value = objEntityImgrtnTasks.RoundName;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadEmpAsgnedForRnd(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_ASGNDEMP_ROUND";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_DTLID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnDetailId;
            cmdReadJob.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityImgrtnTasks.UserId;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadStatusDdl(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_READ_DDL_LOAD";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnRndId;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void addRoundDtls(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadById = "IMMIGRATION_TASKS.SP_UPD_ROUND_INFO";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;

                cmdReadById.Parameters.Add("I_IMGRTNID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnId;
                cmdReadById.Parameters.Add("I_IMGRTNDTL_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnDetailId;
                cmdReadById.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityImgrtnTasks.UserId;
                cmdReadById.Parameters.Add("I_USERDATE", OracleDbType.Date).Value = objEntityImgrtnTasks.UsrDate;

                cmdReadById.Parameters.Add("I_CANDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
                cmdReadById.Parameters.Add("I_RNDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnRndId;
                cmdReadById.Parameters.Add("I_STS", OracleDbType.Int32).Value = objEntityImgrtnTasks.RoundStatusId;
                if (objEntityImgrtnTasks.CloseDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("I_EXPDATE", OracleDbType.Date).Value = objEntityImgrtnTasks.CloseDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("I_EXPDATE", OracleDbType.Date).Value = null;
                }
                if (objEntityImgrtnTasks.ScheduleDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("I_SDLDATE", OracleDbType.Date).Value = objEntityImgrtnTasks.ScheduleDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("I_SDLDATE", OracleDbType.Date).Value = null;
                }
                cmdReadById.Parameters.Add("I_ACT_FNAME", OracleDbType.Varchar2).Value = objEntityImgrtnTasks.ActFname;
                cmdReadById.Parameters.Add("I_FNAME", OracleDbType.Varchar2).Value = objEntityImgrtnTasks.Fname;
                cmdReadById.ExecuteNonQuery();
            }
        }
        public void CloseRound(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadById = "IMMIGRATION_TASKS.SP_CLOSE_RND";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("I_IMGRTNID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnId;
                cmdReadById.Parameters.Add("I_IMGRTNDTL_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnDetailId;
                cmdReadById.Parameters.Add("I_STS", OracleDbType.Int32).Value = objEntityImgrtnTasks.RoundStatusId;

                cmdReadById.Parameters.Add("I_RNDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnRndId;
                cmdReadById.Parameters.Add("I_CANDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
                cmdReadById.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityImgrtnTasks.UserId;
                cmdReadById.Parameters.Add("I_DATE", OracleDbType.Date).Value = objEntityImgrtnTasks.UsrDate;

                cmdReadById.ExecuteNonQuery();
            }
        }
        public void finisRound(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadById = "IMMIGRATION_TASKS.SP_FINISH_RND";
            using (OracleCommand cmdReadById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadById.Connection = con;
                cmdReadById.CommandText = strQueryReadById;
                cmdReadById.CommandType = CommandType.StoredProcedure;
                cmdReadById.Parameters.Add("I_IMGRTNID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnId;
                cmdReadById.Parameters.Add("I_IMGRTNDTL_ID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnDetailId;
                cmdReadById.Parameters.Add("I_STS", OracleDbType.Int32).Value = objEntityImgrtnTasks.RoundStatusId;

                cmdReadById.Parameters.Add("I_RNDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnRndId;
                cmdReadById.Parameters.Add("I_CANDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
                cmdReadById.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityImgrtnTasks.UserId;
                cmdReadById.Parameters.Add("I_DATE", OracleDbType.Date).Value = objEntityImgrtnTasks.UsrDate;
                if (objEntityImgrtnTasks.ScheduleDate != DateTime.MinValue)
                {
                    cmdReadById.Parameters.Add("I_SDLDATE", OracleDbType.Date).Value = objEntityImgrtnTasks.ScheduleDate;
                }
                else
                {
                    cmdReadById.Parameters.Add("I_SDLDATE", OracleDbType.Date).Value = null;
                }
                cmdReadById.ExecuteNonQuery();
            }
        }
        public DataTable CheckRoundFinisdClsd(clsEntityImmigrationTasks objEntityImgrtnTasks)
        {
            string strQueryReadPayGrd = "IMMIGRATION_TASKS.SP_CHECK_RND_FNSH_CLS";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("I_CANDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.CandId;
            cmdReadJob.Parameters.Add("I_RNDID", OracleDbType.Int32).Value = objEntityImgrtnTasks.ImgrtnRndId;
            cmdReadJob.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
    }
}
