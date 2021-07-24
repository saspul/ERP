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
// CREATED DATE:03/10/2016
// REVIEWED BY:
// REVIEW DATE:
namespace BL_Compzit.BusinessLayer_AWMS
{
    public class clsBusinessLayerInsuranceProvider
    {
        //Method of passing INSURANCE table data from datalayer to ui layer
        public DataTable ReadInsuranceType()
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            DataTable dtReadInsuranceType = objDataLayerInsurance.ReadInsuranceType();
            return dtReadInsuranceType;
        }
        //Method of passing insurance details from ui layer to datalayer for insertion
        public void AddInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance, List<clsEntityLayerInsuranceProvider> objEntityInsList)
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            objDataLayerInsurance.AddInsuranceProvider(objEntityInsurance,objEntityInsList);
        }
        //Method of passing insurance details from ui layer to datalayer for insertion
        public void UpdateInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance, List<clsEntityLayerInsuranceProvider> objEntityInsList)
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            objDataLayerInsurance.UpdateInsuranceProvider(objEntityInsurance, objEntityInsList);
        }
        // This Method checks Product name in the database for duplication.
        public string CheckInsuranceProviderName(clsEntityLayerInsuranceProvider objEntityInsurance)
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            string COUNT = objDataLayerInsurance.CheckInsuranceProviderName(objEntityInsurance);
            return COUNT;
        }
        
        // This Method will fetch insurance provider DEATILS BY ID
        public DataTable ReadInsuranceproviderById(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            DataTable dtReadInsuranceDetails = objDataLayerInsurance.ReadInsuranceproviderById(objEntityInsurance);
            return dtReadInsuranceDetails;
        }
        // This Method will fetch insurance TYPE DEATILS BY ID
        public DataTable ReadInsuranceTypeByPrvdrId(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            DataTable dtReadInsuranceDetails = objDataLayerInsurance.ReadInsuranceTypeByPrvdrId(objEntityInsurance);
            return dtReadInsuranceDetails;
        }

         //Method for cancel Insurance Provider
        public void CancelInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance)
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            objDataLayerInsurance.CancelInsuranceProvider(objEntityInsurance);
        }
         //Method for cancel Insurance Provider
        public void ReCallInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance)
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            objDataLayerInsurance.ReCallInsuranceProvider(objEntityInsurance);
        }
        
         // This Method will fetch product category list
        public DataTable ReadInsuranceProviderList(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            DataTable dtReadInsuranceDetails = objDataLayerInsurance.ReadInsuranceProviderList(objEntityInsurance);
            return dtReadInsuranceDetails;
        }
        // This Method will fetch product category list BY SEARCH
        public DataTable ReadInsuranceProviderListBySearch(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            DataTable dtReadInsuranceDetailsBySearch = objDataLayerInsurance.ReadInsuranceProviderListBySearch(objEntityInsurance);
            return dtReadInsuranceDetailsBySearch;
        }
        public void Update_Provider_Status(clsEntityLayerInsuranceProvider objEntityInsurance)
        {//Creating objects for datalayer
            clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
            objDataLayerInsurance.Update_Provider_Status(objEntityInsurance);
        }
    }
}
