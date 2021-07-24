using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using CL_Compzit;

// CREATED BY:EVM-0007
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit
{
   public class clsBusinessLayerTimeslot
    {
        //Creating object for datalayer
        clsDataLayerTimeslot objDataLayerTimeslot = new clsDataLayerTimeslot();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //Method for read Complaint Category for set dropdownlist
        //public DataTable ReadComplaintCtgry(clsEntityComplaint objEntityComplaint)
        //{
        //    DataTable dtResultSet = objDataLayerComplaint.ReadComplaintCtgry(objEntityComplaint);
        //    return dtResultSet;
        //}
        //Method for check Timeslot_Name already exist in the table or not.
        public string CheckTimeslotName(clsEntityTimeslot objEntityTimeslot)
        {
            string strCount = objDataLayerTimeslot.CheckTimeslotName(objEntityTimeslot);
            return strCount;
        }
        public DateTime textWithTimeToDateTime(string strSearchText)
        {
            DateTime dtSearchText = objCommonLibrary.textWithTimeToDateTime(strSearchText);
            return dtSearchText;
        }

        //Method of passing data about Timeslot for insertion from ui layer to datalayer.
        public void Insert_Timeslot(clsEntityTimeslot objEntitTimeslot)
        {
            objDataLayerTimeslot.Insert_Timeslot(objEntitTimeslot);
        }
        //Method for passing Timeslot master table from datalayer to uilayer for list view.
        public DataTable ReadTimeslotList(clsEntityTimeslot objEntityTimeslot)
        {
            DataTable dtResultSet = objDataLayerTimeslot.ReadTimeslotList(objEntityTimeslot);
            return dtResultSet;
        }

        //Method of passing Timeslot table from datalayer to ui layer with their id
        public DataTable ReadTimeslotById(clsEntityTimeslot objEntityTimeslot)
        {
            DataTable dtResultSet = objDataLayerTimeslot.ReadTimeslotById(objEntityTimeslot);
            return dtResultSet;
        }
        //Method for passing data about Timeslot modification for updation ui layer to data layer
        public void Update_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            objDataLayerTimeslot.Update_Timeslot(objEntityTimeslot);
        }
        //Method for cancel the Timeslot so passing data about timeslot that get cancel
        public void Cancel_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            objDataLayerTimeslot.Cancel_Timeslot(objEntityTimeslot);
        }
        //Method for Recall Cancelled Timeslot from Timeslot master table so update cancel related fields
        public void Recall_Timeslot(clsEntityTimeslot objEntityTimeslot)
        {
            objDataLayerTimeslot.Recall_Timeslot(objEntityTimeslot);
        }
        public void Update_Timeslot_Status(clsEntityTimeslot objEntitTimeslot)
        {
            objDataLayerTimeslot.Update_Timeslot_Status(objEntitTimeslot);
        }
    }
}
