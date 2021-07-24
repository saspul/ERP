using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using DL_Compzit;
using System.Data;

// CREATED BY:EVM-0001
// CREATED DATE:19/03/2016
// REVIEWED BY:
// REVIEW DATE:

namespace BL_Compzit
{
    public class clsBusinessLayerProductMaster
    {
        //Creating objects for datalayer
        clsDataLayerProductMaster objDataLayerProduct = new clsDataLayerProductMaster();

        // This Method will fetch Product Group table For Drop Down
        public DataTable ReadProductGroup(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadProductGroup(objEntityProduct);
            return dtReadProduct;
        }
        // This Method will fetch Product Brand table For Drop Down
        public DataTable ReadProductBrand(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadProductBrand(objEntityProduct);
            return dtReadProduct;
        }
        // This Method will fetch Division table For Drop Down
        public DataTable ReadDivision(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadDivision(objEntityProduct);
            return dtReadProduct;
        }
        // This Method will fetch MainCategory For Drop Down
        public DataTable ReadMainCategory(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadMainCategory(objEntityProduct);
            return dtReadProduct;
        }
        // This Method will fetch Categorys by type id and main category For Drop Down
        public DataTable ReadCategorys(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadCategorys(objEntityProduct);
            return dtReadProduct;
        }
        // This Method will fetch MainCategory For Drop Down
        public DataTable ReadCountry()
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadCountry();
            return dtReadProduct;
        }

        // This Method will fetch Tax For Drop Down
        public DataTable ReadTax(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadTax(objEntityProduct);
            return dtReadProduct;
        }
        // This Method will fetch  FETCHES TAX ID  BY CATEGORY GROUP ID TO DISPLAY IN DROPDOWNLIST BASED ON GROUP SELECTED
        public DataTable ReadTaxByGroupId(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadTaxByGroupId(objEntityProduct);
            return dtReadProduct;
        }
        //Method of passing the count of Product name that exist in the table
        public string CheckProductName(dynamic objEntityProduct)
        {
            string strUpdateCount = objDataLayerProduct.CheckProductName(objEntityProduct);
            return strUpdateCount;
        }
        //Method of passing the count of Product barcode that exist in the table

        //Method of passing the count of Product short name that exist in the table
        public string CheckProductShortName(dynamic objEntityProduct)
        {
            string strUpdateCount = objDataLayerProduct.CheckProductShortName(objEntityProduct);
            return strUpdateCount;
        }
        //Method of passing the count of Product code that exist in the table
        public string CheckProductCode(dynamic objEntityProduct)
        {
            string strUpdateCount = objDataLayerProduct.CheckProductCode(objEntityProduct);
            return strUpdateCount;
        }
        //Method of passing the count of EXTERNAL APP  code that exist in the table
        public string CheckProductExternalCode(dynamic objEntityProduct)
        {
            string strUpdateCount = objDataLayerProduct.CheckProductExternalCode(objEntityProduct);
            return strUpdateCount;
        }
        //Add Product Details
        public void AddProductDetils(clsEntityProduct_Master objEntityProduct)
        {
             objDataLayerProduct.AddProductDetils(objEntityProduct);
          
        }
        // This Method will fetch Product table without searching criteria
        public DataTable ReadProductList(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadProductList(objEntityProduct);
            return dtReadProduct;
        }

        // This Method will fetch Product table with searching criteria
        public DataTable ReadProductListBySearch(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProductSrch = objDataLayerProduct.ReadProductListBySearch(objEntityProduct);
            return dtReadProductSrch;
        }

        //passing data about Product cancel to data layer from ui layer.
        public void CancelProductMaster(clsEntityProduct_Master objEntityProduct)
        {
            objDataLayerProduct.CancelProductMaster(objEntityProduct);
        }
        //Method of passing Product master table data from datalayer to ui layer
        public DataTable ReadProductById(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadProductById(objEntityProduct);
            return dtReadProduct;
        }
        //Add Product Details
        public void UpdateProductDetils(clsEntityProduct_Master objEntityProduct)
        {
            objDataLayerProduct.UpdateProductDetils(objEntityProduct);

        }      
        //read tax details based on Product group
        public DataTable Read_Tax_By_Group(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtTax = objDataLayerProduct.ReadTaxByGroup(objEntityProduct);
            return dtTax;
        }
        //insert more than one product details to the product master
        public string AddBulkProductDetails(List<clsEntityProduct_Master> objEntityProductList)
        {
            string strOutput = objDataLayerProduct.AddBulkProductDetils(objEntityProductList);
            return strOutput;
        }
        public DataTable ReadUnitOfMeasure(clsEntityProduct_Master objEntityProduct)
        {
            DataTable dtReadProduct = objDataLayerProduct.ReadUnitOfMeasure(objEntityProduct);
            return dtReadProduct;
        }
        public void UpdateProductSts(clsEntityProduct_Master objEntityProduct)
        {
            objDataLayerProduct.UpdateProductSts(objEntityProduct);

        } 
    }
}
