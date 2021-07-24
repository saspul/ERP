using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
// CREATED BY:EVM-0005
// CREATED DATE:12/10/2016
// REVIEWED BY:
// REVIEW DATE:


namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerLicenseType
    {
        // This Method adds License Type details to the table
        public void AddLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            ObjDataLtype.AddLicenseType(objEntityLicense);

        }

        // This Method update License type details to the table
        public void UpdateLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            ObjDataLtype.UpdateLicenseType(objEntityLicense);
        }

        // This Method checks License type name in the database for duplication.
        public string CheckLicenseTypeName(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            string count = ObjDataLtype.CheckLicenseTypeName(objEntityLicense);
            return count;
        }

        //Method for cancel LicenseType
        public void CancelLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            ObjDataLtype.CancelLicenseType(objEntityLicense);
        }

        // This Method will fetCH license type details  BY ID
        public DataTable ReadLicenseTypeById(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            DataTable dtAccodetails = ObjDataLtype.ReadLicenseTypeById(objEntityLicense);
            return dtAccodetails;
        }

        // This Method will fetch license type list
        public DataTable ReadLicenseTypeList(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            DataTable dtAccodetails = ObjDataLtype.ReadLicenseTypeList(objEntityLicense);
            return dtAccodetails;
        }


        // This Method will fetch image list
        public DataTable ReadImageDetails(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            DataTable dtAccodetails = ObjDataLtype.ReadImageDetails(objEntityLicense);
            return dtAccodetails;
        }
        //Method for recall license type

        public void ReCallLicenseType(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            ObjDataLtype.ReCallLicenseType(objEntityLicense);
        }
        public DataTable ReadLictyById(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            DataTable dtResultSet = ObjDataLtype.ReadLictyById(objEntityLicense);
            return dtResultSet;
        }
        public void UpdateStatus(clsEntityLayerLicenseType objEntityLicense)
        {
            clsDataLayerLicenseType ObjDataLtype = new clsDataLayerLicenseType();
            ObjDataLtype.UpdateStatus(objEntityLicense);
        }
    }
}
