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
// CREATED DATE:24/11/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
   public class clsBussinesLayerVehicleStatusMngmnt
    {
        // This Method will fetch WATER CARD DETAILS
       public DataTable ReadVehicles(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtVehicle = objDataLayerVehicleSts.ReadVehicles(ObjVehicleStatus);
            return dtVehicle;
        }
               // This Method will fetch DIVISION details
        public DataTable ReadDivision(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
       {
           clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
           DataTable dtDivision = objDataLayerVehicleSts.ReadDivision(ObjVehicleStatus);
           return dtDivision;
       }
        // This Method will fetch PROJECT details
        public DataTable ReadProject(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtProject = objDataLayerVehicleSts.ReadProject(ObjVehicleStatus);
            return dtProject;
        }
            // This Method will fetch EMPLOYEE details
        public DataTable ReadEmployee(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtEmp = objDataLayerVehicleSts.ReadEmployee(ObjVehicleStatus);
            return dtEmp;
        }

        // This Method will fetch EMPLOYEE details
        public DataTable ReadVehicleStatsType(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtEmp = objDataLayerVehicleSts.ReadVehicleStatsType(ObjVehicleStatus);
            return dtEmp;
        }
       // This Method will fetch EMPLOYEE details
        public DataTable ReadVehicleStats(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtEmp = objDataLayerVehicleSts.ReadVehicleStats(ObjVehicleStatus);
            return dtEmp;
        }
        public void AddAssignVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.AddAssignVehicle(ObjVehicleStatus);
        }
          public void UpdateAssignVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.UpdateAssignVehicle(ObjVehicleStatus);
        }
        public void MakeAvailVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.MakeAvailVehicle(ObjVehicleStatus);
        }
        public void CancelAssignVehicle(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.CancelAssignVehicle(ObjVehicleStatus);
        }
        public void CancelOtherStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.CancelOtherStatus(ObjVehicleStatus);
        }
                 // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehcicleStatusDetail(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtEmp = objDataLayerVehicleSts.ReadVehcicleStatusDetail(ObjVehicleStatus);
            return dtEmp;
        }
               // This Method checks water card number in the database for duplication.
        public string CheckDateInAsgn(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            string Count=objDataLayerVehicleSts.CheckDateInAsgn(ObjVehicleStatus);
            return Count;
        }

        public void CloseVehicleStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.CloseVehicleStatus(ObjVehicleStatus);
        }
        public void ConfirmVehicleStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.ConfirmVehicleStatus(ObjVehicleStatus);
        }
               // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadStatusNotConfirmBydate(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtList = objDataLayerVehicleSts.ReadStatusNotConfirmBydate(ObjVehicleStatus);
            return dtList;
        }
               public DataTable ReadVehicleAssignListById(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtList = objDataLayerVehicleSts.ReadVehicleAssignListById(ObjVehicleStatus);
            return dtList;
        }
              // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehicleAssignDetailsById(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtList = objDataLayerVehicleSts.ReadVehicleAssignDetailsById(ObjVehicleStatus);
            return dtList;
        }

               // This Method will fetch ASSIGN details BY VEH ID
        public DataTable ReadVehicleAssignForAllocate(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtList = objDataLayerVehicleSts.ReadVehicleAssignForAllocate(ObjVehicleStatus);
            return dtList;
        }

        public void AutoCloseStatus(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            objDataLayerVehicleSts.AutoCloseStatus(ObjVehicleStatus);
        }
         
               // This Method will fetch Vehicle nUmber
        public DataTable ReadVehNumber(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtList = objDataLayerVehicleSts.ReadVehNumber(ObjVehicleStatus);
            return dtList;
        }
               // This Method will fetCH Vehicle Number
        public DataTable ReadVehicleNumber(clsEntityVehicleStatusMngmnt ObjVehicleStatus)
        {
            clsDataLayerVehicleStatusMngmnt objDataLayerVehicleSts = new clsDataLayerVehicleStatusMngmnt();
            DataTable dtList = objDataLayerVehicleSts.ReadVehicleNumber(ObjVehicleStatus);
            return dtList;
        }
    }
}
