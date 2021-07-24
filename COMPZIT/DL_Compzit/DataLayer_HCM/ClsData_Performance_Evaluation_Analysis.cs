using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
using CL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
  public  class ClsData_Performance_Evaluation_Analysis
    {

      public DataTable ReadEmployeEvaluationSummary(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_tmplt)
      {
          DataTable dtReadPrfmcTmplt = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_PRFMNC_EVALTN_ANALYSIS";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
            

              cmdReadPerfmncTmplt.Parameters.Add("PERFM_ISSUE", OracleDbType.Int32).Value = objEntityPermne_tmplt.IssueId;
              cmdReadPerfmncTmplt.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPermne_tmplt.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPermne_tmplt.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("USERID", OracleDbType.Int32).Value = objEntityPermne_tmplt.EmpUsrId;
              
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcTmplt = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcTmplt;
      }
      public DataTable ReadPerfomanceIssue(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Evltion)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_PRFMNC_ISSUE";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
              cmdReadPerfmncTmplt.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EvltnId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
      public DataTable ReadPerEmployeeDtls(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_anlyz)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_EMPLOYEE_DTLS";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

              cmdReadPerfmncTmplt.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPermne_anlyz.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPermne_anlyz.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("USERID", OracleDbType.Int32).Value = objEntityPermne_anlyz.EmpUsrId;

              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
      public DataTable readEvaluation(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_anlyz)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_EVLTN";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

              cmdReadPerfmncTmplt.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPermne_anlyz.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPermne_anlyz.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("USERID", OracleDbType.Int32).Value = objEntityPermne_anlyz.EmpUsrId;
              cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_ID", OracleDbType.Int32).Value = objEntityPermne_anlyz.IssueId;
              cmdReadPerfmncTmplt.Parameters.Add("P_TYP_ID", OracleDbType.Int32).Value = objEntityPermne_anlyz.RspnTypeId;
              cmdReadPerfmncTmplt.Parameters.Add("P_EVLTR_ID", OracleDbType.Int32).Value = objEntityPermne_anlyz.usrDtlId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
      public DataTable ReadGrpQstnById(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Evltion)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_GRP_BYID";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
              cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
      public DataTable ReadQstnById(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Evltion)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_QSTN_BY_ID";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

              cmdReadPerfmncTmplt.Parameters.Add("P_GRP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.GrpId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
      public DataTable LoadEmployee(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Evltion)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_LOAD_EMPLOYEE";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

              cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
              cmdReadPerfmncTmplt.Parameters.Add("P_TYPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpTypId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }

      public DataTable ReadGoals(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_Evltion)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_GOAL";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

              cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
              cmdReadPerfmncTmplt.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpUsrId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
      public DataTable readEvaluator(ClsEntity_Performance_Evaluation_Analysis objEntityPermne_anlyz)
      {
          DataTable dtReadPrfmcEvltn = new DataTable();
          using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
          {
              cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFORM_EVLTN_ANLYZ.SP_READ_EVLTOR";
              cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;

              cmdReadPerfmncTmplt.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntityPermne_anlyz.OrgId;
              cmdReadPerfmncTmplt.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntityPermne_anlyz.CorpId;
              cmdReadPerfmncTmplt.Parameters.Add("USERID", OracleDbType.Int32).Value = objEntityPermne_anlyz.EmpUsrId;
              cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_ID", OracleDbType.Int32).Value = objEntityPermne_anlyz.IssueId;
              cmdReadPerfmncTmplt.Parameters.Add("P_TYP_ID", OracleDbType.Int32).Value = objEntityPermne_anlyz.RspnTypeId;
              cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
          }
          return dtReadPrfmcEvltn;
      }
    }
}
