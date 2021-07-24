using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;
using CL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:22/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerOrgType
    {
        clsDataLayerOrgType objDataLayerOrgMstr = new clsDataLayerOrgType();
        // This Method adds Organisation details to the database by passing details to Data Layer
        public void AddOrgMstr(clsEntityOrgType objOrgMstr)
        {
            objDataLayerOrgMstr.AddOrgMstr(objOrgMstr);
        }
        // This Method displays Organisation details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable GridDisplay(clsEntityOrgType objOrg)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerOrgMstr.GridDisplay(objOrg);
            return dtDisp;
        }
        // This Method Updates the Status of Organisation  by Passing the Organisation id, Status,updating userid and date.
        public void UpdateStatusOrg(clsEntityOrgType objOrgMstr)
        {
            if (objOrgMstr.OrgStatus == 1)
            {
                objOrgMstr.OrgStatus = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);
            }
            else
            {
                objOrgMstr.OrgStatus = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            }

            objDataLayerOrgMstr.UpdateStatus(objOrgMstr);
        }
        // This Method select the details from the database when Edit and View Button is Clicked And Pass the data to UI Layer 
        public DataTable EditViewOrg(clsEntityOrgType objOrgMstr)
        {
            DataTable dtEditViewCountry = new DataTable();
            dtEditViewCountry = objDataLayerOrgMstr.EditViewOrg(objOrgMstr);
            return dtEditViewCountry;
        }
        // This Method Updates  Organisation details  by  calling method in database.It act As a bridge Between UI Layer and Data Layer
        public void UpdateOrg(clsEntityOrgType objOrgMstr)
        {
            objDataLayerOrgMstr.UpdateOrg(objOrgMstr);
        }
        // This Method Cancels  Organisation details  by  calling method in database.It act As a bridge Between UI Layer and Data Layer
        public void UpdateCancel(clsEntityOrgType objOrgMstr)
        {
            objDataLayerOrgMstr.UpdateCancelClick(objOrgMstr);
        }
        //Method for passing organisation type name and org type name count in table in between two tables.
        public DataTable CheckOrgTypeName(clsEntityOrgType objOrgMstr)
        {
            DataTable dtOrgName = objDataLayerOrgMstr.CheckOrgType(objOrgMstr);
            return dtOrgName;
        }
        //Method of passing organisation type name count in the table at the time of updation
        public string CheckOrgTypeUpdation(clsEntityOrgType objOrgMstr)
        {
            string strReturn = objDataLayerOrgMstr.CheckOrgTypeUpdation(objOrgMstr);
            return strReturn;
        }
    }
}