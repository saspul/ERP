using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
using CL_Compzit;
using HashingUtility;
// CREATED BY:EVM-0002
// CREATED DATE:08/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerWorkStation
    {
        //Method for read work area for set dropdownlist
        public DataTable ReadWorkArea(clsEntityWorkStation objEntityStation)
        {
            string strQueryReadArea = "WORK_STATION.SP_READ_AREA";
            using (OracleCommand cmdReadArea = new OracleCommand())
            {
                cmdReadArea.CommandText = strQueryReadArea;
                cmdReadArea.CommandType = CommandType.StoredProcedure;
                cmdReadArea.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityStation.Organisation_Id;
                cmdReadArea.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityStation.CorpOffice_Id;
                cmdReadArea.Parameters.Add("W_AREA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtArea = new DataTable();
                dtArea = clsDataLayer.SelectDataTable(cmdReadArea);
                return dtArea;
            }
        }

        //Method for check work station name already exist in the table or not.
        public string CheckWorkStationName(clsEntityWorkStation objEntityStation)
        {
            string strQueryCheckStationName = "WORK_STATION.SP_CHECK_STATION_NAME";
            OracleCommand cmdCheckStationName = new OracleCommand();
            cmdCheckStationName.CommandText = strQueryCheckStationName;
            cmdCheckStationName.CommandType = CommandType.StoredProcedure;
            cmdCheckStationName.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityStation.Organisation_Id;
            cmdCheckStationName.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityStation.CorpOffice_Id;
            cmdCheckStationName.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityStation.WorkStation_Name;
            cmdCheckStationName.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckStationName);
            string strReturnCount = cmdCheckStationName.Parameters["W_COUNT"].Value.ToString();
            cmdCheckStationName.Dispose();
            return strReturnCount; ;
        }
        //Method for inserting data about work station to the work station master table
        public void Insert_Station(clsEntityWorkStation objEntityStation)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertStation = "WORK_STATION.SP_INSERT_STATION";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    using (OracleCommand cmdInsertStation = new OracleCommand(strQueryInsertStation, con))
                    {
                        cmdInsertStation.Transaction = tran;

                        cmdInsertStation.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.WORK_STATION);
                        objEntityCommon.CorporateID = objEntityStation.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntityCommon, tran, con);
                        clsHash objHashing = new clsHash();
                        string strEncrypted = objHashing.GetHash(strNextNum, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));

                        objEntityStation.WorkStation_Master_Id = Convert.ToInt32(strNextNum);
                        cmdInsertStation.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityStation.WorkStation_Master_Id;
                        cmdInsertStation.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityStation.WorkStation_Name;
                        cmdInsertStation.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityStation.Organisation_Id;
                        cmdInsertStation.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityStation.CorpOffice_Id;
                        cmdInsertStation.Parameters.Add("W_AREAID", OracleDbType.Int32).Value = objEntityStation.WorkArea_Id;
                        cmdInsertStation.Parameters.Add("W_MULINST", OracleDbType.Int32).Value = objEntityStation.Multiple_Instance;
                        cmdInsertStation.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityStation.WorkStation_Status;
                        cmdInsertStation.Parameters.Add("W_INSUSERID", OracleDbType.Int32).Value = objEntityStation.User_Id;
                        cmdInsertStation.Parameters.Add("W_INSDATE", OracleDbType.Date).Value = objEntityStation.D_Date;
                        cmdInsertStation.Parameters.Add("W_ENCRYPTED", OracleDbType.Varchar2).Value = strEncrypted;
                        cmdInsertStation.ExecuteNonQuery();
                    }
                    tran.Commit();
                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }
        }






     

        //Method for read work station for list view.
        public DataTable ReadWorkStationList(clsEntityWorkStation objEntityStation)
        {
            string strQueryReadStationList = "WORK_STATION.SP_READ_STATIONLIST";
            using (OracleCommand cmdReadStationList = new OracleCommand())
            {
                cmdReadStationList.CommandText = strQueryReadStationList;
                cmdReadStationList.CommandType = CommandType.StoredProcedure;
                cmdReadStationList.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityStation.Organisation_Id;
                cmdReadStationList.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityStation.CorpOffice_Id;
                cmdReadStationList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityStation.WorkStation_Status;
                cmdReadStationList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityStation.Cancel_Status;
                cmdReadStationList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityStation.CommonSearchTerm;
                cmdReadStationList.Parameters.Add("M_SEARCH_WORKSTATION", OracleDbType.Varchar2).Value = objEntityStation.SearchWorkstation;
                cmdReadStationList.Parameters.Add("M_SEARCH_PREMISE", OracleDbType.Varchar2).Value = objEntityStation.SearchPremise;
                cmdReadStationList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityStation.OrderColumn;
                cmdReadStationList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityStation.OrderMethod;
                cmdReadStationList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityStation.PageMaxSize;
                cmdReadStationList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityStation.PageNumber;
                cmdReadStationList.Parameters.Add("W_STATION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtStation = new DataTable();
                dtStation = clsDataLayer.SelectDataTable(cmdReadStationList);
                return dtStation;
            }
        }
        //Method for updating the status of the work station
        public void Update_WorkStation_Status(clsEntityWorkStation objEntityStation)
        {
            string strQueryUpdateStationStatus = "WORK_STATION.SP_UPDATE_STATUS";
            OracleCommand cmdUpdateStationStatus = new OracleCommand();
            cmdUpdateStationStatus.CommandText = strQueryUpdateStationStatus;
            cmdUpdateStationStatus.CommandType = CommandType.StoredProcedure;
            cmdUpdateStationStatus.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityStation.WorkStation_Master_Id;
            cmdUpdateStationStatus.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityStation.WorkStation_Status;
            cmdUpdateStationStatus.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityStation.User_Id;
            cmdUpdateStationStatus.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntityStation.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateStationStatus);
        }

        //Method for read work station by their id.
        public DataTable ReadWorkStationListById(clsEntityWorkStation objEntityStation)
        {
            string strQueryReadStationListById = "WORK_STATION.SP_READ_STATION_BYID";
            using (OracleCommand cmdReadStationListById = new OracleCommand())
            {
                cmdReadStationListById.CommandText = strQueryReadStationListById;
                cmdReadStationListById.CommandType = CommandType.StoredProcedure;
                cmdReadStationListById.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityStation.WorkStation_Master_Id;
                cmdReadStationListById.Parameters.Add("W_STATION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtStation = new DataTable();
                dtStation = clsDataLayer.SelectDataTable(cmdReadStationListById);
                return dtStation;
            }
        }
        //Method for Updating data about work station to the work station master table
        public void Update_WorkStation(clsEntityWorkStation objEntityStation)
        {
            string strQueryUpdateStation = "WORK_STATION.SP_UPDATE_STATION";
            OracleCommand cmdUpdateStation = new OracleCommand();
            cmdUpdateStation.CommandText = strQueryUpdateStation;
            cmdUpdateStation.CommandType = CommandType.StoredProcedure;
            cmdUpdateStation.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityStation.WorkStation_Master_Id;
            cmdUpdateStation.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityStation.WorkStation_Name;
            cmdUpdateStation.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityStation.WorkStation_Status;
            cmdUpdateStation.Parameters.Add("W_AREAID", OracleDbType.Int32).Value = objEntityStation.WorkArea_Id;
            cmdUpdateStation.Parameters.Add("W_MULINST", OracleDbType.Int32).Value = objEntityStation.Multiple_Instance;
            cmdUpdateStation.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityStation.User_Id;
            cmdUpdateStation.Parameters.Add("W_UPDDATE", OracleDbType.Date).Value = objEntityStation.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateStation);
        }

        //Method for check work station name already exist in the table or not at the time of updation
        public string CheckWorkStationNameUpdate(clsEntityWorkStation objEntityStation)
        {
            string strQueryCheckStationNameUpdate = "WORK_STATION.SP_CHECK_STATIONNAME_UPDATION";
            OracleCommand cmdCheckStationNameUpdate = new OracleCommand();
            cmdCheckStationNameUpdate.CommandText = strQueryCheckStationNameUpdate;
            cmdCheckStationNameUpdate.CommandType = CommandType.StoredProcedure;
            cmdCheckStationNameUpdate.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityStation.Organisation_Id;
            cmdCheckStationNameUpdate.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityStation.CorpOffice_Id;
            cmdCheckStationNameUpdate.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityStation.WorkStation_Master_Id;
            cmdCheckStationNameUpdate.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityStation.WorkStation_Name;
            cmdCheckStationNameUpdate.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckStationNameUpdate);
            string strReturnCount = cmdCheckStationNameUpdate.Parameters["W_COUNT"].Value.ToString();
            cmdCheckStationNameUpdate.Dispose();
            return strReturnCount;
        }
        //Method for Cancel work station from worsstation master table so update cancel related fields
        public void Cancel_WorkStation(clsEntityWorkStation objEntityStation)
        {
            string strQueryCancelStation = "WORK_STATION.SP_CANCEL_STATION";
            OracleCommand cmdCancelStation = new OracleCommand();
            cmdCancelStation.CommandText = strQueryCancelStation;
            cmdCancelStation.CommandType = CommandType.StoredProcedure;
            cmdCancelStation.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityStation.WorkStation_Master_Id;
            cmdCancelStation.Parameters.Add("W_CANCEL_USERID", OracleDbType.Int32).Value = objEntityStation.User_Id;
            cmdCancelStation.Parameters.Add("W_CANCEL_DATE", OracleDbType.Date).Value = objEntityStation.D_Date;
            cmdCancelStation.Parameters.Add("W_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityStation.WorkStation_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelStation);
        }
    }

}

