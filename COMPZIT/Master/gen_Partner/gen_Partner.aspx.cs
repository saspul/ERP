using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Data;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class Master_gen_Partner_gen_Partner : System.Web.UI.Page
{
    clsBusinessLayerPartner objBusinessPartner = new clsBusinessLayerPartner();
    protected void Page_Load(object sender, EventArgs e)
    {
     ddlPartshipTyp.Attributes.Add("onkeypress", "return DisableEnter(event)");
     ddlPartshipTyp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     ddlCountry.Attributes.Add("onkeypress", "return DisableEnter(event)");
     //ddlCountry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     ddlState.Attributes.Add("onkeypress", "return DisableEnter(event)");
     //ddlState.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     ddlCity.Attributes.Add("onkeypress", "return DisableEnter(event)");
    // ddlCity.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtPartName.Attributes.Add("onkeypress", "return isTag(event)");
     txtPartName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtAdd1.Attributes.Add("onkeypress", "return isTag(event)");
     txtAdd1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtAdd2.Attributes.Add("onkeypress", "return isTag(event)");
     txtAdd2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtAdd3.Attributes.Add("onkeypress", "return isTag(event)");
     txtAdd3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtZip.Attributes.Add("onkeypress", "return isTag(event)");
     txtZip.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtPhone.Attributes.Add("onkeypress", "return isTag(event)");
     txtPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtFax.Attributes.Add("onkeypress", "return isTag(event)");
     txtFax.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtWebsite.Attributes.Add("onkeypress", "return isTag(event)");
     txtWebsite.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
     txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtEnqMail.Attributes.Add("onkeypress", "return isTag(event)");
     txtEnqMail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtDocNum.Attributes.Add("onkeypress", "return isTag(event)");
     txtDocNum.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtCRN.Attributes.Add("onkeypress", "return isTag(event)");
     txtCRN.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtCCN.Attributes.Add("onkeypress", "return isTag(event)");
     txtCCN.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     txtTIN.Attributes.Add("onkeypress", "return isTag(event)");
     txtTIN.Attributes.Add("onchange", "IncrmntConfrmCounter()");

     if (!IsPostBack)
     {
         //hiddenUserImageSize.Value="512000";
         int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.CORPORATE_PARTNER);
         hiddenUserImageSize.Value = intImageMaxSize.ToString();
         CountryLoad();
         PartshpTypeLoad();
         clsBusinessLayer objBusiness = new clsBusinessLayer();
         string strCurrentDate = objBusiness.LoadCurrentDateInString();
         hiddenCurrentDate.Value = strCurrentDate;

         clsEntityPartner objEntityPartner = new clsEntityPartner();

         if (Session["ORGID"] != null)
         {
             objEntityPartner.Organisation_Id = Convert.ToInt32(Session["ORGID"]);
             hiddenOrgId.Value = Convert.ToString(Session["ORGID"]);
         }
         else
         {
             Response.Redirect("~/Default.aspx");
       
         }
         //when editing 
         if (Request.QueryString["Id"] != null)
         {
             ddlPartshipTyp.Focus();             
             string strRandomMixedId = Request.QueryString["Id"].ToString();
             string strLenghtofId = strRandomMixedId.Substring(0, 2);
             int intLenghtofId = Convert.ToInt16(strLenghtofId);
             string strId = strRandomMixedId.Substring(2, intLenghtofId);
             Update(strId);
             lblEntry.InnerText = "Edit Corporate Partner";
             lblEntryB.InnerText = "Edit Corporate Partner";
         }

         //when  viewing
         else if (Request.QueryString["ViewId"] != null)
         {
           
             string strRandomMixedId = Request.QueryString["ViewId"].ToString();
             string strLenghtofId = strRandomMixedId.Substring(0, 2);
             int intLenghtofId = Convert.ToInt16(strLenghtofId);
             string strId = strRandomMixedId.Substring(2, intLenghtofId);
             View(strId);
             lblEntry.InnerText = "View Corporate Partner";
             lblEntryB.InnerText = "View Corporate Partner";
         }
         else
         {
             ddlPartshipTyp.Focus();
             lblEntry.InnerText = "Add Corporate Partner";
             lblEntryB.InnerText = "Add Corporate Partner";
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
      //Fetching the table from business layer and assign them in our fields.
    public void Update(string strCO_Id)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Partner);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        //future

                    }

                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = true;
                    btnUpdateF.Visible = true;

                }
                else
                {
                    btnUpdate.Visible = false;
                    btnUpdateF.Visible = false;
                }
            }
        hiddenEdit.Value = "Edit";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
       // btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnClear.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        // btnUpdate.Visible = true;
        btnUpdateCloseF.Visible = true;
        btnClearF.Visible = false;
        clsEntityPartner objEntityPartner = new clsEntityPartner();
        objEntityPartner.PartnerId = Convert.ToInt32(strCO_Id);
        DataTable dtCprpOffice = objBusinessPartner.ReadPartnerById(objEntityPartner);
        //After fetch  details in datatable,we need to differentiate.
        txtPartName.Text = dtCprpOffice.Rows[0]["PRTNR_NAME"].ToString();

        if (dtCprpOffice.Rows[0]["PRTSHTY_STATUS"].ToString() == "1" )
        {
            ddlPartshipTyp.Items.FindByText(dtCprpOffice.Rows[0]["PRTSHTY_NAME"].ToString()).Selected = true;

        }
        else
        {
            ListItem lst = new ListItem(dtCprpOffice.Rows[0]["PRTSHTY_NAME"].ToString(), dtCprpOffice.Rows[0]["PRTSHTY_ID"].ToString());
            ddlPartshipTyp.Items.Insert(1, lst);

            SortDDL(ref this.ddlPartshipTyp);

            ddlPartshipTyp.Items.FindByText(dtCprpOffice.Rows[0]["PRTSHTY_NAME"].ToString()).Selected = true;
        }
       

        //ie IF  COUNTRY IS ACTIVE
        if (dtCprpOffice.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCprpOffice.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
        {
            ddlCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;

        }
        else
        {
            ListItem lst = new ListItem(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString(), dtCprpOffice.Rows[0]["CNTRY_ID"].ToString());
            ddlCountry.Items.Insert(1, lst);

            SortDDL(ref this.ddlCountry);

            ddlCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
        }

        txtAdd1.Text = dtCprpOffice.Rows[0]["PRTNR_ADDR1"].ToString();
        txtAdd2.Text = dtCprpOffice.Rows[0]["PRTNR_ADDR2"].ToString();
        txtAdd3.Text = dtCprpOffice.Rows[0]["PRTNR_ADDR3"].ToString();
        txtZip.Text = dtCprpOffice.Rows[0]["PRTNR_ZIP"].ToString();
        txtWebsite.Text = dtCprpOffice.Rows[0]["PRTNR_WEBSITE"].ToString();
        txtPhone.Text = dtCprpOffice.Rows[0]["PRTNR_PHONE"].ToString();
        txtEmail.Text = dtCprpOffice.Rows[0]["PRTNR_EMAIL"].ToString();
        objEntityPartner.CountryId = Convert.ToInt32(dtCprpOffice.Rows[0]["CNTRY_ID"]);
        if (dtCprpOffice.Rows[0]["STATE_ID"].ToString() != "")
        {
           HiddenFieldState.Value = dtCprpOffice.Rows[0]["STATE_ID"].ToString();
           ddlState.Text = dtCprpOffice.Rows[0]["STATE_NAME"].ToString();
            if (dtCprpOffice.Rows[0]["CITY_ID"].ToString() != "")
            {
                HiddenFieldCity.Value = dtCprpOffice.Rows[0]["CITY_ID"].ToString();
                ddlCity.Text = dtCprpOffice.Rows[0]["CITY_NAME"].ToString();              
            }           
        }
        int intCorpStatus = Convert.ToInt32(dtCprpOffice.Rows[0]["PRTNR_STATUS"]);
        if (intCorpStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }


        txtFax.Text = dtCprpOffice.Rows[0]["PRTNR_FAX"].ToString();
        txtEnqMail.Text = dtCprpOffice.Rows[0]["PRTNR_ENQEMAIL"].ToString();
        txtCRN.Text = dtCprpOffice.Rows[0]["PRTNR_CRNUM"].ToString();
        txtTIN.Text = dtCprpOffice.Rows[0]["PRTNR_TINUM"].ToString();
        txtCCN.Text = dtCprpOffice.Rows[0]["PRTNR_CCNUM"].ToString();
        txtDocNum.Text = dtCprpOffice.Rows[0]["PRTNR_DOCNUM"].ToString();
        //HiddenField4.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNAM"].ToString();
        //HiddenField2.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNM_ACT"].ToString();
        //hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
        //new Img Up
        hiddenUserImage.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNAM"].ToString();
        hiddenImageName.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNAM"].ToString();
        if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
        {
            //    divImageEdit.Visible = true;
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + hiddenUserImage.Value;
            // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
            string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
            strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
            strImage += " <img src=\"" + strImagePath + "\"/>";
            strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
            strImage += "</div>";
            divImageDisplay.InnerHtml = strImage;

        }
    }
     //Fetch the new datatable from businesslayer and set separately in each field. 
    public void View(string strCO_Id)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        hiddenView.Value = "View";
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnClear.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        btnClearF.Visible = false;
        clsEntityPartner objEntityPartner = new clsEntityPartner();
        objEntityPartner.PartnerId = Convert.ToInt32(strCO_Id);
        DataTable dtCprpOffice = objBusinessPartner.ReadPartnerById(objEntityPartner);
        //After fetch  details in datatable,we need to differentiate.
        txtPartName.Text = dtCprpOffice.Rows[0]["PRTNR_NAME"].ToString();

        if (dtCprpOffice.Rows[0]["PRTSHTY_STATUS"].ToString() == "1")
        {
            ddlPartshipTyp.Items.FindByText(dtCprpOffice.Rows[0]["PRTSHTY_NAME"].ToString()).Selected = true;

        }
        else
        {
            ListItem lst = new ListItem(dtCprpOffice.Rows[0]["PRTSHTY_NAME"].ToString(), dtCprpOffice.Rows[0]["PRTSHTY_ID"].ToString());
            ddlPartshipTyp.Items.Insert(1, lst);

            SortDDL(ref this.ddlPartshipTyp);

            ddlPartshipTyp.Items.FindByText(dtCprpOffice.Rows[0]["PRTSHTY_NAME"].ToString()).Selected = true;
        }


        //ie IF  COUNTRY IS ACTIVE
        if (dtCprpOffice.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCprpOffice.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
        {
            ddlCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;

        }
        else
        {
            ListItem lst = new ListItem(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString(), dtCprpOffice.Rows[0]["CNTRY_ID"].ToString());
            ddlCountry.Items.Insert(1, lst);

            SortDDL(ref this.ddlCountry);

            ddlCountry.Items.FindByText(dtCprpOffice.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
        }

        txtAdd1.Text = dtCprpOffice.Rows[0]["PRTNR_ADDR1"].ToString();
        txtAdd2.Text = dtCprpOffice.Rows[0]["PRTNR_ADDR2"].ToString();
        txtAdd3.Text = dtCprpOffice.Rows[0]["PRTNR_ADDR3"].ToString();
        txtZip.Text = dtCprpOffice.Rows[0]["PRTNR_ZIP"].ToString();
        txtWebsite.Text = dtCprpOffice.Rows[0]["PRTNR_WEBSITE"].ToString();
        txtPhone.Text = dtCprpOffice.Rows[0]["PRTNR_PHONE"].ToString();
        txtEmail.Text = dtCprpOffice.Rows[0]["PRTNR_EMAIL"].ToString();
        objEntityPartner.CountryId = Convert.ToInt32(dtCprpOffice.Rows[0]["CNTRY_ID"]);
        if (dtCprpOffice.Rows[0]["STATE_ID"].ToString() != "")
        {
            HiddenFieldState.Value = dtCprpOffice.Rows[0]["STATE_ID"].ToString();
            ddlState.Text = dtCprpOffice.Rows[0]["STATE_NAME"].ToString();
            if (dtCprpOffice.Rows[0]["CITY_ID"].ToString() != "")
            {
                HiddenFieldCity.Value = dtCprpOffice.Rows[0]["CITY_ID"].ToString();
                ddlCity.Text = dtCprpOffice.Rows[0]["CITY_NAME"].ToString();
            }
        }
        int intCorpStatus = Convert.ToInt32(dtCprpOffice.Rows[0]["PRTNR_STATUS"]);
        if (intCorpStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }


        txtFax.Text = dtCprpOffice.Rows[0]["PRTNR_FAX"].ToString();
        txtEnqMail.Text = dtCprpOffice.Rows[0]["PRTNR_ENQEMAIL"].ToString();
        txtCRN.Text = dtCprpOffice.Rows[0]["PRTNR_CRNUM"].ToString();
        txtTIN.Text = dtCprpOffice.Rows[0]["PRTNR_TINUM"].ToString();
        txtCCN.Text = dtCprpOffice.Rows[0]["PRTNR_CCNUM"].ToString();
        txtDocNum.Text = dtCprpOffice.Rows[0]["PRTNR_DOCNUM"].ToString();
        //HiddenField4.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNAM"].ToString();
        //HiddenField2.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNM_ACT"].ToString();
        //hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
        //new Img Up
        hiddenUserImage.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNAM"].ToString();
        hiddenImageName.Value = dtCprpOffice.Rows[0]["PRTNR_ICON_FLNAM"].ToString();
        if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
        {
            //    divImageEdit.Visible = true;
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + hiddenUserImage.Value;
            // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
            string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
            strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
            strImage += " <img src=\"" + strImagePath + "\"/>";
            strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
            strImage += "</div>";
            divImageDisplay.InnerHtml = strImage;

        }
        FileUploadProPic.Enabled = false;
        //divImgWrap.Visible = false;
        ddlPartshipTyp.Enabled = false;
        txtPartName.Enabled = false;
        txtAdd1.Enabled = false;
        txtAdd2.Enabled = false;
        txtAdd3.Enabled = false;
        ddlCountry.Enabled = false;
        ddlState.Enabled = false;
        ddlCity.Enabled = false;
        txtZip.Enabled = false;
        txtPhone.Enabled = false;
        txtWebsite.Enabled = false;
        txtEmail.Enabled = false;
        txtEnqMail.Enabled = false;
        cbxStatus.Disabled = true;
        txtFax.Enabled = false;
        txtEnqMail.Enabled = false;
        txtCRN.Enabled = false;
        txtTIN.Enabled = false;      
        txtCCN.Enabled = false;
        txtDocNum.Enabled = false;
        imgClear.Visible = false;
    }
    //Method for binding Country type details to dropdown list.
    public void CountryLoad()
    {
        DataTable dtCountry = objBusinessPartner.ReadCountry();
        ddlCountry.DataSource = dtCountry;
        ddlCountry.DataTextField = "CNTRY_NAME";
        ddlCountry.DataValueField = "CNTRY_ID";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, "--Select Country--");
       
    }
    [WebMethod]
    public static string[] changeCity(string strLikeEmployee, int orgID, int corptID, int stateID)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.StateId = Convert.ToInt32(stateID);
        objEntityCorp.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CITY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CITY_NAME"].ToString()));
        }
        return Employees.ToArray();
    }
    [WebMethod]
    public static string[] changeState(string strLikeEmployee, int orgID, int corptID, int countryID)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.CountryId = Convert.ToInt32(countryID);
        objEntityCorp.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["STATE_ID"].ToString(), dtEmployess.Rows[intRowCount]["STATE_NAME"].ToString()));
        }
        return Employees.ToArray();
    }


    //Method for binding partnership type details to dropdown list.
    public void PartshpTypeLoad()
    {
        DataTable dtCountry = objBusinessPartner.ReadPartshipType();
        ddlPartshipTyp.DataSource = dtCountry;
        ddlPartshipTyp.DataTextField = "PRTSHTY_NAME";
        ddlPartshipTyp.DataValueField = "PRTSHTY_ID";
        ddlPartshipTyp.DataBind();
        ddlPartshipTyp.Items.Insert(0, "--Select Partnership Type--");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityPartner objEntityPartner = new clsEntityPartner();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityPartner.PartnerName = txtPartName.Text.ToUpper().Trim();
        objEntityPartner.PartshipTypeId = Convert.ToInt32(ddlPartshipTyp.SelectedItem.Value);
        objEntityPartner.Address1 = txtAdd1.Text.Trim();
        objEntityPartner.Address2 = txtAdd2.Text.Trim();
        objEntityPartner.Address3 = txtAdd3.Text.Trim();
        objEntityPartner.DocNum = txtDocNum.Text.Trim();
        objEntityPartner.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
        //If there is no state selected
        if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
        {
            //objEntityPartner.StateId = null;
            //objEntityPartner.CityId = null;
        }
        else
        {
            objEntityPartner.StateId = Convert.ToInt32(HiddenFieldState.Value);
            //If there is no city selected
            if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
            {
                //  objEntityPartner.CityId = null;
            }
            else
            {
                objEntityPartner.CityId = Convert.ToInt32(HiddenFieldCity.Value);

            }
        }
        objEntityPartner.ZipCode = txtZip.Text;
        objEntityPartner.Phone_Number = txtPhone.Text;
        objEntityPartner.Web_Address = txtWebsite.Text;
        objEntityPartner.Email_Address = txtEmail.Text;
      
        if (Session["USERID"] != null)
        {
            objEntityPartner.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPartner.Organisation_Id = Convert.ToInt32(Session["ORGID"]);
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPartner.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (cbxStatus.Checked == true)
        {
            objEntityPartner.StatusId = 1;
        }
        else
        {
            objEntityPartner.StatusId = 0;
        }

        objEntityPartner.Fax = txtFax.Text;
        objEntityPartner.EnqMail = txtEnqMail.Text;
        objEntityPartner.CRNnum = txtCRN.Text;
        objEntityPartner.TINnum = txtTIN.Text;
        objEntityPartner.CCNnum = txtCCN.Text;
        objEntityPartner.date = System.DateTime.Now;
      
        // start icon file upload

        //string iconfileid = "file0";
        //for (int intCount = 0; intCount < Request.Files.Count; intCount++)
        //{

        //    string fileId = Request.Files.AllKeys[intCount].ToString();
        //    HttpPostedFile PostedFile = Request.Files[intCount];
        //    if (fileId == iconfileid)
        //    {
        //        if (PostedFile.ContentLength > 0)
        //        {

        //            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
        //            string strFileExt;
        //            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
        //            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

        //            string strImageName = "Icon_" + intImageSection.ToString() + "_" + "." + strFileExt;

        //            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

        //            PostedFile.SaveAs(Server.MapPath(strImagePath) + strImageName);

        //            objEntityPartner.IconFname = strImageName;
        //            objEntityPartner.IconActFname = strFileName;

        //        }
        //    }
        //}
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CORPORATE_PARTNER);
        objEntityCommon.CorporateID = objEntityPartner.Corporate_id;
        objEntityCommon.Organisation_Id = objEntityPartner.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityPartner.NextId = Convert.ToInt32(strNextId);
        if (FileUploadProPic.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;

            strFileExt = FileUploadProPic.FileName.Substring(FileUploadProPic.FileName.LastIndexOf('.') + 1).ToLower();
            string strFileName = FileUploadProPic.FileName;
            //int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.USER_MASTER);
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
            //string strImageName = "Icon_" + intImageSection.ToString() + "_" + "." + strFileExt;
            string strImageName = "Corp_Icon_" + intImageSection.ToString() + "_" + objEntityPartner.NextId + "." + strFileExt;

            objEntityPartner.IconFname = strImageName;
            objEntityPartner.IconActFname = strFileName;

        }
        //stop icon file upload

        string strCount = objBusinessPartner.CheckName(objEntityPartner);
        string strDocNumcount = objBusinessPartner.CheckDocnum(objEntityPartner);
        //Commercial Registration Number
        string strComRegNo = "";
        //Computer Card Number
        string strComCardNo= "";
        //Tax Identification Number
        string strTIN = "";

        if (ddlPartshipTyp.SelectedItem.Text == "COMPANY")
        {
            //if company
            strComRegNo = objBusinessPartner.CheckComRegNo(objEntityPartner);
            if (txtCCN.Text != "")
            {
                strComCardNo = objBusinessPartner.CheckComCardNo(objEntityPartner);
            }
            else
            {
                strComCardNo = "0";
            }
            strTIN = objBusinessPartner.CheckTIN(objEntityPartner);
            //Insertion Process
            if (strCount == "0" && strDocNumcount == "0" && strComRegNo == "0" && strComCardNo == "0" && strTIN=="0")
            {
                objBusinessPartner.insertPartner(objEntityPartner);
                //FOR SAVING DOCUMENTS
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                if (FileUploadProPic.HasFile)
                {
                    FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityPartner.IconFname);
                }
                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                {
                    Response.Redirect("gen_Partner.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
                {
                    Response.Redirect("gen_PartnerList.aspx?InsUpd=Ins");
                }
            }
            else
            {
                if (strCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtPartName.Focus();
                }
                else if (strDocNumcount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDoc", "DuplicationDoc();", true);
                    txtDocNum.Focus();
                }
                else if (strComRegNo != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCRN", "DuplicationCRN();", true);
                    txtCRN.Focus();
                }
                else if (strComCardNo != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCCN", "DuplicationCCN();", true);
                    txtCCN.Focus();
                }
                else if (strTIN != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationTIN", "DuplicationTIN();", true);
                    txtTIN.Focus();
                }
            }
        }
        else
        {

            //Insertion Process
            if (strCount == "0" && strDocNumcount == "0")
            {
                objBusinessPartner.insertPartner(objEntityPartner);
                //FOR SAVING DOCUMENTS
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                if (FileUploadProPic.HasFile)
                {
                    FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityPartner.IconFname);
                }
                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                {
                    Response.Redirect("gen_Partner.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
                {
                    Response.Redirect("gen_PartnerList.aspx?InsUpd=Ins");
                }
            }
            else
            {
                if (strCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtPartName.Focus();
                }
                else if (strDocNumcount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDoc", "DuplicationDoc();", true);
                    txtDocNum.Focus();
                }
            }
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityPartner objEntityPartner = new clsEntityPartner();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityPartner.PartnerId = Convert.ToInt32(strId);

            objEntityPartner.PartnerName = txtPartName.Text.ToUpper().Trim();
            objEntityPartner.PartshipTypeId = Convert.ToInt32(ddlPartshipTyp.SelectedItem.Value);
            objEntityPartner.Address1 = txtAdd1.Text.Trim();
            objEntityPartner.Address2 = txtAdd2.Text.Trim();
            objEntityPartner.Address3 = txtAdd3.Text.Trim();
            objEntityPartner.DocNum = txtDocNum.Text.Trim();
            objEntityPartner.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
            {
                //objEntityPartner.StateId = null;
                //objEntityPartner.CityId = null;
            }
            else
            {
                objEntityPartner.StateId = Convert.ToInt32(HiddenFieldState.Value);
                //If there is no city selected
                if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
                {
                    //  objEntityPartner.CityId = null;
                }
                else
                {
                    objEntityPartner.CityId = Convert.ToInt32(HiddenFieldCity.Value);

                }
            }
            objEntityPartner.ZipCode = txtZip.Text;
            objEntityPartner.Phone_Number = txtPhone.Text;
            objEntityPartner.Web_Address = txtWebsite.Text;
            objEntityPartner.Email_Address = txtEmail.Text;

            if (Session["USERID"] != null)
            {
                objEntityPartner.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPartner.Organisation_Id = Convert.ToInt32(Session["ORGID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPartner.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (cbxStatus.Checked == true)
            {
                objEntityPartner.StatusId = 1;
            }
            else
            {
                objEntityPartner.StatusId = 0;
            }

            objEntityPartner.Fax = txtFax.Text;
            objEntityPartner.EnqMail = txtEnqMail.Text;
            objEntityPartner.CRNnum = txtCRN.Text;
            objEntityPartner.TINnum = txtTIN.Text;
            objEntityPartner.CCNnum = txtCCN.Text;
            objEntityPartner.date = System.DateTime.Now;

            // start icon file upload

            //string iconfileid = "file0";
            //for (int intCount = 0; intCount < Request.Files.Count; intCount++)
            //{

            //    string fileId = Request.Files.AllKeys[intCount].ToString();
            //    HttpPostedFile PostedFile = Request.Files[intCount];
            //    if (fileId == iconfileid)
            //    {
            //        if (PostedFile.ContentLength > 0)
            //        {

            //            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
            //            string strFileExt;
            //            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
            //            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

            //            string strImageName = "Icon_" + intImageSection.ToString() + "_" + "." + strFileExt;

            //            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

            //            PostedFile.SaveAs(Server.MapPath(strImagePath) + strImageName);

            //            objEntityPartner.IconFname = strImageName;
            //            objEntityPartner.IconActFname = strFileName;

            //        }
            //    }
            //}

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CORPORATE_PARTNER);
            objEntityCommon.CorporateID = objEntityPartner.Corporate_id;
            objEntityCommon.Organisation_Id = objEntityPartner.Organisation_Id;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            objEntityPartner.NextId = Convert.ToInt32(strNextId);
            //new file Up
            if (FileUploadProPic.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;

                strFileExt = FileUploadProPic.FileName.Substring(FileUploadProPic.FileName.LastIndexOf('.') + 1).ToLower();
                string strFileName = FileUploadProPic.FileName;
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                string strImageName = "Corp_Icon_" + intImageSection.ToString() + "_" + objEntityPartner.NextId + "." + strFileExt;
                objEntityPartner.IconFname = strImageName;
                objEntityPartner.IconActFname = strFileName;
                //    if (hiddenUserImage.Value != "")
                //    {
                string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                string imageLocation = strImgPath + hiddenImageName.Value;
                if (File.Exists(MapPath(imageLocation)))
                {
                    File.Delete(MapPath(imageLocation));
                }
                //    }

            }

            else
            {
                if (hiddenUserImage.Value != "")
                {
                    objEntityPartner.IconFname = hiddenUserImage.Value;
                }
                else
                {
                    string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    string imageLocation = strImgPath + hiddenImageName.Value;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }

                    objEntityPartner.IconFname = null;
                    //  lblMessage.Text = "Please select image file.";
                }
            }
            
            //stop icon file upload
            string strCount = objBusinessPartner.CheckName(objEntityPartner);
            string strDocNumcount = objBusinessPartner.CheckDocnum(objEntityPartner);
            if (ddlPartshipTyp.SelectedItem.Text == "COMPANY")
            {
                //if company
                //Commercial Registration Number
                string strComRegNo = "";
                //Computer Card Number
                string strComCardNo = "";
                //Tax Identification Number
                string strTIN = "";
                strComRegNo = objBusinessPartner.CheckComRegNo(objEntityPartner);
                if (txtCCN.Text != "")
                {
                    strComCardNo = objBusinessPartner.CheckComCardNo(objEntityPartner);
                }
                else
                {
                    strComCardNo = "0";
                }
                strTIN = objBusinessPartner.CheckTIN(objEntityPartner);
                //Insertion Process
                if (strCount == "0" && strDocNumcount == "0" && strComRegNo == "0" && strComCardNo == "0" && strTIN == "0")
                {
                    objBusinessPartner.UpdatePartner(objEntityPartner);
                    //FOR SAVING DOCUMENTS
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    if (FileUploadProPic.HasFile)
                    {
                        FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityPartner.IconFname);
                    }
                    if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                    {
                        Response.Redirect("gen_Partner.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                    {
                        Response.Redirect("gen_PartnerList.aspx?InsUpd=Upd");
                    }
                }
                else
                {
                    if (strCount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                        txtPartName.Focus();
                    }
                    else if (strDocNumcount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDoc", "DuplicationDoc();", true);
                        txtDocNum.Focus();
                    }
                    else if (strComRegNo != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCRN", "DuplicationCRN();", true);
                        txtCRN.Focus();
                    }
                    else if (strComCardNo != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCCN", "DuplicationCCN();", true);
                        txtCCN.Focus();
                    }
                    else if (strTIN != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationTIN", "DuplicationTIN();", true);
                        txtTIN.Focus();
                    }
                }
            }
            else
            {

                //Insertion Process
                if (strCount == "0" && strDocNumcount == "0")
                {
                    objBusinessPartner.UpdatePartner(objEntityPartner);
                    //FOR SAVING DOCUMENTS
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
                    if (FileUploadProPic.HasFile)
                    {
                        FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityPartner.IconFname);
                    }
                    if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                    {
                        Response.Redirect("gen_Partner.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                    {
                        Response.Redirect("gen_PartnerList.aspx?InsUpd=Upd");
                    }
                }
                else
                {
                    if (strCount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                        txtPartName.Focus();
                    }
                    else if (strDocNumcount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDoc", "DuplicationDoc();", true);
                        txtDocNum.Focus();
                    }
                }
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
}