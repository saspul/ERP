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
// CREATED DATE:23/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Customer_Group_gen_Customer_Group : System.Web.UI.Page
{

    //Creating objects for businesslayer
    clsBusinessLayerCustomerGroup objBusinessLayerCustmrGrp = new clsBusinessLayerCustomerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtCustmrGrpName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCustmrGrpName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            txtCustmrGrpName.Focus();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Customer Group";
                lblEntryB.InnerText = "Edit Customer Group";
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

                lblEntry.InnerText = "View Customer Group";
                lblEntryB.InnerText = "View Customer Group";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Customer Group";
                lblEntryB.InnerText = "Add Customer Group";   
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

 
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityCustomerGroup objEntityCustmrGrp = new clsEntityCustomerGroup();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustmrGrp.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustmrGrp.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
     
        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityCustmrGrp.Customer_Group_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityCustmrGrp.Customer_Group_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityCustmrGrp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityCustmrGrp.D_Date = System.DateTime.Now;
        txtCustmrGrpName.Text = txtCustmrGrpName.Text.ToUpper().Trim();
        objEntityCustmrGrp.Customer_Group_name = txtCustmrGrpName.Text.ToUpper().Trim();
        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerCustmrGrp.CheckCustomerGroupName(objEntityCustmrGrp);
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessLayerCustmrGrp.AddCustomerGroup(objEntityCustmrGrp);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Customer_Group.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_Customer_GroupList.aspx?InsUpd=Ins");
            }
            
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtCustmrGrpName.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityCustomerGroup objEntityCustmrGrp = new clsEntityCustomerGroup();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCustmrGrp.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCustmrGrp.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
         
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityCustmrGrp.Customer_Group_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityCustmrGrp.Customer_Group_Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCustmrGrp.Customer_Group_Id = Convert.ToInt32(strId);
            if (Session["USERID"] != null)
            {
                objEntityCustmrGrp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityCustmrGrp.D_Date = System.DateTime.Now;
            txtCustmrGrpName.Text = txtCustmrGrpName.Text.ToUpper().Trim();
            objEntityCustmrGrp.Customer_Group_name = txtCustmrGrpName.Text.ToUpper().Trim();
            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerCustmrGrp.CheckCustomerGroupName(objEntityCustmrGrp);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                 DataTable dtComplaintDetail = objBusinessLayerCustmrGrp.ReadCustomerGroupById(objEntityCustmrGrp);
                 if (dtComplaintDetail.Rows.Count > 0)
                 {
                     if (dtComplaintDetail.Rows[0]["CSTMRGP_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["CSTMRGP_CNCL_USR_ID"].ToString() == null)
                     {
                         objBusinessLayerCustmrGrp.UpdateCustomerGroup(objEntityCustmrGrp);
                         if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                         {
                             Response.Redirect("gen_Customer_Group.aspx?InsUpd=Upd");
                         }
                         else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                         {
                             Response.Redirect("gen_Customer_GroupList.aspx?InsUpd=Upd");
                         }
                     }
                     else
                     {
                         Response.Redirect("gen_Customer_GroupList.aspx?InsUpd=AlCncl");
                     }
                 }
                
            }
            //If have
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtCustmrGrpName.Focus();
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
        clsEntityCustomerGroup objEntityCustmrGrp = new clsEntityCustomerGroup();
        objEntityCustmrGrp.Customer_Group_Id = Convert.ToInt32(strP_Id);
        DataTable dtCustmrById = objBusinessLayerCustmrGrp.ReadCustomerGroupById(objEntityCustmrGrp);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        if (dtCustmrById.Rows.Count > 0)
        {
            txtCustmrGrpName.Text = dtCustmrById.Rows[0]["CSTMRGP_NAME"].ToString();
            int intStatus = Convert.ToInt32(dtCustmrById.Rows[0]["CSTMRGP_STATUS"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtCustmrGrpName.Enabled = false;
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
        clsEntityCustomerGroup objEntityCustmrGrp = new clsEntityCustomerGroup();
        objEntityCustmrGrp.Customer_Group_Id = Convert.ToInt32(strP_Id);
        DataTable dtCustmrById = objBusinessLayerCustmrGrp.ReadCustomerGroupById(objEntityCustmrGrp);
        //After fetch Deaprtment details in datatable,we need to differentiate.
        if (dtCustmrById.Rows.Count > 0)
        {
            txtCustmrGrpName.Text = dtCustmrById.Rows[0]["CSTMRGP_NAME"].ToString();
            int intStatus = Convert.ToInt32(dtCustmrById.Rows[0]["CSTMRGP_STATUS"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
    }


  
}