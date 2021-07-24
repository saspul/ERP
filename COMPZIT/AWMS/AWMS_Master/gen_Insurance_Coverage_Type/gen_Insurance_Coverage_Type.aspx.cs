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

public partial class AWMS_AWMS_Master_gen_Insurance_Coverage_Type_gen_Insurance_Coverage_Type : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtName.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {

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
                lblEntry.Text = "Edit Insurance Coverage";

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

                lblEntry.Text = "View Insurance Coverage";
               
            }
            else
            {
                lblEntry.Text = "Add Insurance Coverage";

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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Coverage_Type);
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
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        clsEntityLayerInsuranceCoverageType objEntityCoverageType = new clsEntityLayerInsuranceCoverageType();
        clsBusinessLayerInsuranceCoverageType objBusinessCoverageType = new clsBusinessLayerInsuranceCoverageType();
        objEntityCoverageType.CoverageTypeId = Convert.ToInt32(strP_Id);
        objEntityCoverageType.Corporate_id = intCorpId;
        DataTable dtVehicleClassById = objBusinessCoverageType.ReadCoverageTypeById(objEntityCoverageType);
        if (dtVehicleClassById.Rows.Count > 0)
        {

            txtName.Text = dtVehicleClassById.Rows[0]["COVRGTYP_NAME"].ToString();

            int intVehicleClassStatus = Convert.ToInt32(dtVehicleClassById.Rows[0]["COVRGTYP_STATUS"]);
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
        clsEntityLayerInsuranceCoverageType objEntityCoverageType = new clsEntityLayerInsuranceCoverageType();
        clsBusinessLayerInsuranceCoverageType objBusinessCoverageType = new clsBusinessLayerInsuranceCoverageType();
        objEntityCoverageType.CoverageTypeId = Convert.ToInt32(strP_Id);
        objEntityCoverageType.Corporate_id = intCorpId;
        DataTable dtVehicleClassById = objBusinessCoverageType.ReadCoverageTypeById(objEntityCoverageType);
        if (dtVehicleClassById.Rows.Count > 0)
        {

            txtName.Text = dtVehicleClassById.Rows[0]["COVRGTYP_NAME"].ToString();

            int intVehicleClassStatus = Convert.ToInt32(dtVehicleClassById.Rows[0]["COVRGTYP_STATUS"]);
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
        cbxStatus.Enabled = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityLayerInsuranceCoverageType objEntityCoverageType = new clsEntityLayerInsuranceCoverageType();
            clsBusinessLayerInsuranceCoverageType objBusinessCoverageType = new clsBusinessLayerInsuranceCoverageType();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCoverageType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCoverageType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (cbxStatus.Checked == true)
            {
                objEntityCoverageType.Status_id = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityCoverageType.Status_id = 0;
            }
            if (Session["USERID"] != null)
            {
                objEntityCoverageType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityCoverageType.Date = System.DateTime.Now;
            objEntityCoverageType.CoverageTypeName = txtName.Text.ToUpper().Trim();
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCoverageType.CoverageTypeId = Convert.ToInt32(strId);
           
           
            //Checking is there table have any name like this
            string strNameCount = objBusinessCoverageType.CheckCoverageTypeName(objEntityCoverageType);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {

                objBusinessCoverageType.UpdateCoverageType(objEntityCoverageType);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Insurance_Coverage_Type.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Insurance_Coverage_Type_List.aspx?InsUpd=Upd");
                }

            }
            //If have

            else
            {


                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtName.Focus();
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityLayerInsuranceCoverageType objEntityCoverageType = new clsEntityLayerInsuranceCoverageType();
        clsBusinessLayerInsuranceCoverageType objBusinessCoverageType = new clsBusinessLayerInsuranceCoverageType();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCoverageType.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCoverageType.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (cbxStatus.Checked == true)
        {
            objEntityCoverageType.Status_id = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityCoverageType.Status_id = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityCoverageType.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityCoverageType.Date = System.DateTime.Now;
        objEntityCoverageType.CoverageTypeName = txtName.Text.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = objBusinessCoverageType.CheckCoverageTypeName(objEntityCoverageType);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {

            objBusinessCoverageType.AddCoverageType(objEntityCoverageType);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Insurance_Coverage_Type.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Insurance_Coverage_Type_List.aspx?InsUpd=Ins");
            }

        }
        //If have
        else
        {


             ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
             txtName.Focus();

        }
    }
}