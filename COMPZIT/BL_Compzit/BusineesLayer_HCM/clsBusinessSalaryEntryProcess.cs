using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL_Compzit.BusineesLayer_HCM
{
  public class clsBusinessSalaryEntryProcess
    {
      clsDataLayerSalaryEntryProcess objDataPassport = new clsDataLayerSalaryEntryProcess();
      public DataTable ReadEmployeeTableList(clsEntitySalaryEntryProcess objentityPassport)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataPassport.ReadEmployee(objentityPassport);
            return dtGuarnt;
        }

    }
}
