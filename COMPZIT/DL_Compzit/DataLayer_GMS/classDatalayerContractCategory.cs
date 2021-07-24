using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;

namespace DL_Compzit.DataLayer_GMS
{
    public class classDatalayerContractCategory
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds job category details to the table
        public void AddContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryAddContractCat = "CONTRACT_CATEGORY_MASTER.SP_INS_CNTRCT_CAT_DETAILS";
            using (OracleCommand cmdAddContractCat = new OracleCommand())
            {
                cmdAddContractCat.CommandText = strQueryAddContractCat;
                cmdAddContractCat.CommandType = CommandType.StoredProcedure;
                cmdAddContractCat.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCntrctCat.CntrctCatname;
                cmdAddContractCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCntrctCat.JobCat_Status;
                cmdAddContractCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrctCat.Organisation_Id;
                cmdAddContractCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrctCat.CorpOffice_Id;
                cmdAddContractCat.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityCntrctCat.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddContractCat);
            }
        }
        public void UpdateContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryUpdateCntrctCat = "CONTRACT_CATEGORY_MASTER.SP_UPD_CNTRCT_CAT_DETAILS";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
                cmdUpdateCntrctCat.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCntrctCat.CntrctCatname;
                cmdUpdateCntrctCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCntrctCat.JobCat_Status;
                cmdUpdateCntrctCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrctCat.Organisation_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrctCat.CorpOffice_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityCntrctCat.User_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }
        public void ChangeCategoryStatus(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryUpdateCntrctCat = "CONTRACT_CATEGORY_MASTER.SP_UPD_CNTRCT_CAT_STATUS";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
                cmdUpdateCntrctCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCntrctCat.JobCat_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }
        // This Method checks job category name in the database for duplication.
        public string CheckContractCatName(classEntityLayerContractCategory objEntityCntrctCat)
        {

            string strQueryCheckCatName = "CONTRACT_CATEGORY_MASTER.SP_CHECK_CNTRCT_CAT_NAME";
            OracleCommand cmdCheckCntrctName = new OracleCommand();
            cmdCheckCntrctName.CommandText = strQueryCheckCatName;
            cmdCheckCntrctName.CommandType = CommandType.StoredProcedure;
            cmdCheckCntrctName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
            cmdCheckCntrctName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCntrctCat.CntrctCatname;
            cmdCheckCntrctName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrctCat.CorpOffice_Id;
            cmdCheckCntrctName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrctCat.Organisation_Id;
            cmdCheckCntrctName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCntrctName);
            string strReturn = cmdCheckCntrctName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCntrctName.Dispose();
            return strReturn;
        }

        //Method for cancel job category
        public void CancelContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryCancelCntrctCat = "CONTRACT_CATEGORY_MASTER.SP_CANCEL_CNTRCT_CAT";
            using (OracleCommand cmdCancelCntrctCat = new OracleCommand())
            {
                cmdCancelCntrctCat.CommandText = strQueryCancelCntrctCat;
                cmdCancelCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdCancelCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
                cmdCancelCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrctCat.User_Id;
                cmdCancelCntrctCat.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelCntrctCat.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityCntrctCat.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCntrctCat);
            }
        }
        //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
        public void ReCallContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryRecallCntrct = "CONTRACT_CATEGORY_MASTER.SP_RECALL_CNTRCT_CAT";
            OracleCommand cmdRecallCntrct = new OracleCommand();
            cmdRecallCntrct.CommandText = strQueryRecallCntrct;
            cmdRecallCntrct.CommandType = CommandType.StoredProcedure;
            cmdRecallCntrct.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
            cmdRecallCntrct.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrctCat.User_Id;
            cmdRecallCntrct.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCntrctCat.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallCntrct);
        }
        // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadContractCategryById(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryReadCntrctCatgry = "CONTRACT_CATEGORY_MASTER.SP_READ_CNTRCT_CAT_BY_ID";
            OracleCommand cmdReadCntrctCatgry = new OracleCommand();
            cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
            cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCatgry.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
            cmdReadCntrctCatgry.Parameters.Add("C_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
            return dtCategory;
        }
        // This Method will fetch job category list
        public DataTable ReadContractCtgryList(classEntityLayerContractCategory objEntityCntrctCat)
        {
            string strQueryReadCntrctList = "CONTRACT_CATEGORY_MASTER.SP_READ_CNTRCT_CAT_LIST";
            OracleCommand cmdReadCntrctList = new OracleCommand();
            cmdReadCntrctList.CommandText = strQueryReadCntrctList;
            cmdReadCntrctList.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrctCat.Organisation_Id;
            cmdReadCntrctList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrctCat.CorpOffice_Id;
            cmdReadCntrctList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCntrctCat.JobCat_Status;
            cmdReadCntrctList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCntrctCat.Cancel_Status;
            cmdReadCntrctList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCntrctList);
            return dtCategoryList;
        }
    }
}
