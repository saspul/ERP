using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
using DL_Compzit.DataLayer_HCM;
using System.Data;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessEmployeeAddDedReport
    {
        clsDataEmployeeAddDedReport objDataLayer_AccntSetting = new clsDataEmployeeAddDedReport();
        public DataTable LoadDepartment(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadDepartment(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadDivison(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadDivison(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadJob(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadJob(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadDesignation(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadDesignation(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadAddition(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadAddition(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadDeduction(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadDeduction(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadEmployee(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadEmployee(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryFirst(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryFirst(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryFirstMtdTwo(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryFirstMtdTwo(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummarySecond(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummarySecond(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryThird(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryThird(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryThirdGrp(clsEntityEmployeeAddDedReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryThirdGrp(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
    }
}
