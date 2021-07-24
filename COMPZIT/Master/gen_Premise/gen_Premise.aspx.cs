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
// CREATED DATE:10/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Premises_gen_PremiseAdd : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsbusinesslayerPremise objBusinessLayerPremise = new clsbusinesslayerPremise();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtPremiseName.Attributes.Add("onkeypress", "return isTag(event)");
        txtPremiseName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlDept.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlDept.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            txtPremiseName.Focus();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Department Premise";
                lblEntryB.InnerText = "Edit Department Premise";
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
                btnClear.Visible = false;
                btnClearF.Visible = false;
                lblEntry.InnerText = "View Department Premise";
                lblEntryB.InnerText = "View Department Premise";
            }

            else
            {
                lblEntry.InnerText = "Add Department Premise";
                lblEntryB.InnerText = "Add Department Premise";
                Department_Load();
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

    //Method for assigning departments to the dropdown list
    public void Department_Load()
    {
        clsEntityPremise objEntityPremise = new clsEntityPremise();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPremise.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPremise.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDept = objBusinessLayerPremise.ReadCorpDept(objEntityPremise);

        ddlDept.DataSource = dtDept;

        ddlDept.DataTextField = "CPRDEPT_NAME";
        ddlDept.DataValueField = "CPRDEPT_ID";
        ddlDept.DataBind();

        ddlDept.Items.Insert(0, "--SELECT DEPARTMENT--");
    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityPremise objEntityPremise = new clsEntityPremise();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPremise.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPremise.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityPremise.Department_Id = Convert.ToInt32(ddlDept.SelectedItem.Value);
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityPremise.Premise_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityPremise.Premise_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityPremise.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else 
        {
            Response.Redirect("~/Default.aspx");
        }
  
        objEntityPremise.D_Date = System.DateTime.Now;
        txtPremiseName.Text = txtPremiseName.Text.ToUpper().Trim();
        objEntityPremise.Premise_Name = txtPremiseName.Text;
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerPremise.Check_Premise_Name(objEntityPremise);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerPremise.Insert_Premise(objEntityPremise);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Premise.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_PremiseList.aspx?InsUpd=Ins");
            }
           
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtPremiseName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityPremise objEntityPremise = new clsEntityPremise();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPremise.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPremise.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityPremise.Department_Id = Convert.ToInt32(ddlDept.SelectedItem.Value);
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityPremise.Premise_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityPremise.Premise_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityPremise.Premise_Master_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityPremise.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityPremise.D_Date = System.DateTime.Now;
            txtPremiseName.Text = txtPremiseName.Text.ToUpper().Trim();
            objEntityPremise.Premise_Name = txtPremiseName.Text;
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerPremise.Check_Premise_NameUpdation(objEntityPremise);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                DataTable dtComplaintDetail = objBusinessLayerPremise.ReadPremiseById(objEntityPremise);
                if (dtComplaintDetail.Rows.Count > 0)
                {
                    if (dtComplaintDetail.Rows[0]["PREMISE_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["PREMISE_CNCL_USR_ID"].ToString() == null)
                    {
                        objBusinessLayerPremise.Update_Premise(objEntityPremise);
                        if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                        {
                            Response.Redirect("gen_Premise.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                        {
                            Response.Redirect("gen_PremiseList.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_PremiseList.aspx?InsUpd=AlCncl");
                    }
                }         
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtPremiseName.Focus();
            }
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityPremise objEntityPremise = new clsEntityPremise();
        objEntityPremise.Premise_Master_Id = Convert.ToInt32(strP_Id);
        DataTable dtPremiseById = objBusinessLayerPremise.ReadPremiseById(objEntityPremise);
        if (dtPremiseById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtPremiseName.Text = dtPremiseById.Rows[0]["PREMISE_NAME"].ToString();
            ddlDept.Items.Clear();
            ListItem lst = new ListItem(dtPremiseById.Rows[0]["CPRDEPT_NAME"].ToString(), dtPremiseById.Rows[0]["CPRDEPT_ID"].ToString());
            ddlDept.Items.Insert(0, lst);

            int intPremiseStatus = Convert.ToInt32(dtPremiseById.Rows[0]["PREMISE_STATUS"]);
            if (intPremiseStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtPremiseName.Enabled = false;
        ddlDept.Enabled = false;
        cbxStatus.Disabled = true;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityPremise objEntityPremise = new clsEntityPremise();
        objEntityPremise.Premise_Master_Id = Convert.ToInt32(strP_Id);
        DataTable dtPremiseById = objBusinessLayerPremise.ReadPremiseById(objEntityPremise);
        if (dtPremiseById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtPremiseName.Text = dtPremiseById.Rows[0]["PREMISE_NAME"].ToString();
            Department_Load();
            //ie IF  Department IS ACTIVE
            if (dtPremiseById.Rows[0]["CPRDEPT_STATUS"].ToString() == "1" && dtPremiseById.Rows[0]["CPRDEPT_CNCL_USR_ID"].ToString() == "")
            {
                ddlDept.Items.FindByText(dtPremiseById.Rows[0]["CPRDEPT_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtPremiseById.Rows[0]["CPRDEPT_NAME"].ToString(), dtPremiseById.Rows[0]["CPRDEPT_ID"].ToString());
                ddlDept.Items.Insert(1, lst);

                SortDDL(ref this.ddlDept);

                ddlDept.Items.FindByText(dtPremiseById.Rows[0]["CPRDEPT_NAME"].ToString()).Selected = true;
            }


            int intPremiseStatus = Convert.ToInt32(dtPremiseById.Rows[0]["PREMISE_STATUS"]);
            if (intPremiseStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
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