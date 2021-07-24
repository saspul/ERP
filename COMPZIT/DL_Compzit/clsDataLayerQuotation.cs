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
// CREATED DATE:01/04/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Quotation detail and also updating,canceling and viewing the same .
namespace DL_Compzit
{
    public class clsDataLayerQuotation
    {

        clsDataLayer objDatatLayer = new clsDataLayer();

        // This Method will fetch Product  For Drop Down
        public DataTable ReadProducts(int intListMode, clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadItems = "QUOTATION.SP_READ_PRODUCT_ITEMS";
            OracleCommand cmdReadItems = new OracleCommand();
            cmdReadItems.CommandText = strQueryReadItems;
            cmdReadItems.CommandType = CommandType.StoredProcedure;
            cmdReadItems.Parameters.Add("Q_LISTMODE", OracleDbType.Int32).Value = intListMode;
            cmdReadItems.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadItems.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            if (objEntityQuotation.Divisionids != "")
            {
                cmdReadItems.Parameters.Add("Q_DIVSN_IDS", OracleDbType.Varchar2).Value = objEntityQuotation.Divisionids;
            }
            else
            {

                cmdReadItems.Parameters.Add("Q_DIVSN_IDS", OracleDbType.Varchar2).Value = "0";
            }

            cmdReadItems.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadItems);
            return dtProduct;
        }
        // This Method will fetch Product  For autocompletion from WebService
        public DataTable ReadProductsWebService(string strProductLikeName, int intListMode, clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadItems = "QUOTATION.SP_READ_PRDCT_ITEMS_WEBSERVICE";
            OracleCommand cmdReadItems = new OracleCommand();
            cmdReadItems.CommandText = strQueryReadItems;
            cmdReadItems.CommandType = CommandType.StoredProcedure;
            cmdReadItems.Parameters.Add("Q_PRDCTLIKENAME", OracleDbType.Varchar2).Value = strProductLikeName;
            cmdReadItems.Parameters.Add("Q_LISTMODE", OracleDbType.Int32).Value = intListMode;
            cmdReadItems.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadItems.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;

            if (objEntityQuotation.Divisionids != "")
            {
                cmdReadItems.Parameters.Add("Q_DIVSN_IDS", OracleDbType.Varchar2).Value = objEntityQuotation.Divisionids;
            }
            else
            {

                cmdReadItems.Parameters.Add("Q_DIVSN_IDS", OracleDbType.Varchar2).Value = "0";
            }

            cmdReadItems.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadItems);
            return dtProduct;
        }
        // This Method will fetch Tax For Drop Down
        public DataTable ReadTax(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadTax = "QUOTATION.SP_READ_TAX";
            OracleCommand cmdReadTax = new OracleCommand();
            cmdReadTax.CommandText = strQueryReadTax;
            cmdReadTax.CommandType = CommandType.StoredProcedure;
            cmdReadTax.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadTax.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadTax.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTax = new DataTable();
            dtTax = clsDataLayer.ExecuteReader(cmdReadTax);
            return dtTax;
        }
        // This Method will fetch Units For Drop Down
        public DataTable ReadUnit(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadUnit = "QUOTATION.SP_READ_UNIT";
            OracleCommand cmdReadUnit = new OracleCommand();
            cmdReadUnit.CommandText = strQueryReadUnit;
            cmdReadUnit.CommandType = CommandType.StoredProcedure;
            cmdReadUnit.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadUnit.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadUnit.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtUnit = new DataTable();
            dtUnit = clsDataLayer.ExecuteReader(cmdReadUnit);
            return dtUnit;
        }
        // This Method FETCHES PRODUCT DETAILS BASED ON PRODUCT SELECTED IN ENTRY VIA WEB SERVICE
        public DataTable ReadSelctdPrdctDtl(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadPrdctDtl = "QUOTATION.SP_READ_SELECTED_PRODUCT_DTLS";
            OracleCommand cmdReadItemDtl = new OracleCommand();
            cmdReadItemDtl.CommandText = strQueryReadPrdctDtl;
            cmdReadItemDtl.CommandType = CommandType.StoredProcedure;
            cmdReadItemDtl.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadItemDtl.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadItemDtl.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objEntityQuotation.Product_Id;
            cmdReadItemDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtItmDtl = new DataTable();
            dtItmDtl = clsDataLayer.ExecuteReader(cmdReadItemDtl);
            return dtItmDtl;
        }
        // This Method FETCHES TAX DETAILS BASED ON TAX SELECTED IN ENTRY VIA WEB SERVICE
        public DataTable ReadSelctdTaxDtl(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadTaxDtl = "QUOTATION.SP_READ_SELECTED_TAX_TXPERC";
            OracleCommand cmdReadTaxDtl = new OracleCommand();
            cmdReadTaxDtl.CommandText = strQueryReadTaxDtl;
            cmdReadTaxDtl.CommandType = CommandType.StoredProcedure;
            cmdReadTaxDtl.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadTaxDtl.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadTaxDtl.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objEntityQuotation.TaxId;
            cmdReadTaxDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTaxDtl = new DataTable();
            dtTaxDtl = clsDataLayer.ExecuteReader(cmdReadTaxDtl);
            return dtTaxDtl;
        }
        // This Method FETCHES LEAD DETAILS BASED ON LEAD ID FOR DISPALYING LEAD DETAILS
        public DataTable ReadLeadDtlForDisplay(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadLeadDtl = "QUOTATION.SP_READ_LEAD_DTL_BY_LEADID";
            OracleCommand cmdReadLeadDtl = new OracleCommand();
            cmdReadLeadDtl.CommandText = strQueryReadLeadDtl;
            cmdReadLeadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadLeadDtl.Parameters.Add("Q_LEAD_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
            cmdReadLeadDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadLeadDtl);
            return dtDtl;
        }


        // This Method is for fetching CORPORATE MAIL MESSAGE BASED ON CORP TEMPLATE TYP ID AND CORP ID 
        public DataTable ReadCorpMailContent(clsEntityCommon objEntityCommon)
        {
            string strQueryMailMsg = "COMMON.SP_READ_CORPRT_MAIL_MSG";
            OracleCommand cmdReadMailContent = new OracleCommand();
            cmdReadMailContent.CommandText = strQueryMailMsg;
            cmdReadMailContent.CommandType = CommandType.StoredProcedure;
            cmdReadMailContent.Parameters.Add("C_TMLT_TYP_ID", OracleDbType.Int32).Value = objEntityCommon.CorpMailTmpltTypId;
            cmdReadMailContent.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityCommon.CorporateID;
            cmdReadMailContent.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCommon.Organisation_Id;
            cmdReadMailContent.Parameters.Add("C_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtContent = new DataTable();
            dtContent = clsDataLayer.ExecuteReader(cmdReadMailContent);
            return dtContent;
        }


        //insert Quatation details to  table
        public void InsertQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationDetails, List<clsEntityLayerQuotationDtl> objEntityQuotatiDtlGrpList, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDetails)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertQtn = "QUOTATION.SP_INSERT_QUOTATION";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertQuotation = new OracleCommand(strQueryInsertQtn, con))
                    {
                        cmdInsertQuotation.Transaction = tran;

                        cmdInsertQuotation.CommandType = CommandType.StoredProcedure;

                        cmdInsertQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdInsertQuotation.Parameters.Add("Q_REF_SLN_ID", OracleDbType.Int32).Value = objEntityQuotation.QtnRefSerialId;
                        cmdInsertQuotation.Parameters.Add("Q_REFNUMBR", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;
                        cmdInsertQuotation.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                        cmdInsertQuotation.Parameters.Add("Q_LEADID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        if (objEntityQuotation.QuotnComment != null && objEntityQuotation.QuotnComment != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = objEntityQuotation.QuotnComment;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = null;
                        }

                        cmdInsertQuotation.Parameters.Add("Q_CRNCYMSTRID", OracleDbType.Int32).Value = objEntityQuotation.CurncyMastrId;
                        if (objEntityQuotation.PriceTerm != null && objEntityQuotation.PriceTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PriceTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.ManufacturerTerm != null && objEntityQuotation.ManufacturerTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.ManufacturerTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.PaymntTerm != null && objEntityQuotation.PaymntTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PaymntTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.DeliveryPeriod != null && objEntityQuotation.DeliveryPeriod != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryPeriod;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.DeliveryTerm != null && objEntityQuotation.DeliveryTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.WarrantyTerm != null && objEntityQuotation.WarrantyTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.WarrantyTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.ValidityTerm != null && objEntityQuotation.ValidityTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityQuotation.ValidityTerm);
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertQuotation.Parameters.Add("Q_GROSS_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.GrossAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_MODE", OracleDbType.Int32).Value = objEntityQuotation.DiscMode;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_VALUE", OracleDbType.Decimal).Value = objEntityQuotation.DiscValue;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.DiscTotalAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_NET_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.NetAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objEntityQuotation.MailStatus;
                        cmdInsertQuotation.Parameters.Add("Q_INSUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsertQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsertQuotation.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = objEntityQuotation.QuotationStatus;
                        cmdInsertQuotation.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsertQuotation.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsertQuotation.Parameters.Add("Q_APRV_STS", OracleDbType.Int32).Value = objEntityQuotation.ApprovedStatus;
                        cmdInsertQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdInsertQuotation.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsertQuotation.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                        cmdInsertQuotation.ExecuteNonQuery();

                    }
                    //insert quotation group
                    foreach (clsEntityLayerQuotationDtl objGroupDetail in objEntityQuotatiDtlGrpList)
                    {
                        if (objGroupDetail.PrdctGroupName != "")
                        {
                            int intGroupId = 0;
                            string strQueryInsertQtnGrpDetail = "QUOTATION.SP_INSERT_QUOTATION_GRPDTL";
                            using (OracleCommand cmdAddInsertQtnGrpDetail = new OracleCommand(strQueryInsertQtnGrpDetail, con))
                            {
                                cmdAddInsertQtnGrpDetail.Transaction = tran;

                                cmdAddInsertQtnGrpDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QTN_PRDCT_GROUP);
                                objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                                intGroupId = Convert.ToInt32(strNextNum);
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = intGroupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objGroupDetail.PrdctGroupName;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objGroupDetail.GrpGrossAmnt;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objGroupDetail.GrpDiscmode;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscvalue;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscAmount;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpNetAmnt;
                                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnGrpDetail);
                            }


                            //insert to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                    using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                    {
                                        cmdAddInsertQtnDetail.Transaction = tran;

                                        cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;


                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;

                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Varchar2).Value = intGroupId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdAddInsertQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    //insert to  quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntDetails)
                    {

                        string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INSERT_QUOTATION_ATTACHMENT";
                        using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand(strQueryInsertQtnAttchmntDetail, con))
                        {
                            cmdAddInsertQtnAttchmntDetail.Transaction = tran;

                            cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.QtnAttchmntSlNumber;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ATCHSTS", OracleDbType.Int32).Value = objAttchDetail.AttchWthMailsts;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                            cmdAddInsertQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Prepared);//Quotation Prepared
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Prepared);//Quotation Prepared
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
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

        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOTATION TABLE
        public DataTable ReadQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtn = "QUOTATION.SP_READ_QUOTATION";
            OracleCommand cmdReadQtn = new OracleCommand();
            cmdReadQtn.CommandText = strQueryReadQtn;
            cmdReadQtn.CommandType = CommandType.StoredProcedure;
            cmdReadQtn.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtn.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadQtn.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadQtn.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtn);
            return dtDtl;
        }

        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOT_DTLS TABLE
        public DataTable ReadQuotationDetail(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnDtl = "QUOTATION.SP_READ_QUOTATION_DTL";
            OracleCommand cmdReadQtnDtl = new OracleCommand();
            cmdReadQtnDtl.CommandText = strQueryReadQtnDtl;
            cmdReadQtnDtl.CommandType = CommandType.StoredProcedure;
            cmdReadQtnDtl.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnDtl.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadQtnDtl.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadQtnDtl.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
            cmdReadQtnDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnDtl);
            return dtDtl;
        }
        // This Method FETCHES QUOTATION ATTACHMENTS BASED ON QUOTATION ID FROM GN_QOTN_ATTACHMENTS
        public DataTable ReadQuotationAttchmnt(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnAttchmnt = "QUOTATION.SP_READ_QUOTATION_ATTACHMNT";
            OracleCommand cmdReadQtnAttchmnt = new OracleCommand();
            cmdReadQtnAttchmnt.CommandText = strQueryReadQtnAttchmnt;
            cmdReadQtnAttchmnt.CommandType = CommandType.StoredProcedure;
            cmdReadQtnAttchmnt.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnAttchmnt.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnAttchmnt);
            return dtDtl;
        }

        // This Method FETCHES CUSTOMER DETAILS BASED ON LEAD ID FROM GN_LEADS TABLE FOR SHOWING IN PDF
        public DataTable ReadCstmrDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadDtl = "QUOTATION.SP_READ_CUSTMR_DTL_BY_LEADID";
            OracleCommand cmdReadDtl = new OracleCommand();
            cmdReadDtl.CommandText = strQueryReadDtl;
            cmdReadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadDtl.Parameters.Add("Q_LEAD_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
            cmdReadDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadDtl);
            return dtDtl;
        }
        // This Method FETCHES CORP DETAILS BASED ON CORP ID FROM GN_CORP_OFFICES TABLE FOR SHOWING IN PDF
        public DataTable ReadCorpDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadDtl = "QUOTATION.SP_READ_CORP_DTL_BY_CORPID";
            OracleCommand cmdReadDtl = new OracleCommand();
            cmdReadDtl.CommandText = strQueryReadDtl;
            cmdReadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadDtl.Parameters.Add("Q_CORP_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadDtl);
            return dtDtl;
        }
        //Update Quatation details to  table
        public void UpdateQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationDtl> objEntityQuotationUpdateDetails, string[] strarrCancldtlIds, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrp, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrpUpd, string[] strarrCancldtlGrpIds, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDELETEDetails)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryUpdateQtn = "QUOTATION.SP_UPDATE_QUOTATION";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdUpdateQuotation = new OracleCommand(strQueryUpdateQtn, con))
                    {
                        cmdUpdateQuotation.Transaction = tran;

                        cmdUpdateQuotation.CommandType = CommandType.StoredProcedure;

                        cmdUpdateQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                        if (objEntityQuotation.QuotnComment != null && objEntityQuotation.QuotnComment != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = objEntityQuotation.QuotnComment;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = null;
                        }

                        cmdUpdateQuotation.Parameters.Add("Q_CRNCYMSTRID", OracleDbType.Int32).Value = objEntityQuotation.CurncyMastrId;
                        if (objEntityQuotation.PriceTerm != null && objEntityQuotation.PriceTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PriceTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.ManufacturerTerm != null && objEntityQuotation.ManufacturerTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.ManufacturerTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.PaymntTerm != null && objEntityQuotation.PaymntTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PaymntTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.DeliveryPeriod != null && objEntityQuotation.DeliveryPeriod != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryPeriod;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.DeliveryTerm != null && objEntityQuotation.DeliveryTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.WarrantyTerm != null && objEntityQuotation.WarrantyTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.WarrantyTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.ValidityTerm != null && objEntityQuotation.ValidityTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityQuotation.ValidityTerm);
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = null;
                        }
                        cmdUpdateQuotation.Parameters.Add("Q_GROSS_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.GrossAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_MODE", OracleDbType.Int32).Value = objEntityQuotation.DiscMode;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_VALUE", OracleDbType.Decimal).Value = objEntityQuotation.DiscValue;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.DiscTotalAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_NET_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.NetAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objEntityQuotation.MailStatus;
                        cmdUpdateQuotation.Parameters.Add("Q_UPDUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;

                        cmdUpdateQuotation.ExecuteNonQuery();

                    }
                    //insert quotation group
                    foreach (clsEntityLayerQuotationDtl objGroupDetail in objEntityQuotationDetailsGrp)
                    {
                        if (objGroupDetail.PrdctGroupName != "")
                        {
                            int intGroupId = 0;
                            string strQueryInsertQtnGrpDetail = "QUOTATION.SP_INSERT_QUOTATION_GRPDTL";
                            using (OracleCommand cmdAddInsertQtnGrpDetail = new OracleCommand(strQueryInsertQtnGrpDetail, con))
                            {
                                cmdAddInsertQtnGrpDetail.Transaction = tran;

                                cmdAddInsertQtnGrpDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QTN_PRDCT_GROUP);
                                objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                                intGroupId = Convert.ToInt32(strNextNum);
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = intGroupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objGroupDetail.PrdctGroupName;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objGroupDetail.GrpGrossAmnt;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objGroupDetail.GrpDiscmode;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscvalue;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscAmount;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpNetAmnt;
                                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnGrpDetail);
                            }


                            //insert to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationInsertDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                    using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                    {
                                        cmdAddInsertQtnDetail.Transaction = tran;

                                        cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;


                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;

                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = intGroupId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdAddInsertQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }

                            //Start:-New code
                            //Update to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationUpdateDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryUpdateQtnDetail = "QUOTATION.SP_UPDATE_QUOTATION_DTL";
                                    using (OracleCommand cmdUpdateQtnDetail = new OracleCommand(strQueryUpdateQtnDetail, con))
                                    {
                                        cmdUpdateQtnDetail.Transaction = tran;

                                        cmdUpdateQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = objDetail.QtnDtl_Id;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;


                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                        cmdUpdateQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;                                       
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = intGroupId;                                      
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdUpdateQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }
                            //End:-New code
                        }
                    }


                    foreach (clsEntityLayerQuotationDtl objDetailGrp in objEntityQuotationDetailsGrpUpd)
                    {
                        string strQueryUpdateQtnDetailGrp = "QUOTATION.SP_UPDATE_QUOTATION_GRPDTL";
                        using (OracleCommand cmdUpdateQtnDetailgrp = new OracleCommand(strQueryUpdateQtnDetailGrp, con))
                         {
                             cmdUpdateQtnDetailgrp.Transaction = tran;
                             cmdUpdateQtnDetailgrp.CommandType = CommandType.StoredProcedure;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = objDetailGrp.PrdctGrpId;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objDetailGrp.PrdctGroupName;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objDetailGrp.GrpGrossAmnt;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objDetailGrp.GrpDiscmode;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objDetailGrp.GrpDiscvalue;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objDetailGrp.GrpDiscAmount;
                             cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objDetailGrp.GrpNetAmnt;
                             cmdUpdateQtnDetailgrp.ExecuteNonQuery();
                         }


                        foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationInsertDetails)
                        {
                            if (objDetailGrp.PrdctGroupName == objDetail.PrdctGroupName)
                            {
                                string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                {
                                    cmdAddInsertQtnDetail.Transaction = tran;

                                    cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                    if (objDetail.ProductId != 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                    if (objDetail.Hike != "" && objDetail.Hike != null)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                    if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                    }

                                    if (objDetail.TaxId != 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                    if (objDetail.StockSts == 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Varchar2).Value = objDetailGrp.PrdctGrpId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                    cmdAddInsertQtnDetail.ExecuteNonQuery();
                                }
                            }

                        }

                        //Update to  quotation Detail table
                        foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationUpdateDetails)
                        {
                            if (objDetailGrp.PrdctGroupName == objDetail.PrdctGroupName)
                            {
                            string strQueryUpdateQtnDetail = "QUOTATION.SP_UPDATE_QUOTATION_DTL";
                            using (OracleCommand cmdUpdateQtnDetail = new OracleCommand(strQueryUpdateQtnDetail, con))
                            {
                                cmdUpdateQtnDetail.Transaction = tran;

                                cmdUpdateQtnDetail.CommandType = CommandType.StoredProcedure;
                                cmdUpdateQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdUpdateQtnDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = objDetail.QtnDtl_Id;
                                if (objDetail.ProductId != 0)
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                }
                                else
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                }
                                cmdUpdateQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                cmdUpdateQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                cmdUpdateQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                if (objDetail.Hike != "" && objDetail.Hike != null)
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                }
                                else
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                }
                                cmdUpdateQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                cmdUpdateQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                cmdUpdateQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                cmdUpdateQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;


                                if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                }
                                else
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                }

                                if (objDetail.TaxId != 0)
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                }
                                else
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                }
                                cmdUpdateQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                cmdUpdateQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                cmdUpdateQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                cmdUpdateQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                if (objDetail.StockSts == 0)
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                }
                                cmdUpdateQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                //Start:-New code
                                cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = objDetailGrp.PrdctGrpId;
                                //End:-New code
                                cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                cmdUpdateQtnDetail.ExecuteNonQuery();
                            }
                            }
                        }
                    }


                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlGrpIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelQtnDetail = "QUOTATION.SP_DELETE_QUOTATION_GRPDTL";
                            using (OracleCommand cmdCancelQtneDetail = new OracleCommand(strQueryCancelQtnDetail, con))
                            {
                                cmdCancelQtneDetail.Transaction = tran;

                                cmdCancelQtneDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelQtneDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdCancelQtneDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelQtneDetail.ExecuteNonQuery();
                            }


                        }

                    }


                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelQtnDetail = "QUOTATION.SP_CANCEL_QUOTATION_DTL";
                            using (OracleCommand cmdCancelQtneDetail = new OracleCommand(strQueryCancelQtnDetail, con))
                            {
                                cmdCancelQtneDetail.Transaction = tran;

                                cmdCancelQtneDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelQtneDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdCancelQtneDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelQtneDetail.ExecuteNonQuery();
                            }


                        }

                    }

                    //Delete from quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntDELETEDetails)
                    {

                        string strQueryDeleteQtnAttchmntDetail = "QUOTATION.SP_DELETE_QUOTATION_ATTACHMNT";
                        using (OracleCommand cmdDeleteQtnAttchmntDetail = new OracleCommand(strQueryDeleteQtnAttchmntDetail, con))
                        {
                            cmdDeleteQtnAttchmntDetail.Transaction = tran;

                            cmdDeleteQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ATTCHMNTDTL_ID", OracleDbType.Varchar2).Value = objAttchDetail.QtnAttchmntDtlId;

                            cmdDeleteQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //insert to  quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntINSERTDetails)
                    {

                        string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INSERT_QUOTATION_ATTACHMENT";
                        using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand(strQueryInsertQtnAttchmntDetail, con))
                        {
                            cmdAddInsertQtnAttchmntDetail.Transaction = tran;

                            cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.QtnAttchmntSlNumber;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ATCHSTS", OracleDbType.Int32).Value = objAttchDetail.AttchWthMailsts;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                            cmdAddInsertQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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


        //Confirm Quatation details to  table.In this method all are same as update other than updating status to confirmed
        public void ConfirmQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationDtl> objEntityQuotationUpdateDetails, string[] strarrCancldtlIds, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrp, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrpUpd, string[] strarrCancldtlGrpIds, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDELETEDetails)
        {
            //In this method all are same as update method other than updating status to confirmed
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryUpdateQtn = "QUOTATION.SP_UPDATE_QUOTATION";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdUpdateQuotation = new OracleCommand(strQueryUpdateQtn, con))
                    {
                        cmdUpdateQuotation.Transaction = tran;

                        cmdUpdateQuotation.CommandType = CommandType.StoredProcedure;

                        cmdUpdateQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                        if (objEntityQuotation.QuotnComment != null && objEntityQuotation.QuotnComment != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = objEntityQuotation.QuotnComment;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = null;
                        }

                        cmdUpdateQuotation.Parameters.Add("Q_CRNCYMSTRID", OracleDbType.Int32).Value = objEntityQuotation.CurncyMastrId;
                        if (objEntityQuotation.PriceTerm != null && objEntityQuotation.PriceTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PriceTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.ManufacturerTerm != null && objEntityQuotation.ManufacturerTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.ManufacturerTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = null;
                        }


                        if (objEntityQuotation.PaymntTerm != null && objEntityQuotation.PaymntTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PaymntTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.DeliveryPeriod != null && objEntityQuotation.DeliveryPeriod != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryPeriod;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.DeliveryTerm != null && objEntityQuotation.DeliveryTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.WarrantyTerm != null && objEntityQuotation.WarrantyTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.WarrantyTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.ValidityTerm != null && objEntityQuotation.ValidityTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityQuotation.ValidityTerm);
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = null;
                        }
                        cmdUpdateQuotation.Parameters.Add("Q_GROSS_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.GrossAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_MODE", OracleDbType.Int32).Value = objEntityQuotation.DiscMode;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_VALUE", OracleDbType.Decimal).Value = objEntityQuotation.DiscValue;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.DiscTotalAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_NET_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.NetAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objEntityQuotation.MailStatus;
                        cmdUpdateQuotation.Parameters.Add("Q_UPDUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;

                        cmdUpdateQuotation.ExecuteNonQuery();

                    }
                    //insert quotation group
                    foreach (clsEntityLayerQuotationDtl objGroupDetail in objEntityQuotationDetailsGrp)
                    {
                        if (objGroupDetail.PrdctGroupName != "")
                        {
                            int intGroupId = 0;
                            string strQueryInsertQtnGrpDetail = "QUOTATION.SP_INSERT_QUOTATION_GRPDTL";
                            using (OracleCommand cmdAddInsertQtnGrpDetail = new OracleCommand(strQueryInsertQtnGrpDetail, con))
                            {
                                cmdAddInsertQtnGrpDetail.Transaction = tran;

                                cmdAddInsertQtnGrpDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QTN_PRDCT_GROUP);
                                objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                                intGroupId = Convert.ToInt32(strNextNum);
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = intGroupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objGroupDetail.PrdctGroupName;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objGroupDetail.GrpGrossAmnt;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objGroupDetail.GrpDiscmode;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscvalue;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscAmount;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpNetAmnt;
                                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnGrpDetail);
                            }


                            //insert to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationInsertDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                    using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                    {
                                        cmdAddInsertQtnDetail.Transaction = tran;

                                        cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;


                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;

                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = intGroupId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdAddInsertQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }

                            //Start:-New code
                            //Update to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationUpdateDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryUpdateQtnDetail = "QUOTATION.SP_UPDATE_QUOTATION_DTL";
                                    using (OracleCommand cmdUpdateQtnDetail = new OracleCommand(strQueryUpdateQtnDetail, con))
                                    {
                                        cmdUpdateQtnDetail.Transaction = tran;

                                        cmdUpdateQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = objDetail.QtnDtl_Id;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;


                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                        cmdUpdateQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = intGroupId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdUpdateQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }
                            //End:-New code
                        }
                    }


                    foreach (clsEntityLayerQuotationDtl objDetailGrp in objEntityQuotationDetailsGrpUpd)
                    {
                        string strQueryUpdateQtnDetailGrp = "QUOTATION.SP_UPDATE_QUOTATION_GRPDTL";
                        using (OracleCommand cmdUpdateQtnDetailgrp = new OracleCommand(strQueryUpdateQtnDetailGrp, con))
                        {
                            cmdUpdateQtnDetailgrp.Transaction = tran;
                            cmdUpdateQtnDetailgrp.CommandType = CommandType.StoredProcedure;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = objDetailGrp.PrdctGrpId;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objDetailGrp.PrdctGroupName;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objDetailGrp.GrpGrossAmnt;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objDetailGrp.GrpDiscmode;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objDetailGrp.GrpDiscvalue;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objDetailGrp.GrpDiscAmount;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objDetailGrp.GrpNetAmnt;
                            cmdUpdateQtnDetailgrp.ExecuteNonQuery();
                        }


                        foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationInsertDetails)
                        {
                            if (objDetailGrp.PrdctGroupName == objDetail.PrdctGroupName)
                            {
                                string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                {
                                    cmdAddInsertQtnDetail.Transaction = tran;

                                    cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                    if (objDetail.ProductId != 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                    if (objDetail.Hike != "" && objDetail.Hike != null)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                    if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                    }

                                    if (objDetail.TaxId != 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                    if (objDetail.StockSts == 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Varchar2).Value = objDetailGrp.PrdctGrpId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                    cmdAddInsertQtnDetail.ExecuteNonQuery();
                                }
                            }

                        }

                        //Update to  quotation Detail table
                        foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationUpdateDetails)
                        {
                            if (objDetailGrp.PrdctGroupName == objDetail.PrdctGroupName)
                            {
                                string strQueryUpdateQtnDetail = "QUOTATION.SP_UPDATE_QUOTATION_DTL";
                                using (OracleCommand cmdUpdateQtnDetail = new OracleCommand(strQueryUpdateQtnDetail, con))
                                {
                                    cmdUpdateQtnDetail.Transaction = tran;

                                    cmdUpdateQtnDetail.CommandType = CommandType.StoredProcedure;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = objDetail.QtnDtl_Id;
                                    if (objDetail.ProductId != 0)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                    if (objDetail.Hike != "" && objDetail.Hike != null)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;


                                    if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                    }

                                    if (objDetail.TaxId != 0)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                    cmdUpdateQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                    if (objDetail.StockSts == 0)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                    //Start:-New code
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = objDetailGrp.PrdctGrpId;
                                    //End:-New code
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                    cmdUpdateQtnDetail.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlGrpIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelQtnDetail = "QUOTATION.SP_DELETE_QUOTATION_GRPDTL";
                            using (OracleCommand cmdCancelQtneDetail = new OracleCommand(strQueryCancelQtnDetail, con))
                            {
                                cmdCancelQtneDetail.Transaction = tran;

                                cmdCancelQtneDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelQtneDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdCancelQtneDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelQtneDetail.ExecuteNonQuery();
                            }


                        }

                    }
                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelQtnDetail = "QUOTATION.SP_CANCEL_QUOTATION_DTL";
                            using (OracleCommand cmdCancelQtneDetail = new OracleCommand(strQueryCancelQtnDetail, con))
                            {
                                cmdCancelQtneDetail.Transaction = tran;

                                cmdCancelQtneDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelQtneDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdCancelQtneDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelQtneDetail.ExecuteNonQuery();
                            }


                        }

                    }

                    //Delete from quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntDELETEDetails)
                    {

                        string strQueryDeleteQtnAttchmntDetail = "QUOTATION.SP_DELETE_QUOTATION_ATTACHMNT";
                        using (OracleCommand cmdDeleteQtnAttchmntDetail = new OracleCommand(strQueryDeleteQtnAttchmntDetail, con))
                        {
                            cmdDeleteQtnAttchmntDetail.Transaction = tran;

                            cmdDeleteQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ATTCHMNTDTL_ID", OracleDbType.Varchar2).Value = objAttchDetail.QtnAttchmntDtlId;

                            cmdDeleteQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //insert to  quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntINSERTDetails)
                    {

                        string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INSERT_QUOTATION_ATTACHMENT";
                        using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand(strQueryInsertQtnAttchmntDetail, con))
                        {
                            cmdAddInsertQtnAttchmntDetail.Transaction = tran;

                            cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.QtnAttchmntSlNumber;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ATCHSTS", OracleDbType.Int32).Value = objAttchDetail.AttchWthMailsts;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                            cmdAddInsertQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //---------------------------------------------------------------------------change other than update method is code below


                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 1;//confirmed
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }

                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Approval_Pending); //Quotation Approval Pending
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Approval_Pending); //Quotation Approval Pending
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }
                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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

        //Approve Quatation details to  table.In this method all are same as update other than updating status to approve
        public void ApproveQuotation(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQuotationInsertDetails, List<clsEntityLayerQuotationDtl> objEntityQuotationUpdateDetails, string[] strarrCancldtlIds, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrp, List<clsEntityLayerQuotationDtl> objEntityQuotationDetailsGrpUpd, string[] strarrCancldtlGrpIds, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntINSERTDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDELETEDetails)
        {
            //In this method all are same as update method other than updating status to Approve
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryUpdateQtn = "QUOTATION.SP_UPDATE_QUOTATION";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdUpdateQuotation = new OracleCommand(strQueryUpdateQtn, con))
                    {
                        cmdUpdateQuotation.Transaction = tran;

                        cmdUpdateQuotation.CommandType = CommandType.StoredProcedure;

                        cmdUpdateQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                        if (objEntityQuotation.QuotnComment != null && objEntityQuotation.QuotnComment != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = objEntityQuotation.QuotnComment;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = null;
                        }

                        cmdUpdateQuotation.Parameters.Add("Q_CRNCYMSTRID", OracleDbType.Int32).Value = objEntityQuotation.CurncyMastrId;
                        if (objEntityQuotation.PriceTerm != null && objEntityQuotation.PriceTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PriceTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.ManufacturerTerm != null && objEntityQuotation.ManufacturerTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.ManufacturerTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.PaymntTerm != null && objEntityQuotation.PaymntTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PaymntTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.DeliveryPeriod != null && objEntityQuotation.DeliveryPeriod != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryPeriod;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.DeliveryTerm != null && objEntityQuotation.DeliveryTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.WarrantyTerm != null && objEntityQuotation.WarrantyTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.WarrantyTerm;
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.ValidityTerm != null && objEntityQuotation.ValidityTerm != "")
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityQuotation.ValidityTerm);
                        }
                        else
                        {
                            cmdUpdateQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = null;
                        }
                        cmdUpdateQuotation.Parameters.Add("Q_GROSS_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.GrossAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_MODE", OracleDbType.Int32).Value = objEntityQuotation.DiscMode;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_VALUE", OracleDbType.Decimal).Value = objEntityQuotation.DiscValue;
                        cmdUpdateQuotation.Parameters.Add("Q_BILL_DISC_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.DiscTotalAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_NET_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.NetAmnt;
                        cmdUpdateQuotation.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objEntityQuotation.MailStatus;
                        cmdUpdateQuotation.Parameters.Add("Q_UPDUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;

                        cmdUpdateQuotation.ExecuteNonQuery();

                    }
                    //insert quotation group
                    foreach (clsEntityLayerQuotationDtl objGroupDetail in objEntityQuotationDetailsGrp)
                    {
                        if (objGroupDetail.PrdctGroupName != "")
                        {
                            int intGroupId = 0;
                            string strQueryInsertQtnGrpDetail = "QUOTATION.SP_INSERT_QUOTATION_GRPDTL";
                            using (OracleCommand cmdAddInsertQtnGrpDetail = new OracleCommand(strQueryInsertQtnGrpDetail, con))
                            {
                                cmdAddInsertQtnGrpDetail.Transaction = tran;

                                cmdAddInsertQtnGrpDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QTN_PRDCT_GROUP);
                                objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                                intGroupId = Convert.ToInt32(strNextNum);
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = intGroupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objGroupDetail.PrdctGroupName;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objGroupDetail.GrpGrossAmnt;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objGroupDetail.GrpDiscmode;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscvalue;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscAmount;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpNetAmnt;
                                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnGrpDetail);
                            }


                            //insert to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationInsertDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                    using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                    {
                                        cmdAddInsertQtnDetail.Transaction = tran;

                                        cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;


                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;

                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = intGroupId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdAddInsertQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }

                            //Start:-New code
                            //Update to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationUpdateDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryUpdateQtnDetail = "QUOTATION.SP_UPDATE_QUOTATION_DTL";
                                    using (OracleCommand cmdUpdateQtnDetail = new OracleCommand(strQueryUpdateQtnDetail, con))
                                    {
                                        cmdUpdateQtnDetail.Transaction = tran;

                                        cmdUpdateQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = objDetail.QtnDtl_Id;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;


                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                        cmdUpdateQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = intGroupId;
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdUpdateQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }
                            //End:-New code
                        }
                    }


                    foreach (clsEntityLayerQuotationDtl objDetailGrp in objEntityQuotationDetailsGrpUpd)
                    {
                        string strQueryUpdateQtnDetailGrp = "QUOTATION.SP_UPDATE_QUOTATION_GRPDTL";
                        using (OracleCommand cmdUpdateQtnDetailgrp = new OracleCommand(strQueryUpdateQtnDetailGrp, con))
                        {
                            cmdUpdateQtnDetailgrp.Transaction = tran;
                            cmdUpdateQtnDetailgrp.CommandType = CommandType.StoredProcedure;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = objDetailGrp.PrdctGrpId;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objDetailGrp.PrdctGroupName;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objDetailGrp.GrpGrossAmnt;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objDetailGrp.GrpDiscmode;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objDetailGrp.GrpDiscvalue;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objDetailGrp.GrpDiscAmount;
                            cmdUpdateQtnDetailgrp.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objDetailGrp.GrpNetAmnt;
                            cmdUpdateQtnDetailgrp.ExecuteNonQuery();
                        }


                        foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationInsertDetails)
                        {
                            if (objDetailGrp.PrdctGroupName == objDetail.PrdctGroupName)
                            {
                                string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                {
                                    cmdAddInsertQtnDetail.Transaction = tran;

                                    cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                    if (objDetail.ProductId != 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                    if (objDetail.Hike != "" && objDetail.Hike != null)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                    if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                    }

                                    if (objDetail.TaxId != 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;

                                    cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                    if (objDetail.StockSts == 0)
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                    }
                                    else
                                    {
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                    }
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Varchar2).Value = objDetailGrp.PrdctGrpId;
                                    cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                    cmdAddInsertQtnDetail.ExecuteNonQuery();
                                }
                            }

                        }

                        //Update to  quotation Detail table
                        foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationUpdateDetails)
                        {
                            if (objDetailGrp.PrdctGroupName == objDetail.PrdctGroupName)
                            {
                                string strQueryUpdateQtnDetail = "QUOTATION.SP_UPDATE_QUOTATION_DTL";
                                using (OracleCommand cmdUpdateQtnDetail = new OracleCommand(strQueryUpdateQtnDetail, con))
                                {
                                    cmdUpdateQtnDetail.Transaction = tran;

                                    cmdUpdateQtnDetail.CommandType = CommandType.StoredProcedure;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = objDetail.QtnDtl_Id;
                                    if (objDetail.ProductId != 0)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                    if (objDetail.Hike != "" && objDetail.Hike != null)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;


                                    if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                    }

                                    if (objDetail.TaxId != 0)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;

                                    cmdUpdateQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;
                                    if (objDetail.StockSts == 0)
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                    }
                                    else
                                    {
                                        cmdUpdateQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                    }
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                    //Start:-New code
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Int32).Value = objDetailGrp.PrdctGrpId;
                                    //End:-New code
                                    cmdUpdateQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                    cmdUpdateQtnDetail.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlGrpIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelQtnDetail = "QUOTATION.SP_DELETE_QUOTATION_GRPDTL";
                            using (OracleCommand cmdCancelQtneDetail = new OracleCommand(strQueryCancelQtnDetail, con))
                            {
                                cmdCancelQtneDetail.Transaction = tran;

                                cmdCancelQtneDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelQtneDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdCancelQtneDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelQtneDetail.ExecuteNonQuery();
                            }


                        }

                    }
                    //Cancel the rows that have been cancelled when editing in Detail table
                    foreach (string strDtlId in strarrCancldtlIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelQtnDetail = "QUOTATION.SP_CANCEL_QUOTATION_DTL";
                            using (OracleCommand cmdCancelQtneDetail = new OracleCommand(strQueryCancelQtnDetail, con))
                            {
                                cmdCancelQtneDetail.Transaction = tran;

                                cmdCancelQtneDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelQtneDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdCancelQtneDetail.Parameters.Add("Q_DTLID", OracleDbType.Int32).Value = intDtlId;

                                cmdCancelQtneDetail.ExecuteNonQuery();
                            }


                        }

                    }

                    //Delete from quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntDELETEDetails)
                    {

                        string strQueryDeleteQtnAttchmntDetail = "QUOTATION.SP_DELETE_QUOTATION_ATTACHMNT";
                        using (OracleCommand cmdDeleteQtnAttchmntDetail = new OracleCommand(strQueryDeleteQtnAttchmntDetail, con))
                        {
                            cmdDeleteQtnAttchmntDetail.Transaction = tran;

                            cmdDeleteQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdDeleteQtnAttchmntDetail.Parameters.Add("Q_ATTCHMNTDTL_ID", OracleDbType.Varchar2).Value = objAttchDetail.QtnAttchmntDtlId;

                            cmdDeleteQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //insert to  quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntINSERTDetails)
                    {

                        string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INSERT_QUOTATION_ATTACHMENT";
                        using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand(strQueryInsertQtnAttchmntDetail, con))
                        {
                            cmdAddInsertQtnAttchmntDetail.Transaction = tran;

                            cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.QtnAttchmntSlNumber;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ATCHSTS", OracleDbType.Int32).Value = objAttchDetail.AttchWthMailsts;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                            cmdAddInsertQtnAttchmntDetail.ExecuteNonQuery();
                        }
                    }

                    //---------------------------------------------------------------------------change other than update method is code below


                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        if (objEntityQuotation.MailStatus == 1)
                        {
                            cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 4;//Delivered

                        }
                        else
                        {
                            cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 3;//Approved

                        }

                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }

                    string strQueryUpdateQtnApprvStatus = "QUOTATION.SP_UPDATE_APPROVE_DTL";
                    using (OracleCommand cmdUpdateQtnApprvStatus = new OracleCommand(strQueryUpdateQtnApprvStatus, con))
                    {
                        cmdUpdateQtnApprvStatus.Transaction = tran;

                        cmdUpdateQtnApprvStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnApprvStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnApprvStatus.Parameters.Add("Q_APRV_STS", OracleDbType.Int32).Value = 1;//Approve
                        cmdUpdateQtnApprvStatus.Parameters.Add("LDQUOT_APRVD_USR_ID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnApprvStatus.Parameters.Add("LDQUOT_APRVD_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;

                        cmdUpdateQtnApprvStatus.ExecuteNonQuery();
                    }

                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        if (objEntityQuotation.MailStatus == 1)
                        {
                            cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered); //Quotation Delivered
                        }
                        else
                        {

                            cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Approved); //Quotation Approved
                        }
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        if (objEntityQuotation.MailStatus == 1)
                        {
                            cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered); //Quotation Delivered
                        }
                        else
                        {

                            cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Approved); //Quotation Approved
                        }


                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }

                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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

        // This Method change quotation status to Return
        public void ReturnQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            //In this method all are same as update method other than updating status to Approve
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 2;//Return
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }

                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Returned); ;//Quotation returned
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Returned); ;//Quotation returned
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }

                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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

        // This Method change quotation status to ReOpen
        public void ReOpenQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            //In this method all are same as update method other than updating status to Approve
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 5;//ReOpen
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }
                    string strQueryUpdateQtnApprvStatus = "QUOTATION.SP_UPDATE_APPROVE_DTL";
                    using (OracleCommand cmdUpdateQtnApprvStatus = new OracleCommand(strQueryUpdateQtnApprvStatus, con))
                    {
                        cmdUpdateQtnApprvStatus.Transaction = tran;

                        cmdUpdateQtnApprvStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnApprvStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnApprvStatus.Parameters.Add("Q_APRV_STS", OracleDbType.Int32).Value = 0;//Approve
                        cmdUpdateQtnApprvStatus.Parameters.Add("LDQUOT_APRVD_USR_ID", OracleDbType.Int32).Value = null;
                        cmdUpdateQtnApprvStatus.Parameters.Add("LDQUOT_APRVD_DATE", OracleDbType.Date).Value = null;

                        cmdUpdateQtnApprvStatus.ExecuteNonQuery();
                    }
                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_ReOpened); ;//Quotation reopened
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_ReOpened); ;//Quotation reopened
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }

                    string strQueryUpdateRevisionVrsn = "QUOTATION.SP_UPDATE_QTN_REVISION_VERSN";
                    using (OracleCommand cmdUpdateRevisionVrsn = new OracleCommand(strQueryUpdateRevisionVrsn, con))
                    {
                        cmdUpdateRevisionVrsn.Transaction = tran;

                        cmdUpdateRevisionVrsn.CommandType = CommandType.StoredProcedure;
                        cmdUpdateRevisionVrsn.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateRevisionVrsn.Parameters.Add("Q_RVSN", OracleDbType.Int32).Value = objEntityQuotation.QtnRevisionVersn;

                        cmdUpdateRevisionVrsn.ExecuteNonQuery();
                    }
                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
                    }


                    string strQueryUpdateleadReOpenStatus = "QUOTATION.SP_UPDATE_LEAD_REOPEN_STS";
                    using (OracleCommand cmdUpdateLeadReopenStatus = new OracleCommand(strQueryUpdateleadReOpenStatus, con))
                    {
                        cmdUpdateLeadReopenStatus.Transaction = tran;

                        cmdUpdateLeadReopenStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadReopenStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadReopenStatus.Parameters.Add("L_REOPNRSN_ID", OracleDbType.Int32).Value = objEntityQuotation.ReopenRsn_Id;
                        if (objEntityQuotation.ReopenRsnDescrptn != "")
                        {
                            cmdUpdateLeadReopenStatus.Parameters.Add("L_REOPNRSN_DSCRPTN", OracleDbType.Varchar2).Value = objEntityQuotation.ReopenRsnDescrptn;
                        }
                        else
                        {
                            cmdUpdateLeadReopenStatus.Parameters.Add("L_REOPNRSN_DSCRPTN", OracleDbType.Varchar2).Value = null;

                        }
                        cmdUpdateLeadReopenStatus.ExecuteNonQuery();
                    }
                    string strQueryInsertleadReOpenTracking = "COMMON.SP_INS_LEAD_REOPEN_TRACK";
                    using (OracleCommand cmdInsLeadReopenTracking = new OracleCommand(strQueryInsertleadReOpenTracking, con))
                    {
                        cmdInsLeadReopenTracking.Transaction = tran;

                        cmdInsLeadReopenTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadReopenTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadReopenTracking.Parameters.Add("C_REOPNTRCK_USR_ID ", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadReopenTracking.Parameters.Add("C_REOPNTRCK_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadReopenTracking.Parameters.Add("C_REOPNRSN_ID", OracleDbType.Int32).Value = objEntityQuotation.ReopenRsn_Id;
                        cmdInsLeadReopenTracking.Parameters.Add("C_REOPNRSN_DSCRPTN", OracleDbType.Varchar2).Value = objEntityQuotation.ReopenRsnDescrptn;
                        cmdInsLeadReopenTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadReopenTracking.ExecuteNonQuery();
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
        // This Method change quotation status to Delivered
        public void DeliverQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            //In this method all are same as update method other than updating status to Approve
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 4;//Deliver
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }

                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered); //Quotation delivered
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }
                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered); //Quotation delivered
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }

                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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


        //Resend mail Quatation details to  table
        public void ReSendMailQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            //In this method all are same as update method other than updating status to Approve
            clsDataLayer objDatatLayer = new clsDataLayer();

            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {


                    //---------------------------------------------------------------------------change other than update method is code below


                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                        cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 4;//Delivered



                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }


                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;

                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered); //Quotation Delivered
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered); //Quotation Delivered

                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }
                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;

                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;

                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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

        // This Method FETCHES ACTIVE USR DTL FOR DISPLAYING IN THE PDF DOCUMENT  BASED ON LEAD ID  FOR SHOWING IN PDF
        public DataTable ReadActvUsrDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadActvUsrDtl = "QUOTATION.SP_READ_ACTV_USR_DTL_BY_LEADID";
            OracleCommand cmdReadActvUsrDtl = new OracleCommand();
            cmdReadActvUsrDtl.CommandText = strQueryReadActvUsrDtl;
            cmdReadActvUsrDtl.CommandType = CommandType.StoredProcedure;
            cmdReadActvUsrDtl.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadActvUsrDtl.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadActvUsrDtl.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
            cmdReadActvUsrDtl.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadActvUsrDtl);
            return dtDtl;
        }
        // This Method FETCHES TEAM HEAD  DTL AND DIVISION NAME OF THE LEAD FOR DISPLAYING IN THE PDF DOCUMENT  BASED ON LEAD ID  FOR SHOWING IN PDF
        public DataTable ReadTeamHeadDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadTeamHeadrDtl = "QUOTATION.SP_RD_TEAM_HEAD_DTL_BY_LEADID";
            OracleCommand cmdReadTeamHeadDtl = new OracleCommand();
            cmdReadTeamHeadDtl.CommandText = strQueryReadTeamHeadrDtl;
            cmdReadTeamHeadDtl.CommandType = CommandType.StoredProcedure;
            cmdReadTeamHeadDtl.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadTeamHeadDtl.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadTeamHeadDtl.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
            cmdReadTeamHeadDtl.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadTeamHeadDtl);
            return dtDtl;
        }

        // THIS PROCEDURE FETCHES TERMS BASED ON CORPORATE AND ORGANIZATION AND QUOTATION TEMPLATE ID
        public DataTable ReadTermTemplate(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadTermTemplate = "QUOTATION.SP_READ_TERM_TEMPLATES";
            OracleCommand cmdReadTermTemplate = new OracleCommand();
            cmdReadTermTemplate.CommandText = strQueryReadTermTemplate;
            cmdReadTermTemplate.CommandType = CommandType.StoredProcedure;
            cmdReadTermTemplate.Parameters.Add("Q_TEMPLATETYPEID", OracleDbType.Int32).Value = objEntityQuotation.TermTemplateId;
            cmdReadTermTemplate.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadTermTemplate.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadTermTemplate.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplateDtl = new DataTable();
            dtTemplateDtl = clsDataLayer.ExecuteReader(cmdReadTermTemplate);
            return dtTemplateDtl;
        }

        // THIS method FETCHES TERM DESCRIPTION BASED ON CORPORATE AND ORGANIZATION AND TERM TEMPLATE ID
        public DataTable ReadSelectedTermDtl(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadTermDtl = "QUOTATION.SP_RD_SELECTED_TERM_TMPLT_DTL";
            OracleCommand cmdReadTermDtl = new OracleCommand();
            cmdReadTermDtl.CommandText = strQueryReadTermDtl;
            cmdReadTermDtl.CommandType = CommandType.StoredProcedure;
            cmdReadTermDtl.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadTermDtl.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadTermDtl.Parameters.Add("Q_TERM_TEMPLATE_ID", OracleDbType.Int32).Value = objEntityQuotation.TermTemplateId;
            cmdReadTermDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemplateDtl = new DataTable();
            dtTemplateDtl = clsDataLayer.ExecuteReader(cmdReadTermDtl);
            return dtTemplateDtl;
        }

        // THIS method FETCHES MONTH AND YEAR OF QTN DATE IF QTN_ID IS NOT ZERO OR FETCH CURRENT MNTH AND YEAR
        public DataTable ReadMnthYearForRefNum(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadMnthYearDtl = "QUOTATION.SP_RD_MNTH_YEAR_FOR_REFNUM";
            OracleCommand cmdReadMnthYearDtl = new OracleCommand();
            cmdReadMnthYearDtl.CommandText = strQueryReadMnthYearDtl;
            cmdReadMnthYearDtl.CommandType = CommandType.StoredProcedure;
            cmdReadMnthYearDtl.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadMnthYearDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtMnthYearDtl = new DataTable();
            dtMnthYearDtl = clsDataLayer.ExecuteReader(cmdReadMnthYearDtl);
            return dtMnthYearDtl;
        }

        // This Method will fetch Reopen Reason For Drop Down
        public DataTable ReadReopenReasonMstr(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadReopenRsn = "QUOTATION.SP_READ_REOPEN_RSN_MSTR";
            OracleCommand cmdReadReopenRsn = new OracleCommand();
            cmdReadReopenRsn.CommandText = strQueryReadReopenRsn;
            cmdReadReopenRsn.CommandType = CommandType.StoredProcedure;
            cmdReadReopenRsn.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadReopenRsn.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadReopenRsn.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtReopenRsn = new DataTable();
            dtReopenRsn = clsDataLayer.ExecuteReader(cmdReadReopenRsn);
            return dtReopenRsn;
        }

        // This Method FETCHES PROJECT DTL FOR DISPLAYING IN THE PDF DOCUMENT  BASED ON LEAD ID  FOR SHOWING IN PDF
        public DataTable ReadProjectDtlForPDF(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadPrjctDtl = "QUOTATION.SP_READ_PROJECT_DTL_BY_LEADID";
            OracleCommand cmdReadPrjctDtl = new OracleCommand();
            cmdReadPrjctDtl.CommandText = strQueryReadPrjctDtl;
            cmdReadPrjctDtl.CommandType = CommandType.StoredProcedure;
            cmdReadPrjctDtl.Parameters.Add("L_CORP_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadPrjctDtl.Parameters.Add("L_ORG_ID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadPrjctDtl.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
            cmdReadPrjctDtl.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadPrjctDtl);
            return dtDtl;
        }

        //evm 0019
        public void Add_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            string strQueryAddAdtnlMail = "QTN_ADTNL_MAIL.SP_INS_QTN_MAIL";
            using (OracleCommand cmdAddAdtnlMail = new OracleCommand())
            {
                cmdAddAdtnlMail.CommandText = strQueryAddAdtnlMail;
                cmdAddAdtnlMail.CommandType = CommandType.StoredProcedure;
                cmdAddAdtnlMail.Parameters.Add("Q_LEADS_ID", OracleDbType.Int32).Value = objentityAdtnl.Lead_Id;
                cmdAddAdtnlMail.Parameters.Add("Q_TO_MAIL", OracleDbType.Varchar2).Value = objentityAdtnl.ToMail;
                cmdAddAdtnlMail.Parameters.Add("Q_CC_MAIL", OracleDbType.Varchar2).Value = objentityAdtnl.CcMail;
                cmdAddAdtnlMail.Parameters.Add("Q_BCC_MAIL", OracleDbType.Varchar2).Value = objentityAdtnl.BCcMail;
                clsDataLayer.ExecuteNonQuery(cmdAddAdtnlMail);
            }
        }
        public DataTable Read_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            string strQueryReadAdtnlMail = "QTN_ADTNL_MAIL.SP_READ_QTN_MAIL";
            OracleCommand cmdReadAdtnlMail = new OracleCommand();
            cmdReadAdtnlMail.CommandText = strQueryReadAdtnlMail;
            cmdReadAdtnlMail.CommandType = CommandType.StoredProcedure;
            cmdReadAdtnlMail.Parameters.Add("Q_LEADS_ID", OracleDbType.Int32).Value = objentityAdtnl.Lead_Id;
            cmdReadAdtnlMail.Parameters.Add("Q_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAdtnlMail);
            return dtResult;
        }
        public void Delete_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            string strQueryDeleteAdtnlMail = "QTN_ADTNL_MAIL.SP_DELETE_QTN_MAIL";
            OracleCommand cmdDeleteAdtnlMail = new OracleCommand();
            cmdDeleteAdtnlMail.CommandText = strQueryDeleteAdtnlMail;
            cmdDeleteAdtnlMail.CommandType = CommandType.StoredProcedure;
            cmdDeleteAdtnlMail.Parameters.Add("Q_LEADS_ID", OracleDbType.Int32).Value = objentityAdtnl.Lead_Id;
            clsDataLayer.ExecuteNonQuery(cmdDeleteAdtnlMail);

        }
        public void Update_Adtnl_Mail(clsEntityLayerQuotation objentityAdtnl)
        {
            string strQueryUpdateAdtnlMail = "QTN_ADTNL_MAIL.SP_CNFRM_MAIL_STS";
            OracleCommand cmdUpdateAdtnlMail = new OracleCommand();
            cmdUpdateAdtnlMail.CommandText = strQueryUpdateAdtnlMail;
            cmdUpdateAdtnlMail.CommandType = CommandType.StoredProcedure;
            cmdUpdateAdtnlMail.Parameters.Add("Q_LEADS_ID", OracleDbType.Int32).Value = objentityAdtnl.Lead_Id;
            cmdUpdateAdtnlMail.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objentityAdtnl.MailStatus;
            clsDataLayer.ExecuteNonQuery(cmdUpdateAdtnlMail);

        }

        // To read product availability status
        public DataTable ReadAvailbltyStsload(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadPrjctDtl = "QUOTATION.SP_READ_PRDCT_AVALSTS";
            OracleCommand cmdReadPrjctDtl = new OracleCommand();
            cmdReadPrjctDtl.CommandText = strQueryReadPrjctDtl;
            cmdReadPrjctDtl.CommandType = CommandType.StoredProcedure;

            cmdReadPrjctDtl.Parameters.Add("L_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadPrjctDtl);
            return dtDtl;
        }

        // method for quatation by templatetype id
        public DataTable ReadQuotationByTemplateId(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadAttch = "QUOTATION.SP_READ_QUATATION_TEMPLATE";
            using (OracleCommand cmdReadAttch = new OracleCommand())
            {
                cmdReadAttch.CommandText = strQueryReadAttch;
                cmdReadAttch.CommandType = CommandType.StoredProcedure;

                cmdReadAttch.Parameters.Add("L_ID", OracleDbType.Int64).Value = objEntityQuotation.QuotationTemplateTypeId;
                cmdReadAttch.Parameters.Add("L_USERID", OracleDbType.Int64).Value = objEntityQuotation.User_Id;
                cmdReadAttch.Parameters.Add("L_CORPID", OracleDbType.Int64).Value = objEntityQuotation.CorpOffice_Id;
                cmdReadAttch.Parameters.Add("L_ORGID", OracleDbType.Int64).Value = objEntityQuotation.Organisation_Id;

                cmdReadAttch.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadAttch = new DataTable();
                dtReadAttch = clsDataLayer.SelectDataTable(cmdReadAttch);
                return dtReadAttch;
            }
        }

        //insert Quatation details to backup table
        public void AddQuotationBckup(clsEntityLayerQuotation objEntityQuotation, List<clsEntityLayerQuotationDtl> objEntityQtnGrpDtlsList, List<clsEntityLayerQuotationDtl> objEntityQuotationDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDetails)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertQtn = "QUOTATION.SP_INSERT_QUOTATION_BCKUP";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertQuotation = new OracleCommand(strQueryInsertQtn, con))
                    {
                        cmdInsertQuotation.Transaction = tran;

                        cmdInsertQuotation.CommandType = CommandType.StoredProcedure;

                        cmdInsertQuotation.Parameters.Add("Q_LDQTBKP_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
                        cmdInsertQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdInsertQuotation.Parameters.Add("Q_REF_SLN_ID", OracleDbType.Int32).Value = objEntityQuotation.QtnRefSerialId;
                        cmdInsertQuotation.Parameters.Add("Q_REFNUMBR", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;
                        cmdInsertQuotation.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                        cmdInsertQuotation.Parameters.Add("Q_LEADID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        if (objEntityQuotation.QuotnComment != null && objEntityQuotation.QuotnComment != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = objEntityQuotation.QuotnComment;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = null;
                        }

                        cmdInsertQuotation.Parameters.Add("Q_CRNCYMSTRID", OracleDbType.Int32).Value = objEntityQuotation.CurncyMastrId;
                        if (objEntityQuotation.PriceTerm != null && objEntityQuotation.PriceTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PriceTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.ManufacturerTerm != null && objEntityQuotation.ManufacturerTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.ManufacturerTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.PaymntTerm != null && objEntityQuotation.PaymntTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PaymntTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.DeliveryPeriod != null && objEntityQuotation.DeliveryPeriod != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryPeriod;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.DeliveryTerm != null && objEntityQuotation.DeliveryTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.WarrantyTerm != null && objEntityQuotation.WarrantyTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.WarrantyTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.ValidityTerm != null && objEntityQuotation.ValidityTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityQuotation.ValidityTerm);
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertQuotation.Parameters.Add("Q_GROSS_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.GrossAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_MODE", OracleDbType.Int32).Value = objEntityQuotation.DiscMode;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_VALUE", OracleDbType.Decimal).Value = objEntityQuotation.DiscValue;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.DiscTotalAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_NET_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.NetAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objEntityQuotation.MailStatus;
                        cmdInsertQuotation.Parameters.Add("Q_INSUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsertQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsertQuotation.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = objEntityQuotation.QuotationStatus;
                        cmdInsertQuotation.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsertQuotation.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsertQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdInsertQuotation.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsertQuotation.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                        cmdInsertQuotation.ExecuteNonQuery();

                    }

                                        //insert quotation group
                    foreach (clsEntityLayerQuotationDtl objGroupDetail in objEntityQtnGrpDtlsList)
                    {
                        if (objGroupDetail.PrdctGroupName != "")
                        {
                            int intGroupId = 0;
                            string strQueryInsertQtnGrpDetail = "QUOTATION.SP_INSERT_QUOTATION_GRPDTL_BCK";
                            using (OracleCommand cmdAddInsertQtnGrpDetail = new OracleCommand(strQueryInsertQtnGrpDetail, con))
                            {
                                cmdAddInsertQtnGrpDetail.Transaction = tran;

                                cmdAddInsertQtnGrpDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QTN_PRDCT_GROUP);
                                objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                                intGroupId = Convert.ToInt32(strNextNum);
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_ID", OracleDbType.Int32).Value = intGroupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = objGroupDetail.PrdctGrpId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("Q_BID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_NAME", OracleDbType.Varchar2).Value = objGroupDetail.PrdctGroupName;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_GROSS", OracleDbType.Decimal).Value = objGroupDetail.GrpGrossAmnt;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_DISCMODE", OracleDbType.Int32).Value = objGroupDetail.GrpDiscmode;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_DISCVAL", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscvalue;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_DISCAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscAmount;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_BGRP_NETAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpNetAmnt;
                                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnGrpDetail);
                            }



                            //insert to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationDetails)
                            {
                                if (objGroupDetail.PrdctGrpId == objDetail.PrdctGrpId)
                                {
                                    string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL_BCKUP";
                                    using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                    {
                                        cmdAddInsertQtnDetail.Transaction = tran;

                                        cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;

                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;

                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;

                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;


                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;

                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CATNAME", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_GROUP_ID", OracleDbType.Int32).Value = objDetail.PrdctGrpId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_BGROUP_ID", OracleDbType.Int32).Value = intGroupId;
                                        cmdAddInsertQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    //insert to  quotation attachment backup table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntDetails)
                    {

                        string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INSERT_QTN_ATMNT_BCKUP";
                        using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand(strQueryInsertQtnAttchmntDetail, con))
                        {
                            cmdAddInsertQtnAttchmntDetail.Transaction = tran;

                            cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.QtnAttchmntSlNumber;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objAttchDetail.AttchWthMailsts;
                            cmdAddInsertQtnAttchmntDetail.ExecuteNonQuery();
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



        // method for read revised quatation list by templatetype id
        public DataTable ReadRvsdQuotation(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadAttch = "QUOTATION.SP_READ_RVSD_QTN";
            using (OracleCommand cmdReadAttch = new OracleCommand())
            {
                cmdReadAttch.CommandText = strQueryReadAttch;
                cmdReadAttch.CommandType = CommandType.StoredProcedure;
                cmdReadAttch.Parameters.Add("L_ID", OracleDbType.Int64).Value = objEntityQuotation.Lead_Id;
                cmdReadAttch.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadAttch = new DataTable();
                dtReadAttch = clsDataLayer.SelectDataTable(cmdReadAttch);
                return dtReadAttch;
            }
        }

        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOTATION BACKUP TABLE
        public DataTable ReadQuotationBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtn = "QUOTATION.SP_READ_QUOTATION_BCK";
            OracleCommand cmdReadQtn = new OracleCommand();
            cmdReadQtn.CommandText = strQueryReadQtn;
            cmdReadQtn.CommandType = CommandType.StoredProcedure;
            cmdReadQtn.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtn.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadQtn.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadQtn.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtn);
            return dtDtl;
        }

        // This Method FETCHES QUOTATION DETAILS BASED ON QUOTATION ID FOR DISPALYING QUOTATION DETAILS FROM GN_LD_QUOT_DTLS BACKUP TABLE
        public DataTable ReadQuotationDetailBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnDtl = "QUOTATION.SP_READ_QUOTATION_DTL_BCK";
            OracleCommand cmdReadQtnDtl = new OracleCommand();
            cmdReadQtnDtl.CommandText = strQueryReadQtnDtl;
            cmdReadQtnDtl.CommandType = CommandType.StoredProcedure;
            cmdReadQtnDtl.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnDtl.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadQtnDtl.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadQtnDtl.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
            cmdReadQtnDtl.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnDtl);
            return dtDtl;
        }
        // This Method FETCHES QUOTATION ATTACHMENTS BASED ON QUOTATION ID FROM GN_QOTN_ATTACHMENTS BACKUP TABLE
        public DataTable ReadQuotationAttchmntBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnAttchmnt = "QUOTATION.SP_READ_QUOTATION_AMNT_BCK";
            OracleCommand cmdReadQtnAttchmnt = new OracleCommand();
            cmdReadQtnAttchmnt.CommandText = strQueryReadQtnAttchmnt;
            cmdReadQtnAttchmnt.CommandType = CommandType.StoredProcedure;
            cmdReadQtnAttchmnt.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnAttchmnt.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnAttchmnt);
            return dtDtl;
        }


        //insert Quatation details to  table from backup table
        public void InsertQuotationFrmBckup(clsEntityLayerQuotation objEntityQuotation,List<clsEntityLayerQuotationDtl> objEntityQtnGrpDtlsList, List<clsEntityLayerQuotationDtl> objEntityQuotationDetails, List<clsEntityLayerQuotationAttchmntDtl> objEntityQuotationAttchmntDetails)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertQtn = "QUOTATION.SP_INSERT_QUOTATION";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    int intReopenCount = 0;
                    //To read previous data
                    string strQueryReadRefNo = "QUOTATION.SP_READ_REFNO";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryReadRefNo, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;
                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("Q_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        DataTable dtDtl = new DataTable();
                        dtDtl = clsDataLayer.ExecuteReader(cmdUpdateLeadStatus);
                        if (dtDtl.Rows.Count > 0)
                        {
                            objEntityQuotation.QuotationRefNumbr = dtDtl.Rows[0]["LDQUOT_REF_NUMBER"].ToString();
                            intReopenCount = Convert.ToInt32(dtDtl.Rows[0]["LDQUOT_RVSN"].ToString());
                        }
                    }
                    //To delete previous data
                    string strQueryUpdateleadStatusss = "QUOTATION.SP_DELE_QTN";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatusss, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;
                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    using (OracleCommand cmdInsertQuotation = new OracleCommand(strQueryInsertQtn, con))
                    {
                        cmdInsertQuotation.Transaction = tran;

                        cmdInsertQuotation.CommandType = CommandType.StoredProcedure;

                        cmdInsertQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdInsertQuotation.Parameters.Add("Q_REF_SLN_ID", OracleDbType.Int32).Value = objEntityQuotation.QtnRefSerialId;
                        cmdInsertQuotation.Parameters.Add("Q_REFNUMBR", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;
                        cmdInsertQuotation.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                        cmdInsertQuotation.Parameters.Add("Q_LEADID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        if (objEntityQuotation.QuotnComment != null && objEntityQuotation.QuotnComment != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = objEntityQuotation.QuotnComment;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_COMMENTS", OracleDbType.Varchar2).Value = null;
                        }

                        cmdInsertQuotation.Parameters.Add("Q_CRNCYMSTRID", OracleDbType.Int32).Value = objEntityQuotation.CurncyMastrId;
                        if (objEntityQuotation.PriceTerm != null && objEntityQuotation.PriceTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PriceTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PRICE_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.ManufacturerTerm != null && objEntityQuotation.ManufacturerTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.ManufacturerTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_MANUFACTURER_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.PaymntTerm != null && objEntityQuotation.PaymntTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.PaymntTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_PYMNT_TERM", OracleDbType.Varchar2).Value = null;
                        }

                        if (objEntityQuotation.DeliveryPeriod != null && objEntityQuotation.DeliveryPeriod != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryPeriod;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_PERIOD", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.DeliveryTerm != null && objEntityQuotation.DeliveryTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.DeliveryTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_DLVRY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.WarrantyTerm != null && objEntityQuotation.WarrantyTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = objEntityQuotation.WarrantyTerm;
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_WRNTY_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityQuotation.ValidityTerm != null && objEntityQuotation.ValidityTerm != "")
                        {
                            cmdInsertQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityQuotation.ValidityTerm);
                        }
                        else
                        {
                            cmdInsertQuotation.Parameters.Add("Q_VALIDITY_TERM", OracleDbType.Int32).Value = null;
                        }
                        cmdInsertQuotation.Parameters.Add("Q_GROSS_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.GrossAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_MODE", OracleDbType.Int32).Value = objEntityQuotation.DiscMode;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_VALUE", OracleDbType.Decimal).Value = objEntityQuotation.DiscValue;
                        cmdInsertQuotation.Parameters.Add("Q_BILL_DISC_TOTAL_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.DiscTotalAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_NET_AMNT", OracleDbType.Decimal).Value = objEntityQuotation.NetAmnt;
                        cmdInsertQuotation.Parameters.Add("Q_MAIL_STS", OracleDbType.Int32).Value = objEntityQuotation.MailStatus;
                        cmdInsertQuotation.Parameters.Add("Q_INSUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsertQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsertQuotation.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = objEntityQuotation.QuotationStatus;
                        cmdInsertQuotation.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsertQuotation.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsertQuotation.Parameters.Add("Q_APRV_STS", OracleDbType.Int32).Value = objEntityQuotation.ApprovedStatus;
                        cmdInsertQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdInsertQuotation.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsertQuotation.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                        cmdInsertQuotation.ExecuteNonQuery();

                    }

                    string strQueryUpdateleadStatusssS = "QUOTATION.SP_UPD_REOPEN_CNT";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatusssS, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;
                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("Q_RCOUNT", OracleDbType.Int32).Value = intReopenCount;
                        
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }


                    //insert quotation group
                    foreach (clsEntityLayerQuotationDtl objGroupDetail in objEntityQtnGrpDtlsList)
                    {
                        if (objGroupDetail.PrdctGroupName != "")
                        {
                            int intGroupId = 0;
                            string strQueryInsertQtnGrpDetail = "QUOTATION.SP_INSERT_QUOTATION_GRPDTL";
                            using (OracleCommand cmdAddInsertQtnGrpDetail = new OracleCommand(strQueryInsertQtnGrpDetail, con))
                            {
                                cmdAddInsertQtnGrpDetail.Transaction = tran;

                                cmdAddInsertQtnGrpDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QTN_PRDCT_GROUP);
                                objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon);
                                intGroupId = Convert.ToInt32(strNextNum);
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_ID", OracleDbType.Int32).Value = intGroupId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NAME", OracleDbType.Varchar2).Value = objGroupDetail.PrdctGroupName;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_GROSS", OracleDbType.Decimal).Value = objGroupDetail.GrpGrossAmnt;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCMODE", OracleDbType.Int32).Value = objGroupDetail.GrpDiscmode;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCVAL", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscvalue;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_DISCAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpDiscAmount;
                                cmdAddInsertQtnGrpDetail.Parameters.Add("C_GRP_NETAMNT", OracleDbType.Decimal).Value = objGroupDetail.GrpNetAmnt;
                                clsDataLayer.ExecuteNonQuery(cmdAddInsertQtnGrpDetail);
                            }


                            //insert to  quotation Detail table
                            foreach (clsEntityLayerQuotationDtl objDetail in objEntityQuotationDetails)
                            {
                                if (objGroupDetail.PrdctGroupName == objDetail.PrdctGroupName)
                                {
                                    string strQueryInsertQtnDetail = "QUOTATION.SP_INSERT_QUOTATION_DTL";
                                    using (OracleCommand cmdAddInsertQtnDetail = new OracleCommand(strQueryInsertQtnDetail, con))
                                    {
                                        cmdAddInsertQtnDetail.Transaction = tran;

                                        cmdAddInsertQtnDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;

                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QTN_DATE", OracleDbType.Date).Value = objEntityQuotation.QuotationDate;
                                        if (objDetail.ProductId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = objDetail.ProductId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_ID", OracleDbType.Int32).Value = objDetail.UOMId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_QUANTITY", OracleDbType.Decimal).Value = objDetail.Quantity;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_COST_PRICE", OracleDbType.Decimal).Value = objDetail.CostPrice;
                                        if (objDetail.Hike != "" && objDetail.Hike != null)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = Convert.ToDecimal(objDetail.Hike);
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_HIKE", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_RATE", OracleDbType.Decimal).Value = objDetail.Rate;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_DISC_AMNT", OracleDbType.Decimal).Value = objDetail.ItemDiscntAmnt;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_AMOUNT", OracleDbType.Decimal).Value = objDetail.Amount;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_STOCK_STS", OracleDbType.Int32).Value = 1;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CNCL_STS", OracleDbType.Int32).Value = objDetail.CancelSts;

                                        if (objDetail.ItemDescription != null && objDetail.ItemDescription != "")
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = objDetail.ItemDescription;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_DESCRIPTION", OracleDbType.Varchar2).Value = null;
                                        }

                                        if (objDetail.TaxId != 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = objDetail.TaxId;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_PERC", OracleDbType.Decimal).Value = objDetail.TaxPecentage;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TAX_AMNT", OracleDbType.Decimal).Value = objDetail.TaxAmnt;


                                        cmdAddInsertQtnDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_TMPLT_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationTemplateTypeId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_NAME", OracleDbType.Varchar2).Value = objDetail.ProductName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_UOM_NAME", OracleDbType.Varchar2).Value = objDetail.UOMName;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_MODE", OracleDbType.Int32).Value = objDetail.ProductMode;

                                        if (objDetail.StockSts == 0)
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCTAVLSTS", OracleDbType.Int32).Value = objDetail.StockSts;
                                        }
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRINTSTS", OracleDbType.Int32).Value = objDetail.Print;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_CAT", OracleDbType.Varchar2).Value = objDetail.ProductCategory;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_GRPID", OracleDbType.Varchar2).Value = intGroupId;
                                        cmdAddInsertQtnDetail.Parameters.Add("Q_PRDCT_ORDRID", OracleDbType.Varchar2).Value = objDetail.OrderNumberId;
                                        cmdAddInsertQtnDetail.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    //insert to  quotation attachment table
                    foreach (clsEntityLayerQuotationAttchmntDtl objAttchDetail in objEntityQuotationAttchmntDetails)
                    {

                        string strQueryInsertQtnAttchmntDetail = "QUOTATION.SP_INSERT_QUOTATION_ATTACHMENT";
                        using (OracleCommand cmdAddInsertQtnAttchmntDetail = new OracleCommand(strQueryInsertQtnAttchmntDetail, con))
                        {
                            cmdAddInsertQtnAttchmntDetail.Transaction = tran;

                            cmdAddInsertQtnAttchmntDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_FILENAME", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ACTUALNAME", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_SLNUMBR", OracleDbType.Int32).Value = objAttchDetail.QtnAttchmntSlNumber;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_QTN_ATCHSTS", OracleDbType.Int32).Value = objAttchDetail.AttchWthMailsts;
                            cmdAddInsertQtnAttchmntDetail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                            cmdAddInsertQtnAttchmntDetail.ExecuteNonQuery();
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

        //Currency selection
        public DataTable ReadCurrencyLoad(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnAttchmnt = "QUOTATION.SP_READ_CURNCY_LOAD";
            OracleCommand cmdReadQtnAttchmnt = new OracleCommand();
            cmdReadQtnAttchmnt.CommandText = strQueryReadQtnAttchmnt;
            cmdReadQtnAttchmnt.CommandType = CommandType.StoredProcedure;
            cmdReadQtnAttchmnt.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadQtnAttchmnt.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadQtnAttchmnt.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnAttchmnt);
            return dtDtl;
        }
        //End:EMP-0009
        // method for quatation by templatetype id
        public DataTable ReadQuotationByTemplateIdBysearch(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadAttch = "QUOTATION.SP_READ_QUATATION_TMLSEARCH";
            using (OracleCommand cmdReadAttch = new OracleCommand())
            {
                cmdReadAttch.CommandText = strQueryReadAttch;
                cmdReadAttch.CommandType = CommandType.StoredProcedure;

                cmdReadAttch.Parameters.Add("L_ID", OracleDbType.Int64).Value = objEntityQuotation.QuotationTemplateTypeId;
                cmdReadAttch.Parameters.Add("L_USERID", OracleDbType.Int64).Value = objEntityQuotation.User_Id;
                cmdReadAttch.Parameters.Add("L_CORPID", OracleDbType.Int64).Value = objEntityQuotation.CorpOffice_Id;
                cmdReadAttch.Parameters.Add("L_ORGID", OracleDbType.Int64).Value = objEntityQuotation.Organisation_Id;
                cmdReadAttch.Parameters.Add("L_CID", OracleDbType.Int64).Value = objEntityQuotation.CustomerId;

                cmdReadAttch.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadAttch = new DataTable();
                dtReadAttch = clsDataLayer.SelectDataTable(cmdReadAttch);
                return dtReadAttch;
            }
        }

        // method for quatation by templatetype id
        public DataTable ReadCutomerList(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadAttch = "QUOTATION.SP_READ_CUSTOMER_LOAD";
            using (OracleCommand cmdReadAttch = new OracleCommand())
            {
                cmdReadAttch.CommandText = strQueryReadAttch;
                cmdReadAttch.CommandType = CommandType.StoredProcedure;

                cmdReadAttch.Parameters.Add("Q_ORGID", OracleDbType.Int64).Value = objEntityQuotation.Organisation_Id;
                cmdReadAttch.Parameters.Add("Q_CORPID", OracleDbType.Int64).Value = objEntityQuotation.CorpOffice_Id;

                cmdReadAttch.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtReadAttch = new DataTable();
                dtReadAttch = clsDataLayer.SelectDataTable(cmdReadAttch);
                return dtReadAttch;
            }
        }
        //QCLD4 EVM0012
        public void InsertQuotationMailBackup(clsEntityLayerQuotation objEntityQuotation, clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList,clsEntityLayerQuotation InsertQuotationMailBackup)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddAdtnlMail = "QUOTATION.SP_INS_QTN_ADTNL_MAIL_BCK";
                    using (OracleCommand cmdAddAdtnlMail = new OracleCommand())
                    {
                        cmdAddAdtnlMail.CommandText = strQueryAddAdtnlMail;
                        cmdAddAdtnlMail.CommandType = CommandType.StoredProcedure;
                        cmdAddAdtnlMail.Parameters.Add("Q_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
                        cmdAddAdtnlMail.Parameters.Add("Q_TO_MAIL", OracleDbType.Varchar2).Value = InsertQuotationMailBackup.ToMail;
                        cmdAddAdtnlMail.Parameters.Add("Q_CC_MAIL", OracleDbType.Varchar2).Value = InsertQuotationMailBackup.CcMail;
                        cmdAddAdtnlMail.Parameters.Add("Q_BCC_MAIL", OracleDbType.Varchar2).Value = InsertQuotationMailBackup.BCcMail;
                        clsDataLayer.ExecuteNonQuery(cmdAddAdtnlMail);
                    }


                    string strQueryInsertDsgn = "QUOTATION.SP_INSERT_QTN_MAIL_BACKUP";
                    using (OracleCommand cmdInsertQtnMailAttachBkp = new OracleCommand())
                    {
                        cmdInsertQtnMailAttachBkp.Transaction = tran;
                        cmdInsertQtnMailAttachBkp.Connection = con;
                        cmdInsertQtnMailAttachBkp.CommandText = strQueryInsertDsgn;
                        cmdInsertQtnMailAttachBkp.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.QUOTATION_MAIL_ATTCH_BKP);
                        objEntCommon.CorporateID = objEntityQuotation.CorpOffice_Id;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityQuotation.QuotationId = Convert.ToInt32(strNextNum);

                        cmdInsertQtnMailAttachBkp.Parameters.Add("Q_QUOT_ML_BKP_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdInsertQtnMailAttachBkp.Parameters.Add("Q_LDQTBKP_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
                        cmdInsertQtnMailAttachBkp.Parameters.Add("Q_QUOT_ML_BKP_CONTENT", OracleDbType.Clob).Value = objEntityMail.Email_Content;
                        cmdInsertQtnMailAttachBkp.Parameters.Add("Q_QUOT_ML_BKP_SUBJECT", OracleDbType.Varchar2).Value = objEntityMail.Email_Subject;
                        cmdInsertQtnMailAttachBkp.ExecuteNonQuery();
                    }
                    string strQueryInsertInterviewCatDtl = "QUOTATION.SP_INSERT_QTN_MAIL_AT_BACKUP";
                    foreach (clsEntityMailAttachment objIntCatDtl in objEntityMailAttachList)
                    {
                        using (OracleCommand cmdInsertQtnMailAttachBkpDtl = new OracleCommand())
                        {
                            cmdInsertQtnMailAttachBkpDtl.Transaction = tran;
                            cmdInsertQtnMailAttachBkpDtl.Connection = con;
                            cmdInsertQtnMailAttachBkpDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertQtnMailAttachBkpDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertQtnMailAttachBkpDtl.Parameters.Add("Q_QUOT_ML_BKP_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdInsertQtnMailAttachBkpDtl.Parameters.Add("Q_LDMAILATT_FILENAME", OracleDbType.Varchar2).Value = objIntCatDtl.Email_File_Name;
                            cmdInsertQtnMailAttachBkpDtl.Parameters.Add("Q_LDMAILATT_FLNM_ACT", OracleDbType.Varchar2).Value = objIntCatDtl.Email_Real_Name;
                            cmdInsertQtnMailAttachBkpDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        public DataTable ReadQuotationAddtnMailBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_READ_QTN_ADDTN_MAIL_BACKUP";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_QUOT_ML_BKP_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }
        public DataTable ReadQuotationMailBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_READ_QTN_MAIL_BACKUP";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_QUOT_ML_BKP_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }
        public DataTable ReadQuotationMailAttachmntBckup(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_READ_QTN_MAIL_AT_BACKUP";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_QUOT_ML_BKP_ID", OracleDbType.Int32).Value = objEntityQuotation.BckupId;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }
        public void ChangeAttachStatus(clsEntityLayerQuotation objEntityQuotation, string[] strStsAttchIds)
        {
            try
            {

                foreach (string strEachStr in strStsAttchIds)
                {
                    if (strEachStr != "" && strEachStr != null)
                    {
                        string[] strEachStrSpit = strEachStr.Split(',');

                        if (strEachStrSpit[0] != "" && strEachStrSpit[1] != "")
                        {
                            int intDtlId = Convert.ToInt32(strEachStrSpit[0]);

                            string strQueryUpdateAdtnlMail = "QUOTATION.SP_CHNGE_QUOT_ATCHMNT_MAIL_STS";
                            OracleCommand cmdUpdateAdtnlMail = new OracleCommand();
                            cmdUpdateAdtnlMail.CommandText = strQueryUpdateAdtnlMail;
                            cmdUpdateAdtnlMail.CommandType = CommandType.StoredProcedure;

                            cmdUpdateAdtnlMail.CommandType = CommandType.StoredProcedure;
                            cmdUpdateAdtnlMail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                            cmdUpdateAdtnlMail.Parameters.Add("Q_ATTCHMNTDTL_ID", OracleDbType.Int32).Value = intDtlId;
                            cmdUpdateAdtnlMail.Parameters.Add("Q_STS_ID", OracleDbType.Int32).Value = strEachStrSpit[1];
                            clsDataLayer.ExecuteNonQuery(cmdUpdateAdtnlMail);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        // This Method will fetch Product  For autocompletion from WebService
        public DataTable ReadProductcatgryWebService(string strProductLikeName, int intListMode, clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadItems = "QUOTATION.SP_READ_PRDCT_CAT_WEBSERVICE";
            OracleCommand cmdReadItems = new OracleCommand();
            cmdReadItems.CommandText = strQueryReadItems;
            cmdReadItems.CommandType = CommandType.StoredProcedure;
            cmdReadItems.Parameters.Add("Q_PRDCTLIKENAME", OracleDbType.Varchar2).Value = strProductLikeName;
            cmdReadItems.Parameters.Add("Q_LISTMODE", OracleDbType.Int32).Value = intListMode;
            cmdReadItems.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
            cmdReadItems.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;

            if (objEntityQuotation.Divisionids != "")
            {
                cmdReadItems.Parameters.Add("Q_DIVSN_IDS", OracleDbType.Varchar2).Value = objEntityQuotation.Divisionids;
            }
            else
            {

                cmdReadItems.Parameters.Add("Q_DIVSN_IDS", OracleDbType.Varchar2).Value = "0";
            }

            cmdReadItems.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadItems);
            return dtProduct;
        }
        public DataTable ReadQuotationGrpDetailByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_READ_QTN_GRP_DTL_BY_QTNID";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnMail.Parameters.Add("Q_CORPID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }
        public DataTable ReadQuotationCatDetailByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_READ_QTN_CAT_DTL_BY_QTNID";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }
        public DataTable ReadQuotationGrpDetailBckupByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_RD_QTN_GRP_BCK_DTL_BY_QTNID";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }
        public DataTable ReadQuotationCatDetailBckupByQtnId(clsEntityLayerQuotation objEntityQuotation)
        {
            string strQueryReadQtnMail = "QUOTATION.SP_RD_QTN_CAT_BCK_DTL_BY_QTNID";
            OracleCommand cmdReadQtnMail = new OracleCommand();
            cmdReadQtnMail.CommandText = strQueryReadQtnMail;
            cmdReadQtnMail.CommandType = CommandType.StoredProcedure;
            cmdReadQtnMail.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
            cmdReadQtnMail.Parameters.Add("Q_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDtl = new DataTable();
            dtDtl = clsDataLayer.ExecuteReader(cmdReadQtnMail);
            return dtDtl;
        }



        //For list page



        public void ConfirmQuotationList(clsEntityLayerQuotation objEntityQuotation)
        {
            //In this method all are same as update method other than updating status to confirmed
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryUpdateQtn = "QUOTATION.SP_UPDATE_QUOTATION_LIST";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdUpdateQuotation = new OracleCommand(strQueryUpdateQtn, con))
                    {
                        cmdUpdateQuotation.Transaction = tran;

                        cmdUpdateQuotation.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQuotation.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;                     
                        cmdUpdateQuotation.Parameters.Add("Q_UPDUSERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQuotation.Parameters.Add("Q_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQuotation.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQuotation.ExecuteNonQuery();
                    }
                    string strQueryUpdateQtnStatus = "QUOTATION.SP_UPDATE_QUOTATION_STATUS";
                    using (OracleCommand cmdUpdateQtnStatus = new OracleCommand(strQueryUpdateQtnStatus, con))
                    {
                        cmdUpdateQtnStatus.Transaction = tran;

                        cmdUpdateQtnStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STATUS", OracleDbType.Int32).Value = 1;//confirmed
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdUpdateQtnStatus.Parameters.Add("Q_STS_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdUpdateQtnStatus.Parameters.Add("Q_ORGID", OracleDbType.Int32).Value = objEntityQuotation.Organisation_Id;
                        cmdUpdateQtnStatus.ExecuteNonQuery();
                    }

                    string strQueryUpdateleadStatus = "QUOTATION.SP_UPDATE_LEAD_STATUS";
                    using (OracleCommand cmdUpdateLeadStatus = new OracleCommand(strQueryUpdateleadStatus, con))
                    {
                        cmdUpdateLeadStatus.Transaction = tran;

                        cmdUpdateLeadStatus.CommandType = CommandType.StoredProcedure;
                        cmdUpdateLeadStatus.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdUpdateLeadStatus.Parameters.Add("L_STATUS", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Approval_Pending); //Quotation Approval Pending
                        cmdUpdateLeadStatus.Parameters.Add("L_AMOUNT", OracleDbType.Int32).Value = null;
                        cmdUpdateLeadStatus.ExecuteNonQuery();
                    }

                    string strQueryInsertleadStsTracking = "COMMON.SP_INS_LEAD_STS_TRACK";
                    using (OracleCommand cmdInsLeadStsTracking = new OracleCommand(strQueryInsertleadStsTracking, con))
                    {
                        cmdInsLeadStsTracking.Transaction = tran;

                        cmdInsLeadStsTracking.CommandType = CommandType.StoredProcedure;
                        cmdInsLeadStsTracking.Parameters.Add("C_LEADS_ID", OracleDbType.Int32).Value = objEntityQuotation.Lead_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_ID", OracleDbType.Int32).Value = Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Approval_Pending); //Quotation Approval Pending
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_USERID", OracleDbType.Int32).Value = objEntityQuotation.User_Id;
                        cmdInsLeadStsTracking.Parameters.Add("C_STS_TRACK_DATE", OracleDbType.Date).Value = objEntityQuotation.D_Date;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_RSN_ID", OracleDbType.Int32).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_LOSE_DSCRPTN", OracleDbType.Varchar2).Value = null;
                        cmdInsLeadStsTracking.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityQuotation.CorpOffice_Id;
                        cmdInsLeadStsTracking.ExecuteNonQuery();
                    }
                    string strQueryUpdateQtnRefNumbr = "QUOTATION.SP_UPDATE_QTN_REF_NUMBR";
                    using (OracleCommand cmdUpdateQtnRefNumbr = new OracleCommand(strQueryUpdateQtnRefNumbr, con))
                    {
                        cmdUpdateQtnRefNumbr.Transaction = tran;
                        cmdUpdateQtnRefNumbr.CommandType = CommandType.StoredProcedure;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_ID", OracleDbType.Int32).Value = objEntityQuotation.QuotationId;
                        cmdUpdateQtnRefNumbr.Parameters.Add("Q_REFNUM", OracleDbType.Varchar2).Value = objEntityQuotation.QuotationRefNumbr;
                        cmdUpdateQtnRefNumbr.ExecuteNonQuery();
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












    }

}