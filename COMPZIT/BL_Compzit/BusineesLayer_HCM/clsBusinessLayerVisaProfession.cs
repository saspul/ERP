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
    public class clsBusinessLayerVisaProfession
    {
        clsDataLayerVisaProfession objDataLayerVisaType = new clsDataLayerVisaProfession();
        //Method for obtaining data from visa type table.
        public DataTable ReadDetails(clsEntityLayerVisaProfession objEntityVisa)
        {
            DataTable dtOrgDetal = objDataLayerVisaType.ReadDetails(objEntityVisa);
            return dtOrgDetal;
        }
        // This Method for adding data to the visa type table
        public void addDetails(clsEntityLayerVisaProfession objEntityVisa)
        {
            objDataLayerVisaType.addDetails(objEntityVisa);
        }
        //for checking duplication of visa name
        public string ReadVisaName(clsEntityLayerVisaProfession objEntityVisa)
        {
            string count = objDataLayerVisaType.ReadVisaName(objEntityVisa);
            return count;
        }
        //update visa status 
        public void ChangeStatus(clsEntityLayerVisaProfession objEntityVisa)
        {
            objDataLayerVisaType.ChangeStatus(objEntityVisa);
        }

        //update Data Fetch 
        public DataTable getDetails_ById(string id)
        {
            DataTable dt = new DataTable();
            dt=objDataLayerVisaType.getDetailsById(Convert.ToInt32(id));
            return dt;
        }
        //update visa status 
        public void updateVisa(clsEntityLayerVisaProfession objEntityVisa)
        {
            objDataLayerVisaType.Update_Visa(objEntityVisa);
        }
        //Cancel visa type 
        public void CancelVisa(clsEntityLayerVisaProfession objEntityVisa)
        {
            objDataLayerVisaType.Cancel_Visa(objEntityVisa);
        }

    }
}
