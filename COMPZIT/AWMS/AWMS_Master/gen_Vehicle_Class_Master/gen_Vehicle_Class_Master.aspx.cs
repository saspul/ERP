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
// CREATED BY:EVM-0005
// CREATED DATE:19/12/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Vehicle_Class_Master_gen_Vehicle_Class_Master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

      
            txtName.Attributes.Add("onkeypress", "return isTag(event)");
            txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            ddlVhclCategoryType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
            cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
            if (!IsPostBack)
            {
                VehicleTypeLoad();
                int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }

                txtName.Focus();
                int intCorpId = 0;
                if (Session["CORPOFFICEID"] != null)
                {

                    intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }




                //when editing 
                if (Request.QueryString["Id"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["Id"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    Update(strId, intCorpId);
                    lblEntry.Text = "Edit Vehicle Class";

                }
                //when  viewing
                else if (Request.QueryString["ViewId"] != null)
                {
                    btnClear.Visible = false;
                    string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                    string strLenghtofId = strRandomMixedId.Substring(0, 2);
                    int intLenghtofId = Convert.ToInt16(strLenghtofId);
                    string strId = strRandomMixedId.Substring(2, intLenghtofId);

                    View(strId, intCorpId);

                    lblEntry.Text = "View Vehicle Class";
                }
                else
                {
                    lblEntry.Text = "Add Vehicle Class";

                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnAdd.Visible = true;
                    btnAddClose.Visible = true;
                    btnClear.Visible = true;
                    if (Request.QueryString["InsUpd"] != null)
                    {
                        string strInsUpd = Request.QueryString["InsUpd"].ToString();
                        if (strInsUpd == "Ins")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                        }
                        else if (strInsUpd == "Upd")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessUpdation();", true);  

                        }
                    }
                }
                //Allocating child roles
                intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Vehicle_Class);
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
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                        {
                            //future

                        }

                    }
                }

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {


                }
                else
                {

                    btnUpdate.Visible = false;

                }


            }
            ImageDisplay();
           
        }

    protected void VehicleTypeLoad()
    {
        clsBusinessLayerVehicleClass objBusinessVehicle = new clsBusinessLayerVehicleClass();
        DataTable dtVehDetails = new DataTable();
        dtVehDetails = objBusinessVehicle.ReadVehicleCategoryType();
        if (dtVehDetails.Rows.Count > 0)
        {
            ddlVhclCategoryType.DataSource = dtVehDetails;
            ddlVhclCategoryType.DataValueField = "VHCL_CTGRYTYP_ID";
            ddlVhclCategoryType.DataTextField = "VHCL_CTGRYTYP_NAME";
            ddlVhclCategoryType.DataBind();
           // ddlVhclCategoryType.SelectedIndex = ddlVhclCategoryType.Items.IndexOf(ddlVhclCategoryType.Items.FindByText("NORMAL")); 
        }
    }
    public void ImageDisplay()
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerVehicleClass objEntityVehicle = new clsEntityLayerVehicleClass();
        clsBusinessLayerVehicleClass objBusinessVehicle = new clsBusinessLayerVehicleClass();
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        int intAppMode = Convert.ToInt32(clsCommonLibrary.Section.VEHICLE_CLASS);
        objEntityVehicle.AppModeSection = intAppMode;
        DataTable dtImageDetails = new DataTable();
        dtImageDetails = objBusinessVehicle.ReadImageDetails(objEntityVehicle);

        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));
        StringBuilder sb = new StringBuilder();
        string strHtml = "";

        if (dtImageDetails.Rows.Count > 0)
        {
            for (int intCount = 0; intCount < dtImageDetails.Rows.Count; intCount++)
            {

                string ImageNmae = dtImageDetails.Rows[intCount]["GNIMGSCT_IMGNAME"].ToString();
                string imageId = dtImageDetails.Rows[intCount]["GNIMGSCT_ID"].ToString();

                strHtml += "<div style=\"width:47px;height:40px;cursor: pointer;float:left;margin-top: 5px;margin-left: 5px;\" onclick=\"return SelectImage('" + imageId + "');\"> <input type=\"image\" style=\"width:40px;height:40px;border:.5px solid;border-color:#ceb6b6;\"  id=\"vector-" + imageId + "\" src=" + strImagePath + "" + ImageNmae + " alt=\"vehicle\" onclick=\"IncrmntConfrmCounter();\"></input></div>";


            }
        }

        divImageContainer.InnerHtml = strHtml;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        clsEntityLayerVehicleClass objEntityVehicle = new clsEntityLayerVehicleClass();
        clsBusinessLayerVehicleClass objBusinessVehicle = new clsBusinessLayerVehicleClass();
        objEntityVehicle.ClassId = Convert.ToInt32(strP_Id);
        objEntityVehicle.Corporate_id = intCorpId;
        DataTable dtVehicleClassById = objBusinessVehicle.ReadVehicleClassById(objEntityVehicle);
        if (dtVehicleClassById.Rows.Count > 0)
        {

            txtName.Text = dtVehicleClassById.Rows[0]["VHCLCLS_NAME"].ToString();
            int intImageId = Convert.ToInt32(dtVehicleClassById.Rows[0]["GNIMGSCT_ID"]);
            ScriptManager.RegisterStartupScript(this, GetType(), "SelectImage", "SelectImage('"+intImageId+"');", true);
            hiddenSelectedImage.Value = Convert.ToString(intImageId);
            ddlVhclCategoryType.Items.FindByValue(dtVehicleClassById.Rows[0]["VHCL_CTGRYTYP_ID"].ToString()).Selected = true;
            int intVehicleClassStatus = Convert.ToInt32(dtVehicleClassById.Rows[0]["VHCLCLS_STATUS"]);
            if (intVehicleClassStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }
      //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        clsEntityLayerVehicleClass objEntityVehicle = new clsEntityLayerVehicleClass();
        clsBusinessLayerVehicleClass objBusinessVehicle = new clsBusinessLayerVehicleClass();
        objEntityVehicle.ClassId = Convert.ToInt32(strP_Id);
        objEntityVehicle.Corporate_id = intCorpId;
        DataTable dtVehicleClassById = objBusinessVehicle.ReadVehicleClassById(objEntityVehicle);
        if (dtVehicleClassById.Rows.Count > 0)
        {

            txtName.Text = dtVehicleClassById.Rows[0]["VHCLCLS_NAME"].ToString();
            int intImageId = Convert.ToInt32(dtVehicleClassById.Rows[0]["GNIMGSCT_ID"]);
           
            ScriptManager.RegisterStartupScript(this, GetType(), "SelectImage", "SelectImage('" + intImageId + "');", true);
            ddlVhclCategoryType.Items.FindByValue(dtVehicleClassById.Rows[0]["VHCL_CTGRYTYP_ID"].ToString()).Selected = true;
            int intVehicleClassStatus = Convert.ToInt32(dtVehicleClassById.Rows[0]["VHCLCLS_STATUS"]);
            if (intVehicleClassStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtName.Enabled = false;
        divImageContainer.Attributes["style"] = "float: left;width: 38.3%;height: 97px;border:1px solid;border-color:#ceb6b6;margin-left: 42.5%;;pointer-events: none;";
        cbxStatus.Enabled = false;
        ddlVhclCategoryType.Enabled = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityLayerVehicleClass objEntityVehicle = new clsEntityLayerVehicleClass();
        clsBusinessLayerVehicleClass objBusinessVehicle = new clsBusinessLayerVehicleClass();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (cbxStatus.Checked == true)
        {
            objEntityVehicle.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityVehicle.Status_id = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityVehicle.Date = System.DateTime.Now;    
        objEntityVehicle.ClassName = txtName.Text.ToUpper().Trim();
        objEntityVehicle.ImageId = Convert.ToInt32(hiddenSelectedImage.Value);
        objEntityVehicle.CategoryTypeId = Convert.ToInt32(ddlVhclCategoryType.SelectedItem.Value);
        //Checking is there table have any name like this
        string strNameCount = objBusinessVehicle.CheckVehicleClassName(objEntityVehicle);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
           
            objBusinessVehicle.AddVehicleClass(objEntityVehicle);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Vehicle_Class_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Vehicle_Class_Master_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {


            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);      
            ScriptManager.RegisterStartupScript(this, GetType(), "SelectImage", "SelectImage('" + objEntityVehicle.ImageId + "');", true);
            txtName.Focus();

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityLayerVehicleClass objEntityVehicle = new clsEntityLayerVehicleClass();
            clsBusinessLayerVehicleClass objBusinessVehicle = new clsBusinessLayerVehicleClass();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityVehicle.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityVehicle.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (cbxStatus.Checked == true)
            {
                objEntityVehicle.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityVehicle.Status_id = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityVehicle.ClassId = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityVehicle.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityVehicle.Date = System.DateTime.Now;
            objEntityVehicle.ImageId = Convert.ToInt32(hiddenSelectedImage.Value);
            objEntityVehicle.CategoryTypeId = Convert.ToInt32(ddlVhclCategoryType.SelectedItem.Value);
            objEntityVehicle.ClassName = txtName.Text.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = objBusinessVehicle.CheckVehicleClassName(objEntityVehicle);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
               
                objBusinessVehicle.UpdateVehicleClass(objEntityVehicle);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Vehicle_Class_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Vehicle_Class_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have

            else
            {


                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "SelectImage", "SelectImage('" + Convert.ToInt32(hiddenSelectedImage.Value) + "');", true);
                txtName.Focus();
            }
        }
    }
   
 }
   