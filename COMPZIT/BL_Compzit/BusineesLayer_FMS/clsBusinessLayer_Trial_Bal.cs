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
  public  class clsBusinessLayer_Trial_Bal
    {

      clsDataLayer_Trial_Bal objDataPaymnt = new clsDataLayer_Trial_Bal();


        public DataTable TrailBalance_List(clsEntity_Trial_Bal objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataPaymnt.TrailBalance_List(objEntity);
          return dtRcpt;
      }
        public DataTable TrailBalance_ListLed(clsEntity_Trial_Bal objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.TrailBalance_ListLed(objEntity);
            return dtRcpt;
        }
        public DataTable TrailBalance_List_ById(clsEntity_Trial_Bal objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataPaymnt.TrailBalance_List_ById(objEntity);
          return dtRcpt;
      }
        public DataTable LedgerTransDtls(clsEntity_Trial_Bal objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.LedgerTransDtls(objEntity);
            return dtRcpt;
        }
        public DataTable ReadLedgOpenBal(clsEntity_Trial_Bal objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.ReadLedgOpenBal(objEntity);
            return dtRcpt;
        }
        public DataTable TrailBalance_List_Detail(clsEntity_Trial_Bal objEntity)
        {
            DataTable dtRcpt = new DataTable();
            dtRcpt = objDataPaymnt.TrailBalance_List_Detail(objEntity);
            return dtRcpt;
        }
    }
}
