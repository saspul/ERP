using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using Oracle.DataAccess.Client;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerVisaQuotaStatusReport
    {
        public DataTable ReadVisaQuotaStatus(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "HCM_VISA_QUOTA_STATUS_REPORT.SP_READ_VISAQUOTA_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_BUSINESS_UNIT", OracleDbType.Int32).Value = objEntityVisaQuot.BussnsId;
            cmdReadPayGrd.Parameters.Add("P_BUSSTATUS", OracleDbType.Int32).Value = objEntityVisaQuot.BussUnit;
            cmdReadPayGrd.Parameters.Add("P_BUNDLENO", OracleDbType.Int32).Value = objEntityVisaQuot.VisaBundleNo;
            cmdReadPayGrd.Parameters.Add("P_NATION_ID", OracleDbType.Int32).Value = objEntityVisaQuot.CountryId;
            cmdReadPayGrd.Parameters.Add("P_VISATYPE", OracleDbType.Int32).Value = objEntityVisaQuot.VisaTypeId;
            cmdReadPayGrd.Parameters.Add("P_GENDER", OracleDbType.Int32).Value = objEntityVisaQuot.Gender;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadCount(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "HCM_VISA_QUOTA_STATUS_REPORT.SP_CHECK_VISATYP_COUNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_QTAID", OracleDbType.Int32).Value = objEntityVisaQuot.NxtVisaId;
            cmdReadPayGrd.Parameters.Add("P_TYP", OracleDbType.Int32).Value = objEntityVisaQuot.VisaTypeId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }



        public DataTable ReadVisaTyp(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "HCM_VISA_QUOTA_STATUS_REPORT.SP_READ_VISATYP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadBundleNumber(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "HCM_VISA_QUOTA_STATUS_REPORT.SP_READ_BUNDLE_NUMBER";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadSelectNations(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "HCM_VISA_QUOTA_STATUS_REPORT.SP_READ_NATION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public DataTable ReadBussnsUnit(clsEntityVisaQuotaStatusReport objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "HCM_VISA_QUOTA_STATUS_REPORT.SP_READ_BUSINESS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.OrgId;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpId;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }
        public DataTable ReadCorporateAddress(clsEntityVisaQuotaStatusReport objEntityLayerManpwr)
        {
            string strQueryReadCorp = "HCM_VISA_QUOTA_STATUS_REPORT.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

    }
}
