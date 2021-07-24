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
    public class clsBusiness_Payroll_Report
    {
        clsDataLayerPayrollProcessReport objDataPayroll_Report = new clsDataLayerPayrollProcessReport();
        public DataTable ReadDepts(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            DataTable dtDepts = new DataTable();
            dtDepts = objDataPayroll_Report.ReadDepts(objEntityPayroll_Report);
            return dtDepts;
        }
        public DataTable ReadDivision(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            DataTable dtDivision = new DataTable();
            dtDivision = objDataPayroll_Report.ReadDivision(objEntityPayroll_Report);
            return dtDivision;
        }
        public DataTable LoadBank(clsEntityPayrollProcess objEntityPayroll_Report)
        { 
            return objDataPayroll_Report.LoadBank(objEntityPayroll_Report);
        }
        public DataTable LoadPayrollReport(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            return objDataPayroll_Report.LoadPayrollReport(objEntityPayroll_Report);
        }
        public DataTable ReadCorporateAddress(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            DataTable dtCorporate = new DataTable();
            dtCorporate = objDataPayroll_Report.ReadCorporateAddress(objEntityPayroll_Report);
            return dtCorporate;
        }
        //EVM-0027
        public DataTable ReadAllowanceDetails(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            return objDataPayroll_Report.ReadAllowanceDetails(objEntityPayroll_Report);
        }
        public DataTable ReadDeductionDetails(clsEntityPayrollProcess objEntityPayroll_Report)
        {
            return objDataPayroll_Report.ReadDeductionDetails(objEntityPayroll_Report);
        }
        //END
    }
}
