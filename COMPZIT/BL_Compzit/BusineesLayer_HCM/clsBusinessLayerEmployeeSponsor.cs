using DL_Compzit.DataLayer_HCM;
using EL_Compzit.EntityLayer_GMS;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Compzit.BusinessLayer_HCM
{
  public  class clsBusinessLayerEmployeeSponsor
    {
      public void AddEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            ObjDataCntrct.AddEmployeeSponsor(objEntitySpnsrMstr);
        }

        public void UpdateEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            ObjDataCntrct.UpdateEmployeeSponsor(objEntitySpnsrMstr);
        }
        public void ChangeEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            ObjDataCntrct.ChangeEmployeeSponsor(objEntitySpnsrMstr);
        }
        //// This Method checks job category name in the database for duplication.
        public string CheckEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            string strReturn = ObjDataCntrct.CheckEmployeeSponsor(objEntitySpnsrMstr);
            return strReturn;
        }
        // This Method will fetCH job EmployeeSponsor DEATILS BY ID
        public DataTable ReadEmployeeSponsorById(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataCntrct.ReadEmployeeSponsorById(objEntitySpnsrMstr);
            return dtCategory;
        }
        // This Method will fetch EmployeeSponsor  list
        public DataTable ReadEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataCntrct.ReadEmployeeSponsor(objEntitySpnsrMstr);
            return dtCategory;
        }
        // This Method will fetch EmployeeSponsor  list for search
        public DataTable ReadEmployeeSponsorcancld(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataCntrct.ReadEmployeeSponsorcancld(objEntitySpnsrMstr);
            return dtCategory;
        }
        public DataTable ReadEmployeeSponsorBy_search(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            DataTable dtCategory = new DataTable();
            dtCategory = ObjDataCntrct.ReadEmployeeSponsorBy_search(objEntitySpnsrMstr);
            return dtCategory;
        }
        //Method for cancel job category
       public void CancelEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            ObjDataCntrct.CancelEmployeeSponsor(objEntitySpnsrMstr);
        }
        //Method for Recall Cancelled Complaint from job category master table so update cancel related fields
        public void ReCallEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            ObjDataCntrct.ReCallEmployeeSponsor(objEntitySpnsrMstr);
        }
        //fetch country 
        public DataTable Read_Country()
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            DataTable dtCountry = ObjDataCntrct.ReadCountry();
            return dtCountry;
        }
        public DataTable Read_SponsorType()
        {
            clsDataLayerEmployeeSponsorMaster ObjDataCntrct = new clsDataLayerEmployeeSponsorMaster();
            DataTable dtType = ObjDataCntrct.ReadSponsorType();
            return dtType;
        }
    }
}
