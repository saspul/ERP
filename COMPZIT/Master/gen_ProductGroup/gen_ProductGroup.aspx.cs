using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Collections;

public partial class MasterPage_Default : System.Web.UI.Page
{
    clsBusinessLayerProductGrp objBusinessLayerItemGrp = new clsBusinessLayerProductGrp();
    string valu;
    string value = "1";

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions.


        txtPrdctGrpName.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrdctGrpName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPrdctCodeName.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrdctCodeName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlPurchaseTax.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlPurchaseTax.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlSalesTax.Attributes.Add("onkeypress", "return DisableEnter(event)");
       
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlSalesTax.Attributes.Add("onchange", "return onSelectedIndexChange()");



        //If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.

        if (!IsPostBack)
        {
            txtPrdctGrpName.Focus();

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CMDTY_MANTN_OFFCE, clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED
                                                           };
            DataTable dtCorpDetail = new DataTable();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            if (Session["CORPOFFICEID"] != null)
            {
                int intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
                hiddenCommodityValue.Value = dtCorpDetail.Rows[0]["CMDTY_MANTN_OFFCE"].ToString();
                hiddenTaxEnabled.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                if (hiddenCommodityValue.Value == "2" || hiddenTaxEnabled.Value == "0")
                {

                    //divPurchTax.Visible = false;
                    //divSalesTax.Visible = false;
                  
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }



            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Product Group";
                lblEntryB.InnerText = "Edit Product Group";
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
                btnClear.Visible = false;
                btnClearF.Visible = false;
                lblEntry.InnerText = "View Product Group";
                lblEntryB.InnerText = "View Product Group";
            }

