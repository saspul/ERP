using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using CL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;
using System.IO;

public partial class FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List : System.Web.UI.Page
{
    static string strFromDate = "";
    static string strToDate = "";
    static string strStatus = "";
    static string strCnclSts = "";
    static string strAccntBook = "";
    static string strHiddenReopenSts = "";
    static string strHiddenProvisionSts = "0";
    static string strHiddenFieldAuditCloseReopenSts = "";
    static string strhiddenDecimalCount = "";
    static string strHiddenCurrrencyAbrvtn = "";
    static string strhiddenCurrencyModeId = "";
    static string strhiddenDfltCurrencyMstrId = "";
    static string strHiddenFieldRecurrRole = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //ddlAccount.Focus();

        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }

        if (!IsPostBack)
        {

            ddlLedger.Focus();
            AccountLedgerLoad();
            LeadgerLoad();
            clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.User_Id = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

                objEntity.Corporate_id = intCorpId;
                objEntityCommon.CorporateID = intCorpId;
                // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = intOrgId;
                objEntityCommon.Organisation_Id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }







            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            string caption = PrintCaption(objEntity);
            divPrintCaption.InnerHtml = caption;

            int intreopen = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intConfirm = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenProvisionSts.Value = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleUpd.Value = "1";
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenProvisionSts.Value = (clsCommonLibrary.StatusAll.Active).ToString();
                        strHiddenProvisionSts = (clsCommonLibrary.StatusAll.Active).ToString();
                        // HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {

                        intreopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenReopenSts.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                        strHiddenReopenSts = Convert.ToString(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {

                        HiddenFieldAuditCloseReopenSts.Value = "1";
                        strHiddenFieldAuditCloseReopenSts = "1";
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        HiddenFieldRecurrRole.Value = "1";
                        strHiddenFieldRecurrRole = "1";
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


            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            if (dtfinaclYear.Rows.Count > 0)
            {
                objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());


                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();



                DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());


                if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtTodate.Value = objBusinessLayer.LoadCurrentDateInString();
                    curdate = curdate.AddDays(-30);
                    if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromdate.Value = curdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }
                else
                {
                    txtTodate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    curdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                    curdate = curdate.AddDays(-30);
                    if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtFromdate.Value = curdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtFromdate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }


            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };

            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                strhiddenDecimalCount = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                strhiddenDfltCurrencyMstrId = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            // clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {

                HiddenCurrrencyAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                strHiddenCurrrencyAbrvtn = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                strhiddenCurrencyModeId = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();

            }

            if (ddlLedger.SelectedItem.Value != "--SELECT--")
            {
                objEntity.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
            }
            if (ddlAccontLed.SelectedItem.Value != "--SELECT--")
            {
                objEntity.AccntNameId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
            }
            if (txtFromdate.Value != "")
                objEntity.FromDate = objCommon.textToDateTime(txtFromdate.Value);
            if (txtTodate.Value != "")
                objEntity.ToDate = objCommon.textToDateTime(txtTodate.Value);

            objEntity.RcptSts = Convert.ToInt32(ddlRcptSts.SelectedItem.Value);


            strFromDate = txtFromdate.Value;
            strToDate = txtTodate.Value;
            strStatus = ddlRcptSts.SelectedItem.Value;
            if (cbxCnclStatus.Checked == true)
            {
                strCnclSts = "1";
            }
            else
            {
                strCnclSts = "0";
            }
            strAccntBook = ddlAccontLed.SelectedItem.Value;


            DataTable dt = objBussiness.ReadReceiptList(objEntity);
            DataTable dtacntClsDate = objBussiness.ReadAcntClsingDate(objEntity);

            divList.InnerHtml = ConvertDataTableToHTML(dt, intUpdate, intEnableCancel, dtacntClsDate, intConfirm, intreopen);



            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (Request.QueryString["InsUpd"] == "UpdCancl")
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
                else if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (strInsUpd == "UPD")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
                }
                else if (strInsUpd == "SaleAmtExceed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountExceeded", "SalesAmountExceeded();", true);
                }
                    //0039
                else if (strInsUpd == "ALConfrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfrm", "AlreadyConfrm();", true);
                }
                    //END
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                //0039
                else if (strInsUpd == "Reopns")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Reopened", "Reopened();", true);
                }
                //end
                //0039
                else if (strInsUpd == "AllReopns")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AllReopened", "AllReopened();", true);
                }
                //end
                else if (strInsUpd == "AlrdyDeleted")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDeletedList", "SuccessDeletedList();", true);
                }

            }

        }

    }
    public string PrintCaption(clsEntity_Receipt_Account ObjEntityRequest)
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
        strTitle = "RECEIPT";
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
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel, DataTable dtacntClsDate, int intConfirm, int intReopen)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();


        if (strhiddenDfltCurrencyMstrId != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(strhiddenDfltCurrencyMstrId);

        DateTime acntClsDate = DateTime.MinValue;
        int YearEndCls = 0;

        if (Session["FINCYRID"] != null)
        {
            objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtYearEndClsDate = objBusiness.ReadYearEndCloseDate(objEntityCommon);
        if (dtYearEndClsDate.Rows.Count > 0)
        {
            YearEndCls = 1;
        }

        if (dtacntClsDate.Rows.Count > 0)
        {
            if (dtacntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
            {
                acntClsDate = objCommon.textToDateTime(dtacntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
            }
            if (YearEndCls == 1)
            {
                divAdd.Visible = false;
            }
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityAudit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityAudit.Organisation_id = Convert.ToInt32(Session["ORGID"]);

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        // class="table table-bordered table-striped"
        decimal Total = 0;
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" style=\"width: 100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        strHtml += "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"th_b6 tr_l\">REF# ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input id=\"hasRef\"  autocomplete=\"off\"   class=\"tb_inp_1 tb_in\" placeholder=\" REF#\" type=\"text\">  ";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"th_b8 tr_l\" >ACCOUNT ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>	<input id=\"hasAcnt\" autocomplete=\"off\" class=\"tb_inp_1 tb_in\" placeholder=\"ACCOUNT\"  type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"th_b1_4 tr_c\"> DATE ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input id=\"hasDate\" autocomplete=\"off\" class=\"tb_inp_1 tb_in\"  placeholder=\" DATE\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"th_b4 tr_l\"> NARRATION ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input autocomplete=\"off\" class=\"tb_inp_1 tb_in\" placeholder=\"NARRATION\"  type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"th_b7 tr_r\">TOTAL AMOUNT ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input id=\"hasAmt\" autocomplete=\"off\" class=\"tb_inp_1 tb_in\" placeholder=\"TOTAL AMOUNT\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th ></th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                if (strCnclSts == "0")
                {
                    strHtml += "<th class=\"th_b1_4 tr_c\"> STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
                }
                //else
                //{
                //    strHtml += "<th class=\"th_b5 tr_c\" style=display:none;> STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";

                //}
            }
            else if (intColumnHeaderCount == 8)
            {
                strHtml += " <th class=\"th_b4 tr_c\">ACTIONS </th>";
            }

        }

        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int COUNT = 0;
        string amountFrm = "";
        Decimal totalAmntFrm = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            COUNT++;

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td id=\"tdRef\" class=\"tr_l \" >" + dt.Rows[intRowBodyCount]["RECPT_REF"].ToString();
                    if (strHiddenFieldRecurrRole == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["REPAREC_ID"].ToString() != "")
                        {
                            strHtml += "<span class=\"pull-right gre_c\"><i class=\"fa fa-retweet\"></i></span>";
                        }
                    }
                    strHtml += "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td id=\"tdLedgr\" class=\"tr_l \"  >" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    objEntityAudit.FromDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RECPT_DATE"].ToString());
                    strHtml += "<td  id=\"tdDate\" class=\"tr_c \"> " + dt.Rows[intRowBodyCount]["RECPT_DATE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td id=\"tdLedgr\" class=\"tr_l \"  >" + dt.Rows[intRowBodyCount]["RECPT_DSCRPTN"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["RECPT_TOTAL_AMT"].ToString());

                    string strNetAmount = dt.Rows[intRowBodyCount]["RECPT_TOTAL_AMT"].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    amountFrm = strNetAmountWithComma;

                    strHtml += "<td id=\"tdAmnt\"  class=\"tr_r \"  > " + amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td > " + dt.Rows[intRowBodyCount]["RECPT_REF_NEXTNUM"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    if (strCnclSts == "0")
                    {
                        if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() != "1")
                        {

                            if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() == "0" && dt.Rows[intRowBodyCount]["RECPT_REOPEN_STATUS"].ToString() == "1")
                            {
                                if (dt.Rows[intRowBodyCount]["RECPT_REOPEN_USRID"].ToString() != "")
                                {
                                    strHtml += "<td class=\"tr_c \" > REOPENED</td>";
                                }
                            }
                            else if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() == "0")
                            {
                                strHtml += "<td class=\"tr_c \" > PENDING</td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td class=\"tr_c \" > CONFIRMED</td>";
                        }
                    }
                }

                else if (intColumnBodyCount == 8)
                {
                    DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

                    strHtml += " <td >";

                    if (strCnclSts == "1") //deleted view
                    {
                        strHtml += " <a  class=\"btn act_btn bn4\"   title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Receipt_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                    }
                    else
                    { //edit
                        if (YearEndCls == 0)
                        {
                            if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() != "1") //not confirmed
                            {
                                if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    if (dtAuditClsDate.Rows.Count > 0)
                                    {

                                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                        {
                                            if (strHiddenFieldAuditCloseReopenSts == "1")
                                            {
                                                strHtml += " <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                      " href=\"fms_Receipt_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i> </a>";

                                            }
                                            else
                                            {

                                                strHtml += " <a  class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                                     " href=\"fms_Receipt_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "  <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Receipt_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i> </a>";
                                        }

                                    }


                                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                    {

                                        if (strHiddenProvisionSts == (clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            strHtml += "  <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Receipt_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i> </a>";
                                        }

                                        else
                                        {
                                            strHtml += " <a  class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                                " href=\"fms_Receipt_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += " <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Receipt_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i> </a>";
                                    }
                                }

                                if (Convert.ToInt32(strStatus) != 1)
                                {
                                    if (strCnclSts == "0")
                                    {
                                        if (intConfirm == 1)
                                        {
                                            if (dtAuditClsDate.Rows.Count > 0)
                                            {

                                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                                {

                                                    if (strHiddenFieldAuditCloseReopenSts == "1")
                                                    {
                                                        strHtml += "<a  class=\"btn act_btn bn2\"  title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                                    }
                                                    else
                                                    {
                                                        strHtml += "<a  class=\"btn act_btn bn2\" disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                                    }
                                                }
                                                else
                                                {
                                                    strHtml += "<a  class=\"btn act_btn bn2\" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                                }
                                            }
                                            else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                            {

                                                if (strHiddenProvisionSts == (clsCommonLibrary.StatusAll.Active).ToString())
                                                {
                                                    strHtml += "<a  class=\"btn act_btn bn2\"  title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                                }

                                                else
                                                {
                                                    strHtml += "<a   class=\"btn act_btn bn2\"  disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<a  class=\"btn act_btn bn2\" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                            }
                                        }

                                    }
                                }


                            }
                            else  //confirmed
                            {
                                if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                {
                                    strHtml += " <a  class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                      " href=\"fms_Receipt_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                                }


                                if (strCnclSts == "0")
                                {
                                    if (Convert.ToInt32(strStatus) != 1)
                                    {
                                        strHtml += "<a   class=\"btn act_btn bn2\"  disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                    }

                                }
                            }
                        }
                        else
                        {
                            strHtml += " <a  class=\"btn act_btn bn4\" title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                                     " href=\"fms_Receipt_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                            strHtml += "<a   class=\"btn act_btn bn2\"  disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                        }

                        if (YearEndCls == 0)
                        {
                            if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() == "1")
                            {
                                if (strCnclSts == "0")
                                {
                                    if (strHiddenReopenSts == "Active")
                                    {

                                        if (dtAuditClsDate.Rows.Count > 0)
                                        {

                                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                            {

                                                if (strHiddenFieldAuditCloseReopenSts == "1")
                                                {
                                                    strHtml += "  <a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";
                                                }
                                                else
                                                {
                                                    strHtml += " <a disabled href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\" " + " ><i class=\"fa fa-unlock\"></i></a>";
                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";
                                            }

                                        }
                                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                        {

                                            if (strHiddenProvisionSts == (clsCommonLibrary.StatusAll.Active).ToString())
                                            {
                                                strHtml += "  <a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";
                                            }
                                            else
                                            {
                                                strHtml += " <a disabled href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\" " + " ><i class=\"fa fa-unlock\"></i></a>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += " <a href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                            else if (strCnclSts == "0")
                            {
                                if (strHiddenReopenSts == "Active")
                                {
                                    strHtml += "<a disabled href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\"  " +
                                                  " ><i class=\"fa fa-unlock\"></i></a>";
                                }
                            }
                        }
                        else
                        {
                            strHtml += " <a disabled href=\"javascript:;\" class=\"btn act_btn bn2\" title=\"REOPEN\" " + " ><i class=\"fa fa-unlock\"></i></a>";
                        }


                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {
                                if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() != "1")
                                {

                                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                    {

                                        if (dtAuditClsDate.Rows.Count > 0)
                                        {

                                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                            {

                                                if (strHiddenFieldAuditCloseReopenSts == "1")
                                                {
                                                    strHtml += "<a  href=\"javascript:;\" class=\"btn act_btn bn3 \"  title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\" ><i class=\"fa fa-trash\"></i></a>";

                                                }
                                                else
                                                {
                                                    strHtml += "<a  disabled href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" ><i class=\"fa fa-trash\" ></i></a>";

                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<a  href=\"javascript:;\" class=\"btn act_btn bn3 \"  title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\" ><i class=\"fa fa-trash\" ></i></a>";
                                            }
                                        }

                                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["RCPT_DAT"].ToString()))
                                        {
                                            if (strHiddenProvisionSts == (clsCommonLibrary.StatusAll.Active).ToString())
                                            {
                                                strHtml += "<a  href=\"javascript:;\" class=\"btn act_btn bn3 \"  title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\" ><i class=\"fa fa-trash\"></i></a>";
                                            }
                                            else
                                            {
                                                strHtml += "<a class=\"btn act_btn bn3 \" title=\"Delete\" ><i class=\"fa fa-trash\" ></i></a>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" class=\"btn act_btn bn3 \"  title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\" ><i class=\"fa fa-trash\" ></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a  disabled href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" ><i class=\"fa fa-trash\" ></i></a>";

                                    }
                                }
                                else
                                {
                                    strHtml += "<a  disabled href=\"javascript:;\" class=\"btn act_btn bn3 \" title=\"Delete\" ><i class=\"fa fa-trash\"></i></a>";

                                }
                            }
                            else
                            {
                                strHtml += "<a class=\"btn act_btn bn3 \" title=\"Delete\" disabled ><i class=\"fa fa-trash\" ></i></a>";
                            }
                        }


                        if (strCnclSts == "1")
                        {
                            strHtml += " <a  class=\"btn act_btn bn4\"  title=\"VIEW\" onclick='return getdetails(this.href);' " +
                                         " href=\"fms_Receipt_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                        }

                        if (strCnclSts == "0")
                        {
                            strHtml += "<a href=\"javascript:;\"  class=\"btn act_btn bn6\" title=\"PRINT\"  onclick=\"return PrintRcpt('" + Id + "');\" ><i class=\"fa fa-print\"></i></a>";
                        }
                    }

                    strHtml += " </td>";
                }
            }


            strHtml += "</tr>";
        }


        strHtml += "</tbody>";
        if (dt.Rows.Count > 0)
        {
            if (strCnclSts == "0")
            {
                strHtml += " <tfoot> <tr class=\"tr1\">";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" >TOTAL </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\"  style=\"text-align:right;\"> " + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + strHiddenCurrrencyAbrvtn + "</th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "</tr></tfoot>";
            }
            else
            {
                strHtml += " <tfoot> <tr class=\"tr1\">";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" >TOTAL </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\"  style=\"text-align:right;\"> " + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + strHiddenCurrrencyAbrvtn + "</th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
                strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";

                strHtml += "</tr></tfoot>";
            }
        }

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ConfirmRcptDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string strfinancialID)
    {
        FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List objPage = new FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List();
        string[] strRets = new string[5];



        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        strRets[0] = "successConfirm";
        clsBusinessLayer objBusinessLyr = new clsBusinessLayer();

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityRequest.ReceiptId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityRequest.User_Id = Convert.ToInt32(strUserID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
        objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
        try
        {
            DataTable dt = objBussiness.ReadReceptDetailsById(ObjEntityRequest);

            string CurrentDate = objBusinessLyr.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);

            string strdate = "";
            int CntExceed = 0;

            if (dt.Rows.Count > 0)
            {
                if (strfinancialID != "")
                {
                    objEntityCommon.FinancialYrId = Convert.ToInt32(strfinancialID);
                }


                DataTable dtfinaclYear = objBusinessLyr.ReadFinancialYearById(objEntityCommon);
                //  DataTable dtfinaclYear = objBussiness.readFinancialYear(ObjEntityRequest);

                if (dtfinaclYear.Rows.Count > 0)
                {
                    ObjEntityRequest.FinancialYrId = Convert.ToInt32(dtfinaclYear.Rows[0]["FINCYR_ID"].ToString());
                }


                if (dt.Rows[0]["RECPT_REF"].ToString() != "")
                {
                    ObjEntityRequest.RefNum = dt.Rows[0]["RECPT_REF"].ToString();

                }

                if (dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString() != "")
                {
                    ObjEntityRequest.AccntNameId = Convert.ToInt32(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString());
                }


                if (dt.Rows[0]["RECPT_DATE"].ToString() != "")
                {
                    ObjEntityRequest.FromDate = objCommon.textToDateTime(dt.Rows[0]["RECPT_DATE"].ToString());

                }

                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                {
                    ObjEntityRequest.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                }



                if (dt.Rows[0]["RECPT_TOTAL_AMT"].ToString() != "")
                {

                    ObjEntityRequest.TotalAmnt = Convert.ToDecimal(dt.Rows[0]["RECPT_TOTAL_AMT"].ToString());

                }
                if (dt.Rows[0]["RCPT_EXCHANGE_RATE"].ToString() != "")
                {


                    ObjEntityRequest.ExchangeRate = Convert.ToDecimal(dt.Rows[0]["RCPT_EXCHANGE_RATE"].ToString());

                }



                if (dt.Rows[0]["RECPT_REF_NEXTNUM"].ToString() != "")
                {
                    ObjEntityRequest.RefNextNum = Convert.ToInt32(dt.Rows[0]["RECPT_REF_NEXTNUM"].ToString());

                }

                ObjEntityRequest.ConfirmStatus = 1;

                if (dt.Rows[0]["RECPT_UPD_DATE"].ToString() != "")
                {


                    ObjEntityRequest.RcptUpdateDate = objCommon.textToDateTime(dt.Rows[0]["RECPT_UPD_DATE"].ToString());
                }
                else
                {
                    ObjEntityRequest.RcptUpdateDate = objCommon.textToDateTime(dt.Rows[0]["RECPT_INS_DATE"].ToString());

                }
                if (dt.Rows[0]["RECPT_DSCRPTN"].ToString() != "")
                {
                    ObjEntityRequest.Description = dt.Rows[0]["RECPT_DSCRPTN"].ToString();

                }
                List<clsEntity_Receipt_Account> objEntityPerfomList = new List<clsEntity_Receipt_Account>();
                List<clsEntity_Receipt_Account> objEntityPerfomListGrps = new List<clsEntity_Receipt_Account>();


                List<clsEntity_Receipt_Account> ObjEntityLedger_Insert = new List<clsEntity_Receipt_Account>();
                List<clsEntity_Receipt_Account> ObjEntityLedger_Update = new List<clsEntity_Receipt_Account>();
                List<clsEntity_Receipt_Account> ObjEntityLedger_Delete = new List<clsEntity_Receipt_Account>();


                List<clsEntity_Receipt_Account> ObjEntitycostCntr_Insert = new List<clsEntity_Receipt_Account>();
                List<clsEntity_Receipt_Account> ObjEntitycostCntr_Update = new List<clsEntity_Receipt_Account>();
                List<clsEntity_Receipt_Account> ObjEntitycostCntr_Delete = new List<clsEntity_Receipt_Account>();

                List<clsEntity_Receipt_Account> objEntityDeleteSale = new List<clsEntity_Receipt_Account>();

                List<clsEntity_Receipt_Account> objEntityUpdateOB = new List<clsEntity_Receipt_Account>();//EVM-0027

                ObjEntityRequest.Status = 0;
                DataTable dtLDGRdTLS = objBussiness.ReadReceptLedgerDetailsByIdforPrint(ObjEntityRequest);
                DataTable dtcstrDTLS = new DataTable();

                if (dtLDGRdTLS.Rows.Count > 0)
                {
                    //   UserData  data
                    for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
                    {
                        clsEntity_Receipt_Account objSubEntityLedgerINS = new clsEntity_Receipt_Account();

                        clsEntity_Receipt_Account objSubEntityLedgerUPD = new clsEntity_Receipt_Account();

                        clsEntity_Receipt_Account objSubEntitySaleDEL = new clsEntity_Receipt_Account();

                        objSubEntityLedgerUPD.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString());
                        objSubEntityLedgerUPD.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                        if (dtLDGRdTLS.Rows[intCount]["RECPT_LD_AMT"].ToString() != "")
                        {
                            objSubEntityLedgerUPD.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["RECPT_LD_AMT"].ToString());
                        }
                        if (dtLDGRdTLS.Rows[intCount]["RCPT_LD_REMARKS"].ToString() != "")
                        {
                            objSubEntityLedgerUPD.Remarks = dtLDGRdTLS.Rows[intCount]["RCPT_LD_REMARKS"].ToString();
                        }

                        ObjEntityLedger_Update.Add(objSubEntityLedgerUPD);
                        objEntityPerfomListGrps.Add(objSubEntityLedgerUPD);



                        ObjEntityRequest.Status = 1;

                        ObjEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString());
                        dtcstrDTLS = objBussiness.ReadReceptCostcntrDetailsById(ObjEntityRequest);
                        for (int CstrowCnt = 0; CstrowCnt < dtcstrDTLS.Rows.Count; CstrowCnt++)
                        {

                            if (dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString() != "" || dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString() != "")
                            {
                                clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();

                                objSubEntity.Organisation_id = Convert.ToInt32(strOrgIdID);
                                objSubEntity.Corporate_id = Convert.ToInt32(strCorpID);
                                objSubEntity.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                                objSubEntity.ReceiptLedgrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["RECPT_LD_ID"].ToString());
                                objSubEntity.CstCntrAmnt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["RECPT_CST_AMT"].ToString());
                                objSubEntity.ReceiptCstCntrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["RECPT_CST_ID"].ToString());


                                if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                                {
                                    objSubEntity.AccntNameId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString());
                                    objSubEntity.BalanceAmount = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["CREDITNOTE_BAL"].ToString());
                                    objSubEntity.LedgerAmnt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["CREDITNOTE_SETLAMNT"].ToString());
                                }


                                if (dtcstrDTLS.Rows[CstrowCnt]["BALNC_AMT"].ToString() != "")
                                {
                                    objSubEntity.SettlmntAmmnt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["BALNC_AMT"].ToString());
                                }

                                decimal decSalesRemainAmt = 0;
                                if (dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString() == "")
                                {
                                    objSubEntity.Status = 1;
                                    objSubEntity.CostCtrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString());

                                    DataTable dtSalesBalance = objBussiness.ReadSalesBalance(objSubEntity);

                                    if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                                    {
                                        dtSalesBalance = objBussiness.ReadSalesReturnBalance(objSubEntity);
                                    }

                                    decimal decCheckAmnt = objSubEntity.CstCntrAmnt;
                                    if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                                    {
                                        decCheckAmnt = objSubEntity.LedgerAmnt;
                                    }

                                    if (dtSalesBalance.Rows.Count > 0)
                                    {
                                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                    }
                                    if (decSalesRemainAmt != 0)
                                    {
                                        if (decSalesRemainAmt < (objSubEntity.CstCntrAmnt + objSubEntity.LedgerAmnt))
                                        {
                                            strRets[0] = "SalesAmountExceeded";
                                            CntExceed++;
                                        }
                                    }
                                    else if (CntExceed == 0)
                                    {
                                        strRets[0] = "SalesAmtFullySettld";
                                        objSubEntitySaleDEL.ReceiptCstCntrId = objSubEntity.ReceiptCstCntrId;
                                        objEntityDeleteSale.Add(objSubEntitySaleDEL);
                                    }
                                }
                                else
                                {
                                    objSubEntity.Status = 0;
                                    objSubEntity.CostCtrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString());
                                    if (dtcstrDTLS.Rows[CstrowCnt]["COSTGRP_ID_ONE"].ToString() != "")
                                    {
                                        objSubEntity.CostGrp1Id = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["COSTGRP_ID_ONE"].ToString());
                                    }
                                    if (dtcstrDTLS.Rows[CstrowCnt]["COSTGRP_ID_TWO"].ToString() != "")
                                    {
                                        objSubEntity.CostGrp2Id = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["COSTGRP_ID_TWO"].ToString());
                                    }
                                }

                                if (objSubEntity.Status == 0 || (objSubEntity.Status == 1 && decSalesRemainAmt != 0))//insert not fully settled or cst cntr
                                {
                                    ObjEntitycostCntr_Insert.Add(objSubEntity);
                                }
                            }


                            //EVM-0027 Aug 13
                            if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                            {
                                clsEntity_Receipt_Account objSubEntityGrp1 = new clsEntity_Receipt_Account();
                                objSubEntityGrp1.Organisation_id = ObjEntityRequest.Organisation_id;
                                objSubEntityGrp1.Corporate_id = ObjEntityRequest.Corporate_id;
                                objSubEntityGrp1.ReceiptId = ObjEntityRequest.ReceiptId;
                                ObjEntityRequest.VoucherCategory = 1;
                                objSubEntityGrp1.VoucherCategory = 1;
                                objSubEntityLedgerUPD.VoucherCategory = 1;
                                objSubEntityGrp1.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString());

                                objSubEntityGrp1.LedId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                                DataTable dtForOB = objBussiness.ReadOepningBalById(objSubEntityGrp1);
                                if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "" && dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                                {
                                    objSubEntityGrp1.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                                    objSubEntityLedgerUPD.PaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                                    objSubEntityGrp1.BalnceAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBBAL_AMT"].ToString());
                                    objSubEntityLedgerUPD.BalnceAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBBAL_AMT"].ToString());
                                    objSubEntityGrp1.PaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                                    objEntityUpdateOB.Add(objSubEntityGrp1);
                                    ObjEntityLedger_Update.Add(objSubEntityLedgerUPD);
                                }
                            }

                            //END

                        }
                    }
                }

                if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() != "0")
                {
                    strRets[0] = "alrdyCnfrmd";
                }
                else if (dt.Rows[0]["RECPT_CNCL_USR_ID"].ToString() != "")
                {
                    strRets[0] = "AlrdyDeleted";
                }
                else
                {
                    if (objEntityDeleteSale.Count > 0)
                    {
                        objBussiness.DeleteSaleLedgers(objEntityDeleteSale);
                        strRets[0] = "successConfirm";
                    }
                    if (strRets[0] != "SalesAmountExceeded" && strRets[0] != "SalesAmtFullySettld")
                    {
                        objBussiness.ConfirmReceiptDtls(ObjEntityRequest, objEntityPerfomListGrps, objEntityPerfomList, ObjEntityLedger_Insert, ObjEntityLedger_Update, ObjEntitycostCntr_Insert, ObjEntitycostCntr_Update, objEntityUpdateOB);
                    }
                }
            }

            //For table
            clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            intUserId = Convert.ToInt32(strUserID);
            objEntity.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = intCorpId;
            objEntity.Corporate_id = intCorpId;


            intOrgId = Convert.ToInt32(strOrgIdID);
            objEntity.Organisation_id = intOrgId;
            objEntityCommon.Organisation_Id = intOrgId;

            objEntityCommon.FinancialYrId = Convert.ToInt32(strfinancialID);

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleUpd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                    }
                }
            }
            if (strAccntBook != "--SELECT--" && strAccntBook != "")
            {
                objEntity.AccntNameId = Convert.ToInt32(strAccntBook);
            }
            if (strFromDate.Trim() != "")
            {
                objEntity.FromDate = objCommon.textToDateTime(strFromDate.Trim());
            }
            if (strToDate.Trim() != "")
            {
                objEntity.ToDate = objCommon.textToDateTime(strToDate.Trim());
            }
            objEntity.cncl_sts = Convert.ToInt32(strCnclSts);


            DataTable dtfinaclYear1 = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            if (dtfinaclYear1.Rows.Count > 0)
            {
                objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear1.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear1.Rows[0]["FINCYR_END_DT"].ToString());
            }
            objEntity.RcptSts = Convert.ToInt32(strStatus);
            DataTable dt1 = objBussiness.ReadReceiptList(objEntity);
            DataTable dtacntClsDate = objBussiness.ReadAcntClsingDate(objEntity);
            strRets[1] = objPage.ConvertDataTableToHTML(dt1, intUpdate, intEnableCancel, dtacntClsDate, intConfirm, intReopen);


            string[] strHtmlRet = new string[2];
            strHtmlRet = LoadPendingOrders(intUserId, intOrgId, intCorpId);
            strRets[3] = strHtmlRet[0];
            strRets[4] = strHtmlRet[1];
        }

        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["CONFIRM_STS"] = strRets;
        return strRets;

    }

    public void LeadgerLoad()
    {
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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
        ddlLedger.Items.Insert(0, "--SELECT--");
    }

    public void AccountLedgerLoad()
    {
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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
            ddlAccontLed.DataSource = dtSubConrt;
            ddlAccontLed.DataTextField = "LDGR_NAME";
            ddlAccontLed.DataValueField = "LDGR_ID";
            ddlAccontLed.DataBind();

        }
        ddlAccontLed.Items.Insert(0, "--SELECT--");
        //DataTable dtDefaultcurc = objBussiness.ReadDefualtCurrency(ObjEntityRequest);
        //string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        ////ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        //if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
        //    ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgIdID, string strCorpID, string strfinancialID)
    {

        FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List objPage = new FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List();
        string[] strRets = new string[2];
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.ReceiptId = Convert.ToInt32(strId);
        objEntity.User_Id = Convert.ToInt32(usrId);
        objEntity.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity.Corporate_id = Convert.ToInt32(strCorpID);
        if (reasonmust == "1")
        {
            objEntity.CancelReason = cnclRsn;
        }

        else
        {
            objEntity.CancelReason = objCommon.CancelReason();
        }

        try
        {
            //0039
            DataTable dt = objBussiness.ReadReceptDetailsById(objEntity);
            if (dt.Rows[0]["RECPT_CNCL_USR_ID"].ToString() != "" && dt.Rows[0]["RECPT_CNCL_REASN"].ToString() != "")
            {
                strRets[0] = "AlreadyCancl";
            }


            //end


            objBussiness.CancelReceiptById(objEntity);

            //For table
            objEntity = new clsEntity_Receipt_Account();
            objEntity.AccntNameId = 0;
            objEntity.LedgerId = 0;
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            intUserId = Convert.ToInt32(usrId);
            objEntity.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = intCorpId;
            objEntity.Corporate_id = intCorpId;


            intOrgId = Convert.ToInt32(strOrgIdID);
            objEntity.Organisation_id = intOrgId;
            objEntityCommon.Organisation_Id = intOrgId;

            objEntityCommon.FinancialYrId = Convert.ToInt32(strfinancialID);

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleUpd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                    }
                }
            }
            if (strAccntBook != "--SELECT--")
            {
                objEntity.AccntNameId = Convert.ToInt32(strAccntBook);
            }
            if (strFromDate.Trim() != "")
            {
                objEntity.FromDate = objCommon.textToDateTime(strFromDate.Trim());
            }
            if (strToDate.Trim() != "")
            {
                objEntity.ToDate = objCommon.textToDateTime(strToDate.Trim());
            }
            objEntity.cncl_sts = Convert.ToInt32(strCnclSts);


            DataTable dtfinaclYear1 = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            if (dtfinaclYear1.Rows.Count > 0)
            {
                objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear1.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear1.Rows[0]["FINCYR_END_DT"].ToString());
            }
            objEntity.RcptSts = Convert.ToInt32(strStatus);
            DataTable dt1 = objBussiness.ReadReceiptList(objEntity);
            DataTable dtacntClsDate = objBussiness.ReadAcntClsingDate(objEntity);
            strRets[1] = objPage.ConvertDataTableToHTML(dt1, intUpdate, intEnableCancel, dtacntClsDate, intConfirm, intReopen);

        }
        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["CANCEL_STS"] = strRets;
        return strRets;

    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ReopenReceiptDetails(string strmemotId, string usrId, string strOrgIdID, string strCorpID, string reopensts, string AcntClssts, string AuditClssts, string strfinancialID)
    {

        FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List objPage = new FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List();
        string[] strRets = new string[5];

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successReopen";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntity.ReceiptId = Convert.ToInt32(strId);
        objEntity.User_Id = Convert.ToInt32(usrId);
        objEntity.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity.Corporate_id = Convert.ToInt32(strCorpID);
        objEntity.Status = 1;
        List<clsEntity_Receipt_Account> objEntityPerfomList = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityPerfomListGrps = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityUpdateOB = new List<clsEntity_Receipt_Account>();

        DataTable dt = objBussiness.ReadReceptDetailsById(objEntity);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString() != "")
            {
                objEntity.AccntNameId = Convert.ToInt32(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString());
            }
        }
        DataTable dtLDGRdTLS = objBussiness.ReadReceptLedgerDetailsById(objEntity);
        if (dtLDGRdTLS.Rows.Count > 0)
        {
            for (int rowCnt = 0; rowCnt < dtLDGRdTLS.Rows.Count; rowCnt++)
            {
                //if (dtLDGRdTLS.Rows[rowCnt]["RECPT_CST_AMT"].ToString() != "0" || dtLDGRdTLS.Rows[rowCnt]["LDGR_CR_ID"].ToString() != "")
                //{
                clsEntity_Receipt_Account objSubEntityGrp = new clsEntity_Receipt_Account();
                objSubEntityGrp.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());

                objSubEntityGrp.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                objSubEntityGrp.LedId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                objSubEntityGrp.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_AMT"].ToString());
                objEntityPerfomList.Add(objSubEntityGrp);
                if (dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString() != "")
                {
                    objEntity.Status = 1;
                    objEntity.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());
                    // objEntity.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                    DataTable dtcstrDTLS = objBussiness.ReadReceptCostcntrDetailsById(objEntity);
                    for (int CstrowCnt = 0; CstrowCnt < dtcstrDTLS.Rows.Count; CstrowCnt++)
                    {
                        if (dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString() != "" || dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString() != "")
                        {
                            clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();
                            objSubEntity.LedgerId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["RECPT_LD_ID"].ToString());


                            if (dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString() == "" || dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString() != "")
                            {
                                objSubEntity.Status = 1;
                                objSubEntity.CostCtrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString());

                            }
                            else
                            {
                                objSubEntity.Status = 0;
                                objSubEntity.CostCtrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString());
                            }


                            objSubEntity.ReceiptLedgrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["RECPT_LD_ID"].ToString());
                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["RECPT_CST_AMT"].ToString());
                            objSubEntity.ReceiptCstCntrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["RECPT_CST_ID"].ToString());

                            if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                            {
                                objSubEntity.AccntNameId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString());
                                objSubEntity.BalanceAmount = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["CREDITNOTE_BAL"].ToString());
                                objSubEntity.LedgerCreditAmt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["CREDITNOTE_SETLAMNT"].ToString());
                            }
                            objEntityPerfomListGrps.Add(objSubEntity);


                        }
                    }
                }
                //   }
                //EVM-0027 Aug 13
                if (dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString() != "")
                {
                    clsEntity_Receipt_Account objSubEntityGrp1 = new clsEntity_Receipt_Account();
                    objSubEntityGrp1.Organisation_id = objEntity.Organisation_id;
                    objSubEntityGrp1.Corporate_id = objEntity.Corporate_id;
                    objSubEntityGrp1.ReceiptId = objEntity.ReceiptId;
                    objSubEntityGrp1.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());
                    objSubEntityGrp1.VoucherCategory = 1;
                    objSubEntityGrp1.LedId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                    DataTable dtForOB = objBussiness.ReadOepningBalById(objSubEntityGrp1);
                    if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                    {
                        decimal decOpeningBal = Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        decimal decPaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                        objSubEntityGrp1.BalnceAmt = decOpeningBal + decPaidAmt;
                        objEntityUpdateOB.Add(objSubEntityGrp1);
                    }

                }

                //END
            }
        }
        string strdate = "";
        try
        {
            DataTable dtCHK = objBussiness.CheckReceiptCnclSts(objEntity);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["RECPT_DATE"].ToString() != "")
                {
                    strdate = dt.Rows[0]["RECPT_DATE"].ToString();
                    int AcntCloseSts = AccountCloseCheck(strdate, strOrgIdID, strCorpID);
                    int AuditCloseSts = AuditCloseCheck(strdate, strOrgIdID, strCorpID);

                    if (dt.Rows[0]["RECPT_REOPEN_USRID"].ToString() != "" && dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "0")
                    {
                        strRets[0] = "alrdyreopened";
                    }

                    if (reopensts == "Active" && strRets[0] != "alrdyreopened")
                    {
                        if (AuditCloseSts == 1 && AuditClssts == "1")
                        {
                            if (dtCHK.Rows[0][0].ToString() == "")
                            {
                                objBussiness.ReOpenById(objEntity, objEntityPerfomList, objEntityPerfomListGrps, objEntityUpdateOB);
                            }
                            else
                            {
                                strRets[0] = "alrdydeleted";
                            }
                        }
                        else if (AuditCloseSts == 1 && AuditClssts != "1")
                        {
                            strRets[0] = "auditclosed";
                        }
                        else if (AuditCloseSts == 1 && AcntClssts == (clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (dtCHK.Rows[0][0].ToString() == "")
                            {
                                objBussiness.ReOpenById(objEntity, objEntityPerfomList, objEntityPerfomListGrps, objEntityUpdateOB);
                            }
                            else
                            {
                                strRets[0] = "alrdydeleted";
                            }
                        }
                        else if (AuditCloseSts == 1 && AcntClssts != (clsCommonLibrary.StatusAll.Active).ToString())
                        {

                            strRets[0] = "acntclosed";

                        }
                        else
                        {
                            if (dtCHK.Rows[0][0].ToString() == "")
                            {
                                objBussiness.ReOpenById(objEntity, objEntityPerfomList, objEntityPerfomListGrps, objEntityUpdateOB);
                            }
                            else
                            {
                                strRets[0] = "alrdydeleted";
                            }

                        }
                    }
                }

            }

            //For table
            objEntity = new clsEntity_Receipt_Account();
            objEntity.AccntNameId = 0;
            objEntity.LedgerId = 0;

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            intUserId = Convert.ToInt32(usrId);
            objEntity.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = intCorpId;
            objEntity.Corporate_id = intCorpId;


            intOrgId = Convert.ToInt32(strOrgIdID);
            objEntity.Organisation_id = intOrgId;
            objEntityCommon.Organisation_Id = intOrgId;

            objEntityCommon.FinancialYrId = Convert.ToInt32(strfinancialID);

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleConf.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenRoleUpd.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                    }
                }
            }
            if (strAccntBook != "--SELECT--")
            {
                objEntity.AccntNameId = Convert.ToInt32(strAccntBook);
            }
            if (strFromDate.Trim() != "")
            {
                objEntity.FromDate = objCommon.textToDateTime(strFromDate.Trim());
            }
            if (strToDate.Trim() != "")
            {
                objEntity.ToDate = objCommon.textToDateTime(strToDate.Trim());
            }
            objEntity.cncl_sts = Convert.ToInt32(strCnclSts);


            DataTable dtfinaclYear1 = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            if (dtfinaclYear1.Rows.Count > 0)
            {
                objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear1.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear1.Rows[0]["FINCYR_END_DT"].ToString());
            }
            objEntity.RcptSts = Convert.ToInt32(strStatus);
            DataTable dt1 = objBussiness.ReadReceiptList(objEntity);
            DataTable dtacntClsDate = objBussiness.ReadAcntClsingDate(objEntity);
            strRets[1] = objPage.ConvertDataTableToHTML(dt1, intUpdate, intEnableCancel, dtacntClsDate, intConfirm, intReopen);


            string[] strHtmlRet = new string[2];
            strHtmlRet = LoadPendingOrders(intUserId, intOrgId, intCorpId);
            strRets[3] = strHtmlRet[0];
            strRets[4] = strHtmlRet[1];
        }
        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        return strRets;

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


    [WebMethod]
    public static string printReceiptDetails(string strId, string strUserID, string strOrgIdID, string strCorpID, string crncyAbrvt, string crncyId, string UsrName)
    {
        string strRandomMixedId = strId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strrId = strRandomMixedId.Substring(2, intLenghtofId);

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsEntity_Receipt_Account objEntityRcpt = new clsEntity_Receipt_Account();
        string PreparedBy = "";
        string CheckedBy = "";
        if (strCorpID != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
            objEntityRcpt.Corporate_id = Convert.ToInt32(strCorpID);
        }
        if (strOrgIdID != null)
        {
            objEntityRcpt.Organisation_id = Convert.ToInt32(strOrgIdID);
        }
        if (strUserID != null)
        {
            objEntityRcpt.User_Id = Convert.ToInt32(strUserID);
        }

        objEntityRcpt.ReceiptId = Convert.ToInt32(strrId);

        if (UsrName != "")
        {
            PreparedBy = UsrName;
        }

        DataTable dt = objBussiness.ReadReceptDetailsById(objEntityRcpt);
        DataTable dtSales = new DataTable();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["RECPT_CONFRM_USRID"].ToString() != "")
            {
                objEntityRcpt.User_Id = Convert.ToInt32(dt.Rows[0]["RECPT_CONFRM_USRID"].ToString());
                DataTable dtCheckedUserName = objBussiness.ReadUserName(objEntityRcpt);
                if (dtCheckedUserName.Rows.Count > 0)
                {
                    if (dtCheckedUserName.Rows[0]["USR_NAME"].ToString() != "")
                    {
                        CheckedBy = dtCheckedUserName.Rows[0]["USR_NAME"].ToString();
                    }
                }
            }

            if (dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString() != "")
            {
                objEntityRcpt.LedgerId = Convert.ToInt32(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString());
            }

            dtSales = objBussiness.AccntBalancebyId(objEntityRcpt);
        }

        FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List objPage = new FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List();

        DataTable dtProduct = objBussiness.ReadReceptLedgerDetailsByIdforPrint(objEntityRcpt);
        DataTable dtCorp = objBussiness.ReadCorpDtls(objEntityRcpt);
        DataTable invoiceDtl = new DataTable();
        if (dtProduct.Rows.Count == 1)
        {
            objEntityRcpt.LedgerId = Convert.ToInt32(dtProduct.Rows[0]["RECPT_LD_ID"].ToString());
            objEntityRcpt.Status = 3;
            invoiceDtl = objBussiness.ReadReceptCostcntrDetailsById(objEntityRcpt);
        }

        int Version_flg = 0;
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.RECEIPT);
        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

        string strReturn = "";
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                Version_flg = 1;
                strReturn = objBussiness.PdfPrintVersion1(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                Version_flg = 2;
                //strReturn = objPage.PdfPrintVersion2(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg, dtSales, invoiceDtl);
                strReturn = objBussiness.PdfPrintVersion2(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg, dtSales, invoiceDtl);

            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                Version_flg = 3;
                //  strReturn = objPage.PdfPrintVersion2(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg, dtSales, invoiceDtl);
                strReturn = objBussiness.PdfPrintVersion2(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg, dtSales, invoiceDtl);
            }
        }
        return strReturn;
    }

    //public string PdfPrintVersion2(string strrId, DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntity_Receipt_Account ObjEntitySales, string PreparedBy, string CheckedBy, string crncyAbrvt, string crncyId, int Version_flg, DataTable dtSales, DataTable invoiceDtl)
    //{
    //    int precision = 0;
    //    if (dt.Rows[0]["DCML_CNT"].ToString() != "")
    //    {
    //        precision = Convert.ToInt32(dt.Rows[0]["DCML_CNT"].ToString());
    //    }
    //    string format = String.Format("{{0:N{0}}}", precision);
    //    string valuestring = String.Format(format, 0);

    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.RECEIPT_INVOICE);

    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }
    //    if (crncyId != "")
    //    {
    //        objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Receipt_Invoice" + strrId + "_" + strNextNumber + ".pdf";

    //    Document document = new Document(PageSize.LETTER, 50f, 40f, 120f, 30f);
    //    if (Version_flg == 2)
    //    {
    //        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 30f);
    //    }
    //    string strRet = "";
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            if (Version_flg == 2)
    //            {
    //                writer.PageEvent = new PDFHeader();
    //                document.Open();
    //            }
    //            else
    //            {
    //                document.Open();
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //            }

    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 21, 79 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            footrtable.AddCell(new PdfPCell(new Phrase("Date ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["RECPT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("Receipt # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["RECPT_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //            document.Add(footrtable);

    //            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "")
    //            {
    //                if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString().Trim() != "3")
    //                {
    //                    PdfPTable foottrtables = new PdfPTable(2);
    //                    float[] footrssBodys = { 30, 70 };
    //                    foottrtables.SetWidths(footrssBodys);
    //                    foottrtables.WidthPercentage = 70;
    //                    foottrtables.HorizontalAlignment = Element.ALIGN_LEFT;
    //                    foottrtables.AddCell(new PdfPCell(new Phrase("Receipt Details", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 2 });
    //                    foottrtables.AddCell(new PdfPCell(new Phrase("Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
    //                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "0")
    //                    {
    //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Cheque", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                        if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                        }
    //                        if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }
    //                        if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }
    //                        if (dt.Rows[0]["RCPT_CHEQUE_NO"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Cheque Book Number", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_CHEQUE_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                        }
    //                    }
    //                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "1")
    //                    {
    //                        foottrtables.AddCell(new PdfPCell(new Phrase(": DD", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                        if (dt.Rows[0]["RCPT_DD_NO"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD No.", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_DD_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                        }
    //                        if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }
    //                        if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }

    //                        if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("DD Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                        }

    //                    }
    //                    if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "2")
    //                    {
    //                        foottrtables.AddCell(new PdfPCell(new Phrase(": Bank Transfer", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                        if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Transfer Mode", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "0")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": IMPS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "1")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": NEFT", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "2")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": RTGS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                            if (dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString() == "3")
    //                                foottrtables.AddCell(new PdfPCell(new Phrase(": OTHERS", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }
    //                        if (dt.Rows[0]["RCPT_BANK_NAME"].ToString() != "")
    //                        {
    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_BANK_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }
    //                        if (dt.Rows[0]["RCPT_IBAN_NO"].ToString() != "")
    //                        {

    //                            foottrtables.AddCell(new PdfPCell(new Phrase("IBAN", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_IBAN_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthLeft = 0, BorderWidthTop = 0, });
    //                        }

    //                        if (dt.Rows[0]["RCPT_PAMNT_DATE"].ToString() != "")
    //                        {

    //                            foottrtables.AddCell(new PdfPCell(new Phrase("Bank Transfer Date", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                            foottrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["RCPT_PAMNT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 3, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderWidthLeft = 0, BorderWidthTop = 0 });

    //                        }

    //                    }
    //                    document.Add(foottrtables);
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                }
    //            }
    //            if (dtSales.Rows.Count > 0)
    //            {
    //                string AccGrp = "";

    //                if (dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
    //                    AccGrp = dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
    //                else if (dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
    //                    AccGrp = dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
    //                if (AccGrp != "")
    //                {

    //                    PdfPTable footrtables = new PdfPTable(2);
    //                    float[] footrsBodys = { 21, 79 };
    //                    footrtables.SetWidths(footrsBodys);
    //                    footrtables.WidthPercentage = 100;
    //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                    if (AccGrp == "13")
    //                    {
    //                        footrtables.AddCell(new PdfPCell(new Phrase("A/c BOOK ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase("ACC # ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(":         " + dt.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                    }
    //                    else
    //                    {
    //                        footrtables.AddCell(new PdfPCell(new Phrase("CASH BOOK", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
    //                        footrtables.AddCell(new PdfPCell(new Phrase(":       " + dt.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });

    //                    }
    //                    footrtables.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, Colspan = 2 });
    //                    document.Add(footrtables);
    //                }
    //            }
    //            if (dtProduct.Rows.Count > 0)
    //            {
    //                clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                if (dtProduct.Rows.Count == 1)
    //                {
    //                    PdfPTable footrtables = new PdfPTable(5);
    //                    float[] footrsBodys = { 19, 27, 5, 15, 30 };
    //                    footrtables.SetWidths(footrsBodys);
    //                    footrtables.WidthPercentage = 100;
    //                    decimal TOTAL = 0;
    //                    TOTAL = Convert.ToDecimal(dtProduct.Rows[0]["RECPT_LD_AMT"].ToString());
    //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
    //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 5 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Customer Name   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
    //                    decimal decAmnt = 0;
    //                    if (dtProduct.Rows[0]["RECPT_LD_AMT"].ToString() != "")
    //                    {
    //                        decAmnt = Convert.ToDecimal(dtProduct.Rows[0]["RECPT_LD_AMT"].ToString());
    //                    }
    //                    string valuestringAmnt = String.Format(format, decAmnt);
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Amount   :", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 1, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthBottom = 0, BorderWidthRight = 0, BorderWidthLeft = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(valuestringAmnt + "  " + crncyAbrvt, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 1, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.BLACK, BorderColorBottom = iTextSharp.text.BaseColor.WHITE, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Amount in Words:", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 1, BorderColorLeft = iTextSharp.text.BaseColor.BLACK, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.WHITE, BorderWidthTop = 0, BorderWidthRight = 0 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingBottom = 4, Colspan = 4, BorderColorLeft = iTextSharp.text.BaseColor.WHITE, BorderColorTop = iTextSharp.text.BaseColor.WHITE, BorderColorBottom = iTextSharp.text.BaseColor.BLACK, BorderColorRight = iTextSharp.text.BaseColor.BLACK, BorderWidthLeft = 0, BorderWidthTop = 0 });
    //                    document.Add(footrtables);

    //                    int flag = 0;

    //                    if (invoiceDtl.Rows.Count > 0)
    //                    {
    //                        var FontGrey = new BaseColor(134, 152, 160);
    //                        var FontBordrGrey = new BaseColor(236, 236, 236);
    //                        var FontBordrBlack = new BaseColor(138, 138, 138);
    //                        PdfPTable table2 = new PdfPTable(3);
    //                        float[] tableBody2 = { 40, 30, 30 };
    //                        table2.SetWidths(tableBody2);
    //                        table2.WidthPercentage = 100;
    //                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE DETAILS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, Colspan = 3 });
    //                        table2.AddCell(new PdfPCell(new Phrase("INVOICE #", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                        table2.AddCell(new PdfPCell(new Phrase("DESCRIPTION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                        table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                        for (int RowCount = 0; RowCount < invoiceDtl.Rows.Count; RowCount++)
    //                        {
    //                            if (invoiceDtl.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
    //                            {
    //                                if (invoiceDtl.Rows[RowCount]["SALES_REF"].ToString() != "")
    //                                {
    //                                    if (invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString() != "")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        decimal decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString());
    //                                        string valuestringAmnt1 = String.Format(format, decAmnt1);
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    }
    //                                    if (invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString() != "")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        decimal decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString());
    //                                        string valuestringAmnt1 = String.Format(format, decAmnt1);
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    }
    //                                }
    //                                else if (invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase("Opening balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    decimal decAmnt1 = Convert.ToDecimal(invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString());
    //                                    string valuestringAmnt1 = String.Format(format, decAmnt1);
    //                                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
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
    //                else
    //                {
    //                    var FontGrey = new BaseColor(134, 152, 160);
    //                    var FontBordrGrey = new BaseColor(236, 236, 236);
    //                    var FontBordrBlack = new BaseColor(138, 138, 138);
    //                    var FontGreySmall = new BaseColor(236, 236, 236);
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 5, 15, 12, 5, 28, 15, 20 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack, Colspan = 2 });
    //                    table2.AddCell(new PdfPCell(new Phrase("AMOUNT (" + crncyAbrvt + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrBlack });
    //                    string strAmountComma = "";
    //                    decimal TOTAL = 0;
    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
    //                        {
    //                            TOTAL += Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
    //                        }
    //                        decimal decAmnt1 = 0;
    //                        if (dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString() != "")
    //                        {
    //                            decAmnt1 = Convert.ToDecimal(dtProduct.Rows[intRowBodyCount]["RECPT_LD_AMT"].ToString());
    //                        }
    //                        string valuestringAmnt1 = String.Format(format, decAmnt1);

    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 4 });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["RCPT_LD_REMARKS"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt1, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                        clsBusinessLayer_Receipt_Account objBussinessPayment = new clsBusinessLayer_Receipt_Account();
    //                        ObjEntitySales.Status = 3;
    //                        ObjEntitySales.LedgerId = Convert.ToInt32(dtProduct.Rows[intRowBodyCount]["RECPT_LD_ID"].ToString());
    //                        invoiceDtl = objBussinessPayment.ReadReceptCostcntrDetailsById(ObjEntitySales);
    //                        if (invoiceDtl.Rows.Count > 0)
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = invoiceDtl.Rows.Count + 1 });
    //                            table2.AddCell(new PdfPCell(new Phrase("INV#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
    //                            table2.AddCell(new PdfPCell(new Phrase("INV. DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
    //                            table2.AddCell(new PdfPCell(new Phrase("SETTLEMENT REMARKS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack, Colspan = 2 });
    //                            table2.AddCell(new PdfPCell(new Phrase("INV.AMT(" + crncyAbrvt + ")", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGreySmall, BorderColor = FontBordrBlack });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Rowspan = invoiceDtl.Rows.Count + 1 });
    //                            for (int RowCount = 0; RowCount < invoiceDtl.Rows.Count; RowCount++)
    //                            {
    //                                if (invoiceDtl.Rows[RowCount]["COSTCNTR_ID"].ToString() == "")
    //                                {
    //                                    if (invoiceDtl.Rows[RowCount]["SALES_REF"].ToString() != "")
    //                                    {
    //                                        if (invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString() != "")
    //                                        {
    //                                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(invoiceDtl.Rows[RowCount]["RECPT_CST_AMT"].ToString(), objEntityCommon);
    //                                            table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        }
    //                                        if (invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString() != "")
    //                                        {
    //                                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                            table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DESC"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                            strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(invoiceDtl.Rows[RowCount]["CREDITNOTE_SETLAMNT"].ToString(), objEntityCommon);
    //                                            table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        }
    //                                    }
    //                                    else if (invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != "" && invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString() != valuestring)
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        table2.AddCell(new PdfPCell(new Phrase(invoiceDtl.Rows[RowCount]["SALES_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                        strAmountComma = objBusinessLayer.AddCommasForNumberSeperation(invoiceDtl.Rows[RowCount]["OBPAID_AMT"].ToString(), objEntityCommon);
    //                                        table2.AddCell(new PdfPCell(new Phrase("Opening balance", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 2 });
    //                                        table2.AddCell(new PdfPCell(new Phrase(strAmountComma, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(TOTAL));
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 6 });
    //                    string valuestringAmnt11 = String.Format(format, TOTAL);
    //                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt11, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack });
    //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrBlack, Colspan = 7 });
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    document.Add(table2);
    //                }

    //            }
    //            if (Version_flg == 2)
    //            {
    //                if (dt.Rows[0]["RECPT_DSCRPTN"].ToString().Trim() != "")
    //                {
    //                    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    document.Add(new Paragraph(new Chunk(dt.Rows[0]["RECPT_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))));
    //                }
    //            }
    //            float pos1 = writer.GetVerticalPosition(false);
    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //            if (dt.Rows[0]["INSERT_USR"].ToString() != "")
    //            {
    //                PreparedBy = dt.Rows[0]["INSERT_USR"].ToString();
    //            }
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")
    //            {

    //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            else
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase("    ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            }
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            if (pos1 > 90)
    //            {
    //                table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
    //            }
    //            else
    //            {
    //                document.NewPage();
    //                table3.WriteSelectedRows(0, -1, 0, 90, writer.DirectContent);
    //            }
    //            document.Close();
    //        }
    //        strRet = strImagePath + strImageName;
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }
    //    return strRet;
    //}

    //public class PDFHeader : PdfPageEventHelper
    //{
    //    PdfContentByte cb;
    //    PdfTemplate footerTemplate;
    //    BaseFont bf = null;
    //    DateTime PrintTime = DateTime.Now;
    //    public override void OnOpenDocument(PdfWriter writer, Document document)
    //    {
    //        try
    //        {
    //            PrintTime = DateTime.Now;
    //            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
    //            cb = writer.DirectContent;
    //            footerTemplate = cb.CreateTemplate(200, 200);
    //        }
    //        catch (DocumentException de)
    //        {
    //            //handle exception here
    //        }
    //        catch (System.IO.IOException ioe)
    //        {
    //            //handle exception here
    //        }
    //    }
    //    public override void OnStartPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    //    {
    //        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
    //        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
    //        objEntityLayerStock.Corp_Id = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
    //        objEntityLayerStock.Org_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
    //        DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);
    //        clsCommonLibrary objCommon = new clsCommonLibrary();
    //        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "";
    //        string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //        if (dtCorp.Rows.Count > 0)
    //        {
    //            if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //            {
    //                string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                strImageLogo = imaeposition + icon;
    //            }
    //            strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
    //            strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
    //            strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
    //            strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
    //        }
    //        string strAddress = "";
    //        strAddress = strCompanyAddr1;
    //        if (strCompanyAddr2 != "")
    //        {
    //            strAddress += ", " + strCompanyAddr2;
    //        }
    //        if (strCompanyAddr3 != "")
    //        {
    //            strAddress += ", " + strCompanyAddr3;
    //        }
    //        //Head Table
    //        //int globhead = 1;
    //        PdfPTable headtable = new PdfPTable(2);

    //            headtable.AddCell(new PdfPCell(new Phrase("RECEIPT", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });

    //        if (strImageLogo != "")
    //        {
    //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //            image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //            image.ScaleToFit(60f, 40f);
    //            headtable.AddCell(new PdfPCell(image) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
    //        }
    //        else
    //        {
    //            headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Rowspan = 4, Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        }
    //        headtable.AddCell(new PdfPCell(new Phrase(strCompanyName, new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        headtable.AddCell(new PdfPCell(new Phrase(strAddress, new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
    //        headtable.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });
    //        headtable.AddCell(new PdfPCell(new Phrase(" ", new Font(FontFactory.GetFont("Calibri", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 2 });

    //        float[] headersHeading = { 80, 20 };
    //        headtable.SetWidths(headersHeading);
    //        headtable.WidthPercentage = 100;
    //        document.Add(headtable);

    //        PdfPTable tableLine = new PdfPTable(1);
    //        float[] tableLineBody = { 100 };
    //        tableLine.SetWidths(tableLineBody);
    //        tableLine.WidthPercentage = 100;
    //        tableLine.TotalWidth = 650F;
    //        tableLine.AddCell(new PdfPCell(new Phrase("_____________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //        float pos9 = writer.GetVerticalPosition(false);


    //    }

    //    public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
    //    {
    //        // base.OnEndPage(writer, document);
    //        string strUsername = HttpContext.Current.Session["USERFULLNAME"].ToString();
    //        PdfPTable table3 = new PdfPTable(1);
    //        float[] tableBody3 = { 100 };
    //        table3.SetWidths(tableBody3);
    //        table3.WidthPercentage = 100;
    //        table3.TotalWidth = 650F;
    //        table3.AddCell(new PdfPCell(new Phrase("_________________________________________________________________________________________________________________________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.GRAY))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //        PdfPTable headImg = new PdfPTable(3);
    //        string strImageLogo = "/Images/Design_Images/images/Compztlogo.png";
    //        headImg.AddCell(new PdfPCell(new Phrase("______________________________________________________________________________________________________", new Font(FontFactory.GetFont("Tahoma,Arial", 9, Font.NORMAL, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
    //        if (strImageLogo != "")
    //        {
    //            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //            image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //            image.ScaleToFit(60f, 40f);
    //            headImg.AddCell(new PdfPCell(image) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_TOP });
    //        }

    //        headImg.AddCell(new PdfPCell(new Paragraph("Report generated in Compzit by:" + strUsername + "\nReport generated on:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER });
    //        headImg.AddCell(new PdfPCell(new Paragraph(" ", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Colspan = 3 });
    //        float[] headersHeading = { 20, 60, 20 };
    //        headImg.SetWidths(headersHeading);
    //        headImg.WidthPercentage = 100;
    //        headImg.TotalWidth = document.PageSize.Width - 80f;
    //        headImg.WriteSelectedRows(0, -1, 50, document.PageSize.GetBottom(45), writer.DirectContent);

    //        String text = "Page " + writer.PageNumber + " of ";
    //        //Add paging to footer
    //        {
    //            cb.BeginText();
    //            cb.SetFontAndSize(bf, 8);
    //            cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(15));
    //            cb.ShowText(text);
    //            cb.EndText();
    //            float len = bf.GetWidthPoint(text, 8);
    //            cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(15));
    //        }
    //    }
    //    public override void OnCloseDocument(PdfWriter writer, Document document)
    //    {
    //        base.OnCloseDocument(writer, document);
    //        footerTemplate.BeginText();
    //        footerTemplate.SetFontAndSize(bf, 8);
    //        footerTemplate.SetTextMatrix(0, 0);
    //        footerTemplate.ShowText((writer.PageNumber).ToString());
    //        footerTemplate.EndText();
    //    }
    //}


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityCommon.CorporateID = intCorpId;
            objEntity.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {

            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Organisation_id = intOrgId;
            objEntityCommon.Organisation_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["FINCYRID"] != null)
        {
            objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intReopen = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //HiddenRoleConf.Value = "1";
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    //HiddenRoleUpd.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenReopenSts.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                {

                    HiddenFieldAuditCloseReopenSts.Value = "1";
                }


            }
        }
        if (ddlLedger.SelectedItem.Value != "--SELECT--")
        {
            objEntity.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
        }
        if (ddlAccontLed.SelectedItem.Value != "--SELECT--")
        {
            objEntity.AccntNameId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
        }
        if (txtFromdate.Value.Trim() != "")
        {
            objEntity.FromDate = objCommon.textToDateTime(txtFromdate.Value.Trim());
        }
        if (txtTodate.Value.Trim() != "")
        {
            objEntity.ToDate = objCommon.textToDateTime(txtTodate.Value.Trim());
        }
        if (cbxCnclStatus.Checked == true)
        {
            objEntity.cncl_sts = 1;
            strCnclSts = "1";
        }
        else
        {
            objEntity.cncl_sts = 0;
            strCnclSts = "0";
        }
        strFromDate = txtFromdate.Value;
        strToDate = txtTodate.Value;
        strStatus = ddlRcptSts.SelectedItem.Value;
        strAccntBook = ddlAccontLed.SelectedItem.Value;

        strHiddenReopenSts = HiddenReopenSts.Value;
        strHiddenProvisionSts = HiddenProvisionSts.Value;
        strHiddenFieldAuditCloseReopenSts = HiddenFieldAuditCloseReopenSts.Value;
        strhiddenDecimalCount = hiddenDecimalCount.Value;
        strHiddenCurrrencyAbrvtn = HiddenCurrrencyAbrvtn.Value;
        strhiddenCurrencyModeId = hiddenCurrencyModeId.Value;
        strhiddenDfltCurrencyMstrId = hiddenDfltCurrencyMstrId.Value;
        DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

        if (dtfinaclYear.Rows.Count > 0)
        {
            objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
            objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
        }
        objEntity.RcptSts = Convert.ToInt32(ddlRcptSts.SelectedItem.Value);

        DataTable dt = objBussiness.ReadReceiptList(objEntity);
        DataTable dtacntClsDate = objBussiness.ReadAcntClsingDate(objEntity);

        divList.InnerHtml = ConvertDataTableToHTML(dt, intUpdate, intEnableCancel, dtacntClsDate, intConfirm, intReopen);
    }
    [WebMethod]
    public static string PrintCSV(string orgID, string corptID, string FinancialStartDate, string FinancialEndDate, string CurrencyID, string RcptStatus, string from, string toDt, string CnclSts, string LedgrIdID, string Status, string AccountBook)
    {

        string strReturn = "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessLayer_Receipt_Account objBussinessRcpt = new clsBusinessLayer_Receipt_Account();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
        FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List OBJ = new FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account_List();
        if (CurrencyID != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyID);
        objEntity.Organisation_id = Convert.ToInt32(orgID);
        objEntity.Corporate_id = Convert.ToInt32(corptID);


        if (LedgrIdID != "--SELECT--" && LedgrIdID != "")
        {
            objEntity.AccntNameId = Convert.ToInt32(LedgrIdID);
        }

        if (from != "")
        {
            objEntity.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntity.ToDate = objCommon.textToDateTime(toDt);
        }

        objEntity.cncl_sts = Convert.ToInt32(CnclSts);


        objEntity.StartDate = objCommon.textToDateTime(FinancialStartDate);
        objEntity.EndDate = objCommon.textToDateTime(FinancialEndDate);

        objEntity.RcptSts = Convert.ToInt32(RcptStatus);

        DataTable dt = objBussinessRcpt.ReadReceiptList(objEntity);
        strReturn = OBJ.LoadTable_CSV(dt, objEntity, CurrencyID, from, toDt, AccountBook, RcptStatus, Status);
        return strReturn;
    }

    public string LoadTable_CSV(DataTable dtCategory, clsEntity_Receipt_Account ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Status)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, ObjEntityRequest, CurrencyId, from, toDt, Suplier, PurchaseStatus, Status);
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
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECIPTLIST_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Receipt/ReceiptList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "ReceiptList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.RECIPTLIST_CSV);
        return strImagePath + filepath;
    }
    public DataTable GetTable(DataTable dt, clsEntity_Receipt_Account ObjEntityRequest, string CurrencyId, string from, string toDt, string Suplier, string PurchaseStatus, string Status)
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
        table.Columns.Add("RECEIPT LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Columns.Add("    ", typeof(string));
        table.Columns.Add("     ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + from + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + toDt + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Suplier != "")
            table.Rows.Add("SUPPLIER :", '"' + Suplier.TrimEnd(',', ' ') + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
            if (PurchaseStatus == "1")
            table.Rows.Add("RECEIPT STATUS :", "Confirmed", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "0")
            table.Rows.Add("RECEIPT STATUS :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else if (PurchaseStatus == "2")
            table.Rows.Add("RECEIPT STATUS :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        else
            table.Rows.Add("RECEIPT STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("REF #", "ACCOUNT", "DATE", "NARRATION", "TOTAL AMOUNT", "STATUS");
        decimal Total = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string strId = dt.Rows[0][0].ToString();
            int usrId = Convert.ToInt32(strId);
            int intIdLength = dt.Rows[0][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount][3].ToString();
            int CNT = intRowBodyCount + 1;
            string strNetAmount = dt.Rows[intRowBodyCount]["RECPT_TOTAL_AMT"].ToString();
            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
            string amountFrm = strNetAmountWithComma;
            Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["RECPT_TOTAL_AMT"].ToString());
            string strStatusImg = "";
            if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() == "1")
            {
                strStatusImg = "CONFIRMED";
            }
            else
            {
                if (dt.Rows[intRowBodyCount]["RECPT_REOPEN_USRID"].ToString() != "")
                {
                    strStatusImg = "REOPENED";
                }
                else
                {
                    strStatusImg = "PENDING";
                }
            }
            table.Rows.Add('"' + dt.Rows[intRowBodyCount]["RECPT_REF"].ToString() + '"', '"' + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + '"', '"' + dt.Rows[intRowBodyCount]["RECPT_DATE"].ToString() + '"', '"' + dt.Rows[intRowBodyCount]["RECPT_DSCRPTN"].ToString() + '"', '"' + amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + '"', '"' + strStatusImg + '"');
        }

        if (dt.Rows.Count > 0)
        {
            table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + strHiddenCurrrencyAbrvtn + '"', '"' + FORNULL + '"');
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
    [WebMethod]
    public static string PrintList(string orgID, string corptID, string FinancialStartDate, string FinancialEndDate, string CurrencyID, string RcptStatus, string from, string toDt, string CnclSts, string LedgrIdID, string Status, string AccountBook)
    {

        string strReturn = "";
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsBusinessLayer_Receipt_Account objBussinessRcpt = new clsBusinessLayer_Receipt_Account();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();
        if (CurrencyID != "")
            objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyID);
        objEntity.Organisation_id = Convert.ToInt32(orgID);
        objEntity.Corporate_id = Convert.ToInt32(corptID);
        if (LedgrIdID != "--SELECT--" && LedgrIdID != "")
        {
            objEntity.AccntNameId = Convert.ToInt32(LedgrIdID);
        }
        if (from != "")
        {
            objEntity.FromDate = objCommon.textToDateTime(from);
        }
        if (toDt != "")
        {
            objEntity.ToDate = objCommon.textToDateTime(toDt);
        }
        objEntity.cncl_sts = Convert.ToInt32(CnclSts);
        objEntity.StartDate = objCommon.textToDateTime(FinancialStartDate);
        objEntity.EndDate = objCommon.textToDateTime(FinancialEndDate);
        objEntity.RcptSts = Convert.ToInt32(RcptStatus);
        DataTable dt = objBussinessRcpt.ReadReceiptList(objEntity);
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRANSACTION_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_PDF);
        objEntityCommon.CorporateID = objEntity.Corporate_id;
        objEntityCommon.Organisation_Id = objEntity.Organisation_id;
        string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "ReceiptList_" + strNextNumber + ".pdf";

        Document document = new Document(PageSize.A4, 50f, 40f, 120f, 30f);
        document = new Document(PageSize.LETTER, 50f, 40f, 20f, 40f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
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
                if (AccountBook != "")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("SUPPLIER  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                    footrtable.AddCell(new PdfPCell(new Phrase(AccountBook, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                }
                //footrtable.AddCell(new PdfPCell(new Phrase("STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //if (Status == "0")
                //{
                //    footrtable.AddCell(new PdfPCell(new Phrase("Inactive", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //}
                //else if (Status == "1")
                //{
                //    footrtable.AddCell(new PdfPCell(new Phrase("Active", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //}
                //else
                //{
                //    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                //}
                footrtable.AddCell(new PdfPCell(new Phrase("RECEIPT STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (RcptStatus == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (RcptStatus == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (RcptStatus == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (RcptStatus == "4")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(6);
                float[] footrsBody = { 15, 20, 12, 20, 21, 12 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REF#", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("ACCOUNT", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("NARRATION", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL AMOUNT ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });



                string strRandom = objCommon.Random_Number();
                decimal Total = 0;

                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                {
                    string strId = dt.Rows[0][0].ToString();
                    int usrId = Convert.ToInt32(strId);
                    int intIdLength = dt.Rows[0][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    string strCancTransaction = dt.Rows[intRowBodyCount][3].ToString();
                    int CNT = intRowBodyCount + 1;
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["RECPT_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["RECPT_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["RECPT_DSCRPTN"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                    string strNetAmount = dt.Rows[intRowBodyCount]["RECPT_TOTAL_AMT"].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                    string amountFrm = strNetAmountWithComma;
                    TBCustomer.AddCell(new PdfPCell(new Phrase(amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                    Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["RECPT_TOTAL_AMT"].ToString());

                    string strStatusImg = "";
                    if (dt.Rows[intRowBodyCount]["RECPT_CNFRM_STS"].ToString() == "1")
                    {
                        strStatusImg = "CONFIRMED";
                    }
                    else
                    {
                        if (dt.Rows[intRowBodyCount]["RECPT_REOPEN_USRID"].ToString() != "")
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

                if (dt.Rows.Count > 0)
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase(objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + strHiddenCurrrencyAbrvtn, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase("No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 5 });
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
            headtable.AddCell(new PdfPCell(new Phrase("RECEIPT LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    [WebMethod]
    public static string CheckSaleSettlement(string strPayemntId, string strOrgIdID, string strCorpID)
    {
        //EVM-0020
        string ret = "successConfirm";

        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        ObjEntityRequest.ReceiptId = Convert.ToInt32(strId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityRequest.Status = 0;

        int CntExceed = 0;

        DataTable dtLDGRdTLS = objBussiness.ReadReceptLedgerDetailsByIdforPrint(ObjEntityRequest);
        DataTable dtcstrDTLS = new DataTable();

        for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
        {
            ObjEntityRequest.Status = 1;
            ObjEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString());

            dtcstrDTLS = objBussiness.ReadReceptCostcntrDetailsById(ObjEntityRequest);
            for (int CstrowCnt = 0; CstrowCnt < dtcstrDTLS.Rows.Count; CstrowCnt++)
            {
                if (dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString() != "" || dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString() != "")
                {
                    clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();

                    objSubEntity.Organisation_id = Convert.ToInt32(strOrgIdID);
                    objSubEntity.Corporate_id = Convert.ToInt32(strCorpID);
                    if (dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString() == "")
                    {
                        objSubEntity.Status = 1;
                        objSubEntity.CostCtrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["SALES_ID"].ToString());

                    }
                    else
                    {
                        objSubEntity.Status = 0;
                        objSubEntity.CostCtrId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["COSTCNTR_ID"].ToString());
                    }
                    objSubEntity.CstCntrAmnt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["RECPT_CST_AMT"].ToString());



                    if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                    {
                        objSubEntity.AccntNameId = Convert.ToInt32(dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString());
                        objSubEntity.BalanceAmount = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["CREDITNOTE_BAL"].ToString());
                        objSubEntity.LedgerAmnt = Convert.ToDecimal(dtcstrDTLS.Rows[CstrowCnt]["CREDITNOTE_SETLAMNT"].ToString());
                    }


                    DataTable dtSalesBalance = objBussiness.ReadSalesBalance(objSubEntity);

                    if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                    {
                        dtSalesBalance = objBussiness.ReadSalesReturnBalance(objSubEntity);
                    }

                    decimal decCheckAmnt = objSubEntity.CstCntrAmnt;
                    if (dtcstrDTLS.Rows[CstrowCnt]["LDGR_CR_ID"].ToString() != "")
                    {
                        decCheckAmnt = objSubEntity.LedgerAmnt;
                    }

                    decimal decSalesRemainAmt = 0;
                    if (dtSalesBalance.Rows.Count > 0)
                    {
                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                    }

                    if (objSubEntity.Status != 0)
                    {
                        if (decSalesRemainAmt != 0)
                        {
                            if (decSalesRemainAmt < decCheckAmnt)
                            {
                                ret = "SalesAmountExceeded";
                                CntExceed++;
                            }
                        }
                        else if (CntExceed == 0)
                        {
                            ret = "SalesAmtFullySettld";
                        }
                    }

                }
            }
        }

        return ret;
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
        DataRow[] resultss = dsList.Select("REPARECSUB_STS = '1'");

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
            strHtml += "<a href=\"/FMS/FMS_Master/fms_Receipt_Account/fms_Receipt_Account.aspx?Rid=" + StrCorpId + "\" class=\"flip_o\" onmouseover=\"return ShowOrderDtls('" + StrCorpId + "');\">" + dtOrders.Rows[i]["REPARECSUB_DATE"].ToString() + "</a>";
            strHtml += "</td>";
            strHtml += "<td class=\"td_rec1\">" + dtOrders.Rows[i]["RECPT_REF"].ToString() + "</td>";
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
}