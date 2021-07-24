using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:28/03/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerProductRateAmendment
    {
        //create objects for data layer
        clsDataLayerProductRateAmendment objDataLayerRateAmendment = new clsDataLayerProductRateAmendment();
        //check the user given product code exist in the table or not
        public string CheckProductCode(clsEntityProductRateAmendment objEntityRateAmendment)
        {
            string strCount = objDataLayerRateAmendment.CheckProductCode(objEntityRateAmendment);
            return strCount;
        }
        //update the product rate on the basis of product code
        public void RateUpdation(List<clsEntityProductRateAmendment> objEntityRateAmendmentList)
        {
            objDataLayerRateAmendment.ProductRateUpdation(objEntityRateAmendmentList);
        }
        //Method for FETCHING PRODUCT DETAILS BY THE EXTERNAL APP CODE OF PRODUCT.
        public DataTable ReadPrdctDtlByExtCode(clsEntityProductRateAmendment objEntityRateAmendment)
        {
            DataTable dtPrdctDtl = objDataLayerRateAmendment.ReadPrdctDtlByExtCode(objEntityRateAmendment);
            return dtPrdctDtl;
        }
        //methode for fetch all divisions based on user id
        public DataTable Read_Divisions(clsEntityProductRateAmendment objEntityRateUpdate)
        {
            DataTable dtDivisions = objDataLayerRateAmendment.Read_Divisions(objEntityRateUpdate);
            return dtDivisions;
        }
        //methode for fetch all divisions 
        public DataTable Read_All_Divisions(clsEntityProductRateAmendment objEntityRateUpdate)
        {
            DataTable dtDivisions = objDataLayerRateAmendment.Read_All_Divisions(objEntityRateUpdate);
            return dtDivisions;
        }
        //check product name already exist or not
        public string CheckProductName(clsEntityProductRateAmendment objEntityRate)
        {
            string strCount = objDataLayerRateAmendment.CheckProductname(objEntityRate);
            return strCount;
        }
    }
}
