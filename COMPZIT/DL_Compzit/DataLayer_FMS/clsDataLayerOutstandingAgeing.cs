using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;


namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayerOutstandingAgeing
    {
        public DataTable Ageing_List(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntity.Mode;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        //--0044
        public DataTable Ageing_ListCrdtPrd(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_CUST_CRDTPRD";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntity.Mode;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Ageing_List_ByIdCrdPrd(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_BY_CUSTIDCRDT";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_CUSTID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_DUESTS", OracleDbType.Int32).Value = objEntity.DueSts;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        //--------------
        public DataTable Ageing_List_ById(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_BY_CUSTID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_CUSTID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


        public DataTable Ageing_List_Supplier(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_LIST_SUP";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntity.Mode;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Ageing_List_ById_Supplier(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_BY_SUPID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_CUSTID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_CREDIT", OracleDbType.Int32 ).Value = objEntity.ByCredit;
            cmdReadRcpt.Parameters.Add("R_DUESTS", OracleDbType.Int32).Value = objEntity.DueSts;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadOepningBalById(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_OB_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


        public DataTable ReadPendingReceipts(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_PENDING_RECPTS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadPendingPayments(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_PENDING_PYMNTS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadPostdatedChqDtls(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryText = "FMS_OUTSTANDING_AGEING.SP_READ_POSTDTCHQS_BYID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryText;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntity.CustomerId;
            cmdReadPayGrd.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = new DataTable();
            dt = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dt;
        }
        //--0044
        public DataTable Ageing_List_SupplierCrdtPrd(clsEntityOutstandingAgeing objEntity)
        {
            string strQueryReadRcpt = "FMS_OUTSTANDING_AGEING.SP_READ_AGEING_SUP_CRDTPRD";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_DATETO", OracleDbType.Date).Value = objEntity.ToDate;
            cmdReadRcpt.Parameters.Add("R_FROM_AGEING", OracleDbType.Int32).Value = objEntity.FromAgeing;
            cmdReadRcpt.Parameters.Add("R_TO_AGEING", OracleDbType.Int32).Value = objEntity.ToAgeing;
            cmdReadRcpt.Parameters.Add("R_MODE", OracleDbType.Int32).Value = objEntity.Mode;
            cmdReadRcpt.Parameters.Add("R_FINDATEFROM", OracleDbType.Date).Value = objEntity.FinYearFromDate;
            cmdReadRcpt.Parameters.Add("R_FINDATETO", OracleDbType.Date).Value = objEntity.FinYearToDate;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        //--0044


    }
}
