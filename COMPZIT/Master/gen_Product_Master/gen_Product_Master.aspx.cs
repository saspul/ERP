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
using CL_Compzit;
using System.Collections;
using System.Web.Services;
// CREATED BY:EVM-0001
// CREATED DATE:10/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Product_Master_gen_Product_Master : System.Web.UI.Page
{
    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["PRCHS"] != null || Request.QueryString["RFGP"] != null)
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";
    //    }
    //    else
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
    //    }
    //}
    //Creating objects for businesslayer
    clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Assigning  Key actions  . 
            txtProductName.Attributes.Add("onkeypress", "return isTag(event)");
            txtProductName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            txtShortName.Attributes.Add("onkeypress", "return isTag(event)");
            txtShortName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            txtProductCode.Attributes.Add("onkeypress", "return isTag(event)");
            txtProductCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            txtExternalAppCode.Attributes.Add("onkeypress", "return isTag(event)");
            txtExternalAppCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");

            txtProductDescription.Attributes.Add("onchange", "IncrmntConfrmCounter()");

            txtCostPrice.Attributes.Add("onkeydown", "return isNumber(event)");
            txtCostPrice.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            //txtPremiseName.Attributes.Add("onkeypress", "return isTag(event)");

            ddlProductGroup.Attributes.Add("onkeypress", "return DisableEnter(event)");
            //ddlProductGroup.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlProductBrand.Attributes.Add("onkeypress", "return DisableEnter(event)");
            ddlProductBrand.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlCountry.Attributes.Add("onkeypress", "return DisableEnter(event)");
            ddlCountry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlDivision.Attributes.Add("onkeypress", "return DisableEnter(event)");
            ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlMainCategory.Attributes.Add("onkeypress", "return DisableEnter(event)");
            //ddlMainCategory.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlSubCategoryt.Attributes.Add("onkeypress", "return DisableEnter(event)");
            //ddlSubCategoryt.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlSmallCategory.Attributes.Add("onkeypress", "return DisableEnter(event)");
            //ddlSmallCategory.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlLeastCategory.Attributes.Add("onkeypress", "return DisableEnter(event)");
            //ddlLeastCategory.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlTax.Attributes.Add("onkeypress", "return DisableEnter(event)");
            ddlTax.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxInclusiveExclusiveTax.Attributes.Add("onkeypress", "return DisableEnter(event)");
            cbxInclusiveExclusiveTax.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");


            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,  
                                                           clsCommonLibrary.CORP_GLOBAL.GN_ITM_CD_GENERATE,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            hiddenTaxEnabled.Value = "0";//tax not enabled
            hiddenMoneyDecCount.Value = "1";
            hiddenPrdctCodeGenerate.Value = "1";//automatic
            if (dtCorpDetail.Rows.Count > 0)
            {
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    hiddenTaxEnabled.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                }

                if (dtCorpDetail.Rows[0]["GN_ITM_CD_GENERATE"].ToString() != "")
                {
                    hiddenPrdctCodeGenerate.Value = dtCorpDetail.Rows[0]["GN_ITM_CD_GENERATE"].ToString();
                }
                if (dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString() != "")
                {
                    hiddenMoneyDecCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                }
            }

            if (hiddenTaxEnabled.Value == "0")//tax not enabled
            {
                divTax.Visible = false;
                divTax1.Visible = false;
            }
            else
            {
                divTax.Visible = true;//tax  enabled
                divTax1.Visible = true;//tax  enabled

            }
            HiddenFieldcbxSale.Value = "1";
            HiddenFieldcbxStock.Value = "1";
           
            txtProductName.Focus();

            //    when editing 
            if (Request.QueryString["Id"] != null)
            {
                Product_Load();
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId,intCorpId);
                HiddenFieldProdId.Value = strId;
                lblEntry.InnerText = "Edit Product";
                lblEntryB.InnerText = "Edit Product";
                if (hiddenPrdctCodeGenerate.Value == "1")//automatic
                {
                    txtProductCode.Enabled = false;
                }
                else
                {
                    txtProductCode.Enabled = true;//manual

                }
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

         //    when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                Product_Load();
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldProdId.Value = strId;
                View(strId, intCorpId);

                lblEntry.InnerText = "View Product";
                lblEntryB.InnerText = "View Product";

                //--DISABLING
                txtProductName.Enabled = false;
                txtShortName.Enabled = false;
                ddlProductGroup.Enabled = false;
                ddlProductBrand.Enabled = false;
                ddlCountry.Enabled = false;
                ddlDivision.Enabled = false;
                ddlMainCategory.Enabled = false;
                ddlSubCategoryt.Enabled = false;
                ddlSmallCategory.Enabled = false;
                ddlLeastCategory.Enabled = false;
                txtProductCode.Enabled = false;
                txtExternalAppCode.Enabled = false;
                txtCostPrice.Enabled = false;
                txtProductDescription.Enabled = false;
                if (hiddenTaxEnabled.Value == "1")//tax  enabled
                {
                    ddlTax.Enabled = false;
                    cbxInclusiveExclusiveTax.Disabled = true;
                
                }
                cbxStatus.Disabled = true;
                cbxStock.Disabled = true;
                cbxSale.Disabled = true;


                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                HiddenFieldProdId.Value = "";
                lblEntry.InnerText = "Add Product";
                lblEntryB.InnerText = "Add Product";
                Product_Load();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                if (hiddenPrdctCodeGenerate.Value == "1")//automatic
                {
                    divPrdctCode.Visible = false;
                }
                else
                {
                    divPrdctCode.Visible = true;//manual

                }
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
            HiddenChkMode.Value = "0";
            if (Request.QueryString["PRCHS"] != null)
            {
                divList.Visible = false;
                btnUpdate.Visible = false;
                btnUpdate.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = true;
                btnCancel.Visible = false;
                btnUpdateF.Visible = false;
                btnUpdateF.Visible = false;
                btnAddF.Visible = false;
                btnAddCloseF.Visible = true;
                btnCancelF.Visible = false;
                HiddenChkMode.Value = "2";
                cbxStock.Disabled = true;
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else if (Request.QueryString["RFGP"] != null)
            {
                divList.Visible = false;
                btnUpdate.Visible = false;
                btnUpdate.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = true;
                btnCancel.Visible = false;
                btnUpdateF.Visible = false;
                btnUpdateF.Visible = false;
                btnAddF.Visible = false;
                btnAddCloseF.Visible = true;
                btnCancelF.Visible = false;
                HiddenChkMode.Value = "1";
                cbxSale.Disabled = true;
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

        }

    }


    //Method for assigning  values to drop down list for Small ,Sub,Least Category to the dropdown list
    public DataTable Categorys_Load(int intCategoryTypId, int intParentId)
    {
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProduct.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityProduct.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityProduct.CategoryType_Id = intCategoryTypId;
        objEntityProduct.MainCategoryId = intParentId;
        DataTable dtCategorys = objBusinessLayerProduct.ReadCategorys(objEntityProduct);
        return dtCategorys;
    }

    //Method for assigning  values to drop down list for Group,Brand,Division,MainCategory,Country,Tax to the dropdown list
    public void Product_Load()
    {
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProduct.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityProduct.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityProduct.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtGroup = objBusinessLayerProduct.ReadProductGroup(objEntityProduct);
        DataTable dtBrand = objBusinessLayerProduct.ReadProductBrand(objEntityProduct);
        DataTable dtDivision = objBusinessLayerProduct.ReadDivision(objEntityProduct);
        DataTable dtMainCategory = objBusinessLayerProduct.ReadMainCategory(objEntityProduct);
        DataTable dtCountry = objBusinessLayerProduct.ReadCountry();
        DataTable dtTax = objBusinessLayerProduct.ReadTax(objEntityProduct);
        DataTable dtunit = objBusinessLayerProduct.ReadUnitOfMeasure(objEntityProduct);

        //COUNTRY
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);
        ddlCountry.Items.Insert(0, "--SELECT COUNTRY--");
        for (int i = 0; i < dtCountry.Rows.Count; i++)
        {
            ListItem lstaLs = new ListItem(dtCountry.Rows[i]["CNTRY_NAME"].ToString(), dtCountry.Rows[i]["CNTRY_ID"].ToString());
            if (dtCountry.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
            {
                lstaLs.Attributes["data-imagecss"] = "flag ad";
                lstaLs.Attributes["title"] = lstaLs.Text;
                lstaLs.Attributes["data-image"] =  strImagePath + dtCountry.Rows[i]["CNTRY_FLAG_ICON_NAME"].ToString();
            }
            ddlCountry.Items.Insert(i+1, lstaLs);
        }


        //group
        ddlProductGroup.DataSource = dtGroup;

        ddlProductGroup.DataTextField = "PRDTGP_NAME";
        ddlProductGroup.DataValueField = "PRDTGP_ID";
        ddlProductGroup.DataBind();
        ddlProductGroup.Items.Insert(0, "--SELECT GROUP--");

        //brand
        ddlProductBrand.DataSource = dtBrand;

        ddlProductBrand.DataTextField = "PRDTBRND_NAME";
        ddlProductBrand.DataValueField = "PRDTBRND_ID";
        ddlProductBrand.DataBind();
        ddlProductBrand.Items.Insert(0, "--SELECT BRAND--");
        //Division
        ddlDivision.DataSource = dtDivision;

        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

        //Main Category
        ddlMainCategory.DataSource = dtMainCategory;

        ddlMainCategory.DataTextField = "CTGRY_NAME";
        ddlMainCategory.DataValueField = "CTGRY_ID";
        ddlMainCategory.DataBind();   
        ddlMainCategory.Items.Insert(0, "--SELECT MAIN CATEGORY--");
        //TAX
        ddlTax.DataSource = dtTax;

        ddlTax.DataTextField = "TAX_NAME";
        ddlTax.DataValueField = "TAX_ID";
        ddlTax.DataBind();
        ddlTax.Items.Insert(0, "--SELECT TAX--");

        ddlUnit.DataSource = dtunit;
        ddlUnit.DataTextField = "UOM_NAME";
        ddlUnit.DataValueField = "UOM_ID";
        ddlUnit.DataBind();
        ddlUnit.Items.Insert(0, "--SELECT UNIT--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        try
        {
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProduct.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityProduct.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityProduct.Product_name = txtProductName.Text.ToUpper().Trim();
        objEntityProduct.Product_ShortName = txtShortName.Text.ToUpper().Trim();
        objEntityProduct.Product_description = txtProductDescription.Text.Trim();
        objEntityProduct.Product_GrpId = Convert.ToInt32(ddlProductGroup.SelectedItem.Value.ToString());
        if (ddlProductBrand.SelectedItem.Value.ToString() != "--SELECT BRAND--")
        {
            objEntityProduct.ProductBrand = Convert.ToInt32(ddlProductBrand.SelectedItem.Value.ToString());
        }
        if (ddlCountry.SelectedItem.Value.ToString() != "--SELECT COUNTRY--")
        {
            objEntityProduct.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value.ToString());
        }
        if (ddlUnit.SelectedItem.Value.ToString() != "--SELECT UNIT--")
        {
            objEntityProduct.Unit = Convert.ToInt32(ddlUnit.SelectedItem.Value.ToString());
        }
        objEntityProduct.DivsionId = Convert.ToInt32(ddlDivision.SelectedItem.Value.ToString());
        objEntityProduct.Product_MainCtgryId = Convert.ToInt32(ddlMainCategory.SelectedItem.Value.ToString());

        if (HiddenFieldSubC.Value != null && HiddenFieldSubC.Value != "" && HiddenFieldSubC.Value != "--SELECT SUB CATEGORY--")
        {
            objEntityProduct.Product_SubCtgryId = Convert.ToInt32(HiddenFieldSubC.Value);

            if (HiddenFieldSmaC.Value != null && HiddenFieldSmaC.Value != "" && HiddenFieldSmaC.Value != "--SELECT SMALL CATEGORY--")
            {
                objEntityProduct.Product_SmallCtgryId = Convert.ToInt32(HiddenFieldSmaC.Value);

                if (HiddenFieldLeaC.Value != null && HiddenFieldLeaC.Value != "" && HiddenFieldLeaC.Value != "--SELECT LEAST CATEGORY--")
                {
                    objEntityProduct.Product_LeastCtgryId = Convert.ToInt32(HiddenFieldLeaC.Value);
                }

            }

        }




        if (txtExternalAppCode.Text.Trim() != "")
        {

            objEntityProduct.ExternalAppCode = txtExternalAppCode.Text.ToUpper().Trim();

        }

        if (hiddenPrdctCodeGenerate.Value == "2")
        {

            objEntityProduct.Product_Code = txtProductCode.Text.ToUpper().Trim();

        }
        if (txtCostPrice.Text != "")
        {

            objEntityProduct.ProductCostPrice = Convert.ToDecimal(txtCostPrice.Text);

        }
        if (hiddenTaxEnabled.Value == "1")
        {
            if (ddlTax.SelectedItem.Value.ToString() != "--SELECT TAX--")
            {
                objEntityProduct.Product_TaxId = Convert.ToInt32(ddlTax.SelectedItem.Value.ToString());
            }

            if (cbxInclusiveExclusiveTax.Checked == true)
            {//inclusive
                objEntityProduct.Product_TaxMode = 1;
            }
            // checkbox not checked
            else
            {//exclusive
                objEntityProduct.Product_TaxMode = 2;
            }
        }


        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityProduct.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityProduct.Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityProduct.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityProduct.D_Date = System.DateTime.Now;

        if (HiddenChkMode.Value == "1")
        {
            objEntityProduct.SaleableSts = 1;
        }
        else
        {           
          objEntityProduct.SaleableSts = Convert.ToInt32(HiddenFieldcbxSale.Value);
        }
        if (HiddenChkMode.Value == "2")
        {
            objEntityProduct.StockableSts = 1;
        }
        else
        {            
          objEntityProduct.StockableSts = Convert.ToInt32(HiddenFieldcbxStock.Value); ;
        }

        if (cbxNameToDesc.Checked == true)
        {
            objEntityProduct.NametoDescrptnSts = 1;
        }
        if (cbxNametoRmrk.Checked == true)
        {
            objEntityProduct.NametoRemarkSts = 1;
        }


        string strNameCount = "0";
        strNameCount = objBusinessLayerProduct.CheckProductName(objEntityProduct);
        string strShortNameCount = "0";
        if (objEntityProduct.Product_ShortName != "")
        {
            strShortNameCount = objBusinessLayerProduct.CheckProductShortName(objEntityProduct);

        }
        string strPrdctCodeCount = "0";
        if (hiddenPrdctCodeGenerate.Value == "2")
        {
            strPrdctCodeCount = objBusinessLayerProduct.CheckProductCode(objEntityProduct);
        }
        string strPrdctExtrnlAppCodeCount = "0";
        if (objEntityProduct.ExternalAppCode != "")
        {
            strPrdctExtrnlAppCodeCount = objBusinessLayerProduct.CheckProductExternalCode(objEntityProduct);
        }

        if (strNameCount == "0" && strShortNameCount == "0" && strPrdctCodeCount == "0" && strPrdctExtrnlAppCodeCount == "0")
        {
           objBusinessLayerProduct.AddProductDetils(objEntityProduct);


           int ProductId = objEntityProduct.Product_Id;
            if (Request.QueryString["PRCHS"] == "PRDCT")
            {
                string StrRow = "";
                if (Request.QueryString["ROW"] != "")
                {
                    StrRow = Request.QueryString["ROW"];
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedPurchase", "PassSavedPurchase(" + ProductId + "," + StrRow + ");", true);
            }
            else if (Request.QueryString["PRCHS"] == "PRDCTROW")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedProductId", "PassSavedProductId('" + objEntityProduct.Product_Id + "','" + objEntityProduct.Product_name + "','" + Request.QueryString["ROW"].ToString() + "');", true);
            }
            else if (Request.QueryString["RFGP"] == "PRDT")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedProduct", "PassSavedProduct(" + ProductId + "," + Request.QueryString["NUM"] + ");", true);
            }
            else
            {

                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                {
                    Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
                {
                    Response.Redirect("gen_Product_MasterList.aspx?InsUpd=Ins");
                }
            }


        }
        else
        {



            if (strPrdctExtrnlAppCodeCount != "0")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationExternalAppCode", "DuplicationExternalAppCode();", true);
                txtExternalAppCode.Focus();
            }
            if (strPrdctCodeCount != "0")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                txtProductCode.Focus();
            }

            if (strShortNameCount != "0")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationShortName", "DuplicationShortName();", true);
                txtShortName.Focus();
            }
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtProductName.Focus();
            }
            HiddenFieldBindDDl.Value = "1";
            ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
        }
        //----------------
        ////Checking is there table have any name like this
        //string strNameCount = objBusinessLayerProduct.CheckProductName(objEntityProduct);
        ////If there is no name like this on table.    
        //if (strNameCount == "0")
        //{
        //    if (objEntityProduct.Product_ShortName != "")
        //    {
        //        string strShortNameCount = objBusinessLayerProduct.CheckProductShortName(objEntityProduct);
        //        if (strShortNameCount == "0")
        //        {
        //            if (hiddenPrdctCodeGenerate.Value == "2")
        //            {
        //                string strPrdctCodeCount = objBusinessLayerProduct.CheckProductCode(objEntityProduct);
        //                if (strPrdctCodeCount == "0")
        //                {
        //                    if (objEntityProduct.ExternalAppCode != "")
        //                    {
        //                        string strPrdctExtrnlAppCodeCount = objBusinessLayerProduct.CheckProductExternalCode(objEntityProduct);
        //                        if (strPrdctExtrnlAppCodeCount == "0")
        //                        {
        //                            objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                            Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");
        //                        }
        //                        else
        //                        {
        //                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationExternalAppCode", "DuplicationExternalAppCode();", true);
        //                            txtProductCode.Focus();

        //                        }
        //                    }
        //                    else
        //                    {
        //                        objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                        Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");

        //                    }
        //                }
        //                else
        //                {

        //                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
        //                    txtProductCode.Focus();


        //                }
        //            }
        //            else
        //            {

        //                if (objEntityProduct.ExternalAppCode != "")
        //                {
        //                    string strPrdctExtrnlAppCodeCount = objBusinessLayerProduct.CheckProductExternalCode(objEntityProduct);
        //                    if (strPrdctExtrnlAppCodeCount == "0")
        //                    {
        //                        objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                        Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationExternalAppCode", "DuplicationExternalAppCode();", true);
        //                        txtProductCode.Focus();

        //                    }
        //                }
        //                else
        //                {
        //                    objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                    Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");

        //                }


        //            }
        //        }
        //        else
        //        {

        //            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationShortName", "DuplicationShortName();", true);
        //            txtShortName.Focus();

        //        }
        //    }
        //    else
        //    {
        //        if (hiddenPrdctCodeGenerate.Value == "2")
        //        {
        //            string strPrdctCodeCount = objBusinessLayerProduct.CheckProductCode(objEntityProduct);
        //            if (strPrdctCodeCount == "0")
        //            {
        //                if (objEntityProduct.ExternalAppCode != "")
        //                {
        //                    string strPrdctExtrnlAppCodeCount = objBusinessLayerProduct.CheckProductExternalCode(objEntityProduct);
        //                    if (strPrdctExtrnlAppCodeCount == "0")
        //                    {
        //                        objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                        Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationExternalAppCode", "DuplicationExternalAppCode();", true);
        //                        txtProductCode.Focus();

        //                    }
        //                }
        //                else
        //                {
        //                    objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                    Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");

        //                }
        //            }
        //            else
        //            {

        //                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
        //                txtProductCode.Focus();


        //            }
        //        }
        //        else
        //        {

        //            if (objEntityProduct.ExternalAppCode != "")
        //            {
        //                string strPrdctExtrnlAppCodeCount = objBusinessLayerProduct.CheckProductExternalCode(objEntityProduct);
        //                if (strPrdctExtrnlAppCodeCount == "0")
        //                {
        //                    objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                    Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationExternalAppCode", "DuplicationExternalAppCode();", true);
        //                    txtProductCode.Focus();

        //                }
        //            }
        //            else
        //            {
        //                objBusinessLayerProduct.AddProductDetils(objEntityProduct);
        //                Response.Redirect("gen_Product_Master.aspx?InsUpd=Ins");

        //            }


        //        }

        //    }
        //}
        ////If have
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
        //    txtProductName.Focus();
        //}
           }
    catch
    {
        HiddenFieldBindDDl.Value = "1";
        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
    }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        
        try
        {
        if (Request.QueryString["Id"] != null)
        {
            clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityProduct.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityProduct.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityProduct.Product_name = txtProductName.Text.ToUpper().Trim();
            objEntityProduct.Product_ShortName = txtShortName.Text.ToUpper().Trim();
            objEntityProduct.Product_description = txtProductDescription.Text.Trim();
            objEntityProduct.Product_GrpId = Convert.ToInt32(ddlProductGroup.SelectedItem.Value.ToString());
            if (ddlProductBrand.SelectedItem.Value.ToString() != "--SELECT BRAND--")
            {
                objEntityProduct.ProductBrand = Convert.ToInt32(ddlProductBrand.SelectedItem.Value.ToString());
            }
            if (ddlCountry.SelectedItem.Value.ToString() != "--SELECT COUNTRY--")
            {
                objEntityProduct.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value.ToString());
            }
            if (ddlUnit.SelectedItem.Value.ToString() != "--SELECT UNIT--")
            {
                objEntityProduct.Unit = Convert.ToInt32(ddlUnit.SelectedItem.Value.ToString());
            }
            objEntityProduct.DivsionId = Convert.ToInt32(ddlDivision.SelectedItem.Value.ToString());
            objEntityProduct.Product_MainCtgryId = Convert.ToInt32(ddlMainCategory.SelectedItem.Value.ToString());

            if (HiddenFieldSubC.Value != null && HiddenFieldSubC.Value != "" && HiddenFieldSubC.Value != "--SELECT SUB CATEGORY--")
            {
                objEntityProduct.Product_SubCtgryId = Convert.ToInt32(HiddenFieldSubC.Value);

                if (HiddenFieldSmaC.Value != null && HiddenFieldSmaC.Value != "" && HiddenFieldSmaC.Value != "--SELECT SMALL CATEGORY--")
                {
                    objEntityProduct.Product_SmallCtgryId = Convert.ToInt32(HiddenFieldSmaC.Value);

                    if (HiddenFieldLeaC.Value != null && HiddenFieldLeaC.Value != "" && HiddenFieldLeaC.Value != "--SELECT LEAST CATEGORY--")
                    {
                        objEntityProduct.Product_LeastCtgryId = Convert.ToInt32(HiddenFieldLeaC.Value);
                    }

                }

            }

            if (txtExternalAppCode.Text.Trim() != "")
            {

                objEntityProduct.ExternalAppCode = txtExternalAppCode.Text.ToUpper().Trim();

            }

              objEntityProduct.Product_Code = txtProductCode.Text.ToUpper().Trim();

            
            if (txtCostPrice.Text != "")
            {

                objEntityProduct.ProductCostPrice = Convert.ToDecimal(txtCostPrice.Text);

            }
            if (hiddenTaxEnabled.Value == "1")
            {
                if (ddlTax.SelectedItem.Value.ToString() != "--SELECT TAX--")
                {
                    objEntityProduct.Product_TaxId = Convert.ToInt32(ddlTax.SelectedItem.Value.ToString());
                }

                if (cbxInclusiveExclusiveTax.Checked == true)
                {//inclusive
                    objEntityProduct.Product_TaxMode = 1;
                }
                // checkbox not checked
                else
                {//exclusive
                    objEntityProduct.Product_TaxMode = 2;
                }
            }


            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityProduct.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityProduct.Status = 0;
            }


            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityProduct.Product_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityProduct.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityProduct.D_Date = System.DateTime.Now;       
            objEntityProduct.SaleableSts = Convert.ToInt32(HiddenFieldcbxSale.Value);
            objEntityProduct.StockableSts = Convert.ToInt32(HiddenFieldcbxStock.Value);
            if (cbxNameToDesc.Checked == true)
            {
                objEntityProduct.NametoDescrptnSts = 1;
            }
            if (cbxNametoRmrk.Checked == true)
            {
                objEntityProduct.NametoRemarkSts = 1;
            }

            string strNameCount = "0";
            strNameCount = objBusinessLayerProduct.CheckProductName(objEntityProduct);
            string strShortNameCount = "0";
            if (objEntityProduct.Product_ShortName != "")
            {
                strShortNameCount = objBusinessLayerProduct.CheckProductShortName(objEntityProduct);

            }
            string strPrdctCodeCount = "0";
            if (hiddenPrdctCodeGenerate.Value == "2")
            {
                strPrdctCodeCount = objBusinessLayerProduct.CheckProductCode(objEntityProduct);
            }
            string strPrdctExtrnlAppCodeCount = "0";
            if (objEntityProduct.ExternalAppCode != "")
            {
                strPrdctExtrnlAppCodeCount = objBusinessLayerProduct.CheckProductExternalCode(objEntityProduct);
            }

            if (strNameCount == "0" && strShortNameCount == "0" && strPrdctCodeCount == "0" && strPrdctExtrnlAppCodeCount == "0")
            {


                 DataTable dtComplaintDetail = objBusinessLayerProduct.ReadProductById(objEntityProduct);
                 if (dtComplaintDetail.Rows.Count > 0)
                 {
                     if (dtComplaintDetail.Rows[0]["PRDT_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["PRDT_CNCL_USR_ID"].ToString() == null)
                     {
                         objBusinessLayerProduct.UpdateProductDetils(objEntityProduct);
                         if (clickedButton.ID == "btnUpdate")
                         {
                             Response.Redirect("gen_Product_Master.aspx?InsUpd=Upd");
                         }
                         else if (clickedButton.ID == "btnUpdateClose")
                         {
                             Response.Redirect("gen_Product_MasterList.aspx?InsUpd=Upd");
                         }
                     }
                     else
                     {
                         Response.Redirect("gen_Product_MasterList.aspx?InsUpd=AlCncl");
                     }
                 }
            
            }
            else
            {



                if (strPrdctExtrnlAppCodeCount != "0")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationExternalAppCode", "DuplicationExternalAppCode();", true);
                    txtExternalAppCode.Focus();
                }
                if (strPrdctCodeCount != "0")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    txtProductCode.Focus();
                }

                if (strShortNameCount != "0")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationShortName", "DuplicationShortName();", true);
                    txtShortName.Focus();
                }
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtProductName.Focus();
                }
                HiddenFieldBindDDl.Value = "1";
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
       
        }
        }
    catch
    {
        HiddenFieldBindDDl.Value = "1";
        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
    }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        objEntityProduct.Corp_Id = intCorpId;
        objEntityProduct.Product_Id = Convert.ToInt32(strP_Id);
        DataTable dtProductById = objBusinessLayerProduct.ReadProductById(objEntityProduct);
        if (dtProductById.Rows.Count > 0)
        {
            ////After fetch Deaprtment details in datatable,we need to differentiate.
            txtProductName.Text = dtProductById.Rows[0]["PRDT_NAME"].ToString();
            if (dtProductById.Rows[0]["PRDT_SHORT_NAME"].ToString() != "")
            {
                txtShortName.Text = dtProductById.Rows[0]["PRDT_SHORT_NAME"].ToString();
            }

            //ie IF  group IS ACTIVE
            if (dtProductById.Rows[0]["PRDTGP_STATUS"].ToString() == "1" && dtProductById.Rows[0]["PRDTGP_CNCL_USR_ID"].ToString() == "")
            {
                ddlProductGroup.Items.FindByValue(dtProductById.Rows[0]["PRDTGP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtProductById.Rows[0]["PRDTGP_NAME"].ToString(), dtProductById.Rows[0]["PRDTGP_ID"].ToString());
                ddlProductGroup.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProductGroup);

                ddlProductGroup.Items.FindByValue(dtProductById.Rows[0]["PRDTGP_ID"].ToString()).Selected = true;
            }
            if (dtProductById.Rows[0]["PRDTBRND_ID"] != DBNull.Value)
            {
                //ie IF  brand IS ACTIVE
                if (dtProductById.Rows[0]["PRDTBRND_STATUS"].ToString() == "1" && dtProductById.Rows[0]["PRDTBRND_CNCL_USR_ID"].ToString() == "")
                {
                    ddlProductBrand.Items.FindByValue(dtProductById.Rows[0]["PRDTBRND_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstBrand = new ListItem(dtProductById.Rows[0]["PRDTBRND_NAME"].ToString(), dtProductById.Rows[0]["PRDTBRND_ID"].ToString());
                    ddlProductBrand.Items.Insert(1, lstBrand);

                    SortDDL(ref this.ddlProductBrand);

                    ddlProductBrand.Items.FindByValue(dtProductById.Rows[0]["PRDTBRND_ID"].ToString()).Selected = true;
                }
            }
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);
            if (dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"] != DBNull.Value)
            {
                //ie IF  Country IS ACTIVE
                if (dtProductById.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtProductById.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
                {
                    ddlCountry.Items.FindByValue(dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstaLs = new ListItem(dtProductById.Rows[0]["CNTRY_NAME"].ToString(), dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"].ToString());
                    if (dtProductById.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
                    {
                        lstaLs.Attributes["data-imagecss"] = "flag ad";
                        lstaLs.Attributes["title"] = lstaLs.Text;
                        lstaLs.Attributes["data-image"] = strImagePath + dtProductById.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString();
                    }
                    ddlCountry.Items.Insert(1, lstaLs);
                    SortDDL(ref this.ddlCountry);
                    ddlCountry.Items.FindByValue(dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"].ToString()).Selected = true;
                }
            }





            //ie IF  Division IS ACTIVE
            if (dtProductById.Rows[0]["CPRDIV_STATUS"].ToString() == "1" && dtProductById.Rows[0]["CPRDIV_CNCL_USR_ID"].ToString() == "")
            {
                ddlDivision.Items.FindByValue(dtProductById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstaDiv = new ListItem(dtProductById.Rows[0]["CPRDIV_NAME"].ToString(), dtProductById.Rows[0]["CPRDIV_ID"].ToString());
                ddlDivision.Items.Insert(1, lstaDiv);

                SortDDL(ref this.ddlDivision);

                ddlDivision.Items.FindByValue(dtProductById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
            }
            //ie IF  Main Category IS ACTIVE
            if (dtProductById.Rows[0]["MAINCATSTATUS"].ToString() == "1" && dtProductById.Rows[0]["MAINCATCNCLUSRID"].ToString() == "")
            {
                ddlMainCategory.Items.FindByValue(dtProductById.Rows[0]["PRDT_MN_CTGRY_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstaMn = new ListItem(dtProductById.Rows[0]["MAINCAT"].ToString(), dtProductById.Rows[0]["PRDT_MN_CTGRY_ID"].ToString());
                ddlMainCategory.Items.Insert(1, lstaMn);

                SortDDL(ref this.ddlMainCategory);

                ddlMainCategory.Items.FindByValue(dtProductById.Rows[0]["PRDT_MN_CTGRY_ID"].ToString()).Selected = true;
            }
            if (dtProductById.Rows[0]["PRDT_SB_CTGRY_ID"].ToString() != "")
            {
                HiddenFieldSubC.Value = dtProductById.Rows[0]["PRDT_SB_CTGRY_ID"].ToString();
                ddlSubCategoryt.Text = dtProductById.Rows[0]["SUBCAT"].ToString();              
                if (dtProductById.Rows[0]["PRDT_SML_CTGRY_ID"].ToString() != "")
                {
                    HiddenFieldSmaC.Value = dtProductById.Rows[0]["PRDT_SML_CTGRY_ID"].ToString();
                    ddlSmallCategory.Text = dtProductById.Rows[0]["SMALLCAT"].ToString();
                    if (dtProductById.Rows[0]["PRDT_LST_CTGRY_ID"].ToString() != "")
                    {
                        HiddenFieldLeaC.Value = dtProductById.Rows[0]["PRDT_LST_CTGRY_ID"].ToString();
                        ddlLeastCategory.Text = dtProductById.Rows[0]["LEASTCAT"].ToString();
                    }
                }
            }



            if (dtProductById.Rows[0]["EXTRNL_APP_CODE"].ToString() != "")
            {
                txtExternalAppCode.Text = dtProductById.Rows[0]["EXTRNL_APP_CODE"].ToString();
            }

            txtProductCode.Text = dtProductById.Rows[0]["PRDT_CODE"].ToString();
            txtCostPrice.Text = dtProductById.Rows[0]["PRDT_COST_PRICE"].ToString();

            if (hiddenTaxEnabled.Value == "1")//tax  enabled
            {
                if (dtProductById.Rows[0]["TAX_ID"].ToString() != "")
                {

                    if (dtProductById.Rows[0]["TAX_STATUS"].ToString() == "1" && dtProductById.Rows[0]["TAX_CNCL_USR_ID"].ToString() == "")
                    {
                        ddlTax.Items.FindByValue(dtProductById.Rows[0]["TAX_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstax = new ListItem(dtProductById.Rows[0]["TAX_NAME"].ToString(), dtProductById.Rows[0]["TAX_ID"].ToString());
                        ddlTax.Items.Insert(1, lstax);

                        SortDDL(ref this.ddlTax);

                        ddlTax.Items.FindByValue(dtProductById.Rows[0]["TAX_ID"].ToString()).Selected = true;
                    }

                    if (dtProductById.Rows[0]["PRDT_TX_MODE"].ToString() == "1")
                    {
                        cbxInclusiveExclusiveTax.Checked = true;
                    }
                    else
                    {
                        cbxInclusiveExclusiveTax.Checked = false;

                    }

                }
            }
            int intProductStatus = Convert.ToInt32(dtProductById.Rows[0]["PRDT_STATUS"]);
            if (intProductStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            if (dtProductById.Rows[0]["PRDT_SALEABLE_STS"].ToString() == "1")
            {
                HiddenFieldcbxSale.Value = "1";
            }
            else
            {
                HiddenFieldcbxSale.Value = "0";
            }
            if (dtProductById.Rows[0]["PRDT_STOCKABLE_STS"].ToString() == "1")
            {
                HiddenFieldcbxStock.Value = "1";
            }
            else
            {
                HiddenFieldcbxStock.Value = "0";
            }
            cbxNameToDesc.Disabled = true;
            cbxNametoRmrk.Disabled = true;
            ddlUnit.Enabled = false;
        }
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id,int intCorpId)
    { try
        {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        objEntityProduct.Corp_Id = intCorpId;
        objEntityProduct.Product_Id = Convert.ToInt32(strP_Id);
        DataTable dtProductById = objBusinessLayerProduct.ReadProductById(objEntityProduct);
        if (dtProductById.Rows.Count > 0)
        {
            ////After fetch Deaprtment details in datatable,we need to differentiate.
            txtProductName.Text = dtProductById.Rows[0]["PRDT_NAME"].ToString();
            txtProductDescription.Text = dtProductById.Rows[0]["PRDT_DESCRIPTION"].ToString();
            if (dtProductById.Rows[0]["PRDT_SHORT_NAME"].ToString() != "")
            {
                txtShortName.Text = dtProductById.Rows[0]["PRDT_SHORT_NAME"].ToString();
            }
            if (dtProductById.Rows[0]["UOM_ID"].ToString() != "")
            {
                if (dtProductById.Rows[0]["UOM_STATUS"].ToString() == "1" && dtProductById.Rows[0]["UOM_CNCL_USR_ID"].ToString() == "")
                {
                    ddlUnit.Items.FindByValue(dtProductById.Rows[0]["UOM_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProductById.Rows[0]["UOM_NAME"].ToString(), dtProductById.Rows[0]["UOM_ID"].ToString());
                    ddlUnit.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlUnit);

                    ddlUnit.Items.FindByValue(dtProductById.Rows[0]["UOM_ID"].ToString()).Selected = true;
                }
            }

            //ie IF  group IS ACTIVE
            if (dtProductById.Rows[0]["PRDTGP_STATUS"].ToString() == "1" && dtProductById.Rows[0]["PRDTGP_CNCL_USR_ID"].ToString() == "")
            {
                ddlProductGroup.Items.FindByValue(dtProductById.Rows[0]["PRDTGP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtProductById.Rows[0]["PRDTGP_NAME"].ToString(), dtProductById.Rows[0]["PRDTGP_ID"].ToString());
                ddlProductGroup.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProductGroup);

                ddlProductGroup.Items.FindByValue(dtProductById.Rows[0]["PRDTGP_ID"].ToString()).Selected = true;
            }
            if (dtProductById.Rows[0]["PRDTBRND_ID"] != DBNull.Value)
            {
                //ie IF  brand IS ACTIVE
                if (dtProductById.Rows[0]["PRDTBRND_STATUS"].ToString() == "1" && dtProductById.Rows[0]["PRDTBRND_CNCL_USR_ID"].ToString() == "")
                {
                    ddlProductBrand.Items.FindByValue(dtProductById.Rows[0]["PRDTBRND_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstBrand = new ListItem(dtProductById.Rows[0]["PRDTBRND_NAME"].ToString(), dtProductById.Rows[0]["PRDTBRND_ID"].ToString());
                    ddlProductBrand.Items.Insert(1, lstBrand);

                    SortDDL(ref this.ddlProductBrand);

                    ddlProductBrand.Items.FindByValue(dtProductById.Rows[0]["PRDTBRND_ID"].ToString()).Selected = true;
                }
            }
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.COUNTRY_ICON_IMAGES);
            if (dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"] != DBNull.Value)
            {
                //ie IF  Country IS ACTIVE
                if (dtProductById.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtProductById.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
                {
                    ddlCountry.Items.FindByValue(dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstaLs = new ListItem(dtProductById.Rows[0]["CNTRY_NAME"].ToString(), dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"].ToString());
                    if (dtProductById.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString() != "")
                    {
                        lstaLs.Attributes["data-imagecss"] = "flag ad";
                        lstaLs.Attributes["title"] = lstaLs.Text;
                        lstaLs.Attributes["data-image"] = strImagePath + dtProductById.Rows[0]["CNTRY_FLAG_ICON_NAME"].ToString();
                    }
                    ddlCountry.Items.Insert(1, lstaLs);
                    SortDDL(ref this.ddlCountry);
                    ddlCountry.Items.FindByValue(dtProductById.Rows[0]["PRDT_CNTRY_ORGIN"].ToString()).Selected = true;
                }
            }

            //ie IF  Division IS ACTIVE
            if (dtProductById.Rows[0]["CPRDIV_STATUS"].ToString() == "1" && dtProductById.Rows[0]["CPRDIV_CNCL_USR_ID"].ToString() == "")
            {
                ddlDivision.Items.FindByValue(dtProductById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstaDiv = new ListItem(dtProductById.Rows[0]["CPRDIV_NAME"].ToString(), dtProductById.Rows[0]["CPRDIV_ID"].ToString());
                ddlDivision.Items.Insert(1, lstaDiv);

                SortDDL(ref this.ddlDivision);

                ddlDivision.Items.FindByValue(dtProductById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
            }
            //ie IF  Main Category IS ACTIVE
            if (dtProductById.Rows[0]["MAINCATSTATUS"].ToString() == "1" && dtProductById.Rows[0]["MAINCATCNCLUSRID"].ToString() == "")
            {
                ddlMainCategory.Items.FindByValue(dtProductById.Rows[0]["PRDT_MN_CTGRY_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstaMn = new ListItem(dtProductById.Rows[0]["MAINCAT"].ToString(), dtProductById.Rows[0]["PRDT_MN_CTGRY_ID"].ToString());
                ddlMainCategory.Items.Insert(1, lstaMn);

                SortDDL(ref this.ddlMainCategory);

                ddlMainCategory.Items.FindByValue(dtProductById.Rows[0]["PRDT_MN_CTGRY_ID"].ToString()).Selected = true;
            }
            if (dtProductById.Rows[0]["PRDT_SB_CTGRY_ID"].ToString() != "")
            {
                HiddenFieldSubC.Value = dtProductById.Rows[0]["PRDT_SB_CTGRY_ID"].ToString();
                ddlSubCategoryt.Text = dtProductById.Rows[0]["SUBCAT"].ToString();
                if (dtProductById.Rows[0]["PRDT_SML_CTGRY_ID"].ToString() != "")
                {
                    HiddenFieldSmaC.Value = dtProductById.Rows[0]["PRDT_SML_CTGRY_ID"].ToString();
                    ddlSmallCategory.Text = dtProductById.Rows[0]["SMALLCAT"].ToString();
                    if (dtProductById.Rows[0]["PRDT_LST_CTGRY_ID"].ToString() != "")
                    {
                        HiddenFieldLeaC.Value = dtProductById.Rows[0]["PRDT_LST_CTGRY_ID"].ToString();
                        ddlLeastCategory.Text = dtProductById.Rows[0]["LEASTCAT"].ToString();
                    }
                }
            }
            if (dtProductById.Rows[0]["PRDT_SALEABLE_STS"].ToString() == "1")
            {
                HiddenFieldcbxSale.Value = "1";
            }
            else
            {
                HiddenFieldcbxSale.Value = "0";
            }
            if (dtProductById.Rows[0]["PRDT_STOCKABLE_STS"].ToString() == "1")
            {
                HiddenFieldcbxStock.Value = "1";
            }
            else
            {
                HiddenFieldcbxStock.Value = "0";
            }
            if (dtProductById.Rows[0]["PRDCT_DISPLAY_NAME_DESC_STS"].ToString() == "1")
            {
                cbxNameToDesc.Checked = true;
            }
            else
            {
                cbxNameToDesc.Checked = false;
            }
            if (dtProductById.Rows[0]["PRDCT_DISPLAY_NAME_INVRMRK_STS"].ToString() == "1")
            {
                cbxNametoRmrk.Checked = true;
            }
            else
            {
                cbxNametoRmrk.Checked = false;
            }

            if (dtProductById.Rows[0]["EXTRNL_APP_CODE"].ToString() != "")
            {
                txtExternalAppCode.Text = dtProductById.Rows[0]["EXTRNL_APP_CODE"].ToString();
            }

            txtProductCode.Text = dtProductById.Rows[0]["PRDT_CODE"].ToString();
            txtCostPrice.Text = dtProductById.Rows[0]["PRDT_COST_PRICE"].ToString();

            if (hiddenTaxEnabled.Value == "1")//tax  enabled
            {
                if (dtProductById.Rows[0]["TAX_ID"].ToString() != "")
                {

                    if (dtProductById.Rows[0]["TAX_STATUS"].ToString() == "1" && dtProductById.Rows[0]["TAX_CNCL_USR_ID"].ToString() == "")
                    {
                        ddlTax.Items.FindByValue(dtProductById.Rows[0]["TAX_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstax = new ListItem(dtProductById.Rows[0]["TAX_NAME"].ToString(), dtProductById.Rows[0]["TAX_ID"].ToString());
                        ddlTax.Items.Insert(1, lstax);

                        SortDDL(ref this.ddlTax);

                        ddlTax.Items.FindByValue(dtProductById.Rows[0]["TAX_ID"].ToString()).Selected = true;
                    }

                    if (dtProductById.Rows[0]["PRDT_TX_MODE"].ToString() == "1")
                    {
                        cbxInclusiveExclusiveTax.Checked = true;
                    }
                    else
                    {
                        cbxInclusiveExclusiveTax.Checked = false;
                    
                    }

                }
            }
            int intProductStatus = Convert.ToInt32(dtProductById.Rows[0]["PRDT_STATUS"]);
            if (intProductStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        }
    catch
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
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
    [WebMethod]
    public static string[] changeSubC(string strLikeEmployee, int orgID, int corptID, int countryID)
    {
        List<string> Employees = new List<string>();
        clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();       
        objEntityProduct.Corp_Id = Convert.ToInt32(corptID);
        objEntityProduct.Org_Id = Convert.ToInt32(orgID);
        objEntityProduct.CategoryType_Id = 2;
        objEntityProduct.MainCategoryId = countryID;
        objEntityProduct.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerProduct.ReadCategorys(objEntityProduct);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CTGRY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CTGRY_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
    [WebMethod]
    public static string[] changeSmaC(string strLikeEmployee, int orgID, int corptID, int countryID)
    {
        List<string> Employees = new List<string>();
        clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        objEntityProduct.Corp_Id = Convert.ToInt32(corptID);
        objEntityProduct.Org_Id = Convert.ToInt32(orgID);
        objEntityProduct.CategoryType_Id = 3;
        objEntityProduct.MainCategoryId = countryID;
        objEntityProduct.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerProduct.ReadCategorys(objEntityProduct);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CTGRY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CTGRY_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
    [WebMethod]
    public static string[] changeLeaC(string strLikeEmployee, int orgID, int corptID, int countryID)
    {
        List<string> Employees = new List<string>();
        clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
        clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
        objEntityProduct.Corp_Id = Convert.ToInt32(corptID);
        objEntityProduct.Org_Id = Convert.ToInt32(orgID);
        objEntityProduct.CategoryType_Id = 4;
        objEntityProduct.MainCategoryId = countryID;
        objEntityProduct.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerProduct.ReadCategorys(objEntityProduct);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CTGRY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CTGRY_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
     [WebMethod]
    public static string[] changeProdGrp(string Product_GrpId)
    {
        string[] srt = new string[2];
                clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
                clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
                objEntityProduct.Product_GrpId = Convert.ToInt32(Product_GrpId);

                DataTable dtTaxBygrp = objBusinessLayerProduct.ReadTaxByGroupId(objEntityProduct);
                if (dtTaxBygrp.Rows.Count > 0)
                {
                    if (dtTaxBygrp.Rows[0]["PRDTGP_SLS_TAXID"].ToString() != "")
                    {
                        srt[0] = dtTaxBygrp.Rows[0]["PRDTGP_SLS_TAXID"].ToString();
                        srt[1] = dtTaxBygrp.Rows[0]["TAX_NAME"].ToString();    
                    }
                    else
                    {
                        srt[0] = "--SELECT TAX--";
                        srt[1] = "--SELECT TAX--";
                    }

                }
                return srt;
    }
}