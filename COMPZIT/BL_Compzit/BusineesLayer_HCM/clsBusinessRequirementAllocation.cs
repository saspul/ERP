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
    public class clsBusinessRequirementAllocation
    {
        clsDataLayerRequirementAllocationcs objDataReqrmntalctn = new clsDataLayerRequirementAllocationcs();
        public DataTable ReadDivision(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataReqrmntalctn.ReadDivision(objEntityReqrmntAlctn);
            return dtGuarnt;
        }
        public DataTable ReadDepartment(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataReqrmntalctn.ReadDepartment(objEntityReqrmntAlctn);
            return dtGuarnt;
        }
        public DataTable ReadProject(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataReqrmntalctn.ReadProject(objEntityReqrmntAlctn);
            return dtGuarnt;
        }
        public DataTable ReadEmployeeList(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataReqrmntalctn.ReadEmployeeList(objEntityReqrmntAlctn);
            return dtGuarnt;
        }
        public DataTable ReadRequirementList(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataReqrmntalctn.ReadRequirementList(objEntityReqrmntAlctn);
            return dtGuarnt;
        }

        public void insertReqrmntAlctnDtls(clsEntityRequirementAllocation objEntityReqrmntAlctn, string[] strarrRqrmntIds, string[] strarrRqrmntReIds)
        {
            objDataReqrmntalctn.insertReqrmntAlctnDtls(objEntityReqrmntAlctn, strarrRqrmntIds, strarrRqrmntReIds);
        }
        public DataTable ChkRqrmntAlcted(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            DataTable dtGuarnt = new DataTable();
            dtGuarnt = objDataReqrmntalctn.ChkRqrmntAlcted(objEntityReqrmntAlctn);
            return dtGuarnt;
        }
    }
}
