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
   public class clsBusiness_BankReconciliation
    {

       clsDataLayer_BankReconciliation objDataPaymnt = new clsDataLayer_BankReconciliation();


       public DataTable ReadLeadger(clsEntityBankReconciliation objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.ReadLeadger(objEntity);
           return dtRcpt;
       }
       public DataTable BankReconciliation_List(clsEntityBankReconciliation objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.BankReconciliation_List(objEntity);
           return dtRcpt;
       }

       public DataTable ReadBankReconciliationById(clsEntityBankReconciliation objEntity)
       {
           DataTable dtRcpt = new DataTable();
           dtRcpt = objDataPaymnt.ReadBankReconciliationById(objEntity);
           return dtRcpt;
       }

       public void SaveReconciliation(clsEntityBankReconciliation objEntity, string[] strarrdtlIds)
       {
           DataTable dtRcpt = new DataTable();
           objDataPaymnt.SaveReconciliation(objEntity, strarrdtlIds);
         
       }
       public void Recall_Reconciled(clsEntityBankReconciliation objEntity)
       {
           objDataPaymnt.Recall_Reconciled(objEntity);
       }
    }
}
