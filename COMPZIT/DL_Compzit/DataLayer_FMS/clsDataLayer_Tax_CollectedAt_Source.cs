using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
namespace DL_Compzit.DataLayer_FMS
{
 public  class clsDataLayer_Tax_CollectedAt_Source
    {

     public void InsertTaxCollectedAtSource(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
     {

         OracleTransaction tran;


         using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
         {
             con.Open();

             tran = con.BeginTransaction();

             try
             {
                 string strQueryAddTaxCollectedAtSource = "FMS_TAX_COLLECTED_AT_SOURCE.SP_INS_TCS";
                 using (OracleCommand cmdAddTaxCollectedAtSource = new OracleCommand(strQueryAddTaxCollectedAtSource, con))
                 {
                     cmdAddTaxCollectedAtSource.CommandType = CommandType.StoredProcedure;
                     clsEntityCommon objEntCommon = new clsEntityCommon();
        
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTCS.Name;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_PRCNTG", OracleDbType.Decimal).Value = objEntityTCS.Percentage;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_FROM_DATE", OracleDbType.Date).Value = objEntityTCS.FromDate;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_TO_DATE", OracleDbType.Date).Value = objEntityTCS.ToDate;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_RESIDENT_STS", OracleDbType.Int32).Value = objEntityTCS.Resident_sts;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_STS", OracleDbType.Int32).Value = objEntityTCS.Status;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_INS_USRID", OracleDbType.Int32).Value = objEntityTCS.User_Id;
                     cmdAddTaxCollectedAtSource.ExecuteNonQuery();

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
     public void UpdateTaxCollectedAtSource(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
     {

         OracleTransaction tran;


         using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
         {
             con.Open();

             tran = con.BeginTransaction();

             try
             {
                 string strQueryAddTaxCollectedAtSource = "FMS_TAX_COLLECTED_AT_SOURCE.SP_UPDATE_TCS";
                 using (OracleCommand cmdAddTaxCollectedAtSource = new OracleCommand(strQueryAddTaxCollectedAtSource, con))
                 {
                     cmdAddTaxCollectedAtSource.CommandType = CommandType.StoredProcedure;
                     clsEntityCommon objEntCommon = new clsEntityCommon();
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_TCS_ID", OracleDbType.Int32).Value = objEntityTCS.TcsId;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTCS.Name;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_PRCNTG", OracleDbType.Decimal).Value = objEntityTCS.Percentage;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_FROM_DATE", OracleDbType.Date).Value = objEntityTCS.FromDate;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_TO_DATE", OracleDbType.Date).Value = objEntityTCS.ToDate;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_RESIDENT_STS", OracleDbType.Int32).Value = objEntityTCS.Resident_sts;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_STS", OracleDbType.Int32).Value = objEntityTCS.Status;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_CORPID", OracleDbType.Varchar2).Value = objEntityTCS.Corporate_id;
                     cmdAddTaxCollectedAtSource.Parameters.Add("T_UPD_USRID", OracleDbType.Int32).Value = objEntityTCS.User_Id;
                     cmdAddTaxCollectedAtSource.ExecuteNonQuery();

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
     public string CheckTaxName(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
     {

         string strQueryAddTaxCollectedAtSource = "FMS_TAX_COLLECTED_AT_SOURCE.SP_CHECK_TCS_NAME";
         OracleCommand cmdCheckTCSName = new OracleCommand();
         cmdCheckTCSName.CommandText = strQueryAddTaxCollectedAtSource;
         cmdCheckTCSName.CommandType = CommandType.StoredProcedure;
         cmdCheckTCSName.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTCS.TcsId;
         cmdCheckTCSName.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTCS.Name;
         cmdCheckTCSName.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
         cmdCheckTCSName.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
         cmdCheckTCSName.Parameters.Add("T_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
         clsDataLayer.ExecuteScalar(ref cmdCheckTCSName);
         string strReturn = cmdCheckTCSName.Parameters["T_COUNT"].Value.ToString();
         cmdCheckTCSName.Dispose();
         return strReturn;
     }
     public DataTable ReadTCSList(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
     {
         string strQueryReadTcs = "FMS_TAX_COLLECTED_AT_SOURCE.SP_TCS_LIST";
         OracleCommand cmdReadTcs = new OracleCommand();
         cmdReadTcs.CommandText = strQueryReadTcs;
         cmdReadTcs.CommandType = CommandType.StoredProcedure;

         cmdReadTcs.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
         cmdReadTcs.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
         cmdReadTcs.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTCS.Status;
         cmdReadTcs.Parameters.Add("T_CNCL_STS", OracleDbType.Int32).Value = objEntityTCS.cncl_sts;
         cmdReadTcs.Parameters.Add("T_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
         DataTable dtLeav = new DataTable();
         dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
         return dtLeav;

     }
     public DataTable ReadTcsByIdByid(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
     {
         string strQueryReadTcs = "FMS_TAX_COLLECTED_AT_SOURCE.SP_READ_TCS_BYID";
         OracleCommand cmdReadTcs = new OracleCommand();
         cmdReadTcs.CommandText = strQueryReadTcs;
         cmdReadTcs.CommandType = CommandType.StoredProcedure;

         cmdReadTcs.Parameters.Add("T_ORG_ID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
         cmdReadTcs.Parameters.Add("T_CORPRT_ID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
         cmdReadTcs.Parameters.Add("T_TCS_ID", OracleDbType.Int32).Value = objEntityTCS.TcsId;
         cmdReadTcs.Parameters.Add("T_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
         DataTable dtLeav = new DataTable();
         dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
         return dtLeav;

     }
     public void CancelTaxCollectedAtSource(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
     {
         string strQueryCncltCS = " FMS_TAX_COLLECTED_AT_SOURCE.SP_CANCEL_TCS";
         using (OracleCommand cmdCncltCSn = new OracleCommand())
         {
             cmdCncltCSn.CommandText = strQueryCncltCS;
             cmdCncltCSn.CommandType = CommandType.StoredProcedure;
             cmdCncltCSn.Parameters.Add("T_TCS_ID", OracleDbType.Int32).Value = objEntityTCS.TcsId;
             cmdCncltCSn.Parameters.Add("T_CNCL_USRID", OracleDbType.Int32).Value = objEntityTCS.User_Id;
             cmdCncltCSn.Parameters.Add("T_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityTCS.CancelReason;
             cmdCncltCSn.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTCS.Organisation_id;
             cmdCncltCSn.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTCS.Corporate_id;
             clsDataLayer.ExecuteNonQuery(cmdCncltCSn);
         }
     }

    }
}
