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
// CREATED BY:EVM-0001
// CREATED DATE:27/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
   public class clsBusinessLayerJobShdl
    {
       clsDataLayerJobShdl objDataLayerJobShdl = new clsDataLayerJobShdl();


       // This Method will fetch time slots
       public DataTable ReadTimeSlotMasters(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            DataTable dtReadDtl = objDataLayerJobShdl.ReadTimeSlotMasters(objEntityJobShdl);
            return dtReadDtl;
        }
        // This Method will FETCH DETAIL FROM TIMESLOT MASTER REGARDING THE TIMESLOT SELECTED
       public DataTable ReadTimeSlotById(clsEntityLayerJobSchedule objEntityJobShdl)
        {
            DataTable dtReadDtl = objDataLayerJobShdl.ReadTimeSlotById(objEntityJobShdl);
            return dtReadDtl;
        }
       // This Method will fetch Jobs  For autocompletion from WebService
       public DataTable ReadJobsWebService(string strLikeJobName, clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadJobs = objDataLayerJobShdl.ReadJobsWebService(strLikeJobName, objEntityJobShdl);
           return dtReadJobs;
       }
       // This Method will fetch Vehicles  For autocompletion from WebService
       public DataTable ReadVehiclesWebService(string strLikeVhclNumbr, clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadVehicles = objDataLayerJobShdl.ReadVehiclesWebService(strLikeVhclNumbr, objEntityJobShdl);
           return dtReadVehicles;
       }
       // This Method will fetch Projects  For autocompletion from WebService
       public DataTable ReadProjectsWebService(string strLikeProjectName, clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadProjects = objDataLayerJobShdl.ReadProjectsWebService(strLikeProjectName, objEntityJobShdl);
           return dtReadProjects;
       }
       // This Method will fetch Time  For autocompletion from WebService
       public DataTable ReadTimeListWebService(string strLikeTime, clsEntityLayerJobScheduleDtl objEntityJobShdlDtl)
       {
           DataTable dtReadTime = objDataLayerJobShdl.ReadTimeListWebService(strLikeTime, objEntityJobShdlDtl);
           return dtReadTime;
       }

       //Add  Details
       public int Insert_JobScheduling(clsEntityLayerJobSchedule objEntityJobShdl, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsPeriodWise, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsDayWise, List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtl)
       {
           return objDataLayerJobShdl.Insert_JobScheduling(objEntityJobShdl, objEntityJobScheduleDtlsPeriodWise, objEntityJobScheduleDtlsDayWise, objEntityJobScheduleWeekDayDtl);

       }

       // This Method FETCHES  DETAILS BASED ON  AND SHDLWISE_MODE ID FOR DISPALYING
       public DataTable ReadJobSchdlDetail(clsEntityLayerJobSchedule objEntityJobShdl, int intSchdlWiseMode)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadJobSchdlDetail(objEntityJobShdl,intSchdlWiseMode);
           return dtReadDtl;
       }
       // This Method FETCHES  DETAILS BASED ON  AND SHDLWISE_MODE ID FOR DISPALYING
       public DataTable ReadJobSchdlWeekDetail(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadJobSchdlWeekDetail(objEntityJobShdl);
           return dtReadDtl;
       }

       //Update  Details
       public void Update_JobScheduling(clsEntityLayerJobSchedule objEntityJobShdl, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsINSERTPeriodWise, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsUPDATEPeriodWise, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsINSERTDayWise, List<clsEntityLayerJobScheduleDtl> objEntityJobScheduleDtlsUPDATEDayWise, List<clsEntityLayerJobSchdlWeekDayDtl> objEntityJobScheduleWeekDayDtl, string[] strarrCancldtlIds)
       {
           objDataLayerJobShdl.Update_JobScheduling(objEntityJobShdl, objEntityJobScheduleDtlsINSERTPeriodWise, objEntityJobScheduleDtlsUPDATEPeriodWise, objEntityJobScheduleDtlsINSERTDayWise, objEntityJobScheduleDtlsUPDATEDayWise, objEntityJobScheduleWeekDayDtl, strarrCancldtlIds);

       }

       //start-0009
       // This Method will FETCH DETAIL FROM JOB SCEDULE MASTER REGARDING THE EMPLOYEE SELECTED
       public DataTable ReadFromToDateByUsrId(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadFromToDateByUsrId(objEntityJobShdl);
           return dtReadDtl;
       }
       // This Method will fetch Employee job schedule details
       public DataTable ReadEmployeeJSList(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadEmployeeJSList(objEntityJobShdl);
           return dtReadDtl;
       }
       // This Method will fetch number of job schedule against a employee 
       public DataTable ReadEmployeeNoOfJSList(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadEmployeeNoOfJSList(objEntityJobShdl);
           return dtReadDtl;
       }
       // This Method will fetch  employee name
       public DataTable ReadEmpName(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadEmpName(objEntityJobShdl);
           return dtReadDtl;
       }
       public void CloseSchedule(clsEntityLayerJobSchedule objEntityJobShdl)
       {

           objDataLayerJobShdl.CloseSchedule(objEntityJobShdl);
       }
       //stop-0009
       //EVM-0012 start
       public void JobScheduleConfirmRecl(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           objDataLayerJobShdl.JobScheduleConfirmRecl(objEntityJobShdl);
       }
        // METHOD TO FETCH TIME OF VHCL BY START ANS END DATE
       public DataTable ReadVhclDtlByDate(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadVhclDtlByDate(objEntityJobShdl);
           return dtReadDtl;
       }
        //EVM-0012 end
       public DataTable ReadDutyRstr(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadDutyRstr(objEntityJobShdl);
           return dtReadDtl;
       }
       public DataTable readVhclScdldDtls(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.readVhclScdldDtls(objEntityJobShdl);
           return dtReadDtl;
       }
       public DataTable readDays(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.readDays(objEntityJobShdl);
           return dtReadDtl;
       }
      //Start:-EMP-0009
       public DataTable readVhclScdldDtlsDuty(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.readVhclScdldDtlsDuty(objEntityJobShdl);
           return dtReadDtl;
       }
       public DataTable ReadPrjctByVhcl(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.ReadPrjctByVhcl(objEntityJobShdl);
           return dtReadDtl;
       }


       public DataTable readVhclScdldDtlsScdlID(clsEntityLayerJobSchedule objEntityJobShdl)
       {
           DataTable dtReadDtl = objDataLayerJobShdl.readVhclScdldDtlsScdlID(objEntityJobShdl);
           return dtReadDtl;
       }
      
       //End:-EMP-0009
    }
}
