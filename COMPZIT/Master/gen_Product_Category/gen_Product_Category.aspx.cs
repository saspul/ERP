using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.Collections;
using CL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Web.Services;
// CREATED BY:EVM-0002
// CREATED DATE:15/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Product_Category_gen_Product_Category : System.Web.UI.Page
{

    private enum Category_Type
    {
        Main_Category=1,
        Sub_Category=2,
        Small_Category=3,
        Least_Category=4
    }
    
    //Creating objects for businesslayer
    clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
    protected void Page_Load(object sender, EventArgs e)
    {

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        //Assigning  Key actions  .
        txtCategoryName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCategoryName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCategoryCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtCategoryCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCategoryType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlParentCategory.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //ddlParentCategory.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlProductGroup.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlProductGroup.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            int intCommodityMaintndOffice = Convert.ToInt32(dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"]);
            //==1  means current corporate office is a commodity concept maintained corporate office
            if (intCommodityMaintndOffice == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCodeOpen", "CategoryCodeOpen();", true);
            }

        }

        if (!IsPostBack)
        {
            //txtCategoryName.Focus();
            LoadLedgers();
            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Product_Category);
            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            ddlLedger.Enabled = false;
            ddlPurchase.Enabled = false;

            //HiddenBusinessSpecific.Value = "0";
            //HiddenAccountSpecific.Value = "0";
            int intBusinessSpecific = 0, intAccountSpecific = 0;
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        intBusinessSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        //HiddenBusinessSpecific.Value = "1";
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        intAccountSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        // HiddenAccountSpecific.Value = "1";
                    }

                }
            }

            if (intBusinessSpecific == 1 && intAccountSpecific == 0)
            {
                ddlLedger.Enabled = false;
                ddlPurchase.Enabled = false;
            }
            else if (intBusinessSpecific == 0 && intAccountSpecific == 1)
            {
                ddlLedger.Enabled = true;
                ddlPurchase.Enabled = true;
            }
            else if (intBusinessSpecific == 1 && intAccountSpecific == 1)
            {
                ddlLedger.Enabled = true;
                ddlPurchase.Enabled = true;
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldEditId.Value = strId;
                Update(strId);
                lblEntry.InnerText = "Edit Product Category";
                lblEntryB.InnerText = "Edit Product Category";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText = "View Product Category";
                lblEntryB.InnerText = "View Product Category";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Product Category";
                lblEntryB.InnerText = "Add Product Category";
                //Category_Type_Load();
                Product_Group_Load();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                if (Request.QueryString["InsUpd"] != null)
                {
                    string strInsUpd = Request.QueryString["InsUpd"].ToString();
                    if (strInsUpd == "Ins")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }
            }

        }
    }
    //Method for assigning product group
    public void Product_Group_Load()
    {
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCategory.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCategory.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtGroup = objBusinessLayerCategory.Read_Product_Group(objEntityCategory);

        ddlProductGroup.Items.Clear();

        ddlProductGroup.DataSource = dtGroup;

        ddlProductGroup.DataTextField = "PRDTGP_NAME";
        ddlProductGroup.DataValueField = "PRDTGP_ID";
        ddlProductGroup.DataBind();

        ddlProductGroup.Items.Insert(0, "--SELECT PRODUCT GROUP--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCategory.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCategory.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        string strCodeCount = "0";
        if (Convert.ToInt32(ddlCategoryType.Value) == Convert.ToInt32(Category_Type.Main_Category))
        {
            objEntityCategory.MainCategoryId = 0;
            objEntityCategory.CategoryType_Id = Convert.ToInt32(ddlCategoryType.Value);
            objEntityCategory.Commodity_Code = txtCategoryCode.Text;
            objEntityCategory.Item_Group_Id = Convert.ToInt32(ddlProductGroup.SelectedItem.Value);
            strCodeCount = objBusinessLayerCategory.CheckCategoryCode(objEntityCategory);
        }
        else
        {
            objEntityCategory.MainCategoryId = Convert.ToInt32(HiddenFieldParentCtgry.Value);
            objEntityCategory.CategoryType_Id = Convert.ToInt32(ddlCategoryType.Value);
            objEntityCategory.Commodity_Code = null;
            objEntityCategory.Item_Group_Id = 0;            
        }        
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityCategory.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityCategory.Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityCategory.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
        {
            objEntityCategory.LedgerID = Convert.ToInt32(ddlLedger.SelectedItem.Value);
        }
        if (ddlPurchase.SelectedItem.Value != "--SELECT LEDGER--")
        {
            objEntityCategory.PurchaseLedgerID = Convert.ToInt32(ddlPurchase.SelectedItem.Value);
        }

        objEntityCategory.D_Date = System.DateTime.Now;
        txtCategoryName.Text = txtCategoryName.Text.ToUpper().Trim();
        objEntityCategory.Category_name = txtCategoryName.Text;
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerCategory.CheckCategoryName(objEntityCategory);
       
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            if (strCodeCount == "0")
            {
                objBusinessLayerCategory.AddCategoryMaster(objEntityCategory);
                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                {
                    Response.Redirect("gen_Product_Category.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
                {
                    Response.Redirect("gen_Product_CategoryList.aspx?InsUpd=Ins");
                }
             
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
                txtCategoryCode.Focus();
            }
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
            txtCategoryName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityCategory objEntityCategory = new clsEntityCategory();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCategory.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCategory.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //set a variable for category code count
            string strCodeCount = "0";
            //fetch id category id from qu ery string
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCategory.Category_Id = Convert.ToInt32(strId);

            if (Convert.ToInt32(ddlCategoryType.Value) == Convert.ToInt32(Category_Type.Main_Category))
            {
                objEntityCategory.MainCategoryId = 0;
                objEntityCategory.CategoryType_Id = Convert.ToInt32(ddlCategoryType.Value);
                objEntityCategory.Commodity_Code = txtCategoryCode.Text;
                objEntityCategory.Item_Group_Id = Convert.ToInt32(ddlProductGroup.SelectedItem.Value);
                strCodeCount = objBusinessLayerCategory.CheckCategoryCode(objEntityCategory);
            }
            else
            {
                objEntityCategory.MainCategoryId = Convert.ToInt32(HiddenFieldParentCtgry.Value);
                objEntityCategory.CategoryType_Id = Convert.ToInt32(ddlCategoryType.Value);
                objEntityCategory.Commodity_Code = null;
                objEntityCategory.Item_Group_Id = 0;
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityCategory.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityCategory.Status = 0;
            }
            
            if (Session["USERID"] != null)
            {
                objEntityCategory.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityCategory.D_Date = System.DateTime.Now;
            txtCategoryName.Text = txtCategoryName.Text.ToUpper().Trim();
            objEntityCategory.Category_name = txtCategoryName.Text;

            if (ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
            {
                objEntityCategory.LedgerID = Convert.ToInt32(ddlLedger.SelectedItem.Value);
            }
            if (ddlPurchase.SelectedItem.Value != "--SELECT LEDGER--")
            {
                objEntityCategory.PurchaseLedgerID = Convert.ToInt32(ddlPurchase.SelectedItem.Value);
            }
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerCategory.CheckCategoryName(objEntityCategory);

            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                if (strCodeCount == "0")
                {
                     DataTable dtComplaintDetail = objBusinessLayerCategory.ReadCategoryById(objEntityCategory);
                     if (dtComplaintDetail.Rows.Count > 0)
                     {
                         if (dtComplaintDetail.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == null)
                         {
                             objBusinessLayerCategory.UpdateCategory(objEntityCategory);
                             if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                             {
                                 Response.Redirect("gen_Product_Category.aspx?InsUpd=Upd");
                             }
                             else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                             {
                                 Response.Redirect("gen_Product_CategoryList.aspx?InsUpd=Upd");
                             }
                         }
                         else
                         {
                             Response.Redirect("gen_Product_CategoryList.aspx?InsUpd=AlCncl");
                         }
                     }
                  
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
                    txtCategoryCode.Focus();
                }
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
                txtCategoryName.Focus();
            }
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        objEntityCategory.Category_Id = Convert.ToInt32(strP_Id);
        DataTable dtCategoryById = objBusinessLayerCategory.ReadCategoryById(objEntityCategory);

        txtCategoryName.Text = dtCategoryById.Rows[0]["CTGRY_NAME"].ToString();
        ddlCategoryType.Items.Clear();
        ListItem lstCategoryType = new ListItem(dtCategoryById.Rows[0]["CTGRYTYP_NAME"].ToString(), dtCategoryById.Rows[0]["CTGRYTYP_ID"].ToString());
        ddlCategoryType.Items.Insert(0, lstCategoryType);
        if (Convert.ToInt32(dtCategoryById.Rows[0]["CTGRYTYP_ID"]) == Convert.ToInt32(Category_Type.Main_Category))
        {
            //call function for main category
            ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
            ddlProductGroup.Items.Clear();
            ListItem lstProductGroup = new ListItem(dtCategoryById.Rows[0]["PRDTGP_NAME"].ToString(), dtCategoryById.Rows[0]["PRDTGP_ID"].ToString());
            ddlProductGroup.Items.Insert(0, lstProductGroup);
            txtCategoryCode.Text = dtCategoryById.Rows[0]["CTGRY_CMDY_CODE"].ToString();
            ddlProductGroup.Enabled = false;
            txtCategoryCode.Enabled = false;
        }
        else
        {
            //call function for other category
            ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
            clsEntityCategory objEntitySecondCategory = new clsEntityCategory();
            objEntitySecondCategory.Category_Id = Convert.ToInt32(dtCategoryById.Rows[0]["MAIN_CTGRY_ID"]);
            DataTable dtMainCategory = objBusinessLayerCategory.ReadCategoryById(objEntitySecondCategory);
            if (dtMainCategory.Rows[0]["CTGRY_STATUS"].ToString() == "1" && dtMainCategory.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == "")
            {
                HiddenFieldParentCtgry.Value = dtCategoryById.Rows[0]["MAIN_CTGRY_ID"].ToString();
                ddlParentCategory.Text = dtMainCategory.Rows[0]["CTGRY_NAME"].ToString();
            }
            else
            {
                HiddenFieldParentCtgry.Value = dtMainCategory.Rows[0]["MAIN_CTGRY_ID"].ToString();
                ddlParentCategory.Text = dtMainCategory.Rows[0]["CTGRY_NAME"].ToString();
            }

            ddlParentCategory.Enabled = false;
        }

        int intStatus = Convert.ToInt32(dtCategoryById.Rows[0]["CTGRY_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
        txtCategoryName.Enabled = false;
        ddlCategoryType.Disabled = true;
        ddlLedger.Enabled = false;
        ddlPurchase.Enabled = false;
        cbxStatus.Disabled = true;

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString() != "")
        {
            if (dtCategoryById.Rows[0]["LDGR_STATUS"].ToString() == "1" && dtCategoryById.Rows[0]["LDGR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlLedger.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()) != null)
                {
                    ddlLedger.ClearSelection();
                    ddlLedger.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lst = new ListItem(dtCategoryById.Rows[0]["LDGR_NAME"].ToString(), dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString());
                ddlLedger.Items.Insert(1, lst);

                SortDDL(ref this.ddlLedger);
                ddlLedger.ClearSelection();
                ddlLedger.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()).Selected = true;
            }

        }
        if (dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString() != "")
        {
            if (dtCategoryById.Rows[0]["PURCHS_LDGR_STATUS"].ToString() == "1" && dtCategoryById.Rows[0]["PURCHSE_CANCAL_STATUS"].ToString() == "")
            {
                if (ddlPurchase.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString()) != null)
                {
                    ddlPurchase.ClearSelection();
                    ddlPurchase.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lst = new ListItem(dtCategoryById.Rows[0]["PURCHS_LEDGER"].ToString(), dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString());
                ddlPurchase.Items.Insert(1, lst);

                SortDDL(ref this.ddlPurchase);
                ddlPurchase.ClearSelection();
                ddlPurchase.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString()).Selected = true;
            }

        }

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            int intCommodityMaintndOffice = Convert.ToInt32(dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"]);
            //==1  means current corporate office is a commodity concept maintained corporate office
            if (intCommodityMaintndOffice == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCodeOpen", "CategoryCodeOpen();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCodeClose", "CategoryCodeClose();", true);
            }
        }
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityCategory objEntityCategory = new clsEntityCategory();
        objEntityCategory.Category_Id = Convert.ToInt32(strP_Id);
        DataTable dtCategoryById = objBusinessLayerCategory.ReadCategoryById(objEntityCategory);

        txtCategoryName.Text = dtCategoryById.Rows[0]["CTGRY_NAME"].ToString();
        //Category_Type_Load();
        Product_Group_Load();
        ddlCategoryType.Items.FindByValue(dtCategoryById.Rows[0]["CTGRYTYP_ID"].ToString()).Selected = true;

        if (Convert.ToInt32(dtCategoryById.Rows[0]["CTGRYTYP_ID"]) == Convert.ToInt32(Category_Type.Main_Category))
        {
            //call function for main category
            ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
            //Parent_Category_Load();
            if (dtCategoryById.Rows[0]["PRDTGP_STATUS"].ToString() == "1" && dtCategoryById.Rows[0]["PRDTGP_CNCL_USR_ID"].ToString() == "")
            {
                ddlProductGroup.Items.FindByText(dtCategoryById.Rows[0]["PRDTGP_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstProductGroup = new ListItem(dtCategoryById.Rows[0]["PRDTGP_NAME"].ToString(), dtCategoryById.Rows[0]["PRDTGP_ID"].ToString());
                ddlProductGroup.Items.Insert(1, lstProductGroup);
                SortDDL(ref this.ddlProductGroup);
                ddlProductGroup.Items.FindByText(dtCategoryById.Rows[0]["PRDTGP_NAME"].ToString()).Selected = true;
                
            }
            txtCategoryCode.Text = dtCategoryById.Rows[0]["CTGRY_CMDY_CODE"].ToString();
        }
        else
        {
            //call function for other category
            ScriptManager.RegisterStartupScript(this, GetType(), "TypeChange", "TypeChange(1);", true);
            //Parent_Category_Load();
            clsEntityCategory objEntitySecondCategory = new clsEntityCategory();
            objEntitySecondCategory.Category_Id = Convert.ToInt32(dtCategoryById.Rows[0]["MAIN_CTGRY_ID"]);
            DataTable dtMainCategory = objBusinessLayerCategory.ReadCategoryById(objEntitySecondCategory);
            if (dtMainCategory.Rows[0]["CTGRY_STATUS"].ToString() == "1" && dtMainCategory.Rows[0]["CTGRY_CNCL_USR_ID"].ToString() == "")
            {
                HiddenFieldParentCtgry.Value = dtCategoryById.Rows[0]["MAIN_CTGRY_ID"].ToString();
                ddlParentCategory.Text = dtMainCategory.Rows[0]["CTGRY_NAME"].ToString();
            }
            else
            {
                HiddenFieldParentCtgry.Value = dtMainCategory.Rows[0]["MAIN_CTGRY_ID"].ToString();
                ddlParentCategory.Text = dtMainCategory.Rows[0]["CTGRY_NAME"].ToString();
            }
           
        }
        //is this category used anywhere else
        if (dtCategoryById.Rows[0]["CANCEL_COUNT"] != DBNull.Value)
        {
            if (Convert.ToInt32(dtCategoryById.Rows[0]["CANCEL_COUNT"]) != 0)
            {
                ddlCategoryType.Disabled = true;
                ddlParentCategory.Enabled = false;
            }
        }

        if (dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()!="")
        {
            if (dtCategoryById.Rows[0]["LDGR_STATUS"].ToString() == "1" && dtCategoryById.Rows[0]["LDGR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlLedger.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()) != null)
                {
                    ddlLedger.ClearSelection();
                    ddlLedger.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lst = new ListItem(dtCategoryById.Rows[0]["LDGR_NAME"].ToString(), dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString());
                ddlLedger.Items.Insert(1, lst);

                SortDDL(ref this.ddlLedger);
                ddlLedger.ClearSelection();
                ddlLedger.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_LDGR_ID"].ToString()).Selected = true;
            }

        }
        if (dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString() != "")
        {
            if (dtCategoryById.Rows[0]["PURCHS_LDGR_STATUS"].ToString() == "1" && dtCategoryById.Rows[0]["PURCHSE_CANCAL_STATUS"].ToString() == "")
            {
                if (ddlPurchase.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString()) != null)
                {
                    ddlPurchase.ClearSelection();
                    ddlPurchase.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lst = new ListItem(dtCategoryById.Rows[0]["PURCHS_LEDGER"].ToString(), dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString());
                ddlPurchase.Items.Insert(1, lst);

                SortDDL(ref this.ddlPurchase);
                ddlPurchase.ClearSelection();
                ddlPurchase.Items.FindByValue(dtCategoryById.Rows[0]["CTGRY_PRCHS_LDGR_ID"].ToString()).Selected = true;
            }

        }

        int intStatus = Convert.ToInt32(dtCategoryById.Rows[0]["CTGRY_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            int intCommodityMaintndOffice = Convert.ToInt32(dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"]);
            //==1 means current corporate office is a commodity concept maintained corporate office
            if (intCommodityMaintndOffice == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCodeOpen", "CategoryCodeOpen();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "CategoryCodeClose", "CategoryCodeClose();", true);
            }
        }
    }


    //for sorting drop down
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


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
    public void LoadLedgers()
    {
        clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
        clsEntityCategory objEntityCategory = new clsEntityCategory();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCategory.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCategory.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityCategory.NatureSts = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income)-1;
        DataTable dtLedger = objBusinessLayerCategory.ReadLedgers(objEntityCategory);
        if (dtLedger.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtLedger;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");

        objEntityCategory.NatureSts = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense)-1;
        DataTable dtLedger1 = objBusinessLayerCategory.ReadLedgers(objEntityCategory);
        if (dtLedger1.Rows.Count > 0)
        {
            ddlPurchase.DataSource = dtLedger1;
            ddlPurchase.DataTextField = "LDGR_NAME";
            ddlPurchase.DataValueField = "LDGR_ID";
            ddlPurchase.DataBind();
        }
        ddlPurchase.Items.Insert(0, "--SELECT LEDGER--");
    }
    [WebMethod]
    public static string[] changeProdCtgry(string strLikeEmployee, int orgID, int corptID, int Product_Ctgryd, string EditId)
    {
        List<string> Employees = new List<string>();
        clsBusinessLayerCategory objBusinessLayerCategory = new clsBusinessLayerCategory();
        clsEntityCategory objEntityCategory = new clsEntityCategory();       
        objEntityCategory.Corp_Id = Convert.ToInt32(corptID);
        objEntityCategory.Org_Id = Convert.ToInt32(orgID);
        //if category type is sub then load main
        if (Convert.ToInt32(Product_Ctgryd) == Convert.ToInt32(Category_Type.Sub_Category))
            objEntityCategory.CategoryType_Id = Convert.ToInt32(Category_Type.Main_Category);

        //if category type is small then load sub categories
        if (Convert.ToInt32(Product_Ctgryd) == Convert.ToInt32(Category_Type.Small_Category))
            objEntityCategory.CategoryType_Id = Convert.ToInt32(Category_Type.Sub_Category);

        //if category type is least then load small categories
        if (Convert.ToInt32(Product_Ctgryd) == Convert.ToInt32(Category_Type.Least_Category))
            objEntityCategory.CategoryType_Id = Convert.ToInt32(Category_Type.Small_Category);

        objEntityCategory.Cancel_Reason=strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCategory.Read_Main_Category(objEntityCategory);
        string RemName = "";
        if (EditId != null && EditId != "")
        {
            clsEntityCategory objEntCategory = new clsEntityCategory();
            objEntCategory.Category_Id = Convert.ToInt32(EditId);
            DataTable dtCat = objBusinessLayerCategory.ReadCategoryById(objEntCategory);
            if (dtCat.Rows.Count != 0)
            {
               RemName = dtCat.Rows[0]["CTGRY_NAME"].ToString();
            }
        }
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            if (RemName != dtEmployess.Rows[intRowCount]["CTGRY_NAME"].ToString())
            {
                Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CTGRY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CTGRY_NAME"].ToString()));
            }
        }
        return Employees.ToArray();
    }
}