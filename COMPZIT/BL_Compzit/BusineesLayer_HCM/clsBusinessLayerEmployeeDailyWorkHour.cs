using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
  public  class clsBusinessLayerEmployeeDailyWorkHour
    {
        clsDataLayerEmployeeDailyWorkHour objDatalayerEmpDailyWorkHour = new clsDataLayerEmployeeDailyWorkHour();
        //This Method for checking employee name
        public DataTable checkEmpcode(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.checkEmpcode(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }
        //This Method for checking job name
        public DataTable checkJobname(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.checkJobname(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }
        //This Method for inserting into table
        public void InsertDailyWorkHourSheet(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour, List<clsEntityEmployeeDailyWorkHourDtl> objEntityEmpDailyHrList, string[] strarrDupValues)
        {
            objDatalayerEmpDailyWorkHour.InsertDailyWorkHourSheet(objEntityEmpDailyWorkHour, objEntityEmpDailyHrList, strarrDupValues);
        }
        //This Method for read worksheet list
        public DataTable readDailywrksheetList(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.readDailywrksheetList(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }
        //This Method for read worksheet sheet details
        public DataTable readDailywrksheetDtls(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.readDailywrksheetDtls(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }
        //This Method for read OT categories
        public DataTable readOTcategories(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.readOTcategories(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }

        //This Method for check holiday
        public DataTable checkHoliday(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.checkHoliday(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }
        //This Method for read worksheet list
        public DataTable readDailywrkShtMnthYear(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.readDailywrkShtMnthYear(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }
        public void UpdateWrkDtl(clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDtl)
        {
            objDatalayerEmpDailyWorkHour.UpdateWrkDtl(objEntityEmpDailyWorkHourDtl);
            
        }
        public void ConfirmDtls(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            objDatalayerEmpDailyWorkHour.ConfirmDtls(objEntityEmpDailyWorkHour);

        }
        public DataTable ConfrmSts(clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHourDtl)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.ConfrmSts(objEntityEmpDailyWorkHourDtl);
            return dtCountryList;
        }


        public DataTable checkEmpcodeDB(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.checkEmpcodeDB(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }

        public void ReopenAttendanceSheet(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            objDatalayerEmpDailyWorkHour.ReopenAttendanceSheet(objEntityEmpDailyWorkHour);

        }

        public DataTable checkProjectCode(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.checkProjectCode(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }

        public DataTable readLastDailywrksheetList(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dtCountryList = objDatalayerEmpDailyWorkHour.readLastDailywrksheetList(objEntityEmpDailyWorkHour);
            return dtCountryList;
        }

        public DataTable checkOTCategory(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dt = objDatalayerEmpDailyWorkHour.checkOTCategory(objEntityEmpDailyWorkHour);
            return dt;
        }

        public void InsertMonthlyWorkHourSheet(List<clsEntityEmployeeDailyWorkHour> objEntityEmpDailyMasterList, List<clsEntityEmployeeDailyWorkHourDtl> objEntityEmpDailyHrList, string[] strarrDupValues)
        {
            objDatalayerEmpDailyWorkHour.InsertMonthlyWorkHourSheet(objEntityEmpDailyMasterList, objEntityEmpDailyHrList, strarrDupValues);
        }
        public void ConfReopAll(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHourDtl)
        {
            objDatalayerEmpDailyWorkHour.ConfReopAll(objEntityEmpDailyWorkHourDtl);
        }
        public DataTable checkAllConfReop(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dt = objDatalayerEmpDailyWorkHour.checkAllConfReop(objEntityEmpDailyWorkHour);
            return dt;
        }
        public DataTable ReadMasterIds(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dt = objDatalayerEmpDailyWorkHour.ReadMasterIds(objEntityEmpDailyWorkHour);
            return dt;
        }
        public DataTable ReadFirstUploadData(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dt = objDatalayerEmpDailyWorkHour.ReadFirstUploadData(objEntityEmpDailyWorkHour);
            return dt;
        }
        public void removeLeaveAllocation(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHourDtl)
        {
            objDatalayerEmpDailyWorkHour.removeLeaveAllocation(objEntityEmpDailyWorkHourDtl);
        }
        public void UpdateAmendmentAttendance(clsEntityEmployeeDailyWorkHourDtl objEntityEmpDailyWorkHour)
        {
            objDatalayerEmpDailyWorkHour.UpdateAmendmentAttendance(objEntityEmpDailyWorkHour);
        }
        public DataTable readAmenmentDtl(clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour)
        {
            DataTable dt = objDatalayerEmpDailyWorkHour.readAmenmentDtl(objEntityEmpDailyWorkHour);
            return dt;
        }
    }
}
