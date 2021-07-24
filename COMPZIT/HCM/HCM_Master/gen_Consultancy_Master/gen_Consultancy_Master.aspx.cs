using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using CL_Compzit;
using BL_Compzit;
using EL_Compzit;
using System.Data;
using System.Collections;
public partial class HCM_HCM_Master_gen_Consultancy_Master_gen_Consultancy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCnsltyName.Focus();
            LoadCountry();
            LoadConsultancyType();
            //NEW
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //Creating objects for business layer
            clsEntityConsultancyMaster objEntityConslt = new clsEntityConsultancyMaster();
            clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
            int intUserId = 0, intUsrRolMstrId = 0, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityConslt.UserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityConslt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityConslt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Allocating child roles

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Consultancy_Master);
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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

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

                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdateClose.Visible = true;

            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = true;
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId, intOrgId);
                lblEntry.Text = "Edit Consultancy";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                txtCnsltyName.Focus();


            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {

                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                // HiddenViewId.Value = strId;
                View(strId, intCorpId, intOrgId);

                //img1.Disabled = true;
                lblEntry.Text = "View Consultancy";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                txtCntctName.Enabled = false;
                txtAddress.Enabled = false;
                cbRegistrationSts.Enabled = false;
                txtRegistrationNo.Enabled = false;
                ddlCountry.Enabled = false;
                ddlCnsltyType.Enabled = false;
                txtLocation.Enabled = false;
                txtCntctEmail.Enabled = false;
                txtCnsltyEmail.Enabled = false;
                txtCnsltyPhone.Enabled = false;
                cbStatus.Enabled = false;
                txtCnsltyName.Enabled = false;
                txtCntctEmail.Enabled = false;
                txtCntctMobile.Enabled = false;
                
            }
            else
            {
                lblEntry.Text = "Add Consultancy";
                           
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessIns", "SuccessIns();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }
                }
                txtCnsltyName.Focus();
            }
        }
    }
    public void LoadCountry()
    {
        clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
      
        DataTable dtCountryList = objBusinessConslt.ReadCountryList();

        if (dtCountryList.Rows.Count > 0)
        {
            ddlCountry.DataSource = dtCountryList;
            ddlCountry.DataTextField = "CNTRY_NAME";
            ddlCountry.DataValueField = "CNTRY_ID";
            ddlCountry.DataBind();
        }
        ddlCountry.Items.Insert(0, "--SELECT COUNTRY--");
    }
    public void LoadConsultancyType()
    {
        clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
        DataTable dtConsultancytype = objBusinessConslt.ReadConsultancytype();

        if (dtConsultancytype.Rows.Count > 0)
        {
            ddlCnsltyType.DataSource = dtConsultancytype;
            ddlCnsltyType.DataTextField = "CNSLTTYPE_NAME";
            ddlCnsltyType.DataValueField = "CNSLTTYPE_ID";
            ddlCnsltyType.DataBind();
        }
        ddlCnsltyType.Items.Insert(0, "--SELECT CONSULTANCY TYPE--");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityConsultancyMaster objEntityConslt = new clsEntityConsultancyMaster();
        clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityConslt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityConslt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityConslt.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityConslt.ConsultancyName = txtCnsltyName.Text.Trim().ToUpper();
        objEntityConslt.ConsultancyAddress=txtAddress.Text.Trim();
        objEntityConslt.RegNo = txtRegistrationNo.Text.Trim();
        if (ddlCnsltyType.SelectedItem.Value.ToString() != "--SELECT CONSULTANCY TYPE--")
        {
            objEntityConslt.ConsultancyTypeId = Convert.ToInt32(ddlCnsltyType.SelectedItem.Value);
        }
        if (ddlCountry.SelectedItem.Value.ToString() != "--SELECT COUNTRY--")
        {
            objEntityConslt.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
        }
        objEntityConslt.Location = txtLocation.Text.Trim();
        if (cbRegistrationSts.Checked == true)
        {
            objEntityConslt.RegStatus = 1;
        }
        else
        {
            objEntityConslt.RegStatus = 0;
        }
        objEntityConslt.ConsultancyEmail = txtCnsltyEmail.Text.Trim();
        objEntityConslt.ConsultancyPhone = txtCnsltyPhone.Text.Trim();
        if (cbStatus.Checked == true)
        {
            objEntityConslt.ConsultancyStatus = 1;
        }
        else
        {
            objEntityConslt.ConsultancyStatus = 0;

        }
        objEntityConslt.ContactName = txtCntctName.Text.Trim();
        objEntityConslt.ContactEmail = txtCntctEmail.Text.Trim();
        objEntityConslt.ContactMobile = txtCntctMobile.Text.Trim();
        objEntityConslt.Date = DateTime.Now;
        string strNameCount = "";
        strNameCount = objBusinessConslt.CheckDupConsultancyName(objEntityConslt);
        if (strNameCount == "0")
        {
            objBusinessConslt.AddConsultancyMstr(objEntityConslt);
            if (clickedButton.ID == "btnAdd")
            {
                
                Response.Redirect("gen_Consultancy_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Consultancy_MasterList.aspx?InsUpd=Ins");
            }
        }
        else
        {
            //duplicate err msg
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicateConsultancyName", "DuplicateConsultancyName();", true);
        }

    }
    public void Update(string strId,int intCorpId,int intOrgId)
    {
          clsEntityConsultancyMaster objEntityConslt = new clsEntityConsultancyMaster();
        clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
        objEntityConslt.ConsultancyId = Convert.ToInt32(strId);
        HiddenConsultancyId.Value = strId;
        objEntityConslt.CorpId = intCorpId;
        objEntityConslt.OrgId = intOrgId;
        DataTable dtConsltDetails = new DataTable();
        dtConsltDetails=objBusinessConslt.ReadConsultancyByID(objEntityConslt);
        if (dtConsltDetails.Rows.Count > 0)
        {
            txtCnsltyName.Text = dtConsltDetails.Rows[0]["CNSLT_NAME"].ToString();
            txtAddress.Text = dtConsltDetails.Rows[0]["CNSLT_ADDR"].ToString();
            if (dtConsltDetails.Rows[0]["CNSLT_REG_STATUS"].ToString() == "1")
            {
                cbRegistrationSts.Checked = true;
            }
            else
            {
                cbRegistrationSts.Checked = false;
            }
            //ie IF  Country IS ACTIVE

            if (ddlCountry.Items.FindByText(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()) != null)
                {
                    ddlCountry.ClearSelection();
                    ddlCountry.Items.FindByText(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
                }            
            else if(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()!="" &&dtConsltDetails.Rows[0]["CNTRY_ID"].ToString()!="")
            {
                ListItem lst = new ListItem(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString(), dtConsltDetails.Rows[0]["CNTRY_ID"].ToString());
                ddlCountry.Items.Insert(1, lst);
                SortDDL(ref this.ddlCountry);
                ddlCountry.ClearSelection();
                ddlCountry.Items.FindByText(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            //ie IF  Country IS ACTIVE

            if (ddlCnsltyType.Items.FindByText(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString()) != null)
            {
                ddlCnsltyType.ClearSelection();
                ddlCnsltyType.Items.FindByText(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString()).Selected = true;
            }
            else if (dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString() != "" && dtConsltDetails.Rows[0]["CNSLTTYPE_ID"].ToString() != "")
            {
                ListItem lst = new ListItem(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString(), dtConsltDetails.Rows[0]["CNSLTTYPE_ID"].ToString());
                ddlCnsltyType.Items.Insert(1, lst);
                SortDDL(ref this.ddlCnsltyType);
                ddlCnsltyType.ClearSelection();
                ddlCnsltyType.Items.FindByText(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString()).Selected = true;
            }
            txtLocation.Text = dtConsltDetails.Rows[0]["CNSLT_LOCATION"].ToString();
            txtRegistrationNo.Text = dtConsltDetails.Rows[0]["CNSLT_REG_NO"].ToString();
            txtCnsltyEmail.Text = dtConsltDetails.Rows[0]["CNSLT_EMAIL"].ToString();
            txtCnsltyPhone.Text = dtConsltDetails.Rows[0]["CNSLT_PHONE"].ToString();
            if (dtConsltDetails.Rows[0]["CNSLT_STATUS"].ToString() == "1")
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }
            txtCntctName.Text = dtConsltDetails.Rows[0]["CNSLT_CNTCT_NAME"].ToString();
            txtCntctEmail.Text = dtConsltDetails.Rows[0]["CNSLT_CNTCT_EMAIL"].ToString();
            txtCntctMobile.Text = dtConsltDetails.Rows[0]["CNSLT_CNTCT_MOBILE"].ToString();
           //GN_CONSULTANCY_MASTER.CNTRY_ID,GN_COUNTRY_MASTER.CNTRY_NAME,GN_CONSULTANCY_MASTER.CNSLTTYPE_ID,GN_CONSULTANCY_TYPE.CNSLTTYPE_NAME,,,,,,,, 
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
    public void View(string strId, int intCorpId, int intOrgId)
    {
        clsEntityConsultancyMaster objEntityConslt = new clsEntityConsultancyMaster();
        clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
        objEntityConslt.ConsultancyId = Convert.ToInt32(strId);
        objEntityConslt.CorpId = intCorpId;
        objEntityConslt.OrgId = intOrgId;
        DataTable dtConsltDetails = new DataTable();
        dtConsltDetails = objBusinessConslt.ReadConsultancyByID(objEntityConslt);
        if (dtConsltDetails.Rows.Count > 0)
        {
            txtCnsltyName.Text = dtConsltDetails.Rows[0]["CNSLT_NAME"].ToString();
            txtAddress.Text = dtConsltDetails.Rows[0]["CNSLT_ADDR"].ToString();
            if (dtConsltDetails.Rows[0]["CNSLT_REG_STATUS"].ToString() == "1")
            {
                cbRegistrationSts.Checked = true;
            }
            else
            {
                cbRegistrationSts.Checked = false;
            }
            //ie IF  Country IS ACTIVE

            if (ddlCountry.Items.FindByText(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()) != null)
            {
                ddlCountry.ClearSelection();
                ddlCountry.Items.FindByText(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            else if (dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString() != "" && dtConsltDetails.Rows[0]["CNTRY_ID"].ToString() != "")
            {
                ListItem lst = new ListItem(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString(), dtConsltDetails.Rows[0]["CNTRY_ID"].ToString());
                ddlCountry.Items.Insert(1, lst);
                SortDDL(ref this.ddlCountry);
                ddlCountry.ClearSelection();
                ddlCountry.Items.FindByText(dtConsltDetails.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }
            //ie IF  Country IS ACTIVE

            if (ddlCnsltyType.Items.FindByText(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString()) != null)
            {
                ddlCnsltyType.ClearSelection();
                ddlCnsltyType.Items.FindByText(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString()).Selected = true;
            }
            else if (dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString() != "" && dtConsltDetails.Rows[0]["CNSLTTYPE_ID"].ToString() != "")
            {
                ListItem lst = new ListItem(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString(), dtConsltDetails.Rows[0]["CNSLTTYPE_ID"].ToString());
                ddlCnsltyType.Items.Insert(1, lst);
                SortDDL(ref this.ddlCnsltyType);
                ddlCnsltyType.ClearSelection();
                ddlCnsltyType.Items.FindByText(dtConsltDetails.Rows[0]["CNSLTTYPE_NAME"].ToString()).Selected = true;
            }
            txtLocation.Text = dtConsltDetails.Rows[0]["CNSLT_LOCATION"].ToString();
            txtRegistrationNo.Text = dtConsltDetails.Rows[0]["CNSLT_REG_NO"].ToString();
            txtCnsltyEmail.Text = dtConsltDetails.Rows[0]["CNSLT_EMAIL"].ToString();
            txtCnsltyPhone.Text = dtConsltDetails.Rows[0]["CNSLT_PHONE"].ToString();
            if (dtConsltDetails.Rows[0]["CNSLT_STATUS"].ToString() == "1")
            {
                cbStatus.Checked = true;
            }
            else
            {
                cbStatus.Checked = false;
            }
            txtCntctName.Text = dtConsltDetails.Rows[0]["CNSLT_CNTCT_NAME"].ToString();
            txtCntctEmail.Text = dtConsltDetails.Rows[0]["CNSLT_CNTCT_EMAIL"].ToString();
            txtCntctMobile.Text = dtConsltDetails.Rows[0]["CNSLT_CNTCT_MOBILE"].ToString();
            //GN_CONSULTANCY_MASTER.CNTRY_ID,GN_COUNTRY_MASTER.CNTRY_NAME,GN_CONSULTANCY_MASTER.CNSLTTYPE_ID,GN_CONSULTANCY_TYPE.CNSLTTYPE_NAME,,,,,,,, 
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityConsultancyMaster objEntityConslt = new clsEntityConsultancyMaster();
        clsBusinessLayerConsultancyMaster objBusinessConslt = new clsBusinessLayerConsultancyMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityConslt.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityConslt.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityConslt.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityConslt.ConsultancyId = Convert.ToInt32(HiddenConsultancyId.Value);
        objEntityConslt.ConsultancyName = txtCnsltyName.Text.Trim().ToUpper();
        objEntityConslt.ConsultancyAddress = txtAddress.Text.Trim();
        objEntityConslt.RegNo = txtRegistrationNo.Text.Trim();
        if (ddlCnsltyType.SelectedItem.Value.ToString() != "--SELECT CONSULTANCY TYPE--")
        {
            objEntityConslt.ConsultancyTypeId = Convert.ToInt32(ddlCnsltyType.SelectedItem.Value);
        }
        if (ddlCountry.SelectedItem.Value.ToString() != "--SELECT COUNTRY--")
        {
            objEntityConslt.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
        }
        objEntityConslt.Location = txtLocation.Text.Trim();
        if (cbRegistrationSts.Checked == true)
        {
            objEntityConslt.RegStatus = 1;
        }
        else
        {
            objEntityConslt.RegStatus = 0;
        }
        objEntityConslt.ConsultancyEmail = txtCnsltyEmail.Text.Trim();
        objEntityConslt.ConsultancyPhone = txtCnsltyPhone.Text.Trim();
        if (cbStatus.Checked == true)
        {
            objEntityConslt.ConsultancyStatus = 1;
        }
        else
        {
            objEntityConslt.ConsultancyStatus = 0;

        }
        objEntityConslt.ContactName = txtCntctName.Text.Trim();
        objEntityConslt.ContactEmail = txtCntctEmail.Text.Trim();
        objEntityConslt.ContactMobile = txtCntctMobile.Text.Trim();
        objEntityConslt.Date = DateTime.Now;
        string strNameCount = "";
        strNameCount = objBusinessConslt.CheckDupConsultancyName(objEntityConslt);
        if (strNameCount == "0")
        {
            objBusinessConslt.UpdateConsultancyMstr(objEntityConslt);
            if (clickedButton.ID == "btnUpdate")
            {

                Response.Redirect("gen_Consultancy_Master.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("gen_Consultancy_MasterList.aspx?InsUpd=Upd");
            }
        }
        else
        {
            //duplicate err msg
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicateConsultancyName", "DuplicateConsultancyName();", true);
        }
    }
    //protected void btnClear_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("gen_Consultancy_Master.aspx");
    //}
}