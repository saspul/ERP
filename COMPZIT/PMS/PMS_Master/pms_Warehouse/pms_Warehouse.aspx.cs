using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EL_Compzit;
using EL_Compzit.EntityLayer_PMS;
using BL_Compzit;
using BL_Compzit.BusinessLayer_PMS;
using System.Web.Services;
using System.IO;
using System.Text;

public partial class PMS_PMS_Master_pms_Warehouse_pms_Warehouse : System.Web.UI.Page
{
    clsEntityWarehouse objEntityWarehs = new clsEntityWarehouse();
    clsBusinessLayerWarehouse objBusinessWarehs = new clsBusinessLayerWarehouse();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCountry();
            LoadState(0);
            LoadCity(0);

            if (Session["USERID"] != null)
            {
                objEntityWarehs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWarehs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["ORGID"] != null)
            {
                objEntityWarehs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                btnUpdate.Visible = true;
                btnUpdateAndClose.Visible = true;
                btnSave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnClear.Visible = false;
                lblEntry.Text = "Edit Warehouse";
                UpdateView(strId);
            }
            //when viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnSave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnClear.Visible = false;
                lblEntry.Text = "View Warehouse";
                UpdateView(strId);
            }
            else
            {
                btnSave.Visible = true;
                btnSaveAndClose.Visible = true;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                lblEntry.Text = "Add Warehouse";
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "Dup")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationMsg", "DuplicationMsg();", true);
                }
            }


            txtWrhsName.Focus();
        }
    }

    public void LoadCountry()
    {
        DataTable dtCountry = objBusinessWarehs.ReadCountry(objEntityWarehs);

        ddlCountry.Items.Clear();
        if (dtCountry.Rows.Count > 0)
        {
            ddlCountry.DataSource = dtCountry;
            ddlCountry.DataTextField = "CNTRY_NAME";
            ddlCountry.DataValueField = "CNTRY_ID";
            ddlCountry.DataBind();
        }
        ddlCountry.Items.Insert(0, "--Select Country--");
    }

    public void LoadState(int CntryId)
    {
        if (CntryId != 0)
        {
            objEntityWarehs.CntryId = Convert.ToInt32(CntryId);
        }
        DataTable dtState = objBusinessWarehs.ReadState(objEntityWarehs);

        ddlState.Items.Clear();
        if (dtState.Rows.Count > 0)
        {
            ddlState.DataSource = dtState;
            ddlState.DataTextField = "STATE_NAME";
            ddlState.DataValueField = "STATE_ID";
            ddlState.DataBind();
        }
        ddlState.Items.Insert(0, "--Select State--");
    }

    public void LoadCity(int StateId)
    {
        if (StateId != 0)
        {
            objEntityWarehs.StateId = Convert.ToInt32(StateId);
        }
        DataTable dtCity = objBusinessWarehs.ReadCity(objEntityWarehs);

        ddlCity.Items.Clear();
        if (dtCity.Rows.Count > 0)
        {
            ddlCity.DataSource = dtCity;
            ddlCity.DataTextField = "CITY_NAME";
            ddlCity.DataValueField = "CITY_ID";
            ddlCity.DataBind();
        }
        ddlCity.Items.Insert(0, "--Select City--");
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        int CntryId = 0;
        if (ddlCountry.SelectedItem.Value != null && ddlCountry.SelectedItem.Value != "--Select Country--")
        {
            CntryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
        }
        LoadState(CntryId);
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        int StateId = 0;
        if (ddlState.SelectedItem.Value != null && ddlState.SelectedItem.Value != "--Select State--")
        {
            StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
        }
        LoadCity(StateId);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityWarehs.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityWarehs.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityWarehs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityWarehs.WarehouseName = txtWrhsName.Text;
            objEntityWarehs.WarehouseCode = txtWrhsCode.Text;
            objEntityWarehs.Address1 = txtAddress1.Text;
            objEntityWarehs.Address2 = txtAddress2.Text;
            objEntityWarehs.Address3 = txtAddress3.Text;
            if (ddlCountry.SelectedItem.Value != "--Select Country--")
            {
                objEntityWarehs.CntryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            }
            if (ddlState.SelectedItem.Value != null && ddlState.SelectedItem.Value != "--Select State--")
            {
                objEntityWarehs.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
            }
            if (ddlCity.SelectedItem.Value != null && ddlCity.SelectedItem.Value != "--Select City--")
            {
                objEntityWarehs.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            }
            objEntityWarehs.PostalCode = txtPostalCode.Text;
            objEntityWarehs.Phone = txtPhone.Text;
            objEntityWarehs.Email = txtEmail.Text;
            if (cbxStatus.Checked == true)
            {
                objEntityWarehs.Status = 1;
            }
            else
            {
                objEntityWarehs.Status = 0;
            }

            objBusinessWarehs.InsertWarehouse(objEntityWarehs);

            if (clickedButton.ID == "btnSave")
            {
                Response.Redirect("pms_Warehouse.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnSaveAndClose")
            {
                Response.Redirect("pms_Warehouse_List.aspx?InsUpd=Ins");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
        }
    }

    public void UpdateView(string strId)
    {
        objEntityWarehs.WarehouseId = Convert.ToInt32(strId);

        DataTable dt = objBusinessWarehs.ReadWarehouseById(objEntityWarehs);

        if (dt.Rows.Count > 0)
        {
            txtWrhsName.Text = dt.Rows[0]["WRHS_NAME"].ToString();
            txtWrhsCode.Text = dt.Rows[0]["WRHS_CODE"].ToString();
            txtAddress1.Text = dt.Rows[0]["WRHS_ADRESS1"].ToString();
            txtAddress2.Text = dt.Rows[0]["WRHS_ADRESS2"].ToString();
            txtAddress3.Text = dt.Rows[0]["WRHS_ADRESS3"].ToString();

            LoadCountry();
            int CntryId = 0;
            if (dt.Rows[0]["CNTRY_ID"].ToString() != "")
            {
                if (ddlCountry.Items.FindByValue(dt.Rows[0]["CNTRY_ID"].ToString()) != null)
                {
                    ddlCountry.Items.FindByValue(dt.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["CNTRY_NAME"].ToString(), dt.Rows[0]["CNTRY_ID"].ToString());
                    ddlCountry.Items.Insert(0, lstGrp);
                    ddlCountry.Items.FindByValue(dt.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                }
                CntryId = Convert.ToInt32(dt.Rows[0]["CNTRY_ID"].ToString());
            }

            LoadState(CntryId);
            int StateId = 0;
            if (dt.Rows[0]["STATE_ID"].ToString() != "")
            {
                if (ddlState.Items.FindByValue(dt.Rows[0]["STATE_ID"].ToString()) != null)
                {
                    ddlState.Items.FindByValue(dt.Rows[0]["STATE_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["STATE_NAME"].ToString(), dt.Rows[0]["STATE_ID"].ToString());
                    ddlState.Items.Insert(0, lstGrp);
                    ddlState.Items.FindByValue(dt.Rows[0]["STATE_ID"].ToString()).Selected = true;
                }
                StateId = Convert.ToInt32(dt.Rows[0]["STATE_ID"].ToString());
            }

            LoadCity(StateId);
            if (dt.Rows[0]["CITY_ID"].ToString() != "")
            {
                if (ddlCity.Items.FindByValue(dt.Rows[0]["CITY_ID"].ToString()) != null)
                {
                    ddlCity.Items.FindByValue(dt.Rows[0]["CITY_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["CITY_NAME"].ToString(), dt.Rows[0]["CITY_ID"].ToString());
                    ddlCity.Items.Insert(0, lstGrp);
                    ddlCity.Items.FindByValue(dt.Rows[0]["CITY_ID"].ToString()).Selected = true;
                }
            }

            txtPostalCode.Text = dt.Rows[0]["WRHS_POSTCODE"].ToString();
            txtPhone.Text = dt.Rows[0]["WRHS_PHONE"].ToString();
            txtEmail.Text = dt.Rows[0]["WRHS_EMAIL"].ToString();
            if (dt.Rows[0]["WRHS_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            if (Request.QueryString["ViewId"] != null)
            {
                txtWrhsName.Enabled = false;
                txtWrhsCode.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtAddress3.Enabled = false;
                ddlCountry.Enabled = false;
                ddlState.Enabled = false;
                ddlCity.Enabled = false;
                txtPostalCode.Enabled = false;
                txtPhone.Enabled = false;
                txtEmail.Enabled = false;
                cbxStatus.Disabled = true;
            }


        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;

            string strId = "";
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                strId = strRandomMixedId.Substring(2, intLenghtofId);
            }
            if (strId != "")
            {
                objEntityWarehs.WarehouseId = Convert.ToInt32(strId);
            }

            if (Session["USERID"] != null)
            {
                objEntityWarehs.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityWarehs.WarehouseName = txtWrhsName.Text;
            objEntityWarehs.WarehouseCode = txtWrhsCode.Text;
            objEntityWarehs.Address1 = txtAddress1.Text;
            objEntityWarehs.Address2 = txtAddress2.Text;
            objEntityWarehs.Address3 = txtAddress3.Text;
            if (ddlCountry.SelectedItem.Value != "--Select Country--")
            {
                objEntityWarehs.CntryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            }
            if (ddlState.SelectedItem.Value != null && ddlState.SelectedItem.Value != "--Select State--")
            {
                objEntityWarehs.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
            }
            if (ddlCity.SelectedItem.Value != null && ddlCity.SelectedItem.Value != "--Select City--")
            {
                objEntityWarehs.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            }
            objEntityWarehs.PostalCode = txtPostalCode.Text;
            objEntityWarehs.Phone = txtPhone.Text;
            objEntityWarehs.Email = txtEmail.Text;
            if (cbxStatus.Checked == true)
            {
                objEntityWarehs.Status = 1;
            }
            else
            {
                objEntityWarehs.Status = 0;
            }

            objBusinessWarehs.UpdateWarehouse(objEntityWarehs);

            if (clickedButton.ID == "btnUpdate")
            {
                Response.Redirect("pms_Warehouse.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateAndClose")
            {
                Response.Redirect("pms_Warehouse_List.aspx?InsUpd=Upd");
            }
        }
        catch (Exception)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
        }
    }
   
}