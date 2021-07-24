using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL_Compzit;
using EL_Compzit;
using System.Data;
// CREATED BY:EVM-0001
// CREATED DATE:15/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Business Layer for Adding Country and also updating,canceling and viewing the same .

namespace BL_Compzit
{
    public class clsBusinessLayerCountry
    {
        clsDataLayerCountry objDataLayerCntryMstr = new clsDataLayerCountry();
        // This Method adds Country details to the database by passing details to Data Layer
        public void AddCountryMstr(clsEntityCountry objCntryMstr)
        {
            objDataLayerCntryMstr.AddCountryMstr(objCntryMstr);
        }

        // This Method Check Country Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupCountryName(clsEntityCountry objCntryMstr)
        {
            string strCntry = objDataLayerCntryMstr.CheckDupCountryName(objCntryMstr);
            return strCntry;
        }

        // This Method displays Country details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable ReadCountry(clsEntityCountry objCntry)
        {
            DataTable dtDisp = new DataTable();
            dtDisp = objDataLayerCntryMstr.ReadCountry(objCntry);
            return dtDisp;
        }
        // This Method Updates the Status of Country  by Passing the Country id, Status,updating userid and date.
        public void UpdateStat(clsEntityCountry objCntryMstr)
        {
            if (objCntryMstr.CountryStatus == 1)
            {
                objCntryMstr.CountryStatus = 0;
            }
            else
            {
                objCntryMstr.CountryStatus = 1;
            }

            objDataLayerCntryMstr.UpdateStatus(objCntryMstr);
        }
        // This Method select the details from the database when Edit and View Button is Clicked And Pass the data to UI Layer 
        public DataTable EditViewCountry(clsEntityCountry objCntryMstr)
        {
            DataTable dtEditViewCountry = new DataTable();
            dtEditViewCountry = objDataLayerCntryMstr.EditViewCountry(objCntryMstr);
            return dtEditViewCountry;
        }
        // This Method Updates  Country details  by  calling method in database.It act As a bridge Between UI Layer and Data Layer
        public void UpdateCountry(clsEntityCountry objCntryMstr)
        {
            objDataLayerCntryMstr.UpdateCountry(objCntryMstr);
        }
        // This Method Cancels  Country details  by  calling method in database.It act As a bridge Between UI Layer and Data Layer
        public void UpdateCancel(clsEntityCountry objCntryMstr)
        {
            objDataLayerCntryMstr.UpdateCancelClick(objCntryMstr);
        }
        // This Method Check Country Name in database  for duplicaton by passing details to Data Layer at time of updation
        public string CheckDupCountryNameUpdate(clsEntityCountry objCntryMstr)
        {
            string strCntry = objDataLayerCntryMstr.CheckDupCountryNameUpdate(objCntryMstr);
            return strCntry;
        }
    }
}
