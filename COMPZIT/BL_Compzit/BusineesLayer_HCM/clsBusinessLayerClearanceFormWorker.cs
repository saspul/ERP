using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;


namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusinessLayerClearanceFormWorker
    {
        //Read employee list
        public DataTable ReadEmployee(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerList = objDataClearanceFormWorker.ReadEmployee(objEntityClearanceFormWorker);
            return dtClearanceFormWorkerList;
        }
      
        //Read Leave list
        public DataTable ReadLeave(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerList = objDataClearanceFormWorker.ReadLeave(objEntityClearanceFormWorker);
            return dtClearanceFormWorkerList;
        }
        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker, List<clsEntityClearanceFormWorkerDetail> objClearanceFormWorkerDtls)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            objDataClearanceFormWorker.InsertClearanceFormWorker(objEntityClearanceFormWorker, objClearanceFormWorkerDtls);
        }

        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityClearanceFormWorker, objEntityClearanceFormWkrINSERTList, objEntityClearanceFormWkrUPDATEList, objEntityClearanceFormWkrDELETEList)
        public void UpdateClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker, List<clsEntityClearanceFormWorkerDetail> objEntityClearanceFormWkrINSERTList, List<clsEntityClearanceFormWorkerDetail> objEntityClearanceFormWkrUPDATEList, List<clsEntityClearanceFormWorkerDetail> objEntityClearanceFormWkrDELETEList)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            objDataClearanceFormWorker.UpdateClearanceFormWorker(objEntityClearanceFormWorker, objEntityClearanceFormWkrINSERTList, objEntityClearanceFormWkrUPDATEList, objEntityClearanceFormWkrDELETEList);
        }
        //Read ClearanceFormWorker list 
        public DataTable ReadClearanceFormWorkerList(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerList = objDataClearanceFormWorker.ReadClearanceFormWorkerList(objEntityClearanceFormWorker);

            return dtClearanceFormWorkerList;
        }
        //Read worker list
        public DataTable ReadWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();

            DataTable dtClearanceFormWorkerList = objDataClearanceFormWorker.ReadWorker(objEntityClearanceFormWorker);
            return dtClearanceFormWorkerList;
        }


        //Read ClearanceFormWorker BY ID 
        public DataTable ReadClearanceFormWorkerByID(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerByID = objDataClearanceFormWorker.ReadClearanceFormWorkerByID(objEntityClearanceFormWorker);

            return dtClearanceFormWorkerByID;
        }
        //Read ClearanceFormWorker Detail BY ID 
        public DataTable ReadClearanceFormWkrDetailByID(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerByID = objDataClearanceFormWorker.ReadClearanceFormWkrDetailByID(objEntityClearanceFormWorker);

            return dtClearanceFormWorkerByID;
        }
        // This Method delete Consultancy details 
        public void CancelClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            objDataClearanceFormWorker.CancelClearanceFormWorker(objEntityClearanceFormWorker);
        }
        public void RejectClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            objDataClearanceFormWorker.RejectClearanceFormWorker(objEntityClearanceFormWorker);
        }
        //Read employee details
        public DataTable ReadEmployeeDtls(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerByID = objDataClearanceFormWorker.ReadEmployeeDtls(objEntityClearanceFormWorker);

            return dtClearanceFormWorkerByID;
        }
        public void ApproveClearanceFormWorker(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            objDataClearanceFormWorker.ApproveClearanceFormWorker(objEntityClearanceFormWorker);
        }

        //procedure for handover
        public DataTable ReadHadover(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearance = objDataClearanceFormWorker.ReadHadover(objEntityClearanceFormWorker);


            return dtClearance;

        }
        public void UpdateHadover(List<clsEntityLayerClearanceFormWorker> objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            objDataClearanceFormWorker.UpdateHadover(objEntityClearanceFormWorker);
        }
        public DataTable ReadTrvlDtls(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerByID = objDataClearanceFormWorker.ReadTrvlDtls(objEntityClearanceFormWorker);

            return dtClearanceFormWorkerByID;
        }
        public DataTable ReadClearanceFormList(clsEntityLayerClearanceFormWorker objEntityClearanceFormWorker)
        {
            clsDataLayerClearanceFormWorker objDataClearanceFormWorker = new clsDataLayerClearanceFormWorker();
            DataTable dtClearanceFormWorkerList = objDataClearanceFormWorker.ReadClearanceFormList(objEntityClearanceFormWorker);
            return dtClearanceFormWorkerList;
        }
    }
}
