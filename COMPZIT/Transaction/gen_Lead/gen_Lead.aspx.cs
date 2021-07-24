using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Services;
using MailUtility_ERP;
using System.Threading;
using System.Text.RegularExpressions;


public partial class MasterPage_Default : System.Web.UI.Page
{
    clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();
   // int intCorpId;
   // int intOrgId;
   // int intUserId;
  //  int intFincyrId;
   // int intWorkAreaId;
    DataTable dtMedia = new DataTable();
 
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlLeadSource.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlLeadRate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlTeam.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounter()");

     
        

        txtCustName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCustName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //txtDescription.Attributes.Add("onkeypress", "return isTagForMltline(event)");
        //txtDescription.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtComments.Attributes.Add("onkeypress", "return isTagForMltline(event)");
        txtComments.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTitle.Attributes.Add("onkeypress", "return isTag(event)");
        txtTitle.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtProject.Attributes.Add("onkeypress", "return isTag(event)");
        txtProject.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtConsultant.Attributes.Add("onkeypress", "return isTag(event)");
        txtConsultant.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtContractor.Attributes.Add("onkeypress", "return isTag(event)");
        txtContractor.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtClient.Attributes.Add("onkeypress", "return isTag(event)");
        txtClient.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtAddress1.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddress1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddress2.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddress2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddress3.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddress3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtZipCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtZipCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");

       // txtTinNumber.Attributes.Add("onkeypress", "return isTag(event)");
       // txtTinNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtWebSite.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebSite.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtNameOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtNameOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNameTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtNameTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNameThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtNameThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtAddressOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddressOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddressTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddressTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddressThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddressThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtPhoneOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhoneOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhoneTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhoneTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhoneThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhoneThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtEmailOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmailOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmailTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmailTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmailThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmailThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtWebsiteOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebsiteOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtWebsiteTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebsiteTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtWebsiteThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebsiteThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlExistingCustomer.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingProject.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingContractor.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingClient.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingConsultant.Attributes.Add("onkeypress", "return DisableEnter(event)");

        cbxExistingCustomer.Attributes.Add("onkeypress", "return DisableEnter(event)");
       
        cbxExistingProject.Attributes.Add("onkeypress", "return DisableEnter(event)");
       
        cbxExistingClient.Attributes.Add("onkeypress", "return DisableEnter(event)");
     
        cbxExistingContractor.Attributes.Add("onkeypress", "return DisableEnter(event)");
       
        cbxExistingConsultant.Attributes.Add("onkeypress", "return DisableEnter(event)");
      



