using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_FMS
{
   public class clsDataLayer_Trial_Bal
    {

        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        public DataTable TrailBalance_List(clsEntity_Trial_Bal objEntity)
        {
            string strQueryReadRcpt = "FMS_TRIAL_BAL.SP_READ_TRAILBAL_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable TrailBalance_ListLed(clsEntity_Trial_Bal objEntity)
        {
            string strQueryReadRcpt = "FMS_TRIAL_BAL.SP_READ_TRAILBAL_LIST_LEDGR";
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
        public DataTable TrailBalance_List_ById(clsEntity_Trial_Bal objEntity)
        {
            string strQueryReadRcpt = "FMS_TRIAL_BAL.SP_READ_TRAILBAL_LIST_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
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
        public DataTable LedgerTransDtls(clsEntity_Trial_Bal objEntity)
        {
            string strQueryReadRcpt = "FMS_TRIAL_BAL.SP_READ_LEDG_TRANS_DTLS";
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
        public DataTable ReadLedgOpenBal(clsEntity_Trial_Bal objEntity)
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
        public DataTable TrailBalance_List_Detail(clsEntity_Trial_Bal objEntity)
        {
            string strQueryReadRcpt = "FMS_TRIAL_BAL.SP_READ_TRAILBAL_LIST_DETAIL";
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
    }
}
