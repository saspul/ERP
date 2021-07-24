using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_JobCostSummary_Report
    {     
        public DataTable Read_JobCostReport_List(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            string strQueryReadJobCost = "HCM_REPORTS.SP_READ_JOBCOSTREPORT";
            using (OracleCommand cmdJobCost = new OracleCommand())
            {
                cmdJobCost.CommandText = strQueryReadJobCost;
                cmdJobCost.CommandType = CommandType.StoredProcedure;
                cmdJobCost.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.Corporate_Id;
                cmdJobCost.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.Organisation_Id;
                cmdJobCost.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtJobCostReport = new DataTable();
                dtJobCostReport = clsDataLayer.SelectDataTable(cmdJobCost);
                return dtJobCostReport;
            }
        }

        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            string strQueryReadCorp = "REPORTS.SP_READ_CORPORATE_ADDR";
            OracleCommand cmdReadCorp = new OracleCommand();
            cmdReadCorp.CommandText = strQueryReadCorp;
            cmdReadCorp.CommandType = CommandType.StoredProcedure;
            cmdReadCorp.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.Corporate_Id;
            cmdReadCorp.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.Organisation_Id;
            cmdReadCorp.Parameters.Add("D_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCorp = new DataTable();
            dtCorp = clsDataLayer.ExecuteReader(cmdReadCorp);
            return dtCorp;
        }

        public DataTable Read_Dates_ByPrjctId(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            string strQueryReadJobCost = "HCM_REPORTS.SP_READ_PRJCTDTLS";
            using (OracleCommand cmdJobCost = new OracleCommand())
            {
                cmdJobCost.CommandText = strQueryReadJobCost;
                cmdJobCost.CommandType = CommandType.StoredProcedure;
                cmdJobCost.Parameters.Add("P_PROJECTID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.PrjctId;
                cmdJobCost.Parameters.Add("P_CRNSMTID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.CrncyId;
                cmdJobCost.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtJobCostReport = new DataTable();
                dtJobCostReport = clsDataLayer.SelectDataTable(cmdJobCost);
                return dtJobCostReport;
            }
        }

        public DataTable Read_ProjectCostReport_List(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            string strQueryReadJobCost = "HCM_REPORTS.SP_READ_PROJECT_COSTREPORT";
            using (OracleCommand cmdJobCost = new OracleCommand())
            {
                cmdJobCost.CommandText = strQueryReadJobCost;
                cmdJobCost.CommandType = CommandType.StoredProcedure;
                cmdJobCost.Parameters.Add("P_DIV_ID", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.DivisionId;
                cmdJobCost.Parameters.Add("P_MONTH", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.Month;
                cmdJobCost.Parameters.Add("P_YEAR", OracleDbType.Int32).Value = objEntityJobCostSummary_Report.Year;
                cmdJobCost.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtJobCostReport = new DataTable();
                dtJobCostReport = clsDataLayer.SelectDataTable(cmdJobCost);
                return dtJobCostReport;
            }
        }

    }
}
