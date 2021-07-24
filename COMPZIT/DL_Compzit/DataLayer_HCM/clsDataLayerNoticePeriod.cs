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
    public class clsDataLayerNoticePeriod
    {

        public DataTable ReadDesgntn(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "NOTICE_PERIOD.SP_READ_DESG";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("N_ORG_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("N_CORPID", OracleDbType.Int32).Value = objEntityNoticePeriod.CorpId;
                cmdReadInterviewCatByID.Parameters.Add("N_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable CheckDuplctn(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "NOTICE_PERIOD.SP_CHK_DUPCTN";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("N_ORG_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("N_CORPID", OracleDbType.Int32).Value = objEntityNoticePeriod.CorpId;
                cmdReadInterviewCatByID.Parameters.Add("N_DESGID", OracleDbType.Int32).Value = objEntityNoticePeriod.DesgntnId;
                cmdReadInterviewCatByID.Parameters.Add("N_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdId;
                cmdReadInterviewCatByID.Parameters.Add("N_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable ReadNoticePrdList(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "NOTICE_PERIOD.SP_READ_LIST";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("N_ORG_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("N_CORPID", OracleDbType.Int32).Value = objEntityNoticePeriod.CorpId;
                cmdReadInterviewCatByID.Parameters.Add("N_STSID", OracleDbType.Int32).Value = objEntityNoticePeriod.Status;
                cmdReadInterviewCatByID.Parameters.Add("N_CNCLID", OracleDbType.Int32).Value = objEntityNoticePeriod.CancelStatus;
                cmdReadInterviewCatByID.Parameters.Add("N_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        public DataTable ReadNoticePrdDtlsById(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "NOTICE_PERIOD.SP_READ_DTLS_BY_ID";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("N_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdId;
                cmdReadInterviewCatByID.Parameters.Add("N_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }


        public void CancelNoticePrdDtls(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            string strQueryCancelCertificateBundel = "NOTICE_PERIOD.SP_CANCEL_DTL";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelCertificateBundel;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("N_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdId;
                cmdCancelInterviewCat.Parameters.Add("N_CNCL_DATE", OracleDbType.Date).Value = objEntityNoticePeriod.UserDate;
                cmdCancelInterviewCat.Parameters.Add("N_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityNoticePeriod.CnclReason;
                cmdCancelInterviewCat.Parameters.Add("N_USR_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.UserId;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }
        //status change InterviewCat 
        public void ChangeStatus(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            string strQueryCancelInterviewCat = "NOTICE_PERIOD.SP_STATUS_UPD";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("N_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdId;
                cmdCancelInterviewCat.Parameters.Add("N_UPD_DATE", OracleDbType.Date).Value = objEntityNoticePeriod.UserDate;
                cmdCancelInterviewCat.Parameters.Add("N_UPD_USR_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.UserId;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }


        public void AddNoticePrdDtls(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            string strQueryCancelInterviewCat = "NOTICE_PERIOD.SP_INS_NTCPRD_DTL";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("N_DESG_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.DesgntnId;
                cmdCancelInterviewCat.Parameters.Add("N_STATUS", OracleDbType.Int32).Value = objEntityNoticePeriod.Status;
                cmdCancelInterviewCat.Parameters.Add("N_DAYS", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdDays;
                cmdCancelInterviewCat.Parameters.Add("N_INS_DATE", OracleDbType.Date).Value = objEntityNoticePeriod.UserDate;
                cmdCancelInterviewCat.Parameters.Add("N_INS_USR_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.UserId;
                cmdCancelInterviewCat.Parameters.Add("N_ORGID", OracleDbType.Int32).Value = objEntityNoticePeriod.OrgId;
                cmdCancelInterviewCat.Parameters.Add("N_CORPID", OracleDbType.Int32).Value = objEntityNoticePeriod.CorpId;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }

        public void UpdateNoticePrd(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            string strQueryCancelInterviewCat = "NOTICE_PERIOD.SP_UPD_NTCPRD_DTL";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("N_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdId;
                cmdCancelInterviewCat.Parameters.Add("N_DESG_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.DesgntnId;
                cmdCancelInterviewCat.Parameters.Add("N_STATUS", OracleDbType.Int32).Value = objEntityNoticePeriod.Status;
                cmdCancelInterviewCat.Parameters.Add("N_DAYS", OracleDbType.Int32).Value = objEntityNoticePeriod.NoticePrdDays;
                cmdCancelInterviewCat.Parameters.Add("N_INS_DATE", OracleDbType.Date).Value = objEntityNoticePeriod.UserDate;
                cmdCancelInterviewCat.Parameters.Add("N_INS_USR_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.UserId;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }
        public DataTable CheckExtProcess(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "NOTICE_PERIOD.SP_CHK_EXT";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("N_ORG_ID", OracleDbType.Int32).Value = objEntityNoticePeriod.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("N_CORPID", OracleDbType.Int32).Value = objEntityNoticePeriod.CorpId;
                cmdReadInterviewCatByID.Parameters.Add("N_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }


        public DataTable ReadNoticePrdAllocationList(clsEntityLayerNoticePeriod objEntityNoticePeriod)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "NOTICE_PERIOD.SP_NOTICE_PRD_ALLCTN_LIST";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("D_TYPID", OracleDbType.Int32).Value = objEntityNoticePeriod.DesignationTypeId;
                cmdReadInterviewCatByID.Parameters.Add("D_ORGID", OracleDbType.Int32).Value = objEntityNoticePeriod.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("D_CONTROL", OracleDbType.Varchar2).Value = objEntityNoticePeriod.DsgControl;
                cmdReadInterviewCatByID.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }



    }
}
