using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:16/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerUomMaster
    {
        //Creating objects for datalayer
        clsDataLayerUomMaster objDataLayerUom = new clsDataLayerUomMaster();
        //Method of passing Uom details from ui layer to datalayer for insertion
        public void AddUomMaster(clsEntityUomMaster ObjEntityUom)
        {
            objDataLayerUom.AddUomMstr(ObjEntityUom);
        }
        //Method of passing new status deatils from ui layer to datalayerfor status change
        public void UomStausChange(dynamic objEntityUom)
        {
            objDataLayerUom.UomStatusChange(objEntityUom);
        }
        //Method of passing Uom details from ui layer to data layer for updation
        public void UpdateUom(clsEntityUomMaster objEntityUom)
        {
            objDataLayerUom.UpdateUom(objEntityUom);
        }

        //Method of passing the count of Uom name that exist in the table
        public string CheckUomName(dynamic objEntityUom)
        {
            string strUomNameCount = objDataLayerUom.CheckUomName(objEntityUom);
            return strUomNameCount;
        }
        //Method of passing the count of Uom code that exist in the table
        public string CheckUomCode(dynamic objEntityUom)
        {
            string strUomCodeCount = objDataLayerUom.CheckUomCode(objEntityUom);
            return strUomCodeCount;
        }
        //Method of passing uom master table data from datalayer to ui layer
        public DataTable ReadUomById(clsEntityUomMaster ObjEntityUom)
        {
            DataTable dtReadUom = objDataLayerUom.ReadUomById(ObjEntityUom);
            return dtReadUom;
        }

        //passing data about Uom cancel to data layer from ui layer.
        public void CancelUomMaster(clsEntityUomMaster objEntityUom)
        {
            objDataLayerUom.CancelUom(objEntityUom);
        }

        public DataTable ReadUOMTableList(clsEntityUomMaster objEntityUom)
        {
            DataTable dtUOMTable = objDataLayerUom.ReadUnitMasterTable(objEntityUom);
            return dtUOMTable;
        }
       
    }
}
