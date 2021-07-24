using System;
using DL_Compzit;
using System.Data;
using EL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:12/05/2015
// REVIEWED BY:
// REVIEW DATE:
// This is the Business Layer for Adding Corporate Pack and also updating and viewing the same .

namespace BL_Compzit
{

    public class clsBusinessLayerCorporatePack
    {
        clsDataLayerCorporatePack objDataLayerCrpPac = new clsDataLayerCorporatePack();
        // This Method adds Corporate Pack details to the database by passing details to Data Layer
        public void AddCorporatePack(clsEntityCorporatePack objCrpPack)
        {
            objDataLayerCrpPac.AddCorporatePack(objCrpPack);
        }
        // This Method Check Corporate Pack Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupCorporatePackName(clsEntityCorporatePack objCrpPack)
        {
            string strCnt = objDataLayerCrpPac.CheckDupCorporatePackName(objCrpPack);
            return strCnt;
        }
        // This Method Check Corporate office count in database  for duplicaton by passing details to Data Layer
        public string CheckDupCorporatePackCount(clsEntityCorporatePack objCrpPack)
        {
            string strCnt = objDataLayerCrpPac.CheckDupCorporatePackCount(objCrpPack);
            return strCnt;
        }
        // This Method displays Corporate Pack details By calling function in DataLayer and Passing the Data to the UI Layer
        public DataTable GridDisplay(clsEntityCorporatePack objCrpPack)
        {

            clsDataLayerCorporatePack objDataLayerCrpPac = new clsDataLayerCorporatePack();
            DataTable dtDisp = objDataLayerCrpPac.GridDisplay(objCrpPack);
            return dtDisp;

        }
        // This Method Updates the Status of Corporate Pack  by Passing the Corporate Pack id and the Status
        public void UpdateStat(clsEntityCorporatePack objCrpPack)
        {
            if (objCrpPack.CrpStatus == 1)
            {
                objCrpPack.CrpStatus = 0;

            }
            else
            {
                objCrpPack.CrpStatus = 1;

            }

            objDataLayerCrpPac.UpdateStatus(objCrpPack);
        }
        // This Method select the details from the database when Edit Button is Clicked And Pass the data to UI Layer 
        public DataTable EditPack(clsEntityCorporatePack objCrpPack)
        {
            DataTable dtEditPack = new DataTable();

            dtEditPack = objDataLayerCrpPac.EditPack(objCrpPack);
            return dtEditPack;
        }
        // This Method Updates  Corporate Pack details  by  calling method in database.It act As a bridge Between UI Layer and Data Layer
        public void UpdateCorporatePack(clsEntityCorporatePack objCrpPack)
        {
            objDataLayerCrpPac.UpdateCorporatePack(objCrpPack);
        }

    }
}
