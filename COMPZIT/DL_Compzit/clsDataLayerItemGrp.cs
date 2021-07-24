using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.DataAccess.Client;
using System.Data;
using EL_Compzit;
using DL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:16/06/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Item Grp detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
   public class clsDataLayerItemGrp
    {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds Item Group details to the GN_Item_GROUP  table
        public void AddItemGrp(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryAddBankMstr = "PRODUCT_GROUP.SP_INS_ITEM_DETAIL";
            using (OracleCommand cmdAddBank = new OracleCommand())
            {
                cmdAddBank.CommandText = strQueryAddBankMstr;
                cmdAddBank.CommandType = CommandType.StoredProcedure;
                cmdAddBank.Parameters.Add("I_NAME", OracleDbType.Varchar2).Value = objEntityItemGrp.ItemGrp_name;
                cmdAddBank.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityItemGrp.Org_Id;
                cmdAddBank.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityItemGrp.Corp_Id;
                cmdAddBank.Parameters.Add("I_STATUS", OracleDbType.Int32).Value = objEntityItemGrp.Status;
                cmdAddBank.Parameters.Add("I_INSUSERID", OracleDbType.Int32).Value = objEntityItemGrp.User_Id;
                cmdAddBank.Parameters.Add("I_GRPCODE", OracleDbType.Varchar2).Value = objEntityItemGrp.Group_Code;
                if (objEntityItemGrp.Purchase_Tax == 0)
                    cmdAddBank.Parameters.Add("I_PURCHTAX", OracleDbType.Int32).Value = null;
                else
                    cmdAddBank.Parameters.Add("I_PURCHTAX", OracleDbType.Int32).Value = objEntityItemGrp.Purchase_Tax;
                if (objEntityItemGrp.Sales_Tax == 0)
                    cmdAddBank.Parameters.Add("I_SALESTAX", OracleDbType.Int32).Value = null;
                else
                    cmdAddBank.Parameters.Add("I_SALESTAX", OracleDbType.Int32).Value = objEntityItemGrp.Sales_Tax;
                clsDataLayer.ExecuteNonQuery(cmdAddBank);
            }
        }
        //Method for change the active / inactive status of Item group
        public void ItemGroupStatusChange(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryItemStatus = "PRODUCT_GROUP.SP_UPDATE_STATUS";
            using (OracleCommand cmdSuppStatus = new OracleCommand())
            {
                cmdSuppStatus.CommandText = strQueryItemStatus;
                cmdSuppStatus.CommandType = CommandType.StoredProcedure;
                cmdSuppStatus.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityItemGrp.ItemGrp_Id;
                cmdSuppStatus.Parameters.Add("I_STATUS", OracleDbType.Int32).Value = objEntityItemGrp.Status;
                cmdSuppStatus.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityItemGrp.User_Id;
                cmdSuppStatus.Parameters.Add("I_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdSuppStatus);
            }
        }

        //Method for Updating Item group Details
        public void UpdateItemGroup(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryUpdateSup = "PRODUCT_GROUP.SP_UPDATE_ITEM_GROUP";
            using (OracleCommand cmdUpdateItem = new OracleCommand())
            {
                cmdUpdateItem.CommandText = strQueryUpdateSup;
                cmdUpdateItem.CommandType = CommandType.StoredProcedure;
                cmdUpdateItem.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityItemGrp.ItemGrp_Id;
                cmdUpdateItem.Parameters.Add("I_NAME", OracleDbType.Varchar2).Value = objEntityItemGrp.ItemGrp_name;
                cmdUpdateItem.Parameters.Add("I_STATUS", OracleDbType.Int32).Value = objEntityItemGrp.Status;
                cmdUpdateItem.Parameters.Add("I_UPDUSERID", OracleDbType.Int32).Value = objEntityItemGrp.User_Id;
                cmdUpdateItem.Parameters.Add("I_DATE", OracleDbType.Date).Value = objEntityItemGrp.D_Date;
                cmdUpdateItem.Parameters.Add("I_GRPCODE", OracleDbType.Varchar2).Value = objEntityItemGrp.Group_Code;
                if (objEntityItemGrp.Purchase_Tax == 0)
                    cmdUpdateItem.Parameters.Add("I_PURCHTAX", OracleDbType.Int32).Value = null;
                else
                    cmdUpdateItem.Parameters.Add("I_PURCHTAX", OracleDbType.Int32).Value = objEntityItemGrp.Purchase_Tax;
                if (objEntityItemGrp.Sales_Tax == 0)
                    cmdUpdateItem.Parameters.Add("I_SALESTAX", OracleDbType.Int32).Value = null;
                else
                    cmdUpdateItem.Parameters.Add("I_SALESTAX", OracleDbType.Int32).Value = objEntityItemGrp.Sales_Tax;
                
                clsDataLayer.ExecuteNonQuery(cmdUpdateItem);
            }
        }

        //Method for cancel Item group
        public void CancelItemGroup(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryCancelItemGrp = "PRODUCT_GROUP.SP_CANCEL_ITEM_GROUP";
            using (OracleCommand cmdCancelItemGrp = new OracleCommand())
            {
                cmdCancelItemGrp.CommandText = strQueryCancelItemGrp;
                cmdCancelItemGrp.CommandType = CommandType.StoredProcedure;
                cmdCancelItemGrp.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityItemGrp.ItemGrp_Id;
                cmdCancelItemGrp.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityItemGrp.User_Id;
                cmdCancelItemGrp.Parameters.Add("I_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelItemGrp.Parameters.Add("I_REASON", OracleDbType.Varchar2).Value = objEntityItemGrp.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelItemGrp);
            }
        }

        // This Method checks Item group name in the database for duplication.
        public string CheckItemGroupName(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryCheckItemGrpName = "PRODUCT_GROUP.SP_CHECK_ITEM_GROUP_NAME";
            OracleCommand cmdCheckItemGrpName = new OracleCommand();
            cmdCheckItemGrpName.CommandText = strQueryCheckItemGrpName;
            cmdCheckItemGrpName.CommandType = CommandType.StoredProcedure;
            cmdCheckItemGrpName.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityItemGrp.ItemGrp_Id;
            cmdCheckItemGrpName.Parameters.Add("I_NAME", OracleDbType.Varchar2).Value = objEntityItemGrp.ItemGrp_name;
            cmdCheckItemGrpName.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityItemGrp.Org_Id;
            cmdCheckItemGrpName.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityItemGrp.Corp_Id;
            cmdCheckItemGrpName.Parameters.Add("I_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckItemGrpName);
            string strReturn = cmdCheckItemGrpName.Parameters["I_COUNT"].Value.ToString();
            cmdCheckItemGrpName.Dispose();
            return strReturn;
        }

        // This Method will fetch Item group table by ID
        public DataTable ReadItemGroupById(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryReadItemGrptById = "PRODUCT_GROUP.SP_READ_ITEM_GROUP_BYID";
            OracleCommand cmdReadItemGrpById = new OracleCommand();
            cmdReadItemGrpById.CommandText = strQueryReadItemGrptById;
            cmdReadItemGrpById.CommandType = CommandType.StoredProcedure;
            cmdReadItemGrpById.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityItemGrp.ItemGrp_Id;
            cmdReadItemGrpById.Parameters.Add("I_ITEM_GROUP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadItemGrpById);
            return dtBank;
        }
        // This Method checks Item group Code in the database for duplication.
        public string CheckItemGroupCode(clsEntityItemGrp objEntityItemGrp)
        {
            string strQueryCheckItemGrpCode = "PRODUCT_GROUP.SP_CHECK_ITEM_GROUP_CODE";
            OracleCommand cmdCheckItemGrpCode = new OracleCommand();
            cmdCheckItemGrpCode.CommandText = strQueryCheckItemGrpCode;
            cmdCheckItemGrpCode.CommandType = CommandType.StoredProcedure;
            cmdCheckItemGrpCode.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityItemGrp.ItemGrp_Id;
            cmdCheckItemGrpCode.Parameters.Add("I_CODE", OracleDbType.Varchar2).Value = objEntityItemGrp.Group_Code;
            cmdCheckItemGrpCode.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityItemGrp.Org_Id;
            cmdCheckItemGrpCode.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityItemGrp.Corp_Id;
            cmdCheckItemGrpCode.Parameters.Add("I_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckItemGrpCode);
            string strReturn = cmdCheckItemGrpCode.Parameters["I_COUNT"].Value.ToString();
            cmdCheckItemGrpCode.Dispose();
            return strReturn;
        }

        public DataTable ReadPurchaseTax(clsEntityItemGrp objEntityTax)
        {
            string strQueryReadCorporateDept = "PRODUCT_GROUP.SP_READ_PURCH_TAX";
            using (OracleCommand cmdReadCorpDept = new OracleCommand())
            {
                cmdReadCorpDept.CommandText = strQueryReadCorporateDept;
                cmdReadCorpDept.CommandType = CommandType.StoredProcedure;
                cmdReadCorpDept.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTax.Org_Id;
                cmdReadCorpDept.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTax.Corp_Id;
                cmdReadCorpDept.Parameters.Add("P_PURCHTAX", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtPurchTax = new DataTable();
                dtPurchTax = clsDataLayer.SelectDataTable(cmdReadCorpDept);
                return dtPurchTax;
            }
        }

        public DataTable ReadProductGrpList(clsEntityItemGrp objEntityItmGrp)
        {
            string strQueryReadProductGrpList = "PRODUCT_GROUP.SP_READ_PRODUCT_GRP_LIST";
            OracleCommand cmdReadProductGrpList = new OracleCommand();
            cmdReadProductGrpList.CommandText = strQueryReadProductGrpList;
            cmdReadProductGrpList.CommandType = CommandType.StoredProcedure;
            cmdReadProductGrpList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityItmGrp.Org_Id;
            cmdReadProductGrpList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityItmGrp.Corp_Id;
            cmdReadProductGrpList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadProductGrpList);
            return dtCategoryList;
        }




    }
}
