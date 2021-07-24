using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
namespace BL_Compzit.BusineesLayer_HCM
{
   public class clsbusinessLayer_AccntSetting
    {
       clsDataLayer_AccntSetting objDataLayer_AccntSetting = new clsDataLayer_AccntSetting();
       public DataTable ReadEmployeLeaveDetails(clsEntity_AccountSettings objEntityAccountSettings)
       {
           DataTable dtEmployeeDetails = objDataLayer_AccntSetting.ReadEmployeLeaveDetails(objEntityAccountSettings);
           return dtEmployeeDetails;
       }
    }
}
