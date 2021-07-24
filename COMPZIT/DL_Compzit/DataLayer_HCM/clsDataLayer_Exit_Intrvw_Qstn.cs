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
    public class clsDataLayer_Exit_Intrvw_Qstn
    {
        public DataTable ReadDesignationBySearch(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_READ_DSGN_SEARCH";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }
        public DataTable ReadDesignation(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_READ_DESG";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }
        public void InsertExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityExitIntrvwQstnList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryDeleteInterviewCatDtl = "EXIT_INTRVW_QSTN.SP_UPD_COMMON_QSTNS";
            foreach (clsEntityLayer_Exit_Intrvw_Qstn_List objIntCatDtl in objEntityExitIntrvwQstnList)
            {
                using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                {
                    if (objIntCatDtl.CommonSts == 1)
                    {
                        cmdUpdateInterviewCatDtl.Transaction = tran;
                        cmdUpdateInterviewCatDtl.Connection = con;
                        cmdUpdateInterviewCatDtl.CommandText = strQueryDeleteInterviewCatDtl;
                        cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                        cmdUpdateInterviewCatDtl.Parameters.Add("E_COMMOM_QSTN_STS", OracleDbType.Int32).Value = objIntCatDtl.CommonSts;
                        cmdUpdateInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.InsUserId;
                        cmdUpdateInterviewCatDtl.ExecuteNonQuery();
                    }
                }
            }
           
                    string strQueryInsertInterviewCatDtl = "EXIT_INTRVW_QSTN.SP_INS_INTERVIEW_QUESTION";
                    foreach (clsEntityLayer_Exit_Intrvw_Qstn_List objIntQstns in objEntityExitIntrvwQstnList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;

                            if (objEntityExitIntrvwQstn.DesgId == 0)
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = null;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_QSTN", OracleDbType.Varchar2).Value = objIntQstns.Questions;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_COMMOM_QSTN_STS", OracleDbType.Int32).Value = objIntQstns.CommonSts;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.CorpId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_INS_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.InsUserId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_INS_DATE", OracleDbType.Date).Value = objEntityExitIntrvwQstn.InsDate;
                            }
                            else
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_QSTN", OracleDbType.Varchar2).Value = objIntQstns.Questions;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_COMMOM_QSTN_STS", OracleDbType.Int32).Value = objIntQstns.CommonSts;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.CorpId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_INS_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.InsUserId;
                                cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_INS_DATE", OracleDbType.Date).Value = objEntityExitIntrvwQstn.InsDate;
                            }
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
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
        public DataTable ReadDtls(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_READ_DTLS";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }
        public DataTable ReadDtlsById(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_READ_DTLS_BY_ID";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }
        public void UpdExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwINSERTList, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwUPDATEList, List<clsEntityLayer_Exit_Intrvw_Qstn_List> objEntityIntrvwDELETEList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    //INSERT DTL
                    string strQueryInterviewCatDtl = "EXIT_INTRVW_QSTN.SP_INS_INTERVIEW_QUESTION";
                    foreach (clsEntityLayer_Exit_Intrvw_Qstn_List objIntQstns in objEntityIntrvwINSERTList)
                    {
                        using (OracleCommand cmdUpdateCertfctBundel = new OracleCommand())
                        {
                            cmdUpdateCertfctBundel.Transaction = tran;
                            cmdUpdateCertfctBundel.Connection = con;
                            cmdUpdateCertfctBundel.CommandText = strQueryInterviewCatDtl;
                            cmdUpdateCertfctBundel.CommandType = CommandType.StoredProcedure;
                            if (objEntityExitIntrvwQstn.DesgId == 0)
                            {
                                cmdUpdateCertfctBundel.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdUpdateCertfctBundel.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                            }
                            cmdUpdateCertfctBundel.Parameters.Add("E_EXTINTRVQT_QSTN", OracleDbType.Varchar2).Value = objIntQstns.Questions;
                            cmdUpdateCertfctBundel.Parameters.Add("E_COMMOM_QSTN_STS", OracleDbType.Int32).Value = objIntQstns.CommonSts;
                            cmdUpdateCertfctBundel.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                            cmdUpdateCertfctBundel.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.CorpId;
                            cmdUpdateCertfctBundel.Parameters.Add("E_EXTINTRVQT_INS_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.InsUserId;
                            cmdUpdateCertfctBundel.Parameters.Add("E_EXTINTRVQT_INS_DATE", OracleDbType.Date).Value = objEntityExitIntrvwQstn.InsDate;
                            cmdUpdateCertfctBundel.ExecuteNonQuery();
                        }
                    }
                    //UPDATE
                    string strQueryInsertInterviewCatDtl = "EXIT_INTRVW_QSTN.SP_UPD_QUESTIONS";
                    foreach (clsEntityLayer_Exit_Intrvw_Qstn_List objIntCatDtl in objEntityIntrvwUPDATEList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_ID", OracleDbType.Int32).Value = objIntCatDtl.DtlId;
                            if (objEntityExitIntrvwQstn.DesgId == 0)
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                            }
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_QSTN", OracleDbType.Varchar2).Value = objIntCatDtl.Questions;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_COMMOM_QSTN_STS", OracleDbType.Int32).Value = objIntCatDtl.CommonSts;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_ORG_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_CORPRT_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.CorpId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_UPD_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.UpdUserId;
                            cmdInsertInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_UPD_DATE", OracleDbType.Date).Value = objEntityExitIntrvwQstn.UpdDate;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }


                    //DELETE
                    string strQueryDeleteInterviewCatDtl = "EXIT_INTRVW_QSTN.SP_DEL_INTERVIEW_QUESTION";
                    foreach (clsEntityLayer_Exit_Intrvw_Qstn_List objIntCatDtl in objEntityIntrvwDELETEList)
                    {
                        using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                        {
                            cmdUpdateInterviewCatDtl.Transaction = tran;
                            cmdUpdateInterviewCatDtl.Connection = con;
                            cmdUpdateInterviewCatDtl.CommandText = strQueryDeleteInterviewCatDtl;
                            cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateInterviewCatDtl.Parameters.Add("E_EXTINTRVQT_ID", OracleDbType.Int32).Value = objIntCatDtl.DtlId;
                            cmdUpdateInterviewCatDtl.ExecuteNonQuery();
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
        public void DelExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_CANCEL_INTERVIEW_QUESTION";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                cmdReadDesg.Parameters.Add("E_EXTINTRVQT_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.CnclUserId;
                cmdReadDesg.Parameters.Add("E_EXTINTRVQT_CNCL_USR_DATE", OracleDbType.Date).Value = objEntityExitIntrvwQstn.CnclDate;
                cmdReadDesg.Parameters.Add("EXTINTRVQT_CNCL_REASON", OracleDbType.Varchar2).Value = objEntityExitIntrvwQstn.CnclResn;
                clsDataLayer.ExecuteReader(cmdReadDesg);
            }
        }
        public DataTable SearchExitIntrvwQstn(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_READ_DTLS_BYSEARCH";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("J_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                cmdReadDesg.Parameters.Add("J_SEARCHSTS", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.SearchSts;
                cmdReadDesg.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.OrgId;
                cmdReadDesg.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.CorpId;
                cmdReadDesg.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }

        public DataTable GetCommonQuestions(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_READ_COMMON_QSTNS";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }

        public DataTable CheckSubTbl(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_CHECK_SUB_TBL";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwQstn.DesgId;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }

        public DataTable CountTransaction(clsEntityLayer_Exit_Intrvw_Qstn objEntityExitIntrvwQstn)
        {
            string strQueryReadDesg = "EXIT_INTRVW_QSTN.SP_COUNT_TRANSACTION";
            using (OracleCommand cmdReadDesg = new OracleCommand())
            {
                cmdReadDesg.CommandText = strQueryReadDesg;
                cmdReadDesg.CommandType = CommandType.StoredProcedure;
                cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
                return dtCust;
            }
        }
    }
}
