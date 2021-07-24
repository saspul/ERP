using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;

namespace BL_Compzit.BusinessLayer_GMS
{
    public class classBusinessLayerContractCategory
    {
        public void AddContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            ObjDataCntrct.AddContractCategory(objEntityCntrctCat);
        }

        public void UpdateContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            ObjDataCntrct.UpdateContractCategory(objEntityCntrctCat);
        }
          public void ChangeCategoryStatus(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            ObjDataCntrct.ChangeCategoryStatus(objEntityCntrctCat);
        }
        // This Method checks job category name in the database for duplication.
        public string CheckContractCatName(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            string strReturn = ObjDataCntrct.CheckContractCatName(objEntityCntrctCat);
            return strReturn;
        }
        // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadContractCategryById(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataCntrct.ReadContractCategryById(objEntityCntrctCat);
            return dtCategory;
        }
        // This Method will fetch job category list
        public DataTable ReadContractCtgryList(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataCntrct.ReadContractCtgryList(objEntityCntrctCat);
            return dtCategory;
        }
        //Method for cancel job category
        public void CancelContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            ObjDataCntrct.CancelContractCategory(objEntityCntrctCat);
        }
        //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
        public void ReCallContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        {
            classDatalayerContractCategory ObjDataCntrct = new classDatalayerContractCategory();
            ObjDataCntrct.ReCallContractCategory(objEntityCntrctCat);
        }
    }
}
