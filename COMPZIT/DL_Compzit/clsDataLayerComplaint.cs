using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:02/11/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
   public class clsDataLayerComplaint
    {


        //Method for read Complaint Category for set dropdownlist
        public DataTable ReadComplaintCtgry(clsEntityComplaint objEntityComplaint)
        {
            string strQueryComplaintCtgry = "COMPLAINT_MSTR.SP_READ_CMPLNT_CTGRY";
            using (OracleCommand cmdComplaintCtgry = new OracleCommand())
            {
                cmdComplaintCtgry.CommandText = strQueryComplaintCtgry;
                cmdComplaintCtgry.CommandType = CommandType.StoredProcedure;
                cmdComplaintCtgry.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdComplaintCtgry);
                return dtResultSet;
            }
        }

        //Method for check Complaint Description already exist in the table or not.
        public string CheckComplaintDesc(clsEntityComplaint objEntityComplaint)
        {
            string strQueryCheckComplaintName = "COMPLAINT_MSTR.SP_CHECK_COMPLAINTDESC";
            OracleCommand cmdCheckComplaintName = new OracleCommand();
            cmdCheckComplaintName.CommandText = strQueryCheckComplaintName;
            cmdCheckComplaintName.CommandType = CommandType.StoredProcedure;
            cmdCheckComplaintName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Master_Id;
            cmdCheckComplaintName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityComplaint.Organisation_Id;
            cmdCheckComplaintName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityComplaint.CorpOffice_Id;
            cmdCheckComplaintName.Parameters.Add("C_DESC", OracleDbType.Varchar2).Value = objEntityComplaint.ComplaintDesc;
            cmdCheckComplaintName.Parameters.Add("C_CTGRYID", OracleDbType.Int32).Value = objEntityComplaint.CtgryId;
            cmdCheckComplaintName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckComplaintName);
            string strReturnCount = cmdCheckComplaintName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckComplaintName.Dispose();
            return strReturnCount; ;
        }
        //Method for inserting data about Complaints to the Complaint master table
        public void Insert_Complaint(clsEntityComplaint objEntityComplaint)
        {
            string strQueryInsertComplaint = "COMPLAINT_MSTR.SP_INSERT_CMPLNT";
            OracleCommand cmdInsertComplaint = new OracleCommand();
            cmdInsertComplaint.CommandText = strQueryInsertComplaint;
            cmdInsertComplaint.CommandType = CommandType.StoredProcedure;
            cmdInsertComplaint.Parameters.Add("C_DESC", OracleDbType.Varchar2).Value = objEntityComplaint.ComplaintDesc;
            cmdInsertComplaint.Parameters.Add("C_CTGRYID", OracleDbType.Int32).Value = objEntityComplaint.CtgryId;         
             cmdInsertComplaint.Parameters.Add("C_PENALTY", OracleDbType.Decimal).Value = objEntityComplaint.Penalty;          
             cmdInsertComplaint.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Status;
            cmdInsertComplaint.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityComplaint.Organisation_Id;
            cmdInsertComplaint.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityComplaint.CorpOffice_Id;
            cmdInsertComplaint.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityComplaint.User_Id;
            cmdInsertComplaint.Parameters.Add("C_INSDATE", OracleDbType.Date).Value = objEntityComplaint.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdInsertComplaint);
        }
        //Method for read Complaint for list view.
        public DataTable ReadComplaintList(clsEntityComplaint objEntityComplaint)
        {
            string strQueryReadComplaintList = "COMPLAINT_MSTR.SP_READ_COMPLAINTLIST";
            using (OracleCommand cmdReadComplaintList = new OracleCommand())
            {
                cmdReadComplaintList.CommandText = strQueryReadComplaintList;
                cmdReadComplaintList.CommandType = CommandType.StoredProcedure;
                cmdReadComplaintList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityComplaint.Organisation_Id;
                cmdReadComplaintList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityComplaint.CorpOffice_Id;
                cmdReadComplaintList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Status;
                cmdReadComplaintList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityComplaint.Cancel_Status;
                cmdReadComplaintList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityComplaint.CommonSearchTerm;
                cmdReadComplaintList.Parameters.Add("M_SEARCH_COMPLAINT", OracleDbType.Varchar2).Value = objEntityComplaint.SearchComplaint;
                cmdReadComplaintList.Parameters.Add("M_SEARCH_CATEGORY", OracleDbType.Varchar2).Value = objEntityComplaint.SearchCategory;
                cmdReadComplaintList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityComplaint.OrderColumn;
                cmdReadComplaintList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityComplaint.OrderMethod;
                cmdReadComplaintList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityComplaint.PageMaxSize;
                cmdReadComplaintList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityComplaint.PageNumber;
                cmdReadComplaintList.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadComplaintList);
                return dtResultSet;
            }
        }
      

        //Method for read Complaint by their id.
        public DataTable ReadComplaintById(clsEntityComplaint objEntityComplaint)
        {
            string strQueryReadComplaintListById = "COMPLAINT_MSTR.SP_READ_COMPLAINT_BYID";
            using (OracleCommand cmdReadComplaintListById = new OracleCommand())
            {
                cmdReadComplaintListById.CommandText = strQueryReadComplaintListById;
                cmdReadComplaintListById.CommandType = CommandType.StoredProcedure;
                cmdReadComplaintListById.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Master_Id;
                cmdReadComplaintListById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityComplaint.CorpOffice_Id;
                cmdReadComplaintListById.Parameters.Add("C_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtResultSet = new DataTable();
                dtResultSet = clsDataLayer.SelectDataTable(cmdReadComplaintListById);
                return dtResultSet;
            }
        }
        //Method for Updating data about Complaint to the Complaint master table
        public void Update_Complaint(clsEntityComplaint objEntityComplaint)
        {
            string strQueryUpdateComplaint = "COMPLAINT_MSTR.SP_UPDATE_CMPLNT";
            OracleCommand cmdUpdateComplaint = new OracleCommand();
            cmdUpdateComplaint.CommandText = strQueryUpdateComplaint;
            cmdUpdateComplaint.CommandType = CommandType.StoredProcedure;
            cmdUpdateComplaint.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Master_Id;
            cmdUpdateComplaint.Parameters.Add("C_DESC", OracleDbType.Varchar2).Value = objEntityComplaint.ComplaintDesc;
            cmdUpdateComplaint.Parameters.Add("C_CTGRYID", OracleDbType.Int32).Value = objEntityComplaint.CtgryId;           
             cmdUpdateComplaint.Parameters.Add("C_PENALTY", OracleDbType.Decimal).Value = objEntityComplaint.Penalty;          
            cmdUpdateComplaint.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Status;
            cmdUpdateComplaint.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityComplaint.User_Id;
            cmdUpdateComplaint.Parameters.Add("C_UPDDATE", OracleDbType.Date).Value = objEntityComplaint.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateComplaint);
        }

      
        //Method for Cancel Complaint from Complaint master table so update cancel related fields
        public void Cancel_Complaint(clsEntityComplaint objEntityComplaint)
        {
            string strQueryCancelComplaint = "COMPLAINT_MSTR.SP_CANCEL_COMPLAINT";
            OracleCommand cmdCancelComplaint = new OracleCommand();
            cmdCancelComplaint.CommandText = strQueryCancelComplaint;
            cmdCancelComplaint.CommandType = CommandType.StoredProcedure;
            cmdCancelComplaint.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Master_Id;
            cmdCancelComplaint.Parameters.Add("C_CANCEL_USERID", OracleDbType.Int32).Value = objEntityComplaint.User_Id;
            cmdCancelComplaint.Parameters.Add("C_CANCEL_DATE", OracleDbType.Date).Value = objEntityComplaint.D_Date;
            cmdCancelComplaint.Parameters.Add("C_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityComplaint.Complaint_Cancel_reason;
            clsDataLayer.ExecuteNonQuery(cmdCancelComplaint);
        }

        //Method for Recall Cancelled Complaint from Complaint master table so update cancel related fields
        public void Recall_Complaint(clsEntityComplaint objEntityComplaint)
        {
            string strQueryRecallComplaint = "COMPLAINT_MSTR.SP_RECALL_COMPLAINT";
            OracleCommand cmdRecallComplaint = new OracleCommand();
            cmdRecallComplaint.CommandText = strQueryRecallComplaint;
            cmdRecallComplaint.CommandType = CommandType.StoredProcedure;
            cmdRecallComplaint.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Master_Id;
            cmdRecallComplaint.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityComplaint.User_Id;
            cmdRecallComplaint.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityComplaint.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdRecallComplaint);
        }
        public void Update_Complaint_Status(clsEntityComplaint objEntityComplaint)
        {
            string strQueryUpdateComplaint = "COMPLAINT_MSTR.SP_UPDATE_CMPLNT_STS";
            OracleCommand cmdUpdateComplaint = new OracleCommand();
            cmdUpdateComplaint.CommandText = strQueryUpdateComplaint;
            cmdUpdateComplaint.CommandType = CommandType.StoredProcedure;
            cmdUpdateComplaint.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Master_Id;
            cmdUpdateComplaint.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityComplaint.Complaint_Status;
            cmdUpdateComplaint.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityComplaint.User_Id;
            cmdUpdateComplaint.Parameters.Add("C_UPDDATE", OracleDbType.Date).Value = objEntityComplaint.D_Date;
            clsDataLayer.ExecuteNonQuery(cmdUpdateComplaint);
        }
    }
}
