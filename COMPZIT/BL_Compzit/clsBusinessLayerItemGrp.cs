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
   public class clsBusinessLayerItemGrp
    {
        
        //Method of passing ItemGroup details from ui layer to datalayer for insertion
        public void AddItemGrpMaster(clsEntityItemGrp ObjEntityItemGrp)
       {//Creating objects for datalayer
           clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            objDataLayerItemGrp.AddItemGrp(ObjEntityItemGrp);
        }

        //Method of passing new status deatils from ui layer to datalayer for status change
        public void ItemGroupStausChange(dynamic ObjEntityItemGrp)
        {//Creating objects for datalayer
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            objDataLayerItemGrp.ItemGroupStatusChange(ObjEntityItemGrp);
        }
        //Method of passing Item group details from ui layer to data layer for updation
        public void UpdateItemGroup(clsEntityItemGrp ObjEntityItem)
        {//Creating objects for datalayer
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            objDataLayerItemGrp.UpdateItemGroup(ObjEntityItem);
        }
        //Method of passing the count of Item group name that exist in the table
        public string CheckItemGroupName(dynamic ObjEntityItemGrp)
        {//Creating objects for datalayer
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            string strItemCount = objDataLayerItemGrp.CheckItemGroupName(ObjEntityItemGrp);
            return strItemCount;
        }
        //Method of passing Item group table data from datalayer to ui layer
        public DataTable ReadItemGroupById(clsEntityItemGrp ObjEntityItem)
        {//Creating objects for datalayer
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            DataTable dtReadItem = objDataLayerItemGrp.ReadItemGroupById(ObjEntityItem);
            return dtReadItem;
        }

        //passing data about Item group cancel to data layer from ui layer.
        public void CancelItemGroup(clsEntityItemGrp objEntityItem)
        {//Creating objects for datalayer
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            objDataLayerItemGrp.CancelItemGroup(objEntityItem);
        }
        //Method of passing the count of Item group code that exist in the table
        public string CheckItemGroupCode(dynamic ObjEntityItemGrp)
        {//Creating objects for datalayer
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            string strItemCount = objDataLayerItemGrp.CheckItemGroupCode(ObjEntityItemGrp);
            return strItemCount;
        }

        public DataTable ReadPurchaseTax(clsEntityItemGrp objEntityTax)
        {
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            DataTable dtPurchTax = objDataLayerItemGrp.ReadPurchaseTax(objEntityTax);
            return dtPurchTax;
        }

        //fetch product Group
        public DataTable Read_Product_Group_List(clsEntityItemGrp objEntityProduct)
        {
            clsDataLayerItemGrp objDataLayerItemGrp = new clsDataLayerItemGrp();
            DataTable dtProductGrp = objDataLayerItemGrp.ReadProductGrpList(objEntityProduct);
            return dtProductGrp;
        }
    }
}
