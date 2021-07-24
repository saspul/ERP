using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL_Compzit.DataLayer_PMS;
using EL_Compzit.EntityLayer_PMS;

namespace BL_Compzit.BusinessLayer_PMS
{
    public class clsBusinessLayerVendorCategory
    {
        clsDataLayerVendorCategory objDatalayerVendorCategory = new clsDataLayerVendorCategory();
        public void InsertVendorCategory(clsEntityVendorCategory objEntityVendorCategory)
        {
            objDatalayerVendorCategory.InsertVendorCategory(objEntityVendorCategory);
        }

        public void updateVendorCategory(clsEntityVendorCategory objEntityVendorCategory)
        {
            objDatalayerVendorCategory.updateVendorCategory(objEntityVendorCategory);
        }
        public DataTable ReadVendorCategory(clsEntityVendorCategory objEntityVendorCategory)
        {
            DataTable dtVendorCategory = new DataTable();
            dtVendorCategory = objDatalayerVendorCategory.ReadVendorCategory(objEntityVendorCategory);
            return dtVendorCategory;
        }

        public void CancelVendorCategory(clsEntityVendorCategory objEntityVendorCategory)
        {
            objDatalayerVendorCategory.CancelVendorCategory(objEntityVendorCategory);
        }

        public DataTable ReadVendorCategory_ByID(clsEntityVendorCategory objEntityVendorCategory)
        {
            DataTable dtVendorCategory = new DataTable();
            dtVendorCategory = objDatalayerVendorCategory.ReadVendorCategory_ByID(objEntityVendorCategory);
            return dtVendorCategory;
        }
        public DataTable VendorCategoryDplctnChk(clsEntityVendorCategory objEntityVendorCategory)
        {
            DataTable dtVendorCategory = new DataTable();
            dtVendorCategory = objDatalayerVendorCategory.VendorCategoryDplctnChk(objEntityVendorCategory);
            return dtVendorCategory;
        }

    }
}