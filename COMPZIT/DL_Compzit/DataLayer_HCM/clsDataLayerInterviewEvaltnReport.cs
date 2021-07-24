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
   public class clsDataLayerInterviewEvaltnReport
    {

       public DataTable ReadAprvdManpwrRqst(clsEntityInterviewEvaltnReport objEntityLayerOnBoarding_Status)
       {
           string strQueryAprvdReadManpwr = "HCM_REPORT_INTERVIEW_EVALTN.SP_READ_MANPOWER_REQ";
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

    }
}
