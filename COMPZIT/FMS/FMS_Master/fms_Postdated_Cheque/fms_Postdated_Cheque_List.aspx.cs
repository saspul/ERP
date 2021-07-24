using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

public partial class FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque_List : System.Web.UI.Page
{


    //0039
    public static int globfalg = 0;
    public static int globhead = 0;
    //end

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
            clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            LoadAccountHeadLedger();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = { clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                         clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                HiddenCurrencyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();

            }
            objEntityCommon.CurrencyId = Convert.ToInt32(HiddenCurrencyId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {

                HiddenCurrrencyAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();

            }
            int intUsrRolMstrId = 0, intEnableAdd = 0;
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.FMS_POSTDATED_CHEQUE);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenConfirmStatus.Value = "0";

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                        intEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                        HiddenEnableModify.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                        HiddenEnableDelete.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                        HiddenProvisionSts.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                        HiddenReopenSts.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                        HiddenAuditProvisionStatus.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        HiddenConfirmStatus.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
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
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            if (dtfinaclYear.Rows.Count > 0)
            {
                objEntity_Cheque.FiancialStatDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity_Cheque.FiancialEndDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());

                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objEntityCommon);
                DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objEntityCommon);
                DateTime curntdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtToDate.Value = objBusinessLayer.LoadCurrentDateInString();
                    if (txtToDate.Value != "")
                    {
                        objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtToDate.Value);
                    }
                    curntdate = curntdate.AddDays(-30);
                    if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromDate.Value = curntdate.ToString("dd-MM-yyyy");
                        if (txtFromDate.Value != "")
                        {
                            objEntity_Cheque.ChequeDate = objCommon.textToDateTime(txtFromDate.Value);
                        }
                    }
                    else
                    {
                        txtFromDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        if (txtFromDate.Value != "")
                        {
                            objEntity_Cheque.ChequeDate = objCommon.textToDateTime(txtFromDate.Value);
                        }
                    }
                }
                else
                {
                    txtToDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    curntdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                    curntdate = curntdate.AddDays(-30);
                    if (curntdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromDate.Value = curntdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }

            }
            if (ddlAccount.SelectedValue != "0" && ddlAccount.SelectedValue != "--SELECT--")
                objEntity_Cheque.LedgerId = Convert.ToInt32(ddlAccount.SelectedValue);
            objEntity_Cheque.ConfirmStatus = Convert.ToInt32(DdlStatus.SelectedValue);
            if (txtToDate.Value != "")
            {
                objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtToDate.Value);
            }
            if (txtFromDate.Value != "")
            {
                objEntity_Cheque.ChequeDate = objCommon.textToDateTime(txtFromDate.Value);
            }
            if (HiddenFinancialStartDate.Value != "")
                objEntity_Cheque.FiancialStatDate = objCommon.textToDateTime(HiddenFinancialStartDate.Value);
            if (HiddenFnancialEndDeate.Value != "")
                objEntity_Cheque.FiancialEndDate = objCommon.textToDateTime(HiddenFnancialEndDeate.Value);
            if (cbxCnclStatus.Checked)
            {
                objEntity_Cheque.Status = 1;
            }
            else
            {
                objEntity_Cheque.Status = 0;
            }
            objEntity_Cheque.TransactionType = Convert.ToInt32(ddlType.Value);
            DataTable dtList = objBusiness_Cheque.PostDatedCheque_List(objEntity_Cheque);
            divList.InnerHtml = ConvertDataTableToHTML(dtList);
            divPrintCaption.InnerHtml = PrintCaption(objEntity_Cheque);
            if (Request.QueryString["InsUpd"] != null)
            {
                if (Request.QueryString["InsUpd"] == "cncl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClose", "SuccessClose();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Error")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessError", "SuccessError();", true);
                }
                else if (Request.QueryString["InsUpd"] == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDeleted", "SuccessDeleted();", true);
                }
                else if (Request.QueryString["InsUpd"] == "NotConfrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlredyConfirm", "AlredyConfirm();", true);
                }
                    //0039
                //else if (Request.QueryString["InsUpd"] == "Allconfirm")
                //{
                //    ScriptManager.RegisterStartupScript(this, GetType(), "AlredyConfirm", "AlredyConfirm();", true);
                //}
                    //END
                else if (Request.QueryString["InsUpd"] == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (Request.QueryString["InsUpd"] == "UpdConfm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclCnfMsg", "CanclCnfMsg();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                //0039
                else if (Request.QueryString["InsUpd"] == "AllreadyReop")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AllreadyReopened", "AllreadyReopened();", true);
                }
                //end
                //0039
                else if (Request.QueryString["InsUpd"] == "Reopens")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Reopensucce", "Reopensucce();", true);
                }
                //en
                //end
              
            }
        }
    }
    //0039
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
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque(); 
        string PreparedBy = "";

        if (UsrName != "")
        {
            PreparedBy = UsrName;
        }

        FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque_List objPage = new FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque_List();

        string CheckedBy = "";
        if (strCorpID != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
        }
        if (strOrgIdID != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(strOrgIdID);
        }

        //0039
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(strrId);
        DataTable dtforprnnt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
        DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_ById(objEntity_Cheque);
        //end

        int TransctnType = Convert.ToInt32(dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString());

        DataTable dtCorp = objBusiness_Cheque.ReadCorpDtls(objEntity_Cheque);
        if (TransctnType == 0)
        {
            objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PDC_PAYMENT);
        }
        else
        {
            objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PDC_RECEIPT);
        } 
        
        string strReturn = "";
        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                //strReturn = objPage.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntityPayment);
                //strReturn = objBusiness_Cheque.PdfPrintVersion1(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque);
                strReturn = objBusiness_Cheque.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 2, crncyAbrvt);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBusiness_Cheque.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 2, crncyAbrvt);
                //strReturn = objPage.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dt, dtProduct, dtCorp, objEntity_Cheque, 2, dtPayment, crncyAbrvt, dtCost);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBusiness_Cheque.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 3, crncyAbrvt);
            }
        }
        return strReturn;

    }
    //end

    public string PrintCaption(clsEntity_Postdated_Cheque objEntity_Cheque)
    {
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = objEntity_Cheque.Corporate_id;
        objEntityReports.Organisation_Id = objEntity_Cheque.Organisation_id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "POSTDATED CHEQUE";
        DateTime datetm = objBusiness.LoadCurrentDate(); ;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string usrName = "<B> Report Generated By: </B>" + Session["USERFULLNAME"];
        string GuaranteDivsn = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
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
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strUsrName = "";
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
        return sbCap.ToString();
    }
    public void LoadAccountHeadLedger()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
        DataTable dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
        if (dtAccountGrp.Rows.Count > 0)
        {
            ddlAccount.DataSource = dtAccountGrp;
            ddlAccount.DataTextField = "LDGR_NAME";
            ddlAccount.DataValueField = "LDGR_ID";
            ddlAccount.DataBind();

        }
        ddlAccount.Items.Insert(0, "--SELECT--");
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["ORGID"] != null)
        {
            objEntityAudit.Organisation_id = Convert.ToInt32(Session["ORGID"]);
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAudit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
        DateTime acntClsDate = DateTime.MinValue;
        int YearEndCls = 0;
        if (dtAcntClsDate.Rows.Count > 0)
        {
            YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());
            if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
            {
                acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
            }
        }

        if (YearEndCls == 1)
        {
            divAdd.Visible = false;
        }
        decimal Total = 0;
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\">";
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        strHtml += "<th class=\"col-md-2 tr_l\">Ref#<br>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\">";
        strHtml += "</th>";

        strHtml += "<th class=\"col-md-2 tr_l\">Account Name";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Account Name\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "</th>";
        strHtml += "<th class=\"col-md-2 tr_l\">Party";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Party\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "</th>";
        strHtml += " <th class=\"col-md-1\">Date";
        strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Date\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "</th>";
        strHtml += "<th class=\"col-md-2 tr_r\">Total Amount";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"Total Amount\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        if (cbxCnclStatus.Checked == false)
        {
            strHtml += "<th class=\"col-md-1\">Status";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
            strHtml += "</th>";
        }
        strHtml += "<th class=\"col-md-3\">Actions";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        strHtml += "<th  class=\"col-md-3\">";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        strHtml += "<th  class=\"col-md-3\">";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString());
            string strId = dt.Rows[intRowBodyCount]["PST_CHEQUE_ID"].ToString();
            int intIdLength = dt.Rows[intRowBodyCount]["PST_CHEQUE_ID"].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString();
            decimal value = 0;
            string valuestring ="";
            if (dt.Rows[intRowBodyCount]["PST_CHEQUE_AMOUNT"].ToString() != "")
            {
                Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["PST_CHEQUE_AMOUNT"].ToString());
                value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["PST_CHEQUE_AMOUNT"].ToString());
                int precision = Convert.ToInt32(HiddenDecimalCount.Value);
                string format = String.Format("{{0:N{0}}}", precision);
                valuestring = String.Format(format, value);
            }
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["PST_CHEQUE_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["PARTY"].ToString() + "</td>";

            objEntityAudit.FromDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString());
            strHtml += "<td class=\"\"><span style=\"display:none;\">" + dt.Rows[intRowBodyCount]["PST_CHEQUE_DATEO"].ToString() + "</span> " + dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_r\" > " + valuestring + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";// EVM-0024
            // strHtml += "<td class=\"col-md-2\"  > " + dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() + "</td>";
            if (cbxCnclStatus.Checked == false)
            {
                //if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                //    strHtml += "<td class=\"tdT\">Confirmed </td>";
                if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "0" && dt.Rows[intRowBodyCount]["PST_CHEQUE_REOPEN_STATUS"].ToString() == "1")
                {
                    if (dt.Rows[intRowBodyCount]["PST_CHEQUE_REOPEN_USR_ID"].ToString() != "")
                        strHtml += "<td class=\"tdT\" > Reopened</td>";
                }
                else if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1" && Convert.ToInt32(dt.Rows[intRowBodyCount]["PST_CHEQUE_PYMNT_STATUS"].ToString()) == 0)
                    strHtml += "<td class=\"tdT\"> Payment Pending</td>";
                else if (Convert.ToInt32(dt.Rows[intRowBodyCount]["PST_CHEQUE_PYMNT_STATUS"].ToString()) == 1)
                    strHtml += "<td class=\"tdT\"> Payment Completed</td>";
                else if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "0")
                    strHtml += "<td class=\"tdT\">Pending </td>";
            }
            DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
            strHtml += " <td>";
            if ((HiddenEnableModify.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (YearEndCls == 0)
                    {
                        if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                        {
                            if (DdlStatus.SelectedValue == "1" || DdlStatus.SelectedValue == "2")
                                //         strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                                // else  if(DdlStatus.SelectedValue=="2")
                                strHtml += " <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                        }
                        else
                        {
                            if (dtAuditClsDate.Rows.Count > 0)
                            {
                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                                {
                                    if (HiddenAuditProvisionStatus.Value.ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                                        strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";

                                    else
                                        strHtml += "  <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                                }
                                else
                                    strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                            }
                            else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                            {
                                if ((HiddenProvisionSts.Value.ToString()) == clsCommonLibrary.StatusAll.Active.ToString())
                                    strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                                else
                                    strHtml += "  <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                            }
                            else
                                strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                        }
                    }
                    else
                    {
                        strHtml += "  <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                    }

                }
            }
            if ((HiddenConfirmStatus.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (YearEndCls == 0)
                    {
                        if (dtAuditClsDate.Rows.Count > 0)
                        {
                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                            {
                                if ((HiddenAuditProvisionStatus.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    if (strCancTransaction == "0")
                                        strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                                    else
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                                }
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                            {
                                if (strCancTransaction == "0")
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }
                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if ((HiddenProvisionSts.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                if (strCancTransaction == "0")
                                {
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                }

                                else
                                {
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                }
                            }
                            else
                            {
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }
                        else
                        {
                            if (strCancTransaction == "0")
                            {
                                strHtml += "<a  href=\"javascript:;\"   class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                            {
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }
                    }
                    else
                    {
                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                    }
                }
            }
            if ((HiddenReopenSts.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (YearEndCls == 0)
                    {
                        if (dtAuditClsDate.Rows.Count > 0)
                        {
                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                            {
                                if ((HiddenAuditProvisionStatus.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    if (strCancTransaction == "1")
                                    {
                                        strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                    }
                                    else
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                }
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                            {
                                if (strCancTransaction == "1")
                                {
                                    if (Convert.ToInt32(dt.Rows[intRowBodyCount]["VOCHR_SETL_ID"].ToString()) > 0)
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                    else
                                        strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                }
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }
                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if ((HiddenProvisionSts.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                if (strCancTransaction == "1")
                                {
                                    //  strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                }
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                        {
                            if (strCancTransaction == "1")
                            {
                                if (Convert.ToInt32(dt.Rows[intRowBodyCount]["CONFIRM_STATUS"].ToString()) == 0)
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else
                    {
                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                    }

                }
            }
            if ((HiddenEnableDelete.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (cbxCnclStatus.Checked == false)
                {
                    if (YearEndCls == 0)
                    {
                        if (dtAuditClsDate.Rows.Count > 0)
                        {
                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                            {
                                if ((HiddenAuditProvisionStatus.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    if (strCancTransaction == "0")
                                        strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                    else
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                }
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                            {
                                if (strCancTransaction == "0")
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }
                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if (YearEndCls == 0 && (HiddenProvisionSts.Value).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                if (strCancTransaction == "0")
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                        {
                            if (strCancTransaction == "0")
                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else
                    {
                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                    }

                }
            }

            if (cbxCnclStatus.Checked == true)
            {
                strHtml += "  <a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a></td>";
            }
            else
            {
                //0039
                strHtml += " <a class=\"btn act_btn bn6\" title=\"Print\" onclick=\"return PrintPdf('" + Id + "')\"><i class=\"fa fa-print\"></i></a>";

                //end
            }


            strHtml += " </td>";
            strHtml += "<td > " + dt.Rows[intRowBodyCount]["PST_CHEQUE_ID"].ToString() + "</td>";
            strHtml += "<td class=\"col-md-2\"  > " + dt.Rows[intRowBodyCount]["CHEQUE_AMOUNT"].ToString() + "</td>";

                 
             
            strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        if (dt.Rows.Count > 0)
        {
            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" >TOTAL </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\"  style=\"text-align:right;\"> " + objBusinessLayer.AddCommasForNumberSeperation(Total.ToString(), objentcommn) + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }


    public static string ConvertDataTableToHTMLWeb(DataTable dt,string strHiddenDecimalCount,string strHiddenEnableModify,string strHiddenAuditProvisionStatus,string strHiddenProvisionSts,string strHiddenConfirmStatus,string strHiddenReopenSts,string strHiddenEnableDelete, string strOrgIdID, string strCorpID, string sStatus)
    {

        FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque_List objPage = new FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque_List();

        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (strOrgIdID != null && strOrgIdID!="")
        {
            objEntityAudit.Organisation_id = Convert.ToInt32(strOrgIdID);
            intOrgId = Convert.ToInt32(strOrgIdID);
            objentcommn.Organisation_Id = Convert.ToInt32(strOrgIdID);
        }
        if (strCorpID != null && strCorpID!="")
        {
            objEntityAudit.Corporate_id = Convert.ToInt32(strCorpID);
            objentcommn.CorporateID = Convert.ToInt32(strCorpID);
        }
        DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
        int YearEndCls = 0;
        DateTime acntClsDate = DateTime.MinValue;
        if (dtAcntClsDate.Rows.Count > 0)
        {
            YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());
            if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
            {
                acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
            }
        }
        decimal Total = 0;
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" width=\"100%\">";
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        strHtml += "<th class=\"col-md-2 tr_l\">Ref#<br>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Ref#\">";
        strHtml += "</th>";

        strHtml += "<th class=\"col-md-2 tr_l\">Account Name";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Account Name\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "</th>";
        strHtml += "<th class=\"col-md-2 tr_l\">Party";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Party\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "</th>";
        strHtml += " <th class=\"col-md-1\">Date";
        strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in\" placeholder=\"Date\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "</th>";
        strHtml += "<th class=\"col-md-2 tr_r\">Total Amount";
        strHtml += "<input type=\"text\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"Total Amount\" onkeydown=\"return DisableEnter(event)\">";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
       
            strHtml += "<th class=\"col-md-1\">Status";
            strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
            strHtml += "</th>";
        strHtml += "<th class=\"col-md-3\">Actions";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        strHtml += "<th  class=\"col-md-3\">";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        strHtml += "<th  class=\"col-md-3\">";
        strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>";
        strHtml += "</th>";
        strHtml += "</tr>";
        strHtml += "</thead>";
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int AcntClsSts = objPage.AccountCloseCheck(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString());
            string strId = dt.Rows[intRowBodyCount]["PST_CHEQUE_ID"].ToString();
            int intIdLength = dt.Rows[intRowBodyCount]["PST_CHEQUE_ID"].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString();
            decimal value = 0;
            string valuestring = "";
            if (dt.Rows[intRowBodyCount]["PST_CHEQUE_AMOUNT"].ToString() != "")
            {
                Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["PST_CHEQUE_AMOUNT"].ToString());
                value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["PST_CHEQUE_AMOUNT"].ToString());
                int precision = Convert.ToInt32(strHiddenDecimalCount);
                string format = String.Format("{{0:N{0}}}", precision);
                valuestring = String.Format(format, value);
            }
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["PST_CHEQUE_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["PARTY"].ToString() + "</td>";

            objEntityAudit.FromDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString());
            strHtml += "<td class=\"\"><span style=\"display:none;\">" + dt.Rows[intRowBodyCount]["PST_CHEQUE_DATEO"].ToString() + "</span> " + dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tr_r\" > " + valuestring + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";// EVM-0024
            // strHtml += "<td class=\"col-md-2\"  > " + dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() + "</td>";
           
                //if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                //    strHtml += "<td class=\"tdT\">Confirmed </td>";
                if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "0" && dt.Rows[intRowBodyCount]["PST_CHEQUE_REOPEN_STATUS"].ToString() == "1")
                {
                    if (dt.Rows[intRowBodyCount]["PST_CHEQUE_REOPEN_USR_ID"].ToString() != "")
                        strHtml += "<td class=\"tdT\" > Reopened</td>";
                }
                else if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1" && Convert.ToInt32(dt.Rows[intRowBodyCount]["PST_CHEQUE_PYMNT_STATUS"].ToString()) == 0)
                    strHtml += "<td class=\"tdT\"> Payment Pending</td>";
                else if (Convert.ToInt32(dt.Rows[intRowBodyCount]["PST_CHEQUE_PYMNT_STATUS"].ToString()) == 1)
                    strHtml += "<td class=\"tdT\"> Payment Completed</td>";
                else if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "0")
                    strHtml += "<td class=\"tdT\">Pending </td>";

            DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
            strHtml += " <td>";
            if ((strHiddenEnableModify).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (YearEndCls == 0)
                {

                    if (dt.Rows[intRowBodyCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                    {
                        if (sStatus == "1" || sStatus == "2")
                            //         strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                            // else  if(DdlStatus.SelectedValue=="2")
                            strHtml += " <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                    }
                    else
                    {
                        if (dtAuditClsDate.Rows.Count > 0)
                        {
                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                            {
                                if (strHiddenAuditProvisionStatus == (clsCommonLibrary.StatusAll.Active).ToString())
                                    strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";

                                else
                                    strHtml += "  <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                            }
                            else
                                strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                        }
                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if ((strHiddenProvisionSts) == clsCommonLibrary.StatusAll.Active.ToString())
                                strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                            else
                                strHtml += "  <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                        }
                        else
                            strHtml += "  <a  class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                    }
                }
                else
                {
                    strHtml += "  <a  class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " + " href=\"fms_Postdated_Cheque.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                }
            }
            if ((strHiddenConfirmStatus).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (YearEndCls == 0)
                {
                    if (dtAuditClsDate.Rows.Count > 0)
                    {
                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if ((strHiddenAuditProvisionStatus).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                if (strCancTransaction == "0")
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                        {
                            if (strCancTransaction == "0")
                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                    {
                        if ((strHiddenProvisionSts).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (strCancTransaction == "0")
                            {
                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                            }

                            else
                            {
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                            }
                        }
                        else
                        {
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else
                    {
                        if (strCancTransaction == "0")
                        {
                            strHtml += "<a  href=\"javascript:;\"   class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                        {
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                }
                else
                {
                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                }

            }
            if ((strHiddenReopenSts).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (YearEndCls == 0)
                {
                    if (dtAuditClsDate.Rows.Count > 0)
                    {
                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if ((strHiddenAuditProvisionStatus).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                if (strCancTransaction == "1")
                                {
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                }
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                        {
                            if (strCancTransaction == "1")
                            {
                                if (Convert.ToInt32(dt.Rows[intRowBodyCount]["VOCHR_SETL_ID"].ToString()) > 0)
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                    {
                        if ((strHiddenProvisionSts).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (strCancTransaction == "1")
                            {
                                //  strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                    }
                    else
                    {
                        if (strCancTransaction == "1")
                        {
                            if (Convert.ToInt32(dt.Rows[intRowBodyCount]["CONFIRM_STATUS"].ToString()) == 0)
                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                    }
                }
                else
                {
                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                }

            }
            if ((strHiddenEnableDelete).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
            {
                if (YearEndCls == 0)
                {
                    if (dtAuditClsDate.Rows.Count > 0)
                    {
                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                        {
                            if ((strHiddenAuditProvisionStatus).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                if (strCancTransaction == "0")
                                    strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                else
                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            }
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                        {
                            if (strCancTransaction == "0")
                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }
                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["PST_CHEQUE_DATE"].ToString()))
                    {
                        if ((strHiddenProvisionSts).ToString() == (clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (strCancTransaction == "0")
                                strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                            else
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                        else
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                    }
                    else
                    {
                        if (strCancTransaction == "0")
                            strHtml += "<a  href=\"javascript:;\"  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        else
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                    }
                }
                else
                {
                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\";  class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                }

            }

                //0039
                strHtml += " <a class=\"btn act_btn bn6\" title=\"Print\" onclick=\"return PrintPdf(1)\"><i class=\"fa fa-print\"></i></a>";
                //end

            strHtml += " </td>";
            strHtml += "<td > " + dt.Rows[intRowBodyCount]["PST_CHEQUE_ID"].ToString() + "</td>";
            strHtml += "<td class=\"col-md-2\"  > " + dt.Rows[intRowBodyCount]["CHEQUE_AMOUNT"].ToString() + "</td>";


            strHtml += "</tr>";
        }

        if (dt.Rows.Count > 0)
        {
            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" >TOTAL </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\"  style=\"text-align:right;\"> " + objBusinessLayer.AddCommasForNumberSeperation(Total.ToString(), objentcommn) + "  " + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + "</th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "</tr></tfoot>";
        }

        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    public  int AccountCloseCheck(string strDate)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objBusEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objBusEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlAccount.SelectedValue != "0" && ddlAccount.SelectedValue != "--SELECT--")
            objEntity_Cheque.LedgerId = Convert.ToInt32(ddlAccount.SelectedValue);
        objEntity_Cheque.ConfirmStatus = Convert.ToInt32(DdlStatus.SelectedValue);
        if (txtToDate.Value != "")
        {
            objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtToDate.Value);
        }
        if (txtFromDate.Value != "")
        {
            objEntity_Cheque.ChequeDate = objCommon.textToDateTime(txtFromDate.Value);
        }
        if(HiddenFinancialStartDate.Value!="")
            objEntity_Cheque.FiancialStatDate = objCommon.textToDateTime(HiddenFinancialStartDate.Value);
        if (HiddenFnancialEndDeate.Value != "")
            objEntity_Cheque.FiancialEndDate = objCommon.textToDateTime(HiddenFnancialEndDeate.Value);
        if (cbxCnclStatus.Checked)
        {
            objEntity_Cheque.Status = 1;
        }
        else
        {
            objEntity_Cheque.Status = 0;
        }
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlType.Value);
        DataTable dtList = objBusiness_Cheque.PostDatedCheque_List(objEntity_Cheque);
        divList.InnerHtml = ConvertDataTableToHTML(dtList);
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ConfirmPostdatedChequeDetails(string strUserID, string strChequeId, string strOrgIdID, string strCorpID, string FinYrID, string LedgrId, string Status, string ToDate, string FromDate, string FinStartDate, string FinEndDate, string TransType,
        string strHiddenDecimalCount, string strHiddenEnableModify, string strHiddenAuditProvisionStatus, string strHiddenProvisionSts, string strHiddenConfirmStatus, string strHiddenReopenSts, string strHiddenEnableDelete)
    {
        string[] strHtmlu = new string[2];
        string strRets = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        List<clsEntity_Postdated_Cheque> objEntityChequeDtls = new List<clsEntity_Postdated_Cheque>();
        strRets = "successConfirm";

        string strRandomMixedId = strChequeId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(strId);
        objEntity_Cheque.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity_Cheque.Corporate_id = Convert.ToInt32(strCorpID);
        objEntity_Cheque.User_Id = Convert.ToInt32(strUserID);

        DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);

        if (dt.Rows.Count > 0)
        {
            objEntity_Cheque.TransactionType = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString());
            objEntity_Cheque.RefNumber = dt.Rows[0]["PST_CHEQUE_REF"].ToString();
            objEntity_Cheque.PartId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
            objEntity_Cheque.PostdatedChequeDate = objCommon.textToDateTime(dt.Rows[0]["PST_CHEQUE_DATE"].ToString());
            objEntity_Cheque.TotalAmount = Convert.ToDecimal(dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString());

            objEntity_Cheque.Method = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_METHOD_STS"].ToString());

            if (dt.Rows[0]["SALES_ID"].ToString() != "" || dt.Rows[0]["PURCHS_ID"].ToString() != "")
            {
                if (objEntity_Cheque.TransactionType == 0)
                {
                    objEntity_Cheque.PurchaseId = Convert.ToInt32(dt.Rows[0]["PURCHS_ID"].ToString());
                    objEntity_Cheque.SalePurchaseAmnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_BAL_AMT"].ToString());
                }
                else if (objEntity_Cheque.TransactionType == 1)
                {
                    objEntity_Cheque.SalesId = Convert.ToInt32(dt.Rows[0]["SALES_ID"].ToString());
                    objEntity_Cheque.SalePurchaseAmnt = Convert.ToDecimal(dt.Rows[0]["BALNC_AMT"].ToString());
                }
            }
            if (dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString() != "")
            {
                objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString());
            }
            if (dt.Rows[0]["PST_CHEQUE_CLRNC_LDGRID"].ToString() != "")
            {
                objEntity_Cheque.ClearanceLedger = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_CLRNC_LDGRID"].ToString());
            }
            if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
            {
                objEntity_Cheque.Description = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();
            }
            objEntity_Cheque.FinancialYrId = Convert.ToInt32(FinYrID);

            DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_ById(objEntity_Cheque);
            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
            {
                clsEntity_Postdated_Cheque objEntity = new clsEntity_Postdated_Cheque();

                objEntity.ChequeAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                objEntity.ChequeDate = objCommon.textToDateTime(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_CHQ_DATE"].ToString());
                if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_REMARK"].ToString() != "")
                {
                    objEntity.Remarks = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_REMARK"].ToString();
                }
                objEntityChequeDtls.Add(objEntity);
            }

        }

        if (objEntity_Cheque.Method == 1)
        {
            if (objEntity_Cheque.TotalAmount > objEntity_Cheque.SalePurchaseAmnt)
            {
                strRets = "AmntERR";
            }
        }


        try
        {
            DataTable dtPaidStatus = objBusiness_Cheque.CheckChequeCanceled(objEntity_Cheque);
            if (dtPaidStatus.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) > 0)
                {
                    strRets = "Canceled";
                }
                else if (dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
                {
                    strRets = "Alreadyconfrm";
                }
                else
                {
                    objEntity_Cheque.ConfirmStatus = 1;

                    //-------------confirm---------

                    if (strRets != "AmntERR")
                    {
                        objBusiness_Cheque.Confirm_List(objEntity_Cheque, objEntityChequeDtls);
                    }
                }
            }
            if (LedgrId != "0" && LedgrId != "--SELECT--")
                objEntity_Cheque.LedgerId = Convert.ToInt32(LedgrId);
            objEntity_Cheque.ConfirmStatus = Convert.ToInt32(Status);
            if (ToDate != "")
            {
                objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(ToDate);
            }
            if (FromDate != "")
            {
                objEntity_Cheque.ChequeDate = objCommon.textToDateTime(FromDate);
            }
            if (FinStartDate != "")
                objEntity_Cheque.FiancialStatDate = objCommon.textToDateTime(FinStartDate);
            if (FinEndDate != "")
                objEntity_Cheque.FiancialEndDate = objCommon.textToDateTime(FinEndDate);
            objEntity_Cheque.Status = 0;
            objEntity_Cheque.TransactionType = Convert.ToInt32(TransType);
            DataTable dtList = objBusiness_Cheque.PostDatedCheque_List(objEntity_Cheque);
            strHtmlu[1] = ConvertDataTableToHTMLWeb(dtList, strHiddenDecimalCount, strHiddenEnableModify, strHiddenAuditProvisionStatus, strHiddenProvisionSts, strHiddenConfirmStatus, strHiddenReopenSts,
                strHiddenEnableDelete, strOrgIdID, strCorpID, Status);
        }
        catch
        {
            strRets = "failed";
        }
        strHtmlu[0] = strRets;
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        return strHtmlu;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ReopenPostdatedChequeDetails(string strUserID, string strChequeId, string strOrgIdID, string strCorpID, string FinYrID,string LedgrId,string Status,string ToDate,string FromDate,string FinStartDate,string FinEndDate,string TransType,
        string strHiddenDecimalCount,string strHiddenEnableModify,string strHiddenAuditProvisionStatus,string strHiddenProvisionSts,string strHiddenConfirmStatus,string strHiddenReopenSts,string strHiddenEnableDelete)
    {
        string[] strHtmlu = new string[2];
        string strRets = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        strRets = "successReopen";

        string strRandomMixedId = strChequeId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(strId);
        objEntity_Cheque.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity_Cheque.Corporate_id = Convert.ToInt32(strCorpID);
        objEntity_Cheque.User_Id = Convert.ToInt32(strUserID);

        try
        {
            DataTable dtPaidStatus = objBusiness_Cheque.CheckChequePaid(objEntity_Cheque);
            if (dtPaidStatus.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) > 0)
                {
                    strRets = "Paid";
                }
                else
                {
                    objEntity_Cheque.ConfirmStatus = 1;

                    DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
                    if (dt.Rows.Count > 0)
                    {
                        objEntity_Cheque.TotalAmount = Convert.ToDecimal(dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString());
                        objEntity_Cheque.TransactionType = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString());
                        objEntity_Cheque.PartId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
                        objEntity_Cheque.ClearanceLedger = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_CLRNC_LDGRID"].ToString());

                        if (dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                        {
                            if (dt.Rows[0]["PURCHS_ID"].ToString() != "")
                            {
                                objEntity_Cheque.PurchaseId = Convert.ToInt32(dt.Rows[0]["PURCHS_ID"].ToString());
                            }
                        }
                        else
                        {
                            if (dt.Rows[0]["SALES_ID"].ToString() != "")
                            {
                                objEntity_Cheque.SalesId = Convert.ToInt32(dt.Rows[0]["SALES_ID"].ToString());
                            }
                        }
                    }

                    //0039
                    //DataTable dt1 = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
                    if (dt.Rows[0]["PST_CHEQUE_REOPEN_USR_ID"].ToString() != "" && dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "0")
                    {
                        strRets = "Alreadyreopen";
                    }
                    //end

                    objBusiness_Cheque.Reopen_list(objEntity_Cheque);
                }
            }
            if (LedgrId != "0" && LedgrId != "--SELECT--")
                objEntity_Cheque.LedgerId = Convert.ToInt32(LedgrId);
            objEntity_Cheque.ConfirmStatus = Convert.ToInt32(Status);
            if (ToDate != "")
            {
                objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(ToDate);
            }
            if (FromDate != "")
            {
                objEntity_Cheque.ChequeDate = objCommon.textToDateTime(FromDate);
            }
            if (FinStartDate != "")
                objEntity_Cheque.FiancialStatDate = objCommon.textToDateTime(FinStartDate);
            if (FinEndDate != "")
                objEntity_Cheque.FiancialEndDate = objCommon.textToDateTime(FinEndDate);
                objEntity_Cheque.Status = 0;
                objEntity_Cheque.TransactionType = Convert.ToInt32(TransType);
            DataTable dtList = objBusiness_Cheque.PostDatedCheque_List(objEntity_Cheque);
            strHtmlu[1] = ConvertDataTableToHTMLWeb(dtList,strHiddenDecimalCount,strHiddenEnableModify,strHiddenAuditProvisionStatus,strHiddenProvisionSts,strHiddenConfirmStatus,strHiddenReopenSts,
                strHiddenEnableDelete, strOrgIdID, strCorpID, Status);

          
        }
        catch
        {
            strRets = "failed";
        }
        strHtmlu[0] = strRets;
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        return strHtmlu;
    }
    [WebMethod]
    public static string Cancelpostdated_cheque(string strCatId, string reasonmust, string usrId, string cnclRsn, string orgid, string corptid)
    {
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int flag = 0;
        string strRets = "successcncl";
        string strRandomMixedId = strCatId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(strId);
        objEntity_Cheque.User_Id = Convert.ToInt32(usrId);
        objEntity_Cheque.Organisation_id = Convert.ToInt32(orgid);
        objEntity_Cheque.Corporate_id = Convert.ToInt32(corptid);
        if (reasonmust == "1")
        {
            objEntity_Cheque.CancelReason = cnclRsn;
        }
        else
        {
            objEntity_Cheque.CancelReason = objCommon.CancelReason();
        }
        try
        {
            Page objpage = new Page();
            DataTable dtPConfrm = objBusiness_Cheque.CheckChequeConfirmed(objEntity_Cheque);
            DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
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
                if (dt.Rows[0]["PST_CHEQUE_CNCL_USR_ID"].ToString() != "" && dt.Rows[0]["PST_CHEQUE_CNCL_REASN"].ToString() != "")
                {
                    strRets = "AlreadyCancl";
                }
                objBusiness_Cheque.CancelPostDatedCheque(objEntity_Cheque);
                objpage.Session["SuccessMsg"] = "DELETE";
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }


    //0039 pdf v 23
    public string PdfPrintVersion2And3(DataTable dtforprnnt, DataTable dtLDGRdTLS, DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntity_Postdated_Cheque objEntityCheque, int VersionFlag, DataTable dtPayment, string currency, DataTable dtCost)
    {
        globfalg = VersionFlag;
        string PreparedBy = "";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PAYMENT_INVOICE);
        string CheckedBy = "";
        int intCorpId = 0;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (objEntityCheque.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = objEntityCheque.Corporate_id;
            intCorpId = objEntityCheque.Corporate_id;
        }
        if (objEntityCheque.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = objEntityCheque.Organisation_id;
        }

        if (dtforprnnt.Rows.Count > 0)
        {
            if (dtforprnnt.Rows[0]["CRNCMST_ID"].ToString() != "")
                objEntityCommon.CurrencyId = Convert.ToInt32(dtforprnnt.Rows[0]["CRNCMST_ID"].ToString());
            if (dtforprnnt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                currency = dtforprnnt.Rows[0]["CRNCMST_ABBRV"].ToString();
        }

        string strId = "";
        strId = Convert.ToString(objEntityCheque.PaymentId);
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.DFLT_CURNCY_DISPLAY,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                   };
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_PRINT);
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        int DecCnt = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());

        //0039
        globhead = Convert.ToInt32(dtforprnnt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString());
        //end
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "Payment_Invoice" + strId + "_" + strNextNumber + ".pdf";
        Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
        if (VersionFlag == 2)
        {
            document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
        }
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        string strRet = "";
        try
        {
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                if (VersionFlag == 2)
                {
                    writer.PageEvent = new PDFHeader();
                    document.Open();
                }
                else
                {
                    document.Open();
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                }

               

                PdfPTable footrtable = new PdfPTable(2);
                float[] footrsBody = { 20, 80 };
                footrtable.SetWidths(footrsBody);
                footrtable.WidthPercentage = 100;
                //PdfPTable footrtableHead = new PdfPTable(2);
               

                footrtable.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(": " + dtforprnnt.Rows[0]["PST_CHEQUE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                
                footrtable.AddCell(new PdfPCell(new Phrase("Postdated Cheque #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(": " + dtforprnnt.Rows[0]["PST_CHEQUE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

                footrtable.AddCell(new PdfPCell(new Phrase("A/C BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });             
                document.Add(footrtable);

                document.Add(new Paragraph(new Chunk("Cheque Details", FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


                var FontGrey = new BaseColor(134, 152, 160);
                var FontBordrGrey = new BaseColor(236, 236, 236);
                var FontBordrBlack = new BaseColor(138, 138, 138);
                var FontGreySmall = new BaseColor(236, 236, 236);
                var FontColour = new BaseColor(255, 255, 255);

                string strAmountComma = "";
                string strAmountCommaTotal = "";
                decimal TOTAL = 0;

                PdfPTable table4 = new PdfPTable(3);
                float[] table4Body = { 33, 33, 34 };
                table4.SetWidths(table4Body);
                table4.WidthPercentage = 100;

                table4.AddCell(new PdfPCell(new Phrase("Cheque No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                table4.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                table4.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });


                for (int intRowBodyCount = 0; intRowBodyCount < dtLDGRdTLS.Rows.Count; intRowBodyCount++)
                {
                    if (dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                    {
                        TOTAL += Convert.ToDecimal(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString());
                        strAmountCommaTotal = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(TOTAL.ToString(), objEntityCommon);
                    }
                    table4.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_NUMBER"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                    table4.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_CHQ_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                    table4.AddCell(new PdfPCell(new Phrase(dtLDGRdTLS.Rows[intRowBodyCount]["CHQ_DTLS_AMOUNT"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
                }
                clsBusinessLayer ObjBusiness = new clsBusinessLayer();
                string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
                table4.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack , Colspan = 2 });
                table4.AddCell(new PdfPCell(new Phrase(" " + TOTAL, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = FontBordrBlack });
                document.Add(table4);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

               

                PdfPTable footrtables = new PdfPTable(5);
                float[] footrsBodys = { 19, 37, 9, 11, 20 };
                footrtables.SetWidths(footrsBodys);
                footrtables.WidthPercentage = 100;

                footrtables.AddCell(new PdfPCell(new Phrase("Party   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
                footrtables.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PARTY_LDGR"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
                footrtables.AddCell(new PdfPCell(new Phrase(strAmountComma + "  " + currency, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });
                footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
                footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
                document.Add(footrtables);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


                if (dtforprnnt.Rows[0]["PST_CHEQUE_METHOD_STS"].ToString() == "2")
                {

                    PdfPTable table6 = new PdfPTable(3);
                    float[] table6Bodys = { 33, 33, 34 };
                    table6.SetWidths(table6Bodys);
                    table6.WidthPercentage = 100;

                    table6.AddCell(new PdfPCell(new Phrase("Invoice #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                    table6.AddCell(new PdfPCell(new Phrase("Description", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
                    table6.AddCell(new PdfPCell(new Phrase("Amount", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });

                    table6.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack});
                    table6.AddCell(new PdfPCell(new Phrase(dtforprnnt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack});
                    table6.AddCell(new PdfPCell(new Phrase(" " + TOTAL, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack});
                    document.Add(table6);
                }

                document.Close();
            }
            strRet = strImagePath + strImageName;
        }
        catch (Exception)
        {
            document.Close();
            strRet = "false";
        }
        return strRet;
    }
    //end

    //0039
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
            //if (globfalg == 2)
            //{
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            objEntityLayerStock.Corp_Id = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
            objEntityLayerStock.Org_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
            DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);
            clsCommonLibrary objCommon = new clsCommonLibrary();
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
            if (globhead == 1)
            {
                headtable.AddCell(new PdfPCell(new Phrase("PAYMENT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }
            //0039
            else
            {
                headtable.AddCell(new PdfPCell(new Phrase("DRAFT POSTDATED CHEQUE", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
            }
            //end
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
            //}
            //else
            //{
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
            //}

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
            PdfPTable headImg = new PdfPTable(3);
            string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
            headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
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
            headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(45), writer.DirectContent);

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
    //end




}