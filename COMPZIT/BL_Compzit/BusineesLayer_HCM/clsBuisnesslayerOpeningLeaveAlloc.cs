using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBuisnesslayerOpeningLeaveAlloc
    {
        clsDatalayerOpeningLeaveAlloc objDataOpngLvAlloc = new clsDatalayerOpeningLeaveAlloc();
        public DataTable ReadUsers(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            DataTable dtUsers = objDataOpngLvAlloc.ReadUsers(objEntityOpngLvAlloc);
            return dtUsers;
        }
        public DataTable ReadLeaveTypes(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            DataTable dtLeaveType = objDataOpngLvAlloc.ReadLeaveTypes(objEntityOpngLvAlloc);
            return dtLeaveType;
        }
        public void InsertLeaveAlloc(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            objDataOpngLvAlloc.InsertLeaveAlloc(objEntityOpngLvAlloc);
        }
        public void UpdateLeaveAlloc(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            objDataOpngLvAlloc.UpdateLeaveAlloc(objEntityOpngLvAlloc);
        }
        public void ConfirmLeaveAlloc(clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc)
        {
            objDataOpngLvAlloc.ConfirmLeaveAlloc(objEntityOpngLvAlloc);
        }
    }

}
