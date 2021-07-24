using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;
// CREATED BY:EVM-0009
// CREATED DATE:13/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace DL_Compzit
{
  public  class clsDataLayerAccommodationType
    {
        public string CheckAccommodationTypeName(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryCheckAccommodationTypeName = "ACCOMMODATION_TYPE.SP_CHECK_ACCMDTNTYP_NAME";
            OracleCommand cmdCheckAccommodationTypeName = new OracleCommand();
            cmdCheckAccommodationTypeName.CommandText = strQueryCheckAccommodationTypeName;
            cmdCheckAccommodationTypeName.CommandType = CommandType.StoredProcedure;
            cmdCheckAccommodationTypeName.Parameters.Add("AT_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
            cmdCheckAccommodationTypeName.Parameters.Add("AT_ORGID", OracleDbType.Int32).Value = objEntityAccommodationType.Organisation_Id;
            cmdCheckAccommodationTypeName.Parameters.Add("AT_CORPID", OracleDbType.Int32).Value = objEntityAccommodationType.CorpOffice_Id;
            cmdCheckAccommodationTypeName.Parameters.Add("AT_NAME", OracleDbType.Varchar2).Value = objEntityAccommodationType.AccommodationType_Name;
            cmdCheckAccommodationTypeName.Parameters.Add("AT_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckAccommodationTypeName);
            string strReturnCount = cmdCheckAccommodationTypeName.Parameters["AT_COUNT"].Value.ToString();
            cmdCheckAccommodationTypeName.Dispose();
            return strReturnCount; ;
        }
        //Method for inserting data about Accommodation Type to the Accommodation Type master table
        public void Insert_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryAccommodationType = "ACCOMMODATION_TYPE.SP_INSERT_ACCMDTNTYP";
            OracleCommand cmdInsertAccommodationType = new OracleCommand();
            cmdInsertAccommodationType.CommandText = strQueryAccommodationType;
            cmdInsertAccommodationType.CommandType = CommandType.StoredProcedure;
            cmdInsertAccommodationType.Parameters.Add("AT_NAME", OracleDbType.Varchar2).Value = objEntityAccommodationType.AccommodationType_Name;
            cmdInsertAccommodationType.Parameters.Add("AT_STATUS", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodationType_Status;
            cmdInsertAccommodationType.Parameters.Add("AT_ORGID", OracleDbType.Int32).Value = objEntityAccommodationType.Organisation_Id;
            cmdInsertAccommodationType.Parameters.Add("AT_CORPID", OracleDbType.Int32).Value = objEntityAccommodationType.CorpOffice_Id;
            cmdInsertAccommodationType.Parameters.Add("AT_INSUSERID", OracleDbType.Int32).Value = objEntityAccommodationType.User_Id;
            cmdInsertAccommodationType.Parameters.Add("AT_INSDATE", OracleDbType.Date).Value = objEntityAccommodationType.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdInsertAccommodationType);
        }
        //Method for read Accommodation Type for list view.
        //public DataTable ReadAccommodationTypeList(clsEntityAccommodationType objEntityAccommodationType)
        //{
        //    string strQueryReadAccommodationTypeList = "ACCOMMODATION_TYPE.SP_READ_ACCMDTNTYP_LIST";
        //    using (OracleCommand cmdReadAccommodationTypeList = new OracleCommand())
        //    {
        //        cmdReadAccommodationTypeList.CommandText = strQueryReadAccommodationTypeList;
        //        cmdReadAccommodationTypeList.CommandType = CommandType.StoredProcedure;
        //        cmdReadAccommodationTypeList.Parameters.Add("AT_ORGID", OracleDbType.Int32).Value = objEntityAccommodationType.Organisation_Id;
        //        cmdReadAccommodationTypeList.Parameters.Add("AT_CORPID", OracleDbType.Int32).Value = objEntityAccommodationType.CorpOffice_Id;
        //        cmdReadAccommodationTypeList.Parameters.Add("AT_OPTION", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodationType_Status;
        //        cmdReadAccommodationTypeList.Parameters.Add("AT_CANCEL", OracleDbType.Int32).Value = objEntityAccommodationType.Cancel_Status;
        //        cmdReadAccommodationTypeList.Parameters.Add("AT_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //        DataTable dtResultSet = new DataTable();
        //        dtResultSet = clsDataLayer.SelectDataTable(cmdReadAccommodationTypeList);
        //        return dtResultSet;
        //    }
        //}

        public DataTable ReadAccommodationTypeList(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryReadAccommodationTypeList = "ACCOMMODATION_TYPE.SP_READ_ACCMDTNTYP_LIST";
            using (OracleCommand cmdReadAccommodationTypeList = new OracleCommand())
            {
                cmdReadAccommodationTypeList.CommandText = strQueryReadAccommodationTypeList;
                cmdReadAccommodationTypeList.CommandType = CommandType.StoredProcedure;
                cmdReadAccommodationTypeList.Parameters.Add("AT_ORGID", OracleDbType.Int32).Value = objEntityAccommodationType.Organisation_Id;
                cmdReadAccommodationTypeList.Parameters.Add("AT_CORPID", OracleDbType.Int32).Value = objEntityAccommodationType.CorpOffice_Id;
                cmdReadAccommodationTypeList.Parameters.Add("AT_OPTION", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodationType_Status;
                cmdReadAccommodationTypeList.Parameters.Add("AT_CANCEL", OracleDbType.Int32).Value = objEntityAccommodationType.Cancel_Status;
                cmdReadAccommodationTypeList.Parameters.Add("AT_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityAccommodationType.CommonSearchTerm;
                cmdReadAccommodationTypeList.Parameters.Add("AT_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityAccommodationType.SearchType;
                cmdReadAccommodationTypeList.Parameters.Add("AT_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityAccommodationType.OrderColumn;
                cmdReadAccommodationTypeList.Parameters.Add("AT_ORDER_METHOD", OracleDbType.Int32).Value = objEntityAccommodationType.OrderMethod;
                cmdReadAccommodationTypeList.Parameters.Add("AT_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityAccommodationType.PageMaxSize;
                cmdReadAccommodationTypeList.Parameters.Add("AT_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityAccommodationType.PageNumber;
                cmdReadAccommodationTypeList.Parameters.Add("AT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadAccommodationTypeList);
                return dtResultSet;
            }
        }

        //Method for read Accommodation Type by their id.
        public DataTable ReadAccommodationTypeById(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryReadAccommodationTypeListById = "ACCOMMODATION_TYPE.SP_READ_ACCMDTNTYP_BYID";
            using (OracleCommand cmdReadAccmdtnTypeListById = new OracleCommand())
            {
                cmdReadAccmdtnTypeListById.CommandText = strQueryReadAccommodationTypeListById;
                cmdReadAccmdtnTypeListById.CommandType = CommandType.StoredProcedure;
                cmdReadAccmdtnTypeListById.Parameters.Add("AT_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
                cmdReadAccmdtnTypeListById.Parameters.Add("AT_CORPID", OracleDbType.Int32).Value = objEntityAccommodationType.CorpOffice_Id;
                cmdReadAccmdtnTypeListById.Parameters.Add("AT_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadAccmdtnTypeListById);
                return dtResultSet;
            }
        }
        //Method for Updating data about Accommodation Type to the Accommodation Type master table
        public void Update_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryUpdateAccmdtnType = "ACCOMMODATION_TYPE.SP_UPDATE_ACCMDTNTYP";
            OracleCommand cmdUpdateAccmdtnTYpe = new OracleCommand();
            cmdUpdateAccmdtnTYpe.CommandText = strQueryUpdateAccmdtnType;
            cmdUpdateAccmdtnTYpe.CommandType = CommandType.StoredProcedure;
            cmdUpdateAccmdtnTYpe.Parameters.Add("AT_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
            cmdUpdateAccmdtnTYpe.Parameters.Add("AT_NAME", OracleDbType.Varchar2).Value = objEntityAccommodationType.AccommodationType_Name;      
            cmdUpdateAccmdtnTYpe.Parameters.Add("AT_STATUS", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodationType_Status;
            cmdUpdateAccmdtnTYpe.Parameters.Add("AT_UPDUSERID", OracleDbType.Int32).Value = objEntityAccommodationType.User_Id;
            cmdUpdateAccmdtnTYpe.Parameters.Add("AT_UPDDATE", OracleDbType.Date).Value = objEntityAccommodationType.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateAccmdtnTYpe);
        }


        //Method for Cancel Accommodation Type from Accommodation master table so update cancel related fields
        public void Cancel_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryCancelAccmdtnType = "ACCOMMODATION_TYPE.SP_CANCEL_ACCMDTNTYP";
            OracleCommand cmdCancelAccmdtnType = new OracleCommand();
            cmdCancelAccmdtnType.CommandText = strQueryCancelAccmdtnType;
            cmdCancelAccmdtnType.CommandType = CommandType.StoredProcedure;
            cmdCancelAccmdtnType.Parameters.Add("AT_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
            cmdCancelAccmdtnType.Parameters.Add("AT_CANCEL_USERID", OracleDbType.Int32).Value = objEntityAccommodationType.User_Id;
            cmdCancelAccmdtnType.Parameters.Add("AT_CANCEL_DATE", OracleDbType.Date).Value = objEntityAccommodationType.D_Date;
            cmdCancelAccmdtnType.Parameters.Add("AT_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityAccommodationType.AccommmodationType_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelAccmdtnType);
        }

        //Method for Recall Cancelled Accommodation Type from Accommodation Type master table so update cancel related fields
        public void Recall_AccommodationType(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryRecallAccmdtnType = "ACCOMMODATION_TYPE.SP_RECALL_ACCMDTNTYP";
            OracleCommand cmdRecallAccmdtnType = new OracleCommand();
            cmdRecallAccmdtnType.CommandText = strQueryRecallAccmdtnType;
            cmdRecallAccmdtnType.CommandType = CommandType.StoredProcedure;
            cmdRecallAccmdtnType.Parameters.Add("AT_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
            cmdRecallAccmdtnType.Parameters.Add("AT_USERID", OracleDbType.Int32).Value = objEntityAccommodationType.User_Id;
            cmdRecallAccmdtnType.Parameters.Add("AT_DATE", OracleDbType.Date).Value = objEntityAccommodationType.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallAccmdtnType);
        }
        public DataTable ReadAccommodationById(clsEntityAccommodationType objEntityAccommodationType)
        {
            string strQueryRecallAccmdtnType = "ACCOMMODATION_TYPE.SP_READ_ACCOM_BYID";
            using (OracleCommand cmdRecallAccmdtnType = new OracleCommand())
            {
                cmdRecallAccmdtnType.CommandText = strQueryRecallAccmdtnType;
                cmdRecallAccmdtnType.CommandType = CommandType.StoredProcedure;
                cmdRecallAccmdtnType.Parameters.Add("AT_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
                cmdRecallAccmdtnType.Parameters.Add("AT_ORGID", OracleDbType.Int32).Value = objEntityAccommodationType.Organisation_Id;
                cmdRecallAccmdtnType.Parameters.Add("AT_CORPID", OracleDbType.Int32).Value = objEntityAccommodationType.CorpOffice_Id;
                cmdRecallAccmdtnType.Parameters.Add("AT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtAcco = new DataTable();
                dtAcco = clsDataLayer.SelectDataTable(cmdRecallAccmdtnType);
                return dtAcco;
            }
        }
        public void UpdateStatus(clsEntityAccommodationType objEntityAccommodationType)
        {

            string strQueryRecallAccmdtnType = "ACCOMMODATION_TYPE.SP_UPDATE_STATUS";
            using (OracleCommand cmdUpdateAcco = new OracleCommand())
            {
                cmdUpdateAcco.CommandText = strQueryRecallAccmdtnType;
                cmdUpdateAcco.CommandType = CommandType.StoredProcedure;
                cmdUpdateAcco.Parameters.Add("M_ID", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodatonType_Master_Id;
                cmdUpdateAcco.Parameters.Add("M_USERID", OracleDbType.Int32).Value = objEntityAccommodationType.User_Id;
                cmdUpdateAcco.Parameters.Add("M_DATE", OracleDbType.Date).Value = objEntityAccommodationType.D_Date;
                cmdUpdateAcco.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityAccommodationType.AccommodationType_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateAcco);
            }
        }
    }
}
