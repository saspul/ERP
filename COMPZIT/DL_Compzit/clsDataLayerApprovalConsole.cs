using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit;
using CL_Compzit;

namespace DL_Compzit
{
    public class clsDataLayerApprovalConsole
    {

        public DataTable ReadDocuments()
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_DOCUMENTS";
            OracleCommand cmdApprvl = new OracleCommand();
            cmdApprvl.CommandText = strQuery;
            cmdApprvl.CommandType = CommandType.StoredProcedure;
            cmdApprvl.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdApprvl);
            return dt;
        }

        public DataTable ReadApprovalPendingList(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_APPROVAL_PENDING_LIST";
            OracleCommand cmdApprvl = new OracleCommand();
            cmdApprvl.CommandText = strQuery;
            cmdApprvl.CommandType = CommandType.StoredProcedure;
            cmdApprvl.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.CorpId;
            cmdApprvl.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.OrgId;
            cmdApprvl.Parameters.Add("P_USER_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdApprvl.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.DocId;
            cmdApprvl.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityApprvlCnsl.Status;
            if (objEntityApprvlCnsl.FromDate != DateTime.MinValue)
            {
                cmdApprvl.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objEntityApprvlCnsl.FromDate;
            }
            else
            {
                cmdApprvl.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = null;
            }
            if (objEntityApprvlCnsl.ToDate != DateTime.MinValue)
            {
                cmdApprvl.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntityApprvlCnsl.ToDate;
            }
            else
            {
                cmdApprvl.Parameters.Add("P_TODATE", OracleDbType.Date).Value = null;
            }

            //----------------------------------------Pageination--------------------------------------
            cmdApprvl.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.CommonSearchTerm;
            cmdApprvl.Parameters.Add("P_SEARCH_PRCHSORDR_REF", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.SearchRef;
            cmdApprvl.Parameters.Add("P_SEARCH_WRKFLW_NAME", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.SearchWrkflw;
            cmdApprvl.Parameters.Add("P_SEARCH_DOC_NAME", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.SearchDocumnt;
            cmdApprvl.Parameters.Add("P_SEARCH_PRCHSORDR_DATE", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.SearchDate;
            cmdApprvl.Parameters.Add("P_SEARCH_USR_NAME", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.SearchReqstor;
            cmdApprvl.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityApprvlCnsl.OrderColumn;
            cmdApprvl.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityApprvlCnsl.OrderMethod;
            cmdApprvl.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityApprvlCnsl.PageMaxSize;
            cmdApprvl.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityApprvlCnsl.PageNumber;
            //----------------------------------------Pageination--------------------------------------
            cmdApprvl.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdApprvl);
            return dt;
        }

        public DataTable ReadHierarchy(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_HIERCHY_BYID";
            OracleCommand cmdApprvl = new OracleCommand();
            cmdApprvl.CommandText = strQuery;
            cmdApprvl.CommandType = CommandType.StoredProcedure;
            cmdApprvl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.PurchsOrdrId;
            cmdApprvl.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityApprvlCnsl.Mode;
            cmdApprvl.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdApprvl.Parameters.Add("P_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.CommonSearchTerm;
            cmdApprvl.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdApprvl);
            return dt;
        }

        public DataTable ReadConditions(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_CONDITIONS";
            OracleCommand cmdApprvl = new OracleCommand();
            cmdApprvl.CommandText = strQuery;
            cmdApprvl.CommandType = CommandType.StoredProcedure;
            cmdApprvl.Parameters.Add("P_WRKFLOWID", OracleDbType.Int32).Value = objEntityApprvlCnsl.WrkFlowId;
            cmdApprvl.Parameters.Add("P_DSGNID", OracleDbType.Int32).Value = objEntityApprvlCnsl.DesignatnId;
            cmdApprvl.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdApprvl);
            return dt;
        }

        public DataTable CheckConditions(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_CONDITION_CHECK";
            OracleCommand cmdApprvl = new OracleCommand();
            cmdApprvl.CommandText = strQuery;
            cmdApprvl.CommandType = CommandType.StoredProcedure;
            cmdApprvl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.PurchsOrdrId;
            cmdApprvl.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.EmployeeId;
            cmdApprvl.Parameters.Add("P_CNDTNID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ConditionId;
            cmdApprvl.Parameters.Add("P_CNDTNTYPE", OracleDbType.Int32).Value = objEntityApprvlCnsl.ConditionType;
            cmdApprvl.Parameters.Add("P_VALUES", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.ConditionValues;
            cmdApprvl.Parameters.Add("P_MAXVAL", OracleDbType.Int32).Value = objEntityApprvlCnsl.ConditionMaxVal;
            cmdApprvl.Parameters.Add("P_MINVAL", OracleDbType.Int32).Value = objEntityApprvlCnsl.ConditionMinVal;
            cmdApprvl.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdApprvl);
            return dt;
        }

        public void ApproveRejectPurchaseOrder(clsEntityApprovalConsole objEntityApprvlCnsl, List<clsEntityApprovalConsole> objEntityApprvlCnslList, List<clsEntityApprovalConsole> objEntityApprvlCnslAddList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (clsEntityApprovalConsole objSubDetail in objEntityApprvlCnslList)
                    {
                        string strQuery = "PMS_APPROVALCONSOLE.SP_APPROVE_OR_REJECT";
                        using (OracleCommand cmdApprvl = new OracleCommand(strQuery, con))
                        {
                            cmdApprvl.Transaction = tran;
                            cmdApprvl.CommandType = CommandType.StoredProcedure;
                            cmdApprvl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objSubDetail.PurchsOrdrId;
                            cmdApprvl.Parameters.Add("P_ARPRVREJCT_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
                            cmdApprvl.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objSubDetail.EmployeeId;
                            cmdApprvl.Parameters.Add("P_REJCT_REASON", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.RejectReason;
                            cmdApprvl.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityApprvlCnsl.Mode;
                            cmdApprvl.ExecuteNonQuery();
                        }


                        if ((objEntityApprvlCnsl.Mode == 1 && objEntityApprvlCnsl.Status == 1) || objEntityApprvlCnsl.Mode == 2)
                        {
                            string strQuery1 = "PMS_APPROVALCONSOLE.SP_UPDATE_PURCHSORDER";
                            using (OracleCommand cmdApprvl = new OracleCommand(strQuery1, con))
                            {
                                cmdApprvl.Transaction = tran;
                                cmdApprvl.CommandType = CommandType.StoredProcedure;
                                cmdApprvl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objSubDetail.PurchsOrdrId;
                                cmdApprvl.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityApprvlCnsl.Mode;
                                cmdApprvl.ExecuteNonQuery();
                            }
                        }
                    }

                    foreach (clsEntityApprovalConsole objSubDetail in objEntityApprvlCnslAddList)
                    {
                        string strQuery = "PMS_APPROVALCONSOLE.SP_INSERT_APPROVAL_CONSOLE";
                        using (OracleCommand cmdApprvl = new OracleCommand(strQuery, con))
                        {
                            cmdApprvl.Transaction = tran;
                            cmdApprvl.CommandType = CommandType.StoredProcedure;
                            cmdApprvl.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.CorpId;
                            cmdApprvl.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.OrgId;
                            cmdApprvl.Parameters.Add("P_NEXT_USER_ID", OracleDbType.Int32).Value = objSubDetail.EmployeeId;
                            cmdApprvl.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = 1;
                            cmdApprvl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objSubDetail.PurchsOrdrId;
                            cmdApprvl.Parameters.Add("P_APRVL_USR_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
                            cmdApprvl.Parameters.Add("P_LEVEL", OracleDbType.Int32).Value = objSubDetail.Level;
                            cmdApprvl.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        //--------COMMENTS--------
        public DataTable ReadCommentDtls(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_COMMENTDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = 1;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void InsertComments(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_INSERT_COMMENTDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
            cmdPurchase.Parameters.Add("P_APRVLCNSLCMNT_VISBLSTS", OracleDbType.Int32).Value = objEntityApprvlCnsl.VisibleSts;
            cmdPurchase.Parameters.Add("P_APRVLCNSLCMNT_COMMENT", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.Comment;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }

        //--------NOTE--------
        public DataTable ReadNoteDetails(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_NOTEDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdPurchase.Parameters.Add("P_REPLYSTS", OracleDbType.Int32).Value = objEntityApprvlCnsl.ReplySts;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void InsertNote(clsEntityApprovalConsole objEntityApprvlCnsl, List<clsEntityApprovalConsole> objEntityApprvlCnslAttchmnts)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityApprvlCnsl.ReplySts == 1)
                    {
                        string strQuery = "PMS_APPROVALCONSOLE.SP_UPDATE_REPLYNOTE";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_NOTEID", OracleDbType.Int32).Value = objEntityApprvlCnsl.NoteId;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLNOTE_REPLY_MSG", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.NoteMsg;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string strQuery = "PMS_APPROVALCONSOLE.SP_INSERT_NOTE";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
                            cmdPurchase.Parameters.Add("P_TO_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.EmployeeId;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLNOTE_MSG", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.NoteMsg;
                            cmdPurchase.Parameters.Add("P_FROM_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
                            cmdPurchase.Parameters.Add("P_OUT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdPurchase.ExecuteNonQuery();
                            string strReturn = cmdPurchase.Parameters["P_OUT_ID"].Value.ToString();
                            objEntityApprvlCnsl.NoteId = Convert.ToInt32(strReturn);
                        }
                    }

                    foreach (clsEntityApprovalConsole objEntityDtl in objEntityApprvlCnslAttchmnts)
                    {
                        string strQueryDtl = "PMS_APPROVALCONSOLE.SP_INSERT_NOTE_ATTCH";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_NOTEID", OracleDbType.Int32).Value = objEntityApprvlCnsl.NoteId;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLATCHNT_FILENM", OracleDbType.Varchar2).Value = objEntityDtl.FileName;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLATCHNT_FILEACTNM", OracleDbType.Varchar2).Value = objEntityDtl.ActualFileName;
                            if (objEntityApprvlCnsl.ReplySts == 1)
                            {
                                cmdPurchase.Parameters.Add("P_APRVLCNSLATCHNT_TYPE", OracleDbType.Int32).Value = 1;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_APRVLCNSLATCHNT_TYPE", OracleDbType.Int32).Value = 0;
                            }
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        //--------ADDITIONAL DETAILS--------
        public DataTable ReadAdditionalDetails(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_ADDTNLDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdPurchase.Parameters.Add("P_REPLYSTS", OracleDbType.Int32).Value = objEntityApprvlCnsl.ReplySts;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void InsertAdditionalDetails(clsEntityApprovalConsole objEntityApprvlCnsl, List<clsEntityApprovalConsole> objEntityApprvlCnslAttchmnts)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityApprvlCnsl.ReplySts == 1)
                    {
                        string strQuery = "PMS_APPROVALCONSOLE.SP_UPDATE_REPLYADDTNL";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ADDTNLID", OracleDbType.Int32).Value = objEntityApprvlCnsl.AdditionalId;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLADTNL_REPLY_MSG", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.NoteMsg;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string strQuery = "PMS_APPROVALCONSOLE.SP_INSERT_ADDTNL";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
                            cmdPurchase.Parameters.Add("P_TO_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.EmployeeId;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLADTNL_MSG", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.NoteMsg;
                            cmdPurchase.Parameters.Add("P_FROM_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
                            cmdPurchase.Parameters.Add("P_OUT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdPurchase.ExecuteNonQuery();
                            string strReturn = cmdPurchase.Parameters["P_OUT_ID"].Value.ToString();
                            objEntityApprvlCnsl.AdditionalId = Convert.ToInt32(strReturn);
                        }
                    }

                    foreach (clsEntityApprovalConsole objEntityDtl in objEntityApprvlCnslAttchmnts)
                    {
                        string strQueryDtl = "PMS_APPROVALCONSOLE.SP_INSERT_ADDTNL_ATTCH";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ADDTNLID", OracleDbType.Int32).Value = objEntityApprvlCnsl.AdditionalId;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLATCHADDTN_FILENM", OracleDbType.Varchar2).Value = objEntityDtl.FileName;
                            cmdPurchase.Parameters.Add("P_APRVLCNSLATCHADDTN_FILEACTNM", OracleDbType.Varchar2).Value = objEntityDtl.ActualFileName;
                            if (objEntityApprvlCnsl.ReplySts == 1)
                            {
                                cmdPurchase.Parameters.Add("P_APRVLCNSLATCHADDTN_REPLYSTS", OracleDbType.Int32).Value = 1;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_APRVLCNSLATCHADDTN_REPLYSTS", OracleDbType.Int32).Value = 0;
                            }
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void InsertUsrViewComments(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_INSERT_CMNT_USER";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdPurchase.Parameters.Add("P_CNT", OracleDbType.Int32).Value = objEntityApprvlCnsl.Mode;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }

        public void InsertDelegate(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_INSERT_UPDATE_DELEGATE";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
            cmdPurchase.Parameters.Add("P_TO_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.EmployeeId;
            cmdPurchase.Parameters.Add("P_APRVLCNSLDLGT_MESSAGE", OracleDbType.Varchar2).Value = objEntityApprvlCnsl.NoteMsg;
            cmdPurchase.Parameters.Add("P_FROM_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }

        public DataTable ReadDelegateDtls(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_DELEGATE_MSG";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityApprvlCnsl.UserId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void DeleteForMajorityApproval(clsEntityApprovalConsole objEntityApprvlCnsl)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_DELETE_APPROVAL_CONSOLE";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityApprvlCnsl.ApprvlCnslId;
            cmdPurchase.Parameters.Add("P_LEVEL", OracleDbType.Int32).Value = objEntityApprvlCnsl.Level;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }


    }
}
