using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;
using EL_Compzit.EntityLayer_FMS;

// CREATED BY:EVM-0002
// CREATED DATE:17/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerCustomer
    {
        //Creating objects for datalayer
        clsDataLayerCustomer objDataLayerCustomer = new clsDataLayerCustomer();
        //Method of passing customer details from ui layer to datalayer for insertion
        public int AddCustomer(clsEntityCustomer ObjEntityCustomer, List<clsEntityCustomer> objEntityCustomer, List<clsEntityCustomer> objEntityContact)
        {
          int intCustomerId=  objDataLayerCustomer.AddCustomer(ObjEntityCustomer, objEntityCustomer,objEntityContact);
          return intCustomerId;
        }
        //Method of passing new status deatils from ui layer to datalayerfor status change
        public void CustomerStausChange(dynamic ObjEntityCustomer)
        {
            objDataLayerCustomer.CustomerStatusChange(ObjEntityCustomer);
        }
        //Method of passing customer details from ui layer to data layer for updation
        public void UpdateCustomer(clsEntityCustomer ObjEntityCustomer, List<clsEntityCustomer> objEntityCustomer, List<clsEntityCustomer> objEntityContact)
        {
            objDataLayerCustomer.UpdateCustomer(ObjEntityCustomer, objEntityCustomer, objEntityContact);
        }

        //Method of passing the count of customer name that exist in the table
        public string CheckCustomerName(dynamic ObjEntityCustomer)
        {
            string strUpdateCount = objDataLayerCustomer.CheckCustomerName(ObjEntityCustomer);
            return strUpdateCount;
        }
        //Method of passing customer master table data from datalayer to ui layer
        public DataTable ReadCustomerById(clsEntityCustomer ObjEntityCustomer)
        {
            DataTable dtReadsupplier = objDataLayerCustomer.ReadCustomerById(ObjEntityCustomer);
            return dtReadsupplier;
        }

        //passing data about customer cancel to data layer from ui layer.
        public void CancelCustomerMaster(clsEntityCustomer ObjEntityCustomer)
        {
            objDataLayerCustomer.CancelCustomer(ObjEntityCustomer);
        }

        //fetch customer type
        public DataTable Read_Customer_Type(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCustomerType = objDataLayerCustomer.ReadCustomerType(objEntityCustomer);
            return dtCustomerType;
        }

        //read customer group
        public DataTable Read_Customer_Group(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCustomerGroup = objDataLayerCustomer.ReadCustomerGroup(objEntityCustomer);
            return dtCustomerGroup;
        }

        //fetch country 
        public DataTable Read_Country()
        {
            DataTable dtCountry = objDataLayerCustomer.ReadCountry();
            return dtCountry;
        }

        //fetch state based on country
        public DataTable Read_State(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtState = objDataLayerCustomer.ReadState(objEntityCustomer);
            return dtState;
        }

        //fetch city on the basis of state
        public DataTable Read_City(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCity = objDataLayerCustomer.ReadCity(objEntityCustomer);
            return dtCity;
        }

        //fetch customer list based on corporate office id
        public DataTable Read_Customer_List(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCustomer = objDataLayerCustomer.Read_Customer_List(objEntityCustomer);
            return dtCustomer;
        }

        //fetch media master from databse
        public DataTable Read_Media_Master()
        {
            DataTable dtMediaMaster = objDataLayerCustomer.Read_Media_Master();
            return dtMediaMaster;
        }

        //read customer contact details based on customer id
        public DataTable Read_Contact_ById(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtContact = objDataLayerCustomer.Read_Contact_DetailsById(objEntityCustomer);
            return dtContact;
        }

        //read customer media details based on customer id 
        public DataTable Read_Media_ById(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtMedia = objDataLayerCustomer.Read_Media_DetailsById(objEntityCustomer);
            return dtMedia;
        }

        //methode for search customer list based on customer name and corporation id
        public DataTable Read_Customer_List_BySearch(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCustomer = objDataLayerCustomer.Read_Customer_List_BySearch(objEntityCustomer);
            return dtCustomer;
        }

        //method for reading term template
        public DataTable ReadTermTemplate(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCustomer = objDataLayerCustomer.ReadTermTemplate(objEntityCustomer);
            return dtCustomer;
        }

        //method for reading term template details
        public DataTable ReadSelectedTermDtl(clsEntityCustomer objEntityCustomer)
        {
            DataTable dtCustomer = objDataLayerCustomer.ReadSelectedTermDtl(objEntityCustomer);
            return dtCustomer;
        }

        public string AddLedger(clsEntityLedger ObjEntityCustomer)
        {
            string S = objDataLayerCustomer.AddLedger(ObjEntityCustomer);
            return S;
        }
        public void UpdateStatus(clsEntityCustomer ObjEntityCustomer)
        {
            objDataLayerCustomer.UpdateStatus(ObjEntityCustomer);
        }
    }
}