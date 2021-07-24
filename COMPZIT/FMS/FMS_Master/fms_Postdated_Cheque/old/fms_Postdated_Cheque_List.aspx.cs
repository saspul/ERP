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
        }

        if (YearEndCls == 1)
        {
            divAdd.Visible = false;
        }
        else
        {
            divAdd.Visible = true;
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

        if (HttpContext.Current.Session["FINCYRID"] != null)
        {
            objentcommn.FinancialYrId = Convert.ToInt32(HttpContext.Current.Session["FINCYRID"]);
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
}