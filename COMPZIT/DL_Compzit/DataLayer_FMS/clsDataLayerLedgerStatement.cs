using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerLedgerStatement
    {

        public DataTable ReadLedgers(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_LEDGERS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            cmdReadPayGrd.Parameters.Add("R_SUBLDGRSTS", OracleDbType.Int32).Value = objEntityLedgerStmnt.SubLedgerStatus;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        //0039
        public DataTable Readvoucherinfo(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_VOUCHER";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_VACC", OracleDbType.Int32).Value = objEntityLedgerStmnt.VoucherAccId;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }
        //end

        public DataTable ReadLedgerStatementMain(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_LEDGER_STATMNT_MAIN";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            if (objEntityLedgerStmnt.LedgerIds != "''")
                cmdReadPayGrd.Parameters.Add("R_LEDGERS", OracleDbType.Varchar2).Value = objEntityLedgerStmnt.LedgerIds;
            else
                cmdReadPayGrd.Parameters.Add("R_LEDGERS", OracleDbType.Varchar2).Value = null;
            if (objEntityLedgerStmnt.FromDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = objEntityLedgerStmnt.FromDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityLedgerStmnt.ToDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = objEntityLedgerStmnt.ToDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("R_LDGRFRM", OracleDbType.Int32).Value = objEntityLedgerStmnt.LedgerFromRange;
            cmdReadPayGrd.Parameters.Add("R_LDGRTO", OracleDbType.Int32).Value = objEntityLedgerStmnt.LedgerToRange;
            cmdReadPayGrd.Parameters.Add("R_H1FRM", OracleDbType.Int32).Value = objEntityLedgerStmnt.H1LedgerFromRange;
            cmdReadPayGrd.Parameters.Add("R_H1TO", OracleDbType.Int32).Value = objEntityLedgerStmnt.H1LedgerToRange;
            cmdReadPayGrd.Parameters.Add("R_H2FRM", OracleDbType.Int32).Value = objEntityLedgerStmnt.H2LedgerFromRange;
            cmdReadPayGrd.Parameters.Add("R_H2TO", OracleDbType.Int32).Value = objEntityLedgerStmnt.H2LedgerToRange;
            cmdReadPayGrd.Parameters.Add("R_CCFRM", OracleDbType.Int32).Value = objEntityLedgerStmnt.CCFromRange;
            cmdReadPayGrd.Parameters.Add("R_CCTO", OracleDbType.Int32).Value = objEntityLedgerStmnt.CCToRange;
            if (objEntityLedgerStmnt.AccountGrpId != 0)
            {
                cmdReadPayGrd.Parameters.Add("R_ACCID", OracleDbType.Int32).Value = objEntityLedgerStmnt.AccountGrpId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_ACCID", OracleDbType.Int32).Value = null;

            }
            cmdReadPayGrd.Parameters.Add("R_ALLLDGR", OracleDbType.Int32).Value = objEntityLedgerStmnt.AllLedgersStatus;
            cmdReadPayGrd.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntityLedgerStmnt.Mode;
            cmdReadPayGrd.Parameters.Add("R_SUBLDGRSTS", OracleDbType.Int32).Value = objEntityLedgerStmnt.SubLedgerStatus;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        public DataTable ReadLedgerStatementDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_LEDGER_STATMNT_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            cmdReadPayGrd.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntityLedgerStmnt.Ledger;
            if (objEntityLedgerStmnt.FromDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = objEntityLedgerStmnt.FromDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityLedgerStmnt.ToDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = objEntityLedgerStmnt.ToDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }


        public DataTable ReadLedgerStatementCostCentreDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_LEDGER_STATMNT_CC_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            cmdReadPayGrd.Parameters.Add("R_VOCHERID", OracleDbType.Int32).Value = objEntityLedgerStmnt.VoucherId;
            if (objEntityLedgerStmnt.FromDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = objEntityLedgerStmnt.FromDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityLedgerStmnt.ToDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = objEntityLedgerStmnt.ToDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        public DataTable ReadPostdatedChqDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_POSTDTCHQS_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            cmdReadPayGrd.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntityLedgerStmnt.Ledger;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        public DataTable ReadCodes(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_CODES";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            cmdReadPayGrd.Parameters.Add("R_CODETYPE", OracleDbType.Int32).Value = objEntityLedgerStmnt.CodeType;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        public DataTable ReadLedgerStatementAsPerDtls(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_LEDGER_ASPERDTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityLedgerStmnt.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityLedgerStmnt.CorpId;
            cmdReadPayGrd.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntityLedgerStmnt.Ledger;
            if (objEntityLedgerStmnt.FromDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = objEntityLedgerStmnt.FromDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_FRMDATE", OracleDbType.Date).Value = DBNull.Value;
            }
            if (objEntityLedgerStmnt.ToDate != DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = objEntityLedgerStmnt.ToDate;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("R_TODATE", OracleDbType.Date).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("R_VCHRACNTID", OracleDbType.Int32).Value = objEntityLedgerStmnt.VoucherAccntId;
            cmdReadPayGrd.Parameters.Add("R_VCHRID", OracleDbType.Int32).Value = objEntityLedgerStmnt.VoucherId;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }


        public DataTable ReadJournalRemove(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_JRNLRMV";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        public DataTable ReadJournalInsert(clsEntityLedgerStatement objEntityLedgerStmnt)
        {
            string strQueryText = "FMS_LEDGER_STATEMENT.SP_READ_JRNLINSERT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_VCHRID", OracleDbType.Int32).Value = objEntityLedgerStmnt.VoucherId;
            cmdReadPayGrd.Parameters.Add("R_VCHRACNTID", OracleDbType.Int32).Value = objEntityLedgerStmnt.VoucherAccntId;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }

        public void DeleteAndInsertJrnl(List<clsEntityLedgerStatement> objEntityDELETE, List<clsEntityLedgerStatement> objEntityINSERT)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    foreach (clsEntityLedgerStatement objSubDetail in objEntityDELETE)
                    {
                        string strQuerySubDetails = "FMS_LEDGER_STATEMENT.SP_DELETE_MULTIPLE";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("R_VCHRID", OracleDbType.Int32).Value = objSubDetail.VoucherId;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityLedgerStatement objSubDetail in objEntityINSERT)
                    {
                        string strQuerySubDetails = "FMS_LEDGER_STATEMENT.SP_DELETE_INSERT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("R_VCHRID", OracleDbType.Int32).Value = objSubDetail.VoucherId;
                            cmdAddSubDetail.Parameters.Add("R_LDGID", OracleDbType.Int32).Value = objSubDetail.Ledger;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }


                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
        }


    }
}
