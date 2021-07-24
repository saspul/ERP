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
public partial class FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List : System.Web.UI.Page
{

    int intAccntCloseReopen = 0;
    int intReopen = 0;
    static string strFromDate = "";
    static string strToDate = "";
    static string strStatus = "";
    static string strCnclSts = "";
    static string strHiddenProvisionSts = "0";
    static string strHiddenReopenProvision = "0";
    static string strHiddenAuditProvision = "0";
    static string strHiddenConfirmProvision = "0";
    static string strHiddenFieldDecimalCnt = "0";
    static string strHiddenCurrencyAbrv = "";
    protected void Page_Load(object sender, EventArgs e)
    {
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
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntCommn = new clsEntityCommon();

            clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
            cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
            int intUserId = 0, intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                objEntCommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntCommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
                intUserId = ObjEntityCredit.User_Id;
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenConfirmProvision.Value = "0";
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
                        HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenProvisionSts.Value = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                        strHiddenProvisionSts = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        HiddenReopenProvision.Value = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                        strHiddenReopenProvision = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenAuditProvision.Value = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                        strHiddenAuditProvision = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenConfirmProvision.Value = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
                        strHiddenConfirmProvision = Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString();
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
            ObjEntityCredit.Date_From = DateTime.MinValue; ;
            ObjEntityCredit.Date_To = DateTime.MinValue;

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (Session["FINCYRID"] != null)
            {
                objEntCommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntCommn);
            if (dtfinaclYear.Rows.Count > 0)
            {
                ObjEntityCredit.Date_From = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                ObjEntityCredit.Date_To = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());
                HiddenFinancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                HiddenFnancialEndDeate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

      
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
                ObjEntityCredit.Date_From = objCommon.textToDateTime(txtDateFrom.Value);
            if (txtDateTo.Value != "")
                ObjEntityCredit.Date_To = objCommon.textToDateTime(txtDateTo.Value);
            ObjEntityCredit.Status = Convert.ToInt32(ddlPurchaseStatus.SelectedItem.Value);

            strFromDate = txtDateFrom.Value;
            strToDate = txtDateTo.Value;
            strStatus = ddlPurchaseStatus.SelectedItem.Value;
            if (CbxCnclStatus.Checked == true)
            {
                strCnclSts = "1";
            }
            else
            {
                strCnclSts = "0";
            }

            DataTable dtList = objBussinessCredit.ReadCreditNoteList(ObjEntityCredit);
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
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                strHiddenFieldDecimalCnt = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                HiddenCurrencyAbrv.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                strHiddenCurrencyAbrv = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intReopen, intAccntCloseReopen);
            divPrintReport.InnerHtml = ConvertDataTableToPrint(dtList);

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
                else if (Request.QueryString["InsUpd"] == "AcntClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AcntClosed", "AcntClosed();", true);
                }
                if (Request.QueryString["InsUpd"] == "Confrm")
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
                else if (Request.QueryString["InsUpd"] == "AuditClosed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AuditClosed", "AuditClosed();", true);
                }
            }
            divPrintCaption.InnerHtml = PrintCaption(ObjEntityCredit);
        }
    }

    public string ConvertDataTableToHTML(DataTable dt, int intUpdate, int intEnableCancel, int intReopen, int intAccntCloseReopen)
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
        //add header row
        strHtml += "<thead class=\"thead1\">";
        
        strHtml += "<tr >";


        for (int intColumnHeaderCount = 0; intColumnHeaderCount < 6; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 0)
            {
                //strHtml += "<th class=\"hasinput\" >REFERENCE NUMBER";
                //strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"REFERENCE NUMBER\" style=\"text-align:left;\" type=\"text\">";
                //strHtml += "</th >";
                strHtml += "<th class=\"col-md-4 tr_l\">REF#";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"REFERENCE NUMBER\" type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 1)
            {
                //strHtml += "<th class=\"hasinput\" style=\"width:20%;text-align:center;\">DATE";
                //strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"DATE\" style=\"text-align:center;\" type=\"text\">";
                //strHtml += "</th >";
                strHtml += "<th class=\"col-md-2\">DATE";
                strHtml += " <i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"DATE\"  type=\"text\">";
                strHtml += "</th >";
            }
            else if (intColumnHeaderCount == 2)
            {
                //strHtml += "<th class=\"hasinput\" style=\"width:25%;text-align:right;\">TOTAL AMOUNT";
                //strHtml += "<input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"form-control\" placeholder=\"TOTAL AMOUNT\" style=\"text-align:right;\" type=\"text\">";
                //strHtml += "</th >";
                //strHtml += "<th class=\"thT\" style=\"display:none;\"> ";
                //strHtml += "</th >";
                strHtml += "<th class=\"col-md-2 tr_r\">TOTAL AMOUNT";
                strHtml += "<i class=\"fa fa-sort pull-right hed_fa\" aria-hidden=\"true\"></i><br><input onkeypress=\"return DisableEnter(event)\" onkeydown=\"return DisableEnter(event)\" class=\"tb_inp_1 tb_in tr_c \" placeholder=\"TOTAL AMOUNT\" type=\"text\">";
                strHtml += "</th >";
                strHtml += "<th class=\"thT\"> ";
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
                    strHtml += "<th class=\"col-md-1\"> STATUS";
                    strHtml += "</th >";
                }
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"col-md-4\" > Actions";
                strHtml += "</th >";
              
            }
        }

      
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {

            int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString());
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString();

            decimal value = 0;
            if (dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() != "")
            {
                value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
            }
            int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, value);
          //  valuestring = valuestring + " " + strHiddenCurrencyAbrv;
            for (int intColumnBodyCount = 0; intColumnBodyCount < 6; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 0)
                {

                    strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["DR_NOTE_REF"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 1)
                {
                    objEntityAudit.FromDate = objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString());
                    strHtml += "<td> " + dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
                    strHtml += "<td class=\"tr_r\" > " + valuestring + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";// EVM-0024
                    strHtml += "<td class=\"tr_r\"  > " + dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td > " + dt.Rows[intRowBodyCount]["DR_REF_SEQNUM"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                   
                    if (strCnclSts == "0")
                    {
                        if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                        {
                            strHtml += "<td>Confirmed </td>";

                        }
                        else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0" && dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_STATUS"].ToString() == "1")
                        {
                            if (dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_USRID"].ToString() != "")
                            {
                                strHtml += "<td> Reopened</td>";
                            }
                        }
                        else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0")
                        {
                            strHtml += "<td> Pending</td>";
                        }

                    }
                }
                else if (intColumnBodyCount == 5)
                {
                 DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                 strHtml += " <td>";
                    if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {
                                if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                                {
                                    strHtml += " <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Debit_Note.aspx?Id=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                                }
                                else
                                {
                                    if (dtAuditClsDate.Rows.Count > 0)
                                    {

                                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                        {

                                            if (strHiddenAuditProvision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                            {
                                                strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                    " href=\"fms_Debit_Note.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";

                                            }
                                            else
                                            {
                                                strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Debit_Note.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                    " href=\"fms_Debit_Note.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";

                                        }

                                    }

                                    else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                    {
                                        if (intAccntCloseReopen == 1)
                                        {
                                            strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                     " href=\"fms_Debit_Note.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                                        }
                                        else
                                        {
                                            strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                                  " href=\"fms_Debit_Note.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn1\" title=\"Edit\" onclick='return getdetails(this.href);' " +
                                                   " href=\"fms_Debit_Note.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\" ></i></a>";
                                    }
                                }

                            }
                            else
                            {
                                strHtml += "  <a style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                            " href=\"fms_Debit_Note.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a>";
                            }

                        }

                    }
                    if (strHiddenConfirmProvision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                    {

                                        if (strHiddenAuditProvision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            if (strCancTransaction == "0")
                                            {
                                                strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                            }

                                            else
                                            {
                                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        if (strCancTransaction == "0")
                                        {
                                            strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                        }

                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }

                                }

                                else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                {
                                    if (intAccntCloseReopen == 1)
                                    {
                                        if (strCancTransaction == "0")
                                        {
                                            strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                        }

                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                                    }
                                }
                                else
                                {
                                    if (strCancTransaction == "0")
                                    {
                                        strHtml += "<a  href=\"javascript:;\"  style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                    }

                                    else
                                    {
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";

                                    }
                                }
                            }
                            else
                            {
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" href=\"javascript:;\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                            }
                        }

                    }
                    if (strHiddenReopenProvision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        if (strCnclSts == "0")
                        {
                            if (YearEndCls == 0)
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                    {

                                        if (strHiddenAuditProvision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            if (strCancTransaction == "1")
                                            {
                                                //    strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                                if (Convert.ToInt32(dt.Rows[intRowBodyCount]["VOCHR_SETL_ID"].ToString()) > 0)
                                                    strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                                else
                                                    strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";


                                            }

                                            else
                                            {
                                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        if (strCancTransaction == "1")
                                        {
                                            //strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                            if (Convert.ToInt32(dt.Rows[intRowBodyCount]["VOCHR_SETL_ID"].ToString()) > 0)
                                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                            else
                                                strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";


                                        }

                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }

                                }

                                else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                {
                                    if (intAccntCloseReopen == 1)
                                    {
                                        if (strCancTransaction == "1")
                                        {
                                            //  strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                            if (Convert.ToInt32(dt.Rows[intRowBodyCount]["VOCHR_SETL_ID"].ToString()) > 0)
                                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                            else
                                                strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";


                                        }

                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                    }
                                }

                                else
                                {
                                    if (strCancTransaction == "1")
                                    {
                                        // strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                        if (Convert.ToInt32(dt.Rows[intRowBodyCount]["VOCHR_SETL_ID"].ToString()) != 0)
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                        }
                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";
                                    }
                                }
                            }
                            else
                            {
                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Reopen\" href=\"javascript:;\"><i class=\"fa fa-unlock\" style=\"cursor: pointer;\"></i></a>";

                            }

                        }
                    }
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (YearEndCls == 0)
                        {
                            if (strCnclSts == "0")
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                    {

                                        if (strHiddenAuditProvision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            if (strCancTransaction == "0")
                                            {
                                                strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                            }

                                            else
                                            {
                                                strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        if (strCancTransaction == "0")
                                        {
                                            strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                        }

                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }

                                }

                                else if (acntClsDate >= objCommon.textToDateTime(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString()))
                                {
                                    if (intAccntCloseReopen == 1)
                                    {
                                        if (strCancTransaction == "0")
                                        {
                                            strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                        }

                                        else
                                        {
                                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                                    }
                                }
                                else
                                {
                                    if (strCancTransaction == "0")
                                    {
                                        strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                    }

                                    else
                                    {
                                        strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";

                                    }
                                }
                            }
                        }
                        else
                        {
                            strHtml += "<a  href=\"javascript:;\" disabled=\"true\"; style=\"opacity: .4;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelBlock();\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a>";
                        }
                    }

                    if (strCnclSts == "0")
                    {
                        strHtml += " <a class=\"btn act_btn bn6 \" title=\"Print Voucher\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\" ></i></a>";
                    }

              
                
                    if (strCnclSts == "1")
                    {
                        strHtml += "  <a style=\"opacity: 1;\" class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' " +
                                     " href=\"fms_Debit_Note.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\" ></i></a></td>";
                    }
                    strHtml += " </td>";
                }

            }

            strHtml += "</tr>";
        }

        strHtml += "</tbody>";
        if (dt.Rows.Count > 0)
        {
            strHtml += " <tfoot> <tr class=\"tr1\">";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" >TOTAL </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\"  style=\"text-align:right;\"> " + objBusinessLayer.AddCommasForNumberSeperation(Total.ToString(), objentcommn) + " " + strHiddenCurrencyAbrv + "</th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
           
            strHtml += "<th class=\"tr_r bg1 txt_rd\" style=\"text-align:left !important;\" > </th>";
            strHtml += "</tr></tfoot>";
        }
        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToPrint(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        String Status = "";
        int intOrgId = 0;
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
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
            int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString());
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();
            decimal value = 0;
            if (dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() != "")
            {
                value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
            }
            int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, value);
           // valuestring = valuestring + " " + strHiddenCurrencyAbrv;
            strHtml += "<td class=\"tdT\" style=\" width:35%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["DR_NOTE_REF"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\" > " + dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString() + "</td>";
            strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: right;\" > " + valuestring + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
            if (strCnclSts == "0")
            {
                if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Confirmed </td>";
                }
                else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0" && dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_STATUS"].ToString() == "1")
                {
                    if (dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_USRID"].ToString() != "")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" > Reopened</td>";
                    }
                }
                else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0")
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
    public string ConvertDataTableToPrint_PDF(DataTable dt,string fromDate,string  toDate,string  Status,string  LedgerID,string CnclSts)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        string strRandom = objCommon.Random_Number();
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            //objentcommn.CorporateID = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        decimal Total = 0;
        string strRet = "";
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.TRANSACTION_PDF);
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBITNOTE_PDF);
        string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "DebitNoteList_" + strNextNumber + ".pdf";

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
                footrtable.AddCell(new PdfPCell(new Phrase("DEBIT NOTE STATUS  ", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2 });
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
                float[] footrsBody = { 35, 15, 35, 15 };
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
                        int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString());
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;
                        string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();
                        decimal value = 0;
                        if (dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() != "")
                        {
                            Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
                            value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
                        }
                        int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
                        string format = String.Format("{{0:N{0}}}", precision);
                        string valuestring = String.Format(format, value);
                        // valuestring = valuestring + " " + strHiddenCurrencyAbrv;
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["DR_NOTE_REF"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(valuestring + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString(), FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                        if (strCnclSts == "0")
                        {
                            if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Confirmed", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                            else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0" && dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_STATUS"].ToString() == "1")
                            {
                                if (dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_USRID"].ToString() != "")
                                {
                                    TBCustomer.AddCell(new PdfPCell(new Phrase("Reopened", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                                }
                            }
                            else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0")
                            {
                                TBCustomer.AddCell(new PdfPCell(new Phrase("Pending", FontFactory.GetFont("Calibri", 8, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                            }
                        }
                    }
                    if (dt.Rows.Count > 0)
                    {
                        TBCustomer.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
                        TBCustomer.AddCell(new PdfPCell(new Phrase(objBusinessLayer.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + strHiddenCurrencyAbrv, FontFactory.GetFont("Calibri", 8, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontSmallGray, BorderColor = FontGray });
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
            headtable.AddCell(new PdfPCell(new Phrase("DEBIT NOTE LIST ", new Font(FontFactory.GetFont("Calibri", 9, Font.BOLD, BaseColor.BLACK)))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT });
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
    public static string[] CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn , string strCorpID,string strOrgIdID)
    {
        string[] strRets = new string[3];
        FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List objPage = new FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List();


        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityCredit.Debit_Id = Convert.ToInt32(strId);
        ObjEntityCredit.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            ObjEntityCredit.CancelReason = cnclRsn;
        }

        else
        {
            ObjEntityCredit.CancelReason = objCommon.CancelReason();
        }

        try
        {
            DataTable dt = objBussinessCredit.CheckCreditNoteCnclSts(ObjEntityCredit);
            if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
            {
                objBussinessCredit.CancelCreditNote(ObjEntityCredit);
            }
            else if (dt.Rows[0][0].ToString() != "")
            {
                strRets[0] = "UpdCancl";
            }
            else
            {
                strRets[0] = "CnfCancl";
            }


            ObjEntityCredit = new clsEntity_Debit_Note();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

                intUserId = Convert.ToInt32(usrId);
                ObjEntityCredit.User_Id = intUserId;

                intCorpId = Convert.ToInt32(strCorpID);
                ObjEntityCredit.Corporate_id = intCorpId;

                intOrgId = Convert.ToInt32(strOrgIdID);
                ObjEntityCredit.Organisation_id = intOrgId;


                ObjEntityCredit.ConfirmStatus = Convert.ToInt32(strCnclSts);

                ObjEntityCredit.Date_From = objCommon.textToDateTime(strFromDate);
                ObjEntityCredit.Date_To = objCommon.textToDateTime(strToDate);
                ObjEntityCredit.Status = Convert.ToInt32(strStatus);


            DataTable dtList = objBussinessCredit.ReadCreditNoteList(ObjEntityCredit);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        objPage.intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        objPage.intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                }
            }
            strRets[1] = objPage.ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, objPage.intReopen, objPage.intAccntCloseReopen);
            strRets[2] = objPage.ConvertDataTableToPrint(dtList);

        }
        catch
        {
            strRets[0] = "failed";
        }
        return strRets;
    }
    public int AccountCloseCheck(string strDate)
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
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ReopenReceiptDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID)
    {
        string[] strRets = new string[3];
        FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List objPage = new FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List();

        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        List<clsEntity_Debit_Note> objEntityLedger = new List<clsEntity_Debit_Note>();
        List<clsEntity_Debit_Note> objEntityLedgerCostCenter = new List<clsEntity_Debit_Note>();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successReopen";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityCredit.Debit_Id = Convert.ToInt32(strId);
        ObjEntityCredit.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityCredit.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityCredit.User_Id = Convert.ToInt32(strUserID);
        try
        {
            DataTable dtLDGRdTLS = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);

            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
            {
                clsEntity_Debit_Note ObjSubEntityRequestCostAndPurchase = new clsEntity_Debit_Note();
                clsEntity_Debit_Note ObjSubEntityRequest = new clsEntity_Debit_Note();
                if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())) && dtLDGRdTLS.Rows[intCount]["LDGR_DR_AMT"].ToString() != "")
                {
                    if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())))
                    {
                        ObjSubEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                        NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                    }
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequest.Ledger_Debit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_DR_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequest.Ledger_Amount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["LDGR_DR_AMT"].ToString());
                    }
                    objEntityLedger.Add(ObjSubEntityRequest);
                }
                if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_ID"].ToString() != "")
                {
                    if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.Cost_Centre_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.Cost_Centre_Debit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.Cost_Centre_Amt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString());
                    }
                    objEntityLedgerCostCenter.Add(ObjSubEntityRequestCostAndPurchase);
                }
            }
            objBussinessCredit.CreditNoteReOpenById(ObjEntityCredit, objEntityLedger, objEntityLedgerCostCenter);


            ObjEntityCredit = new clsEntity_Debit_Note();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            intUserId = Convert.ToInt32(strUserID);
            ObjEntityCredit.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            ObjEntityCredit.Corporate_id = intCorpId;

            intOrgId = Convert.ToInt32(strOrgIdID);
            ObjEntityCredit.Organisation_id = intOrgId;

           // if (strCnclSts != "")
                ObjEntityCredit.ConfirmStatus = Convert.ToInt32(strCnclSts);

            ObjEntityCredit.Date_From = objCommon.textToDateTime(strFromDate);
            ObjEntityCredit.Date_To = objCommon.textToDateTime(strToDate);
            ObjEntityCredit.Status = Convert.ToInt32(strStatus);


            DataTable dtList = objBussinessCredit.ReadCreditNoteList(ObjEntityCredit);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        objPage.intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        objPage.intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                }
            }
            strRets[1] = objPage.ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, objPage.intReopen, objPage.intAccntCloseReopen);
            strRets[2] = objPage.ConvertDataTableToPrint(dtList);
        }
        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        return strRets;

    }
    [WebMethod]
    public static string ListPrint_PDF(string FINCYRID, string orgID, string corptID, string DecCnt, string CnclSts, string fromDate, string toDate, string Status, string LedgerID, string strPrintMode)
    {
        string strReturn = "";
        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List OBJ = new FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List();
        if (corptID != "")
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(corptID);
        }

        if (orgID != "")
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(orgID);
        }
        if (CnclSts == "1")
        {
            ObjEntityCredit.ConfirmStatus = 1;
            strCnclSts = "1";
        }
        else
        {
            ObjEntityCredit.ConfirmStatus = 0;
            strCnclSts = "0";
        }
       
        ObjEntityCredit.Date_From = objCommon.textToDateTime(fromDate);
        ObjEntityCredit.Date_To = objCommon.textToDateTime(toDate);
        ObjEntityCredit.Status = Convert.ToInt32(Status);
        DataTable dtList = objBussinessCredit.ReadCreditNoteList(ObjEntityCredit);
        if (strPrintMode == "pdf")
        {
            strReturn = OBJ.ConvertDataTableToPrint_PDF(dtList, fromDate, toDate, Status, LedgerID, CnclSts);
        }
        else if ((strPrintMode == "csv"))
        {
            strReturn = OBJ.LoadTable_CSV(dtList,ObjEntityCredit, fromDate, toDate, Status, LedgerID, CnclSts);
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
    public DataTable GetTable(DataTable dt, clsEntity_Debit_Note ObjEntityRequest, string datefrom, string dateto, string Status, string LedgerID, string CnclSts)
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

        table.Columns.Add("DEBIT NOTE LIST", typeof(string));
        table.Columns.Add(" ", typeof(string));
        table.Columns.Add("  ", typeof(string));
        table.Columns.Add("   ", typeof(string));
        table.Rows.Add('"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("FROM DATE :", '"' + datefrom + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        table.Rows.Add("TO DATE :", '"' + dateto + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        if (Status == "0")
        {
            table.Rows.Add("STATUS :", "Pending", '"' + FORNULL + '"', '"' + FORNULL + '"');
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

        string strRandom = objCommon.Random_Number();
        decimal Total = 0;
        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int AcntClsSts = AccountCloseCheck(dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString());
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strCancTransaction = dt.Rows[intRowBodyCount][4].ToString();
                decimal value = 0;
                if (dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString() != "")
                {
                    Total = Total + Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
                    value = Convert.ToDecimal(dt.Rows[intRowBodyCount]["DR_NOTE_TOTAL"].ToString());
                }
                int precision = Convert.ToInt32(strHiddenFieldDecimalCnt);
                string format = String.Format("{{0:N{0}}}", precision);
                string valuestring = String.Format(format, value);
                string strStatus = "";
                if (strCnclSts == "0")
                {
                    if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                    {
                        strStatus = "Confirmed";
                    }
                    else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0" && dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_STATUS"].ToString() == "1")
                    {
                        if (dt.Rows[intRowBodyCount]["DR_NOTE_REOPEN_USRID"].ToString() != "")
                        {
                            strStatus = "Reopened";
                        }
                    }
                    else if (dt.Rows[intRowBodyCount]["DR_NOTE_CONFIRM_STATUS"].ToString() == "0")
                    {
                        strStatus = "Pending";
                    }
                }
                table.Rows.Add('"' + dt.Rows[intRowBodyCount]["DR_NOTE_REF"].ToString() + '"', '"' + dt.Rows[intRowBodyCount]["DR_NOTE_DATE"].ToString() + '"', '"' + valuestring + "  " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + '"', '"' + strStatus + '"');

            }

            if (dt.Rows.Count > 0)
            {
                table.Rows.Add("TOTAL", '"' + FORNULL + '"', '"' + objBusiness.AddCommasForNumberSeperation(Total.ToString(), objEntityCommon) + " " + strHiddenCurrencyAbrv + "  " + FORNULL + '"');
            }
        }
        else
        {
            table.Rows.Add("No data available in table", '"' + FORNULL + '"', '"' + FORNULL + '"', '"' + FORNULL + '"');
        }

       
        return table;
    }
    public string LoadTable_CSV(DataTable dtCategory, clsEntity_Debit_Note ObjEntityRequest, string datefrom, string dateto, string Status, string LedgerID, string CnclSts)
    {
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        DataTable dt = GetTable(dtCategory, ObjEntityRequest, datefrom, dateto, Status, LedgerID, CnclSts);
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


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBITNOTELIST_CSV);
        string strNextId = objBusiness.ReadNextNumberWebForUI(objEntityCommon);
        string newFilePath = Server.MapPath("/CustomFiles/FMS CSV/DebitNote/DebitNoteList_" + strNextId + ".csv");
        System.IO.File.WriteAllText(newFilePath, strResult);
        filepath = "DebitNoteList_" + strNextId + ".csv";
        strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEBITNOTELIST_CSV);
        return strImagePath + filepath;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityCredit.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityCredit.Corporate_id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityCredit.Organisation_id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (CbxCnclStatus.Checked == true)
        {
            ObjEntityCredit.ConfirmStatus = 1;
            strCnclSts = "1";
        }
        else
        {
            ObjEntityCredit.ConfirmStatus = 0;
            strCnclSts = "0";
        }
        ObjEntityCredit.Date_From = objCommon.textToDateTime(txtDateFrom.Value);
        ObjEntityCredit.Date_To = objCommon.textToDateTime(txtDateTo.Value);
        ObjEntityCredit.Status = Convert.ToInt32(ddlPurchaseStatus.SelectedItem.Value);

        strFromDate =txtDateFrom.Value;
        strToDate = txtDateTo.Value; ;
        strStatus = ddlPurchaseStatus.SelectedItem.Value;

        strHiddenProvisionSts =HiddenProvisionSts.Value;
        strHiddenReopenProvision =HiddenReopenProvision.Value;
        strHiddenAuditProvision = HiddenAuditProvision.Value;
        strHiddenConfirmProvision = HiddenConfirmProvision.Value;
        strHiddenFieldDecimalCnt = HiddenFieldDecimalCnt.Value;
        strHiddenCurrencyAbrv = HiddenCurrencyAbrv.Value;


        DataTable dtList = objBussinessCredit.ReadCreditNoteList(ObjEntityCredit);
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                    HiddenRoleEdit.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenEnableCancl.Value = Convert.ToString(clsCommonLibrary.StatusAll.Active);
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                {
                    intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenProvisionSts.Value = "1";
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
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
        divList.InnerHtml = ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, intReopen, intAccntCloseReopen);
        divPrintReport.InnerHtml = ConvertDataTableToPrint(dtList);
        
    }
    [WebMethod]
    public static string PrintPDF(string Id, string orgID, string corptID, string UsrName, string DecCnt, string crncyId)
    {
        string strRandomMixedId = Id;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (corptID != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            ObjEntityCredit.Corporate_id = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(orgID);
            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        }
        ObjEntityCredit.Debit_Id = Convert.ToInt32(strId);

        DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
        DataTable dtCredit = objBussinessCredit.ReadCreditNote_Debit(ObjEntityCredit);


        DataTable dtDebit = objBussinessCredit.ReadCreditNote_Credit(ObjEntityCredit);
        DataTable dtCorp = objBussinessCredit.ReadCorpDtls(ObjEntityCredit);

        FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List objPage = new FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List();
        //return objPage.PdfPrint(strId, dt, dtCredit, dtDebit, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit);
        int Version_flg = 0;
        string strReturn = "";
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.DEBITNOTE);

        DataTable dtinvoiceDtls = new DataTable();
        if (dtCredit.Rows.Count > 0)
        {
            if (dtCredit.Rows[0]["LDGR_DR_ID"].ToString() != "")
            {
                ObjEntityCredit.Ledger_Debit_Id = Convert.ToInt32(dtCredit.Rows[0]["LDGR_DR_ID"].ToString());
                dtinvoiceDtls = objBussinessCredit.ReadInvoiceDtls(ObjEntityCredit);
            }
        }
        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);
        //0039
        DataTable dtLDGRdTLSdbcr = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
        //end

        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                Version_flg = 1;

                strReturn = objBussinessCredit.PdfPrintVersion1(strId, dt, dtCredit, dtDebit, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                Version_flg = 2;
                strReturn = objBussinessCredit.PdfPrintVersion2(dtLDGRdTLSdbcr, strId, dt, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit, Version_flg, dtinvoiceDtls);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                Version_flg = 3;
                strReturn = objBussinessCredit.PdfPrintVersion2(dtLDGRdTLSdbcr, strId, dt, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit, Version_flg, dtinvoiceDtls);
            }
        }


        return strReturn;
    }

 


    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string[] ConfirmReceiptDetails(string strUserID, string strPayemntId, string strOrgIdID, string strCorpID, string FinYrID)
    {

        string[] strRets = new string[3];
        FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List objPage = new FMS_FMS_Master_fms_Debit_Note_fms_Debit_note_List();

        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        List<clsEntity_Debit_Note> objEntityLedger = new List<clsEntity_Debit_Note>();
        List<clsEntity_Debit_Note> objEntityLedgerdEL = new List<clsEntity_Debit_Note>();
        List<clsEntity_Debit_Note> objEntityLedgerCostCenter = new List<clsEntity_Debit_Note>();
        List<clsEntity_Debit_Note> objEntitySaleList = new List<clsEntity_Debit_Note>();
        List<clsEntity_Debit_Note> objEntityDelete = new List<clsEntity_Debit_Note>();//EVM-0020

        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successConfirm";
        string NewRev = "";

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityCredit.Debit_Id = Convert.ToInt32(strId);
        ObjEntityCredit.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityCredit.Corporate_id = Convert.ToInt32(strCorpID);
        ObjEntityCredit.User_Id = Convert.ToInt32(strUserID);
        try
        {
            DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
            if (dt.Rows[0]["DR_NOTE_REF"].ToString() != "")
            {
                ObjEntityCredit.Reference_Num = dt.Rows[0]["DR_NOTE_REF"].ToString();
            }
            if (dt.Rows[0]["DR_NOTE_DATE"].ToString() != "")
            {
                ObjEntityCredit.UpdCredit_date = objCommon.textToDateTime(dt.Rows[0]["DR_NOTE_DATE"].ToString());
                ObjEntityCredit.Debit_Date = objCommon.textToDateTime(dt.Rows[0]["DR_NOTE_DATE"].ToString());
            }
            if (dt.Rows[0]["DR_NOTE_TOTAL"].ToString() != "")
            {
                ObjEntityCredit.Debit_Total = Convert.ToDecimal(dt.Rows[0]["DR_NOTE_TOTAL"].ToString());
            }
            if (dt.Rows[0]["DR_NOTE_NARRATION"].ToString() != "")
            {
                ObjEntityCredit.Description = dt.Rows[0]["DR_NOTE_NARRATION"].ToString();
            }
            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                ObjEntityCredit.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
            }
            if (dt.Rows[0]["DR_REF_SEQNUM"].ToString() != "")
            {
                ObjEntityCredit.RefSeqNo = Convert.ToInt32(dt.Rows[0]["DR_REF_SEQNUM"].ToString());
            }
            DataTable dtLDGRdTLS = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
            int DebtCount = 0;
            int CrdtCount = 0;
            int CntExceed = 0;//EVM-0020
            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
            {
                clsEntity_Debit_Note ObjSubEntityRequestCost = new clsEntity_Debit_Note();
                clsEntity_Debit_Note ObjSubEntityRequestPurchase = new clsEntity_Debit_Note();
                clsEntity_Debit_Note ObjSubEntityRequest = new clsEntity_Debit_Note();
                clsEntity_Debit_Note objEntityCstDtlDEL = new clsEntity_Debit_Note();//EVM-0020

                ObjSubEntityRequestPurchase.Organisation_id = Convert.ToInt32(strOrgIdID);
                ObjSubEntityRequestPurchase.Corporate_id = Convert.ToInt32(strCorpID);
                if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())) && dtLDGRdTLS.Rows[intCount]["LDGR_DR_AMT"].ToString() != "")
                {
                    if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())))
                    {
                        ObjSubEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                        NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                    }
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequest.Ledger_Debit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                    }
                    if (Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_DR_CR_STATUS"].ToString()) == 1)//Credit
                    {
                        CrdtCount++;
                    }
                    else if (Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_DR_CR_STATUS"].ToString()) == 0) //Debit
                    {
                        DebtCount++;
                    }
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_DR_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequest.Ledger_Amount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["LDGR_DR_AMT"].ToString());
                    }
                    ObjSubEntityRequest.Credit_debit_Status = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_DR_CR_STATUS"].ToString());
                    objEntityLedger.Add(ObjSubEntityRequest);
                }
                if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString() != "")
                {
                    ObjSubEntityRequestCost.Cost_Centre_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString());

                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCost.Ledger_Debit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                    }
                    ObjSubEntityRequestCost.Cost_Centre_Amt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString());
                    if (dtLDGRdTLS.Rows[intCount]["COSTGRP_ID_ONE"].ToString() != "")
                    {
                        ObjSubEntityRequestCost.CostGrp1Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTGRP_ID_ONE"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["COSTGRP_ID_TWO"].ToString() != "")
                    {
                        ObjSubEntityRequestCost.CostGrp2Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTGRP_ID_TWO"].ToString());
                    }

   



                    objEntityLedgerCostCenter.Add(ObjSubEntityRequestCost);
                }
                if (dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString() != "")
                {
                    ObjSubEntityRequestPurchase.Cost_Centre_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString());

                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestPurchase.Ledger_Debit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                    }
                    ObjSubEntityRequestPurchase.Cost_Centre_Amt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString());
                    if (dtLDGRdTLS.Rows[intCount]["PURCHS_BAL_AMT"].ToString() != "")
                        ObjSubEntityRequestPurchase.PurchaseActAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PURCHS_BAL_AMT"].ToString());

                    DataTable dtSalesBalance = objBussinessCredit.ReadPurchaseBalance(ObjSubEntityRequestPurchase);
                    decimal decSalesRemainAmt = 0;
                    if (dtSalesBalance.Rows.Count > 0)
                    {
                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                    }
                    //EVM-0020
                    if (decSalesRemainAmt != 0)
                    {
                        if (decSalesRemainAmt < ObjSubEntityRequestPurchase.Cost_Centre_Amt)
                        {
                            strRets[0] = "PrchsAmountExceeded";
                            CntExceed++;
                        }
                    }
                    else if (CntExceed == 0)
                    {
                        strRets[0] = "PrchsAmtFullySettld";
                        objEntityCstDtlDEL.Cost_Centre_Debit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_ID"].ToString());
                        objEntityDelete.Add(objEntityCstDtlDEL);
                    }
                    if (decSalesRemainAmt != 0)//insert not fully settled
                    {
                        objEntitySaleList.Add(ObjSubEntityRequestPurchase);
                    }
                }
            }

            if (objEntityDelete.Count > 0)//delete fully settld saved sales and purchs
            {
                objBussinessCredit.DeletePurchaseLedgers(objEntityDelete);
                strRets[0] = "successConfirm";
            }

            ObjEntityCredit.ConfirmStatus = 1;
            ObjEntityCredit.CreditCount = CrdtCount;
            ObjEntityCredit.DebitCount = DebtCount;
            if (FinYrID != "")
                ObjEntityCredit.FinancialYrId = Convert.ToInt32(FinYrID);

            if (strRets[0] != "PrchsAmountExceeded" && strRets[0] != "PrchsAmtFullySettld")
            {
                objBussinessCredit.ConfirmCredit_Note(ObjEntityCredit, objEntityLedger, objEntityLedgerdEL, objEntityLedgerCostCenter, objEntitySaleList);
            }


            ObjEntityCredit = new clsEntity_Debit_Note();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;

            intUserId = Convert.ToInt32(strUserID);
            ObjEntityCredit.User_Id = intUserId;

            intCorpId = Convert.ToInt32(strCorpID);
            ObjEntityCredit.Corporate_id = intCorpId;

            intOrgId = Convert.ToInt32(strOrgIdID);
            ObjEntityCredit.Organisation_id = intOrgId;

            if (strCnclSts != "")
                ObjEntityCredit.ConfirmStatus = Convert.ToInt32(strCnclSts);
          

            ObjEntityCredit.Date_From = objCommon.textToDateTime(strFromDate);
            ObjEntityCredit.Date_To = objCommon.textToDateTime(strToDate);
            ObjEntityCredit.Status = Convert.ToInt32(strStatus);


            DataTable dtList = objBussinessCredit.ReadCreditNoteList(ObjEntityCredit);
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        objPage.intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        objPage.intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                }
            }
            strRets[1] = objPage.ConvertDataTableToHTML(dtList, intUpdate, intEnableCancel, objPage.intReopen, objPage.intAccntCloseReopen);
            strRets[2] = objPage.ConvertDataTableToPrint(dtList);

        }
        catch
        {
            strRets[0] = "failed";
        }
        //HttpContext.Current.Session["REOPEN_STS"] = strRets;
        return strRets;

    }
    public string PrintCaption(clsEntity_Debit_Note ObjEntityRequest)
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
        strTitle = "DEBIT NOTE";
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
    public static string CheckSaleSettlement(string strPayemntId, string strOrgIdID, string strCorpID)
    {
        //EVM-0020
        string ret = "successConfirm";

        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        List<clsEntity_Debit_Note> objEntitySaleList = new List<clsEntity_Debit_Note>();

        string strRandomMixedId = strPayemntId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        ObjEntityCredit.Debit_Id = Convert.ToInt32(strId);
        ObjEntityCredit.Organisation_id = Convert.ToInt32(strOrgIdID);
        ObjEntityCredit.Corporate_id = Convert.ToInt32(strCorpID);

        int CntExceed = 0;

        DataTable dtLDGRdTLS = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
        for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
        {
            clsEntity_Debit_Note ObjSubEntityRequestPurchase = new clsEntity_Debit_Note();
            clsEntity_Debit_Note ObjSubEntityRequest = new clsEntity_Debit_Note();

            if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_ID"].ToString() != "")
            {
                if (dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString() != "")
                {
                    ObjSubEntityRequestPurchase.Corporate_id = ObjEntityCredit.Corporate_id;
                    ObjSubEntityRequestPurchase.Organisation_id = ObjEntityCredit.Organisation_id;
                    ObjSubEntityRequestPurchase.Cost_Centre_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString());
                    ObjSubEntityRequestPurchase.Cost_Centre_Amt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CST_CNTR_DR_AMOUNT"].ToString());

                    DataTable dtSalesBalance = objBussinessCredit.ReadPurchaseBalance(ObjSubEntityRequestPurchase);
                    decimal decSalesRemainAmt = 0;
                    if (dtSalesBalance.Rows.Count > 0)
                    {
                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                    }
                    if (decSalesRemainAmt != 0)
                    {
                        if (decSalesRemainAmt < ObjSubEntityRequestPurchase.Cost_Centre_Amt)
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