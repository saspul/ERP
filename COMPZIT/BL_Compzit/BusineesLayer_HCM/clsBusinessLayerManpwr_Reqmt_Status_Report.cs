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
    public class clsBusinessLayerManpwr_Reqmt_Status_Report
    {
        clsDataLayerManpwr_Reqmt_Status_Report objDataManpwrReqmt=new clsDataLayerManpwr_Reqmt_Status_Report();
        //Evm-27

        public DataTable ReadProjects(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtProjects = new DataTable();
            dtProjects = objDataManpwrReqmt.ReadProjects(objEntityLayerManpwr);
            return dtProjects;


        }
        public DataTable ReadDivision(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataManpwrReqmt.ReadDivision(objEntityLayerManpwr);
            return dtDivision;


        }
        
        public DataTable ReadDesignation(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtDesignation = new DataTable();
            dtDesignation = objDataManpwrReqmt.ReadDesignation(objEntityLayerManpwr);
            return dtDesignation;


        }
        //End
        public DataTable ReadDepts(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtDepts = new DataTable();
            dtDepts = objDataManpwrReqmt.ReadDepts(objEntityLayerManpwr);
            return dtDepts;
        }

        public DataTable ReadManpwrReqmt(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtMnpwr = new DataTable();
            dtMnpwr = objDataManpwrReqmt.ReadManpwrReqmt(objEntityLayerManpwr);
            return dtMnpwr;
        }

        public DataTable ReadManpwrReqmtById(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtMnpwrId = new DataTable();
            dtMnpwrId = objDataManpwrReqmt.ReadManpwrReqmtById(objEntityLayerManpwr);
            return dtMnpwrId;
        }

        public DataTable ReadManpwrCandidts(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
             DataTable dtMnpwrCand = new DataTable();
             dtMnpwrCand = objDataManpwrReqmt.ReadManpwrCandidts(objEntityLayerManpwr);
             return dtMnpwrCand;
        }

        public string ReadCountCandShrtlst(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strReturn = objDataManpwrReqmt.ReadCountCandShrtlst(objEntityLayerManpwr);
            return strReturn;
        }

        public string ReadCountIntrvwPrcs(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strReturn = objDataManpwrReqmt.ReadCountIntrvwPrcs(objEntityLayerManpwr);
            return strReturn;
        }

        public DataTable ReadCorporateAddress(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            DataTable dtCorp = new DataTable();
            dtCorp = objDataManpwrReqmt.ReadCorporateAddress(objEntityLayerManpwr);
            return dtCorp;
        }



    }
}
