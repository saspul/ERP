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
   public class clsDataLayerVendorCategory
    {
       public void InsertVendorCategory(clsEntityVendorCategory objEntityVendorcategory)
       {
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();
               try
               {
                   string strQueryAddVendorCategory = "PMS_VENDOR_CATEGORY.SP_INS_VENDORCATEGORY";
                   using (OracleCommand cmdAddVendorCategory = new OracleCommand(strQueryAddVendorCategory, con))
                   {
                       cmdAddVendorCategory.CommandType = CommandType.StoredProcedure;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_NAME", OracleDbType.Varchar2).Value = objEntityVendorcategory.VendorCategory;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_CODE", OracleDbType.Varchar2).Value = objEntityVendorcategory.VendorCategoryCode;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_STS", OracleDbType.Int32).Value = objEntityVendorcategory.Status;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_USRID", OracleDbType.Int32).Value = objEntityVendorcategory.UserId;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
                      
                       cmdAddVendorCategory.ExecuteNonQuery();
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
       public void updateVendorCategory(clsEntityVendorCategory objEntityVendorcategory)
       {
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();
               try
               {
                   string strQueryAddVendorCategory = "PMS_VENDOR_CATEGORY.SP_UPD_VENDORCATEGORY";
                   using (OracleCommand cmdAddVendorCategory = new OracleCommand(strQueryAddVendorCategory, con))
                   {
                       cmdAddVendorCategory.CommandType = CommandType.StoredProcedure;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_NAME", OracleDbType.Varchar2).Value = objEntityVendorcategory.VendorCategory;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_CODE", OracleDbType.Varchar2).Value = objEntityVendorcategory.VendorCategoryCode;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_STS", OracleDbType.Int32).Value = objEntityVendorcategory.Status;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_USRID", OracleDbType.Int32).Value = objEntityVendorcategory.UserId;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
                       cmdAddVendorCategory.Parameters.Add("VENDORCAT_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
                       cmdAddVendorCategory.ExecuteNonQuery(); 
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
       public DataTable ReadVendorCategory(clsEntityVendorCategory objEntityVendorcategory)
       {
           string strQueryReadTcs = "PMS_VENDOR_CATEGORY.SP_READ_VENDORCATEGORYlIST";
           OracleCommand cmdReadVCat = new OracleCommand();
           cmdReadVCat.CommandText = strQueryReadTcs;
           cmdReadVCat.CommandType = CommandType.StoredProcedure;
           cmdReadVCat.Parameters.Add("VENDORCAT_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
           cmdReadVCat.Parameters.Add("VENDORCAT_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
           cmdReadVCat.Parameters.Add("VENDORCAT_STS", OracleDbType.Int32).Value = objEntityVendorcategory.Status;
           cmdReadVCat.Parameters.Add("VENDORCAT_CNCLSTS", OracleDbType.Int32).Value = objEntityVendorcategory.Cancel_status;
           cmdReadVCat.Parameters.Add("VENDORCAT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtVendorCategory = new DataTable();
           dtVendorCategory = clsDataLayer.ExecuteReader(cmdReadVCat);
           return dtVendorCategory;

       }
       public DataTable ReadVendorCategory_ByID(clsEntityVendorCategory objEntityVendorcategory)
       {
           string strQueryReadVCatByID = "PMS_VENDOR_CATEGORY.SP_READ_VENDORCATEGORY_BY_ID";
           OracleCommand cmdReadVCat_ByID = new OracleCommand();
           cmdReadVCat_ByID.CommandText = strQueryReadVCatByID;
           cmdReadVCat_ByID.CommandType = CommandType.StoredProcedure;
           cmdReadVCat_ByID.Parameters.Add("VENDORCAT_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
           cmdReadVCat_ByID.Parameters.Add("VENDORCAT_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
           cmdReadVCat_ByID.Parameters.Add("VENDORCAT_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
           cmdReadVCat_ByID.Parameters.Add("VENDORCAT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtVendorCategory = new DataTable();
           dtVendorCategory = clsDataLayer.ExecuteReader(cmdReadVCat_ByID);
           return dtVendorCategory;

       }
       public void CancelVendorCategory(clsEntityVendorCategory objEntityVendorcategory)
       {
           string strQueryCncltCS = " PMS_VENDOR_CATEGORY.SP_CANCEL_VENDORCATEGORY";
           using (OracleCommand cmdCancelVCategory = new OracleCommand())
           {
               cmdCancelVCategory.CommandText = strQueryCncltCS;
               cmdCancelVCategory.CommandType = CommandType.StoredProcedure;
               cmdCancelVCategory.Parameters.Add("VENDORCAT_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
               cmdCancelVCategory.Parameters.Add("VENDORCAT_USRID", OracleDbType.Int32).Value = objEntityVendorcategory.UserId;
               cmdCancelVCategory.Parameters.Add("VENDORCAT_REASON", OracleDbType.Varchar2).Value = objEntityVendorcategory.CancelReason;
               cmdCancelVCategory.Parameters.Add("VENDORCAT_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
               cmdCancelVCategory.Parameters.Add("VENDORCAT_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
               clsDataLayer.ExecuteNonQuery(cmdCancelVCategory);
           }
       }
       public DataTable VendorCategoryDplctnChk(clsEntityVendorCategory objEntityVendorcategory)
       {
           DataTable dtVenderCategory = new DataTable();
           using (OracleCommand cmdReadVendorCategory = new OracleCommand())
           {
               cmdReadVendorCategory.CommandText = "PMS_VENDOR_CATEGORY.SP_CHECK_DUP_VENDORCATEGORY";
               cmdReadVendorCategory.CommandType = CommandType.StoredProcedure;
               cmdReadVendorCategory.Parameters.Add("VENDORCAT_ID", OracleDbType.Int32).Value = objEntityVendorcategory.vendorCategoryID;
               cmdReadVendorCategory.Parameters.Add("VENDORCAT_NAME", OracleDbType.Varchar2).Value = objEntityVendorcategory.VendorCategory;
               cmdReadVendorCategory.Parameters.Add("VENDORCAT_ORGID", OracleDbType.Int32).Value = objEntityVendorcategory.OrgId;
               cmdReadVendorCategory.Parameters.Add("VENDORCAT_CORPID", OracleDbType.Int32).Value = objEntityVendorcategory.CorpId;
               cmdReadVendorCategory.Parameters.Add("VENDORCAT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               dtVenderCategory = clsDataLayer.SelectDataTable(cmdReadVendorCategory);
           }
           return dtVenderCategory;
       }
    }
}
