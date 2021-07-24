using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_JobCostSummary_Report
    {
        clsDataLayer_JobCostSummary_Report objDataLayer_JobCostSummary_Report = new clsDataLayer_JobCostSummary_Report();

        public DataTable Read_JobCostReport_List(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            DataTable dtJobCostReport = objDataLayer_JobCostSummary_Report.Read_JobCostReport_List(objEntityJobCostSummary_Report);
            return dtJobCostReport;
        }

        public DataTable ReadCorporateAddress(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            DataTable dtCorp = objDataLayer_JobCostSummary_Report.ReadCorporateAddress(objEntityJobCostSummary_Report);
            return dtCorp;
        }

        public DataTable Read_Dates_ByPrjctId(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            DataTable dtJobCostReport = objDataLayer_JobCostSummary_Report.Read_Dates_ByPrjctId(objEntityJobCostSummary_Report);
            return dtJobCostReport;
        }

        public DataTable Read_ProjectCostReport_List(clsEntityJobCostSummary_Report objEntityJobCostSummary_Report)
        {
            DataTable dtJobCostReport = objDataLayer_JobCostSummary_Report.Read_ProjectCostReport_List(objEntityJobCostSummary_Report);
            return dtJobCostReport;
        }

    }
}
