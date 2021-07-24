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
namespace BL_Compzit.BusinessLayer_FMS
{
  public  class clsBusinessLyer_Tax_CollectedAt_Source
    {
      clsDataLayer_Tax_CollectedAt_Source objDataLayerTaxCollectedAtSource = new clsDataLayer_Tax_CollectedAt_Source();
      public void InsertTaxCollectedAtSource(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
      {
          objDataLayerTaxCollectedAtSource.InsertTaxCollectedAtSource(objEntityTCS);

      }
      public string CheckTaxName(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
      {
          string count = objDataLayerTaxCollectedAtSource.CheckTaxName(objEntityTCS);
          return count;
      }
      public DataTable ReadTCSList(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
      {
          DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.ReadTCSList(objEntityTCS);
          return dtReadTcsList;
      }
      public DataTable ReadTcsByIdByid(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
      {
          DataTable dtReadTcsList = objDataLayerTaxCollectedAtSource.ReadTcsByIdByid(objEntityTCS);
          return dtReadTcsList;
      }
      public void UpdateTaxCollectedAtSource(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
      {
          objDataLayerTaxCollectedAtSource.UpdateTaxCollectedAtSource(objEntityTCS);

      }
      public void CancelTaxCollectedAtSource(clsEntityLayer_Tax_CollectedAt_Source objEntityTCS)
      {
          objDataLayerTaxCollectedAtSource.CancelTaxCollectedAtSource(objEntityTCS);

      }
    }
}
