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
    public class clsBusinessImmigratnRound
    {

        public void InsertImmigratnRound(clsEntityImmigratnRound objEntityLayerImgratnRnd, List<clsEntityImmigratnRoundDetails> objEntityLayerImgratnRndDtls)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            objDataImgratnRnd.InsertImmigratnRound(objEntityLayerImgratnRnd,objEntityLayerImgratnRndDtls);
        }


        public string CheckDupImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            string strReturn = objDataImgratnRnd.CheckDupImgratnRnd(objEntityLayerImgratnRnd);
            return strReturn;
        }


        public DataTable ReadImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            DataTable dtImgratnRnd = new DataTable();
            dtImgratnRnd = objDataImgratnRnd.ReadImgratnRnd(objEntityLayerImgratnRnd);
            return dtImgratnRnd;
        }


        public DataTable ReadImgratnRndByID(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            DataTable dtImgratnRndById = new DataTable();
            dtImgratnRndById = objDataImgratnRnd.ReadImgratnRndByID(objEntityLayerImgratnRnd);
            return dtImgratnRndById;
        }


        public void UpdateImmigratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd, List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlINSERTList, List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlUPDATEList, List<clsEntityImmigratnRoundDetails> objEntityImgratnRndDtlDELETEList)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            objDataImgratnRnd.UpdateImmigratnRnd(objEntityLayerImgratnRnd, objEntityImgratnRndDtlINSERTList, objEntityImgratnRndDtlUPDATEList, objEntityImgratnRndDtlDELETEList);
        }


        public void CancelImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            objDataImgratnRnd.CancelImgratnRnd(objEntityLayerImgratnRnd);
        }


        public void StatusChangeImgratnRnd(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            objDataImgratnRnd.StatusChangeImgratnRnd(objEntityLayerImgratnRnd);
        }

        public DataTable CheckCancelImgrtnRndId(clsEntityImmigratnRound objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            DataTable dtCancel = new DataTable();
            dtCancel = objDataImgratnRnd.CheckCancelImgrtnRndId(objEntityLayerImgratnRnd);
            return dtCancel;
        }

        public DataTable CheckDeleteImgrtnRndDtlId(clsEntityImmigratnRoundDetails objEntityLayerImgratnRnd)
        {
            clsDataImmigratnRound objDataImgratnRnd = new clsDataImmigratnRound();
            DataTable dtCancel = new DataTable();
            dtCancel = objDataImgratnRnd.CheckDeleteImgrtnRndDtlId(objEntityLayerImgratnRnd);
            return dtCancel;
        }


    }
}
