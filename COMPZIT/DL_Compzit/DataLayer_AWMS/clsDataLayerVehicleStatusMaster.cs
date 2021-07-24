using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0008
// CREATED DATE:02/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerVehicleStatusMaster
    {

        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        // This Method adds accommodation details to the table
        public void AddVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_INS_VEH_STATUS_DETAILS";
            using (OracleCommand cmdVehsts = new OracleCommand())
            {
                cmdVehsts.CommandText = strQueryReadVehStsMstr;
                cmdVehsts.CommandType = CommandType.StoredProcedure;
                cmdVehsts.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityvehsts.ClassName;
                cmdVehsts.Parameters.Add("V_TYPEID", OracleDbType.Int32).Value = objEntityvehsts.StatusTypeId;
                cmdVehsts.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityvehsts.Organisation_id;
                cmdVehsts.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityvehsts.Corporate_id;
                cmdVehsts.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = objEntityvehsts.Status_id;
                cmdVehsts.Parameters.Add("V_INSUSERID", OracleDbType.Int32).Value = objEntityvehsts.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdVehsts);
            }
        }

        // This Method will fetch ACCOMODATION list
        public DataTable ReadVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_READ_VEH_STS";
            OracleCommand cmdVehsts = new OracleCommand();
            cmdVehsts.CommandText = strQueryReadVehStsMstr;
            cmdVehsts.CommandType = CommandType.StoredProcedure;
            cmdVehsts.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVehstsMstr = new DataTable();
            dtVehstsMstr = clsDataLayer.ExecuteReader(cmdVehsts);
            return dtVehstsMstr;
        }

        // This Method will fetch ACCOMODATION list
        public DataTable ReadVStatusMstrList(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_READ_VEH_STATUS_LIST";
            OracleCommand cmdVehsts = new OracleCommand();
            cmdVehsts.CommandText = strQueryReadVehStsMstr;
            cmdVehsts.CommandType = CommandType.StoredProcedure;
            cmdVehsts.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityvehsts.Organisation_id;
            cmdVehsts.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityvehsts.Corporate_id;
            cmdVehsts.Parameters.Add("V_OPTION", OracleDbType.Int32).Value = objEntityvehsts.Status_id;
            cmdVehsts.Parameters.Add("V_CANCEL", OracleDbType.Int32).Value = objEntityvehsts.CancelStatus;
            cmdVehsts.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdVehsts);
            return dtCategoryList;
        }

        // This Method checks Accommodation name in the database for duplication.
        public string CheckVehStsName(clsEntityVehicleStatusMaster objEntityvehsts)
        {

            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_CHECK_VEH_STS";
            OracleCommand cmdVehsts = new OracleCommand();
            cmdVehsts.CommandText = strQueryReadVehStsMstr;
            cmdVehsts.CommandType = CommandType.StoredProcedure;
            cmdVehsts.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityvehsts.VehId;
            cmdVehsts.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityvehsts.ClassName;
            cmdVehsts.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityvehsts.Corporate_id;
            cmdVehsts.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityvehsts.Organisation_id;
            cmdVehsts.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdVehsts);
            string strReturn = cmdVehsts.Parameters["V_COUNT"].Value.ToString();
            cmdVehsts.Dispose();
            return strReturn;
        }

        // This Method update accommoadation details to the table
        public void UpdateVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_UPD_VEH_STATUS_DETAILS";
            using (OracleCommand cmdVehsts = new OracleCommand())
            {
                cmdVehsts.CommandText = strQueryReadVehStsMstr;
                cmdVehsts.CommandType = CommandType.StoredProcedure;

                cmdVehsts.Parameters.Add("V_ID", OracleDbType.Varchar2).Value = objEntityvehsts.VehId;
                cmdVehsts.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityvehsts.ClassName;
                cmdVehsts.Parameters.Add("V_STSID", OracleDbType.Int32).Value = objEntityvehsts.StatusTypeId;
                cmdVehsts.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityvehsts.Organisation_id;
                cmdVehsts.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityvehsts.Corporate_id;
                cmdVehsts.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = objEntityvehsts.Status_id;
                cmdVehsts.Parameters.Add("V_UPDUSERID", OracleDbType.Int32).Value = objEntityvehsts.User_Id;
                cmdVehsts.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdVehsts);
            }
        }

        //Method for cancel Accommodation
        public void CancelVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_CANCEL_VEH_STATUS";
            using (OracleCommand cmdVehsts = new OracleCommand())
            {
                cmdVehsts.CommandText = strQueryReadVehStsMstr;
                cmdVehsts.CommandType = CommandType.StoredProcedure;
                cmdVehsts.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityvehsts.VehId;
                cmdVehsts.Parameters.Add("V_USERID", OracleDbType.Int32).Value = objEntityvehsts.User_Id;
                cmdVehsts.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdVehsts.Parameters.Add("V_REASON", OracleDbType.Varchar2).Value = objEntityvehsts.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdVehsts);
            }
        }

        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadVStatusById(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_READ_VEH_STATUS_BY_ID";
            OracleCommand cmdVehsts = new OracleCommand();
            cmdVehsts.CommandText = strQueryReadVehStsMstr;
            cmdVehsts.CommandType = CommandType.StoredProcedure;
            cmdVehsts.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityvehsts.VehId;
            cmdVehsts.Parameters.Add("V_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdVehsts);
            return dtCategory;
        }

        //Method for recall fuel type

        public void ReCallVStatus(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            string strQueryReadVehStsMstr = "VEH_STATUS_MASTER.SP_RECALL_VEH_STATUS";
            using (OracleCommand cmdVehsts = new OracleCommand())
            {
                cmdVehsts.CommandText = strQueryReadVehStsMstr;
                cmdVehsts.CommandType = CommandType.StoredProcedure;
                cmdVehsts.Parameters.Add("W_ID", OracleDbType.Int32).Value = objEntityvehsts.VehId;
                cmdVehsts.Parameters.Add("W_USERID", OracleDbType.Int32).Value = objEntityvehsts.User_Id;
                cmdVehsts.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdVehsts);
            }
        }
        
    }

 }
