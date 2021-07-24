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
  public  class clsDataLayerJobMaster
  {
      clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
      // This Method adds job details to the table
      public void AddJobDetails(clsEntityLayerJobMaster objJob)
      {
          string strQueryAddJobDetails = "JOB_MASTER.SP_INSERT_JOB_DETAILS";
          using (OracleCommand cmdAddJobDetails = new OracleCommand())
          {
              cmdAddJobDetails.CommandText = strQueryAddJobDetails;
              cmdAddJobDetails.CommandType = CommandType.StoredProcedure;
              cmdAddJobDetails.Parameters.Add("J_TITLE", OracleDbType.Varchar2).Value = objJob.JobTitle;
              cmdAddJobDetails.Parameters.Add("J_DESC", OracleDbType.Varchar2).Value = objJob.JobDescription;
              cmdAddJobDetails.Parameters.Add("J_STATUS", OracleDbType.Int32).Value = objJob.Status_id;
              cmdAddJobDetails.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objJob.Organisation_id;
              cmdAddJobDetails.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objJob.Corporate_id;
              cmdAddJobDetails.Parameters.Add("J_INSUSERID", OracleDbType.Int32).Value = objJob.User_Id;
              clsDataLayer.ExecuteNonQuery(cmdAddJobDetails);
          }
      }
      // This Method update job details to the table
      public void UpdateJobDetails(clsEntityLayerJobMaster objJob)
      {
          string strQueryUpdateJobDetails = "JOB_MASTER.SP_UPD_JOB_DETAILS";
          using (OracleCommand cmdUpdateJobDetails = new OracleCommand())
          {
              cmdUpdateJobDetails.CommandText = strQueryUpdateJobDetails;
              cmdUpdateJobDetails.CommandType = CommandType.StoredProcedure;

              cmdUpdateJobDetails.Parameters.Add("J_ID", OracleDbType.Varchar2).Value = objJob.JobId;
              cmdUpdateJobDetails.Parameters.Add("J_TITLE", OracleDbType.Varchar2).Value = objJob.JobTitle;
              cmdUpdateJobDetails.Parameters.Add("J_DESC", OracleDbType.Varchar2).Value = objJob.JobDescription;
              cmdUpdateJobDetails.Parameters.Add("J_STATUS", OracleDbType.Int32).Value = objJob.Status_id;
              cmdUpdateJobDetails.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objJob.Organisation_id;
              cmdUpdateJobDetails.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objJob.Corporate_id;
              cmdUpdateJobDetails.Parameters.Add("J_UPDUSERID", OracleDbType.Int32).Value = objJob.User_Id;
              cmdUpdateJobDetails.Parameters.Add("J_UPDATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
              clsDataLayer.ExecuteNonQuery(cmdUpdateJobDetails);
          }
      }
      // This Method checks Job details in the database for duplication.
      public string CheckJobTitle(clsEntityLayerJobMaster objJob)
      {

          string strQueryCheckJobTitle = "JOB_MASTER.SP_CHECK_JOB_TITLE";
          OracleCommand cmdCheckJobTitle = new OracleCommand();
          cmdCheckJobTitle.CommandText = strQueryCheckJobTitle;
          cmdCheckJobTitle.CommandType = CommandType.StoredProcedure;
          cmdCheckJobTitle.Parameters.Add("J_ID", OracleDbType.Int32).Value = objJob.JobId;
          cmdCheckJobTitle.Parameters.Add("J_TITLE", OracleDbType.Varchar2).Value = objJob.JobTitle;
          cmdCheckJobTitle.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objJob.Corporate_id;
          cmdCheckJobTitle.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objJob.Organisation_id;
          cmdCheckJobTitle.Parameters.Add("J_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
          clsDataLayer.ExecuteScalar(ref cmdCheckJobTitle);
          string strReturn = cmdCheckJobTitle.Parameters["J_COUNT"].Value.ToString();
          cmdCheckJobTitle.Dispose();
          return strReturn;
      }
      //Method for cancel Job title
      public void CancelJobTitle(clsEntityLayerJobMaster objJob)
      {
          string strQueryCancelJobTitle = "JOB_MASTER.SP_CANCEL_JOB_DETAILS";
          using (OracleCommand cmdCancelJobTitle = new OracleCommand())
          {
              cmdCancelJobTitle.CommandText = strQueryCancelJobTitle;
              cmdCancelJobTitle.CommandType = CommandType.StoredProcedure;
              cmdCancelJobTitle.Parameters.Add("J_ID", OracleDbType.Int32).Value = objJob.JobId;
              cmdCancelJobTitle.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objJob.User_Id;
              cmdCancelJobTitle.Parameters.Add("J_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
              cmdCancelJobTitle.Parameters.Add("J_REASON", OracleDbType.Varchar2).Value = objJob.CancelReason;
              clsDataLayer.ExecuteNonQuery(cmdCancelJobTitle);
          }
      }


      // This Method will fetCH job DEATILS BY ID
      public DataTable ReadJobTitleById(clsEntityLayerJobMaster objJob)
      {
          string strQueryReadJobTitleById = "JOB_MASTER.SP_READ_JOB_DETAILS_BY_ID";
          OracleCommand cmdReadJobTitleById = new OracleCommand();
          cmdReadJobTitleById.CommandText = strQueryReadJobTitleById;
          cmdReadJobTitleById.CommandType = CommandType.StoredProcedure;
          cmdReadJobTitleById.Parameters.Add("J_ID", OracleDbType.Int32).Value = objJob.JobId;
          cmdReadJobTitleById.Parameters.Add(" J_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadJobTitleById);
          return dtCategory;
      }
      // This Method will fetch job list
      public DataTable ReadJobTitleList(clsEntityLayerJobMaster objJob)
      {
          string strQueryReadJobTitleList = "JOB_MASTER.SP_READ_JOB_DETAILS_LIST";
          OracleCommand cmdReadJobTitleList = new OracleCommand();
          cmdReadJobTitleList.CommandText = strQueryReadJobTitleList;
          cmdReadJobTitleList.CommandType = CommandType.StoredProcedure;
          cmdReadJobTitleList.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objJob.Organisation_id;
          cmdReadJobTitleList.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objJob.Corporate_id;
          cmdReadJobTitleList.Parameters.Add("J_OPTION", OracleDbType.Int32).Value = objJob.Status_id;
          cmdReadJobTitleList.Parameters.Add("J_CANCEL", OracleDbType.Int32).Value = objJob.CancelStatus;
          //------------------------------------------Pagination------------------------------------------------
          cmdReadJobTitleList.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objJob.CommonSearchTerm;
          cmdReadJobTitleList.Parameters.Add("P_SEARCH_NAME", OracleDbType.Varchar2).Value = objJob.SearchName;
          cmdReadJobTitleList.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objJob.OrderColumn;
          cmdReadJobTitleList.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objJob.OrderMethod;
          cmdReadJobTitleList.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objJob.PageMaxSize;
          cmdReadJobTitleList.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objJob.PageNumber;
          //------------------------------------------Pagination------------------------------------------------
          cmdReadJobTitleList.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategoryList = new DataTable();
          dtCategoryList = clsDataLayer.ExecuteReader(cmdReadJobTitleList);
          return dtCategoryList;
      }

      //Method for recall job
      public void ReCalljob(clsEntityLayerJobMaster objJob)
      {
          string strQueryReCalljob = "JOB_MASTER.SP_RECALL_JOB";
          using (OracleCommand cmdReCalljob = new OracleCommand())
          {
              cmdReCalljob.CommandText = strQueryReCalljob;
              cmdReCalljob.CommandType = CommandType.StoredProcedure;
              cmdReCalljob.Parameters.Add("J_ID", OracleDbType.Int32).Value = objJob.JobId;
              cmdReCalljob.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objJob.User_Id;
              cmdReCalljob.Parameters.Add("J_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
              clsDataLayer.ExecuteNonQuery(cmdReCalljob);
          }
      }

      public void ChangeStatus(clsEntityLayerJobMaster objJob)
      {
          string strQueryRead = "JOB_MASTER.SP_STATUS_CHANGE";
          OracleCommand cmdSts = new OracleCommand();
          cmdSts.CommandText = strQueryRead;
          cmdSts.CommandType = CommandType.StoredProcedure;
          cmdSts.Parameters.Add("P_ID", OracleDbType.Int32).Value = objJob.JobId;
          cmdSts.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objJob.Status_id;
          clsDataLayer.ExecuteNonQuery(cmdSts);
      }



  }
}

