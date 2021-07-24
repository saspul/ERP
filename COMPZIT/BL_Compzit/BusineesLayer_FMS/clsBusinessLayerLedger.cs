using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_FMS;
using DL_Compzit.DataLayer_FMS;
using System.Data;
namespace BL_Compzit.BusinessLayer_FMS
{
  public  class clsBusinessLayerLedger
    {
      clsDalaLayerLedger objDataLedger = new clsDalaLayerLedger();
      public DataTable ReadTDS(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadTDS(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadTCS(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadTCS(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadAccountGrps(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadAccountGrps(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadAccountGrpsLedgr(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadAccountGrpsLedgr(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadLedgers(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadLedgers(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadCurrencies(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadCurrencies(objEntityShortList);
          return dtDiv;
      }
      public DataTable CheckLedgerCnclSts(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.CheckLedgerCnclSts(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadLedgerList(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadLedgerList(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadLedgerDtlsById(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadLedgerDtlsById(objEntityShortList);
          return dtDiv;
      }
      public DataTable CheckDupName(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.CheckDupName(objEntityShortList);
          return dtDiv;
      }
     
      public void AddLedger(clsEntityLedger objEntityShortList, List<clsEntityLedger> objEntitySubLdgrList)
      {
          objDataLedger.AddLedger(objEntityShortList, objEntitySubLdgrList);
        
      }
      public void UpdateLedger(clsEntityLedger objEntityEmpSlry, List<clsEntityLedger> objEntitySubLdgrList)
      {
          objDataLedger.UpdateLedger(objEntityEmpSlry, objEntitySubLdgrList);
      }
      public void CancelLedger(clsEntityLedger objEntityShortList)
      {
          objDataLedger.CancelLedger(objEntityShortList);
      }
      public DataTable ReadLedgerTaxationSystem(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadLedgerTaxationSystem(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadAddressApplicable(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadAddressApplicable(objEntityShortList);
          return dtDiv;
      }
      public DataTable CheckAccountGroup(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.CheckAccountGroup(objEntityShortList);
          return dtDiv;
      }
      public DataTable ReadAccountGrp_Of_Ledgr(clsEntityLedger objEntityShortList)
      {
          DataTable dtDiv = objDataLedger.ReadAccountGrp_Of_Ledgr(objEntityShortList);
          return dtDiv;
      }

      public string CheckCodeDuplicatn(clsEntityLedger objEntityAccountGroup)
      {
          string count = objDataLedger.CheckCodeDuplicatn(objEntityAccountGroup);
          return count;
      }

      public DataTable ReadSubLedgers(clsEntityLedger objEntityEmpSlry)
      {
          DataTable dtDiv = objDataLedger.ReadSubLedgers(objEntityEmpSlry);
          return dtDiv;
      }

      //evm 0044
      public DataTable LoadLedgerBYId(clsEntityLedger  objEntityLedger)
      {
          DataTable dtAccountdetails = objDataLedger.LoadLedgerById (objEntityLedger );
          return dtAccountdetails;
      }
      public void UpdateLedgerId(int ledgerId)
      {
          objDataLedger.UpdateLedgerId (ledgerId );
      }
        //----------
    }
}
