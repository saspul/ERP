using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HCM_HCM_Master_gen_Manpower_Recruitment_gen_Manpower_Recruitment : System.Web.UI.Page
{
    int intOrgId;
    int intCorpId;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RFGP"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageCompzit_Hcm.master";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    { 
        divhApproval.Visible = false;
        HiddenDivHrSts.Value = "0";
        txtrqstdate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtrqstdate.Attributes.Add("onkeypress", "return isTag(event)");
        TxtdivRqrdDate.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        TxtdivRqrdDate.Attributes.Add("onkeypress", "return isTag(event)");
        txtRqrmntNo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtRqrmntNo.Attributes.Add("onkeypress", "return isTag(event)");
      //  ddlDesignation.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //ddlDesignation.Attributes.Add("onkeypress", "return isTag(event)");
       // ddlDivision.Attributes.Add("onchange", "IncrmntConfrmCounter()");
       // ddlDivision.Attributes.Add("onkeypress", "return isTag(event)");
      //  ddlDepartment.Attributes.Add("onchange", "IncrmntConfrmCounter()");
     // ddlDepartment.Attributes.Add("onkeypress", "return isTag(event)");
        ddlProject.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlProject.Attributes.Add("onkeypress", "return isTag(event)");
        txtnoEmpInSamepos.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtnoEmpInSamepos.Attributes.Add("onkeypress", "return isTag(event)");
        txtYrOfExp.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtYrOfExp.Attributes.Add("onkeypress", "return isTag(event)");
        txtrsnforrqrmnt.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtrsnforrqrmnt.Attributes.Add("onkeypress", "return isTag(event)");
        chkbxListCountry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        chkbxListCountry.Attributes.Add("onkeypress", "return isTag(event)");
        txtothrbenefits.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtothrbenefits.Attributes.Add("onkeypress", "return isTag(event)");
        ddlpaygrade.Attributes.Add("onkeypress", "return isTag(event)");
        ddlpaygrade.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtcomments.Attributes.Add("onkeypress", "return isTag(event)");
        txtcomments.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlIdenter.Attributes.Add("onkeypress", "return isTag(event)");
        ddlIdenter.Attributes.Add("onchange", "IncrmntConfrmCounter()"); 
        txtothrbenefits.Attributes.Add("onkeypress", "return isTag(event)");
        txtothrbenefits.Attributes.Add("onchange", "IncrmntConfrmCounter()");
       // txtothrbenefits.Enabled = false;
      
        if (!IsPostBack)
        {
         
            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            txtrqstdate.Text = HiddenCurrentDate.Value;
            imgbtnReOpen.ImageUrl = "/Images/Icons/Reopen.png";
            imgBtnClose.ImageUrl = "/Images/Icons/close guarantee.png";
       imgbtnReOpen.Visible = false;
       imgBtnClose.Visible = false;
       btnHrReject.Visible = false;
           // HiddenField3_FileUpload.Value = null;
            TxtRefNo.Text = "ReferenceNo";
             
            txtrqstdate.Focus();

            btnHrconfirm.Visible = false;
            brnGMapprove.Visible = false;
            btnConfirm.Visible = false;
           /// btn.Visible = false;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            DesignationLoad();
           // DivisionLoad();
            projectLoad();
            IntenderLoad();
            PaygradeLoad();
            IntenderLoad();
            //Personal details
            CountryLoad();
            DepartmentLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            int intUserId = 0, intUsrRolMstrId, intUserRoleRecall, intEnableAdd = 0, intEnableModify = 0, intEnableCancel = 0, intEnableRecall = 0,intEnableReOpen=0, intEnableHrConfirm = 0, intEnableGMApprove = 0, intEnableConfirm=0,intEnableClose=0;

                     if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"]);
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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
            intUserRoleRecall = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Recall_Cancelled);
            DataTable dtCancelRecall = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUserRoleRecall);
            if (dtCancelRecall.Rows.Count > 0)
            {
                intEnableRecall = 1;
            }
            else
            {
                intEnableRecall = 0;
            }
            //Allocating child roles
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mapower_Requirement);
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

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        Hiddenenabledit.Value = intEnableModify.ToString(); ;
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                    {
                        intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                    {
                        intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                    {
                        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                        //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                    }
                }
            }

            if (intEnableConfirm == 1)
            {

                btnHrconfirm.Visible = false;
                brnGMapprove.Visible = false;
                btnHrReject.Visible = false;
                btnGMreject.Visible = false;

              //  divhApproval.Visible = true;
            }
              if (intEnableHrConfirm == 1)
            {
                btnHrconfirm.Visible = true;
                brnGMapprove.Visible = false;
                divhApproval.Visible = true;
                btnHrReject.Visible = false;
                btnGMreject.Visible = false;
                HiddenDivHrSts.Value = "1";
            }
            if (intEnableGMApprove == 1)
            {
            
                btnHrconfirm.Visible = false;
                brnGMapprove.Visible = true;
                divhApproval.Visible = true;
                btnHrReject.Visible = true;
                btnGMreject.Visible = true;
                HiddenDivHrSts.Value = "1";
            }
            if (intEnableClose == 1)
            {
                imgBtnClose.Visible = true;
                //brnGMapprove.Visible = true;
                //divhApproval.Visible = true;

                //vv
                //btnConfirm.Visible = true;
            }
            //if (intEnableConfirm == 1)
            //{
            //    btnConfirm.Visible = true;
            //    brnGMapprove.Visible = true;
            //    divhApproval.Visible = true;
            //}
            if (intEnableReOpen == 1)
            {
                imgbtnReOpen.Visible = true;
                imgbtnReOpen.Focus();
                // brnGMapprove.Visible = true;
                //divhApproval.Visible = true;
            }
            btnGMreject.Visible = false;
 
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                if (Request.QueryString["MODE"] != null)
                {
                    //hiddenOpenPrmtORIns.Value = Request.QueryString["MODE"].ToString();
                }



                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnClear.Visible = false;
                if (intEnableModify == 1)
                {
                    btnUpdate.Visible = true;
                    btnUpdateClose.Visible = true;

                    if(intEnableAdd==0)
                        btnUpdate.Visible = false;
                }
             //   hiddenVehicleIdForRenew.Value = Request.QueryString["Id"].ToString();
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                      Update(strId);
               // hiddenViewMode.Value = "edit";
                lblEntry.Text = "Edit Manpower Requirement";


            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
              
                View(strId);
//
                lblEntry.Text = "View Manpower Requirement";
               
                if (Request.QueryString["RFGP"] != null)
                {
                    btnHrconfirm.Visible = false;
                    btnCancel.Visible = false;
                    divList.Visible = false;
                    imgBtnClose.Visible = false;
                    cbxStatus.Enabled = false;
                    Image1.Disabled = true;
                    Image6.Disabled = true;
                }
            }

            else
            {
                imgbtnReOpen.Visible = false;
                imgBtnClose.Visible = false;
                divhApproval.Visible = false;
                btnConfirm.Visible = false;
                btnHrReject.Visible = false;
                btnGMreject.Visible = false;
                HiddenDivHrSts.Value = "0";
                txtrqstdate.Focus();
                lblEntry.Text = "Add Manpower Requirement";
               // divCSV.Attributes["style"] = "margin-left: 31%;margin-top: 1%;";
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
                objEntityCommon.CorporateID = intCorpId;
                objEntityCommon.Organisation_Id = intOrgId;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
                hiddenenxtid.Value = strNextId;
              //  ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(strNextId);
                string year = DateTime.Today.Year.ToString();
                TxtRefNo.Text = "REF/" + year + "/" + strNextId;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnHrconfirm.Visible = false;
                brnGMapprove.Visible = false;
                if (intEnableAdd == 1)
                {
                    btnAdd.Visible = true;
                    btnAddClose.Visible = true;
                }
                else {

                    btnAdd.Visible = false;
                    btnAddClose.Visible = false;
                
                }
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
                    else if (strInsUpd == "Conf")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmed", "SuccessConfirmed();", true);
                    }
                    else if (strInsUpd == "Appr")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
                    }
                    else if (strInsUpd == "Reopen")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopened", "SuccessReopened();", true);
                    }
                    else if (strInsUpd == "Close")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClosed", "SuccessClosed();", true);
                    }
                    else if (strInsUpd == "Rejctd")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessRejected", "SuccessRejected();", true);
                    }
                }
            }

        }
    }

    public void CountryLoad()
    {
        clsBusinessLayerPersonalDtls objBusinessPersonaldtls = new clsBusinessLayerPersonalDtls();
        DataTable dtCountry = objBusinessPersonaldtls.readCountry();
        HiddenFieldCbxCount.Value = dtCountry.Rows.Count.ToString();
        chkbxListCountry.DataSource = dtCountry;

        chkbxListCountry.DataTextField = "CNTRY_NAME";
        chkbxListCountry.DataValueField = "CNTRY_ID";
        chkbxListCountry.DataBind();
       // chkbxListCountry.Items.Insert(0, "--ANY--");
    }
    public void projectLoad()
    {
        clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();

        //clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int divid = 0;
        ObjEntityManpowerRecruitment.DivisionId = divid;
        DataTable dtProject = objBusinessMNPWRDetails.ReadProject(ObjEntityManpowerRecruitment);
        if (dtProject.Rows.Count > 0)
        {
            ddlProject.DataSource = dtProject;
           

            ddlProject.DataValueField = "PROJECT_ID";
            ddlProject.DataTextField = "PROJECT_NAME";

            //  ddlprojectassign.DataValueField = "PROJECT_ID";
        

       //     ddlProjct.DataValueField = "PROJECT_ID";
            ddlProject.DataBind();
        
        }
    //    ddlprojectassign.Items.Insert(0, "--SELECT PROJECT--");
        ddlProject.Items.Insert(0, "--SELECT PROJECT--");


    }

    public void DesignationLoad()
    {
        clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdesig = objBusinessMNPWRDetails.ReadDesignation(ObjEntityManpowerRecruitment);
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
        clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityJobDetails.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
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
        ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
    }
    public void PaygradeLoad()
    {
        clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      //  clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdepartment = objBusinessMNPWRDetails.ReadPaygrade(ObjEntityManpowerRecruitment);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlpaygrade.DataSource = dtdepartment;
            ddlpaygrade.Items.Clear();

            ddlpaygrade.DataValueField = "PYGRD_ID";
            ddlpaygrade.DataTextField = "PYGRD_NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlpaygrade.DataBind();

        }
        ddlpaygrade.Items.Insert(0, "--SELECT PAYGRADE--");

    }
    public void IntenderLoad()
    {
        int intUserId = 0;
        clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        //  clsEntityProjectAssign ObjEntityProjectAssign = new clsEntityProjectAssign();

        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdepartment = objBusinessMNPWRDetails.ReadIndenter(ObjEntityManpowerRecruitment);
        if (dtdepartment.Rows.Count > 0)
        {
            ddlIdenter.DataSource = dtdepartment;
            ddlIdenter.Items.Clear();

            ddlIdenter.DataValueField = "USR_ID";
            ddlIdenter.DataTextField = "EMPLOYEE NAME";



            //ddlProjct.DataValueField = "PROJECT_ID";
            ddlIdenter.DataBind();

        }
        ddlIdenter.Items.Insert(0, "--SELECT IDENTER--");
        ddlIdenter.Items.FindByValue(intUserId.ToString()).Selected = true;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
        //objEntityCommon.CorporateID = intCorpId;
        //objEntityCommon.Organisation_Id = intOrgId;
        //string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

        ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(hiddenenxtid.Value);
        //string year = DateTime.Today.Year.ToString();
        //TxtRefNo.Text = "REF/" + year + "/" + strNextId;
        ////  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        ObjEntityManpowerRecruitment.RequestDate = objCommonLibrary.textToDateTime(txtrqstdate.Text);

        ObjEntityManpowerRecruitment.RequestDate1 = objCommonLibrary.textToDateTime(TxtdivRqrdDate.Text);
        ObjEntityManpowerRecruitment.No_Resources = Convert.ToInt32(txtRqrmntNo.Text);
        ObjEntityManpowerRecruitment.Reference_Number = TxtRefNo.Text;
        if (ddlDesignation.SelectedItem.Text == "--SELECT DESIGNATION--")
        {
            ObjEntityManpowerRecruitment.DesignationId = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
        }

        if (ddlDivision.SelectedItem.Text == "--SELECT DIVISION--")
        {
            ObjEntityManpowerRecruitment.DivisionId = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
        }

        if (ddlDepartment.SelectedItem.Text == "--SELECT DEPARTMENT--")
        {
            ObjEntityManpowerRecruitment.Derpartment = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.Derpartment = Convert.ToInt32(ddlDepartment.Text);
        }
        if (ddlProject.SelectedItem != null)
        {

            if (ddlProject.SelectedItem.Text == "--SELECT PROJECT--")
            {
                ObjEntityManpowerRecruitment.Project = 0;
            }
            else
            {

                ObjEntityManpowerRecruitment.Project = Convert.ToInt32(ddlProject.SelectedValue);
            }
        }
        else
            ObjEntityManpowerRecruitment.Project = 0;
        ObjEntityManpowerRecruitment.ExperienceRqrd = Convert.ToInt32(txtYrOfExp.Text);
        ObjEntityManpowerRecruitment.RecruitReason = txtrsnforrqrmnt.Text;
        ObjEntityManpowerRecruitment.OtherBenefits = txtothrbenefits.Text;
        //  ObjEntityManpowerRecruitment.PaygradeId = 
        if (ddlpaygrade.SelectedItem.Text == "--SELECT PAYGRADE--")
        {
            ObjEntityManpowerRecruitment.PaygradeId = 0;
        }
        else
        {


            ObjEntityManpowerRecruitment.PaygradeId = Convert.ToInt32(ddlpaygrade.SelectedValue);
        }



        ObjEntityManpowerRecruitment.Comments = txtcomments.Text;
        // ObjEntityManpowerRecruitment.Identer =Convert.ToInt32( ddlIdenter.Text);
        if (ddlIdenter.SelectedItem.Text == "--SELECT IDENTER--")
        {
            ObjEntityManpowerRecruitment.Identer = 0;
        }
        else
        {


            ObjEntityManpowerRecruitment.Identer = Convert.ToInt32(ddlIdenter.SelectedValue);
        }

  
        ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
        ObjEntityManpowerRecruitment.Comments = txtcomments.Text;


        ObjEntityManpowerRecruitment.PrefferedMastrID = Int32.Parse(hiddenenxtid.Value);
        int j = 0;
        for (int i = 0; i < chkbxListCountry.Items.Count; i++)
        {

            if (chkbxListCountry.Items[i].Selected)
            {
                j++;
                //CllsEntityPrefferedNationaity ObjEntityPrefferedNationaitytemp = new CllsEntityPrefferedNationaity();

                ObjEntityManpowerRecruitment.PrefCountry_id[j] = Int32.Parse(chkbxListCountry.Items[i].Value);



            }
        }

        objBusinessManpowerDetails.AddManpowerRecruitment(ObjEntityManpowerRecruitment);
        if (clickedButton.ID == "btnAdd")
        {

            Response.Redirect("gen_Manpower_Recruitment.aspx?InsUpd=Ins");
        }
        else if (clickedButton.ID == "btnAddClose")
        {
            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Ins");


        }

    }

    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;

        btnUpdateClose.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0,intEnableModify=0, intEnableGMApprove = 0, intEnableConfirm = 0,intEnableReOpen=0, intEnableClose=0;
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        if (Session["USERID"] != null)
        {
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mapower_Requirement);
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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    Hiddenenabledit.Value = intEnableModify.ToString(); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {
                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }

            }
            if (intEnableModify == 1)
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

                if (intEnableAdd == 0)
                    btnUpdate.Visible = false;
            }
           



        }


        ScriptManager.RegisterStartupScript(this, GetType(), "GetEmployeeCount", "GetEmployeeCount();", true);

        Hiddenrqstid.Value = strP_Id;
        ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(strP_Id);
        DataTable dtMnpwrrMstr = objBusinessManpowerDetails.ReadManpowerRecruitmentId(ObjEntityManpowerRecruitment);
        //txt.Text = dtMnpwrrMstr.Rows[0]["SPNSR_NAME"].ToString();
        string rejectststs = dtMnpwrrMstr.Rows[0]["REJECT_STATUS"].ToString();
        string status = dtMnpwrrMstr.Rows[0]["MNP_PROCESS_STATUS"].ToString();
        string cnfrmstatus = dtMnpwrrMstr.Rows[0]["MNP_CONFIRM"].ToString();


        
        
        if (status == "1")
        {
            //***
            if (intEnableConfirm==1)
            btnConfirm.Visible = true;
            btnHrconfirm.Visible = false;
            btnHrReject.Visible = false;
        
            brnGMapprove.Visible = false;
            imgbtnReOpen.Visible = false;
            divhApproval.Visible = false;
            HiddenDivHrSts.Value = "0";
            btnGMreject.Visible = false;
            if (rejectststs == "1")
            {

                divhApproval.Visible = true;
                divhApproval.Disabled = false;
                txthrnote.Enabled = false;
                txtverifieddate.Enabled = false;
                HiddenDivHrSts.Value = "0";
            }

        }
        if (status == "2" && intEnableHrConfirm == 1)
        {
            imgbtnReOpen.Focus();
            btnHrReject.Visible = true;
     
            btnHrconfirm.Visible = true;
            brnGMapprove.Visible = false;
            btnGMreject.Visible = false;
            divhApproval.Visible = true;
        }
        if (status == "3" && intEnableGMApprove==1)
        {
            brnGMapprove.Visible = true;
        
             // brnGMapprove.Visible = false;
            btnGMreject.Visible = true;
            divhApproval.Visible = true;
            HiddenDivHrSts.Value = "0";

        }
        if (status == "4")
        {
            btnGMreject.Visible = false;
       
            btnHrconfirm.Visible = false;
            btnUpdate.Visible = false;
            brnGMapprove.Visible = false;
            btnUpdateClose.Visible = false;
            divhApproval.Visible = false;
            HiddenDivHrSts.Value = "0";
        }

        //if (rejectststs == "1")
        //{

        //    divhApproval.Visible = true;
        //    divhApproval.Disabled = false;
        //    if (status != "2")
        //    {
        //        divhApproval.Visible = false;
        //        txthrnote.Enabled = false;
        //        txtverifieddate.Enabled = false;
        //    }
        //}
        DesignationLoad();
        //DivisionLoad();
        projectLoad();
        IntenderLoad();
        PaygradeLoad();
        IntenderLoad();
        //Personal details
        CountryLoad();
        DepartmentLoad();


        txtrqstdate.Text = dtMnpwrrMstr.Rows[0]["DATE OF REQUEST"].ToString();

        TxtdivRqrdDate.Text = dtMnpwrrMstr.Rows[0]["REQUIRED DATE"].ToString();

        txtRqrmntNo.Text = dtMnpwrrMstr.Rows[0]["MNP_RESOURCENUM"].ToString();
        TxtRefNo.Text= dtMnpwrrMstr.Rows[0]["MNP_REFNUM"].ToString();
        if (dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString() != "")
        {
            if (ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()) != null)
            {
                ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["DSGN_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString());
                ddlDesignation.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlDesignation);

                ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
            }
        }
      //  ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
        if (dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString() != "")
        {
            if (ddlDivision.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString()) != null)
            {
                ddlDivision.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CPRDIV_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString());
                ddlDivision.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlDivision);

                ddlDivision.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString()).Selected = true;
            }
        }
        if (dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString() != "")
        {
            if (ddlDepartment.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString()) != null)
            {
                ddlDepartment.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CPRDEPT_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString());
                ddlDepartment.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlDepartment);

                ddlDepartment.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString()).Selected = true;
            }
        }
      
           //if (dtMnpwrrMstr.Rows[0]["MNP_PROJID"] != DBNull.Value||dtMnpwrrMstr.Rows[0]["MNP_PROJID"] != "")
       // {
       // ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
       // }

        //txtnoEmpInSamepos.Text = dtMnpwrrMstr.Rows[0]["MNP_EXPERIENCE"].ToString();

        txtYrOfExp.Text = dtMnpwrrMstr.Rows[0]["MNP_EXPERIENCE"].ToString();

        txtrsnforrqrmnt.Text = dtMnpwrrMstr.Rows[0]["MNP_RECRUTRSN"].ToString();
        if (dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString() != "")
        {
            if (ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()) != null)
            {
                ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["PROJECT_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString());
                ddlProject.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlProject);

                ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
            }

        }
      //  ddlPrefnationlitiies.Text = dtMnpwrrMstr.Rows[0]["MNPRQST_ID"].ToString();

        txtothrbenefits.Text = dtMnpwrrMstr.Rows[0]["MNP_OTHRBENEFITS"].ToString();
      //ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()).Selected = true;
 
      //  ddlpaygrade.Text = dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString();


        txtcomments.Text = dtMnpwrrMstr.Rows[0]["MNP_COMMENTS"].ToString();
        if (dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString() != "")
        {

            if (ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()) != null)
            {
                ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["PYGRD_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString());
                ddlpaygrade.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlpaygrade);

                ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()).Selected = true;
            }
        }
        if (dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString() != "")
        {
            if (ddlIdenter.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString()) != null)
            {
                ddlIdenter.Text = dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString();

            }
            else
            {
                ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["USR_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString());
                ddlIdenter.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlIdenter);

                ddlIdenter.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString()).Selected = true;
            }

        }


        int intStatus = Convert.ToInt32(dtMnpwrrMstr.Rows[0]["STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }


        for (int i = 0; i < dtMnpwrrMstr.Rows.Count; i++)
        {
            if (dtMnpwrrMstr.Rows[i]["COUNTRY ID"].ToString() != "")
            {
                if (chkbxListCountry.Items.FindByValue(dtMnpwrrMstr.Rows[i]["COUNTRY ID"].ToString()) != null)
                {
                    chkbxListCountry.Items.FindByValue(dtMnpwrrMstr.Rows[i]["COUNTRY ID"].ToString()).Selected = true;

                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[i]["CNTRY_NAME"].ToString(), dtMnpwrrMstr.Rows[i]["COUNTRY ID"].ToString());
                    chkbxListCountry.Items.Insert(1, lstGrp);

                    //SortDDL(ref this.ddlpaygrade);

                    chkbxListCountry.Items.FindByValue(dtMnpwrrMstr.Rows[i]["COUNTRY ID"].ToString()).Selected = true;
                }
            }
        }
        txtverifieddate.Text = dtMnpwrrMstr.Rows[0]["VERIFIEDDATE"].ToString();
        txthrnote.Text = dtMnpwrrMstr.Rows[0]["MNP_HRNOTES"].ToString();
        txtgmNotes.Text = dtMnpwrrMstr.Rows[0]["MNP_GMNOTES"].ToString();
        if (txtgmNotes.Text == "")
        {
            DivGmreject.Visible = false;
            // txtgmNotes.Visible =false;
        }
        else
            DivGmreject.Visible = true;
           // }
           // }

      //  objBusinessManpowerDetails.AddManpowerRecruitment(ObjEntityManpowerRecruitment);
        }
    //vv
    public void View(string strP_Id)
    {

        projectLoad();
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
     
        btnUpdateClose.Visible = true;
        // clsentitylayeemplo objEntitySponsor = new clsEntitySponsor();
        int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0, intEnableCancel = 0, intEnableHrConfirm = 0, intEnableModify = 0, intEnableGMApprove = 0, intEnableConfirm = 0, intEnableReOpen = 0, intEnableClose = 0;
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        if (Session["USERID"] != null)
        {
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
            intUserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //Allocating child roles
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Mapower_Requirement);
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
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                {
                    intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    Hiddenenabledit.Value = intEnableModify.ToString(); ;
                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                {
                    intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    Hiddenenablecancl.Value = intEnableCancel.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.HR_Allocation).ToString())
                {
                    intEnableHrConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenHrCnfrm.Value = intEnableHrConfirm.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.GM_Allocation).ToString())
                {
                    intEnableGMApprove = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                {
                    intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                {
                    intEnableReOpen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }
                else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Close).ToString())
                {
                    intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);

                    //    HiddenGMApprove.Value = intEnableGMApprove.ToString(); ;

                }

            }
            if (intEnableModify == 1)
            {
                btnUpdate.Visible = true;
                btnUpdateClose.Visible = true;

                if (intEnableAdd == 0)
                    btnUpdate.Visible = false;
            }


        

        }


        ScriptManager.RegisterStartupScript(this, GetType(), "GetEmployeeCount", "GetEmployeeCount();", true);

        Hiddenrqstid.Value = strP_Id;
        ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(strP_Id);
        DataTable dtMnpwrrMstr = objBusinessManpowerDetails.ReadManpowerRecruitmentId(ObjEntityManpowerRecruitment);
        if (dtMnpwrrMstr.Rows.Count > 0)
        {
            //txt.Text = dtMnpwrrMstr.Rows[0]["SPNSR_NAME"].ToString();
            string rejectststs = dtMnpwrrMstr.Rows[0]["REJECT_STATUS"].ToString();

            string status = dtMnpwrrMstr.Rows[0]["MNP_PROCESS_STATUS"].ToString();
            string cnfrmstatus = dtMnpwrrMstr.Rows[0]["MNP_CONFIRM"].ToString();

            if (status == "1")
            {
                //***
                btnConfirm.Visible = false;
                btnHrconfirm.Visible = false;

                brnGMapprove.Visible = false;
                imgbtnReOpen.Visible = false;
                divhApproval.Visible = false;
                HiddenDivHrSts.Value = "0";
                if (rejectststs == "1")
                {

                    divhApproval.Visible = true;
                    divhApproval.Disabled = false;
                    txthrnote.Enabled = false;
                    txtverifieddate.Enabled = false;
                    HiddenDivHrSts.Value = "0";
                }
            }
            if (status == "2" && intEnableHrConfirm == 1)
            {
                btnGMreject.Visible = false;
                //vvvv
                btnHrconfirm.Visible = true;
                brnGMapprove.Visible = false;
                btnHrReject.Visible = true;
                divhApproval.Visible = true;
                HiddenDivHrSts.Value = "1";
            }
            else if (status == "2" && intEnableHrConfirm == 0)
            {

                btnHrconfirm.Visible = false;
                btnUpdate.Visible = false;
                brnGMapprove.Visible = false;
                btnUpdateClose.Visible = false;
                divhApproval.Visible = false;
                HiddenDivHrSts.Value = "0";


            }
            if (status == "3" && intEnableGMApprove == 1)
            {
                brnGMapprove.Visible = true;

                // brnGMapprove.Visible = false;
                btnGMreject.Visible = true;
                divhApproval.Visible = true;
                txtverifieddate.Enabled = false;
                txthrnote.Enabled = false;
                btnHrReject.Visible = false;
                divhApproval.Disabled = true;
                imgbtnReOpen.Visible = false;
                HiddenDivHrSts.Value = "0";
            }

            else if (status == "3" && intEnableGMApprove == 0)
            {

                btnHrconfirm.Visible = false;
                btnUpdate.Visible = false;
                brnGMapprove.Visible = false;
                btnUpdateClose.Visible = false;
                btnHrReject.Visible = false;
                divhApproval.Disabled = true;
                imgbtnReOpen.Visible = false;
                txtverifieddate.Enabled = false;
                txthrnote.Enabled = false;
                HiddenDivHrSts.Value = "0";

            }
            if (status == "4")
            {
                btnHrconfirm.Visible = false;
                btnUpdate.Visible = false;
                brnGMapprove.Visible = false;
                btnUpdateClose.Visible = false;
                divhApproval.Visible = false;
                btnGMreject.Visible = false;
                btnHrReject.Visible = false;
                imgbtnReOpen.Visible = false;
                HiddenDivHrSts.Value = "0";
                btnCancel.Focus();
            }

            DesignationLoad();
          //  DivisionLoad();
            projectLoad();
            IntenderLoad();
            PaygradeLoad();
            IntenderLoad();
            //Personal details
            CountryLoad();
            DepartmentLoad();


            txtrqstdate.Text = dtMnpwrrMstr.Rows[0]["DATE OF REQUEST"].ToString();

            TxtdivRqrdDate.Text = dtMnpwrrMstr.Rows[0]["REQUIRED DATE"].ToString();

            txtRqrmntNo.Text = dtMnpwrrMstr.Rows[0]["MNP_RESOURCENUM"].ToString();
            TxtRefNo.Text = dtMnpwrrMstr.Rows[0]["MNP_REFNUM"].ToString();
            if (dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString() != "")
            {
                if (ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()) != null)
                {
                    ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["DSGN_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString());
                    ddlDesignation.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDesignation);

                    ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
                }
            }
            //  ddlDesignation.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DESIGID"].ToString()).Selected = true;
            if (dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString() != "")
            {
                if (ddlDivision.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString()) != null)
                {
                    ddlDivision.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CPRDIV_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString());
                    ddlDivision.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDivision);

                    ddlDivision.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DIVID"].ToString()).Selected = true;
                }
            }
            if (dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString() != "")
            {
                if (ddlDepartment.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString()) != null)
                {
                    ddlDepartment.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CPRDEPT_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString());
                    ddlDepartment.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlDepartment);

                    ddlDepartment.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_DEPID"].ToString()).Selected = true;
                }
            }

            //if (dtMnpwrrMstr.Rows[0]["MNP_PROJID"] != DBNull.Value||dtMnpwrrMstr.Rows[0]["MNP_PROJID"] != "")
            // {
            // ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
            // }

            //txtnoEmpInSamepos.Text = dtMnpwrrMstr.Rows[0]["MNP_EXPERIENCE"].ToString();

            txtYrOfExp.Text = dtMnpwrrMstr.Rows[0]["MNP_EXPERIENCE"].ToString();

            txtrsnforrqrmnt.Text = dtMnpwrrMstr.Rows[0]["MNP_RECRUTRSN"].ToString();
            if (dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString() != "")
            {
                if (ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()) != null)
                {
                    ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["PROJECT_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString());
                    ddlProject.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlProject);

                    ddlProject.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PROJID"].ToString()).Selected = true;
                }

            }
            //  ddlPrefnationlitiies.Text = dtMnpwrrMstr.Rows[0]["MNPRQST_ID"].ToString();

            txtothrbenefits.Text = dtMnpwrrMstr.Rows[0]["MNP_OTHRBENEFITS"].ToString();
            //ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()).Selected = true;

            //  ddlpaygrade.Text = dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString();


            txtcomments.Text = dtMnpwrrMstr.Rows[0]["MNP_COMMENTS"].ToString();
            if (dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString() != "")
            {

                if (ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()) != null)
                {
                    ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["PYGRD_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString());
                    ddlpaygrade.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlpaygrade);

                    ddlpaygrade.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_PAYGRDID"].ToString()).Selected = true;
                }
            }
            if (dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString() != "")
            {
                if (ddlIdenter.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString()) != null)
                {
                    ddlIdenter.Text = dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString();

                }
                else
                {
                    ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["USR_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString());
                    ddlIdenter.Items.Insert(1, lstGrp);

                    SortDDL(ref this.ddlIdenter);

                    ddlIdenter.Items.FindByValue(dtMnpwrrMstr.Rows[0]["MNP_IDENTER_ID"].ToString()).Selected = true;
                }

            }


            int intStatus = Convert.ToInt32(dtMnpwrrMstr.Rows[0]["STATUS"]);
            if (intStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }


            for (int i = 0; i < dtMnpwrrMstr.Rows.Count; i++)
            {
                if (dtMnpwrrMstr.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "" && dtMnpwrrMstr.Rows[0]["CNTRY_STATUS"].ToString() == "1")
                {
                  
                        chkbxListCountry.Items.FindByValue(dtMnpwrrMstr.Rows[0]["COUNTRY ID"].ToString()).Selected = true;

                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtMnpwrrMstr.Rows[0]["CNTRY_NAME"].ToString(), dtMnpwrrMstr.Rows[0]["COUNTRY ID"].ToString());
                        chkbxListCountry.Items.Insert(1, lstGrp);

                        SortDDL(ref this.ddlpaygrade);

                        chkbxListCountry.Items.FindByValue(dtMnpwrrMstr.Rows[0]["COUNTRY ID"].ToString()).Selected = true;
                    }
               
            }
            txtverifieddate.Text = dtMnpwrrMstr.Rows[0]["VERIFIEDDATE"].ToString();
            txthrnote.Text = dtMnpwrrMstr.Rows[0]["MNP_HRNOTES"].ToString();
            txtrqstdate.Enabled = false;
            txtgmNotes.Text = dtMnpwrrMstr.Rows[0]["MNP_GMNOTES"].ToString();
            if (dtMnpwrrMstr.Rows[0]["MNP_CNCL_USR_ID"].ToString() != "" && dtMnpwrrMstr.Rows[0]["MNP_CNCL_USR_ID"].ToString() != null )
            {
                cbxStatus.Enabled = false;
                Image1.Disabled = true;
                Image6.Disabled = true;
                btnHrReject.Visible = false;
                btnConfirm.Visible = false;
                btnHrconfirm.Visible = false;
                txtverifieddate.Enabled = false;
                txthrnote.Enabled = false;
                Image18.Disabled = true;
            }
          
        }
          if (txtgmNotes.Text == "")
          {
              DivGmreject.Visible = false;
             // txtgmNotes.Visible =false;
          }
        else
              DivGmreject.Visible = true;
        TxtdivRqrdDate.Enabled = false;

        txtRqrmntNo.Enabled = false;
         ddlDesignation.Enabled = false;
            ddlDivision.Enabled = false;
       ddlDepartment.Enabled = false;
         ddlProject.Enabled = false;
        txtnoEmpInSamepos.Enabled = false;
        txtYrOfExp.Enabled = false;
        txtrsnforrqrmnt.Enabled = false;
         chkbxListCountry.Enabled = false;
        txtothrbenefits.Enabled = false;
         ddlpaygrade.Enabled = false;
        txtcomments.Enabled = false;
        ddlIdenter.Enabled = false;
        txtothrbenefits.Enabled = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        Chkall.Enabled = false;
        // }
        // }

        //  objBusinessManpowerDetails.AddManpowerRecruitment(ObjEntityManpowerRecruitment);
        //evm-0023 view buttons disabled
        if (Request.QueryString["RFGP"] != null)
        {
            btnHrReject.Visible = false;

            txtverifieddate.Enabled = false;
            txthrnote.Enabled = false;
            Image18.Visible = false;
            imgbtnReOpen.Visible = false;

            brnGMapprove.Visible = false;
            btnGMreject.Visible = false;
        }
    }  
    //vv
    
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
      //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
      //  objEntityCommon.CorporateID = intCorpId;
      //  objEntityCommon.Organisation_Id = intOrgId;
      //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

       ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
        //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        ObjEntityManpowerRecruitment.RequestDate = objCommonLibrary.textToDateTime(txtrqstdate.Text);

        ObjEntityManpowerRecruitment.RequestDate1 = objCommonLibrary.textToDateTime(TxtdivRqrdDate.Text);
        ObjEntityManpowerRecruitment.No_Resources = Convert.ToInt32(txtRqrmntNo.Text);
        ObjEntityManpowerRecruitment.Reference_Number = TxtRefNo.Text;

        if (ddlDesignation.SelectedItem.Text == "--SELECT DESIGNATION--")
        {
            ObjEntityManpowerRecruitment.DesignationId = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
        }

        if (ddlDivision.SelectedItem.Text == "--SELECT DIVISION--")
        {
            ObjEntityManpowerRecruitment.DivisionId = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
        }

        if (ddlDepartment.SelectedItem.Text == "--SELECT DEPARTMENT--")
        {
            ObjEntityManpowerRecruitment.Derpartment = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.Derpartment = Convert.ToInt32(ddlDepartment.Text);
        }

        if (ddlProject.SelectedItem.Text == "--SELECT PROJECT--")
        {
            ObjEntityManpowerRecruitment.Project = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.Project = Convert.ToInt32(ddlProject.SelectedValue);
        }

        ObjEntityManpowerRecruitment.ExperienceRqrd = Convert.ToInt32(txtYrOfExp.Text);
        ObjEntityManpowerRecruitment.RecruitReason = txtrsnforrqrmnt.Text;
        ObjEntityManpowerRecruitment.OtherBenefits = txtothrbenefits.Text;
        //  ObjEntityManpowerRecruitment.PaygradeId = 
        if (ddlpaygrade.SelectedItem.Text == "--SELECT PAYGRADE--")
        {
            ObjEntityManpowerRecruitment.PaygradeId = 0;
        }
        else
        {


            ObjEntityManpowerRecruitment.PaygradeId = Convert.ToInt32(ddlpaygrade.SelectedValue);
        }



        ObjEntityManpowerRecruitment.Comments = txtcomments.Text;
        // ObjEntityManpowerRecruitment.Identer =Convert.ToInt32( ddlIdenter.Text);
        if (ddlIdenter.SelectedItem.Text == "--SELECT IDENTER--")
        {
            ObjEntityManpowerRecruitment.Identer = 0;
        }
        else
        {


            ObjEntityManpowerRecruitment.Identer = Convert.ToInt32(ddlIdenter.SelectedValue);
        }


        ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
        ObjEntityManpowerRecruitment.Comments = txtcomments.Text;


        ObjEntityManpowerRecruitment.PrefferedMastrID = Int32.Parse(Hiddenrqstid.Value);
        int j = 0;
        for (int i = 0; i < chkbxListCountry.Items.Count; i++)
        {

            if (chkbxListCountry.Items[i].Selected)
            {
                j++;
                //CllsEntityPrefferedNationaity ObjEntityPrefferedNationaitytemp = new CllsEntityPrefferedNationaity();

                ObjEntityManpowerRecruitment.PrefCountry_id[j] = Int32.Parse(chkbxListCountry.Items[i].Value);  



            }
        }

        objBusinessManpowerDetails.UpdateManpowerRecruitment(ObjEntityManpowerRecruitment);
        if (clickedButton.ID == "btnUpdate")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);

            Response.Redirect("gen_Manpower_Recruitment.aspx?InsUpd=Upd");
            ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
        }
        else if (clickedButton.ID == "btnUpdateClose")
        {
            Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Upd");


        }
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);

    }
    protected void btnHrconfirm_Click(object sender, EventArgs e)
    {
        Update_MAnpower();
        divhApproval.Visible = true;
        HiddenDivHrSts.Value = "1";
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.ApprovalUsrId1 = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
        //  objEntityCommon.CorporateID = intCorpId;
        //  objEntityCommon.Organisation_Id = intOrgId;
        //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        ObjEntityManpowerRecruitment.ApprovalStats1 = 1;
        ObjEntityManpowerRecruitment.Application_Status = 3;
        ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
        //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
        ObjEntityManpowerRecruitment.RequestDate2 = objCommonLibrary.textToDateTime(txtverifieddate.Text);
        ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
        objBusinessManpowerDetails.Verify(ObjEntityManpowerRecruitment);
        btnHrconfirm.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=verify");
        
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmed", "SuccessConfirmed();", true);
    }
    protected void brnGMapprove_Click(object sender, EventArgs e)
    {
        divhApproval.Visible = true;
        HiddenDivHrSts.Value = "0";
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
       // GetEmployeeCount();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.ApprovalUsrId2 = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
        //  objEntityCommon.CorporateID = intCorpId;
        //  objEntityCommon.Organisation_Id = intOrgId;
        //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        ObjEntityManpowerRecruitment.ApprovalStats2 = 1;
        ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
        ObjEntityManpowerRecruitment.Application_Status = 4;
        //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
        ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
        objBusinessManpowerDetails.Approve(ObjEntityManpowerRecruitment);
        btnHrconfirm.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        brnGMapprove.Visible = false;
        Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Appr");

        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
    }

  [WebMethod]
    public static string GetEmployeeCount(int dept, int div)
    { 


    
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        //if (ddlDesignation.SelectedItem.Text == "--SELECT DESIGNATION--" || ddlDesignation.SelectedItem.Text=="")
        //{
        //    ObjEntityManpowerRecruitment.DesignationId = 0;
        //}
        //else
        //{

        //    ObjEntityManpowerRecruitment.DesignationId = Int32.Parse(ddlDesignation.SelectedValue);
        //}


        //if (ddlDepartment.SelectedItem.Text == "--SELECT DEPARTMENT--")
        //{
        //    ObjEntityManpowerRecruitment.Derpartment = 0;
        //}
        //else
        //{

        //    ObjEntityManpowerRecruitment.Derpartment = Convert.ToInt32(ddlDepartment.Text);
        //}
        ObjEntityManpowerRecruitment.DesignationId = dept;
        ObjEntityManpowerRecruitment.DivisionId = div;
        string count = objBusinessManpowerDetails.GetEmployeeCount(ObjEntityManpowerRecruitment);
       // txtnoEmpInSamepos.Text = count;
        return count;
    }
  protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
  {
      clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();

      //  clsEntityReports ObjLeadReport = new clsEntityReports();
      if (Session["CORPOFFICEID"] != null)
      {
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }

      //int divid = 0;if (ddlDesignation.SelectedItem.Text == "--SELECT DESIGNATION--")

      if (ddlDesignation.SelectedItem.Text == "--SELECT DESIGNATION--")
      {
          
            ObjEntityManpowerRecruitment.DesignationId = 0;
        }
        else
        {

            ObjEntityManpowerRecruitment.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
        }
     // ObjEntityManpowerRecruitment.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
      if (ddlDivision.SelectedItem.Text == "--SELECT DIVISION--")
      {
          ObjEntityManpowerRecruitment.DivisionId = 0;
      }
      else
      {

          ObjEntityManpowerRecruitment.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
      }

         if (ddlDepartment.SelectedItem.Text == "--SELECT DEPARTMENT--")
         {
             ObjEntityManpowerRecruitment.Derpartment = 0;
         }
         else
         {

             ObjEntityManpowerRecruitment.Derpartment = Convert.ToInt32(ddlDepartment.Text);
         }
   //   ObjEntityManpowerRecruitment.Derpartment =  Convert.ToInt32(ddlDepartment.SelectedValue);
      DataTable dtProject = objBusinessMNPWRDetails.ReadProject(ObjEntityManpowerRecruitment);
      if (dtProject.Rows.Count > 0)
      {
          ddlProject.DataSource = dtProject;
          // ddlprojectassign.DataSource = dtProject;

          ddlProject.DataValueField = "PROJECT_ID";
          ddlProject.DataTextField = "PROJECT_NAME";

          ////  ddlprojectassign.DataValueField = "PROJECT_ID";
          // ddlprojectassign.DataTextField = "PROJECT_NAME";

          //ddlProjct.DataValueField = "PROJECT_ID";
          ddlProject.DataBind();
          //ddlprojectassign.DataBind();
      }
      // ddlprojectassign.Items.Insert(0, "--SELECT PROJECT--");
      ddlProject.Items.Insert(0, "--SELECT PROJECT--");

  }
  protected void btnConfirm_Click(object sender, EventArgs e)
  {
      Update_MAnpower();
      
        clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
        CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
        //  clsEntityReports ObjLeadReport = new clsEntityReports();
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            // intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityManpowerRecruitment.ApprovalUsrId1 = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
        //  objEntityCommon.CorporateID = intCorpId;
        //  objEntityCommon.Organisation_Id = intOrgId;
        //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
        ObjEntityManpowerRecruitment.Confirm_Status = 1;
        ObjEntityManpowerRecruitment.Application_Status = 2;
        ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
        //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
        ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
        ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
        objBusinessManpowerDetails.Confirm(ObjEntityManpowerRecruitment);
        btnHrconfirm.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        Response.Redirect("gen_Manpower_Recruitment.aspx?InsUpd=Conf");
        ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmed", "SuccessConfirmed();", true);
    
  }
  protected void imgbtnReOpen_Click(object sender, ImageClickEventArgs e)
  {
      clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
      clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
      clsEntityCommon objEntityCommon = new clsEntityCommon();
      clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
      //  clsEntityReports ObjLeadReport = new clsEntityReports();
      if (Session["CORPOFFICEID"] != null)
      {
          intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.ApprovalUsrId1 = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
      //  objEntityCommon.CorporateID = intCorpId;
      //  objEntityCommon.Organisation_Id = intOrgId;
      //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
      ObjEntityManpowerRecruitment.Confirm_Status = 0;
      ObjEntityManpowerRecruitment.Application_Status = 1;
      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
      ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
      objBusinessManpowerDetails.Confirm(ObjEntityManpowerRecruitment);
      btnHrconfirm.Visible = false;
      btnUpdate.Visible = false;
      btnUpdateClose.Visible = false;
      Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Reopen");
      ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopened", "SuccessReopened();", true);


  }
  protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
  {
      clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
      clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
      clsEntityCommon objEntityCommon = new clsEntityCommon();
      clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
      //  clsEntityReports ObjLeadReport = new clsEntityReports();
      if (Session["CORPOFFICEID"] != null)
      {
          intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
      
          ObjEntityManpowerRecruitment.ApprovalUsrId1 = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
      //  objEntityCommon.CorporateID = intCorpId;
      //  objEntityCommon.Organisation_Id = intOrgId;
      //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
      ObjEntityManpowerRecruitment.Confirm_Status = 0;
      ObjEntityManpowerRecruitment.Application_Status = 7;
      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate1 = DateTime.Today;
     
      ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
      objBusinessManpowerDetails.Close(ObjEntityManpowerRecruitment);
      btnHrconfirm.Visible = false;
      btnUpdate.Visible = false;
      btnUpdateClose.Visible = false;
      Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Close");
   //   ScriptManager.RegisterStartupScript(this, GetType(), "SuccessClosed", "SuccessClosed();", true);

  }
  protected void btnreject_Click(object sender, EventArgs e)
  {

      Update_MAnpower();
      divhApproval.Visible = true;
      clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
      clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
      clsEntityCommon objEntityCommon = new clsEntityCommon();
      clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
      //  clsEntityReports ObjLeadReport = new clsEntityReports();
      if (Session["CORPOFFICEID"] != null)
      {
          intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.ApprovalUsrId1 = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
      //  objEntityCommon.CorporateID = intCorpId;
      //  objEntityCommon.Organisation_Id = intOrgId;
      //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
      ObjEntityManpowerRecruitment.Confirm_Status = 0;
      ObjEntityManpowerRecruitment.Application_Status = 1;
      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
      ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
      objBusinessManpowerDetails.Confirm(ObjEntityManpowerRecruitment);
 
      
      
      
      
      ObjEntityManpowerRecruitment.ApprovalStats1 = 0;
      ObjEntityManpowerRecruitment.Application_Status = 1;
      ObjEntityManpowerRecruitment.RejectStatus = 1;
      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
      ObjEntityManpowerRecruitment.RequestDate2 = objCommonLibrary.textToDateTime(txtverifieddate.Text);
      ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
      objBusinessManpowerDetails.Verify(ObjEntityManpowerRecruitment);
      btnHrconfirm.Visible = false;
      btnUpdate.Visible = false;
      btnUpdateClose.Visible = false;
     // Response.Redirect("gen_Manpower_Recruitment.aspx?InsUpd=Rejctd");
      Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Rejctd");
     // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmed", "SuccessConfirmed();", true);

  
  
  
  
  
  
  }
  protected void    Update_MAnpower()
  {
      clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
      clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
      clsEntityCommon objEntityCommon = new clsEntityCommon();
      clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
      //  clsEntityReports ObjLeadReport = new clsEntityReports();
      if (Session["CORPOFFICEID"] != null)
      {
          intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
      //  objEntityCommon.CorporateID = intCorpId;
      //  objEntityCommon.Organisation_Id = intOrgId;
      //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);

      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate = objCommonLibrary.textToDateTime(txtrqstdate.Text);

      ObjEntityManpowerRecruitment.RequestDate1 = objCommonLibrary.textToDateTime(TxtdivRqrdDate.Text);
      ObjEntityManpowerRecruitment.No_Resources = Convert.ToInt32(txtRqrmntNo.Text);
      ObjEntityManpowerRecruitment.Reference_Number = TxtRefNo.Text;

      if (ddlDesignation.SelectedItem.Text == "--SELECT DESIGNATION--")
      {
          ObjEntityManpowerRecruitment.DesignationId = 0;
      }
      else
      {

          ObjEntityManpowerRecruitment.DesignationId = Convert.ToInt32(ddlDesignation.SelectedValue);
      }

      if (ddlDivision.SelectedItem.Text == "--SELECT DIVISION--")
      {
          ObjEntityManpowerRecruitment.DivisionId = 0;
      }
      else
      {

          ObjEntityManpowerRecruitment.DivisionId = Convert.ToInt32(ddlDivision.SelectedValue);
      }

      if (ddlDepartment.SelectedItem.Text == "--SELECT DEPARTMENT--")
      {
          ObjEntityManpowerRecruitment.Derpartment = 0;
      }
      else
      {

          ObjEntityManpowerRecruitment.Derpartment = Convert.ToInt32(ddlDepartment.Text);
      }

      if (ddlProject.SelectedItem.Text == "--SELECT PROJECT--")
      {
          ObjEntityManpowerRecruitment.Project = 0;
      }
      else
      {

          ObjEntityManpowerRecruitment.Project = Convert.ToInt32(ddlProject.SelectedValue);
      }

      ObjEntityManpowerRecruitment.ExperienceRqrd = Convert.ToInt32(txtYrOfExp.Text);
      ObjEntityManpowerRecruitment.RecruitReason = txtrsnforrqrmnt.Text;
      ObjEntityManpowerRecruitment.OtherBenefits = txtothrbenefits.Text;
      //  ObjEntityManpowerRecruitment.PaygradeId = 
      if (ddlpaygrade.SelectedItem.Text == "--SELECT PAYGRADE--")
      {
          ObjEntityManpowerRecruitment.PaygradeId = 0;
      }
      else
      {


          ObjEntityManpowerRecruitment.PaygradeId = Convert.ToInt32(ddlpaygrade.SelectedValue);
      }



      ObjEntityManpowerRecruitment.Comments = txtcomments.Text;
      // ObjEntityManpowerRecruitment.Identer =Convert.ToInt32( ddlIdenter.Text);
      if (ddlIdenter.SelectedItem.Text == "--SELECT IDENTER--")
      {
          ObjEntityManpowerRecruitment.Identer = 0;
      }
      else
      {


          ObjEntityManpowerRecruitment.Identer = Convert.ToInt32(ddlIdenter.SelectedValue);
      }


      ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
      ObjEntityManpowerRecruitment.Comments = txtcomments.Text;


      ObjEntityManpowerRecruitment.PrefferedMastrID = Int32.Parse(Hiddenrqstid.Value);
      int j = 0;
      for (int i = 0; i < chkbxListCountry.Items.Count; i++)
      {

          if (chkbxListCountry.Items[i].Selected)
          {
              j++;
              //CllsEntityPrefferedNationaity ObjEntityPrefferedNationaitytemp = new CllsEntityPrefferedNationaity();

              ObjEntityManpowerRecruitment.PrefCountry_id[j] = Int32.Parse(chkbxListCountry.Items[i].Value);



          }
      }

      objBusinessManpowerDetails.UpdateManpowerRecruitment(ObjEntityManpowerRecruitment);

  }
  protected void btnGMreject_Click(object sender, EventArgs e)
  {
      divhApproval.Visible = true;
      clsBusinessLayerManpowerRecruitment objBusinessManpowerDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      CllsEntityPrefferedNationaity ObjEntityPrefferedNationaity = new CllsEntityPrefferedNationaity();
      clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
      clsEntityCommon objEntityCommon = new clsEntityCommon();
      clsCommonLibrary objCommonLibrary = new clsCommonLibrary();
      //  clsEntityReports ObjLeadReport = new clsEntityReports();
      // GetEmployeeCount();
      if (Session["CORPOFFICEID"] != null)
      {
          intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.ApprovalUsrId2 = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.MANPOWER_RECRUITMENT);
      //  objEntityCommon.CorporateID = intCorpId;
      //  objEntityCommon.Organisation_Id = intOrgId;
      //  string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objEntityCommon);
      ObjEntityManpowerRecruitment.Confirm_Status = 0;
      ObjEntityManpowerRecruitment.Application_Status = 1;
      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
      ObjEntityManpowerRecruitment.HrNotes = txthrnote.Text;
      objBusinessManpowerDetails.Confirm(ObjEntityManpowerRecruitment);
 




      ObjEntityManpowerRecruitment.ApprovalStats2 = 0;
      ObjEntityManpowerRecruitment.RequestId = Convert.ToInt32(Hiddenrqstid.Value);
      ObjEntityManpowerRecruitment.Application_Status = 1;
      ObjEntityManpowerRecruitment.RejectStatus = 1;
      //  CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      ObjEntityManpowerRecruitment.RequestDate3 = DateTime.Today;
      ObjEntityManpowerRecruitment.HrNotes = txtCnclReason.Text;
      objBusinessManpowerDetails.Approve(ObjEntityManpowerRecruitment);
      btnHrconfirm.Visible = false;
      btnUpdate.Visible = false;
      btnUpdateClose.Visible = false;
      brnGMapprove.Visible = false;
      Response.Redirect("gen_Manpower_Recruitment_List.aspx?InsUpd=Rejctd");

      ScriptManager.RegisterStartupScript(this, GetType(), "SuccessApproved", "SuccessApproved();", true);
  }

  protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)     //emp25
  {
      clsBusinessLayerJobDetails objBusinessJobDetails = new clsBusinessLayerJobDetails();
      clsEntityJobDetails objEntityJobDetails = new clsEntityJobDetails();
      clsBusinessLayerManpowerRecruitment objBusinessMNPWRDetails = new clsBusinessLayerManpowerRecruitment();
      CllsEntityManpowerRecruitment ObjEntityManpowerRecruitment = new CllsEntityManpowerRecruitment();
      if (Session["CORPOFFICEID"] != null)
      {
          ObjEntityManpowerRecruitment.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
      }
      else if (Session["CORPOFFICEID"] == null)
      {
          Response.Redirect("~/Default.aspx");
      }
      if (Session["ORGID"] != null)
      {
          ObjEntityManpowerRecruitment.orgid = Convert.ToInt32(Session["ORGID"].ToString());
      }
      else if (Session["ORGID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      if (Session["USERID"] != null)
      {
          // intUserId = Convert.ToInt32(Session["USERID"]);
          ObjEntityManpowerRecruitment.UserId = Convert.ToInt32(Session["USERID"]);
      }
      else if (Session["USERID"] == null)
      {
          Response.Redirect("/Default.aspx");
      }
      ddlDivision.Items.Clear();
      ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
      if (ddlDepartment.SelectedItem.Value != "--SELECT DEPARTMENT--")
      {
          int Dept = Convert.ToInt32(ddlDepartment.SelectedItem.Value);
          ObjEntityManpowerRecruitment.Derpartment = Dept;
          DataTable dtDivision = objBusinessMNPWRDetails.ReadDivision(ObjEntityManpowerRecruitment);
          ddlDivision.Items.Clear();
          ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
          if (dtDivision.Rows.Count > 0)
          {
              ddlDivision.Items.Clear();
              ddlDivision.DataSource = dtDivision;


              ddlDivision.DataValueField = "CPRDIV_ID";
              ddlDivision.DataTextField = "CPRDIV_NAME";

              ddlDivision.DataBind();
              ddlDivision.Items.Insert(0, "--SELECT DIVISION--");
          }

      }


  }


}