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
  public  class clsDataLayerAttendanceReport
    {
      public DataTable ReadListReport(clsEntityAttendanceReport objEntityLayerOnBoarding_Status)
      {
          string strQueryAprvdReadManpwr = "HCM_REPORT_ATTENDANCE.SP_READ_ATTEND_LIST";
          OracleCommand cmdReadAprvdManPwr = new OracleCommand();
          cmdReadAprvdManPwr.CommandText = strQueryAprvdReadManpwr;
          cmdReadAprvdManPwr.CommandType = CommandType.StoredProcedure;
          cmdReadAprvdManPwr.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.OrgId;
          cmdReadAprvdManPwr.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.CorpId;
          cmdReadAprvdManPwr.Parameters.Add("P_OT_TYPE", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.OtType;
          cmdReadAprvdManPwr.Parameters.Add("P_DEPT", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.DepartmentId;
          cmdReadAprvdManPwr.Parameters.Add("P_DIV", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.DivsnId;
          cmdReadAprvdManPwr.Parameters.Add("P_PRJCT", OracleDbType.Int32).Value = objEntityLayerOnBoarding_Status.ProjectId;
          cmdReadAprvdManPwr.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityLayerOnBoarding_Status.FromDate;
          cmdReadAprvdManPwr.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtAprvdMnPwr = new DataTable();
          dtAprvdMnPwr = clsDataLayer.ExecuteReader(cmdReadAprvdManPwr);
          return dtAprvdMnPwr;
      }
    }
}
