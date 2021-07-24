using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayer_OnBoard_Status_Report
    {

        clsDataLayerOnBoard_Status_Report objDataOnBoarding_Status=new clsDataLayerOnBoard_Status_Report();

        //read man power reqst onboarding 
        public DataTable ReadAprvdManpwrRqst(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtAprvdManPwr = new DataTable();
            dtAprvdManPwr = objDataOnBoarding_Status.ReadAprvdManpwrRqst(objEntityLayerOnBoarding_Status);
            return dtAprvdManPwr;
        }

        //read candidate details onboarding
        public DataTable ReadCandidateDtls(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtCandidateDtls = new DataTable();
            dtCandidateDtls = objDataOnBoarding_Status.ReadCandidateDtls(objEntityLayerOnBoarding_Status);
            return dtCandidateDtls;
        }

        //read candidate details onboarding by Id
        public DataTable ReadCandidateDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtCandidateDtlsId = new DataTable();
            dtCandidateDtlsId = objDataOnBoarding_Status.ReadCandidateDtls_ById(objEntityLayerOnBoarding_Status);
            return dtCandidateDtlsId;
        }

        //read employees onboarding 
        public DataTable ReadEmpOnBoard_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtEmpOnBrd = new DataTable();
            dtEmpOnBrd = objDataOnBoarding_Status.ReadEmpOnBoard_ById(objEntityLayerOnBoarding_Status);
            return dtEmpOnBrd;
        }

        //read visa details by candidate Id
        public DataTable ReadVisaDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtVisaDtlsId = new DataTable();
            dtVisaDtlsId = objDataOnBoarding_Status.ReadVisaDtls_ById(objEntityLayerOnBoarding_Status);
            return dtVisaDtlsId;
        }
            
        //read flight details by candidate Id
        public DataTable ReadFlightDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtFlightDtlsId = new DataTable();
            dtFlightDtlsId = objDataOnBoarding_Status.ReadFlightDtls_ById(objEntityLayerOnBoarding_Status);
            return dtFlightDtlsId;
        }

        //read room details by candidate Id
        public DataTable ReadRoomDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtRoomDtlsId = new DataTable();
            dtRoomDtlsId = objDataOnBoarding_Status.ReadRoomDtls_ById(objEntityLayerOnBoarding_Status);
            return dtRoomDtlsId;
        }

        //read airport pickup details by candidate Id
        public DataTable ReadAirportDtls_ById(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtCandidateDtlsId = new DataTable();
            dtCandidateDtlsId = objDataOnBoarding_Status.ReadAirportDtls_ById(objEntityLayerOnBoarding_Status);
            return dtCandidateDtlsId;
        }

         // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityOnBoarding_Status_Report objEntityLayerOnBoarding_Status)
        {
            DataTable dtCorp = new DataTable();
            dtCorp = objDataOnBoarding_Status.ReadCorporateAddress(objEntityLayerOnBoarding_Status);
            return dtCorp;
        }



    }
}
