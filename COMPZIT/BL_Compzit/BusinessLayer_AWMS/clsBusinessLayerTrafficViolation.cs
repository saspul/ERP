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
// CREATED BY:EVM-0009
// CREATED DATE:30/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit.BusinessLayer_AWMS
{
   public class clsBusinessLayerTrafficViolation
    {  
       //To fetch vehicle number
       clsDataLayerTrafficViolation objDataLayerTrafficVltn = new clsDataLayerTrafficViolation();
       public DataTable ReadVehicleNumber(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtVehicleNumber = objDataLayerTrafficVltn.ReadVehicleNumber(objEntityLayerTrafficVltn);
           return dtVehicleNumber;
       }
       //To fetch employee name
       public DataTable ReadEmployee(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtEmp = objDataLayerTrafficVltn.ReadEmployee(objEntityLayerTrafficVltn);
           return dtEmp;
       }
       // This Method will fetch Employee  For autocompletion from WebService
       public DataTable ReadEmployeesWebService(string strLikeEmployee, clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReadEmployee = objDataLayerTrafficVltn.ReadEmployeesWebService(strLikeEmployee, objEntityLayerTrafficVltn);
           return dtReadEmployee;
       }
       // This Method will fetch Violation  For autocompletion from WebService
       public DataTable ReadViolationWebService(string strLikeViolation, clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReadViolation = objDataLayerTrafficVltn.ReadViolationWebService(strLikeViolation, objEntityLayerTrafficVltn);
           return dtReadViolation;
       }
       public DataTable ReadVehicleDtlByID(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReadVhcl = objDataLayerTrafficVltn.ReadWaterVehicleDtlByID(objEntityLayerTrafficVltn);
           return dtReadVhcl;
       }
       //Add  Details
       public int Insert_TrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn, List<clsEntityLayerTrafficViolationDtl> objEntityTraficVioltnDetails)
       {
           return objDataLayerTrafficVltn.Insert_TrafficVioltn(objEntityLayerTrafficVltn, objEntityTraficVioltnDetails);

       }
       // This Method will fetch traffic violation  list BY SEARCH
       public DataTable ReadTrficVioltnListBySearch(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReadList = objDataLayerTrafficVltn.ReadTrficVioltnListBySearch(objEntityLayerTrafficVltn);
           return dtReadList;
       }
       // This Method will fetch traffic violation details  BY ID
       public DataTable ReadTraficVioltnById(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReadDtl = objDataLayerTrafficVltn.ReadTraficVioltnById(objEntityLayerTrafficVltn);
           return dtReadDtl;
       }
       //Update  details to  table while reopening,add the value to traffic violation
       public void Reopen_TrficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           objDataLayerTrafficVltn.Reopen_TrficVioltn(objEntityLayerTrafficVltn);

       }
       //Method for recall Cancelled traffic violation
       public void ReCallCanceledTrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           objDataLayerTrafficVltn.ReCallCanceledTrafficVioltn(objEntityLayerTrafficVltn);

       }
       //Method for  Cancel traffic violation
       public void CancelTrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           objDataLayerTrafficVltn.CancelTrafficVioltn(objEntityLayerTrafficVltn);

       }
       // This Method FETCHES  DETAILS BASED ON  ID FOR DISPALYING
       public DataTable ReadTrafficVioltnDetail(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReadDtl = objDataLayerTrafficVltn.ReadTrafficVioltnDetail(objEntityLayerTrafficVltn);
           return dtReadDtl;
       }
       //Update  Details
       public void Update_TrafficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnInsertDetails, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnUpdateDetails, string[] strarrCancldtlIds)
       {
           objDataLayerTrafficVltn.Update_TrafficVioltn(objEntityLayerTrafficVltn, objEntityTrafficVioltnInsertDetails, objEntityTrafficVioltnUpdateDetails, strarrCancldtlIds);

       }
       //Confirm  Details
       public void Confirm_TraficVioltn(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnInsertDetails, List<clsEntityLayerTrafficViolationDtl> objEntityTrafficVioltnUpdateDetails, string[] strarrCancldtlIds)
       {
           objDataLayerTrafficVltn.Confirm_TraficVioltn(objEntityLayerTrafficVltn, objEntityTrafficVioltnInsertDetails, objEntityTrafficVioltnUpdateDetails, strarrCancldtlIds);

       }
       //Check Dup ReceiptNo
       public DataTable CheckDupReceiptNo(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           DataTable dtReceiptDtl = objDataLayerTrafficVltn.CheckDupReceiptNo(objEntityLayerTrafficVltn);
           return dtReceiptDtl;
       }
       public string CheckDupReceiptNoByID(clsEntityLayerTrafficViolation objEntityLayerTrafficVltn)
       {
           string strCnt = objDataLayerTrafficVltn.CheckDupReceiptNoByID(objEntityLayerTrafficVltn);
           return strCnt;
       }
    }
}
