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
// CREATED DATE:25/11/2016
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit.DataLayer_AWMS
{
    public class clsDataLayerFuelType
    {

        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        // This Method adds accommodation details to the table
        public void AddFuelType(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryAddFuelType = "FUEL_TYPE_MASTER.SP_INS_FUEL_TYPE_DETAILS";
            using (OracleCommand cmdAddFuelType = new OracleCommand())
            {
                cmdAddFuelType.CommandText = strQueryAddFuelType;
                cmdAddFuelType.CommandType = CommandType.StoredProcedure;
                cmdAddFuelType.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityFuel.ClassName;
                cmdAddFuelType.Parameters.Add("V_IMAGE", OracleDbType.Int32).Value = objEntityFuel.ImageId;
                cmdAddFuelType.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityFuel.Organisation_id;
                cmdAddFuelType.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityFuel.Corporate_id;
                cmdAddFuelType.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = objEntityFuel.Status_id;
                cmdAddFuelType.Parameters.Add("V_INSUSERID", OracleDbType.Int32).Value = objEntityFuel.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddFuelType);
            }
        }

        // This Method will fetch ACCOMODATION list
        public DataTable ReadImageDetails(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryReadImageDetails = "FUEL_TYPE_MASTER.SP_READ_IMAGE_DETAIL";
            OracleCommand cmdReadImage = new OracleCommand();
            cmdReadImage.CommandText = strQueryReadImageDetails;
            cmdReadImage.CommandType = CommandType.StoredProcedure;
            cmdReadImage.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityFuel.Organisation_id;
            cmdReadImage.Parameters.Add("V_APP_ID", OracleDbType.Int32).Value = objEntityFuel.AppModeSection;
            cmdReadImage.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadImage);
            return dtCategoryList;
        }

        // This Method will fetch ACCOMODATION list
        public DataTable ReadFuelTypeList(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryReadFuelList = "FUEL_TYPE_MASTER.SP_READ_FUEL_CLASS_LIST";
            OracleCommand cmdReadFuelList = new OracleCommand();
            cmdReadFuelList.CommandText = strQueryReadFuelList;
            cmdReadFuelList.CommandType = CommandType.StoredProcedure;
            cmdReadFuelList.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityFuel.Organisation_id;
            cmdReadFuelList.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityFuel.Corporate_id;
            cmdReadFuelList.Parameters.Add("V_OPTION", OracleDbType.Int32).Value = objEntityFuel.Status_id;
            cmdReadFuelList.Parameters.Add("V_CANCEL", OracleDbType.Int32).Value = objEntityFuel.CancelStatus;
            //------------------------------------------Pagination------------------------------------------------
            cmdReadFuelList.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityFuel.CommonSearchTerm;
            cmdReadFuelList.Parameters.Add("P_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityFuel.SearchName;
            cmdReadFuelList.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityFuel.OrderColumn;
            cmdReadFuelList.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityFuel.OrderMethod;
            cmdReadFuelList.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityFuel.PageMaxSize;
            cmdReadFuelList.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityFuel.PageNumber;
            //------------------------------------------Pagination------------------------------------------------
            cmdReadFuelList.Parameters.Add("V_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadFuelList);
            return dtCategoryList;
        }

        // This Method checks Accommodation name in the database for duplication.
        public string CheckFuelTypeName(clsEntityLayerFuelType objEntityFuel)
        {

            string strQueryCheckFuelName = "FUEL_TYPE_MASTER.SP_CHECK_FUEL_TYP_NAME";
            OracleCommand cmdCheckFuelName = new OracleCommand();
            cmdCheckFuelName.CommandText = strQueryCheckFuelName;
            cmdCheckFuelName.CommandType = CommandType.StoredProcedure;
            cmdCheckFuelName.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityFuel.FuelId;
            cmdCheckFuelName.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityFuel.ClassName;
            cmdCheckFuelName.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityFuel.Corporate_id;
            cmdCheckFuelName.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityFuel.Organisation_id;
            cmdCheckFuelName.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckFuelName);
            string strReturn = cmdCheckFuelName.Parameters["V_COUNT"].Value.ToString();
            cmdCheckFuelName.Dispose();
            return strReturn;
        }

        // This Method update accommoadation details to the table
        public void UpdateFuelType(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryUpdateFuelType = "FUEL_TYPE_MASTER.SP_UPD_FUEL_TYPE_DETAILS";
            using (OracleCommand cmdUpdateFuelType = new OracleCommand())
            {
                cmdUpdateFuelType.CommandText = strQueryUpdateFuelType;
                cmdUpdateFuelType.CommandType = CommandType.StoredProcedure;

                cmdUpdateFuelType.Parameters.Add("V_ID", OracleDbType.Varchar2).Value = objEntityFuel.FuelId;
                cmdUpdateFuelType.Parameters.Add("V_NAME", OracleDbType.Varchar2).Value = objEntityFuel.ClassName;
                cmdUpdateFuelType.Parameters.Add("V_IMAGE", OracleDbType.Int32).Value = objEntityFuel.ImageId;
                cmdUpdateFuelType.Parameters.Add("V_ORGID", OracleDbType.Int32).Value = objEntityFuel.Organisation_id;
                cmdUpdateFuelType.Parameters.Add("V_CORPID", OracleDbType.Int32).Value = objEntityFuel.Corporate_id;
                cmdUpdateFuelType.Parameters.Add("V_STATUS", OracleDbType.Int32).Value = objEntityFuel.Status_id;
                cmdUpdateFuelType.Parameters.Add("V_UPDUSERID", OracleDbType.Int32).Value = objEntityFuel.User_Id;
                cmdUpdateFuelType.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateFuelType);
            }
        }

        //Method for cancel Accommodation
        public void CancelFuelType(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryCancelFuelType = "FUEL_TYPE_MASTER.SP_CANCEL_FUEL_TYPE";
            using (OracleCommand cmdCancelFuelType = new OracleCommand())
            {
                cmdCancelFuelType.CommandText = strQueryCancelFuelType;
                cmdCancelFuelType.CommandType = CommandType.StoredProcedure;
                cmdCancelFuelType.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityFuel.FuelId;
                cmdCancelFuelType.Parameters.Add("V_USERID", OracleDbType.Int32).Value = objEntityFuel.User_Id;
                cmdCancelFuelType.Parameters.Add("V_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelFuelType.Parameters.Add("V_REASON", OracleDbType.Varchar2).Value = objEntityFuel.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelFuelType);
            }
        }

        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadFuelTypeById(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryReadFuelType = "FUEL_TYPE_MASTER.SP_READ_FUEL_TYPE_BY_ID";
            OracleCommand cmdReadFuelType = new OracleCommand();
            cmdReadFuelType.CommandText = strQueryReadFuelType;
            cmdReadFuelType.CommandType = CommandType.StoredProcedure;
            cmdReadFuelType.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityFuel.FuelId;
            cmdReadFuelType.Parameters.Add("V_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadFuelType);
            return dtCategory;
        }

        //Method for recall fuel type

        public void ReCallFuelType(clsEntityLayerFuelType ObjEntityFuel)
        {
            string strQueryRecallWaterCard = "FUEL_TYPE_MASTER.SP_RECALL_FUEL_TYPE";
            using (OracleCommand cmdRecallWaterCard = new OracleCommand())
            {
                cmdRecallWaterCard.CommandText = strQueryRecallWaterCard;
                cmdRecallWaterCard.CommandType = CommandType.StoredProcedure;
                cmdRecallWaterCard.Parameters.Add("W_ID", OracleDbType.Int32).Value = ObjEntityFuel.FuelId;
                cmdRecallWaterCard.Parameters.Add("W_USERID", OracleDbType.Int32).Value = ObjEntityFuel.User_Id;
                cmdRecallWaterCard.Parameters.Add("W_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdRecallWaterCard);
            }
        }

        public void ChangeStatus(clsEntityLayerFuelType objEntityFuel)
        {
            string strQueryRead = "FUEL_TYPE_MASTER.SP_STATUS_CHANGE";
            OracleCommand cmdSts = new OracleCommand();
            cmdSts.CommandText = strQueryRead;
            cmdSts.CommandType = CommandType.StoredProcedure;
            cmdSts.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityFuel.FuelId;
            cmdSts.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityFuel.Status_id;
            clsDataLayer.ExecuteNonQuery(cmdSts);
        }

        
    }

 }
