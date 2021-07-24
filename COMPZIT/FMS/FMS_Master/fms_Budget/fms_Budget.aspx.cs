using System;
using System.Collections.Generic;
using System.Web.UI;
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
using Newtonsoft.Json;

public partial class FMS_FMS_Master_fms_Budget_fms_Budget : System.Web.UI.Page
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
            HiddenView.Value = "";
            txtBudgtName.Focus();
            YearLoad();
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
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID                                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }
            hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            // for adding comma
             clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                //HiddenDefultCrncAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }


            int intUsrRolMstrId = 0, intConfirm = 0, intReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Budget);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            btnCreateBudgt.Visible = false;
            txtBudgtName.Disabled = true;
            ddlMode.Disabled = true;
            ddlYear.Disabled = true;
            DivModeType.Visible = false;
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                lblEntry.Text = "Edit Monthly Budgeting";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                bttnsavecls.Visible = false;
                btnUpdate.Visible = true;
                btnUpdatecls.Visible = true;
                btnCancel.Visible = true;
                Update(strId, intConfirm, intReopen);
                DisableMonths();
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                lblEntry.Text = "View Monthly Budgeting";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                bttnsavecls.Visible = false;
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnConfirm.Visible = false;
                btnCancel.Visible = true;
                View(strId, intConfirm, intReopen);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                // sb.Append("<tr>");
                // sb.Append("<td colspan=\"16\" style=\"text-align: center;\">No data available</td></tr>");
                // tabMainBody.InnerHtml = sb.ToString();

                lblEntry.Text = "Add Monthly Budgeting";
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnConfirm.Visible = false;
                btnCreateBudgt.Visible = true;
                txtBudgtName.Disabled = false;
                ddlMode.Disabled = false;
                ddlYear.Disabled = false;
                bttnsave.Visible = false;
                bttnsavecls.Visible = false;
                addTable();
            }
        }
        if (Request.QueryString["InsUpd"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
            }
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
            }
            else if (strInsUpd == "Cnf")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfMsg", "SuccessCnfMsg();", true);
            }
            else if (strInsUpd == "UpdCancl")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
            }
            else if (strInsUpd == "UpdConfm")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CanclCnfMsg", "CanclCnfMsg();", true);
            }
        }
    }
    protected void YearLoad()
    {
        ddlYear.Items.Clear();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityLayerBudget objEntityLayerBudgt = new clsEntityLayerBudget();
        clsBusinessLayerBudget objBusinessLayerBudgt = new clsBusinessLayerBudget();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerBudgt.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerBudgt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtfinaclYear = objBusinessLayerBudgt.ReadFinancialYear(objEntityLayerBudgt);
        string strCurrentDate = "";
        string[] split;
        if (dtfinaclYear.Rows.Count > 0)
        {
            //for (int i = 0; i < dtfinaclYear.Rows.Count; i++)
            //{
            //    if (dtfinaclYear.Rows[i]["FINCYR_DEFAULTNAME"].ToString() != "")
            //        ddlYear.Items.Add(dtfinaclYear.Rows[i]["FINCYR_DEFAULTNAME"].ToString());
            //}
            if (dtfinaclYear.Rows.Count > 0)
            {
                ddlYear.DataSource = dtfinaclYear;
                ddlYear.DataTextField = "FINCYR_DEFAULTNAME";
                ddlYear.DataValueField = "FINCYR_ID";
                ddlYear.DataBind();
            }
            //  strCurrentDate = dtfinaclYear.Rows[0]["FINCYR_DEFAULTNAME"].ToString();
            // split = strCurrentDate.Split('-');
        }
        else
        {
            strCurrentDate = objBusiness.LoadCurrentDateInString();
            split = strCurrentDate.Split('-');

            var currentYear = Convert.ToInt32(split[2]);
            for (int i = 0; i <= 10; i++)
            {
                ddlYear.Items.Add((currentYear + i).ToString());
            }
        }
    }

    public void addTable()
    {
        try
        {
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            clsBusinessLayerBudget objBusinessLayerBdgt = new clsBusinessLayerBudget();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            DataTable dtLedgerDeb = new DataTable();
            objEntityLayerStock.ConfirmSts = Convert.ToInt32(ddlMode.Value);
            dtLedgerDeb = objBusinessLayerBdgt.ReadLedgerDdl(objEntityLayerStock);

            DataTable dtCostCentr = objBusinessLayerStock.ReadCostCentrDdl(objEntityLayerStock);
            if (dtCostCentr.Rows.Count > 0)
            {
                ddlMainCostCenter.DataSource = dtCostCentr;
                ddlMainCostCenter.DataTextField = "COSTCNTR_NAME";
                ddlMainCostCenter.DataValueField = "COSTCNTR_ID";
                ddlMainCostCenter.DataBind();
            }
            ddlMainCostCenter.Items.Insert(0, "-Select Cost Centre-");
            if (dtLedgerDeb.Rows.Count > 0)
            {
                ddlMainLedger.DataSource = dtLedgerDeb;
                ddlMainLedger.DataTextField = "LDGR_NAME";
                ddlMainLedger.DataValueField = "LDGR_ID";
                ddlMainLedger.DataBind();
            }
            ddlMainLedger.Items.Insert(0, "-Select Ledger-");

            //StringBuilder sb = new StringBuilder();


            //sb.Append("<tr id=\"MainRow0\">");
            //sb.Append("<td style=\"display:none;\">0</td>");
            //sb.Append("<td style=\"display:none;\"></td>");
            //sb.Append("<td colspan=\"16\" style=\"padding:0px;\">");
            //sb.Append("<table class=\"table table-bordered\" id=\"tabSub0\">");
            //sb.Append("<tbody >");


            //sb.Append("<tr id=\"SubRow00\">");
            //sb.Append("<td style=\"display:none;\">0</td>");
            //sb.Append("<td style=\"display:none;\"></td>");
            //sb.Append("<td style=\"8%\" rowspan=\"1000\">");
            //sb.Append("<div id=\"divddlLed00\"><select  onblur=\"IncrmntConfrmCounter();\" class=\"form-control ddl\" id=\"ddlLed00\" onchange=\"return changeLedger(0,0);\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
            //sb.Append("<option>-Select Ledger-</option>");
            //for (int intRowCount = 0; intRowCount < dtLedgerDeb.Rows.Count; intRowCount++)
            //{
            //sb.Append("<option value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
            //}
            //sb.Append("</select></div>");

            //sb.Append("<span style=\"display:inline-block;float:right;width:100%\">");

            //sb.Append("<button class=\"btn btn-primary\" title=\"Add\" style=\"margin-top:2%;width:47%;\" id=\"btnAddMain00\" onclick=\"return addMainTabRow(0,0);\">");
            //sb.Append("<span class=\"fa fa-plus\" id=\"Span1\" style=\"display: block;\">&nbsp;</span>");
            //sb.Append("</button>");
            //sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;width:47%;margin-left:5%;\" id=\"btnDelMain00\" onclick=\"return delMainTabRow(0,0);\">");
            //sb.Append("<span class=\"fa fa-trash\" id=\"chevron-left\" style=\"display: block;\">&nbsp;</span>");
            //sb.Append("</button>");
            //sb.Append("</span>");

            //sb.Append("</td>");
            ////sb.Append("<td style=\"width:6.5%\">");

            ////sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntJan00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntFeb00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Feb');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntMar00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Mar');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntApr00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Apr');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntMay00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'May');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntJun00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Jun');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntJul00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Jul');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntAug00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Aug');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntSep00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Sep');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntOct00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Oct');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntNov00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Nov');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntDec00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Dec');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:9%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtTotal00\" type=\"text\"  onchange=\"changeCostAmnt(0,0,'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("</tr>");

            //sb.Append("<tr id=\"SubRow01\">");
            //sb.Append("<td style=\"display:none;\">1</td>");
            //sb.Append("<td style=\"display:none;\"></td>");
            //sb.Append("<td style=\"width:11%\">");
            //sb.Append("<div id=\"divddlCost01\"><select onblur=\"IncrmntConfrmCounter();\" class=\"form-control ddl\" id=\"ddlCost01\" onchange=\"return changeCostCentr(1,0);\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\"  >");
            //sb.Append("<option>-Select Cost Center-</option>");
            //for (int intRowCount = 0; intRowCount < dtCostCentr.Rows.Count; intRowCount++)
            //{
            //    sb.Append("<option value=\"" + dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() + "\">" + dtCostCentr.Rows[intRowCount]["COSTCNTR_NAME"].ToString() + "</option>");
            //}
            //sb.Append("</select></div>");

            //sb.Append("<span style=\"display:inline-block;float:right;width:100%\">");

            //sb.Append("<button class=\"btn btn-primary\" title=\"Add\" style=\"margin-top:2%;width:47%;\" id=\"btnAddSub01\" onclick=\"return addSubRow(1,0);\">");
            //sb.Append("<span class=\"fa fa-plus\" id=\"Span3\" style=\"display: block;\">&nbsp;</span>");
            //sb.Append("</button>");
            //sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;width:47%;margin-left:5%;\" id=\"btnDelSub01\" onclick=\"return delSubRow(1,0);\">");
            //sb.Append("<span class=\"fa fa-trash\" id=\"Span2\" style=\"display: block;\">&nbsp;</span>");
            //sb.Append("</button>");
            //sb.Append("</span>");

            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntJan01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntFeb01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Feb');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntMar01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Mar');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntApr01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Apr');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntMay01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'May');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntJun01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Jun');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntJul01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Jul');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntAug01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Aug');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntSep01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Sep');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntOct01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Oct');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntNov01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Nov');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            //sb.Append("<td style=\"width:6.5%border:1px solid #e4e4e3;\">");
            //sb.Append("<input style=\"text-align:right;\" class=\"form-control\" value=\"\" id=\"txtAmntDec01\" type=\"text\"  onchange=\"changeCostAmnt(1,0,'Dec');\" onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
            //sb.Append("</td>");
            // sb.Append("</tr>");




            // sb.Append("</tbody>");
            // sb.Append("</table>");
            // sb.Append("</td>");
            // sb.Append("</tr>");


            //tabMainBody.InnerHtml = sb.ToString();
        }
        catch (Exception)
        {

        }
    }
    public class clsLedgrData
    {
        public string MAINTABID { get; set; }
        public string LEDGRTABID { get; set; }
        public string LEDGRID { get; set; }
        public string LEDGRAMNTJAN { get; set; }
        public string LEDGRAMNTFEB { get; set; }
        public string LEDGRAMNTMAR { get; set; }
        public string LEDGRAMNTAPR { get; set; }
        public string LEDGRAMNTMAY { get; set; }
        public string LEDGRAMNTJUN { get; set; }
        public string LEDGRAMNTJUL { get; set; }
        public string LEDGRAMNTAUG { get; set; }
        public string LEDGRAMNTSEP { get; set; }
        public string LEDGRAMNTOCT { get; set; }
        public string LEDGRAMNTNOV { get; set; }
        public string LEDGRAMNTDEC { get; set; }
        public string LEDGRTOTALAMT { get; set; }
    }
    public class clsCostCntrData
    {
        public string MAINTABID { get; set; }
        public string SUBTABID { get; set; }
        public string COSTCENTRTABID { get; set; }
        public string COSTCENTRID { get; set; }
        public string COSTCENTRAMNTJAN { get; set; }
        public string COSTCENTRAMNTFEB { get; set; }
        public string COSTCENTRAMNTMAR { get; set; }
        public string COSTCENTRAMNTAPR { get; set; }
        public string COSTCENTRAMNTMAY { get; set; }
        public string COSTCENTRAMNTJUN { get; set; }
        public string COSTCENTRAMNTJUL { get; set; }
        public string COSTCENTRAMNTAUG { get; set; }
        public string COSTCENTRAMNTSEP { get; set; }
        public string COSTCENTRAMNTOCT { get; set; }
        public string COSTCENTRAMNTNOV { get; set; }
        public string COSTCENTRAMNTDEC { get; set; }
        public string COSTCENTRTOTALAMT { get; set; }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        try
        {
            clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityLayerStock.BudgtName = HiddenFieldName.Value;
            objEntityLayerStock.Year = Convert.ToInt32(ddlYear.Value);
            objEntityLayerStock.Mode = Convert.ToInt32(HiddenFieldMode.Value);
            objEntityLayerStock.LedgerCC_Mode = Convert.ToInt32(HiddenFieldLedgerOrCC.Value);
            List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityBudgetLedgerDtl>();
            List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityBudgetCostCntrDtl>();

            string jsonData = HiddenFieldBudgtDataLedgr.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


            if (HiddenFieldBudgtDataLedgr.Value != "" && HiddenFieldBudgtDataLedgr.Value != "[]" && HiddenFieldBudgtDataLedgr.Value != null)
            {
                foreach (clsLedgrData objclsTVData in objTVDataList5)
                {
                    clsEntityBudgetLedgerDtl objEntityDtl = new clsEntityBudgetLedgerDtl();
                    objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                    objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                    if (objclsTVData.LEDGRAMNTJAN != "")
                    {
                        objEntityDtl.TotAmntJan = Convert.ToDecimal(objclsTVData.LEDGRAMNTJAN);
                    }
                    if (objclsTVData.LEDGRAMNTFEB != "")
                    {
                        objEntityDtl.TotAmntFeb = Convert.ToDecimal(objclsTVData.LEDGRAMNTFEB);
                    }
                    if (objclsTVData.LEDGRAMNTMAR != "")
                    {
                        objEntityDtl.TotAmntMar = Convert.ToDecimal(objclsTVData.LEDGRAMNTMAR);
                    }
                    if (objclsTVData.LEDGRAMNTAPR != "")
                    {
                        objEntityDtl.TotAmntApr = Convert.ToDecimal(objclsTVData.LEDGRAMNTAPR);
                    }
                    if (objclsTVData.LEDGRAMNTMAY != "")
                    {
                        objEntityDtl.TotAmntMay = Convert.ToDecimal(objclsTVData.LEDGRAMNTMAY);
                    }
                    if (objclsTVData.LEDGRAMNTJUN != "")
                    {
                        objEntityDtl.TotAmntJun = Convert.ToDecimal(objclsTVData.LEDGRAMNTJUN);
                    }
                    if (objclsTVData.LEDGRAMNTJUL != "")
                    {
                        objEntityDtl.TotAmntJul = Convert.ToDecimal(objclsTVData.LEDGRAMNTJUL);
                    }
                    if (objclsTVData.LEDGRAMNTAUG != "")
                    {
                        objEntityDtl.TotAmntAug = Convert.ToDecimal(objclsTVData.LEDGRAMNTAUG);
                    }
                    if (objclsTVData.LEDGRAMNTSEP != "")
                    {
                        objEntityDtl.TotAmntSep = Convert.ToDecimal(objclsTVData.LEDGRAMNTSEP);
                    }
                    if (objclsTVData.LEDGRAMNTOCT != "")
                    {
                        objEntityDtl.TotAmntOct = Convert.ToDecimal(objclsTVData.LEDGRAMNTOCT);
                    }
                    if (objclsTVData.LEDGRAMNTNOV != "")
                    {
                        objEntityDtl.TotAmntNov = Convert.ToDecimal(objclsTVData.LEDGRAMNTNOV);
                    }
                    if (objclsTVData.LEDGRAMNTDEC != "")
                    {
                        objEntityDtl.TotAmntDec = Convert.ToDecimal(objclsTVData.LEDGRAMNTDEC);
                    }
                    if (objclsTVData.LEDGRTOTALAMT != "")
                    {
                        objEntityDtl.LedgerTotal = Convert.ToDecimal(objclsTVData.LEDGRTOTALAMT);
                    }
                    objEntityJrnlLedgrList.Add(objEntityDtl);
                }
            }

            jsonData = HiddenFieldBudgtDataCostCentr.Value;
            c = jsonData.Replace("\"{", "\\{");
            d = c.Replace("\\n", "\r\n");
            g = d.Replace("\\", "");
            h = g.Replace("}\"]", "}]");
            i = h.Replace("}\",", "},");
            List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
            objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


            if (HiddenFieldBudgtDataCostCentr.Value != "" && HiddenFieldBudgtDataCostCentr.Value != "[]" && HiddenFieldBudgtDataCostCentr.Value != null)
            {
                foreach (clsCostCntrData objclsTVData in objTVDataList6)
                {
                    if (objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                    {
                        clsEntityBudgetCostCntrDtl objEntityDtl = new clsEntityBudgetCostCntrDtl();
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        //  objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                        objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);

                        if (objclsTVData.COSTCENTRAMNTJAN != "")
                        {
                            objEntityDtl.TotAmntJan = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJAN);
                        }
                        if (objclsTVData.COSTCENTRAMNTFEB != "")
                        {
                            objEntityDtl.TotAmntFeb = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTFEB);
                        }
                        if (objclsTVData.COSTCENTRAMNTMAR != "")
                        {
                            objEntityDtl.TotAmntMar = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTMAR);
                        }
                        if (objclsTVData.COSTCENTRAMNTAPR != "")
                        {
                            objEntityDtl.TotAmntApr = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTAPR);
                        }
                        if (objclsTVData.COSTCENTRAMNTMAY != "")
                        {
                            objEntityDtl.TotAmntMay = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTMAY);
                        }
                        if (objclsTVData.COSTCENTRAMNTJUN != "")
                        {
                            objEntityDtl.TotAmntJun = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJUN);
                        }
                        if (objclsTVData.COSTCENTRAMNTJUL != "")
                        {
                            objEntityDtl.TotAmntJul = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJUL);
                        }
                        if (objclsTVData.COSTCENTRAMNTAUG != "")
                        {
                            objEntityDtl.TotAmntAug = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTAUG);
                        }
                        if (objclsTVData.COSTCENTRAMNTSEP != "")
                        {
                            objEntityDtl.TotAmntSep = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTSEP);
                        }
                        if (objclsTVData.COSTCENTRAMNTOCT != "")
                        {
                            objEntityDtl.TotAmntOct = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTOCT);
                        }
                        if (objclsTVData.COSTCENTRAMNTNOV != "")
                        {
                            objEntityDtl.TotAmntNov = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTNOV);
                        }
                        if (objclsTVData.COSTCENTRAMNTDEC != "")
                        {
                            objEntityDtl.TotAmntDec = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTDEC);
                        }
                        if (objclsTVData.COSTCENTRTOTALAMT != "")
                        {
                            objEntityDtl.CCTotal = Convert.ToDecimal(objclsTVData.COSTCENTRTOTALAMT);
                        }
                        objEntityJrnlCostcentrList.Add(objEntityDtl);
                    }
                }
            }

            // objEntityJrnlLedgrList.Reverse();
            //  objEntityJrnlCostcentrList.Reverse();
            DataTable dt = objBusinessLayerStock.CheckDupName(objEntityLayerStock);
            if (dt.Rows[0][0].ToString() == "0" && dt.Rows[1][0].ToString() == "0")
            {
                if (clickedButton.ID == "bttnsave")
                {
                    objBusinessLayerStock.AddBudgetDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Budget.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "bttnsavecls")
                {
                    objBusinessLayerStock.AddBudgetDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Budget_List.aspx?&InsUpd=Ins");
                }
            }
            else if (dt.Rows[1][0].ToString() != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDupMsgYear", "SuccessDupMsgYear();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDupMsgName", "SuccessDupMsgName();", true);
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
                clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                objEntityLayerStock.LedgerCC_Mode = Convert.ToInt32(HiddenFieldLedgerOrCC.Value);
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
                objEntityLayerStock.BudgetId = Convert.ToInt32(strId);
                List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityBudgetLedgerDtl>();
                List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityBudgetCostCntrDtl>();

                string jsonData = HiddenFieldBudgtDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldBudgtDataLedgr.Value != "" && HiddenFieldBudgtDataLedgr.Value != "[]" && HiddenFieldBudgtDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityBudgetLedgerDtl objEntityDtl = new clsEntityBudgetLedgerDtl();
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        if (objclsTVData.LEDGRAMNTJAN != "")
                        {
                            objEntityDtl.TotAmntJan = Convert.ToDecimal(objclsTVData.LEDGRAMNTJAN);
                        }
                        if (objclsTVData.LEDGRAMNTFEB != "")
                        {
                            objEntityDtl.TotAmntFeb = Convert.ToDecimal(objclsTVData.LEDGRAMNTFEB);
                        }
                        if (objclsTVData.LEDGRAMNTMAR != "")
                        {
                            objEntityDtl.TotAmntMar = Convert.ToDecimal(objclsTVData.LEDGRAMNTMAR);
                        }
                        if (objclsTVData.LEDGRAMNTAPR != "")
                        {
                            objEntityDtl.TotAmntApr = Convert.ToDecimal(objclsTVData.LEDGRAMNTAPR);
                        }
                        if (objclsTVData.LEDGRAMNTMAY != "")
                        {
                            objEntityDtl.TotAmntMay = Convert.ToDecimal(objclsTVData.LEDGRAMNTMAY);
                        }
                        if (objclsTVData.LEDGRAMNTJUN != "")
                        {
                            objEntityDtl.TotAmntJun = Convert.ToDecimal(objclsTVData.LEDGRAMNTJUN);
                        }
                        if (objclsTVData.LEDGRAMNTJUL != "")
                        {
                            objEntityDtl.TotAmntJul = Convert.ToDecimal(objclsTVData.LEDGRAMNTJUL);
                        }
                        if (objclsTVData.LEDGRAMNTAUG != "")
                        {
                            objEntityDtl.TotAmntAug = Convert.ToDecimal(objclsTVData.LEDGRAMNTAUG);
                        }
                        if (objclsTVData.LEDGRAMNTSEP != "")
                        {
                            objEntityDtl.TotAmntSep = Convert.ToDecimal(objclsTVData.LEDGRAMNTSEP);
                        }
                        if (objclsTVData.LEDGRAMNTOCT != "")
                        {
                            objEntityDtl.TotAmntOct = Convert.ToDecimal(objclsTVData.LEDGRAMNTOCT);
                        }
                        if (objclsTVData.LEDGRAMNTNOV != "")
                        {
                            objEntityDtl.TotAmntNov = Convert.ToDecimal(objclsTVData.LEDGRAMNTNOV);
                        }
                        if (objclsTVData.LEDGRAMNTDEC != "")
                        {
                            objEntityDtl.TotAmntDec = Convert.ToDecimal(objclsTVData.LEDGRAMNTDEC);
                        }
                        if (objclsTVData.LEDGRTOTALAMT != "")
                        {
                            objEntityDtl.LedgerTotal = Convert.ToDecimal(objclsTVData.LEDGRTOTALAMT);
                        }
                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldBudgtDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldBudgtDataCostCentr.Value != "" && HiddenFieldBudgtDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityBudgetCostCntrDtl objEntityDtl = new clsEntityBudgetCostCntrDtl();
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);

                            if (objclsTVData.COSTCENTRAMNTJAN != "")
                            {
                                objEntityDtl.TotAmntJan = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJAN);
                            }
                            if (objclsTVData.COSTCENTRAMNTFEB != "")
                            {
                                objEntityDtl.TotAmntFeb = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTFEB);
                            }
                            if (objclsTVData.COSTCENTRAMNTMAR != "")
                            {
                                objEntityDtl.TotAmntMar = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTMAR);
                            }
                            if (objclsTVData.COSTCENTRAMNTAPR != "")
                            {
                                objEntityDtl.TotAmntApr = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTAPR);
                            }
                            if (objclsTVData.COSTCENTRAMNTMAY != "")
                            {
                                objEntityDtl.TotAmntMay = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTMAY);
                            }
                            if (objclsTVData.COSTCENTRAMNTJUN != "")
                            {
                                objEntityDtl.TotAmntJun = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJUN);
                            }
                            if (objclsTVData.COSTCENTRAMNTJUL != "")
                            {
                                objEntityDtl.TotAmntJul = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJUL);
                            }
                            if (objclsTVData.COSTCENTRAMNTAUG != "")
                            {
                                objEntityDtl.TotAmntAug = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTAUG);
                            }
                            if (objclsTVData.COSTCENTRAMNTSEP != "")
                            {
                                objEntityDtl.TotAmntSep = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTSEP);
                            }
                            if (objclsTVData.COSTCENTRAMNTOCT != "")
                            {
                                objEntityDtl.TotAmntOct = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTOCT);
                            }
                            if (objclsTVData.COSTCENTRAMNTNOV != "")
                            {
                                objEntityDtl.TotAmntNov = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTNOV);
                            }
                            if (objclsTVData.COSTCENTRAMNTDEC != "")
                            {
                                objEntityDtl.TotAmntDec = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTDEC);
                            }
                            if (objclsTVData.COSTCENTRTOTALAMT != "")
                            {
                                objEntityDtl.CCTotal = Convert.ToDecimal(objclsTVData.COSTCENTRTOTALAMT);
                            }
                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

                //   objEntityJrnlLedgrList.Reverse();
                //  objEntityJrnlCostcentrList.Reverse();

                DataTable dt = objBusinessLayerStock.CheckBdgtCnclSts(objEntityLayerStock);

                

                    if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
                    {
                        if (clickedButton.ID == "btnUpdate")
                        {
                        objBusinessLayerStock.EditBudgetDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                        Response.Redirect("fms_Budget.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdatecls")
                       {
                        objBusinessLayerStock.EditBudgetDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                        Response.Redirect("fms_Budget_List.aspx?InsUpd=Upd");
                        }
                    }
                    else   if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
                    {
                        objBusinessLayerStock.EditBudgetDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                        Response.Redirect("fms_Budget.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Budget_List.aspx?InsUpd=UpdCancl");
                }
                else if (dt.Rows[0][1].ToString() == "1")
                {
                    Response.Redirect("fms_Budget_List.aspx?InsUpd=UpdConfm");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
                clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                objEntityLayerStock.LedgerCC_Mode = Convert.ToInt32(HiddenFieldLedgerOrCC.Value);

                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
                objEntityLayerStock.BudgetId = Convert.ToInt32(strId);
                objEntityLayerStock.ConfirmSts = 1;
                List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityBudgetLedgerDtl>();
                List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityBudgetCostCntrDtl>();

                string jsonData = HiddenFieldBudgtDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldBudgtDataLedgr.Value != "" && HiddenFieldBudgtDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityBudgetLedgerDtl objEntityDtl = new clsEntityBudgetLedgerDtl();
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        if (objclsTVData.LEDGRAMNTJAN != "")
                        {
                            objEntityDtl.TotAmntJan = Convert.ToDecimal(objclsTVData.LEDGRAMNTJAN);
                        }
                        if (objclsTVData.LEDGRAMNTFEB != "")
                        {
                            objEntityDtl.TotAmntFeb = Convert.ToDecimal(objclsTVData.LEDGRAMNTFEB);
                        }
                        if (objclsTVData.LEDGRAMNTMAR != "")
                        {
                            objEntityDtl.TotAmntMar = Convert.ToDecimal(objclsTVData.LEDGRAMNTMAR);
                        }
                        if (objclsTVData.LEDGRAMNTAPR != "")
                        {
                            objEntityDtl.TotAmntApr = Convert.ToDecimal(objclsTVData.LEDGRAMNTAPR);
                        }
                        if (objclsTVData.LEDGRAMNTMAY != "")
                        {
                            objEntityDtl.TotAmntMay = Convert.ToDecimal(objclsTVData.LEDGRAMNTMAY);
                        }
                        if (objclsTVData.LEDGRAMNTJUN != "")
                        {
                            objEntityDtl.TotAmntJun = Convert.ToDecimal(objclsTVData.LEDGRAMNTJUN);
                        }
                        if (objclsTVData.LEDGRAMNTJUL != "")
                        {
                            objEntityDtl.TotAmntJul = Convert.ToDecimal(objclsTVData.LEDGRAMNTJUL);
                        }
                        if (objclsTVData.LEDGRAMNTAUG != "")
                        {
                            objEntityDtl.TotAmntAug = Convert.ToDecimal(objclsTVData.LEDGRAMNTAUG);
                        }
                        if (objclsTVData.LEDGRAMNTSEP != "")
                        {
                            objEntityDtl.TotAmntSep = Convert.ToDecimal(objclsTVData.LEDGRAMNTSEP);
                        }
                        if (objclsTVData.LEDGRAMNTOCT != "")
                        {
                            objEntityDtl.TotAmntOct = Convert.ToDecimal(objclsTVData.LEDGRAMNTOCT);
                        }
                        if (objclsTVData.LEDGRAMNTNOV != "")
                        {
                            objEntityDtl.TotAmntNov = Convert.ToDecimal(objclsTVData.LEDGRAMNTNOV);
                        }
                        if (objclsTVData.LEDGRAMNTDEC != "")
                        {
                            objEntityDtl.TotAmntDec = Convert.ToDecimal(objclsTVData.LEDGRAMNTDEC);
                        }
                        if (objclsTVData.LEDGRTOTALAMT != "")
                        {
                            objEntityDtl.LedgerTotal = Convert.ToDecimal(objclsTVData.LEDGRTOTALAMT);
                        }
                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldBudgtDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldBudgtDataCostCentr.Value != "" && HiddenFieldBudgtDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityBudgetCostCntrDtl objEntityDtl = new clsEntityBudgetCostCntrDtl();
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);

                            if (objclsTVData.COSTCENTRAMNTJAN != "")
                            {
                                objEntityDtl.TotAmntJan = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJAN);
                            }
                            if (objclsTVData.COSTCENTRAMNTFEB != "")
                            {
                                objEntityDtl.TotAmntFeb = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTFEB);
                            }
                            if (objclsTVData.COSTCENTRAMNTMAR != "")
                            {
                                objEntityDtl.TotAmntMar = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTMAR);
                            }
                            if (objclsTVData.COSTCENTRAMNTAPR != "")
                            {
                                objEntityDtl.TotAmntApr = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTAPR);
                            }
                            if (objclsTVData.COSTCENTRAMNTMAY != "")
                            {
                                objEntityDtl.TotAmntMay = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTMAY);
                            }
                            if (objclsTVData.COSTCENTRAMNTJUN != "")
                            {
                                objEntityDtl.TotAmntJun = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJUN);
                            }
                            if (objclsTVData.COSTCENTRAMNTJUL != "")
                            {
                                objEntityDtl.TotAmntJul = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTJUL);
                            }
                            if (objclsTVData.COSTCENTRAMNTAUG != "")
                            {
                                objEntityDtl.TotAmntAug = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTAUG);
                            }
                            if (objclsTVData.COSTCENTRAMNTSEP != "")
                            {
                                objEntityDtl.TotAmntSep = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTSEP);
                            }
                            if (objclsTVData.COSTCENTRAMNTOCT != "")
                            {
                                objEntityDtl.TotAmntOct = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTOCT);
                            }
                            if (objclsTVData.COSTCENTRAMNTNOV != "")
                            {
                                objEntityDtl.TotAmntNov = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTNOV);
                            }
                            if (objclsTVData.COSTCENTRAMNTDEC != "")
                            {
                                objEntityDtl.TotAmntDec = Convert.ToDecimal(objclsTVData.COSTCENTRAMNTDEC);
                            }
                            if (objclsTVData.COSTCENTRTOTALAMT != "")
                            {
                                objEntityDtl.CCTotal = Convert.ToDecimal(objclsTVData.COSTCENTRTOTALAMT);
                            }
                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

                //      objEntityJrnlLedgrList.Reverse();
                //    objEntityJrnlCostcentrList.Reverse();

                DataTable dt = objBusinessLayerStock.CheckBdgtCnclSts(objEntityLayerStock);
                if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
                {
                    objBusinessLayerStock.EditBudgetDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Budget.aspx?ViewId=" + Request.QueryString["Id"] + "&InsUpd=Cnf");
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Budget_List.aspx?InsUpd=UpdCancl");
                }
                else if (dt.Rows[0][1].ToString() == "1")
                {
                    Response.Redirect("fms_Budget_List.aspx?InsUpd=UpdConfm");
                }
            }
        }
        catch (Exception)
        {

        }
    }

    public void Update(string id, int intConfirm, int intReopen)
    {
        try
        {
            HiddenEdit.Value = "1";
            clsEntityLayerBudget objEntityLayerBudgt = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerBudgt = new clsBusinessLayerBudget();
            clsBusinessLayer objBusinesslayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (Session["USERID"] != null)
            {
                objEntityLayerBudgt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerBudgt.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerBudgt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (intConfirm == 1)
            {
                btnConfirm.Visible = true;
            }
            else
            {
                btnConfirm.Visible = false;
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID                                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityLayerBudgt.Corp_Id);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }
            hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            // for adding comma

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                //HiddenDefultCrncAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }

            objEntityLayerBudgt.BudgetId = Convert.ToInt32(id);
            DataTable dt = objBusinessLayerBudgt.ReadBdgtDtlsById(objEntityLayerBudgt);

            if (dt.Rows.Count > 0)
            {
                if (ddlYear.Items.FindByValue(dt.Rows[0]["FINCYR_DEFAULTNAME"].ToString()) != null)
                {
                    ddlYear.Items.FindByValue(dt.Rows[0]["FINCYR_DEFAULTNAME"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["FINCYR_DEFAULTNAME"].ToString(), dt.Rows[0]["FINCYR_DEFAULTNAME"].ToString());
                    ddlYear.Items.Insert(1, lstGrp);
                    ddlYear.Items.FindByValue(dt.Rows[0]["FINCYR_DEFAULTNAME"].ToString()).Selected = true;
                }
                ddlMode.Value = dt.Rows[0]["BUDGT_MODE"].ToString();
                txtBudgtName.Value = dt.Rows[0]["BUDGT_NAME"].ToString();

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
                DivModeType.Visible = true;
                objEntityLayerBudgt.LedgerCC_Mode = Convert.ToInt32(dt.Rows[0]["BUDGT_LDGR_CC_MODE"].ToString());
                DataTable dtLedgerDeb = new DataTable();
                objEntityLayerStock.ConfirmSts = Convert.ToInt32(ddlMode.Value);
                dtLedgerDeb = objBusinessLayerBudgt.ReadLedgerDdl(objEntityLayerStock);

      

                DataTable dtCostCntrDebDtl = objBusinessLayerBudgt.ReadBdgtCostCntrDtlsById(objEntityLayerBudgt);

                if (dtCostCntrDebDtl.Rows.Count > 0)
                {
                    int CCRowCount = 0;
                    HiddenFieldLedgerOrCC.Value = "1";
                    DivCostCentre.Attributes["style"] = "display:block";
                    DivLedgerTable.Attributes["style"] = "display:none";
                    typLedger.Checked = false;
                    typCostCenter.Checked = true;
                    DataTable dtCostCentr = objBusinessLayerStock.ReadCostCentrDdl(objEntityLayerStock);
                    if (dtCostCentr.Rows.Count > 0)
                    {
                        ddlMainCostCenter.DataSource = dtCostCentr;
                        ddlMainCostCenter.DataTextField = "COSTCNTR_NAME";
                        ddlMainCostCenter.DataValueField = "COSTCNTR_ID";
                        ddlMainCostCenter.DataBind();
                    }
                    ddlMainCostCenter.Items.Insert(0, "-Select Cost Center-");
                    StringBuilder sbCC = new StringBuilder();
                    //if (hiddenCurrencyModeId.Value != "")
                    //    objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                    // objEntityLayerBudgt.BudgetId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_ID"].ToString());


  

                    for (int i = 0; i < dtCostCntrDebDtl.Rows.Count; i++)
                    {
                        int k = 1;
                        sbCC.Append("<tr id=\"SubRow" + i.ToString() + k.ToString() + "\">");
                        sbCC.Append("<td style=\"display:none;\">" + i.ToString() + k.ToString() + "</td>");
                        sbCC.Append("<td style=\"display:none;\"></td>");
                        sbCC.Append("<td class=\"td1\"><span>&nbsp;</span><br>");
                        sbCC.Append("<div id=\"divddlCost" + i.ToString() + k.ToString() + "\"><select onblur=\"IncrmntConfrmCounter();\" class=\"form-control fg2_inp4 t_bx tr_l ddl\" id=\"ddlCost" + i.ToString() + k.ToString() + "\" onchange=\"return changeCostCentr(" + k.ToString() + "," + i.ToString() + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\"  >");
                        sbCC.Append("<option>-Select Cost Center-</option>");

                        int f = 0;
                        for (int intRowCount = 0; intRowCount < dtCostCentr.Rows.Count; intRowCount++)
                        {
                            if (dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() == dtCostCntrDebDtl.Rows[i]["COSTCNTR_ID"].ToString())
                            {
                                f = 1;
                                sbCC.Append("<option selected value=\"" + dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() + "\">" + dtCostCentr.Rows[intRowCount]["COSTCNTR_NAME"].ToString() + "</option>");
                            }
                            else
                            {
                                sbCC.Append("<option value=\"" + dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() + "\">" + dtCostCentr.Rows[intRowCount]["COSTCNTR_NAME"].ToString() + "</option>");
                            }
                        }
                        if (f == 0)
                        {
                            sbCC.Append("<option selected value=\"" + dtCostCntrDebDtl.Rows[i]["COSTCNTR_ID"].ToString() + "\">" + dtCostCntrDebDtl.Rows[i]["COSTCNTR_NAME"].ToString() + "</option>");
                        }
                        sbCC.Append("</select></div></td>");

                        

                        sbCC.Append("<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JANUARY\" id=\"tdlc\">JAN</span>");
                        string strJan="";
                        string strFeb = "";
                        string strMar = "";
                        string strApr = "";
                        string strMay = "";
                        string strJune = "";
                        string strJuly = "";
                        string strAug = "";
                        string strSep = "";
                        string strOct = "";
                        string strNov = "";
                        string strDec = "";
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JAN"].ToString() != "")
                        {
                            strJan= objBusinesslayer.AddCommasForNumberSeperation( dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JAN"].ToString() , objEntityCommon) ;
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" +strJan+ "\" id=\"txtAmntJan" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt( " + i + "," + k + ",'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" id=\"tdlc\">FEB</span>");
                         if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_FEB"].ToString() != "")
                        {
                            strFeb = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_FEB"].ToString(), objEntityCommon);
                        }
                         sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strFeb + "\" id=\"txtAmntFeb" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Feb');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MARCH\" id=\"tdlc\">MAR</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAR"].ToString() != "")
                        {
                            strMar = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAR"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMar + "\" id=\"txtAmntMar" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Mar');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"APRIL\" id=\"tdlc\">APR</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_APR"].ToString() != "")
                        {
                            strApr = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_APR"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strApr + "\" id=\"txtAmntApr" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Apr');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MAY\" id=\"tdlc\">MAY</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAY"].ToString() != "")
                        {
                            strMay = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAY"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMay + "\" id=\"txtAmntMay" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'May');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JUNE\" id=\"tdlc\">JUN</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUN"].ToString() != "")
                        {
                            strJune = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUN"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJune + "\" id=\"txtAmntJun" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Jun');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");

                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JULY\" id=\"tdlc\">JUL</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUL"].ToString() != "")
                        {
                            strJuly = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUL"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJuly + "\" id=\"txtAmntJul" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Jul');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");

                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"AUGUST\" id=\"tdlc\">AUG</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_AUG"].ToString() != "")
                        {
                            strAug = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_AUG"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strAug + "\" id=\"txtAmntAug" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Aug');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"SEPTEMBER\" id=\"tdlc\">SEP</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_SEP"].ToString() != "")
                        {
                            strSep = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_SEP"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strSep + "\" id=\"txtAmntSep" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Sep');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"OCTOBER\" id=\"tdlc\">OCT</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_OCT"].ToString() != "")
                        {
                            strOct = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_OCT"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strOct + "\" id=\"txtAmntOct" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Oct');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");


                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"NOVEMBER\" id=\"tdlc\">NOV</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_NOV"].ToString() != "")
                        {
                            strNov = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_NOV"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strNov + "\" id=\"txtAmntNov" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Nov');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"DECEMBER\" id=\"tdlc\">DEC</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_DEC"].ToString() != "")
                        {
                            strDec = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_DEC"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strDec + "\" id=\"txtAmntDec" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Dec');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");

                        sbCC.Append("<td ><span>&nbsp;</span><br><b>");
                        string strTotal = "";
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_TOTAL_AMT"].ToString() != "")
                        {
                            strTotal = objBusinesslayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_TOTAL_AMT"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strTotal + "\" id=\"txtTotal" + i.ToString() + k.ToString() + "\" type=\"text\"  onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
                        sbCC.Append("</b></td>");



                        sbCC.Append("<td><div class=\"btn_stl1 ltp\">");

                        if (i == dtCostCntrDebDtl.Rows.Count - 1)
                        {
                            sbCC.Append("<button class=\"btn act_btn bn2\" title=\"Add\"id=\"btnAddSub" + i.ToString() + k.ToString() + "\" onclick=\"return Validate_addMainTab_CC(" + i + ");\">");
                            sbCC.Append("<span class=\"fa fa-plus\" id=\"Span3\" style=\"display: block;\">&nbsp;</span>");
                            sbCC.Append("</button>");
                        
                        }
                        else
                        {
                            sbCC.Append("<button disabled class=\"btn act_btn bn2\" title=\"Add\" id=\"btnAddSub" + i.ToString() + k.ToString() + "\" onclick=\"return Validate_addMainTab_CC(" + i + ");\">");
                            sbCC.Append("<span class=\"fa fa-plus\" id=\"Span3\" style=\"display: block;\">&nbsp;</span>");
                            sbCC.Append("</button>");
                     
                        }
                        sbCC.Append("<button class=\"btn act_btn bn3\" title=\"Delete\" id=\"btnDelSub" + i.ToString() + k.ToString() + "\" onclick=\"return delSubRow(" + k.ToString() + "," + i.ToString() + ");\">");
                        sbCC.Append("<span class=\"fa fa-trash\" id=\"Span2\" style=\"display: block;\">&nbsp;</span>");
                        sbCC.Append("</button>");
                        //sbCC.Append("</span>");
                        sbCC.Append("</div></td>");
                       

                        sbCC.Append("</tr>");
                        TableCostCentreBody.InnerHtml = sbCC.ToString();
                        HiddenLedgerRowCount.Value = Convert.ToString(CCRowCount);

                    }
                }


                StringBuilder sb = new StringBuilder();
                DataTable dtLedgrdDebDtl = objBusinessLayerBudgt.ReadBdgtLedgrDtlsById(objEntityLayerBudgt);
                int LedgerRowCount = 0;
                if (dtLedgrdDebDtl.Rows.Count > 0)
                {
                    HiddenFieldLedgerOrCC.Value = "0";
                    DivLedgerTable.Attributes["style"] = "display:block";
                    DivCostCentre.Attributes["style"] = " display:none";
                    typCostCenter.Checked = false;
                    typLedger.Checked = true;
                  
                    for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                    {
                        string strJan = "";
                        string strFeb = "";
                        string strMar = "";
                        string strApr = "";
                        string strMay = "";
                        string strJune = "";
                        string strJuly = "";
                        string strAug = "";
                        string strSep = "";
                        string strOct = "";
                        string strNov = "";
                        string strDec = "";
                        sb.Append("<tr id=\"MainRow" + i + "\">");
                        sb.Append("<td style=\"display:none;\">" + i + "0</td>");
                        sb.Append("<td style=\"display:none;\"></td>");
                        sb.Append("<td ><span>&nbsp;</span><br>");
                        sb.Append("<div id=\"divddlLed" + i + "0\"><select onblur=\"IncrmntConfrmCounter();\" class=\"form-control fg2_inp4 t_bx tr_l ddl\" id=\"ddlLed" + i + "0\" onchange=\"return changeLedger(0," + i + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        sb.Append("<option>-Select Ledger-</option>");
                        int f = 0;
                        LedgerRowCount = i;
                        for (int intRowCount = 0; intRowCount < dtLedgerDeb.Rows.Count; intRowCount++)
                        {
                            if (dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() == dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString())
                            {
                                f = 1;
                                sb.Append("<option selected value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                            }
                            else
                            {
                                sb.Append("<option value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                            }
                        }
                        if (f == 0)
                        {
                            sb.Append("<option selected value=\"" + dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() + "\">" + dtLedgrdDebDtl.Rows[i]["LDGR_NAME"].ToString() + "</option>");
                        }
                        sb.Append("</select></div></td>");
                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JANUARY\" id=\"tdlc\">JAN</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JAN"].ToString() != "")
                        {
                            strJan = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JAN"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJan + "\" id=\"txtAmntJan" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");
                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" id=\"tdlc\">FEB</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_FEB"].ToString() != "")
                        {
                            strFeb = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_FEB"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strFeb + "\" id=\"txtAmntFeb" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Feb');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MARCH\" id=\"tdlc\">MAR</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAR"].ToString() != "")
                        {
                            strMar = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAR"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMar + "\" id=\"txtAmntMar" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Mar');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");
                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"APRIL\" id=\"tdlc\">APR</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_APR"].ToString() != "")
                        {
                            strApr = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_APR"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strApr + "\" id=\"txtAmntApr" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Apr');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MAY\" id=\"tdlc\">MAY</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAY"].ToString() != "")
                        {
                            strMay = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAY"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMay + "\" id=\"txtAmntMay" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'May');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");
                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JUNE\" id=\"tdlc\">JUN</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUN"].ToString() != "")
                        {
                            strJune = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUN"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJune + "\" id=\"txtAmntJun" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Jun');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JULY\" id=\"tdlc\">JUL</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUL"].ToString() != "")
                        {
                            strJuly = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUL"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJuly + "\" id=\"txtAmntJul" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Jul');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");
                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"AUGUST\" id=\"tdlc\">AUG</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_AUG"].ToString() != "")
                        {
                            strAug = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_AUG"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strAug + "\" id=\"txtAmntAug" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Aug');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"SEPTEMBER\" id=\"tdlc\">SEP</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_SEP"].ToString() != "")
                        {
                            strSep = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_SEP"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strSep + "\" id=\"txtAmntSep" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Sep');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");
                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"OCTOBER\" id=\"tdlc\">OCT</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_OCT"].ToString() != "")
                        {
                            strOct = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_OCT"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strOct + "\" id=\"txtAmntOct" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Oct');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"NOVEMBER\" id=\"tdlc\">NOV</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_NOV"].ToString() != "")
                        {
                            strNov = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_NOV"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strNov + "\" id=\"txtAmntNov" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Nov');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");
                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"DECEMBER\" id=\"tdlc\">DEC</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_DEC"].ToString() != "")
                        {
                            strDec = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_DEC"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strDec + "\" id=\"txtAmntDec" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Dec');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><span>&nbsp;</span><br><b>");
                        string strTotal = "";
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_TOTAL_AMT"].ToString() != "")
                        {
                            strTotal = objBusinesslayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_TOTAL_AMT"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strTotal + "\" id=\"txtTotal" + i + "0\" type=\"text\"   onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
                        sb.Append("</b></td>");
                        sb.Append("<td><div class=\"btn_stl1 ltp\">");

                        if (i == dtLedgrdDebDtl.Rows.Count - 1)
                        {
                            sb.Append("<button class=\"btn act_btn bn2\" title=\"Add\"  id=\"btnAddMain" + i + "0\" onclick=\"return Validate_addMainTabRow(" + i + ");\">");
                            sb.Append("<span class=\"fa fa-plus\" id=\"Span1\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");

                        }
                        else
                        {
                            sb.Append("<button disabled class=\"btn act_btn bn2\" title=\"Add\"  id=\"btnAddMain" + i + "0\" onclick=\"return Validate_addMainTabRow(" + i + ");\">");
                            sb.Append("<span class=\"fa fa-plus\" id=\"Span1\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");

                        }
                        sb.Append("<button class=\"btn act_btn bn3\" title=\"Delete\"  id=\"btnDelMain" + i + "0\" onclick=\"return delMainTabRow(0," + i + ");\">");
                        sb.Append("<span class=\"fa fa-trash\" id=\"chevron-left\" style=\"display: block;\">&nbsp;</span>");
                        sb.Append("</button>");
                        //sb.Append("</span>");
                        sb.Append("</div></td>");

                        sb.Append("</tr>");
                        tabMainBody.InnerHtml = sb.ToString();

                        HiddenLedgerRowCount.Value = Convert.ToString(LedgerRowCount);

                    }
                }
                
            }
            addTable();
            ScriptManager.RegisterStartupScript(this, GetType(), "FillAuto", "FillAuto();", true);////////

        }
        catch (Exception)
        {

        }
    }
    public void View(string id, int intConfirm, int intReopen)
    {
        try
        {
            HiddenView.Value = "1";
            HiddenEdit.Value = "1";
            clsEntityLayerBudget objEntityLayerBudgt = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerBudgt = new clsBusinessLayerBudget();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
               clsEntityCommon objEntityCommon = new clsEntityCommon();
            if (Session["USERID"] != null)
            {
                objEntityLayerBudgt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerBudgt.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerBudgt.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityLayerBudgt.BudgetId = Convert.ToInt32(id);
            DataTable dt = objBusinessLayerBudgt.ReadBdgtDtlsById(objEntityLayerBudgt);

           
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID                                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityLayerBudgt.Corp_Id);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }
            hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            // for adding comma

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                //HiddenDefultCrncAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            if (dt.Rows.Count > 0)
            {

                ddlMode.Value = dt.Rows[0]["BUDGT_MODE"].ToString();
                if (ddlYear.Items.FindByValue(dt.Rows[0]["BUDGT_YEAR"].ToString()) != null)
                {
                    ddlYear.Items.FindByValue(dt.Rows[0]["BUDGT_YEAR"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["BUDGT_YEAR"].ToString(), dt.Rows[0]["BUDGT_YEAR"].ToString());
                    ddlYear.Items.Insert(1, lstGrp);
                    ddlYear.Items.FindByValue(dt.Rows[0]["BUDGT_YEAR"].ToString()).Selected = true;
                }
                txtBudgtName.Value = dt.Rows[0]["BUDGT_NAME"].ToString();

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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

                //    DataTable dtLedgerDeb = new DataTable();
                objEntityLayerStock.ConfirmSts = Convert.ToInt32(ddlMode.Value);
                DivModeType.Visible = true;
                objEntityLayerBudgt.LedgerCC_Mode = Convert.ToInt32(dt.Rows[0]["BUDGT_LDGR_CC_MODE"].ToString());
                DataTable dtLedgerDeb = new DataTable();
                objEntityLayerStock.ConfirmSts = Convert.ToInt32(ddlMode.Value);
                dtLedgerDeb = objBusinessLayerBudgt.ReadLedgerDdl(objEntityLayerStock);




                DataTable dtCostCntrDebDtl = objBusinessLayerBudgt.ReadBdgtCostCntrDtlsById(objEntityLayerBudgt);

                if (dtCostCntrDebDtl.Rows.Count > 0)
                {
                    
                    int CCRowCount = 0;
                    HiddenFieldLedgerOrCC.Value = "1";
                    DivCostCentre.Attributes["style"] = "display:block";
                    DivLedgerTable.Attributes["style"] = " display:none";
                    typLedger.Checked = false;
                    typCostCenter.Checked = true;
                    DataTable dtCostCentr = objBusinessLayerStock.ReadCostCentrDdl(objEntityLayerStock);
                    if (dtCostCentr.Rows.Count > 0)
                    {
                        ddlMainCostCenter.DataSource = dtCostCentr;
                        ddlMainCostCenter.DataTextField = "COSTCNTR_NAME";
                        ddlMainCostCenter.DataValueField = "COSTCNTR_ID";
                        ddlMainCostCenter.DataBind();
                    }
                    ddlMainCostCenter.Items.Insert(0, "-Select Cost Center-");
                    StringBuilder sbCC = new StringBuilder();

                    // objEntityLayerBudgt.BudgetId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_ID"].ToString());
                    for (int i = 0; i < dtCostCntrDebDtl.Rows.Count; i++)
                    {
                        string strJan = "";
                        string strFeb = "";
                        string strMar = "";
                        string strApr = "";
                        string strMay = "";
                        string strJune = "";
                        string strJuly = "";
                        string strAug = "";
                        string strSep = "";
                        string strOct = "";
                        string strNov = "";
                        string strDec = "";
                        int k = 1;
                        sbCC.Append("<tr id=\"SubRow" + i.ToString() + k.ToString() + "\">");
                        sbCC.Append("<td style=\"display:none;\">" + i.ToString() + k.ToString() + "</td>");
                        sbCC.Append("<td style=\"display:none;\"></td>");
                        sbCC.Append("<td ><span>&nbsp;</span><br>");
                        sbCC.Append("<div id=\"divddlCost" + i.ToString() + k.ToString() + "\"><select disabled onblur=\"IncrmntConfrmCounter();\" class=\"form-control fg2_inp4 t_bx tr_l ddl\" id=\"ddlCost" + i.ToString() + k.ToString() + "\" onchange=\"return changeCostCentr(" + k.ToString() + "," + i.ToString() + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\"  >");
                        sbCC.Append("<option>-Select Cost Center-</option>");

                        int f = 0;
                        for (int intRowCount = 0; intRowCount < dtCostCentr.Rows.Count; intRowCount++)
                        {
                            if (dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() == dtCostCntrDebDtl.Rows[i]["COSTCNTR_ID"].ToString())
                            {
                                f = 1;
                                sbCC.Append("<option selected value=\"" + dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() + "\">" + dtCostCentr.Rows[intRowCount]["COSTCNTR_NAME"].ToString() + "</option>");
                            }
                            else
                            {
                                sbCC.Append("<option value=\"" + dtCostCentr.Rows[intRowCount]["COSTCNTR_ID"].ToString() + "\">" + dtCostCentr.Rows[intRowCount]["COSTCNTR_NAME"].ToString() + "</option>");
                            }
                        }
                        if (f == 0)
                        {
                            sbCC.Append("<option selected value=\"" + dtCostCntrDebDtl.Rows[i]["COSTCNTR_ID"].ToString() + "\">" + dtCostCntrDebDtl.Rows[i]["COSTCNTR_NAME"].ToString() + "</option>");
                        }
                        sbCC.Append("</select></div></td>");
                        //sbCC.Append("<span style=\"display:inline-block;float:right;width:100%\">");
                     

                        sbCC.Append("<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JANUARY\" id=\"tdlc\">JAN</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JAN"].ToString() != "")
                        {
                            strJan = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JAN"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJan + "\" id=\"txtAmntJan" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt( " + i + "," + k + ",'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" id=\"tdlc\">FEB</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_FEB"].ToString() != "")
                        {
                            strFeb = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_FEB"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strFeb + "\" id=\"txtAmntFeb" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Feb');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MARCH\" id=\"tdlc\">MARCH</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAR"].ToString() != "")
                        {
                            strMar = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAR"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMar + "\" id=\"txtAmntMar" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Mar');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"APRIL\" id=\"tdlc\">APRIL</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_APR"].ToString() != "")
                        {
                            strApr = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_APR"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strApr + "\" id=\"txtAmntApr" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Apr');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MAY\" id=\"tdlc\">MAY</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAY"].ToString() != "")
                        {
                            strMay = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_MAY"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMay + "\" id=\"txtAmntMay" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'May');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JUNE\" id=\"tdlc\">JUNE</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUN"].ToString() != "")
                        {
                            strJune = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUN"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJune + "\" id=\"txtAmntJun" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Jun');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JULY\" id=\"tdlc\">JULY</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUL"].ToString() != "")
                        {
                            strJuly = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUL"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_JUL"].ToString() + "\" id=\"txtAmntJul" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Jul');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"AUGUST\" id=\"tdlc\">AUGUST</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_AUG"].ToString() != "")
                        {
                            strAug = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_AUG"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strAug + "\" id=\"txtAmntAug" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Aug');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td  ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"SEPTEMBER\" id=\"tdlc\">SEPTEMBER</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_SEP"].ToString() != "")
                        {
                            strSep = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_SEP"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strSep + "\" id=\"txtAmntSep" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Sep');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"OCTOBER\" id=\"tdlc\">OCTOBER</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_OCT"].ToString() != "")
                        {
                            strOct = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_OCT"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strOct + "\" id=\"txtAmntOct" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Oct');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"NOVEMBER\" id=\"tdlc\">NOVEMBER</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_NOV"].ToString() != "")
                        {
                            strNov = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_NOV"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strNov + "\" id=\"txtAmntNov" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Nov');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sbCC.Append("</td>");
                        sbCC.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"DECEMBER\" id=\"tdlc\">DECEMBER</span>");
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_DEC"].ToString() != "")
                        {
                            strDec = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_DEC"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + dtCostCntrDebDtl.Rows[i]["CST_BUDGT_AMT_DEC"].ToString() + "\" id=\"txtAmntDec" + i.ToString() + k.ToString() + "\" type=\"text\"  onchange=\"CalculateCostAmnt(" + i + "," + k + ",'Dec');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sbCC.Append("</td>");
                        sbCC.Append("<td ><span>&nbsp;</span><br><b>");
                        string strTotal = "";
                        if (dtCostCntrDebDtl.Rows[i]["CST_BUDGT_TOTAL_AMT"].ToString() != "")
                        {
                            strTotal = objBusinessLayer.AddCommasForNumberSeperation(dtCostCntrDebDtl.Rows[i]["CST_BUDGT_TOTAL_AMT"].ToString(), objEntityCommon);
                        }
                        sbCC.Append("<input disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strTotal + "\" id=\"txtTotal" + i.ToString() + k.ToString() + "\" type=\"text\"  onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\">");
                        sbCC.Append("</b></td>");

                        sbCC.Append("<td><div class=\"btn_stl1 ltp\">");
                        if (i == dtCostCntrDebDtl.Rows.Count - 1)
                        {
                            sbCC.Append("<button class=\"btn act_btn bn2\" disabled title=\"Add\" id=\"btnAddSub" + i.ToString() + k.ToString() + "\" onclick=\"return Validate_addMainTab_CC(" + i + ");\">");
                            sbCC.Append("<span class=\"fa fa-plus\" id=\"Span3\" ></span>");
                            sbCC.Append("</button>");
                        }
                        else
                        {
                            sbCC.Append("<button disabled class=\"btn act_btn bn2\" title=\"Add\"  id=\"btnAddSub" + i.ToString() + k.ToString() + "\" onclick=\"return Validate_addMainTab_CC(" + i + ");\">");
                            sbCC.Append("<span class=\"fa fa-plus\" id=\"Span3\"></span>");
                            sbCC.Append("</button>");
                        }
                        sbCC.Append("<button class=\"btn act_btn bn3\" disabled title=\"Delete\"  id=\"btnDelSub" + i.ToString() + k.ToString() + "\" onclick=\"return delSubRow(" + k.ToString() + "," + i.ToString() + ");\">");
                        sbCC.Append("<span class=\"fa fa-trash\" id=\"Span2\" ></span>");
                        sbCC.Append("</button>");
                        //sbCC.Append("</span>");
                        sbCC.Append("</div></td>");
                        sbCC.Append("</tr>");
                        TableCostCentreBody.InnerHtml = sbCC.ToString();
                        HiddenLedgerRowCount.Value = Convert.ToString(CCRowCount);

                    }
                }
                else
                {
                    HiddenEdit.Value = "2";
                }

                StringBuilder sb = new StringBuilder();
                DataTable dtLedgrdDebDtl = objBusinessLayerBudgt.ReadBdgtLedgrDtlsById(objEntityLayerBudgt);
                int LedgerRowCount = 0;
                if (dtLedgrdDebDtl.Rows.Count > 0)
                {
                    
                    HiddenFieldLedgerOrCC.Value = "0";
                    DivLedgerTable.Attributes["style"] = "display:block";
                    DivCostCentre.Attributes["style"] = " display:none";
                    typCostCenter.Checked = false;
                    typLedger.Checked = true;

                    for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                    {
                        string strJan = "";
                        string strFeb = "";
                        string strMar = "";
                        string strApr = "";
                        string strMay = "";
                        string strJune = "";
                        string strJuly = "";
                        string strAug = "";
                        string strSep = "";
                        string strOct = "";
                        string strNov = "";
                        string strDec = "";
                        sb.Append("<tr id=\"MainRow" + i + "\">");
                        sb.Append("<td style=\"display:none;\">" + i + "0</td>");
                        sb.Append("<td style=\"display:none;\"></td>");
                        sb.Append("<td ><span>&nbsp;</span><br>");


                        sb.Append("<div id=\"divddlLed" + i + "0\"><select disabled  onblur=\"IncrmntConfrmCounter();\" class=\"form-control fg2_inp4 t_bx tr_l ddl\" id=\"ddlLed" + i + "0\" onchange=\"return changeLedger(0," + i + ");\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        sb.Append("<option>-Select Ledger-</option>");
                        int f = 0;
                        LedgerRowCount = i;
                        for (int intRowCount = 0; intRowCount < dtLedgerDeb.Rows.Count; intRowCount++)
                        {
                            if (dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() == dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString())
                            {
                                f = 1;
                                sb.Append("<option selected value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                            }
                            else
                            {
                                sb.Append("<option value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                            }
                        }
                        if (f == 0)
                        {
                            sb.Append("<option selected value=\"" + dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() + "\">" + dtLedgrdDebDtl.Rows[i]["LDGR_NAME"].ToString() + "</option>");
                        }
                        sb.Append("</select></div></td>");
                        //sb.Append("<span style=\"display:inline-block;float:right;width:100%\">");
              
                 
                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JANUARY\" id=\"tdlc\">JAN</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JAN"].ToString() != "")
                        {
                            strJan = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JAN"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJan + "\" id=\"txtAmntJan" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Jan');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");

                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" >FEB</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_FEB"].ToString() != "")
                        {
                            strFeb = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_FEB"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strFeb + "\" id=\"txtAmntFeb" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Feb');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MARCH\" >MAR</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAR"].ToString() != "")
                        {
                            strMar = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAR"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMar + "\" id=\"txtAmntMar" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Mar');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");

                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"APRIL\" >APR</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_APR"].ToString() != "")
                        {
                            strApr = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_APR"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strApr + "\" id=\"txtAmntApr" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Apr');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"MAY\" >MAY</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAY"].ToString() != "")
                        {
                            strMay = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_MAY"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strMay + "\" id=\"txtAmntMay" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'May');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");

                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JUNE\" >JUN</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUN"].ToString() != "")
                        {
                            strJune = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUN"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJune + "\" id=\"txtAmntJun" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Jun');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"JULY\" >JUL</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUL"].ToString() != "")
                        {
                            strJuly = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_JUL"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strJuly + "\" id=\"txtAmntJul" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Jul');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");

                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"AUGUST\" >AUG</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_AUG"].ToString() != "")
                        {
                            strAug = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_AUG"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strAug + "\" id=\"txtAmntAug" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Aug');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td ><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"SEPTEMBER\" >SEP</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_SEP"].ToString() != "")
                        {
                            strSep = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_SEP"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strSep + "\" id=\"txtAmntSep" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Sep');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");

                        sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"OCTOBER\" >OCT</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_OCT"].ToString() != "")
                        {
                            strOct = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_OCT"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strOct + "\" id=\"txtAmntOct" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Oct');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        sb.Append("</td>");

                        sb.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"NOVEMBER\" >NOV</span>");
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_NOV"].ToString() != "")
                        {
                            strNov = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_NOV"].ToString(), objEntityCommon);
                        }
                        sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strNov + "\" id=\"txtAmntNov" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Nov');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                        //sb.Append("</td>");

                          sb.Append("<div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"FEBRUARY\" >FEB</span>");
                          if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_DEC"].ToString() != "")
                          {
                              strDec = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_AMT_DEC"].ToString(), objEntityCommon);
                          }
                          sb.Append("<input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strDec + "\" id=\"txtAmntDec" + i + "0\" type=\"text\"  onchange=\"CalculateLedgerAmnt(" + i + ",'Dec');\" onkeydown=\"return isNumberDec(event);\"  maxlength=8 onkeypress=\"return isNumberDec(event);\"></div>");
                          sb.Append("</td>");

                        //sb.Append("<td><div class=\"input-group t_bx\"><span class=\"input-group-addon cur5 cur_mnth\" title=\"DECEMBER\" >DEC</span>");
                        string strTotal = "";
                        if (dtLedgrdDebDtl.Rows[i]["LD_BUDGT_TOTAL_AMT"].ToString() != "")
                        {
                            strTotal = objBusinessLayer.AddCommasForNumberSeperation(dtLedgrdDebDtl.Rows[i]["LD_BUDGT_TOTAL_AMT"].ToString(), objEntityCommon);
                        }
                        sb.Append("<td ><span>&nbsp;</span><br><b><input  disabled class=\"form-control fg2_inp2 tr_r amt_1\" value=\"" + strTotal + "\" id=\"txtTotal" + i + "0\" type=\"text\"   onkeydown=\"return isNumberDec(event);\"  maxlength=12 onkeypress=\"return isNumberDec(event);\"></div>");
                   
                        sb.Append("</b></td>");
                        sb.Append("<td>  <div class=\"btn_stl1 ltp\">");

                        if (i == dtLedgrdDebDtl.Rows.Count - 1)
                        {
                            sb.Append("<button class=\"btn act_btn bn2\" disabled title=\"Add\" id=\"btnAddMain" + i + "0\" onclick=\"return Validate_addMainTabRow(" + i + ");\">");
                            sb.Append("<i class=\"fa fa-plus\" id=\"Span1\" ></i>");
                            sb.Append("</button>");

                        }
                        else
                        {
                            sb.Append("<button disabled class=\"btn act_btn bn2\" title=\"Add\"  id=\"btnAddMain" + i + "0\" onclick=\"return Validate_addMainTabRow(" + i + ");\">");
                            sb.Append("<i class=\"fa fa-plus\" id=\"Span1\"></i>");
                            sb.Append("</button>");

                        }
                        sb.Append("<button class=\"btn act_btn bn3\" disabled title=\"Delete\"  id=\"btnDelMain" + i + "0\" onclick=\"return delMainTabRow(0," + i + ");\">");
                        sb.Append("<i class=\"fa fa-trash\" id=\"chevron-left\"></i>");
                        sb.Append("</button>");
                        //sb.Append("</span>");
                        sb.Append("</div></td>");

                       
                        sb.Append("</tr>");
                        tabMainBody.InnerHtml = sb.ToString();

                        HiddenLedgerRowCount.Value = Convert.ToString(LedgerRowCount);

                    }
                }
                else
                {
                    HiddenEdit.Value = "2";
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "FillAuto", "FillAuto();", true);////////

        }
        catch (Exception)
        {

        }
    }
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }

        textList.Sort();


        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
    protected void btnCreateBudgt_Click(object sender, EventArgs e)
    {
        try
        {
            addTable();
            clsEntityLayerBudget objEntityLayerStock = new clsEntityLayerBudget();
            clsBusinessLayerBudget objBusinessLayerStock = new clsBusinessLayerBudget();
            if (Session["USERID"] != null)
            {
                objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityLayerStock.BudgtName = txtBudgtName.Value.ToUpper();
            objEntityLayerStock.Mode = Convert.ToInt32(ddlMode.Value);
            objEntityLayerStock.Year = Convert.ToInt32(ddlYear.Value);
            DataTable dt = objBusinessLayerStock.CheckDupName(objEntityLayerStock);
            if (dt.Rows[0][0].ToString() == "0" && dt.Rows[1][0].ToString() == "0")
            {
                bttnsave.Visible = true;
                bttnsavecls.Visible = true;
                HiddenFieldName.Value = txtBudgtName.Value.ToUpper();
                HiddenFieldMode.Value = ddlMode.Value;
                HiddenFieldYear.Value = ddlYear.Value;
                DivModeType.Visible = true;
                DivLedgerTable.Attributes["style"] = " display:block";
                HiddenFieldLedgerOrCC.Value = "0";
                ddlMode.Disabled = true;
                ddlYear.Disabled = true;
                txtBudgtName.Disabled = true;
                DisableMonths();
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCreateBudgt", "SuccessCreateBudgt();", true);
            }
            else if (dt.Rows[1][0].ToString() != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDupMsgYear", "SuccessDupMsgYear();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDupMsgName", "SuccessDupMsgName();", true);
            }
        }
        catch (Exception)
        {

        }
    }
    public void DisableMonths()
    {
        HiddenFieldDisabledMnts.Value = "";
        try
        {
            clsBusinessLayer onjBusuness = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            DateTime currMnt = onjBusuness.LoadCurrentDate();
            DateTime tarMnt = new DateTime();
            for (int i = 1; i < 13; i++)
            {
                string mnth = i.ToString();
                if (i.ToString().Length == 1)
                {
                    mnth = "0" + i.ToString();
                }
                tarMnt = objCommon.textToDateTime("01-" + mnth + "-" + ddlYear.Value);
                if (tarMnt <= currMnt)
                {
                    HiddenFieldDisabledMnts.Value = HiddenFieldDisabledMnts.Value + "," + tarMnt.ToString("MMM");
                }
            }
        }
        catch (Exception)
        {

        }
    }
    [WebMethod]
    public static string FinancialYear(string finYear, string intorgid, string intcorpid)
    {
        string result = "";
        clsEntityLayerBudget objEntityLayerBudgt = new clsEntityLayerBudget();
        clsBusinessLayerBudget objBusinessLayerBudgt = new clsBusinessLayerBudget();
        if (intorgid != "")
            objEntityLayerBudgt.Org_Id = Convert.ToInt32(intorgid);
        if (intcorpid != "")
            objEntityLayerBudgt.Corp_Id = Convert.ToInt32(intcorpid);
        DataTable dtfinaclYear = objBusinessLayerBudgt.ReadFinancialYear(objEntityLayerBudgt);
        //  DataRow[] dr = dtfinaclYear.Select("FINCYR_DEFAULTNAME = " + finYear.ToString());
        DataRow[] drPaytable = dtfinaclYear.Select("FINCYR_DEFAULTNAME like '%" + finYear.ToString() + "%'");
        if (drPaytable[0]["FINCYR_ID"].ToString() != "")
        {
            result = drPaytable[0]["FINCYR_ID"].ToString();
        }
        return result;

    }
}
