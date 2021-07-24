using EL_Compzit;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsData_Candidate_Login
    {
        public DataTable Readlogin(clsEntityCandidatelogin objEntityjob)
        {
            string strQueryReadPayGrd = "CANDIDATE_LOGIN.SP_READ_CANDIDATE_LOGIN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
           // cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("C_CANDID", OracleDbType.Varchar2).Value = objEntityjob.CandidateId;
          
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable Checklogin(clsEntityCandidatelogin objEntityjob)
        {
            string strQueryReadPayGrd = "CANDIDATE_LOGIN.SP_CHECK_LOGIN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            // cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("C_GENCANDID", OracleDbType.Varchar2).Value = objEntityjob.GeneratedCandidateId;

            cmdReadJob.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
              cmdReadJob.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void AddLogin(clsEntityCandidatelogin objEntityjob)
        {
            string strQueryReadPayGrd = "CANDIDATE_LOGIN.SP_ADD_CANDIDATE_LOGIN";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               
                cmdReadPayGrd.Parameters.Add("P_GENCANDID", OracleDbType.Varchar2).Value = objEntityjob.GeneratedCandidateId;
                cmdReadPayGrd.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityjob.CandidateId;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;


                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public DataTable ReadCandidates(clsEntityCandidatelogin objEntityjob)
        {
            string strQueryReadPayGrd = "CANDIDATE_LOGIN.SP_READ_CANDIDATES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            // cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
            public DataTable ReadRegisteredCandidates(clsEntityCandidatelogin objEntityCandidate)
        {
            string strQueryReadPayGrd = "CANDIDATE_LOGIN.SP_READ_CANDIDATE_REG";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityCandidate.User_Id;
            cmdReadJob.Parameters.Add("T_CANCEL", OracleDbType.Int32).Value = objEntityCandidate.Cancelstatus;
            cmdReadJob.Parameters.Add("C_CFRMSTAT", OracleDbType.Int32).Value = objEntityCandidate.Confirmstatus;
      
            cmdReadJob.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
            cmdReadJob.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
            cmdReadJob.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

            public void UpdateCandidatesId(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryUpdateCandidatesId = "CANDIDATE_LOGIN.SP_UPD_CAND_ID";
                OracleCommand cmdUpdateCandidatesId = new OracleCommand();
                cmdUpdateCandidatesId.CommandText = strQueryUpdateCandidatesId;
                cmdUpdateCandidatesId.CommandType = CommandType.StoredProcedure;
                cmdUpdateCandidatesId.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;
                cmdUpdateCandidatesId.Parameters.Add("C_USER_ID", OracleDbType.Int32).Value = objEntityCandidate.EmployeeId;

                clsDataLayer.ExecuteNonQuery(cmdUpdateCandidatesId);
            }
            //START EVM-0019
            public void UpdateCnfrmSts(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryUpdateCnfrmSts = "CANDIDATE_LOGIN.SP_UPD_CONFRM_STS";
                using (OracleCommand cmdUpdateCnfrmSts = new OracleCommand())
                {
                    cmdUpdateCnfrmSts.CommandText = strQueryUpdateCnfrmSts;
                    cmdUpdateCnfrmSts.CommandType = CommandType.StoredProcedure;
                    cmdUpdateCnfrmSts.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;
                    cmdUpdateCnfrmSts.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
                    cmdUpdateCnfrmSts.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
                    clsDataLayer.ExecuteNonQuery(cmdUpdateCnfrmSts);
                }
            }
        //END EVM-0019

            //EVM-0027
            public DataTable ReadStaffDetails(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryReadPayGrd = "CANDIDATE_LOGIN.SP_READ_STAFF_DETAILS";
                OracleCommand cmdReadJob = new OracleCommand();
                cmdReadJob.CommandText = strQueryReadPayGrd;
                cmdReadJob.CommandType = CommandType.StoredProcedure;
                cmdReadJob.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;

                cmdReadJob.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
                cmdReadJob.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
                cmdReadJob.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCategory = new DataTable();
                dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
                return dtCategory;
            }
            public DataTable ReadCorpDtls(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryReadTcs = "CANDIDATE_LOGIN.SP_READ_CORP_DTLS";
                OracleCommand cmdReadTcs = new OracleCommand();
                cmdReadTcs.CommandText = strQueryReadTcs;
                cmdReadTcs.CommandType = CommandType.StoredProcedure;
                cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
                cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
                cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeav = new DataTable();
                dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
                return dtLeav;
            }
            public DataTable ReadLanguageDetails(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryReadTcs = "CANDIDATE_LOGIN.SP_READ_STAFF_lANG_DETAILS";
                OracleCommand cmdReadTcs = new OracleCommand();
                cmdReadTcs.CommandText = strQueryReadTcs;
                cmdReadTcs.CommandType = CommandType.StoredProcedure;
                cmdReadTcs.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;

                cmdReadTcs.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeav = new DataTable();
                dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
                return dtLeav;
            }
            public DataTable ReadExperienceDetails(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryReadTcs = "CANDIDATE_LOGIN.SP_READ_STAFF_EXPRNC_DETAILS";
                OracleCommand cmdReadTcs = new OracleCommand();
                cmdReadTcs.CommandText = strQueryReadTcs;
                cmdReadTcs.CommandType = CommandType.StoredProcedure;
                cmdReadTcs.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;

                cmdReadTcs.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
                cmdReadTcs.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
                cmdReadTcs.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeav = new DataTable();
                dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
                return dtLeav;
            }
            public DataTable ReadQualification(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryReadTcs = "CANDIDATE_LOGIN.SP_READ_STAFF_QUAL_DETAILS";
                OracleCommand cmdReadTcs = new OracleCommand();
                cmdReadTcs.CommandText = strQueryReadTcs;
                cmdReadTcs.CommandType = CommandType.StoredProcedure;
                cmdReadTcs.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;

                cmdReadTcs.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
                cmdReadTcs.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
                cmdReadTcs.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeav = new DataTable();
                dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
                return dtLeav;
            }
            public DataTable ReadDepentantDetails(clsEntityCandidatelogin objEntityCandidate)
            {
                string strQueryReadTcs = "CANDIDATE_LOGIN.SP_READ_DEPENTANT_DETAILS";
                OracleCommand cmdReadTcs = new OracleCommand();
                cmdReadTcs.CommandText = strQueryReadTcs;
                cmdReadTcs.CommandType = CommandType.StoredProcedure;
                cmdReadTcs.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityCandidate.CandidateId;

                cmdReadTcs.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCandidate.Organisation_Id;
                cmdReadTcs.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityCandidate.CorpOffice_Id;
                cmdReadTcs.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtLeav = new DataTable();
                dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
                return dtLeav;
            }
        //END

    }
}
