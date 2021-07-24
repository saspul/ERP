using DL_Compzit.DataLayer_AWMS;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_AWMS;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL_Compzit.BusineesLayer_HCM
{
    public class cls_Business_Mess_Exemption
    {
        clsDataLayer_Mess_Exemption ObjdataMess = new clsDataLayer_Mess_Exemption();
        //method to read employee
        public DataTable ReadEmployee(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtMess = ObjdataMess.ReadEmployee(objEntityMessExcept);
            return dtMess;
        }
        //metghod to read accomodation
         public DataTable ReadAccomodation(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtMess = ObjdataMess.ReadAccomodation(objEntityMessExcept);
            return dtMess;
        }
         //to read mess exception
         public DataTable ReadMessException_List(clsEntity_Mess_Exemption objEntityMessExcept)
         {
             DataTable dtMess = ObjdataMess.ReadMessException_List(objEntityMessExcept);
             return dtMess;
         }
         //read mess exception data by id
        public DataTable ReadMessExceptionData_ById(clsEntity_Mess_Exemption objEntityMessExcept)
        {

            DataTable dtMess = ObjdataMess.ReadMessExceptionData_ById(objEntityMessExcept);
            return dtMess;
        }
        //to insert mess exception deatils
        public void InsertMessExcept(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            ObjdataMess.InsertMessExcept(objEntityMessExcept);

        }
        //update mess exception details
        public void UpdateMessExcept(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            ObjdataMess.UpdateMessExcept(objEntityMessExcept);
        }
         //read mess Employee data by ACCOMODATION Id
        public DataTable ReadEmployee_ByAccoId(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtMess = ObjdataMess.ReadEmployee_ByAccoId(objEntityMessExcept);
            return dtMess;
        }
         //To read the divisions of an employee
        public DataTable ReadDivisionOfEmp(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtMess = ObjdataMess.ReadDivisionOfEmp(objEntityMessExcept);
            return dtMess;
        }
         //To read the DATA of an employee
        public DataTable ReadEmpDetailById(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtMess = ObjdataMess.ReadEmpDetailById(objEntityMessExcept);
            return dtMess;
        }

         //To check duplication in mess exemption
        public DataTable CheckDuplication(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtMess = ObjdataMess.CheckDuplication(objEntityMessExcept);
            return dtMess;
        }

        //evm-0023
        public DataTable ReadMessBackup(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtData = ObjdataMess.ReadMessBackup(objEntityMessExcept);
            return dtData;
        }
        public DataTable ReadCurrentMess(clsEntity_Mess_Exemption objEntityMessExcept)
        {
            DataTable dtData = ObjdataMess.ReadCurrentMess(objEntityMessExcept);
            return dtData;
        }
    }
}
