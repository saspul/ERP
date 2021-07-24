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
    public class clsDataLayerLicenseType
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // this method is for insert the license types
        public void AddLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryAddLicense = "LICENSE_TYPE_MASTER.SP_INS_LICENSE_TYPE";
            using (OracleCommand cmdAddLicenseType = new OracleCommand())
            {
                cmdAddLicenseType.CommandText = strQueryAddLicense;
                cmdAddLicenseType.CommandType = CommandType.StoredProcedure;
                cmdAddLicenseType.Parameters.Add("LT_NAME", OracleDbType.Varchar2).Value = objEntityLicense.ClassName;
                cmdAddLicenseType.Parameters.Add("LT_IMAGE", OracleDbType.Int32).Value = objEntityLicense.ImageId;
                cmdAddLicenseType.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
                cmdAddLicenseType.Parameters.Add("LT_CORPID", OracleDbType.Int32).Value = objEntityLicense.Corporate_id;
                cmdAddLicenseType.Parameters.Add("LT_STATUS", OracleDbType.Int32).Value = objEntityLicense.Status_id;
                cmdAddLicenseType.Parameters.Add("LT_INSUSERID", OracleDbType.Int32).Value = objEntityLicense.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddLicenseType);
            }
        }

        // This Method update the license type details to the table
        public void UpdateLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryUpdateLicense = "LICENSE_TYPE_MASTER.SP_UPD_LICENSE_TYPE_DETAILS";
            using (OracleCommand cmdUpdateLicenseType = new OracleCommand())
            {
                cmdUpdateLicenseType.CommandText = strQueryUpdateLicense;
                cmdUpdateLicenseType.CommandType = CommandType.StoredProcedure;

                cmdUpdateLicenseType.Parameters.Add("LT_ID", OracleDbType.Varchar2).Value = objEntityLicense.LtypId;
                cmdUpdateLicenseType.Parameters.Add("LT_NAME", OracleDbType.Varchar2).Value = objEntityLicense.ClassName;
                cmdUpdateLicenseType.Parameters.Add("LT_IMAGE", OracleDbType.Int32).Value = objEntityLicense.ImageId;
                cmdUpdateLicenseType.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
                cmdUpdateLicenseType.Parameters.Add("LT_CORPID", OracleDbType.Int32).Value = objEntityLicense.Corporate_id;
                cmdUpdateLicenseType.Parameters.Add("LT_STATUS", OracleDbType.Int32).Value = objEntityLicense.Status_id;
                cmdUpdateLicenseType.Parameters.Add("LT_UPDUSERID", OracleDbType.Int32).Value = objEntityLicense.User_Id;
                cmdUpdateLicenseType.Parameters.Add("LT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateLicenseType);
            }
        }

        // This Method checks License type name in the database for duplication.
        public string CheckLicenseTypeName(clsEntityLayerLicenseType objEntityLicense)
        {

            string strQueryCheckLicenseTypeName = "LICENSE_TYPE_MASTER.SP_CHECK_LICENSE_TYPE_NAME";
            OracleCommand cmdCheckLicenseTypeName = new OracleCommand();
            cmdCheckLicenseTypeName.CommandText = strQueryCheckLicenseTypeName;
            cmdCheckLicenseTypeName.CommandType = CommandType.StoredProcedure;
            cmdCheckLicenseTypeName.Parameters.Add("LT_ID", OracleDbType.Int32).Value = objEntityLicense.LtypId;
            cmdCheckLicenseTypeName.Parameters.Add("LT_NAME", OracleDbType.Varchar2).Value = objEntityLicense.ClassName;
            cmdCheckLicenseTypeName.Parameters.Add("LT_CORPID", OracleDbType.Int32).Value = objEntityLicense.Corporate_id;
            cmdCheckLicenseTypeName.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
            cmdCheckLicenseTypeName.Parameters.Add("LT_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckLicenseTypeName);
            string strReturn = cmdCheckLicenseTypeName.Parameters["LT_COUNT"].Value.ToString();
            cmdCheckLicenseTypeName.Dispose();
            return strReturn;
        }


        //Method for cancel LicenseType
        public void CancelLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryCancelLicenseType = "LICENSE_TYPE_MASTER.SP_CANCEL_LICENSE_TYPE";
            using (OracleCommand cmdCancelLicenseType = new OracleCommand())
            {
                cmdCancelLicenseType.CommandText = strQueryCancelLicenseType;
                cmdCancelLicenseType.CommandType = CommandType.StoredProcedure;
                cmdCancelLicenseType.Parameters.Add("LT_ID", OracleDbType.Int32).Value = objEntityLicense.LtypId;
                cmdCancelLicenseType.Parameters.Add("LT_USERID", OracleDbType.Int32).Value = objEntityLicense.User_Id;
                cmdCancelLicenseType.Parameters.Add("LT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelLicenseType.Parameters.Add("LT_REASON", OracleDbType.Varchar2).Value = objEntityLicense.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelLicenseType);
            }
        }


        // This Method will fetCH License typoe BY ID
        public DataTable ReadLicenseTypeById(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryReadLicenseTypeById = "LICENSE_TYPE_MASTER.SP_READ_LICENSE_TYPE_BY_ID";
            OracleCommand cmdReadLicenseTypeById = new OracleCommand();
            cmdReadLicenseTypeById.CommandText = strQueryReadLicenseTypeById;
            cmdReadLicenseTypeById.CommandType = CommandType.StoredProcedure;
            cmdReadLicenseTypeById.Parameters.Add("LT_ID", OracleDbType.Int32).Value = objEntityLicense.LtypId;
            cmdReadLicenseTypeById.Parameters.Add("LT_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadLicenseTypeById);
            return dtCategory;
        }


        // This Method will fetch License type list
        //public DataTable ReadLicenseTypeList(clsEntityLayerLicenseType objEntityLicense)
        //{
        //    string strQueryReadLicenseTypeList = "LICENSE_TYPE_MASTER.SP_READ_LICENSE_TYPE_LIST";
        //    OracleCommand cmdReadLicenseTypeList = new OracleCommand();
        //    cmdReadLicenseTypeList.CommandText = strQueryReadLicenseTypeList;
        //    cmdReadLicenseTypeList.CommandType = CommandType.StoredProcedure;
        //    cmdReadLicenseTypeList.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
        //    cmdReadLicenseTypeList.Parameters.Add("LT_CORPID", OracleDbType.Int32).Value = objEntityLicense.Corporate_id;
        //    cmdReadLicenseTypeList.Parameters.Add("LT_OPTION", OracleDbType.Int32).Value = objEntityLicense.Status_id;
        //    cmdReadLicenseTypeList.Parameters.Add("LT_CANCEL", OracleDbType.Int32).Value = objEntityLicense.CancelStatus;
        //    cmdReadLicenseTypeList.Parameters.Add("LT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtCategoryList = new DataTable();
        //    dtCategoryList = clsDataLayer.ExecuteReader(cmdReadLicenseTypeList);
        //    return dtCategoryList;
        //}

        public DataTable ReadLicenseTypeList(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryReadLicenseTypeList = "LICENSE_TYPE_MASTER.SP_READ_LICENSE_TYPE_LIST";
            using (OracleCommand cmdReadLicenseTypeList = new OracleCommand())
            {
                cmdReadLicenseTypeList.CommandText = strQueryReadLicenseTypeList;
                cmdReadLicenseTypeList.CommandType = CommandType.StoredProcedure;
                cmdReadLicenseTypeList.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
                cmdReadLicenseTypeList.Parameters.Add("LT_CORPID", OracleDbType.Int32).Value = objEntityLicense.Corporate_id;
                cmdReadLicenseTypeList.Parameters.Add("LT_OPTION", OracleDbType.Int32).Value = objEntityLicense.Status_id;
                cmdReadLicenseTypeList.Parameters.Add("LT_CANCEL", OracleDbType.Int32).Value = objEntityLicense.CancelStatus;
                cmdReadLicenseTypeList.Parameters.Add("LT_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLicense.CommonSearchTerm;
                cmdReadLicenseTypeList.Parameters.Add("LT_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityLicense.SearchType;
                cmdReadLicenseTypeList.Parameters.Add("LT_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLicense.OrderColumn;
                cmdReadLicenseTypeList.Parameters.Add("LT_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLicense.OrderMethod;
                cmdReadLicenseTypeList.Parameters.Add("LT_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLicense.PageMaxSize;
                cmdReadLicenseTypeList.Parameters.Add("LT_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLicense.PageNumber;
                cmdReadLicenseTypeList.Parameters.Add("LT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadLicenseTypeList);
                return dtResultSet;
            }
        }
        // This Method will fetch image list
        public DataTable ReadImageDetails(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryReadImageDetails = "LICENSE_TYPE_MASTER.SP_READ_IMAGE_DETAIL";
            OracleCommand cmdReadImage = new OracleCommand();
            cmdReadImage.CommandText = strQueryReadImageDetails;
            cmdReadImage.CommandType = CommandType.StoredProcedure;
            cmdReadImage.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
            cmdReadImage.Parameters.Add("LT_APP_ID", OracleDbType.Int32).Value = objEntityLicense.AppModeSection;
            cmdReadImage.Parameters.Add("LT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadImage);
            return dtCategoryList;
        }

        //Method for recall License Type

        public void ReCallLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryRecallLicenseType = "LICENSE_TYPE_MASTER.SP_RECALL_LICENSE_TYPE";
            using (OracleCommand cmdRecallLicenseTyp = new OracleCommand())
            {
                cmdRecallLicenseTyp.CommandText = strQueryRecallLicenseType;
                cmdRecallLicenseTyp.CommandType = CommandType.StoredProcedure;
                cmdRecallLicenseTyp.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLicense.LtypId;
                cmdRecallLicenseTyp.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityLicense.User_Id;
                cmdRecallLicenseTyp.Parameters.Add("L_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdRecallLicenseTyp);
            }
        }
        public DataTable ReadLictyById(clsEntityLayerLicenseType objEntityLicense)
        {
            string strQueryRecallLicType = "LICENSE_TYPE_MASTER.SP_READ_LIC_BYID";
            using (OracleCommand cmdRecallLicType = new OracleCommand())
            {
                cmdRecallLicType.CommandText = strQueryRecallLicType;
                cmdRecallLicType.CommandType = CommandType.StoredProcedure;
                cmdRecallLicType.Parameters.Add("LT_ID", OracleDbType.Int32).Value = objEntityLicense.LtypId;
                cmdRecallLicType.Parameters.Add("LT_ORGID", OracleDbType.Int32).Value = objEntityLicense.Organisation_id;
                cmdRecallLicType.Parameters.Add("LT_CORPID", OracleDbType.Int32).Value = objEntityLicense.Corporate_id;
                cmdRecallLicType.Parameters.Add("LT_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtAcco = new DataTable();
                dtAcco = clsDataLayer.SelectDataTable(cmdRecallLicType);
                return dtAcco;
            }
        }
        public void UpdateStatus(clsEntityLayerLicenseType objEntityLicense)
        {

            string strQueryRecallLicType = "LICENSE_TYPE_MASTER.SP_UPDATE_STATUS";
            using (OracleCommand cmdUpdateLic = new OracleCommand())
            {
                cmdUpdateLic.CommandText = strQueryRecallLicType;
                cmdUpdateLic.CommandType = CommandType.StoredProcedure;
                cmdUpdateLic.Parameters.Add("LT_ID", OracleDbType.Int32).Value = objEntityLicense.LtypId;
                cmdUpdateLic.Parameters.Add("LT_USERID", OracleDbType.Int32).Value = objEntityLicense.User_Id;
                cmdUpdateLic.Parameters.Add("LT_DATE", OracleDbType.Date).Value = objEntityLicense.Date;
                cmdUpdateLic.Parameters.Add("LT_STATUS", OracleDbType.Int32).Value = objEntityLicense.Status_id;
                clsDataLayer.ExecuteNonQuery(cmdUpdateLic);
            }
        }
    }
}
