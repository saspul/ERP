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
// CREATED DATE:11/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_WorkArea_gen_WorkAreaAdd : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsBusinessLayerWorkArea objBusinessLayerWorkArea = new clsBusinessLayerWorkArea();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtWorkAreaName.Attributes.Add("onkeypress", "return isTag(event)");
        txtWorkAreaName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlPremise.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlPremise.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            txtWorkAreaName.Focus();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Premise Area";
                lblEntryB.InnerText = "Edit Premise Area";
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

                lblEntry.InnerText = "View Premise Area";
                lblEntryB.InnerText = "View Premise Area";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add Premise Area";
                lblEntryB.InnerText = "Add Premise Area";
                Premise_Load();
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
    //Method for assigning Premise to the dropdown list
    public void Premise_Load()
    {
        clsEntityWorkArea objEntityArea = new clsEntityWorkArea();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityArea.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityArea.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtPremise = objBusinessLayerWorkArea.ReadPremise(objEntityArea);

        ddlPremise.DataSource = dtPremise;

        ddlPremise.DataTextField = "PREMISE_NAME";
        ddlPremise.DataValueField = "PREMISE_ID";
        ddlPremise.DataBind();

        ddlPremise.Items.Insert(0, "--SELECT PREMISE--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityWorkArea objEntityArea = new clsEntityWorkArea();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityArea.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityArea.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityArea.PremiseId = Convert.ToInt32(ddlPremise.SelectedItem.Value);
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityArea.WorkArea_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityArea.WorkArea_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityArea.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityArea.D_Date = System.DateTime.Now;
        txtWorkAreaName.Text = txtWorkAreaName.Text.ToUpper().Trim();
        objEntityArea.WorkArea_Name = txtWorkAreaName.Text;
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerWorkArea.Check_WorkArea_Name(objEntityArea);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerWorkArea.Insert_WorkArea(objEntityArea);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_WorkArea.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_WorkAreaList.aspx?InsUpd=Ins");
            }
          
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtWorkAreaName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {
            clsEntityWorkArea objEntityArea = new clsEntityWorkArea();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityArea.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityArea.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityArea.PremiseId = Convert.ToInt32(ddlPremise.SelectedItem.Value);
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityArea.WorkArea_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityArea.WorkArea_Status = 0;
            }
            if (Session["USERID"] != null)
            {
                objEntityArea.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityArea.D_Date = System.DateTime.Now;
            txtWorkAreaName.Text = txtWorkAreaName.Text.ToUpper().Trim();
            objEntityArea.WorkArea_Name = txtWorkAreaName.Text;
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityArea.WorkArea_Master_Id = Convert.ToInt32(strId);
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerWorkArea.Check_WorkArea_NameUpdation(objEntityArea);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {

                DataTable dtComplaintDetail = objBusinessLayerWorkArea.ReadWorkAreaById(objEntityArea);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["DPTAREA_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["DPTAREA_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessLayerWorkArea.Update_WorkArea(objEntityArea);
                        if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                        {
                            Response.Redirect("gen_WorkArea.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                        {
                            Response.Redirect("gen_WorkAreaList.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_WorkAreaList.aspx?InsUpd=AlCncl");
                    }
                }               
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtWorkAreaName.Focus();
            }
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strWA_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityWorkArea objEntityArea = new clsEntityWorkArea();
        objEntityArea.WorkArea_Master_Id = Convert.ToInt32(strWA_Id);
        DataTable dtWorkAreaById = objBusinessLayerWorkArea.ReadWorkAreaById(objEntityArea);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtWorkAreaName.Text = dtWorkAreaById.Rows[0]["DPTAREA_NAME"].ToString();

        ddlPremise.Items.Clear();
        ListItem lst = new ListItem(dtWorkAreaById.Rows[0]["PREMISE_NAME"].ToString(), dtWorkAreaById.Rows[0]["PREMISE_ID"].ToString());
        ddlPremise.Items.Insert(0, lst);

        int intWorkAreaStatus = Convert.ToInt32(dtWorkAreaById.Rows[0]["DPTAREA_STATUS"]);
        if (intWorkAreaStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
        txtWorkAreaName.Enabled = false;
        ddlPremise.Enabled = false;
        cbxStatus.Disabled = true;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strWA_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityWorkArea objEntityArea = new clsEntityWorkArea();
        objEntityArea.WorkArea_Master_Id = Convert.ToInt32(strWA_Id);
        DataTable dtWorkAreaById = objBusinessLayerWorkArea.ReadWorkAreaById(objEntityArea);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        txtWorkAreaName.Text = dtWorkAreaById.Rows[0]["DPTAREA_NAME"].ToString();
        Premise_Load();

        //ie IF  PREMISE IS ACTIVE
        if (dtWorkAreaById.Rows[0]["PREMISE_STATUS"].ToString() == "1" && dtWorkAreaById.Rows[0]["PREMISE_CNCL_USR_ID"].ToString() == "")
        {
            ddlPremise.Items.FindByText(dtWorkAreaById.Rows[0]["PREMISE_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lst = new ListItem(dtWorkAreaById.Rows[0]["PREMISE_NAME"].ToString(), dtWorkAreaById.Rows[0]["PREMISE_ID"].ToString());
            ddlPremise.Items.Insert(1, lst);

            SortDDL(ref this.ddlPremise);

            ddlPremise.Items.FindByText(dtWorkAreaById.Rows[0]["PREMISE_NAME"].ToString()).Selected = true;
        }




        int intWorkAreaStatus = Convert.ToInt32(dtWorkAreaById.Rows[0]["DPTAREA_STATUS"]);
        if (intWorkAreaStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
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