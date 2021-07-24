using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:18/03/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerTaxMaster
    {
        //Creating objects for datalayer
        clsDataLayerTaxMaster objDataLayerTax = new clsDataLayerTaxMaster();
        //Method of passing tax details from ui layer to datalayer for insertion
        public void AddTaxMaster(clsEntityTaxMaster ObjEntityTax)
        {
            objDataLayerTax.AddTaxMstr(ObjEntityTax);
        }
        //Method of passing new status deatils from ui layer to datalayerfor status change
        public void TaxStausChange(dynamic objEntityTax)
        {
            objDataLayerTax.TaxStatusChange(objEntityTax);
        }
        //Method of passing tax details from ui layer to data layer for updation
        public void UpdateTax(clsEntityTaxMaster objEntityTax)
        {
            objDataLayerTax.UpdateTax(objEntityTax);
        }

        //Method of passing the count of Tax name that exist in the table
        public string CheckTaxName(dynamic objEntityTax)
        {
            string strTaxCount = objDataLayerTax.CheckTaxName(objEntityTax);
            return strTaxCount;
        }
        //Method of passing tax master table data from datalayer to ui layer
        public DataTable ReadTaxById(clsEntityTaxMaster ObjEntityTax)
        {
            DataTable dtReadTax = objDataLayerTax.ReadTaxById(ObjEntityTax);
            return dtReadTax;
        }

        //passing data about Tax cancel to data layer from ui layer.
        public void CancelTaxMaster(clsEntityTaxMaster objEntityTax)
        {
            objDataLayerTax.CancelTax(objEntityTax);
        }
        //Method of passing tax master table data from datalayer to ui layer
        public DataTable ReadTaxList(clsEntityTaxMaster ObjEntityTax)
        {
            DataTable dtReadTax = objDataLayerTax.ReadTaxList(ObjEntityTax);
            return dtReadTax;
        }
    }
}
