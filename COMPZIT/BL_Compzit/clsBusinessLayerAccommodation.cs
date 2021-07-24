using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using CL_Compzit;

// CREATED BY:EVM-0009
// CREATED DATE:15/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
   public class clsBusinessLayerAccommodation
    {
        // This Method adds accommodation details to the table
        public int AddAccommodation(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
           int AccId= ObjDataAcco.AddAccommodation(objEntityAcco);
           return AccId;

        }
        // This Method update accommoadation details to the table
        public void UpdateAccommodation(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            ObjDataAcco.UpdateAccommodation(objEntityAcco);
        }

        // This Method checks Accommodation name in the database for duplication.
        public string CheckAccommodationName(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            string count = ObjDataAcco.CheckAccommodationName(objEntityAcco);
            return count;
        }
        //Method for cancel Accommodation
        public void CancelAccommodation(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            ObjDataAcco.CancelAccommodation(objEntityAcco);
        }

        // This Method will fetCH accommodation DEATILS BY ID
        public DataTable ReadAccommodationById(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccodetails = ObjDataAcco.ReadAccommodationById(objEntityAcco);
            return dtAccodetails;
        }
        // This Method will fetch ACCOMODATION list
        public DataTable ReadAccommodationList(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccodetails = ObjDataAcco.ReadAccommodationList(objEntityAcco);
            return dtAccodetails;
        }
        // This Method will fetch ACCOMODATION Type
        public DataTable ReadAccommodationType(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccmdtnType = ObjDataAcco.ReadAccommodationType(objEntityAcco);
            return dtAccmdtnType;
        }
        // This Method will fetch accommmodation CATEGORY DETAIL
        public DataTable ReadAcmdtnDetailByid(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccmdtnTypeDta = ObjDataAcco.ReadAcmdtnDetailByid(objEntityAcco);
            return dtAccmdtnTypeDta;
        }
        //Method for Recall Cancelled Accommodation  from Accommodation  master table so update cancel related fields
        public void Recall_Accommodation(clsEntityAccommodation objEntityAccommodation)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            ObjDataAcco.Recall_Accommodation(objEntityAccommodation);
        }
        //To read employee list from the database
        public DataTable ReadEmployeeList(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccmdtnTypeDta = ObjDataAcco.ReadEmployeeList(objEntityAcco);
            return dtAccmdtnTypeDta;
        }

        //To read SUB CATEGARY DETAIL AGAINST ACCOMODATION from the database
        public DataTable ReadSubCatDetail(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccmdtnTypeDta = ObjDataAcco.ReadSubCatDetail(objEntityAcco);
            return dtAccmdtnTypeDta;
        }
        public void Insert_Sub_Detail(clsEntityAccommodation objEntityAcco, List<clsEntityAccommodation> objEntityAccoAdd, List<clsEntityAccommodation> objEntityAccoEdit, List<clsEntityAccommodation> objEntityAccoDelete)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            ObjDataAcco.Insert_Sub_Detail(objEntityAcco, objEntityAccoAdd, objEntityAccoEdit, objEntityAccoDelete);
        }
        public void StatusChangeInterviewCat(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation objDataInterviewCategory = new clsDataLayerAccommodation();
            objDataInterviewCategory.StatusChangeAccomodation(objEntityAcco);
        }
        public DataTable ReadBusinessUnits(clsEntityAccommodation objEntityAcco)
        {
            clsDataLayerAccommodation ObjDataAcco = new clsDataLayerAccommodation();
            DataTable dtAccmdtnTypeDta = ObjDataAcco.ReadBusinessUnits(objEntityAcco);
            return dtAccmdtnTypeDta;
        }

    }
}
