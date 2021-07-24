using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:06/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerPremise
    {
        //Method for read department for set dropdownlist
        public DataTable ReadCorporateDept(clsEntityPremise objEntityPremise)
        {
            string strQueryReadCorporateDept = "PREMISES.SP_READ_DEPT";
            using (OracleCommand cmdReadCorpDept = new OracleCommand())
            {
                cmdReadCorpDept.CommandText = strQueryReadCorporateDept;
                cmdReadCorpDept.CommandType = CommandType.StoredProcedure;
                cmdReadCorpDept.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPremise.Organisation_Id;
                cmdReadCorpDept.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPremise.CorpOffice_Id;
                cmdReadCorpDept.Parameters.Add("P_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadCorpDept);
                return dtCorpDept;
            }
        }

        //Method for check premise name already exist in the table or not.
        public string CheckPremiseName(clsEntityPremise objEntityPremise)
        {
            string strQueryCheckPremiseName = "PREMISES.SP_CHECK_PREMISE_NAME";
            OracleCommand cmdCheckPremiseName = new OracleCommand();
            cmdCheckPremiseName.CommandText = strQueryCheckPremiseName;
            cmdCheckPremiseName.CommandType = CommandType.StoredProcedure;
            cmdCheckPremiseName.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPremise.Organisation_Id;
            cmdCheckPremiseName.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPremise.CorpOffice_Id;
            cmdCheckPremiseName.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPremise.Premise_Name;
            cmdCheckPremiseName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckPremiseName);
            string strReturnCount = cmdCheckPremiseName.Parameters["P_COUNT"].Value.ToString();
            cmdCheckPremiseName.Dispose();
            return strReturnCount; ;
        }
        //Method for inserting data about Premises to the Premise master table
        public void Insert_Premise(clsEntityPremise objEntityPremise)
        {
            string strQueryInsertPremise = "PREMISES.SP_INERT_PREMISE";
            OracleCommand cmdInsertPremise = new OracleCommand();
            cmdInsertPremise.CommandText = strQueryInsertPremise;
            cmdInsertPremise.CommandType = CommandType.StoredProcedure;
            cmdInsertPremise.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPremise.Premise_Name;
            cmdInsertPremise.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPremise.Organisation_Id;
            cmdInsertPremise.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPremise.CorpOffice_Id;
            cmdInsertPremise.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityPremise.Department_Id;
            cmdInsertPremise.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPremise.Premise_Status;
            cmdInsertPremise.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityPremise.User_Id;
            cmdInsertPremise.Parameters.Add("P_INSDATE", OracleDbType.Date).Value = objEntityPremise.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdInsertPremise);
        }
        //Method for read Premise for list view.
        public DataTable ReadPremiseList(clsEntityPremise objEntityPremise)
        {
            string strQueryReadPremiseList = "PREMISES.SP_READ_PREMISELIST";
            using (OracleCommand cmdReadPremiseList = new OracleCommand())
            {
                cmdReadPremiseList.CommandText = strQueryReadPremiseList;
                cmdReadPremiseList.CommandType = CommandType.StoredProcedure;
                cmdReadPremiseList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPremise.Organisation_Id;
                cmdReadPremiseList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPremise.CorpOffice_Id;
                cmdReadPremiseList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityPremise.Premise_Status;
                cmdReadPremiseList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityPremise.Cancel_Status;
                cmdReadPremiseList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityPremise.CommonSearchTerm;
                cmdReadPremiseList.Parameters.Add("M_SEARCH_PREMISE", OracleDbType.Varchar2).Value = objEntityPremise.SearchPremise;
                cmdReadPremiseList.Parameters.Add("M_SEARCH_DEPARTMENT", OracleDbType.Varchar2).Value = objEntityPremise.SearchDepartment;
                cmdReadPremiseList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityPremise.OrderColumn;
                cmdReadPremiseList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityPremise.OrderMethod;
                cmdReadPremiseList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityPremise.PageMaxSize;
                cmdReadPremiseList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityPremise.PageNumber;
                cmdReadPremiseList.Parameters.Add("P_PREMISE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtPremise = new DataTable();
                dtPremise = clsDataLayer.SelectDataTable(cmdReadPremiseList);
                return dtPremise;
            }
        }
        //Method for updating the status of the premises
        public void Update_Premise_Status(clsEntityPremise objEntityPremise)
        {
            string strQueryUpdatePremiseStatus = "PREMISES.SP_UPDATE_STATUS";
            OracleCommand cmdUpdatePremiseStatus = new OracleCommand();
            cmdUpdatePremiseStatus.CommandText = strQueryUpdatePremiseStatus;
            cmdUpdatePremiseStatus.CommandType = CommandType.StoredProcedure;
            cmdUpdatePremiseStatus.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPremise.Premise_Master_Id;
            cmdUpdatePremiseStatus.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPremise.Premise_Status;
            cmdUpdatePremiseStatus.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPremise.User_Id;
            cmdUpdatePremiseStatus.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPremise.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdatePremiseStatus);
        }

        //Method for read premise by their id.
        public DataTable ReadPremiseListById(clsEntityPremise objEntityPremise)
        {
            string strQueryReadPremiseListById = "PREMISES.SP_READ_PREMISE_BYID";
            using (OracleCommand cmdReadPremiseListById = new OracleCommand())
            {
                cmdReadPremiseListById.CommandText = strQueryReadPremiseListById;
                cmdReadPremiseListById.CommandType = CommandType.StoredProcedure;
                cmdReadPremiseListById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPremise.Premise_Master_Id;
                cmdReadPremiseListById.Parameters.Add("P_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorpDept = new DataTable();
                dtCorpDept = clsDataLayer.SelectDataTable(cmdReadPremiseListById);
                return dtCorpDept;
            }
        }
        //Method for Updating data about premise to the premise master table
        public void Update_Premise(clsEntityPremise objEntityPremise)
        {
            string strQueryUpdatePremise = "PREMISES.SP_UPDATE_PREMISE";
            OracleCommand cmdUpdatePremise = new OracleCommand();
            cmdUpdatePremise.CommandText = strQueryUpdatePremise;
            cmdUpdatePremise.CommandType = CommandType.StoredProcedure;
            cmdUpdatePremise.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPremise.Premise_Master_Id;
            cmdUpdatePremise.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPremise.Premise_Name;
            cmdUpdatePremise.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPremise.Premise_Status;
            cmdUpdatePremise.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityPremise.Department_Id;
            cmdUpdatePremise.Parameters.Add("P_UPDUSERID", OracleDbType.Int32).Value = objEntityPremise.User_Id;
            cmdUpdatePremise.Parameters.Add("P_UPDDATE", OracleDbType.Date).Value = objEntityPremise.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdatePremise);
        }

        //Method for check Premise name already exist in the table or not at the time of updation
        public string CheckPremiseNameUpdate(clsEntityPremise objEntityPremise)
        {
            string strQueryCheckPremiseNameUpdate = "PREMISES.SP_CHECK_PREMISENAME_UPDATION";
            OracleCommand cmdCheckPremiseNameUpdate = new OracleCommand();
            cmdCheckPremiseNameUpdate.CommandText = strQueryCheckPremiseNameUpdate;
            cmdCheckPremiseNameUpdate.CommandType = CommandType.StoredProcedure;
            cmdCheckPremiseNameUpdate.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPremise.Organisation_Id;
            cmdCheckPremiseNameUpdate.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPremise.CorpOffice_Id;
            cmdCheckPremiseNameUpdate.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPremise.Premise_Master_Id;
            cmdCheckPremiseNameUpdate.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityPremise.Premise_Name;
            cmdCheckPremiseNameUpdate.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckPremiseNameUpdate);
            string strReturnCount = cmdCheckPremiseNameUpdate.Parameters["P_COUNT"].Value.ToString();
            cmdCheckPremiseNameUpdate.Dispose();
            return strReturnCount; ;
        }
        //Method for Cancel premise from premise master table so update cancel related fields
        public void Cancel_Premise(clsEntityPremise objEntityPremise)
        {
            string strQueryCancelPremise = "PREMISES.SP_CANCEL_PREMISE";
            OracleCommand cmdCancelPremise = new OracleCommand();
            cmdCancelPremise.CommandText = strQueryCancelPremise;
            cmdCancelPremise.CommandType = CommandType.StoredProcedure;
            cmdCancelPremise.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPremise.Premise_Master_Id;
            cmdCancelPremise.Parameters.Add("P_CANCEL_USERID", OracleDbType.Int32).Value = objEntityPremise.User_Id;
            cmdCancelPremise.Parameters.Add("P_CANCEL_DATE", OracleDbType.Date).Value = objEntityPremise.D_Date;
            cmdCancelPremise.Parameters.Add("P_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityPremise.Premise_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelPremise);
        }
    }

}
