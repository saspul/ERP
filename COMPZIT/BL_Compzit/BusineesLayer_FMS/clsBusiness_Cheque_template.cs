using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using DL_Compzit.DataLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL_Compzit.BusineesLayer_FMS
{
    public class clsBusiness_Cheque_template
    {

        clsDataLayerChequeTemplate objDataChequeTemplate = new clsDataLayerChequeTemplate();
        public void InsertChequeTemplte(clsEntityChequeTemplate objEntityPerformanceIssue)
        {
            objDataChequeTemplate.InsertChequeTemplte(objEntityPerformanceIssue);
        }

        public void UpdateChequeTemplte(clsEntityChequeTemplate objEntityPerformanceIssue)
        {
            objDataChequeTemplate.UpdateChequeTemplte(objEntityPerformanceIssue);
        }
        public string DuplicationCheckName(clsEntityChequeTemplate objEntityPerformanceIssue)
        {
            string dtDept = "";
            dtDept = objDataChequeTemplate.DuplicationCheckName(objEntityPerformanceIssue);
            return dtDept;
        }
        public DataTable ReadList(clsEntityChequeTemplate objEntityPerformanceIssue)
        {
            DataTable dtDept = new DataTable();
            dtDept = objDataChequeTemplate.ReadList(objEntityPerformanceIssue);
            return dtDept;
        }

        public void CancelChequeTemplate(clsEntityChequeTemplate objEntityPerformanceIssue)
        {
            objDataChequeTemplate.CancelChequeTemplate(objEntityPerformanceIssue);
        }

        public DataTable ReadTemplateById(clsEntityChequeTemplate objEntityPerformanceIssue)
        {
            DataTable dtDept = new DataTable();
            dtDept = objDataChequeTemplate.ReadTemplateById(objEntityPerformanceIssue);
            return dtDept;
        }

    }
}
