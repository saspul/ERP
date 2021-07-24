using System;
using System.Collections.Generic;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerSupplierOutstaning
    {
        public DataTable ReadSupplier(clsEntitySupplierOutstanding objEntityCustomer)
        {
            string strQueryReadRcpt = "FMS_SUPPLIER_OUTSTANDING.SP_READ_SUPPLIER";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCustomer.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATE", OracleDbType.Date).Value = objEntityCustomer.SupplierDate;
            cmdReadRcpt.Parameters.Add("R_FINSTART", OracleDbType.Date).Value = objEntityCustomer.FinancialStartDate;
            cmdReadRcpt.Parameters.Add("R_FINEND", OracleDbType.Date).Value = objEntityCustomer.FinancialEndDate;
            cmdReadRcpt.Parameters.Add("R_PRMRYGRPID", OracleDbType.Varchar2).Value = objEntityCustomer.PrimaryGrpIds;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadSuppliersDetails(clsEntitySupplierOutstanding objEntityCustomer)
        {
            string strQueryReadRcpt = "FMS_SUPPLIER_OUTSTANDING.SP_READ_SUPPLIER_DTLS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCustomer.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntityCustomer.Ledger_id;
            cmdReadRcpt.Parameters.Add("R_DATE", OracleDbType.Date).Value = objEntityCustomer.SupplierDate;
            cmdReadRcpt.Parameters.Add("R_FINSTART", OracleDbType.Date).Value = objEntityCustomer.FinancialStartDate;
            cmdReadRcpt.Parameters.Add("R_FINEND", OracleDbType.Date).Value = objEntityCustomer.FinancialEndDate;
            cmdReadRcpt.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntityCustomer.TransactionType;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadSupplierInfo(clsEntitySupplierOutstanding objEntityCustomer)
        {
            string strQueryReadRcpt = "FMS_SUPPLIER_OUTSTANDING.SP_READ_SUPPLIER_INFO";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCustomer.Organisation_Id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCustomer.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntityCustomer.Ledger_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
    }
}
