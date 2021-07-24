using System;
using DL_Compzit;
using System.Data;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:12/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerLicensePack
    {
        //Create object for datalayer
        clsDataLayerLicensePack objDataLayerLicPac = new clsDataLayerLicensePack();
        public void AddLicensePack(clsEntityLicensePack objEntLicPac)
        {
            //passing the datas from UI layer to data layer for insertion in license pack master.
            objDataLayerLicPac.AddLicensePack(objEntLicPac);
        }
        // This Method Check License Pack Name in database  for duplicaton by passing details to Data Layer
        public string CheckDupLicensePackName(clsEntityLicensePack objLicPack)
        {
            string strCnt = objDataLayerLicPac.CheckDupLicensePackName(objLicPack);
            return strCnt;
        }
        // This Method Check LicensePack Maximum User in database for duplicaton by passing details to Data Layer
        public string CheckDupLicensePackMaxUserCount(clsEntityLicensePack objLicPack)
        {
            string strMaxCnt = objDataLayerLicPac.CheckDupLicensePackMaxUserCount(objLicPack);
            return strMaxCnt;
        }
        public DataTable ReadLicPac(clsEntityLicensePack objLicPack)
        {
            //Passing license pack table from data layer to UI layer.
            DataTable dtReadLicPac = objDataLayerLicPac.ReadLicPac(objLicPack);
            return dtReadLicPac;
        }
        public DataTable ReadLicPacEdit(clsEntityLicensePack objEntLicPac)
        {
            //Passing license pack table from datalayer to Ui layer according to their id passed from UI layer to data layer
            DataTable dtReadLicPacEdit = new DataTable();
            dtReadLicPacEdit = objDataLayerLicPac.ReadLicPacEdit(objEntLicPac);
            return dtReadLicPacEdit;
        }
        public void UpdateLicPac(clsEntityLicensePack objEntLicPac)
        {
            //Passing new data from UI layer to datalayer for updating license pack master.
            objDataLayerLicPac.UpdateLicPac(objEntLicPac);
        }
        public void UpdateLicPacActive(clsEntityLicensePack objEntLicPac)
        {
            //Passing licensepack active status detail for updating that field in table. 
            if (objEntLicPac.LicPacStatus == 1)
            {
                objEntLicPac.LicPacStatus = 0;
            }
            else
            {
                objEntLicPac.LicPacStatus = 1;
            }
            objDataLayerLicPac.UpdateLicPacActive(objEntLicPac);
        }
    }
}
