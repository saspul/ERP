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
    public class clsBussiness_Emp_Transfer
    {
        cls_DataLayer_Emp_Transfer ObjDataEmpTransfer = new cls_DataLayer_Emp_Transfer();
         //FOR READING BUSSINESS UNIUTS
        public DataTable ReadBussinessUnit(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadBussinessUnit(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
         // FOR READING EMPLOYEES BY B U
        public DataTable ReadEmployees(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadEmployees(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
         //READ EMPLOYEE DETAILS BY ID
        public DataTable ReadEmployeesDetailsById(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadEmployeesDetailsById(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
         //READ ALL DEPARTMENTS
        public DataTable ReadCorporateDepartments(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadCorporateDepartments(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
         //READ ALL DIVISIONS
        public DataTable ReadDivisions(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadDivisions(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
        //READC ALL P[AYGRADES
        public DataTable ReadPaygrade(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadPaygrade(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
         //READ ALL SPOSEORS LIST
        public DataTable ReadSponsor(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadSponsor(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }

        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadProjects(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtBusinessUnit = ObjDataEmpTransfer.ReadProjects(ObjEntityEmpTransfer);
            return dtBusinessUnit;
        }
        public void InsertEmployeeTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer, List<clsEntity_Emp_Transfer> objEntitylayerDivList ,List<clsEntity_Emp_Transfer> objEntitylayerEmpList)
        {
            ObjDataEmpTransfer.InsertEmployeeTransfer(ObjEntityEmpTransfer, objEntitylayerDivList, objEntitylayerEmpList);
        }
         public void UpdateEmployeeTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer, List<clsEntity_Emp_Transfer> objEntitylayerDivList, List<clsEntity_Emp_Transfer> objEntitylayerEmpList)
        {
            ObjDataEmpTransfer.UpdateEmployeeTransfer(ObjEntityEmpTransfer, objEntitylayerDivList, objEntitylayerEmpList);
        }
         public void ConfirmEmpTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
         {
             ObjDataEmpTransfer.ConfirmEmpTransfer(ObjEntityEmpTransfer);
         }
         //READ EMPLOREE TRANSFER LIST
        public DataTable ReadEmployeeTransferList(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadEmployeeTransferList(ObjEntityEmpTransfer);
            return dtLIST;
        }
         //READ EMPLOYEE TRANSFER DETAILS BY ID 
        public DataTable ReadEmployeeTransferById(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadEmployeeTransferById(ObjEntityEmpTransfer);
            return dtLIST;
        }
           //READ ALL MAN POWER REQUEST LIST
        public DataTable ReadManpowerRequestList(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadManpowerRequestList(ObjEntityEmpTransfer);
            return dtLIST;
        }
        //READ ALL PROJECTS NAME LIST FOR DRPDOWN
        public DataTable ReadManpowerRequestDetailsById(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadManpowerRequestDetailsById(ObjEntityEmpTransfer);
            return dtLIST;
        }
        //READ EMPLOYEE LIST
        public DataTable ReadEmployeeList(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadEmployeeList(ObjEntityEmpTransfer);
            return dtLIST;
        }

        //UPDATE EMPLOYEE FROM AND TO DATE
        public void UpdateEmpTransferDates(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            ObjDataEmpTransfer.UpdateEmpTransferDates(ObjEntityEmpTransfer);
        }
        //READ EMPLOYEE TRANSFER FROM DATE AND TO DATE
        public DataTable ReadEmployeeTransferDate(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadEmployeeTransferDate(ObjEntityEmpTransfer);
            return dtLIST;
        }


        public DataTable ReadEmployeeTransfer(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadEmployeeTransfer(ObjEntityEmpTransfer);
            return dtLIST;

        }
        public DataTable ReadEmployeeTransferUsrId(clsEntity_Emp_Transfer ObjEntityEmpTransfer)
        {
            DataTable dtLIST = ObjDataEmpTransfer.ReadEmployeeTransferUsrId(ObjEntityEmpTransfer);
            return dtLIST;

        }
        public void updateUserId(clsEntity_Emp_Transfer ObjEntityEmpTransfer, List<clsEntity_Emp_Transfer> objEntitylayerEmpList)
        {
            ObjDataEmpTransfer.updateUserId(ObjEntityEmpTransfer, objEntitylayerEmpList);
        }
    }
}
