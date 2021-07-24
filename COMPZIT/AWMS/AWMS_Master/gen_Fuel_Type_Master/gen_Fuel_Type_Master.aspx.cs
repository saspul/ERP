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
// CREATED BY:EVM-0008
// CREATED DATE:25/11/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class AWMS_AWMS_Master_gen_Fuel_Type_Master_gen_Fuel_Type_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (hiddenSelectedImage.Value != "")
        {
            var image = hiddenSelectedImage.Value;
            // hiddenSelectedImage.Value = image;
            ScriptManager.RegisterStartupScript(this, GetType(), "FillVehicleClassTextBox", "FillVehicleClassTextBox(" + image + ");", true);
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
                lblEntry.Text = "Edit Fuel Type";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.Text = "View Fuel Type";
            }

            else
            {
                lblEntry.Text = "Add Fuel Type";

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
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
        clsEntityLayerFuelType objEntityFuel = new clsEntityLayerFuelType();
        clsBusniessLayerFuelType objBusinessFuel = new clsBusniessLayerFuelType();
        if (Session["ORGID"] != null)
        {
            objEntityFuel.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intAppMode = Convert.ToInt32(clsCommonLibrary.Section.FUEL_TYPE);
        objEntityFuel.AppModeSection = intAppMode;
        DataTable dtImageDetails = new DataTable();
        dtImageDetails = objBusinessFuel.ReadImageDetails(objEntityFuel);

        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));
        StringBuilder sb = new StringBuilder();
        string strHtml = "";

        if (dtImageDetails.Rows.Count > 0)
        {
            for (int intCount = 0; intCount < dtImageDetails.Rows.Count; intCount++)
            {
                string ImageName = dtImageDetails.Rows[intCount]["GNIMGSCT_IMGNAME"].ToString();
                string[] ImageNameSplit = ImageName.Split('.');
                string ImageWtName = ImageNameSplit[0] + "_wt." + ImageNameSplit[1];
                string imageId = dtImageDetails.Rows[intCount]["GNIMGSCT_ID"].ToString();

                strHtml += "<a href=\"javascript:;\" onclick=\"return SelectImage('" + imageId + "');\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('vhl2','','" + strImagePath + "" + ImageWtName + "',1)\">";
                strHtml += "<button id=\"btn-" + imageId + "\" class=\"vhl_1 fu1\">";
                strHtml += "<img id=\"vector-" + imageId + "\" src=\"" + strImagePath + "" + ImageName + "\" alt=\"Fuel\" width=\"50\" height=\"30\">";
                strHtml += "</button>";
                strHtml += "</a>";
            }
        }

        divImageContainer.InnerHtml = strHtml;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerFuelType objEntityFuel = new clsEntityLayerFuelType();
        clsBusniessLayerFuelType objBusinessFuel = new clsBusniessLayerFuelType();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityFuel.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityFuel.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityFuel.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityFuel.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityFuel.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityFuel.FuelId = Convert.ToInt32(strId);
            string strNameCount = "0";
            if (txtName.Text != "" && txtName.Text != null)
            {
                objEntityFuel.ClassName = txtName.Text.Trim().ToUpper();
                strNameCount = objBusinessFuel.CheckFuelTypeName(objEntityFuel);
            }
              objEntityFuel.ImageId = Convert.ToInt32(hiddenSelectedImage.Value);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessFuel.UpdateFuelType(objEntityFuel);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Fuel_Type_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Fuel_Type_Master_List.aspx?InsUpd=Upd");
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
        clsEntityLayerFuelType objEntityFuel = new clsEntityLayerFuelType();
        clsBusniessLayerFuelType objBusinessFuel = new clsBusniessLayerFuelType();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityFuel.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityFuel.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityFuel.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityFuel.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityFuel.Status_id = 0;
        }

        string strNameCount = "0";
        if (txtName.Text != "" && txtName.Text != null)
        {
            objEntityFuel.ClassName = txtName.Text.Trim().ToUpper();
            strNameCount = objBusinessFuel.CheckFuelTypeName(objEntityFuel);
        }

        objEntityFuel.ImageId = Convert.ToInt32(hiddenSelectedImage.Value);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessFuel.AddFuelType(objEntityFuel);

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Fuel_Type_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Fuel_Type_Master_List.aspx?InsUpd=Ins");
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
        clsEntityLayerFuelType objEntityFuel = new clsEntityLayerFuelType();
        clsBusniessLayerFuelType objBusinessFuel = new clsBusniessLayerFuelType();

        objEntityFuel.FuelId = Convert.ToInt32(strWId);
        DataTable dtFuelTypDetail = new DataTable();
        dtFuelTypDetail = objBusinessFuel.ReadFuelTypeById(objEntityFuel);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtFuelTypDetail.Rows.Count > 0)
        {
            txtName.Text = dtFuelTypDetail.Rows[0]["FUELTYP_NAME"].ToString();
            objEntityFuel.ImageId = Convert.ToInt32(dtFuelTypDetail.Rows[0]["GNIMGSCT_ID"].ToString());
            var image = dtFuelTypDetail.Rows[0]["GNIMGSCT_ID"].ToString();
            if (image != "")
            {
                hiddenSelectedImage.Value = image;
                ScriptManager.RegisterStartupScript(this, GetType(), "FillVehicleClassTextBox", "FillVehicleClassTextBox(" + image + ");", true);
            }
            int intInsuretStatus = Convert.ToInt32(dtFuelTypDetail.Rows[0]["FUELTYP_STATUS"]);
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
        divImageContainer.Attributes["style"] = "pointer-events: none;";


         

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        cbxStatus.Disabled = true;
        cbxStatus.Attributes["style"] = "pointer-events: none;";
    }

     //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWId)
    {

        clsEntityLayerFuelType objEntityFuel = new clsEntityLayerFuelType();
        clsBusniessLayerFuelType objBusinessFuel = new clsBusniessLayerFuelType();
        objEntityFuel.FuelId = Convert.ToInt32(strWId);
        DataTable dtFuelTypDetail = new DataTable();
        dtFuelTypDetail = objBusinessFuel.ReadFuelTypeById(objEntityFuel);
        //After fetch insurance details in datatable,we need to differentiate.
        if (dtFuelTypDetail.Rows.Count > 0)
        {
            txtName.Text = dtFuelTypDetail.Rows[0]["FUELTYP_NAME"].ToString();
            var image = dtFuelTypDetail.Rows[0]["GNIMGSCT_ID"].ToString();
             if (image != "")
            {
                hiddenSelectedImage.Value = image;
                ScriptManager.RegisterStartupScript(this, GetType(), "FillVehicleClassTextBox", "FillVehicleClassTextBox(" + image + ");", true);
            }
             int intInsuretStatus = Convert.ToInt32(dtFuelTypDetail.Rows[0]["FUELTYP_STATUS"]);
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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Fuel_Type);
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

        }
        else
        {

            btnUpdate.Visible = false;

        }

        btnClear.Visible = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdateClose.Visible = true;
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("gen_Fuel_Type_Master.aspx");
    }
}
   



