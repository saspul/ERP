using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;

namespace DL_Compzit.DataLayer_FMS
{
   public class clsDL_Tax_CollectedAt_Source
    {

       public void InsertTaxDeducted(clsEntityLayer_Tax_CollectedAt_Source objEntity)
       {
           string strQueryReadPayGrd = "TAXDEDUCTED_SOURCE.SP_INSERT_TAX_DEDUCTED";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntity.Name;
               cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objEntity.FromDate;
               cmdReadPayGrd.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntity.ToDate;
               cmdReadPayGrd.Parameters.Add("P_PERCENTEGE", OracleDbType.Decimal).Value = objEntity.Percentage;
               cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntity.Status;
               cmdReadPayGrd.Parameters.Add("P_RESDT_STS", OracleDbType.Int32).Value = objEntity.Resident_sts;
               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
              
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }
       public void UpdateTaxDeducted(clsEntityLayer_Tax_CollectedAt_Source objEntity)
       {
           string strQueryReadPayGrd = "TAXDEDUCTED_SOURCE.SP_UPD_TAX_DEDUCTED";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntity.TaxId;
               cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntity.Name;
               cmdReadPayGrd.Parameters.Add("P_FROMDATE", OracleDbType.Date).Value = objEntity.FromDate;
               cmdReadPayGrd.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntity.ToDate;
               cmdReadPayGrd.Parameters.Add("P_PERCENTEGE", OracleDbType.Decimal).Value = objEntity.Percentage;
               cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntity.Status;
               cmdReadPayGrd.Parameters.Add("P_RESDT_STS", OracleDbType.Int32).Value = objEntity.Resident_sts;
               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
              
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }


       public DataTable DuplicationCheckTaxName(clsEntityLayer_Tax_CollectedAt_Source objEntity)
        {
            string strQueryReadPayGrd = "TAXDEDUCTED_SOURCE.SP_READ_NAME_DUPCHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntity.TaxId;
            cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntity.Name;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

       public DataTable ReadTaxDeductionList(clsEntityLayer_Tax_CollectedAt_Source objEntity)
       {
           string strQueryReadPayGrd = "TAXDEDUCTED_SOURCE.SP_READ_TAXDEDCTN_LIST";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntity.Status;
           cmdReadPayGrd.Parameters.Add("P_RESSTS", OracleDbType.Int32).Value = objEntity.Resident_sts;
           cmdReadPayGrd.Parameters.Add("P_CANCL_STS", OracleDbType.Int32).Value = objEntity.cnclStatus;
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }

       public void CancelPerfomanceTemplate(clsEntityLayer_Tax_CollectedAt_Source objEntity)
       {
           string strQueryReadPayGrd = "TAXDEDUCTED_SOURCE.SP_CANCEL_TAX_DEDUCTED";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntity.TaxId;
               cmdReadPayGrd.Parameters.Add("P_CANCLREASON", OracleDbType.Varchar2).Value = objEntity.CancelReason;
              
               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;

               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }
       }


       public DataTable ReadTaxDeductionById(clsEntityLayer_Tax_CollectedAt_Source objEntity)
       {
           string strQueryReadPayGrd = "TAXDEDUCTED_SOURCE.SP_READ_TAXDEDCTN_BYID";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadPayGrd;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntity.TaxId;
        
           cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;

           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtCategory;
       }


    }
}
