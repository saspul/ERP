using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;


namespace BL_Compzit
{
   public class clsBusinessLayerPrdctBrand
   {
       clsDataLayerPrdctBrand objDataLayerPrdctBrand = new clsDataLayerPrdctBrand();
       //Method of passing ItemGroup details from ui layer to datalayer for insertion
       public void AddProductBrand(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer

           objDataLayerPrdctBrand.AddProductBrand(objEntityPrdctBrnd);
       }

      //Method of passing Item group details from ui layer to data layer for updation
       public void UpdateItemGroup(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer
           
           objDataLayerPrdctBrand.UpdateProductBrand(objEntityPrdctBrnd);
       }
       //Method of passing the count of Item group name that exist in the table
       public string CheckItemGroupName(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer

           string strItemCount = objDataLayerPrdctBrand.CheckProductBrandName(objEntityPrdctBrnd);
           return strItemCount;
       }
       //Method of passing Item group table data from datalayer to ui layer
       public DataTable ReadItemGroupById(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer
           
           DataTable dtReadItem = objDataLayerPrdctBrand.ReadProductBrandById(objEntityPrdctBrnd);
           return dtReadItem;
       }

       //passing data about Item group cancel to data layer from ui layer.
       public void CancelItemGroup(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer
           
           objDataLayerPrdctBrand.CancelProductBrand(objEntityPrdctBrnd);
       }
       //Method of passing the count of Item group code that exist in the table
       public string CheckItemGroupCode(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer
    
           string strItemCount = objDataLayerPrdctBrand.CheckProductBrandCode(objEntityPrdctBrnd);
           return strItemCount;
       }

      
       //fetch product Group
       public DataTable Read_Product_Group_List(clsEntityProductBrand objEntityPrdctBrnd)
       {
         
           DataTable dtProductGrp = objDataLayerPrdctBrand.ReadProductBrandList(objEntityPrdctBrnd);
           return dtProductGrp;
       }
       public void Update_Brand_Status(clsEntityProductBrand objEntityPrdctBrnd)
       {//Creating objects for datalayer

           objDataLayerPrdctBrand.Update_Brand_Status(objEntityPrdctBrnd);
       }
   }
}
