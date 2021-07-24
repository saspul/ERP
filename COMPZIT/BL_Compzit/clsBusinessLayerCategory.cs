using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:17/06/2015
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit
{
  public class clsBusinessLayerCategory
    {        
        //Method of passing CategoryType table data from datalayer to ui layer
        public DataTable ReadCategoryType()
      {//Creating objects for datalayer
          clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dtReadCategoryType = objDataLayerCategory.ReadCategoryType();
            return dtReadCategoryType;
        }
        //Method of passing Category details from ui layer to datalayer for insertion
        public void AddCategoryMaster(clsEntityCategory ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            objDataLayerCategory.AddCategory(ObjEntityCategory);
        }

        //Method of passing new status deatils from ui layer to datalayer for status change
        public void CategoryStausChange(dynamic ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            objDataLayerCategory.CategoryStatusChange(ObjEntityCategory);
        }
        //Method of passing Category details from ui layer to data layer for updation
        public void UpdateCategory(clsEntityCategory ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            objDataLayerCategory.UpdateCategory(ObjEntityCategory);
        }

        //Method of passing the count of Category name that exist in the table
        public string CheckCategoryName(dynamic ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            string strCategoryCount = objDataLayerCategory.CheckCategoryName(ObjEntityCategory);
            return strCategoryCount;
        }
        //Method of passing the count of CategoryMain id  if category id of it exxists as main category in other
        public int CheckCategoryMainId(clsEntityCategory ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            string strCategoryCount = objDataLayerCategory.CheckCategoryMainId(ObjEntityCategory);
            int intCategoryCount=Convert.ToInt32(  strCategoryCount);
            return intCategoryCount;
        }
        //Method of passing Category table data from datalayer to ui layer
        public DataTable ReadCategoryById(clsEntityCategory ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dtReadCategory = objDataLayerCategory.ReadCategoryById(ObjEntityCategory);
            return dtReadCategory;
        }

        //passing data about Category cancel to data layer from ui layer.
        public void CancelCategory(clsEntityCategory objEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            objDataLayerCategory.CancelCategory(objEntityCategory);
        }
        //Method of passing the count of Category code that exist in the table
        public string CheckCategoryCode(dynamic ObjEntityCategory)
        {//Creating objects for datalayer
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            string strCategoryCount = objDataLayerCategory.CheckCategoryCode(ObjEntityCategory);
            return strCategoryCount;
        }
        //fetch product group on the basis corporate office
        public DataTable Read_Product_Group(clsEntityCategory objEntityCategory)
        {
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dtProductGroup = objDataLayerCategory.ReadProductGroup(objEntityCategory);
            return dtProductGroup;
        }
      //fetch main category on the basis of corporate office
        public DataTable Read_Main_Category(clsEntityCategory objEntityCategory)
        {
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dtMainCategory = objDataLayerCategory.ReadMainCategory(objEntityCategory);
            return dtMainCategory;
        }
        //fetch product category 
        public DataTable Read_Product_Category_List(clsEntityCategory objEntityCategory)
        {
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dtProductCategory = objDataLayerCategory.ReadCategoryList(objEntityCategory);
            return dtProductCategory;
        }
      //fetch category list based on search word
        public DataTable Read_CategoryList_BySearch(clsEntityCategory objEntityCategory)
        {
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dtCategoryList = objDataLayerCategory.ReadCategoryListBySearch(objEntityCategory);
            return dtCategoryList;
        }


        public DataTable ReadLedgers(clsEntityCategory objEntityCategory)
        {
            clsDataLayerCategory objDataLayerCategory = new clsDataLayerCategory();
            DataTable dt = objDataLayerCategory.ReadLedgers(objEntityCategory);
            return dt;
        }
    }
}
