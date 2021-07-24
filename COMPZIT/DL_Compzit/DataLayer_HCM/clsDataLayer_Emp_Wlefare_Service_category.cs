using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
using CL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_Emp_Wlefare_Service_category
    {
        public void InsertWelfareCcategory(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertCategory = "WELFARE_SERVICE_CATEGORY.SP_INS_WELFARE_CATEGORY";
                    using (OracleCommand cmdInsertCategory = new OracleCommand())
                    {
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        
                        cmdInsertCategory.Transaction = tran;
                        cmdInsertCategory.Connection = con;
                        cmdInsertCategory.CommandText = strQueryInsertCategory;
                        cmdInsertCategory.CommandType = CommandType.StoredProcedure;
                        cmdInsertCategory.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityWelfareCcategory.categoryName;
                        if(objEntityWelfareCcategory.categoryDescription!="")
                        {
                        cmdInsertCategory.Parameters.Add("W_DESC", OracleDbType.Varchar2).Value = objEntityWelfareCcategory.categoryDescription;
                        }
                        else
                        {
                            cmdInsertCategory.Parameters.Add("W_DESC", OracleDbType.Int32).Value =null;
                        }
                        cmdInsertCategory.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWelfareCcategory.Status;
                        cmdInsertCategory.Parameters.Add("W_INSUSERID", OracleDbType.Int32).Value = objEntityWelfareCcategory.UserId;
                        cmdInsertCategory.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWelfareCcategory.OrgId;
                        cmdInsertCategory.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CorpId;
                        
                        clsDataLayer.ExecuteNonQuery(cmdInsertCategory);
                    }                   
                }
                catch (Exception ex)
                {
                }
            }
        
        }
        public void UpdateWelfareCategory(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            string strQueryupdCategory = "WELFARE_SERVICE_CATEGORY.SP_UPD_WELFARE_CATEGORY";
            using (OracleCommand cmdUpdCategory = new OracleCommand())
            {
                cmdUpdCategory.CommandText = strQueryupdCategory;
                cmdUpdCategory.CommandType = CommandType.StoredProcedure;
                cmdUpdCategory.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CategoryId;
                cmdUpdCategory.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityWelfareCcategory.categoryName;
                cmdUpdCategory.Parameters.Add("W_DESC", OracleDbType.Varchar2).Value = objEntityWelfareCcategory.categoryDescription;
                cmdUpdCategory.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWelfareCcategory.Status;
                cmdUpdCategory.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityWelfareCcategory.UserId;
                cmdUpdCategory.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWelfareCcategory.OrgId;
                cmdUpdCategory.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CorpId;     
                clsDataLayer.ExecuteNonQuery(cmdUpdCategory);
            }
        }
        // This Method checks Welfare category name in the database for duplication.
        public string CheckCategoryName(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {

            string strQueryCheckCategoryName = "WELFARE_SERVICE_CATEGORY.SP_CHECK_WLFR_CATGRY_NAME";
            OracleCommand cmdCheckCategoryName = new OracleCommand();
            cmdCheckCategoryName.CommandText = strQueryCheckCategoryName;
            cmdCheckCategoryName.CommandType = CommandType.StoredProcedure;
            cmdCheckCategoryName.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CategoryId;
            cmdCheckCategoryName.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityWelfareCcategory.categoryName;
            cmdCheckCategoryName.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CorpId;
            cmdCheckCategoryName.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWelfareCcategory.OrgId;
            cmdCheckCategoryName.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCategoryName);
            string strReturn = cmdCheckCategoryName.Parameters["W_COUNT"].Value.ToString();
            cmdCheckCategoryName.Dispose();
            return strReturn;
        }
        // This Method displays User  details from the database
        public DataTable ReadCategoryDetails(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            string strCommandText = "WELFARE_SERVICE_CATEGORY.SP_READ_CATGRY_LIST";
            using (OracleCommand cmdCategoryDetails = new OracleCommand())
            {
                cmdCategoryDetails.CommandText = strCommandText;
                cmdCategoryDetails.CommandType = CommandType.StoredProcedure;
                cmdCategoryDetails.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CorpId;
                cmdCategoryDetails.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWelfareCcategory.OrgId;
                cmdCategoryDetails.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWelfareCcategory.Status;
                cmdCategoryDetails.Parameters.Add("W_CANCEL", OracleDbType.Int32).Value = objEntityWelfareCcategory.Cancel_Status;
                cmdCategoryDetails.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCategoryDetails = new DataTable();
                dtCategoryDetails = clsDataLayer.SelectDataTable(cmdCategoryDetails);
                return dtCategoryDetails;
            }
        }
        // This Method displays User  details from the database
        public DataTable ReadCategoryDetailsById(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            string strCommandText = "WELFARE_SERVICE_CATEGORY.SP_READ_WLFR_CATGRY_BYID";
            using (OracleCommand cmdCategoryDetails = new OracleCommand())
            {
                cmdCategoryDetails.CommandText = strCommandText;
                cmdCategoryDetails.CommandType = CommandType.StoredProcedure;          
                cmdCategoryDetails.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CategoryId;
                cmdCategoryDetails.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityWelfareCcategory.OrgId;
                cmdCategoryDetails.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CorpId;
                cmdCategoryDetails.Parameters.Add("W_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCategoryDetails = new DataTable();
                dtCategoryDetails = clsDataLayer.SelectDataTable(cmdCategoryDetails);
                return dtCategoryDetails;
            }
        }
        public void CancelWelfareCategory(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            string strQueryCancelCategory = "WELFARE_SERVICE_CATEGORY.SP_CANCEL_WELFARE_CATEGORY";
            using (OracleCommand cmdCancelCategory = new OracleCommand())
            {
                cmdCancelCategory.CommandText = strQueryCancelCategory;
                cmdCancelCategory.CommandType = CommandType.StoredProcedure;
                cmdCancelCategory.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CategoryId;
                cmdCancelCategory.Parameters.Add("W_CNSL_USRID", OracleDbType.Int32).Value = objEntityWelfareCcategory.UserId;
                cmdCancelCategory.Parameters.Add("W_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityWelfareCcategory.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCategory);
            }
        }
        public void ChangeCategoryStatus(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            string strQueryChangeStatus = "WELFARE_SERVICE_CATEGORY.SP_UPD_CHANGE_STATUS";
            using (OracleCommand cmdChangeStatus = new OracleCommand())
            {
                cmdChangeStatus.CommandText = strQueryChangeStatus;
                cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                cmdChangeStatus.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityWelfareCcategory.CategoryId;
                cmdChangeStatus.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityWelfareCcategory.Status;
                cmdChangeStatus.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityWelfareCcategory.UserId;
                clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
            }
        }
    }
}
