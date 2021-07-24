using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;

namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerTimeSheetReport
    {
        //To fetch employee name
        public DataTable ReadEmployee(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            clsDataLayerTimeSheetReport objDataLayerTimeSheetReport = new clsDataLayerTimeSheetReport();
            DataTable dtEmp = objDataLayerTimeSheetReport.ReadEmployees(objEntityTimeSheetReport);
            return dtEmp;
        }
        //To fetch Division
        public DataTable ReadDivision(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            clsDataLayerTimeSheetReport objDataLayerTimeSheetReport = new clsDataLayerTimeSheetReport();
            DataTable dtDiv = objDataLayerTimeSheetReport.ReadDivision(objEntityTimeSheetReport);
            return dtDiv;
        }
        //To fetch Division
        public DataTable ReadDepartment(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            clsDataLayerTimeSheetReport objDataLayerTimeSheetReport = new clsDataLayerTimeSheetReport();
            DataTable dtDiv = objDataLayerTimeSheetReport.ReadDepartment(objEntityTimeSheetReport);
            return dtDiv;
        }
        // This Method will fetch Report
        public DataTable ReadTimeSheetReport(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            clsDataLayerTimeSheetReport objDataLayerTimeSheetReport = new clsDataLayerTimeSheetReport();
            DataTable dtTimeSheetReport = objDataLayerTimeSheetReport.ReadTimeSheetReport(objEntityTimeSheetReport);
            return dtTimeSheetReport;
        }
        //read corporate details for printing
        public DataTable Read_Corp_Details(clsEntityLayerTimeSheetReport objEntityTimeSheetReport)
        {
            clsDataLayerTimeSheetReport objDataLayerTimeSheetReport = new clsDataLayerTimeSheetReport();
            DataTable dtCorp = objDataLayerTimeSheetReport.ReadCorporateAddress(objEntityTimeSheetReport);
            return dtCorp;
        }
    }
}
