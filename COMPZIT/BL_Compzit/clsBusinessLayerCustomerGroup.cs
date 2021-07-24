using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:23/03/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit
{
    public class clsBusinessLayerCustomerGroup
    {
        //Creating objects for datalayer
        clsDataLayerCustomerGroup objDataLayerCust = new clsDataLayerCustomerGroup();
        //Method of passing customer group details from ui layer to datalayer for insertion
        public void AddCustomerGroup(clsEntityCustomerGroup ObjEntityCust)
        {
            objDataLayerCust.AddCustomerGroup(ObjEntityCust);
        }
       
        //Method of passing customer group details from ui layer to data layer for updation
        public void UpdateCustomerGroup(clsEntityCustomerGroup ObjEntityCust)
        {
            objDataLayerCust.UpdateCustomerGroup(ObjEntityCust);
        }

        //Method of passing the count of customer group name that exist in the table
        public string CheckCustomerGroupName(dynamic ObjEntityCust)
        {
            string strCustCount = objDataLayerCust.CheckCustomerGroupName(ObjEntityCust);
            return strCustCount;
        }
        //Method of passing customer group table data from datalayer to ui layer
        public DataTable ReadCustomerGroupById(clsEntityCustomerGroup ObjEntityCust)
        {
            DataTable dtReadCust = objDataLayerCust.ReadCustomerGroupById(ObjEntityCust);
            return dtReadCust;
        }

        //passing data about customer group cancel to data layer from ui layer.
        public void CancelCustomerGroup(clsEntityCustomerGroup objEntityCust)
        {
            objDataLayerCust.CancelCustomerGroup(objEntityCust);
        }
        //Method of passing customer group table data from datalayer to ui layer
        public DataTable ReadCustomerGroupList(clsEntityCustomerGroup ObjEntityCust)
        {
            DataTable dtReadCust = objDataLayerCust.ReadCustomerGroupList(ObjEntityCust);
            return dtReadCust;
        }
        public void UpdateStatus(clsEntityCustomerGroup ObjEntityCust)
        {
            objDataLayerCust.UpdateStatus(ObjEntityCust);
        }
    }
}
