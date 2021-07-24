using System;
using System.Text;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;

// CREATED BY:EVM-0001
// CREATED DATE:22/02/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerApproval
    {
        // This Method for fetch the approval pending organisations details from parking table.
        public DataTable Approval_Pending()
        {
            string strCommandText = "APPROVAL_PENDING.SP_READ_APPROVAL_PENDING";
            using (OracleCommand cmdAprvlPen = new OracleCommand())
            {
                cmdAprvlPen.CommandText = strCommandText;
                cmdAprvlPen.CommandType = CommandType.StoredProcedure;
                cmdAprvlPen.Parameters.Add("O_APPROVAL_PENDING", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtAprvlPen = new DataTable();
                dtAprvlPen = clsDataLayer.SelectDataTable(cmdAprvlPen);
                return dtAprvlPen;
            }
        }

        // This Method for fetch the organisation details for approve/reject.
        public DataTable Select_Organisation(clsEntityLayerApproval objEntityApproval)
        {
            string strCommandText = "APPROVAL_PENDING.SP_READ_APPROVAL_SELECTED";
            using (OracleCommand cmdOrg = new OracleCommand())
            {
                cmdOrg.CommandText = strCommandText;
                cmdOrg.CommandType = CommandType.StoredProcedure;
                cmdOrg.Parameters.Add("O_ID", OracleDbType.Int32).Value = objEntityApproval.Park_id;
                cmdOrg.Parameters.Add("O_APPROVAL_PENDING", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtOrg = new DataTable();
                dtOrg = clsDataLayer.SelectDataTable(cmdOrg);
                return dtOrg;
            }
        }

        //Method for updating status of organization in parking table.
        public void Update_Organisation(clsEntityLayerApproval objEntityApproval)
        {
            string strCommandText = "APPROVAL_PENDING.SP_UPDATE_STATUS";
            using (OracleCommand cmdStatus = new OracleCommand())
            {
                cmdStatus.CommandText = strCommandText;
                cmdStatus.CommandType = CommandType.StoredProcedure;
                cmdStatus.Parameters.Add("O_ID", OracleDbType.Int32).Value = objEntityApproval.Park_id;
                cmdStatus.Parameters.Add("O_STATUS", OracleDbType.Int32).Value = objEntityApproval.Status;
                cmdStatus.Parameters.Add("O_DATE", OracleDbType.Date).Value = objEntityApproval.Date_Update;
                cmdStatus.Parameters.Add("O_USERID", OracleDbType.Int32).Value = objEntityApproval.UserId;
                clsDataLayer.ExecuteNonQuery(cmdStatus);
            }
        }

        //Method for updating status of organization to rejection in parking table.
        public void Reject_Organisation(clsEntityLayerApproval objEntityApproval)
        {
            string strCommandText = "APPROVAL_PENDING.SP_REJECT_STATUS";
            using (OracleCommand cmdStatus = new OracleCommand())
            {
                cmdStatus.CommandText = strCommandText;
                cmdStatus.CommandType = CommandType.StoredProcedure;
                cmdStatus.Parameters.Add("O_ID", OracleDbType.Int32).Value = objEntityApproval.Park_id;
                cmdStatus.Parameters.Add("O_STATUS", OracleDbType.Int32).Value = objEntityApproval.Status;
                cmdStatus.Parameters.Add("O_DATE", OracleDbType.Date).Value = objEntityApproval.Date_Update;
                cmdStatus.Parameters.Add("O_USERID", OracleDbType.Int32).Value = objEntityApproval.UserId;
                cmdStatus.Parameters.Add("O_REASON", OracleDbType.Varchar2).Value = objEntityApproval.Reason;
                clsDataLayer.ExecuteNonQuery(cmdStatus);
            }
        }
    }
}
