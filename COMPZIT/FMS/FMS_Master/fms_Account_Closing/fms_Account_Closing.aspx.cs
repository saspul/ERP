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

public partial class FMS_FMS_Master_fms_Account_Closing_fms_Account_Closing : System.Web.UI.Page
{
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
            HiddenSearch.Value = "";
            HiddenddlAccntGrp.Value = "";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            HiddenCurrentDate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            LoadAccountGrp();
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
            cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            clsCommonLibrary objcommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntityAccnt.User_Id = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityAccnt.Corporate_id = intCorpId;
                objEntityCommon.CorporateID = intCorpId;
                objEntityAudit.Corporate_id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityAccnt.Organisation_id = intOrgId;
                objEntityCommon.Organisation_Id = intOrgId;
                objEntityAudit.Organisation_id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
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
            }

            DataTable dtCurrentFinclYr = objBusinessLayer.ReadFinancialYear(objEntityCommon);
            if (dtCurrentFinclYr.Rows.Count > 0)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(dtCurrentFinclYr.Rows[0]["FINCYR_ID"].ToString());
                objEntityAccnt.FinancialYrId = Convert.ToInt32(dtCurrentFinclYr.Rows[0]["FINCYR_ID"].ToString());
            }

            //if (Session["FINCYRID"] != null)
            //{
            //    objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            //    objEntityAccnt.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            //    //objEntityAudit.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            //}
            //else
            //{
            //    Response.Redirect("/Default.aspx");
            //}

            //To calculate last closed date
            DataTable dtCls = objBusinessAudit.Read_Account_Close(objEntityAudit);
            DataTable dtAuditCls = objBusinessAudit.Read_Audit_Close(objEntityAudit);
            DataTable dtCls1 = objEmpAccntCls.ReadCloseDates(objEntityAccnt);

            DivClsHis.InnerHtml = ConvertDataTableToHTMLClsgHistory(dtCls1);

            if (dtCls.Rows.Count > 0)
            {
                if (dtCls.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                {
                    int count = dtCls.Rows.Count - 1;
                    HiddenAccountClsDate.Value = dtCls.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    lblLastClsdDate.InnerText = HiddenAccountClsDate.Value;
                }
            }

            if (dtAuditCls.Rows.Count > 0)
            {
                int count = dtAuditCls.Rows.Count - 1;
                if (dtAuditCls.Rows[0]["AUDIT_CLS_DATE"].ToString() != "")
                    HiddenLastClosDate.Value = dtAuditCls.Rows[0]["AUDIT_CLS_DATE"].ToString();
            }
            DateTime dtAudit = new DateTime();
            DateTime dtAccount = new DateTime();
            if (HiddenAccountClsDate.Value != "")
                dtAccount = objcommon.textToDateTime(HiddenAccountClsDate.Value);
            if (HiddenLastClosDate.Value != "")
            {
                dtAudit = objcommon.textToDateTime(HiddenLastClosDate.Value);
                dtAudit = dtAudit.AddDays(1);
            }
            if (dtAudit != DateTime.MinValue || dtAccount != DateTime.MinValue)
            {
                if (dtAudit >= dtAccount)
                    HiddenStartDate.Value = dtAudit.ToString("dd-MM-yyyy");
                else
                    HiddenStartDate.Value = dtAccount.ToString("dd-MM-yyyy");
            }
            if (HiddenCurrentDate.Value == HiddenLastClosDate.Value)
            {
                //  HiddenCurrentDate.Value = "";
            }

            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                {
                    HiddenFinancialYearTo.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }
                if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "")
                {
                    HiddenFinancialYearFrom.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    if (HiddenStartDate.Value == "")
                    {
                        HiddenStartDate.Value = objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()).ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        if (objcommon.textToDateTime(HiddenStartDate.Value) >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && objcommon.textToDateTime(HiddenStartDate.Value) <= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {

                        }
                        else
                        {
                            HiddenStartDate.Value = objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()).ToString("dd-MM-yyyy");
                        }
                    }
                }
                if (System.DateTime.Now >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && System.DateTime.Now <= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                {
                    txtFromdate.Value = HiddenCurrentDate.Value;
                }
            }

            DataTable dtClsYearEnd = objEmpAccntCls.CheckYearEndClose(objEntityAccnt);
            if (dtClsYearEnd.Rows.Count > 0)
            {
                if (dtClsYearEnd.Rows[0]["ACCNT_CLS_ID"].ToString() != "")
                {
                    HiddenFieldYearEndId.Value = dtClsYearEnd.Rows[0]["ACCNT_CLS_ID"].ToString();
                    BtnClose.InnerHtml = "<i class=\"fa fa-repeat rd\"></i>Recall";
                    txtFromdate.Value = dtClsYearEnd.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    cbxCnclStatus.Checked = true;
                    cbxCnclStatus.Enabled = false;
                    txtFromdate.Disabled = true;

                    objEntityAudit.FromDate = objcommon.textToDateTime(txtFromdate.Value);
                    DataTable dtAuditClsEnd = objBusinessAudit.CheckYearEndClosingDate(objEntityAudit);
                    if (dtAuditClsEnd.Rows.Count > 0)
                    {
                        if (objcommon.textToDateTime(dtAuditClsEnd.Rows[0]["AUDIT_CLS_DATE"].ToString()) > objcommon.textToDateTime(dtClsYearEnd.Rows[0]["ACCNT_CLS_DATE"].ToString()))
                        {
                            BtnClose.Visible = false;
                        }
                    }
                }
            }

            lblEntry.Text = "Account Closing";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                txtFromdate.Disabled = true;
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (strInsUpd == "InsCls")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CloseErrorMsg", "CloseErrorMsg();", true);
                }
                else if (Request.QueryString["InsUpd"] == "cncl")
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
                else if (Request.QueryString["InsUpd"] == "ConfirmSus")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
                }
                else if (Request.QueryString["InsUpd"] == "Confirmed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfirm", "AlreadyConfirm();", true);
                }
                else if (Request.QueryString["InsUpd"] == "PendingConfirm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PendingConfirmMsg", "PendingConfirmMsg();", true);
                }
                else if (Request.QueryString["InsUpd"] == "AlreadyRecall")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyRecall", "AlreadyRecall();", true);
                }
                else if (Request.QueryString["InsUpd"] == "SucRecall")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SucRecall", "SucRecall();", true);
                }
            }
        }

    }

    public void LoadAccountGrp()
    {
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityAccnt.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityAccnt.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityAccnt.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtAccgrp = objEmpAccntCls.ReadAccntGrpList(objEntityAccnt);
        ddlAccntGrp.ClearSelection();
        if (dtAccgrp.Rows.Count > 0)
        {

            ddlAccntGrp.DataSource = dtAccgrp;
            ddlAccntGrp.DataTextField = "ACNT_GRP_NAME";
            ddlAccntGrp.DataValueField = "ACNT_GRP_ID";
            ddlAccntGrp.DataBind();
            ddlAccntGrp.Items.Insert(0, "--SELECT ACCOUNT GROUP--");

        }

    }

    public string ConvertDataTableToHTMLClsgHistory(DataTable dt)
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

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_columnCls\" class=\"display table-bordered\" style=\"width: 100%\" >";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr >";

        strHtml += "<th class=\"col-md-2\"> CLOSED DATE";
        strHtml += "<input class=\" tb_inp_1 tb_in tr_c \" placeholder=\" CLOSED DATE\" >";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-2\">ACTION DATE";
        strHtml += "<input class=\"tb_inp_1 tb_in tr_c \" placeholder=\"ACTION DATE\" style=\"text-align:center;\" type=\"text\">";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-2\">YEAR END CLOSE";
        strHtml += "<input class=\"tb_inp_1 tb_in tr_c \" placeholder=\"YEAR END CLOSE\" style=\"text-align:center;\" type=\"text\">";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-2 tr_l \">CLOSED BY";
        strHtml += "<input class=\"tb_inp_1 tb_in \" placeholder=\"CLOSED BY\" type=\"text\">";
        strHtml += "</th >";

        strHtml += "<th class=\"col-md-3\">Action<p class=\"nbsp1\">&nbsp;</p>";
        //strHtml += "<input class=\"form-control\" placeholder=\"CONFIRM\" style=\"text-align:center;\" type=\"text\">";
        //strHtml += "</th >";

        //strHtml += "<th class=\"hasinput\" style=\"width:8%;text-align:center;\">DELETE";
        //strHtml += "<input class=\"form-control\" placeholder=\"DELETE\" style=\"text-align:center;\" type=\"text\">";
        strHtml += "</th >";
        
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            //  string orgid = dt.Rows[intRowBodyCount][0].ToString();
            // strHtml += "<td class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>";
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            strHtml += "<tr>";
            strHtml += "<td  >" + dt.Rows[intRowBodyCount]["ACCNT_CLS_DATE"].ToString() + "</td>";
            strHtml += "<td >" + dt.Rows[intRowBodyCount]["ACCNT_CLS_INS_DATE"].ToString() + "</td>";
            strHtml += "<td >" + dt.Rows[intRowBodyCount]["ACCNT_CLS_YEAREND_STS"].ToString() + "</td>"; 

            if (dt.Rows[intRowBodyCount]["ACCNT_CLS_CONFIRM_STS"].ToString() != "")
            {
                if (dt.Rows[intRowBodyCount]["ACCNT_CLS_CONFIRM_STS"].ToString() == "1")
                {
                    strHtml += "<td class=\"tr_l\">" + dt.Rows[intRowBodyCount]["EMPNAME"].ToString() + "</td>";
                    strHtml += "<td > <a  href=\"javascript:;\" style=\"opacity: 0.5;\" class=\"btn act_btn bn2 \" title=\"Confirm\"><i class=\"fa fa-check\" style=\"\"></i></a>";
                    strHtml += "<a  href=\"javascript:;\" style=\"opacity: 0.5;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";
               
                }
                else
                {
                    strHtml += "<td></td>";
                    strHtml += "<td><a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn2 \" title=\"Confirm\" onclick=\"return OpenConfirm('" + Id + "');\"><i class=\"fa fa-check\" style=\"cursor: pointer;\"></i></a>";
                    strHtml += "<a  href=\"javascript:;\" style=\"opacity: 1;z-index: 10;\" class=\"btn act_btn bn3 \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"cursor: pointer;\"></i></a></td>";
                }
            }
           strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }

    public string ConvertDataTableToHTML(DataTable dt)
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

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"datatable_fixed_column\" class=\"display table-bordered\" style=\"width: 100%\">";
        //add header row
        strHtml += "<thead class=\"thead1\">";
        strHtml += "<tr>";
        strHtml += "<th class=\"col-md-6 tr_l\"> LEDGER";
        strHtml += "<br><input class=\" tb_inp_1 tb_in tr_l\" placeholder=\" LEDGER\" type=\"text\">";
        strHtml += "</th >";
        strHtml += "<th class=\" col-md-6 tr_r\" >AMOUNT";
        strHtml += "<br><input class=\"tb_inp_1 tb_in tr_r \" placeholder=\"AMOUNT\" type=\"text\">";
        strHtml += "</th >";
        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
           
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            strHtml += "<tr>";
            strHtml += "<td class=\"tr_l\" >" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</td>";
            Decimal DecDebAmnt=  Convert.ToDecimal(dt.Rows[intRowBodyCount]["DEBIT_AMNT"].ToString());
            Decimal DecCredAmnt = Convert.ToDecimal(dt.Rows[intRowBodyCount]["CREDIT_AMNT"].ToString());


           if (dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != "" && dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString() != null)
           {
               int LedgMode = Convert.ToInt32(dt.Rows[intRowBodyCount]["LDGR_MODE"].ToString());
               decimal OpeningBalance = Convert.ToDecimal(dt.Rows[intRowBodyCount]["LDGR_OPEN_BAL"].ToString());
          
                   if (LedgMode == 0)
                   {
                       DecDebAmnt = DecDebAmnt + OpeningBalance;
                   }
                   else {
                       DecCredAmnt = DecCredAmnt + OpeningBalance;
                   }
            
                 
               
           }
            

           Decimal DecBal = 0;
           int precision = Convert.ToInt32(HiddenFieldDecimalCnt.Value);
           string format = String.Format("{{0:N{0}}}", precision);
           if (DecDebAmnt > DecCredAmnt)
           {
               DecBal = DecDebAmnt - DecCredAmnt;

               string valuestringTot = String.Format(format, DecBal);
               strHtml += "<td class=\"tr_r\">" + valuestringTot + " DR</td>";
           }
           else 
           {
               DecBal = DecCredAmnt-DecDebAmnt  ;
               string valuestringTot = String.Format(format, DecBal);
               strHtml += "<td class=\"tr_r\" >" + valuestringTot + " CR</td>";
           }
            strHtml += "</tr>";
        }
     

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public void OutStandingBalance(string strP_Id)
    {

    }

    protected void btnCnclSearch_Click(object sender, EventArgs e)
    {

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntityAccnt.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntityAccnt.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityAccnt.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenddlAccntGrp.Value!="")
        objEntityAccnt.AccntGrpid = Convert.ToInt32(HiddenddlAccntGrp.Value);
       // objEntityAccnt.FromDate = objCommon.textToDateTime(LedFrmDate.Value);
        objEntityAccnt.CurrentDate = objCommon.textToDateTime(LedToDate.Value);
        DataTable dtCls = objEmpAccntCls.ReadOutStandingBal(objEntityAccnt);

        //clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
        //intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.TAX_DEDCTD_ATSRCE);
        //DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);





       // if (dtCls.Rows.Count > 0)
            DivOutstdBal.InnerHtml = ConvertDataTableToHTML(dtCls);
            ScriptManager.RegisterStartupScript(this, GetType(), "DisplayChange", "DisplayChange();", true);

    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityAccnt.User_Id = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityAccnt.Corporate_id = intCorpId;
           // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityAccnt.Organisation_id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (txtFromdate.Value != "")
        {
            objEntityAccnt.FromDate = objCommon.textToDateTime(txtFromdate.Value);
        }
        if (cbxCnclStatus.Checked == true)
        {
            objEntityAccnt.YearEndStatus = 1;
        }

        if (HiddenFieldYearEndId.Value == "")
        {

            DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);

            if (cbxCnclStatus.Checked == true)
            {
                dtAccntCls = objEmpAccntCls.CheckYearEndClosingDate(objEntityAccnt);
            }

            if (dtAccntCls.Rows.Count > 0)
            {
                Response.Redirect("fms_Account_Closing.aspx?InsUpd=InsCls");
            }
            else
            {
                DataTable dtNoncnfrm = objEmpAccntCls.CheckNonConfirmStatus(objEntityAccnt);
                if (dtNoncnfrm.Rows.Count > 0)
                {
                    Response.Redirect("fms_Account_Closing.aspx?InsUpd=PendingConfirm");
                }
                else
                {
                    objEmpAccntCls.InsertAccountClosing(objEntityAccnt);
                    if (clickedButton.ID == "bttnsave")
                    {
                        Response.Redirect("fms_Account_Closing.aspx?InsUpd=Ins");
                    }
                }
            }
        }
        else
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            objEntityCommon.CorporateID = objEntityAccnt.Corporate_id;
            objEntityCommon.Organisation_Id = objEntityAccnt.Organisation_id;

            DataTable dtCurrentFinclYr = objBusinessLayer.ReadFinancialYear(objEntityCommon);
            if (dtCurrentFinclYr.Rows.Count > 0)
            {
                objEntityAccnt.FinancialYrId = Convert.ToInt32(dtCurrentFinclYr.Rows[0]["FINCYR_ID"].ToString());
            }

            DataTable dtClsYearEnd = objEmpAccntCls.CheckYearEndClose(objEntityAccnt);
            if (dtClsYearEnd.Rows.Count == 0)
            {
                Response.Redirect("fms_Account_Closing.aspx?InsUpd=AlreadyRecall");
            }
            else
            {
                objEntityAccnt.AccountClsId = Convert.ToInt32(HiddenFieldYearEndId.Value);
                objEmpAccntCls.RecallAccountClose(objEntityAccnt);
                Response.Redirect("fms_Account_Closing.aspx?InsUpd=SucRecall");
            }
        }
    }
    [WebMethod]
    public static string CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strOrgID, string strCorprtID)
    {
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityAccnt.AccountClsId = Convert.ToInt32(strId);
        objEntityAccnt.User_Id = Convert.ToInt32(usrId);
        objEntityAccnt.Corporate_id = Convert.ToInt32(strCorprtID);
        objEntityAccnt.Organisation_id = Convert.ToInt32(strOrgID);
        if (reasonmust == "1")
        {
            objEntityAccnt.Cancel_Reason = cnclRsn;
        }
        else
        {
            objEntityAccnt.Cancel_Reason = objCommon.CancelReason();
        }
        try
        {
            DataTable dtChkCnfrm = objEmpAccntCls.CheckAccountClsDateConfirmStatus(objEntityAccnt);
            DataTable dt = objEmpAccntCls.CheckAccountClsDateCnclSts(objEntityAccnt);
            if (dt.Rows.Count>0)
            {
                strRets = "UpdCancl";
            }
            else if (dtChkCnfrm.Rows.Count > 0)
            {
                if (dtChkCnfrm.Rows[0][0].ToString() != "" && dtChkCnfrm.Rows[0][0].ToString() != null)
                {
                    strRets = "Confirmed";
                }
            }
            else 
            {
               objEmpAccntCls.CancelAccntClsDate(objEntityAccnt);
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }
    [WebMethod]
    public static string ConfirmAccountClose(string strId, string strUserID)
    {

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "ConfirmSus";
        string strRandomMixedId = strId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string StrId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityAccnt.AccountClsId = Convert.ToInt32(StrId);
        objEntityAccnt.User_Id = Convert.ToInt32(strUserID);
        try
        {
            DataTable dt = objEmpAccntCls.CheckAccountClsDateCnclSts(objEntityAccnt);
            if (dt.Rows.Count > 0)
            {
                strRets = "UpdCancl";
            }
           
            else
            {
                objEmpAccntCls.ConfirmAccntClsDate(objEntityAccnt);
            }
        }
        catch
        {
            strRets = "failed";
        }
        return strRets;
    }
}