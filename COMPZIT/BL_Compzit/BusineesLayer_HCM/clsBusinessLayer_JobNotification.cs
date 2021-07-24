using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsBusinessLayer_JobNotification
    {
       clsDataLayer_JobNotification objDataJobNotify = new clsDataLayer_JobNotification();

        public DataTable ReadDivision(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.ReadDivision(objEntityjob);
           return dtDiv;
       }
        public DataTable ReadDepartment(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDpt = objDataJobNotify.ReadDepartment(objEntityjob);
           return dtDpt;
       }
        public DataTable ReadDesignation(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDesig = objDataJobNotify.ReadDesignation(objEntityjob);
           return dtDesig;
       }
       public DataTable ReadConsultancies(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtConsult = objDataJobNotify.ReadConsultancies(objEntityjob);
           return dtConsult;
       }
       public DataTable ReadAprvdManPwrReqstList(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtList = objDataJobNotify.ReadAprvdManPwrReqstList(objEntityjob);
           return dtList;
       }
        public DataTable ReadProject(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtPrj = objDataJobNotify.ReadProject(objEntityjob);
           return dtPrj;
       }
        public DataTable ReadEmployee(clsEntityLayer_JobNotification objEntityjob)
        {
            DataTable dtPrj = objDataJobNotify.ReadEmployee(objEntityjob);
            return dtPrj;
        }
        public DataTable ReadManPwrReqstById(clsEntityLayer_JobNotification objEntityjob)
        {
             DataTable dtPrj = objDataJobNotify.ReadManPwrReqstById(objEntityjob);
            return dtPrj;
        }
       public DataTable ReadEmployeeById(clsEntityLayer_JobNotification objEntityjob)
        {
            DataTable dtEmp = objDataJobNotify.ReadEmployeeById(objEntityjob);
            return dtEmp;
        }
        public DataTable ReadDivisionById(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.ReadDivisionById(objEntityjob);
           return dtDiv;
       }
        public DataTable ReadConsultancyById(clsEntityLayer_JobNotification objEntityjob)
        {
            DataTable dtDiv = objDataJobNotify.ReadConsultancyById(objEntityjob);
            return dtDiv;
        }
       public DataTable ReadDepartmntById(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.ReadDepartmntById(objEntityjob);
           return dtDiv;
       }

       public DataTable ReadFromMailDetails(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.ReadFromMailDetails(objEntityjob);
           return dtDiv;
       }

       public DataTable CheckIsInserted(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.CheckIsInserted(objEntityjob);
           return dtDiv;
       }
       public void AddNotificationDetail(clsEntityLayer_JobNotification objEntityjob, List<clsEntityConsultDetail> objEntityConsultData, List<clsEntityDivisionDetail> objEntityDivisionData, List<clsEntityDepartmentDetail> objEntityDepartData, List<clsEntityEmployeeDetail> objEntityEmployData)
       {
           objDataJobNotify.AddNotificationDetail(objEntityjob, objEntityConsultData, objEntityDivisionData, objEntityDepartData, objEntityEmployData);
       }

        public void UpdateNotificationDetail(clsEntityLayer_JobNotification objEntityjob, List<clsEntityConsultDetail> objEntityConsultData, List<clsEntityDivisionDetail> objEntityDivisionData, List<clsEntityDepartmentDetail> objEntityDepartData, List<clsEntityEmployeeDetail> objEntityEmployData)
       {
           objDataJobNotify.UpdateNotificationDetail(objEntityjob, objEntityConsultData, objEntityDivisionData, objEntityDepartData, objEntityEmployData);
       }
        public DataTable ReadJobNotifyById(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.ReadJobNotifyById(objEntityjob);
           return dtDiv;
       }
        public DataTable ReadJobNotifyCnsltById(clsEntityLayer_JobNotification objEntityjob)
        {
            DataTable dtDiv = objDataJobNotify.ReadJobNotifyCnsltById(objEntityjob);
            return dtDiv;
        }
       public DataTable ReadJobNotifyDivById(clsEntityLayer_JobNotification objEntityjob)
        {
            DataTable dtDiv = objDataJobNotify.ReadJobNotifyDivById(objEntityjob);
            return dtDiv;
        }
        public DataTable ReadJobNotifyDepById(clsEntityLayer_JobNotification objEntityjob)
       {
           DataTable dtDiv = objDataJobNotify.ReadJobNotifyDepById(objEntityjob);
           return dtDiv;
       }
        public DataTable ReadJobNotifyEmpById(clsEntityLayer_JobNotification objEntityjob)
        {
            DataTable dtDiv = objDataJobNotify.ReadJobNotifyEmpById(objEntityjob);
            return dtDiv;
        }
    }
}
