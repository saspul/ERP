using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusinessLayer_HCM
{
   public class clsBusinessLayerPayroll
    {
       clsDatalayerPayroll ObjDataPayrl = new clsDatalayerPayroll();
        public DataTable FetchPayrollDetails(clsEntityLayerPayroll objEntityPayrol)
        {

            DataTable dtfetch = ObjDataPayrl.Fetch_Payroll_Details(objEntityPayrol);
            return dtfetch;
        }

        public DataTable FetchPayrollDetails_List(clsEntityLayerPayroll objEntityPayrol)
        {

            DataTable dtfetch = ObjDataPayrl.Fetch_Payroll_Details_List(objEntityPayrol);
            return dtfetch;
        }

        public void AddPayrolDetails(clsEntityLayerPayroll objEntityPayrol)
        {
            ObjDataPayrl.Add_Payroll_Details(objEntityPayrol);
        }
        public void updatePayrol(clsEntityLayerPayroll objEntityPayrol)
        {
            ObjDataPayrl.Update_Payroll(objEntityPayrol);
        }
        public void ChangeStatus(clsEntityLayerPayroll objEntityPayrol)
        {
            ObjDataPayrl.Change_Status(objEntityPayrol);
        }

        public void CancelPayroll(clsEntityLayerPayroll objEntityPayrol)
        {
            ObjDataPayrl.Cancel_Payroll(objEntityPayrol);
        }
        
        //Update/view Data Fetch 
        public DataTable getDataById(clsEntityLayerPayroll ObjEntitityPayrl)
        {
            DataTable dt = new DataTable();
            dt = ObjDataPayrl.getDataById(ObjEntitityPayrl);
            return dt;
        }
        public string FetchPayrollName(clsEntityLayerPayroll objEntityPayrol)
        {

            string fetchcount = ObjDataPayrl.Fetch_Payroll_Name(objEntityPayrol);
            return fetchcount;
        }
        public string FetchPayrollCode(clsEntityLayerPayroll objEntityPayrol)
        {

            string fetchcount = ObjDataPayrl.FetchPayrollCode(objEntityPayrol);
            return fetchcount;
        }
    }
}
