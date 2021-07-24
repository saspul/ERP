using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:18/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerCityMaster
    {
        //Creating object for data layer.
        clsDataLayerCityMaster objDataLayerCityMaster = new clsDataLayerCityMaster();
        //Fetch State table from datalayer and pass to ui layer.
        public DataTable ReadStateDetails()
        {
            DataTable dtStateDetails = objDataLayerCityMaster.ReadStateDetails();
            return dtStateDetails;
        }
        //Passing new City details from ui layer to data layer.
        public void AddCityDeatils(clsEntityCityMaster objEntCityMaster)
        {
            objDataLayerCityMaster.AddCityDetails(objEntCityMaster);
        }
        //Fetch City table from datalayer and pass to ui layer.
        public DataTable ReadCityTable(clsEntityCityMaster objEntityCityMaster)
        {
            DataTable dtCityTable = objDataLayerCityMaster.ReadCityTable(objEntityCityMaster);
            return dtCityTable;
        }
        //Fetch City master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadCityMasterEdit(clsEntityCityMaster objEntCityMaster)
        {
            DataTable dtReadCityMstrEdit = objDataLayerCityMaster.ReadCityMasterEdit(objEntCityMaster);
            return dtReadCityMstrEdit;
        }
        //Accuring data from ui layer and pass to data layer for city updating.
        public void UpdateCityTable(clsEntityCityMaster objEntCityMaster)
        {
            objDataLayerCityMaster.UpdateCityDetails(objEntCityMaster);
        }
        //Accuring data about city master status and pass that to datalayer for updating status
        public void UpdateCityStatus(clsEntityCityMaster objEntCityMaster)
        {
            if (objEntCityMaster.CityStatus == 1)
            {
                objEntCityMaster.CityStatus = 0;
            }
            else
            {
                objEntCityMaster.CityStatus = 1;
            }
            objDataLayerCityMaster.UpdateCityStatus(objEntCityMaster);
        }
        //passing data about city cancel to data layer from ui layer.
        public void UpdateCityCancel(clsEntityCityMaster objEntCityMaster)
        {
            objDataLayerCityMaster.UpdateCityCancel(objEntCityMaster);
        }
        //Method for passing city name and city name count in table in between two tables.
        public DataTable CheckCityName(clsEntityCityMaster objEntCityMaster)
        {
            DataTable dtCityName = objDataLayerCityMaster.CheckCityName(objEntCityMaster);
            return dtCityName;
        }
        //Method for passing city name and city name count in table in between two tables at the time updation
        public string CheckCityNameUpdate(clsEntityCityMaster objEntCityMaster)
        {
            string strCityCount = objDataLayerCityMaster.CheckCityNameUpdate(objEntCityMaster);
            return strCityCount;
        }
    }
}
