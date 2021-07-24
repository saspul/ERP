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
using CL_Compzit;
// CREATED BY:EVM-0001
// CREATED DATE:20/02/2016
// REVIEWED BY:
// REVIEW DATE:

// This is the UI Layer for Adding Organisation Details and also updating,canceling and viewing the same .

public partial class Master_gen_OrganisationType_gen_OrganisationTypeAdd : System.Web.UI.Page
{
  
    //Created objects for business layer
    clsBusinessLayerOrgType objBusinessLayerOrgMstr = new clsBusinessLayerOrgType();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtOrgTypeName.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgTypeName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

      
        //On not is post back
        if (!IsPostBack)
        {
            txtOrgTypeName.Focus();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.Text = "Edit Organization Type";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);
                lblEntry.Text = "View Organization Type";

            }
            else
            {
                lblEntry.Text = "Add Organization Type";
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
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strO_Id)
    {
        if (strO_Id != "")
        {
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;

            clsEntityOrgType objOrg = new clsEntityOrgType();
            objOrg.OrgTypId = Convert.ToInt32(strO_Id);
            DataTable dtEditOrg = new DataTable();
            dtEditOrg = objBusinessLayerOrgMstr.EditViewOrg(objOrg);
            txtOrgTypeName.Text = dtEditOrg.Rows[0]["ORGCTY_NAME"].ToString();
            if (dtEditOrg.Rows[0]["ORGCTY_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
           
        }
    }
    //Fetch the new datatable from businesslayer and set separately in each field. 
    public void View(string strO_Id)
    {
        if (strO_Id != "")
        {

            
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
          
            clsEntityOrgType objOrg = new clsEntityOrgType();
            objOrg.OrgTypId = Convert.ToInt32(strO_Id);
            DataTable dtEditOrg = new DataTable();
            dtEditOrg = objBusinessLayerOrgMstr.EditViewOrg(objOrg);
            txtOrgTypeName.Text = dtEditOrg.Rows[0]["ORGCTY_NAME"].ToString();
            if (dtEditOrg.Rows[0]["ORGCTY_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
           cbxStatus.Enabled = false;
           txtOrgTypeName.Enabled = false;
        }
    }
    //On SaveSubmit Button Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityOrgType objOrg = new clsEntityOrgType();
        objOrg.OrgUserId = Convert.ToInt32(Session["USERID"]);
        txtOrgTypeName.Text = txtOrgTypeName.Text.ToUpper();
        objOrg.OrgName = txtOrgTypeName.Text.Trim();
        //When CheckBox For Active is unChecked
        if (cbxStatus.Checked == false)
        {
            objOrg.OrgStatus =Convert.ToInt32( clsCommonLibrary.StatusAll.InActive);
        }
        else
        {
            objOrg.OrgStatus = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
        }
        //Check wheather organisation type name already exist or not
        DataTable dtOrgType = objBusinessLayerOrgMstr.CheckOrgTypeName(objOrg);
        string strOrgType = dtOrgType.Rows[0]["COUNT(ORGCTY_ID)"].ToString();
        if (strOrgType == "0")
        {
            objBusinessLayerOrgMstr.AddOrgMstr(objOrg);
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_OrganisationType.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_OrganisationtypeList.aspx?InsUpd=Ins");
            }
           
          
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtOrgTypeName.Focus();
        }
    }
    //When Save Button while editing  is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
           clsEntityOrgType objOrg = new clsEntityOrgType();
            txtOrgTypeName.Text = txtOrgTypeName.Text.ToUpper();
            objOrg.OrgStatus = 1;
            if (cbxStatus.Checked == false)
            {
                objOrg.OrgStatus = 0;
            }
            objOrg.OrgName = txtOrgTypeName.Text.Trim();
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objOrg.OrgTypId = Convert.ToInt32(strId);
            objOrg.OrgUserId = Convert.ToInt32(Session["USERID"]);
            objOrg.OrgDate = System.DateTime.Now;
            //Check wheather organisation type name already exist or not in updation
            string strOrgType = objBusinessLayerOrgMstr.CheckOrgTypeUpdation(objOrg);
            if (strOrgType == "0")
            {
                objBusinessLayerOrgMstr.UpdateOrg(objOrg);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_OrganisationType.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_OrganisationtypeList.aspx?InsUpd=Upd");
                }
               
             
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtOrgTypeName.Focus();
            }
        }
    }

}