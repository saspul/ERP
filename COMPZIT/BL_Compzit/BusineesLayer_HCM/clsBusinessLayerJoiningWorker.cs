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
    public class clsBusinessLayerJoiningWorker
    {
        public DataTable ReadCandidateData(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            DataTable dtDpt = objDataLayerJoiningWorker.ReadCandidateData(objEntityJoiningWorker);
            return dtDpt;
        }
        public DataTable ReadCandidate(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            DataTable dtDpt = objDataLayerJoiningWorker.ReadCandidate(objEntityJoiningWorker);
            return dtDpt;
        }
        public DataTable ReadJoinigWorkerList(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            DataTable dtDpt = objDataLayerJoiningWorker.ReadJoinigWorkerList(objEntityJoiningWorker);
            return dtDpt;
        }
        public void InsertJoiningWorker(clsEntityJoiningWorker objEntityJoiningWorker, List<clsJoiningWorkerDtl> objEntityJoiningWorkerDetilsList)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            objDataLayerJoiningWorker.InsertJoiningWorker(objEntityJoiningWorker, objEntityJoiningWorkerDetilsList);

        }
        public DataTable ReadJoinigWorkerByID(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            DataTable dtDpt = objDataLayerJoiningWorker.ReadJoinigWorkerByID(objEntityJoiningWorker);
            return dtDpt;
        }
        public DataTable ReadJoinigWkrDtlByID(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            DataTable dtDpt = objDataLayerJoiningWorker.ReadJoinigWkrDtlByID(objEntityJoiningWorker);
            return dtDpt;
        }
        public void UpdateJoiningWorker(clsEntityJoiningWorker objEntityJoiningWorker, List<clsJoiningWorkerDtl> objEntityJoiningWorkerDetilsList, List<clsJoiningWorkerDtl> objEntityJoiningWkrDtlsDELETEList)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            objDataLayerJoiningWorker.UpdateJoiningWorker(objEntityJoiningWorker, objEntityJoiningWorkerDetilsList, objEntityJoiningWkrDtlsDELETEList);
        }

        // This Method delete JoiningWkr details 
        public void CancelJoiningWkr(clsEntityJoiningWorker objEntityJoiningWorker)
        {
          clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
          objDataLayerJoiningWorker.CancelJoiningWkr(objEntityJoiningWorker);
        }

        public void UpdateCnfrmSts(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            objDataLayerJoiningWorker.UpdateCnfrmSts(objEntityJoiningWorker);
        }

        public string CheckPassNo(clsEntityJoiningWorker objEntityJoiningWorker)
        {
            clsDataLayerJoiningWorker objDataLayerJoiningWorker = new clsDataLayerJoiningWorker();
            string strReturn = objDataLayerJoiningWorker.CheckPassNo(objEntityJoiningWorker);
            return strReturn;
        }
    }
}
