using DL_Compzit.DataLayer_HCM;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class cls_Business_Certificate_Bundel_Template
    {

        public DataTable ReadCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
        {
            cls_Data_Certificate_Bundel_Template objDataCrtificateBundel = new cls_Data_Certificate_Bundel_Template();
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataCrtificateBundel.ReadCertificateTemplate(objEntityCertificateBundel);
            return dtInterviewCatList;
        }


        public string CheckDupCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
        {
            cls_Data_Certificate_Bundel_Template objDataCrtificateBundel = new cls_Data_Certificate_Bundel_Template();
            string strReturn = objDataCrtificateBundel.CheckDupCertificateTemplate(objEntityCertificateBundel);
            return strReturn;
        }


        public void InsertCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel, List<clsEntity_Certificate_Bundel_Template_details> objCertificatebundelDtls)
        {
            cls_Data_Certificate_Bundel_Template objDataCertificateBundel = new cls_Data_Certificate_Bundel_Template();
            objDataCertificateBundel.InsertCertificateTemplate(objEntityCertificateBundel, objCertificatebundelDtls);
        }


        public string CheckDupInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            string strReturn = objDataInterviewCategory.CheckDupInterviewCategory(objEntityInterviewCategory);
            return strReturn;
        }
        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void UpdateCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctINSERTList, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctUPDATEList, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctDELETEList)
        {
            cls_Data_Certificate_Bundel_Template objDataCertificateBndel = new cls_Data_Certificate_Bundel_Template();
            objDataCertificateBndel.UpdateCertificateTemplate(objEntityCertificateBundel, objEntityCertfctINSERTList, objEntityCertfctUPDATEList, objEntityCertfctDELETEList);
        }
        //Read InterviewCat list 
        public DataTable ReadInterviewCatList(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataInterviewCategory.ReadInterviewCatList(objEntityInterviewCategory);
            return dtInterviewCatList;
        }
        //Read InterviewCat BY ID 
        public DataTable ReadInterviewCatByID(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
        {
            cls_Data_Certificate_Bundel_Template objDataCertificateBndel = new cls_Data_Certificate_Bundel_Template();
            DataTable dtInterviewCatByID = new DataTable();
            dtInterviewCatByID = objDataCertificateBndel.ReadInterviewCatByID(objEntityCertificateBundel);
            return dtInterviewCatByID;
        }
        //Cancel InterviewCat 
        public void CancelCertificateBndl(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
        {
            cls_Data_Certificate_Bundel_Template objDataCertificateBundel = new cls_Data_Certificate_Bundel_Template();
            objDataCertificateBundel.CancelCertificateBndl(objEntityCertificateBundel);
        }

        public void StatusChangeCertificateBundel(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
        {
            cls_Data_Certificate_Bundel_Template objDataCertificateBundel = new cls_Data_Certificate_Bundel_Template();
            objDataCertificateBundel.StatusChangeCertificateBundel(objEntityCertificateBundel);
        }





    }







}
