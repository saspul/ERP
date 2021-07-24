using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class FMS_FMS_Master_fms_Journal_fms_Journal : System.Web.UI.Page
{
    int intAccntCloseReopen = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addTable();
            ddlCurrency.Focus();           
            LoadCurrencies();
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
            string ForeignExcSts = "";
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }
          
            ddlCurrency.Disabled = true;



            int intUsrRolMstrId = 0, intConfirm = 0, intReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldAcntCloseReopenSts.Value = "1";
                    }
                }
            }
            if (Request.QueryString["Id"] != null)
            {
               
                lblEntry.Text = "Edit Journal";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                Update(strId, intConfirm, intReopen);

            }
            else if (Request.QueryString["ViewId"] != null)
            {

                lblEntry.Text = "View Journal";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                btnUpdate.Visible = false;
                btnConfirm.Visible = false;
                btnReopen.Visible = false;
                btnCancel.Visible = true;
                View(strId, intConfirm, intReopen);
            }
            else
            {
               
                lblEntry.Text = "Add Journal";
                btnUpdate.Visible = false;
                btnConfirm.Visible = false;
                btnReopen.Visible = false;

                
                string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
                txtDateFrom.Value = strCurrentDate;
               
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                txtRefNum.Value = "REF/"+strNextId;
                HiddenFieldJournalId.Value = strNextId;
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
            else if (strInsUpd == "Reop")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopMsg", "SuccessReopMsg();", true);
            }
        }
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
    [WebMethod]
    public static string CheckAcntCloseSts(string jrnlDate, string orgID, string corptID)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        if (corptID != null && corptID!="")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(corptID);
        }
        if (orgID != null && orgID!="") 
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(orgID);
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts.ToString();
    }
    public void LoadCurrencies()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLedger.ReadCurrencies(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtdiv;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
            //ddlCurrency.ClearSelection();
            ddlCurrency.Items.FindByValue(dtdiv.Rows[0][2].ToString()).Selected = true;
        }

    }
    public void addTable()
    {
        try
        {
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            DataTable dtLedgerDeb = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            objEntityLayerStock.ConfirmSts = 1;
            DataTable dtLedgerCre = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            DataTable dtCostCentr = objBusinessLayerStock.ReadCostCentrDdl(objEntityLayerStock);
            if (dtCostCentr.Rows.Count > 0)
            {
                ddlMainCostCenter.DataSource = dtCostCentr;
                ddlMainCostCenter.DataTextField = "COSTCNTR_NAME";
                ddlMainCostCenter.DataValueField = "COSTCNTR_ID";
                ddlMainCostCenter.DataBind();
            }
            ddlMainCostCenter.Items.Insert(0, "-Select Cost Center-");
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr id=\"MainRowDeb0\">");
            sb.Append("<td style=\"display:none;\">0</td>");
            sb.Append("<td style=\"display:none;\"></td>");
            sb.Append("<td style=\"width:32%;\">");
            sb.Append("<div id=\"divLedDeb0\"><select class=\"form-control ddl\" id=\"ddlLedDeb0\" onblur=\"IncrmntConfrmCounter();\" onchange=\"return changeLedger(0,'Deb');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
            sb.Append("<option>-Select Ledger-</option>");
            for (int intRowCount = 0; intRowCount < dtLedgerDeb.Rows.Count; intRowCount++)
            {
                sb.Append("<option value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
            }
            sb.Append("</select></div>");
            sb.Append("<label id=\"lblBalDeb0\" style=\"font-size: 11px;margin-top: 1%;\"></label>");
            sb.Append("</td>");
            sb.Append("<td style=\"width:30%;\">");
            sb.Append("<input type=\"text\" class=\"form-control\" style=\"padding: 6px;text-align: right;\" id=\"txtTotAmntDeb0\" onchange=\"changeLedgrAmnt(0,'Deb');\"  onkeypress=\"return isDecimalNumber(event,'txtTotAmntDeb0')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntDeb0')\" onblur=\"return AmountChecking('txtTotAmntDeb0');\"  maxlength=12 >");
            sb.Append("</td>");

            sb.Append("<td class=\"smart-form\" style=\"width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\">");
            sb.Append("<button id=\"ChkPurchaseDeb0\" type=\"button\" class=\"btn\" onclick=\"return ddlLedOnchange('0','Deb');\" style=\"padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;\">Sales</button>");
            sb.Append("<button id=\"ChkCostCenterDeb0\" type=\"button\" class=\"btn\" onclick=\"MyModalCostCenter('0','Deb');\" style=\"padding: 6px 12px;width: 86%;height: 32px;\">Cost Center</button>");
            sb.Append("</td>");

            sb.Append("<td style=\"width:10%;padding:10px;\">");
            sb.Append("<button class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainDeb0\"  onclick=\"return addMainTabRow(0,'Deb');\">");
            sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
            sb.Append("</button>");
            sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainDeb0\" onclick=\"return delMainTabRow(0,'Deb');\">");
            sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
            sb.Append("</button>");
            sb.Append("</td>");
            sb.Append("<td id=\"DtlPurchaseDeb0\" style=\"display:none;\"></td>");
            sb.Append("<td id=\"DtlCostCenterDeb0\" style=\"display:none;\"></td>");
            sb.Append("</tr>");

            tabMainDebBody.InnerHtml = sb.ToString();

            sb.Clear();
            sb.Append("<tr id=\"MainRowCre0\">");
            sb.Append("<td style=\"display:none;\">0</td>");
            sb.Append("<td style=\"display:none;\"></td>");
            sb.Append("<td style=\"width:32%;\">");
            sb.Append("<div id=\"divLedCre0\"><select class=\"form-control ddl\" id=\"ddlLedCre0\" onblur=\"IncrmntConfrmCounter();\" onchange=\"return changeLedger(0,'Cre');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
            sb.Append("<option>-Select Ledger-</option>");
            for (int intRowCount = 0; intRowCount < dtLedgerCre.Rows.Count; intRowCount++)
            {
                sb.Append("<option value=\"" + dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerCre.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
            }
            sb.Append("</select></div>");
            sb.Append("<label id=\"lblBalCre0\" style=\"font-size: 11px;margin-top: 1%;\"></label>");
            sb.Append("</td>");
            sb.Append("<td style=\"width:30%;\">");
            sb.Append("<input type=\"text\" class=\"form-control\" id=\"txtTotAmntCre0\" style=\"padding: 6px;text-align: right;\" onchange=\"changeLedgrAmnt(0,'Cre');\"   maxlength=12 onkeypress=\"return isDecimalNumber(event,'txtTotAmntCre0')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntCre0')\" onblur=\"return AmountChecking('txtTotAmntCre0');\">");
            sb.Append("</td>");

            sb.Append("<td class=\"smart-form\" style=\"width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\">");
            sb.Append("<button id=\"ChkPurchaseCre0\" type=\"button\" class=\"btn\" onclick=\"return ddlLedOnchange('0','Cre');\" style=\"padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;\">Purchase</button>");
            sb.Append("<button id=\"ChkCostCenterCre0\" type=\"button\" class=\"btn\" onclick=\"MyModalCostCenter('0','Cre');\" style=\"padding: 6px 12px;width: 86%;height: 32px;\">Cost Center</button>");
            sb.Append("</td>");

            sb.Append("<td style=\"width:10%;padding:10px;\">");

            sb.Append("<button class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainCre0\"  onclick=\"return addMainTabRow(0,'Cre');\">");
            sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
            sb.Append("</button>");
            sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainCre0\" onclick=\"return delMainTabRow(0,'Cre');\">");
            sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
            sb.Append("</button>");
            sb.Append("</td>");
            sb.Append("<td id=\"DtlPurchaseCre0\" style=\"display:none;\"></td>");
            sb.Append("<td id=\"DtlCostCenterCre0\" style=\"display:none;\"></td>");
            sb.Append("</tr>");

            tabMainCreBody.InnerHtml = sb.ToString();
        }
        catch (Exception)
        {
        }
    }
    [WebMethod]
    public static string[] LoadSelectList(string tabMode, string NewLedgerId, string orgID, string corptID, string FloatingValueMoney)
    {

        int precision = Convert.ToInt32(FloatingValueMoney);
        string format = String.Format("{{0:N{0}}}", precision);

        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal(); 
        string []ret = new string[2];
        try
        {
            objEntityLayerStock.JournalId = Convert.ToInt32(NewLedgerId);
            if (tabMode == "Cre")
            {
                objEntityLayerStock.ConfirmSts = 1;
            }
            objEntityLayerStock.Org_Id = Convert.ToInt32(orgID);
            objEntityLayerStock.Corp_Id = Convert.ToInt32(corptID);
            DataTable dt = objBusinessLayerStock.ReadSelectList(objEntityLayerStock);
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                sb.Append("<table class=\"list-group bg-grey\" style=\"width:100%\" id=\"TableAddQstn\" >");
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    decimal costAmnt = 0;
                    if (dt.Rows[i][2].ToString() != "")
                        costAmnt = Convert.ToDecimal(dt.Rows[i][2].ToString());
                    string valuestringCost = String.Format(format, costAmnt);
                    sb.Append("<tr class=\"list-group-item\">");
                    //sb.Append("<td class=\"smart-form\" style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align: left;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  id=\"cbxList" + i + "\" value=\"" + dt.Rows[i][0].ToString() + "\"><i  style=\"margin-top:-15%;\"></i></label></td>");
                    sb.Append("<td class=\"smart-form\"  style=\"width:63%;word-break: break-all; word-wrap:break-word;text-align: left;\">" + dt.Rows[i][1].ToString() + " <p style=\"font-size:19px;\">");
                    sb.Append("<span style=\"color:#258e25;font-weight:bold;\">" + dt.Rows[i][3].ToString() + " </span>");
                    sb.Append("<span style=\"display:none;\" id=\"refList" + dt.Rows[i][0].ToString() + "\"> " + dt.Rows[i][1].ToString() + "</span><span style=\"display:none;\" id=\"AmntList" + dt.Rows[i][0].ToString() + "\">" + valuestringCost + "</span>");
                    sb.Append("<span style=\"font-weight:bold;margin-left:3%;\">Rs." + valuestringCost + "</span></p></td>");
                    sb.Append("<td style=\"width:37%;\"><input id=\"txtTotAmntPurSale" + dt.Rows[i][0].ToString() + "\" type=\"text\" class=\"form-control\" style=\"padding: 6px;text-align: right;\"  onchange=\"changePurSaleAmnt(" + dt.Rows[i][0].ToString() + ");\" onkeypress=\"return isDecimalNumber(event,'txtTotAmntPurSale" + dt.Rows[i][0].ToString() + "')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntPurSale" + dt.Rows[i][0].ToString() + "')\"   onblur=\"return AmountChecking('txtTotAmntPurSale" + dt.Rows[i][0].ToString() + "');\" maxlength=\"12\" ></td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            ret[0] = sb.ToString();
            DataTable dtBal = objBusinessLayerStock.ReadLedgrBal(objEntityLayerStock);

            string strSym = "";
            if (dtBal.Rows.Count > 0)
            {
                decimal decNetBal = 0;
                if (dtBal.Rows[0][0].ToString() != "")
                {
                    decNetBal = Convert.ToDecimal(dtBal.Rows[0][0].ToString());
                }
                if (dtBal.Rows[0]["LDGR_OPEN_BAL"].ToString() != "" && dtBal.Rows[0]["LDGR_MODE"].ToString() != "")
                {
                    if (dtBal.Rows[0]["LDGR_MODE"].ToString() == "0")
                    {
                        decNetBal = decNetBal + Convert.ToDecimal(dtBal.Rows[0]["LDGR_OPEN_BAL"].ToString());
                    }
                    else
                    {
                        decNetBal = decNetBal - Convert.ToDecimal(dtBal.Rows[0]["LDGR_OPEN_BAL"].ToString());
                    }
                }
                if (decNetBal > 0)
                {
                    string valuestringCost = String.Format(format, decNetBal);
                    strSym = "Current Balance: " + valuestringCost + " Dr";
                }
                else if (decNetBal < 0)
                {
                    decNetBal = decNetBal * (-1);
                    string valuestringCost = String.Format(format, decNetBal);
                    strSym = "Current Balance: " + valuestringCost + " Cr";
                }
            }
            ret[1] = strSym;
        }
        catch (Exception)
        {
        }
        return ret;
    }
    [WebMethod]
    public static string LoadSelectListById(string tabMode, string CostCentrId, string orgID, string corptID, string FloatingValueMoney)
    {
        int precision = Convert.ToInt32(FloatingValueMoney);
        string format = String.Format("{{0:N{0}}}", precision);

        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        string ret = "";
        objEntityLayerStock.JournalId = Convert.ToInt32(CostCentrId);
        if (tabMode == "Cre")
        {
            objEntityLayerStock.ConfirmSts = 1;
        }
        objEntityLayerStock.Org_Id = Convert.ToInt32(orgID);
        objEntityLayerStock.Corp_Id = Convert.ToInt32(corptID);
        DataTable dt = objBusinessLayerStock.ReadSelectListById(objEntityLayerStock);
        if (dt.Rows.Count > 0)
        {
            decimal costAmnt = 0;
            if (dt.Rows[0][0].ToString() != "")
                costAmnt = Convert.ToDecimal(dt.Rows[0][0].ToString());
            string valuestringCost = String.Format(format, costAmnt);


            ret = valuestringCost;
        }
       
        return ret;
    }
    public class clsLedgrData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string LEDGRTABID { get; set; }
        public string LEDGRID { get; set; }
        public string LEDGRAMNT { get; set; }
    }
    public class clsCostCntrData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string SUBTABID { get; set; }
        public string COSTCENTRTABID { get; set; }
        public string COSTCENTRID { get; set; }
        public string COSTCENTRAMNT { get; set; }
        public string PURSALESTS { get; set; }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        try
        {
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            objEntityLayerStock.RefNum = txtRefNum.Value.ToUpper().Trim();
            objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtDateFrom.Value);
            objEntityLayerStock.CurrencyId = Convert.ToInt32(ddlCurrency.Value);
            objEntityLayerStock.Description = txtDesc.Value.Trim();
            objEntityLayerStock.JournalId = Convert.ToInt32(HiddenFieldJournalId.Value);
            objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(HiddenFieldTotAmnt.Value);


            if (txtExchangeRate.Value.Trim() != "")
                objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());


            List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
            List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

            string jsonData = HiddenFieldJornlDataLedgr.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


            if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
            {
                foreach (clsLedgrData objclsTVData in objTVDataList5)
                {
                    clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                    objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                    objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                    objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                    objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                    objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(objclsTVData.LEDGRAMNT);
                    objEntityJrnlLedgrList.Add(objEntityDtl);
                }
            }

            jsonData = HiddenFieldJornlDataCostCentr.Value;
            c = jsonData.Replace("\"{", "\\{");
            d = c.Replace("\\n", "\r\n");
            g = d.Replace("\\", "");
            h = g.Replace("}\"]", "}]");
            i = h.Replace("}\",", "},");
            List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
            objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


            if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
            {
                foreach (clsCostCntrData objclsTVData in objTVDataList6)
                {
                    if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                    {
                        clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                        objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                        objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);
                        objEntityJrnlCostcentrList.Add(objEntityDtl);
                    }
                }
            }

            objEntityJrnlLedgrList.Reverse();
            objEntityJrnlCostcentrList.Reverse();

            int AcntCloseSts = AccountCloseCheck(txtDateFrom.Value);
            if (AcntCloseSts == 1 && intAccntCloseReopen == 0)
            {
                Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
            }
            else
            {
                objBusinessLayerStock.AddJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                Response.Redirect("fms_Journal.aspx?InsUpd=Ins");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtDateFrom.Value);
                objEntityLayerStock.CurrencyId = Convert.ToInt32(ddlCurrency.Value);
                objEntityLayerStock.Description = txtDesc.Value.Trim();
                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(HiddenFieldTotAmnt.Value);
                if (txtExchangeRate.Value.Trim() != "")
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());
                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                string jsonData = HiddenFieldJornlDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(objclsTVData.LEDGRAMNT);
                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldJornlDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                            objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                            objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                            objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);
                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

                objEntityJrnlLedgrList.Reverse();
                objEntityJrnlCostcentrList.Reverse();
                DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);

                int AcntCloseSts = AccountCloseCheck(txtDateFrom.Value);
                if (AcntCloseSts == 1 && intAccntCloseReopen == 0)
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
                }
                else if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
                {
                    objBusinessLayerStock.EditJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdCancl");
                }
                else
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdConfm");
                }
            }
        }
        catch (Exception)
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

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtDateFrom.Value);
                objEntityLayerStock.CurrencyId = Convert.ToInt32(ddlCurrency.Value);
                objEntityLayerStock.Description = txtDesc.Value.Trim();
                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(HiddenFieldTotAmnt.Value);
                objEntityLayerStock.ConfirmSts = 1;
                if (txtExchangeRate.Value.Trim() != "")
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());

                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                string jsonData = HiddenFieldJornlDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(objclsTVData.LEDGRAMNT);
                        if (txtExchangeRate.Value.Trim() != "")
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt * objEntityLayerStock.ExchangeRate;
                        }
                        else
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt;
                        }
                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldJornlDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                            objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                            objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                            objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);

                            if (txtExchangeRate.Value.Trim() != "")
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt * objEntityLayerStock.ExchangeRate;
                            }
                            else
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt;
                            }


                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

                objEntityJrnlLedgrList.Reverse();
                objEntityJrnlCostcentrList.Reverse();
                DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
                int AcntCloseSts = AccountCloseCheck(txtDateFrom.Value);
                if (AcntCloseSts == 1 && intAccntCloseReopen == 0)
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
                }
                else if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
                {
                    objBusinessLayerStock.ConfirmJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Cnf");
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdCancl");
                }
                else
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdConfm");
                }
            }
        }
        catch (Exception)
        {
        }
    }
    protected void btnReopen_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/ADMIN/Default.aspx");
                }
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtDateFrom.Value);
                objEntityLayerStock.CurrencyId = Convert.ToInt32(ddlCurrency.Value);
                objEntityLayerStock.Description = txtDesc.Value.Trim();
                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                objEntityLayerStock.ConfirmSts = 0;

                if (txtExchangeRate.Value.Trim() != "")
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());
                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                string jsonData = HiddenFieldJornlDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(objclsTVData.LEDGRAMNT);

                        if (txtExchangeRate.Value.Trim() != "")
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt * objEntityLayerStock.ExchangeRate;
                        }
                        else
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt;
                        }

                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldJornlDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                            objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                            objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                            objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);

                            if (txtExchangeRate.Value.Trim() != "")
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt * objEntityLayerStock.ExchangeRate;
                            }
                            else
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt;
                            }

                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

                objEntityJrnlLedgrList.Reverse();
                objEntityJrnlCostcentrList.Reverse();
                DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
                int AcntCloseSts = AccountCloseCheck(txtDateFrom.Value);
                if (AcntCloseSts == 1 && intAccntCloseReopen == 0)
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
                }
                else if (dt.Rows[0][0].ToString() == "")
                {
                    objBusinessLayerStock.ReopenJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Reop");
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdCancl");
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
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            DataTable dtLedgerDeb = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            objEntityLayerStock.ConfirmSts = 1;
            DataTable dtLedgerCre = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            DataTable dtCostCentr = objBusinessLayerStock.ReadCostCentrDdl(objEntityLayerStock);
            objEntityLayerStock.JournalId = Convert.ToInt32(id);
            DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
            if (dt.Rows.Count > 0)
            {

                int AcntCloseSts = AccountCloseCheck(dt.Rows[0]["JURNL_DATE"].ToString());
                txtExchangeRate.Value = dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString();

                if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
                {
                    btnConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    if ((intReopen == 1 && AcntCloseSts == 0) || intAccntCloseReopen == 1)
                    {
                        btnReopen.Visible = true;
                    }
                    else
                    {
                        btnReopen.Visible = false;
                    }
                    View(id, intConfirm, intReopen);
                }
                else if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "0" && AcntCloseSts == 1 && intAccntCloseReopen == 0)
                {
                    btnConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnReopen.Visible = false;
                    View(id, intConfirm, intReopen);
                }
                else
                {
                    btnReopen.Visible = false;
                    if (intConfirm == 1)
                    {
                        btnConfirm.Visible = true;
                    }
                    else
                    {
                        btnConfirm.Visible = false;
                    }


                    txtRefNum.Value = dt.Rows[0]["JURNL_REF"].ToString();
                    txtDateFrom.Value = dt.Rows[0]["JURNL_DATE"].ToString();

                    ddlCurrency.SelectedIndex = -1;


                    if (ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                    {
                        ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dt.Rows[0]["CRNCMST_NAME"].ToString(), dt.Rows[0]["CRNCMST_ID"].ToString());
                        ddlCurrency.Items.Insert(1, lstGrp);
                        //SortDDL(ref this.ddlCurrency);
                        ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                    }
                    txtDesc.Value = dt.Rows[0]["JURNL_DSCRPTN"].ToString();
                    //For debit side
                    objEntityLayerStock.ConfirmSts = 0;
                    StringBuilder sb = new StringBuilder();



                    int precision = Convert.ToInt32(HiddenFieldDecimalCnt.Value);
                    string format = String.Format("{{0:N{0}}}", precision);


                    DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                    for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                    {
                        sb.Append("<tr id=\"MainRowDeb" + i + "\">");
                        sb.Append("<td style=\"display:none;\">" + i + "</td>");
                        sb.Append("<td style=\"display:none;\">" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"width:32%;\">");
                        sb.Append("<div id=\"divLedDeb" + i + "\"><select onblur=\"IncrmntConfrmCounter();\" class=\"form-control ddl\" id=\"ddlLedDeb" + i + "\" onchange=\"return changeLedger(" + i + ",'Deb');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        sb.Append("<option>-Select Ledger-</option>");
                        int f = 0;
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
                        sb.Append("</select></div>");

                        string strSym = "";
                        decimal decNetBal = 0;
                        if (dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString() != "")
                        {
                            decNetBal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString());
                        }
                        if (dtLedgrdDebDtl.Rows[0]["LDGR_OPEN_BAL"].ToString() != "" && dtLedgrdDebDtl.Rows[0]["LDGR_MODE"].ToString() != "")
                        {
                            if (dtLedgrdDebDtl.Rows[0]["LDGR_MODE"].ToString() == "0")
                            {
                                decNetBal = decNetBal + Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            }
                            else
                            {
                                decNetBal = decNetBal - Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            }
                        }
                        if (decNetBal > 0)
                        {
                            string valuestring = String.Format(format, decNetBal);
                            strSym = "Current Balance: " + valuestring + " Dr";
                        }
                        else if (decNetBal < 0)
                        {
                            decNetBal = decNetBal * (-1);
                            string valuestring = String.Format(format, decNetBal);
                            strSym = "Current Balance: " + valuestring + " Cr";
                        }

                        sb.Append("<label id=\"lblBalDeb" + i + "\" style=\"font-size: 11px;margin-top: 1%;\">" + strSym + "</label>");
                        sb.Append("</td>");
                        objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                        DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                        string strCostDtl = "", strPurchaseDtl = "";
                        for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                        {
                            decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                            string valuestringCost = String.Format(format, costAmnt);
                            if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                            {
                                if (strCostDtl == "")
                                {
                                    strCostDtl = dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                                }
                                else
                                {
                                    strCostDtl = strCostDtl + "$" + dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                                }
                            }
                            else
                            {
                                if (strPurchaseDtl == "")
                                {
                                    strPurchaseDtl = dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost;
                                }
                                else
                                {
                                    strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost;
                                }
                            }
                        }


                        sb.Append("<td style=\"width:30%;\">");

                        decimal LedgrAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                        string valuestringLedg = String.Format(format, LedgrAmnt);
                        sb.Append("<input type=\"text\" class=\"form-control\" style=\"padding: 6px;text-align: right;\" value=\"" + valuestringLedg + "\" id=\"txtTotAmntDeb" + i + "\" onchange=\"changeLedgrAmnt(" + i + ",'Deb');\" onkeypress=\"return isDecimalNumber(event,'txtTotAmntDeb" + i + "')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntDeb" + i + "')\"   onblur=\"return AmountChecking('txtTotAmntDeb" + i + "');\"  maxlength=12 >");
                        sb.Append("</td>");

                        sb.Append("<td class=\"smart-form\" style=\"width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\">");
                        sb.Append("<button id=\"ChkPurchaseDeb" + i + "\" type=\"button\" class=\"btn\" onclick=\"return ddlLedOnchange(" + i + ",'Deb');\" style=\"padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;\">Sales</button>");
                        sb.Append("<button id=\"ChkCostCenterDeb" + i + "\" type=\"button\" class=\"btn\" onclick=\"MyModalCostCenter(" + i + ",'Deb');\" style=\"padding: 6px 12px;width: 86%;height: 32px;\">Cost Center</button>");
                        sb.Append("</td>");


                        sb.Append("<td style=\"width:10%;padding:10px;\">");
                        if (i == dtLedgrdDebDtl.Rows.Count - 1)
                        {
                            sb.Append("<button class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainDeb" + i + "\"  onclick=\"return addMainTabRow(" + i + ",'Deb');\">");
                            sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");
                            sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainDeb" + i + "\" onclick=\"return delMainTabRow(" + i + ",'Deb');\">");
                            sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");

                        }
                        else
                        {
                            sb.Append("<button disabled class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainDeb" + i + "\"  onclick=\"return addMainTabRow(" + i + ",'Deb');\">");
                            sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");
                            sb.Append("<button  class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainDeb" + i + "\" onclick=\"return delMainTabRow(" + i + ",'Deb');\">");
                            sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");

                        }
                        sb.Append("</td>");

                        sb.Append("<td id=\"DtlPurchaseDeb" + i + "\" style=\"display:none;\">" + strPurchaseDtl + "</td>");
                        sb.Append("<td id=\"DtlCostCenterDeb" + i + "\" style=\"display:none;\">" + strCostDtl + "</td>");

                        sb.Append("</tr>");
                    }
                    tabMainDebBody.InnerHtml = sb.ToString();
                    //For credit side
                    sb.Clear();
                    objEntityLayerStock.JournalId = Convert.ToInt32(id);
                    objEntityLayerStock.ConfirmSts = 1;
                    DataTable dtLedgrdCreDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                    for (int i = 0; i < dtLedgrdCreDtl.Rows.Count; i++)
                    {
                        sb.Append("<tr id=\"MainRowCre" + i + "\">");
                        sb.Append("<td style=\"display:none;\">" + i + "</td>");
                        sb.Append("<td style=\"display:none;\">" + dtLedgrdCreDtl.Rows[i]["LD_JURNL_ID"].ToString() + "</td>");
                        sb.Append("<td style=\"width:32%;\">");
                        sb.Append("<div id=\"divLedCre" + i + "\"><select onblur=\"IncrmntConfrmCounter();\" class=\"form-control ddl\" id=\"ddlLedCre" + i + "\" onchange=\"return changeLedger(" + i + ",'Cre');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        sb.Append("<option>-Select Ledger-</option>");
                        int f = 0;
                        for (int intRowCount = 0; intRowCount < dtLedgerCre.Rows.Count; intRowCount++)
                        {
                            if (dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() == dtLedgrdCreDtl.Rows[i]["LDGR_ID"].ToString())
                            {
                                f = 1;
                                sb.Append("<option selected value=\"" + dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerCre.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                            }
                            else
                            {
                                sb.Append("<option value=\"" + dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerCre.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                            }
                        }
                        if (f == 0)
                        {
                            sb.Append("<option selected value=\"" + dtLedgrdCreDtl.Rows[i]["LDGR_ID"].ToString() + "\">" + dtLedgrdCreDtl.Rows[i]["LDGR_NAME"].ToString() + "</option>");
                        }
                        sb.Append("</select></div>");
                        string strSym = "";
                        decimal decNetBal = 0;


                        if (dtLedgrdCreDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString() != "")
                        {
                            decNetBal = Convert.ToDecimal(dtLedgrdCreDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString());
                        }
                        if (dtLedgrdCreDtl.Rows[0]["LDGR_OPEN_BAL"].ToString() != "" && dtLedgrdCreDtl.Rows[0]["LDGR_MODE"].ToString() != "")
                        {
                            if (dtLedgrdCreDtl.Rows[0]["LDGR_MODE"].ToString() == "0")
                            {
                                decNetBal = decNetBal + Convert.ToDecimal(dtLedgrdCreDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            }
                            else
                            {
                                decNetBal = decNetBal - Convert.ToDecimal(dtLedgrdCreDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            }
                        }

                        if (decNetBal > 0)
                        {
                            string valuestring = String.Format(format, decNetBal);
                            strSym = "Current Balance: " + valuestring + " Dr";
                        }
                        else if (decNetBal < 0)
                        {
                            decNetBal = decNetBal * (-1);
                            string valuestring = String.Format(format, decNetBal);
                            strSym = "Current Balance: " + valuestring + " Cr";
                        }

                        sb.Append("<label id=\"lblBalCre" + i + "\" style=\"font-size: 11px;margin-top: 1%;\">" + strSym + "</label>");
                        sb.Append("</td>");


                        objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdCreDtl.Rows[i]["LD_JURNL_ID"].ToString());
                        DataTable dtCostCntrCreDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                        string strCostDtl = "", strPurchaseDtl = "";
                        for (int j = 0; j < dtCostCntrCreDtl.Rows.Count; j++)
                        {
                            decimal costAmnt = Convert.ToDecimal(dtCostCntrCreDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                            string valuestringCost = String.Format(format, costAmnt);
                            if (dtCostCntrCreDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                            {
                                if (strCostDtl == "")
                                {
                                    strCostDtl = dtCostCntrCreDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                                }
                                else
                                {
                                    strCostDtl = strCostDtl + "$" + dtCostCntrCreDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                                }
                            }
                            else
                            {
                                if (strPurchaseDtl == "")
                                {
                                    strPurchaseDtl = dtCostCntrCreDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost;
                                }
                                else
                                {
                                    strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrCreDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost;
                                }
                            }
                        }

                        sb.Append("<td style=\"width:30%;\">");
                        Decimal LedgAmnt = Convert.ToDecimal(dtLedgrdCreDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                        string valuestringLedg = String.Format(format, LedgAmnt);
                        sb.Append("<input type=\"text\" class=\"form-control\" style=\"padding: 6px;text-align: right;\" value=\"" + valuestringLedg + "\" id=\"txtTotAmntCre" + i + "\" onchange=\"changeLedgrAmnt(" + i + ",'Cre');\"  maxlength=12 onkeypress=\"return isDecimalNumber(event,'txtTotAmntCre" + i + "')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntCre" + i + "')\" onblur=\"return AmountChecking('txtTotAmntCre" + i + "');\" >");
                        sb.Append("</td>");

                        sb.Append("<td class=\"smart-form\" style=\"width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\">");
                        sb.Append("<button id=\"ChkPurchaseCre" + i + "\" type=\"button\" class=\"btn\" onclick=\"return ddlLedOnchange(" + i + ",'Cre');\" style=\"padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;\">Purchase</button>");
                        sb.Append("<button id=\"ChkCostCenterCre" + i + "\" type=\"button\" class=\"btn\" onclick=\"MyModalCostCenter(" + i + ",'Cre');\" style=\"padding: 6px 12px;width: 86%;height: 32px;\">Cost Center</button>");
                        sb.Append("</td>");


                        sb.Append("<td style=\"width:10%;padding:10px;\">");
                        if (i == dtLedgrdCreDtl.Rows.Count - 1)
                        {
                            sb.Append("<button class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainCre" + i + "\"  onclick=\"return addMainTabRow(" + i + ",'Cre');\">");
                            sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");
                            sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainCre" + i + "\" onclick=\"return delMainTabRow(" + i + ",'Cre');\">");
                            sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");
                        }
                        else
                        {
                            sb.Append("<button disabled class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainCre" + i + "\"  onclick=\"return addMainTabRow(" + i + ",'Cre');\">");
                            sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");
                            sb.Append("<button  class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainCre" + i + "\" onclick=\"return delMainTabRow(" + i + ",'Cre');\">");
                            sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                            sb.Append("</button>");
                        }

                        sb.Append("</td>");

                        sb.Append("<td id=\"DtlPurchaseCre" + i + "\" style=\"display:none;\">" + strPurchaseDtl + "</td>");
                        sb.Append("<td id=\"DtlCostCenterCre" + i + "\" style=\"display:none;\">" + strCostDtl + "</td>");

                        sb.Append("</tr>");
                    }
                    tabMainCreBody.InnerHtml = sb.ToString();
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public void View(string id, int intConfirm, int intReopen)
    {
        try
        {
            HiddenFieldViewMode.Value = "1";
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/ADMIN/Default.aspx");
            }
            DataTable dtLedgerDeb = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            objEntityLayerStock.ConfirmSts = 1;
            DataTable dtLedgerCre = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            DataTable dtCostCentr = objBusinessLayerStock.ReadCostCentrDdl(objEntityLayerStock);
            objEntityLayerStock.JournalId = Convert.ToInt32(id);
            DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
            if (dt.Rows.Count > 0)
            {

                txtExchangeRate.Value = dt.Rows[0]["JURNL_EXCHAN_RATE"].ToString();
                txtRefNum.Value = dt.Rows[0]["JURNL_REF"].ToString();
                txtDateFrom.Value = dt.Rows[0]["JURNL_DATE"].ToString();
                ddlCurrency.SelectedIndex = -1;
                if (ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["CRNCMST_NAME"].ToString(), dt.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);
                    //SortDDL(ref this.ddlCurrency);
                    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                txtDesc.Value = dt.Rows[0]["JURNL_DSCRPTN"].ToString();
                txtExchangeRate.Disabled = true;
                txtDesc.Disabled = true;
                ddlCurrency.Disabled = true;
                txtDateFrom.Disabled = true;
                //For debit side
                objEntityLayerStock.ConfirmSts = 0;
                StringBuilder sb = new StringBuilder();

                int precision = Convert.ToInt32(HiddenFieldDecimalCnt.Value);
                string format = String.Format("{{0:N{0}}}", precision);

                DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                {
                    sb.Append("<tr id=\"MainRowDeb" + i + "\">");
                    sb.Append("<td style=\"display:none;\">" + i + "</td>");
                    sb.Append("<td style=\"display:none;\">" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() + "</td>");
                    sb.Append("<td style=\"width:32%;\">");
                    sb.Append("<div id=\"divLedDeb" + i + "\"><select disabled class=\"form-control ddl\" id=\"ddlLedDeb" + i + "\" onchange=\"return changeLedger(" + i + ",'Deb');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option>-Select Ledger-</option>");
                    int f = 0;
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
                    sb.Append("</select></div>");
                    string strSym = "";
                    decimal decNetBal = 0;
                    if (dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString() != "")
                    {
                        decNetBal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString());
                    }

                    if (dtLedgrdDebDtl.Rows[0]["LDGR_OPEN_BAL"].ToString() != "" && dtLedgrdDebDtl.Rows[0]["LDGR_MODE"].ToString() != "")
                    {
                        if (dtLedgrdDebDtl.Rows[0]["LDGR_MODE"].ToString() == "0")
                        {
                            decNetBal = decNetBal + Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                        else
                        {
                            decNetBal = decNetBal - Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                    }
                    if (decNetBal > 0)
                    {
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "Current Balance: " + valuestring + " Dr";
                    }
                    else if (decNetBal < 0)
                    {
                        decNetBal = decNetBal * (-1);
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "Current Balance: " + valuestring + " Cr";
                    }
                    sb.Append("<label id=\"lblBalDeb" + i + "\" style=\"font-size: 11px;margin-top: 1%;\">" + strSym + "</label>");
                    sb.Append("</td>");




                    objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                    DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                    string strCostDtl = "", strPurchaseDtl = "";
                    for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                    {
                        decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                        string valuestringCost = String.Format(format, costAmnt);
                        if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                        {
                            if (strCostDtl == "")
                            {
                                strCostDtl = dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                            }
                            else
                            {
                                strCostDtl = strCostDtl + "$" + dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                            }
                        }
                        else
                        {
                            if (strPurchaseDtl == "")
                            {
                                strPurchaseDtl = dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost;
                            }
                            else
                            {
                                strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost;
                            }
                        }
                    }
                    sb.Append("<td style=\"width:30%;\">");

                    Decimal LedgAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                    string valuestringLedg = String.Format(format, LedgAmnt);

                    sb.Append("<input disabled type=\"text\" style=\"padding: 6px;text-align: right;\" class=\"form-control\" value=\"" + valuestringLedg + "\" id=\"txtTotAmntDeb" + i + "\" onchange=\"changeLedgrAmnt(" + i + ",'Deb');\" onkeypress=\"return isDecimalNumber(event,'txtTotAmntDeb" + i + "')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntDeb" + i + "')\" onblur=\"return AmountChecking('txtTotAmntDeb" + i + "');\"  maxlength=12 >");
                    sb.Append("</td>");


                    sb.Append("<td class=\"smart-form\" style=\"width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\">");
                    sb.Append("<button  id=\"ChkPurchaseDeb" + i + "\" type=\"button\" class=\"btn\" onclick=\"return ddlLedOnchange(" + i + ",'Deb');\" style=\"padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;\">Sales</button>");
                    sb.Append("<button  id=\"ChkCostCenterDeb" + i + "\" type=\"button\" class=\"btn\" onclick=\"MyModalCostCenter(" + i + ",'Deb');\" style=\"padding: 6px 12px;width: 86%;height: 32px;\">Cost Center</button>");
                    sb.Append("</td>");



                    sb.Append("<td style=\"width:10%;padding:10px\">");
                    sb.Append("<button disabled class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainDeb" + i + "\"  onclick=\"return addMainTabRow(" + i + ",'Deb');\">");
                    sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                    sb.Append("</button>");
                    sb.Append("<button disabled class=\"btn btn-primary\" title=\"Delete\" style=\"margin-top:2%;\" id=\"btnDelMainDeb" + i + "\" onclick=\"return delMainTabRow(" + i + ",'Deb');\">");
                    sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                    sb.Append("</button>");
                    sb.Append("</td>");

                    sb.Append("<td id=\"DtlPurchaseDeb" + i + "\" style=\"display:none;\">" + strPurchaseDtl + "</td>");
                    sb.Append("<td id=\"DtlCostCenterDeb" + i + "\" style=\"display:none;\">" + strCostDtl + "</td>");

                    sb.Append("</tr>");
                }
                tabMainDebBody.InnerHtml = sb.ToString();
                //For credit side
                sb.Clear();
                objEntityLayerStock.JournalId = Convert.ToInt32(id);
                objEntityLayerStock.ConfirmSts = 1;
                DataTable dtLedgrdCreDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                for (int i = 0; i < dtLedgrdCreDtl.Rows.Count; i++)
                {
                    sb.Append("<tr id=\"MainRowCre" + i + "\">");
                    sb.Append("<td style=\"display:none;\">" + i + "</td>");
                    sb.Append("<td style=\"display:none;\">" + dtLedgrdCreDtl.Rows[i]["LD_JURNL_ID"].ToString() + "</td>");
                    sb.Append("<td style=\"width:32%;\">");
                    sb.Append("<div id=\"divLedCre" + i + "\"><select disabled class=\"form-control ddl\" id=\"ddlLedCre" + i + "\" onchange=\"return changeLedger(" + i + ",'Cre');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option>-Select Ledger-</option>");
                    int f = 0;
                    for (int intRowCount = 0; intRowCount < dtLedgerCre.Rows.Count; intRowCount++)
                    {
                        if (dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() == dtLedgrdCreDtl.Rows[i]["LDGR_ID"].ToString())
                        {
                            f = 1;
                            sb.Append("<option selected value=\"" + dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerCre.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dtLedgerCre.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerCre.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                        }
                    }
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dtLedgrdCreDtl.Rows[i]["LDGR_ID"].ToString() + "\">" + dtLedgrdCreDtl.Rows[i]["LDGR_NAME"].ToString() + "</option>");
                    }
                    sb.Append("</select></div>");
                    string strSym = "";
                    decimal decNetBal = 0;
                    if (dtLedgrdCreDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString() != "")
                    {
                        decNetBal = Convert.ToDecimal(dtLedgrdCreDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString());
                    }
                    if (dtLedgrdCreDtl.Rows[0]["LDGR_OPEN_BAL"].ToString() != "" && dtLedgrdCreDtl.Rows[0]["LDGR_MODE"].ToString() != "")
                    {
                        if (dtLedgrdCreDtl.Rows[0]["LDGR_MODE"].ToString() == "0")
                        {
                            decNetBal = decNetBal + Convert.ToDecimal(dtLedgrdCreDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                        else
                        {
                            decNetBal = decNetBal - Convert.ToDecimal(dtLedgrdCreDtl.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                    }

                    if (decNetBal > 0)
                    {
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "Current Balance: " + valuestring + " Dr";
                    }
                    else if (decNetBal < 0)
                    {
                        decNetBal = decNetBal * (-1);
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "Current Balance: " + valuestring + " Cr";
                    }
                    sb.Append("<label id=\"lblBalCre" + i + "\" style=\"font-size: 11px;margin-top: 1%;\">" + strSym + "</label>");
                    sb.Append("</td>");




                    objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdCreDtl.Rows[i]["LD_JURNL_ID"].ToString());
                    DataTable dtCostCntrCreDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                    string strCostDtl = "", strPurchaseDtl = "";
                    for (int j = 0; j < dtCostCntrCreDtl.Rows.Count; j++)
                    {
                        decimal costAmnt = Convert.ToDecimal(dtCostCntrCreDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                        string valuestringCost = String.Format(format, costAmnt);
                        if (dtCostCntrCreDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                        {
                            if (strCostDtl == "")
                            {
                                strCostDtl = dtCostCntrCreDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                            }
                            else
                            {
                                strCostDtl = strCostDtl + "$" + dtCostCntrCreDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost;
                            }
                        }
                        else
                        {
                            if (strPurchaseDtl == "")
                            {
                                strPurchaseDtl = dtCostCntrCreDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost;
                            }
                            else
                            {
                                strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrCreDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost;
                            }
                        }
                    }

                    sb.Append("<td style=\"width:30%;\">");

                    Decimal LedgAmnt = Convert.ToDecimal(dtLedgrdCreDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                    string valuestringLedg = String.Format(format, LedgAmnt);
                    sb.Append("<input disabled type=\"text\" class=\"form-control\" style=\"padding: 6px;text-align: right;\" value=\"" + valuestringLedg + "\" id=\"txtTotAmntCre" + i + "\" onchange=\"changeLedgrAmnt(" + i + ",'Cre');\"  maxlength=12 onkeypress=\"return isDecimalNumber(event,'txtTotAmntCre" + i + "')\" onkeydown=\"return isDecimalNumber(event,'txtTotAmntCre" + i + "')\" onblur=\"return AmountChecking('txtTotAmntCre" + i + "');\">");
                    sb.Append("</td>");

                    sb.Append("<td class=\"smart-form\" style=\"width:28%;word-break: break-all; word-wrap:break-word;text-align: center;\">");
                    sb.Append("<button  id=\"ChkPurchaseCre" + i + "\" type=\"button\" class=\"btn\" onclick=\"return ddlLedOnchange(" + i + ",'Cre');\" style=\"padding: 6px 12px;padding: 6px 12px;width: 86%; margin-bottom: 2%; height: 32px;\">Purchase</button>");
                    sb.Append("<button  id=\"ChkCostCenterCre" + i + "\" type=\"button\" class=\"btn\" onclick=\"MyModalCostCenter(" + i + ",'Cre');\" style=\"padding: 6px 12px;width: 86%;height: 32px;\">Cost Center</button>");
                    sb.Append("</td>");

                    sb.Append("<td style=\"width:10%;padding:10px\">");
                    sb.Append("<button disabled class=\"btn btn-primary\" title=\"Delete\"  id=\"btnDelMainCre" + i + "\" onclick=\"return delMainTabRow(" + i + ",'Cre');\">");
                    sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                    sb.Append("</button>");
                    sb.Append("<button disabled class=\"btn btn-primary\" title=\"Add\" id=\"btnAddMainCre" + i + "\" style=\"margin-top:2%;\" onclick=\"return addMainTabRow(" + i + ",'Cre');\">");
                    sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                    sb.Append("</button>");
                    sb.Append("</td>");

                    sb.Append("<td id=\"DtlPurchaseCre" + i + "\" style=\"display:none;\">" + strPurchaseDtl + "</td>");
                    sb.Append("<td id=\"DtlCostCenterCre" + i + "\" style=\"display:none;\">" + strCostDtl + "</td>");

                    sb.Append("</tr>");
                }
                tabMainCreBody.InnerHtml = sb.ToString();
            }
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
}