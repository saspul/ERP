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
using System.Web.Services;
// CREATED BY:EVM-0001
// CREATED DATE:20/02/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class Master_gen_City_gen_CityAdd : System.Web.UI.Page
{
    //Creating object for business layer and data table
    clsBusinessLayerCityMaster objBusinessLayerCityMaster = new clsBusinessLayerCityMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assign  key process.
        txtCityName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCityName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCityStateName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlCityStateName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbCityStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbCityStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCountry.Attributes.Add("onkeypress", "return DisableEnter(event)");

        if (!IsPostBack)
        {

            txtCityName.Focus();
            CountryLoad();
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
                lblEntry.InnerText = "Edit City Master";
                lblEntryB.InnerText = "Edit City Master";
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
                lblEntry.InnerText = "View City Master";
                lblEntryB.InnerText = "View City Master";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {
                lblEntry.InnerText = "Add City Master";
                lblEntryB.InnerText = "Add City Master";
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
    public void CountryLoad()
    {
        clsBusinessLayerPartner objBusinessPartner = new clsBusinessLayerPartner();
        DataTable dtCountry = objBusinessPartner.ReadCountry();
        ddlCountry.DataSource = dtCountry;
        ddlCountry.DataTextField = "CNTRY_NAME";
        ddlCountry.DataValueField = "CNTRY_ID";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, "--SELECT--");

    }

    //assigning new data to the entity layer for updation.
    protected void btnCityUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityCityMaster objEntCityMaster = new clsEntityCityMaster();
            objEntCityMaster.CityName = txtCityName.Value.ToUpper().Trim();
            objEntCityMaster.CityStateId = Convert.ToInt32(HiddenFieldState.Value);
            objEntCityMaster.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            objEntCityMaster.UserId = Convert.ToInt32(Session["USERID"]);
            if (cbCityStatus.Checked)
            {
                objEntCityMaster.CityStatus = 1;
            }
            else
            {
                objEntCityMaster.CityStatus = 0;
            }
            objEntCityMaster.Date = System.DateTime.Now;
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntCityMaster.CityMasterId = Convert.ToInt32(strId);
            //checking this city name alreadty exist in the table or not
            string strCityCount = objBusinessLayerCityMaster.CheckCityNameUpdate(objEntCityMaster);
            if (strCityCount == "0")
            {
                //passing new data from users to business layer for update table
                objBusinessLayerCityMaster.UpdateCityTable(objEntCityMaster);

                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_City.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_CityList.aspx?InsUpd=Upd");
                }
              

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtCityName.Focus();
            }
        }
    }
    //Fetch the new datatable from businesslayer and set separately in each field. 
    public void View(string strCtyMstrId)
    {
        if (strCtyMstrId != "")
        {
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;

            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = false;
            btnUpdateCloseF.Visible = false;
            clsEntityCityMaster objEntCityMaster = new clsEntityCityMaster();
            objEntCityMaster.CityMasterId = Convert.ToInt32(strCtyMstrId);
            DataTable dtCtyMastr = objBusinessLayerCityMaster.ReadCityMasterEdit(objEntCityMaster);
            txtCityName.Value = dtCtyMastr.Rows[0]["CITY_NAME"].ToString();

            HiddenFieldState.Value = dtCtyMastr.Rows[0]["STATE_ID"].ToString();
            ddlCityStateName.Text = dtCtyMastr.Rows[0]["STATE_NAME"].ToString();

            if (dtCtyMastr.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCtyMastr.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
            {
                ddlCountry.Items.FindByText(dtCtyMastr.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtCtyMastr.Rows[0]["CNTRY_NAME"].ToString(), dtCtyMastr.Rows[0]["CNTRY_ID"].ToString());
                ddlCountry.Items.Insert(1, lst);
                SortDDL(ref this.ddlCountry);
                ddlCountry.Items.FindByText(dtCtyMastr.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
          

            int intCityStatus = Convert.ToInt32(dtCtyMastr.Rows[0]["STATE_STATUS"]);
            if (intCityStatus == 1)
            {
                cbCityStatus.Checked = true;
            }
            else
            {
                cbCityStatus.Checked = false;
            }
            txtCityName.Disabled = true;
            ddlCityStateName.Enabled = true;
            cbCityStatus.Disabled = true;
            ddlCountry.Enabled = false;
        }
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strCtyMstrId)
    {
        if (strCtyMstrId != "")
        {
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnUpdate.Visible = true;
            btnUpdateClose.Visible = true;

            btnAddF.Visible = false;
            btnAddCloseF.Visible = false;
            btnUpdateF.Visible = true;
            btnUpdateCloseF.Visible = true;
            clsEntityCityMaster objEntCityMaster = new clsEntityCityMaster();
            objEntCityMaster.CityMasterId = Convert.ToInt32(strCtyMstrId);
            DataTable dtCtyMastr = objBusinessLayerCityMaster.ReadCityMasterEdit(objEntCityMaster);
            txtCityName.Value = dtCtyMastr.Rows[0]["CITY_NAME"].ToString();
            HiddenFieldState.Value = dtCtyMastr.Rows[0]["STATE_ID"].ToString();
            ddlCityStateName.Text = dtCtyMastr.Rows[0]["STATE_NAME"].ToString();
            //ie IF  State IS ACTIVE
            if (dtCtyMastr.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCtyMastr.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
            {
                ddlCountry.Items.FindByText(dtCtyMastr.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lst = new ListItem(dtCtyMastr.Rows[0]["CNTRY_NAME"].ToString(), dtCtyMastr.Rows[0]["CNTRY_ID"].ToString());
                ddlCountry.Items.Insert(1, lst);
                SortDDL(ref this.ddlCountry);
                ddlCountry.Items.FindByText(dtCtyMastr.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            int intCityStatus = Convert.ToInt32(dtCtyMastr.Rows[0]["CITY_STATUS"]);
            if (intCityStatus == 1)
            {
                cbCityStatus.Checked = true;
            }
            else
            {
                cbCityStatus.Checked = false;
            }
        }
    }
    //accuring data from users and passing to the business layer for inserting new city details.
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCityMaster objEntCityMaster = new clsEntityCityMaster();    
        objEntCityMaster.CityName = txtCityName.Value.ToUpper().Trim();
        objEntCityMaster.CityStateId = Convert.ToInt32(HiddenFieldState.Value);
        objEntCityMaster.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
        objEntCityMaster.UserId = Convert.ToInt32(Session["USERID"]);
        if (cbCityStatus.Checked)
        {
            objEntCityMaster.CityStatus = 1;
        }
        else
        {
            objEntCityMaster.CityStatus = 0;
        }
        if (hiddenDsgnTypId.Value == "1")
        {
            objEntCityMaster.Preinstall = 1;
        }
        else
        {
            objEntCityMaster.Preinstall = 0;
        }
        //Check wheather the city name already exist or not
        DataTable dtCity = objBusinessLayerCityMaster.CheckCityName(objEntCityMaster);
        string strCityName = dtCity.Rows[0]["COUNT(CITY_ID)"].ToString();
        if (strCityName == "0")
        {
            objBusinessLayerCityMaster.AddCityDeatils(objEntCityMaster);
            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
            {
                Response.Redirect("gen_City.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
            {
                Response.Redirect("gen_CityList.aspx?InsUpd=Ins");
            }
           


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtCityName.Focus();
        }
    }
    [WebMethod]
    public static string[] changeState(string strLikeEmployee, int orgID, int corptID, int countryID)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.CountryId = Convert.ToInt32(countryID);
        objEntityCorp.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["STATE_ID"].ToString(), dtEmployess.Rows[intRowCount]["STATE_NAME"].ToString()));
        }
        return Employees.ToArray();
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
