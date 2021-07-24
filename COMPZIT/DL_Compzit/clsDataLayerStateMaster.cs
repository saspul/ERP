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
    public class clsDataLayerStateMaster
    {
        // This Method add State details to the database
        public void AddStateDetails(clsEntityStateMaster objEntStateMaster)
        {
            using (OracleCommand cmdAddState = new OracleCommand())
            {
                cmdAddState.InitialLONGFetchSize = 1000;
                cmdAddState.CommandText = "STATE_MASTER.SP_INSERT_STATE_MASTER";
                cmdAddState.CommandType = CommandType.StoredProcedure;
                cmdAddState.Parameters.Add("S_NAME", OracleDbType.Varchar2).Value = objEntStateMaster.StateName;
                cmdAddState.Parameters.Add("S_CNTRTYID", OracleDbType.Int32).Value = objEntStateMaster.StateCountryId;
                cmdAddState.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = objEntStateMaster.StateStatus;
                cmdAddState.Parameters.Add("S_PREINSTL", OracleDbType.Int32).Value = objEntStateMaster.Preinstall;
                cmdAddState.Parameters.Add("S_INRTUSRID", OracleDbType.Int32).Value = objEntStateMaster.UserId;
                clsDataLayer.ExecuteNonQuery(cmdAddState);
            }
        }

        // This Method read Country details from the database
        public DataTable ReadCountryDetails()
        {
            string strQueryAddState = "STATE_MASTER.SP_READ_COUNTRY";
            DataTable dtCntryDetails = new DataTable();
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryAddState;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_CNTRYNAMEID", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtCntryDetails = clsDataLayer.ExecuteReader(cmdReadCountry);
            }
            return dtCntryDetails;
        }

        // This Method fetch state table from the database
        public DataTable ReadStateTable(clsEntityStateMaster objEntityState)
        {
            string strQueryAddState = "STATE_MASTER.SP_READ_STATE_MASTER";
            DataTable dtStateTable = new DataTable();
            using (OracleCommand cmdReadState = new OracleCommand())
            {
                cmdReadState.CommandText = strQueryAddState;
                cmdReadState.CommandType = CommandType.StoredProcedure;
                cmdReadState.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityState.StateStatus;
                cmdReadState.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityState.StateCancelId;

                cmdReadState.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityState.CommonSearchTerm;
                cmdReadState.Parameters.Add("M_SEARCH_COUNTRY", OracleDbType.Varchar2).Value = objEntityState.SearchCountry;
                cmdReadState.Parameters.Add("M_SEARCH_STATE", OracleDbType.Varchar2).Value = objEntityState.SearchState;
                cmdReadState.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityState.OrderColumn;
                cmdReadState.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityState.OrderMethod;
                cmdReadState.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityState.PageMaxSize;
                cmdReadState.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityState.PageNumber;

                cmdReadState.Parameters.Add("S_STATEMASTER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtStateTable = clsDataLayer.ExecuteReader(cmdReadState);
            }
            return dtStateTable;
        }

        public DataTable ReadStateMasterEdit(clsEntityStateMaster objEntStateMaster)
        {
            //Read State master table according to their Id(Primary Key)
            string strQueryReadLicPacEdit = "STATE_MASTER.SP_READ_STATE_MASTER_BYID";
            using (OracleCommand cmdReadStateEdit = new OracleCommand())
            {
                cmdReadStateEdit.CommandText = strQueryReadLicPacEdit;
                cmdReadStateEdit.CommandType = CommandType.StoredProcedure;
                cmdReadStateEdit.Parameters.Add("S_ID", OracleDbType.Int32).Value = objEntStateMaster.StateMasterId;
                cmdReadStateEdit.Parameters.Add("S_STATEMASTER", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtStateMasterEdit = new DataTable();
                dtStateMasterEdit = clsDataLayer.ExecuteReader(cmdReadStateEdit);
                return dtStateMasterEdit;
            }
        }
        public void UpdateStateDetails(clsEntityStateMaster objEntStateMaster)
        {
            //Method for updating state master table.
            using (OracleCommand cmdUpdateState = new OracleCommand())
            {
                cmdUpdateState.InitialLONGFetchSize = 1000;
                cmdUpdateState.CommandText = "STATE_MASTER.SP_UPDATE_STATE_MASTER";
                cmdUpdateState.CommandType = CommandType.StoredProcedure;
                cmdUpdateState.Parameters.Add("S_ID", OracleDbType.Int32).Value = objEntStateMaster.StateMasterId;
                cmdUpdateState.Parameters.Add("S_NAME", OracleDbType.Varchar2).Value = objEntStateMaster.StateName;
                cmdUpdateState.Parameters.Add("S_CNTRTYID", OracleDbType.Int32).Value = objEntStateMaster.StateCountryId;
                cmdUpdateState.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = objEntStateMaster.StateStatus;
                cmdUpdateState.Parameters.Add("S_INRTUSRID", OracleDbType.Int32).Value = objEntStateMaster.UserId;
                cmdUpdateState.Parameters.Add("S_UPDTDATE", OracleDbType.Date).Value = objEntStateMaster.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateState);
            }
        }
        public void UpdateStateStatus(clsEntityStateMaster objStateMaster)
        {
            //Updating state status field in state master table.
            using (OracleCommand cmdUpdateStateStatus = new OracleCommand())
            {
                cmdUpdateStateStatus.InitialLONGFetchSize = 1000;
                cmdUpdateStateStatus.CommandText = "STATE_MASTER.SP_UPDATE_STMSTRSTATUS";
                cmdUpdateStateStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateStateStatus.Parameters.Add("S_ID", OracleDbType.Int32).Value = objStateMaster.StateMasterId;
                cmdUpdateStateStatus.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = objStateMaster.StateStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdateStateStatus);
            }
        }
        public void UpdateStateCancel(clsEntityStateMaster objEntStateMaster)
        {
            //Method for updating state cancel details in state master table.
            using (OracleCommand cmdUpdateStateCancel = new OracleCommand())
            {
                cmdUpdateStateCancel.InitialLONGFetchSize = 1000;
                cmdUpdateStateCancel.CommandText = "STATE_MASTER.SP_UPDATE_STMSTRCANCEL";
                cmdUpdateStateCancel.CommandType = CommandType.StoredProcedure;
                cmdUpdateStateCancel.Parameters.Add("S_ID", OracleDbType.Int32).Value = objEntStateMaster.StateMasterId;
                cmdUpdateStateCancel.Parameters.Add("S_CANCELID", OracleDbType.Int32).Value = objEntStateMaster.UserId;
                cmdUpdateStateCancel.Parameters.Add("S_CANCELREASON", OracleDbType.Varchar2).Value = objEntStateMaster.StateCancelReason;
                cmdUpdateStateCancel.Parameters.Add("S_CANCELDATE", OracleDbType.Date).Value = objEntStateMaster.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateStateCancel);
            }
        }
        //Method for check state name already existed in table or not.
        public DataTable Check_State_Name(clsEntityStateMaster objEntStateMaster)
        {
            string strQueryCheckStateName = "STATE_MASTER.SP_CHECK_STATE_NAME";
            using (OracleCommand cmdCheckStateName = new OracleCommand())
            {
                cmdCheckStateName.CommandText = strQueryCheckStateName;
                cmdCheckStateName.CommandType = CommandType.StoredProcedure;
                cmdCheckStateName.Parameters.Add("S_NAME", OracleDbType.Varchar2).Value = objEntStateMaster.StateName;
                cmdCheckStateName.Parameters.Add("S_CNTRYID", OracleDbType.Int32).Value = objEntStateMaster.StateCountryId;
                cmdCheckStateName.Parameters.Add("S_STATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtStateName = new DataTable();
                dtStateName = clsDataLayer.ExecuteReader(cmdCheckStateName);
                return dtStateName;
            }
        }
        //Method for check state name already existed in table or not at the time of updation
        public string Check_State_NameUpdate(clsEntityStateMaster objEntStateMaster)
        {
            string strQueryCheckStateName = "STATE_MASTER.SP_CHECK_STATE_NAMEUPDATE";
            OracleCommand cmdCheckStateName = new OracleCommand();
                cmdCheckStateName.CommandText = strQueryCheckStateName;
                cmdCheckStateName.CommandType = CommandType.StoredProcedure;
                cmdCheckStateName.Parameters.Add("S_ID", OracleDbType.Int32).Value = objEntStateMaster.StateMasterId;
                cmdCheckStateName.Parameters.Add("S_NAME", OracleDbType.Varchar2).Value = objEntStateMaster.StateName;
                cmdCheckStateName.Parameters.Add("S_CNTRYID", OracleDbType.Int32).Value = objEntStateMaster.StateCountryId;
                cmdCheckStateName.Parameters.Add("S_STATECOUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteScalar(ref cmdCheckStateName);
                string strReturnCount = cmdCheckStateName.Parameters["S_STATECOUNT"].Value.ToString();
                cmdCheckStateName.Dispose();
                return strReturnCount; ;
        }
    }
}
