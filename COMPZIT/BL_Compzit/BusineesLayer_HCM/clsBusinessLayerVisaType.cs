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
    public class clsBusinessLayerVisaType
    {
        clsDataLayerVisaType objDataLayerVisaType = new clsDataLayerVisaType();
        //Method for obtaining data from visa type table.
        public DataTable ReadDetails(clsEntityLayerVisaType objEntityVisa)
        {
            DataTable dtOrgDetal = objDataLayerVisaType.ReadDetails(objEntityVisa);
            return dtOrgDetal;
        }
        // This Method for adding data to the visa type table
        public void addDetails(clsEntityLayerVisaType objEntityVisa)
        {
            objDataLayerVisaType.addDetails(objEntityVisa);
        }
        //for checking duplication of visa name
        public string ReadVisaName(clsEntityLayerVisaType objEntityVisa)
        {
            string count = objDataLayerVisaType.ReadVisaName(objEntityVisa);
            return count;
        }
        //update visa status 
        public void ChangeStatus(clsEntityLayerVisaType objEntityVisa)
        {
            objDataLayerVisaType.ChangeStatus(objEntityVisa);
        }

        //update Data Fetch 
        public DataTable getDetails_ById(clsEntityLayerVisaType objEntityVisa)
        {
            DataTable dt = new DataTable();
            dt = objDataLayerVisaType.getDetailsById(objEntityVisa);
            return dt;
        }
        //update visa status 
        public void updateVisa(clsEntityLayerVisaType objEntityVisa)
        {
            objDataLayerVisaType.Update_Visa(objEntityVisa);
        }
        //Cancel visa type 
        public void CancelVisa(clsEntityLayerVisaType objEntityVisa)
        {
            objDataLayerVisaType.Cancel_Visa(objEntityVisa);
        }

    }
}
