using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:08/06/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerWorkArea
    {
        //Creating object for datalayer
        clsDataLayerWorkArea objDataLayerWorkArea = new clsDataLayerWorkArea();
        //Method of passing premise table from datalayer to ui layer
        public DataTable ReadPremise(clsEntityWorkArea objEntityArea)
        {
            DataTable dtPremise = objDataLayerWorkArea.ReadPremise(objEntityArea);
            return dtPremise;
        }
        //Method of passing work area name count that have in the table.
        public string Check_WorkArea_Name(clsEntityWorkArea objEntityArea)
        {
            string strCount = objDataLayerWorkArea.CheckWorkAreaName(objEntityArea);
            return strCount;
        }
        //Method of passing data about work area for insertion from ui layer to datalayer.
        public void Insert_WorkArea(clsEntityWorkArea objEntityArea)
        {
            objDataLayerWorkArea.Insert_Area(objEntityArea);
        }
        //Method for passing workarea master table from datalayer to uilayer for list view.
        public DataTable ReadWorkAreaList(clsEntityWorkArea objEntityArea)
        {
            DataTable dtAreaList = objDataLayerWorkArea.ReadWorkAreaList(objEntityArea);
            return dtAreaList;
        }
        //Passing the details about new status about the work area
        public void Update_WorkArea_Status(clsEntityWorkArea objEntityArea)
        {
            if (objEntityArea.WorkArea_Status == 1)
            {
                objEntityArea.WorkArea_Status = 0;
            }
            else
            {
                objEntityArea.WorkArea_Status = 1;
            }
            objDataLayerWorkArea.Update_WorkArea_Status(objEntityArea);
        }
        //Method of passing work area table from datalayer to ui layer with their id
        public DataTable ReadWorkAreaById(clsEntityWorkArea objEntityArea)
        {
            DataTable dtAreaById = objDataLayerWorkArea.ReadWorkAreaListById(objEntityArea);
            return dtAreaById;
        }
        //Method for passing data about work area modification for updation ui layer to data layer
        public void Update_WorkArea(clsEntityWorkArea objEntityArea)
        {
            objDataLayerWorkArea.Update_WorkArea(objEntityArea);
        }
        //Passing work area name for checking duplication at the time of updation
        public string Check_WorkArea_NameUpdation(clsEntityWorkArea objEntityArea)
        {
            string strCount = objDataLayerWorkArea.CheckWorkAreaNameUpdate(objEntityArea);
            return strCount;
        }
        //Method for cancel the work area so passing data about the work area that get cancel
        public void Cancel_WorkArea(clsEntityWorkArea objEntityArea)
        {
            objDataLayerWorkArea.Cancel_WorkArea(objEntityArea);
        }
    }
}
