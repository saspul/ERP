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
   public class clsBusinessLayer_Cost_Center
    {
       clsDataLayer_Cost_Center objDataLayerCostCenter = new clsDataLayer_Cost_Center();
       public string InsertCostCenter(clsEntityLayer_Cost_Center objEntity)
        {
            string count = objDataLayerCostCenter.InsertCostCenter(objEntity);
            return count;
        }
       public string CheckCostName(clsEntityLayer_Cost_Center objEntity)
        {
            string count = objDataLayerCostCenter.CheckCostName(objEntity);
            return count;
        }
       public DataTable ReadCostGroup(clsEntityLayer_Cost_Center objEntity)
       {
           DataTable dtDiv = objDataLayerCostCenter.ReadCostGroup(objEntity);
           return dtDiv;
       }
       public DataTable ReadCostCenterList(clsEntityLayer_Cost_Center objEntity)
       {
           DataTable dtReadCostCenterList = objDataLayerCostCenter.ReadCostCenterList(objEntity);
           return dtReadCostCenterList;
       }
       public DataTable ReadCostCenterById(clsEntityLayer_Cost_Center objEntity)
       {
           DataTable dtReadCostCenterList = objDataLayerCostCenter.ReadCostCenterById(objEntity);
           return dtReadCostCenterList;
       }
       public void UpdateCostCenter(clsEntityLayer_Cost_Center objEntity)
       {
           objDataLayerCostCenter.UpdateCostCenter(objEntity);

       }
       public void CancelCostCenter(clsEntityLayer_Cost_Center objEntity)
       {
           objDataLayerCostCenter.CancelCostCenter(objEntity);

       }
       public DataTable CostCenterCancelChk(clsEntityLayer_Cost_Center objEntity)
       {
           DataTable dtCostCancelCancelChk = objDataLayerCostCenter.CostCenterCancelChk(objEntity);
           return dtCostCancelCancelChk;
       }

      
       public string CheckCodeDuplicatn(clsEntityLayer_Cost_Center objEntityAccountGroup)
       {
           string count = objDataLayerCostCenter.CheckCodeDuplicatn(objEntityAccountGroup);
           return count;
       }

       public void DeleteCostCenter(clsEntityLayer_Cost_Center objEntity)
       {
           objDataLayerCostCenter.DeleteCostCenter(objEntity);

       }
       //evm 0044
       public void UpdateCostGroupNextId(clsEntityLayer_Cost_Center objEntity)
       {
           objDataLayerCostCenter.UpdateCostGroupNextId(objEntity);
       }
    }
}
