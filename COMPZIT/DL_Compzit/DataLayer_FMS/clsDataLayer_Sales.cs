using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using System.Globalization;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_Sales
    {
        clsDataLayer objDatatLayer = new clsDataLayer();
        public DataTable ReadCustomerLedger(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_CUSTOMER_LEDGER";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_TYPE", OracleDbType.Varchar2).Value = ObjEntitySales.LedgerType;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }


        public void ConfirmExpenseDetls(clsEntitySales ObjEntitySales)
        {

            string strQuery = "FMS_EXPENSE.SP_CONFIRM_EXPENSE";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strQuery;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("E_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmd.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmd.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmd.Parameters.Add("E_USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
            clsDataLayer.ExecuteNonQuery(cmd);



        }

        public DataTable ReadAccountName(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.LOAD_BANK_LDGR";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }
        public DataTable ReadProducts(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_PRODUCT";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_PRDCTNAME", OracleDbType.Varchar2).Value = ObjEntitySales.ProdctName;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }

        public DataTable ReadTax(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_TAX";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_PRDT_ID", OracleDbType.Int32).Value = ObjEntitySales.product_id;
            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }

        public DataTable ReadSalesDetailsList(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_SALES_LIST";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_LEDGERID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;

            //0039

            //----------pagination--------//
            cmdReadTcs.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = ObjEntitySales.CommonSearchTerm;
            cmdReadTcs.Parameters.Add("P_SEARCH_REF", OracleDbType.Varchar2).Value = ObjEntitySales.SearchRef;
            cmdReadTcs.Parameters.Add("P_SEARCH_DATE", OracleDbType.Varchar2).Value = ObjEntitySales.SearchDate;
            cmdReadTcs.Parameters.Add("P_SEARCH_CUST", OracleDbType.Varchar2).Value = ObjEntitySales.SearchCusto;
            cmdReadTcs.Parameters.Add("P_SEARCH_AMNT", OracleDbType.Varchar2).Value = ObjEntitySales.SearchAmount;

            cmdReadTcs.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = ObjEntitySales.OrderColumn;
            cmdReadTcs.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = ObjEntitySales.OrderMethod;
            cmdReadTcs.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = ObjEntitySales.PageMaxSize;
            cmdReadTcs.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = ObjEntitySales.PageNumber;
            //---------------pagination------------//
            //end
            if (ObjEntitySales.FromPeriod != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_FROM_DATE", OracleDbType.Date).Value = ObjEntitySales.FromPeriod;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_FROM_DATE", OracleDbType.Date).Value = null;
            }

            if (ObjEntitySales.ToPeriod != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_TO_DATE", OracleDbType.Date).Value = ObjEntitySales.ToPeriod;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_TO_DATE", OracleDbType.Date).Value = null;
            }


            if (ObjEntitySales.StartDate != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = ObjEntitySales.StartDate;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = null;
            }

            if (ObjEntitySales.EndDate != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = ObjEntitySales.EndDate;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadTcs.Parameters.Add("S_CNCL_STS", OracleDbType.Int32).Value = ObjEntitySales.cnclStatus;
            cmdReadTcs.Parameters.Add("S_STS", OracleDbType.Int32).Value = ObjEntitySales.Status;
            cmdReadTcs.Parameters.Add("S_SALE_STS", OracleDbType.Int32).Value = ObjEntitySales.SalesSts;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }
        public DataTable ReadSalesDetailsList_Sum(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_SALES_LIST_SUM";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_LEDGERID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
            if (ObjEntitySales.FromPeriod != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_FROM_DATE", OracleDbType.Date).Value = ObjEntitySales.FromPeriod;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_FROM_DATE", OracleDbType.Date).Value = null;
            }

            if (ObjEntitySales.ToPeriod != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_TO_DATE", OracleDbType.Date).Value = ObjEntitySales.ToPeriod;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_TO_DATE", OracleDbType.Date).Value = null;
            }


            if (ObjEntitySales.StartDate != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = ObjEntitySales.StartDate;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = null;
            }

            if (ObjEntitySales.EndDate != DateTime.MinValue)
            {
                cmdReadTcs.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = ObjEntitySales.EndDate;
            }
            else
            {
                cmdReadTcs.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadTcs.Parameters.Add("S_CNCL_STS", OracleDbType.Int32).Value = ObjEntitySales.cnclStatus;
            cmdReadTcs.Parameters.Add("S_STS", OracleDbType.Int32).Value = ObjEntitySales.Status;
            cmdReadTcs.Parameters.Add("S_SALE_STS", OracleDbType.Int32).Value = ObjEntitySales.SalesSts;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }
        public DataTable ReadSalesDetailsById(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_SALES_DTLS_BYID";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;

            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_SALEID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }
        public DataTable ReadProductSalesById(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_PRODUCTS_BYID";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_SALEID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;

        }

        public void InsertSalesDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesList, List<clsEntitySales> ObjEntitySalesAttachmntList, List<clsEntitySales> ObjEntitySalesCCList)
        {
            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strReturn = "";
                    string refenablests = "";
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES);
                    objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
                    objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
                    string strNextId1 = objDatatLayer.ReadNextNumber(objEntityCommon);
                    string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                    ObjEntitySales.RefNextNumbr = Convert.ToInt32(strNextId);
                    ObjEntitySales.SalesId = Convert.ToInt32(strNextId);
                    int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                    intCorpId = ObjEntitySales.Corporate_id;
                    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    string strColumns = "";
                    for (int intcount = 0; intcount < arrEnumer.Length; intcount++)
                    {
                        if (intcount == 0)
                        {
                            strColumns = arrEnumer[intcount].ToString();
                        }
                        else
                        {
                            strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                        }
                    }
                    dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                    }

                    objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
                    objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
                    //   objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);

                    int intOrgId = objEntityCommon.Organisation_Id;
                    DataTable dtFormate = readRefFormate(objEntityCommon);
                    //--evm 0044
                    if (dtFormate.Rows.Count > 0)
                    {
                        refenablests = dtFormate.Rows[0]["REF_SALES_NUM_ENABLE_STS"].ToString();
                    }
                    //------
                    clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                    string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                    clsCommonLibrary objCommon = new clsCommonLibrary();
                    DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                    int DtYear = dtCurrentDate.Year;
                    int DtMonth = dtCurrentDate.Month;
                    string dtyy = dtCurrentDate.ToString("yy");

                    clsDataLayer objBusinessLayer = new clsDataLayer();
                    //clsEntityCommon objEntityCommon = new clsEntityCommon();

                    //objEntityCommon.Organisation_Id = objEntityShortList.Org_Id;
                    //objEntityCommon.CorporateID = objEntityShortList.Corp_Id;
                    objEntityCommon.FinancialYrId = ObjEntitySales.FinancialYrId;

                    DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
                    DateTime dtFinStartDate = new DateTime();
                    DateTime dtFinEndDate = new DateTime();
                    if (dtCurrentFiscalYr.Rows.Count > 0)
                    {
                        dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                        dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
                    }

                    string refFormatByDiv = "";
                    string strRealFormat = "";
                    string strRefnxt = "";

                    string refText = ObjEntitySales.Ref;
                    string Ref = ""; int SubRef = 1;
                    if (refenablests == "0")
                    {
                        if (dtFormate.Rows.Count > 0)
                        {
                            if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                            {
                                refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                                string strReferenceFormat = "";
                                strReferenceFormat = refFormatByDiv;

                                int flag = 0;
                                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                                int intArrayRowCount = arrReferenceSplit.Length;

                                if (flag == 1)
                                {
                                    refFormatByDiv = "#COR#*/*#USR#";
                                }
                                if (refFormatByDiv == "" || refFormatByDiv == null)
                                {
                                    strRealFormat = intCorpId + "/" + strNextId;
                                }
                                else
                                {
                                    strRealFormat = refFormatByDiv.ToString();
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
                                        strRealFormat = strRealFormat.Replace("#USR#", ObjEntitySales.User_Id.ToString());
                                    }

                                    //2019
                                    if (strRealFormat.Contains("#YER#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                                    }
                                    if (strRealFormat.Contains("#FYERS#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#FYERS#", dtFinStartDate.Year.ToString());
                                    }
                                    if (strRealFormat.Contains("#FYERE#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#FYERE#", dtFinEndDate.Year.ToString());
                                    }

                                    //19
                                    if (strRealFormat.Contains("#YY#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                                    }
                                    if (strRealFormat.Contains("#FYYS#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#FYYS#", dtFinStartDate.ToString("yy"));
                                    }
                                    if (strRealFormat.Contains("#FYYE#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#FYYE#", dtFinEndDate.ToString("yy"));
                                    }

                                    if (strRealFormat.Contains("#MON#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                                    }
                                    //strRealFormat = strRealFormat + "/" + strNextNum;
                                    if (strRealFormat.Contains("#NUM#"))
                                    {
                                        strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                                    }
                                    else
                                    {
                                        strRealFormat = strRealFormat + "/" + strNextId;
                                    }
                                    strRealFormat = strRealFormat.Replace("#", "");

                                }
                                ObjEntitySales.Ref = strRealFormat;
                            }


                        }
                        else
                        {
                            ObjEntitySales.Ref = strNextId;
                        }
                        //CHECKING SUB REF NUMBER

                        if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

                            clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

                            objEntityAccnt.FromDate = ObjEntitySales.Date;

                            objEntityAudit.FromDate = ObjEntitySales.Date;

                            clsEntitySales objEntityLayerStock1 = new clsEntitySales();
                            objEntityLayerStock1.FromPeriod = ObjEntitySales.Date;
                            objEntityAccnt.Corporate_id = intCorpId;
                            objEntityLayerStock1.Corporate_id = intCorpId;
                            objEntityAccnt.Organisation_id = intOrgId;
                            objEntityLayerStock1.Organisation_id = intOrgId;
                            objEntityAudit.Corporate_id = intCorpId;
                            objEntityAudit.Organisation_id = intOrgId;
                            DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                            DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                            if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                            {
                                DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);

                                if (dtRefFormat1.Rows.Count > 0)
                                {
                                    string strRef = "";
                                    if (dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                    {
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                    }
                                    objEntityLayerStock1.Ref = strRef;
                                    DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                    if (dtRefFormat.Rows.Count > 0)
                                    {
                                        Ref = dtRefFormat.Rows[0]["SALES_REF"].ToString();
                                        if (dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                        {
                                            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString());
                                        }
                                        if (SubRef != 1)
                                        {
                                            Ref = Ref.TrimEnd('/');
                                            Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            Ref += "/";
                                        }
                                        Ref = Ref + "" + SubRef;
                                        ObjEntitySales.Ref = Ref;
                                        SubRef++;

                                        if (dtRefFormat1.Rows[0]["SALES_REF_NEXTNUM"].ToString() != "")
                                        {

                                            ObjEntitySales.RefNextNumbr = Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NEXTNUM"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (refenablests == "1")
                    {
                        ObjEntitySales.Ref = refText;
                    }
                    //--------------

                    string strQueryInsertUser = "FMS_SALES.SP_INSERT_SALES_DTLS";
                    using (OracleCommand cmdInsertSales = new OracleCommand())
                    {
                        cmdInsertSales.Transaction = tran;
                        cmdInsertSales.Connection = con;
                        cmdInsertSales.CommandText = strQueryInsertUser;
                        cmdInsertSales.CommandType = CommandType.StoredProcedure;
                        cmdInsertSales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = strNextId1;
                        cmdInsertSales.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = ObjEntitySales.Ref;
                        cmdInsertSales.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntitySales.Date;
                        //cmdInsertSales.Parameters.Add("S_ACNT_ID", OracleDbType.Int32).Value = ObjEntitySales.AccId;
                        cmdInsertSales.Parameters.Add("S_CSTMR_LDGR_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                        if (ObjEntitySales.ExistingSplrsts == 0)
                        {

                            cmdInsertSales.Parameters.Add("S_SUP_NAME", OracleDbType.Varchar2).Value = null;
                            cmdInsertSales.Parameters.Add("S_SUP_ADD_ONE", OracleDbType.Varchar2).Value = null;
                            cmdInsertSales.Parameters.Add("S_SUP_ADD_TWO", OracleDbType.Varchar2).Value = null;
                            cmdInsertSales.Parameters.Add("S_SUP_ADD_THREE", OracleDbType.Varchar2).Value = null;

                        }
                        else
                        {

                            cmdInsertSales.Parameters.Add("S_SUP_NAME", OracleDbType.Varchar2).Value = ObjEntitySales.CustName;
                            cmdInsertSales.Parameters.Add("S_SUP_ADD_ONE", OracleDbType.Varchar2).Value = ObjEntitySales.AddressOne;
                            cmdInsertSales.Parameters.Add("S_SUP_ADD_TWO", OracleDbType.Varchar2).Value = ObjEntitySales.AddressTwo;
                            cmdInsertSales.Parameters.Add("S_SUP_ADD_THREE", OracleDbType.Varchar2).Value = ObjEntitySales.AddressThree;

                        }
                        //43
                        cmdInsertSales.Parameters.Add("S_GUEST_NAME", OracleDbType.Varchar2).Value = ObjEntitySales.GuestName;
                        //end
                        cmdInsertSales.Parameters.Add("PR_SPL_STS", OracleDbType.Int32).Value = ObjEntitySales.ExistingSplrsts;

                        // cmdInsertSales.Parameters.Add("S_RCPT_NO", OracleDbType.Varchar2).Value = ObjEntitySales.ReceiptNo;
                        cmdInsertSales.Parameters.Add("S_ORDER_NO", OracleDbType.Varchar2).Value = ObjEntitySales.OrderNo;
                        cmdInsertSales.Parameters.Add("S_GROSS_TOTL", OracleDbType.Decimal).Value = ObjEntitySales.GrossTotal;
                        cmdInsertSales.Parameters.Add("S_TAX_AMT", OracleDbType.Decimal).Value = ObjEntitySales.TotalTax;
                        cmdInsertSales.Parameters.Add("S_DISCOUNT", OracleDbType.Decimal).Value = ObjEntitySales.TotalDiscount;
                        cmdInsertSales.Parameters.Add("S_NET_TOTL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                        cmdInsertSales.Parameters.Add("S_EXRATETL", OracleDbType.Decimal).Value = ObjEntitySales.TotalExchangeRate;
                        cmdInsertSales.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
                        cmdInsertSales.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
                        cmdInsertSales.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                        cmdInsertSales.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = ObjEntitySales.status;
                        if (ObjEntitySales.CurrencyId != 0)
                        {
                            cmdInsertSales.Parameters.Add("S_CRNCY_ID", OracleDbType.Int32).Value = ObjEntitySales.CurrencyId;
                        }
                        else
                        {
                            cmdInsertSales.Parameters.Add("S_CRNCY_ID", OracleDbType.Int32).Value = null;
                        }
                        if (ObjEntitySales.ExchangeRate != 0)
                        {
                            cmdInsertSales.Parameters.Add("S_EXCHANG_RATE", OracleDbType.Decimal).Value = ObjEntitySales.ExchangeRate;
                        }
                        else
                        {
                            cmdInsertSales.Parameters.Add("S_EXCHANG_RATE", OracleDbType.Decimal).Value = null;
                        }


                        cmdInsertSales.Parameters.Add("S_DEFLT_CRNCY_ID", OracleDbType.Int32).Value = ObjEntitySales.DefaultCurrencyId;
                        cmdInsertSales.Parameters.Add("S_CRNCY_STS", OracleDbType.Int32).Value = ObjEntitySales.Currencysts;
                        cmdInsertSales.Parameters.Add("S_DESC", OracleDbType.Varchar2).Value = ObjEntitySales.CancelReason;



                        cmdInsertSales.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;

                        cmdInsertSales.Parameters.Add("S_ATCHMNT_STS", OracleDbType.Varchar2).Value = ObjEntitySales.AtchmntSts;
                        cmdInsertSales.Parameters.Add("S_REF_NEXTID", OracleDbType.Varchar2).Value = ObjEntitySales.RefNextNumbr;
                        //evm 0044
                        if (ObjEntitySales.CreditPeriod != 0)
                        {
                            cmdInsertSales.Parameters.Add("S_CREDIT_PRD", OracleDbType.Int32).Value = ObjEntitySales.CreditPeriod;
                        }
                        else
                        {
                            cmdInsertSales.Parameters.Add("S_CREDIT_PRD", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        //----------

                        cmdInsertSales.ExecuteNonQuery();
                    }
                    foreach (clsEntitySales objSaleList in ObjEntitySalesList)
                    {

                        string strQueryInsertGrp = "FMS_SALES.SP_INSERT_SALES_PRDT";
                        using (OracleCommand cmdInsertprdt = new OracleCommand())
                        {
                            cmdInsertprdt.Transaction = tran;
                            cmdInsertprdt.Connection = con;
                            cmdInsertprdt.CommandText = strQueryInsertGrp;
                            cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                            cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = strNextId1;
                            cmdInsertprdt.Parameters.Add("S_SLNO", OracleDbType.Int32).Value = objSaleList.SLnO;
                            cmdInsertprdt.Parameters.Add("S_PRDT_ID", OracleDbType.Int32).Value = objSaleList.product_id;
                            cmdInsertprdt.Parameters.Add("S_QTY", OracleDbType.Decimal).Value = objSaleList.Quantity;
                            cmdInsertprdt.Parameters.Add("S_RATE", OracleDbType.Decimal).Value = objSaleList.Rate;
                            cmdInsertprdt.Parameters.Add("S_DESCNT_PRCNTG", OracleDbType.Decimal).Value = objSaleList.DcntPrcntg;
                            cmdInsertprdt.Parameters.Add("S_DESCNT_AMT", OracleDbType.Decimal).Value = objSaleList.DcntAmt;
                            if (objSaleList.Tax_id != 0)
                            {
                                cmdInsertprdt.Parameters.Add("S_TAX_ID", OracleDbType.Int32).Value = objSaleList.Tax_id;
                            }
                            else
                            {
                                cmdInsertprdt.Parameters.Add("S_TAX_ID", OracleDbType.Int32).Value = null;
                            }
                            cmdInsertprdt.Parameters.Add("S_TAX_AMT", OracleDbType.Decimal).Value = objSaleList.TaxAmt;
                            cmdInsertprdt.Parameters.Add("S_PRICE", OracleDbType.Decimal).Value = objSaleList.Price;
                            cmdInsertprdt.Parameters.Add("S_REMRK", OracleDbType.Varchar2).Value = objSaleList.Remark;
                            cmdInsertprdt.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdInsertprdt.ExecuteNonQuery();
                            strReturn = cmdInsertprdt.Parameters["L_OUT"].Value.ToString();
                            cmdInsertprdt.Dispose();
                            // cmdInsertprdt.ExecuteNonQuery();
                        }

                        foreach (clsEntitySales objSaleCCList in ObjEntitySalesCCList)
                        {
                            string strQueryInsertCC = "FMS_SALES.SP_INSERT_SALES_CC_DTLS";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (objSaleList.product_id == objSaleCCList.product_id && objSaleList.SLnO == objSaleCCList.SLnO)
                                {
                                    cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = strNextId1;
                                    cmdInsertprdt.Parameters.Add("S_PRDCT_ID", OracleDbType.Int32).Value = strReturn;
                                    cmdInsertprdt.Parameters.Add("S_CC_ID", OracleDbType.Int32).Value = objSaleCCList.CC_Id;
                                    cmdInsertprdt.Parameters.Add("S_AMT", OracleDbType.Decimal).Value = objSaleCCList.CC_Amount;
                                    if (objSaleCCList.CC_Grp1_Id != 0)
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP1", OracleDbType.Decimal).Value = objSaleCCList.CC_Grp1_Id;
                                    else
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP1", OracleDbType.Decimal).Value = null;
                                    if (objSaleCCList.CC_Grp2_Id != 0)
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP2", OracleDbType.Decimal).Value = objSaleCCList.CC_Grp2_Id;
                                    else
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP2", OracleDbType.Decimal).Value = null;
                                    cmdInsertprdt.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    foreach (clsEntitySales objSaleList in ObjEntitySalesAttachmntList)
                    {

                        string strQueryInsertGrp = "FMS_SALES.SP_INSERT_SALES_ATCHMNT";
                        using (OracleCommand cmdInsertprdt = new OracleCommand())
                        {
                            cmdInsertprdt.Transaction = tran;
                            cmdInsertprdt.Connection = con;
                            cmdInsertprdt.CommandText = strQueryInsertGrp;
                            cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                            cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = strNextId1;
                            cmdInsertprdt.Parameters.Add("S_FILE_NAME", OracleDbType.Varchar2).Value = objSaleList.FileName;
                            cmdInsertprdt.Parameters.Add("S_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objSaleList.ActualFileName;

                            cmdInsertprdt.ExecuteNonQuery();
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
        public void CancelSalesDtlsById(clsEntitySales ObjEntitySales)
        {
            string strQueryCnclSales = " FMS_SALES.DETETE_SALES_DTL_BYID";
            using (OracleCommand cmdCnclsales = new OracleCommand())
            {
                cmdCnclsales.CommandText = strQueryCnclSales;
                cmdCnclsales.CommandType = CommandType.StoredProcedure;
                cmdCnclsales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                cmdCnclsales.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                cmdCnclsales.Parameters.Add("CNCL_RSN", OracleDbType.Varchar2).Value = ObjEntitySales.CancelReason;
                cmdCnclsales.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
                cmdCnclsales.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
                clsDataLayer.ExecuteNonQuery(cmdCnclsales);
            }
        }
        public void ChangeStatusById(clsEntitySales ObjEntitySales)
        {
            string strQueryCnclSales = " FMS_SALES.CHANGE_STATUS_BYID";
            using (OracleCommand cmdCnclsales = new OracleCommand())
            {
                cmdCnclsales.CommandText = strQueryCnclSales;
                cmdCnclsales.CommandType = CommandType.StoredProcedure;
                cmdCnclsales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                cmdCnclsales.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                cmdCnclsales.Parameters.Add("STS", OracleDbType.Int32).Value = ObjEntitySales.Status;
                clsDataLayer.ExecuteNonQuery(cmdCnclsales);
            }
        }
        public void ConfmSaleDetlById(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesListINS, List<clsEntitySales> ObjEntitySalesListUPD)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryCnclSales = " FMS_SALES.CONFM_SALE_BYID";
                    using (OracleCommand cmdCnclsales = new OracleCommand(strQueryCnclSales, con))
                    {
                        cmdCnclsales.Transaction = tran;
                        cmdCnclsales.CommandType = CommandType.StoredProcedure;
                        cmdCnclsales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                        cmdCnclsales.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                        cmdCnclsales.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                        cmdCnclsales.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                        cmdCnclsales.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                        cmdCnclsales.ExecuteNonQuery();
                    }
                    //on confirm
                    if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                    {
                        //insert sales details to vocher account
                        string strQueryInsertVoucher = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_SALES";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                            cmdAddSubDetail.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                            cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //products insert
                        foreach (clsEntitySales objSubDetail in ObjEntitySalesListINS)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucherPdct = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherPdct, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                ObjEntitySales.VoucherId = Convert.ToInt32(strVReturn);
                            }

                            //insert into cost centre vocher table
                            string strQueryInsertVoucherCC = "FMS_SALES.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherCC, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = ObjEntitySales.VoucherId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                        }

                        //products update
                        foreach (clsEntitySales objSubDetail in ObjEntitySalesListUPD)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucherPdct = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherPdct, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                ObjEntitySales.VoucherId = Convert.ToInt32(strVReturn);
                            }

                            //insert into cost centre vocher table
                            string strQueryInsertVoucherCC = "FMS_SALES.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherCC, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = ObjEntitySales.VoucherId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                        }

                        //update if difference in total amount present in vocher and add to ledger details table
                        string strQueryInsertVoucherDiff = "FMS_SALES.SP_UPD_VOUCHER_ACCNT_DIFFAMNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherDiff, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.ExecuteNonQuery();
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

        public void UpdateSalesDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesInsertList, List<clsEntitySales> ObjEntitySalesUpdateList, List<clsEntitySales> ObjEntitySalesDeleteList, List<clsEntitySales> ObjEntitySalesAttachmntList, List<clsEntitySales> ObjEntityDeleteSalesAttachmntList, List<clsEntitySales> ObjEntitySalesCCList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strQueryLeaveTyp = "FMS_SALES.SP_UPDATE_SALES_DTLS";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                string strReturn = "";

                try
                {
                    using (OracleCommand cmdUpdSalesDtls = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdUpdSalesDtls.Transaction = tran;
                        string Ref = ""; int SubRef = 1;
                        string refenablests = "";

                        if (ObjEntitySales.Date != ObjEntitySales.UpdSaleDate)
                        {
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES);
                            objEntCommon.CorporateID = ObjEntitySales.Corporate_id;
                            //CHECKING FOR CORP GLOBAL SUB REF STATUS
                            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                            intCorpId = ObjEntitySales.Corporate_id;
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);
                            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                              };
                            DataTable dtCorpDetail = new DataTable();
                            string strColumns = "";
                            for (int intcount = 0; intcount < arrEnumer.Length; intcount++)
                            {
                                if (intcount == 0)
                                {
                                    strColumns = arrEnumer[intcount].ToString();
                                }
                                else
                                {
                                    strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                                }
                            }
                            dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                            if (dtCorpDetail.Rows.Count > 0)
                            {
                                strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                            }
                            int intOrgId = ObjEntitySales.Organisation_id;
                            int intUsrId = ObjEntitySales.User_Id;

                            DataTable dtFormate = readRefFormate(objEntCommon);

                            //--evm 0044
                            if (dtFormate.Rows.Count > 0)
                            {
                                refenablests = dtFormate.Rows[0]["REF_SALES_NUM_ENABLE_STS"].ToString();
                            }
                            //------

                            clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                            string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                            int DtYear = dtCurrentDate.Year;
                            int DtMonth = dtCurrentDate.Month;


                            if (refenablests == "0")
                            {
                                //CHECKING SUB REF NUMBER
                                if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                                    clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                    clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                                    clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                    objEntityAudit.FromDate = ObjEntitySales.Date;
                                    objEntityAccnt.FromDate = ObjEntitySales.Date;
                                    clsEntitySales objEntityLayerStock1 = new clsEntitySales();
                                    objEntityLayerStock1.FromPeriod = ObjEntitySales.Date;
                                    objEntityAccnt.Corporate_id = intCorpId;
                                    objEntityLayerStock1.Corporate_id = intCorpId;
                                    objEntityAccnt.Organisation_id = intOrgId;
                                    objEntityLayerStock1.Organisation_id = intOrgId;
                                    objEntityAudit.Corporate_id = intCorpId;
                                    objEntityAudit.Organisation_id = intOrgId;
                                    DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                    DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                    if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                    {
                                        DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);


                                        if (dtRefFormat1.Rows.Count > 0)
                                        {
                                            string strRef = "";
                                            if (dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                            }
                                            objEntityLayerStock1.Ref = strRef;
                                            DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                            if (dtRefFormat.Rows.Count > 0)
                                            {
                                                if (ObjEntitySales.SalesId != Convert.ToInt32(dtRefFormat.Rows[0]["SALES_ID"].ToString()))
                                                {
                                                    Ref = dtRefFormat.Rows[0]["SALES_REF"].ToString();
                                                    if (dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                                    {
                                                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString());
                                                    }
                                                    if (SubRef != 1)
                                                    {
                                                        Ref = Ref.TrimEnd('/');
                                                        Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                    }
                                                    else
                                                    {
                                                        Ref += "/";
                                                    }
                                                    Ref = Ref + "" + SubRef;
                                                    ObjEntitySales.Ref = Ref;
                                                    SubRef++;
                                                }
                                            }

                                            if (dtRefFormat1.Rows[0]["SALES_REF_NEXTNUM"].ToString() != "")
                                            {
                                                ObjEntitySales.RefNextNumbr = Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NEXTNUM"].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        cmdUpdSalesDtls.CommandText = strQueryLeaveTyp;
                        cmdUpdSalesDtls.CommandType = CommandType.StoredProcedure;
                        cmdUpdSalesDtls.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                        cmdUpdSalesDtls.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntitySales.Date;
                        cmdUpdSalesDtls.Parameters.Add("S_CSTMR_LDGR_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;

                        if (ObjEntitySales.ExistingSplrsts == 0)
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_NAME", OracleDbType.Varchar2).Value = null;
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_ADD_ONE", OracleDbType.Varchar2).Value = null;
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_ADD_TWO", OracleDbType.Varchar2).Value = null;
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_ADD_THREE", OracleDbType.Varchar2).Value = null;
                        }
                        else
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_NAME", OracleDbType.Varchar2).Value = ObjEntitySales.CustName;
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_ADD_ONE", OracleDbType.Varchar2).Value = ObjEntitySales.AddressOne;
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_ADD_TWO", OracleDbType.Varchar2).Value = ObjEntitySales.AddressTwo;
                            cmdUpdSalesDtls.Parameters.Add("S_SUP_ADD_THREE", OracleDbType.Varchar2).Value = ObjEntitySales.AddressThree;
                        }
                        //43
                        cmdUpdSalesDtls.Parameters.Add("S_GUEST_NAME", OracleDbType.Varchar2).Value = ObjEntitySales.GuestName;
                        //43
                        cmdUpdSalesDtls.Parameters.Add("S_SPL_STS", OracleDbType.Int32).Value = ObjEntitySales.ExistingSplrsts;
                        cmdUpdSalesDtls.Parameters.Add("S_ORDER_NO", OracleDbType.Varchar2).Value = ObjEntitySales.OrderNo;
                        cmdUpdSalesDtls.Parameters.Add("S_GROSS_TOTL", OracleDbType.Decimal).Value = ObjEntitySales.GrossTotal;
                        cmdUpdSalesDtls.Parameters.Add("S_TAX_AMT", OracleDbType.Decimal).Value = ObjEntitySales.TotalTax;
                        cmdUpdSalesDtls.Parameters.Add("S_DISCOUNT", OracleDbType.Decimal).Value = ObjEntitySales.TotalDiscount;
                        cmdUpdSalesDtls.Parameters.Add("S_NET_TOTL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                        cmdUpdSalesDtls.Parameters.Add("S_EXRATETL", OracleDbType.Decimal).Value = ObjEntitySales.TotalExchangeRate;
                        cmdUpdSalesDtls.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
                        cmdUpdSalesDtls.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
                        cmdUpdSalesDtls.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                        cmdUpdSalesDtls.Parameters.Add("S_STATUS", OracleDbType.Int32).Value = ObjEntitySales.status;
                        if (ObjEntitySales.CurrencyId != 0)
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_CRNCY_ID", OracleDbType.Int32).Value = ObjEntitySales.CurrencyId;
                        }
                        else
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_CRNCY_ID", OracleDbType.Int32).Value = null;
                        }
                        cmdUpdSalesDtls.Parameters.Add("S_DEFLT_CRNCY_ID", OracleDbType.Int32).Value = ObjEntitySales.DefaultCurrencyId;
                        cmdUpdSalesDtls.Parameters.Add("S_CRNCY_STS", OracleDbType.Int32).Value = ObjEntitySales.Currencysts;
                        if (ObjEntitySales.ExchangeRate != 0)
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_EXCHANG_RATE", OracleDbType.Decimal).Value = ObjEntitySales.ExchangeRate;
                        }
                        else
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_EXCHANG_RATE", OracleDbType.Decimal).Value = null;
                        }
                        cmdUpdSalesDtls.Parameters.Add("S_DESC", OracleDbType.Varchar2).Value = ObjEntitySales.CancelReason;
                        cmdUpdSalesDtls.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = ObjEntitySales.Ref;
                        cmdUpdSalesDtls.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdUpdSalesDtls.Parameters.Add("S_ATCHMNT_STS", OracleDbType.Varchar2).Value = ObjEntitySales.AtchmntSts;
                        cmdUpdSalesDtls.Parameters.Add("S_REF_NEXTID", OracleDbType.Varchar2).Value = ObjEntitySales.RefNextNumbr;
                        //evm 0044
                        if (ObjEntitySales.CreditPeriod != 0)
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_CREDIT_PRD", OracleDbType.Int32).Value = ObjEntitySales.CreditPeriod;
                        }
                        else
                        {
                            cmdUpdSalesDtls.Parameters.Add("S_CREDIT_PRD", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        //----------
                        cmdUpdSalesDtls.ExecuteNonQuery();
                    }

                    //on confirm
                    if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                    {
                        string strQueryCnclSales = " FMS_SALES.CONFM_SALE_BYID";
                        using (OracleCommand cmdCnclsales = new OracleCommand(strQueryCnclSales, con))
                        {
                            cmdCnclsales.Transaction = tran;
                            cmdCnclsales.CommandType = CommandType.StoredProcedure;
                            cmdCnclsales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdCnclsales.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                            cmdCnclsales.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                            cmdCnclsales.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                            cmdCnclsales.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                            cmdCnclsales.ExecuteNonQuery();
                        }
                    }

                    //on confirm
                    if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                    {
                        //insert sales details to vocher account
                        string strQueryInsertVoucher = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_SALES";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                            cmdAddSubDetail.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                            cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }

                    //if no attachments
                    if (ObjEntitySales.AtchmntSts == 0)
                    {
                        //delete attachments
                        string strQueryInsertGrp = "FMS_SALES.SP_DELETE_ATCHMNT";
                        using (OracleCommand cmdInsertprdt = new OracleCommand())
                        {
                            cmdInsertprdt.Transaction = tran;
                            cmdInsertprdt.Connection = con;
                            cmdInsertprdt.CommandText = strQueryInsertGrp;
                            cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                            cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdInsertprdt.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //add attachments
                        foreach (clsEntitySales objSaleList in ObjEntitySalesAttachmntList)
                        {
                            string strQueryInsertGrp1 = "FMS_SALES.SP_INSERT_SALES_ATCHMNT";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                cmdInsertprdt.Transaction = tran;
                                cmdInsertprdt.Connection = con;
                                cmdInsertprdt.CommandText = strQueryInsertGrp1;
                                cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdInsertprdt.Parameters.Add("S_FILE_NAME", OracleDbType.Varchar2).Value = objSaleList.FileName;
                                cmdInsertprdt.Parameters.Add("S_ACT_FILE_NAME", OracleDbType.Varchar2).Value = objSaleList.ActualFileName;

                                cmdInsertprdt.ExecuteNonQuery();
                            }
                        }
                        //delete attachments
                        foreach (clsEntitySales objSaleList in ObjEntityDeleteSalesAttachmntList)
                        {
                            string strQueryInsertGrp1 = "FMS_SALES.SP_CANCEL_SALES_ATCHMNT";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                cmdInsertprdt.Transaction = tran;
                                cmdInsertprdt.Connection = con;
                                cmdInsertprdt.CommandText = strQueryInsertGrp1;
                                cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                cmdInsertprdt.Parameters.Add("S_ATCHMNT_SALES_ID", OracleDbType.Int32).Value = objSaleList.AtchmntId;
                                cmdInsertprdt.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                                cmdInsertprdt.ExecuteNonQuery();
                            }
                        }
                    }

                    decimal decTotalAmnt = 0;

                    //update products
                    foreach (clsEntitySales ObjEntitySalesList in ObjEntitySalesUpdateList)
                    {
                        string strQuerySubDetails = "FMS_SALES.SP_UPDATE_SUBDTL";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.Parameters.Add("S_SALES_PRDT_ID", OracleDbType.Int32).Value = ObjEntitySalesList.SalesProductId;
                            cmdAddSubDetail.Parameters.Add("S_SLNO", OracleDbType.Int32).Value = ObjEntitySalesList.SLnO;
                            cmdAddSubDetail.Parameters.Add("S_PRDT_ID", OracleDbType.Int32).Value = ObjEntitySalesList.product_id;
                            cmdAddSubDetail.Parameters.Add("S_QTY", OracleDbType.Decimal).Value = ObjEntitySalesList.Quantity;
                            cmdAddSubDetail.Parameters.Add("S_RATE", OracleDbType.Decimal).Value = ObjEntitySalesList.Rate;
                            cmdAddSubDetail.Parameters.Add("S_DESCNT_PRCNTG", OracleDbType.Decimal).Value = ObjEntitySalesList.DcntPrcntg;
                            cmdAddSubDetail.Parameters.Add("S_DESCNT_AMT", OracleDbType.Decimal).Value = ObjEntitySalesList.DcntAmt;
                            if (ObjEntitySalesList.Tax_id == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("S_TAX_ID", OracleDbType.Int32).Value = null;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("S_TAX_ID", OracleDbType.Int32).Value = ObjEntitySalesList.Tax_id;
                            }
                            cmdAddSubDetail.Parameters.Add("S_TAX_AMT", OracleDbType.Decimal).Value = ObjEntitySalesList.TaxAmt;
                            cmdAddSubDetail.Parameters.Add("S_PRICE", OracleDbType.Decimal).Value = ObjEntitySalesList.Price;
                            cmdAddSubDetail.Parameters.Add("S_REMRK", OracleDbType.Varchar2).Value = ObjEntitySalesList.Remark;

                            decTotalAmnt = decTotalAmnt + ObjEntitySalesList.Price;

                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //on confirm
                        if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucherPdct = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherPdct, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = ObjEntitySalesList.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                ObjEntitySales.VoucherId = Convert.ToInt32(strVReturn);
                            }
                        }

                        //insert cost centre to products
                        foreach (clsEntitySales objSaleCCList in ObjEntitySalesCCList)
                        {
                            string strQueryInsertCC = "FMS_SALES.SP_INSERT_SALES_CC_DTLS";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (ObjEntitySalesList.product_id == objSaleCCList.product_id && ObjEntitySalesList.SLnO == objSaleCCList.SLnO)
                                {
                                    cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                    cmdInsertprdt.Parameters.Add("S_PRDCT_ID", OracleDbType.Int32).Value = ObjEntitySalesList.SalesProductId;
                                    cmdInsertprdt.Parameters.Add("S_CC_ID", OracleDbType.Int32).Value = objSaleCCList.CC_Id;
                                    cmdInsertprdt.Parameters.Add("S_AMT", OracleDbType.Decimal).Value = objSaleCCList.CC_Amount;
                                    if (objSaleCCList.CC_Grp1_Id != 0)
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP1", OracleDbType.Decimal).Value = objSaleCCList.CC_Grp1_Id;
                                    else
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP1", OracleDbType.Decimal).Value = null;
                                    if (objSaleCCList.CC_Grp2_Id != 0)
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP2", OracleDbType.Decimal).Value = objSaleCCList.CC_Grp2_Id;
                                    else
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP2", OracleDbType.Decimal).Value = null;
                                    cmdInsertprdt.ExecuteNonQuery();
                                }
                            }
                        }

                        if (ObjEntitySalesCCList.Count > 0)
                        {
                            //on confirm
                            if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                            {
                                //insert into cost centre vocher table
                                string strQueryInsertVoucherCC = "FMS_SALES.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherCC, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                    cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = ObjEntitySalesList.SalesProductId;
                                    cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                    cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = ObjEntitySales.VoucherId;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    //delete products
                    foreach (clsEntitySales objSubDetail in ObjEntitySalesDeleteList)
                    {
                        {
                            string strQueryChangeStatus = "FMS_SALES.DETETE_SUBTABLE";
                            using (OracleCommand cmdChangeStatus = new OracleCommand())
                            {
                                cmdChangeStatus.Transaction = tran;
                                cmdChangeStatus.Connection = con;
                                cmdChangeStatus.CommandText = strQueryChangeStatus;
                                cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                cmdChangeStatus.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdChangeStatus.Parameters.Add("S_SALES_PRDT_ID", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                                cmdChangeStatus.ExecuteNonQuery();
                            }
                        }
                    }

                    //insert products
                    foreach (clsEntitySales ObjEntitySalesInsert in ObjEntitySalesInsertList)
                    {
                        string strQuerySubDetails = "FMS_SALES.SP_INSERT_SALES_PRDT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.Parameters.Add("S_SLNO", OracleDbType.Int32).Value = ObjEntitySalesInsert.SLnO;
                            cmdAddSubDetail.Parameters.Add("S_PRDT_ID", OracleDbType.Int32).Value = ObjEntitySalesInsert.product_id;
                            cmdAddSubDetail.Parameters.Add("S_QTY", OracleDbType.Decimal).Value = ObjEntitySalesInsert.Quantity;
                            cmdAddSubDetail.Parameters.Add("S_RATE", OracleDbType.Decimal).Value = ObjEntitySalesInsert.Rate;
                            cmdAddSubDetail.Parameters.Add("S_DESCNT_PRCNTG", OracleDbType.Decimal).Value = ObjEntitySalesInsert.DcntPrcntg;
                            cmdAddSubDetail.Parameters.Add("S_DESCNT_AMT", OracleDbType.Decimal).Value = ObjEntitySalesInsert.DcntAmt;
                            if (ObjEntitySalesInsert.Tax_id != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("S_TAX_ID", OracleDbType.Int32).Value = ObjEntitySalesInsert.Tax_id;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("S_TAX_ID", OracleDbType.Int32).Value = null;
                            }
                            cmdAddSubDetail.Parameters.Add("S_TAX_AMT", OracleDbType.Decimal).Value = ObjEntitySalesInsert.TaxAmt;
                            cmdAddSubDetail.Parameters.Add("S_PRICE", OracleDbType.Decimal).Value = ObjEntitySalesInsert.Price;
                            cmdAddSubDetail.Parameters.Add("S_REMRK", OracleDbType.Varchar2).Value = ObjEntitySalesInsert.Remark;
                            cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddSubDetail.ExecuteNonQuery();
                            strReturn = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();
                            cmdAddSubDetail.Dispose();

                            ObjEntitySalesInsert.SalesProductId = Convert.ToInt32(strReturn);

                            decTotalAmnt = decTotalAmnt + ObjEntitySalesInsert.Price;
                        }

                        //on confirm
                        if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucherPdct = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherPdct, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = ObjEntitySalesInsert.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                ObjEntitySales.VoucherId = Convert.ToInt32(strVReturn);
                            }
                        }

                        //insert cost centre to products
                        foreach (clsEntitySales objSaleCCList in ObjEntitySalesCCList)
                        {
                            string strQueryInsertCC = "FMS_SALES.SP_INSERT_SALES_CC_DTLS";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (ObjEntitySalesInsert.product_id == objSaleCCList.product_id && ObjEntitySalesInsert.SLnO == objSaleCCList.SLnO)
                                {
                                    cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                    cmdInsertprdt.Parameters.Add("S_PRDCT_ID", OracleDbType.Int32).Value = strReturn;
                                    cmdInsertprdt.Parameters.Add("S_CC_ID", OracleDbType.Int32).Value = objSaleCCList.CC_Id;
                                    cmdInsertprdt.Parameters.Add("S_AMT", OracleDbType.Decimal).Value = objSaleCCList.CC_Amount;
                                    if (objSaleCCList.CC_Grp1_Id != 0)
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP1", OracleDbType.Decimal).Value = objSaleCCList.CC_Grp1_Id;
                                    else
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP1", OracleDbType.Decimal).Value = null;
                                    if (objSaleCCList.CC_Grp2_Id != 0)
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP2", OracleDbType.Decimal).Value = objSaleCCList.CC_Grp2_Id;
                                    else
                                        cmdInsertprdt.Parameters.Add("S_CC_GRP2", OracleDbType.Decimal).Value = null;
                                    cmdInsertprdt.ExecuteNonQuery();
                                }
                            }
                        }


                        if (ObjEntitySalesCCList.Count > 0)
                        {
                            //on confirm
                            if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                            {
                                //insert into cost centre vocher table
                                string strQueryInsertVoucherCC = "FMS_SALES.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherCC, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                    cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = ObjEntitySalesInsert.SalesProductId;
                                    cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                    cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = ObjEntitySales.VoucherId;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                            }
                        }

                    }

                    //on confirm
                    if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                    {
                        //update if difference in total amount present in vocher and add to ledger details table
                        string strQueryInsertVoucherDiff = "FMS_SALES.SP_UPD_VOUCHER_ACCNT_DIFFAMNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherDiff, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.ExecuteNonQuery();
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

        public DataTable SaleCancelChk(clsEntitySales ObjEntitySales)
        {
            string strQueryReadSales = "FMS_SALES.SP_SALE_CNCLCHCK";
            OracleCommand cmdReadSales = new OracleCommand();
            cmdReadSales.CommandText = strQueryReadSales;
            cmdReadSales.CommandType = CommandType.StoredProcedure;

            cmdReadSales.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadSales.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadSales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadSales.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadSales);
            return dtLeav;

        }
        public DataTable ReadCurrency(clsEntitySales objEntity)
        {
            string strQueryReadRcpt = "FMS_SALES.SP_READ_CURRENCY";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


        public DataTable ReadDefualtCurrency(clsEntitySales objEntity)
        {
            string strQueryReadRcpt = "FMS_SALES.SP_READDEFLT_CURRENCY";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadCrncyAbrvtn(clsEntitySales objEntity)
        {
            string strQueryReadRcpt = "FMS_SALES.SP_READ_CURRENCY_ABRVTN";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_CRNCY_ID", OracleDbType.Int32).Value = objEntity.CurrencyId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadCustomerCredits(clsEntitySales objEntityPurchase)
        {
            string strQueryReadEmpSlry = "FMS_SALES.SP_READ_CUSTOMER_CREDITS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.SalesId;
            cmdReadPayGrd.Parameters.Add("PR_SUP", OracleDbType.Int32).Value = objEntityPurchase.LedgerId;
            cmdReadPayGrd.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadCustomerDtls(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_CUSTOMER_DTLS";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_CUSTLEDGR_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;
        }
        public DataTable ReadCorpDtls(clsEntitySales ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_SALES.SP_READ_CORP_DTLS";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;
        }


        public DataTable ReadDefultLdgr(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_DFLT_LDGR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_MOD_ID", OracleDbType.Int32).Value = ObjEntitySales.ActModeId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_RD_REF_FORMAT";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_MOD_ID", OracleDbType.Int32).Value = ObjEntitySales.SectionId;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable readFinancialYear(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_RD_FINSCAL_YEAR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable readAcntClsDate(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_RD_ACNT_CLS_DATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("S_FROM_DATE", OracleDbType.Date).Value = ObjEntitySales.FromPeriod;
            cmdReadCustomerLdger.Parameters.Add("S_TO_DATE", OracleDbType.Date).Value = ObjEntitySales.ToPeriod;

            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }



        public DataTable ReadRefNumberByDate(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_RD_REF_BYDATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntitySales.FromPeriod;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;

        }

        public DataTable ReadRefNumberByDateLast(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_RD_REF_BYDATE_LAST";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = ObjEntitySales.Ref;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;

        }
        public void ReopenSales(clsEntitySales ObjEntitySales)
        {
            string strQueryCnclSales = " FMS_SALES.REOPEN_SALE_BYID";
            using (OracleCommand cmdCnclsales = new OracleCommand())
            {
                cmdCnclsales.CommandText = strQueryCnclSales;
                cmdCnclsales.CommandType = CommandType.StoredProcedure;
                cmdCnclsales.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                cmdCnclsales.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                cmdCnclsales.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                cmdCnclsales.Parameters.Add("USR_ID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdCnclsales);
            }
        }

        public DataTable ReadProductName(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_RD_PRDT_NAME";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("S_PID", OracleDbType.Varchar2).Value = ObjEntitySales.product_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;

        }
        public DataTable ReadAttachmentById(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_ATTACHMENT_BY_ID";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_SALE_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;

        }

        public void ConfirmSales(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQuerylWelfare = "FMS_SALES.SP_CONFRM_SALES";
                    using (OracleCommand cmdlWelfare = new OracleCommand(strQuerylWelfare, con))
                    {
                        cmdlWelfare.Transaction = tran;
                        cmdlWelfare.CommandType = CommandType.StoredProcedure;
                        cmdlWelfare.Parameters.Add("S_PID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                        cmdlWelfare.Parameters.Add("S_CORPID", OracleDbType.Decimal).Value = ObjEntitySales.Organisation_id;
                        cmdlWelfare.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
                        cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                        cmdlWelfare.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                        cmdlWelfare.ExecuteNonQuery();
                    }

                    //on confirm
                    if (ObjEntitySales.Status == 1 && ObjEntitySales.NetTotal > 0)
                    {
                        //insert sales details to vocher account
                        string strQueryInsertVoucher = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_SALES";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                            cmdAddSubDetail.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                            cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //products
                        foreach (clsEntitySales objSubDetail in ObjEntitySalesList)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucherPdct = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherPdct, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                ObjEntitySales.VoucherId = Convert.ToInt32(strVReturn);
                            }

                            //insert into cost centre vocher table
                            string strQueryInsertVoucherCC = "FMS_SALES.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherCC, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.SalesProductId;
                                cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                                cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = ObjEntitySales.VoucherId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                        }

                        //update if difference in total amount present in vocher and add to ledger details table
                        string strQueryInsertVoucherDiff = "FMS_SALES.SP_UPD_VOUCHER_ACCNT_DIFFAMNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherDiff, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                            cmdAddSubDetail.ExecuteNonQuery();
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

        public DataTable ReadPrintVersion(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_DEFLT_PRINT_VERSION";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadBankDetails(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_BANK_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadSaleCCDetails(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_SALE_CC_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("R_SALID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadCustomerLdger.Parameters.Add("R_PDCTID", OracleDbType.Int32).Value = ObjEntitySales.SalesProductId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadSaleCreditDtls(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_CREDIT_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CSTMRID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
            cmdReadCustomerLdger.Parameters.Add("R_DATE", OracleDbType.Date).Value = ObjEntitySales.Date;
            cmdReadCustomerLdger.Parameters.Add("R_SALESID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public void DeleteDuplicateSales(clsEntitySales ObjEntitySales)
        {
            string strQuerylWelfare = "FMS_SALES.SP_UPDATE_ATTCH_DEL";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("S_USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                cmdlWelfare.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }

        //evm 0044
        public string CheckCodeDuplicatn(clsEntitySales objEntitySales)
        {
            string strQueryAddBank = "FMS_SALES.SP_CHECK_DUP_REF_NUM";
            OracleCommand cmdCheckRefNum = new OracleCommand();
            cmdCheckRefNum.CommandText = strQueryAddBank;
            cmdCheckRefNum.CommandType = CommandType.StoredProcedure;
            cmdCheckRefNum.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = objEntitySales.SalesId;
            cmdCheckRefNum.Parameters.Add("S_REF_NUM", OracleDbType.Varchar2).Value = objEntitySales.Ref;
            cmdCheckRefNum.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntitySales.Corporate_id;
            cmdCheckRefNum.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntitySales.Organisation_id;
            cmdCheckRefNum.Parameters.Add("S_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckRefNum);
            string strReturn = cmdCheckRefNum.Parameters["S_COUNT"].Value.ToString();
            cmdCheckRefNum.Dispose();
            return strReturn;
        }



        //evm 0044 expense
        public DataTable ReadLedgers(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_SALES.SP_READ_LEDGER";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_LDGRNAME", OracleDbType.Varchar2).Value = ObjEntitySales.CommonSearchTerm;
            cmdReadCustomerLdger.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadExpenseData(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_EXPENSE.SP_READ_EXPENSE_DATA";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("E_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadCustomerLdger.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadExpense_Data(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_EXPENSE.SP_READ_EXPENSEDATA";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("E_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
            cmdReadCustomerLdger.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public void InsertExpenseDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesDetailList, List<clsEntitySales> ObjEntitySalesPrdtList)
        {
            //OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
               // tran = con.BeginTransaction();
                try
                {

                    string strReturn = "";
                    string refenablests = "";//--evm 0044
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXPENSE);
                    objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
                    objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
                    string strNextId1 = objDatatLayer.ReadNextNumber(objEntityCommon);
                    string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                    ObjEntitySales.RefNextNumbr = Convert.ToInt32(strNextId);
                    ObjEntitySales.SalesId = Convert.ToInt32(strNextId);
                    int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                    intCorpId = ObjEntitySales.Corporate_id;
                    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);
                    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                              };
                    DataTable dtCorpDetail = new DataTable();
                    string strColumns = "";
                    for (int intcount = 0; intcount < arrEnumer.Length; intcount++)
                    {
                        if (intcount == 0)
                        {
                            strColumns = arrEnumer[intcount].ToString();
                        }
                        else
                        {
                            strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                        }
                    }
                    dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                    if (dtCorpDetail.Rows.Count > 0)
                    {
                        strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                    }

                    objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
                    objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
                    //   objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);

                    int intOrgId = objEntityCommon.Organisation_Id;
                    DataTable dtFormate = readRefFormate(objEntityCommon);
                    //--evm 0044
                    if (dtFormate.Rows.Count > 0)
                    {
                        refenablests = dtFormate.Rows[0]["REF_SALES_NUM_ENABLE_STS"].ToString();
                    }
                    //------
                    clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                    string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                    clsCommonLibrary objCommon = new clsCommonLibrary();
                    DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                    int DtYear = dtCurrentDate.Year;
                    int DtMonth = dtCurrentDate.Month;
                    string dtyy = dtCurrentDate.ToString("yy");

                    clsDataLayer objBusinessLayer = new clsDataLayer();
                    //clsEntityCommon objEntityCommon = new clsEntityCommon();

                    //objEntityCommon.Organisation_Id = objEntityShortList.Org_Id;
                    //objEntityCommon.CorporateID = objEntityShortList.Corp_Id;
                    objEntityCommon.FinancialYrId = ObjEntitySales.FinancialYrId;

                    DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
                    DateTime dtFinStartDate = new DateTime();
                    DateTime dtFinEndDate = new DateTime();
                    if (dtCurrentFiscalYr.Rows.Count > 0)
                    {
                        dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                        dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
                    }

                    string refFormatByDiv = "";
                    string strRealFormat = "";
                    string strRefnxt = "";

                    //evm 0044 
                    string refText = ObjEntitySales.Ref;
                    string Ref = ""; int SubRef = 1;

                    //evm 0044---------

                    if (dtFormate.Rows.Count > 0)
                    {

                        if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                        {
                            refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                            string strReferenceFormat = "";
                            strReferenceFormat = refFormatByDiv;

                            int flag = 0;
                            string[] arrReferenceSplit = strReferenceFormat.Split('*');
                            int intArrayRowCount = arrReferenceSplit.Length;

                            if (flag == 1)
                            {
                                refFormatByDiv = "#COR#*/*#USR#";
                            }
                            if (refFormatByDiv == "" || refFormatByDiv == null)
                            {
                                strRealFormat = intCorpId + "/" + strNextId;
                            }
                            else
                            {
                                strRealFormat = refFormatByDiv.ToString();
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
                                    strRealFormat = strRealFormat.Replace("#USR#", ObjEntitySales.User_Id.ToString());
                                }

                                //2019
                                if (strRealFormat.Contains("#YER#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                                }
                                if (strRealFormat.Contains("#FYERS#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#FYERS#", dtFinStartDate.Year.ToString());
                                }
                                if (strRealFormat.Contains("#FYERE#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#FYERE#", dtFinEndDate.Year.ToString());
                                }

                                //19
                                if (strRealFormat.Contains("#YY#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                                }
                                if (strRealFormat.Contains("#FYYS#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#FYYS#", dtFinStartDate.ToString("yy"));
                                }
                                if (strRealFormat.Contains("#FYYE#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#FYYE#", dtFinEndDate.ToString("yy"));
                                }

                                if (strRealFormat.Contains("#MON#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                                }

                                //strRealFormat = strRealFormat + "/" + strNextId;

                                if (strRealFormat.Contains("#NUM#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                                }
                                else
                                {
                                    strRealFormat = strRealFormat + "/" + strNextId;
                                }
                                strRealFormat = strRealFormat.Replace("#", "");
                                strRealFormat = strRealFormat.Replace("*", "");
                                strRealFormat = strRealFormat.Replace("%", "");
                            }
                            ObjEntitySales.ExpRef = strRealFormat;

                        }

                        else
                        {
                            ObjEntitySales.Ref = strNextId;
                        }

                    }

                    //--------------

                    string strQueryInsertUser = "FMS_EXPENSE.SP_INSERT_EXPENSE_MASTER";
                    using (OracleCommand cmdInsertExpense = new OracleCommand())
                    {
                       // cmdInsertExpense.Transaction = tran;
                        cmdInsertExpense.Connection = con;
                        cmdInsertExpense.CommandText = strQueryInsertUser;
                        cmdInsertExpense.CommandType = CommandType.StoredProcedure;
                        cmdInsertExpense.Parameters.Add("E_EXPENSE_ID", OracleDbType.Int32).Value = strNextId1;
                        cmdInsertExpense.Parameters.Add("E_EXPAMOUNT", OracleDbType.Decimal).Value = ObjEntitySales.expAmount;
                        cmdInsertExpense.Parameters.Add("E_DATE", OracleDbType.Date).Value = ObjEntitySales.ExpDate;
                        cmdInsertExpense.Parameters.Add("E_REF", OracleDbType.Varchar2).Value = ObjEntitySales.ExpRef;
                        cmdInsertExpense.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntitySales.expOrgId;
                        cmdInsertExpense.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntitySales.expCorpId;
                        cmdInsertExpense.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = ObjEntitySales.expUserId;
                        cmdInsertExpense.Parameters.Add("E_DESC", OracleDbType.Varchar2).Value = ObjEntitySales.expDesc;


                        cmdInsertExpense.ExecuteNonQuery();
                    }
                    foreach (clsEntitySales objSaleList in ObjEntitySalesDetailList)
                    {

                        string strQueryInsertGrp = "FMS_EXPENSE.SP_INSERT_EXPENSE_DETAIL";
                        using (OracleCommand cmdInsertexpDtl = new OracleCommand())
                        {
                            //cmdInsertexpDtl.Transaction = tran;
                            cmdInsertexpDtl.Connection = con;
                            cmdInsertexpDtl.CommandText = strQueryInsertGrp;
                            cmdInsertexpDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertexpDtl.Parameters.Add("E_EXPENSEID", OracleDbType.Int32).Value = strNextId1;
                            cmdInsertexpDtl.Parameters.Add("E_SALESID", OracleDbType.Int32).Value = objSaleList.expSalesId;
                            cmdInsertexpDtl.Parameters.Add("E_LDGRID", OracleDbType.Int32).Value = objSaleList.expDtlLdgrId;
                            cmdInsertexpDtl.Parameters.Add("E_EXPDTLAMT", OracleDbType.Decimal).Value = objSaleList.expDtlAmt;
                            cmdInsertexpDtl.Parameters.Add("E_EXPDTL_DESC", OracleDbType.Varchar2).Value = objSaleList.expDtlDesc;

                            cmdInsertexpDtl.Parameters.Add("E_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdInsertexpDtl.ExecuteNonQuery();
                            strReturn = cmdInsertexpDtl.Parameters["E_OUT"].Value.ToString();
                            cmdInsertexpDtl.Dispose();
                            // cmdInsertprdt.ExecuteNonQuery();
                        }

                        foreach (clsEntitySales objSaleCCList in ObjEntitySalesPrdtList)
                        {
                            string strQueryInsertCC = "FMS_EXPENSE.SP_INSERT_EXPPRDT_DETAIL";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (objSaleList.SLnO == objSaleCCList.SLnO)
                                {
                                   // cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("E_EXPDTLID", OracleDbType.Int32).Value = strReturn;
                                    cmdInsertprdt.Parameters.Add("E_EXPENSE_ID", OracleDbType.Int32).Value = strNextId1;
                                    cmdInsertprdt.Parameters.Add("E_PRDTID", OracleDbType.Int32).Value = objSaleCCList.expPrdtId;
                                    cmdInsertprdt.Parameters.Add("E_EXPDTLAMT", OracleDbType.Decimal).Value = objSaleCCList.expPrdtAmt;
                                    cmdInsertprdt.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    //tran.Commit();
                }
                catch (Exception e)
                {
                    //tran.Rollback();
                    throw e;

                }

            }
        }

        public void UpdateExpenseDetls(clsEntitySales ObjEntitySales, List<clsEntitySales> ObjEntitySalesDetailList, List<clsEntitySales> ObjEntitySalesPrdtList, List<clsEntitySales> ObjEntitySalesDeleteList, List<clsEntitySales> ObjEntitySalesProductDeleteList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

           // OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
              //  tran = con.BeginTransaction();
                string strReturn = "";

                try
                {
                    string strQueryLeaveTyp = "FMS_EXPENSE.SP_UPDATE_EXPENSE_MASTER";
                    using (OracleCommand cmdInsertExpense = new OracleCommand())
                    {
                       // cmdInsertExpense.Transaction = tran;
                        cmdInsertExpense.Connection = con;
                        cmdInsertExpense.CommandText = strQueryLeaveTyp;
                        cmdInsertExpense.CommandType = CommandType.StoredProcedure;
                        cmdInsertExpense.Parameters.Add("E_EXPENSE_ID", OracleDbType.Int32).Value = ObjEntitySales.ExpenseId;
                        cmdInsertExpense.Parameters.Add("E_EXPAMOUNT", OracleDbType.Decimal).Value = ObjEntitySales.expAmount;
                        cmdInsertExpense.Parameters.Add("E_DATE", OracleDbType.Date).Value = ObjEntitySales.ExpDate;
                        cmdInsertExpense.Parameters.Add("E_REF", OracleDbType.Varchar2).Value = ObjEntitySales.ExpRef;
                        cmdInsertExpense.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntitySales.expOrgId;
                        cmdInsertExpense.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntitySales.expCorpId;
                        cmdInsertExpense.Parameters.Add("E_UPD_USR_ID", OracleDbType.Int32).Value = ObjEntitySales.expUserId;
                        cmdInsertExpense.Parameters.Add("E_DESC", OracleDbType.Varchar2).Value = ObjEntitySales.expDesc;
                        cmdInsertExpense.Parameters.Add("E_STS", OracleDbType.Int32).Value = ObjEntitySales.Status;
                        cmdInsertExpense.ExecuteNonQuery();
                    }

                    //on confirm
                    if (ObjEntitySales.Status == 1 && ObjEntitySales.expAmount > 0)
                    {
                        ////insert sales details to vocher account
                        //string strQueryInsertVoucher = "FMS_SALES.SP_INS_VOUCHER_ACCOUNT_SALES";
                        //using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        //{
                        //    cmdAddSubDetail.Transaction = tran;
                        //    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                        //    cmdAddSubDetail.Parameters.Add("S_SALES_ID", OracleDbType.Int32).Value = ObjEntitySales.SalesId;
                        //    cmdAddSubDetail.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = ObjEntitySales.NetTotal;
                        //    cmdAddSubDetail.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = ObjEntitySales.LedgerId;
                        //    cmdAddSubDetail.Parameters.Add("FINYR_ID", OracleDbType.Int32).Value = ObjEntitySales.FinancialYrId;
                        //    cmdAddSubDetail.ExecuteNonQuery();
                        //}
                    }

                    foreach (clsEntitySales objSaleList in ObjEntitySalesDetailList)
                    {
                        //Party update
                        if (objSaleList.expDtlId != 0)
                        {
                            strReturn = objSaleList.expDtlId.ToString();
                            string strQueryInsertGrp = "FMS_EXPENSE.SP_UPDATE_EXPENSE_DETAIL";
                            using (OracleCommand cmdInsertexpDtl = new OracleCommand())
                            {
                               // cmdInsertexpDtl.Transaction = tran;
                                cmdInsertexpDtl.Connection = con;
                                cmdInsertexpDtl.CommandText = strQueryInsertGrp;
                                cmdInsertexpDtl.CommandType = CommandType.StoredProcedure;
                                cmdInsertexpDtl.Parameters.Add("E_EXPENSEID", OracleDbType.Int32).Value = ObjEntitySales.ExpenseId;
                                cmdInsertexpDtl.Parameters.Add("E_EXPDTLID", OracleDbType.Int32).Value = objSaleList.expDtlId;
                                cmdInsertexpDtl.Parameters.Add("E_SALESID", OracleDbType.Int32).Value = objSaleList.expSalesId;
                                cmdInsertexpDtl.Parameters.Add("E_LDGRID", OracleDbType.Int32).Value = objSaleList.expDtlLdgrId;
                                cmdInsertexpDtl.Parameters.Add("E_EXPDTLAMT", OracleDbType.Decimal).Value = objSaleList.expDtlAmt;
                                cmdInsertexpDtl.Parameters.Add("E_EXPDTL_DESC", OracleDbType.Varchar2).Value = objSaleList.expDtlDesc;
                                cmdInsertexpDtl.Parameters.Add("E_STS", OracleDbType.Int32).Value = ObjEntitySales.Status;
                                cmdInsertexpDtl.ExecuteNonQuery();
                            }
                        }
                        else
                        {//Party insert
                            string strQueryInsertGrp = "FMS_EXPENSE.SP_INSERT_EXPENSE_DETAIL";
                            using (OracleCommand cmdInsertexpDtl = new OracleCommand())
                            {
                               // cmdInsertexpDtl.Transaction = tran;
                                cmdInsertexpDtl.Connection = con;
                                cmdInsertexpDtl.CommandText = strQueryInsertGrp;
                                cmdInsertexpDtl.CommandType = CommandType.StoredProcedure;
                                cmdInsertexpDtl.Parameters.Add("E_EXPENSEID", OracleDbType.Int32).Value = ObjEntitySales.ExpenseId;
                                cmdInsertexpDtl.Parameters.Add("E_SALESID", OracleDbType.Int32).Value = objSaleList.expSalesId;
                                cmdInsertexpDtl.Parameters.Add("E_LDGRID", OracleDbType.Int32).Value = objSaleList.expDtlLdgrId;
                                cmdInsertexpDtl.Parameters.Add("E_EXPDTLAMT", OracleDbType.Decimal).Value = objSaleList.expDtlAmt;
                                cmdInsertexpDtl.Parameters.Add("E_EXPDTL_DESC", OracleDbType.Varchar2).Value = objSaleList.expDtlDesc;

                                cmdInsertexpDtl.Parameters.Add("E_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdInsertexpDtl.ExecuteNonQuery();
                                strReturn = cmdInsertexpDtl.Parameters["E_OUT"].Value.ToString();
                                cmdInsertexpDtl.Dispose();
                            }
                        }


                        foreach (clsEntitySales objSaleCCList in ObjEntitySalesPrdtList)
                        {
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (objSaleList.SLnO == objSaleCCList.SLnO)
                                {
                                    //Prdct update
                                    if (objSaleCCList.expDtlId != 0)
                                    {
                                        string strQueryInsertCC = "FMS_EXPENSE.SP_UPDATE_EXPPRDT_DETAIL";
                                        //cmdInsertprdt.Transaction = tran;
                                        cmdInsertprdt.Connection = con;
                                        cmdInsertprdt.CommandText = strQueryInsertCC;
                                        cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                        cmdInsertprdt.Parameters.Add("E_EXPPRDT_DTLID", OracleDbType.Int32).Value = objSaleCCList.expDtlId;
                                        cmdInsertprdt.Parameters.Add("E_EXPDTLID", OracleDbType.Int32).Value = objSaleList.expDtlId;
                                        cmdInsertprdt.Parameters.Add("E_EXPENSE_ID", OracleDbType.Int32).Value = ObjEntitySales.ExpenseId;
                                        cmdInsertprdt.Parameters.Add("E_PRDTID", OracleDbType.Int32).Value = objSaleCCList.expPrdtId;
                                        cmdInsertprdt.Parameters.Add("E_EXPDTLAMT", OracleDbType.Decimal).Value = objSaleCCList.expPrdtAmt;
                                        cmdInsertprdt.ExecuteNonQuery();
                                    }
                                    else
                                    {//Prdct insert
                                        string strQueryInsertCC = "FMS_EXPENSE.SP_INSERT_EXPPRDT_DETAIL";
                                        //cmdInsertprdt.Transaction = tran;
                                        cmdInsertprdt.Connection = con;
                                        cmdInsertprdt.CommandText = strQueryInsertCC;
                                        cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                        cmdInsertprdt.Parameters.Add("E_EXPDTLID", OracleDbType.Int32).Value = strReturn;
                                        cmdInsertprdt.Parameters.Add("E_EXPENSE_ID", OracleDbType.Int32).Value = ObjEntitySales.ExpenseId;
                                        cmdInsertprdt.Parameters.Add("E_PRDTID", OracleDbType.Int32).Value = objSaleCCList.expPrdtId;
                                        cmdInsertprdt.Parameters.Add("E_EXPDTLAMT", OracleDbType.Decimal).Value = objSaleCCList.expPrdtAmt;
                                        cmdInsertprdt.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                    //Party delete
                    foreach (clsEntitySales objSaleList in ObjEntitySalesDeleteList)
                    {
                        string strQueryInsertGrp = "FMS_EXPENSE.SP_DELETE_EXPENSE_DETAIL";
                        using (OracleCommand cmdInsertexpDtl = new OracleCommand())
                        {
                            //cmdInsertexpDtl.Transaction = tran;
                            cmdInsertexpDtl.Connection = con;
                            cmdInsertexpDtl.CommandText = strQueryInsertGrp;
                            cmdInsertexpDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertexpDtl.Parameters.Add("E_EXPDTLID", OracleDbType.Int32).Value = objSaleList.expDtlId;
                            cmdInsertexpDtl.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                            cmdInsertexpDtl.ExecuteNonQuery();
                        }
                    }
                    //Prdct delete
                    foreach (clsEntitySales objSalePrdctList in ObjEntitySalesProductDeleteList)
                    {
                        string strQueryInsertGrp = "FMS_EXPENSE.SP_DELETE_EXPPRDT_DETAIL";
                        using (OracleCommand cmdInsertexpDtl = new OracleCommand())
                        {
                           // cmdInsertexpDtl.Transaction = tran;
                            cmdInsertexpDtl.Connection = con;
                            cmdInsertexpDtl.CommandText = strQueryInsertGrp;
                            cmdInsertexpDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertexpDtl.Parameters.Add("E_EXPDTLID", OracleDbType.Int32).Value = objSalePrdctList.expDtlId;
                            cmdInsertexpDtl.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
                            cmdInsertexpDtl.ExecuteNonQuery();
                        }
                    }

                   // tran.Commit();
                }

                catch (Exception e)
                {
                    //tran.Rollback();
                    throw e;

                }


            }
        }

        public void ReopenExpense(clsEntitySales ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_EXPENSE.SP_CONFIRM_REOPEN_EXPENSE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("E_EXPENSEID", OracleDbType.Int32).Value = ObjEntitySales.ExpenseId;
            cmdReadCustomerLdger.Parameters.Add("E_STATUS", OracleDbType.Int32).Value = ObjEntitySales.Status;
            cmdReadCustomerLdger.Parameters.Add("E_USERID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadCustomerLdger);
        }




    }
}
