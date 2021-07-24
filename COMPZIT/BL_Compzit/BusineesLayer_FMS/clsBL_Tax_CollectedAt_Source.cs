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
   public class clsBL_Tax_CollectedAt_Source
    {

       clsDL_Tax_CollectedAt_Source objDataPerformance = new clsDL_Tax_CollectedAt_Source();
       public void InsertTaxDeducted(clsEntityLayer_Tax_CollectedAt_Source objEntityPerformanceIssue)
        {
            objDataPerformance.InsertTaxDeducted(objEntityPerformanceIssue);
        }

       public void UpdateTaxDeducted(clsEntityLayer_Tax_CollectedAt_Source objEntityPerformanceIssue)
       {
           objDataPerformance.UpdateTaxDeducted(objEntityPerformanceIssue);
       }



       public DataTable DuplicationCheckTaxName(clsEntityLayer_Tax_CollectedAt_Source objEntityPerformanceIssue)
       {
           DataTable dtDept = new DataTable();
           dtDept = objDataPerformance.DuplicationCheckTaxName(objEntityPerformanceIssue);
           return dtDept;
       }
       public DataTable ReadTaxDeductionList(clsEntityLayer_Tax_CollectedAt_Source objEntityPerformanceIssue)
       {
           DataTable dtDept = new DataTable();
           dtDept = objDataPerformance.ReadTaxDeductionList(objEntityPerformanceIssue);
           return dtDept;
       }

       public void CancelPerfomanceTemplate(clsEntityLayer_Tax_CollectedAt_Source objEntityPerformanceIssue)
       {
           objDataPerformance.CancelPerfomanceTemplate(objEntityPerformanceIssue);
       }

       public DataTable ReadTaxDeductionById(clsEntityLayer_Tax_CollectedAt_Source objEntityPerformanceIssue)
       {
           DataTable dtDept = new DataTable();
           dtDept = objDataPerformance.ReadTaxDeductionById(objEntityPerformanceIssue);
           return dtDept;
       }
       
    }
}
