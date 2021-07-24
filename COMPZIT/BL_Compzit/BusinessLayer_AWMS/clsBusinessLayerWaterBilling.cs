using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0001
// CREATED DATE:01/12/2016
// REVIEWED BY:
// REVIEW DATE:


namespace BL_Compzit.BusinessLayer_AWMS
{
  public class clsBusinessLayerWaterBilling
    {

      clsDataLayerWaterBilling objDataLayerWaterBilling = new clsDataLayerWaterBilling();

      // This Method will fetch Vehicle  For autocompletion from WebService
      public DataTable ReadVehiclesWebService(string strLikeVhclNumbr, clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          DataTable dtReadVehicle = objDataLayerWaterBilling.ReadVehiclesWebService(strLikeVhclNumbr, objEntityWatrBilling);
          return dtReadVehicle;
      }
      public DataTable ReadWaterCard(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          DataTable dtReadCard = objDataLayerWaterBilling.ReadWaterCard(objEntityWatrBilling);
          return dtReadCard;
      }
      public DataTable ReadWaterCardDtlByID(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          DataTable dtReadCard = objDataLayerWaterBilling.ReadWaterCardDtlByID(objEntityWatrBilling);
          return dtReadCard;
      }
      //Add  Details
      public int Insert_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling, List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingDetails)
      {
        return  objDataLayerWaterBilling.Insert_WaterBiling(objEntityWatrBilling, objEntityWaterBillingDetails);

      }
      // This Method FETCHES  DETAILS BASED ON  ID FOR DISPALYING
      public DataTable ReadWaterBilingDetail(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          DataTable dtReadDtl = objDataLayerWaterBilling.ReadWaterBilingDetail(objEntityWatrBilling);
          return dtReadDtl;
      }
      //Update  Details
      public void Update_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling, List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingInsertDetails, List<clsEntityLayerWaterBillingDtl> objEntitWaterBillingUpdateDetails, string[] strarrCancldtlIds)
      {
          objDataLayerWaterBilling.Update_WaterBiling(objEntityWatrBilling, objEntityWaterBillingInsertDetails, objEntitWaterBillingUpdateDetails, strarrCancldtlIds);

      }
      //Confirm  Details
      public void Confirm_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling, List<clsEntityLayerWaterBillingDtl> objEntityWaterBillingInsertDetails, List<clsEntityLayerWaterBillingDtl> objEntitWaterBillingUpdateDetails, string[] strarrCancldtlIds)
      {
          objDataLayerWaterBilling.Confirm_WaterBiling(objEntityWatrBilling, objEntityWaterBillingInsertDetails, objEntitWaterBillingUpdateDetails, strarrCancldtlIds);

      }
      // This Method will fetch water card details and billing  DEATILS BY ID
      public DataTable ReadWaterBillingById(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          DataTable dtReadDtl = objDataLayerWaterBilling.ReadWaterBillingById(objEntityWatrBilling);
          return dtReadDtl;
      }
      //Update  details to  table while reopening,add the value to watercard
      public void Reopen_WaterBiling(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          objDataLayerWaterBilling.Reopen_WaterBiling(objEntityWatrBilling);

      }
      //Method for recall Cancelled water billing
      public void ReCallCanceledWaterBilling(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          objDataLayerWaterBilling.ReCallCanceledWaterBilling(objEntityWatrBilling);

      }
      //Method for  Cancel water billing
      public void CancelWaterBilling(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          objDataLayerWaterBilling.CancelWaterBilling(objEntityWatrBilling);

      }
      // This Method will fetch water bill  list BY SEARCH
      public DataTable ReadWaterBillingListBySearch(clsEntityLayerWaterBilling objEntityWatrBilling)
      {
          DataTable dtReadList = objDataLayerWaterBilling.ReadWaterBillingListBySearch(objEntityWatrBilling);
          return dtReadList;
      }
    }
}
