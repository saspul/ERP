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
    public class clsBusinessLayerStateMaster
    {
        //Creating object for data layer.
        clsDataLayerStateMaster objDataLayerStateMaster = new clsDataLayerStateMaster();
        //Fetch country table from datalayer and pass to ui layer.
        public DataTable ReadCountryDetails()
        {
            DataTable dtCountryDetails = objDataLayerStateMaster.ReadCountryDetails();
            return dtCountryDetails;
        }
        //Passing new state details from ui layer to data layer.
        public void AddStateDeatils(clsEntityStateMaster objEntStateMaster)
        {
            objDataLayerStateMaster.AddStateDetails(objEntStateMaster);
        }
        //Fetch state table from datalayer and pass to ui layer.
        public DataTable ReadStateTable(clsEntityStateMaster objEntityState)
        {
            DataTable dtStateTable = objDataLayerStateMaster.ReadStateTable(objEntityState);
            return dtStateTable;
        }
        //Fetch state master table from datalayer according to the id and pass to the ui layer. 
        public DataTable ReadStateMasterEdit(clsEntityStateMaster objEntStateMaster)
        {
            DataTable dtReadStMstrEdit = objDataLayerStateMaster.ReadStateMasterEdit(objEntStateMaster);
            return dtReadStMstrEdit;
        }
        //Accuring data from ui layer and pass to data layer for updating.
        public void UpdateStateTable(clsEntityStateMaster objEntStateMaster)
        {
            objDataLayerStateMaster.UpdateStateDetails(objEntStateMaster);
        }
        //Accuring data about state master status and pass that to datalayer for updating status
        public void UpdateStateStatus(clsEntityStateMaster objEntStateMaster)
        {
            if (objEntStateMaster.StateStatus == 1)
            {
                objEntStateMaster.StateStatus = 0;
            }
            else
            {
                objEntStateMaster.StateStatus = 1;
            }
            objDataLayerStateMaster.UpdateStateStatus(objEntStateMaster);
        }
        //passing data about state cancel to data layer from ui layer.
        public void UpdateStateCancel(clsEntityStateMaster objEntStateMaster)
        {
            objDataLayerStateMaster.UpdateStateCancel(objEntStateMaster);
        }
        //Method for passing state name and state name count in table in between two tables.
        public DataTable CheckStateName(clsEntityStateMaster objEntStateMaster)
        {
            DataTable dtStateName = objDataLayerStateMaster.Check_State_Name(objEntStateMaster);
            return dtStateName;
        }
        //Method for passing state name and state name count in table in between two tables at the time of updation
        public string CheckStateNameUpdate(clsEntityStateMaster objEntStateMaster)
        {
           string strStateCount = objDataLayerStateMaster.Check_State_NameUpdate(objEntStateMaster);
            return strStateCount;
        }
    }
}
