using System;
using System.Data;
using BL_Compzit;
using EL_Compzit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CL_Compzit;
using System.Net;
using MailUtility_ERP;
using System.Threading;
using System.Text;
using HashingUtility;

// CREATED BY:EVM-0001
// CREATED DATE:20/02/2016
// REVIEWED BY:
// REVIEW DATE:
public partial class Master_gen_Org_Parking_Gen_Org_Parking_Reg2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        //Assigning enter key direction on each fields
        txtOrgName.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgAdd1.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgAdd2.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgAdd3.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgZip.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgPhone.Attributes.Add("onkeydown", "return isNumber(event)");
        txtOrgPhone.Attributes.Add("onblur", "return BlurNotNumber('" + txtOrgPhone.ClientID + "')");
        txtOrgMobile.Attributes.Add("onkeydown", "return isNumber(event)");
        txtOrgMobile.Attributes.Add("onblur", "return BlurNotNumber('" + txtOrgMobile.ClientID + "')");

        txtOrgWebsite.Attributes.Add("onkeypress", "return isTag(event)");
        txtOrgEmail.Attributes.Add("onkeypress", "return isTag(event)");
        cbxPswdVisible.Attributes.Add("onkeypress", "return DisableEnter(event)");

        txtOrgPwd.Attributes.Add("onkeypress", "return Password_Strength(event)");
        txtOrgConPwd.Attributes.Add("onkeypress", "return isTag(event)");
        txtContactPerson.Attributes.Add("onkeypress", "return isTag(event)");

        if (!IsPostBack)
        {



            DataTable dtConfigDtl = new DataTable();
            clsBusinessLayer objBusines = new clsBusinessLayer();
            clsBusinessLayerLogin objBusinesLogin = new clsBusinessLayerLogin();
            dtConfigDtl = objBusines.LoadConfigDetail();
            string strDvlprInfo = "0";
            int intOnCloud = 1;
            hiddenlblOnCloudOrNot.Value = intOnCloud.ToString();
            if (dtConfigDtl.Rows.Count > 0)
            {
                strDvlprInfo = dtConfigDtl.Rows[0]["DVLPR_INFO"].ToString().Trim();
                intOnCloud = Convert.ToInt16(dtConfigDtl.Rows[0]["ON_CLOUD"].ToString().Trim());
                hiddenlblOnCloudOrNot.Value = intOnCloud.ToString();
            }
            //to show developed by information
            if (strDvlprInfo == "1")
            {
                string strCompanyName = "", strCompanyWeb = "";

                DataTable dtCompanyDetail = new DataTable();
                clsCommonLibrary.APP_COMPANY[] arrEnumer = { clsCommonLibrary.APP_COMPANY.CMPNY_NAME, clsCommonLibrary.APP_COMPANY.CMPNY_WEB, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_NAME, clsCommonLibrary.APP_COMPANY.CHNL_PARTNR_WEB };
                dtCompanyDetail = objBusines.LoadCompanyDetail(arrEnumer);
                if (dtCompanyDetail.Rows.Count > 0)
                {
                    if (dtCompanyDetail.Rows[0]["CHNL_PARTNR_NAME"].ToString() != "")
                    {
                        strCompanyName = dtCompanyDetail.Rows[0]["CHNL_PARTNR_NAME"].ToString();
                        strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CHNL_PARTNR_WEB"].ToString();
                    }
                    else
                    {
                        strCompanyName = dtCompanyDetail.Rows[0]["CMPNY_NAME"].ToString();
                        strCompanyWeb = "http://" + dtCompanyDetail.Rows[0]["CMPNY_WEB"].ToString();

                    }

                }
                divdevelop.InnerHtml = "Developed by: <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";
            }
            else
            {
                divdevelop.InnerHtml = "";

            }
            if (intOnCloud == Convert.ToInt16(clsCommonLibrary.Cloud.NotCloud))
            {
                string strCheck = objBusinesLogin.CheckForNewRegister();
                if (strCheck == "0")
                {

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script>alert('An organization is already registered for COMPZIT Application. You can login after approval!') ;windows:location='../../Default.aspx'</script>");

                }


            }


            FrameworkLoad();
            ddlOrgType.Focus();
            OrgTypeLoad();
            CountryLoad();
            LicensePackLoad();
            CorporatePackLoad();

        }

    }

    //Method for binding framework details to dropdown list.
    public void FrameworkLoad()
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        DataTable dtOrganisation = objBusinessLayerOrgParking.ReadFramework();
        if (dtOrganisation.Rows.Count>0)
        {
            ddlFramework.DataSource = dtOrganisation;
            ddlFramework.DataTextField = "FRMWRK_NAME";
            ddlFramework.DataValueField = "FRMWRK_ID";
            ddlFramework.DataBind();
        }
        ddlFramework.Items.Insert(0, "--Select Framework--");
    }

    //Method for binding organisation type details to dropdown list.
    public void OrgTypeLoad()
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        DataTable dtOrganisation = objBusinessLayerOrgParking.ReadOrganisationType();
        DataView dvOrgType = new DataView(dtOrganisation);
        dvOrgType.Sort = "ORGCTY_NAME";
        ddlOrgType.DataSource = dvOrgType;
        for (int intDtCnt = 0; intDtCnt < dtOrganisation.Rows.Count; intDtCnt++)
        {
            ddlOrgType.DataTextField = "ORGCTY_NAME";
            ddlOrgType.DataValueField = "ORGCTY_ID";
            ddlOrgType.DataBind();
        }
        ddlOrgType.Items.Insert(0, "--Select Organization Type--");
    }

    //Method for binding Country type details to dropdown list.
    public void CountryLoad()
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        DataTable dtCountry = objBusinessLayerOrgParking.ReadCountry();
        DataView dvCountry = new DataView(dtCountry);
        dvCountry.Sort = "CNTRY_NAME";
        ddlOrgCountry.DataSource = dvCountry;
        for (int intDtCnt = 0; intDtCnt < dtCountry.Rows.Count; intDtCnt++)
        {

            ddlOrgCountry.DataTextField = "CNTRY_NAME";
            ddlOrgCountry.DataValueField = "CNTRY_ID";
            ddlOrgCountry.DataBind();
        }
        ddlOrgCountry.Items.Insert(0, "--Select Your Country--");
    }

    //When select a country from country dropdown list then bind state details of selected country to state dropdownlist.
    protected void ddlOrgCountry_SelectedIndexChanged(object sender, EventArgs e)
    {//Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        if (ddlOrgCountry.SelectedItem.Text == "--Select Your Country--")
        {
            ddlOrgState.Items.Clear();
            ddlOrgCity.Items.Clear();
        }
        else
        {
            clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
            objEntityOrgParking.CountryId = Convert.ToInt32(ddlOrgCountry.SelectedItem.Value);
            DataTable dtState = objBusinessLayerOrgParking.ReadState(objEntityOrgParking);
            DataView dvState = new DataView(dtState);
            dvState.Sort = "STATE_NAME";
            ddlOrgState.DataSource = dvState;
            ddlOrgCity.Items.Clear();
            //if selected country have no states
            if (dtState.Rows.Count == 0)
            {
                ddlOrgState.Items.Clear();
                ddlOrgState.Items.Insert(0, "--Select Your State--");
            }
            else
            {
                for (int intDtCnt = 0; intDtCnt < dtState.Rows.Count; intDtCnt++)
                {
                    ddlOrgState.DataTextField = "STATE_NAME";
                    ddlOrgState.DataValueField = "STATE_ID";
                    ddlOrgState.DataBind();
                }
                ddlOrgState.Items.Insert(0, "--Select Your State--");
                ddlOrgCountry.Focus();
            }
        }
    }

    //When select a state from state dropdown list then bind city details of selected state to city dropdownlist.
    protected void ddlOrgState_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        if (ddlOrgState.SelectedItem.Text == "--Select Your State--")
        {
            ddlOrgCity.Items.Clear();
        }
        else
        {
            clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
            objEntityOrgParking.StateId = Convert.ToInt32(ddlOrgState.SelectedItem.Value);
            DataTable dtCity = objBusinessLayerOrgParking.ReadCity(objEntityOrgParking);
            DataView dvCity = new DataView(dtCity);
            dvCity.Sort = "CITY_NAME";
            ddlOrgCity.DataSource = dvCity;
            //if selected states have no city
            if (dtCity.Rows.Count == 0)
            {
                ddlOrgCity.Items.Clear();
                ddlOrgCity.Items.Insert(0, "--Select Your City--");
            }
            else
            {
                for (int intDtCnt = 0; intDtCnt < dtCity.Rows.Count; intDtCnt++)
                {
                    ddlOrgCity.DataTextField = "CITY_NAME";
                    ddlOrgCity.DataValueField = "CITY_ID";
                    ddlOrgCity.DataBind();
                }
                ddlOrgCity.Items.Insert(0, "--Select Your City--");
                ddlOrgState.Focus();
            }
        }
    }

    //Method for bind license pack details to dropdown list.
    public void LicensePackLoad()
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        DataTable dtLicense = objBusinessLayerOrgParking.ReadLicensePack();
        ddlOrgLicPac.DataSource = dtLicense;
        for (int intDtCnt = 0; intDtCnt < dtLicense.Rows.Count; intDtCnt++)
        {

            ddlOrgLicPac.DataTextField = "LIC_PACK_NAME";
            ddlOrgLicPac.DataValueField = "LIC_PACK_ID";
            ddlOrgLicPac.DataBind();
        }
        ddlOrgLicPac.Items.Insert(0, "--Choose Your License Pack--");

    }

    //Method of bind corporate pack details to dropdown list.
    public void CorporatePackLoad()
    {//Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        DataTable dtCorporate = objBusinessLayerOrgParking.ReadCorporatePack();
        ddlOrgCorPac.DataSource = dtCorporate;
        for (int intDtCnt = 0; intDtCnt < dtCorporate.Rows.Count; intDtCnt++)
        {

            ddlOrgCorPac.DataTextField = "CORP_PACK_NAME";
            ddlOrgCorPac.DataValueField = "CORP_PACK_ID";
            ddlOrgCorPac.DataBind();
        }
        ddlOrgCorPac.Items.Insert(0, "--Choose Your Corporate Pack--");
    }


    //When a license pack is selected from license pack dropdown list then assign its maximum users details to a textbox.
    protected void ddlOrgLicPac_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        if (ddlOrgLicPac.SelectedItem.Text == "--Choose Your License Pack--")
        {
            txtLicPacCount.Text = null;
        }
        else
        {
            clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
            objEntityOrgParking.LicPacId = Convert.ToInt32(ddlOrgLicPac.SelectedItem.Value);
            DataTable dtLicPacCount = objBusinessLayerOrgParking.ReadLicPacCount(objEntityOrgParking);
            txtLicPacCount.Text = dtLicPacCount.Rows[0]["LIC_PACK_ENDS"].ToString();
            ddlOrgLicPac.Focus();
        }
    }

    //When a corporate pack is selected from corporate pack dropdown list then bind its office allowed details to a textbox.
    protected void ddlOrgCorPac_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        if (ddlOrgCorPac.SelectedItem.Text == "--Choose Your Corporate Pack--")
        {
            txtCorPacCount.Text = null;
        }
        else
        {
            clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
            objEntityOrgParking.CorPacId = Convert.ToInt32(ddlOrgCorPac.SelectedItem.Value);
            DataTable dtCorPacCount = objBusinessLayerOrgParking.ReadCorPacCount(objEntityOrgParking);
            txtCorPacCount.Text = dtCorPacCount.Rows[0]["CORP_PACK_COUNT"].ToString();
            ddlOrgCorPac.Focus();
        }
    }

    //Method for fetch the server port and domain name.
    public string GetServerDetail()
    {
        string strDomainName = Request.ServerVariables["server_name"].ToString();
        string strPort = Request.ServerVariables["server_port"].ToString();
        string strHostAddr = strDomainName + ":" + strPort;
        return strHostAddr;

    }

    //Passing all details about registering organisation to business layer when save button clicked.
    protected void btnOrgSave_Click(object sender, EventArgs e)
    {   //Creating object for clsBusinessLayer Mail in in the BusinessLayer
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        //Creating object for clsMail  in in the MailUtility Layer
        clsMail objMail = new clsMail();
        string strTransId = "";
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();


        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
        //Method for fetching nextvalue for insertion.
        objEntityOrgParking.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.Corporate_Office);
        DataTable dtNextId = objBusinessLayerOrgParking.ReadNextId(objEntityOrgParking);
        objEntityOrgParking.NextValue = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);

        objEntityOrgParking.FrameworkId = Convert.ToInt32(ddlFramework.SelectedItem.Value);
        objEntityOrgParking.OrgTypeId = Convert.ToInt32(ddlOrgType.SelectedItem.Value);
        objEntityOrgParking.Organisation_Name = txtOrgName.Text.ToUpper().Trim();
        objEntityOrgParking.Address1 = txtOrgAdd1.Text.Trim();
        objEntityOrgParking.Address2 = txtOrgAdd2.Text.Trim();
        objEntityOrgParking.Address3 = txtOrgAdd3.Text.Trim();
        objEntityOrgParking.CountryId = Convert.ToInt32(ddlOrgCountry.SelectedItem.Value);
        //If there is no state selected
        if (ddlOrgState.SelectedItem.Text == "--Select Your State--")
        {
            objEntityOrgParking.StateId = null;
            objEntityOrgParking.CityId = null;
        }
        else
        {
            objEntityOrgParking.StateId = Convert.ToInt32(ddlOrgState.SelectedItem.Value);
            //If there is no city selected
            if (ddlOrgCity.SelectedItem.Text == "--Select Your City--")
            {
                objEntityOrgParking.CityId = null;
            }
            else
            {
                objEntityOrgParking.CityId = Convert.ToInt32(ddlOrgCity.SelectedItem.Value);

            }
        }
        objEntityOrgParking.ZipCode = txtOrgZip.Text.Trim();
        objEntityOrgParking.Mobile_Number = txtOrgMobile.Text.Trim();
        objEntityOrgParking.Phone_Number = txtOrgPhone.Text.Trim();
        objEntityOrgParking.Web_Address = txtOrgWebsite.Text.Trim();
        objEntityOrgParking.Contact_Person = txtContactPerson.Text.Trim();

        objEntityOrgParking.Email_Address = txtOrgEmail.Text.Trim();
        // hashing the password
        string strPwd = txtOrgPwd.Text.Trim();
        clsHash objHashing = new clsHash();
        string strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));


        objEntityOrgParking.Password = strEncryptedPwd;
        objEntityOrgParking.LicPacId = Convert.ToInt32(ddlOrgLicPac.SelectedItem.Value);
        objEntityOrgParking.LicPacCount = Convert.ToInt32(txtLicPacCount.Text);
        objEntityOrgParking.CorPacId = Convert.ToInt32(ddlOrgCorPac.SelectedItem.Value);
        objEntityOrgParking.CorPacCount = Convert.ToInt32(txtCorPacCount.Text);
        objEntityOrgParking.OrgStatusId = Convert.ToInt32(clsCommonLibrary.Status.Status_New);
        objEntityOrgParking.OrganisationStatusDate = System.DateTime.Now;
        objEntityOrgParking.OrgInsertDate = System.DateTime.Now;
        objEntityOrgParking.IP_Address = objCommon.GetIp();
        objEntityOrgParking.Verification_Code = objCommon.Random_Number() + objEntityOrgParking.NextValue;
        objEntityOrgParking.Verification_Link = "http://" + GetServerDetail() + "/Master/gen_Org_Verification/gen_Org_Verification.aspx";
        //for password encryption
        clsCommonLibrary.Encrp_Pwd(objEntityOrgParking);

        //Checking database table have already this email or not.
        DataTable dtEmailCount = objBusinessLayerOrgParking.EmailCheck(objEntityOrgParking);
        string strEmailCount = dtEmailCount.Rows[0]["COUNT(ORG_PARK_ID)"].ToString();
        DataTable dtEmailCountUser = objBusinessLayerOrgParking.EmailCheckUser(objEntityOrgParking);
        string strEmailCountUser = dtEmailCountUser.Rows[0]["COUNT(USR_ID)"].ToString();
        //Parking table have no existed email like this.
        if (strEmailCount == "0")
        {
            //Users table have no existed email like this.
            if (strEmailCountUser == "0")
            {
                //Check wheather this organisation name already exist or not
                DataTable dtOrg = objBusinessLayerOrgParking.CheckOrgName(objEntityOrgParking);
                string strOrg = dtOrg.Rows[0]["COUNT(ORG_PARK_ID)"].ToString();
                if (strOrg == "0")
                {
                    clsBusinessLayer objBusines = new clsBusinessLayer();
                    DataTable dtConfigDtl = new DataTable();
                    dtConfigDtl = objBusines.LoadConfigDetail();

                    string strTemplateId = "";
                    if (dtConfigDtl.Rows.Count > 0)
                    {
                        strTemplateId = dtConfigDtl.Rows[0]["DFLT_ORG_EMTMPLT_ID"].ToString();
                    }
                    DataTable dtCompanyDetail = new DataTable();
                    DataTable dtTemplateDetail = new DataTable();
                    dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
                    objMail.InstantMail(strTemplateId, ref dtTemplateDetail);

                    // Saving to organization parking table and to Gn_Email_Store.
                    strTransId = objEntityOrgParking.NextValue.ToString(); ;
                    objBusinessLayerOrgParking.InsertOrgParking_Mail(objEntityOrgParking, strTemplateId, dtCompanyDetail, dtTemplateDetail);

                    //for sending mail, avoid time delay we use threading
                    // Thread threadMail = new Thread(() => Mail(objEntityOrgParking));
                    //threadMail.Start();
                    Mail(objEntityOrgParking, strTransId);



                    if (hiddenlblOnCloudOrNot.Value != "")
                    {
                        int intOnCloud = Convert.ToInt32(hiddenlblOnCloudOrNot.Value);

                        if (intOnCloud == Convert.ToInt16(clsCommonLibrary.Cloud.NotCloud))
                        {
                            string strAlertMsg = "<script>alert('Registration Successful, Please Select Verification Link Send to Your Registered E-Mail ID!');windows:location='../../Default.aspx'</script>";
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", strAlertMsg);



                        }
                        else
                        {
                            string strAlertMsg = "<script>alert('Registration Successful, Please Select Verification Link Send to Your Registered E Mail ID!');windows:location='../../Default.aspx'</script>"; //Master/gen_Org_Parking/gen_Org_Parking_Reg.aspx
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", strAlertMsg);

                        }


                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtOrgName.Focus();
                }
            }
            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);

                txtOrgEmail.Focus();
            }
        }
        //If have
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
            txtOrgEmail.Focus();
        }
    }
    //Method for sending mail.
    public void Mail(clsEntityOrgParking objEntityOrgParking, string strTransId)
    {

        //Creating object for clsBusinessLayer Mail in in the BusinessLayer
        clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
        //Creating object for clsMail  in in the MailUtility Layer
        clsMail objMail = new clsMail();

        clsBusinessLayer objBusines = new clsBusinessLayer();
        DataTable dtConfigDtl = new DataTable();
        dtConfigDtl = objBusines.LoadConfigDetail();

        string strTemplateId = "";
        if (dtConfigDtl.Rows.Count > 0)
        {

            strTemplateId = dtConfigDtl.Rows[0]["DFLT_ORG_EMTMPLT_ID"].ToString();
        }



        // EntityLayer.clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();

        DataTable dtCompanyDetail = new DataTable();
        //  DataTable dtTemplateDetail = new DataTable();
        dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
        // objMail.InstantMail("3", ref dtTemplateDetail);
        // save to registration table
        // save to message table
        // objBusinessLayerMail.InstantMailInsert("3", objEntityOrgParking.Email_Address,objEntityOrgParking.NextValue.ToString(), dtCompanyDetail, dtTemplateDetail);
        // on success send mail
        objMail.BulkMail(strTemplateId, strTransId, dtCompanyDetail, objEntityOrgParking);
        //   objMail.BulkMail();
    }
}