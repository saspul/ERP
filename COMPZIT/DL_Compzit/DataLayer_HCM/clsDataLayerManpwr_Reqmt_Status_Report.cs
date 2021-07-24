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
    public class clsDataLayerManpwr_Reqmt_Status_Report
    {
        //Evm-27
        public DataTable ReadProjects(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadDivision = "HCM_REPORTS.SP_READ_PROJECTS";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            //cmdReadDivision.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityLayerManpwr.DeptId;
            //cmdReadDivision.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityLayerManpwr.DeptId;
            cmdReadDivision.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }

        public DataTable ReadDivision(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadDivision = "HCM_REPORTS.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            cmdReadDivision.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityLayerManpwr.DeptId;
            cmdReadDivision.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }
        public DataTable ReadDesignation(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadDesignation = "HCM_REPORTS.SP_READ_DESIGNATION";
            OracleCommand cmdReadDesignation = new OracleCommand();
            cmdReadDesignation.CommandText = strQueryReadDesignation;
            cmdReadDesignation.CommandType = CommandType.StoredProcedure;
            cmdReadDesignation.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            //cmdReadDesignation.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            //cmdReadDesignation.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityLayerManpwr.DeptId;
            cmdReadDesignation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDesignation);
            return dtDivision;
        }


        public DataTable ReadDepts(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadDepts = "HCM_REPORTS.SP_READ_DEPARTMENTS";
            OracleCommand cmdReadDepts = new OracleCommand();
            cmdReadDepts.CommandText = strQueryReadDepts;
            cmdReadDepts.CommandType = CommandType.StoredProcedure;
            cmdReadDepts.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            cmdReadDepts.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            cmdReadDepts.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDepts = new DataTable();
            dtDepts = clsDataLayer.ExecuteReader(cmdReadDepts);
            return dtDepts;
        }

        public DataTable ReadManpwrReqmt(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadManpwr = "HCM_REPORTS.SP_READ_MANPWR_REQMT";
            OracleCommand cmdReadManpwr = new OracleCommand();
            cmdReadManpwr.CommandText = strQueryReadManpwr;
            cmdReadManpwr.CommandType = CommandType.StoredProcedure;
            cmdReadManpwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.OrgId;
            cmdReadManpwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpId;
            cmdReadManpwr.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityLayerManpwr.DivsnId;
            cmdReadManpwr.Parameters.Add("P_PROJECTID", OracleDbType.Int32).Value = objEntityLayerManpwr.intProjid;
            cmdReadManpwr.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityLayerManpwr.DeptId;
            cmdReadManpwr.Parameters.Add("P_DEG", OracleDbType.Int32).Value = objEntityLayerManpwr.intDegsid;
            if (objEntityLayerManpwr.FromDt != DateTime.MinValue)
            {
                cmdReadManpwr.Parameters.Add("P_DATEFROM", OracleDbType.Date).Value = objEntityLayerManpwr.FromDt;
            }
            else
            {
                cmdReadManpwr.Parameters.Add("P_DATEFROM", OracleDbType.Date).Value = null;
            }
            if (objEntityLayerManpwr.ToDate != DateTime.MinValue)
            {
                cmdReadManpwr.Parameters.Add("P_DATETO", OracleDbType.Date).Value = objEntityLayerManpwr.ToDate;
            }
            else
            {
                cmdReadManpwr.Parameters.Add("P_DATETO", OracleDbType.Date).Value = null;
            }
            //cmdReadManpwr.Parameters.Add("P_DATEFROM", OracleDbType.Date).Value = objEntityLayerManpwr.FromDt;
            //cmdReadManpwr.Parameters.Add("P_DATETO", OracleDbType.Date).Value = objEntityLayerManpwr.ToDate;
            cmdReadManpwr.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityLayerManpwr.intS;
            cmdReadManpwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMnpwr = new DataTable();
            dtMnpwr = clsDataLayer.ExecuteReader(cmdReadManpwr);
            return dtMnpwr;
        }
        //End
        public DataTable ReadManpwrReqmtById(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadManpwrId = "HCM_REPORTS.SP_READ_MANPWR_REQMT_BYID";
            OracleCommand cmdReadManpwrId = new OracleCommand();
            cmdReadManpwrId.CommandText = strQueryReadManpwrId;
            cmdReadManpwrId.CommandType = CommandType.StoredProcedure;
            cmdReadManpwrId.Parameters.Add("P_MNPWRID", OracleDbType.Int32).Value = objEntityLayerManpwr.ManPwrId;
            cmdReadManpwrId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMnpwrId = new DataTable();
            dtMnpwrId = clsDataLayer.ExecuteReader(cmdReadManpwrId);
            return dtMnpwrId;
        }

        public DataTable ReadManpwrCandidts(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadManpwrCand = "HCM_REPORTS.SP_READ_CANDIDATES_MANPWR";
            OracleCommand cmdReadManpwrCand = new OracleCommand();
            cmdReadManpwrCand.CommandText = strQueryReadManpwrCand;
            cmdReadManpwrCand.CommandType = CommandType.StoredProcedure;
            cmdReadManpwrCand.Parameters.Add("P_MNPWRID", OracleDbType.Int32).Value = objEntityLayerManpwr.ManPwrId;
            cmdReadManpwrCand.Parameters.Add("P_STS", OracleDbType.Varchar2).Value = objEntityLayerManpwr.StsChk;
            cmdReadManpwrCand.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMnpwrCand = new DataTable();
            dtMnpwrCand = clsDataLayer.ExecuteReader(cmdReadManpwrCand);
            return dtMnpwrCand;
        }

        public string ReadCountCandShrtlst(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadCountCandShrtlst = "HCM_REPORTS.SP_READ_COUNT_CANDSHRTLST";
            OracleCommand cmdReadCountCandShrtlst = new OracleCommand();
            cmdReadCountCandShrtlst.CommandText = strQueryReadCountCandShrtlst;
            cmdReadCountCandShrtlst.CommandType = CommandType.StoredProcedure;
            cmdReadCountCandShrtlst.Parameters.Add("P_MNPWRID", OracleDbType.Int32).Value = objEntityLayerManpwr.ManPwrId;
            cmdReadCountCandShrtlst.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadCountCandShrtlst);
            string strReturn = cmdReadCountCandShrtlst.Parameters["P_COUNT"].Value.ToString();
            cmdReadCountCandShrtlst.Dispose();
            return strReturn;
        }

        public string ReadCountIntrvwPrcs(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadCountIntrvwPrcs = "HCM_REPORTS.SP_READ_COUNT_INTRVW";
            OracleCommand cmdReadCountIntrvwPrcs = new OracleCommand();
            cmdReadCountIntrvwPrcs.CommandText = strQueryReadCountIntrvwPrcs;
            cmdReadCountIntrvwPrcs.CommandType = CommandType.StoredProcedure;
            cmdReadCountIntrvwPrcs.Parameters.Add("P_MNPWRID", OracleDbType.Int32).Value = objEntityLayerManpwr.ManPwrId;
            cmdReadCountIntrvwPrcs.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadCountIntrvwPrcs);
            string strReturn = cmdReadCountIntrvwPrcs.Parameters["P_COUNT"].Value.ToString();
            cmdReadCountIntrvwPrcs.Dispose();
            return strReturn;
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityManpwrReqmt_Status_Report objEntityLayerManpwr)
        {
            string strQueryReadCorp = "HCM_REPORTS.SP_READ_CORP_ADDRSS_PRINT";
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
