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

namespace BL_Compzit.BusinessLayer_AWMS
{
   public class clsBusinessLayerTrafficViolationReport
    {
       clsDataLayerTrafficViolationReport objdatalayerreports = new clsDataLayerTrafficViolationReport();
       public DataTable ReadViolationreport(clsEntityLayerTrafficViolationReport objentityviolationreports, List<clsEntityLayerEmployee> objviolatedemp)
       {
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objdatalayerreports.ReadViolationreport(objentityviolationreports, objviolatedemp);
           
           return dtGuarnt;
       }



       public DataTable ReadEmployee(clsEntityLayerTrafficViolationReport objreademploye)
        {
            clsDataLayerTrafficViolationReport objdatalayeremploye = new clsDataLayerTrafficViolationReport();
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objdatalayeremploye.ReadEmployee(objreademploye);
            return dtGuarnt;
        }
       public DataTable ReadVehicle(clsEntityLayerTrafficViolationReport objreademploye)
       {
           clsDataLayerTrafficViolationReport objdatalayeremploye = new clsDataLayerTrafficViolationReport();
           DataTable dtGuarnt = new DataTable();
           dtGuarnt = objdatalayeremploye.ReadVehicle(objreademploye);
           return dtGuarnt;
       }

        

    }
}
