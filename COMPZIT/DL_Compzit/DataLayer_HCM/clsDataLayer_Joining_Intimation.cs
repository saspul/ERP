using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Joining_Intimation
    {

        public DataTable ReadDivision(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityShortlist.Deprt_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public DataTable ReadDepartment(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadProject(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPrjct = "JOINING_INTIMATION.SP_READ_PROJECT";
            OracleCommand cmdReadPrjct = new OracleCommand();
            cmdReadPrjct.CommandText = strQueryReadPrjct;
            cmdReadPrjct.CommandType = CommandType.StoredProcedure;
            cmdReadPrjct.Parameters.Add("J_DIVID", OracleDbType.Int32).Value = objEntityShortlist.DivId;
            cmdReadPrjct.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadPrjct.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadPrjct.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadPrjct.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
            return dtCategory;
        }
        public DataTable ReadJoingReqrmntList(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_JOININGRQST_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityShortlist.DivId;
            cmdReadJob.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityShortlist.Deprt_Id;
            cmdReadJob.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityShortlist.PrjctId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadAprvdManPwrReqstListByid(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_MAN_PWRRQST_BY_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadCandidates(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_CANDIDATE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            //  cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public DataTable ReadSelected_Candidates(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_GET_SHORT_LISTED_CAND";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable EmailIdFetch(SelectedCandiate objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_GET_EMAIL_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityShortlist.CandidateId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void EmailStsUpdate(SelectedCandiate objEntityShortlist) 
        {
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {

                string strQueryReadPayGrd = "JOINING_INTIMATION.SP_GET_EMAILSTS_UPDATE";
                OracleCommand cmdReadJob = new OracleCommand();
                cmdReadJob.CommandText = strQueryReadPayGrd;
                cmdReadJob.CommandType = CommandType.StoredProcedure;

                cmdReadJob.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityShortlist.CandidateId;


                clsDataLayer.ExecuteNonQuery(cmdReadJob);
            }
           
        }

        //update joining status evm-0019 Start
        public void UpdJoinStatus(SelectedCandiate objEntityShortlist)
        {
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {

                string strQueryReadPayGrd = "JOINING_INTIMATION.SP_GET_JOINSTS_UPDATE";
                OracleCommand cmdReadJob = new OracleCommand();
                cmdReadJob.CommandText = strQueryReadPayGrd;
                cmdReadJob.CommandType = CommandType.StoredProcedure;

                cmdReadJob.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityShortlist.CandidateId;
                cmdReadJob.Parameters.Add("C_JOINSTS", OracleDbType.Int32).Value = objEntityShortlist.JoiningStatus;

                clsDataLayer.ExecuteNonQuery(cmdReadJob);
            }

        }
        //evm-0019 end


        public DataTable ReadLeaveTyp(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_LEAVETYP";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("L_DSG_ID", OracleDbType.Int32).Value = objEntityShortlist.DesgId;
            cmdReadJob.Parameters.Add("L_PYGRD_ID", OracleDbType.Int32).Value = objEntityShortlist.PayGradeId;
            cmdReadJob.Parameters.Add("L_EXP_ID", OracleDbType.Int32).Value = objEntityShortlist.Experience;
            cmdReadJob.Parameters.Add("L_GENDER", OracleDbType.Int32).Value = objEntityShortlist.Gender;
            cmdReadJob.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }   

        public DataTable ReadNoticePeriod(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_NOTICE_PERD";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("L_DESG_ID", OracleDbType.Int32).Value = objEntityShortlist.DesgId;
            cmdReadJob.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public void UpdJoinDate(SelectedCandiate objEntityShortlist)
        {
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                string strQueryReadPayGrd = "JOINING_INTIMATION.SP_GET_JOINDATE_UPDATE";
                OracleCommand cmdReadJob = new OracleCommand();
                cmdReadJob.CommandText = strQueryReadPayGrd;
                cmdReadJob.CommandType = CommandType.StoredProcedure;
                cmdReadJob.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityShortlist.CandidateId;
                cmdReadJob.Parameters.Add("C_JOINDATE", OracleDbType.Date).Value = objEntityShortlist.JoinDate;
                clsDataLayer.ExecuteNonQuery(cmdReadJob);
            }
        }

        public DataTable ReadJobDescrptn(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_JOB_DESCRIPTN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("L_DESG_ID", OracleDbType.Int32).Value = objEntityShortlist.DesgId;
            cmdReadJob.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        public DataTable ReadAppointmtParamtrs(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_APPOINTMT_PARAMTRS";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("L_CORPRT_ID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadCandidatesReport(clsEntity_Joining_Intimation objEntityShortlist)
        {
            string strQueryReadPayGrd = "JOINING_INTIMATION.SP_READ_CANDIDATE_REPORT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityShortlist.PrjctId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

        
    }
}
