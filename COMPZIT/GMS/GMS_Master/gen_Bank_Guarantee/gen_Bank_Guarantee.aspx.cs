using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using EL_Compzit;
using System.Web.Services;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Web.Script.Services;


public partial class GMS_GMS_Master_gen_Bank_Guarantee_gen_Bank_Guarantee : System.Web.UI.Page
{
    clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();

    clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();


    protected void Page_Load(object sender, EventArgs e)
    {
        txtValidity.Enabled = false;
        //hiddenFileCanclDtlId.Value = "";
        hiddenFieldUserId.Value = "";
        cbxExistingEmployee.Attributes.Add("onkeypress", "IncrmntConfrmCounter()");
        txtGuarnteno.Attributes.Add("onkeypress", "return isTag(event)");
        txtGuarnteno.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtOpngDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtOpngDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPrjctClsngDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrjctClsngDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAmount.Attributes.Add("onkeypress", "return isTag(event)");
        txtCntctMail.Attributes.Add("onkeypress", "return isTag(event)");
        txtCntctMail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmpName.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmpName.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtadress.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtDescrptn.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtSubjct.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtValidity.Attributes.Add("onkeypress", "return isTag(event)");
        txtValidity.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtRemarks.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlCurrency.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCurrency.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //ddlSubContrct.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlSubContrct.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //ddlExistingEmp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlExistingEmp.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlBank.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlBank.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlOwnershp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlOwnershp.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlGuarntyp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlGuarntyp.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioLimited.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioOpen.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ScriptManager.RegisterStartupScript(this, GetType(), "AutocompleteEmp", "AutocompleteEmp();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "FocusOnDate", "FocusOnDate();", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "FocusDate", "FocusDate();", true);

        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null || Request.QueryString["Renew"] != null || Request.QueryString["ViewId"] != null)
            {
                ddlPolicyType.Enabled = false;
                ddlPolicyType.Items.FindByValue("1").Selected = true;
                LoadFunction_GUARNTEE();
            }
            else if (Request.QueryString["Id_INSRNC"] != null || Request.QueryString["Renew_INSRNC"] != null || Request.QueryString["ViewId_INSRNC"] != null)
            {
                ddlPolicyType.Enabled = false;
                ddlPolicyType.Items.FindByValue("2").Selected = true;
                LoadFunction_INSRNC();
            }
            else
            {
                LoadFunction_GUARNTEE();
                LoadFunction_INSRNC();
                hiddenAddPage.Value = "1";
            }
        }
    }

        //-------------------guarantee-----------------------

    public void LoadFunction_GUARNTEE()
    {
        //ScriptManager.RegisterStartupScript(this, GetType(), "FocusOnDate", "FocusOnDate();", true);
        hiddenRsnid.Value = "1";
        if (HiddenFieldChckUpdate.Value != "1")
        {
            radioClient.Checked = true;
        }
        radioOpen.Checked = true;
        LoadDdlForClientGtee();
        NotifyTempLoad();
        guaranteeModeLoad();
        SubContractLoad();
        BankLoad();
        CurrencyLoad();
        EmployeeLoad();
        CustomerLoad();


        DropDownEmployeeDataStore();
        DropdownDesignationDataStore();
        DropdownDivisionDataStore();
        HiddenFieldGuarntId.Value = "0";
        // CustomerLoad();
        // JobCategryLoad();

        //ddlGuaranteCat.Items.Insert(0, "--SELECT CATEGORY--");
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intUsrRolMstrIdprjct = 0;
        // radioOpen.Focus();
        if (radioClient.Checked == true)
        {
            ddlGuarntyp.Focus();
        }
        if (radioSuplier.Checked == true)
        {
            //txtGuarnteno.Focus();
            ddlGteeType.Focus();
        }
        imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";
        //  imgBtnClose.ImageUrl = "/Images/Icons/close guarantee.png";
        imgbtnReOpen.Visible = false;
        btnConfirm.Visible = false;
        btnrenew.Visible = false;
        HiddenFieldviewchck.Value = "";
        // hiddenRsnid.Value = "";
        HiddenFieldChckUpdate.Value = "0";
        hiddenFileCanclDtlId.Value = "";
        HiddenField2_FileUploadLnk.Value = "";
        HiddenSubContractSlct.Value = "";
        hiddenEditAttchmnt.Value = "";
        HiddenRenew.Value = "";
        HiddenFieldRequestCltId.Value = "";
        HiddenImportaddchk.Value = "";
        HiddenDuplictnchk.Value = "0";
        hiddenRoleAddProjct.Value = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
            HiddenUserId.Value = Session["USERID"].ToString();

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            HiddenOrgansId.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        int intEnableReOpen = 0, intEnableConfirm = 0, intEnableSuplier = 0, intEnableClient = 0, intEnableClose = 0, intEnableAdd1 = 0, intEnableAddContract = 0, intUsrRolMstrIdContract = 0;
        //Allocating child roles
        hiddenRoleAdd.Value = "0";
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Bank_Guarantee);
        intUsrRolMstrIdprjct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project);
        intUsrRolMstrIdContract = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);

        DataTable dtPrjct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdprjct);
        DataTable dtContractRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdContract);

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
                    hiddenRoleAdd.Value = intEnableAdd.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleReOpen.Value = intEnableReOpen.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleConfirm.Value = intEnableConfirm.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleClose.Value = intEnableConfirm.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Suplier_Guarantee_Permission).ToString())
                {
                    intEnableSuplier = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenFieldSuplier.Value = intEnableSuplier.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Client_Guarantee_Permission).ToString())
                {
                    intEnableClient = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    HiddenFieldClient.Value = intEnableClient.ToString();

                }
            }
        }
        if (dtContractRol.Rows.Count > 0)
        {
            string strChildRolDeftn1 = dtContractRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords1 = strChildRolDeftn1.Split('-');
            foreach (string strC_Role in strChildDefArrWords1)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intEnableAddContract = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                }
            }

        }
        if (intEnableAddContract != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnNewContract.Visible = false;
        }

        if (dtPrjct.Rows.Count > 0)
        {
            string strChildRolDeftn1 = dtPrjct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords1 = strChildRolDeftn1.Split('-');
            foreach (string strC_Role in strChildDefArrWords1)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intEnableAdd1 = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleAddProjct.Value = intEnableAdd1.ToString();
                }
            }

        }
        if (hiddenRoleAddProjct.Value == "")
        {
            btnNewProject.Visible = false;
        }

        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            if (intEnableSuplier == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
            }

            else if (intEnableClient == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

                btnAdd.Visible = true;
                btnAddClose.Visible = true;
            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                radioClient.Disabled = true;
            }

        }
        else
        {

            btnUpdate.Visible = false;

        }
        if (HiddenFieldSuplier.Value == "1" && HiddenFieldClient.Value == "1")
        {
            radioClient.Disabled = false;
            radioSuplier.Disabled = false;
            // btnConfirm.Visible = true;

        }
        else
        {
            if (HiddenFieldSuplier.Value == "1")
            {
                radioClient.Disabled = true;
                radioClient.Checked = false;
                // btnConfirm.Visible = true;
                radioSuplier.Checked = true;
            }

            else if (HiddenFieldClient.Value == "1")
            {
                radioSuplier.Disabled = true;
                //btnConfirm.Visible = true;
                radioClient.Checked = true;
                radioSuplier.Checked = false;
            }
            else
            {
                // btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                radioClient.Disabled = true;
                radioSuplier.Disabled = true;
            }
        }



        hiddenFilePath.Value = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
        //clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        DataTable dtGuarntAttchmnt = new DataTable();
        dtGuarntAttchmnt = ObjBussinessBankGuarnt.Read_Attachment(ObjEntityRequest);
        if (dtGuarntAttchmnt.Rows.Count > 0)
        {
            hiddenAttchmntSlNumber.Value = dtGuarntAttchmnt.Rows[0]["GRNTY_ATCH_SL_NUM"].ToString();
        }


        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        }

        // for adding comma
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        DataTable dtCurrencyDetail = new DataTable();
        dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        if (dtCurrencyDetail.Rows.Count > 0)
        {
            hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
        }

        //if (Request.QueryString["Close"] != null && Request.QueryString["Close"] != "")
        //{//when Canceled
        //    classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        //    string strRandomMixedId = Request.QueryString["Close"].ToString();
        //    string strLenghtofId = strRandomMixedId.Substring(0, 2);
        //    int intLenghtofId = Convert.ToInt16(strLenghtofId);
        //    string strId = strRandomMixedId.Substring(2, intLenghtofId);

        //    ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strId);
        //    ObjEntityRequest.User_Id = intUserId;
        //    ObjEntityRequest.D_Date = System.DateTime.Now;
        //    hiddenRsnid.Value = strId;

        //}



        cbxPrjct.Checked = true;

        cbxExistingEmployee.Checked = true;
        //when editing 
        if (Request.QueryString["Id"] != null)
        {
            btnClear.Visible = false;
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            Update(strId, intCorpId);
            lblEntry.Text = "Edit Bank Guarantee";

            if (hiddenRoleAdd.Value.ToString() != "")
            {
                if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate.Visible = false;
                }
            }

            if (hiddenRoleClose.Value.ToString() != "")
            {
                if (Convert.ToInt32(hiddenRoleClose.Value.ToString()) != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    // imgBtnClose.Visible = false;
                }
            }
        }

        else if (Request.QueryString["Renew"] != null)
        {
            btnNewProject.Visible = false;
            HiddenRenew.Value = "1";
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnAdd.Visible = false;
            btnAddClose.Visible = false;
            btnrenew.Visible = true;
            btnClear.Visible = false;
            string strRandomMixedId = Request.QueryString["Renew"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityRequest.GuaranteeId = Convert.ToInt32(strId);
            ObjEntityRequest.User_Id = intUserId;

            ObjEntityRequest.D_Date = System.DateTime.Now;

            //  ObjBussinessBankGuarnt.RenewBankGuarantee(ObjEntityRequest);

            imgbtnReOpen.Visible = false;
            View(strId, intCorpId);

            lblEntry.Text = "Renew Bank Guarantee";
            hiddenEditMode.Value = "View";
            //  hiddenConfirmOrNot.Value = "1";
            // imgBtnClose.Visible = false;
        }
        //when  viewing
        else if (Request.QueryString["ViewId"] != null)
        {
            btnNewProject.Visible = false;
            btnNewContract.Visible = false;
            btnClear.Visible = false;
            string strRandomMixedId = Request.QueryString["ViewId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            View(strId, intCorpId);

            lblEntry.Text = "View Bank Guarantee";
            hiddenConfirmOrNot.Value = "1";
            // imgBtnClose.Visible = false;
            hiddenEditMode.Value = "View";
        }
        else
        {
            //LoadDdlForClientGtee();
            lblEntry.Text = "Add Bank Guarantee";

            DefaultTemplateLoad();



            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Bank_Guarantee);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            string year = DateTime.Today.Year.ToString();
            LabelRefnum.Text = "BNKGUARNT/" + year + "/" + strNextId;
            hiddenFieldRefNumber.Value = "BNKGUARNT/" + year + "/" + strNextId;

            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnAdd.Visible = true;
            btnAddClose.Visible = true;
            btnClear.Visible = true;
            DataTable dtClientGurnt = new DataTable();
            dtClientGurnt = ObjBussinessBankGuarnt.ReadRequesClienttGuaranteeList(ObjEntityRequest);

            string strHtm = ConvertDataTableToHTML(dtClientGurnt);
            // ScriptManager.RegisterStartupScript(this, GetType(), "CraeteTable", "CraeteTable(" + strHtm + ");", true);
            //Write to divReport
            // divReport.InnerHtml = strHtm;



            // imgBtnClose.Visible = false;
        }
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
            else if (strInsUpd == "Cnfrm")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm", "SuccessConfirm();", true);
            }
            else if (strInsUpd == "ReOpen")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen", "SuccessReOpen();", true);
            }
            else if (strInsUpd == "Renewd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessGuaranteeRenewed", "SuccessGuaranteeRenewed();", true);
            }
            else if (strInsUpd == "PrjIns")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrjct", "SuccessConfirmationPrjct();", true);
            }
            else if (strInsUpd == "PrjUpd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrjct", "SuccessUpdationPrjct();", true);
            }
        }
        // created object for business layer for compare the date
        string strCurrentDate = objBusiness.LoadCurrentDateInString();

        hiddenCurrentDate.Value = strCurrentDate;
    }


    public void CustomerLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadCustomerLoad(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlSuplCus.DataSource = dtSubConrt;
            ddlSuplCus.DataTextField = "CSTMR_NAME";
            ddlSuplCus.DataValueField = "CSTMR_ID";
            ddlSuplCus.DataBind();


        }

        ddlSuplCus.Items.Insert(0, "--SELECT--");

    }
    public void guaranteeModeLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtGuarantMod = ObjBussinessBankGuarnt.GuaranteeModeList(ObjEntityRequest);

        DataTable dtGuarantModClient = ObjBussinessBankGuarnt.GuaranteeModeClient(ObjEntityRequest);
        if (dtGuarantMod.Rows.Count > 0)
        {
            ddlGuarntyp.DataSource = dtGuarantMod;
            ddlGuarntyp.DataTextField = "GUANTCAT_NAME";
            ddlGuarntyp.DataValueField = "GUANTCAT_ID";
            ddlGuarntyp.DataBind();


        }
        if (dtGuarantModClient.Rows.Count > 0)
        {
            ddlGuaranteeMde.DataSource = dtGuarantModClient;
            ddlGuaranteeMde.DataTextField = "GUANTCAT_NAME";
            ddlGuaranteeMde.DataValueField = "GUANTCAT_ID";
            ddlGuaranteeMde.DataBind();

        }

        ddlGuarntyp.Items.Insert(0, "--SELECT GUARANTEE MODE--");
        ddlGuaranteeMde.Items.Insert(0, "--SELECT GUARANTEE MODE--");
    }

    public void SubContractLoad(int intSubContract = 0)
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadSubContract(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlSubContrct.DataSource = dtSubConrt;
            ddlSubContrct.DataTextField = "CNTRCT_NAME";
            ddlSubContrct.DataValueField = "CNTRCT_ID";
            ddlSubContrct.DataBind();

        }

        ddlSubContrct.Items.Insert(0, "--SELECT SUB-CONTRACT--");

        if (ddlSubContrct.Items.FindByValue(intSubContract.ToString()) != null)
        {
            ddlSubContrct.ClearSelection();
            ddlSubContrct.Items.FindByValue(intSubContract.ToString()).Selected = true;
        }
    }
    public void BankLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadBankLoad(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlBank.DataSource = dtSubConrt;
            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataValueField = "BANK_ID";
            ddlBank.DataBind();


        }

        ddlBank.Items.Insert(0, "--SELECT BANK--");


    }
    public void CurrencyLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadCurrency(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        DataTable dtDefaultcurc = ObjBussinessBankGuarnt.ReadDefualtCurrency(ObjEntityRequest);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy)!=null)
        ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }


    public void EmployeeLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadEmployee(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlOwnershp.DataSource = dtSubConrt;
            ddlOwnershp.DataTextField = "USR_NAME";
            ddlOwnershp.DataValueField = "USR_ID";
            ddlOwnershp.DataBind();
            ddlExistingEmp.DataSource = dtSubConrt;
            ddlExistingEmp.DataTextField = "USR_NAME";
            ddlExistingEmp.DataValueField = "USR_ID";
            ddlExistingEmp.DataBind();
        }

        ddlOwnershp.Items.Insert(0, "--SELECT EMPLOYEE--");
        ddlExistingEmp.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    //notification template dropdown fill
    public void NotifyTempLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtTemplate = ObjBussinessBankGuarnt.ReadNotifyTemplates(ObjEntityRequest);
        if (dtTemplate.Rows.Count > 0)
        {
            ddlTemplate.DataSource = dtTemplate;
            ddlTemplate.DataTextField = "NOTFTEMP_NAME";
            ddlTemplate.DataValueField = "NOTFTEMP_ID";
            ddlTemplate.DataBind();

        }
        else
        {

            ddlTemplate.Items.Insert(0, "--SELECT TEMPLATE--");
        }
    }
   
    protected void ddlSubContrct_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubContrctSelIndexChange();
    }
 
    public void ddlSubContrctSelIndexChange()
    {
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();
        DropDownEmployeeDataStore();
        DropdownDesignationDataStore();
        DropdownDivisionDataStore();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (ddlSubContrct.SelectedItem.Value.ToString() != "--SELECT SUB-CONTRACT--")
        {
            ObjEntityBnkGurnt.SubContractId = Convert.ToInt32(ddlSubContrct.SelectedItem.Value);
        }
        DataTable dtCusAddress = ObjBussinessBankGuarnt.ReadcusAddress(ObjEntityBnkGurnt);
        string intprojctid = "", intCustmrid = "";
        if (dtCusAddress.Rows.Count > 0)
        {
            txtadress.Text = dtCusAddress.Rows[0]["CSTMR_ADDRESS1"].ToString();
            LblProject.Text = dtCusAddress.Rows[0]["PROJECT_NAME"].ToString();
            HiddenFieldPRJCTID.Value = dtCusAddress.Rows[0]["PROJECT_ID"].ToString();
            intprojctid = dtCusAddress.Rows[0]["PROJECT_ID"].ToString();
            intCustmrid = dtCusAddress.Rows[0]["CSTMR_ID"].ToString();
            LabelCustmrContrctr.Text = dtCusAddress.Rows[0]["CSTMR_NAME"].ToString();
            HiddenFieldCustmor.Value = dtCusAddress.Rows[0]["CSTMR_ID"].ToString();
            HiddenSubContractSlct.Value = "1";

        }
        else
        {
            txtadress.Text = "";
            LblProject.Text = "";
            LabelCustmrContrctr.Text = "";
            ScriptManager.RegisterStartupScript(this, GetType(), "RadioSupplierClick", "RadioSupplierClick();", true);

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "FocusOnPostSubContrct", "FocusOnPostSubContrct(" + intprojctid + "," + intCustmrid + ");", true);
        ScriptManager.RegisterStartupScript(this, GetType(), "FocusOnDate", "FocusOnDate();", true);

    }
    [WebMethod]
    public static string[] CallExistEmpChange(int OrgId, int CorpId, int EmpId)
    {
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        string[] Address = new string[2];

        ObjEntityRequest.Organisation_Id = OrgId;
        ObjEntityRequest.CorpOffice_Id = CorpId;
        ObjEntityRequest.EmployeId = EmpId;
        DataTable dtEmploye = ObjBussinessBankGuarnt.ReadEmployeeData(ObjEntityRequest);
        if (dtEmploye.Rows.Count > 0)
        {
            Address[0] = dtEmploye.Rows[0]["USR_EMAIL"].ToString();
            Address[1] = Convert.ToString(dtEmploye.Rows[0]["USR_ID"].ToString());
        }

        return Address;
    }

    //protected void ddlExistingEmp_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();
    //    DropDownEmployeeDataStore();
    //    DropdownDesignationDataStore();
    //    DropdownDivisionDataStore();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (ddlExistingEmp.SelectedItem.Value.ToString() != "--SELECT EMPLOYEE--")
    //    {
    //        ObjEntityBnkGurnt.EmployeId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
    //    }
    //    DataTable dtEmploye = ObjBussinessBankGuarnt.ReadEmployeeData(ObjEntityBnkGurnt);
    //    string strEmail = "";
    //    if (dtEmploye.Rows.Count > 0)
    //    {
    //        txtCntctMail.Text = dtEmploye.Rows[0]["USR_EMAIL"].ToString();
    //        strEmail = dtEmploye.Rows[0]["USR_EMAIL"].ToString();
    //        hiddenFieldUserId.Value = Convert.ToString(dtEmploye.Rows[0]["USR_ID"].ToString());
    //    }
    //    // ddlExistingEmp.Focus();
    //    ScriptManager.RegisterStartupScript(this, GetType(), "FocusOnPostBckEmp", "FocusOnPostBckEmp('" + strEmail + "');", true);
    //}


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            ObjEntityBnkGurnt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        //Status checkbox checked

        int intRequestId = 0;
        int intnoofDays = 0;

        if (radioClient.Checked == true)
        {
            ObjEntityBnkGurnt.Guarantee_Method = 101;



            if (HiddenImportaddchk.Value == "1")
            {
                ObjEntityBnkGurnt.ReqstGrntId = Convert.ToInt32(HiddenFieldRequestCltId.Value);
                intRequestId = Convert.ToInt32(HiddenFieldRequestCltId.Value);

                ObjEntityBnkGurnt.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
                ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
                ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(HiddenFieldMode.Value);

                // ObjEntityBnkGurnt.Contrctr =null ;
                ObjEntityBnkGurnt.Customer = Convert.ToInt32(HiddenFieldCustmor.Value);


                ObjEntityBnkGurnt.Currency = Convert.ToInt32(HiddenFieldCurrcy.Value);


                //ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text);
                //ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
            }
            else
            {
                if (HiddenFieldAmount.Value.Trim() != "")
                {
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
                }
                if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);

                }

                if (cbxPrjct.Checked == true)
                {
                    if (HiddenProjctsave.Value != "0")
                    {
                        ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenProjctsave.Value);
                    }
                }
                else
                {
                    ObjEntityBnkGurnt.ProjectName = txtPrjctName.Text.Trim();
                }


                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                {
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                }
                if (ddlCustomerList.SelectedItem.Value != "--SELECT CUSTOMER--")
                {
                    ObjEntityBnkGurnt.Customer = Convert.ToInt32(ddlCustomerList.SelectedItem.Value);
                }
            }

        }
        else if (radioSuplier.Checked == true)
        {
            ObjEntityBnkGurnt.Guarantee_Method = 102;
            if (ddlGuarntyp.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
            {
                ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGuarntyp.SelectedItem.Value);

            }
            if (ddlSubContrct.SelectedItem.Value.ToString() != "--SELECT SUB-CONTRACT--")
            {
                ObjEntityBnkGurnt.SubContractId = Convert.ToInt32(ddlSubContrct.SelectedItem.Value);
            }
            if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }
            ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());

            ObjEntityBnkGurnt.Contrctr = Convert.ToInt32(HiddenFieldCustmor.Value);
            ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
            //Convert.ToInt32( LblProject.Text.Trim());
            //ObjEntityBnkGurnt.Customer = null;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Bank_Guarantee);
        objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
        objEntityCommon.Organisation_Id = ObjEntityBnkGurnt.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        ObjEntityBnkGurnt.NextIdForRqst = Convert.ToInt32(strNextId);
        HiddenBankGuarenteeId.Value = Convert.ToString(ObjEntityBnkGurnt.NextIdForRqst);
        ObjEntityBnkGurnt.RefNumber = hiddenFieldRefNumber.Value;
        ObjEntityBnkGurnt.GuaranteeNo = txtGuarnteno.Text.Trim();

        //Convert.ToInt32(LblProject.Text.Trim());
        if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
        {
            ObjEntityBnkGurnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
        }
        if (radioOpen.Checked == true)
        {
            ObjEntityBnkGurnt.GuarTypeId = 101;
            ObjEntityBnkGurnt.ExpireDate = DateTime.MinValue;
        }
        else if (radioLimited.Checked == true)
        {
            ObjEntityBnkGurnt.GuarTypeId = 102;
            ObjEntityBnkGurnt.GuaranteeNoDays = Convert.ToInt32(HiddenValidatedays.Value);
            intnoofDays = Convert.ToInt32(HiddenTextValidty.Value);

            ObjEntityBnkGurnt.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
        }
        ObjEntityBnkGurnt.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());
        if (HiddenOwnership.Value != "" && HiddenOwnership.Value != "--SELECT EMPLOYEE--")
        {
            ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(HiddenOwnership.Value);
        }
        //if (ddlOwnershp.SelectedItem.Value != "--SELECT EMPLOYEE--")
        //{
        //    ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(ddlOwnershp.SelectedItem.Value);
        //}
        if (cbxDontNotify.Checked == true)
        {
            ObjEntityBnkGurnt.DontNotify = 1;
        }
        else
        {
            ObjEntityBnkGurnt.DontNotify = 0;
        }

        ObjEntityBnkGurnt.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
        // ObjEntityBnkGurnt.CustomerContrctr = Convert.ToInt32(LabelCustmrContrctr.Text.Trim());
        ObjEntityBnkGurnt.Address = txtadress.Text.Trim();
        ObjEntityBnkGurnt.Subject = txtSubjct.Text.Trim();
        ObjEntityBnkGurnt.Description = txtDescrptn.Text.Trim();
        ObjEntityBnkGurnt.Remarks = txtRemarks.Text.Trim();
        if (cbxExistingEmployee.Checked == true)
        {
            if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                ObjEntityBnkGurnt.EmployeName = ddlExistingEmp.SelectedItem.Text;
                ObjEntityBnkGurnt.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);

            }
        }
        else
        {
            ObjEntityBnkGurnt.EmployeName = txtEmpName.Text.Trim();
        }
        if (hiddenFieldUserId.Value != "")
        {
            //ObjEntityBnkGurnt.ContactPersnUsrId=Convert.ToInt32(hiddenFieldUserId.Value);
        }
        ObjEntityBnkGurnt.Email = txtCntctMail.Text.Trim();

        ObjEntityBnkGurnt.D_Date = System.DateTime.Now;

        string strGurntNo = "", strReqstId = "";
        strReqstId = ObjBussinessBankGuarnt.ChckDupReqstId(ObjEntityBnkGurnt);




        strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityBnkGurnt);
        if (strReqstId == "" || strReqstId == "0")
        {

            if (strGurntNo == "" || strGurntNo == "0")
            {
                ObjBussinessBankGuarnt.AddBankGuarantee(ObjEntityBnkGurnt);

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
                //string strNextNum = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerGuaranteeAttachments>();

                int intSlNumbr = 0;
                if (hiddenAttchmntSlNumber.Value != "")
                {
                    intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                    intSlNumbr++;

                }
                if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                {
                    string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");
                    List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                    //   UserData  data
                    objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);


                    foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                    {

                        //if (intCount == Intcountchk)
                        //{

                        if (objClsBannrAddAttData.EVTACTION == "INS")
                        {
                            string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                            HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityLayerGuaranteeAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);

                                objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                                int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                                objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                objEntityLayerGuarnteeAtchmntDtl.GuarenteeId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                intSlNumbr++;
                            }


                        }
                    }
                }
                List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuaranteeAtchmntDtlListDelete = new List<clsEntityLayerGuaranteeAttachments>();
                if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                {
                    string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");
                    List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                    //   UserData  data
                    objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);


                    foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                    {

                        clsEntityLayerGuaranteeAttachments objEntityLayerGuaranteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();

                        objEntityLayerGuaranteeAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                        objEntityLayerGuaranteeAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);

                        objEntityLayerGuaranteeAtchmntDtlListDelete.Add(objEntityLayerGuaranteeAtchmntDtl);

                    }

                }

                if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                {

                    ObjBussinessBankGuarnt.Add_Pictures(ObjEntityBnkGurnt, objEntityLayerGuarenteeAtchmntDtlList);
                }
                if (objEntityLayerGuaranteeAtchmntDtlListDelete.Count > 0)
                {
                    ObjBussinessBankGuarnt.Delete_Pictures(ObjEntityBnkGurnt, objEntityLayerGuaranteeAtchmntDtlListDelete);

                    //Delete from location
                    foreach (clsEntityLayerGuaranteeAttachments objEntityLayerIGuaranteeAtchmntDtl in objEntityLayerGuaranteeAtchmntDtlListDelete)
                    {

                        string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                        string imageLocation = strImgPath + objEntityLayerIGuaranteeAtchmntDtl.FileName;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }

                }

                //for inserting template

                int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                string strEachTempTotalString = hiddenEachSliceData.Value;
                string strNotifyMode = hiddenNotificationMOde.Value;
                string strNotifyVia = hiddenNotifyVia.Value;
                string strNotifyDur = hiddenNotificationDuration.Value;
                int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                string[] strEachTempString = new string[TempCount];
                strEachTempString = strEachTempTotalString.Split('!');

                //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
                for (int intCount = 0; intCount < TempCount; intCount++)
                {
                    BnkGrntyTemplateDetail objEntityTempDeatils = new BnkGrntyTemplateDetail();

                    //for template mode
                    string jsonDataNotyMod = strNotifyMode;
                    string a = jsonDataNotyMod.Replace("\"{", "\\{");
                    string b = a.Replace("\\n", "\r\n");
                    string c = b.Replace("\\", "");
                    string d = c.Replace("}\"]", "}]");
                    string k = d.Replace("}\",", "},");

                    List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                    objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                    string MODEROWID = objEachTempDetModList[intCount].ROWID;
                    string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                    string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                    if (NOTMODE == "D")
                    {
                        objEntityTempDeatils.TempDetPeriod = 2;
                    }
                    else
                    {
                        objEntityTempDeatils.TempDetPeriod = 1;
                    }

                    //for template NotifyVia
                    string jsonDataNotyVia = strNotifyVia;
                    string l = jsonDataNotyVia.Replace("\"{", "\\{");
                    string m = l.Replace("\\n", "\r\n");
                    string n = m.Replace("\\", "");
                    string o = n.Replace("}\"]", "}]");
                    string p = o.Replace("}\",", "},");

                    List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                    objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                    string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                    string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                    string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                    if (VIAWHT.Contains("D"))
                    {
                        objEntityTempDeatils.IsDashBoard = 1;
                    }
                    if (VIAWHT.Contains("E"))
                    {
                        objEntityTempDeatils.IsEmail = 1;
                    }

                    //for template notify Duration
                    string jsonDataNotyDur = strNotifyDur;
                    string q = jsonDataNotyDur.Replace("\"{", "\\{");
                    string r = q.Replace("\\n", "\r\n");
                    string s = r.Replace("\\", "");
                    string t = s.Replace("}\"]", "}]");
                    string u = t.Replace("}\",", "},");

                    List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                    objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                    string DURROWID = objEachTempDetDurList[intCount].ROWID;
                    string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                    string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                    objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                    string jsonData = strEachTempString[intCount + 1];
                    string V = jsonData.Replace("\"{", "\\{");
                    string W = V.Replace("\\n", "\r\n");
                    string X = W.Replace("\\", "");
                    string Y = X.Replace("}\"]", "}]");
                    string Z = Y.Replace("}\",", "},");

                    List<BnkGrntyTemplateAlert> objEntityTempAlertList = new List<BnkGrntyTemplateAlert>();


                    List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                    objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                    if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                    {

                        for (int count = 0; count < objEachTempDetList.Count; count++)
                        {
                            string ROWID = objEachTempDetList[count].ROWID;

                            string VALUE = objEachTempDetList[count].DDLVALUE;
                            string DDLMODE = objEachTempDetList[count].DDLMODE;
                            string DTLID = objEachTempDetList[count].DTLID;
                            if (VALUE != "0")
                            {
                                BnkGrntyTemplateAlert objEntityTemplateAlert = new BnkGrntyTemplateAlert();
                                if (DDLMODE == "ddlDivision_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 0;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "ddlDesignation_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 1;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "ddlEmployee_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 2;
                                    objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                }
                                else if (DDLMODE == "txtGenMail_")
                                {
                                    objEntityTemplateAlert.TemplateAlertOptId = 3;
                                    objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                }


                                objEntityTempAlertList.Add(objEntityTemplateAlert);
                            }
                        }

                    }
                    //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                    ObjBussinessBankGuarnt.AddTemplateDetail(ObjEntityBnkGurnt, objEntityTempDeatils, objEntityTempAlertList);
                }



                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Bank_Guarantee.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Ins");
                }
            }
            else
            {
                if (ObjEntityBnkGurnt.ReqstGrntId == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Duplicationx", "Duplicationx('" + intRequestId + "','" + intnoofDays + "');", true);
                }
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationRequestId", "DuplicationRequestId();", true);
        }


    }
    public class clsEachTempDeatail
    {
        public string DDLVALUE { get; set; }
        public string ROWID { get; set; }
        public string DDLMODE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
    }

    public class clsEachTempNotyMOde
    {
        public string ROWID { get; set; }
        public string NOTMODE { get; set; }
        public string TEMPID { get; set; }
    }
    public class clsEachTempNotyVia
    {
        public string ROWID { get; set; }
        public string NOTVIA { get; set; }
        public string TEMPID { get; set; }
    }
    public class clsEachTempNotyDur
    {
        public string ROWID { get; set; }
        public string NOTDUR { get; set; }
        public string TEMPID { get; set; }
    }


    public class clsEachAlertDel
    {
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                ObjEntityBnkGurnt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }
            //string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(strReqForIdId);
            ObjEntityBnkGurnt.RefNumber = HiddenFieldRefNumber2.Value;

            if (radioClient.Checked == true)
            {
                ObjEntityBnkGurnt.Guarantee_Method = 101;
                //if RFG imported Gtee
                if (HiddenRFGImportedGtee.Value == "1")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(HiddenFieldMode.Value);
                    // ObjEntityBnkGurnt.Contrctr =null ;
                    ObjEntityBnkGurnt.Customer = Convert.ToInt32(HiddenFieldCustmor.Value);
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(HiddenFieldCurrcy.Value);
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
                    ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
                    ObjEntityBnkGurnt.ReqstGrntId = Convert.ToInt32(HiddenFieldRequestCltId.Value);
                }
                else
                {
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
                    if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);

                    }
                    //if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--")
                    //{
                    //    ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                    //}

                    if (cbxPrjct.Checked == true)
                    {
                        if (HiddenProjctsave.Value != "0")
                        {
                            ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenProjctsave.Value);
                        }
                    }
                    else
                    {
                        ObjEntityBnkGurnt.ProjectName = txtPrjctName.Text.Trim();
                    }
                    if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                    {
                        ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                    }
                    if (ddlCustomerList.SelectedItem.Value != "--SELECT CUSTOMER--")
                    {
                        ObjEntityBnkGurnt.Customer = Convert.ToInt32(ddlCustomerList.SelectedItem.Value);
                    }
                }
            }
            else if (radioSuplier.Checked == true)
            {
                ObjEntityBnkGurnt.Guarantee_Method = 102;
                if (ddlGuarntyp.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGuarntyp.SelectedItem.Value);

                }
                if (ddlSubContrct.SelectedItem.Value.ToString() != "--SELECT SUB-CONTRACT--")
                {
                    ObjEntityBnkGurnt.SubContractId = Convert.ToInt32(ddlSubContrct.SelectedItem.Value);
                }
                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                {
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                }
                ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());


                ObjEntityBnkGurnt.Contrctr = Convert.ToInt32(HiddenFieldCustmor.Value);
                ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);

            }

            ObjEntityBnkGurnt.GuaranteeNo = txtGuarnteno.Text.Trim();

            if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
            {
                ObjEntityBnkGurnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            }
            if (radioOpen.Checked == true)
            {
                ObjEntityBnkGurnt.GuarTypeId = 101;
                ObjEntityBnkGurnt.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited.Checked == true)
            {
                ObjEntityBnkGurnt.GuarTypeId = 102;
                ObjEntityBnkGurnt.GuaranteeNoDays = Convert.ToInt32(HiddenTextValidty.Value);

                ObjEntityBnkGurnt.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            }
            ObjEntityBnkGurnt.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());
            if (HiddenOwnership.Value != "" && HiddenOwnership.Value != "--SELECT EMPLOYEE--")
            {
                ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(HiddenOwnership.Value);
            }
            //if (ddlOwnershp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            //{
            // ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(ddlOwnershp.SelectedItem.Value);
            //}
            if (cbxDontNotify.Checked == true)
            {
                ObjEntityBnkGurnt.DontNotify = 1;
            }
            else
            {
                ObjEntityBnkGurnt.DontNotify = 0;
            }

            ObjEntityBnkGurnt.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);

            // ObjEntityBnkGurnt.CustomerContrctr = Convert.ToInt32(LabelCustmrContrctr.Text.Trim());
            ObjEntityBnkGurnt.Address = txtadress.Text.Trim();
            ObjEntityBnkGurnt.Subject = txtSubjct.Text.Trim();
            ObjEntityBnkGurnt.Description = txtDescrptn.Text.Trim();
            ObjEntityBnkGurnt.Remarks = txtRemarks.Text.Trim();
            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    ObjEntityBnkGurnt.EmployeName = ddlExistingEmp.SelectedItem.Text;
                    ObjEntityBnkGurnt.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);

                }
            }
            else
            {
                ObjEntityBnkGurnt.EmployeName = txtEmpName.Text.Trim();
            }
            if (hiddenFieldUserId.Value != "")
            {
                //ObjEntityBnkGurnt.ContactPersnUsrId=Convert.ToInt32(hiddenFieldUserId.Value);
            }
            ObjEntityBnkGurnt.Email = txtCntctMail.Text.Trim();

            ObjEntityBnkGurnt.D_Date = System.DateTime.Now;
            string strGurntNo = "";

            strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityBnkGurnt);
            if (strGurntNo == "" || strGurntNo == "0")
            {

                ObjBussinessBankGuarnt.UpdateBankGuarantee(ObjEntityBnkGurnt);

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
                //string strNextNum = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerGuaranteeAttachments>();

                int intSlNumbr = 0;
                if (hiddenAttchmntSlNumber.Value != "")
                {
                    intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                    intSlNumbr++;

                }
                if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                {
                    string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");
                    List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                    //   UserData  data
                    objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);


                    foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                    {

                        //if (intCount == Intcountchk)
                        //{

                        if (objClsBannrAddAttData.EVTACTION == "INS")
                        {
                            string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                            HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityLayerGuaranteeAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);

                                objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                                int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                                objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                objEntityLayerGuarnteeAtchmntDtl.GuarenteeId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                intSlNumbr++;
                            }


                        }
                    }
                }
                List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuaranteeAtchmntDtlListDelete = new List<clsEntityLayerGuaranteeAttachments>();
                if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                {
                    string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");
                    List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                    //   UserData  data
                    objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);


                    foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                    {

                        clsEntityLayerGuaranteeAttachments objEntityLayerGuaranteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();

                        objEntityLayerGuaranteeAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                        objEntityLayerGuaranteeAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);

                        objEntityLayerGuaranteeAtchmntDtlListDelete.Add(objEntityLayerGuaranteeAtchmntDtl);

                    }

                }

                if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                {

                    ObjBussinessBankGuarnt.Add_Pictures(ObjEntityBnkGurnt, objEntityLayerGuarenteeAtchmntDtlList);
                }
                if (objEntityLayerGuaranteeAtchmntDtlListDelete.Count > 0)
                {
                    ObjBussinessBankGuarnt.Delete_Pictures(ObjEntityBnkGurnt, objEntityLayerGuaranteeAtchmntDtlListDelete);

                    //Delete from location
                    foreach (clsEntityLayerGuaranteeAttachments objEntityLayerIGuaranteeAtchmntDtl in objEntityLayerGuaranteeAtchmntDtlListDelete)
                    {

                        string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                        string imageLocation = strImgPath + objEntityLayerIGuaranteeAtchmntDtl.FileName;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }

                }
                ObjEntityBnkGurnt.NextIdForRqst = ObjEntityBnkGurnt.GuaranteeId;
                if (hiddenTemplateChange.Value == "CHANGED")
                {
                    ObjBussinessBankGuarnt.DeleteTemplateAlertByGr(ObjEntityBnkGurnt);
                    ObjBussinessBankGuarnt.DeleteTemplateDetByGr(ObjEntityBnkGurnt);



                    //for inserting template

                    int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                    string strEachTempTotalString = hiddenEachSliceData.Value;
                    string strNotifyMode = hiddenNotificationMOde.Value;
                    string strNotifyVia = hiddenNotifyVia.Value;
                    string strNotifyDur = hiddenNotificationDuration.Value;
                    int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                    string[] strEachTempString = new string[TempCount];
                    strEachTempString = strEachTempTotalString.Split('!');

                    //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
                    for (int intCount = 0; intCount < TempCount; intCount++)
                    {
                        BnkGrntyTemplateDetail objEntityTempDeatils = new BnkGrntyTemplateDetail();

                        //for template mode
                        string jsonDataNotyMod = strNotifyMode;
                        string a = jsonDataNotyMod.Replace("\"{", "\\{");
                        string b = a.Replace("\\n", "\r\n");
                        string c = b.Replace("\\", "");
                        string d = c.Replace("}\"]", "}]");
                        string k = d.Replace("}\",", "},");

                        List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                        objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                        string MODEROWID = objEachTempDetModList[intCount].ROWID;
                        string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                        string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                        if (NOTMODE == "D")
                        {
                            objEntityTempDeatils.TempDetPeriod = 2;
                        }
                        else
                        {
                            objEntityTempDeatils.TempDetPeriod = 1;
                        }

                        //for template NotifyVia
                        string jsonDataNotyVia = strNotifyVia;
                        string l = jsonDataNotyVia.Replace("\"{", "\\{");
                        string m = l.Replace("\\n", "\r\n");
                        string n = m.Replace("\\", "");
                        string o = n.Replace("}\"]", "}]");
                        string p = o.Replace("}\",", "},");

                        List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                        objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                        string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                        string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                        string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                        if (VIAWHT.Contains("D"))
                        {
                            objEntityTempDeatils.IsDashBoard = 1;
                        }
                        if (VIAWHT.Contains("E"))
                        {
                            objEntityTempDeatils.IsEmail = 1;
                        }

                        //for template notify Duration
                        string jsonDataNotyDur = strNotifyDur;
                        string q = jsonDataNotyDur.Replace("\"{", "\\{");
                        string r = q.Replace("\\n", "\r\n");
                        string s = r.Replace("\\", "");
                        string t = s.Replace("}\"]", "}]");
                        string u = t.Replace("}\",", "},");

                        List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                        objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                        string DURROWID = objEachTempDetDurList[intCount].ROWID;
                        string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                        string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                        objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                        string jsonData = strEachTempString[intCount + 1];
                        string V = jsonData.Replace("\"{", "\\{");
                        string W = V.Replace("\\n", "\r\n");
                        string X = W.Replace("\\", "");
                        string Y = X.Replace("}\"]", "}]");
                        string Z = Y.Replace("}\",", "},");

                        List<BnkGrntyTemplateAlert> objEntityTempAlertList = new List<BnkGrntyTemplateAlert>();


                        List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                        objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                        if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                        {

                            for (int count = 0; count < objEachTempDetList.Count; count++)
                            {
                                string ROWID = objEachTempDetList[count].ROWID;

                                string VALUE = objEachTempDetList[count].DDLVALUE;
                                string DDLMODE = objEachTempDetList[count].DDLMODE;
                                string DTLID = objEachTempDetList[count].DTLID;
                                if (VALUE != "0")
                                {
                                    BnkGrntyTemplateAlert objEntityTemplateAlert = new BnkGrntyTemplateAlert();
                                    if (DDLMODE == "ddlDivision_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 0;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlDesignation_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 1;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlEmployee_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 2;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "txtGenMail_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 3;
                                        objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                    }


                                    objEntityTempAlertList.Add(objEntityTemplateAlert);
                                }
                            }

                        }
                        //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                        ObjBussinessBankGuarnt.AddTemplateDetail(ObjEntityBnkGurnt, objEntityTempDeatils, objEntityTempAlertList);
                    }
                }
                else
                {
                    int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                    string strEachTempTotalString = hiddenEachSliceData.Value;
                    string strNotifyMode = hiddenNotificationMOde.Value;
                    string strNotifyVia = hiddenNotifyVia.Value;
                    string strNotifyDur = hiddenNotificationDuration.Value;
                    //-----for template ---
                    int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                    string[] strEachTempString = new string[TempCount];
                    strEachTempString = strEachTempTotalString.Split('!');

                    //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
                    for (int intCount = 0; intCount < TempCount; intCount++)
                    {
                        BnkGrntyTemplateDetail objEntityTempDeatils = new BnkGrntyTemplateDetail();

                        //for template mode
                        string jsonDataNotyMod = strNotifyMode;
                        string a = jsonDataNotyMod.Replace("\"{", "\\{");
                        string b = a.Replace("\\n", "\r\n");
                        string c = b.Replace("\\", "");
                        string d = c.Replace("}\"]", "}]");
                        string k = d.Replace("}\",", "},");

                        List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                        objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                        string MODEROWID = objEachTempDetModList[intCount].ROWID;
                        string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                        string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                        if (NOTMODE == "D")
                        {
                            objEntityTempDeatils.TempDetPeriod = 2;
                        }
                        else
                        {
                            objEntityTempDeatils.TempDetPeriod = 1;
                        }
                        if (MODETEMPID != "0")
                        {
                            objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                        }
                        //for template NotifyVia
                        string jsonDataNotyVia = strNotifyVia;
                        string l = jsonDataNotyVia.Replace("\"{", "\\{");
                        string m = l.Replace("\\n", "\r\n");
                        string n = m.Replace("\\", "");
                        string o = n.Replace("}\"]", "}]");
                        string p = o.Replace("}\",", "},");

                        List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                        objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                        string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                        string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                        string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                        if (VIAWHT.Contains("D"))
                        {
                            objEntityTempDeatils.IsDashBoard = 1;
                        }
                        if (VIAWHT.Contains("E"))
                        {
                            objEntityTempDeatils.IsEmail = 1;
                        }

                        //for template notify Duration
                        string jsonDataNotyDur = strNotifyDur;
                        string q = jsonDataNotyDur.Replace("\"{", "\\{");
                        string r = q.Replace("\\n", "\r\n");
                        string s = r.Replace("\\", "");
                        string t = s.Replace("}\"]", "}]");
                        string u = t.Replace("}\",", "},");

                        List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                        objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                        string DURROWID = objEachTempDetDurList[intCount].ROWID;
                        string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                        string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                        objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                        string jsonData = strEachTempString[intCount + 1];
                        string V = jsonData.Replace("\"{", "\\{");
                        string W = V.Replace("\\n", "\r\n");
                        string X = W.Replace("\\", "");
                        string Y = X.Replace("}\"]", "}]");
                        string Z = Y.Replace("}\",", "},");

                        List<BnkGrntyTemplateAlert> objEntityTempAlertList = new List<BnkGrntyTemplateAlert>();


                        List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                        objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                        if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                        {
                            int AddingCount = 0;
                            for (int count = 0; count < objEachTempDetList.Count; count++)
                            {
                                string ROWID = objEachTempDetList[count].ROWID;

                                string VALUE = objEachTempDetList[count].DDLVALUE;
                                string DDLMODE = objEachTempDetList[count].DDLMODE;
                                string DTLID = objEachTempDetList[count].DTLID;
                                if (VALUE != "0")
                                {
                                    BnkGrntyTemplateAlert objEntityTemplateAlert = new BnkGrntyTemplateAlert();
                                    if (DDLMODE == "ddlDivision_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 0;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlDesignation_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 1;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlEmployee_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 2;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "txtGenMail_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 3;
                                        objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                    }

                                    if (DTLID != "0")
                                    {
                                        objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                        ObjBussinessBankGuarnt.UpdateNotifyTemplateAlert(objEntityTemplateAlert, objEntityTempDeatils);
                                    }
                                    else
                                    {
                                        AddingCount++;
                                        objEntityTempAlertList.Add(objEntityTemplateAlert);
                                    }
                                }

                            }
                            if (objEntityTempDeatils.TempDetailId != 0)
                            {
                                if (AddingCount != 0)
                                {
                                    ObjBussinessBankGuarnt.AddTemplateAlert(objEntityTempAlertList, ObjEntityBnkGurnt, objEntityTempDeatils);
                                }
                            }
                        }
                        //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                        if (objEntityTempDeatils.TempDetailId != 0)
                        {
                            ObjBussinessBankGuarnt.UpdateNotifyTemplateDetail(objEntityTempDeatils);
                        }
                        else
                        {
                            ObjBussinessBankGuarnt.AddTemplateDetail(ObjEntityBnkGurnt, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }

                    string strTotalDelete = hiddenDeleteSliceData.Value;
                    string[] strEachTempDelete = new string[TempCount];
                    strEachTempDelete = strTotalDelete.Split('!');
                    for (int intDCount = 1; intDCount <= TempCount; intDCount++)
                    {
                        if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                        {
                            string strDeletedAlert = strEachTempDelete[intDCount];
                            string jsonDataDeleted = strDeletedAlert;
                            string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                            string d2 = d1.Replace("\\n", "\r\n");
                            string d3 = d2.Replace("\\", "");
                            string d4 = d3.Replace("}\"]", "}]");
                            string d5 = d4.Replace("}\",", "},");
                            List<BnkGrntyTemplateAlert> objEntityTempAlertDeleteList = new List<BnkGrntyTemplateAlert>();


                            List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                            objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                            for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                            {
                                string ROWID = objAlertDelList[delcount].ROWID;
                                string AlertVALUE = objAlertDelList[delcount].DTLID;

                                BnkGrntyTemplateAlert objEntityTempAlertDelete = new BnkGrntyTemplateAlert();
                                objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                                objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                            }
                            ObjBussinessBankGuarnt.DeleteTemplateAlert(objEntityTempAlertDeleteList);

                        }
                    }
                }


                if (clickedButton.ID == "btnUpdate")
                {
                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Upd";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strReqForIdId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);

                    Response.Redirect(strRedirectUrl);
                    if (hiddenRoleAdd.Value.ToString() != "")
                    {

                        //if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        //{
                        //   // Response.Redirect("gen_Bank_Guarantee.aspx?InsUpd=Upd");
                        //    Response.Redirect(strRedirectUrl);
                        //}
                        //else
                        //{
                        //    Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Upd");
                        //}

                    }

                }
                else if (clickedButton.ID == "btnUpdateClose")
                {

                    if (Request.QueryString["default"] != null)
                    {
                        if (Request.QueryString["default"] == "3months")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Upd&default=3months");
                        }
                        else if (Request.QueryString["default"] == "expired")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Upd&default=expired");
                        }
                        else if (Request.QueryString["default"] == "new")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Upd&default=new");
                        }
                        else
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Upd");

                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
        }

    }


    protected void btnrenew_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();

        if (Request.QueryString["Renew"] != null || Request.QueryString["ViewId"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                ObjEntityBnkGurnt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            string strRandomMixedId = "";
            if (Request.QueryString["Renew"] != null)
            {
                strRandomMixedId = Request.QueryString["Renew"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }
            // string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(strReqForIdId);
            ObjEntityBnkGurnt.RefNumber = HiddenFieldRefNumber2.Value;



            if (radioClient.Checked == true)
            {


                ObjEntityBnkGurnt.Guarantee_Method = 101;

                //if RFG imported Gtee
                if (HiddenRFGImportedGtee.Value == "1")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(HiddenFieldMode.Value);
                    // ObjEntityBnkGurnt.Contrctr =null ;
                    ObjEntityBnkGurnt.Customer = Convert.ToInt32(HiddenFieldCustmor.Value);
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(HiddenFieldCurrcy.Value);
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
                    ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
                    ObjEntityBnkGurnt.ReqstGrntId = Convert.ToInt32(HiddenFieldRequestCltId.Value);
                }
                else
                {
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text);
                    if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);

                    }
                    //if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--")
                    //{
                    //    ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                    //}

                    if (cbxPrjct.Checked == true)
                    {
                        if (HiddenProjctsave.Value != "0")
                        {
                            ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenProjctsave.Value);
                        }
                    }
                    else
                    {
                        ObjEntityBnkGurnt.ProjectName = txtPrjctName.Text.Trim();
                    }
                    if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                    {
                        ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                    }
                    if (ddlCustomerList.SelectedItem.Value != "--SELECT CUSTOMER--")
                    {
                        ObjEntityBnkGurnt.Customer = Convert.ToInt32(ddlCustomerList.SelectedItem.Value);
                    }
                }

            }
            else if (radioSuplier.Checked == true)
            {
                ObjEntityBnkGurnt.Guarantee_Method = 102;
                if (ddlGuarntyp.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGuarntyp.SelectedItem.Value);

                }
                if (ddlSubContrct.SelectedItem.Value.ToString() != "--SELECT SUB-CONTRACT--")
                {
                    ObjEntityBnkGurnt.SubContractId = Convert.ToInt32(ddlSubContrct.SelectedItem.Value);
                }
                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                {
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                }
                ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
                //ObjEntityBnkGurnt.Contrctr = 1624;
                ObjEntityBnkGurnt.Contrctr = Convert.ToInt32(HiddenFieldCustmor.Value);
                ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
                //ObjEntityBnkGurnt.Customer = null;
            }
            //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Bank_Guarantee);
            //objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
            //objEntityCommon.Organisation_Id = ObjEntityBnkGurnt.Organisation_Id;
            //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            //ObjEntityBnkGurnt.NextIdForRqst = Convert.ToInt32(strNextId);
            //HiddenBankGuarenteeId.Value = Convert.ToString(ObjEntityBnkGurnt.NextIdForRqst);
            //ObjEntityBnkGurnt.RefNumber = hiddenFieldRefNumber.Value;
            ObjEntityBnkGurnt.GuaranteeNo = txtGuarnteno.Text.Trim();
            // ObjEntityBnkGurnt.ProjectId = 121621;
            //Convert.ToInt32(LblProject.Text.Trim());
            if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
            {
                ObjEntityBnkGurnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            }
            if (radioOpen.Checked == true)
            {
                ObjEntityBnkGurnt.GuarTypeId = 101;
                ObjEntityBnkGurnt.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited.Checked == true)
            {
                ObjEntityBnkGurnt.GuarTypeId = 102;
                ObjEntityBnkGurnt.GuaranteeNoDays = Convert.ToInt32(HiddenTextValidty.Value);

                ObjEntityBnkGurnt.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            }
            ObjEntityBnkGurnt.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());

            //if (ddlOwnershp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            //{
            //    ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(ddlOwnershp.SelectedItem.Value);
            //}
            if (HiddenOwnership.Value != "" && HiddenOwnership.Value != "--SELECT EMPLOYEE--")
            {
                ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(HiddenOwnership.Value);
            }

            if (cbxDontNotify.Checked == true)
            {
                ObjEntityBnkGurnt.DontNotify = 1;
            }
            else
            {
                ObjEntityBnkGurnt.DontNotify = 0;
            }

            ObjEntityBnkGurnt.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
            // ObjEntityBnkGurnt.CustomerContrctr = Convert.ToInt32(LabelCustmrContrctr.Text.Trim());
            ObjEntityBnkGurnt.Address = txtadress.Text.Trim();
            ObjEntityBnkGurnt.Subject = txtSubjct.Text.Trim();
            ObjEntityBnkGurnt.Description = txtDescrptn.Text.Trim();
            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    ObjEntityBnkGurnt.EmployeName = ddlExistingEmp.SelectedItem.Text;
                    ObjEntityBnkGurnt.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);

                }
            }
            else
            {
                ObjEntityBnkGurnt.EmployeName = txtEmpName.Text.Trim();
            }
            if (hiddenFieldUserId.Value != "")
            {
                //ObjEntityBnkGurnt.ContactPersnUsrId=Convert.ToInt32(hiddenFieldUserId.Value);
            }
            ObjEntityBnkGurnt.Email = txtCntctMail.Text.Trim();

            ObjEntityBnkGurnt.D_Date = System.DateTime.Now;
            string strGurntNo = "";

            strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityBnkGurnt);
            if (strGurntNo == "" || strGurntNo == "0")
            {


                DataTable GuarantStatus = ObjBussinessBankGuarnt.ChkConfirmBankGuarantee(ObjEntityBnkGurnt);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["GUARANTEE_STATUS"].ToString();
                }
                if (strchckStatus != "1")
                {
                    if (strchckStatus != "4")
                    {
                        if (strchckStatus == "2")
                        {
                            //ObjEntityBnkGurnt.StatusIdCheck = 2;
                            ObjBussinessBankGuarnt.RenewBankGuarantee(ObjEntityBnkGurnt);
                        }
                        ObjBussinessBankGuarnt.UpdateBankGuarantee(ObjEntityBnkGurnt);


                        //else if (strchckStatus == "3")
                        //{
                        //    ObjEntityBnkGurnt.StatusIdCheck = 4;
                        //}

                        //ObjBussinessBankGuarnt.ConfirmBankGuarantee(ObjEntityBnkGurnt);
                        if (txtPrjctClsngDate.Text.Trim() != "")
                        {
                            ObjBussinessBankGuarnt.MailStatusChange(ObjEntityBnkGurnt);
                        }

                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                        objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
                        //string strNextNum = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                        List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerGuaranteeAttachments>();

                        int intSlNumbr = 0;
                        if (hiddenAttchmntSlNumber.Value != "")
                        {
                            intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                            intSlNumbr++;

                        }
                        if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                        {
                            string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                            string strAtt2 = strAtt1.Replace("\\", "");
                            string strAtt3 = strAtt2.Replace("}\"]", "}]");
                            string strAtt4 = strAtt3.Replace("}\",", "},");
                            List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                            //   UserData  data
                            objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);


                            foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                            {

                                //if (intCount == Intcountchk)
                                //{

                                if (objClsBannrAddAttData.EVTACTION == "INS")
                                {
                                    string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                                    HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                                    if (PostedFile.ContentLength > 0)
                                    {
                                        clsEntityLayerGuaranteeAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();
                                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);

                                        objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;
                                        string strFileExt;

                                        strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                        int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                                        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                                        objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                        string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                        objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                        objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                        objEntityLayerGuarnteeAtchmntDtl.GuarenteeId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);

                                        PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                        objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                        intSlNumbr++;
                                    }


                                }
                            }
                        }
                        List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuaranteeAtchmntDtlListDelete = new List<clsEntityLayerGuaranteeAttachments>();
                        if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                        {
                            string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                            string strAtt2 = strAtt1.Replace("\\", "");
                            string strAtt3 = strAtt2.Replace("}\"]", "}]");
                            string strAtt4 = strAtt3.Replace("}\",", "},");
                            List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                            //   UserData  data
                            objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);


                            foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                            {

                                clsEntityLayerGuaranteeAttachments objEntityLayerGuaranteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();

                                objEntityLayerGuaranteeAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                                objEntityLayerGuaranteeAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);

                                objEntityLayerGuaranteeAtchmntDtlListDelete.Add(objEntityLayerGuaranteeAtchmntDtl);

                            }

                        }

                        if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                        {

                            ObjBussinessBankGuarnt.Add_Pictures(ObjEntityBnkGurnt, objEntityLayerGuarenteeAtchmntDtlList);
                        }
                        if (objEntityLayerGuaranteeAtchmntDtlListDelete.Count > 0)
                        {
                            ObjBussinessBankGuarnt.Delete_Pictures(ObjEntityBnkGurnt, objEntityLayerGuaranteeAtchmntDtlListDelete);

                            //Delete from location
                            foreach (clsEntityLayerGuaranteeAttachments objEntityLayerIGuaranteeAtchmntDtl in objEntityLayerGuaranteeAtchmntDtlListDelete)
                            {

                                string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                                string imageLocation = strImgPath + objEntityLayerIGuaranteeAtchmntDtl.FileName;
                                if (File.Exists(MapPath(imageLocation)))
                                {
                                    File.Delete(MapPath(imageLocation));
                                }
                            }

                        }


                        // if (clickedButton.ID == "btnUpdate")
                        // {
                        //if (hiddenRoleAdd.Value.ToString() != "")
                        //{
                        //REDIRECT TO UPDATE VIEW 
                        List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                        objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                        clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "InsUpd";
                        objEntityQueryString.QueryStringValue = "Renewd";
                        objEntityQueryString.Encrypt = 0;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "ViewId";
                        objEntityQueryString.QueryStringValue = strReqForIdId;
                        objEntityQueryString.Encrypt = 1;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                        Response.Redirect(strRedirectUrl);

                        //if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        //{
                        //    Response.Redirect("gen_Bank_Guarantee.aspx?InsUpd=Renewd");
                        //}
                        //else
                        //{
                        //    Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Renewd");
                        //}
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "StsChkClsRenew", "StsChkClsRenew();", true);

                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "StsChkReopnRenew", "StsChkReopnRenew();", true);

                }
                //}

                // }
                // else if (clickedButton.ID == "btnUpdateClose")
                //  {
                //  Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cnfrm");
                // }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
        }

    }


    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                ObjEntityBnkGurnt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            //Status checkbox checked
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }
            // string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(strReqForIdId);
            ObjEntityBnkGurnt.RefNumber = HiddenFieldRefNumber2.Value;
            int intReqstApprvChk = 0;
            if (radioClient.Checked == true)
            {
                ObjEntityBnkGurnt.Guarantee_Method = 101;


                //if RFG imported Gtee
                if (HiddenRFGImportedGtee.Value == "1")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(HiddenFieldMode.Value);
                    // ObjEntityBnkGurnt.Contrctr =null ;
                    ObjEntityBnkGurnt.Customer = Convert.ToInt32(HiddenFieldCustmor.Value);
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(HiddenFieldCurrcy.Value);
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(HiddenFieldAmount.Value);
                    ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
                    ObjEntityBnkGurnt.ReqstGrntId = Convert.ToInt32(HiddenFieldRequestCltId.Value);
                    intReqstApprvChk = Convert.ToInt32(HiddenFieldRequestCltId.Value);
                }
                else
                {
                    ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text);
                    if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);

                    }
                    //if (ddlProjects.SelectedItem.Value != "--SELECT PROJECT--")
                    //{
                    //    ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(ddlProjects.SelectedItem.Value);
                    //}
                    if (cbxPrjct.Checked == true)
                    {
                        if (HiddenProjctsave.Value != "0")
                        {
                            ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenProjctsave.Value);
                        }
                    }
                    else
                    {
                        ObjEntityBnkGurnt.ProjectName = txtPrjctName.Text.Trim();
                    }
                    if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                    {
                        ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                    }
                    if (ddlCustomerList.SelectedItem.Value != "--SELECT CUSTOMER--")
                    {
                        ObjEntityBnkGurnt.Customer = Convert.ToInt32(ddlCustomerList.SelectedItem.Value);
                    }
                }
            }
            else if (radioSuplier.Checked == true)
            {
                ObjEntityBnkGurnt.Guarantee_Method = 102;
                if (ddlGuarntyp.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                {
                    ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(ddlGuarntyp.SelectedItem.Value);

                }
                if (ddlSubContrct.SelectedItem.Value.ToString() != "--SELECT SUB-CONTRACT--")
                {
                    ObjEntityBnkGurnt.SubContractId = Convert.ToInt32(ddlSubContrct.SelectedItem.Value);
                }
                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                {
                    ObjEntityBnkGurnt.Currency = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                }
                ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
                //ObjEntityBnkGurnt.Contrctr = 1624;
                ObjEntityBnkGurnt.Contrctr = Convert.ToInt32(HiddenFieldCustmor.Value);
                ObjEntityBnkGurnt.ProjectId = Convert.ToInt32(HiddenFieldPRJCTID.Value);
                //ObjEntityBnkGurnt.Customer = null;
            }
            //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Bank_Guarantee);
            //objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
            //objEntityCommon.Organisation_Id = ObjEntityBnkGurnt.Organisation_Id;
            //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
            //ObjEntityBnkGurnt.NextIdForRqst = Convert.ToInt32(strNextId);
            //HiddenBankGuarenteeId.Value = Convert.ToString(ObjEntityBnkGurnt.NextIdForRqst);
            //ObjEntityBnkGurnt.RefNumber = hiddenFieldRefNumber.Value;
            ObjEntityBnkGurnt.GuaranteeNo = txtGuarnteno.Text.Trim();
            // ObjEntityBnkGurnt.ProjectId = 121621;
            //Convert.ToInt32(LblProject.Text.Trim());
            if (ddlBank.SelectedItem.Value != "--SELECT BANK--")
            {
                ObjEntityBnkGurnt.BankId = Convert.ToInt32(ddlBank.SelectedItem.Value);
            }
            if (radioOpen.Checked == true)
            {
                ObjEntityBnkGurnt.GuarTypeId = 101;
                ObjEntityBnkGurnt.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited.Checked == true)
            {
                ObjEntityBnkGurnt.GuarTypeId = 102;
                ObjEntityBnkGurnt.GuaranteeNoDays = Convert.ToInt32(HiddenTextValidty.Value);

                ObjEntityBnkGurnt.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            }
            ObjEntityBnkGurnt.OpenDate = objCommon.textToDateTime(txtOpngDate.Text.Trim());
            if (HiddenOwnership.Value != "" && HiddenOwnership.Value != "--SELECT EMPLOYEE--")
            {
                ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(HiddenOwnership.Value);
            }
            //if (ddlOwnershp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            //{
            //    ObjEntityBnkGurnt.OwnershipEmply = Convert.ToInt32(ddlOwnershp.SelectedItem.Value);
            //}


            // ObjEntityBnkGurnt.CustomerContrctr = Convert.ToInt32(LabelCustmrContrctr.Text.Trim());
            ObjEntityBnkGurnt.Address = txtadress.Text.Trim();
            ObjEntityBnkGurnt.Subject = txtSubjct.Text.Trim();
            ObjEntityBnkGurnt.Description = txtDescrptn.Text.Trim();
            ObjEntityBnkGurnt.Remarks = txtRemarks.Text.Trim();
            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    ObjEntityBnkGurnt.EmployeName = ddlExistingEmp.SelectedItem.Text;
                    ObjEntityBnkGurnt.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);

                }
            }
            else
            {
                ObjEntityBnkGurnt.EmployeName = txtEmpName.Text.Trim();
            }
            if (hiddenFieldUserId.Value != "")
            {
                //ObjEntityBnkGurnt.ContactPersnUsrId=Convert.ToInt32(hiddenFieldUserId.Value);
            }

            if (cbxDontNotify.Checked == true)
            {
                ObjEntityBnkGurnt.DontNotify = 1;
            }
            else
            {
                ObjEntityBnkGurnt.DontNotify = 0;
            }

            ObjEntityBnkGurnt.NotTempId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
            ObjEntityBnkGurnt.Email = txtCntctMail.Text.Trim();

            ObjEntityBnkGurnt.D_Date = System.DateTime.Now;
            string strGurntNo = "";

            strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityBnkGurnt);
            if (strGurntNo == "" || strGurntNo == "0")
            {


                DataTable GuarantStatus = ObjBussinessBankGuarnt.ChkConfirmBankGuarantee(ObjEntityBnkGurnt);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["GUARANTEE_STATUS"].ToString();
                }
                if (strchckStatus == "1")
                {
                    ObjEntityBnkGurnt.StatusIdCheck = 2;
                }
                else if (strchckStatus == "3")
                {
                    ObjEntityBnkGurnt.StatusIdCheck = 4;
                }
                if (strchckStatus != "2")
                {

                    ObjBussinessBankGuarnt.UpdateBankGuarantee(ObjEntityBnkGurnt);
                    if (intReqstApprvChk != 0)
                    {
                        ObjBussinessBankGuarnt.UpdateReqstGuarnteStats(ObjEntityBnkGurnt);
                    }


                    ObjBussinessBankGuarnt.ConfirmBankGuarantee(ObjEntityBnkGurnt);

                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                    objEntityCommon.CorporateID = ObjEntityBnkGurnt.CorpOffice_Id;
                    //string strNextNum = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                    List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerGuaranteeAttachments>();

                    int intSlNumbr = 0;
                    if (hiddenAttchmntSlNumber.Value != "")
                    {
                        intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber.Value);
                        intSlNumbr++;

                    }
                    if (HiddenField2_FileUploadLnk.Value != "" && HiddenField2_FileUploadLnk.Value != null && HiddenField2_FileUploadLnk.Value != "[]")
                    {
                        string jsonDataDltAttch = HiddenField2_FileUploadLnk.Value;
                        string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                        string strAtt2 = strAtt1.Replace("\\", "");
                        string strAtt3 = strAtt2.Replace("}\"]", "}]");
                        string strAtt4 = strAtt3.Replace("}\",", "},");
                        List<clsBannerDataADDAttchmnt> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt>();
                        //   UserData  data
                        objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt>>(strAtt4);


                        foreach (clsBannerDataADDAttchmnt objClsBannrAddAttData in objBannerDataDltAttList)
                        {

                            //if (intCount == Intcountchk)
                            //{

                            if (objClsBannrAddAttData.EVTACTION == "INS")
                            {
                                string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                                HttpPostedFile PostedFile = Request.Files["file" + strfilepath];
                                if (PostedFile.ContentLength > 0)
                                {
                                    clsEntityLayerGuaranteeAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();
                                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);

                                    objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;
                                    string strFileExt;

                                    strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();

                                    int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.Guarantee_Attchment);
                                    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                                    objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                    string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                    objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                    objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx" + strfilepath];

                                    objEntityLayerGuarnteeAtchmntDtl.GuarenteeId = Convert.ToInt32(HiddenBankGuarenteeId.Value);

                                    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);

                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                    objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                    intSlNumbr++;
                                }


                            }
                        }
                    }
                    List<clsEntityLayerGuaranteeAttachments> objEntityLayerGuaranteeAtchmntDtlListDelete = new List<clsEntityLayerGuaranteeAttachments>();
                    if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
                    {
                        string jsonDataDltAttch = hiddenFileCanclDtlId.Value;
                        string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                        string strAtt2 = strAtt1.Replace("\\", "");
                        string strAtt3 = strAtt2.Replace("}\"]", "}]");
                        string strAtt4 = strAtt3.Replace("}\",", "},");
                        List<clsPictureDataDELETEAttchmnt> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt>();
                        //   UserData  data
                        objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt>>(strAtt4);


                        foreach (clsPictureDataDELETEAttchmnt objClsPictureDltAttData in objPictureDataDltAttList)
                        {

                            clsEntityLayerGuaranteeAttachments objEntityLayerGuaranteeAtchmntDtl = new clsEntityLayerGuaranteeAttachments();

                            objEntityLayerGuaranteeAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                            objEntityLayerGuaranteeAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);

                            objEntityLayerGuaranteeAtchmntDtlListDelete.Add(objEntityLayerGuaranteeAtchmntDtl);

                        }

                    }

                    if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                    {

                        ObjBussinessBankGuarnt.Add_Pictures(ObjEntityBnkGurnt, objEntityLayerGuarenteeAtchmntDtlList);
                    }
                    if (objEntityLayerGuaranteeAtchmntDtlListDelete.Count > 0)
                    {
                        ObjBussinessBankGuarnt.Delete_Pictures(ObjEntityBnkGurnt, objEntityLayerGuaranteeAtchmntDtlListDelete);

                        //Delete from location
                        foreach (clsEntityLayerGuaranteeAttachments objEntityLayerIGuaranteeAtchmntDtl in objEntityLayerGuaranteeAtchmntDtlListDelete)
                        {

                            string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.Guarantee_Attchment);
                            string imageLocation = strImgPath + objEntityLayerIGuaranteeAtchmntDtl.FileName;
                            if (File.Exists(MapPath(imageLocation)))
                            {
                                File.Delete(MapPath(imageLocation));
                            }
                        }

                    }
                    ObjEntityBnkGurnt.NextIdForRqst = ObjEntityBnkGurnt.GuaranteeId;
                    if (hiddenTemplateChange.Value == "CHANGED")
                    {
                        ObjBussinessBankGuarnt.DeleteTemplateAlertByGr(ObjEntityBnkGurnt);
                        ObjBussinessBankGuarnt.DeleteTemplateDetByGr(ObjEntityBnkGurnt);



                        //for inserting template

                        int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                        string strEachTempTotalString = hiddenEachSliceData.Value;
                        string strNotifyMode = hiddenNotificationMOde.Value;
                        string strNotifyVia = hiddenNotifyVia.Value;
                        string strNotifyDur = hiddenNotificationDuration.Value;
                        int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                        string[] strEachTempString = new string[TempCount];
                        strEachTempString = strEachTempTotalString.Split('!');

                        //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
                        for (int intCount = 0; intCount < TempCount; intCount++)
                        {
                            BnkGrntyTemplateDetail objEntityTempDeatils = new BnkGrntyTemplateDetail();

                            //for template mode
                            string jsonDataNotyMod = strNotifyMode;
                            string a = jsonDataNotyMod.Replace("\"{", "\\{");
                            string b = a.Replace("\\n", "\r\n");
                            string c = b.Replace("\\", "");
                            string d = c.Replace("}\"]", "}]");
                            string k = d.Replace("}\",", "},");

                            List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                            objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                            string MODEROWID = objEachTempDetModList[intCount].ROWID;
                            string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                            string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                            if (NOTMODE == "D")
                            {
                                objEntityTempDeatils.TempDetPeriod = 2;
                            }
                            else
                            {
                                objEntityTempDeatils.TempDetPeriod = 1;
                            }

                            //for template NotifyVia
                            string jsonDataNotyVia = strNotifyVia;
                            string l = jsonDataNotyVia.Replace("\"{", "\\{");
                            string m = l.Replace("\\n", "\r\n");
                            string n = m.Replace("\\", "");
                            string o = n.Replace("}\"]", "}]");
                            string p = o.Replace("}\",", "},");

                            List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                            objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                            string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                            string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                            string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                            if (VIAWHT.Contains("D"))
                            {
                                objEntityTempDeatils.IsDashBoard = 1;
                            }
                            if (VIAWHT.Contains("E"))
                            {
                                objEntityTempDeatils.IsEmail = 1;
                            }

                            //for template notify Duration
                            string jsonDataNotyDur = strNotifyDur;
                            string q = jsonDataNotyDur.Replace("\"{", "\\{");
                            string r = q.Replace("\\n", "\r\n");
                            string s = r.Replace("\\", "");
                            string t = s.Replace("}\"]", "}]");
                            string u = t.Replace("}\",", "},");

                            List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                            objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                            string DURROWID = objEachTempDetDurList[intCount].ROWID;
                            string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                            string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                            objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                            string jsonData = strEachTempString[intCount + 1];
                            string V = jsonData.Replace("\"{", "\\{");
                            string W = V.Replace("\\n", "\r\n");
                            string X = W.Replace("\\", "");
                            string Y = X.Replace("}\"]", "}]");
                            string Z = Y.Replace("}\",", "},");

                            List<BnkGrntyTemplateAlert> objEntityTempAlertList = new List<BnkGrntyTemplateAlert>();


                            List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                            objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                            if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                            {

                                for (int count = 0; count < objEachTempDetList.Count; count++)
                                {
                                    string ROWID = objEachTempDetList[count].ROWID;

                                    string VALUE = objEachTempDetList[count].DDLVALUE;
                                    string DDLMODE = objEachTempDetList[count].DDLMODE;
                                    string DTLID = objEachTempDetList[count].DTLID;
                                    if (VALUE != "0")
                                    {
                                        BnkGrntyTemplateAlert objEntityTemplateAlert = new BnkGrntyTemplateAlert();
                                        if (DDLMODE == "ddlDivision_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 0;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlDesignation_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 1;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlEmployee_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 2;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "txtGenMail_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 3;
                                            objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                        }


                                        objEntityTempAlertList.Add(objEntityTemplateAlert);
                                    }
                                }

                            }
                            //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                            ObjBussinessBankGuarnt.AddTemplateDetail(ObjEntityBnkGurnt, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }
                    else
                    {
                        int TemplateCount = Convert.ToInt32(hiddenTemplateCount.Value);
                        string strEachTempTotalString = hiddenEachSliceData.Value;
                        string strNotifyMode = hiddenNotificationMOde.Value;
                        string strNotifyVia = hiddenNotifyVia.Value;
                        string strNotifyDur = hiddenNotificationDuration.Value;
                        //-----for template ---
                        int TempCount = Convert.ToInt32(hiddenTemplateCount.Value);

                        string[] strEachTempString = new string[TempCount];
                        strEachTempString = strEachTempTotalString.Split('!');

                        //List<NotificationTemplateDetail> objEntityTempDeatilsList = new List<NotificationTemplateDetail>();
                        for (int intCount = 0; intCount < TempCount; intCount++)
                        {
                            BnkGrntyTemplateDetail objEntityTempDeatils = new BnkGrntyTemplateDetail();

                            //for template mode
                            string jsonDataNotyMod = strNotifyMode;
                            string a = jsonDataNotyMod.Replace("\"{", "\\{");
                            string b = a.Replace("\\n", "\r\n");
                            string c = b.Replace("\\", "");
                            string d = c.Replace("}\"]", "}]");
                            string k = d.Replace("}\",", "},");

                            List<clsEachTempNotyMOde> objEachTempDetModList = new List<clsEachTempNotyMOde>();
                            objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde>>(k);

                            string MODEROWID = objEachTempDetModList[intCount].ROWID;
                            string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                            string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                            if (NOTMODE == "D")
                            {
                                objEntityTempDeatils.TempDetPeriod = 2;
                            }
                            else
                            {
                                objEntityTempDeatils.TempDetPeriod = 1;
                            }
                            if (MODETEMPID != "0")
                            {
                                objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                            }
                            //for template NotifyVia
                            string jsonDataNotyVia = strNotifyVia;
                            string l = jsonDataNotyVia.Replace("\"{", "\\{");
                            string m = l.Replace("\\n", "\r\n");
                            string n = m.Replace("\\", "");
                            string o = n.Replace("}\"]", "}]");
                            string p = o.Replace("}\",", "},");

                            List<clsEachTempNotyVia> objEachTempDetViaList = new List<clsEachTempNotyVia>();
                            objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia>>(p);

                            string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                            string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                            string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                            if (VIAWHT.Contains("D"))
                            {
                                objEntityTempDeatils.IsDashBoard = 1;
                            }
                            if (VIAWHT.Contains("E"))
                            {
                                objEntityTempDeatils.IsEmail = 1;
                            }

                            //for template notify Duration
                            string jsonDataNotyDur = strNotifyDur;
                            string q = jsonDataNotyDur.Replace("\"{", "\\{");
                            string r = q.Replace("\\n", "\r\n");
                            string s = r.Replace("\\", "");
                            string t = s.Replace("}\"]", "}]");
                            string u = t.Replace("}\",", "},");

                            List<clsEachTempNotyDur> objEachTempDetDurList = new List<clsEachTempNotyDur>();
                            objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur>>(u);

                            string DURROWID = objEachTempDetDurList[intCount].ROWID;
                            string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                            string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                            objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                            string jsonData = strEachTempString[intCount + 1];
                            string V = jsonData.Replace("\"{", "\\{");
                            string W = V.Replace("\\n", "\r\n");
                            string X = W.Replace("\\", "");
                            string Y = X.Replace("}\"]", "}]");
                            string Z = Y.Replace("}\",", "},");

                            List<BnkGrntyTemplateAlert> objEntityTempAlertList = new List<BnkGrntyTemplateAlert>();


                            List<clsEachTempDeatail> objEachTempDetList = new List<clsEachTempDeatail>();
                            objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail>>(Z);



                            if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                            {
                                int AddingCount = 0;
                                for (int count = 0; count < objEachTempDetList.Count; count++)
                                {
                                    string ROWID = objEachTempDetList[count].ROWID;

                                    string VALUE = objEachTempDetList[count].DDLVALUE;
                                    string DDLMODE = objEachTempDetList[count].DDLMODE;
                                    string DTLID = objEachTempDetList[count].DTLID;
                                    if (VALUE != "0")
                                    {
                                        BnkGrntyTemplateAlert objEntityTemplateAlert = new BnkGrntyTemplateAlert();
                                        if (DDLMODE == "ddlDivision_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 0;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlDesignation_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 1;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlEmployee_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 2;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "txtGenMail_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 3;
                                            objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                        }

                                        if (DTLID != "0")
                                        {
                                            objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                            ObjBussinessBankGuarnt.UpdateNotifyTemplateAlert(objEntityTemplateAlert, objEntityTempDeatils);
                                        }
                                        else
                                        {
                                            AddingCount++;
                                            objEntityTempAlertList.Add(objEntityTemplateAlert);
                                        }
                                    }

                                }
                                if (objEntityTempDeatils.TempDetailId != 0)
                                {
                                    if (AddingCount != 0)
                                    {
                                        ObjBussinessBankGuarnt.AddTemplateAlert(objEntityTempAlertList, ObjEntityBnkGurnt, objEntityTempDeatils);
                                    }
                                }
                            }
                            //objEntityTempDeatilsList.Add(objEntityTempDeatils);

                            if (objEntityTempDeatils.TempDetailId != 0)
                            {
                                ObjBussinessBankGuarnt.UpdateNotifyTemplateDetail(objEntityTempDeatils);
                            }
                            else
                            {
                                ObjBussinessBankGuarnt.AddTemplateDetail(ObjEntityBnkGurnt, objEntityTempDeatils, objEntityTempAlertList);
                            }
                        }

                        string strTotalDelete = hiddenDeleteSliceData.Value;
                        string[] strEachTempDelete = new string[TempCount];
                        strEachTempDelete = strTotalDelete.Split('!');
                        for (int intDCount = 1; intDCount <= TempCount; intDCount++)
                        {
                            if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                            {
                                string strDeletedAlert = strEachTempDelete[intDCount];
                                string jsonDataDeleted = strDeletedAlert;
                                string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                                string d2 = d1.Replace("\\n", "\r\n");
                                string d3 = d2.Replace("\\", "");
                                string d4 = d3.Replace("}\"]", "}]");
                                string d5 = d4.Replace("}\",", "},");
                                List<BnkGrntyTemplateAlert> objEntityTempAlertDeleteList = new List<BnkGrntyTemplateAlert>();


                                List<clsEachAlertDel> objAlertDelList = new List<clsEachAlertDel>();
                                objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel>>(d5);
                                for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                                {
                                    string ROWID = objAlertDelList[delcount].ROWID;
                                    string AlertVALUE = objAlertDelList[delcount].DTLID;

                                    BnkGrntyTemplateAlert objEntityTempAlertDelete = new BnkGrntyTemplateAlert();
                                    objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                                    objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                                }
                                ObjBussinessBankGuarnt.DeleteTemplateAlert(objEntityTempAlertDeleteList);

                            }
                        }
                    }

                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Cnfrm";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "ViewId";
                    objEntityQueryString.QueryStringValue = strReqForIdId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);
                    if (hiddenRoleAdd.Value.ToString() != "")
                    {

                        //if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        //{
                        //    Response.Redirect("gen_Bank_Guarantee.aspx?InsUpd=Cnfrm");
                        //}
                        //else
                        //{
                        //    Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cnfrm");
                        //}

                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheck", "StatusCheck();", true);

                }//  Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=Cnfrm");
                // }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
            }
        }

    }

    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null || Request.QueryString["Renew"] != null)
        {

            if (Session["CORPOFFICEID"] != null)
            {
                ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }

            if (Request.QueryString["Renew"] != null)
            {
                strRandomMixedId = Request.QueryString["Renew"].ToString();
            }
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);

            ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(strReqForIdId);
            if (Session["USERID"] != null)
            {
                ObjEntityBnkGurnt.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityBnkGurnt.D_Date = System.DateTime.Now;

            DataTable GuarantStatus = ObjBussinessBankGuarnt.ChkConfirmBankGuarantee(ObjEntityBnkGurnt);
            string strchckStatus = "";
            if (GuarantStatus.Rows.Count > 0)
            {
                strchckStatus = GuarantStatus.Rows[0]["GUARANTEE_STATUS"].ToString();
            }
            if (strchckStatus == "2")
            {
                ObjEntityBnkGurnt.StatusIdCheck = 1;
            }
            else if (strchckStatus == "4")
            {
                ObjEntityBnkGurnt.StatusIdCheck = 3;
            }
            if (strchckStatus != "4")
            {
                if (strchckStatus != "1")
                {
                    ObjBussinessBankGuarnt.ReOpenRequest(ObjEntityBnkGurnt);
                    ObjBussinessBankGuarnt.MailStatusChange(ObjEntityBnkGurnt);

                    if (HiddenFieldRequestCltId.Value != "")
                    {
                        ObjEntityBnkGurnt.ReqstGrntId = Convert.ToInt32(HiddenFieldRequestCltId.Value);
                        ObjBussinessBankGuarnt.UpdateReqstGuarnteStatsonReopn(ObjEntityBnkGurnt);
                    }

                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "ReOpen";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strReqForIdId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);

                    //if (hiddenRoleAdd.Value.ToString() != "")
                    //{
                    //    if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    //    {
                    //        Response.Redirect("gen_Bank_Guarantee.aspx?InsUpd=ReOpen");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd=ReOpen");
                    //    }

                    //}
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheckReopn", "StatusCheckReopn();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheckClsReopn", "StatusCheckClsReopn();", true);
            }

        }


    }

    public class clsPictureDataDELETEAttchmnt
    {
        public string FILENAME { get; set; }

        public string DTLID { get; set; }

    }
    public class clsBannerDataADDAttchmnt
    {
        public string EVTACTION { get; set; }
        public string ROWID { get; set; }
        public string DTLID { get; set; }

    }


    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        HiddenFieldChckUpdate.Value = "1";
        HiddenImportaddchk.Value = "1";
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(strP_Id);
        HiddenFieldGuarntId.Value = strP_Id;
        HiddenBankGuarenteeId.Value = strP_Id;
        ObjEntityBnkGurnt.CorpOffice_Id = intCorpId;
        // DataTable dtClientGurnt = new DataTable();
        // dtClientGurnt = ObjBussinessBankGuarnt.ReadRequesClienttGuaranteeList(ObjEntityBnkGurnt);

        //  string strHtm = ConvertDataTableToHTML(dtClientGurnt);
        //Write to divReport
        // divReport.InnerHtml = strHtm;
        DataTable dtRqstFrGrnt = ObjBussinessBankGuarnt.ReadGuranteeById(ObjEntityBnkGurnt);
        if (dtRqstFrGrnt.Rows.Count > 0)
        {

            HiddenFieldRefNumber2.Value = dtRqstFrGrnt.Rows[0]["GUARANTEE_REF_NUM"].ToString();
            LabelRefnum.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_REF_NUM"].ToString();
            txtadress.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_ADDRESS"].ToString();
            txtSubjct.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_SUBJECT"].ToString();
            txtDescrptn.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_DESCRIPTION"].ToString();
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtGuarnteno.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_NUMBER"].ToString();
            LblProject.Text = dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString();
            HiddenFieldPRJCTID.Value = dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString();
            HiddenProjctsave.Value = dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString();
            txtCntctMail.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString();
            txtOpngDate.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_DATE"].ToString();
            txtRemarks.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_REMARKS"].ToString();

            if (dtRqstFrGrnt.Rows[0]["GUARANTEE_DONT_NOTIFY"].ToString() == "1")
            {
                cbxDontNotify.Checked = true;
            }
            else
            {
                cbxDontNotify.Checked = false;
            }
            if (dtRqstFrGrnt.Rows[0]["NOTFTEMP_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["NOTFTEMP_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTemplate.Items.FindByValue(dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
                {
                    ddlTemplate.Items.FindByValue(dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["NOTFTEMP_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString());
                ddlTemplate.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTemplate);

                ddlTemplate.Items.FindByValue(dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }


            if (dtRqstFrGrnt.Rows[0]["GUARANTEE_PERSON_ID"].ToString() != "")
            {
                cbxExistingEmployee.Checked = true;

                if (dtRqstFrGrnt.Rows[0]["PERSNUSERSTATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["PERSNCANCELUSERID"].ToString() == "")
                {
                    if (ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString()) != null)
                    {
                        ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["PERUSERNAME"].ToString(), dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString());
                    ddlExistingEmp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp);

                    ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee.Checked = false;
                txtEmpName.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_PERSON_NAME"].ToString();
            }
            string temp = dtRqstFrGrnt.Rows[0]["USR_ID"].ToString();
            if (dtRqstFrGrnt.Rows[0]["USR_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlOwnershp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()) != null)
                {
                    ddlOwnershp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
            }
            else if (dtRqstFrGrnt.Rows[0]["USR_ID"].ToString() != null && dtRqstFrGrnt.Rows[0]["USR_ID"].ToString() != "")
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["USR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["USR_ID"].ToString());
                ddlOwnershp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlOwnershp);

                ddlOwnershp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }
            else
            {
                ddlOwnershp.Items.FindByValue("--SELECT EMPLOYEE--").Selected = true;
            }


            if (dtRqstFrGrnt.Rows[0]["BANK_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["BANK_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()) != null)
                {
                    ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["BANK_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString());
                ddlBank.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlOwnershp);

                ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
            }





            //if (dtRqstFrGrnt.Rows[0]["BANK_STATUS"].ToString() == "1" &&  dtRqstFrGrnt.Rows[0]["BANK_CNCL_USR_ID"].ToString() == "")
            //{
            //    ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
            //}
            //else
            //{
            //    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["BANK_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString());
            //    ddlBank.Items.Insert(1, lstGrp);

            //    SortDDL(ref this.ddlOwnershp);

            //    ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
            //}





            if (dtRqstFrGrnt.Rows[0]["GRNTYMTHD_ID"].ToString() == "101")
            {
                //LoadDdlForClientGtee();
                //GteeType
                if (dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString() != null || dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString() != "")
                {
                    if (ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                    {
                        ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                        ddlGteeType.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlGteeType);
                        ddlGteeType.ClearSelection();
                        if (ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                        {
                            ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                        }
                    }
                    if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                    {
                        int intProjectId = 0, intGCatID = 0;
                        string strProjectName = "";

                        intGCatID = Convert.ToInt32(ddlGteeType.SelectedItem.Value);
                        if (dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString() != null && dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString() != "")
                        {
                            intProjectId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString());
                            strProjectName = dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString();
                            cbxPrjct.Checked = true;
                        }
                        else
                        {
                            cbxPrjct.Checked = false;
                            txtPrjctName.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_PRJCT_NAME"].ToString();
                        }
                        LoadProjects(intGCatID, intProjectId, strProjectName);
                    }
                }
                //Projects
                //if (dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString() != null || dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString() != "")
                //{
                //    if (ddlProjects.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()) != null)
                //    {
                //        ddlProjects.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                //    }
                //    else
                //    {
                //        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString());
                //        ddlProjects.Items.Insert(1, lstGrp);

                //        SortDDL(ref this.ddlProjects);
                //        ddlProjects.ClearSelection();
                //        if (ddlProjects.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()) != null)
                //        {
                //            ddlProjects.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
                //        }
                //    }
                //}
                //Currency
                ddlCurrency.ClearSelection();
                if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                    {
                        ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCurrency);

                    ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                //customer
                if (dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString() != null || dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString() != "")
                {
                    if (ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()) != null)
                    {
                        ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString());
                        ddlCustomerList.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlCustomerList);
                        ddlCustomerList.ClearSelection();
                        if (ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()) != null)
                        {
                            ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                        }
                    }
                }
                if (dtRqstFrGrnt.Rows[0]["RFQ_ID"].ToString() != "")
                {
                    ddlGteeType.Enabled = false;
                    ddlCurrency.Enabled = false;
                    ddlCustomerList.Enabled = false;
                    ddlProjects.Enabled = false;
                    txtAmount.Enabled = false;
                    HiddenRFGImportedGtee.Value = "1";
                }
                radioClient.Checked = true;
                radioSuplier.Checked = false;
                ddlGuarntyp.Focus();
                HiddenFieldRequestCltId.Value = dtRqstFrGrnt.Rows[0]["RFQ_ID"].ToString();
                //ObjEntityBnkGurnt.Guarantee_Method = 101;
                // ObjEntityBnkGurnt.GuarCatgryId = 1627;
                //del lbl
                //lblGuarntMde.Text = dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString();
                HiddenFieldMode.Value = dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString();
                // ObjEntityBnkGurnt.Contrctr =null ;
                //ObjEntityBnkGurnt.Customer = 1624;
                LabelCustmrContrctr.Text = dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString();
                HiddenFieldCustmor.Value = dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString();
                // ObjEntityBnkGurnt.Currency = 328;
                // ObjEntityBnkGurnt.Amount = Convert.ToDecimal(120.00);
                //del lbl
                //currcyLabl.Text = dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString();
                HiddenFieldCurrcy.Value = dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString();
                txtAmount.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                HiddenFieldAmount.Value = dtRqstFrGrnt.Rows[0]["GUARANTEE_AMOUNT"].ToString();
            }
            else if (dtRqstFrGrnt.Rows[0]["GRNTYMTHD_ID"].ToString() == "102")
            {
                //ObjEntityBnkGurnt.Guarantee_Method = 102;
                radioSuplier.Checked = true;
                radioClient.Checked = false;
                //txtGuarnteno.Focus();
                ddlGteeType.Focus();
                string strcatagory = "";
                ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt123 = new clsBusinessLayerBankGuarantee();
                strcatagory = ObjBussinessBankGuarnt123.ChkCatagory(ObjEntityBnkGurnt);
                if (strcatagory == "101")
                {
                    if (dtRqstFrGrnt.Rows[0]["GUANTCAT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["GUANTCAT_CNCL_USR_ID"].ToString() == "")
                    {
                        if (ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                        {
                            ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                        }
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                        ddlGuarntyp.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlGuarntyp);

                        ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                    ddlGuarntyp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlGuarntyp);

                    ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                }


                if (dtRqstFrGrnt.Rows[0]["CNTRCT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CNTRCT_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlSubContrct.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString()) != null)
                    {
                        ddlSubContrct.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CNTRCT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString());
                    ddlSubContrct.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlSubContrct);

                    ddlSubContrct.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString()).Selected = true;
                }

                ddlCurrency.ClearSelection();
                if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                    {
                        ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCurrency);

                    ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }

                //ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
                txtAmount.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                HiddenFieldCustmor.Value = dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString();
                ObjEntityBnkGurnt.Contrctr = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString());
                LabelCustmrContrctr.Text = dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString();
                //ObjEntityBnkGurnt.Customer = null;
            }

            if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
                //ObjEntityBnkGurnt.ExpireDate = DateTime.MinValue;
            }
            else if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "102")
            {

                // ObjEntityBnkGurnt.GuarTypeId = 102;
                radioLimited.Checked = true;
                txtValidity.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_NO_DAYS"].ToString();
                HiddenTextValidty.Value = dtRqstFrGrnt.Rows[0]["GUARANTEE_NO_DAYS"].ToString();
                txtPrjctClsngDate.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_EXP_DATE"].ToString();

            }

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("PictureAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));
            dtAttchmnt.Columns.Add("Description", typeof(string));

            DataTable dtPicGalleryFull = new DataTable();
            dtPicGalleryFull = ObjBussinessBankGuarnt.Read_Picture(ObjEntityBnkGurnt);

            for (int intcnt = 0; intcnt < dtPicGalleryFull.Rows.Count; intcnt++)
            {
                DataRow drAttch = dtAttchmnt.NewRow();
                drAttch["PictureAttchmntDtlId"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_ID"].ToString();
                drAttch["FileName"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_NAME"].ToString();
                drAttch["ActualFileName"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_ACT_NAME"].ToString();
                drAttch["Description"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_DESC"].ToString();
                dtAttchmnt.Rows.Add(drAttch);

            }

            string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
            hiddenEditAttchmnt.Value = strJson;

            //for filling template details

            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = new DataTable();
            dtEachTemplateDetail = ObjBussinessBankGuarnt.ReadTemplateDetailById(ObjEntityBnkGurnt);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    BnkGrntyTemplateDetail objEntityNotTempDetail = new BnkGrntyTemplateDetail();
                    objEntityNotTempDetail.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_ID"]);
                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBussinessBankGuarnt.ReadTemplateAlertById(objEntityNotTempDetail);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRTY_TMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson2 = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson2;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
            hiddenTemplateLoadingMode.Value = "FromBnk";


            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtRqstFrGrnt.Rows[0]["GUARANTEE_STATUS"].ToString() == "2")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            }

            if (hiddenRoleConfirm.Value != "")
            {
                if (hiddenRoleConfirm.Value == "1")
                {

                    if (dtRqstFrGrnt.Rows[0]["GUARANTEE_STATUS"].ToString() == "1")
                    {
                        btnConfirm.Visible = true;
                    }
                }
            }
            txtValidity.Enabled = false;
            if (HiddenFieldSuplier.Value == "1" && HiddenFieldClient.Value == "1")
            {
                radioClient.Disabled = false;
                radioSuplier.Disabled = false;
                // btnConfirm.Visible = true;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
            }
            else
            {
                if (HiddenFieldSuplier.Value == "1")
                {
                    radioClient.Disabled = true;
                    // btnConfirm.Visible = true;
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;
                }

                else if (HiddenFieldClient.Value == "1")
                {
                    radioSuplier.Disabled = true;
                    //btnConfirm.Visible = true;
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;
                }
                else
                {
                    // btnConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnAdd.Visible = false;
                    btnAddClose.Visible = false;
                    btnClear.Visible = false;
                    radioClient.Disabled = true;
                    radioSuplier.Disabled = true;
                }
            }

            //if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "2" || dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "3")
            //{

            //    hiddenConfirmOrNot.Value = "1";
            //    txtCntctMail.Enabled = false;
            //    cbxStatus.Enabled = false;
            //    cbxExistingEmployee.Enabled = false;
            //    txtRemarks.Enabled = false;
            //    txtPrjctClsngDate.Enabled = false;
            //    txtInFavrOf.Enabled = false;
            //    txtEmpName.Enabled = false;
            //    txtAmount.Enabled = false;
            //    txtValidity.Enabled = false;
            //    ddlProject.Enabled = false;
            //    ddlJobCategory.Enabled = false;
            //    ddlGuaranteCat.Enabled = false;
            //    ddlExistingEmp.Enabled = false;
            //    ddlCustomer.Enabled = false;
            //    ddlCurrency.Enabled = false;
            //    radioOpen.Disabled = true;
            //    radioLimited.Disabled = true;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;

            //}
        }

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
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        //  HiddenImportaddchk.Value = "1";
        HiddenFieldviewchck.Value = "1";
        //HiddenFieldChckUpdate.Value = "1";

        if (strP_Id != "")
        {
            HiddenBankGuarenteeId.Value = strP_Id;
        }
        clsEntityLayerBankGuarantee ObjEntityBnkGurnt = new clsEntityLayerBankGuarantee();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityBnkGurnt.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityBnkGurnt.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityBnkGurnt.GuaranteeId = Convert.ToInt32(strP_Id);
        ObjEntityBnkGurnt.CorpOffice_Id = intCorpId;

        string strGurntNo = "";
        strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityBnkGurnt);
        if (strGurntNo == "" || strGurntNo == "0")
        {
            DataTable GuarantStatus = ObjBussinessBankGuarnt.ChkConfirmBankGuarantee(ObjEntityBnkGurnt);
            string strchckStatus = "";
            if (GuarantStatus.Rows.Count > 0)
            {
                strchckStatus = GuarantStatus.Rows[0]["GUARANTEE_STATUS"].ToString();
            }
            if (strchckStatus == "2")
            {
                HiddenGuarStatus.Value = "2";
                //  HiddenRenew.Value = "1";
            }
            //else if (strchckStatus == "4")
            //{
            //    ObjEntityBnkGurnt.StatusIdCheck = 3;
            //}
        }

        DataTable dtRqstFrGrnt = ObjBussinessBankGuarnt.ReadGuranteeById(ObjEntityBnkGurnt);
        if (dtRqstFrGrnt.Rows.Count > 0)
        {
            HiddenFieldRefNumber2.Value = dtRqstFrGrnt.Rows[0]["GUARANTEE_REF_NUM"].ToString();
            LabelRefnum.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_REF_NUM"].ToString();
            txtadress.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_ADDRESS"].ToString();
            txtSubjct.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_SUBJECT"].ToString();
            txtDescrptn.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_DESCRIPTION"].ToString();
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtGuarnteno.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_NUMBER"].ToString();
            LblProject.Text = dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString();
            HiddenFieldPRJCTID.Value = dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString();
            HiddenProjctsave.Value = dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString();
            txtCntctMail.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_PERSON_EMAIL"].ToString();
            txtOpngDate.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_DATE"].ToString();
            txtRemarks.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_REMARKS"].ToString();
            cbxExistingEmployee.Checked = true;
            if (dtRqstFrGrnt.Rows[0]["GUARANTEE_DONT_NOTIFY"].ToString() == "1")
            {
                cbxDontNotify.Checked = true;
            }
            else
            {
                cbxDontNotify.Checked = false;
            }
            if (dtRqstFrGrnt.Rows[0]["NOTFTEMP_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["NOTFTEMP_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTemplate.Items.FindByValue(dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
                {
                    ddlTemplate.Items.FindByValue(dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["NOTFTEMP_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString());
                ddlTemplate.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTemplate);

                ddlTemplate.Items.FindByValue(dtRqstFrGrnt.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }
            if (dtRqstFrGrnt.Rows[0]["GUARANTEE_PERSON_ID"].ToString() != "")
            {
                cbxExistingEmployee.Checked = true;

                if (dtRqstFrGrnt.Rows[0]["PERSNUSERSTATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["PERSNCANCELUSERID"].ToString() == "")
                {
                    if (ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString()) != null)
                    {
                        ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["PERUSERNAME"].ToString(), dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString());
                    ddlExistingEmp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp);

                    ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PERUSERID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee.Checked = false;
                txtEmpName.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_PERSON_NAME"].ToString();
            }

            if (dtRqstFrGrnt.Rows[0]["USR_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlOwnershp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()) != null)
                {
                    ddlOwnershp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["USR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["USR_ID"].ToString());
                ddlOwnershp.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlOwnershp);

                ddlOwnershp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["BANK_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["BANK_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()) != null)
                {
                    ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["BANK_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString());
                ddlBank.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlBank);

                ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
            }





            //if (dtRqstFrGrnt.Rows[0]["BANK_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["BANK_CNCL_USR_ID"].ToString() == "")
            //{
            //    ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
            //}
            //else
            //{
            //    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["BANK_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString());
            //    ddlBank.Items.Insert(1, lstGrp);

            //    SortDDL(ref this.ddlOwnershp);

            //    ddlBank.Items.FindByValue(dtRqstFrGrnt.Rows[0]["BANK_ID"].ToString()).Selected = true;
            //}








            if (dtRqstFrGrnt.Rows[0]["GRNTYMTHD_ID"].ToString() == "101")
            {
                //LoadDdlForClientGtee();
                //GteeType
                if (dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString() != null || dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString() != "")
                {
                    if (ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                    {
                        ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                        ddlGteeType.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlGteeType);
                        ddlGteeType.ClearSelection();
                        if (ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                        {
                            ddlGteeType.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                        }
                    }
                }
                //Projects
                if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
                {
                    int intProjectId = 0, intGCatID = 0;
                    string strProjectName = "";

                    intGCatID = Convert.ToInt32(ddlGteeType.SelectedItem.Value);
                    if (dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString() != null && dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString() != "")
                    {
                        intProjectId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString());
                        strProjectName = dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString();
                        cbxPrjct.Checked = true;
                        ddlProjects.Enabled = false;
                    }
                    else
                    {
                        cbxPrjct.Checked = false;
                        txtPrjctName.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_PRJCT_NAME"].ToString();
                    }
                    LoadProjects(intGCatID, intProjectId, strProjectName);
                    txtPrjctName.Enabled = false;
                }
                cbxPrjct.Enabled = false;

                //Currency
                ddlCurrency.ClearSelection();
                if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                    {
                        ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCurrency);

                    ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                //customer
                if (dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString() != null || dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString() != "")
                {
                    if (ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()) != null)
                    {
                        ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString());
                        ddlCustomerList.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlCustomerList);
                        ddlCustomerList.ClearSelection();
                        if (ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()) != null)
                        {
                            ddlCustomerList.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                        }
                    }
                }
                //disble ddls
                ddlGteeType.Enabled = false;
                //ddlCurrency.Enabled = false;
                ddlCustomerList.Enabled = false;
                ddlProjects.Enabled = false;
                radioClient.Checked = true;
                radioSuplier.Checked = false;
                HiddenFieldRequestCltId.Value = dtRqstFrGrnt.Rows[0]["RFQ_ID"].ToString();
                //ObjEntityBnkGurnt.Guarantee_Method = 101;
                // ObjEntityBnkGurnt.GuarCatgryId = 1627;
                //del lbl
                //lblGuarntMde.Text = dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString();
                HiddenFieldMode.Value = dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString();
                // ObjEntityBnkGurnt.Contrctr =null ;
                //ObjEntityBnkGurnt.Customer = 1624;
                LabelCustmrContrctr.Text = dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString();
                HiddenFieldCustmor.Value = dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString();
                // ObjEntityBnkGurnt.Currency = 328;
                // ObjEntityBnkGurnt.Amount = Convert.ToDecimal(120.00);
                //del lbl
                //currcyLabl.Text = dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString();
                HiddenFieldCurrcy.Value = dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString();
                txtAmount.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                HiddenFieldAmount.Value = dtRqstFrGrnt.Rows[0]["GUARANTEE_AMOUNT"].ToString();
            }
            else if (dtRqstFrGrnt.Rows[0]["GRNTYMTHD_ID"].ToString() == "102")
            {
                //ObjEntityBnkGurnt.Guarantee_Method = 102;
                radioSuplier.Checked = true;
                radioClient.Checked = false;
                string strcatagory = "";
                ObjEntityBnkGurnt.GuarCatgryId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt123 = new clsBusinessLayerBankGuarantee();
                strcatagory = ObjBussinessBankGuarnt123.ChkCatagory(ObjEntityBnkGurnt);
                if (strcatagory == "101")
                {
                    if (dtRqstFrGrnt.Rows[0]["GUANTCAT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["GUANTCAT_CNCL_USR_ID"].ToString() == "")
                    {
                        if (ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                        {
                            ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                        }
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                        ddlGuarntyp.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlGuarntyp);

                        ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                    ddlGuarntyp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlGuarntyp);

                    ddlGuarntyp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                }

                if (dtRqstFrGrnt.Rows[0]["CNTRCT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CNTRCT_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlSubContrct.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString()) != null)
                    {
                        ddlSubContrct.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CNTRCT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString());
                    ddlSubContrct.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlSubContrct);

                    ddlSubContrct.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString()).Selected = true;
                }

                ddlCurrency.ClearSelection();
                if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                    {
                        ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCurrency);

                    ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }

                //ObjEntityBnkGurnt.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
                txtAmount.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_AMOUNT"].ToString();
                HiddenFieldCustmor.Value = dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString();
                ObjEntityBnkGurnt.Contrctr = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["CNTRCT_ID"].ToString());
                LabelCustmrContrctr.Text = dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString();
                //ObjEntityBnkGurnt.Customer = null;
            }

            if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
                radioLimited.Checked = false;
                //ObjEntityBnkGurnt.ExpireDate = DateTime.MinValue;
            }
            else if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "102")
            {

                // ObjEntityBnkGurnt.GuarTypeId = 102;
                radioLimited.Checked = true;
                radioOpen.Checked = false;
                txtValidity.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_NO_DAYS"].ToString();
                HiddenTextValidty.Value = dtRqstFrGrnt.Rows[0]["GUARANTEE_NO_DAYS"].ToString();
                txtPrjctClsngDate.Text = dtRqstFrGrnt.Rows[0]["GUARANTEE_EXP_DATE"].ToString();

            }

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("PictureAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));
            dtAttchmnt.Columns.Add("Description", typeof(string));

            DataTable dtPicGalleryFull = new DataTable();
            dtPicGalleryFull = ObjBussinessBankGuarnt.Read_Picture(ObjEntityBnkGurnt);
            if (dtPicGalleryFull.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtPicGalleryFull.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["PictureAttchmntDtlId"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_ID"].ToString();
                    drAttch["FileName"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_NAME"].ToString();
                    drAttch["ActualFileName"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_ACT_NAME"].ToString();
                    drAttch["Description"] = dtPicGalleryFull.Rows[intcnt]["GRNTY_ATCH_DESC"].ToString();
                    dtAttchmnt.Rows.Add(drAttch);

                }
                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenEditAttchmnt.Value = strJson;

            }


            //for filling template details

            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = new DataTable();
            dtEachTemplateDetail = ObjBussinessBankGuarnt.ReadTemplateDetailById(ObjEntityBnkGurnt);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    BnkGrntyTemplateDetail objEntityNotTempDetail = new BnkGrntyTemplateDetail();
                    objEntityNotTempDetail.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["GRTY_TMDTL_ID"]);
                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBussinessBankGuarnt.ReadTemplateAlertById(objEntityNotTempDetail);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRTY_TMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_TMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["GRNT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson2 = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson2;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
            hiddenTemplateLoadingMode.Value = "FromBnk";



            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtRqstFrGrnt.Rows[0]["GUARANTEE_STATUS"].ToString() == "3")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            }


            //if (hiddenRoleConfirm.Value != "")
            //{
            //    if (hiddenRoleConfirm.Value == "1")
            //    {

            //        if (dtRqstFrGrnt.Rows[0]["GUARANTEE_STATUS"].ToString() == "2")
            //        {
            //            imgbtnReOpen.Visible = true;
            //        }
            //    }
            //}
            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtRqstFrGrnt.Rows[0]["GUARANTEE_STATUS"].ToString() == "2")
                    {
                        imgbtnReOpen.Visible = true;
                    }
                }
            }

            if (HiddenGuarStatus.Value == "2" || HiddenGuarStatus.Value == "3")
            {
                if (HiddenRenew.Value == "1")
                {
                    btnrenew.Visible = true;
                }
                // btnUpdate.Visible = true;
                //btnUpdateClose.Visible = true;
                //if (hiddenRoleConfirm.Value != "")
                //{
                //    if (hiddenRoleConfirm.Value == "1")
                //    {
                //        btnConfirm.Visible = true;
                //    }
                //}
            }
            //else
            //{
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;
            //    btnConfirm.Visible = false;
            //}

            //if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "2" || dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "3")
            //{

            //    hiddenConfirmOrNot.Value = "1";
            //    txtCntctMail.Enabled = false;
            //    cbxStatus.Enabled = false;
            //    cbxExistingEmployee.Enabled = false;
            //    txtRemarks.Enabled = false;
            //    txtPrjctClsngDate.Enabled = false;
            //    txtInFavrOf.Enabled = false;
            //    txtEmpName.Enabled = false;
            //    txtAmount.Enabled = false;
            //    txtValidity.Enabled = false;
            //    ddlProject.Enabled = false;
            //    ddlJobCategory.Enabled = false;
            //    ddlGuaranteCat.Enabled = false;
            //    ddlExistingEmp.Enabled = false;
            //    ddlCustomer.Enabled = false;
            //    ddlCurrency.Enabled = false;
            //    radioOpen.Disabled = true;
            //    radioLimited.Disabled = true;
            //    btnUpdate.Visible = false;
            //    btnUpdateClose.Visible = false;

            //}
        }
        txtadress.Enabled = false;
        txtSubjct.Enabled = false;
        txtDescrptn.Enabled = false;
        txtGuarnteno.Enabled = false;
        txtCntctMail.Enabled = false;
        txtOpngDate.Enabled = false;
        cbxExistingEmployee.Enabled = false;
        ddlExistingEmp.Enabled = false;
        ddlOwnershp.Enabled = false;
        ddlBank.Enabled = false;
        ddlTemplate.Enabled = false;
        cbxDontNotify.Enabled = false;
        if (HiddenGuarStatus.Value == "2")
        {
            if (HiddenRenew.Value == "1")
            {
                // if (radioLimited.Checked == true)
                // {
                txtAmount.Enabled = true;
                // }
                //else
                //{
                // txtAmount.Enabled = false;
                // }
            }
            else
            {
                txtAmount.Enabled = false;
            }
        }
        else
        {
            txtAmount.Enabled = false;
        }
        radioClient.Disabled = true;

        radioSuplier.Disabled = true;
        ddlGuarntyp.Enabled = false;
        ddlSubContrct.Enabled = false;
        ddlCurrency.Enabled = false;
        radioOpen.Disabled = true;
        radioLimited.Disabled = true;
        txtValidity.Enabled = false;
        if (HiddenGuarStatus.Value == "2")
        {
            if (HiddenRenew.Value == "1")
            {
                if (radioLimited.Checked == true)
                {
                    txtPrjctClsngDate.Enabled = true;
                }
                else
                {
                    txtPrjctClsngDate.Enabled = false;
                }
            }
            else
            {
                txtPrjctClsngDate.Enabled = false;
            }
        }
        else
        {
            txtPrjctClsngDate.Enabled = false;
        }


        // txtValidity.Enabled = false;
        // txtAmount.Enabled = false;
        txtEmpName.Enabled = false;
        txtRemarks.Enabled = false;
    }

    public string ConvertDataTableToHTML(DataTable dt)
    {

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRandom = objCommon.Random_Number();




        // class="table table-bordered table-striped"
        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        // strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";




        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {


            if (intColumnHeaderCount == 1)
            {

                strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "GUARANTEE MODE" + "</th>";

            }
            if (intColumnHeaderCount == 2)
            {

                strHtml += "<th class=\"thT\" style=\"width:34%; word-wrap:break-word; text-align: center;\">" + "CUSTOMER" + "</th>";

            }
            else if (intColumnHeaderCount == 3)
            {

                strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "PROJECT" + "</th>";

            }

            else if (intColumnHeaderCount == 4)
            {

                strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: right; word-wrap:break-word;\">" + "AMOUNT" + "</th>";

            }



        }


        if (HiddenFieldClient.Value == "1")
        {

            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">IMPORT</th>";

        }








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

                    strHtml += "<td class=\"tdT\" style=\" width:34%;word-break: break-all; word-wrap:break-word; text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 3)
                {

                    strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                }
                else if (intColumnBodyCount == 4)
                {
                    string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                    strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";

                }
            }
            string strId = dt.Rows[intRowBodyCount][0].ToString();
            //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
            //  string stridLength = intIdLength.ToString("00");
            //string Id = stridLength + strId + strRandom;




            if (HiddenFieldClient.Value == "1")
            {


                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;cursor:pointer \" title=\"Import\"   onclick=\"return ImportView('" + strId + "'); \" >" +
                                     "<img  style=\"\" src='/Images/Icons/Re-open.png' /> " + "</a> </td>";

            }


            //  if (intEnableClose==Convert.ToInt32(clsCommonLibrary.StatusAll.Active))









            strHtml += "</tr>";
        }
        strHtml += "</tbody>";

        strHtml += "</table>";



        sb.Append(strHtml);
        return sb.ToString();
    }
    public class Reqstgurnte
    {
        public int intCtacgryId = 0;
        public string strCtacgryNme = "";
        public string strCustmrAddress = "";
        public int intCustNameId = 0;
        public string strCustName = "";
        public int intProjctId = 0;
        public string strProjctName = "";
        public decimal decAmount = 0;
        public int intCurracyId = 0;
        public string strCurracyName = "";
        public int intGurnttyp = 0;
        public int intRequestGrdId = 0;
        public string strExpireDate = "";
        public DateTime dateExpiredt = DateTime.MinValue;
        public int intNoOfDays = 0;
        public string stropngDate = "";

        public string ConvertDataTableToHTML(DataTable dt)
        {

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            // objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
            clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();




            // class="table table-bordered table-striped"
            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";
            // strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\"> </th>";




            for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
            {


                if (intColumnHeaderCount == 1)
                {

                    strHtml += "<th class=\"thT\" style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "GUARANTEE MODE" + "</th>";

                }
                if (intColumnHeaderCount == 2)
                {

                    strHtml += "<th class=\"thT\" style=\"width:34%; word-wrap:break-word; text-align: left;\">" + "CUSTOMER" + "</th>";

                }
                else if (intColumnHeaderCount == 3)
                {

                    strHtml += "<th class=\"thT\"  style=\"width:20%;text-align: left; word-wrap:break-word;\">" + "PROJECT" + "</th>";

                }

                else if (intColumnHeaderCount == 4)
                {

                    strHtml += "<th class=\"thT\"  style=\"width:22%;text-align: right; word-wrap:break-word;\">" + "AMOUNT" + "</th>";

                }



            }


            //  if (HiddenFieldClient.Value == "1")
            // {

            strHtml += "<th class=\"thT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">IMPORT</th>";

            //    }








            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows
            strHtml += "<tbody>";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {

                string strReqstId = "";
                int intDuplkChk = 0;
                string strRfqIDChk = dt.Rows[intRowBodyCount]["RFQ_ID"].ToString();
                ObjEntityRequest.ReqstGrntId = Convert.ToInt32(strRfqIDChk);
                ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["CORPRT_ID"].ToString());
                ObjEntityRequest.Organisation_Id = Convert.ToInt32(dt.Rows[intRowBodyCount]["ORG_ID"].ToString());
                strReqstId = ObjBussinessBankGuarnt.ChckDupReqstId(ObjEntityRequest);
                if (strReqstId == "" || strReqstId == "0")
                {
                    intDuplkChk = 1;
                }


                strHtml += "<tr  >";


                for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                {

                    if (intColumnBodyCount == 1)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    if (intColumnBodyCount == 2)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:34%;word-break: break-all; word-wrap:break-word; text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 3)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";

                    }
                    else if (intColumnBodyCount == 4)
                    {
                        string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                        string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                        strHtml += "<td class=\"tdT\" style=\" width:22%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + " " + dt.Rows[intRowBodyCount]["CRNCMST_ABBRV"].ToString() + "</td>";

                    }
                }
                string strId = dt.Rows[intRowBodyCount][0].ToString();
                //int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                //  string stridLength = intIdLength.ToString("00");
                //string Id = stridLength + strId + strRandom;



                //  if (HiddenFieldClient.Value == "1")
                // {


                if (intDuplkChk != 0)
                {

                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltipp\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-right: 21.5%;cursor:pointer \" title=\"Import\"   onclick=\"return ImportView('" + strId + "'); \" >" +
                                             "<img  style=\"\" src='/Images/Icons/Import.png' /> " + "</a> </td>";

                }
                else
                {
                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltipp\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-right: 21.5%;cursor:pointer \" title=\"Import\"  onclick='return ImportNotPossible();' >"
                         + "<img style=\"opacity: 0.2;cursor: pointer; \" src='/Images/Icons/Import.png' /> " + "</a> </td>";
                }

                //  }


                //  if (intEnableClose==Convert.ToInt32(clsCommonLibrary.StatusAll.Active))









                strHtml += "</tr>";
            }
            strHtml += "</tbody>";

            strHtml += "</table>";



            sb.Append(strHtml);
            return sb.ToString();
        }

    }

    // this web method is for fetching data based on the card selected 
    [WebMethod]
    public static Reqstgurnte ReadReqstgurnte(string GuarnteId)
    {

        Reqstgurnte objReqstgurnte = new Reqstgurnte();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (GuarnteId != null && GuarnteId != "" && GuarnteId != "undefined")
        {
            ObjEntityRequest.GuaranteeId = Convert.ToInt32(GuarnteId);
        }

        DataTable dtWtrCrdDtl = new DataTable();

        dtWtrCrdDtl = ObjBussinessBankGuarnt.ReadRequestByID(ObjEntityRequest);
        if (dtWtrCrdDtl.Rows.Count > 0)
        {
            objReqstgurnte.intCtacgryId = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["GUANTCAT_ID"].ToString());
            objReqstgurnte.strCtacgryNme = dtWtrCrdDtl.Rows[0]["GUANTCAT_NAME"].ToString();
            objReqstgurnte.strCustmrAddress = dtWtrCrdDtl.Rows[0]["CSTMR_ADDRESS1"].ToString();
            objReqstgurnte.intCustNameId = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["CSTMR_ID"].ToString());
            objReqstgurnte.strCustName = dtWtrCrdDtl.Rows[0]["CSTMR_NAME"].ToString();
            objReqstgurnte.intProjctId = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["PROJECT_ID"].ToString());
            objReqstgurnte.strProjctName = dtWtrCrdDtl.Rows[0]["PROJECT_NAME"].ToString();
            objReqstgurnte.decAmount = Convert.ToDecimal(dtWtrCrdDtl.Rows[0]["RFQ_AMOUNT"].ToString());
            objReqstgurnte.intCurracyId = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["CRNCMST_ID"].ToString());
            objReqstgurnte.strCurracyName = dtWtrCrdDtl.Rows[0]["CRNCMST_NAME"].ToString();
            objReqstgurnte.intGurnttyp = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["GUARNTYPE_ID"].ToString());
            objReqstgurnte.intRequestGrdId = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["RFQ_ID"].ToString());
            objReqstgurnte.strExpireDate = dtWtrCrdDtl.Rows[0]["RFQ_CLOSING_DATE"].ToString();
            if (dtWtrCrdDtl.Rows[0]["RFQ_VALIDITY_DAYS"].ToString() != "")
            {
                DateTime ExDate = DateTime.MinValue, opnDate = DateTime.MinValue;
                objReqstgurnte.intNoOfDays = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["RFQ_VALIDITY_DAYS"].ToString());
                int numdays = Convert.ToInt32(dtWtrCrdDtl.Rows[0]["RFQ_VALIDITY_DAYS"].ToString());
                ExDate = objCommon.textToDateTime(dtWtrCrdDtl.Rows[0]["RFQ_CLOSING_DATE"].ToString());
                opnDate = ExDate.AddDays(-(numdays));
                objReqstgurnte.stropngDate = opnDate.ToString("dd-MM-yyyy");
            }
            //objReqstgurnte.dateExpiredt = objCommon.textToDateTime(strdate); 
            //dtWtrCrdDtl.Rows[0]["RFQ_CLOSING_DATE"].ToString();
        }
        return objReqstgurnte;
    }

    // this web method is for fetching data based on the card selected 
    [WebMethod]
    public static string ReadReqstListBySrch(string GuarnteModeId, string CustmerId, string StrOrgId, string StrCorpId, string StrUserId)
    {

        Reqstgurnte objReqstgurnte = new Reqstgurnte();
        //Creating objects for business layer
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        ObjEntityRequest.Organisation_Id = Convert.ToInt32(StrOrgId);
        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(StrCorpId);
        ObjEntityRequest.User_Id = Convert.ToInt32(StrUserId);
        if (GuarnteModeId != null && GuarnteModeId != "" && GuarnteModeId != "undefined" && GuarnteModeId != "--SELECT GUARANTEE MODE--")
        {
            // ObjEntityRequest.Guarantee_Method = Convert.ToInt32(GuarnteModeId);

            ObjEntityRequest.Guarantee_Method = Convert.ToInt32(GuarnteModeId);

        }
        else
        {
            ObjEntityRequest.Guarantee_Method = 0;
        }

        if (CustmerId != null && CustmerId != "" && CustmerId != "undefined" && CustmerId != "--SELECT--")
        {
            //  ObjEntityRequest.CusSuply = Convert.ToInt32(CustmerId);

            ObjEntityRequest.CusSuply = Convert.ToInt32(CustmerId);

        }
        else
        {
            ObjEntityRequest.CusSuply = 0;
        }

        DataTable dtWtrCrdDtl = new DataTable();

        dtWtrCrdDtl = ObjBussinessBankGuarnt.ReadRequesClienttGuaranteeList(ObjEntityRequest);
        string strHtm = objReqstgurnte.ConvertDataTableToHTML(dtWtrCrdDtl);
        //Write to divReport
        //divReport.InnerHtml = strHtm;
        return strHtm;
    }


    [WebMethod]
    public static string ReadReqstListClient(string StrOrgId, string StrCorpId, string StrUserId)
    {

        Reqstgurnte objReqstgurnte = new Reqstgurnte();
        //Creating objects for business layer
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        ObjEntityRequest.Organisation_Id = Convert.ToInt32(StrOrgId);
        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(StrCorpId);
        ObjEntityRequest.User_Id = Convert.ToInt32(StrUserId);


        DataTable dtWtrCrdDtl = new DataTable();

        dtWtrCrdDtl = ObjBussinessBankGuarnt.ReadRequesClienttGuaranteeList(ObjEntityRequest);
        string strHtm = objReqstgurnte.ConvertDataTableToHTML(dtWtrCrdDtl);
        //Write to divReport
        //divReport.InnerHtml = strHtm;
        return strHtm;
    }

    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        DropDownEmployeeDataStore();
        DropdownDesignationDataStore();
        DropdownDivisionDataStore();
        int strId = Convert.ToInt32(ddlTemplate.SelectedItem.Value);
        objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);

        if (dtTemplate.Rows.Count > 0)
        {
            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = new DataTable();
            dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);
                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
        }
        string importchk = HiddenImportaddchk.Value;
        ScriptManager.RegisterStartupScript(this, GetType(), "TemplateLoad", "TemplateLoad(" + importchk + ");", true);

        string a = HiddenImportaddchk.Value;
    }

    public void DefaultTemplateLoad()
    {
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtDfltTemp = new DataTable();
        dtDfltTemp = ObjBussinessBankGuarnt.ReadDefaultNotifyTemplates(ObjEntityRequest);
        int templateid = 0;
        if (dtDfltTemp.Rows.Count > 0)
        {
            templateid = Convert.ToInt32(dtDfltTemp.Rows[0]["NOTFTEMP_ID"]);
            if (ddlTemplate.Items.FindByValue(dtDfltTemp.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
            {
                ddlTemplate.Items.FindByValue(dtDfltTemp.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }
        }
        objEntityNotTemp.NotTempId = Convert.ToInt32(templateid);
        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);


        if (dtTemplate.Rows.Count > 0)
        {
            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = new DataTable();
            dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);
                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail.Value = strJson;
                hiddenTemplateAlertData.Value = strAlertDetailFull;
            }
        }
        hiddenTemplateLoadingMode.Value = "FromTemp";

    }


    public void DropdownDivisionDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = "dtTableDivision";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDivisionddlData.Value = result;
    }


    public void DropdownDesignationDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = "dtTableDesignation";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDesignationddlData.Value = result;
    }

    public void DropDownEmployeeDataStore()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmployeeDdlData.Value = result;
    }
    [WebMethod]
    public static string DropdownDivisionBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();

        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string DropdownDesignationBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    [WebMethod]
    public static string DropdownEmployeeBind(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    public void LoadDdlForClientGtee()
    {
        //This function loads DDL for client Gtee
        //This loads DDLs ClientGtee,Project,Currency,Customer
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //DataTable dtSubConrt = ObjBussinessBankGuarnt.ReadBankLoad(ObjEntityRequest);
        //if (dtSubConrt.Rows.Count > 0)
        //{
        //    ddlBank.DataSource = dtSubConrt;
        //    ddlBank.DataTextField = "BANK_NAME";
        //    ddlBank.DataValueField = "BANK_ID";
        //    ddlBank.DataBind();
        //}
        //ddlBank.Items.Insert(0, "--SELECT BANK--");
        //EVM-0012
        //ddlGteeType
        //DataTable dtUser = new DataTable();
        //dtUser = objBusinessLayerGuarantee.ReadGuaranteTypeList(objEntityGuaranteType);

        //Category
        DataTable dtCategory = new DataTable();
        dtCategory = ObjBussinessBankGuarnt.GteeTypeClient(ObjEntityRequest);
        if (dtCategory.Rows.Count > 0)
        {
            ddlGteeType.DataSource = dtCategory;
            ddlGteeType.DataTextField = "GUANTCAT_NAME";
            ddlGteeType.DataValueField = "GUANTCAT_ID";
            ddlGteeType.DataBind();
        }
        ddlGteeType.Items.Insert(0, "--SELECT GUARANTEE MODE--");
        //Project
        ddlProjects.Items.Insert(0, "--SELECT PROJECT--");
        //Currency
        //DataTable dtCurrency = new DataTable();
        //dtCurrency = ObjBussinessBankGuarnt.ReadCurrency(ObjEntityRequest);
        //Customer
        DataTable dtCustomer = new DataTable();
        dtCustomer = ObjBussinessBankGuarnt.ReadCustomerLoad(ObjEntityRequest);
        if (dtCustomer.Rows.Count > 0)
        {
            ddlCustomerList.DataSource = dtCustomer;
            ddlCustomerList.DataTextField = "CSTMR_NAME";
            ddlCustomerList.DataValueField = "CSTMR_ID";
            ddlCustomerList.DataBind();
        }
        ddlCustomerList.Items.Insert(0, "--SELECT CUSTOMER--");

    }

    protected void ddlGteeType_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intGuarCatgryId = 0;
        if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
        {
            intGuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);
            LoadProjects(intGuarCatgryId);

        }
        ScriptManager.RegisterStartupScript(this, GetType(), "AutocomProjct", "AutocomProjct();", true);

    }
    //protected void ddlCustomerList_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownEmployeeDataStore();
    //    DropdownDesignationDataStore();
    //    DropdownDivisionDataStore();
    //    clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }

    //    if (Session["ORGID"] != null)
    //    {
    //        ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (ddlCustomerList.SelectedItem.Value != "--SELECT CUSTOMER--")
    //    {
    //        ObjEntityRequest.Customer = Convert.ToInt32(ddlCustomerList.SelectedItem.Value);
    //        DataTable dtProjects = new DataTable();
    //        dtProjects = ObjBussinessBankGuarnt.ReadCustomerAddrByID(ObjEntityRequest);
    //        if (dtProjects.Rows.Count > 0)
    //        {
    //            txtadress.Text = dtProjects.Rows[0]["CSTMR_ADDRESS1"].ToString();
    //        }
    //    }
    //    ddlCustomerList.Focus();
    //    ScriptManager.RegisterStartupScript(this, GetType(), "RadioClientClick", "RadioClientClick();", true);
    //}

    [WebMethod]
    public static string CustomerChange(int OrgId, int CorpId, int Custid)
    {
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        string Address = "";

        ObjEntityRequest.Organisation_Id = OrgId;
        ObjEntityRequest.CorpOffice_Id = CorpId;
        ObjEntityRequest.Customer = Custid;

        DataTable dtProjects = new DataTable();
        dtProjects = ObjBussinessBankGuarnt.ReadCustomerAddrByID(ObjEntityRequest);
        if (dtProjects.Rows.Count > 0)
        {
            Address = dtProjects.Rows[0]["CSTMR_ADDRESS1"].ToString();
        }
        return Address;

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["default"] != null)
        {
            if (Request.QueryString["default"] == "3months")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?default=3months");
            }
            else if (Request.QueryString["default"] == "expired")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?default=expired");
            }
            else
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx");
            }
        }
        else
        {
            Response.Redirect("gen_Bank_Guarantee_List.aspx");
        }
    }
    public void LoadProjects(int intGuarCatgryId, int intProjectId = 0, string strProjectName = null)
    {
        DropDownEmployeeDataStore();
        DropdownDesignationDataStore();
        DropdownDivisionDataStore();
        //LOAD PROJECTS BASED ON GTEE TYPE
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //ObjEntityRequest.GuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);
        ObjEntityRequest.GuarCatgryId = intGuarCatgryId;
        DataTable dtProjects = new DataTable();
        dtProjects = ObjBussinessBankGuarnt.ReadProjectGteeTypeID(ObjEntityRequest);
        if (dtProjects.Rows.Count > 0)
        {
            ddlProjects.Items.Clear();
            ddlProjects.DataSource = dtProjects;
            ddlProjects.DataTextField = "PROJECT_NAME";
            ddlProjects.DataValueField = "PROJECT_ID";
            ddlProjects.DataBind();
        }
        ddlProjects.Items.Insert(0, "--SELECT PROJECT--");
        //ReadProjectGteeTypeID
        //RadioClientClick();
        if (intProjectId != 0)
        {
            if (ddlProjects.Items.FindByValue(intProjectId.ToString()) != null)
            {
                ddlProjects.Items.FindByValue(intProjectId.ToString()).Selected = true;
            }

            else
            {
                ListItem lstGrp = new ListItem(strProjectName, intProjectId.ToString());
                ddlProjects.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProjects);
                ddlProjects.ClearSelection();
                if (ddlProjects.Items.FindByValue(intProjectId.ToString()) != null)
                {
                    ddlProjects.Items.FindByValue(intProjectId.ToString()).Selected = true;
                }
            }

        }
        ddlGteeType.Focus();
        ScriptManager.RegisterStartupScript(this, GetType(), "RadioClientClick", "RadioClientClick();", true);

    }


    protected void btnNewProject_Click(object sender, EventArgs e)
    {
        int intGuarCatgryId = 0;
        string strProjectid = "";
        if (ddlGteeType.SelectedItem.Value != "--SELECT GUARANTEE MODE--")
        {
            intGuarCatgryId = Convert.ToInt32(ddlGteeType.SelectedItem.Value);
            LoadProjects(intGuarCatgryId);

            string target = Request["__EVENTTARGET"];

            if (target == "ctl00$cphMain$btnNewProject")
            {
                strProjectid = hiddenNewProjectId.Value;
                if (ddlProjects.Items.FindByValue(strProjectid) != null)
                {
                    ddlProjects.ClearSelection();
                    ddlProjects.Items.FindByValue(strProjectid).Selected = true;
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelProjectLoad", "UpdatePanelProjectLoad(" + strProjectid + ");", true);

        }
        else
        {
            LoadProjects(0);
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelProjectLoad", "UpdatePanelProjectLoad(" + strProjectid + ");", true);
        }
        


    }

    [WebMethod]
    public static string DuplctnGurntNumChk(string OrgId, string CorpId, string GurntId, string GurntNo)
    {
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(CorpId);
        ObjEntityRequest.Organisation_Id = Convert.ToInt32(OrgId);
        ObjEntityRequest.GuaranteeNo = GurntNo;
        ObjEntityRequest.GuaranteeId = Convert.ToInt32(GurntId);
        //DataTable dtEmployeeList = new DataTable();
        //dtEmployeeList = ObjBussinessBankGuarnt.ReadEmployee(ObjEntityRequest);

        string result = "0";
        string strGurntNo = ObjBussinessBankGuarnt.ChckDuplGurntNo(ObjEntityRequest);
        if (strGurntNo == "" || strGurntNo == "0")
        {
            result = "0";
        }
        else
        {
            result = "1";
        }

        return result;

    }

    [WebMethod]
    public static string[] ReadCusByPrjctId(string a, string OrgId, string CorpId)
    {
        string[] CusData = new string[7];
        clsBusinessLayerBankGuarantee ObjBussinessBankGuarnt = new clsBusinessLayerBankGuarantee();
        clsEntityLayerBankGuarantee ObjEntityRequest = new clsEntityLayerBankGuarantee();
        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(CorpId);
        ObjEntityRequest.Organisation_Id = Convert.ToInt32(OrgId);
        ObjEntityRequest.ProjectId = Convert.ToInt32(a);

        DataTable dtCustomer = new DataTable();
        dtCustomer = ObjBussinessBankGuarnt.ReadCustomerLoad(ObjEntityRequest);

        DataTable dtCustDtl = ObjBussinessBankGuarnt.ReadCustomerDtlByPrjID(ObjEntityRequest);

        if (dtCustDtl.Rows.Count > 0)
        {

            CusData[0] = dtCustDtl.Rows[0]["CSTMR_ID"].ToString();
            CusData[1] = dtCustDtl.Rows[0]["CSTMR_ADDRESS1"].ToString();
            CusData[2] = "0";
            bool existsCus = dtCustomer.Select().ToList().Exists(row => row["CSTMR_ID"].ToString().ToUpper() == CusData[0]);
            if (existsCus == true)
            {
                CusData[2] = "1";
            }
        }

        return CusData;

    }
    //evm-0012 Adding Contracts
    protected void btnNewContract_Click(object sender, EventArgs e)
    {


        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewContract")
        {
            int intSubContract = Convert.ToInt32(hiddenNewContractId.Value);
            SubContractLoad(intSubContract);
            ddlSubContrctSelIndexChange();
            //ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelProjectLoad", "UpdatePanelProjectLoad(" + strProjectid + ");", true);
        }


    }



    //-------------------insurance-----------------------

    public void LoadFunction_INSRNC()
    {
        LoadCurrency_INSRNC();
        LoadEmployee_INSRNC();
        LoadInsuranceProvider_INSRNC();
        LoadInsuranceType_Master(); // evm-0023
        NotifyTempLoad_INSRNC();

        txtValidity_INSRNC.Enabled = false;
        imgbtnReOpen_INSRNC.Visible = false;
        btnConfirm_INSRNC.Visible = false;
        btnrenew_INSRNC.Visible = false;

        HiddenFieldView_INSRNC.Value = "";
        HiddenFieldUpdate_INSRNC.Value = "0";
        hiddenFileCanclDtlId_INSRNC.Value = "";
        HiddenField2_FileUploadLnk_INSRNC.Value = "";
        hiddenEditAttchmnt_INSRNC.Value = "";
        HiddenRenew_INSRNC.Value = "";
        HiddenDuplictnchk_INSRNC.Value = "0";
        hiddenRoleAddProjct_INSRNC.Value = "";

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
        int intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0, intOrgId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            HiddenCorpId_INSRNC.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            HiddenOrgansId_INSRNC.Value = Session["ORGID"].ToString();
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        int intUsrRolMstrId, intEnableAdd = 0, intUsrRolMstrIdprjct = 0, intEnableReOpen = 0, intEnableConfirm = 0, intEnableClose = 0, intEnableAdd1 = 0, intUsrRolMstrIdContract = 0;
        //Allocating child roles
        hiddenRoleAdd_INSRNC.Value = "0";
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Bank_Guarantee);
        intUsrRolMstrIdprjct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project);

        DataTable dtPrjct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdprjct);
        DataTable dtContractRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdContract);

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
                    hiddenRoleAdd_INSRNC.Value = intEnableAdd.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleReOpen_INSRNC.Value = intEnableReOpen.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleConfirm_INSRNC.Value = intEnableConfirm.ToString();
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                }
            }
        }

        if (dtPrjct.Rows.Count > 0)
        {
            string strChildRolDeftn1 = dtPrjct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            string[] strChildDefArrWords1 = strChildRolDeftn1.Split('-');
            foreach (string strC_Role in strChildDefArrWords1)
            {
                if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                {
                    intEnableAdd1 = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    hiddenRoleAddProjct_INSRNC.Value = intEnableAdd1.ToString();
                }
            }

        }
        if (hiddenRoleAddProjct_INSRNC.Value == "")
        {
            btnNewProject_INSRNC.Visible = false;
        }

        if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
        {
            btnUpdate_INSRNC.Visible = false;
            btnUpdateClose_INSRNC.Visible = false;
            btnAdd_INSRNC.Visible = false;
            btnAddClose_INSRNC.Visible = false;
            btnClear_INSRNC.Visible = false;
        }
        else
        {
            btnUpdate_INSRNC.Visible = false;
        }

        hiddenFilePath_INSRNC.Value = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
        DataTable dtAttchmnt = objBusinessInsurance.Read_AllAttachment();
        if (dtAttchmnt.Rows.Count > 0)
        {
            hiddenAttchmntSlNumber_INSRNC.Value = dtAttchmnt.Rows[0]["INSRNC_ATTCH_SL_NUM"].ToString();
        }

        clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetail = new DataTable();
        dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
        if (dtCorpDetail.Rows.Count > 0)
        {
            hiddenDecimalCount_INSRNC.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            hiddenDfltCurrencyMstrId_INSRNC.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        }

        // for adding comma
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId_INSRNC.Value);
        DataTable dtCurrencyDetail = new DataTable();
        dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
        if (dtCurrencyDetail.Rows.Count > 0)
        {
            hiddenCurrencyModeId_INSRNC.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
        }

        string strCurrentDate = objBusinessLayer.LoadCurrentDateInString();
        hiddenCurrentDate_INSRNC.Value = strCurrentDate;

        if (Request.QueryString["Id_INSRNC"] != null)
        {
            btnClear_INSRNC.Visible = false;
            string strRandomMixedId = Request.QueryString["Id_INSRNC"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            Update_INSRNC(strId);
            lblEntry.Text = "Edit Insurance";

            if (hiddenRoleAdd_INSRNC.Value.ToString() != "")
            {
                if (Convert.ToInt32(hiddenRoleAdd_INSRNC.Value.ToString()) != Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    btnUpdate_INSRNC.Visible = false;
                }
            }
        }

        else if (Request.QueryString["Renew_INSRNC"] != null)
        {
            string strRandomMixedId = Request.QueryString["Renew_INSRNC"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.User_Id = intUserId;
            objEntityInsurance.D_Date = System.DateTime.Now;
            imgbtnReOpen_INSRNC.Visible = false;

            btnNewProject_INSRNC.Visible = false;
            HiddenRenew_INSRNC.Value = "1";
            btnUpdate_INSRNC.Visible = false;
            btnUpdateClose_INSRNC.Visible = false;
            btnAdd_INSRNC.Visible = false;
            btnAddClose_INSRNC.Visible = false;
            btnrenew_INSRNC.Visible = true;
            btnClear_INSRNC.Visible = false;

            View_INSRNC(strId);

            lblEntry.Text = "Renew Insurance";
            hiddenEditMode_INSRNC.Value = "View";
        }
        else if (Request.QueryString["ViewId_INSRNC"] != null)
        {
            btnNewProject_INSRNC.Visible = false;
            btnClear_INSRNC.Visible = false;
            string strRandomMixedId = Request.QueryString["ViewId_INSRNC"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            View_INSRNC(strId);

            lblEntry.Text = "View Insurance";
            hiddenEditMode_INSRNC.Value = "View";
        }
        else
        {
            lblEntry.Text = "Add Insurance";

            DropDownEmployeeDataStore_INSRNC();
            DropdownDesignationDataStore_INSRNC();
            DropdownDivisionDataStore_INSRNC();

            DefaultTemplateLoad_INSRNC();
            LoadProjects_INSRNC(0, "");

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_MSTR);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

            string year = DateTime.Today.Year.ToString();
            LabelRefnum_INSRNC.Text = "INSRNC/" + year + "/" + strNextId;

            btnUpdate_INSRNC.Visible = false;
            btnUpdateClose_INSRNC.Visible = false;
            btnAdd_INSRNC.Visible = true;
            btnAddClose_INSRNC.Visible = true;
            btnClear_INSRNC.Visible = true;

            cbxExistingEmployee_INSRNC.Checked = true;
            radioOpen_INSRNC.Checked = true;
            btnConfirm_INSRNC.Visible = false;
            btnrenew_INSRNC.Visible = false;
            imgbtnReOpen_INSRNC.Visible = false;
        }

        if (Request.QueryString["InsUpd_INSRNC"] != null)
        {
            string strInsUpd = Request.QueryString["InsUpd_INSRNC"].ToString();
            if (strInsUpd == "Ins")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation_INSRNC", "SuccessConfirmation_INSRNC();", true);
            }
            else if (strInsUpd == "Upd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation_INSRNC", "SuccessUpdation_INSRNC();", true);
            }
            else if (strInsUpd == "Cnfrm")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirm_INSRNC", "SuccessConfirm_INSRNC();", true);
            }
            else if (strInsUpd == "ReOpen")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReOpen_INSRNC", "SuccessReOpen_INSRNC();", true);
            }
            else if (strInsUpd == "Renewd")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessGuaranteeRenewed_INSRNC", "SuccessGuaranteeRenewed_INSRNC();", true);
            }
        }
    }

    public void LoadCurrency_INSRNC()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtCurrency = objBusinessInsurance.ReadCurrency(objEntityInsurance);
        if (dtCurrency.Rows.Count > 0)
        {
            ddlCurrency_INSRNC.DataSource = dtCurrency;
            ddlCurrency_INSRNC.DataTextField = "CRNCMST_NAME";
            ddlCurrency_INSRNC.DataValueField = "CRNCMST_ID";
            ddlCurrency_INSRNC.DataBind();

        }
        string strdefltcurrcy = hiddenDfltCurrencyMstrId_INSRNC.Value;
        if (ddlCurrency_INSRNC.Items.FindByValue(strdefltcurrcy) != null)
        {
            ddlCurrency_INSRNC.Items.FindByValue(strdefltcurrcy).Selected = true;
        }
    }

    public void LoadEmployee_INSRNC()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtEmp = objBusinessInsurance.ReadEmployee(objEntityInsurance);
        if (dtEmp.Rows.Count > 0)
        {
            ddlExistingEmp_INSRNC.DataSource = dtEmp;
            ddlExistingEmp_INSRNC.DataTextField = "USR_NAME";
            ddlExistingEmp_INSRNC.DataValueField = "USR_ID";
            ddlExistingEmp_INSRNC.DataBind();
        }
        ddlExistingEmp_INSRNC.Items.Insert(0, "--SELECT EMPLOYEE--");
    }

    public void LoadInsuranceProvider_INSRNC()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtInsurancePrvdrs = objBusinessInsurance.ReadInsuranceProviders(objEntityInsurance);
        if (dtInsurancePrvdrs.Rows.Count > 0)
        {
            ddlInsurncPrvdr.DataSource = dtInsurancePrvdrs;
            ddlInsurncPrvdr.DataTextField = "INSURPRVDR_NAME";
            ddlInsurncPrvdr.DataValueField = "INSURPRVDR_ID";
            ddlInsurncPrvdr.DataBind();
        }
        ddlInsurncPrvdr.Items.Insert(0, "--SELECT INSURANCE PROVIDER--");
    }

    public void LoadProjects_INSRNC(int ProjctId, string PrjctName)
    {
        DropDownEmployeeDataStore_INSRNC();
        DropdownDesignationDataStore_INSRNC();
        DropdownDivisionDataStore_INSRNC();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtProjects = objBusinessInsurance.ReadProjects(objEntityInsurance);
        if (dtProjects.Rows.Count > 0)
        {
            ddlProjects_INSRNC.Items.Clear();
            ddlProjects_INSRNC.DataSource = dtProjects;
            ddlProjects_INSRNC.DataTextField = "PROJECT_NAME";
            ddlProjects_INSRNC.DataValueField = "PROJECT_ID";
            ddlProjects_INSRNC.DataBind();
        }
        ddlProjects_INSRNC.Items.Insert(0, "--SELECT PROJECT--");

        if (ProjctId != 0)
        {
            if (ddlProjects_INSRNC.Items.FindByValue(ProjctId.ToString()) != null)
            {
                ddlProjects_INSRNC.Items.FindByValue(ProjctId.ToString()).Selected = true;
            }

            else
            {
                ListItem lstGrp = new ListItem(PrjctName, ProjctId.ToString());
                ddlProjects_INSRNC.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProjects_INSRNC);
                ddlProjects_INSRNC.ClearSelection();
                if (ddlProjects_INSRNC.Items.FindByValue(ProjctId.ToString()) != null)
                {
                    ddlProjects_INSRNC.Items.FindByValue(ProjctId.ToString()).Selected = true;
                }
            }
        }

    }

  
    public void NotifyTempLoad_INSRNC()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtTemplate = objBusinessInsurance.ReadNotifyTemplates(objEntityInsurance);
        if (dtTemplate.Rows.Count > 0)
        {
            ddlTemplate_INSRNC.DataSource = dtTemplate;
            ddlTemplate_INSRNC.DataTextField = "NOTFTEMP_NAME";
            ddlTemplate_INSRNC.DataValueField = "NOTFTEMP_ID";
            ddlTemplate_INSRNC.DataBind();
        }
        else
        {
            ddlTemplate_INSRNC.Items.Insert(0, "--SELECT TEMPLATE--");
        }
    }

    public void DefaultTemplateLoad_INSRNC()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtDfltTemp = objBusinessInsurance.ReadDefaultNotifyTemplates(objEntityInsurance);

        int templateid = 0;
        if (dtDfltTemp.Rows.Count > 0)
        {
            templateid = Convert.ToInt32(dtDfltTemp.Rows[0]["NOTFTEMP_ID"]);
            if (ddlTemplate_INSRNC.Items.FindByValue(dtDfltTemp.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
            {
                ddlTemplate_INSRNC.Items.FindByValue(dtDfltTemp.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }
        }

        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        objEntityNotTemp.NotTempId = Convert.ToInt32(templateid);

        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);
        if (dtTemplate.Rows.Count > 0)
        {
            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;
                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);

                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail_INSRNC.Value = strJson;
                hiddenTemplateAlertData_INSRNC.Value = strAlertDetailFull;
            }
        }
        hiddenTemplateLoadingMode_INSRNC.Value = "FromTemp";
    }

    public void DropdownDivisionDataStore_INSRNC()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = "dtTableDivision";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDivisionddlData_INSRNC.Value = result;
    }


    public void DropdownDesignationDataStore_INSRNC()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {

            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = "dtTableDesignation";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenDesignationddlData_INSRNC.Value = result;
    }

    public void DropDownEmployeeDataStore_INSRNC()
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        if (Session["USERID"] != null)
        {
            objEntityNotTemp.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityNotTemp.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityNotTemp.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = "dtTableEmployee";
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }
        hiddenEmployeeDdlData_INSRNC.Value = result;
    }
    [WebMethod]
    public static string DropdownDivisionBind_INSRNC(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();

        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDivisionList = new DataTable();
        dtDivisionList = ObjBusinessNotiFi.ReadDivision(objEntityNotTemp);
        dtDivisionList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDivisionList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }
    [WebMethod]
    public static string DropdownDesignationBind_INSRNC(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtDesignationList = new DataTable();
        dtDesignationList = ObjBusinessNotiFi.ReadDesignations(objEntityNotTemp);
        dtDesignationList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtDesignationList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }

    [WebMethod]
    public static string DropdownEmployeeBind_INSRNC(string tableName, int CorpId, int OrgId)
    {
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        objEntityNotTemp.CorpOffice_Id = CorpId;
        objEntityNotTemp.Organisation_Id = OrgId;
        DataTable dtEmployeeList = new DataTable();
        dtEmployeeList = ObjBusinessNotiFi.ReadEmployee(objEntityNotTemp);
        dtEmployeeList.TableName = tableName;
        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtEmployeeList.WriteXml(sw);
            result = sw.ToString();
        }

        return result;

    }


    protected void btnAdd_INSRNC_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        int intnoofDays = 0;

        if (HiddenFieldAmount_INSRNC.Value.Trim() != "")
        {
            objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount_INSRNC.Value);
        }
        

        if (ddlCurrency_INSRNC.SelectedItem.Value != "--SELECT CURRENCY--")
        {
            objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency_INSRNC.SelectedItem.Value);
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_MSTR);
        objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;
        objEntityCommon.Organisation_Id = objEntityInsurance.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        objEntityInsurance.NextIdForRqst = Convert.ToInt32(strNextId);
        hiddenInsuranceId.Value = Convert.ToString(objEntityInsurance.NextIdForRqst);

        objEntityInsurance.RefNumber = LabelRefnum_INSRNC.Text;
        objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

        if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
        {
            objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
        }

        // evm-0023 strt
        if (ddlInsurncTyp.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
        {
            objEntityInsurance.InsuranceTypMstr = Convert.ToInt32(ddlInsurncTyp.SelectedItem.Value);
        }
        //evm-0023


        if (radioOpen_INSRNC.Checked == true)
        {
            objEntityInsurance.InsuranceTyp = 101;
            objEntityInsurance.ExpireDate = DateTime.MinValue;
        }
        else if (radioLimited_INSRNC.Checked == true)
        {
            objEntityInsurance.InsuranceTyp = 102;
            objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenValidatedays_INSRNC.Value);
            intnoofDays = Convert.ToInt32(HiddenValidatedays_INSRNC.Value);

            objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate_INSRNC.Text.Trim());
        }
        objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate_INSRNC.Text.Trim());

        if (cbxDontNotify_INSRNC.Checked == true)
        {
            objEntityInsurance.DontNotify = 1;
        }
        else
        {
            objEntityInsurance.DontNotify = 0;
        }

        objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate_INSRNC.SelectedItem.Value);
        objEntityInsurance.Description = txtDescrptn_INSRNC.Text.Trim();

        if (cbxExistingEmployee_INSRNC.Checked == true)
        {
            if (ddlExistingEmp_INSRNC.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityInsurance.EmployeName = ddlExistingEmp_INSRNC.SelectedItem.Text;
                objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp_INSRNC.SelectedItem.Value);

            }
        }
        else
        {
            objEntityInsurance.EmployeName = txtEmpName_INSRNC.Text.Trim();
        }

        if (cbxPrjct_INSRNC.Checked == true)
        {
            if (ddlProjects_INSRNC.SelectedItem.Value != "--SELECT PROJECT--")
            {
                objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects_INSRNC.SelectedItem.Value);
            }
        }
        else
        {
            objEntityInsurance.ProjectName = txtPrjctName_INSRNC.Text.Trim();
        }

        objEntityInsurance.Email = txtCntctMail_INSRNC.Text.Trim();
        objEntityInsurance.D_Date = System.DateTime.Now;

        string strGurntNo = "";
        strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

        if (strGurntNo == "" || strGurntNo == "0")
        {
            objBusinessInsurance.AddInsurance(objEntityInsurance);


            //for inserting attachmnts

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
            objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

            List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

            int intSlNumbr = 0;
            if (hiddenAttchmntSlNumber_INSRNC.Value != "")
            {
                intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber_INSRNC.Value);
                intSlNumbr++;
            }

            if (HiddenField2_FileUploadLnk_INSRNC.Value != "" && HiddenField2_FileUploadLnk_INSRNC.Value != null && HiddenField2_FileUploadLnk_INSRNC.Value != "[]")
            {
                string jsonDataDltAttch = HiddenField2_FileUploadLnk_INSRNC.Value;
                string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                string strAtt2 = strAtt1.Replace("\\", "");
                string strAtt3 = strAtt2.Replace("}\"]", "}]");
                string strAtt4 = strAtt3.Replace("}\",", "},");

                List<clsBannerDataADDAttchmnt_INSRNC> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt_INSRNC>();
                objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt_INSRNC>>(strAtt4);

                foreach (clsBannerDataADDAttchmnt_INSRNC objClsBannrAddAttData in objBannerDataDltAttList)
                {
                    if (objClsBannrAddAttData.EVTACTION == "INS")
                    {
                        string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                        HttpPostedFile PostedFile = Request.Files["file_INSRNC_" + strfilepath];
                        if (PostedFile.ContentLength > 0)
                        {
                            clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                            string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                            objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                            string strFileExt;
                            strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                            int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                            int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                            objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                            string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                            objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                            objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx_INSRNC" + strfilepath];

                            objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(hiddenInsuranceId.Value);

                            string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                            PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                            objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                            intSlNumbr++;
                        }


                    }
                }
            }

            List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

            if (hiddenFileCanclDtlId_INSRNC.Value != "" && hiddenFileCanclDtlId_INSRNC.Value != null)
            {
                string jsonDataDltAttch = hiddenFileCanclDtlId_INSRNC.Value;
                string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                string strAtt2 = strAtt1.Replace("\\", "");
                string strAtt3 = strAtt2.Replace("}\"]", "}]");
                string strAtt4 = strAtt3.Replace("}\",", "},");

                List<clsPictureDataDELETEAttchmnt_INSRNC> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt_INSRNC>();
                objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt_INSRNC>>(strAtt4);

                foreach (clsPictureDataDELETEAttchmnt_INSRNC objClsPictureDltAttData in objPictureDataDltAttList)
                {
                    clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                    objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                    objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                    objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                }
            }

            if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
            {
                objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
            }

            if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
            {
                objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                {

                    string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                    string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
            }

            //for inserting template

            string strEachTempTotalString = hiddenEachSliceData_INSRNC.Value;
            string strNotifyMode = hiddenNotificationMOde_INSRNC.Value;
            string strNotifyVia = hiddenNotifyVia_INSRNC.Value;
            string strNotifyDur = hiddenNotificationDuration_INSRNC.Value;
            int TempCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);

            string[] strEachTempString = new string[TempCount];
            strEachTempString = strEachTempTotalString.Split('!');

            for (int intCount = 0; intCount < TempCount; intCount++)
            {
                InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                //for template mode
                string jsonDataNotyMod = strNotifyMode;
                string a = jsonDataNotyMod.Replace("\"{", "\\{");
                string b = a.Replace("\\n", "\r\n");
                string c = b.Replace("\\", "");
                string d = c.Replace("}\"]", "}]");
                string k = d.Replace("}\",", "},");

                List<clsEachTempNotyMOde_INSRNC> objEachTempDetModList = new List<clsEachTempNotyMOde_INSRNC>();
                objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde_INSRNC>>(k);

                string MODEROWID = objEachTempDetModList[intCount].ROWID;
                string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                if (NOTMODE == "D")
                {
                    objEntityTempDeatils.TempDetPeriod = 2;
                }
                else
                {
                    objEntityTempDeatils.TempDetPeriod = 1;
                }

                //for template NotifyVia
                string jsonDataNotyVia = strNotifyVia;
                string l = jsonDataNotyVia.Replace("\"{", "\\{");
                string m = l.Replace("\\n", "\r\n");
                string n = m.Replace("\\", "");
                string o = n.Replace("}\"]", "}]");
                string p = o.Replace("}\",", "},");

                List<clsEachTempNotyVia_INSRNC> objEachTempDetViaList = new List<clsEachTempNotyVia_INSRNC>();
                objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia_INSRNC>>(p);

                string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                if (VIAWHT.Contains("D"))
                {
                    objEntityTempDeatils.IsDashBoard = 1;
                }
                if (VIAWHT.Contains("E"))
                {
                    objEntityTempDeatils.IsEmail = 1;
                }

                //for template notify Duration
                string jsonDataNotyDur = strNotifyDur;
                string q = jsonDataNotyDur.Replace("\"{", "\\{");
                string r = q.Replace("\\n", "\r\n");
                string s = r.Replace("\\", "");
                string t = s.Replace("}\"]", "}]");
                string u = t.Replace("}\",", "},");

                List<clsEachTempNotyDur_INSRNC> objEachTempDetDurList = new List<clsEachTempNotyDur_INSRNC>();
                objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur_INSRNC>>(u);

                string DURROWID = objEachTempDetDurList[intCount].ROWID;
                string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                string jsonData = strEachTempString[intCount + 1];
                string V = jsonData.Replace("\"{", "\\{");
                string W = V.Replace("\\n", "\r\n");
                string X = W.Replace("\\", "");
                string Y = X.Replace("}\"]", "}]");
                string Z = Y.Replace("}\",", "},");

                List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();

                List<clsEachTempDeatail_INSRNC> objEachTempDetList = new List<clsEachTempDeatail_INSRNC>();
                objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail_INSRNC>>(Z);

                if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                {

                    for (int count = 0; count < objEachTempDetList.Count; count++)
                    {
                        string ROWID = objEachTempDetList[count].ROWID;

                        string VALUE = objEachTempDetList[count].DDLVALUE;
                        string DDLMODE = objEachTempDetList[count].DDLMODE;
                        string DTLID = objEachTempDetList[count].DTLID;
                        if (VALUE != "0")
                        {
                            InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                            if (DDLMODE == "ddlDivision_INSRNC_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 0;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlDesignation_INSRNC_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 1;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "ddlEmployee_INSRNC_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 2;
                                objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                            }
                            else if (DDLMODE == "txtGenMail_INSRNC_")
                            {
                                objEntityTemplateAlert.TemplateAlertOptId = 3;
                                objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                            }


                            objEntityTempAlertList.Add(objEntityTemplateAlert);
                        }
                    }

                }

                objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
            }



            if (clickedButton.ID == "btnAdd_INSRNC")
            {
                Response.Redirect("gen_Bank_Guarantee.aspx?InsUpd_INSRNC=Ins");
            }
            else if (clickedButton.ID == "btnAddClose_INSRNC")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Ins");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Duplication_INSRNC", "Duplication_INSRNC();", true);
        }

    }


    public class clsPictureDataDELETEAttchmnt_INSRNC
    {
        public string FILENAME { get; set; }
        public string DTLID { get; set; }
    }
    public class clsBannerDataADDAttchmnt_INSRNC
    {
        public string EVTACTION { get; set; }
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }

    public class clsEachTempDeatail_INSRNC
    {
        public string DDLVALUE { get; set; }
        public string ROWID { get; set; }
        public string DDLMODE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
    }

    public class clsEachTempNotyMOde_INSRNC
    {
        public string ROWID { get; set; }
        public string NOTMODE { get; set; }
        public string TEMPID { get; set; }
    }
    public class clsEachTempNotyVia_INSRNC
    {
        public string ROWID { get; set; }
        public string NOTVIA { get; set; }
        public string TEMPID { get; set; }
    }
    public class clsEachTempNotyDur_INSRNC
    {
        public string ROWID { get; set; }
        public string NOTDUR { get; set; }
        public string TEMPID { get; set; }
    }


    public class clsEachAlertDel_INSRNC
    {
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }

    protected void ddlTemplate_INSRNC_SelectedIndexChanged(object sender, EventArgs e)
    {
        classBusinessLayerNotifi_Temp ObjBusinessNotiFi = new classBusinessLayerNotifi_Temp();
        classEntityLayerNotifi_Temp objEntityNotTemp = new classEntityLayerNotifi_Temp();

        DropDownEmployeeDataStore_INSRNC();
        DropdownDesignationDataStore_INSRNC();
        DropdownDivisionDataStore_INSRNC();
        int strId = Convert.ToInt32(ddlTemplate_INSRNC.SelectedItem.Value);
        objEntityNotTemp.NotTempId = Convert.ToInt32(strId);
        DataTable dtTemplate = ObjBusinessNotiFi.ReadTemplateById(objEntityNotTemp);

        if (dtTemplate.Rows.Count > 0)
        {
            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = new DataTable();
            dtEachTemplateDetail = ObjBusinessNotiFi.ReadTemplateDetailById(objEntityNotTemp);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["TEMDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["TEMDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    objEntityNotTemp.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["TEMDTL_ID"]);
                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    DataTable dtTempAlertEachSlice = ObjBusinessNotiFi.ReadTemplateAlertById(objEntityNotTemp);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_EMAIL"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["TEMALRT_NTFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail_INSRNC.Value = strJson;
                hiddenTemplateAlertData_INSRNC.Value = strAlertDetailFull;
            }
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "TemplateLoad_INSRNC", "TemplateLoad_INSRNC();", true);
    }

    protected void btnNewProject_INSRNC_Click(object sender, EventArgs e)
    {
        int Projectid = Convert.ToInt32(hiddenNewProjectId_INSRNC.Value);
        LoadProjects_INSRNC(Projectid, "");
    }

    public void Update_INSRNC(string strId)
    {
        btnAdd_INSRNC.Visible = false;
        btnAddClose_INSRNC.Visible = false;
        btnUpdate_INSRNC.Visible = true;
        btnUpdateClose_INSRNC.Visible = true;
        HiddenFieldUpdate_INSRNC.Value = "1";

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId_INSRNC.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (strId != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
            hiddenInsuranceId.Value = strId;
        }

        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceById(objEntityInsurance);
        if (dtInsurance.Rows.Count > 0)
        {
            LabelRefnum_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_REF_NUM"].ToString();
            txtInsuranceno.Text = dtInsurance.Rows[0]["INSURANCE_NUMBER"].ToString();
            txtCntctMail_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString();
            txtOpngDate_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_DATE"].ToString();
            txtDescrptn_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_DESCRIPTION"].ToString();

            if (dtInsurance.Rows[0]["INSURPRVDR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()) != null)
                {
                    ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["INSURPRVDR_NAME"].ToString(), dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString());
                ddlInsurncPrvdr.Items.Insert(1, lstGrp);
                ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }

            //EVM-0023 STRT
            if (dtInsurance.Rows[0]["INSRC_TYPMSTR_STS"].ToString() == "1" && dtInsurance.Rows[0]["INSRC_TYPMSTR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInsurncTyp.Items.FindByValue(dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString()) != null)
                {
                    ddlInsurncTyp.Items.FindByValue(dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["INSRC_TYPMSTR_NAME"].ToString(), dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString());
                ddlInsurncTyp.Items.Insert(1, lstGrp);
                ddlInsurncTyp.Items.FindByValue(dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString()).Selected = true;
            }
            //EVM-0023 END

            if (dtInsurance.Rows[0]["INSURANCE_DONT_NOTIFY"].ToString() == "1")
            {
                cbxDontNotify_INSRNC.Checked = true;
            }
            else
            {
                cbxDontNotify_INSRNC.Checked = false;
            }
            ddlCurrency_INSRNC.ClearSelection();
            if (dtInsurance.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlCurrency_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["CRNCMST_NAME"].ToString(), dtInsurance.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency_INSRNC.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCurrency_INSRNC);

                ddlCurrency_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            txtAmount_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_AMOUNT"].ToString();

            int intProjectId = 0; string strProjectName = "";
            if (dtInsurance.Rows[0]["PROJECT_ID"].ToString() != "")
            {
                cbxPrjct_INSRNC.Checked = true;
                if (dtInsurance.Rows[0]["PROJECT_ID"].ToString() != null || dtInsurance.Rows[0]["PROJECT_ID"].ToString() != "")
                {
                    intProjectId = Convert.ToInt32(dtInsurance.Rows[0]["PROJECT_ID"].ToString());
                    strProjectName = dtInsurance.Rows[0]["PROJECT_NAME"].ToString();
                }
            }
            else
            {
                cbxPrjct_INSRNC.Checked = false;
                txtPrjctName_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_PRJCT_NAME"].ToString();
            }
            LoadProjects_INSRNC(intProjectId, strProjectName);

            if (dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString() != "")
            {
                cbxExistingEmployee_INSRNC.Checked = true;

                if (dtInsurance.Rows[0]["USR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingEmp_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()) != null)
                    {
                        ddlExistingEmp_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["USR_NAME"].ToString(), dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString());
                    ddlExistingEmp_INSRNC.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp_INSRNC);

                    ddlExistingEmp_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee_INSRNC.Checked = false;
                txtEmpName_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_NAME"].ToString();
            }

            if (dtInsurance.Rows[0]["NOTFTEMP_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["NOTFTEMP_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTemplate_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
                {
                    ddlTemplate_INSRNC.ClearSelection();
                    ddlTemplate_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["NOTFTEMP_NAME"].ToString(), dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString());
                ddlTemplate_INSRNC.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTemplate_INSRNC);
                ddlTemplate_INSRNC.ClearSelection();

                ddlTemplate_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }

            if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "101")
            {
                radioOpen_INSRNC.Checked = true;
                txtPrjctClsngDate_INSRNC.Enabled = false;
            }
            else if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "102")
            {
                radioLimited_INSRNC.Checked = true;
                txtValidity_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                HiddenTextValidty_INSRNC.Value = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                txtPrjctClsngDate_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_EXP_DATE"].ToString();
                txtPrjctClsngDate_INSRNC.Enabled = true;
            }

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("PictureAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));
            dtAttchmnt.Columns.Add("Description", typeof(string));

            DataTable dtPicGalleryFull = objBusinessInsurance.ReadAttachmntsById(objEntityInsurance);

            if (dtPicGalleryFull.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtPicGalleryFull.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["PictureAttchmntDtlId"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ID"].ToString();
                    drAttch["FileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_NAME"].ToString();
                    drAttch["ActualFileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ACT_NAME"].ToString();
                    drAttch["Description"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_DESCRPTN"].ToString();
                    dtAttchmnt.Rows.Add(drAttch);
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenEditAttchmnt_INSRNC.Value = strJson;
            }

            //for filling template details

            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = objBusinessInsurance.ReadTemplateById(objEntityInsurance);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    InsuranceTemplateDetail objEntityNotTempDetail = new InsuranceTemplateDetail();

                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    objEntityNotTempDetail.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"]);

                    DataTable dtTempAlertEachSlice = objBusinessInsurance.ReadTemplateAlertById(objEntityNotTempDetail);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_NOTIFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson2 = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail_INSRNC.Value = strJson2;
                hiddenTemplateAlertData_INSRNC.Value = strAlertDetailFull;
            }
            hiddenTemplateLoadingMode_INSRNC.Value = "FromBnk";


            if (hiddenRoleReOpen_INSRNC.Value != "")
            {
                if (hiddenRoleReOpen_INSRNC.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "2")
                    {
                        imgbtnReOpen_INSRNC.Visible = true;
                    }
                }
            }

            if (hiddenRoleConfirm_INSRNC.Value != "")
            {
                if (hiddenRoleConfirm_INSRNC.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "1")
                    {
                        btnConfirm_INSRNC.Visible = true;
                    }
                }
            }
            txtValidity_INSRNC.Enabled = false;
        }
    }

    public void View_INSRNC(string strId)
    {
        btnAdd_INSRNC.Visible = false;
        btnAddClose_INSRNC.Visible = false;
        btnUpdate_INSRNC.Visible = false;
        btnUpdateClose_INSRNC.Visible = false;
        HiddenFieldView_INSRNC.Value = "1";

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId_INSRNC.Value);
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (strId != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
            hiddenInsuranceId.Value = strId;
        }
        string strGurntNo = "";
        strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);
        if (strGurntNo == "" || strGurntNo == "0")
        {
            DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
            string strchckStatus = "";
            if (GuarantStatus.Rows.Count > 0)
            {
                strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
            }
            if (strchckStatus == "2")
            {
                hiddenStatus.Value = "2";
            }
        }

        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceById(objEntityInsurance);
        if (dtInsurance.Rows.Count > 0)
        {
            LabelRefnum_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_REF_NUM"].ToString();
            txtInsuranceno.Text = dtInsurance.Rows[0]["INSURANCE_NUMBER"].ToString();
            txtCntctMail_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_EMAIL"].ToString();
            txtOpngDate_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_DATE"].ToString();
            txtDescrptn_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_DESCRIPTION"].ToString();

            if (dtInsurance.Rows[0]["INSURPRVDR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["INSURPRVDR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()) != null)
                {
                    ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["INSURPRVDR_NAME"].ToString(), dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString());
                ddlInsurncPrvdr.Items.Insert(1, lstGrp);
                ddlInsurncPrvdr.Items.FindByValue(dtInsurance.Rows[0]["INSURPRVDR_ID"].ToString()).Selected = true;
            }

            //EVM-0023 STRT
            if (dtInsurance.Rows[0]["INSRC_TYPMSTR_STS"].ToString() == "1" && dtInsurance.Rows[0]["INSRC_TYPMSTR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlInsurncTyp.Items.FindByValue(dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString()) != null)
                {
                    ddlInsurncTyp.Items.FindByValue(dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["INSRC_TYPMSTR_NAME"].ToString(), dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString());
                ddlInsurncTyp.Items.Insert(1, lstGrp);
                ddlInsurncTyp.Items.FindByValue(dtInsurance.Rows[0]["INSRC_TYPMSTR_ID"].ToString()).Selected = true;
            }
            //EVM-0023 END

            if (dtInsurance.Rows[0]["INSURANCE_DONT_NOTIFY"].ToString() == "1")
            {
                cbxDontNotify_INSRNC.Checked = true;
            }
            else
            {
                cbxDontNotify_INSRNC.Checked = false;
            }
            ddlCurrency_INSRNC.ClearSelection();
            if (dtInsurance.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlCurrency_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["CRNCMST_NAME"].ToString(), dtInsurance.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency_INSRNC.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCurrency_INSRNC);

                ddlCurrency_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            txtAmount_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_AMOUNT"].ToString();

            int intProjectId = 0; string strProjectName = "";

            if (dtInsurance.Rows[0]["PROJECT_ID"].ToString() != "")
            {
                cbxPrjct_INSRNC.Checked = true;
                if (dtInsurance.Rows[0]["PROJECT_ID"].ToString() != null || dtInsurance.Rows[0]["PROJECT_ID"].ToString() != "")
                {
                    intProjectId = Convert.ToInt32(dtInsurance.Rows[0]["PROJECT_ID"].ToString());
                    strProjectName = dtInsurance.Rows[0]["PROJECT_NAME"].ToString();
                    ddlProjects_INSRNC.Enabled = false;
                }
            }
            else
            {
                cbxPrjct_INSRNC.Checked = false;
                txtPrjctName_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_PRJCT_NAME"].ToString();
                txtPrjctName_INSRNC.Enabled = false;
            }
            LoadProjects_INSRNC(intProjectId, strProjectName);
            cbxPrjct_INSRNC.Enabled = false;

            if (dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString() != "")
            {
                cbxExistingEmployee_INSRNC.Checked = true;

                if (dtInsurance.Rows[0]["USR_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingEmp_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()) != null)
                    {
                        ddlExistingEmp_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["USR_NAME"].ToString(), dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString());
                    ddlExistingEmp_INSRNC.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp_INSRNC);

                    ddlExistingEmp_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["INSURANCE_PERSON_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee_INSRNC.Checked = false;
                txtEmpName_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_PERSON_NAME"].ToString();
            }

            if (dtInsurance.Rows[0]["NOTFTEMP_STATUS"].ToString() == "1" && dtInsurance.Rows[0]["NOTFTEMP_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlTemplate_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()) != null)
                {
                    ddlTemplate_INSRNC.ClearSelection();
                    ddlTemplate_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtInsurance.Rows[0]["NOTFTEMP_NAME"].ToString(), dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString());
                ddlTemplate_INSRNC.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlTemplate_INSRNC);
                ddlTemplate_INSRNC.ClearSelection();

                ddlTemplate_INSRNC.Items.FindByValue(dtInsurance.Rows[0]["NOTFTEMP_ID"].ToString()).Selected = true;
            }

            if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "101")
            {
                radioOpen_INSRNC.Checked = true;
                txtPrjctClsngDate_INSRNC.Enabled = false;
            }
            else if (dtInsurance.Rows[0]["INSURNCTYPE_ID"].ToString() == "102")
            {
                radioLimited_INSRNC.Checked = true;
                txtValidity_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                HiddenTextValidty_INSRNC.Value = dtInsurance.Rows[0]["INSURANCE_NO_DAYS"].ToString();
                txtPrjctClsngDate_INSRNC.Text = dtInsurance.Rows[0]["INSURANCE_EXP_DATE"].ToString();
                txtPrjctClsngDate_INSRNC.Enabled = true;
            }

            DataTable dtAttchmnt = new DataTable();
            dtAttchmnt.Columns.Add("PictureAttchmntDtlId", typeof(int));
            dtAttchmnt.Columns.Add("FileName", typeof(string));
            dtAttchmnt.Columns.Add("ActualFileName", typeof(string));
            dtAttchmnt.Columns.Add("Description", typeof(string));

            DataTable dtPicGalleryFull = objBusinessInsurance.ReadAttachmntsById(objEntityInsurance);

            if (dtPicGalleryFull.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtPicGalleryFull.Rows.Count; intcnt++)
                {
                    DataRow drAttch = dtAttchmnt.NewRow();
                    drAttch["PictureAttchmntDtlId"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ID"].ToString();
                    drAttch["FileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_NAME"].ToString();
                    drAttch["ActualFileName"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_ACT_NAME"].ToString();
                    drAttch["Description"] = dtPicGalleryFull.Rows[intcnt]["INSRNC_ATTCH_DESCRPTN"].ToString();
                    dtAttchmnt.Rows.Add(drAttch);
                }

                string strJson = DataTableToJSONWithJavaScriptSerializer(dtAttchmnt);
                hiddenEditAttchmnt_INSRNC.Value = strJson;
            }


            //for filling template details

            DataTable dtTemplateDetail = new DataTable();
            dtTemplateDetail.Columns.Add("TempDetailId", typeof(int));
            dtTemplateDetail.Columns.Add("NotifyMod", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyVia", typeof(string));
            dtTemplateDetail.Columns.Add("NotifyDur", typeof(string));

            DataTable dtEachTemplateDetail = objBusinessInsurance.ReadTemplateById(objEntityInsurance);

            string strAlertDetailFull = "";
            if (dtEachTemplateDetail.Rows.Count > 0)
            {
                for (int intcnt = 0; intcnt < dtEachTemplateDetail.Rows.Count; intcnt++)
                {
                    DataRow drAttchTempDet = dtTemplateDetail.NewRow();
                    drAttchTempDet["TempDetailId"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"].ToString();
                    drAttchTempDet["NotifyMod"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_PERIOD"].ToString();
                    drAttchTempDet["NotifyDur"] = dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_COUNT"].ToString();
                    string strVia = "";
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_DASHBOARD"].ToString() == "1")
                    {
                        strVia = strVia + "," + "D";
                    }
                    if (dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_EMAIL"].ToString() == "1")
                    {
                        strVia = strVia + "," + "E";
                    }
                    drAttchTempDet["NotifyVia"] = strVia;

                    dtTemplateDetail.Rows.Add(drAttchTempDet);

                    InsuranceTemplateDetail objEntityNotTempDetail = new InsuranceTemplateDetail();

                    DataTable dtTemplateAlert = new DataTable();
                    dtTemplateAlert.Columns.Add("TempDetailId", typeof(int));
                    dtTemplateAlert.Columns.Add("TempAlertId", typeof(int));
                    dtTemplateAlert.Columns.Add("AlertOpt", typeof(string));
                    dtTemplateAlert.Columns.Add("AlertNtfyId", typeof(string));

                    objEntityNotTempDetail.TempDetailId = Convert.ToInt32(dtEachTemplateDetail.Rows[intcnt]["INSRNC_TMPDTL_ID"]);

                    DataTable dtTempAlertEachSlice = objBusinessInsurance.ReadTemplateAlertById(objEntityNotTempDetail);
                    if (dtTempAlertEachSlice.Rows.Count > 0)
                    {
                        for (int intAlertcnt = 0; intAlertcnt < dtTempAlertEachSlice.Rows.Count; intAlertcnt++)
                        {
                            DataRow drAttchTempAlert = dtTemplateAlert.NewRow();
                            drAttchTempAlert["TempDetailId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPDTL_ID"].ToString();
                            drAttchTempAlert["TempAlertId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_ID"].ToString();
                            drAttchTempAlert["AlertOpt"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString();
                            if (dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_OPT"].ToString() == "3")
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_TMPALRT_NTFYEMAILID"].ToString();
                            }
                            else
                            {
                                drAttchTempAlert["AlertNtfyId"] = dtTempAlertEachSlice.Rows[intAlertcnt]["INSRNC_NOTIFY_ID"].ToString();
                            }

                            dtTemplateAlert.Rows.Add(drAttchTempAlert);
                        }
                    }

                    string strAlertJson = DataTableToJSONWithJavaScriptSerializer(dtTemplateAlert);
                    strAlertDetailFull = strAlertDetailFull + "!" + strAlertJson;
                }

                string strJson2 = DataTableToJSONWithJavaScriptSerializer(dtTemplateDetail);
                hiddenEachTemplateDetail_INSRNC.Value = strJson2;
                hiddenTemplateAlertData_INSRNC.Value = strAlertDetailFull;
            }
            hiddenTemplateLoadingMode_INSRNC.Value = "FromBnk";

            if (hiddenRoleReOpen_INSRNC.Value != "")
            {
                if (hiddenRoleReOpen_INSRNC.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "3")
                    {
                        imgbtnReOpen_INSRNC.Visible = true;
                    }
                }
            }
            if (hiddenRoleReOpen_INSRNC.Value != "")
            {
                if (hiddenRoleReOpen_INSRNC.Value == "1")
                {
                    if (dtInsurance.Rows[0]["INSURANCE_STATUS"].ToString() == "2")
                    {
                        imgbtnReOpen_INSRNC.Visible = true;
                    }
                }
            }

            if (hiddenStatus.Value == "2" || hiddenStatus.Value == "3")
            {
                if (HiddenRenew_INSRNC.Value == "1")
                {
                    btnrenew_INSRNC.Visible = true;
                }
            }
            txtDescrptn_INSRNC.Enabled = false;
            txtInsuranceno.Enabled = false;
            txtCntctMail_INSRNC.Enabled = false;
            txtOpngDate_INSRNC.Enabled = false;
            cbxExistingEmployee_INSRNC.Enabled = false;
            ddlExistingEmp_INSRNC.Enabled = false;
            ddlInsurncPrvdr.Enabled = false;
            ddlInsurncTyp.Enabled = false;
            ddlTemplate_INSRNC.Enabled = false;
            cbxDontNotify_INSRNC.Enabled = false;
            ddlProjects_INSRNC.Enabled = false;
            if (HiddenRenew_INSRNC.Value != "1")
            {
                img1_INSRNC.Attributes.Add("style", "pointer-events:none;");
            }
            img2_INSRNC.Attributes.Add("style", "pointer-events:none;");

            if (hiddenStatus.Value == "2")
            {
                if (HiddenRenew_INSRNC.Value == "1")
                {
                    txtAmount_INSRNC.Enabled = true;
                }
                else
                {
                    txtAmount_INSRNC.Enabled = false;
                }
            }
            else
            {
                txtAmount_INSRNC.Enabled = false;
            }
            ddlCurrency_INSRNC.Enabled = false;
            radioOpen_INSRNC.Disabled = true;
            radioLimited_INSRNC.Disabled = true;
            txtValidity_INSRNC.Enabled = false;
            if (hiddenStatus.Value == "2")
            {
                if (HiddenRenew_INSRNC.Value == "1")
                {
                    if (radioLimited_INSRNC.Checked == true)
                    {
                        txtPrjctClsngDate_INSRNC.Enabled = true;
                    }
                    else
                    {
                        txtPrjctClsngDate_INSRNC.Enabled = false;
                    }
                }
                else
                {
                    txtPrjctClsngDate_INSRNC.Enabled = false;
                }
            }
            else
            {
                txtPrjctClsngDate_INSRNC.Enabled = false;
            }
            txtEmpName_INSRNC.Enabled = false;
        }
    }

    protected void btnUpdate_INSRNC_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["Id_INSRNC"] != null || Request.QueryString["ViewId_INSRNC"] != null)
        {
            string strRandomMixedId = "";
            if (Request.QueryString["Id_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["Id_INSRNC"].ToString();
            }
            if (Request.QueryString["ViewId_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId_INSRNC"].ToString();
            }
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.RefNumber = LabelRefnum_INSRNC.Text;
            objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

            if (HiddenFieldAmount_INSRNC.Value.Trim() != "")
            {
                objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount_INSRNC.Value);
            }
            if (ddlCurrency_INSRNC.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency_INSRNC.SelectedItem.Value);
            }


            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
            {
                objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
            }

            //evm-0023 strt
            if (ddlInsurncTyp.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
            {
                objEntityInsurance.InsuranceTypMstr = Convert.ToInt32(ddlInsurncTyp.SelectedItem.Value);
            }
            //evm-0023 end


            if (radioOpen_INSRNC.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 101;
                objEntityInsurance.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited_INSRNC.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 102;
                objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenTextValidty_INSRNC.Value);
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate_INSRNC.Text.Trim());
            }
            objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate_INSRNC.Text.Trim());

            if (cbxDontNotify_INSRNC.Checked == true)
            {
                objEntityInsurance.DontNotify = 1;
            }
            else
            {
                objEntityInsurance.DontNotify = 0;
            }

            objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate_INSRNC.SelectedItem.Value);
            objEntityInsurance.Description = txtDescrptn_INSRNC.Text.Trim();

            if (cbxExistingEmployee_INSRNC.Checked == true)
            {
                if (ddlExistingEmp_INSRNC.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    objEntityInsurance.EmployeName = ddlExistingEmp_INSRNC.SelectedItem.Text;
                    objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp_INSRNC.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.EmployeName = txtEmpName_INSRNC.Text.Trim();
            }
            if (cbxPrjct_INSRNC.Checked == true)
            {
                if (ddlProjects_INSRNC.SelectedItem.Value != "--SELECT PROJECT--")
                {
                    objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects_INSRNC.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.ProjectName = txtPrjctName_INSRNC.Text.Trim();
            }

            objEntityInsurance.Email = txtCntctMail_INSRNC.Text.Trim();
            objEntityInsurance.D_Date = System.DateTime.Now;

            string strGurntNo = "";
            strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

            if (strGurntNo == "" || strGurntNo == "0")
            {
                objBusinessInsurance.UpdateInsurance(objEntityInsurance);


                //for UPDATING attachmnts

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

                List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

                int intSlNumbr = 0;
                if (hiddenAttchmntSlNumber_INSRNC.Value != "")
                {
                    intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber_INSRNC.Value);
                    intSlNumbr++;
                }

                if (HiddenField2_FileUploadLnk_INSRNC.Value != "" && HiddenField2_FileUploadLnk_INSRNC.Value != null && HiddenField2_FileUploadLnk_INSRNC.Value != "[]")
                {
                    string jsonDataDltAttch = HiddenField2_FileUploadLnk_INSRNC.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");

                    List<clsBannerDataADDAttchmnt_INSRNC> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt_INSRNC>();
                    objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt_INSRNC>>(strAtt4);

                    foreach (clsBannerDataADDAttchmnt_INSRNC objClsBannrAddAttData in objBannerDataDltAttList)
                    {
                        if (objClsBannrAddAttData.EVTACTION == "INS")
                        {
                            string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                            HttpPostedFile PostedFile = Request.Files["file_INSRNC_" + strfilepath];
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                                string strFileExt;
                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                                int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx_INSRNC" + strfilepath];

                                objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(hiddenInsuranceId.Value);

                                string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                intSlNumbr++;
                            }


                        }
                    }
                }

                List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

                if (hiddenFileCanclDtlId_INSRNC.Value != "" && hiddenFileCanclDtlId_INSRNC.Value != null)
                {
                    string jsonDataDltAttch = hiddenFileCanclDtlId_INSRNC.Value;
                    string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                    string strAtt2 = strAtt1.Replace("\\", "");
                    string strAtt3 = strAtt2.Replace("}\"]", "}]");
                    string strAtt4 = strAtt3.Replace("}\",", "},");

                    List<clsPictureDataDELETEAttchmnt_INSRNC> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt_INSRNC>();
                    objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt_INSRNC>>(strAtt4);

                    foreach (clsPictureDataDELETEAttchmnt_INSRNC objClsPictureDltAttData in objPictureDataDltAttList)
                    {
                        clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                        objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                        objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                        objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                    }
                }

                if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                {
                    objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
                }

                if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
                {
                    objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                    foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                    {
                        string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                        string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }
                }

                objEntityInsurance.NextIdForRqst = objEntityInsurance.InsuranceId;

                //for UPDATING template
                if (hiddenTemplateChange_INSRNC.Value == "CHANGED")
                {
                    //TEMPLT CHANGED

                    objBusinessInsurance.DeleteTemplateAlertById(objEntityInsurance);
                    objBusinessInsurance.DeleteTemplateDetailById(objEntityInsurance);

                    int TemplateCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);
                    string strEachTempTotalString = hiddenEachSliceData_INSRNC.Value;
                    string strNotifyMode = hiddenNotificationMOde_INSRNC.Value;
                    string strNotifyVia = hiddenNotifyVia_INSRNC.Value;
                    string strNotifyDur = hiddenNotificationDuration_INSRNC.Value;
                    int TempCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);

                    string[] strEachTempString = new string[TempCount];
                    strEachTempString = strEachTempTotalString.Split('!');

                    for (int intCount = 0; intCount < TempCount; intCount++)
                    {
                        InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                        //for template mode
                        string jsonDataNotyMod = strNotifyMode;
                        string a = jsonDataNotyMod.Replace("\"{", "\\{");
                        string b = a.Replace("\\n", "\r\n");
                        string c = b.Replace("\\", "");
                        string d = c.Replace("}\"]", "}]");
                        string k = d.Replace("}\",", "},");

                        List<clsEachTempNotyMOde_INSRNC> objEachTempDetModList = new List<clsEachTempNotyMOde_INSRNC>();
                        objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde_INSRNC>>(k);

                        string MODEROWID = objEachTempDetModList[intCount].ROWID;
                        string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                        string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                        if (NOTMODE == "D")
                        {
                            objEntityTempDeatils.TempDetPeriod = 2;
                        }
                        else
                        {
                            objEntityTempDeatils.TempDetPeriod = 1;
                        }

                        //for template NotifyVia
                        string jsonDataNotyVia = strNotifyVia;
                        string l = jsonDataNotyVia.Replace("\"{", "\\{");
                        string m = l.Replace("\\n", "\r\n");
                        string n = m.Replace("\\", "");
                        string o = n.Replace("}\"]", "}]");
                        string p = o.Replace("}\",", "},");

                        List<clsEachTempNotyVia_INSRNC> objEachTempDetViaList = new List<clsEachTempNotyVia_INSRNC>();
                        objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia_INSRNC>>(p);

                        string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                        string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                        string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                        if (VIAWHT.Contains("D"))
                        {
                            objEntityTempDeatils.IsDashBoard = 1;
                        }
                        if (VIAWHT.Contains("E"))
                        {
                            objEntityTempDeatils.IsEmail = 1;
                        }

                        //for template notify Duration
                        string jsonDataNotyDur = strNotifyDur;
                        string q = jsonDataNotyDur.Replace("\"{", "\\{");
                        string r = q.Replace("\\n", "\r\n");
                        string s = r.Replace("\\", "");
                        string t = s.Replace("}\"]", "}]");
                        string u = t.Replace("}\",", "},");

                        List<clsEachTempNotyDur_INSRNC> objEachTempDetDurList = new List<clsEachTempNotyDur_INSRNC>();
                        objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur_INSRNC>>(u);

                        string DURROWID = objEachTempDetDurList[intCount].ROWID;
                        string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                        string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                        objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                        string jsonData = strEachTempString[intCount + 1];
                        string V = jsonData.Replace("\"{", "\\{");
                        string W = V.Replace("\\n", "\r\n");
                        string X = W.Replace("\\", "");
                        string Y = X.Replace("}\"]", "}]");
                        string Z = Y.Replace("}\",", "},");

                        List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();

                        List<clsEachTempDeatail_INSRNC> objEachTempDetList = new List<clsEachTempDeatail_INSRNC>();
                        objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail_INSRNC>>(Z);

                        if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                        {

                            for (int count = 0; count < objEachTempDetList.Count; count++)
                            {
                                string ROWID = objEachTempDetList[count].ROWID;

                                string VALUE = objEachTempDetList[count].DDLVALUE;
                                string DDLMODE = objEachTempDetList[count].DDLMODE;
                                string DTLID = objEachTempDetList[count].DTLID;
                                if (VALUE != "0")
                                {
                                    InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                    if (DDLMODE == "ddlDivision_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 0;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlDesignation_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 1;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlEmployee_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 2;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "txtGenMail_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 3;
                                        objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                    }


                                    objEntityTempAlertList.Add(objEntityTemplateAlert);
                                }
                            }

                        }

                        objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                    }
                }
                else
                {
                    //SAME TEMPLT UPDT

                    int TemplateCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);
                    string strEachTempTotalString = hiddenEachSliceData_INSRNC.Value;
                    string strNotifyMode = hiddenNotificationMOde_INSRNC.Value;
                    string strNotifyVia = hiddenNotifyVia_INSRNC.Value;
                    string strNotifyDur = hiddenNotificationDuration_INSRNC.Value;
                    //-----for template ---
                    int TempCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);

                    string[] strEachTempString = new string[TempCount];
                    strEachTempString = strEachTempTotalString.Split('!');

                    for (int intCount = 0; intCount < TempCount; intCount++)
                    {
                        InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                        //for template mode
                        string jsonDataNotyMod = strNotifyMode;
                        string a = jsonDataNotyMod.Replace("\"{", "\\{");
                        string b = a.Replace("\\n", "\r\n");
                        string c = b.Replace("\\", "");
                        string d = c.Replace("}\"]", "}]");
                        string k = d.Replace("}\",", "},");

                        List<clsEachTempNotyMOde_INSRNC> objEachTempDetModList = new List<clsEachTempNotyMOde_INSRNC>();
                        objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde_INSRNC>>(k);

                        string MODEROWID = objEachTempDetModList[intCount].ROWID;
                        string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                        string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                        if (NOTMODE == "D")
                        {
                            objEntityTempDeatils.TempDetPeriod = 2;
                        }
                        else
                        {
                            objEntityTempDeatils.TempDetPeriod = 1;
                        }
                        if (MODETEMPID != "0")
                        {
                            objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                        }
                        //for template NotifyVia
                        string jsonDataNotyVia = strNotifyVia;
                        string l = jsonDataNotyVia.Replace("\"{", "\\{");
                        string m = l.Replace("\\n", "\r\n");
                        string n = m.Replace("\\", "");
                        string o = n.Replace("}\"]", "}]");
                        string p = o.Replace("}\",", "},");

                        List<clsEachTempNotyVia_INSRNC> objEachTempDetViaList = new List<clsEachTempNotyVia_INSRNC>();
                        objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia_INSRNC>>(p);

                        string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                        string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                        string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                        if (VIAWHT.Contains("D"))
                        {
                            objEntityTempDeatils.IsDashBoard = 1;
                        }
                        if (VIAWHT.Contains("E"))
                        {
                            objEntityTempDeatils.IsEmail = 1;
                        }

                        //for template notify Duration
                        string jsonDataNotyDur = strNotifyDur;
                        string q = jsonDataNotyDur.Replace("\"{", "\\{");
                        string r = q.Replace("\\n", "\r\n");
                        string s = r.Replace("\\", "");
                        string t = s.Replace("}\"]", "}]");
                        string u = t.Replace("}\",", "},");

                        List<clsEachTempNotyDur_INSRNC> objEachTempDetDurList = new List<clsEachTempNotyDur_INSRNC>();
                        objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur_INSRNC>>(u);

                        string DURROWID = objEachTempDetDurList[intCount].ROWID;
                        string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                        string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                        objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);

                        string jsonData = strEachTempString[intCount + 1];
                        string V = jsonData.Replace("\"{", "\\{");
                        string W = V.Replace("\\n", "\r\n");
                        string X = W.Replace("\\", "");
                        string Y = X.Replace("}\"]", "}]");
                        string Z = Y.Replace("}\",", "},");

                        List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();


                        List<clsEachTempDeatail_INSRNC> objEachTempDetList = new List<clsEachTempDeatail_INSRNC>();
                        objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail_INSRNC>>(Z);



                        if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                        {
                            int AddingCount = 0;
                            for (int count = 0; count < objEachTempDetList.Count; count++)
                            {
                                string ROWID = objEachTempDetList[count].ROWID;

                                string VALUE = objEachTempDetList[count].DDLVALUE;
                                string DDLMODE = objEachTempDetList[count].DDLMODE;
                                string DTLID = objEachTempDetList[count].DTLID;
                                if (VALUE != "0")
                                {
                                    InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                    if (DDLMODE == "ddlDivision_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 0;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlDesignation_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 1;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "ddlEmployee_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 2;
                                        objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                    }
                                    else if (DDLMODE == "txtGenMail_INSRNC_")
                                    {
                                        objEntityTemplateAlert.TemplateAlertOptId = 3;
                                        objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                    }

                                    if (DTLID != "0")
                                    {
                                        objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                        objBusinessInsurance.UpdateTemplateAlert(objEntityTempDeatils, objEntityTemplateAlert);
                                    }
                                    else
                                    {
                                        AddingCount++;
                                        objEntityTempAlertList.Add(objEntityTemplateAlert);
                                    }
                                }

                            }
                            if (objEntityTempDeatils.TempDetailId != 0)
                            {
                                if (AddingCount != 0)
                                {
                                    objBusinessInsurance.AddTemplateAlert(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                                }
                            }
                        }

                        if (objEntityTempDeatils.TempDetailId != 0)
                        {
                            objBusinessInsurance.UpdateTemplateDetail(objEntityTempDeatils);
                        }
                        else
                        {
                            objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }

                    string strTotalDelete = hiddenDeleteSliceData_INSRNC.Value;
                    string[] strEachTempDelete = new string[TempCount];
                    strEachTempDelete = strTotalDelete.Split('!');
                    for (int intDCount = 1; intDCount <= TempCount; intDCount++)
                    {
                        if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                        {
                            string strDeletedAlert = strEachTempDelete[intDCount];
                            string jsonDataDeleted = strDeletedAlert;
                            string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                            string d2 = d1.Replace("\\n", "\r\n");
                            string d3 = d2.Replace("\\", "");
                            string d4 = d3.Replace("}\"]", "}]");
                            string d5 = d4.Replace("}\",", "},");
                            List<InsuranceTemplateAlert> objEntityTempAlertDeleteList = new List<InsuranceTemplateAlert>();


                            List<clsEachAlertDel_INSRNC> objAlertDelList = new List<clsEachAlertDel_INSRNC>();
                            objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel_INSRNC>>(d5);
                            for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                            {
                                string ROWID = objAlertDelList[delcount].ROWID;
                                string AlertVALUE = objAlertDelList[delcount].DTLID;

                                InsuranceTemplateAlert objEntityTempAlertDelete = new InsuranceTemplateAlert();
                                objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                                objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                            }

                            objBusinessInsurance.DeleteTemplateAlert(objEntityTempAlertDeleteList);
                        }
                    }
                }

                if (clickedButton.ID == "btnUpdate_INSRNC")
                {
                    //REDIRECT TO UPDATE VIEW
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd_INSRNC";
                    objEntityQueryString.QueryStringValue = "Upd";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id_INSRNC";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);

                    Response.Redirect(strRedirectUrl);
                }
                else if (clickedButton.ID == "btnUpdateClose_INSRNC")
                {
                    if (Request.QueryString["default_INSRNC"] != null)
                    {
                        if (Request.QueryString["default_INSRNC"] == "3months")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Upd&default_INSRNC=3months");
                        }
                        else if (Request.QueryString["default_INSRNC"] == "expired")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Upd&default_INSRNC=expired");
                        }
                        else if (Request.QueryString["default_INSRNC"] == "new")
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Upd&default_INSRNC=new");
                        }
                        else
                        {
                            Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Upd");
                        }
                    }
                    else
                    {
                        Response.Redirect("gen_Bank_Guarantee_List.aspx?InsUpd_INSRNC=Upd");
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication_INSRNC", "Duplication_INSRNC();", true);
            }
        }
    }

    protected void btnConfirm_INSRNC_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        if (Request.QueryString["Id_INSRNC"] != null || Request.QueryString["ViewId_INSRNC"] != null)
        {
            string strRandomMixedId = "";
            if (Request.QueryString["Id_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["Id_INSRNC"].ToString();
            }
            if (Request.QueryString["ViewId_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId_INSRNC"].ToString();
            }
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.RefNumber = LabelRefnum_INSRNC.Text;
            objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

            if (HiddenFieldAmount_INSRNC.Value.Trim() != "")
            {
                objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount_INSRNC.Value);
            }

            if (ddlCurrency_INSRNC.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency_INSRNC.SelectedItem.Value);
            }

            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
            {
                objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
            }


            //evm-0023 strt
            if (ddlInsurncTyp.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
            {
                objEntityInsurance.InsuranceTypMstr = Convert.ToInt32(ddlInsurncTyp.SelectedItem.Value);
            }
            //evm-0023 end

            if (radioOpen_INSRNC.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 101;
                objEntityInsurance.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited_INSRNC.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 102;
                objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenTextValidty_INSRNC.Value);
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate_INSRNC.Text.Trim());
            }
            objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate_INSRNC.Text.Trim());

            if (cbxDontNotify_INSRNC.Checked == true)
            {
                objEntityInsurance.DontNotify = 1;
            }
            else
            {
                objEntityInsurance.DontNotify = 0;
            }

            objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate_INSRNC.SelectedItem.Value);
            objEntityInsurance.Description = txtDescrptn_INSRNC.Text.Trim();

            if (cbxExistingEmployee_INSRNC.Checked == true)
            {
                if (ddlExistingEmp_INSRNC.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    objEntityInsurance.EmployeName = ddlExistingEmp_INSRNC.SelectedItem.Text;
                    objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp_INSRNC.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.EmployeName = txtEmpName_INSRNC.Text.Trim();
            }

            if (cbxPrjct_INSRNC.Checked == true)
            {
                if (ddlProjects_INSRNC.SelectedItem.Value != "--SELECT PROJECT--")
                {
                    objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects_INSRNC.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.ProjectName = txtPrjctName_INSRNC.Text.Trim();
            }

            objEntityInsurance.Email = txtCntctMail_INSRNC.Text.Trim();
            objEntityInsurance.D_Date = System.DateTime.Now;

            string strGurntNo = "";
            strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

            if (strGurntNo == "" || strGurntNo == "0")
            {

                DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
                }
                if (strchckStatus == "1")
                {
                    objEntityInsurance.StatusIdCheck = 2;
                }
                else if (strchckStatus == "3")
                {
                    objEntityInsurance.StatusIdCheck = 4;
                }
                if (strchckStatus != "2")
                {

                    objBusinessInsurance.UpdateInsurance(objEntityInsurance);
                    objBusinessInsurance.ConfirmInsurance(objEntityInsurance);

                    //for UPDATING attachmnts

                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                    objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

                    List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

                    int intSlNumbr = 0;
                    if (hiddenAttchmntSlNumber_INSRNC.Value != "")
                    {
                        intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber_INSRNC.Value);
                        intSlNumbr++;
                    }

                    if (HiddenField2_FileUploadLnk_INSRNC.Value != "" && HiddenField2_FileUploadLnk_INSRNC.Value != null && HiddenField2_FileUploadLnk_INSRNC.Value != "[]")
                    {
                        string jsonDataDltAttch = HiddenField2_FileUploadLnk_INSRNC.Value;
                        string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                        string strAtt2 = strAtt1.Replace("\\", "");
                        string strAtt3 = strAtt2.Replace("}\"]", "}]");
                        string strAtt4 = strAtt3.Replace("}\",", "},");

                        List<clsBannerDataADDAttchmnt_INSRNC> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt_INSRNC>();
                        objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt_INSRNC>>(strAtt4);

                        foreach (clsBannerDataADDAttchmnt_INSRNC objClsBannrAddAttData in objBannerDataDltAttList)
                        {
                            if (objClsBannrAddAttData.EVTACTION == "INS")
                            {
                                string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                                HttpPostedFile PostedFile = Request.Files["file_INSRNC_" + strfilepath];
                                if (PostedFile.ContentLength > 0)
                                {
                                    clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                                    string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                    objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                                    string strFileExt;
                                    strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                    int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                                    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                    objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                    string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                    objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                    objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx_INSRNC" + strfilepath];

                                    objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(hiddenInsuranceId.Value);

                                    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                    PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                    objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                    intSlNumbr++;
                                }


                            }
                        }
                    }

                    List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

                    if (hiddenFileCanclDtlId_INSRNC.Value != "" && hiddenFileCanclDtlId_INSRNC.Value != null)
                    {
                        string jsonDataDltAttch = hiddenFileCanclDtlId_INSRNC.Value;
                        string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                        string strAtt2 = strAtt1.Replace("\\", "");
                        string strAtt3 = strAtt2.Replace("}\"]", "}]");
                        string strAtt4 = strAtt3.Replace("}\",", "},");

                        List<clsPictureDataDELETEAttchmnt_INSRNC> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt_INSRNC>();
                        objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt_INSRNC>>(strAtt4);

                        foreach (clsPictureDataDELETEAttchmnt_INSRNC objClsPictureDltAttData in objPictureDataDltAttList)
                        {
                            clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                            objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                            objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                            objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                        }
                    }

                    if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                    {
                        objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
                    }

                    if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
                    {
                        objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                        foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                        {
                            string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                            string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                            if (File.Exists(MapPath(imageLocation)))
                            {
                                File.Delete(MapPath(imageLocation));
                            }
                        }
                    }

                    objEntityInsurance.NextIdForRqst = objEntityInsurance.InsuranceId;

                    //for UPDATING template
                    if (hiddenTemplateChange_INSRNC.Value == "CHANGED")
                    {
                        //TEMPLT CHANGED

                        objBusinessInsurance.DeleteTemplateAlertById(objEntityInsurance);
                        objBusinessInsurance.DeleteTemplateDetailById(objEntityInsurance);

                        int TemplateCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);
                        string strEachTempTotalString = hiddenEachSliceData_INSRNC.Value;
                        string strNotifyMode = hiddenNotificationMOde_INSRNC.Value;
                        string strNotifyVia = hiddenNotifyVia_INSRNC.Value;
                        string strNotifyDur = hiddenNotificationDuration_INSRNC.Value;
                        int TempCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);

                        string[] strEachTempString = new string[TempCount];
                        strEachTempString = strEachTempTotalString.Split('!');

                        for (int intCount = 0; intCount < TempCount; intCount++)
                        {
                            InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                            //for template mode
                            string jsonDataNotyMod = strNotifyMode;
                            string a = jsonDataNotyMod.Replace("\"{", "\\{");
                            string b = a.Replace("\\n", "\r\n");
                            string c = b.Replace("\\", "");
                            string d = c.Replace("}\"]", "}]");
                            string k = d.Replace("}\",", "},");

                            List<clsEachTempNotyMOde_INSRNC> objEachTempDetModList = new List<clsEachTempNotyMOde_INSRNC>();
                            objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde_INSRNC>>(k);

                            string MODEROWID = objEachTempDetModList[intCount].ROWID;
                            string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                            string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                            if (NOTMODE == "D")
                            {
                                objEntityTempDeatils.TempDetPeriod = 2;
                            }
                            else
                            {
                                objEntityTempDeatils.TempDetPeriod = 1;
                            }

                            //for template NotifyVia
                            string jsonDataNotyVia = strNotifyVia;
                            string l = jsonDataNotyVia.Replace("\"{", "\\{");
                            string m = l.Replace("\\n", "\r\n");
                            string n = m.Replace("\\", "");
                            string o = n.Replace("}\"]", "}]");
                            string p = o.Replace("}\",", "},");

                            List<clsEachTempNotyVia_INSRNC> objEachTempDetViaList = new List<clsEachTempNotyVia_INSRNC>();
                            objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia_INSRNC>>(p);

                            string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                            string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                            string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                            if (VIAWHT.Contains("D"))
                            {
                                objEntityTempDeatils.IsDashBoard = 1;
                            }
                            if (VIAWHT.Contains("E"))
                            {
                                objEntityTempDeatils.IsEmail = 1;
                            }

                            //for template notify Duration
                            string jsonDataNotyDur = strNotifyDur;
                            string q = jsonDataNotyDur.Replace("\"{", "\\{");
                            string r = q.Replace("\\n", "\r\n");
                            string s = r.Replace("\\", "");
                            string t = s.Replace("}\"]", "}]");
                            string u = t.Replace("}\",", "},");

                            List<clsEachTempNotyDur_INSRNC> objEachTempDetDurList = new List<clsEachTempNotyDur_INSRNC>();
                            objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur_INSRNC>>(u);

                            string DURROWID = objEachTempDetDurList[intCount].ROWID;
                            string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                            string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                            objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);


                            string jsonData = strEachTempString[intCount + 1];
                            string V = jsonData.Replace("\"{", "\\{");
                            string W = V.Replace("\\n", "\r\n");
                            string X = W.Replace("\\", "");
                            string Y = X.Replace("}\"]", "}]");
                            string Z = Y.Replace("}\",", "},");

                            List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();

                            List<clsEachTempDeatail_INSRNC> objEachTempDetList = new List<clsEachTempDeatail_INSRNC>();
                            objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail_INSRNC>>(Z);

                            if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                            {

                                for (int count = 0; count < objEachTempDetList.Count; count++)
                                {
                                    string ROWID = objEachTempDetList[count].ROWID;

                                    string VALUE = objEachTempDetList[count].DDLVALUE;
                                    string DDLMODE = objEachTempDetList[count].DDLMODE;
                                    string DTLID = objEachTempDetList[count].DTLID;
                                    if (VALUE != "0")
                                    {
                                        InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                        if (DDLMODE == "ddlDivision_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 0;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlDesignation_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 1;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlEmployee_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 2;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "txtGenMail_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 3;
                                            objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                        }


                                        objEntityTempAlertList.Add(objEntityTemplateAlert);
                                    }
                                }

                            }

                            objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                        }
                    }
                    else
                    {
                        //SAME TEMPLT UPDT

                        int TemplateCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);
                        string strEachTempTotalString = hiddenEachSliceData_INSRNC.Value;
                        string strNotifyMode = hiddenNotificationMOde_INSRNC.Value;
                        string strNotifyVia = hiddenNotifyVia_INSRNC.Value;
                        string strNotifyDur = hiddenNotificationDuration_INSRNC.Value;
                        //-----for template ---
                        int TempCount = Convert.ToInt32(hiddenTemplateCount_INSRNC.Value);

                        string[] strEachTempString = new string[TempCount];
                        strEachTempString = strEachTempTotalString.Split('!');

                        for (int intCount = 0; intCount < TempCount; intCount++)
                        {
                            InsuranceTemplateDetail objEntityTempDeatils = new InsuranceTemplateDetail();

                            //for template mode
                            string jsonDataNotyMod = strNotifyMode;
                            string a = jsonDataNotyMod.Replace("\"{", "\\{");
                            string b = a.Replace("\\n", "\r\n");
                            string c = b.Replace("\\", "");
                            string d = c.Replace("}\"]", "}]");
                            string k = d.Replace("}\",", "},");

                            List<clsEachTempNotyMOde_INSRNC> objEachTempDetModList = new List<clsEachTempNotyMOde_INSRNC>();
                            objEachTempDetModList = JsonConvert.DeserializeObject<List<clsEachTempNotyMOde_INSRNC>>(k);

                            string MODEROWID = objEachTempDetModList[intCount].ROWID;
                            string NOTMODE = objEachTempDetModList[intCount].NOTMODE;
                            string MODETEMPID = objEachTempDetModList[intCount].TEMPID;

                            if (NOTMODE == "D")
                            {
                                objEntityTempDeatils.TempDetPeriod = 2;
                            }
                            else
                            {
                                objEntityTempDeatils.TempDetPeriod = 1;
                            }
                            if (MODETEMPID != "0")
                            {
                                objEntityTempDeatils.TempDetailId = Convert.ToInt32(MODETEMPID);
                            }
                            //for template NotifyVia
                            string jsonDataNotyVia = strNotifyVia;
                            string l = jsonDataNotyVia.Replace("\"{", "\\{");
                            string m = l.Replace("\\n", "\r\n");
                            string n = m.Replace("\\", "");
                            string o = n.Replace("}\"]", "}]");
                            string p = o.Replace("}\",", "},");

                            List<clsEachTempNotyVia_INSRNC> objEachTempDetViaList = new List<clsEachTempNotyVia_INSRNC>();
                            objEachTempDetViaList = JsonConvert.DeserializeObject<List<clsEachTempNotyVia_INSRNC>>(p);

                            string VIAROWID = objEachTempDetViaList[intCount].ROWID;
                            string VIAWHT = objEachTempDetViaList[intCount].NOTVIA;
                            string VIATEMPID = objEachTempDetViaList[intCount].TEMPID;

                            if (VIAWHT.Contains("D"))
                            {
                                objEntityTempDeatils.IsDashBoard = 1;
                            }
                            if (VIAWHT.Contains("E"))
                            {
                                objEntityTempDeatils.IsEmail = 1;
                            }

                            //for template notify Duration
                            string jsonDataNotyDur = strNotifyDur;
                            string q = jsonDataNotyDur.Replace("\"{", "\\{");
                            string r = q.Replace("\\n", "\r\n");
                            string s = r.Replace("\\", "");
                            string t = s.Replace("}\"]", "}]");
                            string u = t.Replace("}\",", "},");

                            List<clsEachTempNotyDur_INSRNC> objEachTempDetDurList = new List<clsEachTempNotyDur_INSRNC>();
                            objEachTempDetDurList = JsonConvert.DeserializeObject<List<clsEachTempNotyDur_INSRNC>>(u);

                            string DURROWID = objEachTempDetDurList[intCount].ROWID;
                            string DURCOUNT = objEachTempDetDurList[intCount].NOTDUR;
                            string DURTEMPID = objEachTempDetDurList[intCount].TEMPID;

                            objEntityTempDeatils.TempDetailPeriodCount = Convert.ToInt32(DURCOUNT);

                            string jsonData = strEachTempString[intCount + 1];
                            string V = jsonData.Replace("\"{", "\\{");
                            string W = V.Replace("\\n", "\r\n");
                            string X = W.Replace("\\", "");
                            string Y = X.Replace("}\"]", "}]");
                            string Z = Y.Replace("}\",", "},");

                            List<InsuranceTemplateAlert> objEntityTempAlertList = new List<InsuranceTemplateAlert>();


                            List<clsEachTempDeatail_INSRNC> objEachTempDetList = new List<clsEachTempDeatail_INSRNC>();
                            objEachTempDetList = JsonConvert.DeserializeObject<List<clsEachTempDeatail_INSRNC>>(Z);



                            if (strEachTempString[intCount + 1] != "" && strEachTempString[intCount + 1] != null)
                            {
                                int AddingCount = 0;
                                for (int count = 0; count < objEachTempDetList.Count; count++)
                                {
                                    string ROWID = objEachTempDetList[count].ROWID;

                                    string VALUE = objEachTempDetList[count].DDLVALUE;
                                    string DDLMODE = objEachTempDetList[count].DDLMODE;
                                    string DTLID = objEachTempDetList[count].DTLID;
                                    if (VALUE != "0")
                                    {
                                        InsuranceTemplateAlert objEntityTemplateAlert = new InsuranceTemplateAlert();
                                        if (DDLMODE == "ddlDivision_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 0;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlDesignation_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 1;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "ddlEmployee_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 2;
                                            objEntityTemplateAlert.TemplateWhoNotifyId = Convert.ToInt32(VALUE);
                                        }
                                        else if (DDLMODE == "txtGenMail_INSRNC_")
                                        {
                                            objEntityTemplateAlert.TemplateAlertOptId = 3;
                                            objEntityTemplateAlert.TemplateNotifyWhoMail = VALUE;
                                        }

                                        if (DTLID != "0")
                                        {
                                            objEntityTemplateAlert.TemplateAlertId = Convert.ToInt32(DTLID);
                                            objBusinessInsurance.UpdateTemplateAlert(objEntityTempDeatils, objEntityTemplateAlert);
                                        }
                                        else
                                        {
                                            AddingCount++;
                                            objEntityTempAlertList.Add(objEntityTemplateAlert);
                                        }
                                    }

                                }
                                if (objEntityTempDeatils.TempDetailId != 0)
                                {
                                    if (AddingCount != 0)
                                    {
                                        objBusinessInsurance.AddTemplateAlert(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                                    }
                                }
                            }

                            if (objEntityTempDeatils.TempDetailId != 0)
                            {
                                objBusinessInsurance.UpdateTemplateDetail(objEntityTempDeatils);
                            }
                            else
                            {
                                objBusinessInsurance.AddTemplateDetail(objEntityInsurance, objEntityTempDeatils, objEntityTempAlertList);
                            }
                        }

                        string strTotalDelete = hiddenDeleteSliceData_INSRNC.Value;
                        string[] strEachTempDelete = new string[TempCount];
                        strEachTempDelete = strTotalDelete.Split('!');
                        for (int intDCount = 1; intDCount <= TempCount; intDCount++)
                        {
                            if (strEachTempDelete[intDCount] != null && strEachTempDelete[intDCount] != "" && strEachTempDelete[intDCount] != "null")
                            {
                                string strDeletedAlert = strEachTempDelete[intDCount];
                                string jsonDataDeleted = strDeletedAlert;
                                string d1 = jsonDataDeleted.Replace("\"{", "\\{");
                                string d2 = d1.Replace("\\n", "\r\n");
                                string d3 = d2.Replace("\\", "");
                                string d4 = d3.Replace("}\"]", "}]");
                                string d5 = d4.Replace("}\",", "},");
                                List<InsuranceTemplateAlert> objEntityTempAlertDeleteList = new List<InsuranceTemplateAlert>();


                                List<clsEachAlertDel_INSRNC> objAlertDelList = new List<clsEachAlertDel_INSRNC>();
                                objAlertDelList = JsonConvert.DeserializeObject<List<clsEachAlertDel_INSRNC>>(d5);
                                for (int delcount = 0; delcount < objAlertDelList.Count; delcount++)
                                {
                                    string ROWID = objAlertDelList[delcount].ROWID;
                                    string AlertVALUE = objAlertDelList[delcount].DTLID;

                                    InsuranceTemplateAlert objEntityTempAlertDelete = new InsuranceTemplateAlert();
                                    objEntityTempAlertDelete.TemplateAlertId = Convert.ToInt32(AlertVALUE);
                                    objEntityTempAlertDeleteList.Add(objEntityTempAlertDelete);
                                }

                                objBusinessInsurance.DeleteTemplateAlert(objEntityTempAlertDeleteList);
                            }
                        }
                    }
                    //REDIRECT TO UPDATE VIEW
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd_INSRNC";
                    objEntityQueryString.QueryStringValue = "Cnfrm";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "ViewId_INSRNC";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);

                    Response.Redirect(strRedirectUrl);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheck_INSRNC", "StatusCheck_INSRNC();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication_INSRNC", "Duplication_INSRNC();", true);
            }
        }
    }

    protected void btnrenew_INSRNC_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = "";
        if (Request.QueryString["ViewId_INSRNC"] != null || Request.QueryString["Renew_INSRNC"] != null)
        {
            if (Request.QueryString["ViewId_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId_INSRNC"].ToString();
            }

            if (Request.QueryString["Renew_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["Renew_INSRNC"].ToString();
            }

            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            objEntityInsurance.RefNumber = LabelRefnum_INSRNC.Text;
            objEntityInsurance.InsuranceNo = txtInsuranceno.Text.Trim();

            if (HiddenFieldAmount_INSRNC.Value.Trim() != "")
            {
                objEntityInsurance.Amount = Convert.ToDecimal(HiddenFieldAmount_INSRNC.Value);
            }
            if (ddlCurrency_INSRNC.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                objEntityInsurance.Currency = Convert.ToInt32(ddlCurrency_INSRNC.SelectedItem.Value);
            }

            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
            {
                objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
            }

            //evm-0023 strt 
            if (ddlInsurncTyp.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
            {
                objEntityInsurance.InsuranceTypMstr = Convert.ToInt32(ddlInsurncTyp.SelectedItem.Value);
            }
            //evm-0023 end

            if (radioOpen_INSRNC.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 101;
                objEntityInsurance.ExpireDate = DateTime.MinValue;
            }
            else if (radioLimited_INSRNC.Checked == true)
            {
                objEntityInsurance.InsuranceTyp = 102;
                objEntityInsurance.NoOfDays = Convert.ToInt32(HiddenTextValidty_INSRNC.Value);
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(txtPrjctClsngDate_INSRNC.Text.Trim());
            }
            objEntityInsurance.OpenDate = objCommon.textToDateTime(txtOpngDate_INSRNC.Text.Trim());

            if (cbxDontNotify_INSRNC.Checked == true)
            {
                objEntityInsurance.DontNotify = 1;
            }
            else
            {
                objEntityInsurance.DontNotify = 0;
            }

            objEntityInsurance.NotTempId = Convert.ToInt32(ddlTemplate_INSRNC.SelectedItem.Value);
            objEntityInsurance.Description = txtDescrptn_INSRNC.Text.Trim();

            if (cbxExistingEmployee_INSRNC.Checked == true)
            {
                if (ddlExistingEmp_INSRNC.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    objEntityInsurance.EmployeName = ddlExistingEmp_INSRNC.SelectedItem.Text;
                    objEntityInsurance.ContactPersnUsrId = Convert.ToInt32(ddlExistingEmp_INSRNC.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.EmployeName = txtEmpName_INSRNC.Text.Trim();
            }

            if (cbxPrjct_INSRNC.Checked == true)
            {
                if (ddlProjects_INSRNC.SelectedItem.Value != "--SELECT PROJECT--")
                {
                    objEntityInsurance.ProjectId = Convert.ToInt32(ddlProjects_INSRNC.SelectedItem.Value);
                }
            }
            else
            {
                objEntityInsurance.ProjectName = txtPrjctName_INSRNC.Text.Trim();
            }

            objEntityInsurance.Email = txtCntctMail_INSRNC.Text.Trim();
            objEntityInsurance.D_Date = System.DateTime.Now;

            string strGurntNo = "";
            strGurntNo = objBusinessInsurance.CheckDupInsrncNo(objEntityInsurance);

            if (strGurntNo == "" || strGurntNo == "0")
            {

                DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
                }
                if (strchckStatus != "1")
                {
                    if (strchckStatus != "4")
                    {
                        if (strchckStatus == "2")
                        {
                            objBusinessInsurance.RenewInsurance(objEntityInsurance);
                        }

                        objBusinessInsurance.UpdateInsurance(objEntityInsurance);

                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                        objEntityCommon.CorporateID = objEntityInsurance.CorpOffice_Id;

                        List<clsEntityLayerInsuranceAttachments> objEntityLayerGuarenteeAtchmntDtlList = new List<clsEntityLayerInsuranceAttachments>();

                        int intSlNumbr = 0;
                        if (hiddenAttchmntSlNumber_INSRNC.Value != "")
                        {
                            intSlNumbr = Convert.ToInt32(hiddenAttchmntSlNumber_INSRNC.Value);
                            intSlNumbr++;
                        }

                        if (HiddenField2_FileUploadLnk_INSRNC.Value != "" && HiddenField2_FileUploadLnk_INSRNC.Value != null && HiddenField2_FileUploadLnk_INSRNC.Value != "[]")
                        {
                            string jsonDataDltAttch = HiddenField2_FileUploadLnk_INSRNC.Value;
                            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                            string strAtt2 = strAtt1.Replace("\\", "");
                            string strAtt3 = strAtt2.Replace("}\"]", "}]");
                            string strAtt4 = strAtt3.Replace("}\",", "},");

                            List<clsBannerDataADDAttchmnt_INSRNC> objBannerDataDltAttList = new List<clsBannerDataADDAttchmnt_INSRNC>();
                            objBannerDataDltAttList = JsonConvert.DeserializeObject<List<clsBannerDataADDAttchmnt_INSRNC>>(strAtt4);

                            foreach (clsBannerDataADDAttchmnt_INSRNC objClsBannrAddAttData in objBannerDataDltAttList)
                            {
                                if (objClsBannrAddAttData.EVTACTION == "INS")
                                {
                                    string strfilepath = Convert.ToString(objClsBannrAddAttData.ROWID);

                                    HttpPostedFile PostedFile = Request.Files["file_INSRNC_" + strfilepath];
                                    if (PostedFile.ContentLength > 0)
                                    {
                                        clsEntityLayerInsuranceAttachments objEntityLayerGuarnteeAtchmntDtl = new clsEntityLayerInsuranceAttachments();
                                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                        objEntityLayerGuarnteeAtchmntDtl.ActualFileName = strFileName;

                                        string strFileExt;
                                        strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                                        int intAppModSection = Convert.ToInt32(clsCommonLibrary.Section.INSURANCE_ATTACHMNT);
                                        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                        objEntityLayerGuarnteeAtchmntDtl.AttchmntSlNumber = intSlNumbr;
                                        string strImageName = intAppModSection.ToString() + "_" + intImageSection.ToString() + "_" + "_" + intSlNumbr + "." + strFileExt;
                                        objEntityLayerGuarnteeAtchmntDtl.FileName = strImageName;

                                        objEntityLayerGuarnteeAtchmntDtl.CaptionName = Request.Form["textbx_INSRNC" + strfilepath];

                                        objEntityLayerGuarnteeAtchmntDtl.InsuranceId = Convert.ToInt32(hiddenInsuranceId.Value);

                                        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                        PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityLayerGuarnteeAtchmntDtl.FileName);

                                        objEntityLayerGuarenteeAtchmntDtlList.Add(objEntityLayerGuarnteeAtchmntDtl);
                                        intSlNumbr++;
                                    }


                                }
                            }
                        }

                        List<clsEntityLayerInsuranceAttachments> objEntityLayerInsuranceAtchmntDtlListDelete = new List<clsEntityLayerInsuranceAttachments>();

                        if (hiddenFileCanclDtlId_INSRNC.Value != "" && hiddenFileCanclDtlId_INSRNC.Value != null)
                        {
                            string jsonDataDltAttch = hiddenFileCanclDtlId_INSRNC.Value;
                            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                            string strAtt2 = strAtt1.Replace("\\", "");
                            string strAtt3 = strAtt2.Replace("}\"]", "}]");
                            string strAtt4 = strAtt3.Replace("}\",", "},");

                            List<clsPictureDataDELETEAttchmnt_INSRNC> objPictureDataDltAttList = new List<clsPictureDataDELETEAttchmnt_INSRNC>();
                            objPictureDataDltAttList = JsonConvert.DeserializeObject<List<clsPictureDataDELETEAttchmnt_INSRNC>>(strAtt4);

                            foreach (clsPictureDataDELETEAttchmnt_INSRNC objClsPictureDltAttData in objPictureDataDltAttList)
                            {
                                clsEntityLayerInsuranceAttachments objEntityLayerInsuranceAtchmntDtl = new clsEntityLayerInsuranceAttachments();

                                objEntityLayerInsuranceAtchmntDtl.PictureId = Convert.ToInt32(objClsPictureDltAttData.DTLID);
                                objEntityLayerInsuranceAtchmntDtl.FileName = Convert.ToString(objClsPictureDltAttData.FILENAME);
                                objEntityLayerInsuranceAtchmntDtlListDelete.Add(objEntityLayerInsuranceAtchmntDtl);
                            }
                        }

                        if (objEntityLayerGuarenteeAtchmntDtlList.Count > 0)
                        {
                            objBusinessInsurance.Add_Pictures(objEntityInsurance, objEntityLayerGuarenteeAtchmntDtlList);
                        }

                        if (objEntityLayerInsuranceAtchmntDtlListDelete.Count > 0)
                        {
                            objBusinessInsurance.Delete_Pictures(objEntityInsurance, objEntityLayerInsuranceAtchmntDtlListDelete);

                            foreach (clsEntityLayerInsuranceAttachments objEntityLayerIInsuranceAtchmntDtl in objEntityLayerInsuranceAtchmntDtlListDelete)
                            {
                                string strImgPath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.INSURANCE_ATTACHMNT);
                                string imageLocation = strImgPath + objEntityLayerIInsuranceAtchmntDtl.FileName;
                                if (File.Exists(MapPath(imageLocation)))
                                {
                                    File.Delete(MapPath(imageLocation));
                                }
                            }
                        }


                        objBusinessInsurance.MailStatusChangeBack(objEntityInsurance);

                        //REDIRECT TO UPDATE VIEW 
                        List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                        objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                        clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "InsUpd_INSRNC";
                        objEntityQueryString.QueryStringValue = "Renewd";
                        objEntityQueryString.Encrypt = 0;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "ViewId_INSRNC";
                        objEntityQueryString.QueryStringValue = strId;
                        objEntityQueryString.Encrypt = 1;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                        Response.Redirect(strRedirectUrl);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "StsChkClsRenew_INSRNC", "StsChkClsRenew_INSRNC();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StsChkReopnRenew_INSRNC", "StsChkReopnRenew_INSRNC();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Duplication_INSRNC", "Duplication_INSRNC();", true);
            }
        }
    }

    protected void imgbtnReOpen_INSRNC_Click(object sender, ImageClickEventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        string strRandomMixedId = "";
        if (Request.QueryString["Id_INSRNC"] != null || Request.QueryString["ViewId_INSRNC"] != null || Request.QueryString["Renew_INSRNC"] != null)
        {
            if (Request.QueryString["Id_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["Id_INSRNC"].ToString();
            }
            if (Request.QueryString["ViewId_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId_INSRNC"].ToString();
            }

            if (Request.QueryString["Renew_INSRNC"] != null)
            {
                strRandomMixedId = Request.QueryString["Renew_INSRNC"].ToString();
            }

            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityInsurance.InsuranceId = Convert.ToInt32(strId);

            DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
            string strchckStatus = "";
            if (GuarantStatus.Rows.Count > 0)
            {
                strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
            }
            if (strchckStatus == "2")
            {
                objEntityInsurance.StatusIdCheck = 1;
            }
            else if (strchckStatus == "4")
            {
                objEntityInsurance.StatusIdCheck = 3;
            }
            if (strchckStatus != "4")
            {
                if (strchckStatus != "1")
                {
                    objBusinessInsurance.ReOpenInsurance(objEntityInsurance);
                    objBusinessInsurance.MailStatusChangeBack(objEntityInsurance);


                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    objEntityCommon.RedirectUrl = "gen_Bank_Guarantee.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd_INSRNC";
                    objEntityQueryString.QueryStringValue = "ReOpen";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id_INSRNC";
                    objEntityQueryString.QueryStringValue = strId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheckReopn_INSRNC", "StatusCheckReopn_INSRNC();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "StatusCheckClsReopn_INSRNC", "StatusCheckClsReopn_INSRNC();", true);
            }
        }

    }

    protected void btnCancel_INSRNC_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["default_INSRNC"] != null)
        {
            if (Request.QueryString["default_INSRNC"] == "3months")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?default_INSRNC=3months");
            }
            else if (Request.QueryString["default_INSRNC"] == "expired")
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx?default_INSRNC=expired");
            }
            else
            {
                Response.Redirect("gen_Bank_Guarantee_List.aspx");
            }
        }
        else
        {
            Response.Redirect("gen_Bank_Guarantee_List.aspx");
        }
    }


    //evm-0023
    public void LoadInsuranceType_Master()
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityInsurance.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtInsuranceTyp = objBusinessInsurance.ReadInsuranceTypes(objEntityInsurance);
        if (dtInsuranceTyp.Rows.Count > 0)
        {
            ddlInsurncTyp.DataSource = dtInsuranceTyp;
            ddlInsurncTyp.DataTextField = "INSRC_TYPMSTR_NAME";
            ddlInsurncTyp.DataValueField = "INSRC_TYPMSTR_ID";
            ddlInsurncTyp.DataBind();
        }
        ddlInsurncTyp.Items.Insert(0, "--SELECT INSURANCE TYPE--");
    }




}