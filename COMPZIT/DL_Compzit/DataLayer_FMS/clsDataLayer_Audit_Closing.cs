using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_Audit_Closing
    {
        public void InsertAuditClosing(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_INSERT_AUDIT_CLOSE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_CLOSE_DATE", OracleDbType.Date).Value = objEntity.FromDate;
                cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
                cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
                cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public DataTable ReadCloseDates(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_READ_CLS_DATE_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable CheckAuditClosingDate(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CHECK_AUDITCLS_DATE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntity.User_Id;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("FROM_DATE", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable CheckAuditClsDateCnclSts(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CHECK_AUDITCLS_CNCLSTS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ACCNTCLSID", OracleDbType.Int32).Value = objEntity.AuditClsId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public void CancelAuditClsDate(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CNCL_AUDIT_CLOSE_DATE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AuditClsId;
                cmdReadPayGrd.Parameters.Add("J_CNCL_REASON", OracleDbType.Varchar2).Value = objEntity.Cancel_Reason;
                cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntity.User_Id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public void ConfirmAuditClsDate(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CNFRM_AUDIT_CLOSE_DATE";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AuditClsId;
                cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntity.User_Id;
                cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
                cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }
        }
        public DataTable CheckAuditClsDateConfirmStatus(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CKECK_CNFRM_DATE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntity.AuditClsId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable CheckNonConfirmEntry(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CKECK_NON_CONFIRM";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable Read_Account_Close(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_READ_ACCOUNTCLOSE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable Read_Audit_Close(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_READ_AUDITCLOSE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable CheckYearEndClosingDate(clsEntityLayerAuditClosing objEntity)
        {
            string strQueryReadPayGrd = "FMS_AUDIT_CLOSE.SP_CHECK_YEAREND_CLSDATE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadPayGrd.Parameters.Add("P_FROM_DATE", OracleDbType.Date).Value = objEntity.FromDate;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }


    }
}
