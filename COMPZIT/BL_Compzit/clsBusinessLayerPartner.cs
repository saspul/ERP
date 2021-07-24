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

namespace BL_Compzit
{
  public class clsBusinessLayerPartner
    {
      clsDataLayerPartner objDataLayerPartner = new clsDataLayerPartner();
      //Method for passing country table from datalayer to uilayer.
      public DataTable ReadCountry()
      {
          DataTable dtReadCountry = objDataLayerPartner.ReadCountry();
          return dtReadCountry;
      }
      //Method for passing partnership type table from datalayer to uilayer.
      public DataTable ReadPartshipType()
      {
          DataTable dtReadCountry = objDataLayerPartner.ReadPartshipType();
          return dtReadCountry;
      }
      //Method for passing state details in between the datalayer and ui layer.
      public DataTable ReadState(clsEntityPartner objEntityPartner)
      {
          DataTable dtReadState = objDataLayerPartner.ReadState(objEntityPartner);
          return dtReadState;
      }
      //Method for passing city details in between the datalayer and ui layer.
      public DataTable ReadCity(clsEntityPartner objEntityPartner)
      {
          DataTable dtReadCity = objDataLayerPartner.ReadCity(objEntityPartner);
          return dtReadCity;
      }
      //Method for passing partner table from data layer to ui layer.
      public DataTable ReadPartner(clsEntityPartner objEntityPartner)
      {
          DataTable dtCorpOffice = objDataLayerPartner.ReadPartner(objEntityPartner);
          return dtCorpOffice;
      }
      //Method for passing the details about partner from ui layer to datalayer.
      public void insertPartner(clsEntityPartner objEntityPartner)
      {
          objDataLayerPartner.insertPartner(objEntityPartner);
      }
      //Method for passing partner table from data layer to ui layer.
      public DataTable ReadPartnerById(clsEntityPartner objEntityPartner)
      {
          DataTable dtCorpOffice = objDataLayerPartner.ReadPartnerById(objEntityPartner);
          return dtCorpOffice;
      }
      //Method for passing the details about partner from ui layer to datalayer.
      public void UpdatePartner(clsEntityPartner objEntityPartner)
      {
          objDataLayerPartner.UpdatePartner(objEntityPartner);
      }
      //Method to passing the count of partner name number in table
      public string CheckName(clsEntityPartner objEntityPartner)
      {
          string strReturn = objDataLayerPartner.CheckName(objEntityPartner);
          return strReturn;
      }
      //Method to passing the count of document number in table
      public string CheckDocnum(clsEntityPartner objEntityPartner)
      {
          string strReturn = objDataLayerPartner.CheckDocnum(objEntityPartner);
          return strReturn;
      }
      //Method for cancel partner, data passed from ui layer to data layer.
      public void CancelPartner(clsEntityPartner objEntityPartner)
      {
          objDataLayerPartner.CancelPartner(objEntityPartner);
      }
      //evm-0012
      public string CheckComRegNo(clsEntityPartner objEntityPartner)
      {
          string strReturn = objDataLayerPartner.CheckComRegNo(objEntityPartner);
          return strReturn;
      }
      public string CheckComCardNo(clsEntityPartner objEntityPartner)
      {
          string strReturn = objDataLayerPartner.CheckComCardNo(objEntityPartner);
          return strReturn;
      }
      public string CheckTIN(clsEntityPartner objEntityPartner)
      {
          string strReturn = objDataLayerPartner.CheckTIN(objEntityPartner);
          return strReturn;
      }
      public void StatusChange(clsEntityPartner objEntityPartner)
      {

        objDataLayerPartner.StatusChange(objEntityPartner);
      }
    }
}
