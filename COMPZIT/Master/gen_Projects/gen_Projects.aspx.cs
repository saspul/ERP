using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BL_Compzit;
using EL_Compzit;
using System.Text;
using CL_Compzit;
using System.Collections;
// CREATED BY:EVM-0001
// CREATED DATE:26/05/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Projects_gen_Projects : System.Web.UI.Page
{
    //Creating objects for businesslayer
    clsBusinesslayerProject objBusinessLayerProject = new clsBusinesslayerProject();

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["CFAM"] != null)
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";
    //    }
    //    else
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
    //    }
    //    if (Request.QueryString["PRFG"] != null)
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";
    //    }
    //    else
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions  .
        txtProjectName.Attributes.Add("onkeypress", "return isTag(event)");
        txtProjectName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtClientRefNUm.Attributes.Add("onkeypress", "return isTag(event)");
        txtClientRefNUm.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtContactMail.Attributes.Add("onkeypress", "return isTag(event)");
        txtContactMail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtContactPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtContactPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //txtCustName.Attributes.Add("onkeypress", "return isTag(event)");
       // txtCustName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmployeeName.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmployeeName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtInternalRefNum.Attributes.Add("onkeypress", "return isTag(event)");
        txtInternalRefNum.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTenderRFQ.Attributes.Add("onkeypress", "return isTag(event)");
        txtTenderRFQ.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxAwarded.Attributes.Add("onkeypress", "return DisableEnter(event)");
       // cbxExistingCustomer.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxExistingEmployee.Attributes.Add("onkeypress", "return DisableEnter(event)");

        ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlExistingCustomer.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlExistingEmployee.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlProjectManager.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlDivision.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingCustomer.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlExistingEmployee.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlProjectManager.Attributes.Add("onkeypress", "return DisableEnter(event)");


      
        if (!IsPostBack)
        {
            btnAddClose.Visible = false;
            btnAddCloseF.Visible = false;
            txtProjectName.Focus();
            ExistingCustomerLoad();
            ExistingEmployeeLoad();
            DivisionByUserLoad();
            cbxAwarded.Checked = false;
            hiddenEditMode.Value = "";
            btnClose.Visible = false;
            btnCloseF.Visible = false;
            LoadWarehouse();

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            int intCorpId = 0, intOrgId = 0, intUserId=0;
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
        
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            cbxExistingEmployee.Checked = true;
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId);
                lblEntry.InnerText = "Edit Project Master";
                lblEntryB.InnerText = "Edit Project Master";
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText = "View Project Master";
                lblEntryB.InnerText = "View Project Master";
                hiddenEditMode.Value = "view";

                btnClear.Visible = false;
                btnClearF.Visible = false;
            }

            else
            {
                lblEntry.InnerText = "Add Project Master";
                lblEntryB.InnerText = "Add Project Master";
                btnAddNext.Visible = false;
                btnAddNextF.Visible = false;
                //Allocating child roles
                int intUsrRolMstrIdCntrct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);
                DataTable dtChildRolCntrct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCntrct);
                btnUpdateNext.Visible = false;
                btnUpdateNextF.Visible = false;
                if (dtChildRolCntrct.Rows.Count > 0)
                {
                    string strChildRolDeftn = dtChildRolCntrct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                    string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                    foreach (string strC_Role in strChildDefArrWords)
                    {
                        if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                        {
                            btnAddNext.Visible = true;
                            btnAddNextF.Visible = true;
                        }

                    }
                }

                clsEntityCommon objEntityCommon = new clsEntityCommon();
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PROJECT);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                string year = DateTime.Today.Year.ToString();

                lblRefNumber.Value = "PRJCT/" + year + "/" + strNextId;

                btnUpdate.Visible = false;
                btnUpdateNext.Visible = false;
                btnAdd.Visible = true;
                btnAddNext.Visible = true;
                btnNewCust.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateNextF.Visible = false;
                btnAddF.Visible = true;
                btnAddNextF.Visible = true;
                if (Request.QueryString["CFAM"] != null)
                {
                    txtProjectName.Text = Request.QueryString["CFAM"].ToString().Trim().ToUpper();
                    //cbxExistingCustomer.Enabled = false;
                    btnNewCust.Visible = false;
                }
                if (Request.QueryString["CFBM"] != null)
                {
                    string strDiviId = Request.QueryString["CFBM"].ToString().Trim();
                    string[] split=strDiviId.Split('_');
                    int DiviId = Convert.ToInt32(split[0]);
                    DivisionByUserLoadFrmLead(DiviId);
                    btnNewCust.Visible = false;
                }
          
                if (Request.QueryString["CFCM"] != null && Request.QueryString["CFCM"] != "")
                {
                    string strCustId = Request.QueryString["CFCM"].ToString().Trim();
                    string[] split = strCustId.Split('=');
                    int CustId = Convert.ToInt32(split[0]);
                    ExistingCustomerLoadFrmLead(strCustId);
                    btnNewCust.Visible = false;
                }
                else 
                {
                    ExistingCustomerLoad();
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
                }
            }
            int  intUsrRolMstrId, intEnableAdd = 0;
           
            //Allocating child roles
            clsBusinessLayer objBusinessLayercmmn = new clsBusinessLayer();
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Project);
            DataTable dtChildRol = objBusinessLayercmmn.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
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
                btnUpdateF.Visible = false;
            }

            if (Request.QueryString["CFAM"] != null)
            {
                divList.Visible = false;
                btnAdd.Visible = false;
                btnCancel.Visible = false;
                btnAddF.Visible = false;
                btnCancelF.Visible = false;
                btnClear.Visible = false;
                btnClearF.Visible = false;
            }
            else
            {

                divList.Visible = true;
            }
        
            clsBusinessLayer objBusinessLayerCommn = new clsBusinessLayer();
            int intUsrRolMstrIdCust, intEnableAddCust=0;
           
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
                        intEnableAddCust = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }


                }

               

            }
            if (intEnableAddCust == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
             
                if (Request.QueryString["CFAM"] != null)
                {

                    btnNewCust.Visible = false;
                    btnAddNext.Visible = false;
                    btnAddClose.Visible = true;
                    btnAdd.Visible = true;
                    btnAddNextF.Visible = false;
                    btnAddCloseF.Visible = true;
                    btnAddF.Visible = true;
                }
                else
                {
                    btnNewCust.Visible = true;
                    
                }

            }
            else
            {
                btnNewCust.Visible = false;
                //btnNewCust.Visible = false;

            }


            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.PMS_CONTROLS_DISPLAY_STS,
                                                   };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                if (dtCorpDetail.Rows[0]["PMS_CONTROLS_DISPLAY_STS"].ToString() != "")
                {
                    hiddenPMSDisplaySts.Value = dtCorpDetail.Rows[0]["PMS_CONTROLS_DISPLAY_STS"].ToString();
                }
            }



        }

        if (Request.QueryString["PRFG"] != null)
        {
            divList.Visible = false;
            btnNewCust.Visible = false;
            btnAddNext.Visible = false;
            btnAddClose.Visible = true;
            btnAdd.Visible = false;
            btnCancel.Visible = false;
            btnAddNextF.Visible = false;
            btnAddCloseF.Visible = true;
            btnAddF.Visible = false;
            btnCancelF.Visible = false;
            btnClear.Visible = false;
            btnClearF.Visible = false;
            btnClose.Visible = true;
            btnCloseF.Visible = true;
            //this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "AutoCompleteEmp", "AutoCompleteEmp();", true);


        if (Request.QueryString["DivId"] != null)
        {
            string strDivId = Request.QueryString["DivId"].ToString();
            if (ddlDivision.Items.FindByValue(strDivId) != null)
            {
                ddlDivision.Items.FindByValue(strDivId).Selected = true;
                ddlDivision.Enabled = false;
                divList.Visible = false;
                btnNewCust.Visible = false;
                btnAddNext.Visible = false;
                btnAddClose.Visible = true;
                btnAdd.Visible = false;
                btnCancel.Visible = false;
                btnAddNextF.Visible = false;
                btnAddCloseF.Visible = true;
                btnAddF.Visible = false;
                btnCancelF.Visible = false;
                btnClear.Visible = false;
                btnClearF.Visible = false;
                btnClose.Visible = true;
                btnCloseF.Visible = true;
            }
        }

    }

    //Method for binding Existing Customer details to dropdown list.
    public void ExistingCustomerLoad()
    {
        clsEntityProject objEntityProject = new clsEntityProject();

            if (Session["CORPOFFICEID"] != null)
            {
                objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
   
            if (Session["ORGID"] != null)
            {
                objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

            DataTable dtExistingCustomer = objBusinessLayerProject.ReadExistingCustomer(objEntityProject);
            ddlExistingCustomer.Items.Clear();

            if (dtExistingCustomer.Rows.Count > 0)
            {
                ddlExistingCustomer.DataSource = dtExistingCustomer;
                ddlExistingCustomer.DataTextField = "CSTMR_NAME";
                ddlExistingCustomer.DataValueField = "CSTMR_ID";
                ddlExistingCustomer.DataBind();
                ddlExistingCustomer.Items.Insert(0, "--SELECT CUSTOMER--");
            }

    }



    public void ExistingCustomerLoadFrmLead(string strCustId)
    {
        clsEntityProject objEntityProject = new clsEntityProject();
        
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtExistingCustomer = objBusinessLayerProject.ReadExistingCustomer(objEntityProject);
        ddlExistingCustomer.Items.Clear();

        if (dtExistingCustomer.Rows.Count > 0)
        {
            
            ddlExistingCustomer.DataSource = dtExistingCustomer;
            ddlExistingCustomer.DataTextField = "CSTMR_NAME";
            ddlExistingCustomer.DataValueField = "CSTMR_ID";
            ddlExistingCustomer.DataBind();
            ddlExistingCustomer.SelectedValue = strCustId;
        }
           
   }


    //Method for binding Existing EMPLOYEE details to dropdown list.
    public void ExistingEmployeeLoad()
    {
        clsEntityProject objEntityProject = new clsEntityProject();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtExistingCustomer = objBusinessLayerProject.ReadExistingEmployee(objEntityProject);
        if (dtExistingCustomer.Rows.Count > 0)
        {
            ddlExistingEmployee.DataSource = dtExistingCustomer;
            ddlExistingEmployee.DataTextField = "USR_NAME";
            ddlExistingEmployee.DataValueField = "USR_ID";
            ddlExistingEmployee.DataBind();
            ddlExistingEmployee.Items.Insert(0, "--SELECT EMPLOYEE--");



            ddlProjectManager.DataSource = dtExistingCustomer;
            ddlProjectManager.DataTextField = "USR_NAME";
            ddlProjectManager.DataValueField = "USR_ID";
            ddlProjectManager.DataBind();
            ddlProjectManager.Items.Insert(0, "--SELECT EMPLOYEE--");
        }

    }
    
    




    //Method for binding Existing EMPLOYEE details to dropdown list.
    public void DivisionByUserLoadFrmLead(int DiviId)
    {
        clsEntityProject objEntityProject = new clsEntityProject();

        if (Session["ORGID"] != null)
        {
            objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityProject.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtExistingCustomer = objBusinessLayerProject.ReadDivisionByUser(objEntityProject);

        if (dtExistingCustomer.Rows.Count > 0)
        {
            foreach (DataRow dr in dtExistingCustomer.Rows)
            {
                if (Convert.ToInt32(dr["CPRDIV_ID"].ToString()) != DiviId)
                    dr.Delete();
            }

        }
        ddlDivision.Items.Clear();

        ddlDivision.DataSource = dtExistingCustomer;
        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();

    }
    //Method for binding Existing EMPLOYEE details to dropdown list.
    public void DivisionByUserLoad()
    {
        clsEntityProject objEntityProject = new clsEntityProject();

        if (Session["ORGID"] != null)
        {
            objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityProject.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        DataTable dtExistingCustomer = objBusinessLayerProject.ReadDivisionByUser(objEntityProject);

        ddlDivision.Items.Clear();

        ddlDivision.DataSource = dtExistingCustomer;
        ddlDivision.DataTextField = "CPRDIV_NAME";
        ddlDivision.DataValueField = "CPRDIV_ID";
        ddlDivision.DataBind();
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");

    }
    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityProject objEntityProject = new clsEntityProject();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityProject.Project_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityProject.Project_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityProject.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Request.QueryString["DivId"] != null)
        {
            string strDivId = Request.QueryString["DivId"].ToString();
            if (ddlDivision.Items.FindByValue(strDivId) != null)
            {
                objEntityProject.Corp_Div_id = Convert.ToInt32(strDivId);
            }
        }
        else
        {
            objEntityProject.Corp_Div_id = Convert.ToInt32(ddlDivision.SelectedItem.Value);
        }
        objEntityProject.Customer_Id = Convert.ToInt32(ddlExistingCustomer.SelectedItem.Value);
        if (cbxExistingEmployee.Checked == true)
        {
            if (ddlExistingEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
            {
                objEntityProject.Employee_Id = Convert.ToInt32(ddlExistingEmployee.SelectedItem.Value);
                objEntityProject.Contact_Name = ddlExistingEmployee.SelectedItem.Text;
            }
        }
        else
        {
            if (txtEmployeeName.Text.Trim() != "")
            {
                objEntityProject.Contact_Name = txtEmployeeName.Text.Trim();
            }
        }
        if (txtContactPhone.Text.Trim() != "")
        {
            objEntityProject.Contact_Phone = txtContactPhone.Text.Trim();
        }
        if (txtContactMail.Text.Trim() != "")
        {
            objEntityProject.Contact_Email = txtContactMail.Text.Trim();
        }

        if (cbxAwarded.Checked == true)
        {
            objEntityProject.GuaranteMOde_Id = 101;
            objEntityProject.Manager_Id = Convert.ToInt32(ddlProjectManager.SelectedItem.Value);
            objEntityProject.Client_Ref = txtClientRefNUm.Text.Trim();
            objEntityProject.Inter_Ref = txtInternalRefNum.Text.Trim();
        }
        else
        {
            objEntityProject.GuaranteMOde_Id = 102;
            objEntityProject.Tender_Ref = txtTenderRFQ.Text.Trim();
        }

        objEntityProject.D_Date = System.DateTime.Now;
        txtProjectName.Text = txtProjectName.Text.ToUpper().Trim();
        objEntityProject.ProjectName = txtProjectName.Text.Trim();
        objEntityProject.Proj_Ref_Num = lblRefNumber.Value.Trim();

        objEntityProject.WarehouseIds = hiddenWarehouseIds.Value;
        if (hiddenSelctdPrimaryWrhs.Value != "")
        {
            objEntityProject.WarehousePrimaryId = Convert.ToInt32(hiddenSelctdPrimaryWrhs.Value);
        }

        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerProject.Check_Project_Name(objEntityProject);

        string strInternalRefNum = "0";
        if (cbxAwarded.Checked == true)
        {
            strInternalRefNum = objBusinessLayerProject.CheckInternalRefNumber(objEntityProject);
        }

        //If there is no name like this on table.    
        if (strNameCount == "0" && strInternalRefNum == "0")
        {
            string intCustomerId = objBusinessLayerProject.Insert_Project_Return_PrjctId(objEntityProject);

            if (Request.QueryString["CFAM"] != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedProjectToLead", "PassSavedProjectToLead(" + intCustomerId + ");", true);
            }
            else
            {

                if (Request.QueryString["RFGP"] == "RFG")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedProjectToRFG", "PassSavedProjectToRFG(" + intCustomerId + ");", true);
                }
                if (Request.QueryString["PRCHS"] == "RFG")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedProjectToPRCHS", "PassSavedProjectToPRCHS(" + intCustomerId + ",'" + objEntityProject.ProjectName + "');", true);
                }
                else
                {
                    if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                    {
                        Response.Redirect("gen_Projects.aspx?InsUpd=Ins");
                    }
                    else if (clickedButton.ID == "btnAddNext" || clickedButton.ID == "btnAddNextF")
                    {
                        if (cbxAwarded.Checked == true)
                        {
                            Response.Redirect("/GMS/GMS_Master/gen_Contract_Master/gen_Contract_Master.aspx?InsUpd=PrjIns");
                        }
                        else
                        {
                            int intUserId = 0, intAddGuar = 0;
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
                            //Allocating child roles
                            int intUsrRolMstrIdCntrct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
                            DataTable dtChildRolCntrct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCntrct);
                            btnUpdateNext.Visible = false;
                            if (dtChildRolCntrct.Rows.Count > 0)
                            {
                                string strChildRolDeftn = dtChildRolCntrct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                                foreach (string strC_Role in strChildDefArrWords)
                                {
                                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                                    {
                                        intAddGuar = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                                    }

                                }
                            }

                            if (intAddGuar == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                            {
                                Response.Redirect("/GMS/GMS_Master/gen_Request_For_Guarantee/gen_Request_For_Guarantee.aspx?InsUpd=PrjIns");
                            }
                            else
                            {
                                Response.Redirect("gen_ProjectsList.aspx?InsUpd=Ins");
                            }
                        }
                    }
                }
            }

        }
        //If have
        else if (strNameCount != "0")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
            txtProjectName.Focus();
        }
        else if (strInternalRefNum != "0")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationInternalRefNum", "DuplicationInternalRefNum();", true);
            txtInternalRefNum.Focus();
        }
    }
    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsEntityProject objEntityProject = new clsEntityProject();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        
            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityProject.Project_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityProject.Project_Status = 0;
            }

            objEntityProject.Corp_Div_id = Convert.ToInt32(ddlDivision.SelectedItem.Value);
            objEntityProject.Customer_Id = Convert.ToInt32(ddlExistingCustomer.SelectedItem.Value);
            if (cbxExistingEmployee.Checked == true)
            {
                objEntityProject.Employee_Id = Convert.ToInt32(ddlExistingEmployee.SelectedItem.Value);
                objEntityProject.Contact_Name = ddlExistingEmployee.SelectedItem.Text;
            }
            else
            {
                if (txtEmployeeName.Text.Trim() != "")
                {
                    objEntityProject.Contact_Name = txtEmployeeName.Text.Trim();
                }
            }
            if (txtContactPhone.Text.Trim() != "")
            {
                objEntityProject.Contact_Phone = txtContactPhone.Text.Trim();
            }
            if (txtContactMail.Text.Trim() != "")
            {
                objEntityProject.Contact_Email = txtContactMail.Text.Trim();
            }

            if (cbxAwarded.Checked == true)
            {
                objEntityProject.GuaranteMOde_Id = 101;
                objEntityProject.Manager_Id = Convert.ToInt32(ddlProjectManager.SelectedItem.Value);
                objEntityProject.Client_Ref = txtClientRefNUm.Text.Trim();
                objEntityProject.Inter_Ref = txtInternalRefNum.Text.Trim();
            }
            else
            {
                objEntityProject.GuaranteMOde_Id = 102;
                objEntityProject.Tender_Ref = txtTenderRFQ.Text.Trim();
            }

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityProject.Project_Master_Id = Convert.ToInt32(strId);
           
            if (Session["USERID"] != null)
            {
                objEntityProject.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityProject.D_Date = System.DateTime.Now;
            objEntityProject.ProjectName = txtProjectName.Text.ToUpper().Trim();

            objEntityProject.WarehouseIds = hiddenWarehouseIds.Value;
            if (hiddenSelctdPrimaryWrhs.Value != "")
            {
                objEntityProject.WarehousePrimaryId = Convert.ToInt32(hiddenSelctdPrimaryWrhs.Value);
            }


            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerProject.Check_Project_NameUpdation(objEntityProject);


            string strInternalRefNum = "0";
            if (cbxAwarded.Checked == true)
            {
                strInternalRefNum = objBusinessLayerProject.CheckInternalRefNumberUpdation(objEntityProject);
            }

            //If there is no name like this on table.    
            if (strNameCount == "0" && strInternalRefNum == "0")
            {
                 DataTable dtComplaintDetail = objBusinessLayerProject.ReadProjectById(objEntityProject);
                 if (dtComplaintDetail.Rows.Count > 0)
                 {
                     if (dtComplaintDetail.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == "" || dtComplaintDetail.Rows[0]["PROJECT_CNCL_USR_ID"].ToString() == null)
                     {
                         objBusinessLayerProject.Update_Project(objEntityProject);
                         if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                         {
                             Response.Redirect("gen_Projects.aspx?InsUpd=Upd");
                         }
                         else if (clickedButton.ID == "btnUpdateNext" || clickedButton.ID == "btnUpdateNextF")
                         {
                             if (cbxAwarded.Checked == true)
                             {
                                 int intUserId = 0, intAddGuar = 0;
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
                                 //Allocating child roles
                                 int intUsrRolMstrIdCntrct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);
                                 DataTable dtChildRolCntrct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCntrct);
                                 btnUpdateNext.Visible = false;
                                 if (dtChildRolCntrct.Rows.Count > 0)
                                 {
                                     string strChildRolDeftn = dtChildRolCntrct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                                     string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                                     foreach (string strC_Role in strChildDefArrWords)
                                     {
                                         if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                                         {
                                             intAddGuar = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                                         }

                                     }
                                 }

                                 if (intAddGuar == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                 {
                                     Response.Redirect("/GMS/GMS_Master/gen_Contract_Master/gen_Contract_Master.aspx?InsUpd=PrjUpd");
                                 }
                                 else
                                 {
                                     Response.Redirect("gen_ProjectsList.aspx?InsUpd=Ins");
                                 }
                             }
                             else
                             {
                                 int intUserId = 0, intAddGuar = 0;
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
                                 //Allocating child roles
                                 int intUsrRolMstrIdCntrct = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Request_For_Guarantee);
                                 DataTable dtChildRolCntrct = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrIdCntrct);
                                 btnUpdateNext.Visible = false;
                                 if (dtChildRolCntrct.Rows.Count > 0)
                                 {
                                     string strChildRolDeftn = dtChildRolCntrct.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                                     string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                                     foreach (string strC_Role in strChildDefArrWords)
                                     {
                                         if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                                         {
                                             intAddGuar = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                                         }

                                     }
                                 }

                                 if (intAddGuar == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                                 {
                                     Response.Redirect("/GMS/GMS_Master/gen_Request_For_Guarantee/gen_Request_For_Guarantee.aspx?InsUpd=PrjUpd");

                                 }
                                 else
                                 {
                                     Response.Redirect("gen_ProjectsList.aspx?InsUpd=Ins");
                                 }
                             }
                         }
                     }
                     else
                     {
                         Response.Redirect("gen_ProjectsList.aspx?InsUpd=AlCncl");
                     }
                 }
               
            }
            //If have
            else if (strNameCount != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtProjectName.Focus();
            }
            else if (strInternalRefNum != "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationInternalRefNum", "DuplicationInternalRefNum();", true);
                txtInternalRefNum.Focus();
            }
        }
    }
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddNext.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateNext.Visible = false;
        btnAddF.Visible = false;
        btnAddNextF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateNextF.Visible = false;
        clsEntityProject objEntityProject = new clsEntityProject();
        objEntityProject.Project_Master_Id = Convert.ToInt32(strP_Id);
        DataTable dtProjectById = objBusinessLayerProject.ReadProjectById(objEntityProject);
        if (dtProjectById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtProjectName.Text = dtProjectById.Rows[0]["PROJECT_NAME"].ToString();

            lblRefNumber.Value = dtProjectById.Rows[0]["PROJECT_REF_NUMBER"].ToString();
            if (dtProjectById.Rows[0]["PROJECT_CNCT_EMAIL"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_CNCT_EMAIL"] != DBNull.Value)
            {
                txtContactMail.Text = dtProjectById.Rows[0]["PROJECT_CNCT_EMAIL"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECT_CNCT_PHONE"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_CNCT_PHONE"] != DBNull.Value)
            {
                txtContactPhone.Text = dtProjectById.Rows[0]["PROJECT_CNCT_PHONE"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECT_TENDER_REF"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_TENDER_REF"] != DBNull.Value)
            {
                txtTenderRFQ.Text = dtProjectById.Rows[0]["PROJECT_TENDER_REF"].ToString();
            }
            if (dtProjectById.Rows[0]["GUARNTMODE_ID"].ToString() == "1")
            {
                cbxAwarded.Checked = true;
            }
            else
            {
                cbxAwarded.Checked = false;
            }

            if (dtProjectById.Rows[0]["PROJECTS_CLIENT_REF"].ToString() != "" && dtProjectById.Rows[0]["PROJECTS_CLIENT_REF"] != DBNull.Value)
            {
                txtClientRefNUm.Text = dtProjectById.Rows[0]["PROJECTS_CLIENT_REF"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECTS_INTER_REF"].ToString() != "" && dtProjectById.Rows[0]["PROJECTS_INTER_REF"] != DBNull.Value)
            {
                txtInternalRefNum.Text = dtProjectById.Rows[0]["PROJECTS_INTER_REF"].ToString();
            }


            if (dtProjectById.Rows[0]["CSTMR_ID"].ToString() != "" && dtProjectById.Rows[0]["CSTMR_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["CSTMR_STATUS"].ToString() == "1")
                {
                    ddlExistingCustomer.Items.FindByValue(dtProjectById.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["CSTMR_NAME"].ToString(), dtProjectById.Rows[0]["CSTMR_ID"].ToString());
                    ddlExistingCustomer.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingCustomer);

                    ddlExistingCustomer.Items.FindByValue(dtProjectById.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
            }

            if (dtProjectById.Rows[0]["CPRDIV_ID"].ToString() != "" && dtProjectById.Rows[0]["CPRDIV_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["CPRDIV_STATUS"].ToString() == "1")
                {
                    ddlDivision.Items.FindByValue(dtProjectById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["CPRDIV_NAME"].ToString(), dtProjectById.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtProjectById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
            }

            if (dtProjectById.Rows[0]["USR_ID"].ToString() != "" && dtProjectById.Rows[0]["USR_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["USR_STATUS"].ToString() == "1")
                {
                    ddlExistingEmployee.Items.FindByValue(dtProjectById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["USR_NAME"].ToString(), dtProjectById.Rows[0]["USR_ID"].ToString());
                    ddlExistingEmployee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmployee);

                    ddlExistingEmployee.Items.FindByValue(dtProjectById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }
                cbxExistingEmployee.Checked = true;
            }
            else
            {
                cbxExistingEmployee.Checked = true;
                if (dtProjectById.Rows[0]["PROJECT_CNCT_NAME"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_CNCT_NAME"] != DBNull.Value)
                {
                    txtEmployeeName.Text = dtProjectById.Rows[0]["PROJECT_CNCT_NAME"].ToString();
                }
            }

            if (dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString() != "" && dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["PROJECTS_MANAGER_STATUS"].ToString() == "1")
                {
                    ddlProjectManager.Items.FindByValue(dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["PROJECTS_MANAGER_NAME"].ToString(), dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString());
                    ddlProjectManager.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProjectManager);

                    ddlProjectManager.Items.FindByValue(dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString()).Selected = true;
                }
            }

            int intProjectStatus = Convert.ToInt32(dtProjectById.Rows[0]["PROJECT_STATUS"]);
            if (intProjectStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
        }
        txtProjectName.Enabled = false;
        txtClientRefNUm.Enabled = false;
        txtContactMail.Enabled = false;
        txtContactPhone.Enabled = false;
        //txtCustName.Enabled = false;
        txtEmployeeName.Enabled = false;
        txtInternalRefNum.Enabled = false;
        txtProjectName.Enabled = false;
        txtTenderRFQ.Enabled = false;
        ddlDivision.Enabled = false;
        ddlExistingCustomer.Enabled = false;
        ddlExistingEmployee.Enabled = false;
        ddlProjectManager.Enabled = false;
        cbxAwarded.Disabled = true;
        //cbxExistingCustomer.Enabled = false;
        cbxExistingEmployee.Disabled = true;
        cbxStatus.Disabled = true;
        btnNewCust.Disabled = true;
        ddlWarehouse.Enabled = false;
        ddlPrimaryWrhs.Enabled = false;
    }
    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        int intUserId = 0;
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
         //Allocating child roles
           int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Contract_Master);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            btnUpdateNext.Visible = false;
            btnUpdateNextF.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        btnUpdateNext.Visible = true;
                        btnUpdateNextF.Visible = true;
                    }
                   
                }
            }


        btnAdd.Visible = false;
        btnAddNext.Visible = false;
        btnUpdate.Visible = true;
        btnAddF.Visible = false;
        btnAddNextF.Visible = false;
        btnUpdateF.Visible = true;
        clsEntityProject objEntityProject = new clsEntityProject();
        objEntityProject.Project_Master_Id = Convert.ToInt32(strP_Id);
        DataTable dtProjectById = objBusinessLayerProject.ReadProjectById(objEntityProject);
        if (dtProjectById.Rows.Count > 0)
        {
            //After fetch Deaprtment details in datatable,we need to differentiate.
            txtProjectName.Text = dtProjectById.Rows[0]["PROJECT_NAME"].ToString();
            lblRefNumber.Value = dtProjectById.Rows[0]["PROJECT_REF_NUMBER"].ToString();
            if (dtProjectById.Rows[0]["PROJECT_CNCT_EMAIL"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_CNCT_EMAIL"] != DBNull.Value)
            {
                txtContactMail.Text = dtProjectById.Rows[0]["PROJECT_CNCT_EMAIL"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECT_CNCT_PHONE"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_CNCT_PHONE"] != DBNull.Value)
            {
                txtContactPhone.Text = dtProjectById.Rows[0]["PROJECT_CNCT_PHONE"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECT_TENDER_REF"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_TENDER_REF"] != DBNull.Value)
            {
               txtTenderRFQ.Text = dtProjectById.Rows[0]["PROJECT_TENDER_REF"].ToString();
            }
            if (dtProjectById.Rows[0]["GUARNTMODE_ID"].ToString() == "101")
            {
                cbxAwarded.Checked = true;
                cbxAwarded.Disabled = true;
            }
            else
            {
                cbxAwarded.Checked = false;
            }

            if (dtProjectById.Rows[0]["PROJECTS_CLIENT_REF"].ToString() != "" && dtProjectById.Rows[0]["PROJECTS_CLIENT_REF"] != DBNull.Value)
            {
                txtClientRefNUm.Text = dtProjectById.Rows[0]["PROJECTS_CLIENT_REF"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECTS_INTER_REF"].ToString() != "" && dtProjectById.Rows[0]["PROJECTS_INTER_REF"] != DBNull.Value)
            {
                txtInternalRefNum.Text = dtProjectById.Rows[0]["PROJECTS_INTER_REF"].ToString();
            }


            if (dtProjectById.Rows[0]["CSTMR_ID"].ToString() != "" && dtProjectById.Rows[0]["CSTMR_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["CSTMR_STATUS"].ToString() == "1" && dtProjectById.Rows[0]["CSTMR_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlExistingCustomer.Items.FindByValue(dtProjectById.Rows[0]["CSTMR_ID"].ToString()) != null)
                    {
                        ddlExistingCustomer.Items.FindByValue(dtProjectById.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["CSTMR_NAME"].ToString(), dtProjectById.Rows[0]["CSTMR_ID"].ToString());
                        ddlExistingCustomer.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlExistingCustomer);

                        ddlExistingCustomer.Items.FindByValue(dtProjectById.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["CSTMR_NAME"].ToString(), dtProjectById.Rows[0]["CSTMR_ID"].ToString());
                    ddlExistingCustomer.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingCustomer);

                    ddlExistingCustomer.Items.FindByValue(dtProjectById.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                }
            }

            if (dtProjectById.Rows[0]["CPRDIV_ID"].ToString() != "" && dtProjectById.Rows[0]["CPRDIV_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["CPRDIV_STATUS"].ToString() == "1" && dtProjectById.Rows[0]["CPRDIV_CNCL_USR_ID"].ToString() == "")
                {
                    if (ddlDivision.Items.FindByValue(dtProjectById.Rows[0]["CPRDIV_ID"].ToString()) != null)
                    {
                        ddlDivision.Items.FindByValue(dtProjectById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["CPRDIV_NAME"].ToString(), dtProjectById.Rows[0]["CPRDIV_ID"].ToString());
                        ddlDivision.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlDivision);

                        ddlDivision.Items.FindByValue(dtProjectById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["CPRDIV_NAME"].ToString(), dtProjectById.Rows[0]["CPRDIV_ID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtProjectById.Rows[0]["CPRDIV_ID"].ToString()).Selected = true;
                }
            }

            if (dtProjectById.Rows[0]["USR_ID"].ToString() != "" && dtProjectById.Rows[0]["USR_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["USR_STATUS"].ToString() == "1" && dtProjectById.Rows[0]["USR_CNCL_DATE"].ToString() == "")
                {
                    if (ddlExistingEmployee.Items.FindByValue(dtProjectById.Rows[0]["USR_ID"].ToString()) != null)
                    {
                        ddlExistingEmployee.Items.FindByValue(dtProjectById.Rows[0]["USR_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["USR_NAME"].ToString(), dtProjectById.Rows[0]["USR_ID"].ToString());
                        ddlExistingEmployee.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlExistingEmployee);

                        ddlExistingEmployee.Items.FindByValue(dtProjectById.Rows[0]["USR_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["USR_NAME"].ToString(), dtProjectById.Rows[0]["USR_ID"].ToString());
                    ddlExistingEmployee.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlExistingEmployee);

                    ddlExistingEmployee.Items.FindByValue(dtProjectById.Rows[0]["USR_ID"].ToString()).Selected = true;
                }

                cbxExistingEmployee.Checked = true;
            }
            else
            {
                cbxExistingEmployee.Checked = false;
                if (dtProjectById.Rows[0]["PROJECT_CNCT_NAME"].ToString() != "" && dtProjectById.Rows[0]["PROJECT_CNCT_NAME"] != DBNull.Value)
                {
                    txtEmployeeName.Text = dtProjectById.Rows[0]["PROJECT_CNCT_NAME"].ToString();
                }
            }

            if (dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString() != "" && dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"] != DBNull.Value)
            {
                if (dtProjectById.Rows[0]["PROJECTS_MANAGER_STATUS"].ToString() == "1")
                {
                    if (ddlProjectManager.Items.FindByValue(dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString()) != null)
                    {
                        ddlProjectManager.Items.FindByValue(dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["PROJECTS_MANAGER_NAME"].ToString(), dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString());
                        ddlProjectManager.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlProjectManager);

                        ddlProjectManager.Items.FindByValue(dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtProjectById.Rows[0]["PROJECTS_MANAGER_NAME"].ToString(), dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString());
                    ddlProjectManager.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProjectManager);

                    ddlProjectManager.Items.FindByValue(dtProjectById.Rows[0]["PROJECTS_MANAGER_ID"].ToString()).Selected = true;
                }
            }


            int intProjectStatus = Convert.ToInt32(dtProjectById.Rows[0]["PROJECT_STATUS"]);
            if (intProjectStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }

            if (dtProjectById.Rows[0]["PROJECTS_WAREHOUSE_IDS"].ToString() != "")
            {
                hiddenWarehouseIds.Value = dtProjectById.Rows[0]["PROJECTS_WAREHOUSE_IDS"].ToString();
            }
            if (dtProjectById.Rows[0]["PROJECTS_WAREHOUSE_PRIMARY_ID"].ToString() != "")
            {
                hiddenSelctdPrimaryWrhs.Value = dtProjectById.Rows[0]["PROJECTS_WAREHOUSE_PRIMARY_ID"].ToString();
            }


        }
    }
    protected void btnNewCust_Click(object sender, EventArgs e)
    {
        ExistingCustomerLoad();
        string target = Request["__EVENTTARGET"];
        if (target == "ctl00$cphMain$btnNewCustS")
        {
            string strCustid = hiddenNewCustId.Value;
            //  string strCustid = Request["__EVENTARGUMENT"];
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelCustomerLoad", "UpdatePanelCustomerLoad(" + strCustid + ");", true);
        }
    }
    protected void ddlExistingEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsEntityProject objEntityProject = new clsEntityProject();
        if (ddlExistingEmployee.SelectedItem.Value != "--SELECT EMPLOYEE--")
        {
            objEntityProject.User_Id = Convert.ToInt32(ddlExistingEmployee.SelectedItem.Value);

           DataTable dtEmp= objBusinessLayerProject.ReadEmployeeDetail(objEntityProject);
           if (dtEmp.Rows.Count > 0)
           {
               txtContactPhone.Text = dtEmp.Rows[0]["USR_MOBILE"].ToString();
               txtContactMail.Text = dtEmp.Rows[0]["USR_EMAIL"].ToString();
           }
        }

        ScriptManager.RegisterStartupScript(this, GetType(), "UpdatePanelExistEmployee", "UpdatePanelExistEmployee();", true);
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


    public void LoadWarehouse()
    {
        clsEntityProject objEntityProject = new clsEntityProject();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityProject.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityProject.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtWarehouse = objBusinessLayerProject.ReadWarehouses(objEntityProject);

        ddlWarehouse.Items.Clear();
        if (dtWarehouse.Rows.Count > 0)
        {
            ddlWarehouse.DataSource = dtWarehouse;
            ddlWarehouse.DataTextField = "WRHS_NAME";
            ddlWarehouse.DataValueField = "WRHS_ID";
            ddlWarehouse.DataBind();
        }

    }




}