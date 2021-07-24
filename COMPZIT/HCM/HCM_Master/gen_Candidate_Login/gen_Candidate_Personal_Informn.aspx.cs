using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using CL_Compzit;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Web.Services;
using BL_Compzit.BusinessLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit.Entity_Layer_HCM;
using BL_Compzit.BusineesLayer_HCM;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Globalization;
public partial class Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn : System.Web.UI.Page
{//Functional
    #region Enumerations;
    //Enumeration for identifying apllication typeid 
    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3,
        GUARANTEE_MANAGEMENT_SYSTEM = 4

    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }

    #endregion
    clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();

    DataTable dtCorpDivVisibility = new DataTable();

    clsBusinessLayerContactDtls objBusinessEmp = new clsBusinessLayerContactDtls();
    protected void Page_Load(object sender, EventArgs e)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableConfirm = 0;

        if (!IsPostBack)
        {
           // HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            hiddenOtherUpdChk.Value = "";
            ddlEduQualification.Items.Clear();
            ddlEduQualification.Items.Insert(0, "--Select Course--");
            HiddenCurrentDatee.Value = DateTime.Now.ToString("dd-MM-yyyy");
            this.Form.Enctype = "multipart/form-data";
            //start dependent
            txtDepndtNameFM.Attributes.Add("onkeypress", "return isTag(event)");

            ddlReltnshpFM.Attributes.Add("onkeypress", "return isTag(event)");

            RelationshipLoad();
            //contact details
            txtPermAddrsSCD.Attributes.Add("onkeypress", "return isTagWithEnter(event)");
            txtEmrgCntcSCD.Attributes.Add("onkeypress", "return isTagWithEnter(event)");
            
            ddlLoctnSCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
            ddlLoctnSCD.Attributes.Add("onchange", "IncrmntConfrmCounterCD()");

            ddlSpnsrSCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
            ddlSpnsrSCD.Attributes.Add("onchange", "IncrmntConfrmCounterCD()");


            ddlRcrtdSCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
            ddlRcrtdSCD.Attributes.Add("onchange", "IncrmntConfrmCounterCD()");


            LanguageLoad();
            BloodgrpLoad();
            LoadCandidates();
            SponserLoad();
            LocationLoad();
            BindDdlMonths();
            BindDdlYears();
            //personaldetails
            txtName.Attributes.Add("onkeypress", "return isTag(event)");
            txtloccontact.Attributes.Add("onkeypress", "return isTag(event)");
            txtUsrMob.Attributes.Add("onkeypress", "return isTag(event)");
            txtUsrEmail.Attributes.Add("onkeypress", "return isTag(event)");
            txtloccontact.Attributes.Add("onkeypress", "return isTag(event)");
            ddlUsrDsgn.Attributes.Add("onkeypress", "return isTagEnter(event)");
            ddlUsrDsgn.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");

            ddlDivison.Attributes.Add("onkeypress", "return isTagEnter(event)");
            ddlDivison.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");

            ddlNationality.Attributes.Add("onkeypress", "return isTagEnter(event)");
            ddlNationality.Attributes.Add("onchange", "IncrmntConfrmCounterpd()"); //evm-0023 'IncrmntConfrmCounterpd'
            DivisionLoad();
            CountryLoad();
            // DesignationLoad();
          
            btnCnfrmPrsn.Visible = false;

            RadioAppliedNo.Checked = true;
            RBillness2.Checked = true;
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;
            clsBusinessLayerStaffImmigration objBusinessImigration = new clsBusinessLayerStaffImmigration();
            clsEntityStaffImmigration objEntityImigrationDtls = new clsEntityStaffImmigration();
            clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
            clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
            clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
            clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();
            clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
            //clsQualification
            clsEntityLayerStaffLanguage objEntityLanguage = new clsEntityLayerStaffLanguage();
            ClsBusinessLayerStaffWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerStaffWorkExperience();
            //clsQualification
            clsEntityLayerStaffWorkExperience objEntityWorkExperience = new clsEntityLayerStaffWorkExperience();

            if (RadioSponsor1.Checked == true)
            {
                ddlSpnsrSCD.Enabled = false;
            }

            else if (RadioSponsor2.Checked == true)
            {

                ddlSpnsrSCD.Enabled = false;
            }
            // clsBusinessLayer objBusiness = new clsBusinessLayer();
            //    string strCurrentDate = objBusiness.LoadCurrentDateInString();
            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                HiddenOrgId.Value = Session["ORGID"].ToString();

                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                hiddenuserid.Value = Session["USERID"].ToString();
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Request.QueryString["Id"] != null)
            {
                // lblEntry.Text = "Edit Employee";
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();

                //   lblEntry.Text = "Add Employee";
                //  ScriptManager.RegisterStartupScript(this, GetType(), "IsAdd", "IsAdd();", true);
                intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Joining_Staff);
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

                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        {
                            intEnableConfirm = 1;

                        }

                    }
                }
                if (intEnableConfirm == 1)
                {
                    divDivforHRPd.Visible = true;
                    // divDesigPd.Visible = true;
                    HiddenStaffHR.Value = "HR";
                }
                else
                {
                    HiddenStaffHR.Value = "";

                    divDivforHRPd.Visible = false;
                }
                if (intEnableConfirm != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    Response.Redirect("../../gen_Candidate_Login/gen_Candidate_Login.aspx");
                }
                //  LoadUsr();
                Divcand.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId1 = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId1);
                HiddenCandidateId.Value = strId;
                btnCnfrmPrsn.Visible = true;
                updateDepent(strId, "EDIT");
                Update_ContactDtls(strId);
                Update_PersonalDtls(strId);
                objEntityImigrationDtls.CandId = Convert.ToInt32(strId);
                objEntityImigrationDtls.CorpId = intCorpId;
                objEntityImigrationDtls.OrgId = intOrgId;
                //  HiddenCandidateId.Value = ConverstrId);
                DataTable dtImigrations = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
                // updateDepent(strId);
                updateImigrationDtls(dtImigrations);
                updateOtherDtls(strId);
                objEntityEducation.CandidateID = Convert.ToInt32(strId);
                objEntityEducation.Corporate_id = intCorpId;
                objEntityEducation.Organisation_id = intOrgId;

                DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
                string strHtmListEdu = ConvertDataTableToHTMLeductn(dtEdulist);
                divListEdu.InnerHtml = strHtmListEdu;
                objEntityLanguage.CandidateID = Convert.ToInt32(strId);
                objEntityLanguage.Corporate_id = intCorpId;
                objEntityLanguage.Organisation_id = intOrgId;

                DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
                string strHtmlLang = ConvertDataTableToHTMLlang(dtLanglist);
                divListLang.InnerHtml = strHtmlLang;
                objEntityWorkExperience.CandidateID = Convert.ToInt32(strId);
                objEntityWorkExperience.Corporate_id = intCorpId;
                objEntityWorkExperience.Organisation_id = intOrgId;

                DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
                string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
                divListWrkExp.InnerHtml = strHtmList;


            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                // lblEntry.Text = "View Employee";
                //   btnAdd.Visible = false;


                Divcand.Visible = false;

                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                // Update(strId, "VIEW");


            }
            else if (Request.QueryString["Candid"] != null)
            {
                txtName.Focus();
                ScriptManager.RegisterStartupScript(this, GetType(), "IsAdd", "IsAdd();", true);

                // lblEntry.Text = "View Employee";
                //   btnAdd.Visible = false;
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();

                intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Joining_Staff);
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

                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        {
                            intEnableConfirm = 1;

                        }

                    }
                }
                if (intEnableConfirm == 1)
                {
                    divDivforHRPd.Visible = true;
                    // divDesigPd.Visible = true;
                    //  HiddenStaffHR.Value = "HR";
                }
                else
                {
                    HiddenStaffHR.Value = "";

                    divDivforHRPd.Visible = false;
                }

                Divcand.Visible = false;

                string strRandomMixedId = Request.QueryString["Candid"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenCandidateId.Value = strId;

                Visaload();
                // Update(strId, "VIEW");

                btnUpdatepersonal.Visible = false;
                btnUpdateClosepersonal.Visible = false;
                btnUpdatePD.Visible = false;
                btnUpdateSCD.Visible = false;

                //btnUpdateDepnt.Visible = false;

                btnUpdateSCD.Visible = false;
                updateDepent(strId, "EDIT");
                Update_ContactDtls(strId);
                Update_PersonalDtls(strId);

                objEntityImigrationDtls.CandId = Convert.ToInt32(strId);
                objEntityImigrationDtls.CorpId = intCorpId;
                objEntityImigrationDtls.OrgId = intOrgId;
                //  HiddenCandidateId.Value = ConverstrId);
                DataTable dtImigrations = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
                // updateDepent(strId);
                updateImigrationDtls(dtImigrations);
                updateOtherDtls(strId);
                objEntityEducation.CandidateID = Convert.ToInt32(strId);
                objEntityEducation.Corporate_id = intCorpId;
                objEntityEducation.Organisation_id = intOrgId;

                DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
                string strHtmListEdu = ConvertDataTableToHTMLeductn(dtEdulist);
                divListEdu.InnerHtml = strHtmListEdu;
                objEntityLanguage.CandidateID = Convert.ToInt32(strId);
                objEntityLanguage.Corporate_id = intCorpId;
                objEntityLanguage.Organisation_id = intOrgId;

                DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
                string strHtmlLang = ConvertDataTableToHTMLlang(dtLanglist);
                divListLang.InnerHtml = strHtmlLang;
                objEntityWorkExperience.CandidateID = Convert.ToInt32(strId);
                objEntityWorkExperience.Corporate_id = intCorpId;
                objEntityWorkExperience.Organisation_id = intOrgId;

                DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
                string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
                divListWrkExp.InnerHtml = strHtmList;

                // Update_ContactDtls(strId);
                //  DataTable dt = objBusinessDependent.readDependentList("0");
                // DataTable dt = null;
                //  string strHtmm = ConvertDataTableToHTMLForDependent(dt);
                //  divReportforDependent.InnerHtml = strHtmm;
                ///    LoadUsr();
                // DropDownBind();
                //  objEntityImigrationDtls.CandId = 162426;
                DataTable dtImigrations1 = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
                string strHtm = ConvertDataTableToHTMLForImig(dtImigrations1);
                divImigList.InnerHtml = strHtm;
                DataTable dtEdulist1 = objBusinessEducation.readEduList(objEntityEducation);
                string strHtmListEdu1 = ConvertDataTableToHTMLeductn(dtEdulist1);
                divListEdu.InnerHtml = strHtmListEdu1;
                DataTable dtLanglist1 = objBusinessLangauage.readLangList(objEntityLanguage);
                string strHtmlLang1 = ConvertDataTableToHTMLlang(dtLanglist1);
                divListLang.InnerHtml = strHtmlLang1;
                DataTable dtlist1 = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
                string strHtmList1 = ConvertDataTableToHTMLwrkExp(dtlist1);
                divListWrkExp.InnerHtml = strHtmList1;
            }

            else
            {
                Divcand.Visible = true;
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();

                //   lblEntry.Text = "Add Employee";
                ScriptManager.RegisterStartupScript(this, GetType(), "IsAdd", "IsAdd();", true);
                intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Joining_Staff);
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

                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                        {
                            intEnableConfirm = 1;

                        }

                    }
                }
                if (intEnableConfirm == 1)
                {
                    divDivforHRPd.Visible = true;
                    // divDesigPd.Visible = true;
                    HiddenStaffHR.Value = "HR";
                }
                else
                {
                    HiddenStaffHR.Value = "";
                    divDivforHRPd.Visible = false;
                }
                if (intEnableConfirm != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    Response.Redirect("../../gen_Candidate_Login/gen_Candidate_Login.aspx");
                }
                // BtnsaveJob.Visible = false;
                //  btnAddImigrationDtls.Visible = false;
                //  btnUpdate.Visible = false;

                btnUpdatepersonal.Visible = false;
                btnUpdateClosepersonal.Visible = false;
                btnUpdatePD.Visible = false;
                btnUpdateSCD.Visible = false;

                //btnUpdateDepnt.Visible = false;

                btnUpdateSCD.Visible = false;
                clsBusinessLayerDependent objBusinessDependent1 = new clsBusinessLayerDependent();
                clsEntityLayerDependent objEntityDependent1 = new clsEntityLayerDependent();
                DataTable dt1 = objBusinessDependent1.readDependentList("0");
                // DataTable dt = null;
                string strHtmm1 = ConvertDataTableToHTMLForDependent(dt1);
                divReportforDependent.InnerHtml = strHtmm1;
                ///    LoadUsr();
                // DropDownBind();
                //objEntityImigrationDtls.CandId = Convert.ToInt32(HiddenCandidateId.Value);
                DataTable dtImigrations12 = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
                string strHtm1 = ConvertDataTableToHTMLForImig(dtImigrations12);
                divImigList.InnerHtml = strHtm1;
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Confirmation", "Confirmation();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                //code 005 start
                else if (strInsUpd == "Ipsd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFail", "MailsendFail();", true);
                }
                else if (strInsUpd == "IpRMSsd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFailReviewMailStng", "MailsendFailReviewMailStng();", true);
                }

            }



        }
        else
        {


           // updateDepent(HiddenCandidateId.Value, "");
        
        
        }

    }
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
    protected void btnAddDepnt_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
        clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDependent.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityDependent.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityDependent.EmpUserId = Convert.ToInt32(HiddenCandidateId.Value);
        objEntityDependent.Date = System.DateTime.Now;
        objEntityDependent.DepntName = txtDepndtNameFM.Text.ToUpper();
        objEntityDependent.RelatnshpId = Convert.ToInt32(ddlReltnshpFM.SelectedItem.Value);
        // objEntityDependent.oc = txtPasprtNum.Text;
        objEntityDependent.Occupation = txtOccptnFM.Text;
        if (txtAgeFM.Text != "")
        {
            objEntityDependent.DateOfBirth =objCommon.textToDateTime(txtAgeFM.Text);
        }
        objBusinessDependent.insertDependentDtls(objEntityDependent);


        DataTable dt = objBusinessDependent.readDependentList(objEntityDependent);
        DataTable dt1 = objBusinessDependent.readFamilyList(objEntityDependent);
        if (dt1.Rows.Count > 0)
        {

        }

        string strHtm = ConvertDataTableToHTMLForDependent(dt);
        divReportforDependent.InnerHtml = strHtm;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDepnt", "SuccessConfirmationDepnt();", true);

        //if (clickedButton.ID == "btnAddDepnt")
        //{
        //    btnUpdateDepnt.Visible = true;
        //    btnAddDepnt.Visible = false;
        //    btnClearDepnt.Visible = false;
        //}
    }

    protected void btnUpdateDepnt_Click(object sender, EventArgs e)
    {
        clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
        clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDependent.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityDependent.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityDependent.DepntId = Convert.ToInt32(HiddenDepntId.Value);
        objEntityDependent.Date = System.DateTime.Now;
        objEntityDependent.DepntName = txtDepndtNameFM.Text.ToUpper();
        objEntityDependent.RelatnshpId = Convert.ToInt32(ddlReltnshpFM.SelectedItem.Value);
        //  objEntityDependent.DepntPasprtNum = txtPasprtNum.Text;
        objEntityDependent.DepntName = txtDepndtNameFM.Text.ToUpper();
        objEntityDependent.RelatnshpId = Convert.ToInt32(ddlReltnshpFM.SelectedItem.Value);
        // objEntityDependent.oc = txtPasprtNum.Text;
        objEntityDependent.Occupation = txtOccptnFM.Text;
     if (txtAgeFM.Text != "")
        {
            objEntityDependent.DateOfBirth = objCommon.textToDateTime(txtAgeFM.Text);
        }
        objBusinessDependent.UpdateDependentDtls(objEntityDependent);


        //   DataTable dt = objBusinessDependent.readDependentList(objEntityDependent);
        objBusinessDependent.UpdateDependentDtls(objEntityDependent);
        objEntityDependent.EmpUserId = Convert.ToInt32(HiddenCandidateId.Value); 
        DataTable dt = objBusinessDependent.readDependentList(objEntityDependent);
        string strHtm = ConvertDataTableToHTMLForDependent(dt);
        divReportforDependent.InnerHtml = strHtm;
        updateDepent(HiddenCandidateId.Value, "");
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationDepnt", "SuccessUpdationDepnt();", true);
    }
    public string ConvertDataTableToHTMLForDependent(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableDep\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">NAME</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">RELATIONSHIP</th>";
            }



        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {




            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;




            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a class=\"tooltip\" title=\"Edit\" style=\"margin-top: -1.5%;opacity: 1;cursor: pointer;\" onclick=\"return updateDepntById('" + strId + "');\" >" +
                           "<img  style=\"margin-top: -1.5%;opacity: 1;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"margin-top: -1.5%;opacity: 1;cursor: pointer;margin-left:1%;\" onclick=\"return deleteDepntById('" + strId + "');\" >" +
                                "<img style=\"margin-top: -1.5%;opacity: 1;\" src='/Images/Icons/delete.png' /> " + "</a> </td>";

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    public void updateDepent(string id, string mode)
    {
        //btnUpdateDepnt.Visible = false;
        clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityDependent.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }


        clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
        objEntityDependent.EmpUserId = Convert.ToInt32(id);

        DataTable dt = objBusinessDependent.readDependentList(objEntityDependent);
        if (dt.Rows.Count > 0)
        {
            //  btnAddDepnt.Visible = false;
            //  btnUpdateDepnt.Visible = true;

        }
        objEntityDependent.EmpUserId = Convert.ToInt32(id);


        //DataTable dt1 = objBusinessDependent.readFamilyList(objEntityDependent);
        //string strhtm = ConvertDataTableToHTMLForDependent(dt);
        //divReportforDependent.InnerHtml = strhtm;
        //if (dt1.Rows.Count > 0)
        //{
        //    btnUpdateDepntfamily.Visible = true;
        //    btnAddDepntfamily.Visible = false;
        //    //btnClearDepntFamily.Visible = false;
        //    //  btnUpdateClosepersonal.Visible = false;
        //    //   btnAddPD.Visible = false;
        //    txtHusbandNameDP.Text = dt1.Rows[0]["STAFF_FMLY_GUARD_NAME"].ToString();
        //    txtSpouseNameDP.Text = dt1.Rows[0]["STAFF_FMLY_SPOUSE_NAME"].ToString();
        //    txtOccuDP.Text = dt1.Rows[0]["STAFF_FMLY_GUARD_OCCP"].ToString();
        //    //STAFF_FMLY_GUARD_TYP
        //    if (dt1.Rows[0]["STAFF_FMLY_GUARD_TYP"].ToString() == "0")
        //    {

        //        RbHusbandDP.Checked = true;
        //    }
        //    else if (dt1.Rows[0]["STAFF_FMLY_GUARD_TYP"].ToString() == "1")
        //    {
        //        RbFatherDP.Checked = true;

        //    }
        //    else
        //    {
        //        RbNoneDP.Checked = true;
        //    }


        //    if (dt1.Rows[0]["STAFF_FMLY_MRG_STS"].ToString() == "0")
        //    {

        //        // RbMaritalStatusDP2.Checked = true;
        //        rblMarrStatus.Items.FindByValue(dt1.Rows[0]["STAFF_FMLY_MRG_STS"].ToString()).Selected = true;
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ShowHidespouse", "ShowHidespouse();", true);

        //        rblMarrStatus.SelectedValue = "0";
        //    }
        //    else
        //    {
        //        rblMarrStatus.Items.FindByValue(dt1.Rows[0]["STAFF_FMLY_MRG_STS"].ToString()).Selected = true;
            
        //     //   rblMarrStatus.SelectedValue = "1";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "ShowHidespouse", "ShowHidespouse();", true);

             
           
        //    }

        //    btnClearDepntFamily.Visible = false;
        //    //   btnUpdateDepntfamily.Visible = true;
        //}
        //else {
        //  //  btnUpdateDepntfamily.Visible = false;
        //    btnUpdateDepntfamily.Visible = false;
        //    btnAddDepntfamily.Visible = true;
          
        //}
    }
    public class Dependent
    {
        public string Name = "";
        public int reltnshpId = 0;
        public string occupation = "";
        public string age = "";
        public string reltnshpStsId = "";
        public string reltnshpName = "";
        public string pasprtNum = "";
        public string pasprtExpDate = "";
        public string RpNum = "";
        public string RpIssDate = "";
        public string RpExpDate = "";
        public string strDepntLIst = "";
        public string ConvertDataTableToHTML(DataTable dt)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableDep\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (i == 0)
                //{
                //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">NAME</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">RELATIONSHIP</th>";
                }



            }


            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {




                strHtml += "<tr  >";



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    //if (j == 0)
                    //{
                    //    int intCnt = i + 1;
                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                    //}
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;




                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a class=\"tooltip\" title=\"Edit\" style=\"margin-top: -1.5%;opacity: 1;cursor: pointer;\" onclick=\"return updateDepntById('" + strId + "');\" >" +
                               "<img  style=\"margin-top: -1.5%;opacity: 1;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Delete\" style=\"margin-top: -1.5%;opacity: 1;cursor: pointer;margin-left:1%;\" onclick=\"return deleteDepntById('" + strId + "');\" >" +
                                    "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }

    }
    [WebMethod]
    public static Dependent ReadDepntDtlById(string Id)
    {
        Dependent objDepnt = new Dependent();

        clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
        clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
        objEntityDependent.DepntId = Convert.ToInt32(Id);
        objEntityDependent.DepntId = Convert.ToInt32(Id);
        DataTable dt = objBusinessDependent.ReadDepntById(objEntityDependent);
        if (dt.Rows.Count > 0)
        {

            objDepnt.Name = dt.Rows[0]["STAFF_DPNT_NAME"].ToString();
            objDepnt.reltnshpId = Convert.ToInt32(dt.Rows[0]["RELATE_ID"].ToString());
            objDepnt.occupation = dt.Rows[0]["STAFF_DPNT_OCCUPATION"].ToString();
            if (dt.Rows[0]["STAFF_DPNT_DT_BIRTH"].ToString() == "")
                objDepnt.age = "";
            else
                objDepnt.age = dt.Rows[0]["STAFF_DPNT_DT_BIRTH"].ToString();

            objDepnt.reltnshpStsId = dt.Rows[0]["RELATE_STATUS"].ToString();
            objDepnt.reltnshpName = dt.Rows[0]["RELATE_NAME"].ToString();

        }
        return objDepnt;
    }
    [WebMethod]
    public static Dependent deleteDepntDtlById(string Id, string empId, int CorpId, int Orgid)
    {
        Dependent objDepnt = new Dependent();
        clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
        clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
        objEntityDependent.DepntId = Convert.ToInt32(Id);
        objEntityDependent.Date = System.DateTime.Now;
        objBusinessDependent.DeleteDepntById(objEntityDependent);
        objEntityDependent.Corporate_id = CorpId;
        objEntityDependent.Organisation_id = Orgid;
        objEntityDependent.EmpUserId = Convert.ToInt32(empId);
        DataTable dt = objBusinessDependent.readDependentList(objEntityDependent);
        objDepnt.strDepntLIst = objDepnt.ConvertDataTableToHTML(dt);
        return objDepnt;
    }

    public void LocationLoad()
    {
        ClsEntity_Staff_Contact_Details objEntityContactDtls = new ClsEntity_Staff_Contact_Details();



        Cls_Business_Staff_Contact_Details objBusinessContactDtls = new Cls_Business_Staff_Contact_Details();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityContactDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityContactDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityContactDtls.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessContactDtls.ReadAccomdationn(objEntityContactDtls);
        if (dtDivision.Rows.Count > 0)
        {
            ddlLoctnSCD.Items.Clear();
            ddlLoctnSCD.DataSource = dtDivision;


            ddlLoctnSCD.DataValueField = "ACCMDTN_ID";
            ddlLoctnSCD.DataTextField = "ACCMDTN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlLoctnSCD.DataBind();

        }
        ddlLoctnSCD.Items.Insert(0, "--SELECT LOCATION--");

    }

    public void SponserLoad()
    {
        ClsEntity_Staff_Contact_Details objEntityContactDtls = new ClsEntity_Staff_Contact_Details();



        Cls_Business_Staff_Contact_Details objBusinessContactDtls = new Cls_Business_Staff_Contact_Details();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityContactDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityContactDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityContactDtls.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessContactDtls.ReadSponser(objEntityContactDtls);
        if (dtDivision.Rows.Count > 0)
        {
            ddlSpnsrSCD.Items.Clear();
            ddlSpnsrSCD.DataSource = dtDivision;


            ddlSpnsrSCD.DataValueField = "SPSNSR_ID";
            ddlSpnsrSCD.DataTextField = "SPNSR_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlSpnsrSCD.DataBind();

        }
        ddlSpnsrSCD.Items.Insert(0, "--SELECT SPONSER--");

    }
    protected void btnAddCloseSCD_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;


        clsCommonLibrary objCommon = new clsCommonLibrary();

        ClsEntity_Staff_Contact_Details objEntityContactDtls = new ClsEntity_Staff_Contact_Details();



        Cls_Business_Staff_Contact_Details objBusinessContactDtls = new Cls_Business_Staff_Contact_Details();
        //clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();
        //clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityContactDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityContactDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityContactDtls.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityContactDtls.CandidadteId = Convert.ToInt32(HiddenCandidateId.Value);

        // string strcount = objBusinessPersonalDtls.checkEmpId(objEntityPersonalDtls);


        // objEntityPersonalDtls.EmpUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityContactDtls.Date = System.DateTime.Now;
        // objEntityPersonalDtls.Fname = txtFName.Text.ToUpper().Trim();
        //  objEntityPersonalDtls.Mname = txtMName.Text.ToUpper().Trim();
        //  objEntityPersonalDtls.Lname = txtLName.Text.ToUpper().Trim();
        objEntityContactDtls.StaffPermanentAdd = txtPermAddrsSCD.Text.Trim();

        objEntityContactDtls.EmergencyContact = txtEmrgCntcSCD.Text.Trim();

        //  objEntityPersonalDtls.CountryID = Convert.ToInt32(ddlNationality.SelectedItem.Value);

        //objEntityPersonalDtls.ReligionId = Convert.ToInt32(ddlReligion.SelectedItem.Value);
        // objEntityPersonalDtls.DOB = objCommon.textToDateTime(TxtDOB.Text);
        //objEntityPersonalDtls.BloodGrpId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);


        if (ddlLoctnSCD.SelectedItem.Value == "--SELECT LOCATION--")  //EMP17
        {
            objEntityContactDtls.Accomdation = 0;
        }
        else
        {
            objEntityContactDtls.Accomdation = Convert.ToInt32(ddlLoctnSCD.SelectedItem.Value);

        }

        if (RadioSponsor1.Checked == true)
        {
            if (ddlSpnsrSCD.SelectedItem.Value != "--SELECT SPONSER--")
            {

                objEntityContactDtls.Sponser = Convert.ToInt32(ddlSpnsrSCD.SelectedItem.Value);
            }
        }

        else if (RadioSponsor2.Checked == true)
        {
                objEntityContactDtls.Sponser = 0;
                ddlSpnsrSCD.Enabled = false;
        }
        //EMP17
        if (ddlRcrtdSCD.SelectedItem.Value == "--SELECT REFERENCE--")
        {
            objEntityContactDtls.Recruted = 0;

        }
        else
        {


            objEntityContactDtls.Recruted = Convert.ToInt32(ddlRcrtdSCD.SelectedItem.Value);

        }

        objBusinessContactDtls.insertContactDetails(objEntityContactDtls);
        Update_ContactDtls(HiddenCandidateId.Value);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationCD", "SuccessConfirmationCD();", true);



    }
    protected void btnUpdateSCD_Click(object sender, EventArgs e)
    {
        ClsEntity_Staff_Contact_Details objEntityContactDtls = new ClsEntity_Staff_Contact_Details();



        Cls_Business_Staff_Contact_Details objBusinessContactDtls = new Cls_Business_Staff_Contact_Details();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityContactDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityContactDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityContactDtls.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityContactDtls.CandidadteId = Convert.ToInt32(HiddenCandidateId.Value);


        objEntityContactDtls.Date = System.DateTime.Now;
        // objEntityPersonalDtls.Fname = txtFName.Text.ToUpper().Trim();
        //  objEntityPersonalDtls.Mname = txtMName.Text.ToUpper().Trim();
        //  objEntityPersonalDtls.Lname = txtLName.Text.ToUpper().Trim();
        objEntityContactDtls.StaffPermanentAdd = txtPermAddrsSCD.Text.Trim();

        objEntityContactDtls.EmergencyContact = txtEmrgCntcSCD.Text.Trim();

        //  objEntityPersonalDtls.CountryID = Convert.ToInt32(ddlNationality.SelectedItem.Value);

        //objEntityPersonalDtls.ReligionId = Convert.ToInt32(ddlReligion.SelectedItem.Value);
        // objEntityPersonalDtls.DOB = objCommon.textToDateTime(TxtDOB.Text);
        //objEntityPersonalDtls.BloodGrpId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);


        if (ddlLoctnSCD.SelectedItem.Value == "--SELECT LOCATION--")  //EMP17
        {
            objEntityContactDtls.Accomdation = 0;
        }
        else
        {
            objEntityContactDtls.Accomdation = Convert.ToInt32(ddlLoctnSCD.SelectedItem.Value);

        }


        if (RadioSponsor1.Checked == true)
        {
            if (ddlSpnsrSCD.SelectedItem.Value != "--SELECT SPONSER--")
            {
                objEntityContactDtls.Sponser = Convert.ToInt32(ddlSpnsrSCD.SelectedItem.Value);
            }
        }
        else if (RadioSponsor2.Checked == true)
        {
            objEntityContactDtls.Sponser = 0;
            ddlSpnsrSCD.Enabled = false;
        } //EMP17
        if (ddlRcrtdSCD.SelectedItem.Value == "--SELECT REFERENCE--")
        {
            objEntityContactDtls.Recruted = 0;

        }
        else
        {


            objEntityContactDtls.Recruted = Convert.ToInt32(ddlRcrtdSCD.SelectedItem.Value);

        }   //EMP17



        objBusinessContactDtls.UpdateContactDetails(objEntityContactDtls);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationCD", "SuccessUpdationCD();", true);


    }



    public void Update_ContactDtls(string strP_Id)
    {
        btnAddSCD.Visible = true;
        //btnAddClose.Visible = false;
        btnUpdateSCD.Visible = false;
        //btnUpdateClose.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableModify = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0;
        ClsEntity_Staff_Contact_Details objEntityContactDtls = new ClsEntity_Staff_Contact_Details();



        Cls_Business_Staff_Contact_Details objBusinessContactDtls = new Cls_Business_Staff_Contact_Details();
        if (Session["USERID"] != null)
        {
            objEntityContactDtls.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityContactDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityContactDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (intEnableModify == 1)
        {
            btnUpdateSCD.Visible = true;
            //btnUpdateClose.Visible = true;

            if (intEnableAdd == 0)
                btnUpdateSCD.Visible = false;
        }




        objEntityContactDtls.CandidadteId = Convert.ToInt32(strP_Id.ToString());


        DataTable dtcontactdetails = objBusinessContactDtls.ReadContactDetailsId(objEntityContactDtls);

        if (dtcontactdetails.Rows.Count > 0)
        {
            btnAddSCD.Visible = false;
            HiddenMasterid.Value = dtcontactdetails.Rows[0]["STAFF_CNT_ID"].ToString();
            HiddenDepntId.Value = dtcontactdetails.Rows[0]["STAFF_CNT_ID"].ToString();
            btnClearSCD.Visible = false;
            btnUpdateSCD.Visible = true;

            btnAddSCD.Visible = false;
            txtPermAddrsSCD.Text = dtcontactdetails.Rows[0]["STAFF_CNT_PR_ADDR"].ToString();

            txtEmrgCntcSCD.Text = dtcontactdetails.Rows[0]["STAFF_CNT_EMR_CNT"].ToString();

            if (dtcontactdetails.Rows[0]["SPSNSR_ID"].ToString() != null)
            {


                RadioSponsor1.Checked = true;
                RadioSponsor2.Checked = false;
                ddlSpnsrSCD.Enabled = true;
            }
            else
            {
                RadioSponsor1.Checked = false;
                RadioSponsor2.Checked = true;
                ddlSpnsrSCD.Enabled = false;
            }


            if (dtcontactdetails.Rows[0]["ACCMDTN_ID"].ToString() != "")
            {
                if (ddlLoctnSCD.Items.FindByValue(dtcontactdetails.Rows[0]["ACCMDTN_ID"].ToString()) != null)
                {
                    ddlLoctnSCD.ClearSelection();
                    ddlLoctnSCD.Items.FindByValue(dtcontactdetails.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtcontactdetails.Rows[0]["ACCMDTN_NAME"].ToString(), dtcontactdetails.Rows[0]["ACCMDTN_ID"].ToString());
                    ddlLoctnSCD.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlLoctnSCD);

                    ddlLoctnSCD.Items.FindByValue(dtcontactdetails.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }
            }
            //  ddlDesignation.Items.FindByValue(dtcontactdetails.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
            if (dtcontactdetails.Rows[0]["STAFF_CNT_REFF"].ToString() != "")
            {
                if (ddlRcrtdSCD.Items.FindByValue(dtcontactdetails.Rows[0]["STAFF_CNT_REFF"].ToString()) != null)
                {
                    ddlRcrtdSCD.ClearSelection();
                    ddlRcrtdSCD.Items.FindByValue(dtcontactdetails.Rows[0]["STAFF_CNT_REFF"].ToString()).Selected = true;
                }

            }
            if (dtcontactdetails.Rows[0]["SPSNSR_ID"].ToString() != "")
            {
                if (ddlSpnsrSCD.Items.FindByValue(dtcontactdetails.Rows[0]["SPSNSR_ID"].ToString()) != null)
                {
                    ddlSpnsrSCD.ClearSelection();
                    ddlSpnsrSCD.Items.FindByValue(dtcontactdetails.Rows[0]["SPSNSR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtcontactdetails.Rows[0]["SPNSR_NAME"].ToString(), dtcontactdetails.Rows[0]["SPSNSR_ID"].ToString());
                    ddlSpnsrSCD.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlSpnsrSCD);

                    ddlSpnsrSCD.Items.FindByValue(dtcontactdetails.Rows[0]["SPSNSR_ID"].ToString()).Selected = true;
                }
            }

            //if (dtMnpwrrMstr.Rows[0]["MNP_PROJID"] != DBNull.Value||dtMnpwrrMstr.Rows[0]["MNP_PROJID"] != "")
            // {
            // ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
            // }

            //txtnoEmpInSamepos.Text = dtMnpwrrMstr.Rows[0]["MNP_EXPERIENCE"].ToString();



            // }
            // }

            //  objBusinessManpowerDetails.AddManpowerRecruitment(ObjEntityManpowerRecruitment);
         
        }
    }
    protected void btnAddPersnl_Click(object sender, EventArgs e)
    {
        //getting the next value
        Button clickedButton = sender as Button;


        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();



        ClsBusinessStaffPersonalDtls objBusinessPersonalDtls = new ClsBusinessStaffPersonalDtls();
        //clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();
        //clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPersonalDtls.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (ddlCandidateName.SelectedItem.Value != "--SELECT CANDIDATE--")
        {

            HiddenCandidateId.Value = ddlCandidateName.SelectedItem.Value;


        }
        if (HiddenCandidateId.Value == "")
        {
        }
        else
            objEntityPersonalDtls.CandidadteId = Convert.ToInt32(HiddenCandidateId.Value);
        // HiddenCandidateId.Value = ddlCandidateName.SelectedItem.Value;
        // string strcount = objBusinessPersonalDtls.checkEmpId(objEntityPersonalDtls);

        // objEntityPersonalDtls.EmpUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityPersonalDtls.Date = System.DateTime.Now;
        // objEntityPersonalDtls.Fname = txtFName.Text.ToUpper().Trim();
        //  objEntityPersonalDtls.Mname = txtMName.Text.ToUpper().Trim();
        //  objEntityPersonalDtls.Lname = txtLName.Text.ToUpper().Trim();
        objEntityPersonalDtls.StaffName = txtName.Text.Trim();

        objEntityPersonalDtls.LocalContact = txtloccontact.Text.Trim();

        //  objEntityPersonalDtls.CountryID = Convert.ToInt32(ddlNationality.SelectedItem.Value);
        objEntityPersonalDtls.TelaephoneNmbr = txtUsrMob.Text.Trim();
        //objEntityPersonalDtls.ReligionId = Convert.ToInt32(ddlReligion.SelectedItem.Value);
        // objEntityPersonalDtls.DOB = objCommon.textToDateTime(TxtDOB.Text);
        //objEntityPersonalDtls.BloodGrpId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);
        objEntityPersonalDtls.emailid = txtUsrEmail.Text.Trim();

       // if (ddlUsrDsgn.SelectedItem.Value != "--SELECT DESIGNATION--")  //EMP17
       // {
        //    objEntityPersonalDtls.designationId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
        //}
       // else
       // {
            objEntityPersonalDtls.designationId = 0;
       // }

            if (TxtFirstName.Text != "")
            {
                objEntityPersonalDtls.Firstname = TxtFirstName.Text.Trim();
            }
            if (TxtMiddleName.Text != "")
            {
                objEntityPersonalDtls.Middlename = TxtMiddleName.Text.Trim();
            }
            if (TxtLastName.Text != "")
            {
                objEntityPersonalDtls.Lastname = TxtLastName.Text.Trim();
            }
        if (ddlNationality.SelectedItem.Value != "--SELECT NATIONALITY--")
        {

            objEntityPersonalDtls.country = Convert.ToInt32(ddlNationality.SelectedItem.Value);
        }
        else
        {
            objEntityPersonalDtls.country = 0;
        }   //EMP17
        if (ddlDivison.SelectedItem.Value != "--SELECT DIVISION--")
        {

            objEntityPersonalDtls.crprtdivision = Convert.ToInt32(ddlDivison.SelectedItem.Value);
        }
        else
        {
            objEntityPersonalDtls.crprtdivision = 0;
        }   //EMP17

        ddlCandidateName.Enabled = false;
        objBusinessPersonalDtls.insertPersonalDtls(objEntityPersonalDtls);

        if (clickedButton.ID == "btnAddpersonal")
        {
            btnAddClosepersonal.Visible = false;
            btnAddpersonal.Visible = false;
            btnUpdatepersonal.Visible = true;
            btnUpdateClosepersonal.Visible = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "Notadd", "Notadd();", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPD", "SuccessConfirmationPD();", true);
        }
        else if (clickedButton.ID == "btnAddClosepersonal")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPD", "SuccessConfirmationPD();", true);
        }

        // Update_PersonalDtls(HiddenCandidateId.Value.ToString());




    }
    public void DivisionLoad()
    {
        clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();



        ClsBusinessStaffPersonalDtls objBusinessPersonalDtls = new ClsBusinessStaffPersonalDtls();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityPersonalDtls.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessPersonalDtls.ReadDivision(objEntityPersonalDtls);
        if (dtDivision.Rows.Count > 0)
        {
            ddlDivison.Items.Clear();
            ddlDivison.DataSource = dtDivision;


            ddlDivison.DataValueField = "CPRDIV_ID";
            ddlDivison.DataTextField = "CPRDIV_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDivison.DataBind();

        }
        ddlDivison.Items.Insert(0, "--SELECT DIVISION--");

    }
    public void CountryLoad()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.readCountry();
        // HiddenFieldCbxCount.Value = dtCountry.Rows.Count.ToString();
        ddlNationality.Items.Clear();
        ddlNationality.DataSource = dtCountry;

        ddlNationality.DataTextField = "CNTRY_NAME";
        ddlNationality.DataValueField = "CNTRY_ID";
        ddlNationality.DataBind();
        ddlNationality.Items.Insert(0, "--SELECT NATIONALITY--");
        // chkbxListCountry.Items.Insert(0, "--ANY--");
    }


    public void DesignationLoad()
    {
        ClsBusinessStaffPersonalDtls objBusinessPersonaldtls = new ClsBusinessStaffPersonalDtls();
        clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityPersonalDtls.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdesig = objBusinessPersonaldtls.ReadDesignation(objEntityPersonalDtls);
        if (dtdesig.Rows.Count > 0)
        {
            ddlUsrDsgn.Items.Clear();
            ddlUsrDsgn.DataSource = dtdesig;


            ddlUsrDsgn.DataValueField = "DSGN_ID";
            ddlUsrDsgn.DataTextField = "DSGN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlUsrDsgn.DataBind();

        }
        ddlUsrDsgn.Items.Insert(0, "--SELECT DESIGNATION--");

    }


    public void Update_PersonalDtls(string strP_Id)
    {
        
        btnUpdateClosepersonal.Visible = false;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableModify = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0;
        ClsBusinessStaffPersonalDtls objBusinessPersonaldtls = new ClsBusinessStaffPersonalDtls();
        clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();
        if (Session["USERID"] != null)
        {
            objEntityPersonalDtls.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (intEnableModify == 1)
        {
            // btnUpdate.Visible = true;
            //  btnUpdateClose.Visible = true;

            // if (intEnableAdd == 0)
            //btnUpdate.Visible = false;
        }




        objEntityPersonalDtls.CandidadteId = Convert.ToInt32(strP_Id.ToString());


        DataTable dtMnpwrrMstr = objBusinessPersonaldtls.ReadPersonalDetailsId(objEntityPersonalDtls);

        if (dtMnpwrrMstr.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Notadd", "Notadd();", true);

            ddlCandidateName.Visible = false;
            btnUpdateClosepersonal.Visible = true;
            btnUpdatepersonal.Visible = true;
            btnAddClosepersonal.Visible = false;
            btnAddpersonal.Visible = false;
            HiddenMasterid.Value = dtMnpwrrMstr.Rows[0]["STAFF_PR_ID"].ToString();


            txtName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_NAME"].ToString();

            txtloccontact.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_LCL_CNT_NUM"].ToString();

            txtUsrMob.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_TELE"].ToString();

            txtUsrEmail.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_EMAIL"].ToString();
            TxtFirstName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_FNAME"].ToString();
            TxtMiddleName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_MNAME"].ToString();
            TxtLastName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_LNAME"].ToString();

            if (dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString() != "")
            {
                //if (ddlUsrDsgn.Items.FindByValue(dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString()) != null)
               // {
                   // ddlUsrDsgn.Items.FindByValue(dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString()).Selected = true;
               // }
               // else
               // {
                 //   ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["DSGN_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString());
                  ///  ddlUsrDsgn.Items.Insert(1, lstGrp);

                   // SortDDL(ref this.ddlUsrDsgn);

                    ///ddlUsrDsgn.Items.FindByValue(dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                //}
            }
            //  ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
            if (dtMnpwrrMstr.Rows[0]["CPRDIV_ID"].ToString() != "")
            {
                if (ddlDivison.Items.FindByValue(dtMnpwrrMstr.Rows[0]["CPRDIV_ID"].ToString()) != null)
                {
                    ddlDivison.Items.FindByValue(dtMnpwrrMstr.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CPRDIV_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivison.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivison);

                    ddlDivison.Items.FindByValue(dtMnpwrrMstr.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
            }
            if (dtMnpwrrMstr.Rows[0]["CNTRY_ID"].ToString() != "")
            {
                if (ddlNationality.Items.FindByValue(dtMnpwrrMstr.Rows[0]["CNTRY_ID"].ToString()) != null)
                {
                    ddlNationality.Items.FindByValue(dtMnpwrrMstr.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CNTRY_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["CNTRY_ID"].ToString());
                    ddlNationality.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlNationality);

                    ddlNationality.Items.FindByValue(dtMnpwrrMstr.Rows[0]["CNTRY_ID"].ToString()).Selected = true;
                }
            }


        }


    }

    protected void btnUpdatePersonalDtls_Click(object sender, EventArgs e)
    {
        int intCorpId, intOrgId;
        ClsBusinessStaffPersonalDtls objBusinessPersonaldtls = new ClsBusinessStaffPersonalDtls();
        clsEntityStaffPersonalDtls objEntityPersonalDtls = new clsEntityStaffPersonalDtls();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityPersonalDtls.corpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityPersonalDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityPersonalDtls.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityPersonalDtls.CandidadteId = Convert.ToInt32(HiddenCandidateId.Value);

        // objEntityPersonalDtls.StaffId = Convert.ToInt32(HiddenMasterid.Value);


        objEntityPersonalDtls.Date = System.DateTime.Now;

        objEntityPersonalDtls.StaffName = txtName.Text.Trim();

        objEntityPersonalDtls.LocalContact = txtloccontact.Text.Trim();


        objEntityPersonalDtls.TelaephoneNmbr = txtUsrMob.Text.Trim();

        objEntityPersonalDtls.emailid = txtUsrEmail.Text.Trim();
        if (TxtFirstName.Text != "")
        {
            objEntityPersonalDtls.Firstname = TxtFirstName.Text.Trim();
        }
        if (TxtMiddleName.Text != "")
        {
            objEntityPersonalDtls.Middlename = TxtMiddleName.Text.Trim();
        }
        if (TxtLastName.Text != "")
        {
            objEntityPersonalDtls.Lastname = TxtLastName.Text.Trim();
        }
        //if (ddlUsrDsgn.SelectedItem.Text == "--SELECT DESIGNATION--")
        //{
            objEntityPersonalDtls.designationId = 0;
       // }
       // else
       // {

        //    objEntityPersonalDtls.designationId = Convert.ToInt32(ddlUsrDsgn.SelectedValue);
       // }

        if (ddlNationality.SelectedItem.Text == "--SELECT NATIONALITY--")
        {
            objEntityPersonalDtls.country = 0;
        }
        else
        {

            objEntityPersonalDtls.country = Convert.ToInt32(ddlNationality.SelectedValue);
        }

        if (ddlDivison.SelectedItem.Text == "--SELECT DIVISION--")
        {
            objEntityPersonalDtls.crprtdivision = 0;
        }
        else
        {

            objEntityPersonalDtls.crprtdivision = Convert.ToInt32(ddlDivison.Text);
        }
        objBusinessPersonaldtls.UpdatepersonalDetails(objEntityPersonalDtls);


        Button clickedButton = sender as Button;
        if (clickedButton.ID == "btnUpdatepersonal")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPD", "SuccessUpdationPD();", true);
        }
        else if (clickedButton.ID == "btnUpdateClosepersonal")
        {
            Response.Redirect("../gen_Candidate_Login/gen_Candidate_Login.aspx");
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPD", "SuccessUpdationPD();", true);
        }
    }



    public void RelationshipLoad()
    {
        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        DataTable dtCountry = objBusinessDependent.ReadRelationship();
        ddlReltnshpFM.Items.Clear();
        ddlReltnshpFM.DataSource = dtCountry;
        ddlReltnshpFM.DataTextField = "RELATE_NAME";
        ddlReltnshpFM.DataValueField = "RELATE_ID";
        ddlReltnshpFM.DataBind();
        ddlReltnshpFM.Items.Insert(0, "--Select Relationship--");
    }

    //Immigration
    public void updateImigrationDtls(DataTable dtImigrations)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "show_updatebutton", "show_updatebutton();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "hide_saveebutton", "hide_saveebutton();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "hide_clearbutton", "hide_clearbutton();", true);


        //btnUpdateImigrationDtls.Visible = true;
        //  btnAddImigrationDtls.Visible = false;
        // btnClear.Visible = false;

        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        //// objEntityImigrationDtls.Imig_Id = Convert.ToInt32(id);
        // if (Session["CORPOFFICEID"] != null)
        // {
        //     objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        // }
        // else if (Session["CORPOFFICEID"] == null)
        // {
        //     Response.Redirect("~/Default.aspx");
        // }
        // if (Session["ORGID"] != null)
        // {
        //     objEntityImigrationDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        // }
        // else if (Session["ORGID"] == null)
        // {
        //     Response.Redirect("~/Default.aspx");
        // }
        // if (Session["USERID"] != null)
        // {
        //     objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        // }
        // else
        // {
        //     Response.Redirect("~/Default.aspx");
        // }
        // DataTable dt = objBusinessImigration.ReadImmigrationById(objEntityImigrationDtls);
        // RadioButtonDocList.SelectedValue = dtImigrations.Rows[0]["EMPIMG_DOC_TYPEID"].ToString();
        /// DataTable dtImigrations = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);//2emp17
        string strHtm = ConvertDataTableToHTMLImmigration(dtImigrations);//2emp17

        divImigList.InnerHtml = strHtm;
        // objimmigrationtls.strhtml = strHtm;

        //if (dtImigrations.Rows.Count > 0)
        //{
        //    // btnUpdateImigrationDtls.Visible = true;
        //    txtVisaExpDate.Text = dtImigrations.Rows[0]["VISA EXPIRY DATE"].ToString();
        //    TextPass.Text = dtImigrations.Rows[0]["PASSPORT NUMBER"].ToString();
        //    TextVisa.Text = dtImigrations.Rows[0]["VISA NAME"].ToString();
        //    txtPassExpDate.Text = dtImigrations.Rows[0]["PASSPORT EXIPRY DATE"].ToString();
        //   // Ddlvisatype.Text = dtImigrations.Rows[0]["VISATYP_ID"].ToString();
        //    //    TxtComments.Text = dtImigrations.Rows[0]["EMPIMG_DOC_COMMENTS"].ToString();
        //    //ie IF  COUNTRY IS ACTIVE
        //    Visaload();
        //    if (dtImigrations.Rows[0]["VISATYP_ID"].ToString() != null)
        //    {
        //        Ddlvisatype.Items.FindByText(dtImigrations.Rows[0]["VISATYP_ID"].ToString()).Selected = true;

        //    }



    }
    public string ConvertDataTableToHTMLImmigration(DataTable dt)
    {

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        //  clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        //clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableImgrtn\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        int intReCallForTAble = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            string CnclUsrId = dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString();
            if (CnclUsrId != "")
            {
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                if (intCnclUsrId != 0)
                {
                    intReCallForTAble = 1;
                }
            }



        }
        strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">SL#</th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)9
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {

                strHtml += "<th class=\"thT\" style=\"width:2%; word-wrap:break-word;text-align: center;\">EDIT </th>";
            }
            else if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:2%; word-wrap:break-word;text-align: center;\">DELETE</th>";

            }

        }


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int User_Id = 1;
            // int id = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPIMG_ID"]);
            //if (Session["USERID"] != null)
            //{
            //    User_Id = Convert.ToInt32(Session["USERID"]);
            //}
            //else if (Session["USERID"] == null)
            //{
            //    Response.Redirect("/Default.aspx");
            //}

            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
            string Id = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();
            int slno = intRowBodyCount + 1;
            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>"; //3emp17

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                string strVisa = dt.Rows[intRowBodyCount]["STAFF_VISA_TYP_ID"].ToString();
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + strVisa + "');\" >" + "<img   src='/Images/Icons/edit.png' /> " + "</a> </td>";  //3emp17

                }

                else if (intColumnBodyCount == 7)
                {



                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1%;margin-left:1% \"onclick=\"return DeleteImigrationByid('" + Id + "','" + strVisa + "');\" >" + "<img   src='/Images/Icons/delete.png' /> " + "</a> </td>";      //3emp17

                }   //3emp17

                //    int id;



            }
            strHtml += "</tr>";

        }
        strHtml += "</tbody>";

        strHtml += "</table>";







        sb.Append(strHtml);
        return sb.ToString();
    }








    public void Visaload()
    {
        clsBusinessLayerImmigration objBusinessImmigdtls = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImigrationDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityImigrationDtls.Imig_Emp_id=Convert.ToInt32(HiddenCandidateId.Value);
        Ddlvisatype.Items.Clear();
        DataTable dtVisatype = objBusinessImmigdtls.Read_Visa_ById(objEntityImigrationDtls);
        Ddlvisatype.DataSource = dtVisatype;
        Ddlvisatype.DataTextField = "VISA_NAME";
        Ddlvisatype.DataValueField = "VISATYP_ID";
        Ddlvisatype.DataBind();
        Ddlvisatype.Items.Insert(0, "--Select Visa Type--");



    }



    protected void btnAddStaffImigrationDtls_Click(object sender, EventArgs e)
    {
        int intuserid = 0;
        clsBusinessLayerStaffImmigration objBusinessImigration = new clsBusinessLayerStaffImmigration();
        clsEntityStaffImmigration objEntityImigrationDtls = new clsEntityStaffImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImigrationDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intuserid = Convert.ToInt32(Session["USERID"].ToString());
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityImigrationDtls.CandId = Convert.ToInt32(HiddenCandidateId.Value);

        if (Ddlvisatype.Text == "--Select Visa Type--")
        {
            objEntityImigrationDtls.intVisaTypeID = 0;

        }
        else
        {
            objEntityImigrationDtls.intVisaTypeID = Convert.ToInt32(Ddlvisatype.SelectedValue);
        }

        objEntityImigrationDtls.VisaNo = TextVisa.Text;

        if (txtVisaExpDate.Text == "")
        {
            objEntityImigrationDtls.VisaExpDate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.VisaExpDate = objCommon.textToDateTime(txtVisaExpDate.Text);
        }

        objEntityImigrationDtls.PassNo = TextPass.Text;

        if (txtPassExpDate.Text == "")
        {
            objEntityImigrationDtls.PassExpDate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.PassExpDate = objCommon.textToDateTime(txtPassExpDate.Text);
        }

        objEntityImigrationDtls.UsrInsdate = DateTime.Now;
        objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(Session["USERID"].ToString());

        objBusinessImigration.AddStaffImmigration(objEntityImigrationDtls);

        DataTable dtImigrationDtls = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
        string strhtm = ConvertDataTableToHTMLForImig(dtImigrationDtls);
        divImigList.InnerHtml = strhtm;
        ScriptManager.RegisterStartupScript(this, GetType(), "ImigSuccessConfirmation", "ImigSuccessConfirmation();", true);

    }

    public string ConvertDataTableToHTMLForImig(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableImgrtn\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName.ToUpper() + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName.ToUpper() + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName.ToUpper() + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName.ToUpper() + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName.ToUpper() + "</th>";
            }



        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {




            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                string id = dt.Rows[intRowBodyCount]["CAND_ID"].ToString(); ;
                string strVisa = dt.Rows[intRowBodyCount]["STAFF_VISA_TYP_ID"].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");

                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + id + "','" + strVisa + "');\" >" + "<img   src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }

                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1%;margin-left:1% \"onclick=\"return DeleteImigrationByid('" + id + "','" + strVisa + "');\" >" + "<img   src='/Images/Icons/delete.png' /> " + "</a> </td>";
                }


            } strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    protected void btnUpdateStaffImigrationDtls_Click(object sender, EventArgs e)
    {

        int intuserid = 0;
        clsBusinessLayerStaffImmigration objBusinessImigration = new clsBusinessLayerStaffImmigration();
        clsEntityStaffImmigration objEntityImigrationDtls = new clsEntityStaffImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImigrationDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intuserid = Convert.ToInt32(Session["USERID"].ToString());
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityImigrationDtls.CandId = Convert.ToInt32(HiddenCandidateId.Value);

        if (Ddlvisatype.Text == "--Select Visa Type--")
        {
            objEntityImigrationDtls.intVisaTypeID = 0;

        }
        else
        {
            objEntityImigrationDtls.intVisaTypeID = Convert.ToInt32(Ddlvisatype.SelectedValue);
        }

        objEntityImigrationDtls.VisaNo = TextVisa.Text;

        if (txtVisaExpDate.Text == "")
        {
            objEntityImigrationDtls.VisaExpDate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.VisaExpDate = objCommon.textToDateTime(txtVisaExpDate.Text);
        }

        objEntityImigrationDtls.PassNo = TextPass.Text;

        if (txtPassExpDate.Text == "")
        {
            objEntityImigrationDtls.PassExpDate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.PassExpDate = objCommon.textToDateTime(txtPassExpDate.Text);
        }

        objEntityImigrationDtls.UsrInsdate = DateTime.Now;
        objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(Session["USERID"].ToString());
        objEntityImigrationDtls.StaffImig_Id = Convert.ToInt32(HiddenMAsteridImig.Value); ;
        objBusinessImigration.UpdateImmigration(objEntityImigrationDtls);
        DataTable dtImigrationDtls = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
        string strhtm = ConvertDataTableToHTMLForImig(dtImigrationDtls);
        divImigList.InnerHtml = strhtm;
        ScriptManager.RegisterStartupScript(this, GetType(), "ImigSuccessUpdation", "ImigSuccessUpdation();", true);

    }
    public class immigration
    {
        public string issudate = "";
        public string Imig_Id = "";
        public string EMPIMG_ID = "";
        public string VISANUMBER = "";
        public string PASSNUMBER = "";
        public string IMGUSER_ID = "";
        public string ORG_ID = "";
        public string PassEXPIRY = "";
        public string CORPRT_ID = "";
        public string VISAEXPIRY = "";
        public string EMPIMG_DOC_TYPEID = "";
        public string REVIEWDATE = "";
        public string EMPIMG_DOC_COMMENTS = "";
        public string IfRsnShw = "";
        public string attachname = "";
        public string strhtml = "";
        public string visatype = "";
        public string ConvertDataTableToHTMLImmigration(DataTable dt)
        {

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            //  clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
            //clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableImgrtn\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            int intReCallForTAble = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string CnclUsrId = dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString();
                if (CnclUsrId != "")
                {
                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                    if (intCnclUsrId != 0)
                    {
                        intReCallForTAble = 1;
                    }
                }



            }
            strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">SL#</th>";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (i == 0)9
                //{
                //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 6)
                {

                    strHtml += "<th class=\"thT\" style=\"width:2%; word-wrap:break-word;text-align: center;\">EDIT </th>";
                }
                else if (intColumnHeaderCount == 7)
                {
                    strHtml += "<th class=\"thT\" style=\"width:2%; word-wrap:break-word;text-align: center;\">DELETE</th>";

                }

            }


            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int User_Id = 1;
                // int id = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPIMG_ID"]);
                //if (Session["USERID"] != null)
                //{
                //    User_Id = Convert.ToInt32(Session["USERID"]);
                //}
                //else if (Session["USERID"] == null)
                //{
                //    Response.Redirect("/Default.aspx");
                //}

                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                strHtml += "<tr  >";
                string Id = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();
                int slno = intRowBodyCount + 1;
                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>"; //3emp17

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    string strVisa = dt.Rows[intRowBodyCount]["STAFF_VISA_TYP_ID"].ToString();
                    //if (j == 0)
                    //{
                    //    int intCnt = i + 1;
                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                    //}
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 6)
                    {
                        // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                        strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + strVisa + "');\" >" + "<img   src='/Images/Icons/edit.png' /> " + "</a> </td>";  //3emp17

                    }

                    else if (intColumnBodyCount == 7)
                    {



                        strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1%;margin-left:1% \"onclick=\"return DeleteImigrationByid('" + Id + "','" + strVisa + "');\" >" + "<img   src='/Images/Icons/delete.png' /> " + "</a> </td>";      //3emp17

                    }   //3emp17

                    //    int id;



                }
                strHtml += "</tr>";

            }
            strHtml += "</tbody>";

            strHtml += "</table>";







            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    [WebMethod]
    public static immigration ReadImigrationByid(int x, int corpid, int orgid, int empid)
    {
        immigration objImigration = new immigration();
        clsEntityStaffImmigration objEntityImigrationDtls = new clsEntityStaffImmigration();
        clsBusinessLayerStaffImmigration objBusinessImigration = new clsBusinessLayerStaffImmigration();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityImigrationDtls.StaffImig_Id = empid;
        objEntityImigrationDtls.CorpId = corpid;
        objEntityImigrationDtls.OrgId = orgid;
        objEntityImigrationDtls.CandId = x;

        DataTable dt = objBusinessImigration.ReadStaffImmigrationById(objEntityImigrationDtls);



        clsEntityStaffImmigration objEntityImigrationDtls1 = new clsEntityStaffImmigration();
        if (dt.Rows.Count > 0)
        {
            objImigration.Imig_Id = dt.Rows[0]["STAFF_VISA_TYP_ID"].ToString();

            // objImigration.EMPIMG_DOC_TYPEID = dt.Rows[0]["VISATYP_ID"].ToString();
            objImigration.VISANUMBER = dt.Rows[0]["VISA NUMBER"].ToString();
            objImigration.PASSNUMBER = dt.Rows[0]["PASSPORT NUMBER"].ToString();

            //objImigration.issudate = dt.Rows[0]["ISSUEDATE"].ToString();
            objImigration.VISAEXPIRY = dt.Rows[0]["VISA EXPIRY DATE"].ToString();
            objImigration.PassEXPIRY = dt.Rows[0]["PASSPORT EXIPRY DATE"].ToString();
            //objImigration.REVIEWDATE = dt.Rows[0]["REVIEWDATE"].ToString();
            //  objImigration.EMPIMG_DOC_COMMENTS = dt.Rows[0]["EMPIMG_DOC_COMMENTS"].ToString();
            //ie IF  COUNTRY IS ACTIVE

            objImigration.visatype = dt.Rows[0]["VISATYP_ID"].ToString();
        }
        return objImigration;

    }
    [WebMethod]
    public static immigration DeleteImigrationByid(string candid, string CorpId, string Orgid, string UserId, string Emp_id)
    {
        int id = Convert.ToInt32(Emp_id);
        clsBusinessLayerStaffImmigration objBusinessImigration = new clsBusinessLayerStaffImmigration();
        //  clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        immigration objimmigrationtls = new immigration();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityStaffImmigration objEntityImigrationDtls = new clsEntityStaffImmigration();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        objEntityImigrationDtls.StaffImig_Id = Convert.ToInt32(Emp_id);
        objEntityImigrationDtls.CorpId = Convert.ToInt32(CorpId);
        objEntityImigrationDtls.OrgId = Convert.ToInt32(Orgid);
        //  objimmigrationtls.Imig_Id = id.ToString();
        //objEntityImigrationDtls.Imig_user_id = id;
        //objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);
        objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(UserId);
        objEntityImigrationDtls.CandId = Convert.ToInt32(candid);
        string strrsn = "1";
        //objimmigrationtls.ISSUEDATE = System.DateTime.Now.ToString();
        objEntityImigrationDtls.Imigdate = System.DateTime.Now;
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, objEntityImigrationDtls.CorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            if (CnclrsnMust == "0")
            {
                strrsn = "";
                objEntityImigrationDtls.ImigCancelREASON = objCommon.CancelReason();

                objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);
                //Write to divReport
                //  divImigList.InnerHtml = strHtm;
                //ss ScriptManager.RegisterStartupScript(this, GetType(), "JobSuccessConfirmation", "JobSuccessConfirmation();", true);
            }
            else
            {
                objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);
                objimmigrationtls.IfRsnShw = strrsn;
            }

        }
        DataTable dtImigrations = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);//2emp17
        string strHtm = objimmigrationtls.ConvertDataTableToHTMLImmigration(dtImigrations);//2emp17


        objimmigrationtls.strhtml = strHtm;

        objimmigrationtls.IfRsnShw = strrsn;
        return objimmigrationtls;
    }
    //Immigration end
    //Other Details
    protected void btnAddOtherDtls_Click(object sender, EventArgs e)
    {
        //getting the next value
        Button clickedButton = sender as Button;


        clsCommonLibrary objCommon = new clsCommonLibrary();

        //ending  the next val
        clsEntityCommon objEntityCommon = new clsEntityCommon();
    
        clsBusinessLayerCandidateOtherDetails objBusinessCandDtls = new clsBusinessLayerCandidateOtherDetails();
        clsEntityCandidateOtherDetails objEntityCandDtls = new clsEntityCandidateOtherDetails();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
       // clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandDtls.CrprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCandDtls.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityCandDtls.UserID = Convert.ToInt32(Session["USERID"].ToString());

            objEntityCandDtls.InsUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        objEntityCandDtls.InsUserDate = DateTime.Now;

        objEntityCandDtls.CandId = Convert.ToInt32(HiddenCandidateId.Value);


        if (TxtDOB.Text != "")
        {
            objEntityCandDtls.Dob = objCommon.textToDateTime(TxtDOB.Text);
        }
        else
        {

            objEntityCandDtls.Dob = DateTime.MinValue;
        }

        if (ddlBldGrp.SelectedItem.Value != "--Select Blood Group--")
        {

            objEntityCandDtls.BloodGroupId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);
        }
        else
        {
            objEntityCandDtls.BloodGroupId = 0;
        }   //EMP17



        objEntityCandDtls.Name1 = TextName1.Text;
        objEntityCandDtls.Address1 = TextAddr1.Text;
        objEntityCandDtls.Occupation1 = TextOccp1.Text;
        objEntityCandDtls.Phonenumber1 = TextPhn1.Text;
        objEntityCandDtls.Name2 = TextName2.Text;
        objEntityCandDtls.Address2 = TextAddr2.Text;
        objEntityCandDtls.Occupation2 = TextOccp2.Text;
        objEntityCandDtls.Phonenumber2 = TextPhn2.Text;

        if (txtJoinDate.Text != "")
        {
            objEntityCandDtls.JoiningDate = objCommon.textToDateTime(txtJoinDate.Text);
        }
        else
        {

            objEntityCandDtls.JoiningDate = new DateTime();
        }

        if (RadioObj1.Checked == true)
        {
            objEntityCandDtls.SecurSts = 1;
        }
        else if (RadioObj2.Checked == true)
        {
            objEntityCandDtls.SecurSts = 0;
        }
      
        if (RBillness1.Checked == true)
        {
            objEntityCandDtls.illnesstatus = 1;
        }
        else if (RBillness2.Checked == true)
        {
            objEntityCandDtls.illnesstatus = 0;
        }

        if (RadioAppliedYes.Checked == true)
        {
            objEntityCandDtls.AppliedBfrSts = 1;
        }
        else if (RadioAppliedNo.Checked == true)
        {
            objEntityCandDtls.AppliedBfrSts = 0;
        }

        objEntityCandDtls.SpOcu = TextSpOcu.Text;
        objEntityCandDtls.IllnesDetails = TextIllDtls.Text;
        objEntityCandDtls.AppliedBfrDtls = TextApliedBfrDtls.Text;
        if (RadioRelate1.Checked == true)
        {
            objEntityCandDtls.Relationstats = 1;
        }
        else if (RadioRelate2.Checked == true)
        {
            objEntityCandDtls.Relationstats = 0;
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_STAFF_OTHER_DETAILS);
        objEntityCommon.CorporateID = objEntityCandDtls.CrprtId;
        objEntityCommon.Organisation_Id = objEntityCandDtls.UserOrgId;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        //objEntityCandDtls.CrprtId = Convert.ToInt32(strNextId);
        int intImgID = Convert.ToInt32(strNextId);

        string jsonData = HiddenField2_FileUpload.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");

        List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
        objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSub = new List<clsEntityStaffOtherSub>();

        if (HiddenField2_FileUpload.Value != "" && HiddenField2_FileUpload.Value != null)
        {


            for (int count = 0; count < objTVDataList.Count; count++)
            {
                string jsonFileid = "file" + objTVDataList[count].ROWID;
                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                {

                    string fileId = Request.Files.AllKeys[intCount].ToString();
                    HttpPostedFile PostedFile = Request.Files[intCount];
                    if (fileId == jsonFileid)
                    {
                        if (PostedFile.ContentLength > 0)
                        {
                            clsEntityStaffOtherSub objEntityStaff = new clsEntityStaffOtherSub();
                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntityStaff.OtherDocuActualName = strFileName;
                            string strFileExt;

                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                            int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);
                            string strImageName = "DOC_" + intImageSectionOtherDocu.ToString() + "_" + intImgID.ToString() + "_" + count + "." + strFileExt;
                            objEntityStaff.OtherDocuFileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);

                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityStaff.OtherDocuFileName);
                            objEntityStaffOtherDetilsSub.Add(objEntityStaff);

                        }
                    }
                }
            }
        }
        objBusinessCandDtls.insertCandidateDtls(objEntityCandDtls, objEntityStaffOtherDetilsSub);
        OtherdetailsSubUpdate(HiddenCandidateId.Value);

        //if (FileUploadOthrdoc.HasFile)
        //{
        //    // GET FILE EXTENSION

        //    string strFileExt;
        //    strFileExt = FileUploadOthrdoc.FileName.Substring(FileUploadOthrdoc.FileName.LastIndexOf('.') + 1).ToLower();
        //    string strFileName = FileUploadOthrdoc.FileName;
        //    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.STAFF_OTHER_DOCUMENT);
        //    string strImageName = "UserDoc_" + intImageSection.ToString() + "_" + objEntityCandDtls.CandId + "." + strFileExt;
        //    // objEntityCandDtls.PhotoFname = strImageName;
        //    objEntityCandDtls.ImigDocName = strImageName;

        //}

        //objBusinessCandDtls.insertCandidateDtls(objEntityCandDtls);
        //updateOtherDtls(HiddenCandidateId.Value);
        btnAddPD.Visible = false;
        btnUpdatePD.Visible = true;
        btnClearPD.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationOth", "SuccessConfirmationOth();", true);



    }
    public class clsAtchmntData
    {

        public string ROWID { get; set; }
        public string FILEPATH { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }

    protected void btnUpdateOthrDtls_Click(object sender, EventArgs e)
    {

        clsBusinessLayerCandidateOtherDetails objBusinessCandDtls = new clsBusinessLayerCandidateOtherDetails();
        clsEntityCandidateOtherDetails objEntityCandDtls = new clsEntityCandidateOtherDetails();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
    
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandDtls.CrprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCandDtls.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityCandDtls.UserID = Convert.ToInt32(Session["USERID"].ToString());

            objEntityCandDtls.InsUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }


        objEntityCandDtls.InsUserDate = DateTime.Now;

        objEntityCandDtls.CandId = Convert.ToInt32(HiddenCandidateId.Value);


        if (TxtDOB.Text != "")
        {
            objEntityCandDtls.Dob = objCommon.textToDateTime(TxtDOB.Text);
        }
        else
        {

            objEntityCandDtls.Dob =  DateTime.MinValue;
        }

        if (ddlBldGrp.SelectedItem.Value != "--Select Blood Group--")
        {

            objEntityCandDtls.BloodGroupId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);
        }
        else
        {
            objEntityCandDtls.BloodGroupId = 0;
        }   //EMP17



        objEntityCandDtls.Name1 = TextName1.Text;
        objEntityCandDtls.Address1 = TextAddr1.Text;
        objEntityCandDtls.Occupation1 = TextOccp1.Text;
        objEntityCandDtls.Phonenumber1 = TextPhn1.Text;
        objEntityCandDtls.Name2 = TextName2.Text;
        objEntityCandDtls.Address2 = TextAddr2.Text;
        objEntityCandDtls.Occupation2 = TextOccp2.Text;
        objEntityCandDtls.Phonenumber2 = TextPhn2.Text;

        if (txtJoinDate.Text != "")
        {
            objEntityCandDtls.JoiningDate = objCommon.textToDateTime(txtJoinDate.Text);
        }
        else
        {

            objEntityCandDtls.JoiningDate = new DateTime();
        }

        if (RadioObj1.Checked == true)
        {
            objEntityCandDtls.SecurSts = 1;
        }
        else if (RadioObj2.Checked == true)
        {
            objEntityCandDtls.SecurSts = 0;
        }

        if (RBillness1.Checked == true)
        {
            objEntityCandDtls.illnesstatus = 1;
        }
        else if (RBillness2.Checked == true)
        {
            objEntityCandDtls.illnesstatus = 0;
        }

        if (RadioAppliedYes.Checked == true)
        {
            objEntityCandDtls.AppliedBfrSts = 1;
        }
        else if (RadioAppliedNo.Checked == true)
        {
            objEntityCandDtls.AppliedBfrSts = 0;
        }

        objEntityCandDtls.SpOcu = TextSpOcu.Text;
        objEntityCandDtls.IllnesDetails = TextIllDtls.Text;
        objEntityCandDtls.AppliedBfrDtls = TextApliedBfrDtls.Text;
        if (RadioRelate1.Checked == true)
        {
            objEntityCandDtls.Relationstats = 1;
        }
        else if (RadioRelate2.Checked == true)
        {
            objEntityCandDtls.Relationstats = 0;
        }



        //if (FileUploadOthrdoc.HasFile)
        //{
        //    // GET FILE EXTENSION

        //    string strFileExt;
        //    strFileExt = FileUploadOthrdoc.FileName.Substring(FileUploadOthrdoc.FileName.LastIndexOf('.') + 1).ToLower();
        //    string strFileName = FileUploadOthrdoc.FileName;
        //    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.STAFF_OTHER_DOCUMENT);
        //    string strImageName = "UserDoc_" + intImageSection.ToString() + "_" + objEntityCandDtls.CandId + "." + strFileExt;
        //    // objEntityCandDtls.PhotoFname = strImageName;
        //    objEntityCandDtls.ImigDocName = strImageName;

        //}

        //objBusinessCandDtls.updatePersonalDtls(objEntityCandDtls);


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_STAFF_OTHER_DETAILS);
        objEntityCommon.CorporateID = objEntityCandDtls.CrprtId;
        objEntityCommon.Organisation_Id = objEntityCandDtls.UserOrgId;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        //objEntityCandDtls.CrprtId = Convert.ToInt32(strNextId);
        int intImgID = Convert.ToInt32(strNextId);

        string jsonData = HiddenField2_FileUpload.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");

        List<clsAtchmntData> objTVDataList = new List<clsAtchmntData>();
        objTVDataList = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);

        List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSub = new List<clsEntityStaffOtherSub>();

        if (HiddenField2_FileUpload.Value != "" && HiddenField2_FileUpload.Value != null)
        {


            for (int count = 0; count < objTVDataList.Count; count++)
            {
                string jsonFileid = "file" + objTVDataList[count].ROWID;
                for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                {

                    string fileId = Request.Files.AllKeys[intCount].ToString();
                    HttpPostedFile PostedFile = Request.Files[intCount];
                    if (fileId == jsonFileid)
                    {
                        if (PostedFile.ContentLength > 0)
                        {
                            clsEntityStaffOtherSub objEntityStaff = new clsEntityStaffOtherSub();
                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntityStaff.OtherDocuActualName = strFileName;
                            string strFileExt;

                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                            int intImageSectionOtherDocu = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);
                            string strImageName = "DOC_" + intImageSectionOtherDocu.ToString() + "_" + intImgID.ToString() + "_" + count + "." + strFileExt;
                            objEntityStaff.OtherDocuFileName = strImageName;
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);

                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityStaff.OtherDocuFileName);
                            objEntityStaffOtherDetilsSub.Add(objEntityStaff);

                        }
                    }
                }
            }
        }


        string strCanclDtlId = "";
        string[] strarrCancldtlIds = strCanclDtlId.Split(',');
        if (hiddenPerFileCanclDtlId.Value != "" && hiddenPerFileCanclDtlId.Value != null)
        {
            strCanclDtlId = hiddenPerFileCanclDtlId.Value;
            strarrCancldtlIds = strCanclDtlId.Split(',');

        }

        List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSubdelete = new List<clsEntityStaffOtherSub>();
        if (hiddenPerFileCanclDtlId.Value != "" && hiddenPerFileCanclDtlId.Value != null)
        {
            string jsonDataDltAttch = hiddenPerFileCanclDtlId.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsOtherDocuAttchDELETE> objEntityStaffOtherDeleteSub = new List<clsOtherDocuAttchDELETE>();
            //   UserData  data
            objEntityStaffOtherDeleteSub = JsonConvert.DeserializeObject<List<clsOtherDocuAttchDELETE>>(strAtt4);


            foreach (clsOtherDocuAttchDELETE objClsVhclDltAttData in objEntityStaffOtherDeleteSub)
            {

                clsEntityStaffOtherSub objEntityRnwlDetailsAttchmnt = new clsEntityStaffOtherSub();

                objEntityRnwlDetailsAttchmnt.WorkerDetailID = Convert.ToInt32(objClsVhclDltAttData.DTLID);
                objEntityRnwlDetailsAttchmnt.OtherDocuFileName = Convert.ToString(objClsVhclDltAttData.FILENAME);

                objEntityStaffOtherDetilsSubdelete.Add(objEntityRnwlDetailsAttchmnt);


            }
        }


        objBusinessCandDtls.updatePersonalDtls(objEntityCandDtls, objEntityStaffOtherDetilsSub, objEntityStaffOtherDetilsSubdelete);


        OtherdetailsSubUpdate(HiddenCandidateId.Value);

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationOth", "SuccessUpdationOth();", true);

    }



    public class clsOtherDocuAttchDELETE
    {
        public string FILENAME { get; set; }

        public string DTLID { get; set; }

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


    public void updateOtherDtls(string id)
    {
        OtherdetailsSubUpdate(id);
        btnAddPD.Visible = true;
        btnUpdatePD.Visible = false;
        clsEntityCandidateOtherDetails objEntityOtherDetails = new clsEntityCandidateOtherDetails();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOtherDetails.CrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityOtherDetails.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //btnUpdateMrgInfo.Visible = true;
        //btnAddMrgInfo.Visible = false;
        //btnClearMrgInfo.Visible = false;
        clsBusinessLayerCandidateOtherDetails objBusinessOtherDetails = new clsBusinessLayerCandidateOtherDetails();
        //  clsEntityCandidateOtherDetails objEntityOtherDetails = new clsEntityCandidateOtherDetails();
        objEntityOtherDetails.CandId = Convert.ToInt32(id);
        DataTable dt = objBusinessOtherDetails.ReadPersnlDtlsById(objEntityOtherDetails);
        if (dt.Rows.Count > 0)
        {
            hiddenOtherUpdChk.Value = "1";
            btnAddPD.Visible = false;
            btnUpdatePD.Visible = true;

            //txtAdr1.Text = dt.Rows[0]["MRG_DATE"].ToString();
            txtJoinDate.Text = dt.Rows[0]["STAFF_JOINING_DATE"].ToString();

            TxtDOB.Text = dt.Rows[0]["DATE OF BIRTH"].ToString();


            //if (ddlBldGrp.SelectedItem.Value != "--Select Blood Group--")



            //EMP17


           
            TextName1.Text = dt.Rows[0]["STAFF_REFF_A_NAME"].ToString();
            TextAddr1.Text = dt.Rows[0]["STAFF_REFF_A_ADDR"].ToString();
            TextOccp1.Text = dt.Rows[0]["STAFF_REFF_A_OCCUPATION"].ToString();
            TextPhn1.Text = dt.Rows[0]["STAFF_REFF_A_PHN"].ToString();
            TextName2.Text = dt.Rows[0]["STAFF_REFF_B_NAME"].ToString();
            TextAddr2.Text = dt.Rows[0]["STAFF_REFF_B_ADDR"].ToString();
            TextOccp2.Text = dt.Rows[0]["STAFF_REFF_B_OCCUPATION"].ToString();

            TextPhn2.Text = dt.Rows[0]["STAFF_REFF_B_PHN"].ToString();

            if (dt.Rows[0]["BLOOD ID"].ToString() != "")
            {
                if (ddlBldGrp.Items.FindByValue(dt.Rows[0]["BLOOD ID"].ToString()) != null)
                {
                    ddlBldGrp.Items.FindByValue(dt.Rows[0]["BLOOD ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["BLOOD GROUP"].ToString(), dt.Rows[0]["BLOOD ID"].ToString());
                    ddlBldGrp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivison);

                    ddlBldGrp.Items.FindByValue(dt.Rows[0]["BLOOD ID"].ToString()).Selected = true;
                }
            }

            if (dt.Rows[0]["STAFF_REFF_SECUR_STS"].ToString() == "1")
            {

                RadioObj1.Checked = true;
                RadioObj2.Checked = false;
            }
            else
            {
                RadioObj1.Checked = false;
                RadioObj2.Checked = true;
               
            }
            txtJoinDate.Text = dt.Rows[0]["STAFF_JOINING_DATE"].ToString();

            //TxtJoinDate.Text=""; 



            if (dt.Rows[0]["ILLNESS STATUS"].ToString() == "1")
            {


                RBillness1.Checked = true;
                RBillness2.Checked = false;
                TextIllDtls.Enabled = true;
            }
            else {
                RBillness2.Checked = true;
                RBillness1.Checked = false;
                TextIllDtls.Enabled = false;
            }

            TextIllDtls.Text = dt.Rows[0]["ILLNES DETAILS"].ToString();



            if (dt.Rows[0]["APPLIED BEFORE"].ToString() == "1")
            {

                RadioAppliedYes.Checked = true;
                RadioAppliedNo.Checked = false;
                TextApliedBfrDtls.Enabled = true;
            }
            else
            {
                RadioAppliedNo.Checked = true;
                RadioAppliedYes.Checked = false;
                TextApliedBfrDtls.Enabled = false;
            }
            TextApliedBfrDtls.Text = dt.Rows[0]["APPLIED BEFORE DETAILS"].ToString();




            TextSpOcu.Text = dt.Rows[0]["SPOUSE OCCUPATION"].ToString();

            TextApliedBfrDtls.Text = dt.Rows[0]["APPLIED BEFORE DETAILS"].ToString();



            if (dt.Rows[0]["ANY RELATIVES"].ToString() == "1")
            {

                RadioRelate1.Checked = true;
                RadioRelate2.Checked = false;
            }

            else
            {
                RadioRelate2.Checked = true;
                RadioRelate1.Checked = false;
            }






            //if (FileUploadRecharge.HasFile)
            //{
            //     GET FILE EXTENSION

            //    string strFileExt;
            //    strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();
            //    string strFileName = FileUploadRecharge.FileName;
            //    int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.STAFF_OTHER_DOCUMENT);
            //    string strImageName = "UserDoc_" + intImageSection.ToString() + "_" + objEntityCandDtls.CandId + "." + strFileExt;
            //     objEntityCandDtls.PhotoFname = strImageName;
            //    objEntityCandDtls.ImigDocName = strImageName;

            //}

           

        }
    }
    public void OtherdetailsSubUpdate(string strCandID)
    {
        clsEntityCandidateOtherDetails objEntityOtherDetails = new clsEntityCandidateOtherDetails();
        clsBusinessLayerCandidateOtherDetails objBusinessCandDtls = new clsBusinessLayerCandidateOtherDetails();
        DataTable dtWorkerOtherDocu = new DataTable();
        objEntityOtherDetails.CandId = Convert.ToInt32(strCandID);
        dtWorkerOtherDocu = objBusinessCandDtls.ReadStaffOtherSubByID(objEntityOtherDetails);

        if (dtWorkerOtherDocu.Rows.Count > 0)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            HiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.JOINING_WORKER_DOCUMENTS);

            DataTable dtIAttchmnt = new DataTable();
            dtIAttchmnt.Columns.Add("TransDtlId", typeof(int));
            dtIAttchmnt.Columns.Add("FileName", typeof(string));
            dtIAttchmnt.Columns.Add("ActualFileName", typeof(string));




            if (dtWorkerOtherDocu.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtWorkerOtherDocu.Rows.Count; intcnt++)
                {
                    DataRow drAttchInsur = dtIAttchmnt.NewRow();
                    drAttchInsur["TransDtlId"] = dtWorkerOtherDocu.Rows[intcnt]["STFF_SUB_ID"].ToString();
                    drAttchInsur["FileName"] = dtWorkerOtherDocu.Rows[intcnt]["STFF_SUB_FILE_NAME"].ToString();
                    drAttchInsur["ActualFileName"] = dtWorkerOtherDocu.Rows[intcnt]["STFF_SUB_ACT_NAME"].ToString();
                    dtIAttchmnt.Rows.Add(drAttchInsur);
                }
                string strJson = DataTableToJSONWithJavaScriptSerializer(dtIAttchmnt);
                HiddenEdit.Value = strJson;
            }
           
        }
        else
        {
            HiddenEdit.Value = "";
        }

    }
    public void BloodgrpLoad()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.ReadBloodgrp();
        ddlBldGrp.Items.Clear();
        ddlBldGrp.DataSource = dtCountry;
        ddlBldGrp.DataTextField = "BLOODGRP_NAME";
        ddlBldGrp.DataValueField = "BLOODGRP_ID";
        ddlBldGrp.DataBind();
        ddlBldGrp.Items.Insert(0, "--Select Blood Group--");
    }
    //Other Details end
    //evm-0012
    protected void btnAddWrkExp_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerStaffWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerStaffWorkExperience();
        //clsQualification
        clsEntityLayerStaffWorkExperience objEntityWorkExperience = new clsEntityLayerStaffWorkExperience();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWorkExperience.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWorkExperience.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityWorkExperience.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityWorkExperience.CandidateID = Convert.ToInt32(strId);
        }

        objEntityWorkExperience.CandidateID = Convert.ToInt32(HiddenCandidateId.Value);

        objEntityWorkExperience.WrkEmpName = txtNameOfEmployerWrkExp.Text.Trim().ToUpper();
        objEntityWorkExperience.WrkAddress = txtAddressOfEmployerWrkExp.Text.Trim();
        if (txtWorkExpYearsWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.WrkExpYears = Convert.ToDecimal(txtWorkExpYearsWrkExp.Text.Trim());
        }
        if (txtGCCExpYearsWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.WrkGCCExpYears = Convert.ToDecimal(txtGCCExpYearsWrkExp.Text.Trim());
        }
        if (txtDateOfJoiningWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.LastWrkJoiningDate = objCommon.textToDateTime(txtDateOfJoiningWrkExp.Text);
        }
        if (txtDateOfLeavingWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.LastWrkLeavingDate = objCommon.textToDateTime(txtDateOfLeavingWrkExp.Text);
        }
        objEntityWorkExperience.Designation = txtDesignationWrkExp.Text.Trim().ToUpper();
        if (txtSalaryWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.Salary = Convert.ToDecimal(txtSalaryWrkExp.Text.Trim());
        }
        
        objEntityWorkExperience.Date = System.DateTime.Now;



        objBusinessLayerWorkExperience.insertWorkExp(objEntityWorkExperience);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);

        //objEntityWorkExperience.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
        string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
        divListWrkExp.InnerHtml = strHtmList;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationWrkExp", "SuccessConfirmationWrkExp();", true);


    }
    protected void btnUpdateWrkExp_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerStaffWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerStaffWorkExperience();
        //clsQualification
        clsEntityLayerStaffWorkExperience objEntityWorkExperience = new clsEntityLayerStaffWorkExperience();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWorkExperience.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityWorkExperience.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityWorkExperience.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(hiddenWrkExpDtlID.Value);
        objEntityWorkExperience.CandidateID = Convert.ToInt32(HiddenCandidateId.Value);

        objEntityWorkExperience.WrkEmpName = txtNameOfEmployerWrkExp.Text.Trim().ToUpper();
        objEntityWorkExperience.WrkAddress = txtAddressOfEmployerWrkExp.Text.Trim();
        if (txtWorkExpYearsWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.WrkExpYears = Convert.ToDecimal(txtWorkExpYearsWrkExp.Text.Trim());
        }
        if (txtGCCExpYearsWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.WrkGCCExpYears = Convert.ToDecimal(txtGCCExpYearsWrkExp.Text.Trim());
        }
        if (txtDateOfJoiningWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.LastWrkJoiningDate = objCommon.textToDateTime(txtDateOfJoiningWrkExp.Text);
        }
        if (txtDateOfLeavingWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.LastWrkLeavingDate = objCommon.textToDateTime(txtDateOfLeavingWrkExp.Text);
        }
        objEntityWorkExperience.Designation = txtDesignationWrkExp.Text.Trim().ToUpper();
        if (txtSalaryWrkExp.Text.Trim() != "")
        {
            objEntityWorkExperience.Salary = Convert.ToDecimal(txtSalaryWrkExp.Text.Trim());
        }
        objEntityWorkExperience.Date = System.DateTime.Now;

        objBusinessLayerWorkExperience.updateWorkExp(objEntityWorkExperience);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);

        DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
        string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
        divListWrkExp.InnerHtml = strHtmList;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationWrkExp", "SuccessUpdationWrkExp();", true);


    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLwrkExp(DataTable dt)
    {
        //STAFF_WRK_EXP_ID,STAFF_WRK_EXP_YR,STAFF_WRK_GCC_EXP,STAFF_WRK_NAME_LST_EMP,STAFF_WRK_ADDR_LST_EMP,STAFF_WRK_DT_JOINING,STAFF_WRK_DT_LEAVING,STAFF_WRK_DSGN,STAFF_WRK_SALARY,CAND_ID

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableWrkExp\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";//EMP17 ..CAPITALISED
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            //if (intColumnHeaderCount == 7)
            //{
            //    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            //}
        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";   //EMP17

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {




            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                //if (intColumnBodyCount == 7)
                //{
                //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                //}
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            string strCandId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();
            //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            //string stridLength = intIdLength.ToString("00");
            //string Id = stridLength + strId + strRandom;



            //emp17    tooltip added




            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 0.5%;margin-top: -1.5%;\" class=\"tooltip\" title=\"Edit\" onclick=\"return updateWrkExpById('" + strId + "','" + strCandId + "');\" >" +
                           "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1.5%;\" class=\"tooltip\" title=\"Delete\" onclick=\"return deleteWrkExpById('" + strId + "','" + strCandId + "');\" >" +
                                "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
            //emp17    tooltip added

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    public class WorkExperience
    {

        public string WorkExpDtl_id = "";
        public string CandidateID = "";
        public string WrkExpYears = "";
        public string WrkGCCExpYears = "";
        public string WrkEmpName = "";
        public string WrkAddress = "";
        public string LastWrkJoiningDate = "";
        public string LastWrkLeavingDate = "";
        public string Designation = "";
        public string Salary = "";
        public string strImg = "";
        public string strWrkExpList = "";
        public string ImageLoad(string Fname, string ActFname)
        {
            //for displaying photo
            string strImage = "";
            if (Fname != "")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION) + Fname;
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";

            }
            return strImage;
        }
        public string ConvertDataTableToHTMLwrkExp(DataTable dt)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableWrkExp\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (i == 0)
                //{
                //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";//EMP17 ..CAPITALISED
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 6)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                //if (intColumnHeaderCount == 7)
                //{
                //    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                //}
            }


            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {




                strHtml += "<tr  >";



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    //if (j == 0)
                    //{
                    //    int intCnt = i + 1;
                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                    //}
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    //if (intColumnBodyCount == 7)
                    //{
                    //    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    //}
                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                string strCandId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();
                //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                //string stridLength = intIdLength.ToString("00");
                //string Id = stridLength + strId + strRandom;




                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return updateWrkExpById('" + strId + "','" + strCandId + "');\" >" +
                               "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return deleteWrkExpById('" + strId + "','" + strCandId + "');\" >" +
                                    "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    //evm--0012 editView
    [WebMethod]
    public static WorkExperience ReadWrkExpDtlById(string Id, string CandID, string OrgIDStaff, string CorpidIDStaff)
    {
        WorkExperience objWorkExp = new WorkExperience();

        ClsBusinessLayerStaffWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerStaffWorkExperience();
        //clsQualification
        clsEntityLayerStaffWorkExperience objEntityWorkExperience = new clsEntityLayerStaffWorkExperience();
        objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(Id);
        objEntityWorkExperience.CandidateID = Convert.ToInt32(CandID);
        objEntityWorkExperience.Corporate_id = Convert.ToInt32(CorpidIDStaff);
        objEntityWorkExperience.Organisation_id = Convert.ToInt32(OrgIDStaff);
        DataTable dt = objBusinessLayerWorkExperience.ReadWrkExpDtlById(objEntityWorkExperience);


        if (dt.Rows.Count > 0)
        {
            objWorkExp.WorkExpDtl_id = dt.Rows[0]["STAFF_WRK_EXP_ID"].ToString();
            objWorkExp.CandidateID = dt.Rows[0]["CAND_ID"].ToString();
            objWorkExp.WrkExpYears = dt.Rows[0]["STAFF_WRK_EXP_YR"].ToString();
            objWorkExp.WrkGCCExpYears = dt.Rows[0]["STAFF_WRK_GCC_EXP"].ToString();
            objWorkExp.WrkEmpName = dt.Rows[0]["STAFF_WRK_NAME_LST_EMP"].ToString();
            objWorkExp.WrkAddress = dt.Rows[0]["STAFF_WRK_ADDR_LST_EMP"].ToString();
            objWorkExp.LastWrkJoiningDate = dt.Rows[0]["STAFF_WRK_DT_JOINING"].ToString();
            objWorkExp.LastWrkLeavingDate = dt.Rows[0]["STAFF_WRK_DT_LEAVING"].ToString();
            objWorkExp.Designation = dt.Rows[0]["STAFF_WRK_DSGN"].ToString();
            objWorkExp.Salary = dt.Rows[0]["STAFF_WRK_SALARY"].ToString();
            //objWorkExp.strImg = objWorkExp.ImageLoad(objWorkExp.Fname, objWorkExp.ActFname);
        }
        return objWorkExp;
    }
    [WebMethod]
    public static WorkExperience deleteWrkExpById(string Id, string CandID, string OrgIDStaff, string CorpidIDStaff)
    {
        WorkExperience objWrkExp = new WorkExperience();

        ClsBusinessLayerStaffWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerStaffWorkExperience();
        //clsQualification
        clsEntityLayerStaffWorkExperience objEntityWorkExperience = new clsEntityLayerStaffWorkExperience();
        objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(Id);
        objEntityWorkExperience.Corporate_id = Convert.ToInt32(CorpidIDStaff);
        objEntityWorkExperience.Organisation_id = Convert.ToInt32(OrgIDStaff);
        objEntityWorkExperience.CandidateID = Convert.ToInt32(CandID);
        objBusinessLayerWorkExperience.DeleteWrkExpDtl(objEntityWorkExperience);


        DataTable dt = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
        objWrkExp.strWrkExpList = objWrkExp.ConvertDataTableToHTMLwrkExp(dt);
        return objWrkExp;
    }
    //stop:Qualification-Work Experience


    //start:Qualification-Education
    public void EduLvlLoad()
    {
        clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
        clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();
        if (ddlEduType.SelectedItem.Value != "--Select Type--")
        {
            objEntityEducation.CandidateID = Convert.ToInt32(ddlEduType.SelectedItem.Value);
        }
        DataTable dt = objBusinessEducation.ReadEduLvl(objEntityEducation);
        ddlEduQualification.Items.Clear();

        ddlEduQualification.DataSource = dt;
        ddlEduQualification.DataTextField = "COURSE";
        ddlEduQualification.DataValueField = "QUAL_COURSE_ID";
        ddlEduQualification.DataBind();
        ddlEduQualification.Items.Insert(0, "--Select Course--");
        //if (Hiddenddlselect.Value != "")
        //{
        //    ddlEduQualification.ClearSelection();
        //    if (ddlEduQualification.Items.FindByValue(Hiddenddlselect.Value) != null)
        //    {
        //        ddlEduQualification.Items.FindByValue(Hiddenddlselect.Value).Selected = true;
              // Hiddenddlselect.Value = "0";
        //    }
           
        //  //  ddlEduQualification.SelectedValue = Hiddenddlselect.Value;
        //}
    }

    protected void btnAddEdu_Click(object sender, EventArgs e)
    {
        clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
        clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEducation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEducation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEducation.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityEducation.Date = System.DateTime.Now;
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityEducation.CandidateID = Convert.ToInt32(strId);
        }
        objEntityEducation.CandidateID = Convert.ToInt32(HiddenCandidateId.Value);


        if (ddlEduQualification.SelectedItem.Value != "--Select Course--")
        {
            objEntityEducation.CourseID = Convert.ToInt32(ddlEduQualification.SelectedItem.Value);
        }

        objEntityEducation.Institution = txtEduInstite.Text.Trim();
        objEntityEducation.Specialization = txtEduSpecialization.Text.Trim();
        objEntityEducation.Degree = txtEduDegree.Text.Trim();
        if (txtEduStrtDate.Text.Trim() != "")
        {

          //  objEntityEducation.PassingYear = objCommon.textToDateTime(txtEduStrtDate.Text);
            //objEntityEducation.PassingYear=
        }
         else
        {
            objEntityEducation.PassingYear = DateTime.MinValue;
        }
        if (ddlYearEdu.SelectedItem.Value != "--YEAR--" && ddlMonthEdu.SelectedItem.Value != "--MONTH--")
        {
            // objEntityEducation.PassingYear = objCommon.textToDateTime(txtEduStrtDate.Text);
            int intYear = Convert.ToInt32(ddlYearEdu.SelectedItem.Value);
            int intMonth = Convert.ToInt32(ddlMonthEdu.SelectedItem.Value);
            DateTime dateMonthAndYearEdu = new DateTime(intYear, intMonth, 1);
            objEntityEducation.PassingYear = dateMonthAndYearEdu;
        }
        else
        {
            objEntityEducation.PassingYear = DateTime.MinValue;
        }
        if (txtEduPercentage.Text.Trim() != "")
        {
            objEntityEducation.Percentage = Convert.ToDecimal(txtEduPercentage.Text.Trim());
        }
        objBusinessEducation.insertEducation(objEntityEducation);

        //objEntityEducation.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
        string strHtmListEdu = ConvertDataTableToHTMLeductn(dtEdulist);
        divListEdu.InnerHtml = strHtmListEdu;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationEdu", "SuccessConfirmationEdu();", true);


    }
    protected void btnUpdateEdu_Click(object sender, EventArgs e)
    {
        clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
        clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEducation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEducation.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEducation.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityEducation.Date = System.DateTime.Now;
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityEducation.CandidateID = Convert.ToInt32(strId);
        }
        objEntityEducation.CandidateID = Convert.ToInt32(HiddenCandidateId.Value);
        objEntityEducation.Degree = txtEduDegree.Text.Trim();
        objEntityEducation.EductnDtl_Id = Convert.ToInt32(HiddenEductnDtlId.Value);
        if (Hiddenddlselect.Value != "0" || Hiddenddlselect.Value != "--Select Course--")
        {
         objEntityEducation.CourseID =Convert.ToInt32(Hiddenddlselect.Value);
        }
        //else {
            
       // }

        objEntityEducation.Institution = txtEduInstite.Text.Trim();
        objEntityEducation.Specialization = txtEduSpecialization.Text.Trim();
        //if (txtEduStrtDate.Text.Trim() != "")
        //{
        //    objEntityEducation.PassingYear = objCommon.textToDateTime(txtEduStrtDate.Text);
        //}
        //else
        //{
        //    objEntityEducation.PassingYear = DateTime.MinValue;
        //} 
        if (ddlYearEdu.SelectedItem.Value != "--YEAR--" && ddlMonthEdu.SelectedItem.Value != "--MONTH--")
        {
            // objEntityEducation.PassingYear = objCommon.textToDateTime(txtEduStrtDate.Text);
            int intYear = Convert.ToInt32(ddlYearEdu.SelectedItem.Value);
            int intMonth = Convert.ToInt32(ddlMonthEdu.SelectedItem.Value);
            DateTime dateMonthAndYearEdu = new DateTime(intYear, intMonth, 1);
            objEntityEducation.PassingYear = dateMonthAndYearEdu;
        }
        else
        {
            objEntityEducation.PassingYear = DateTime.MinValue;
        }
        if (txtEduPercentage.Text.Trim()!="")
        {
            objEntityEducation.Percentage = Convert.ToDecimal(txtEduPercentage.Text.Trim());
            
        }
        objBusinessEducation.updateEducation(objEntityEducation);



        //objEntityEducation.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
        string strHtmListEdu = ConvertDataTableToHTMLeductn(dtEdulist);
        divListEdu.InnerHtml = strHtmListEdu;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationEdu", "SuccessUpdationEdu();", true);


    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLeductn(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableEdu\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            //if (i == 0)
            //{
            //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
            //}
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>"; //15EMP17
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 7)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }

        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";//15EMP17

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {




            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {

                if (intColumnBodyCount == 1)
                {
                    if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "PG" + "</td>";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "UG" + "</td>";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "HSE" + "</td>";
                    }
                    else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "Other" + "</td>";
                    }
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            //string stridLength = intIdLength.ToString("00");
            //string Id = stridLength + strId + strRandom;
            string strCandId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();

            // style="margin-left: -37%;"
            //15emp17
            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Edit\" onclick=\"return updateEduDtlById('" + strId + "','" + strCandId + "');\" >" +
                            "<img  style=\"margin-left: -63%;\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Delete\" onclick=\"return deleteEduDtlById('" + strId + "','" + strCandId + "');\" >" +
                                "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";

            //15emp17
            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    public class Education
    {
        //public int LvlId = 0;
        //public int LvlSts = 0;
        //public string LvlName = "";
        //public string Institute = "";
        //public string MjrSpec = "";
        //public string year = "";
        //public string Score = "";
        //public string StartDate = "";
        //public string EndDate = "";
        //public string Fname = "";
        public string EduType = "";
        public string QulfctnLoad = "";

        public string StaffQualID = "";
        public string date = "";
        public string CandidateID = "";
        public string CancelReason = "";
        public string Institution = "";
        public string CourseID = "";
        public string PassingYear = "";
        public string Degree = "";
        public string Specialization = "";
        public string Percentage = "";
        public int Year = 0; 
        public int Month = 0;

        public string strEduList = "";
        public string strImg = "";
        public string ImageLoad(string Fname, string ActFname)
        {
            //for displaying photo
            string strImage = "";
            if (Fname != "")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION) + Fname;
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofyEdu\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofyEdu\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";

            }
            return strImage;
        }
        //It build the Html table by using the datatable provided
        public string ConvertDataTableToHTMLeductn(DataTable dt)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableEdu\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (i == 0)
                //{
                //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 6)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 7)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }

            }


            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {




                strHtml += "<tr  >";



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "1")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "PG" + "</td>";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "2")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "UG" + "</td>";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "3")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "HSE" + "</td>";
                        }
                        else if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() == "4")
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + "Other" + "</td>";
                        }
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 6)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 7)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                //string stridLength = intIdLength.ToString("00");
                //string Id = stridLength + strId + strRandom;
                string strCandId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();



                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return updateEduDtlById('" + strId + "','" + strCandId + "');\" >" +
                               "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return deleteEduDtlById('" + strId + "','" + strCandId + "');\" >" +
                                    "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    [WebMethod]
    public static Education ReadEduDtlById(string Id, string CandID)
    {
        Education objEdu = new Education();
        clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
        clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();
        objEntityEducation.EductnDtl_Id = Convert.ToInt32(Id);
        objEntityEducation.CandidateID = Convert.ToInt32(CandID);
        DataTable dt = objBusinessEducation.ReadEduDtlById(objEntityEducation);
        if (dt.Rows.Count > 0)
        {
            objEdu.StaffQualID = dt.Rows[0]["STAFF_QUAL_ID"].ToString();
            objEdu.CourseID = dt.Rows[0]["QUAL_COURSE_ID"].ToString();
            objEdu.Institution = dt.Rows[0]["STAFF_QUAL_INST"].ToString();
            objEdu.PassingYear = dt.Rows[0]["STAFF_QUAL_PASSING_YR"].ToString();
            objEdu.Degree = dt.Rows[0]["STAFF_QUAL_DEGREE"].ToString();
            objEdu.Specialization = dt.Rows[0]["STAFF_QUAL_SPEC"].ToString();
            objEdu.Percentage = dt.Rows[0]["STAFF_QUAL_PRCTG"].ToString();
            objEdu.EduType = dt.Rows[0]["QUAL_TYPE"].ToString();
            objEdu.CandidateID = dt.Rows[0]["CAND_ID"].ToString();
            if (dt.Rows[0]["STAFF_QUAL_PASSING_YR"].ToString() != "")
            {
                DateTime dtPassyear = Convert.ToDateTime(objEdu.PassingYear);
                objEdu.Year = dtPassyear.Year;
                objEdu.Month = dtPassyear.Month;
            }
            if (objEdu.EduType != "0")
            {


                objEntityEducation.CandidateID =Convert.ToInt32( objEdu.EduType);
                
                DataTable dtt = objBusinessEducation.ReadEduLvl(objEntityEducation);
                dtt.TableName = "dtTableQualfTyp";
                string result;
                using (StringWriter sw = new StringWriter())
                {
                    dtt.WriteXml(sw);
                    result = sw.ToString();
                    objEdu.QulfctnLoad = result;
                }
               
            }

        }
        return objEdu;
    }
    [WebMethod]
    public static Education deleteEduById(string Id, string empId)
    {
        Education objEdu = new Education();
        clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
        clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();
        objEntityEducation.EductnDtl_Id = Convert.ToInt32(Id);
        objEntityEducation.CandidateID = Convert.ToInt32(empId);
        objBusinessEducation.deleteEduById(objEntityEducation);


        DataTable dt = objBusinessEducation.readEduList(objEntityEducation);
        objEdu.strEduList = objEdu.ConvertDataTableToHTMLeductn(dt);
        return objEdu;
    }
    //evm-0012
    public void LanguageLoad()
    {
        clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
        DataTable dt = objBusinessLangauage.ReadLanguage();
        ddlQuLang.Items.Clear();
        ddlQuLang.DataSource = dt;
        ddlQuLang.DataTextField = "LANGMSTR_NAME";
        ddlQuLang.DataValueField = "LANGMSTR_ID";
        ddlQuLang.DataBind();
        ddlQuLang.Items.Insert(0, "--Select Language--");
    }
    //evm-0012
    protected void btnAddLang_Click(object sender, EventArgs e)
    {
        clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
        //clsQualification
        clsEntityLayerStaffLanguage objEntityLanguage = new clsEntityLayerStaffLanguage();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLanguage.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLanguage.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLanguage.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //objEntityLanguage.Date = System.DateTime.Now;
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLanguage.CandidateID = Convert.ToInt32(strId);
        }
        objEntityLanguage.CandidateID = Convert.ToInt32(HiddenCandidateId.Value);

        objEntityLanguage.LanguageId = Convert.ToInt32(ddlQuLang.SelectedItem.Value);
        if (CbxLangWrt.Checked == true)
        {
            objEntityLanguage.LangWrite = 1;
        }
        if (CbxLangRead.Checked == true)
        {
            objEntityLanguage.LangRead = 1;
        }
        if (CbxLangSpk.Checked == true)
        {
            objEntityLanguage.LangSpeak = 1;
        }
        if (cbxLangMotherTongue.Checked == true)
        {
            objEntityLanguage.MotherTongue = 1;
        }

        //objEntityLanguage.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objBusinessLangauage.insertLanguageDtl(objEntityLanguage);

        DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
        string strHtmlLang = ConvertDataTableToHTMLlang(dtLanglist);
        divListLang.InnerHtml = strHtmlLang;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationLang", "SuccessConfirmationLang();", true);
    }
    protected void btnUpdLang_Click(object sender, EventArgs e)
    {

        clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
        //clsQualification
        clsEntityLayerStaffLanguage objEntityLanguage = new clsEntityLayerStaffLanguage();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLanguage.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLanguage.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLanguage.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityLanguage.Date = System.DateTime.Now;
        objEntityLanguage.LangdtlId = Convert.ToInt32(HiddenFieldLangDtlId.Value);
        objEntityLanguage.LanguageId = Convert.ToInt32(ddlQuLang.SelectedItem.Value);
        objEntityLanguage.CandidateID = Convert.ToInt32(HiddenCandidateId.Value);
        if (CbxLangWrt.Checked == true)
        {
            objEntityLanguage.LangWrite = 1;
        }
        if (CbxLangRead.Checked == true)
        {
            objEntityLanguage.LangRead = 1;
        }
        if (CbxLangSpk.Checked == true)
        {
            objEntityLanguage.LangSpeak = 1;
        }

        objBusinessLangauage.updateLanguageDtl(objEntityLanguage);
        //objEntityLanguage.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
        string strHtmlLang = ConvertDataTableToHTMLlang(dtLanglist);
        divListLang.InnerHtml = strHtmlLang;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationLang", "SuccessUpdationLang();", true);
    }

    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLlang(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableLang\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }



        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {




            strHtml += "<tr  >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                //if (j == 0)
                //{
                //    int intCnt = i + 1;
                //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                //}
                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strCandId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();

            //12emp17

            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 0.5%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\"  title=\"Edit\" onclick=\"return updateLangDtlById('" + strId + "','" + strCandId + "');\" >" +
                           "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\"  title=\"Delete\" onclick=\"return deleteLangDtlById('" + strId + "','" + strCandId + "');\" >" +
                                "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
            //12emp17

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }

    public class Language
    {

        public string LangDtlId = "";
        public string LangId = "";
        public string Write = "";
        public string Speak = "";
        public string Read = "";
        public string comment = "";
        public string date = "";
        public string MotherTongue = "";
        public string CandidateID = "";
        public string SklLangList = "";
        public string LangSts = "";
        public string LangName = "";

        public string ConvertDataTableToHTMLlang(DataTable dt)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableLang\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" style=\"height:10%;\"  >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {
                //if (i == 0)
                //{
                //    html += "<th style=\"width:6%; word-wrap:break-word;\">" + dt.Columns[i].ColumnName + "</th>";
                //}
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }


            }


            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {




                strHtml += "<tr  >";



                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    //if (j == 0)
                    //{
                    //    int intCnt = i + 1;
                    //    html += "<td class=\"rowHeight\" style=\"width:6%; word-wrap:break-word;\">" + intCnt + "</td>";
                    //}
                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strCandId = dt.Rows[intRowBodyCount]["CAND_ID"].ToString();



                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;\" onclick=\"return updateLangDtlById('" + strId + "','" + strCandId + "');\" >" +
                               "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;\" onclick=\"return deleteLangDtlById('" + strId + "','" + strCandId + "');\" >" +
                                    "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }
    }

    [WebMethod]
    public static Language updateLangDtlById(string Id, string CandID)
    {
        Language objLang = new Language();
        clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
        //clsQualification
        clsEntityLayerStaffLanguage objEntityLanguage = new clsEntityLayerStaffLanguage();
        objEntityLanguage.LangdtlId = Convert.ToInt32(Id);
        objEntityLanguage.CandidateID = Convert.ToInt32(CandID);
        DataTable dt = objBusinessLangauage.ReadLangDtlById(objEntityLanguage);
        if (dt.Rows.Count > 0)
        {
            objLang.LangDtlId = dt.Rows[0]["STAFF_LANG_ID"].ToString();
            objLang.LangId = dt.Rows[0]["LANGMSTR_ID"].ToString();
            objLang.Read = dt.Rows[0]["STAFF_LANG_READ"].ToString();
            objLang.Write = dt.Rows[0]["STAFF_LANG_WRITE"].ToString();
            objLang.Speak = dt.Rows[0]["STAFF_LANG_SPEAK"].ToString();
            objLang.MotherTongue = dt.Rows[0]["STAFF_LANGMOTHER_TONGUE"].ToString();
            objLang.CandidateID = dt.Rows[0]["CAND_ID"].ToString();
            objLang.LangSts = dt.Rows[0]["LANGMSTR_STATUS"].ToString();
            objLang.LangName = dt.Rows[0]["LANGMSTR_NAME"].ToString();


        }

        return objLang;

    }
    [WebMethod]
    public static Language deleteLangDtlById(string Id, string CandID)
    {
        Language objLang = new Language();
        clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
        //clsQualification
        clsEntityLayerStaffLanguage objEntityLanguage = new clsEntityLayerStaffLanguage();
        objEntityLanguage.LangdtlId = Convert.ToInt32(Id);
        objEntityLanguage.CandidateID = Convert.ToInt32(CandID);
        objBusinessLangauage.deleteLanguageDtl(objEntityLanguage);
        objEntityLanguage.CandidateID = Convert.ToInt32(CandID);
        DataTable dt = objBusinessLangauage.readLangList(objEntityLanguage);
        objLang.SklLangList = objLang.ConvertDataTableToHTMLlang(dt);
        return objLang;
    }

    protected void ddlEduType_SelectedIndexChanged(object sender, EventArgs e)
    {
        EduLvlLoad();
        ddlEduType.Focus();
        ScriptManager.RegisterStartupScript(this, GetType(), "IncrmntConfrmCounterEdu", "IncrmntConfrmCounterEdu();", true);

    }
    //protected void btnFamilySave_Click(object sender, EventArgs e)
    //{
    //    clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
    //    clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityDependent.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        objEntityDependent.User_Id = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    objEntityDependent.EmpUserId = Convert.ToInt32(HiddenCandidateId.Value);
    //    objEntityDependent.Date = System.DateTime.Now;
    //    objEntityDependent.GuardOccp = txtOccuDP.Text.ToUpper();
    //    objEntityDependent.SpsName = txtSpouseNameDP.Text.ToUpper();
    //    objEntityDependent.GuardName = txtHusbandNameDP.Text.ToUpper();

    //    // objEntityDependent.oc = txtPasprtNum.Text;
    //    if
    //        (RbHusbandDP.Checked == true)
    //    {
    //        objEntityDependent.GuardTyp = 0;
    //    }
    //    else if
    //        (RbFatherDP.Checked == true)
    //    {
    //        objEntityDependent.GuardTyp = 1;
    //    }
    //    else
    //    {
    //        objEntityDependent.GuardTyp = 2;
    //    }



    //    if (rblMarrStatus.SelectedItem.Text == "Married")

    //        objEntityDependent.Maritalstst = 1;
    //    else
    //        objEntityDependent.Maritalstst = 0;




    //    objBusinessDependent.insertFamilyDtls(objEntityDependent);
    //    updateDepent(HiddenCandidateId.Value, "");
    //    //string strHtm = ConvertDataTableToHTMLForDependent(dt);
    //    //divReportforDependent.InnerHtml = strHtm;
    //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationMrg", "SuccessConfirmationMrg();", true);

    //}


    //protected void btnUpdateFamily_Click(object sender, EventArgs e)
    //{
    //    Button clickedButton = sender as Button;
    //    clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
    //    clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityDependent.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    if (Session["USERID"] != null)
    //    {
    //        objEntityDependent.User_Id = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("~/Default.aspx");
    //    }
    //    objEntityDependent.DepntId = Convert.ToInt32(HiddenDepntId.Value);
    //    objEntityDependent.EmpUserId = Convert.ToInt32(HiddenCandidateId.Value);
    //    objEntityDependent.Date = System.DateTime.Now;
    //    objEntityDependent.GuardOccp = txtOccuDP.Text.ToUpper();
    //    objEntityDependent.SpsName = txtSpouseNameDP.Text.ToUpper();
    //    objEntityDependent.GuardName = txtHusbandNameDP.Text.ToUpper();

    //    // objEntityDependent.oc = txtPasprtNum.Text;
    //    if
    //        (RbHusbandDP.Checked == true)
    //    {
    //        objEntityDependent.GuardTyp = 0;
    //    }
    //    else if
    //        (RbFatherDP.Checked == true)
    //    {
    //        objEntityDependent.GuardTyp = 1;
    //    }
    //    else
    //    {
    //        objEntityDependent.GuardTyp = 2;
    //    }

    //    if (rblMarrStatus.SelectedItem.Text == "Married")

    //    objEntityDependent.Maritalstst = 1;
    //    else
    //        objEntityDependent.Maritalstst = 0;




    //    objBusinessDependent.UpdateFamilyDtls(objEntityDependent);
    //    updateDepent(HiddenCandidateId.Value, "");
    //    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationMrg", "SuccessUpdationMrg();", true);



    //}
    //load worker
    public void LoadCandidates()
    {
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJoiningWorker.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = objBusinessLayerJoiningWorker.ReadCandidate(objEntityJoiningWorker);
        ddlCandidateName.Items.Clear();
        if (dtSubConrt.Rows.Count > 0)
        {

            ddlCandidateName.DataSource = dtSubConrt;
            ddlCandidateName.DataTextField = "CAND_NAME";
            ddlCandidateName.DataValueField = "CAND_ID";
            ddlCandidateName.DataBind();

        }

        ddlCandidateName.Items.Insert(0, "--SELECT CANDIDATE--");


    }
    protected void btnCnfrmPrsn_Click(object sender, EventArgs e)
    {
        clsEntityCandidatelogin objEntityCandLogin = new clsEntityCandidatelogin();
        clsBusiness_Candidate_Login objBusinessCandLogin = new clsBusiness_Candidate_Login();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCandLogin.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCandLogin.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId1 = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId1);
        objEntityCandLogin.CandidateId = Convert.ToInt32(strId);
        objBusinessCandLogin.UpdateCnfrmSts(objEntityCandLogin);
        int intcandidateid = Convert.ToInt32(HiddenCandidateId.Value);
        Response.Redirect("~/Master/gen_Emply_Personal_Informn/gen_Emply_Personal_Informn.aspx?CANDID=" + strRandomMixedId);
    }
    public void BindDdlMonths(string strMonth = null)
    {
        ddlMonthEdu.Items.Clear();
        var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        for (int i = 0; i < months.Length - 1; i++)
        {
            ddlMonthEdu.Items.Add(new ListItem(months[i], (i + 1).ToString()));
        }
        if (strMonth != null)
        {
            if (ddlMonthEdu.Items.FindByValue(strMonth) != null)
            {
                ddlMonthEdu.Items.FindByValue(strMonth).Selected = true;
            }
        }
        ddlMonthEdu.Items.Insert(0, "--MONTH--");
    }
    public void BindDdlYears(string strYear = null)
    {
        ddlYearEdu.Items.Clear();
        var currentYear = DateTime.Today.Year;
        for (int i = 50; i >= 0; i--)
        {

            ddlYearEdu.Items.Add((currentYear - i).ToString());
        }
        if (strYear != null)
        {
            if (ddlYearEdu.Items.FindByValue(strYear) != null)
            {
                ddlYearEdu.Items.FindByValue(strYear).Selected = true;
            }
        }
        ddlYearEdu.Items.Insert(0, "--YEAR--");
    }
    
          [WebMethod]
    public static string ReadDepntDtlTable(string id)
    {
        Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn obj = new Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn();
        clsBusinessLayerStaffFamilyDtls objBusinessDependent = new clsBusinessLayerStaffFamilyDtls();
        clsEntityLayerFamilyDetails objEntityDependent = new clsEntityLayerFamilyDetails();
        objEntityDependent.EmpUserId = Convert.ToInt32(id); 
        DataTable dt = objBusinessDependent.readDependentList(objEntityDependent);
    
        string strHtm = obj.ConvertDataTableToHTMLForDependent(dt);
        return strHtm;
    }

          [WebMethod]
          public static string ReadImmigrationTable(string id,string copr,string org)
          {
              Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn obj = new Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn();
              clsBusinessLayerStaffImmigration objBusinessImigration = new clsBusinessLayerStaffImmigration();
              clsEntityStaffImmigration objEntityImigrationDtls = new clsEntityStaffImmigration();
              objEntityImigrationDtls.CandId = Convert.ToInt32(id);
              objEntityImigrationDtls.CorpId = Convert.ToInt32(copr);
              objEntityImigrationDtls.OrgId =Convert.ToInt32(org);
              DataTable dtImigrations1 = objBusinessImigration.ReadStaffImmigration(objEntityImigrationDtls);
              string strHtm = obj.ConvertDataTableToHTMLForImig(dtImigrations1);

             
              return strHtm;
          }

    
             [WebMethod]
          public static string[] ReadQualificTablee(string id, string copr, string org)
          {
              string[] strHtm = new string[5];
              Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn obj = new Master_gen__Cand_Personal__Informn_gen__Cand_Personal__Informn();
              clsBusinessLayerStaffEducation objBusinessEducation = new clsBusinessLayerStaffEducation();
              clsEntityLayerStaffEducation objEntityEducation = new clsEntityLayerStaffEducation();


              clsBusinessLayerStaffLanguage objBusinessLangauage = new clsBusinessLayerStaffLanguage();
              //clsQualification
              clsEntityLayerStaffLanguage objEntityLanguage = new clsEntityLayerStaffLanguage();
              ClsBusinessLayerStaffWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerStaffWorkExperience();
              //clsQualification
              clsEntityLayerStaffWorkExperience objEntityWorkExperience = new clsEntityLayerStaffWorkExperience();


              objEntityEducation.CandidateID = Convert.ToInt32(id);
              objEntityEducation.Corporate_id = Convert.ToInt32(copr);
              objEntityEducation.Organisation_id = Convert.ToInt32(org);

              objEntityLanguage.CandidateID = Convert.ToInt32(id);
              objEntityLanguage.Corporate_id = Convert.ToInt32(copr);
              objEntityLanguage.Organisation_id = Convert.ToInt32(org);

              objEntityWorkExperience.CandidateID = Convert.ToInt32(id);
              objEntityWorkExperience.Corporate_id = Convert.ToInt32(copr);
              objEntityWorkExperience.Organisation_id = Convert.ToInt32(org);

              DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
               strHtm[0] = obj.ConvertDataTableToHTMLeductn(dtEdulist);


              DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
              strHtm[1] = obj.ConvertDataTableToHTMLlang(dtLanglist);


              DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
              strHtm[2] = obj.ConvertDataTableToHTMLwrkExp(dtlist);
           

             
              return strHtm;
          }
}