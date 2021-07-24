using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
// CREATED BY:EVM-0007
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
 public class clsDataLayerTimeslot
    {

        

        //Method for check Timeslot_Name already exist in the table or not.
        public string CheckTimeslotName(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryCheckTimeslotName = "TIMESLOT_MASTER .SP_CHECK_TIMESLOTNAME";
            OracleCommand cmdCheckTimeslotName = new OracleCommand();
            cmdCheckTimeslotName.CommandText = strQueryCheckTimeslotName;
            cmdCheckTimeslotName.CommandType = CommandType.StoredProcedure;
            cmdCheckTimeslotName.Parameters.Add("TS_ID", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Master_Id;
            cmdCheckTimeslotName.Parameters.Add("TS_ORGID", OracleDbType.Int32).Value = objEntityTimeslot.Organisation_Id;
            cmdCheckTimeslotName.Parameters.Add("TS_CORPID", OracleDbType.Int32).Value = objEntityTimeslot.CorpOffice_Id;
            cmdCheckTimeslotName.Parameters.Add("TS_NAME", OracleDbType.Varchar2).Value = objEntityTimeslot.Timeslot_Name;
            //cmdCheckTimeslotName.Parameters.Add("C_CTGRYID", OracleDbType.Int32).Value = objEntityTimeslot.CtgryId;
            cmdCheckTimeslotName.Parameters.Add("TS_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref  cmdCheckTimeslotName);
            string strReturnCount = cmdCheckTimeslotName.Parameters["TS_COUNT"].Value.ToString();
            cmdCheckTimeslotName.Dispose();
            return strReturnCount; ;
        }
        //Method for inserting data about Timeslot to the Timeslot master table
        public void Insert_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryInsertTimeslot = "TIMESLOT_MASTER.SP_INSERT_TIMESLOT";
            OracleCommand cmdInsertTimeslot = new OracleCommand();
            cmdInsertTimeslot.CommandText = strQueryInsertTimeslot;
            cmdInsertTimeslot.CommandType = CommandType.StoredProcedure;
            cmdInsertTimeslot.Parameters.Add("TS_NAME", OracleDbType.Varchar2).Value = objEntityTimeslot.Timeslot_Name;
            cmdInsertTimeslot.Parameters.Add("TS_STARTTIME", OracleDbType.TimeStamp).Value =objEntityTimeslot.Start_Time;
            cmdInsertTimeslot.Parameters.Add("TS_ENDTIME", OracleDbType.TimeStamp).Value = objEntityTimeslot.End_Time;
            cmdInsertTimeslot.Parameters.Add("TS_STATUS", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Status;
            cmdInsertTimeslot.Parameters.Add("TS_ORGID", OracleDbType.Int32).Value = objEntityTimeslot.Organisation_Id;
            cmdInsertTimeslot.Parameters.Add("TS_CORPID", OracleDbType.Int32).Value = objEntityTimeslot.CorpOffice_Id;
            cmdInsertTimeslot.Parameters.Add("TS_INSUSERID", OracleDbType.Int32).Value = objEntityTimeslot.User_Id;
            cmdInsertTimeslot.Parameters.Add("TS_INSDATE", OracleDbType.Date).Value = objEntityTimeslot.D_Date;
           
            clsDataLayer.ExecuteNonQuery(cmdInsertTimeslot);
        }
        //Method for read Timeslot for list view.
        public DataTable ReadTimeslotList(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryReadTimeslotList = "TIMESLOT_MASTER.SP_READ_TIMESLOTLIST";
            using (OracleCommand cmdReadTimeslotList = new OracleCommand())
            {
                cmdReadTimeslotList.CommandText = strQueryReadTimeslotList;
                cmdReadTimeslotList.CommandType = CommandType.StoredProcedure;
                cmdReadTimeslotList.Parameters.Add("TS_ORGID", OracleDbType.Int32).Value = objEntityTimeslot.Organisation_Id;
                cmdReadTimeslotList.Parameters.Add("TS_CORPID", OracleDbType.Int32).Value = objEntityTimeslot.CorpOffice_Id;
                cmdReadTimeslotList.Parameters.Add("TS_OPTION", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Status;
                cmdReadTimeslotList.Parameters.Add("TS_CANCEL", OracleDbType.Int32).Value = objEntityTimeslot.Cancel_Status;
                cmdReadTimeslotList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityTimeslot.CommonSearchTerm;
                cmdReadTimeslotList.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityTimeslot.SearchName;
                cmdReadTimeslotList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityTimeslot.OrderColumn;
                cmdReadTimeslotList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityTimeslot.OrderMethod;
                cmdReadTimeslotList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityTimeslot.PageMaxSize;
                cmdReadTimeslotList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityTimeslot.PageNumber;
                cmdReadTimeslotList.Parameters.Add("TS_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadTimeslotList);
                return dtResultSet;
            }
        }

        public void Update_Timeslot_Status(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryUpdateTimeslot = "TIMESLOT_MASTER.SP_UPDATE_TIMESLOT_STS";
            OracleCommand cmdUpdateTimeslot = new OracleCommand();
            cmdUpdateTimeslot.CommandText = strQueryUpdateTimeslot;
            cmdUpdateTimeslot.CommandType = CommandType.StoredProcedure;
            cmdUpdateTimeslot.Parameters.Add("TS_ID", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Master_Id;
            cmdUpdateTimeslot.Parameters.Add("TS_STATUS", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Status;
            cmdUpdateTimeslot.Parameters.Add("TS_UPDUSERID", OracleDbType.Int32).Value = objEntityTimeslot.User_Id;
            cmdUpdateTimeslot.Parameters.Add("TS_UPDDATE", OracleDbType.Date).Value = objEntityTimeslot.D_Date;

            clsDataLayer.ExecuteNonQuery(cmdUpdateTimeslot);
        }
        //Method for read Timeslot by their id.
        public DataTable ReadTimeslotById(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryReadTimeslotListById = "TIMESLOT_MASTER.SP_READ_TIMESLOT_BYID";
            using (OracleCommand cmdReadTimeslotListById = new OracleCommand())
            {
                cmdReadTimeslotListById.CommandText = strQueryReadTimeslotListById;
                cmdReadTimeslotListById.CommandType = CommandType.StoredProcedure;
                cmdReadTimeslotListById.Parameters.Add("TS_ID", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Master_Id;
                cmdReadTimeslotListById.Parameters.Add("TS_CORPID", OracleDbType.Int32).Value = objEntityTimeslot.CorpOffice_Id;
                cmdReadTimeslotListById.Parameters.Add("TS_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadTimeslotListById);
                return dtResultSet;
            }
        }
        //Method for Updating data about Timeslot to the Timeslot master table
        public void Update_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryUpdateTimeslot = "TIMESLOT_MASTER.SP_UPDATE_TIMESLOT";
            OracleCommand cmdUpdateTimeslot = new OracleCommand();
            cmdUpdateTimeslot.CommandText = strQueryUpdateTimeslot;
            cmdUpdateTimeslot.CommandType = CommandType.StoredProcedure;
            cmdUpdateTimeslot.Parameters.Add("TS_ID", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Master_Id;
            cmdUpdateTimeslot.Parameters.Add("TS_NAME", OracleDbType.Varchar2).Value = objEntityTimeslot.Timeslot_Name;
            cmdUpdateTimeslot.Parameters.Add("TS_STARTTIME", OracleDbType.TimeStamp).Value = objEntityTimeslot.Start_Time;
            cmdUpdateTimeslot.Parameters.Add("TS_ENDTIME", OracleDbType.TimeStamp).Value = objEntityTimeslot.End_Time;
            cmdUpdateTimeslot.Parameters.Add("TS_STATUS", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Status;
            cmdUpdateTimeslot.Parameters.Add("TS_UPDUSERID", OracleDbType.Int32).Value = objEntityTimeslot.User_Id;
            cmdUpdateTimeslot.Parameters.Add("TS_UPDDATE", OracleDbType.Date).Value = objEntityTimeslot.D_Date;
           
            clsDataLayer.ExecuteNonQuery(cmdUpdateTimeslot);
        }


        //Method for Cancel Timeslot from Timeslot master table so update cancel related fields
        public void Cancel_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryCancelTimeslot = "TIMESLOT_MASTER.SP_CANCEL_TIMESLOT";
            OracleCommand cmdCancelTimeslot = new OracleCommand();
            cmdCancelTimeslot.CommandText = strQueryCancelTimeslot;
            cmdCancelTimeslot.CommandType = CommandType.StoredProcedure;
            cmdCancelTimeslot.Parameters.Add("TS_ID", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Master_Id;
            cmdCancelTimeslot.Parameters.Add("TS_CANCEL_USERID", OracleDbType.Int32).Value = objEntityTimeslot.User_Id;
            cmdCancelTimeslot.Parameters.Add("TS_CANCEL_DATE", OracleDbType.Date).Value = objEntityTimeslot.D_Date;
            cmdCancelTimeslot.Parameters.Add("TS_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityTimeslot.Timeslot_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelTimeslot);
        }

        //Method for Recall Cancelled Timeslot from Timeslot master table so update cancel related fields
        public void Recall_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            string strQueryRecallTimeslot = "TIMESLOT_MASTER.SP_RECALL_TIMESLOT";
            OracleCommand cmdRecallTimeslot = new OracleCommand();
            cmdRecallTimeslot.CommandText = strQueryRecallTimeslot;
            cmdRecallTimeslot.CommandType = CommandType.StoredProcedure;
            cmdRecallTimeslot.Parameters.Add("TS_ID", OracleDbType.Int32).Value = objEntityTimeslot.Timeslot_Master_Id;
            cmdRecallTimeslot.Parameters.Add("TS_USERID", OracleDbType.Int32).Value = objEntityTimeslot.User_Id;
            cmdRecallTimeslot.Parameters.Add("TS_DATE", OracleDbType.Date).Value = objEntityTimeslot.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallTimeslot);
        }
    }
}
