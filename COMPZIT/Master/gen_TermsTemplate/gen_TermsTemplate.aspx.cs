using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Text;
using System.Collections;
// CREATED BY:EVM-0002
// CREATED DATE:01/06/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_TermsTemplate_gen_TermsTemplate : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsBusinessLayerTermsTemplate objBusinessLayerTermsTemplate = new clsBusinessLayerTermsTemplate();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .
        txtTemplateName.Attributes.Add("onkeypress", "return isTag(event)");
        txtTemplateName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTemplateDescription.Attributes.Add("onkeydown", "return textCounter(event,300);");
        txtTemplateDescription.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlTemplateType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlTemplateType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            txtTemplateName.Focus();
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            Template_Type_Load();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.InnerText = "Edit Terms Template";
                lblEntryB.InnerText = "Edit Terms Template";
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
                lblEntry.InnerText = "View Terms Template";
                lblEntryB.InnerText = "View Terms Template";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add Terms Template";
                lblEntryB.InnerText = "Add Terms Template";
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


    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityTermsTemplate objEntityTerms = new clsEntityTermsTemplate();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTerms.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTerms.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityTerms.Template_Description = txtTemplateDescription.Value;
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityTerms.Template_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityTerms.Template_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityTerms.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityTerms.D_Date = System.DateTime.Now;
        objEntityTerms.Template_name = txtTemplateName.Text.ToUpper().Trim();
        objEntityTerms.Template_Type = Convert.ToInt32(ddlTemplateType.SelectedItem.Value);
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerTermsTemplate.CheckTemplateName(objEntityTerms);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerTermsTemplate.AddTemplateMaster(objEntityTerms);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_TermsTemplate.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_TermsTemplateList.aspx?InsUpd=Ins");
            } 
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtTemplateName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityTermsTemplate objEntityTerms = new clsEntityTermsTemplate();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTerms.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTerms.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityTerms.Template_Description = txtTemplateDescription.Value;
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityTerms.Template_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityTerms.Template_Status = 0;
            }
            if (Session["USERID"] != null)
            {
                objEntityTerms.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityTerms.Template_Id = Convert.ToInt32(strId);
            objEntityTerms.D_Date = System.DateTime.Now;
            objEntityTerms.Template_name = txtTemplateName.Text.ToUpper().Trim();
            objEntityTerms.Template_Type = Convert.ToInt32(ddlTemplateType.SelectedItem.Value);
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerTermsTemplate.CheckTemplateName(objEntityTerms);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                 DataTable dtComplaintDetail = objBusinessLayerTermsTemplate.ReadTemplateById(objEntityTerms);
                 if (dtComplaintDetail.Rows.Count > 0)
                 {
                     if (dtComplaintDetail.Rows[0]["TRTEMP_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["TRTEMP_CNCL_USR_ID"].ToString() == null)
                     {
                         objBusinessLayerTermsTemplate.UpdateTemplate(objEntityTerms);
                         if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                         {
                             Response.Redirect("gen_TermsTemplate.aspx?InsUpd=Upd");
                         }
                         else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                         {
                             Response.Redirect("gen_TermsTemplateList.aspx?InsUpd=Upd");
                         }
                     }
                     else
                     {
                         Response.Redirect("gen_TermsTemplateList.aspx?InsUpd=AlCncl");
                     }
                 }             
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtTemplateName.Focus();
            }
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strT_Id)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityTermsTemplate objEntityTerms = new clsEntityTermsTemplate();
        objEntityTerms.Template_Id = Convert.ToInt32(strT_Id);
        DataTable dtTaxById = objBusinessLayerTermsTemplate.ReadTemplateById(objEntityTerms);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtTemplateName.Text = dtTaxById.Rows[0]["TRTEMP_NAME"].ToString();
        txtTemplateDescription.Value = dtTaxById.Rows[0]["TRTEMP_DESCRIPTION"].ToString();
        ListItem lst = new ListItem(dtTaxById.Rows[0]["QTTEMP_NAME"].ToString(), dtTaxById.Rows[0]["QTTEMP_ID"].ToString());
        ddlTemplateType.Items.Insert(0, lst);
        ddlTemplateType.Items.FindByText(dtTaxById.Rows[0]["QTTEMP_NAME"].ToString()).Selected = true;
        int intStatus = Convert.ToInt32(dtTaxById.Rows[0]["TRTEMP_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
        txtTemplateName.Enabled = false;
        txtTemplateDescription.Disabled = true;
        ddlTemplateType.Enabled = false;
        cbxStatus.Disabled = true;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strT_Id)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityTermsTemplate objEntityTerms = new clsEntityTermsTemplate();
        objEntityTerms.Template_Id = Convert.ToInt32(strT_Id);
        DataTable dtTaxById = objBusinessLayerTermsTemplate.ReadTemplateById(objEntityTerms);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtTemplateName.Text = dtTaxById.Rows[0]["TRTEMP_NAME"].ToString();
        txtTemplateDescription.Value = dtTaxById.Rows[0]["TRTEMP_DESCRIPTION"].ToString();
        Template_Type_Load();
        //ie IF  TEMPLATYE TYPE IS INACTIVE IS ACTIVE
        if (dtTaxById.Rows[0]["QTTEMP_STATUS"].ToString() == "1")
        {
            ddlTemplateType.Items.FindByText(dtTaxById.Rows[0]["QTTEMP_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lst = new ListItem(dtTaxById.Rows[0]["QTTEMP_NAME"].ToString(), dtTaxById.Rows[0]["QTTEMP_ID"].ToString());
            ddlTemplateType.Items.Insert(1, lst);
            SortDDL(ref this.ddlTemplateType);
            ddlTemplateType.Items.FindByText(dtTaxById.Rows[0]["QTTEMP_NAME"].ToString()).Selected = true;
        }
        int intStatus = Convert.ToInt32(dtTaxById.Rows[0]["TRTEMP_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
    }
    //Method for assigning template type
    public void Template_Type_Load()
    {
        clsEntityTermsTemplate objEntityTemp = new clsEntityTermsTemplate();
        DataTable dtTemp = objBusinessLayerTermsTemplate.ReadTempMaster();
        ddlTemplateType.Items.Clear();
        ddlTemplateType.DataSource = dtTemp;
        ddlTemplateType.DataTextField = "QTTEMP_NAME";
        ddlTemplateType.DataValueField = "QTTEMP_ID";
        ddlTemplateType.DataBind();
        ddlTemplateType.Items.Insert(0, "--SELECT TEMPLATE CATEGORY--");
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
}