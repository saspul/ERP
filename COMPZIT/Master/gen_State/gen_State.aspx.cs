using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using System.Collections;

// CREATED BY:EVM-0001
// CREATED DATE:19/02/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_State_gen_StateAdd : System.Web.UI.Page
{
    //Creating object for business layer and data table
    clsBusinessLayerStateMaster objBusinessLayerStateMaster = new clsBusinessLayerStateMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtStateName.Attributes.Add("onkeypress", "return isTag(event)");
        txtStateName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlStateCountryName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlStateCountryName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbStateStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbStateStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        //If this page is loaded or redirected from any other location other than edit button and view button in the list of city is clicked.
        if (!IsPostBack)
        {
            txtStateName.Focus();
            if (Session["DSGN_TYPID"] != null)
            {
                hiddenDsgnTypId.Value = Session["DSGN_TYPID"].ToString();
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
                lblEntry.InnerText = "Edit State Master";
                lblEntryB.InnerText = "Edit State Master";
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

                lblEntry.InnerText = "View State Master";
                lblEntryB.InnerText = "View State Master";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add State Master";
                lblEntryB.InnerText = "Add State Master";
                DropDownBind();
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
    //Assign country details from country table to dropdownlist.
    public void DropDownBind()
    {
        DataTable dtCountryDetails = new DataTable();
        dtCountryDetails = objBusinessLayerStateMaster.ReadCountryDetails();

        ddlStateCountryName.DataSource = dtCountryDetails;

        ddlStateCountryName.DataTextField = "CNTRY_NAME";
        ddlStateCountryName.DataValueField = "CNTRY_ID";
        ddlStateCountryName.DataBind();
        ddlStateCountryName.Items.Insert(0, "--SELECT--");
    }

    //assigning new data to the entity layer for updation.
    protected void btnStateUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {
            clsEntityStateMaster objEntStateMaster = new clsEntityStateMaster();
            txtStateName.Value = txtStateName.Value.ToUpper();
            objEntStateMaster.StateName = txtStateName.Value.Trim();
            objEntStateMaster.StateCountryId = Convert.ToInt32(ddlStateCountryName.SelectedItem.Value);
            if (Session["USERID"] != null)
            {
                objEntStateMaster.UserId = Convert.ToInt32(Session["USERID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
           
            if (cbStateStatus.Checked)
            {
                objEntStateMaster.StateStatus = 1;
            }
            else
            {
                objEntStateMaster.StateStatus = 0;
            }
            objEntStateMaster.Date = System.DateTime.Now;
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntStateMaster.StateMasterId = Convert.ToInt32(strId);
            //Checking state name already exist in the table.
            string strStateCount = objBusinessLayerStateMaster.CheckStateNameUpdate(objEntStateMaster);
            if (strStateCount == "0")
            {
                objBusinessLayerStateMaster.UpdateStateTable(objEntStateMaster);
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_State.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_StateList.aspx?InsUpd=Upd");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtStateName.Focus();
            }
        }
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strS_Id)
    {
        if (strS_Id != "")
        {
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;
            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = true;
            btnUpdateCloseF.Visible = true;
            clsEntityStateMaster objEntStateMaster = new clsEntityStateMaster();
            objEntStateMaster.StateMasterId = Convert.ToInt32(strS_Id);
            DataTable dtStMsrt = objBusinessLayerStateMaster.ReadStateMasterEdit(objEntStateMaster);
            txtStateName.Value = dtStMsrt.Rows[0]["STATE_NAME"].ToString();
            DropDownBind();
            //ie IF  COUNTRY IS ACTIVE
            if (dtStMsrt.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtStMsrt.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
            {
                ddlStateCountryName.Items.FindByText(dtStMsrt.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtStMsrt.Rows[0]["CNTRY_NAME"].ToString(), dtStMsrt.Rows[0]["CNTRY_ID"].ToString());
                ddlStateCountryName.Items.Insert(1, lst);

                SortDDL(ref this.ddlStateCountryName);

                ddlStateCountryName.Items.FindByText(dtStMsrt.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }

            int intStateStatus = Convert.ToInt32(dtStMsrt.Rows[0]["STATE_STATUS"]);
            if (intStateStatus == 1)
            {
                cbStateStatus.Checked = true;
            }
            else
            {
                cbStateStatus.Checked = false;
            }
        }
    }
    //Fetch the new datatable from businesslayer and set separately in each field. 
    public void View(string strS_Id)
    {
        if (strS_Id != "")
        {
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;

            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = false;
            btnUpdateCloseF.Visible = false;
            clsEntityStateMaster objEntStateMaster = new clsEntityStateMaster();
            objEntStateMaster.StateMasterId = Convert.ToInt32(strS_Id);
            DataTable dtStMsrt = objBusinessLayerStateMaster.ReadStateMasterEdit(objEntStateMaster);
            txtStateName.Value = dtStMsrt.Rows[0]["STATE_NAME"].ToString();


            ddlStateCountryName.Items.Clear();
            ListItem lst = new ListItem(dtStMsrt.Rows[0]["CNTRY_NAME"].ToString(), dtStMsrt.Rows[0]["CNTRY_ID"].ToString());
            ddlStateCountryName.Items.Insert(0, lst);

            int intStateStatus = Convert.ToInt32(dtStMsrt.Rows[0]["STATE_STATUS"]);
            if (intStateStatus == 1)
            {
                cbStateStatus.Checked = true;
            }
            else
            {
                cbStateStatus.Checked = false;
            }
            txtStateName.Disabled = true;
            ddlStateCountryName.Enabled = false;
            cbStateStatus.Disabled = true;
        }
    }
    //accuring data from users and passing to the business layer for inserting new state details.
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        //accuring data from users and passing to the business layer for inserting new state details.
        clsEntityStateMaster objEntStateMaster = new clsEntityStateMaster();
        txtStateName.Value = txtStateName.Value.ToUpper();
        objEntStateMaster.StateName = txtStateName.Value.Trim();
        objEntStateMaster.StateCountryId = Convert.ToInt32(ddlStateCountryName.SelectedItem.Value);
        objEntStateMaster.UserId = Convert.ToInt32(Session["USERID"]);
        if (cbStateStatus.Checked)
        {
            objEntStateMaster.StateStatus = 1;
        }
        else
        {
            objEntStateMaster.StateStatus = 0;
        }
        if (hiddenDsgnTypId.Value == "1")
        {
            objEntStateMaster.Preinstall = 1;
        }
        else
        {
            objEntStateMaster.Preinstall = 0;
        }
        //Check wheather state name already existed in the table.
        DataTable dtStateName = objBusinessLayerStateMaster.CheckStateName(objEntStateMaster);
        string strStateCount = dtStateName.Rows[0]["COUNT(STATE_ID)"].ToString();
        if (strStateCount == "0")
        {
            objBusinessLayerStateMaster.AddStateDeatils(objEntStateMaster);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_State.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_StateList.aspx?InsUpd=Ins");
            }
          

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtStateName.Focus();
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

