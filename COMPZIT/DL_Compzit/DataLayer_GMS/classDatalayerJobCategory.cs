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
   
   public class classDatalayerJobCategory
    {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
       // This Method adds job category details to the table
       public void AddJobCategory(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryAddJobCat = "JOB_CATEGORY_MASTER.SP_INS_JOB_CAT_DETAILS";
           using (OracleCommand cmdAddJobCat = new OracleCommand())
           {
               cmdAddJobCat.CommandText = strQueryAddJobCat;
               cmdAddJobCat.CommandType = CommandType.StoredProcedure;
               cmdAddJobCat.Parameters.Add("J_NAME", OracleDbType.Varchar2).Value = objEntityJobCat.JobCatname;
               cmdAddJobCat.Parameters.Add("J_STATUS", OracleDbType.Int32).Value = objEntityJobCat.JobCat_Status;
               cmdAddJobCat.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobCat.Organisation_Id;
               cmdAddJobCat.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobCat.CorpOffice_Id;
               cmdAddJobCat.Parameters.Add("J_INSUSERID", OracleDbType.Int32).Value = objEntityJobCat.User_Id;
               clsDataLayer.ExecuteNonQuery(cmdAddJobCat);
           }
       }
       public void UpdateJobCategory(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryUpdateJobCat = "JOB_CATEGORY_MASTER.SP_UPD_JOB_CAT_DETAILS";
           using (OracleCommand cmdUpdateJobCat = new OracleCommand())
           {
               cmdUpdateJobCat.CommandText = strQueryUpdateJobCat;
               cmdUpdateJobCat.CommandType = CommandType.StoredProcedure;
               cmdUpdateJobCat.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobCat.JobCatId;
               cmdUpdateJobCat.Parameters.Add("J_NAME", OracleDbType.Varchar2).Value = objEntityJobCat.JobCatname;
               cmdUpdateJobCat.Parameters.Add("J_STATUS", OracleDbType.Int32).Value = objEntityJobCat.JobCat_Status;
               cmdUpdateJobCat.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobCat.Organisation_Id;
               cmdUpdateJobCat.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobCat.CorpOffice_Id;
               cmdUpdateJobCat.Parameters.Add("J_UPDUSERID", OracleDbType.Int32).Value = objEntityJobCat.User_Id;
               cmdUpdateJobCat.Parameters.Add("J_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdUpdateJobCat);
           }
       }
       public void ChangeCategoryStatus(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryUpdateJobCat = "JOB_CATEGORY_MASTER.SP_UPD_JOB_CAT_STATUS";
           using (OracleCommand cmdUpdateJobCat = new OracleCommand())
           {
               cmdUpdateJobCat.CommandText = strQueryUpdateJobCat;
               cmdUpdateJobCat.CommandType = CommandType.StoredProcedure;
               cmdUpdateJobCat.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobCat.JobCatId;
               cmdUpdateJobCat.Parameters.Add("J_STATUS", OracleDbType.Int32).Value = objEntityJobCat.JobCat_Status;
               clsDataLayer.ExecuteNonQuery(cmdUpdateJobCat);
           }
       }
       // This Method checks job category name in the database for duplication.
       public string CheckJobCatName(classEntityLayerJobCategory objEntityJobCat)
       {

           string strQueryCheckCatName = "JOB_CATEGORY_MASTER.SP_CHECK_JOB_CAT_NAME";
           OracleCommand cmdCheckJobName = new OracleCommand();
           cmdCheckJobName.CommandText = strQueryCheckCatName;
           cmdCheckJobName.CommandType = CommandType.StoredProcedure;
           cmdCheckJobName.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobCat.JobCatId;
           cmdCheckJobName.Parameters.Add("J_NAME", OracleDbType.Varchar2).Value = objEntityJobCat.JobCatname;
           cmdCheckJobName.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobCat.CorpOffice_Id;
           cmdCheckJobName.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobCat.Organisation_Id;
           cmdCheckJobName.Parameters.Add("J_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckJobName);
           string strReturn = cmdCheckJobName.Parameters["J_COUNT"].Value.ToString();
           cmdCheckJobName.Dispose();
           return strReturn;
       }

       //Method for cancel job category
       public void CancelJobCategory(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryCancelJobCat = "JOB_CATEGORY_MASTER.SP_CANCEL_JOB_CAT";
           using (OracleCommand cmdCancelJobCat = new OracleCommand())
           {
               cmdCancelJobCat.CommandText = strQueryCancelJobCat;
               cmdCancelJobCat.CommandType = CommandType.StoredProcedure;
               cmdCancelJobCat.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobCat.JobCatId;
               cmdCancelJobCat.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityJobCat.User_Id;
               cmdCancelJobCat.Parameters.Add("J_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               cmdCancelJobCat.Parameters.Add("J_REASON", OracleDbType.Varchar2).Value = objEntityJobCat.Cancel_reason;
               clsDataLayer.ExecuteNonQuery(cmdCancelJobCat);
           }
       }
       //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
       public void ReCallJobCategory(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryRecallJob = "JOB_CATEGORY_MASTER.SP_RECALL_JOB_CAT";
           OracleCommand cmdRecallJob = new OracleCommand();
           cmdRecallJob.CommandText = strQueryRecallJob;
           cmdRecallJob.CommandType = CommandType.StoredProcedure;
           cmdRecallJob.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobCat.JobCatId;
           cmdRecallJob.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityJobCat.User_Id;
           cmdRecallJob.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityJobCat.D_Date;
           clsDataLayer.ExecuteNonQuery(cmdRecallJob);
       }
       // This Method will fetCH job category DEATILS BY ID
       public DataTable ReadJobCategryById(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryReadJobCatgry = "JOB_CATEGORY_MASTER.SP_READ_JOB_CAT_BY_ID";
           OracleCommand cmdReadJobCatgry = new OracleCommand();
           cmdReadJobCatgry.CommandText = strQueryReadJobCatgry;
           cmdReadJobCatgry.CommandType = CommandType.StoredProcedure;
           cmdReadJobCatgry.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityJobCat.JobCatId;
           cmdReadJobCatgry.Parameters.Add("J_ACCOMDETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJobCatgry);
           return dtCategory;
       }
       // This Method will fetch job category list
       public DataTable ReadJobCtgryList(classEntityLayerJobCategory objEntityJobCat)
       {
           string strQueryReadJobList = "JOB_CATEGORY_MASTER.SP_READ_JOB_CAT_LIST";
           OracleCommand cmdReadJobList = new OracleCommand();
           cmdReadJobList.CommandText = strQueryReadJobList;
           cmdReadJobList.CommandType = CommandType.StoredProcedure;
           cmdReadJobList.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityJobCat.Organisation_Id;
           cmdReadJobList.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityJobCat.CorpOffice_Id;
           cmdReadJobList.Parameters.Add("J_OPTION", OracleDbType.Int32).Value = objEntityJobCat.JobCat_Status;
           cmdReadJobList.Parameters.Add("J_CANCEL", OracleDbType.Int32).Value = objEntityJobCat.Cancel_Status;
           cmdReadJobList.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategoryList = new DataTable();
           dtCategoryList = clsDataLayer.ExecuteReader(cmdReadJobList);
           return dtCategoryList;
       }
    }
}
