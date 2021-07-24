using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class cls_Business_Bulk_LabourCard_Print
    {
        cls_Data_Bulk_LabourCard_Print objData = new cls_Data_Bulk_LabourCard_Print();
        public DataTable LoadDep(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            DataTable dt = objData.LoadDep(objEntityBulkPrint);
            return dt;
        }

        public DataTable ReadEmployeeCode(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            DataTable dt = objData.ReadEmployeeCode(objEntityBulkPrint);
            return dt;
        }

        public DataTable ReadEmployeeDetailsList(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            DataTable dt = objData.ReadEmployeeDetailsList(objEntityBulkPrint);
            return dt;
        }
        public DataTable LoadSalaryPrssPaymentTable(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            DataTable dt = objData.LoadSalaryPrssPaymentTable(objEntityBulkPrint);
            return dt;
        }

        //EVM-0043
        public DataTable EmailId(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {

            DataTable dt = objData.EmailIdFetch(objEntityBulkPrint);
            return dt;
        }
        public void UpdateMailid(cls_Entity_Bulk_LabourCard_Print objEntityBulkPrint)
        {
            objData.UpdateEmail(objEntityBulkPrint);
        }
        //EVM-OO43 end

    }
}
