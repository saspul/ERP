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
   public class clsDataLayer_BankReconciliation
    {


       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

       public DataTable ReadLeadger(clsEntityBankReconciliation objEntity)
       {
           string strQueryReadRcpt = "FMS_BANK_RECONCILIATION.SP_ACCNT_LEDGER_READ";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable BankReconciliation_List(clsEntityBankReconciliation objEntity)
       {
           string strQueryReadRcpt = "FMS_BANK_RECONCILIATION.SP_BANK_RECOCILIATION_LST";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_DATEFROM", OracleDbType.Date).Value = objEntity.FromDate;
           cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
           cmdReadRcpt.Parameters.Add("R_VOUCHERTYP", OracleDbType.Int32).Value = objEntity.VoucherTyp;
           cmdReadRcpt.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntity.Status;

           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadBankReconciliationById(clsEntityBankReconciliation objEntity)
       {
           string strQueryReadRcpt = "FMS_BANK_RECONCILIATION.SP_BANK_RECOCILIATION_BYID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
          // cmdReadRcpt.Parameters.Add("R_VOUCHERTYP", OracleDbType.Int32).Value = objEntity.LedgId;
          cmdReadRcpt.Parameters.Add("R_LEDID", OracleDbType.Int32).Value = objEntity.LedgId;
          cmdReadRcpt.Parameters.Add("R_VOUCHERTYP", OracleDbType.Int32).Value = objEntity.VoucherTyp;

           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public void SaveReconciliation(clsEntityBankReconciliation objEntity, string[] strarrdtlIds)
       {
               


           foreach (string strDtlId in strarrdtlIds)
           {
               if (strDtlId != "" && strDtlId != null)
               {
                   int intDtlId = Convert.ToInt32(strDtlId);

                   string strQueryReadRcpt = "FMS_BANK_RECONCILIATION.SP_ACCOUNT_RECONCILIATION";
                   OracleCommand cmdReadRcpt = new OracleCommand();
                   
                   

                       cmdReadRcpt.CommandText = strQueryReadRcpt;
                       cmdReadRcpt.CommandType = CommandType.StoredProcedure;

                       cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
                       cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
                       cmdReadRcpt.Parameters.Add("R_VOUCHERID", OracleDbType.Int32).Value = intDtlId;
                       cmdReadRcpt.Parameters.Add("R_VOUCHERTYP", OracleDbType.Int32).Value = objEntity.VoucherTyp;
                      // cmdReadRcpt.Parameters.Add("B_CHKBOOKID", OracleDbType.Int32).Value = intDtlId;
                       clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
                      // cmdCancelDetail.ExecuteNonQuery();
                   
               }
           }

        
         
       }
       public void Recall_Reconciled(clsEntityBankReconciliation objEntity)
       {
           string strQuerylWelfare = "FMS_BANK_RECONCILIATION.SP_ACCOUNT_RECONCITON_RECALL";
           using (OracleCommand cmdlWelfare = new OracleCommand())
           {
               cmdlWelfare.CommandText = strQuerylWelfare;
               cmdlWelfare.CommandType = CommandType.StoredProcedure;
               cmdlWelfare.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
               cmdlWelfare.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
               cmdlWelfare.Parameters.Add("R_VOUCHERID", OracleDbType.Int32).Value = objEntity.LedgId;
               cmdlWelfare.Parameters.Add("R_VOUCHERTYP", OracleDbType.Int32).Value = objEntity.VoucherTyp;
               clsDataLayer.ExecuteNonQuery(cmdlWelfare);
           }
       }
    }
}
