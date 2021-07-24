using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:23/03/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding cutomer group detail and also updating,canceling and viewing the same .


namespace DL_Compzit
{
    public class clsDataLayerCustomerGroup
    {
        
        // This Method adds customer group details to the customer group table
        public void AddCustomerGroup(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryAddCustomerGroup = "CUSTOMER_GROUP.SP_INSERT_CUSTOMER_GROUP";
            using (OracleCommand cmdAddCust = new OracleCommand())
            {
                cmdAddCust.CommandText = strQueryAddCustomerGroup;
                cmdAddCust.CommandType = CommandType.StoredProcedure;
                cmdAddCust.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCust.Customer_Group_name;
                cmdAddCust.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCust.Org_Id;
                cmdAddCust.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCust.Corp_Id;
                cmdAddCust.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Status;
                cmdAddCust.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityCust.User_Id;
                cmdAddCust.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCust.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdAddCust);
            }
        }

        //Method for Updating customer group Details
        public void UpdateCustomerGroup(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryUpdateCust = "CUSTOMER_GROUP.SP_UPDATE_CUSTOMER_GROUP";
            using (OracleCommand cmdUpdateCust = new OracleCommand())
            {
                cmdUpdateCust.CommandText = strQueryUpdateCust;
                cmdUpdateCust.CommandType = CommandType.StoredProcedure;
                cmdUpdateCust.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Id;
                cmdUpdateCust.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCust.Customer_Group_name;
                cmdUpdateCust.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Status;
                cmdUpdateCust.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityCust.User_Id;
                cmdUpdateCust.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCust.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCust);
            }
        }

        //Method for cancel customer group
        public void CancelCustomerGroup(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryCancelCust = "CUSTOMER_GROUP.SP_CANCEL_CUSTOMER_GROUP";
            using (OracleCommand cmdCancelCust = new OracleCommand())
            {
                cmdCancelCust.CommandText = strQueryCancelCust;
                cmdCancelCust.CommandType = CommandType.StoredProcedure;
                cmdCancelCust.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Id;
                cmdCancelCust.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCust.User_Id;
                cmdCancelCust.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCust.D_Date;
                cmdCancelCust.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityCust.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCust);
            }
        }

        // This Method checks customer group name in the database for duplication.
        public string CheckCustomerGroupName(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryCheckCustName = "CUSTOMER_GROUP.SP_CHECK_CUSTOMER_GROUP_NAME";
            OracleCommand cmdCheckCustName = new OracleCommand();
            cmdCheckCustName.CommandText = strQueryCheckCustName;
            cmdCheckCustName.CommandType = CommandType.StoredProcedure;
            cmdCheckCustName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Id;
            cmdCheckCustName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCust.Customer_Group_name;
            cmdCheckCustName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCust.Org_Id;
            cmdCheckCustName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCust.Corp_Id;
            cmdCheckCustName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCustName);
            string strReturn = cmdCheckCustName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCustName.Dispose();
            return strReturn;
        }

        // This Method will fetch customer group table by ID
        public DataTable ReadCustomerGroupById(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryReadCustById = "CUSTOMER_GROUP.SP_READ_CUSTOMER_GROUP_BYID";
            OracleCommand cmdReadCustById = new OracleCommand();
            cmdReadCustById.CommandText = strQueryReadCustById;
            cmdReadCustById.CommandType = CommandType.StoredProcedure;
            cmdReadCustById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Id;
            cmdReadCustById.Parameters.Add("C_CUSTOMER_GROUP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCust = new DataTable();
            dtCust = clsDataLayer.ExecuteReader(cmdReadCustById);
            return dtCust;
        }
        // This Method will fetch customer group table 
        public DataTable ReadCustomerGroupList(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryReadCust = "CUSTOMER_GROUP.SP_READ_CUSTOMER_LIST";
            OracleCommand cmdReadCust = new OracleCommand();
            cmdReadCust.CommandText = strQueryReadCust;
            cmdReadCust.CommandType = CommandType.StoredProcedure;
            cmdReadCust.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Status;
            cmdReadCust.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCust.Cancel_Status;
            cmdReadCust.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCust.Org_Id;
            cmdReadCust.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCust.Corp_Id;
            cmdReadCust.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityCust.CommonSearchTerm;
            cmdReadCust.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityCust.SearchName;
            cmdReadCust.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityCust.OrderColumn;
            cmdReadCust.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityCust.OrderMethod;
            cmdReadCust.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityCust.PageMaxSize;
            cmdReadCust.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityCust.PageNumber;
            cmdReadCust.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCust = new DataTable();
            dtCust = clsDataLayer.ExecuteReader(cmdReadCust);
            return dtCust;
        }
        public void UpdateStatus(clsEntityCustomerGroup objEntityCust)
        {
            string strQueryUpdateCust = "CUSTOMER_GROUP.SP_UPD_CUSTOMER_GROUP_STS";
            using (OracleCommand cmdUpdateCust = new OracleCommand())
            {
                cmdUpdateCust.CommandText = strQueryUpdateCust;
                cmdUpdateCust.CommandType = CommandType.StoredProcedure;
                cmdUpdateCust.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Id;
                cmdUpdateCust.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCust.Customer_Group_Status;
                cmdUpdateCust.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityCust.User_Id;
                cmdUpdateCust.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCust.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCust);
            }
        }
    }
}
