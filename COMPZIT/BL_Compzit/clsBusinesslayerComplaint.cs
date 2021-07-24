using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;

// CREATED BY:EVM-0001
// CREATED DATE:02/11/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinesslayerComplaint
    {
        //Creating object for datalayer
        clsDataLayerComplaint objDataLayerComplaint = new clsDataLayerComplaint();
        //Method for read Complaint Category for set dropdownlist
        public DataTable ReadComplaintCtgry(clsEntityComplaint objEntityComplaint)
        {
            DataTable dtResultSet = objDataLayerComplaint.ReadComplaintCtgry(objEntityComplaint);
            return dtResultSet;
        }
        //Method for check Complaint Description already exist in the table or not.
        public string CheckComplaintDesc(clsEntityComplaint objEntityComplaint)
        {
            string strCount = objDataLayerComplaint.CheckComplaintDesc(objEntityComplaint);
            return strCount;
        }
        //Method of passing data about Complaint for insertion from ui layer to datalayer.
        public void Insert_Complaint(clsEntityComplaint objEntityComplaint)
        {
            objDataLayerComplaint.Insert_Complaint(objEntityComplaint);
        }
        //Method for passing Complaint master table from datalayer to uilayer for list view.
        public DataTable ReadComplaintList(clsEntityComplaint objEntityComplaint)
        {
            DataTable dtResultSet = objDataLayerComplaint.ReadComplaintList(objEntityComplaint);
            return dtResultSet;
        }
       
        //Method of passing Complaint table from datalayer to ui layer with their id
        public DataTable ReadComplaintById(clsEntityComplaint objEntityComplaint)
        {
            DataTable dtResultSet = objDataLayerComplaint.ReadComplaintById(objEntityComplaint);
            return dtResultSet;
        }
        //Method for passing data about Complaint modification for updation ui layer to data layer
        public void Update_Complaint(clsEntityComplaint objEntityComplaint)
        {
            objDataLayerComplaint.Update_Complaint(objEntityComplaint);
        }
        //Method for cancel the complaint so passing data about complaint that get cancel
        public void Cancel_Complaint(clsEntityComplaint objEntityComplaint)
        {
            objDataLayerComplaint.Cancel_Complaint(objEntityComplaint);
        }
        //Method for Recall Cancelled Complaint from Complaint master table so update cancel related fields
        public void Recall_Complaint(clsEntityComplaint objEntityComplaint)
        {
            objDataLayerComplaint.Recall_Complaint(objEntityComplaint);
        }
        public void Update_Complaint_Status(clsEntityComplaint objEntityComplaint)
        {
            objDataLayerComplaint.Update_Complaint_Status(objEntityComplaint);
        }
    }
}
