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

namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerVehicleClass
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds vehical class details to the table
        public void AddVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryAddVehicleClass = "VEHICLE_CLASS.SP_INS_VEHICLE_CLASS_DETAILS";
            using (OracleCommand cmdAddVehicleClass = new OracleCommand())
            {
                cmdAddVehicleClass.CommandText = strQueryAddVehicleClass;
                cmdAddVehicleClass.CommandType = CommandType.StoredProcedure;
                cmdAddVehicleClass.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityVehicle.ClassName;
                cmdAddVehicleClass.Parameters.Add("V_IMAGE", OracleDbType.Int32).Value = objEntityVehicle.ImageId;
                cmdAddVehicleClass.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityVehicle.Organisation_id;
                cmdAddVehicleClass.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityVehicle.Corporate_id;
                cmdAddVehicleClass.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = objEntityVehicle.Status_id;
                cmdAddVehicleClass.Parameters.Add("V_INSUSERID", OracleDbType.Int32).Value = objEntityVehicle.User_Id;
                cmdAddVehicleClass.Parameters.Add("V_CTGRYTYP_ID", OracleDbType.Int32).Value = objEntityVehicle.CategoryTypeId;
                clsDataLayer.ExecuteNonQuery(cmdAddVehicleClass);
            }
        }
        // This Method update vehical class details to the table
        public void UpdateVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryUpdateVehicleClass = "VEHICLE_CLASS.SP_UPD_VEHICLE_CLASS_DETAILS";
            using (OracleCommand cmdUpdateVehicleClass = new OracleCommand())
            {
                cmdUpdateVehicleClass.CommandText = strQueryUpdateVehicleClass;
                cmdUpdateVehicleClass.CommandType = CommandType.StoredProcedure;

                cmdUpdateVehicleClass.Parameters.Add("V_ID", OracleDbType.Varchar2).Value = objEntityVehicle.ClassId;
                cmdUpdateVehicleClass.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityVehicle.ClassName;
                cmdUpdateVehicleClass.Parameters.Add("V_IMAGE", OracleDbType.Int32).Value = objEntityVehicle.ImageId;
                cmdUpdateVehicleClass.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityVehicle.Organisation_id;
                cmdUpdateVehicleClass.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityVehicle.Corporate_id;
                cmdUpdateVehicleClass.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = objEntityVehicle.Status_id;
                cmdUpdateVehicleClass.Parameters.Add("V_UPDUSERID", OracleDbType.Int32).Value = objEntityVehicle.User_Id;
                cmdUpdateVehicleClass.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdUpdateVehicleClass.Parameters.Add("V_CTGRYTYP_ID", OracleDbType.Int32).Value = objEntityVehicle.CategoryTypeId;
                clsDataLayer.ExecuteNonQuery(cmdUpdateVehicleClass);
            }
        }
        // This Method checks vehical class name in the database for duplication.
        public string CheckVehicleClassName(clsEntityLayerVehicleClass objEntityVehicle)
        {

            string strQueryCheckVehName = "VEHICLE_CLASS.SP_CHECK_VEHICLE_CLS_NAME";
            OracleCommand cmdCheckVehName = new OracleCommand();
            cmdCheckVehName.CommandText = strQueryCheckVehName;
            cmdCheckVehName.CommandType = CommandType.StoredProcedure;
            cmdCheckVehName.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityVehicle.ClassId;
            cmdCheckVehName.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityVehicle.ClassName;
            cmdCheckVehName.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityVehicle.Corporate_id;
            cmdCheckVehName.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityVehicle.Organisation_id;
            cmdCheckVehName.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehName);
            string strReturn = cmdCheckVehName.Parameters["V_COUNT"].Value.ToString();
            cmdCheckVehName.Dispose();
            return strReturn;
        }
        //Method for cancel vehical class
        public void CancelVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryCancelVehicleClass = "VEHICLE_CLASS.SP_CANCEL_VEHICLE_CLASS";
            using (OracleCommand cmdCancelVehicleClass = new OracleCommand())
            {
                cmdCancelVehicleClass.CommandText = strQueryCancelVehicleClass;
                cmdCancelVehicleClass.CommandType = CommandType.StoredProcedure;
                cmdCancelVehicleClass.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityVehicle.ClassId;
                cmdCancelVehicleClass.Parameters.Add("V_USERID", OracleDbType.Int32).Value = objEntityVehicle.User_Id;
                cmdCancelVehicleClass.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelVehicleClass.Parameters.Add("V_REASON", OracleDbType.Varchar2).Value = objEntityVehicle.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelVehicleClass);
            }
        }
        //Method for recall vehical class
        public void RecallVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryCancelVehicleClass = "VEHICLE_CLASS.SP_RECALL_VEHICLE_CLASS";
            using (OracleCommand cmdCancelVehicleClass = new OracleCommand())
            {
                cmdCancelVehicleClass.CommandText = strQueryCancelVehicleClass;
                cmdCancelVehicleClass.CommandType = CommandType.StoredProcedure;
                cmdCancelVehicleClass.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityVehicle.ClassId;
                cmdCancelVehicleClass.Parameters.Add("V_USERID", OracleDbType.Int32).Value = objEntityVehicle.User_Id;
                cmdCancelVehicleClass.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdCancelVehicleClass);
            }
        }


        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadVehicleClassById(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryReadVehicleClass = "VEHICLE_CLASS.SP_READ_VEHICLE_CLS_BY_ID";
            OracleCommand cmdReadVehicleClass = new OracleCommand();
            cmdReadVehicleClass.CommandText = strQueryReadVehicleClass;
            cmdReadVehicleClass.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleClass.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityVehicle.ClassId;
            cmdReadVehicleClass.Parameters.Add("V_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleClass);
            return dtCategory;
        }
        // This Method will fetch ACCOMODATION list
        public DataTable ReadVehicleClassList(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryReadVehicleClassList = "VEHICLE_CLASS.SP_READ_VEHICLE_CLASS_LIST";
            OracleCommand cmdReadVehicleList = new OracleCommand();
            cmdReadVehicleList.CommandText = strQueryReadVehicleClassList;
            cmdReadVehicleList.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleList.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityVehicle.Organisation_id;
            cmdReadVehicleList.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityVehicle.Corporate_id;
            cmdReadVehicleList.Parameters.Add("V_OPTION", OracleDbType.Int32).Value = objEntityVehicle.Status_id;
            cmdReadVehicleList.Parameters.Add("V_CANCEL", OracleDbType.Int32).Value = objEntityVehicle.CancelStatus;
            cmdReadVehicleList.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleList);
            return dtCategoryList;
        }
        // This Method will fetch ACCOMODATION list
        public DataTable ReadImageDetails(clsEntityLayerVehicleClass objEntityVehicle)
        {
            string strQueryReadImageDetails = "VEHICLE_CLASS.SP_READ_IMAGE_DETAIL";
            OracleCommand cmdReadImage = new OracleCommand();
            cmdReadImage.CommandText = strQueryReadImageDetails;
            cmdReadImage.CommandType = CommandType.StoredProcedure;
            cmdReadImage.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityVehicle.Organisation_id;
            cmdReadImage.Parameters.Add("V_APP_ID", OracleDbType.Int32).Value = objEntityVehicle.AppModeSection;
            cmdReadImage.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadImage);
            return dtCategoryList;
        }
        public DataTable ReadVehicleCategoryType()
        {
            string strQueryReadImageDetails = "VEHICLE_CLASS.SP_READ_VHCL_CTGRYTYP";
            OracleCommand cmdReadImage = new OracleCommand();
            cmdReadImage.CommandText = strQueryReadImageDetails;
            cmdReadImage.CommandType = CommandType.StoredProcedure;
            cmdReadImage.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadImage);
            return dtCategoryList;
        }
      
    }
}
