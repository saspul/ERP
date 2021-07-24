using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using CL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;


namespace DL_Compzit
{
   public class clsDataLayerPrdctBrand
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds brand details to the table
        public void AddProductBrand(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryAddBankMstr = "PRODUCT_BRAND.SP_INS_PRDCT_BRND_DETAIL";
            using (OracleCommand cmdAddBank = new OracleCommand())
            {
                cmdAddBank.CommandText = strQueryAddBankMstr;
                cmdAddBank.CommandType = CommandType.StoredProcedure;
                cmdAddBank.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Brand_name;
                cmdAddBank.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Org_Id;
                cmdAddBank.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Corp_Id;
                cmdAddBank.Parameters.Add("B_STATUS", OracleDbType.Int32).Value = objEntityPrdctBrnd.Status;
                cmdAddBank.Parameters.Add("B_INSUSERID", OracleDbType.Int32).Value = objEntityPrdctBrnd.User_Id;
                cmdAddBank.Parameters.Add("B_INSUSRDATE", OracleDbType.Date).Value = objEntityPrdctBrnd.D_Date;
                cmdAddBank.Parameters.Add("B_GRPCODE", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Brand_Code;
                
                clsDataLayer.ExecuteNonQuery(cmdAddBank);
            }
        }
      

        //Method for Updating Item group Details
        public void UpdateProductBrand(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryUpdateSup = "PRODUCT_BRAND.SP_UPD_PRDCT_BRND_DETAIL";
            using (OracleCommand cmdUpdateItem = new OracleCommand())
            {
                cmdUpdateItem.CommandText = strQueryUpdateSup;
                cmdUpdateItem.CommandType = CommandType.StoredProcedure;
                cmdUpdateItem.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Brand_Id;
                cmdUpdateItem.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Brand_name;
                cmdUpdateItem.Parameters.Add("B_STATUS", OracleDbType.Int32).Value = objEntityPrdctBrnd.Status;
                cmdUpdateItem.Parameters.Add("B_UPDUSERID", OracleDbType.Int32).Value = objEntityPrdctBrnd.User_Id;
                cmdUpdateItem.Parameters.Add("B_UPDUSERDATE", OracleDbType.Date).Value = objEntityPrdctBrnd.D_Date;
                cmdUpdateItem.Parameters.Add("B_BRDCODE", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Brand_Code;
                clsDataLayer.ExecuteNonQuery(cmdUpdateItem);
            }
        }

        //Method for cancel Item group
        public void CancelProductBrand(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryCancelItemGrp = "PRODUCT_BRAND.SP_CANCEL_PRDCT_BRAND";
            using (OracleCommand cmdCancelItemGrp = new OracleCommand())
            {
                cmdCancelItemGrp.CommandText = strQueryCancelItemGrp;
                cmdCancelItemGrp.CommandType = CommandType.StoredProcedure;
                cmdCancelItemGrp.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Brand_Id;
                cmdCancelItemGrp.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityPrdctBrnd.User_Id;
                cmdCancelItemGrp.Parameters.Add("B_DATE", OracleDbType.Date).Value = objEntityPrdctBrnd.D_Date;
                cmdCancelItemGrp.Parameters.Add("B_REASON", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelItemGrp);
            }
        }

        // This Method checks Item group name in the database for duplication.
        public string CheckProductBrandName(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryCheckItemGrpName = "PRODUCT_BRAND.SP_CHECK_PRDCT_BRAND_NAME";
            OracleCommand cmdCheckItemGrpName = new OracleCommand();
            cmdCheckItemGrpName.CommandText = strQueryCheckItemGrpName;
            cmdCheckItemGrpName.CommandType = CommandType.StoredProcedure;
            cmdCheckItemGrpName.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Brand_Id;
            cmdCheckItemGrpName.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Brand_name;
            cmdCheckItemGrpName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Org_Id;
            cmdCheckItemGrpName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Corp_Id;
            cmdCheckItemGrpName.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckItemGrpName);
            string strReturn = cmdCheckItemGrpName.Parameters["B_COUNT"].Value.ToString();
            cmdCheckItemGrpName.Dispose();
            return strReturn;
        }

        // This Method will fetch Item group table by ID
        public DataTable ReadProductBrandById(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryReadItemGrptById = "PRODUCT_BRAND.SP_READ_PRDCT_BRAND_BYID";
            OracleCommand cmdReadItemGrpById = new OracleCommand();
            cmdReadItemGrpById.CommandText = strQueryReadItemGrptById;
            cmdReadItemGrpById.CommandType = CommandType.StoredProcedure;
            cmdReadItemGrpById.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Brand_Id;
            cmdReadItemGrpById.Parameters.Add("B_ITEM_GROUP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadItemGrpById);
            return dtBank;
        }
        // This Method checks Item group Code in the database for duplication.
        public string CheckProductBrandCode(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryCheckItemGrpCode = "PRODUCT_BRAND.SP_CHECK_PRDCT_BRAND_CODE";
            OracleCommand cmdCheckItemGrpCode = new OracleCommand();
            cmdCheckItemGrpCode.CommandText = strQueryCheckItemGrpCode;
            cmdCheckItemGrpCode.CommandType = CommandType.StoredProcedure;
            cmdCheckItemGrpCode.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Brand_Id;
            cmdCheckItemGrpCode.Parameters.Add("B_CODE", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.Brand_Code;
            cmdCheckItemGrpCode.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Org_Id;
            cmdCheckItemGrpCode.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Corp_Id;
            cmdCheckItemGrpCode.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckItemGrpCode);
            string strReturn = cmdCheckItemGrpCode.Parameters["B_COUNT"].Value.ToString();
            cmdCheckItemGrpCode.Dispose();
            return strReturn;
        }



        public DataTable ReadProductBrandList(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryReadProductGrpList = "PRODUCT_BRAND.SP_READ_PRODUCT_BRAND_LIST";
            OracleCommand cmdReadProductGrpList = new OracleCommand();
            cmdReadProductGrpList.CommandText = strQueryReadProductGrpList;
            cmdReadProductGrpList.CommandType = CommandType.StoredProcedure;
            cmdReadProductGrpList.Parameters.Add("B_OPTION", OracleDbType.Int32).Value = objEntityPrdctBrnd.Status;
            cmdReadProductGrpList.Parameters.Add("B_CANCEL", OracleDbType.Int32).Value = objEntityPrdctBrnd.Cancel_Status;
            cmdReadProductGrpList.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Org_Id;
            cmdReadProductGrpList.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Corp_Id;

            cmdReadProductGrpList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.CommonSearchTerm;
            cmdReadProductGrpList.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.SearchName;
            cmdReadProductGrpList.Parameters.Add("M_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityPrdctBrnd.SearchCode;
            cmdReadProductGrpList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityPrdctBrnd.OrderColumn;
            cmdReadProductGrpList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityPrdctBrnd.OrderMethod;
            cmdReadProductGrpList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityPrdctBrnd.PageMaxSize;
            cmdReadProductGrpList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityPrdctBrnd.PageNumber;

            cmdReadProductGrpList.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadProductGrpList);
            return dtCategoryList;
        }


        public void Update_Brand_Status(clsEntityProductBrand objEntityPrdctBrnd)
        {
            string strQueryUpdateSup = "PRODUCT_BRAND.SP_UPD_PRDCT_BRND_STS";
            using (OracleCommand cmdUpdateItem = new OracleCommand())
            {
                cmdUpdateItem.CommandText = strQueryUpdateSup;
                cmdUpdateItem.CommandType = CommandType.StoredProcedure;
                cmdUpdateItem.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityPrdctBrnd.Brand_Id;
                cmdUpdateItem.Parameters.Add("B_STATUS", OracleDbType.Int32).Value = objEntityPrdctBrnd.Status;
                cmdUpdateItem.Parameters.Add("B_UPDUSERID", OracleDbType.Int32).Value = objEntityPrdctBrnd.User_Id;
                cmdUpdateItem.Parameters.Add("B_UPDUSERDATE", OracleDbType.Date).Value = objEntityPrdctBrnd.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateItem);
            }
        }

    }
}