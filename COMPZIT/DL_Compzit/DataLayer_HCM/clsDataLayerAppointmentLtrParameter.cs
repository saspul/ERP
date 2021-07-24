using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerAppointmentLtrParameter
    {
        // This Method adds ApptLetterParameter details to the database
        public void AddApptLetterParameterMstr(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            string strQueryAddApptLetterParameterMstr = "HCM_APPOINTMENT_LTR_PARAMETER.SP_INSERT_HCM_APPT_LTR_PARAM";
            using (OracleCommand cmdAddApptLetterParameterMstr = new OracleCommand())
            {
                cmdAddApptLetterParameterMstr.CommandText = strQueryAddApptLetterParameterMstr;
                cmdAddApptLetterParameterMstr.CommandType = CommandType.StoredProcedure;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_APPT_HEAD", OracleDbType.Varchar2).Value = objEntityApptLtrParam.Head;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_APPT_ADDR", OracleDbType.Varchar2).Value = objEntityApptLtrParam.Description;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_APPT_STATUS", OracleDbType.Int32).Value = objEntityApptLtrParam.Status;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.OrgId;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.CorpId;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_APPT_INS_USR_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.UserId;
                cmdAddApptLetterParameterMstr.Parameters.Add("C_APPT_INS_DATE", OracleDbType.Date).Value = objEntityApptLtrParam.Date;
                clsDataLayer.ExecuteNonQuery(cmdAddApptLetterParameterMstr);
            }
        }
        // This Method checks ApptLetterParameter Name in the database for duplication (FOR UPDATE AND INSERT)
        public string CheckDupApptLetterParameterName(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            string strQueryCheckApptLetterParameterName = "HCM_APPOINTMENT_LTR_PARAMETER.SP_CHECK_HCM_APPT_LTR_PARAM";
            OracleCommand cmdCheckApptLetterParameterName = new OracleCommand();
            cmdCheckApptLetterParameterName.CommandText = strQueryCheckApptLetterParameterName;
            cmdCheckApptLetterParameterName.CommandType = CommandType.StoredProcedure;
            if (objEntityApptLtrParam.ApptLtrParameterId == 0)
            {
                cmdCheckApptLetterParameterName.Parameters.Add("C_APPT_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdCheckApptLetterParameterName.Parameters.Add("C_APPT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.ApptLtrParameterId;
            }
            cmdCheckApptLetterParameterName.Parameters.Add("C_APPT_HEAD", OracleDbType.Varchar2).Value = objEntityApptLtrParam.Head;
            cmdCheckApptLetterParameterName.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.OrgId;
            cmdCheckApptLetterParameterName.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.CorpId;
            cmdCheckApptLetterParameterName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckApptLetterParameterName);
            string strReturn = cmdCheckApptLetterParameterName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckApptLetterParameterName.Dispose();
            return strReturn;

        }
        //Read ApptLetterParameter list 
        public DataTable ReadApptLetterParameterList(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            DataTable dtApptLetterParameterList = new DataTable();
            using (OracleCommand cmdReadApptLetterParameterList = new OracleCommand())
            {
                cmdReadApptLetterParameterList.CommandText = "HCM_APPOINTMENT_LTR_PARAMETER.SP_READ_HCM_APPT_LTR_PARAM";
                cmdReadApptLetterParameterList.CommandType = CommandType.StoredProcedure;
                cmdReadApptLetterParameterList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityApptLtrParam.Status;
                cmdReadApptLetterParameterList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityApptLtrParam.CancelStatus;
                cmdReadApptLetterParameterList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityApptLtrParam.OrgId;
                cmdReadApptLetterParameterList.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.CorpId;
                cmdReadApptLetterParameterList.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtApptLetterParameterList = clsDataLayer.SelectDataTable(cmdReadApptLetterParameterList);
            }
            return dtApptLetterParameterList;
        }
        //Read ApptLetterParameter DETAIL 
        public DataTable ReadApptLetterParameterByID(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            DataTable dtApptLetterParameterDetails = new DataTable();
            using (OracleCommand cmdReadApptLetterParameterDetails = new OracleCommand())
            {
                cmdReadApptLetterParameterDetails.CommandText = "HCM_APPOINTMENT_LTR_PARAMETER.SP_RD_HCM_APPT_LTR_PARAM_BYID";
                cmdReadApptLetterParameterDetails.CommandType = CommandType.StoredProcedure;
                cmdReadApptLetterParameterDetails.Parameters.Add("C_APPT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.ApptLtrParameterId;
                cmdReadApptLetterParameterDetails.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityApptLtrParam.OrgId;
                cmdReadApptLetterParameterDetails.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.CorpId;
                cmdReadApptLetterParameterDetails.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtApptLetterParameterDetails = clsDataLayer.SelectDataTable(cmdReadApptLetterParameterDetails);
            }
            return dtApptLetterParameterDetails;
        }
        // This Method update ApptLetterParameter details 
        public void UpdateApptLetterParameterMstr(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            string strQueryUpdateApptLetterParameter = "HCM_APPOINTMENT_LTR_PARAMETER.SP_UPD_HCM_APPT_LTR_PARAM";
            using (OracleCommand cmdUpdateApptLetterParameter = new OracleCommand())
            {
                cmdUpdateApptLetterParameter.CommandText = strQueryUpdateApptLetterParameter;
                cmdUpdateApptLetterParameter.CommandType = CommandType.StoredProcedure;
                cmdUpdateApptLetterParameter.Parameters.Add("C_APPT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.ApptLtrParameterId;
                cmdUpdateApptLetterParameter.Parameters.Add("C_APPT_HEAD", OracleDbType.Varchar2).Value = objEntityApptLtrParam.Head;
                cmdUpdateApptLetterParameter.Parameters.Add("C_APPT_ADDR", OracleDbType.Varchar2).Value = objEntityApptLtrParam.Description;
                cmdUpdateApptLetterParameter.Parameters.Add("C_APPT_STATUS", OracleDbType.Int32).Value = objEntityApptLtrParam.Status;
                cmdUpdateApptLetterParameter.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.OrgId;
                cmdUpdateApptLetterParameter.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.CorpId;
                cmdUpdateApptLetterParameter.Parameters.Add("C_APPT_UPD_USR_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.UserId;
                cmdUpdateApptLetterParameter.Parameters.Add("C_APPT_UPD_DATE", OracleDbType.Date).Value = objEntityApptLtrParam.Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateApptLetterParameter);
            }
        }
        // This Method delete ApptLetterParameter details 
        public void CancelApptLetterParameterMstr(clsEntityAppointmentLtrParameter objEntityApptLtrParam)
        {
            string strQueryCancelApptLetterParameter = "HCM_APPOINTMENT_LTR_PARAMETER.SP_CANCEL_HCM_APPT_LTR_PARAM";
            using (OracleCommand cmdCancelApptLetterParameter = new OracleCommand())
            {
                cmdCancelApptLetterParameter.CommandText = strQueryCancelApptLetterParameter;
                cmdCancelApptLetterParameter.CommandType = CommandType.StoredProcedure;
                cmdCancelApptLetterParameter.Parameters.Add("C_APPT_ID", OracleDbType.Int32).Value = objEntityApptLtrParam.ApptLtrParameterId;
                cmdCancelApptLetterParameter.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityApptLtrParam.UserId;
                cmdCancelApptLetterParameter.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityApptLtrParam.Date;
                cmdCancelApptLetterParameter.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityApptLtrParam.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelApptLetterParameter);
            }
        }
   
    }
}
