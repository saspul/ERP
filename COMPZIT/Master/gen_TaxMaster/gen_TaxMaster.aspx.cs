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
// CREATED BY:EVM-0001
// CREATED DATE:10/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_TaxMaster_gen_TaxMaster : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsBusinessLayerTaxMaster objBusinessLayerTaxMaster = new clsBusinessLayerTaxMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtTaxName.Attributes.Add("onkeypress", "return isTag(event)");
        txtTaxName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTaxPercentage.Attributes.Add("onkeydown", "return isNumber(event)");
        txtTaxPercentage.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            txtTaxName.Focus();

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
              
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.TAX_PERC_DECIMAL
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            hiddenFloatingValue.Value = "0";
            if (dtCorpDetail.Rows.Count > 0)
            {
                if (dtCorpDetail.Rows[0]["TAX_PERC_DECIMAL"].ToString() != "")
                {
                    hiddenFloatingValue.Value = dtCorpDetail.Rows[0]["TAX_PERC_DECIMAL"].ToString();
                }


            }



            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Tax Master";
                lblEntryB.InnerText = "Edit Tax Master";
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

                lblEntry.InnerText = "View Tax Master";
                lblEntryB.InnerText = "View Tax Master";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Tax Master";
                lblEntryB.InnerText = "Add Tax Master";
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
        clsEntityTaxMaster objEntityTaxMaster = new clsEntityTaxMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityTaxMaster.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityTaxMaster.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityTaxMaster.Tax_Percentage = Convert.ToDecimal(txtTaxPercentage.Text.Trim());
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityTaxMaster.Tax_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityTaxMaster.Tax_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityTaxMaster.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityTaxMaster.D_Date = System.DateTime.Now;
        txtTaxName.Text = txtTaxName.Text.ToUpper().Trim();
        objEntityTaxMaster.Tax_name = txtTaxName.Text.Trim();
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerTaxMaster.CheckTaxName(objEntityTaxMaster);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerTaxMaster.AddTaxMaster(objEntityTaxMaster);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_TaxMaster.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_TaxMasterList.aspx?InsUpd=Ins");
            }
          
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtTaxName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityTaxMaster objEntityTaxMaster = new clsEntityTaxMaster();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityTaxMaster.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityTaxMaster.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityTaxMaster.Tax_Percentage = Convert.ToDecimal(txtTaxPercentage.Text.Trim());
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityTaxMaster.Tax_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityTaxMaster.Tax_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityTaxMaster.Tax_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityTaxMaster.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityTaxMaster.D_Date = System.DateTime.Now;
            txtTaxName.Text = txtTaxName.Text.ToUpper().Trim();
            objEntityTaxMaster.Tax_name = txtTaxName.Text.Trim();
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerTaxMaster.CheckTaxName(objEntityTaxMaster);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                DataTable dtComplaintDetail = objBusinessLayerTaxMaster.ReadTaxById(objEntityTaxMaster);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["TAX_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["TAX_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessLayerTaxMaster.UpdateTax(objEntityTaxMaster);
                        if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                        {
                            Response.Redirect("gen_TaxMaster.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                        {
                            Response.Redirect("gen_TaxMasterList.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_TaxMasterList.aspx?InsUpd=AlCncl");
                    }
                }      
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtTaxName.Focus();
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
        clsEntityTaxMaster objEntityTaxMaster = new clsEntityTaxMaster();
        objEntityTaxMaster.Tax_Id = Convert.ToInt32(strT_Id);
        DataTable dtTaxById = objBusinessLayerTaxMaster.ReadTaxById(objEntityTaxMaster);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtTaxName.Text = dtTaxById.Rows[0]["TAX_NAME"].ToString();
        string strPercentageValue = dtTaxById.Rows[0]["TAX_PERCENTAGE"].ToString();

        int intTaxDecimalCount = 0;
        if (hiddenFloatingValue.Value != "")
        {

            intTaxDecimalCount = Convert.ToInt32(hiddenFloatingValue.Value);
        }
        if (strPercentageValue != "")
        {
            if (strPercentageValue.Contains('.'))
            strPercentageValue = objCommon.Format(intTaxDecimalCount, strPercentageValue);
        }
        txtTaxPercentage.Text = strPercentageValue;
        int intStatus = Convert.ToInt32(dtTaxById.Rows[0]["TAX_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
        txtTaxName.Enabled = false;
        txtTaxPercentage.Enabled = false;
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
        clsEntityTaxMaster objEntityTaxMaster = new clsEntityTaxMaster();
        objEntityTaxMaster.Tax_Id = Convert.ToInt32(strT_Id);
        DataTable dtTaxById = objBusinessLayerTaxMaster.ReadTaxById(objEntityTaxMaster);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtTaxName.Text = dtTaxById.Rows[0]["TAX_NAME"].ToString();
        string strPercentageValue = dtTaxById.Rows[0]["TAX_PERCENTAGE"].ToString();

        int intTaxDecimalCount = 0;
        if (hiddenFloatingValue.Value != "")
        {

            intTaxDecimalCount = Convert.ToInt32(hiddenFloatingValue.Value);
        }
        if (strPercentageValue != "")
        {
            if(strPercentageValue.Contains('.'))
            strPercentageValue = objCommon.Format(intTaxDecimalCount, strPercentageValue);
        }
        txtTaxPercentage.Text = strPercentageValue;
        int intStatus = Convert.ToInt32(dtTaxById.Rows[0]["TAX_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
    }


   
}