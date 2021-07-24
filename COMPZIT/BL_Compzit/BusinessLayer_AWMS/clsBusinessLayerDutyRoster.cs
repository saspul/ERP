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
// CREATED BY:EVM-0005
// CREATED DATE:17/03/2017
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerDutyRoster
    {
        clsDataLayerDutyRoster objDtalayerDutyroster = new clsDataLayerDutyRoster();
         // This Method will fetch emlpoyee datas
        public DataTable ReadEmployee(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmp = objDtalayerDutyroster.ReadEmployee(objEntityDutyRost);
            return dtEmp;
        }

           // This Method will fetch emlpoyee wise duty datas
       public DataTable ReadJobShdlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmp = objDtalayerDutyroster.ReadJobShdlByEmp(objEntityDutyRost);
            return dtEmp;
        }
         // This Method will fetch emlpoyee wise duty datas
       public DataTable ReadJobShdlByDateEmp(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadJobShdlByEmp(objEntityDutyRost);
           return dtEmp;
       }
          // This Method will fetch emlpoyee wise duty datas
       public DataTable ReadJobShdlByDayWise(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadJobShdlByDayWise(objEntityDutyRost);
           return dtEmp;
       }
        // This Method will fetch emlpoyee wise duty datas
       public DataTable ReadJobShdlForDayEmp(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadJobShdlForDayEmp(objEntityDutyRost);
           return dtEmp;
       }
         // This Method will fetch emlpoyee wise duty sheduled datas
       public DataTable ReadDutyShdlForDayEmp(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadDutyShdlForDayEmp(objEntityDutyRost);
           return dtEmp;
       }
         // This Method will fetch holiday details
       public DataTable ReadHolidays(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadHolidays(objEntityDutyRost);
           return dtEmp;
       }
         // This Method will fetch VEHICLE detail
       public DataTable ReadVehicleById(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadVehicleById(objEntityDutyRost);
           return dtEmp;
       }
        //START:-EVM-0009
        //For inserting job schedule details
       public void insertScheduleDetails(clsEntityLayerDutyRoster objEntityDutyRost, List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseList, List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseListUpd, string[] strCanclDtlIds)
       {
           objDtalayerDutyroster.insertScheduleDetails(objEntityDutyRost, objEntityobScheduleDtlPeriodWiseList, objEntityobScheduleDtlPeriodWiseListUpd, strCanclDtlIds);
       }
       //To check data Already exist in th table
       public string CheckDutyRoster(clsEntityLayerDutyRoster objEntityDutyRost)
       {

           string count = objDtalayerDutyroster.CheckDutyRoster(objEntityDutyRost);
           return count;
       }
       //For reading dutyslip details of a employee daywise
       public DataTable ReadDutyslipDtl(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadDutyslipDtl(objEntityDutyRost);
           return dtEmp;
       }
       //For inserting job submission details
       public void insertJobSbmsnDetails(clsEntityLayerDutyRoster objEntityDutyRost, List<clsEntityLayerSubmissionDtl> objEntityJobSubmsnDtlList, List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsList)
       {
           objDtalayerDutyroster.insertJobSbmsnDetails(objEntityDutyRost, objEntityJobSubmsnDtlList, objEntityAddtnlJobsList);
       }
       //To check dutyslip submitted for an employee on a date
       public string CheckDutySlpSubmsnSts(clsEntityLayerDutyRoster objEntityDutyRost)
       {

           string count = objDtalayerDutyroster.CheckDutySlpSubmsnSts(objEntityDutyRost);
           return count;
       }
       //For reading dutyslip submission time sheet  details of a employee daywise
       public DataTable ReadDutySlipSbmsnTimesheetDtl(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadDutySlipSbmsnTimesheetDtl(objEntityDutyRost);
           return dtEmp;
       }
       //For reading dutyslip job submission details of a employee daywise
       public DataTable ReadDutySlipSbmsnDtl(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadDutySlipSbmsnDtl(objEntityDutyRost);
           return dtEmp;
       }
       //For reading dutyslip submission additional jobs details of a employee daywise
       public DataTable ReadDutySlipSbmsnAddtnlJobDtl(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadDutySlipSbmsnAddtnlJobDtl(objEntityDutyRost);
           return dtEmp;
       }
       //For updating job submission details
       public void updateJobSbmsnDetails(clsEntityLayerDutyRoster objEntityDutyRost, List<clsEntityLayerSubmissionDtl> objEntityJobSubmsnDtlList, List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListAdd, List<clsEntityLayerJobScheduleDtl> objEntityAddtnlJobsListUpdate, string[] strCanclDtlIds)
       {
           objDtalayerDutyroster.updateJobSbmsnDetails(objEntityDutyRost, objEntityJobSubmsnDtlList, objEntityAddtnlJobsListAdd, objEntityAddtnlJobsListUpdate, strCanclDtlIds);
       }
       //To read status
       public DataTable ReadSts()
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadSts();
           return dtEmp;
       }
       // This Method will fetch emlpoyee wise leave details
       public DataTable ReadLeaveDtlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           DataTable dtEmp = objDtalayerDutyroster.ReadLeaveDtlByEmp(objEntityDutyRost);
           return dtEmp;
       }
       //For Re-open job schedule details
       public void reopenSubmision(clsEntityLayerDutyRoster objEntityDutyRost)
       {
           objDtalayerDutyroster.reopenSubmision(objEntityDutyRost);
       }
        //STOP:-EVM-0009

         //For reading week wise duty off
        public DataTable ReadWeeklyDutyOff(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpDuty = objDtalayerDutyroster.ReadWeeklyDutyOff(objEntityDutyRost);
            return dtEmpDuty;
        }
         //For reading month wise duty off
        public DataTable ReadMonthlyDutyOff(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpDuty = objDtalayerDutyroster.ReadMonthlyDutyOff(objEntityDutyRost);
            return dtEmpDuty;
        }
        //For confirming job schedule details
        public void confirmSubmision(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            objDtalayerDutyroster.confirmSubmision(objEntityDutyRost);
        }

         // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadDutyShdlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpDuty = objDtalayerDutyroster.ReadDutyShdlByEmp(objEntityDutyRost);
            return dtEmpDuty;
        }
         // This Method will fetch emlpoyee wise duty datas
        public DataTable ReadJobShdlForDayEmpDaywise(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpDuty = objDtalayerDutyroster.ReadJobShdlForDayEmpDaywise(objEntityDutyRost);
            return dtEmpDuty;
        }
        // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpDuty = objDtalayerDutyroster.ReadCorporateAddress(objEntityDutyRost);
            return dtEmpDuty;
        }
         // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadEmpDetail(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpDuty = objDtalayerDutyroster.ReadEmpDetail(objEntityDutyRost);
            return dtEmpDuty;
        }

          // This Method confirm submission details
        public void PrintStsUpdate(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            objDtalayerDutyroster.PrintStsUpdate(objEntityDutyRost);
        }

         // This Method will fetch emlpoyee wise leave details for a single day
        public DataTable ReadSingleLeaveDtlByEmp(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            DataTable dtEmpLeav = objDtalayerDutyroster.ReadSingleLeaveDtlByEmp(objEntityDutyRost);
            return dtEmpLeav;
        }

         public void AddLeavAlloctnDetails(clsEntityLayerDutyRoster objEntityDutyRost)
        {
            objDtalayerDutyroster.AddLeavAlloctnDetails(objEntityDutyRost);
        }
         public DataTable ReadDutyslipCreateOrNOt(clsEntityLayerDutyRoster objEntityDutyRost)
         {
             DataTable dtEmpLeav = objDtalayerDutyroster.ReadDutyslipCreateOrNOt(objEntityDutyRost);
             return dtEmpLeav;
         }

         public void updateScheduleDetails(List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseList, List<clsEntityLayerJobScheduleDtl> objEntityobScheduleDtlPeriodWiseListUpd, string[] strCanclDtlIds)
        {
            objDtalayerDutyroster.updateScheduleDetails(objEntityobScheduleDtlPeriodWiseList, objEntityobScheduleDtlPeriodWiseListUpd, strCanclDtlIds);
        }
         public DataTable readVhclDetails(clsEntityLayerDutyRoster objEntityDutyRost)
         {
             DataTable dtEmpLeav = objDtalayerDutyroster.readVhclDetails(objEntityDutyRost);
             return dtEmpLeav;
         }
         public void updateVhclMlg(clsEntityLayerDutyRoster objEntityDutyRost)
         {
             objDtalayerDutyroster.updateVhclMlg(objEntityDutyRost);
         }
        //Start:-EMP-0009
         public void UpdateDutySlipSts(clsEntityLayerDutyRoster objEntityDutyRost)
         {
             objDtalayerDutyroster.UpdateDutySlipSts(objEntityDutyRost);
         }
         public DataTable readEmpDateDtls(clsEntityLayerDutyRoster objEntityDutyRost)
         {
             DataTable dtEmpLeav = objDtalayerDutyroster.readEmpDateDtls(objEntityDutyRost);
             return dtEmpLeav;
         }

        //End:-EMP-0009
    }
}
