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
  public  class clsBusiness_Account_Setting
    {

      clsDataLayer_Account_Setting objDataAccount = new clsDataLayer_Account_Setting();
      public DataTable ReadAccountGrpMapping(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadAccountGrpMapping(objEntity);
          return dtRcpt;
      }
      public DataTable CheckPrimaryAccountGrp(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.CheckPrimaryAccountGrp(objEntity);
          return dtRcpt;
      }
      public DataTable ReadHeadGrpMapping(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadHeadGrpMapping(objEntity);
          return dtRcpt;
      }
      public DataTable ReadAccountGrp(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadAccountGrp(objEntity);
          return dtRcpt;
      }
      public DataTable ReadLedgerPurchase(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadLedgerPurchase(objEntity);
          return dtRcpt;
      }
      public DataTable ReadLedgerSale(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadLedgerSale(objEntity);
          return dtRcpt;
      }
      public DataTable ReadFinancialYear(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadFinancialYear(objEntity);
          return dtRcpt;
      }
      public void InsertPrimaryAccountGroup(clsEntity_Account_Setting objEntity)
      {
          objDataAccount.InsertPrimaryAccountGroup(objEntity);
      }
      public void InsertAccount_Setting(clsEntity_Account_Setting objEntity, List<clsEntity_Account_Setting> ObjEntityGroup, List<clsEntity_Account_Setting> ObjEntityHead, List<clsEntity_Account_Setting> ObjEntityFinancialYear, List<clsEntity_Account_Setting> ObjEntityFYrCancel, List<clsEntity_Account_Setting> ObjEntityVersions, List<clsEntity_Account_Setting> objEntityPrmryGrp)
      {
          objDataAccount.InsertAccount_Setting(objEntity, ObjEntityGroup, ObjEntityHead, ObjEntityFinancialYear, ObjEntityFYrCancel, ObjEntityVersions, objEntityPrmryGrp);
      }
      public DataTable CheckFinancialYear(clsEntity_Account_Setting objEntity)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.CheckFinancialYear(objEntity);
          return dtRcpt;
      }
      public DataTable ReadLedgerByNature(clsEntity_Account_Setting objEntityEmpSlry)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadLedgerByNature(objEntityEmpSlry);
          return dtRcpt;
      }
      public DataTable ReadPrintVersions(clsEntity_Account_Setting objEntityEmpSlry)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadPrintVersions(objEntityEmpSlry);
          return dtRcpt;
      }
      public DataTable ReadDefaultPrintVersions(clsEntity_Account_Setting objEntityEmpSlry)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadDefaultPrintVersions(objEntityEmpSlry);
          return dtRcpt;
      }
      public DataTable ReadVoucherType(clsEntity_Account_Setting objEntityEmpSlry)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadVoucherType(objEntityEmpSlry);
          return dtRcpt;
      }

      public DataTable ReadPrimaryGrpsMapped(clsEntity_Account_Setting objEntityEmpSlry)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadPrimaryGrpsMapped(objEntityEmpSlry);
          return dtRcpt;
      }

      public DataTable ReadSelectedGrpOrLdgrLedger(clsEntity_Account_Setting objEntityEmpSlry)
      {
          DataTable dtRcpt = new DataTable();
          dtRcpt = objDataAccount.ReadSelectedGrpOrLdgrLedger(objEntityEmpSlry);
          return dtRcpt;
      }







    }
}
