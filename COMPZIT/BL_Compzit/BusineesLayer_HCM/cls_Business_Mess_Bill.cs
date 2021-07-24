using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Collections.Generic;
using System.Data;


namespace BL_Compzit.BusineesLayer_HCM
{
    public class cls_Business_Mess_Bill
    {
        clsData_Mess_Bill ObjdataMess = new clsData_Mess_Bill();
        //metghod to read accomodation
        public DataTable ReadAccomodation(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadAccomodation(objEntityMessBill);
            return dtData;

        }
        //to read mess bill
       public DataTable ReadMessBill_List(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadMessBill_List(objEntityMessBill);
            return dtData;

        }
         //read mess bill data by id
       public DataTable ReadMessBillData_ById(clsEntity_Mess_Bill objEntityMessBill)
       {
           DataTable dtData = ObjdataMess.ReadMessBillData_ById(objEntityMessBill);
           return dtData;

       }
         //to insert mess bill deatils
       public void InsertMessBill(clsEntity_Mess_Bill objEntityMessBill, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlList, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlMnthWiseList)
       {
           ObjdataMess.InsertMessBill(objEntityMessBill, objEntityMessEmpDtlList, objEntityMessEmpDtlMnthWiseList);
           
       }
         //update mess bill details
       public void UpdateMessBill(clsEntity_Mess_Bill objEntityMessBill, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlList, List<clsEntity_Mess_Bill_EMP_DTLS> objEntityMessEmpDtlMnthWiseList)
       {
           ObjdataMess.UpdateMessBill(objEntityMessBill, objEntityMessEmpDtlList, objEntityMessEmpDtlMnthWiseList);
       }
         //update mess bill details
       public void DeleteMessBill(clsEntity_Mess_Bill objEntityMessBill)
       {
           ObjdataMess.DeleteMessBill(objEntityMessBill);
       }
         //read mess bill data by id
        public DataTable ReadMessExemDataByDate(clsEntity_Mess_Bill objEntityMessBill)
       {
           DataTable dtData = ObjdataMess.ReadMessExemDataByDate(objEntityMessBill);
           return dtData;

       }
        //read mess Employee data by ACCOMODATION Id
        public DataTable ReadEmployee_ByAccoId(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadEmployee_ByAccoId(objEntityMessBill);
            return dtData;

        }
         // This method is for fetching the CORPORATE Address for showing in Print page
        public DataTable ReadCorporateAddress(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadCorporateAddress(objEntityMessBill);
            return dtData;
        }
        //To check duplication in mess BILL
        public DataTable CheckDuplication(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.CheckDuplication(objEntityMessBill);
            return dtData;
        }
        public DataTable ReadMessBackup(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadMessBackup(objEntityMessBill);
            return dtData;
        }
        public DataTable ReadCurrentMess(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadCurrentMess(objEntityMessBill);
            return dtData;
        }
        public DataTable ReadMessEmpDtl(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadMessEmpDtl(objEntityMessBill);
            return dtData;
        }

        public DataTable ReadEmployees(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadEmployees(objEntityMessBill);
            return dtData;
        }
        public DataTable CheckEmployeeMessDate(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.CheckEmployeeMessDate(objEntityMessBill);
            return dtData;
        }
        public DataTable ReadBusnsUnitsAcmdtn(clsEntity_Mess_Bill objEntityMessBill)
        {
            DataTable dtData = ObjdataMess.ReadBusnsUnitsAcmdtn(objEntityMessBill);
            return dtData;
        }


    }
}
