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
    public class clsBusinessLayerConsultancyMaster
    {
        //This Method for fetching the COUNTRY LIST
        public DataTable ReadCountryList()
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            DataTable dtCountryList = objDataConslt.ReadCountryList();
            return dtCountryList;

        }
        //This Method for fetching the Consultancy type
        public DataTable ReadConsultancytype()
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            DataTable dtConsultancytype = objDataConslt.ReadConsultancytype();
            return dtConsultancytype;
        }
        // This Method adds Consultancy details to the database
        public void AddConsultancyMstr(clsEntityConsultancyMaster objEntityConslt)
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            objDataConslt.AddConsultancyMstr(objEntityConslt);
        }
        // This Method checks Consultancy Name in the database for duplication (FOR UPDATE AND INSERT)
        public string CheckDupConsultancyName(clsEntityConsultancyMaster objEntityConslt)
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            string strReturn = objDataConslt.CheckDupConsultancyName(objEntityConslt);
            return strReturn;

        }
        //Read Consultancy list 
        public DataTable ReadConsultancyList(clsEntityConsultancyMaster objEntityConslt)
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            DataTable dtConsultancyList = new DataTable();
            dtConsultancyList = objDataConslt.ReadConsultancyList(objEntityConslt);
            return dtConsultancyList;
        }
        //Read Consultancy DETAIL 
        public DataTable ReadConsultancyByID(clsEntityConsultancyMaster objEntityConslt)
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            DataTable dtConsultancyDetails = new DataTable();
            dtConsultancyDetails = objDataConslt.ReadConsultancyByID(objEntityConslt);
            return dtConsultancyDetails;
        }
         // This Method update Consultancy details 
        public void UpdateConsultancyMstr(clsEntityConsultancyMaster objEntityConslt)
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            objDataConslt.UpdateConsultancyMstr(objEntityConslt);
        }
        // This Method delete Consultancy details 
        public void CancelConsultancyMstr(clsEntityConsultancyMaster objEntityConslt)
        {
            clsDataLayerConsultancyMaster objDataConslt = new clsDataLayerConsultancyMaster();
            objDataConslt.CancelConsultancyMstr(objEntityConslt);
        }
    }
}
