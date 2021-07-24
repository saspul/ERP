using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using EL_Compzit.EntityLayer_PMS;
using BL_Compzit.BusinessLayer_PMS;
using EL_Compzit;
using BL_Compzit;
using CL_Compzit;
using System.Web.Services;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using EL_Compzit.EntityLayer_FMS;

public partial class PMS_PMS_Master_pms_Purchase_Order_pms_Purchase_Order : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["VId"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzitModal.master";
        }
        else
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
        }
    }

    clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
    clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

    clsBusinessLayer objBusinessLayer= new clsBusinessLayer();
    clsEntityCommon objEntityCommon = new clsEntityCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            this.Form.Enctype = "multipart/form-data";

            txtPrchsOrdrDate.Value = objBusinessLayer.LoadCurrentDateInString();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {       clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                               clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                               clsCommonLibrary.CORP_GLOBAL.CMN_PERCENT_DECIMAL,
                                                               clsCommonLibrary.CORP_GLOBAL.TAX_PERC_DECIMAL,
                                                       };
            DataTable dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId); //GN_CORP_GLOBAL
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDefaultCurrencyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                hiddenTaxEnabled.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenPercntgDecimalCount.Value = dtCorpDetail.Rows[0]["CMN_PERCENT_DECIMAL"].ToString();
                hiddenTaxDecimalCount.Value = dtCorpDetail.Rows[0]["TAX_PERC_DECIMAL"].ToString();
            }

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDefaultCurrencyId.Value);
            DataTable dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon); //CURRENCY
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                hiddenDefaultCrncyAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }

            LoadModeOfSupply();
            LoadCurrency();
            LoadDocumntWrkflw();
            LoadDivision();

            LoadProjects();
            LoadWarehouse();
            LoadCustomer();
            ddlPOContact.Items.Insert(0, "--SELECT CONTACT PERSON--");
            LoadVendorContacts();

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_MASTER);
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);

            clsCommonLibrary objCommon = new clsCommonLibrary();
            DateTime dtCurrentDate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

            DataTable dtFormate = objBusinessLayer.ReadRefFormat(objEntityCommon);

            int intOrgId = objEntityPurchaseOrder.OrgId;
            int intUsrId = objEntityPurchaseOrder.UserId;
            int DtYear = dtCurrentDate.Year;
            int DtMonth = dtCurrentDate.Month;
            string dtyy = dtCurrentDate.ToString("yy");

            string RefNo = "";
            string RefFormat = "";
            string strRealFormat = "";
            if (dtFormate.Rows.Count > 0)
            {
                if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                {
                    RefFormat = dtFormate.Rows[0]["REF_FORMATE"].ToString();

                    string[] arrReferenceSplit = RefFormat.Split('*');
                    if (RefFormat == "" || RefFormat == null)
                    {
                        strRealFormat = strNextId;
                    }
                    else
                    {
                        strRealFormat = RefFormat.ToString();
                        if (strRealFormat.Contains("#ORG#"))
                        {
                            strRealFormat = strRealFormat.Replace("#ORG#", intOrgId.ToString());
                        }
                        if (strRealFormat.Contains("#COR#"))
                        {
                            strRealFormat = strRealFormat.Replace("#COR#", intCorpId.ToString());
                        }

                        if (strRealFormat.Contains("#USR#"))
                        {
                            strRealFormat = strRealFormat.Replace("#USR#", intUsrId.ToString());
                        }
                        //2019
                        if (strRealFormat.Contains("#YER#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                        }
                        //19
                        if (strRealFormat.Contains("#YY#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                        }
                        if (strRealFormat.Contains("#MON#"))
                        {
                            strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                        }
                        if (strRealFormat.Contains("#NUM#"))
                        {
                            strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                        }
                        else
                        {
                            strRealFormat = strRealFormat + "/" + strNextId;
                        }
                        strRealFormat = strRealFormat.Replace("#", "");
                    }
                    RefNo = strRealFormat;
                }
            }
            else
            {
                RefNo = strNextId;
            }

            txtPrchsOrdrRef.Text = RefNo;

            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Purchase_Order_Master);
            int intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableDiscount = 0, intEnableConfirm = 0, intEnableReopen = 0;
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
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
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString())
                    {
                        intEnableDiscount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }
            }

            hiddenEnableReopen.Value = intEnableReopen.ToString();

            btnSave.Visible = false;
            btnSaveFloat.Visible = false;
            btnSaveAndClose.Visible = false;
            btnSaveAndCloseFloat.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateAndClose.Visible = false;
            btnUpdateFloat.Visible = false;
            btnUpdateAndCloseFloat.Visible = false;
            btnClear.Visible = false;
            btnClearFloat.Visible = false;
            btnConfirm.Visible = false;
            btnConfirmFloat.Visible = false;
            btnReopen.Visible = false;
            btnReopenFloat.Visible = false;

            //Edit
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                lblEntry.Text = "Edit Purchase Order";
                if (intEnableModify == 1)
                {
                    btnUpdate.Visible = true;
                    btnUpdateAndClose.Visible = true;
                    btnUpdateFloat.Visible = true;
                    btnUpdateAndCloseFloat.Visible = true;
                    if (intEnableConfirm == 1)
                    {
                        btnConfirm.Visible = true;
                        btnConfirmFloat.Visible = true;
                    }
                }
                if (Request.QueryString["VId"] != null)
                {
                    divList.Visible = false;
                    OlSection.Visible = false;
                    qk_bo.Attributes.Add("style", "display:none;");
                    divQuickSearch.Attributes.Add("style", "display:none;");

                    if (Request.QueryString["VId"].ToString() == "1")
                    {
                        hiddenApprvaCnslMode.Value = "1";
                        ddlDocumntWrkflw.Attributes.Add("readonly", "true");
                        btnConfirm.Visible = false;
                        btnConfirmFloat.Visible = false;
                        btnUpdateAndClose.Visible = false;
                        btnUpdateAndCloseFloat.Visible = false;
                    }
                    else
                    {
                        hiddenApprvaCnslMode.Value = "0";
                        btnUpdate.Visible = false;
                        btnUpdateAndClose.Visible = false;
                        btnUpdateFloat.Visible = false;
                        btnUpdateAndCloseFloat.Visible = false;
                        btnConfirm.Visible = false;
                        btnConfirmFloat.Visible = false;
                        lblEntry.Text = "View Purchase Order";
                    }
                }

                UpdateView(strId);
            }
            //View
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                hiddenView.Value = "1";
                lblEntry.Text = "View Purchase Order";

                if (Request.QueryString["VId"] != null)
                {
                    divList.Visible = false;
                    OlSection.Visible = false;
                    qk_bo.Attributes.Add("style", "display:none;");
                    divQuickSearch.Attributes.Add("style", "display:none;");
                    hiddenApprvaCnslMode.Value = "0";
                }

                UpdateView(strId);
            }
            //Add
            else
            {
                if (intEnableAdd == 1)
                {
                    btnSave.Visible = true;
                    btnSaveFloat.Visible = true;
                    btnSaveAndClose.Visible = true;
                    btnSaveAndCloseFloat.Visible = true;
                }

                lblEntry.Text = "Add Purchase Order";
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Dup")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
                }
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopen", "SuccessReopen();", true);
                }
                else if (strInsUpd == "AlrdyReopnd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyReopened", "AlreadyReopened();", true);
                }
                else if (strInsUpd == "AlrdyCnfrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfirmed", "AlreadyConfirmed();", true);
                }
                else if (strInsUpd == "AlrdyDeleted")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyDeleted", "AlreadyDeleted();", true);
                }
            }

            ddlPrchsOrdrType.Focus();

        }
    }

    public void LoadModeOfSupply()
    {
        DataTable dt = objBusinessPurchaseOrder.ReadModeOfSupply(objEntityPurchaseOrder);

        ddlModeofSupply.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlModeofSupply.DataSource = dt;
            ddlModeofSupply.DataTextField = "MODEFSUPPLY_NAME";
            ddlModeofSupply.DataValueField = "MODEFSUPPLY_ID";
            ddlModeofSupply.DataBind();
        }
        ddlModeofSupply.Items.Insert(0, "--SELECT MODE OF SUPPLY--");
    }

    public void LoadCurrency()
    {
        ddlCurrency.ClearSelection();
        DataTable dtSubConrt = objBusinessLayer.ReadCurrency(objEntityCommon);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
        }

        string strdefltcurrcy = hiddenDefaultCurrencyId.Value;
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
        {
            ddlCurrency.ClearSelection();
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
        }
    }

    public void LoadDivision()
    {
        DataTable dt = objBusinessPurchaseOrder.ReadDivision(objEntityPurchaseOrder);

        ddlPODivision.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlPODivision.DataSource = dt;
            ddlPODivision.DataTextField = "CPRDIV_NAME";
            ddlPODivision.DataValueField = "CPRDIV_ID";
            ddlPODivision.DataBind();
        }
        ddlPODivision.Items.Insert(0, "--SELECT DIVISION--");
    }

    [WebMethod]
    public static string[] LoadVendors(string CorpId, string OrgId, string strText)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
        objEntityPurchaseOrder.CommonSearchTerm = strText;

        DataTable dt = objBusinessPurchaseOrder.ReadVendor(objEntityPurchaseOrder);

        List<string> ListReturn = new List<string>();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            ListReturn.Add(dt.Rows[intRow]["SUPLIR_ID"].ToString() + "<>" + dt.Rows[intRow]["SUPLIR_NAME"].ToString());
        }
        return ListReturn.ToArray();
    }

    public void LoadDocumntWrkflw()
    {
        DataTable dt = objBusinessPurchaseOrder.ReadDocumntWrkflow(objEntityPurchaseOrder);

        ddlDocumntWrkflw.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlDocumntWrkflw.DataSource = dt;
            ddlDocumntWrkflw.DataTextField = "WRKFLW_NAME";
            ddlDocumntWrkflw.DataValueField = "WRKFLW_ID";
            ddlDocumntWrkflw.DataBind();
        }
        
        if (dt.Rows.Count == 1)
        {
            if (ddlDocumntWrkflw.Items.FindByValue(dt.Rows[0]["WRKFLW_ID"].ToString()) != null)
            {
                ddlDocumntWrkflw.Items.FindByValue(dt.Rows[0]["WRKFLW_ID"].ToString()).Selected = true;
            }
        }
        else
        {
            ddlDocumntWrkflw.Items.Insert(0, "--SELECT DOCUMENT WORKFLOW--");
        }
    }

    [WebMethod]
    public static string[] LoadProducts(string CorpId, string OrgId, string ProductMode, string strText)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
        objEntityPurchaseOrder.CommonSearchTerm = strText;

        DataTable dt = new DataTable();
        if (ProductMode == "1")
        {
            dt = objBusinessPurchaseOrder.ReadProducts(objEntityPurchaseOrder);
        }
        else if (ProductMode == "2")
        {
            dt = objBusinessPurchaseOrder.ReadVehicles(objEntityPurchaseOrder);
        }

        List<string> ListReturn = new List<string>();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            ListReturn.Add(string.Format("{0}<>{1}", dt.Rows[intRow]["PRDT_ID"].ToString(), dt.Rows[intRow]["PRDT_NAME"].ToString()));
        }
        return ListReturn.ToArray();
    }

    [WebMethod]
    public static string[] LoadEmployees(string CorpId, string OrgId, string ProductMode, string strText)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CorporateID= Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.Searchstring = strText;

        DataTable dt = objBusinessLayer.ReadEmployees(objEntityCommon);

        List<string> ListReturn = new List<string>();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            ListReturn.Add(string.Format("{0}<>{1}", dt.Rows[intRow]["USR_ID"].ToString(), dt.Rows[intRow]["USR_NAME_CODE"].ToString()));
        }
        return ListReturn.ToArray();
    }

    [WebMethod]
    public static string[] LoadEmployeeDtls(string CorpId, string OrgId, string EmpId)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
        objEntityPurchaseOrder.EmployeeId = Convert.ToInt32(EmpId);

        DataTable dt = objBusinessPurchaseOrder.ReadEmployeeDtls(objEntityPurchaseOrder);

        string[] strReturn = new string[2];
        if (dt.Rows.Count > 0)
        {
            strReturn[0] = dt.Rows[0]["USR_CODE"].ToString();
            strReturn[1] = dt.Rows[0]["CPRDIV_NAME"].ToString().TrimEnd(',',' ');
        }
        return strReturn;
    }

    [WebMethod]
    public static string[] LoadProductTaxDetails(string CorpId, string OrgId, string ProductId)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);

        if (ProductId != "")
        {
            objEntityPurchaseOrder.ProductId = Convert.ToInt32(ProductId);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadProductTaxDtls(objEntityPurchaseOrder);

        string[] strReturn = new string[5];
        if (dt.Rows.Count > 0)
        {
            strReturn[0] = dt.Rows[0]["PRDT_COST_PRICE"].ToString();
            decimal TaxPrcnt = 0;
            if (dt.Rows[0]["TAX_ID"].ToString() != "")
            {
                strReturn[4] = dt.Rows[0]["TAX_ID"].ToString();
                strReturn[1] = dt.Rows[0]["TAX_NAME"].ToString();
                strReturn[2] = dt.Rows[0]["TAX_PERCENTAGE"].ToString();

                TaxPrcnt = Convert.ToDecimal(dt.Rows[0]["TAX_PERCENTAGE"].ToString());
                decimal TaxAmnt = (Convert.ToDecimal(dt.Rows[0]["PRDT_COST_PRICE"].ToString()) * TaxPrcnt) / 100;
                strReturn[3] = TaxAmnt.ToString();
            }

        }
        return strReturn;
    }

    [WebMethod]
    public static string[] ChangeCurrency(string CorpId, string OrgId, string CurrencyId)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);

        DataTable dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon); //CURRENCY

        string[] strReturn = new string[4];
        if (dtCurrencyDetail.Rows.Count > 0)
        {
            strReturn[0] = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            strReturn[1] = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
        }
        return strReturn;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
            clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (Session["USERID"] != null)
            {
                objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityPurchaseOrder.PurchaseOrderType = Convert.ToInt32(ddlPrchsOrdrType.SelectedItem.Value);
            objEntityPurchaseOrder.WrkFlowId = Convert.ToInt32(ddlDocumntWrkflw.SelectedItem.Value);
            objEntityPurchaseOrder.PurchsOrdrRefrncNo = txtPrchsOrdrRef.Text;
            objEntityPurchaseOrder.PurchsOrdrDate = objCommon.textToDateTime(txtPrchsOrdrDate.Value);
            if (txtDeliveryDate.Value != "")
            {
                objEntityPurchaseOrder.ExpctdDelivryDate = objCommon.textToDateTime(txtDeliveryDate.Value);
            }
            objEntityPurchaseOrder.ClientName = txtClientName.Text;
            objEntityPurchaseOrder.EndCustmrName = txtEndCustomer.Text;
            if (radioProjct.Checked == true)
            {
                objEntityPurchaseOrder.DeliverToSts = 1;
            }
            else if (radioWarehouse.Checked == true)
            {
                objEntityPurchaseOrder.DeliverToSts = 0;
            }
            if (ddlWarehouse.SelectedItem.Value != "--SELECT WAREHOUSE--" && ddlWarehouse.SelectedItem.Value != "" && ddlWarehouse.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.WarehouseId = Convert.ToInt32(ddlWarehouse.SelectedItem.Value);
            }
            objEntityPurchaseOrder.WrhsDeliveryLocatn = txtWarehouseDelivery.Text;
            //objEntityPurchaseOrder.PrjctDeliveryLocatn=
            objEntityPurchaseOrder.QuotatnRefNo = txtQuotatnRef.Text;
            if (txtQuotatnDate.Value != "")
            {
                objEntityPurchaseOrder.QuotatnDate = objCommon.textToDateTime(txtQuotatnDate.Value);
            }
            //objEntityPurchaseOrder.VendorId = Convert.ToInt32(ddlVendor.SelectedItem.Value);
            objEntityPurchaseOrder.VendorId = Convert.ToInt32(hiddenVendorId.Value);
            objEntityPurchaseOrder.VendorRefNo = txtVendorRef.Text;

            List<clsEntitySupplierContact> objEntitySupplierCntctList = new List<clsEntitySupplierContact>();

            if (hiddenF9Mode.Value == "1")
            {
                if (ddlVendorContact.SelectedItem.Value != "--SELECT CONTACT PERSON--" && ddlVendorContact.SelectedItem.Value != "" && ddlVendorContact.SelectedItem.Value != null)
                {
                    objEntityPurchaseOrder.VendorCntctPrsnId = Convert.ToInt32(ddlVendorContact.SelectedItem.Value);
                }
                objEntityPurchaseOrder.VendorContactName = "";
            }
            else if (hiddenF9Mode.Value == "0")
            {
                objEntityPurchaseOrder.VendorContactName = txtVendorContact.Text;
                objEntityPurchaseOrder.VendorCntctPrsnId = 0;

                if (cbxFuture.Checked == true)
                {
                    objEntityPurchaseOrder.UseVendorDtlFuture = 1;

                    if (txtVendorContact.Text != "" && txtVendorAddress.Text != "")
                    {
                        clsEntitySupplierContact objEntityContact = new clsEntitySupplierContact();

                        if (txtVendorContact.Text != "")
                        {
                            objEntityContact.ContactName = txtVendorContact.Text;
                        }
                        if (txtVendorAddress.Text != "")
                        {
                            objEntityContact.ContactAddress = txtVendorAddress.Text;
                        }
                        if (txtVendorMobile.Text != "")
                        {
                            objEntityContact.ContactMobile = txtVendorMobile.Text;
                        }
                        if (txtVendorContactNo.Text != "")
                        {
                            objEntityContact.ContactPhone = txtVendorContactNo.Text;
                        }
                        if (txtVendorEmail.Text != "")
                        {
                            objEntityContact.ContactEmail = txtVendorEmail.Text;
                        }

                        objEntitySupplierCntctList.Add(objEntityContact);
                    }

                }
            }

            objEntityPurchaseOrder.VendorAddress = txtVendorAddress.Text;
            objEntityPurchaseOrder.VendorMobile = txtVendorMobile.Text;
            objEntityPurchaseOrder.VendorPhone = txtVendorContactNo.Text;
            objEntityPurchaseOrder.VendorFax = txtVendorFax.Text;
            objEntityPurchaseOrder.VendorEmail = txtVendorEmail.Text;

            objEntityPurchaseOrder.VendorComments = txtVendorComments.Text;
            objEntityPurchaseOrder.DivisionId = Convert.ToInt32(ddlPODivision.SelectedItem.Value);
            if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--" && ddlProjects.SelectedItem.Value != "" && ddlProjects.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            }
            if (ddlPORequestor.SelectedItem.Value != "--SELECT CUSTOMER--" && ddlPORequestor.SelectedItem.Value != "" && ddlPORequestor.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.RqstdCustomerId = Convert.ToInt32(ddlPORequestor.SelectedItem.Value);
            }
            if (txtPORequiremntDate.Value != "")
            {
                objEntityPurchaseOrder.RqrmntDate = objCommon.textToDateTime(txtPORequiremntDate.Value);
            }
            objEntityPurchaseOrder.ModeOfSupply = Convert.ToInt32(ddlModeofSupply.SelectedItem.Value);
            if (ddlPOContact.SelectedItem.Value != "--SELECT CONTACT PERSON--" && ddlPOContact.SelectedItem.Value != "" && ddlPOContact.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.POCntctPrsnId = Convert.ToInt32(ddlPOContact.SelectedItem.Value);
            }
            objEntityPurchaseOrder.POMobileNo = txtPOMobile.Text;
            objEntityPurchaseOrder.POReqstnNo = txtPORequisitionNo.Text;
            if (txtPORequisitnDate.Value != "")
            {
                objEntityPurchaseOrder.POReqstnDate = objCommon.textToDateTime(txtPORequisitnDate.Value);
            }
            if (txtApprovalDate.Value != "")
            {
                objEntityPurchaseOrder.ApprovalDate = objCommon.textToDateTime(txtApprovalDate.Value);
            }
            if (cbxPOUrgent.Checked == true)
            {
                objEntityPurchaseOrder.POPriority = 1;
            }
            objEntityPurchaseOrder.JobCode = txtJobCode.Text;
            objEntityPurchaseOrder.JobDescriptn = txtJobDescrptn.Text;
            objEntityPurchaseOrder.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            objEntityPurchaseOrder.ExchngRate = Convert.ToDecimal(txtExchgRate.Text);

            string[] txtNetTotalSplit = txtNetTotal.Value.Split(' ');
            objEntityPurchaseOrder.NetAmntWthoutExchngRt = Convert.ToDecimal(txtNetTotalSplit[0]);

            string[] txtGrossTotalSplit = txtGrossTotal.Value.Split(' ');
            objEntityPurchaseOrder.GrossTotalAmnt = Convert.ToDecimal(txtGrossTotalSplit[0]);

            string[] txtTaxTotalSplit = txtTaxTotal.Value.Split(' ');
            objEntityPurchaseOrder.TaxTotalAmnt = Convert.ToDecimal(txtTaxTotalSplit[0]);

            string[] txtDiscntTotalSplit = new string[2];
            if (txtDiscntTotal.Value != "")
            {
                txtDiscntTotalSplit = txtDiscntTotal.Value.Split(' ');
                objEntityPurchaseOrder.DiscntTotalAmnt = Convert.ToDecimal(txtDiscntTotalSplit[0]);
            }

            objEntityPurchaseOrder.NetTotalAmnt = Convert.ToDecimal(hiddenNetAmnt.Value);

            objEntityPurchaseOrder.PaymntTerms = txtPaymntTerms.Text;
            objEntityPurchaseOrder.TermsAndCondtns = txtTermsCondtns.Text;
            objEntityPurchaseOrder.FreightTerms = txtFreightTerms.Text;

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrDtlsList = new List<clsEntityPurchaseOrder>();

            if (hiddenPurchsOrdrDtls.Value != "" && hiddenPurchsOrdrDtls.Value != "[]")
            {
                string jsonData = hiddenPurchsOrdrDtls.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                string DataValue = k;

                List<clsData> objDataList = new List<clsData>();
                objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                foreach (clsData objclsData in objDataList)
                {
                    clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();

                    objEntity.SLNo = Convert.ToInt32(objclsData.SLNO);
                    objEntity.Qnty = Convert.ToDecimal(objclsData.QUANTITY);
                    objEntity.Price = Convert.ToDecimal(objclsData.PRICE);
                    objEntity.ProductTotalAmnt = Convert.ToDecimal(objclsData.TOTALAMNT);

                    if (objclsData.PRODUCTID != "")
                    {
                        objEntity.ProductId = Convert.ToInt32(objclsData.PRODUCTID);
                    }
                    if (objclsData.DISCNTPRCNTG != "")
                    {
                        objEntity.DiscntPrcnt = Convert.ToDecimal(objclsData.DISCNTPRCNTG);
                    }
                    if (objclsData.DISCNTAMNT != "")
                    {
                        objEntity.DiscntAmnt = Convert.ToDecimal(objclsData.DISCNTAMNT);
                    }
                    if (objclsData.TAXID != "")
                    {
                        objEntity.TaxId = Convert.ToInt32(objclsData.TAXID);
                    }
                    if (objclsData.TAXPRCNTG != "")
                    {
                        objEntity.TaxPrcnt = Convert.ToDecimal(objclsData.TAXPRCNTG);
                    }
                    if (objclsData.VEHICLEID != "")
                    {
                        objEntity.VehicleId = Convert.ToInt32(objclsData.VEHICLEID);
                    }
                    if (objclsData.STRTDATE != "")
                    {
                        objEntity.StartDate = objCommon.textToDateTime(objclsData.STRTDATE);
                    }
                    if (objclsData.ENDDATE != "")
                    {
                        objEntity.EndDate = objCommon.textToDateTime(objclsData.ENDDATE);
                    }
                    if (objclsData.EMPID != "")
                    {
                        objEntity.EmployeeId = Convert.ToInt32(objclsData.EMPID);
                    }
                    if (objclsData.FLGHTPNRNO != "")
                    {
                        objEntity.PNRNo = objclsData.FLGHTPNRNO;
                    }
                    if (objclsData.SECTOR != "")
                    {
                        objEntity.Sector = objclsData.SECTOR;
                    }
                    if (objclsData.TRVLDATE != "")
                    {
                        objEntity.TravelDate = objCommon.textToDateTime(objclsData.TRVLDATE);
                    }
                    objEntityPurchsOrdrDtlsList.Add(objEntity);
                }
            }

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrChrgHeadList = new List<clsEntityPurchaseOrder>();

            if (hiddenChrgDtls.Value != "" && hiddenChrgDtls.Value != "[]")
            {
                string jsonData = hiddenChrgDtls.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                string DataValue = k;

                List<clsData> objDataList = new List<clsData>();
                objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                foreach (clsData objclsData in objDataList)
                {
                    clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();

                    objEntity.ChrgHeadId = Convert.ToInt32(objclsData.CHRGHDID);
                    objEntity.ChrgHeadAmnt = Convert.ToDecimal(objclsData.CHRGAMNT);
                    objEntityPurchsOrdrChrgHeadList.Add(objEntity);
                }
            }


            List<clsEntityPurchaseOrder> objEntityPurchsOrdrAttchmntList = new List<clsEntityPurchaseOrder>();

            if (cbxAttachmnt.Checked == true)
            {
                if (hiddenAttchmntDtls.Value != "" && hiddenAttchmntDtls.Value != "[]")
                {
                    string jsonData = hiddenAttchmntDtls.Value;
                    string c = jsonData.Replace("\"{", "\\{");
                    string d = c.Replace("\\n", "\r\n");
                    string g = d.Replace("\\", "");
                    string h = g.Replace("}\"]", "}]");
                    string k = h.Replace("}\",", "},");
                    string DataValue = k;

                    List<clsData> objDataList = new List<clsData>();
                    objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                    for (int count = 0; count < objDataList.Count; count++)
                    {
                        string jsonFileid = "fileAttach" + objDataList[count].ROWID;
                        for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                        {
                            string fileId = Request.Files.AllKeys[intCount].ToString();
                            HttpPostedFile PostedFile = Request.Files[intCount];
                            if (fileId == jsonFileid)
                            {
                                if (PostedFile.ContentLength > 0)
                                {
                                    clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();
                                    objEntity.Descrptn = objDataList[count].DESCRPTN;

                                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                    objEntity.ActualFileName = strFileName;
                                    string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_ATTCHMNT);
                                    objEntityCommon.CorporateID = objEntityPurchaseOrder.CorpId;
                                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_ATTCHMNT);
                                    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                                    string strImageName = "PURCHASEORDER_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                                    objEntity.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_ATTCHMNT);

                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntity.FileName);

                                    objEntityPurchsOrdrAttchmntList.Add(objEntity);
                                }
                            }
                        }

                    }
                }
            }

            objBusinessPurchaseOrder.InsertPurchaseOrder(objEntityPurchaseOrder, objEntityPurchsOrdrDtlsList, objEntityPurchsOrdrChrgHeadList, objEntityPurchsOrdrAttchmntList, objEntitySupplierCntctList);

            if (clickedButton.ID == "btnSave" || clickedButton.ID == "btnSaveFloat")
            {
                Response.Redirect("pms_Purchase_Order.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnSaveAndClose" || clickedButton.ID == "btnSaveAndCloseFloat")
            {
                Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=Ins");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.StartsWith("Thread") == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
            }
        }
    }

    public class clsData
    {
        public string ROWID { get; set; }
        public string SLNO { get; set; }
        public string PRODUCTID { get; set; }
        public string QUANTITY { get; set; }
        public string PRICE { get; set; }
        public string TOTALAMNT { get; set; }
        public string DISCNTPRCNTG { get; set; }
        public string DISCNTAMNT { get; set; }
        public string TAXID { get; set; }
        public string TAXPRCNTG { get; set; }
        public string VEHICLEID { get; set; }
        public string STRTDATE { get; set; }
        public string ENDDATE { get; set; }
        public string EMPID { get; set; }
        public string FLGHTPNRNO { get; set; }
        public string SECTOR { get; set; }
        public string TRVLDATE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string CHRGHDID { get; set; }
        public string CHRGAMNT { get; set; }
        public string DESCRPTN { get; set; }
    }

    public void UpdateView(string strId, string strCopyMode = "0", string strCopyBasicDtls = "0", string strCopyProducts = "0", string strCopyChrgHds = "0", string strCopyTermsCndtns = "0")
    {
        objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);

        DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderById(objEntityPurchaseOrder);

        if (dt.Rows.Count > 0)
        {
            ddlPrchsOrdrType.ClearSelection();
            if (ddlPrchsOrdrType.Items.FindByValue(dt.Rows[0]["PRCHSORDR_TYPE"].ToString()) != null)
            {
                ddlPrchsOrdrType.Items.FindByValue(dt.Rows[0]["PRCHSORDR_TYPE"].ToString()).Selected = true;
            }

            if (strCopyMode == "0")
            {
                ddlPrchsOrdrType.Enabled = false;

                if (Convert.ToInt32(dt.Rows[0]["NOTECNT"].ToString()) > 0)//not replied note
                {
                    btnConfirm.Visible = false;
                    btnConfirmFloat.Visible = false;
                }

                txtPrchsOrdrRef.Text = dt.Rows[0]["PRCHSORDR_REF"].ToString();
                txtPrchsOrdrDate.Value = dt.Rows[0]["PRCHSORDR_DATE"].ToString();
            }

            if ((strCopyMode == "0") || (strCopyMode == "1" && strCopyBasicDtls == "1"))
            {
                txtDeliveryDate.Value = dt.Rows[0]["PRCHSORDR_DLVRYDT"].ToString();

                ddlPODivision.ClearSelection();
                if (ddlPODivision.Items.FindByValue(dt.Rows[0]["CPRDIV_ID"].ToString()) != null)
                {
                    ddlPODivision.Items.FindByValue(dt.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["CPRDIV_NAME"].ToString(), dt.Rows[0]["CPRDIV_ID"].ToString());
                    ddlPODivision.Items.Insert(1, lstGrp);
                    ddlPODivision.Items.FindByValue(dt.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }

                LoadProjects();
                ddlProjects.ClearSelection();
                if (ddlProjects.Items.FindByValue(dt.Rows[0]["PROJECT_ID"].ToString()) != null)
                {
                    ddlProjects.Items.FindByValue(dt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                }
                //else
                //{
                //    ListItem lstGrp = new ListItem(dt.Rows[0]["PROJECT_NAME"].ToString(), dt.Rows[0]["PROJECT_ID"].ToString());
                //    ddlProjects.Items.Insert(1, lstGrp);
                //    ddlProjects.Items.FindByValue(dt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                //}

                txtClientName.Text = dt.Rows[0]["PRCHSORDR_CLIENTNAME"].ToString();
                txtEndCustomer.Text = dt.Rows[0]["PRCHSORDR_ENDCSTMRNAME"].ToString();

                ddlModeofSupply.ClearSelection();
                if (ddlModeofSupply.Items.FindByValue(dt.Rows[0]["PRCHSORDR_MODOFSUPPLY"].ToString()) != null)
                {
                    ddlModeofSupply.Items.FindByValue(dt.Rows[0]["PRCHSORDR_MODOFSUPPLY"].ToString()).Selected = true;
                }
                radioProjct.Checked = false;
                radioWarehouse.Checked = false;
                if (dt.Rows[0]["PRCHSORDR_DLVRYTO_STS"].ToString() == "1")
                {
                    radioProjct.Checked = true;
                }
                else if (dt.Rows[0]["PRCHSORDR_DLVRYTO_STS"].ToString() == "0")
                {
                    radioWarehouse.Checked = true;
                }

                LoadWarehouse();
                ddlWarehouse.ClearSelection();
                if (ddlWarehouse.Items.FindByValue(dt.Rows[0]["WRHS_ID"].ToString()) != null)
                {
                    ddlWarehouse.Items.FindByValue(dt.Rows[0]["WRHS_ID"].ToString()).Selected = true;
                }
                //else
                //{
                //    ListItem lstGrp = new ListItem(dt.Rows[0]["WRHS_NAME"].ToString(), dt.Rows[0]["WRHS_ID"].ToString());
                //    ddlWarehouse.Items.Insert(1, lstGrp);
                //    ddlWarehouse.Items.FindByValue(dt.Rows[0]["WRHS_ID"].ToString()).Selected = true;
                //}

                txtWarehouseDelivery.Text = dt.Rows[0]["PRCHSORDR_DLVRLCTN_WRHS"].ToString();
                txtQuotatnRef.Text = dt.Rows[0]["PRCHSORDR_QTNNO"].ToString();
                txtQuotatnDate.Value = dt.Rows[0]["PRCHSORDR_QTNDATE"].ToString();

                ddlCurrency.ClearSelection();
                if (ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                txtExchgRate.Text = dt.Rows[0]["PRCHSORDR_EXCHNG_RATE"].ToString();


                ddlVendor.Text = dt.Rows[0]["SUPLIR_NAME"].ToString();
                hiddenVendorId.Value = dt.Rows[0]["SUPLIR_ID"].ToString();
                tdVendorName.Value = dt.Rows[0]["SUPLIR_NAME"].ToString();

                txtVendorRef.Text = dt.Rows[0]["PRCHSORDR_VENDOR_REFNO"].ToString();
                txtVendorAddress.Text = dt.Rows[0]["PRCHSORDR_VENDOR_ADDRSS"].ToString();

                if (dt.Rows[0]["PRCHSORDR_VENDOR_CONTCTNAME"].ToString() == "")
                {
                    ddlVendorContact.Attributes.Add("style", "display:block");
                    txtVendorContact.Attributes.Add("style", "display:none");

                    LoadVendorContacts();
                    ddlVendorContact.ClearSelection();
                    if (dt.Rows[0]["PRCHSORDR_VENDOR_CONTCTPRSN_ID"].ToString() != "")
                    {
                        if (ddlVendorContact.Items.FindByValue(dt.Rows[0]["PRCHSORDR_VENDOR_CONTCTPRSN_ID"].ToString()) != null)
                        {
                            ddlVendorContact.Items.FindByValue(dt.Rows[0]["PRCHSORDR_VENDOR_CONTCTPRSN_ID"].ToString()).Selected = true;
                        }
                    }

                    cbxFuture.Disabled = true;
                    hiddenF9Mode.Value = "1";
                }
                else
                {
                    ddlVendorContact.Attributes.Add("style", "display:none");
                    txtVendorContact.Attributes.Add("style", "display:block");
                    txtVendorContact.Text = dt.Rows[0]["PRCHSORDR_VENDOR_CONTCTNAME"].ToString();

                    cbxFuture.Disabled = false;
                    hiddenF9Mode.Value = "0";
                }

                txtVendorMobile.Text = dt.Rows[0]["PRCHSORDR_VENDOR_MOBILE"].ToString();
                txtVendorContactNo.Text = dt.Rows[0]["PRCHSORDR_VENDOR_PHONE"].ToString();
                txtVendorFax.Text = dt.Rows[0]["PRCHSORDR_VENDOR_FAX"].ToString();
                txtVendorEmail.Text = dt.Rows[0]["PRCHSORDR_VENDOR_EMAIL"].ToString();
                txtVendorComments.Text = dt.Rows[0]["PRCHSORDR_VENDOR_COMMNTS"].ToString();
                if (dt.Rows[0]["PRCHSORDR_VENDOR_FUTUREUSE"].ToString() == "1")
                {
                    cbxFuture.Checked = true;
                }
                ddlDocumntWrkflw.ClearSelection();
                if (ddlDocumntWrkflw.Items.FindByValue(dt.Rows[0]["WRKFLW_ID"].ToString()) != null)
                {
                    ddlDocumntWrkflw.Items.FindByValue(dt.Rows[0]["WRKFLW_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["WRKFLW_NAME"].ToString(), dt.Rows[0]["WRKFLW_ID"].ToString());
                    ddlDocumntWrkflw.Items.Insert(1, lstGrp);
                    ddlDocumntWrkflw.Items.FindByValue(dt.Rows[0]["WRKFLW_ID"].ToString()).Selected = true;
                }

                LoadCustomer();
                ddlPORequestor.ClearSelection();
                if (ddlPORequestor.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()) != null)
                {
                    ddlPORequestor.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
                //else
                //{
                //    ListItem lstGrp = new ListItem(dt.Rows[0]["CSTMR_NAME"].ToString(), dt.Rows[0]["CSTMR_ID"].ToString());
                //    ddlPORequestor.Items.Insert(1, lstGrp);
                //    ddlPORequestor.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                //}

                txtPORequiremntDate.Value = dt.Rows[0]["PRCHSORDR_REQRMNTDATE"].ToString();
                if (dt.Rows[0]["PRCHSORDR_PRIORTY"].ToString() == "1")
                {
                    cbxPOUrgent.Checked = true;
                }
                txtPORequisitionNo.Text = dt.Rows[0]["PRCHSORDR_PO_REQSTNNO"].ToString();
                txtPORequisitnDate.Value = dt.Rows[0]["PRCHSORDR_REQRMNTDATE"].ToString();

                LoadCustomerContact();
                ddlPOContact.ClearSelection();
                if (ddlPOContact.Items.FindByValue(dt.Rows[0]["PRCHSORDR_PO_CONTACTPRSN_ID"].ToString()) != null)
                {
                    ddlPOContact.Items.FindByValue(dt.Rows[0]["PRCHSORDR_PO_CONTACTPRSN_ID"].ToString()).Selected = true;
                }

                txtPOMobile.Text = dt.Rows[0]["PRCHSORDR_PO_MOBILE"].ToString();
                txtApprovalDate.Value = dt.Rows[0]["PRCHSORDR_PO_APPRVLDATE"].ToString();
                txtJobCode.Text = dt.Rows[0]["PRCHSORDR_JOBCODE"].ToString();
                txtJobDescrptn.Text = dt.Rows[0]["PRCHSORDR_JOBDESCRPTN"].ToString();
            }

            if ((strCopyMode == "0") || (strCopyMode == "1" && strCopyTermsCndtns == "1"))
            {
                txtPaymntTerms.Text = dt.Rows[0]["PRCHSORDR_PAYMT_TERM"].ToString();
                txtTermsCondtns.Text = dt.Rows[0]["PRCHSORDR_TERM_CNDTNS"].ToString();
                txtFreightTerms.Text = dt.Rows[0]["PRCHSORDR_FRGHT_TERM"].ToString();
            }

            //prodct
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("DTLID", typeof(string));
            dtDetail.Columns.Add("SLNO", typeof(string));
            dtDetail.Columns.Add("QUANTITY", typeof(string));
            dtDetail.Columns.Add("PRICE", typeof(string));
            dtDetail.Columns.Add("TOTALAMNT", typeof(string));
            dtDetail.Columns.Add("PRODUCTID", typeof(string));
            dtDetail.Columns.Add("DISCNTPRCNTG", typeof(string));
            dtDetail.Columns.Add("DISCNTAMNT", typeof(string));
            dtDetail.Columns.Add("TAXID", typeof(string));
            dtDetail.Columns.Add("TAXPRCNTG", typeof(string));
            dtDetail.Columns.Add("VEHICLEID", typeof(string));
            dtDetail.Columns.Add("STRTDATE", typeof(string));
            dtDetail.Columns.Add("ENDDATE", typeof(string));
            dtDetail.Columns.Add("EMPID", typeof(string));
            dtDetail.Columns.Add("FLGHTPNRNO", typeof(string));
            dtDetail.Columns.Add("SECTOR", typeof(string));
            dtDetail.Columns.Add("TRVLDATE", typeof(string));
            dtDetail.Columns.Add("PRODUCTNAME", typeof(string));
            dtDetail.Columns.Add("VEHICLENAME", typeof(string));
            dtDetail.Columns.Add("EMPNAME", typeof(string));
            dtDetail.Columns.Add("TAXNAME", typeof(string));

            DataTable dtDtls = objBusinessPurchaseOrder.ReadPurchaseOrderDetailsById(objEntityPurchaseOrder);
            if (dtDtls.Rows.Count > 0)
            {
                for (int intCount = 0; intCount < dtDtls.Rows.Count; intCount++)
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["DTLID"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_ID"].ToString();
                    drDtl["SLNO"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_SLNO"].ToString();
                    drDtl["QUANTITY"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_QNTY"].ToString();
                    drDtl["PRICE"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_RATE"].ToString();
                    drDtl["TOTALAMNT"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_TOTLAMNT"].ToString();
                    drDtl["PRODUCTID"] = dtDtls.Rows[intCount]["PRDT_ID"].ToString();
                    drDtl["DISCNTPRCNTG"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_DISCNTPCNT"].ToString();
                    drDtl["DISCNTAMNT"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_DISCNTAMT"].ToString();
                    drDtl["TAXID"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_TAXID"].ToString();
                    drDtl["TAXPRCNTG"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_TAXPRCNT"].ToString();
                    drDtl["VEHICLEID"] = dtDtls.Rows[intCount]["VHCL_ID"].ToString();
                    drDtl["STRTDATE"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_STRTDATE"].ToString();
                    drDtl["ENDDATE"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_ENDDATE"].ToString();
                    drDtl["EMPID"] = dtDtls.Rows[intCount]["USR_ID"].ToString();
                    drDtl["FLGHTPNRNO"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_PNRNO"].ToString();
                    drDtl["SECTOR"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_SECTOR"].ToString();
                    drDtl["TRVLDATE"] = dtDtls.Rows[intCount]["PRCHSORDR_DTL_TRVLDATE"].ToString();
                    drDtl["PRODUCTNAME"] = dtDtls.Rows[intCount]["PRDT_NAME"].ToString();
                    drDtl["VEHICLENAME"] = dtDtls.Rows[intCount]["VHCL_NUMBR"].ToString();
                    drDtl["EMPNAME"] = dtDtls.Rows[intCount]["USR_NAME_CODE"].ToString();
                    drDtl["TAXNAME"] = dtDtls.Rows[intCount]["TAX_NAME"].ToString();
                    dtDetail.Rows.Add(drDtl);
                }
            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            if ((strCopyMode == "0") || (strCopyMode == "1" && strCopyProducts == "1"))
            {
                hiddenEditDtls.Value = strJson;
            }

            //charge
            DataTable dtChrgDetail = new DataTable();
            dtChrgDetail.Columns.Add("DTLID", typeof(string));
            dtChrgDetail.Columns.Add("CHRGHDID", typeof(string));
            dtChrgDetail.Columns.Add("CHRGAMNT", typeof(string));
            dtChrgDetail.Columns.Add("CHRGHDNAME", typeof(string));
            dtChrgDetail.Columns.Add("CHRGCALCULATE", typeof(string));

            DataTable dtChrgDtls = objBusinessPurchaseOrder.ReadPurchaseOrderChrgHeadsById(objEntityPurchaseOrder);
            if (dtChrgDtls.Rows.Count > 0)
            {
                for (int intCount = 0; intCount < dtChrgDtls.Rows.Count; intCount++)
                {
                    DataRow drDtl = dtChrgDetail.NewRow();
                    drDtl["DTLID"] = dtChrgDtls.Rows[intCount]["PRCHSORDR_CHRGID"].ToString();
                    drDtl["CHRGHDID"] = dtChrgDtls.Rows[intCount]["CHRGHD_ID"].ToString();
                    drDtl["CHRGAMNT"] = dtChrgDtls.Rows[intCount]["PRCHSORDR_CHRGAMNT"].ToString();
                    drDtl["CHRGHDNAME"] = dtChrgDtls.Rows[intCount]["CHRGHD_NAME"].ToString();
                    drDtl["CHRGCALCULATE"] = dtChrgDtls.Rows[intCount]["CHRGHD_CALCULATE"].ToString();
                    dtChrgDetail.Rows.Add(drDtl);
                }
            }
            if ((strCopyMode == "0") || (strCopyMode == "1" && strCopyChrgHds == "1"))
            {
                hiddenChrgDtls.Value = DataTableToJSONWithJavaScriptSerializer(dtChrgDetail);
            }

            if (strCopyMode == "0")
            {
                //attachmnt
                DataTable dtAttchDetail = new DataTable();
                dtAttchDetail.Columns.Add("DTLID", typeof(string));
                dtAttchDetail.Columns.Add("FILENAME", typeof(string));
                dtAttchDetail.Columns.Add("ACT_FILENAME", typeof(string));
                dtAttchDetail.Columns.Add("DESCRIPTN", typeof(string));

                DataTable dtAttchDtls = objBusinessPurchaseOrder.ReadPurchaseOrderAttachmntsById(objEntityPurchaseOrder);
                if (dtAttchDtls.Rows.Count > 0)
                {
                    cbxAttachmnt.Checked = true;

                    for (int intCount = 0; intCount < dtAttchDtls.Rows.Count; intCount++)
                    {
                        DataRow drDtl = dtAttchDetail.NewRow();
                        drDtl["DTLID"] = dtAttchDtls.Rows[intCount]["PRCHSORDR_ATCHID"].ToString();
                        drDtl["FILENAME"] = dtAttchDtls.Rows[intCount]["PRCHSORDRATCH_FILE_NAME"].ToString();
                        drDtl["ACT_FILENAME"] = dtAttchDtls.Rows[intCount]["PRCHSORDRATCH_FILE_ACTNM"].ToString();
                        drDtl["DESCRIPTN"] = dtAttchDtls.Rows[intCount]["PRCHSORDRATCH_DESCRPTN"].ToString();
                        dtAttchDetail.Rows.Add(drDtl);
                    }
                }
                hiddenAttchmntDtls.Value = DataTableToJSONWithJavaScriptSerializer(dtAttchDetail);

                clsCommonLibrary objCommon = new clsCommonLibrary();
                hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_ATTCHMNT);
            }

            if ((Request.QueryString["ViewId"] != null) || (Request.QueryString["Id"] != null && Request.QueryString["VId"] != null && Request.QueryString["VId"].ToString() == "0"))
            {

                if (Request.QueryString["Id"] == null)
                {
                    if (dt.Rows[0]["PRCHSORDR_CNCL_USR_ID"].ToString() == "")
                    {
                        if (hiddenEnableReopen.Value == "1")
                        {
                            btnReopen.Visible = true;
                            btnReopenFloat.Visible = true;
                        }
                    }
                    else
                    {
                        btnReopen.Visible = false;
                        btnReopenFloat.Visible = false;
                    }
                }

                if (Convert.ToInt32(dt.Rows[0]["APRVLCNT"].ToString()) > 0)//Apprvl done
                {
                    btnReopen.Visible = false;
                    btnReopenFloat.Visible = false;
                }

                if (Request.QueryString["VId"] != null && Request.QueryString["VId"].ToString() == "0")
                {
                    btnReopen.Visible = false;
                    btnReopenFloat.Visible = false;
                }

                txtPrchsOrdrRef.Enabled = false;
                txtPrchsOrdrDate.Disabled = true;
                spanPrchsOrdrDate.Attributes.Add("style", "pointer-events:none");
                txtDeliveryDate.Disabled = true;
                spanDeliveryDate.Attributes.Add("style", "pointer-events:none");
                ddlPODivision.Enabled = false;
                ddlProjects.Enabled = false;
                txtClientName.Enabled = false;
                txtEndCustomer.Enabled = false;
                ddlModeofSupply.Enabled = false;
                radioProjct.Enabled = false;
                radioWarehouse.Enabled = false;
                ddlWarehouse.Enabled = false;
                txtWarehouseDelivery.Enabled = false;
                txtQuotatnRef.Enabled = false;
                txtQuotatnDate.Disabled = true;
                spanQuotatnDate.Attributes.Add("style", "pointer-events:none");
                ddlCurrency.Enabled = false;
                txtExchgRate.Enabled = false;
                ddlVendor.Enabled = false;
                txtVendorRef.Enabled = false;
                txtVendorAddress.Enabled = false;
                ddlVendorContact.Enabled = false;
                txtVendorMobile.Enabled = false;
                txtVendorContactNo.Enabled = false;
                txtVendorFax.Enabled = false;
                txtVendorEmail.Enabled = false;
                txtVendorComments.Enabled = false;
                cbxFuture.Disabled = true;
                ddlDocumntWrkflw.Enabled = false;
                ddlPORequestor.Enabled = false;
                txtPORequiremntDate.Disabled = true;
                spanPORequiremntDate.Attributes.Add("style", "pointer-events:none");
                cbxPOUrgent.Disabled = true;
                txtPORequisitionNo.Enabled = false;
                txtPORequisitnDate.Disabled = true;
                spanPORequisitnDate.Attributes.Add("style", "pointer-events:none");
                ddlPOContact.Enabled = false;
                txtPOMobile.Enabled = false;
                txtApprovalDate.Disabled = true;
                spanApprovalDate.Attributes.Add("style", "pointer-events:none");
                txtJobCode.Enabled = false;
                txtJobDescrptn.Enabled = false;
                txtPaymntTerms.Enabled = false;
                txtTermsCondtns.Enabled = false;
                txtFreightTerms.Enabled = false;
                txtDiscntTotal.Disabled = true;
                cbxAttachmnt.Disabled = true;
                AddVendor.Disabled = true;
                AddVendor.Attributes.Add("style", "pointer-events:none");
                AddProject.Disabled = true;
                AddProject.Attributes.Add("style", "pointer-events:none");
            }

        }

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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
            clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            string strId = "";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                strId = strRandomMixedId.Substring(2, intLenghtofId);
            }
            if (strId != "")
            {
                objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);
            }

            if (Session["USERID"] != null)
            {
                objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityPurchaseOrder.PurchaseOrderType = Convert.ToInt32(ddlPrchsOrdrType.SelectedItem.Value);
            objEntityPurchaseOrder.WrkFlowId = Convert.ToInt32(ddlDocumntWrkflw.SelectedItem.Value);
            objEntityPurchaseOrder.PurchsOrdrRefrncNo = txtPrchsOrdrRef.Text;
            objEntityPurchaseOrder.PurchsOrdrDate = objCommon.textToDateTime(txtPrchsOrdrDate.Value);
            if (txtDeliveryDate.Value != "")
            {
                objEntityPurchaseOrder.ExpctdDelivryDate = objCommon.textToDateTime(txtDeliveryDate.Value);
            }
            objEntityPurchaseOrder.ClientName = txtClientName.Text;
            objEntityPurchaseOrder.EndCustmrName = txtEndCustomer.Text;
            if (radioProjct.Checked == true)
            {
                objEntityPurchaseOrder.DeliverToSts = 1;
            }
            else if (radioWarehouse.Checked == true)
            {
                objEntityPurchaseOrder.DeliverToSts = 0;
            }
            if (ddlWarehouse.SelectedItem.Value != "--SELECT WAREHOUSE--" && ddlWarehouse.SelectedItem.Value != "" && ddlWarehouse.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.WarehouseId = Convert.ToInt32(ddlWarehouse.SelectedItem.Value);
            }
            objEntityPurchaseOrder.WrhsDeliveryLocatn = txtWarehouseDelivery.Text;
            //objEntityPurchaseOrder.PrjctDeliveryLocatn=
            objEntityPurchaseOrder.QuotatnRefNo = txtQuotatnRef.Text;
            if (txtQuotatnDate.Value != "")
            {
                objEntityPurchaseOrder.QuotatnDate = objCommon.textToDateTime(txtQuotatnDate.Value);
            }
            //objEntityPurchaseOrder.VendorId = Convert.ToInt32(ddlVendor.SelectedItem.Value);
            objEntityPurchaseOrder.VendorId = Convert.ToInt32(hiddenVendorId.Value);
            objEntityPurchaseOrder.VendorRefNo = txtVendorRef.Text;

            List<clsEntitySupplierContact> objEntitySupplierCntctList = new List<clsEntitySupplierContact>();

            if (hiddenF9Mode.Value == "1")
            {
                if (ddlVendorContact.SelectedItem.Value != "--SELECT CONTACT PERSON--" && ddlVendorContact.SelectedItem.Value != "" && ddlVendorContact.SelectedItem.Value != null)
                {
                    objEntityPurchaseOrder.VendorCntctPrsnId = Convert.ToInt32(ddlVendorContact.SelectedItem.Value);
                }
                objEntityPurchaseOrder.VendorContactName = "";
            }
            else if (hiddenF9Mode.Value == "0")
            {
                objEntityPurchaseOrder.VendorContactName = txtVendorContact.Text;
                objEntityPurchaseOrder.VendorCntctPrsnId = 0;

                if (cbxFuture.Checked == true)
                {
                    objEntityPurchaseOrder.UseVendorDtlFuture = 1;

                    if (txtVendorContact.Text != "" && txtVendorAddress.Text != "")
                    {
                        clsEntitySupplierContact objEntityContact = new clsEntitySupplierContact();

                        if (txtVendorContact.Text != "")
                        {
                            objEntityContact.ContactName = txtVendorContact.Text;
                        }
                        if (txtVendorAddress.Text != "")
                        {
                            objEntityContact.ContactAddress = txtVendorAddress.Text;
                        }
                        if (txtVendorMobile.Text != "")
                        {
                            objEntityContact.ContactMobile = txtVendorMobile.Text;
                        }
                        if (txtVendorContactNo.Text != "")
                        {
                            objEntityContact.ContactPhone = txtVendorContactNo.Text;
                        }
                        if (txtVendorEmail.Text != "")
                        {
                            objEntityContact.ContactEmail = txtVendorEmail.Text;
                        }

                        objEntitySupplierCntctList.Add(objEntityContact);
                    }

                }
            }
            objEntityPurchaseOrder.VendorAddress = txtVendorAddress.Text;
            objEntityPurchaseOrder.VendorMobile = txtVendorMobile.Text;
            objEntityPurchaseOrder.VendorPhone = txtVendorContactNo.Text;
            objEntityPurchaseOrder.VendorFax = txtVendorFax.Text;
            objEntityPurchaseOrder.VendorEmail = txtVendorEmail.Text;
 
            objEntityPurchaseOrder.VendorComments = txtVendorComments.Text;
            objEntityPurchaseOrder.DivisionId = Convert.ToInt32(ddlPODivision.SelectedItem.Value);
            if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--" && ddlProjects.SelectedItem.Value != "" && ddlProjects.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
            }
            if (ddlPORequestor.SelectedItem.Value != "--SELECT CUSTOMER--" && ddlPORequestor.SelectedItem.Value != "" && ddlPORequestor.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.RqstdCustomerId = Convert.ToInt32(ddlPORequestor.SelectedItem.Value);
            }
            if (txtPORequiremntDate.Value != "")
            {
                objEntityPurchaseOrder.RqrmntDate = objCommon.textToDateTime(txtPORequiremntDate.Value);
            }
            objEntityPurchaseOrder.ModeOfSupply = Convert.ToInt32(ddlModeofSupply.SelectedItem.Value);
            if (ddlPOContact.SelectedItem.Value != "--SELECT CONTACT PERSON--" && ddlPOContact.SelectedItem.Value != "" && ddlPOContact.SelectedItem.Value != null)
            {
                objEntityPurchaseOrder.POCntctPrsnId = Convert.ToInt32(ddlPOContact.SelectedItem.Value);
            }
            objEntityPurchaseOrder.POMobileNo = txtPOMobile.Text;
            objEntityPurchaseOrder.POReqstnNo = txtPORequisitionNo.Text;
            if (txtPORequisitnDate.Value != "")
            {
                objEntityPurchaseOrder.POReqstnDate = objCommon.textToDateTime(txtPORequisitnDate.Value);
            }
            if (txtApprovalDate.Value != "")
            {
                objEntityPurchaseOrder.ApprovalDate = objCommon.textToDateTime(txtApprovalDate.Value);
            }
            if (cbxPOUrgent.Checked == true)
            {
                objEntityPurchaseOrder.POPriority = 1;
            }
            objEntityPurchaseOrder.JobCode = txtJobCode.Text;
            objEntityPurchaseOrder.JobDescriptn = txtJobDescrptn.Text;
            objEntityPurchaseOrder.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            objEntityPurchaseOrder.ExchngRate = Convert.ToDecimal(txtExchgRate.Text);

            string[] txtNetTotalSplit = txtNetTotal.Value.Split(' ');
            objEntityPurchaseOrder.NetAmntWthoutExchngRt = Convert.ToDecimal(txtNetTotalSplit[0]);

            string[] txtGrossTotalSplit = txtGrossTotal.Value.Split(' ');
            objEntityPurchaseOrder.GrossTotalAmnt = Convert.ToDecimal(txtGrossTotalSplit[0]);

            string[] txtTaxTotalSplit = txtTaxTotal.Value.Split(' ');
            objEntityPurchaseOrder.TaxTotalAmnt = Convert.ToDecimal(txtTaxTotalSplit[0]);

            string[] txtDiscntTotalSplit = new string[2];
            if (txtDiscntTotal.Value != "")
            {
                txtDiscntTotalSplit = txtDiscntTotal.Value.Split(' ');
                objEntityPurchaseOrder.DiscntTotalAmnt = Convert.ToDecimal(txtDiscntTotalSplit[0]);
            }

            objEntityPurchaseOrder.NetTotalAmnt = Convert.ToDecimal(hiddenNetAmnt.Value);

            objEntityPurchaseOrder.PaymntTerms = txtPaymntTerms.Text;
            objEntityPurchaseOrder.TermsAndCondtns = txtTermsCondtns.Text;
            objEntityPurchaseOrder.FreightTerms = txtFreightTerms.Text;

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrDtlsList = new List<clsEntityPurchaseOrder>();

            if (hiddenPurchsOrdrDtls.Value != "" && hiddenPurchsOrdrDtls.Value != "[]")
            {
                string jsonData = hiddenPurchsOrdrDtls.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                string DataValue = k;

                List<clsData> objDataList = new List<clsData>();
                objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                foreach (clsData objclsData in objDataList)
                {
                    clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();

                    objEntity.DtlId = Convert.ToInt32(objclsData.DTLID);
                    objEntity.SLNo = Convert.ToInt32(objclsData.SLNO);
                    objEntity.Qnty = Convert.ToDecimal(objclsData.QUANTITY);
                    objEntity.Price = Convert.ToDecimal(objclsData.PRICE);
                    objEntity.ProductTotalAmnt = Convert.ToDecimal(objclsData.TOTALAMNT);

                    if (objclsData.PRODUCTID != "")
                    {
                        objEntity.ProductId = Convert.ToInt32(objclsData.PRODUCTID);
                    }
                    if (objclsData.DISCNTPRCNTG != "")
                    {
                        objEntity.DiscntPrcnt = Convert.ToDecimal(objclsData.DISCNTPRCNTG);
                    }
                    if (objclsData.DISCNTAMNT != "")
                    {
                        objEntity.DiscntAmnt = Convert.ToDecimal(objclsData.DISCNTAMNT);
                    }
                    if (objclsData.TAXID != "")
                    {
                        objEntity.TaxId = Convert.ToInt32(objclsData.TAXID);
                    }
                    if (objclsData.TAXPRCNTG != "")
                    {
                        objEntity.TaxPrcnt = Convert.ToDecimal(objclsData.TAXPRCNTG);
                    }
                    if (objclsData.VEHICLEID != "")
                    {
                        objEntity.VehicleId = Convert.ToInt32(objclsData.VEHICLEID);
                    }
                    if (objclsData.STRTDATE != "")
                    {
                        objEntity.StartDate = objCommon.textToDateTime(objclsData.STRTDATE);
                    }
                    if (objclsData.ENDDATE != "")
                    {
                        objEntity.EndDate = objCommon.textToDateTime(objclsData.ENDDATE);
                    }
                    if (objclsData.EMPID != "")
                    {
                        objEntity.EmployeeId = Convert.ToInt32(objclsData.EMPID);
                    }
                    if (objclsData.FLGHTPNRNO != "")
                    {
                        objEntity.PNRNo = objclsData.FLGHTPNRNO;
                    }
                    if (objclsData.SECTOR != "")
                    {
                        objEntity.Sector = objclsData.SECTOR;
                    }
                    if (objclsData.TRVLDATE != "")
                    {
                        objEntity.TravelDate = objCommon.textToDateTime(objclsData.TRVLDATE);
                    }
                    objEntityPurchsOrdrDtlsList.Add(objEntity);
                }
            }

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrDtlsDELETE_List = new List<clsEntityPurchaseOrder>();

            if (hiddenCnclDtlIds.Value != "" && hiddenCnclDtlIds.Value != null)
            {
                string[] strArrCnclIds = hiddenCnclDtlIds.Value.Split(',');

                foreach (string strDtlId in strArrCnclIds)
                {
                    if (strDtlId != "")
                    {
                        clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();
                        objEntity.DtlId = Convert.ToInt32(strDtlId);
                        objEntityPurchsOrdrDtlsDELETE_List.Add(objEntity);
                    }
                }
            }


            List<clsEntityPurchaseOrder> objEntityPurchsOrdrChrgHeadList = new List<clsEntityPurchaseOrder>();

            if (hiddenChrgDtls.Value != "" && hiddenChrgDtls.Value != "[]")
            {
                string jsonData = hiddenChrgDtls.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");
                string DataValue = k;

                List<clsData> objDataList = new List<clsData>();
                objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                foreach (clsData objclsData in objDataList)
                {
                    clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();

                    objEntity.ChrgHeadId = Convert.ToInt32(objclsData.CHRGHDID);
                    objEntity.ChrgHeadAmnt = Convert.ToDecimal(objclsData.CHRGAMNT);
                    objEntityPurchsOrdrChrgHeadList.Add(objEntity);
                }
            }

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrAttchmntList = new List<clsEntityPurchaseOrder>();

            if (cbxAttachmnt.Checked == true)
            {
                if (hiddenAttchmntDtls.Value != "" && hiddenAttchmntDtls.Value != "[]")
                {
                    string jsonData = hiddenAttchmntDtls.Value;
                    string c = jsonData.Replace("\"{", "\\{");
                    string d = c.Replace("\\n", "\r\n");
                    string g = d.Replace("\\", "");
                    string h = g.Replace("}\"]", "}]");
                    string k = h.Replace("}\",", "},");
                    string DataValue = k;

                    List<clsData> objDataList = new List<clsData>();
                    objDataList = JsonConvert.DeserializeObject<List<clsData>>(DataValue);
                    for (int count = 0; count < objDataList.Count; count++)
                    {
                        string jsonFileid = "fileAttach" + objDataList[count].ROWID;

                        clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();
                        objEntity.DtlId = Convert.ToInt32(objDataList[count].DTLID);

                        for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                        {
                            string fileId = Request.Files.AllKeys[intCount].ToString();
                            HttpPostedFile PostedFile = Request.Files[intCount];
                            if (fileId == jsonFileid)
                            {
                                objEntity.Descrptn = objDataList[count].DESCRPTN;

                                if (PostedFile.ContentLength > 0)
                                {
                                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                    objEntity.ActualFileName = strFileName;
                                    string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_ATTCHMNT);
                                    objEntityCommon.CorporateID = objEntityPurchaseOrder.CorpId;
                                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ORDER_ATTCHMNT);
                                    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                                    string strImageName = "PURCHASEORDER_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                                    objEntity.FileName = strImageName;
                                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ORDER_ATTCHMNT);

                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntity.FileName);

                                    objEntityPurchsOrdrAttchmntList.Add(objEntity);
                                }
                                else if (objEntity.DtlId != 0)
                                {
                                    objEntityPurchsOrdrAttchmntList.Add(objEntity);
                                }
                            }
                        }

                    }
                }
            }

            List<clsEntityPurchaseOrder> objEntityPurchsOrdrAttchmntDELETEList = new List<clsEntityPurchaseOrder>();

            if (hiddenAttchCnclDtlIds.Value != "" && hiddenAttchCnclDtlIds.Value != null)
            {
                string[] strArrCnclIds = hiddenAttchCnclDtlIds.Value.Split(',');

                foreach (string strDtlId in strArrCnclIds)
                {
                    if (strDtlId != "")
                    {
                        clsEntityPurchaseOrder objEntity = new clsEntityPurchaseOrder();
                        objEntity.DtlId = Convert.ToInt32(strDtlId);
                        objEntityPurchsOrdrAttchmntDELETEList.Add(objEntity);
                    }
                }
            }

            List<clsEntityApprovalConsole> objEntityApprvCnslList = new List<clsEntityApprovalConsole>();

            DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderById(objEntityPurchaseOrder);
            
            int AlrdyCnfrm = 0;
            if (clickedButton.ID == "btnConfirmClick")
            {
                objEntityPurchaseOrder.Status = 1;

                objEntityApprvCnslList = GetNextApprovalIds();

                if (dt.Rows.Count > 0 && dt.Rows[0]["PRCHSORDR_CONFRM_STS"].ToString() == "1")//confrmd
                {
                    AlrdyCnfrm++;
                }
            }

            int AlrdyDeleted = 0;
            if (dt.Rows.Count > 0 && dt.Rows[0]["PRCHSORDR_CNCL_USR_ID"].ToString() != "")//deleted
            {
                AlrdyDeleted++;
            }

            if (AlrdyCnfrm == 0 && AlrdyDeleted == 0)
            {
                objBusinessPurchaseOrder.UpdatePurchaseOrder(objEntityPurchaseOrder, objEntityPurchsOrdrDtlsList, objEntityPurchsOrdrDtlsDELETE_List, objEntityPurchsOrdrChrgHeadList, objEntityPurchsOrdrAttchmntList, objEntityPurchsOrdrAttchmntDELETEList, objEntitySupplierCntctList, objEntityApprvCnslList);
            }

            if (AlrdyDeleted == 0)
            {
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateFloat")
                {
                    if (hiddenApprvaCnslMode.Value != "")
                    {
                        Response.Redirect("/Master/gen_Approval_Console/gen_Approval_Console.aspx?InsUpd=Upd");
                    }
                    else
                    {
                        Response.Redirect("pms_Purchase_Order.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                }
                else if (clickedButton.ID == "btnUpdateAndClose" || clickedButton.ID == "btnUpdateAndCloseFloat")
                {
                    Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=Upd");
                }
                else
                {
                    if (clickedButton.ID == "btnConfirmClick")
                    {

                        clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                        List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
                        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();

                        string strRef = "";
                        if (dt.Rows.Count > 0)
                        {
                            strRef = dt.Rows[0]["PRCHSORDR_REF"].ToString();
                        }

                        foreach (clsEntityApprovalConsole objEntity in objEntityApprvCnslList)
                        {
                            clsEntityLayerUserRegistration objEntityUser = new clsEntityLayerUserRegistration();
                            clsBusinessLayerUserRegisteration objBusinessUser = new clsBusinessLayerUserRegisteration();

                            objEntityUser.UsrRegistrationId = objEntity.EmployeeId;
                            DataTable dtEmp = objBusinessUser.ReadUsrMasterEdit(objEntityUser);
                            string strToMail = "", strToName = "";
                            if (dtEmp.Rows.Count > 0)
                            {
                                strToMail = dtEmp.Rows[0]["USR_EMAIL"].ToString();
                                strToName = dtEmp.Rows[0]["USR_NAME"].ToString();
                            }
                            strToMail = "projectlead.democompany@gmail.com";

                            string strEmailSubject = "Approval Request";
                            StringBuilder sb = new StringBuilder();
                            sb.Append("Dear " + strToName + ",");
                            sb.Append("<br/><br/>This email is to notify you that the purchase order with Ref# " + strRef + " requires approval.");
                            sb.Append("<br/><br/>");
                            sb.Append("<br/>Please do the needful as soon as possible.");

                            string strEmailContent = sb.ToString();

                            if (strToMail != "")
                            {
                                //SendMail(strToMail, strEmailSubject, strEmailContent, objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                            }
                        }

                        if (AlrdyCnfrm == 0)
                        {
                            Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=Confrm");
                        }
                        else
                        {
                            Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=AlrdyCnfrm");
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("pms_Purchase_Order_List.aspx?InsUpd=AlrdyDeleted");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.StartsWith("Thread") == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
            }
        }
    }

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        try
        {
            clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
            clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

            string strId = "";
            if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                strId = strRandomMixedId.Substring(2, intLenghtofId);
            }
            if (strId != "")
            {
                objEntityPurchaseOrder.PurchsOrdrId = Convert.ToInt32(strId);
            }

            if (Session["USERID"] != null)
            {
                objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityPurchaseOrder.Status = 0;

            int AlrdyReopen = 0;
            DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderById(objEntityPurchaseOrder);
            if (dt.Rows.Count > 0 && dt.Rows[0]["PRCHSORDR_CONFRM_STS"].ToString() == "0" && dt.Rows[0]["PRCHSORDR_REOPN_USR_ID"].ToString() != "")//reopened
            {
                AlrdyReopen++;
            }
            if (AlrdyReopen == 0)
            {
                objBusinessPurchaseOrder.ReopenPurchaseOrder(objEntityPurchaseOrder);
                Response.Redirect("pms_Purchase_Order.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=Reopen");
            }
            else
            {
                Response.Redirect("pms_Purchase_Order.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=AlrdyReopnd");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.StartsWith("Thread") == false)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
            }
        }
    }


    [WebMethod]
    public static string[] LoadChargeHeads(string CorpId, string OrgId, string ChrgHdId)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
        if (ChrgHdId != "")
        {
            objEntityPurchaseOrder.ChrgHeadId = Convert.ToInt32(ChrgHdId);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadChargeHeads(objEntityPurchaseOrder);

        List<string> ListReturn = new List<string>();

        if (ChrgHdId != "" && dt.Rows.Count > 0)
        {
            ListReturn.Add(dt.Rows[0]["CHRGHD_CALCULATE"].ToString());
        }

        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            ListReturn.Add(string.Format("{0}<>{1}", dt.Rows[intRow]["CHRGHD_ID"].ToString(), dt.Rows[intRow]["CHRGHD_NAME"].ToString()));
        }
        return ListReturn.ToArray();
    }


    [WebMethod]
    public static string LoadBulkProducts(string CorpId, string OrgId, string ProductMode, string strText)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
        objEntityPurchaseOrder.CommonSearchTerm = strText;

        DataTable dt = new DataTable();
        if (ProductMode == "1")
        {
            dt = objBusinessPurchaseOrder.ReadProducts(objEntityPurchaseOrder);
        }
        else if (ProductMode == "2")
        {
            dt = objBusinessPurchaseOrder.ReadVehicles(objEntityPurchaseOrder);
        }

        StringBuilder sb = new StringBuilder();
        for (int intRow = 0; intRow < dt.Rows.Count; intRow++)
        {
            sb.Append("<li id=\"liPrdct_" + dt.Rows[intRow]["PRDT_ID"].ToString() + "\" data-draggable=\"item\" draggable=\"true\" style=\"word-break:break-word;\"><input id=\"cbxPrdct" + dt.Rows[intRow]["PRDT_ID"].ToString() + "\" type=\"checkbox\" class=\"ck_b1\" onclick=\"return AppendSelectedList('" + dt.Rows[intRow]["PRDT_ID"].ToString() + "','" + dt.Rows[intRow]["PRDT_NAME"].ToString() + "','1');\" /><label id=\"lblPrdct" + dt.Rows[intRow]["PRDT_ID"].ToString() + "\">" + dt.Rows[intRow]["PRDT_NAME"].ToString() + "</label><input id=\"txtBulkQnty" + dt.Rows[intRow]["PRDT_ID"].ToString() + "\" class=\"in_qty tr_c\" type=\"number\" value=\"1\" placeholder=\"1\" min=\"1\"></li>");
        }

        return sb.ToString();
    }

    public void LoadProjects()
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        if (Session["USERID"] != null)
        {
            objEntityPurchaseOrder.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlPODivision.SelectedItem.Value != "--SELECT DIVISION--" && ddlPODivision.SelectedItem.Value != "")
        {
            objEntityPurchaseOrder.DivisionId = Convert.ToInt32(ddlPODivision.SelectedItem.Value);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadProjects(objEntityPurchaseOrder);

        ddlProjects.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlProjects.DataSource = dt;
            ddlProjects.DataTextField = "PROJECT_NAME";
            ddlProjects.DataValueField = "PROJECT_ID";
            ddlProjects.DataBind();
        }
        ddlProjects.Items.Insert(0, "--SELECT PROJECT--");
    }

    public void LoadWarehouse()
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--" && ddlProjects.SelectedItem.Value != "")
        {
            objEntityPurchaseOrder.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadWarehouse(objEntityPurchaseOrder);

        string PrimaryWarehouse = "";
        if (dt.Rows.Count > 0)
        {
            PrimaryWarehouse = dt.Rows[0]["PROJECTS_WAREHOUSE_PRIMARY_ID"].ToString();
        }

        ddlWarehouse.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlWarehouse.DataSource = dt;
            ddlWarehouse.DataTextField = "WRHS_NAME";
            ddlWarehouse.DataValueField = "WRHS_ID";
            ddlWarehouse.DataBind();
        }
        ddlWarehouse.Items.Insert(0, "--SELECT WAREHOUSE--");

        if (PrimaryWarehouse != "")
        {
            if (ddlWarehouse.Items.FindByValue(PrimaryWarehouse) != null)
            {
                ddlWarehouse.Items.FindByValue(PrimaryWarehouse).Selected = true;
            }
        }
    }

    public void LoadCustomer()
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--" && ddlProjects.SelectedItem.Value != "")
        {
            objEntityPurchaseOrder.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadCustomers(objEntityPurchaseOrder);

        string ProjectCtmrId = "";
        if (dt.Rows.Count > 0)
        {
            ProjectCtmrId = dt.Rows[0]["PRJCT_CSTMRID"].ToString();
        }

        ddlPORequestor.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlPORequestor.DataSource = dt;
            ddlPORequestor.DataTextField = "CSTMR_NAME";
            ddlPORequestor.DataValueField = "CSTMR_ID";
            ddlPORequestor.DataBind();
        }
        ddlPORequestor.Items.Insert(0, "--SELECT CUSTOMER--");

        if (ProjectCtmrId != "")
        {
            if (ddlPORequestor.Items.FindByValue(ProjectCtmrId) != null)
            {
                ddlPORequestor.Items.FindByValue(ProjectCtmrId).Selected = true;
            }
        }
    }

    public void LoadVendorContacts()
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (hiddenVendorId.Value != "--SELECT VENDOR--" && hiddenVendorId.Value != "")
        {
            objEntityPurchaseOrder.VendorId = Convert.ToInt32(hiddenVendorId.Value);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadVendorCntctPrsn(objEntityPurchaseOrder);

        string strRating = "";

        if (dt.Rows.Count > 0 && dt.Rows[0]["SUPLIR_CNTCT_ID"].ToString() != "")
        {
            strRating = dt.Rows[0]["SUPLIR_RATING"].ToString();
            if (dt.Rows[0]["SUPLIR_CONTACTNO"].ToString() != "")
            {
                txtVendorMobile.Text = dt.Rows[0]["SUPLIR_CONTACTNO"].ToString();
            }
        }

        ddlVendorContact.Items.Clear();
        if (dt.Rows.Count > 0 && dt.Rows[0]["SUPLIR_CNTCT_ID"].ToString() != "")
        {
            ddlVendorContact.DataSource = dt;
            ddlVendorContact.DataTextField = "SUPLIR_CNTCT_NAME";
            ddlVendorContact.DataValueField = "SUPLIR_CNTCT_ID";
            ddlVendorContact.DataBind();
        }
        ddlVendorContact.Items.Insert(0, "--SELECT CONTACT PERSON--");

        if (dt.Rows.Count == 1 && dt.Rows[0]["SUPLIR_CNTCT_ID"].ToString() != "")
        {
            if (ddlVendorContact.Items.FindByValue(dt.Rows[0]["SUPLIR_CNTCT_ID"].ToString()) != null)
            {
                ddlVendorContact.Items.FindByValue(dt.Rows[0]["SUPLIR_CNTCT_ID"].ToString()).Selected = true;
            }
        }

        if (strRating != "")
        {
            float decRating = float.Parse(strRating, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            spanRate1.Attributes.Add("class", "fa fa-star-o");
            spanRate2.Attributes.Add("class", "fa fa-star-o");
            spanRate3.Attributes.Add("class", "fa fa-star-o");
            spanRate4.Attributes.Add("class", "fa fa-star-o");
            spanRate5.Attributes.Add("class", "fa fa-star-o");

            if (decRating == 0.5)
            {
                spanRate1.Attributes.Add("class", "fa fa-star-half-o checked");
            }
            if (decRating >= 1)
            {
                if (decRating >= 1.5)
                {
                    spanRate2.Attributes.Add("class", "fa fa-star-half-o checked");
                }
                spanRate1.Attributes.Add("class", "fa fa-star checked");
            }
            if (decRating >= 2)
            {
                if (decRating >= 2.5)
                {
                    spanRate3.Attributes.Add("class", "fa fa-star-half-o checked");
                }
                spanRate2.Attributes.Add("class", "fa fa-star checked");
            }
            if (decRating >= 3)
            {
                if (decRating >= 3.5)
                {
                    spanRate4.Attributes.Add("class", "fa fa-star-half-o checked");
                }
                spanRate3.Attributes.Add("class", "fa fa-star checked");
            }
            if (decRating >= 4)
            {
                if (decRating >= 4.5)
                {
                    spanRate5.Attributes.Add("class", "fa fa-star-half-o checked");
                }
                spanRate4.Attributes.Add("class", "fa fa-star checked");
            }
            if (decRating == 5)
            {
                spanRate5.Attributes.Add("class", "fa fa-star checked");
            }
        }
    }

    public void LoadCustomerContact()
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchaseOrder.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityPurchaseOrder.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (ddlPORequestor.SelectedItem.Value != "" && ddlPORequestor.SelectedItem.Value != "--SELECT CUSTOMER--")
        {
            objEntityPurchaseOrder.RqstdCustomerId = Convert.ToInt32(ddlPORequestor.SelectedItem.Value);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadPOCntctPrsn(objEntityPurchaseOrder);

        ddlPOContact.Items.Clear();
        if (dt.Rows.Count > 0)
        {
            ddlPOContact.DataSource = dt;
            ddlPOContact.DataTextField = "CSTMRCNT_NAME";
            ddlPOContact.DataValueField = "CSTMRCNT_ID";
            ddlPOContact.DataBind();
        }
        ddlPOContact.Items.Insert(0, "--SELECT CONTACT PERSON--");

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["CSTMR_MOBILE"].ToString() != "")
            {
                txtPOMobile.Text = dt.Rows[0]["CSTMR_MOBILE"].ToString();
            }
        }

        if (dt.Rows.Count == 1)
        {
            if (ddlPOContact.Items.FindByValue(dt.Rows[0]["CSTMRCNT_ID"].ToString()) != null)
            {
                ddlPOContact.Items.FindByValue(dt.Rows[0]["CSTMRCNT_ID"].ToString()).Selected = true;
            }
        }
    }

    protected void ddlPODivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProjects();
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(1);", true);
    }

    protected void ddlProjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadWarehouse();
        LoadCustomer();

        objEntityPurchaseOrder.DeliverToSts = 1;
        if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--" && ddlProjects.SelectedItem.Value != "")
        {
            objEntityPurchaseOrder.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
        }
        DataTable dt = objBusinessPurchaseOrder.ReadLocationDtls(objEntityPurchaseOrder);
        if (dt.Rows.Count > 0)
        {
            txtWarehouseDelivery.Text = dt.Rows[0]["WRHS_ADRESS1"].ToString();
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(2);", true);
    }

    protected void ddlPORequestor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCustomerContact();
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(3);", true);
    }

    protected void ddlVendor_TextChanged(object sender, EventArgs e)
    {
        LoadVendorContacts();
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(4);", true);
    }

    protected void btnPrjct_Click(object sender, EventArgs e)
    {
        LoadProjects();

        if (hiddenProjectId.Value != "")
        {
            ddlProjects.ClearSelection();
            if (ddlProjects.Items.FindByValue(hiddenProjectId.Value) != null)
            {
                ddlProjects.Items.FindByValue(hiddenProjectId.Value).Selected = true;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(1);", true);
    }

    protected void btnSupp_Click(object sender, EventArgs e)
    {
        LoadVendorContacts();
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(4);", true);
    }

    [WebMethod]
    public static string[] ChangeContactPerson(string Mode, string ContactId)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        objEntityPurchaseOrder.ModeOfSupply = Convert.ToInt32(Mode);
        if (objEntityPurchaseOrder.ModeOfSupply == 0)
        {
            objEntityPurchaseOrder.VendorCntctPrsnId = Convert.ToInt32(ContactId);
        }
        else
        {
            objEntityPurchaseOrder.POCntctPrsnId = Convert.ToInt32(ContactId);
        }

        DataTable dt = objBusinessPurchaseOrder.ReadContactDtlsById(objEntityPurchaseOrder);

        string[] strReturn = new string[1];
        if (dt.Rows.Count > 0)
        {
            strReturn[0] = dt.Rows[0]["CNTCT_MOBILE"].ToString();
        }
        return strReturn;
    }

    public List<clsEntityApprovalConsole> GetNextApprovalIds()
    {
        List<clsEntityApprovalConsole> objEntityList = new List<clsEntityApprovalConsole>();

        clsEntityApprovalConsole objEntityApprvlCnsl = new clsEntityApprovalConsole();
        clsBusinessLayerApprovalConsole objBusinessApprvlCnsl = new clsBusinessLayerApprovalConsole();

        string strId = "";
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            strId = strRandomMixedId.Substring(2, intLenghtofId);
        }
        if (strId != "")
        {
            objEntityApprvlCnsl.PurchsOrdrId = Convert.ToInt32(strId);
        }

        if (Session["USERID"] != null)
        {
            objEntityApprvlCnsl.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityApprvlCnsl.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityApprvlCnsl.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityApprvlCnsl.WrkFlowId = Convert.ToInt32(ddlDocumntWrkflw.SelectedItem.Value);

        DataTable dtHierarchy = objBusinessApprvlCnsl.ReadHierarchy(objEntityApprvlCnsl);

        if (dtHierarchy.Rows.Count > 0)
        {
            int Level = Convert.ToInt32(dtHierarchy.Rows[0]["WRKFLWFLT_LEVEL"].ToString());
            for (int intRow = 0; intRow < dtHierarchy.Rows.Count; intRow++)
            {
                int NewLevel = Convert.ToInt32(dtHierarchy.Rows[intRow]["WRKFLWFLT_LEVEL"].ToString());

                if (Level == NewLevel)
                {
                    objEntityApprvlCnsl.EmployeeId = Convert.ToInt32(dtHierarchy.Rows[intRow]["USR_ID"].ToString());
                    objEntityApprvlCnsl.DesignatnId = Convert.ToInt32(dtHierarchy.Rows[intRow]["DSGN_ID"].ToString());
                    objEntityApprvlCnsl.Level = Convert.ToInt32(Level);

                    clsEntityApprovalConsole objEntity = new clsEntityApprovalConsole();

                    DataTable dtConditions = objBusinessApprvlCnsl.ReadConditions(objEntityApprvlCnsl);

                    if (dtConditions.Rows.Count > 0)
                    {
                        int Flag = 0;
                        for (int intCRow = 0; intCRow < dtConditions.Rows.Count; intCRow++)
                        {
                            objEntityApprvlCnsl.ConditionId = Convert.ToInt32(dtConditions.Rows[intCRow]["CNDTN_ID"].ToString());
                            objEntityApprvlCnsl.ConditionType = Convert.ToInt32(dtConditions.Rows[intCRow]["CNDTN_TYPE_ID"].ToString());

                            objEntityApprvlCnsl.ConditionValues = dtConditions.Rows[intCRow]["APRVLSET_DTL_VALUES"].ToString();
                            objEntityApprvlCnsl.ConditionMinVal = Convert.ToInt32(dtConditions.Rows[intCRow]["APRVLSET_DTL_MINVAL"].ToString());
                            objEntityApprvlCnsl.ConditionMaxVal = Convert.ToInt32(dtConditions.Rows[intCRow]["APRVLSET_DTL_MAXVAL"].ToString());

                            DataTable dtChkConditions = objBusinessApprvlCnsl.CheckConditions(objEntityApprvlCnsl);

                            if (dtChkConditions.Rows[0]["CNT"].ToString() != "0")
                            {
                                Flag++;
                            }
                        }

                        if (Flag == dtConditions.Rows.Count)
                        {
                            objEntity.Level = objEntityApprvlCnsl.Level;
                            objEntity.EmployeeId = objEntityApprvlCnsl.EmployeeId;
                            objEntityList.Add(objEntity);
                        }
                    }
                    else
                    {
                        objEntity.Level = objEntityApprvlCnsl.Level;
                        objEntity.EmployeeId = objEntityApprvlCnsl.EmployeeId;
                        objEntityList.Add(objEntity);
                    }

                }
                else
                {
                    if (objEntityList.Count == 0)
                    {
                        Level = NewLevel;
                    }
                }
            }
        }

        return objEntityList;
    }

    [WebMethod]
    public static string LoadSearchPO(string CorpId, string OrgId, string strText)
    {
        clsBusinessLayerPurchaseOrder objBusinessPurchaseOrder = new clsBusinessLayerPurchaseOrder();
        clsEntityPurchaseOrder objEntityPurchaseOrder = new clsEntityPurchaseOrder();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        objEntityPurchaseOrder.CorpId = Convert.ToInt32(CorpId);
        objEntityPurchaseOrder.OrgId = Convert.ToInt32(OrgId);
        objEntityPurchaseOrder.Status = 3;
        objEntityPurchaseOrder.CancelStatus = 0;
        objEntityPurchaseOrder.PurchaseOrderType = 0;
        objEntityPurchaseOrder.SearchRef = strText;

        DataTable dt = objBusinessPurchaseOrder.ReadPurchaseOrderList(objEntityPurchaseOrder);

        StringBuilder sb = new StringBuilder();

        sb.Append("<table class=\"table table-bordered qk_tbl\">");
        sb.Append("<thead class=\"thead1\"><tr>");
        sb.Append("<th>Purchase Order Type</th>");
        sb.Append("<th>Purchase Order Date</th>");
        sb.Append("<th>Vendor</th>");
        sb.Append("<th>Project</th>");
        sb.Append("<th>Exp.delivery Date</th>");
        sb.Append("</tr></thead>");
        sb.Append("<tbody>");

        if (dt.Rows.Count > 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                sb.Append("<tr>");
                sb.Append("<th>" + dt.Rows[intRowBodyCount]["PO_TYP"].ToString() + "</th>");
                sb.Append("<th>" + dt.Rows[intRowBodyCount]["PRCHSORDR_DATE"].ToString() + "</th>");
                sb.Append("<th>" + dt.Rows[intRowBodyCount]["SUPLIR_NAME"].ToString() + "</th>");
                sb.Append("<th>" + dt.Rows[intRowBodyCount]["PROJECT_NAME"].ToString() + "</th>");
                sb.Append("<th>" + dt.Rows[intRowBodyCount]["PRCHSORDR_DLVRYDT"].ToString() + "</th>");
                sb.Append("</tr>");
            }
        }
        else
        {
            sb.Append("<tr></tr>");
        }
        sb.Append("</tbody>");
        sb.Append("</table>");

        return sb.ToString();
    }

    protected void btnCopyClick_Click(object sender, EventArgs e)
    {
        string[] strCopySplit = HiddenCopy.Value.Split(',');

        string strRandomMixedId = strCopySplit[0];
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);

        UpdateView(strId, "1", strCopySplit[1], strCopySplit[2], strCopySplit[3], strCopySplit[4]);

        ScriptManager.RegisterStartupScript(this, GetType(), "LoadFunctions", "LoadFunctions('" + hiddenEditDtls.Value + "','" + hiddenChrgDtls.Value + "','" + txtPaymntTerms.Text + "','" + txtTermsCondtns.Text + "','" + txtFreightTerms.Text + "','" + hiddenVendorId.Value + "','" + hiddenF9Mode.Value + "');", true);
    }

    public void SendMail(string strToMail, string strEmailSubject, string strEmailContent, clsEntityMailConsole objEntityMail, List<clsEntityMailAttachment> objEntityMailAttachList, List<clsEntityMailCcBCc> objEntityMailCcBCcList, List<classEntityToMailAddress> objEntityToMailAddressList)
    {
        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityUserReg.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtFromMail = objBusinessLayer.ReadFromMailDetails(objEntityUserReg);

        objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
        objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
        objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
        objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
        objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
        objEntityMail.D_Date = System.DateTime.Now;

        objEntityMail.To_Email_Address = strToMail;
        objEntityMail.Email_Subject = strEmailSubject;
        objEntityMail.Email_Content = strEmailContent;

        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon ObjEntityCommon = new clsEntityCommon();
        clsBusinessLayer objDataCommon = new clsBusinessLayer();

        ObjEntityCommon.CorporateID = Convert.ToInt32(HttpContext.Current.Session["CORPOFFICEID"].ToString());
        ObjEntityCommon.Organisation_Id = Convert.ToInt32(HttpContext.Current.Session["ORGID"].ToString());
        DataTable dtCorp = objDataCommon.ReadCorpDetails(ObjEntityCommon);
        string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyMobile = "", strCompanyPhone = "";
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
            strCompanyMobile = dtCorp.Rows[0]["CORPRT_MOBILE"].ToString();
            strCompanyPhone = dtCorp.Rows[0]["CORPRT_PHONE"].ToString();
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

        StringBuilder sb = new StringBuilder();

        sb.Append("<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>");
        sb.Append("<br/><br/><br/>Best Regards,");
        sb.Append("<br/><font color=\"#0a409b\"><b>Admin Department</b></font><br/><font color=\"#438df8\">democlient Trading and Contracting Co. WLL </font><br/><font color=\"#438df8\">T: +974 44667714/15/16<br/>P O Box 5777, Doha - Qatar</font>");
        //sb.Append("<br/><br/><br/><b><u>NOTE</u></b>: <i>This is system generated email. Kindly do not reply to this email address. For any queries/feedback, please email to itsupport@albaalagh.com</i>");
        //sb.Append("<br/><br/><br/>Best Regards,");
        //sb.Append("<br/><font color=\"#0a409b\"><b>Admin Department</b></font><br/><font color=\"#438df8\">" + strCompanyName + "</font><br/><font color=\"#438df8\">T: " + strCompanyMobile + "<br/>" + strAddress + "</font>");

        objEntityMail.Signature = sb.ToString();

        objMail.SendMailAsHtml(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
    }

    protected void ddlWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        objEntityPurchaseOrder.DeliverToSts = 0;
        if (ddlWarehouse.SelectedItem.Value != "--SELECT WAREHOUSE--" && ddlWarehouse.SelectedItem.Value != "")
        {
            objEntityPurchaseOrder.WarehouseId = Convert.ToInt32(ddlWarehouse.SelectedItem.Value);
        }
        DataTable dt = objBusinessPurchaseOrder.ReadLocationDtls(objEntityPurchaseOrder);
        if (dt.Rows.Count > 0)
        {
            txtWarehouseDelivery.Text = dt.Rows[0]["WRHS_ADRESS1"].ToString();
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteAll", "AutoCompleteAll(1);", true);
    }
}