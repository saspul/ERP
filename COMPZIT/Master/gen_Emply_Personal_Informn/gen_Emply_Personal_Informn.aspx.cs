using System;
using System.Collections.Generic;
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
using System.Web.Mail;
using BL_Compzit.BusineesLayer_HCM;
using Newtonsoft.Json;

using System.Linq;

public partial class Master_gen__Emply_Personal__Informn_gen__Emply_Personal__Informn : System.Web.UI.Page
{//Functional
    #region Enumerations;
    //Enumeration for identifying apllication typeid 
    private enum APPS
    {
        APP_ADMINSTRATION = 1,
        SALES_FORCE_AUTOMATION = 2,
        AUTO_WORKSHOP_MANAGEMENT_SYSTEM = 3,
        GUARANTEE_MANAGEMENT_SYSTEM = 4,
        HUMAN_CAPITAL_MANAGEMENT = 5,
        FINANCE_MANAGEMENT_SYSTEM = 6,
        PROCUREMENT_MANAGEMENT_SYSTEM = 7,
    }
    private enum USERLIMITED
    {
        ISLIMITED = 1,
        NOTLIMITED = 2

    }

    #endregion
    clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();

    DataTable dtCorpDivVisibility = new DataTable();
    clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
    clsEntityLayerContactDtls objEntityEmp = new clsEntityLayerContactDtls();
    clsBusinessLayerContactDtls objBusinessEmp = new clsBusinessLayerContactDtls();
    protected void Page_Load(object sender, EventArgs e)
    {

        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableModify = 0, intEnableRenew = 0;
        txtLoginName.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtUsrPwd.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtUsrConPwd.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLicenseExpDate.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLicenceNumbr.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxMustLogin.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxLimitedUser.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxPswExpiry.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxPswdVisible.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxDutyRoster.Attributes.Add("onkeypress", "return DisableEnter(event)");
        OccupyDate.Attributes.Add("onkeypress", "return DisableEnter(event)");
        Txtemplyid.Attributes.Add("onkeypress", "return DisableEnter(event)");
        TxtFrstName.Attributes.Add("onkeypress", "return isTag(event)");
        TxtFrstName.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");

        TxtMidleName.Attributes.Add("onkeypress", "return isTag(event)");
        TxtMidleName.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        TxtLstName.Attributes.Add("onkeypress", "return isTag(event)");
        TxtLstName.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        txtBirthPlc.Attributes.Add("onkeypress", "return isTag(event)");
        txtBirthPlc.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        txtNickName.Attributes.Add("onkeypress", "return isTag(event)");
        txtNickName.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        TxtDOB.Attributes.Add("onkeypress", "return isTag(event)");
        TxtDOB.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        ddlNationality.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlNationality.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        ddlReligion.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlReligion.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        ddlBldGrp.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlBldGrp.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        cbxSmoker.Attributes.Add("onkeypress", "return isTag(event)");
        cbxSmoker.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        cbxAlchlc.Attributes.Add("onkeypress", "return isTag(event)");
        cbxAlchlc.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        RadioButtonMale.Attributes.Add("onkeypress", "return isTagEnter(event)");
        RadioButtonMale.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        RadioButtonFemale.Attributes.Add("onkeypress", "return isTag(event)");
        RadioButtonFemale.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        RadioButtonOther.Attributes.Add("onkeypress", "return isTag(event)");
        RadioButtonOther.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        RadioMarried.Attributes.Add("onkeypress", "return isTag(event)");
        RadioMarried.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");
        RadioUnmarried.Attributes.Add("onkeypress", "return isTag(event)");
        RadioUnmarried.Attributes.Add("onchange", "IncrmntConfrmCounterOther()");

        //start dependent
        txtDepndtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtDepndtName.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        ddlReltnshp.Attributes.Add("onkeypress", "return isTag(event)");
        ddlReltnshp.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        txtPasprtNum.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        txtPasprtNum.Attributes.Add("onkeypress", "return isTag(event)");
        txtPsprtDate.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        txtPsprtDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtRPnum.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        txtRPnum.Attributes.Add("onkeypress", "return isTag(event)");
        txtRPissDate.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        txtRPissDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtRPexpDate.Attributes.Add("onchange", "IncrmntConfrmCounterDepnt()");
        txtRPexpDate.Attributes.Add("onkeypress", "return isTag(event)");

        txtBasicpayFrm.Attributes.Add("onchange", "IncrmntConfrmCounterSalryPaygrd()");
        txtAmntRgeFrm.Attributes.Add("onchange", "IncrmntConfrmCounterSalryAllwnce()");
        txtAmntRedcnFrom.Attributes.Add("onchange", "IncrmntConfrmCounterSalryDedctn()");
        txtBasicpayFrm.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmntRgeFrm.Attributes.Add("onkeypress", "return isTag(event)");
        txtAmntRedcnFrom.Attributes.Add("onkeypress", "return isTag(event)");
        ddlPayGrd.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlAddtn.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddldedctn.Attributes.Add("onkeypress", "return DisableEnter(event)");

        txtAdr1.Attributes.Add("onkeypress", "return isTag(event)");
        txtAdr1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAdr2.Attributes.Add("onkeypress", "return isTag(event)");
        txtAdr2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAdr3.Attributes.Add("onkeypress", "return isTag(event)");
        txtAdr3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCountryCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlCountryCD.Attributes.Add("onchange", "changeCountryCD()");
        ddlStateCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlStateCD.Attributes.Add("onchange", "changeStateCD()");
        ddlCityCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlCityCD.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPostalCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtPostalCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhone.Attributes.Add("onkeypress", "return isNumber(event)");
        txtPhone.Attributes.Add("onblur", "return BlurNotNumber('" + txtPhone.ClientID + "')");
        txtPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtMobile.Attributes.Add("onkeypress", "return isTag(event)");
        txtMobile.Attributes.Add("onkeypress", "return isNumber(event)");
        txtMobile.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmail.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtFax.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtFax.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        //Communication Address
        txtCommuAddr1.Attributes.Add("onkeypress", "return isTag(event)");
        txtCommuAddr1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCommuAddr2.Attributes.Add("onkeypress", "return isTag(event)");
        txtCommuAddr2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCommuAddr3.Attributes.Add("onkeypress", "return isTag(event)");
        txtCommuAddr3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCommuCountryCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlCommuCountryCD.Attributes.Add("onchange", "changeCountryCommu()");
        ddlCommuStateCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlCommuStateCD.Attributes.Add("onchange", "changeStateCommu()");
        ddlCommuCityCD.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlCommuCityCD.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCommuPostalCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtCommuPostalCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCommuPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtCommuPhone.Attributes.Add("onkeypress", "return isNumber(event)");
        txtCommuPhone.Attributes.Add("onblur", "return BlurNotNumber('" + txtCommuPhone.ClientID + "')");
        txtCommuPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCommuMobile.Attributes.Add("onkeypress", "return isTag(event)");
        txtCommuMobile.Attributes.Add("onkeypress", "return isNumber(event)");
        txtCommuMobile.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCmmuEmail.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtCmmuEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtCommuFax.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtCommuFax.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        // Emergency datails
        txtEmrgName.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmrgName.Attributes.Add("onchange", "IncrmntConfrmCounterEmrg()");
        ddlEmrgRelat.Attributes.Add("onkeypress", "return isTagEnter(event)");
        ddlEmrgRelat.Attributes.Add("onchange", "IncrmntConfrmCounterEmrg()");
        txtEmrgAddr.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtEmrgPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmrgPhone.Attributes.Add("onkeypress", "return isNumber(event)");
        txtEmrgPhone.Attributes.Add("onblur", "return BlurNotNumber('" + txtEmrgPhone.ClientID + "')");
        txtEmrgMobile.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmrgMobile.Attributes.Add("onkeypress", "return isNumber(event)");
        txtEmrgMobile.Attributes.Add("onchange", "IncrmntConfrmCounterEmrg()");
        txtEmrgEmail.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtEmrgFax.Attributes.Add("onkeypress", "return isTagEnter(event)");

        RadioButtonDocList.Attributes.Add("onkeypress", "return isTag(event)");
        Textnumber.Attributes.Add("onkeypress", "return isTag(event)");
        TextIssuueddate.Attributes.Add("onkeypress", "return isTag(event)");
        TxtdivExpiryDate.Attributes.Add("onkeypress", "return isTag(event)");
        Txtelgblestats.Attributes.Add("onkeypress", "return isTag(event)");
        TxtEligiblervwdate.Attributes.Add("onkeypress", "return isTag(event)");
        TxtComments.Attributes.Add("onkeypress", "return isTagEnter(event)");
        TxtRsnimig.Attributes.Add("onkeypress", "return isTag(event)");
        Textnumber.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");
        TextIssuueddate.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");
        TxtdivExpiryDate.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");
        Txtelgblestats.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");
        TxtEligiblervwdate.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");
        TxtComments.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");
        Txtelgblestats.Attributes.Add("onkeypress", "return isTag(event)");
        Txtelgblestats.Attributes.Add("onchange", "IncrmntConfrmCounterImig()");

        //Work Experience
        txtWrkCompny.Attributes.Add("onkeypress", "return isTag(event)");
        txtWrkCompny.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        txtWrkJobTle.Attributes.Add("onkeypress", "return isTag(event)");
        txtWrkJobTle.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        txtWrkFromDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtWrkFromDate.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        txtWrkToDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtWrkToDate.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        txtWrkCmnt.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtWrkCmnt.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        cbxRefCheck.Attributes.Add("onkeypress", "return isTag(event)");
        cbxRefCheck.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        txtWrkRefName.Attributes.Add("onkeypress", "return isTag(event)");
        txtWrkRefName.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        txtWrkRefDesg.Attributes.Add("onkeypress", "return isTag(event)");
        txtWrkRefDesg.Attributes.Add("onchange", "IncrmntConfrmCounterWrkExp()");
        //Education
        ddlEduLvl.Attributes.Add("onkeypress", "return isTag(event)");
        ddlEduLvl.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        txtEduInstite.Attributes.Add("onkeypress", "return isTag(event)");
        txtEduInstite.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        txtEduMjr.Attributes.Add("onkeypress", "return isTag(event)");
        txtEduMjr.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        txtEduYear.Attributes.Add("onkeypress", "return isTag(event)");
        txtEduYear.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        txtEduGPA.Attributes.Add("onkeypress", "return isTag(event)");
        txtEduGPA.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        txtEduStrtDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtEduStrtDate.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        txtEduEndDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtEduEndDate.Attributes.Add("onchange", "IncrmntConfrmCounterEdu()");
        //Skill & Certification
        ddlSCSkill.Attributes.Add("onkeypress", "return isTag(event)");
        ddlSCSkill.Attributes.Add("onchange", "IncrmntConfrmCounterSklCer()");
        txtSCCertfcn.Attributes.Add("onkeypress", "return isTag(event)");
        txtSCCertfcn.Attributes.Add("onchange", "IncrmntConfrmCounterSklCer()");
        txtSCYearExp.Attributes.Add("onkeypress", "return isTag(event)");
        txtSCYearExp.Attributes.Add("onchange", "IncrmntConfrmCounterSklCer()");
        txtSCcmnt.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtSCcmnt.Attributes.Add("onchange", "IncrmntConfrmCounterSklCer()");
        //Language
        ddlQuLang.Attributes.Add("onkeypress", "return isTag(event)");
        ddlQuLang.Attributes.Add("onchange", "IncrmntConfrmCounterLang()");
        CbxLangWrt.Attributes.Add("onkeypress", "return isTag(event)");
        CbxLangWrt.Attributes.Add("onchange", "IncrmntConfrmCounterLang()");
        CbxLangRead.Attributes.Add("onkeypress", "return isTag(event)");
        CbxLangRead.Attributes.Add("onchange", "IncrmntConfrmCounterLang()");
        CbxLangSpk.Attributes.Add("onkeypress", "return isTag(event)");
        CbxLangSpk.Attributes.Add("onchange", "IncrmntConfrmCounterLang()");
        txtLangCmnt.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtLangCmnt.Attributes.Add("onchange", "IncrmntConfrmCounterLang()");

        txtJoineddate.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        txtpermanencyDate.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        ddlDepartment.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        TxtJobDesc.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        ddlDesignation.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        ddlEmployeeType.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        TxtjobTitle.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        ddtype.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        Txtprojloc.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");
        ddlSponsor.Attributes.Add("onchange", "IncrmntConfrmCounterJob()");

        txtJoineddate.Attributes.Add("onkeypress", "return isTag(event)");
        txtProbationdate.Attributes.Add("onkeypress", "return isTag(event)");
        txtpermanencyDate.Attributes.Add("onkeypress", "return isTag(event)");
        ddlDepartment.Attributes.Add("onkeypress", "return isTag(event)"); ;
        TxtJobDesc.Attributes.Add("onkeypress", "return isTag(event)");
        ddlDesignation.Attributes.Add("onkeypress", "return isTag(event)");
        ddlDivision.Attributes.Add("onkeypress", "return isTag(event)");
        ddlEmployeeType.Attributes.Add("onkeypress", "return isTag(event)");
        TxtjobTitle.Attributes.Add("onkeypress", "return isTag(event)");
        ddlProject.Attributes.Add("onkeypress", "return isTag(event)");
        ddtype.Attributes.Add("onkeypress", "return isTag(event)");
        Txtprojloc.Attributes.Add("onkeypress", "return isTag(event)");
        ddlSponsor.Attributes.Add("onkeypress", "return isTag(event)");
        ddlprojectassign.Attributes.Add("onkeypress", "return isTag(event)");
        txtprojectstartdate.Attributes.Add("onkeypress", "return isTag(event)");
        txtProjectEndDate.Attributes.Add("onkeypress", "return isTag(event)");
        ddlprojectassign.Attributes.Add("onchange", "IncrmntConfrmCounterProj()");
        txtprojectstartdate.Attributes.Add("onchange", "IncrmntConfrmCounterProj()");
        txtProjectEndDate.Attributes.Add("onchange", "IncrmntConfrmCounterProj()");

        //emp-0043 start
        RadioBank.Attributes.Add("onkeypress", "IncrmntConformCounterOther()");
        RadioCash.Attributes.Add("onchange", "IncrmntConformCounterOther()");
        RadioBank.Attributes.Add("onkeypress", "IncrmntConformCounterOther()");
        RadioCash.Attributes.Add("onchange", "IncrmntConformCounterOther()");
        //emp-0043 end

        if (!IsPostBack)
        {
            LoadProbationDropDowns();
            LoadTaskTimeDropDowns();
            hiddenBankDtls.Value = "";
            HiddenAccmdtnSaveChk.Value = "0";
            btnCancelCan.Visible = false;
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            hiddenCurrentDate.Value = strCurrentDate;
            int intCorpId = 0, intOrgId = 0, intuserId = 0;
            hiddenDsgnControlId.Value = "C";
            HiddenEmployeeId.Value = "0";// emp0025

            if (Session["DSGN_CONTROL"] != null)
            {
                hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            AccommodationLoad();
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                HiddenUserId.Value = Session["USERID"].ToString();
                intuserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            RadioButtonDocList.SelectedValue = "1";
            HiddenPayGradechnge.Value = "0";
            CountryLoadCD();
            CountryLoadCommu();
            LoadRelation();
            Visaload();
            ddlload();
            CountryLoadforImig();
            projectLoad();
            DepartmentLoad();
            SponsorLoad();
            DesignationLoad();
            // DivisionLoad();
            CountryLoad();
            AccsbleBULoad();
            ReprtingEmployeeLoad("0");
            ReligionLoad();
            BloodgrpLoad();
            RelationshipLoad();
            TxtFrstName.Focus();
            //SALARY DETAILS

            HiddenTotalpay.Value = "0.00";
            HiddenSalarSummry.Value = "0.00";
       
            HiddenPayGrdeId.Value = "";

            ddlAddtn.Items.Clear();
            ddldedctn.Items.Clear();
            ddlAddtn.Items.Insert(0, "--SELECT SALARY ADDITION--");
            ddldedctn.Items.Insert(0, "--SELECT SALARY DEDCTION--");
            ButtonAdd.Attributes.Add("style", "display:block;width: 95%");
            PayGradeLoad();
            HiddenddlAllDed.Value = "";
            HiddnEnableCacel.Value = "1";
            ButtnSalryupd.Attributes.Add("style", "display:none;width: 95%");
            int intImageMaxSize = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SIZE.EMPLOYEE_PERSONAL);
            hiddenUserImageSize.Value = intImageMaxSize.ToString();
            BtnupdateJob.Visible = false;
            EduLvlLoad();
            SkillLoad();
            LanguageLoad();
            BankLoad("0", 0);//bank

            btnUpdateCD.Visible = false;
            btnUpdatePD.Visible = false;
            //SALARY DETAILS
            radioTotlAmnt.Checked = true;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.JOINING_DATE_LIMIT
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            hiddenDfltCurrencyMstrId.Value = "0";
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                if (dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString() != "")
                {
                    hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                }
                HiddenFieldJoinDateLimit.Value = dtCorpDetail.Rows[0]["JOINING_DATE_LIMIT"].ToString();               
            }

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusiness.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }

            //SALARY DETAILS 0008
            clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

            //IMMIGRATION
            clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
            clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
            ClsBusinessLayerWorkExperience objBusinessLayerWorkExperience1 = new ClsBusinessLayerWorkExperience();
            ClsEntityLayerWorkExperience objEntityWorkExperience1 = new ClsEntityLayerWorkExperience();

            DataTable dtlist1 = objBusinessLayerWorkExperience1.readWrkExpList(objEntityWorkExperience1);
            string strHtmList1 = ConvertDataTableToHTMLwrkExp(dtlist1);
            divListWrkExp.InnerHtml = strHtmList1;
            dtlist1 = objBusinessLayerWorkExperience1.readWrkExpList(objEntityWorkExperience1);
            strHtmList1 = ConvertDataTableToHTMLwrkExp(dtlist1);
            divListWrkExp.InnerHtml = strHtmList1;
            //For Education list
            ClsBusinessLayerEducation objBusinessEducation1 = new ClsBusinessLayerEducation();
            ClsEntityLayerEducation objEntityEducation1 = new ClsEntityLayerEducation();

            DataTable dtEdulist1 = objBusinessEducation1.readEduList(objEntityEducation1);
            string strHtmListEdu1 = ConvertDataTableToHTMLeductn(dtEdulist1);
            divListEdu.InnerHtml = strHtmListEdu1;
            //For Skill &Certification list
            ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn1 = new ClsBusinessLayerSkillCertfn();
            ClsEntityLayerSkillCertifcn objEntitySkillCertfcn2 = new ClsEntityLayerSkillCertifcn();

            DataTable dtSkCerlist1 = objBusinessSkillCertfcn1.readSklCerList(objEntitySkillCertfcn2);
            string strHtmListSklCer1 = ConvertDataTableToHTMLsklCer(dtSkCerlist1);
            divSkCerList.InnerHtml = strHtmListSklCer1;
            //For language list
            ClsBusinessLayerLanguage objBusinessLangauage1 = new ClsBusinessLayerLanguage();
            ClsEntityLayerLanguage objEntityLanguage1 = new ClsEntityLayerLanguage();

            DataTable dtLanglist1 = objBusinessLangauage1.readLangList(objEntityLanguage1);
            string strHtmlLang1 = ConvertDataTableToHTMLlang(dtLanglist1);
            divListLang.InnerHtml = strHtmlLang1;
            //evm-0024
            ddlJobRole.Items.Insert(0, "--Select Job Role--");
            ddlJobRole.SelectedIndex = 0;
            //end
            if (Request.QueryString["Id"] != null)
            {

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //start-Qualification
                EduLvlLoad();
                SkillLoad();
                LanguageLoad();
                HiddenEmpUserId.Value = strId;
                HiddenEmployeeMasterId.Value = strId;
                //for work experience list
                ClsBusinessLayerWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerWorkExperience();
                ClsEntityLayerWorkExperience objEntityWorkExperience = new ClsEntityLayerWorkExperience();
                objEntityWorkExperience.EmpUser_id = Convert.ToInt32(strId);
                DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
                string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
                divListWrkExp.InnerHtml = strHtmList;
                //For Education list
                ClsBusinessLayerEducation objBusinessEducation = new ClsBusinessLayerEducation();
                ClsEntityLayerEducation objEntityEducation = new ClsEntityLayerEducation();
                objEntityEducation.EmpUser_id = Convert.ToInt32(strId);
                DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
                string strHtmListEdu = ConvertDataTableToHTMLeductn(dtEdulist);
                divListEdu.InnerHtml = strHtmListEdu;
                //For Skill &Certification list
                ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
                ClsEntityLayerSkillCertifcn objEntitySkillCertfcn = new ClsEntityLayerSkillCertifcn();
                objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(strId);
                DataTable dtSkCerlist = objBusinessSkillCertfcn.readSklCerList(objEntitySkillCertfcn);
                string strHtmListSklCer = ConvertDataTableToHTMLsklCer(dtSkCerlist);
                divSkCerList.InnerHtml = strHtmListSklCer;
                //For language list
                ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
                ClsEntityLayerLanguage objEntityLanguage = new ClsEntityLayerLanguage();
                objEntityLanguage.EmpUser_id = Convert.ToInt32(strId);
                DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
                string strHtmlLang = ConvertDataTableToHTMLlang(dtLanglist);
                divListLang.InnerHtml = strHtmlLang;

                HiddenEmplyId.Value = strId;
                objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(strId);
                objEntityEmpSlary.Organisation_Id = intOrgId;
                objEntityEmpSlary.CorpOffice_Id = intCorpId;
                objEntityEmpSlary.User_Id = intuserId;

                string strEmplCheck = "";
                strEmplCheck = objEmpSalary.EpmlyCheckPayGrade(objEntityEmpSlary);
                if (strEmplCheck != "" && strEmplCheck != "0")
                {
                    updateSalary(strId);
                }

                HiddenEmpUserId.Value = strId;
                clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
                //check wheather employee personal details added
                string strCount = objBusinessPersonalDtls.CheckPerDtlAddedOrNot(strId);
                //update personal details
                if (strCount != "0")
                {
                    LblEntryother.Text = "Edit Other Details";
                    updatePD(strId);
                }
                else
                {
                    LblEntryother.Text = "Add Other Details";
                    btnUpdatePD.Visible = false;
                    btnAddPD.Visible = true;
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERSONAL_DETAILS);
                    objEntityCommon.CorporateID = intCorpId;
                    objEntityCommon.Organisation_Id = intOrgId;
                    //EVM-0024
                    //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                    //string year = DateTime.Today.Year.ToString();
                    //Txtemplyid.Text = "EMP/" + year + "/" + strNextId;
                    //txtRefNum.Text = "REF/" + year + "/" + strNextId;
                }
                clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
                clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
                DataTable dt = objBusinessDependent.readDependentList(strId);
                string strHtm = ConvertDataTableToHTML(dt);
                divReport.InnerHtml = strHtm;
                intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
                DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intuserId, intUsrRolMstrId);
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
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                        {
                            intEnableModify = 1;

                        }
                        else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                        {
                            intEnableRenew = 1;
                        }

                    }
                }
                if (intEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divRenewImg.Visible = true;
                }
                else
                {
                    divRenewImg.Visible = false;
                }

                TxtPeriod.Enabled = false;
                TxtPeriod.Text = "0";

                clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
                HiddenEmpoyeeid.Value = strId;
                HiddenJobProbId.Value = "";

                objEntityImigrationDtls.CorpId = intCorpId;
                objEntityImigrationDtls.OrgId = intOrgId;
                objEntityImigrationDtls.Imig_Emp_id = Int32.Parse(strId);
                HiddenRPStatus.Value = "0";//22/02 evm-0024
                Hiddenempid.Value = strId;
                HiddenEmployeeMasterId.Value = strId;
                DataTable dtImigrations = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);
                if (dtImigrations.Rows.Count > 0)
                {
                    //22/02 evm-0024
                    for (int intimgCount = 0; intimgCount < dtImigrations.Rows.Count; intimgCount++)
                    {
                        if (dtImigrations.Rows[intimgCount]["DOCUMENT"].ToString() == "RP")
                        {
                            HiddenRPStatus.Value = "1";

                        }
                    }//end
                    ScriptManager.RegisterStartupScript(this, GetType(), "show_clearbutton", "show_clearbutton();", true);
                }
                else
                {
                    RadioButtonDocList.SelectedValue = "1";
                    ScriptManager.RegisterStartupScript(this, GetType(), "show_clearbutton", "show_clearbutton();", true);

                    ScriptManager.RegisterStartupScript(this, GetType(), "hide_updatebutton", "hide_updatebutton();", true);
                    LabelImmighead.Text = "Add Immigration";
                    RadioButtonDocList.SelectedValue = "1";
                }

                strHtm = ConvertDataTableToHTMLImmigration(dtImigrations);
                //Write to divReport
                divImigList.InnerHtml = strHtm;
                DataTable dtReadContctDtls = new DataTable();
                HiddenContactUserId.Value = strId;
                objEntityEmp.EmpID = Convert.ToInt32(HiddenContactUserId.Value);
                dtReadContctDtls = objBusinessEmp.ReadContactDtlsById(objEntityEmp);
                if (dtReadContctDtls.Rows.Count > 0)
                {
                    update_Contact_dtls(HiddenEmployeeMasterId.Value);
                    btnUpdateCD.Visible = true;
                    btnAddCD.Enabled = false;
                    HiddenEmployeeMasterId.Value = strId;
                    //evm-0024
                    if (dtReadContctDtls.Rows.Count > 0)
                    {

                        if (ddlIssuedby.Items.FindByValue(dtReadContctDtls.Rows[0]["CNTRY_ID"].ToString()) != null)
                        {
                            ddlIssuedby.ClearSelection();
                            ddlIssuedby.Items.FindByValue(dtReadContctDtls.Rows[0]["CNTRY_ID"].ToString()).Selected = true;

                        }
                    }
                    //end
                }
                else
                {
                    btnAddCD.Enabled = true;
                    btnUpdateCD.Visible = false;
                    btnClearCD.Enabled = true;
                    HiddenContactUserId.Value = strId;
                    HiddenEmployeeMasterId.Value = strId;
                }
                // END CONTACT DETAILS
            }
           
            //evm-0024
            clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
            objEntityUsrRegistr.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.UserId);
            DataTable dtNextId = objBusinessLayerUserRegisteration.ShowNextId(objEntityUsrRegistr);
            objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
            //Start:-Empcode

            //string stryear = DateTime.Today.Year.ToString();
            int intNewIncrNextId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"].ToString()) + 1;
            //txtEmployeeCode.Text = "ALB/" + stryear + "/" + intNewIncrNextId;
            HiddenFieldNewNextId.Value = intNewIncrNextId.ToString();
            //end

            //End:-Empcode
            //functional
            objEntityUsrRegistr.UserCrprtId = intCorpId;  //emp00025
            DataTable dtcrprtSts = objBusinessLayerUserRegisteration.ReadCrprtSts(objEntityUsrRegistr);
            if (dtcrprtSts.Rows.Count > 0)
            {

                if (dtcrprtSts.Rows[0]["EMPID_AUTOFILL_STS"].ToString() == "1")
                {
                    txtEmployeeCode.Enabled = true;
                }
                else
                {
                    txtEmployeeCode.Enabled = false;
                }
            }

            int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);

            clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();

         
            
         
            
            clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
            DataTable dtUserDetails = new DataTable();

            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityDsgnation.DesignationUserId = intUserId;

            dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
            if (dtUserDetails.Rows.Count > 0)
            {
                intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());

            }
            if (intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED))
            {

                cbxLimitedUser.Enabled = true;
            }
            else
            {

                cbxLimitedUser.Enabled = false;
            }

            divAutoWorkshopSection.Style.Add("display", "none");
            divLoginDetailsSection.Style.Add("display", "none");

            divDiv.Visible = false;
            bussiDiv.Visible = false;
            divDept.Visible = false;
            hiddenDsgnContrl.Value = "";
            UserTypeLoad();
            BindCompzitModules();
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                Hiddenusermode.Value = "0";
                lblEntry.Text = "Edit Employee";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

                LoadUsr();
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId1 = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId1);
                Resigncheck(strId);
                HiddenEmpUserId.Value = strId;
                Update(strId, "EDIT");

            }
            else if (Request.QueryString["CANDID"] != null)
            {

                ////emp0021//////
                ScriptManager.RegisterStartupScript(this, GetType(), "IsAdd", "IsAdd();", true);


                string strRandomMixedId = Request.QueryString["CANDID"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Hiddenusermode.Value = "0";
                updateOtherDtls(strId);
                updateImigrationDtls(strId);
                updateDepent(strId);
                Update_ContactDtls(strId);
                LoadUsr();
                DropDownBind();

                Update_PersonalDtls(strId);
                designationLoadData();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnCancelCan.Visible = true;
                btnCancel.Visible = false;
            }
            else if (Request.QueryString["WORKERID"] != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "IsAdd", "IsAdd();", true);

                ////emp0021//////


                string strRandomMixedId = Request.QueryString["WORKERID"].ToString();
                hiddenWorkerId.Value = strRandomMixedId;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Hiddenusermode.Value = "1";
                LoadUsr();
                DropDownBind();
                updateWrksDtls(strId);
                designationLoadData();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                Hiddenusermode.Value = "0";

                lblEntry.Text = "View Employee";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                divShowPassword.Visible = false;
                divCPassword.Visible = false;
                divPassword.Visible = false;
                TxtFrstName.Enabled = false;
                ddlUsrDsgn.Enabled = false;
                ddlEmpType.Enabled = false;
                txtNationalIdNmbr.Enabled = false;
               // txtEmployeeCode.Enabled = false;   emp00025
                txtUsrMob.Enabled = false;
                txtUsrEmail.Enabled = false;
                cbxStatus.Enabled = false;
                cbxReadMail.Enabled = false;
                cbxMailSendStatus.Enabled = false;
                cbxlCorporateOffc.Enabled = false;
                cbxlCorporateDvsn.Enabled = false;
                ddlUsrCorporate.Enabled = false;
                txtLoginName.Enabled = false;
                cbxLimitedUser.Enabled = false;
                cbxPswExpiry.Enabled = false;

                txtLicenceNumbr.Enabled = false;
                txtLicenseExpDate.Enabled = false;
                ddlAccommodatn.Enabled = false;
                cbxDutyRoster.Enabled = false;

                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, "VIEW");
            }

            else
            {
                Hiddenusermode.Value = "0";

                lblEntry.Text = "Add Employee";
                ScriptManager.RegisterStartupScript(this, GetType(), "IsAdd", "IsAdd();", true);

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;

                divShowPassword.Visible = true;
                divCPassword.Visible = true;
                divPassword.Visible = true;
                //immigration
                clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
                objEntityImigrationDtls.CorpId = intCorpId;
                objEntityImigrationDtls.Imig_Emp_id = 1;
                objEntityImigrationDtls.OrgId = intOrgId;
                RadioButtonDocList.SelectedValue = "1";
                ScriptManager.RegisterStartupScript(this, GetType(), "show_clearbutton", "show_clearbutton();", true);

                ScriptManager.RegisterStartupScript(this, GetType(), "hide_updatebutton", "hide_updatebutton();", true);
                LabelImmighead.Text = "Add Immigration";
                DataTable dtImigrations = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);
                string strHtm = ConvertDataTableToHTMLImmigration(dtImigrations);
                divImigList.InnerHtml = strHtm;

                ScriptManager.RegisterStartupScript(this, GetType(), "show_Resigndiv", "show_Resigndiv();", true);

                clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
                clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
                DataTable dt = objBusinessDependent.readDependentList("0");
                // DataTable dt = null;
                string strHtmm = ConvertDataTableToHTML(dt);
                divReport.InnerHtml = strHtmm;
                LoadUsr();
                DropDownBind();
                clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();  //emp0025
                objEntityUserReg.UserId = Convert.ToInt32(HiddenEmployeeId.Value);

                string uid = Convert.ToString(objEntityUserReg.UserId);
                if (ddlUsrDsgn.SelectedItem.Value != "--SELECT--")
                {
                    objEntityUserReg.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
                }
                else
                    objEntityUserReg.UserDsgnId = 0;
                objEntityUserReg.UserCrprtDept = 0;
                objEntityUserReg.UserDvsnId = " 0";
                //DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUserReg);
                //string count = dtWelfareScvc.Rows.Count.ToString();
                //DataTable dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityUserReg);
                //dtWelfar = null;
                //if (dtWelfareScvc.Rows.Count > 0)
                //{

                //    string strHtmmm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar, count, uid);
                //    //Write to divReport
                //    divReport1.InnerHtml = strHtmmm;

                //}
                //else
                //{
                //    lblWelfareSrvc.Visible = false;
                //}

                //    lblWelfareSrvc.Attributes["style"] = "display:none;";
            }
            //EVM-0024@
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId1 = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId1);

                HiddenEmployeeId.Value = strId;

                objEntityJobDetails.EmployeeId = Int32.Parse(strId);
                clsBusinessLayerJobDetails objBusinessjob = new clsBusinessLayerJobDetails();
                clsEntityProjectAssign objproj = new clsEntityProjectAssign();

                DataTable dtJob = objBusinessjob.ReadJobtDetails(objEntityJobDetails);
                string strHtm1;
                if (dtJob.Rows.Count > 0)
                {
                    HiddenJobProbId.Value = dtJob.Rows[0]["EMPJOB_ID"].ToString();
                    Btnclrjob.Visible = false;
                    BtnsaveJob.Visible = false;
                    txtProbationdate.Enabled = false;
                    Image9.Disabled = true;
                    ddlPlusWeek.Enabled = false;//evm--0024
                    BtnupdateJob.Visible = true;
                    filljob(dtJob);
                    Btncanceljob.Visible = true;

                }
                else
                {
                    divRenewImg.Visible = false;//EVM-0024
                    DataTable dtProjectassign = objBusinessjob.ReadProjAssign(objproj);

                    strHtm1 = ConvertDataTableToHTMLProject(dtProjectassign, intEnableModify);
                    divreportforProject.InnerHtml = strHtm1;

                }
            }
            //END
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
                else if (strInsUpd == "Ipsd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFail", "MailsendFail();", true);
                }
                else if (strInsUpd == "IpRMSsd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "MailsendFailReviewMailStng", "MailsendFailReviewMailStng();", true);
                }

                else if (strInsUpd == "SaveDependant")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDepnt", "SuccessConfirmationDepnt();", true);
                }
                else if (strInsUpd == "SaveImmigration")
                {
                     ScriptManager.RegisterStartupScript(this, GetType(), "ImigSuccessConfirmation", "ImigSuccessConfirmation();", true);
                }
                else if (strInsUpd == "SaveProjectDtls")
                {
                     ScriptManager.RegisterStartupScript(this, GetType(), "projectSuccessConfirmation", "projectSuccessConfirmation();", true);
                }
                else if (strInsUpd == "SaveSalaryAllwnc")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationAllwnce", "SuccessConfirmationAllwnce("+HiddenPayGrdeId.Value+");", true);
                }
                else if (strInsUpd == "SaveSalaryDedctn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDedctn", "SuccessConfirmationDedctn(" + HiddenPayGrdeId.Value + ");", true);
                }
                else if (strInsUpd == "SaveWorkExp")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationWrkExp", "SuccessConfirmationWrkExp();", true);
                }
                else if (strInsUpd == "SaveEducation")
                {
                     ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationEdu", "SuccessConfirmationEdu();", true);
                }
                else if (strInsUpd == "SaveSkill_Cirtfctn")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationSkCer", "SuccessConfirmationSkCer();", true);
                }
                else if (strInsUpd == "SaveLanguage")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationLang", "SuccessConfirmationLang();", true);
                }
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
            DataTable dtChildRol1 = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol1.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol1.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

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
                }
            }

            if (intEnableAdd != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                BtnsaveJob.Visible = false;
                btnAddImigrationDtls.Visible = false;
                btnUpdate.Visible = false;
            }
            TxtFrstName.Focus();


            if (Session["FRMWRK_TYPE"]!=null&&Session["FRMWRK_TYPE"].ToString() == "1")
            {
                TrTblid1.Visible = false;
                TrTblid3.Visible = false;
                TrTblid5.Visible = false;
                TrTblid6.Visible = false;
                TrTblid7.Visible = false;
                TrTblid9.Visible = false;
                divAutoWorkshopSection.Style.Add("display", "none");
            }
            //evm-0023-20-2
            if (HiddenEmployeeMasterId.Value != "")
            {
                LeavTypLoad(HiddenEmployeeMasterId.Value);
            }
        }


       
    }
    private void LoadTaskTimeDropDowns()
    {
        ddlPlusWeek.Items.Clear();

        ddlPlusWeek.Items.Add("--Select Month--");
        ListItem lst4Week = new ListItem("1 Year", "12");
        ddlPlusWeek.Items.Insert(1, lst4Week);
        ListItem lst3Week = new ListItem("6 Month", "6");
        ddlPlusWeek.Items.Insert(1, lst3Week);
        ListItem lst2Week = new ListItem("3 Month", "3");
        ddlPlusWeek.Items.Insert(1, lst2Week);
        ListItem lst1Week = new ListItem("1 Month", "1");
        ddlPlusWeek.Items.Insert(1, lst1Week);

    }
    //EVM-0024
    private void LoadProbationDropDowns()
    {
        DrpProbEndDate.Items.Clear();
        DrpProbEndDate.Items.Add("--Select Month--");
        ListItem lst4Week = new ListItem("1 Year", "12");
        DrpProbEndDate.Items.Insert(1, lst4Week);
        ListItem lst3Week = new ListItem("6 Month", "6");
        DrpProbEndDate.Items.Insert(1, lst3Week);
        ListItem lst2Week = new ListItem("3 Month", "3");
        DrpProbEndDate.Items.Insert(1, lst2Week);
        ListItem lst1Week = new ListItem("1 Month", "1");
        DrpProbEndDate.Items.Insert(1, lst1Week);
    }
    //ENd

    //SALARY DETAILS 0008
    public void DedctionLoad()
    {
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        hiddenDsgnControlId.Value = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //  if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
        {

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            HiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlPayGrd.SelectedItem.Value);
        DataTable dtSubConrt = objEmpSalary.ReadDedctnLoad(objEntityEmpSlary);

        ddldedctn.Items.Clear();
        if (dtSubConrt.Rows.Count > 0)
        {
            ddldedctn.DataSource = dtSubConrt;
            ddldedctn.DataTextField = "PAYRL_NAME";
            ddldedctn.DataValueField = "PGDEDTN_ID";
            ddldedctn.DataBind();

        }
        ddldedctn.Items.Insert(0, "--SELECT SALARY DEDUCTION--");
    }

    public string ConvertDataTableToHTML(DataTable dt, DataTable dtWelfar, string count, string uid)   //EMP0025
    {

        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"

        string strHtml = "<table  id=\"ReportTable\" class=\"main_table\"  style=\"border: none !important;\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        //strHtml += "<tr class=\"main_table_head\">";

        //for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        //{
        //    if (intColumnHeaderCount == 0)
        //    {
        //        strHtml += "<th class=\"thT\" style=\"width:45%;text-align: left; word-wrap:break-word;\">Service</th>";
        //    }

        //  int deptId =Convert.ToInt32(HiddenUserCrprtDept.Value);

        //}

        //strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        //    hiddenRowCount.Value = "0";
        //   hiddenRowCount.Value = dt.Rows.Count.ToString();


        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr id=\"trId_" + intRowBodyCount + " \" style=\"background: #eef9eb;\" >";



            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {







                if (intColumnBodyCount == 1)
                {

                    strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:100%;word-break: break-all; word-wrap:break-word;text-align: left;background: #eef9eb;\"  >" + " <a class=\"tooltip\"  style=\"cursor:pointer;color: blue;opacity: 1;z-index: 10;position: sticky;font-size: 14px;background: #eef9eb;\"  title=\"Go To View\" onclick=\"return preview('" + dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "," + uid + "," + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "');\" >" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</a></td>";

                    //  strHtml += "<td  id=\"tdName_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:45%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString() + "</td>";
                    strHtml += "<td id=\"tdEmpId_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + uid + "</td>";
                    strHtml += "<td id=\"tdWelfareId_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dt.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "</td>";
                    //divSeviceName.InnerHtml = dt.Rows[intRowBodyCount]["WLFRSRVC_NAME"].ToString();
                }




            }

            strHtml += "</tr>";

        }
        if (dt.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\" colspan=\"4\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >No Data Available</td>";


        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);



        return sb.ToString();


    }

    [WebMethod]
    public static string preview1(string strid, string strempid, string deptid, string desgid)
    {

        clsEntityLayerDepartmentWelfareSrvc objEntityWelfare = new clsEntityLayerDepartmentWelfareSrvc();
        clsBusinesslayerCorpDept objBusinessLayerCorpDept = new clsBusinesslayerCorpDept();

        Master_gen__Emply_Personal__Informn_gen__Emply_Personal__Informn obj = new Master_gen__Emply_Personal__Informn_gen__Emply_Personal__Informn();
        string Details = obj.ConvertDataTable(strid, strempid, deptid, desgid);


        return Details;


    }
    public string ConvertDataTable(string Id, string strempid, string deptid, string desgid)
    {

        clsEntityLayerUserRegistration objEntityEmp = new clsEntityLayerUserRegistration();
        clsEntityLayerEmployeeWelfareSrvc objEntityWelfareEmp = new clsEntityLayerEmployeeWelfareSrvc();
        objEntityEmp.UserId = Convert.ToInt32(strempid);
        objEntityWelfareEmp.Emp_Id = Convert.ToInt32(strempid);
        if (deptid != "")
        {
            objEntityWelfareEmp.DepId = Convert.ToInt32(deptid); ;
        }


        objEntityWelfareEmp.Welfare_Id = Convert.ToInt32(Id);
        if (desgid != "")
        {
            objEntityWelfareEmp.DesgId = Convert.ToInt32(desgid);
        }
        DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityEmp);
        DataTable dtWelfarById = objBusinessLayerUserRegisteration.ReadDsgnWelfareById(objEntityWelfareEmp);
        DataTable dtWelfareScvcDept = objBusinessLayerUserRegisteration.ReadEmpnWelfareDept(objEntityWelfareEmp);
        DataTable dtWelfareScvcDesg = objBusinessLayerUserRegisteration.ReadEmpnWelfareDesg(objEntityWelfareEmp);
        DataTable dtWelfar = new DataTable();
        string WelfareSubId = "";
        if (dtWelfarById.Rows.Count > 0)
        {
            for (int i = 0; i < dtWelfarById.Rows.Count; i++)
            {
                objEntityWelfareEmp.WelfrSub_Id = Convert.ToInt32(dtWelfarById.Rows[i]["WLFSRVCDTL_ID"].ToString());
                if (WelfareSubId == "")
                {
                    WelfareSubId = dtWelfarById.Rows[i]["WLFSRVCDTL_ID"].ToString();

                }

                else
                {
                    WelfareSubId = WelfareSubId + "," + dtWelfarById.Rows[i]["WLFSRVCDTL_ID"].ToString();

                }
            }
            objEntityWelfareEmp.WelfSub_Id = WelfareSubId;
            dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityWelfareEmp);

        }


        StringBuilder sb = new StringBuilder();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"

        string strHtml = "<table id=\"ReportTableWelfare\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        int count = dtWelfarById.Rows.Count;


        int wlchecked1 = 0;
        int chkCount = 0;

        int flag = 0;
        if (flag == 0)
        {
            for (int intRowBodyCount = 0; intRowBodyCount < dtWelfarById.Rows.Count; intRowBodyCount++)
            {

                if (dtWelfar != null)
                {
                    if (dtWelfar.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtWelfar.Rows.Count; intRowCount++)
                        {

                            if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfar.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                            {
                                if (dtWelfar.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() == "")
                                {
                                    chkCount = chkCount + 1;
                                    wlchecked1 = 1;
                                    break;
                                }
                                else if (dtWelfar.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() != "")
                                {
                                    wlchecked1 = 2;
                                    break;
                                }
                            }

                        }



                    }
                    else if (dtWelfareScvcDesg.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtWelfareScvcDesg.Rows.Count; intRowCount++)
                        {

                            if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfareScvcDesg.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                            {
                                if (dtWelfareScvcDesg.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() == "")
                                {
                                    chkCount = chkCount + 1;
                                    wlchecked1 = 1;
                                    break;
                                }
                                else if (dtWelfareScvcDesg.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() != "")
                                {
                                    wlchecked1 = 2;
                                    break;
                                }
                            }

                        }



                    }
                    else if (dtWelfareScvcDept.Rows.Count > 0)
                    {
                        for (int intRowCount = 0; intRowCount < dtWelfareScvcDept.Rows.Count; intRowCount++)
                        {

                            if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfareScvcDept.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                            {
                                if (dtWelfareScvcDept.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() == "")
                                {
                                    chkCount = chkCount + 1;
                                    wlchecked1 = 1;
                                    break;
                                }
                                else if (dtWelfareScvcDept.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() != "")
                                {
                                    wlchecked1 = 2;
                                    break;
                                }
                            }

                        }



                    }

                    else
                    {




                        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" checked=\"checked\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
                        flag = 1;
                        break;

                    }


                }

            }
        }
        if (flag == 0)
        {
            if (wlchecked1 == 1)
            {
                if (chkCount == count)
                {
                    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" checked=\"checked\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
                }
                else
                    strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
            }
            else if (wlchecked1 == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";
            }
            else if (wlchecked1 == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" title=\"Select All\"  style=\"margin-left: 12%;\" onkeypress=\"return DisableEnter(event)\" onchange=\"selectAll(" + count + ")\"></th>";

            }
        }







        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dtWelfarById.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 0)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">From</th>";


            }

            else if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: center; word-wrap:break-word;\">To</th>";

            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Frequency</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:25%;text-align: left; word-wrap:break-word;\">Limit</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\"  style=\"width:15%;text-align: center; word-wrap:break-word;\">Unit</th>";
            }


        }

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows
        //   hiddenRowCount.Value = dtWelfareScvc.Rows.Count.ToString();


        strHtml += "<tbody>";

        for (int intRowBodyCount = 0; intRowBodyCount < dtWelfarById.Rows.Count; intRowBodyCount++)
        {
            strHtml += "<tr id=\"trId_" + intRowBodyCount + " \"  >";
            //   strHtml += "<td id=\"tdCount_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows.Count.ToString() + "</td>";
            int wlchecked = 0;
            if (dtWelfar != null)
            {
                if (dtWelfar.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dtWelfar.Rows.Count; intRowCount++)
                    {

                        if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfar.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                        {
                            if (dtWelfar.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() == "")
                            {
                                wlchecked = 1;
                                break;
                            }
                            else if (dtWelfar.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() != "")
                            {
                                wlchecked = 2;
                                break;
                            }
                        }

                    }

                    if (wlchecked == 1)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input   type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";

                    }
                    else if (wlchecked == 0)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input  type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";

                    }
                    else if (wlchecked == 2)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input   type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";

                    }

                }
                else if (dtWelfareScvcDesg.Rows.Count > 0)
                {
                    for (int intRowCount = 0; intRowCount < dtWelfareScvcDesg.Rows.Count; intRowCount++)
                    {

                        if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfareScvcDesg.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                        {
                            if (dtWelfareScvcDesg.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() == "")
                            {
                                wlchecked = 1;
                                break;
                            }
                            else if (dtWelfareScvcDesg.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() != "")
                            {
                                wlchecked = 2;
                                break;
                            }
                        }

                    }

                    if (wlchecked == 1)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input   type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";

                    }
                    else if (wlchecked == 0)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input  type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";

                    }
                    else if (wlchecked == 2)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input   type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";

                    }


                }





                else if (dtWelfareScvcDept.Rows.Count > 0)
                {

                    for (int intRowCount = 0; intRowCount < dtWelfareScvcDept.Rows.Count; intRowCount++)
                    {

                        if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfareScvcDept.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                        {
                            if (dtWelfareScvcDept.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() == "")
                            {
                                wlchecked = 1;
                                break;
                            }
                            else if (dtWelfareScvcDept.Rows[intRowCount]["WELF_CNCL_DATE"].ToString() != "")
                            {
                                wlchecked = 0;
                                break;
                            }
                        }

                    }

                    if (wlchecked == 1)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input   type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";

                    }
                    else if (wlchecked == 0)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input  type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";

                    }
                    else if (wlchecked == 2)
                    {
                        strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input   type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                        strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >1</td>";

                    }

                }


                else
                {

                    strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
                    strHtml += "<td id=\"tdchkSts_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >0</td>";
                }
            }
            else
            {

                strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"CheckBoxChange(" + count + ");\" /></td>";
            }




            for (int intColumnBodyCount = 0; intColumnBodyCount < dtWelfarById.Columns.Count; intColumnBodyCount++)
            {

                //     strHtml += "<td  id=\"tdchkbx_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" checked=\"checked\" style=\"float: right;margin-right: 42%;\" Id=\"cblwelfarescvc_" + intRowBodyCount + "\" onchange=\"IncrmntConfrmCounter();\" /></td>";
                if (intColumnBodyCount == 0)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRMPERD"].ToString() + "</td>";


                }

                else if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_TOPERD"].ToString() + "</td>";
                    //  strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: center;display:none; \"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"tdSubtId_" + intRowBodyCount + " \" class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() + "</td>";
                    strHtml += "<td id=\"tdWelfareId_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:2%;word-break: break-all; word-wrap:break-word;text-align: center;display:none;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_ID"].ToString() + "</td>";



                }
                else if (intColumnBodyCount == 2)
                {
                    string Frequancy = dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRQNCY"].ToString();
                    if (Frequancy == "0")
                    {
                        strHtml += "<td class=\"tdT\"  style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >1 Month</td>";
                    }
                    if (Frequancy == "1")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >2 Month</td>";
                    }
                    if (Frequancy == "2")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >1 Year</td>";
                    }
                    if (Frequancy == "3")
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >Per Visit</td>";
                    }
                    //  strHtml += "<td class=\"tdT\" style=\" width:30%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_FRQNCY"].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    int qty = 0;
                    string strQntity = "";
                    if (dtWelfar != null)
                    {

                        if (dtWelfar.Rows.Count > 0)
                        {
                            for (int intRowCount = 0; intRowCount < dtWelfar.Rows.Count; intRowCount++)
                            {
                                if (dtWelfarById.Rows[intRowBodyCount]["WLFSRVCDTL_ID"].ToString() == dtWelfar.Rows[intRowCount]["WLFSRVCDTL_ID"].ToString())
                                {
                                    strQntity = dtWelfar.Rows[intRowCount]["WLFRSRVC_QNTY"].ToString();
                                    qty = 1;
                                    break;
                                }
                            }
                            if (qty == 1)
                            {

                                strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + strQntity + "\"  maxlength=\"10\" onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                                // strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";

                            }
                            else
                            {
                                int deptcount = dtWelfareScvcDept.Rows.Count;
                                int desgcount = dtWelfareScvcDesg.Rows.Count;
                                if (dtWelfareScvcDesg.Rows.Count > 0 && (desgcount - 1 >= intRowBodyCount))
                                {

                                    strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfareScvcDept.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                }

                                else if (dtWelfareScvcDept.Rows.Count > 0 && (deptcount - 1 >= intRowBodyCount))
                                {

                                    strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfareScvcDept.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                }
                                else
                                {

                                    strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                                }
                                strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                                // strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                            }

                        }
                        else if (dtWelfareScvcDesg.Rows.Count > 0)
                        {


                            strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfareScvcDesg.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                            strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                            strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                        }





                        else if (dtWelfareScvcDept.Rows.Count > 0)
                        {


                            strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfareScvcDept.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                            strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                            strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                        }
                        else
                        {

                            strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"  onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                            strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                            strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                        }
                    }
                    else
                    {

                        strHtml += "<td id=\"tdlimit_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align:center;\"  ><input  style=\" width:78%;text-align:center;\" id=txtlmt_" + intRowBodyCount + " type=\"text\"  value=\"" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "\"  maxlength=\"10\"   onblur=\" return isTagText(event);\"onkeypress=\" return isTagText(event);\"  /></td>";
                        strHtml += "<td id=\"tdlimit1_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_QNTY"].ToString() + "</td>";
                        strHtml += "<td id=\"tdChecked_" + intRowBodyCount + " \"  class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align:center; display:none\"  >" + dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_MANDTRY"].ToString() + "</td>";
                    }



                }
                else if (intColumnBodyCount == 4)
                {
                    string unit = dtWelfarById.Rows[intRowBodyCount]["WLFRSRVC_UNIT"].ToString();
                    string strunt = "";
                    if (unit == "0")
                    {
                        strunt = "Liter";

                    }
                    else if (unit == "1")
                    {
                        strunt = "Amount";

                    }
                    else if (unit == "2")
                    {
                        strunt = "Count";

                    }
                    else if (unit == "3")
                    {
                        strunt = "KiloGram";

                    }
                    else if (unit == "4")
                    {
                        strunt = "Meter";

                    }

                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + strunt + "</td>";

                }
            }

            strHtml += "</tr>";

        }
        if (dtWelfarById.Rows.Count == 0)
        {
            strHtml += "<td class=\"tdT\" colspan=\"6\" style=\" width:90%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >No Data Available</td>";


        }

        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();


    }

    public void AllowanceLoad()
    {
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        hiddenDsgnControlId.Value = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
        {

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }


        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            HiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlPayGrd.SelectedItem.Value);
        DataTable dtSubConrt = objEmpSalary.ReadAddnLoad(objEntityEmpSlary);
        ddlAddtn.Items.Clear();

        if (dtSubConrt.Rows.Count > 0)
        {
            ddlAddtn.DataSource = dtSubConrt;
            ddlAddtn.DataTextField = "PAYRL_NAME";
            ddlAddtn.DataValueField = "PGALLCE_ID";
            ddlAddtn.DataBind();

        }

        ddlAddtn.Items.Insert(0, "--SELECT SALARY ADDITION--");

    }
    //SALARY DETAILS
    public void PayGradeLoad(string strId = null)
    {

        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            HiddenOrgId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();

        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        hiddenDsgnControlId.Value = strDsgControlLoginUsr;
        if (strDsgControlLoginUsr == "O")
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strEId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityEmpSlary.EmplyUserId = Convert.ToInt32(strEId);
            }
        }

        DataTable dtSubConrt = objEmpSalary.ReadPayGrade(objEntityEmpSlary);
        ddlPayGrd.Items.Clear();
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlPayGrd.DataSource = dtSubConrt;
            ddlPayGrd.DataTextField = "PYGRD_NAME";
            ddlPayGrd.DataValueField = "PYGRD_ID";
            ddlPayGrd.DataBind();

        }

        ddlPayGrd.Items.Insert(0, "--SELECT PAY GRADE--");


    }
    //SALARY DETAILS 0008
    public void updateSalary(string id)
    {
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        ButtnSalryupd.Attributes.Add("style", "display:block;width: 95%");
        ButtonClr.Attributes.Add("style", "display:none;width: 95%");
        ButtonAdd.Attributes.Add("style", "display:none;width: 95%");
        hiddenDsgnControlId.Value = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
        {

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }


        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(id);
        HiddenEmployeeMasterId.Value = id;
        DataTable dtSlry = objEmpSalary.ReadSalaryByEmpId(objEntityEmpSlary);
        if (dtSlry.Rows.Count > 0)
        {
            HiddenPayGrdeId.Value = dtSlry.Rows[0]["PYGRD_ID"].ToString();
            HiddenRestrctRange.Value = dtSlry.Rows[0]["PYGRD_RANGE_FRM"].ToString() + "," + dtSlry.Rows[0]["PYGRD_RANGE_TO"].ToString() + "," + dtSlry.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString();
            BasicRestrctrang.InnerText = dtSlry.Rows[0]["PYGRD_RANGE_FRM"].ToString() + " - " + dtSlry.Rows[0]["PYGRD_RANGE_TO"].ToString() + "  " + dtSlry.Rows[0]["CRNCMST_ABBRV"].ToString();//evm-20

            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(dtSlry.Rows[0]["PYGRD_ID"].ToString());

            if (dtSlry.Rows[0]["PYGRD_STATUS"].ToString() == "1" && dtSlry.Rows[0]["PYGRD_CNCL_USR_ID"].ToString() == "")
            {
                ddlPayGrd.Items.FindByValue(dtSlry.Rows[0]["PYGRD_ID"].ToString()).Selected = true;

            }
            else
            {
                ListItem lst = new ListItem(dtSlry.Rows[0]["PYGRD_NAME"].ToString(), dtSlry.Rows[0]["PYGRD_ID"].ToString());
                ddlPayGrd.Items.Insert(1, lst);

                SortDDL(ref this.ddlPayGrd);

                ddlPayGrd.Items.FindByValue(dtSlry.Rows[0]["PYGRD_ID"].ToString()).Selected = true;
            }
            txtBasicpayFrm.Text = dtSlry.Rows[0]["AMOUNTFRM"].ToString();

            HiddenSalarSummry.Value = dtSlry.Rows[0]["AMOUNTFRM"].ToString();

            HiddenEmpSalryId.Value = dtSlry.Rows[0]["SLRY_ID"].ToString();
            //evm-20
            if (dtSlry.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString() == "1")
            {
                IdRestrctdRngBasic.InnerText = "Restricted Range";
                BasicRestrctrang.Attributes.Add("style", "margin-left:16.5%");
            }
            else
            {
                IdRestrctdRngBasic.InnerText = "Amount Range";
                BasicRestrctrang.Attributes.Add("style", "margin-left:17.5%");
            }//END

            DataTable dtCorpDetail;
            dtCorpDetail = objEmpSalary.RestrictionChk(objEntityEmpSlary);
            if (dtCorpDetail.Rows.Count > 0)
                HiddenSalaryAbbrv.Value = dtCorpDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            AllowanceLoad();
            DedctionLoad();
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        hiddenDsgnControlId.Value = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
        //{

        if (Session["CORPOFFICEID"] != null)
        {

            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        //}

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityEmpSlary.D_Date = DateTime.Now;

        if (ddlPayGrd.SelectedItem.Value.ToString() != "--SELECT PAY GRADE--")
        {
            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlPayGrd.SelectedItem.Value);
            HiddenPayGrdeId.Value = ddlPayGrd.SelectedItem.Value;
        }
        objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtBasicpayFrm.Text.Trim());

        string strdupName = "";

        AllowanceLoad();
        DedctionLoad();
        if (HiddenPayGradechnge.Value == "1")
        {
            objEmpSalary.UpdatePayGrade(objEntityEmpSlary);
        }
        else
        {
            objEmpSalary.UpdatePayGradeBasicPay(objEntityEmpSlary);
        }

        int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);

        objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(HiddenEmplyId.Value);
        DataTable dtSlry = objEmpSalary.ReadSalaryByEmpId(objEntityEmpSlary);

        BasicRestrctrang.InnerText = dtSlry.Rows[0]["PYGRD_RANGE_FRM"].ToString() + " - " + dtSlry.Rows[0]["PYGRD_RANGE_TO"].ToString() + "  " + dtSlry.Rows[0]["CRNCMST_ABBRV"].ToString();
        if (dtSlry.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString() == "1")
        {
            IdRestrctdRngBasic.InnerText = "Restricted Range";
        }
        else
        {
            IdRestrctdRngBasic.InnerText = "Amount Range";
        }//END


        if (clickedButton.ID == "ButtnSalryupd")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPayGradeUpd", "SuccessConfirmationPayGradeUpd(" + Paygdid + ");", true);

        }

        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
    }
    //SALARY DETAILS
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        hiddenDsgnControlId.Value = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
        {

            if (Session["CORPOFFICEID"] != null)
            {

                objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }


        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //must change when integrating
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);

        if (ddlPayGrd.SelectedItem.Value.ToString() != "--SELECT PAY GRADE--")
        {
            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlPayGrd.SelectedItem.Value);
            HiddenPayGrdeId.Value = ddlPayGrd.SelectedItem.Value;
        }
        objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtBasicpayFrm.Text.Trim());
        string strdupName = "";

        AllowanceLoad();
        DedctionLoad();
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEE_SALARY);
        objEntityCommon.CorporateID = objEntityEmpSlary.CorpOffice_Id;
        objEntityCommon.Organisation_Id = objEntityEmpSlary.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(strNextId);
        objEmpSalary.AddPayGrade(objEntityEmpSlary);
        HiddenEmpSalryId.Value = strNextId;
        int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
        ButtonAdd.Attributes.Add("style", "display:none;width: 95%");
        ButtnSalryupd.Attributes.Add("style", "display:block;width: 95%");//evm-20
        //evm-20
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(HiddenEmplyId.Value);
        DataTable dtSlry = objEmpSalary.ReadSalaryByEmpId(objEntityEmpSlary);
        BasicRestrctrang.InnerText = dtSlry.Rows[0]["PYGRD_RANGE_FRM"].ToString() + " - " + dtSlry.Rows[0]["PYGRD_RANGE_TO"].ToString() + "  " + dtSlry.Rows[0]["CRNCMST_ABBRV"].ToString();
        if (dtSlry.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString() == "1")
        {
            IdRestrctdRngBasic.InnerText = "Restricted Range";

        }
        else
        {
            IdRestrctdRngBasic.InnerText = "Amount Range";
        }//END

        if (txtJoineddate.Text.Trim() != "")
        {
            InsUserLeaveTypes(objEntityEmpSlary.CorpOffice_Id, objEntityEmpSlary.Organisation_Id, objEntityEmpSlary.EmplyUserId,objCommon.textToDateTime(txtJoineddate.Text.Trim()), 0);
        }

        if (clickedButton.ID == "ButtonAdd")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPayGrade", "SuccessConfirmationPayGrade(" + Paygdid + ");", true);

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
    }
    //SALARY DETAILS

    //Evm-0023-20-2
    protected void btnAdd_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;

        hiddenDsgnControlId.Value = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            hiddenDsgnControlId.Value = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //if (hiddenDsgnControlId.Value == "C" || hiddenDsgnControlId.Value == "c")
        //{

        if (Session["CORPOFFICEID"] != null)
        {

            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        // }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //must change when integrating
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        //objEntityEmpSlary.NextIdForPayGrade = 381624;
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(HiddenEmpSalryId.Value);
        objEntityEmpSlary.AlownceId = Convert.ToInt32(HiddenddlAllDed.Value);



        if (rdbAllwcAmt.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 0;
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());
        }
        else if (rdbAllwcPerc.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 1;
            objEntityEmpSlary.Percentge = Convert.ToDecimal(txtPerctgAllwnc.Text.Trim());
        }

        string strdupAllownce = "";
        strdupAllownce = objEmpSalary.DuplCheckSalaryAllownce(objEntityEmpSlary);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objEmpSalary.AddSalaryAddnAllownce(objEntityEmpSlary);
            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
            if (clickedButton.ID == "SaveAddtn")
            {

                string strRandom = objCommon.Random_Number();
                string strId = HiddenEmployeeMasterId.Value;
                int intIdLength = HiddenEmployeeMasterId.Value.Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveSalaryAllwnc");

                //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationAllwnce", "SuccessConfirmationAllwnce(" + Paygdid + ");", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryAllwnce", "DuplicationSalaryAllwnce();", true);
        }
       // ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
    }
    protected void btnAdd_Dedctn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);
        objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(HiddenEmpSalryId.Value);

        objEntityEmpSlary.DedctnId = Convert.ToInt32(HiddenddlAllDed.Value);

        if (radAmnt.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 0;
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRedcnFrom.Text.Trim());

        }
        else if (radPercntge.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 1;
            objEntityEmpSlary.Percentge = Convert.ToDecimal(txtperctg.Text.Trim());
        }
        if (radioBascPay.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 0;
        }
        else if (radioTotlAmnt.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 1;
        }
        string strdupAllownce = "";
        strdupAllownce = objEmpSalary.DuplCheckSalaryDedctn(objEntityEmpSlary);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objEmpSalary.AddSalaryDedction(objEntityEmpSlary);

            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);

            if (clickedButton.ID == "SaveDedctn")
            {
                string strRandom = objCommon.Random_Number();
                string strId = HiddenEmployeeMasterId.Value;
                int intIdLength = HiddenEmployeeMasterId.Value.Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveSalaryDedctn");
                
                //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDedctn", "SuccessConfirmationDedctn(" + Paygdid + ");", true);
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryDedctn", "DuplicationSalaryDedctn();", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

    }

    //SALARY DETAILS
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(hiddenRsnid.Value);


            if (Session["USERID"] != null)
            {
                objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            objEntityEmpSlary.D_Date = System.DateTime.Now;

            objEntityEmpSlary.Cancel_reason = txtCnclReason.Text.Trim();


            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
            if (HiddenDelChk.Value == "0")
            {
                objEmpSalary.CancelAllownce(objEntityEmpSlary);
                txtCnclReason.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationAllwnce", "SuccessCancelationAllwnce(" + Paygdid + ");", true);
            }
            if (HiddenDelChk.Value == "1")
            {
                objEmpSalary.CancelDedctn(objEntityEmpSlary);
                txtCnclReason.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancelationDedctn", "SuccessCancelationDedctn(" + Paygdid + ");", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);
        }
    }
    //SALARY DETAILS

    //evm-0023-20-2
    protected void btnUpdate_Addtn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.D_Date = DateTime.Now;
        if (HiddenEmpSalryId.Value != "")
        {
            objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(HiddenEmpSalryId.Value);
        }
        objEntityEmpSlary.SalaryAllwnceId = Convert.ToInt32(HiddenSalaryAllwceId.Value);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);

        objEntityEmpSlary.AlownceId = Convert.ToInt32(HiddenddlAllDed.Value);

        if (rdbAllwcAmt.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 0;
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRgeFrm.Text.Trim());
        }
        else if (rdbAllwcPerc.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 1;
            objEntityEmpSlary.Percentge = Convert.ToDecimal(txtPerctgAllwnc.Text.Trim());
        }

        string strdupAllownce = "";
        strdupAllownce = objEmpSalary.DuplCheckSalaryAllownce(objEntityEmpSlary);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objEmpSalary.UpdSalaryAddnAllownce(objEntityEmpSlary);
            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);
            if (clickedButton.ID == "UpdateAddtn")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradeAllwnce", "UpdatePayGradeAllwnce(" + Paygdid + ");", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryAllwnce", "DuplicationSalaryAllwnce();", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

    }

    protected void btnUpdate_Dedctn_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        int intUserId = 0, intUsrRolMstrId = 0, intEnableCancel = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpSlary.User_Id = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpSlary.D_Date = DateTime.Now;
        if (HiddenEmpSalryId.Value != "")
        {
            objEntityEmpSlary.EmpSalaryId = Convert.ToInt64(HiddenEmpSalryId.Value);
        }
        objEntityEmpSlary.SlaryDedctnId = Convert.ToInt32(HiddenSalaryDedctnId.Value);

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(HiddenPayGrdeId.Value);

        objEntityEmpSlary.DedctnId = Convert.ToInt32(HiddenddlAllDed.Value);

        if (radAmnt.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 0;
            objEntityEmpSlary.AmountRangeFrm = Convert.ToDecimal(txtAmntRedcnFrom.Text.Trim());

        }
        else if (radPercntge.Checked == true)
        {
            objEntityEmpSlary.PercOrAmountChk = 1;
            objEntityEmpSlary.Percentge = Convert.ToDecimal(txtperctg.Text.Trim());
        }
        if (radioBascPay.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 0;
        }
        else if (radioTotlAmnt.Checked == true)
        {
            objEntityEmpSlary.BasicOrTotalAmtChk = 1;
        }
        string strdupAllownce = "";
        strdupAllownce = objEmpSalary.DuplCheckSalaryDedctn(objEntityEmpSlary);
        if (strdupAllownce == "" || strdupAllownce == "0")
        {
            objEmpSalary.UpdateSalaryDedction(objEntityEmpSlary);
            int Paygdid = Convert.ToInt32(HiddenPayGrdeId.Value);

            if (clickedButton.ID == "UpdateDedctn")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePayGradeDedctn", "UpdatePayGradeDedctn(" + Paygdid + ");", true);
            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationSalaryDedctn", "DuplicationSalaryDedctn();", true);
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "LoadListPageallwnce", "LoadListPageallwnce();", true);

    }

    public void BankLoad(string strId, int CorpID)
    {
        clsEntityPersonalDtls objEntityPersonaldtls = new clsEntityPersonalDtls();
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonaldtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonaldtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPersonaldtls.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strDsgControlLoginUsr == "O")
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strEId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityPersonaldtls.EmpUserId = Convert.ToInt32(strEId);
            }
        }

        DataTable dtBank = objBusinessPersonaldtls.ReadBank(objEntityPersonaldtls);
        if (dtBank.Rows.Count > 0)
        {
            ddlBank.DataSource = dtBank;
            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataValueField = "BANK_ID";
            ddlBank.DataBind();
        }

        ddlBank.Items.Insert(0, "--Select Bank--");

    }

    public void CountryLoad()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.readCountry();
        ddlNationality.DataSource = dtCountry;
        ddlNationality.DataTextField = "CNTRY_NAME";
        ddlNationality.DataValueField = "CNTRY_ID";
        ddlNationality.DataBind();
        ddlNationality.Items.Insert(0, "--Select Country--");

    }
    public void ReligionLoad()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.ReadReligion();

        ddlReligion.DataSource = dtCountry;

        ddlReligion.DataTextField = "RELIGION_NAME";
        ddlReligion.DataValueField = "RELIGION_ID";
        ddlReligion.DataBind();
        ddlReligion.Items.Insert(0, "--Select Religion--");
    }
    public void BloodgrpLoad()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.ReadBloodgrp();
        ddlBldGrp.DataSource = dtCountry;
        ddlBldGrp.DataTextField = "BLOODGRP_NAME";
        ddlBldGrp.DataValueField = "BLOODGRP_ID";
        ddlBldGrp.DataBind();
        ddlBldGrp.Items.Insert(0, "--Select Blood Group--");
    }
    public void RelationshipLoad()
    {
        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        DataTable dtCountry = objBusinessDependent.ReadRelationship();
        ddlReltnshp.DataSource = dtCountry;
        ddlReltnshp.DataTextField = "RELATE_NAME";
        ddlReltnshp.DataValueField = "RELATE_ID";
        ddlReltnshp.DataBind();
        ddlReltnshp.Items.Insert(0, "--Select Relationship--");
    }

    protected void btnAddPersnlDtls_Click(object sender, EventArgs e)
    {
        //getting the next value
        Button clickedButton = sender as Button;
        string empid;

        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();

        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityUsrRegistr.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //evm-0024
        //objEntityUsrRegistr.NextId = Convert.ToInt32(clsCommonLibrary.MasterId.UserId);
        //DataTable dtNextId = objBusinessLayerUserRegisteration.ReadNextId(objEntityUsrRegistr);
        //objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(dtNextId.Rows[0]["MST_NEXT_VALUE"]);
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPersonalDtls.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityPersonalDtls.EmployeeId = txtEmployeeCode.Text.Trim();//Evm-0024
        string strcount = objBusinessPersonalDtls.checkEmpId(objEntityPersonalDtls);
        objEntityPersonalDtls.EmpUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        empid = HiddenEmployeeMasterId.Value;
        objEntityPersonalDtls.Date = System.DateTime.Now;
        objEntityPersonalDtls.RefNum = txtRefNum.Text.Trim();
        objEntityPersonalDtls.JoinDate = objCommon.textToDateTime(txtJoinDate.Text);
        objEntityPersonalDtls.BirthPlace = txtBirthPlc.Text.ToUpper().Trim();
        objEntityPersonalDtls.NickName = txtNickName.Text.ToUpper().Trim();
        objEntityPersonalDtls.Hobbies = txtHobbies.Text.Trim();

        if (ddlReligion.SelectedItem.Value != "--Select Religion--")  //EMP17
        {
            objEntityPersonalDtls.ReligionId = Convert.ToInt32(ddlReligion.SelectedItem.Value);
        }
        else
        {
            objEntityPersonalDtls.ReligionId = 0;
        }


        if (TxtDOB.Text != "")
        {
            objEntityPersonalDtls.DOB = objCommon.textToDateTime(TxtDOB.Text);
        }
        else
        {

            objEntityPersonalDtls.DOB = new DateTime();
        }

        if (ddlBldGrp.SelectedItem.Value != "--Select Blood Group--")
        {

            objEntityPersonalDtls.BloodGrpId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);
        }
        else
        {
            objEntityPersonalDtls.BloodGrpId = 0;
        }   //EMP17

        if (cbxSmoker.Checked == true)
        {
            objEntityPersonalDtls.Smoker = 1;
        }
        else
        {
            objEntityPersonalDtls.Smoker = 0;
        }
        if (cbxAlchlc.Checked == true)
        {
            objEntityPersonalDtls.Alcoholic = 1;
        }
        else
        {
            objEntityPersonalDtls.Alcoholic = 0;
        }

        if (RadioMarried.Checked)
        {
            objEntityPersonalDtls.MaritalSts = 0;
        }
        else
        {
            objEntityPersonalDtls.MaritalSts = 1;
        }

        //EMP-0043 START
        if (RadioBank.Checked)
        {
            objEntityPersonalDtls.PaymentSts = 0;
            // objEntityPersonalDtls.DeleteSts = 1;
        }
        else
        {
            objEntityPersonalDtls.PaymentSts = 1;
            //objEntityPersonalDtls.DeleteSts = 0;
        }


        //bank dtls
        if (RadioBank.Checked)
        {
            if (ddlBank.SelectedItem.Value != "--Select Bank--")
            {
                objEntityPersonalDtls.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
                hiddenBankDtls.Value = Convert.ToInt32(ddlBank.SelectedItem.Value).ToString();
            }
            else
            {
                objEntityPersonalDtls.BankId = 0;
            }

            if (txtBranch.Text.Trim() != "")
            {
                objEntityPersonalDtls.BankBranch = txtBranch.Text.Trim();
            }
            if (ddlAccntTyp.SelectedItem.Value != "")
            {
                objEntityPersonalDtls.AccountTyp = Convert.ToInt32(ddlAccntTyp.SelectedItem.Value);
            }

            if (ddlAccntTyp.SelectedItem.Value == "1")
            {
                if (txtIban.Text.Trim() != "")
                {
                    objEntityPersonalDtls.IbanNo = txtIban.Text.Trim();
                }
            }
            else
            {
                objEntityPersonalDtls.IbanNo = "";
                hiddenPaycrdSal.Value = "true";
            }

            if (txtCardNo.Text.Trim() != "")
            {
                objEntityPersonalDtls.CardNo = txtCardNo.Text.Trim();
            }

            objBusinessPersonalDtls.InsertBankDtls(objEntityPersonalDtls);
        }

        int SubcatgId = 0, MessAccmId = 0;
        if (ddlAccmdtn.SelectedItem.Value != "--SELECT--")
        {
            objEntityPersonalDtls.AccomdtnId = Convert.ToInt32(ddlAccmdtn.SelectedItem.Value);
            HiddenAccmdtnSaveChk.Value = "1";
            if (HiddenAccCat.Value != "0")
            {
                objEntityPersonalDtls.SubCatagoryId = Convert.ToInt32(HiddenAccCat.Value);
                if (HiddenAccSubCat.Value != "0")
                {
                    SubcatgId = Convert.ToInt32(HiddenAccSubCat.Value);
                }
            }

            if (OccupyDate.Text != "")
            {
                objEntityPersonalDtls.DateMess = objCommon.textToDateTime(OccupyDate.Text);
            }
            if (txtAcmdtnToDate.Text != "")
            {
                objEntityPersonalDtls.DateAcmdtn = objCommon.textToDateTime(txtAcmdtnToDate.Text);
            }

        }

        if (DdlMess.SelectedItem.Value != "--SELECT--")
        {
            MessAccmId = Convert.ToInt32(DdlMess.SelectedItem.Value);

            if (txtMessFromDate.Text != "")
            {
                objEntityPersonalDtls.DateMessFrom = objCommon.textToDateTime(txtMessFromDate.Text);
            }
            if (txtMessToDate.Text != "")
            {
                objEntityPersonalDtls.DateMessTo = objCommon.textToDateTime(txtMessToDate.Text);
            }

        }

        //0039
        if (strcount == "0" || strcount == "1") //removing employee code duplication for rejoin with existing code
        {
            objBusinessPersonalDtls.insertPersonalDtls(objEntityPersonalDtls, SubcatgId, MessAccmId);

            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPD", "SuccessConfirmationPD();", true);

        }
        //end
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmpId", "DuplicationEmpId();", true);
            Txtemplyid.Focus();
        }
        string stridmrg = HiddenEmployeeMasterId.Value;

        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        ScriptManager.RegisterStartupScript(this, GetType(), "Notadd", "Notadd();", true);
        LblEntryother.Text = "Edit Other Details";
        btnAddPD.Visible = false;
        btnUpdatePD.Visible = true;
        btnClearPD.Visible = false;

        updatePD(empid);
        Txtemplyid.Focus(); //emp17
    }
    protected void btnAddDepnt_Click(object sender, EventArgs e)
    {
        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        objEntityDependent.EmpUserId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityDependent.Date = System.DateTime.Now;
        objEntityDependent.DepntName = txtDepndtName.Text.ToUpper();
        objEntityDependent.RelatnshpId = Convert.ToInt32(ddlReltnshp.SelectedItem.Value);
        objEntityDependent.DepntPasprtNum = txtPasprtNum.Text;
        if (txtPsprtDate.Text != "")
        {
            objEntityDependent.PasprtExpDate = objCommon.textToDateTime(txtPsprtDate.Text);
        }
        objEntityDependent.RPNum = txtRPnum.Text;
        if (txtRPissDate.Text != "")
        {
            objEntityDependent.RPIssDate = objCommon.textToDateTime(txtRPissDate.Text);
        }
        if (txtRPexpDate.Text != "")
        {
            objEntityDependent.RPExpDate = objCommon.textToDateTime(txtRPexpDate.Text);
        }
        objBusinessDependent.insertDependent(objEntityDependent);


        DataTable dt = objBusinessDependent.readDependentList(HiddenEmployeeMasterId.Value);
        string strHtm = ConvertDataTableToHTML(dt);
        divReport.InnerHtml = strHtm;


     
        string strRandom = objCommon.Random_Number();
        string strId = HiddenEmployeeMasterId.Value;
        int intIdLength = HiddenEmployeeMasterId.Value.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId + strRandom;

        Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveDependant");

        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationDepnt", "SuccessConfirmationDepnt();", true);

    }
    protected void btnUpdatePersnlDtls_Click(object sender, EventArgs e)
    {
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPersonalDtls.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        string empid = "";
        if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityPersonalDtls.EmpUserId = Convert.ToInt32(strId);
            HiddenEmpUserId.Value = strId;
            empid = strId;
        }
        objEntityPersonalDtls.EmployeeId = Txtemplyid.Text.Trim();
        objEntityPersonalDtls.RefNum = txtRefNum.Text.Trim();
        string strcount = objBusinessPersonalDtls.checkEmpId(objEntityPersonalDtls);
        objEntityPersonalDtls.Date = System.DateTime.Now;
        objEntityPersonalDtls.JoinDate = objCommon.textToDateTime(txtJoinDate.Text);
        objEntityPersonalDtls.BirthPlace = txtBirthPlc.Text.ToUpper().Trim();
        objEntityPersonalDtls.NickName = txtNickName.Text.ToUpper().Trim();
        objEntityPersonalDtls.Hobbies = txtHobbies.Text.Trim();

        if (ddlReligion.SelectedItem.Value == "--Select Religion--")  //EMP17
        {
            objEntityPersonalDtls.ReligionId = 0;
        }
        else
        {
            objEntityPersonalDtls.ReligionId = Convert.ToInt32(ddlReligion.SelectedItem.Value);

        }


        if (TxtDOB.Text != "")
        {
            objEntityPersonalDtls.DOB = objCommon.textToDateTime(TxtDOB.Text);
        }
        else
        {

            objEntityPersonalDtls.DOB = new DateTime();
        }

        if (ddlBldGrp.SelectedItem.Value != "--Select Blood Group--")
        {

            objEntityPersonalDtls.BloodGrpId = Convert.ToInt32(ddlBldGrp.SelectedItem.Value);
        }
        else
        {
            objEntityPersonalDtls.BloodGrpId = 0;
        }   //EMP17


        if (cbxSmoker.Checked == true)
        {
            objEntityPersonalDtls.Smoker = 1;
        }
        else
        {
            objEntityPersonalDtls.Smoker = 0;
        }
        if (cbxAlchlc.Checked == true)
        {
            objEntityPersonalDtls.Alcoholic = 1;
        }
        else
        {
            objEntityPersonalDtls.Alcoholic = 0;
        }

        if (RadioMarried.Checked)
        {
            objEntityPersonalDtls.MaritalSts = 0;
        }
        else
        {
            objEntityPersonalDtls.MaritalSts = 1;
        }

        //bank dtls

        //emp-0043 strt
        if (RadioBank.Checked)
        {
            objEntityPersonalDtls.PaymentSts = 0;
            // objEntityPersonalDtls.DeleteSts = 1;
        }
        else
        {
            objEntityPersonalDtls.PaymentSts = 1;
            //objEntityPersonalDtls.DeleteSts = 0;
        }

        clsEntityPersonalDtls objEntityPersonalDetails = new clsEntityPersonalDtls();
        clsBusinessLayerPersonalDtls objBusinessPersonalDetails = new clsBusinessLayerPersonalDtls();
        objEntityPersonalDetails.EmpUserId = Convert.ToInt32(HiddenEmpUserId.Value);

        DataTable dtBank = objBusinessPersonalDetails.ReadBankDtlsById(objEntityPersonalDetails);

        if (RadioBank.Checked == true)
        {
            if (ddlBank.SelectedItem.Value != "--Select Bank--")
            {
                objEntityPersonalDtls.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
                hiddenBankDtls.Value = Convert.ToInt32(ddlBank.SelectedItem.Value).ToString();
            }
            else
            {
                objEntityPersonalDtls.BankId = 0;
            }

            if (txtBranch.Text.Trim() != "")
            {
                objEntityPersonalDtls.BankBranch = txtBranch.Text.Trim();
            }

            if (ddlAccntTyp.SelectedItem.Value != "")
            {
                objEntityPersonalDtls.AccountTyp = Convert.ToInt32(ddlAccntTyp.SelectedItem.Value);
            }

            if (ddlAccntTyp.SelectedItem.Value == "1")
            {
                if (txtIban.Text.Trim() != "")
                {
                    objEntityPersonalDtls.IbanNo = txtIban.Text.Trim();
                }
            }
            else
            {
                objEntityPersonalDtls.IbanNo = "";
                hiddenPaycrdSal.Value = "true";
            }

            if (txtCardNo.Text.Trim() != "")
            {
                objEntityPersonalDtls.CardNo = txtCardNo.Text.Trim();
            }

            if (dtBank.Rows.Count > 0)
            {
                objBusinessPersonalDtls.UpdateBankDtls(objEntityPersonalDtls);
            }
            else
            {
                objBusinessPersonalDtls.InsertBankDtls(objEntityPersonalDtls);
            }
        }

        if (dtBank.Rows.Count > 0)
        {
            objEntityPersonalDtls.BankDtlId = Convert.ToInt32(hiddenEmpBankId.Value);
            objBusinessPersonalDtls.CancelBankdtls(objEntityPersonalDtls);
        }

        //end

        //end

        int SubcatgId = 0, MessAccmId = 0;
        if (ddlAccmdtn.SelectedItem.Value != "--SELECT--")
        {
            objEntityPersonalDtls.AccomdtnId = Convert.ToInt32(ddlAccmdtn.SelectedItem.Value);
            if (HiddenAccCat.Value != "0")
            {
                objEntityPersonalDtls.SubCatagoryId = Convert.ToInt32(HiddenAccCat.Value);
                if (HiddenAccSubCat.Value != "0")
                {
                    SubcatgId = Convert.ToInt32(HiddenAccSubCat.Value);
                }
            }
            if (OccupyDate.Text != "")
            {
                objEntityPersonalDtls.DateMess = objCommon.textToDateTime(OccupyDate.Text);
            }

            if (txtAcmdtnToDate.Text != "")    //emp25
            {
                objEntityPersonalDtls.DateAcmdtn = objCommon.textToDateTime(txtAcmdtnToDate.Text);
            }

        }

        if (DdlMess.SelectedItem.Value != "--SELECT--")
        {
            MessAccmId = Convert.ToInt32(DdlMess.SelectedItem.Value);
            if (txtMessFromDate.Text != "")
            {
                objEntityPersonalDtls.DateMessFrom = objCommon.textToDateTime(txtMessFromDate.Text);
            }
            if (txtMessToDate.Text != "")
            {
                objEntityPersonalDtls.DateMessTo = objCommon.textToDateTime(txtMessToDate.Text);
            }
        }
        //0039
        if (strcount == "0" || strcount == "1")//removing employee code duplication for rejoin with existing code
        {
            objBusinessPersonalDtls.updatePersonalDtls(objEntityPersonalDtls, SubcatgId, MessAccmId);
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPD", "SuccessUpdationPD();", true);
            txtBirthPlc.Focus();
        }
        //end
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmpId", "DuplicationEmpId();", true);
            Txtemplyid.Focus();
        }


        string stridmrg = HiddenEmployeeMasterId.Value;

        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        updatePD(empid);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);

    }
    protected void btnUpdateDepnt_Click(object sender, EventArgs e)
    {
        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityDependent.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        objEntityDependent.DepntName = txtDepndtName.Text.ToUpper();
        objEntityDependent.RelatnshpId = Convert.ToInt32(ddlReltnshp.SelectedItem.Value);
        objEntityDependent.DepntPasprtNum = txtPasprtNum.Text;
        if (txtPsprtDate.Text != "")
        {
            objEntityDependent.PasprtExpDate = objCommon.textToDateTime(txtPsprtDate.Text);
        }
        objEntityDependent.RPNum = txtRPnum.Text;
        if (txtRPissDate.Text != "")
        {
            objEntityDependent.RPIssDate = objCommon.textToDateTime(txtRPissDate.Text);
        }
        if (txtRPexpDate.Text != "")
        {
            objEntityDependent.RPExpDate = objCommon.textToDateTime(txtRPexpDate.Text);
        }
        objBusinessDependent.updateDependent(objEntityDependent);
        DataTable dt = objBusinessDependent.readDependentList(HiddenEmpUserId.Value);
        string strHtm = ConvertDataTableToHTML(dt);
        divReport.InnerHtml = strHtm;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationDepnt", "SuccessUpdationDepnt();", true);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {

        Textnumber.Text = "";
        TextIssuueddate.Text = "";
        TxtdivExpiryDate.Text = "";
        Txtelgblestats.Text = "";
        TxtEligiblervwdate.Text = "";
        TxtComments.Text = "";
        //ie IF  COUNTRY IS ACTIVE
        CountryLoad();
        ddlIssuedby.SelectedIndex = 0;


        //for displaying photo
        hiddenUserImage.Value = "";

    }
    public class Dependent
    {
        public string Name = "";
        public int reltnshpId = 0;
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
                               "<img  style=\"margin-top: -1.5%;opacity: 1;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Delete\" style=\"margin-top: -1.5%;opacity: 1;cursor: pointer;margin-left:1%;\" onclick=\"return deleteDepntById('" + strId + "');\" >" +
                                    "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";

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

        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
        objEntityDependent.DepntId = Convert.ToInt32(Id);
        DataTable dt = objBusinessDependent.ReadDepntById(objEntityDependent);
        if (dt.Rows.Count > 0)
        {

            objDepnt.Name = dt.Rows[0]["EMPDPNT_NAME"].ToString();
            objDepnt.reltnshpId = Convert.ToInt32(dt.Rows[0]["RELATE_ID"].ToString());
            objDepnt.pasprtNum = dt.Rows[0]["EMPDPNT_PASPRT_NUM"].ToString();
            if (dt.Rows[0]["PASSPRT_EXPDATE"].ToString() != "01-01-0001")
            {
                objDepnt.pasprtExpDate = dt.Rows[0]["PASSPRT_EXPDATE"].ToString();
            }
            objDepnt.RpNum = dt.Rows[0]["EMPDPNT_RSDPER_NUM"].ToString();
            if (dt.Rows[0]["RP_ISSDATE"].ToString() != "01-01-0001")
            {
                objDepnt.RpIssDate = dt.Rows[0]["RP_ISSDATE"].ToString();
            }
            if (dt.Rows[0]["RP_EXPDATE"].ToString() != "01-01-0001")
            {
                objDepnt.RpExpDate = dt.Rows[0]["RP_EXPDATE"].ToString();
            }
            objDepnt.reltnshpStsId = dt.Rows[0]["RELATE_STATUS"].ToString();
            objDepnt.reltnshpName = dt.Rows[0]["RELATE_NAME"].ToString();

        }
        return objDepnt;
    }
    [WebMethod]
    public static Dependent deleteDepntDtlById(string Id, string empId)
    {
        Dependent objDepnt = new Dependent();
        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
        objEntityDependent.DepntId = Convert.ToInt32(Id);
        objEntityDependent.Date = System.DateTime.Now;
        objBusinessDependent.DeleteDependent(objEntityDependent);

        DataTable dt = objBusinessDependent.readDependentList(empId);
        objDepnt.strDepntLIst = objDepnt.ConvertDataTableToHTML(dt);
        return objDepnt;
    }


    public void updatePD(string id)
    {
        btnUpdatePD.Visible = true;
        btnAddPD.Visible = false;
        btnClearPD.Visible = false;
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityPersonalDtls.EmpUserId = Convert.ToInt32(id);
        DataTable dt = objBusinessPersonalDtls.ReadPersnlDtlsById(objEntityPersonalDtls);
        if (dt.Rows.Count > 0)
        {
            Txtemplyid.Text = dt.Rows[0]["EMPERDTL_EMPLOYEE_ID"].ToString();
            txtRefNum.Text = dt.Rows[0]["EMPERDTL_REF_NUM"].ToString();
            txtJoinDate.Text = dt.Rows[0]["JOIN_DATE"].ToString();
            TxtDOB.Text = dt.Rows[0]["DOB"].ToString();
            txtBirthPlc.Text = dt.Rows[0]["EMPERDTL_BIRTH_PLC"].ToString();
            txtNickName.Text = dt.Rows[0]["EMPERDTL_NICK_NAME"].ToString();
            txtHobbies.Text = dt.Rows[0]["EMPERDTL_HOBBIES"].ToString();

            if (dt.Rows[0]["RELIGION_STATUS"] == DBNull.Value) //emp17
            {

            }

            else if (dt.Rows[0]["RELIGION_STATUS"].ToString() == "1")
            {
                ddlReligion.Items.FindByText(dt.Rows[0]["RELIGION_NAME"].ToString()).Selected = true;

            }
            else
            {
                ListItem lst = new ListItem(dt.Rows[0]["RELIGION_NAME"].ToString(), dt.Rows[0]["RELIGION_ID"].ToString());
                ddlReligion.Items.Insert(1, lst);

                SortDDL(ref this.ddlReligion);

                ddlReligion.Items.FindByText(dt.Rows[0]["RELIGION_NAME"].ToString()).Selected = true;
            }
            //If blood group is active
            if (dt.Rows[0]["BLOODGRP_NAME"] == DBNull.Value) //emp17
            {

            }
            else if (dt.Rows[0]["BLOODGRP_STATUS"].ToString() == "1")
            {
                ddlBldGrp.Items.FindByText(dt.Rows[0]["BLOODGRP_NAME"].ToString()).Selected = true;

            }
            else
            {
                ListItem lst = new ListItem(dt.Rows[0]["BLOODGRP_NAME"].ToString(), dt.Rows[0]["BLOODGRP_ID"].ToString());
                ddlBldGrp.Items.Insert(1, lst);

                SortDDL(ref this.ddlBldGrp);

                ddlBldGrp.Items.FindByText(dt.Rows[0]["BLOODGRP_NAME"].ToString()).Selected = true;
            }

            //EMP-0043 START
            if (dt.Rows[0]["EMPERDTL_PAYMENT_STS"].ToString() == "0")
            {
                RadioBank.Checked = true;
            }
            else
            {
                RadioCash.Checked = true;
            }
            //END


            if (dt.Rows[0]["ACCMDTN_ID"].ToString() != null && dt.Rows[0]["ACCMDTN_ID"].ToString() != "")
            {
                if (ddlAccmdtn.Items.FindByValue(dt.Rows[0]["ACCMDTN_ID"].ToString()) != null)
                {
                    ddlAccmdtn.ClearSelection();
                    ddlAccmdtn.Items.FindByValue(dt.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["ACCMDTN_NAME"].ToString(), dt.Rows[0]["ACCMDTN_ID"].ToString());
                    ddlAccmdtn.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlAccmdtn);

                    ddlAccmdtn.Items.FindByValue(dt.Rows[0]["ACCMDTN_ID"].ToString()).Selected = true;
                }
                objEntityPersonalDtls.AccomdtnId = Convert.ToInt32(dt.Rows[0]["ACCMDTN_ID"].ToString());
                DataTable dtState = objBusinessPersonalDtls.ReadAccnCatagry(objEntityPersonalDtls);

                if (dtState.Rows.Count > 0)
                {
                    ddlCategry.Items.Clear();
                    ddlCategry.DataSource = dtState;

                    ddlCategry.DataValueField = "ACCOMDTNCATSUB_ID";
                    ddlCategry.DataTextField = "ACCOMDTNCATSUB_NAME";
                    ddlCategry.DataBind();
                    ddlCategry.Items.Insert(0, "--SELECT--");

                }
            }
            else
            {
                ddlCategry.Items.Clear();
                ddlCategry.ClearSelection();
                ddlCategry.Items.Insert(0, "--SELECT--");
            }

            if (dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString() != null && dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString() != "")
            {
                if (ddlCategry.Items.FindByValue(dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString()) != null)
                {

                    ddlCategry.ClearSelection();
                    ddlCategry.Items.FindByValue(dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["ACCOMDTNCATSUB_NAME"].ToString(), dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString());
                    ddlCategry.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCategry);

                    ddlCategry.Items.FindByValue(dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString()).Selected = true;
                }
                objEntityPersonalDtls.SubCatagoryId = Convert.ToInt32(dt.Rows[0]["ACCOMDTNCATSUB_ID"].ToString());
                DataTable dtt = objBusinessPersonalDtls.ReadAccnSubCatagry(objEntityPersonalDtls);

                if (dtt.Rows.Count > 0)
                {
                    ddlSubCat.Items.Clear();
                    ddlSubCat.DataSource = dtt;


                    ddlSubCat.DataValueField = "ACSUBCATDTL_ID";
                    ddlSubCat.DataTextField = "ACSUBCATDTL_NAME";

                    ddlSubCat.DataBind();
                    ddlSubCat.Items.Insert(0, "--SELECT--");

                }
            }
            else
            {
                ddlSubCat.Items.Clear();
                ddlSubCat.ClearSelection();
                ddlSubCat.Items.Insert(0, "--SELECT--");
            }

            if (dt.Rows[0]["ACSUBCATDTL_ID"].ToString() != null && dt.Rows[0]["ACSUBCATDTL_ID"].ToString() != "")
            {
                if (ddlSubCat.Items.FindByValue(dt.Rows[0]["ACSUBCATDTL_ID"].ToString()) != null)
                {
                    ddlSubCat.ClearSelection();
                    ddlSubCat.Items.FindByValue(dt.Rows[0]["ACSUBCATDTL_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["ACSUBCATDTL_NAME"].ToString(), dt.Rows[0]["ACSUBCATDTL_ID"].ToString());
                    ddlSubCat.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlSubCat);

                    ddlSubCat.Items.FindByValue(dt.Rows[0]["ACSUBCATDTL_ID"].ToString()).Selected = true;
                }
            }

            if (dt.Rows[0]["MESS_ACCMDTN_ID"].ToString() != null && dt.Rows[0]["MESS_ACCMDTN_ID"].ToString() != "")
            {
                if (DdlMess.Items.FindByValue(dt.Rows[0]["MESS_ACCMDTN_ID"].ToString()) != null)
                {
                    DdlMess.ClearSelection();
                    DdlMess.Items.FindByValue(dt.Rows[0]["MESS_ACCMDTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["ACCOMNAME"].ToString(), dt.Rows[0]["MESS_ACCMDTN_ID"].ToString());
                    DdlMess.Items.Insert(1, lstGrp);

                    SortDDL(ref this.DdlMess);


                    DdlMess.Items.FindByValue(dt.Rows[0]["MESS_ACCMDTN_ID"].ToString()).Selected = true;
                }
            }
            OccupyDate.Text = dt.Rows[0]["ACCMDTN_DATE"].ToString();
            txtAcmdtnToDate.Text = dt.Rows[0]["ACCMDTN_TO_DATE"].ToString();
            txtMessFromDate.Text = dt.Rows[0]["MESS_FROM_DATE"].ToString();
            txtMessToDate.Text = dt.Rows[0]["MESS_TO_DATE"].ToString();

            if (dt.Rows[0]["EMPERDTL_SMOKER"].ToString() == "1")
            {
                cbxSmoker.Checked = true;
            }
            else
            {
                cbxSmoker.Checked = false;
            }

            if (dt.Rows[0]["EMPERDTL_ALCHLIC"].ToString() == "1")
            {
                cbxAlchlc.Checked = true;
            }
            else
            {
                cbxAlchlc.Checked = false;
            }

            //bank dtls
            clsEntityPersonalDtls objEntityPersonalDetails = new clsEntityPersonalDtls();
            clsBusinessLayerPersonalDtls objBusinessPersonalDetails = new clsBusinessLayerPersonalDtls();
            objEntityPersonalDetails.EmpUserId = Convert.ToInt32(id);

            DataTable dtBank = objBusinessPersonalDetails.ReadBankDtlsById(objEntityPersonalDetails);
            //emp-0043 start
            if (dtBank.Rows.Count > 0)
            {
                hiddenEmpBankId.Value = dtBank.Rows[0]["EMPBANK_ID"].ToString();
                //end
                if (ddlBank.Items.FindByValue(dtBank.Rows[0]["BANK_ID"].ToString()) != null)
                {
                    ddlBank.Items.FindByValue(dtBank.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
                else
                {
                    //EVM-0027 sep 26
                    ListItem lstGrp = new ListItem(dtBank.Rows[0]["BANK_NAME"].ToString(), dtBank.Rows[0]["BANK_ID"].ToString());
                    ddlBank.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlBank);
                    ddlBank.Items.FindByValue(dtBank.Rows[0]["BANK_ID"].ToString()).Selected = true;
                    //END
                }
                hiddenBankDtls.Value = dtBank.Rows[0]["BANK_ID"].ToString();
                txtBranch.Text = dtBank.Rows[0]["EMPBANK_BRANCH"].ToString();
                ddlAccntTyp.Items.FindByValue(dtBank.Rows[0]["EMPBANK_ACCOUNT_TYP"].ToString()).Selected = true;
                if (dtBank.Rows[0]["EMPBANK_IBAN"].ToString() != "")
                {
                    hiddenPaycrdSal.Value = "false";
                    txtIban.Text = dtBank.Rows[0]["EMPBANK_IBAN"].ToString();
                }
                else
                {
                    hiddenPaycrdSal.Value = "true";
                    if (dtBank.Rows[0]["EMPBANK_EMPID"].ToString() != "")
                    {
                        txtEmpId.Text = dtBank.Rows[0]["EMPBANK_EMPID"].ToString();
                    }
                    if (dtBank.Rows[0]["EMPBANK_CARDNUM"].ToString() != "")
                    {
                        txtCardNo.Text = dtBank.Rows[0]["EMPBANK_CARDNUM"].ToString();
                    }
                }
            }
            //END

        }
    }
    public void updateDepent(string id)
    {
        btnUpdateDepnt.Visible = true;
        btnAddDepnt.Visible = false;
        btnClearDepnt.Visible = false;
        clsBusinessLayerDependent objBusinessDependent = new clsBusinessLayerDependent();
        clsEntityLayerDependent objEntityDependent = new clsEntityLayerDependent();
        objEntityDependent.DepntId = Convert.ToInt32(id);
        DataTable dt = objBusinessDependent.ReadDepntById(objEntityDependent);
        if (dt.Rows.Count > 0)
        {
            txtDepndtName.Text = dt.Rows[0]["EMPDPNT_NAME"].ToString();
            if (dt.Rows[0]["RELATE_STATUS"].ToString() == "1")
            {
                ddlReltnshp.Items.FindByText(dt.Rows[0]["RELATE_NAME"].ToString()).Selected = true;

            }
            else
            {
                ListItem lst = new ListItem(dt.Rows[0]["RELATE_NAME"].ToString(), dt.Rows[0]["RELATE_ID"].ToString());
                ddlReltnshp.Items.Insert(1, lst);

                SortDDL(ref this.ddlReltnshp);

                ddlReltnshp.Items.FindByText(dt.Rows[0]["RELATE_NAME"].ToString()).Selected = true;
            }
            txtPasprtNum.Text = dt.Rows[0]["EMPDPNT_PASPRT_NUM"].ToString();
            txtPsprtDate.Text = dt.Rows[0]["PASSPRT_EXPDATE"].ToString();
            txtRPnum.Text = dt.Rows[0]["EMPDPNT_RSDPER_NUM"].ToString();
            txtRPissDate.Text = dt.Rows[0]["RP_ISSDATE"].ToString();
            txtRPexpDate.Text = dt.Rows[0]["RP_EXPDATE"].ToString();


        }
    }
    //start dependent 
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTML(DataTable dt)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableDep\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
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
                           "<img  style=\"margin-top: -1.5%;opacity: 1;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"margin-top: -1.5%;opacity: 1;cursor: pointer;margin-left:1%;\" onclick=\"return deleteDepntById('" + strId + "');\" >" +
                                "<img style=\"margin-top: -1.5%;opacity: 1;\" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    //for creating HTML Title
    private string SetTitle(string size, string value)
    {

        return "<h" + size + "><p align=center>" + value + "</p align></h" + size + ">";

    }
    //end dependent
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
    //salary details

    //EVM-0023-20-2
    public class ConvrtDataTable
    {
        public int SalaryAllwceId = 0;
        public int PaygrdId = 0;
        public int AllowceId = 0;
        public int DedctnId = 0;
        public decimal FrmAmount = 0;
        public decimal Toamount = 0;
        public int ddlselectedVal = 0;
        public int sts = 0;
        public int RestrctSts = 0;
        public decimal Perctgeamnt = 0;
        public int PerOrAmntck = 0;
        public int BasicOrTotl = 0;
        public string strhtml = "";
        public string strSummry = "";
        public int ddlBinding = 0;
        public string ddltext = "";
        public string strperct = "";
        public string strCurrcAbbrv = "";
        public string Amnt = "";
        public string AmntRange = "";
        public string strPerFromTotal = "0";
        public string strPerFromBasic = "0";
        public string PayrolTypSts = "";

        //It build the Html table by using the datatable provided

        public string SalaryPerctTotal(DataTable dt, string AllwOrDed)
        {
            string strStatusMode = ""; decimal perctotalFromTotal = 0, perctotalFromBasic = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();

                if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0, TotalAmountBsic = 1;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());
                    TotalAmountBsic = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (PerORAmntchk == 1)
                        {
                            if (intColumnBodyCount == 3)
                            {
                                if (strStatusMode == "ACTIVE")
                                {
                                    // count++;
                                    if (TotalAmountBsic == 1)
                                        perctotalFromTotal = perctotalFromTotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                    else if (TotalAmountBsic == 0)
                                        perctotalFromBasic = perctotalFromBasic + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }
                        }


                    }
                }
            }
            string strPerTotal = perctotalFromTotal.ToString() + "-" + perctotalFromBasic.ToString();

            return strPerTotal;
        }

        public string SalarySummary(DataTable dt, string AllwOrDed)
        {

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            Decimal totalAmntFrm = 0, totalAmntTo = 0, perctotal = 0;
            int count = 0;
            var strStatusMode = "";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
                if (AllwOrDed == "0")
                {

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 2)
                        {
                            if (strStatusMode == "ACTIVE")
                            {
                                count++;

                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                            }

                        }

                    }
                }
                else if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                        if (PerORAmntchk == 0)
                        {
                            if (intColumnBodyCount == 2)
                            {
                                if (strStatusMode == "ACTIVE")
                                {
                                    count++;

                                    totalAmntFrm = totalAmntFrm + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }
                        }
                        else if (PerORAmntchk == 1)
                        {
                            if (intColumnBodyCount == 3)
                            {
                                if (strStatusMode == "ACTIVE")
                                {
                                    // count++;

                                    perctotal = perctotal + Convert.ToDecimal(dt.Rows[intRowBodyCount][intColumnBodyCount].ToString());
                                }

                            }
                        }



                    }
                }
            }
            string NetAmountWithCommaTo = "0";
            string stramntSummary = "0";

            string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmntFrm.ToString(), objEntityCommon);
            //NetAmountWithCommaTo = objBusiness.AddCommasForNumberSeperation(totalAmntTo.ToString(), objEntityCommon);
            string strabbrv = "";
            if (dt.Rows.Count > 0)
            {
                strabbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            stramntSummary = NetAmountWithCommaFrm + " " + strabbrv;
            // }

            return stramntSummary;
        }

        //evm-0023-20-2
        public string ConvertDataTableToHTML(DataTable dt, int intEnableCancel, string CurrcyId, string AllwOrDed)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            //objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);


            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "";

            if (AllwOrDed == "0")
            {
                strHtml = "<table id=\"ReportTableAllow\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            }
            if (AllwOrDed == "1")
            {
                strHtml = "<table id=\"ReportTableDedtn\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            }

            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            int intReCallForTAble = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                if (intCnclUsrId != 0)
                {
                    intReCallForTAble = 1;
                }

            }
            if (AllwOrDed == "0")
            {
                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">ADDITION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: right; word-wrap:break-word;\">AMOUNT </th>";
                    }



                }
            }
            else if (AllwOrDed == "1")
            {

                for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
                {

                    if (intColumnHeaderCount == 1)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">DEDUCTION</th>";
                    }

                    else if (intColumnHeaderCount == 2)
                    {
                        strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: right; word-wrap:break-word;\">PERCENTAGE/AMOUNT </th>";
                    }



                }
            }
            if (intReCallForTAble == 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">STATUS</th>";
            }

            if (intReCallForTAble == 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
            }
            else
            {
                strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">VIEW</th>";
            }

            if (intReCallForTAble == 0)
            {
                if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>";
                }
            }



            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            string amountFrm = "", amountTo = "";
            float totalAmntFrm = 0, totalAmntTo = 0;
            int count = 0;
            int intSlno = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strStatusMode = "";
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                strHtml += "<tr  >";
                intSlno = Convert.ToInt32(intRowBodyCount.ToString());
                intSlno++;
                //   strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + intSlno.ToString() + "</td>";
                if (AllwOrDed == "0")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYALLCE_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 2)
                        {
                            count++;
                            //strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            string strNetAmount = "";
                            if (PerORAmntchk == 0)
                            {
                                strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                            }
                            else
                            {
                                strNetAmount = dt.Rows[intRowBodyCount]["SLRYALLCE_PERCNTGE"].ToString();
                            }


                            string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                            amountFrm = strNetAmountWithComma;

                            if (PerORAmntchk == 0)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + " %"  + "</td>";

                            }
                        }


                    }
                }
                else if (AllwOrDed == "1")
                {
                    int PerORAmntchk = 0;
                    PerORAmntchk = Convert.ToInt32(dt.Rows[intRowBodyCount]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());

                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (intColumnBodyCount == 1)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }

                        else if (intColumnBodyCount == 2)
                        {
                            if (PerORAmntchk == 0)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                amountFrm = strNetAmountWithComma;
                                strHtml += "<td class=\"tdT\" style=\" width:18%;word-break: break-all; word-wrap:break-word;text-align: right;\" >" + amountFrm + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";
                            }
                        }
                        else if (intColumnBodyCount == 3)
                        {
                            if (PerORAmntchk == 1)
                            {
                                string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                                string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                                strHtml += "<td class=\"tdT\" style=\" width:14%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma + " " + "%" + "</td>";
                            }
                        }


                    }
                }

                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                strStatusMode = dt.Rows[intRowBodyCount][4].ToString();
                if (intCnclUsrId == 0)
                {
                    if (strStatusMode == "ACTIVE")
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\"  title=\"Make Inactive\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "','" + AllwOrDed + "');\" >" +
                            "<img   src='../../Images/Icons/activate.png' /> " + "</a> </td>";

                    }
                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\" Make Active\" onclick=\"return ChangeStatus('" + strId + "','" + strStatusMode + "','" + AllwOrDed + "');\" >" +
                          "<img   src='../../Images/Icons/inactivate.png' /> " + "</a> </td>";
                    }
                }

                if (AllwOrDed == "0")
                {
                    //{
                    if (intCnclUsrId == 0)
                    {


                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.1%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"Edit\" onclick=\"return getdetailsAllwceById('" + strId + "');\" >" +
                             "<img  style=\"cursor:pointer\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";




                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.1%;margin-top: -1.2%;z-index: 99;\" class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";


                    }
                }
                else if (AllwOrDed == "1")
                {

                    if (intCnclUsrId == 0)
                    {


                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"Edit\" onclick=\"return getdetailsDedctnById('" + strId + "');\" >" +
                             "<img  style=\"cursor:pointer\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";




                    }

                    else
                    {
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 2.0%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"View\" onclick='return getdetails(this.href);' " +
                         " href=\"gen_Pay_Grade_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>";


                    }
                }
                //}
                if (intReCallForTAble == 0)
                {
                    if (intEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        if (intCnclUsrId == 0)
                        {
                            if (intCancTransaction == 0)
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 2.8%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\" title=\"Delete\" onclick=\"return CancelAlertAllwceById('" + strId + "','" + AllwOrDed + "');\" >" +
                                  "<img  style=\"cursor:pointer\" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

                            }
                            else
                            {

                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\" title=\"Delete\" onclick='return CancelNotPossible();' >"
                                        + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

                            }



                        }
                        else
                        {

                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                        }
                    }
                }

                strHtml += "</tr>";
            }

            // HiddenAmountRnge.Value = amountTo;

            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }
    }

    //evm-0023-20-2
    [WebMethod]
    public static ConvrtDataTable CheckForRestriction(string ddlAddtnValue, string Orgid, string CorpId, string AllwOrDed)
    {

        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        int AmntFrm = 0, AmountTo = 0;
        string Amnt = "";
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlAddtnValue);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);

        DataTable dtCorpDetail = new DataTable();
        if (AllwOrDed == "0")
        {
            dtCorpDetail = objEmpSalary.RestrictionChk(objEntityEmpSlary);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PYGRD_RANGE_FRM"].ToString() + "," + dtCorpDetail.Rows[0]["PYGRD_RANGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString();

                objConvrtDataTable.strCurrcAbbrv = dtCorpDetail.Rows[0]["CRNCMST_ABBRV"].ToString();

                objConvrtDataTable.RestrctSts = Convert.ToInt32(dtCorpDetail.Rows[0]["PYGRD_RANGE_RESTRICT_STS"].ToString()); //evm-20
            }
        }
        else if (AllwOrDed == "1")
        {
            //FROM HERE 0012

            dtCorpDetail = objEmpSalary.AllowncRestrictionChk(objEntityEmpSlary);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objConvrtDataTable.PerOrAmntck = Convert.ToInt16(dtCorpDetail.Rows[0]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString());
                objConvrtDataTable.PayrolTypSts = dtCorpDetail.Rows[0]["PAYRL_TYPE_STS"].ToString();
                if (dtCorpDetail.Rows[0]["PGALLCE_AMNT_PERCTGE_CHCK"].ToString() == "0") //Amount
                {
                    objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PGALLCE_RANGE_FRM"].ToString() + "," + dtCorpDetail.Rows[0]["PGALLCE_RANGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGALLCE_RANGE_RESTRICT_STS"].ToString();
                }
                else //Percentage
                {
                    objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PGALLCE_PERCNTGE"].ToString() + "," + dtCorpDetail.Rows[0]["PGALLCE_PERCNTGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGALLCE_RANGE_RESTRICT_PER_STS"].ToString();
                }

            }
        }
        else if (AllwOrDed == "2")
        {
            dtCorpDetail = objEmpSalary.DedctnRestrictionChk(objEntityEmpSlary);
            if (dtCorpDetail.Rows.Count > 0)
            {

                objConvrtDataTable.PerOrAmntck = Convert.ToInt16(dtCorpDetail.Rows[0]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString());
                objConvrtDataTable.PayrolTypSts = dtCorpDetail.Rows[0]["PAYRL_TYPE_STS"].ToString();


                if (dtCorpDetail.Rows[0]["PGDEDTN_AMNT_PERCTGE_CHCK"].ToString() == "0") //Amount
                {
                    objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PGDEDTN_RANGE_FRM"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_RESTRICT_STS"].ToString();
                }
                else //Percentage
                {
                    objConvrtDataTable.Amnt = dtCorpDetail.Rows[0]["PGDEDTN_PERCNTGE"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_PERCNTGE_TO"].ToString() + "," + dtCorpDetail.Rows[0]["PGDEDTN_RANGE_RESTRICT_PER_STS"].ToString();
                }
            }
        }


        return objConvrtDataTable;
    }
    [WebMethod]
    public static string Loadallwceddl(int ddlpygdeValue, int Orgid, int CorpId)
    {

        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlpygdeValue);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objEmpSalary.ReadAddnLoad(objEntityEmpSlary);
        dtCorpDetail.TableName = "dtTableAllwnce";
        string result = "";
        if (dtCorpDetail.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtCorpDetail.WriteXml(sw);
                result = sw.ToString();
            }
        }

        return result;
    }

    [WebMethod]
    public static string LoadDedctionddl(int ddlpygdeValue, int Orgid, int CorpId)
    {

        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(ddlpygdeValue);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(Orgid);
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objEmpSalary.ReadDedctnLoad(objEntityEmpSlary);
        dtCorpDetail.TableName = "dtTableDedctn";
        string result = "";
        if (dtCorpDetail.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtCorpDetail.WriteXml(sw);
                result = sw.ToString();
            }
        }

        return result;
    }



    [WebMethod]
    public static ConvrtDataTable LoadListPageallwncee(string EnableCanl, string CurrcyId, string CorpId, string OrgId, string varddlAddtn)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        DataTable dtContract = new DataTable();
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        string AllwOrDed = "0";
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(varddlAddtn);
        dtContract = objEmpSalary.ReadAllounceList(objEntityEmpSlary);



        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);
        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, CurrcyId, AllwOrDed);
        objConvrtDataTable.strSummry = objConvrtDataTable.SalarySummary(dtContract, AllwOrDed);
        return objConvrtDataTable;
    }

    [WebMethod]
    public static ConvrtDataTable LoadListPageDed(string EnableCanl, string CurrcyId, string CorpId, string OrgId, string varddlAddtn)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        DataTable dtContract = new DataTable();
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        string AllwOrDed = "1";
        objEntityEmpSlary.EmplyUserId = Convert.ToInt32(varddlAddtn);
        dtContract = objEmpSalary.ReadDedctnList(objEntityEmpSlary);

        string htrm = "";
        int EnableCancel = Convert.ToInt32(EnableCanl);

        objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dtContract, EnableCancel, CurrcyId, AllwOrDed);
        objConvrtDataTable.strSummry = objConvrtDataTable.SalarySummary(dtContract, AllwOrDed);
        string totalper = objConvrtDataTable.SalaryPerctTotal(dtContract, AllwOrDed);
        string[] strtotalper = totalper.Split('-');
        objConvrtDataTable.strPerFromTotal = strtotalper[0];
        objConvrtDataTable.strPerFromBasic = strtotalper[1];

        return objConvrtDataTable;
    }




    [WebMethod]
    public static string ChangeContractStatus(int strCatId, string strStatus, string AllwOrDed, string OrgId, string CorpId)
    {

        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();

        string strRet = "success";

        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        if (strStatus == "ACTIVE")
        {
            objEntityEmpSlary.PayGrdStatus = 0;
        }
        else
        {
            objEntityEmpSlary.PayGrdStatus = 1;
        }
        objEntityEmpSlary.NextIdForPayGrade = strCatId;
        try
        {
            if (AllwOrDed == "0")
            {
                objEmpSalary.ChangeAllowStatus(objEntityEmpSlary);
            }
            if (AllwOrDed == "1")
            {
                objEmpSalary.ChangeDedctnStatus(objEntityEmpSlary);
            }
        }
        catch
        {
            strRet = "failed";
        }

        return strRet;
    }

    //evm-0023-20-2
    [WebMethod]
    public static ConvrtDataTable ReadAllwceById(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();

        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objEmpSalary.ReadAllounceById(objEntityEmpSlary);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.SalaryAllwceId = Convert.ToInt32(dtAllwce.Rows[0]["SLRYALLCE_ID"].ToString());
            // objConvrtDataTable.AllowceId = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());
            objConvrtDataTable.ddltext = dtAllwce.Rows[0]["PAYRL_NAME"].ToString();
            objConvrtDataTable.ddlselectedVal = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());

            objConvrtDataTable.PerOrAmntck = Convert.ToInt32(dtAllwce.Rows[0]["SLRYALLCE_AMNT_PERCTGE_CHCK"].ToString());

            if (Convert.ToInt32(dtAllwce.Rows[0]["SLRYALLCE_AMNT_PERCTGE_CHCK"].ToString()) == 0)
            {
                objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTFRM"].ToString());
            }
            else
            {
                objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["PERCENTAGE"].ToString());
            }

            objConvrtDataTable.PaygrdId = Convert.ToInt32(dtAllwce.Rows[0]["PYGRD_ID"].ToString());

            if (dtAllwce.Rows[0]["PGALLCE_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["PGALLCE_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlBinding = 0;
            }
            else
            {

                objConvrtDataTable.ddlBinding = 1;
            }
        }
        return objConvrtDataTable;
    }
    [WebMethod]
    public static int CancelAlertAllwceById(string x, string userId, string CorpId, string AllwOrDed)
    {
        int intuserId = Convert.ToInt32(userId);
        int intCorpId = Convert.ToInt32(CorpId);
        int ret = 0;
        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityEmpSlary.User_Id = intuserId;

        objEntityEmpSlary.D_Date = System.DateTime.Now;

        if (dtCorpDetail.Rows.Count > 0)
        {
            // string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            string CnclrsnMust = "0";
            if (CnclrsnMust == "0")
            {

                objEntityEmpSlary.Cancel_reason = objCommon.CancelReason();
                if (AllwOrDed == "0")
                {
                    ret = 0;
                    objEmpSalary.CancelAllownce(objEntityEmpSlary);
                }
                if (AllwOrDed == "1")
                {
                    ret = 1;
                    objEmpSalary.CancelDedctn(objEntityEmpSlary);
                }


            }
            else
            {

                ret = 1;
            }
        }

        return ret;
    }

    [WebMethod]
    public static ConvrtDataTable ReadDedctnId(string x, string CorpId, string OrgId)
    {
        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        clsBusinessLayerEmpSalary objEmpSalary = new clsBusinessLayerEmpSalary();
        clsEntityLayerEmpSalary objEntityEmpSlary = new clsEntityLayerEmpSalary();
        objEntityEmpSlary.NextIdForPayGrade = Convert.ToInt32(x);
        objEntityEmpSlary.Organisation_Id = Convert.ToInt32(OrgId);
        objEntityEmpSlary.CorpOffice_Id = Convert.ToInt32(CorpId);
        DataTable dtAllwce = objEmpSalary.ReadDedctnById(objEntityEmpSlary);
        if (dtAllwce.Rows.Count > 0)
        {
            objConvrtDataTable.SalaryAllwceId = Convert.ToInt32(dtAllwce.Rows[0]["SLRYDEDTN_ID"].ToString());
            // objConvrtDataTable.AllowceId = Convert.ToInt32(dtAllwce.Rows[0]["PGALLCE_ID"].ToString());
            objConvrtDataTable.ddltext = dtAllwce.Rows[0]["PAYRL_NAME"].ToString();
            objConvrtDataTable.ddlselectedVal = Convert.ToInt32(dtAllwce.Rows[0]["PGDEDTN_ID"].ToString());
            objConvrtDataTable.FrmAmount = Convert.ToDecimal(dtAllwce.Rows[0]["AMOUNTFRM"].ToString());
            objConvrtDataTable.PaygrdId = Convert.ToInt32(dtAllwce.Rows[0]["PYGRD_ID"].ToString());
            if (Convert.ToInt32(dtAllwce.Rows[0]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString()) == 1)
            {
                objConvrtDataTable.strperct = dtAllwce.Rows[0]["PERC"].ToString();
            }
            objConvrtDataTable.BasicOrTotl = Convert.ToInt32(dtAllwce.Rows[0]["SLRYDEDTN_BASIC_OR_TOTAL_AMNT"].ToString());
            objConvrtDataTable.PerOrAmntck = Convert.ToInt32(dtAllwce.Rows[0]["SLRYDEDTN_AMNT_PERCTGE_CHCK"].ToString());
            if (dtAllwce.Rows[0]["PGDEDTN_STATUS"].ToString() == "1" && dtAllwce.Rows[0]["PGDEDTN_CNCL_USR_ID"].ToString() == "")
            {
                objConvrtDataTable.ddlBinding = 0;
            }
            else
            {

                objConvrtDataTable.ddlBinding = 1;
            }


        }
        return objConvrtDataTable;
    }
    //-------------------IMMIGRATION AND JOB-------------
    protected void btnRsnSaveImig_Click(object sender, EventArgs e)
    {
        //Creating objects for business layer
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityImigrationDtls.Imig_Id = Convert.ToInt32(hiddenRsnid.Value);



            if (Session["CORPOFFICEID"] != null)
            {
                objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
                objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityImigrationDtls.Imigdate = System.DateTime.Now;

            objEntityImigrationDtls.ImigCancelREASON = TxtRsnimig.Text.Trim();
            objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);
            TxtRsnimig.Text = "";
            ScriptManager.RegisterStartupScript(this, GetType(), "ImigSuccessCancelation", "ImigSuccessCancelation();", true);
            objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(Hiddenempid.Value);
            DataTable dtImigrationDtls = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);
            string strhtm = ConvertDataTableToHTMLImmigration(dtImigrationDtls);
            divImigList.InnerHtml = strhtm;

        }
    }
    protected void btnClear_ClickImig(object sender, EventArgs e)
    {
        Textnumber.Text = "";
        TextIssuueddate.Text = "";
        TxtdivExpiryDate.Text = "";
        Txtelgblestats.Text = "";
        TxtEligiblervwdate.Text = "";
        TxtComments.Text = "";
        //ie IF  COUNTRY IS ACTIVE
        CountryLoad();
        ddlIssuedby.SelectedIndex = 0;











        //for displaying photo
        hiddenUserImage.Value = "";


    }
    //Immigration and job dtails




    protected void btnAddImigrationDtls_Click(object sender, EventArgs e)
    {
        int intuserid = 0;
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        if (RadioButtonDocList.SelectedItem.Text != "Health Card")
        {
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION);
            if (FileUploadRecharge.HasFile)
            {

                string strFileExt;
                // = FileUploadRecharge.FileName;
                strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

                string strImageName = intImageSection.ToString() + "_" + objEntityImigrationDtls.Imig_Id + "." + strFileExt;
                objEntityImigrationDtls.ImigAttachname = strImageName;
                FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + strImageName);

            }
        }
        objEntityImigrationDtls.Imigdate = System.DateTime.Now;
        objEntityImigrationDtls.Imig_Doc_No = Textnumber.Text;
        objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(HiddenEmployeeMasterId.Value); ;//Convert.ToInt32(Session("EMP_ID"));
        objEntityImigrationDtls.ImigDocType_Id = Convert.ToInt32(RadioButtonDocList.SelectedValue);


        if (ddlIssuedby.SelectedItem.Text == "--Select Country--")
        {
            objEntityImigrationDtls.IssuedBy = -1;
        }
        else
        {
            objEntityImigrationDtls.IssuedBy = Convert.ToInt32(ddlIssuedby.SelectedItem.Value);
        }


        if (TextIssuueddate.Text == "")
        {
            objEntityImigrationDtls.Imigissuedate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.Imigissuedate = objCommon.textToDateTime(TextIssuueddate.Text);
        }


        if (TxtdivExpiryDate.Text == "")
        {
            objEntityImigrationDtls.ImigExpdate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.ImigExpdate = objCommon.textToDateTime(TxtdivExpiryDate.Text);
        }

        if (RadioButtonDocList.SelectedItem.Text == "Health Card")
        {
            if (HcExpDate.Text == "")
            {
                objEntityImigrationDtls.ImigExpdate = new DateTime();
            }
            else
            {
                objEntityImigrationDtls.ImigExpdate = objCommon.textToDateTime(HcExpDate.Text);
            }
            if (TxtCntrnum.Text != "")
            {
                objEntityImigrationDtls.CenterNum = TxtCntrnum.Text.Trim();
            }

        }


        if (TxtEligiblervwdate.Text == "")
        {
            objEntityImigrationDtls.Imigrvwdate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.Imigrvwdate = objCommon.textToDateTime(TxtEligiblervwdate.Text);
        }

        if (Ddlvisatype.Text == "--Select Visa Type--")
        {
            objEntityImigrationDtls.intVisaType = 0;

        }
        else
        {
            objEntityImigrationDtls.intVisaType = Convert.ToInt32(Ddlvisatype.SelectedValue);
        }




        // objEntityImigrationDtls.Imigrvwdate = objCommon.textToDateTime(TxtEligiblervwdate.Text);
        objEntityImigrationDtls.ImigDocName = RadioButtonDocList.SelectedItem.Text;
        objEntityImigrationDtls.ImigComments = TxtComments.Text.Trim();

        objEntityImigrationDtls.ImigStatus = Txtelgblestats.Text;
        string strReturn = objBusinessImigration.Check_DOCNUM(objEntityImigrationDtls);
        if (strReturn == "0") //3emp17
        {


            objBusinessImigration.AddImmigration(objEntityImigrationDtls);
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION);
            if (FileUploadRecharge.HasFile)
            {
                FileUploadRecharge.SaveAs(Server.MapPath(strImagePath) + objEntityImigrationDtls.ImigAttachname);
            }
            DataTable dtImigrations = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);
            string strHtm = ConvertDataTableToHTMLImmigration(dtImigrations);
            //Write to divReport
            divImigList.InnerHtml = strHtm;
            //22/02 evm-0024
            if (RadioButtonDocList.SelectedValue == "3")
            {
                HiddenRPStatus.Value = "1";
            }
            if (HiddenRPStatus.Value == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DisableVisa", "DisableVisa();", true);
            }
            //end
            RadioButtonDocList.SelectedValue = "1";
            ddlIssuedby.SelectedIndex = 0;
            Ddlvisatype.SelectedIndex = 0;


            string strRandom = objCommon.Random_Number();
            string strId = HiddenEmployeeMasterId.Value;
            int intIdLength = HiddenEmployeeMasterId.Value.Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveImmigration");

           // ScriptManager.RegisterStartupScript(this, GetType(), "ImigSuccessConfirmation", "ImigSuccessConfirmation();", true);

        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "immigrationSuccessDuplicationSave", "immigrationSuccessDuplicationSave();", true);
        }
    }
    protected void btnUpdateImigrationDtls_Click(object sender, EventArgs e)
    {
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityImigrationDtls.Imig_Id = Convert.ToInt32(HiddenImmigid.Value);
        objEntityImigrationDtls.Imigdate = System.DateTime.Now;
        objEntityImigrationDtls.Imig_Doc_No = Textnumber.Text;

        objEntityImigrationDtls.ImigDocType_Id = Convert.ToInt32(RadioButtonDocList.SelectedValue);
        if (ddlIssuedby.SelectedItem.Text == "--Select Country--")
        {
            objEntityImigrationDtls.IssuedBy = -1;
        }
        else
        {
            objEntityImigrationDtls.IssuedBy = Convert.ToInt32(ddlIssuedby.SelectedItem.Value);
        }

        if (TextIssuueddate.Text == "")
        {
            objEntityImigrationDtls.Imigissuedate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.Imigissuedate = objCommon.textToDateTime(TextIssuueddate.Text);
        }


        if (TxtdivExpiryDate.Text == "")
        {
            objEntityImigrationDtls.ImigExpdate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.ImigExpdate = objCommon.textToDateTime(TxtdivExpiryDate.Text);
        }
        if (RadioButtonDocList.SelectedItem.Text == "Health Card")
        {
            if (HcExpDate.Text == "")
            {
                objEntityImigrationDtls.ImigExpdate = new DateTime();
            }
            else
            {
                objEntityImigrationDtls.ImigExpdate = objCommon.textToDateTime(HcExpDate.Text);
            }
            if (TxtCntrnum.Text != "")
            {
                objEntityImigrationDtls.CenterNum = TxtCntrnum.Text.Trim();
            }

        }


        if (TxtEligiblervwdate.Text == "")
        {
            objEntityImigrationDtls.Imigrvwdate = new DateTime();

        }
        else
        {
            objEntityImigrationDtls.Imigrvwdate = objCommon.textToDateTime(TxtEligiblervwdate.Text);
        }
        if (Ddlvisatype.Text == "--Select Visa Type--")
        {
            objEntityImigrationDtls.intVisaType = 0;

        }
        else
        {
            objEntityImigrationDtls.intVisaType = Convert.ToInt32(Ddlvisatype.SelectedValue);
        }

        objEntityImigrationDtls.ImigDocName = RadioButtonDocList.SelectedItem.Text;
        objEntityImigrationDtls.ImigComments = TxtComments.Text.Trim();

        objEntityImigrationDtls.ImigStatus = Txtelgblestats.Text;
        if (RadioButtonDocList.SelectedItem.Text != "Health Card")
        {
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION);
            if (FileUploadRecharge.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                // objEntityImigrationDtls.ImigDocName = FileUploadRecharge.FileName;
                strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

                string strImageName = intImageSection.ToString() + "_" + objEntityImigrationDtls.Imig_Id + "." + strFileExt;
                objEntityImigrationDtls.ImigAttachname = strImageName;
                FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + strImageName);

            }
            else
            {
                if (hiddenUserImage.Value == "")
                {
                    objEntityImigrationDtls.ImigAttachname = "";
                }
                else
                {
                    objEntityImigrationDtls.ImigAttachname = hiddenUserImage.Value;
                }
            }
        }
        string strReturn = objBusinessImigration.Check_DOCNUM(objEntityImigrationDtls);
        if (strReturn == "0") //3emp17
        {


            objBusinessImigration.UpdateImmigration(objEntityImigrationDtls);
            //   string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
            RadioButtonDocList.SelectedValue = "1";
            ddlIssuedby.SelectedIndex = 0;
            Ddlvisatype.SelectedIndex = 0;
            ScriptManager.RegisterStartupScript(this, GetType(), "ImigSuccessUpdation", "ImigSuccessUpdation();", true);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "immigrationSuccessDuplication", "immigrationSuccessDuplication();", true);

        }
        objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(Hiddenempid.Value);
        DataTable dtImigrationDtls = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);
        string strhtm = ConvertDataTableToHTMLImmigration(dtImigrationDtls);
        divImigList.InnerHtml = strhtm;
    }

    public void updateImigrationDtls(DataTable dtImigrations)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "show_updatebutton", "show_updatebutton();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "hide_saveebutton", "hide_saveebutton();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "hide_clearbutton", "hide_clearbutton();", true);

        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (dtImigrations.Rows.Count > 0)
        {
            // btnUpdateImigrationDtls.Visible = true;
            Textnumber.Text = dtImigrations.Rows[0]["NUMBER"].ToString();
            TextIssuueddate.Text = dtImigrations.Rows[0]["ISSUEDATE"].ToString();
            TxtdivExpiryDate.Text = dtImigrations.Rows[0]["EXPIRY DATE"].ToString();
            Txtelgblestats.Text = dtImigrations.Rows[0]["EMPIMG_ELIGBLE_STATUS"].ToString();
            TxtEligiblervwdate.Text = dtImigrations.Rows[0]["REVIEWDATE"].ToString();
            TxtComments.Text = dtImigrations.Rows[0]["EMPIMG_DOC_COMMENTS"].ToString();
            //ie IF  COUNTRY IS ACTIVE
            CountryLoad();
            if (dtImigrations.Rows[0]["ISSUED BY"].ToString() != null)
            {
                ddlIssuedby.Items.FindByText(dtImigrations.Rows[0]["ISSUED BY"].ToString()).Selected = true;

            }

            hiddenUserImage.Value = dtImigrations.Rows[0]["EMPIMG_DOC_ATTACHMENT"].ToString();
            string strFileName = dtImigrations.Rows[0]["EMPIMG_DOC_ATTACHMENT"].ToString();
            if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
            {
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION) + hiddenUserImage.Value;
                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                {

                    // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy1\" >Click to View Attachment Uploaded</a>";
                    strImage += " <div class=\"lightbox-target\" id=\"goofy1\">";
                    strImage += " <img src=\"" + strImagePath + "\"/>";
                    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                    strImage += "</div>";

                }
                else
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                }
                divImageDisplay12.InnerHtml = strImage;
            }
        }
    }




    public class immigration
    {
        public string issudate;
        public string EMPIMG_DOC_ATTACHMENT;

        public string Imig_Id;
        public string EMPIMG_ID;
        public string DOCUMENT;
        public string NUMBER;
        public string USER_ID;
        public string CNTRY_NAME;
        public string ORG_ID;
        public string ISSUEDATE;
        public string CORPRT_ID;
        public string EXPIRY;
        public string EMPIMG_DOC_TYPEID;
        public string EMPIMG_ELIGBLE_STATUS;
        public string REVIEWDATE;
        public string EMPIMG_DOC_COMMENTS;
        public string IfRsnShw;
        public string attachname;
        public string strhtml;
        public string visatype;
        public string Centernum;
        public string ConvertDataTableToHTMLImmigration(DataTable dt)
        {

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableImgrtn\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            int intReCallForTAble = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

                if (intCnclUsrId != 0)
                {
                    intReCallForTAble = 1;
                }

            }
            strHtml += "<th class=\"thT\" style=\"width:2%;text-align: left; word-wrap:break-word;\">SL#</th>";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {

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
                    strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[5].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[6].ColumnName + "</th>";
                }

                else if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[7].ColumnName + "</th>";
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
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatusMode = "";
                int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
                int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

                strHtml += "<tr  >";
                Id = dt.Rows[intRowBodyCount][0].ToString();
                string strdoc = dt.Rows[intRowBodyCount][1].ToString();
                int slno = intRowBodyCount + 1;
                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>"; //3emp17

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {
                    string usr = dt.Rows[intRowBodyCount]["USER_ID"].ToString();

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
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][5].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 4)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][6].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 5)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][7].ToString() + "</td>"; //3emp17
                    }
                    else if (intColumnBodyCount == 6)
                    {
                        // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                        strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='../../Images/Icons/edit.png' /> " + "</a> </td>";  //3emp17

                    }

                    else if (intColumnBodyCount == 7)
                    {



                        strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1%;margin-left:1% \"onclick=\"return DeleteImigrationByid('" + Id + "','" + usr + "','" + strdoc + "');\" >" + "<img   src='../../Images/Icons/delete.png' /> " + "</a> </td>";      //3emp17

                    }   //3emp17


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
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityImigrationDtls.Imig_Id = x;
        objEntityImigrationDtls.CorpId = corpid;
        objEntityImigrationDtls.OrgId = orgid;
        objEntityImigrationDtls.Imig_user_id = empid;

        DataTable dt = objBusinessImigration.ReadImmigrationById(objEntityImigrationDtls);



        clsEntityImmigration objEntityImigrationDtls1 = new clsEntityImmigration();
        objImigration.Imig_Id = dt.Rows[0]["EMPIMG_ID"].ToString();

        objImigration.EMPIMG_DOC_TYPEID = dt.Rows[0]["EMPIMG_DOC_TYPEID"].ToString();
        objImigration.DOCUMENT = dt.Rows[0]["NUMBER"].ToString();
        objImigration.issudate = dt.Rows[0]["ISSUEDATE"].ToString();
        objImigration.EXPIRY = dt.Rows[0]["EXPIRY DATE"].ToString();
        objImigration.EMPIMG_ELIGBLE_STATUS = dt.Rows[0]["EMPIMG_ELIGBLE_STATUS"].ToString();
        objImigration.REVIEWDATE = dt.Rows[0]["REVIEWDATE"].ToString();
        objImigration.EMPIMG_DOC_COMMENTS = dt.Rows[0]["EMPIMG_DOC_COMMENTS"].ToString();
        //ie IF  COUNTRY IS ACTIVE

        objImigration.CNTRY_NAME = dt.Rows[0]["EMPIMG_DOC_ISSUEDBY"].ToString();

        objImigration.visatype = dt.Rows[0]["VISATYPE_ID"].ToString();


        objImigration.Centernum = dt.Rows[0]["HC_CENTER_NUM"].ToString();




        //for displaying photo
        string a;
        a = dt.Rows[0]["EMPIMG_DOC_ATTACHMENT"].ToString();
        string strFileName = dt.Rows[0]["EMPIMG_DOC_ATTACHMENT"].ToString();

        //  hiddenImageName.Value = dt.Rows[0]["EMPERDTL_FLNM_ACT"].ToString();
        if (a != null && a != "")
        {
            //    divImageEdit.Visible = true;
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION) + a;
            string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
            string strImage;
            if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
            {

                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy1\" >Click to View Attachment Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofy1\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";

            }
            else
            {
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
            }
            objImigration.attachname = strFileName;
            objImigration.EMPIMG_DOC_ATTACHMENT = strImage;
        }


        return objImigration;




    }
    [WebMethod]
    public static immigration DeleteImigrationByid(int x, int CorpId, int Orgid, int UserId, int Emp_id)
    {
        int id = x;
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        //  clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        immigration objimmigrationtls = new immigration();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        objEntityImigrationDtls.Imig_Emp_id = Emp_id;
        objEntityImigrationDtls.CorpId = CorpId;
        objEntityImigrationDtls.OrgId = Orgid;
        objimmigrationtls.Imig_Id = id.ToString();
        objEntityImigrationDtls.Imig_Id = id;
        //objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);
        objimmigrationtls.Imig_Id = UserId.ToString();
        objEntityImigrationDtls.Imig_user_id = UserId;
        string strrsn = "1";
        objimmigrationtls.ISSUEDATE = System.DateTime.Now.ToString();
        objEntityImigrationDtls.Imigdate = System.DateTime.Now;
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, CorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
            if (CnclrsnMust == "0")
            {
                strrsn = "";
                objEntityImigrationDtls.ImigCancelREASON = objCommon.CancelReason();

                objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);

            }
            else
            {
                objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);
                objimmigrationtls.IfRsnShw = strrsn;
            }

        }
        DataTable dtImigrations = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);//2emp17
        string strHtm = objimmigrationtls.ConvertDataTableToHTMLImmigration(dtImigrations);//2emp17


        objimmigrationtls.strhtml = strHtm;

        objimmigrationtls.IfRsnShw = strrsn;
        return objimmigrationtls;
    }
    public void deleteImigrationDtls(string id)
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "show_updatebutton", "show_updatebutton();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "hide_saveebutton", "hide_saveebutton();", true);


        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        immigration immigrationobj = new immigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityImigrationDtls.Imig_Id = Convert.ToInt32(id);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        hiddenRsnid.Value = id;

    }
    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLImmigration(DataTable dt)
    {

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();

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
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());

            if (intCnclUsrId != 0)
            {
                intReCallForTAble = 1;
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
                //  strHtml += "<th class=\"thT\"  style=\"width:9%;text-align: left; word-wrap:break-word;\">" + dt.Columns[5].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                // strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[6].ColumnName + "</th>";
            }

            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\"  style=\"width:5%;text-align: center; word-wrap:break-word;\">" + dt.Columns[7].ColumnName + "</th>";
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





        // strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">PRINT</th>";

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            int User_Id = 1;
            // int id = Convert.ToInt32(dt.Rows[intRowBodyCount]["EMPIMG_ID"]);
            if (Session["USERID"] != null)
            {
                User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;
            string strStatusMode = "";
            int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["CANCEL USER ID"].ToString());
            int intCancTransaction = Convert.ToInt32(dt.Rows[intRowBodyCount]["COUNT_TRANSACTION"].ToString());

            strHtml += "<tr  >";
            Id = dt.Rows[intRowBodyCount][0].ToString();
            string strdoc = dt.Rows[intRowBodyCount][1].ToString();
            int slno = intRowBodyCount + 1;
            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno + "</td>"; //3emp17

            for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
            {
                string usr = dt.Rows[intRowBodyCount]["USER_ID"].ToString();

                if (intColumnBodyCount == 1)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:19%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:25%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }


                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount][7].ToString() + "</td>"; //3emp17
                }

                else if (intColumnBodyCount == 6)
                {
                    // strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='../../Images/Icons/edit.png' /> " + "</a> </td>";  //3emp17

                }

                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1%;margin-left:1% \"onclick=\"return DeleteImigrationByid('" + Id + "','" + usr + "','" + strdoc + "');\" >" + "<img   src='../../Images/Icons/delete.png' /> " + "</a> </td>";      //3emp17
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



    protected void btnAddJobDtls_Click(object sender, EventArgs e)
    {
        int intCorpId = 0;
        int intOrgId = 0;
        int IntUsrId = 0;
        int intUsrRolMstrId;
        int intEnableRenew = 0;
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }       
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"].ToString());
            IntUsrId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //EVM-0027
        if (ddlProject.Text == "--SELECT PROJECT--")
        {
            objEntityJobDetails.Project = 0;

        }
        else
        {
            objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        if (ddlSponsor.Text == "--SELECT SPONSOR--")
        {
            objEntityJobDetails.Sponsorid = 0;

        }
        else
        {
            objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        }


        //END

        objEntityJobDetails.JoinedDate = objCommon.textToDateTime(txtJoineddate.Text);
        if (txtpermanencyDate.Text == "")
        {
            objEntityJobDetails.PermamanencyDate = DateTime.Today;
        }
        else
        {
            objEntityJobDetails.PermamanencyDate = objCommon.textToDateTime(txtpermanencyDate.Text);
        }
        if (txtProbationdate.Text == "")
        {
            objEntityJobDetails.ProbationEnddate = DateTime.Today;
        }
        else
        {

            objEntityJobDetails.ProbationEnddate = objCommon.textToDateTime(txtProbationdate.Text);
        }
        if (TxtPeriod.Text == "")
        {
            objEntityJobDetails.Probation = 0;
        }
        else
        {
            objEntityJobDetails.Probation = int.Parse(TxtPeriod.Text);
        }

        if (ddlDepartment.Text == "--SELECT DEPARTMENT--")
        {
            objEntityJobDetails.Department_Id = 0;
        }
        else
        {

            objEntityJobDetails.Department_Id = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }

        objEntityJobDetails.Description = TxtJobDesc.Text;

        objEntityJobDetails.Designation = 0;



        if (ddlDivision.Text == "--SELECT DIVISION--")
        {
            objEntityJobDetails.Division = 0;
        }
        else
        {

            objEntityJobDetails.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        };
        objEntityJobDetails.EmployeeId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        //   objEntityJobDetails.EmployeeLocation = TxtLocation.Text; HiddenEmpId.Value
        //EVM-0024
        objEntityJobDetails.EmployeeType = HiddenEmpType.Value;
        //END
        // objEntityJobDetails.EmployeeType = ddlEmployeeType.SelectedItem.Text;
        objEntityJobDetails.JobCancelREASON = Txtelgblestats.Text;
        objEntityJobDetails.JobTitle = TxtjobTitle.Text;
        objEntityJobDetails.JobUserDate = DateTime.Now;
        //evm-0027
       // objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
        //EVM-0027
        objEntityJobDetails.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
        DataTable dtDsgnMastr = objBusinessJobDetails.ReadDesignationType(objEntityJobDetails);
        //objEntityJobDetails.JobType = ddtype.SelectedItem.Text;
        if (dtDsgnMastr.Rows[0]["D_TYPE"].ToString() == "1")
        {
            objEntityJobDetails.JobType = "Labour";
        }
        else
        {
            objEntityJobDetails.JobType = "Staff";
        }
        //objEntityJobDetails.JobType = Convert.ToInt32(dtDsgnMastr.Rows[0]["D_TYPE"]); 
        objEntityJobDetails.ProjectLocation = Txtprojloc.Text;
        //EVM-0027
     //   objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        //END
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEEJOB);
        objEntityCommon.CorporateID = intCorpId;
        objEntityCommon.Organisation_Id = intOrgId;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityJobDetails.Job_Id = Convert.ToInt32(strNextId);

        objBusinessJobDetails.AddJobDetails(objEntityJobDetails);
        Hiddenjobid.Value = strNextId;
        BtnsaveJob.Visible = false;
        BtnupdateJob.Visible = true;
        Btnclrjob.Visible = true;
        txtProbationdate.Enabled = false;
        ddlPlusWeek.Enabled = false;//evm--0024
        //Response.Redirect("gen_Emply_Personal_Informn.aspx?InsUpd=Ins");

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(IntUsrId, intUsrRolMstrId);
        if (dtChildRol.Rows.Count > 0)
        {
            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            foreach (string strC_Role in strChildDefArrWords)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    intEnableRenew = 1;
            }
        }
        if (intEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            divRenewImg.Visible = true;
        }
        else
        {
            divRenewImg.Visible = false;
        }
        InsUserLeaveTypes(intCorpId, intOrgId, objEntityJobDetails.EmployeeId, objEntityJobDetails.JoinedDate,1);
        ScriptManager.RegisterStartupScript(this, GetType(), "JobSuccessConfirmation", "JobSuccessConfirmation();", true);


    }

    public decimal CalculateDays(DateTime dtFrom, DateTime dtTo)
    {
        decimal TotalDays = Convert.ToInt32((dtTo - dtFrom).TotalDays) + 1;
        if (TotalDays > 365)
        {
            TotalDays = 365;
        }
        return TotalDays;
    }
    public void InsUserLeaveTypes(int intCorpId, int intOrgId, int EmployeeId,DateTime DtJoinDate,int DeleSts)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLeaveRequest objBusinessLeaveRequest1 = new clsBusinessLeaveRequest();
        clsEntityLeaveRequest objEntityLeaveRequest1 = new clsEntityLeaveRequest();
        objEntityLeaveRequest1.Corporate_id = intCorpId;
        objEntityLeaveRequest1.Organisation_id = intOrgId;
        objEntityLeaveRequest1.User_Id = EmployeeId;
        DateTime dtCurreDate=objCommon.textToDateTime(hiddenCurrentDate.Value);
        DataTable DtLevAlloDetails = objBusinessLeaveRequest1.ReadLeavTypdtl(objEntityLeaveRequest1);
        DataTable DtUser = objBusinessLeaveRequest1.ReadUserDetails(objEntityLeaveRequest1);
        string UsrDesg = DtUser.Rows[0]["DSGN_ID"].ToString();
        string UsrJoinDate = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
        string UsrGender = DtUser.Rows[0]["EMPERDTL_GENDER"].ToString();
        string UsrMrtlSts = DtUser.Rows[0]["EMPERDTL_MRTL_STS"].ToString();
        string UsrPayGrd = DtUser.Rows[0]["PYGRD_ID"].ToString();

        foreach (DataRow rowDepnt in DtLevAlloDetails.Rows)
        {
            string GendrChck = "false", MrtlChck = "false", DesgChck = "false", PayGrdChck = "false", ExpChck = "false", IndvdlLvTypChk = "false";

            if (rowDepnt["EMPLEAVTYP_ID"].ToString() != "")
            {
                IndvdlLvTypChk = "true";
            }
            
            objEntityLeaveRequest1.Leave_Id = Convert.ToInt32(rowDepnt["LEAVETYP_ID"].ToString());
            DataTable dtGendrMrtSts = objBusinessLeaveRequest1.ReadGendrMrtSts(objEntityLeaveRequest1);
            DataTable dtDesgDtls = objBusinessLeaveRequest1.ReadDesgDtls(objEntityLeaveRequest1);
            DataTable dtPayGrdeDtls = objBusinessLeaveRequest1.ReadPayGrdedtls(objEntityLeaveRequest1);
            DataTable dtExpDtls = objBusinessLeaveRequest1.ReadExpDtls(objEntityLeaveRequest1);

            //For gender check
            if (dtGendrMrtSts.Rows.Count > 0)
            {
                if (dtGendrMrtSts.Rows[0][0].ToString() == "2")
                {
                    GendrChck = "true";
                }
                else if (dtGendrMrtSts.Rows[0][0].ToString() == UsrGender)
                {
                    GendrChck = "true";
                }
            }
            //For marrital status
            if (dtGendrMrtSts.Rows.Count > 0)
            {
                if (dtGendrMrtSts.Rows[0][1].ToString() == "2")
                {
                    MrtlChck = "true";
                }
                else if (dtGendrMrtSts.Rows[0][1].ToString() != UsrGender)
                {
                    MrtlChck = "true";
                }
            }
            //For Designation 
            if (dtDesgDtls.Rows.Count > 0)
            {
                if (dtDesgDtls.Rows[0][1].ToString() == "1")
                {
                    DesgChck = "true";
                }
                else
                {
                    foreach (DataRow rowDesg in dtDesgDtls.Rows)
                    {
                        if (rowDesg[0].ToString() == UsrDesg)
                        {
                            DesgChck = "true";
                            break;
                        }
                    }

                }
            }
            //For paygrade
            if (dtPayGrdeDtls.Rows.Count > 0)
            {
                if (dtPayGrdeDtls.Rows[0][1].ToString() == "1")
                {
                    PayGrdChck = "true";
                }
                else
                {
                    foreach (DataRow rowDesg in dtPayGrdeDtls.Rows)
                    {
                        if (rowDesg[0].ToString() == UsrPayGrd)
                        {
                            PayGrdChck = "true";
                            break;
                        }
                    }

                }
            }
            //For experience
            decimal ExpYears = 0;
            if (UsrJoinDate != "")
            {

                DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
                //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                ExpYears = (dtCurreDate.Month - Dob.Month) + 12 * (dtCurreDate.Year - Dob.Year);
                ExpYears = ExpYears / 12;
            }

            if (dtExpDtls.Rows.Count > 0)
            {
                if (dtExpDtls.Rows[0][1].ToString() == "1")
                {
                    ExpChck = "true";
                }
                else
                {
                    foreach (DataRow rowDesg in dtExpDtls.Rows)
                    {
                        int intMinYear= Convert.ToInt32(rowDesg[2]);
                        int intMaxYear= Convert.ToInt32(rowDesg[3]);
                        if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                        {
                            ExpChck = "true";
                        }
                        

                        //if (rowDesg[0].ToString() == "1")
                        //{
                        //    if (ExpYears >= 0 && ExpYears <= 2)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}

                        //else if (rowDesg[0].ToString() == "2")
                        //{
                        //    if (ExpYears >= 2 && ExpYears <= 4)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}

                        //else if (rowDesg[0].ToString() == "3")
                        //{
                        //    if (ExpYears >= 4 && ExpYears <= 6)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}

                        //else if (rowDesg[0].ToString() == "4")
                        //{
                        //    if (ExpYears >= 6 && ExpYears <= 8)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}

                        //else if (rowDesg[0].ToString() == "5")
                        //{
                        //    if (ExpYears >= 8 && ExpYears <= 10)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "6")
                        //{
                        //    if (ExpYears >= 10 && ExpYears <= 15)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                        //else if (rowDesg[0].ToString() == "7")
                        //{
                        //    if (ExpYears >= 15 && ExpYears <= 20)
                        //    {
                        //        ExpChck = "true";
                        //    }
                        //}
                    }

                }
            }


            if ((DesgChck == "true" || ExpChck == "true" || PayGrdChck == "true" || IndvdlLvTypChk == "true") && (GendrChck == "true" && MrtlChck == "true"))
            {
            }
            else
            {
                rowDepnt.Delete();
              
            }
        }
        DtLevAlloDetails.AcceptChanges();
        decimal days=365;
        if (dtCurreDate.Year > DtJoinDate.Year)
        {
            DtJoinDate = new DateTime(dtCurreDate.Year, 1, 1);
        }
        else
        {
            days = CalculateDays(DtJoinDate, new DateTime(DtJoinDate.Year, 12, 31));
        }
        if (DeleSts == 1)
        {
            objBusinessLeaveRequest1.DeleteUSerLeaveTypes(objEntityLeaveRequest1);
        }
        for (int i = 0; i < DtLevAlloDetails.Rows.Count; i++)
        {
            string strchkuserlevCount = "0";
            objEntityLeaveRequest1.LeaveFrmDate = DtJoinDate;
            objEntityLeaveRequest1.Leave_Id = Convert.ToInt32(DtLevAlloDetails.Rows[i]["LEAVETYP_ID"].ToString());
            strchkuserlevCount = objBusinessLeaveRequest1.chkUserLevCount(objEntityLeaveRequest1);
            objEntityLeaveRequest1.OpeningLv = (Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString()) / 365) * days;
            objEntityLeaveRequest1.RemingLev = (Convert.ToDecimal(DtLevAlloDetails.Rows[i]["LEAVETYP_NUMDAYS"].ToString()) / 365) * days;
            if (strchkuserlevCount != "0" && strchkuserlevCount != "")
            {
            }
            else
            {
                objBusinessLeaveRequest1.InsertUserNewLevRow(objEntityLeaveRequest1);
            }
        }
    }

    protected void btnAddProjDtls_Click(object sender, EventArgs e)
    {
        int intCorpId = 0;
        int intOrgId = 0;
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityProjectAssign.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        ObjEntityProjectAssign.Project_Comments = TxtProjectComments.Text;
        ObjEntityProjectAssign.Project_EndDate = objCommon.textToDateTime(txtProjectEndDate.Text); ;
        ObjEntityProjectAssign.ProjectName = ddlprojectassign.SelectedItem.Text;
        ObjEntityProjectAssign.Project_StartDate = objCommon.textToDateTime(txtprojectstartdate.Text).Date; ;

        ObjEntityProjectAssign.ProjectId = Convert.ToInt32(ddlprojectassign.SelectedItem.Value);


        ObjEntityProjectAssign.Project_Job_Id = Convert.ToInt32(Hiddenjobid.Value);

        ObjEntityProjectAssign.UserDate = new DateTime();
        //   ObjEntityProjectAssign.UserId=ses;.
        objEntityJobDetails.Project = ObjEntityProjectAssign.ProjectId;
        objEntityJobDetails.Job_Id = ObjEntityProjectAssign.Project_Job_Id;
        string strReturn = objBusinessJobDetails.Checkproj_Assign(objEntityJobDetails);
        if (strReturn == "0")
        {

            objBusinessJobDetails.AddProjAssign(ObjEntityProjectAssign);
            DataTable dtProjectassign = objBusinessJobDetails.ReadProjAssign(ObjEntityProjectAssign);
            int intEnableModify = 1;
            string strHtm = ConvertDataTableToHTMLProject(dtProjectassign, intEnableModify);
            divreportforProject.InnerHtml = strHtm;



            string strRandom = objCommon.Random_Number();
            string strId = HiddenEmployeeMasterId.Value;
            int intIdLength = HiddenEmployeeMasterId.Value.Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;


            Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveProjectDtls");



           // ScriptManager.RegisterStartupScript(this, GetType(), "projectSuccessConfirmation", "projectSuccessConfirmation();", true);
            TxtProjectComments.Text = "";
            txtprojectstartdate.Text = "";
            txtProjectEndDate.Text = "";
            ddlprojectassign.SelectedIndex = 0;
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "projectSuccessDuplication", "projectSuccessDuplication();", true);

        }
    }

    protected void btnUpdateJobDtls_Click(object sender, EventArgs e)
    {
        clsBusinessLayerJobDetails objBusinessJob = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"].ToString());
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
            objEntityJobDetails.Job_Id = Convert.ToInt32(strId);

        }


        objEntityJobDetails.JoinedDate = objCommon.textToDateTime(txtJoineddate.Text);
        if (txtpermanencyDate.Text == "")
        {
            objEntityJobDetails.PermamanencyDate = new DateTime();
        }
        else
        {
            objEntityJobDetails.PermamanencyDate = objCommon.textToDateTime(txtpermanencyDate.Text);
        }
        if (txtProbationdate.Text == "")
        {
            objEntityJobDetails.ProbationEnddate = new DateTime();
        }
        else
        {

            objEntityJobDetails.ProbationEnddate = objCommon.textToDateTime(txtProbationdate.Text);
        }

        if (TxtPeriod.Text == "")
        {
            objEntityJobDetails.Probation = 0;
        }
        else
        {
            objEntityJobDetails.Probation = int.Parse(TxtPeriod.Text);
        }

        if (ddlDepartment.Text == "--SELECT DEPARTMENT--")
        {
            objEntityJobDetails.Department_Id = 0;
        }
        else
        {

            objEntityJobDetails.Department_Id = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
        }

        objEntityJobDetails.Description = TxtJobDesc.Text;
        if (ddlDesignation.Text == "--SELECT DESIGNATION--")
        {
            objEntityJobDetails.Designation = 0;
        }
        else
        {
            objEntityJobDetails.Designation = Convert.ToInt32(ddlDesignation.SelectedItem.Value);
        }

        if (ddlDivision.Text == "--SELECT DIVISION--")
        {
            objEntityJobDetails.Division = 0;
        }
        else
        {
            objEntityJobDetails.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }

        //EVM-0027
        if (ddlProject.Text == "--SELECT PROJECT--")
        {
            objEntityJobDetails.Project = 0;
              
        }
        else
        {
            objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        if (ddlSponsor.Text == "--SELECT SPONSOR--")
        {
            objEntityJobDetails.Sponsorid = 0;

        }
        else
        {
            objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
        }


            //END
      
        objEntityJobDetails.EmployeeId = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        //   objEntityJobDetails.EmployeeLocation = TxtLocation.Text;  HiddenEmpId.Value
        //evm-0024
        objEntityJobDetails.EmployeeType = HiddenEmpType.Value;
        //end
        // objEntityJobDetails.EmployeeType = ddlEmployeeType.SelectedItem.Text;
        objEntityJobDetails.JobCancelREASON = Txtelgblestats.Text;
        objEntityJobDetails.JobTitle = TxtjobTitle.Text;
        objEntityJobDetails.JobUserDate = new DateTime();
      
     

        objEntityJobDetails.ProjectLocation = Txtprojloc.Text;
       


        objBusinessJob.UpdateJobDetails(objEntityJobDetails);
        BtnupdateJob.Visible = true;
        BtnsaveJob.Visible = false;

        InsUserLeaveTypes(objEntityJobDetails.CorpId, objEntityJobDetails.OrgId, objEntityJobDetails.EmployeeId, objEntityJobDetails.JoinedDate,1);

        //  string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
        ScriptManager.RegisterStartupScript(this, GetType(), "JobSuccessUpdation", "JobSuccessUpdation();", true);
        //Response.Redirect("gen_Emply_Personal_Informn.aspx?InsUpd=Upd");
    }
    protected void btnjobdtlClear_Click(object sender, EventArgs e)
    {

    }
    public void updateJobDtls(string id)
    {
        // BtnupdateJob.Visible = true;
        BtnsaveJob.Visible = true;
        Btnclrjob.Visible = false;
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityImigrationDtls.Imig_Id = Convert.ToInt32(id);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dt = objBusinessImigration.ReadImmigrationById(objEntityImigrationDtls);
        RadioButtonDocList.SelectedValue = dt.Rows[0]["EMPIMG_DOC_TYPEID"].ToString();
        Textnumber.Text = dt.Rows[0]["NUMBER"].ToString();
        TextIssuueddate.Text = dt.Rows[0]["ISSUEDATE"].ToString();
        TxtdivExpiryDate.Text = dt.Rows[0]["EXPIRY DATE"].ToString();
        Txtelgblestats.Text = dt.Rows[0]["EMPIMG_ELIGBLE_STATUS"].ToString();
        TxtEligiblervwdate.Text = dt.Rows[0]["REVIEWDATE"].ToString();
        TxtComments.Text = dt.Rows[0]["EMPIMG_DOC_COMMENTS"].ToString();
        //ie IF  COUNTRY IS ACTIVE
        CountryLoad();
        if (dt.Rows[0]["ISSUED BY"].ToString() != null)
        {
            ddlIssuedby.Items.FindByText(dt.Rows[0]["ISSUED BY"].ToString()).Selected = true;

        }

        //for displaying photo
        hiddenUserImage.Value = dt.Rows[0]["EMPIMG_DOC_ATTACHMENT"].ToString();
        string strFileName = dt.Rows[0]["EMPIMG_DOC_ATTACHMENT"].ToString();
        //  hiddenImageName.Value = dt.Rows[0]["EMPERDTL_FLNM_ACT"].ToString();
        if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
        {
            //    divImageEdit.Visible = true;
            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.EMPLOYEE_IMMIGRATION) + hiddenUserImage.Value;
            string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
            string strImage;
            if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
            {

                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy2\" >Click to View Attachment Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofy2\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";

            }
            else
            {
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
            }
            divImageDisplay12.InnerHtml = strImage;
        }

    }
    public void deleteJobDtls(string id)
    {
        BtnupdateJob.Visible = true;
        BtnsaveJob.Visible = false;
        Btnclrjob.Visible = false;
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityImigrationDtls.Imig_Id = Convert.ToInt32(id);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        hiddenRsnid.Value = id;

    }

    protected void btnRsnSavejob_Click(object sender, EventArgs e)
    {

        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();

        //Creating objects for business layer
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityImigrationDtls.Imig_Id = Convert.ToInt32(hiddenRsnid.Value);



            if (Session["CORPOFFICEID"] != null)
            {
                objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
                objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityImigrationDtls.Imigdate = System.DateTime.Now;
            ObjEntityProjectAssign.ProjAssgnCanReason = "";
            objEntityImigrationDtls.ImigCancelREASON = txtCnclReason.Text.Trim();
            objBusinessImigration.CancelImmigrationById(objEntityImigrationDtls);


            Response.Redirect("gen_Emply_Personal_Informn.aspx?InsUpd=cncl");



        }
    }
    public void CountryLoadforImig()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.readCountry();

        ddlIssuedby.DataSource = dtCountry;

        ddlIssuedby.DataTextField = "CNTRY_NAME";
        ddlIssuedby.DataValueField = "CNTRY_ID";
        ddlIssuedby.DataBind();
        ddlIssuedby.Items.Insert(0, "--Select Country--");
    }
    public void projectLoad(int intDivision = 0)
    {
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //if (ddlDivision.SelectedItem.Value=="")
        {

        }
        int divid = intDivision;
        objEntityJobDetails.Department_Id = divid;
        DataTable dtProject = objBusinessJobDetails.ReadProject(objEntityJobDetails);
        ddlProject.Items.Clear();
        ddlprojectassign.Items.Clear();
        if (dtProject.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProject;
            ddlprojectassign.DataSource = dtProject;

            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataTextField = "PROJECT_NAME";

            ddlprojectassign.DataValueField = "PROJECT_ID";
            ddlprojectassign.DataTextField = "PROJECT_NAME";

            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();
            ddlprojectassign.DataBind();
        }
        ddlprojectassign.Items.Insert(0, "--SELECT PROJECT--");
        ddlProject.Items.Insert(0, "--SELECT PROJECT--");

    }

    public void DesignationLoad()
    {
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdesig = objBusinessJobDetails.ReadDesignation(objEntityJobDetails);
        if (dtdesig.Rows.Count > 0)
        {
            ddlDesignation.DataSource = dtdesig;


            ddlDesignation.DataValueField = "DSGN_ID";
            ddlDesignation.DataTextField = "DSGN_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDesignation.DataBind();

        }
        ddlDesignation.Items.Insert(0, "--SELECT DESIGNATION--");

    }

    public void DepartmentLoad()
    {
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strDsgControlLoginUsr == "O")
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityJobDetails.EmployeeId = Convert.ToInt32(strId);
            }
        }
        DataTable dtdepartment = objBusinessJobDetails.ReadDepartment(objEntityJobDetails);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlDepartment.DataSource = dtdepartment;
            ddlDepartment.Items.Clear();

            ddlDepartment.DataValueField = "CPRDEPT_ID";
            ddlDepartment.DataTextField = "CPRDEPT_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlDepartment.DataBind();

        }

        ddlDepartment.Items.Insert(0, "--SELECT DEPARTMENT--");
        if (ddlDepartment.Items.FindByValue(rbtnCropDept.SelectedValue) != null)
        {
            ddlDepartment.ClearSelection();
            ddlDepartment.Items.FindByValue(rbtnCropDept.SelectedValue).Selected = true;
        }

    }

    public void SponsorLoad()
    {
        //evm-0012

        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strDsgControlLoginUsr == "O")
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityJobDetails.EmployeeId = Convert.ToInt32(strId);
            }
        }


        DataTable dtSponsor = objBusinessJobDetails.ReadSponsor(objEntityJobDetails);
        if (dtSponsor.Rows.Count > 0)
        {
            ddlSponsor.Items.Clear();
            ddlSponsor.DataSource = dtSponsor;
            ddlSponsor.DataValueField = "SPSNSR_ID";
            ddlSponsor.DataTextField = "SPNSR_NAME";
            ddlSponsor.DataBind();

        }





        ddlSponsor.Items.Insert(0, "--SELECT SPONSOR--");

    }
    public void DivisionLoad()
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();

        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (rbtnCropDept.SelectedValue != "" && rbtnCropDept.SelectedValue != null)
        {
            objEntityUsrRegistr.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedValue);

        }
        DataTable dtCrptDvsn = new DataTable();
        dtCrptDvsn = objBusinessLayerUserRegisteration.ReadCrptDivisionsDetails(objEntityUsrRegistr);
        dtCorpDivVisibility = dtCrptDvsn;
        if (dtCrptDvsn.Rows.Count == 0)
        {

            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        }
        if (dtCrptDvsn.Rows.Count > 0)
        {

            ddlDivision.Items.Clear();
            ddlDivision.DataSource = dtCrptDvsn;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        }
    }

    public void AccomodationLoad()
    {
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinessJobDetails.ReadAccomodation(objEntityJobDetails);
        //  ddlAccomodation.Items.Clear();
        if (dtDivision.Rows.Count > 0)
        {


        }


    }

    public void ddlload()
    {
        ddlEmployeeType.Items.Clear();

        ddlEmployeeType.Items.Insert(0, "--SELECT TYPE--");
        ddlEmployeeType.Items.Insert(1, "Permanent");
        ddlEmployeeType.Items.Insert(2, "Contract");
        ddlEmployeeType.DataBind();

        ddlStafftype.Items.Clear();

        ddlStafftype.Items.Add(new ListItem("--SELECT TYPE--", "2"));
        ddlStafftype.Items.Add(new ListItem("Staff", "0"));
        ddlStafftype.Items.Add(new ListItem("Worker", "1"));
        ddlStafftype.DataBind();
        ddlStafftype.Items.FindByValue("2").Selected = true;

    }
    //It build the Html table by using the datatable provided    public string ConvertDataTableToHTMLProject(DataTable dt, int intEnableModify)
    public string ConvertDataTableToHTMLProject(DataTable dt, int intEnableModify)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableforproject\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
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
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }


        }

        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:5%;text-align: center; word-wrap:break-word;\">DELETE</th>";


        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        int Id = 0;
        int jobid = 0;
        int slno = 0;
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {
            jobid = Convert.ToInt32(dt.Rows[intRowBodyCount]["PROJASSN_JOB_DTL_ID"].ToString());
            Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["PROJASSN_ID"].ToString());
            int intCnclUsrId = 0;


            strHtml += "<tr  >";

            slno = intRowBodyCount + 1;
            //  strHtml += "<td class=\"tdT\" style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + slno  + "</td>";


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
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 3)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }

            }


            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1.5%;margin-left:-2%;\"onclick=\"return EditprojectByid('" + Id + "');\" >" + "<img  style=\"margin-left: 60%;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
            strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1.5%;margin-left:-2%;\"onclick=\"return DeleteprojectByid('" + Id + "','" + jobid + "');\" >" + "<img style=\"margin-left: 66%;\"   src='../../Images/Icons/delete.png' /> " + "</a> </td>";

        }


        strHtml += "</tr>";



        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    [WebMethod]
    public static clsEntityProjectAssign ReadProjectById(int x)
    {
        int id = x;
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();

        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
        ObjEntityProjectAssign.Project_Asgn_Id = id;

        DataTable dtProjectassign = objBusinessJobDetails.ReadProjAssignById(ObjEntityProjectAssign);
        clsEntityProjectAssign ObjEntityProjectAssign1 = new clsEntityProjectAssign();

        ObjEntityProjectAssign1.Project_Comments = dtProjectassign.Rows[0]["PROJASSN_PROJ_COMMENTS"].ToString();

        ObjEntityProjectAssign1.ProjectId = Int32.Parse(dtProjectassign.Rows[0]["PROJASSN_PROJ_ID"].ToString());
        ObjEntityProjectAssign1.ProjAssgnCanReason = dtProjectassign.Rows[0]["Project_EndDate"].ToString();
        ObjEntityProjectAssign1.ProjectName = dtProjectassign.Rows[0]["Project_StartDate"].ToString();
        ObjEntityProjectAssign1.Project_Asgn_Id = Int32.Parse(dtProjectassign.Rows[0]["PROJASSN_ID"].ToString());

        return ObjEntityProjectAssign1;
    }
    public class projectdetails
    {
        public string projectdetaillist = "";
        public string ifrsnshw = "";
        public string ConvertDataTableToHTMLProject(DataTable dt, int intEnableModify)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableforprojectweb\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";
            //   strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";
            //      strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">SL NO</th>";

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
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }
                else if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\"  style=\"width:10%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
                }


            }

            strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">EDIT</th>";
            strHtml += "<th class=\"thT\" style=\"width:5%;text-align: left; word-wrap:break-word;\">DELETE</th>";


            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            int Id = 0;
            int jobid = 0;
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                jobid = Convert.ToInt32(dt.Rows[intRowBodyCount]["PROJASSN_JOB_DTL_ID"].ToString());
                Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["PROJASSN_ID"].ToString());
                int intCnclUsrId = 0;

                strHtml += "<tr  >";

                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    else if (intColumnBodyCount == 3)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }

                }


                strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a    onclick=\"return EditprojectByid('" + Id + "');\" >" + "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                strHtml += "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;\">" + " <a   onclick=\"return DeleteprojectByid('" + Id + "','" + jobid + "');\" >" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";


            }


            strHtml += "</tr>";



            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }



    }
    [WebMethod]
    public static projectdetails DeleteProjectById(int x, int jobid, int CorpId)
    {
        int id = x;
        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        //  clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        projectdetails objprojdtls = new projectdetails();
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
        string strrsn = "1";
        DataTable dtCorpDetail = new DataTable();
        ObjEntityProjectAssign.Project_Asgn_Id = id;
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, CorpId);


        strrsn = "";
        objEntityImigrationDtls.ImigCancelREASON = objCommon.CancelReason();
        objBusinessJobDetails.DeleteProjectDetails(ObjEntityProjectAssign);
        //ScriptManager.RegisterStartupScript(this, GetType(), "JobSuccessConfirmation", "JobSuccessConfirmation();", true);


        objBusinessJobDetails.DeleteProjectDetails(ObjEntityProjectAssign);
        ObjEntityProjectAssign.Project_Job_Id = jobid;
        DataTable dtproject = objBusinessJobDetails.ReadProjAssign(ObjEntityProjectAssign);
        objprojdtls.projectdetaillist = objprojdtls.ConvertDataTableToHTMLProject(dtproject, 1);
        return objprojdtls;
    }



    protected void btnUpdateProjDtls_Click(object sender, EventArgs e)
    {
        clsBusinessLayerJobDetails objBusinessProjects = new clsBusinessLayerJobDetails();
        clsEntityProjectAssign objEntityProjects = new clsEntityProjectAssign();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["USERID"] != null)
        {
            objEntityProjects.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityProjects.UserDate = System.DateTime.Now;

        objEntityProjects.Project_Comments = TxtProjectComments.Text;
        objEntityProjects.Project_EndDate = objCommon.textToDateTime(txtProjectEndDate.Text); ;
        objEntityProjects.ProjectName = ddlprojectassign.SelectedItem.Text;
        objEntityProjects.Project_StartDate = objCommon.textToDateTime(txtprojectstartdate.Text).Date; ;

        objEntityProjects.ProjectId = Convert.ToInt32(ddlprojectassign.SelectedItem.Value);


        objEntityProjects.Project_Job_Id = Convert.ToInt32(Hiddenjobid.Value);
        objEntityProjects.Project_Asgn_Id = Convert.ToInt32(Hiddenprojassgn.Value);

        objBusinessProjects.UpdateProjectDetails(objEntityProjects);
        TxtProjectComments.Text = "";
        txtprojectstartdate.Text = "";
        txtProjectEndDate.Text = "";
        ddlprojectassign.SelectedIndex = 0;
        // HiddenEmpoyeeid.Value = strId;
        DataTable dtProjectassign = objBusinessProjects.ReadProjAssign(objEntityProjects);
        int intEnableModify = 1;
        string strHtm = ConvertDataTableToHTMLProject(dtProjectassign, intEnableModify);
        divreportforProject.InnerHtml = strHtm;

        // string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
        ScriptManager.RegisterStartupScript(this, GetType(), "projectSuccessUpdation", "projectSuccessUpdation();", true);
        // Response.Redirect("gen_Emply_Personal_Informn.aspx?InsUpd=Upd");
    }
    public void filljob(DataTable dt)
    {
        BtnupdateJob.Visible = true;
        BtnsaveJob.Visible = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "show_clearbuttonproj", "show_clearbuttonproj();", true);

        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
        // clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
        //ddlload();
        //CountryLoadforImig();

        DepartmentLoad();
        SponsorLoad();
        DesignationLoad();

        // AccomodationLoad();
        txtJoineddate.Text = dt.Rows[0]["EMP_JOINED_DATE"].ToString();

        if (dt.Rows[0]["COUNT_ROWS"].ToString() != "0")
        {
            txtJoineddate.Enabled = false;
        }

        txtProbationdate.Text = dt.Rows[0]["EMP_PROBATION_END_DATE"].ToString();
        TxtPeriod.Text = dt.Rows[0]["EMP_PROBATION_PERIOD"].ToString();
        txtpermanencyDate.Text = dt.Rows[0]["EMP_PERMANENCY_DATE"].ToString();

        //if (dt.Rows[0]["EMP_DEP_ID"].ToString() != "")
        //{
        //    if (ddlDepartment.Items.FindByValue(dt.Rows[0]["EMP_DEP_ID"].ToString()) != null)
        //    {
        //        ddlDepartment.Items.FindByValue(dt.Rows[0]["EMP_DEP_ID"].ToString()).Selected = true;
        //    }
        //    else
        //    {
        //        ListItem lstGrp = new ListItem(dt.Rows[0]["CPRDEPT_NAME"].ToString(), dt.Rows[0]["EMP_DEP_ID"].ToString());
        //        ddlDepartment.Items.Insert(1, lstGrp);

        //        SortDDL(ref this.ddlDesignation);

        //        ddlDepartment.Items.FindByValue(dt.Rows[0]["EMP_DEP_ID"].ToString()).Selected = true;
        //    }
        //}

        //if(dt.Rows[0]["EMP_TYPE"].ToString()!="")
        //{
        //    ddlEmployeeType.Items.FindByValue(dt.Rows[0]["EMP_TYPE"].ToString()).Selected = true;
        //}

      //  if (dt.Rows[0]["EMP_DIV_ID"].ToString() != "")
            //{
            //    ddlDivision.ClearSelection();
            //    if (ddlDivision.Items.FindByValue(dt.Rows[0]["EMP_DIV_ID"].ToString()) != null)
            //    {
            //        ddlDivision.Items.FindByValue(dt.Rows[0]["EMP_DIV_ID"].ToString()).Selected = true;
            //    }
            //    else
            //    {

            //        ListItem lstGrp = new ListItem(dt.Rows[0]["CPRDIV_NAME"].ToString(), dt.Rows[0]["EMP_DIV_ID"].ToString());
            //        ddlDivision.Items.Insert(0, lstGrp);

            //        SortDDL(ref this.ddlDesignation);

            //        ddlDivision.Items.FindByValue(dt.Rows[0]["EMP_DIV_ID"].ToString()).Selected = true;
            //    }
            //    projectLoad(Convert.ToInt32(dt.Rows[0]["EMP_DIV_ID"]));
            //}


            //if (dt.Rows[0]["EMP_PROJ_ID"].ToString() != "")
            //{
            //    if (ddlProject.Items.FindByValue(dt.Rows[0]["EMP_PROJ_ID"].ToString()) != null)
            //    {
            //        ddlProject.Items.FindByValue(dt.Rows[0]["EMP_PROJ_ID"].ToString()).Selected = true;
            //    }
            //    else
            //    {
            //        ListItem lstGrp = new ListItem(dt.Rows[0]["PROJECT_NAME"].ToString(), dt.Rows[0]["EMP_PROJ_ID"].ToString());
            //        ddlProject.Items.Insert(1, lstGrp);

            //        SortDDL(ref this.ddlDesignation);

            //        ddlProject.Items.FindByValue(dt.Rows[0]["EMP_PROJ_ID"].ToString()).Selected = true;
            //    }
            //}
            if (dt.Rows[0]["EMP_SPNSR_ID"].ToString() != "")
            {
                if (ddlSponsor.Items.FindByValue(dt.Rows[0]["EMP_SPNSR_ID"].ToString()) != null)
                {
                    ddlSponsor.Items.FindByValue(dt.Rows[0]["EMP_SPNSR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["SPNSR_NAME"].ToString(), dt.Rows[0]["EMP_SPNSR_ID"].ToString());
                    ddlSponsor.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDesignation);

                    ddlSponsor.Items.FindByValue(dt.Rows[0]["EMP_SPNSR_ID"].ToString()).Selected = true;
                }
            }


        TxtJobDesc.Text = dt.Rows[0]["EMP_JOB_DESC"].ToString();

        TxtjobTitle.Text = dt.Rows[0]["EMP_JOB_TITLE"].ToString();
        //objEntityJobDetails.JobUserDate = dt.Rows[0]["EMP_JOINED_DATE"].ToString();

        //  ddlStafftype.SelectedItem.Text = dt.Rows[0]["EMP_JOB_TYPE"].ToString();
        Txtprojloc.Text = dt.Rows[0]["EMP_PROJ_LOC"].ToString();

        ObjEntityProjectAssign.Project_Job_Id = Int32.Parse(dt.Rows[0]["EMPJOB_ID"].ToString());
        Hiddenjobid.Value = dt.Rows[0]["EMPJOB_ID"].ToString();
        DivisionLoad();
        if (dt.Rows[0]["EMP_DIV_ID"].ToString() != "")
        {
            ddlDivision.ClearSelection();
            if (ddlDivision.Items.FindByValue(dt.Rows[0]["EMP_DIV_ID"].ToString()) != null)
            {
                ddlDivision.Items.FindByValue(dt.Rows[0]["EMP_DIV_ID"].ToString()).Selected = true;
            }
            else
            {

                ListItem lstGrp = new ListItem(dt.Rows[0]["CPRDIV_NAME"].ToString(), dt.Rows[0]["EMP_DIV_ID"].ToString());
                ddlDivision.Items.Insert(0, lstGrp);

                SortDDL(ref this.ddlDesignation);

                ddlDivision.Items.FindByValue(dt.Rows[0]["EMP_DIV_ID"].ToString()).Selected = true;
            }
            projectLoad(Convert.ToInt32(dt.Rows[0]["EMP_DIV_ID"]));
        }
        if (dt.Rows[0]["EMP_PROJ_ID"].ToString() != "")
        {
            if (ddlProject.Items.FindByValue(dt.Rows[0]["EMP_PROJ_ID"].ToString()) != null)
            {
                ddlProject.Items.FindByValue(dt.Rows[0]["EMP_PROJ_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dt.Rows[0]["PROJECT_NAME"].ToString(), dt.Rows[0]["EMP_PROJ_ID"].ToString());
                ddlProject.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlDesignation);

                ddlProject.Items.FindByValue(dt.Rows[0]["EMP_PROJ_ID"].ToString()).Selected = true;
            }
        }
        DataTable dtProjectassign = objBusinessJobDetails.ReadProjAssign(ObjEntityProjectAssign);
        int intEnableModify = 1;
        string strHtm = ConvertDataTableToHTMLProject(dtProjectassign, intEnableModify);
        divreportforProject.InnerHtml = strHtm;

    }
    //End imigration and job

    //CONTACT DETAILS
    [WebMethod]
    public static string countryChangeCommu(string tableName, string countryId)
    {
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.CountryId = Convert.ToInt32(countryId);
        DataTable dtState = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        dtState.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtState.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    //CONTACT DETAILS
    [WebMethod]
    public static string countryChangeCD(string tableName, string countryId)
    {
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.CountryId = Convert.ToInt32(countryId);
        DataTable dtState = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        dtState.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtState.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    //CONTACT DETAILS
    [WebMethod]
    public static string stateChangeCD(string tableName, string stateId)
    {
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.StateId = Convert.ToInt32(stateId);
        DataTable dtCity = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        dtCity.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCity.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
    }
    //CONTACT DETAILS
    [WebMethod]
    public static string stateChangeCommu(string tableName, string stateId)
    {
        clsEntityCorpOffice objEntityCorp = new clsEntityCorpOffice();
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        objEntityCorp.StateId = Convert.ToInt32(stateId);
        DataTable dtCity = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        dtCity.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtCity.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
    }
    //CONTACT DETAILS DIV

    //Assinging the states to state dropdown list that the country have.
    public void StateLoadCD(clsEntityCorpOffice objEntityCorp)
    {
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        DataTable dtState = objBusinessLayerCorpOffice.ReadState(objEntityCorp);
        ddlStateCD.DataSource = dtState;
        ddlStateCD.DataTextField = "STATE_NAME";
        ddlStateCD.DataValueField = "STATE_ID";
        ddlStateCD.DataBind();
        ddlStateCD.Items.Insert(0, "--Select State--");
    }
    //CONTACT DETAILS DIV

    //Assinging the states to state dropdown list that the country have.
    public void StateLoadCommu(clsEntityCorpOffice objEntityCorp)
    {
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        DataTable dtState = objBusinessLayerCorpOffice.ReadState(objEntityCorp);

        ddlCommuStateCD.DataSource = dtState;

        ddlCommuStateCD.DataTextField = "STATE_NAME";
        ddlCommuStateCD.DataValueField = "STATE_ID";
        ddlCommuStateCD.DataBind();

        ddlCommuStateCD.Items.Insert(0, "--Select State--");
    }
    //CONTACT DETAILS DIV

    //Assign cities to the city dropdown list that the state have
    public void CityLoadCD(clsEntityCorpOffice objEntityCorp)
    {
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        DataTable dtCity = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        ddlCityCD.DataSource = dtCity;
        ddlCityCD.DataTextField = "CITY_NAME";
        ddlCityCD.DataValueField = "CITY_ID";
        ddlCityCD.DataBind();
        ddlCityCD.Items.Insert(0, "--Select City--");
    }
    //CONTACT DETAILS DIV

    public void CityLoadCommu(clsEntityCorpOffice objEntityCorp)
    {
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        DataTable dtCity = objBusinessLayerCorpOffice.ReadCity(objEntityCorp);
        ddlCommuCityCD.DataSource = dtCity;
        ddlCommuCityCD.DataTextField = "CITY_NAME";
        ddlCommuCityCD.DataValueField = "CITY_ID";
        ddlCommuCityCD.DataBind();
        ddlCommuCityCD.Items.Insert(0, "--Select City--");
    }
    //CONTACT DETAILS DIV

    public void CountryLoadCD()
    {
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        DataTable dtCountry = objBusinessLayerCorpOffice.ReadCountry();
        ddlCountryCD.DataSource = dtCountry;
        ddlCountryCD.DataTextField = "CNTRY_NAME";
        ddlCountryCD.DataValueField = "CNTRY_ID";
        ddlCountryCD.DataBind();
        ddlCountryCD.Items.Insert(0, "--Select Country--");
    }
    //CONTACT DETAILS DIV

    public void CountryLoadCommu()
    {
        clsBusinesslayerCorporateOffice objBusinessLayerCorpOffice = new clsBusinesslayerCorporateOffice();
        DataTable dtCountry = objBusinessLayerCorpOffice.ReadCountry();

        ddlCommuCountryCD.DataSource = dtCountry;
        ddlCommuCountryCD.DataTextField = "CNTRY_NAME";
        ddlCommuCountryCD.DataValueField = "CNTRY_ID";
        ddlCommuCountryCD.DataBind();
        ddlCommuCountryCD.Items.Insert(0, "--Select Country--");
    }
    //CONTACT DETAILS DIV

    public void LoadRelation()
    {
        clsBusinessLayerContactDtls objBussinesEmp = new clsBusinessLayerContactDtls();
        DataTable dtrelate = objBussinesEmp.ReadRelation();
        ddlEmrgRelat.DataSource = dtrelate;
        ddlEmrgRelat.DataTextField = "RELATE_NAME";
        ddlEmrgRelat.DataValueField = "RELATE_ID";
        ddlEmrgRelat.DataBind();
        ddlEmrgRelat.Items.Insert(0, "--Select Relation--");
        ddlEmrgRelat.DataSource = dtrelate;

    }

    //CONTACT DETAILS START

    public void update_Contact_dtls(string id)
    {
        btnUpdateCD.Visible = true;
        btnAddCD.Visible = false;
        btnClearCD.Visible = false;
        clsBusinessLayerContactDtls objBussEmp = new clsBusinessLayerContactDtls();
        //clsEntityLayerContactDtls objEntEmp = new clsEntityLayerContactDtls();
        clsEntityCorpOffice objEntCorpOffice = new clsEntityCorpOffice();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityEmp.EmpID = Convert.ToInt32(id);
        DataTable dt = objBussEmp.ReadContactDtlsById(objEntityEmp);
        txtAdr1.Text = dt.Rows[0]["EMCNDT_ADR1"].ToString();
        txtAdr2.Text = dt.Rows[0]["EMCNDT_ADR2"].ToString();
        txtAdr3.Text = dt.Rows[0]["EMCNDT_ADR3"].ToString();
        txtPhone.Text = dt.Rows[0]["EMCNDT_PHONE"].ToString();
        txtEmail.Text = dt.Rows[0]["EMCNDT_EMAIL"].ToString();
        txtMobile.Text = dt.Rows[0]["EMCNDT_MOBILE"].ToString();
        txtPostalCode.Text = dt.Rows[0]["EMCNDT_ZIPCODE"].ToString();
        txtFax.Text = dt.Rows[0]["EMCNDT_FAX"].ToString();
        txtCommuAddr1.Text = dt.Rows[0]["EMCNDT_CUM_ADR1"].ToString();
        txtCommuAddr2.Text = dt.Rows[0]["EMCNDT_CUM_ADR2"].ToString();
        txtCommuAddr3.Text = dt.Rows[0]["EMCNDT_CUM_ADR3"].ToString();
        txtCommuPhone.Text = dt.Rows[0]["EMCNDT_CUM_PHONE"].ToString();
        txtCommuMobile.Text = dt.Rows[0]["EMCNDT_CUM_MOBILE"].ToString();
        txtCmmuEmail.Text = dt.Rows[0]["EMCNDT_CUM_EMAIL"].ToString();
        txtCommuPostalCode.Text = dt.Rows[0]["EMCNDT_CUM_ZIPCODE"].ToString();
        txtCommuFax.Text = dt.Rows[0]["EMCNDT_CUM_FAX"].ToString();
        txtEmrgAddr.Value = dt.Rows[0]["EMCNDT_EMG_CON_ADR"].ToString();
        txtEmrgName.Text = dt.Rows[0]["EMCNDT_EMG_CON_NAME"].ToString();
        txtEmrgPhone.Text = dt.Rows[0]["EMCNDT_EMG_CON_PHONE"].ToString();
        txtEmrgMobile.Text = dt.Rows[0]["EMP_EMRG_CONT_MOBILE"].ToString();
        txtEmrgEmail.Text = dt.Rows[0]["EMCNDT_EMG_CON_EMAIL"].ToString();
        txtEmrgFax.Text = dt.Rows[0]["EMCNDT_EMG_CON_FAX"].ToString();



        if (!String.IsNullOrEmpty(dt.Rows[0]["EMCNDT_EMG_CON_RELAT"].ToString()))
        {
            // ddlEmrgRelat.Items.FindByText(dt.Rows[0]["EMCNDT_EMG_CON_RELAT"].ToString()).Selected = true;

            //new 
            if (ddlEmrgRelat.Items.FindByText(dt.Rows[0]["EMCNDT_EMG_CON_RELAT"].ToString()) != null)
            {
                ddlEmrgRelat.ClearSelection();
                ddlEmrgRelat.Items.FindByText(dt.Rows[0]["EMCNDT_EMG_CON_RELAT"].ToString()).Selected = true;
            }

            //new 

        }
        //CountryLoad();
        // ie IF  COUNTRY IS ACTIVE
        if (dt.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dt.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
        {
            ddlCountryCD.Items.FindByText(dt.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lst = new ListItem(dt.Rows[0]["CNTRY_NAME"].ToString(), dt.Rows[0]["CNTRY_ID"].ToString());
            ddlCountryCD.Items.Insert(1, lst);
            SortDDL(ref this.ddlNationality);
            ddlCountryCD.Items.FindByText(dt.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
        }
        objEntCorpOffice.CountryId = Convert.ToInt32(dt.Rows[0]["CNTRY_ID"]);
        StateLoadCD(objEntCorpOffice);
        //Check if there is a state id selected or not.
        if (dt.Rows[0]["STATE_ID"].ToString() != "")
        {
            int intStateId = Convert.ToInt32(dt.Rows[0]["STATE_ID"]);
            //ie IF  STATE IS ACTIVE
            if (dt.Rows[0]["STATE_STATUS"].ToString() == "1" && dt.Rows[0]["STATE_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlStateCD.Items.FindByText(dt.Rows[0]["STATE_NAME"].ToString()) != null)
                {
                    ddlStateCD.Items.FindByText(dt.Rows[0]["STATE_NAME"].ToString()).Selected = true;
                }
                else { }
            }
            else { }

            objEntCorpOffice.StateId = intStateId;
            //Search if there is a city id selected or not
            CityLoadCD(objEntCorpOffice);
            if (dt.Rows[0]["CITY_ID"].ToString() != "")
            {

                if (dt.Rows[0]["CITY_STATUS"].ToString() == "1" && dt.Rows[0]["CITY_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlCityCD.Items.FindByText(dt.Rows[0]["CITY_NAME"].ToString()) != null)
                    {
                        ddlCityCD.Items.FindByText(dt.Rows[0]["CITY_NAME"].ToString()).Selected = true;
                    }
                    else { }
                }
                else { }
            }
        }

        // ie IF communication COUNTRY IS ACTIVE
        if (dt.Rows[0]["COM_CNTRY_STATUS"].ToString() == "1" && dt.Rows[0]["COM_CNTRY_CNCL_ID"].ToString() == "")
        {
            ddlCommuCountryCD.Items.FindByText(dt.Rows[0]["COM_CNTRY_NAME"].ToString()).Selected = true;

        }
        else
        {
            ListItem lst = new ListItem(dt.Rows[0]["COM_CNTRY_NAME"].ToString(), dt.Rows[0]["COM_CNTRY_ID"].ToString());
            ddlCommuCountryCD.Items.Insert(1, lst);

            SortDDL(ref this.ddlNationality);

            ddlCommuCountryCD.Items.FindByText(dt.Rows[0]["COM_CNTRY_NAME"].ToString()).Selected = true;
        }

        objEntCorpOffice.CountryId = Convert.ToInt32(dt.Rows[0]["CNTRY_ID"]);
        StateLoadCommu(objEntCorpOffice);
        //Check if there is a state id selected or not.
        if (dt.Rows[0]["COM_STATE_ID"].ToString() != "")
        {
            int intStateId = Convert.ToInt32(dt.Rows[0]["COM_STATE_ID"]);
            //ie IF  STATE IS ACTIVE
            if (dt.Rows[0]["COM_STATE_STATUS"].ToString() == "1" && dt.Rows[0]["COM_STATE_CNCL_ID"].ToString() == "")
            {
                if (ddlCommuStateCD.Items.FindByText(dt.Rows[0]["COM_STATE_NAME"].ToString()) != null)
                {
                    ddlCommuStateCD.Items.FindByText(dt.Rows[0]["COM_STATE_NAME"].ToString()).Selected = true;
                }
                else { }
            }
            else { }

            objEntCorpOffice.StateId = intStateId;
            //Search if there is a city id selected or not
            CityLoadCommu(objEntCorpOffice);
            if (dt.Rows[0]["COM_CITY_ID"].ToString() != "")
            {

                if (dt.Rows[0]["COM_CITY_STATUS"].ToString() == "1" && dt.Rows[0]["COM_CITY_CNCL_ID"].ToString() == "")
                {
                    if (ddlCommuCityCD.Items.FindByText(dt.Rows[0]["COM_CITY_NAME"].ToString()) != null)
                    {
                        ddlCommuCityCD.Items.FindByText(dt.Rows[0]["COM_CITY_NAME"].ToString()).Selected = true;
                    }
                    else { }
                }
                else { }
            }
        }
    }



    //CONTACT DETAILS
    protected void btnUpdateCD_Click(object sender, EventArgs e)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        // objEntityEmp.EmpID = 1627;
        objEntityEmp.EmpID = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityEmp.Address1 = txtAdr1.Text.ToUpper().Trim();
        objEntityEmp.Address2 = txtAdr2.Text.ToUpper().Trim();
        objEntityEmp.Address3 = txtAdr3.Text.ToUpper().Trim();
        if (ddlCountryCD.SelectedItem.Text != "--Select Country--")
        {
            objEntityEmp.CountryId = Convert.ToInt32(ddlCountryCD.SelectedItem.Value);
        }

        if (HiddenStateValueCD.Value == "" || HiddenStateValueCD.Value == null)
        {
            objEntityEmp.StateId = null;
            objEntityEmp.CityId = null;
        }
        else
        {
            if (HiddenStateValueCD.Value != "0")
            {
                objEntityEmp.StateId = Convert.ToInt32(HiddenStateValueCD.Value);
            }
            else
                objEntityEmp.StateId = null;
            //If there is no city selected
            if (HiddenCityValueCD.Value == "" || HiddenCityValueCD.Value == null)
            {
                objEntityEmp.CityId = null;
            }
            else
            {
                if (HiddenCityValueCD.Value != "0")
                {
                    objEntityEmp.CityId = Convert.ToInt32(HiddenCityValueCD.Value);
                }
                else
                    objEntityEmp.CityId = null;

            }
        }
        if (HiddenCommuStateValueCD.Value == "" || HiddenCommuStateValueCD.Value == null)
        {
            objEntityEmp.Cmu_StateId = null;
            objEntityEmp.Cmu_CityId = null;
        }
        else
        {
            if (HiddenCommuStateValueCD.Value != "0")
            {
                objEntityEmp.Cmu_StateId = Convert.ToInt32(HiddenCommuStateValueCD.Value);
            }
            else
                objEntityEmp.Cmu_StateId = null;
            //If there is no city selected
            if (HiddenCommuCityValueCD.Value == "" || HiddenCommuCityValueCD.Value == null)
            {
                objEntityEmp.Cmu_CityId = null;
            }
            else
            {
                if (HiddenCommuCityValueCD.Value != "0")
                {
                    objEntityEmp.Cmu_CityId = Convert.ToInt32(HiddenCommuCityValueCD.Value);
                }
                else
                    objEntityEmp.Cmu_CityId = null;

            }
        }

        objEntityEmp.ZipCode = txtPostalCode.Text.Trim();
        objEntityEmp.Email_Address = txtEmail.Text.Trim();
        objEntityEmp.Phone_Number = txtPhone.Text.Trim();
        objEntityEmp.Mobile_Number = txtMobile.Text.Trim();
        objEntityEmp.Fax = txtFax.Text.Trim();
        objEntityEmp.Cmu_Address1 = txtCommuAddr1.Text.ToUpper().Trim();
        objEntityEmp.Cmu_Address2 = txtCommuAddr2.Text.ToUpper().Trim();
        objEntityEmp.Cmu_Address3 = txtCommuAddr3.Text.ToUpper().Trim();
        if (ddlCommuCountryCD.SelectedItem.Text != "--Select Country--")
        {
            objEntityEmp.Cmu_CountryId = Convert.ToInt32(ddlCommuCountryCD.SelectedItem.Value);
        }

        objEntityEmp.Cmu_ZipCode = txtCommuPostalCode.Text.Trim();
        objEntityEmp.Cmu_Email_Address = txtCmmuEmail.Text.Trim();
        objEntityEmp.Cmu_Phone_Number = txtCommuPhone.Text.Trim();
        objEntityEmp.Cmu_Mobile_Number = txtCommuMobile.Text.Trim();
        objEntityEmp.Cmu_Fax = txtCommuFax.Text.Trim();
        objEntityEmp.Emrg_Name = txtEmrgName.Text.ToUpper().Trim();
        objEntityEmp.Emrg_Address = txtEmrgAddr.Value.ToUpper().Trim();
        if (ddlEmrgRelat.SelectedItem.Text != "--Select Relation--")
        {
            objEntityEmp.Emrg_Relation = ddlEmrgRelat.SelectedItem.Text;
        }
        objEntityEmp.Emrg_Email = txtEmrgEmail.Text.Trim();
        objEntityEmp.Emrg_Phone = txtEmrgPhone.Text.Trim();
        objEntityEmp.Emrg_Moble = txtEmrgMobile.Text.Trim();
        objEntityEmp.Emrg_Fax = txtEmrgFax.Text.Trim();
        objEntityEmp.Upd_Userid = Convert.ToInt32(Session["USERID"].ToString());
        objEntityEmp.Upd_Date = System.DateTime.Now;
        //Start:- EVM-0024

        DataTable dtReadContctDtls = objBusinessEmp.ReadCountry(objEntityEmp);

        if (dtReadContctDtls.Rows.Count > 0)
        {

            if (ddlIssuedby.Items.FindByValue(dtReadContctDtls.Rows[0]["CNTRY_ID"].ToString()) != null)
            {
                ddlIssuedby.ClearSelection();
                ddlIssuedby.Items.FindByValue(dtReadContctDtls.Rows[0]["CNTRY_ID"].ToString()).Selected = true;

            }
        }
        else
        {
            ddlIssuedby.Items.Insert(0, "--Select Country--");
            ddlIssuedby.SelectedIndex = 0;
        }
        //End

        objBusinessEmp.Update_Contact_Details(objEntityEmp);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationCD", "SuccessUpdationCD();", true);
        update_Contact_dtls(HiddenEmployeeMasterId.Value);
    }
    //CONTACT DETAILS
    protected void btnAddCD_Click(object sender, EventArgs e)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEmp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntityEmp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmp.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityEmp.EmpID = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityEmp.Address1 = txtAdr1.Text.ToUpper().Trim();
        objEntityEmp.Address2 = txtAdr2.Text.ToUpper().Trim();
        objEntityEmp.Address3 = txtAdr3.Text.ToUpper().Trim();
        if (ddlCountryCD.SelectedItem.Text != "--Select Country--")
        {
            objEntityEmp.CountryId = Convert.ToInt32(ddlCountryCD.SelectedItem.Value);
        }

        if (HiddenStateValueCD.Value == "" || HiddenStateValueCD.Value == null)
        {
            objEntityEmp.StateId = null;
            objEntityEmp.CityId = null;
        }
        else
        {
            if (HiddenStateValueCD.Value != "0")
            {
                objEntityEmp.StateId = Convert.ToInt32(HiddenStateValueCD.Value);
            }
            else
                objEntityEmp.StateId = null;
            //If there is no city selected
            if (HiddenCityValueCD.Value == "" || HiddenCityValueCD.Value == null)
            {
                objEntityEmp.CityId = null;
            }
            else
            {
                if (HiddenCityValueCD.Value != "0")
                {
                    objEntityEmp.CityId = Convert.ToInt32(HiddenCityValueCD.Value);
                }
                else
                    objEntityEmp.CityId = null;

            }
        }
        if (HiddenCommuStateValueCD.Value == "" || HiddenCommuStateValueCD.Value == null)
        {
            objEntityEmp.Cmu_StateId = null;
            objEntityEmp.Cmu_CityId = null;
        }
        else
        {
            if (HiddenCommuStateValueCD.Value != "0")
            {
                objEntityEmp.Cmu_StateId = Convert.ToInt32(HiddenCommuStateValueCD.Value);
            }
            else
                objEntityEmp.Cmu_StateId = null;
            //If there is no city selected
            if (HiddenCommuCityValueCD.Value == "" || HiddenCommuCityValueCD.Value == null)
            {
                objEntityEmp.Cmu_CityId = null;
            }
            else
            {
                if (HiddenCommuCityValueCD.Value != "0")
                {
                    objEntityEmp.Cmu_CityId = Convert.ToInt32(HiddenCommuCityValueCD.Value);
                }
                else
                    objEntityEmp.Cmu_CityId = null;

            }
        }

        objEntityEmp.ZipCode = txtPostalCode.Text.Trim();
        objEntityEmp.Email_Address = txtEmail.Text.Trim();
        objEntityEmp.Phone_Number = txtPhone.Text.Trim();
        objEntityEmp.Mobile_Number = txtMobile.Text.Trim();
        objEntityEmp.Fax = txtFax.Text.Trim();
        objEntityEmp.Cmu_Address1 = txtCommuAddr1.Text.ToUpper().Trim();
        objEntityEmp.Cmu_Address2 = txtCommuAddr2.Text.ToUpper().Trim();
        objEntityEmp.Cmu_Address3 = txtCommuAddr3.Text.ToUpper().Trim();
        if (ddlCommuCountryCD.SelectedItem.Text != "--Select Country--")
        {
            objEntityEmp.Cmu_CountryId = Convert.ToInt32(ddlCommuCountryCD.SelectedItem.Value);
        }

        objEntityEmp.Cmu_ZipCode = txtCommuPostalCode.Text.Trim();
        objEntityEmp.Cmu_Email_Address = txtCmmuEmail.Text.Trim();
        objEntityEmp.Cmu_Phone_Number = txtCommuPhone.Text.Trim();
        objEntityEmp.Cmu_Mobile_Number = txtCommuMobile.Text.Trim();
        objEntityEmp.Cmu_Fax = txtCommuFax.Text.Trim();
        objEntityEmp.Emrg_Name = txtEmrgName.Text.ToUpper().Trim();
        objEntityEmp.Emrg_Address = txtEmrgAddr.Value.ToUpper().Trim();
        if (ddlEmrgRelat.SelectedItem.Text != "--Select Relation--")
        {
            objEntityEmp.Emrg_Relation = ddlEmrgRelat.SelectedItem.Text;
        }
        objEntityEmp.Emrg_Email = txtEmrgEmail.Text.Trim();
        objEntityEmp.Emrg_Phone = txtEmrgPhone.Text.Trim();
        objEntityEmp.Emrg_Moble = txtEmrgMobile.Text.Trim();
        objEntityEmp.Emrg_Fax = txtEmrgFax.Text.Trim();
        objEntityEmp.Ins_Userid = Convert.ToInt32(Session["USERID"].ToString());
        objEntityEmp.Ins_date = System.DateTime.Now;
        //Start:- EVM-0024

        DataTable dtReadContctDtls = objBusinessEmp.ReadCountry(objEntityEmp);

        if (dtReadContctDtls.Rows.Count > 0)
        {

            if (ddlIssuedby.Items.FindByValue(dtReadContctDtls.Rows[0]["CNTRY_ID"].ToString()) != null)
            {
                ddlIssuedby.ClearSelection();
                ddlIssuedby.Items.FindByValue(dtReadContctDtls.Rows[0]["CNTRY_ID"].ToString()).Selected = true;

            }
        }
        else
        {
            ddlIssuedby.Items.Insert(0, "--Select Country--");
            ddlIssuedby.SelectedIndex = 0;
        }
        //End
        //objBusinessPersonalDtls.insertPersonalDtls(objEntityPersonalDtls);
        objBusinessEmp.add_Contact_Details(objEntityEmp);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationCD", "SuccessConfirmationCD();", true);
        btnAddCD.Visible = false;
        btnUpdateCD.Visible = true;
    }
    //start:Qualification


    //start:Qualification-Work Experience
    protected void btnAddWrkExp_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerWorkExperience();
        ClsEntityLayerWorkExperience objEntityWorkExperience = new ClsEntityLayerWorkExperience();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWorkExperience.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        objEntityWorkExperience.Date = System.DateTime.Now;
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityWorkExperience.EmpUser_id = Convert.ToInt32(strId);
        }
        objEntityWorkExperience.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityWorkExperience.CompanyName = txtWrkCompny.Text.Trim().ToUpper();
        objEntityWorkExperience.JobTitle = txtWrkJobTle.Text.Trim().ToUpper();

        if (txtWrkFromDate.Text != "")
        {
            objEntityWorkExperience.FromDate = objCommon.textToDateTime(txtWrkFromDate.Text);
        }
        if (txtWrkToDate.Text != "")
        {
            objEntityWorkExperience.ToDate = objCommon.textToDateTime(txtWrkToDate.Text);
        }
        int ExpYears = 0;
        if (txtWrkFromDate.Text != "" && txtWrkToDate.Text != "")
        {
            int FromYear = Convert.ToInt32(objEntityWorkExperience.FromDate.ToString("yyyy"));
            int ToYear = Convert.ToInt32(objEntityWorkExperience.ToDate.ToString("yyyy"));
            ExpYears = ToYear - FromYear;
            clsEntity_Leave_Type objEnityLeave_Type=new clsEntity_Leave_Type();
            clsBusiness_Leave_Type objBusiness_Leave_Type = new clsBusiness_Leave_Type();

           DataTable dtExperience= objBusiness_Leave_Type.ReadExperienceByID(objEnityLeave_Type);
           if (dtExperience.Rows.Count > 0)
           {
               for (int intRowCount = 0; intRowCount < dtExperience.Rows.Count; intRowCount++)
               {
                   int intMinYear=Convert.ToInt32(dtExperience.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
                   int intMaxYear=Convert.ToInt32(dtExperience.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
                   if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
                   {
                       objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(dtExperience.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
                   }
               }
           }


            //if (ExpYears >= 0 && ExpYears <= 2)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 1;
            //}
            //else if (ExpYears >= 2 && ExpYears <= 4)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 2;
            //}
            //else if (ExpYears >= 4 && ExpYears <= 6)
            //{

            //    objEntityWorkExperience.WorkExpDtl_id = 3;
            //}
            //else if (ExpYears >= 6 && ExpYears <= 8)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 4;
            //}
            //else if (ExpYears >= 8 && ExpYears <= 10)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 5;

            //}
            //else if (ExpYears >= 10 && ExpYears <= 15)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 6;

            //}
            //else if (ExpYears >= 15 && ExpYears <= 20)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 7;
            //}
            //else if (ExpYears >= 20 && ExpYears <= 25)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 8;
            //}
            //else if (ExpYears <25)
            //{
            //    objEntityWorkExperience.WorkExpDtl_id = 9;
            //}
        }
        objEntityWorkExperience.Comment = txtWrkCmnt.Text;
        if (cbxRefCheck.Checked)
        {
            objEntityWorkExperience.Refcheck_id = 1;
        }
        else
        {
            objEntityWorkExperience.Refcheck_id = 0;
        }
        objEntityWorkExperience.RefName = txtWrkRefName.Text.Trim();
        objEntityWorkExperience.RefDesgntn = txtWrkRefDesg.Text.Trim();
        if (FileUploadWrk.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            strFileExt = FileUploadWrk.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
            string strFileName = FileUploadWrk.FileName;
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
            string strImageName = "WorkExp_" + intImageSection.ToString() + "_" + objEntityWorkExperience.CompanyName + strFileName + "." + strFileExt;
            objEntityWorkExperience.Fname = strImageName;
            objEntityWorkExperience.ActFname = strFileName;

        }
        objBusinessLayerWorkExperience.insertWorkExp(objEntityWorkExperience);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
        if (FileUploadWrk.HasFile)
        {
            FileUploadWrk.SaveAs(Server.MapPath(strImagePath) + objEntityWorkExperience.Fname);
        }
        objEntityWorkExperience.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
        string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
        divListWrkExp.InnerHtml = strHtmList;


        string strRandom = objCommon.Random_Number();
        string strId1 = HiddenEmployeeMasterId.Value;
        int intIdLength = HiddenEmployeeMasterId.Value.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId1 + strRandom;



        Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveWorkExp");

       // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationWrkExp", "SuccessConfirmationWrkExp();", true);


    }
    protected void btnUpdateWrkExp_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerWorkExperience();
        ClsEntityLayerWorkExperience objEntityWorkExperience = new ClsEntityLayerWorkExperience();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityWorkExperience.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        objEntityWorkExperience.Date = System.DateTime.Now;
        objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(HiddenWorkExpDtlId.Value);
        objEntityWorkExperience.CompanyName = txtWrkCompny.Text.Trim().ToUpper();
        objEntityWorkExperience.JobTitle = txtWrkJobTle.Text.Trim().ToUpper();
        if (txtWrkFromDate.Text != "")
        {
            objEntityWorkExperience.FromDate = objCommon.textToDateTime(txtWrkFromDate.Text);
        }
        if (txtWrkToDate.Text != "")
        {
            objEntityWorkExperience.ToDate = objCommon.textToDateTime(txtWrkToDate.Text);
        }
        objEntityWorkExperience.Comment = txtWrkCmnt.Text;
        if (cbxRefCheck.Checked)
        {
            objEntityWorkExperience.Refcheck_id = 1;
        }
        else
        {
            objEntityWorkExperience.Refcheck_id = 0;
        }
        objEntityWorkExperience.RefName = txtWrkRefName.Text.Trim();
        objEntityWorkExperience.RefDesgntn = txtWrkRefDesg.Text.Trim();
        if (FileUploadWrk.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            strFileExt = FileUploadWrk.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
            string strFileName = FileUploadWrk.FileName;
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
            string strImageName = "WorkExp_" + intImageSection.ToString() + "_" + objEntityWorkExperience.CompanyName + strFileName + "." + strFileExt;
            objEntityWorkExperience.Fname = strImageName;
            objEntityWorkExperience.ActFname = strFileName;

        }
        objBusinessLayerWorkExperience.updateWorkExp(objEntityWorkExperience);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
        if (FileUploadWrk.HasFile)
        {
            FileUploadWrk.SaveAs(Server.MapPath(strImagePath) + objEntityWorkExperience.Fname);
        }
        objEntityWorkExperience.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtlist = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
        string strHtmList = ConvertDataTableToHTMLwrkExp(dtlist);
        divListWrkExp.InnerHtml = strHtmList;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationWrkExp", "SuccessUpdationWrkExp();", true);


    }
    //It build the Html table by using the datatable provided
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
                strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">COMPANY</th>";//EMP17 ..CAPITALISED
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">JOB TITLE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE</th>";
            }

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

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 0.5%;margin-top: -1.5%;\" class=\"tooltip\" title=\"Edit\" onclick=\"return updateWrkExpById('" + strId + "');\" >" +
                           "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1.5%;\" class=\"tooltip\" title=\"Delete\" onclick=\"return deleteWrkExpById('" + strId + "');\" >" +
                                "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
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
        public string Company = "";
        public string JobTitle = "";
        public string FromDate = "";
        public string ToDate = "";
        public string Fname = "";
        public string ActFname = "";
        public string Comment = "";
        public string RefName = "";
        public string RefDesg = "";
        public int RefCheckId = 0;
        public string strWrkExpList = "";
        public string strImg = "";
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

                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">Company</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:30%;text-align: left; word-wrap:break-word;\">Job Title</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">From Date</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">To Date</th>";
                }

            }


            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">Edit</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">Delete</th>";

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

                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();

                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return updateWrkExpById('" + strId + "');\" >" +
                               "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return deleteWrkExpById('" + strId + "');\" >" +
                                    "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    [WebMethod]
    public static WorkExperience ReadWrkExpDtlById(string Id)
    {
        WorkExperience objWorkExp = new WorkExperience();

        ClsBusinessLayerWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerWorkExperience();
        ClsEntityLayerWorkExperience objEntityWorkExperience = new ClsEntityLayerWorkExperience();
        objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(Id);
        DataTable dt = objBusinessLayerWorkExperience.ReadWrkExpDtlById(objEntityWorkExperience);
        if (dt.Rows.Count > 0)
        {
            objWorkExp.Company = dt.Rows[0]["EMWRKEX_CMPNY"].ToString();
            objWorkExp.JobTitle = dt.Rows[0]["EMWRKEX_JOB_TITLE"].ToString();
            objWorkExp.FromDate = dt.Rows[0]["FROM"].ToString();
            objWorkExp.ToDate = dt.Rows[0]["TO"].ToString();
            objWorkExp.Comment = dt.Rows[0]["EMWRKEX_CMNT"].ToString();
            objWorkExp.Fname = dt.Rows[0]["EMWRKEX_FILENAME"].ToString();
            objWorkExp.ActFname = dt.Rows[0]["EMWRKEX_FLNM_ACT"].ToString();
            objWorkExp.RefCheckId = Convert.ToInt32(dt.Rows[0]["EMWRKEX_REF_CHK_STS"].ToString());
            objWorkExp.RefName = dt.Rows[0]["EMWRKEX_REF_EMP_NAME"].ToString();
            objWorkExp.RefDesg = dt.Rows[0]["EMWRKEX_REF_EMP_DSG"].ToString();
            objWorkExp.strImg = objWorkExp.ImageLoad(objWorkExp.Fname, objWorkExp.ActFname);
        }
        return objWorkExp;
    }
    [WebMethod]
    public static WorkExperience deleteWrkExpById(string Id, string empId)
    {
        WorkExperience objWrkExp = new WorkExperience();
        ClsBusinessLayerWorkExperience objBusinessLayerWorkExperience = new ClsBusinessLayerWorkExperience();
        ClsEntityLayerWorkExperience objEntityWorkExperience = new ClsEntityLayerWorkExperience();
        objEntityWorkExperience.WorkExpDtl_id = Convert.ToInt32(Id);
        objBusinessLayerWorkExperience.DeleteWrkExpDtl(objEntityWorkExperience);

        objEntityWorkExperience.EmpUser_id = Convert.ToInt32(empId);
        DataTable dt = objBusinessLayerWorkExperience.readWrkExpList(objEntityWorkExperience);
        objWrkExp.strWrkExpList = objWrkExp.ConvertDataTableToHTMLwrkExp(dt);
        return objWrkExp;
    }
    //stop:Qualification-Work Experience


    //start:Qualification-Education
    public void EduLvlLoad()
    {
        ClsBusinessLayerEducation objBusinessEducation = new ClsBusinessLayerEducation();
        DataTable dt = objBusinessEducation.ReadEduLvl();
        ddlEduLvl.DataSource = dt;
        ddlEduLvl.DataTextField = "EDUCTNLVL_NAME";
        ddlEduLvl.DataValueField = "EDUCTNLVL_ID";
        ddlEduLvl.DataBind();
        ddlEduLvl.Items.Insert(0, "--Select Level--");
    }

    protected void btnAddEdu_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerEducation objBusinessEducation = new ClsBusinessLayerEducation();
        ClsEntityLayerEducation objEntityEducation = new ClsEntityLayerEducation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEducation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
            objEntityEducation.EmpUser_id = Convert.ToInt32(strId);
        }
        objEntityEducation.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objEntityEducation.EduLevelId = Convert.ToInt32(ddlEduLvl.SelectedItem.Value);
        objEntityEducation.Institute = txtEduInstite.Text.Trim();
        objEntityEducation.MajorSpec = txtEduMjr.Text.Trim();
        if (txtEduYear.Text.Trim() != "")
        {
            objEntityEducation.Year = Convert.ToInt32(txtEduYear.Text.Trim());
        }
        if (txtEduGPA.Text.Trim() != "")
        {
            objEntityEducation.GPAscore = Convert.ToDecimal(txtEduGPA.Text.Trim());
        }
        if (txtEduStrtDate.Text != "")
        {
            objEntityEducation.StartDate = objCommon.textToDateTime(txtEduStrtDate.Text);
        }
        if (txtEduEndDate.Text != "")
        {
            objEntityEducation.EndDate = objCommon.textToDateTime(txtEduEndDate.Text);
        }

        if (FileUploadEdu.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            strFileExt = FileUploadEdu.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
            string strFileName = FileUploadEdu.FileName;
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
            string strImageName = "Education_" + intImageSection.ToString() + "_" + objEntityEducation.EduLevelId + strFileName + "." + strFileExt;
            objEntityEducation.Fname = strImageName;
            objEntityEducation.ActFname = strFileName;

        }
        objBusinessEducation.insertEducation(objEntityEducation);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
        if (FileUploadEdu.HasFile)
        {
            FileUploadEdu.SaveAs(Server.MapPath(strImagePath) + objEntityEducation.Fname);
        }
        objEntityEducation.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtEdulist = objBusinessEducation.readEduList(objEntityEducation);
        string strHtmListEdu = ConvertDataTableToHTMLeductn(dtEdulist);
        divListEdu.InnerHtml = strHtmListEdu;

        string strRandom = objCommon.Random_Number();
        string strId1 = HiddenEmployeeMasterId.Value;
        int intIdLength = HiddenEmployeeMasterId.Value.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId1 + strRandom;



        Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveEducation");

       // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationEdu", "SuccessConfirmationEdu();", true);


    }
    protected void btnUpdateEdu_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerEducation objBusinessEducation = new ClsBusinessLayerEducation();
        ClsEntityLayerEducation objEntityEducation = new ClsEntityLayerEducation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityEducation.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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


        objEntityEducation.EductnDtl_Id = Convert.ToInt32(HiddenEductnDtlId.Value);
        objEntityEducation.EduLevelId = Convert.ToInt32(ddlEduLvl.SelectedItem.Value);
        objEntityEducation.Institute = txtEduInstite.Text.Trim();
        objEntityEducation.MajorSpec = txtEduMjr.Text.Trim();
        if (txtEduYear.Text.Trim() != "")
        {
            objEntityEducation.Year = Convert.ToInt32(txtEduYear.Text.Trim());
        }
        if (txtEduGPA.Text.Trim() != "")
        {
            objEntityEducation.GPAscore = Convert.ToDecimal(txtEduGPA.Text.Trim());
        }

        if (txtEduStrtDate.Text != "")
        {
            objEntityEducation.StartDate = objCommon.textToDateTime(txtEduStrtDate.Text);
        }
        if (txtEduEndDate.Text != "")
        {
            objEntityEducation.EndDate = objCommon.textToDateTime(txtEduEndDate.Text);
        }
        if (hiddenUserImage.Value != "")           //15emp17
        {
            objEntityEducation.Fname = hiddenUserImage.Value;
        }

        else
        {
            if (FileUploadEdu.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                strFileExt = FileUploadEdu.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
                string strFileName = FileUploadEdu.FileName;
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
                string strImageName = "Education_" + intImageSection.ToString() + "_" + objEntityEducation.EduLevelId + strFileName + "." + strFileExt;
                objEntityEducation.Fname = strImageName;
                objEntityEducation.ActFname = strFileName;

            }
        }
        objBusinessEducation.updateEducation(objEntityEducation);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
        if (FileUploadEdu.HasFile)
        {
            FileUploadEdu.SaveAs(Server.MapPath(strImagePath) + objEntityEducation.Fname);
        }
        objEntityEducation.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
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

            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">LEVEL</th>"; //15EMP17
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">INSTITUTE</th>";
            }
            if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">GPA/SCORE</th>";
            }
            if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FROM DATE</th>";
            }
            if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">TO DATE</th>";
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
                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
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
            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();

            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Edit\" onclick=\"return updateEduDtlById('" + strId + "');\" >" +
                            "<img  style=\"margin-left: -63%;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Delete\" onclick=\"return deleteEduDtlById('" + strId + "');\" >" +
                                "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";

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
        public int LvlId = 0;
        public int LvlSts = 0;
        public string LvlName = "";
        public string Institute = "";
        public string MjrSpec = "";
        public string year = "";
        public string Score = "";
        public string StartDate = "";
        public string EndDate = "";
        public string Fname = "";
        public string ActFname = "";
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
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">Level</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">Institute</th>";
                }
                if (intColumnHeaderCount == 3)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: right; word-wrap:break-word;\">GPA/Score</th>";
                }
                if (intColumnHeaderCount == 4)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">From Date</th>";
                }
                if (intColumnHeaderCount == 5)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">To Date</th>";
                }

            }


            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">Edit</th>";
            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">Delete</th>";

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
                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
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
                }


                string strId = dt.Rows[intRowBodyCount][0].ToString();

                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return updateEduDtlById('" + strId + "');\" >" +
                               "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return deleteEduDtlById('" + strId + "');\" >" +
                                    "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";

                strHtml += "</tr>";

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }
    }
    [WebMethod]
    public static Education ReadEduDtlById(string Id)
    {
        Education objEdu = new Education();
        ClsBusinessLayerEducation objBusinessEducation = new ClsBusinessLayerEducation();
        ClsEntityLayerEducation objEntityEducation = new ClsEntityLayerEducation();
        objEntityEducation.EductnDtl_Id = Convert.ToInt32(Id);
        DataTable dt = objBusinessEducation.ReadEduDtlById(objEntityEducation);
        if (dt.Rows.Count > 0)
        {
            objEdu.LvlId = Convert.ToInt32(dt.Rows[0]["EDUCTNLVL_ID"].ToString());
            objEdu.LvlSts = Convert.ToInt32(dt.Rows[0]["EDUCTNLVL_STATUS"].ToString());
            objEdu.LvlName = dt.Rows[0]["EDUCTNLVL_NAME"].ToString();
            objEdu.Institute = dt.Rows[0]["EMEDUDTL_INSTITUTE"].ToString();
            objEdu.MjrSpec = dt.Rows[0]["EMEDUDTL_MAJOR"].ToString();
            objEdu.year = dt.Rows[0]["EMEDUDTL_YEAR"].ToString();
            objEdu.Score = dt.Rows[0]["EMEDUDTL_GPASCORE"].ToString();
            objEdu.StartDate = dt.Rows[0]["START DATE"].ToString();
            objEdu.EndDate = dt.Rows[0]["END DATE"].ToString();
            objEdu.Fname = dt.Rows[0]["EMEDUDTL_FILENAME"].ToString();
            objEdu.ActFname = dt.Rows[0]["EMEDUDTL_FLNM_ACT"].ToString();
            objEdu.strImg = objEdu.ImageLoad(objEdu.Fname, objEdu.ActFname);
        }
        return objEdu;
    }
    [WebMethod]
    public static Education deleteEduById(string Id, string empId)
    {
        Education objEdu = new Education();
        ClsBusinessLayerEducation objBusinessEducation = new ClsBusinessLayerEducation();
        ClsEntityLayerEducation objEntityEducation = new ClsEntityLayerEducation();
        objEntityEducation.EductnDtl_Id = Convert.ToInt32(Id);
        objBusinessEducation.deleteEduById(objEntityEducation);

        objEntityEducation.EmpUser_id = Convert.ToInt32(empId);
        DataTable dt = objBusinessEducation.readEduList(objEntityEducation);
        objEdu.strEduList = objEdu.ConvertDataTableToHTMLeductn(dt);
        return objEdu;
    }

    public void SkillLoad()
    {
        ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
        DataTable dt = objBusinessSkillCertfcn.ReadSkillDropdown();
        ddlSCSkill.DataSource = dt;
        ddlSCSkill.DataTextField = "SKILLMSTR_NAME";
        ddlSCSkill.DataValueField = "SKILLMSTR_ID";
        ddlSCSkill.DataBind();
        ddlSCSkill.Items.Insert(0, "--Select Skill--");
    }


    protected void btnAddSkCer_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
        ClsEntityLayerSkillCertifcn objEntitySkillCertfcn = new ClsEntityLayerSkillCertifcn();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntitySkillCertfcn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntitySkillCertfcn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntitySkillCertfcn.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntitySkillCertfcn.Date = System.DateTime.Now;
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(strId);
        }
        else
            objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);

        if (radioSkill.Checked == true)
        {
            objEntitySkillCertfcn.SkillId = Convert.ToInt32(ddlSCSkill.SelectedItem.Value);
            objEntitySkillCertfcn.Certfcn = null;
            objEntitySkillCertfcn.cbxSklCerId = 0;
        }
        else
        {

            objEntitySkillCertfcn.Certfcn = txtSCCertfcn.Text.Trim();
            objEntitySkillCertfcn.cbxSklCerId = 1;
        }

        if (txtSCYearExp.Text.Trim() != "")
        {
            objEntitySkillCertfcn.year = Convert.ToInt32(txtSCYearExp.Text.Trim());
        }
        objEntitySkillCertfcn.Comment = txtSCcmnt.Text.Trim();

        if (FileUploadSkCer.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            strFileExt = FileUploadSkCer.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
            string strFileName = FileUploadSkCer.FileName;
            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
            string strImageName = "SkillCer_" + intImageSection.ToString() + "_" + objEntitySkillCertfcn.SkillId + objEntitySkillCertfcn.Certfcn + strFileName + "." + strFileExt;
            objEntitySkillCertfcn.Fname = strImageName;
            objEntitySkillCertfcn.ActFname = strFileName;

        }
        objBusinessSkillCertfcn.insertSkillCertfcn(objEntitySkillCertfcn);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
        if (FileUploadSkCer.HasFile)
        {
            FileUploadSkCer.SaveAs(Server.MapPath(strImagePath) + objEntitySkillCertfcn.Fname);
        }

        objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtSkCerlist = objBusinessSkillCertfcn.readSklCerList(objEntitySkillCertfcn);
        string strHtmListSklCer = ConvertDataTableToHTMLsklCer(dtSkCerlist);
        divSkCerList.InnerHtml = strHtmListSklCer;


        string strRandom = objCommon.Random_Number();
        string strId1 = HiddenEmployeeMasterId.Value;
        int intIdLength = HiddenEmployeeMasterId.Value.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId1 + strRandom;

        Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveSkill_Cirtfctn");

        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationSkCer", "SuccessConfirmationSkCer();", true);
    }


    protected void btnUpdateSkCer_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
        ClsEntityLayerSkillCertifcn objEntitySkillCertfcn = new ClsEntityLayerSkillCertifcn();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntitySkillCertfcn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }

        if (Session["ORGID"] != null)
        {
            objEntitySkillCertfcn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntitySkillCertfcn.User_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntitySkillCertfcn.Date = System.DateTime.Now;
        objEntitySkillCertfcn.SklCerfnDtlId = Convert.ToInt32(HiddenFieldSkCerDtlId.Value);
        if (radioSkill.Checked == true)
        {
            objEntitySkillCertfcn.SkillId = Convert.ToInt32(ddlSCSkill.SelectedItem.Value);
            objEntitySkillCertfcn.Certfcn = null;
            objEntitySkillCertfcn.cbxSklCerId = 0;
        }
        else
        {

            objEntitySkillCertfcn.Certfcn = txtSCCertfcn.Text.Trim();
            objEntitySkillCertfcn.cbxSklCerId = 1;
        }

        if (txtSCYearExp.Text.Trim() != "")
        {
            objEntitySkillCertfcn.year = Convert.ToInt32(txtSCYearExp.Text.Trim());
        }
        objEntitySkillCertfcn.Comment = txtSCcmnt.Text.Trim();
        if (hiddenUserImage.Value != "")//12emp17
        {
            objEntitySkillCertfcn.Fname = hiddenUserImage.Value;

        }
        else
        {

            if (FileUploadSkCer.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                strFileExt = FileUploadSkCer.FileName.Substring(FileUploadWrk.FileName.LastIndexOf('.') + 1).ToLower();
                string strFileName = FileUploadSkCer.FileName;
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
                string strImageName = "SkillCer_" + intImageSection.ToString() + "_" + objEntitySkillCertfcn.SkillId + objEntitySkillCertfcn.Certfcn + strFileName + "." + strFileExt;
                objEntitySkillCertfcn.Fname = strImageName;
                objEntitySkillCertfcn.ActFname = strFileName;

            }
        }
        objBusinessSkillCertfcn.updateSkillCertfcn(objEntitySkillCertfcn);
        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION);
        if (FileUploadSkCer.HasFile)
        {
            FileUploadSkCer.SaveAs(Server.MapPath(strImagePath) + objEntitySkillCertfcn.Fname);
        }
        objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        DataTable dtSkCerlist = objBusinessSkillCertfcn.readSklCerList(objEntitySkillCertfcn);
        string strHtmListSklCer = ConvertDataTableToHTMLsklCer(dtSkCerlist);
        divSkCerList.InnerHtml = strHtmListSklCer;
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationSkCer", "SuccessUpdationSkCer();", true);
    }


    //It build the Html table by using the datatable provided
    public string ConvertDataTableToHTMLsklCer(DataTable dt)
    {

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();

        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTableSkCer\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {

            if (intColumnHeaderCount == 1)
            {
                if (radioSkill.Checked == true)
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">SKILL</th>"; //12EMP17
                }
                else
                {
                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CERTIFICATION</th>";
                }
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">YEARS OF EXPERIENCE</th>";
            }


        }


        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">EDIT</th>";
        strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">DELETE</th>"; //12EMP17

        strHtml += "</tr>";
        strHtml += "</thead>";
        //add rows

        strHtml += "<tbody>";
        for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
        {


            if (radioSkill.Checked == true)
            {
                if (dt.Rows[intRowBodyCount][1].ToString() == "0")
                {
                    strHtml += "<tr  >";
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (intColumnBodyCount == 1)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";

                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                        }

                    }
                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    //12EMP17
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Edit\" onclick=\"return updateSklCerDtlById('" + strId + "');\" >" +
                                   "<img  style=\"cursor: pointer;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Delete\"  onclick=\"return deleteSklCerDtlById('" + strId + "');\" >" +
                                        "<img style=\"cursor: pointer;\"  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    //12EMP17
                    strHtml += "</tr>";

                }
            }

            else
            {
                if (dt.Rows[intRowBodyCount][1].ToString() == "1")
                {
                    strHtml += "<tr  >";
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {

                        if (intColumnBodyCount == 1)
                        {

                            strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";

                        }
                        if (intColumnBodyCount == 2)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                        }

                    }
                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    //12EMP17
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Edit\" onclick=\"return updateSklCerDtlById('" + strId + "');\" >" +
                                   "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1%;z-index: 99;\" class=\"tooltip\"  title=\"Delete\"  onclick=\"return deleteSklCerDtlById('" + strId + "');\" >" +
                                        "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    //12EMP17

                    strHtml += "</tr>";
                }
            }

        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }
    public class SkilCertfcn
    {
        public int SkillId = 0;
        public int SkillSts = 0;
        public string SkillName = "";
        public string Certfcn = "";
        public int YearExp = 0;
        public string comment = "";
        public string Fname = "";
        public string ActFname = "";
        public string SklCerList = "";
        public string strImg = "";
        public string ImageLoad(string Fname, string ActFname)
        {
            //for displaying photo
            string strImage = "";
            if (Fname != "")
            {
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.QUALIFICATION) + Fname;
                strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofySkCer\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofySkCer\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";

            }
            return strImage;
        }
        public string ConvertDataTableToHTMLsklCer(DataTable dt, int mode)
        {

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTableSkCer\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";

            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {

                if (intColumnHeaderCount == 1)
                {
                    if (mode == 0)
                    {
                        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">SKILL</th>";
                    }
                    else
                    {
                        strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">CERTIFICATION</th>";
                    }
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:40%;text-align: left; word-wrap:break-word;\">YEARS OF EXPERIENCE</th>";
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


                if ((mode == 0))
                {
                    if (dt.Rows[intRowBodyCount][1].ToString() == "0")
                    {
                        strHtml += "<tr  >";
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {

                            if (intColumnBodyCount == 1)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][2].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                            }

                        }
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return updateSklCerDtlById('" + strId + "');\" >" +
                                       "<img  style=\"cursor: pointer;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;cursor: pointer;\">" + "<a onclick=\"return deleteSklCerDtlById('" + strId + "');\" >" +
                                            "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                        strHtml += "</tr>";

                    }
                }

                else
                {
                    if (dt.Rows[intRowBodyCount][1].ToString() == "1")
                    {
                        strHtml += "<tr  >";
                        for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                        {

                            if (intColumnBodyCount == 1)
                            {

                                strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][3].ToString() + "</td>";

                            }
                            if (intColumnBodyCount == 2)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:40%;word-break: break-all; word-wrap:break-word;text-align:left;\"  >" + dt.Rows[intRowBodyCount][4].ToString() + "</td>";
                            }

                        }
                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return updateSklCerDtlById('" + strId + "');\" >" +
                                       "<img  style=\"cursor: pointer;\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a onclick=\"return deleteSklCerDtlById('" + strId + "');\" >" +
                                            "<img style=\"cursor: pointer;\" src='../../Images/Icons/delete.png' /> " + "</a> </td>";

                        strHtml += "</tr>";
                    }
                }

            }

            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();
        }
    }

    [WebMethod]
    public static SkilCertfcn ReadSklCerDtlById(string Id)
    {
        SkilCertfcn objSklCer = new SkilCertfcn();
        ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
        ClsEntityLayerSkillCertifcn objEntitySkillCertfcn = new ClsEntityLayerSkillCertifcn();
        objEntitySkillCertfcn.SklCerfnDtlId = Convert.ToInt32(Id);
        DataTable dt = objBusinessSkillCertfcn.ReadSklCerDtlById(objEntitySkillCertfcn);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["SKILLMSTR_ID"] != DBNull.Value && dt.Rows[0]["SKILLMSTR_ID"] != "") //12emp17
            {
                objSklCer.SkillId = Convert.ToInt32(dt.Rows[0]["SKILLMSTR_ID"].ToString());
            }
            if (dt.Rows[0]["SKILLMSTR_STATUS"] != DBNull.Value && dt.Rows[0]["SKILLMSTR_STATUS"] != "") //12emp17
            {
                objSklCer.SkillSts = Convert.ToInt32(dt.Rows[0]["SKILLMSTR_STATUS"].ToString());
            } if (dt.Rows[0]["SKILLMSTR_NAME"] != DBNull.Value && dt.Rows[0]["SKILLMSTR_NAME"] != "") //12emp17
            {
                objSklCer.SkillName = dt.Rows[0]["SKILLMSTR_NAME"].ToString();
            } if (dt.Rows[0]["EMSKLCER_CERTFN"] != DBNull.Value && dt.Rows[0]["EMSKLCER_CERTFN"] != "") //12emp17
            {
                objSklCer.Certfcn = dt.Rows[0]["EMSKLCER_CERTFN"].ToString();
            }
            if (dt.Rows[0]["EMSKLCER_CMNT"] != DBNull.Value && dt.Rows[0]["EMSKLCER_CMNT"] != "") //12emp17
            {
                objSklCer.comment = dt.Rows[0]["EMSKLCER_CMNT"].ToString();
            }
            if (dt.Rows[0]["EMSKLCER_YEAR_EXP"] != DBNull.Value && dt.Rows[0]["EMSKLCER_YEAR_EXP"] != "") //12emp17
            { objSklCer.YearExp = Convert.ToInt32(dt.Rows[0]["EMSKLCER_YEAR_EXP"].ToString()); }
            if (dt.Rows[0]["EMSKLCER_FILENAME"] != DBNull.Value && dt.Rows[0]["EMSKLCER_FILENAME"] != "") //12emp17
            {
                objSklCer.Fname = dt.Rows[0]["EMSKLCER_FILENAME"].ToString();
            }
            if (dt.Rows[0]["EMSKLCER_FLNM_ACT"] != DBNull.Value && dt.Rows[0]["EMSKLCER_FLNM_ACT"] != "") //12emp17
            {
                objSklCer.ActFname = dt.Rows[0]["EMSKLCER_FLNM_ACT"].ToString();
                objSklCer.strImg = objSklCer.ImageLoad(objSklCer.Fname, objSklCer.ActFname);
            }



        }
        return objSklCer;
    }
    [WebMethod]
    public static SkilCertfcn deleteSklCerDtlById(string Id, string empId, int mode)
    {
        SkilCertfcn objSklCer = new SkilCertfcn();
        ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
        ClsEntityLayerSkillCertifcn objEntitySkillCertfcn = new ClsEntityLayerSkillCertifcn();
        objEntitySkillCertfcn.SklCerfnDtlId = Convert.ToInt32(Id);
        objBusinessSkillCertfcn.DeleSkillCertfcn(objEntitySkillCertfcn);
        objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(empId);
        DataTable dt = objBusinessSkillCertfcn.readSklCerList(objEntitySkillCertfcn);
        objSklCer.SklCerList = objSklCer.ConvertDataTableToHTMLsklCer(dt, mode);
        return objSklCer;
    }
    [WebMethod]
    public static SkilCertfcn readSklCerList(string empId, int mode)
    {
        SkilCertfcn objSklCer = new SkilCertfcn();
        ClsBusinessLayerSkillCertfn objBusinessSkillCertfcn = new ClsBusinessLayerSkillCertfn();
        ClsEntityLayerSkillCertifcn objEntitySkillCertfcn = new ClsEntityLayerSkillCertifcn();
        objEntitySkillCertfcn.EmpUser_id = Convert.ToInt32(empId);
        DataTable dt = objBusinessSkillCertfcn.readSklCerList(objEntitySkillCertfcn);
        objSklCer.SklCerList = objSklCer.ConvertDataTableToHTMLsklCer(dt, mode);
        return objSklCer;
    }
    //Stop--Skill & Certification 




    //Start:Qualification-Language

    public void LanguageLoad()
    {
        ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
        DataTable dt = objBusinessLangauage.ReadLanguage();
        ddlQuLang.DataSource = dt;
        ddlQuLang.DataTextField = "LANGMSTR_NAME";
        ddlQuLang.DataValueField = "LANGMSTR_ID";
        ddlQuLang.DataBind();
        ddlQuLang.Items.Insert(0, "--Select Language--");
    }
    protected void btnAddLang_Click(object sender, EventArgs e)
    {
        ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
        ClsEntityLayerLanguage objEntityLanguage = new ClsEntityLayerLanguage();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLanguage.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLanguage.EmpUser_id = Convert.ToInt32(strId);
        }
        objEntityLanguage.LanguageId = Convert.ToInt32(ddlQuLang.SelectedItem.Value);
        if (HiddenFluency.Value != "")
        {
            objEntityLanguage.FlncyLvlId = Convert.ToInt32(HiddenFluency.Value);
        }

        if (CbxLangWrt.Checked == true)
        {
            objEntityLanguage.LangWriteId = 1;
        }
        if (CbxLangRead.Checked == true)
        {
            objEntityLanguage.LangReadId = 1;
        }
        if (CbxLangSpk.Checked == true)
        {
            objEntityLanguage.LangSpeakId = 1;
        }

        objEntityLanguage.Comment = txtLangCmnt.Text.Trim();
        objEntityLanguage.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
        objBusinessLangauage.insertLanguageDtl(objEntityLanguage);

        DataTable dtLanglist = objBusinessLangauage.readLangList(objEntityLanguage);
        string strHtmlLang = ConvertDataTableToHTMLlang(dtLanglist);
        divListLang.InnerHtml = strHtmlLang;


        string strRandom = objCommon.Random_Number();
        string strId1 = HiddenEmployeeMasterId.Value;
        int intIdLength = HiddenEmployeeMasterId.Value.Length;
        string stridLength = intIdLength.ToString("00");
        string Id = stridLength + strId1 + strRandom;



        Response.Redirect("gen_Emply_Personal_Informn.aspx?Id=" + Id + "&InsUpd=SaveLanguage");

        //ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationLang", "SuccessConfirmationLang();", true);
    }
    protected void btnUpdLang_Click(object sender, EventArgs e)
    {

        ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
        ClsEntityLayerLanguage objEntityLanguage = new ClsEntityLayerLanguage();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLanguage.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        if (HiddenFluency.Value != "")
        {
            objEntityLanguage.FlncyLvlId = Convert.ToInt32(HiddenFluency.Value);
        }
        if (CbxLangWrt.Checked == true)
        {
            objEntityLanguage.LangWriteId = 1;
        }
        if (CbxLangRead.Checked == true)
        {
            objEntityLanguage.LangReadId = 1;
        }
        if (CbxLangSpk.Checked == true)
        {
            objEntityLanguage.LangSpeakId = 1;
        }

        objEntityLanguage.Comment = txtLangCmnt.Text.Trim();
        objBusinessLangauage.updateLanguageDtl(objEntityLanguage);
        objEntityLanguage.EmpUser_id = Convert.ToInt32(HiddenEmployeeMasterId.Value);
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
                strHtml += "<th class=\"thT\" style=\"width:65%;text-align: left; word-wrap:break-word;\">LANGUAGE</th>";
            }
            if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:15%;text-align: center; word-wrap:break-word;\">FLUENCY LEVEL </th>";
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
                    strHtml += "<td class=\"tdT\" style=\" width:65%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                string strFlcyLvlId = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                if (intColumnBodyCount == 2)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + strFlcyLvlId + " Star </td>";
                }

            }


            string strId = dt.Rows[intRowBodyCount][0].ToString();
            int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string Id = stridLength + strId + strRandom;

            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 0.5%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\"  title=\"Edit\" onclick=\"return updateLangDtlById('" + strId + "');\" >" +
                           "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";


            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;opacity: 1;margin-left: 1%;margin-top: -1.5%;z-index: 99;\" class=\"tooltip\"  title=\"Delete\" onclick=\"return deleteLangDtlById('" + strId + "');\" >" +
                                "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";

            strHtml += "</tr>";

        }

        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    public class Language
    {
        public int LangId = 0;
        public int LangSts = 0;
        public string LangName = "";
        public int LangWrtId = 0;
        public int LangRedId = 0;
        public int LangSpkId = 0;
        public int FlncyLvlId = 0;
        public string comment = "";
        public string SklLangList = "";
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
                if (intColumnHeaderCount == 1)
                {
                    strHtml += "<th class=\"thT\" style=\"width:70%;text-align: left; word-wrap:break-word;\">LANGUAGE</th>";
                }
                if (intColumnHeaderCount == 2)
                {
                    strHtml += "<th class=\"thT\" style=\"width:10%;text-align: center; word-wrap:break-word;\">FLUENCY LEVEL</th>";
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
                        strHtml += "<td class=\"tdT\" style=\" width:70%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                    }
                    string strFlcyLvlId = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                    if (intColumnBodyCount == 2)
                    {
                        strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:center;\"  >" + strFlcyLvlId + " STAR</td>";
                    }
                }
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;\" onclick=\"return updateLangDtlById('" + strId + "');\" >" +
                               "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>";
                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + "<a style=\"cursor:pointer;\" onclick=\"return deleteLangDtlById('" + strId + "');\" >" +
                                    "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                strHtml += "</tr>";
            }
            strHtml += "</tbody>";
            strHtml += "</table>";
            sb.Append(strHtml);
            return sb.ToString();
        }
    }

    [WebMethod]
    public static Language updateLangDtlById(string Id)
    {
        Language objLang = new Language();
        ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
        ClsEntityLayerLanguage objEntityLanguage = new ClsEntityLayerLanguage();
        objEntityLanguage.LangdtlId = Convert.ToInt32(Id);
        DataTable dt = objBusinessLangauage.ReadLangDtlById(objEntityLanguage);
        if (dt.Rows.Count > 0)
        {
            objLang.LangId = Convert.ToInt32(dt.Rows[0]["LANGMSTR_ID"].ToString());
            objLang.LangSts = Convert.ToInt32(dt.Rows[0]["LANGMSTR_STATUS"].ToString());
            objLang.LangName = dt.Rows[0]["LANGMSTR_NAME"].ToString();
            objLang.LangWrtId = Convert.ToInt32(dt.Rows[0]["EMLANDTL_WRT_STS"].ToString());
            objLang.LangRedId = Convert.ToInt32(dt.Rows[0]["EMLANDTL_READ_STS"].ToString());
            objLang.LangSpkId = Convert.ToInt32(dt.Rows[0]["EMLANDTL_SPEAK_STS"].ToString());
            objLang.FlncyLvlId = Convert.ToInt32(dt.Rows[0]["EMLANDTL_FLNCYLVL_ID"].ToString());
            objLang.comment = dt.Rows[0]["EMLANDTL_CMNT"].ToString();
        }
        return objLang;
    }
    [WebMethod]
    public static Language deleteLangDtlById(string Id, string empId)
    {
        Language objLang = new Language();
        ClsBusinessLayerLanguage objBusinessLangauage = new ClsBusinessLayerLanguage();
        ClsEntityLayerLanguage objEntityLanguage = new ClsEntityLayerLanguage();
        objEntityLanguage.LangdtlId = Convert.ToInt32(Id);
        objBusinessLangauage.deleteLanguageDtl(objEntityLanguage);
        objEntityLanguage.EmpUser_id = Convert.ToInt32(empId);
        DataTable dt = objBusinessLangauage.readLangList(objEntityLanguage);
        objLang.SklLangList = objLang.ConvertDataTableToHTMLlang(dt);
        return objLang;
    }
    //Stop:Qualification-Language
    //End:Qualification
    //Start Fucntional
    //Assign Compzit module against user.
    public void BindCompzitModules()
    {
        cbxlCompzitModules.Items.Clear();
        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        DataTable dtModuleDetails = new DataTable();
        if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            objEmpRoleAllocation.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        dtModuleDetails = objBusinessEmpRoleAllocation.DisplayCompzitModuleByUsrId(objEmpRoleAllocation);
        if (dtModuleDetails.Rows.Count > 0)
        {
            divCompzitModuleList.Visible = true;
            divCompzitModuleNoList.Visible = false;
            cbxlCompzitModules.DataSource = dtModuleDetails;
            cbxlCompzitModules.DataTextField = "PRTZAPP_NAME";
            cbxlCompzitModules.DataValueField = "PRTZAPP_ID";
            cbxlCompzitModules.DataBind();
        }
        else
        {
            divCompzitModuleList.Visible = false;
            divCompzitModuleNoList.Visible = true;
        }
    }

    protected void AccommodationLoad()
    {
        ddlAccommodatn.Items.Clear();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPersonalDtls.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strDsgControlLoginUsr == "O")
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityPersonalDtls.EmpUserId = Convert.ToInt32(strId);
            }
        }
        DataTable dtAccommodation = new DataTable();
        DataTable dtState = objBusinessPersonalDtls.ReadAccomdtionMess(objEntityPersonalDtls);
        dtAccommodation = objBusinessPersonalDtls.ReadAccomdtion(objEntityPersonalDtls);
        if (dtAccommodation.Rows.Count > 0)
        {
            ddlAccmdtn.DataSource = dtAccommodation;
            ddlAccmdtn.DataTextField = "ACCMDTN_NAME";
            ddlAccmdtn.DataValueField = "ACCMDTN_ID";
            ddlAccmdtn.DataBind();
        }
        if (dtState.Rows.Count > 0)
        {
            DdlMess.DataSource = dtState;
            DdlMess.DataTextField = "ACCMDTN_NAME";
            DdlMess.DataValueField = "ACCMDTN_ID";
            DdlMess.DataBind();
        }
        ddlAccmdtn.Items.Insert(0, "--SELECT--");
        ddlCategry.Items.Insert(0, "--SELECT--");
        ddlSubCat.Items.Insert(0, "--SELECT--");
        DdlMess.Items.Insert(0, "--SELECT--");
    }
    protected void LicenseTypeLoad(int intCorpId, int intUserId = 0)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();
        objEntityUserReg.UserCrprtId = intCorpId;
        objEntityUserReg.UsrRegistrationId = intUserId;
        if (Session["ORGID"] != null)
        {
            objEntityUserReg.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strImagePath = (objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.APP_ICON_IMAGES));
        DataTable dtLicenseType = new DataTable();
        dtLicenseType = objBusinessLayerUserRegisteration.ReadLicenseType(objEntityUserReg);
        string strHtml = "";
        if (dtLicenseType.Rows.Count > 0)
        {
            for (int intRowcount = 0; intRowcount < dtLicenseType.Rows.Count; intRowcount++)
            {
                string TypeName = dtLicenseType.Rows[intRowcount]["VHCLLCNSTYP_NAME"].ToString();
                string strImageName = dtLicenseType.Rows[intRowcount]["GNIMGSCT_IMGNAME"].ToString();
                string strTypeId = dtLicenseType.Rows[intRowcount]["VHCLLCNSTYP_ID"].ToString();
                strHtml += "<div class=\"divImageLicenseType\" id=\"divImageLicenseType-" + strTypeId + "\" onclick=\"SelectLicenseType('" + strTypeId + "');\" style=\"float:left;cursor: pointer;\">";
                strHtml += "<label style=\"color: #2476A4;display: block;text-align:center;width: 100%;font-family: calibri;font-size: 15px;\" >" + TypeName + "</label>";

                strHtml += "<img style=\"margin-left: 40%;margin-top: -0.5%;padding-bottom: 2%;\"  id=\"Veh-" + strTypeId + "\" src=" + strImagePath + "" + strImageName + " alt=\"vehicle\" />";
                strHtml += "</div>";
            }
        }
        divLicenseType.InnerHtml = strHtml;
    }
    public void LoadUsr()
    {
        int intUserId = 0, intUsrRolMstrLoginSectionId, intUsrRolMstrAutoWrkShopSectionId;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strDsgControlLoginUsr == "O")
        {
            DataTable dtCrptDetails = new DataTable();
            dtCrptDetails = objBusinessLayerUserRegisteration.ReadCrptOfficeDetails(objEntityUsrRegistr);
            ddlUsrCorporate.DataSource = dtCrptDetails;
            ddlUsrCorporate.DataTextField = "CORPRT_NAME";
            ddlUsrCorporate.DataValueField = "CORPRT_ID";
            ddlUsrCorporate.DataBind();
            ddlUsrCorporate.Items.Insert(0, "--SELECT--");
            cbxlCorporateOffc.DataSource = dtCrptDetails;
            cbxlCorporateOffc.DataTextField = "CORPRT_NAME";
            cbxlCorporateOffc.DataValueField = "CORPRT_ID";
            cbxlCorporateOffc.DataBind();
        }
        else
        {
            // Here we create a DataTable with 2 columns.
            DataTable dtCorpControl = new DataTable();
            dtCorpControl.Columns.Add("CORPRT_NAME", typeof(string));
            dtCorpControl.Columns.Add("CORPRT_ID", typeof(int));
            string strCorpId = "";
            if (Session["CORPOFFICEID"] != null)
            {
                strCorpId = Session["CORPOFFICEID"].ToString();
            }
            if (strCorpId != "" && strCorpId != null)
            {
                int intCorpId = Convert.ToInt32(strCorpId);
                string strCorpName = "";
                if (Session["CORPORATENAME"] != null)
                {
                    strCorpName = Session["CORPORATENAME"].ToString();
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
                // Here we add 1 DataRows.
                dtCorpControl.Rows.Add(strCorpName, intCorpId);
                if (dtCorpControl.Rows.Count > 0)
                {
                    ddlUsrCorporate.DataSource = dtCorpControl;
                    ddlUsrCorporate.DataTextField = "CORPRT_NAME";
                    ddlUsrCorporate.DataValueField = "CORPRT_ID";
                    ddlUsrCorporate.DataBind();
                    //     ddlUsrCorporate.Items.Insert(0, "--SELECT--");
                }
                DropDownBindDepartment(strCorpId);
                mvUsrCorporate.Visible = true;
                mvUsrCorporate.SetActiveView(vSingle);
                LicenseTypeLoad(intCorpId);
                // AccommodationLoad(intCorpId);
                //Start:-Empcode
                if (Request.QueryString["Id"] == null)
                {
                    txtEmployeeCode.Text = empRefFormatLoad(intCorpId);
                }
                //End:-Empcode
            }
        }
        // for showing and hidding Login Section and AutoWorkShop Section
        intUsrRolMstrLoginSectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Login_Details);
        DataTable dtLoginSection = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrLoginSectionId);
        if (dtLoginSection.Rows.Count > 0)
        {
            divLoginDetailsSection.Style.Add("display", "block");
        }
        else
        {
            divLoginDetailsSection.Style.Add("display", "none");
        }
        intUsrRolMstrAutoWrkShopSectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Auto_Workshop);
        DataTable dtAutoWrkShopSection = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrAutoWrkShopSectionId);

        if (dtAutoWrkShopSection.Rows.Count > 0)
        {
            divAutoWorkshopSection.Style.Add("display", "block");
        }
        else
        {
            divAutoWorkshopSection.Style.Add("display", "none");
        }
    }
    //EVM--0024
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    //END
    public void Update(string strUsrId, string strEditOrView)
    {
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(strUsrId);
        int intUserId = 0, UserOrgId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityUsrRegistr.UserId = objEntityUsrRegistr.UsrRegistrationId;
        DataTable dtAcsCorpOfices = objBusinessLayerUserRegisteration.ReadAcsCorpBy_Usr(objEntityUsrRegistr);
        DataTable dtUsrMastr = objBusinessLayerUserRegisteration.ReadUsrMasterEdit(objEntityUsrRegistr);
        ReprtingEmployeeLoad(strUsrId);
        ddlUsrDsgn.Items.Clear();
        DesignationLoad();
        DropDownBind();
        ddlload(); //EVM-0024@
        UpdateTreeViewByUserId(strUsrId);
        if (dtUsrMastr.Rows.Count > 0)
        {
            if (dtAcsCorpOfices.Rows.Count > 0)
            {
                for (int intCount = 0; intCount < dtAcsCorpOfices.Rows.Count; intCount++)
                {
                    foreach (ListItem item in cbxListAccsBU.Items)
                    {
                        if (item.Value == dtAcsCorpOfices.Rows[intCount]["CORPRT_ID"].ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
            }

            if (dtUsrMastr.Rows[0]["RSGN_STS"].ToString() != "0")    //emp25
            {
                HiddenFieldRsgnSts.Value = "1";

            }
            if (dtUsrMastr.Rows[0]["LOGIN_NAME"].ToString() != "")
            { //FOR PASSWORD VISIBLITY
                divShowPassword.Visible = false;
                divCPassword.Visible = false;
                divPassword.Visible = false;
                hiddenUserEditId.Value = strUsrId;
            }

            //ie IF  DESIGNATION IS ACTIVE
            if (dtUsrMastr.Rows[0]["DSGN_STATUS"].ToString() == "1" && dtUsrMastr.Rows[0]["DSGN_CNCL_USR_ID"].ToString() == "")
            {
                ddlUsrDsgn.SelectedItem.Text = dtUsrMastr.Rows[0]["DSGN_NAME"].ToString();
                ddlUsrDsgn.SelectedItem.Value =Convert.ToInt32(dtUsrMastr.Rows[0]["DSGN_ID"]).ToString();
                if (dtUsrMastr.Rows[0]["DSGN_ID"].ToString() != "")
                {
                    if (ddlUsrDsgn.Items.FindByValue(dtUsrMastr.Rows[0]["DSGN_ID"].ToString()) != null)
                    {
                        ddlUsrDsgn.Items.FindByValue(dtUsrMastr.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtUsrMastr.Rows[0]["DSGN_NAME"].ToString(), dtUsrMastr.Rows[0]["DSGN_ID"].ToString());
                        ddlUsrDsgn.Items.Insert(1, lstGrp);
                        SortDDL(ref this.ddlUsrDsgn);
                        ddlUsrDsgn.Items.FindByValue(dtUsrMastr.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                    }
                }

            }

            //    if (ddlUsrDsgn.Items.FindByText(dtUsrMastr.Rows[0]["DSGN_NAME"].ToString()) != null)
            //    {
                    
            //        //ddlUsrDsgn.ClearSelection();
            //        //ddlUsrDsgn.Items.FindByText(dtUsrMastr.Rows[0]["DSGN_NAME"].ToString()).Selected = true;
            //        ddlUsrDsgn.ClearSelection();
            //        ddlUsrDsgn.Items.FindByText(dtUsrMastr.Rows[0]["DSGN_NAME"].ToString()).Selected = true;
            //    }
            //}
            //else
            //{
            //    ListItem lst = new ListItem(dtUsrMastr.Rows[0]["DSGN_NAME"].ToString(), dtUsrMastr.Rows[0]["DSGN_ID"].ToString());
            //    ddlUsrDsgn.Items.Insert(1, lst);
            //    SortDDL(ref this.ddlUsrDsgn);
            //    ddlUsrDsgn.ClearSelection();
            //    ddlUsrDsgn.Items.FindByText(dtUsrMastr.Rows[0]["DSGN_NAME"].ToString()).Selected = true;
            //}
            Hiddenusermode.Value = dtUsrMastr.Rows[0]["STAFF_WORKER"].ToString();
            HiddenUserCrprtDept.Value = "";
            HiddenUserCrprtDept.Value = dtUsrMastr.Rows[0]["CPRDEPT_ID"].ToString();

            //for job role 0013
            int desig = 0;
            if (ddlUsrDsgn.SelectedItem.Value != "--SELECT--")
            {
                //desig = Convert.ToInt32(ddlUsrDsgn.SelectedValue);
                desig = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
              
            }
            objEntityUsrRegistr.UserDsgnId = desig;
            if (dtUsrMastr.Rows[0]["EMPREPORTING"].ToString() != null && dtUsrMastr.Rows[0]["EMPREPORTING"].ToString() != "")  // EMP25
            {
                if (dtUsrMastr.Rows[0]["REPORT_STS"].ToString() == "1")
                {
                    if (ddlRepotingTo.Items.FindByValue(dtUsrMastr.Rows[0]["EMPREPORTING"].ToString()) != null)
                        ddlRepotingTo.Items.FindByValue(dtUsrMastr.Rows[0]["EMPREPORTING"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtUsrMastr.Rows[0]["REPORT_NAME"].ToString(), dtUsrMastr.Rows[0]["EMPREPORTING"].ToString());
                    ddlRepotingTo.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlRepotingTo);

                    ddlRepotingTo.Items.FindByValue(dtUsrMastr.Rows[0]["EMPREPORTING"].ToString()).Selected = true;
                }
            }
            if (ddlStafftype.Items.FindByValue(dtUsrMastr.Rows[0]["STAFF_WORKER"].ToString()) != null)
            {
                ddlStafftype.ClearSelection();
                ddlStafftype.Items.FindByValue(dtUsrMastr.Rows[0]["STAFF_WORKER"].ToString()).Selected = true;
            }


            ddlJobRole.Items.Clear();
            if (dtUsrMastr.Rows[0]["JOBRL_ID"].ToString() != "" && dtUsrMastr.Rows[0]["JOBRL_NAME"].ToString() != "")
            {
                int intJobRleId = Convert.ToInt32(dtUsrMastr.Rows[0]["JOBRL_ID"].ToString());
                DataTable dtJobRol = new DataTable();
                dtJobRol = objBusinessLayerUserRegisteration.ReadJobRol(objEntityUsrRegistr);
                if (dtJobRol.Rows.Count > 0)
                {
                    ddlJobRole.Items.Clear();
                    ddlJobRole.DataSource = dtJobRol;
                    ddlJobRole.DataTextField = "JOBRL_NAME";
                    ddlJobRole.DataValueField = "JOBRL_ID";
                    ddlJobRole.DataBind();
                    ddlJobRole.Items.Insert(0, "--Select Job Role--");
                    if (ddlJobRole.Items.FindByValue(dtUsrMastr.Rows[0]["JOBRL_ID"].ToString()) != null)
                    {
                        ddlJobRole.ClearSelection();
                        ddlJobRole.Items.FindByValue(dtUsrMastr.Rows[0]["JOBRL_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lst = new ListItem(dtUsrMastr.Rows[0]["JOBRL_NAME"].ToString(), dtUsrMastr.Rows[0]["JOBRL_ID"].ToString());
                        ddlJobRole.Items.Insert(1, lst);
                        SortDDL(ref this.ddlJobRole);
                        ddlJobRole.ClearSelection();
                        ddlJobRole.Items.FindByValue(dtUsrMastr.Rows[0]["JOBRL_ID"].ToString()).Selected = true;
                    }
                    ddlJobRole.Focus();
                }
                else
                {
                    ddlJobRole.Items.Clear();
                    ddlJobRole.Items.Insert(0, "--Select Job Role--");
                    ddlJobRole.Focus();
                }
            }
            else
            {
                DataTable dtJobRol = new DataTable();
                dtJobRol = objBusinessLayerUserRegisteration.ReadJobRol(objEntityUsrRegistr);
                if (dtJobRol.Rows.Count > 0)
                {
                    ddlJobRole.Items.Clear();
                    ddlJobRole.DataSource = dtJobRol;
                    ddlJobRole.DataTextField = "JOBRL_NAME";
                    ddlJobRole.DataValueField = "JOBRL_ID";
                    ddlJobRole.DataBind();
                    ddlJobRole.Items.Insert(0, "--Select Job Role--");
                    ddlJobRole.Focus();
                }
                else
                {
                    ddlJobRole.Items.Clear();
                    ddlJobRole.Items.Insert(0, "--Select Job Role--");
                    ddlJobRole.Focus();
                }
            }
            int userRole = Convert.ToInt32(dtUsrMastr.Rows[0]["JOBRL_ID"].ToString());
            DesignationSelectIndexChange(0);

            if (divLoginDetailsSection.Style["display"] != "none")
            {
                if (dtUsrMastr.Rows[0]["LOGIN_NAME"].ToString() != "")
                {
                    cbxMustLogin.Checked = true;
                }
                else
                {
                    cbxMustLogin.Checked = false;
                }
            }
            if (divAutoWorkshopSection.Style["display"] != "none")
            {
                if (dtUsrMastr.Rows[0]["USR_DRVLIC_NUMBR"].ToString() != "")
                {
                    cbxMustAutoWorkshop.Checked = true;
                }
                else
                {
                    cbxMustAutoWorkshop.Checked = false;
                }
            }

            if (dtUsrMastr.Rows[0]["USRTYP_STATUS"].ToString() == "1")
            {
                if (ddlEmpType.Items.FindByValue(dtUsrMastr.Rows[0]["USRTYP_ID"].ToString()) != null)
                {
                    ddlEmpType.ClearSelection();
                    ddlEmpType.Items.FindByValue(dtUsrMastr.Rows[0]["USRTYP_ID"].ToString()).Selected = true;
                    HiddenEmpType.Value = dtUsrMastr.Rows[0]["USRTYP_ID"].ToString();
                }
            }
            else
            {
                ListItem lst = new ListItem(dtUsrMastr.Rows[0]["USRTYP_NAME"].ToString(), dtUsrMastr.Rows[0]["USRTYP_ID"].ToString());
                ddlEmpType.Items.Insert(1, lst);
                SortDDL(ref this.ddlEmpType);
                ddlEmpType.ClearSelection();
                ddlEmpType.Items.FindByValue(dtUsrMastr.Rows[0]["USRTYP_ID"].ToString()).Selected = true;
                HiddenEmpType.Value = dtUsrMastr.Rows[0]["USRTYP_ID"].ToString();
            }
            if (dtUsrMastr.Rows[0]["USR_NAME"].ToString().Trim() != "")
            {
                TxtFrstName.Text = dtUsrMastr.Rows[0]["USR_NAME"].ToString().Trim();
            }
            else
            {
                TxtFrstName.Text = dtUsrMastr.Rows[0]["EMPERDTL_FNAME"].ToString().Trim();
            }
            TxtMidleName.Text = dtUsrMastr.Rows[0]["EMPERDTL_MNAME"].ToString().Trim();
            TxtLstName.Text = dtUsrMastr.Rows[0]["EMPERDTL_LNAME"].ToString().Trim();
            txtNationalIdNmbr.Text = dtUsrMastr.Rows[0]["USR_NTNLID_NUMBR"].ToString().Trim();
            txtEmployeeCode.Text = dtUsrMastr.Rows[0]["USR_CODE"].ToString().ToUpper().Trim();
            txtUsrMob.Text = dtUsrMastr.Rows[0]["USR_MOBILE"].ToString().Trim();
            txtUsrEmail.Text = dtUsrMastr.Rows[0]["USR_EMAIL"].ToString().Trim();
            hiddenUserImage.Value = dtUsrMastr.Rows[0]["USR_IMAGE"].ToString();
            hiddenImageName.Value = dtUsrMastr.Rows[0]["USR_IMAGE"].ToString();
            txtOfflMail.Text = dtUsrMastr.Rows[0]["USR_OFFCL_EMAIL"].ToString();

            //EVM-0027
            if (dtUsrMastr.Rows[0]["EMPERDTL_GENDER"].ToString() == "0")
            {
                RadioButtonMale.Checked = true;
            }
            else if (dtUsrMastr.Rows[0]["EMPERDTL_GENDER"].ToString() == "1")
            {
                RadioButtonFemale.Checked = true;
            }
            else
            {
                RadioButtonOther.Checked = true;
            }



          //  
            //END
            if (dtUsrMastr.Rows[0]["CNTRY_ID"].ToString() != "")
            {
                //  LicenseTypeLoad(intCorpId, Convert.ToInt32(strUsrId));         //  This has already loaded in LoadUsr() when DsgnControl is 'C' of user but if user is dsgnContrl'o' and dsgn of user for editing is 'C' then not loaded
                CountryLoad();
                ddlNationality.SelectedValue = dtUsrMastr.Rows[0]["CNTRY_ID"].ToString();
            }
            if (hiddenUserImage.Value != null && hiddenUserImage.Value != "")
            {
                //    divImageEdit.Visible = true;
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC) + hiddenUserImage.Value;
                // string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\">Click to View Image Uploaded</a>";
                string strImage = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Image Uploaded</a>";
                strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                strImage += " <img src=\"" + strImagePath + "\"/>";
                strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                strImage += "</div>";
                divImageDisplaypropic.InnerHtml = strImage;
            }
            int intUsrStatus = Convert.ToInt32(dtUsrMastr.Rows[0]["USR_STATUS"]);
            int intMailSts = Convert.ToInt32(dtUsrMastr.Rows[0]["USR_MAILSND_STS"]);
            int intMailReadSts = Convert.ToInt32(dtUsrMastr.Rows[0]["USR_MAILREAD_STS"]);
            if (intUsrStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            if (intMailSts == 1)
            {
                cbxMailSendStatus.Checked = true;
            }
            else
            {
                cbxMailSendStatus.Checked = false;
            }
            if (intMailReadSts == 1)
            {
                cbxReadMail.Checked = true;
            }
            else
            {
                cbxReadMail.Checked = false;
            }


            //emp-20
            clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
            clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
            if (Request.QueryString["WORKERID"] != null)
            {
                string strRandomMixedId = Request.QueryString["WORKERID"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityJoiningWorker.WorkerID = Convert.ToInt32(strId);
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                if (Session["ORGID"] != null)
                {
                    objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                DataTable dtWorkerDetails = new DataTable();

                dtWorkerDetails = objBusinessLayerJoiningWorker.ReadJoinigWorkerByID(objEntityJoiningWorker);
                if (dtWorkerDetails.Rows[0]["WKR_PASSPORTNO"].ToString() != "")
                {
                    Textnumber.Text = dtWorkerDetails.Rows[0]["WKR_PASSPORTNO"].ToString();
                }
            }
            hiddenDsgnContrl.Value = dtUsrMastr.Rows[0]["DSGN_CONTROL"].ToString();

            if (hiddenDsgnContrl.Value == "C")
            {
                if (dtUsrMastr.Rows[0]["CORPRT_STATUS"].ToString() == "1" && dtUsrMastr.Rows[0]["CORPRT_CNCL_USR_ID"].ToString() == "")
                {
                    ddlUsrCorporate.ClearSelection();
                    ddlUsrCorporate.Items.FindByValue(dtUsrMastr.Rows[0]["CORPRT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstc = new ListItem(dtUsrMastr.Rows[0]["CORPRT_NAME"].ToString(), dtUsrMastr.Rows[0]["CORPRT_ID"].ToString());
                    ddlUsrCorporate.Items.Insert(1, lstc);
                    SortDDL(ref this.ddlUsrCorporate);
                    ddlUsrCorporate.ClearSelection();
                    ddlUsrCorporate.Items.FindByText(dtUsrMastr.Rows[0]["CORPRT_NAME"].ToString()).Selected = true;
                }
                if (dtUsrMastr.Rows[0]["CORPRT_ID"].ToString() != "")
                {
                    int intCorpId = Convert.ToInt32(dtUsrMastr.Rows[0]["CORPRT_ID"].ToString());
                    LicenseTypeLoad(intCorpId, Convert.ToInt32(strUsrId));         //  This has already loaded in LoadUsr() when DsgnControl is 'C' of user but if user is dsgnContrl'o' and dsgn of user for editing is 'C' then not loaded
                    // AccommodationLoad(intCorpId);
                    DropDownBindDepartment(dtUsrMastr.Rows[0]["CORPRT_ID"].ToString());
                    divDept.Visible = true;
                    divDiv.Visible = true;//0013
                    bussiDiv.Visible = true;//0013
                    BindSubBusUnt(UserOrgId, intCorpId, intUserId);//0013
                }
                HiddenUserCrprtDept.Value = "";
                if (dtUsrMastr.Rows[0]["CPRDEPT_ID"].ToString() != "")
                {
                    if (rbtnCropDept.Items.FindByText(dtUsrMastr.Rows[0]["CPRDEPT_NAME"].ToString()) != null)
                    {
                        rbtnCropDept.Items.FindByText(dtUsrMastr.Rows[0]["CPRDEPT_NAME"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstD = new ListItem(dtUsrMastr.Rows[0]["CPRDEPT_NAME"].ToString(), dtUsrMastr.Rows[0]["CPRDEPT_ID"].ToString());
                        rbtnCropDept.Items.Insert(0, lstD);
                        rbtnCropDept.ClearSelection();
                        HiddenUserCrprtDept.Value = dtUsrMastr.Rows[0]["CPRDEPT_ID"].ToString();//EVM-0024@
                        rbtnCropDept.Items.FindByText(dtUsrMastr.Rows[0]["CPRDEPT_NAME"].ToString()).Selected = true;
                    }
                    checkboxDivsnLoad();
                }
                for (int intCount = 0; intCount < dtUsrMastr.Rows.Count; intCount++)
                {
                    foreach (ListItem item in cbxlCorporateDvsn.Items)
                    {
                        if (item.Value == dtUsrMastr.Rows[intCount]["CPRDIV_ID"].ToString())
                        {
                            if (HiddenDivision.Value == "0")
                            {
                                HiddenDivision.Value = dtUsrMastr.Rows[intCount]["CPRDIV_ID"].ToString();
                            }
                            else
                            {
                                HiddenDivision.Value = HiddenDivision.Value + "," + dtUsrMastr.Rows[intCount]["CPRDIV_ID"].ToString();
                            }
                            item.Selected = true;

                            if (dtUsrMastr.Rows[intCount]["USRDIV_PRIMARY_STS"].ToString() == "1")
                            {
                                hiddenPrimaryDivision.Value = dtUsrMastr.Rows[intCount]["CPRDIV_ID"].ToString();
                            }

                            //   ScriptManager.RegisterStartupScript(this, GetType(), "check", "check(" + intCount + ");", true);
                        }
                    }
                }
            }
            if (divLoginDetailsSection.Style["display"] != "none")
            {
                txtLoginName.Text = dtUsrMastr.Rows[0]["LOGIN_NAME"].ToString();
                int intLimitedUser = Convert.ToInt32(dtUsrMastr.Rows[0]["USR_LMTD"]);
                int intPaswdExpiry = Convert.ToInt32(dtUsrMastr.Rows[0]["USR_PSWD_EXPIRY"]);
                if (intLimitedUser == 1)
                {
                    cbxLimitedUser.Checked = true;
                }
                else
                {
                    cbxLimitedUser.Checked = false;
                }
                if (intPaswdExpiry == 1)
                {
                    cbxPswExpiry.Checked = true;
                }
                else
                {
                    cbxPswExpiry.Checked = false;
                }
            }
            if (divAutoWorkshopSection.Style["display"] != "none")
            {
                txtLicenceNumbr.Text = dtUsrMastr.Rows[0]["USR_DRVLIC_NUMBR"].ToString().Trim();
                txtLicenseExpDate.Text = dtUsrMastr.Rows[0]["LICEXPDATE"].ToString().Trim();
                int intDutyRoster = Convert.ToInt32(dtUsrMastr.Rows[0]["ALLOW_DUTYROSTER"]);
                if (intDutyRoster == 1)
                {
                    cbxDutyRoster.Checked = true;
                }
                else
                {
                    cbxDutyRoster.Checked = false;
                }
                hiddenUserLicenseCopy.Value = dtUsrMastr.Rows[0]["USR_DRVLIC_CPY"].ToString().Trim();
                hiddenLicenseCopyName.Value = dtUsrMastr.Rows[0]["USR_DRVLIC_CPY"].ToString().Trim();
                if (hiddenUserLicenseCopy.Value != null && hiddenUserLicenseCopy.Value != "")
                {
                    string strFileExt;
                    strFileExt = hiddenUserLicenseCopy.Value.Substring(hiddenUserLicenseCopy.Value.LastIndexOf('.') + 1).ToLower();
                    //    divImageEdit.Visible = true;
                    string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY) + hiddenUserLicenseCopy.Value;
                    string strHtmlLicCopy = "";
                    if (strFileExt == "png" || strFileExt == "gif" || strFileExt == "jpeg" || strFileExt == "jpg" || strFileExt == "bmp")
                    {
                        strHtmlLicCopy = "<a style=\"font-family: Calibri;font-size:13px;\" class=\"lightbox\" href=\"#goofyLC\" >Click to View License Copy Uploaded</a>";
                        strHtmlLicCopy += " <div class=\"lightbox-target\" id=\"goofyLC\">";
                        strHtmlLicCopy += " <img src=\"" + strImagePath + "\"/>";
                        strHtmlLicCopy += " <a class=\"lightbox-close\" href=\"#\"></a>";
                        strHtmlLicCopy += "</div>";
                    }
                    else
                    {
                        strHtmlLicCopy = "<a style=\"font-family: Calibri;font-size:13px;\" target=\"_blank\" href=\"" + strImagePath + "\" >Click to View License Copy Uploaded</a>";
                    }
                    divLicenseCopyDisplay.InnerHtml = strHtmlLicCopy;
                }
                DataTable dtLicType = objBusinessLayerUserRegisteration.ReadLicenseType_ByUsrId(objEntityUsrRegistr);
                if (dtLicType.Rows.Count > 0)
                {
                    for (int intCount = 0; intCount < dtLicType.Rows.Count; intCount++)
                    {
                        hiddenLicenseTypeId.Value = hiddenLicenseTypeId.Value + dtLicType.Rows[intCount]["VHCLLCNSTYP_ID"].ToString().Trim() + ",";
                    }
                }
            }
            //20/02 EVM-0024
            DataTable dtDistinctList = RemoveDuplicateRows(dtUsrMastr, "SUBCORPID");
            if (hiddenDsgnContrl.Value == "C")
            {
                foreach (ListItem item in cbxBussiness.Items)
                {
                    item.Selected = false;
                }
                for (int intCount = 0; intCount < dtDistinctList.Rows.Count; intCount++)
                {
                    foreach (ListItem item in cbxBussiness.Items)
                    {
                        if (item.Value == dtDistinctList.Rows[intCount]["SUBCORPID"].ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
                mvUsrCorporate.Visible = true;
                mvUsrCorporate.SetActiveView(vSingle);
            }
            else if (hiddenDsgnContrl.Value == "O")
            {
                foreach (ListItem item in cbxBussiness.Items)
                {
                    item.Selected = false;
                }
                for (int intCount = 0; intCount < dtDistinctList.Rows.Count; intCount++)
                {
                    foreach (ListItem item in cbxBussiness.Items)
                    {
                        if (item.Value == dtDistinctList.Rows[intCount]["SUBCORPID"].ToString())
                        {
                            item.Selected = true;
                        }
                    }
                }
                mvUsrCorporate.Visible = true;
                mvUsrCorporate.SetActiveView(vMultiple);
            }
        }
       
        clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();  //emp0025
        objEntityUserReg.UserId = objEntityUsrRegistr.UsrRegistrationId;
        if (ddlUsrDsgn.SelectedItem.Text != "--SELECT--")
        {
            objEntityUserReg.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
        }
        else
            objEntityUserReg.UserDsgnId = 0;
        ddlUsrDsgn.SelectedItem.Text = dtUsrMastr.Rows[0]["DSGN_NAME"].ToString();


        //  objEntityUserReg.UserId = Convert.ToInt32(HiddenEmployeeId.Value);
        string uid = Convert.ToString(objEntityUserReg.UserId);
        //objEntityUserReg.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
        objEntityUserReg.UserDvsnId = HiddenDivision.Value;
        //objEntityUserReg.UserCrprtDept= Convert.ToInt32( HiddenUserCrprtDept.Value);
        if (rbtnCropDept.SelectedValue != "" && rbtnCropDept.SelectedValue != null)
        {
            objEntityUserReg.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedValue);
        }

        DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUserReg);
        string count = dtWelfareScvc.Rows.Count.ToString();
        // DataTable dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityUserReg);
        DataTable dtWelfar = new DataTable();
        dtWelfar = null;
        if (dtWelfareScvc.Rows.Count > 0)
        {

            string strHtmmm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar, count, uid);
            //Write to divReport
            divReport1.InnerHtml = strHtmmm;
            divwelfareSrevc.Attributes["style"] = "display:block;";
        }
        else
        {
            divwelfareSrevc.Attributes["style"] = "display:none;";
        }
       
    }
    public void AccsbleBULoad()
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityUsrRegistr.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["DSGN_CONTROL"] != null)
        {
            objEntityUsrRegistr.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtAccsbleCorp = new DataTable();
        dtAccsbleCorp = objBusinessLayerUserRegisteration.ReadAccessibleCorp(objEntityUsrRegistr);
        if (dtAccsbleCorp.Rows.Count > 0)
        {
            cbxListAccsBU.DataSource = dtAccsbleCorp;
            cbxListAccsBU.DataTextField = "CORPRT_NAME";
            cbxListAccsBU.DataValueField = "CORPRT_ID";
            cbxListAccsBU.DataBind();
            cbxListAccsBU.Enabled = true;
            divAcsBUContainer.Style["display"] = "block";
        }
        else
        {
            divAcsBUContainer.Style["display"] = "none";
        
        }

    }

    public void UserTypeLoad()
    {
        ddlEmpType.Items.Clear();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        DataTable dtUserTypes = new DataTable();
        dtUserTypes = objBusiness.ReadUserTypeMaster();
        if (dtUserTypes.Rows.Count > 0)
        {
            ddlEmpType.DataSource = dtUserTypes;
            ddlEmpType.DataTextField = "USRTYP_NAME";
            ddlEmpType.DataValueField = "USRTYP_ID";
            ddlEmpType.DataBind();
        }
        ddlEmpType.Items.Insert(0, "--SELECT--");
    }
    //Assign Designation details from GN_DESIGNATIONS table to dropdownlist based on control.
    public void DropDownBind()
    {
        ddlUsrDsgn.Items.Clear();
        string strUsrDsgnId = "", strUserDsgnName = "";
        int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
        clsEntityLayerDesignation objEntityDsgnation = new clsEntityLayerDesignation();
        clsBusinessLayerDesignation objBusinessLayerDsgnMaster = new clsBusinessLayerDesignation();
        DataTable dtUserDetails = new DataTable();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityDsgnation.DesignationUserId = intUserId;
        dtUserDetails = objBusinessLayerDsgnMaster.ReadIfUserLimitedByUsrId(objEntityDsgnation);
        if (dtUserDetails.Rows.Count > 0)
        {
            intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
            strUsrDsgnId = dtUserDetails.Rows[0]["DSGN_ID"].ToString();
            strUserDsgnName = dtUserDetails.Rows[0]["DSGN_NAME"].ToString();
        }
        if (intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED))
        {
            clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
            DataTable dtDsgnDetails = new DataTable();
            if (Session["DSGN_CONTROL"] != null)
            {
                objEntityUsrRegistr.DsgControl = Convert.ToChar(Session["DSGN_CONTROL"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            dtDsgnDetails = objBusinessLayerUserRegisteration.ReadDsgnDetails(objEntityUsrRegistr);
            ddlUsrDsgn.DataSource = dtDsgnDetails;
            ddlUsrDsgn.DataTextField = "DSGN_NAME";
            ddlUsrDsgn.DataValueField = "DSGN_ID";
            ddlUsrDsgn.DataBind();
            ddlUsrDsgn.Items.Insert(0, "--SELECT--");
        }
        else
        {//IF LIMITED USER
            clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
            ListItem liDsgn = new ListItem();
            //string strUsrId = "";
            liDsgn.Text = strUserDsgnName;
            liDsgn.Value = strUsrDsgnId;
            ddlUsrDsgn.Items.Add(liDsgn);
            DesignationSelectIndexChange(0);
            objEntityUsrRegistr.UsrRegistrationId = intUserId;
            DataTable dtUsrMastr = objBusinessLayerUserRegisteration.ReadUsrMasterEdit(objEntityUsrRegistr);
            objEntityUsrRegistr.UserDsgnId = Convert.ToInt32(strUsrDsgnId);
            DataTable dtJobRol = new DataTable();
            dtJobRol = objBusinessLayerUserRegisteration.ReadJobRol(objEntityUsrRegistr);
            if (dtJobRol.Rows.Count > 0)
            {
                for (int intcount = 0; intcount < dtJobRol.Rows.Count; intcount++)
                {
                    ddlJobRole.DataSource = dtJobRol;
                    ddlJobRole.DataTextField = "JOBRL_NAME";
                    ddlJobRole.DataValueField = "JOBRL_ID";
                    ddlJobRole.DataBind();
                }
                ddlJobRole.Items.Insert(0, "--Select Job Role--");
                ddlJobRole.Focus();
            }
            else
            {
                ddlJobRole.Items.Insert(0, "--Select Job Role--");
                ddlJobRole.Focus();
            }
        }
    }
    public void DropDownBindDepartment(string strCrptId = null)
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (strCrptId == null)
        {
            if (ddlUsrCorporate.SelectedItem.Text.ToString() != "--SELECT--")
            {
                objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value.ToString());
                DataTable dtDeptDetails = new DataTable();
                dtDeptDetails = objBusinessLayerUserRegisteration.ReadCrptDeptDetails(objEntityUsrRegistr);
                rbtnCropDept.DataTextField = "CPRDEPT_NAME";
                rbtnCropDept.DataValueField = "CPRDEPT_ID";
                rbtnCropDept.DataSource = dtDeptDetails;
                rbtnCropDept.DataBind();
                rbtnCropDept.Enabled = true;
            }
            else
            {
                objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value.ToString());
                DataTable dtDeptDetails = new DataTable();
                dtDeptDetails = objBusinessLayerUserRegisteration.ReadCrptDeptDetails(objEntityUsrRegistr);
                rbtnCropDept.DataTextField = "CPRDEPT_NAME";
                rbtnCropDept.DataValueField = "CPRDEPT_ID";
                rbtnCropDept.DataSource = dtDeptDetails;
                rbtnCropDept.DataBind();
                rbtnCropDept.Enabled = true;
            }
        }
        else
        {
            objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(strCrptId);
            DataTable dtDeptDetails = new DataTable();
            dtDeptDetails = objBusinessLayerUserRegisteration.ReadCrptDeptDetails(objEntityUsrRegistr);
            rbtnCropDept.DataTextField = "CPRDEPT_NAME";
            rbtnCropDept.DataValueField = "CPRDEPT_ID";
            rbtnCropDept.DataSource = dtDeptDetails;
            rbtnCropDept.DataBind();
            rbtnCropDept.Enabled = true;
        }
    }
    //0013 sub bussiness unit checkboxlist bind
    public void BindSubBusUnt(int orgId = 0, int corpId = 0, int usrId = 0)
    {
        bussiDiv.Visible = true;
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (orgId == 0 || corpId == 0 || usrId == 0)
        {
            if (ddlUsrCorporate.SelectedItem.Text.ToString() != "--SELECT--" && ddlUsrCorporate.SelectedItem.Text.ToString() != "")
            {
                objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value.ToString());
                DataTable dtSubBussUnit = new DataTable();
                dtSubBussUnit = objBusinessLayerUserRegisteration.ReadSubBusUnt(objEntityUsrRegistr);
                if (dtSubBussUnit.Rows.Count > 0)
                {
                    cbxBussiness.DataSource = dtSubBussUnit;
                    cbxBussiness.DataTextField = "CORPRT_NAME";
                    cbxBussiness.DataValueField = "CORPRT_ID";
                    cbxBussiness.DataBind();
                    cbxBussiness.Enabled = true;
                }
                else
                {
                    bussiDiv.Visible = false;
                }
            }
            else
            {
                bussiDiv.Visible = false;
            }
        }
        else
        {
            if (ddlUsrCorporate.SelectedItem.Text.ToString() != "--SELECT--")
            {
                objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value.ToString());
                DataTable dtSubBussUnit = new DataTable();
                dtSubBussUnit = objBusinessLayerUserRegisteration.ReadSubBusUnt(objEntityUsrRegistr);
                if (dtSubBussUnit.Rows.Count > 0)
                {
                    cbxBussiness.DataSource = dtSubBussUnit;
                    cbxBussiness.DataTextField = "CORPRT_NAME";
                    cbxBussiness.DataValueField = "CORPRT_ID";
                    cbxBussiness.DataBind();
                    cbxBussiness.Enabled = true;
                }
                else
                {
                    bussiDiv.Visible = false;
                }
            }
            else
            {
                bussiDiv.Visible = false;
            }
            DataTable dtSubBussUnit1 = new DataTable();
            objEntityUsrRegistr.UserId = usrId;
            objEntityUsrRegistr.UserOrgId = orgId;
            objEntityUsrRegistr.UserCrprtId = corpId;
            dtSubBussUnit1 = objBusinessLayerUserRegisteration.ReadSubBuss(objEntityUsrRegistr);
            for (int intCount = 0; intCount < dtSubBussUnit1.Rows.Count; intCount++)
            {
                foreach (ListItem item in cbxBussiness.Items)
                {
                    if (item.Value == dtSubBussUnit1.Rows[intCount]["SUBCORPRT_ID"].ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }
    //0013
    private List<clsEntityLayerJobRlRole> Merge(List<clsEntityLayerJobRlRole> objlisDsgnRolMainDtls, List<clsEntityLayerJobRlRole> objlisDsgnRolChildrenDtls)
    {
        List<clsEntityLayerJobRlRole> objlisDsgnRol = null;
        objlisDsgnRol = new List<clsEntityLayerJobRlRole>();
        foreach (clsEntityLayerJobRlRole objDsgnRolMainDtls in objlisDsgnRolMainDtls)
        {
            string strchild = "";
            foreach (clsEntityLayerJobRlRole objDsgnRolChildrenDtls in objlisDsgnRolChildrenDtls)
            {
                if (objDsgnRolMainDtls.UsrRolId == objDsgnRolChildrenDtls.UsrRolId)
                {
                    if (strchild != "")
                    {
                        strchild = strchild + "-" + objDsgnRolChildrenDtls.strChildRolId;
                    }
                    else
                    {
                        strchild = objDsgnRolChildrenDtls.strChildRolId;
                    }
                }
            }
            objDsgnRolMainDtls.strChildRolId = strchild;
        }
        return objlisDsgnRolMainDtls;
    }
    //
    protected void btnAdd_ClickUsrRegistr(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityUsrRegistr.UserEmail = txtUsrEmail.Text.Trim();
        objEntityUsrRegistr.OffclEmail = txtOfflMail.Text.Trim();
        if (divLoginDetailsSection.Style["display"] != "none")
        {
            if (cbxMustLogin.Checked == true)
            {
                objEntityUsrRegistr.LoginName = txtLoginName.Text.Trim();
            }
        }
        string strNameCount = "0";//emp00025
        if (txtEmployeeCode.Text != "" && txtEmployeeCode.Text != null)
        {
            objEntityUsrRegistr.UserCode = txtEmployeeCode.Text.ToUpper().Trim();
            strNameCount = objBusinessLayerUserRegisteration.CheckEmployeeCode(objEntityUsrRegistr);
            //0039
            strNameCount = "0";
            //end
        }

        //   objEntityUsrRegistr.UserCode = txtEmployeeCode.Text.ToUpper().Trim();
        string strEmailCount = "0";
        if (objEntityUsrRegistr.UserEmail != "")//EMAIL CAN BE NULL SO THIS CHECKING
        {
            strEmailCount = objBusinessLayerUserRegisteration.CheckDupUserEmailIns(objEntityUsrRegistr);
            //0039
            strEmailCount = "0";
            //end
        }
        //DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUsrRegistr);//EMP0025
        //List<clsEntityLayerEmployeeWelfareSrvc> objListEmpWelfare = new List<clsEntityLayerEmployeeWelfareSrvc>();


        //string jsonData = Hiddenchecklist.Value;
        //string c = jsonData.Replace("\"{", "\\{");
        //string d = c.Replace("\\n", "\r\n");
        //string g = d.Replace("\\", "");
        //string h = g.Replace("}\"]", "}]");
        //string k = h.Replace("}\",", "},");
        //List<clsWBData> objWBDataList = new List<clsWBData>();
        //objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
        //foreach (clsWBData objclsWBData in objWBDataList)
        //{
        //    clsEntityLayerEmployeeWelfareSrvc objEmp = new clsEntityLayerEmployeeWelfareSrvc();

        //    objEmp.Emp_Id = Convert.ToInt32(objclsWBData.EmpId);
        //    objEmp.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
        //    objEmp.Qty = Convert.ToDecimal(objclsWBData.limit);
        //    objListEmpWelfare.Add(objEmp);
        //}
        if (strEmailCount == "0")
        {
            string strLNameCount = "0";
            if (objEntityUsrRegistr.LoginName != "")//LOGIN NAME CAN BE NULL SO THIS CHECKING
            {
                strLNameCount = objBusinessLayerUserRegisteration.CheckDupUserLoginName(objEntityUsrRegistr);
                //0039
                strLNameCount = "0";
                //end
            }
            if (strLNameCount == "0")
            {
                if (strNameCount == "0")
                {

                    List<clsEntityLayerUserVhclType> objlisUsrVhclLicTypDtls = new List<clsEntityLayerUserVhclType>();
                    objEntityUsrRegistr.UserName = TxtFrstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.Fname = TxtFrstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.Mname = TxtMidleName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.Lname = TxtLstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.CountryID = Convert.ToInt32(ddlNationality.SelectedItem.Value);
                    objEntityUsrRegistr.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
                    //objEntityUsrRegistr.JoiningDate = objCommon.textToDateTime(txtJoiningDate.Text.Trim());
                    objEntityUsrRegistr.UserRoleId = Convert.ToInt32(ddlJobRole.SelectedItem.Value.ToString());//0013
                    objEntityUsrRegistr.EmployeeTypId = Convert.ToInt32(ddlEmpType.SelectedItem.Value.ToString());
                    objEntityUsrRegistr.NationalIdNumber = txtNationalIdNmbr.Text.Trim();
                    objEntityUsrRegistr.UserMobile = txtUsrMob.Text.Trim();

                    objEntityUsrRegistr.UsrType = Convert.ToInt32(ddlStafftype.SelectedItem.Value);
                    if (RadioButtonMale.Checked)
                    {
                        objEntityUsrRegistr.Gender = 0;
                    }
                    else if (RadioButtonFemale.Checked)
                    {
                        objEntityUsrRegistr.Gender = 1;
                    }
                    else if (RadioButtonOther.Checked)
                    {
                        objEntityUsrRegistr.Gender = 2;
                    }
                    if (Session["USERID"] != null)
                    {
                        objEntityUsrRegistr.UserId = Convert.ToInt32(Session["USERID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                    if (cbxStatus.Checked)
                    {
                        objEntityUsrRegistr.UserStatus = 1;
                    }
                    else
                    {
                        objEntityUsrRegistr.UserStatus = 0;
                    }
                    if (cbxMailSendStatus.Checked)
                    {
                        objEntityUsrRegistr.MailSendSts = 1;
                    }
                    else
                    {
                        objEntityUsrRegistr.MailSendSts = 0;
                    }
                    if (cbxReadMail.Checked)
                    {
                        objEntityUsrRegistr.MailReadSts = 1;
                    }
                    else
                    {
                        objEntityUsrRegistr.MailReadSts = 0;
                    }
                    if (divLoginDetailsSection.Style["display"] != "none")
                    {
                        if (cbxMustLogin.Checked == true)
                        {
                            objEntityUsrRegistr.UserPsw = txtUsrPwd.Text.Trim();
                            if (cbxLimitedUser.Checked)
                            {
                                objEntityUsrRegistr.LimitedUser = 1;
                            }
                            else
                            {
                                objEntityUsrRegistr.LimitedUser = 2;
                            }
                            if (cbxPswExpiry.Checked)
                            {
                                objEntityUsrRegistr.PasswordExpiry = 1;
                            }
                            else
                            {
                                objEntityUsrRegistr.PasswordExpiry = 2;
                            }
                        }
                    }
                    if (divAutoWorkshopSection.Style["display"] != "none")
                    {
                        if (cbxMustAutoWorkshop.Checked == true)
                        {
                            objEntityUsrRegistr.LicenseNumber = txtLicenceNumbr.Text.Trim();
                            objEntityUsrRegistr.LicenseExpiryDate = objCommon.textToDateTime(txtLicenseExpDate.Text.Trim());

                            if (cbxDutyRoster.Checked)
                            {
                                objEntityUsrRegistr.AllowDutyRoster = 1;
                            }
                            else
                            {
                                objEntityUsrRegistr.AllowDutyRoster = 0;
                            }
                            if (hiddenLicenseTypeId.Value != "")
                            {

                                string strLicTypList = hiddenLicenseTypeId.Value;
                                // Split string on spaces.
                                // ... This will separate all the words.
                                string[] strArrLicenseTypes = strLicTypList.Split(',');
                                foreach (string strLicTyp in strArrLicenseTypes)
                                {
                                    if (strLicTyp != "")
                                    {
                                        clsEntityLayerUserVhclType objEntityUsrVhclType = new clsEntityLayerUserVhclType();
                                        objEntityUsrVhclType.LicTypeId = Convert.ToInt32(strLicTyp);
                                        objlisUsrVhclLicTypDtls.Add(objEntityUsrVhclType);
                                    }
                                }

                            }

                        }
                    }
                    List<clsEntityLayerUserCorporate> objEntityAccsCorporateList = new List<clsEntityLayerUserCorporate>();
                    foreach (ListItem item in cbxListAccsBU.Items)
                    {
                        if (item.Selected)
                        {
                            clsEntityLayerUserCorporate objEntityAccsCorporate = new clsEntityLayerUserCorporate();
                            objEntityAccsCorporate.UsrCrprtId = Convert.ToInt32(item.Value);
                            objEntityAccsCorporateList.Add(objEntityAccsCorporate);
                        }
                    }
                    //for sub business unit section 0013
                    List<clsEntityLayerUserSubBusness> objlisUserSubBusnessDtls = new List<clsEntityLayerUserSubBusness>();
                    int intDefaultCorpId = 0;
                    foreach (ListItem item in cbxBussiness.Items)
                    {
                        if (item.Selected)
                        {
                            if (intDefaultCorpId == 0)
                            {
                                intDefaultCorpId = Convert.ToInt32(item.Value);
                            }
                            clsEntityLayerUserSubBusness objEntityUsrSubBus = new clsEntityLayerUserSubBusness();
                            objEntityUsrSubBus.SubBusUntId = Convert.ToInt32(item.Value);
                            objEntityUsrSubBus.DfltSubBusUntId = intDefaultCorpId;
                            if (Session["ORGID"] != null)
                            {
                                objEntityUsrSubBus.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                            }
                            else
                            {
                                Response.Redirect("~/Default.aspx");
                            }

                            objlisUserSubBusnessDtls.Add(objEntityUsrSubBus);
                        }
                    }

                    //FOR USER IMAGE
                    if (FileUploadProPic.HasFile)
                    {
                        // GET FILE EXTENSION
                        string strFileExt;
                        strFileExt = FileUploadProPic.FileName.Substring(FileUploadProPic.FileName.LastIndexOf('.') + 1).ToLower();
                        int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.USER_MASTER);
                        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                        string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityUsrRegistr.UsrRegistrationId.ToString() + "." + strFileExt;
                        objEntityUsrRegistr.ImagePath = strImageName;
                    }
                    if (divAutoWorkshopSection.Style["display"] != "none")
                    {
                        if (cbxMustAutoWorkshop.Checked == true)
                        {
                            //FOR LICENSE COPY
                            if (FileUploadLicenseCopy.HasFile)
                            {
                                // GET FILE EXTENSION
                                string strFileExt;
                                strFileExt = FileUploadLicenseCopy.FileName.Substring(FileUploadLicenseCopy.FileName.LastIndexOf('.') + 1).ToLower();
                                int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.USER_MASTER);
                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityUsrRegistr.UsrRegistrationId.ToString() + "." + strFileExt;
                                objEntityUsrRegistr.LicenseCopyPath = strImageName;
                            }
                        }
                    }
                    //start-inserting jobroles userroles
                    int intTreeAppAdminVisible = 0, intTreeSFAVisible = 0, intTreeAWMSVisible = 0, intTreeGMSVisible = 0, intTreeHCMVisible = 0, intTreeFMSVisible = 0, intTreePMSVisible = 0;
                    List<clsEntityLayerEmployeeAppRole> objlisJobRlAppRol = new List<clsEntityLayerEmployeeAppRole>();
                    foreach (ListItem itemCheckBoxModules in cbxlCompzitModules.Items)
                    {
                        if (itemCheckBoxModules.Selected)
                        {
                            clsEntityLayerEmployeeAppRole objEmpRlAppRol = new clsEntityLayerEmployeeAppRole();

                            // If the item is selected.

                            if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                            {
                                intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                            {
                                intTreeSFAVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                            {
                                intTreeAWMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                            {
                                intTreeGMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                            {
                                intTreeHCMVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                            {
                                intTreeFMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))
                            {
                                intTreePMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }

                            objEmpRlAppRol.App_Id = Convert.ToInt32(itemCheckBoxModules.Value);
                            objlisJobRlAppRol.Add(objEmpRlAppRol);
                        }
                    }
                    List<clsEntityLayerEmployeeRole> objlisDsgnRol = new List<clsEntityLayerEmployeeRole>();

                    if (intTreeAppAdminVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_AppAdmin = TreeViewCompzit_AppAdminstration.CheckedNodes;
                        if (objNodeCollection_COMPZIT_AppAdmin.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_AppAdmin = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_AppAdmin = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_Online in objNodeCollection_COMPZIT_AppAdmin)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();

                                string[] strchild = objTreeNode_Online.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_AppAdmin.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_AppAdmin.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolAppAdministration = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolAppAdministration = Merge(objlisDsgnRolMainDtls_AppAdmin, objlisDsgnRolChildrenDtls_AppAdmin);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolAppAdministration)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeSFAVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_SalesAutmtn = TreeViewCompzit_SalesAutomation.CheckedNodes;
                        if (objNodeCollection_COMPZIT_SalesAutmtn.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_SFA = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_SFA = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_SFA in objNodeCollection_COMPZIT_SalesAutmtn)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();

                                string[] strchild = objTreeNode_SFA.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_SFA.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_SFA.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolSFA = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolSFA = Merge(objlisDsgnRolMainDtls_SFA, objlisDsgnRolChildrenDtls_SFA);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolSFA)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeAWMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_WorkshopMngmnt = TreeViewCompzit_AutoWorkshopManagement.CheckedNodes;
                        if (objNodeCollection_COMPZIT_WorkshopMngmnt.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_WMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_WMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_WMS in objNodeCollection_COMPZIT_WorkshopMngmnt)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_WMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_WMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_WMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_WMS, objlisDsgnRolChildrenDtls_WMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeGMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_GuaranteeManagement = TreeViewCompzit_GuaranteeManagement.CheckedNodes;
                        if (objNodeCollection_COMPZIT_GuaranteeManagement.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_GMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_GMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_GMS in objNodeCollection_COMPZIT_GuaranteeManagement)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();

                                string[] strchild = objTreeNode_GMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_GMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_GMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_GMS, objlisDsgnRolChildrenDtls_GMS);
                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeHCMVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_HumanCapitalManagement = TreeViewCompzit_HumanCapitalManagement.CheckedNodes;
                        if (objNodeCollection_COMPZIT_HumanCapitalManagement.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_HCM = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_HCM = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_HCM in objNodeCollection_COMPZIT_HumanCapitalManagement)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_HCM.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_HCM.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_HCM.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_HCM, objlisDsgnRolChildrenDtls_HCM);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeFMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_FinanceManagementSystem = TreeViewCompzit_FinanceManagementSystem.CheckedNodes;
                        if (objNodeCollection_COMPZIT_FinanceManagementSystem.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_FMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_FMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_HCM in objNodeCollection_COMPZIT_FinanceManagementSystem)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_HCM.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_FMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_FMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_FMS, objlisDsgnRolChildrenDtls_FMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreePMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_ProcurementManagementSystem = TreeViewCompzit_ProcurementManagementSystem.CheckedNodes;
                        if (objNodeCollection_COMPZIT_ProcurementManagementSystem.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_PMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_PMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_PMS in objNodeCollection_COMPZIT_ProcurementManagementSystem)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_PMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_PMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_PMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_PMS, objlisDsgnRolChildrenDtls_PMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }


                    if (hiddenDsgnContrl.Value == "O")
                    {
                        List<clsEntityLayerUserCorporate> objlisUsrCrprtDtls = new List<clsEntityLayerUserCorporate>();
                        foreach (ListItem item in cbxlCorporateOffc.Items)
                        {
                            if (item.Selected)
                            {
                                clsEntityLayerUserCorporate objEntityUsrCrprt = new clsEntityLayerUserCorporate();
                                objEntityUsrCrprt.UsrCrprtId = Convert.ToInt32(item.Value);
                                int corpid = Convert.ToInt32(item.Value);
                                if (Session["ORGID"] != null)
                                {
                                    objEntityUsrCrprt.UsrOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                }
                                else
                                {
                                    Response.Redirect("~/Default.aspx");
                                }
                                objlisUsrCrprtDtls.Add(objEntityUsrCrprt);
                                // BankLoad(strId, corpid);
                            }
                        }
                        if (hiddenBankDtls.Value != "")
                        {
                            ddlBank.Items.FindByValue(hiddenBankDtls.Value).Selected = true;
                        }
                        //clsBusiness_Leave_Type objBusinessLeavetype = new clsBusiness_Leave_Type();
                        //clsEntity_Leave_Type ObjEntityLeaveType = new clsEntity_Leave_Type();
                        //List<clsEntity_Users_list> objEntityUser_List = new List<clsEntity_Users_list>();

                        //DataTable dtLeaveType = objBusinessLayerUserRegisteration.ReadLeaveTypeByDesgn(objEntityUsrRegistr);
                        //for (int Leave = 0; Leave < dtLeaveType.Rows.Count; Leave++)
                        //{
                        //    if (dtLeaveType.Rows[Leave]["LEAVETYP_ID"].ToString() != "")
                        //    {
                        //        ObjEntityLeaveType.lea = hiddenselectedDesignlist.Value;
                        //        clsEntity_Users_list objEntityUsers_list = new clsEntity_Users_list();
                        //        if (!(UserID.Contains(dtDsgnUsers.Rows[i]["USR_ID"].ToString())))
                        //        {
                        //            UserID = UserID + "," + dtDsgnUsers.Rows[i]["USR_ID"].ToString();
                        //            objEntityUsers_list.UserID = Convert.ToInt32(dtDsgnUsers.Rows[i]["USR_ID"].ToString());
                        //            objEntityUser_List.Add(objEntityUsers_list);
                        //        }
                        //    }
                        //}


                        int intEmployeeID = 0;
                        intEmployeeID = objBusinessLayerUserRegisteration.InsertUserRegisterationDetail(objEntityUsrRegistr, objEntityAccsCorporateList, objlisUsrCrprtDtls, null, objlisUsrVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);


                        //Start:-For job details insert

                        int intCorpId = 0;
                        int intOrgId = 0;
                        int IntUsrId = 0;
                        int intUsrRolMstrId;
                        int intEnableRenew = 0;
                        clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
                        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
                        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
                        if (Session["CORPOFFICEID"] != null)
                        {
                            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                        }
                        if (Session["ORGID"] != null)
                        {
                            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                            objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                        }
                        else if (Session["ORGID"] == null)
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                        if (Session["USERID"] != null)
                        {
                            objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"].ToString());
                            IntUsrId = Convert.ToInt32(Session["USERID"].ToString());
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                        //EVM-0027
                        if (ddlProject.Text == "--SELECT PROJECT--")
                        {
                            objEntityJobDetails.Project = 0;

                        }
                        else
                        {
                            objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
                        }
                        if (ddlSponsor.Text == "--SELECT SPONSOR--")
                        {
                            objEntityJobDetails.Sponsorid = 0;

                        }
                        else
                        {
                            objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
                        }


                        //END

                        objEntityJobDetails.JoinedDate = objCommon.textToDateTime(txtJoineddate.Text);
                        if (txtpermanencyDate.Text == "")
                        {
                            objEntityJobDetails.PermamanencyDate = DateTime.Today;
                        }
                        else
                        {
                            objEntityJobDetails.PermamanencyDate = objCommon.textToDateTime(txtpermanencyDate.Text);
                        }
                        if (txtProbationdate.Text == "")
                        {
                            objEntityJobDetails.ProbationEnddate = DateTime.Today;
                        }
                        else
                        {

                            objEntityJobDetails.ProbationEnddate = objCommon.textToDateTime(txtProbationdate.Text);
                        }
                        if (TxtPeriod.Text == "")
                        {
                            objEntityJobDetails.Probation = 0;
                        }
                        else
                        {
                            objEntityJobDetails.Probation = int.Parse(TxtPeriod.Text);
                        }

                        if (ddlDepartment.Text == "--SELECT DEPARTMENT--")
                        {
                            objEntityJobDetails.Department_Id = 0;
                        }
                        else
                        {

                            objEntityJobDetails.Department_Id = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
                        }

                        objEntityJobDetails.Description = TxtJobDesc.Text;

                        objEntityJobDetails.Designation = 0;



                        if (ddlDivision.Text == "--SELECT DIVISION--")
                        {
                            objEntityJobDetails.Division = 0;
                        }
                        else
                        {

                            objEntityJobDetails.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                        };
                        objEntityJobDetails.EmployeeId = intEmployeeID;
                        //   objEntityJobDetails.EmployeeLocation = TxtLocation.Text; HiddenEmpId.Value
                        //EVM-0024
                        objEntityJobDetails.EmployeeType = HiddenEmpType.Value;
                        //END
                        // objEntityJobDetails.EmployeeType = ddlEmployeeType.SelectedItem.Text;
                        objEntityJobDetails.JobCancelREASON = Txtelgblestats.Text;
                        objEntityJobDetails.JobTitle = TxtjobTitle.Text;
                        objEntityJobDetails.JobUserDate = DateTime.Now;
                        //evm-0027
                        // objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
                        //EVM-0027
                        objEntityJobDetails.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
                        DataTable dtDsgnMastr = objBusinessJobDetails.ReadDesignationType(objEntityJobDetails);
                        //objEntityJobDetails.JobType = ddtype.SelectedItem.Text;
                        if (dtDsgnMastr.Rows[0]["D_TYPE"].ToString() == "1")
                        {
                            objEntityJobDetails.JobType = "Labour";
                        }
                        else
                        {
                            objEntityJobDetails.JobType = "Staff";
                        }
                        //objEntityJobDetails.JobType = Convert.ToInt32(dtDsgnMastr.Rows[0]["D_TYPE"]); 
                        objEntityJobDetails.ProjectLocation = Txtprojloc.Text;
                        //EVM-0027
                        //   objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
                        //END
                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEEJOB);
                        objEntityCommon.CorporateID = intCorpId;
                        objEntityCommon.Organisation_Id = intOrgId;
                        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                        objEntityJobDetails.Job_Id = Convert.ToInt32(strNextId);

                        objBusinessJobDetails.AddJobDetails(objEntityJobDetails);
                        Hiddenjobid.Value = strNextId;
                        BtnsaveJob.Visible = false;
                        BtnupdateJob.Visible = true;
                        Btnclrjob.Visible = true;
                        txtProbationdate.Enabled = false;
                        ddlPlusWeek.Enabled = false;//evm--0024
                        //Response.Redirect("gen_Emply_Personal_Informn.aspx?InsUpd=Ins");

                        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
                        DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(IntUsrId, intUsrRolMstrId);
                        if (dtChildRol.Rows.Count > 0)
                        {
                            string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                            string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                            foreach (string strC_Role in strChildDefArrWords)
                            {
                                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                                    intEnableRenew = 1;
                            }
                        }
                        if (intEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            divRenewImg.Visible = true;
                        }
                        else
                        {
                            divRenewImg.Visible = false;
                        }
                        InsUserLeaveTypes(intCorpId, intOrgId, objEntityJobDetails.EmployeeId, objEntityJobDetails.JoinedDate, 1);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "JobSuccessConfirmation", "JobSuccessConfirmation();", true);

                        //End:-For job details insert






                        string strRandom = objCommon.Random_Number();
                        string strId = intEmployeeID.ToString();
                        int intIdLength = intEmployeeID.ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string PassingId = stridLength + strId + strRandom;


                        //strores id in cand dtls                        
                        clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
                        clsEntityCandidatelogin objEntityCandidatelogin = new clsEntityCandidatelogin();
                        if (Request.QueryString["CANDID"] != null)
                        {
                            ////emp0021//////
                            string strRandomMixedId = Request.QueryString["CANDID"].ToString();
                            string strLenghtofId = strRandomMixedId.Substring(0, 2);
                            int intLenghtofId = Convert.ToInt16(strLenghtofId);
                            string strId2 = strRandomMixedId.Substring(2, intLenghtofId);
                            objEntityCandidatelogin.CandidateId = Convert.ToInt32(strId2);
                            objEntityCandidatelogin.EmployeeId = intEmployeeID;
                            //UpdateCandidatesId
                            objBusiness_Candidate_Login.UpdateCandidatesId(objEntityCandidatelogin);
                        }
                        //FOR SAVING DOCUMENTS
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                        if (FileUploadProPic.HasFile)
                        {
                            FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityUsrRegistr.ImagePath);
                        }
                        string strLicenseCopyPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                        if (FileUploadLicenseCopy.HasFile)
                        {
                            FileUploadLicenseCopy.SaveAs(Server.MapPath(strLicenseCopyPath) + objEntityUsrRegistr.LicenseCopyPath);
                        }
                        if (divLoginDetailsSection.Style["display"] != "none")
                        {
                            if (cbxMustLogin.Checked == true)
                            {
                                //005 start
                                if (Session["CORPOFFICEID"] != null)
                                {
                                    objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
                                }
                                else if (Session["CORPOFFICEID"] == null)
                                {
                                    if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                    {
                                        Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                                    }
                                    else if (clickedButton.ID == "btnAddClose")
                                    {
                                        Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                    }
                                }
                                List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
                                clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
                                clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                                MailMessage mail = new MailMessage();
                                DataTable dtFromMail = objBussinessLayer.ReadFromMailDetails(objEntityUsrRegistr);
                                DataTable dtUserDetails = new DataTable();
                                dtUserDetails = objBusinessLayerUserRegisteration.ReadUsrDetails(objEntityUsrRegistr);
                                string username = "";
                                string designation = "";
                                string corprtname = "";
                                if (dtUserDetails.Rows.Count > 0)
                                {
                                    username = dtUserDetails.Rows[0]["USR_NAME"].ToString();
                                    designation = dtUserDetails.Rows[0]["DSGN_NAME"].ToString();
                                    corprtname = dtUserDetails.Rows[0]["CORPRT_NAME"].ToString();
                                }
                                string content = "\nDear " + TxtFrstName.Text.ToUpper() + ",\n\nWelcome aboard our team! We are  pleased to have you working with COMPZIT. \nYou can use the following details to login into COMPZIT.\n\nEmail id : " + txtUsrEmail.Text + "\nLogin Name : " + txtLoginName.Text + "\nPassword : " + txtUsrPwd.Text + "\n\nNOTE : You can use either Email Id/ Login Name\n\n\n" + username + "\n" + designation + "\n" + corprtname + "";

                                if (dtFromMail.Rows.Count > 0)
                                {
                                    objEntityMail.To_Email_Address = txtUsrEmail.Text.Trim();
                                    objEntityMail.Email_Subject = "Compzit - Login Details";
                                    objEntityMail.Email_Content = content;
                                    objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                                    objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                                    objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                                    objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                                    objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
                                    objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();
                                    MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                                    List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                                    List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                                    try
                                    {
                                        objMail.SendMail(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);
                                    }
                                    catch
                                    {
                                        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                        {
                                            Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ipsd");
                                        }
                                        else if (clickedButton.ID == "btnAddClose")
                                        {
                                            Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ipsd");
                                        }
                                    }
                                    if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                    {
                                    }
                                    else if (clickedButton.ID == "btnAddClose")
                                    {
                                    }
                                }
                                else
                                {
                                    if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                    {
                                        Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=IpRMSsd");
                                    }
                                    else if (clickedButton.ID == "btnAddClose")
                                    {
                                        Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=IpRMSsd");
                                    }
                                }
                            }
                            else
                            {
                                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                {
                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                                }
                                else if (clickedButton.ID == "btnAddClose")
                                {
                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                }
                            }
                        }
                        else
                        {
                            if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                            {
                                Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                            }
                            else if (clickedButton.ID == "btnAddClose")
                            {
                                Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                            }
                        }
                    }
                    // when designation Control is Corporate
                    else if (hiddenDsgnContrl.Value == "C")
                    {
                        int count = 0;
                        if (rbtnCropDept.SelectedValue != "")
                        {
                            count++;
                        }
                        if (count > 0)
                        {
                            List<clsEntityLayerUserCorporate> objlisUsrCrprtDtls = new List<clsEntityLayerUserCorporate>();
                            foreach (ListItem item in cbxlCorporateOffc.Items)
                            {
                                if (item.Selected)
                                {
                                    clsEntityLayerUserCorporate objEntityUsrCrprt = new clsEntityLayerUserCorporate();
                                    objEntityUsrCrprt.UsrCrprtId = Convert.ToInt32(item.Value);
                                    if (Session["ORGID"] != null)
                                    {
                                        objEntityUsrCrprt.UsrOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Default.aspx");
                                    }
                                    objlisUsrCrprtDtls.Add(objEntityUsrCrprt);
                                }
                            }
                            HiddenUserCrprtDept.Value = "";
                            objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value.ToString());
                            objEntityUsrRegistr.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedValue);
                            HiddenUserCrprtDept.Value = rbtnCropDept.SelectedValue;//EVM-0024@
                            List<clsEntityLayerUserDivision> objlisUsrDivisionDtls = new List<clsEntityLayerUserDivision>();
                            int intDefultCorpId = 0;
                            foreach (ListItem item in cbxlCorporateDvsn.Items)
                            {
                                if (item.Selected)
                                {
                                    if (intDefultCorpId == 0)
                                    {
                                        intDefultCorpId = Convert.ToInt32(item.Value);
                                    }
                                    clsEntityLayerUserDivision objEntityUsrdivsn = new clsEntityLayerUserDivision();
                                    objEntityUsrdivsn.Divisn_Id = Convert.ToInt32(item.Value);
                                    objEntityUsrdivsn.DfltCrpDivisnId = intDefultCorpId;
                                    if (hiddenPrimaryDivision.Value == objEntityUsrdivsn.Divisn_Id.ToString())
                                    {
                                        objEntityUsrdivsn.PrimaryDivsnSts = 1;
                                    }
                                    else
                                    {
                                        objEntityUsrdivsn.PrimaryDivsnSts = 0;
                                    }


                                    if (Session["ORGID"] != null)
                                    {
                                        objEntityUsrdivsn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                    }
                                    else
                                    {
                                        Response.Redirect("~/Default.aspx");
                                    }
                                    objlisUsrDivisionDtls.Add(objEntityUsrdivsn);
                                }
                            }
                            if (ddlRepotingTo.SelectedItem.Value != "--Select Employee--")
                            {
                                objEntityUsrRegistr.EmployeeToReport = Convert.ToInt32(ddlRepotingTo.SelectedItem.Value);
                            }
                            else
                            {
                                objEntityUsrRegistr.EmployeeToReport = 0;
                            }
                            //0039
                            int intEmployeeID = 0;
                            if (lblEntry.Text != "Edit Employee")
                            {

                                intEmployeeID = objBusinessLayerUserRegisteration.InsertUserRegisterationDetail(objEntityUsrRegistr, objEntityAccsCorporateList, objlisUsrCrprtDtls, objlisUsrDivisionDtls, objlisUsrVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);

                            }
                            else if (lblEntry.Text == "Edit Employee")
                            {

                                //intEmployeeID = objBusinessLayerUserRegisteration.InsertUserRegisterationDetail(objEntityUsrRegistr, objEntityAccsCorporateList, objlisUsrCrprtDtls, objlisUsrDivisionDtls, objlisUsrVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);
                                intEmployeeID = Convert.ToInt32(HiddenEmpUserId.Value);

                            }
                            //end
                            //Start:-For job details insert

                            int intCorpId = 0;
                            int intOrgId = 0;
                            int IntUsrId = 0;
                            int intUsrRolMstrId;
                            int intEnableRenew = 0;
                            clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
                            clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
                            clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();
                            if (Session["CORPOFFICEID"] != null)
                            {
                                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                                objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                            }
                            if (Session["ORGID"] != null)
                            {
                                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                objEntityJobDetails.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                            }
                            else if (Session["ORGID"] == null)
                            {
                                Response.Redirect("~/Default.aspx");
                            }
                            if (Session["USERID"] != null)
                            {
                                objEntityJobDetails.UserId = Convert.ToInt32(Session["USERID"].ToString());
                                IntUsrId = Convert.ToInt32(Session["USERID"].ToString());
                            }
                            else
                            {
                                Response.Redirect("~/Default.aspx");
                            }
                            //EVM-0027
                            if (ddlProject.Text == "--SELECT PROJECT--")
                            {
                                objEntityJobDetails.Project = 0;

                            }
                            else
                            {
                                objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
                            }
                            if (ddlSponsor.Text == "--SELECT SPONSOR--")
                            {
                                objEntityJobDetails.Sponsorid = 0;

                            }
                            else
                            {
                                objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
                            }


                            //END

                            objEntityJobDetails.JoinedDate = objCommon.textToDateTime(txtJoineddate.Text);
                            if (txtpermanencyDate.Text == "")
                            {
                                objEntityJobDetails.PermamanencyDate = DateTime.Today;
                            }
                            else
                            {
                                objEntityJobDetails.PermamanencyDate = objCommon.textToDateTime(txtpermanencyDate.Text);
                            }
                            if (txtProbationdate.Text == "")
                            {
                                objEntityJobDetails.ProbationEnddate = DateTime.Today;
                            }
                            else
                            {

                                objEntityJobDetails.ProbationEnddate = objCommon.textToDateTime(txtProbationdate.Text);
                            }
                            if (TxtPeriod.Text == "")
                            {
                                objEntityJobDetails.Probation = 0;
                            }
                            else
                            {
                                objEntityJobDetails.Probation = int.Parse(TxtPeriod.Text);
                            }

                            if (ddlDepartment.Text == "--SELECT DEPARTMENT--")
                            {
                                objEntityJobDetails.Department_Id = 0;
                            }
                            else
                            {

                                objEntityJobDetails.Department_Id = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
                            }

                            objEntityJobDetails.Description = TxtJobDesc.Text;

                            objEntityJobDetails.Designation = 0;



                            if (ddlDivision.Text == "--SELECT DIVISION--")
                            {
                                objEntityJobDetails.Division = 0;
                            }
                            else
                            {

                                objEntityJobDetails.Division = Convert.ToInt32(ddlDivision.SelectedItem.Value);
                            };
                            objEntityJobDetails.EmployeeId = intEmployeeID;
                            //   objEntityJobDetails.EmployeeLocation = TxtLocation.Text; HiddenEmpId.Value
                            //EVM-0024
                            objEntityJobDetails.EmployeeType = HiddenEmpType.Value;
                            //END
                            // objEntityJobDetails.EmployeeType = ddlEmployeeType.SelectedItem.Text;
                            objEntityJobDetails.JobCancelREASON = Txtelgblestats.Text;
                            objEntityJobDetails.JobTitle = TxtjobTitle.Text;
                            objEntityJobDetails.JobUserDate = DateTime.Now;
                            //evm-0027
                            // objEntityJobDetails.Project = Convert.ToInt32(ddlProject.SelectedItem.Value);
                            //EVM-0027
                            objEntityJobDetails.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
                            DataTable dtDsgnMastr = objBusinessJobDetails.ReadDesignationType(objEntityJobDetails);
                            //objEntityJobDetails.JobType = ddtype.SelectedItem.Text;
                            if (dtDsgnMastr.Rows[0]["D_TYPE"].ToString() == "1")
                            {
                                objEntityJobDetails.JobType = "Labour";
                            }
                            else
                            {
                                objEntityJobDetails.JobType = "Staff";
                            }
                            //objEntityJobDetails.JobType = Convert.ToInt32(dtDsgnMastr.Rows[0]["D_TYPE"]); 
                            objEntityJobDetails.ProjectLocation = Txtprojloc.Text;
                            //EVM-0027
                            //   objEntityJobDetails.Sponsorid = Convert.ToInt32(ddlSponsor.SelectedItem.Value);
                            //END
                            clsEntityCommon objEntityCommon = new clsEntityCommon();
                            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EMPLOYEEJOB);
                            objEntityCommon.CorporateID = intCorpId;
                            objEntityCommon.Organisation_Id = intOrgId;
                            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                            objEntityJobDetails.Job_Id = Convert.ToInt32(strNextId);

                            objBusinessJobDetails.AddJobDetails(objEntityJobDetails);
                            Hiddenjobid.Value = strNextId;
                            BtnsaveJob.Visible = false;
                            BtnupdateJob.Visible = true;
                            Btnclrjob.Visible = true;
                            txtProbationdate.Enabled = false;
                            ddlPlusWeek.Enabled = false;//evm--0024
                            //Response.Redirect("gen_Emply_Personal_Informn.aspx?InsUpd=Ins");

                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Employee_Master);
                            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(IntUsrId, intUsrRolMstrId);
                            if (dtChildRol.Rows.Count > 0)
                            {
                                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                                foreach (string strC_Role in strChildDefArrWords)
                                {
                                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                                        intEnableRenew = 1;
                                }
                            }
                            if (intEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                divRenewImg.Visible = true;
                            }
                            else
                            {
                                divRenewImg.Visible = false;
                            }
                            InsUserLeaveTypes(intCorpId, intOrgId, objEntityJobDetails.EmployeeId, objEntityJobDetails.JoinedDate, 1);
                            //ScriptManager.RegisterStartupScript(this, GetType(), "JobSuccessConfirmation", "JobSuccessConfirmation();", true);

                            //End:-For job details insert





                            string strRandom = objCommon.Random_Number();
                            string strId = intEmployeeID.ToString();
                            int intIdLength = intEmployeeID.ToString().Length;
                            string stridLength = intIdLength.ToString("00");
                            string PassingId = stridLength + strId + strRandom;


                            //strores id in cand dtls                        
                            clsBusiness_Candidate_Login objBusiness_Candidate_Login = new clsBusiness_Candidate_Login();
                            clsEntityCandidatelogin objEntityCandidatelogin = new clsEntityCandidatelogin();
                            if (Request.QueryString["CANDID"] != null)
                            {
                                ////emp0021//////
                                string strRandomMixedId = Request.QueryString["CANDID"].ToString();
                                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                                string strId2 = strRandomMixedId.Substring(2, intLenghtofId);
                                objEntityCandidatelogin.CandidateId = Convert.ToInt32(strId2);
                                objEntityCandidatelogin.EmployeeId = intEmployeeID;
                                objBusiness_Candidate_Login.UpdateCandidatesId(objEntityCandidatelogin);
                            }
                            string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                            if (FileUploadProPic.HasFile)
                            {
                                FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityUsrRegistr.ImagePath);
                            }
                            string strLicenseCopyPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                            if (FileUploadLicenseCopy.HasFile)
                            {
                                FileUploadLicenseCopy.SaveAs(Server.MapPath(strLicenseCopyPath) + objEntityUsrRegistr.LicenseCopyPath);
                            }
                            if (divLoginDetailsSection.Style["display"] != "none")
                            {
                                if (cbxMustLogin.Checked == true)
                                {
                                    //005 start
                                    if (Session["CORPOFFICEID"] != null)
                                    {
                                        objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"]);
                                    }
                                    else if (Session["CORPOFFICEID"] == null)
                                    {
                                        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                        {
                                            Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                                        }
                                        else if (clickedButton.ID == "btnAddClose")
                                        {
                                            Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                        }
                                    }
                                    List<clsEntityMailAttachment> objEntityMailAttachList = new List<clsEntityMailAttachment>();
                                    clsBusinessLayer objBussinessLayer = new clsBusinessLayer();
                                    clsEntityMailConsole objEntityMail = new clsEntityMailConsole();
                                    MailMessage mail = new MailMessage();
                                    DataTable dtFromMail = objBussinessLayer.ReadFromMailDetails(objEntityUsrRegistr);
                                    DataTable dtUserDetails = new DataTable();
                                    dtUserDetails = objBusinessLayerUserRegisteration.ReadUsrDetails(objEntityUsrRegistr);
                                    string username = "";
                                    string designation = "";
                                    string corprtname = "";
                                    if (dtUserDetails.Rows.Count > 0)
                                    {
                                        username = dtUserDetails.Rows[0]["USR_NAME"].ToString();
                                        designation = dtUserDetails.Rows[0]["DSGN_NAME"].ToString();
                                        corprtname = dtUserDetails.Rows[0]["CORPRT_NAME"].ToString();
                                    }
                                    string content = "\nDear " + TxtFrstName.Text.ToUpper() + ",\n\nWelcome aboard our team! We are  pleased to have you working with COMPZIT. \nYou can use the following details to login into COMPZIT.\n\nEmail id : " + txtUsrEmail.Text + "\nLogin Name : " + txtLoginName.Text + "\nPassword : " + txtUsrPwd.Text + "\n\nNOTE : You can use either Email Id/ Login Name\n\n\n" + username + "\n" + designation + "\n" + corprtname + "";

                                    if (dtFromMail.Rows.Count > 0)
                                    {
                                        objEntityMail.To_Email_Address = txtUsrEmail.Text.Trim();
                                        objEntityMail.Email_Subject = "Compzit - Login Details";
                                        objEntityMail.Email_Content = content;
                                        objEntityMail.From_Email_Address = dtFromMail.Rows[0]["MLCNFG_EMAIL"].ToString();
                                        objEntityMail.Out_Service_Name = dtFromMail.Rows[0]["MLCNFG_OUT_SERVICE_NAME"].ToString();
                                        objEntityMail.Out_Port_Number = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_OUT_PORT_NUMBER"]);
                                        objEntityMail.SSL_Status = Convert.ToInt32(dtFromMail.Rows[0]["MLCNFG_SSL_STATUS"]);
                                        objEntityMail.Password = dtFromMail.Rows[0]["MLCNFG_PASSWORD"].ToString();
                                        objEntityMail.Signature = dtFromMail.Rows[0]["MLCNFG_SIGNATURE"].ToString();
                                        MailUtility_ERP.clsMail objMail = new MailUtility_ERP.clsMail();
                                        List<clsEntityMailCcBCc> objEntityMailCcBCcList = new List<clsEntityMailCcBCc>();
                                        List<classEntityToMailAddress> objEntityToMailAddressList = new List<classEntityToMailAddress>();
                                        try
                                        {
                                            objMail.SendMail(objEntityMail, objEntityMailAttachList, objEntityMailCcBCcList, objEntityToMailAddressList);

                                            //emp-20
                                            if (hiddenWorkerId.Value == "")
                                            {
                                                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                                {
                                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                                                }
                                                else if (clickedButton.ID == "btnAddClose")
                                                {
                                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                                }
                                            }
                                            else
                                            {
                                                string strRandomMixedWorkerId = hiddenWorkerId.Value;

                                                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                                {
                                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&WORKERID=" + strRandomMixedWorkerId + "&InsUpd=Ins");
                                                }
                                                else if (clickedButton.ID == "btnAddClose")
                                                {
                                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                                }
                                            }
                                        }
                                        catch
                                        {
                                            //emp-20
                                            if (hiddenWorkerId.Value == "")
                                            {
                                                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                                {
                                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ipsd");
                                                }
                                                else if (clickedButton.ID == "btnAddClose")
                                                {
                                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ipsd");
                                                }
                                            }
                                            else
                                            {
                                                string strRandomMixedWorkerId = hiddenWorkerId.Value;

                                                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                                {
                                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&WORKERID=" + strRandomMixedWorkerId + "&InsUpd=Ins");
                                                }
                                                else if (clickedButton.ID == "btnAddClose")
                                                {
                                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                        {
                                            Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=IpRMSsd");
                                        }
                                        else if (clickedButton.ID == "btnAddClose")
                                        {
                                            Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=IpRMSsd");
                                        }
                                    }
                                }
                                else
                                {
                                    //evm-20
                                    if (hiddenWorkerId.Value == "")
                                    {
                                        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                        {
                                            Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                                        }
                                        else if (clickedButton.ID == "btnAddClose")
                                        {
                                            Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                        }
                                    }
                                    else
                                    {
                                        string strRandomMixedWorkerId = hiddenWorkerId.Value;

                                        if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                        {
                                            Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&WORKERID=" + strRandomMixedWorkerId + "&InsUpd=Ins");
                                        }
                                        else if (clickedButton.ID == "btnAddClose")
                                        {
                                            Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "BtnsaveJob")
                                {
                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + PassingId + "&InsUpd=Ins");
                                }
                                else if (clickedButton.ID == "btnAddClose")
                                {
                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Ins");
                                }
                            }
                        }
                        else
                        {
                            btnAdd.Enabled = true;
                            btnAddClose.Enabled = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessDep", "SuccessDep();", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmployeeCode", "DuplicationEmployeeCode();", true);
                    txtEmployeeCode.Focus();
                }
            }
            else
            {
                btnAdd.Enabled = true;
                btnAddClose.Enabled = true;
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtLoginName.Focus();
            }
        }
        else
        {
            btnAdd.Enabled = true;
            btnAddClose.Enabled = true;
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
            txtUsrEmail.Focus();
        }
        btnCancelCan.Visible = false;
        btnCancel.Visible = true;
    }

    public class clsWBData //EMP0025
    {
        public string EmpId { get; set; }
        public string WelfareId { get; set; }
        public string limit { get; set; }
        public string WelfareSubId { get; set; }
        public string ActLimt { get; set; }
        public string chkSts { get; set; }
        public string CheckboxSts { get; set; }
    }
    private List<clsEntityLayerEmployeeRole> Merge(List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls, List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls)
    {
        List<clsEntityLayerEmployeeRole> objlisDsgnRol = null;
        objlisDsgnRol = new List<clsEntityLayerEmployeeRole>();
        foreach (clsEntityLayerEmployeeRole objDsgnRolMainDtls in objlisDsgnRolMainDtls)
        {
            string strchild = "";
            foreach (clsEntityLayerEmployeeRole objDsgnRolChildrenDtls in objlisDsgnRolChildrenDtls)
            {
                if (objDsgnRolMainDtls.UsrRolId == objDsgnRolChildrenDtls.UsrRolId)
                {
                    if (strchild != "")
                    {
                        strchild = strchild + "-" + objDsgnRolChildrenDtls.strChildRolId;
                    }
                    else
                    {
                        strchild = objDsgnRolChildrenDtls.strChildRolId;
                    }
                }
            }
            objDsgnRolMainDtls.strChildRolId = strchild;
        }
        return objlisDsgnRolMainDtls;
    }
    // when updation button is clicked
    protected void btnUpdate_ClickUsrRegistr(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityUsrRegistr.UserEmail = txtUsrEmail.Text;
        objEntityUsrRegistr.OffclEmail = txtOfflMail.Text.Trim();
        if (divLoginDetailsSection.Style["display"] != "none")
        {
            if (cbxMustLogin.Checked == true)
            {
                objEntityUsrRegistr.LoginName = txtLoginName.Text.Trim();
            }
        }


        string strRandomMixedId = Request.QueryString["Id"].ToString();
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(strId);
        objEntityUsrRegistr.UsrType = Convert.ToInt32(ddlStafftype.SelectedItem.Value);
        // objEntityUsrRegistr.UsrType = Convert.ToInt32(Hiddenusermode.Value);


        string strNameCount = "0";//emp00025
        if (txtEmployeeCode.Text != "" && txtEmployeeCode.Text != null)
        {
            objEntityUsrRegistr.UserCode = txtEmployeeCode.Text.ToUpper().Trim();
            strNameCount = objBusinessLayerUserRegisteration.CheckEmployeeCode(objEntityUsrRegistr);
            // strNameCount
            //0039
            strNameCount = "0";
            //end
        }

        string strEmailCount = "0";
        if (objEntityUsrRegistr.UserEmail != "")//EMAIL CAN BE NULL SO THIS CHECKING
        {
            strEmailCount = objBusinessLayerUserRegisteration.CheckDupUserEmailUpd(objEntityUsrRegistr);
            //0039
            strEmailCount = "0";
            //end
        }

        //DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUsrRegistr);//EMP0025
        //List<clsEntityLayerEmployeeWelfareSrvc> objListEmpWelfare = new List<clsEntityLayerEmployeeWelfareSrvc>();


        //string jsonData = Hiddenchecklist.Value;
        //string c = jsonData.Replace("\"{", "\\{");
        //string d = c.Replace("\\n", "\r\n");
        //string g = d.Replace("\\", "");
        //string h = g.Replace("}\"]", "}]");
        //string k = h.Replace("}\",", "},");
        //List<clsWBData> objWBDataList = new List<clsWBData>();
        //objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
        //foreach (clsWBData objclsWBData in objWBDataList)
        //{
        //    clsEntityLayerEmployeeWelfareSrvc objEmp = new clsEntityLayerEmployeeWelfareSrvc();

        //    objEmp.Emp_Id = Convert.ToInt32(objclsWBData.EmpId);
        //    objEmp.Welfare_Id = Convert.ToInt32(objclsWBData.WelfareId);
        //    objEmp.Qty = Convert.ToDecimal(objclsWBData.limit);
        //    objListEmpWelfare.Add(objEmp);
        //}

        if (strEmailCount == "0")
        {
            string strLNameCount = "0";
            if (objEntityUsrRegistr.LoginName != "")//LOGIN NAME CAN BE NULL SO THIS CHECKING
            {
                strLNameCount = objBusinessLayerUserRegisteration.CheckDupUserLoginName(objEntityUsrRegistr);
                //0039
                strLNameCount = "0";
                //end
            }

            if (strLNameCount == "0")
            {

                if (strNameCount == "0")
                {

                    List<clsEntityLayerUserVhclType> objlisUsrVhclLicTypDtls = new List<clsEntityLayerUserVhclType>();
                    objEntityUsrRegistr.UserName = TxtFrstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.Fname = TxtFrstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.Mname = TxtMidleName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.Lname = TxtLstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.CountryID = Convert.ToInt32(ddlNationality.SelectedItem.Value);
                    objEntityUsrRegistr.UserName = TxtFrstName.Text.ToUpper().Trim();
                    objEntityUsrRegistr.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
                    objEntityUsrRegistr.UserRoleId = Convert.ToInt32(ddlJobRole.SelectedItem.Value.ToString());
                    ///   objEntityUsrRegistr.JoiningDate = objCommon.textToDateTime(txtJoiningDate.Text.Trim());
                    objEntityUsrRegistr.EmployeeTypId = Convert.ToInt32(ddlEmpType.SelectedItem.Value.ToString());
                    objEntityUsrRegistr.NationalIdNumber = txtNationalIdNmbr.Text.Trim();
                    objEntityUsrRegistr.UserMobile = txtUsrMob.Text.Trim();
                    if (RadioButtonMale.Checked)
                    {
                        objEntityUsrRegistr.Gender = 0;
                    }
                    else if (RadioButtonFemale.Checked)
                    {
                        objEntityUsrRegistr.Gender = 1;
                    }
                    else if (RadioButtonOther.Checked)
                    {
                        objEntityUsrRegistr.Gender = 2;
                    }
                    if (Session["USERID"] != null)
                    {
                        objEntityUsrRegistr.UserId = Convert.ToInt32(Session["USERID"].ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    objEntityUsrRegistr.UserDate = System.DateTime.Now;
                    if (cbxStatus.Checked)
                    {
                        objEntityUsrRegistr.UserStatus = 1;
                    }
                    else
                    {
                        objEntityUsrRegistr.UserStatus = 0;
                    }
                    if (cbxMailSendStatus.Checked)
                    {
                        objEntityUsrRegistr.MailSendSts = 1;
                    }
                    else
                    {
                        objEntityUsrRegistr.MailSendSts = 0;
                    }
                    if (cbxReadMail.Checked)
                    {
                        objEntityUsrRegistr.MailReadSts = 1;
                    }
                    else
                    {
                        objEntityUsrRegistr.MailReadSts = 0;
                    }
                    if (divLoginDetailsSection.Style["display"] != "none")
                    {
                        if (cbxMustLogin.Checked == true)
                        {
                            if (divPassword.Visible == true)
                            {
                                objEntityUsrRegistr.UserPsw = txtUsrPwd.Text.Trim();
                            }
                            objEntityUsrRegistr.LoginMust = true;
                            if (cbxLimitedUser.Checked)
                            {
                                objEntityUsrRegistr.LimitedUser = 1;
                            }
                            else
                            {
                                objEntityUsrRegistr.LimitedUser = 2;
                            }
                            if (cbxPswExpiry.Checked)
                            {
                                objEntityUsrRegistr.PasswordExpiry = 1;
                            }
                            else
                            {
                                objEntityUsrRegistr.PasswordExpiry = 2;
                            }
                        }
                    }
                    if (divAutoWorkshopSection.Style["display"] != "none")
                    {
                        if (cbxMustAutoWorkshop.Checked == true)
                        {
                            objEntityUsrRegistr.AutoWrkShopMust = true;
                            objEntityUsrRegistr.LicenseNumber = txtLicenceNumbr.Text.Trim();
                            objEntityUsrRegistr.LicenseExpiryDate = objCommon.textToDateTime(txtLicenseExpDate.Text.Trim());
                            if (cbxDutyRoster.Checked)
                            {
                                objEntityUsrRegistr.AllowDutyRoster = 1;
                            }
                            else
                            {
                                objEntityUsrRegistr.AllowDutyRoster = 0;
                            }
                            if (hiddenLicenseTypeId.Value != "")
                            {
                                string strLicTypList = hiddenLicenseTypeId.Value;
                                // Split string on spaces.
                                // ... This will separate all the words.
                                string[] strArrLicenseTypes = strLicTypList.Split(',');
                                foreach (string strLicTyp in strArrLicenseTypes)
                                {
                                    if (strLicTyp != "")
                                    {
                                        clsEntityLayerUserVhclType objEntityUsrVhclType = new clsEntityLayerUserVhclType();
                                        objEntityUsrVhclType.LicTypeId = Convert.ToInt32(strLicTyp);
                                        objlisUsrVhclLicTypDtls.Add(objEntityUsrVhclType);
                                    }
                                }
                            }
                        }
                    }
                    if (FileUploadProPic.HasFile)
                    {
                        // GET FILE EXTENSION
                        string strFileExt;
                        strFileExt = FileUploadProPic.FileName.Substring(FileUploadProPic.FileName.LastIndexOf('.') + 1).ToLower();
                        int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.USER_MASTER);
                        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                        string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityUsrRegistr.UsrRegistrationId.ToString() + "." + strFileExt;
                        objEntityUsrRegistr.ImagePath = strImageName;
                        //    if (hiddenUserImage.Value != "")
                        //    {
                        string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                        string imageLocation = strImgPath + strImageName;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                        //    }
                    }
                    else
                    {
                        if (hiddenUserImage.Value != "")
                        {
                            objEntityUsrRegistr.ImagePath = hiddenUserImage.Value;
                        }
                        else
                        {
                            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                            string imageLocation = strImgPath + hiddenImageName.Value;
                            if (File.Exists(MapPath(imageLocation)))
                            {
                                File.Delete(MapPath(imageLocation));
                            }
                            objEntityUsrRegistr.ImagePath = null;
                            //  lblMessage.Text = "Please select image file.";
                        }
                    }
                    if (divAutoWorkshopSection.Style["display"] != "none")
                    {
                        if (cbxMustAutoWorkshop.Checked == true)
                        {
                            //FOR LICENSE COPY
                            if (FileUploadLicenseCopy.HasFile)
                            {
                                // GET FILE EXTENSION
                                string strFileExt;
                                strFileExt = FileUploadLicenseCopy.FileName.Substring(FileUploadLicenseCopy.FileName.LastIndexOf('.') + 1).ToLower();
                                int intAppModSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.Section.USER_MASTER);
                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + objEntityUsrRegistr.UsrRegistrationId.ToString() + "." + strFileExt;
                                objEntityUsrRegistr.LicenseCopyPath = strImageName;
                                string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                                string imageLocation = strImgPath + hiddenLicenseCopyName.Value;
                                if (File.Exists(MapPath(imageLocation)))
                                {
                                    File.Delete(MapPath(imageLocation));
                                }
                            }
                            else
                            {
                                if (hiddenUserLicenseCopy.Value != "")
                                {
                                    objEntityUsrRegistr.LicenseCopyPath = hiddenUserLicenseCopy.Value;
                                }
                                else
                                {
                                    string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                                    string imageLocation = strImgPath + hiddenLicenseCopyName.Value;
                                    if (File.Exists(MapPath(imageLocation)))
                                    {
                                        File.Delete(MapPath(imageLocation));
                                    }
                                    objEntityUsrRegistr.LicenseCopyPath = null;
                                    //  lblMessage.Text = "Please select image file.";
                                }
                            }
                        }
                    }
                    List<clsEntityLayerUserCorporate> objEntityAccsCorporateList = new List<clsEntityLayerUserCorporate>();
                    foreach (ListItem item in cbxListAccsBU.Items)
                    {
                        if (item.Selected)
                        {
                            clsEntityLayerUserCorporate objEntityAccsCorporate = new clsEntityLayerUserCorporate();
                            objEntityAccsCorporate.UsrCrprtId = Convert.ToInt32(item.Value);
                            objEntityAccsCorporateList.Add(objEntityAccsCorporate);
                        }
                    }
                    ///////////////////////////////////
                    //for sub business unit section 0013
                    List<clsEntityLayerUserSubBusness> objlisUserSubBusnessDtls = new List<clsEntityLayerUserSubBusness>();
                    int intDefultCorpId = 0;
                    foreach (ListItem item in cbxBussiness.Items)
                    {
                        if (item.Selected)
                        {
                            if (intDefultCorpId == 0)
                            {
                                intDefultCorpId = Convert.ToInt32(item.Value);
                            }
                            clsEntityLayerUserSubBusness objEntityUsrSubBus = new clsEntityLayerUserSubBusness();
                            objEntityUsrSubBus.SubBusUntId = Convert.ToInt32(item.Value);
                            objEntityUsrSubBus.DfltSubBusUntId = intDefultCorpId;
                            if (Session["ORGID"] != null)
                            {
                                objEntityUsrSubBus.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                            }
                            else
                            {
                                Response.Redirect("~/Default.aspx");
                            }
                            objlisUserSubBusnessDtls.Add(objEntityUsrSubBus);
                        }
                    }
                    //////
                    //0013 END
                    //start-inserting jobroles userroles
                    int intTreeAppAdminVisible = 0, intTreeSFAVisible = 0, intTreeAWMSVisible = 0, intTreeGMSVisible = 0, intTreeHCMVisible = 0, intTreeFMSVisible = 0, intTreePMSVisible = 0;
                    List<clsEntityLayerEmployeeAppRole> objlisJobRlAppRol = new List<clsEntityLayerEmployeeAppRole>();
                    foreach (ListItem itemCheckBoxModules in cbxlCompzitModules.Items)
                    {
                        if (itemCheckBoxModules.Selected)
                        {
                            clsEntityLayerEmployeeAppRole objEmpRlAppRol = new clsEntityLayerEmployeeAppRole();
                            // If the item is selected.
                            if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.APP_ADMINSTRATION))
                            {
                                intTreeAppAdminVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.SALES_FORCE_AUTOMATION))
                            {
                                intTreeSFAVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM))
                            {
                                intTreeAWMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.GUARANTEE_MANAGEMENT_SYSTEM))
                            {
                                intTreeGMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.HUMAN_CAPITAL_MANAGEMENT))
                            {
                                intTreeHCMVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.FINANCE_MANAGEMENT_SYSTEM))
                            {
                                intTreeFMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }
                            else if (Convert.ToInt32(itemCheckBoxModules.Value) == Convert.ToInt32(APPS.PROCUREMENT_MANAGEMENT_SYSTEM))
                            {
                                intTreePMSVisible = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                            }

                            objEmpRlAppRol.App_Id = Convert.ToInt32(itemCheckBoxModules.Value);
                            objlisJobRlAppRol.Add(objEmpRlAppRol);
                        }
                    }
                    List<clsEntityLayerEmployeeRole> objlisDsgnRol = new List<clsEntityLayerEmployeeRole>();
                    if (intTreeAppAdminVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_AppAdmin = TreeViewCompzit_AppAdminstration.CheckedNodes;
                        if (objNodeCollection_COMPZIT_AppAdmin.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_AppAdmin = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_AppAdmin = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_Online in objNodeCollection_COMPZIT_AppAdmin)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();

                                string[] strchild = objTreeNode_Online.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_AppAdmin.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_AppAdmin.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolAppAdministration = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolAppAdministration = Merge(objlisDsgnRolMainDtls_AppAdmin, objlisDsgnRolChildrenDtls_AppAdmin);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolAppAdministration)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeSFAVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_SalesAutmtn = TreeViewCompzit_SalesAutomation.CheckedNodes;
                        if (objNodeCollection_COMPZIT_SalesAutmtn.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_SFA = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_SFA = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_SFA in objNodeCollection_COMPZIT_SalesAutmtn)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_SFA.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_SFA.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_SFA.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolSFA = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolSFA = Merge(objlisDsgnRolMainDtls_SFA, objlisDsgnRolChildrenDtls_SFA);
                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolSFA)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeAWMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_WorkshopMngmnt = TreeViewCompzit_AutoWorkshopManagement.CheckedNodes;
                        if (objNodeCollection_COMPZIT_WorkshopMngmnt.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_WMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_WMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_WMS in objNodeCollection_COMPZIT_WorkshopMngmnt)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_WMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_WMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_WMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_WMS, objlisDsgnRolChildrenDtls_WMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeGMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_GuaranteeManagement = TreeViewCompzit_GuaranteeManagement.CheckedNodes;
                        if (objNodeCollection_COMPZIT_GuaranteeManagement.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_GMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_GMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_GMS in objNodeCollection_COMPZIT_GuaranteeManagement)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_GMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_GMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_GMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_GMS, objlisDsgnRolChildrenDtls_GMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeHCMVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_HumanCapitalManagement = TreeViewCompzit_HumanCapitalManagement.CheckedNodes;
                        if (objNodeCollection_COMPZIT_HumanCapitalManagement.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_HCM = null;
                            objlisDsgnRolMainDtls_HCM = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_HCM = null;
                            objlisDsgnRolChildrenDtls_HCM = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_WMS in objNodeCollection_COMPZIT_HumanCapitalManagement)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_WMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_HCM.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_HCM.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = null;
                            objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_HCM, objlisDsgnRolChildrenDtls_HCM);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreeFMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_FinanceManagementSystem = TreeViewCompzit_FinanceManagementSystem.CheckedNodes;
                        if (objNodeCollection_COMPZIT_FinanceManagementSystem.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_FMS = null;
                            objlisDsgnRolMainDtls_FMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_FMS = null;
                            objlisDsgnRolChildrenDtls_FMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_WMS in objNodeCollection_COMPZIT_FinanceManagementSystem)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_WMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_FMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_FMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = null;
                            objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_FMS, objlisDsgnRolChildrenDtls_FMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }
                    if (intTreePMSVisible == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))//PMS
                    {
                        TreeNodeCollection objNodeCollection_COMPZIT_ProcurementManagementSystem = TreeViewCompzit_ProcurementManagementSystem.CheckedNodes;
                        if (objNodeCollection_COMPZIT_ProcurementManagementSystem.Count > 0)
                        {
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolMainDtls_PMS = null;
                            objlisDsgnRolMainDtls_PMS = new List<clsEntityLayerEmployeeRole>();
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolChildrenDtls_PMS = null;
                            objlisDsgnRolChildrenDtls_PMS = new List<clsEntityLayerEmployeeRole>();
                            foreach (TreeNode objTreeNode_PMS in objNodeCollection_COMPZIT_ProcurementManagementSystem)
                            {
                                clsEntityLayerEmployeeRole objEntityDsgnRole = null;
                                objEntityDsgnRole = new clsEntityLayerEmployeeRole();
                                string[] strchild = objTreeNode_PMS.Value.Split('.');
                                if ((strchild.Length - 1) > 0)
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objEntityDsgnRole.strChildRolId = strchild[1];
                                    objlisDsgnRolChildrenDtls_PMS.Add(objEntityDsgnRole);
                                }
                                else
                                {
                                    objEntityDsgnRole.UsrRolId = Convert.ToInt32(strchild[0]);
                                    objlisDsgnRolMainDtls_PMS.Add(objEntityDsgnRole);
                                }
                            }
                            List<clsEntityLayerEmployeeRole> objlisDsgnRolWMS = null;
                            objlisDsgnRolWMS = new List<clsEntityLayerEmployeeRole>();
                            objlisDsgnRolWMS = Merge(objlisDsgnRolMainDtls_PMS, objlisDsgnRolChildrenDtls_PMS);

                            foreach (clsEntityLayerEmployeeRole objDsgnRol in objlisDsgnRolWMS)
                            {
                                objlisDsgnRol.Add(objDsgnRol);
                            }
                        }
                    }


                    //stop-inserting jobroles userroles
                    // when designation Control is Organisation
                    if (hiddenDsgnContrl.Value == "O")
                    {
                        List<clsEntityLayerUserCorporate> objlisUsrCrprtDtls = null;
                        objlisUsrCrprtDtls = new List<clsEntityLayerUserCorporate>();
                        foreach (ListItem item in cbxlCorporateOffc.Items)
                        {
                            if (item.Selected)
                            {
                                clsEntityLayerUserCorporate objEntityUsrCrprt = new clsEntityLayerUserCorporate();
                                objEntityUsrCrprt.UsrCrprtId = Convert.ToInt32(item.Value);
                                int corpid = Convert.ToInt32(item.Value);
                                if (Session["ORGID"] != null)
                                {
                                    objEntityUsrCrprt.UsrOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                }
                                else
                                {
                                    Response.Redirect("~/Default.aspx");
                                }
                                objlisUsrCrprtDtls.Add(objEntityUsrCrprt);
                                BankLoad(strId, corpid);
                            }
                        }
                        if (hiddenBankDtls.Value != "")
                        {
                            ddlBank.Items.FindByValue(hiddenBankDtls.Value).Selected = true;
                        }

                        if (ddlRepotingTo.SelectedItem.Value != "--Select Employee--")  //EMP25
                        {
                            objEntityUsrRegistr.EmployeeToReport = Convert.ToInt32(ddlRepotingTo.SelectedItem.Value);
                        }
                        else
                        {
                            objEntityUsrRegistr.EmployeeToReport = 0;
                        }
                        objBusinessLayerUserRegisteration.UpdateUserRegisterationDetail(objEntityUsrRegistr, objEntityAccsCorporateList, objlisUsrCrprtDtls, null, objlisUsrVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);
                        //FOR SAVING DOCUMENTS
                        string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                        if (FileUploadProPic.HasFile)
                        {
                            FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityUsrRegistr.ImagePath);
                        }
                        if (divAutoWorkshopSection.Style["display"] != "none")
                        {
                            if (cbxMustAutoWorkshop.Checked == true)
                            {
                                string strLicenseCopyPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                                if (FileUploadLicenseCopy.HasFile)
                                {
                                    FileUploadLicenseCopy.SaveAs(Server.MapPath(strLicenseCopyPath) + objEntityUsrRegistr.LicenseCopyPath);
                                }
                            }
                        }
                        cbxStatus.Checked = true;
                        cbxMailSendStatus.Checked = false;
                        if (clickedButton.ID == "btnUpdate")
                        {
                            Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + strRandomMixedId + "&InsUpd=Ipsd");
                            // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                        }
                        else if (clickedButton.ID == "btnUpdateClose")
                        {
                            Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Upd");
                        }
                    }
                    // when designation Control is Corporate
                    else if (hiddenDsgnContrl.Value == "C")
                    {
                        if (ddlUsrCorporate.SelectedItem.Text.ToString() != "--SELECT--")
                        {
                            if (rbtnCropDept.SelectedIndex > -1)
                            {
                                objEntityUsrRegistr.UserCrprtId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value.ToString());
                                objEntityUsrRegistr.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedItem.Value.ToString());
                                int intDefaultCorpId = 0;
                                List<clsEntityLayerUserDivision> objlisUsrDivisionDtls = new List<clsEntityLayerUserDivision>();
                                foreach (ListItem item in cbxlCorporateDvsn.Items)
                                {
                                    if (item.Selected)
                                    {
                                        if (intDefaultCorpId == 0)
                                        {
                                            intDefaultCorpId = Convert.ToInt32(item.Value);
                                        }
                                        clsEntityLayerUserDivision objEntityUsrdivsn = new clsEntityLayerUserDivision();
                                        objEntityUsrdivsn.Divisn_Id = Convert.ToInt32(item.Value);
                                        objEntityUsrdivsn.DfltCrpDivisnId = intDefaultCorpId;
                                        //EVM-0027
                                        if (hiddenPrimaryDivision.Value == objEntityUsrdivsn.Divisn_Id.ToString())
                                        {
                                            objEntityUsrdivsn.PrimaryDivsnSts = 1;
                                        }
                                        else
                                        {
                                            objEntityUsrdivsn.PrimaryDivsnSts = 0;
                                        }
                                        //END

                                        if (Session["ORGID"] != null)
                                        {
                                            objEntityUsrdivsn.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                        }
                                        else
                                        {
                                            Response.Redirect("~/Default.aspx");
                                        }
                                        objlisUsrDivisionDtls.Add(objEntityUsrdivsn);
                                    }
                                }
                                if (ddlRepotingTo.SelectedItem.Value != "--Select Employee--")  //EMP25
                                {
                                    objEntityUsrRegistr.EmployeeToReport = Convert.ToInt32(ddlRepotingTo.SelectedItem.Value);
                                }
                                else
                                {
                                    objEntityUsrRegistr.EmployeeToReport = 0;
                                }
                                objBusinessLayerUserRegisteration.UpdateUserRegisterationDetail(objEntityUsrRegistr, objEntityAccsCorporateList, null, objlisUsrDivisionDtls, objlisUsrVhclLicTypDtls, objlisUserSubBusnessDtls, objlisDsgnRol, objlisJobRlAppRol);
                                //FOR SAVING DOCUMENTS
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC);
                                if (FileUploadProPic.HasFile)
                                {
                                    FileUploadProPic.SaveAs(Server.MapPath(strImagePath) + objEntityUsrRegistr.ImagePath);
                                }
                                if (divAutoWorkshopSection.Style["display"] != "none")
                                {
                                    if (cbxMustAutoWorkshop.Checked == true)
                                    {
                                        string strLicenseCopyPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_LICENSECOPY);
                                        if (FileUploadLicenseCopy.HasFile)
                                        {
                                            FileUploadLicenseCopy.SaveAs(Server.MapPath(strLicenseCopyPath) + objEntityUsrRegistr.LicenseCopyPath);
                                        }
                                    }
                                }
                                TxtFrstName.Focus();
                                cbxStatus.Checked = true;
                                cbxMailSendStatus.Checked = false;
                                if (clickedButton.ID == "btnUpdate") //emp0025
                                {
                                    Response.Redirect("gen_Emply_Personal_Informn.aspx?id=" + strRandomMixedId + "&InsUpd=Ipsd");
                                    // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                                }
                                else if (clickedButton.ID == "btnUpdateClose")
                                {
                                    Response.Redirect("gen_Emp_Personal_Info_List.aspx?InsUpd=Upd");
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "EmptyDepartment", "EmptyDepartment();", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "EmptyCorporate", "EmptyCorporate();", true);
                            ddlUsrCorporate.Focus();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmployeeCode", "DuplicationEmployeeCode();", true);
                    txtEmployeeCode.Focus();
                }
                //EVM-0024
                //else
                //{

                //    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmpCode", "DuplicationEmpCode();", true);
                //    txtEmployeeCode.Focus();
                //}
            }

            else
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtLoginName.Focus();
            }


        }
        else
        {

            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationEmail", "DuplicationEmail();", true);
            txtUsrEmail.Focus();
        }
    }

    //when we select designation from dropdown
    protected void ddlUsrDsgn_SelectedIndexChanged(object sender, EventArgs e)
    {

        hiddenConfirmValue.Value = "IncrmntConfrmCounter";
        DesignationSelectIndexChange(1);
        divDept.Visible = true;
        bussiDiv.Visible = true;
        BindSubBusUnt();
        ddlJobRole.Items.Clear();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (ddlUsrDsgn.SelectedItem.Value != "--SELECT--")
        {
            int desig = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
            objEntityUsrRegistr.UserDsgnId = desig;
            DataTable dtJobRol = new DataTable();
            DataTable dtStaffWorker = new DataTable();
            dtStaffWorker = objBusinessLayerUserRegisteration.ReadStaffWorkerBiDesgId(objEntityUsrRegistr);
            if (dtStaffWorker.Rows.Count > 0)
            {
                Hiddenusermode.Value = dtStaffWorker.Rows[0]["D_TYPE"].ToString();
            }

            dtJobRol = objBusinessLayerUserRegisteration.ReadJobRol(objEntityUsrRegistr);

            if (dtJobRol.Rows.Count > 0)
            {
                for (int intcount = 0; intcount < dtJobRol.Rows.Count; intcount++)
                {
                    ddlJobRole.DataSource = dtJobRol;
                    ddlJobRole.DataTextField = "JOBRL_NAME";
                    ddlJobRole.DataValueField = "JOBRL_ID";
                    ddlJobRole.DataBind();

                }
                //ddlJobRole.Focus();
            }
            ddlJobRole.Items.Insert(0, "--Select Job Role--");

            clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();  //emp0025
            objEntityUserReg.UserId = Convert.ToInt32(HiddenEmployeeId.Value);
            string uid = Convert.ToString(objEntityUserReg.UserId);
            objEntityUserReg.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
            objEntityUserReg.UserDvsnId = " 0";
            DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUserReg);
            string count = dtWelfareScvc.Rows.Count.ToString();
            //DataTable dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityUserReg);
            DataTable dtWelfar = new DataTable();
            dtWelfar = null;
            if (dtWelfareScvc.Rows.Count > 0)
            {

                string strHtmmm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar, count, uid);
                //Write to divReport
                divReport1.InnerHtml = strHtmmm;

                divwelfareSrevc.Attributes["style"] = "display:block;";
            }
            else
            {
                divwelfareSrevc.Attributes["style"] = "display:none;";
            }

        }
        else
        {
            BindCompzitModules();
            TreeViewCompzit_AppAdminstration.Nodes.Clear();
            TreeViewCompzit_SalesAutomation.Nodes.Clear();
            TreeViewCompzit_AutoWorkshopManagement.Nodes.Clear();
            TreeViewCompzit_GuaranteeManagement.Nodes.Clear();
            TreeViewCompzit_HumanCapitalManagement.Nodes.Clear();
            TreeViewCompzit_FinanceManagementSystem.Nodes.Clear();
            TreeViewCompzit_ProcurementManagementSystem.Nodes.Clear();
            ddlJobRole.Items.Insert(0, "--Select Job Role--");
            //ddlJobRole.Focus();
        }
        ddlUsrDsgn.Focus();
        ScriptManager.RegisterStartupScript(this, GetType(), "ClickCompzitModule", "ClickCompzitModule();", true);


    }
    private void DesignationSelectIndexChange(int x)
    {
        int intDsgnId = 0, intUserId = 0, intUsrRolMstrLoginSectionId, intUsrRolMstrAutoWrkShopSectionId;
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        intUsrRolMstrLoginSectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Login_Details);
        DataTable dtLoginSection = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrLoginSectionId);
        if (dtLoginSection.Rows.Count > 0)
        {
            divLoginDetailsSection.Style.Add("display", "block");
        }
        else
        {
            divLoginDetailsSection.Style.Add("display", "none");
        }
        intUsrRolMstrAutoWrkShopSectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Auto_Workshop);
        DataTable dtAutoWrkShopSection = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrAutoWrkShopSectionId);
        if (dtAutoWrkShopSection.Rows.Count > 0)
        {
            divAutoWorkshopSection.Style.Add("display", "block");
        }
        else
        {
            divAutoWorkshopSection.Style.Add("display", "none");
        }
        string newCode = "";
        if (ddlUsrDsgn.SelectedItem.Text != "--SELECT--")
        {
            //for login details section and auto workshop section
            intDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value.ToString());
            objEntityUsrRegistr.UserDsgnId = intDsgnId;
            hiddenDsgnContrl.Value = objBusinessLayerUserRegisteration.ReadDsgnCntrl(objEntityUsrRegistr);
            if (hiddenDsgnContrl.Value == "C")
            {
                mvUsrCorporate.Visible = true;
                mvUsrCorporate.SetActiveView(vSingle);

                //Start:-Empcode
                if (ddlUsrCorporate.SelectedItem.Value == "--SELECT--")
                {
                }
                else
                {
                    int intCorpId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value);
                    if (Request.QueryString["Id"] != null)
                    {
                        newCode = empRefFormatLoad(intCorpId);
                    }
                    else
                    {
                        txtEmployeeCode.Text = empRefFormatLoad(intCorpId);
                    }
                }
                //End:-Empcode
            }
            else if (hiddenDsgnContrl.Value == "O")
            {
                mvUsrCorporate.Visible = true;
                mvUsrCorporate.SetActiveView(vMultiple);
                //it add divisions based on current corrporate
                //   ChangeCbxlCorpOffc();
                divAutoWorkshopSection.Style.Add("display", "none");
                divDiv.Visible = false;
                //Start:-Empcode
                if (Session["CORPOFFICEID"] != null)
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        newCode = empRefFormatLoad(Convert.ToInt32(Session["CORPOFFICEID"]));
                    }
                    else
                    {
                        txtEmployeeCode.Text = empRefFormatLoad(Convert.ToInt32(Session["CORPOFFICEID"]));
                    }

                }
                //End:-Empcode
            }
            //End:-Empcode
            //EVM-0027
            if (Request.QueryString["Id"] != null && x == 1)
            {
               // ScriptManager.RegisterStartupScript(this, GetType(), "EmpRefChange", "EmpRefChange('" + newCode + "');", true);
            }
            //End
        }
        else
        {
            mvUsrCorporate.Visible = true;
            mvUsrCorporate.ActiveViewIndex = -1;
            //End:-Empcode
            txtEmployeeCode.Text = "";
            //End:-Empcode
        }
    }
    protected void ddlUsrCorporate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string newCode = "";

        hiddenConfirmValue.Value = "IncrmntConfrmCounter";
      //  txtEmployeeCode.Enabled = true;
        divDept.Visible = true;//0013
        DropDownBindDepartment();
        ddlUsrCorporate.Focus();
        //--------------

        divDiv.Visible = true;
        checkboxDivsnLoad();
        bussiDiv.Visible = true;//0013
        BindSubBusUnt();//0013
        if (ddlUsrCorporate.SelectedItem.Value == "--SELECT--")
        {
            divDiv.Visible = false;
            bussiDiv.Visible = false;
            divDept.Visible = false;
            divDiv.Visible = false;
            LicenseTypeLoad(0);
            //End:-Empcode
            txtEmployeeCode.Text = "";
            //End:-Empcode
        }
        else
        {
            divDept.Visible = true;
            int intCorpId = Convert.ToInt32(ddlUsrCorporate.SelectedItem.Value);
            LicenseTypeLoad(intCorpId);

            //End:-Empcode
            if (Request.QueryString["Id"] != null)
            {
                newCode = empRefFormatLoad(intCorpId);
                txtEmployeeCode.Text = newCode;
            }
            else
            {
                txtEmployeeCode.Text = empRefFormatLoad(intCorpId);
            }
            //End:-Empcode
        }
        //End:-Empcode
        //EVM-0027
      //  ScriptManager.RegisterStartupScript(this, GetType(), "PartialLoad", "PartialLoad('" + newCode + "');", true);
        //END
        //End:-Empcode
    }
    private bool CompareArray(byte[] a1, byte[] a2)
    {
        if (a1.Length != a2.Length)
            return false;
        for (int i = 0; i < a1.Length; i++)
        {

            if (a1[i] != a2[i])
                return false;
        }
        return true;
    }
    protected void ddlJobRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        hiddenConfirmValue.Value = "IncrmntConfrmCounter";
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        char charDsgTypCntrl = 'A';
        if (ddlJobRole.SelectedItem.Value != "--Select Job Role--")
        {
            objEntityUsrRegistr.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
            charDsgTypCntrl = Convert.ToChar(objBusinessLayerUserRegisteration.ReadDsgnCntrl(objEntityUsrRegistr));
            Treefill(charDsgTypCntrl);
        }
        else
        {
            BindCompzitModules();
            TreeViewCompzit_AppAdminstration.Nodes.Clear();
            TreeViewCompzit_SalesAutomation.Nodes.Clear();
            TreeViewCompzit_AutoWorkshopManagement.Nodes.Clear();
            TreeViewCompzit_GuaranteeManagement.Nodes.Clear();
            TreeViewCompzit_HumanCapitalManagement.Nodes.Clear();
            TreeViewCompzit_FinanceManagementSystem.Nodes.Clear();
            TreeViewCompzit_ProcurementManagementSystem.Nodes.Clear();
        }
        BindCompzitModules();
        TreeViewCompzit_AppAdminstration.Nodes.Clear();
        TreeViewCompzit_SalesAutomation.Nodes.Clear();
        TreeViewCompzit_AutoWorkshopManagement.Nodes.Clear();
        TreeViewCompzit_GuaranteeManagement.Nodes.Clear();
        TreeViewCompzit_HumanCapitalManagement.Nodes.Clear();
        TreeViewCompzit_FinanceManagementSystem.Nodes.Clear();
        TreeViewCompzit_ProcurementManagementSystem.Nodes.Clear();
        UpdateViewByDdl(ddlJobRole.SelectedItem.Value);
        ddlJobRole.Focus();
        ScriptManager.RegisterStartupScript(this, GetType(), "ClickCompzitModule", "ClickCompzitModule();", true);
    }
    //For DDL
    public void UpdateTreeViewByUserId(string strUserId)
    {
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
        objEmpRoleAllocation.EmployeeId = Convert.ToInt32(strUserId);
        DataTable dtDsgnMastr = objBusinessEmpRoleAllocation.ReadDsgnMasterEdit(objEmpRoleAllocation);
        DataTable dtDsgnAppRoles = objBusinessEmpRoleAllocation.ReadDsgnAppRoleByDsgnId(objEmpRoleAllocation);
        for (int intcountApp = 0; intcountApp < dtDsgnAppRoles.Rows.Count; intcountApp++)
        {
            if (dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() != "")
            {
                foreach (ListItem itemCheckBoxModules in cbxlCompzitModules.Items)
                {
                    if (itemCheckBoxModules.Value == dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString())
                    {
                        itemCheckBoxModules.Selected = true;
                    }
                }
            }
        }
        char charDsgTypCntrl = 'A';
        if (dtDsgnMastr.Rows.Count > 0)
        {
            charDsgTypCntrl = Convert.ToChar(dtDsgnMastr.Rows[0]["DSGN_CONTROL"].ToString());
            Treefill(charDsgTypCntrl);
            Int32 intPrimary = 1;
            string strUsrRoleChildRole = "";
            for (int intcount = 0; intcount < dtDsgnMastr.Rows.Count; intcount++)
            {
                if (dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() != "")
                {
                    if (intcount == 0)
                    {
                        strUsrRoleChildRole = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString();
                        if (dtDsgnMastr.Rows[intcount]["USRROL_CHLDRL_DEFN"].ToString() != "")
                        {
                            string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["USRROL_CHLDRL_DEFN"].ToString();
                            string[] strChildren = strchildRoleDefn.Split('-');
                            foreach (string strChild in strChildren)
                            {
                                string strBind = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() + "." + strChild;
                                strUsrRoleChildRole = strUsrRoleChildRole + "," + strBind;
                            }
                        }
                    }
                    else if (intcount > 0)
                    {
                        strUsrRoleChildRole = strUsrRoleChildRole + "," + dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString();

                        if (dtDsgnMastr.Rows[intcount]["USRROL_CHLDRL_DEFN"].ToString() != "")
                        {
                            string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["USRROL_CHLDRL_DEFN"].ToString();
                            string[] strChildren = strchildRoleDefn.Split('-');
                            foreach (string strChild in strChildren)
                            {
                                string strBind = dtDsgnMastr.Rows[intcount]["USROL_ID"].ToString() + "." + strChild;
                                strUsrRoleChildRole = strUsrRoleChildRole + "," + strBind;
                            }
                        }
                    }
                }
            }
            if (strUsrRoleChildRole != "")
            {
                foreach (TreeNode node in TreeViewCompzit_AppAdminstration.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }
                foreach (TreeNode node in TreeViewCompzit_SalesAutomation.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }
                foreach (TreeNode node in TreeViewCompzit_AutoWorkshopManagement.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }
                foreach (TreeNode node in TreeViewCompzit_GuaranteeManagement.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }
                foreach (TreeNode node in TreeViewCompzit_HumanCapitalManagement.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }
                foreach (TreeNode node in TreeViewCompzit_FinanceManagementSystem.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }
                foreach (TreeNode node in TreeViewCompzit_ProcurementManagementSystem.Nodes)
                {
                    SelectNodesRecursive(node, strUsrRoleChildRole);
                }

            }
        }
    }
    public void UpdateViewByDdl(string strJobRoleId)
    {
        if (strJobRoleId == "--Select Job Role--")
        {
        }
        else
        {
            clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
            int intJobRol = Convert.ToInt32(strJobRoleId);
            objEntityUsrRegistr.UserRoleId = intJobRol;
            objEntityUsrRegistr.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedValue.ToString());
            DataTable dtDsgnMastr = objBusinessLayerUserRegisteration.ReadJobRlRoles(objEntityUsrRegistr);
            DataTable dtDsgnAppRoles = objBusinessLayerUserRegisteration.ReadJobRlAppRoles(objEntityUsrRegistr);
            for (int intcountApp = 0; intcountApp < dtDsgnAppRoles.Rows.Count; intcountApp++)
            {
                if (dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString() != "")
                {
                    foreach (ListItem itemCheckBoxModules in cbxlCompzitModules.Items)
                    {
                        if (itemCheckBoxModules.Value == dtDsgnAppRoles.Rows[intcountApp]["PRTZAPP_ID"].ToString())
                        {
                            itemCheckBoxModules.Selected = true;
                        }
                    }
                }
            }
            char charDsgTypCntrl = 'A';
            if (dtDsgnMastr.Rows.Count > 0)
            {
                charDsgTypCntrl = Convert.ToChar(dtDsgnMastr.Rows[0]["DSGN_CONTROL"].ToString());
                Treefill(charDsgTypCntrl);
                Int32 intPrimary = 1;
                string strUsrRoleChildRole = "";
                for (int intcount = 0; intcount < dtDsgnMastr.Rows.Count; intcount++)
                {
                    if (dtDsgnMastr.Rows[intcount]["USRROL_ID"].ToString() != "")
                    {
                        if (intcount == 0)
                        {
                            strUsrRoleChildRole = dtDsgnMastr.Rows[intcount]["USRROL_ID"].ToString();
                            if (dtDsgnMastr.Rows[intcount]["JOBRLROL_CHLDRL_DEFN"].ToString() != "")
                            {
                                string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["JOBRLROL_CHLDRL_DEFN"].ToString();
                                string[] strChildren = strchildRoleDefn.Split('-');
                                foreach (string strChild in strChildren)
                                {
                                    string strBind = dtDsgnMastr.Rows[intcount]["USRROL_ID"].ToString() + "." + strChild;
                                    strUsrRoleChildRole = strUsrRoleChildRole + "," + strBind;
                                }
                            }
                        }
                        else if (intcount > 0)
                        {
                            strUsrRoleChildRole = strUsrRoleChildRole + "," + dtDsgnMastr.Rows[intcount]["USRROL_ID"].ToString();
                            if (dtDsgnMastr.Rows[intcount]["JOBRLROL_CHLDRL_DEFN"].ToString() != "")
                            {
                                string strchildRoleDefn = dtDsgnMastr.Rows[intcount]["JOBRLROL_CHLDRL_DEFN"].ToString();

                                string[] strChildren = strchildRoleDefn.Split('-');
                                foreach (string strChild in strChildren)
                                {
                                    string strBind = dtDsgnMastr.Rows[intcount]["USRROL_ID"].ToString() + "." + strChild;
                                    strUsrRoleChildRole = strUsrRoleChildRole + "," + strBind;
                                }
                            }
                        }
                    }
                }
                if (strUsrRoleChildRole != "")
                {
                    foreach (TreeNode node in TreeViewCompzit_AppAdminstration.Nodes)
                    {

                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }
                    foreach (TreeNode node in TreeViewCompzit_SalesAutomation.Nodes)
                    {
                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }
                    foreach (TreeNode node in TreeViewCompzit_AutoWorkshopManagement.Nodes)
                    {
                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }
                    foreach (TreeNode node in TreeViewCompzit_GuaranteeManagement.Nodes)
                    {
                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }
                    foreach (TreeNode node in TreeViewCompzit_HumanCapitalManagement.Nodes)
                    {
                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }
                    foreach (TreeNode node in TreeViewCompzit_FinanceManagementSystem.Nodes)
                    {
                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }
                    foreach (TreeNode node in TreeViewCompzit_ProcurementManagementSystem.Nodes)
                    {
                        SelectNodesRecursive(node, strUsrRoleChildRole);
                    }

                }
            }
        }
    }
    public void SelectNodesRecursive(TreeNode oParentNode, string strNodeValue)
    {
        string[] strValues = strNodeValue.Split(',');
        foreach (string strSingleValue in strValues)
        {
            if (oParentNode.Value == strSingleValue)
            {
                oParentNode.Checked = true;
            }
        }
        // Start recursion on all subnodes.
        foreach (TreeNode oSubNode in oParentNode.ChildNodes)
        {
            SelectNodesRecursive(oSubNode, strNodeValue);
        }
    }

    public void Treefill(char charDsgTypCntrl)
    {
        int intUserLimited = Convert.ToInt32(USERLIMITED.ISLIMITED);
        int intUserId = 0;
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
        DataTable dtUserDetails = new DataTable();
        if (Session["USERID"] == null)
        {
            Response.Redirect("../../Default.aspx");
        }
        else
        {
            objEmpRoleAllocation.UserId = Convert.ToInt32(Session["USERID"].ToString());
            // objEmpRoleAllocation.UserId = Convert.ToInt32(ddlEmployee.SelectedItem.Value);
            intUserId = objEmpRoleAllocation.UserId;
        }
        //BL
        dtUserDetails = objBusinessEmpRoleAllocation.ReadIfUserLimitedByUsrId(objEmpRoleAllocation);
        if (dtUserDetails.Rows.Count > 0)
        {
            intUserLimited = Convert.ToInt32(dtUserDetails.Rows[0]["USR_LMTD"].ToString());
        }
        Treefill_CRM_App(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_SFA(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_AWMS(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_GMS(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_HCM(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_FMS(charDsgTypCntrl, intUserLimited, intUserId);
        Treefill_CRM_PMS(charDsgTypCntrl, intUserLimited, intUserId);//PMS

    }
    public void Treefill_CRM_App(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        TreeViewCompzit_AppAdminstration.Nodes.Clear();
        TreeViewCompzit_SalesAutomation.Nodes.Clear();
        TreeViewCompzit_AutoWorkshopManagement.Nodes.Clear();
        TreeViewCompzit_GuaranteeManagement.Nodes.Clear();
        TreeViewCompzit_HumanCapitalManagement.Nodes.Clear();
        TreeViewCompzit_FinanceManagementSystem.Nodes.Clear();
        TreeViewCompzit_ProcurementManagementSystem.Nodes.Clear();

        PopulateRootLevel(1, 'W', APPS.APP_ADMINSTRATION, charDsgTypCntrl, intUserLimited, intUserId);
    }
    public void Treefill_CRM_SFA(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(2, 'W', APPS.SALES_FORCE_AUTOMATION, charDsgTypCntrl, intUserLimited, intUserId);
    }
    public void Treefill_CRM_AWMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(3, 'W', APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);
    }
    public void Treefill_CRM_GMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(4, 'W', APPS.GUARANTEE_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);
    }
    //TreeViewCompzit_HumanCapitalManagement
    public void Treefill_CRM_HCM(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(5, 'W', APPS.HUMAN_CAPITAL_MANAGEMENT, charDsgTypCntrl, intUserLimited, intUserId);
    }
    public void Treefill_CRM_FMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(6, 'W', APPS.FINANCE_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);
    }
    public void Treefill_CRM_PMS(char charDsgTypCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        PopulateRootLevel(7, 'W', APPS.PROCUREMENT_MANAGEMENT_SYSTEM, charDsgTypCntrl, intUserLimited, intUserId);//PMS
    }

    private void PopulateRootLevel(int intAppId, char chAppType, APPS Appsid, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId)
    {   //Created objects for business layer
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();

        objEmpRoleAllocation.ParentId = 0;
        objEmpRoleAllocation.AppId = intAppId;
        objEmpRoleAllocation.AppType = chAppType;
        objEmpRoleAllocation.DsgControl = charUsrolCntrl;
        objEmpRoleAllocation.UserId = intUserId;
        objEmpRoleAllocation.UserLimited = intUserLimited;
        DataTable dt = new DataTable();
        if (Session["FRMWRK_TYPE"]!=null &&Session["FRMWRK_TYPE"].ToString() == "1")
        {
            if (Session["FRMWRK_ID"] != null)
            {
                objEmpRoleAllocation.CorpOfficeId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            dt = objBusinessEmpRoleAllocation.DisplayUserolMstrFramewrk(objEmpRoleAllocation);
        }
        else
        {
            dt = objBusinessEmpRoleAllocation.DisplayUserolMstr(objEmpRoleAllocation);
        }

        if (Appsid == APPS.APP_ADMINSTRATION)
        {
            PopulateNodes(dt, TreeViewCompzit_AppAdminstration.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
        }
        else if (Appsid == APPS.SALES_FORCE_AUTOMATION)
        {
            PopulateNodes(dt, TreeViewCompzit_SalesAutomation.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
        }
        else if (Appsid == APPS.AUTO_WORKSHOP_MANAGEMENT_SYSTEM)
        {
            PopulateNodes(dt, TreeViewCompzit_AutoWorkshopManagement.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
        }
        else if (Appsid == APPS.GUARANTEE_MANAGEMENT_SYSTEM)
        {
            PopulateNodes(dt, TreeViewCompzit_GuaranteeManagement.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
        }
        else if (Appsid == APPS.HUMAN_CAPITAL_MANAGEMENT)
        {
            PopulateNodes(dt, TreeViewCompzit_HumanCapitalManagement.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
        }
        else if (Appsid == APPS.FINANCE_MANAGEMENT_SYSTEM)
        {
            PopulateNodes(dt, TreeViewCompzit_FinanceManagementSystem.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
        }
        else if (Appsid == APPS.PROCUREMENT_MANAGEMENT_SYSTEM)
        {
            PopulateNodes(dt, TreeViewCompzit_ProcurementManagementSystem.Nodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);//PMS
        }

    }
    
    private void PopulateSubLevel(int parentid, TreeNode parentNode, int intAppId, char chAppType, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId)
    { //Created objects for business layer

        clsBusinessLayerEmpRoleAllocation objBusinessEmpRoleAllocation = new clsBusinessLayerEmpRoleAllocation();
        clsEntityEmpRoleAllocation objEmpRoleAllocation = new clsEntityEmpRoleAllocation();
        objEmpRoleAllocation.ParentId = parentid;
        objEmpRoleAllocation.AppId = intAppId;
        objEmpRoleAllocation.AppType = chAppType;
        objEmpRoleAllocation.DsgControl = charUsrolCntrl;
        objEmpRoleAllocation.UserId = intUserId;
        objEmpRoleAllocation.UserLimited = intUserLimited;
        DataTable dt = new DataTable();
        if (Session["FRMWRK_TYPE"]!=null&&Session["FRMWRK_TYPE"].ToString() == "1")
        {
            if (Session["FRMWRK_ID"] != null)
            {
                objEmpRoleAllocation.CorpOfficeId = Convert.ToInt32(Session["FRMWRK_ID"].ToString());
            }
            dt = objBusinessEmpRoleAllocation.DisplayUserolMstrFramewrk(objEmpRoleAllocation);
        }
        else
        {
            dt = objBusinessEmpRoleAllocation.DisplayUserolMstr(objEmpRoleAllocation);
        }
        PopulateNodes(dt, parentNode.ChildNodes, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);
    }
    
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes, int intAppId, char chAppType, char charUsrolCntrl, Int32 intUserLimited, Int32 intUserId)
    {
        foreach (DataRow dr in dt.Rows)
        {
            int intUsrRolMstrId, intLimitedEnableAdd = 0, intLimitedEnableModify = 0, intLimitedEnableCancel = 0, intLimitedEnableFind = 0, intLimitedEnableRateUpdation = 0;
            int intLimitedEnableConfirm = 0, intLimitedEnableApprove = 0, intLimitedEnableReOpen = 0, intLimitedEnableReturn = 0, intLimitedEnableWin = 0, intLimitedEnableLoss = 0;
            int intLimitedEnableAllocate = 0, intLimitedEnableAllMails = 0, intLimitedEnableMailAllocate = 0, intLimitedEnableMailForword = 0, intLimitedEnableMailAttach = 0, intLimitedEnableClose = 0, intLimitedEnableSuplier_Guarantee_Permission = 0, intLimitedEnableClient_Guarantee_Permission = 0;
            int intLimitedEnableRenew = 0, intLimitedEnableHRallocation = 0, intLimitedEnableSelfAllocation = 0, intLimitedEditAllocation = 0, intLimitedGMAllocation = 0;
            int intLimitedEnableReissue = 0, intLimitedEnableOnHold = 0, intLimitedEnableBussinessunit = 0, intLimitedAllDivision = 0, intLimitedFmsAudit = 0, intAccountSecific = 0, intBusinessSecific = 0, intLimitedFmsAccount = 0, intDiscount = 0, intFiscalYrEdit = 0, intAdministrator_Privileges = 0, intRecurring = 0, intChequePrint = 0;  //evm-0023-05-04-19
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            TreeNode tn = new TreeNode();
            tn.Text = dr["USROL_NAME"].ToString();
            tn.Value = dr["USROL_ID"].ToString();
            tn.NavigateUrl = "javascript:void(0)";
            nodes.Add(tn);



            //Getting child roles based on user role maser id for cheching for the limited user case
            intUsrRolMstrId = Convert.ToInt32(dr["USROL_ID"].ToString());
            DataTable dtChildRolForLimited = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRolForLimited.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolForLimited.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intLimitedEnableAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intLimitedEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intLimitedEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString())
                    {
                        intLimitedEnableFind = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString())
                    {
                        intLimitedEnableRateUpdation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intLimitedEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        intLimitedEnableApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intLimitedEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString())
                    {
                        intLimitedEnableReturn = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString())
                    {
                        intLimitedEnableWin = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString())
                    {
                        intLimitedEnableLoss = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString())
                    {
                        intLimitedEnableAllocate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString())
                    {
                        intLimitedEnableAllMails = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString())
                    {
                        intLimitedEnableMailAllocate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString())
                    {
                        intLimitedEnableMailForword = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString())
                    {
                        intLimitedEnableMailAttach = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intLimitedEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                    {
                        intLimitedEnableSuplier_Guarantee_Permission = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                    {
                        intLimitedEnableClient_Guarantee_Permission = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString())
                    {
                        intLimitedEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intLimitedEnableHRallocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString())
                    {
                        intLimitedEnableSelfAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString())
                    {
                        intLimitedEditAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString())
                    {
                        intLimitedEnableReissue = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                        intLimitedGMAllocation = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString())
                    {
                        intLimitedEnableOnHold = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString())
                    {
                        intLimitedEnableBussinessunit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        intLimitedFmsAudit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intLimitedFmsAccount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        intAccountSecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        intBusinessSecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString())
                    {
                        intDiscount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString())
                    {
                        intFiscalYrEdit = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString()) //evm-0023-05-04-19
                    {
                        intAdministrator_Privileges = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        intRecurring = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString())
                    {
                        intChequePrint = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                }


            }
            //If node has child nodes, then enable on-demand populating
            //   tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"].ToString()) > 0);
            if (dr["USROL_CHLDRL_DEFN"].ToString() != "")
            {

                string strChildDef = dr["USROL_CHLDRL_DEFN"].ToString();
                // Split string on spaces.
                // ... This will separate all the words.
                string[] strChildDefArrWords = strChildDef.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnAdd = new TreeNode();
                        tnAdd.Text = "ADD";
                        tnAdd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString();
                        tnAdd.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnAdd);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableModify == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnModify = new TreeNode();
                        tnModify.Text = "MODIFY";
                        tnModify.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString();
                        tnModify.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnModify);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableCancel == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnCncl = new TreeNode();
                        tnCncl.Text = "CANCEL";
                        tnCncl.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString();
                        tnCncl.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnCncl);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableFind == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnFind = new TreeNode();
                        tnFind.Text = "FIND";
                        tnFind.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Find).ToString();
                        tnFind.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnFind);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableRateUpdation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRateUpd = new TreeNode();
                        tnRateUpd.Text = "RATE UPDATION";
                        tnRateUpd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Rate_Updation).ToString();
                        tnRateUpd.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRateUpd);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "CONFIRM";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableApprove == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "DM ALLOCATION";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReOpen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "RE-OPEN";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReturn == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "RETURN";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Return).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableWin == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "WIN";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Win).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableLoss == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "LOSS";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Loss).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAllocate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "ALLOCATE";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Allocate).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableAllMails == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "VIEW ALL MAILS";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.All_Mails).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailAllocate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "MAIL ALLOCATE";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Allocate).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailForword == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "MAIL FORWARD";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Forward).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableMailAttach == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnConfm = new TreeNode();
                        tnConfm.Text = "LEAD ATTACH";
                        tnConfm.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Mail_Attach).ToString();
                        tnConfm.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnConfm);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableClose == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnClose = new TreeNode();
                        tnClose.Text = "CLOSE";
                        tnClose.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString();
                        tnClose.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnClose);

                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableSuplier_Guarantee_Permission == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnSuplier_Guarantee = new TreeNode();
                        tnSuplier_Guarantee.Text = "SUPPLIER_GUARANTEE";
                        tnSuplier_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString();
                        tnSuplier_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnSuplier_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableClient_Guarantee_Permission == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnClient_Guarantee = new TreeNode();
                        tnClient_Guarantee.Text = "CLIENT_GUARANTEE";
                        tnClient_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString();
                        tnClient_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnClient_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableRenew == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "RENEW";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Renew).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableHRallocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "HR ALLOCATION";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableSelfAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "SELF ALLOCATION";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Self_Allocation).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEditAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "EDIT ALLOCATION";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Edit_Allocation).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableReissue == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnreissue = new TreeNode();
                        tnreissue.Text = "REISSUE";
                        tnreissue.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString();
                        tnreissue.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnreissue);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedGMAllocation == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "GM ALLOCATION";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableOnHold == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "ON HOLD";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.OnHold).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }

                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedEnableBussinessunit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "ALL BUSINESS UNIT";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_BUSINESS_UNIT).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);

                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedAllDivision == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "ALL DIVISION";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ALL_DIVISION).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedFmsAccount == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = " ACCOUNT";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intLimitedFmsAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = " AUDIT";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intAccountSecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = " ACCOUNT SPECIFIC";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intBusinessSecific == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = " BUSINESS SPECIFIC";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intDiscount == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "DISCOUNT";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intFiscalYrEdit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnRenew_Guarantee = new TreeNode();
                        tnRenew_Guarantee.Text = "FINANCIAL YEAR EDIT";
                        tnRenew_Guarantee.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.FINANCL_YR_EDIT).ToString();
                        tnRenew_Guarantee.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnRenew_Guarantee);
                    }

                        //evm-0023-05-04-19
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intAdministrator_Privileges == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnAdd = new TreeNode();
                        tnAdd.Text = "ADMINISTRATOR PRIVILEGES";
                        tnAdd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Administrator_Privileges).ToString();
                        tnAdd.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnAdd);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intRecurring == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnAdd = new TreeNode();
                        tnAdd.Text = "RECURRING";
                        tnAdd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString();
                        tnAdd.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnAdd);
                    }
                    else if ((strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.NOTLIMITED)) || (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString() && intUserLimited == Convert.ToInt32(USERLIMITED.ISLIMITED) && intChequePrint == Convert.ToInt32(clsCommonLibrary.StatusAll.Active)))
                    {
                        TreeNode tnAdd = new TreeNode();
                        tnAdd.Text = "CHEQUE PRINT";
                        tnAdd.Value = dr["USROL_ID"].ToString() + "." + Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString();
                        tnAdd.NavigateUrl = "javascript:void(0)";
                        tn.ChildNodes.Add(tnAdd);
                    }
                }
                // PopulateSubLevel(Convert.ToInt32(dr["USROL_ID"].ToString()), tn);

            }

            if (Convert.ToInt32(dr["childnodecount"].ToString()) > 0)
            {
                PopulateSubLevel(Convert.ToInt32(dr["USROL_ID"].ToString()), tn, intAppId, chAppType, charUsrolCntrl, intUserLimited, intUserId);

            }
        }
    }
    //for edit-read user role 0013
    public void ReadUserRole(int jobRl, int desig)
    {

    }

    //End functional

    public void clearpersonal()
    {
        TxtFrstName.Text = "";
        TxtMidleName.Text = "";
        TxtLstName.Text = "";
        Txtemplyid.Text = "";
        txtRefNum.Text = "";
        TxtDOB.Text = "";
        txtBirthPlc.Text = "";
        txtNickName.Text = "";
        txtHobbies.Text = "";
        ddlNationality.SelectedIndex = 0;
    }

    [WebMethod]
    public static string LoadRole(int ddldesigValue, int Orgid, int CorpId)
    {
        clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        int desig = ddldesigValue;
        objEntityUsrRegistr.UserDsgnId = desig;
        DataTable dtJobRol = new DataTable();
        dtJobRol = objBusinessLayerUserRegisteration.ReadJobRol(objEntityUsrRegistr);
        dtJobRol.TableName = "dtrole";
        string result = "";
        if (dtJobRol.Rows.Count > 0)
        {
            using (StringWriter sw = new StringWriter())
            {
                dtJobRol.WriteXml(sw);
                result = sw.ToString();
            }
        }
        return result;
    }

    public void Visaload()
    {
        clsBusinessLayerImmigration objBusinessImmigdtls = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityImigrationDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        string strDsgControlLoginUsr = "C";
        if (Session["DSGN_CONTROL"] != null)
        {
            strDsgControlLoginUsr = Session["DSGN_CONTROL"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (strDsgControlLoginUsr == "O")
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(strId);
            }
        }
        DataTable dtVisatype = objBusinessImmigdtls.Read_Visa(objEntityImigrationDtls);
        Ddlvisatype.DataSource = dtVisatype;
        Ddlvisatype.DataTextField = "VISA_NAME";
        Ddlvisatype.DataValueField = "VISATYP_ID";
        Ddlvisatype.DataBind();
        Ddlvisatype.Items.Insert(0, "--Select Visa Type--");
    }
    //contact details
    //protected void btnClearCD_Click(object sender, EventArgs e)
    //{
    //    //CountryLoadCD();
    //    //CountryLoadCommu();
    //    //LoadRelation();
    //}
    protected void ddlDivsn_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intDivisionID = 0;
        if (ddlDivision.Text == "--SELECT DIVISION--")
        {
            intDivisionID = 0;
        }
        else
        {
            intDivisionID = Convert.ToInt32(ddlDivision.SelectedValue);
        }
        projectLoad(intDivisionID);
        ddlDivision.Focus();
    }
    protected void ddlprojectassign_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    public void updateImigrationDtls(string id)
    {
        clsBusinessLayerImmigration objBusinessImigration = new clsBusinessLayerImmigration();
        clsEntityImmigration objEntityImigrationDtls = new clsEntityImmigration();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        // objEntityImigrationDtls.Imig_Id = Convert.ToInt32(id);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityImigrationDtls.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityImigrationDtls.Imig_user_id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        objEntityImigrationDtls.Imig_Emp_id = Convert.ToInt32(id);
        DataTable dtImigrations = objBusinessImigration.ReadImmigrationList(objEntityImigrationDtls);

        string strHtmListSklCer1 = ConvertDataTableToHTMLForCandImmig(dtImigrations);
        divImigList.InnerHtml = strHtmListSklCer1;

    }
    public void Update_PersonalDtls(string strP_Id)
    {
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
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityPersonalDtls.CandidadteId = Convert.ToInt32(strP_Id.ToString());
        DataTable dtMnpwrrMstr = objBusinessPersonaldtls.ReadPersonalDetailsId(objEntityPersonalDtls);
        if (dtMnpwrrMstr.Rows.Count > 0)
        {
            TxtFrstName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_FNAME"].ToString(); //evm-0023
            TxtMidleName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_MNAME"].ToString(); //evm-0023
            TxtLstName.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_LNAME"].ToString(); //evm-0023
            //txtloccontact.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_LCL_CNT_NUM"].ToString();
            txtUsrMob.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_TELE"].ToString();
            txtUsrEmail.Text = dtMnpwrrMstr.Rows[0]["STAFF_PR_EMAIL"].ToString();
            ddlUsrDsgn.Text = dtMnpwrrMstr.Rows[0]["DSGN_NAME"].ToString();
            if (dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString() != "")
            {
                if (ddlUsrDsgn.Items.FindByValue(dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString()) != null)
                {
                    ddlUsrDsgn.ClearSelection();
                    ddlUsrDsgn.Items.FindByValue(dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["DSGN_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString());
                    ddlUsrDsgn.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlUsrDsgn);
                    ddlUsrDsgn.ClearSelection();
                    ddlUsrDsgn.Items.FindByValue(dtMnpwrrMstr.Rows[0]["DSGN_ID"].ToString()).Selected = true;
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
            int intCount = 0;
            foreach (ListItem item in cbxlCorporateDvsn.Items)
            {
                if (item.Value == dtMnpwrrMstr.Rows[0]["CPRDIV_ID"].ToString())
                {
                    item.Selected = true;
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "check", "check(" + intCount + ");", true);
                }
                intCount++;
            }
        }
    }
    public void Update_ContactDtls(string strP_Id)
    {
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableModify = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0;
        //Id, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableModify = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0;
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
        if (Session["ORGID"] != null)
        {
            objEntityContactDtls.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityContactDtls.CandidadteId = Convert.ToInt32(strP_Id.ToString());
        DataTable dtcontactdetails = objBusinessContactDtls.ReadContactDetailsId(objEntityContactDtls);
        //  HiddenMasterid.Value = dtcontactdetails.Rows[0]["STAFF_CNT_ID"].ToString();

        if (dtcontactdetails.Rows.Count > 0)
        {
            txtAdr1.Text = dtcontactdetails.Rows[0]["STAFF_CNT_PR_ADDR"].ToString();
            txtEmrgName.Text = dtcontactdetails.Rows[0]["STAFF_CNT_EMR_CNT"].ToString();

        }
    }
    public void updateOtherDtls(string id)
    {
        clsEntityCandidateOtherDetails objEntityOtherDetails = new clsEntityCandidateOtherDetails();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityOtherDetails.CrprtId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityOtherDetails.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayerCandidateOtherDetails objBusinessOtherDetails = new clsBusinessLayerCandidateOtherDetails();
        //  clsEntityCandidateOtherDetails objEntityOtherDetails = new clsEntityCandidateOtherDetails();
        objEntityOtherDetails.CandId = Convert.ToInt32(id);
        DataTable dt = objBusinessOtherDetails.ReadPersnlDtlsById(objEntityOtherDetails);
        if (dt.Rows.Count > 0)
        {
            TxtDOB.Text = dt.Rows[0]["DATE OF BIRTH"].ToString();
        }
    }
    public void updateWrksDtls(string id)
    {
        clsEntityJoiningWorker objEntityJoiningWorker = new clsEntityJoiningWorker();
        clsBusinessLayerJoiningWorker objBusinessLayerJoiningWorker = new clsBusinessLayerJoiningWorker();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJoiningWorker.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityJoiningWorker.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityJoiningWorker.WorkerID = Convert.ToInt32(id);
        DataTable dt = objBusinessLayerJoiningWorker.ReadJoinigWorkerByID(objEntityJoiningWorker);
        if (dt.Rows.Count > 0)
        {
            //txtAdr1.Text = dt.Rows[0]["MRG_DATE"].ToString();
            TxtFrstName.Text = dt.Rows[0]["CAND_NAME"].ToString();

            ddlUsrDsgn.Text = dt.Rows[0]["DSGN_NAME"].ToString();
            if (dt.Rows[0]["DSGN_ID"].ToString() != "")
            {
                if (ddlUsrDsgn.Items.FindByValue(dt.Rows[0]["DSGN_ID"].ToString()) != null)
                {
                    ddlUsrDsgn.Items.FindByValue(dt.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["DSGN_NAME"].ToString(), dt.Rows[0]["DSGN_ID"].ToString());
                    ddlUsrDsgn.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlUsrDsgn);
                    ddlUsrDsgn.Items.FindByValue(dt.Rows[0]["DSGN_ID"].ToString()).Selected = true;
                }
            }
            //emp-20
            for (int intCount = 0; intCount < dt.Rows.Count; intCount++)
            {
                foreach (ListItem item in cbxlCorporateDvsn.Items)
                {
                    if (item.Value == dt.Rows[intCount]["CPRDIV_ID"].ToString())
                    {
                        item.Selected = true;
                        //  ScriptManager.RegisterStartupScript(this, GetType(), "check", "check(" + intCount + ");", true);
                    }
                }
            }
            if (dt.Rows[0]["WKR_PASSPORTNO"].ToString() != "")
            {
                Textnumber.Text = dt.Rows[0]["WKR_PASSPORTNO"].ToString();
            }
        }
    }
    public string ConvertDataTableToHTMLForCandImmig(DataTable dt)
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
                string usr = dt.Rows[intRowBodyCount]["CAND_ID"].ToString(); ;
                string strId = dt.Rows[intRowBodyCount]["STAFF_VISA_TYP_ID"].ToString();
                int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = strId;
                string strdoc = dt.Rows[intRowBodyCount][1].ToString();
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
                if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Edit\" style=\"opacity: 1.2;text-align: center;cursor: pointer;margin-top:-1% \"onclick=\"return EditImigrationByid('" + Id + "','" + usr + "');\" >" + "<img   src='/Images/Icons/edit.png' /> " + "</a> </td>";
                }
                if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\"width:1%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" title=\"Delete\" style=\"opacity: 1.2;cursor: pointer;margin-top:-1%;margin-left:1% \"onclick=\"return DeleteImigrationByid('" + Id + "','" + usr + "','" + strdoc + "');\" >" + "<img   src='/Images/Icons/delete.png' /> " + "</a> </td>";
                }
            } strHtml += "</tr>";
        }
        strHtml += "</tbody>";
        strHtml += "</table>";
        sb.Append(strHtml);
        return sb.ToString();
    }
    //for worker and staff
    public void designationLoadData()
    {
        hiddenConfirmValue.Value = "IncrmntConfrmCounter";
        DesignationSelectIndexChange(0);
        // txtJoiningDate.Focus();
        divDept.Visible = true;
        bussiDiv.Visible = true;
        BindSubBusUnt();
        ddlJobRole.Items.Clear();
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        if (ddlUsrDsgn.SelectedItem.Value != "--SELECT--")
        {
            int desig = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
            objEntityUsrRegistr.UserDsgnId = desig;
            DataTable dtJobRol = new DataTable();
            dtJobRol = objBusinessLayerUserRegisteration.ReadJobRol(objEntityUsrRegistr);
            if (dtJobRol.Rows.Count > 0)
            {
                for (int intcount = 0; intcount < dtJobRol.Rows.Count; intcount++)
                {
                    ddlJobRole.DataSource = dtJobRol;
                    ddlJobRole.DataTextField = "JOBRL_NAME";
                    ddlJobRole.DataValueField = "JOBRL_ID";
                    ddlJobRole.DataBind();
                }
            }
            ddlJobRole.Items.Insert(0, "--Select Job Role--");
        }
        else
        {
            BindCompzitModules();
            TreeViewCompzit_AppAdminstration.Nodes.Clear();
            TreeViewCompzit_SalesAutomation.Nodes.Clear();
            TreeViewCompzit_AutoWorkshopManagement.Nodes.Clear();
            TreeViewCompzit_GuaranteeManagement.Nodes.Clear();
            TreeViewCompzit_HumanCapitalManagement.Nodes.Clear();
            TreeViewCompzit_FinanceManagementSystem.Nodes.Clear();
            TreeViewCompzit_ProcurementManagementSystem.Nodes.Clear();
        }
    }
    public void ReprtingEmployeeLoad(string id)   //EMP25
    {
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityPersonalDtls.EmpUserId = Convert.ToInt32(id.ToString());

        clsBusinessLayerPersonalDtls objBusinessLangauage = new clsBusinessLayerPersonalDtls();


        DataTable dt = objBusinessLangauage.ReadEmployee(objEntityPersonalDtls);
        ddlRepotingTo.Items.Clear();
        ddlRepotingTo.DataSource = dt;
        ddlRepotingTo.DataTextField = "USR_NAME";
        ddlRepotingTo.DataValueField = "USR_ID";
        ddlRepotingTo.DataBind();
        ddlRepotingTo.Items.Insert(0, "--Select Employee--");
    }
    public void Resigncheck(string strId)
    {
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }

        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityPersonalDtls.EmployeeId = strId;
        clsBusinessLayerPersonalDtls objBusinessLangauage = new clsBusinessLayerPersonalDtls();
        DataTable dt = objBusinessLangauage.ReadResignDetails(objEntityPersonalDtls);
        if (dt.Rows.Count > 0)
        {
            hiddendetailidresignation.Value = dt.Rows[0]["MastrId"].ToString();
            string status = dt.Rows[0]["STATUS"].ToString();
            ddlresignstatus.ClearSelection();
            txtleavingdate.Text = dt.Rows[0]["PRFRD_DATE"].ToString();
            ddlresignstatus.Items.FindByValue(status).Selected = true;
            txtResgnreasn.InnerText = dt.Rows[0]["RSGNTN_HR_REASON"].ToString();
            txtResgnreasn.Disabled = true;
        }
        else
            ScriptManager.RegisterStartupScript(this, GetType(), "show_Resigndiv", "show_Resigndiv();", true);
    }

    protected void btnAddRS_Click(object sender, EventArgs e)
    {
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPersonalDtls.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        if (Session["ORGID"] != null)
        {
            objEntityPersonalDtls.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityPersonalDtls.RefNum = hiddendetailidresignation.Value;
        objEntityPersonalDtls.EmployeeId = HiddenEmployeeMasterId.Value;
        objEntityPersonalDtls.Date = objCommon.textToDateTime(txtleavingdate.Text); ;
        objEntityPersonalDtls.Resignsstats = Convert.ToInt32(ddlresignstatus.SelectedItem.Value);
        clsBusinessLayerPersonalDtls objBusinessLangauage = new clsBusinessLayerPersonalDtls();
        objBusinessLangauage.UpdateResignDetails(objEntityPersonalDtls);
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessResignation", "SuccessResignation();", true);
    }

    [WebMethod]
    public static string LoadAcccmdtnCat(string accmdtn)
    {
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        objEntityPersonalDtls.AccomdtnId = Convert.ToInt32(accmdtn);
        DataTable dtState = objBusinessPersonalDtls.ReadAccnCatagry(objEntityPersonalDtls);
        dtState.TableName = "dtTableAllwnce";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtState.WriteXml(sw);
            result = sw.ToString();
        }
        return result;

    }
    [WebMethod]
    public static string LoadAcccmdtnSubCat(string accmdtn, string accmdtnCat)
    {
        clsBusinessLayerPersonalDtls objBusinessPersonalDtls = new clsBusinessLayerPersonalDtls();
        clsEntityPersonalDtls objEntityPersonalDtls = new clsEntityPersonalDtls();
        objEntityPersonalDtls.AccomdtnId = Convert.ToInt32(accmdtn);
        objEntityPersonalDtls.SubCatagoryId = Convert.ToInt32(accmdtnCat);
        DataTable dtState = objBusinessPersonalDtls.ReadAccnSubCatagry(objEntityPersonalDtls);
        dtState.TableName = "dtTableAllwnce";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtState.WriteXml(sw);
            result = sw.ToString();
        }
        return result;
    }

    protected void radioCorporateDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        hiddendeptchng.Value = "1";//evm-20
        hiddenPrimaryDivision.Value = "";

        clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();  //emp0025
        objEntityUserReg.UserId = Convert.ToInt32(HiddenEmployeeId.Value);
        string uid = Convert.ToString(objEntityUserReg.UserId);
        objEntityUserReg.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
        objEntityUserReg.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedItem.Value);
        objEntityUserReg.UserDvsnId = "0";
        DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUserReg);
        string count = dtWelfareScvc.Rows.Count.ToString();
        // DataTable dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityUserReg);
        DataTable dtWelfar = new DataTable();
        dtWelfar = null;
        if (dtWelfareScvc.Rows.Count > 0)
        {

            // divwelfareSrevc.Visible = true;
            // lblWelfareSrvc.Attributes["style"] = "display:block;";
            divwelfareSrevc.Attributes["style"] = "display:block;";
            string strHtmmm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar, count, uid);
            //Write to divReport
            divReport1.InnerHtml = strHtmmm;

        }
        else
        {
            divwelfareSrevc.Attributes["style"] = "display:none;";
            //  divwelfareSrevc.Visible = false;


        }



        checkboxDivsnLoad();
    }
    public void checkboxDivsnLoad()
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();

        HiddenUserCrprtDept.Value = "";//EVM-0024@
        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (rbtnCropDept.SelectedValue != "" && rbtnCropDept.SelectedValue != null)
        {
            objEntityUsrRegistr.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedValue);
            HiddenUserCrprtDept.Value = rbtnCropDept.SelectedValue;
        }
        DataTable dtCrptDvsn = new DataTable();
        dtCrptDvsn = objBusinessLayerUserRegisteration.ReadCrptDivisionsDetails(objEntityUsrRegistr);
        dtCorpDivVisibility = dtCrptDvsn;
        if (dtCrptDvsn.Rows.Count == 0)
        {
            divDiv.Visible = false;
            ddlDivision.Items.Clear();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        }
        if (dtCrptDvsn.Rows.Count > 0)
        {
            divDiv.Visible = true;
            cbxlCorporateDvsn.DataSource = dtCrptDvsn;
            cbxlCorporateDvsn.DataTextField = "CPRDIV_NAME";
            cbxlCorporateDvsn.DataValueField = "CPRDIV_ID";
            cbxlCorporateDvsn.DataBind();
            ddlDivision.Items.Clear();
            ddlDivision.DataSource = dtCrptDvsn;
            ddlDivision.DataTextField = "CPRDIV_NAME";
            ddlDivision.DataValueField = "CPRDIV_ID";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
        }

        if (dtCrptDvsn.Rows.Count > 0)
        {
            LoadPrimaryDivision(dtCrptDvsn.Rows.Count);
        }

        if (rbtnCropDept.SelectedValue != "" && rbtnCropDept.SelectedValue != null)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "FocusDept", "FocusDept(" + rbtnCropDept.SelectedIndex + ");", true);
        }
    }


    [WebMethod]
    public static string[] readprobation(string strJobId)
    {
        clsBusinessLayerJobDetails objBusinessjob = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        string[] strpass = new string[2];
        objEntityJobDetails.Job_Id = Convert.ToInt32(strJobId);
        DataTable dtDates = objBusinessjob.ReadJobProbation(objEntityJobDetails);
        if (dtDates.Rows.Count > 0)
        {
            strpass[0] = dtDates.Rows[0]["EMP_PROBATION_END_DATE"].ToString();
            strpass[1] = dtDates.Rows[0]["EMP_PROBATION_PERIOD"].ToString();
        }

        return strpass;
    }
    [WebMethod]
    public static string RenewProbationUpdate(string strJobsId, string strProbDate, string strProbPeriod)
    {
        clsBusinessLayerJobDetails objBusinessjob = new clsBusinessLayerJobDetails();
        clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityJobDetails.Job_Id = Convert.ToInt32(strJobsId);

        objEntityJobDetails.ProbationEnddate = new DateTime();
        objEntityJobDetails.ProbationEnddate = objCommon.textToDateTime(strProbDate);

        objEntityJobDetails.Probation = int.Parse(strProbPeriod);
        objBusinessjob.UpdateProbationDate(objEntityJobDetails);
        return "true";
    }
    [WebMethod]

    public static string LoadWelfareService(string struid, string strdesgid, string strdeptid, string strdivid)
    {
        string strHtmmm = "";
        clsBusinessLayerUserRegisteration objBusinessLayerUserRegisteration = new clsBusinessLayerUserRegisteration();
        clsEntityLayerUserRegistration objEntityUserReg = new clsEntityLayerUserRegistration();  //emp0025
        Master_gen__Emply_Personal__Informn_gen__Emply_Personal__Informn obj = new Master_gen__Emply_Personal__Informn_gen__Emply_Personal__Informn();
        objEntityUserReg.UserId = Convert.ToInt32(struid);
        objEntityUserReg.UserDsgnId = Convert.ToInt32(strdesgid);
        objEntityUserReg.UserCrprtDept = Convert.ToInt32(strdeptid);



        objEntityUserReg.UserDvsnId = strdivid;

        DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUserReg);
        string count = dtWelfareScvc.Rows.Count.ToString();
        // DataTable dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityUserReg);
        DataTable dtWelfar = new DataTable();
        if (dtWelfareScvc.Rows.Count > 0)
        {

            strHtmmm = obj.ConvertDataTableToHTML(dtWelfareScvc, dtWelfar, count, struid);

            //Write to divReport


            //  obj.divReport1.InnerHtml = strHtmmm;

        }
        // dtWelfar = null;
        return strHtmmm;
    }
    protected void btnRenSave_Click(object sender, EventArgs e)
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        clsEntityLayerEmployeeWelfareSrvc objEntityEmpWelfr = new clsEntityLayerEmployeeWelfareSrvc();
        if (Session["ORGID"] != null)
        {
            objEntityUsrRegistr.UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityEmpWelfr.Emp_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityEmpWelfr.Welfare_Id = Convert.ToInt32(HiddenWelfareId.Value);

        string uid = HiddenEmployeeId.Value;
        objEntityUsrRegistr.UserId = Convert.ToInt32(uid);
        objEntityUsrRegistr.UserDsgnId = Convert.ToInt32(ddlUsrDsgn.SelectedItem.Value);
        objEntityUsrRegistr.UserDvsnId = HiddenDivision.Value;
        if (rbtnCropDept.SelectedValue != "" && rbtnCropDept.SelectedValue != null)
        {
            objEntityUsrRegistr.UserCrprtDept = Convert.ToInt32(rbtnCropDept.SelectedValue);
        }

        DataTable dtWelfareScvc = objBusinessLayerUserRegisteration.ReadEmpnWelfareSrvc(objEntityUsrRegistr);
        string count = dtWelfareScvc.Rows.Count.ToString();
        DataTable dtWelfar = new DataTable();
        dtWelfar = null;
        // DataTable dtWelfar = objBusinessLayerUserRegisteration.ReadEmpnWelfare(objEntityUserReg);
        bool existsCus = dtWelfareScvc.Select().ToList().Exists(row => row["WLFRSRVC_ID"].ToString().ToUpper() == HiddenWelfareId.Value);
        if (existsCus == true)
        {


            // CusData[2] = "1";



            List<clsEntityLayerEmployeeWelfareSrvc> objListEmpWelfare = new List<clsEntityLayerEmployeeWelfareSrvc>();


            string jsonData = Hiddenchecklist.Value;
            if (jsonData == "[]")
            {
                objEntityEmpWelfr.Emp_Id = Convert.ToInt32(uid);
                objEntityEmpWelfr.WelfSub_Id = HiddenWelfareSubid.Value.TrimEnd(" , ".ToCharArray());
            }
            else
            {
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string k = h.Replace("}\",", "},");

                List<clsWBData> objWBDataList = new List<clsWBData>();
                objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
                foreach (clsWBData objclsWBData in objWBDataList)
                {

                    clsEntityLayerEmployeeWelfareSrvc objEmp = new clsEntityLayerEmployeeWelfareSrvc();
                    //for (int i = 0; i < dtWelfareScvc.Rows.Count; i++)
                    //{
                    //    if (objclsWBData.WelfareId != dtWelfareScvc.Rows[i]["WLFRSRVC_ID"])
                    //    {

                    //    }
                    //}



                    objEmp.Emp_Id = Convert.ToInt32(objclsWBData.EmpId);
                    objEntityEmpWelfr.Emp_Id = objEmp.Emp_Id;



                    objEmp.WelfrSub_Id = Convert.ToInt32(objclsWBData.WelfareSubId);
                    objEntityEmpWelfr.WelfSub_Id = HiddenWelfareSubid.Value.TrimEnd(" , ".ToCharArray());
                    objEmp.Qty = Convert.ToDecimal(objclsWBData.limit);
                    objEntityEmpWelfr.Qty = objEmp.Qty;
                    objEmp.chkSts = Convert.ToInt32(objclsWBData.chkSts);
                    objEmp.ActQty = Convert.ToDecimal(objclsWBData.ActLimt);
                    objEmp.checkboxsts = Convert.ToInt32(objclsWBData.CheckboxSts);
                    objListEmpWelfare.Add(objEmp);
                }
            }



            objBusinessLayerUserRegisteration.Insert_EmpWelfare(objListEmpWelfare, objEntityEmpWelfr);
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMessage", "SuccessMessage();", true);


        }
        else
        {
            if (dtWelfareScvc.Rows.Count > 0)
            {

                string strHtmmm = ConvertDataTableToHTML(dtWelfareScvc, dtWelfar, count, uid);
                //Write to divReport
                divReport1.InnerHtml = strHtmmm;
                divwelfareSrevc.Attributes["style"] = "display:block;";
                divwelfareSrevc.Attributes["style"] = "border-color:Red;";
            }
            else
            {
                divwelfareSrevc.Attributes["style"] = "display:none;";
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "ValueNotFoundMessage", "ValueNotFoundMessage();", true);
        }
    }

    //Start:-Empcode
    public string empRefFormatLoad(int corpId)
    {
        clsEntityLayerUserRegistration objEntityUsrRegistr = new clsEntityLayerUserRegistration();
        objEntityUsrRegistr.UserCrprtId = corpId;
        DataTable dtRefFormat = objBusinessLayerUserRegisteration.ReadReferenceFormatEmp(objEntityUsrRegistr);
        string refFormatByDiv = "";
        string strRealFormat = "";


        if (dtRefFormat.Rows.Count != 0)
        {
            refFormatByDiv = dtRefFormat.Rows[0]["EMP_REF_FORMAT"].ToString();
            string strReferenceFormat = "";
            strReferenceFormat = refFormatByDiv;

            int flag = 0;
            string[] arrReferenceSplit = strReferenceFormat.Split('*');
            int intArrayRowCount = arrReferenceSplit.Length;
            for (int intRowCount = 0; intRowCount < intArrayRowCount; intRowCount++)
            {
                if (arrReferenceSplit[intRowCount] != "" && arrReferenceSplit[intRowCount] != null)
                {
                    if (arrReferenceSplit[intRowCount].Contains("#"))
                    {
                        string[] strSplitWithHash = arrReferenceSplit[intRowCount].Split('#');
                        int intArraySplitHashCount = strSplitWithHash.Length;
                        for (int intcount = 0; intcount < intArraySplitHashCount; intcount++)
                        {
                            if (strSplitWithHash[intcount] != "" && strSplitWithHash[intcount] != null)
                            {
                                if (strSplitWithHash[intcount] == "COR" || strSplitWithHash[intcount] == "USR" || strSplitWithHash[intcount] == "YER" || strSplitWithHash[intcount] == "MON")
                                {

                                }
                                else
                                {
                                    flag = 1;
                                }
                            }

                        }
                    }
                }
            }
            if (flag == 1)
            {
                refFormatByDiv = "#COR#*/*#USR#";
            }

            if (Request.QueryString["Id"] != null)
            {
                objEntityUsrRegistr.UsrRegistrationId = Convert.ToInt32(HiddenEmpUserId.Value);
                int intUserId = 0, UserOrgId = 0;
                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    UserOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                objEntityUsrRegistr.UserId = objEntityUsrRegistr.UsrRegistrationId;
                DataTable dtUsrMastr = objBusinessLayerUserRegisteration.ReadUsrMasterEdit(objEntityUsrRegistr);

                if (dtUsrMastr.Rows.Count > 0)
                {

                    HiddenFieldInsdate.Value = dtUsrMastr.Rows[0]["INSDATE"].ToString();
                }

                //EVM-0027

                if (refFormatByDiv == "" || refFormatByDiv == null)
                {
                    strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "0" + HiddenEmpUserId.Value; 
                }
                   
                else
                {  


                    clsCommonLibrary objCommon = new clsCommonLibrary();

                    DateTime dt = objCommon.textToDateTime(HiddenFieldInsdate.Value);

                    strRealFormat = refFormatByDiv.ToString();
                    if (strRealFormat.Contains("#COR#"))
                    {
                        strRealFormat = strRealFormat.Replace("#COR#", dtRefFormat.Rows[0]["CORPRT_CODE"].ToString());
                    }
                  
                    if (strRealFormat.Contains("#USR#"))
                    {
                        string uidFormtWithZero = "";
                        uidFormtWithZero = "0" + HiddenEmpUserId.Value;
                        strRealFormat = strRealFormat.Replace("#USR#",uidFormtWithZero );
                    }
                    if (strRealFormat.Contains("#YER#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YER#", dt.Year.ToString());
                    }

                    if (strRealFormat.Contains("#MON#"))
                    {
                        strRealFormat = strRealFormat.Replace("#MON#", dt.Month.ToString());

                    }
                    //EVM-0027
                    if (strRealFormat == "")
                    {
                        strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "0" + HiddenFieldNewNextId.Value;
                    }
                    //END
                    strRealFormat = strRealFormat.Replace("#", "");
                    strRealFormat = strRealFormat.Replace("*", "");
                    strRealFormat = strRealFormat.Replace("%", "");

                }

            }
            else
            {
                //EVM-0027
                if (refFormatByDiv == "" || refFormatByDiv == null)
                {
                    strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() +"0"+ HiddenFieldNewNextId.Value;
                }
                   
                else
                {
                    strRealFormat = refFormatByDiv.ToString();
                    if (strRealFormat.Contains("#COR#"))
                    {
                        strRealFormat = strRealFormat.Replace("#COR#", dtRefFormat.Rows[0]["CORPRT_CODE"].ToString());
                    }

                    if (strRealFormat.Contains("#USR#"))
                    {
                        string uidFormtWithZero = "";
                        uidFormtWithZero = "0" + HiddenFieldNewNextId.Value;
                        strRealFormat = strRealFormat.Replace("#USR#", uidFormtWithZero);
                    }
                    if (strRealFormat.Contains("#YER#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YER#", DateTime.Today.Year.ToString());
                    }

                    if (strRealFormat.Contains("#MON#"))
                    {
                        strRealFormat = strRealFormat.Replace("#MON#", DateTime.Today.Month.ToString());

                    }
                   

                    if (strRealFormat == "")
                    {
                        strRealFormat = dtRefFormat.Rows[0]["CORPRT_CODE"].ToString() + "0" + HiddenFieldNewNextId.Value;
                    }
                    //END
                    strRealFormat = strRealFormat.Replace("#", "");
                    strRealFormat = strRealFormat.Replace("*", "");
                    strRealFormat = strRealFormat.Replace("%", "");

                }
            }
        }
        return strRealFormat;
    }
    //End:-Empcode

    public void LoadPrimaryDivision(int DivisnCnt)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("<table id=\"tablePrimaryDivison\" cellspacing=\"0\" cellpadding=\"10px\" >");
        sb.Append("<tr>");

        for (int intRowBodyCount = 0; intRowBodyCount < DivisnCnt; intRowBodyCount++)
        {
            sb.Append("<td><div id=\"divradiodiv" + intRowBodyCount + "\">");
            sb.Append("<input type=\"checkbox\"  id=\"radioDivision" + intRowBodyCount + "\" name=\"radioDiv\"  onclick=\"return PrimaryChange(" + intRowBodyCount + ");\" title=\"Set as primary\" onkeypress=\"return DisableEnter(event);\" onkeydown=\"return DisableEnter(event);\" >");
            sb.Append("</td><td><label id=\"lblPrimary" + intRowBodyCount + "\" class=\"form2 divcls\" for=\"radioDivision" + intRowBodyCount + "\"></label>");
            sb.Append("</div></td>");
            sb.Append("</tr>");
        }
        sb.Append("</table>");

        divPrimaryDivision.InnerHtml = sb.ToString();
    }

    //evm-0023-20-2
    static DateTime currDateTime = DateTime.Now;
    protected void LeavTypLoad(string EmpId)
    {
         BL_Compzit.BusinessLayer_AWMS.clsBussinessLayerLeaveAllocationMaster objBusLevAllocn = new  BL_Compzit.BusinessLayer_AWMS.clsBussinessLayerLeaveAllocationMaster();
         EL_Compzit.EntityLayer_AWMS.clsEntityLayerLeaveAllocationMaster objEntLevAllocn = new EL_Compzit.EntityLayer_AWMS.clsEntityLayerLeaveAllocationMaster();

         int intUserId;
        
        if (Session["CORPOFFICEID"] != null)
        {
            objEntLevAllocn.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
  if (Session["ORGID"] != null)
  {
      objEntLevAllocn.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
  }
  else if (Session["USERID"] != null)
  {
      objEntLevAllocn.User_Id = Convert.ToInt32(Session["USERID"].ToString());
      intUserId = Convert.ToInt32(Session["USERID"].ToString());
  }
  else
  {
      Response.Redirect("~/Default.aspx");
  }
  clsCommonLibrary objCommon = new clsCommonLibrary();

  objEntLevAllocn.EmployeeId = Convert.ToInt32(EmpId);
  DataTable DtUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
  string UsrJoinDate = "", strJoinDate = "";
  if (DtUser.Rows.Count > 0)
  {
      strJoinDate = DtUser.Rows[0]["USR_JOINED_DATE"].ToString();

      if (strJoinDate == "")
      {
          DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
          if (DtgnUser.Rows.Count > 0)
          {
              strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
          }
          if (strJoinDate != "")
          {
              if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
              {
                  UsrJoinDate = strJoinDate;
              }
          }
      }
      else if ((objCommon.textToDateTime(strJoinDate) == DateTime.MinValue))
      {
          DataTable DtgnUser = objBusLevAllocn.ReadUserDetails(objEntLevAllocn);
          if (DtgnUser.Rows.Count > 0)
          {
              strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
          }
          if (strJoinDate != "")
          {
              if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
              {
                  UsrJoinDate = strJoinDate;
              }
          }
      }
      else
      {
          UsrJoinDate = strJoinDate;
      }
  }
  else
  {
      DataTable DtgnUser = objBusLevAllocn.ReadUserDetailsGnUser(objEntLevAllocn);
      if (DtgnUser.Rows.Count > 0)
      {
          strJoinDate = DtgnUser.Rows[0]["USR_JOIN_DATE"].ToString();
      }

      if (strJoinDate != "")
      {
          if ((objCommon.textToDateTime(strJoinDate) != DateTime.MinValue))
          {
              UsrJoinDate = strJoinDate;
          }
      }
  }
  DateTime dtCurrentDate = DateTime.Now;
  //  string UsrJoinDategnuser = DtUser.Rows[0]["EMPERDTL_JOIN_DATE"].ToString();
  //For experience
  decimal ExpYears = 0;
  int ExpChck = 0;

 
 clsBusiness_Leave_Type objBusinessLeave_Type = new clsBusiness_Leave_Type();
 clsEntity_Leave_Type objEntityLeave_Type = new clsEntity_Leave_Type();
 DataTable dtExpDtls = objBusinessLeave_Type.ReadExperienceByID(objEntityLeave_Type);
 if (UsrJoinDate != "")
  {
      DateTime Dob = objCommon.textToDateTime(UsrJoinDate);
      //ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
      ExpYears = (currDateTime.Month - Dob.Month) + 12 * (currDateTime.Year - Dob.Year);
      ExpYears = ExpYears / 12;
      //if (ExpYears != 0)
      //{
      for (int intRowCount = 0; intRowCount < dtExpDtls.Rows.Count; intRowCount++)
      {
          int intMinYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MIN_YEAR"]);
          int intMaxYear = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["EXPMASTR_MAX_YEAR"]);
          if (ExpYears >= intMinYear && ExpYears <= intMaxYear)
          {
              ExpChck = Convert.ToInt32(dtExpDtls.Rows[intRowCount]["LEAVDTLS_EXPMASTR_ID"]);
          }
      }
 
  }

  DataTable DtLevAlloDetails = new DataTable();
  DtLevAlloDetails = objBusLevAllocn.ReadLeavTypdtl(objEntLevAllocn, ExpChck);
  StringBuilder sb = new StringBuilder();
  sb.Append("<table class=\"main_table\" style=\"width:60%\" border=\"1\">");
  sb.Append("<tr class=\"main_table_head\">");
  sb.Append("<th class=\"thT\" style=\"width:40%;text-align: left;\"> Leave Type </th>");
  sb.Append("<th class=\"thT\" style=\"width:20%;text-align: left;\"> Number Of Days </th>");
  sb.Append("</tr>");


  for (int intRowBodyCount = 0; intRowBodyCount < DtLevAlloDetails.Rows.Count; intRowBodyCount++)
  {
      sb.Append("<tr>");
      sb.Append("<td class=\"tdT\">" + DtLevAlloDetails.Rows[intRowBodyCount]["LEAVETYP_NAME"].ToString() + "</td>");
      sb.Append("<td class=\"tdT\">" + DtLevAlloDetails.Rows[intRowBodyCount]["LEAVETYP_NUMDAYS"].ToString() + "</td>");
      sb.Append("</tr>");
  }
  sb.Append("</table>");
  sb.Append("<br/><br/>");
  divLeaveType.InnerHtml = sb.ToString();


    }
   
}