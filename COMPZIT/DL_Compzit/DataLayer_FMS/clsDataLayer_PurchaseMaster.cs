using System;
using System.Collections.Generic;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using CL_Compzit;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Web;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_PurchaseMaster
    {
        public DataTable ReadCustomerLdger(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.LOAD_CUSTOMER_LDGR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadProductTax(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.LOAD_TAX_MSTR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_PRDTID", OracleDbType.Int32).Value = objEntityPurchase.ProductId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadProductLdger(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.LOAD_PRODUCT_MSTR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("SEARCH_TXT", OracleDbType.Varchar2).Value = objEntityPurchase.SearchString;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadBankLdger(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.LOAD_BANK_LDGR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public void InsertPurchaseMaster(clsEntityPurchaseMaster objEntityPurchase, List<clsEntityPurchaseMaster_list> objEntityPurchaseList, List<clsEntityPurchaseMaster> objEntityAttahmentList, List<clsEntityPurchaseMaster_list> ObjEntitySalesCCList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_PURCHASE_MSTR.SP_INS_PURCHASE_MSTR";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strReturn = "";
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                    
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PURCHASE_MASTER);
                        objEntCommon.CorporateID = objEntityPurchase.CorpId;
                        string strNextId1 = objDatatLayer.ReadNextNumber(objEntCommon);
                        string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntCommon);
                        objEntityPurchase.PurchaseId = Convert.ToInt32(strNextId1);
                        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                        intCorpId = objEntityPurchase.CorpId;
                        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
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
                      //  objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
                        int intOrgId = objEntityPurchase.OrgId;
                        DataTable dtFormate = readRefFormate(objEntCommon);

                        clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                        string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                        int DtYear = dtCurrentDate.Year;
                        int DtMonth = dtCurrentDate.Month;
                        string dtyy = dtCurrentDate.ToString("yy");

                        clsDataLayer objBusinessLayer = new clsDataLayer();
                        clsEntityCommon objEntityCommon = new clsEntityCommon();

                        objEntityCommon.Organisation_Id = objEntityPurchase.OrgId;
                        objEntityCommon.CorporateID = objEntityPurchase.CorpId;
                        objEntityCommon.FinancialYrId = objEntityPurchase.FinancialYrID;

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
                        if (dtFormate.Rows.Count > 0)
                        {
                            if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                            {
                                refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                                string strReferenceFormat = "";
                                strReferenceFormat = refFormatByDiv;
                                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                                int intArrayRowCount = arrReferenceSplit.Length;
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
                                        strRealFormat = strRealFormat.Replace("#USR#", objEntityPurchase.UserId.ToString());
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
                                objEntityPurchase.AccountRef = strRealFormat;

                            }
                        }
                        else
                        {
                        
                            objEntityPurchase.AccountRef = strNextId;
                        }
                        objEntityPurchase.SequenceRef = Convert.ToInt32(strNextId);
                        //CHECKING SUB REF NUMBER
                        string Ref = ""; int SubRef = 1;
                        if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

                            clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                            objEntityAudit.FromDate = objEntityPurchase.AccountDate;
                            objEntityAccnt.FromDate = objEntityPurchase.AccountDate;
                            clsEntityPurchaseMaster objEntityLayerStock1 = new clsEntityPurchaseMaster();
                            objEntityLayerStock1.FromDate = objEntityPurchase.AccountDate;
                            objEntityAccnt.Corporate_id = intCorpId;
                            objEntityLayerStock1.CorpId = intCorpId;
                            objEntityAccnt.Organisation_id = intOrgId;
                            objEntityLayerStock1.OrgId = intOrgId;
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
                                    if (dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                    {
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                    }
                                    objEntityLayerStock1.AccountRef= strRef;
                                    DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                    if (dtRefFormat.Rows.Count > 0)
                                    {
                                        Ref = dtRefFormat.Rows[0]["PURCHS_REF"].ToString();
                                        if (dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                        {
                                            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString());
                                            objEntityPurchase.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCHS_REF_SEQNUM"].ToString());

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
                                        objEntityPurchase.AccountRef = Ref;
                                        SubRef++;
                                    }
                                }
                            }
                        }
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                        cmdAddService.Parameters.Add("PR_REF", OracleDbType.Varchar2).Value = objEntityPurchase.AccountRef;
                        cmdAddService.Parameters.Add("PR_DATE", OracleDbType.Date).Value = objEntityPurchase.AccountDate;
                      //  cmdAddService.Parameters.Add("PR_ACC", OracleDbType.Int32).Value = objEntityPurchase.LedgerBank;
                        cmdAddService.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
                        if (objEntityPurchase.ExistingSplrsts == 0)
                        {
                         
                            cmdAddService.Parameters.Add("PR_SUP_NAME", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_ONE", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_TWO", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_THREE", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_NUM", OracleDbType.Varchar2).Value = null;

                        }
                        else
                        {
                       
                            cmdAddService.Parameters.Add("PR_SUP_NAME", OracleDbType.Varchar2).Value = objEntityPurchase.SplrName;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_ONE", OracleDbType.Varchar2).Value = objEntityPurchase.AddressOne;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_TWO", OracleDbType.Varchar2).Value = objEntityPurchase.AddressTwo;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_THREE", OracleDbType.Varchar2).Value = objEntityPurchase.AddressThree;
                            cmdAddService.Parameters.Add("PR_NUM", OracleDbType.Varchar2).Value = objEntityPurchase.ContactNumber;


                        }
                        cmdAddService.Parameters.Add("PR_SPL_STS", OracleDbType.Int32).Value = objEntityPurchase.ExistingSplrsts;
                        cmdAddService.Parameters.Add("PR_RECI", OracleDbType.Varchar2).Value = objEntityPurchase.ReceiptNo;
                        cmdAddService.Parameters.Add("PR_ORDR", OracleDbType.Varchar2).Value = objEntityPurchase.OrderNo;
                        cmdAddService.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
                        cmdAddService.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
                        cmdAddService.Parameters.Add("PR_USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;

                        cmdAddService.Parameters.Add("PR_GROS", OracleDbType.Decimal).Value = objEntityPurchase.GrossAmount;
                        cmdAddService.Parameters.Add("PR_TAXTL", OracleDbType.Decimal).Value = objEntityPurchase.TaxTotal;
                        cmdAddService.Parameters.Add("PR_DISTL", OracleDbType.Decimal).Value = objEntityPurchase.DiscountTotal;
                        cmdAddService.Parameters.Add("PR_NETTL", OracleDbType.Decimal).Value = objEntityPurchase.NetAmount;
                        cmdAddService.Parameters.Add("PR_STS", OracleDbType.Int32).Value = objEntityPurchase.AccountStatus;
                        cmdAddService.Parameters.Add("PR_CUR", OracleDbType.Int32).Value = objEntityPurchase.CurrencyId;
                        cmdAddService.Parameters.Add("PR_EXRATE", OracleDbType.Int32).Value = objEntityPurchase.ExchangeRate;
                        cmdAddService.Parameters.Add("PR_EXRATETL", OracleDbType.Decimal).Value = objEntityPurchase.TotalExchangeRate;
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("PR_FILE", OracleDbType.Int32).Value = objEntityPurchase.AttachmentStatus;
                        if (objEntityPurchase.Description != "")
                        {
                            cmdAddService.Parameters.Add("PR_DESCRPTN", OracleDbType.Varchar2).Value = objEntityPurchase.Description;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_DESCRPTN", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityPurchase.Terms != "")
                        {
                            cmdAddService.Parameters.Add("PR_TERM", OracleDbType.Varchar2).Value = objEntityPurchase.Terms;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = Convert.ToInt32(objEntityPurchase.SequenceRef);
                        //evm 0044
                        if (objEntityPurchase.CreditPeriod != 0)
                        {
                            cmdAddService.Parameters.Add("PR_CREDIT_PRD", OracleDbType.Int32).Value = objEntityPurchase.CreditPeriod;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_CREDIT_PRD", OracleDbType.Int32).Value = null;
                        }
                        //-----------
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntityPurchaseMaster objAttchDetail in objEntityAttahmentList)
                    {
                        string strQueryInsertAtcmntDtls = "FMS_PURCHASE_MSTR.SP_INS_PURCHASE_ATTACHMENT";
                        using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                        {
                            cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                            cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                            cmdInsertAtcmntDtls.Parameters.Add("S_FILE", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdInsertAtcmntDtls.Parameters.Add("S_ACTFILE", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdInsertAtcmntDtls.Parameters.Add("S_PID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdInsertAtcmntDtls.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityPurchaseMaster_list objSubDetail in objEntityPurchaseList)
                    {

                        string strQuerySubDetails = "FMS_PURCHASE_MSTR.SP_INS_PURCHASE_DTL";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdAddSubDetail.Parameters.Add("PR_PRDCT", OracleDbType.Int32).Value = objSubDetail.ProductId;
                            cmdAddSubDetail.Parameters.Add("PR_SL", OracleDbType.Int32).Value = objSubDetail.SlNo;
                            cmdAddSubDetail.Parameters.Add("PR_QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                            cmdAddSubDetail.Parameters.Add("PR_RATE", OracleDbType.Decimal).Value = objSubDetail.Rate;
                            if (objSubDetail.DiscountPercentage != 0 && objSubDetail.DiscountPercentage != null)
                            {
                                cmdAddSubDetail.Parameters.Add("PR_DIS", OracleDbType.Decimal).Value = objSubDetail.DiscountPercentage;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("PR_DIS", OracleDbType.Decimal).Value = 0;
                            }
                            
                                cmdAddSubDetail.Parameters.Add("PR_DISAMT", OracleDbType.Decimal).Value = objSubDetail.DiscountAmount;
                           

                            if (objSubDetail.Tax != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("PR_TAX", OracleDbType.Decimal).Value = objSubDetail.Tax;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("PR_TAX", OracleDbType.Decimal).Value = null;
                            }
                            
                            cmdAddSubDetail.Parameters.Add("PR_TAXAMT", OracleDbType.Decimal).Value = objSubDetail.TaxAmount;

                            cmdAddSubDetail.Parameters.Add("PR_PRIC", OracleDbType.Decimal).Value = objSubDetail.Price;
                            cmdAddSubDetail.Parameters.Add("S_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remark;
                            cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddSubDetail.ExecuteNonQuery();
                            strReturn = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();
                            cmdAddSubDetail.Dispose();
                        }


                        foreach (clsEntityPurchaseMaster_list objSaleCCList in ObjEntitySalesCCList)
                        {
                            string strQueryInsertCC = "FMS_PURCHASE_MSTR.SP_INSERT_PURCHASE_CC_DTLS";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (objSubDetail.ProductId == objSaleCCList.ProductId && objSubDetail.SlNo == objSaleCCList.SlNo)
                                {
                                    cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("S_PURCHS_ID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
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

                    tran.Commit();

                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }


            }
        }

        public void UpdatePurchaseMaster(clsEntityPurchaseMaster objEntityPurchase, List<clsEntityPurchaseMaster_list> objEntityPurchaseList, List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Update, List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Delete, List<clsEntityPurchaseMaster> objEntityAttahmentList, List<clsEntityPurchaseMaster> objEntityDeleteAttchmntList, List<clsEntityPurchaseMaster_list> ObjEntitySalesCCList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strQueryLeaveTyp = "FMS_PURCHASE_MSTR.SP_UPD_PURCHASE_MSTR";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                string strReturn = "";
                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        string Ref = ""; int SubRef = 1;
                        if (objEntityPurchase.AccountDate != objEntityPurchase.PurchaseDateInUpd)
                        {
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PURCHASE_MASTER);
                            objEntCommon.CorporateID = objEntityPurchase.CorpId;
                            //CHECKING FOR CORP GLOBAL SUB REF STATUS
                            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                            intCorpId = objEntityPurchase.CorpId;
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
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
                            int intOrgId = objEntityPurchase.OrgId;
                            int intUsrId = objEntityPurchase.UserId;
                            //  objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Credit_Note);
                            DataTable dtFormate = readRefFormate(objEntCommon);
                            clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                            string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                            int DtYear = dtCurrentDate.Year;
                            int DtMonth = dtCurrentDate.Month;
                            //CHECKING SUB REF NUMBER
                            if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

                                clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAudit.FromDate = objEntityPurchase.AccountDate;
                                objEntityAccnt.FromDate = objEntityPurchase.AccountDate;
                                clsEntityPurchaseMaster objEntityLayerStock1 = new clsEntityPurchaseMaster();
                                objEntityLayerStock1.FromDate = objEntityPurchase.AccountDate;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityLayerStock1.CorpId = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityLayerStock1.OrgId = intOrgId;
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
                                        if (dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                        }
                                        objEntityLayerStock1.AccountRef = strRef;
                                        DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            if (objEntityPurchase.PurchaseId != Convert.ToInt32(dtRefFormat.Rows[0]["PURCHS_ID"].ToString()))
                                            {
                                                Ref = dtRefFormat.Rows[0]["PURCHS_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString());
                                                    objEntityPurchase.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCHS_REF_SEQNUM"].ToString());
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
                                                objEntityPurchase.AccountRef = Ref;
                                                SubRef++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                        if (objEntityPurchase.AccountRef != "")
                        {
                            cmdAddService.Parameters.Add("PR_REF", OracleDbType.Varchar2).Value = objEntityPurchase.AccountRef;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_REF", OracleDbType.Varchar2).Value = null;
                        }
                        cmdAddService.Parameters.Add("PR_DATE", OracleDbType.Date).Value = objEntityPurchase.AccountDate;
                        cmdAddService.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;

                        if (objEntityPurchase.ExistingSplrsts == 0)
                        {
                            cmdAddService.Parameters.Add("PR_SUP_NAME", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_ONE", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_TWO", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_THREE", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("PR_NUM", OracleDbType.Varchar2).Value = null;
                        }
                        else
                        {

                            cmdAddService.Parameters.Add("PR_SUP_NAME", OracleDbType.Varchar2).Value = objEntityPurchase.SplrName;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_ONE", OracleDbType.Varchar2).Value = objEntityPurchase.AddressOne;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_TWO", OracleDbType.Varchar2).Value = objEntityPurchase.AddressTwo;
                            cmdAddService.Parameters.Add("PR_SUP_ADD_THREE", OracleDbType.Varchar2).Value = objEntityPurchase.AddressThree;
                            cmdAddService.Parameters.Add("PR_NUM", OracleDbType.Varchar2).Value = objEntityPurchase.ContactNumber;
                        }

                        cmdAddService.Parameters.Add("PR_SPL_STS", OracleDbType.Int32).Value = objEntityPurchase.ExistingSplrsts;

                        if (objEntityPurchase.ReceiptNo != "")
                        {
                            cmdAddService.Parameters.Add("PR_RECI", OracleDbType.Varchar2).Value = objEntityPurchase.ReceiptNo;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_RECI", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityPurchase.OrderNo != "")
                        {
                            cmdAddService.Parameters.Add("PR_ORDR", OracleDbType.Varchar2).Value = objEntityPurchase.OrderNo;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_ORDR", OracleDbType.Varchar2).Value = null;
                        }

                        cmdAddService.Parameters.Add("PR_USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;
                        cmdAddService.Parameters.Add("PR_GROS", OracleDbType.Decimal).Value = objEntityPurchase.GrossAmount;
                        cmdAddService.Parameters.Add("PR_TAXTL", OracleDbType.Decimal).Value = objEntityPurchase.TaxTotal;
                        cmdAddService.Parameters.Add("PR_DISTL", OracleDbType.Decimal).Value = objEntityPurchase.DiscountTotal;
                        cmdAddService.Parameters.Add("PR_NETTL", OracleDbType.Decimal).Value = objEntityPurchase.NetAmount;
                        if (objEntityPurchase.ConfirmStatus == 1)
                        {
                            cmdAddService.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = objEntityPurchase.BalanceAmount;
                            cmdAddService.Parameters.Add("PR_CNFRM_USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;
                            cmdAddService.Parameters.Add("PR_CNFRM_DATE", OracleDbType.Date).Value = objEntityPurchase.ConfirmDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = 0;
                            cmdAddService.Parameters.Add("PR_CNFRM_USRID", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("PR_CNFRM_DATE", OracleDbType.Date).Value = null;
                        }
                        cmdAddService.Parameters.Add("PR_STS", OracleDbType.Int32).Value = objEntityPurchase.AccountStatus;
                        cmdAddService.Parameters.Add("PR_CONFRM", OracleDbType.Int32).Value = objEntityPurchase.ConfirmStatus;
                        cmdAddService.Parameters.Add("PR_CUR", OracleDbType.Int32).Value = objEntityPurchase.CurrencyId;
                        cmdAddService.Parameters.Add("PR_EXRATE", OracleDbType.Int32).Value = objEntityPurchase.ExchangeRate;
                        cmdAddService.Parameters.Add("PR_EXRATETL", OracleDbType.Decimal).Value = objEntityPurchase.TotalExchangeRate;
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("PR_FILE", OracleDbType.Int32).Value = objEntityPurchase.AttachmentStatus;
                        cmdAddService.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                        if (objEntityPurchase.Description != "")
                        {
                            cmdAddService.Parameters.Add("PR_DESCRPTN", OracleDbType.Varchar2).Value = objEntityPurchase.Description;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_DESCRPTN", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityPurchase.Terms != "")
                        {
                            cmdAddService.Parameters.Add("PR_TERM", OracleDbType.Varchar2).Value = objEntityPurchase.Terms;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_TERM", OracleDbType.Varchar2).Value = null;
                        }
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = objEntityPurchase.SequenceRef;
                        //evm 0044
                        if (objEntityPurchase.CreditPeriod != 0)
                        {
                            cmdAddService.Parameters.Add("PR_CREDIT_PRD", OracleDbType.Int32).Value = objEntityPurchase.CreditPeriod;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("PR_CREDIT_PRD", OracleDbType.Int32).Value = null;
                        }
                        //----------
                        cmdAddService.ExecuteNonQuery();
                    }

                    //on confirm
                    if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                    {
                        //insert purchase details to vocher account
                        string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_INS_VOUCHER_ACCOUNT_PURCHS";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdAddSubDetail.Parameters.Add("PR_REF", OracleDbType.Varchar2).Value = objEntityPurchase.AccountRef;
                            cmdAddSubDetail.Parameters.Add("PR_DATE", OracleDbType.Date).Value = objEntityPurchase.AccountDate;
                            cmdAddSubDetail.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
                            cmdAddSubDetail.Parameters.Add("PR_NETTL", OracleDbType.Decimal).Value = objEntityPurchase.NetAmount;
                            cmdAddSubDetail.Parameters.Add("PR_DESCRPTN", OracleDbType.Varchar2).Value = objEntityPurchase.Description;
                            cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }

                    //delete all products by prodctid
                    foreach (clsEntityPurchaseMaster_list objSubDetail in ObjEntityPurchaseList_Delete)
                    {
                        {
                            string strQueryChangeStatus = "FMS_PURCHASE_MSTR.SP_DEL_PURCHASE_DTL";
                            using (OracleCommand cmdChangeStatus = new OracleCommand())
                            {
                                cmdChangeStatus.Connection = con;
                                cmdChangeStatus.Transaction = tran;
                                cmdChangeStatus.CommandText = strQueryChangeStatus;
                                cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                cmdChangeStatus.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;
                                cmdChangeStatus.ExecuteNonQuery();
                            }
                        }
                    }

                    decimal decTotalAmnt = 0;

                    //insert products
                    foreach (clsEntityPurchaseMaster_list objSubDetail in objEntityPurchaseList)
                    {
                        string strQuerySubDetails = "FMS_PURCHASE_MSTR.SP_INS_PURCHASE_DTL";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdAddSubDetail.Parameters.Add("PR_PRDCT", OracleDbType.Int32).Value = objSubDetail.ProductId;
                            cmdAddSubDetail.Parameters.Add("PR_SL", OracleDbType.Int32).Value = objSubDetail.SlNo;
                            cmdAddSubDetail.Parameters.Add("PR_QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                            cmdAddSubDetail.Parameters.Add("PR_RATE", OracleDbType.Decimal).Value = objSubDetail.Rate;
                            if (objSubDetail.DiscountPercentage != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("PR_DIS", OracleDbType.Decimal).Value = objSubDetail.DiscountPercentage;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("PR_DIS", OracleDbType.Decimal).Value = null;
                            }

                            cmdAddSubDetail.Parameters.Add("PR_DISAMT", OracleDbType.Decimal).Value = objSubDetail.DiscountAmount;

                            if (objSubDetail.Tax != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("PR_TAX", OracleDbType.Decimal).Value = objSubDetail.Tax;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("PR_TAX", OracleDbType.Decimal).Value = null;
                            }

                            cmdAddSubDetail.Parameters.Add("PR_TAXAMT", OracleDbType.Decimal).Value = objSubDetail.TaxAmount;
                            cmdAddSubDetail.Parameters.Add("PR_PRIC", OracleDbType.Decimal).Value = objSubDetail.Price;
                            cmdAddSubDetail.Parameters.Add("S_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remark;
                            cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddSubDetail.ExecuteNonQuery();
                            strReturn = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();
                            cmdAddSubDetail.Dispose();

                            objSubDetail.PurchaseProductId = Convert.ToInt32(strReturn);

                            decTotalAmnt = decTotalAmnt + objSubDetail.Price;
                        }

                        //on confirm
                        if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                objEntityPurchase.VoucherId = Convert.ToInt32(strVReturn);
                            }
                        }

                        //insert cost centres for products
                        foreach (clsEntityPurchaseMaster_list objSaleCCList in ObjEntitySalesCCList)
                        {
                            string strQueryInsertCC = "FMS_PURCHASE_MSTR.SP_INSERT_PURCHASE_CC_DTLS";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (objSubDetail.ProductId == objSaleCCList.ProductId && objSubDetail.SlNo == objSaleCCList.SlNo)
                                {
                                    cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("S_PURCHS_ID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
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

                        //on confirm
                        if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                        {
                            //insert into cost centre vocher table
                            string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                                cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = objEntityPurchase.VoucherId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }

                    }

                    //update products
                    foreach (clsEntityPurchaseMaster_list objSubDetail in ObjEntityPurchaseList_Update)
                    {
                        string strQuerySubDetails = "FMS_PURCHASE_MSTR.SP_UPD_PURCHASE_DTL";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdAddSubDetail.Parameters.Add("PR_PRDCT", OracleDbType.Int32).Value = objSubDetail.ProductId;
                            cmdAddSubDetail.Parameters.Add("PR_SL", OracleDbType.Int32).Value = objSubDetail.SlNo;
                            cmdAddSubDetail.Parameters.Add("PR_QNTY", OracleDbType.Decimal).Value = objSubDetail.Quantity;
                            cmdAddSubDetail.Parameters.Add("PR_RATE", OracleDbType.Decimal).Value = objSubDetail.Rate;
                            if (objSubDetail.DiscountPercentage != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("PR_DIS", OracleDbType.Decimal).Value = objSubDetail.DiscountPercentage;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("PR_DIS", OracleDbType.Decimal).Value = null;
                            }
                            cmdAddSubDetail.Parameters.Add("PR_DISAMT", OracleDbType.Decimal).Value = objSubDetail.DiscountAmount;
                            if (objSubDetail.Tax != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("PR_TAX", OracleDbType.Decimal).Value = objSubDetail.Tax;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("PR_TAX", OracleDbType.Decimal).Value = null;
                            }

                            cmdAddSubDetail.Parameters.Add("PR_TAXAMT", OracleDbType.Decimal).Value = objSubDetail.TaxAmount;
                            cmdAddSubDetail.Parameters.Add("PR_PRIC", OracleDbType.Decimal).Value = objSubDetail.Price;
                            cmdAddSubDetail.Parameters.Add("S_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remark;
                            cmdAddSubDetail.ExecuteNonQuery();

                            decTotalAmnt = decTotalAmnt + objSubDetail.Price;
                        }

                        //on confirm
                        if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                objEntityPurchase.VoucherId = Convert.ToInt32(strVReturn);
                            }
                        }

                        //update cost centres for products
                        foreach (clsEntityPurchaseMaster_list objSaleCCList in ObjEntitySalesCCList)
                        {
                            string strQueryInsertCC = "FMS_PURCHASE_MSTR.SP_INSERT_PURCHASE_CC_DTLS";
                            using (OracleCommand cmdInsertprdt = new OracleCommand())
                            {
                                if (objSubDetail.ProductId == objSaleCCList.ProductId && objSubDetail.SlNo == objSaleCCList.SlNo)
                                {
                                    cmdInsertprdt.Transaction = tran;
                                    cmdInsertprdt.Connection = con;
                                    cmdInsertprdt.CommandText = strQueryInsertCC;
                                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                                    cmdInsertprdt.Parameters.Add("S_PURCHS_ID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                    cmdInsertprdt.Parameters.Add("S_PRDCT_ID", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
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

                        //on confirm
                        if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                        {
                            //insert into cost centre vocher table
                            string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                                cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = objEntityPurchase.VoucherId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }

                    }

                    //on confirm
                    if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                    {
                        //update if difference in total amount present in vocher and add to ledger details table
                        string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_UPD_VOUCHER_ACCNT_DIFFAMNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }


                    //delete products
                    foreach (clsEntityPurchaseMaster_list objSubDetail in ObjEntityPurchaseList_Delete)
                    {
                        {
                            string strQueryChangeStatus = "FMS_PURCHASE_MSTR.SP_DEL_PURCHASE_DTL";
                            using (OracleCommand cmdChangeStatus = new OracleCommand())
                            {
                                cmdChangeStatus.Connection = con;
                                cmdChangeStatus.Transaction = tran;
                                cmdChangeStatus.CommandText = strQueryChangeStatus;
                                cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                cmdChangeStatus.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;
                                cmdChangeStatus.ExecuteNonQuery();
                            }
                        }
                    }

                    //insert attachments
                    foreach (clsEntityPurchaseMaster objAttchDetail in objEntityAttahmentList)
                    {
                        string strQueryInsertAtcmntDtls = "FMS_PURCHASE_MSTR.SP_INS_PURCHASE_ATTACHMENT";
                        using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                        {
                            cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                            cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                            cmdInsertAtcmntDtls.Parameters.Add("S_FILE", OracleDbType.Varchar2).Value = objAttchDetail.FileName;
                            cmdInsertAtcmntDtls.Parameters.Add("S_ACTFILE", OracleDbType.Varchar2).Value = objAttchDetail.ActualFileName;
                            cmdInsertAtcmntDtls.Parameters.Add("S_PID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdInsertAtcmntDtls.ExecuteNonQuery();
                        }
                    }
                    //delete attachments
                    foreach (clsEntityPurchaseMaster objAttchDetail in objEntityDeleteAttchmntList)
                    {
                        string strQueryInsertAtcmntDtls = "FMS_PURCHASE_MSTR.SP_DEL_PURCHASE_ATTACHMENT";
                        using (OracleCommand cmdInsertAtcmntDtls = new OracleCommand(strQueryInsertAtcmntDtls, con))
                        {
                            cmdInsertAtcmntDtls.CommandText = strQueryInsertAtcmntDtls;
                            cmdInsertAtcmntDtls.CommandType = CommandType.StoredProcedure;
                            cmdInsertAtcmntDtls.Parameters.Add("S_PID", OracleDbType.Int32).Value = objAttchDetail.AttachmentId;
                            cmdInsertAtcmntDtls.ExecuteNonQuery();
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
       
        public DataTable ReadPurchseOnList(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_PURCHSE_LIST";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_CANCEL", OracleDbType.Int32).Value = objEntityPurchase.CancelStatus;
            cmdReadCustomerLdger.Parameters.Add("PR_STS", OracleDbType.Int32).Value = objEntityPurchase.AccountStatus;

            //0039

            //----------pagination--------//
            cmdReadCustomerLdger.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityPurchase.CommonSearchTerm;
            cmdReadCustomerLdger.Parameters.Add("P_SEARCH_REF", OracleDbType.Varchar2).Value = objEntityPurchase.SearchRef;
            cmdReadCustomerLdger.Parameters.Add("P_SEARCH_DATE", OracleDbType.Varchar2).Value = objEntityPurchase.SearchDate;
            cmdReadCustomerLdger.Parameters.Add("P_SEARCH_CUST", OracleDbType.Varchar2).Value = objEntityPurchase.SearchSuppl;
            cmdReadCustomerLdger.Parameters.Add("P_SEARCH_AMNT", OracleDbType.Varchar2).Value = objEntityPurchase.SearchAmount;

            cmdReadCustomerLdger.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityPurchase.OrderColumn;
            cmdReadCustomerLdger.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityPurchase.OrderMethod;
            cmdReadCustomerLdger.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityPurchase.PageMaxSize;
            cmdReadCustomerLdger.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityPurchase.PageNumber;
            //---------------pagination------------//
            //end
            
            
            
            
            
            
            if (objEntityPurchase.FromDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("FROMDT", OracleDbType.Date).Value = objEntityPurchase.FromDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("FROMDT", OracleDbType.Date).Value = null;
            }
            if (objEntityPurchase.ToDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("TODT", OracleDbType.Date).Value = objEntityPurchase.ToDate;
            }
            else{
                cmdReadCustomerLdger.Parameters.Add("TODT", OracleDbType.Date).Value = null;
                }
            if (objEntityPurchase.StartDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = objEntityPurchase.StartDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityPurchase.EndDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = objEntityPurchase.EndDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadCustomerLdger.Parameters.Add("PR_PUR_STS", OracleDbType.Int32).Value = objEntityPurchase.ConfirmStatus;

            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
       
        public DataTable ReadPurchaseById(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_PURCHASE_BYID";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadProductPurchaseById(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_PRODUCTS_BYID";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public void CancelProductMaster(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQuerylWelfare = "FMS_PURCHASE_MSTR.SP_DEL_PURCHASE_MSTR";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;
                cmdlWelfare.Parameters.Add("W_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityPurchase.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public void ChangeProducStatus(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQuerylWelfare = "FMS_PURCHASE_MSTR.SP_UPD_CHANGE_STATUS";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                cmdlWelfare.Parameters.Add("PR_STATUS", OracleDbType.Int32).Value = objEntityPurchase.AccountStatus;
                cmdlWelfare.Parameters.Add("PR_UPDUSERID", OracleDbType.Varchar2).Value = objEntityPurchase.UserId;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public DataTable ChkProductMasterIsCancel(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_CHK_PURCHASE_CANCEL";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ChkProductMasterIsCnfrm(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_CHK_PURCHASE_CNFRM";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadCurrencies(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadEmpSlry = "FMS_PURCHASE_MSTR.SP_READ_CURRENCIES";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ProductSearchItems(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strCommandSearch = "FMS_PURCHASE_MSTR.SP_SEARCH_ITEMS";
            OracleCommand cmdReadSearch = new OracleCommand();
            cmdReadSearch.CommandText = strCommandSearch;
            cmdReadSearch.CommandType = CommandType.StoredProcedure;
            cmdReadSearch.Parameters.Add("ORG_ID", SqlDbType.Int).Value = objEntityPurchase.OrgId;
            cmdReadSearch.Parameters.Add("CORPT_ID", SqlDbType.Int).Value = objEntityPurchase.CorpId;
            cmdReadSearch.Parameters.Add("SEARCH_TXT", SqlDbType.VarChar).Value = objEntityPurchase.SearchString;
            //  cmdReadSearch.Parameters.Add("SEARCH_TYPE", SqlDbType.VarChar).Value = objEntityBook.SearchType;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadSearch);
            return dtEmpSlry;
        }
        public DataTable ReadSupplierCredits(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadEmpSlry = "FMS_PURCHASE_MSTR.SP_READ_SUPPLIER_CREDITS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadPayGrd.Parameters.Add("PR_SUP", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
            cmdReadPayGrd.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadPaymentCash(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadEmpSlry = "FMS_PURCHASE_MSTR.SP_READ_PAYMENT_CASH";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("PR_SUP", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
            cmdReadPayGrd.Parameters.Add("PR_DATE", OracleDbType.Date).Value = objEntityPurchase.AccountDate;
            cmdReadPayGrd.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }


        public DataTable ReadDefultLdgr(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_DFLT_LDGR";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_MOD_ID", OracleDbType.Int32).Value = objEntityPurchase.ActModeId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable readRefFormate(clsEntityCommon objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_RD_REF_FORMAT";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_MOD_ID", OracleDbType.Int32).Value = objEntityPurchase.SectionId;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable chkOrderNoDuplication(clsEntityPurchaseMaster objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_PURCHASE_MSTR.SP_CHECK_DUP_NAME";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.PurchaseId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_DATE", OracleDbType.Date).Value = objEntityEmpSlry.FromDate;
            
            cmdReadPayGrd.Parameters.Add("L_ORDER_NO", OracleDbType.Varchar2).Value = objEntityEmpSlry.OrderNo;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadRefNumberByDate(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_RD_REF_BYDATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = objEntityPurchase.FromDate;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadRefNumberByDateLast(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_RD_REF_BYDATE_LAST";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = objEntityPurchase.AccountRef;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public void ReopenPurchase(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQuerylWelfare = "FMS_PURCHASE_MSTR.REOPEN_PURCHASE_BYID";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                cmdlWelfare.Parameters.Add("PR_BAL", OracleDbType.Decimal).Value = objEntityPurchase.NetAmount;
                cmdlWelfare.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
                cmdlWelfare.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.UserId;

                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }

        public DataTable ReadCorpDtls(clsEntityPurchaseMaster ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_PURCHASE_MSTR.SP_READ_CORP_DTLS";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.OrgId;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorpId;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;
        }
        public DataTable ReadProductName(clsEntityPurchaseMaster ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_RD_PRDT_NAME";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorpId;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.OrgId;
            cmdReadCustomerLdger.Parameters.Add("S_PID", OracleDbType.Varchar2).Value = ObjEntitySales.ProductId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;

        }
        public DataTable ReadAttachmentById(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_REDA_ATTACHMENT_BYID";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_PID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public void ConfirmPurchase(clsEntityPurchaseMaster objEntityPurchase, List<clsEntityPurchaseMaster_list> objEntityPurchaseList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQuerylWelfare = "FMS_PURCHASE_MSTR.SP_CONFRM_PURCHASE";
                    using (OracleCommand cmdlWelfare = new OracleCommand(strQuerylWelfare, con))
                    {
                        cmdlWelfare.Transaction = tran;
                        cmdlWelfare.CommandType = CommandType.StoredProcedure;
                        cmdlWelfare.Parameters.Add("S_PID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                        cmdlWelfare.Parameters.Add("S_CORPID", OracleDbType.Decimal).Value = objEntityPurchase.OrgId;
                        cmdlWelfare.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
                        cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPurchase.UserId;
                        cmdlWelfare.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                        cmdlWelfare.ExecuteNonQuery();
                    }

                    //on confirm
                    if (objEntityPurchase.ConfirmStatus == 1 && objEntityPurchase.NetAmount > 0)
                    {
                        //insert purchase details to vocher account
                        string strQueryInsertVoucher = "FMS_PURCHASE_MSTR.SP_INS_VOUCHER_ACCOUNT_PURCHS";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                            cmdAddSubDetail.Parameters.Add("PR_REF", OracleDbType.Varchar2).Value = objEntityPurchase.AccountRef;
                            cmdAddSubDetail.Parameters.Add("PR_DATE", OracleDbType.Date).Value = objEntityPurchase.AccountDate;
                            cmdAddSubDetail.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
                            cmdAddSubDetail.Parameters.Add("PR_NETTL", OracleDbType.Decimal).Value = objEntityPurchase.NetAmount;
                            cmdAddSubDetail.Parameters.Add("PR_DESCRPTN", OracleDbType.Varchar2).Value = objEntityPurchase.Description;
                            cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //products
                        foreach (clsEntityPurchaseMaster_list objSubDetail in objEntityPurchaseList)
                        {
                            //insert product details to vocher account
                            string strQueryInsertVoucherPdct = "FMS_PURCHASE_MSTR.SP_INS_VOUCHER_ACCOUNT_PRODUCT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherPdct, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                                cmdAddSubDetail.Parameters.Add("P_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddSubDetail.ExecuteNonQuery();
                                string strVReturn = cmdAddSubDetail.Parameters["P_ID"].Value.ToString();
                                cmdAddSubDetail.Dispose();
                                objEntityPurchase.VoucherId = Convert.ToInt32(strVReturn);
                            }

                            //insert into cost centre vocher table
                            string strQueryInsertVoucherCC = "FMS_PURCHASE_MSTR.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherCC, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
                                cmdAddSubDetail.Parameters.Add("PR_PRCHSPRDCT", OracleDbType.Int32).Value = objSubDetail.PurchaseProductId;
                                cmdAddSubDetail.Parameters.Add("PR_YRID", OracleDbType.Int32).Value = objEntityPurchase.FinancialYrID;
                                cmdAddSubDetail.Parameters.Add("PR_VOUCHERID", OracleDbType.Int32).Value = objEntityPurchase.VoucherId;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                        }

                        //update if difference in total amount present in vocher and add to ledger details table
                        string strQueryInsertVoucherDiff = "FMS_PURCHASE_MSTR.SP_UPD_VOUCHER_ACCNT_DIFFAMNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherDiff, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
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

        public DataTable ReadPrintVersion(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_DEFLT_PRINT_VERSION";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("R_MODID", OracleDbType.Int32).Value = objEntityPurchase.ActModeId;
            
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadBankDetails(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_BANK_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_LDGRID", OracleDbType.Int32).Value = objEntityPurchase.LedgerBank;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadPurchaseCCDetails(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_PURCHASE_CC_DTLS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("R_PURCHSID", OracleDbType.Int32).Value = objEntityPurchase.PurchaseId;
            cmdReadCustomerLdger.Parameters.Add("R_PDCTID", OracleDbType.Int32).Value = objEntityPurchase.ProductId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadPurchseOnList_Sum(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadCustomerLdger = "FMS_PURCHASE_MSTR.SP_READ_PURCHSE_LIST_SUM";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_CUST", OracleDbType.Int32).Value = objEntityPurchase.LedgerCustomer;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPurchase.OrgId;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPurchase.CorpId;
            cmdReadCustomerLdger.Parameters.Add("PR_CANCEL", OracleDbType.Int32).Value = objEntityPurchase.CancelStatus;
            cmdReadCustomerLdger.Parameters.Add("PR_STS", OracleDbType.Int32).Value = objEntityPurchase.AccountStatus;
            if (objEntityPurchase.FromDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("FROMDT", OracleDbType.Date).Value = objEntityPurchase.FromDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("FROMDT", OracleDbType.Date).Value = null;
            }
            if (objEntityPurchase.ToDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("TODT", OracleDbType.Date).Value = objEntityPurchase.ToDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("TODT", OracleDbType.Date).Value = null;
            }
            if (objEntityPurchase.StartDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = objEntityPurchase.StartDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityPurchase.EndDate != DateTime.MinValue)
            {
                cmdReadCustomerLdger.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = objEntityPurchase.EndDate;
            }
            else
            {
                cmdReadCustomerLdger.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadCustomerLdger.Parameters.Add("PR_PUR_STS", OracleDbType.Int32).Value = objEntityPurchase.ConfirmStatus;

            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        //evm 0044
        public DataTable ReadSupplierCreditsById(clsEntityPurchaseMaster objEntityPurchase)
        {
            string strQueryReadSupCrdts = "FMS_PURCHASE_MSTR.SP_RD_SUPPLIER_CREDITS_BYID";
            OracleCommand cmdReadSupCrdts = new OracleCommand();
            cmdReadSupCrdts.CommandText = strQueryReadSupCrdts;
            cmdReadSupCrdts.CommandType = CommandType.StoredProcedure;
            cmdReadSupCrdts.Parameters.Add("PR_SUPID", OracleDbType.Int32).Value = objEntityPurchase.LedgerId;
            cmdReadSupCrdts.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadSupCrdts);
            return dtEmpSlry;
        }
        //-------------



    }
}
