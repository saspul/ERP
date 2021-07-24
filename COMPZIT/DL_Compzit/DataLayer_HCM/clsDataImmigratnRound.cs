using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;


namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataImmigratnRound
    {
        //Insert into the tables
        public void InsertImmigratnRound(clsEntityImmigratnRound objEntityLayerImgratnRnd, List<clsEntityImmigratnRoundDetails> objEntityLayerImgratnRndDtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strinsertimgrnd = "IMMIGRATN_ROUND.SP_INS_IMGRATN_RND_MSTR";
                    using (OracleCommand cmdInsImgrtnrnd = new OracleCommand())
                    {
                        cmdInsImgrtnrnd.Transaction = tran;
                        cmdInsImgrtnrnd.Connection = con;

                        cmdInsImgrtnrnd.CommandText = strinsertimgrnd;
                        cmdInsImgrtnrnd.CommandType = CommandType.StoredProcedure;
                        cmdInsImgrtnrnd.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                        cmdInsImgrtnrnd.Parameters.Add("R_IMGRTNRND_NAME", OracleDbType.Varchar2).Value = objEntityLayerImgratnRnd.ImgratnRound_Name;
                        cmdInsImgrtnrnd.Parameters.Add("R_IMGRATNRND_STATUS", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Status;
                        cmdInsImgrtnrnd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
                        cmdInsImgrtnrnd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                        cmdInsImgrtnrnd.Parameters.Add("R_INS_USR_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.UserId;
                        cmdInsImgrtnrnd.Parameters.Add("R_INS_USR_DATE", OracleDbType.Date).Value = objEntityLayerImgratnRnd.Date;
                        cmdInsImgrtnrnd.ExecuteNonQuery();
                    }

                    string strinsertimgrnddtls = "IMMIGRATN_ROUND.SP_INS_IMGRATN_RND_DTLS";

                    foreach (clsEntityImmigratnRoundDetails objRnddtl in objEntityLayerImgratnRndDtls)
                    {
                        using (OracleCommand cmdinsImgrtnrndDtls = new OracleCommand())
                        {
                            cmdinsImgrtnrndDtls.Transaction = tran;
                            cmdinsImgrtnrndDtls.Connection = con;

                            cmdinsImgrtnrndDtls.CommandText = strinsertimgrnddtls;
                            cmdinsImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                            cmdinsImgrtnrndDtls.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Id;
                            cmdinsImgrtnrndDtls.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                            cmdinsImgrtnrndDtls.Parameters.Add("R_IMGRTNRNDDTL_NAME", OracleDbType.Varchar2).Value = objRnddtl.ImgratnRoundDtl_Name;
                            cmdinsImgrtnrndDtls.Parameters.Add("R_IMGRTNRNDDTL_STATUS", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Status;
                            cmdinsImgrtnrndDtls.Parameters.Add("R_IMGRTNRNDDTL_CMPLT", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Cmplt;
                            cmdinsImgrtnrndDtls.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                            cmdinsImgrtnrndDtls.ExecuteNonQuery();
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


        //Checking duplication of Rnd name 
        public string CheckDupImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            string strQueryCheckDsgnName = "IMMIGRATN_ROUND.SP_CHECK_IMGRATN_RND_MSTR";
            OracleCommand cmdCheckImgratnRndName = new OracleCommand();
            cmdCheckImgratnRndName.CommandText = strQueryCheckDsgnName;
            cmdCheckImgratnRndName.CommandType = CommandType.StoredProcedure;
            if (objEntityLayerImgratnRnd.ImgratnRound_Id == 0)
            {
                cmdCheckImgratnRndName.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdCheckImgratnRndName.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
            }
            cmdCheckImgratnRndName.Parameters.Add("R_IMGRTNRND_NAME", OracleDbType.Varchar2).Value = objEntityLayerImgratnRnd.ImgratnRound_Name;
            cmdCheckImgratnRndName.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
            cmdCheckImgratnRndName.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
            cmdCheckImgratnRndName.Parameters.Add("R_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckImgratnRndName);
            string strReturn = cmdCheckImgratnRndName.Parameters["R_COUNT"].Value.ToString();
            cmdCheckImgratnRndName.Dispose();
            return strReturn;
        }



        //Read immigratn rnds
        public DataTable ReadImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            DataTable dtImgratnRnd = new DataTable();
            using (OracleCommand cmdReadImgratnRnd = new OracleCommand())
            {
                cmdReadImgratnRnd.CommandText = "IMMIGRATN_ROUND.SP_READ_IMGRATN_RND_MSTR";
                cmdReadImgratnRnd.CommandType = CommandType.StoredProcedure;
                cmdReadImgratnRnd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
                cmdReadImgratnRnd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                cmdReadImgratnRnd.Parameters.Add("R_OPTION", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Status;
                cmdReadImgratnRnd.Parameters.Add("R_CANCEL", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CancelStatus;
                cmdReadImgratnRnd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtImgratnRnd = clsDataLayer.SelectDataTable(cmdReadImgratnRnd);
            }
            return dtImgratnRnd;
        }


        //Read immigratn rnds by id
        public DataTable ReadImgratnRndByID(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            DataTable dtImgratnRndByID = new DataTable();
            using (OracleCommand cmdReadImgratnRndByID = new OracleCommand())
            {
                cmdReadImgratnRndByID.CommandText = "IMMIGRATN_ROUND.SP_READ_IMGRATN_RND_BYID";
                cmdReadImgratnRndByID.CommandType = CommandType.StoredProcedure;
                cmdReadImgratnRndByID.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                cmdReadImgratnRndByID.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
                cmdReadImgratnRndByID.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                cmdReadImgratnRndByID.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtImgratnRndByID = clsDataLayer.SelectDataTable(cmdReadImgratnRndByID);
            }
            return dtImgratnRndByID;
        }


        //Update the tables
        public void UpdateImmigratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd, List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlINSERTList,List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlUPDATEList,List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlDELETEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    //Update ImgratnRnds
                    string strQueryUpdateDsgn = "IMMIGRATN_ROUND.SP_UPD_IMGRATN_RND_MSTR";
                    using (OracleCommand cmdUpdateImgratnRnd = new OracleCommand())
                    {
                        cmdUpdateImgratnRnd.Transaction = tran;
                        cmdUpdateImgratnRnd.Connection = con;
                        cmdUpdateImgratnRnd.CommandText = strQueryUpdateDsgn;
                        cmdUpdateImgratnRnd.CommandType = CommandType.StoredProcedure;
                        cmdUpdateImgratnRnd.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                        cmdUpdateImgratnRnd.Parameters.Add("R_IMGRTNRND_NAME", OracleDbType.Varchar2).Value = objEntityLayerImgratnRnd.ImgratnRound_Name;
                        cmdUpdateImgratnRnd.Parameters.Add("R_IMGRTNRND_STATUS", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Status;
                        cmdUpdateImgratnRnd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
                        cmdUpdateImgratnRnd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                        cmdUpdateImgratnRnd.Parameters.Add("R_IMGRTNRND_UPD_USR_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.UserId;
                        cmdUpdateImgratnRnd.Parameters.Add("R_IMGRTNRND_UPD_DATE", OracleDbType.Date).Value = objEntityLayerImgratnRnd.Date;
                        cmdUpdateImgratnRnd.ExecuteNonQuery();
                    }

                    //INSERT ImgratnRnd Details
                    foreach (clsEntityImmigratnRoundDetails objRnddtl in objEntityImgratnRndDtlINSERTList)
                    {
                        //if rnddtlcomplt=1,then rest=0 and insert
                        if (objRnddtl.ImgratnRoundDtl_Cmplt == 1)
                        {
                            string strQueryInsertCompltDlt = "IMMIGRATN_ROUND.SP_CHNG_DEL_BFR_DTLS";
                            using (OracleCommand cmdAddInsertCompltDlt = new OracleCommand(strQueryInsertCompltDlt, con))
                            {
                                cmdAddInsertCompltDlt.Transaction = tran;
                                cmdAddInsertCompltDlt.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertCompltDlt.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Id;
                                cmdAddInsertCompltDlt.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                                cmdAddInsertCompltDlt.Parameters.Add("R_IMGRTNRNDDTL_CMPLT", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Cmplt;
                                cmdAddInsertCompltDlt.ExecuteNonQuery();
                            }

                        }

                        //else simply insert rnddtls 
                        string strQueryInsertImgratnRndDtl = "IMMIGRATN_ROUND.SP_INS_IMGRATN_RND_DTLS";

                        using (OracleCommand cmdInsertImgratnRndDtls = new OracleCommand())
                        {
                            cmdInsertImgratnRndDtls.Transaction = tran;
                            cmdInsertImgratnRndDtls.Connection = con;
                            cmdInsertImgratnRndDtls.CommandText = strQueryInsertImgratnRndDtl;
                            cmdInsertImgratnRndDtls.CommandType = CommandType.StoredProcedure;
                            cmdInsertImgratnRndDtls.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Id;
                            cmdInsertImgratnRndDtls.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                            cmdInsertImgratnRndDtls.Parameters.Add("R_IMGRTNRNDDTL_NAME", OracleDbType.Varchar2).Value = objRnddtl.ImgratnRoundDtl_Name;
                            cmdInsertImgratnRndDtls.Parameters.Add("R_IMGRTNRNDDTL_STATUS", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Status;
                            cmdInsertImgratnRndDtls.Parameters.Add("R_IMGRTNRNDDTL_CMPLT", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Cmplt;
                            cmdInsertImgratnRndDtls.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                            
                            cmdInsertImgratnRndDtls.ExecuteNonQuery();
                        }
                    }


                    //UPDATE ImgratnRnd Details
                    
                    foreach (clsEntityImmigratnRoundDetails objRnddtl in objEntityImgratnRndDtlUPDATEList)
                    {

                        //if rnddtlcomplt=1,then rest=0 and update
                        if (objRnddtl.ImgratnRoundDtl_Cmplt == 1)
                        {
                            string strQueryInsertCompltDlt = "IMMIGRATN_ROUND.SP_CHNG_DEL_BFR_DTLS";
                            using (OracleCommand cmdAddInsertCompltDlt = new OracleCommand(strQueryInsertCompltDlt, con))
                            {
                                cmdAddInsertCompltDlt.Transaction = tran;
                                cmdAddInsertCompltDlt.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertCompltDlt.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Id;
                                cmdAddInsertCompltDlt.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                                cmdAddInsertCompltDlt.Parameters.Add("R_IMGRTNRNDDTL_CMPLT", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Cmplt;
                                cmdAddInsertCompltDlt.ExecuteNonQuery();
                            }

                        }


                        string strQueryUpdateImgratnRndDtl = "IMMIGRATN_ROUND.SP_UPD_IMGRATN_RND_DTLS";
                        using (OracleCommand cmdUpdateImgratnRndDtl = new OracleCommand())
                        {
                            cmdUpdateImgratnRndDtl.Transaction = tran;
                            cmdUpdateImgratnRndDtl.Connection = con;
                            cmdUpdateImgratnRndDtl.CommandText = strQueryUpdateImgratnRndDtl;
                            cmdUpdateImgratnRndDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateImgratnRndDtl.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Id;
                            cmdUpdateImgratnRndDtl.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                            cmdUpdateImgratnRndDtl.Parameters.Add("R_IMGRTNRNDDTL_NAME", OracleDbType.Varchar2).Value = objRnddtl.ImgratnRoundDtl_Name;
                            cmdUpdateImgratnRndDtl.Parameters.Add("R_IMGRTNRNDDTL_STATUS", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Status;
                            cmdUpdateImgratnRndDtl.Parameters.Add("R_IMGRTNRNDDTL_CMPLT", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Cmplt;
                            cmdUpdateImgratnRndDtl.ExecuteNonQuery();
                        }
                    }
                    //DELETE ImgratnRnd Details
                    string strQueryDeleteImgratnRndDtl = "IMMIGRATN_ROUND.SP_DEL_IMGRATN_RND_DTLS";
                    foreach (clsEntityImmigratnRoundDetails objRnddtl in objEntityImgratnRndDtlDELETEList)
                    {
                        using (OracleCommand cmdDelImgratnRndDtl = new OracleCommand())
                        {
                            cmdDelImgratnRndDtl.Transaction = tran;
                            cmdDelImgratnRndDtl.Connection = con;
                            cmdDelImgratnRndDtl.CommandText = strQueryDeleteImgratnRndDtl;
                            cmdDelImgratnRndDtl.CommandType = CommandType.StoredProcedure;
                            cmdDelImgratnRndDtl.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objRnddtl.ImgratnRoundDtl_Id;
                            cmdDelImgratnRndDtl.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                            cmdDelImgratnRndDtl.ExecuteNonQuery();
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



        public void CancelImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            string strQueryCancelImgratnRnd = "IMMIGRATN_ROUND.SP_CANCEL_IMGRATN_RND_MSTR";
            using (OracleCommand cmdCancelImgratnRnd = new OracleCommand())
            {
                cmdCancelImgratnRnd.CommandText = strQueryCancelImgratnRnd;
                cmdCancelImgratnRnd.CommandType = CommandType.StoredProcedure;
                cmdCancelImgratnRnd.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                cmdCancelImgratnRnd.Parameters.Add("R_IMGRTNRND_CNCL_DATE", OracleDbType.Date).Value = objEntityLayerImgratnRnd.Date;
                cmdCancelImgratnRnd.Parameters.Add("R_IMGRTNRND_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityLayerImgratnRnd.CancelReason;
                cmdCancelImgratnRnd.Parameters.Add("R_IMGRTNRND_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.UserId;
                cmdCancelImgratnRnd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
                cmdCancelImgratnRnd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                cmdCancelImgratnRnd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdCancelImgratnRnd);
            }
        }


        
        public void StatusChangeImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            string strQueryStatus = "IMMIGRATN_ROUND.SP_STATUS_CHANGE_IMGRATN_RND";
            using (OracleCommand cmdStatusChng = new OracleCommand())
            {
                cmdStatusChng.CommandText = strQueryStatus;
                cmdStatusChng.CommandType = CommandType.StoredProcedure;
                cmdStatusChng.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                cmdStatusChng.Parameters.Add("R_IMGRTNRND_UPD_USR_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.UserId;
                cmdStatusChng.Parameters.Add("R_IMGRTNRND_UPD_DATE", OracleDbType.Date).Value = objEntityLayerImgratnRnd.Date;
                cmdStatusChng.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.OrgId;
                cmdStatusChng.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.CorpId;
                clsDataLayer.ExecuteNonQuery(cmdStatusChng);
            }
        }

        public DataTable CheckCancelImgrtnRndId(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            string strQueryCheckCancel = "IMMIGRATN_ROUND.SP_CHECK_CANCL_IMGRATN_RNDID";
            DataTable dtCancel = new DataTable();
            using (OracleCommand cmdCheckCancel = new OracleCommand())
            {
                cmdCheckCancel.CommandText = strQueryCheckCancel;
                cmdCheckCancel.CommandType = CommandType.StoredProcedure;
                cmdCheckCancel.Parameters.Add("R_IMGRTNRND_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRound_Id;
                cmdCheckCancel.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCancel = clsDataLayer.SelectDataTable(cmdCheckCancel);
            }
            return dtCancel;
        }


        public DataTable CheckDeleteImgrtnRndDtlId(clsEntityImmigratnRoundDetails objEntityLayerImgratnRnd)
        {
            string strQueryCheckCancel = "IMMIGRATN_ROUND.SP_CHECK_DEL_IMGRATN_RNDDTLID";
            DataTable dtCancel = new DataTable();
            using (OracleCommand cmdCheckCancel = new OracleCommand())
            {
                cmdCheckCancel.CommandText = strQueryCheckCancel;
                cmdCheckCancel.CommandType = CommandType.StoredProcedure;
                cmdCheckCancel.Parameters.Add("R_IMGRTNRNDDTL_ID", OracleDbType.Int32).Value = objEntityLayerImgratnRnd.ImgratnRoundDtl_Id;
                cmdCheckCancel.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCancel = clsDataLayer.SelectDataTable(cmdCheckCancel);
            }
            return dtCancel;
        }




    }
}
