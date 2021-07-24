using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Data;


public partial class MasterPage_Default : System.Web.UI.Page
{
    clsBusinessLayerUomMaster objBusinessUOM = new clsBusinessLayerUomMaster();
    clsEntityCommon objEntityCommon = new clsEntityCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUnitName.Attributes.Add("onkeypress", "return isTag(event)");
        txtUnitName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtUnitDescription.Attributes.Add("onkeypress", "return isTag(event)");
        txtUnitDescription.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        if (!IsPostBack)
        {
            txtUnitName.Focus();


            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Unit of Measure";
                lblEntryB.InnerText = "Edit Unit of Measure";
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
                lblEntry.InnerText = "View Unit of Measure";
                lblEntryB.InnerText = "View Unit of Measure";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add Unit of Measure";
                lblEntryB.InnerText = "Add Unit of Measure";
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
    public void Update(string strC_Id)
    {
        if (strC_Id != "")
        {
            clsEntityUomMaster objUomMaster = new clsEntityUomMaster();
            objUomMaster.Uom_Id = Convert.ToInt32(strC_Id);
            DataTable dtEditUOM = new DataTable();
            dtEditUOM = objBusinessUOM.ReadUomById(objUomMaster);


            txtUnitName.Text = dtEditUOM.Rows[0]["UOM_NAME"].ToString();
            txtUnitDescription.Text = dtEditUOM.Rows[0]["UOM_DESCRIPTION"].ToString();
            if (dtEditUOM.Rows[0]["UOM_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtUnitName.Enabled = true;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = true;
            btnUpdateCloseF.Visible = true;
        }
    }
    //Fetch the new datatable from businesslayer and set separately in each field. 
    public void View(string strC_Id)
    {
        if (strC_Id != "")
        {
            clsEntityUomMaster objUomMaster = new clsEntityUomMaster();
            objUomMaster.Uom_Id = Convert.ToInt32(strC_Id);
            DataTable dtEditUOM = new DataTable();
            dtEditUOM = objBusinessUOM.ReadUomById(objUomMaster);


            txtUnitName.Text = dtEditUOM.Rows[0]["UOM_NAME"].ToString();
            txtUnitDescription.Text = dtEditUOM.Rows[0]["UOM_DESCRIPTION"].ToString();
            if (dtEditUOM.Rows[0]["UOM_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtUnitName.Enabled = false;
            txtUnitDescription.Enabled = false;
            //cbxStatus.Enabled = false;
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
    }


    //When Save Button while editing  is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {
            clsEntityUomMaster objUomMaster = new clsEntityUomMaster();
            objUomMaster.Unit_Status = 1;
            if (cbxStatus.Checked == false)
            {
                objUomMaster.Unit_Status = 0;
            }
            objUomMaster.Uom_name = txtUnitName.Text.ToUpper().Trim();
            objUomMaster.Uom_Code = txtUnitDescription.Text.ToUpper().Trim();
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objUomMaster.Uom_Id = Convert.ToInt32(strId);

            objUomMaster.D_Date = System.DateTime.Now;

            if (Session["USERID"] != null)
            {
                objUomMaster.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objUomMaster.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objUomMaster.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            string strUnitNameCount = objBusinessUOM.CheckUomName(objUomMaster);
            string strUnitDescCount = objBusinessUOM.CheckUomCode(objUomMaster);
            if (strUnitNameCount == "0" && strUnitDescCount == "0")
            {

                DataTable dtComplaintDetail = objBusinessUOM.ReadUomById(objUomMaster);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["UOM_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["UOM_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessUOM.UpdateUom(objUomMaster);
                        if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                        {
                            Response.Redirect("gen_UomMaster.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                        {
                            Response.Redirect("gen_UomMasterList.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_UomMasterList.aspx?InsUpd=AlCncl");
                    }
                }      
            }
            else
            {
                if (strUnitDescCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDescptn", "DuplicationDescptn();", true);
                    txtUnitDescription.Focus();
                }
                if (strUnitNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtUnitName.Focus();
                }
            }
        }
    }
    //On SaveSubmit Button Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityUomMaster objUomMaster = new clsEntityUomMaster();
        objUomMaster.Unit_Status = 1;
        if (cbxStatus.Checked == false)
        {
            objUomMaster.Unit_Status = 0;
        }
        objUomMaster.Uom_name = txtUnitName.Text.ToUpper().Trim();
        objUomMaster.Uom_Code = txtUnitDescription.Text.ToUpper().Trim();
       

        objUomMaster.D_Date = System.DateTime.Now;

        if (Session["USERID"] != null)
        {
            objUomMaster.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objUomMaster.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objUomMaster.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        string strUnitNameCount = objBusinessUOM.CheckUomName(objUomMaster);
        string strUnitDescCount = objBusinessUOM.CheckUomCode(objUomMaster);
        if (strUnitNameCount == "0" && strUnitDescCount == "0")
        {

            objBusinessUOM.AddUomMaster(objUomMaster);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_UomMaster.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_UomMasterList.aspx?InsUpd=Ins");
            }
         

        }
        else
        {
            if (strUnitDescCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationDescptn", "DuplicationDescptn();", true);
                txtUnitDescription.Focus();
            }
            if (strUnitNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtUnitName.Focus();
            }
        }

    }
}