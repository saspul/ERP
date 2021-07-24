using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.Script.Serialization;

public partial class FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account_List : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //ddlAccount.Focus();

        if (!IsPostBack)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objentcommn = new clsEntityCommon();

          
            AccountLedgerLoad();
            LeadgerLoad();
            clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                // objEntity.UserId = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {

                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());


            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


           

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                         clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,};
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {

                HiddenCurrrencyAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();

            }
            int intUsrRolMstrId = 0, intEnableAdd = 0, intRecurr = 0;
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenConfirmStatus.Value = "0";
        
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        // intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableModify.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        // intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenProvisionSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        HiddenReopenSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenAuditProvisionStatus.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenConfirmStatus.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        intRecurr = 1;
                        HiddenFieldRecurrRole.Value = "1";
                    }
                }

            }

            if (HiddenFieldRecurrRole.Value == "1")
            {
                string[] strHtmlRet = new string[2];
                strHtmlRet = LoadPendingOrders(intUserId, intOrgId, intCorpId);
                if (strHtmlRet[0] != "" && strHtmlRet[0] != null)
                {
                    sPendOrdNum.InnerText = strHtmlRet[0];
                    menu1.Attributes.Add("style", "display:block");
                }
                else
                {
                    menu1.Attributes.Add("style", "display:none");
                }
                myTable.InnerHtml = strHtmlRet[1];
            }
            else
            {
                menu1.Attributes.Add("style", "display:none");
            }


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (strInsUpd == "StsCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessStatusChange", "SuccessStatusChange();", true);
                }
                else if (strInsUpd == "Cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelation", "SuccessCancelation();", true);
                }
                else if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "CnfrmCncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNotConfirmation", "SuccessNotConfirmation();", true);
                }
                else if (strInsUpd == "AlCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessAlreadyCancel", "SuccessAlreadyCancel();", true);
                }
                else if (strInsUpd == "ChkNo")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChequeNumberDuplicationMsg", "ChequeNumberDuplicationMsg();", true);
                }
                else if (Request.QueryString["InsUpd"] == "UpdCancl")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDeleted", "SuccessDeleted();", true);
                }
                else if (Request.QueryString["InsUpd"] == "AcntClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AcntClosed", "AcntClosed();", true);
                }
                else if (Request.QueryString["InsUpd"] == "AuditClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AuditClosed", "AuditClosed();", true);
                }

            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }

            if (Session["FINCYRID"] != null)
            {
                objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);
            if (dtfinaclYear.Rows.Count > 0)
            {
                ObjEntityRequest.FromDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                ObjEntityRequest.ToDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());

                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
                DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objentcommn);
                DateTime startDate = new DateTime();
    

                DateTime curntdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());


                if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtTodate.Value = objBusinessLayer.LoadCurrentDateInString();
                    curntdate = curntdate.AddDays(-30);
                    if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromdate.Value = curntdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }
                else
                {
                    txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    curntdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                    curntdate = curntdate.AddDays(-30);
                    if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromdate.Value = curntdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }



            }
            if (dtfinaclYear.Rows.Count > 0)
            {
                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
                DateTime acntClsDate = DateTime.MinValue;
                int YearEndCls = 0;

                if (Session["FINCYRID"] != null)
                {
                    objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                DataTable dtYearEndClsDate = objBusinessLayer.ReadYearEndCloseDate(objentcommn);
                if (dtYearEndClsDate.Rows.Count > 0)
                {
                    YearEndCls = 1;
                }

                if (dtAcntClsDate.Rows.Count > 0)
                {
                    if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                    {
                        acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                    }

                    if (YearEndCls == 1)
                    {
                        divAdd.Visible = false;
                    }
                }
            }

            divPrintCaption.InnerHtml = PrintCaption(ObjEntityRequest);
        }
    }
    public void LeadgerLoad()
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();

        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLedger = objBussiness.ReadLeadgerReceipt(ObjEntityRequest);

        if (dtLedger.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtLedger;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();

        }
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");
    }
    public void AccountLedgerLoad()
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussiness.ReadAccountLedger(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlAccount.DataSource = dtSubConrt;
            ddlAccount.DataTextField = "LDGR_NAME";
            ddlAccount.DataValueField = "LDGR_ID";
            ddlAccount.DataBind();

        }
        ddlAccount.Items.Insert(0, "--SELECT ACCOUNT--");
    }
    [WebMethod]
    public static string CancelPaymentAccount(string strCatId, string reasonmust, string usrId, string cnclRsn, string orgid, string corptid)
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int flag = 0;
        string strRets = "successcncl";
        string strRandomMixedId = strCatId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);
        ObjEntityRequest.User_Id = Convert.ToInt32(usrId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(orgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(corptid);

        if (reasonmust == "1")
        {
            ObjEntityRequest.CancelReason = cnclRsn;
        }

        else
        {
            ObjEntityRequest.CancelReason = objCommon.CancelReason();
        }

        try
        {
            Page objpage = new Page();
            DataTable dtPConfrm = objBussiness.ChkPaymentMasterIsCnfrm(ObjEntityRequest);


            clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
            DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);

            if (dtPConfrm.Rows.Count > 0)
            {
                int intConfrm = 0;
                intConfrm = Convert.ToInt32(dtPConfrm.Rows[0][0].ToString());
                if (intConfrm > 0)
                {
                    flag++;
                    strRets = "NOT DELETE";
                }
            }
            if (flag == 0)
            {
                if (dt.Rows[0]["PAYMNT_CNCL_USR_ID"].ToString() != "" && dt.Rows[0]["PAYMNT_CNCL_REASN"].ToString() != "")
                {
                    strRets = "AlreadyCancl";
                }
                objBussiness.CancelPaymentAccount(ObjEntityRequest);
                objpage.Session["SuccessMsg"] = "DELETE";
                
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ReopenReceiptDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string AcntClsPrvsn, string AuditClsPrvsn)
    {
        string[] strHtmlu = new string[5];

        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successReopen";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityRequest.User_Id = Convert.ToInt32(strUserID);
        try
        {
            DataTable dt = objBussiness.Read_PayemntByID(ObjEntityRequest);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // clsEntityPaymentAccount ObjSubEntityRequest = new clsEntityPaymentAccount();
                if (dt.Rows[i]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
                {
                    if (dt.Rows[i]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
                    {
                        ObjEntityRequest.LedgerId = Convert.ToInt32(dt.Rows[i]["PAYMNT_ACCNT_LDGR_ID"].ToString());
                    }
                    if (dt.Rows[i]["PURCHS_NET_TOTAL"].ToString() != "")
                    {
                        ObjEntityRequest.LedgerAmnt = Convert.ToDecimal(dt.Rows[i]["PURCHS_NET_TOTAL"].ToString());
                    }
                    //  objEntityLedger.Add(ObjSubEntityRequest);
                }

            }
            DataTable dtLDGRdTLS = objBussiness.Read_PayemntLedgerByID(ObjEntityRequest);

            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
            {
                clsEntityPaymentAccount ObjSubEntityRequestCostAndPurchase = new clsEntityPaymentAccount();
                clsEntityPaymentAccount ObjSubEntityRequest = new clsEntityPaymentAccount();
                if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())) && dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString() != "")
                {
                    if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())))
                    {
                        ObjSubEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                        NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequest.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString());
                    }
                    objEntityLedger.Add(ObjSubEntityRequest);
                    //EVM-0027 Aug 14
                    ObjSubEntityRequest.Organisation_id = ObjEntityRequest.Organisation_id;
                    ObjSubEntityRequest.Corporate_id = ObjEntityRequest.Corporate_id;
                    ObjSubEntityRequest.PaymentId = ObjEntityRequest.PaymentId;
                    ObjSubEntityRequest.Payment_Ledgr_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_ID"].ToString());
                    DataTable dtForOB = objBussiness.ReadOepningBalById(ObjSubEntityRequest);
                    if (dtForOB.Rows.Count > 0)
                    {
                        ObjSubEntityRequest.VoucherCategory = 1;
                        decimal decOpeningBal = 0;
                        if (dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                        {
                            decOpeningBal = Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                        decimal decPaidAmt = 0;
                        if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                        {
                            decPaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                        }
                        ObjSubEntityRequest.BalnceAmt = decOpeningBal - decPaidAmt;
                    }
                    //END
                }
                if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "" || dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "" || dtLDGRdTLS.Rows[intCount]["EXPENSE_ID"].ToString() != "")
                {
                    if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.CostCtrId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString());
                    }
                    else
                    {
                        ObjSubEntityRequestCostAndPurchase.CostCtrId = 0;
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.PurchaseId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString());
                    }
                    else
                    {
                        ObjSubEntityRequestCostAndPurchase.PurchaseId = 0;
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.CstCntrAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_AMT"].ToString());
                    }
                    if(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString()!="")
                        ObjSubEntityRequestCostAndPurchase.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_STATUS"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteStatus = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_STATUS"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["DEBIT_NOTE_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["DEBIT_NOTE_ID"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_AMT"].ToString());
                    }

                    if (dtLDGRdTLS.Rows[intCount]["EXPENSE_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.ExpenceId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["EXPENSE_ID"].ToString());
                        ObjSubEntityRequestCostAndPurchase.ExpnsAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["EXPENSE_AMT"].ToString());
                        ObjSubEntityRequestCostAndPurchase.TotalExpnsAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["EXPENSE_DTL_BALNC_AMT"].ToString());
                    }

                    objEntityLedgerCostCenter.Add(ObjSubEntityRequestCostAndPurchase);
                }
            }

            string strdate = "";
            DataTable dtCHK = objBussiness.CheckPaymentCnclSts(ObjEntityRequest);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PAYMNT_DATE"].ToString() != "")
                {
                    strdate = dt.Rows[0]["PAYMNT_DATE"].ToString();
                    int AcntCloseSts = AccountCloseCheck(strdate, strOrgIdID, strCorpID);
                    int AuditCloseSts = AuditCloseCheck(strdate, strOrgIdID, strCorpID);
                    if (AuditCloseSts == 1 && AuditClsPrvsn != "1")
                    {
                        strRets = "auditclosed";
                    }
                    else if (AuditCloseSts == 1 && AuditClsPrvsn == "1")
                    {
                    }
                    else if (AcntCloseSts == 1 && AcntClsPrvsn != "1")
                    {
                        strRets = "acntclosed";
                    }
                    else if (dt.Rows[0]["PAYMNT_REOPEN_USRID"].ToString() != "" && dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "0")
                    {
                        strRets = "alrdyreopened";
                    }
                    else
                    {
                        if (dtCHK.Rows[0][0].ToString() == "")
                        {
                            objBussiness.PayemntReOpenById(ObjEntityRequest, objEntityLedger, objEntityLedgerCostCenter);
                        }
                        else if (dtCHK.Rows[0][0].ToString() != "")
                        {
                            strRets = "alrdydeleted";
                        }
                    }

                }
            }
            string[] strHtmlRet = new string[2];
            strHtmlRet = LoadPendingOrders(Convert.ToInt32(strUserID), Convert.ToInt32(strOrgIdID), Convert.ToInt32(strCorpID));
            strHtmlu[3] = strHtmlRet[0];
            strHtmlu[4] = strHtmlRet[1];
        }
        catch
        {
            strRets = "failed";
        }
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        strHtmlu[0] = strRets;
        return strHtmlu;

    }
    public static int AuditCloseCheck(string strDate, string strOrgIdID, string strcorpId)
    {
        int sts = 0;
        cls_Business_Audit_Closeing objEmpAccntCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAccnt = new clsEntityLayerAuditClosing();
        if (strcorpId != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(strcorpId);
        }

        if (strOrgIdID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(strOrgIdID);
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAuditClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }
    public static int AccountCloseCheck(string strDate, string strOrgIdID, string strcorpId)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        if (strcorpId != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(strcorpId);
        }

        if (strOrgIdID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(strOrgIdID);
        }

        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] CheckIssuedSuccess(string strPayemntId, string strdate, string corpid, string orgid, string userid)
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();
        clsBusiness_Cheque_template objEmpPerfomance = new clsBusiness_Cheque_template();
        clsEntityChequeTemplate objEntity = new clsEntityChequeTemplate();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strRets = new string[4];


        strRets[0] = "successIssue";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);

        if (corpid != "")
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(corpid);
            objEntity.Corporate_id = Convert.ToInt32(corpid);
        }
        if (orgid != "")
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(orgid);
            objEntity.Organisation_id = Convert.ToInt32(orgid);
        }
        if (userid != "")
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(userid);
            objEntity.User_Id = Convert.ToInt32(userid);
        }

        try
        {
            DataTable dt = objBussiness.Read_PayemntByID(ObjEntityRequest);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["CHKTEMPLT_ID"].ToString() != "")
                {
                    objEntity.ChequeTemplateId = Convert.ToInt32(dt.Rows[0]["CHKTEMPLT_ID"].ToString());
                }
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("CHKTEMPLT_WIDTH", typeof(string));

                dtDetail.Columns.Add("CHKTEMPLT_HEIGHT", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_TOPS", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_TOPS_F", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_PAYEE_LEFT", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_DATE_LEFT", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMNTWORD1_LEFT", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMNTWORD2_LEFT", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMNTNUM_LEFT", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_PAYEE_TOP", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_DATE_TOP", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMNTWORD1_TOP", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMNTWORD2_TOP", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMNTNUM_TOP", typeof(string));


                dtDetail.Columns.Add("CHKTEMPLT_PAYEE_NAME", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_DATE", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMT_WORD_ONE", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMT_WORD_TWO", typeof(string));
                dtDetail.Columns.Add("CHKTEMPLT_AMT_NUM", typeof(string));


                DataTable dtList = objEmpPerfomance.ReadTemplateById(objEntity);
                dtDetail.TableName = "dtTableLoadcstcntr";
                if (dtList.Rows.Count > 0)
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["CHKTEMPLT_WIDTH"] = dtList.Rows[0]["CHKTEMPLT_WIDTH"].ToString();
                    drDtl["CHKTEMPLT_HEIGHT"] = dtList.Rows[0]["CHKTEMPLT_HEIGHT"].ToString();

                    string[] arr = dtList.Rows[0]["CHKTEMPLT_TOPS"].ToString().Split(',');
                    string[] arrf = dtList.Rows[0]["CHKTEMPLT_TOPS_F"].ToString().Split(',');


                    drDtl["CHKTEMPLT_PAYEE_LEFT"] = dtList.Rows[0]["CHKTEMPLT_PAYEE_LEFT"].ToString();
                    drDtl["CHKTEMPLT_PAYEE_TOP"] = dtList.Rows[0]["CHKTEMPLT_PAYEE_TOP"].ToString();

                    drDtl["CHKTEMPLT_DATE_LEFT"] = dtList.Rows[0]["CHKTEMPLT_DATE_LEFT"].ToString();
                    drDtl["CHKTEMPLT_DATE_TOP"] = dtList.Rows[0]["CHKTEMPLT_DATE_TOP"].ToString();

                    drDtl["CHKTEMPLT_AMNTWORD1_LEFT"] = dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_LEFT"].ToString();
                    drDtl["CHKTEMPLT_AMNTWORD1_TOP"] = dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_TOP"].ToString();


                    drDtl["CHKTEMPLT_AMNTWORD2_LEFT"] = dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_LEFT"].ToString();
                    drDtl["CHKTEMPLT_AMNTWORD2_TOP"] = dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_TOP"].ToString();

                    drDtl["CHKTEMPLT_AMNTNUM_LEFT"] = dtList.Rows[0]["CHKTEMPLT_AMNTNUM_LEFT"].ToString();
                    drDtl["CHKTEMPLT_AMNTNUM_TOP"] = dtList.Rows[0]["CHKTEMPLT_AMNTNUM_TOP"].ToString();


                    if (dtList.Rows[0]["CHKTEMPLT_PAYEE_NAME"].ToString() != "")
                    {
                        drDtl["CHKTEMPLT_PAYEE_NAME"] = dtList.Rows[0]["CHKTEMPLT_PAYEE_NAME"].ToString();
                    }
                    if (dtList.Rows[0]["CHKTEMPLT_DATE"].ToString() != "")
                    {
                        drDtl["CHKTEMPLT_DATE"] = dtList.Rows[0]["CHKTEMPLT_DATE"].ToString();
                    }
                    if (dtList.Rows[0]["CHKTEMPLT_AMT_WORD_ONE"].ToString() != "")
                    {
                        drDtl["CHKTEMPLT_AMT_WORD_ONE"] = dtList.Rows[0]["CHKTEMPLT_AMT_WORD_ONE"].ToString();
                    }
                    if (dtList.Rows[0]["CHKTEMPLT_AMT_WORD_TWO"].ToString() != "")
                    {
                        drDtl["CHKTEMPLT_AMT_WORD_TWO"] = dtList.Rows[0]["CHKTEMPLT_AMT_WORD_TWO"].ToString();
                    }
                    if (dtList.Rows[0]["CHKTEMPLT_AMT_NUM"].ToString() != "")
                    {
                        drDtl["CHKTEMPLT_AMT_NUM"] = dtList.Rows[0]["CHKTEMPLT_AMT_NUM"].ToString();
                    }
                    dtDetail.Rows.Add(drDtl);
                    string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);

                    strRets[1] = strJson;
                }


            }
            if (dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
            {

                strRets[0] = "alrdychecked";
            }


            ObjEntityRequest.ChequeIssueDate = objCommon.textToDateTime(strdate);

            objBussiness.CheckIssue_PaymentAccount(ObjEntityRequest);
        }
        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["CHK_ISSUE"] = strRets[0];
        return strRets;

    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ReadCheckDate(string strPayemntId, string corpid, string orgid, string userid)
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();


        clsCommonLibrary objCommon = new clsCommonLibrary();

        string[] strRets = new string[4];


        strRets[0] = "";


        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);

        if (corpid != "")
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(corpid);

        }
        if (orgid != "")
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(orgid);

        }
        if (userid != "")
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(userid);

        }

        try
        {
            DataTable dt = objBussiness.Read_PayemntByID(ObjEntityRequest);
            if (dt.Rows.Count > 0)
            {


                if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                {
                    strRets[0] = dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString();
                }


            }





        }
        catch
        {
            strRets[0] = "failed";
        }

        return strRets;

    }
    public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }
    [WebMethod]
    public static string printReceiptDetails(string strId, string UsrName, string strOrgIdID, string strCorpID, string crncyAbrvt, string crncyId)
    {
        string strRandomMixedId = strId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strrId = strRandomMixedId.Substring(2, intLenghtofId);

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityPaymentAccount ObjEntityPayment = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        string PreparedBy = "";

        if (UsrName != "")
        {
            PreparedBy = UsrName;
        }

        FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account_List objPage = new FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account_List();

        string CheckedBy = "";
        if (strCorpID != null)
        {
            ObjEntityPayment.Corporate_id = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
        }
        if (strOrgIdID != null)
        {
            ObjEntityPayment.Organisation_id = Convert.ToInt32(strOrgIdID);
        }


        ObjEntityPayment.PaymentId = Convert.ToInt32(strrId);
        DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityPayment);
        DataTable dtProduct = objBussinessPayment.Read_PayemntLedgerByIDForPrint(ObjEntityPayment);
        DataTable dtCost = new DataTable();

        if (dtProduct.Rows[0]["PAYMNT_LD_ID"].ToString() != "")
        {
            ObjEntityPayment.Payment_Ledgr_Id = Convert.ToInt32(dtProduct.Rows[0]["PAYMNT_LD_ID"].ToString());
        }

        if (dtProduct.Rows.Count == 1)
        {
            ObjEntityPayment.LedgerId = Convert.ToInt32(dtProduct.Rows[0]["PAYMNT_LD_ID"].ToString());
            dtCost = objBussinessPayment.Read_PayemntCostByID(ObjEntityPayment);
        }

        DataTable dtCorp = objBussinessPayment.ReadCorpDtls(ObjEntityPayment);
        //evm
        if (dt.Rows[0]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
        {
            ObjEntityPayment.LedgerId = Convert.ToInt32(dt.Rows[0]["PAYMNT_ACCNT_LDGR_ID"].ToString());
        }
        DataTable dtPayment = objBussinessPayment.AccntBalancebyId(ObjEntityPayment);
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PAYMENT);
        string strReturn = "";
        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                //strReturn = objPage.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntityPayment);
                strReturn = objBussinessPayment.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntityPayment);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBussinessPayment.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntityPayment, 2, dtPayment, crncyAbrvt, dtCost);
                //strReturn = objPage.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntityPayment, 2, dtPayment, crncyAbrvt, dtCost);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBussinessPayment.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntityPayment, 3, dtPayment, crncyAbrvt, dtCost);
            }
        }
        return strReturn;

    }

    //public string PdfPrintVersion2And3(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPaymentAccount ObjEntitySales, int VersionFlag, DataTable dtPayment, string currency, DataTable dtCost)
    //{
    //    //globfalg = VersionFlag;
    //    string PreparedBy = "";
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
    //    string CheckedBy = "";
    //    int intCorpId = 0;
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //        intCorpId = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    if (dt.Rows.Count > 0)
    //    {
    //        if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //            objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //        if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //            currency = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
    //    }

    //    string strId = "";
    //    strId = Convert.ToString(ObjEntitySales.PaymentId);
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.DFLT_CURNCY_DISPLAY,
    //                                                       clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
    //                                                        clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
    //                                               };
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_PRINT);
    //    DataTable dtCorpDetail = new DataTable();
    //    dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
    //    int DecCnt = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());

    //    //globhead = Convert.ToInt32(dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString());

    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Payment_Invoice" + strId + "_" + strNextNumber + ".pdf";
    //    Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
    //    if (VersionFlag == 2)
    //    {
    //        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
    //    }
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    string strRet = "";
    //    try
    //    {
    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            if (VersionFlag == 2)
    //            {
    //                writer.PageEvent = new PDFHeader();
    //                document.Open();
    //            }
    //            else
    //            {
    //                document.Open();
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }

    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 20, 80 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            PdfPTable footrtableHead = new PdfPTable(2);

    //            float[] footrsBodyHead = { 100, 0 };
    //            footrtableHead.SetWidths(footrsBodyHead);
    //            footrtableHead.WidthPercentage = 100;
    //            document.Add(footrtableHead);
    //            footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("Payment # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            document.Add(footrtable);

    //            if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "")
    //            {
    //                if (dt.Rows[0]["PAYMNT_MODE"].ToString().Trim() != "0")
    //                {
    //                    PdfPTable foottrtables = new PdfPTable(2);
    //                    float[] footrssBodys = { 30, 70 };
    //                    foottrtables.SetWidths(footrssBodys);
    //                    foottrtables.WidthPercentage = 70;

    //                    foottrtables.HorizontalAlignment = Element.ALIGN_LEFT;
    //                    foottrtables.AddCell(new PdfPCell(new Phrase("Payment Details :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, Colspan = 2 });
    //                    foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
    //                    if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "1")
    //                    {
    //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                        if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                        }
    //                        if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() != "")
    //                        {
    //                            if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "1" && dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
    //                            {
    //                                foottrtables.AddCell(new PdfPCell(new Phrase("Issue Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                            }
    //                        }
    //                        if (dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Number", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                        }
    //                    }

    //                    if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "2")
    //                    {
    //                        foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                        if (dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                        }
    //                        if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }
    //                    }

    //                    if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "3")
    //                    {
    //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                        if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Transfer Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "0")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "1")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "2")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                            if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() == "3")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                        }
    //                        if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                        }
    //                        if (dt.Rows[0]["PAYMNT_BK_IBAN"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PAYMNT_BK_IBAN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                        }
    //                    }

    //                    document.Add(foottrtables);
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                }
    //            }

    //            if (dtPayment.Rows.Count > 0)
    //            {
    //                string AccGrp = "";
    //                if (dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
    //                    AccGrp = dtPayment.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
    //                else if (dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
    //                    AccGrp = dtPayment.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
    //                if (AccGrp != "")
    //                {
    //                    PdfPTable footrtables = new PdfPTable(2);
    //                    float[] footrsBodys = { 15, 85 };
    //                    footrtables.SetWidths(footrsBodys);
    //                    footrtables.WidthPercentage = 100;
    //                    if (AccGrp == "13")
    //                    {
    //                        footrtables.AddCell(new PdfPCell(new Phrase("A/C BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase("ACC # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                    }
    //                    else
    //                    {
    //                        footrtables.AddCell(new PdfPCell(new Phrase("CASH BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase("            : " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                    }
    //                    //       footrtables.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2 });
    //                    //   document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(footrtables);
    //                }
    //            }

    //            float pos2 = writer.GetVerticalPosition(false);

    //            if (dtProduct.Rows.Count > 0)
    //            {
    //                clsBusinessLayer ObjBusiness = new clsBusinessLayer();

    //                decimal TOTAL = 0;

    //                var FontGrey = new BaseColor(134, 152, 160);
    //                var FontBordrGrey = new BaseColor(236, 236, 236);
    //                var FontBordrBlack = new BaseColor(138, 138, 138);
    //                var FontGreySmall = new BaseColor(236, 236, 236);

    //                if (dtProduct.Rows.Count == 1)//single ledger
    //                {
    //                    PdfPTable footrtables = new PdfPTable(5);
    //                    float[] footrsBodys = { 19, 37, 9, 11, 20 };
    //                    footrtables.SetWidths(footrsBodys);
    //                    footrtables.WidthPercentage = 100;

    //                    TOTAL = Convert.ToDecimal(dtProduct.Rows[0]["PAYMNT_LD_AMT"].ToString());
    //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Customer Name   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
    //                    string strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[0]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);
    //                    footrtables.AddCell(new PdfPCell(new Phrase(strAmountComma + "  " + currency, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });

    //                    if (dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString() != "")
    //                    {
    //                        footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0, BorderWidthBottom = 0 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0, BorderWidthBottom = 0 });

    //                        footrtables.AddCell(new PdfPCell(new Phrase("Payee Name:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                    }
    //                    else
    //                    {
    //                        footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                    }
    //                    document.Add(footrtables);

    //                    if (dtCost.Rows.Count > 0)
    //                    {
    //                        PdfPTable table2 = new PdfPTable(3);
    //                        float[] tableBody2 = { 40, 30, 30 };
    //                        table2.SetWidths(tableBody2);
    //                        table2.WidthPercentage = 100;
    //                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
    //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE #.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                        table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + currency + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

    //                        decimal value = 0;
    //                        int precision = DecCnt;
    //                        string format = String.Format("{{0:N{0}}}", precision);
    //                        string valuestring = String.Format(format, value);
    //                        int flag = 0;

    //                        for (int RowCount = 0; RowCount < dtCost.Rows.Count; RowCount++)
    //                        {
    //                            if (dtCost.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
    //                            {
    //                                if (dtCost.Rows[RowCount]["PURCHS_REF"].ToString() != "")
    //                                {
    //                                    if (dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString() != "")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString(), objEntityCommon);
    //                                        table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    }
    //                                    if (dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString(), objEntityCommon);
    //                                        table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    }
    //                                }
    //                                else if (dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase("Opening balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                    strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["OBPAID_AMT"].ToString(), objEntityCommon);
    //                                    table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                }
    //                                flag++;
    //                            }
    //                        }
    //                        if (flag > 0)
    //                        {
    //                            document.Add(table2);
    //                        }
    //                    }
    //                }
    //                else //multiple ledgers
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 5, 15, 12, 5, 28, 15, 20 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;


    //                    //Table table = new Table(2);
    //                    //// header row:
    //                    //table.addHeaderCell("Key");
    //                    //table.addHeaderCell("Value");


    //                    table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 2 });
    //                    table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + currency + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                    string strAmountComma = "";
    //                    string strAmountCommaTotal = "";
    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        if (dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString() != "")
    //                        {
    //                            TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString());
    //                            strAmountCommaTotal = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
    //                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);

    //                        }

    //                        float posStrtTbl = writer.GetVerticalPosition(false);


    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_REMARK"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_AMT"].ToString(), objEntityCommon);
    //                        table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });

    //                        decimal value = 0;
    //                        int precision = DecCnt;
    //                        string format = String.Format("{{0:N{0}}}", precision);
    //                        string valuestring = String.Format(format, value);
    //                        int flag = 0;

    //                        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
    //                        ObjEntitySales.Payment_Ledgr_Id = Convert.ToInt32(dtProduct.Rows[intRowBodyCount]["PAYMNT_LD_ID"].ToString());
    //                        dtCost = objBussinessPayment.Read_PayemntCostByID(ObjEntitySales);
    //                        if (dtCost.Rows.Count > 0)
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = dtCost.Rows.Count + 1 });
    //                            table2.AddCell(new PdfPCell(new Phrase("INV#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
    //                            table2.AddCell(new PdfPCell(new Phrase("INV. DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
    //                            table2.AddCell(new PdfPCell(new Phrase("SETTLEMENT REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack, Colspan = 2 });
    //                            table2.AddCell(new PdfPCell(new Phrase("INV.AMT(" + currency + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = dtCost.Rows.Count + 1 });
    //                            for (int RowCount = 0; RowCount < dtCost.Rows.Count; RowCount++)
    //                            {
    //                                if (dtCost.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
    //                                {
    //                                    if (dtCost.Rows[RowCount]["PURCHS_REF"].ToString() != "")
    //                                    {
    //                                        if (dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString() != "")
    //                                        {
    //                                            table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["BILL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_AMT"].ToString(), objEntityCommon);
    //                                            table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        }
    //                                        if (dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
    //                                        {
    //                                            table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["BILL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["PURCHS_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["PAYMNT_CST_DEBIT_AMT"].ToString(), objEntityCommon);
    //                                            table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        }
    //                                    }
    //                                    else if (dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && dtCost.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        table2.AddCell(new PdfPCell(new Phrase(dtCost.Rows[RowCount]["BILL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(dtCost.Rows[RowCount]["OBPAID_AMT"].ToString(), objEntityCommon);
    //                                        table2.AddCell(new PdfPCell(new Phrase("Opening balance ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                        table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    }
    //                                    flag++;
    //                                }
    //                            }
    //                        }
    //                    }
    //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 6 });
    //                    table2.AddCell(new PdfPCell(new Phrase(strAmountCommaTotal, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 7 });
    //                    document.Add(table2);
    //                }
    //            }

    //            float pos1 = writer.GetVerticalPosition(false);

    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;
    //            var FontBordrBlak = new BaseColor(138, 138, 138);
    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //            if (dt.Rows[0]["USR_NAME"].ToString() != "")
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            if (dt.Rows[0]["INSERT_USR"].ToString() != "")
    //            {
    //                PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
    //            }
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase("Received By", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 5, Border = 0, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 5, Border = 0, Colspan = 3 });

    //            table3.AddCell(new PdfPCell(new Phrase("Name", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("ID No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("Mobile No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 8, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("Signature", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 25, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 2, PaddingRight = 2, PaddingTop = 2, PaddingBottom = 25, BorderColor = FontBordrBlak });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 1, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            else
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("_______________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, PaddingRight = 90, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            if (pos1 > 240)
    //            {
    //                table3.WriteSelectedRows(0, -1, 50, 240, writer.DirectContent);
    //            }
    //            else
    //            {
    //                document.NewPage();
    //                table3.WriteSelectedRows(0, -1, 50, 240, writer.DirectContent);
    //            }
    //            document.Close();
    //        }
    //        strRet = strImagePath + strImageName;
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";
    //    }
    //    return strRet;
    //}

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ConfirmPurchaseDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string strFinYrID)
    {

        string[] strHtmlu = new string[5];
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();
        clsBusiness_purchaseMaster objBussiness = new clsBusiness_purchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successConfirm";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityRequest.User_Id = Convert.ToInt32(strUserID);
        ObjEntityRequest.FinancialYrId = Convert.ToInt32(strFinYrID);
        try
        {
            DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["PAYMNT_REF"].ToString() != "")
                {
                    ObjEntityRequest.RefNum = dt.Rows[0]["PAYMNT_REF"].ToString();
                }
                if (dt.Rows[0]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
                {
                    ObjEntityRequest.AccntNameId = Convert.ToInt32(dt.Rows[0]["PAYMNT_ACCNT_LDGR_ID"].ToString());
                }
                if (dt.Rows[0]["PAYMNT_DATE"].ToString() != "")
                {
                    ObjEntityRequest.UpdPaymentDate = objCommon.textToDateTime(dt.Rows[0]["PAYMNT_DATE"].ToString());
                    ObjEntityRequest.FromDate = objCommon.textToDateTime(dt.Rows[0]["PAYMNT_DATE"].ToString());
                }
                ObjEntityRequest.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                {
                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                    {
                        ObjEntityRequest.TotalAmnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_NET_TOTAL"].ToString());
                    }

                }
                if (dt.Rows[0]["PAYMNT_REF_SEQNUM"].ToString() != "")
                {
                    ObjEntityRequest.SequenceRef = Convert.ToInt32(dt.Rows[0]["PAYMNT_REF_SEQNUM"].ToString());
                }
                ObjEntityRequest.ConfirmStatus = 1;
                if (dt.Rows[0]["PAYMNT_EXCHANGE_RATE"].ToString() != "")
                {
                    ObjEntityRequest.ExchangeRate = Convert.ToDecimal(dt.Rows[0]["PAYMNT_EXCHANGE_RATE"].ToString());
                }
                if (dt.Rows[0]["PAYMNT_DSCRPTN"].ToString() != "")
                {
                    ObjEntityRequest.Description = dt.Rows[0]["PAYMNT_DSCRPTN"].ToString();
                }
                if (dt.Rows[0]["PAYMNT_MODE"].ToString() != "")
                {
                    ObjEntityRequest.PayemntMode = Convert.ToInt32(dt.Rows[0]["PAYMNT_MODE"].ToString());
                }
                if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "1")
                {
                    if (dt.Rows[0]["CHKBK_ID"].ToString() != "")
                    {
                        ObjEntityRequest.ChequeBookId = Convert.ToInt32(dt.Rows[0]["CHKBK_ID"].ToString());
                    }
                    if (dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                    {
                        ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString());
                    }
                    if (dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString() != "")
                    {
                        ObjEntityRequest.Payee = dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString();
                    }
                    if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "0")
                    {
                    }
                    else if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "1")
                    {
                        if (dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
                        {
                            ObjEntityRequest.ChequeIssueDate = objCommon.textToDateTime(dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString());
                        }
                    }
                    if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                    {
                        ObjEntityRequest.ToDate = objCommon.textToDateTime(dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString());
                    }

                }
                else if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "2")
                {
                    if (dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString() != "")
                    {
                        ObjEntityRequest.DD_Number = dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString();
                    }
                    if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                    {
                        ObjEntityRequest.ToDate = objCommon.textToDateTime(dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString());
                    }
                }
                else if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "3")
                {
                    if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
                    {
                        if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != null && dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
                        {
                            ObjEntityRequest.BankTransfer_Mode = Convert.ToInt32(dt.Rows[0]["PAYMNT_BK_MODE"].ToString());
                        }
                    }
                    if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                    {
                        ObjEntityRequest.ToDate = objCommon.textToDateTime(dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString());
                    }
                    if (dt.Rows[0]["PAYMNT_BK_BANK"].ToString() != "")
                    {
                        ObjEntityRequest.Bank_BankTransfer = dt.Rows[0]["PAYMNT_BK_BANK"].ToString();
                    }
                    if (dt.Rows[0]["PAYMNT_BK_IBAN"].ToString() != "")
                    {
                        ObjEntityRequest.IBAN_BankTransfer = dt.Rows[0]["PAYMNT_BK_IBAN"].ToString();
                    }
                }
            }
            List<clsEntityPaymentAccount> objEntityCostCenterIns = new List<clsEntityPaymentAccount>();
            List<clsEntityPaymentAccount> objEntityCostCenterUpd = new List<clsEntityPaymentAccount>();
            List<clsEntityPaymentAccount> objEntityCostCenterDel = new List<clsEntityPaymentAccount>();
            List<clsEntityPaymentAccount> objEntityLedgerIns = new List<clsEntityPaymentAccount>();
            List<clsEntityPaymentAccount> objEntityLedgerUpd = new List<clsEntityPaymentAccount>();
            List<clsEntityPaymentAccount> objEntityLedgerDel = new List<clsEntityPaymentAccount>();
            List<clsEntityPaymentAccount> objEntityDelete = new List<clsEntityPaymentAccount>();

            int CntExceed = 0;

            DataTable dtLDGRdTLS = objBussinessPayment.Read_PayemntLedgerByID(ObjEntityRequest);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dtLDGRdTLS.Rows.Count; i++)
                {
                    int revflg = 0;
                    string[] newRev1 = NewRev.Split(',');
                    for (int j = 0; j < newRev1.Length; j++)
                    {
                        if (newRev1[j] != dtLDGRdTLS.Rows[i]["PAYMNT_LD_ID"].ToString())
                        {
                            revflg = 0;
                        }
                        else
                        {
                            revflg = 1;
                        }
                    }
                    if (revflg == 0)
                    {
                        clsEntityPaymentAccount objSubEntityLedgerINS = new clsEntityPaymentAccount();
                        clsEntityPaymentAccount objSubEntityLedgerUPD = new clsEntityPaymentAccount();
                        NewRev = NewRev + "," + dtLDGRdTLS.Rows[i]["PAYMNT_LD_ID"].ToString();
                        objSubEntityLedgerUPD.Payment_Ledgr_Id = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PAYMNT_LD_ID"].ToString());
                        objSubEntityLedgerUPD.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["LDGR_ID"].ToString());
                        if (dtLDGRdTLS.Rows[i]["PAYMNT_LD_AMT"].ToString() != "")
                        {
                            objSubEntityLedgerUPD.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["PAYMNT_LD_AMT"].ToString());
                        }
                        if (dtLDGRdTLS.Rows[i]["PAYMNT_LD_REMARK"].ToString() != "")
                        {
                            objSubEntityLedgerUPD.Remarks = dtLDGRdTLS.Rows[i]["PAYMNT_LD_REMARK"].ToString();
                        }

                        //EVM-0027 Aug 14
                        if (dtLDGRdTLS.Rows[i]["LDGR_ID"].ToString() != "")
                        {
                            clsEntityPaymentAccount objSubEntityGrp1 = new clsEntityPaymentAccount();

                            objSubEntityGrp1.Payment_Ledgr_Id = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PAYMNT_LD_ID"].ToString());
                            objSubEntityGrp1.Organisation_id = ObjEntityRequest.Organisation_id;
                            objSubEntityGrp1.Corporate_id = ObjEntityRequest.Corporate_id;
                            objSubEntityGrp1.PaymentId = ObjEntityRequest.PaymentId;
                            ObjEntityRequest.VoucherCategory = 1;
                            objSubEntityGrp1.VoucherCategory = 1;
                            objSubEntityLedgerUPD.VoucherCategory = 1;

                            objSubEntityGrp1.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["LDGR_ID"].ToString());
                            DataTable dtForOB = objBussinessPayment.ReadOepningBalById(objSubEntityGrp1);
                            if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                            {
                                objSubEntityGrp1.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["LDGR_ID"].ToString());
                                objSubEntityLedgerUPD.PaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                                objSubEntityGrp1.BalnceAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBBAL_AMT"].ToString());
                                objSubEntityLedgerUPD.BalnceAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBBAL_AMT"].ToString());
                                objSubEntityGrp1.PaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                            }
                        }

                        //END
                        objEntityLedgerUpd.Add(objSubEntityLedgerUPD);
                    }

                    clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();
                    clsEntityPaymentAccount objEntityCstDtlDEL = new clsEntityPaymentAccount();

                    objSubEntity.Organisation_id = ObjEntityRequest.Organisation_id;
                    objSubEntity.Corporate_id = ObjEntityRequest.Corporate_id;
                    if (dtLDGRdTLS.Rows[i]["PAYMNT_CST_ID"].ToString() != "")
                    {
                        objSubEntity.Payment_Ledgr_Id = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PAYMNT_LD_ID"].ToString());
                        objSubEntity.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["LDGR_ID"].ToString());
                        if (dtLDGRdTLS.Rows[i]["PAYMNT_CST_AMT"].ToString() != "")
                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["PAYMNT_CST_AMT"].ToString());


                        if (dtLDGRdTLS.Rows[i]["COSTCNTR_ID"].ToString() != "")
                        {
                            objSubEntity.CostCtrId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["COSTCNTR_ID"].ToString());
                            if (dtLDGRdTLS.Rows[i]["COSTGRP_ID_ONE"].ToString() != "")
                                objSubEntity.CostGrp1Id = Convert.ToInt32(dtLDGRdTLS.Rows[i]["COSTGRP_ID_ONE"].ToString());
                            if (dtLDGRdTLS.Rows[i]["COSTGRP_ID_TWO"].ToString() != "")
                                objSubEntity.CostGrp2Id = Convert.ToInt32(dtLDGRdTLS.Rows[i]["COSTGRP_ID_TWO"].ToString());
                        }

          
                        if (dtLDGRdTLS.Rows[i]["PURCHS_ID"].ToString() != "")
                        {
                            objSubEntity.PurchaseId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PURCHS_ID"].ToString());

                            if (dtLDGRdTLS.Rows[i]["PAYMNT_CST_DEBIT_STATUS"].ToString() != "")
                            {
                                objSubEntity.DebitNoteStatus = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PAYMNT_CST_DEBIT_STATUS"].ToString());
                            }
                            if (dtLDGRdTLS.Rows[i]["DEBIT_NOTE_ID"].ToString() != "")
                            {
                                objSubEntity.DebitNoteId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["DEBIT_NOTE_ID"].ToString());
                            }
                            if (dtLDGRdTLS.Rows[i]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
                            {
                                objSubEntity.DebitNoteAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["PAYMNT_CST_DEBIT_AMT"].ToString());
                            }
                            //if (dtLDGRdTLS.Rows[i]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString() != "")
                            //{
                            //    objSubEntity.DebitNoteRemainingAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString());
                            //}
                            if (dtLDGRdTLS.Rows[i]["PURCHS_BAL_AMT"].ToString() != "")
                                objSubEntity.PurchaseActAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["PURCHS_BAL_AMT"].ToString());
                            if (dtLDGRdTLS.Rows[i]["VOCHR_BFR_SETL_AMT"].ToString() != "")
                            {
                                objSubEntity.DebitNoteRemainingAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["VOCHR_BFR_SETL_AMT"].ToString());
                            }

                            int intCreditNoteSettleSts = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PAYMNT_CST_DEBIT_STATUS"].ToString());

                            DataTable dtSalesBalance = objBussinessPayment.ReadPurchaseBalance(objSubEntity);
                            if (intCreditNoteSettleSts == 1)
                            {
                                dtSalesBalance = objBussinessPayment.ReadSalesReturnBalance(objSubEntity);
                            }

                            decimal decCheckAmnt = objSubEntity.CstCntrAmnt;
                            if (intCreditNoteSettleSts == 1)
                            {
                                decCheckAmnt = objSubEntity.DebitNoteAmount;
                            }

                            decimal decSalesRemainAmt = 0;
                            if (dtSalesBalance.Rows.Count > 0)
                            {
                                if (dtSalesBalance.Rows[0][1].ToString() != "")
                                    decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                            }

                            if (decSalesRemainAmt != 0)
                            {
                                if (decSalesRemainAmt < (objSubEntity.CstCntrAmnt + objSubEntity.DebitNoteAmount))
                                {
                                    strRets = "PrchsAmountExceeded";
                                    CntExceed++;
                                }
                            }
                            else if (CntExceed == 0)
                            {
                                strRets = "PrchsAmtFullySettld";
                                objEntityCstDtlDEL.PaymentCostCntrId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["PAYMNT_CST_ID"].ToString());
                                objEntityDelete.Add(objEntityCstDtlDEL);
                            }
                            if (decSalesRemainAmt != 0)//insert not fully settled
                            {
                                objEntityCostCenterIns.Add(objSubEntity);
                            }
                        }
                        else
                        {

                            if (dtLDGRdTLS.Rows[i]["EXPENSE_ID"].ToString() != "")
                            {
                                objSubEntity.ExpenceId = Convert.ToInt32(dtLDGRdTLS.Rows[i]["EXPENSE_ID"].ToString());
                                objSubEntity.ExpnsAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["EXPENSE_AMT"].ToString());
                                objSubEntity.TotalExpnsAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[i]["EXPENSE_DTL_BALNC_AMT"].ToString());


                                if (objSubEntity.TotalExpnsAmnt < objSubEntity.ExpnsAmnt)
                                {

                                    strRets = "PrchsAmountExceeded";
                                
                                }
                            }


                            objEntityCostCenterIns.Add(objSubEntity);
                        }
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PAYMNT_CNCL_USR_ID"].ToString() != "")
                {
                    strRets = "alrdydeleted";
                }
                else if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
                {
                    strRets = "alrdyConfirmed";
                }
                else if (strRets != "PrchsAmountExceeded" && strRets != "PrchsAmtFullySettld")
                {
                    if (objEntityDelete.Count > 0)//delete fully settld saved sales and purchs
                    {
                        objBussinessPayment.DeletePurchaseLedgers(objEntityDelete);
                        strRets = "successConfirm";
                    }

                    int PostdateChqSts = 0;
                    PostdateChqSts = Convert.ToInt32(dt.Rows[0]["PAYMNT_POSTDATED_CHEQUE_STATUS"].ToString());
                    if (PostdateChqSts == 1)
                    {
                        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
                        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

                        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_ID"].ToString());
                        objEntity_Cheque.ChequeBookId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString());
                        objEntity_Cheque.User_Id = ObjEntityRequest.User_Id;
                        //update paid status
                        objEntity_Cheque.Status = 1;
                        objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);
                    }

                    objBussinessPayment.ConfirmPaymentFromList(ObjEntityRequest, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntityCostCenterUpd, objEntityCostCenterDel);
                }
            }

            string[] strHtmlRet = new string[2];
            strHtmlRet = LoadPendingOrders(Convert.ToInt32(strUserID), Convert.ToInt32(strOrgIdID), Convert.ToInt32(strCorpID));
            strHtmlu[3] = strHtmlRet[0];
            strHtmlu[4] = strHtmlRet[1];
           
        }
        catch
        {
            strRets = "failed";
        }
        strHtmlu[0] = strRets;
        return strHtmlu;
    }

    public string PrintCaption(clsEntityPaymentAccount ObjEntityRequest)
    {
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.Corporate_id;
        objEntityReports.Organisation_Id = ObjEntityRequest.Organisation_id;
        //    objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "PAYMENT";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string strHidden = "", GuaranteDivsn = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // GuaranteDivsn = "<B> DATE  : </B>" + ObjEntityRequest.FromDate.ToString("dd-MM-yyyy");
        if (dtCorp.Rows.Count > 0)
        {
            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
            strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();
        string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);
        StringBuilder sbCap = new StringBuilder();
        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
        string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "", strGuaranteBank = "", strUsrName = "";
        if (dat != "")
        {
            strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
        }
        if (strTitle != "")
        {
            strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
        }
        if (GuaranteDivsn != "")
        {
            strGuaranteDivsn = "<tr><td class=\"RprtDiv\">" + GuaranteDivsn + "</td></tr>";

        }
        if (usrName != "")
        {
            strUsrName = "<tr><td class=\"RprtDiv\">" + usrName + "</td></tr>";
        }
        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strGuaranteDivsn + strUsrName + strCaptionTabTitle + strCaptionTabstop;
        sbCap.Append(strPrintCaptionTable);
        ////write to  divPrintCaption
        return sbCap.ToString();


    }
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string PurchaseStatus, string AccountId, string from, string toDt, string CnclSts, string CurrencyId, string StartDate, string EndDate, string LedgerId, string SupName, string Currency)
    {
        string strReturn = "";
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        ObjEntityRequest.Organisation_id = Convert.ToInt32(orgID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(corptID);
        ObjEntityRequest.cnclStatus = Convert.ToInt32(CnclSts);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);
        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

        if (AccountId != "--SELECT ACCOUNT--" && AccountId != "0")
        {
            ObjEntityRequest.AccntNameId = Convert.ToInt32(AccountId);
        }
        if (LedgerId != "--SELECT LEDGER--" && LedgerId != "0")
        {
            ObjEntityRequest.LedgerId = Convert.ToInt32(LedgerId);
        }
        if (from != "")
        {
            ObjEntityRequest.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            ObjEntityRequest.ToDate = objCommon.textToDateTime(toDt);
        }
        if (StartDate != "")
        {
            ObjEntityRequest.StartDate = objCommon.textToDateTime(StartDate);
        }
        if (EndDate != "")
        {
            ObjEntityRequest.EndDate = objCommon.textToDateTime(EndDate);
        }
        if (PurchaseStatus != "")
        {
            ObjEntityRequest.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
        }
        DataTable dtCategory = objBussiness.Payment_List(ObjEntityRequest);
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRANSACTION_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_PDF);
        objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        string strNextNumber = objBusinesslayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "PaymentList_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string format = String.Format("{{0:N{0}}}", 2);
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                writer.PageEvent = new PDFHeader();
                document.Open();

                PdfPTable footrtable = new PdfPTable(3);
                float[] footrsBody1 = { 20, 5, 75 };
                footrtable.SetWidths(footrsBody1);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase("FROM DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(from, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(toDt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (SupName != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("ACCOUNT BOOK  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(SupName, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                footrtable.AddCell(new PdfPCell(new Phrase("PAYMENT STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (PurchaseStatus == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (PurchaseStatus == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (PurchaseStatus == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (PurchaseStatus == "3")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(7);
                float[] footrsBody = { 14, 18, 14, 10, 17, 15, 12 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REFERENCE NUMBER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ACCOUNT GROUP", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("PAYEE NAME", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("NARRATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL AMOUNT ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                string strRandom = objCommon.Random_Number();
                decimal Total = 0;
                if (dtCategory.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
                    {
                        string strId = dtCategory.Rows[0][0].ToString();
                        int usrId = Convert.ToInt32(strId);
                        int intIdLength = dtCategory.Rows[0][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        string strCancTransaction = dtCategory.Rows[intRowBodyCount][3].ToString();
                        int CNT = intRowBodyCount + 1;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PAYMNT_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PAYMNT_CHQ_PAYEE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PAYMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dtCategory.Rows[intRowBodyCount]["PAYMNT_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string NetAmountWithCommaFrm = "";
                        string totalAmnt = "";
                        if (dtCategory.Rows[intRowBodyCount]["TOTAL_AMT"].ToString() != "")
                        {
                            totalAmnt = dtCategory.Rows[intRowBodyCount]["TOTAL_AMT"].ToString();
                        }
                        Total = Total + Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["TOTAL_AMT"].ToString());
                        NetAmountWithCommaFrm = objBusinesslayer.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon) + " " + Currency;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(NetAmountWithCommaFrm, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        string strStatusImg = "";
                        if (dtCategory.Rows[intRowBodyCount]["PAYMNT_CNFRM_STS"].ToString() == "1")
                        {
                            strStatusImg = "CONFIRMED";
                        }
                        else
                        {
                            if (dtCategory.Rows[intRowBodyCount]["PAYMNT_REOPEN_USRID"].ToString() != "")
                            {
                                strStatusImg = "REOPENED";
                            }
                            else
                            {
                                strStatusImg = "PENDING";
                            }
                        }
                        TBCustomer.AddCell(new PdfPCell(new Phrase(strStatusImg, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    }
                    if (dtCategory.Rows.Count > 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinesslayer.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon)+" "+Currency, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 7 });

                }
                document.Add(TBCustomer);
                document.Close();
                strRet = strImagePath + strImageName;
            }
        }
        catch (Exception)
        {
            document.Close();
            strRet = "";
        }
        return strRet;
    }
    [WebMethod]
    public static string PrintCSV(string orgID, string corptID, string PurchaseStatus, string AccountId, string from, string toDt, string CnclSts, string CurrencyId, string StartDate, string EndDate, string LedgerId, string SupName, string Currency)
    {
        string strReturn = "";
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
        FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account_List OBJ = new FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account_List();
        ObjEntityRequest.Organisation_id = Convert.ToInt32(orgID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(corptID);
        ObjEntityRequest.cnclStatus = Convert.ToInt32(CnclSts);
        int intCorpId = 0;
        if (corptID != "")
            intCorpId = Convert.ToInt32(corptID);
        if (CurrencyId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

        if (AccountId != "--SELECT ACCOUNT--" && AccountId != "0")
        {
            ObjEntityRequest.AccntNameId = Convert.ToInt32(AccountId);
        }
        if (LedgerId != "--SELECT LEDGER--" && LedgerId != "0")
        {
            ObjEntityRequest.LedgerId = Convert.ToInt32(LedgerId);
        }
        if (from != "")
        {
            ObjEntityRequest.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            ObjEntityRequest.ToDate = objCommon.textToDateTime(toDt);
        }
        if (StartDate != "")
        {
            ObjEntityRequest.StartDate = objCommon.textToDateTime(StartDate);
        }
        if (EndDate != "")
        {
            ObjEntityRequest.EndDate = objCommon.textToDateTime(EndDate);
        }
        if (PurchaseStatus != "")
        {
            ObjEntityRequest.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
        }
        DataTable dtCategory = objBussiness.Payment_List(ObjEntityRequest);
        strReturn = OBJ.LoadTable_CSV(dtCategory, ObjEntityRequest, CurrencyId, from, toDt, SupName, PurchaseStatus, Currency);
        return strReturn;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntityPaymentAccount ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Currency)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, ObjEntityRequest, CurrencyId, from, toDt, Suplier, PurchaseStatus, Currency);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (ObjEntityRequest.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
        }
        if (ObjEntityRequest.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENTLIST_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Payment/PaymentList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "PaymentList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PAYMENTLIST_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dtCategory, clsEntityPaymentAccount ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Currency)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.Corporate_id != 0)
        {
            intCorpId = ObjEntityRequest.Corporate_id;
        }

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }

        string FORNULL = "";
        DataTable table = new DataTable();
        string strRandom = objCommon.Random_Number();
        table.Columns.Add("PAYMENT LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));
        table.Columns.Add("      ", typeof(string));

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Suplier != "")
            table.Rows.Add("SUPPLIER :", '"' + Suplier.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //if (Status == "1")
        //    table.Rows.Add("STATUS :", "Active", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //else if (Status == "0")
        //    table.Rows.Add("STATUS :", "Inactive", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        //else
        //    table.Rows.Add("STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (PurchaseStatus == "1")
            table.Rows.Add("PURCHASE STATUS :", "Confirmed", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "0")
            table.Rows.Add("PURCHASE STATUS :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "2")
            table.Rows.Add("PURCHASE STATUS :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("PURCHASE STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("REF #", "ACCOUNT GROUP", "PAYEE NAME","DATE", "NARRATION","TOTAL AMOUNT", "STATUS");
        decimal Total = 0;
        if (dtCategory.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtCategory.Rows.Count; intRowBodyCount++)
            {
                string strId = dtCategory.Rows[0][0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtCategory.Rows[0][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strCancTransaction = dtCategory.Rows[intRowBodyCount][3].ToString();
                int CNT = intRowBodyCount + 1;
                string NetAmountWithCommaFrm = "";
                string totalAmnt = "";
                if (dtCategory.Rows[intRowBodyCount]["TOTAL_AMT"].ToString() != "")
                {
                    totalAmnt = dtCategory.Rows[intRowBodyCount]["TOTAL_AMT"].ToString();
                }
                Total = Total + Convert.ToDecimal(dtCategory.Rows[intRowBodyCount]["TOTAL_AMT"].ToString());
                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon) + " " + Currency;
                string strStatusImg = "";
                if (dtCategory.Rows[intRowBodyCount]["PAYMNT_CNFRM_STS"].ToString() == "1")
                {
                    strStatusImg = "CONFIRMED";
                }
                else
                {
                    if (dtCategory.Rows[intRowBodyCount]["PAYMNT_REOPEN_USRID"].ToString() != "")
                    {
                        strStatusImg = "REOPENED";
                    }
                    else
                    {
                        strStatusImg = "PENDING";
                    }
                }
                table.Rows.Add('"' + dtCategory.Rows[intRowBodyCount]["PAYMNT_REF"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PAYMNT_CHQ_PAYEE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PAYMNT_DATE"].ToString() + '"', '"' + dtCategory.Rows[intRowBodyCount]["PAYMNT_DSCRPTN"].ToString() + '"', '"' + NetAmountWithCommaFrm + '"', '"' + strStatusImg + '"');

            }
            if (dtCategory.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + Currency + '"', '"' + FORNULL + '"');
            }
        }
        else
        {
            table.Rows.Add(" No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        return table;
    }
    public string DataTableToCSV(DataTable dtSIFHeader, char seperator)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
        {
            sb.Append(dtSIFHeader.Columns[i]);
            if (i < dtSIFHeader.Columns.Count - 1)
                sb.Append(seperator);
        }
        sb.AppendLine();
        foreach (DataRow dr in dtSIFHeader.Rows)
        {
            for (int i = 0; i < dtSIFHeader.Columns.Count; i++)
            {
                sb.Append(dr[i].ToString());

                if (i < dtSIFHeader.Columns.Count - 1)
                    sb.Append(seperator);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
    public static string[] LoadPendingOrders(int intUserId, int intOrgId, int intCorpId)
     {
         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         string strRandom = objCommon.Random_Number();
         clsBusinessLayer objBusiness = new clsBusinessLayer();
         objEntityCommon.Organisation_Id = intOrgId;
         objEntityCommon.CorporateID = intCorpId;

         int Decimalcount = 0;
         clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                    clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                    };
         DataTable dtCorpDetail = new DataTable();
         dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
         if (dtCorpDetail.Rows.Count > 0)
         {
             objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
             Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
         }
         string format = String.Format("{{0:N{0}}}", Decimalcount);
         string[] strHtmlRet = new string[2];
         string strHtml = "";
         clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
         DataTable dt = objBusinessLayer.ReadRecurrnceList(objEntityCommon);
         List<clsEntityCommon> objEntityNewOrdersList = new List<clsEntityCommon>();
         DateTime dtCurrentDate = objCommon.textToDateTime(objBusiness.LoadCurrentDateInString());
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             DateTime dtRecurrDate = objCommon.textToDateTime(dt.Rows[i]["REPAREC_CURR_DATE"].ToString());
             int Period = Convert.ToInt32(dt.Rows[i]["REPAREC_PERIOD"].ToString());
             int RemindDays = Convert.ToInt32(dt.Rows[i]["REPAREC_REM_DAYS"].ToString());
             int RecurrMasterTabId = Convert.ToInt32(dt.Rows[i]["REPAREC_ID"].ToString());
             int PayRecpId = 0, PayRecpSts = 0;
             if (dt.Rows[i]["PAYMNT_ID"].ToString() != "")
             {
                 PayRecpId = Convert.ToInt32(dt.Rows[i]["PAYMNT_ID"].ToString());
                 PayRecpSts = 0;
             }
             else
             {
                 PayRecpId = Convert.ToInt32(dt.Rows[i]["RECPT_ID"].ToString());
                 PayRecpSts = 1;
             }

             DateTime dtNewRecurDate = new DateTime();
             DateTime dtRemindDate = new DateTime();
             if (Period == 1)
             {
                 dtNewRecurDate = dtRecurrDate.AddDays(1);
             }
             else if (Period == 2)
             {
                 dtNewRecurDate = dtRecurrDate.AddMonths(1);
             }
             else if (Period == 3)
             {
                 dtNewRecurDate = dtRecurrDate.AddMonths(2);
             }
             else if (Period == 4)
             {
                 dtNewRecurDate = dtRecurrDate.AddMonths(6);
             }
             else if (Period == 5)
             {
                 dtNewRecurDate = dtRecurrDate.AddYears(1);
             }
             dtRemindDate = dtNewRecurDate.AddDays(RemindDays * -1);
             DataTable dtOrd = objBusinessLayer.ReadRecurrnceOrderList(objEntityCommon);
             while (dtRemindDate <= dtCurrentDate)
             {
                 DataRow[] results = dtOrd.Select("REPAREC_ID ='" + dt.Rows[i]["REPAREC_ID"].ToString() + "' AND  REPARECSUB_DATE='" + dtNewRecurDate.ToString("dd-MM-yyyy") + "'");
                 if (results.Length == 0)
                 {
                     clsEntityCommon objRecur = new clsEntityCommon();
                     objRecur.RecurMasterId = RecurrMasterTabId;
                     objRecur.RecurDate = objCommon.textToDateTime(dtNewRecurDate.ToString("dd-MM-yyyy"));
                     objRecur.SectionId = PayRecpSts;
                     objRecur.RecurSubId = intUserId;
                     objEntityNewOrdersList.Add(objRecur);
                 }


                 dtRecurrDate = objCommon.textToDateTime(dtNewRecurDate.ToString("dd-MM-yyyy"));
                 if (Period == 1)
                 {
                     dtNewRecurDate = dtRecurrDate.AddDays(1);
                 }
                 else if (Period == 2)
                 {
                     dtNewRecurDate = dtRecurrDate.AddMonths(1);
                 }
                 else if (Period == 3)
                 {
                     dtNewRecurDate = dtRecurrDate.AddMonths(2);
                 }
                 else if (Period == 4)
                 {
                     dtNewRecurDate = dtRecurrDate.AddMonths(6);
                 }
                 else if (Period == 5)
                 {
                     dtNewRecurDate = dtRecurrDate.AddYears(1);
                 }
                 dtRemindDate = dtNewRecurDate.AddDays(RemindDays * -1);
             }
         }
         if (objEntityNewOrdersList.Count > 0)
         {
             objBusinessLayer.insertNewORders(objEntityNewOrdersList);
         }


         DataTable dsList = objBusinessLayer.ReadRecurrnceOrderList(objEntityCommon);


         DataRow[] resultss = dsList.Select("REPARECSUB_STS = '0'");

         DataTable dtOrders = new DataTable();
         if (resultss.Length > 0)
         {
             dtOrders = resultss.CopyToDataTable();
         }
         if (dtOrders.Rows.Count > 0)
         {
             strHtmlRet[0] = dtOrders.Rows.Count.ToString();
         }
         for (int i = 0; i < dtOrders.Rows.Count; i++)
         {
             string strId = dtOrders.Rows[i]["REPARECSUB_ID"].ToString();
             int intIdLength = dtOrders.Rows[i]["REPARECSUB_ID"].ToString().Length;
             string stridLength = intIdLength.ToString("00");
             string StrCorpId = stridLength + strId + strRandom;

             strHtml += "<tr>";
             strHtml += "<td class=\"td_rec\">";
             strHtml += "<a href=\"/FMS/FMS_Master/fms_Payment_Account/fms_Payment_Account.aspx?Rid=" + StrCorpId + "\" class=\"flip_o\" onmouseover=\"return ShowOrderDtls('" + StrCorpId + "');\">" + dtOrders.Rows[i]["REPARECSUB_DATE"].ToString() + "</a>";
             strHtml += "</td>";
             strHtml += "<td class=\"td_rec1\">" + dtOrders.Rows[i]["PAYMNT_REF"].ToString() + "</td>";
             strHtml += "<td class=\"td_rec\">";
             strHtml += "<div class=\"btn_stl1\">";
             strHtml += "<button onclick=\"return RecurReject('" + StrCorpId + "',this);\" class=\"btn act_btn bn3\" title=\"Reject\"><i class=\"fa fa-times\"></i></button>";
             strHtml += "</div>";
             strHtml += "</td>";
             strHtml += "</tr>";
         }
         strHtmlRet[1] = strHtml;
         return strHtmlRet;
     }

     [WebMethod]
     public static string ShowOrderDtls(string strid, string CorpId)
     {
         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         clsBusinessLayer objBusiness = new clsBusinessLayer();

         string strRandomMixedId = strid;
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);

         clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
         clsCommonLibrary ObjCommonlib = new clsCommonLibrary();
         objEntityCommon.RecurSubId = Convert.ToInt32(strId);
         objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
         DataTable dt = objBusinessLayer.ReadOrderDtls(objEntityCommon);//dr
         string strHtml = "";
         if (dt.Rows.Count > 0)
         {

             strHtml += "<div class=\"panhed_1\">";
             strHtml += "<p>" + dt.Rows[0]["L1"].ToString() + "</p>";
             strHtml += "</div>";
             strHtml += "<div class=\"pan_cont\">";
             strHtml += "<span class=\"sp1\">" + dt.Rows[0]["RECPT_REF"].ToString() + "</span><span class=\"sp2\">" + dt.Rows[0]["RECPT_DATE"].ToString() + "</span>";
             strHtml += "<table class=\"table table-bordered\">";
             strHtml += "<thead class=\"thead1\">";
             strHtml += "<tr>";
             strHtml += "<th class=\"tr_l\">Ledger Name</th>";
             strHtml += "<th class=\"tr_r\">Amount</th>";
             strHtml += "</tr>";
             strHtml += "</thead>";
             strHtml += "<tbody id=\"Tbody1\">";
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 strHtml += "<tr>";
                 strHtml += "<td class=\"tr_l\">" + dt.Rows[i]["L2"].ToString() + "</td>";
                 strHtml += "<td class=\"tr_r\">" + dt.Rows[i]["RECPT_LD_AMT"].ToString() + "</td>";
                 strHtml += "</tr>";
             }
             strHtml += "</tbody>";
             strHtml += "</table>";
             strHtml += "</div>";
         }
         return strHtml;
     }
     [WebMethod]
     public static string RecurReject(string strid, string UserId)
     {
         string strRandomMixedId = strid;
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);

         string strHtml = "Suc";
         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsBusinessLayerFinanceHome objBusinessLayer = new clsBusinessLayerFinanceHome();
         objEntityCommon.RecurSubId = Convert.ToInt32(strId);
         objEntityCommon.RecurMasterId = Convert.ToInt32(UserId);
         try
         {
             objBusinessLayer.rejectOrders(objEntityCommon);
         }
         catch (Exception ex)
         {
             strHtml = "Fail";
         }
         return strHtml;
     }

     [WebMethod]
     public static string CheckSaleSettlement(string strPayemntId, string strOrgIdID, string strCorpID)
     {
         string ret = "successConfirm";

         clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
         clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
         List<clsEntityPaymentAccount> objEntityCostCenterIns = new List<clsEntityPaymentAccount>();

         string strRandomMixedId = strPayemntId;
         string id = strRandomMixedId;
         string strLenghtofId = strRandomMixedId.Substring(0, 2);
         int intLenghtofId = Convert.ToInt16(strLenghtofId);
         string strId = strRandomMixedId.Substring(2, intLenghtofId);

         ObjEntityRequest.PaymentId = Convert.ToInt32(strId);
         ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
         ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);

         int CntExceed = 0;

         DataTable dtLDGRdTLS = objBussinessPayment.Read_PayemntLedgerByID(ObjEntityRequest);
         for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
         {
             clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

             if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_ID"].ToString() != "")
             {
                 if (dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_AMT"].ToString() != "")
                 {
                     objSubEntity.Corporate_id = ObjEntityRequest.Corporate_id;
                     objSubEntity.Organisation_id = ObjEntityRequest.Organisation_id;
                     objSubEntity.PurchaseId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString());
                     objSubEntity.CstCntrAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_AMT"].ToString());
                     if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
                     {
                         objSubEntity.DebitNoteAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_AMT"].ToString());
                     }
                     if (dtLDGRdTLS.Rows[intCount]["VOCHR_BFR_SETL_AMT"].ToString() != "")
                     {
                         objSubEntity.DebitNoteRemainingAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["VOCHR_BFR_SETL_AMT"].ToString());
                     }
                     int intCreditNoteSettleSts = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_STATUS"].ToString());

                     DataTable dtSalesBalance = objBussinessPayment.ReadPurchaseBalance(objSubEntity);
                     if (intCreditNoteSettleSts == 1)
                     {
                         dtSalesBalance = objBussinessPayment.ReadSalesReturnBalance(objSubEntity);
                     }

                     decimal decCheckAmnt = objSubEntity.CstCntrAmnt;
                     if (intCreditNoteSettleSts == 1)
                     {
                         decCheckAmnt = objSubEntity.DebitNoteAmount;
                     }

                     decimal decSalesRemainAmt = 0;
                     if (dtSalesBalance.Rows.Count > 0)
                     {
                         if (dtSalesBalance.Rows[0][1].ToString() != "")
                             decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                     }
                     if (decSalesRemainAmt != 0)
                     {
                         if (decSalesRemainAmt < decCheckAmnt)
                         {
                             ret = "PrchsAmountExceeded";
                             CntExceed++;
                         }
                     }
                     else if (CntExceed == 0)
                     {
                         ret = "PrchsAmtFullySettld";
                     }
                 }
             }

             decimal expamnt;

             if (dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString() != "")
             {
                 expamnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString());
             }

             decimal balamt = 0;

             if (dtLDGRdTLS.Rows[intCount]["EXPENSE_DTL_BALNC_AMT"].ToString() != "")
             {

                 balamt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["EXPENSE_DTL_BALNC_AMT"].ToString());

             }

             if (balamt == 0 && dtLDGRdTLS.Rows[intCount]["EXPENSE_DTL_BALNC_AMT"].ToString() != "")
             {
                 ret = "PrchsAmountExceeded";


             }
             

         }
         

         return ret;
     }

     [WebMethod]
     public static string PaymentAmountSum(string orgID, string corptID, string PurchaseStatus, string AccountId, string from, string toDt, string CnclSts, string CurrencyId, string StartDate, string EndDate, string LedgerId, string Currency)
     {
         string strReturn = "";

         clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
         clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
         clsEntityCommon objEntityCommon = new clsEntityCommon();
         clsCommonLibrary objCommon = new clsCommonLibrary();
         clsBusinessLayer objBusinesslayer = new clsBusinessLayer();

         ObjEntityRequest.Organisation_id = Convert.ToInt32(orgID);
         ObjEntityRequest.Corporate_id = Convert.ToInt32(corptID);
         ObjEntityRequest.cnclStatus = Convert.ToInt32(CnclSts);
         int intCorpId = 0;
         if (corptID != "")
             intCorpId = Convert.ToInt32(corptID);
         if (CurrencyId != "")
             objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

         if (AccountId != "--SELECT ACCOUNT--" && AccountId != "0")
         {
             ObjEntityRequest.AccntNameId = Convert.ToInt32(AccountId);
         }
         if (LedgerId != "--SELECT LEDGER--" && LedgerId != "0")
         {
             ObjEntityRequest.LedgerId = Convert.ToInt32(LedgerId);
         }
         if (from != "")
         {
             ObjEntityRequest.FromDate = objCommon.textToDateTime(from);
         }
         if (toDt != "")
         {
             ObjEntityRequest.ToDate = objCommon.textToDateTime(toDt);
         }
         if (StartDate != "")
         {
             ObjEntityRequest.StartDate = objCommon.textToDateTime(StartDate);
         }
         if (EndDate != "")
         {
             ObjEntityRequest.EndDate = objCommon.textToDateTime(EndDate);
         }
         if (PurchaseStatus != "")
         {
             ObjEntityRequest.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
         }
         DataTable dtCategory = objBussiness.Payment_List_Sum(ObjEntityRequest);

        StringBuilder sb = new StringBuilder();
         string strHtml = "";
         if (dtCategory.Rows.Count > 0 && dtCategory.Rows[0]["TOTAL"].ToString() != "")
         {
             strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > TOTAL</td>";
             strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </td>";
             strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
             strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </td>";
             strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
             strHtml += "<td class=\"tr_r bg1 txt_rd\" style=\"text-align:right !important;\" id=\"tdtotal\">" + objBusinesslayer.AddCommasForNumberSeperation(dtCategory.Rows[0]["TOTAL"].ToString(), objEntityCommon) + " " + Currency + " </td>";
             strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
             if (CnclSts == "0")
             {
                 strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
             }

         }
         sb.Append(strHtml);
         return sb.ToString();
     }

     public class PDFHeader : PdfPageEventHelper
     {
         PdfContentByte cb;
         PdfTemplate footerTemplate;
         BaseFont bf = null;
         DateTime PrintTime = DateTime.Now;
         public override void OnOpenDocument(PdfWriter writer, Document document)
         {
             try
             {
                 PrintTime = DateTime.Now;
                 bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                 cb = writer.DirectContent;
                 footerTemplate = cb.CreateTemplate(200, 200);
             }
             catch (DocumentException de)
             {
                 //handle exception here
             }
             catch (System.IO.IOException ioe)
             {
                 //handle exception here
             }
         }
         public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
         {
             clsCommonLibrary objCommon = new clsCommonLibrary();
             clsEntityCommon ObjEntityCommon = new clsEntityCommon();
             clsBusinessLayer objDataCommon = new clsBusinessLayer();
             ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
             ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
             DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
             string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
             string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
             if (dtCorp.Rows.Count > 0)
             {
                 if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                 {
                     string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                     string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
                     strImageLogo = imaeposition + icon;
                 }
                 strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                 strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                 strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                 strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
             }
             string strAddress = "";
             strAddress = strCompanyAddr1;
             if (strCompanyAddr2 != "")
             {
                 strAddress += ", " + strCompanyAddr2;
             }
             if (strCompanyAddr3 != "")
             {
                 strAddress += ", " + strCompanyAddr3;
             }
             //Head Table
             PdfPTable headtable = new PdfPTable(2);
             headtable.AddCell(new PdfPCell(new Phrase("PAYMENT LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             if (strImageLogo != "")
             {
                 iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                 image.ScalePercent(PdfPCell.ALIGN_CENTER);
                 image.ScaleToFit(60f, 40f);
                 headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
             }
             else
             {
                 headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             }
             headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
             headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
             headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
             float[] headersHeading = { 80, 20 };
             headtable.SetWidths(headersHeading);
             headtable.WidthPercentage = 100;
             document.Add(headtable);
             PdfPTable tableLine = new PdfPTable(1);
             float[] tableLineBody = { 100 };
             tableLine.SetWidths(tableLineBody);
             tableLine.WidthPercentage = 100;
             tableLine.TotalWidth = 650F;
             tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
             float pos9 = writer.GetVerticalPosition(false);
         }
         public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
         {
             // base.OnEndPage(writer, document);
             string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
             PdfPTable table3 = new PdfPTable(1);
             float[] tableBody3 = { 100 };
             table3.SetWidths(tableBody3);
             table3.WidthPercentage = 100;
             table3.TotalWidth = 650F;
             table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
             // document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
             PdfPTable headImg = new PdfPTable(3);
             string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
             //headImg.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });

             headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3, PaddingTop = 5 });
             if (strImageLogo != "")
             {
                 iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                 image.ScalePercent(PdfPCell.ALIGN_CENTER);
                 image.ScaleToFit(60f, 40f);
                 headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
             }

             headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
             headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
             float[] headersHeading = { 20, 60, 20 };
             headImg.SetWidths(headersHeading);
             headImg.WidthPercentage = 100;
             headImg.TotalWidth = document.PageSize.Width - 80f;

             headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(50), writer.DirectContent);

             String text = "Page " + writer.PageNumber + " of ";
             //Add paging to footer
             {
                 cb.BeginText();
                 cb.SetFontAndSize(bf, 8);
                 cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
                 cb.ShowText(text);
                 cb.EndText();
                 float len = bf.GetWidthPoint(text, 8);
                 cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
             }
         }
         public override void OnCloseDocument(PdfWriter writer, Document document)
         {
             base.OnCloseDocument(writer, document);
             footerTemplate.BeginText();
             footerTemplate.SetFontAndSize(bf, 8);
             footerTemplate.SetTextMatrix(0, 0);
             footerTemplate.ShowText((writer.PageNumber).ToString());
             footerTemplate.EndText();
         }
     }
}

  