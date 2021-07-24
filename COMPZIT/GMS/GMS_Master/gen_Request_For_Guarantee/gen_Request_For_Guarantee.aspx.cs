using BL_Compzit.BusinessLayer_GMS;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit;
using EL_Compzit;
using System.IO;
using System.Web.Services;
using System.Collections;
using System.Collections.Generic;
// CREATED BY:EVM-0005
// CREATED DATE:16/1/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Request_For_Guarantee_gen_Request_For_Guarantee : System.Web.UI.Page
{
    classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();

    protected void Page_Load(object sender, EventArgs e)
    {
        cbxExistingEmployee.Attributes.Add("onkeypress", "return isTag(event)");
        cbxStatus.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrjctClsngDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtPrjctClsngDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAmount.Attributes.Add("onkeypress", "return isTag(event)");
        txtCntctMail.Attributes.Add("onkeypress", "return isTag(event)");
        txtCntctMail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmpName.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmpName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtInFavrOf.Attributes.Add("onkeypress", "return isTag(event)");
        txtInFavrOf.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtRemarks.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtValidity.Attributes.Add("onkeypress", "return isTag(event)");
        txtValidity.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlCurrency.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCurrency.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlCustomer.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCustomer.Attributes.Add("onkeypress", "return DisableEnter(event)");
   
        ddlExistingEmp.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlGuaranteCat.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlGuaranteCat.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlJobCategory.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlJobCategory.Attributes.Add("onkeypress", "return DisableEnter(event)");

        ddlProject.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioLimited.Attributes.Add("onkeypress", "return DisableEnter(event)");
        radioOpen.Attributes.Add("onkeypress", "return DisableEnter(event)");


        if (!IsPostBack)
        {
            divtile.InnerHtml = "Request For Guarantees";
            ProjectLoad();
            CustomerLoad();
            CurrencyLoad();
            JobCategryLoad();
            EmployeeLoad();
            ddlGuaranteCat.Items.Insert(0, "--SELECT CATEGORY--");
            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableReissue = 0;
            radioOpen.Focus();
            imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";
            imgBtnClose.ImageUrl = "/Images/Icons/close guarantee.png";
            imgbtnReOpen.Visible = false;
            btnConfirm.Visible = false;
            hiddenRsnid.Value = "";
            HiddenReissue.Value = "";
            HiddenUserId.Value = "";
            BttnReissue.Visible = false;
            HiddenRFQid.Value = "";
            DivHistory.Visible = false;
            HiddenReissuecHCK.Value = "";
            Butproceed.Visible = false;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
                HiddenUserId.Value = intUserId.ToString();
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0, intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                HiddenOrgId.Value = Session["ORGID"].ToString();
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intEnableReOpen = 0, intEnableConfirm = 0;
            //Allocating child roles
            hiddenRoleAdd.Value = "0";
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
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
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        hiddenRoleClose.Value = intEnableConfirm.ToString();
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Reissue).ToString())
                    {
                        intEnableReissue = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenReissue.Value = intEnableReissue.ToString();
                    }
                }
            }
            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {

                btnUpdate.Visible = false;

            }
            btnNewCategory.Visible = false;
            btnNewCust.Visible = false;
            btnNewProject.Visible = false;
            int intUsrRolMstrIdPro = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project);
            DataTable dtChildRolProj = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdPro);
            if (dtChildRolProj.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolProj.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        btnNewProject.Visible = true;
                    }
                }
            }
            int intUsrRolMstrIdGuCat = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Guarantee_Type_Master);
            DataTable dtChildRolGuCat = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdGuCat);
            if (dtChildRolGuCat.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolGuCat.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        btnNewCategory.Visible = true;
                    }
                }
            }
            int intUsrRolMstrIdCust = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Customer_Master);
            DataTable dtChildRolCust = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCust);
            if (dtChildRolCust.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolCust.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();
                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        btnNewCust.Visible = true;
                    }
                }
            }


            classEntityLayerRequestForGrnte ObjEntityRFG = new classEntityLayerRequestForGrnte();
            DataTable dtshort = new DataTable();
            ObjEntityRFG.CorpOffice_Id = intCorpId;
            dtshort = ObjBussinessRequest.BindCorptShortName(ObjEntityRFG);
            h2_person.InnerHtml = dtshort.Rows[0]["CORPRT_NAME_SHORT"].ToString() + " -Contact Person";
            h2_email.InnerHtml = dtshort.Rows[0]["CORPRT_NAME_SHORT"].ToString() + " -Contact Person Email";

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

            if (Request.QueryString["Close"] != null && Request.QueryString["Close"] != "")
            {//when Canceled
                classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

                string strRandomMixedId = Request.QueryString["Close"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strId);
                ObjEntityRequest.User_Id = intUserId;
                ObjEntityRequest.D_Date = System.DateTime.Now;
                hiddenRsnid.Value = strId;

            }
            cbxExistingEmployee.Checked = true;
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenRFQid.Value = strId;
                Update(strId, intCorpId);
                lblEntry.Text = "Edit Request For Guarantee";

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
                        imgBtnClose.Visible = false;
                    }
                }
               
            }
            //for reissue and view
            else if (Request.QueryString["ReissueIddirect"] != null)
            {
                HiddenReissuecHCK.Value = Request.QueryString["ReissueIddirect"].ToString();
                btnClear.Visible = false;
                string strId = Request.QueryString["ReissueIddirect"].ToString();
                HiddenViewId.Value = strId;
                HiddenRFQid.Value = strId;
                View(strId, intCorpId);

                lblEntry.Text = "View Request For Guarantee";
                hiddenConfirmOrNot.Value = "1";
                imgBtnClose.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReissue", "SuccessReissue();", true);
            }
            else if (Request.QueryString["ReissueId"] != null)
            {

                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ReissueId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenViewId.Value = strId;
                HiddenReissuecHCK.Value = strId;
                HiddenRFQid.Value = strId;
                View(strId, intCorpId);
                lblEntry.Text = "View Request For Guarantee";
                hiddenConfirmOrNot.Value = "1";
                imgBtnClose.Visible = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenViewId.Value = strId;
                HiddenRFQid.Value = strId;
                View(strId, intCorpId);
                lblEntry.Text = "View Request For Guarantee";
                hiddenConfirmOrNot.Value = "1";
                imgBtnClose.Visible = false;


            }
            else
            {
                lblEntry.Text = "Add Request For Guarantee";



                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.REQUEST_FOR_GUARANTEE);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                string year = DateTime.Today.Year.ToString();

                lblRefNumber.Text = "RQST/" + year + "/" + strNextId;

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
               

                imgBtnClose.Visible = false;
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
                else if (strInsUpd == "CntrctIns")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationCntrct", "SuccessConfirmationCntrct();", true);
                }
                else if (strInsUpd == "PrjIns")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrjct", "SuccessConfirmationPrjct();", true);
                }
                else if (strInsUpd == "PrjUpd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrjct", "SuccessUpdationPrjct();", true);
                }
                else if (strInsUpd == "PrcedCh")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessProceed", "SuccessProceed();", true);
                }
            }



            // created object for business layer for compare the date
            string strCurrentDate = objBusiness.LoadCurrentDateInString();
            hiddenPermitFileSize.Value = clsCommonLibrary.IMAGE_SIZE.REQUEST_FOR_GUARANTEE.ToString();
            hiddenCurrentDate.Value = strCurrentDate;

        }


    }

    public void ProjectLoad()
    {

        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

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
        DataTable dtProject = ObjBussinessRequest.ReadProjects(ObjEntityRequest);
        if (dtProject.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProject;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");
    }
    public void CustomerLoad()
    {

        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

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
        DataTable dtCustomer = ObjBussinessRequest.ReadCustomer(ObjEntityRequest);
        if (dtCustomer.Rows.Count > 0)
        {
            ddlCustomer.DataSource = dtCustomer;
            ddlCustomer.DataTextField = "CSTMR_NAME";
            ddlCustomer.DataValueField = "CSTMR_ID";
            ddlCustomer.DataBind();

        }

        ddlCustomer.Items.Insert(0, "--SELECT CUSTOMER--");
    }
    public void CurrencyLoad()
    {

        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

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
        DataTable dtCustomer = ObjBussinessRequest.ReadCurrency(ObjEntityRequest);
        if (dtCustomer.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtCustomer;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }

        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
    }
    public void JobCategryLoad()
    {

        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

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
        DataTable dtCustomer = ObjBussinessRequest.ReadJobCategory(ObjEntityRequest);
        if (dtCustomer.Rows.Count > 0)
        {
            ddlJobCategory.DataSource = dtCustomer;
            ddlJobCategory.DataTextField = "JOBCTGRY_NAME";
            ddlJobCategory.DataValueField = "JOBCTGRY_ID";
            ddlJobCategory.DataBind();

        }

        ddlJobCategory.Items.Insert(0, "--SELECT JOB CATEGORY--");
    }

    public void CategryLoad()
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

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

        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            ObjEntityRequest.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        DataTable dtGuaranteCat = ObjBussinessRequest.ReadGuaranteeCat(ObjEntityRequest);
        ddlGuaranteCat.Items.Clear();
        if (dtGuaranteCat.Rows.Count > 0)
        {
            ddlGuaranteCat.DataSource = dtGuaranteCat;
            ddlGuaranteCat.DataTextField = "GUANTCAT_NAME";
            ddlGuaranteCat.DataValueField = "GUANTCAT_ID";
            ddlGuaranteCat.DataBind();

        }
        ddlGuaranteCat.Items.Insert(0, "--SELECT CATEGORY--");

    }

    public void EmployeeLoad()
    {

        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

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
        DataTable dtCustomer = ObjBussinessRequest.ReadEmployee(ObjEntityRequest);
        if (dtCustomer.Rows.Count > 0)
        {
            ddlExistingEmp.DataSource = dtCustomer;
            ddlExistingEmp.DataTextField = "USR_NAME";
            ddlExistingEmp.DataValueField = "USR_ID";
            ddlExistingEmp.DataBind();

        }

        ddlExistingEmp.Items.Insert(0, "--SELECT EMPLOYEE--");
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null || Request.QueryString["ReissueId"] != null || Request.QueryString["ReissueIddirect"] != null)
        {

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
            string strUpdateMode = "Id";

            if (HiddenReissuecHCK.Value == "")
            {

                //Status checkbox checked
                if (cbxStatus.Checked == true)
                {
                    ObjEntityRequest.Guarantee_Status = 1;
                }
                //Status checkbox not checked
                else
                {
                    ObjEntityRequest.Guarantee_Status = 0;
                }
                string strRandomMixedId = "";
                if (Request.QueryString["Id"] != null)
                {
                    strRandomMixedId = Request.QueryString["Id"].ToString();
                }
                else if (Request.QueryString["ViewId"] != null)
                {
                    strRandomMixedId = Request.QueryString["ViewId"].ToString();
                }
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);

                ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strReqForIdId);

                ObjEntityRequest.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());

                if (txtValidity.Text.ToUpper().Trim() != "")
                {
                    ObjEntityRequest.Validity = Convert.ToInt32(txtValidity.Text.ToUpper().Trim());
                }
                ObjEntityRequest.ProjCloseDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
                if (txtInFavrOf.Text.Trim() != "")
                {
                    ObjEntityRequest.InFavrOf = txtInFavrOf.Text.Trim();
                }

                if (txtCntctMail.Text.Trim() != "")
                {
                    ObjEntityRequest.ContactMail = txtCntctMail.Text.Trim();
                }
                if (txtRemarks.Text.Trim() != "")
                {
                    ObjEntityRequest.Remarks = txtRemarks.Text.Trim();
                }

                if (cbxExistingEmployee.Checked == true)
                {
                    if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                    {
                        ObjEntityRequest.EmployeId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
                    }
                }
                else
                {
                    ObjEntityRequest.ContactName = txtEmpName.Text.Trim();
                }

                if (radioOpen.Checked == true)
                {
                    ObjEntityRequest.GuarTypeId = 101;
                }
                else if (radioLimited.Checked == true)
                {
                    ObjEntityRequest.GuarTypeId = 102;
                }
                if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
                {
                    ObjEntityRequest.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
                }
                if (hiddenGuantCat.Value != "--SELECT CATEGORY--")
                {
                    ObjEntityRequest.GuarCatId = Convert.ToInt32(hiddenGuantCat.Value);
                }
                if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
                {
                    ObjEntityRequest.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                }
                if (ddlCustomer.SelectedItem.Value != "--SELECT CUSTOMER--")
                {
                    ObjEntityRequest.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
                }
                if (ddlJobCategory.SelectedItem.Value != "--SELECT JOB CATEGORY--")
                {
                    ObjEntityRequest.JobCat_Id = Convert.ToInt32(ddlJobCategory.SelectedItem.Value);
                }

                if (Session["USERID"] != null)
                {
                    ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }

                ObjEntityRequest.D_Date = System.DateTime.Now;

                //Checking is there table have any name like this
                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
                string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
                if (FileUploadRecharge.HasFile)
                {
                    // GET FILE EXTENSION

                    string strFileExt;
                    ObjEntityRequest.FileNameAct = FileUploadRecharge.FileName;
                    strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

                    string strImageName = intImageSection.ToString() + "_" + ObjEntityRequest.ReqForGuarId + "." + strFileExt;
                    ObjEntityRequest.FileName = strImageName;


                }
                else
                {

                    if (hiddenRechargeFile.Value == "")
                    {
                        ObjEntityRequest.FileName = "";
                        ObjEntityRequest.FileNameAct = "";

                    }
                    else
                    {
                        ObjEntityRequest.FileName = hiddenRechargeFile.Value;
                        ObjEntityRequest.FileNameAct = hiddenRechargeFileAct.Value;
                    }
                }

                ObjBussinessRequest.UpdateRqstForGuarantee(ObjEntityRequest);
                if (FileUploadRecharge.HasFile)
                {
                    if (hiddenRechargeFileDeleted.Value != "")
                    {
                        string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }
                    FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + ObjEntityRequest.FileName);
                }
                else
                {
                    if (hiddenRechargeFile.Value == "")
                    {
                        if (hiddenRechargeFileDeleted.Value != "")
                        {
                            string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                            if (File.Exists(MapPath(imageLocation)))
                            {
                                File.Delete(MapPath(imageLocation));
                            }
                        }
                    }
                }
            }
            else
            {
                ObjEntityRequest.ReqForGuarId = Convert.ToInt32(HiddenReissuecHCK.Value);
                ObjEntityRequest.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
                ObjEntityRequest.ProjCloseDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
                ObjBussinessRequest.UpdateRqstForGuaranteeReissue(ObjEntityRequest);
                strUpdateMode = "ReissueId";
            }

            if (clickedButton.ID == "btnUpdate")
            {
                //REDIRECT TO UPDATE VIEW 
                List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                objEntityCommon.RedirectUrl = "gen_Request_For_Guarantee.aspx";
                clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                objEntityQueryString.QueryString = "InsUpd";
                objEntityQueryString.QueryStringValue = "Upd";
                objEntityQueryString.Encrypt = 0;
                objEntityQueryStringList.Add(objEntityQueryString);
                objEntityQueryString = new clsEntityQueryString();
                objEntityQueryString.QueryString = strUpdateMode;
                objEntityQueryString.QueryStringValue = ObjEntityRequest.ReqForGuarId.ToString();
                objEntityQueryString.Encrypt = 1;
                objEntityQueryStringList.Add(objEntityQueryString);
                string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                Response.Redirect(strRedirectUrl);
                //if (hiddenRoleAdd.Value.ToString() != "")
                //{
                //    if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                //    {
                //        string strUrl = "gen_Request_For_Guarantee.aspx?Id=";
                //        string strId = "09271622602PPNFK9";
                //        string strMsg = "InsUpd=Upd";
                //        Response.Redirect(strUrl + strId + "&" + strMsg);
                //    }
                //    else
                //    {
                //        Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Upd");
                //    }

                //}

            }
            else if (clickedButton.ID == "btnUpdateClose")
            {
                Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Upd");
            }
            else if (clickedButton.ID == "Butproceed")
            {
                classBusinessLayerRequestForGrnte ObjBussinessRequestGrnty = new classBusinessLayerRequestForGrnte();
               // classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
                if (HiddenRFQid.Value != "" && HiddenUserId.Value != "")
                {

                    ObjEntityRequest.User_Id = Convert.ToInt32(HiddenUserId.Value);

                    ObjEntityRequest.Guarantee_Status = 5;

                    ObjEntityRequest.ReqForGuarId = Convert.ToInt32(HiddenRFQid.Value);
                    try
                    {
                        ObjBussinessRequestGrnty.ChangeReqToProcd(ObjEntityRequest);
                        //REDIRECT TO UPDATE VIEW 
                        List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                        
                        objEntityCommon.RedirectUrl = "gen_Request_For_Guarantee.aspx";
                        clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "InsUpd";
                        objEntityQueryString.QueryStringValue = "PrcedCh";
                        objEntityQueryString.Encrypt = 0;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        objEntityQueryString = new clsEntityQueryString();
                        objEntityQueryString.QueryString = "ViewId";
                        objEntityQueryString.QueryStringValue = ObjEntityRequest.ReqForGuarId.ToString();
                        objEntityQueryString.Encrypt = 1;
                        objEntityQueryStringList.Add(objEntityQueryString);
                        string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                        Response.Redirect(strRedirectUrl);

                    }
                    catch
                    {

                    }
                }
                
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
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

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            ObjEntityRequest.Guarantee_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            ObjEntityRequest.Guarantee_Status = 0;
        }
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.REQUEST_FOR_GUARANTEE);
        objEntityCommon.CorporateID = ObjEntityRequest.CorpOffice_Id;
        objEntityCommon.Organisation_Id = ObjEntityRequest.Organisation_Id;
        string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        ObjEntityRequest.NextIdForRqst = Convert.ToInt32(strNextId);

        ObjEntityRequest.RefNumber = lblRefNumber.Text.Trim();
        ObjEntityRequest.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
        if (txtValidity.Text.ToUpper().Trim() != "")
        {
            ObjEntityRequest.Validity = Convert.ToInt64(txtValidity.Text.ToUpper().Trim());
        }
        ObjEntityRequest.ProjCloseDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
        if (txtInFavrOf.Text.Trim() != "")
        {
            ObjEntityRequest.InFavrOf = txtInFavrOf.Text.Trim();
        }

        if (txtCntctMail.Text.Trim() != "")
        {
            ObjEntityRequest.ContactMail = txtCntctMail.Text.Trim();
        }
        if (txtRemarks.Text.Trim() != "")
        {
            ObjEntityRequest.Remarks = txtRemarks.Text.Trim();
        }

        if (cbxExistingEmployee.Checked == true)
        {
            if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                ObjEntityRequest.EmployeId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
            }
        }
        else
        {
            ObjEntityRequest.ContactName = txtEmpName.Text.Trim();
        }

        if (radioOpen.Checked == true)
        {
            ObjEntityRequest.GuarTypeId = 101;
        }
        else if (radioLimited.Checked == true)
        {
            ObjEntityRequest.GuarTypeId = 102;
        }
        if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
        {
            ObjEntityRequest.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        }
        if (hiddenGuantCat.Value != "--SELECT CATEGORY--")
        {
            ObjEntityRequest.GuarCatId = Convert.ToInt32(hiddenGuantCat.Value);
        }
        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
        {
            ObjEntityRequest.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        }
        if (ddlCustomer.SelectedItem.Value != "--SELECT CUSTOMER--")
        {
            ObjEntityRequest.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
        }
        if (ddlJobCategory.SelectedItem.Value != "--SELECT JOB CATEGORY--")
        {
            ObjEntityRequest.JobCat_Id = Convert.ToInt32(ddlJobCategory.SelectedItem.Value);
        }

        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntityRequest.D_Date = System.DateTime.Now;

        //EVM-0016
        int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
        string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
        if (FileUploadRecharge.HasFile)
        {
            // GET FILE EXTENSION

            string strFileExt;
            ObjEntityRequest.FileNameAct = FileUploadRecharge.FileName;
            strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

            string strImageName = intImageSection.ToString() + "_" + ObjEntityRequest.NextId + "." + strFileExt;
            ObjEntityRequest.FileName = strImageName;
        }


        //EVM-0016

        ObjBussinessRequest.AddRqstForGuarantee(ObjEntityRequest);
        if (FileUploadRecharge.HasFile)
        {
            FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + ObjEntityRequest.FileName);
        }
        if (clickedButton.ID == "btnAdd")
        {
            Response.Redirect("gen_Request_For_Guarantee.aspx?InsUpd=Ins");
        }
        else if (clickedButton.ID == "btnAddClose")
        {
            Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Ins");
        }


    }




    [WebMethod]
    public static string[] ProjectChange(int ProjectId, int OrgId, int corpId)
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
        string[] Contents = new string[4];
        ObjEntityRequest.CorpOffice_Id = corpId;
        ObjEntityRequest.Organisation_Id = OrgId;
        ObjEntityRequest.ProjectId = ProjectId;
        DataTable dtGuaranteCat = ObjBussinessRequest.ReadGuaranteeCat(ObjEntityRequest);

        dtGuaranteCat.TableName = "dtCategory";
        using (StringWriter sw = new StringWriter())
        {
            dtGuaranteCat.WriteXml(sw);
            Contents[0] = sw.ToString();
        }

        DataTable dtProject = ObjBussinessRequest.ReadpRrojectById(ObjEntityRequest);
        if (dtProject.Rows.Count > 0)
        {

            if (dtProject.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtProject.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == "")
            {
                Contents[1] = dtProject.Rows[0]["CSTMR_ID"].ToString();

            }


            if (dtProject.Rows[0]["USR_ID"].ToString() != "" && dtProject.Rows[0]["USR_ID"] != DBNull.Value)
            {
                if (dtProject.Rows[0]["USR_STATUS"].ToString() == "1" && dtProject.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    Contents[2] = dtProject.Rows[0]["USR_ID"].ToString();

                }


            }

            if (dtProject.Rows[0]["USR_EMAIL"].ToString() != "" && dtProject.Rows[0]["USR_EMAIL"] != DBNull.Value)
            {
                Contents[3] = dtProject.Rows[0]["USR_EMAIL"].ToString();
            }
        }

        return Contents;
    }


    [WebMethod]
    public static string[] EmployeeChange(int EmployeeId, int OrgId, int corpId)
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
        string[] Contents = new string[1];
        ObjEntityRequest.CorpOffice_Id = corpId;
        ObjEntityRequest.Organisation_Id = OrgId;
        ObjEntityRequest.EmployeId = EmployeeId;


        DataTable dtEmploye = ObjBussinessRequest.ReadEmployeeData(ObjEntityRequest);
        if (dtEmploye.Rows.Count > 0)
        {

            Contents[0] = dtEmploye.Rows[0]["USR_EMAIL"].ToString();
        }


        return Contents;
    }

    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        int intReissueChk = 0;
        DivHistory.Visible = true;
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
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
        ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strP_Id);
        ObjEntityRequest.CorpOffice_Id = intCorpId;
        DataTable dtRqstFrGrnt = ObjBussinessRequest.ReadRqstFrGrntyById(ObjEntityRequest);
        if (dtRqstFrGrnt.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate

            if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
            }
            else if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "102")
            {
                radioLimited.Checked = true;
            }
            Labl_HistoryList.Text = "Request For Guarantee History-" + dtRqstFrGrnt.Rows[0]["RFQ_REF_NUMBER"].ToString();
            txtCntctMail.Text = dtRqstFrGrnt.Rows[0]["RFQ_CNCT_PERSON_EMAIL"].ToString();
            txtRemarks.Text = dtRqstFrGrnt.Rows[0]["RFQ_REMARKS"].ToString();
            txtPrjctClsngDate.Text = dtRqstFrGrnt.Rows[0]["RFQ_CLOSING_DATE"].ToString();
            txtInFavrOf.Text = dtRqstFrGrnt.Rows[0]["RFQ_FAVOUR_OF"].ToString();
            txtEmpName.Text = dtRqstFrGrnt.Rows[0]["RFQ_CNCT_PERSON"].ToString();

            txtAmount.Text = dtRqstFrGrnt.Rows[0]["RFQ_AMOUNT"].ToString();
            txtValidity.Text = dtRqstFrGrnt.Rows[0]["RFQ_VALIDITY_DAYS"].ToString();
            lblRefNumber.Text = dtRqstFrGrnt.Rows[0]["RFQ_REF_NUMBER"].ToString();
            if (dtRqstFrGrnt.Rows[0]["PROJECT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == "")
            {
                ddlProject.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString());
                ddlProject.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProject);

                ddlProject.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }
            ObjEntityRequest.ProjectId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PROJECT_ID"]);
            DataTable dtGuaranteCat = ObjBussinessRequest.ReadGuaranteeCat(ObjEntityRequest);
            ddlGuaranteCat.Items.Clear();
            if (dtGuaranteCat.Rows.Count > 0)
            {
                ddlGuaranteCat.DataSource = dtGuaranteCat;
                ddlGuaranteCat.DataTextField = "GUANTCAT_NAME";
                ddlGuaranteCat.DataValueField = "GUANTCAT_ID";
                ddlGuaranteCat.DataBind();

            }
            ddlGuaranteCat.Items.Insert(0, "--SELECT CATEGORY--");

            string strAwardedBiding = "";
            int intAwardedBidngChk = 0;

            strAwardedBiding = ObjBussinessRequest.ChkAwardedBiding(ObjEntityRequest);

            if (strAwardedBiding == "0")
            {
                intAwardedBidngChk = 1;
            }
            if (intAwardedBidngChk == 0)
            {
                if (dtRqstFrGrnt.Rows[0]["GUANTCAT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["GUANTCAT_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                    {

                        ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                        ddlGuaranteCat.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlGuaranteCat);

                        ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                    ddlGuaranteCat.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlGuaranteCat);

                    ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                ddlGuaranteCat.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlGuaranteCat);

                ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()) != null)
                    ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString());
                    ddlCustomer.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCustomer);

                    ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString());
                ddlCustomer.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCustomer);

                ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString() != "" && dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"] != null)
            {
                if (dtRqstFrGrnt.Rows[0]["JOBCTGRY_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["JOBCTGRY_CNCL_USR_ID"].ToString() == "1")
                {
                    ddlJobCategory.Items.FindByValue(dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["JOBCTGRY_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString());
                    ddlJobCategory.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlJobCategory);

                    ddlJobCategory.Items.FindByValue(dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
                }
            }
            if (dtRqstFrGrnt.Rows[0]["USR_ID"].ToString() != "" && dtRqstFrGrnt.Rows[0]["USR_ID"] != null)
            {
                if (dtRqstFrGrnt.Rows[0]["USR_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["USR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["USR_ID"].ToString());
                    ddlExistingEmp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp);

                    ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee.Checked = false;
            }

            if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCurrency);

                ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["RFG_FILENAME"] != DBNull.Value && dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString() != "")
            {
                hiddenRechargeFile.Value = dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString();
                hiddenRechargeFileAct.Value = dtRqstFrGrnt.Rows[0]["RFG_FLNM_ACT"].ToString();
                string strFileName = dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE) + dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                {

                    strImage = "<a style=\"font-family: Calibri;font-size:13px;margin-left: -311px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Attachment Uploaded</a>";
                    strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                    strImage += " <img src=\"" + strImagePath + "\"/>";
                    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                    strImage += "</div>";

                }
                else
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                }
                divImageDisplay.InnerHtml = strImage;
            }


            int intRFQStatus = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["RFQ_STATUS"]);
            if (intRFQStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
            }
            else if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "102")
            {
                radioLimited.Checked = true;
            }

            if (HiddenReissue.Value == "1")
            {
                if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "5")
                {
                    BttnReissue.Visible = true;
                }
            }
            if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "6")
            {
                intReissueChk = 1;
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;
            }
            if (hiddenRoleConfirm.Value != "")
            {
                if (hiddenRoleConfirm.Value == "1")
                {

                    if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "5")
                    {
                        btnConfirm.Visible = true;
                    }
                }
            }
            ObjEntityRequest.Guarantee_Status = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString());
            DataTable dtRqstStatus = ObjBussinessRequest.ReadRFGStatusdtails(ObjEntityRequest);
            if (dtRqstStatus.Rows.Count > 0)
            {
                if (dtRqstStatus.Rows[0]["RFQ_DATE"].ToString() != "")
                {
                    LMDate.InnerText = dtRqstStatus.Rows[0]["RFQ_DATE"].ToString();
                }
                LMUser.InnerText = dtRqstStatus.Rows[0]["USR_NAME"].ToString();
                LMStatus.InnerText = dtRqstStatus.Rows[0]["STATUS"].ToString();
            }

        }
        if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "6")
        {
            Butproceed.Visible = true;
        }

        txtCntctMail.Enabled = false;
        cbxStatus.Enabled = false;
        cbxExistingEmployee.Enabled = false;
        txtRemarks.Enabled = false;
        if (intReissueChk != 1)
        {

            txtPrjctClsngDate.Enabled = false;
            txtAmount.Enabled = false;
        }



        txtInFavrOf.Enabled = false;
        txtEmpName.Enabled = false;
        txtValidity.Enabled = false;
        ddlProject.Enabled = false;
        ddlJobCategory.Enabled = false;
        ddlGuaranteCat.Enabled = false;
        ddlExistingEmp.Enabled = false;
        ddlCustomer.Enabled = false;
        ddlCurrency.Enabled = false;
        radioOpen.Disabled = true;
        radioLimited.Disabled = true;
        FileUploadRecharge.Enabled = false;
        btnNewProject.Enabled = false;
        btnNewCategory.Enabled = false;
        btnNewCust.Enabled = false;
        ScriptManager.RegisterStartupScript(this, GetType(), "disablingCancel", "disablingCancel();", true);

    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        DivHistory.Visible = true;
        int BankGurntChck = 0;
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
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
        ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strP_Id);
        ObjEntityRequest.CorpOffice_Id = intCorpId;
        DataTable dtRqstFrGrnt = ObjBussinessRequest.ReadRqstFrGrntyById(ObjEntityRequest);
        if (dtRqstFrGrnt.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            Labl_HistoryList.Text = "Request For Guarantee History-" + dtRqstFrGrnt.Rows[0]["RFQ_REF_NUMBER"].ToString();
            txtCntctMail.Text = dtRqstFrGrnt.Rows[0]["RFQ_CNCT_PERSON_EMAIL"].ToString();
            txtRemarks.Text = dtRqstFrGrnt.Rows[0]["RFQ_REMARKS"].ToString();
            txtPrjctClsngDate.Text = dtRqstFrGrnt.Rows[0]["RFQ_CLOSING_DATE"].ToString();
            txtInFavrOf.Text = dtRqstFrGrnt.Rows[0]["RFQ_FAVOUR_OF"].ToString();
            txtEmpName.Text = dtRqstFrGrnt.Rows[0]["RFQ_CNCT_PERSON"].ToString();

            txtAmount.Text = dtRqstFrGrnt.Rows[0]["RFQ_AMOUNT"].ToString();

            txtValidity.Text = dtRqstFrGrnt.Rows[0]["RFQ_VALIDITY_DAYS"].ToString();
            lblRefNumber.Text = dtRqstFrGrnt.Rows[0]["RFQ_REF_NUMBER"].ToString();
            if (dtRqstFrGrnt.Rows[0]["PROJECT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == "")
            {
                ddlProject.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["PROJECT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString());
                ddlProject.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProject);

                ddlProject.Items.FindByValue(dtRqstFrGrnt.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }

            ObjEntityRequest.ProjectId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["PROJECT_ID"]);
            DataTable dtGuaranteCat = ObjBussinessRequest.ReadGuaranteeCat(ObjEntityRequest);
            ddlGuaranteCat.Items.Clear();
            if (dtGuaranteCat.Rows.Count > 0)
            {
                ddlGuaranteCat.DataSource = dtGuaranteCat;
                ddlGuaranteCat.DataTextField = "GUANTCAT_NAME";
                ddlGuaranteCat.DataValueField = "GUANTCAT_ID";
                ddlGuaranteCat.DataBind();

            }
            ddlGuaranteCat.Items.Insert(0, "--SELECT CATEGORY--");
            string strAwardedBiding = "", strcatagory = "";
            int intAwardedBidngChk = 0;
            classBusinessLayerRequestForGrnte ObjBussinessRequest2 = new classBusinessLayerRequestForGrnte();
            ObjEntityRequest.GuarCatId = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"]);
            strAwardedBiding = ObjBussinessRequest.ChkAwardedBiding(ObjEntityRequest);
            strcatagory = ObjBussinessRequest2.ChkCatagory(ObjEntityRequest);

            if (strAwardedBiding == "0")
            {
                intAwardedBidngChk = 1;
            }
            if (intAwardedBidngChk == 0)
            {
                if (strcatagory == "102")
                {
                    if (ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()) != null)
                    {
                        if (dtRqstFrGrnt.Rows[0]["GUANTCAT_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["GUANTCAT_CNCL_USR_ID"].ToString() == "")
                        {
                            ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                            ddlGuaranteCat.Items.Insert(1, lstGrp);

                            SortDDL(ref this.ddlGuaranteCat);

                            ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                        }
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                        ddlGuaranteCat.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlGuaranteCat);

                        ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;

                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                    ddlGuaranteCat.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlGuaranteCat);

                    ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["GUANTCAT_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString());
                ddlGuaranteCat.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlGuaranteCat);

                ddlGuaranteCat.Items.FindByValue(dtRqstFrGrnt.Rows[0]["GUANTCAT_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == "")
            {
                if (ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()) != null)
                    ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString());
                    ddlCustomer.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlCustomer);

                    ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }

            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CSTMR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString());
                ddlCustomer.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCustomer);

                ddlCustomer.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString() != "" && dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"] != null)
            {
                if (dtRqstFrGrnt.Rows[0]["JOBCTGRY_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["JOBCTGRY_CNCL_USR_ID"].ToString() == "1")
                {
                    ddlJobCategory.Items.FindByValue(dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["JOBCTGRY_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString());
                    ddlJobCategory.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlJobCategory);

                    ddlJobCategory.Items.FindByValue(dtRqstFrGrnt.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
                }
            }
            if (dtRqstFrGrnt.Rows[0]["USR_ID"].ToString() != "" && dtRqstFrGrnt.Rows[0]["USR_ID"] != null)
            {
                if (dtRqstFrGrnt.Rows[0]["USR_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["USR_CNCL_USR_ID"].ToString() == "")
                {
                    ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["USR_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["USR_ID"].ToString());
                    ddlExistingEmp.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmp);

                    ddlExistingEmp.Items.FindByValue(dtRqstFrGrnt.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                cbxExistingEmployee.Checked = false;
            }


            if (dtRqstFrGrnt.Rows[0]["CRNCMST_STATUS"].ToString() == "1" && dtRqstFrGrnt.Rows[0]["CRNCMST_CNCL_USR_ID"].ToString() == "")
            {
                ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtRqstFrGrnt.Rows[0]["CRNCMST_NAME"].ToString(), dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCurrency);

                ddlCurrency.Items.FindByValue(dtRqstFrGrnt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            if (dtRqstFrGrnt.Rows[0]["RFG_FILENAME"] != DBNull.Value && dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString() != "")
            {
                hiddenRechargeFile.Value = dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString();
                hiddenRechargeFileAct.Value = dtRqstFrGrnt.Rows[0]["RFG_FLNM_ACT"].ToString();
                string strFileName = dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString();

                clsCommonLibrary objCommon = new clsCommonLibrary();
                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE) + dtRqstFrGrnt.Rows[0]["RFG_FILENAME"].ToString();


                string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();
                string strImage;
                if (strFileExt == "gif" || strFileExt == "png" || strFileExt == "bmp" || strFileExt == "jpeg" || strFileExt == "jpg")
                {

                    strImage = "<a style=\"font-family: Calibri;font-size:13px;margin-left: -311px;\" class=\"lightbox\" href=\"#goofy\" >Click to View Attachment Uploaded</a>";
                    strImage += " <div class=\"lightbox-target\" id=\"goofy\">";
                    strImage += " <img src=\"" + strImagePath + "\"/>";
                    strImage += " <a class=\"lightbox-close\" href=\"#\"></a>";
                    strImage += "</div>";

                }
                else
                {
                    strImage = "<a style=\"font-family: Calibri;font-size:13px;margin-left: -311px;\" href=\"" + strImagePath + "\" target=\"blank\" >Click to View Attachment Uploaded</a>";
                }
                divImageDisplay.InnerHtml = strImage;
            }

            int intRFQStatus = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["RFQ_STATUS"]);
            if (intRFQStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "101")
            {
                radioOpen.Checked = true;
            }
            else if (dtRqstFrGrnt.Rows[0]["GUARNTYPE_ID"].ToString() == "102")
            {
                radioLimited.Checked = true;
            }
            string dtBnkGurnt = "";
            dtBnkGurnt = ObjBussinessRequest.ReadBankGuranteeById(ObjEntityRequest);
            if (dtBnkGurnt != "0")
            {
                BankGurntChck = 1;
            }

            if (hiddenRoleReOpen.Value != "")
            {
                if (hiddenRoleReOpen.Value == "1")
                {
                    if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "2")
                    {
                        if (BankGurntChck != 1)
                        {
                            imgbtnReOpen.Visible = true;
                        }
                    }
                }
            }
            string LastModDate = "", LastModUser = "", LastModStatus = "";
            ObjEntityRequest.Guarantee_Status = Convert.ToInt32(dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString());
            DataTable dtRqstStatus = ObjBussinessRequest.ReadRFGStatusdtails(ObjEntityRequest);
            if (dtRqstStatus.Rows.Count > 0)
            {
                if (dtRqstStatus.Rows[0]["RFQ_DATE"].ToString() != "")
                {

                    LMDate.InnerText = dtRqstStatus.Rows[0]["RFQ_DATE"].ToString();
                }
                LMUser.InnerText = dtRqstStatus.Rows[0]["USR_NAME"].ToString();
                LMStatus.InnerText = dtRqstStatus.Rows[0]["STATUS"].ToString();
            }


            if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "1" || dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "6")
            {
                Butproceed.Visible = true;
            }
            if (dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "2" || dtRqstFrGrnt.Rows[0]["RFQ_GRNTY_STATUS"].ToString() == "3")
            {

                hiddenConfirmOrNot.Value = "1";
                txtCntctMail.Enabled = false;
                cbxStatus.Enabled = false;
                cbxExistingEmployee.Enabled = false;
                txtRemarks.Enabled = false;
                txtPrjctClsngDate.Enabled = false;
                txtInFavrOf.Enabled = false;
                txtEmpName.Enabled = false;
                txtAmount.Enabled = false;
                txtValidity.Enabled = false;
                ddlProject.Enabled = false;
                ddlJobCategory.Enabled = false;
                ddlGuaranteCat.Enabled = false;
                ddlExistingEmp.Enabled = false;
                ddlCustomer.Enabled = false;
                ddlCurrency.Enabled = false;
                radioOpen.Disabled = true;
                radioLimited.Disabled = true;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                FileUploadRecharge.Enabled = false;
                btnNewProject.Enabled = false;
                btnNewCategory.Enabled = false;
                btnNewCust.Enabled = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "disablingCancel", "disablingCancel();", true);
            }
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

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null || Request.QueryString["ViewId"] != null)
        {

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

            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                ObjEntityRequest.Guarantee_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                ObjEntityRequest.Guarantee_Status = 0;
            }
            string strRandomMixedId = "";
            if (Request.QueryString["Id"] != null)
            {
                strRandomMixedId = Request.QueryString["Id"].ToString();
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                strRandomMixedId = Request.QueryString["ViewId"].ToString();
            }

            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);

            ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strReqForIdId);

            ObjEntityRequest.Amount = Convert.ToDecimal(txtAmount.Text.ToUpper().Trim());
            if (txtValidity.Text.ToUpper().Trim() != "")
            {
                ObjEntityRequest.Validity = Convert.ToInt32(txtValidity.Text.ToUpper().Trim());
            }
            ObjEntityRequest.ProjCloseDate = objCommon.textToDateTime(txtPrjctClsngDate.Text.Trim());
            if (txtInFavrOf.Text.Trim() != "")
            {
                ObjEntityRequest.InFavrOf = txtInFavrOf.Text.Trim();
            }

            if (txtCntctMail.Text.Trim() != "")
            {
                ObjEntityRequest.ContactMail = txtCntctMail.Text.Trim();
            }
            if (txtRemarks.Text.Trim() != "")
            {
                ObjEntityRequest.Remarks = txtRemarks.Text.Trim();
            }

            if (cbxExistingEmployee.Checked == true)
            {
                if (ddlExistingEmp.SelectedItem.Value != "--SELECT EMPLOYEE--")
                {
                    ObjEntityRequest.EmployeId = Convert.ToInt32(ddlExistingEmp.SelectedItem.Value);
                }
            }
            else
            {
                ObjEntityRequest.ContactName = txtEmpName.Text.Trim();
            }

            if (radioOpen.Checked == true)
            {
                ObjEntityRequest.GuarTypeId = 101;
            }
            else if (radioLimited.Checked == true)
            {
                ObjEntityRequest.GuarTypeId = 102;
            }
            if (ddlProject.SelectedItem.Value != "--SELECT PROJECT--")
            {
                ObjEntityRequest.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            }
            if (hiddenGuantCat.Value != "--SELECT CATEGORY--")
            {
                ObjEntityRequest.GuarCatId = Convert.ToInt32(hiddenGuantCat.Value);
            }
            if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
            {
                ObjEntityRequest.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            }
            if (ddlCustomer.SelectedItem.Value != "--SELECT CUSTOMER--")
            {
                ObjEntityRequest.CustomerId = Convert.ToInt32(ddlCustomer.SelectedItem.Value);
            }
            if (ddlJobCategory.SelectedItem.Value != "--SELECT JOB CATEGORY--")
            {
                ObjEntityRequest.JobCat_Id = Convert.ToInt32(ddlJobCategory.SelectedItem.Value);
            }

            if (Session["USERID"] != null)
            {
                ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityRequest.D_Date = System.DateTime.Now;

            int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
            string strImgPath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.REQUEST_FOR_GUARANTEE);
            if (FileUploadRecharge.HasFile)
            {
                // GET FILE EXTENSION

                string strFileExt;
                ObjEntityRequest.FileNameAct = FileUploadRecharge.FileName;
                strFileExt = FileUploadRecharge.FileName.Substring(FileUploadRecharge.FileName.LastIndexOf('.') + 1).ToLower();

                string strImageName = intImageSection.ToString() + "_" + ObjEntityRequest.ReqForGuarId + "." + strFileExt;
                ObjEntityRequest.FileName = strImageName;


            }
            else
            {

                if (hiddenRechargeFile.Value == "")
                {
                    ObjEntityRequest.FileName = "";
                    ObjEntityRequest.FileNameAct = "";

                }
                else
                {
                    ObjEntityRequest.FileName = hiddenRechargeFile.Value;
                    ObjEntityRequest.FileNameAct = hiddenRechargeFileAct.Value;
                }
            }
            ObjBussinessRequest.UpdateRqstForGuarantee(ObjEntityRequest);
            if (FileUploadRecharge.HasFile)
            {
                if (hiddenRechargeFileDeleted.Value != "")
                {
                    string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                    if (File.Exists(MapPath(imageLocation)))
                    {
                        File.Delete(MapPath(imageLocation));
                    }
                }
                FileUploadRecharge.SaveAs(Server.MapPath(strImgPath) + ObjEntityRequest.FileName);
            }
            else
            {
                if (hiddenRechargeFile.Value == "")
                {
                    if (hiddenRechargeFileDeleted.Value != "")
                    {
                        string imageLocation = strImgPath + hiddenRechargeFileDeleted.Value;
                        if (File.Exists(MapPath(imageLocation)))
                        {
                            File.Delete(MapPath(imageLocation));
                        }
                    }
                }
            }
            //EVM-0016
            ObjBussinessRequest.ConfirmRequest(ObjEntityRequest);
            //REDIRECT TO UPDATE VIEW 
            List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
            objEntityCommon.RedirectUrl = "gen_Request_For_Guarantee.aspx";
            clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
            objEntityQueryString.QueryString = "InsUpd";
            objEntityQueryString.QueryStringValue = "Cnfrm";
            objEntityQueryString.Encrypt = 0;
            objEntityQueryStringList.Add(objEntityQueryString);
            objEntityQueryString = new clsEntityQueryString();
            objEntityQueryString.QueryString = "ViewId";
            objEntityQueryString.QueryStringValue = ObjEntityRequest.ReqForGuarId.ToString();
            objEntityQueryString.Encrypt = 1;
            objEntityQueryStringList.Add(objEntityQueryString);
            string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
            Response.Redirect(strRedirectUrl);

            //if (hiddenRoleAdd.Value.ToString() != "")
            //{
            //    if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            //    {
            //        Response.Redirect("gen_Request_For_Guarantee.aspx?InsUpd=Cnfrm");
            //    }
            //    else
            //    {
            //        Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Cnfrm");
            //    }

            //}

        }
    }
    protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        Button clickedButton = sender as Button;

        if (Request.QueryString["Id"] != null)
        {

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
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strReqForIdId = strRandomMixedId.Substring(2, intLenghtofId);

            ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strReqForIdId);
            if (Session["USERID"] != null)
            {
                ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            ObjEntityRequest.D_Date = System.DateTime.Now;

            ObjBussinessRequest.ReOpenRequest(ObjEntityRequest);


            if (hiddenRoleAdd.Value.ToString() != "")
            {
                if (Convert.ToInt32(hiddenRoleAdd.Value.ToString()) == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    Response.Redirect("gen_Request_For_Guarantee.aspx?InsUpd=ReOpen");
                }
                else
                {
                    Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=ReOpen");
                }

            }

        }
    }

    protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        string RequestId = "";
        if (Request.QueryString["Id"] != null)
        {
            RequestId = Request.QueryString["Id"].ToString();
        }

        Response.Redirect("gen_Request_For_Guarantee.aspx?Close=" + RequestId + "");
    }
    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        if (Request.QueryString["Close"] != null && Request.QueryString["Close"] != "")
        {//when Canceled


            string strRandomMixedId = Request.QueryString["Close"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);

            ObjEntityRequest.ReqForGuarId = Convert.ToInt32(strId);
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntityRequest.D_Date = System.DateTime.Now;
        ObjEntityRequest.Cancel_reason = txtCnclReason.Text.Trim();

        ObjBussinessRequest.CloseRequest(ObjEntityRequest);

        Response.Redirect("gen_Request_For_Guarantee_List.aspx?InsUpd=Cls");
    }
    protected void btnNewCust_Click(object sender, EventArgs e)
    {
        CustomerLoad();
        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewCust")
        {
            string strCustid = hiddenNewCustId.Value;
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelCustomerLoad", "UpdatePanelCustomerLoad(" + strCustid + ");", true);
        }
    }
    protected void btnNewProject_Click(object sender, EventArgs e)
    {
        ProjectLoad();
        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewProject")
        {
            string strProjectid = hiddenNewProjectId.Value;
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelProjectLoad", "UpdatePanelProjectLoad(" + strProjectid + ");", true);
        }

    }

    protected void btnNewCategory_Click(object sender, EventArgs e)
    {
        CategryLoad();
        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewCategory")
        {
            string strCatId = HiddenCategryId.Value;
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelCategoryLoad", "UpdatePanelCategoryLoad(" + strCatId + ");", true);
        }
    }
    [WebMethod]
    public static string CheckProjctAwdOrBiddg(string prjctId, string CorpId, string OrgId)
    {
        classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        ObjEntityRequest.ProjectId = Convert.ToInt32(prjctId);
        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(CorpId);
        ObjEntityRequest.Organisation_Id = Convert.ToInt32(OrgId);
        string strchk, strBiddg = "0";
        strchk = ObjBussinessRequest.ChkAwardedBiding(ObjEntityRequest);
        if (strchk != "" && strchk != "0")
        {
            strBiddg = "1";
        }
        return strBiddg;
    }

    [WebMethod]
    public static string ChangeToReissue(string CatId, string UserId, string Reason)
    {
        classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
        string strRet = "success";


        ObjEntityRequest.Guarantee_Status = 6;
        ObjEntityRequest.User_Id = Convert.ToInt32(UserId);
        ObjEntityRequest.ReqForGuarId = Convert.ToInt32(CatId);
        ObjEntityRequest.Cancel_reason = Reason;
        try
        {
            ObjBussinessRequest.ChangeToReissue(ObjEntityRequest);
        }
        catch
        {
            strRet = "failed";
        }
        return strRet;
    }
    public class ConvrtDataTable
    {

        public string strPrintReport = "";
        public string strhtml = "";
        public string strPrintCap = "";


        public string ConvertDataTableToHTML(DataTable dt, string RfqId, string varOrgId, string varCorpId)
        {
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
            classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
            ObjEntityRequest.ReqForGuarId = Convert.ToInt32(RfqId);
            string Rfq_Status = dt.Rows[0]["RFQ_STATUS"].ToString();
            ObjEntityRequest.Guarantee_Status = Convert.ToInt32(Rfq_Status);
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(varOrgId);
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(varCorpId);
            DataTable dtSts;
            dtSts = ObjBussinessRequest.ReadRFGStatusdtails(ObjEntityRequest);
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            StringBuilder sb = new StringBuilder();
            string strHtml = "";

            strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";



            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"main_table_head\">";


            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";


            if (dt.Columns.Count > 0)
            {
                strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">DATE & TIME</th>";

                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">USER</th>";

                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: center; word-wrap:break-word;\">PREVIOUS STATUS</th>";

                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: center; word-wrap:break-word;\">MODIFIED STATUS</th>";

            }

            strHtml += "</tr>";
            strHtml += "</thead>";
            //add rows

            strHtml += "<tbody>";
            int intRowCount = dt.Rows.Count;
            intRowCount--;
            string Singlestatus = "0";
            int count = 1;
            int srlno = 1;
            int rownum = 0;
            string strGurntStatusCHK = "";
            strGurntStatusCHK = "";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strGurntStatus = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                if (strGurntStatusCHK != dt.Rows[intRowBodyCount]["STATUS"].ToString())
                {
                    if (strGurntStatus == "Pending")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["PEND_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PEND_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                       

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                        // continue;
                    }
                    else if (strGurntStatus == "Confirmed")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();
                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_CONFIRM_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CON_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                        

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Approved")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["GUARANTEE_CNFRM_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["APPR_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                       

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Closed")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        count++;
                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_CLOSE_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CLOS_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                       

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Proceed")
                    {

                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();


                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_PROCEED_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROC_NAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                       

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Reissue")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_REISSUE_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["REIS_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                      //  strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["REIS_UNAME"].ToString() + "</td>";

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    if (intRowBodyCount == intRowCount)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSts.Rows[0]["STATUS"].ToString() + "</td>";

                    }


                    strHtml += "</tr>";


                }

            }


            strHtml += "</tbody>";

            strHtml += "</table>";

            sb.Append(strHtml);
            return sb.ToString();

        }
        public string PrintCaption(DataTable dtCorp)
        {
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strTitle = "";
            strTitle = "Request For Guarantee History";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");

            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
            }



            clsCommonLibrary objClsCommon = new clsCommonLibrary();
            string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

            StringBuilder sbCap = new StringBuilder();

            string strCaptionTabRprtDate = "", strCaptionTabTitle = "";

            string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
            string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
            string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";


            if (dat != "")
            {
                strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
            }
            if (strTitle != "")
            {
                strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
            }

            string strCaptionTabstop = "</table>";
            string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabTitle + strCaptionTabstop;



            sbCap.Append(strPrintCaptionTable);

            return sbCap.ToString();
        }
        public string ConvertDataTableForPrint(DataTable dt, DataTable dtCorp, string RfqId, string varOrgId, string varCorpId)
        {

            clsEntityCommon objEntityCommon = new clsEntityCommon();

            string strCompanyName = "", strCompanyAddr1 = "", strCompanyAddr2 = "", strCompanyAddr3 = "", strCompanyAddrCntry = "";
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            string strTitle = "";
            strTitle = "Request For Guarantee History";
            DateTime datetm = DateTime.Now;
            string dat = "<B>Report Date: </B>" + datetm.ToString("R");

            string strHidden = "", GuaranteDivsn = "", GuaranteCatgry = "";
            clsCommonLibrary objCommon = new clsCommonLibrary();

            if (dtCorp.Rows.Count > 0)
            {
                strCompanyName = dtCorp.Rows[0]["CORPRT_NAME"].ToString();
                strCompanyAddr1 = dtCorp.Rows[0]["CORPRT_ADDR1"].ToString();
                strCompanyAddr2 = dtCorp.Rows[0]["CORPRT_ADDR2"].ToString();
                strCompanyAddr3 = dtCorp.Rows[0]["CORPRT_ADDR3"].ToString();
                strCompanyAddrCntry = dtCorp.Rows[0]["CNTRY_NAME"].ToString();
            }



            clsCommonLibrary objClsCommon = new clsCommonLibrary();
            string strCompanyAddr = objClsCommon.FrmtCrprt_Addr(strCompanyAddr1, strCompanyAddr2, strCompanyAddr3, strCompanyAddrCntry);

            StringBuilder sbCap = new StringBuilder();



            string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
            string strCaptionTabCompanyNameRow = "<tr><td class=\"CompanyName\">" + strCompanyName + "</td></tr>";
            string strCaptionTabCompanyAddrRow = "<tr><td class=\"CompanyAddr\">" + strCompanyAddr1 + "</td></tr>";
            string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strGuaranteDivsn = "", strGuaranteCatgry = "";
            if (dat != "")
            {
                strCaptionTabRprtDate = "<tr><td class=\"RprtDate\">" + dat + "</td></tr>";
            }
            if (strTitle != "")
            {
                strCaptionTabTitle = "<tr><td class=\"CapTitle\">" + strTitle + "</td></tr>";
            }
            string strCaptionTabstop = "</table>";
            string strPrintCaptionTable = strCaptionTabstart + strCaptionTabCompanyNameRow + strCaptionTabCompanyAddrRow + strCaptionTabRprtDate + strCaptionTabstop;



            sbCap.Append(strPrintCaptionTable);

            classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
            classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();
            ObjEntityRequest.ReqForGuarId = Convert.ToInt32(RfqId);
            string Rfq_Status = dt.Rows[0]["RFQ_STATUS"].ToString();
            ObjEntityRequest.Guarantee_Status = Convert.ToInt32(Rfq_Status);
            ObjEntityRequest.Organisation_Id = Convert.ToInt32(varOrgId);
            ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(varCorpId);
            DataTable dtSts;
            dtSts = ObjBussinessRequest.ReadRFGStatusdtails(ObjEntityRequest);


            StringBuilder sb = new StringBuilder();
            string strHtml = "<table id=\"PrintTable\" class=\"tab\"  >";
            //add header row
            strHtml += "<thead>";
            strHtml += "<tr class=\"top_row\">";
            strHtml += "<th class=\"thT\" style=\"width:4%;text-align: left; word-wrap:break-word;\">SL#</th>";
            if (dt.Columns.Count > 0)
            {

                strHtml += "<th class=\"thT\" style=\"width:24%;text-align: left; word-wrap:break-word;\">DATE & TIME</th>";

                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: left; word-wrap:break-word;\">USER</th>";

                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: center; word-wrap:break-word;\">PREVIOUS STATUS</th>";

                strHtml += "<th class=\"thT\"  style=\"width:24%;text-align: center; word-wrap:break-word;\">MODIFIED STATUS</th>";

            }

            strHtml += "</tr>";
            strHtml += "</thead>";

            //add rows

            strHtml += "<tbody>";

            int intRowCount = dt.Rows.Count;
            intRowCount--;
            string Singlestatus = "0";
            int count = 1;
            int srlno = 1;
            int rownum = 0;
            string strGurntStatusCHK = "";
            strGurntStatusCHK = "";
            for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
            {
                string strGurntStatus = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                if (strGurntStatusCHK != dt.Rows[intRowBodyCount]["STATUS"].ToString())
                {
                    if (strGurntStatus == "Pending")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["PEND_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PEND_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();
                        // continue;
                    }
                    else if (strGurntStatus == "Confirmed")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();
                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_CONFIRM_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CON_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Approved")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["GUARANTEE_CNFRM_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["APPR_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Closed")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        count++;
                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_CLOSE_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["CLOS_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Proceed")
                    {

                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();


                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_PROCEED_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["PROC_NAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }


                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    else if (strGurntStatus == "Reissue")
                    {
                        if (strGurntStatusCHK == "")
                            strGurntStatusCHK = dt.Rows[0]["STATUS"].ToString();

                        strHtml += "<tr  >";
                        strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + srlno.ToString() + "</td>";
                        srlno++;
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount + 1]["RFQBP_REISSUE_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["REIS_UNAME"].ToString() + "</td>";
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["RFQ_DATE"].ToString() + "</td>";
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtSts.Rows[0]["USR_NAME"].ToString() + "</td>";
                        }
                        //  strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dt.Rows[intRowBodyCount]["REIS_UNAME"].ToString() + "</td>";

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount]["STATUS"].ToString() + "</td>";
                        if (intRowBodyCount < intRowCount)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dt.Rows[intRowBodyCount + 1]["STATUS"].ToString() + "</td>";
                        }

                        strGurntStatusCHK = dt.Rows[intRowBodyCount]["STATUS"].ToString();

                    }
                    if (intRowBodyCount == intRowCount)
                    {

                        strHtml += "<td class=\"tdT\" style=\" width:24%;word-break: break-all; word-wrap:break-word;text-align: center;\" >" + dtSts.Rows[0]["STATUS"].ToString() + "</td>";

                    }


                    strHtml += "</tr>";


                }

            }

            strHtml += "</tbody>";

            strHtml += "</table>";


            sb.Append(strHtml);
            return sb.ToString();

        }
    }

    [WebMethod]
    public static ConvrtDataTable HistoryList(string RfqId, string varOrgId, string varCorpId, string varUserId)
    {
        classBusinessLayerRequestForGrnte ObjBussinessRequest = new classBusinessLayerRequestForGrnte();
        classEntityLayerRequestForGrnte ObjEntityRequest = new classEntityLayerRequestForGrnte();

        clsBusinessLayerGmsReports objBusinessLayerReports = new clsBusinessLayerGmsReports();
        clsEntityReports objEntityReports = new clsEntityReports();

        ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        objEntityReports.Corporate_Id = Convert.ToInt32(varCorpId);
        objEntityReports.Organisation_Id = Convert.ToInt32(varOrgId);
        // ConvrtDataTable objConvrtDataTable = new ConvrtDataTable();
        ObjEntityRequest.ReqForGuarId = Convert.ToInt32(RfqId);
        ObjEntityRequest.Organisation_Id = Convert.ToInt32(varOrgId);
        ObjEntityRequest.CorpOffice_Id = Convert.ToInt32(varCorpId);
        ObjEntityRequest.User_Id = Convert.ToInt32(varUserId);
        // string strhtml;
        DataTable dtCorp = objBusinessLayerReports.Read_Corp_Details(objEntityReports);

        DataTable dt;
        dt = ObjBussinessRequest.HistoryList(ObjEntityRequest);
        if (dt.Rows.Count > 0)
        {
            objConvrtDataTable.strhtml = objConvrtDataTable.ConvertDataTableToHTML(dt, RfqId, varOrgId, varCorpId);
            objConvrtDataTable.strPrintReport = objConvrtDataTable.ConvertDataTableForPrint(dt, dtCorp, RfqId, varOrgId, varCorpId);
            objConvrtDataTable.strPrintCap = objConvrtDataTable.PrintCaption(dtCorp);
        }
        else
        {
            objConvrtDataTable.strhtml = "";
        }
        return objConvrtDataTable;
    }

   
    protected void Butproceed_Click(object sender, EventArgs e)
    {
      

       

        
        
    }
}