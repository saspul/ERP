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
    public class clsBusinessLayerClearanceFormStaff
    {
        //Read employee list
        public DataTable ReadEmployee(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaffList = objDataClearanceFormStaff.ReadEmployee(objEntityClearanceFormStaff);
            return dtClearanceFormStaffList;
        }

        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertClearanceFormStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objClearanceFormStaffDtls, List<clsEntityClearanceFormStaffSub> objClearanceFormStaffSub)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            objDataClearanceFormStaff.InsertClearanceFormStaff(objEntityClearanceFormStaff, objClearanceFormStaffDtls, objClearanceFormStaffSub);
        }

        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityClearanceFormStaff, objEntityClearanceFormStaffINSERTList, objEntityClearanceFormStaffUPDATEList, objEntityClearanceFormStaffDELETEList)
        public void UpdateClearanceFormStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlINSERTList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlUPDATEList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlDELETEList, List<clsEntityClearanceFormStaffSub> objEntityStaffSubUPDATEList)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            objDataClearanceFormStaff.UpdateClearanceFormStaff(objEntityClearanceFormStaff, objEntityStaffDtlINSERTList, objEntityStaffDtlUPDATEList, objEntityStaffDtlDELETEList, objEntityStaffSubUPDATEList);
        }
        //Read leave details
        public DataTable ReadLeaveDtls(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaffByID = objDataClearanceFormStaff.ReadLeaveDtls(objEntityClearanceFormStaff);

            return dtClearanceFormStaffByID;
        }
        //Read employee details
        public DataTable ReadEmployeeDtls(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormWorkerByID = objDataClearanceFormStaff.ReadEmployeeDtls(objEntityClearanceFormStaff);

            return dtClearanceFormWorkerByID;
        }


        //Read ClearanceFormStaff  
        public DataTable ReadClearanceFormStaffByID(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadClearanceFormStaffByID(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
        //Read ClearanceFormStaff  Sub
        public DataTable ReadClrFormStaffSubByID(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadClrFormStaffSubByID(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
        //Read ClearanceFormStaff  Details
        public DataTable ReadClrFormStaffDetailByID(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadClrFormStaffDetailByID(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
        //Start:-EMP-0009
        //For approving clearance form staff details

        public void ApproveClrncStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff){
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            objDataClearanceFormStaff.ApproveClrncStaff(objEntityClearanceFormStaff);
        }

        //For rejecting clearance form staff details
        public void RejectClrncStaff(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            objDataClearanceFormStaff.RejectClrncStaff(objEntityClearanceFormStaff);
        }
        //End:-EMP-0009
        public DataTable ReadDivisionOfEmp(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadDivisionOfEmp(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
       
  //For resignation form

        //Read leave details
        public DataTable ReadLeaveDtlsResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaffByID = objDataClearanceFormStaff.ReadLeaveDtlsResg(objEntityClearanceFormStaff);
            return dtClearanceFormStaffByID;
        }
        //Read ClearanceFormStaff  
        public DataTable ReadClearanceFormStaffByIDResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadClearanceFormStaffByIDResg(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
        //Read ClearanceFormStaff  Sub
        public DataTable ReadClrFormStaffSubByIDResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadClrFormStaffSubByIDResg(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
        //Read ClearanceFormStaff  Details
        public DataTable ReadClrFormStaffDetailByIDResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadClrFormStaffDetailByIDResg(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertClearanceFormStaffResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objClearanceFormStaffDtls, List<clsEntityClearanceFormStaffSub> objClearanceFormStaffSub)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            objDataClearanceFormStaff.InsertClearanceFormStaffResg(objEntityClearanceFormStaff, objClearanceFormStaffDtls, objClearanceFormStaffSub);
        }

        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityClearanceFormStaff, objEntityClearanceFormStaffINSERTList, objEntityClearanceFormStaffUPDATEList, objEntityClearanceFormStaffDELETEList)
        public void UpdateClearanceFormStaffResg(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlINSERTList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlUPDATEList, List<clsEntityClearanceFormStaffDetail> objEntityStaffDtlDELETEList, List<clsEntityClearanceFormStaffSub> objEntityStaffSubUPDATEList)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            objDataClearanceFormStaff.UpdateClearanceFormStaffResg(objEntityClearanceFormStaff, objEntityStaffDtlINSERTList, objEntityStaffDtlUPDATEList, objEntityStaffDtlDELETEList, objEntityStaffSubUPDATEList);
        }
        //Read Leave date, Resign date, Exit process date
        public DataTable ReadFromDate(clsEntityLayerClearanceFormStaff objEntityClearanceFormStaff)
        {
            clsDataLayerClearanceFormStaff objDataClearanceFormStaff = new clsDataLayerClearanceFormStaff();
            DataTable dtClearanceFormStaff = objDataClearanceFormStaff.ReadFromDate(objEntityClearanceFormStaff);
            return dtClearanceFormStaff;
        }
    }
}
