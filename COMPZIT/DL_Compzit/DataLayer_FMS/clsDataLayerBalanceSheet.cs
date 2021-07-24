using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using System.Data;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerBalanceSheet
    {
        public DataTable ReadPrimaryGroupDetails(clsEntityBalanceSheet objEntity)
        {
            string strQueryReadRcpt = "FMS_BALANCE_SHEET.SP_READ_PRIMARY_GROUP_DTLS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntity.Status;
            cmdReadRcpt.Parameters.Add("R_ZERO_STATUS", OracleDbType.Int32).Value = objEntity.ShowZerosts;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadSubGroupDetails(clsEntityBalanceSheet objEntity)
        {
            string strQueryReadRcpt = "FMS_BALANCE_SHEET.SP_READ_SUB_GROUP_DTLS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntity.Status;
            cmdReadRcpt.Parameters.Add("R_ACCNT_GROUP_ID", OracleDbType.Int32).Value = objEntity.AccountGroupId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadProfitLoss(clsEntityBalanceSheet objEntity)
        {
            string strQueryReadRcpt = "FMS_BALANCE_SHEET.SP_READ_PROFIT_AND_LOSS_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable TrailBalance_List_ById(clsEntityBalanceSheet objEntity)
        {
            string strQueryReadRcpt = "FMS_BALANCE_SHEET.SP_READ_TRAILBAL_LIST_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_LEDID", OracleDbType.Int32).Value = objEntity.LedgId;
            cmdReadRcpt.Parameters.Add("R_STS", OracleDbType.Int32).Value = objEntity.Status;
            cmdReadRcpt.Parameters.Add("R_ZERO_STATUS", OracleDbType.Int32).Value = objEntity.ShowZerosts;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable LedgerTransDtls(clsEntityBalanceSheet objEntity)
        {
            string strQueryReadRcpt = "FMS_BALANCE_SHEET.SP_READ_LEDG_TRANS_DTLS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_LEDID", OracleDbType.Int32).Value = objEntity.LedgId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadLedgOpenBal(clsEntityBalanceSheet objEntity)
        {
            string strQueryReadRcpt = "FMS_TRIAL_BAL.SP_READ_LEDG_OPEN_BAL";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate.AddDays(-1);
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_LEDID", OracleDbType.Int32).Value = objEntity.LedgId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
    }
}
