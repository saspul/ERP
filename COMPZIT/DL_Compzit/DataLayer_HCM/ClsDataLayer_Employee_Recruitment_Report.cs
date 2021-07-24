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
    public class ClsDataLayer_Employee_Recruitment_Report
    {


        public DataTable ReadEmployeeRecruitment(ClsEntity_HCM_Common objEntityLayerHcmCommon)
        {
            string strQueryReadVisaQuota = "HCM_REPORTS.SP_READ_EMPLOYE_RECRU_RPT";
            OracleCommand cmdReadVisaQuota = new OracleCommand();
            cmdReadVisaQuota.CommandText = strQueryReadVisaQuota;
            cmdReadVisaQuota.CommandType = CommandType.StoredProcedure;

            cmdReadVisaQuota.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityLayerHcmCommon.OrgId;
            cmdReadVisaQuota.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityLayerHcmCommon.CorpId;
            cmdReadVisaQuota.Parameters.Add("E_FRMDATE", OracleDbType.Date).Value = objEntityLayerHcmCommon.FrmDate;
            cmdReadVisaQuota.Parameters.Add("E_TODATE", OracleDbType.Date).Value = objEntityLayerHcmCommon.ToDate;


            cmdReadVisaQuota.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVisaQuota = new DataTable();
            dtVisaQuota = clsDataLayer.ExecuteReader(cmdReadVisaQuota);
            return dtVisaQuota;
        }




        public DataTable ReadEmployeeRecruitmentById(ClsEntity_HCM_Common objEntityLayerHcmCommon)
        {
            string strQueryReadVisaDtls = "HCM_REPORTS.SP_READ_EMPLOYE_REC_BYID";
            OracleCommand cmdReadVisaDtls = new OracleCommand();
            cmdReadVisaDtls.CommandText = strQueryReadVisaDtls;
            cmdReadVisaDtls.CommandType = CommandType.StoredProcedure;


            cmdReadVisaDtls.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerHcmCommon.OrgId;
            cmdReadVisaDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerHcmCommon.CorpId;
            cmdReadVisaDtls.Parameters.Add("E_FRMDATE", OracleDbType.Date).Value = objEntityLayerHcmCommon.FrmDate;
            cmdReadVisaDtls.Parameters.Add("E_TODATE", OracleDbType.Date).Value = objEntityLayerHcmCommon.ToDate;
            cmdReadVisaDtls.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVisaDtls = new DataTable();
            dtVisaDtls = clsDataLayer.ExecuteReader(cmdReadVisaDtls);
            return dtVisaDtls;
        }


        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(ClsEntity_HCM_Common objEntityLayerHcmCommon)
        {
            {
                string strQueryReadCorp = "HCM_REPORTS.SP_READ_CORP_ADDRSS_PRINT";
                OracleCommand cmdReadCorp = new OracleCommand();
                cmdReadCorp.CommandText = strQueryReadCorp;
                cmdReadCorp.CommandType = CommandType.StoredProcedure;
                cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerHcmCommon.OrgId;
                cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerHcmCommon.CorpId;
                cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCorp = new DataTable();
                dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
                return dtCorp;
            }

        }
    }
}
