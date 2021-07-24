using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using DL_Compzit.DataLayer_FMS;
using System.Data;
using EL_Compzit.EntityLayer_FMS;
namespace BL_Compzit.BusineesLayer_FMS
{
   
 public class clsBusinessLyer_Cost_Group
    {
        clsDataLayer_Cost_Group objDataLayerCostGroup = new clsDataLayer_Cost_Group();
        public void InsertCostGroup(clsEntityLayer_Cost_Group objEntityCost)
        {
            objDataLayerCostGroup.InsertCostGroup(objEntityCost);

        }
        public string CheckCostName(clsEntityLayer_Cost_Group objEntityCost)
        {
            string count = objDataLayerCostGroup.CheckCostName(objEntityCost);
            return count;
        }
        public DataTable ReadCOSTList(clsEntityLayer_Cost_Group objEntityCost)
        {
            DataTable dtReadCOSTList = objDataLayerCostGroup.ReadCOSTList(objEntityCost);
            return dtReadCOSTList;
        }
        public DataTable ReadCOSTById(clsEntityLayer_Cost_Group objEntityCost)
        {
            DataTable dtReadCOSTList = objDataLayerCostGroup.ReadCOSTById(objEntityCost);
            return dtReadCOSTList;
        }
        public void UpdateCostGroup(clsEntityLayer_Cost_Group objEntityCost)
        {
            objDataLayerCostGroup.UpdateCostGroup(objEntityCost);

        }
        public void CancelCostGroup(clsEntityLayer_Cost_Group objEntityCost)
        {
            objDataLayerCostGroup.CancelCostGroup(objEntityCost);

        }
        public DataTable ReadCostCnclChck(clsEntityLayer_Cost_Group objEntityCost)
        {
            DataTable dtReadCOSTCnclChck = objDataLayerCostGroup.ReadCostCnclChck(objEntityCost);
            return dtReadCOSTCnclChck;
        }
        public DataTable CostGroupCancelChk(clsEntityLayer_Cost_Group objEntityCost)
        {
            DataTable dtCostGroupCancelChk = objDataLayerCostGroup.CostGroupCancelChk(objEntityCost);
            return dtCostGroupCancelChk;
        }
        public DataTable ReadCostGroupHierarchy(clsEntityLayer_Cost_Group objEntityCost)
        {
            DataTable dtReadCOSTList = objDataLayerCostGroup.ReadCostGroupHierarchy(objEntityCost);
            return dtReadCOSTList;
        }
        public string CheckCodeDuplicatn(clsEntityLayer_Cost_Group objEntityAccountGroup)
        {
            string count = objDataLayerCostGroup.CheckCodeDuplicatn(objEntityAccountGroup);
            return count;
        }

    }
}
