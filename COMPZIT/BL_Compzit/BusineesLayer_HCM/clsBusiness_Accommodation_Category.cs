using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusineesLayer_HCM
{
    public class clsBusiness_Accommodation_Category
    {
        public void InsertAccomodationTemplate(clsEntity_Accommodation_Cat objEntityAccomdtncat, List<cls_Entity_Accommodation_Category_list> objAccomdntncatlist)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            objDataAccomdtioncat.InsertAccomodationTemplate(objEntityAccomdtncat, objAccomdntncatlist);
        }
        public DataTable ReadAccommodationCatByID(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            DataTable dtInterviewCatByID = new DataTable();
            dtInterviewCatByID = objDataAccomdtioncat.ReadAccommodationCatByID(objEntityAccomdtncat);
            return dtInterviewCatByID;
        }
        public void UpdateAccommodationCat(clsEntity_Accommodation_Cat objEntityAccomdtncat, List<cls_Entity_Accommodation_Category_list> objEntityCertfctINSERTList, List<cls_Entity_Accommodation_Category_list> objEntityCertfctUPDATEList, List<cls_Entity_Accommodation_Category_list> objEntityCertfctDELETEList)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            objDataAccomdtioncat.UpdateAccommodationCat(objEntityAccomdtncat, objEntityCertfctINSERTList, objEntityCertfctUPDATEList, objEntityCertfctDELETEList);
        }
        public void CancelAccommodtincat(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            objDataAccomdtioncat.CancelAccommodtincat(objEntityAccomdtncat);
        }
        public string CheckDupCertificateTemplate(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            string strReturn = objDataAccomdtioncat.CheckDupCertificateTemplate(objEntityAccomdtncat);
            return strReturn;
        }
        public DataTable ReadAccomdtncat(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            DataTable dtInterviewCatList = new DataTable();
            dtInterviewCatList = objDataAccomdtioncat.ReadAccomdtncat(objEntityAccomdtncat);
            return dtInterviewCatList;
        }
        public DataTable Readcatname(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            DataTable dtReadsupplier = objDataAccomdtioncat.Readcatname(objEntityAccomdtncat);
            return dtReadsupplier;
        }
        public void StatusChangeAccoomdtn(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            objDataAccomdtioncat.StatusChangeAccoomdtn(objEntityAccomdtncat);
        }
        public string CheckSubCat(cls_Entity_Accommodation_Category_list objEntityAccomdtncat)
        {
            clsData_Accommodation_Category objDataAccomdtioncat = new clsData_Accommodation_Category();
            string strCount=objDataAccomdtioncat.CheckSubCat(objEntityAccomdtncat);
            return strCount;
        }
    }
}
