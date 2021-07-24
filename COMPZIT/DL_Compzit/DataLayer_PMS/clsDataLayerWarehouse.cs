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
    public class clsDataLayerWarehouse
    {

        public DataTable ReadCountry(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_READ_COUNTRY";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public DataTable ReadState(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_READ_STATE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_CNTRYID", OracleDbType.Int32).Value = objEntityWarehouse.CntryId;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public DataTable ReadCity(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_READ_CITY";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = objEntityWarehouse.StateId;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public void InsertWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_INSERT_WAREHOUSE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WRHS_NAME", OracleDbType.Varchar2).Value = objEntityWarehouse.WarehouseName;
            cmdWrhs.Parameters.Add("P_WRHS_CODE", OracleDbType.Varchar2).Value = objEntityWarehouse.WarehouseCode;
            cmdWrhs.Parameters.Add("P_ADDRSS1", OracleDbType.Varchar2).Value = objEntityWarehouse.Address1;
            cmdWrhs.Parameters.Add("P_ADDRSS2", OracleDbType.Varchar2).Value = objEntityWarehouse.Address2;
            cmdWrhs.Parameters.Add("P_ADDRSS3", OracleDbType.Varchar2).Value = objEntityWarehouse.Address3;
            cmdWrhs.Parameters.Add("P_CNTRYID", OracleDbType.Int32).Value = objEntityWarehouse.CntryId;
            if (objEntityWarehouse.StateId != 0)
            {
                cmdWrhs.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = objEntityWarehouse.StateId;
            }
            else
            {
                cmdWrhs.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = DBNull.Value;
            }
            if (objEntityWarehouse.CityId != 0)
            {
                cmdWrhs.Parameters.Add("P_CITYID", OracleDbType.Int32).Value = objEntityWarehouse.CityId;
            }
            else
            {
                cmdWrhs.Parameters.Add("P_CITYID", OracleDbType.Int32).Value = DBNull.Value;
            }
            cmdWrhs.Parameters.Add("P_POSTLCODE", OracleDbType.Varchar2).Value = objEntityWarehouse.PostalCode;
            cmdWrhs.Parameters.Add("P_PHONE", OracleDbType.Varchar2).Value = objEntityWarehouse.Phone;
            cmdWrhs.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = objEntityWarehouse.Email;
            cmdWrhs.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityWarehouse.Status;
            cmdWrhs.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWarehouse.CorpId;
            cmdWrhs.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWarehouse.OrgId;
            cmdWrhs.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityWarehouse.UserId;
            clsDataLayer.ExecuteNonQuery(cmdWrhs);
        }

        public DataTable ReadWarehouseList(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_READ_WAREHOUSE_LIST";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWarehouse.CorpId;
            cmdWrhs.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWarehouse.OrgId;
            cmdWrhs.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityWarehouse.Status;
            cmdWrhs.Parameters.Add("P_CNCLSTS", OracleDbType.Int32).Value = objEntityWarehouse.CancelSts;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public DataTable ReadWarehouseById(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_READ_WAREHOUSE_BYID";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WAREHSID", OracleDbType.Int32).Value = objEntityWarehouse.WarehouseId;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public void UpdateWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_UPDATE_WAREHOUSE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WAREHSID", OracleDbType.Int32).Value = objEntityWarehouse.WarehouseId;
            cmdWrhs.Parameters.Add("P_WRHS_NAME", OracleDbType.Varchar2).Value = objEntityWarehouse.WarehouseName;
            cmdWrhs.Parameters.Add("P_WRHS_CODE", OracleDbType.Varchar2).Value = objEntityWarehouse.WarehouseCode;
            cmdWrhs.Parameters.Add("P_ADDRSS1", OracleDbType.Varchar2).Value = objEntityWarehouse.Address1;
            cmdWrhs.Parameters.Add("P_ADDRSS2", OracleDbType.Varchar2).Value = objEntityWarehouse.Address2;
            cmdWrhs.Parameters.Add("P_ADDRSS3", OracleDbType.Varchar2).Value = objEntityWarehouse.Address3;
            cmdWrhs.Parameters.Add("P_CNTRYID", OracleDbType.Int32).Value = objEntityWarehouse.CntryId;
            if (objEntityWarehouse.StateId != 0)
            {
                cmdWrhs.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = objEntityWarehouse.StateId;
            }
            else
            {
                cmdWrhs.Parameters.Add("P_STATEID", OracleDbType.Int32).Value = DBNull.Value;
            }
            if (objEntityWarehouse.CityId != 0)
            {
                cmdWrhs.Parameters.Add("P_CITYID", OracleDbType.Int32).Value = objEntityWarehouse.CityId;
            }
            else
            {
                cmdWrhs.Parameters.Add("P_CITYID", OracleDbType.Int32).Value = DBNull.Value;
            }
            cmdWrhs.Parameters.Add("P_POSTLCODE", OracleDbType.Varchar2).Value = objEntityWarehouse.PostalCode;
            cmdWrhs.Parameters.Add("P_PHONE", OracleDbType.Varchar2).Value = objEntityWarehouse.Phone;
            cmdWrhs.Parameters.Add("P_EMAIL", OracleDbType.Varchar2).Value = objEntityWarehouse.Email;
            cmdWrhs.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityWarehouse.Status;
            cmdWrhs.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityWarehouse.UserId;
            clsDataLayer.ExecuteNonQuery(cmdWrhs);
        }

        public void CancelWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_CANCEL_WAREHOUSE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WAREHSID", OracleDbType.Int32).Value = objEntityWarehouse.WarehouseId;
            cmdWrhs.Parameters.Add("P_CNCLREASON", OracleDbType.Varchar2).Value = objEntityWarehouse.CnclReason;
            cmdWrhs.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityWarehouse.UserId;
            clsDataLayer.ExecuteNonQuery(cmdWrhs);
        }

        public void StatusChangeWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_STATUSCHNG_WAREHOUSE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WAREHSID", OracleDbType.Int32).Value = objEntityWarehouse.WarehouseId;
            cmdWrhs.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityWarehouse.Status;
            clsDataLayer.ExecuteNonQuery(cmdWrhs);
        }

        public DataTable CheckNameDuplictnWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_CHECK_DUPNAME_WAREHOUSE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WAREHSID", OracleDbType.Int32).Value = objEntityWarehouse.WarehouseId;
            cmdWrhs.Parameters.Add("P_WRHS_NAME", OracleDbType.Varchar2).Value = objEntityWarehouse.WarehouseName;
            cmdWrhs.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWarehouse.CorpId;
            cmdWrhs.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWarehouse.OrgId;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public DataTable CheckCodeDuplictnWarehouse(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_CHECK_DUPCODE_WAREHOUSE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_WAREHSID", OracleDbType.Int32).Value = objEntityWarehouse.WarehouseId;
            cmdWrhs.Parameters.Add("P_WRHS_CODE", OracleDbType.Varchar2).Value = objEntityWarehouse.WarehouseCode;
            cmdWrhs.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWarehouse.CorpId;
            cmdWrhs.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWarehouse.OrgId;
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }

        public DataTable ReadWarehouseListPage(clsEntityWarehouse objEntityWarehouse)
        {
            string strQuery = "PMS_WAREHOUSE.SP_READ_WAREHOUSE_LIST_PAGE";
            OracleCommand cmdWrhs = new OracleCommand();
            cmdWrhs.CommandText = strQuery;
            cmdWrhs.CommandType = CommandType.StoredProcedure;
            cmdWrhs.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWarehouse.CorpId;
            cmdWrhs.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWarehouse.OrgId;
            cmdWrhs.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityWarehouse.Status;
            cmdWrhs.Parameters.Add("P_CNCLSTS", OracleDbType.Int32).Value = objEntityWarehouse.CancelSts;
            //------------------------------------------Pagination------------------------------------------------
            cmdWrhs.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityWarehouse.CommonSearchTerm;
            cmdWrhs.Parameters.Add("P_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityWarehouse.SearchName;
            cmdWrhs.Parameters.Add("P_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityWarehouse.SearchCode;
            cmdWrhs.Parameters.Add("P_SEARCH_ADDRSS", OracleDbType.Varchar2).Value = objEntityWarehouse.SearchAddress;
            cmdWrhs.Parameters.Add("P_SEARCH_CNTRY", OracleDbType.Varchar2).Value = objEntityWarehouse.SearchCountry;
            cmdWrhs.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityWarehouse.OrderColumn;
            cmdWrhs.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityWarehouse.OrderMethod;
            cmdWrhs.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityWarehouse.PageMaxSize;
            cmdWrhs.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityWarehouse.PageNumber;
            //------------------------------------------Pagination------------------------------------------------
            cmdWrhs.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdWrhs);
            return dt;
        }


    }
}
