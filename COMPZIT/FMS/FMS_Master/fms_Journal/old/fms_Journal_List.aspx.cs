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

public partial class FMS_FMS_Master_fms_Journal_fms_Journal_List : System.Web.UI.Page
{
    int intAccntCloseReopen = 0;
    int intReopen = 0;
    static string strFromDate = "";
    static string strToDate = "";
    static string strStatus = "";
    static string strCnclSts = "";
    static string strHiddenReopen = "";
    static string strHiddenReopenSts = "";
    static string strHiddenProvisionSts = "";
    static string strHiddenFieldAuditCloseReopenSts = "";
    static string strHiddenFieldDecimalCnt = "";
    static string strhiddenDfltCurrencyMstrId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objentcommn = new clsEntityCommon();
            LoadLedger();
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityLayerStock.User_Id = intUserId;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityLayerStock.Corp_Id = intCorpId;
                objentcommn.CorporateID = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityLayerStock.Org_Id = intOrgId;
                objentcommn.Organisation_Id = intOrgId;
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (CbxCnclStatus.Checked == true)
            {
                objEntityLayerStock.ConfirmSts = 1;
            }
            else
            {
                objEntityLayerStock.ConfirmSts = 0;
            }

            if (Session["FINCYRID"] != null)
            {
                objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            string caption = PrintCaption(objEntityLayerStock);
            divPrintCaption.InnerHtml = caption;
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intConfirm = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenReopen.Value = "0";
            strHiddenReopen = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenProvisionSts.Value = "1";
                        strHiddenProvisionSts = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenReopen.Value = "1";
                        strHiddenReopen = "1";
                        
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
                }
            }
            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                divAdd.Visible = false;
            }

            objEntityLayerStock.FromPeriod = DateTime.MinValue; ;
            objEntityLayerStock.ToPeriod = DateTime.MinValue;



            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

            if (dtfinaclYear.Rows.Count > 0)
            {
                objEntityLayerStock.FromPeriod = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntityLayerStock.ToPeriod = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());

                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
                DateTime startDate = new DateTime();
                //if (dtAcntClsDate.Rows.Count > 0)
                //{

                //    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0][0].ToString();
                //    if (HiddenProvisionSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                //    {
                //        if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //        {
                //            divAdd.Visible = true;
                //        }
                //        if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //        {
                //            HiddenReopenSts.Value = "1";
                //        }
                //        if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //        {
                //            hiddenEnableCancl.Value = "1";
                //        }
                //    }
                //    else
                //    {
                //        startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                //        if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                //        {
                //            divAdd.Visible = false;
                //        }
                //        else
                //        {

                //        }
                //    }
                //    if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //    {
                //        HiddenReopenSts.Value = "1";
                //    }
                //}
               
                    if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopenSts.Value = "1";
                        strHiddenReopenSts = "1";
                    }


                    // HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    //HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
               

                DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());


                if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtDateTo.Value = objBusinessLayer.LoadCurrentDateInString();
                    curdate = curdate.AddDays(-30);
                    if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtDateFrom.Value = curdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtDateFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }
                else
                {
                    txtDateTo.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    curdate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                    curdate = curdate.AddDays(-30);
                    if (curdate >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                    {
                        txtDateFrom.Value = curdate.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        txtDateFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    }
                }



            }
            if (txtDateFrom.Value != "")
                objEntityLayerStock.FromDate = objCommon.textToDateTime(txtDateFrom.Value);
            if (txtDateTo.Value != "")
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtDateTo.Value);
            if (ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
                objEntityLayerStock.JournalId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
            objEntityLayerStock.JrnltSts = Convert.ToInt32(ddlJrnlSts.SelectedItem.Value);

            strFromDate = txtDateFrom.Value;
            strToDate = txtDateTo.Value;
            strStatus = ddlJrnlSts.SelectedItem.Value;
            strCnclSts = "0";

            DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntityLayerStock);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID                                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCancelReasonMust.Value = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                strHiddenFieldDecimalCnt = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                strhiddenDfltCurrencyMstrId = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intConfirm);
            //divPrintReport.InnerHtml = ConvertDataTableToPrint(dtList, intUpdate, intEnableCancel, intConfirm);

        }
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
            else if (Request.QueryString["InsUpd"] == "UpdConfm")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CanclCnfMsg", "CanclCnfMsg();", true);
            }
            else if (Request.QueryString["InsUpd"] == "AcntClosed")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "AcntClosed", "AcntClosed();", true);
            }
            else if (Request.QueryString["InsUpd"] == "AuditClosed")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "AuditClosed", "AuditClosed();", true);
            }
            else if (Request.QueryString["InsUpd"] == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
            }
            else if (Request.QueryString["InsUpd"] =="Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
            }
            else if (Request.QueryString["InsUpd"]== "SaleAmtExceed")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountExceeded", "SalesAmountExceeded();", true);
            }
            else if (Request.QueryString["InsUpd"] == "PurchaseAmtExceed")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PurchaseAmountExceeded", "PurchaseAmountExceeded();", true);
            }
            else if (Request.QueryString["InsUpd"] == "Cnf")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfMsg", "SuccessCnfMsg();", true);
            }
        }
    }

    public string PrintCaption(clsEntityJournal ObjEntityRequest)
    {
        clsBusinessLayerReports objBusinessLayerReports = new clsBusinessLayerReports();
        clsEntityReports objEntityReports = new clsEntityReports();
        objEntityReports.Corporate_Id = ObjEntityRequest.Corp_Id;
        objEntityReports.Organisation_Id = ObjEntityRequest.Org_Id;
        //    objEntityReports.User_Id = ObjEntityRequest.User_Id;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        string strTitle = "";
        strTitle = "JOURNAL";
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
    public int AccountCloseCheck(string strDate)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
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
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }
    public void LoadLedger()
    {
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLayerStock.ReadLedgrListDdl(objEntityLayerStock);
        if (dtdiv.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtdiv;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");
    }
    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel, int intConfirm)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objentcommn = new clsEntityCommon();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();


        string strRandom = objCommon.Random_Number();
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            objEntityAudit.Organisation_id = Convert.ToInt32(Session["ORGID"]);
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAudit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            int intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objentcommn.CorporateID = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
      
        DateTime acntClsDate = DateTime.MinValue;
        if(strhiddenDfltCurrencyMstrId!="")
        objentcommn.CurrencyId = Convert.ToInt32(strhiddenDfltCurrencyMstrId);
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
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";
        strHtml += "<tr >";
        for (int intColumnHeaderCount = 0; intColumnHeaderCount <= 5; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"col-md-4 tr_l\">REF# ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i> <input id=\"hasRef\" class=\"tb_inp_1 tb_in tr_l\" placeholder=\" REF#\" type=\"text\" autocomplete=\"off\">  ";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"col-md-2 tr_c\"> DATE ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i>	<input id=\"hasDate\" class=\"tb_inp_1 tb_in tr_c\"  placeholder=\" DATE\" type=\"text\" autocomplete=\"off\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"col-md-2 tr_r\">TOTAL AMOUNT ";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i> <input id=\"hasAmt\" class=\"tb_inp_1 tb_in tr_r\" placeholder=\"TOTAL AMOUNT\" type=\"text\" autocomplete=\"off\">";
                strHtml += "</th >";

                strHtml += "<th class=\"thT\" style=\"display:none;\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"col-md-1\" ></th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                if (strCnclSts == "0")
                {
                    strHtml += "<th class=\"col-md-1\"> STATUS<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i></th>";
                }
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += " <th class=\"col-md-4\">ACTIONS </th>";
            }

        }
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
       
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr>";

            int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString());
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString();
            decimal value = 0;
            if (dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString() != "")
            {
                value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
            }
            int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, value);
            valuestring = valuestring + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
            for (int intColumnBodyCount = 0; intColumnBodyCount <= 5; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {

                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["JURNL_REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    objEntityAudit.FromDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString());
                    strHtml += "<td class=\"tr_c\" > " + dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
                    string strNetAmountWithComma = objBusinessLayer.AddCommasForNumberSeperation(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString(), objentcommn);
                    //strHtml += "<td class=\"tr_r\" > " + valuestring + "</td>";
                    strHtml += "<td class=\"tr_r\" > " + strNetAmountWithComma + "</td>";
                    strHtml += "<td class=\"tr_r\" style=\" display:none;\" > " + dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td > " + dt.Rows[intRowBodyCount]["JURNL_REF_SEQNUM"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    if (strCnclSts == "0")
                    {
                        if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "1")
                        {
                            strHtml += "<td class=\"tr_c\" >Confirmed </td>";
                        }
                        else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0" && dt.Rows[intRowBodyCount]["JURNL_REOPEN_STATUS"].ToString() == "1")
                        {
                            if (dt.Rows[intRowBodyCount]["JURNL_REOPEN_USRID"].ToString() != "")
                            {
                                strHtml += "<td class=\"tr_c\" > Reopened</td>";
                            }
                        }
                        else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0")
                        {
                            strHtml += "<td class=\"tr_c\" > Pending</td>";
                        }
                    }
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += " <td>";
                    DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {
                                if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "1")
                                {
                                    strHtml += " <a class=\"btn act_btn bn4\"  title=\"View\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Journal.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                }
                                else
                                {
                                    if (dtAuditClsDate.Rows.Count > 0)
                                    {

                                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                        {

                                            if (strHiddenFieldAuditCloseReopenSts == "1")
                                            {
                                                strHtml += " <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                    " href=\"fms_Journal.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                                            }
                                            else
                                            {
                                                strHtml += "  <a class=\"btn act_btn bn4\"  title=\"View\" onclick='return getdetails(this.href);' " +
                                                     " href=\"fms_Journal.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += " <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                    " href=\"fms_Journal.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                                        }

                                    }

                                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                    {
                                        if (strHiddenProvisionSts == "1")
                                        {
                                            strHtml += " <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                     " href=\"fms_Journal.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                                        }
                                        else
                                        {
                                            strHtml += " <a class=\"btn act_btn bn4\"  title=\"View\" onclick='return getdetails(this.href);' " +
                                                    " href=\"fms_Journal.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += " <a class=\"btn act_btn bn1\"  title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                   " href=\"fms_Journal.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                                    }

                                }

                            }
                            else
                            {
                                strHtml += " <a class=\"btn act_btn bn4\"  title=\"View\" onclick='return getdetails(this.href);' " +
                                                    " href=\"fms_Journal.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                            }

                        }

                    }



                    if (strCnclSts == "0")
                    {
                        if (YearEndCls == 0)
                        {
                            if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() != "1")
                            {

                                if (Convert.ToInt32(strStatus) != 1)
                                {

                                    if (intConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                    {


                                        if (dtAuditClsDate.Rows.Count > 0)
                                        {

                                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                            {

                                                if (strHiddenFieldAuditCloseReopenSts == "1")
                                                {
                                                    strHtml += "<a class=\"btn act_btn bn2\"  title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                                }
                                                else
                                                {
                                                    strHtml += "<a class=\"btn act_btn bn2\" disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                                }
                                            }
                                            else
                                            {
                                                strHtml += "<a class=\"btn act_btn bn2\"  title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                            }

                                        }

                                        else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                        {
                                            if (strHiddenProvisionSts == "1")
                                            {
                                                strHtml += "<a class=\"btn act_btn bn2\"  title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                            }
                                            else
                                            {
                                                strHtml += "<a class=\"btn act_btn bn2\" disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a class=\"btn act_btn bn2\"  title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a class=\"btn act_btn bn2\" disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                    }


                                }

                            }
                            else
                            {
                                strHtml += "<a class=\"btn act_btn bn2\" disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                            }

                        }
                        else
                        {
                            strHtml += "<a class=\"btn act_btn bn2\" disabled  href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                        }
                    }

                    if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "1")
                    {
                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {

                                if (strHiddenReopenSts == "1")
                                {
                                    if (dtAuditClsDate.Rows.Count > 0)
                                    {

                                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                        {

                                            if (strHiddenFieldAuditCloseReopenSts == "1")
                                            {
                                                strHtml += "<a class=\"btn act_btn bn2\" href=\"javascript:;\" style=\"cursor: pointer;\"  title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";

                                            }
                                            else
                                            {
                                                strHtml += "<a class=\"btn act_btn bn2\" href=\"javascript:;\" disabled style=\"cursor: pointer;\"  title=\"REOPEN\"  ><i class=\"fa fa-unlock\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a class=\"btn act_btn bn2\" href=\"javascript:;\"   title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";

                                        }

                                    }
                                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                    {
                                        if (strHiddenProvisionSts == "1")
                                        {
                                            strHtml += " <a class=\"btn act_btn bn2\" href=\"javascript:;\"   title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";

                                        }
                                        else
                                        {
                                            strHtml += " <a class=\"btn act_btn bn2\" href=\"javascript:;\" disabled style=\"cursor: pointer;\"  title=\"REOPEN\"  ><i class=\"fa fa-unlock\"></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += " <a class=\"btn act_btn bn2\" href=\"javascript:;\"   title=\"REOPEN\"  onclick=\"return ReOpen('" + Id + "');\" ><i class=\"fa fa-unlock\"></i></a>";
                                    }
                                }
                            }
                            else
                            {
                                strHtml += " <a class=\"btn act_btn bn2\" href=\"javascript:;\" disabled style=\"cursor: pointer;\"  title=\"REOPEN\"  ><i class=\"fa fa-unlock\"></i></a>";
                            }
                        }
                    }
                    else
                    {
                        if (strCnclSts == "0")
                        {
                            strHtml += " <a class=\"btn act_btn bn2\" href=\"javascript:;\" disabled style=\"cursor: pointer;\"  title=\"REOPEN\"  ><i class=\"fa fa-unlock\"></i></a>";
                        }
                    }


                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                    {

                                        if (strHiddenFieldAuditCloseReopenSts == "1")
                                        {
                                            if (strCancTransaction == "0")
                                            {

                                                strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\"  class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";

                                            }
                                            else
                                            {
                                                strHtml += "<a class=\"btn act_btn bn3\" href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        if (strCancTransaction == "0")
                                        {
                                            strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";
                                        }
                                        else
                                        {
                                            strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";

                                        }

                                    }

                                }



                                else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString()))
                                {
                                    if (strHiddenProvisionSts == "1")
                                    {
                                        if (strCancTransaction == "0")
                                        {
                                            strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";

                                        }
                                        else
                                        {
                                            strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";
                                    }






                                }
                                else
                                {
                                    if (strCancTransaction == "0")
                                    {
                                        strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" ></i></a>";
                                    }
                                    else
                                    {
                                        strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";

                                    }
                                }
                            }
                            else
                            {
                                strHtml += "<a class=\"btn act_btn bn3\"  href=\"javascript:;\" disabled class=\"tooltip \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" ></i></a>";
                            }

                        }
                    }
                    if (strCnclSts == "0")
                    {
                        strHtml += "<a class=\"btn act_btn bn6\" title=\"Print Voucher\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                    }



                    if (strCnclSts == "1")
                    {
                        strHtml += " <a class=\"btn act_btn bn4\"  title=\"View\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Journal.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                    }

                    strHtml += "</td>";
                }
            }

        }
        strHtml += "</tr>";


        strHtml += "</tbody>";
        if (dt.Rows.Count > 0)
        {
            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" >TOTAL </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\"  style=\"text-align:right;\"> " + objBusinessLayer.AddCommasForNumberSeperation(Total.ToString(), objentcommn) + "</th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";

            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToPrint(DataTable dt, int intUpdate, int intEnableCancel, int intConfirm)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            int intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objentcommn.CorporateID = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
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
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"PrintTable\" class=\"tab\" \">";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"top_row\">";
        strHtml += "<th class=\"thT\" style=\"width:35%;text-align:left;\">REFERENCE NUMBER";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:20%;text-align:center;\">DATE";
        strHtml += "</th >";
        strHtml += "<th class=\"thT\" style=\"width:25%;text-align:right;\">TOTAL AMOUNT";
        strHtml += "</th >";

        if (strCnclSts == "0")
        {
            strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left;\"> STATUS";
        }
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString());
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();
            decimal value = 0;
            if (dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString() != "")
            {
                value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
            }
            int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, value);
            valuestring = valuestring + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
            strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["JURNL_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" > " + dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + valuestring + "</td>";
            if (strCnclSts == "0")
            {
                if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "1")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Confirmed </td>";
                }
                else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0" && dt.Rows[intRowBodyCount]["JURNL_REOPEN_STATUS"].ToString() == "1")
                {
                    if (dt.Rows[intRowBodyCount]["JURNL_REOPEN_USRID"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" > Reopened</td>";
                    }
                }
                else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" > Pending</td>";
                }
            }


            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public string ConvertDataTableToPrint_PDF(DataTable dt, string fromDate, string toDate, string Status, string LedgerID, string CnclSts)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
      
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            int intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objentcommn.CorporateID = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
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
        StringBuilder sb = new StringBuilder();
        string strRet = "";
        decimal Total = 0;
        string strRandom = objCommon.Random_Number();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRANSACTION_PDF);
        objentcommn.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PDF);
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objentcommn);
        string strImageName = "JournalList_" + strNextNumber + ".pdf";

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
                footrtable.AddCell(new PdfPCell(new Phrase(fromDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("TO DATE     ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(toDate, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase("JOURNAL STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                footrtable.AddCell(new PdfPCell(new Phrase(":", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
                if (Status == "0")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (Status == "1")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (Status == "2")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                else if (Status == "4")
                {
                    footrtable.AddCell(new PdfPCell(new Phrase("All", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, PaddingBottom = 6 });
                }
                document.Add(footrtable);

                //adding table to pdf
                PdfPTable TBCustomer = new PdfPTable(4);
                float[] footrsBody = { 30, 20, 30, 20 };
                TBCustomer.SetWidths(footrsBody);
                TBCustomer.WidthPercentage = 100;
                TBCustomer.HeaderRows = 1;

                var FontGray = new BaseColor(138, 138, 138);
                var FontColour = new BaseColor(134, 152, 160);
                var FontSmallGray = new BaseColor(230, 230, 230);

                TBCustomer.AddCell(new PdfPCell(new Phrase("REFERENCE NUMBER", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("DATE", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL AMOUNT ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
                TBCustomer.AddCell(new PdfPCell(new Phrase("STATUS", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

                if (dt.Rows.Count > 0)
                {
                    for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                    {
                        int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString());
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();
                        decimal value = 0;
                        if (dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString() != "")
                        {
                            Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
                            value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
                        }
                        int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
                        string format = String.Format("{{0:N{0}}}", precision);
                        string valuestring = String.Format(format, value);
                        // valuestring = valuestring + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString();
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["JURNL_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(valuestring, FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

                        if (strCnclSts == "0")
                        {
                            if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "1")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0" && dt.Rows[intRowBodyCount]["JURNL_REOPEN_STATUS"].ToString() == "1")
                            {
                                if (dt.Rows[intRowBodyCount]["JURNL_REOPEN_USRID"].ToString() != "")
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                            }
                            else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Total.ToString(), objentcommn), FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                    }
                }
                else
                {
                    TBCustomer.AddCell(new PdfPCell(new Phrase(" No data available in table", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, Colspan = 4 });
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
            headtable.AddCell(new PdfPCell(new Phrase("JOURNAL LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ConfirmJrnlDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID)
    {
        FMS_FMS_Master_fms_Journal_fms_Journal_List objPage = new FMS_FMS_Master_fms_Journal_fms_Journal_List();
        string[] strRets = new string[3];

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();

        strRets[0] = "successConfirm";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityLayerStock.JournalId = Convert.ToInt32(strId);
        objEntityLayerStock.Org_Id = Convert.ToInt32(strOrgIdID);
        objEntityLayerStock.Corp_Id = Convert.ToInt32(strCorpID);
        objEntityLayerStock.User_Id = Convert.ToInt32(strUserID);
        objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
        try
        {
            DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
            string strdate = "";
            int CntExceed = 0;

            if (dt.Rows.Count > 0)
            {

                DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYear(objEntityCommon);

                if (dtfinaclYear.Rows.Count > 0)
                {
                    if (dtfinaclYear.Rows[0]["FINCYR_ID"].ToString() != "")
                    {
                        objEntityLayerStock.FinancialYrId = Convert.ToInt32(dtfinaclYear.Rows[0]["FINCYR_ID"].ToString());
                    }
                }


                if (dt.Rows[0]["JURNL_REF"].ToString() != "")
                {

                    objEntityLayerStock.RefNum = dt.Rows[0]["JURNL_REF"].ToString();
                }
                if (dt.Rows[0]["JURNL_DATE"].ToString() != "")
                {
                    objEntityLayerStock.JournalDate = objCommon.textToDateTime(dt.Rows[0]["JURNL_DATE"].ToString());




                }

                if (dt.Rows[0]["JURNL_DSCRPTN"].ToString() != "")
                {
                    objEntityLayerStock.Description = dt.Rows[0]["JURNL_DSCRPTN"].ToString();
                }

                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                {
                    objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
                }
                objEntityLayerStock.ConfirmSts = 1;

                if (dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString() != "")
                {
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString());
                }
                if (dt.Rows[0]["JURNL_REF_SEQNUM"].ToString() != "")
                {
                    objEntityLayerStock.RefSeqNo = Convert.ToInt32(dt.Rows[0]["JURNL_REF_SEQNUM"].ToString());
                }

                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                List<clsEntityJournalCostCntrDtl> objEntityDelete = new List<clsEntityJournalCostCntrDtl>();//EVM-0020


                int DebtCount = 0;
                int CrdtCount = 0;
                DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                int rowSubCatagory = 0;
                for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                {
                    decimal decSalesRemainAmt = 0;
                    decimal decPrchsRemainAmt = 0;

                    clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();

                    objEntityDtl.LdgrCount = i;
                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() != "")
                    {
                        if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() == "0")
                        {
                            objEntityDtl.TabMode = 0;
                            DebtCount++;
                        }
                        else
                        {
                            objEntityDtl.TabMode = 1;
                            CrdtCount++;
                        }
                    }

                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() != "")
                    {
                        objEntityDtl.MainTabId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                    }

                    objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                    if (dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() != "")
                    {
                        objEntityDtl.LedgerId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString());
                    }
                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString() != "")
                    {
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                    }

                    if (dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString() != "")
                    {
                        objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt * objEntityLayerStock.ExchangeRate;
                    }
                    else
                    {
                        objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt;
                    }
                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_REMARK"].ToString() != "")
                    {
                        objEntityDtl.Remarks = dtLedgrdDebDtl.Rows[i]["LD_JURNL_REMARK"].ToString();
                    }

                    objEntityJrnlLedgrList.Add(objEntityDtl);


                    objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                    DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);

                    if (dtCostCntrDebDtl.Rows.Count > 0)
                    {

                        for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                        {
                            clsEntityJournalCostCntrDtl objEntityCstDtl = new clsEntityJournalCostCntrDtl();
                            clsEntityJournalCostCntrDtl objEntityCstDtlDEL = new clsEntityJournalCostCntrDtl();//EVM-0020

                            if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() != "")
                            {
                                if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() == "0")
                                {
                                    objEntityCstDtl.TabMode = objEntityDtl.TabMode;

                                }


                                else
                                {
                                    objEntityCstDtl.TabMode = objEntityDtl.TabMode;
                                }
                            }

                            if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() != "")
                            {
                                objEntityCstDtl.MainTabId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                            }


                            objEntityCstDtl.JournalId = Convert.ToInt32(strId);
                            if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString() != "")
                            {
                                objEntityCstDtl.CostCntrAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                            }
                            if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                            {
                                objEntityCstDtl.PurSaleRefNum = "";
                                objEntityCstDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString());
                            }
                            else if (dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() != "")
                            {
                                objEntityCstDtl.PurSaleRefNum = "Cre";
                                objEntityCstDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString());

                                DataTable dtSalesBalance = objBusinessLayerStock.ReadSalesBalance(objEntityLayerStock, objEntityCstDtl);
                                if (dtSalesBalance.Rows.Count > 0)
                                {
                                    if (dtSalesBalance.Rows[0][1].ToString() != "")
                                        decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                }
                                //EVM-0020
                                if (decSalesRemainAmt != 0)
                                {
                                    if (decSalesRemainAmt < objEntityCstDtl.CostCntrAmnt)
                                    {
                                        strRets[0] = "SalesAmountExceeded";
                                        CntExceed++;
                                    }
                                }
                                else if (CntExceed == 0)
                                {
                                    strRets[0] = "SalesAmtFullySettld";
                                    objEntityCstDtlDEL.JournalCostCntrId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["CST_JURNL_ID"].ToString());
                                    objEntityDelete.Add(objEntityCstDtlDEL);
                                }

                                objEntityCstDtl.SettlmntAmmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["BALNC_AMT"].ToString());
                            }
                            else if (dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() != "")
                            {
                                objEntityCstDtl.PurSaleRefNum = "Deb";
                                objEntityCstDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString());

                                DataTable dtSalesBalance = objBusinessLayerStock.ReadPurchaseBalance(objEntityLayerStock, objEntityCstDtl);
                                if (dtSalesBalance.Rows.Count > 0)
                                {
                                    if (dtSalesBalance.Rows[0][1].ToString() != "")
                                        decPrchsRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                }
                                //EVM-0020
                                if (decPrchsRemainAmt != 0)
                                {
                                    if (decPrchsRemainAmt < objEntityCstDtl.CostCntrAmnt)
                                    {
                                        strRets[0] = "PrchsAmountExceeded";
                                        CntExceed++;
                                    }
                                }
                                else if (CntExceed == 0)
                                {
                                    strRets[0] = "PrchsAmtFullySettld";
                                    objEntityCstDtlDEL.JournalCostCntrId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["CST_JURNL_ID"].ToString());
                                    objEntityDelete.Add(objEntityCstDtlDEL);
                                }

                                objEntityCstDtl.SettlmntAmmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["PURCHS_BAL_AMT"].ToString());
                            }

                            if (dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_ONE"].ToString() != "")
                            {
                                objEntityCstDtl.CostGrp1Id = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_ONE"].ToString());
                            }
                            if (dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_TWO"].ToString() != "")
                            {
                                objEntityCstDtl.CostGrp2Id = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_TWO"].ToString());
                            }


                            if (dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString() != "")
                            {
                                objEntityCstDtl.ExchangeRate = objEntityCstDtl.CostCntrAmnt * Convert.ToDecimal(dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString());
                            }
                            else
                            {
                                objEntityCstDtl.ExchangeRate = objEntityCstDtl.CostCntrAmnt;
                            }

                            if (objEntityCstDtl.PurSaleRefNum == "" || (objEntityCstDtl.PurSaleRefNum == "Cre" && decSalesRemainAmt != 0) || (objEntityCstDtl.PurSaleRefNum == "Deb" && decPrchsRemainAmt != 0))//insert not fully settled or cst cntr
                            {
                                objEntityJrnlCostcentrList.Add(objEntityCstDtl);
                            }

                        }
                    }
                }

                objEntityLayerStock.CreditCount = CrdtCount;
                objEntityLayerStock.DebitCount = DebtCount;

                if (objEntityDelete.Count > 0)//delete fully settld saved sales and purchs
                {
                    objBusinessLayerStock.DeleteSalePurchaseLedgers(objEntityDelete);
                    strRets[0] = "successConfirm";
                }


                objEntityLayerStock.JournalId = Convert.ToInt32(strId);

                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                {
                    objEntityLayerStock.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                }

                DataTable dtChk = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
                if (dtChk.Rows[0][0].ToString() == "" && dtChk.Rows[0][1].ToString() == "0" && strRets[0] != "SalesAmountExceeded" && strRets[0] != "SalesAmtFullySettld" && strRets[0] != "PrchsAmountExceeded" && strRets[0] != "PrchsAmtFullySettld")
                {
                    objBusinessLayerStock.ConfirmJournalDtlsList(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);

                }


                clsEntityCommon objentcommn = new clsEntityCommon();
                clsEntityJournal objEntitySupplier = new clsEntityJournal();
                int intCorpId = 0, intOrgId = 0, intUserId = 0;
                intUserId = Convert.ToInt32(strUserID);
                objEntitySupplier.User_Id = intUserId;

                intCorpId = Convert.ToInt32(strCorpID);
                objEntitySupplier.Corp_Id = intCorpId;
                objentcommn.CorporateID = intCorpId;

                intOrgId = Convert.ToInt32(strOrgIdID);
                objEntitySupplier.Org_Id = intOrgId;
                objentcommn.Organisation_Id = intOrgId;

                if (strCnclSts == "1")
                {
                    objEntitySupplier.ConfirmSts = 1;
                }
                else
                {
                    objEntitySupplier.ConfirmSts = 0;
                }
                objEntitySupplier.FromDate = objCommon.textToDateTime(strFromDate);
                objEntitySupplier.JournalDate = objCommon.textToDateTime(strToDate);
                objEntitySupplier.JrnltSts = Convert.ToInt32(strStatus);

                DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntitySupplier);
                int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intConfirm = 0;
                intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                        }
                        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                        {
                            intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                        {
                            intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        {
                            intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        }
                    }
                }
                strRets[1] = objPage.ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intConfirm);
                strRets[2] = objPage.ConvertDataTableToPrint(dtList, intUpdate, intEnableCancel, intConfirm);

                //End:-For datatable

            }
        }

        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["CONFIRM_STS"] = strRets;
        return strRets;

    }
    [WebMethod]
    public static string[] CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgIdID,string strCorpID)
    {
        FMS_FMS_Master_fms_Journal_fms_Journal_List objPage = new FMS_FMS_Master_fms_Journal_fms_Journal_List();
        string[] strRets = new string[3];

        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityLayerStock.JournalId = Convert.ToInt32(strId);
        objEntityLayerStock.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            objEntityLayerStock.Cancel_Reason = cnclRsn;
        }

        else
        {
            objEntityLayerStock.Cancel_Reason = objCommon.CancelReason();
        }

        try
        {
            DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
            if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
            {
                objBusinessLayerStock.CancelJournal(objEntityLayerStock);
            }
            else if (dt.Rows[0][0].ToString() != "")
            {
                strRets[0] = "UpdCancl";
            }
            else
            {
                strRets[0] = "CnfCancl";
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objentcommn = new clsEntityCommon();
            clsEntityJournal objEntitySupplier = new clsEntityJournal();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            intUserId = Convert.ToInt32(usrId);
            objEntitySupplier.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            objEntitySupplier.Corp_Id = intCorpId;
            objentcommn.CorporateID = intCorpId;

            intOrgId = Convert.ToInt32(strOrgIdID);
            objEntitySupplier.Org_Id = intOrgId;
            objentcommn.Organisation_Id = intOrgId;

            if (strCnclSts == "1")
            {
                objEntitySupplier.ConfirmSts = 1;
            }
            else
            {
                objEntitySupplier.ConfirmSts = 0;
            }
            objEntitySupplier.FromDate = objCommon.textToDateTime(strFromDate);
            objEntitySupplier.JournalDate = objCommon.textToDateTime(strToDate);
            objEntitySupplier.JrnltSts = Convert.ToInt32(strStatus);

            DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntitySupplier);
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intConfirm = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            strRets[1] = objPage.ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intConfirm);
            strRets[2] = objPage.ConvertDataTableToPrint(dtList, intUpdate, intEnableCancel, intConfirm);

            //End:-For datatable
        }
        catch
        {
            strRets[0] = "failed";
        }
        return strRets;
    }


    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsEntityJournal objEntitySupplier = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        strHiddenFieldDecimalCnt = HiddenFieldDecimalCnt.Value;

        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntitySupplier.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntitySupplier.Corp_Id = intCorpId;
            objentcommn.CorporateID = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntitySupplier.Org_Id = intOrgId;
            objentcommn.Organisation_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (CbxCnclStatus.Checked == true)
        {
            objEntitySupplier.ConfirmSts = 1;
            strCnclSts = "1";
        }
        else
        {
            objEntitySupplier.ConfirmSts = 0;
            strCnclSts = "0";
        }
        if (Session["FINCYRID"] != null)
        {
            objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        objEntitySupplier.FromDate = objCommon.textToDateTime(txtDateFrom.Value);
        objEntitySupplier.JournalDate = objCommon.textToDateTime(txtDateTo.Value);
        if (ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
            objEntitySupplier.JournalId = Convert.ToInt32(ddlLedger.SelectedItem.Value);

        objEntitySupplier.JrnltSts = Convert.ToInt32(ddlJrnlSts.SelectedItem.Value);

        strFromDate = txtDateFrom.Value;
        strToDate = txtDateTo.Value;
        strStatus = ddlJrnlSts.SelectedItem.Value;
       


        DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntitySupplier);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intConfirm=0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                }
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
               
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                {
                    intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenProvisionSts.Value = "1";
                    strHiddenProvisionSts = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenReopen.Value = "1";
                    strHiddenReopen = "1";

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
            }
        }

        if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {

        }
        else
        {
            divAdd.Visible = false;
        }

       DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

       if (dtfinaclYear.Rows.Count > 0)
       {
           objEntityLayerStock.FromPeriod = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
           objEntityLayerStock.ToPeriod = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());

           HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
           HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

           DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
           DateTime startDate = new DateTime();
           if (dtAcntClsDate.Rows.Count > 0)
           {

               HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0][0].ToString();
               if (HiddenProvisionSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
               {
                   if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                   {
                       divAdd.Visible = true;
                   }
                   if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                   {
                       HiddenReopenSts.Value = "1";
                       strHiddenReopenSts = "1";
                   }
                   if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                   {
                       hiddenEnableCancl.Value = "1";
                   }
                
               }
               else
               {
                   startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                   if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                   {
                       divAdd.Visible = false;
                   }
                   else
                   {

                   }
               }
               if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
               {
                   HiddenReopenSts.Value = "1";
                   strHiddenReopenSts = "1";
               }
           }
           else
           {
               if (intReopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
               {
                   HiddenReopenSts.Value = "1";
                   strHiddenReopenSts = "1";
               }
           }
       }

     
       divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intConfirm);
       //divPrintReport.InnerHtml = ConvertDataTableToPrint(dtList, intUpdate, intEnableCancel, intConfirm);
        
    }

    [WebMethod]
    public static string ListPrint_PDF(string FINCYRID, string orgID, string corptID, string DecCnt, string CnclSts, string fromDate, string toDate, string Status, string LedgerID, string strPrintMode)
    {
        string strReturn = "";
        clsEntityCommon objentcommn = new clsEntityCommon();
        clsEntityJournal objEntitySupplier = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        FMS_FMS_Master_fms_Journal_fms_Journal_List OBJ = new FMS_FMS_Master_fms_Journal_fms_Journal_List();
        strHiddenFieldDecimalCnt = DecCnt;

        int intCorpId = 0, intOrgId = 0, intUserId = 0;

        if (corptID != "" )
        {
            intCorpId = Convert.ToInt32(corptID);
            objEntitySupplier.Corp_Id = intCorpId;
            objentcommn.CorporateID = intCorpId;
        }

        if (orgID!="")
        {
            intOrgId = Convert.ToInt32(orgID);
            objEntitySupplier.Org_Id = intOrgId;
            objentcommn.Organisation_Id = intOrgId;
        }

        if (CnclSts=="1")
        {
            objEntitySupplier.ConfirmSts = 1;
            strCnclSts = "1";
        }
        else
        {
            objEntitySupplier.ConfirmSts = 0;
            strCnclSts = "0";
        }
        if (FINCYRID != "")
        {
            objentcommn.FinancialYrId = Convert.ToInt32(FINCYRID);
        }

        objEntitySupplier.FromDate = objCommon.textToDateTime(fromDate);
        objEntitySupplier.JournalDate = objCommon.textToDateTime(toDate);
        if (LedgerID != "--SELECT LEDGER--")
        objEntitySupplier.JournalId = Convert.ToInt32(LedgerID);
        objEntitySupplier.JrnltSts = Convert.ToInt32(Status);
        DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntitySupplier);
        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);
        if (strPrintMode == "pdf")
        {
            strReturn = OBJ.ConvertDataTableToPrint_PDF(dtList, fromDate, toDate, Status, LedgerID, CnclSts);
        }
        else if ((strPrintMode == "csv"))
        {
            strReturn = OBJ.LoadTable_CSV(dtList,objEntitySupplier, fromDate, toDate, Status, LedgerID, CnclSts);
        }   
        return strReturn;
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
    public DataTable GetTable(DataTable dt, clsEntityJournal ObjEntityRequest, string datefrom, string dateto, string Status, string LedgerID, string CnclSts)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,                                                           
                                                      clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,    
                                                              };
        int intCorpId = 0;
        if (ObjEntityRequest.Corp_Id != 0)
        {
            intCorpId = ObjEntityRequest.Corp_Id;
        }

        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        int Decimalcount = 0;
        if (dtCorpDetail.Rows.Count > 0)
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            Decimalcount = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString());
        }
        decimal Total = 0;
        string strRandom = objCommon.Random_Number();
        string FORNULL = "";
        DataTable table = new DataTable();

        table.Columns.Add("JOURNAL LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');

        if (Status == "0")
        {
            table.Rows.Add("STATUS :","Pending", '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else if (Status == "1")
        {
            table.Rows.Add("STATUS :", "Confirmed", '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else if (Status == "2")
        {
            table.Rows.Add("STATUS :", "Reopened", '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        else if (Status == "4")
        {
            table.Rows.Add("STATUS :", "All", '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("REF#", "DATE", "TOTAL AMOUNT", "STATUS");
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString());
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();
                decimal value = 0;
                if (dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString() != "")
                {
                    Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
                    value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["JURNL_TOTAL_AMT"].ToString());
                }
                int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
                string format = String.Format("{{0:N{0}}}", precision);
                string valuestring = String.Format(format, value);
                string strStatus = "";
                if (strCnclSts == "0")
                {
                    if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "1")
                    {
                        strStatus = "Confirmed";
                    }
                    else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0" && dt.Rows[intRowBodyCount]["JURNL_REOPEN_STATUS"].ToString() == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["JURNL_REOPEN_USRID"].ToString() != "")
                        {
                            strStatus = "Reopened";
                        }
                    }
                    else if (dt.Rows[intRowBodyCount]["JURNL_CNFRM_STS"].ToString() == "0")
                    {
                        strStatus = "Pending";
                    }
                }
                table.Rows.Add('"' + dt.Rows[intRowBodyCount]["JURNL_REF"].ToString() + '"', '"' + dt.Rows[intRowBodyCount]["JURNL_DATE"].ToString() + '"', '"' + valuestring + '"', '"' + strStatus + '"');
            }
            if (dt.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + '"', '"' + FORNULL + '"');
            }
        }
        else
        {
            table.Rows.Add("No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }
        return table;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntityJournal ObjEntityRequest, string datefrom, string dateto, string Status, string LedgerID, string CnclSts)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        DataTable dt = GetTable(dtCategory, ObjEntityRequest, datefrom, dateto, Status, LedgerID, CnclSts);
        string strResult = DataTableToCSV(dt, ',');
        string strImagePath = "";
        string filepath = "";
        if (ObjEntityRequest.Corp_Id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityRequest.Corp_Id;
        }
        if (ObjEntityRequest.Org_Id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityRequest.Org_Id;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNALLIST_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/Journal/JounrnalList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "JounrnalList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOURNALLIST_CSV);
        return strImagePath + filepath;
    }
    [WebMethod]
    public static string PrintPDF(string Id, string orgID, string corptID, string UsrName, string DecCnt)
    {
        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
               clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (corptID != null)
        {
            objEntityLayerStock.Corp_Id = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {

            objEntityLayerStock.Org_Id = Convert.ToInt32(orgID);
        }
        objEntityLayerStock.JournalId = Convert.ToInt32(strId);

        DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
        DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
        DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);

        FMS_FMS_Master_fms_Journal_fms_Journal_List objMaster = new FMS_FMS_Master_fms_Journal_fms_Journal_List();

        int Version_flg = 0;

        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.JOURNAL);
            DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

            string strReturn = "";
            if (dtVersion.Rows.Count > 0)
            {
                if (dtVersion.Rows[0][0].ToString() == "1")
                {
                    Version_flg = 1;
                    strReturn = objBusinessLayerStock.PdfPrintVersion1(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);

                    //strReturn = objMaster.PdfPrintVersion1(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);
                }
                else if (dtVersion.Rows[0][0].ToString() == "2")
                {
                    Version_flg = 2;
                    strReturn = objBusinessLayerStock.PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);

                    //strReturn = objMaster.PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);
                }
                else if (dtVersion.Rows[0][0].ToString() == "3")
                {
                    Version_flg = 3;
                    strReturn = objBusinessLayerStock.PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);

                    //strReturn = objMaster.PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);
                }
            }

            return strReturn;

    }
    //public string PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
    //    string strRet = "";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
    //    objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";


    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {
    //        int precision = Convert.ToInt32(DecCnt);
    //        string format = String.Format("{{0:N{0}}}", precision);


    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();
    //            PdfPTable headImg = new PdfPTable(2);

    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                    strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //            }

    //            if (strImageLogo != "")
    //            {
    //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //                image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                image.ScaleToFit(100f, 80f);

    //                headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            var FontColour = new BaseColor(79, 167, 206);

    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            }
    //            float[] headersHeading = { 60, 40 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            FontColour = new BaseColor(0, 174, 239);
    //            footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}


    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            }
    //            document.Add(footrtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            PdfPTable footrtables = new PdfPTable(2);
    //            float[] footrsBodys = { 15, 85 };
    //            footrtables.SetWidths(footrsBodys);
    //            footrtables.WidthPercentage = 100;

    //            footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            document.Add(footrtables);

    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                var FontGray = new BaseColor(138, 138, 138);

    //                PdfPTable table2 = new PdfPTable(4);
    //                float[] tableBody2 = { 40, 20, 20, 20 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;

    //                FontColour = new BaseColor(134, 152, 160);
    //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });


    //                var FontColour_BORDER = new BaseColor(236, 236, 236);
    //                for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                    {
    //                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                    }
    //                    string valuestringAmnt = String.Format(format, decAmnt);

    //                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                }
    //                FontColour = new BaseColor(216, 49, 61);
    //                decimal decTotal = 0;
    //                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
    //                {
    //                    decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
    //                }
    //                string valuestringTot = String.Format(format, decTotal);

    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                {
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                }
    //                string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
    //                FontColour = new BaseColor(0, 174, 239);
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });

    //                document.Add(table2);
    //            }

    //            if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            }

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            float pos1 = writer.GetVerticalPosition(false);

    //            string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();

    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            else
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            }


    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);


    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

    //            // table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);
    //            if (pos1 > 141)
    //            {
    //                table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
    //            }
    //            else
    //            {
    //                document.NewPage();
    //                table3.WriteSelectedRows(0, -1, 0, 140, writer.DirectContent);
    //            }

    //            document.Close();
    //        }

    //        //    Response.Write("<script>window.open('" + strImagePath + strImageName + "','_blank');</script>");
    //        strRet = strImagePath + strImageName;
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }

    //    return strRet;


    //}
    //public string PdfPrintVersion2(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
    //    clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
    //    string strRet = "";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
    //    objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";
    //    DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);


    //    Document document = new Document(PageSize.A4.Rotate(), 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {
    //        int precision = Convert.ToInt32(DecCnt);
    //        string format = String.Format("{{0:N{0}}}", precision);

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            if (Version_flg == 2)
    //            {
    //                PdfPTable headImg = new PdfPTable(2);

    //                if (strImageLogo != "")
    //                {


    //                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));

    //                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                    image.ScaleToFit(100f, 80f);

    //                    headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //                }
    //                else
    //                {
    //                    headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //                }

    //                headImg.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 16, Font.BOLD))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT });

    //                var FontGrey = new BaseColor(134, 152, 160);

    //                float[] headersHeading = { 70, 30 };
    //                headImg.SetWidths(headersHeading);
    //                headImg.WidthPercentage = 100;

    //                document.Add(headImg);

    //            }

    //            else
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }


    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;

    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_LEFT });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_LEFT });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }

    //            footrtable.AddCell(new PdfPCell(new Phrase("Date : ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //PdfPTable footrtables = new PdfPTable(2);
    //            //float[] footrsBodys = { 15, 85 };
    //            //footrtables.SetWidths(footrsBodys);
    //            //footrtables.WidthPercentage = 100;

    //            footrtable.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //      document.Add(footrtables);

    //            document.Add(footrtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //            var FontRed = new BaseColor(202, 3, 20);
    //            var FontGreen = new BaseColor(46, 179, 51);
    //            var FontGray = new BaseColor(138, 138, 138);

    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                // var FontGray = new BaseColor(138, 138, 138);

    //                PdfPTable table2 = new PdfPTable(8);
    //                float[] tableBody2 = { 18, 12, 12, 13, 12, 12, 12, 14 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;
    //                var FontColour = new BaseColor(134, 152, 160);

    //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("COST-G1", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("COST-G2", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("CC AMT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });


    //                var FontColour_BORDER = new BaseColor(236, 236, 236);
    //                int FLG = 0;
    //                int cstcntrSts = 0;
    //                for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                    DataTable dtCostCntrDebDtl = new DataTable();

    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString() != "")
    //                    {
    //                        objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString());
    //                        dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);

    //                    }

    //                    if (dtCostCntrDebDtl.Rows.Count > 0)
    //                    {
    //                        FLG = 0;

    //                        decimal CstAmmount = 0;
    //                        for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
    //                        {

    //                            decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
    //                            string valuestringCost = String.Format(format, costAmnt);


    //                            if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
    //                            {
    //                                string costGrp1 = dtCostCntrDebDtl.Rows[j]["COSTCNTR_NAME"].ToString();
    //                                string costGrp2 = dtCostCntrDebDtl.Rows[j]["GRP_NAME_ONE"].ToString();
    //                                string costCntr = dtCostCntrDebDtl.Rows[j]["GRP_NAME_TWO"].ToString();
    //                                decimal DecCstAmt = 0;
    //                                if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString() != "")
    //                                {
    //                                    DecCstAmt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());
    //                                }
    //                                string valuestringCstAmnt = String.Format(format, DecCstAmt);


    //                                CstAmmount = CstAmmount + Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());



    //                                if (FLG == 0)
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                                    {
    //                                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                                    }
    //                                    string valuestringAmnt = String.Format(format, decAmnt);

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }
    //                                    else
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }
    //                                    else
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }

    //                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                                }
    //                                else
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                }
    //                                table2.AddCell(new PdfPCell(new Phrase(costGrp1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(costGrp2, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(costCntr, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringCstAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                FLG = 1;
    //                            }
    //                            else
    //                            {
    //                                cstcntrSts = 1;
    //                            }


    //                        }

    //                        if (FLG == 1)
    //                        {
    //                            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                            {
    //                                objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                            }
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });

    //                            table2.AddCell(new PdfPCell(new Phrase("CC-TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 3 });


    //                            string CstCntrTotalDec = String.Format(format, CstAmmount);


    //                            table2.AddCell(new PdfPCell(new Phrase(CstCntrTotalDec, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });



    //                        }

    //                        if (FLG == 0)
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                            {
    //                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                            }
    //                            string valuestringAmnt = String.Format(format, decAmnt);

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }
    //                            else
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }
    //                            else
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }

    //                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        }

    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                        {
    //                            decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                        }
    //                        string valuestringAmnt = String.Format(format, decAmnt);

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }
    //                        else
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }
    //                        else
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }

    //                        table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    }
    //                }

    //                decimal decTotal = 0;
    //                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
    //                {
    //                    decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
    //                }
    //                string valuestringTot = String.Format(format, decTotal);

    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                {
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                }
    //                string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));

    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 8 });

    //                document.Add(table2);
    //            }


    //            if (Version_flg == 2)
    //            {



    //                if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
    //                {
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                }

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }
    //            float pos1 = writer.GetVerticalPosition(false);

    //            var phrase2 = new Phrase();
    //            var phrase5 = new Phrase();
    //            var FontBlack = new BaseColor(8, 7, 7);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();

    //            PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;

    //            table3.TotalWidth = 700F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            else
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            //table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            //table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });




    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });


    //            if (pos1 > 96)
    //            {
    //                table3.WriteSelectedRows(0, -1, 65, 95, writer.DirectContent);
    //            }
    //            else
    //            {
    //                //document.NewPage();
    //                table3.WriteSelectedRows(0, -1, 65, 95, writer.DirectContent);
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
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ReopenReceiptDetails(string strmemotId, string strUserID, string strOrgIdID, string strCorpID)
    {
        FMS_FMS_Master_fms_Journal_fms_Journal_List objPage = new FMS_FMS_Master_fms_Journal_fms_Journal_List();
        string[] strRets = new string[3];
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityJournal ObjEntityRequest = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
        List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();
        strRets[0] = "successReopen";
        string NewRev = "";
        try
        {
            string strRandomMixedId = strmemotId;
            string id = strRandomMixedId;
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityRequest.JournalId = Convert.ToInt32(strId);
            ObjEntityRequest.Org_Id = Convert.ToInt32(strOrgIdID);
            ObjEntityRequest.Corp_Id = Convert.ToInt32(strCorpID);
            ObjEntityRequest.User_Id = Convert.ToInt32(strUserID);

            DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(ObjEntityRequest);
            for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
            {
                clsEntityJournalLedgerDtl objEntityJrnlLedgrSubList = new clsEntityJournalLedgerDtl();
                if (dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() != "")
                {
                    objEntityJrnlLedgrSubList.LedgerId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString());
                }
                if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() != "")
                {
                    objEntityJrnlLedgrSubList.TabMode = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString());
                }
                if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString() != "")
                {
                    objEntityJrnlLedgrSubList.LedgerTotAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                    objEntityJrnlLedgrSubList.ExchangeRate = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                }
                if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() != "")
                {
                    objEntityJrnlLedgrSubList.MainTabId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());

                    ObjEntityRequest.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                }
                objEntityJrnlLedgrList.Add(objEntityJrnlLedgrSubList);

                DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(ObjEntityRequest);
                for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                {
                    clsEntityJournalCostCntrDtl objEntitySubCostCntrDtl = new clsEntityJournalCostCntrDtl();
                    if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                    {
                        objEntitySubCostCntrDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString());
                    }
                    else if (dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() != "")
                    {
                        objEntitySubCostCntrDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString());
                    }
                    else if (dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() != "")
                    {
                        objEntitySubCostCntrDtl.PurSaleRefNum = "Deb";
                        objEntitySubCostCntrDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString());
                    }
                    if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString() != "")
                    {
                        objEntitySubCostCntrDtl.CostCntrAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                        objEntitySubCostCntrDtl.ExchangeRate = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                    }
                    if (dtCostCntrDebDtl.Rows[j]["LD_JURNL_ID"].ToString() != "")
                    {
                        objEntitySubCostCntrDtl.MainTabId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["LD_JURNL_ID"].ToString());
                    }
                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() != "")
                    {
                        objEntitySubCostCntrDtl.TabMode = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString());
                    }
                    objEntityJrnlCostcentrList.Add(objEntitySubCostCntrDtl);
                }
            }

            ObjEntityRequest.JournalId = Convert.ToInt32(strId);
            objBusinessLayerStock.ReopenJournalDtls(ObjEntityRequest, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objentcommn = new clsEntityCommon();
            clsEntityJournal objEntitySupplier = new clsEntityJournal();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            intUserId = Convert.ToInt32(strUserID);
            objEntitySupplier.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            objEntitySupplier.Corp_Id = intCorpId;
            objentcommn.CorporateID = intCorpId;

            intOrgId = Convert.ToInt32(strOrgIdID);
            objEntitySupplier.Org_Id = intOrgId;
            objentcommn.Organisation_Id = intOrgId;

            if (strCnclSts == "1")
            {
                objEntitySupplier.ConfirmSts = 1;
            }
            else
            {
                objEntitySupplier.ConfirmSts = 0;
            }
            objEntitySupplier.FromDate = objCommon.textToDateTime(strFromDate);
            objEntitySupplier.JournalDate = objCommon.textToDateTime(strToDate);
            objEntitySupplier.JrnltSts = Convert.ToInt32(strStatus);

            DataTable dtList = objBusinessLayerStock.ReadJournlList(objEntitySupplier);
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intConfirm = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }
            strRets[1] = objPage.ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intConfirm);
            //strRets[2] = objPage.ConvertDataTableToPrint(dtList, intUpdate, intEnableCancel, intConfirm);

            //End:-For datatable

        }
        catch
        {
            strRets[0] = "failed";

        }
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        return strRets;
    }
    [WebMethod]
    public static string CheckSaleSettlement(string strPayemntId, string strOrgIdID, string strCorpID)
    {
        //EVM-0020
        string ret = "successConfirm";

        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();

        List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
        List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        objEntityLayerStock.Org_Id = Convert.ToInt32(strOrgIdID);
        objEntityLayerStock.Corp_Id = Convert.ToInt32(strCorpID);

        objEntityLayerStock.JournalId = Convert.ToInt32(strId);
        objEntityLayerStock.ConfirmSts = 1;

        int CntExceed = 0;

        DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
        for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
        {
            objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());

            DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
            for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
            {
                clsEntityJournalCostCntrDtl objEntityCstDtl = new clsEntityJournalCostCntrDtl();

                if (dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() != "")
                {
                    objEntityCstDtl.PurSaleRefNum = "Cre";
                    objEntityCstDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString());
                    objEntityCstDtl.SettlmntAmmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["BALNC_AMT"].ToString());
                    if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString() != "")
                    {
                        objEntityCstDtl.CostCntrAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                    }

                    DataTable dtSalesBalance = objBusinessLayerStock.ReadSalesBalance(objEntityLayerStock, objEntityCstDtl);
                    decimal decSalesRemainAmt = 0;
                    if (dtSalesBalance.Rows.Count > 0)
                    {
                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                    }
                    if (decSalesRemainAmt != 0)
                    {
                        if (decSalesRemainAmt < objEntityCstDtl.CostCntrAmnt)
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
                else if (dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() != "")
                {
                    objEntityCstDtl.PurSaleRefNum = "Deb";
                    objEntityCstDtl.CostCenterId = Convert.ToInt32(dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString());
                    objEntityCstDtl.SettlmntAmmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["PURCHS_BAL_AMT"].ToString());
                    if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString() != "")
                    {
                        objEntityCstDtl.CostCntrAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                    }

                    DataTable dtSalesBalance = objBusinessLayerStock.ReadPurchaseBalance(objEntityLayerStock, objEntityCstDtl);
                    decimal decSalesRemainAmt = 0;
                    if (dtSalesBalance.Rows.Count > 0)
                    {
                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                    }
                    if (decSalesRemainAmt != 0)
                    {
                        if (decSalesRemainAmt < objEntityCstDtl.CostCntrAmnt)
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
        }

        return ret;
    }
}