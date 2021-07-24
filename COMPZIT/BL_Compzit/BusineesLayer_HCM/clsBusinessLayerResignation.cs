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
   public class clsBusinessLayerResignation
    {
       clsDataLayerResignation objDataResignation = new clsDataLayerResignation();
       public DataTable ReadEmpDetails(clsEntityLayerResignation objEntityResignation)
        {
            DataTable dtClearanceFormStaffList = objDataResignation.ReadEmpDetails(objEntityResignation);
            return dtClearanceFormStaffList;
        }
       public DataTable ReadNoticePrd(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = objDataResignation.ReadNoticePrd(objEntityResignation);
           return dtClearanceFormStaffList;
       }
       public DataTable ReadDivisionOfEmp(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = objDataResignation.ReadDivisionOfEmp(objEntityResignation);
           return dtClearanceFormStaffList;
       }
       public DataTable CheckEmp(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = objDataResignation.CheckEmp(objEntityResignation);
           return dtClearanceFormStaffList;
       }
       public void AddResignation(clsEntityLayerResignation objEntityResignation)
       {
           objDataResignation.AddResignation(objEntityResignation);
       }
       public void UpdateResignation(clsEntityLayerResignation objEntityResignation)
       {
           objDataResignation.UpdateResignation(objEntityResignation);
       }
       public void ConfirmResignation(clsEntityLayerResignation objEntityResignation)
       {
           objDataResignation.ConfirmResignation(objEntityResignation);
       }
       public void CancelResignation(clsEntityLayerResignation objEntityResignation)
       {
           objDataResignation.CancelResignation(objEntityResignation);
       }
       public void CancelClearnceDtls(clsEntityLayerResignation objEntityResignation)
       {
           objDataResignation.CancelClearnceDtls(objEntityResignation);
       }
       public void CancelClearnce(clsEntityLayerResignation objEntityResignation)
       {
           objDataResignation.CancelClearnce(objEntityResignation);
       }
       public DataTable ReadLvStfId(clsEntityLayerResignation objEntityResignation)
       {
           DataTable dtClearanceFormStaffList = objDataResignation.ReadLvStfId(objEntityResignation);
           return dtClearanceFormStaffList;
       }
    }
}
