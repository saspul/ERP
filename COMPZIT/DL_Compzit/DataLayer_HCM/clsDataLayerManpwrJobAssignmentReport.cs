using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayerManpwrJobAssignmentReport
    {

       public DataTable ReadManpwrJobAssignment(clsEntityManpwrJobAsignment_Report objEntityLayerManpwr)
       {
           OracleCommand cmdReadManpwr = new OracleCommand();
          

               string strQueryReadManpwr = "HCM_JOB_ASSIGNMENT_REPORT.SP_READ_JOB_ASSIGNMENT";
           
               cmdReadManpwr.CommandText = strQueryReadManpwr;
               cmdReadManpwr.CommandType = CommandType.StoredProcedure;
               cmdReadManpwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.Organisation_Id;
               cmdReadManpwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpOffice_Id;
               cmdReadManpwr.Parameters.Add("R_PRJCTID", OracleDbType.Int32).Value = objEntityLayerManpwr.PrjctId;
               cmdReadManpwr.Parameters.Add("R_ASSIGNID", OracleDbType.Varchar2).Value = objEntityLayerManpwr.Employee_Id;
               if (objEntityLayerManpwr.FromDate == DateTime.MinValue)
               {
                   cmdReadManpwr.Parameters.Add("R_FROM_DATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdReadManpwr.Parameters.Add("R_FROM_DATE", OracleDbType.Date).Value = objEntityLayerManpwr.FromDate;
               }
               if (objEntityLayerManpwr.ToDate == DateTime.MinValue)
               {
                   cmdReadManpwr.Parameters.Add("R_TO_DATE", OracleDbType.Date).Value = null;
               }
               else
               {
                   cmdReadManpwr.Parameters.Add("R_TO_DATE", OracleDbType.Date).Value = objEntityLayerManpwr.ToDate;
               }
               cmdReadManpwr.Parameters.Add("R_STATUS", OracleDbType.Varchar2).Value = objEntityLayerManpwr.SelfAlctnSts;
               cmdReadManpwr.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
         
               DataTable dtMnpwr = new DataTable();
               dtMnpwr = clsDataLayer.ExecuteReader(cmdReadManpwr);

               return dtMnpwr;
           
       }

       public DataTable ReadProject(clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "HCM_JOB_ASSIGNMENT_REPORT.SP_READ_PROJECT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadEmployeeList(clsEntityManpwrJobAsignment_Report objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "HCM_JOB_ASSIGNMENT_REPORT.SP_READ_EMPLOYEE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadCorporateAddress(clsEntityManpwrJobAsignment_Report objEntityLayerManpwr)
       {
           string strQueryReadCorp = "HCM_REPORTS.SP_READ_CORP_ADDRSS_PRINT";
           OracleCommand cmdReadCorp = new OracleCommand();
           cmdReadCorp.CommandText = strQueryReadCorp;
           cmdReadCorp.CommandType = CommandType.StoredProcedure;
           cmdReadCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerManpwr.Organisation_Id;
           cmdReadCorp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerManpwr.CorpOffice_Id;
           cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCorp = new DataTable();
           dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
           return dtCorp;
       }
       public string ReadCountCandShrtlst(clsEntityManpwrJobAsignment_Report objEntityLayerManpwr)
       {
           string strQueryReadCountCandShrtlst = "HCM_JOB_ASSIGNMENT_REPORT.SP_READ_COUNT_CANDSHRTLST";
           OracleCommand cmdReadCountCandShrtlst = new OracleCommand();
           cmdReadCountCandShrtlst.CommandText = strQueryReadCountCandShrtlst;
           cmdReadCountCandShrtlst.CommandType = CommandType.StoredProcedure;
           cmdReadCountCandShrtlst.Parameters.Add("P_MNPWRID", OracleDbType.Int32).Value = objEntityLayerManpwr.Reqrmnt_Id;
           cmdReadCountCandShrtlst.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadCountCandShrtlst);
           string strReturn = cmdReadCountCandShrtlst.Parameters["P_COUNT"].Value.ToString();
           cmdReadCountCandShrtlst.Dispose();
           return strReturn;
       }
       public string ReadCountIntrvwPrcs(clsEntityManpwrJobAsignment_Report objEntityLayerManpwr)
       {
           string strQueryReadCountIntrvwPrcs = "HCM_JOB_ASSIGNMENT_REPORT.SP_READ_COUNT_INTRVW";
           OracleCommand cmdReadCountIntrvwPrcs = new OracleCommand();
           cmdReadCountIntrvwPrcs.CommandText = strQueryReadCountIntrvwPrcs;
           cmdReadCountIntrvwPrcs.CommandType = CommandType.StoredProcedure;
           cmdReadCountIntrvwPrcs.Parameters.Add("P_MNPWRID", OracleDbType.Int32).Value = objEntityLayerManpwr.Reqrmnt_Id;
           cmdReadCountIntrvwPrcs.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadCountIntrvwPrcs);
           string strReturn = cmdReadCountIntrvwPrcs.Parameters["P_COUNT"].Value.ToString();
           cmdReadCountIntrvwPrcs.Dispose();
           return strReturn;
       }

    }
}
