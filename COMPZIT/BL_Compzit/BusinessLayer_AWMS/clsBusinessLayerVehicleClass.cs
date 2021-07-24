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
// CREATED BY:EVM-0005
// CREATED DATE:19/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit.BusinessLayer_AWMS
{
   public class clsBusinessLayerVehicleClass
    {
        // This Method adds vehical class details to the table
       public void AddVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
       {
           clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
           ObjDataVeh.AddVehicleClass(objEntityVehicle);

        }
       // This Method update vehical class details to the table
       public void UpdateVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
        {
            clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
            ObjDataVeh.UpdateVehicleClass(objEntityVehicle);
        }

       // This Method checks vehical class name in the database for duplication.
       public string CheckVehicleClassName(clsEntityLayerVehicleClass objEntityVehicle)
        {
            clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
            string count = ObjDataVeh.CheckVehicleClassName(objEntityVehicle);
            return count;
        }
       //Method for cancel vehical class
       public void CancelVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
        {
            clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
            ObjDataVeh.CancelVehicleClass(objEntityVehicle);
        }
       //Method for Recall vehical class
       public void RecallVehicleClass(clsEntityLayerVehicleClass objEntityVehicle)
       {
           clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
           ObjDataVeh.RecallVehicleClass(objEntityVehicle);
       }
       // This Method will fetCH vehical class DEATILS BY ID
       public DataTable ReadVehicleClassById(clsEntityLayerVehicleClass objEntityVehicle)
        {
            clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
            DataTable dtAccodetails = ObjDataVeh.ReadVehicleClassById(objEntityVehicle);
            return dtAccodetails;
        }
       // This Method will fetch vehical class list
       public DataTable ReadVehicleClassList(clsEntityLayerVehicleClass objEntityVehicle)
        {
            clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
            DataTable dtAccodetails = ObjDataVeh.ReadVehicleClassList(objEntityVehicle);
            return dtAccodetails;
        }
        // This Method will fetch image list
       public DataTable ReadImageDetails(clsEntityLayerVehicleClass objEntityVehicle)
        {
            clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
            DataTable dtAccodetails = ObjDataVeh.ReadImageDetails(objEntityVehicle);
            return dtAccodetails;
        }
       // This Method will fetch vehicle category type details
       public DataTable ReadVehicleCategoryType()
       {
           clsDataLayerVehicleClass ObjDataVeh = new clsDataLayerVehicleClass();
           DataTable dtAccodetails = ObjDataVeh.ReadVehicleCategoryType();
           return dtAccodetails;
       }
    }
}
