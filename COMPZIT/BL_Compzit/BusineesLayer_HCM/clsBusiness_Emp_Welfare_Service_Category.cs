using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Collections.Generic;
using System.Data;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_Emp_Welfare_Service_Category
    {
        clsDataLayer_Emp_Wlefare_Service_category objDataLayer_Welfare_Category = new clsDataLayer_Emp_Wlefare_Service_category();
       
        //to insert Welfare Service Category
        public void InsertWelfareCcategory(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            objDataLayer_Welfare_Category.InsertWelfareCcategory(objEntityWelfareCcategory);

        }
        //update Welfare Service Category
        public void UpdateWelfareCategory(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            objDataLayer_Welfare_Category.UpdateWelfareCategory(objEntityWelfareCcategory);
        }
        // This Method checks  Welfare Service Category name in the database for duplication.
        public string CheckCategoryName(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            string count = objDataLayer_Welfare_Category.CheckCategoryName(objEntityWelfareCcategory);
            return count;
        }
        //Read Employee welfare service category list
        public DataTable ReadCategoryDetails(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            DataTable dtList = objDataLayer_Welfare_Category.ReadCategoryDetails(objEntityWelfareCcategory);
            return dtList;
        }
        //Read Employee welfare service category list
        public DataTable ReadCategoryDetailsById(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            DataTable dtDetailsById = objDataLayer_Welfare_Category.ReadCategoryDetailsById(objEntityWelfareCcategory);
            return dtDetailsById;
        }
        public void CancelWelfareCategory(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            objDataLayer_Welfare_Category.CancelWelfareCategory(objEntityWelfareCcategory);

        }
        public void ChangeCategoryStatus(clsEntity_Emp_Welfare_Service_category objEntityWelfareCcategory)
        {
            objDataLayer_Welfare_Category.ChangeCategoryStatus(objEntityWelfareCcategory);

        }
    }
}
