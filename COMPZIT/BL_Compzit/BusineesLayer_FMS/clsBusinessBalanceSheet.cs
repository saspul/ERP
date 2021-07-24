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
    public class clsBusinessBalanceSheet
    {
        clsDataLayerBalanceSheet objDataPaymnt = new clsDataLayerBalanceSheet();
        public DataTable ReadPrimaryGroupDetails(clsEntityBalanceSheet objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadPrimaryGroupDetails(objEntity);
            return dtRcpt;
        }
        public DataTable ReadSubGroupDetails(clsEntityBalanceSheet objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadSubGroupDetails(objEntity);
            return dtRcpt;
        }
        public DataTable ReadProfitLoss(clsEntityBalanceSheet objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadProfitLoss(objEntity);
            return dtRcpt;
        }
        public DataTable TrailBalance_List_ById(clsEntityBalanceSheet objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.TrailBalance_List_ById(objEntity);
            return dtRcpt;
        }
        public DataTable LedgerTransDtls(clsEntityBalanceSheet objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.LedgerTransDtls(objEntity);
            return dtRcpt;
        }
        public DataTable ReadLedgOpenBal(clsEntityBalanceSheet objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadLedgOpenBal(objEntity);
            return dtRcpt;
        }
    }
}
