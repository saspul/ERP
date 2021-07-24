using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Web.Services;
using BL_Compzit.BusineesLayer_FMS;
using System.Text;
using System.Web.Script.Serialization;

using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Web.Services;
using System.Globalization;
public partial class FMS_FMS_Master_fms_Account_Setting_fms_Account_Setting : System.Web.UI.Page
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
            HiddenModuleCount.Value = "0";
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            clsEntity_Account_Setting objEntity = new clsEntity_Account_Setting();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                objEntity.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0;
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Account_Setting);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  
                                                         clsCommonLibrary.CORP_GLOBAL.GN_REMOVE_RESTRCTNS_STS
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenRestritionStatus.Value = dtCorpDetail.Rows[0]["GN_REMOVE_RESTRCTNS_STS"].ToString();
            }
            //when editing 
            lblEntry.Text = "Add Account Setting";
            FinancialYearLoad();
            ModuleGrp.InnerHtml = UpdateAccountGrpMapping(objEntity);
            HeadMap.InnerHtml = UpdateAccountHeadMapping(objEntity);
            DivPrintVersion.InnerHtml = UpdatePrintVersionMapping(objEntity);
            divPrimaryAccntGrps.InnerHtml = UpdatePrimaryAccountGrpMapping(objEntity, HiddenRestritionStatus.Value);

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                if (strInsUpd == "Fail")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "FinancialYear", "FinancialYear();", true);
                }
            }

        }
    }

    public static string UpdateAccountGrpMapping(clsEntity_Account_Setting objEntity)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        clsBusiness_Account_Setting objBusinessAcntSetting = new clsBusiness_Account_Setting();
        DataTable dt = objBusinessAcntSetting.ReadAccountGrpMapping(objEntity);
        StringBuilder sb = new StringBuilder();

        if (dt.Rows.Count > 0)
        {
            objEntityCommon.Organisation_Id = objEntity.OrgId;
            objEntityCommon.CorporateID = objEntity.CorpId;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            String Status = "";
            int intOrgId = 0;

            sb.Append("<table id=\"tblAccountGroup\" class=\"table table-bordered\"  >");
            sb.Append("<thead class=\"thead1\">");
            sb.Append("<tr >");
            sb.Append("<th class=\"col-md-6 tr_l\" > MODULE");
            sb.Append("</th >");
            sb.Append("<th class=\"col-md-6 tr_l\">DEFAULT ACCOUNT GROUP");
            sb.Append("</th >");
            sb.Append("</th >");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            //   HiddenModuleCount.Value = dt.Rows.Count.ToString();
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                sb.Append("<tr >");
                string strId = "";
                if (dt.Rows[intRowBodyCount][0].ToString() != "")
                {
                    strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                }
                if (intRowBodyCount != 0)
                    objEntity.UserId = Convert.ToInt32(dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString());
                if (Convert.ToInt32(dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString()) == 1)
                    objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
                else if (Convert.ToInt32(dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString()) == 2)
                    objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR));
                else if (Convert.ToInt32(dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString()) == 3)
                    objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
                objEntity.AccountNatureStatus = 4;
                DataTable dtAccountGrp = objBusiness.ReadAccountGrps(objEntityCommon);
                //  ReadAccountGrp
                sb.Append("<td class=\"tr_l\" id=\"Grp_Id\" style=\"display:none;\" >" + intRowBodyCount + "</td>");
                if (dt.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() != "")
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"AccountGrp_Id" + intRowBodyCount + "\" name=\"AccountGrp_Id" + intRowBodyCount + "\" value=\"" + strId + "\" /></td>");
                }
                else
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"AccountGrp_Id" + intRowBodyCount + "\" name=\"AccountGrp_Id" + intRowBodyCount + "\" /></td>");
                }
                sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"Account_Id" + intRowBodyCount + "\" name=\"Account_Id" + intRowBodyCount + "\" value=\"" + dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() + "\" />" + dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() + "</td>");
                if (dt.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() != "")
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\" value=\"" + dt.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() + "\"  id=\"ddlAccountGrp_Id" + intRowBodyCount + "\" name=\"ddlAccountGrp_Id" + intRowBodyCount + "\"  /></td>");
                }
                else
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"ddlAccountGrp_Id" + intRowBodyCount + "\" name=\"ddlAccountGrp_Id" + intRowBodyCount + "\"  /></td>");
                }
                sb.Append("<td class=\"tr_l\"  >" + dt.Rows[intRowBodyCount]["ASMOD_NAME"].ToString() + "</td>");
                sb.Append("<td class=\"tr_l\" style=\" \" >");
                sb.Append("<div id=\"divAcntDeb" + intRowBodyCount + "\"><select onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl \" id=\"ddlAccountGrp" + intRowBodyCount + "\" onchange=\"return changeAccount(" + intRowBodyCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");

                sb.Append("<option>-Select Account Group-</option>");
                int f = 0;
                for (int intRowCount = 0; intRowCount < dtAccountGrp.Rows.Count; intRowCount++)
                {
                    if (dtAccountGrp.Rows[intRowCount]["ACNT_GRP_ID"].ToString() == dt.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                    {
                        f = 1;
                        sb.Append("<option selected value=\"" + dtAccountGrp.Rows[intRowCount]["ACNT_GRP_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCount]["ACNT_GRP_NAME"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dtAccountGrp.Rows[intRowCount]["ACNT_GRP_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCount]["ACNT_GRP_NAME"].ToString() + "</option>");
                    }
                }
                //if (dt.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() != "")
                //{
                //    if (f == 0)
                //    {
                //        sb.Append("<option selected value=\"" + dt.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() + "\">" + dt.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</option>");
                //    }
                //}
                sb.Append("<div style=\"display:none;\" id=\"divAccnt" + intRowBodyCount + "\"><input  id=\"AccntddlValue" + intRowBodyCount + "\" style=\"display:none;\"  ></div>");
                sb.Append("</select></div></td>");
                sb.Append("</tr>");

            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            //    ModuleGrp.InnerHtml = sb.ToString();

        }
        return sb.ToString();
    }

    public static string UpdateAccountHeadMapping(clsEntity_Account_Setting objEntity)
    {
        clsBusiness_Account_Setting objBusiness = new clsBusiness_Account_Setting();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        objEntityCommon.Organisation_Id = objEntity.OrgId;
        objEntityCommon.CorporateID = objEntity.CorpId;
        DataTable dt = objBusiness.ReadHeadGrpMapping(objEntity);
        //clsCommonLibrary.ASMOD_ID
        StringBuilder sb = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            sb.Append("<table id=\"tblHeadModule\" class=\"table table-bordered\"  >");
            sb.Append("<thead class=\"thead1\">");
            sb.Append("<tr >");
            sb.Append("<th class=\"col-md-6 tr_l\" > MODULE");
            sb.Append("</th >");
            sb.Append("<th class=\"col-md-6 tr_l\">DEFAULT ACCOUNT HEAD");
            sb.Append("</th >");
            sb.Append("</th >");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strId = "";
                sb.Append("<tr >");
                if (dt.Rows[intRowBodyCount][0].ToString() != "")
                {
                    strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                }
                sb.Append("<td class=\"tr_l\" id=\"Head_Id\" style=\"display:none;\" >" + intRowBodyCount + "</td>");
                if (dt.Rows[intRowBodyCount]["LDGR_ID"].ToString() != "")
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"AccountHead_Id" + intRowBodyCount + "\" name=\"AccountHead_Id" + intRowBodyCount + "\" value=\"" + strId + "\" />" + strId + "</td>");
                }
                else
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"AccountHead_Id" + intRowBodyCount + "\" name=\"AccountHead_Id" + intRowBodyCount + "\" />" + strId + "</td>");
                }
                sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"AccountH_Id" + intRowBodyCount + "\" name=\"AccountH_Id" + intRowBodyCount + "\" value=\"" + dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() + "\" />" + dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() + "</td>");
                if (dt.Rows[intRowBodyCount]["LDGR_ID"].ToString() != "")
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"ddlAccountHead_Id" + intRowBodyCount + "\" name=\"ddlAccountHead_Id" + intRowBodyCount + "\" value=\"" + dt.Rows[intRowBodyCount]["LDGR_ID"].ToString() + "\" /></td>");
                }
                else
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"ddlAccountHead_Id" + intRowBodyCount + "\" name=\"ddlAccountHead_Id" + intRowBodyCount + "\"  /></td>");
                }
                sb.Append("<td class=\"tr_l\" style=\" \" >" + dt.Rows[intRowBodyCount]["ASMOD_NAME"].ToString() + "</td>");


                sb.Append("<td class=\"tr_l\" style=\"\" >");
                sb.Append("<div id=\"divLedDeb" + intRowBodyCount + "\"><select onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl\" id=\"ddlAccountHead" + intRowBodyCount + "\" onchange=\"return changeLedger(" + intRowBodyCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");

                sb.Append("<option>-Select Ledger-</option>");
                int f = 0;
                DataTable dtAccountGrp = new DataTable();
                if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.purchase).ToString())
                {
                    objEntity.AccountNatureStatus = 2;
                    dtAccountGrp = objBusiness.ReadLedgerByNature(objEntity);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.sales).ToString())
                {
                    objEntity.AccountNatureStatus = 3;
                    dtAccountGrp = objBusiness.ReadLedgerByNature(objEntity);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.supplier).ToString())
                {
                    objEntity.AccountNatureStatus = 1;
                    dtAccountGrp = objBusiness.ReadLedgerByNature(objEntity);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.customer).ToString())
                {
                    objEntity.AccountNatureStatus = 0;
                    dtAccountGrp = objBusiness.ReadLedgerByNature(objEntity);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.bank).ToString())
                {
                    objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
                    objEntity.AccountNatureStatus = 4;
                    dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.profitloss).ToString())
                {
                    objEntityCommon.PrimaryGrpIds = "0";
                    dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.paymntclearance).ToString())
                {
                    objEntityCommon.PrimaryGrpIds = "0";
                    dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
                }
                else if (dt.Rows[intRowBodyCount]["ASMOD_ID"].ToString() == Convert.ToInt32(clsCommonLibrary.ASMOD_ID.receiptclearance).ToString())
                {
                    objEntityCommon.PrimaryGrpIds = "0";
                    dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
                }

                for (int intRowCount = 0; intRowCount < dtAccountGrp.Rows.Count; intRowCount++)
                {
                    if (dtAccountGrp.Rows[intRowCount]["LDGR_ID"].ToString() == dt.Rows[intRowBodyCount]["LDGR_ID"].ToString())
                    {
                        f = 1;
                        sb.Append("<option selected value=\"" + dtAccountGrp.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dtAccountGrp.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                    }
                }

                if (dt.Rows[intRowBodyCount]["LDGR_ID"].ToString() != "")
                {
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dt.Rows[intRowBodyCount]["LDGR_ID"].ToString() + "\">" + dt.Rows[intRowBodyCount]["LDGR_NAME"].ToString() + "</option>");
                    }
                }
                sb.Append("<div style=\"display:none;\" id=\"divAccnt" + intRowBodyCount + "\"><input  id=\"AccntddlValue" + intRowBodyCount + "\" style=\"display:none;\"  ></div>");
                sb.Append("</select></div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
        }
        return sb.ToString();
    }

    public static string UpdatePrintVersionMapping(clsEntity_Account_Setting objEntity)
    {
        clsBusiness_Account_Setting objBusiness = new clsBusiness_Account_Setting();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();
        StringBuilder sb = new StringBuilder();
        sb.Append("<table id=\"tblPrintVersions\" class=\"table table-bordered\"  >");
        sb.Append("<thead class=\"thead1\">");
        sb.Append("<tr >");
        sb.Append("<th class=\"col-md-6 tr_l\" > VERSION");
        sb.Append("</th >");
        sb.Append("<th class=\"col-md-6 tr_l\">DEFAULT VERSIONS");
        sb.Append("</th >");
        sb.Append("</th >");
        sb.Append("</tr>");
        sb.Append("</thead>");
        sb.Append("<tbody>");
        DataTable dtAccountGrp = objBusiness.ReadPrintVersions(objEntity);
        DataTable dtVoucherType = objBusiness.ReadVoucherType(objEntity);
        int f = 0;
        for (int intRowCount = 0; intRowCount < dtVoucherType.Rows.Count; intRowCount++)
        {
            sb.Append("<tr >");
            sb.Append("<td class=\"tr_l\" id=\"Vocher_Id" + intRowCount + "\" style=\"display:none;\" >" + intRowCount + "</td>");
            sb.Append("<td class=\"tr_l\" style=\"\" >" + dtVoucherType.Rows[intRowCount]["VOCHR_TYPE"].ToString() + "</td>");
            sb.Append("<td class=\"tr_l\" style=\" \" >");
            sb.Append("<div id=\"divPrintVrsn\"><select onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl\" id=\"ddlPrintVersion" + intRowCount + "\"  onchange=\"return changePrintVersion(" + intRowCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");

            sb.Append("<option>-Select Print Version-</option>");
            for (int intRowCnt = 0; intRowCnt < dtAccountGrp.Rows.Count; intRowCnt++)
            {
                if (dtAccountGrp.Rows.Count > 0)
                {
                    if (dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_ID"].ToString() == dtVoucherType.Rows[intRowCount]["PRNT_VRN_ID"].ToString())
                    {
                        f = 1;
                        sb.Append("<option selected value=\"" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_NAME"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_NAME"].ToString() + "</option>");
                    }
                }
                else
                {
                    sb.Append("<option value=\"" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_NAME"].ToString() + "</option>");
                }
                //  }
                //else
                //{
                //    sb.Append("<option value=\"" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_ID"].ToString() + "\">" + dtAccountGrp.Rows[intRowCnt]["PRNT_VRN_NAME"].ToString() + "</option>");
                //}
            }

            //    if (dt.Rows.Count > 0)
            // {
            if (dtVoucherType.Rows[intRowCount]["DFLT_VERSION_ID"].ToString() != "")
            {
                sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"ddlPrintVersion_Id" + intRowCount + "\" name=\"ddlPrintVersion_Id" + intRowCount + "\" value=\"" + dtVoucherType.Rows[intRowCount]["PRNT_VRN_ID"].ToString() + "\" /></td>");
            }
            //  }
            else
            {
                sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"ddlPrintVersion_Id" + intRowCount + "\" name=\"ddlPrintVersion_Id" + intRowCount + "\"  /></td>");
            }
            sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"ddlVocher_Id" + intRowCount + "\" name=\"ddlVocher_Id" + intRowCount + "\" value=\"" + dtVoucherType.Rows[intRowCount]["VOCHR_TYP_ID"].ToString() + "\" /></td>");

            sb.Append("<div style=\"display:none;\" id=\"divVersion\"><input  id=\"VersionddlValue\" style=\"display:none;\"  ></div>");
            sb.Append("</select></div></td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");
        //DivPrintVersion.InnerHtml = sb.ToString();
        return sb.ToString();
    }

    public static string UpdatePrimaryAccountGrpMapping(clsEntity_Account_Setting objEntity, string RestritionStatus)
    {
        clsBusiness_Account_Setting objBusiness = new clsBusiness_Account_Setting();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        objEntity.UserId = 0;
        objEntityCommon.Organisation_Id = objEntity.OrgId;
        objEntityCommon.CorporateID = objEntity.CorpId;
        DataTable dtAccountGrps = objBusinessCommon.ReadAccountGrps(objEntityCommon);
        StringBuilder sb = new StringBuilder();
        DataTable dtPrimaryGrps = objBusiness.ReadPrimaryGrpsMapped(objEntity);
        if (dtPrimaryGrps.Rows.Count > 0)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            sb.Append("<table id=\"tblPrimaryAccntGrp\" class=\"table table-bordered\">");
            sb.Append("<thead class=\"thead1\">");
            sb.Append("<tr >");
            sb.Append("<th class=\"col-md-6 tr_l\" >MODULE");
            sb.Append("</th >");
            sb.Append("<th class=\"col-md-6 tr_l\">PRIMARY ACCOUNT GROUP");
            sb.Append("</th >");
            sb.Append("</th >");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");
            //   HiddenModuleCount.Value = dtPrimaryGrps.Rows.Count.ToString();

            for (int intRowBodyCount = 0; intRowBodyCount < dtPrimaryGrps.Rows.Count; intRowBodyCount++)
            {
                sb.Append("<tr>");

                sb.Append("<td class=\"tr_l\" id=\"td_PrmryCnt\" style=\"display:none;\" >" + intRowBodyCount + "</td>");
                sb.Append("<td class=\"tr_l\" >" + dtPrimaryGrps.Rows[intRowBodyCount]["PRMRYGRP_NAME"].ToString() + "</td>");

                sb.Append("<td class=\"tr_l\" >");
                sb.Append("<div id=\"divPrmryAccntGrps" + intRowBodyCount + "\">");
                DataTable dtChkPrimary = new DataTable(); ;
                if (dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() != "")
                {
                    objEntity.AccountGrpId = Convert.ToInt32(dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString());
                    dtChkPrimary = objBusiness.CheckPrimaryAccountGrp(objEntity);
                }
                if (RestritionStatus != "1")
                {
                    if (dtChkPrimary.Rows.Count > 0)
                    {
                        if (dtChkPrimary.Rows[0]["PYMNT_ACC_CNT"].ToString() != "0" || dtChkPrimary.Rows[0]["RCPT_ACC_CNT"].ToString() != "0" || dtChkPrimary.Rows[0]["PRCHS_ACC_CNT"].ToString() != "0" || dtChkPrimary.Rows[0]["SALE_ACC_CNT"].ToString() != "0")
                            sb.Append("<select readonly style=\"pointer-events: none;\" onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl\" id=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" name=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" onchange=\"return ChangePrimaryGrp(" + intRowBodyCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        else
                            sb.Append("<select onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl\" id=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" name=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" onchange=\"return ChangePrimaryGrp(" + intRowBodyCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    }
                    else
                    {
                            sb.Append("<select onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl\" id=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" name=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" onchange=\"return ChangePrimaryGrp(" + intRowBodyCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    }
                }
                else
                {
                    sb.Append("<select onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 ddl\" id=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" name=\"ddlPrmryAccountGrp" + intRowBodyCount + "\" onchange=\"return ChangePrimaryGrp(" + intRowBodyCount + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                }
                sb.Append("<option>-Select Account Group-</option>");
                int f = 0;
                for (int intRowCount = 0; intRowCount < dtAccountGrps.Rows.Count; intRowCount++)
                {
                    if (dtAccountGrps.Rows[intRowCount]["ACNT_GRP_ID"].ToString() == dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString())
                    {
                        f = 1;
                        sb.Append("<option selected value=\"" + dtAccountGrps.Rows[intRowCount]["ACNT_GRP_ID"].ToString() + "\">" + dtAccountGrps.Rows[intRowCount]["ACNT_GRP_NAME"].ToString() + "</option>");
                    }
                    else
                    {
                        sb.Append("<option value=\"" + dtAccountGrps.Rows[intRowCount]["ACNT_GRP_ID"].ToString() + "\">" + dtAccountGrps.Rows[intRowCount]["ACNT_GRP_NAME"].ToString() + "</option>");
                    }
                }
                if (dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() != "")
                {
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() + "\">" + dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_NAME"].ToString() + "</option>");
                    }
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"tdPrmryAccntGrpId" + intRowBodyCount + "\" name=\"tdPrmryAccntGrpId" + intRowBodyCount + "\" value=\"" + dtPrimaryGrps.Rows[intRowBodyCount]["ACNT_GRP_ID"].ToString() + "\" /></td>");
                }
                else
                {
                    sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"tdPrmryAccntGrpId" + intRowBodyCount + "\" name=\"tdPrmryAccntGrpId" + intRowBodyCount + "\"  /></td>");
                }
                sb.Append("<td class=\"tr_l\" style=\"display:none;\" ><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"tdPrmryId" + intRowBodyCount + "\" name=\"tdPrmryId" + intRowBodyCount + "\" value=\"" + dtPrimaryGrps.Rows[intRowBodyCount]["PRMRYGRP_ID"].ToString() + "\" /></td>");
                sb.Append("</select></div>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
        }
        return sb.ToString();
    }

    public void FinancialYearLoad()
    {
        clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();
        clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
        if (Session["USERID"] != null)
        {
            objEntityAccount.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccount.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccount.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBussinessAccount.ReadFinancialYear(objEntityAccount);
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("FINCYR_ID", typeof(int));
        dtDetail.Columns.Add("FINCYR_START_DT", typeof(string));
        dtDetail.Columns.Add("FINCYR_END_DT", typeof(string));
        dtDetail.Columns.Add("FINCYR_STATUS", typeof(int));
        dtDetail.Columns.Add("FINCYR_DEFAULTNAME", typeof(string));
        for (int intCount = 0; intCount < dtSubConrt.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["FINCYR_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["FINCYR_ID"].ToString());
            drDtl["FINCYR_START_DT"] = dtSubConrt.Rows[intCount]["START_DATE"].ToString();
            drDtl["FINCYR_END_DT"] = dtSubConrt.Rows[intCount]["END_DATE"].ToString();
            drDtl["FINCYR_STATUS"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["FINCYR_STATUS"].ToString());
            drDtl["FINCYR_DEFAULTNAME"] = dtSubConrt.Rows[intCount]["FINCYR_DEFAULTNAME"].ToString();
            dtDetail.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenFinancialYear.Value = strJson;
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

    public class clsWBDataGroup
    {
        public string MODULEGROUPID { get; set; }
        //  public string ACCOUNTGROUPID { get; set; }

    }
    public class clsWBDataHead
    {
        public string MODULEHEADID { get; set; }
        //   public string LEDGERID { get; set; }
    }
    public class clsVersionPrint
    {
        public string VERSIONID { get; set; }
        //   public string LEDGERID { get; set; }
    }
    public class clsWBDataFY
    {
        public string FYID { get; set; }
        //public string STRATDATE { get; set; }
        //public string ENDDATE { get; set; }
        //public string DEFAULTNAME { get; set; }
        public string CHECK { get; set; }
    }

    public class clsWBDataPrmryGrp
    {
        public string PRIMARYGRP { get; set; }
    }
    [WebMethod]
    public static string[] AccountSetting(string intuserid, string intorgid, string intcorpid, string PrimaryGrp, string PrmryAccountGrp)
    {
        string[] result = new string[4];

        try
        {
            clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();
            clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
            objEntityAccount.OrgId = Convert.ToInt32(intorgid);
            objEntityAccount.UserId = Convert.ToInt32(intuserid);
            objEntityAccount.CorpId = Convert.ToInt32(intcorpid);

            objEntityAccount.AccountGrpId = Convert.ToInt32(PrmryAccountGrp);
            objEntityAccount.PrimaryGrpId = Convert.ToInt32(PrimaryGrp);
            objBussinessAccount.InsertPrimaryAccountGroup(objEntityAccount);
        }
        catch (Exception e)
        {

        }
        return result;
    }
    [WebMethod]
    public static string[] LoadOthetsAccountSetting(string intuserid, string intorgid, string intcorpid, string RestritionStatus)
    {
        string[] result = new string[4];

        try
        {
            clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();
            clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
            objEntityAccount.OrgId = Convert.ToInt32(intorgid);
            objEntityAccount.UserId = Convert.ToInt32(intuserid);
            objEntityAccount.CorpId = Convert.ToInt32(intcorpid);
            result[0] = UpdateAccountGrpMapping(objEntityAccount);
            result[1] = UpdateAccountHeadMapping(objEntityAccount);
            result[3] = UpdatePrimaryAccountGrpMapping(objEntityAccount, RestritionStatus);
        }
        catch (Exception e)
        {

        }
        return result;
    }
    
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Account_Setting objEntityAccount = new clsEntity_Account_Setting();
        clsBusiness_Account_Setting objBussinessAccount = new clsBusiness_Account_Setting();
        List<clsEntity_Account_Setting> ObjEntityGroup = new List<clsEntity_Account_Setting>();
        List<clsEntity_Account_Setting> ObjEntityHead = new List<clsEntity_Account_Setting>();
        List<clsEntity_Account_Setting> ObjEntityFinancialYear = new List<clsEntity_Account_Setting>();
        List<clsEntity_Account_Setting> ObjEntityFYrCancel = new List<clsEntity_Account_Setting>();
        List<clsEntity_Account_Setting> ObjEntityVersions = new List<clsEntity_Account_Setting>();
        List<clsEntity_Account_Setting> ObjEntityPrmryGrpList = new List<clsEntity_Account_Setting>();


        clsEntityCommon objentcommn = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityAccount.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccount.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccount.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        int CurrentFY = 0;
        DataTable dyChkFY = new DataTable();
        if (HiddenFieldSaveAccount.Value != "")
        {
            string jsonData = HiddenFieldSaveAccount.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string k = h.Replace("}\",", "},");


            List<clsWBDataPrmryGrp> objWBPrmryGrp = new List<clsWBDataPrmryGrp>();
            objWBPrmryGrp = JsonConvert.DeserializeObject<List<clsWBDataPrmryGrp>>(k);
            foreach (clsWBDataPrmryGrp objclsWBData2 in objWBPrmryGrp)
            {
                if (objclsWBData2.PRIMARYGRP != "" && objclsWBData2.PRIMARYGRP != null)
                {
                    string[] Modulevalues = objclsWBData2.PRIMARYGRP.Split(',');
                    for (int i = 0; i < Modulevalues.Length; i++)
                    {
                        clsEntity_Account_Setting objEntityPrmryGrp = new clsEntity_Account_Setting();

                        if (Request.Form["ddlPrmryAccountGrp" + Modulevalues[i]] != "")
                        {
                            objEntityPrmryGrp.AccountGrpId = Convert.ToInt32(Request.Form["ddlPrmryAccountGrp" + Modulevalues[i]]);
                        }
                        string rop = Request.Form["tdPrmryId" + Modulevalues[i]];
                        objEntityPrmryGrp.PrimaryGrpId = Convert.ToInt32(Request.Form["tdPrmryId" + Modulevalues[i]]);
                        ObjEntityPrmryGrpList.Add(objEntityPrmryGrp);

                    }
                }
            }


            List<clsWBDataGroup> objWBDataList = new List<clsWBDataGroup>();
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBDataGroup>>(k);
            foreach (clsWBDataGroup objclsWBData in objWBDataList)
            {
                if (objclsWBData.MODULEGROUPID != "" && objclsWBData.MODULEGROUPID != null)
                {
                    string[] Modulevalues = objclsWBData.MODULEGROUPID.Split(',');
                    for (int i = 0; i < Modulevalues.Length; i++)
                    {
                        clsEntity_Account_Setting objEntity_Grp = new clsEntity_Account_Setting();
                        string rt = Request.Form["AccountGrp_Id" + Modulevalues[i]];
                        if (Request.Form["AccountGrp_Id" + Modulevalues[i]].ToString() != "")
                        {
                            objEntity_Grp.MasterId = Convert.ToInt32(Request.Form["AccountGrp_Id" + Modulevalues[i]]);
                        }
                        string rop = Request.Form["Account_Id" + Modulevalues[i]];
                        objEntity_Grp.ModuleId = Convert.ToInt32(Request.Form["Account_Id" + Modulevalues[i]]);
                        objEntity_Grp.AccountGrpId = Convert.ToInt32(Request.Form["ddlAccountGrp_Id" + Modulevalues[i]]);
                        ObjEntityGroup.Add(objEntity_Grp);


                    }
                }
            }
            List<clsWBDataHead> objWBDataList2 = new List<clsWBDataHead>();
            objWBDataList2 = JsonConvert.DeserializeObject<List<clsWBDataHead>>(k);
            foreach (clsWBDataHead objclsWBData2 in objWBDataList2)
            {
                if (objclsWBData2.MODULEHEADID != "" && objclsWBData2.MODULEHEADID != null)
                {
                    string[] Modulevalues = objclsWBData2.MODULEHEADID.Split(',');
                    for (int i = 0; i < Modulevalues.Length; i++)
                    {
                        clsEntity_Account_Setting objEntity_Head = new clsEntity_Account_Setting();

                        if (Request.Form["AccountHead_Id" + Modulevalues[i]] != "")
                        {
                            objEntity_Head.MasterId = Convert.ToInt32(Request.Form["AccountHead_Id" + Modulevalues[i]]);
                        }
                        string rop = Request.Form["AccountH_Id" + Modulevalues[i]];
                        objEntity_Head.ModuleId = Convert.ToInt32(Request.Form["AccountH_Id" + Modulevalues[i]]);

                        objEntity_Head.LedgerId = Convert.ToInt32(Request.Form["ddlAccountHead_Id" + Modulevalues[i]]);
                        ObjEntityHead.Add(objEntity_Head);

                    }
                }
            }
            List<clsVersionPrint> objWBPrint = new List<clsVersionPrint>();
            objWBPrint = JsonConvert.DeserializeObject<List<clsVersionPrint>>(k);
            foreach (clsVersionPrint objclsWBData2 in objWBPrint)
            {
                if (objclsWBData2.VERSIONID != "" && objclsWBData2.VERSIONID != null)
                {
                    string[] Modulevalues = objclsWBData2.VERSIONID.Split(',');
                    for (int i = 0; i < Modulevalues.Length; i++)
                    {
                        clsEntity_Account_Setting objEntity_Version = new clsEntity_Account_Setting();

                        if (Request.Form["ddlPrintVersion_Id" + Modulevalues[i]] != "")
                        {
                            if (Request.Form["ddlPrintVersion_Id" + Modulevalues[i]] != "-Select Print Version-" && Request.Form["ddlPrintVersion_Id" + Modulevalues[i]] != null)
                            {
                                objEntity_Version.VersionID = Convert.ToInt32(Request.Form["ddlPrintVersion_Id" + Modulevalues[i]]);
                            }
                        }
                        string rop = Request.Form["ddlVocher_Id" + Modulevalues[i]];
                        objEntity_Version.VoucherID = Convert.ToInt32(Request.Form["ddlVocher_Id" + Modulevalues[i]]);
                        ObjEntityVersions.Add(objEntity_Version);

                    }
                }
            }
            List<clsWBDataFY> objWBDataList3 = new List<clsWBDataFY>();
            objWBDataList3 = JsonConvert.DeserializeObject<List<clsWBDataFY>>(k);
            foreach (clsWBDataFY objclsWBData3 in objWBDataList3)
            {

                if (objclsWBData3.FYID != "" && objclsWBData3.FYID != null)
                {
                    string[] Modulevalues = objclsWBData3.FYID.Split(',');
                    for (int i = 0; i < Modulevalues.Length; i++)
                    {
                        clsEntity_Account_Setting objEntity_Yr = new clsEntity_Account_Setting();
                        string sds = Request.Form["tdDtlIdTempid" + Modulevalues[i]];
                        if (Request.Form["tdDtlIdTempid" + Modulevalues[i]] != "")
                        {
                            objEntity_Yr.FinancialYearID = Convert.ToInt32(Request.Form["tdDtlIdTempid" + Modulevalues[i]]);
                            if (Modulevalues[i] == objclsWBData3.CHECK)
                            {
                                HiddenFinancialYrID.Value = Request.Form["tdDtlIdTempid" + Modulevalues[i]];
                            }
                        }
                        objEntity_Yr.StartDate = objCommon.textToDateTime(Request.Form["StartDateFY" + Modulevalues[i]]);

                        objEntity_Yr.EndDate = objCommon.textToDateTime(Request.Form["EndDateFY" + Modulevalues[i]]);

                        objEntity_Yr.DefaultName = Request.Form["DefaultName" + Modulevalues[i]];
                        if (Modulevalues[i] == objclsWBData3.CHECK)
                        {
                            objEntity_Yr.FinancialYearStatus = 1;
                        }
                        else
                        {
                            objEntity_Yr.FinancialYearStatus = 0;
                        }
                        ObjEntityFinancialYear.Add(objEntity_Yr);
                    }
                }
            }
            string strCanclDtlId = "";
            string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
            if (HiddenFYCnclId.Value != "" && HiddenFYCnclId.Value != null)
            {
                strCanclDtlId = HiddenFYCnclId.Value;
                strarrCancldtlIdsGrp = strCanclDtlId.Split(',');

            }
            foreach (string strDtlId in strarrCancldtlIdsGrp)
            {
                if (strDtlId != "" && strDtlId != null)
                {
                    int intDtlId = Convert.ToInt32(strDtlId);
                    clsEntity_Account_Setting objEntity_Yr = new clsEntity_Account_Setting();
                    objEntity_Yr.FinancialYearID = Convert.ToInt32(strDtlId);
                    ObjEntityFYrCancel.Add(objEntity_Yr);
                    DataTable dtSubConrt = objBussinessAccount.ReadFinancialYear(objEntityAccount);
                    if (dtSubConrt.Rows.Count > 0)
                    {
                        for (int intCount = 0; intCount < dtSubConrt.Rows.Count; intCount++)
                        {
                            if (dtSubConrt.Rows[intCount]["FINCYR_STATUS"].ToString() == "1")
                            {
                                if (dtSubConrt.Rows[intCount]["FINCYR_ID"].ToString() == strDtlId)
                                {
                                    objEntityAccount.FinancialYearID = Convert.ToInt32(strDtlId);
                                    dyChkFY = objBussinessAccount.CheckFinancialYear(objEntityAccount);
                                }
                            }
                        }

                    }
                }
            }

        }
        if (dyChkFY.Rows.Count > 0)
        {
            Response.Redirect("fms_Account_Setting.aspx?InsUpd=Fail");

        }
        else
        {
            objBussinessAccount.InsertAccount_Setting(objEntityAccount, ObjEntityGroup, ObjEntityHead, ObjEntityFinancialYear, ObjEntityFYrCancel, ObjEntityVersions, ObjEntityPrmryGrpList);

            if (HiddenFinancialYrID.Value != "")
            {
                Session["FINCYRID"] = Convert.ToInt32(HiddenFinancialYrID.Value);
            }
            else
            {
                if (Session["CORPOFFICEID"] != null)
                {
                    DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYear(objentcommn);
                    if (dtfinaclYear.Rows.Count > 0)
                    {
                        if (dtfinaclYear.Rows[0]["FINCYR_ID"].ToString() != "")
                        {
                            Session["FINCYRID"] = Convert.ToInt32(dtfinaclYear.Rows[0]["FINCYR_ID"].ToString());
                        }
                    }
                }
            }

            if (clickedButton.ID == "btnsave")
            {
                Response.Redirect("fms_Account_Setting.aspx?InsUpd=Ins");
            }
        }

    }
}