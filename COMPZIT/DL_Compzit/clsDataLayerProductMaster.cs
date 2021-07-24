using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
using CL_Compzit;
using System.Configuration;

// CREATED BY:EVM-0001
// CREATED DATE:19/03/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Product detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{

    public class clsDataLayerProductMaster
    {
        clsDataLayer objDatatLayer = new clsDataLayer();
        clsDataLayerDateAndTime objDataLayerDateAndTime = new clsDataLayerDateAndTime();

        // This Method will fetch Product Group table For Drop Down
        public DataTable ReadProductGroup(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadGrp = "PRODUCT_MASTER.SP_READ_PRODUCT_GROUP";
            OracleCommand cmdReadGrp = new OracleCommand();
            cmdReadGrp.CommandText = strQueryReadGrp;
            cmdReadGrp.CommandType = CommandType.StoredProcedure;
            cmdReadGrp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadGrp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadGrp.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadGrp);
            return dtProduct;
        }
        // This Method will fetch Product Brand table For Drop Down
        public DataTable ReadProductBrand(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadBrand = "PRODUCT_MASTER.SP_READ_PRODUCT_BRAND";
            OracleCommand cmdReadBrand = new OracleCommand();
            cmdReadBrand.CommandText = strQueryReadBrand;
            cmdReadBrand.CommandType = CommandType.StoredProcedure;
            cmdReadBrand.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadBrand.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadBrand.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadBrand);
            return dtProduct;
        }
        // This Method will fetch Division table For Drop Down
        public DataTable ReadDivision(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadDivision = "PRODUCT_MASTER.SP_READ_CORP_DIVISIONS";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strQueryReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadDivision.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
            cmdReadDivision.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtProduct;
        }
        // This Method will fetch MainCategory For Drop Down
        public DataTable ReadMainCategory(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadMainCategory = "PRODUCT_MASTER.SP_READ_MAIN_CATEGORYS";
            OracleCommand cmdReadMainCategory = new OracleCommand();
            cmdReadMainCategory.CommandText = strQueryReadMainCategory;
            cmdReadMainCategory.CommandType = CommandType.StoredProcedure;
            cmdReadMainCategory.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadMainCategory.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadMainCategory.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadMainCategory);
            return dtProduct;
        }
        // This Method will fetch Categorys by type id and main category For Drop Down
        public DataTable ReadCategorys(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadCategorys = "PRODUCT_MASTER.SP_READ_CTGRYS_BY_TYPID_PARENT";
            OracleCommand cmdReadCategorys = new OracleCommand();
            cmdReadCategorys.CommandText = strQueryReadCategorys;
            cmdReadCategorys.CommandType = CommandType.StoredProcedure;
            cmdReadCategorys.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadCategorys.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadCategorys.Parameters.Add("P_CTGRYTYPID", OracleDbType.Int32).Value = objEntityProduct.CategoryType_Id;
            cmdReadCategorys.Parameters.Add("P_MAINCTGRYID", OracleDbType.Int32).Value = objEntityProduct.MainCategoryId;
            cmdReadCategorys.Parameters.Add("P_SEARCH", OracleDbType.Varchar2).Value = objEntityProduct.Cancel_Reason;
            cmdReadCategorys.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadCategorys);
            return dtProduct;
        }

        // This Method will fetch MainCategory For Drop Down
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "PRODUCT_MASTER.SP_READ_COUNTRY";
            OracleCommand cmdReadCountry = new OracleCommand();
            cmdReadCountry.CommandText = strQueryReadCountry;
            cmdReadCountry.CommandType = CommandType.StoredProcedure;
            cmdReadCountry.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadCountry);
            return dtProduct;
        }

        // This Method will fetch Tax For Drop Down
        public DataTable ReadTax(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadTax = "PRODUCT_MASTER.SP_READ_TAX";
            OracleCommand cmdReadTax = new OracleCommand();
            cmdReadTax.CommandText = strQueryReadTax;
            cmdReadTax.CommandType = CommandType.StoredProcedure;
            cmdReadTax.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadTax.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadTax.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadTax);
            return dtProduct;
        }
        // This Method will fetch FETCHES TAX ID  BY CATEGORY GROUP ID TO DISPLAY IN DROPDOWNLIST BASED ON GROUP SELECTED
        public DataTable ReadTaxByGroupId(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadTax = "PRODUCT_MASTER.SP_READ_TAXID_BY_GRPID";
            OracleCommand cmdReadTaxByGrpId = new OracleCommand();
            cmdReadTaxByGrpId.CommandText = strQueryReadTax;
            cmdReadTaxByGrpId.CommandType = CommandType.StoredProcedure;
            cmdReadTaxByGrpId.Parameters.Add("P_GRPID", OracleDbType.Int32).Value = objEntityProduct.Product_GrpId;
            cmdReadTaxByGrpId.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadTaxByGrpId);
            return dtProduct;
        }

        // This Method adds Product detailsto the Product master table
        public void AddProductDetils(clsEntityProduct_Master objEntityProduct)
        {



            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryAddProduct = "PRODUCT_MASTER.SP_INSERT_PRODUCT";
                        using (OracleCommand cmdAddProduct = new OracleCommand(strQueryAddProduct, con))
                        {

                            cmdAddProduct.Transaction = tran;

                            cmdAddProduct.CommandType = CommandType.StoredProcedure;
                            clsEntityCommon objEntityCommon = new clsEntityCommon();
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PRODUCT_MASTER);
                            objEntityCommon.CorporateID = objEntityProduct.Corp_Id;
                            string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntityCommon, tran, con);
                            objEntityProduct.Product_Id = Convert.ToInt32(strNextNum);
                            cmdAddProduct.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
                            cmdAddProduct.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_name;
                            if (objEntityProduct.Product_ShortName != "")
                            {
                                cmdAddProduct.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_ShortName;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = null;
                            }
                            
                            
                            if (objEntityProduct.Product_Code == "")
                            {
                               
                      
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PRODUCT_CODE);
                                string strProductCode = objDatatLayer.ReadNextNumberWeb(objEntityCommon, tran, con);
                                cmdAddProduct.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = strProductCode;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityProduct.Product_Code;
                            }

                            if (objEntityProduct.ExternalAppCode != "")
                            {
                                cmdAddProduct.Parameters.Add("P_EXTAPPCODE", OracleDbType.Varchar2).Value = objEntityProduct.ExternalAppCode;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_EXTAPPCODE", OracleDbType.Varchar2).Value = null;
                            }


                            cmdAddProduct.Parameters.Add("P_GROUPID", OracleDbType.Int32).Value = objEntityProduct.Product_GrpId;
                            cmdAddProduct.Parameters.Add("P_MAINCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_MainCtgryId;
                            if (objEntityProduct.Product_SubCtgryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_SUBCTGRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_SUBCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_SubCtgryId;
                            }
                            if (objEntityProduct.Product_SmallCtgryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_SMALLCTGRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_SMALLCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_SmallCtgryId;
                            }
                            if (objEntityProduct.Product_LeastCtgryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_LEASTCTGRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_LEASTCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_LeastCtgryId;
                            }
                          
                            if (objEntityProduct.Product_TaxId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_TAXID", OracleDbType.Int32).Value = null;
                                cmdAddProduct.Parameters.Add("P_TAXMODE", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_TAXID", OracleDbType.Int32).Value = objEntityProduct.Product_TaxId;
                                cmdAddProduct.Parameters.Add("P_TAXMODE", OracleDbType.Int32).Value = objEntityProduct.Product_TaxMode;
                            }
                            cmdAddProduct.Parameters.Add("P_COSTPRICE", OracleDbType.Decimal).Value = objEntityProduct.ProductCostPrice;
                            cmdAddProduct.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
                            cmdAddProduct.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
                            cmdAddProduct.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProduct.Status;
                            cmdAddProduct.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
                            cmdAddProduct.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityProduct.D_Date;
                            cmdAddProduct.Parameters.Add("P_DIVSNID", OracleDbType.Int32).Value = objEntityProduct.DivsionId;
                            if (objEntityProduct.ProductBrand == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_BRANDID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_BRANDID", OracleDbType.Int32).Value = objEntityProduct.ProductBrand;
                            }
                            if (objEntityProduct.CountryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_COUNTRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_COUNTRYID", OracleDbType.Int32).Value = objEntityProduct.CountryId;
                            }
                            cmdAddProduct.Parameters.Add("P_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityProduct.Product_description;
                            cmdAddProduct.Parameters.Add("P_UNIT", OracleDbType.Int32).Value = objEntityProduct.Unit;
                            cmdAddProduct.Parameters.Add("P_SALEABLE", OracleDbType.Int32).Value = objEntityProduct.SaleableSts;
                            cmdAddProduct.Parameters.Add("P_STOCKABLE", OracleDbType.Int32).Value = objEntityProduct.StockableSts;
                            cmdAddProduct.Parameters.Add("P_NAMETODESC_STS", OracleDbType.Int32).Value = objEntityProduct.NametoDescrptnSts;
                            cmdAddProduct.Parameters.Add("P_NAMETO_INVRMRK_STS", OracleDbType.Int32).Value = objEntityProduct.NametoRemarkSts;
                            cmdAddProduct.ExecuteNonQuery();

                        }
                       
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }
          
        }

        //this methode for add more products at a time
        public string AddBulkProductDetils(List<clsEntityProduct_Master> objEntityProductList)
        {

            string strOutput = "";

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    foreach (clsEntityProduct_Master objEntityProduct in objEntityProductList)
                    {
                        string strQueryAddProduct = "PRODUCT_MASTER.SP_INSERT_PRODUCT";
                        using (OracleCommand cmdAddProduct = new OracleCommand(strQueryAddProduct, con))
                        {

                            cmdAddProduct.Transaction = tran;

                            cmdAddProduct.CommandType = CommandType.StoredProcedure;
                            clsEntityCommon objEntityCommon = new clsEntityCommon();
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PRODUCT_MASTER);
                            objEntityCommon.CorporateID = objEntityProduct.Corp_Id;
                            string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntityCommon, tran, con);
                            objEntityProduct.Product_Id = Convert.ToInt32(strNextNum);
                            cmdAddProduct.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
                            cmdAddProduct.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_name;
                            if (objEntityProduct.Product_ShortName != "")
                            {
                                cmdAddProduct.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_ShortName;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = null;
                            }


                            if (objEntityProduct.Product_Code == "")
                            {
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PRODUCT_CODE);
                                string strProductCode = objDatatLayer.ReadNextNumberWeb(objEntityCommon, tran, con);
                                cmdAddProduct.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = strProductCode;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityProduct.Product_Code;
                            }

                            if (objEntityProduct.ExternalAppCode != "")
                            {
                                cmdAddProduct.Parameters.Add("P_EXTAPPCODE", OracleDbType.Varchar2).Value = objEntityProduct.ExternalAppCode;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_EXTAPPCODE", OracleDbType.Varchar2).Value = null;
                            }


                            cmdAddProduct.Parameters.Add("P_GROUPID", OracleDbType.Int32).Value = objEntityProduct.Product_GrpId;
                            cmdAddProduct.Parameters.Add("P_MAINCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_MainCtgryId;
                            if (objEntityProduct.Product_SubCtgryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_SUBCTGRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_SUBCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_SubCtgryId;
                            }
                            if (objEntityProduct.Product_SmallCtgryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_SMALLCTGRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_SMALLCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_SmallCtgryId;
                            }
                            if (objEntityProduct.Product_LeastCtgryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_LEASTCTGRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_LEASTCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_LeastCtgryId;
                            }

                            if (objEntityProduct.Product_TaxId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_TAXID", OracleDbType.Int32).Value = null;
                                cmdAddProduct.Parameters.Add("P_TAXMODE", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_TAXID", OracleDbType.Int32).Value = objEntityProduct.Product_TaxId;
                                cmdAddProduct.Parameters.Add("P_TAXMODE", OracleDbType.Int32).Value = objEntityProduct.Product_TaxMode;
                            }
                            cmdAddProduct.Parameters.Add("P_COSTPRICE", OracleDbType.Decimal).Value = objEntityProduct.ProductCostPrice;
                            cmdAddProduct.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
                            cmdAddProduct.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
                            cmdAddProduct.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProduct.Status;
                            cmdAddProduct.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
                            cmdAddProduct.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDateAndTime.DateAndTime();
                            cmdAddProduct.Parameters.Add("P_DIVSNID", OracleDbType.Int32).Value = objEntityProduct.DivsionId;
                            if (objEntityProduct.ProductBrand == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_BRANDID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_BRANDID", OracleDbType.Int32).Value = objEntityProduct.ProductBrand;
                            }
                            if (objEntityProduct.CountryId == 0)
                            {
                                cmdAddProduct.Parameters.Add("P_COUNTRYID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddProduct.Parameters.Add("P_COUNTRYID", OracleDbType.Int32).Value = objEntityProduct.CountryId;
                            }
                            cmdAddProduct.Parameters.Add("P_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityProduct.Product_description;

                            cmdAddProduct.ExecuteNonQuery();

                        }
                    }
                    tran.Commit();
                    strOutput = "Success";
                }
                catch (Exception e)
                {
                    strOutput = "Fail";
                }
            }
            return strOutput;
        }

        // This Method checks Product name in the database for duplication.
        public string CheckProductName(clsEntityProduct_Master objEntityProduct)
        {

            string strQueryCheckProductName = "PRODUCT_MASTER.SP_CHECK_PRODUCT_NAME";
            OracleCommand cmdCheckProductName = new OracleCommand();
            cmdCheckProductName.CommandText = strQueryCheckProductName;
            cmdCheckProductName.CommandType = CommandType.StoredProcedure;
            cmdCheckProductName.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
            cmdCheckProductName.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_name;
            cmdCheckProductName.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdCheckProductName.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdCheckProductName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProductName);
            string strReturn = cmdCheckProductName.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProductName.Dispose();
            return strReturn;
        }


        // This Method checks Product short name in the database for duplication.
        public string CheckProductShortName(clsEntityProduct_Master objEntityProduct)
        {

            string strQueryCheckProductName = "PRODUCT_MASTER.SP_CHECK_PRODUCT_SHORT_NAME";
            OracleCommand cmdCheckProductName = new OracleCommand();
            cmdCheckProductName.CommandText = strQueryCheckProductName;
            cmdCheckProductName.CommandType = CommandType.StoredProcedure;
            cmdCheckProductName.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
            cmdCheckProductName.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_ShortName;
            cmdCheckProductName.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdCheckProductName.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdCheckProductName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProductName);
            string strReturn = cmdCheckProductName.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProductName.Dispose();
            return strReturn;
        }

        // This Method checks Product code in the database for duplication.
        public string CheckProductCode(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryCheckProductCode = "PRODUCT_MASTER.SP_CHECK_PRODUCT_CODE";
            OracleCommand cmdCheckProductCode = new OracleCommand();
            cmdCheckProductCode.CommandText = strQueryCheckProductCode;
            cmdCheckProductCode.CommandType = CommandType.StoredProcedure;
            cmdCheckProductCode.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
            cmdCheckProductCode.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityProduct.Product_Code;
            cmdCheckProductCode.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdCheckProductCode.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdCheckProductCode.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProductCode);
            string strReturn = cmdCheckProductCode.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProductCode.Dispose();
            return strReturn;
        }
        // This Method checks Product External app code in the database for duplication.
        public string CheckProductExternalCode(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryCheckProductCode = "PRODUCT_MASTER.SP_CHECK_EXTERNAL_APP_CODE";
            OracleCommand cmdCheckProductCode = new OracleCommand();
            cmdCheckProductCode.CommandText = strQueryCheckProductCode;
            cmdCheckProductCode.CommandType = CommandType.StoredProcedure;
            cmdCheckProductCode.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
            cmdCheckProductCode.Parameters.Add("P_EXT_APP_CODE", OracleDbType.Varchar2).Value = objEntityProduct.ExternalAppCode;
            cmdCheckProductCode.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdCheckProductCode.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdCheckProductCode.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProductCode);
            string strReturn = cmdCheckProductCode.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProductCode.Dispose();
            return strReturn;
        }


        // This Method will fetch Product table without searching criteria
        public DataTable ReadProductList(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadProduct = "PRODUCT_MASTER.SP_READ_PRODUCTLIST";
            OracleCommand cmdReadProduct = new OracleCommand();
            cmdReadProduct.CommandText = strQueryReadProduct;
            cmdReadProduct.CommandType = CommandType.StoredProcedure;
            cmdReadProduct.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadProduct.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadProduct.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
            cmdReadProduct.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProducts = new DataTable();
            dtProducts = clsDataLayer.ExecuteReader(cmdReadProduct);
            return dtProducts;
        }

        // This Method will fetch Product table without searching criteria
        public DataTable ReadProductListBySearch(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadProduct = "PRODUCT_MASTER.SP_READ_PRODUCTLIST_BY_SRCH";
            OracleCommand cmdReadProduct = new OracleCommand();
            cmdReadProduct.CommandText = strQueryReadProduct;
            cmdReadProduct.CommandType = CommandType.StoredProcedure;
            cmdReadProduct.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadProduct.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadProduct.Parameters.Add("P_DIVSN_ID", OracleDbType.Int32).Value = objEntityProduct.DivsionId;
            if (objEntityProduct.Product_name == "")
            {
                cmdReadProduct.Parameters.Add("P_PRDCTNAME", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadProduct.Parameters.Add("P_PRDCTNAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_name;
            }
            cmdReadProduct.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
            cmdReadProduct.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityProduct.Status;
            cmdReadProduct.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityProduct.Cancel_Status;
            cmdReadProduct.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityProduct.CommonSearchTerm;
            cmdReadProduct.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityProduct.SearchName;
            cmdReadProduct.Parameters.Add("M_SEARCH_CODE", OracleDbType.Varchar2).Value = objEntityProduct.SearchCode;
            cmdReadProduct.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityProduct.OrderColumn;
            cmdReadProduct.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityProduct.OrderMethod;
            cmdReadProduct.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityProduct.PageMaxSize;
            cmdReadProduct.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityProduct.PageNumber;
            cmdReadProduct.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProducts = new DataTable();
            dtProducts = clsDataLayer.ExecuteReader(cmdReadProduct);
            return dtProducts;
        }
        //Method for cancel Products
        public void CancelProductMaster(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryCancelProduct = "PRODUCT_MASTER.SP_CANCEL_PRODUCT";
            using (OracleCommand cmdCancelProduct = new OracleCommand())
            {
                cmdCancelProduct.CommandText = strQueryCancelProduct;
                cmdCancelProduct.CommandType = CommandType.StoredProcedure;
                cmdCancelProduct.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
                cmdCancelProduct.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
                cmdCancelProduct.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityProduct.D_Date;
                cmdCancelProduct.Parameters.Add("P_REASON", OracleDbType.Varchar2).Value = objEntityProduct.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelProduct);
            }
        }

        // This Method will fetch Product table by ID
        public DataTable ReadProductById(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadProductById = "PRODUCT_MASTER.SP_READ_PRODUCT_BYID";
            OracleCommand cmdReadProductById = new OracleCommand();
            cmdReadProductById.CommandText = strQueryReadProductById;
            cmdReadProductById.CommandType = CommandType.StoredProcedure;
            cmdReadProductById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
            cmdReadProductById.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadProductById.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProducts = new DataTable();
            dtProducts = clsDataLayer.ExecuteReader(cmdReadProductById);
            return dtProducts;
        }

        public void UpdateProductSts(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryCancelProduct = "PRODUCT_MASTER.SP_PRODUCT_STS";
            using (OracleCommand cmdCancelProduct = new OracleCommand())
            {
                cmdCancelProduct.CommandText = strQueryCancelProduct;
                cmdCancelProduct.CommandType = CommandType.StoredProcedure;
                cmdCancelProduct.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
                cmdCancelProduct.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
                cmdCancelProduct.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityProduct.D_Date;
                cmdCancelProduct.Parameters.Add("P_STATUS", OracleDbType.Varchar2).Value = objEntityProduct.Status;
                clsDataLayer.ExecuteNonQuery(cmdCancelProduct);
            }
        }
      
        //Method for Updating Product Details
        public void UpdateProductDetils(clsEntityProduct_Master objEntityProduct)
        {
            clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    
                      if (objEntityProduct.Product_Id != 0)
                        {
                            string strQueryUpdateProduct = "PRODUCT_MASTER.SP_UPDATE_PRODUCT";
                            using (OracleCommand cmdUpdateProduct = new OracleCommand(strQueryUpdateProduct, con))
                            {
                                cmdUpdateProduct.Transaction = tran;
                                cmdUpdateProduct.CommandText = strQueryUpdateProduct;
                                cmdUpdateProduct.CommandType = CommandType.StoredProcedure;
                                cmdUpdateProduct.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityProduct.Product_Id;
                                cmdUpdateProduct.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_name;

                                if (objEntityProduct.Product_ShortName != "")
                                {
                                    cmdUpdateProduct.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = objEntityProduct.Product_ShortName;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_SHORTNAME", OracleDbType.Varchar2).Value = null;
                                }

                                cmdUpdateProduct.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityProduct.Product_Code;


                                if (objEntityProduct.ExternalAppCode != "")
                                {
                                    cmdUpdateProduct.Parameters.Add("P_EXTAPPCODE", OracleDbType.Varchar2).Value = objEntityProduct.ExternalAppCode;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_EXTAPPCODE", OracleDbType.Varchar2).Value = null;
                                }


                                cmdUpdateProduct.Parameters.Add("P_GROUPID", OracleDbType.Int32).Value = objEntityProduct.Product_GrpId;
                                cmdUpdateProduct.Parameters.Add("P_MAINCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_MainCtgryId;
                                if (objEntityProduct.Product_SubCtgryId == 0)
                                {
                                    cmdUpdateProduct.Parameters.Add("P_SUBCTGRYID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_SUBCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_SubCtgryId;
                                }
                                if (objEntityProduct.Product_SmallCtgryId == 0)
                                {
                                    cmdUpdateProduct.Parameters.Add("P_SMALLCTGRYID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_SMALLCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_SmallCtgryId;
                                }
                                if (objEntityProduct.Product_LeastCtgryId == 0)
                                {
                                    cmdUpdateProduct.Parameters.Add("P_LEASTCTGRYID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_LEASTCTGRYID", OracleDbType.Int32).Value = objEntityProduct.Product_LeastCtgryId;
                                }

                                if (objEntityProduct.Product_TaxId == 0)
                                {
                                    cmdUpdateProduct.Parameters.Add("P_TAXID", OracleDbType.Int32).Value = null;
                                    cmdUpdateProduct.Parameters.Add("P_TAXMODE", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_TAXID", OracleDbType.Int32).Value = objEntityProduct.Product_TaxId;
                                    cmdUpdateProduct.Parameters.Add("P_TAXMODE", OracleDbType.Int32).Value = objEntityProduct.Product_TaxMode;
                                }
                                cmdUpdateProduct.Parameters.Add("P_COSTPRICE", OracleDbType.Decimal).Value = objEntityProduct.ProductCostPrice;
                                cmdUpdateProduct.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
                                cmdUpdateProduct.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
                                cmdUpdateProduct.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityProduct.Status;


                                cmdUpdateProduct.Parameters.Add("P_UPDUSERID", OracleDbType.Int32).Value = objEntityProduct.User_Id;
                                cmdUpdateProduct.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                                cmdUpdateProduct.Parameters.Add("P_DIVSNID", OracleDbType.Int32).Value = objEntityProduct.DivsionId;
                                if (objEntityProduct.ProductBrand == 0)
                                {
                                    cmdUpdateProduct.Parameters.Add("P_BRANDID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_BRANDID", OracleDbType.Int32).Value = objEntityProduct.ProductBrand;

                                }
                                if (objEntityProduct.CountryId == 0)
                                {
                                    cmdUpdateProduct.Parameters.Add("P_COUNTRYID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateProduct.Parameters.Add("P_COUNTRYID", OracleDbType.Int32).Value = objEntityProduct.CountryId;
                                }
                                    cmdUpdateProduct.Parameters.Add("P_PRDCTSOURCE", OracleDbType.Int32).Value = 1;
                                cmdUpdateProduct.Parameters.Add("P_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityProduct.Product_description;
                                cmdUpdateProduct.Parameters.Add("P_UNIT", OracleDbType.Int32).Value = objEntityProduct.Unit;
                                cmdUpdateProduct.Parameters.Add("P_SALEABLE", OracleDbType.Int32).Value = objEntityProduct.SaleableSts;
                                cmdUpdateProduct.Parameters.Add("P_STOCKABLE", OracleDbType.Int32).Value = objEntityProduct.StockableSts;
                                cmdUpdateProduct.Parameters.Add("P_NAMETODESC_STS", OracleDbType.Int32).Value = objEntityProduct.NametoDescrptnSts;
                                cmdUpdateProduct.Parameters.Add("P_NAMETO_INVRMRK_STS", OracleDbType.Int32).Value = objEntityProduct.NametoRemarkSts;
                                cmdUpdateProduct.ExecuteNonQuery();
                            }
                        }
                       
                       
                       
                    
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;
                }
            }

       
        }

     
        // This Method for fetch image prefix from database
        public DataTable ReadTaxByGroup(clsEntityProduct_Master objEntityProduct)
        {

            string strQueryReadTaxByGroup = "Product_MASTER.SP_READ_TAX_BYGROUP";
            OracleCommand cmdReadTaxByGroup = new OracleCommand();
            cmdReadTaxByGroup.CommandText = strQueryReadTaxByGroup;
            cmdReadTaxByGroup.CommandType = CommandType.StoredProcedure;
            cmdReadTaxByGroup.Parameters.Add("I_GROUPID", OracleDbType.Int32).Value = objEntityProduct.Product_GrpId;
            cmdReadTaxByGroup.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadTaxByGroup.Parameters.Add("I_TAX", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTax = new DataTable();
            dtTax = clsDataLayer.ExecuteReader(cmdReadTaxByGroup);
            return dtTax;
        }
        public DataTable ReadUnitOfMeasure(clsEntityProduct_Master objEntityProduct)
        {
            string strQueryReadProduct = "PRODUCT_MASTER.SP_LOAD_UOM";
            OracleCommand cmdReadProduct = new OracleCommand();
            cmdReadProduct.CommandText = strQueryReadProduct;
            cmdReadProduct.CommandType = CommandType.StoredProcedure;
            cmdReadProduct.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityProduct.Org_Id;
            cmdReadProduct.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityProduct.Corp_Id;
            cmdReadProduct.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProducts = new DataTable();
            dtProducts = clsDataLayer.ExecuteReader(cmdReadProduct);
            return dtProducts;
        }
    }
}
