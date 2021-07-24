using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using DL_Compzit.DataLayer_HCM;
using EL_Compzit;

namespace BL_Compzit
{
 public class clsBusinessLayerStaffFamilyDtls
    {
     clsDataStaffFamily objDataLayerdependent = new clsDataStaffFamily();
     public DataTable ReadRelationship(clsEntityLayerFamilyDetails objEntityDependent)
        {
            DataTable dtReadCountry = objDataLayerdependent.ReadRelationship(objEntityDependent);
            return dtReadCountry;
        }

        public void insertDependentDtls(clsEntityLayerFamilyDetails objEntityDependent)
        {
            objDataLayerdependent.insertDependentDtls(objEntityDependent);
        }
        public void UpdateDependentDtls(clsEntityLayerFamilyDetails objEntityDependent)
        {
            objDataLayerdependent.UpdateDependentDtls(objEntityDependent);
        }
        public DataTable readDependentList(clsEntityLayerFamilyDetails objEntityDependent)
        {
            DataTable dtReadCountry = objDataLayerdependent.readDependentList(objEntityDependent);
            return dtReadCountry;
        }
        public DataTable readFamilyList(clsEntityLayerFamilyDetails objEntityDependent)
        {
            DataTable dtReadCountry = objDataLayerdependent.readFamilyList(objEntityDependent);
            return dtReadCountry;
        }
        public DataTable ReadDepntById(clsEntityLayerFamilyDetails objEntityDependent)
        {
            DataTable dtReadCountry = objDataLayerdependent.ReadDepntById(objEntityDependent);
            return dtReadCountry;
        }

        public void DeleteDepntById(clsEntityLayerFamilyDetails objEntityDependent)
        {
            objDataLayerdependent.DeleteDepntById(objEntityDependent);
        }
        public void insertFamilyDtls(clsEntityLayerFamilyDetails objEntityDependent)
        {
            objDataLayerdependent.insertFamilyDtls(objEntityDependent);
        }
        public void UpdateFamilyDtls(clsEntityLayerFamilyDetails objEntityDependent)
        {
            objDataLayerdependent.UpdateFamilyDtls(objEntityDependent);
        }

       

    }
}
