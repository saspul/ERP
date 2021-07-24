using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using System.Web.Services;
using System.IO;
//using BL
// CREATED BY:WEM-0006
// CREATED DATE:12/10/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_License_Type_Master_gen_License_Type_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     //   cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (hiddenSelectedImage.Value != "")
        {
            var image = hiddenSelectedImage.Value;
            // hiddenSelectedImage.Value = image;
            ScriptManager.RegisterStartupScript(this, GetType(), "FillLicenseTextBox", "FillLicenseTextBox(" + image + ");", true);
        }

        if (!IsPostBack)
        {
            txtName.Focus();
            ImageDisplay();



            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit License Type";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText= "View License Type";
            }

            else
            {
                lblEntry.InnerText= "Add License Type";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnUpdatef.Visible = false;
                btnUpdateClosef.Visible = false;
                btnAddf.Visible = true;
                btnAddClosef.Visible = true;
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

    public void ImageDisplay()
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerLicenseType objBusinessLicense = new clsBusinessLayerLicenseType();
        clsEntityLayerLicenseType objEntityLicenseType = new clsEntityLayerLicenseType();
                if (Session["ORGID"] != null)
        {
            objEntityLicenseType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intAppMode = Convert.ToInt32(clsCommonLibrary.Section.LICENSE_TYPE);
        objEntityLicenseType.AppModeSection = intAppMode;
        DataTable dtImageDetails = new DataTable();
        dtImageDetails = objBusinessLicense.ReadImageDetails(objEntityLicenseType);

        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));
        StringBuilder sb = new StringBuilder();
        string strHtml = "";

        if (dtImageDetails.Rows.Count > 0)
        {
            for (int intCount = 0; intCount < dtImageDetails.Rows.Count; intCount++)
            {

                string ImageName = dtImageDetails.Rows[intCount]["GNIMGSCT_IMGNAME"].ToString();
                string imageId = dtImageDetails.Rows[intCount]["GNIMGSCT_ID"].ToString();

                strHtml += "<div class=\"vhl_1 \" onclick=\"return SelectImage('" + imageId + "');\"> <input  type=\"image\" style=\"width:80px;height:50px;\"  id=\"vector-" + imageId + "\" src=" + strImagePath + "" + ImageName + " alt=\"vehicle\" ></input></div>";


            }
        }

        divImageContainer.InnerHtml = strHtml;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerLicenseType objBusinessLicense = new clsBusinessLayerLicenseType();
        clsEntityLayerLicenseType objEntityLicenseType = new clsEntityLayerLicenseType();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLicenseType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLicenseType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityLicenseType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityLicenseType.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityLicenseType.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strWaterId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityLicenseType.LtypId = Convert.ToInt32(strWaterId);
            string strNameCount = "0";
            if (txtName.Text != "" && txtName.Text != null)
            {
                objEntityLicenseType.ClassName = txtName.Text.Trim().ToUpper();
                strNameCount = objBusinessLicense.CheckLicenseTypeName(objEntityLicenseType);
            }
            objEntityLicenseType.ImageId = Convert.ToInt32(hiddenSelectedImage.Value);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLicense.UpdateLicenseType(objEntityLicenseType);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_License_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_License_Type_Master_List.aspx?InsUpd=Upd");
                }
               else if (clickedButton.ID == "btnUpdatef")
                {
                    Response.Redirect("gen_License_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClosef")
                {
                    Response.Redirect("gen_License_Type_Master_List.aspx?InsUpd=Upd");
                }
            }
            //If have
            else
            {
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

                }

            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerLicenseType objBusinessLicense = new clsBusinessLayerLicenseType();
        clsEntityLayerLicenseType objEntityLicenseType = new clsEntityLayerLicenseType();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLicenseType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLicenseType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityLicenseType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityLicenseType.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityLicenseType.Status_id = 0;
        }

        string strNameCount = "0";
        if (txtName.Text != "" && txtName.Text != null)
        {
            objEntityLicenseType.ClassName = txtName.Text.Trim().ToUpper();
            strNameCount = objBusinessLicense.CheckLicenseTypeName(objEntityLicenseType);
        }

        objEntityLicenseType.ImageId = Convert.ToInt32(hiddenSelectedImage.Value);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLicense.AddLicenseType(objEntityLicenseType);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_License_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_License_Type_Master_List.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddf")
            {
                Response.Redirect("gen_License_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClosef")
            {
                Response.Redirect("gen_License_Type_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);

            }

        }
    }

    public void View(string strWId)
    {
        clsBusinessLayerLicenseType objBusinessLicense = new clsBusinessLayerLicenseType();
        clsEntityLayerLicenseType objEntityLicenseType = new clsEntityLayerLicenseType();

        objEntityLicenseType.LtypId = Convert.ToInt32(strWId);
        DataTable dtLicTypDetail = new DataTable();
        dtLicTypDetail = objBusinessLicense.ReadLicenseTypeById(objEntityLicenseType);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtLicTypDetail.Rows.Count > 0)
        {
            txtName.Text = dtLicTypDetail.Rows[0]["VHCLLCNSTYP_NAME"].ToString();
            objEntityLicenseType.ImageId = Convert.ToInt32(dtLicTypDetail.Rows[0]["GNIMGSCT_ID"].ToString());
            var image = dtLicTypDetail.Rows[0]["GNIMGSCT_ID"].ToString();
            if (image != "")
            {
                hiddenSelectedImage.Value = image;
                ScriptManager.RegisterStartupScript(this, GetType(), "FillLicenseTextBox", "FillLicenseTextBox(" + image + ");", true);
            }
            int intInsuretStatus = Convert.ToInt32(dtLicTypDetail.Rows[0]["VHCLLCNSTYP_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtName.Enabled = false;
        // divImageContainer.Disabled = true;
        divImageContainer.Attributes["style"] = "pointer-events: none;backgroundColor:dedede;width: 34.3%;margin-left: 28.5%;height: 97px;overflow: auto;border: 1px solid rgb(207, 204, 204);background-color: white";




        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnClearf.Visible = false;
        btnAddf.Visible = false;
        btnAddClosef.Visible = false;
        btnUpdatef.Visible = false;
        btnUpdateClosef.Visible = false;
        cbxStatus.Enabled = false;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
    }

    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWId)
    {

        clsBusinessLayerLicenseType objBusinessLicense = new clsBusinessLayerLicenseType();
        clsEntityLayerLicenseType objEntityLicenseType = new clsEntityLayerLicenseType();
        objEntityLicenseType.LtypId = Convert.ToInt32(strWId);
        DataTable dtLicTypDetail = new DataTable();
        dtLicTypDetail = objBusinessLicense.ReadLicenseTypeById(objEntityLicenseType);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtLicTypDetail.Rows.Count > 0)
        {
            txtName.Text = dtLicTypDetail.Rows[0]["VHCLLCNSTYP_NAME"].ToString();
            var image = dtLicTypDetail.Rows[0]["GNIMGSCT_ID"].ToString();
            if (image != "")
            {
                hiddenSelectedImage.Value = image;
                ScriptManager.RegisterStartupScript(this, GetType(), "FillLicenseTextBox", "FillLicenseTextBox(" + image + ");", true);
            }
            int intInsuretStatus = Convert.ToInt32(dtLicTypDetail.Rows[0]["VHCLLCNSTYP_STATUS"]);
            if (intInsuretStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

        }


        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.License_Type);
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
            }
        }
        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate.Visible = true;
            btnUpdatef.Visible = true;
        }
        else
        {

            btnUpdate.Visible = false;
            btnUpdatef.Visible = false;

        }

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;
        btnClearf.Visible = false;
        btnAddf.Visible = false;
        btnAddClosef.Visible = false;
        btnUpdateClosef.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_License_Type_Master.aspx");
    }
}