            else
            {

                lblEntry.InnerText = "Add Product Group";
                lblEntryB.InnerText = "Add Product Group";
                Department_Load();
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

    //Method for assigning corporate departments to the dropdown list
    public void Department_Load(int intItemtId = 0)
    {
        clsEntityProductGrp objEntityItmGrp = new clsEntityProductGrp();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityItmGrp.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityItmGrp.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (intItemtId != 0)
        {
            objEntityItmGrp.ItemGrp_Id = intItemtId;
        }
        DataTable dtItmGrp = objBusinessLayerItemGrp.ReadPurchaseTax(objEntityItmGrp);

        ddlPurchaseTax.DataSource = dtItmGrp;

        ddlPurchaseTax.DataTextField = "TAX_NAME";
        ddlPurchaseTax.DataValueField = "TAX_ID";
        ddlPurchaseTax.DataBind();

        ddlPurchaseTax.Items.Insert(0, "--SELECT PURCHASE TAX--");

        DataTable dtPrdctSale = objBusinessLayerItemGrp.ReadPurchaseTax(objEntityItmGrp);
        ddlSalesTax.DataSource = dtPrdctSale;
        ddlSalesTax.DataTextField = "TAX_NAME";
        ddlSalesTax.DataValueField = "TAX_ID";
        ddlSalesTax.DataBind();
        ddlSalesTax.Items.Insert(0, "--SELECT SALES TAX--");

    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        valu = HiddenField1.Value;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityProductGrp objEntityItmGrp = new clsEntityProductGrp();


            if (Session["CORPOFFICEID"] != null)
            {
                objEntityItmGrp.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityItmGrp.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }

            //If not  selected
            if (ddlPurchaseTax.SelectedItem.Text.ToString() == "--SELECT PURCHASE TAX--")
            {
                objEntityItmGrp.Purchase_Tax = 0;
            }
            //If selected
            else
            {
                objEntityItmGrp.Purchase_Tax = Convert.ToInt32(ddlPurchaseTax.SelectedItem.Value);
            }

            if (ddlSalesTax.SelectedItem.Text.ToString() == "--SELECT SALES TAX--")
            {
                objEntityItmGrp.Sales_Tax = 0;
            }
            //If selected
            else
            {
                objEntityItmGrp.Sales_Tax = Convert.ToInt32(ddlSalesTax.SelectedItem.Value);
            }

            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityItmGrp.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityItmGrp.Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strDeptId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityItmGrp.ItemGrp_Id = Convert.ToInt32(strDeptId);

            objEntityItmGrp.User_Id = Convert.ToInt32(Session["USERID"]);
            objEntityItmGrp.D_Date = System.DateTime.Now;
            txtPrdctGrpName.Text = txtPrdctGrpName.Text.ToUpper().Trim();
            objEntityItmGrp.ItemGrp_name = txtPrdctGrpName.Text;
            txtPrdctCodeName.Text = txtPrdctCodeName.Text.ToUpper().Trim();
            objEntityItmGrp.Group_Code = txtPrdctCodeName.Text;



            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerItemGrp.CheckItemGroupName(objEntityItmGrp);
            string strCodeCount = objBusinessLayerItemGrp.CheckItemGroupCode(objEntityItmGrp);
            //If there is no name like this on table.    
            if (strNameCount == "0" && strCodeCount == "0")
            {
                DataTable dtComplaintDetail = objBusinessLayerItemGrp.ReadItemGroupById(objEntityItmGrp);
                 if (dtComplaintDetail.Rows.Count > 0)
                 {
                     if (dtComplaintDetail.Rows[0]["PRDTGP_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["PRDTGP_CNCL_USR_ID"].ToString() == null)
                     {
                         objEntityItmGrp.Item_Tax_Update = Convert.ToInt32(hiddenTaxValue.Value);
                         objBusinessLayerItemGrp.UpdateItemGroup(objEntityItmGrp);

                         if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF" || clickedButton.ID == "Button1")
                         {
                             Response.Redirect("gen_ProductGroup.aspx?InsUpd=Upd");
                         }
                         else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF" || clickedButton.ID == "Button2")
                         {
                             Response.Redirect("gen_ProductGroupList.aspx?InsUpd=Upd");
                         }
                     }
                     else
                     {
                         Response.Redirect("gen_ProductGroupList.aspx?InsUpd=AlCncl");
                     }
                 }
               

            }
            //If have
            else
            {
                if (strCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    txtPrdctCodeName.Focus();
                }
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtPrdctGrpName.Focus();
                }
            }
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityProductGrp objEntityItmGrp = new clsEntityProductGrp();


        if (Session["CORPOFFICEID"] != null)
        {
            objEntityItmGrp.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityItmGrp.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        //If not selected

        if (ddlPurchaseTax.SelectedItem.Text.ToString() == "--SELECT PURCHASE TAX--")
        {
            objEntityItmGrp.Purchase_Tax = 0;
        }
        //If selected
        else
        {
            objEntityItmGrp.Purchase_Tax = Convert.ToInt32(ddlPurchaseTax.SelectedItem.Value);
        }

        if (ddlSalesTax.SelectedItem.Text.ToString() == "--SELECT SALES TAX--")
        {
            objEntityItmGrp.Sales_Tax = 0;
        }
        //If selected
        else
        {
            objEntityItmGrp.Sales_Tax = Convert.ToInt32(ddlSalesTax.SelectedItem.Value);
        }
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityItmGrp.Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityItmGrp.Status = 0;
        }
        objEntityItmGrp.User_Id = Convert.ToInt32(Session["USERID"]);
        objEntityItmGrp.D_Date = System.DateTime.Now;
        txtPrdctGrpName.Text = txtPrdctGrpName.Text.ToUpper().Trim();
        objEntityItmGrp.ItemGrp_name = txtPrdctGrpName.Text;
        txtPrdctCodeName.Text = txtPrdctCodeName.Text.ToUpper().Trim(); ;
        objEntityItmGrp.Group_Code = txtPrdctCodeName.Text;

        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerItemGrp.CheckItemGroupName(objEntityItmGrp);
        string strCodeCount = objBusinessLayerItemGrp.CheckItemGroupCode(objEntityItmGrp);
        //If there is no name like this on table.    
        if (strNameCount == "0" && strCodeCount == "0")
        {
            objBusinessLayerItemGrp.AddItemGrpMaster(objEntityItmGrp);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_ProductGroup.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_ProductGroupList.aspx?InsUpd=Ins");
            }
           
        }
        //If have
        else
        {
            if (strCodeCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                txtPrdctCodeName.Focus();
            }
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtPrdctGrpName.Focus();
            }

        }
    }


