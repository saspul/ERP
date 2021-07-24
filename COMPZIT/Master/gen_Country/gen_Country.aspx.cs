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

// CREATED BY:EVM-0001
// CREATED DATE:19/02/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the UI Layer for Adding Country Details and also updating,canceling and viewing the same .

public partial class Master_gen_Country_gen_CountryAdd : System.Web.UI.Page
{

    //Created objects for business layer
    clsBusinessLayerCountry objBusinessLayerCntryMstr = new clsBusinessLayerCountry();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .

        txtCountryName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCountryName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        //On not is post back
        if (!IsPostBack)
        {
            txtCountryName.Focus();

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
                lblEntry.InnerText = "Edit Country Master";
                lblEntryB.InnerText = "Edit Country Master";
                btnClearF.Visible = false;
                btnClear.Visible = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);
                lblEntry.InnerText = "View Country Master";
                lblEntryB.InnerText = "View Country Master";
                btnClearF.Visible = false;
                btnClear.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add Country Master";
                lblEntryB.InnerText = "Add Country Master";
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
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strC_Id)
    {
        if (strC_Id != "")
        {
            EL_Compzit.clsEntityCountry objCountry = null;
            objCountry = new EL_Compzit.clsEntityCountry();
            objCountry.CountryId = Convert.ToInt32(strC_Id);
            DataTable dtEditCountry = new DataTable();
            dtEditCountry = objBusinessLayerCntryMstr.EditViewCountry(objCountry);
            txtCountryName.Value = dtEditCountry.Rows[0]["CNTRY_NAME"].ToString();
            if (dtEditCountry.Rows[0]["CNTRY_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtCountryName.Disabled = false;
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
            EL_Compzit.clsEntityCountry objCountry = null;
            objCountry = new EL_Compzit.clsEntityCountry();
            objCountry.CountryId = Convert.ToInt32(strC_Id);
            DataTable dtEditCountry = new DataTable();
            dtEditCountry = objBusinessLayerCntryMstr.EditViewCountry(objCountry);
            txtCountryName.Value = dtEditCountry.Rows[0]["CNTRY_NAME"].ToString();
            if (dtEditCountry.Rows[0]["CNTRY_STATUS"].ToString() == "1")
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            txtCountryName.Disabled = true;
            cbxStatus.Disabled = true;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;

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
            EL_Compzit.clsEntityCountry objCountry = null;
            objCountry = new EL_Compzit.clsEntityCountry();
            objCountry.CountryStatus = 1;
            if (cbxStatus.Checked == false)
            {
                objCountry.CountryStatus = 0;
            }
            objCountry.CountryName = txtCountryName.Value.ToUpper().Trim();
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objCountry.CountryId = Convert.ToInt32(strId);
            objCountry.CountryUserId = Convert.ToInt32(Session["USERID"]);
            objCountry.CountryDate = System.DateTime.Now;
            string strCountryCount = objBusinessLayerCntryMstr.CheckDupCountryNameUpdate(objCountry);
            if (strCountryCount == "0")
            {
                objBusinessLayerCntryMstr.UpdateCountry(objCountry);
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_Country.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_CountryList.aspx?InsUpd=Upd");
                }
              

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtCountryName.Focus();
            }
        }
    }
    //On SaveSubmit Button Click
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        EL_Compzit.clsEntityCountry objCountry = null;
        objCountry = new EL_Compzit.clsEntityCountry();
        objCountry.CountryUserId = Convert.ToInt32(Session["USERID"]);
        txtCountryName.Value = txtCountryName.Value.ToUpper().Trim();
        objCountry.CountryName = txtCountryName.Value.Trim();
        //When CheckBox For Active is unChecked
        if (cbxStatus.Checked == false)
        {
            objCountry.CountryStatus = 0;
        }
        else
        {
            objCountry.CountryStatus = 1;
        }
        if (hiddenDsgnTypId.Value == "1")
        {
            objCountry.Preinstall = 1;
        }
        else
        {
            objCountry.Preinstall = 0;
        }

        string strCntryNameCount = objBusinessLayerCntryMstr.CheckDupCountryName(objCountry);
        if (strCntryNameCount == "0")
        {

            objBusinessLayerCntryMstr.AddCountryMstr(objCountry);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_Country.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_CountryList.aspx?InsUpd=Ins");
            }
       

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtCountryName.Focus();
        }
    }
  
  
}