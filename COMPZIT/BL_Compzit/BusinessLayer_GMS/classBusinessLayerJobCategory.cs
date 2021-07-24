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
    public class classBusinessLayerJobCategory
    {
        public void AddJobCategory(classEntityLayerJobCategory objEntityJobCat)
        {
            classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
            ObjDataJob.AddJobCategory(objEntityJobCat);
        }

        public void UpdateJobCategory(classEntityLayerJobCategory objEntityJobCat)
        {
            classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
            ObjDataJob.UpdateJobCategory(objEntityJobCat);
        }
         public void ChangeCategoryStatus(classEntityLayerJobCategory objEntityJobCat)
        {
            classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
            ObjDataJob.ChangeCategoryStatus(objEntityJobCat);
        }
        // This Method checks job category name in the database for duplication.
        public string CheckJobCatName(classEntityLayerJobCategory objEntityJobCat)
        {
            classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
            string strReturn = ObjDataJob.CheckJobCatName(objEntityJobCat);
            return strReturn;
        }
         // This Method will fetCH job category DEATILS BY ID
       public DataTable ReadJobCategryById(classEntityLayerJobCategory objEntityJobCat)
       {
           classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
           DataTable dtCategory = new DataTable();
           dtCategory = ObjDataJob.ReadJobCategryById(objEntityJobCat);
           return dtCategory;
       }
        // This Method will fetch job category list
       public DataTable ReadJobCtgryList(classEntityLayerJobCategory objEntityJobCat)
       {
           classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
           DataTable dtCategory = new DataTable();
           dtCategory = ObjDataJob.ReadJobCtgryList(objEntityJobCat);
           return dtCategory;
       }
         //Method for cancel job category
       public void CancelJobCategory(classEntityLayerJobCategory objEntityJobCat)
       {
           classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
           ObjDataJob.CancelJobCategory(objEntityJobCat);
       }
         //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
       public void ReCallJobCategory(classEntityLayerJobCategory objEntityJobCat)
       {
           classDatalayerJobCategory ObjDataJob = new classDatalayerJobCategory();
           ObjDataJob.ReCallJobCategory(objEntityJobCat);
       }
    }
}
