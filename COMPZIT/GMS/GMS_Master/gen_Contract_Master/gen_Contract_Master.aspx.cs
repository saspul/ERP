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
using System.Web.Services;
using System.Collections;
using System.Collections.Generic;
// CREATED BY:EVM-0005
// CREATED DATE:7/1/2017
// REVIEWED BY:
// REVIEW DATE:

public partial class GMS_GMS_Master_gen_Contract_Master_gen_Contract_Master : System.Web.UI.Page
{
    classBusinessLayerContractMaster ObjBusinessContract = new classBusinessLayerContractMaster();
    //evm-0012 Adding Contracts
    protected void Page_PreInit(object sender, EventArgs e)
    {

        if (Request.QueryString["RFGP"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPage_Compzit_GMS.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtContractName.Attributes.Add("onkeypress", "return isTag(event)");
        txtContractName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtContractCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtContractCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlProject.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlContractType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlExistingCntrctr.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlJobCtgry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlParentCntrct.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlProject.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlContractType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingCntrctr.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlJobCtgry.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlParentCntrct.Attributes.Add("onkeypress", "return DisableEnter(event)");

        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        if (!IsPostBack)
        {

            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
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

            ParentContractLoad();
            ContractorLoad();
            JobCategoryLoad();
            ContractCategoryLoad();
            ProjectLoad();

            btnAddNext.Visible = false;
            btnSkip.Visible = false;
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.Text = "Edit Contract";

            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId, intCorpId);

                lblEntry.Text = "View Contract";
            }
            else
            {
                
                lblEntry.Text = "Add Contract";


                clsEntityCommon objEntityCommon = new clsEntityCommon();

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CONTRACT);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                string year = DateTime.Today.Year.ToString();

                lblRefNumber.Text = "CNTRCT/" + year + "/" + strNextId;

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;
               



                if (Session["USERID"] != null)
                {
                    intUserId = Convert.ToInt32(Session["USERID"]);

                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                //Allocating child roles
                int intUsrRolMstrIdCntrct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
                DataTable dtChildRolCntrct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCntrct);
                btnAddNext.Visible = false;
                if (dtChildRolCntrct.Rows.Count > 0)
                {
                    string strChildRolDeftn = dtChildRolCntrct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                    foreach (string strC_Role in strChildDefArrWords)
                    {
                        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                        {
                            btnAddNext.Visible = true;

                        }

                    }
                }
                //evm-0012 Adding Contracts
                if (Request.QueryString["RFGP"] != null)
                {
                    divList.Visible = false;
                    btnNewCust.Visible = false;
                    btnCancel.Visible = false;
                    btnAddClose.Visible = false;
                    btnAddNext.Visible = false;
                    btnClear.Visible = false;
                    btnAdd.Text="Save & Close";
                    btnCloseWindow.Visible = true;
                }
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
                else if (strInsUpd == "PrjIns")
                {
                    btnSkip.Visible = true;
                    btnAddNext.Visible = true;
                    btnAddClose.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationPrj", "SuccessConfirmationPrj();", true);
                }
                else if (strInsUpd == "PrjUpd")
                {
                    btnSkip.Visible = true;
                    btnAddNext.Visible = true;
                    btnAddClose.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdationPrj", "SuccessUpdationPrj();", true);
                }
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);
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

                }
            }

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                btnUpdate.Visible = false;
            }

            clsBusinessLayer objBusinessLayerCommn = new clsBusinessLayer();
            int intUsrRolMstrIdCust, intAddCust = 0;

            //Allocating child roles
            intUsrRolMstrIdCust = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Customer_Master);
            DataTable dtChildRolCust = objBusinessLayerCommn.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCust);

            if (dtChildRolCust.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRolCust.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAddCust = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    }


                }

            }
            if (intAddCust == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {
                btnNewCust.Visible = false;
            }





        }
    }
    public void ProjectLoad()
    {

        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityCntrct.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtProject = ObjBusinessContract.ReadProjects(objEntityCntrct);
        if (dtProject.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProject;
            ddlProject.DataTextField = "PROJECT_NAME";
            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();

        }

        ddlProject.Items.Insert(0, "--SELECT PROJECT--");
    }
    public void ContractCategoryLoad()
    {

        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["USERID"] != null)
        {
            objEntityCntrct.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        DataTable dtContract = ObjBusinessContract.ReadContractCategory(objEntityCntrct);
        if (dtContract.Rows.Count > 0)
        {
            ddlContractType.DataSource = dtContract;
            ddlContractType.DataTextField = "CNTRCTYPE_NAME";
            ddlContractType.DataValueField = "CNTRCTYPE_ID";
            ddlContractType.DataBind();

        }
        ddlContractType.Items.Insert(0, "--SELECT CONTRACT CATEGORY--");

    }
    public void JobCategoryLoad()
    {

        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtCategory = ObjBusinessContract.ReadJobCategory(objEntityCntrct);
        if (dtCategory.Rows.Count > 0)
        {
            ddlJobCtgry.DataSource = dtCategory;
            ddlJobCtgry.DataTextField = "JOBCTGRY_NAME";
            ddlJobCtgry.DataValueField = "JOBCTGRY_ID";
            ddlJobCtgry.DataBind();

        }

        ddlJobCtgry.Items.Insert(0, "--SELECT JOB CATEGORY--");
    }

    public void ContractorLoad()
    {

        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        DataTable dtExistingCustomer = ObjBusinessContract.ReadContractor(objEntityCntrct);
        if (dtExistingCustomer.Rows.Count > 0)
        {
            ddlExistingCntrctr.DataSource = dtExistingCustomer;
            ddlExistingCntrctr.DataTextField = "CSTMR_NAME";
            ddlExistingCntrctr.DataValueField = "CSTMR_ID";
            ddlExistingCntrctr.DataBind();

        }
        ddlExistingCntrctr.Items.Insert(0, "--SELECT CONTRACTOR--");

    }
    public void ParentContractLoad()
    {

        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCntrct.CntrctId = Convert.ToInt32(strId);
        }
        else
        {
            objEntityCntrct.CntrctId = 0;
        }
        DataTable dtExistingCustomer = ObjBusinessContract.ReadParentContract(objEntityCntrct);
        if (dtExistingCustomer.Rows.Count > 0)
        {
            ddlParentCntrct.DataSource = dtExistingCustomer;
            ddlParentCntrct.DataTextField = "CNTRCT_NAME";
            ddlParentCntrct.DataValueField = "CNTRCT_ID";
            ddlParentCntrct.DataBind();

        }
        ddlParentCntrct.Items.Insert(0, "--SELECT CONTRACT--");

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();
        if (Request.QueryString["Id"] != null)
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityCntrct.Contract_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityCntrct.Contract_Status = 0;
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strContractId = strRandomMixedId.Substring(2, intLenghtofId);

            objEntityCntrct.CntrctId = Convert.ToInt32(strContractId);
            objEntityCntrct.Sub_Cntrct_Name = txtContractName.Text.ToUpper().Trim();
            objEntityCntrct.Sub_CntrctCode = txtContractCode.Text.ToUpper().Trim();
            objEntityCntrct.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
            objEntityCntrct.CntrctCatId = Convert.ToInt32(ddlContractType.SelectedItem.Value);
            objEntityCntrct.JobCat_Id = Convert.ToInt32(ddlJobCtgry.SelectedItem.Value);
            objEntityCntrct.SubCntrctrId = Convert.ToInt32(ddlExistingCntrctr.SelectedItem.Value);

            if (ddlParentCntrct.SelectedItem.Value != "--SELECT CONTRACT--")
            {
                objEntityCntrct.Parnt_SubCntrct_Id = Convert.ToInt32(ddlParentCntrct.SelectedItem.Value);
            }
            else
            {
                objEntityCntrct.Parnt_SubCntrct_Id = 0;
            }

            if (Session["USERID"] != null)
            {
                objEntityCntrct.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }


            objEntityCntrct.D_Date = System.DateTime.Now;

            //Checking is there table have any name like this
            string strNameCount = ObjBusinessContract.CheckContractName(objEntityCntrct);
            string strCodeCount = ObjBusinessContract.CheckContractCode(objEntityCntrct);
            //If there is no name like this on table.    
            if (strNameCount == "0" && strCodeCount == "0")
            {
                ObjBusinessContract.UpdateContract(objEntityCntrct);
                if (clickedButton.ID == "btnUpdate")
                {
                    //REDIRECT TO UPDATE VIEW 
                    List<clsEntityQueryString> objEntityQueryStringList = new List<clsEntityQueryString>();
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                    objEntityCommon.RedirectUrl = "gen_Contract_Master.aspx";
                    clsEntityQueryString objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "InsUpd";
                    objEntityQueryString.QueryStringValue = "Upd";
                    objEntityQueryString.Encrypt = 0;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    objEntityQueryString = new clsEntityQueryString();
                    objEntityQueryString.QueryString = "Id";
                    objEntityQueryString.QueryStringValue = strContractId;
                    objEntityQueryString.Encrypt = 1;
                    objEntityQueryStringList.Add(objEntityQueryString);
                    string strRedirectUrl = objBusinessLayer.RedirectToUpdateView(objEntityCommon, objEntityQueryStringList);
                    Response.Redirect(strRedirectUrl);

                   // Response.Redirect("gen_Contract_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Upd");
                }


            }
            //If have
            else
            {
                if (strNameCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtContractName.Focus();
                }
                else if (strCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                    txtContractCode.Focus();
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCntrct.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCntrct.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityCntrct.Contract_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityCntrct.Contract_Status = 0;
        }
        objEntityCntrct.RefNumber = lblRefNumber.Text.Trim();
        objEntityCntrct.Sub_Cntrct_Name = txtContractName.Text.ToUpper().Trim();
        objEntityCntrct.Sub_CntrctCode = txtContractCode.Text.ToUpper().Trim();
        objEntityCntrct.ProjectId = Convert.ToInt32(ddlProject.SelectedItem.Value);
        objEntityCntrct.CntrctCatId = Convert.ToInt32(ddlContractType.SelectedItem.Value);
        objEntityCntrct.JobCat_Id = Convert.ToInt32(ddlJobCtgry.SelectedItem.Value);
        objEntityCntrct.SubCntrctrId = Convert.ToInt32(ddlExistingCntrctr.SelectedItem.Value);

        if (ddlParentCntrct.SelectedItem.Value != "--SELECT CONTRACT--")
        {
            objEntityCntrct.Parnt_SubCntrct_Id = Convert.ToInt32(ddlParentCntrct.SelectedItem.Value);
        }

        if (Session["USERID"] != null)
        {
            objEntityCntrct.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }


        objEntityCntrct.D_Date = System.DateTime.Now;

        //Checking is there table have any name like this
        string strNameCount = ObjBusinessContract.CheckContractName(objEntityCntrct);
        string strCodeCount = ObjBusinessContract.CheckContractCode(objEntityCntrct);
        //If there is no name like this on table.    
        if (strNameCount == "0" && strCodeCount == "0")
        {
            //evm-0012 Adding Contracts
            string strContractId = "";
            strContractId=ObjBusinessContract.AddContract(objEntityCntrct);

            if (Request.QueryString["RFGP"] == "RFG")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedContractToRFG", "PassSavedContractToRFG(" + strContractId + ");", true);
            }
            else
            {
                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Contract_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Contract_Master_List.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddNext")
                {

                    Response.Redirect("/GMS/GMS_Master/gen_Bank_Guarantee/gen_Bank_Guarantee.aspx?InsUpd=CntrctIns");
                }
            }


        }
        //If have
        else
        {
            if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtContractName.Focus();
            }
            else if (strCodeCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCode", "DuplicationCode();", true);
                txtContractCode.Focus();
            }
        }
    }
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();
        objEntityCntrct.CntrctId = Convert.ToInt32(strP_Id);
        objEntityCntrct.CorpOffice_Id = intCorpId;
        DataTable dtCntrctId = ObjBusinessContract.ReadContractById(objEntityCntrct);
        if (dtCntrctId.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate
            txtContractName.Text = dtCntrctId.Rows[0]["CNTRCT_NAME"].ToString();
            txtContractCode.Text = dtCntrctId.Rows[0]["CNTRCT_CODE"].ToString();
            lblRefNumber.Text = dtCntrctId.Rows[0]["CNTRCT_REF_NUMBER"].ToString();
            if (dtCntrctId.Rows[0]["PROJECT_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == null)
            {
                ddlProject.Items.FindByValue(dtCntrctId.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["PROJECT_NAME"].ToString(), dtCntrctId.Rows[0]["PROJECT_ID"].ToString());
                ddlProject.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProject);

                ddlProject.Items.FindByValue(dtCntrctId.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }

            if (dtCntrctId.Rows[0]["CNTRCTYPE_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["CNTRCTYPE_CNCL_USR_ID"].ToString() == null)
            {
                ddlContractType.Items.FindByValue(dtCntrctId.Rows[0]["CNTRCTYPE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["CNTRCTYPE_NAME"].ToString(), dtCntrctId.Rows[0]["CNTRCTYPE_ID"].ToString());
                ddlContractType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlContractType);

                ddlContractType.Items.FindByValue(dtCntrctId.Rows[0]["CNTRCTYPE_ID"].ToString()).Selected = true;
            }

            if (dtCntrctId.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == null)
            {
                ddlExistingCntrctr.Items.FindByValue(dtCntrctId.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["CSTMR_NAME"].ToString(), dtCntrctId.Rows[0]["CSTMR_ID"].ToString());
                ddlExistingCntrctr.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlExistingCntrctr);

                ddlExistingCntrctr.Items.FindByValue(dtCntrctId.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
            }

            if (dtCntrctId.Rows[0]["JOBCTGRY_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["JOBCTGRY_CNCL_USR_ID"].ToString() == null)
            {
                ddlJobCtgry.Items.FindByValue(dtCntrctId.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["JOBCTGRY_NAME"].ToString(), dtCntrctId.Rows[0]["JOBCTGRY_ID"].ToString());
                ddlJobCtgry.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlJobCtgry);

                ddlJobCtgry.Items.FindByValue(dtCntrctId.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
            }
            if (dtCntrctId.Rows[0]["PARENT_ID"].ToString() != "" && dtCntrctId.Rows[0]["PARENT_ID"] != null)
            {
                if (dtCntrctId.Rows[0]["PARENT_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["PARENT_CNCL_USR_ID"].ToString() == null)
                {
                    ddlParentCntrct.Items.FindByValue(dtCntrctId.Rows[0]["PARENT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["PARENT_NAME"].ToString(), dtCntrctId.Rows[0]["PARENT_ID"].ToString());
                    ddlParentCntrct.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlParentCntrct);

                    ddlParentCntrct.Items.FindByValue(dtCntrctId.Rows[0]["PARENT_ID"].ToString()).Selected = true;
                }
            }

            int intContractStatus = Convert.ToInt32(dtCntrctId.Rows[0]["CNTRCT_STATUS"]);
            if (intContractStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }

        cbxStatus.Enabled = false;
        txtContractCode.Enabled = false;
        txtContractName.Enabled = false;
        ddlContractType.Enabled = false;
        ddlExistingCntrctr.Enabled = false;
        ddlJobCtgry.Enabled = false;
        ddlParentCntrct.Enabled = false;
        ddlProject.Enabled = false;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnAddNext.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        classEntityLayerContractMaster objEntityCntrct = new classEntityLayerContractMaster();
        objEntityCntrct.CntrctId = Convert.ToInt32(strP_Id);
        objEntityCntrct.CorpOffice_Id = intCorpId;
        DataTable dtCntrctId = ObjBusinessContract.ReadContractById(objEntityCntrct);
        if (dtCntrctId.Rows.Count > 0)
        {            //After fetch Deaprtment details in datatable,we need to differentiate
            txtContractName.Text = dtCntrctId.Rows[0]["CNTRCT_NAME"].ToString();
            txtContractCode.Text = dtCntrctId.Rows[0]["CNTRCT_CODE"].ToString();
            lblRefNumber.Text = dtCntrctId.Rows[0]["CNTRCT_REF_NUMBER"].ToString();
            if (dtCntrctId.Rows[0]["PROJECT_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == null)
            {
                ddlProject.Items.FindByValue(dtCntrctId.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["PROJECT_NAME"].ToString(), dtCntrctId.Rows[0]["PROJECT_ID"].ToString());
                ddlProject.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProject);

                ddlProject.Items.FindByValue(dtCntrctId.Rows[0]["PROJECT_ID"].ToString()).Selected = true;
            }

            if (dtCntrctId.Rows[0]["CNTRCTYPE_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["CNTRCTYPE_CNCL_USR_ID"].ToString() == null)
            {
                ddlContractType.Items.FindByValue(dtCntrctId.Rows[0]["CNTRCTYPE_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["CNTRCTYPE_NAME"].ToString(), dtCntrctId.Rows[0]["CNTRCTYPE_ID"].ToString());
                ddlContractType.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlContractType);

                ddlContractType.Items.FindByValue(dtCntrctId.Rows[0]["CNTRCTYPE_ID"].ToString()).Selected = true;
            }

            if (dtCntrctId.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == null)
            {
                ddlExistingCntrctr.Items.FindByValue(dtCntrctId.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["CSTMR_NAME"].ToString(), dtCntrctId.Rows[0]["CSTMR_ID"].ToString());
                ddlExistingCntrctr.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlExistingCntrctr);

                ddlExistingCntrctr.Items.FindByValue(dtCntrctId.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
            }

            if (dtCntrctId.Rows[0]["JOBCTGRY_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["JOBCTGRY_CNCL_USR_ID"].ToString() == null)
            {
                ddlJobCtgry.Items.FindByValue(dtCntrctId.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["JOBCTGRY_NAME"].ToString(), dtCntrctId.Rows[0]["JOBCTGRY_ID"].ToString());
                ddlJobCtgry.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlJobCtgry);

                ddlJobCtgry.Items.FindByValue(dtCntrctId.Rows[0]["JOBCTGRY_ID"].ToString()).Selected = true;
            }
            if (dtCntrctId.Rows[0]["PARENT_ID"].ToString() != "" && dtCntrctId.Rows[0]["PARENT_ID"] != null)
            {
                if (dtCntrctId.Rows[0]["PARENT_STATUS"].ToString() == "1" && dtCntrctId.Rows[0]["PARENT_CNCL_USR_ID"].ToString() == null)
                {
                    ddlParentCntrct.Items.FindByValue(dtCntrctId.Rows[0]["PARENT_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCntrctId.Rows[0]["PARENT_NAME"].ToString(), dtCntrctId.Rows[0]["PARENT_ID"].ToString());
                    ddlParentCntrct.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlParentCntrct);

                    ddlParentCntrct.Items.FindByValue(dtCntrctId.Rows[0]["PARENT_ID"].ToString()).Selected = true;
                }
            }

            int intContractStatus = Convert.ToInt32(dtCntrctId.Rows[0]["CNTRCT_STATUS"]);
            if (intContractStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
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
    protected void btnNewCust_Click(object sender, EventArgs e)
    {
        ContractorLoad();
        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewCust")
        {
            string strCustid = hiddenNewCustId.Value;
            //  string strCustid = Request["__EVENTARGUMENT"];
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelCustomerLoad", "UpdatePanelCustomerLoad(" + strCustid + ");", true);
        }
    }
    protected void btnSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("/GMS/GMS_Master/gen_Request_For_Guarantee/gen_Request_For_Guarantee.aspx");
    }
}