    public void View(string strDId)
    {

        clsEntityProductGrp objEntItmGrp = new clsEntityProductGrp();
        objEntItmGrp.ItemGrp_Id = Convert.ToInt32(strDId);
        DataTable dtDeptById = objBusinessLayerItemGrp.ReadItemGroupById(objEntItmGrp);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtPrdctGrpName.Text = dtDeptById.Rows[0]["PRDTGP_NAME"].ToString();
        txtPrdctCodeName.Text = dtDeptById.Rows[0]["PRDTGP_GRP_CODE"].ToString();


        ddlPurchaseTax.Items.Clear();

        if (dtDeptById.Rows[0]["PURCH_TAX"].ToString() == "")
        {
            ddlPurchaseTax.Items.Insert(0, "--SELECT PURCHASE TAX--");
        }
        else
        {
            ddlPurchaseTax.Items.Clear();
            ListItem lst = new ListItem(dtDeptById.Rows[0]["PURCH_TAX"].ToString(), dtDeptById.Rows[0]["PRDTGP_PURCH_TAXID"].ToString());
            ddlPurchaseTax.Items.Insert(0, lst);
        }
        ddlSalesTax.Items.Clear();

        if (dtDeptById.Rows[0]["SALE_TAX"].ToString() == "")
        {
            ddlSalesTax.Items.Insert(0, "--SELECT SALES TAX--");
        }
        else
        {
            ddlSalesTax.Items.Clear();
            ListItem lst = new ListItem(dtDeptById.Rows[0]["SALE_TAX"].ToString(), dtDeptById.Rows[0]["PRDTGP_SLS_TAXID"].ToString());
            ddlSalesTax.Items.Insert(0, lst);
        }


        int intDeptStatus = Convert.ToInt32(dtDeptById.Rows[0]["PRDTGP_STATUS"]);
        if (intDeptStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

        txtPrdctGrpName.Enabled = false;
        txtPrdctCodeName.Enabled = false;

        ddlPurchaseTax.Enabled = false;
        ddlSalesTax.Enabled = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Disabled = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strDId)
    {
        clsEntityProductGrp objEntItmGrp = new clsEntityProductGrp();
        objEntItmGrp.ItemGrp_Id = Convert.ToInt32(strDId);
        DataTable dtDeptById = objBusinessLayerItemGrp.ReadItemGroupById(objEntItmGrp);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtPrdctGrpName.Text = dtDeptById.Rows[0]["PRDTGP_NAME"].ToString();
        txtPrdctCodeName.Text = dtDeptById.Rows[0]["PRDTGP_GRP_CODE"].ToString();
        Int32 intPrdgpId = Convert.ToInt32(dtDeptById.Rows[0]["PRDTGP_ID"]);
        Department_Load(intPrdgpId);


        if (dtDeptById.Rows[0]["PURCH_TAX"].ToString() == "")
        {
            ddlPurchaseTax.Items.FindByText("--SELECT PURCHASE TAX--").Selected = true;
        }
        else
        {

            //    ddlPurchaseTax.Items.Clear();
            if (dtDeptById.Rows[0]["PURCH_STATUS"].ToString() == "1" && dtDeptById.Rows[0]["PURCH_USER"].ToString() == "")
            {
                ddlPurchaseTax.Items.FindByText(dtDeptById.Rows[0]["PURCH_TAX"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtDeptById.Rows[0]["PURCH_TAX"].ToString(), dtDeptById.Rows[0]["PRDTGP_PURCH_TAXID"].ToString());
                ddlPurchaseTax.Items.Insert(0, lst);
                SortDDL(ref this.ddlPurchaseTax);
                ddlPurchaseTax.Items.FindByText(dtDeptById.Rows[0]["PURCH_TAX"].ToString()).Selected = true;
            }
        }




        if (dtDeptById.Rows[0]["SALE_TAX"].ToString() == "")
        {
            ddlSalesTax.Items.FindByText("--SELECT SALES TAX--").Selected = true;
        }
        else
        {
            if (dtDeptById.Rows[0]["SALE_STATUS"].ToString() == "1" && dtDeptById.Rows[0]["SALE_USER"].ToString() == "")
            {
                ddlSalesTax.Items.FindByText(dtDeptById.Rows[0]["SALE_TAX"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtDeptById.Rows[0]["SALE_TAX"].ToString(), dtDeptById.Rows[0]["PRDTGP_SLS_TAXID"].ToString());
                ddlSalesTax.Items.Insert(0, lst);
                SortDDL(ref this.ddlSalesTax);
                ddlSalesTax.Items.FindByText(dtDeptById.Rows[0]["SALE_TAX"].ToString()).Selected = true;
            }

        }


        int intDeptStatus = Convert.ToInt32(dtDeptById.Rows[0]["PRDTGP_STATUS"]);
        if (intDeptStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }


        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
    }

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


    protected void ddlSalesTax_SelectedIndexChanged(object sender, EventArgs e)
    {
        // HiddenField1.Value = value;
    }
}