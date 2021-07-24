
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
// CREATED DATE:02/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusniessLayerVehicleStatusMaster
    {
        // This Method will fetch vehicle status
        public DataTable ReadVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            DataTable dtAccodetails = ObjDatavehsts.ReadVStatusMstr(objEntityvehsts);
            return dtAccodetails;
        }

        // This Method will fetch ACCOMODATION list
        public DataTable ReadVStatusMstrList(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            DataTable dtAccodetails = ObjDatavehsts.ReadVStatusMstrList(objEntityvehsts);
            return dtAccodetails;
        }

        // This Method checks Accommodation name in the database for duplication.
        public string CheckVehStsName(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            string count = ObjDatavehsts.CheckVehStsName(objEntityvehsts);
            return count;
        }

        // This Method adds accommodation details to the table
        public void AddVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            ObjDatavehsts.AddVStatusMstr(objEntityvehsts);

        }

        // This Method update accommoadation details to the table
        public void UpdateVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            ObjDatavehsts.UpdateVStatusMstr(objEntityvehsts);
        }

        //Method for cancel Accommodation
        public void CancelVStatusMstr(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            ObjDatavehsts.CancelVStatusMstr(objEntityvehsts);
        }
        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadVStatusById(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            DataTable dtAccodetails = ObjDatavehsts.ReadVStatusById(objEntityvehsts);
            return dtAccodetails;
        }
        //Method for recall fuel type

        public void ReCallVStatus(clsEntityVehicleStatusMaster objEntityvehsts)
        {
            clsDataLayerVehicleStatusMaster ObjDatavehsts = new clsDataLayerVehicleStatusMaster();
            ObjDatavehsts.ReCallVStatus(objEntityvehsts);
        }

           }
}
