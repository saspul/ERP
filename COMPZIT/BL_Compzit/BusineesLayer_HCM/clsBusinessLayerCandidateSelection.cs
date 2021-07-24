using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit.DataLayer_GMS;
using EL_Compzit.EntityLayer_GMS;
using System.Data;
using DL_Compzit.HCM;
using EL_Compzit.HCM;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
namespace BL_Compzit
{
    public class clsBusinessLayerCandidateSelection
    {
        clsDataLayerCandidateSelection objDataCandidateSelection = new clsDataLayerCandidateSelection();
        public DataTable ReadAprvdManPwrReqstList(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtList = objDataCandidateSelection.ReadAprvdManPwrReqstList(objEntityCandidateSel);
            return dtList;
        }
        public DataTable ReadProject(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtPrj = objDataCandidateSelection.ReadProject(objEntityCandidateSel);
            return dtPrj;
        }
        public DataTable ReadDivision(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtDiv = objDataCandidateSelection.ReadDivision(objEntityCandidateSel);
            return dtDiv;
        }
        public DataTable ReadDepartment(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtDpt = objDataCandidateSelection.ReadDepartment(objEntityCandidateSel);
            return dtDpt;
        }
        public DataTable ReadConsultancies(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtDpt = objDataCandidateSelection.ReadConsultancies(objEntityCandidateSel);
            return dtDpt;
        }
         public DataTable ReadEmployee(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtDpt = objDataCandidateSelection.ReadEmployee(objEntityCandidateSel);
            return dtDpt;
        }

        public DataTable ReadManPwrReqstById(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtPrj = objDataCandidateSelection.ReadManPwrReqstById(objEntityCandidateSel);
            return dtPrj;
        }
        public DataTable ReadinterviewTemList(clsEntityCandidateSelection objEntityCandidateSel)
        {
            DataTable dtPrj = objDataCandidateSelection.ReadinterviewTemList(objEntityCandidateSel);
            return dtPrj;
        }
        //fetch country 
        public DataTable ReadCountry()
        {
            DataTable dtCountry = objDataCandidateSelection.ReadCountry();
            return dtCountry;
        }
        public void InsertCandidateSel(clsEntityCandidateSelection objEntityTemp, List<clsEntityCandSelectionDtl> objCandSelectionDtl)
        {
            objDataCandidateSelection.InsertCandidateSel(objEntityTemp, objCandSelectionDtl);
        }

        public void UpdateCandidateSel(clsEntityCandidateSelection objEntityTemp, List<clsEntityCandSelectionDtl> objEntityCandSelDtlINSERTList, List<clsEntityCandSelectionDtl> objEntityCandSelDtlUPDATEList, List<clsEntityCandSelectionDtl> objEntityCandSelDtlDELETEList)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            objDataCandidateSelection.UpdateCandidateSel(objEntityTemp, objEntityCandSelDtlINSERTList, objEntityCandSelDtlUPDATEList, objEntityCandSelDtlDELETEList);
        }
        public DataTable ReadCandidateListByID(clsEntityCandidateSelection objEntityTemp)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            DataTable dtCand= objDataCandidateSelection.ReadCandidateListByID(objEntityTemp);
            return dtCand;
        }
        public string CheckInterviewPanel(clsEntityCandidateSelection clsEntityCandidateSelection)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            string strCount = objDataCandidateSelection.CheckInterviewPanel(clsEntityCandidateSelection);
            return strCount;
        }
        public DataTable ReadNoDelCandidateList(clsEntityCandidateSelection objEntityTemp)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            DataTable dtCand = objDataCandidateSelection.ReadNoDelCandidateList(objEntityTemp);
            return dtCand;
        }
    }
}
