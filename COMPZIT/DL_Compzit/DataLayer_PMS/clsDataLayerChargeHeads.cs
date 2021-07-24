using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_PMS;

namespace DL_Compzit.DataLayer_PMS
{
  public  class clsDataLayerChargeHeads
  {
      public void InsertChargeHead(clsEntityChargeHeads objEntityVendorcategory, List<clsEntityChargeHeads> objEntityVendorcat)
      {
          OracleTransaction tran;

          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              string strReturn = "";
              con.Open();
              tran = con.BeginTransaction();
              try
              {

                  string strQueryAddChargeHead = "PMS_CHARGE_HEAD.SP_INS_CHARGEHEAD";
                  using (OracleCommand cmdAddChargeHead = new OracleCommand(strQueryAddChargeHead, con))
                  {
                      cmdAddChargeHead.CommandType = CommandType.StoredProcedure;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_NAME", OracleDbType.Varchar2).Value = objEntityVendorcategory.ChargeHead;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_CODE", OracleDbType.Varchar2).Value = objEntityVendorcategory.ChargeHeadCode;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_CALCULATE", OracleDbType.Int32).Value = objEntityVendorcategory.CHCalculate;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_STATUS", OracleDbType.Int32).Value = objEntityVendorcategory.Status;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_USRID", OracleDbType.Int32).Value = objEntityVendorcategory.UserId;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
                      cmdAddChargeHead.Parameters.Add("CHRGHDID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                      cmdAddChargeHead.ExecuteNonQuery();
                      strReturn = cmdAddChargeHead.Parameters["CHRGHDID_OUT"].Value.ToString();
                      cmdAddChargeHead.Dispose();

                  }
                  foreach (clsEntityChargeHeads objEntityCntry in objEntityVendorcat)
                  {
                      string strQueryAdd = "PMS_CHARGE_HEAD.SP_INS_CHARGEHEADCATEGORY";
                      using (OracleCommand cmdAddChargeHead = new OracleCommand(strQueryAdd, con))
                      {
                          cmdAddChargeHead.Transaction = tran;
                          cmdAddChargeHead.CommandType = CommandType.StoredProcedure;
                          cmdAddChargeHead.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                          cmdAddChargeHead.Parameters.Add("CHRGECTGRY_ID", OracleDbType.Int32).Value = objEntityCntry.CHCategoryId;
                          cmdAddChargeHead.ExecuteNonQuery();
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
      public void updateChargeHead(clsEntityChargeHeads objEntityVendorcategory, List<clsEntityChargeHeads> objEntityVendorcat)
      {
          OracleTransaction tran;
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();
              try
              {
                  string strQueryAddChargeHead = "PMS_CHARGE_HEAD.SP_UPD_CHARGEHEAD";
                  using (OracleCommand cmdAddChargeHead = new OracleCommand(strQueryAddChargeHead, con))
                  {
                      cmdAddChargeHead.CommandType = CommandType.StoredProcedure;
                      cmdAddChargeHead.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
                      cmdAddChargeHead.Parameters.Add("CHRGEHD_NAME", OracleDbType.Varchar2).Value = objEntityVendorcategory.ChargeHead;
                      cmdAddChargeHead.Parameters.Add("CHRGEHD_CODE", OracleDbType.Varchar2).Value = objEntityVendorcategory.ChargeHeadCode;
                      cmdAddChargeHead.Parameters.Add("CHRGEHDCAT_ID", OracleDbType.Int32).Value = objEntityVendorcategory.CHCategoryId;
                      cmdAddChargeHead.Parameters.Add("CHRGEHD_CALCULATE", OracleDbType.Int32).Value = objEntityVendorcategory.CHCalculate;
                      cmdAddChargeHead.Parameters.Add("CHRGEHD_STATUS", OracleDbType.Int32).Value = objEntityVendorcategory.Status;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_USRID", OracleDbType.Int32).Value = objEntityVendorcategory.UserId;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
                      cmdAddChargeHead.Parameters.Add("CHRGHD_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
                      cmdAddChargeHead.ExecuteNonQuery();
                  }

                  string strQueryDeleteChargeHead = "PMS_CHARGE_HEAD.SP_DELETECHCAT_BYID";
                   using (OracleCommand cmdDeleteChargeHead = new OracleCommand(strQueryDeleteChargeHead, con))
                   {
                       cmdDeleteChargeHead.CommandType = CommandType.StoredProcedure;
                       cmdDeleteChargeHead.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
                       cmdDeleteChargeHead.ExecuteNonQuery();
                   }
                  foreach (clsEntityChargeHeads objEntityCntry in objEntityVendorcat)
                  {
                      string strQueryAdd = "PMS_CHARGE_HEAD.SP_INS_CHARGEHEADCATEGORY";
                      using (OracleCommand cmdAddChargeHead = new OracleCommand(strQueryAdd, con))
                      {
                          cmdAddChargeHead.Transaction = tran;
                          cmdAddChargeHead.CommandType = CommandType.StoredProcedure;
                          cmdAddChargeHead.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
                          cmdAddChargeHead.Parameters.Add("CHRGECTGRY_ID", OracleDbType.Int32).Value = objEntityCntry.CHCategoryId;
                          cmdAddChargeHead.ExecuteNonQuery();
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
      public DataTable ReadChargeHead(clsEntityChargeHeads objEntityVendorcategory)
      {
          string strQueryReadTcs = "PMS_CHARGE_HEAD.SP_READ_CHARGEHEADlIST";
          OracleCommand cmdReadVCat = new OracleCommand();
          cmdReadVCat.CommandText = strQueryReadTcs;
          cmdReadVCat.CommandType = CommandType.StoredProcedure;
          cmdReadVCat.Parameters.Add("CHRGHD_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
          cmdReadVCat.Parameters.Add("CHRGHD_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
          cmdReadVCat.Parameters.Add("CHRGEHD_STATUS", OracleDbType.Int32).Value = objEntityVendorcategory.Status;
          cmdReadVCat.Parameters.Add("CHRGEHD_CNCLSTS", OracleDbType.Int32).Value = objEntityVendorcategory.Cancel_status;
          cmdReadVCat.Parameters.Add("CHRGEHD_CATID", OracleDbType.Int32).Value = objEntityVendorcategory.CHCategoryId;
          cmdReadVCat.Parameters.Add("CHRGHD_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtChargeHead = new DataTable();
          dtChargeHead = clsDataLayer.ExecuteReader(cmdReadVCat);
          return dtChargeHead;

      }
      public DataTable ReadChargeHead_ByID(clsEntityChargeHeads objEntityVendorcategory)
      {
          string strQueryReadChargeHead = "PMS_CHARGE_HEAD.SP_READ_CHARGEHEAD_BY_ID";
          OracleCommand cmdReadVCat_ByID = new OracleCommand();
          cmdReadVCat_ByID.CommandText = strQueryReadChargeHead;
          cmdReadVCat_ByID.CommandType = CommandType.StoredProcedure;
          cmdReadVCat_ByID.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
          cmdReadVCat_ByID.Parameters.Add("CHRGHD_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
          cmdReadVCat_ByID.Parameters.Add("CHRGHD_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
          cmdReadVCat_ByID.Parameters.Add("CHRGHD_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtChargeHead = new DataTable();
          dtChargeHead = clsDataLayer.ExecuteReader(cmdReadVCat_ByID);
          return dtChargeHead;

      }
      public void CancelChargeHead(clsEntityChargeHeads objEntityVendorcategory)
      {
          string strQueryCncltCS = " PMS_CHARGE_HEAD.SP_CANCEL_CHARGEHEAD";
          using (OracleCommand cmdCancelVCategory = new OracleCommand())
          {
              cmdCancelVCategory.CommandText = strQueryCncltCS;
              cmdCancelVCategory.CommandType = CommandType.StoredProcedure;
              cmdCancelVCategory.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
              cmdCancelVCategory.Parameters.Add("CHRGHD_USRID", OracleDbType.Int32).Value = objEntityVendorcategory.UserId;
              cmdCancelVCategory.Parameters.Add("CHRGEHD_REASON", OracleDbType.Varchar2).Value = objEntityVendorcategory.CancelReason;
              cmdCancelVCategory.Parameters.Add("CHRGHD_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
              cmdCancelVCategory.Parameters.Add("CHRGHD_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
              clsDataLayer.ExecuteNonQuery(cmdCancelVCategory);
          }
      }
      public DataTable ChargeHeadDplctnChk(clsEntityChargeHeads objEntityVendorcategory)
      {
          DataTable dtVenderCategory = new DataTable();
          using (OracleCommand cmdReadChargeHead = new OracleCommand())
          {
              cmdReadChargeHead.CommandText = "PMS_CHARGE_HEAD.SP_CHECK_DUP_CHARGEHEAD";
              cmdReadChargeHead.CommandType = CommandType.StoredProcedure;
              cmdReadChargeHead.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
              cmdReadChargeHead.Parameters.Add("CHRGEHD_NAME", OracleDbType.Varchar2).Value = objEntityVendorcategory.ChargeHead;
              cmdReadChargeHead.Parameters.Add("CHRGHD_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
              cmdReadChargeHead.Parameters.Add("CHRGHD_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
              cmdReadChargeHead.Parameters.Add("CHRGHD_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtVenderCategory = clsDataLayer.SelectDataTable(cmdReadChargeHead);
          }
          return dtVenderCategory;
      }
      public DataTable ReadChargeHeadCategory(clsEntityChargeHeads objEntityVendorcategory)
      {
          string strQueryReadChargeHead = "PMS_CHARGE_HEAD.SP_LOAD_CHSATEGORY";
          OracleCommand cmdReadChargeHeadCategory = new OracleCommand();
          cmdReadChargeHeadCategory.CommandText = strQueryReadChargeHead;
          cmdReadChargeHeadCategory.CommandType = CommandType.StoredProcedure;
          cmdReadChargeHeadCategory.Parameters.Add("CHRGHD_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtChargeHead = new DataTable();
          dtChargeHead = clsDataLayer.ExecuteReader(cmdReadChargeHeadCategory);
          return dtChargeHead;

      }
      public DataTable ReadChargeHeadCategoryByID(clsEntityChargeHeads objEntityVendorcategory)
      {
          string strQueryReadChargeHead = "PMS_CHARGE_HEAD.SP_READCHCAT_BYID";
          OracleCommand cmdReadChargeHeadCategory = new OracleCommand();
          cmdReadChargeHeadCategory.CommandText = strQueryReadChargeHead;
          cmdReadChargeHeadCategory.CommandType = CommandType.StoredProcedure;
          cmdReadChargeHeadCategory.Parameters.Add("CHRGEHD_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
          cmdReadChargeHeadCategory.Parameters.Add("CHRGHD_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtChargeHead = new DataTable();
          dtChargeHead = clsDataLayer.ExecuteReader(cmdReadChargeHeadCategory);
          return dtChargeHead;

      }
  }
}
