using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:18/03/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding tax detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
    public class clsDataLayerTaxMaster
    {
        // This Method adds Tax details to the tax master table
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        public void AddTaxMstr(clsEntityTaxMaster objEntityTax)
        {
            string strQueryAddTaxMstr = "TAX_MASTER.SP_INSERT_TAX";
            using (OracleCommand cmdAddTax = new OracleCommand())
            {
                cmdAddTax.CommandText = strQueryAddTaxMstr;
                cmdAddTax.CommandType = CommandType.StoredProcedure;
                cmdAddTax.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTax.Tax_name;
                cmdAddTax.Parameters.Add("T_PERCENTAGE", OracleDbType.Decimal).Value = objEntityTax.Tax_Percentage;
                cmdAddTax.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTax.Org_Id;
                cmdAddTax.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTax.Corp_Id;
                cmdAddTax.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTax.Tax_Status;
                cmdAddTax.Parameters.Add("T_INSUSERID", OracleDbType.Int32).Value = objEntityTax.User_Id;
                cmdAddTax.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTax.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdAddTax);
            }
        }

        //Method for change the active / inactive status of tax master
        public void TaxStatusChange(clsEntityTaxMaster objEntityTax)
        {
            string strQueryTaxStatus = "TAX_MASTER.SP_UPDATE_STATUS";
            using (OracleCommand cmdTaxStatus = new OracleCommand())
            {
                cmdTaxStatus.CommandText = strQueryTaxStatus;
                cmdTaxStatus.CommandType = CommandType.StoredProcedure;
                cmdTaxStatus.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTax.Tax_Id;
                cmdTaxStatus.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTax.Tax_Status;
                cmdTaxStatus.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTax.User_Id;
                cmdTaxStatus.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTax.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdTaxStatus);
            }
        }

        //Method for Updating tax Details
        public void UpdateTax(clsEntityTaxMaster objEntityTax)
        {
            string strQueryUpdateTax = "TAX_MASTER.SP_UPDATE_TAX";
            using (OracleCommand cmdUpdateTax = new OracleCommand())
            {
                cmdUpdateTax.CommandText = strQueryUpdateTax;
                cmdUpdateTax.CommandType = CommandType.StoredProcedure;
                cmdUpdateTax.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTax.Tax_Id;
                cmdUpdateTax.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTax.Tax_name;
                cmdUpdateTax.Parameters.Add("T_PERCENTAGE", OracleDbType.Decimal).Value = objEntityTax.Tax_Percentage;
                cmdUpdateTax.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTax.Tax_Status;
                cmdUpdateTax.Parameters.Add("T_UPDUSERID", OracleDbType.Int32).Value = objEntityTax.User_Id;
                cmdUpdateTax.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTax.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateTax);
            }
        }

        //Method for cancel Tax
        public void CancelTax(clsEntityTaxMaster objEntityTax)
        {
            string strQueryCancelTax = "TAX_MASTER.SP_CANCEL_TAX";
            using (OracleCommand cmdCancelTax = new OracleCommand())
            {
                cmdCancelTax.CommandText = strQueryCancelTax;
                cmdCancelTax.CommandType = CommandType.StoredProcedure;
                cmdCancelTax.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTax.Tax_Id;
                cmdCancelTax.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTax.User_Id;
                cmdCancelTax.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTax.D_Date;
                cmdCancelTax.Parameters.Add("T_REASON", OracleDbType.Varchar2).Value = objEntityTax.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelTax);
            }
        }

        // This Method checks tax name in the database for duplication.
        public string CheckTaxName(clsEntityTaxMaster objEntityTax)
        {
            string strQueryCheckTaxName = "TAX_MASTER.SP_CHECK_TAX_NAME";
            OracleCommand cmdCheckTaxName = new OracleCommand();
            cmdCheckTaxName.CommandText = strQueryCheckTaxName;
            cmdCheckTaxName.CommandType = CommandType.StoredProcedure;
            cmdCheckTaxName.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTax.Tax_Id;
            cmdCheckTaxName.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTax.Tax_name;
            cmdCheckTaxName.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTax.Org_Id;
            cmdCheckTaxName.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTax.Corp_Id;
            cmdCheckTaxName.Parameters.Add("T_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckTaxName);
            string strReturn = cmdCheckTaxName.Parameters["T_COUNT"].Value.ToString();
            cmdCheckTaxName.Dispose();
            return strReturn;
        }

        // This Method will fetch Tax master table by ID
        public DataTable ReadTaxById(clsEntityTaxMaster objEntityTax)
        {
            string strQueryReadTaxById = "TAX_MASTER.SP_READ_TAX_BYID";
            OracleCommand cmdReadTaxById = new OracleCommand();
            cmdReadTaxById.CommandText = strQueryReadTaxById;
            cmdReadTaxById.CommandType = CommandType.StoredProcedure;
            cmdReadTaxById.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTax.Tax_Id;
            cmdReadTaxById.Parameters.Add("T_BANK", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtBank = new DataTable();
            dtBank = clsDataLayer.ExecuteReader(cmdReadTaxById);
            return dtBank;
        }
        //Method for cancelling tax master so updating cancel related fields
        public void CancelTaxMaster(clsEntityTaxMaster objEntityTax)
        {
            string strQueryCancelTax = "TAX_MASTER.SP_CANCEL_TAX";
            using (OracleCommand cmdCancelTax = new OracleCommand())
            {
                cmdCancelTax.InitialLONGFetchSize = 1000;
                cmdCancelTax.CommandText = strQueryCancelTax;
                cmdCancelTax.CommandType = CommandType.StoredProcedure;
                cmdCancelTax.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTax.Tax_Id;
                cmdCancelTax.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTax.User_Id;
                cmdCancelTax.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTax.D_Date;
                cmdCancelTax.Parameters.Add("T_REASON", OracleDbType.Varchar2).Value = objEntityTax.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelTax);
            }
        }
        // This Method will fetch Tax master table 
        public DataTable ReadTaxList(clsEntityTaxMaster objEntityTax)
        {
            string strQueryReadTax= "TAX_MASTER.SP_READ_TAXLIST";
            OracleCommand cmdReadTax = new OracleCommand();
            cmdReadTax.CommandText = strQueryReadTax;
            cmdReadTax.CommandType = CommandType.StoredProcedure;
            cmdReadTax.Parameters.Add("T_OPTION", OracleDbType.Int32).Value = objEntityTax.Tax_Status;
            cmdReadTax.Parameters.Add("T_CANCEL", OracleDbType.Int32).Value = objEntityTax.Cancel_Status;
            cmdReadTax.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTax.Org_Id;
            cmdReadTax.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTax.Corp_Id;
            cmdReadTax.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityTax.CommonSearchTerm;
            cmdReadTax.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityTax.SearchName;
            cmdReadTax.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityTax.OrderColumn;
            cmdReadTax.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityTax.OrderMethod;
            cmdReadTax.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityTax.PageMaxSize;
            cmdReadTax.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityTax.PageNumber;
            cmdReadTax.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadTax);
            return dtList;
        }

    }
}
