using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:08/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerWorkArea
    {
        //Method for read premise for set dropdownlist
        public DataTable ReadPremise(clsEntityWorkArea objEntityArea)
        {
            string strQueryReadPremise = "WORK_AREA.SP_READ_PREMISE";
            using (OracleCommand cmdReadPremise  = new OracleCommand())
            {
                cmdReadPremise.CommandText = strQueryReadPremise;
                cmdReadPremise.CommandType = CommandType.StoredProcedure;
                cmdReadPremise.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityArea.Organisation_Id;
                cmdReadPremise.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityArea.CorpOffice_Id;
                cmdReadPremise.Parameters.Add("W_PREMISE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtPremise = new DataTable();
                dtPremise = clsDataLayer.SelectDataTable(cmdReadPremise);
                return dtPremise;
            }
        }

        //Method for check work area name already exist in the table or not.
        public string CheckWorkAreaName(clsEntityWorkArea objEntityArea)
        {
            string strQueryCheckAreaName = "WORK_AREA.SP_CHECK_AREA_NAME";
            OracleCommand cmdCheckAreaName = new OracleCommand();
            cmdCheckAreaName.CommandText = strQueryCheckAreaName;
            cmdCheckAreaName.CommandType = CommandType.StoredProcedure;
            cmdCheckAreaName.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityArea.Organisation_Id;
            cmdCheckAreaName.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityArea.CorpOffice_Id;
            cmdCheckAreaName.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityArea.WorkArea_Name;
            cmdCheckAreaName.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckAreaName);
            string strReturnCount = cmdCheckAreaName.Parameters["W_COUNT"].Value.ToString();
            cmdCheckAreaName.Dispose();
            return strReturnCount; ;
        }
        //Method for inserting data about work area to the work area master table
        public void Insert_Area(clsEntityWorkArea objEntityArea)
        {
            string strQueryInsertArea = "WORK_AREA.SP_INSERT_AREA";
            OracleCommand cmdInsertArea = new OracleCommand();
            cmdInsertArea.CommandText = strQueryInsertArea;
            cmdInsertArea.CommandType = CommandType.StoredProcedure;
            cmdInsertArea.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityArea.WorkArea_Name;
            cmdInsertArea.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityArea.Organisation_Id;
            cmdInsertArea.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityArea.CorpOffice_Id;
            cmdInsertArea.Parameters.Add("W_PREMISEID", OracleDbType.Int32).Value = objEntityArea.PremiseId;
            cmdInsertArea.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityArea.WorkArea_Status;
            cmdInsertArea.Parameters.Add("W_INSUSERID", OracleDbType.Int32).Value = objEntityArea.User_Id;
            cmdInsertArea.Parameters.Add("W_INSDATE", OracleDbType.Date).Value = objEntityArea.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdInsertArea);
        }
        //Method for read work area for list view.
        public DataTable ReadWorkAreaList(clsEntityWorkArea objEntityArea)
        {
            string strQueryReadAreaList = "WORK_AREA.SP_READ_AREALIST";
            using (OracleCommand cmdReadAreaList = new OracleCommand())
            {
                cmdReadAreaList.CommandText = strQueryReadAreaList;
                cmdReadAreaList.CommandType = CommandType.StoredProcedure;
                cmdReadAreaList.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityArea.Organisation_Id;
                cmdReadAreaList.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityArea.CorpOffice_Id;
                cmdReadAreaList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityArea.WorkArea_Status;
                cmdReadAreaList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityArea.Cancel_Status;
                cmdReadAreaList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityArea.CommonSearchTerm;
                cmdReadAreaList.Parameters.Add("M_SEARCH_AREA", OracleDbType.Varchar2).Value = objEntityArea.SearchArea;
                cmdReadAreaList.Parameters.Add("M_SEARCH_PREMISE", OracleDbType.Varchar2).Value = objEntityArea.SearchPremise;
                cmdReadAreaList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityArea.OrderColumn;
                cmdReadAreaList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityArea.OrderMethod;
                cmdReadAreaList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityArea.PageMaxSize;
                cmdReadAreaList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityArea.PageNumber;
                cmdReadAreaList.Parameters.Add("W_AREA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtArea = new DataTable();
                dtArea = clsDataLayer.SelectDataTable(cmdReadAreaList);
                return dtArea;
            }
        }
        //Method for updating the status of the work area
        public void Update_WorkArea_Status(clsEntityWorkArea objEntityArea)
        {
            string strQueryUpdateAreaStatus = "WORK_AREA.SP_UPDATE_STATUS";
            OracleCommand cmdUpdateAreaStatus = new OracleCommand();
            cmdUpdateAreaStatus.CommandText = strQueryUpdateAreaStatus;
            cmdUpdateAreaStatus.CommandType = CommandType.StoredProcedure;
            cmdUpdateAreaStatus.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityArea.WorkArea_Master_Id;
            cmdUpdateAreaStatus.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityArea.WorkArea_Status;
            cmdUpdateAreaStatus.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityArea.User_Id;
            cmdUpdateAreaStatus.Parameters.Add("W_DATE", OracleDbType.Date).Value = objEntityArea.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateAreaStatus);
        }

        //Method for read work area by their id.
        public DataTable ReadWorkAreaListById(clsEntityWorkArea objEntityArea)
        {
            string strQueryReadAreaListById = "WORK_AREA.SP_READ_AREA_BYID";
            using (OracleCommand cmdReadAreaListById = new OracleCommand())
            {
                cmdReadAreaListById.CommandText = strQueryReadAreaListById;
                cmdReadAreaListById.CommandType = CommandType.StoredProcedure;
                cmdReadAreaListById.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityArea.WorkArea_Master_Id;
                cmdReadAreaListById.Parameters.Add("W_AREA", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtArea = new DataTable();
                dtArea = clsDataLayer.SelectDataTable(cmdReadAreaListById);
                return dtArea;
            }
        }
        //Method for Updating data about work area to the work area master table
        public void Update_WorkArea(clsEntityWorkArea objEntityArea)
        {
            string strQueryUpdateArea = "WORK_AREA.SP_UPDATE_AREA";
            OracleCommand cmdUpdateArea = new OracleCommand();
            cmdUpdateArea.CommandText = strQueryUpdateArea;
            cmdUpdateArea.CommandType = CommandType.StoredProcedure;
            cmdUpdateArea.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityArea.WorkArea_Master_Id;
            cmdUpdateArea.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityArea.WorkArea_Name;
            cmdUpdateArea.Parameters.Add("W_STATUS", OracleDbType.Int32).Value = objEntityArea.WorkArea_Status;
            cmdUpdateArea.Parameters.Add("W_PREMISEID", OracleDbType.Int32).Value = objEntityArea.PremiseId;
            cmdUpdateArea.Parameters.Add("W_UPDUSERID", OracleDbType.Int32).Value = objEntityArea.User_Id;
            cmdUpdateArea.Parameters.Add("W_UPDDATE", OracleDbType.Date).Value = objEntityArea.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateArea);
        }

        //Method for check work area name already exist in the table or not at the time of updation
        public string CheckWorkAreaNameUpdate(clsEntityWorkArea objEntityArea)
        {
            string strQueryCheckAreaNameUpdate = "WORK_AREA.SP_CHECK_AREANAME_UPDATION";
            OracleCommand cmdCheckAreaNameUpdate = new OracleCommand();
            cmdCheckAreaNameUpdate.CommandText = strQueryCheckAreaNameUpdate;
            cmdCheckAreaNameUpdate.CommandType = CommandType.StoredProcedure;
            cmdCheckAreaNameUpdate.Parameters.Add("W_ORGID", OracleDbType.Int32).Value = objEntityArea.Organisation_Id;
            cmdCheckAreaNameUpdate.Parameters.Add("W_CORPID", OracleDbType.Int32).Value = objEntityArea.CorpOffice_Id;
            cmdCheckAreaNameUpdate.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityArea.WorkArea_Master_Id;
            cmdCheckAreaNameUpdate.Parameters.Add("W_NAME", OracleDbType.Varchar2).Value = objEntityArea.WorkArea_Name;
            cmdCheckAreaNameUpdate.Parameters.Add("W_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckAreaNameUpdate);
            string strReturnCount = cmdCheckAreaNameUpdate.Parameters["W_COUNT"].Value.ToString();
            cmdCheckAreaNameUpdate.Dispose();
            return strReturnCount; 
        }
        //Method for Cancel work area from work area master table so update cancel related fields
        public void Cancel_WorkArea(clsEntityWorkArea objEntityArea)
        {
            string strQueryCancelArea = "WORK_AREA.SP_CANCEL_AREA";
            OracleCommand cmdCancelArea = new OracleCommand();
            cmdCancelArea.CommandText = strQueryCancelArea;
            cmdCancelArea.CommandType = CommandType.StoredProcedure;
            cmdCancelArea.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityArea.WorkArea_Master_Id;
            cmdCancelArea.Parameters.Add("W_CANCEL_USERID", OracleDbType.Int32).Value = objEntityArea.User_Id;
            cmdCancelArea.Parameters.Add("W_CANCEL_DATE", OracleDbType.Date).Value = objEntityArea.D_Date;
            cmdCancelArea.Parameters.Add("W_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityArea.WorkArea_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelArea);
        }
    }

}

