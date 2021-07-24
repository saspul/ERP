using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerJoiningWorker
    {
        public DataTable ReadCandidateData(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryReadPayGrd = "JOINING_WORKER.SP_READ_CANDIDATE_DATA";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
            cmdReadJob.Parameters.Add("P_CAND_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.UserId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadCandidate(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryReadPayGrd = "JOINING_WORKER.SP_READ_CANDIDATES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
            cmdReadJob.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
            cmdReadJob.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadJoinigWorkerList(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryReadPayGrd = "JOINING_WORKER.SP_READ_JOINING_WORKER_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("J_CANCEL", OracleDbType.Int32).Value = objEntityJoiningWorker.CancelStatus;
            cmdReadJob.Parameters.Add("J_CONFIRM", OracleDbType.Int32).Value = objEntityJoiningWorker.ConfirmStatus;
            cmdReadJob.Parameters.Add("J_ORG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
            cmdReadJob.Parameters.Add("J_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
            cmdReadJob.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void InsertJoiningWorker(clsEntityJoiningWorker objEntityJoiningWorker, List<clsJoiningWorkerDtl> objEntityJoiningWorkerDetilsList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "JOINING_WORKER.SP_INSERT_JOINING_WORKER_MSTR";
                    using (OracleCommand cmdInsertJoiningWorker = new OracleCommand())
                    {
                        cmdInsertJoiningWorker.Transaction = tran;
                        cmdInsertJoiningWorker.Connection = con;
                        cmdInsertJoiningWorker.CommandText = strQueryInsertDsgn;
                        cmdInsertJoiningWorker.CommandType = CommandType.StoredProcedure;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
                        cmdInsertJoiningWorker.Parameters.Add("J_CAND_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CandidateID;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_PASSPORTNO", OracleDbType.Varchar2).Value = objEntityJoiningWorker.PassportNo;
                        if (objEntityJoiningWorker.JoiningDate == DateTime.MinValue)
                        {
                            cmdInsertJoiningWorker.Parameters.Add("J_WKR_JOINING_DATE", OracleDbType.Date).Value = null;
                        }
                        else
                        {
                            cmdInsertJoiningWorker.Parameters.Add("J_WKR_JOINING_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.JoiningDate;

                        }
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_DESIG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.Designation;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_DIVISION", OracleDbType.Int32).Value = objEntityJoiningWorker.Division;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_FRM_FLNG_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.FormFillDate;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_COMMENTS", OracleDbType.Varchar2).Value = objEntityJoiningWorker.Comments;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_SITE_NO", OracleDbType.Varchar2).Value = objEntityJoiningWorker.SiteNo;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_LICN_FILE_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.LicenceFileName;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_LICN_ACT_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.LicenceActualName;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_CRTF_FILE_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.CertificateFileName;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_CRTF_ACT_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.CertificateActualName;
                        cmdInsertJoiningWorker.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
                        cmdInsertJoiningWorker.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_INS_USR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.UserId;
                        cmdInsertJoiningWorker.Parameters.Add("J_WKR_INS_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.Date;
                        cmdInsertJoiningWorker.ExecuteNonQuery();
                    }

                    string strQueryInsertJoiningWorkerDtl = "JOINING_WORKER.SP_INSERT_JOINING_WORKER_DTL";
                    foreach (clsJoiningWorkerDtl objIntCatDtl in objEntityJoiningWorkerDetilsList)
                    {
                        using (OracleCommand cmdInsertJoiningWorkerDtl = new OracleCommand())
                        {
                            cmdInsertJoiningWorkerDtl.Transaction = tran;
                            cmdInsertJoiningWorkerDtl.Connection = con;
                            cmdInsertJoiningWorkerDtl.CommandText = strQueryInsertJoiningWorkerDtl;
                            cmdInsertJoiningWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertJoiningWorkerDtl.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
                            cmdInsertJoiningWorkerDtl.Parameters.Add("J_WKR_DTL_FILE_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuFileName;
                            cmdInsertJoiningWorkerDtl.Parameters.Add("J_WKR_DTL_ACT_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuActualName;
                            cmdInsertJoiningWorkerDtl.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
                            cmdInsertJoiningWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        public DataTable ReadJoinigWorkerByID(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryReadPayGrd = "JOINING_WORKER.SP_READ_JOINING_WORKER_BYID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("J_WORKER_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
            cmdReadJob.Parameters.Add("J_ORG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
            cmdReadJob.Parameters.Add("J_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
            cmdReadJob.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadJoinigWkrDtlByID(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryReadPayGrd = "JOINING_WORKER.SP_READ_JOINING_WKR_DTL_BYID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("J_WORKER_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;;
            cmdReadJob.Parameters.Add("J_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void UpdateJoiningWorker(clsEntityJoiningWorker objEntityJoiningWorker, List<clsJoiningWorkerDtl> objEntityJoiningWorkerDetilsList, List<clsJoiningWorkerDtl> objEntityJoiningWkrDtlsDELETEList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateDsgn = "JOINING_WORKER.SP_UPDATE_JOINING_WORKER_MSTR";
                    using (OracleCommand cmdUpdateJoiningWorker = new OracleCommand())
                    {
                        cmdUpdateJoiningWorker.Transaction = tran;
                        cmdUpdateJoiningWorker.Connection = con;
                        cmdUpdateJoiningWorker.CommandText = strQueryUpdateDsgn;
                        cmdUpdateJoiningWorker.CommandType = CommandType.StoredProcedure;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
                        cmdUpdateJoiningWorker.Parameters.Add("J_CAND_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CandidateID;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_PASSPORTNO", OracleDbType.Varchar2).Value = objEntityJoiningWorker.PassportNo;
                        if (objEntityJoiningWorker.JoiningDate == DateTime.MinValue)
                        {
                            cmdUpdateJoiningWorker.Parameters.Add("J_WKR_JOINING_DATE", OracleDbType.Date).Value = null;
                        }
                        else
                        {
                            cmdUpdateJoiningWorker.Parameters.Add("J_WKR_JOINING_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.JoiningDate;

                        }

                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_DESIG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.Designation;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_DIVISION", OracleDbType.Int32).Value = objEntityJoiningWorker.Division;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_FRM_FLNG_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.FormFillDate;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_COMMENTS", OracleDbType.Varchar2).Value = objEntityJoiningWorker.Comments;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_SITE_NO", OracleDbType.Varchar2).Value = objEntityJoiningWorker.SiteNo;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_LICN_FILE_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.LicenceFileName;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_LICN_ACT_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.LicenceActualName;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_CRTF_FILE_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.CertificateFileName;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_CRTF_ACT_NAME", OracleDbType.Varchar2).Value = objEntityJoiningWorker.CertificateActualName;
                        cmdUpdateJoiningWorker.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
                        cmdUpdateJoiningWorker.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_UPD_USR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.UserId;
                        cmdUpdateJoiningWorker.Parameters.Add("J_WKR_UPD_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.Date;
                        cmdUpdateJoiningWorker.ExecuteNonQuery();
                    }
                    string strQueryInsertJoiningWorkerDtl = "JOINING_WORKER.SP_INSERT_JOINING_WORKER_DTL";
                    foreach (clsJoiningWorkerDtl objIntCatDtl in objEntityJoiningWorkerDetilsList)
                    {
                        using (OracleCommand cmdUpdateJoiningWorkerDtl = new OracleCommand())
                        {
                            cmdUpdateJoiningWorkerDtl.Transaction = tran;
                            cmdUpdateJoiningWorkerDtl.Connection = con;
                            cmdUpdateJoiningWorkerDtl.CommandText = strQueryInsertJoiningWorkerDtl;
                            cmdUpdateJoiningWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateJoiningWorkerDtl.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
                            cmdUpdateJoiningWorkerDtl.Parameters.Add("J_WKR_DTL_FILE_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuFileName;
                            cmdUpdateJoiningWorkerDtl.Parameters.Add("J_WKR_DTL_ACT_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuActualName;
                            cmdUpdateJoiningWorkerDtl.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
                            cmdUpdateJoiningWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    string strQueryDeleteJoiningWorkerDtl = "JOINING_WORKER.SP_DELETE_JOINING_WRR_DTL";
                    foreach (clsJoiningWorkerDtl objIntCatDtl in objEntityJoiningWkrDtlsDELETEList)
                    {
                        using (OracleCommand cmdUpdateJoiningWorkerDtl = new OracleCommand())
                        {
                            cmdUpdateJoiningWorkerDtl.Transaction = tran;
                            cmdUpdateJoiningWorkerDtl.Connection = con;
                            cmdUpdateJoiningWorkerDtl.CommandText = strQueryDeleteJoiningWorkerDtl;
                            cmdUpdateJoiningWorkerDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateJoiningWorkerDtl.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objIntCatDtl.WorkerDetailID;
                            cmdUpdateJoiningWorkerDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        // This Method delete JoiningWkr details 
        public void CancelJoiningWkr(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryCancelJoiningWkr = "JOINING_WORKER.SP_CANCEL_JOINING_WRR";
            using (OracleCommand cmdCancelJoiningWkr = new OracleCommand())
            {
                cmdCancelJoiningWkr.CommandText = strQueryCancelJoiningWkr;
                cmdCancelJoiningWkr.CommandType = CommandType.StoredProcedure;
                cmdCancelJoiningWkr.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
                cmdCancelJoiningWkr.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
                cmdCancelJoiningWkr.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
                cmdCancelJoiningWkr.Parameters.Add("J_WKR_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.UserId;
                cmdCancelJoiningWkr.Parameters.Add("J_WKR_CNCL_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.Date;
                cmdCancelJoiningWkr.Parameters.Add("J_WKR_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityJoiningWorker.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelJoiningWkr);
            }
        }

        public void UpdateCnfrmSts(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryUpdateCnfrmSts = "JOINING_WORKER.SP_UPD_CONFRM_STS";
            using (OracleCommand cmdUpdateCnfrmSts = new OracleCommand())
            {
                cmdUpdateCnfrmSts.CommandText = strQueryUpdateCnfrmSts;
                cmdUpdateCnfrmSts.CommandType = CommandType.StoredProcedure;
                cmdUpdateCnfrmSts.Parameters.Add("J_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
                cmdUpdateCnfrmSts.Parameters.Add("J_ORG_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.OrgId;
                cmdUpdateCnfrmSts.Parameters.Add("J_CORPRT_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.CorpId;
                cmdUpdateCnfrmSts.Parameters.Add("J_WKR_CONFM_DATE", OracleDbType.Date).Value = objEntityJoiningWorker.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCnfrmSts);
            }
        }


        public string CheckPassNo(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            string strQueryCheckPassNo = "JOINING_WORKER.SP_CHECK_PASSPORT_DTLS";
            OracleCommand cmdUpdateCheckPassNo = new OracleCommand();
            cmdUpdateCheckPassNo.CommandText = strQueryCheckPassNo;
            cmdUpdateCheckPassNo.CommandType = CommandType.StoredProcedure;
            cmdUpdateCheckPassNo.Parameters.Add("P_WKR_ID", OracleDbType.Int32).Value = objEntityJoiningWorker.WorkerID;
            cmdUpdateCheckPassNo.Parameters.Add("P_NO", OracleDbType.Varchar2).Value = objEntityJoiningWorker.PassportNo;
            cmdUpdateCheckPassNo.Parameters.Add("P_ORGID", OracleDbType.Varchar2).Value = objEntityJoiningWorker.OrgId;
            cmdUpdateCheckPassNo.Parameters.Add("P_CORPRTID", OracleDbType.Varchar2).Value = objEntityJoiningWorker.CorpId;
            cmdUpdateCheckPassNo.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdUpdateCheckPassNo);
            string strReturn = cmdUpdateCheckPassNo.Parameters["P_OUT"].Value.ToString();
            cmdUpdateCheckPassNo.Dispose();
            return strReturn;
        }
    }
}
