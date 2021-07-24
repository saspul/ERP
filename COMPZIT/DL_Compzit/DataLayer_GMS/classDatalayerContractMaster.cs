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
    public class classDatalayerContractMaster
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        // This Method will fetCH projects
        public DataTable ReadProjects(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadProject = "CONTRACT_MASTER.SP_READ_PROJECTS";
            OracleCommand cmdReadProject = new OracleCommand();
            cmdReadProject.CommandText = strQueryReadProject;
            cmdReadProject.CommandType = CommandType.StoredProcedure;
            cmdReadProject.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
            cmdReadProject.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdReadProject.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;

            cmdReadProject.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadProject);
            return dtCategory;
        }
        // This Method will fetCH contract category
        public DataTable ReadContractCategory(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadCntrctCat = "CONTRACT_MASTER.SP_READ_CNTRCT_CATEGORY";
            OracleCommand cmdReadCntrctCat = new OracleCommand();
            cmdReadCntrctCat.CommandText = strQueryReadCntrctCat;
            cmdReadCntrctCat.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdReadCntrctCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdReadCntrctCat.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCat);
            return dtCategory;
        }
        // This Method will fetCH JOB category
        public DataTable ReadJobCategory(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadCntrctCat = "CONTRACT_MASTER.SP_READ_JOB_CATEGORY";
            OracleCommand cmdReadCntrctCat = new OracleCommand();
            cmdReadCntrctCat.CommandText = strQueryReadCntrctCat;
            cmdReadCntrctCat.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdReadCntrctCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdReadCntrctCat.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCat);
            return dtCategory;
        }
        // This Method will fetCH JOB category
        public DataTable ReadContractor(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadCntrctCat = "CONTRACT_MASTER.SP_READ_CONTRACTOR";
            OracleCommand cmdReadCntrctCat = new OracleCommand();
            cmdReadCntrctCat.CommandText = strQueryReadCntrctCat;
            cmdReadCntrctCat.CommandType = CommandType.StoredProcedure;
            //cmdReadCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
            cmdReadCntrctCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdReadCntrctCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdReadCntrctCat.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCat);
            return dtCategory;
        }
        // This Method will fetCH JOB category
        public DataTable ReadParentContract(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadCntrctCat = "CONTRACT_MASTER.SP_READ_PARENT_CONTRACT";
            OracleCommand cmdReadCntrctCat = new OracleCommand();
            cmdReadCntrctCat.CommandText = strQueryReadCntrctCat;
            cmdReadCntrctCat.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCat.Parameters.Add("C_CNTRCT_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
            cmdReadCntrctCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdReadCntrctCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdReadCntrctCat.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCat);
            return dtCategory;
        }

        // This Method adds job category details to the table
        public string AddContract(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryAddContract = "CONTRACT_MASTER.SP_INS_CNTRCT_DETAILS";
            OracleCommand cmdAddContract = new OracleCommand();
            cmdAddContract.CommandText = strQueryAddContract;
            cmdAddContract.CommandType = CommandType.StoredProcedure;
            cmdAddContract.CommandText = strQueryAddContract;
            cmdAddContract.CommandType = CommandType.StoredProcedure;
            cmdAddContract.Parameters.Add("C_REFNUM", OracleDbType.Varchar2).Value = objEntityCntrct.RefNumber;
            cmdAddContract.Parameters.Add("C_PRJCT_ID", OracleDbType.Int32).Value = objEntityCntrct.ProjectId;
            cmdAddContract.Parameters.Add("C_CNTRCTNAME", OracleDbType.Varchar2).Value = objEntityCntrct.Sub_Cntrct_Name;
            cmdAddContract.Parameters.Add("C_CATID", OracleDbType.Int32).Value = objEntityCntrct.CntrctCatId;
            cmdAddContract.Parameters.Add("C_CNTRCTCODE", OracleDbType.Varchar2).Value = objEntityCntrct.Sub_CntrctCode;
            cmdAddContract.Parameters.Add("C_CNTRCTRID", OracleDbType.Int32).Value = objEntityCntrct.SubCntrctrId;
            cmdAddContract.Parameters.Add("C_JOBCATID", OracleDbType.Int32).Value = objEntityCntrct.JobCat_Id;
            if (objEntityCntrct.Parnt_SubCntrct_Id != 0)
            {
                cmdAddContract.Parameters.Add("C_PARNTCNTRCT", OracleDbType.Int32).Value = objEntityCntrct.Parnt_SubCntrct_Id;
            }
            else
            {
                cmdAddContract.Parameters.Add("C_PARNTCNTRCT", OracleDbType.Int32).Value = null;
            }
            cmdAddContract.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCntrct.Contract_Status;
            cmdAddContract.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdAddContract.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdAddContract.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
            cmdAddContract.Parameters.Add("C_CNTRCT_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
            // clsDataLayer.ExecuteNonQuery(cmdAddContract);
            clsDataLayer.ExecuteScalar(ref cmdAddContract);
            string strReturn = cmdAddContract.Parameters["C_CNTRCT_ID"].Value.ToString();
            cmdAddContract.Dispose();
            return strReturn;

        }
        public void UpdateContract(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryUpdateCntrct = "CONTRACT_MASTER.SP_UPD_CNTRCT_DETAILS";
            using (OracleCommand cmdUpdateCntrct = new OracleCommand())
            {
                cmdUpdateCntrct.CommandText = strQueryUpdateCntrct;
                cmdUpdateCntrct.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrct.Parameters.Add("C_CNTRCT_ID", OracleDbType.Varchar2).Value = objEntityCntrct.CntrctId;
                cmdUpdateCntrct.Parameters.Add("C_PRJCT_ID", OracleDbType.Int32).Value = objEntityCntrct.ProjectId;
                cmdUpdateCntrct.Parameters.Add("C_CNTRCTNAME", OracleDbType.Varchar2).Value = objEntityCntrct.Sub_Cntrct_Name;
                cmdUpdateCntrct.Parameters.Add("C_CATID", OracleDbType.Int32).Value = objEntityCntrct.CntrctCatId;
                cmdUpdateCntrct.Parameters.Add("C_CNTRCTCODE", OracleDbType.Varchar2).Value = objEntityCntrct.Sub_CntrctCode;
                cmdUpdateCntrct.Parameters.Add("C_CNTRCTRID", OracleDbType.Int32).Value = objEntityCntrct.SubCntrctrId;
                cmdUpdateCntrct.Parameters.Add("C_JOBCATID", OracleDbType.Int32).Value = objEntityCntrct.JobCat_Id;
                if (objEntityCntrct.Parnt_SubCntrct_Id != 0)
                {
                    cmdUpdateCntrct.Parameters.Add("C_PARNTCNTRCT", OracleDbType.Int32).Value = objEntityCntrct.Parnt_SubCntrct_Id;
                }
                else
                {
                    cmdUpdateCntrct.Parameters.Add("C_PARNTCNTRCT", OracleDbType.Int32).Value = null;
                }
                cmdUpdateCntrct.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCntrct.Contract_Status;
                cmdUpdateCntrct.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
                cmdUpdateCntrct.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
                cmdUpdateCntrct.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
                cmdUpdateCntrct.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrct);
            }
        }
        public void ChangeContractStatus(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryUpdateCntrct = "CONTRACT_MASTER.SP_UPD_CNTRCT_STATUS";
            using (OracleCommand cmdUpdateCntrct = new OracleCommand())
            {
                cmdUpdateCntrct.CommandText = strQueryUpdateCntrct;
                cmdUpdateCntrct.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrct.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
                cmdUpdateCntrct.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityCntrct.Contract_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrct);
            }
        }
        // This Method checks job category name in the database for duplication.
        public string CheckContractName(classEntityLayerContractMaster objEntityCntrct)
        {

            string strQueryCheckContractName = "CONTRACT_MASTER.SP_CHECK_CNTRCT_NAME";
            OracleCommand cmdCheckCntrctName = new OracleCommand();
            cmdCheckCntrctName.CommandText = strQueryCheckContractName;
            cmdCheckCntrctName.CommandType = CommandType.StoredProcedure;
            cmdCheckCntrctName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
            cmdCheckCntrctName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityCntrct.Sub_Cntrct_Name;
            cmdCheckCntrctName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdCheckCntrctName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdCheckCntrctName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCntrctName);
            string strReturn = cmdCheckCntrctName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCntrctName.Dispose();
            return strReturn;
        }
        // This Method checks job category name in the database for duplication.
        public string CheckContractCode(classEntityLayerContractMaster objEntityCntrct)
        {

            string strQueryCheckContractCode = "CONTRACT_MASTER.SP_CHECK_CNTRCT_CODE";
            OracleCommand cmdCheckCntrctCode = new OracleCommand();
            cmdCheckCntrctCode.CommandText = strQueryCheckContractCode;
            cmdCheckCntrctCode.CommandType = CommandType.StoredProcedure;
            cmdCheckCntrctCode.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
            cmdCheckCntrctCode.Parameters.Add("C_CODE", OracleDbType.Varchar2).Value = objEntityCntrct.Sub_CntrctCode;
            cmdCheckCntrctCode.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdCheckCntrctCode.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdCheckCntrctCode.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCntrctCode);
            string strReturn = cmdCheckCntrctCode.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCntrctCode.Dispose();
            return strReturn;
        }
        //Method for cancel job category
        public void CancelContract(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryCancelCntrct = "CONTRACT_MASTER.SP_CANCEL_CONTRACT";
            using (OracleCommand cmdCancelCntrct = new OracleCommand())
            {
                cmdCancelCntrct.CommandText = strQueryCancelCntrct;
                cmdCancelCntrct.CommandType = CommandType.StoredProcedure;
                cmdCancelCntrct.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
                cmdCancelCntrct.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
                cmdCancelCntrct.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelCntrct.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityCntrct.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCntrct);
            }
        }
        //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
        public void ReCallContract(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryRecallCntrct = "CONTRACT_MASTER.SP_RECALL_CONTRACT";
            OracleCommand cmdRecallCntrct = new OracleCommand();
            cmdRecallCntrct.CommandText = strQueryRecallCntrct;
            cmdRecallCntrct.CommandType = CommandType.StoredProcedure;
            cmdRecallCntrct.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
            cmdRecallCntrct.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
            cmdRecallCntrct.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCntrct.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallCntrct);
        }
        // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadContractById(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadCntrctCatgry = "CONTRACT_MASTER.SP_READ_CONTRACT_BY_ID";
            OracleCommand cmdReadCntrctCatgry = new OracleCommand();
            cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
            cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCatgry.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrct.CntrctId;
            cmdReadCntrctCatgry.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
            return dtCategory;
        }
        // This Method will fetch job category list
        public DataTable ReadContractList(classEntityLayerContractMaster objEntityCntrct)
        {
            string strQueryReadCntrctList = "CONTRACT_MASTER.SP_READ_CONTRACT_LIST";
            OracleCommand cmdReadCntrctList = new OracleCommand();
            cmdReadCntrctList.CommandText = strQueryReadCntrctList;
            cmdReadCntrctList.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctList.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrct.User_Id;
            cmdReadCntrctList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCntrct.Organisation_Id;
            cmdReadCntrctList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCntrct.CorpOffice_Id;
            cmdReadCntrctList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCntrct.Contract_Status;
            cmdReadCntrctList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCntrct.Cancel_Status;
            cmdReadCntrctList.Parameters.Add("C_CNTRCTR", OracleDbType.Int32).Value = objEntityCntrct.SubCntrctrId;
            cmdReadCntrctList.Parameters.Add("C_CNT_CTGRY", OracleDbType.Int32).Value = objEntityCntrct.CntrctCatId;
            cmdReadCntrctList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCntrctList);
            return dtCategoryList;
        }
    }
}
