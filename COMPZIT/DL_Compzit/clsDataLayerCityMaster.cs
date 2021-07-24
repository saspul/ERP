using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:18/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
   public class clsDataLayerCityMaster
    {
        // This Method add City details to the database
        public void AddCityDetails(clsEntityCityMaster objEntCityMaster)
        {
            using (OracleCommand cmdAddCity = new OracleCommand())
            {
                cmdAddCity.InitialLONGFetchSize = 1000;
                cmdAddCity.CommandText = "CITY_MASTER.SP_INSERT_CITY_MASTER";
                cmdAddCity.CommandType = CommandType.StoredProcedure;
                cmdAddCity.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntCityMaster.CityName;
                cmdAddCity.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntCityMaster.CityStateId;
                cmdAddCity.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntCityMaster.CityStatus;
                cmdAddCity.Parameters.Add("C_PREINSTL", OracleDbType.Int32).Value = objEntCityMaster.Preinstall;
                cmdAddCity.Parameters.Add("C_INRTUSRID", OracleDbType.Int32).Value = objEntCityMaster.UserId;
                cmdAddCity.Parameters.Add("C_COUNTRYID", OracleDbType.Int32).Value = objEntCityMaster.CountryId;
                clsDataLayer.ExecuteNonQuery(cmdAddCity);
            }
        }

        // This Method read state details from the database
        public DataTable ReadStateDetails()
        {
            DataTable dtStateDetails = new DataTable();
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = "CITY_MASTER.SP_READ_STATE";
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("C_STATEID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtStateDetails = clsDataLayer.ExecuteReader(cmdReadState);
            }
            return dtStateDetails;
        }

        // This Method fetch state table from the database
        public DataTable ReadCityTable(clsEntityCityMaster objEntCityMaster)
        {
            DataTable dtStateTable = new DataTable();
            using (OracleCommand cmdReadCity = new OracleCommand())
            {
                cmdReadCity.CommandText = "CITY_MASTER.SP_READ_CITY_MASTER";
                cmdReadCity.CommandType = CommandType.StoredProcedure;
                cmdReadCity.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntCityMaster.CityStatus;
                cmdReadCity.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntCityMaster.Cancel_Status;
                cmdReadCity.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntCityMaster.CommonSearchTerm;
                cmdReadCity.Parameters.Add("M_SEARCH_CITY", OracleDbType.Varchar2).Value = objEntCityMaster.SearchCity;
                cmdReadCity.Parameters.Add("M_SEARCH_STATE", OracleDbType.Varchar2).Value = objEntCityMaster.SearchState;
                cmdReadCity.Parameters.Add("M_SEARCH_COUNTRY", OracleDbType.Varchar2).Value = objEntCityMaster.SearchCountry;
                cmdReadCity.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntCityMaster.OrderColumn;
                cmdReadCity.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntCityMaster.OrderMethod;
                cmdReadCity.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntCityMaster.PageMaxSize;
                cmdReadCity.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntCityMaster.PageNumber;
                cmdReadCity.Parameters.Add("C_CITYMASTER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtStateTable = clsDataLayer.ExecuteReader(cmdReadCity);
            }
            return dtStateTable;
        }

        public DataTable ReadCityMasterEdit(clsEntityCityMaster objEntCityMaster)
        {
            //Read city master table according to their Id(Primary Key)
            using (OracleCommand cmdReadCityEdit = new OracleCommand())
            {
                cmdReadCityEdit.CommandText = "CITY_MASTER.SP_READ_CITY_MASTER_BYID";
                cmdReadCityEdit.CommandType = CommandType.StoredProcedure;
                cmdReadCityEdit.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntCityMaster.CityMasterId;
                cmdReadCityEdit.Parameters.Add("C_CITYMASTER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCityMasterEdit = new DataTable();
                dtCityMasterEdit = clsDataLayer.ExecuteReader(cmdReadCityEdit);
                return dtCityMasterEdit;
            }
        }
        public void UpdateCityDetails(clsEntityCityMaster objEntCityMaster)
        {
            //Method for updating City master table.
            using (OracleCommand cmdUpdateCity = new OracleCommand())
            {
                cmdUpdateCity.InitialLONGFetchSize = 1000;
                cmdUpdateCity.CommandText = "CITY_MASTER.SP_UPDATE_CITY_MASTER";
                cmdUpdateCity.CommandType = CommandType.StoredProcedure;
                cmdUpdateCity.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntCityMaster.CityMasterId;
                cmdUpdateCity.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntCityMaster.CityName;
                cmdUpdateCity.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntCityMaster.CityStateId;
                cmdUpdateCity.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntCityMaster.CityStatus;
                cmdUpdateCity.Parameters.Add("C_INRTUSRID", OracleDbType.Int32).Value = objEntCityMaster.UserId;
                cmdUpdateCity.Parameters.Add("C_UPDTDATE", OracleDbType.Date).Value = objEntCityMaster.Date;
                cmdUpdateCity.Parameters.Add("C_COUNTRYID", OracleDbType.Int32).Value = objEntCityMaster.CountryId;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCity);
            }
        }
        public void UpdateCityStatus(clsEntityCityMaster objCityMaster)
        {
            //Updating state status field in state master table.
            using (OracleCommand cmdUpdateCity = new OracleCommand())
            {
                cmdUpdateCity.InitialLONGFetchSize = 1000;
                cmdUpdateCity.CommandText = "CITY_MASTER.SP_UPDATE_CTYMASTRSTATUS";
                cmdUpdateCity.CommandType = CommandType.StoredProcedure;
                cmdUpdateCity.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCityMaster.CityMasterId;
                cmdUpdateCity.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objCityMaster.CityStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCity);
            }
        }
        public void UpdateCityCancel(clsEntityCityMaster objEntCityMaster)
        {
            //Method for updating city cancel details in state master table.
            using (OracleCommand cmdupdateCityCancel = new OracleCommand())
            {
                cmdupdateCityCancel.InitialLONGFetchSize = 1000;
                cmdupdateCityCancel.CommandText = "CITY_MASTER.SP_UPDATE_CTYMASTRCANCEL";
                cmdupdateCityCancel.CommandType = CommandType.StoredProcedure;
                cmdupdateCityCancel.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntCityMaster.CityMasterId;
                cmdupdateCityCancel.Parameters.Add("C_CANCELID", OracleDbType.Int32).Value = objEntCityMaster.UserId;
                cmdupdateCityCancel.Parameters.Add("C_CANCELREASON", OracleDbType.Varchar2).Value = objEntCityMaster.CityCancelReason;
                cmdupdateCityCancel.Parameters.Add("C_CANCELDATE", OracleDbType.Date).Value = objEntCityMaster.Date;
                clsDataLayer.ExecuteNonQuery(cmdupdateCityCancel);
            }
        }

        //Method for checking city name already existed on the table.
        public DataTable CheckCityName(clsEntityCityMaster objEntCityMaster)
        {
            using (OracleCommand cmdCheckCityName = new OracleCommand())
            {
                cmdCheckCityName.CommandText = "CITY_MASTER.SP_CHECK_CITY_NAME";
                cmdCheckCityName.CommandType = CommandType.StoredProcedure;
                cmdCheckCityName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntCityMaster.CityName;
                cmdCheckCityName.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntCityMaster.CityStateId;
                cmdCheckCityName.Parameters.Add("C_CITY", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCityName = new DataTable();
                dtCityName = clsDataLayer.ExecuteReader(cmdCheckCityName);
                return dtCityName;
            }
        }
        //Method for check city name already existed in table or not at the time of updation
        public string CheckCityNameUpdate(clsEntityCityMaster objEntCityMaster)
        {
                OracleCommand cmdCheckCityName = new OracleCommand();
                cmdCheckCityName.CommandText = "CITY_MASTER.SP_CHECK_CITY_NAMEUPDATE";
                cmdCheckCityName.CommandType = CommandType.StoredProcedure;
                cmdCheckCityName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntCityMaster.CityMasterId;
                cmdCheckCityName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntCityMaster.CityName;
                cmdCheckCityName.Parameters.Add("C_STATEID", OracleDbType.Int32).Value = objEntCityMaster.CityStateId;
                cmdCheckCityName.Parameters.Add("C_CITYCOUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckCityName);
                string strReturnCount = cmdCheckCityName.Parameters["C_CITYCOUNT"].Value.ToString();
                cmdCheckCityName.Dispose();
                return strReturnCount; ;
        }
    }
}
