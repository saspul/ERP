using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLeaveApplicationStatusReport
    {

        public DataTable LoadLeaveType(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_LEAVETYP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadDepartment(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_DEPARTMENT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadDivison(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_DIVISION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable LoadJob(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_JOB";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryTypeList(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_SUMMARY_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityBulkPrint.FromDate;
            cmdReadPayGrd.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityBulkPrint.Todate;
            if (objEntityBulkPrint.LeaveTypeId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_LEAVE_TYPE", OracleDbType.Varchar2).Value = objEntityBulkPrint.LeaveTypeId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_LEAVE_TYPE", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPARTMENT", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPARTMENT", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DIVISION", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIVISION", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            if (objEntityBulkPrint.JobId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_JOB", OracleDbType.Varchar2).Value = objEntityBulkPrint.JobId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_JOB", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.Status != "")
            {
                cmdReadPayGrd.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Status;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_SUMMARY_TYPE", OracleDbType.Int32).Value = objEntityBulkPrint.SummaryTypeId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryTypeListSingle(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_SUMMARY_LIST_IND";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityBulkPrint.FromDate;
            cmdReadPayGrd.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityBulkPrint.Todate;
            if (objEntityBulkPrint.LeaveTypeId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_LEAVE_TYPE", OracleDbType.Varchar2).Value = objEntityBulkPrint.LeaveTypeId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_LEAVE_TYPE", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPARTMENT", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPARTMENT", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DIVISION", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIVISION", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            if (objEntityBulkPrint.JobId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_JOB", OracleDbType.Varchar2).Value = objEntityBulkPrint.JobId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_JOB", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.Status != "")
            {
                cmdReadPayGrd.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Status;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_SUMMARY_TYPE", OracleDbType.Int32).Value = objEntityBulkPrint.SummaryTypeId;
            cmdReadPayGrd.Parameters.Add("P_SUMMARY_TYPE_IND", OracleDbType.Int32).Value = objEntityBulkPrint.SummaryTypeIdInd;
            cmdReadPayGrd.Parameters.Add("P_QUERY_COLS", OracleDbType.Varchar2).Value = objEntityBulkPrint.QueryColumns;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadSummaryLeaveDtls(clsEntityLeaveApplicationStatusReport objEntityBulkPrint)
        {
            string strQueryReadPayGrd = "LEAVE_APPLICATION_STS_REPORT.SP_READ_SUMMARY_LEAVE_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityBulkPrint.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityBulkPrint.CorpId;
            cmdReadPayGrd.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntityBulkPrint.FromDate;
            cmdReadPayGrd.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityBulkPrint.Todate;
            if (objEntityBulkPrint.LeaveTypeId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_LEAVE_TYPE", OracleDbType.Varchar2).Value = objEntityBulkPrint.LeaveTypeId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_LEAVE_TYPE", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DepartmentId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DEPARTMENT", OracleDbType.Varchar2).Value = objEntityBulkPrint.DepartmentId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DEPARTMENT", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.DivisionId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_DIVISION", OracleDbType.Varchar2).Value = objEntityBulkPrint.DivisionId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_DIVISION", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_CATEGORY", OracleDbType.Int32).Value = objEntityBulkPrint.CategoryId;
            if (objEntityBulkPrint.JobId != "")
            {
                cmdReadPayGrd.Parameters.Add("P_JOB", OracleDbType.Varchar2).Value = objEntityBulkPrint.JobId;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_JOB", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            if (objEntityBulkPrint.Status != "")
            {
                cmdReadPayGrd.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = objEntityBulkPrint.Status;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_SUMMARY_TYPE", OracleDbType.Int32).Value = objEntityBulkPrint.SummaryTypeId;
            if (objEntityBulkPrint.SummaryTypeIdInd != -1)
            {
                cmdReadPayGrd.Parameters.Add("P_SUMMARY_TYPE_IND", OracleDbType.Int32).Value = objEntityBulkPrint.SummaryTypeIdInd;
            }
            else
            {
                cmdReadPayGrd.Parameters.Add("P_SUMMARY_TYPE_IND", OracleDbType.Int32).Value = DBNull.Value;
            }
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
    }
}
