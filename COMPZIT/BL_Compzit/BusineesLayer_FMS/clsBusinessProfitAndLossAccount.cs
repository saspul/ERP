using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;
namespace BL_Compzit.BusineesLayer_FMS
{
   public class clsBusinessProfitAndLossAccount
    {
       clsDataProfitAndLossAccount objDataPaymnt = new clsDataProfitAndLossAccount();


       public DataTable ProfitAndLossAcnt_List(clsEntityProfitAndLossAccount objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ProfitAndLossAcnt_List(objEntity);
            return dtRcpt;
        }
       public DataTable ProfitAndLossAcnt_List_ById(clsEntityProfitAndLossAccount objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.ProfitAndLossAcnt_List_ById(objEntity);
           return dtRcpt;
       }
       public DataTable Net_ProfitAndLossAcnt_List(clsEntityProfitAndLossAccount objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.Net_ProfitAndLossAcnt_List(objEntity);
           return dtRcpt;
       }
       public DataTable LedgerTransDtls(clsEntityProfitAndLossAccount objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.LedgerTransDtls(objEntity);
           return dtRcpt;
       }
       public DataTable ReadLedgOpenBal(clsEntityProfitAndLossAccount objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.ReadLedgOpenBal(objEntity);
           return dtRcpt;
       }
    }
}
