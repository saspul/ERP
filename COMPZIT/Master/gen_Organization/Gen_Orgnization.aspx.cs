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
using System.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;

public partial class Master_gen_Organization_Gen_Orgnization : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning enter key direction on each fields
        txtCrNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtExpCrDate.Attributes.Add("onkeypress", "return isTag(event)");
        //txtAttach.Attributes.Add("onkeypress", "return isTag(event)");
        txtIssueCrDate.Attributes.Add("onkeypress", "return isTag(event)");

        txtTiNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtExpTxDate.Attributes.Add("onkeypress", "return isTag(event)");
        //txtAttachTax.Attributes.Add("onkeypress", "return isTag(event)");
        txtIssueTxDate.Attributes.Add("onkeypress", "return isTag(event)");

        txtCompNo.Attributes.Add("onkeypress", "return isTag(event)");
        txtExpCompDate.Attributes.Add("onkeypress", "return isTag(event)");
        //txtAttachComp.Attributes.Add("onkeypress", "return isTag(event)");
        txtIssueCompDate.Attributes.Add("onkeypress", "return isTag(event)");

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
        //txtContactPerson.Attributes.Add("onkeypress", "return isTag(event)");

        if (!IsPostBack)
        {

            int intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }


            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();

                if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }

            }
            //btnClear.Visible = false;
            //btnClearUp.Visible = false;
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
                //divdevelop.InnerHtml = "Developed by: <a target= \"_blank \" href=\"" + strCompanyWeb + "\">" + strCompanyName + "</a> ";
            }
            else
            {
               // divdevelop.InnerHtml = "";

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
            string strOrgId = ConfigurationManager.AppSettings["OrganisationId"];
            clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
            clsEntityOrganization objEntityOrganization = new clsEntityOrganization();
            objEntityOrganization.OrgId = Convert.ToInt32(strOrgId);
            int cr = 1;


            hiddenEdit.Value = "Edit";

            DataTable dtOrgDetail = new DataTable();
            dtOrgDetail = objBusinessLayerOrganization.OrgDetails(objEntityOrganization);
            string OrgName = dtOrgDetail.Rows[0]["ORG_NAME"].ToString();
            string add1 = dtOrgDetail.Rows[0]["ORG_ADDR1"].ToString();
            string add2 = dtOrgDetail.Rows[0]["ORG_ADDR2"].ToString();
            string add3 = dtOrgDetail.Rows[0]["ORG_ADDR3"].ToString();
            string zipcode = dtOrgDetail.Rows[0]["ORG_ZIP"].ToString();
            string phone = dtOrgDetail.Rows[0]["ORG_PHONE"].ToString();
            string mob = dtOrgDetail.Rows[0]["ORG_MOBILE"].ToString();
            string web = dtOrgDetail.Rows[0]["ORG_WEBSITE"].ToString();
            string email = dtOrgDetail.Rows[0]["ORG_EMAIL"].ToString();
            string orgcty = dtOrgDetail.Rows[0]["ORGCTY_ID"].ToString();
            string cntry = dtOrgDetail.Rows[0]["CNTRY_ID"].ToString();
            string state = dtOrgDetail.Rows[0]["STATE_ID"].ToString();
            string city = dtOrgDetail.Rows[0]["CITY_ID"].ToString();
            string Lic_id = dtOrgDetail.Rows[0]["LIC_PACK_ID"].ToString();
            string corp_id = dtOrgDetail.Rows[0]["CORP_PACK_ID"].ToString();
            string LicCount = dtOrgDetail.Rows[0]["ORG_LICENSE_COUNTD"].ToString();
            string CorpCount = dtOrgDetail.Rows[0]["ORG_CORPORATE_COUNT"].ToString();
            string crNum = dtOrgDetail.Rows[0]["ORG_CMRCLRGT_NUM"].ToString();
            string txNum = dtOrgDetail.Rows[0]["ORG_TAXCRD_NUM"].ToString();
            string compNum = dtOrgDetail.Rows[0]["ORG_CMPTRCRD_NUM"].ToString();
            string crExDate = dtOrgDetail.Rows[0]["ORG_CMRCLRGT_EXP_DATE"].ToString();
            string crIssueDate = dtOrgDetail.Rows[0]["ORG_CMRCLRGT_ISSUE_DATE"].ToString();
            string txExDate = dtOrgDetail.Rows[0]["ORG_TAXCRD_EXP_DATE"].ToString();
            string txIssueDate = dtOrgDetail.Rows[0]["ORG_TAXCRD_ISSUE_DATE"].ToString();
            string compExDate = dtOrgDetail.Rows[0]["ORG_CMPTRCRD_EXP_DATE"].ToString();
            string compIssueDate = dtOrgDetail.Rows[0]["ORG_CMPTRCRD_ISSUE_DATE"].ToString();

            HiddenFieldState.Value = state;
            HiddenFieldCity.Value = city;
            ddlOrgState.Text = dtOrgDetail.Rows[0]["STATE_NAME"].ToString();
            ddlOrgCity.Text = dtOrgDetail.Rows[0]["CITY_NAME"].ToString();

            clsCommonLibrary objCommon = new clsCommonLibrary();
            //objEntityOrganization.OrgId = objEntityCommon.Organisation_Id;
            for (int s = 1; s < 4; s++)
            {
                cr = s;
                objEntityOrganization.CrRoll = cr;

                DataTable dtCrCard = new DataTable();
                dtCrCard = objBusinessLayerOrganization.OrgCrCard(objEntityOrganization);
                if (dtCrCard.Rows.Count > 0)
                {
                    HiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ORGANIZATION);
                    if (cr == 1)
                    {
                        hiddenFileCR_Attach.Value = DataTableToJSONWithJavaScriptSerializer(dtCrCard);
                    }
                    else if (cr == 2)
                    {
                        hiddenFileTX_Attach.Value = DataTableToJSONWithJavaScriptSerializer(dtCrCard);
                    }
                    else
                    {
                        hiddenFileCOMP_Attach.Value = DataTableToJSONWithJavaScriptSerializer(dtCrCard);
                    }

                }
            }

            txtOrgName.Text = OrgName;
            txtOrgAdd1.Text = add1;
            txtOrgAdd2.Text = add2;
            txtOrgAdd3.Text = add3;
            txtOrgZip.Text = zipcode;
            txtOrgPhone.Text = phone;
            txtOrgMobile.Text = mob;
            txtOrgWebsite.Text = web;
            txtOrgEmail.Text = email;
            txtCrNumber.Text = crNum;
            txtTiNumber.Text = txNum;
            txtCompNo.Text = compNum;

            txtExpCrDate.Value = crExDate;
            txtIssueCrDate.Value = crIssueDate;
            txtExpTxDate.Value = txExDate;
            txtIssueTxDate.Value = txIssueDate;
            txtExpCompDate.Value = compExDate;
            txtIssueCompDate.Value = compIssueDate;
            txtOrgNewPwd.Text = string.Empty;
            ddlOrgType.Focus();
            if (orgcty != "" && orgcty != null)
            {
                OrgTypeLoad1(orgcty);

            }
            else
            {
                OrgTypeLoad();
            }
            if (cntry != "" && cntry != null)
            {
                CountryLoad1(cntry);
            }
            else
            {
                CountryLoad();
            }
            if (Lic_id != null && Lic_id != "")
            {
                LicensePackLoad1(Lic_id);
            }
            else
            {
                LicensePackLoad();
            }
            if (corp_id != null && corp_id != "")
            {
                CorporatePackLoad1(corp_id);
            }
            else
            {
                CorporatePackLoad();
            }

            //////////////////////////////////////////////////////////////////////
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("TransId", typeof(int));
            dtDetail.Columns.Add("TransDtlId", typeof(int));
            dtDetail.Columns.Add("OrgId", typeof(int));
            dtDetail.Columns.Add("PartnerName", typeof(string));
            dtDetail.Columns.Add("DocumentNo", typeof(string));
            dtDetail.Columns.Add("CrNo", typeof(string));
            dtDetail.Columns.Add("ContyNo", typeof(string));
            dtDetail.Columns.Add("SharePer", typeof(decimal));
            dtDetail.Columns.Add("Status", typeof(int));

            DataTable dt = new DataTable();
            dt = objBusinessLayerOrganization.OrgReadPartner(objEntityOrganization);
            for (int intcnt = 0; intcnt < dt.Rows.Count; intcnt++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["TransId"] = Convert.ToInt32(dt.Rows[intcnt]["ORGPARTNR_ID"].ToString());
                drDtl["TransDtlId"] = Convert.ToInt32(dt.Rows[intcnt]["ORGPARTNR_ID"].ToString());
                drDtl["OrgId"] = Convert.ToInt32(dt.Rows[intcnt]["ORG_ID"].ToString());
                drDtl["PartnerName"] = dt.Rows[intcnt]["ORGPARTNR_NAME"].ToString();
                drDtl["DocumentNo"] = dt.Rows[intcnt]["ORGPARTNR_DCMNT_NUM"].ToString();
                drDtl["CrNo"] = dt.Rows[intcnt]["ORGPARTNR_CRN_NUM"].ToString();
                drDtl["ContyNo"] = dt.Rows[intcnt]["CNTRY_ID"].ToString();
                drDtl["SharePer"] = dt.Rows[intcnt]["ORGPARTNR_PERCNT"].ToString();
                drDtl["Status"] = Convert.ToInt32(dt.Rows[intcnt]["ORGPARTNR_STATUS"].ToString());
                dtDetail.Rows.Add(drDtl);

            }
            string strJsonF = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenPartner.Value = strJsonF;
            //////////////////////////////////////////////////////////////////////////////////////////////////

            nation();
            FillCapctha();
        }
    }
    public void FillCapctha()
    {
        try
        {
            Random random = new Random();
            //txtCaptcha.Text = "";
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                captcha.Append(combination[random.Next(combination.Length)]);
            }
            Session["captcha"] = captcha.ToString();
            hiddenCaptcha.Value = Session["Captcha"].ToString();
            imgCaptcha.ImageUrl = "Gen_Orgnization_Capcha.aspx?" + DateTime.Now.Ticks.ToString();
        }
        catch
        {
            // throw;
        }
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

    public void OrgTypeLoad1(string orgcty)
    {
        int orgctyId = Convert.ToInt32(orgcty);
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();

        objEntityOrganization.OrgTypeId = orgctyId;
        DataTable dtOrgType = new DataTable();
        dtOrgType = objBusinessLayerOrganization.OrgType(objEntityOrganization);

        string str = dtOrgType.Rows[0]["ORGCTY_NAME"].ToString();
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

        //ddlOrgType.Items.Insert(0, str);
        if (orgcty != null)
        {
            ddlOrgType.Items.FindByValue(dtOrgType.Rows[0]["ORGCTY_ID"].ToString()).Selected = true;
        }
        else
        {
            OrgTypeLoad();
        }

    }



    //Method for binding Country type details to dropdown list.
    public void CountryLoad()
    {
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        //hiddenNation.Value = "";
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

    public void CountryLoad1(string cntry)
    {
        //Creating objects for businesslayer.
        //clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();
        DataTable dtContry = new DataTable();

        objEntityOrganization.CountryId = Convert.ToInt32(cntry);
        dtContry = objBusinessLayerOrganization.OrgContry(objEntityOrganization);
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
        if (cntry != null)
        {
            ddlOrgCountry.Items.FindByValue(dtContry.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
        }
    }
    [WebMethod]
    public static string[] changeCity(string strLikeEmployee, int orgID, int corptID, int stateID)
    {
        List<string> Employees = new List<string>();
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.StateId = Convert.ToInt32(stateID);
        objEntityCorp.Cancel_Reason = strLikeEmployee;
        DataTable dtEmployess = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<,>{1}", dtEmployess.Rows[intRowCount]["CITY_ID"].ToString(), dtEmployess.Rows[intRowCount]["CITY_NAME"].ToString()));
        }
        return Employees.ToArray();
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
    //Method for bind license pack details to dropdown list.
    public void LicensePackLoad()
    {
        hiddenNation.Value = "";
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

    public void LicensePackLoad1(string licId)
    {
        hiddenNation.Value = "";
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();

        int LicId = Convert.ToInt32(licId);
        objEntityOrganization.LicPacId = LicId;
        DataTable dtLicPack = new DataTable();
        dtLicPack = objBusinessLayerOrganization.OrgLicPack(objEntityOrganization);

        DataTable dtLicense = objBusinessLayerOrgParking.ReadLicensePack();
        ddlOrgLicPac.DataSource = dtLicense;
        for (int intDtCnt = 0; intDtCnt < dtLicense.Rows.Count; intDtCnt++)
        {

            ddlOrgLicPac.DataTextField = "LIC_PACK_NAME";
            ddlOrgLicPac.DataValueField = "LIC_PACK_ID";
            ddlOrgLicPac.DataBind();
        }
        //ddlOrgLicPac.Items.Insert(0, str);
        if (licId != null)
        {
            ddlOrgLicPac.Items.FindByValue(dtLicPack.Rows[0]["LIC_PACK_ID"].ToString()).Selected = true;
        }
        txtLicPacCount.InnerHtml ="Count<i class=\"fa fa-hashtag\"></i>: "+dtLicPack.Rows[0]["LIC_PACK_ENDS"].ToString();
        HiddenFieldLpack.Value = dtLicPack.Rows[0]["LIC_PACK_ENDS"].ToString();

    }

    //Method of bind corporate pack details to dropdown list.
    public void CorporatePackLoad()
    {
        hiddenNation.Value = "";
        //Creating objects for businesslayer.
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
    public void CorporatePackLoad1(string Corp_id)
    {
        hiddenNation.Value = "";
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();


        int CorpId = Convert.ToInt32(Corp_id);
        objEntityOrganization.CorPacId = CorpId;
        DataTable dtCorpId = new DataTable();
        dtCorpId = objBusinessLayerOrganization.OrgCorpPack(objEntityOrganization);

        DataTable dtCorporate = objBusinessLayerOrgParking.ReadCorporatePack();
        ddlOrgCorPac.DataSource = dtCorporate;
        for (int intDtCnt = 0; intDtCnt < dtCorporate.Rows.Count; intDtCnt++)
        {

            ddlOrgCorPac.DataTextField = "CORP_PACK_NAME";
            ddlOrgCorPac.DataValueField = "CORP_PACK_ID";
            ddlOrgCorPac.DataBind();
        }
        //ddlOrgCorPac.Items.Insert(0, str);
        if (Corp_id != null)
        {
            ddlOrgCorPac.Items.FindByValue(dtCorpId.Rows[0]["CORP_PACK_ID"].ToString()).Selected = true;
        }
        txtCorPacCount.InnerHtml = "Count<i class=\"fa fa-hashtag\"></i>: " + dtCorpId.Rows[0]["CORP_PACK_COUNT"].ToString();
        HiddenFieldCpack.Value = dtCorpId.Rows[0]["CORP_PACK_COUNT"].ToString();
    }


    //When a license pack is selected from license pack dropdown list then assign its maximum users details to a textbox.
    [WebMethod]
    public static string changeLiscencePack(string LicPacId)
    {
        string strRet = "";
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        if (LicPacId == "--Choose Your License Pack--")
        {
            strRet = "";
        }
        else
        {
            clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
            objEntityOrgParking.LicPacId = Convert.ToInt32(LicPacId);
            DataTable dtLicPacCount = objBusinessLayerOrgParking.ReadLicPacCount(objEntityOrgParking);
            strRet=dtLicPacCount.Rows[0]["LIC_PACK_ENDS"].ToString();  
        }
        return strRet;
    }

    //When a corporate pack is selected from corporate pack dropdown list then bind its office allowed details to a textbox.
    [WebMethod]
    public static string changeCorpPack(string CorpPacId)
    {
        string strRet = "";
        //Creating objects for businesslayer.
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        if (CorpPacId == "--Choose Your Corporate Pack--")
        {
            strRet = "";
        }
        else
        {
            clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
            objEntityOrgParking.CorPacId = Convert.ToInt32(CorpPacId);
            DataTable dtCorPacCount = objBusinessLayerOrgParking.ReadCorPacCount(objEntityOrgParking);
            strRet = dtCorPacCount.Rows[0]["CORP_PACK_COUNT"].ToString();        
        }
        return strRet;
    }

    //Method for fetch the server port and domain name.
    public string GetServerDetail()
    {
        string strDomainName = Request.ServerVariables["server_name"].ToString();
        string strPort = Request.ServerVariables["server_port"].ToString();
        string strHostAddr = strDomainName + ":" + strPort;
        return strHostAddr;

    }

    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    //Passing all details about registering organisation to business layer when save button clicked.
    //protected void btnOrgSave_Click(object sender, EventArgs e)
    //{   //Creating object for clsBusinessLayer Mail in in the BusinessLayer
    //    clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
    //    //Creating object for clsMail  in in the MailUtility Layer
    //    clsMail objMail = new clsMail();
    //    string strTransId = "";
    //    //Creating objects for businesslayer.
    //    clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();


    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
    //    //Method for fetching nextvalue for insertion.
    //    objEntityOrgParking.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.Corporate_Office);
    //    DataTable dtNextId = objBusinessLayerOrgParking.ReadNextId(objEntityOrgParking);
    //    objEntityOrgParking.NextValue = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);

    //    objEntityOrgParking.OrgTypeId = Convert.ToInt32(ddlOrgType.SelectedItem.Value);
    //    objEntityOrgParking.Organisation_Name = txtOrgName.Text.ToUpper().Trim();
    //    objEntityOrgParking.Address1 = txtOrgAdd1.Text.Trim();
    //    objEntityOrgParking.Address2 = txtOrgAdd2.Text.Trim();
    //    objEntityOrgParking.Address3 = txtOrgAdd3.Text.Trim();
    //    objEntityOrgParking.CountryId = Convert.ToInt32(ddlOrgCountry.SelectedItem.Value);
    //    //If there is no state selected
    //    if (ddlOrgState.SelectedItem.Text == "--Select Your State--")
    //    {
    //        objEntityOrgParking.StateId = null;
    //        objEntityOrgParking.CityId = null;
    //    }
    //    else
    //    {
    //        objEntityOrgParking.StateId = Convert.ToInt32(ddlOrgState.SelectedItem.Value);
    //        //If there is no city selected
    //        if (ddlOrgCity.SelectedItem.Text == "--Select Your City--")
    //        {
    //            objEntityOrgParking.CityId = null;
    //        }
    //        else
    //        {
    //            objEntityOrgParking.CityId = Convert.ToInt32(ddlOrgCity.SelectedItem.Value);

    //        }
    //    }
    //    objEntityOrgParking.ZipCode = txtOrgZip.Text.Trim();
    //    objEntityOrgParking.Mobile_Number = txtOrgMobile.Text.Trim();
    //    objEntityOrgParking.Phone_Number = txtOrgPhone.Text.Trim();
    //    objEntityOrgParking.Web_Address = txtOrgWebsite.Text.Trim();
    //    //objEntityOrgParking.Contact_Person = txtContactPerson.Text.Trim();

    //    objEntityOrgParking.Email_Address = txtOrgEmail.Text.Trim();
    //    // hashing the password
    //    string strPwd = txtOrgPwd.Text.Trim();
    //    clsHash objHashing = new clsHash();
    //    string strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));


    //    objEntityOrgParking.Password = strEncryptedPwd;
    //    objEntityOrgParking.LicPacId = Convert.ToInt32(ddlOrgLicPac.SelectedItem.Value);
    //    objEntityOrgParking.LicPacCount = Convert.ToInt32(txtLicPacCount.Text);
    //    objEntityOrgParking.CorPacId = Convert.ToInt32(ddlOrgCorPac.SelectedItem.Value);
    //    objEntityOrgParking.CorPacCount = Convert.ToInt32(txtCorPacCount.Text);
    //    objEntityOrgParking.OrgStatusId = Convert.ToInt32(clsCommonLibrary.Status.Status_New);
    //    objEntityOrgParking.OrganisationStatusDate = System.DateTime.Now;
    //    objEntityOrgParking.OrgInsertDate = System.DateTime.Now;
    //    objEntityOrgParking.IP_Address = objCommon.GetIp();
    //    objEntityOrgParking.Verification_Code = objCommon.Random_Number() + objEntityOrgParking.NextValue;
    //    objEntityOrgParking.Verification_Link = "http://" + GetServerDetail() + "/Master/gen_Org_Verification/gen_Org_Verification.aspx";
    //    //for password encryption
    //    clsCommonLibrary.Encrp_Pwd(objEntityOrgParking);

    //    //Checking database table have already this email or not.
    //    DataTable dtEmailCount = objBusinessLayerOrgParking.EmailCheck(objEntityOrgParking);
    //    string strEmailCount = dtEmailCount.Rows[0]["COUNT(ORG_PARK_ID)"].ToString();
    //    DataTable dtEmailCountUser = objBusinessLayerOrgParking.EmailCheckUser(objEntityOrgParking);
    //    string strEmailCountUser = dtEmailCountUser.Rows[0]["COUNT(USR_ID)"].ToString();
    //    //Parking table have no existed email like this.
    //    if (strEmailCount == "0")
    //    {
    //        //Users table have no existed email like this.
    //        if (strEmailCountUser == "0")
    //        {
    //            //Check wheather this organisation name already exist or not
    //            DataTable dtOrg = objBusinessLayerOrgParking.CheckOrgName(objEntityOrgParking);
    //            string strOrg = dtOrg.Rows[0]["COUNT(ORG_PARK_ID)"].ToString();
    //            if (strOrg == "0")
    //            {
    //                clsBusinessLayer objBusines = new clsBusinessLayer();
    //                DataTable dtConfigDtl = new DataTable();
    //                dtConfigDtl = objBusines.LoadConfigDetail();

    //                string strTemplateId = "";
    //                if (dtConfigDtl.Rows.Count > 0)
    //                {
    //                    strTemplateId = dtConfigDtl.Rows[0]["DFLT_ORG_EMTMPLT_ID"].ToString();
    //                }
    //                DataTable dtCompanyDetail = new DataTable();
    //                DataTable dtTemplateDetail = new DataTable();
    //                dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
    //                objMail.InstantMail(strTemplateId, ref dtTemplateDetail);

    //                // Saving to organization parking table and to Gn_Email_Store.
    //                strTransId = objEntityOrgParking.NextValue.ToString(); ;
    //                objBusinessLayerOrgParking.InsertOrgParking_Mail(objEntityOrgParking, strTemplateId, dtCompanyDetail, dtTemplateDetail);

    //                //for sending mail, avoid time delay we use threading
    //                // Thread threadMail = new Thread(() => Mail(objEntityOrgParking));
    //                //threadMail.Start();
    //                Mail(objEntityOrgParking, strTransId);



    //                if (hiddenlblOnCloudOrNot.Value != "")
    //                {
    //                    int intOnCloud = Convert.ToInt32(hiddenlblOnCloudOrNot.Value);

    //                    if (intOnCloud == Convert.ToInt16(clsCommonLibrary.Cloud.NotCloud))
    //                    {
    //                        string strAlertMsg = "<script>alert('Registration Successful, Please Select Verification Link Send to Your Registered E-Mail ID!');windows:location='../../Default.aspx'</script>";
    //                        ClientScript.RegisterStartupScript(this.GetType(), "alert", strAlertMsg);



    //                    }
    //                    else
    //                    {
    //                        string strAlertMsg = "<script>alert('Registration Successful, Please Select Verification Link Send to Your Registered E Mail ID!');windows:location='../../Default.aspx'</script>"; //Master/gen_Org_Parking/gen_Org_Parking_Reg.aspx
    //                        ClientScript.RegisterStartupScript(this.GetType(), "alert", strAlertMsg);

    //                    }


    //                }

    //            }
    //            else
    //            {
    //                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
    //                txtOrgName.Focus();
    //            }
    //        }
    //        else
    //        {

    //            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);

    //            txtOrgEmail.Focus();
    //        }
    //    }
    //    //If have
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
    //        txtOrgEmail.Focus();
    //    }
    //}
    ////Method for sending mail.
    //public void Mail(clsEntityOrgParking objEntityOrgParking, string strTransId)
    //{

    //    //Creating object for clsBusinessLayer Mail in in the BusinessLayer
    //    clsBusinessLayerMail objBusinessLayerMail = new clsBusinessLayerMail();
    //    //Creating object for clsMail  in in the MailUtility Layer
    //    clsMail objMail = new clsMail();

    //    clsBusinessLayer objBusines = new clsBusinessLayer();
    //    DataTable dtConfigDtl = new DataTable();
    //    dtConfigDtl = objBusines.LoadConfigDetail();

    //    string strTemplateId = "";
    //    if (dtConfigDtl.Rows.Count > 0)
    //    {

    //        strTemplateId = dtConfigDtl.Rows[0]["DFLT_ORG_EMTMPLT_ID"].ToString();
    //    }



    //    // EntityLayer.clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();

    //    DataTable dtCompanyDetail = new DataTable();
    //    //  DataTable dtTemplateDetail = new DataTable();
    //    dtCompanyDetail = objBusinessLayerMail.SelectCompanyDetails();
    //    // objMail.InstantMail("3", ref dtTemplateDetail);
    //    // save to registration table
    //    // save to message table
    //    // objBusinessLayerMail.InstantMailInsert("3", objEntityOrgParking.Email_Address,objEntityOrgParking.NextValue.ToString(), dtCompanyDetail, dtTemplateDetail);
    //    // on success send mail
    //    objMail.BulkMail(strTemplateId, strTransId, dtCompanyDetail, objEntityOrgParking);
    //    //   objMail.BulkMail();
    //}
    public class clsDELETEPartner
    {

        public string ROWID { get; set; }
        public string PARTNER { get; set; }
        public string DOCNUM { get; set; }
        public string CRNUM { get; set; }
        public int NATION { get; set; }
        public int SHAREPER { get; set; }
        public int STATUS { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }
    public class clsDELETEAttchmnt
    {
        public string FILENAME { get; set; }

        public string DTLID { get; set; }

    }
    public class clsAtchmntData
    {

        public string ROWID { get; set; }
        public string FILEPATH { get; set; }
        public string DESCRPTN { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }
    public class clsPartnerData
    {

        public string ROWID { get; set; }
        public string PARTNER { get; set; }
        public string DOCNUM { get; set; }
        public string CRNUM { get; set; }
        public string NATION { get; set; }
        public string SHAREPER { get; set; }
        public string STATUS { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }
    protected void btnAddUp_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityOrganization.UserId = intUserId;
        int pwdCount = 0;
        string strEncryptedPwdNew = "";
        if (txtOrgPwd.Text != null && txtOrgPwd.Text != "")
        {
            string strPwd = txtOrgPwd.Text.Trim();
            clsHash objHashing = new clsHash();
            string strEncryptedPwd = objHashing.GetHash(strPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));
            DataTable dtPswd = new DataTable();
            objEntityOrganization.OrgId = objEntityCommon.Organisation_Id;
            dtPswd = objBusinessLayerOrganization.ReadPasswrd(objEntityOrganization);

            if (dtPswd.Rows.Count > 0)
            {
                string Pswd = dtPswd.Rows[0]["USR_PWD"].ToString();
                if (strEncryptedPwd == Pswd)
                {
                    pwdCount = 0;
                }
                else
                {
                    pwdCount = 1;
                }

            }
            string strNewPwd = txtOrgNewPwd.Text.Trim();
            clsHash objHashingNew = new clsHash();
            strEncryptedPwdNew = objHashing.GetHash(strNewPwd, Convert.ToInt32(clsCommonLibrary.HashType.SHA256));
        }
        //string str = ddlOrgCountry.SelectedItem.Value;
        // int s= ddlOrgCountry.SelectedItem.Value;

        objEntityOrganization.CountryId = Convert.ToInt32(ddlOrgCountry.SelectedItem.Value);
        if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
        {
            objEntityOrganization.StateId = null;
            objEntityOrganization.CityId = null;
        }
        else
        {
            if (HiddenFieldState.Value != "--Select Your State--" && HiddenFieldState.Value != "")
            {
                objEntityOrganization.StateId = Convert.ToInt32(HiddenFieldState.Value);
            }
            else
                objEntityOrganization.StateId = null;
            //If there is no city selected
            if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
            {
                objEntityOrganization.CityId = null;
            }
            else
            {
                if (HiddenFieldCity.Value != "--Select Your City--" && HiddenFieldCity.Value != "")
                {
                    objEntityOrganization.CityId = Convert.ToInt32(HiddenFieldCity.Value);
                }
                else
                    objEntityOrganization.CityId = null;

            }
        }
        objEntityOrganization.LicPacId = Convert.ToInt32(ddlOrgLicPac.SelectedItem.Value);
        objEntityOrganization.LicPacCount = Convert.ToInt32(HiddenFieldLpack.Value);
        objEntityOrganization.CorPacId = Convert.ToInt32(ddlOrgCorPac.SelectedItem.Value);
        objEntityOrganization.CorPacCount = Convert.ToInt32(HiddenFieldCpack.Value);
        objEntityOrganization.OrgTypeId = Convert.ToInt32(ddlOrgType.SelectedItem.Value);
        objEntityOrganization.Organisation_Name = txtOrgName.Text.ToUpper().Trim();
        objEntityOrganization.Address1 = txtOrgAdd1.Text.Trim();
        objEntityOrganization.Address2 = txtOrgAdd2.Text.Trim();
        objEntityOrganization.Address3 = txtOrgAdd3.Text.Trim();
        objEntityOrganization.ZipCode = txtOrgZip.Text.Trim();
        objEntityOrganization.Phone_Number = txtOrgPhone.Text.Trim();
        objEntityOrganization.Mobile_Number = txtOrgMobile.Text.Trim();
        objEntityOrganization.Web_Address = txtOrgWebsite.Text.Trim();
        objEntityOrganization.Email_Address = txtOrgEmail.Text.Trim();
        objEntityOrganization.Password = strEncryptedPwdNew;
        objEntityOrganization.CRnumber = txtCrNumber.Text.Trim();
        objEntityOrganization.CrNumExpDate = objCommon.textToDateTime(txtExpCrDate.Value);
        objEntityOrganization.CrNumIssueDate = objCommon.textToDateTime(txtIssueCrDate.Value);
        objEntityOrganization.TxNumber = txtTiNumber.Text.Trim();
        objEntityOrganization.TxNumExpDate = objCommon.textToDateTime(txtExpTxDate.Value);
        objEntityOrganization.TxNumIssueDate = objCommon.textToDateTime(txtIssueTxDate.Value);
        objEntityOrganization.CompNumber = txtCompNo.Text;
        objEntityOrganization.CompNumExpDate = objCommon.textToDateTime(txtExpCompDate.Value);
        objEntityOrganization.CompNumIssueDate = objCommon.textToDateTime(txtIssueCompDate.Value);



        //if (dtOrgName.Rows.Count > 0)
        //{
        //    hiddenOrgName.Value = "1";
        //}
        //else
        //{
        //    hiddenOrgName.Value = null;
        //}

        if (HiddenField2_FileUpload.Value == "0")
        {
            HiddenField2_FileUpload.Value = "";
        }

        string jsonData = HiddenField2_FileUpload.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsAtchmntData> objDataList = new List<clsAtchmntData>();
        objDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsEntityAttachment> objEntityAttchmntDeatilsList = new List<clsEntityAttachment>();

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ORGANIZATION_UPDATE);
        //objEntityCommon.CorporateID = objEntityOrganization.Corporate_id;
        //objEntityCommon.Organisation_Id = objEntityOrganization.OrgId;
        int strId = objEntityCommon.Organisation_Id;
        objEntityOrganization.NextId = Convert.ToInt32(strId);

        if (HiddenField2_FileUpload.Value != "" && HiddenField2_FileUpload.Value != null)
        {
            for (int count = 0; count < objDataList.Count; count++)
            {
                string jsonFileid = objDataList[count].ROWID;
                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                {
                    clsEntityAttachment objEntityAttach = new clsEntityAttachment();
                    if (jsonFileid.Contains("comp"))
                    {
                        objEntityAttach.CardRol = 3;
                    }
                    else if (jsonFileid.Contains("cr"))
                    {
                        objEntityAttach.CardRol = 1;
                    }
                    else
                    {
                        objEntityAttach.CardRol = 2;
                    }
                    string fileId = Request.Files.AllKeys[intCount].ToString();
                    HttpPostedFile PostedFile = Request.Files[intCount];
                    if (fileId == jsonFileid)
                    {

                        if (PostedFile.ContentLength > 0)
                        {

                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntityAttach.ActualFileName = strFileName;
                            string strFileExt;

                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ORGANIZATION);
                            objEntityAttach.RnwlAttchmntSlNumber = count;
                            string strImageName = "ATTACH_" + intImageSection.ToString() + "_" + objEntityOrganization.NextId.ToString() + +count + "." + strFileExt;
                            objEntityAttach.FileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.ORGANIZATION);

                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityAttach.FileName);

                            if (objDataList[count].DESCRPTN != "--Description--")
                            {
                                objEntityAttach.Description = objDataList[count].DESCRPTN;
                            }
                            objEntityAttach.OrgId = objEntityOrganization.NextId;
                            objEntityAttchmntDeatilsList.Add(objEntityAttach);
                        }
                    }
                }
            }
        }
        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (HiddenDlet_FileUpload.Value != "" && HiddenDlet_FileUpload.Value != null)
        {
            strCanclDtlId = HiddenDlet_FileUpload.Value;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }
        List<clsEntityAttachment> objEntityPerDeleteAttchmntDeatilsList = new List<clsEntityAttachment>();

        if (HiddenDlet_FileUpload.Value != "" && HiddenDlet_FileUpload.Value != null)
        {
            string str = HiddenDlet_FileUpload.Value;
            string jsonData1 = HiddenDlet_FileUpload.Value;
            string c1 = jsonData1.Replace("\"{", "\\{");
            string d1 = c1.Replace("\\n", "\r\n");
            string g1 = d1.Replace("\\", "");
            string h1 = g1.Replace("}\"]", "}]");
            string i1 = h1.Replace("}\",", "},");
            List<clsAtchmntData> objDataList1 = new List<clsAtchmntData>();
            objDataList1 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i1);
            List<clsDELETEAttchmnt> objVhclDataDltAttList = new List<clsDELETEAttchmnt>();
            //   UserData  data
            objVhclDataDltAttList = JsonConvert.DeserializeObject<List<clsDELETEAttchmnt>>(i1);


            foreach (clsDELETEAttchmnt objClsVhclDltAttData in objVhclDataDltAttList)
            {

                clsEntityAttachment objEntityRnwlDetailsAttchmnt = new clsEntityAttachment();

                objEntityRnwlDetailsAttchmnt.RnwlId = Convert.ToInt32(objClsVhclDltAttData.DTLID);
                //objEntityRnwlDetailsAttchmnt.FileName = Convert.ToString(objClsVhclDltAttData.FILENAME);

                objEntityPerDeleteAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);


            }
            HiddenDlet_FileUpload.Value = "";
        }

        string str11 = hiddenCanclDtlId.Value;
        string strCanclPartnerId = "";
        string[] strPartCancldtlIds = strCanclPartnerId.Split(',');
        if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
        {
            strCanclPartnerId = hiddenCanclDtlId.Value;
            strPartCancldtlIds = strCanclPartnerId.Split(',');
            int count = strPartCancldtlIds.Length;
            for (int j = 0; j < count; j++)
            {
                clsAddPartner objPartnerDtls = new clsAddPartner();
                objPartnerDtls.RnwlId = Convert.ToInt32(strPartCancldtlIds[j]);
                objBusinessLayerOrganization.DeletPartner(objPartnerDtls);

            }
        }
        //List<AddPartner> objEntityPerDeletePartnerDeatilsList = new List<AddPartner>();
        //if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
        //{
        //    string str = hiddenCanclDtlId.Value;
        //    string jsonData1 = hiddenCanclDtlId.Value;
        //    string c1 = jsonData1.Replace("\"{", "\\{");
        //    string d1 = c1.Replace("\\n", "\r\n");
        //    string g1 = d1.Replace("\\", "");
        //    string h1 = g1.Replace("}\"]", "}]");
        //    string i1 = h1.Replace("}\",", "},");
        //    List<clsPartnerData> objDataList2 = new List<clsPartnerData>();
        //    objDataList2 = JsonConvert.DeserializeObject<List<clsPartnerData>>(i1);
        //    List<clsDELETEPartner> objVhclDataDltAttList = new List<clsDELETEPartner>();
        //    //   UserData  data
        //    objVhclDataDltAttList = JsonConvert.DeserializeObject<List<clsDELETEPartner>>(i1);

        //    foreach (clsDELETEPartner objPrtnerDlt in objVhclDataDltAttList)
        //    {

        //        AddPartner objPartnerDtls = new AddPartner();

        //        objPartnerDtls.RnwlId = Convert.ToInt32(objPrtnerDlt.DTLID);


        //        objEntityPerDeletePartnerDeatilsList.Add(objPartnerDtls);


        //    }
        //    hiddenDelt_Partner.Value = "";
        //}

        //objBusinessLayerOrganization.DeletPartner(objEntityPerDeletePartnerDeatilsList);


        //objBusinessLayerOrganization.DeletAttachment(objEntityPerDeleteAttchmntDeatilsList);
        //objBusinessLayerOrganization.AddOrgDetails(objEntityOrganization, objEntityAttchmntDeatilsList);
        string str1 = HiddenFieldAddTable.Value;
        //int intcount = 0;
        List<clsAddPartner> objEntityPartnerList = new List<clsAddPartner>();
        List<clsAddPartner> objEntityPartnerUpdateList = new List<clsAddPartner>();
        if (HiddenFieldAddTable.Value != "" && HiddenFieldAddTable.Value != null)
        {
            string str = HiddenFieldAddTable.Value;
            string jsonData2 = HiddenFieldAddTable.Value;
            string c2 = jsonData2.Replace("\"{", "\\{");
            string d2 = c2.Replace("\\n", "\r\n");
            string g2 = d2.Replace("\\", "");
            string h2 = g2.Replace("}\"]", "}]");
            string i2 = h2.Replace("}\",", "},");
            List<clsPartnerData> objDataList2 = new List<clsPartnerData>();
            objDataList2 = JsonConvert.DeserializeObject<List<clsPartnerData>>(i2);
            foreach (clsPartnerData objPart in objDataList2)
            {
                if (objPart.EVTACTION == "INS")
                {
                    clsAddPartner objAddPartner = new clsAddPartner();
                    if (objPart.NATION != "0" && objPart.CRNUM != "" && objPart.DOCNUM != "" && objPart.PARTNER != "" && objPart.STATUS != "" && objPart.SHAREPER != "")
                    {
                        objAddPartner.orgId = objEntityCommon.Organisation_Id;
                        objAddPartner.Contry = Convert.ToInt32(objPart.NATION);
                        objAddPartner.CrNo = objPart.CRNUM;
                        objAddPartner.DocNo = objPart.DOCNUM;
                        objAddPartner.PartnerName = objPart.PARTNER;
                        objAddPartner.Status = Convert.ToInt32(objPart.STATUS);
                        objAddPartner.Percent = Convert.ToDecimal(objPart.SHAREPER);
                        objEntityPartnerList.Add(objAddPartner);
                    }
                    else
                    {
                        //intcount++;
                        //ScriptManager.RegisterStartupScript(this, GetType(), "Duplicationtable", "Duplicationtable();", true);
                    }

                }
                else if (objPart.EVTACTION == "UPD")
                {
                    if (objPart.NATION != "0" && objPart.CRNUM != "" && objPart.DOCNUM != "" && objPart.PARTNER != "" && objPart.STATUS != "" && objPart.SHAREPER != "")
                    {
                        clsAddPartner objAddPartner = new clsAddPartner();
                        objAddPartner.orgId = objEntityCommon.Organisation_Id;
                        objAddPartner.Contry = Convert.ToInt32(objPart.NATION);
                        objAddPartner.CrNo = objPart.CRNUM;
                        objAddPartner.DocNo = objPart.DOCNUM;
                        objAddPartner.PartnerName = objPart.PARTNER;
                        objAddPartner.Status = Convert.ToInt32(objPart.STATUS);
                        objAddPartner.Percent = Convert.ToDecimal(objPart.SHAREPER);
                        objAddPartner.RnwlId = Convert.ToInt32(objPart.DTLID);
                        objEntityPartnerUpdateList.Add(objAddPartner);
                    }
                    else
                    {
                        //intcount++;

                    }
                }

            }
            HiddenFieldAddTable.Value = "";
        }
        //objBusinessLayerOrganization.UpdatePartner(objEntityPartnerUpdateList);
        //objBusinessLayerOrganization.AddPartner(objEntityPartnerList);
        
        string strNameCount = objBusinessLayerOrganization.ReadOrg(objEntityOrganization);
        string txCard = objBusinessLayerOrganization.ReadCard(objEntityOrganization);
        string crNumCard = objBusinessLayerOrganization.ReadCrCard(objEntityOrganization);
        string compCard = objBusinessLayerOrganization.ReadCompCard(objEntityOrganization);
        if (pwdCount == 0)
        {
            if (strNameCount == "0")
            {
                if (txCard == "0")
                {
                    if (crNumCard == "0")
                    {
                        if (compCard == "0")
                        {
                            if (clickedButton.ID == "btnAddUp" || clickedButton.ID == "btnAdd")
                            {

                                objBusinessLayerOrganization.UpdatePartner(objEntityPartnerUpdateList);
                                objBusinessLayerOrganization.AddPartner(objEntityPartnerList);
                                objBusinessLayerOrganization.DeletAttachment(objEntityPerDeleteAttchmntDeatilsList);
                                //if (txtOrgNewPwd.Text != "" && txtOrgNewPwd.Text != null)
                                //{
                                objBusinessLayerOrganization.AddOrgDetails(objEntityOrganization, objEntityAttchmntDeatilsList);
                                //}
                                //else
                                //{

                                //}
                                Response.Redirect("Gen_Orgnization.aspx?InsUpd=Upd");
                            }
                            else
                            {
                                Response.Redirect("Gen_Orgnization.aspx");
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationComp", "DuplicationComp();", true);
                            txtCompNo.Focus();
                            nation();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCr", "DuplicationCr();", true);
                        txtCrNumber.Focus();
                        nation();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationTx", "DuplicationTx();", true);
                    txtTiNumber.Focus();
                    nation();
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtOrgName.Focus();
                nation();
            }
        }
        else
        {
            //intcount++;
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationPwd", "DuplicationPwd();", true);
            nation();
        }
        //intcount = 0;
    }

    public void Corporate()
    {
        string tableName = "dtTableCorp";
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        DataTable dtCorporate = objBusinessLayerOrgParking.ReadCorporatePack();

        DataView dvLic = new DataView(dtCorporate);
        dvLic.Sort = "CORP_PACK_NAME";

        dtCorporate.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCorporate.WriteXml(sw);
            result = sw.ToString();
        }

        hiddenCorp.Value = result;

    }
    public void License()
    {
        string tableName = "dtTableLic";
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();


        DataTable dtLicense = objBusinessLayerOrgParking.ReadLicensePack();
        DataView dvLic = new DataView(dtLicense);
        dvLic.Sort = "LIC_PACK_NAME";

        dtLicense.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtLicense.WriteXml(sw);
            result = sw.ToString();
        }

        hiddenLic.Value = result;

    }

    public void nation()
    {
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        string tableName = "dtTableNation";
        DataTable dtCountry = objBusinessLayerOrgParking.ReadCountry();
        DataView dvCountry = new DataView(dtCountry);
        dvCountry.Sort = "CNTRY_NAME";
        dtCountry.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountry.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenNation.Value = result;

    }

    [WebMethod]
    public static string DropdownContryBind(string tableName)
    {
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();


        DataTable dtCountry = objBusinessLayerOrgParking.ReadCountry();
        DataView dvCountry = new DataView(dtCountry);
        dvCountry.Sort = "CNTRY_NAME";

        dtCountry.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCountry.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string DropdownCorpBind(string tableName)
    {
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();

        DataTable dtCorporate = objBusinessLayerOrgParking.ReadCorporatePack();

        DataView dvLic = new DataView(dtCorporate);
        dvLic.Sort = "CORP_PACK_NAME";

        dtCorporate.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCorporate.WriteXml(sw);
            result = sw.ToString();
        }

        return result;


    }
    [WebMethod]
    public static string DropdownLicBind(string tableName)
    {
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();


        DataTable dtLicense = objBusinessLayerOrgParking.ReadLicensePack();
        DataView dvLic = new DataView(dtLicense);
        dvLic.Sort = "LIC_PACK_NAME";

        dtLicense.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtLicense.WriteXml(sw);
            result = sw.ToString();
        }

        return result;


    }
    [WebMethod]
    public static string LicPackChange(string tableName, string LicPackId)
    {
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
        objEntityOrgParking.LicPacId = Convert.ToInt32(LicPackId);
        DataTable dtLicPacCount = objBusinessLayerOrgParking.ReadLicPacCount(objEntityOrgParking);
        dtLicPacCount.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtLicPacCount.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string CorpPackChange(string tableName, string CorpPackId)
    {
        clsBusinessLayerOrgParking objBusinessLayerOrgParking = new clsBusinessLayerOrgParking();
        clsEntityOrgParking objEntityOrgParking = new clsEntityOrgParking();
        objEntityOrgParking.CorPacId = Convert.ToInt32(CorpPackId);
        DataTable dtCorPacCount = objBusinessLayerOrgParking.ReadCorPacCount(objEntityOrgParking);

        dtCorPacCount.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCorPacCount.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string countryChange(string tableName, string countryId)
    {
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();
        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        //clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        //clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityOrganization.CountryId = Convert.ToInt32(countryId);
        DataTable dtState = objBusinessLayerOrganization.ReadState(objEntityOrganization);
        dtState.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtState.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string stateChange(string tableName, string stateId)
    {
        clsEntityOrganization objEntityOrganization = new clsEntityOrganization();
        clsBusinessLayerOrganization objBusinessLayerOrganization = new clsBusinessLayerOrganization();
        //clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        //clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityOrganization.StateId = Convert.ToInt32(stateId);
        DataTable dtCity = objBusinessLayerOrganization.ReadCity(objEntityOrganization);
        dtCity.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCity.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    protected void btnClearUp_Click(object sender, EventArgs e)
    {
        Response.Redirect("Gen_Orgnization.aspx");
    }
}
