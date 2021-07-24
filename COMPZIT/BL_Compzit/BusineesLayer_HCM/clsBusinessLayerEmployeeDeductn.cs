using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
   
    public class clsBusinessLayerEmployeeDeductn
    {
        clsDatalayerEmployeeDeduction objDataEmployeeDeduction = new clsDatalayerEmployeeDeduction();
        //public DataTable FetchPayrollDetails(clsEntityLayerPayroll objEntityPayrol)
        //{

        //    DataTable dtfetch = objDataEmployeeDeduction.Add_Deduction_Master(objEntityPayrol);
        //    return dtfetch;
        //}
        public void Add_Deduction_Details(ClsEntityEmployeeDeduction objEntityEmployeeDeduction, List <ClsEntityEmployeeDeduction>  objEntityEmployeeDeductionlist)
        {
            objDataEmployeeDeduction.Add_Deduction_Master(objEntityEmployeeDeduction,objEntityEmployeeDeductionlist);
        }
        public void Update_Installement(ClsEntityEmployeeDeduction objEntityEmployeeDeduction, List<ClsEntityEmployeeDeduction> objEntityEmployeeDeductionlist, string instmtStatus)
        {
            objDataEmployeeDeduction.Update_Deduction_Master(objEntityEmployeeDeduction, objEntityEmployeeDeductionlist, instmtStatus);
        }
        public DataTable ReadDeductionList(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            return objDataEmployeeDeduction.ReadDeductionList(objEntityEmployeeDeduction);
        }
        public DataTable ReadDeductionById(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            return objDataEmployeeDeduction.ReadDeductionById(objEntityEmployeeDeduction);
        }
        public DataTable ReadInstallmentDeductionById(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            return objDataEmployeeDeduction.ReadInstallmentDeductionById(objEntityEmployeeDeduction);
        }
        public void CancelPayroll(clsEntityLayerPayroll objEntityPayrol)
        {
            objDataEmployeeDeduction.Cancel_Payroll(objEntityPayrol);
        }
        public void ConfirmDedcution(ClsEntityEmployeeDeduction objEntityPayrol)
        {
            objDataEmployeeDeduction.ConfirmDedcution(objEntityPayrol);
        }
        //Update/view Data Fetch 
        public string CheckDocNum(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        { return objDataEmployeeDeduction.CheckDocNum(objEntityEmployeeDeduction); }
        public void DeleDeductionById(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            objDataEmployeeDeduction.DeleDeductionById(objEntityEmployeeDeduction);
        }
        public DataTable CheckEffctveDate(ClsEntityEmployeeDeduction objEntityEmployeeDeduction)
        {
            return objDataEmployeeDeduction.CheckEffctveDate(objEntityEmployeeDeduction);
        }
        public void ReopenDedcution(ClsEntityEmployeeDeduction objEntityPayrol)
        {
            objDataEmployeeDeduction.ReopenDedcution(objEntityPayrol);
        }
      
    }

}
