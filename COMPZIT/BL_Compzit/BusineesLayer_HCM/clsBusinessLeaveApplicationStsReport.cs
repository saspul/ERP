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
    public class clsBusinessLeaveApplicationStsReport
    {
        clsDataLeaveApplicationStatusReport objDataLayer_AccntSetting = new clsDataLeaveApplicationStatusReport();
        public DataTable LoadLeaveType(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadLeaveType(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadDepartment(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadDepartment(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadDivison(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadDivison(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable LoadJob(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.LoadJob(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryTypeList(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryTypeList(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryTypeListSingle(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryTypeListSingle(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
        public DataTable ReadSummaryLeaveDtls(clsEntityLeaveApplicationStatusReport objEntityAccountSettings)
        {
            DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadSummaryLeaveDtls(objEntityAccountSettings);
            return dtEmployeeDetails;
        }
    }
}
