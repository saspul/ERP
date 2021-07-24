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
    public class clsDataLayerInsuranceCoverageType
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds vehical class details to the table
        public void AddCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            string strQueryAddVehicleClass = "INSURANCE_COVERAGE_TYPE.SP_INS_COVRGTYP_DETAILS";
            using (OracleCommand cmdAddVehicleClass = new OracleCommand())
            {
                cmdAddVehicleClass.CommandText = strQueryAddVehicleClass;
                cmdAddVehicleClass.CommandType = CommandType.StoredProcedure;
                cmdAddVehicleClass.Parameters.Add("CT_NAME", OracleDbType.Varchar2).Value = objEntityCoverageType.CoverageTypeName;
                cmdAddVehicleClass.Parameters.Add("CT_ORGID", OracleDbType.Int32).Value = objEntityCoverageType.Organisation_id;
                cmdAddVehicleClass.Parameters.Add("CT_CORPID", OracleDbType.Int32).Value = objEntityCoverageType.Corporate_id;
                cmdAddVehicleClass.Parameters.Add("CT_STATUS", OracleDbType.Int32).Value = objEntityCoverageType.Status_id;
                cmdAddVehicleClass.Parameters.Add("CT_INSUSERID", OracleDbType.Int32).Value = objEntityCoverageType.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddVehicleClass);
            }
        }
        // This Method update vehical class details to the table
        public void UpdateCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            string strQueryUpdateVehicleClass = "INSURANCE_COVERAGE_TYPE.SP_UPD_COVRGTYP_DETAILS";
            using (OracleCommand cmdUpdateVehicleClass = new OracleCommand())
            {
                cmdUpdateVehicleClass.CommandText = strQueryUpdateVehicleClass;
                cmdUpdateVehicleClass.CommandType = CommandType.StoredProcedure;

                cmdUpdateVehicleClass.Parameters.Add("CT_ID", OracleDbType.Varchar2).Value = objEntityCoverageType.CoverageTypeId;
                cmdUpdateVehicleClass.Parameters.Add("CT_NAME", OracleDbType.Varchar2).Value = objEntityCoverageType.CoverageTypeName;
                cmdUpdateVehicleClass.Parameters.Add("CT_ORGID", OracleDbType.Int32).Value = objEntityCoverageType.Organisation_id;
                cmdUpdateVehicleClass.Parameters.Add("CT_CORPID", OracleDbType.Int32).Value = objEntityCoverageType.Corporate_id;
                cmdUpdateVehicleClass.Parameters.Add("CT_STATUS", OracleDbType.Int32).Value = objEntityCoverageType.Status_id;
                cmdUpdateVehicleClass.Parameters.Add("CT_UPDUSERID", OracleDbType.Int32).Value = objEntityCoverageType.User_Id;
                cmdUpdateVehicleClass.Parameters.Add("CT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateVehicleClass);
            }
        }
        // This Method checks coverage type  name in the database for duplication.
        public string CheckCoverageTypeName(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {

            string strQueryCheckVehName = "INSURANCE_COVERAGE_TYPE.SP_CHECK_COVRGTYP_NAME";
            OracleCommand cmdCheckVehName = new OracleCommand();
            cmdCheckVehName.CommandText = strQueryCheckVehName;
            cmdCheckVehName.CommandType = CommandType.StoredProcedure;
            cmdCheckVehName.Parameters.Add("CT_ID", OracleDbType.Int32).Value = objEntityCoverageType.CoverageTypeId;
            cmdCheckVehName.Parameters.Add("CT_NAME", OracleDbType.Varchar2).Value = objEntityCoverageType.CoverageTypeName;
            cmdCheckVehName.Parameters.Add("CT_CORPID", OracleDbType.Int32).Value = objEntityCoverageType.Corporate_id;
            cmdCheckVehName.Parameters.Add("CT_ORGID", OracleDbType.Int32).Value = objEntityCoverageType.Organisation_id;
            cmdCheckVehName.Parameters.Add("CT_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckVehName);
            string strReturn = cmdCheckVehName.Parameters["CT_COUNT"].Value.ToString();
            cmdCheckVehName.Dispose();
            return strReturn;
        }
        //Method for cancel vehical class
        public void CancelCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            string strQueryCancelVehicleClass = "INSURANCE_COVERAGE_TYPE.SP_CANCEL_COVRGTYP";
            using (OracleCommand cmdCancelVehicleClass = new OracleCommand())
            {
                cmdCancelVehicleClass.CommandText = strQueryCancelVehicleClass;
                cmdCancelVehicleClass.CommandType = CommandType.StoredProcedure;
                cmdCancelVehicleClass.Parameters.Add("CT_ID", OracleDbType.Int32).Value = objEntityCoverageType.CoverageTypeId;
                cmdCancelVehicleClass.Parameters.Add("CT_USERID", OracleDbType.Int32).Value = objEntityCoverageType.User_Id;
                cmdCancelVehicleClass.Parameters.Add("CT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelVehicleClass.Parameters.Add("CT_REASON", OracleDbType.Varchar2).Value = objEntityCoverageType.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelVehicleClass);
            }
        }
        //Method for recall vehical class
        public void RecallCoverageType(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            string strQueryCancelVehicleClass = "INSURANCE_COVERAGE_TYPE.SP_RECALL_COVRGTYP";
            using (OracleCommand cmdCancelVehicleClass = new OracleCommand())
            {
                cmdCancelVehicleClass.CommandText = strQueryCancelVehicleClass;
                cmdCancelVehicleClass.CommandType = CommandType.StoredProcedure;
                cmdCancelVehicleClass.Parameters.Add("CT_ID", OracleDbType.Int32).Value = objEntityCoverageType.CoverageTypeId;
                cmdCancelVehicleClass.Parameters.Add("CT_USERID", OracleDbType.Int32).Value = objEntityCoverageType.User_Id;
                cmdCancelVehicleClass.Parameters.Add("CT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdCancelVehicleClass);
            }
        }


        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadCoverageTypeById(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            string strQueryReadVehicleClass = "INSURANCE_COVERAGE_TYPE.SP_READ_COVRGTYP_BY_ID";
            OracleCommand cmdReadVehicleClass = new OracleCommand();
            cmdReadVehicleClass.CommandText = strQueryReadVehicleClass;
            cmdReadVehicleClass.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleClass.Parameters.Add("CT_ID", OracleDbType.Int32).Value = objEntityCoverageType.CoverageTypeId;
            cmdReadVehicleClass.Parameters.Add("CT_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadVehicleClass);
            return dtCategory;
        }
        // This Method will fetch ACCOMODATION list
        public DataTable ReadCoverageTypeList(clsEntityLayerInsuranceCoverageType objEntityCoverageType)
        {
            string strQueryReadVehicleClassList = "INSURANCE_COVERAGE_TYPE.SP_READ_COVRGTYP_LIST";
            OracleCommand cmdReadVehicleList = new OracleCommand();
            cmdReadVehicleList.CommandText = strQueryReadVehicleClassList;
            cmdReadVehicleList.CommandType = CommandType.StoredProcedure;
            cmdReadVehicleList.Parameters.Add("CT_ORGID", OracleDbType.Int32).Value = objEntityCoverageType.Organisation_id;
            cmdReadVehicleList.Parameters.Add("CT_CORPID", OracleDbType.Int32).Value = objEntityCoverageType.Corporate_id;
            cmdReadVehicleList.Parameters.Add("CT_OPTION", OracleDbType.Int32).Value = objEntityCoverageType.Status_id;
            cmdReadVehicleList.Parameters.Add("CT_CANCEL", OracleDbType.Int32).Value = objEntityCoverageType.CancelStatus;
            cmdReadVehicleList.Parameters.Add("CT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadVehicleList);
            return dtCategoryList;
        }
       
    }
}
