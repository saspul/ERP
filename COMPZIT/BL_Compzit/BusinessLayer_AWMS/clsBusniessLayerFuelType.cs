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
// CREATED BY:EVM-0008
// CREATED DATE:25/11/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusniessLayerFuelType
    {
        // This Method will fetch image list
        public DataTable ReadImageDetails(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            DataTable dtAccodetails = ObjDataFuel.ReadImageDetails(objEntityFuel);
            return dtAccodetails;
        }

        // This Method will fetch ACCOMODATION list
        public DataTable ReadFuelTypeList(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            DataTable dtAccodetails = ObjDataFuel.ReadFuelTypeList(objEntityFuel);
            return dtAccodetails;
        }

        // This Method checks Accommodation name in the database for duplication.
        public string CheckFuelTypeName(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            string count = ObjDataFuel.CheckFuelTypeName(objEntityFuel);
            return count;
        }

        // This Method adds accommodation details to the table
        public void AddFuelType(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            ObjDataFuel.AddFuelType(objEntityFuel);

        }

        // This Method update accommoadation details to the table
        public void UpdateFuelType(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            ObjDataFuel.UpdateFuelType(objEntityFuel);
        }

        //Method for cancel Accommodation
        public void CancelFuelType(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            ObjDataFuel.CancelFuelType(objEntityFuel);
        }
        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadFuelTypeById(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            DataTable dtAccodetails = ObjDataFuel.ReadFuelTypeById(objEntityFuel);
            return dtAccodetails;
        }
        //Method for recall fuel type

        public void ReCallFuelType(clsEntityLayerFuelType ObjEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            ObjDataFuel.ReCallFuelType(ObjEntityFuel);
        }

        public void ChangeStatus(clsEntityLayerFuelType objEntityFuel)
        {
            clsDataLayerFuelType ObjDataFuel = new clsDataLayerFuelType();
            ObjDataFuel.ChangeStatus(objEntityFuel);
        }

    }
}
