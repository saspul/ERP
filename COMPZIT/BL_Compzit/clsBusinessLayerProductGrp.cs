using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using System.Data;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:16/06/2015
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit
{
   public class clsBusinessLayerProductGrp
    {
        
        //Method of passing ItemGroup details from ui layer to datalayer for insertion
        public void AddItemGrpMaster(clsEntityProductGrp ObjEntityItemGrp)
       {//Creating objects for datalayer
           clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            objDataLayerItemGrp.AddItemGrp(ObjEntityItemGrp);
        }

        //Method of passing new status deatils from ui layer to datalayer for status change
        public void ItemGroupStausChange(dynamic ObjEntityItemGrp)
        {//Creating objects for datalayer
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            objDataLayerItemGrp.ItemGroupStatusChange(ObjEntityItemGrp);
        }
        //Method of passing Item group details from ui layer to data layer for updation
        public void UpdateItemGroup(clsEntityProductGrp ObjEntityItem)
        {//Creating objects for datalayer
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            objDataLayerItemGrp.UpdateItemGroup(ObjEntityItem);
        }
        //Method of passing the count of Item group name that exist in the table
        public string CheckItemGroupName(dynamic ObjEntityItemGrp)
        {//Creating objects for datalayer
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            string strItemCount = objDataLayerItemGrp.CheckItemGroupName(ObjEntityItemGrp);
            return strItemCount;
        }
        //Method of passing Item group table data from datalayer to ui layer
        public DataTable ReadItemGroupById(clsEntityProductGrp ObjEntityItem)
        {//Creating objects for datalayer
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            DataTable dtReadItem = objDataLayerItemGrp.ReadItemGroupById(ObjEntityItem);
            return dtReadItem;
        }

        //passing data about Item group cancel to data layer from ui layer.
        public void CancelItemGroup(clsEntityProductGrp objEntityItem)
        {//Creating objects for datalayer
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            objDataLayerItemGrp.CancelItemGroup(objEntityItem);
        }
        //Method of passing the count of Item group code that exist in the table
        public string CheckItemGroupCode(dynamic ObjEntityItemGrp)
        {//Creating objects for datalayer
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            string strItemCount = objDataLayerItemGrp.CheckItemGroupCode(ObjEntityItemGrp);
            return strItemCount;
        }

        public DataTable ReadPurchaseTax(clsEntityProductGrp objEntityTax)
        {
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            DataTable dtPurchTax = objDataLayerItemGrp.ReadPurchaseTax(objEntityTax);
            return dtPurchTax;
        }

        //fetch product Group
        public DataTable Read_Product_Group_List(clsEntityProductGrp objEntityProduct)
        {
            clsDataLayerProductGrp objDataLayerItemGrp = new clsDataLayerProductGrp();
            DataTable dtProductGrp = objDataLayerItemGrp.ReadProductGrpList(objEntityProduct);
            return dtProductGrp;
        }
    }
}
