using BL_Compzit;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Employee_Sponsor_Master : System.Web.UI.Page
{
    int SPSNR_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSponsorName.Focus();
        //Assigning  Key actions  .

        txtSponsorName.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorAddress1.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorAddress1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorAddress2.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorAddress2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorAddress3.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorAddress3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorDocNo.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorDocNo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorFax.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorFax.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtSponsorPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSponsorEmail.Attributes.Add("onkeypress", "return isTag(event)");
        ddlSpnsrType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlSpnsrType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlcountry.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlcountry.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {
            SponsorType_Load();
            Country_Load();
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Transfer);
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

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        HiddnEnableCacel.Value = "1";
                        intEnableCancel = 1;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = 1;

                    }

                }
            }
            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

            }
            else
            {



            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
               
            }
            else
            {
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
            }

            if (intEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;

            }
            else
            {

            }

            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                 Update(strId);
                 lblEntry.Text = "Edit Employee Sponsor";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                lblEntry.Text = "View Employee Sponsor";
  
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                btnCancel.Attributes.CssStyle.Add("margin-left", "22%");
                View(strId);

                        }
                            //when  viewing
            else if (Request.QueryString["canId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["canId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                // string strId = strRandomMixedId.Substring(2, intLenghtofId);

                // View(strId, intCorpId);

              
            }
           
            else
            {
                lblEntry.Text = "Add Employee Sponsor";


                clsEntityCommon objEntityCommon = new clsEntityCommon();

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONTRACT);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                string year = DateTime.Today.Year.ToString();

                //     lblRefNumber.Text = "CNTRCT/" + year + "/" + strNextId;
              
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
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                    }
                    else if (strInsUpd == "Upd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                    }

                    else if (strInsUpd == "PrjIns")
                    {
                        //  btnSkip.Visible = true;
                        //  btnAddNext.Visible = true;
                        btnAddClose.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrj", "SuccessConfirmationPrj();", true);
                    }
                    else if (strInsUpd == "PrjUpd")
                    {
                        //    btnSkip.Visible = true;
                        //   btnAddNext.Visible = true;
                        btnAddClose.Visible = false;
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrj", "SuccessUpdationPrj();", true);
                    }
                }






            }
        }
    }

    //methode for loading the country
    public void Country_Load()
    {
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
      //  clsEntitySponsor objEntitySponsor = new clsEntitySponsor();

        DataTable dtCountry = objBusinessEmployeeSponsor.Read_Country();

        ddlcountry.Items.Clear();

        ddlcountry.DataSource = dtCountry;

        ddlcountry.DataTextField = "CNTRY_NAME";
        ddlcountry.DataValueField = "CNTRY_ID";
        ddlcountry.DataBind();

        ddlcountry.Items.Insert(0, "--SELECT COUNTRY--");




    }
    public void SponsorType_Load()
    {
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
        //clsEntitySponsor objEntitySponsor = new clsEntitySponsor();
    

        DataTable dtCountry = objBusinessEmployeeSponsor.Read_SponsorType();

        ddlSpnsrType.Items.Clear();

        ddlSpnsrType.DataSource = dtCountry;

        ddlSpnsrType.DataTextField = "SPNSR_TYPE_NAME";
        ddlSpnsrType.DataValueField = "SPNSR_TYPE_ID";
        ddlSpnsrType.DataBind();

        ddlSpnsrType.Items.Insert(0, "--SELECT TYPE--");
        ddlSpnsrType.SelectedIndex=0;



    }


    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntityEmployee = new clsEntityLayerEmployeeSponsorMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmployee.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmployee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityEmployee.Sponsor_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityEmployee.Sponsor_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityEmployee.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityEmployee.SponsrDate = System.DateTime.Now;
        txtSponsorName.Text = txtSponsorName.Text.ToUpper().Trim();
        objEntityEmployee.Sponsor_Name = txtSponsorName.Text;

        //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);
        objEntityEmployee.SponsorType_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);

        objEntityEmployee.Address1 = txtSponsorAddress1.Text;

        if (txtSponsorAddress2.Text != "" && txtSponsorAddress2.Text != null)
            objEntityEmployee.Address2 = txtSponsorAddress2.Text;

        if (txtSponsorAddress3.Text != "" && txtSponsorAddress3.Text != null)
            objEntityEmployee.Address3 = txtSponsorAddress3.Text;

        objEntityEmployee.CountryId = Convert.ToInt32(ddlcountry.SelectedItem.Value);




        objEntityEmployee.SponsorDoc_No = txtSponsorDocNo.Text;
        objEntityEmployee.Phone_Number = txtSponsorPhone.Text;
        objEntityEmployee.Mobile_Number = txtMobile.Text;
        objEntityEmployee.Email_Address = txtSponsorEmail.Text;
        objEntityEmployee.Phone_Number = txtSponsorPhone.Text.Trim();
        objEntityEmployee.Fax_Number = txtSponsorFax.Text;

        string strcount = objBusinessEmployeeSponsor.CheckEmployeeSponsor(objEntityEmployee);
        if (strcount == "1")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);


        }
        else
        {
            objBusinessEmployeeSponsor.AddEmployeeSponsor(objEntityEmployee);

           

            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("gen_Employee_Sponsor_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("gen_Employee_Sponsor_List.aspx?InsUpd=Ins");
            }




        }
       
    }

    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
            clsEntityLayerEmployeeSponsorMaster objEntityEmployee = new clsEntityLayerEmployeeSponsorMaster();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityEmployee.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityEmployee.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityEmployee.Sponsor_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityEmployee.Sponsor_Status = 0;
            }
            if (Session["USERID"] != null)
            {
                objEntityEmployee.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityEmployee.Sponsor_Id = int.Parse(Hiddensponsorid.Value);
            objEntityEmployee.SponsrDate = System.DateTime.Now;
            txtSponsorName.Text = txtSponsorName.Text.ToUpper().Trim();
            objEntityEmployee.Sponsor_Name = txtSponsorName.Text;

            //  objEntityEmployee.Sponsor_Group_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);
            objEntityEmployee.SponsorType_Id = Convert.ToInt32(ddlSpnsrType.SelectedItem.Value);

            objEntityEmployee.Address1 = txtSponsorAddress1.Text;

            if (txtSponsorAddress2.Text != "" && txtSponsorAddress2.Text != null)
                objEntityEmployee.Address2 = txtSponsorAddress2.Text;

            if (txtSponsorAddress3.Text != "" && txtSponsorAddress3.Text != null)
                objEntityEmployee.Address3 = txtSponsorAddress3.Text;

            objEntityEmployee.CountryId = Convert.ToInt32(ddlcountry.SelectedItem.Value);




            objEntityEmployee.SponsorDoc_No = txtSponsorDocNo.Text;
            objEntityEmployee.Phone_Number = txtSponsorPhone.Text;
            objEntityEmployee.Mobile_Number = txtMobile.Text;
            objEntityEmployee.Email_Address = txtSponsorEmail.Text;
            objEntityEmployee.Phone_Number = txtSponsorPhone.Text.Trim();
            objEntityEmployee.Fax_Number = txtSponsorFax.Text;
        
            string strcount = objBusinessEmployeeSponsor.CheckEmployeeSponsor(objEntityEmployee);
            if (strcount == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);


            }
            else
            {
                objBusinessEmployeeSponsor.UpdateEmployeeSponsor(objEntityEmployee);
                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Employee_Sponsor_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Employee_Sponsor_List.aspx?InsUpd=Upd");
                }


            }
        }

    }

    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {
        txtSponsorName.Enabled = false;
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        //   clsEntitySponsor objEntitySponsor = new clsEntitySponsor();
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();
        if (Session["USERID"] != null)
        {

            objEntitySpnsrMstr.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {

            objEntitySpnsrMstr.UserId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntitySpnsrMstr.CorpId = intCorpId;

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {

            objEntitySpnsrMstr.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        Hiddensponsorid.Value = strP_Id;

        objEntitySpnsrMstr.Sponsor_Id = Convert.ToInt32(strP_Id);
        DataTable dtSponsor = objBusinessEmployeeSponsor.ReadEmployeeSponsorById(objEntitySpnsrMstr);
        if (dtSponsor.Rows.Count > 0)
        {
            txtSponsorName.Text = dtSponsor.Rows[0]["SPNSR_NAME"].ToString();


            Country_Load();
            SponsorType_Load();

            //ddlSpnsrType.SelectedValue = dtSponsor.Rows[0]["CSTMRTYP_ID"].ToString();
            txtSponsorDocNo.Text = dtSponsor.Rows[0]["SPNSR_DOCNO"].ToString();
            txtSponsorDocNo.Enabled = false;
            txtSponsorAddress1.Text = dtSponsor.Rows[0]["SPSNSR_ADDRESS1"].ToString();
            txtSponsorAddress1.Enabled = false;
            txtSponsorAddress2.Text = dtSponsor.Rows[0]["SPSNSR_ADDRESS2"].ToString();
            txtSponsorAddress2.Enabled = false;
            txtSponsorAddress3.Text = dtSponsor.Rows[0]["SPSNSR_ADDRESS3"].ToString();
            txtSponsorAddress3.Enabled = false;
            txtSponsorEmail.Text = dtSponsor.Rows[0]["SPSNSR_EMAIL"].ToString();
            txtSponsorEmail.Enabled = false;
            txtSponsorFax.Text = dtSponsor.Rows[0]["SPSNSR_FAX"].ToString();
            txtSponsorFax.Enabled = false;
            txtSponsorPhone.Text = dtSponsor.Rows[0]["SPSNSR_PHONE"].ToString();
            txtSponsorPhone.Enabled = false;
            txtMobile.Text = dtSponsor.Rows[0]["SPSNSR_MOBILE"].ToString();
            txtMobile.Enabled = false;
            //  ddlcountry.Items.Clear();
          //  ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
            if (dtSponsor.Rows[0]["CNTRY_ID"].ToString() != "" && dtSponsor.Rows[0]["CNTRY_STATUS"].ToString() == "1")
            {
                if (ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()) != null)
                    ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["CNTRY_NAME"].ToString(), dtSponsor.Rows[0]["CNTRY_ID"].ToString());
                    ddlcountry.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlcountry);

                    ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["CNTRY_NAME"].ToString(), dtSponsor.Rows[0]["CNTRY_ID"].ToString());
                ddlcountry.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlcountry);

                ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
            }
            //ddlcountry.SelectedValue = dtSponsor.Rows[0]["CNTRY_ID"].ToString();
            ddlcountry.Enabled = false;
            //ddlSpnsrType.Items.Clear();
            ddlSpnsrType.SelectedValue = dtSponsor.Rows[0]["SPSNSR_TYPE_ID"].ToString();
            ddlSpnsrType.Enabled = false;


            int intStatus = Convert.ToInt32(dtSponsor.Rows[0]["SPSNSR_STATUS"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            cbxStatus.Enabled = false;
        }
    }


    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;

        btnUpdateClose.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
        clsBusinessLayerEmployeeSponsor objBusinessEmployeeSponsor = new clsBusinessLayerEmployeeSponsor();
        clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr = new clsEntityLayerEmployeeSponsorMaster();
        if (Session["USERID"] != null)
        {
            objEntitySpnsrMstr.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntitySpnsrMstr.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntitySpnsrMstr.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Sponsor_Master);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnUpdate.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;

            }



        }


            Hiddensponsorid.Value = strP_Id;
            objEntitySpnsrMstr.Sponsor_Id = Convert.ToInt32(strP_Id);
            DataTable dtSponsor = objBusinessEmployeeSponsor.ReadEmployeeSponsorById(objEntitySpnsrMstr);
            txtSponsorName.Text = dtSponsor.Rows[0]["SPNSR_NAME"].ToString();


            Country_Load();
            SponsorType_Load();

            //ddlSpnsrType.SelectedValue = dtSponsor.Rows[0]["CSTMRTYP_ID"].ToString();
            txtSponsorDocNo.Text = dtSponsor.Rows[0]["SPNSR_DOCNO"].ToString();

            txtSponsorAddress1.Text = dtSponsor.Rows[0]["SPSNSR_ADDRESS1"].ToString();

            txtSponsorAddress2.Text = dtSponsor.Rows[0]["SPSNSR_ADDRESS2"].ToString();

            txtSponsorAddress3.Text = dtSponsor.Rows[0]["SPSNSR_ADDRESS3"].ToString();

            txtSponsorEmail.Text = dtSponsor.Rows[0]["SPSNSR_EMAIL"].ToString();

            txtSponsorFax.Text = dtSponsor.Rows[0]["SPSNSR_FAX"].ToString();

            txtSponsorPhone.Text = dtSponsor.Rows[0]["SPSNSR_PHONE"].ToString();

            txtMobile.Text = dtSponsor.Rows[0]["SPSNSR_MOBILE"].ToString();


           // ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;

            if (dtSponsor.Rows[0]["CNTRY_ID"].ToString() != "" && dtSponsor.Rows[0]["CNTRY_STATUS"].ToString() == "1")
            {
                if (ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()) != null)
                    ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                else
                {
                    ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["CNTRY_NAME"].ToString(), dtSponsor.Rows[0]["CNTRY_ID"].ToString());
                    ddlcountry.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlcountry);

                    ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtSponsor.Rows[0]["CNTRY_NAME"].ToString(), dtSponsor.Rows[0]["CNTRY_ID"].ToString());
                ddlcountry.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlcountry);

                ddlcountry.Items.FindByValue(dtSponsor.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
            }
            //ddlSpnsrType.Items.Clear();
            ddlSpnsrType.SelectedValue = dtSponsor.Rows[0]["SPSNSR_TYPE_ID"].ToString();



            int intStatus = Convert.ToInt32(dtSponsor.Rows[0]["SPSNSR_STATUS"]);
            if (intStatus == 1)
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

   
