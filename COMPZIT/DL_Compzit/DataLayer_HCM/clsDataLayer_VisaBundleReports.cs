using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_VisaBundleReports
    {
        
        public DataTable ReadVisaQuota(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            string strQueryReadVisaQuota = "HCM_REPORTS.SP_READ_VISA_QUOTA";
            OracleCommand cmdReadVisaQuota = new OracleCommand();
            cmdReadVisaQuota.CommandText = strQueryReadVisaQuota;
            cmdReadVisaQuota.CommandType = CommandType.StoredProcedure;
            cmdReadVisaQuota.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.UserId;
            cmdReadVisaQuota.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.OrgId;
            cmdReadVisaQuota.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.CorpId;
            if (objEntityLayerVisaBundle.FrmDate != DateTime.MinValue)
            {
                cmdReadVisaQuota.Parameters.Add("P_FRMDATE", OracleDbType.Date).Value = objEntityLayerVisaBundle.FrmDate;
            }
            else
            {
                cmdReadVisaQuota.Parameters.Add("P_FRMDATE", OracleDbType.Date).Value = null;
            }
            if (objEntityLayerVisaBundle.ToDate != DateTime.MinValue)
            {
                cmdReadVisaQuota.Parameters.Add("P_TODATE", OracleDbType.Date).Value = objEntityLayerVisaBundle.ToDate;
            }
            else
            {
                cmdReadVisaQuota.Parameters.Add("P_TODATE", OracleDbType.Date).Value = null;
            }
            cmdReadVisaQuota.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVisaQuota = new DataTable();
            dtVisaQuota = clsDataLayer.ExecuteReader(cmdReadVisaQuota);
            return dtVisaQuota;
        }


        public DataTable ReadVisaQuotaById(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            string strQueryReadVisaQuotaById = "HCM_REPORTS.SP_READ_VISAQUOTA_BYID";
            OracleCommand cmdReadVisaQuotaById = new OracleCommand();
            cmdReadVisaQuotaById.CommandText = strQueryReadVisaQuotaById;
            cmdReadVisaQuotaById.CommandType = CommandType.StoredProcedure;
            cmdReadVisaQuotaById.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.VisaQuotaId;
            cmdReadVisaQuotaById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.UserId;
            cmdReadVisaQuotaById.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.OrgId;
            cmdReadVisaQuotaById.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.CorpId;
            cmdReadVisaQuotaById.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVisaQuotaId = new DataTable();
            dtVisaQuotaId = clsDataLayer.ExecuteReader(cmdReadVisaQuotaById);
            return dtVisaQuotaId;
        }



        public DataTable ReadVisaDetailsById(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            string strQueryReadVisaDtls = "HCM_REPORTS.SP_READ_VISA_DETAILS_BYID";
            OracleCommand cmdReadVisaDtls = new OracleCommand();
            cmdReadVisaDtls.CommandText = strQueryReadVisaDtls;
            cmdReadVisaDtls.CommandType = CommandType.StoredProcedure;
            cmdReadVisaDtls.Parameters.Add("P_VISAQUOTA_ID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.VisaQuotaId;
            cmdReadVisaDtls.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.UserId;
            cmdReadVisaDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.OrgId;
            cmdReadVisaDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.CorpId;
            cmdReadVisaDtls.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVisaDtls = new DataTable();
            dtVisaDtls = clsDataLayer.ExecuteReader(cmdReadVisaDtls);
            return dtVisaDtls;
        }


        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityVisaBundleReports objEntityLayerVisaBundle)
        {
            string strQueryReadCorp = "HCM_REPORTS.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.OrgId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerVisaBundle.CorpId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }
















    }
}
