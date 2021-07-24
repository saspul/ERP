using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_PMS;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_FMS;

namespace DL_Compzit.DataLayer_PMS
{
    public class clsDataLayerPurchaseOrder
    {

        public DataTable ReadModeOfSupply(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_MODE_OF_SUPPLY";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadProjects(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_PROJECTS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            cmdPurchase.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityPurchaseOrder.DivisionId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }
        public DataTable ReadWarehouse(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_WAREHOUSE";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_PROJECTID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ProjectId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadVendor(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_VENDORS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_SEARCHSTRING", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.CommonSearchTerm;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }
        public DataTable ReadVendorCntctPrsn(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_VENDORCNTCTPRSN";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_VENDORID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadDocumntWrkflow(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_DOCUMNT_WRKFLOW";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadDivision(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_DIVISION";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }
        public DataTable ReadCustomers(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_CUSTOMERS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_DIVSNID", OracleDbType.Int32).Value = objEntityPurchaseOrder.DivisionId;
            cmdPurchase.Parameters.Add("P_PROJECTID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ProjectId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }
        public DataTable ReadPOCntctPrsn(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_POCONTACTPRSNS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_CUSTID", OracleDbType.Int32).Value = objEntityPurchaseOrder.RqstdCustomerId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadProducts(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_PRODUCTS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_SEARCHSTRING", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.CommonSearchTerm;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadVehicles(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_VEHICLES";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_SEARCHSTRING", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.CommonSearchTerm;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadEmployeeDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_EMPLOYEEDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.EmployeeId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadProductTaxDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.READ_PRODUCT_TAX_DTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_PRDCTID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ProductId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }


        public void InsertPurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder, List<clsEntityPurchaseOrder> objPurchaseProductList, List<clsEntityPurchaseOrder> objPurchaseChrgHeadList, List<clsEntityPurchaseOrder> objPurchaseAttchmntList, List<clsEntitySupplierContact> objEnitytSupplierCntctList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQuery = "PMS_PURCHASE_ORDER.SP_INSERT_PURCHASE_ORDER";
                    using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                    {
                        cmdPurchase.Transaction = tran;
                        cmdPurchase.CommandType = CommandType.StoredProcedure;

                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        clsDataLayer objDataLayer = new clsDataLayer();
                        objEntityCommon.CorporateID = objEntityPurchaseOrder.CorpId;
                        objEntityCommon.Organisation_Id = objEntityPurchaseOrder.OrgId;
                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_MASTER);

                        string strNextId = objDataLayer.ReadNextNumber(objEntityCommon);
                        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strNextId);
                        string strRefNextId = objDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);
                        objEntityPurchaseOrder.PurchsOrdrRefrncNo = strRefNextId;

                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                        string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                        DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);

                        DataTable dtFormate = objDataLayer.ReadRefFormat(objEntityCommon);

                        int intCorpId = objEntityPurchaseOrder.CorpId;
                        int intOrgId = objEntityPurchaseOrder.OrgId;
                        int intUsrId = objEntityPurchaseOrder.UserId;
                        int DtYear = dtCurrentDate.Year;
                        int DtMonth = dtCurrentDate.Month;
                        string dtyy = dtCurrentDate.ToString("yy");

                        string RefFormat = "";
                        string strRealFormat = "";
                        if (dtFormate.Rows.Count > 0)
                        {
                            if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                            {
                                RefFormat = dtFormate.Rows[0]["REF_FORMATE"].ToString();

                                string[] arrReferenceSplit = RefFormat.Split('*');
                                if (RefFormat == "" || RefFormat == null)
                                {
                                    strRealFormat = strRefNextId;
                                }
                                else
                                {
                                    strRealFormat = RefFormat.ToString();
                                    if (strRealFormat.Contains("#ORG#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#ORG#", intOrgId.ToString());
                                    }
                                    if (strRealFormat.Contains("#COR#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#COR#", intCorpId.ToString());
                                    }

                                    if (strRealFormat.Contains("#USR#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#USR#", intUsrId.ToString());
                                    }
                                    //2019
                                    if (strRealFormat.Contains("#YER#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                                    }
                                    //19
                                    if (strRealFormat.Contains("#YY#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                                    }
                                    if (strRealFormat.Contains("#MON#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                                    }
                                    if (strRealFormat.Contains("#NUM#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#NUM#", strRefNextId);
                                    }
                                    else
                                    {
                                        strRealFormat = strRealFormat + "/" + strRefNextId;
                                    }
                                    strRealFormat = strRealFormat.Replace("#", "");
                                }
                                objEntityPurchaseOrder.PurchsOrdrRefrncNo = strRealFormat;
                            }
                        }
                        else
                        {
                            objEntityPurchaseOrder.PurchsOrdrRefrncNo = strRefNextId;
                        }

                        cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                        cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
                        cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
                        cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_TYPE", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchaseOrderType;
                        cmdPurchase.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WrkFlowId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_REF", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.PurchsOrdrRefrncNo;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DATE", OracleDbType.Date).Value = objEntityPurchaseOrder.PurchsOrdrDate;
                        if (objEntityPurchaseOrder.ExpctdDelivryDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRYDT", OracleDbType.Date).Value = objEntityPurchaseOrder.ExpctdDelivryDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRYDT", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_CLIENTNAME", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.ClientName;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_ENDCSTMRNAME", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.EndCustmrName;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRYTO_STS", OracleDbType.Int32).Value = objEntityPurchaseOrder.DeliverToSts;
                        if (objEntityPurchaseOrder.WarehouseId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_WRHS_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WarehouseId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_WRHS_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRLCTN_WRHS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.WrhsDeliveryLocatn;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRLCTN_PRJCT", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.PrjctDeliveryLocatn;

                        cmdPurchase.Parameters.Add("P_PRCHSORDR_QTNNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.QuotatnRefNo;
                        if (objEntityPurchaseOrder.QuotatnDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_QTNDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.QuotatnDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_QTNDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_SUPLIR_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_REFNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorRefNo;
                        if (objEntityPurchaseOrder.VendorCntctPrsnId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_CONTCT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorCntctPrsnId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_CONTCT_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_CONTCTNAME", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorContactName;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_ADDRSS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorAddress;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_MOBILE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorMobile;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_PHONE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorPhone;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_FAX", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorFax;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_EMAIL", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorEmail;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_FUTUREUSE", OracleDbType.Int32).Value = objEntityPurchaseOrder.UseVendorDtlFuture;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_COMMNTS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorComments;
                        cmdPurchase.Parameters.Add("P_CPRDIV_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.DivisionId;
                        if (objEntityPurchaseOrder.ProjectId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_PROJECT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ProjectId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PROJECT_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityPurchaseOrder.RqstdCustomerId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_CSTMR_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.RqstdCustomerId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_CSTMR_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityPurchaseOrder.RqrmntDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_REQRMNTDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.RqrmntDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_REQRMNTDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_MODOFSUPPLY", OracleDbType.Int32).Value = objEntityPurchaseOrder.ModeOfSupply;
                        if (objEntityPurchaseOrder.POCntctPrsnId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_CONTACTPRSN_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.POCntctPrsnId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_CONTACTPRSN_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_MOBILE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.POMobileNo;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_REQSTNNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.POReqstnNo;
                        if (objEntityPurchaseOrder.POReqstnDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_REQSTNDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.POReqstnDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_REQSTNDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objEntityPurchaseOrder.ApprovalDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_APPRVLDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.ApprovalDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_APPRVLDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PRIORTY", OracleDbType.Int32).Value = objEntityPurchaseOrder.POPriority;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_JOBCODE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.JobCode;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_JOBDESCRPTN", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.JobDescriptn;
                        cmdPurchase.Parameters.Add("P_CRNCMST_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CurrencyId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_EXCHNG_RATE", OracleDbType.Decimal).Value = objEntityPurchaseOrder.ExchngRate;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_AMNT_EXCNG", OracleDbType.Decimal).Value = objEntityPurchaseOrder.NetAmntWthoutExchngRt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_GROSS_TOTAL", OracleDbType.Decimal).Value = objEntityPurchaseOrder.GrossTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_TAX_TOTAL", OracleDbType.Decimal).Value = objEntityPurchaseOrder.TaxTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DISCOUNT", OracleDbType.Decimal).Value = objEntityPurchaseOrder.DiscntTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_NET_TOTAL", OracleDbType.Decimal).Value = objEntityPurchaseOrder.NetTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PAYMT_TERM", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.PaymntTerms;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_TERM_CNDTNS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.TermsAndCondtns;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_FRGHT_TERM", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.FreightTerms;
                        cmdPurchase.ExecuteNonQuery();
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objPurchaseProductList)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_PRODUCT_DTLS";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_QNTY", OracleDbType.Decimal).Value = objEntityDtl.Qnty;
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_RATE", OracleDbType.Decimal).Value = objEntityDtl.Price;
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TOTLAMNT", OracleDbType.Decimal).Value = objEntityDtl.ProductTotalAmnt;
                            if (objEntityPurchaseOrder.PurchaseOrderType == 1)
                            {
                                cmdPurchase.Parameters.Add("P_PRDT_ID", OracleDbType.Int32).Value = objEntityDtl.ProductId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTPCNT", OracleDbType.Decimal).Value = objEntityDtl.DiscntPrcnt;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTAMT", OracleDbType.Decimal).Value = objEntityDtl.DiscntAmnt;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXID", OracleDbType.Int32).Value = objEntityDtl.TaxId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXPRCNT", OracleDbType.Decimal).Value = objEntityDtl.TaxPrcnt;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_PRDT_ID", OracleDbType.Int32).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTPCNT", OracleDbType.Decimal).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTAMT", OracleDbType.Decimal).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXID", OracleDbType.Int32).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXPRCNT", OracleDbType.Decimal).Value = DBNull.Value;
                            }

                            if (objEntityPurchaseOrder.PurchaseOrderType == 2)
                            {
                                cmdPurchase.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = objEntityDtl.VehicleId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = objEntityDtl.StartDate;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = objEntityDtl.EndDate;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = DBNull.Value;
                            }

                            if (objEntityPurchaseOrder.PurchaseOrderType == 2 || objEntityPurchaseOrder.PurchaseOrderType == 3)
                            {
                                cmdPurchase.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityDtl.EmployeeId;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                            }

                            if (objEntityPurchaseOrder.PurchaseOrderType == 3)
                            {
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_PNRNO", OracleDbType.Varchar2).Value = objEntityDtl.PNRNo;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SECTOR", OracleDbType.Varchar2).Value = objEntityDtl.Sector;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TRVLDATE", OracleDbType.Date).Value = objEntityDtl.TravelDate;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_PNRNO", OracleDbType.Varchar2).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SECTOR", OracleDbType.Varchar2).Value = DBNull.Value;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TRVLDATE", OracleDbType.Date).Value = DBNull.Value;
                            }
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_REMARKS", OracleDbType.Varchar2).Value = objEntityDtl.Remarks;
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SLNO", OracleDbType.Int32).Value = objEntityDtl.SLNo;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objPurchaseChrgHeadList)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_CHARGE_HEADS";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                            cmdPurchase.Parameters.Add("P_CHRGHD_ID", OracleDbType.Int32).Value = objEntityDtl.ChrgHeadId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_CHRGAMNT", OracleDbType.Decimal).Value = objEntityDtl.ChrgHeadAmnt;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objPurchaseAttchmntList)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_ATTCHMNTS";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_FILE_NAME", OracleDbType.Varchar2).Value = objEntityDtl.FileName;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_FILE_ACTNM", OracleDbType.Varchar2).Value = objEntityDtl.ActualFileName;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_DESCRPTN", OracleDbType.Varchar2).Value = objEntityDtl.Descrptn;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    if (objEntityPurchaseOrder.UseVendorDtlFuture == 1)
                    {
                        foreach (clsEntitySupplierContact objSubDetail in objEnitytSupplierCntctList)
                        {
                            string strQuerySubDetails = "PMS_PURCHASE_ORDER.SP_INSERT_SUPPLIER_CONTACT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("L_SUPLIER_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorId;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTNAME", OracleDbType.Varchar2).Value = objSubDetail.ContactName;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTADDRESS", OracleDbType.Varchar2).Value = objSubDetail.ContactAddress;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTMOBILE", OracleDbType.Varchar2).Value = objSubDetail.ContactMobile;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTPHONE", OracleDbType.Varchar2).Value = objSubDetail.ContactPhone;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTWEBSITE", OracleDbType.Varchar2).Value = objSubDetail.ContactWebsite;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTEMAIL", OracleDbType.Varchar2).Value = objSubDetail.ContactEmail;
                                cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public DataTable ReadPurchaseOrderList(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_PURCHASE_ORDER_LIST";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_SUPLIR_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorId;
            if (objEntityPurchaseOrder.StartDate != DateTime.MinValue)
            {
                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.StartDate;
            }
            else
            {
                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = null;
            }
            if (objEntityPurchaseOrder.EndDate != DateTime.MinValue)
            {
                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.EndDate;
            }
            else
            {
                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = null;
            }
            cmdPurchase.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WrkFlowId;
            cmdPurchase.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPurchaseOrder.Status;
            cmdPurchase.Parameters.Add("P_CNCLSTS", OracleDbType.Int32).Value = objEntityPurchaseOrder.CancelStatus;
            cmdPurchase.Parameters.Add("P_PRCHSORDR_TYPE", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchaseOrderType;
            //----------------------------------------Pageination--------------------------------------
            cmdPurchase.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.CommonSearchTerm;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_DATE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchDate;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_REFNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchRef;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_POTYPE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchPOType;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_VENDOR", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchVendor;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_DOCMNT", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchWrkflw;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_DLVRYDT", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchDelvryDt;
            cmdPurchase.Parameters.Add("P_SEARCH_PRCHSORDR_AMNT", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.SearchAmnt;
            cmdPurchase.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrderColumn;
            cmdPurchase.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrderMethod;
            cmdPurchase.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityPurchaseOrder.PageMaxSize;
            cmdPurchase.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityPurchaseOrder.PageNumber;
            //----------------------------------------Pageination--------------------------------------
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void CancelPurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_CANCEL_PURCHASE_ORDER";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_CNCLREASON", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.CancelReason;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }

        public DataTable ReadPurchaseOrderById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_PURCHS_ORDER_BYID";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }
        public DataTable ReadPurchaseOrderDetailsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_PURCHS_ORDER_DTLS_BYID";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void UpdatePurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder, List<clsEntityPurchaseOrder> objPurchaseProductList, List<clsEntityPurchaseOrder> objPurchaseProductDeleteList, List<clsEntityPurchaseOrder> objPurchaseChrgHeadList, List<clsEntityPurchaseOrder> objPurchaseAttchmntList, List<clsEntityPurchaseOrder> objPurchaseAttchmntDeleteList, List<clsEntitySupplierContact> objEnitytSupplierCntctList, List<clsEntityApprovalConsole> objEntityApprvlCnslList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQuery = "PMS_PURCHASE_ORDER.SP_UPDATE_PURCHASE_ORDER";
                    using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                    {
                        cmdPurchase.Transaction = tran;
                        cmdPurchase.CommandType = CommandType.StoredProcedure;

                        cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                        cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                        cmdPurchase.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WrkFlowId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DATE", OracleDbType.Date).Value = objEntityPurchaseOrder.PurchsOrdrDate;
                        if (objEntityPurchaseOrder.ExpctdDelivryDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRYDT", OracleDbType.Date).Value = objEntityPurchaseOrder.ExpctdDelivryDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRYDT", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_CLIENTNAME", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.ClientName;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_ENDCSTMRNAME", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.EndCustmrName;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRYTO_STS", OracleDbType.Int32).Value = objEntityPurchaseOrder.DeliverToSts;
                        if (objEntityPurchaseOrder.WarehouseId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_WRHS_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WarehouseId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_WRHS_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRLCTN_WRHS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.WrhsDeliveryLocatn;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DLVRLCTN_PRJCT", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.PrjctDeliveryLocatn;

                        cmdPurchase.Parameters.Add("P_PRCHSORDR_QTNNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.QuotatnRefNo;
                        if (objEntityPurchaseOrder.QuotatnDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_QTNDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.QuotatnDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_QTNDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_SUPLIR_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_REFNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorRefNo;
                        if (objEntityPurchaseOrder.VendorCntctPrsnId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_CONTCT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorCntctPrsnId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_CONTCT_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_CONTCTNAME", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorContactName;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_ADDRSS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorAddress;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_MOBILE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorMobile;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_PHONE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorPhone;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_FAX", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorFax;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_EMAIL", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorEmail;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_FUTUREUSE", OracleDbType.Int32).Value = objEntityPurchaseOrder.UseVendorDtlFuture;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_VENDOR_COMMNTS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.VendorComments;
                        cmdPurchase.Parameters.Add("P_CPRDIV_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.DivisionId;
                        if (objEntityPurchaseOrder.ProjectId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_PROJECT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ProjectId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PROJECT_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityPurchaseOrder.RqstdCustomerId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_CSTMR_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.RqstdCustomerId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_CSTMR_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityPurchaseOrder.RqrmntDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_REQRMNTDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.RqrmntDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_REQRMNTDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_MODOFSUPPLY", OracleDbType.Int32).Value = objEntityPurchaseOrder.ModeOfSupply;
                        if (objEntityPurchaseOrder.POCntctPrsnId != 0)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_CONTACTPRSN_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.POCntctPrsnId;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_CONTACTPRSN_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_MOBILE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.POMobileNo;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_REQSTNNO", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.POReqstnNo;
                        if (objEntityPurchaseOrder.POReqstnDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_REQSTNDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.POReqstnDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_REQSTNDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objEntityPurchaseOrder.ApprovalDate != DateTime.MinValue)
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_APPRVLDATE", OracleDbType.Date).Value = objEntityPurchaseOrder.ApprovalDate;
                        }
                        else
                        {
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_PO_APPRVLDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PRIORTY", OracleDbType.Int32).Value = objEntityPurchaseOrder.POPriority;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_JOBCODE", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.JobCode;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_JOBDESCRPTN", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.JobDescriptn;
                        cmdPurchase.Parameters.Add("P_CRNCMST_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CurrencyId;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_EXCHNG_RATE", OracleDbType.Decimal).Value = objEntityPurchaseOrder.ExchngRate;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_AMNT_EXCNG", OracleDbType.Decimal).Value = objEntityPurchaseOrder.NetAmntWthoutExchngRt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_GROSS_TOTAL", OracleDbType.Decimal).Value = objEntityPurchaseOrder.GrossTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_TAX_TOTAL", OracleDbType.Decimal).Value = objEntityPurchaseOrder.TaxTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_DISCOUNT", OracleDbType.Decimal).Value = objEntityPurchaseOrder.DiscntTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_NET_TOTAL", OracleDbType.Decimal).Value = objEntityPurchaseOrder.NetTotalAmnt;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_PAYMT_TERM", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.PaymntTerms;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_TERM_CNDTNS", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.TermsAndCondtns;
                        cmdPurchase.Parameters.Add("P_PRCHSORDR_FRGHT_TERM", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.FreightTerms;
                        cmdPurchase.ExecuteNonQuery();
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objPurchaseProductList)
                    {
                        if (objEntityDtl.DtlId != 0)
                        {
                            string strQueryDtl = "PMS_PURCHASE_ORDER.SP_UPDATE_PRODUCT_DTLS";
                            using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                            {
                                cmdPurchase.Transaction = tran;
                                cmdPurchase.CommandType = CommandType.StoredProcedure;
                                cmdPurchase.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityDtl.DtlId;
                                cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_QNTY", OracleDbType.Decimal).Value = objEntityDtl.Qnty;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_RATE", OracleDbType.Decimal).Value = objEntityDtl.Price;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TOTLAMNT", OracleDbType.Decimal).Value = objEntityDtl.ProductTotalAmnt;
                                if (objEntityPurchaseOrder.PurchaseOrderType == 1)
                                {
                                    cmdPurchase.Parameters.Add("P_PRDT_ID", OracleDbType.Int32).Value = objEntityDtl.ProductId;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTPCNT", OracleDbType.Decimal).Value = objEntityDtl.DiscntPrcnt;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTAMT", OracleDbType.Decimal).Value = objEntityDtl.DiscntAmnt;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXID", OracleDbType.Int32).Value = objEntityDtl.TaxId;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXPRCNT", OracleDbType.Decimal).Value = objEntityDtl.TaxPrcnt;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_PRDT_ID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTPCNT", OracleDbType.Decimal).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTAMT", OracleDbType.Decimal).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXPRCNT", OracleDbType.Decimal).Value = DBNull.Value;
                                }

                                if (objEntityPurchaseOrder.PurchaseOrderType == 2)
                                {
                                    cmdPurchase.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = objEntityDtl.VehicleId;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = objEntityDtl.StartDate;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = objEntityDtl.EndDate;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = DBNull.Value;
                                }

                                if (objEntityPurchaseOrder.PurchaseOrderType == 2 || objEntityPurchaseOrder.PurchaseOrderType == 3)
                                {
                                    cmdPurchase.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityDtl.EmployeeId;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                                }

                                if (objEntityPurchaseOrder.PurchaseOrderType == 3)
                                {
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_PNRNO", OracleDbType.Varchar2).Value = objEntityDtl.PNRNo;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SECTOR", OracleDbType.Varchar2).Value = objEntityDtl.Sector;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TRVLDATE", OracleDbType.Date).Value = objEntityDtl.TravelDate;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_PNRNO", OracleDbType.Varchar2).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SECTOR", OracleDbType.Varchar2).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TRVLDATE", OracleDbType.Date).Value = DBNull.Value;
                                }
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_REMARKS", OracleDbType.Varchar2).Value = objEntityDtl.Remarks;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SLNO", OracleDbType.Int32).Value = objEntityDtl.SLNo;
                                cmdPurchase.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_PRODUCT_DTLS";
                            using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                            {
                                cmdPurchase.Transaction = tran;
                                cmdPurchase.CommandType = CommandType.StoredProcedure;
                                cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_QNTY", OracleDbType.Decimal).Value = objEntityDtl.Qnty;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_RATE", OracleDbType.Decimal).Value = objEntityDtl.Price;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TOTLAMNT", OracleDbType.Decimal).Value = objEntityDtl.ProductTotalAmnt;
                                if (objEntityPurchaseOrder.PurchaseOrderType == 1)
                                {
                                    cmdPurchase.Parameters.Add("P_PRDT_ID", OracleDbType.Int32).Value = objEntityDtl.ProductId;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTPCNT", OracleDbType.Decimal).Value = objEntityDtl.DiscntPrcnt;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTAMT", OracleDbType.Decimal).Value = objEntityDtl.DiscntAmnt;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXID", OracleDbType.Int32).Value = objEntityDtl.TaxId;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXPRCNT", OracleDbType.Decimal).Value = objEntityDtl.TaxPrcnt;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_PRDT_ID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTPCNT", OracleDbType.Decimal).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_DISCNTAMT", OracleDbType.Decimal).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TAXPRCNT", OracleDbType.Decimal).Value = DBNull.Value;
                                }

                                if (objEntityPurchaseOrder.PurchaseOrderType == 2)
                                {
                                    cmdPurchase.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = objEntityDtl.VehicleId;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = objEntityDtl.StartDate;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = objEntityDtl.EndDate;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_VHCL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_STRTDATE", OracleDbType.Date).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_ENDDATE", OracleDbType.Date).Value = DBNull.Value;
                                }

                                if (objEntityPurchaseOrder.PurchaseOrderType == 2 || objEntityPurchaseOrder.PurchaseOrderType == 3)
                                {
                                    cmdPurchase.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityDtl.EmployeeId;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = DBNull.Value;
                                }

                                if (objEntityPurchaseOrder.PurchaseOrderType == 3)
                                {
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_PNRNO", OracleDbType.Varchar2).Value = objEntityDtl.PNRNo;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SECTOR", OracleDbType.Varchar2).Value = objEntityDtl.Sector;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TRVLDATE", OracleDbType.Date).Value = objEntityDtl.TravelDate;
                                }
                                else
                                {
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_PNRNO", OracleDbType.Varchar2).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SECTOR", OracleDbType.Varchar2).Value = DBNull.Value;
                                    cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_TRVLDATE", OracleDbType.Date).Value = DBNull.Value;
                                }
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_REMARKS", OracleDbType.Varchar2).Value = objEntityDtl.Remarks;
                                cmdPurchase.Parameters.Add("P_PRCHSORDR_DTL_SLNO", OracleDbType.Int32).Value = objEntityDtl.SLNo;
                                cmdPurchase.ExecuteNonQuery();
                            }

                        }
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtlDelete in objPurchaseProductDeleteList)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_CANCEL_PRODUCT_DTLS_ORATTCH";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityDtlDelete.DtlId;
                            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                            cmdPurchase.Parameters.Add("P_MODE", OracleDbType.Int32).Value = 0;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    string strQueryDeleteDtl = "PMS_PURCHASE_ORDER.SP_DELETE_CHRGHEAD";
                    using (OracleCommand cmdPurchase = new OracleCommand(strQueryDeleteDtl, con))
                    {
                        cmdPurchase.Transaction = tran;
                        cmdPurchase.CommandType = CommandType.StoredProcedure;
                        cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                        cmdPurchase.Parameters.Add("P_MODE", OracleDbType.Int32).Value = 0;
                        cmdPurchase.ExecuteNonQuery();
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objPurchaseChrgHeadList)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_CHARGE_HEADS";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                            cmdPurchase.Parameters.Add("P_CHRGHD_ID", OracleDbType.Int32).Value = objEntityDtl.ChrgHeadId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDR_CHRGAMNT", OracleDbType.Decimal).Value = objEntityDtl.ChrgHeadAmnt;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objPurchaseAttchmntList)
                    {
                        if (objEntityDtl.DtlId != 0)
                        {
                            string strQueryDtl = "PMS_PURCHASE_ORDER.SP_UPDATE_ATTCHMNTS";
                            using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                            {
                                cmdPurchase.Transaction = tran;
                                cmdPurchase.CommandType = CommandType.StoredProcedure;
                                cmdPurchase.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityDtl.DtlId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_DESCRPTN", OracleDbType.Varchar2).Value = objEntityDtl.Descrptn;
                                cmdPurchase.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_ATTCHMNTS";
                            using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                            {
                                cmdPurchase.Transaction = tran;
                                cmdPurchase.CommandType = CommandType.StoredProcedure;
                                cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                                cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_FILE_NAME", OracleDbType.Varchar2).Value = objEntityDtl.FileName;
                                cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_FILE_ACTNM", OracleDbType.Varchar2).Value = objEntityDtl.ActualFileName;
                                cmdPurchase.Parameters.Add("P_PRCHSORDRATCH_DESCRPTN", OracleDbType.Varchar2).Value = objEntityDtl.Descrptn;
                                cmdPurchase.ExecuteNonQuery();
                            }
                        }
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtlDelete in objPurchaseAttchmntDeleteList)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_CANCEL_PRODUCT_DTLS_ORATTCH";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityDtlDelete.DtlId;
                            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                            cmdPurchase.Parameters.Add("P_MODE", OracleDbType.Int32).Value = 1;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    //Confirm
                    if (objEntityPurchaseOrder.Status == 1)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_CONFIRM_REOPEN_PRCHS_ORDER";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                            cmdPurchase.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPurchaseOrder.Status;
                            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                            cmdPurchase.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WrkFlowId;
                            cmdPurchase.ExecuteNonQuery();
                        }

                        foreach (clsEntityApprovalConsole objSubDetail in objEntityApprvlCnslList)
                        {
                            string strQuerySubDetails = "PMS_APPROVALCONSOLE.SP_INSERT_APPROVAL_CONSOLE";
                            using (OracleCommand cmdApprvlCnsl = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdApprvlCnsl.Transaction = tran;
                                cmdApprvlCnsl.CommandType = CommandType.StoredProcedure;
                                cmdApprvlCnsl.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
                                cmdApprvlCnsl.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
                                cmdApprvlCnsl.Parameters.Add("P_NEXT_USER_ID", OracleDbType.Int32).Value = objSubDetail.EmployeeId;
                                cmdApprvlCnsl.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = 1;
                                cmdApprvlCnsl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                                cmdApprvlCnsl.Parameters.Add("P_APRVL_USR_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                                cmdApprvlCnsl.Parameters.Add("P_LEVEL", OracleDbType.Int32).Value = objSubDetail.Level;
                                cmdApprvlCnsl.ExecuteNonQuery();
                            }
                        }
                    }

                    string strQueryDelDetails = "PMS_PURCHASE_ORDER.SP_DELETE_SUPPLIER_CONTACT";
                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryDelDetails, con))
                    {
                        cmdAddSubDetail.Transaction = tran;
                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                        cmdAddSubDetail.ExecuteNonQuery();
                    }

                    if (objEntityPurchaseOrder.UseVendorDtlFuture == 1)
                    {

                        foreach (clsEntitySupplierContact objSubDetail in objEnitytSupplierCntctList)
                        {
                            string strQuerySubDetails = "PMS_PURCHASE_ORDER.SP_INSERT_SUPPLIER_CONTACT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("L_SUPLIER_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorId;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTNAME", OracleDbType.Varchar2).Value = objSubDetail.ContactName;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTADDRESS", OracleDbType.Varchar2).Value = objSubDetail.ContactAddress;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTMOBILE", OracleDbType.Varchar2).Value = objSubDetail.ContactMobile;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTPHONE", OracleDbType.Varchar2).Value = objSubDetail.ContactPhone;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTWEBSITE", OracleDbType.Varchar2).Value = objSubDetail.ContactWebsite;
                                cmdAddSubDetail.Parameters.Add("L_CONTACTEMAIL", OracleDbType.Varchar2).Value = objSubDetail.ContactEmail;
                                cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void ReopenPurchaseOrder(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_CONFIRM_REOPEN_PRCHS_ORDER";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityPurchaseOrder.Status;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            cmdPurchase.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WrkFlowId;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }

        public DataTable ReadChargeHeads(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_CHARGEHEADS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdPurchase.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPurchaseOrder.OrgId;
            cmdPurchase.Parameters.Add("P_CHRGHDID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ChrgHeadId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadPurchaseOrderChrgHeadsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_CHARGEHEADS_BYID";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public DataTable ReadPurchaseOrderAttachmntsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_ATTACHMENTS_BYID";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        //--------NOTE--------
        public DataTable ReadNoteDetails(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_NOTEDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            cmdPurchase.Parameters.Add("P_REPLYSTS", OracleDbType.Int32).Value = objEntityPurchaseOrder.ReplySts;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void InsertNote(clsEntityPurchaseOrder objEntityPurchaseOrder, List<clsEntityPurchaseOrder> objEntityPurchaseOrderAttchmnts)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityPurchaseOrder.ReplySts == 1)
                    {
                        string strQuery = "PMS_PURCHASE_ORDER.SP_UPDATE_REPLYNOTE";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_NOTEID", OracleDbType.Int32).Value = objEntityPurchaseOrder.NoteId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRNOTE_REPLY_MSG", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.NoteMsg;
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string strQuery = "PMS_PURCHASE_ORDER.SP_INSERT_NOTE";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQuery, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
                            cmdPurchase.Parameters.Add("P_TO_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.EmployeeId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRNOTE_MSG", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.NoteMsg;
                            cmdPurchase.Parameters.Add("P_FROM_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
                            cmdPurchase.Parameters.Add("P_NOTEID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdPurchase.ExecuteNonQuery();
                            string strReturn = cmdPurchase.Parameters["P_NOTEID"].Value.ToString();
                            objEntityPurchaseOrder.NoteId = Convert.ToInt32(strReturn);
                        }
                    }

                    foreach (clsEntityPurchaseOrder objEntityDtl in objEntityPurchaseOrderAttchmnts)
                    {
                        string strQueryDtl = "PMS_PURCHASE_ORDER.SP_INSERT_NOTE_ATTCH";
                        using (OracleCommand cmdPurchase = new OracleCommand(strQueryDtl, con))
                        {
                            cmdPurchase.Transaction = tran;
                            cmdPurchase.CommandType = CommandType.StoredProcedure;
                            cmdPurchase.Parameters.Add("P_NOTEID", OracleDbType.Int32).Value = objEntityPurchaseOrder.NoteId;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRATCHNT_FILENM", OracleDbType.Varchar2).Value = objEntityDtl.FileName;
                            cmdPurchase.Parameters.Add("P_PRCHSORDRATCHNT_FILEACTNM", OracleDbType.Varchar2).Value = objEntityDtl.ActualFileName;
                            if (objEntityPurchaseOrder.ReplySts == 1)
                            {
                                cmdPurchase.Parameters.Add("P_PRCHSORDRATCHNT_TYPE", OracleDbType.Int32).Value = 1;
                            }
                            else
                            {
                                cmdPurchase.Parameters.Add("P_PRCHSORDRATCHNT_TYPE", OracleDbType.Int32).Value = 0;
                            }
                            cmdPurchase.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataTable ReadContactDtlsById(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_CONTACTDTLS_BYID";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPurchaseOrder.ModeOfSupply;
            if (objEntityPurchaseOrder.ModeOfSupply == 0)
            {
                cmdPurchase.Parameters.Add("P_CONTACT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.VendorCntctPrsnId;
            }
            else
            {
                cmdPurchase.Parameters.Add("P_CONTACT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.POCntctPrsnId;
            }
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        //--------STATUS--------
        public DataTable ReadStatusDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_APPROVALCONSOLE.SP_READ_STATUS_DTLS";
            OracleCommand cmdApprvlCnsl = new OracleCommand();
            cmdApprvlCnsl.CommandText = strQuery;
            cmdApprvlCnsl.CommandType = CommandType.StoredProcedure;
            cmdApprvlCnsl.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.CorpId;
            cmdApprvlCnsl.Parameters.Add("P_PRCHSORDRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdApprvlCnsl.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = 1;
            cmdApprvlCnsl.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdApprvlCnsl);
            return dt;
        }

        //--------COMMENTS--------
        public DataTable ReadCommentDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_COMMENTDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

        public void InsertComments(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_INSERT_COMMENTDTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPurchaseOrder.PurchsOrdrId;
            cmdPurchase.Parameters.Add("P_PRCHSORDRCMNT_VISBLSTS", OracleDbType.Int32).Value = objEntityPurchaseOrder.VisibleSts;
            cmdPurchase.Parameters.Add("P_PRCHSORDRCMNT_COMMENT", OracleDbType.Varchar2).Value = objEntityPurchaseOrder.Comment;
            cmdPurchase.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPurchaseOrder.UserId;
            clsDataLayer.ExecuteNonQuery(cmdPurchase);
        }


        public DataTable ReadLocationDtls(clsEntityPurchaseOrder objEntityPurchaseOrder)
        {
            string strQuery = "PMS_PURCHASE_ORDER.SP_READ_LOCATION_DTLS";
            OracleCommand cmdPurchase = new OracleCommand();
            cmdPurchase.CommandText = strQuery;
            cmdPurchase.CommandType = CommandType.StoredProcedure;
            cmdPurchase.Parameters.Add("P_MODE", OracleDbType.Int32).Value = objEntityPurchaseOrder.DeliverToSts;
            cmdPurchase.Parameters.Add("P_WRHSID", OracleDbType.Int32).Value = objEntityPurchaseOrder.WarehouseId;
            cmdPurchase.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityPurchaseOrder.ProjectId;
            cmdPurchase.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dt = clsDataLayer.ExecuteReader(cmdPurchase);
            return dt;
        }

    }
}
