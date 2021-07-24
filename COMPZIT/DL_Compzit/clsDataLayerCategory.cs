using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:18/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Category detail and also updating,canceling and viewing the same .
namespace DL_Compzit
{
   public class clsDataLayerCategory
   {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetch Category Type table
        public DataTable ReadCategoryType()
        {
            string strQueryReadCategory = "ITEM_CATEGORY.SP_READ_CATEGORY_TYPE";
            OracleCommand cmdReadCategoryType = new OracleCommand();
            cmdReadCategoryType.CommandText = strQueryReadCategory;
            cmdReadCategoryType.CommandType = CommandType.StoredProcedure;
            cmdReadCategoryType.Parameters.Add(" C_CATEGORYTYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCategoryType);
            return dtCategory;
        }
        // This Method adds Category details to the GN_CATEGORY  table
        public void AddCategory(clsEntityCategory objEntityCategory)
        {
            string strQueryAddCategory = "ITEM_CATEGORY.SP_INS_CATEGORY_DETAIL";
            using (OracleCommand cmdAddCategory = new OracleCommand())
            {
                cmdAddCategory.CommandText = strQueryAddCategory;
                cmdAddCategory.CommandType = CommandType.StoredProcedure;
                cmdAddCategory.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCategory.Category_name;
                cmdAddCategory.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
                cmdAddCategory.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
                cmdAddCategory.Parameters.Add("C_CTGRYTYPID", OracleDbType.Int32).Value = objEntityCategory.CategoryType_Id;
                cmdAddCategory.Parameters.Add("C_MAINCTGRYID", OracleDbType.Int32).Value = objEntityCategory.MainCategoryId;
                cmdAddCategory.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCategory.Status;
                cmdAddCategory.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityCategory.User_Id;
                if (objEntityCategory.Item_Group_Id == 0)
                    cmdAddCategory.Parameters.Add("C_GROUPID", OracleDbType.Int32).Value = null;
                else
                    cmdAddCategory.Parameters.Add("C_GROUPID", OracleDbType.Int32).Value = objEntityCategory.Item_Group_Id;
                cmdAddCategory.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCategory.Commodity_Code;
                if (objEntityCategory.LedgerID != 0)
                {
                    cmdAddCategory.Parameters.Add("C_LEDGER_ID", OracleDbType.Int32).Value = objEntityCategory.LedgerID;

                }
                else
                {
                    cmdAddCategory.Parameters.Add("C_LEDGER_ID", OracleDbType.Int32).Value = null;

                }
                if (objEntityCategory.PurchaseLedgerID != 0)
                {
                    cmdAddCategory.Parameters.Add("C_PRCHS_LDGR_ID", OracleDbType.Int32).Value = objEntityCategory.PurchaseLedgerID;

                }
                else
                {
                    cmdAddCategory.Parameters.Add("C_PRCHS_LDGR_ID", OracleDbType.Int32).Value = null;
                }

                clsDataLayer.ExecuteNonQuery(cmdAddCategory);
            }
        }
        //Method for change the active / inactive status of Category
        public void CategoryStatusChange(clsEntityCategory objEntityCategory)
        {
            string strQuerySupplierStatus = "ITEM_CATEGORY.SP_UPDATE_STATUS";
            using (OracleCommand cmdSuppStatus = new OracleCommand())
            {
                cmdSuppStatus.CommandText = strQuerySupplierStatus;
                cmdSuppStatus.CommandType = CommandType.StoredProcedure;
                cmdSuppStatus.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
                cmdSuppStatus.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCategory.Status;
                cmdSuppStatus.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCategory.User_Id;
                cmdSuppStatus.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdSuppStatus);
            }
        }
        //Method for Updating Category Details
        public void UpdateCategory(clsEntityCategory objEntityCategory)
        {
            string strQueryUpdateCategory = "ITEM_CATEGORY.SP_UPDATE_CATEGORY";
            using (OracleCommand cmdUpdateCategory = new OracleCommand())
            {
                cmdUpdateCategory.CommandText = strQueryUpdateCategory;
                cmdUpdateCategory.CommandType = CommandType.StoredProcedure;
                cmdUpdateCategory.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
                cmdUpdateCategory.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCategory.Category_name;
                cmdUpdateCategory.Parameters.Add("C_CTGRYTYPID", OracleDbType.Int32).Value = objEntityCategory.CategoryType_Id;
                cmdUpdateCategory.Parameters.Add("C_MAINCTGRYID", OracleDbType.Int32).Value = objEntityCategory.MainCategoryId;
                cmdUpdateCategory.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCategory.Status;
                cmdUpdateCategory.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityCategory.User_Id;
                cmdUpdateCategory.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                if (objEntityCategory.Item_Group_Id == 0)
                    cmdUpdateCategory.Parameters.Add("C_GROUPID", OracleDbType.Int32).Value = null;
                else
                    cmdUpdateCategory.Parameters.Add("C_GROUPID", OracleDbType.Int32).Value = objEntityCategory.Item_Group_Id;
                cmdUpdateCategory.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCategory.Commodity_Code;
                if (objEntityCategory.LedgerID != 0)
                {
                    cmdUpdateCategory.Parameters.Add("C_LEDGER_ID", OracleDbType.Int32).Value = objEntityCategory.LedgerID;

                }
                else
                {
                    cmdUpdateCategory.Parameters.Add("C_LEDGER_ID", OracleDbType.Int32).Value = null;

                }
                if (objEntityCategory.PurchaseLedgerID != 0)
                {
                    cmdUpdateCategory.Parameters.Add("C_PRCHS_LDGR_ID", OracleDbType.Int32).Value = objEntityCategory.PurchaseLedgerID;

                }
                else
                {
                    cmdUpdateCategory.Parameters.Add("C_PRCHS_LDGR_ID", OracleDbType.Int32).Value = null;
                }
                clsDataLayer.ExecuteNonQuery(cmdUpdateCategory);
            }
        }
        //Method for cancel Category
        public void CancelCategory(clsEntityCategory objEntityCategory)
        {
            string strQueryCancelCategory = "ITEM_CATEGORY.SP_CANCEL_CATEGORY";
            using (OracleCommand cmdCancelCategory = new OracleCommand())
            {
                cmdCancelCategory.CommandText = strQueryCancelCategory;
                cmdCancelCategory.CommandType = CommandType.StoredProcedure;
                cmdCancelCategory.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
                cmdCancelCategory.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCategory.User_Id;
                cmdCancelCategory.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelCategory.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityCategory.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCategory);
            }
        }
        // This Method checks Category name in the database for duplication.
        public string CheckCategoryName(clsEntityCategory objEntityCategory)
        {
            string strQueryCheckCategoryName = "ITEM_CATEGORY.SP_CHECK_CATEGORY_NAME";
            OracleCommand cmdCheckCategoryName = new OracleCommand();
            cmdCheckCategoryName.CommandText = strQueryCheckCategoryName;
            cmdCheckCategoryName.CommandType = CommandType.StoredProcedure;
            cmdCheckCategoryName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
            cmdCheckCategoryName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCategory.Category_name;
            cmdCheckCategoryName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdCheckCategoryName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdCheckCategoryName.Parameters.Add("C_CTGRYTYPID", OracleDbType.Int32).Value = objEntityCategory.CategoryType_Id;
            cmdCheckCategoryName.Parameters.Add("C_MAINCTGRYID", OracleDbType.Int32).Value = objEntityCategory.MainCategoryId;
            cmdCheckCategoryName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCategoryName);
            string strReturn = cmdCheckCategoryName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCategoryName.Dispose();
            return strReturn;
        }
        // This Method checks Category Id if present in Main category id  field of any other item in the database for duplication.
        public string CheckCategoryMainId(clsEntityCategory objEntityCategory)
        {
            string strQueryCheckCategoryName = "ITEM_CATEGORY.SP_CHECK_MAINID_UPD";
            OracleCommand cmdCheckCategoryName = new OracleCommand();
            cmdCheckCategoryName.CommandText = strQueryCheckCategoryName;
            cmdCheckCategoryName.CommandType = CommandType.StoredProcedure;
            cmdCheckCategoryName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
            cmdCheckCategoryName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdCheckCategoryName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdCheckCategoryName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCategoryName);
            string strReturn = cmdCheckCategoryName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCategoryName.Dispose();
            return strReturn;
        }
        // This Method will fetch Category table by ID
        public DataTable ReadCategoryById(clsEntityCategory objEntityCategory)
        {
            string strQueryReadCategorytById = "ITEM_CATEGORY.SP_READ_CATEGORY_BYID";
            OracleCommand cmdReadCategoryById = new OracleCommand();
            cmdReadCategoryById.CommandText = strQueryReadCategorytById;
            cmdReadCategoryById.CommandType = CommandType.StoredProcedure;
            cmdReadCategoryById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
            cmdReadCategoryById.Parameters.Add("C_CATEGORY", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCategoryById);
            return dtCategory;
        }
        // This Method will fetch product group on the basis of corporate office
        public DataTable ReadProductGroup(clsEntityCategory objEntityCategory)
        {
            string strQueryReadProductGroup = "ITEM_CATEGORY.SP_READ_PRODUCT_GROUP";
            OracleCommand cmdReadProductGroup = new OracleCommand();
            cmdReadProductGroup.CommandText = strQueryReadProductGroup;
            cmdReadProductGroup.CommandType = CommandType.StoredProcedure;
            cmdReadProductGroup.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdReadProductGroup.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdReadProductGroup.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProductGroup = new DataTable();
            dtProductGroup = clsDataLayer.ExecuteReader(cmdReadProductGroup);
            return dtProductGroup;
        }
        // This Method will fetch product main category
        public DataTable ReadMainCategory(clsEntityCategory objEntityCategory)
        {
            string strQueryReadMainCategory = "ITEM_CATEGORY.SP_READ_PRODUCT_MAIN_CATEGORY";
            OracleCommand cmdReadMainCategory = new OracleCommand();
            cmdReadMainCategory.CommandText = strQueryReadMainCategory;
            cmdReadMainCategory.CommandType = CommandType.StoredProcedure;
            cmdReadMainCategory.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdReadMainCategory.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdReadMainCategory.Parameters.Add("C_CATEGORYID", OracleDbType.Int32).Value = objEntityCategory.CategoryType_Id;
            cmdReadMainCategory.Parameters.Add("C_SEARCH", OracleDbType.Varchar2).Value = objEntityCategory.Cancel_Reason;
            cmdReadMainCategory.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMainCategory = new DataTable();
            dtMainCategory = clsDataLayer.ExecuteReader(cmdReadMainCategory);
            return dtMainCategory;
        }
        // This Method will fetch product category list
        public DataTable ReadCategoryList(clsEntityCategory objEntityCategory)
        {
            string strQueryReadCategoryList = "ITEM_CATEGORY.SP_READ_CATEGORY_LIST";
            OracleCommand cmdReadCategoryList = new OracleCommand();
            cmdReadCategoryList.CommandText = strQueryReadCategoryList;
            cmdReadCategoryList.CommandType = CommandType.StoredProcedure;
            cmdReadCategoryList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdReadCategoryList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdReadCategoryList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCategoryList);
            return dtCategoryList;
        }
        // This Method will fetch product category list
        public DataTable ReadCategoryListBySearch(clsEntityCategory objEntityCategory)
        {
            string strQueryReadCategoryListBySearch = "ITEM_CATEGORY.SP_READ_CATEGORY_LIST_BYSEARCH";
            OracleCommand cmdReadCategoryListBySearch = new OracleCommand();
            cmdReadCategoryListBySearch.CommandText = strQueryReadCategoryListBySearch;
            cmdReadCategoryListBySearch.CommandType = CommandType.StoredProcedure;
            cmdReadCategoryListBySearch.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdReadCategoryListBySearch.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            if (objEntityCategory.Search_Field == "")
            {
                cmdReadCategoryListBySearch.Parameters.Add("C_SEARCH_WORD", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadCategoryListBySearch.Parameters.Add("C_SEARCH_WORD", OracleDbType.Varchar2).Value = objEntityCategory.Search_Field;
            }
            cmdReadCategoryListBySearch.Parameters.Add("C_DATABASE_FIELD", OracleDbType.Varchar2).Value = objEntityCategory.DataBase_Field;
            cmdReadCategoryListBySearch.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCategory.Status;
            cmdReadCategoryListBySearch.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCategory.Cancel_Status;
            cmdReadCategoryListBySearch.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityCategory.CommonSearchTerm;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityCategory.SearchName;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityCategory.SearchType;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_CATEGORY", OracleDbType.Varchar2).Value = objEntityCategory.SearchCategory;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_GROUP", OracleDbType.Varchar2).Value = objEntityCategory.SearchGroup;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_SALE", OracleDbType.Varchar2).Value = objEntityCategory.SearchSale;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_PURCHASE", OracleDbType.Varchar2).Value = objEntityCategory.SearchPurchase;
            cmdReadCategoryListBySearch.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityCategory.OrderColumn;
            cmdReadCategoryListBySearch.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityCategory.OrderMethod;
            cmdReadCategoryListBySearch.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityCategory.PageMaxSize;
            cmdReadCategoryListBySearch.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityCategory.PageNumber;
            cmdReadCategoryListBySearch.Parameters.Add("M_ACCNT_SPEC", OracleDbType.Int32).Value = objEntityCategory.User_Id;
            cmdReadCategoryListBySearch.Parameters.Add("M_COMMO", OracleDbType.Int32).Value = objEntityCategory.PurchaseLedgerID;
            cmdReadCategoryListBySearch.Parameters.Add("M_CODE", OracleDbType.Varchar2).Value = objEntityCategory.SearchCode;
            cmdReadCategoryListBySearch.Parameters.Add("M_CTGID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;

            cmdReadCategoryListBySearch.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCategoryListBySearch);
            return dtCategoryList;
        }
        // This Method checks Category CODE in the database for duplication.
        public string CheckCategoryCode(clsEntityCategory objEntityCategory)
        {
            string strQueryCheckCategoryCode = "ITEM_CATEGORY.SP_CHECK_CATEGORY_CODE";
            OracleCommand cmdCheckCategoryCode = new OracleCommand();
            cmdCheckCategoryCode.CommandText = strQueryCheckCategoryCode;
            cmdCheckCategoryCode.CommandType = CommandType.StoredProcedure;
            cmdCheckCategoryCode.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCategory.Category_Id;
            cmdCheckCategoryCode.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCategory.Commodity_Code;
            cmdCheckCategoryCode.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdCheckCategoryCode.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdCheckCategoryCode.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCategoryCode);
            string strReturn = cmdCheckCategoryCode.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCategoryCode.Dispose();
            return strReturn;
        }
        public DataTable ReadLedgers(clsEntityCategory objEntityCategory)
        {
            string strQueryText = "ITEM_CATEGORY.SP_READ_LEDGERS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCategory.Org_Id;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCategory.Corp_Id;
            cmdReadPayGrd.Parameters.Add("R_NATURE", OracleDbType.Int32).Value = objEntityCategory.NatureSts;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }


    }
}
