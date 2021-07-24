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
    public class clsBusinessLayerInterviewCategory
    {
         //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory, List<clsEntityInterviewCategoryDetails> objInterviewCategoryDtls)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            objDataInterviewCategory.InsertInterviewCategory(objEntityInterviewCategory, objInterviewCategoryDtls);
        }
         // This Method checks interviewCategory Name in the database for duplication
        public string CheckDupInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            string strReturn = objDataInterviewCategory.CheckDupInterviewCategory(objEntityInterviewCategory);
            return strReturn;
        }
         //Methode of inserting values to Interview Category and Interview Category Details table.
         public void UpdateInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory, List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlINSERTList,List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlUPDATEList,List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlDELETEList)
         {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            objDataInterviewCategory.UpdateInterviewCategory(objEntityInterviewCategory, objEntityIntwCatDtlINSERTList, objEntityIntwCatDtlUPDATEList, objEntityIntwCatDtlDELETEList);
        }
        //Read InterviewCat list 
        public DataTable ReadInterviewCatList(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList=objDataInterviewCategory.ReadInterviewCatList(objEntityInterviewCategory);
            return dtInterviewCatList;
        }
        //Read InterviewCat BY ID 
        public DataTable ReadInterviewCatByID(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            DataTable dtInterviewCatByID = new DataTable();
            dtInterviewCatByID = objDataInterviewCategory.ReadInterviewCatByID(objEntityInterviewCategory);
            return dtInterviewCatByID;
        }
        //Cancel InterviewCat 
        public void CancelInterviewCat(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            objDataInterviewCategory.CancelInterviewCat(objEntityInterviewCategory);
        }
        //status change InterviewCat 
        public void StatusChangeInterviewCat(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            clsDataLayerInterviewCategory objDataInterviewCategory = new clsDataLayerInterviewCategory();
            objDataInterviewCategory.StatusChangeInterviewCat(objEntityInterviewCategory);
        }
    }
}
