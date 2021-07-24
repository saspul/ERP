using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerOnBoard_Status_Report
    {
        //read man power reqst onboarding
        public DataTable ReadAprvdManpwrRqst(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryAprvdReadManpwr = "HCM_REPORTS.SP_READ_MANPOWER_REQ";
            OracleCommand cmdReadAprvdManPwr = new OracleCommand();
            cmdReadAprvdManPwr.CommandText = strQueryAprvdReadManpwr;
            cmdReadAprvdManPwr.CommandType = CommandType.StoredProcedure;
            cmdReadAprvdManPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.OrgId;
            cmdReadAprvdManPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CorpId;
            cmdReadAprvdManPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAprvdMnPwr = new DataTable();
            dtAprvdMnPwr = clsDataLayer.ExecuteReader(cmdReadAprvdManPwr);
            return dtAprvdMnPwr;
        }

        //read candidate details onboarding
        public DataTable ReadCandidateDtls(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryCandidateDtls = "HCM_REPORTS.SP_READ_CANDIDATE_MASTER";
            OracleCommand cmdCandidateDtls = new OracleCommand();
            cmdCandidateDtls.CommandText = strQueryCandidateDtls;
            cmdCandidateDtls.CommandType = CommandType.StoredProcedure;
            cmdCandidateDtls.Parameters.Add("P_MNPRQST_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.ManPwrId;
            cmdCandidateDtls.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCandidateDtls = new DataTable();
            dtCandidateDtls = clsDataLayer.ExecuteReader(cmdCandidateDtls);
            return dtCandidateDtls;
        }

        //read candidate details onboarding by Id
        public DataTable ReadCandidateDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryCandidateDtlsId = "HCM_REPORTS.SP_READ_CANDIDATE_MASTER_BYID";
            OracleCommand cmdCandidateDtlsId = new OracleCommand();
            cmdCandidateDtlsId.CommandText = strQueryCandidateDtlsId;
            cmdCandidateDtlsId.CommandType = CommandType.StoredProcedure;
            cmdCandidateDtlsId.Parameters.Add("P_CANDIDATE_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CandidtId;
            cmdCandidateDtlsId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCandidateDtlsId = new DataTable();
            dtCandidateDtlsId = clsDataLayer.ExecuteReader(cmdCandidateDtlsId);
            return dtCandidateDtlsId;
        }

        //read employees onboarding by candidate detail Id
        public DataTable ReadEmpOnBoard_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryEmpOnBoardDtlsId = "HCM_REPORTS.SP_READ_EMPLOYEE_ONBOARD";
            OracleCommand cmdEmpOnBoardDtlsId = new OracleCommand();
            cmdEmpOnBoardDtlsId.CommandText = strQueryEmpOnBoardDtlsId;
            cmdEmpOnBoardDtlsId.CommandType = CommandType.StoredProcedure;
            cmdEmpOnBoardDtlsId.Parameters.Add("P_CANDIDATE_DTL_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.Candidt_DtlId;
            cmdEmpOnBoardDtlsId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpOnBrd = new DataTable();
            dtEmpOnBrd = clsDataLayer.ExecuteReader(cmdEmpOnBoardDtlsId);
            return dtEmpOnBrd;
        }


        //read visa details by candidate Id
        public DataTable ReadVisaDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryVisaDtlsId = "HCM_REPORTS.SP_READ_VISADTL_BY_CAND";
            OracleCommand cmdVisaDtlsId = new OracleCommand();
            cmdVisaDtlsId.CommandText = strQueryVisaDtlsId;
            cmdVisaDtlsId.CommandType = CommandType.StoredProcedure;
            cmdVisaDtlsId.Parameters.Add("P_CANDIDATE_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CandidtId;
            cmdVisaDtlsId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtVisaDtlsId = new DataTable();
            dtVisaDtlsId = clsDataLayer.ExecuteReader(cmdVisaDtlsId);
            return dtVisaDtlsId;
        }


        //read flight details by candidate Id
        public DataTable ReadFlightDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryFlightDtlsId = "HCM_REPORTS.SP_READ_FLIGHTDTL_BY_CAND";
            OracleCommand cmdFlightDtlsId = new OracleCommand();
            cmdFlightDtlsId.CommandText = strQueryFlightDtlsId;
            cmdFlightDtlsId.CommandType = CommandType.StoredProcedure;
            cmdFlightDtlsId.Parameters.Add("P_CANDIDATE_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CandidtId;
            cmdFlightDtlsId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtFlightDtlsId = new DataTable();
            dtFlightDtlsId = clsDataLayer.ExecuteReader(cmdFlightDtlsId);
            return dtFlightDtlsId;
        }


        //read room details by candidate Id
        public DataTable ReadRoomDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryRoomDtlsId = "HCM_REPORTS.SP_READ_ROOMDTL_BY_CAND";
            OracleCommand cmdRoomDtlsId = new OracleCommand();
            cmdRoomDtlsId.CommandText = strQueryRoomDtlsId;
            cmdRoomDtlsId.CommandType = CommandType.StoredProcedure;
            cmdRoomDtlsId.Parameters.Add("P_CANDIDATE_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CandidtId;
            cmdRoomDtlsId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtRoomDtlsId = new DataTable();
            dtRoomDtlsId = clsDataLayer.ExecuteReader(cmdRoomDtlsId);
            return dtRoomDtlsId;
        }


        //read airport pickup details by candidate Id
        public DataTable ReadAirportDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryAirprtDtlsId = "HCM_REPORTS.SP_READ_AIRPORTDTL_BY_CAND";
            OracleCommand cmdAirprtDtlsId = new OracleCommand();
            cmdAirprtDtlsId.CommandText = strQueryAirprtDtlsId;
            cmdAirprtDtlsId.CommandType = CommandType.StoredProcedure;
            cmdAirprtDtlsId.Parameters.Add("P_CANDIDATE_ID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CandidtId;
            cmdAirprtDtlsId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtAirprtDtlsId = new DataTable();
            dtAirprtDtlsId = clsDataLayer.ExecuteReader(cmdAirprtDtlsId);
            return dtAirprtDtlsId;
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            string strQueryReadCorp = "HCM_REPORTS.SP_READ_CORP_ADDRSS_PRINT";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.OrgId;
            cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CorpId;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }











    }
}
