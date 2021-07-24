using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
// CREATED BY:EVM-0001
// CREATED DATE:15/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Country detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
   public class clsDataLayerCountry
    {
        // This Method adds Country details to the database
       public void AddCountryMstr(clsEntityCountry objCntryMstr)
       {
           string strQueryAddCountryMstr = "COUNTRY_MASTER.SP_INSERT_GEN_COUNTRY_MSTR";
           using (OracleCommand cmdAddCountry = new OracleCommand())
           {
               cmdAddCountry.CommandText = strQueryAddCountryMstr;
               cmdAddCountry.CommandType = CommandType.StoredProcedure;
               cmdAddCountry.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objCntryMstr.CountryName;
               cmdAddCountry.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objCntryMstr.CountryStatus;
               cmdAddCountry.Parameters.Add("C_PREINSTL", OracleDbType.Int32).Value = objCntryMstr.Preinstall;
               cmdAddCountry.Parameters.Add("C_INS_USERID", OracleDbType.Int32).Value = objCntryMstr.CountryUserId;
               clsDataLayer.ExecuteNonQuery(cmdAddCountry);
           }
       }
       // This Method checks Country  Name in the database for duplication
       public string CheckDupCountryName(clsEntityCountry objCntry)
       {
           string strQueryCheckCountryName = "COUNTRY_MASTER.SP_CHECK_GEN_COUNTRY_NAME";
           OracleCommand cmdCheckCountryName = new OracleCommand();
           cmdCheckCountryName.CommandText = strQueryCheckCountryName;
           cmdCheckCountryName.CommandType = CommandType.StoredProcedure;
           cmdCheckCountryName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objCntry.CountryName;
           cmdCheckCountryName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckCountryName);
           string strReturn = cmdCheckCountryName.Parameters["C_COUNT"].Value.ToString();
           cmdCheckCountryName.Dispose();
           return strReturn;
       }
       // This Method displays Country  details from the database
       public DataTable ReadCountry(clsEntityCountry objCntry)
       {
           string strCommandText = "COUNTRY_MASTER.SP_READ_GEN_COUNTRY_MSTR";
           using (OracleCommand cmdGrid = new OracleCommand())
           {
               cmdGrid.CommandText = strCommandText;
               cmdGrid.CommandType = CommandType.StoredProcedure;
               cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objCntry.CountryStatus;
               cmdGrid.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objCntry.CountryUserId;
               cmdGrid.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objCntry.CommonSearchTerm;
               cmdGrid.Parameters.Add("M_SEARCH_COUNTRY", OracleDbType.Varchar2).Value = objCntry.SearchCountry;
               cmdGrid.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objCntry.OrderColumn;
               cmdGrid.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objCntry.OrderMethod;
               cmdGrid.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objCntry.PageMaxSize;
               cmdGrid.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objCntry.PageNumber;
               cmdGrid.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtGridDisp = new DataTable();
               dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
               return dtGridDisp;
           }
       }
       // This Method Updates the Status of Country in the database
       public void UpdateStatus(clsEntityCountry objCntry)
       {
           string strCommandText = "COUNTRY_MASTER.SP_UPDATE_GEN_COUNTRY_ACTIVE";
           using (OracleCommand cmdUpdateStatus = new OracleCommand())
           {
               cmdUpdateStatus.CommandText = strCommandText;
               cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
               cmdUpdateStatus.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCntry.CountryId;
               cmdUpdateStatus.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objCntry.CountryStatus;
               cmdUpdateStatus.Parameters.Add("C_UPD_USR_ID", OracleDbType.Int32).Value = objCntry.CountryUserId;
               cmdUpdateStatus.Parameters.Add("C_UPD_DATE", OracleDbType.Date).Value = objCntry.CountryDate;
               clsDataLayer.ExecuteNonQuery(cmdUpdateStatus);
           }
       }
       // This Method select the details from the database when Edit and View Button is Clicked
       public DataTable EditViewCountry(clsEntityCountry objCntry)
       {
           string strCommandText = "COUNTRY_MASTER.SP_READ_GEN_COUNTRY_BYID";
           using (OracleCommand cmdEditView = new OracleCommand())
           {
               cmdEditView.CommandText = strCommandText;
               cmdEditView.CommandType = CommandType.StoredProcedure;
               cmdEditView.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCntry.CountryId;
               cmdEditView.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtEditViewCountry = new DataTable();
               dtEditViewCountry = clsDataLayer.SelectDataTable(cmdEditView);
               return dtEditViewCountry;
           }
       }
       // This Method Updates  Corporate Pack details  to the database
       public void UpdateCountry(clsEntityCountry objCntry)
       {
           string strQueryUpdCrpPack = "COUNTRY_MASTER.SP_UPDATE_GEN_COUNTRY_MSTR";
           using (OracleCommand cmdUpdateCountry = new OracleCommand())
           {
               cmdUpdateCountry.CommandText = strQueryUpdCrpPack;
               cmdUpdateCountry.CommandType = CommandType.StoredProcedure;
               cmdUpdateCountry.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCntry.CountryId;
               cmdUpdateCountry.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objCntry.CountryName;
               cmdUpdateCountry.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objCntry.CountryStatus;
               cmdUpdateCountry.Parameters.Add("C_UPD_USR_ID", OracleDbType.Int32).Value = objCntry.CountryUserId;
               cmdUpdateCountry.Parameters.Add("C_UPD_DATE", OracleDbType.Date).Value = objCntry.CountryDate;
               clsDataLayer.ExecuteNonQuery(cmdUpdateCountry);
           }
       }
       //this method updates cancel user id and cancel reason to the database when cancel is clicked
       public void UpdateCancelClick(clsEntityCountry objCntry)
       {
           string strCommandText = "COUNTRY_MASTER.SP_CANCEL_GEN_COUNTRY";
           using (OracleCommand cmdUpadateCancel = new OracleCommand())
           {
               cmdUpadateCancel.CommandText = strCommandText;
               cmdUpadateCancel.CommandType = CommandType.StoredProcedure;
               cmdUpadateCancel.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCntry.CountryId;
               cmdUpadateCancel.Parameters.Add("C_CNCL_USR_ID", OracleDbType.Int32).Value = objCntry.CountryUserId;
               cmdUpadateCancel.Parameters.Add("C_CNCL_DATE", OracleDbType.Date).Value = objCntry.CountryDate;
               cmdUpadateCancel.Parameters.Add("C_CNCL_REASON", OracleDbType.Varchar2).Value = objCntry.CountryCancelReason;
               clsDataLayer.ExecuteNonQuery(cmdUpadateCancel);
           }
       }
       // This Method checks Country  Name in the database for duplication at the time of updation
       public string CheckDupCountryNameUpdate(clsEntityCountry objCntry)
       {
           string strQueryCheckCountryNameUpdate = "COUNTRY_MASTER.SP_CHECK_GEN_COUNTRY_UPDATE";
           OracleCommand cmdCheckCountryName = new OracleCommand();
           cmdCheckCountryName.CommandText = strQueryCheckCountryNameUpdate;
           cmdCheckCountryName.CommandType = CommandType.StoredProcedure;
           cmdCheckCountryName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objCntry.CountryId;
           cmdCheckCountryName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objCntry.CountryName;
           cmdCheckCountryName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckCountryName);
           string strReturn = cmdCheckCountryName.Parameters["C_COUNT"].Value.ToString();
           cmdCheckCountryName.Dispose();
           return strReturn;
       }
        
    }
}
