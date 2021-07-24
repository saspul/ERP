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
    public class clsBusinessLayerWorkStation
    {
        //Creating object for datalayer
        clsDataLayerWorkStation objDataLayerWorkStation = new clsDataLayerWorkStation();
        //Method of passing work area table from datalayer to ui layer
        public DataTable ReadWorkArea(clsEntityWorkStation objEntityStation)
        {
            DataTable dtArea = objDataLayerWorkStation.ReadWorkArea(objEntityStation);
            return dtArea;
        }
        //Method of passing work station name count that have in the table.
        public string Check_WorkStation_Name(clsEntityWorkStation objEntityStation)
        {
            string strCount = objDataLayerWorkStation.CheckWorkStationName(objEntityStation);
            return strCount;
        }
        //Method of passing data about work station for insertion from ui layer to datalayer.
        public void Insert_WorkStation(clsEntityWorkStation objEntityStation)
        {
            objDataLayerWorkStation.Insert_Station(objEntityStation);
        }
        //Method for passing workstation master table from datalayer to uilayer for list view.
        public DataTable ReadWorkStationList(clsEntityWorkStation objEntityStation)
        {
            DataTable dtStationList = objDataLayerWorkStation.ReadWorkStationList(objEntityStation);
            return dtStationList;
        }
        //Passing the details about new status about the work station
        public void Update_WorkStatus_Status(clsEntityWorkStation objEntityStation)
        {
            if (objEntityStation.WorkStation_Status == 1)
            {
                objEntityStation.WorkStation_Status = 0;
            }
            else
            {
                objEntityStation.WorkStation_Status = 1;
            }
            objDataLayerWorkStation.Update_WorkStation_Status(objEntityStation);
        }
        //Method of passing work station table from datalayer to ui layer with their id
        public DataTable ReadWorkStationById(clsEntityWorkStation objEntityStation)
        {
            DataTable dtStationById = objDataLayerWorkStation.ReadWorkStationListById(objEntityStation);
            return dtStationById;
        }
        //Method for passing data about work station modification for updation ui layer to data layer
        public void Update_WorkStation(clsEntityWorkStation objEntityStation)
        {
            objDataLayerWorkStation.Update_WorkStation(objEntityStation);
        }
        //Passing work area station for checking duplication at the time of updation
        public string Check_WorkStation_NameUpdation(clsEntityWorkStation objEntityStation)
        {
            string strCount = objDataLayerWorkStation.CheckWorkStationNameUpdate(objEntityStation);
            return strCount;
        }
        //Method for cancel the work station so passing data about the work station that get cancel
        public void Cancel_WorkStation(clsEntityWorkStation objEntityStation)
        {
            objDataLayerWorkStation.Cancel_WorkStation(objEntityStation);
        }
    }
}