        if (!IsPostBack)
        {
            CKEditorDescription.config.toolbar = new object[] { };
            CKEditorDescription.config.resize_enabled = false;
            CKEditorDescription.config.removePlugins = "liststyle,tabletools,scayt,menubutton,contextmenu,elementspath";
            CKEditorDescription.config.height = "300";
            CKEditorDescription.config.uiColor = "#0680bd";


            if (Request.QueryString["L_MODE"] != null)
            {
                string strL_MODE = Request.QueryString["L_MODE"].ToString();
                ListLink.HRef="/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + strL_MODE;
            }
            else
            {
                ListLink.HRef="/Transaction/gen_Lead/gen_LeadList.aspx";
            }




            if (Request.QueryString["L_MODE"] != null)
            {
                string strL_MODE = Request.QueryString["L_MODE"].ToString();             
                hiddenL_MODE.Value = strL_MODE;
            }
            else
            {
                hiddenL_MODE.Value = "";
            }
           
            ddlNamePrefix.Visible = false;
            int intCorpId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                hiddenUserId.Value = Session["USERID"].ToString();
                intUserId =Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            if (Session["CORPOFFICEID"] != null)
            {
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                hiddenOrganisationId.Value = Session["ORGID"].ToString();

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("../../Default.aspx");
            }

            if (Session["FINCYRID"] != null)
            {
                hiddenFinacialYearId.Value = Session["FINCYRID"].ToString();
            }
            else if (Session["FINCYRID"] != null)
            {
                Response.Redirect("../../Default.aspx");
            }



            //for child role checking for adding  new project
            //Allocating child roles
            btnNewProject.Visible = false;
            btnNewCust.Visible = false;
            btnNewCustddl.Visible = false;
            btnNewProjectH.Visible = false;
            btnNewCustH.Visible = false;
            btnNewCustddlH.Visible = false;
            int intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
             int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project);
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
                          btnNewProject.Visible = true;
                          btnNewProjectH.Visible = true;
                      }

                  }

              }

            // for checking if to show new customer add button or not
             int intUsrRolMstrIdCustMstr = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Customer_Master);
             DataTable dtChildRolCustMstr = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCustMstr);
              if (dtChildRolCustMstr.Rows.Count > 0)
              {
                  string strChildRolDeftn = dtChildRolCustMstr.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                  string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                  foreach (string strC_Role in strChildDefArrWords)
                  {
                      if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                      {
                       
                          btnNewCust.Visible = true;
                          btnNewCustddl.Visible = true;
                          btnNewCustH.Visible = true;
                          btnNewCustddlH.Visible = true;
                      }

                  }

              }
            
            clsCommonLibrary objCommon = new clsCommonLibrary();
       


           
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED
                                                              };
            clsCommonLibrary.CORP_SUB_GLOBAL[] arr_Sub_Enumer = {  clsCommonLibrary.CORP_SUB_GLOBAL.LD_PRJCT_SELECTN_MUST,
                                                               clsCommonLibrary.CORP_SUB_GLOBAL.LD_EMAIL_MUST,
                                                                 clsCommonLibrary.CORP_SUB_GLOBAL.AUTOMTC_MOBL_CODE,
                                                              };
            DataTable dtCorpDetail = new DataTable();
            DataTable dtSubCorpDetail = new DataTable();

            DateTime dCurrent = System.DateTime.Now;
            txtDate.Text = objCommon.ConvertDateTimeToStringWithoutTime(dCurrent);

          

            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            dtSubCorpDetail = objBusinessLayer.Load_Sub_GlobalDetail(arr_Sub_Enumer, intCorpId);
            //if (dtCorpDetail.Rows.Count > 0)
            //{
            //    if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"] != DBNull.Value)
            //    {
            //        //value 1 means commodity maintained corporate 
            //        if (Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"]) == 1)
            //        {
            //            ScriptManager.RegisterStartupScript(this, GetType(), "VisibleTinNumber", "VisibleTinNumber();", true);
            //        }
            //    }
            //}
            if (dtSubCorpDetail.Rows.Count > 0)
            {
                hiddenProjectMust.Value = dtSubCorpDetail.Rows[0]["LD_PRJCT_SELECTN_MUST"].ToString().Trim();
                hiddenEmailMust.Value = dtSubCorpDetail.Rows[0]["LD_EMAIL_MUST"].ToString().Trim();
                if (hiddenProjectMust.Value == "1")
                {
                    h3Project.InnerHtml = "*";
                }
                if (hiddenEmailMust.Value == "1")
                {
                    h3Email.InnerHtml = "*&nbsp;";
                }

                if (dtSubCorpDetail.Rows[0]["AUTOMTC_MOBL_CODE"].ToString().Trim() != "")
                {
                    string strHindMobileNum = dtSubCorpDetail.Rows[0]["AUTOMTC_MOBL_CODE"].ToString().Trim();
                    txtMobile.Attributes.Add("placeholder", strHindMobileNum);
                    txtMobileOne.Attributes.Add("placeholder", strHindMobileNum);
                    txtMobileTwo.Attributes.Add("placeholder", strHindMobileNum);
                    txtMobileThree.Attributes.Add("placeholder", strHindMobileNum);
                }
            }
            ddlLeadSource.Focus();
            this.Form.Enctype = "multipart/form-data";
            //Dropdown loads
            DivisionLoad();
            ExistingCustomerLoad();
            ExistingProjectLoad();
            ExistingClientLoad();
            ExistingContractorLoad();
            ExistingConsultantLoad();
            //LeadSourceLoad();
           // NamePrefixLoad();
            Mail_Set();
            LeadRatingLoad();
            TeamLoad();
            CountryLoad();

            dtMedia = objBusinessLead.Read_Media_Master();
            if (dtMedia.Rows.Count == 0)
            {
            }
            else
            {
                string strMediaHtml = "";
                int intRowIdentity = 0;
                //automatically generate media controls based on media master
                for (int intRow = 0; intRow < dtMedia.Rows.Count; intRow++)
                {
                    string strTextboxName = dtMedia.Rows[intRow]["MEDIA_ID"].ToString();
                    if (intRowIdentity == 0)
                        strMediaHtml = strMediaHtml + " <tr id=\"div7\">";
                    else
                        strMediaHtml = strMediaHtml + " <tr id=\"div7\">";
                    strMediaHtml = strMediaHtml + "<td class=\"col-md-4 tr_l\"> " + dtMedia.Rows[intRow]["MEDIA_NAME"] + " </td>";
                    if (intRowIdentity == 0)
                        strMediaHtml = strMediaHtml + "<td class=\"col-md-8 tr_l\"><input type=text ID=" + strTextboxName + " placeholder=\""+dtMedia.Rows[intRow]["MEDIA_NAME"]+" Id\"  class=\"form-control fg2_inp2 tr_l\" onblur=\"return AssignMediaValues(this)\" runat=\"server\" MaxLength=\"150\" ></td>";
                    else
                        strMediaHtml = strMediaHtml + "<td class=\"col-md-8 tr_l\"><input type=text ID=" + strTextboxName + " placeholder=\"" + dtMedia.Rows[intRow]["MEDIA_NAME"] + " Id\" class=\"form-control fg2_inp2 tr_l\" onblur=\"return AssignMediaValues(this)\" runat=\"server\" MaxLength=\"150\" ></td>";
                    strMediaHtml = strMediaHtml + "</tr>";

                    if (intRowIdentity == 0)
                        intRowIdentity = 1;
                    else
                        intRowIdentity = 0;
                }

                divMedia.InnerHtml = strMediaHtml;
            }

          

            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId);
                lblEntry.InnerText = "Edit Opportunity";
                lblEntryB.InnerText = "Edit Opportunity";
                btnClear.Visible = false;
                btnClearF.Visible = false;
                if (Request.QueryString["Dup"] != null)
                {

                    string strDuplication = Request.QueryString["Dup"].ToString();
                    if (strDuplication == "Cstmr")
                    {
                        txtCustName.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCustomer", "DuplicationCustomer();", true);
                       
                    }
                    else if (strDuplication == "Prjct")
                    {
                        txtProject.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationProject", "DuplicationProject();", true);
                       
                    }
                    else if (strDuplication == "Client")
                    {
                        txtClient.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationClient", "DuplicationClient();", true);
                       
                    }
                    else if (strDuplication == "Cntrctr")
                    {
                        txtContractor.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationContractor", "DuplicationContractor();", true);
                        
                    }
                    else if (strDuplication == "Cnsultnt")
                    {
                        txtConsultant.Focus();
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationConsultant", "DuplicationConsultant();", true);
                     
                    }
                }
            }
            else
            {


                lblEntry.InnerText = "New Opportunity";
                lblEntryB.InnerText = "New Opportunity";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false; 
                CheckIfTeam();

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
            // created object for business layer for compare the date
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;

        }
    }

    //create media master details through web service
    [WebMethod]
    public static string CreateMedia()
    {
        clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();
        DataTable dtMedia = objBusinessLead.Read_Media_Master();
        string strMediaHtml = "";
        if (dtMedia.Rows.Count == 0)
        {
        }
        else
        {
           
            int intRowIdentity = 0;
            //automatically generate media controls based on media master
            for (int intRow = 0; intRow < dtMedia.Rows.Count; intRow++)
            {
                string strTextboxName = dtMedia.Rows[intRow]["MEDIA_ID"].ToString();
                if (intRowIdentity == 0)
                    strMediaHtml = strMediaHtml + " <tr id=\"div7\">";
                else
                    strMediaHtml = strMediaHtml + " <div id=\"div7\">";
                strMediaHtml = strMediaHtml + "  <td class=\"col-md-4 tr_l\"> " + dtMedia.Rows[intRow]["MEDIA_NAME"] + " </td>";
                if (intRowIdentity == 0)
                    strMediaHtml = strMediaHtml + " <td class=\"col-md-8 tr_l\"><input type=text ID=" + strTextboxName + " placeholder=\""+dtMedia.Rows[intRow]["MEDIA_NAME"]+" Id\" class=\"form-control fg2_inp2 tr_l\" onblur=\"return AssignMediaValues(this)\" runat=\"server\" MaxLength=\"150\" ></td>";
                else
                    strMediaHtml = strMediaHtml + " <td class=\"col-md-8 tr_l\"><input type=text ID=" + strTextboxName + " placeholder=\"" + dtMedia.Rows[intRow]["MEDIA_NAME"] + " Id\" class=\"form-control fg2_inp2 tr_l\" onblur=\"return AssignMediaValues(this)\" runat=\"server\" MaxLength=\"150\" ></td>";
                strMediaHtml = strMediaHtml + "</tr>";

                if (intRowIdentity == 0)
                    intRowIdentity = 1;
                else
                    intRowIdentity = 0;
            }

        }
        return strMediaHtml;
    }


    //Method for binding Lead Source to dropdown list.
    public void LeadSourceLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        DataTable dtSourceLead = objBusinessLead.ReadLeadSource(objEntityLead);

        ddlLeadSource.DataSource = dtSourceLead;
        ddlLeadSource.DataTextField = "LDSRCE_NAME";
        ddlLeadSource.DataValueField = "LDSRCE_ID";
        ddlLeadSource.DataBind();
        ddlLeadSource.Items.Insert(0, "--SELECT SOURCE--");
    }

    public void NamePrefixLoad()
    {
        //clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        //DataTable dtNamePrefix = objBusinessLead.ReadNamePrefix(objEntityLead);

        //ddlNamePrefix.DataSource = dtNamePrefix;
        //ddlNamePrefix.DataTextField = "NAMEPRFX_NAME";
        //ddlNamePrefix.DataValueField = "NAMEPRFX_ID";
        //ddlNamePrefix.DataBind();
    }

    ////Method for binding Country type details to dropdown list.
    public void CountryLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        DataTable dtCountry = objBusinessLead.ReadCountry();

        ddlCountry.DataSource = dtCountry;
        ddlCountry.DataTextField = "CNTRY_NAME";
        ddlCountry.DataValueField = "CNTRY_ID";
        ddlCountry.DataBind();
        ddlCountry.Items.Insert(0, "--SELECT YOUR COUNTRY--");
    }

    [WebMethod]
    public static List<string[]> ReadCountry()
    {
        clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        DataTable dtCountry = objBusinessLead.ReadCountry();

        List<string[]> CountryArrayList = new List<string[]>();
        if (dtCountry.Rows.Count != 0)
        {
            for (int intRowCount = 0; intRowCount < dtCountry.Rows.Count; intRowCount++)
            {
                string[] strStateArray = new string[2];
                strStateArray[0] = dtCountry.Rows[intRowCount]["CNTRY_ID"].ToString();
                strStateArray[1] = dtCountry.Rows[intRowCount]["CNTRY_NAME"].ToString();
                CountryArrayList.Add(strStateArray);
            }
        }
        return CountryArrayList;
    }

    //public void StateLoad()
    //{
    //    if (ddlCountry.SelectedItem.Text == "--SELECT YOUR COUNTRY--")
    //    {
    //        ddlState.Items.Clear();
    //        ddlCity.Items.Clear();
    //    }
    //    else
    //    {
    //        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
    //        objEntityLead.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
    //        DataTable dtState = objBusinessLead.ReadState(objEntityLead);

    //        List<string[]> StateArrayList=new List<string[]>();

    //        for (int intRowCount = 0; intRowCount < dtState.Rows.Count; intRowCount++)
    //        {
    //            string[] strStateArray = new string[2];
    //            strStateArray[0] = dtState.Rows[intRowCount]["STATE_ID"].ToString();
    //            strStateArray[1] = dtState.Rows[intRowCount]["STATE_NAME"].ToString();
    //            StateArrayList.Add(strStateArray);
    //        }

    //        ddlState.DataSource = dtState;
    //        ddlCity.Items.Clear();
    //        //if selected country have no states
    //        if (dtState.Rows.Count == 0)
    //        {
    //            ddlState.Items.Clear();
    //            ddlState.Items.Insert(0, "--SELECT YOUR STATE--");
    //        }
    //        else
    //        {
    //            ddlState.DataTextField = "STATE_NAME";
    //            ddlState.DataValueField = "STATE_ID";
    //            ddlState.DataBind();
    //            ddlState.Items.Insert(0, "--SELECT YOUR STATE--");
    //            ddlCountry.Focus();
    //        }
    //    }
    //}

    [WebMethod]
    public static List<string[]> ReadState(string intCountryId)
    {
        clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        objEntityLead.CountryId = Convert.ToInt32(intCountryId);
        DataTable dtState = objBusinessLead.ReadState(objEntityLead);

        List<string[]> StateArrayList = new List<string[]>();
        if (dtState.Rows.Count != 0)
        {
            for (int intRowCount = 0; intRowCount < dtState.Rows.Count; intRowCount++)
            {
                string[] strStateArray = new string[2];
                strStateArray[0] = dtState.Rows[intRowCount]["STATE_ID"].ToString();
                strStateArray[1] = dtState.Rows[intRowCount]["STATE_NAME"].ToString();
                StateArrayList.Add(strStateArray);
            }

        }
        return StateArrayList;
    }


    [WebMethod]
    public static List<string[]> ReadCity(string intStateId)
    {
        clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        objEntityLead.StateId = Convert.ToInt32(intStateId);
        DataTable dtCity = objBusinessLead.ReadCity(objEntityLead);

        List<string[]> StateArrayList = new List<string[]>();
        if (dtCity.Rows.Count != 0)
        {
            for (int intRowCount = 0; intRowCount < dtCity.Rows.Count; intRowCount++)
            {
                string[] strStateArray = new string[2];
                strStateArray[0] = dtCity.Rows[intRowCount]["CITY_ID"].ToString();
                strStateArray[1] = dtCity.Rows[intRowCount]["CITY_NAME"].ToString();
                StateArrayList.Add(strStateArray);
            }

        }
        return StateArrayList;
    }

    //public void CityLoad()
    //{
    //    if (ddlState.SelectedItem.Text == "--SELECT YOUR STATE--")
    //    {
    //        ddlCity.Items.Clear();
    //    }
    //    else
    //    {
    //        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
    //        objEntityLead.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
    //        DataTable dtCity = objBusinessLead.ReadCity(objEntityLead);
    //        ddlCity.DataSource = dtCity;
    //        //if selected states have no city
    //        if (dtCity.Rows.Count == 0)
    //        {
    //            ddlCity.Items.Clear();
    //            ddlCity.Items.Insert(0, "--SELECT YOUR CITY--");
    //        }
    //        else
    //        {
    //            ddlCity.DataTextField = "CITY_NAME";
    //            ddlCity.DataValueField = "CITY_ID";
    //            ddlCity.DataBind();
    //            ddlCity.Items.Insert(0, "--SELECT YOUR CITY--");
    //            ddlState.Focus();
    //        }
    //    }
    //}

    ////When select a country from country dropdown list then bind state details of selected country to state dropdownlist.
    //protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    StateLoad();
    //}

    ////When select a state from state dropdown list then bind city details of selected state to city dropdownlist.
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    CityLoad();
    //}

    //Method for binding Lead Rating details to dropdown list.
    public void LeadRatingLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        DataTable dtLeadRating = objBusinessLead.ReadLeadRating(objEntityLead);

        ddlLeadRate.DataSource = dtLeadRating;
        ddlLeadRate.DataTextField = "LDRATE_NAME";
        ddlLeadRate.DataValueField = "LDRATE_ID";
        ddlLeadRate.DataBind();
        ddlLeadRate.Items.Insert(0, "--SELECT OPPORTUNITY RATING--");
    }

    //Method for binding Team details to dropdown list.
    public void TeamLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        if (hiddenUserId.Value == "")
        {
            if (Session["USERID"] != null)
            {
                objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.User_Id = Convert.ToInt32(hiddenUserId.Value);
        }
        DataTable dtTeam = objBusinessLead.ReadTeamSelect(objEntityLead);
         if (dtTeam.Rows.Count == 1)
        {
            ddlTeam.DataSource = dtTeam;
            ddlTeam.DataTextField = "TEAM_NAME";
            ddlTeam.DataValueField = "TEAM_ID";
            ddlTeam.DataBind();
        }
        else
        {
            ddlTeam.DataSource = dtTeam;
            ddlTeam.DataTextField = "TEAM_NAME";
            ddlTeam.DataValueField = "TEAM_ID";
            ddlTeam.DataBind();
            ddlTeam.Items.Insert(0, "--SELECT YOUR TEAM--");
        }

    }

    //Method for binding Team details to dropdown list.
    public void CheckIfTeam()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        if (hiddenUserId.Value == "")
        {
            if (Session["USERID"] != null)
            {
                objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.User_Id = Convert.ToInt32(hiddenUserId.Value);
        }
        DataTable dtTeam = objBusinessLead.ReadTeamSelect(objEntityLead);
        if (dtTeam.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "NoTeam", "NoTeam();", true);
            // Response.Write("<script>alert('hi')</script>");
        }

    }
    //Method for binding Existing Customer details to dropdown list.
    public void ExistingCustomerLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
       
        DataTable dtExistingCustomer= objBusinessLead.ReadExistingCustomers(objEntityLead);

        ddlExistingCustomer.DataSource = dtExistingCustomer;
        ddlExistingCustomer.DataTextField = "CSTMR_NAME";
        ddlExistingCustomer.DataValueField = "CSTMR_ID";
        ddlExistingCustomer.DataBind();
        ddlExistingCustomer.Items.Insert(0, "--SELECT CUSTOMER/COMPANY--");

    }

    //Method for binding Existing project details to dropdown list.
    public void ExistingProjectLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        if (hiddenUserId.Value == "")
        {
            if (Session["USERID"] != null)
            {
                objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.User_Id = Convert.ToInt32(hiddenUserId.Value);
        }
        DataTable dtExistingProject = objBusinessLead.ReadExistingProjects(objEntityLead);

        ddlExistingProject.DataSource = dtExistingProject;
        ddlExistingProject.DataTextField = "PROJECT_NAME";
        ddlExistingProject.DataValueField = "PROJECT_ID";
        ddlExistingProject.DataBind();
        ddlExistingProject.Items.Insert(0, "--SELECT PROJECT--");

    }

    //Method for binding Existing CLIENT details to dropdown list.
    public void ExistingClientLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }

        DataTable dtExistingClient = objBusinessLead.ReadExistingClients(objEntityLead);

        ddlExistingClient.DataSource = dtExistingClient;
        ddlExistingClient.DataTextField = "CSTMR_NAME";
        ddlExistingClient.DataValueField = "CSTMR_ID";
        ddlExistingClient.DataBind();
        ddlExistingClient.Items.Insert(0, "--SELECT CLIENT--");

    }

    //Method for binding Existing CONTRACTOR details to dropdown list.
    public void ExistingContractorLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }

        DataTable dtExistingContractor = objBusinessLead.ReadExistingContractors(objEntityLead);

        ddlExistingContractor.DataSource = dtExistingContractor;
        ddlExistingContractor.DataTextField = "CSTMR_NAME";
        ddlExistingContractor.DataValueField = "CSTMR_ID";
        ddlExistingContractor.DataBind();
        ddlExistingContractor.Items.Insert(0, "--SELECT CONTRACTOR--");

    }

    //Method for binding Existing CONSULTANT details to dropdown list.
    public void ExistingConsultantLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }

        DataTable dtExistingConsultant = objBusinessLead.ReadExistingConsultants(objEntityLead);

        ddlExistingConsultant.DataSource = dtExistingConsultant;
        ddlExistingConsultant.DataTextField = "CSTMR_NAME";
        ddlExistingConsultant.DataValueField = "CSTMR_ID";
        ddlExistingConsultant.DataBind();
        ddlExistingConsultant.Items.Insert(0, "--SELECT CONSULTANT--");

    }
    //Method for binding Corporate division to dropdown list.
    public void DivisionLoad()
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        if (hiddenUserId.Value == "")
        {
            if (Session["USERID"] != null)
            {
                objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityLead.User_Id = Convert.ToInt32(hiddenUserId.Value);
        }
        DataTable dtDivision = objBusinessLead.ReadCorpDivision(objEntityLead);
        if (dtDivision.Rows.Count == 1)
        {
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CORP_ID_CODE";
            ddlDivision.DataBind();
        }
        else
        {
            ddlDivision.DataSource = dtDivision;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CORP_ID_CODE";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, "--SELECT YOUR DIVISION--");
        }
        //ddlDivision.Items.Insert(1, "216251");
    }


    public void Update(string strId)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        btnSave.Visible = false;
        btnSaveClose.Visible = false;
        btnSaveF.Visible = false;
        btnSaveCloseF.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        objEntityLead.LeadId = Convert.ToInt32(strId);
        DataTable dtCustomer = objBusinessLead.Read_Lead_ById(objEntityLead);
        DataTable dtContact = objBusinessLead.Read_Contact_ById(objEntityLead);
        DataTable dtMedia = objBusinessLead.Read_Media_ById(objEntityLead);
        DataTable dtMediaMaster = objBusinessLead.Read_Media_Master();
        DataTable dtLeadAttchmnt = new DataTable();
        dtLeadAttchmnt = objBusinessLead.ReadLeadAttchmnt(objEntityLead);

        if (dtCustomer.Rows.Count > 0)
        {
            if (dtCustomer.Rows[0]["LDSRCE_STATUS"].ToString() == "1")
            {
                ddlLeadSource.Items.FindByText(dtCustomer.Rows[0]["LDSRCE_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstLeadSource = new ListItem(dtCustomer.Rows[0]["LDSRCE_NAME"].ToString(), dtCustomer.Rows[0]["LDSRCE_ID"].ToString());
                ddlLeadSource.Items.Insert(1, lstLeadSource);
                //SortDDL(ref this.ddlLeadSource);
                ddlLeadSource.Items.FindByText(dtCustomer.Rows[0]["LDSRCE_NAME"].ToString()).Selected = true;
            }


            if (dtCustomer.Rows[0]["CPRDIV_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CPRDIV_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlDivision.Items.FindByText(dtCustomer.Rows[0]["CPRDIV_NAME"].ToString()) != null)
                    ddlDivision.Items.FindByText(dtCustomer.Rows[0]["CPRDIV_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstCorpDiv = new ListItem(dtCustomer.Rows[0]["CPRDIV_NAME"].ToString(), dtCustomer.Rows[0]["CORP_ID_CODE"].ToString());
                ddlDivision.Items.Insert(1, lstCorpDiv);
                SortDDL(ref this.ddlDivision);
                ddlDivision.Items.FindByText(dtCustomer.Rows[0]["CPRDIV_NAME"].ToString()).Selected = true;
            }



            if (dtCustomer.Rows[0]["TEAM_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["TEAM_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTeam.Items.FindByText(dtCustomer.Rows[0]["TEAM_NAME"].ToString()) != null)
                    ddlTeam.Items.FindByText(dtCustomer.Rows[0]["TEAM_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstTeams = new ListItem(dtCustomer.Rows[0]["TEAM_NAME"].ToString(), dtCustomer.Rows[0]["TEAM_ID"].ToString());
                ddlTeam.Items.Insert(1, lstTeams);
                SortDDL(ref this.ddlTeam);
                ddlTeam.Items.FindByText(dtCustomer.Rows[0]["TEAM_NAME"].ToString()).Selected = true;
            }

            if (dtCustomer.Rows[0]["LDRATE_STATUS"].ToString() == "1")
            {
                ddlLeadRate.Items.FindByText(dtCustomer.Rows[0]["LDRATE_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstLeadRate = new ListItem(dtCustomer.Rows[0]["LDRATE_NAME"].ToString(), dtCustomer.Rows[0]["LDRATE_ID"].ToString());
                ddlLeadRate.Items.Insert(1, lstLeadRate);
                SortDDL(ref this.ddlLeadRate);
                ddlLeadRate.Items.FindByText(dtCustomer.Rows[0]["LDRATE_NAME"].ToString()).Selected = true;
            }


            if (dtCustomer.Rows[0]["CSTMR_ID"] != DBNull.Value)
            {

                if (dtCustomer.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == "")
                {

                    ddlExistingCustomer.Items.FindByValue(dtCustomer.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstTeams = new ListItem(dtCustomer.Rows[0]["CSTMR_NAME"].ToString(), dtCustomer.Rows[0]["CSTMR_ID"].ToString());
                    ddlExistingCustomer.Items.Insert(1, lstTeams);
                    SortDDL(ref this.ddlExistingCustomer);
                    ddlExistingCustomer.Items.FindByValue(dtCustomer.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
                HiddenCustomerSet.Value = "1";
                cbxExistingCustomer.Checked = true;

            }
            else
            {
                HiddenCustomerSet.Value = "0";
                cbxExistingCustomer.Checked = false;

            }

            txtCustName.Text = dtCustomer.Rows[0]["LEADS_CSTMR_NAME"].ToString();
            txtAddress1.Text = dtCustomer.Rows[0]["LEADS_ADDRESS1"].ToString();
            txtAddress2.Text = dtCustomer.Rows[0]["LEADS_ADDRESS2"].ToString();
            txtAddress3.Text = dtCustomer.Rows[0]["LEADS_ADDRESS3"].ToString();
            CKEditorDescription.Text = dtCustomer.Rows[0]["LEADS_DESCRIPTION"].ToString();
            txtTitle.Text = dtCustomer.Rows[0]["LEADS_TITLE"].ToString();
            txtComments.Value = dtCustomer.Rows[0]["LEADS_COMMENTS"].ToString();
            txtDate.Text = dtCustomer.Rows[0]["LEADS_DATE"].ToString();


            if (dtCustomer.Rows[0]["PROJECT_ID"].ToString() != "")
            {

                if (dtCustomer.Rows[0]["PROJECT_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingProject.Items.FindByValue(dtCustomer.Rows[0]["PROJECT_ID"].ToString()) != null)
                    {
                        ddlExistingProject.Items.FindByValue(dtCustomer.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstPrjct = new ListItem(dtCustomer.Rows[0]["EXTNG_PROJECT_NAME"].ToString(), dtCustomer.Rows[0]["PROJECT_ID"].ToString());
                    ddlExistingProject.Items.Insert(1, lstPrjct);
                    SortDDL(ref this.ddlExistingProject);
                    ddlExistingProject.Items.FindByValue(dtCustomer.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                }

                cbxExistingProject.Checked = true;
                if (dtCustomer.Rows[0]["GUARNTMODE_ID"].ToString() != "")
                {
                    HiddenFieldddlProjectStatus.Value = dtCustomer.Rows[0]["GUARNTMODE_ID"].ToString();
                }
                ba_box1.Disabled = true;
                ba_box2.Disabled = true;
            }
            else
            {
                string strGuarntmode_ID = ReadProjectStatusByID(strId);
                if (strGuarntmode_ID == "101" || strGuarntmode_ID=="102")
                {
                    HiddenFieldddlProjectStatus.Value = strGuarntmode_ID;
                }
                cbxExistingProject.Checked = false;
            }

            if (dtCustomer.Rows[0]["LEADS_PROJECT_NAME"].ToString() != "")
            {
                txtProject.Text = dtCustomer.Rows[0]["LEADS_PROJECT_NAME"].ToString();
            }

            if (dtCustomer.Rows[0]["LEADS_CLIENT_ID"].ToString() != "")
            {

                if (dtCustomer.Rows[0]["CLIENT_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CLIENT_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingClient.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CLIENT_ID"].ToString()) != null)
                    {
                        ddlExistingClient.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CLIENT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstClient = new ListItem(dtCustomer.Rows[0]["CLIENT_NAME"].ToString(), dtCustomer.Rows[0]["LEADS_CLIENT_ID"].ToString());
                    ddlExistingClient.Items.Insert(1, lstClient);
                    SortDDL(ref this.ddlExistingClient);
                    ddlExistingClient.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CLIENT_ID"].ToString()).Selected = true;
                }

                cbxExistingClient.Checked = true;

            }
            else
            {

                cbxExistingClient.Checked = false;

            }

            if (dtCustomer.Rows[0]["LEADS_CLIENT"].ToString() != "")
            {
                txtClient.Text = dtCustomer.Rows[0]["LEADS_CLIENT"].ToString();
            }


            if (dtCustomer.Rows[0]["LEADS_CONTRACTOR_ID"].ToString() != "")
            {

                if (dtCustomer.Rows[0]["CONTRACTOR_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CONTRACTOR_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingContractor.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CONTRACTOR_ID"].ToString()) != null)
                    {
                        ddlExistingContractor.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CONTRACTOR_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstContrctr = new ListItem(dtCustomer.Rows[0]["CONTRACTOR_NAME"].ToString(), dtCustomer.Rows[0]["LEADS_CONTRACTOR_ID"].ToString());
                    ddlExistingContractor.Items.Insert(1, lstContrctr);
                    SortDDL(ref this.ddlExistingContractor);
                    ddlExistingContractor.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CONTRACTOR_ID"].ToString()).Selected = true;
                }

                cbxExistingContractor.Checked = true;

            }
            else
            {

                cbxExistingContractor.Checked = false;

            }

            if (dtCustomer.Rows[0]["LEADS_CONTRACTOR"].ToString() != "")
            {
                txtContractor.Text = dtCustomer.Rows[0]["LEADS_CONTRACTOR"].ToString();
            }


            if (dtCustomer.Rows[0]["LEADS_CONSULTANT_ID"].ToString() != "")
            {

                if (dtCustomer.Rows[0]["CONSULTANT_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CONSULTANT_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingConsultant.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CONSULTANT_ID"].ToString()) != null)
                    {
                        ddlExistingConsultant.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CONSULTANT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstConsultant = new ListItem(dtCustomer.Rows[0]["CONSULTANT_NAME"].ToString(), dtCustomer.Rows[0]["LEADS_CONSULTANT_ID"].ToString());
                    ddlExistingConsultant.Items.Insert(1, lstConsultant);
                    SortDDL(ref this.ddlExistingConsultant);
                    ddlExistingConsultant.Items.FindByValue(dtCustomer.Rows[0]["LEADS_CONSULTANT_ID"].ToString()).Selected = true;
                }

                cbxExistingConsultant.Checked = true;

            }
            else
            {

                cbxExistingConsultant.Checked = false;

            }

            if (dtCustomer.Rows[0]["LEADS_CONSULTANT"].ToString() != "")
            {
                txtConsultant.Text = dtCustomer.Rows[0]["LEADS_CONSULTANT"].ToString();
            }



            txtZipCode.Text = dtCustomer.Rows[0]["LEADS_ZIP_CODE"].ToString();

            //txtTinNumber.Text = dtCustomer.Rows[0]["LEADS_TIN_NUMBER"].ToString();
            txtMobile.Text = dtCustomer.Rows[0]["LEADS_MOBILE"].ToString();
            txtPhone.Text = dtCustomer.Rows[0]["LEADS_PHONE"].ToString();
            txtEmail.Text = dtCustomer.Rows[0]["LEADS_EMAIL"].ToString();
            txtWebSite.Text = dtCustomer.Rows[0]["LEADS_WEBSITE"].ToString();

            if (dtCustomer.Rows[0]["CNTRY_ID"] != DBNull.Value)
            {
                HiddenCountryId.Value = dtCustomer.Rows[0]["CNTRY_ID"].ToString();
                HiddenCountryName.Value = dtCustomer.Rows[0]["CNTRY_NAME"].ToString().Trim();
                ddlCountry.Items.FindByText(dtCustomer.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
            }

            if (dtCustomer.Rows[0]["STATE_ID"] != DBNull.Value)
            {
                HiddenFieldState.Value = dtCustomer.Rows[0]["STATE_ID"].ToString();
                ddlState.Text = dtCustomer.Rows[0]["STATE_NAME"].ToString();

                HiddenStateId.Value = dtCustomer.Rows[0]["STATE_ID"].ToString();
                HiddenStateName.Value = dtCustomer.Rows[0]["STATE_NAME"].ToString().Trim();

            }


            if (dtCustomer.Rows[0]["CITY_ID"] != DBNull.Value)
            {
                HiddenFieldCity.Value = dtCustomer.Rows[0]["CITY_ID"].ToString();
                ddlCity.Text = dtCustomer.Rows[0]["CITY_NAME"].ToString(); 

                HiddenCityId.Value = dtCustomer.Rows[0]["CITY_ID"].ToString();
                HiddenCityName.Value = dtCustomer.Rows[0]["CITY_NAME"].ToString().Trim();
            }


            //filling extra contact details
            if (dtContact.Rows.Count == 0) { }
            else
            {
                if (dtContact.Rows.Count >= 1)
                {
                    txtNameOne.Text = dtContact.Rows[0]["LDCNT_CNTCT_NAME"].ToString();
                    txtAddressOne.Text = dtContact.Rows[0]["LDCNT_ADDRESS"].ToString();
                    txtMobileOne.Text = dtContact.Rows[0]["LDCNT_MOBILE"].ToString();
                    txtPhoneOne.Text = dtContact.Rows[0]["LDCNT_PHONE"].ToString();
                    txtEmailOne.Text = dtContact.Rows[0]["LDCNT_EMAIL"].ToString();
                    if (dtContact.Rows[0]["LDCNT_MAIL_ALWD"].ToString() == "1")
                    {
                        cbxAllowOtherMailOne.Checked = true;
                    }
                    else
                    {
                        cbxAllowOtherMailOne.Checked = false;
                    }
                    txtWebsiteOne.Text = dtContact.Rows[0]["LDCNT_WEBSITE"].ToString();
                }
                if (dtContact.Rows.Count >= 2)
                {
                    txtNameTwo.Text = dtContact.Rows[1]["LDCNT_CNTCT_NAME"].ToString();
                    txtAddressTwo.Text = dtContact.Rows[1]["LDCNT_ADDRESS"].ToString();
                    txtMobileTwo.Text = dtContact.Rows[1]["LDCNT_MOBILE"].ToString();
                    txtPhoneTwo.Text = dtContact.Rows[1]["LDCNT_PHONE"].ToString();
                    txtEmailTwo.Text = dtContact.Rows[1]["LDCNT_EMAIL"].ToString();
                    if (dtContact.Rows[1]["LDCNT_MAIL_ALWD"].ToString() == "1")
                    {
                        cbxAllowOtherMailTwo.Checked = true;
                    }
                    else
                    {
                        cbxAllowOtherMailTwo.Checked = false;
                    }
                    txtWebsiteTwo.Text = dtContact.Rows[1]["LDCNT_WEBSITE"].ToString();
                }
                if (dtContact.Rows.Count >= 3)
                {
                    txtNameThree.Text = dtContact.Rows[2]["LDCNT_CNTCT_NAME"].ToString();
                    txtAddressThree.Text = dtContact.Rows[2]["LDCNT_ADDRESS"].ToString();
                    txtMobileThree.Text = dtContact.Rows[2]["LDCNT_MOBILE"].ToString();
                    txtPhoneThree.Text = dtContact.Rows[2]["LDCNT_PHONE"].ToString();
                    txtEmailThree.Text = dtContact.Rows[2]["LDCNT_EMAIL"].ToString();
                    if (dtContact.Rows[2]["LDCNT_MAIL_ALWD"].ToString() == "1")
                    {
                        cbxAllowOtherMailThree.Checked = true;
                    }
                    else
                    {
                        cbxAllowOtherMailThree.Checked = false;
                    }
                    txtWebsiteThree.Text = dtContact.Rows[2]["LDCNT_WEBSITE"].ToString();
                }
            }
            if (dtMedia.Rows.Count == 0) { }
            else
            {
                string strMediaValue = DataTableToJSONWithJavaScriptSerializer(dtMedia);
                hiddenMedia.Value = strMediaValue;
            }

            string strMediaHtml = "";
            int intRowIdentity = 0;
            //automatically generate media controls based on media master
            for (int intRow = 0; intRow < dtMedia.Rows.Count; intRow++)
            {
                string strTextboxName = dtMedia.Rows[intRow]["MEDIA_ID"].ToString();

                string strValue = "";
                strValue = dtMedia.Rows[intRow]["MEDIA_DESCRIPTION"].ToString();
                if (intRowIdentity == 0)
                    strMediaHtml = strMediaHtml + " <tr id=\"div7\">";
                else
                    strMediaHtml = strMediaHtml + " <tr id=\"div7\"  >";
                strMediaHtml = strMediaHtml + " <td class=\"col-md-4 tr_l\">" + dtMediaMaster.Rows[intRow]["MEDIA_NAME"] + " </td>";

                if (Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Success) ||
                             Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss))
                {

                    strMediaHtml = strMediaHtml + " <td class=\"col-md-8 tr_l\"><input placeholder=\"" + dtMediaMaster.Rows[intRow]["MEDIA_NAME"] +" Id\" disabled type=text ID=" + strTextboxName + "  class=\"form-control fg2_inp2 tr_l\" onblur=\"return AssignMediaValues(this)\" runat=\"server\" MaxLength=\"150\" value=" + strValue + " ></td>";

                }
                else
                {
                    strMediaHtml = strMediaHtml + " <td class=\"col-md-8 tr_l\"><input placeholder=\"" + dtMediaMaster.Rows[intRow]["MEDIA_NAME"] + " Id\" type=text ID=" + strTextboxName + "  class=\"form-control fg2_inp2 tr_l\" onblur=\"return AssignMediaValues(this)\" runat=\"server\" MaxLength=\"150\" value=" + strValue + " ></td>";
                }
                strMediaHtml = strMediaHtml + "</tr>";

                if (intRowIdentity == 0)
                    intRowIdentity = 1;
                else
                    intRowIdentity = 0;
            }





            divMedia.InnerHtml = strMediaHtml;

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("TransDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));

            hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);
            if (dtLeadAttchmnt.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtLeadAttchmnt.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["TransDtlId"] = dtLeadAttchmnt.Rows[intcnt]["LDATCH_ID"].ToString();
                    drAttch["FileName"] = dtLeadAttchmnt.Rows[intcnt]["LDATCH_FILENAME"].ToString();
                    drAttch["ActualFileName"] = dtLeadAttchmnt.Rows[intcnt]["LDATCH_FLNAME_ACT"].ToString();

                    dtAttchmnt.Rows.Add(drAttch);
                    hiddenAttchmntSlNumber.Value = dtLeadAttchmnt.Rows[intcnt]["LDATCH_SLNUM"].ToString();
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenEditAttchmnt.Value = strJson;
            }
            if (Request.QueryString["Dup"] != null)
            {
                hiddenEdit.Value = strId;
                hiddenView.Value = "";
            }
            else
            {
                if (Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Success) ||
                                          Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss)
                                             || Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered))
                {

                    // if view
                    hiddenEdit.Value = "";
                    hiddenView.Value = strId;
                }
                else
                {

                    // if edit
                    hiddenEdit.Value = strId;
                    hiddenView.Value = "";


                }
            }
            if (Request.QueryString["Dup"] != null)
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
                btnUpdateF.Visible = true;
                btnUpdateCloseF.Visible = true;
            }
            else
            {
                if (Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Success) ||
                               Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Loss)
                     || Convert.ToInt32(dtCustomer.Rows[0]["LDSTS_ID"]) == Convert.ToInt32(clsCommonLibrary.LeadStatus.Quotation_Delivered))
                {
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnUpdateF.Visible = false;
                    btnUpdateCloseF.Visible = false;
                }
                else
                {
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;
                    btnUpdateF.Visible = true;
                    btnUpdateCloseF.Visible = true;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        try
        {
            List<clsEntityLeadCreation> objEntityLeadList = new List<clsEntityLeadCreation>();
            List<clsEntityLeadCreation> objEntityMediaList = new List<clsEntityLeadCreation>();
            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();

            clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();

        


            string div = ddlDivision.SelectedItem.Value;
            string[] DivIdCode = (div).Split('_');
            string DivsnId = DivIdCode[0];
            int divIdLen = DivsnId.Length + 1;
            int codelength = div.Length - divIdLen;
            string DivCode = div.Substring(divIdLen, codelength);



            if (hiddenCorporateId.Value == "")
            {
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {

                objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
            }
            if (hiddenOrganisationId.Value == "")
            {
                if (Session["ORGID"] != null)
                {
                    objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
            }
            if (hiddenUserId.Value == "")
            {
                if (Session["USERID"] != null)
                {
                    objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                objEntityLead.User_Id = Convert.ToInt32(hiddenUserId.Value);
            }
            if (hiddenFinacialYearId.Value == "")
            {
                if (Session["FINCYRID"] != null)
                {
                    objEntityLead.FinYearId = Convert.ToInt32(Session["FINCYRID"].ToString());
                }
                else if (Session["FINCYRID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                objEntityLead.FinYearId = Convert.ToInt32(hiddenFinacialYearId.Value);
            }


            //if the lead generated from a mail 
            if (Request.QueryString["md"] != null)
            {
                objEntityLead.MailBoxId = Convert.ToInt64(Request.QueryString["md"]);
            }
           
            objEntityLead.LeadSourceId = Convert.ToInt32(ddlLeadSource.Value);
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityLead.LeadDate = objCommon.textToDateTime(txtDate.Text);

            objEntityLead.Description = CKEditorDescription.Text;
         //   objEntityLead.NamePrefix_Id = Convert.ToInt32(ddlNamePrefix.SelectedItem.Value);
            if (cbxExistingCustomer.Checked == false)
                objEntityLead.Customer_Name = txtCustName.Text.ToUpper().Trim();
            else
            {
                objEntityLead.Customer_Name = ddlExistingCustomer.SelectedItem.Text;
                objEntityLead.Customer_Id = Convert.ToInt32(ddlExistingCustomer.SelectedItem.Value);
            }

            objEntityLead.DivisionId = Convert.ToInt32(DivsnId);
            objEntityLead.DivisionCode = DivCode;

            objEntityLead.Title = txtTitle.Text.Trim();
            objEntityLead.Team = Convert.ToInt32(ddlTeam.SelectedItem.Value);
            if (txtComments.Value.Length > 2000)
                objEntityLead.Comments = txtComments.Value.Substring(0, 2000);
            else
                objEntityLead.Comments = txtComments.Value;


            if (cbxExistingProject.Checked == false)
            {
                objEntityLead.Project = txtProject.Text.ToUpper().Trim();
                objEntityLead.ProjectStatus = Convert.ToInt32(HiddenFieldddlProjectStatus.Value);
            }
            else
            {
                if (ddlExistingProject.SelectedItem.Value != "--SELECT PROJECT--" && ddlExistingProject.SelectedItem.Value != "")
                {
                    objEntityLead.Project = ddlExistingProject.SelectedItem.Text.ToUpper().Trim();
                    objEntityLead.Project_Id = Convert.ToInt32(ddlExistingProject.SelectedItem.Value);
                }
            }
            if (cbxExistingClient.Checked == false)
            {
                objEntityLead.Client = txtClient.Text.ToUpper().Trim();
            }
            else
            {
                if (ddlExistingClient.SelectedItem.Value != "--SELECT CLIENT--" && ddlExistingClient.SelectedItem.Value != "")
                {
                    objEntityLead.Client = ddlExistingClient.SelectedItem.Text.ToUpper().Trim();
                    objEntityLead.Client_Id = Convert.ToInt32(ddlExistingClient.SelectedItem.Value);
                }
            }
            if (cbxExistingContractor.Checked == false)
            {
                objEntityLead.Contractor = txtContractor.Text.ToUpper().Trim();
            }
            else
            {
                if (ddlExistingContractor.SelectedItem.Value != "--SELECT CONTRACTOR--" && ddlExistingContractor.SelectedItem.Value != "")
                {
                    objEntityLead.Contractor = ddlExistingContractor.SelectedItem.Text.ToUpper().Trim();
                    objEntityLead.Contractor_Id = Convert.ToInt32(ddlExistingContractor.SelectedItem.Value);
                }
            }
            if (cbxExistingConsultant.Checked == false)
            {
                objEntityLead.Consultant = txtConsultant.Text.ToUpper().Trim();
            }
            else
            {
                if (ddlExistingConsultant.SelectedItem.Value != "--SELECT CONSULTANT--" && ddlExistingConsultant.SelectedItem.Value != "")
                {
                    objEntityLead.Consultant = ddlExistingConsultant.SelectedItem.Text.ToUpper().Trim();
                    objEntityLead.Consultant_Id = Convert.ToInt32(ddlExistingConsultant.SelectedItem.Value);
                }
            }
           
            objEntityLead.Address1 = txtAddress1.Text.Trim();
            objEntityLead.Address2 = txtAddress2.Text.Trim();
            objEntityLead.Address3 = txtAddress3.Text.Trim();
            objEntityLead.InsertDate = System.DateTime.Now;

            //IF COUNTRY NOT SELECTED
            if (ddlCountry.SelectedItem.Value == "--SELECT YOUR COUNTRY--")
            {
                objEntityLead.CountryId = 0;
            }
            //IF COUNTRY SELECTED
            else
            {
                objEntityLead.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            }
            if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
            {
                //objEntityPartner.StateId = null;
                //objEntityPartner.CityId = null;
            }
            else
            {
                objEntityLead.StateId = Convert.ToInt32(HiddenFieldState.Value);
                //If there is no city selected
                if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
                {
                    //  objEntityPartner.CityId = null;
                }
                else
                {
                    objEntityLead.CityId = Convert.ToInt32(HiddenFieldCity.Value);
                }
            }
           


            objEntityLead.ZipCode = txtZipCode.Text.Trim();
            //objEntityLead.TinNumber = txtTinNumber.Text.Trim();
            objEntityLead.Mobile = txtMobile.Text.Trim();
            objEntityLead.Phone = txtPhone.Text.Trim();
            objEntityLead.Email = txtEmail.Text.Trim();
            objEntityLead.Web = txtWebSite.Text.Trim();

            if (ddlLeadRate.SelectedItem.Text.ToString() == "--SELECT OPPORTUNITY RATING--")
            {
                objEntityLead.LeadRating = 0;
            }
            else
            {

                objEntityLead.LeadRating = Convert.ToInt32(ddlLeadRate.SelectedItem.Value);
            }

            //Checking is there table have any name like this
            //string strNameCount = objBusinessLayerCustomer.CheckCustomerName(objEntityCustomer);

            if (txtNameOne.Text.Trim() != "" && txtNameOne.Text.Trim() != null)
            {
                clsEntityLeadCreation objEntityLeadOne = new clsEntityLeadCreation();
                objEntityLeadOne.Customer_Name = txtNameOne.Text.ToUpper().Trim();
                objEntityLeadOne.Address1 = txtAddressOne.Text;
                objEntityLeadOne.Mobile = txtMobileOne.Text;
                objEntityLeadOne.Phone = txtPhoneOne.Text;
                objEntityLeadOne.Email = txtEmailOne.Text;
                objEntityLeadOne.Web = txtWebsiteOne.Text;
                if (cbxAllowOtherMailOne.Checked == true)
                {
                    objEntityLeadOne.MailSendAllwd = 1;
                }
                objEntityLeadList.Add(objEntityLeadOne);
            }

            if (txtNameTwo.Text.Trim() != "" && txtNameTwo.Text.Trim() != null)
            {
                clsEntityLeadCreation objEntityLeadTwo = new clsEntityLeadCreation();
                objEntityLeadTwo.Customer_Name = txtNameTwo.Text.ToUpper().Trim();
                objEntityLeadTwo.Address1 = txtAddressTwo.Text;
                objEntityLeadTwo.Mobile = txtMobileTwo.Text;
                objEntityLeadTwo.Phone = txtPhoneTwo.Text;
                objEntityLeadTwo.Email = txtEmailTwo.Text;
                objEntityLeadTwo.Web = txtWebsiteTwo.Text;
                if (cbxAllowOtherMailTwo.Checked == true)
                {
                    objEntityLeadTwo.MailSendAllwd = 1;
                }
                objEntityLeadList.Add(objEntityLeadTwo);
            }

            if (txtNameThree.Text.Trim() != "" && txtNameThree.Text.Trim() != null)
            {
                clsEntityLeadCreation objEntityLeadThree = new clsEntityLeadCreation();
                objEntityLeadThree.Customer_Name = txtNameThree.Text.ToUpper().Trim();
                objEntityLeadThree.Address1 = txtAddressThree.Text;
                objEntityLeadThree.Mobile = txtMobileThree.Text;
                objEntityLeadThree.Phone = txtPhoneThree.Text;
                objEntityLeadThree.Email = txtEmailThree.Text;
                objEntityLeadThree.Web = txtWebsiteThree.Text;
                if (cbxAllowOtherMailThree.Checked == true)
                {
                    objEntityLeadThree.MailSendAllwd = 1;
                }
                objEntityLeadList.Add(objEntityLeadThree);
            }

            //fetching mail id if the lead created from a mail
            if (Request.QueryString["md"] != null)
            {
                Int64 intMailid = Convert.ToInt64(Request.QueryString["md"]);
                objEntityLead.MailBoxId = intMailid;
            }


            dtMedia = objBusinessLead.Read_Media_Master();
            if (dtMedia.Rows.Count == 0)
            {
            }
            else
            {

                //convert media values that placed in jason
                string jsonData = hiddenMedia.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string g = c.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsEntityLeadCreation> objMediaList = new List<clsEntityLeadCreation>();

                objMediaList = JsonConvert.DeserializeObject<List<clsEntityLeadCreation>>(i);

                for (int intRowCount = 0; intRowCount < dtMedia.Rows.Count; intRowCount++)
                {
                    clsEntityLeadCreation objEntityMedia = new clsEntityLeadCreation();
                    objEntityMedia.Media_Id = Convert.ToInt32(dtMedia.Rows[intRowCount]["MEDIA_ID"]);
                    objEntityMediaList.Add(objEntityMedia);
                }

                //add media details
                if (objMediaList != null)
                {
                    foreach (clsEntityLeadCreation MediaCust in objMediaList)
                    {
                        if (MediaCust != null)
                        {
                            foreach (clsEntityLeadCreation CustMedia in objEntityMediaList)
                            {
                                if (MediaCust.Media_Id == CustMedia.Media_Id)
                                    CustMedia.Media_Description = MediaCust.Media_Description;
                            }
                        }
                    }
                }

            }

            //for file upload
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.LEAD);
            objEntityCommon.CorporateID = objEntityLead.Corp_Id;
            string strNextNum = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

            objEntityLead.LeadId = Convert.ToInt32(strNextNum);

            List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntDeatilsList = new List<clsEntityLayerLeadAttchmntDtl>();
            int intSlNumbr = 0;
            for (int intCount = 0; intCount < Request.Files.Count; intCount++)
            {

                HttpPostedFile PostedFile = Request.Files[intCount];

                if (PostedFile.ContentLength > 0)
                {
                    clsEntityLayerLeadAttchmntDtl objEntityLeadDetailsAttchmnt = new clsEntityLayerLeadAttchmntDtl();
                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                    objEntityLeadDetailsAttchmnt.ActualFileName = strFileName;
                    string strFileExt;

                    strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                    int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.LEAD);
                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);
                    objEntityLeadDetailsAttchmnt.LeadAttchmntSlNumber = intSlNumbr;
                    string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityLead.LeadId.ToString() + "_" + intSlNumbr + "." + strFileExt;
                    objEntityLeadDetailsAttchmnt.FileName = strImageName;
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);

                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLeadDetailsAttchmnt.FileName);

                    objEntityLeadAttchmntDeatilsList.Add(objEntityLeadDetailsAttchmnt);

                    //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);
                    intSlNumbr++;
                }

            }
            
            List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntList = new List<clsEntityLayerLeadAttchmntDtl>();

            objEntityLeadAttchmntList = JsonConvert.DeserializeObject<List<clsEntityLayerLeadAttchmntDtl>>(hiddenMailAttachment.Value);

            if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
            {
                string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                string strAtt2 = strAtt1.Replace("\\", "");
                string strAtt3 = strAtt2.Replace("}\"]", "}]");
                string strAtt4 = strAtt3.Replace("}\",", "},");
                List<clsLeadDataDELETEAttchmnt> objLeadDataDltAttList = new List<clsLeadDataDELETEAttchmnt>();
                //   UserData  data
                objLeadDataDltAttList = JsonConvert.DeserializeObject<List<clsLeadDataDELETEAttchmnt>>(strAtt4);


                foreach (clsLeadDataDELETEAttchmnt objClsLeadDltAttData in objLeadDataDltAttList)
                {

                    clsEntityLayerLeadAttchmntDtl objEntityLeadAttDetails = new clsEntityLayerLeadAttchmntDtl();

                    objEntityLeadAttDetails.LeadAttchmntDtlId = Convert.ToInt32(objClsLeadDltAttData.DTLID);
                    objEntityLeadAttDetails.FileName = Convert.ToString(objClsLeadDltAttData.FILENAME);

                    foreach (clsEntityLayerLeadAttchmntDtl objAttch in objEntityLeadAttchmntList)
                    {
                        if (objAttch.LeadAttchmntDtlId == objEntityLeadAttDetails.LeadAttchmntDtlId)
                        {
                            objEntityLeadAttchmntList.Remove(objAttch);
                            goto outer;
                        }
                    }
                outer: ;
                   // objEntityLeadAttchmntDELETEDeatilsList.Add(objEntityLeadAttDetails);


                }
            }

            if (objEntityLeadAttchmntList != null)
            {

                foreach (clsEntityLayerLeadAttchmntDtl objAttch in objEntityLeadAttchmntList)
                {
                    clsEntityLayerLeadAttchmntDtl objEntityLeadDetailsAttchmnt = new clsEntityLayerLeadAttchmntDtl();

                    objEntityLeadDetailsAttchmnt.ActualFileName = objAttch.ActualFileName;

                    string strFileExt;

                    strFileExt = objAttch.ActualFileName.Substring(objAttch.ActualFileName.LastIndexOf('.') + 1).ToLower();

                    int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.LEAD);
                    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);
                    objEntityLeadDetailsAttchmnt.LeadAttchmntSlNumber = intSlNumbr;
                    string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityLead.LeadId.ToString() + "_" + intSlNumbr + "." + strFileExt;
                    objEntityLeadDetailsAttchmnt.FileName = strImageName;
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);

                    objEntityLeadAttchmntDeatilsList.Add(objEntityLeadDetailsAttchmnt);

                    string strOrginalPath = @"\" + objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Mail_Attachments);

                    if (File.Exists(Server.MapPath(strOrginalPath) + objAttch.FileName))
                    {
                        File.Copy(Server.MapPath(strOrginalPath) + objAttch.FileName, Server.MapPath(strImagePath) + objEntityLeadDetailsAttchmnt.FileName);
                    }
                    intSlNumbr++;

                }
            }
            objBusinessLead.AddLead(objEntityLead, objEntityLeadList, objEntityMediaList, objEntityLeadAttchmntDeatilsList);
            //if (Request.QueryString["L_MODE"] != null)
            //{
            //    string strL_MODE = Request.QueryString["L_MODE"].ToString();
            //    Response.Redirect("gen_Lead.aspx?InsUpd=Ins&L_MODE=" + strL_MODE + "");
            //}
            //else
            //{
            //    Response.Redirect("gen_Lead.aspx?InsUpd=Ins");
            //}
            string strRandom = objCommon.Random_Number();

            string strId = objEntityLead.LeadId.ToString();
            int intIdLength = strId.Length;
            string stridLength = intIdLength.ToString("00");
            string strRandomLeadMixedId = stridLength + strId + strRandom;
            if (clickedButton.ID == "btnSave" || clickedButton.ID == "btnSaveF")
            {
                if (Request.QueryString["L_MODE"] != null)
                {
                    string strL_MODE = Request.QueryString["L_MODE"].ToString();
                    Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&InsUpd=ANL&L_MODE=" + strL_MODE + "");
                }
                else
                {
                    Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&InsUpd=ANL");
                }
            }
            else if (clickedButton.ID == "btnSaveClose" || clickedButton.ID == "btnSaveCloseF")
            {
                if (Request.QueryString["L_MODE"] != null)
                {
                    string strL_MODE = Request.QueryString["L_MODE"].ToString();
                    Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?InsUpd=InsList&L_MODE=" + strL_MODE + "");
                }
                else
                {
                    Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?InsUpd=InsList");
                }

            }
          
        }
        catch
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
        }
    }


    //for sorting drop down
    public void SortDDL(ref DropDownList objDDL)
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


    //convert datatable to json format
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


    // its just for uploading
    public void btnUpload_Click()
    {
        //HttpFileCollection hfc = Request.Files;
        //for (int i = 0; i < hfc.Count; i++)
        //{
        //    foreach (String h in hfc.AllKeys)
        //    {
        //        // Add an item to a folder
        //        // was specified for the corresponding control.
        //        HttpPostedFile PostedFile = hfc[h];
        //        if (hfc[h].ContentLength > 0)
        //        {
        //            string FileName = System.IO.Path.GetFileName(PostedFile.FileName);
        //            PostedFile.SaveAs(Server.MapPath("~/Files/") + FileName);
        //        }
        //    }
        //}

        HttpFileCollection fileCollection = Request.Files;
        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile uploadfile = fileCollection[i];
            string fileName = Path.GetFileName(uploadfile.FileName);
            if (uploadfile.ContentLength > 0)
            {
                uploadfile.SaveAs(Server.MapPath("~/UploadFiles/") + fileName);
                string str = fileName;
            }
        }


    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
      // try
    //   {
            if (Request.QueryString["Id"] != null)
            {
                List<clsEntityLeadCreation> objEntityLeadList = new List<clsEntityLeadCreation>();
                List<clsEntityLeadCreation> objEntityMediaList = new List<clsEntityLeadCreation>();
                clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();

                clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();

                string div = ddlDivision.SelectedItem.Value;
                string[] DivIdCode = (div).Split('_');
                string DivsnId = DivIdCode[0];
                int divIdLen = DivsnId.Length + 1;
                int codelength = div.Length - divIdLen;
                string DivCode = div.Substring(divIdLen, codelength);

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityLead.LeadId = Convert.ToInt32(strId);
                if (hiddenCorporateId.Value == "")
                {
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityLead.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {

                    objEntityLead.Corp_Id = Convert.ToInt32(hiddenCorporateId.Value);
                }
                if (hiddenOrganisationId.Value == "")
                {
                    if (Session["ORGID"] != null)
                    {
                        objEntityLead.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityLead.Org_Id = Convert.ToInt32(hiddenOrganisationId.Value);
                }
                if (hiddenUserId.Value == "")
                {
                    if (Session["USERID"] != null)
                    {
                        objEntityLead.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                    }
                    else if (Session["USERID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityLead.User_Id = Convert.ToInt32(hiddenUserId.Value);
                }
                if (hiddenFinacialYearId.Value == "")
                {
                    if (Session["FINCYRID"] != null)
                    {
                        objEntityLead.FinYearId = Convert.ToInt32(Session["FINCYRID"].ToString());
                    }
                    else if (Session["FINCYRID"] == null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    objEntityLead.FinYearId = Convert.ToInt32(hiddenFinacialYearId.Value);
                }


                clsCommonLibrary objCommon = new clsCommonLibrary();
                objEntityLead.LeadSourceId = Convert.ToInt32(ddlLeadSource.Value);
                objEntityLead.LeadDate = objCommon.textToDateTime(txtDate.Text);

                objEntityLead.Description = CKEditorDescription.Text;
             //   objEntityLead.NamePrefix_Id = Convert.ToInt32(ddlNamePrefix.SelectedItem.Value);
                if (cbxExistingCustomer.Checked == false)
                    objEntityLead.Customer_Name = txtCustName.Text.ToUpper().Trim();
                else
                {
                    objEntityLead.Customer_Name = ddlExistingCustomer.SelectedItem.Text;
                    objEntityLead.Customer_Id = Convert.ToInt32(ddlExistingCustomer.SelectedItem.Value);
                }

                objEntityLead.DivisionId = Convert.ToInt32(DivsnId);
                objEntityLead.DivisionCode = DivCode;

                objEntityLead.Title = txtTitle.Text.Trim();
                objEntityLead.Team = Convert.ToInt32(ddlTeam.SelectedItem.Value);
                if (txtComments.Value.Length > 2000)
                    objEntityLead.Comments = txtComments.Value.Substring(0, 2000);
                else
                    objEntityLead.Comments = txtComments.Value;
                if (cbxExistingProject.Checked == false)
                {
                    objEntityLead.Project = txtProject.Text.ToUpper().Trim();
                    objEntityLead.ProjectStatus = Convert.ToInt32(HiddenFieldddlProjectStatus.Value);
                }
                else
                {
                    if (ddlExistingProject.SelectedItem.Value != "--SELECT PROJECT--" && ddlExistingProject.SelectedItem.Value != "")
                    {
                        objEntityLead.Project = ddlExistingProject.SelectedItem.Text.ToUpper().Trim();
                        objEntityLead.Project_Id = Convert.ToInt32(ddlExistingProject.SelectedItem.Value);
                    }
                }
                if (cbxExistingClient.Checked == false)
                {
                    objEntityLead.Client = txtClient.Text.ToUpper().Trim();
                }
                else
                {
                    if (ddlExistingClient.SelectedItem.Value != "--SELECT CLIENT--" && ddlExistingClient.SelectedItem.Value != "")
                    {
                        objEntityLead.Client = ddlExistingClient.SelectedItem.Text.ToUpper().Trim();
                        objEntityLead.Client_Id = Convert.ToInt32(ddlExistingClient.SelectedItem.Value);
                    }
                }
                if (cbxExistingContractor.Checked == false)
                {
                    objEntityLead.Contractor = txtContractor.Text.ToUpper().Trim();
                }
                else
                {
                    if (ddlExistingContractor.SelectedItem.Value != "--SELECT CONTRACTOR--" && ddlExistingContractor.SelectedItem.Value != "")
                    {
                        objEntityLead.Contractor = ddlExistingContractor.SelectedItem.Text.ToUpper().Trim();
                        objEntityLead.Contractor_Id = Convert.ToInt32(ddlExistingContractor.SelectedItem.Value);
                    }
                }
                if (cbxExistingConsultant.Checked == false)
                {
                    objEntityLead.Consultant = txtConsultant.Text.ToUpper().Trim();
                }
                else
                {
                    if (ddlExistingConsultant.SelectedItem.Value != "--SELECT CONSULTANT--" && ddlExistingConsultant.SelectedItem.Value != "")
                    {
                        objEntityLead.Consultant = ddlExistingConsultant.SelectedItem.Text.ToUpper().Trim();
                        objEntityLead.Consultant_Id = Convert.ToInt32(ddlExistingConsultant.SelectedItem.Value);
                    }
                }
                objEntityLead.Address1 = txtAddress1.Text.Trim();
                objEntityLead.Address2 = txtAddress2.Text.Trim();
                objEntityLead.Address3 = txtAddress3.Text.Trim();
                objEntityLead.InsertDate = DateTime.Now;

                //IF COUNTRY NOT SELECTED
                if (ddlCountry.SelectedItem.Value == "--SELECT YOUR COUNTRY--")
                {
                    objEntityLead.CountryId = 0;
                }
                //IF COUNTRY SELECTED
                else
                {
                    objEntityLead.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                }
                if (HiddenFieldState.Value == "" || HiddenFieldState.Value == null)
                {
                    //objEntityPartner.StateId = null;
                    //objEntityPartner.CityId = null;
                }
                else
                {
                    objEntityLead.StateId = Convert.ToInt32(HiddenFieldState.Value);
                    //If there is no city selected
                    if (HiddenFieldCity.Value == "" || HiddenFieldCity.Value == null)
                    {
                        //  objEntityPartner.CityId = null;
                    }
                    else
                    {
                        objEntityLead.CityId = Convert.ToInt32(HiddenFieldCity.Value);
                    }
                }

                objEntityLead.ZipCode = txtZipCode.Text.Trim();
                //objEntityLead.TinNumber = txtTinNumber.Text.Trim();
                objEntityLead.Mobile = txtMobile.Text.Trim();
                objEntityLead.Phone = txtPhone.Text.Trim();
                objEntityLead.Email = txtEmail.Text.Trim();
                objEntityLead.Web = txtWebSite.Text.Trim();

                if (ddlLeadRate.SelectedItem.Text.ToString() == "--SELECT OPPORTUNITY RATING--")
                {
                    objEntityLead.LeadRating = 0;
                }
                else
                {

                    objEntityLead.LeadRating = Convert.ToInt32(ddlLeadRate.SelectedItem.Value);
                }


                if (txtNameOne.Text.Trim() != "" && txtNameOne.Text.Trim() != null)
                {
                    clsEntityLeadCreation objEntityLeadOne = new clsEntityLeadCreation();
                    objEntityLeadOne.Customer_Name = txtNameOne.Text.ToUpper().Trim();
                    objEntityLeadOne.Address1 = txtAddressOne.Text;
                    objEntityLeadOne.Mobile = txtMobileOne.Text;
                    objEntityLeadOne.Phone = txtPhoneOne.Text;
                    objEntityLeadOne.Email = txtEmailOne.Text;
                    objEntityLeadOne.Web = txtWebsiteOne.Text;
                    if (cbxAllowOtherMailOne.Checked == true)
                    {
                        objEntityLeadOne.MailSendAllwd = 1;
                    }
                    objEntityLeadList.Add(objEntityLeadOne);
                }

                if (txtNameTwo.Text.Trim() != "" && txtNameTwo.Text.Trim() != null)
                {
                    clsEntityLeadCreation objEntityLeadTwo = new clsEntityLeadCreation();
                    objEntityLeadTwo.Customer_Name = txtNameTwo.Text.ToUpper().Trim();
                    objEntityLeadTwo.Address1 = txtAddressTwo.Text;
                    objEntityLeadTwo.Mobile = txtMobileTwo.Text;
                    objEntityLeadTwo.Phone = txtPhoneTwo.Text;
                    objEntityLeadTwo.Email = txtEmailTwo.Text;
                    objEntityLeadTwo.Web = txtWebsiteTwo.Text;
                    if (cbxAllowOtherMailTwo.Checked == true)
                    {
                        objEntityLeadTwo.MailSendAllwd = 1;
                    }
                    objEntityLeadList.Add(objEntityLeadTwo);
                }

                if (txtNameThree.Text.Trim() != "" && txtNameThree.Text.Trim() != null)
                {
                    clsEntityLeadCreation objEntityLeadThree = new clsEntityLeadCreation();
                    objEntityLeadThree.Customer_Name = txtNameThree.Text.ToUpper().Trim();
                    objEntityLeadThree.Address1 = txtAddressThree.Text;
                    objEntityLeadThree.Mobile = txtMobileThree.Text;
                    objEntityLeadThree.Phone = txtPhoneThree.Text;
                    objEntityLeadThree.Email = txtEmailThree.Text;
                    objEntityLeadThree.Web = txtWebsiteThree.Text;
                    if (cbxAllowOtherMailThree.Checked == true)
                    {
                        objEntityLeadThree.MailSendAllwd = 1;
                    }
                    objEntityLeadList.Add(objEntityLeadThree);
                }
                dtMedia = objBusinessLead.Read_Media_Master();
                if (dtMedia.Rows.Count == 0)
                {
                }
                else
                {

                    //convert media values that placed in jason
                    string jsonData = hiddenMedia.Value;
                    string c = jsonData.Replace("\"{", "\\{");
                    string g = c.Replace("\\", "");
                    string h = g.Replace("}\"]", "}]");
                    string i = h.Replace("}\",", "},");

                    List<clsEntityLeadCreation> objMediaList = new List<clsEntityLeadCreation>();

                    objMediaList = JsonConvert.DeserializeObject<List<clsEntityLeadCreation>>(i);

                    for (int intRowCount = 0; intRowCount < dtMedia.Rows.Count; intRowCount++)
                    {
                        clsEntityLeadCreation objEntityMedia = new clsEntityLeadCreation();
                        objEntityMedia.Media_Id = Convert.ToInt32(dtMedia.Rows[intRowCount]["MEDIA_ID"]);
                        objEntityMediaList.Add(objEntityMedia);
                    }

                    foreach (clsEntityLeadCreation MediaCust in objMediaList)
                    {
                        if (MediaCust != null)
                        {
                            foreach (clsEntityLeadCreation CustMedia in objEntityMediaList)
                            {
                                if (MediaCust.Media_Id == CustMedia.Media_Id)
                                    CustMedia.Media_Description = MediaCust.Media_Description;
                            }
                        }
                    }

                }
               

                List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntINSERTDeatilsList = new List<clsEntityLayerLeadAttchmntDtl>();
                int intSlNumbr = 0;
                if (hiddenAttchmntSlNumber.Value != "")
                {
                    intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                    intSlNumbr++;

                }
                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                {

                    HttpPostedFile PostedFile = Request.Files[intCount];

                    if (PostedFile.ContentLength > 0)
                    {
                        clsEntityLayerLeadAttchmntDtl objEntityLeadDetailsAttchmnt = new clsEntityLayerLeadAttchmntDtl();
                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        objEntityLeadDetailsAttchmnt.ActualFileName = strFileName;
                        string strFileExt;

                        strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                        int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.LEAD);
                        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);
                        objEntityLeadDetailsAttchmnt.LeadAttchmntSlNumber = intSlNumbr;
                        string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityLead.LeadId.ToString() + "_" + intSlNumbr + "." + strFileExt;
                        objEntityLeadDetailsAttchmnt.FileName = strImageName;
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);

                        PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLeadDetailsAttchmnt.FileName);

                        objEntityLeadAttchmntINSERTDeatilsList.Add(objEntityLeadDetailsAttchmnt);

                        //  PostedFile.SaveAs(Server.MapPath("Files\\") + FileName);
                        intSlNumbr++;
                    }

                }                
                

                List<clsEntityLayerLeadAttchmntDtl> objEntityLeadAttchmntDELETEDeatilsList = new List<clsEntityLayerLeadAttchmntDtl>();

                if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                {
                    string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");
                    List<clsLeadDataDELETEAttchmnt> objLeadDataDltAttList = new List<clsLeadDataDELETEAttchmnt>();
                    //   UserData  data
                    objLeadDataDltAttList = JsonConvert.DeserializeObject<List<clsLeadDataDELETEAttchmnt>>(strAtt4);


                    foreach (clsLeadDataDELETEAttchmnt objClsLeadDltAttData in objLeadDataDltAttList)
                    {

                        clsEntityLayerLeadAttchmntDtl objEntityLeadAttDetails = new clsEntityLayerLeadAttchmntDtl();

                        objEntityLeadAttDetails.LeadAttchmntDtlId = Convert.ToInt32(objClsLeadDltAttData.DTLID);
                        objEntityLeadAttDetails.FileName = Convert.ToString(objClsLeadDltAttData.FILENAME);

                        objEntityLeadAttchmntDELETEDeatilsList.Add(objEntityLeadAttDetails);


                    }
                }





                objBusinessLead.UpdateLead(objEntityLead, objEntityLeadList, objEntityMediaList, objEntityLeadAttchmntINSERTDeatilsList, objEntityLeadAttchmntDELETEDeatilsList);

                //Delete from location
                foreach (clsEntityLayerLeadAttchmntDtl objAttchDetail in objEntityLeadAttchmntDELETEDeatilsList)
                {

                    string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.LEAD_ATTACHMENT);
                    string imageLocation = strImgPath + objAttchDetail.FileName;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    if (Request.QueryString["Prev"] != null)
                    {
                        string strPrevUrl = Request.QueryString["Prev"].ToString();
                        if (strPrevUrl == "Indvl")
                        {
                            if (Request.QueryString["Id"] != null)
                            {
                                string strRandomLeadMixedId = Request.QueryString["Id"].ToString();
                                if (Request.QueryString["L_MODE"] != null)
                                {
                                    string strL_MODE = Request.QueryString["L_MODE"].ToString();
                                    Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&InsUpd=new&L_MODE=" + strL_MODE + "");
                                }
                                else
                                {
                                    Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&InsUpd=new");
                                }

                            }
                            else
                            {
                                if (Request.QueryString["L_MODE"] != null)
                                {
                                    string strL_MODE = Request.QueryString["L_MODE"].ToString();
                                    Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + strL_MODE + "");
                                }
                                else
                                {
                                    Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx");
                                }


                            }

                        }
                        else
                        {
                            if (Request.QueryString["L_MODE"] != null)
                            {
                                string strL_MODE = Request.QueryString["L_MODE"].ToString();
                                Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + strL_MODE + "");
                            }
                            else
                            {
                                Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx");
                            }


                        }
                    }
                    else
                    {

                        if (Request.QueryString["Id"] != null)
                        {
                            string strRandomLeadMixedId = Request.QueryString["Id"].ToString();
                            if (Request.QueryString["L_MODE"] != null)
                            {
                                string strL_MODE = Request.QueryString["L_MODE"].ToString();
                                Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&InsUpd=new&L_MODE=" + strL_MODE + "");
                            }
                            else
                            {
                                Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&InsUpd=new");
                            }

                        }
                        else
                        {
                            if (Request.QueryString["L_MODE"] != null)
                            {
                                string strL_MODE = Request.QueryString["L_MODE"].ToString();
                                Response.Redirect("gen_Lead.aspx?InsUpd=Upd&L_MODE=" + strL_MODE + "");
                            }
                            else
                            {
                                Response.Redirect("gen_Lead.aspx?InsUpd=Upd");
                            }
                        }
                    }
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {

                    if (Request.QueryString["L_MODE"] != null)
                    {
                        string strL_MODE = Request.QueryString["L_MODE"].ToString();
                        Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?InsUpd=UpdList&L_MODE=" + strL_MODE + "");
                    }
                    else
                    {
                        Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?InsUpd=UpdList");
                    }


                }


            }
      //  }
     //  catch
       // {
       //   ScriptManager.RegisterStartupScript(this, GetType(), "ErrorMsg", "ErrorMsg();", true);
      // }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Prev"] != null)
        {
            string strPrevUrl = Request.QueryString["Prev"].ToString();
            if (strPrevUrl == "Indvl")
            {
                if (Request.QueryString["Id"] != null)
                {
                    string strRandomLeadMixedId = Request.QueryString["Id"].ToString();
                    if (Request.QueryString["L_MODE"] != null)
                    {
                        string strL_MODE = Request.QueryString["L_MODE"].ToString();            
                        Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "&L_MODE=" + strL_MODE + "");
                    }
                    else
                    {
                        Response.Redirect("/Transaction/gen_Lead/gen_LeadIndividualList.aspx?Id=" + strRandomLeadMixedId + "");
                    }
                  
                }
                else
                {
                    if (Request.QueryString["L_MODE"] != null)
                    {
                        string strL_MODE = Request.QueryString["L_MODE"].ToString();
                        Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + strL_MODE + "");
                    }
                    else
                    {
                        Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx");
                    }
                 

                }

            }
            else if (strPrevUrl == "Mail")
            {

                Response.Redirect("/Transaction/Compzit_Mailbox/Compzit_Mailbox.aspx");

            }
            else
            {
                if (Request.QueryString["L_MODE"] != null)
                {
                    string strL_MODE = Request.QueryString["L_MODE"].ToString();
                    Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + strL_MODE + "");
                }
                else
                {
                    Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx");
                }

            }
        }

        else
        {
            if (Request.QueryString["L_MODE"] != null)
            {
                string strL_MODE = Request.QueryString["L_MODE"].ToString();
                Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx?L_MODE=" + strL_MODE + "");
            }
            else
            {
                Response.Redirect("/Transaction/gen_Lead/gen_LeadList.aspx");
            }


        }

    }

    //fetch and set mail details if the lead generated from a mail
    private void Mail_Set()
    {

        if (Request.QueryString["md"] != null)
        {
            ddlLeadSource.Items.FindByText(clsCommonLibrary.Lead_Sources.Mail.ToString()).Selected = true;
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
            clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();
            objEntityLead.MailBoxId = Convert.ToInt64(Request.QueryString["md"]);
            DataTable dtMailDetails = objBusinessLead.ReadMailDetails(objEntityLead);
            DataTable dtMailAttachment = objBusinessLead.Read_Mail_Attachment(objEntityLead);
            if (dtMailDetails.Rows.Count > 0)
            {
                if (dtMailDetails.Rows[0]["MLBOX_CONTENT"] != DBNull.Value)
                {
                    CKEditorDescription.Text = dtMailDetails.Rows[0]["MLBOX_CONTENT"].ToString();
                    
                }
                if (dtMailDetails.Rows[0]["MLBOX_FROM_MAIL"].ToString() != "")
                {
                    string strFromMail = dtMailDetails.Rows[0]["MLBOX_FROM_MAIL"].ToString();
                    try
                    {
                        string[] strSplit1 = strFromMail.Split('<');
                        strFromMail = strSplit1[1].ToString();
                        string[] strSplit2 = strFromMail.Split('>');
                        strFromMail = strSplit2[0].ToString();
                    }
                    catch
                    {
                    
                    
                    }
                    txtEmail.Text = strFromMail;
                }
                if (dtMailDetails.Rows[0]["MLBOX_SUBJECT"].ToString() != "")
                {
                    string strTitle = dtMailDetails.Rows[0]["MLBOX_SUBJECT"].ToString();
                    txtTitle.Text = strTitle;
                }
                //txtDate.Text = System.DateTime.Now.ToShortDateString();
            }
            hiddenFileMailPath.Value ="/" + objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Mail_Attachments);


            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("LeadAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));


            if (dtMailAttachment.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtMailAttachment.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["LeadAttchmntDtlId"] = dtMailAttachment.Rows[intcnt]["MLBXATCH_ID"].ToString();
                    drAttch["FileName"] = dtMailAttachment.Rows[intcnt]["MLBXATCH_FLNAME"].ToString();
                    drAttch["ActualFileName"] = dtMailAttachment.Rows[intcnt]["MLBXATCH_ACT_FLNM"].ToString();

                    dtAttchmnt.Rows.Add(drAttch);
                    hiddenAttchmntSlNumber.Value = intcnt.ToString();
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenMailAttachment.Value = strJson;
            }

        }

        clsEntityLayerLeadAttchmntDtl objA = new clsEntityLayerLeadAttchmntDtl();
        


    }
    public class clsLeadDataDELETEAttchmnt
    {
        public string FILENAME { get; set; }

        public string DTLID { get; set; }

    }

    //select customer deatils through web service
    [WebMethod]
    public static string[] CustomerDetails(string strCustomerId)
    {
        string[] strArray = new string[36];

        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        clsBusinessLayerLeadCreation objBusinesLead = new clsBusinessLayerLeadCreation();
        if (strCustomerId != "--SELECT CUSTOMER/COMPANY--")
        {
            objEntityCustomer.Customer_Id = Convert.ToInt32(strCustomerId);
        }
        else {

            objEntityCustomer.Customer_Id = 0;
        }

        DataTable dtCustomerDetails = objBusinesLead.ReadCustomerById(objEntityCustomer);
        DataTable dtContactDetails = objBusinesLead.Read_Contact_ById(objEntityCustomer);        

        if (dtCustomerDetails.Rows.Count > 0)
        {
            strArray[0] = dtCustomerDetails.Rows[0]["CSTMR_ADDRESS1"].ToString();
            strArray[1] = dtCustomerDetails.Rows[0]["CSTMR_ADDRESS2"].ToString();
            strArray[2] = dtCustomerDetails.Rows[0]["CSTMR_ADDRESS3"].ToString();
            strArray[3] = dtCustomerDetails.Rows[0]["CNTRY_NAME"].ToString();
            strArray[4] = dtCustomerDetails.Rows[0]["STATE_NAME"].ToString();
            strArray[5] = dtCustomerDetails.Rows[0]["CITY_NAME"].ToString();
            strArray[6] = dtCustomerDetails.Rows[0]["CSTMR_ZIPCODE"].ToString();
            strArray[7] = dtCustomerDetails.Rows[0]["CSTMR_TIN_NUMBER"].ToString();
            strArray[8] = dtCustomerDetails.Rows[0]["CSTMR_MOBILE"].ToString();
            strArray[9] = dtCustomerDetails.Rows[0]["CSTMR_PHONE"].ToString();
            strArray[10] = dtCustomerDetails.Rows[0]["CSTMR_EMAIL"].ToString();
            strArray[11] = dtCustomerDetails.Rows[0]["CSTMR_WEBSITE"].ToString();

            strArray[33] = dtCustomerDetails.Rows[0]["CNTRY_ID"].ToString();
            strArray[34] = dtCustomerDetails.Rows[0]["STATE_ID"].ToString();
            strArray[35] = dtCustomerDetails.Rows[0]["CITY_ID"].ToString();
        }

        if (dtContactDetails.Rows.Count > 0)
        {
            strArray[12] = dtContactDetails.Rows[0]["CSTMRCNT_NAME"].ToString();
            strArray[13] = dtContactDetails.Rows[0]["CSTMRCNT_ADDRESS"].ToString();
            strArray[14] = dtContactDetails.Rows[0]["CSTMRCNT_MOBILE"].ToString();
            strArray[15] = dtContactDetails.Rows[0]["CSTMRCNT_PHONE"].ToString();
            strArray[16] = dtContactDetails.Rows[0]["CSTMRCNT_EMAIL"].ToString();
            strArray[17] = dtContactDetails.Rows[0]["CSTMRCNT_WEBSITE"].ToString();
            strArray[30] = dtContactDetails.Rows[0]["CSTMRCNT_MAIL_ALWD"].ToString();

            if (dtContactDetails.Rows.Count > 1)
            {
                strArray[18] = dtContactDetails.Rows[1]["CSTMRCNT_NAME"].ToString();
                strArray[19] = dtContactDetails.Rows[1]["CSTMRCNT_ADDRESS"].ToString();
                strArray[20] = dtContactDetails.Rows[1]["CSTMRCNT_MOBILE"].ToString();
                strArray[21] = dtContactDetails.Rows[1]["CSTMRCNT_PHONE"].ToString();
                strArray[22] = dtContactDetails.Rows[1]["CSTMRCNT_EMAIL"].ToString();
                strArray[23] = dtContactDetails.Rows[1]["CSTMRCNT_WEBSITE"].ToString();
                strArray[31] = dtContactDetails.Rows[1]["CSTMRCNT_MAIL_ALWD"].ToString();
            }

            if (dtContactDetails.Rows.Count > 2)
            {
                strArray[24] = dtContactDetails.Rows[2]["CSTMRCNT_NAME"].ToString();
                strArray[25] = dtContactDetails.Rows[2]["CSTMRCNT_ADDRESS"].ToString();
                strArray[26] = dtContactDetails.Rows[2]["CSTMRCNT_MOBILE"].ToString();
                strArray[27] = dtContactDetails.Rows[2]["CSTMRCNT_PHONE"].ToString();
                strArray[28] = dtContactDetails.Rows[2]["CSTMRCNT_EMAIL"].ToString();
                strArray[29] = dtContactDetails.Rows[2]["CSTMRCNT_WEBSITE"].ToString();
                strArray[32] = dtContactDetails.Rows[2]["CSTMRCNT_MAIL_ALWD"].ToString();
            }

        }


        return strArray;


    }

    //select customer media details through web service
    [WebMethod]
    public static List<string[]> MeadiaDetails(string strCustomerId)
    {
        List<string[]> MediaList = new List<string[]>();

        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        clsBusinessLayerLeadCreation objBusinesLead = new clsBusinessLayerLeadCreation();
        if (strCustomerId != "--SELECT CUSTOMER/COMPANY--")
        {
            objEntityCustomer.Customer_Id = Convert.ToInt32(strCustomerId);
        }
        else {

            objEntityCustomer.Customer_Id = 0;
        }

        DataTable dtMediaDetails = objBusinesLead.Read_Media_ById(objEntityCustomer);
        if (dtMediaDetails.Rows.Count > 0)
        {
            for (int intTableRow = 0; intTableRow < dtMediaDetails.Rows.Count; intTableRow++)
            {
                string[] MediaString = new string[50];
                MediaString[0] = dtMediaDetails.Rows[intTableRow]["MEDIA_ID"].ToString();
                MediaString[1] = dtMediaDetails.Rows[intTableRow]["MEDIA_DESCRIPTION"].ToString();
                MediaList.Add(MediaString);
            }
        }
       
        return MediaList;
    }

    //protected void btnSaveProject_Click(object sender, EventArgs e)
    //{
    //    clsBusinesslayerProject objBusinessLayerPrjct = new clsBusinesslayerProject();
    //    clsEntityProject objEntityProject = new clsEntityProject();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }

       
    //   objEntityProject.Project_Status = 1;
       
    //    if (Session["USERID"] != null)
    //    {
    //        objEntityProject.User_Id = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }

    //    objEntityProject.D_Date = System.DateTime.Now;
      
    //    objEntityProject.ProjectName = txtProject.Text.ToUpper().Trim();
    //    //Checking is there table have any name like this
    //    string strNameCount = objBusinessLayerPrjct.Check_Project_Name(objEntityProject);
    //    //If there is no name like this on table.    
    //    if (strNameCount == "0")
    //    {
    //        string strPrjctId  =  objBusinessLayerPrjct.Insert_Project_Return_PrjctId(objEntityProject);
    //        ExistingProjectLoad();

    //        //  ddlExistingProject.Items.Clear();
    //        ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelProjectLoad", "UpdatePanelProjectLoad("+strPrjctId+");", true);

    //    }
    //    //If have
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationProjectClientside", "DuplicationProjectClientside();", true);
    //        txtProject.Focus();
    //    }

      
    //}

    // web method to check duplication
    [WebMethod]
    public static bool CheckDuplicationProject(string corporateId, string organisationId, string ProjectName)
    {

        //Creating objects for businesslayer
        clsBusinesslayerProject objBusinessLayerPrjct = new clsBusinesslayerProject();
        clsEntityProject objEntityPrjct = new clsEntityProject();

        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && ProjectName != null && ProjectName != "" && ProjectName != "undefined" )
        {
            objEntityPrjct.CorpOffice_Id = Convert.ToInt32(corporateId);
            objEntityPrjct.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityPrjct.ProjectName = ProjectName.ToUpper().Trim();
        
        }
        //Checking if there in table have any name like this
        string strDupCount = objBusinessLayerPrjct.Check_Project_Name(objEntityPrjct);
        //If there is no name like this on table.    
        if (strDupCount == "0")
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    protected void btnNewCust_Click(object sender, EventArgs e)
    {
        ExistingCustomerLoad();
        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewCust")
        {
            string strCustid = hiddenNewCustId.Value;
          //  string strCustid = Request["__EVENTARGUMENT"];
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelCustomerLoad", "UpdatePanelCustomerLoad(" + strCustid + ");", true);
        }
    
    }
    protected void btnNewProject_Click(object sender, EventArgs e)
    {
        ExistingProjectLoad();
     

        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewProject")
        {
            string strProjectid = hiddenNewProjectId.Value;
            //read project stage
            string strGuaranteeModeID = LoadProjectDetailsByID(strProjectid);
            //  string strCustid = Request["__EVENTARGUMENT"];
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelProjectLoad", "UpdatePanelProjectLoad(" + strProjectid + "," + strGuaranteeModeID + ");", true);
        }

    }
    //evm0012
    public string LoadProjectDetailsByID(string id)
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        objEntityLead.Project_Id =Convert.ToInt32(id);
        DataTable dtExistingProject = objBusinessLead.ReadProjectDetails(objEntityLead);
        string strGuaranteeModeID = "0";
        if (dtExistingProject.Rows.Count > 0)
        {
            strGuaranteeModeID = dtExistingProject.Rows[0]["GUARNTMODE_ID"].ToString();

        }
        return strGuaranteeModeID;
      
    }
    public string ReadProjectStatusByID(string id)
    {
        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        objEntityLead.LeadId = Convert.ToInt32(id);
        DataTable dtExistingProject = objBusinessLead.ReadProjectStatus(objEntityLead);
        string strGuaranteeModeID = "0";
        if (dtExistingProject.Rows.Count>0)
        {
            strGuaranteeModeID = dtExistingProject.Rows[0]["GUARNTMODE_ID"].ToString();
            
        }
        return strGuaranteeModeID;

    }
   
    [System.Web.Services.WebMethod]
    public static string loadProjectStatus(string strExistingPrjID)
    {
        clsBusinessLayerLeadCreation objBusinessLead = new clsBusinessLayerLeadCreation();

        clsEntityLeadCreation objEntityLead = new clsEntityLeadCreation();
        objEntityLead.Project_Id = Convert.ToInt32(strExistingPrjID);
        DataTable dtExistingProject = objBusinessLead.ReadProjectDetails(objEntityLead);
        string strGuaranteeModeID = "0";
        if (dtExistingProject.Rows.Count > 0)
        {
            strGuaranteeModeID = dtExistingProject.Rows[0]["GUARNTMODE_ID"].ToString();

        }
        return strGuaranteeModeID;


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
}