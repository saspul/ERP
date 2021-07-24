using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusinessLayer_HCM
{
  public class clsBusinessLayerStaffImmigration
    {
        //clsDataLayerImmigration objDataLayerImmigration = new clsDataLayerImmigration();
        clsDataLayerStaffImmigration objDataLayerStaffImmigration = new clsDataLayerStaffImmigration();
        public void AddStaffImmigration(clsEntityStaffImmigration ObjEntityStaffImmigration)
        {
            objDataLayerStaffImmigration.AddStaffImmigration(ObjEntityStaffImmigration);

        }
        public void UpdateImmigration(clsEntityStaffImmigration ObjEntityImmigration)
        {
            objDataLayerStaffImmigration.UpdateImmigration(ObjEntityImmigration);
        }
        ////Method of passing Immigration master table data from datalayer to ui layer
        public void CancelImmigrationById(clsEntityStaffImmigration ObjEntityImmigration)
        {
            objDataLayerStaffImmigration.CancelImmigrationById(ObjEntityImmigration);

        }
        ////Method of cancelling 
        public DataTable ReadStaffImmigrationById(clsEntityStaffImmigration ObjEntityStaffImmigration)
        {
            DataTable dtReadsupplier = objDataLayerStaffImmigration.ReadStaffImmigrationById(ObjEntityStaffImmigration);
            return dtReadsupplier;
        }
        public DataTable ReadStaffImmigration(clsEntityStaffImmigration ObjEntityStaffImmigration)
        {
            DataTable dtReadsupplier = objDataLayerStaffImmigration.ReadImmigrationList(ObjEntityStaffImmigration);
            return dtReadsupplier;
        }
        //fetch country 
        public DataTable Read_Visa(clsEntityStaffImmigration objEntityImigrationDtls)
        {
            DataTable dtCountry = objDataLayerStaffImmigration.ReadVisa(objEntityImigrationDtls);
            return dtCountry;
        }
        //TO READ PASSPORT NUMBER
        public string Check_DOCNUM(clsEntityStaffImmigration objEntityImigrationDtls)
        {
            string strreturn = objDataLayerStaffImmigration.Check_DOCNUM(objEntityImigrationDtls);
            return strreturn;
        }
        ////fetch Immigration list based on corporate office id
        //public DataTable Read_Immigration_List(clsEntityStaffImmigration objEntityImmigration)
        //{
        //    DataTable dtImmigration = objDataLayerImmigration.Read_Immigration_List(objEntityImmigration);
        //    return dtImmigration;
        //}

    }
}
