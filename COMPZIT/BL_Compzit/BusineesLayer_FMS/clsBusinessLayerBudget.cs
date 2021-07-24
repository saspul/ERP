using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_FMS;
using DL_Compzit.DataLayer_FMS;
using System.Data;
namespace BL_Compzit.BusineesLayer_FMS
{
   public class clsBusinessLayerBudget
    {

       clsDataLayerBudget objDataLedger = new clsDataLayerBudget();
       public DataTable CheckDupName(clsEntityLayerBudget objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.CheckDupName(objEntityShortList);
            return dtDiv;
        }
       public DataTable ReadLedgerDdl(clsEntityJournal objEntityShortList)
        {
            DataTable dtDiv = objDataLedger.ReadLedgerDdl(objEntityShortList);
            return dtDiv;
        }
       
       public DataTable ReadBudgetList(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBudgetList(objEntityShortList);
           return dtDiv;
       }
       public DataTable ReadBdgtDtlsById(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBdgtDtlsById(objEntityShortList);
           return dtDiv;
       }
       public DataTable ReadBdgtLedgrDtlsById(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBdgtLedgrDtlsById(objEntityShortList);
           return dtDiv;
       }
       public DataTable ReadBdgtCostCntrDtlsById(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBdgtCostCntrDtlsById(objEntityShortList);
           return dtDiv;
       }
       public DataTable ReadBdgtLedgrDtlsByIdMnth(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBdgtLedgrDtlsByIdMnth(objEntityShortList);
           return dtDiv;
       }
       public DataTable ReadBdgtCostCntrDtlsByIdMnth(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBdgtCostCntrDtlsByIdMnth(objEntityShortList);
           return dtDiv;
       }
       public DataTable ReadBdgtYear(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.ReadBdgtYear(objEntityShortList);
           return dtDiv;
       }
       public void SubmitMonthDtls(clsEntityLayerBudget objEntityShortList, List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList, List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList)
       {
           objDataLedger.SubmitMonthDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
       }
       public DataTable CheckBdgtCnclSts(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtDiv = objDataLedger.CheckBdgtCnclSts(objEntityShortList);
           return dtDiv;
       }
       public void CancelBudget(clsEntityLayerBudget objEntityShortList)
       {
           objDataLedger.CancelBudget(objEntityShortList);
       }

       public void AddBudgetDtls(clsEntityLayerBudget objEntityShortList, List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList, List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList)
        {
            objDataLedger.AddBudgetDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
        }
       public void EditBudgetDtls(clsEntityLayerBudget objEntityShortList, List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList, List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList)
       {
           objDataLedger.EditBudgetDtls(objEntityShortList, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
       }
       public DataTable ReadFinancialYear(clsEntityLayerBudget objEntityShortList)
       {
           DataTable dtFin = new DataTable();
           dtFin = objDataLedger.ReadFinancialYear(objEntityShortList);
           return dtFin;
       }
    }
}
