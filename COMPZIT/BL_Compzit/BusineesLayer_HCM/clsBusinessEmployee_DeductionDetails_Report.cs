using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
namespace BL_Compzit.BusineesLayer_HCM
{
  public  class clsBusinessEmployee_DeductionDetails_Report
    {
 clsDataEmployee_DeductionDetails_Report objDataEmployeeDeduction = new clsDataEmployee_DeductionDetails_Report();

 public DataTable ReadDivision(clsEntityEmployee_DeductionDetails_Report objEntityjob)
 {
     DataTable dtDiv = objDataEmployeeDeduction.ReadDivision(objEntityjob);
     return dtDiv;
 }
 public DataTable ReadDepartment(clsEntityEmployee_DeductionDetails_Report objEntityjob)
 {
     DataTable dtDpt = objDataEmployeeDeduction.ReadDepartment(objEntityjob);
     return dtDpt;
 }
 public DataTable ReadDesignation(clsEntityEmployee_DeductionDetails_Report objEntityjob)
 {
     DataTable dtDesig = objDataEmployeeDeduction.ReadDesignation(objEntityjob);
     return dtDesig;
 }
 public DataTable ReadDeductionList(clsEntityEmployee_DeductionDetails_Report objEntityjob)
 {
     DataTable dtDesig = objDataEmployeeDeduction.ReadDeductionList(objEntityjob);
     return dtDesig;
 }
 public DataTable ReadDeductionById(clsEntityEmployee_DeductionDetails_Report objEntityjob)
 {
     DataTable dtDesig = objDataEmployeeDeduction.ReadDeductionById(objEntityjob);
     return dtDesig;
 }
 public DataTable ReadCorporateAddress(clsEntityEmployee_DeductionDetails_Report objEntityjob)
 {
     DataTable dtDesig = objDataEmployeeDeduction.ReadCorporateAddress(objEntityjob);
     return dtDesig;
 }
    }
}
