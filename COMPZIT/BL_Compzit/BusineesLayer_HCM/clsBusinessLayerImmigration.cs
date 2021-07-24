using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;
//using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;

namespace BL_Compzit.BusinessLayer_HCM
{
  
  public  class clsBusinessLayerImmigration
    {
      //clsDataLayerImmigration objDataLayerImmigration = new clsDataLayerImmigration();
      clsDataLayerImmigration objDataLayerImmigration = new clsDataLayerImmigration();
      public void AddImmigration(clsEntityImmigration ObjEntityImmigration)
      {
        objDataLayerImmigration.AddImmigration(ObjEntityImmigration);
          
      }
      public void UpdateImmigration(clsEntityImmigration ObjEntityImmigration)
      {
          objDataLayerImmigration.UpdateImmigration(ObjEntityImmigration);
      }
      ////Method of passing Immigration master table data from datalayer to ui layer
      public void CancelImmigrationById(clsEntityImmigration ObjEntityImmigration)
      {
           objDataLayerImmigration.CancelImmigrationById(ObjEntityImmigration);
        
      }
      ////Method of cancelling 
      public DataTable ReadImmigrationById(clsEntityImmigration ObjEntityImmigration)
      {
          DataTable dtReadsupplier = objDataLayerImmigration.ReadImmigrationById(ObjEntityImmigration);
          return dtReadsupplier;
      }
      public DataTable ReadImmigrationList(clsEntityImmigration ObjEntityImmigration)
      {
          DataTable dtReadsupplier = objDataLayerImmigration.ReadImmigrationList(ObjEntityImmigration);
          return dtReadsupplier;
      }
      //fetch country 
      public DataTable Read_Visa(clsEntityImmigration objEntityImigrationDtls)
      {
          DataTable dtCountry = objDataLayerImmigration.ReadVisa(objEntityImigrationDtls);
          return dtCountry;
      }
      public DataTable ReadVisaByType(clsEntityImmigration objEntityImigrationDtls)
      {
          DataTable dtCountry = objDataLayerImmigration.ReadVisaByType(objEntityImigrationDtls);
          return dtCountry;
      }
      public DataTable Read_Visa_ById(clsEntityImmigration objEntityImigrationDtls)
      {
          DataTable dtCountry = objDataLayerImmigration.Read_Visa_ById(objEntityImigrationDtls);
          return dtCountry;
      }
      
      //TO READ PASSPORT NUMBER
      public string Check_DOCNUM(clsEntityImmigration objEntityImigrationDtls)
      {
          string strreturn = objDataLayerImmigration.Check_DOCNUM(objEntityImigrationDtls);
          return strreturn;
      }
 
    }
}
